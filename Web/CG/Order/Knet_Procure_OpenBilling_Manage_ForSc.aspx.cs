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
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Data.SqlClient;

using KNet.DBUtility;
using KNet.Common;


/// <summary>
/// 采购管理-----采购单 管理
/// </summary>
public partial class Knet_Procure_OpenBilling_Manage_ForSc : BasePage
{
    public string s_DivStyle = "";
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            this.Lbl_Title.Text = "生产订单";
            if (AM.CheckLogin("采购单列表") == false)
            {
                BasePage.AlertAndRedirect("您未登陆系统或已超过，请重新登陆系统!", "Default.aspx");
            }
            else
            {
                string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
                string s_Model = Request.QueryString["Model"] == null ? "" : Request.QueryString["Model"].ToString();

                Base_DropSupp(this.Ddl_Supp);
                if ((s_ID != "") && (s_Model == "IsSend"))
                {
                    KNet.BLL.Knet_Procure_OrdersList Bll = new KNet.BLL.Knet_Procure_OrdersList();
                    KNet.Model.Knet_Procure_OrdersList Model = Bll.GetModelB(s_ID);
                    Model.OrderNo = s_ID;

                    int i_IsSend = 0;
                    if (Model.KPO_IsSend == 0)
                    {
                        i_IsSend = 1;
                    }

                    else if (Model.KPO_IsSend == 1)
                    {
                        i_IsSend = 2;
                    }
                    if (Model.KPO_IsSend == 2)
                    {
                        i_IsSend = 0;
                    }
                    Model.KPO_IsSend = i_IsSend;
                    Bll.UpdateIsSend(Model);
                }

                //if ((s_ID != "") && (s_Model == "IsCrk"))
                //{
                //    KNet.BLL.Knet_Procure_OrdersList Bll = new KNet.BLL.Knet_Procure_OrdersList();
                //    KNet.Model.Knet_Procure_OrdersList Model = Bll.GetModelB(s_ID);
                //    Model.OrderNo = s_ID;
                //    int i_IsSend = Math.Abs(int.Parse(Model.KPO_RkState) - 1);
                //    Model.KPO_RkState = i_IsSend.ToString();
                //    Bll.UpdateRKState(Model);
                //}


                //客户删除
                if (AM.YNAuthority("删除采购单") == false)
                {
                    this.Btn_Del.Enabled = false;
                }

                this.Btn_Del.Attributes.Add("onclick", "return confirm('你确信要删除所选记录吗?！\\n\\n注意：该删除会同时删除采购单产品明细记录.')");

                base.Base_DropBindSearch(this.bas_searchfield, "Knet_Procure_OrdersList");
                base.Base_DropBindSearch(this.Fields, "Knet_Procure_OrdersList");
                this.DataShows();
            }
        }

    }
    public string ScOrder(string s_OrderNo, string s_Details)
    {
        string s_Return = "";
        try
        {
            KNet.BLL.Knet_Procure_OrdersList bll = new KNet.BLL.Knet_Procure_OrdersList();
            KNet.Model.Knet_Procure_OrdersList model = bll.GetModelB(s_OrderNo);
            if ((s_Details == "加工厂") && (model.OrderCheckYN == false))
            {
                s_Return = "<a href=\"Knet_Procure_OpenBilling_Sc.aspx?ID=" + s_OrderNo + "\" target=\"_blank\"><font color=red>" + s_Details + "</font></a>";
            }
            else
            {
                s_Return = s_Details;
            }
        }
        catch
        { }
        return s_Return;
    }

    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.Knet_Procure_OrdersList bll = new KNet.BLL.Knet_Procure_OrdersList();

        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string s_ProductsBarCode = Request["ProductsBarCode"] == null ? "" : Request["ProductsBarCode"].ToString();
        string s_Type = "";

        string SqlWhere = " 1=1 and orderType='128860698200781250' ";
        AdminloginMess AM = new AdminloginMess();

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
            SqlWhere += " and ContractNos like '%" + s_SalesOrderNo + "%' ";
        }

        if (this.Ddl_Supp.SelectedValue != "")
        {
            SqlWhere += " and SuppNo='" + this.Ddl_Supp.SelectedValue + "' ";
        }
        if (s_ProductsBarCode != "")
        {

            SqlWhere += " and OrderNo in (Select OrderNO from Knet_Procure_OrdersList_Details where ProductsBarCode like '%" + s_ProductsBarCode + "%') ";
        }
        SqlWhere += " order by SYstemDateTimes desc";
        DataSet ds = bll.GetList(SqlWhere);

        GridView1.DataSource = ds.Tables[0];
        GridView1.DataKeyNames = new string[] { "OrderNo" };
        GridView1.DataBind();

        ////查看采购单  执行完成  状态 
        //for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
        //{
        //    DataRowView mydrv = ds.Tables[0].DefaultView[i];
        //    if (UpdateOrderState(mydrv["OrderNo"].ToString()) == true)
        //    {
        //        //更新采购单为 “已完成”
        //        string DoSqlOrder = " update Knet_Procure_OrdersList set OrderState=5 where OrderNo='" + mydrv["OrderNo"].ToString() + "'";
        //        DbHelperSQL.ExecuteSql(DoSqlOrder);
        //    }
        //}

    }

    protected string GetOutWareListfollowup(object OutWareNo, string s_Title, string s_Type)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            StringBuilder Sb_Return = new StringBuilder();
            StringBuilder Sb_Str = new StringBuilder();
            if (s_Type == "成品采购")
            {
                Sb_Str.Append("发货日期：");
                string s_Sql = "select top 1 SPD_EndTime from Sc_Produce_Plan_Details a ";
                s_Sql += "join Knet_Procure_OrdersList_Details b on a.SPD_OrderNo=b.ID  ";
                s_Sql += "where b.OrderNo='" + OutWareNo + "' ";
                s_Sql += "order by SPD_FaterID desc";
                try
                {
                    this.BeginQuery(s_Sql);
                    Sb_Str.Append(base.DateToString(this.QueryForReturn()));
                }
                catch
                { }
                Sb_Str.Append("<br/>");
            }
            conn.Open();
            string Dostr = "select top 1 ID,FollowNo,OutWareNo,FollowDateTime,FollowStaffNo,FollowText,FollowEnd,ReTime from KNet_Sales_OutWareList_FlowList where OutWareNo='" + OutWareNo + "' order by FollowDateTime desc";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if ((dr["ReTime"] != null) && (dr["ReTime"].ToString() != ""))
                {
                    Sb_Str.Append("交期：" + DateTime.Parse(dr["ReTime"].ToString()).ToShortDateString());
                }
                Sb_Str.Append("<br/>" + KNetPage.CutString(dr["FollowText"].ToString().Trim(), 40));
                if (dr["FollowEnd"].ToString() == "True")
                {
                    Sb_Return.Append("<img src=\"../../images/takman.gif\" width=\"11\" height=\"14\" border=\"0\" /><a href=\"#\" style=\"line-height: 22px;\" onclick=\"lhgdialog.opendlg('" + s_Title + ":<font color=Red>" + OutWareNo + "</font> 跟踪', '../Order/Knet_Sales_Ship_Manage_Talks_List.aspx?OutWareNo=" + OutWareNo + "', 780, 400,false,false);\">" + Sb_Str.ToString() + "</a>&nbsp;<font color=red>结束</font>");//&nbsp;<font color=\"gray\">" + base.Base_GetUserName(dr["FollowStaffNo"].ToString()) + "&nbsp;(" + dr["FollowDateTime"].ToString() + ")</font>
                }
                else
                {
                    Sb_Return.Append("<img src=\"../../images/takman.gif\" width=\"11\" height=\"14\" border=\"0\" /><a href=\"#\" style=\"line-height: 22px;\" onclick=\"lhgdialog.opendlg('" + s_Title + ":<font color=Red>" + OutWareNo + "</font> 跟踪', '../Order/Knet_Sales_Ship_Manage_Talks_List.aspx?OutWareNo=" + OutWareNo + "', 780, 400,false,false);\">" + Sb_Str.ToString() + "</a>&nbsp;<img src=\"../../images/45.gif\" width=\"11\" height=\"11\" border=\"0\" /><a href=\"#\" onclick=\"lhgdialog.opendlg('" + s_Title + ":<font color=Red>" + OutWareNo + "</font> 跟踪', '../Order/Knet_Sales_Ship_Manage_Talks_Add.aspx?OutWareNo=" + OutWareNo + "', 780, 400,false,false);\">添加</a>");
                }
            }
            else
            {
                Sb_Return.Append("<a href=\"#\" onclick=\"lhgdialog.opendlg('" + s_Title + ":<font color=Red>" + OutWareNo + "</font> 跟踪', '../Order/Knet_Sales_Ship_Manage_Talks_Add.aspx?OutWareNo=" + OutWareNo + "', 780, 400,false,false);\">" + Sb_Str.ToString() + " 添加</a>");
            }
            return Sb_Return.ToString();
        }
    }

    /// <summary>
    /// 查采购单状态 是否完成
    /// </summary>
    /// <param name="OrderNo"></param>
    protected bool UpdateOrderState(string OrderNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dosql = " select  (Sum(OrderAmount)-Sum(OrderHaveReceiving)-Sum(OrderHasReturned)) as SSum from Knet_Procure_OrdersList_Details where OrderNo='" + OrderNo + "'";
            SqlCommand cmd = new SqlCommand(Dosql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                try
                {
                    if (int.Parse(dr["SSum"].ToString().Trim()) > 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }


    /// <summary>
    /// 添加提示
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_DataRowBinding(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            CheckBox cb = (CheckBox)e.Row.Cells[1].FindControl("Chbk");
            TextBox Tbx_OrderNo = (TextBox)e.Row.Cells[1].FindControl("Tbx_OrderNo");

            if (GetReceivCheckYNEitxt(Tbx_OrderNo.Text) == true)
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
    /// 查看收货单是否已审核
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected bool GetReceivCheckYNEitxt(string OrderNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,OrderCheckYN,OrderNo from Knet_Procure_OrdersList where OrderNo='" + OrderNo + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["OrderCheckYN"].ToString() == "True")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
    /// <summary>
    /// 由采购单  返回采收货单 （删除用）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetKNet_ReceivNo(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,OrderNo,ReceivNo from Knet_Procure_ReceivingList where OrderNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["ReceivNo"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }

    /// <summary>
    /// 获取采购单明细数目
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected int Knet_Procure_OrdersList_Details_Shu(string OrderNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select count(*) as IDS  from Knet_Procure_OrdersList_Details where OrderNo='" + OrderNo + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return int.Parse(dr["IDS"].ToString().Trim().ToString());
            }
            else
            {
                return -1;
            }
        }
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

            string s_Sql = "select * from Zl_Produce_Problem_Details a join Zl_Produce_Problem b on a.ZPPD_FID=b.ZPP_ID  where ZPPD_OrderNo='" + aa + "' ";
            this.BeginQuery(s_Sql);
            DataTable Dtb_Table = (DataTable)this.QueryForDataTable();
            if (Dtb_Table.Rows.Count > 0)
            {
                string s_Return = "";
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
                    string s_ProblemType = base.Base_GetBasicCodeName("261", Dtb_Table.Rows[i]["ZPP_Type"].ToString()) + " 问题|";
                    string s_ZPPID = Dtb_Table.Rows[i]["ZPP_ID"].ToString();
                    string s_FlowStep = base.Base_GetBasicCodeName("263", Dtb_Table.Rows[i]["ZPP_FlowStep"].ToString()) + " ";

                    s_Return += "<a href=\"/WEB/ZL/Problem/Zl_Produce_Problem_View.aspx?ID=" + s_ZPPID + "\" target=\"_blank\"><font color=red>" + s_ProblemType + s_FlowStep + "</font></a>";
                    s_Return += "</br>";

                }
                return s_Return;
            }
            AdminloginMess AM = new AdminloginMess();
            if (((AM.KNet_StaffDepart != "129652783965723459") || (AM.KNet_Position != "102")) && (AM.KNet_StaffDepart != "129652784259578018"))//如果是研发中心经理显示
            {
                return "<font color=red>无权审核</font>";
            }
            conn.Open();

            string Dostr = "select ID,OrderNo,OrderState,OrderCheckYN from Knet_Procure_OrdersList where OrderNo='" + aa + "' and  OrderState!=2";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["OrderCheckYN"].ToString() == "True")
                {
                    return "<img src=\"../../../images/gou.gif\"  border=\"0\" />";
                }
                else
                {
                    if (Knet_Procure_OrdersList_Details_Shu(aa.ToString()) <= 0)
                    {
                        return "<a href=\"Knet_Procure_OpenBilling_AddDetails.aspx?OrderNo=" + aa + "\"><img src=\"../../../images/Nodata.gif\"  border=\"0\"  title=\"未完成的采购单（没有明细记录）\" /></a>";
                    }
                    else
                    {
                        if (GetYFsp(aa.ToString()))
                        {

                            string JSD = "Knet_Procure_OpenBilling_View.aspx?ID=" + aa.ToString() + "";
                            string StrPop = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=100,left=100,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=1000,height=600');\"  title=\"点击进行审核操作\">等待 <font color=red>研发经理</font> 审核</a>";
                            return StrPop;
                        }
                        else
                        {

                            string JSD = "Knet_Procure_OpenBilling_View.aspx?ID=" + aa.ToString() + "";
                            string StrPop = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=100,left=100,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=1000,height=600');\"  title=\"点击进行审核操作\">审核</a>";
                            return StrPop;
                        }
                    }
                }
            }
            else
            {
                return "--";
            }
        }
    }
    private bool GetYFsp(string s_OrderNo)
    {
        try
        {
            string s_Sql = "Select * from Knet_Procure_OrdersList_Details a join Knet_Procure_OrdersList b on a.OrderNo=b.OrderNO ";
            s_Sql += " and b.SuppNo in(Select SuppNo from Knet_Procure_OrdersList  where OrderNo='" + s_OrderNo + "' ) and ProductsBarCode in(Select ProductsBarCode from Knet_Procure_OrdersList_Details  where OrderNo='" + s_OrderNo + "' ) and a.OrderNo <>'" + s_OrderNo + "' ";
            this.BeginQuery(s_Sql);
            DataTable Dtb_Table = (DataTable)this.QueryForDataTable();
            if (Dtb_Table.Rows.Count <= 0)
            {
                return true;
            }
        }
        catch { }
        return false;
    }
    protected string CheckView(string s_OrderNo, string s_OrderType)
    {
        string s_Return = "", JSD = "";
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
                s_Return += "  <a href=\"../../Mail/PB_Basic_Mail_Add.aspx?OrderNo=" + Model.OrderNo + "\" class=\"webMnu\" target=\"_blank\"><img src=\"../../images/email.gif\"  border=\"0\" /></a> ";

            }
        }
        return s_Return;

    }

    protected string CheckView1(string s_OrderNo, string s_OrderType)
    {
        KNet.BLL.Knet_Procure_OrdersList BLl = new KNet.BLL.Knet_Procure_OrdersList();
        KNet.Model.Knet_Procure_OrdersList Model = BLl.GetModel(s_OrderNo);
        string s_Return = "";
        try
        {
            if (s_OrderType == "128860698200781250")//成品
            {
                s_Return = "<a href=\"/Web/Sc/Sc_Plan_Material.aspx?OrderNo=" + s_OrderNo + "\" target=\"_blank\">物料</a>";
            }
            else
            {

            }
        }
        catch
        { }
        return s_Return;

    }

    protected string GetPrint(string s_OrderNo, int i_IsSend)
    {
        string s_Return = "";
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
        }
        return s_Return;

    }


    /// <summary>
    /// 返回状态情况 （0未执行，1执行中，2逾期作废，3收货中，4退货中，5完成）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetOrderStateYN(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,OrderNo,OrderState,OrderCheckYN from Knet_Procure_OrdersList where OrderNo='" + aa + "' ";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                int A = int.Parse(dr["OrderState"].ToString());
                string Str = "--";
                switch (A)
                {
                    case 0:
                        Str = "<font color=#CC9900>未执行</font>";
                        break;
                    case 1:
                        Str = "<font color=blue>执行中</font>";
                        break;
                    case 2:
                        Str = "<font color=Red>作废</font>";
                        break;
                    case 3:
                        Str = "<font color=#990000>收货中</font>";
                        break;
                    case 4:
                        Str = "<font color=#FF9900>退货中</font>";
                        break;
                    case 5:
                        Str = "<img src=\"../../../images/fin.gif\" alt=\"采购单已完成\" width=\"15\" height=\"15\" border=\"0\" />";
                        break;
                    default:
                        Str = "--";
                        break;
                }
                return Str;
            }
            else
            {
                return "--";
            }
        }
    }

    protected void Btn_Query_Click(object sender, EventArgs e)
    {
        this.DataShows();
    }
    protected void Btn_Del_Click(object sender, EventArgs e)
    {
        AdminloginMess LogAM = new AdminloginMess();
        if (LogAM.KNet_StaffName == "项洲")
        {
            string sql = "delete from Knet_Procure_OrdersList where"; //删除采购单
            string sql2 = "delete from Knet_Procure_OrdersList_Details where"; //采购单明细

            string s_Sql2 = "Delete from PB_Basic_Mail where PBM_FID  in (Select OrderNo from Knet_Procure_OrdersList where ";

            string sql3 = "Select ContractNos from Knet_Procure_OrdersList where OrderType='128860698200781250' and  "; //采购单明细

            string cal = "", cal1 = "";
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
                if (cb.Checked == true)
                {
                    cal += " OrderNo='" + GridView1.DataKeys[i].Value.ToString() + "' or";
                    cal1 += " ParentOrderNo='" + GridView1.DataKeys[i].Value.ToString() + "' or";
                }
            }
            if (cal != "")
            {
                sql += cal.Substring(0, cal.Length - 3);
                sql2 += cal.Substring(0, cal.Length - 3);
                sql3 += cal.Substring(0, cal.Length - 3);
                s_Sql2 += cal.Substring(0, cal.Length - 3) + " ) and PBM_State=0 ";
            }
            else
            {
                sql = "";       //不删除
                sql2 = "";       //不删除
                sql3 = "";       //不删除
                Response.Write("<script language=javascript>alert('您没有选择要删除的记录!');history.back(-1);</script>");
                Response.End();
            }
            string s_ContractNo = "";
            try
            {
                this.BeginQuery(sql3);
                this.QueryForDataTable();
                if (this.Dtb_Result.Rows.Count > 0)
                {
                    for (int i = 0; i < Dtb_Result.Rows.Count; i++)
                    {
                        s_ContractNo += Dtb_Result.Rows[i][0].ToString() + ",";
                    }
                }
            }
            catch
            { }
            if (s_ContractNo != "")
            {
                s_ContractNo = s_ContractNo.Substring(0, s_ContractNo.Length - 1);
                string s_Sql = "Update  KNet_Sales_ContractList set IsOrder='0' where ContractNo in ('" + s_ContractNo.Replace(",", "','") + "')";
                DbHelperSQL.ExecuteSql(s_Sql);
            }

            DbHelperSQL.ExecuteSql(s_Sql2);
            DbHelperSQL.ExecuteSql(sql);
            DbHelperSQL.ExecuteSql(sql2);
            Alert("删除成功！");
            LogAM.Add_Logs("采购入库--->采购单管理--->采购单删除 操作成功！" + cal);

            this.DataShows();
        }
    }
    public string GetRk(string s_RKSTtate, string s_OrderNo, string s_Type)
    {
        if (s_Type != "加工厂")
        {

            if (s_RKSTtate == "0")
            {
                return "<a href=\"/Web/Cg/OrderInWareHouse/Knet_Procure_WareHouseList_Add.aspx?OrderNo=" + s_OrderNo + "\"><font color=\"red\">未入库</font></a>";
            }
            else if (s_RKSTtate == "1")
            {
                return "<a href=\"/Web/Cg/OrderInWareHouse/Knet_Procure_WareHouseList_Add.aspx?OrderNo=" + s_OrderNo + "\"><font color=\"red\">已入库</font></a>";
            }
            else
            {
                return "<a href=\"/Web/Cg/OrderInWareHouse/Knet_Procure_WareHouseList_Add.aspx?OrderNo=" + s_OrderNo + "\"><font color=\"red\">部分发货</font></a>";
            }

        }
        else
        {
            KNet.BLL.Knet_Procure_OrdersList Bll = new KNet.BLL.Knet_Procure_OrdersList();
            KNet.Model.Knet_Procure_OrdersList Model = Bll.GetModelB(s_OrderNo);

            if (Model.KPO_IsStopProduce == 1)
            {
                return "<font color=\"blue\">暂停生产</font>";
            }
            else
            {

                if (s_RKSTtate == "0")
                {
                    return "<a href=\"/Web/ScExpend/Sc_Expend_Add.aspx?OrderNo=" + s_OrderNo + "\"><font color=\"red\">未入库</font></a>";
                }
                else if (s_RKSTtate == "1")
                {
                    return "<a href=\"/Web/ScExpend/Sc_Expend_Add.aspx?OrderNo=" + s_OrderNo + "\"><font color=\"red\">已入库</font></a>";
                }
                else
                {
                    return "<a href=\"/Web/ScExpend/Sc_Expend_Add.aspx?OrderNo=" + s_OrderNo + "\"><font color=\"red\">部分发货</font></a>";
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
    public string GetContract(string s_ContractNos, string s_ContractNo1)
    {
        string s_Return = "";
        try
        {
            string[] s_ContractNo = s_ContractNos.Split(',');
            for (int i = 0; i < s_ContractNo.Length; i++)
            {
                s_Return += "<a href=\"/Web/Xs/SalesContract/KNet_Sales_ContractList_View.aspx?ID=" + s_ContractNo[i] + "\" target=\"_blank\" >" + s_ContractNo[i] + "</a>&nbsp;";
                s_Return += "<a href=\"Knet_Procure_OpenBilling_Manage.aspx?SalesOrderNo=" + s_ContractNo[i] + "\"><font color=green>相同</font></a>";
            }
            if (s_Return == "")
            {
                s_Return += "<a href=\"/Web/Xs/SalesContract/KNet_Sales_ContractList_View.aspx?ID=" + s_ContractNo1 + "\" target=\"_blank\" >" + s_ContractNo1 + "</a>&nbsp;";
                s_Return += "<a href=\"Knet_Procure_OpenBilling_Manage.aspx?SalesOrderNo=" + s_ContractNo1 + "\"><font color=green>相同</font></a>";
            }
        }
        catch
        { }
        return s_Return;
    }
    protected void Ddl_Supp_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataShows();
    }
    public string GetDbState(string s_ScOrderNo)
    {
        string s_Return = "";
        try {
            string s_Sql = "select Sum(isnull(KWAC_Number,0)) Number from Knet_Procure_OrdersList_Details a left join KNet_WareHouse_AllocateList_CPDetails b ";
            s_Sql += " on a.ID=b.KWAC_OrderNoID where a.OrderNo='" + s_ScOrderNo + "' group by  a.id order by a.id";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            if (this.Dtb_Result.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Result.Rows.Count; i++)
                {
                    s_Return += Dtb_Result.Rows[i]["Number"].ToString();

                    s_Return += "<br/>";
                }
            }
        }
        catch
        { }
        return s_Return;
    }
}
