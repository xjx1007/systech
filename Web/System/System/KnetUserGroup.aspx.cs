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
public partial class Knet_Web_System_KnetUserGroup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("用户组权限设置") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            ////用户组及权限查看
            //if (AM.YNAuthority(NQ.Str7010) == false)
            //{
            //    AM.NoAuthority("7010");
            //}
            ////用户组管理
            //if (AM.YNAuthority(NQ.Str7011) == false)
            //{
            //    AM.NoAuthority("7011");
            //}

            ////用户组管理
            //if (AM.YNAuthority(NQ.Str70110) == false)
            //{
            //    this.Button2.Enabled = false;
            //    this.Button3.Enabled = false;
            //}

            ViewState["SortOrder"] = "GroupPai";
            ViewState["OrderDire"] = "Desc";
            this.Button2.Attributes.Add("onclick", "return confirm('你确信要删除所选用户组名称记录吗?\\n\\n注意：删除后该用户组所拥有的权限也同时会清除！\\n同时所属这个用户组的所有用户权限全失效！')");

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
        KNet.BLL.KNet_Sys_AuthorityUserGroup bll = new KNet.BLL.KNet_Sys_AuthorityUserGroup();
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
            GridView1.DataKeyNames = new string[] { "GroupValue" };
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
    /// 返回回款详细与操作
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string Get_MangerDetail(object GroupValue)
    {
        return "<a href=\"#\" onclick=\"javascript:window.open('KnetUserAuthoritySetA.aspx?GroupValue=" + GroupValue + "','用户组权限设置','top=100,left=100,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=950,height=550');\">用户组权限详细设置</a>";
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

        string sql = "delete from KNet_Sys_AuthorityUserGroup where";
        string sql2 = "delete from KNet_Sys_AuthorityUserGroupSetup where";
        string cal = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {
                cal += " GroupValue='" + GridView1.DataKeys[i].Value.ToString() + "' or";
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
        LogAM.Add_Logs("系统设置--->用户组及权限--->用户组批量删除 操作成功！");

        this.DataShows();
        this.RowOverYN();
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
        KNet.BLL.KNet_Sys_AuthorityUserGroup bll = new KNet.BLL.KNet_Sys_AuthorityUserGroup();
        KNet.Model.KNet_Sys_AuthorityUserGroup model = new KNet.Model.KNet_Sys_AuthorityUserGroup();

        string GroupValue = GridView1.DataKeys[e.RowIndex].Value.ToString().Trim();
        string GroupName = KNetPage.KHtmlEncode(((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text.ToString().Trim());

        int GroupPai = int.Parse(KNetPage.KHtmlEncode(((TextBox)GridView1.Rows[e.RowIndex].Cells[3].FindControl("GroupPaitxt")).Text.ToString()));

        model.GroupValue = GroupValue;
        model.GroupName = GroupName;
        model.GroupPai = GroupPai;
        try
        {
            bll.Update(model);

            AdminloginMess LogAM = new AdminloginMess();
            LogAM.Add_Logs("系统设置--->用户组及权限--->用户组 更新 操作成功！用户组名称：" + GroupName);
        }
        catch
        {
            Response.Write("<script>alert('用户组 更新 失败！');history.back(-1);</script>");
            Response.End();
        }
        GridView1.EditIndex = -1;
        this.DataShows();
    }


    //==============================
    /// <summary>
    /// 获取用户组是否已有设置了操作权限
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetGroupNameYNPic(string GroupValue)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetJxcDB"))
        {
            conn.Open();
            string Dostr = "select GroupValue,AuthorityValue,AuthorityGroup from KNet_Sys_AuthorityUserGroupSetup where  GroupValue='" + GroupValue + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return "<img src=\"../../images/Au1.gif\" />";
            }
            else
            {
                return "<img src=\"../../images/Au2.gif\" />";
            }
        }
    }


  }
