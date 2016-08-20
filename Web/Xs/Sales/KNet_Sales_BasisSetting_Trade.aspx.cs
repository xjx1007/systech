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
/// 销售管理设置  ---客户行业
/// </summary>
public partial class KNet_Web_Sales_KNet_Sales_BasisSetting_Trade : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {   
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("基础设置") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }

            ViewState["SortOrder"] = "ClientPai";
            ViewState["OrderDire"] = "Desc";
            this.Button2.Attributes.Add("onclick", "return confirm('你确定要删除所选记录吗? ！')");
            this.DataShows();
            this.RowOverYN();

           
        }
    }
    /// <summary>
    /// 是不是有记录 CheckNotes
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
    /// 绑定数据源 分类(1渠道信息，2客户类型,3客户行业，4客户来源）
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.KNet_Sales_ClientAppseting bll = new KNet.BLL.KNet_Sales_ClientAppseting();
        using (DataSet ds = bll.GetList(" ClientKings=3 and Clientdefault=0 "))
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

        string sql = "delete from KNet_Sales_ClientAppseting where";
        string cal = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {
                cal += " ID='" + GridView1.DataKeys[i].Value.ToString() + "' or";
            }
        }
        if (cal != "")
        {
            sql += cal.Substring(0, cal.Length - 3);
        }
        else
        {
            sql = "";       //不删除
            Response.Write("<script language=javascript>alert('您没有选择要删除的记录!');history.back(-1);</script>");
            Response.End();
        }
        DbHelperSQL.ExecuteSql(sql);

        AdminloginMess LogAM = new AdminloginMess();
        LogAM.Add_Logs("销售管理--->销售管理设置--->客户行业 批量删除 操作成功！");

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
        KNet.BLL.KNet_Sales_ClientAppseting bll = new KNet.BLL.KNet_Sales_ClientAppseting();
        KNet.Model.KNet_Sales_ClientAppseting model = new KNet.Model.KNet_Sales_ClientAppseting();

        string  ID = GridView1.DataKeys[e.RowIndex].Value.ToString().Trim();
        string Client_Name = KNetPage.KHtmlEncode(((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text.ToString().Trim());

        int ClientPai = int.Parse(KNetPage.KHtmlEncode(((TextBox)GridView1.Rows[e.RowIndex].Cells[3].FindControl("UnitsPaitxt")).Text.ToString()));

        model.ID = ID;
        model.Client_Name = Client_Name;
        model.ClientPai = ClientPai;
        try
        {

            bll.Update(model);

            AdminloginMess LogAM = new AdminloginMess();
            LogAM.Add_Logs("销售管理--->销售管理设置--->客户行业 更新 操作成功！名称：" + Client_Name);
        }
        catch
        {
            Response.Write("<script>alert('客户行业 更新 失败！');history.back(-1);</script>");
            Response.End();
        }
        GridView1.EditIndex = -1;
        this.DataShows();
    }


    /// <summary>
    /// 添加单位 (1渠道信息，2客户类型,3客户行业，4客户来源）
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button8_Click(object sender, EventArgs e)
    {
        string ClientValue = DateTime.Now.ToFileTimeUtc().ToString();
        string Client_Name = KNetPage.KHtmlEncode(this.txtUnitsName.Text);
        bool Clientdefault = false;
        int ClientKings = 3;
        int ClientPai = int.Parse(this.txtUnitsPai.Text);

        if (Client_Name == "" || Client_Name == null)
        {
            Response.Write("<script>alert('客户行业 名称不能为空！');history.back(-1);</script>");
            Response.End();
        }


        KNet.BLL.KNet_Sales_ClientAppseting bll = new KNet.BLL.KNet_Sales_ClientAppseting();
        KNet.Model.KNet_Sales_ClientAppseting model = new KNet.Model.KNet_Sales_ClientAppseting();

        model.ClientValue = ClientValue;
        model.Client_Name = Client_Name;
        model.ClientPai = ClientPai;
        model.Clientdefault = Clientdefault;
        model.ClientKings = ClientKings;

        try
        {
            if (bll.Exists(Client_Name, ClientKings) == false)
            {
                bll.Add(model);

                AdminloginMess LogAM = new AdminloginMess();
                LogAM.Add_Logs("销售管理--->销售管理设置--->客户行业 添加 操作成功！名称：" + Client_Name);

                Response.Write("<script>alert('客户行业 添加 成功！');location.href='" + Request.Url.ToString() + "';</script>");
                Response.End();
            }
            else
            {
                Response.Write("<script>alert('客户行业名称已存在 添加失败1！');history.back(-1);</script>");
                Response.End();
            }
        }
        catch
        {
            Response.Write("<script>alert('客户行业 添加 失败2！');history.back(-1);</script>");
            Response.End();
        }
    }
}
