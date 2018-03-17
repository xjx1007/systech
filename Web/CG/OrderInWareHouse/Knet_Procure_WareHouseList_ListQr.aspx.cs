using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;

using KNet.DBUtility;
using KNet.Common;
using System.Data.SqlClient;

public partial class Knet_Procure_WareHouseList_ListQr : BasePage
{
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("采购入库列表") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
            else
            {
                string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
                string s_Model = Request.QueryString["Model"] == null ? "" : Request.QueryString["Model"].ToString();
                base.Base_DropWareHouseBind(this.Ddl_House, " KSW_Type='0' ");
                if ((s_ID != "") && (s_Model == "IsQr"))
                {
                    KNet.BLL.Knet_Procure_WareHouseList Bll = new KNet.BLL.Knet_Procure_WareHouseList();
                    KNet.Model.Knet_Procure_WareHouseList Model = Bll.GetModelB(s_ID);
                    Model.OrderNo = s_ID;
                    int i_QrState = Math.Abs(Model.KPO_QRState - 1);
                    Model.KPO_QRState = i_QrState;
                    if (i_QrState == 1)
                    {
                        Model.WareHouseDateTime = DateTime.Now;
                    }
                    else
                    {
                        Model.WareHouseDateTime =null;
                    }
                    Model.KPW_CheckPerson = AM.KNet_StaffNo;
                    Bll.UpdateQRState(Model);
                }
                DataShows();
                //采购入库删除
                if (AM.YNAuthority("删除采购入库") == false)
                {
                    this.Btn_Del.Enabled = false;
                }
                this.Btn_Del.Attributes.Add("onclick", "return confirm('你确信要删除所选记录吗?！')");
                //base.Base_DropBatchBind(this.Ddl_Batch, "Knet_Procure_WareHouseList", "XSQ_DutyPerson");
                base.Base_DropBindSearch(this.bas_searchfield, "Knet_Procure_WareHouseList");
                base.Base_DropBindSearch(this.Fields, "Knet_Procure_WareHouseList");
            }
        }

    }

    protected void GridView1_DataRowBinding(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
        }
    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        string s_Sql = "Select  a.HouseNo,Count(*) CountNumber,Sum(wareHouseAmount) as number from";
        s_Sql += " Knet_Procure_WareHouseList a ";
        s_Sql += "  join Knet_Procure_WareHouseList_Details b on a.WareHouseNo=b.WareHouseNo";
        s_Sql += " left join Knet_Procure_OrdersList c on a.OrderNo=c.OrderNo where ";
        string s_SqlWhere = " a.KPW_Del='0' and a.KPO_QRState=0 ";

        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string s_Type = "";
        if (s_WhereID != "")
        {
            s_SqlWhere += Base_GetBasicWhere(s_WhereID);
        }
        if ((this.bas_searchfield.SelectedValue != "") && (search_text.Text != ""))
        {
            s_SqlWhere += base.Base_GetBasicColumnWhere(this.bas_searchfield.SelectedValue, this.search_text.Text);
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
            s_SqlWhere += base.Base_GetAdvWhere(s_Fields, s_Condition, s_Text, s_Type);
        }
        if (this.Ddl_House.SelectedValue != "")
        {
            s_SqlWhere += " and a.HouseNo='" + this.Ddl_House.SelectedValue + "'";
        }
        s_SqlWhere += " Group by a.HouseNo ";
        this.BeginQuery(s_Sql + s_SqlWhere);
        DataSet ds = (DataSet)this.QueryForDataSet();
        this.MyGridView1.DataSource = ds;
        MyGridView1.DataKeyNames = new string[] { "HouseNo" };
        MyGridView1.DataBind();
    }

    protected string CheckView( string s_HouseNo)
    {
        string s_Return = "", JSD = "";
        /*
    KNet.BLL.Knet_Procure_OrdersList BLl = new KNet.BLL.Knet_Procure_OrdersList();
    KNet.Model.Knet_Procure_OrdersList Model = BLl.GetModel(s_OrderNo);

    if (Model.KPO_Del == 1)
    {
        return "<font color=red>订单关闭</font>";
    }
    if (Model.OrderCheckYN == false)
    {
        s_Return = "";
    }
    else
    {
        //if (base.base_GetProcureTypeNane(s_OrderType) == "芯片")
        //{
        //    JSD = "OrderList_View.aspx?OrderNo=" + s_OrderNo + "";
        //    s_Return = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=780,height=500');\"  title=\"点击进行审核操作\"><img src=\"../../../images/View.gif\"  border=\"0\" /></a>";

        //}
        //else
        //{ }
        string s_Sql = "Select Sum(KSP_isModiy) from KNet_Sys_Products a join Knet_Procure_OrdersList_Details b on a.ProductsBarCode=b.ProductsBarCode";
        s_Sql += " where b.OrderNo='" + Model.OrderNo + "' ";
        this.BeginQuery(s_Sql);
        string s_IsModiy = this.QueryForReturn();
        if (int.Parse(s_IsModiy) > 0)
        {
            s_Return += "<font color=red>产品需确认</font>";
        }
        else
        {
            JSD = "Knet_Procure_OpenBilling_Print.aspx?ID=" + s_OrderNo + "";
            s_Return = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=120,left=150,toolbar=yes, menubar=yes,scrollbars=yes, resizable=yes, location=yes, status=yes, width=780,height=500');\"  title=\"点击查看\"><img src=\"../../images/View.gif\"  border=\"0\" /></a>";
            s_Return += "  <a href=\"PDF/" + Model.OrderNo + ".PDF\" class=\"webMnu\" target=\"_blank\"><img src=\"../../images/pdf.gif\"  border=\"0\" /></a> ";

        }
    }*/
        try
        {
            s_Return += "  <a href=\"../../Mail/PB_Basic_Mail_Add.aspx?HouseNo=" + s_HouseNo + "\" class=\"webMnu\" target=\"_blank\"><img src=\"../../images/email.gif\"  border=\"0\" /></a> ";
        }
        catch
        { }
        return s_Return;

    }

    protected string GetPrint(string s_HouseNo)
    {
        string s_Return = "";
        KNet.BLL.PB_Basic_Mail bll_Mail = new KNet.BLL.PB_Basic_Mail();
        string s_Sql = "PBM_Del=0 and PBM_FID='" + s_HouseNo + "' and CONVERT(varchar(12) , PBM_CTime, 112 )= CONVERT(varchar(12) , getdate(), 112 ) and PBM_Type=5 ";
        s_Sql += " Order by PBM_CTime desc";
        DataSet ds_Mail = bll_Mail.GetList(s_Sql);
        if (ds_Mail.Tables[0].Rows.Count > 0)
        {
            s_Return = "<font color=green>今日已发送</font>";
        }
        else
        {
            s_Return = "<font color=red>今日未发送</font>";
 
        }
            /*
        if (i_IsSend == 0)
        {
            string JSD = "Knet_Procure_OpenBilling_Manage.aspx?ID=" + s_OrderNo + "&Model=IsSend";
            s_Return = "<a href=\"" + JSD + "\" onclick=\"\"  ><font color=red>未发送</font></a>";
        }
        else if (i_IsSend == 1)
        {
            string JSD = "Knet_Procure_OpenBilling_Manage.aspx?ID=" + s_OrderNo + "&Model=IsSend";
            s_Return = "<a href=\"" + JSD + "\" onclick=\"\" >已发送</a>";
        }
        else if (i_IsSend == 2)
        {
            string JSD = "Knet_Procure_OpenBilling_Manage.aspx?ID=" + s_OrderNo + "&Model=IsSend";
            s_Return = "<a href=\"" + JSD + "\" onclick=\"\" ><font color=green>已确认</font></a>";
        }*/
        return s_Return;

    }
    protected void Btn_Query_Click(object sender, EventArgs e)
    {
        this.DataShows();
    }
    protected string GetPrint1(string s_ID)
    {
        KNet.BLL.Knet_Procure_WareHouseList Bll = new KNet.BLL.Knet_Procure_WareHouseList();
        KNet.Model.Knet_Procure_WareHouseList Model = Bll.GetModel(s_ID);
        string s_Return = "";
        if (Model.KPO_QRState == 1)
        {

            s_Return = "<a href=\"#\"  onclick=\"GPrint('" + s_ID + "')\"><Image ID=\"Image4\" src=\"../../../images/Print1.gif\" border=0   /></a>(" + Model.KPW_PrintNums + ")";
        }
        return s_Return;
    }

    protected void Btn_Del_Click(object sender, EventArgs e)
    {
        StringBuilder s_Sql = new StringBuilder();
        StringBuilder s_Log = new StringBuilder();
        try
        {
            for (int i = 0; i < MyGridView1.Rows.Count; i++)
            {
                CheckBox Ckb = (CheckBox)MyGridView1.Rows[i].Cells[0].FindControl("Chbk");
                if (Ckb.Checked)
                {
                    string s_ID = MyGridView1.DataKeys[i].Value.ToString();
                    s_Sql.Append(" delete from Knet_Procure_WareHouseList_Details Where  WareHouseNo='" + s_ID + "' ");
                    s_Sql.Append(" delete from Knet_Procure_WareHouseList Where  WareHouseNo='" + s_ID + "' ");
                    s_Log.Append(s_ID);
                }
            }
            if (DbHelperSQL.ExecuteSql(s_Sql.ToString()) > 0)
            {
                this.DataShows();
                AdminloginMess AM = new AdminloginMess();
                AM.Add_Logs("Knet_Procure_WareHouseList 删除 编号：" + s_Log + "");
                Alert("删除成功！");
            }
        }
        catch (Exception ex)
        {
            Alert("删除失败！");
            return;
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
    /// <summary>
    /// 库存类型
    /// </summary>
    /// <param name="s_Order"></param>
    /// <returns></returns>
    public string Base_GetOrderInProductsPattern(string s_StoreNo)
    {
        string s_Return = "";
        this.BeginQuery("Select * from Knet_Procure_WareHouseList_Details Where WareHouseNo='" + s_StoreNo + "' order by ProductsBarCode ");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                s_Return += Base_GetProductsEdition_Link(Dtb_Result.Rows[i]["ProductsBarCode"].ToString()) + "<br>";
            }
            s_Return = s_Return.Substring(0, s_Return.Length - 4);
        }
        return s_Return;
    }

    /// <summary>
    /// 库存数量
    /// </summary>
    /// <param name="s_Order"></param>
    /// <returns></returns>
    public string Base_GetOrderInProductsNUmbers(string s_StoreNo)
    {
        string s_Return = "";
        this.BeginQuery("Select WareHouseAmount as WareHouseAmount from Knet_Procure_WareHouseList_Details Where WareHouseNo='" + s_StoreNo + "' order by ProductsBarCode ");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                s_Return += Dtb_Result.Rows[i]["WareHouseAmount"].ToString() + "<br>";
            }
            s_Return = s_Return.Substring(0, s_Return.Length - 4);
        }
        return s_Return;
    }
    /// <summary>
    /// 返回审核情况
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetOrderCheckYN(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,WareHouseNo,WareHouseCheckYN from Knet_Procure_WareHouseList where WareHouseNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                if (dr["WareHouseCheckYN"].ToString() == "1")
                {
                    return "<a href=\"Procure_MaterialIn_List.aspx?ID=" + aa + "\"><font color=Green>部门已审</font></a>";
                }
                else if (dr["WareHouseCheckYN"].ToString() == "2")
                {
                    return "<a href=\"Procure_MaterialIn_List.aspx?ID=" + aa + "\"><font color=red>财务已审</font></a>";
                }
                else
                {
                    return "<font color=blue>未审核</font>";
                }
            }
            else
            {
                return "--";
            }
        }
    }
    protected void Ddl_House_TextChanged(object sender, EventArgs e)
    {
        this.DataShows();
    }
    protected void Btn_SpSave(object sender, EventArgs e)
    {

        StringBuilder s_Sql = new StringBuilder();
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
                    s_Log.Append(s_ID + ",");
                    s_Sql.Append(" Update  Knet_Procure_WareHouseList Set WareHouseCheckYN='1',WareHouseCheckStaffNo='" + AM.KNet_StaffNo + "',KPO_CheckTime='" + DateTime.Now + "' where WareHouseNo='" + s_ID + "' ");
                }
            }
            if (DbHelperSQL.ExecuteSql(s_Sql.ToString()) > 0)
            {
                this.DataShows();
                AM.Add_Logs("Knet_Procure_WareHouseList 审批 编号：" + s_Log + "");
                Alert("批量审批成功！");
            }
        }
        catch (Exception ex)
        {
            Alert("批量审批失败！");
            return;
        }
    }
    public string GetCheckState(string WareHouseNo)
    {
        string s_Return = "";
        try{
          //已对账
            KNet.BLL.Cg_Order_Checklist_Details Cg_Details = new KNet.BLL.Cg_Order_Checklist_Details();
            DataSet dts_Cg = Cg_Details.GetList(" COD_DirectOutID in (select ID from Knet_Procure_WareHouseList_Details where WareHouseNo='" + WareHouseNo + "') ");
            if (dts_Cg.Tables[0].Rows.Count > 0)
            {
                s_Return = "<font color=green>已对账</font>";
            }
            else
            {
                s_Return = "<font color=green>未对账</font>";
            }
        }
        catch
        {}
        return s_Return;
    }
    protected void Btn_QrSave(object sender, EventArgs e)
    {

        StringBuilder s_Sql = new StringBuilder();
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
                    s_Log.Append(s_ID + ",");
                    s_Sql.Append(" Update  Knet_Procure_WareHouseList Set KPO_QrState='1',WareHouseDateTime='" + DateTime.Now + "',KPW_CheckPerson='"+AM.KNet_StaffNo+"' where WareHouseNo='" + s_ID + "' ");
                }
            }
            if (DbHelperSQL.ExecuteSql(s_Sql.ToString()) > 0)
            {
                this.DataShows();
                AM.Add_Logs("Knet_Procure_WareHouseList 审批 编号：" + s_Log + "");
                Alert("批量确认成功！");
            }
        }
        catch (Exception ex)
        {
            Alert("批量确认失败！");
            return;
        }
    }
}
