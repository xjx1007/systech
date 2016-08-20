using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Json;

using KNet.DBUtility;
using KNet.Common;
using System.Net;


public partial class Admin_hame : BasePage
{
    public class KDDetails
    {

        private string _status;
        private string _errCode;
        private string _message;

        public string status
        {
            set { _status = value; }
            get { return _status; }
        }
        public string errCode
        {
            set { _errCode = value; }
            get { return _errCode; }
        }
        public string message
        {
            set { _message = value; }
            get { return _message; }
        }
    }

    public string GetKDSateName(string s_WareNo)
    {
        string s_Rturn = "";
        this.BeginQuery("Select * from KNet_Sales_OutWareList_FlowList where OutWareNo='" + s_WareNo + "' and KDCodeName<>'' and KDCode<>'' ");
        this.QueryForDataTable();
        DataTable Dtb_Table = this.Dtb_Result;
        if (Dtb_Table.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Table.Rows.Count; i++)
            {
                string s_KDName = Dtb_Table.Rows[i]["KDName"].ToString();
                string s_Code = Dtb_Table.Rows[i]["KDCode"].ToString();
                string s_ID = Dtb_Table.Rows[i]["ID"].ToString();
                string s_CodeName = Dtb_Table.Rows[i]["KDCodeName"].ToString();
                string s_State = Dtb_Table.Rows[i]["State"]==null?"":Dtb_Table.Rows[i]["State"].ToString();
                if (s_State == "")
                {
                    String url = "http://api.ickd.cn/?com=" + s_KDName + "&nu=" + s_Code + "&id=F358C662FEC3E1CAA2C8C20DD2F9A448&type=json";
                    string jsonString = "";
                    this.BeginQuery("Select * from PB_Basic_Wl where PBW_Name='" + s_CodeName + "'");
                    this.QueryForDataTable();
                    if (this.Dtb_Result.Rows.Count > 0)
                    {

                        if (this.Dtb_Result.Rows[0]["PBW_Code"].ToString() == "")
                        {
                            WebPage webInfo = new WebPage(this.Dtb_Result.Rows[0]["PBW_Url"].ToString() + s_Code);
                            string s_Detiles = webInfo.M_html.Replace("请输入运单编号", "");
                            if (s_Detiles.IndexOf("签收") > 0)
                            {
                                s_State = "<Font Color=red>已签收</Font>";
                            }
                            else if (s_Detiles.IndexOf("SORRY") > 0)
                            {
                                s_State = "<Font Color=Black>查询失败<Font Color=Blue>";
                            }
                            else
                            {
                                s_State = "<Font Color=Blue>正常</Font>";
                            }
                        }
                        else
                        {
                            try
                            {

                                jsonString = getPageInfo(url);
                                KDDetails KdDetail = JsonHelper.ParseFromJson<KDDetails>(jsonString);
                                s_State = GetSateName(KdDetail.status);
                            }
                            catch
                            {
                                s_State = "错误！";
                            }

                        }
                        if (s_State == "<Font Color=red>已签收</Font>")
                        {
                            KNet.BLL.KNet_Sales_OutWareList_FlowList BLL_Flow = new KNet.BLL.KNet_Sales_OutWareList_FlowList();
                            KNet.Model.KNet_Sales_OutWareList_FlowList Model_Flow = new KNet.Model.KNet_Sales_OutWareList_FlowList();
                            Model_Flow.ID = s_ID;
                            Model_Flow.State = s_State;
                            BLL_Flow.UpDataSate(Model_Flow);
                        }
                    }
                }
                s_Rturn += "<a href=\"#\"  onclick=\"javascript:window.open('../Web/Sales/Knet_Sales_Ship_Manage_Talks_Detail.aspx?com=" + s_KDName + "&Code=" + s_Code + "&Name=" + s_CodeName + "','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=580,height=250');\">" + s_Code;

                s_Rturn += "( " + s_State + " )</a>" + ",";
            }

        }
        return s_Rturn == "" ? "" : s_Rturn.Substring(0, s_Rturn.Length - 1);
    }

    public static string getPageInfo(String url)
    {
        WebResponse wr_result = null;
        StringBuilder txthtml = new StringBuilder();
        try
        {
            WebRequest wr_req = WebRequest.Create(url);
            wr_req.Timeout = 10000;
            wr_result = wr_req.GetResponse();
            Stream ReceiveStream = wr_result.GetResponseStream();
            Encoding encode = System.Text.Encoding.GetEncoding("gb2312");
            StreamReader sr = new StreamReader(ReceiveStream, encode);
            if (true)
            {
                Char[] read = new Char[256];
                int count = sr.Read(read, 0, 256);
                while (count > 0)
                {
                    String str = new String(read, 0, count);
                    txthtml.Append(str);
                    count = sr.Read(read, 0, 256);
                }
            }
        }
        catch (Exception)
        {
            txthtml.Append("err");
        }
        finally
        {
            if (wr_result != null)
            {
                wr_result.Close();
            }
        }
        return txthtml.ToString();
    }
    public string GetSateName(string s_ID)
    {
        string s_Return = "";
        //0表示查询失败，1正常，2派送中，3已签收，4退回
        switch (int.Parse(s_ID))
        {
            case 0:
                s_Return = "<Font Color=Black>查询失败<Font Color=Blue>";
                break;
            case 1:
                s_Return = "<Font Color=Blue>正常</Font>";
                break;
            case 2:
                s_Return = "<Font Color=Green>派送中</Font>";
                break;
            case 3:
                s_Return = "<Font Color=red>已签收</Font>";
                break;
        }
        return s_Return;

    }
    //错误代码，0无错误，1单号不存在，2验证码错误，3链接查询服务器失败，4程序内部错误，5程序执行错误，6快递单号格式错误，7快递公司错误，10未知错误。
    public string GetErrorName(string s_ID)
    {
        string s_Return = "";
        //0表示查询失败，1正常，2派送中，3已签收，4退回
        switch (int.Parse(s_ID))
        {
            case 0:
                s_Return = "无错误";
                break;
            case 1:
                s_Return = "单号不存在";
                break;
            case 2:
                s_Return = "验证码错误";
                break;
            case 3:
                s_Return = "链接查询服务器失败";
                break;
            case 4:
                s_Return = "程序内部错误";
                break;
            case 5:
                s_Return = "程序执行错误";
                break;
            case 6:
                s_Return = "快递单号格式错误";
                break;
            case 7:
                s_Return = "快递公司错误";
                break;
            case 10:
                s_Return = "未知错误";
                break;
        }
        return s_Return;

    }
    protected void Page_Load(object sender, EventArgs e)
    {   
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();

            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '../Default.aspx';</script>");
                Response.End();
            }
            else
            {
                string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();

                if (AM.KNet_StaffName.ToUpper() == "ADMIN")
                {
                    this.Warehouse_Name.Text = "超级管理员:全部库";
                }
                else
                {
                    this.Warehouse_Name.Text = GetKNet_Sys_WareHouseName(AM.KNet_StaffNo);
                }

                if (AM.KNet_Soft_StaffLanguage ==1)
                {
                    this.StaffLanguage.Items[0].Selected = true;
                }
                else if (AM.KNet_Soft_StaffLanguage == 2)
                {
                    this.StaffLanguage.Items[1].Selected = true;
                }
                else
                {
                    this.StaffLanguage.Items[0].Selected = true;
                }

                try
                {
                    this.StaffCatalogue.SelectedValue = AM.KNet_Soft_StaffCatalogue.ToString();
                }
                catch { }


                this.StaffName.Text = AM.KNet_StaffName;
                this.A2A.Visible = false;
                this.B2B.Visible = true;
                this.C2C.Visible = false;
                this.D2D.Visible = false;
                this.LinkButton2.CssClass = "Div22";


                if (AM.KNet_Sys_NoticeYN == true)
                {
                    this.NoticeYNs.Visible = true;
                    this.NoticeContenttxt.Text = AM.KNet_Sys_NoticeContent;
                    
                }
                else
                {
                    this.NoticeYNs.Visible = false;
                    this.NoticeContenttxt.Text = "公告没有打开..";
                }
                this.DataShows();
                if ((AM.KNet_StaffDepart == "129652783965723459") && (AM.KNet_Position == "102"))//如果是研发中心经理显示
                {
                    KNet.BLL.Knet_Procure_OrdersList bll = new KNet.BLL.Knet_Procure_OrdersList();
                    DataSet ds = bll.GetList("OrderCheckYN='0' Order by SystemDatetimes desc");
                    GridView_Order.DataSource = ds.Tables[0];
                    GridView_Order.DataKeyNames = new string[] { "OrderNo" };
                    GridView_Order.DataBind();
                    this.Ltn_Order.Text += "  [ <Font Color=Red>" + Convert.ToString(ds.Tables[0].Rows.Count) + "</font> ]";
                }
                else
                {
                    this.Ltn_Order.Text += "  [ <Font Color=Red>0</font> ]";
                }
                KNet.BLL.KNet_Sales_OutWareList bll_Sales_OutWareList = new KNet.BLL.KNet_Sales_OutWareList();

                string SqlWhere = " 1=1 and OutWareNo not in (Select OutWareNo from KNet_Sales_OutWareList_FlowList where Followend='1') ";
                SqlWhere = SqlWhere + " order by SystemDateTimes desc";
                DataSet ds_Sales_OutWareList = bll_Sales_OutWareList.GetList(SqlWhere);
                GridView_Ship.DataSource = ds_Sales_OutWareList;
                GridView_Ship.DataKeyNames = new string[] { "OutWareNo" };
                GridView_Ship.DataBind();
                this.Ltn_Ship.Text += "  [ <Font Color=Red>" + Convert.ToString(ds_Sales_OutWareList.Tables[0].Rows.Count) + "</font> ]";

                if (s_Type == "1")
                {

                    this.Pan_Contract.Visible = true;
                    this.Ltn_Ship.Visible = false;
                    this.Ltn_Order.Visible = false;
                    this.Lbl_Cotracted.Visible = false;
                    this.Ltn_SalesReturn.Visible = false;
                    this.Ltn_Return.Visible = false;
                }
                else
                {
                    if (IsShipYN() != "")
                    {
                        this.MSNfunction(AM.KNet_Sys_CompanyName, "../web/Sales_Check/KNet_Sales_ContractList_Manage.aspx?Type=1", "最近发货提醒:", "最近有<font color=red>" + IsShipYN() + "</font> 条 需要发货!<BR><BR>已有合同评审将到达发货日期!", "点击查看合同评审明细");
                    }
                }
            }
        }
    }


    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.KNet_Sales_ContractList bll = new KNet.BLL.KNet_Sales_ContractList();
        string SqlWhere = " 1=1 and  ContractCheckYN='0' ";
        SqlWhere = SqlWhere + " order by SystemDateTimes desc";
        DataSet ds = bll.GetList(SqlWhere);
        this.Ltn_Contract.Text += "  [ <Font Color=Red>"+Convert.ToString(ds.Tables[0].Rows.Count)+"</font> ]";
        GridView2.DataSource = ds;
        GridView2.DataKeyNames = new string[] { "ContractNo" };
        GridView2.DataBind();
        AdminloginMess AM = new AdminloginMess();
        string s_Sql = " 1=1 and  ContractCheckYN='1' and ContractDateTime>'2012-9-27' and ContractNO not in (Select XCV_ContractNo from Xs_Contract_ViewPerson where XCV_Person='" + AM.KNet_StaffNo+ "')";
        s_Sql = s_Sql + " order by SystemDateTimes desc";
        DataSet Ds1 = bll.GetList(s_Sql);
        this.Lbl_Cotracted.Text += "  [ <Font Color=Red>" + Convert.ToString(Ds1.Tables[0].Rows.Count) + "</font> ]";
        this.GridView_Cotracted.DataSource = Ds1;
        GridView_Cotracted.DataKeyNames = new string[] { "ContractNo" };
        GridView_Cotracted.DataBind();


        //退货


        KNet.BLL.KNet_WareHouse_DirectInto bll_DirectInto = new KNet.BLL.KNet_WareHouse_DirectInto();

        string S_SqlWhere = " KWD_Type='102' and  DirectINCheckYN='0' ";
        S_SqlWhere = S_SqlWhere + " order by SystemDatetimes desc ";
        DataSet ds2 = bll_DirectInto.GetList(S_SqlWhere);
        GridView_Return.DataSource = ds2;
        this.Ltn_Return.Text += "  [ <Font Color=Red>" + Convert.ToString(ds2.Tables[0].Rows.Count) + "</font> ]";
        GridView_Return.DataBind();


        KNet.BLL.KNet_Sales_ReturnList bll_ReturnList = new KNet.BLL.KNet_Sales_ReturnList();
        SqlWhere=" ReturnCheckYN='0' ";
        SqlWhere = SqlWhere + " order by ReturnDateTime desc";
        DataSet ds3 = bll_ReturnList.GetList(SqlWhere);
        GridView_SalesReturn.DataSource = ds3;
        GridView_SalesReturn.DataKeyNames = new string[] { "ReturnNo" };
        this.Ltn_SalesReturn.Text += "  [ <Font Color=Red>" + Convert.ToString(ds3.Tables[0].Rows.Count) + "</font> ]";
        GridView_SalesReturn.DataBind();



        string SqlWhere3 = " 1=1 and  c.isship='1' and a.SystemDateTimes>'2012-9-1' ";
        SqlWhere3 = SqlWhere3 + " order by a.SystemDateTimes desc";
        DataSet Ds4 = bll.GetCkList(SqlWhere3);
        this.Ltn_RkNotShip.Text += "  [ <Font Color=Red>" + Convert.ToString(Ds4.Tables[0].Rows.Count) + "</font> ]";
        this.GridView_RkNotShip.DataSource = Ds4;
        GridView_RkNotShip.DataKeyNames = new string[] { "ContractNo" };
        GridView_RkNotShip.DataBind();


        
    }


    /// <summary>
    /// 返回审核情况（Y）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetSalesReturnCheckYN(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,ReturnNo,ReturnCheckYN from KNet_Sales_ReturnList where ReturnNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["ReturnCheckYN"].ToString() == "True")
                {
                    string s_Return = "";
                    decimal d_DirectOutAmount = 0, d_ReturnAmount = 0;
                    this.BeginQuery("Select a.DirectInNo,isnull(Sum(b.DirectInAmount),0) as Number from KNet_WareHouse_DirectInto a join KNet_WareHouse_DirectInto_Details b on a.DirectInNo=b.DirectInNo where a.KWD_Type='102' and a.KWD_ReturnNo='" + aa + "' Group by a.DirectInNo ");
                    this.QueryForDataTable();
                    if (this.Dtb_Result.Rows.Count > 0)
                    {
                        d_DirectOutAmount = Decimal.Parse(Dtb_Result.Rows[0][1].ToString());

                    }

                    this.BeginQuery("Select a.ReturnNo,isnull(Sum(b.ReturnAmount),0) as Number from KNet_Sales_ReturnList a join KNet_Sales_ReturnList_Details b on a.ReturnNo=b.ReturnNo where a.ReturnNo='" + aa + "' Group by a.ReturnNo ");
                    this.QueryForDataTable();
                    if (this.Dtb_Result.Rows.Count > 0)
                    {
                        d_ReturnAmount = Decimal.Parse(Dtb_Result.Rows[0][1].ToString());
                    }
                    if (d_ReturnAmount > d_DirectOutAmount)
                    {
                        s_Return = "<a href=\"../Web/Sales/KNet_WareHouse_DirectInto_Add.aspx?ReturnNo=" + aa + "\"><font Color=Red>部分入库</font></a>";
                    }
                    if (d_DirectOutAmount == 0)
                    {
                        s_Return = "<a href=\"../Web/Sales/KNet_WareHouse_DirectInto_Add.aspx?ReturnNo=" + aa + "\"><font Color=Red>未入库</font></a>";
                    }
                    if (d_ReturnAmount == d_DirectOutAmount)
                    {
                        s_Return = "已入库";
                    }

                    if (d_ReturnAmount < d_DirectOutAmount)
                    {
                        s_Return = "<font Color=Green>已多入库</font>";
                    }
                    return s_Return;
                }
                else
                {
                    this.BeginQuery("select count(*) as IDS  from KNet_Sales_ReturnList_Details where ReturnNo='" + aa + "'");
                    this.QueryForDataSet();
                    if (this.Dts_Result.Tables[0].Rows.Count <= 0)
                    {
                        return "<a href=\"../Web/Sales/Knet_Sales_Retrun_Manage_AddDetails.aspx?ReturnNo=" + aa + "\"><img src=\"../images/Nodata.gif\"  border=\"0\"  title=\"未完成的退货单（没有明细记录）\" /></a>";
                    }
                    else
                    {
                        string JSD = "../Web/Sales/pop/Knet_Sales_RetrunCheckYN.aspx?ReturnNo=" + aa.ToString() + "";
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

    /// <summary>
    /// 退货入库
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    public string GetReturnCheckYN(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,DirectInNo,DirectInCheckYN from KNet_WareHouse_DirectInto where DirectInNo='" + aa + "' ";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["DirectInCheckYN"].ToString() == "True")
                {
                    return "<img src=\"../images/gou.gif\"  border=\"0\" />";
                }
                else
                {
                    this.BeginQuery("select count(*) as IDS  from KNet_WareHouse_DirectInto_Details where DirectInNo='" + aa + "'");
                    this.QueryForDataSet();
                    if (this.Dts_Result.Tables[0].Rows.Count <= 0)
                    {
                        return "<a href=\"../Web/Sales/KNet_WareHouse_DirectInto_AddDetails.aspx?DirectInNo=" + aa + "\"><img src=\"../Web/images/Nodata.gif\"  border=\"0\"  title=\"未完成的入库单（没有明细记录）\" /></a>";
                    }
                    else
                    {
                        string JSD = "../Web/WareHouse/pop/KNet_WareHouse_DirectIntoCheckYN.aspx?DirectInNo=" + aa.ToString() + "";
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
    /// <summary>
    /// 系统前台
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        this.LinkButton1.CssClass = "Div22";
        this.LinkButton2.CssClass = "Div11";
        this.LinkButton3.CssClass = "Div11";
        this.LinkButton4.CssClass = "Div11";
        this.A2A.Visible = true;
        this.B2B.Visible = false;
        this.C2C.Visible = false;
        this.D2D.Visible = false;
    }
    /// <summary>
    /// 我的信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        this.LinkButton1.CssClass = "Div11";
        this.LinkButton2.CssClass = "Div22";
        this.LinkButton3.CssClass = "Div11";
        this.LinkButton4.CssClass = "Div11";
        this.A2A.Visible = false;
        this.B2B.Visible = true;
        this.C2C.Visible = false;
        this.D2D.Visible = false;
    }


    /// <summary>
    /// 修改密码
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        this.LinkButton1.CssClass = "Div11";
        this.LinkButton2.CssClass = "Div11";
        this.LinkButton3.CssClass = "Div22";
        this.LinkButton4.CssClass = "Div11";
        this.A2A.Visible = false;
        this.B2B.Visible = false;
        this.C2C.Visible = true;
        this.D2D.Visible = false;
    }
    /// <summary>
    /// 习惯设置
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        this.LinkButton1.CssClass = "Div11";
        this.LinkButton2.CssClass = "Div11";
        this.LinkButton3.CssClass = "Div11";
        this.LinkButton4.CssClass = "Div22";
        this.A2A.Visible = false;
        this.B2B.Visible = false;
        this.C2C.Visible = false;
        this.D2D.Visible = true;
    }
    /// <summary>
    /// 获返仓库名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetKNet_Sys_WareHouseNameByHouseNo(string HouseNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,HouseNo,HouseName from KNet_Sys_WareHouse where HouseNo='" + HouseNo + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    return dr["HouseName"].ToString().Trim();
                }
                else
                {
                    return "";
                }
            }
        }
    }
    /// <summary>
    /// 获取员工的仓库列表
    /// </summary>
    /// <param name="StaffNo"></param>
    /// <returns></returns>
    protected string GetKNet_Sys_WareHouseName(string StaffNo)
    {
        string ListStr = "";
        using (DataSet ds = GetList("StaffNo='" + StaffNo + "'"))
        {
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                DataRowView mydrv = ds.Tables[0].DefaultView[i];
                if (i == 0)
                {
                    ListStr = ListStr + GetKNet_Sys_WareHouseNameByHouseNo(mydrv["HouseNo"].ToString());
                }
                else
                {
                    ListStr = ListStr + "<B>|</B>" + GetKNet_Sys_WareHouseNameByHouseNo(mydrv["HouseNo"].ToString());
                }
            }
        }
        if (ListStr == "")
        {
            return "<font color=\"gray\">未受权任何仓库</font>";
        }
        else
        {
            return ListStr;
        }
    }
    /// <summary>
    /// 获得受权仓库  数据列表
    /// </summary>
    protected DataSet GetList(string strWhere)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select StaffNo,HouseNo ");
        strSql.Append(" FROM KNet_Sys_WareHouse_AuthList ");
        if (strWhere.Trim() != "")
        {
            strSql.Append(" where " + strWhere);
        }
        return DbHelperSQL.Query(strSql.ToString());
    }


    /// <summary>
    /// 最近日志绑定 
    /// </summary>
    /// <param name="ParentID"></param>
    protected void DLBind(GridView DataListName)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Parentsqlstr = "select top 15 * from KNet_Static_logs order by Logtime desc";
            
            SqlDataAdapter da = new SqlDataAdapter(Parentsqlstr, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "KNet_logs");
            DataListName.DataSource = ds;
            DataListName.DataBind();
        }
    }
    /// <summary>
    /// 由员工编号获取员工姓名
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string Knet_Get_StaffName(string aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,StaffNo,StaffName from KNet_Resource_Staff where StaffNo='" + aa + "'  or  StaffCard='" + aa + "' ";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    return dr["StaffName"].ToString().Trim();
                }
                else
                {
                    return "未知员工";
                }
            }
        }

    }

    /// <summary>
    /// 排序
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_DataRowBinding(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            int id = e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = id.ToString();
        }
    }


    //确定修改密码
    protected void Button4_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        if (AM.KNet_Soft_WebTest == true) //演示版
        {
            Response.Write("<script>alert('抱歉!在线演示用,不能操作此处!');history.back(-1);</script>");
            Response.End();
        }


        if (AM.CheckLogin() == false)
        {
            Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '../Default.aspx';</script>");
            Response.End();
        }
        else
        {
            try
            {
                string NewWspA = KNetPage.KNetMD5(NewWsp1.Text.Trim().ToUpper());
                string NewWspB = KNetPage.KNetMD5(NewWsp2.Text.Trim().ToUpper());

                string StaffNos = AM.KNet_StaffNo;
                string StaffNames = AM.KNet_StaffName;
                if (NewWspA.CompareTo(NewWspB) == 0)
                {


                    this.Update_Knet_Staff_UpdatePasswordSelf(StaffNos, StaffNames, NewWspB);

                    Response.Write("<script language=javascript>alert('新的密码修改成功，请重新登陆系统！');parent.location.href = '../Default.aspx';</script>");
                    Response.End();
                }
                else
                {
                    Response.Write("<script language=javascript>alert('密码改修错误,未知错误！请重新登陆系统！');parent.location.href = '../Default.aspx';</script>");
                    Response.End();
                }
            }
            catch
            {
               // throw;
               Response.Write("<script language=javascript>alert('密码改修错误,未知错误！请重新登陆系统！');parent.location.href = '../Default.aspx';</script>");
               Response.End();
            }
        }
    }
    /// <summary>
    /// 自改密码
    /// </summary>
    /// <param name="P_Str_HouseNo"></param>
    /// <param name="P_Str_HouseName"></param>
    /// <param name="P_Str_HouseWps"></param>
    public void Update_Knet_Staff_UpdatePasswordSelf(string P_Str_StaffNo, string P_Str_StaffName, string P_Str_StaffPassword)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            SqlCommand myCmd = new SqlCommand("Proc_Update_Knet_Staff_Password", conn);
            myCmd.CommandType = CommandType.StoredProcedure;
            //添加参数
            SqlParameter StaffNo = new SqlParameter("@StaffNo", SqlDbType.NVarChar, 50);
            StaffNo.Value = P_Str_StaffNo;
            myCmd.Parameters.Add(StaffNo);
            //添加参数
            SqlParameter StaffName = new SqlParameter("@StaffName", SqlDbType.NVarChar, 60);
            StaffName.Value = P_Str_StaffName;
            myCmd.Parameters.Add(StaffName);
            //添加参数
            SqlParameter StaffPassword = new SqlParameter("@StaffPassword", SqlDbType.NVarChar, 60);
            StaffPassword.Value = P_Str_StaffPassword;
            myCmd.Parameters.Add(StaffPassword);
            //执行过程
            conn.Open();
            try
            {
                myCmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                myCmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }
    }

    /// <summary>
    /// 个人习惯设置
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        if (AM.CheckLogin() == false)
        {
            Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '../Default.aspx';</script>");
            Response.End();
        }
        else
        {
            try
            {
                int StaffLanguage = int.Parse(this.StaffLanguage.SelectedValue.Trim());
                int StaffCatalogue = int.Parse(this.StaffCatalogue.SelectedValue.Trim());

                string StaffNo = AM.KNet_StaffNo;
                string StaffCard = AM.KNet_StaffCard;

                string Dosql = "update KNet_Resource_Staff set StaffLanguage=" + StaffLanguage + ",StaffCatalogue=" + StaffCatalogue + " where StaffNo='" + StaffNo + "' and StaffCard='" + StaffCard + "'";

                try
                {
                    DbHelperSQL.ExecuteSql(Dosql);
                    Response.Write("<script language=javascript>alert('个人习惯设置成功，请重新登陆系统！');parent.location.href = '../login.aspx';</script>");
                    Response.End();
                }
                catch { throw; }
            }
            catch
            {
                // throw;
                Response.Write("<script language=javascript>alert('个人习惯设置错误,未知错误！请重新登陆系统！');parent.location.href = '../login.aspx';</script>");
                Response.End();
            }
        }
    }


    /// <summary>
    /// 返回审核情况（Y）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetShipCheckYN(object aa)
    {
        AdminloginMess AM = new AdminloginMess();
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,OutWareNo,OutWareCheckYN,DutyPerson from KNet_Sales_OutWareList where OutWareNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                string s_DeptID = base.Base_GetNextDept(aa.ToString(), "102");//下一部门ID
                string s_DutyPerson = dr["DutyPerson"].ToString();
                if (dr["OutWareCheckYN"].ToString() == "True")
                {

                    if (base.Base_ShipIsDirectOut(aa.ToString()) != "已发货")
                    {
                        return "<a href=\"../Web/Sales/Sales_ShipWareOut_Add.aspx?ShipNo=" + aa + "\">" + base.Base_ShipIsDirectOut(aa.ToString()) + "</a>";
                    }
                    else
                    {
                        return "<font color=red>已发货</font>";
                    }
                }
                else
                {
                    if (Knet_Procure_OrdersList_Details_Shu2(aa.ToString()) <= 0)
                    {
                        return "<a href=\"../Web/Sales/Knet_Sales_Ship_Manage_AddDetails.aspx?OutWareNo=" + aa + "\"><img src=\"../images/Nodata.gif\"  border=\"0\"  title=\"未完成的发货单（没有明细记录）\" /></a>";
                    }
                    else
                    {

                        //责任人审批
                        if (s_DutyPerson != "")
                        {
                            this.BeginQuery("select * from KNet_Sales_Flow a join KNet_Resource_Staff b on a.KSF_ShPerson=b.StaffNo Where (KSF_State='1' or KSF_State='3')   and KSF_ContractNo='" + aa.ToString() + "'  and b.StaffNo='" + s_DutyPerson + "' and KSF_Del='0'");
                            this.QueryForDataTable();
                            if ((this.Dtb_Result.Rows.Count <= 0) && (AM.KNet_StaffNo == s_DutyPerson))
                            {
                                string JSD = "../Web/Sales/pop/Knet_Sales_ShipCheckYN.aspx?OutWareNo=" + aa.ToString() + "";
                                string StrPop = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=600,height=500');\"  title=\"点击进行审核操作\">审核</a><br/>等待 <font color=red>" + base.Base_GetUserName(s_DutyPerson) + "</font> 审核";
                                return StrPop;
                            }
                            else if ((this.Dtb_Result.Rows.Count <= 0) && (AM.KNet_StaffNo != s_DutyPerson))
                            {
                                string JSD = "../Web/Sales/pop/Knet_Sales_ShipCheckDetail.aspx?OutWareNo=" + aa.ToString() + "";
                                string StrPop = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=600,height=500');\"  title=\"点击进行审核操作\">查看</a><br/>等待 <font color=red>" + base.Base_GetUserName(s_DutyPerson) + "</font> 审核";
                                return StrPop;
                            }
                        }


                        this.BeginQuery("Select Top 1 * from KNet_Sales_Flow Where KFS_Type='1' and KSF_ContractNo='" + aa.ToString() + "' Order by KSF_Date Desc ");
                        this.QueryForDataTable();
                        if (this.Dtb_Result.Rows.Count > 0)
                        {
                            if (this.Dtb_Result.Rows[0]["KFS_NextPerson"].ToString() != "")//如果有指定
                            {
                                if (AM.KNet_StaffNo != this.Dtb_Result.Rows[0]["KFS_NextPerson"].ToString())
                                {

                                    string JSD = "../Web/Sales/pop/Knet_Sales_ShipCheckDetail.aspx?OutWareNo=" + aa.ToString() + "";
                                    string StrPop = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=600,height=500');\"  title=\"点击进行审核操作\">查看</a><br/>等待 <font color=red>" + base.Base_GetUserName(this.Dtb_Result.Rows[0]["KFS_NextPerson"].ToString()) + "</font> 审核";
                                    return StrPop;
                                }
                                else
                                {
                                    string JSD = "../Web/Sales/pop/Knet_Sales_ShipCheckYN.aspx?OutWareNo=" + aa.ToString() + "";
                                    string StrPop = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=600,height=500');\"  title=\"点击进行审核操作\">审核</a><br/>等待 <font color=red>" + base.Base_GetUserName(this.Dtb_Result.Rows[0]["KFS_NextPerson"].ToString()) + "</font> 审核";
                                    return StrPop;
                                }
                            }
                            else
                            {

                                if ((s_DeptID != "") && (AM.KNet_StaffDepart == s_DeptID))
                                {
                                    string JSD = "../Web/Sales/pop/Knet_Sales_ShipCheckYN.aspx?OutWareNo=" + aa.ToString() + "";
                                    string StrPop = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=600,height=500');\"  title=\"点击进行审核操作\">审核</a><br/>等待 <font color=red>" + base.Base_GeDept(s_DeptID) + "</font> 审核";
                                    return StrPop;
                                }
                                else
                                {
                                    string JSD = "../Web/Sales/pop/Knet_Sales_ShipCheckDetail.aspx?OutWareNo=" + aa.ToString() + "";
                                    string StrPop = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=600,height=500');\"  title=\"点击进行审核操作\">查看</a><br/>等待 <font color=red>" + base.Base_GeDept(s_DeptID) + "</font> 审核";
                                    return StrPop;
                                }

                            }
                        }
                        else
                        {
                            return "";
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



    /// <summary>
    /// 获取单明细数目 （Y）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected int Knet_Procure_OrdersList_Details_Shu2(string OutWareNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select count(*) as IDS  from KNet_Sales_OutWareList_Details where OutWareNo='" + OutWareNo + "'";
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
    /// 返回审核情况（Y）
    /// </summary>
    /// <param name="aa"></param>   
    /// <returns></returns>
    protected string GetBaoPriceCheckYN(object aa)
    {


        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            AdminloginMess AM = new AdminloginMess();
            conn.Open();
            string Dostr = "select ID,ContractNo,ContractCheckYN,DutyPerson from KNet_Sales_ContractList where ContractNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string s_DutyPerson = dr["DutyPerson"].ToString();
                if (dr["ContractCheckYN"].ToString() == "True")
                {
                    return "<img src=\"../../images/gou.gif\"  border=\"0\" />";
                }
                else
                {
                    if (Knet_Procure_OrdersList_Details_Shu(aa.ToString()) <= 0)
                    {
                        return "<a href=\"../Web/Sales/KNet_Sales_ContractList_Manage_AddDetails.aspx?ContractNo=" + aa + "\"><img src=\"../../images/Nodata.gif\"  border=\"0\"  title=\"未完成的合同单（没有明细记录）\" /></a>";
                    }
                    else
                    {
                        string s_DeptID = Base_GetNextDept(aa.ToString(),"101");
                     
                        this.BeginQuery("select * from KNet_Sales_Flow a join KNet_Resource_Staff b on a.KSF_ShPerson=b.StaffNo Where KSF_State='0'   and KSF_ContractNo='" + aa.ToString() + "' and StaffDepart='" + s_DeptID + "' and KSF_Del='0'");
                        this.QueryForDataTable();
                        string JSD = "../Web/Sales/pop/ContractListCheckYN.aspx?ContractNo=" + aa.ToString() + "&Type=1";
                        string StrPop = "";
                        if (this.Dtb_Result.Rows.Count > 0)
                        {
                            JSD = "../Web/Sales/pop/ContractListCheckDetail.aspx?ContractNo=" + aa.ToString() + "&Type=1";
                            StrPop = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=700,height=450');\"  title=\"点击进行审核操作\">查看</a><br/> " + base.Base_GeDept(s_DeptID) + " <font color=Blue>不通过</font>";

                            return StrPop;

                        }
                        //责任人审批
                        if (s_DutyPerson!="")
                        {

                            this.BeginQuery("select * from KNet_Sales_Flow a join KNet_Resource_Staff b on a.KSF_ShPerson=b.StaffNo Where (KSF_State='1' or KSF_State='3')   and KSF_ContractNo='" + aa.ToString() + "'  and b.StaffNo='" + s_DutyPerson + "' and KSF_Del='0'");
                            this.QueryForDataTable();
                            if ((this.Dtb_Result.Rows.Count <= 0) && (AM.KNet_StaffNo == s_DutyPerson))
                            {
                                StrPop = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=700,height=450');\"  title=\"点击进行审核操作\">审核</a><br/>等待 <font color=red>" + base.Base_GetUserName(s_DutyPerson) + "</font> 审核";

                                return StrPop;
                            }
                            else if ((this.Dtb_Result.Rows.Count <= 0) && (AM.KNet_StaffNo != s_DutyPerson))
                            {
                                JSD = "../Web/Sales/pop/ContractListCheckDetail.aspx?ContractNo=" + aa.ToString() + "&Type=1";
                                return "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=700,height=450');\"  title=\"点击进行审核操作\">查看</a><br/>等待 " + base.Base_GetUserName(s_DutyPerson) + " 审核";

                            }
                        }
                        //下个审批部门
                         if ((s_DeptID == AM.KNet_StaffDepart) && (AM.KNet_Position == "102"))
                        {

                            StrPop = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=700,height=450');\"  title=\"点击进行审核操作\">审核</a><br/>等待  <font color=red>" + base.Base_GeDept(s_DeptID) + "</font> 审核";

                            return StrPop;

                        }
                        else
                        {
                            JSD = "../Web/Sales/pop/ContractListCheckDetail.aspx?ContractNo=" + aa.ToString() + "";
                            return "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=700,height=450');\"  title=\"点击进行审核操作\">查看</a><br/>等待 " + base.Base_GeDept(s_DeptID) + " 审核";
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


    /// <summary>
    /// 获取单明细数目 （Y）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected int Knet_Procure_OrdersList_Details_Shu(string ContractNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select count(*) as IDS  from KNet_Sales_ContractList_Details where ContractNo='" + ContractNo + "'";
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
                        Str = "<img src=\"../../images/fin.gif\" alt=\"采购单已完成\" width=\"15\" height=\"15\" border=\"0\" />";
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
            string Dostr = "select ID,OrderNo,OrderState,OrderCheckYN from Knet_Procure_OrdersList where OrderNo='" + aa + "' and  OrderState!=2";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["OrderCheckYN"].ToString() == "True")
                {
                    return "<img src=\"../images/gou.gif\"  border=\"0\" />";
                }
                else
                {
                    if (Knet_Procure_OrdersList_Details_Shu1(aa.ToString()) <= 0)
                    {
                        return "<a href=\"../Web/Procure/Knet_Procure_OpenBilling_AddDetails.aspx?OrderNo=" + aa + "\"><img src=\"../images/Nodata.gif\"  border=\"0\"  title=\"未完成的采购单（没有明细记录）\" /></a>";
                    }
                    else
                    {
                        string JSD = "../Web/Procure/pop/Knet_Procure_OpenBillingCheckYN.aspx?OrderNo=" + aa.ToString() + "";
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

    /// <summary>
    /// 获取采购单明细数目
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected int Knet_Procure_OrdersList_Details_Shu1(string OrderNo)
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
    /// 返回发货跟踪 最新一条记录（Y）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetOutWareListfollowup(object OutWareNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select top 1 ID,FollowNo,OutWareNo,FollowDateTime,FollowStaffNo,FollowText,FollowEnd from KNet_Sales_OutWareList_FlowList where OutWareNo='" + OutWareNo + "' order by FollowDateTime desc";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["FollowEnd"].ToString() == "True")
                {
                    return "<img src=\"../images/takman.gif\" width=\"11\" height=\"14\" border=\"0\" /><a href=\"#\" style=\"line-height: 22px;\" onclick=\"lhgdialog.opendlg('发货单号:<font color=Red>" + OutWareNo + "</font> 跟踪', '../Sales/Knet_Sales_Ship_Manage_Talks_List.aspx?OutWareNo=" + OutWareNo + "', 780, 400,false,false);\">" + KNetPage.CutString(dr["FollowText"].ToString().Trim(), 40) + "</a><br>&nbsp;&nbsp;<font color=\"gray\">" + base.Base_GetUserName(dr["FollowStaffNo"].ToString()) + "&nbsp;(" + dr["FollowDateTime"].ToString() + ")</font>&nbsp;<<font color=red>结束</font>>";
                }
                else
                {
                    return "<img src=\"../images/takman.gif\" width=\"11\" height=\"14\" border=\"0\" /><a href=\"#\" style=\"line-height: 22px;\" onclick=\"lhgdialog.opendlg('发货单号:<font color=Red>" + OutWareNo + "</font> 跟踪', '../Sales/Knet_Sales_Ship_Manage_Talks_List.aspx?OutWareNo=" + OutWareNo + "', 780, 400,false,false);\">" + KNetPage.CutString(dr["FollowText"].ToString().Trim(), 40) + "</a><br>&nbsp;&nbsp;<font color=\"gray\">" + base.Base_GetUserName(dr["FollowStaffNo"].ToString()) + "&nbsp;(" + dr["FollowDateTime"].ToString() + ")</font>&nbsp;<img src=\"../images/45.gif\" width=\"11\" height=\"11\" border=\"0\" /><a href=\"#\" onclick=\"lhgdialog.opendlg('发货单号:<font color=Red>" + OutWareNo + "</font> 跟踪', '../Sales/Knet_Sales_Ship_Manage_Talks_Add.aspx?OutWareNo=" + OutWareNo + "', 780, 400,false,false);\">添加</a>";
                }
            }
            else
            {
                return "<font color=\"gray\">暂无相关发货跟踪信息....</font>&nbsp;&nbsp;<img src=\"../images/45.gif\" width=\"11\" height=\"11\" border=\"0\" /><a href=\"#\" onclick=\"lhgdialog.opendlg('发货单号:<font color=Red>" + OutWareNo + "</font> 跟踪', '../Sales/Knet_Sales_Ship_Manage_Talks_Add.aspx?OutWareNo=" + OutWareNo + "', 780, 400,false,false);\">添加</a>";
            }
        }
    }

    // <summary>
    // 查库存是否有需要发货的产品
    // </summary>
    // <param name="DoSQL"></param>
    // <returns></returns>
    protected string IsShipYN()
    {
        AdminloginMess AM = new AdminloginMess();
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  Count(*)");
            strSql.Append(" FROM KNet_Sales_ContractList_Details a join KNet_Sales_ContractList b on a.ContractNo=b.ContractNo ");
            strSql.Append(" where  DateDiff(dd,b.ContractToDeliDate,'" + DateTime.Now.ToShortDateString() + "')<=3 and  b.ContractToDeliDate<= dateadd(day,3,'" + DateTime.Now.ToShortDateString() + "') ");
            using (SqlCommand cmd = new SqlCommand(strSql.ToString(), conn))
            {
                SqlDataReader DR = cmd.ExecuteReader();
                if (DR.Read())
                {
                    return DR[0].ToString();
                }
                else
                {
                    return "";
                }
            }
        }
    }


    /// <summary>
    /// MSN提醒
    /// </summary>
    /// <returns></returns>
    protected void MSNfunction(string ComName, string GetUrl, string s_Title, string s_Details, string s_UrlDetails)
    {
        string Src = "";
        Src += "<html>\n";
        Src += "<head>\n";
        Src += "<title>" + ComName + "</title>\n";
        Src += "</head>\n";
        Src += "<body scroll=no topmargin=\"0\" leftmargin=\"0\" rightmargin=\"0\">\n";
        Src += "<script language=\"JavaScript\">\n";
        Src += "window.onload = getMsg;\n";
        Src += "window.onresize = resizeDiv;\n";
        Src += "window.onerror = function(){}\n";
        Src += "var divTop,divLeft,divWidth,divHeight,docHeight,docWidth,objTimer,i = 0;\n";
        Src += "function getMsg()\n";
        Src += "{\n";
        Src += "try{\n";
        Src += "divTop = parseInt(document.getElementById(\"eMeng\").style.top,10)\n";
        Src += "divLeft = parseInt(document.getElementById(\"eMeng\").style.left,10)\n";
        Src += "divHeight = parseInt(document.getElementById(\"eMeng\").offsetHeight,10)\n";
        Src += "divWidth = parseInt(document.getElementById(\"eMeng\").offsetWidth,10)\n";
        Src += "docWidth = document.body.clientWidth;\n";
        Src += "docHeight = document.body.clientHeight;\n";
        Src += "document.getElementById(\"eMeng\").style.top = parseInt(document.body.scrollTop,10) + docHeight + 10;\n";
        Src += "document.getElementById(\"eMeng\").style.left = parseInt(document.body.scrollLeft,10) + docWidth - divWidth\n";
        Src += "document.getElementById(\"eMeng\").style.visibility=\"visible\"\n";
        Src += "objTimer = window.setInterval(\"moveDiv()\",10)\n";
        Src += "}\n";
        Src += "catch(e){}\n";
        Src += "}\n";
        Src += "function resizeDiv()\n";
        Src += "{\n";
        Src += "i+=1\n";
        Src += "if(i>1500) closeDiv()\n";
        Src += "try{\n";
        Src += "divHeight = parseInt(document.getElementById(\"eMeng\").offsetHeight,10)\n";
        Src += "divWidth = parseInt(document.getElementById(\"eMeng\").offsetWidth,10)\n";
        Src += "docWidth = document.body.clientWidth;\n";
        Src += "docHeight = document.body.clientHeight;\n";
        Src += "document.getElementById(\"eMeng\").style.top = docHeight - divHeight + parseInt(document.body.scrollTop,10)\n";
        Src += "document.getElementById(\"eMeng\").style.left = docWidth - divWidth + parseInt(document.body.scrollLeft,10)\n";
        Src += "}\n";
        Src += "catch(e){}\n";
        Src += "}\n";
        Src += "function moveDiv()\n";
        Src += "{\n";
        Src += "try\n";
        Src += "{\n";
        Src += "if(parseInt(document.getElementById(\"eMeng\").style.top,10) <= (docHeight - divHeight + parseInt(document.body.scrollTop,10)))\n";
        Src += "{\n";
        Src += "window.clearInterval(objTimer)\n";
        Src += "objTimer = window.setInterval(\"resizeDiv()\",1)\n";
        Src += "}\n";
        Src += "divTop = parseInt(document.getElementById(\"eMeng\").style.top,10)\n";
        Src += "document.getElementById(\"eMeng\").style.top = divTop - 1\n";
        Src += "}\n";
        Src += "catch(e){}\n";
        Src += "}\n";
        Src += "function closeDiv()\n";
        Src += "{\n";
        Src += "document.getElementById(\'eMeng\').style.visibility=\'hidden\';\n";
        Src += "if(objTimer) window.clearInterval(objTimer)\n";
        Src += "}\n";
        Src += "</script>\n";
        Src += "<DIV id=eMeng style=\"BORDER-RIGHT: #455690 1px solid; BORDER-TOP: #a6b4cf 1px solid; Z-INDEX:99999; LEFT: 0px; VISIBILITY: hidden; BORDER-LEFT: #a6b4cf 1px solid; WIDTH: 180px; BORDER-BOTTOM: #455690 1px solid; POSITION: absolute; TOP: 0px; HEIGHT: 116px; BACKGROUND-COLOR: #c9d3f3\">\n";
        Src += "<TABLE style=\"BORDER-TOP: #ffffff 1px solid; BORDER-LEFT: #ffffff 1px solid\" cellSpacing=0 cellPadding=0 width=\"100%\" bgColor=#cfdef4 border=0>\n";
        Src += "<TBODY>\n";
        Src += "<TR>\n";
        Src += "<TD style=\"FONT-SIZE: 12px; BACKGROUND-IMAGE: url(msgTopBg.gif); COLOR: #0f2c8c\" width=30 height=24></TD>\n";
        Src += "<TD style=\"FONT-WEIGHT: normal; FONT-SIZE: 12px; BACKGROUND-IMAGE: url(msgTopBg.gif); COLOR: #1f336b; PADDING-TOP: 4px;PADDING-left: 4px\" vAlign=center width=\"100%\">" + s_Title + "</TD>\n";
        Src += "<TD style=\"BACKGROUND-IMAGE: url(msgTopBg.gif); PADDING-TOP: 2px;PADDING-right:2px\" vAlign=center align=right width=19><span title=关闭 style=\"CURSOR: hand;color:red;font-size:12px;font-weight:bold;margin-right:4px;\" onclick=closeDiv() >×</span></TD>\n";
        Src += "</TR>\n";
        Src += "<TR>\n";
        Src += "<TD style=\"PADDING-RIGHT: 1px; BACKGROUND-IMAGE: url(1msgBottomBg.jpg); PADDING-BOTTOM: 1px\" colSpan=3 height=90>\n";
        Src += "<DIV style=\"BORDER-RIGHT: #b9c9ef 1px solid; PADDING-RIGHT: 13px; BORDER-TOP: #728eb8 1px solid; PADDING-LEFT: 13px; FONT-SIZE: 12px; PADDING-BOTTOM: 13px; BORDER-LEFT: #728eb8 1px solid; WIDTH: 100%; COLOR: #1f336b; PADDING-TOP: 18px; BORDER-BOTTOM: #b9c9ef 1px solid; HEIGHT: 100%\">" + s_Details + "<br><br>\n";
        Src += "<DIV align=center style=\"word-break:break-all\"><a href=\"" + GetUrl + "\" target=\"main\"><font color=#FF0000>" + s_UrlDetails + "</font></a></DIV>\n";
        Src += "</DIV>\n";
        Src += "</TD>\n";
        Src += "</TR>\n";
        Src += "</TBODY>\n";
        Src += "</TABLE>\n";
        Src += "</DIV>\n";
        Src += "</body>\n";
        Src += "</html>\n";
        Response.Write(Src);
    }



    protected void Ltn_Contract_Click(object sender, EventArgs e)
    {
        if (this.Pan_Contract.Visible == false)
        {
            this.Pan_Contract.Visible = true;
            this.Ltn_Ship.Visible = false;
            this.Ltn_Order.Visible = false;
            this.Lbl_Cotracted.Visible = false;
            this.Ltn_SalesReturn.Visible = false;
            this.Ltn_Return.Visible = false;
            this.Ltn_RkNotShip.Visible = false;
        }
        else
        {
            this.Pan_Contract.Visible = false;
            this.Ltn_Ship.Visible = true;
            this.Ltn_Order.Visible = true;
            this.Lbl_Cotracted.Visible = true;
            this.Ltn_SalesReturn.Visible = true;
            this.Ltn_Return.Visible = true;
            this.Ltn_RkNotShip.Visible = true;
        }
    }

    protected void Ltn_Ship_Click(object sender, EventArgs e)
    {
        if (this.Pan_Ship.Visible == false)
        {
            this.Pan_Ship.Visible = true;
            this.Ltn_Contract.Visible = false;
            this.Ltn_Order.Visible = false;
            this.Lbl_Cotracted.Visible = false;
            this.Ltn_SalesReturn.Visible = false;
            this.Ltn_Return.Visible = false;
            this.Ltn_RkNotShip.Visible = false;
        }
        else
        {
            this.Pan_Ship.Visible = false;
            this.Ltn_Contract.Visible = true;
            this.Ltn_Order.Visible = true;
            this.Lbl_Cotracted.Visible = true;
            this.Ltn_SalesReturn.Visible = true;
            this.Ltn_Return.Visible = true;
            this.Ltn_RkNotShip.Visible = true;
        }
    }

    protected void Ltn_Order_Click(object sender, EventArgs e)
    {
        if (this.Pan_Order.Visible == false)
        {
            this.Pan_Order.Visible = true;

            this.Ltn_Contract.Visible = false;
            this.Ltn_Ship.Visible = false;
            this.Lbl_Cotracted.Visible = false;
            this.Ltn_SalesReturn.Visible = false;
            this.Ltn_Return.Visible = false;
            this.Ltn_RkNotShip.Visible = false;
        }
        else
        {
            this.Pan_Order.Visible = false;
            this.Ltn_Contract.Visible = true;
            this.Ltn_Ship.Visible = true;
            this.Lbl_Cotracted.Visible = true;
            this.Ltn_SalesReturn.Visible = true;
            this.Ltn_Return.Visible = true;

            this.Ltn_RkNotShip.Visible = true;
        }
    }

    protected void Lbl_Cotracted_Click(object sender, EventArgs e)
    {
        if (this.Pan_Cotracted.Visible == false)
        {
            this.Pan_Cotracted.Visible = true;
            this.Ltn_Contract.Visible = false;
            this.Ltn_Ship.Visible = false;
            this.Ltn_Order.Visible = false;

            this.Ltn_SalesReturn.Visible = false;
            this.Ltn_Return.Visible = false;
            this.Ltn_RkNotShip.Visible = false;
        }
        else
        {
            this.Pan_Cotracted.Visible = false;
            this.Ltn_Contract.Visible = true;
            this.Ltn_Ship.Visible = true;
            this.Ltn_Order.Visible = true;
            this.Ltn_SalesReturn.Visible = true;

            this.Ltn_SalesReturn.Visible = true;
            this.Ltn_Return.Visible = true;
            this.Ltn_RkNotShip.Visible = true;
        }
    }

    protected void Ltn_Return_Click(object sender, EventArgs e)
    {
        if (this.Pan_Return.Visible == false)
        {


            this.Pan_Return.Visible = true;

            this.Lbl_Cotracted.Visible = false;
            this.Ltn_Contract.Visible = false;
            this.Ltn_Ship.Visible = false;
            this.Ltn_Order.Visible = false;
            this.Ltn_SalesReturn.Visible = false;
            this.Ltn_RkNotShip.Visible = false;
        }
        else
        {
            this.Pan_Return.Visible = false;

            this.Lbl_Cotracted.Visible = true;
            this.Ltn_Contract.Visible = true;
            this.Ltn_Ship.Visible = true;
            this.Ltn_Order.Visible = true;

            this.Ltn_SalesReturn.Visible = true;
            this.Ltn_RkNotShip.Visible = true;

        }
    }

    protected void Ltn_SalesReturn_Click(object sender, EventArgs e)
    {
        if (this.Pan_SalesReturn.Visible == false)
        {


            this.Pan_SalesReturn.Visible = true;

            this.Lbl_Cotracted.Visible = false;
            this.Ltn_Contract.Visible = false;
            this.Ltn_Ship.Visible = false;
            this.Ltn_Order.Visible = false;

            this.Ltn_Return.Visible = false;
            this.Ltn_RkNotShip.Visible = false;
        }
        else
        {
            this.Pan_SalesReturn.Visible = false;

            this.Lbl_Cotracted.Visible = true;
            this.Ltn_Contract.Visible = true;
            this.Ltn_Ship.Visible = true;
            this.Ltn_Order.Visible = true;

            this.Ltn_Return.Visible = true;
            this.Ltn_RkNotShip.Visible = true;
            
        }
    }


    protected void Ltn_RkNotShip_Click(object sender, EventArgs e)
    {
        if (this.Pan_RkNotShip.Visible == false)
        {

            this.Pan_RkNotShip.Visible = true;


            this.Lbl_Cotracted.Visible = false;
            this.Ltn_Contract.Visible = false;
            this.Ltn_Ship.Visible = false;
            this.Ltn_Order.Visible = false;
            this.Ltn_Return.Visible = false;

            this.Ltn_SalesReturn.Visible = false;
        }
        else
        {
            this.Pan_RkNotShip.Visible = false;

            this.Lbl_Cotracted.Visible = true;
            this.Ltn_Contract.Visible = true;
            this.Ltn_Ship.Visible = true;
            this.Ltn_Order.Visible = true;

            this.Ltn_Return.Visible = true;
            this.Ltn_SalesReturn.Visible = true;
        }
    }
    
    
    
}
