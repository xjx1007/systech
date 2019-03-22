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

public partial class Web_Complain_Knet_Product_Prototype : BasePage
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
                if (AM.YNAuthority("审核治具申请"))
                {
                    string DoSqlOrder = " update KNet_Product_Gauge_InOut set  KPI_State='" + AuditState + "' where KPI_SID='" + s_ID + "' ";
                    DbHelperSQL.ExecuteSql(DoSqlOrder);
                }
                else
                {
                    Response.Write(
                   "<script language=javascript>alert('您没有审核治具的权限!')</script>");
                }
            }


            this.Btn_Del.Attributes.Add("onclick", "return confirm('你确信要删除所选记录吗?！\\n\\n注意：该删除会同时删除出库单产品明细记录.')");
            base.Base_DropBindSearch(this.bas_searchfield, "KNet_Product_Gauge_InOut");
            base.Base_DropBindSearch(this.Fields, "KNet_Product_Gauge_InOut");
            Base_StaffNo(this.Ddl_StaffNo);
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

        KNet.BLL.KNet_Product_Gauge_InOut bll = new KNet.BLL.KNet_Product_Gauge_InOut();
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
            SqlWhere += " and KPI_Person='" + this.Ddl_StaffNo.SelectedValue + "' ";
        }
        SqlWhere = SqlWhere + " order by KPI_SID desc ";
        DataSet ds = bll.GetList1(SqlWhere);
        MyGridView1.DataSource = ds;
        MyGridView1.DataKeyNames = new string[] { "KPI_SID" };
        MyGridView1.DataBind();
    }

    protected void Btn_Del_Click(object sender, EventArgs e)
    {


        for (int i = 0; i < MyGridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)MyGridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {

                KNet.BLL.KNet_Product_Gauge_InOut BLL = new KNet.BLL.KNet_Product_Gauge_InOut();
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
            KNet.BLL.KNet_Product_Gauge_InOut Bll = new KNet.BLL.KNet_Product_Gauge_InOut();

            string DirectInNo = MyGridView1.DataKeys[e.Row.RowIndex].Value.ToString(); //获取ID值
            CheckBox cb = (CheckBox)e.Row.Cells[1].FindControl("Chbk");
            this.BeginQuery("select count(*) from KNet_Product_Gauge_InOut where KPI_SID='" + DirectInNo + "' and KPI_State!=0");
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






    protected string GetAuditState(object aa)
    {


        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {

            conn.Open();
            //string Dostr = "select * from KNet_Sampling_List where ID='" + aa + "' and AuditState='0' ";
            //SqlCommand cmd = new SqlCommand(Dostr, conn);
            //SqlDataReader dr = cmd.ExecuteReader();
            this.BeginQuery("select count(*) from KNet_Product_Gauge_InOut where KPI_SID='" + aa + "' and KPI_State=0");
            this.QueryForDataTable();
            DataTable Dtb_Re = Dtb_Result;
          
            int ws = Convert.ToInt32(Dtb_Re.Rows[0][0].ToString());
           
            if (ws > 0 )
            {
                string JSD = "Knet_Product_Prototype.aspx?ID=" + aa + "&AuditState=1";
                return "<a href=\"" + JSD + "\" onclick=\"\"  ><font color=blue>未审核</font></a>";
            }
           
            else
            {
                string JSD = "Knet_Product_Prototype.aspx?ID=" + aa + "&AuditState=0";
                return "<a href=\"" + JSD + "\" onclick=\"\"  ><font color=red>已审核</font></a>";
            }

        }


    }
    /// <summary>
    /// 是借出还是退还
    /// </summary>
    /// <param name="s_ID"></param>
    /// <returns></returns>
    public string Base_GetKPIInOut(String s_ID)
    {

        String s_Name = "";
        this.BeginQuery("select top 1 KPI_InOut from KNet_Product_Gauge_InOut where KPI_SID='" + s_ID + "'");
        this.QueryForDataTable();
        //this.BeginQuery("select * from PB_Basic_ProductsClass where PBP_ID='" + s_ID + "'");
        //this.QueryForDataTable();
        DataTable Dtb_Re = Dtb_Result;
        if (Dtb_Re.Rows.Count > 0)
        {
            s_Name = base.Base_GetBasicCodeName("1144", Dtb_Re.Rows[0][0].ToString());

        }
        return s_Name;
    }
    /// <summary>
    /// 获取治具名称
    /// </summary>
    /// <param name="s_ID"></param>
    /// <returns></returns>
    public string Base_GetName(String s_ID)
    {

        String s_Name = "";
        this.BeginQuery("select KPG_Name from KNet_Product_Gauge where KPG_KID in (select  KPI_Code from KNet_Product_Gauge_InOut where KPI_SID='" + s_ID + "')");
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
    /// 获取治具数量
    /// </summary>
    /// <param name="s_ID"></param>
    /// <returns></returns>
    public string Base_GetNumber(String s_ID)
    {

        String s_Name = "";
        this.BeginQuery("select  KPI_Number from KNet_Product_Gauge_InOut where KPI_SID='" + s_ID + "' ");
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
    /// 出处地
    /// </summary>
    /// <param name="s_ID"></param>
    /// <returns></returns>
    public string Base_GetForSuppName(string s_ID)
    {
        String s_Name = "";
        this.BeginQuery("select HouseName from KNet_Sys_WareHouse where HouseNo in (select top 1 KPI_UseFrom from KNet_Product_Gauge_InOut where KPI_SID='" + s_ID + "') ");
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
    /// 借入地
    /// </summary>
    /// <param name="s_ID"></param>
    /// <returns></returns>
    public string Base_GetInSuppName(string s_ID)
    {
        String s_Name = "";
        this.BeginQuery("select HouseName from KNet_Sys_WareHouse where HouseNo in (select top 1 KPI_UserIn from KNet_Product_Gauge_InOut where KPI_SID='" + s_ID + "') ");
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
    /// 申请人
    /// </summary>
    /// <param name="s_ID"></param>
    /// <returns></returns>
    public string Base_GetProposer(String s_ID)
    {

        String s_Name = "";
        this.BeginQuery("select top 1 KPI_Person from KNet_Product_Gauge_InOut where KPI_SID='" + s_ID + "'");
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
    /// <summary>
    /// 申请时间
    /// </summary>
    /// <param name="s_ID"></param>
    /// <returns></returns>
    public string Base_GetSamplingTime(String s_ID)
    {
        String s_Name = "";
        this.BeginQuery("select TOP 1 KPI_Time from KNet_Product_Gauge_InOut where KPI_SID='" + s_ID + "' order by KPI_Time desc");
        this.QueryForDataTable();
        DataTable Dtb_Re = Dtb_Result;
        if (Dtb_Re.Rows.Count > 0)
        {
            s_Name= Dtb_Re.Rows[0]["KPI_Time"].ToString();
            //s_Name += "<br/>";
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