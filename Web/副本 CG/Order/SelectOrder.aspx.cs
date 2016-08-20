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
public partial class SelectOrder : BasePage
{
    public string s_DivStyle = "";
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            this.Lbl_Title.Text = "采购单列表";
            if (AM.CheckLogin("采购单列表") == false)
            {
                BasePage.AlertAndRedirect("您未登陆系统或已超过，请重新登陆系统!", "Default.aspx");
            }
            else
            {
                string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
                string s_Model = Request.QueryString["Model"] == null ? "" : Request.QueryString["Model"].ToString();
                if ((s_ID != "") && (s_Model == "IsSend"))
                {
                    KNet.BLL.Knet_Procure_OrdersList Bll = new KNet.BLL.Knet_Procure_OrdersList();
                    KNet.Model.Knet_Procure_OrdersList Model = Bll.GetModelB(s_ID);
                    Model.OrderNo = s_ID;
                    int i_IsSend = Math.Abs(Model.KPO_IsSend - 1);
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
                this.RowOverYN();
            }
        }

    }
    /// <summary>
    /// 是不是有记录
    /// </summary>
    protected void RowOverYN()
    {
        if (GridView1.Rows.Count == 0) //如果没有记录
        {
            this.Btn_Del.Enabled = false;
        }
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
        string s_Type = "";

        string SqlWhere = " 1=1 ";
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
            string OrderNo = GridView1.DataKeys[e.Row.RowIndex].Value.ToString(); //获取ID值
            CheckBox cb = (CheckBox)e.Row.Cells[1].FindControl("Chbk");
            if (GetReceivCheckYNEitxt(OrderNo) == true)
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
                        string JSD = "Knet_Procure_OpenBillingCheckYN.aspx?OrderNo=" + aa.ToString() + "";
                        string StrPop = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=400,height=250');\"  title=\"点击进行审核操作\">审核</a>";
                        return StrPop;
                    }
                }
            }
            else
            {
                return "--";
            }
        }
    }
    protected string CheckView(string s_OrderNo,string s_OrderType)
    {
        string s_Return = "", JSD="";
        KNet.BLL.Knet_Procure_OrdersList BLl = new KNet.BLL.Knet_Procure_OrdersList();
        KNet.Model.Knet_Procure_OrdersList Model = BLl.GetModelB(s_OrderNo);
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
                JSD = "Knet_Procure_OpenBilling_Print.aspx?ID=" + s_OrderNo + "";
                s_Return = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=120,left=150,toolbar=yes, menubar=yes,scrollbars=yes, resizable=yes, location=yes, status=yes, width=780,height=500');\"  title=\"点击进行审核操作\"><img src=\"../../../images/View.gif\"  border=\"0\" /></a>";
            
 
        }
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
        else
        {
            string JSD = "Knet_Procure_OpenBilling_Manage.aspx?ID=" + s_OrderNo + "&Model=IsSend";
            s_Return = "<a href=\"" + JSD + "\" onclick=\"\" >已发送</a>";
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
        string sql = "delete from Knet_Procure_OrdersList where"; //删除采购单
        string sql2 = "delete from Knet_Procure_OrdersList_Details where"; //采购单明细
        string sql3 = "Update  KNet_Sales_ContractList set IsOrder='0' where ContractNo in (Select ContractNo from Knet_Procure_OrdersList where "; //采购单明细

        string cal = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {
                cal += " OrderNo='" + GridView1.DataKeys[i].Value.ToString() + "' or";
            }
        }
        if (cal != "")
        {
            sql += cal.Substring(0, cal.Length - 3);
            sql2 += cal.Substring(0, cal.Length - 3);
            sql3 += cal.Substring(0, cal.Length - 3);

        }
        else
        {
            sql = "";       //不删除
            sql2 = "";       //不删除
            sql3 = "";       //不删除
            Response.Write("<script language=javascript>alert('您没有选择要删除的记录!');history.back(-1);</script>");
            Response.End();
        }

        DbHelperSQL.ExecuteSql(sql3 + ")");
        DbHelperSQL.ExecuteSql(sql);
        DbHelperSQL.ExecuteSql(sql2);

        LogAM.Add_Logs("采购入库--->采购单管理--->采购单删除 操作成功！");

        this.DataShows();
        this.RowOverYN();
    }
    public string GetRk(string s_OrderNo)
    {
        int i_LeftNumber=0,i_Number=0;
        //string s_Return = "";
        string s_Sql = "select b.ProductsBarCode,Sum(b.WareHouseAmount),Sum(C.OrderAmount),Sum(C.OrderAmount-b.WareHouseAmount) from Knet_Procure_WareHouseList a join Knet_Procure_WareHouseList_Details b on a.WareHouseNo=b.WareHouseNo join Knet_Procure_OrdersList_Details c on c.OrderNo=a.OrderNo Where a.OrderNo='" + s_OrderNo + "' Group by b.ProductsBarCode";
        this.BeginQuery(s_Sql);
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                i_LeftNumber += int.Parse(Dtb_Result.Rows[i][3].ToString());
                i_Number+= int.Parse(Dtb_Result.Rows[i][2].ToString());
            }
            if(i_LeftNumber==0)
            {
                return "<font color=\"blue\">全部入库</font>";
            }
            else if (i_LeftNumber == i_Number)
            {
                return "<a href=\"Knet_Procure_WareHouse_Manage_Add.aspx?OrderNo=" + s_OrderNo + "\"><font color=\"red\">未入库</font></a>";
            }
            else 
            {
                return "<a href=\"Knet_Procure_WareHouse_Manage_Add.aspx?OrderNo=" + s_OrderNo + "\"><font color=\"red\">部分发货</font></a>";
            }
    
        }
        else
        {
            return "<a href=\"Knet_Procure_WareHouse_Manage_Add.aspx?OrderNo=" + s_OrderNo + "\"><font color=\"red\">未入库</font></a>";
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
    public string GetContract(string s_ContractNos)
    {
        string s_Return = "";
        try
        {
            string[] s_ContractNo = s_ContractNos.Split(',');
            for (int i = 0; i < s_ContractNo.Length; i++)
            {
                s_Return += "<a href=\"../../SalesContract/Xs_ContractList_View.aspx?ID=" + s_ContractNo[i] + "\" >" + s_ContractNo[i] + "</a><br>";

            }
        }
        catch
        { }
        return s_Return;
    }
}
    