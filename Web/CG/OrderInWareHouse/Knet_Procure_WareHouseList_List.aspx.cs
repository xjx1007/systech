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

public partial class Web_Sales_Knet_Procure_WareHouseList_List : BasePage
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
                    //if (i_QrState == 1)
                    //{
                    //    Model.WareHouseDateTime = DateTime.Now;
                    //}
                    //else
                    //{
                    //    Model.WareHouseDateTime = null;
                    //}
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
            string WareHouseNo = this.MyGridView1.DataKeys[e.Row.RowIndex].Value.ToString(); //获取ID值
            CheckBox cb = (CheckBox) e.Row.Cells[1].FindControl("Chbk");

            //已对账
            KNet.BLL.Cg_Order_Checklist_Details Cg_Details = new KNet.BLL.Cg_Order_Checklist_Details();
            DataSet dts_Cg =
                Cg_Details.GetList(
                    " COD_DirectOutID in (select ID from Knet_Procure_WareHouseList_Details where WareHouseNo='" +
                    WareHouseNo + "') ");
            if (dts_Cg.Tables[0].Rows.Count > 0)
            {
                cb.Enabled = false;
            }
            else
            {
                cb.Enabled = true;
            }
            KNet.BLL.Knet_Procure_WareHouseList bll = new KNet.BLL.Knet_Procure_WareHouseList();
            KNet.Model.Knet_Procure_WareHouseList Model = bll.GetModelB(WareHouseNo);
            if ((Model.KPO_QRState == 1) || (Model.WareHouseCheckYN == 2))
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
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        string s_SqlWhere = " KPW_Del='0' ";

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
            if (this.matchtype1.Checked == true) //and
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
            s_SqlWhere += " and HouseNo='" + this.Ddl_House.SelectedValue + "'";
        }
        s_SqlWhere += " Order by Knet_Procure_WareHouseList.SystemDateTimes desc ";
        KNet.BLL.Knet_Procure_WareHouseList bll = new KNet.BLL.Knet_Procure_WareHouseList();
        DataSet ds = bll.GetList(s_SqlWhere);
        this.MyGridView1.DataSource = ds;
        MyGridView1.DataKeyNames = new string[] {"WareHouseNo"};
        MyGridView1.DataBind();
    }

    protected void Btn_Query_Click(object sender, EventArgs e)
    {
        this.DataShows();
    }

    protected string GetPrint(string s_OrderNo, string OrderNo)
    {
        KNet.BLL.Knet_Procure_WareHouseList Bll = new KNet.BLL.Knet_Procure_WareHouseList();
        KNet.Model.Knet_Procure_WareHouseList Model = Bll.GetModelB(s_OrderNo);
        string s_Return = "";
        int i_IsSend = Model.KPO_QRState;
        int i_WareHouseCheck = Model.WareHouseCheckYN;
        string str = OrderNo.Substring(0, 2);
        if (str != "YP") //判断是不是样品申请的采购单号
        {
            if (i_IsSend == 0)
            {
                string JSD = "Knet_Procure_WareHouseList_List.aspx?ID=" + s_OrderNo + "&Model=IsQr";
                s_Return = "<a href=\"" + JSD + "\" onclick=\"\"  ><font color=red>未确认</font></a>";
            }
            else
            {
                if (i_WareHouseCheck == 2)
                {
                    s_Return = "已确认";
                }
                else
                {

                    string JSD = "Knet_Procure_WareHouseList_List.aspx?ID=" + s_OrderNo + "&Model=IsQr";
                    s_Return = "<a href=\"" + JSD + "\" onclick=\"\" >已确认</a>";
                }
            }
        }
        else
        {
            if (i_IsSend == 0)
            {
                //string JSD = "Knet_Procure_WareHouseList_List.aspx?ID=" + s_OrderNo + "&Model=IsQr";
                s_Return = "<a ><font color=red>未确认</font></a>";
            }
            else
            {
                if (i_WareHouseCheck == 2)
                {
                    s_Return = "已确认";
                }
                else
                {

                    //string JSD = "Knet_Procure_WareHouseList_List.aspx?ID=" + s_OrderNo + "&Model=IsQr";
                    s_Return = "<a >已确认</a>";
                }
            }
        }
        return s_Return;
    }

    protected string GetPrint1(string s_ID)
    {
        KNet.BLL.Knet_Procure_WareHouseList Bll = new KNet.BLL.Knet_Procure_WareHouseList();
        KNet.Model.Knet_Procure_WareHouseList Model = Bll.GetModel(s_ID);
        string s_Return = "";
        this.BeginQuery("select KPO_Sampling from Knet_Procure_OrdersList where OrderNo='" + Model.ReceivNo + "' ");
        this.QueryForDataTable();
        try
        {
            if (Dtb_Result.Rows[0][0].ToString() == "1")//&& Model.KPO_QRState == 1
            {
                s_Return = "<a href=\"#\"  onclick=\"GPrint2('" + s_ID + "','" + Dtb_Result.Rows[0][0].ToString() + "')\"><Image ID=\"Image4\" src=\"../../../images/Print1.gif\" border=0   /></a>(" + Model.KPW_PrintNums + ")";
            }
            else //if (Model.KPO_QRState == 1)
            {

                s_Return = "<a href=\"#\"  onclick=\"GPrint('" + s_ID + "')\"><Image ID=\"Image4\" src=\"../../../images/Print1.gif\" border=0   /></a>(" + Model.KPW_PrintNums + ")";
            }
        }
        catch
        {
            return s_Return;

        }
       
        return s_Return;
    }

    protected void Btn_Del_Click(object sender, EventArgs e)
    {
        StringBuilder s_Sql = new StringBuilder();
        StringBuilder s_Log = new StringBuilder();
        try
        {
            string s_WareHouseNoLeft = "";
            for (int i = 0; i < MyGridView1.Rows.Count; i++)
            {
                CheckBox Ckb = (CheckBox)MyGridView1.Rows[i].Cells[0].FindControl("Chbk");
                if (Ckb.Checked)
                {
                    string s_ID = MyGridView1.DataKeys[i].Value.ToString();
                    if ((GetCheckState(s_ID) == "<font color=green>未对账</font>") && (GetOrderCheckYN(s_ID) == "<font color=blue>未审核</font>"))
                    {
                        s_Sql.Append(" delete from Knet_Procure_WareHouseList_Details Where  WareHouseNo='" + s_ID + "' ");
                        s_Sql.Append(" delete from Knet_Procure_WareHouseList Where  WareHouseNo='" + s_ID + "' ");
                        s_Log.Append(s_ID);
                    }
                    else
                    {
                        s_WareHouseNoLeft += s_ID + ",";
                    }
                }
            }
            if (DbHelperSQL.ExecuteSql(s_Sql.ToString()) > 0)
            {
                this.DataShows();
                AdminloginMess AM = new AdminloginMess();
                AM.Add_Logs("Knet_Procure_WareHouseList 删除 编号：" + s_Log + ""); 
                if (s_WareHouseNoLeft != "")
                {
                    Alert("删除成功！" + s_WareHouseNoLeft + "已对账或者已审批不能删除！");
                }
                else
                {
                    Alert("删除成功！");
                }

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
