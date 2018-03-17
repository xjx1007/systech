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
/// 库存管理-----库存盘点 管理
/// </summary>
public partial class Knet_Web_WareHouse_KNet_WareHouse_WareCheck_Manage_PrinterList : System.Web.UI.Page
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

            
            ViewState["SortOrder"] = "WareCheckDateTime";
            ViewState["OrderDire"] = "Desc";
         
            this.DataShows();

 
        }

    }

    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        AdminloginMess AM = new AdminloginMess();

        KNet.BLL.KNet_WareHouse_WareCheckList bll = new KNet.BLL.KNet_WareHouse_WareCheckList();
        string LogtimeA = null;
        string LogtimeB = null;
        string KSeachKey = null;

        string SqlWhere = " ( " + AM.MyDoSqlWith_Do + " )  ";

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

            SqlWhere = SqlWhere + " and ( WareCheckDateTime >= '" + LogtimeA + "' and  WareCheckDateTime<='" + LogtimeB + "'   ) ";
        }
        if (Request["SeachKey"] != null && Request["SeachKey"] !="")
        {
            KSeachKey = Request.QueryString["SeachKey"].ToString().Trim();
            if (KSeachKey == "") { KSeachKey = null; }
            this.SeachKey.Text = KSeachKey;

            SqlWhere = SqlWhere + " and ( WareCheckTopic like '%" + KSeachKey + "%' or WareCheckNo  like '%" + KSeachKey + "%' )";
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
            GridView1.DataKeyNames = new string[] { "WareCheckNo" };
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
        DropDownList goodsType = (DropDownList)e.Row.FindControl("PrinterModel");

        KNet.BLL.KNet_WareHouse_WareCheckList_Printer_Setup bll = new KNet.BLL.KNet_WareHouse_WareCheckList_Printer_Setup();
        if (goodsType != null)
        {
            using (DataSet ds = bll.GetList("PrinterYN=1"))
            {
                goodsType.DataSource = ds;
                goodsType.DataTextField = "PrinterTitle";
                goodsType.DataValueField = "Tex_ID";
                goodsType.DataBind();

                //ListItem item = new ListItem("请选择打印模板", ""); //默认值
                //goodsType.Items.Insert(0, item);
            }
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
        Response.Redirect("KNet_WareHouse_WareCheck_Manage_PrinterList.aspx?LogtimeA=" + LogtimeA + "&LogtimeB=" + LogtimeB + "&SeachKey=" + SeachKeyContent + "&Css4=Div22");
        Response.End();
    }
    /// <summary>
    /// 返回仓库名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetHouseNoName(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,HouseNo,HouseName from KNet_Sys_WareHouse where HouseNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["HouseName"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }

    /// <summary>
    /// 获取入库单明细数目
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected int Knet_Procure_OrdersList_Details_Shu(string WareCheckNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select count(*) as IDS  from KNet_WareHouse_WareCheckList_Details where WareCheckNo='" + WareCheckNo + "'";
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
            conn.Open();
            string Dostr = "select ID,WareCheckNo,WareCheckCheckYN from KNet_WareHouse_WareCheckList where WareCheckNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["WareCheckCheckYN"].ToString() == "True")
                {
                    return "<img src=\"../../images/gou.gif\"  border=\"0\" />";
                }
                else
                {
                    if (Knet_Procure_OrdersList_Details_Shu(aa.ToString()) <= 0)
                    {
                        return "<a href=\"KNet_WareHouse_WareCheck_AddDetails.aspx?WareCheckNo=" + aa + "&Css2=Div22\"><img src=\"../../images/Nodata.gif\"  border=\"0\"  title=\"未完成的盘点单（没有明细记录）\" /></a>";
                    }
                    else
                    {
                        return "<font color=blue>未审</font>";
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
    /// 打印输出操作(原意为删除操作）
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string WareCheckNo = GridView1.DataKeys[e.RowIndex].Value.ToString().Trim();
        string PrinterModel = KNetPage.KHtmlEncode(((DropDownList)GridView1.Rows[e.RowIndex].Cells[6].FindControl("PrinterModel")).SelectedValue.ToString());

        if (PrinterModel != "" && PrinterModel != null)
        {
            Response.Redirect("KNet_WareHouse_WareCheck_Manage_PrinterListSettingPage.aspx?WareCheckNo=" + WareCheckNo + "&PrinterModel=" + PrinterModel + "");
            Response.End();
        }
        else
        {
            Response.Write("<script>alert('请先选择打印模板');history.back(-1);</script>");
            Response.End();
        }
    }

}
