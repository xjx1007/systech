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

public partial class Web_Products_KNetSamplingList : BasePage
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
            base.Base_DropBindSearch(this.bas_searchfield, "KNet_Sampling_List");
            base.Base_DropBindSearch(this.Fields, "KNet_Sampling_List");
            Base_StaffNo(this.Ddl_StaffNo);
            base.Base_DropBasicCodeBind(this.Ddl_GroupType, "1137");
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

        KNet.BLL.KNet_Sampling_List bll = new KNet.BLL.KNet_Sampling_List();
        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string s_ProductsBarCode = Request["ProductsBarCode"] == null ? "" : Request["ProductsBarCode"].ToString();
        string s_Type = "";

        string SqlWhere = " 1=1  ";


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



        //SqlWhere += " order by SYstemDateTimes desc";
        //string SqlWhere = " 1=1  ";
        if (this.Ddl_StaffNo.SelectedValue != "")
        {
            SqlWhere += " and Proposer='" + this.Ddl_StaffNo.SelectedValue + "' ";
        }
        if (this.Ddl_GroupType.SelectedValue != "")
        {
            SqlWhere += " and ProjectGroup='" + this.Ddl_GroupType.SelectedValue + "' ";
        }
        SqlWhere = SqlWhere + " order by ID desc ";
        DataSet ds = bll.GetList(SqlWhere);
        MyGridView1.DataSource = ds;
        MyGridView1.DataKeyNames = new string[] { "ID" };
        MyGridView1.DataBind();
    }

    protected void Btn_Del_Click(object sender, EventArgs e)
    {


        for (int i = 0; i < MyGridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)MyGridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {

                KNet.BLL.KNet_Sampling_List BLL = new KNet.BLL.KNet_Sampling_List();
                bool a = BLL.Delete(MyGridView1.DataKeys[i].Value.ToString());
                if (a)
                {
                    AdminloginMess LogAM = new AdminloginMess();
                    LogAM.Add_Logs("制造费用 删除 操作成功！");
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
            KNet.BLL.KNet_Sampling_List Bll = new KNet.BLL.KNet_Sampling_List();

            string DirectInNo = MyGridView1.DataKeys[e.Row.RowIndex].Value.ToString(); //获取ID值
            CheckBox cb = (CheckBox)e.Row.Cells[1].FindControl("Chbk");
            this.BeginQuery("select count(*) from KNet_Sampling_List where ID='" + DirectInNo + "' and InState!='0'");
            this.QueryForDataTable();
            DataTable Dtb_Re = Dtb_Result;
            //KNet.Model.KNet_Sampling_List Model = Bll.GetModel(DirectInNo);
            if (Convert.ToInt32(Dtb_Re.Rows[0][0]) != 0)
            {
                cb.Enabled = false;
            }
            else
            {
                cb.Enabled = true;
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

    protected string GetBuyStateYN(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            //string Dostr = "select * from KNet_Sampling_List where ID='" + aa + "' ";
            //SqlCommand cmd = new SqlCommand(Dostr, conn);
            //SqlDataReader dr = cmd.ExecuteReader();
            this.BeginQuery("select count(*) from KNet_Sampling_List where ID='" + aa + "' and BuyState='0'");
            this.QueryForDataTable();
            DataTable Dtb_Re = Dtb_Result;
            this.BeginQuery("select count(*) from KNet_Sampling_List where ID='" + aa + "'");
            this.QueryForDataTable();
            DataTable Dtb_Re1 = Dtb_Result;
            //if (Dtb_Re.Rows.Count > 0)
            //{
            int cg = Convert.ToInt32(Dtb_Re.Rows[0][0].ToString());
            int cot = Convert.ToInt32(Dtb_Re1.Rows[0][0].ToString());
            if (cg > 0 && cg < cot)
            {

                return "<font color=red>部分采购</font>";
            }
            if (cg == cot)
            {

                return "<font color=blue>未采购</font>";
            }
            else
            {
                return "<font color=red>已采购</font>";
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
            //string Dostr = "select * from KNet_Sampling_List where ID='" + aa + "' ";
            //SqlCommand cmd = new SqlCommand(Dostr, conn);
            //SqlDataReader dr = cmd.ExecuteReader();
            this.BeginQuery("select count(*) from KNet_Sampling_List where ID='" + aa + "' and InState='0'");
            this.QueryForDataTable();
            DataTable Dtb_Re = Dtb_Result;
            this.BeginQuery("select count(*) from KNet_Sampling_List where ID='" + aa + "'");
            this.QueryForDataTable();
            DataTable Dtb_Re1 = Dtb_Result;
            //if (Dtb_Re.Rows.Count > 0)
            //{
            int Wrk = Convert.ToInt32(Dtb_Re.Rows[0][0].ToString());
            int cot = Convert.ToInt32(Dtb_Re1.Rows[0][0].ToString());
            if (Wrk > 0 && Wrk < cot)
            {

                return "<font color=red>部分入库</font>";
            }

            if (Wrk == cot)
            {

                return "<font color=blue>未入库</font>";
            }
            else
            {
                return "<font color=red>已入库</font>";
            }
            //}
            //else
            //{
            //    return "<font color=red>已入库</font>";
            //}
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
            else if (ws == cot)
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
    public string Base_GetSamplingName(String s_ID)
    {

        String s_Name = "";
        this.BeginQuery("select  SampleName from KNet_Sampling_List where ID='" + s_ID + "' order by STime desc");
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
    public string Base_GetSamplingNumber(String s_ID)
    {

        String s_Name = "";
        this.BeginQuery("select  Number from KNet_Sampling_List where ID='" + s_ID + "' order by STime desc");
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

    public string Base_GetSamplingPrice(string s_ID)
    {
        String s_Name = "";
        this.BeginQuery("select  Price from KNet_Sampling_List where ID='" + s_ID + "' order by STime desc");
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

    public string Base_GetProposer(String s_ID)
    {

        String s_Name = "";
        this.BeginQuery("select top 1 Proposer from KNet_Sampling_List where ID='" + s_ID + "'");
        this.QueryForDataTable();
        DataTable Dtb_Re1 = Dtb_Result;
        // String s_Name = "";
        this.BeginQuery("Select * From KNet_Resource_Staff Where StaffNo='" + Dtb_Re1.Rows[0][0].ToString() + "'");
        this.QueryForDataTable();
        DataTable Dtb_Re = Dtb_Result;
        if (Dtb_Re.Rows.Count > 0)
        {
            s_Name = Dtb_Re.Rows[0]["StaffName"].ToString();
        }
        return s_Name;

    }

    public string Base_GetSamplingTime(String s_ID)
    {
        String s_Name = "";
        this.BeginQuery("select TOP 1 STime from KNet_Sampling_List where ID='" + s_ID + "' order by STime desc");
        this.QueryForDataTable();
        DataTable Dtb_Re = Dtb_Result;
        if (Dtb_Re.Rows.Count > 0)
        {
            s_Name += Dtb_Re.Rows[0]["STime"].ToString();
            s_Name += "<br/>";
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

    protected void Ddl_GroupType_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        DataShows();
    }
}