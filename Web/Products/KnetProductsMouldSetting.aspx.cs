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
/// 模具管理管理
/// </summary>
public partial class Knet_Web_KnetProductsMouldSetting : BasePage
{
    public string s_AdvShow = "", s_ProductsClass="";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Lbl_Title.Text = "模具管理列表";
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin(this.Lbl_Title.Text) == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            //删除模具管理
            if (AM.YNAuthority("删除模具管理") == false)
            {
                this.Btn_Del.Enabled = false;
            }
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string s_Model = Request.QueryString["Model"] == null ? "" : Request.QueryString["Model"].ToString();
            BuildTree("1", null);
            this.TreeView1.CollapseAll();
            this.TreeView1.Nodes[0].Expand();
            this.TreeView1.Nodes[0].Select();
            KNet.BLL.PB_Basic_ProductsClass BLL_Class = new KNet.BLL.PB_Basic_ProductsClass();
            if ((s_ID != "") && (s_Model == "IsDel"))
            {
                if (AM.YNAuthority("停用模具管理") == true)
                {
                    KNet.BLL.KNet_Sys_Products Bll = new KNet.BLL.KNet_Sys_Products();
                    KNet.Model.KNet_Sys_Products Model = Bll.GetModelB(s_ID);
                    Model.ProductsBarCode = s_ID;
                    int i_Del = Math.Abs(Model.KSP_Del - 1);
                    Model.KSP_Del = i_Del;
                    Bll.UpdateDel(Model);
                }
                else
                {
                    AM.NoAuthority("停用模具管理");
                }
            }
            this.Btn_Del.Attributes.Add("onclick", "return confirm('你确信要删除所选记录吗?！')");
            base.Base_DropBindSearch(this.bas_searchfield, "KNet_Sys_Products");
            base.Base_DropBindSearch(this.Fields, "KNet_Sys_Products");
            this.DataShows();
        }

    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.KNet_Sys_Products bll = new KNet.BLL.KNet_Sys_Products();
        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string s_Type = "";

        string SqlWhere = " 1=1 ";
        AdminloginMess AM = new AdminloginMess();

        if (s_WhereID != "")
        {
            SqlWhere += Base_GetBasicWhere(s_WhereID);
        }

        if ((this.bas_searchfield.SelectedValue != "") && (search_text.Text != ""))
        {
            SqlWhere += base.Base_GetBasicColumnWhere(this.bas_searchfield.SelectedValue, this.search_text.Text);
        }
        if (s_Text != "")
        {
            if (this.matchtype1.Checked == true)//and
            {
                s_Type = "0";
            }
            if (this.matchtype2.Checked == true)
            {
                s_Type = "1";
            }
            SqlWhere += base.Base_GetAdvWhere(s_Fields, s_Condition, s_Text, s_Type);
        }
        if (this.TreeView1.SelectedNode.Value != "1")
        {
            KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
            string s_SonID = Bll_ProductsDetails.GetSonIDs(this.TreeView1.SelectedNode.Value);
            s_SonID = s_SonID.Replace(",", "','");
            SqlWhere += " and ProductsType in ('" + s_SonID + "') ";
        }
        DataSet ds = bll.GetList(SqlWhere);
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "ID" };
        GridView1.DataBind();
    }



    protected void Btn_Del_Click(object sender, EventArgs e)
    {

        string sql = "delete from KNet_Sys_Products where";
        string cal = "";
        string s_BarCode = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {
                cal += " ID='" + GridView1.DataKeys[i].Value.ToString() + "' or";
                s_BarCode += GridView1.Rows[i].Cells[2].Text+",";
            }
        }
        if (cal != "")
        {
            sql += cal.Substring(0, cal.Length - 3);
            s_BarCode = s_BarCode.Substring(0, s_BarCode.Length - 1);
        }
        else
        {
            sql = "";       //不删除
            Response.Write("<script language=javascript>alert('您没有选择要删除的记录!');history.back(-1);</script>");
            Response.End();
        }
        sql += " delete from Xs_Products_Prodocts where XPP_FaterBarCode in ('" + s_BarCode.Replace(",", "','") + "') ";
        sql += " delete from Xs_Customer_Products where XCP_ProductsID in ('" + s_BarCode.Replace(",", "','") + "') ";
        DbHelperSQL.ExecuteSql(sql);

        AdminloginMess LogAM = new AdminloginMess();
        LogAM.Add_Logs("系统设置--->模具管理字典--->模具管理字典删除 操作成功！");

        this.DataShows();
    }
    public void btnBasicSearch_Click(object sender, EventArgs e)
    {
        this.advSearch.Style["display"] = "none";
        this.Search_basic.Style["display"] = "block";
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

    public string BaseGetIC(string s_ProductsBarCode)
    {
        string s_Return="-";
        this.BeginQuery("Select top 1 * from Xs_Products_Prodocts a join KNet_Sys_Products b on a.XPP_ProductsBarCode=b.ProductsBarCode where XPP_FaterBarCode='" + s_ProductsBarCode + "' and b.ProductsMainCategory='129682169809390852' ");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            s_Return = Dtb_Result.Rows[0]["ProductsEdition"].ToString();
        }
        return s_Return;
    }
    public string GetState(string s_ProductsBarCode, int s_Del)
    {
        string s_Return = "";
        try
        {

            if (s_Del == 1)
            {
                string JSD = "KnetProductsSetting.aspx?ID=" + s_ProductsBarCode + "&Model=IsDel";
                s_Return = "<a href=\"" + JSD + "\" onclick=\"\"  ><font color=red>停用</font></a>";
            }
            else
            {
                string JSD = "KnetProductsSetting.aspx?ID=" + s_ProductsBarCode + "&Model=IsDel";
                s_Return = "<a href=\"" + JSD + "\" onclick=\"\" >启用</a>";
            }
        }
        catch
        { }
        return s_Return;
    }
    public string GetProductsType(string s_ID)
    {
        string s_Return="";
        try
        {
            KNet.BLL.PB_Basic_ProductsClass Bll = new KNet.BLL.PB_Basic_ProductsClass();
            s_Return = Bll.GetProductsName(s_ID);
        }
        catch
        { }
        return s_Return;
    }
    public void BuildTree(string s_ID,TreeNode tree)
    {
        try
        {
            KNet.BLL.PB_Basic_ProductsClass Bll=new KNet.BLL.PB_Basic_ProductsClass();
            TreeNode treeMainNode = new TreeNode();
            KNet.BLL.PB_Basic_ProductsClass bll = new KNet.BLL.PB_Basic_ProductsClass();
            if (tree == null)
            {
                KNet.Model.PB_Basic_ProductsClass Model = bll.GetModel(s_ID);
                this.TreeView1.Nodes.Clear();
                treeMainNode.Text = Model.PBP_Name;
                treeMainNode.Value = Model.PBP_ID;
                this.TreeView1.Nodes.Add(treeMainNode);
            }
            else
            {
                treeMainNode = tree;
            }
            
            DataSet Dts_Table = bll.GetList(" PBP_FaterID='" + s_ID + "'");


            if (Dts_Table.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                {
                    TreeNode treeNode1 = new TreeNode();
                    treeNode1.Text=Dts_Table.Tables[0].Rows[i]["PBP_Name"].ToString();
                    treeNode1.Value=Dts_Table.Tables[0].Rows[i]["PBP_ID"].ToString();
                    treeMainNode.ChildNodes.Add(treeNode1);
                    BuildTree(Dts_Table.Tables[0].Rows[i]["PBP_ID"].ToString(), treeNode1);
                }
            }
        }
        catch
        { }
    }
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        this.DataShows();
    }

    protected void Lbl_Spce_Click(object sender, EventArgs e)
    {
        string UploadPath = "../../UpFile/Products/模具管理型号命名规则.doc";  //上传文件
        Response.Redirect(UploadPath);
    }
}
