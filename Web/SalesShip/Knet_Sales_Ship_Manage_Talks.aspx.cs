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
/// 销售管理-----发货单 管理
/// </summary>
public partial class Knet_Web_Sales_Knet_Sales_Ship_Manage_Talks : BasePage
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        KNet.DBUtility.AdminloginMess AMLanguage = new KNet.DBUtility.AdminloginMess();
        if (AMLanguage.KNet_Soft_StaffLanguage == 2)
        {
            // 1、默认为简体转繁体，编码为utf-8
            Response.Filter = new LU.Web.ChineseConvertor(Response.Filter);
        }
        else if (AMLanguage.KNet_Soft_StaffLanguage == 1)
        {
            // 2、繁体简体转，编码为utf-8
            Response.Filter = new LU.Web.ChineseConvertor(Response.Filter, LU.Web.ChineseConvertor.CCDirection.T2S);
        }
        else
        { }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("发货单跟踪") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }

            ViewState["SortOrder"] = "OutWareDateTime";
            ViewState["OrderDire"] = "Desc";

            this.DataShows();
        }

    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.KNet_Sales_OutWareList bll = new KNet.BLL.KNet_Sales_OutWareList();
        string LogtimeA = null;
        string LogtimeB = null;
        string KSeachKey = null;

        string SqlWhere = " 1=1 ";

        if (Request["LogtimeA"] != null && Request["LogtimeB"] != null && Request["LogtimeA"] != "" && Request["LogtimeB"] != "")
        {
            LogtimeA = Request.QueryString["LogtimeA"].ToString().Trim();
            if (LogtimeA == "") { LogtimeA = null; }
            this.StartDate.Text = LogtimeA;

        }
        if (Request["LogtimeB"] != null && Request["LogtimeA"] != null && Request["LogtimeB"] != "" && Request["LogtimeA"] != "")
        {
            LogtimeB = Request.QueryString["LogtimeB"].ToString().Trim();
            if (LogtimeB == "") { LogtimeB = null; }
            this.EndDate.Text = LogtimeB;

            SqlWhere = SqlWhere + " and ( OutWareDateTime >= '" + LogtimeA + "' and  OutWareDateTime<='" + LogtimeB + "'   ) ";
        }
        if (Request["SeachKey"] != null && Request["SeachKey"] !="")
        {
            KSeachKey = Request.QueryString["SeachKey"].ToString().Trim();
            if (KSeachKey == "") { KSeachKey = null; }
            this.SeachKey.Text = KSeachKey;

            SqlWhere = SqlWhere + " and ( OutWareTopic like '%" + KSeachKey + "%' or OutWareNo  like '%" + KSeachKey + "%' or OutWareOursContact like '%" + KSeachKey + "%' or OutWareSideContact like '%" + KSeachKey + "%' )";
        }

        using (DataSet ds = bll.GetList(SqlWhere))
        {
            //正反排序------
            DataView dv = ds.Tables[0].DefaultView;
            string sort = (string)ViewState["SortOrder"] + " " + (string)ViewState["OrderDire"];
            dv.Sort = sort;
            //--分页-------
            PagedDataSource pds = new PagedDataSource();
            AspNetPager1.RecordCount = dv.Count;
            pds.DataSource = dv;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;
            //--End分页-----
            GridView1.DataSource = pds;
            GridView1.DataKeyNames = new string[] { "OutWareNo" };
            GridView1.DataBind();

        }
    }

    /// <summary>
    /// 正反排序
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sPage = e.SortExpression;
        if (ViewState["SortOrder"].ToString() == sPage)
        {
            if (ViewState["OrderDire"].ToString() == "Desc")
                ViewState["OrderDire"] = "ASC";
            else
                ViewState["OrderDire"] = "Desc";
        }
        else
        {
            ViewState["SortOrder"] = e.SortExpression;
        }
        this.DataShows();
    }

    /// <summary>
    /// 执行分页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void AspNetPager1_PageChanged(object src, EventArgs e)
    {
        this.DataShows();
    }
    /// <summary>
    /// 执行全选操作
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox ChkM = (CheckBox)GridView1.HeaderRow.Cells[0].FindControl("CheckBox1");

        foreach (GridViewRow gr in GridView1.Rows)
        {
            CheckBox chk = (CheckBox)gr.Cells[0].FindControl("Chbk");
            if (!chk.Checked && chk.Enabled == true)
            {
                chk.Checked = true;
                ChkM.Text = "消";
            }
            else
            {
                chk.Checked = false;
                ChkM.Text = "选";
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
        if (e.Row.RowIndex != -1)
        { //自动ID号
            int id = (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = id.ToString();
        }
    }

    /// <summary>
    /// 搜索
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button4_Click(object sender, EventArgs e)
    {
        string LogtimeA = StartDate.Text.ToString().Trim();
        string LogtimeB = EndDate.Text.ToString().Trim();
        string SeachKeyContent = KNetPage.KHtmlEncode(SeachKey.Text.ToString());
        if ((LogtimeA == "" && LogtimeB != "") || (LogtimeA != "" && LogtimeB == ""))
        {
            Response.Write("<script language=javascript>alert('您所选择的日期一定要有 开始日期 和 结束日期!');history.back(-1);</script>");
            Response.End();
        }
        Response.Redirect("Knet_Sales_Ship_Manage_Talks.aspx?LogtimeA=" + LogtimeA + "&LogtimeB=" + LogtimeB + "&SeachKey=" + SeachKeyContent + "&Css2=Div22");
        Response.End();
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
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,OutWareNo,OutWareCheckYN from KNet_Sales_OutWareList where OutWareNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["OutWareCheckYN"].ToString() == "True")
                {
                    return "<img src=\"../../images/gou.gif\"  border=\"0\" />";
                }
                else
                {
                    if (Knet_Procure_OrdersList_Details_Shu(aa.ToString()) <= 0)
                    {
                        return "<a href=\"Knet_Sales_Ship_Manage_AddDetails.aspx?OutWareNo=" + aa + "\"><img src=\"../../images/Nodata.gif\"  border=\"0\"  title=\"未完成的发货单（没有明细记录）\" /></a>";
                    }
                    else
                    {
                        string JSD = "pop/Knet_Sales_ShipCheckYN.aspx?OutWareNo=" + aa.ToString() + "";
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
    /// 返回洽谈跟进人名称（Y）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetStaffNameNane(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,StaffNo,StaffName from KNet_Resource_Staff where StaffNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["StaffName"].ToString().Trim();
            }
            else
            {
                return "";
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
                    return "<img src=\"../images/takman.gif\" width=\"11\" height=\"14\" border=\"0\" /><a href=\"#\" style=\"line-height: 22px;\" onclick=\"lhgdialog.opendlg('发货单号:<font color=Red>" + OutWareNo + "</font> 跟踪', '../Sales/Knet_Sales_Ship_Manage_Talks_List.aspx?OutWareNo=" + OutWareNo + "', 780, 400,false,false);\">" + KNetPage.CutString(dr["FollowText"].ToString().Trim(), 40) + "</a><br>&nbsp;&nbsp;<font color=\"gray\">" + GetStaffNameNane(dr["FollowStaffNo"]) + "&nbsp;(" + dr["FollowDateTime"].ToString() + ")</font>&nbsp;<<font color=red>结束</font>>";
                }
                else
                {
                    return "<img src=\"../images/takman.gif\" width=\"11\" height=\"14\" border=\"0\" /><a href=\"#\" style=\"line-height: 22px;\" onclick=\"lhgdialog.opendlg('发货单号:<font color=Red>" + OutWareNo + "</font> 跟踪', '../Sales/Knet_Sales_Ship_Manage_Talks_List.aspx?OutWareNo=" + OutWareNo + "', 780, 400,false,false);\">" + KNetPage.CutString(dr["FollowText"].ToString().Trim(), 40) + "</a><br>&nbsp;&nbsp;<font color=\"gray\">" + GetStaffNameNane(dr["FollowStaffNo"]) + "&nbsp;(" + dr["FollowDateTime"].ToString() + ")</font>&nbsp;<img src=\"/images/45.gif\" width=\"11\" height=\"11\" border=\"0\" /><a href=\"#\" onclick=\"lhgdialog.opendlg('发货单号:<font color=Red>" + OutWareNo + "</font> 跟踪', '../Sales/Knet_Sales_Ship_Manage_Talks_Add.aspx?OutWareNo=" + OutWareNo + "', 780, 400,false,false);\">添加</a>";
                }
            }
            else
            {
                return "<font color=\"gray\">暂无相关发货跟踪信息....</font>&nbsp;&nbsp;<img src=\"../images/45.gif\" width=\"11\" height=\"11\" border=\"0\" /><a href=\"#\" onclick=\"lhgdialog.opendlg('发货单号:<font color=Red>" + OutWareNo + "</font> 跟踪', '../Sales/Knet_Sales_Ship_Manage_Talks_Add.aspx?OutWareNo=" + OutWareNo + "', 780, 400,false,false);\">添加</a>";
            }
        }
    }

}
