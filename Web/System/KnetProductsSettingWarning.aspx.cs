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
/// 仓库管理
/// </summary>
public partial class Knet_Web_System_KnetProductsSettingWarning : System.Web.UI.Page
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

            ViewState["SortOrder"] = "ProductsAddTime";
            ViewState["OrderDire"] = "Desc";
            this.Button2.Attributes.Add("onclick", "return confirm('你确定要设置所选项的 库存缺货预警吗？')");

            this.DataShows();
            this.RowOverYN();
            this.DataBindProductsMainCategory();
        }

    }
    /// <summary>
    /// 是不是有记录
    /// </summary>
    protected void RowOverYN()
    {
        if (GridView1.Rows.Count == 0) //如果没有记录
        {
            this.Button2.Enabled = false;
            this.Button3.Enabled = false;
        }
    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.KNet_Sys_Products bll = new KNet.BLL.KNet_Sys_Products();
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

            SqlWhere = SqlWhere + " and ( ProductsAddTime >= '" + LogtimeA + "' and  ProductsAddTime<='" + LogtimeB + "'   ) ";
        }


        if (Request["KSeachKey"] != null && Request["KSeachKey"] !="")
        {
            KSeachKey = Request.QueryString["KSeachKey"].ToString().Trim();
            if (KSeachKey == "") { KSeachKey = null; }
            this.SeachKey.Text = KSeachKey;

            SqlWhere = SqlWhere + " and ( ProductsName like '%" + KSeachKey + "%' or ProductsBarCode  like '%" + KSeachKey + "%' or ProductsPattern  like '%" + KSeachKey + "%' )";
        }

        if (Request["KDBList"] != null && Request["KDBList"] != "")
        {
            string KDBList = Request.QueryString["KDBList"].ToString().Trim();
            if (KDBList == "") { KDBList = null; }
            this.ProductsMainCategoryDList.SelectedValue = KDBList;

            SqlWhere = SqlWhere + " and ProductsMainCategory = '" + KDBList + "' ";
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
        this.RowOverYN();
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
            if (!chk.Checked)
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
    /// 返回大类名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetBigCateNane(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,BigNo,CateName from KNet_Sys_BigCategories where BigNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["CateName"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }

    /// <summary>
    /// 返回单位名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetUnitsName(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,UnitsNo,UnitsName from KNet_Sys_Units where UnitsNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["UnitsName"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }
    /// <summary>
    /// 批量设置 库存缺货预警记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        string cal = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
            TextBox obj2 = (TextBox)GridView1.Rows[i].Cells[0].FindControl("OrderAmounttxt");

            if (cb.Checked == true)
            {
                cal += GridView1.DataKeys[i].Value;

                string Dosql = "update KNet_Sys_Products set ProductsStockAlert=" + int.Parse(obj2.Text.ToString()) + " where ID='" + GridView1.DataKeys[i].Value.ToString() + "' ";
                try
                {
                    DbHelperSQL.ExecuteSql(Dosql);
                }
                catch { }
            }
        }
        if (cal == "")
        {
            Response.Write("<script language=javascript>alert('您没有选择要设置库存缺货预警的记录!');history.back(-1);</script>");
            Response.End();
        }
        else
        {
            AdminloginMess LogAM = new AdminloginMess();
            LogAM.Add_Logs("系统设置--->产品字典--->库存缺货预警设置 操作成功！");

            Response.Write("<script language=javascript>alert('库存缺货预警设置成功 !')</script>");

            this.DataShows();
            this.RowOverYN();
        }
    }

    /// <summary>
    /// 取消所有已选中列
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            CheckBox ChkB = (CheckBox)GridView1.HeaderRow.Cells[0].FindControl("CheckBox1");
            ChkB.Checked = false;

            foreach (GridViewRow gr in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)gr.Cells[0].FindControl("Chbk");
                chk.Checked = false;
            }
            GridView1.EditIndex = -1;
            this.DataShows();
        }
        catch { }
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
        string KSeachKey = KNetPage.KHtmlEncode(SeachKey.Text.ToString());
        if ((LogtimeA == "" && LogtimeB != "") || (LogtimeA != "" && LogtimeB == ""))
        {
            Response.Write("<script language=javascript>alert('您所选择的日期一定要有 开始日期 和 结束日期!');history.back(-1);</script>");
            Response.End();
        }
        Response.Redirect("KnetProductsSettingWarning.aspx?LogtimeA=" + LogtimeA + "&LogtimeB=" + LogtimeB + "&KSeachKey=" + KSeachKey + "");
        Response.End();
    }


    /// <summary>
    /// 大分类绑定
    /// </summary>
    protected void DataBindProductsMainCategory()
    {
        KNet.BLL.KNet_Sys_BigCategories bll = new KNet.BLL.KNet_Sys_BigCategories();
        DataSet ds = bll.GetAllList();
        this.ProductsMainCategoryDList.DataSource = ds;
        this.ProductsMainCategoryDList.DataTextField = "CateName";
        this.ProductsMainCategoryDList.DataValueField = "BigNo";
        this.ProductsMainCategoryDList.DataBind();
        ListItem item = new ListItem("按大分类筛选记录", ""); //默认值
        this.ProductsMainCategoryDList.Items.Insert(0, item);
    }

    /// <summary>
    /// 大类分类搜索
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ProductsMainCategoryDList_SelectedIndexChanged(object sender, EventArgs e)
    {
        string KDBList = this.ProductsMainCategoryDList.SelectedValue;
        
        Response.Redirect("KnetProductsSettingWarning.aspx?KDBList=" + KDBList + "");
        Response.End();
        
    }
}
