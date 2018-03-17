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

using KNet.DBUtility;
using KNet.Common;
using System.Data.SqlClient;

public partial class KNet_Sys_AuthorityTable_List : BasePage
{
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            this.Lbl_Title.Text = "权限注册列表";
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin(this.Lbl_Title.Text) == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            this.Btn_Del.Attributes.Add("onclick", "return confirm('你确信要删除所选记录吗?！')");

            BuildTree("", null);
            this.TreeView1.CollapseAll();
            this.TreeView1.Nodes[0].Expand();
            this.TreeView1.Nodes[0].Select();
            this.DataShows();
            base.Base_DropBindSearch(this.bas_searchfield, "KNet_Sys_AuthorityTable");
            base.Base_DropBindSearch(this.Fields, "KNet_Sys_AuthorityTable");
        }
    }

    public void btnBasicSearch_Click(object sender, EventArgs e)
    {
        this.advSearch.Style["display"] = "none";
        this.Search_basic.Style["display"] = "block";
        this.DataShows();
    }


    public void BuildTree(string s_ID, TreeNode tree)
    {
        try
        {
            KNet.BLL.PB_Basic_Menu Bll = new KNet.BLL.PB_Basic_Menu();
            TreeNode treeMainNode = new TreeNode();
            KNet.BLL.PB_Basic_Menu bll = new KNet.BLL.PB_Basic_Menu();
            if (tree == null)
            {

                try
                {
                    KNet.Model.PB_Basic_Menu Model = bll.GetModel(s_ID);
                    this.TreeView1.Nodes.Clear();
                    treeMainNode.Text = Model.PBM_Name;
                    treeMainNode.Value = Model.PBM_ID;
                    this.TreeView1.Nodes.Add(treeMainNode);
                }
                catch
                {
                    treeMainNode.Text = "菜单";
                    treeMainNode.Value = "";
                    this.TreeView1.Nodes.Add(treeMainNode);
                }
            }
            else
            {
                treeMainNode = tree;
            }

            DataSet Dts_Table = bll.GetList(" PBM_FatherID='" + s_ID + "'");


            if (Dts_Table.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                {
                    TreeNode treeNode1 = new TreeNode();
                    treeNode1.Text = Dts_Table.Tables[0].Rows[i]["PBM_Name"].ToString();
                    treeNode1.Value = Dts_Table.Tables[0].Rows[i]["PBM_ID"].ToString();
                    treeMainNode.ChildNodes.Add(treeNode1);
                    BuildTree(Dts_Table.Tables[0].Rows[i]["PBM_ID"].ToString(), treeNode1);
                }
            }
        }
        catch (Exception ex)
        { }
    }
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        this.DataShows();
    }
    public void btnAdvancedSearch_Click(object sender, EventArgs e)
    {
        this.Search_basic.Style["display"] = "none";
        this.advSearch.Style["display"] = "block";

        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string[] arr_Fields = s_Fields.Split(',');
        string[] arr_Condition = s_Condition.Split(',');
        string[] arr_Text = s_Text.Split(',');
        this.Fields.SelectedValue = arr_Fields[0];
        this.Condition.SelectedValue = arr_Condition[0];
        this.Srch_value.Text = arr_Text[0];
        s_AdvShow = Base_GetAdvShowHtml(arr_Fields, arr_Condition, arr_Text);
        this.DataShows();
    }
    public void DataShows()
    {
        AdminloginMess AM = new AdminloginMess();

        KNet.BLL.KNet_Sys_AuthorityTable bll = new KNet.BLL.KNet_Sys_AuthorityTable();
        string s_Sql = "1=1 ";
        if (this.search_text.Text != "")
        {
            s_Sql += " and  AuthorityName like '%" + this.search_text.Text + "%' ";
        }
        if (this.TreeView1.SelectedNode.Text != "")
        {
            s_Sql += " and  AuthorityGroup like '%" + this.TreeView1.SelectedNode.Value + "%' or AuthorityFaterID like '%" + this.TreeView1.SelectedNode.Value + "%'  ";
        }
        s_Sql += " Order by ID desc ";
        DataSet ds = bll.GetList(s_Sql);
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "ID" };
        GridView1.DataBind();
        ds.Dispose();
    }

    protected void Btn_Del_Click(object sender, EventArgs e)
    {
        string sql = "delete from  KNet_Sys_AuthorityTable  " ; //删除
        sql +=" where";
        AdminloginMess LogAM = new AdminloginMess();
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
            Response.Write("<script language=javascript>alert('您没有选择要删除的记录!');history.back(-1);</script>");
            Response.End();
        }
        try
        {
            DbHelperSQL.ExecuteSql(sql);

            Alert("删除成功！");
            LogAM.Add_Logs("系统设置--->权限注册管理--->权限注册删除"+sql+" 操作成功！");
            this.DataShows();
        }
        catch { }
    }
  
    protected void Btn_Search_Click(object sender, EventArgs e)
    {
        this.DataShows();
    }
    
}
