using KNet.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_ProductSubmitted_Knet_Submitted_Product_List : BasePage
{
    public string s_AdvShow = "", s_Type1 = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin() == false)
            {
                Response.Write(
                    "<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string AuditState = Request.QueryString["AuditState"] == null ? "" : Request.QueryString["AuditState"].ToString();
            if (s_ID != "" && AuditState != "")
            {
                if (AM.YNAuthority("审核请购单"))
                {
                    string DoSqlOrder = " update KNet_Sampling_List set  AuditState='" + AuditState + "' where ID='" + s_ID + "' ";
                    DbHelperSQL.ExecuteSql(DoSqlOrder);
                }
                else
                {
                    Response.Write(
                   "<script language=javascript>alert('您没有审核请购单的权限!')</script>");
                }
            }


            this.Btn_Del.Attributes.Add("onclick", "return confirm('你确信要删除所选记录吗?！\\n\\n注意：该删除会同时删除出库单产品明细记录.')");
            base.Base_DropBindSearch(this.bas_searchfield, "Knet_Submitted_Product");
            base.Base_DropBindSearch(this.Fields, "Knet_Submitted_Product");
            base.Base_DropWareHouseBind(this.Ddl_StaffNo, "  KSW_Type=0 and HouseNo!='131235104473261008' ");
            //Base_StaffNo(this.Ddl_StaffNo);
            this.DataShows();
            this.RowOverYN();
        }
    }

    /// <summary>
    /// 是不是有记录
    /// </summary>
    protected void RowOverYN()
    {
        if (MyGridView1.Rows.Count == 0) //如果没有记录
        {
            this.Btn_Del.Enabled = false;
        }
    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        AdminloginMess AM = new AdminloginMess();

        KNet.BLL.Knet_Submitted_Product bll = new KNet.BLL.Knet_Submitted_Product();
        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string s_ProductsBarCode = Request["ProductsBarCode"] == null ? "" : Request["ProductsBarCode"].ToString();
        string s_Type = "";

        string SqlWhere = " 1=1 and KSP_Type=1 ";


        if (s_WhereID != "")
        {
            SqlWhere += Base_GetBasicWhere(s_WhereID);
        }

        if ((this.bas_searchfield.SelectedValue != "") && (search_text.Text != ""))
        {
            SqlWhere += base.Base_GetBasicColumnWhere(this.bas_searchfield.SelectedValue, this.search_text.Text);
        }

        if (s_Text != "")
        {
            if (this.matchtype1.Checked == true)//and
            {
                s_Type = "0";
            }
            if (this.matchtype2.Checked == true)
            {
                s_Type = "1";
            }
            SqlWhere += base.Base_GetAdvWhere(s_Fields, s_Condition, s_Text, s_Type);
        }
        string s_SalesOrderNo = Request.QueryString["SalesOrderNo"] == null ? "" : Request.QueryString["SalesOrderNo"].ToString();

        if (s_SalesOrderNo != "")
        {
            SqlWhere += " and ID like '%" + s_SalesOrderNo + "%' ";
        }
        if (this.Ddl_StaffNo.SelectedValue != "")
        {
            SqlWhere += " and KSP_HouseNo='" + this.Ddl_StaffNo.SelectedValue + "' ";
        }


        //SqlWhere += " order by SYstemDateTimes desc";
        //string SqlWhere = " 1=1  ";
        //if (this.Ddl_StaffNo.SelectedValue != "")
        //{
        //    SqlWhere += " and Proposer='" + this.Ddl_StaffNo.SelectedValue + "' ";
        //}
        SqlWhere = SqlWhere + " order by KSP_Stime desc ";
        DataSet ds = bll.GetList(SqlWhere);
        MyGridView1.DataSource = ds;
        MyGridView1.DataKeyNames = new string[] { "KSP_SID" };
        MyGridView1.DataBind();
    }

    protected void Btn_Del_Click(object sender, EventArgs e)
    {


        for (int i = 0; i < MyGridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)MyGridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {

                KNet.BLL.Knet_Submitted_Product_Details BLL = new KNet.BLL.Knet_Submitted_Product_Details();
                KNet.BLL.Knet_Submitted_Product KSP_Bll = new KNet.BLL.Knet_Submitted_Product();
               bool b= KSP_Bll.Delete(MyGridView1.DataKeys[i].Value.ToString());
                bool a = BLL.Delete(MyGridView1.DataKeys[i].Value.ToString());
                if (a)
                {
                    AdminloginMess LogAM = new AdminloginMess();
                    LogAM.Add_Logs("送检单 删除 操作成功！送检单号："+ MyGridView1.DataKeys[i].Value.ToString() + " ");
                    Alert("删除成功");
                    this.DataShows();
                    this.RowOverYN();
                }
                else
                {
                    Alert("删除失败");
                }
            }
        }
    }

    public void btnBasicSearch_Click(object sender, EventArgs e)
    {
        this.advSearch.Style["display"] = "none";
        this.Search_basic.Style["display"] = "block";
        this.DataShows();
    }
    public void btnAdvancedSearch_Click(object sender, EventArgs e)
    {
        this.Search_basic.Style["display"] = "none";
        this.advSearch.Style["display"] = "block";

        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string[] arr_Fields = s_Fields.Split(',');
        string[] arr_Condition = s_Condition.Split(',');
        string[] arr_Text = s_Text.Split(',');
        this.Fields.SelectedValue = arr_Fields[0];
        this.Condition.SelectedValue = arr_Condition[0];
        this.Srch_value.Text = arr_Text[0];
        s_AdvShow = Base_GetAdvShowHtml(arr_Fields, arr_Condition, arr_Text);
        this.DataShows();
    }

    protected void Ddl_Batch_TextChanged(object sender, EventArgs e)
    {
        this.DataShows();
    }

    protected void GridView1_DataRowBinding(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            KNet.BLL.Knet_Submitted_Product Bll = new KNet.BLL.Knet_Submitted_Product();

            string DirectInNo = MyGridView1.DataKeys[e.Row.RowIndex].Value.ToString(); //获取ID值
            CheckBox cb = (CheckBox)e.Row.Cells[1].FindControl("Chbk");
            this.BeginQuery("select KSP_State from Knet_Submitted_Product where KSP_SID='" + DirectInNo + "' and KSP_State=1");
            this.QueryForDataTable();
            DataTable Dtb_Re = Dtb_Result;
            //KNet.Model.KNet_Sampling_List Model = Bll.GetModel(DirectInNo);
            if (Convert.ToInt32(Dtb_Re.Rows.Count)<= 0)
            {
                cb.Enabled = true;
            }
            else
            {
                cb.Enabled = false;
            }
        }
    }
    /// <summary>
    /// 采购状态
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    //protected string GetBuyStateYN(object aa)
    //{

    //}

    protected string GetInHouseYN(string aa,string order)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            //string Dostr = "select * from KNet_Sampling_List where ID='" + aa + "' ";
            //SqlCommand cmd = new SqlCommand(Dostr, conn);
            //SqlDataReader dr = cmd.ExecuteReader();
            this.BeginQuery("select ISNULL(sum( KPD_Number ), 0) from Knet_Submitted_Product a join Knet_Submitted_Product_Details b on a.KSP_SID=b.KPD_SID where KSP_OrderNo='" + order + "'");
            this.QueryForDataTable();
            DataTable Dtb_Re = Dtb_Result;
            this.BeginQuery("select ISNULL(sum( WareHouseAmount), 0) from Knet_Procure_WareHouseList a join Knet_Procure_WareHouseList_Details b on a.WareHouseNo=b.WareHouseNo where a.OrderNo='" + order + "'");
            this.QueryForDataTable();
            DataTable Dtb_Re1 = Dtb_Result;
            //if (Dtb_Re.Rows.Count > 0)
            //{
            int sj = Convert.ToInt32(Dtb_Re.Rows[0][0].ToString());//送检的物料数量
            int rk = Convert.ToInt32(Dtb_Re1.Rows[0][0].ToString());//入库的物料数量
            if (rk!=0&&(rk-sj)<0)
            {
                return "<font color=red>部分入库</font>";
            }
            else if (sj==rk)
            {

                return "<font color=blue>已入库</font>";
            }
            
            else
            {
                return "<font color=red>未入库</font>";
            }
            //}
            //else
            //{
            //    return "<font color=red>已采购</font>";
            //}
            //    if (dr.Read())
            //{
            //    if (dr["BuyState"].ToString() == "0")
            //    {
            //        return "<font color=blue>未采购</font>";
            //    }
            //    else /*if (dr["BuyState"].ToString() == "1")*/
            //    {

            //        return "<font color=red>已采购</font>";
            //    }
            //    //else if(dr["BuyState"].ToString() == "2")
            //    //{
            //    //    return "<font color=red>财务已审</font>";
            //    //}
            //}
            //else
            //{
            //    return "--";
            //}
        }
    }

    protected string GetInState(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
          
            this.BeginQuery("select KSP_State from Knet_Submitted_Product where KSP_SID='" + aa + "'");
            this.QueryForDataTable();
            DataTable Dtb_Re = Dtb_Result;
            if (Dtb_Re.Rows[0][0].ToString()=="0")
            {
                return "<font color=blue>未审</font>";
            }
            else
            {
                return "<font color=red>已审</font>";
            }
           
           
        }
    }
    protected string GetAuditState(object aa)
    {


        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {

            conn.Open();
            //string Dostr = "select * from KNet_Sampling_List where ID='" + aa + "' and AuditState='0' ";
            //SqlCommand cmd = new SqlCommand(Dostr, conn);
            //SqlDataReader dr = cmd.ExecuteReader();
            this.BeginQuery("select count(*) from KNet_Sampling_List where ID='" + aa + "' and AuditState='0'");
            this.QueryForDataTable();
            DataTable Dtb_Re = Dtb_Result;
            this.BeginQuery("select count(*) from KNet_Sampling_List where ID='" + aa + "'");
            this.QueryForDataTable();
            DataTable Dtb_Re1 = Dtb_Result;
            //if (Dtb_Re.Rows.Count > 0)
            //{
            int ws = Convert.ToInt32(Dtb_Re.Rows[0][0].ToString());
            int cot = Convert.ToInt32(Dtb_Re1.Rows[0][0].ToString());
            if (ws > 0 && ws < cot)
            {
                string JSD = "KNetSamplingList.aspx?ID=" + aa + "&AuditState=2";
                //return "<font color=red>审核中</font>";
                return "<a href=\"" + JSD + "\" onclick=\"\"  ><font color=red>部分审核</font></a>";
                //return "<font color=red>部分审核</font>";
            }
            if (ws == cot)
            {
                string JSD = "KNetSamplingList.aspx?ID=" + aa + "&AuditState=2";
                return "<a href=\"" + JSD + "\" onclick=\"\"  ><font color=blue>未审核</font></a>";
            }
            else
            {
                string JSD = "KNetSamplingList.aspx?ID=" + aa + "&AuditState=0";
                return "<a href=\"" + JSD + "\" onclick=\"\"  ><font color=red>已审核</font></a>";
            }

        }


    }
    public string Base_GetProjectGroup(String s_ID)
    {

        String s_Name = "";
        this.BeginQuery("select top 1 ProjectGroup from KNet_Sampling_List where ID='" + s_ID + "'");
        this.QueryForDataTable();
        //this.BeginQuery("select * from PB_Basic_ProductsClass where PBP_ID='" + s_ID + "'");
        //this.QueryForDataTable();
        DataTable Dtb_Re = Dtb_Result;
        if (Dtb_Re.Rows.Count > 0)
        {
            s_Name = base.Base_GetBasicCodeName("1137", Dtb_Re.Rows[0][0].ToString());
        }
        return s_Name;
    }
    /// <summary>
    /// 获取送检物料名称
    /// </summary>
    /// <param name="s_ID"></param>
    /// <returns></returns>
    public string Base_GetProductName(String s_ID)
    {


        String s_Name = "";
        this.BeginQuery("select ProductsName from KNet_Sys_Products where ProductsBarCode in (select  KPD_Code from Knet_Submitted_Product_Details where KPD_SID = '" + s_ID + "')");
        this.QueryForDataTable();
        DataTable Dtb_Re = Dtb_Result;
        if (Dtb_Re.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Re.Rows.Count; i++)
            {
                s_Name += Dtb_Re.Rows[i][0].ToString();
                s_Name += "<br/>";
            }

        }
        return s_Name;
    }

    public string Base_GetProductCode(String s_ID)
    {
        String s_Name = "";
        this.BeginQuery("select KSP_COde from KNet_Sys_Products where ProductsBarCode in (select  KPD_Code from Knet_Submitted_Product_Details where KPD_SID = '" + s_ID + "')");
        this.QueryForDataTable();
        DataTable Dtb_Re = Dtb_Result;
        if (Dtb_Re.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Re.Rows.Count; i++)
            {
                s_Name += Dtb_Re.Rows[i][0].ToString();
                s_Name += "<br/>";
            }

        }
        return s_Name;
    }
    /// <summary>
    /// 获取送检级别
    /// </summary>
    /// <param name="s_ID"></param>
    /// <returns></returns>
    public string Base_GetRank(String s_ID)
    {


        String s_Name = "";
        this.BeginQuery("select KSP_Rank from Knet_Submitted_Product where KSP_SID='"+ s_ID + "'");
        this.QueryForDataTable();
        DataTable Dtb_Re = Dtb_Result;
        string a = Dtb_Re.Rows[0][0].ToString();       
        if (a=="0")
        {
            s_Name = "";
        }
        else if (a == "1")
        {
            s_Name = "一般";
        }
        else if (a == "2")
        {
            s_Name = "加急";
        }
        else if (a=="3")
        {
            s_Name = "暂缓";
        }
        return s_Name;
    }
    /// <summary>
    /// 获取供应商
    /// </summary>
    /// <param name="SuppNo"></param>
    /// <returns></returns>
    public string Base_GetSuppName(string SuppNo)
    {
        KNet.BLL.Knet_Procure_Suppliers BLL_Supp = new KNet.BLL.Knet_Procure_Suppliers();
        KNet.Model.Knet_Procure_Suppliers Model_Supp =
            BLL_Supp.GetModelB(SuppNo);
       return Model_Supp.SuppName;
    }
    public string Base_GetSamplingNumber(String s_ID)
    {

        String s_Name = "";
        this.BeginQuery("select  KPD_Number from Knet_Submitted_Product_Details where KPD_SID = '" + s_ID + "'");
        this.QueryForDataTable();
        DataTable Dtb_Re = Dtb_Result;
        if (Dtb_Re.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Re.Rows.Count; i++)
            {
                s_Name += Dtb_Re.Rows[i][0].ToString();
                s_Name += "<br/>";
            }

        }
        return s_Name;
    }

    /// <summary>
    /// 获取抽检数量
    /// </summary>
    /// <param name="s_ID"></param>
    /// <returns></returns>
    public string Base_GetCheckNumber(String s_ID)
    {
        String s_Name = "";
        this.BeginQuery("select  KPD_CheckNumber from Knet_Submitted_Product_Details where KPD_SID = '" + s_ID + "'");
        this.QueryForDataTable();
        DataTable Dtb_Re = Dtb_Result;
        if (Dtb_Re.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Re.Rows.Count; i++)
            {
                s_Name += Dtb_Re.Rows[i][0].ToString();
                s_Name += "<br/>";
            }

        }
        return s_Name;

    }

    public string Base_GetBadNumber(String s_ID)
    {
        String s_Name = "";
        this.BeginQuery("select  KPD_BadNumber from Knet_Submitted_Product_Details where KPD_SID = '" + s_ID + "'");
        this.QueryForDataTable();
        DataTable Dtb_Re = Dtb_Result;
        if (Dtb_Re.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Re.Rows.Count; i++)
            {
                s_Name += Dtb_Re.Rows[i][0].ToString();
                s_Name += "<br/>";
            }

        }
        return s_Name;
    }

    public string Base_GetRejectRatio(string s_ID)
    {
        String s_Name = "";
        this.BeginQuery("select  KPD_RejectRatio from Knet_Submitted_Product_Details where KPD_SID = '" + s_ID + "'");
        this.QueryForDataTable();
        DataTable Dtb_Re = Dtb_Result;
        if (Dtb_Re.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Re.Rows.Count; i++)
            {
                //(decimal.Parse(Dtb_Table.Rows[i]["KPD_RejectRatio"].ToString()) * 100).ToString("f2") + "%"
                if ( decimal.Parse(Dtb_Re.Rows[i][0].ToString())<=0)
                {
                    s_Name += "0";
                    s_Name += "<br/>";
                }
                else
                {
                    s_Name += (decimal.Parse(Dtb_Re.Rows[i][0].ToString()) * 100).ToString("f2") + "%";
                    s_Name += "<br/>";
                }
               
            }

        }
        return s_Name;
    }
    public string Base_GetSamplingPrice(string s_ID)
    {
        string s_Return = "", JSD;
        JSD = "Knet_Submitted_Product_Print.aspx?ID=" + s_ID + "";
        s_Return += "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=120,left=150,toolbar=yes, menubar=yes,scrollbars=yes, resizable=yes, location=yes, status=yes, width=780,height=500');\"  title=\"点击查看\"><img src=\"../../images/View.gif\"  border=\"0\" /></a>";
        this.BeginQuery("Select KSP_State From Knet_Submitted_Product Where KSP_SID='" + s_ID + "'");
        this.QueryForDataTable();
        DataTable Dtb_Re = Dtb_Result;
        if (Dtb_Re.Rows[0][0].ToString()!="0")
        {
            s_Return += "  <a href=\"../Mail/PB_Basic_Mail_Add.aspx?SubmittedID=" + s_ID + "\" class=\"webMnu\" target=\"_blank\"><img src=\"../images/email.gif\"  border=\"0\" /></a> ";
        }
       
        //s_Return += "  <a href=\"PDF/" + s_ID + ".PDF\" class=\"webMnu\" target=\"_blank\"><img src=\"../images/pdf.gif\"  border=\"0\" /></a> ";
        //s_Return += "  <a href=\"../../Mail/PB_Basic_Mail_Add.aspx?OrderNo=" + s_ID + "\" class=\"webMnu\" target=\"_blank\"><img src=\"../images/email.gif\"  border=\"0\" /></a> ";

        return s_Return;
    }
    /// <summary>
    /// 获取送检结果
    /// </summary>
    /// <param name="s_ID"></param>
    /// <returns></returns>
    public string Base_GetResult(String s_ID)
    {

        String s_Name = "";
        this.BeginQuery("Select KPD_YNTState From Knet_Submitted_Product_Details Where KPD_SID='" + s_ID + "'");
        this.QueryForDataTable();
        DataTable Dtb_Re = Dtb_Result;
        if (Dtb_Re.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Re.Rows.Count; i++)
            {
                if (Dtb_Re.Rows[i][0].ToString()=="0")
                {
                    s_Name += "<font color=blue>未检</font>";
                    s_Name += "<br/>";
                }
                else if (Dtb_Re.Rows[i][0].ToString() == "1")
                {
                    s_Name += "<font color=blue>合格</font>";
                    s_Name += "<br/>";
                }
                else if (Dtb_Re.Rows[i][0].ToString() == "2")
                {
                    s_Name += "<font color=red>不良</font>";
                    s_Name += "<br/>";
                }
                else if (Dtb_Re.Rows[i][0].ToString() == "3")
                {
                    s_Name += "<font color=yellow>特采</font>";
                    s_Name += "<br/>";
                }
               
               
            }
        }
        return s_Name;

    }
    /// <summary>
    /// 获取送检人
    /// </summary>
    /// <param name="KSP_Proposer"></param>
    /// <returns></returns>
    public string Base_GetProposer(String KSP_Proposer)
    {
        string s_Name = "";
        this.BeginQuery("Select * From KNet_Resource_Staff Where StaffNo='" + KSP_Proposer + "'");
        this.QueryForDataTable();
        DataTable Dtb_Re = Dtb_Result;
        if (Dtb_Re.Rows.Count > 0)
        {
            s_Name = Dtb_Re.Rows[0]["StaffName"].ToString();
        }
        return s_Name;
       
    }
    protected void Btn_SpSave(object sender, EventArgs e)
    {

        //StringBuilder s_Sql = new StringBuilder();
        StringBuilder s_Log = new StringBuilder();
        AdminloginMess AM = new AdminloginMess();
        try
        {

            for (int i = 0; i < MyGridView1.Rows.Count; i++)
            {
                CheckBox Ckb = (CheckBox)MyGridView1.Rows[i].Cells[0].FindControl("Chbk");
                if (Ckb.Checked)
                {
                    string s_ID = MyGridView1.DataKeys[i].Value.ToString();
                    string DoSqlOrder = " update KNet_Sampling_List set  AuditState='2' where ID='" + s_ID + "' ";
                    DbHelperSQL.ExecuteSql(DoSqlOrder);
                    s_Log.Append(s_ID + ",");
                }
            }
            if (s_Log.ToString() == "")
            {
                Alert("未选择申请单！");
            }
            else
            {
                //this.DataBind();
                DataShows();
                AM.Add_Logs("KNetSamplingList 审批 编号：" + s_Log + "");
                Alert("批量审批成功！");
            }
        }
        catch (Exception ex)
        {
            Alert("批量审批失败！");
            return;
        }
    }
    protected void Btn_SpSave1(object sender, EventArgs e)
    {
        //StringBuilder s_Sql = new StringBuilder();
        StringBuilder s_Log = new StringBuilder();
        AdminloginMess AM = new AdminloginMess();
        try
        {

            for (int i = 0; i < MyGridView1.Rows.Count; i++)
            {
                CheckBox Ckb = (CheckBox)MyGridView1.Rows[i].Cells[0].FindControl("Chbk");

                if (Ckb.Checked)
                {
                    string s_ID = MyGridView1.DataKeys[i].Value.ToString();

                    string DoSqlOrder = " update KNet_Sampling_List set  AuditState='0' where ID='" + s_ID + "' ";
                    DbHelperSQL.ExecuteSql(DoSqlOrder);
                    s_Log.Append(s_ID + ",");
                }
            }
            if (s_Log.ToString() == "")
            {
                Alert("未选择请购单！");
            }
            else
            {
                //this.DataBind();
                DataShows();
                AM.Add_Logs("KNetSamplingList 审批 编号：" + s_Log + "");
                Alert("批量反审批成功！");
            }
        }
        catch (Exception ex)
        {
            Alert("批量审批失败！");
            return;
        }
    }
    protected void Ddl_StaffNo_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        DataShows();
    }
}