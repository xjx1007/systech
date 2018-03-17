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

using KNet.Common;
using KNet.DBUtility;

/// <summary>
/// 人力资源 ---组织架构
/// </summary>
public partial class KNet_Web_HR_OrganizationalStructure : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("组织结构设置") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            else
            {
                ViewState["SortOrder"] = "StrucPai";
                ViewState["OrderDire"] = "Desc";
                this.showlist();
                this.DataShows();
            }
        }
      
    }

    /// <summary>
    /// 树目录显示出来
    /// </summary>
    protected void showlist()
    {
        this.TreeView1.Nodes.Clear();
        KNet.Common.dropdown.listshow(allclass(), "StrucName", "StrucValue", "StrucPai", "StrucPID", "0", this.TreeView1, true);
    }


    //列出所有类别数据
    protected DataTable allclass()
    {
        KNet.DAL.KNet_Resource_OrganizationalStructure DAL = new KNet.DAL.KNet_Resource_OrganizationalStructure();
        return DAL.GetList("").Tables[0];
    }

    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.KNet_Resource_OrganizationalStructure bll = new KNet.BLL.KNet_Resource_OrganizationalStructure();
        using (DataSet ds = bll.GetList("StrucPID='0'"))
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
    /// 添加提示
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_DataRowBinding(object sender, GridViewRowEventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //自动ID号
            int id = (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = id.ToString();

            e.Row.Cells[4].Attributes.Add("onClick", "return confirm('你确信要删除该记录吗！');");

            ////企业组织架构
            //if (AM.YNAuthority(NQ.Str5001) == false)
            //{
            //    e.Row.Cells[4].Text = "<font color=#999999>删除</font>";
            //    e.Row.Cells[4].Attributes.Remove("onClick");
            //}
        }
    }

    /// <summary>
    /// 添加记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        KNet.BLL.KNet_Resource_OrganizationalStructure BLL = new KNet.BLL.KNet_Resource_OrganizationalStructure();
        KNet.Model.KNet_Resource_OrganizationalStructure model = new KNet.Model.KNet_Resource_OrganizationalStructure();

        string StrucName = KNetPage.KHtmlEncode(this.txtStrucName.Text.Trim());
        int StrucPai = int.Parse(this.txtStrucPai.Text.Trim());
        

        string StrucValue = DateTime.Now.ToFileTimeUtc().ToString();
        string StrucPID = "0";

        
        model.StrucName = StrucName;
        model.StrucPai = StrucPai;
        model.StrucValue = StrucValue;
        model.StrucPID = StrucPID;

        try
        {
            if (BLL.Exists(StrucName, StrucPID) == false)
            {
                BLL.Add(model);

                AdminloginMess LogAM = new AdminloginMess();
                LogAM.Add_Logs("系统设置--->组织架构--->分部添加操作成功！分部名称:" + StrucName);

                Response.Write("<script>alert('组织架构分部 添加 成功！');location.href='" + Request.Url.ToString() + "';</script>");
                Response.End();
            }
            else
            {
                Response.Write("<script>alert('组织架构分部 名称已存在 添加失败1！');history.back(-1);</script>");
                Response.End();
            }
        }
        catch
        {
            Response.Write("<script>alert('组织架构分部 添加 失败2！');history.back(-1);</script>");
            Response.End();
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
    /// 删除记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_del(object sender, GridViewDeleteEventArgs e)
    {
        KNet.BLL.KNet_Resource_OrganizationalStructure bll = new KNet.BLL.KNet_Resource_OrganizationalStructure();
        string ID = GridView1.DataKeys[e.RowIndex].Value.ToString();

        if (Is_RootDBExit(ID) == true)
        {
            Response.Write("<script>alert('组织架构 分部删除 失败！下面有部门，请先删除部门！');history.back(-1);</script>");
            Response.End();
        }
        else
        {
            bll.Delete(ID);
            AdminloginMess LogAM = new AdminloginMess();
            LogAM.Add_Logs("系统设置--->组织架构--->分部名称删除操作成功！ID:" + ID);
        }

        this.DataShows();
    }
    /// <summary>
    /// 更新数据记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        KNet.BLL.KNet_Resource_OrganizationalStructure bll = new KNet.BLL.KNet_Resource_OrganizationalStructure();
        KNet.Model.KNet_Resource_OrganizationalStructure model = new KNet.Model.KNet_Resource_OrganizationalStructure();

        string ID = GridView1.DataKeys[e.RowIndex].Value.ToString().Trim();
        string StrucName = KNetPage.KHtmlEncode(((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text.ToString().Trim());

        int StrucPai = int.Parse(KNetPage.KHtmlEncode(((TextBox)GridView1.Rows[e.RowIndex].Cells[2].FindControl("UnitsPaitxt")).Text.ToString()));

        model.ID = ID;
        model.StrucName = StrucName;
        model.StrucPai = StrucPai;
        model.StrucPID = "0";
        try
        {
            bll.Update(model);

            AdminloginMess LogAM = new AdminloginMess();
            LogAM.Add_Logs("系统设置--->组织架构--->分部名称更新操作成功！分部名称:" + StrucName);

            Response.Redirect("KNet_OrganizationalStructure.aspx");
            Response.End();

        }
        catch
        {
            Response.Write("<script>alert('组织架构 分部名称更新 失败！');history.back(-1);</script>");
            Response.End();
        }
        GridView1.EditIndex = -1;
        this.DataShows();
    }

    /// <summary>
    /// 打开公司添加面板
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click(object sender, EventArgs e)
    {
        this.AddNewsCompany.Visible = true;
        this.Button2.Visible = false;
    }
    /// <summary>
    /// 关公司添加面板
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button3_Click(object sender, EventArgs e)
    {
        this.AddNewsCompany.Visible = false;
        this.Button2.Visible = true;
    }


    /// <summary>
    /// 是否有子分类
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    public bool Is_RootDBExit(string aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select * from KNet_Resource_OrganizationalStructure where StrucPID='" + Is_GetStrucPID(aa) + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }


    /// <summary>
    /// 是否有子分类
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    public string Is_GetStrucPID(string aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select * from KNet_Resource_OrganizationalStructure where ID='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["StrucValue"].ToString();
            }
            else
            {
                return "";
            }
        }
    }

}

