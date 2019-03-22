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

public partial class Web_Complain_Knet_Product_Prototype_List : BasePage
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
            //string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            //string AuditState = Request.QueryString["AuditState"] == null ? "" : Request.QueryString["AuditState"].ToString();
            //if (s_ID != "" && AuditState != "")
            //{
            //    if (AM.YNAuthority("审核请购单"))
            //    {
            //        string DoSqlOrder = " update KNet_Sampling_List set  AuditState='" + AuditState + "' where ID='" + s_ID + "' ";
            //        DbHelperSQL.ExecuteSql(DoSqlOrder);
            //    }
            //    else
            //    {
            //        Response.Write(
            //       "<script language=javascript>alert('您没有审核请购单的权限!')</script>");
            //    }
            //}


            this.Btn_Del.Attributes.Add("onclick", "return confirm('你确信要删除所选记录吗?！\\n\\n注意：该删除会同时删除出库单产品明细记录.')");
            base.Base_DropBindSearch(this.bas_searchfield, "KNet_Product_Gauge");
            base.Base_DropBindSearch(this.Fields, "KNet_Product_Gauge");
            base.Base_DropWareHouseBind(this.Ddl_StaffNo, "  KSW_Type=0 and HouseNo!='131235104473261008' ");
            base.Base_DropBasicCodeBind(this.DropDownListType, "1146");
            //this.DropDownListType.SelectedValue = "0";
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

        KNet.BLL.KNet_Product_Gauge bll = new KNet.BLL.KNet_Product_Gauge();
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
            if (this.matchtype1.Checked == true) //and
            {
                s_Type = "0";
            }
            if (this.matchtype2.Checked == true)
            {
                s_Type = "1";
            }
            SqlWhere += base.Base_GetAdvWhere(s_Fields, s_Condition, s_Text, s_Type);
        }
        string s_SalesOrderNo = Request.QueryString["SalesOrderNo"] == null
            ? ""
            : Request.QueryString["SalesOrderNo"].ToString();

        if (s_SalesOrderNo != "")
        {
            SqlWhere += " and ID like '%" + s_SalesOrderNo + "%' ";
        }



        //SqlWhere += " order by SYstemDateTimes desc";
        //string SqlWhere = " 1=1  ";

        SqlWhere = SqlWhere + " order by KPG_Time desc ";
        DataSet ds = bll.GetList(SqlWhere);
        MyGridView1.DataSource = ds;
        MyGridView1.DataKeyNames = new string[] {"KPG_ID"};
        MyGridView1.DataBind();
    }

    protected void Btn_Del_Click(object sender, EventArgs e)
    {


        for (int i = 0; i < MyGridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox) MyGridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {

                KNet.BLL.KNet_Product_Gauge BLL = new KNet.BLL.KNet_Product_Gauge();
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

    public string Base_GetProductName(String s_ID)
    {

        String s_Name = "";
        this.BeginQuery("select ProductsName from KNet_Sys_Products where ProductsBarCode in(" + s_ID + ")");
        this.QueryForDataTable();
        DataTable Dtb_Re = Dtb_Result;
        try
        {
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
        catch 
        {

            return s_Name;
        }
        
    }
    /// <summary>
    /// 获取治具库存
    /// </summary>
    /// <returns></returns>
    public string Base_GetStoreCount(string suppno,string id)
    {
        int s_Count =0;
        this.BeginQuery("select ISNULL( sum(KPG_Number),0) from KNet_Product_Gauge where KPG_SuppNo='" + suppno + "' and KPG_KID='"+ id + "'");
        this.QueryForDataTable();
        DataTable Dtb_Re1 = Dtb_Result;//本地库存
        this.BeginQuery("select ISNULL( sum(KPI_Number),0) from KNet_Product_Gauge_InOut where KPI_UseFrom='" + suppno + "' and KPI_InOut=0 and KPI_Code='"+ id + "'and KPI_State=1");
        this.QueryForDataTable();
        DataTable Dtb_Re2 = Dtb_Result;//借出
        this.BeginQuery("select ISNULL( sum(KPI_Number),0) from KNet_Product_Gauge_InOut where KPI_UserIn='" + suppno + "' and KPI_InOut=0 and KPI_Code='" + id + "' and KPI_State=1");
        this.QueryForDataTable();
        DataTable Dtb_Re3 = Dtb_Result;//借出
        this.BeginQuery("select ISNULL( sum(KPI_Number),0) from KNet_Product_Gauge_InOut where KPI_UserIn='" + suppno + "' and KPI_InOut=1 and KPI_Code='"+ id + "'and KPI_State=1");
        this.QueryForDataTable();
        DataTable Dtb_Re4 = Dtb_Result;//归还
        this.BeginQuery("select ISNULL( sum(KPI_Number),0) from KNet_Product_Gauge_InOut where KPI_UseFrom='" + suppno + "' and KPI_InOut=1 and KPI_Code='" + id + "' and KPI_State=1");
        this.QueryForDataTable();
        DataTable Dtb_Re5 = Dtb_Result;//归还
        this.BeginQuery("select ISNULL( sum(KPI_BadNumber),0) from KNet_Product_Gauge_InOut where KPI_UseFrom='" + suppno + "' and KPI_InOut=1 and KPI_Code='" + id + "' and KPI_State=1");
        this.QueryForDataTable();
        DataTable Dtb_Re7 = Dtb_Result;//归还
        s_Count = int.Parse(Dtb_Re1.Rows[0][0].ToString()) - int.Parse(Dtb_Re2.Rows[0][0].ToString()) +
                  int.Parse(Dtb_Re3.Rows[0][0].ToString())+ int.Parse(Dtb_Re4.Rows[0][0].ToString())- int.Parse(Dtb_Re5.Rows[0][0].ToString())- int.Parse(Dtb_Re7.Rows[0][0].ToString());
        return s_Count.ToString();
    }
    public string Base_GetSuppNoName(string s_ID)
    {
        String s_Name = "";
        this.BeginQuery("select HouseName from KNet_Sys_WareHouse where HouseNo='" + s_ID + "'");
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

    public string Base_GetType(string s_ID)
    {
        string s_Name = "";
        if (s_ID=="0")
        {
            s_Name = "品质治具";
        }
        if (s_ID=="1")
        {
            s_Name = "生产钢网";
        }
        if (s_ID == "2")
        {
            s_Name = "生产治具";
        }
        return s_Name;
    }

    public string Base_GetPersonName(String s_ID)
    {
        String s_Name = "";
        this.BeginQuery("Select * From KNet_Resource_Staff Where StaffNo='" + s_ID + "'");
        this.QueryForDataTable();
        DataTable Dtb_Re = Dtb_Result;
        if (Dtb_Re.Rows.Count > 0)
        {
            s_Name = Dtb_Re.Rows[0]["StaffName"].ToString();
        }
        return s_Name;
    }

    protected void Ddl_StaffNo_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownListType.SelectedValue!="")
        {
            DataShows1();
        }
        
    }

    public void DataShows1()
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.BLL.KNet_Product_Gauge bll = new KNet.BLL.KNet_Product_Gauge();
        string SqlWhere = "  1=1  ";
        if (this.Ddl_StaffNo.SelectedValue != "")
        {
            SqlWhere += " and  KPG_SuppNo='" + this.Ddl_StaffNo.SelectedValue + "' and KPG_Type=" + int.Parse(DropDownListType.SelectedValue) + " ";//a.KPI_UserIn='" + this.Ddl_StaffNo.SelectedValue + "' and a.KPI_Type="+  int.Parse(DropDownListType.SelectedValue) + " and b.KPG_Type="+ int.Parse(DropDownListType.SelectedValue) + "
        }
        SqlWhere = SqlWhere + " order by KPG_Time desc ";
        DataSet ds = bll.GetList(SqlWhere);
        MyGridView1.DataSource = ds;
        MyGridView1.DataKeyNames = new string[] { "KPG_ID" };
        MyGridView1.DataBind();
    }
}