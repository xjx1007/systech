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
/// 库存管理-----直接出库单管理   出库价格分析，明细表
/// </summary>
public partial class Knet_Web_WareHouse_KNet_WareHouse_WareCheck_Manage_Analysis : System.Web.UI.Page
{
    private double OrderAmount_Sum1 = 0;       //盘差 数量 合计
    private double OrderAmount_Sum2 = 0;       //盘差数量 合计

    private double OrderDiscount_Sum1 = 0;     //计价调节合计
    private double OrderDiscount_Sum2 = 0;     //计价调节合计

    private double OrderTotalNet_Sum1 = 0;     //净值合计
    private double OrderTotalNet_Sum2 = 0;     //净值合计


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
            ViewState["SortOrder"] = "ProductsBarCode";
            ViewState["OrderDire"] = "Asc";
            this.DataShows();
        }

    }


    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.KNet_WareHouse_WareCheckList_Details bll = new KNet.BLL.KNet_WareHouse_WareCheckList_Details();

        using (DataSet ds = bll.GetList(""))
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
            GridView1.DataKeyNames = new string[] { "ProductsBarCode" };
            GridView1.DataBind();

            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                DataRowView mydrv = ds.Tables[0].DefaultView[i];

                if (int.Parse(mydrv["WareCheckLossUp"].ToString()) == 1)
                {
                    //计价调节合计
                    OrderDiscount_Sum1 = OrderDiscount_Sum1 + double.Parse(mydrv["WareCheckDiscount"].ToString());
                    //净值合计
                    OrderTotalNet_Sum1 = OrderTotalNet_Sum1 + double.Parse(mydrv["WareCheckTotalNet"].ToString());

                    //采购数量 合计
                    OrderAmount_Sum1 = OrderAmount_Sum1 + double.Parse(mydrv["WareCheckAmount"].ToString());
                }
                else
                {
                    //计价调节合计
                    OrderDiscount_Sum2 = OrderDiscount_Sum2 + double.Parse(mydrv["WareCheckDiscount"].ToString());
                    //净值合计
                    OrderTotalNet_Sum2 = OrderTotalNet_Sum2 + double.Parse(mydrv["WareCheckTotalNet"].ToString());

                    //采购数量 合计
                    OrderAmount_Sum2 = OrderAmount_Sum2 + double.Parse(mydrv["WareCheckAmount"].ToString());
                }
            }
            string Mstrings = "&nbsp;<span  style=\"font-size:13px;line-height:20px;\"> 共有记录 <B><font color=#0000FF>" + ds.Tables[0].Rows.Count.ToString() + "</font></B> 笔，数量盘差(正)合计：<font color=#FF0000><B>" + OrderAmount_Sum1.ToString() + "</B></font>，数量盘差(负)合计：<font color=#FF0000><B>" + OrderAmount_Sum2.ToString() + "</B></font><br>";
            Mstrings = Mstrings + "&nbsp;&nbsp;计价调节(盘正)合计：<B><font color=#0000FF>" + OrderDiscount_Sum1.ToString("N") + "</font></B>，计价调节(盘负)合计：<B><font color=#0000FF>" + OrderDiscount_Sum2.ToString("N") + "</font></B>，(盘正)净值合计：<B><font color=#0000FF>" + OrderTotalNet_Sum1.ToString("N") + "</font></B>，(盘负)净值合计：<B><font color=#0000FF>" + OrderTotalNet_Sum2.ToString("N") + "</font></B></span>";
            this.SmA.Text = Mstrings;
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
    /// 返回盘点类型
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetOrderAmountss(object WareCheckLossUp)
    {
        try
        {
            if (WareCheckLossUp.ToString() == "1")
            {
                return "<font color=red>盘正</font>";
            }
            if (WareCheckLossUp.ToString() == "2")
            {
                return "<font color=blue>盘负</font>";
            }
            else
            {
                return "--";
            }
        }
        catch { return "--"; }
    }



 

}
