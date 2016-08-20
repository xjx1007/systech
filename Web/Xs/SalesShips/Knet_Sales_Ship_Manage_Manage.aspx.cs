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
using System.Runtime.Serialization.Json;

using KNet.DBUtility;
using KNet.Common;
using System.Net;

/// <summary>
/// 销售管理-----发货单 管理
/// </summary>
public partial class Knet_Web_Sales_Knet_Sales_Ship_Manage_Manage : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            
        string s_ContractNo = Request.QueryString["ContractNo"] == null ? "" : Request.QueryString["ContractNo"].ToString();
        this.Tbx_ContractNo.Text = s_ContractNo;



            this.Btn_Del.Attributes.Add("onclick", "return confirm('你确信要删除所选记录吗?！\\n\\n注意：该删除会同时删除发货单产品明细记录.')");

            this.DataShows();
            this.RowOverYN();
            
           
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
        KNet.BLL.KNet_Sales_OutWareList bll = new KNet.BLL.KNet_Sales_OutWareList();

        string SqlWhere = " 1=1 ";


        if (this.StartDate.Text != "")
        {
            SqlWhere = SqlWhere + " and  OutWareDateTime >= '" + this.StartDate.Text + "' ";
        }

        if (this.EndDate.Text != "")
        {
            SqlWhere = SqlWhere + " and  OutWareDateTime<='" + this.EndDate.Text + "'";
        }

        if (this.Tbx_Customer.Text != "")
        {
            SqlWhere = SqlWhere + " and CustomerValue in (Select CustomerValue from [KNet_Sales_ClientList] where CustomerName like '%" + this.Tbx_Customer.Text + "%') ";
        }
        if (this.Tbx_ContractNo.Text != "")
        {

            SqlWhere += "and ContractNo='" + this.Tbx_ContractNo.Text + "'";
        }
        SqlWhere = SqlWhere + " order by SystemDateTimes desc";

        DataSet ds = bll.GetList(SqlWhere);
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "OutWareNo" };
        GridView1.DataBind();

    }


    /// <summary>
    /// 执行分页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void AspNetPager1_PageChanged(object src, EventArgs e)
    {
        this.DataShows();
        this.RowOverYN();
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
            string ContractNo = GridView1.DataKeys[e.Row.RowIndex].Value.ToString(); //获取ID值
            CheckBox cb = (CheckBox)e.Row.Cells[1].FindControl("Chbk");
            if (GetReceivCheckYNEitxt(ContractNo) == true)
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
    /// 查看 发货单 是否已审核
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected bool GetReceivCheckYNEitxt(string OutWareNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,OutWareCheckYN,OutWareNo from KNet_Sales_OutWareList where OutWareNo='" + OutWareNo + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["OutWareCheckYN"].ToString() == "True")
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
    /// 返回关联合同唯一值
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetContractNo(object OutWareNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,ContractNo,OutWareNo from KNet_Sales_OutWareList where OutWareNo='" + OutWareNo + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["ContractNo"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }


    /// <summary>
    /// 返回采购公司名称（Y）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetStrucNameNane(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,StrucValue,StrucName from KNet_Resource_OrganizationalStructure where StrucValue='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["StrucName"].ToString().Trim();
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
    protected int Knet_Procure_OrdersList_Details_Shu(string OutWareNo)
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
                    string s_State=base.Base_ShipIsDirectOut(aa.ToString());
                    if ((s_State != "已多发货")&&(s_State!="正常发货"))
                    {
                        return "<a href=\"Sales_ShipWareOut_Add.aspx?ShipNo=" + aa + "\">" + s_State + "</a>";
                    }
                    else
                    {
                        return s_State;
                    }
                }
                else
                {
                    if (Knet_Procure_OrdersList_Details_Shu(aa.ToString()) <= 0)
                    {
                        return "<a href=\"Knet_Sales_Ship_Manage_AddDetails.aspx?OutWareNo=" + aa + "\"><img src=\"../images/Nodata.gif\"  border=\"0\"  title=\"未完成的发货单（没有明细记录）\" /></a>";
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
                                string JSD = "pop/Knet_Sales_ShipCheckYN.aspx?OutWareNo=" + aa.ToString() + "";
                                string StrPop = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=600,height=500');\"  title=\"点击进行审核操作\">审核</a><br/>等待 <font color=red>" + base.Base_GetUserName(s_DutyPerson) + "</font> 审核";
                                return StrPop;
                            }
                            else if ((this.Dtb_Result.Rows.Count <= 0) && (AM.KNet_StaffNo != s_DutyPerson))
                            {
                                string JSD = "pop/Knet_Sales_ShipCheckDetail.aspx?OutWareNo=" + aa.ToString() + "";
                                string StrPop = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=600,height=500');\"  title=\"点击进行审核操作\">查看</a>&nbsp;&nbsp;";

                                if (AM.KNet_StaffDepart == "129652784259578018")//物料部
                                {
                                    StrPop += "<a href=\"Sales_ShipWareOut_Add.aspx?ShipNo=" + aa + "\">发货</a>";
                                }
                                StrPop += "<br/>等待 <font color=red>" + base.Base_GetUserName(s_DutyPerson) + "</font> 审核";
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

                                    string JSD = "pop/Knet_Sales_ShipCheckDetail.aspx?OutWareNo=" + aa.ToString() + "";
                                    string StrPop = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=600,height=500');\"  title=\"点击进行审核操作\">查看</a>&nbsp;&nbsp;";

                                    if (AM.KNet_StaffDepart == "129652784259578018")//物料部
                                    {
                                        StrPop += "<a href=\"Sales_ShipWareOut_Add.aspx?ShipNo=" + aa + "\">发货</a>";
                                    }
                                    StrPop += "<br/>等待 <font color=red>" + base.Base_GetUserName(this.Dtb_Result.Rows[0]["KFS_NextPerson"].ToString()) + "</font> 审核";
                                    return StrPop;
                                }
                                else
                                {
                                    string JSD = "pop/Knet_Sales_ShipCheckYN.aspx?OutWareNo=" + aa.ToString() + "";
                                    string StrPop = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=600,height=500');\"  title=\"点击进行审核操作\">审核</a>&nbsp;&nbsp;";

                                    if (AM.KNet_StaffDepart == "129652784259578018")//物料部
                                    {
                                        StrPop += "<a href=\"Sales_ShipWareOut_Add.aspx?ShipNo=" + aa + "\">发货</a>";
                                    }
                                    StrPop += "<br/>等待 <font color=red>" + base.Base_GetUserName(this.Dtb_Result.Rows[0]["KFS_NextPerson"].ToString()) + "</font> 审核";
                                    return StrPop;
                                }
                            }
                            else
                            {

                                if ((s_DeptID != "") && (AM.KNet_StaffDepart == s_DeptID))
                                {
                                    string JSD = "pop/Knet_Sales_ShipCheckYN.aspx?OutWareNo=" + aa.ToString() + "";
                                    string StrPop = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=600,height=500');\"  title=\"点击进行审核操作\">审核</a>&nbsp;&nbsp;";

                                    if (AM.KNet_StaffDepart == "129652784259578018")//物料部
                                    {
                                        StrPop += "<a href=\"Sales_ShipWareOut_Add.aspx?ShipNo=" + aa + "\">发货</a>";
                                    }
                                    StrPop += "<br/>等待 <font color=red>" + base.Base_GeDept(s_DeptID) + "</font> 审核";
                                    return StrPop;
                                }
                                else
                                {
                                    string JSD = "pop/Knet_Sales_ShipCheckDetail.aspx?OutWareNo=" + aa.ToString() + "";
                                    string StrPop = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=600,height=500');\"  title=\"点击进行审核操作\">查看</a>&nbsp;&nbsp;";

                                    if (AM.KNet_StaffDepart == "129652784259578018")//物料部
                                    {
                                        StrPop += "<a href=\"Sales_ShipWareOut_Add.aspx?ShipNo=" + aa + "\">发货</a>";
                                    }
                                    StrPop += "<br/>等待 <font color=red>" + base.Base_GeDept(s_DeptID) + "</font> 审核";
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
        DataTable Dtb_DataTable = this.Dtb_Result;
        if (Dtb_DataTable.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_DataTable.Rows.Count; i++)
            {
                string s_KDName = Dtb_DataTable.Rows[i]["KDName"].ToString();
                string s_Code = Dtb_DataTable.Rows[i]["KDCode"].ToString();
                string s_CodeName = Dtb_DataTable.Rows[i]["KDCodeName"].ToString();
                string s_ID = Dtb_DataTable.Rows[i]["ID"].ToString();
                string s_State = Dtb_DataTable.Rows[i]["State"] == null ? "" : Dtb_DataTable.Rows[i]["State"].ToString();
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
                s_Rturn += "<a href=\"#\"  onclick=\"javascript:window.open('Knet_Sales_Ship_Manage_Talks_Detail.aspx?com=" + s_KDName + "&Code=" + s_Code + "&Name=" + s_CodeName + "','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=580,height=250');\">" + s_Code;

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
            wr_req.Timeout = 50;
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

    protected void Btn_Del_Click(object sender, EventArgs e)
    {

        string sql = "delete from KNet_Sales_OutWareList where"; //删除发货单
        string sql2 = "delete from KNet_Sales_OutWareList_Details where"; //发货 明细
        string sql3 = "";//更新合同状态

        string cal = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
            TextBox Tbx_ContractNo = (TextBox)GridView1.Rows[i].Cells[0].FindControl("ContractNo");
            if (cb.Checked == true)
            {
                cal += " OutWareNo='" + GridView1.DataKeys[i].Value.ToString() + "' or";
                sql3 += "Update KNet_Sales_ContractList set ContractState=1 where ContractNo='" + Tbx_ContractNo.Text + "' ";
                sql3 += " Update Knet_Procure_WareHouseList set isship='1' where WareHouseNo in (Select KSO_WareHouseNo from KNet_Sales_OutWareList where OutWareNo='" + GridView1.DataKeys[i].Value.ToString() + "') ";

                KNet.BLL.KNet_Sales_OutWareList_Details BLL = new KNet.BLL.KNet_Sales_OutWareList_Details();
                DataSet ds = BLL.GetList(" OutWareNo='" + GridView1.DataKeys[i].Value.ToString() + "' ");

                for (int j = 0; j <= ds.Tables[0].Rows.Count - 1; j++)
                {
                    DataRowView mydrv = ds.Tables[0].DefaultView[j];

                    string ID = mydrv["ID"].ToString();
                    string ProductsBarCode = mydrv["ProductsBarCode"].ToString();
                    string ContractNo = GetContractNo(GridView1.DataKeys[i].Value.ToString());

                    try
                    {

                        string DoSqlOrder = " update KNet_Sales_ContractList set ContractState=1 where ContractNo='" + ContractNo + "'";
                        DbHelperSQL.ExecuteSql(DoSqlOrder);
                        BLL.Delete(ID, ContractNo, ProductsBarCode);
                    }
                    catch
                    { }
                }
            }
        }
        if (cal != "")
        {
            sql += cal.Substring(0, cal.Length - 3);
            sql2 += cal.Substring(0, cal.Length - 3);
        }
        else
        {
            sql = "";       //不删除
            sql2 = "";       //不删除
            Response.Write("<script language=javascript>alert('您没有选择要删除的记录!');history.back(-1);</script>");
            Response.End();
        }

        DbHelperSQL.ExecuteSql(sql3);
        DbHelperSQL.ExecuteSql(sql);
        DbHelperSQL.ExecuteSql(sql2);

        AdminloginMess LogAM = new AdminloginMess();
        LogAM.Add_Logs("销售管理--->销售发货管理--->发货单删除 操作成功！");

        this.DataShows();
        this.RowOverYN();

    }


    /// <summary>
    /// 查合同单状态 是否完成
    /// </summary>
    /// <param name="OrderNo"></param>
    protected bool UpdateContractState(string ContractNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dosql = " select  (Sum(ContractAmount)-Sum(ContractReceiving)) as SSum from KNet_Sales_ContractList_Details where ContractNo='" + ContractNo + "'";
            SqlCommand cmd = new SqlCommand(Dosql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
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
            else
            {
                return false;
            }
        }
    }
    protected void Btn_Query_Click(object sender, EventArgs e)
    {
        
        this.DataShows();
        this.RowOverYN();
    }

    public string GetUpdate(string s_ContractNo, string s_contractStaffNo)
    {
        AdminloginMess AM = new AdminloginMess();

        if (AM.KNet_StaffNo != s_contractStaffNo)
        {
            return "<font color=red>不可修改</font>";
        }

        this.BeginQuery("select * from KNet_Sales_Flow a Where KSF_Del='0' and KSF_State='1' and  KSF_ContractNo='" + s_ContractNo + "'");
        this.QueryForDataTable();
        if ((this.Dtb_Result.Rows.Count <= 0))
        {
            return " <a href=\"Knet_Sales_Ship_Manage_AddDetails.aspx?OutWareNo=" + s_ContractNo + "&Css2=Div22\"><img id=\"Image1\" title=\"修改\" src=\"../../images/Edit.gif\" style=\"border-width:0px;\" /></a>";
        }

        string s_DeptID = Base_GetNextDept(s_ContractNo, "102");
        this.BeginQuery("select * from KNet_Sales_Flow a join KNet_Resource_Staff b on a.KSF_ShPerson=b.StaffNo Where KSF_State='0'   and KSF_ContractNo='" + s_ContractNo + "' and StaffDepart='" + s_DeptID + "'");
        this.QueryForDataTable();
        string JSD = "pop/ContractListCheckYN.aspx?ContractNo=" + s_ContractNo + "";
        string StrPop = "";
        if ((this.Dtb_Result.Rows.Count > 0))
        {
            return " <a href=\"Knet_Sales_Ship_Manage_AddDetails.aspx?OutWareNo=" + s_ContractNo + "&Css2=Div22\"><img id=\"Image1\" title=\"修改\" src=\"../../images/Edit.gif\" style=\"border-width:0px;\" /></a>";
        }
        else
        {
            return "<font color=red>不可修改</font>";
        }
    }
}
