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

using KNet.DBUtility;
using KNet.Common;

/// <summary>
/// 基础设置---产品大类设置
/// </summary>
public partial class KNet_Web_System_BasisSetting_BigClass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {   
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("基本设置列表") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            //基础设置管理
            if (AM.YNAuthority("删除基本设置") == false)
            {
            }
            ViewState["SortOrder"] = "CatePai";
            ViewState["OrderDire"] = "Desc";
            this.Button2.Attributes.Add("onclick", "return confirm('你确信要删除所选记录吗?\\n\\n注意：删除后有该产品分类的产品将变成“未知分类”！')");
            this.DataShows();
            this.RowOverYN();
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
        KNet.BLL.KNet_Sys_BigCategories bll = new KNet.BLL.KNet_Sys_BigCategories();
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
            GridView1.DataKeyNames = new string[] { "BigNo" };
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
                ChkM.Text = "取消";
            }
            else
            {
                chk.Checked = false;
                ChkM.Text = "全选";
            }
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
    /// 批量删除记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {

        string sql = "delete from KNet_Sys_BigCategories where";
        string sql2 = "delete from KNet_Sys_SmallCategories where";
        string cal = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {
                cal += " BigNo='" + GridView1.DataKeys[i].Value.ToString() + "' or";
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


        DbHelperSQL.ExecuteSql(sql);
        DbHelperSQL.ExecuteSql(sql2);

        AdminloginMess LogAM = new AdminloginMess();
        LogAM.Add_Logs("系统设置--->基础设置--->产品大类  批量删除 操作成功！");

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
            //自动ID号
            int id = (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = id.ToString();
        }
    }

    /// <summary>
    /// 开启编辑
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_Editing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        this.DataShows();
    }

    /// <summary>
    /// 取消编辑
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        this.DataShows();
    }

    /// <summary>
    /// 更新数据记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        KNet.BLL.KNet_Sys_BigCategories bll = new KNet.BLL.KNet_Sys_BigCategories();
        KNet.Model.KNet_Sys_BigCategories model = new KNet.Model.KNet_Sys_BigCategories();

        string BigNo = GridView1.DataKeys[e.RowIndex].Value.ToString().Trim();
        string UnitsName = KNetPage.KHtmlEncode(((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text.ToString().Trim());

        int UnitsPai = int.Parse(KNetPage.KHtmlEncode(((TextBox)GridView1.Rows[e.RowIndex].Cells[3].FindControl("UnitsPaitxt")).Text.ToString()));

        model.BigNo = BigNo;
        model.CateName = UnitsName;
        model.CatePai = UnitsPai;
        try
        {
            bll.Update(model);

            AdminloginMess LogAM = new AdminloginMess();
            LogAM.Add_Logs("系统设置--->基础设置--->产品大类 更新 操作成功！名称：" + UnitsName);
        }
        catch
        {
           //throw;
            Response.Write("<script>alert('产品大类 更新 失败！');history.back(-1);</script>");
            Response.End();
        }
        GridView1.EditIndex = -1;
        this.DataShows();
    }


    /// <summary>
    /// 添加单位
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button8_Click(object sender, EventArgs e)
    {
        string UnitsNo = DateTime.Now.ToFileTimeUtc().ToString();
        string UnitsName =KNetPage.KHtmlEncode(this.txtUnitsName.Text);
        int UnitsPai = int.Parse(this.txtUnitsPai.Text);

        if (UnitsName == "" || UnitsName == null)
        {
            Response.Write("<script>alert('产品大类名称不能为空！');history.back(-1);</script>");
            Response.End();
        }


        KNet.Model.KNet_Sys_BigCategories model = new KNet.Model.KNet_Sys_BigCategories();
        model.BigNo = UnitsNo;
        model.CateName = UnitsName;
        model.CatePai = UnitsPai;

        KNet.BLL.KNet_Sys_BigCategories bll = new KNet.BLL.KNet_Sys_BigCategories();



        try
        {
            if (bll.Exists(UnitsName) == false)
            {
                bll.Add(model);


                AdminloginMess LogAM = new AdminloginMess();
                LogAM.Add_Logs("系统设置--->基础设置--->产品大类 添加 操作成功！名称：" + UnitsName);

                Response.Write("<script>alert('产品大类 添加 成功！');location.href='" + Request.Url.ToString() + "';</script>");
                Response.End();
            }
            else
            {
                Response.Write("<script>alert('产品大类 名称已存在 添加失败1！');history.back(-1);</script>");
                Response.End();
            }
        }
        catch
        {
           // throw;
           Response.Write("<script>alert('产品大类 添加 失败2！');history.back(-1);</script>");
           Response.End();
        }
    }
}
