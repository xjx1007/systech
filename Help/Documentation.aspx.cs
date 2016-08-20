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
///  帮助中心 -----帮助文档 
/// </summary>
public partial class Knet_Help_Documentation : System.Web.UI.Page
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
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            else
            {

                ViewState["SortOrder"] = "Addtimes";
                ViewState["OrderDire"] = "Desc";
               

                this.DataShows();

            }
           
        }

    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.AKNet_helps bll = new KNet.BLL.AKNet_helps();
        string KSeachKey = null;
        string SqlWhere = " YN=1 ";

        if (Request["KSeachKey"] != null && Request["KSeachKey"] != "")
        {
            KSeachKey = Request.QueryString["KSeachKey"].ToString().Trim();
            if (KSeachKey == "") { KSeachKey = null; }
            this.SeachKey.Text = KSeachKey;

            SqlWhere = SqlWhere + " and  Titles like '%" + KSeachKey + "%'  ";
        }


        if (Request["kings"] != null && Request["kings"] != "")
        {
            try
            {
                int kings = int.Parse(Request.QueryString["kings"].ToString().Trim());
                SqlWhere = SqlWhere + " and kings = " + kings + " ";
            }
            catch { }
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
            GridView1.DataKeyNames = new string[] { "ID" };
            GridView1.DataBind();
            ds.Dispose();
            dv.Dispose();
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

        string KSeachKey = KNetPage.KHtmlEncode(SeachKey.Text.ToString());

        Response.Redirect("Documentation.aspx?KSeachKey=" + KSeachKey + "");
        Response.End();
    }
    /// <summary>
    /// 返回类型 帮助类型（1采购入库，2库存管理，3销售管理，4财务管理，5统计分析，6人事管理，7系统管理）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string getkingsstring(object aa)
    {
        if (aa.ToString() == "1")
        {
            return "采购入库";
        }
        else if (aa.ToString() == "2")
        {
            return "库存管理";
        }
        else if (aa.ToString() == "3")
        {
            return "销售管理";
        }
        else if (aa.ToString() == "4")
        {
            return "财务管理";
        }
        else if (aa.ToString() == "5")
        {
            return "统计分析";
        }
        else if (aa.ToString() == "6")
        {
            return "人事管理";
        }
        else if (aa.ToString() == "7")
        {
            return "系统管理";
        }
        else
        {
            return "--";
        }
    }
    /// <summary>
    /// 返回详细与操作
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string Get_MangerDetail(object ID)
    {
        return "<a href=\"#\" onclick=\"javascript:window.open('Documentation_Details.aspx?ID=" + ID + "','查看详细','top=100,left=100,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=900,height=550');\">查看详细</a>";
    }


}
