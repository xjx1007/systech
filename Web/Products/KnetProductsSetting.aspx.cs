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
/// 产品管理
/// </summary>
public partial class Knet_Web_System_KnetProductsSetting : BasePage
{
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Lbl_Title.Text = "产品列表";
            AdminloginMess AM = new AdminloginMess();
            Tbx_Productstype.Text = AM.ProductsType;
            Lbl_Type.Text = base.Base_GetProductsType(Tbx_Productstype.Text);
            if (AM.CheckLogin(this.Lbl_Title.Text) == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            //删除产品
            if (AM.YNAuthority("删除产品") == false)
            {
                this.Btn_Del.Enabled = false;
            }
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string s_Model = Request.QueryString["Model"] == null ? "" : Request.QueryString["Model"].ToString();
            BuildTree("1",null);
            this.TreeView1.CollapseAll();
            this.TreeView1.Nodes[0].Expand();
            this.TreeView1.Nodes[0].Select();
            KNet.BLL.PB_Basic_ProductsClass BLL_Class = new KNet.BLL.PB_Basic_ProductsClass();
            if ((s_ID != "") && (s_Model == "IsDel"))
            {

                if ((AM.KNet_Position == "103") || (AM.KNet_StaffName == "李文立") || (AM.KNet_StaffName == "项洲") || (AM.KNet_StaffName == "毛刚挺"))
                {
                    if (AM.YNAuthority("停用产品") == true)
                    {
                        KNet.BLL.KNet_Sys_Products Bll = new KNet.BLL.KNet_Sys_Products();
                        KNet.Model.KNet_Sys_Products Model = Bll.GetModelB(s_ID);
                        Model.ProductsBarCode = s_ID;
                        int i_Del = Math.Abs(Model.KSP_Del - 1);
                        Model.KSP_Del = i_Del;
                        Bll.UpdateDel(Model);
                        AM.Add_Logs("系统设置--->产品字典--->产品字典 添加 操作成功！停用产品编码：" + s_ID);
                    }
                    else
                    {
                        AM.NoAuthority("停用产品");
                    }
                }
            }
            if ((s_ID != "") && (s_Model == "IsQr"))
            {
                if ((AM.KNet_Position == "103") || (AM.KNet_StaffName == "李文立") || (AM.KNet_StaffName == "项洲") || (AM.KNet_StaffName == "毛刚挺"))
                {
                    if (AM.YNAuthority("停用产品") == true)
                    {
                        KNet.BLL.KNet_Sys_Products Bll = new KNet.BLL.KNet_Sys_Products();
                        KNet.Model.KNet_Sys_Products Model = Bll.GetModelB(s_ID);
                        Model.ProductsBarCode = s_ID;
                        int i_Del = Math.Abs(Model.KSP_isModiy - 1);
                        Model.KSP_isModiy = i_Del;
                        Bll.UpdateisModiy(Model);
                        AM.Add_Logs("系统设置--->产品字典--->产品字典 添加 操作成功！确认产品编码：" + s_ID);
                    }
                    else
                    {
                        AM.NoAuthority("停用产品");
                    }
                }
            }
            this.Btn_Del.Attributes.Add("onclick", "return confirm('你确信要删除所选记录吗?！')");
            base.Base_DropBindSearch(this.bas_searchfield, "KNet_Sys_Products");
            base.Base_DropBindSearch(this.Fields, "KNet_Sys_Products");

            base.Base_DropBatchBindBySql(this.Ddl_Batch, "KNet_Sys_Products", "KSP_RDPerson", " and straffDepart='129652783965723459'");
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
        string s_ProductsBarCode = Request["ProductsBarCode"] == null ? "" : Request["ProductsBarCode"].ToString();
        string s_ID = Request["ID"] == null ? "" : Request["ID"].ToString();

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


        if (this.Ddl_Batch.SelectedValue != "")
        {
            SqlWhere += Base_GetBasicWhere(this.Ddl_Batch.SelectedValue);
        }
        if (s_ProductsBarCode != "")
        {
            SqlWhere += " and ProductsBarCode in ('" + s_ProductsBarCode + "') ";
        }
        if (s_ID != "")
        {
            SqlWhere += " and ProductsBarCode in ('" + s_ID + "') ";
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
               TextBox Tbx_BarCode= (TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_ProductsBarCode");
               s_BarCode += Tbx_BarCode.Text + ",";
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
        string s_Sql = "Select XPD_ProductsBarCode from Xs_Products_Prodocts_Demo where  XPD_ProductsBarCode in ('" + s_BarCode.Replace(",", "','") + "') ";
       this.BeginQuery(s_Sql);
       DataTable Dtb_Res = (DataTable)this.QueryForDataTable();
       if (Dtb_Res.Rows.Count > 0)
       {
           Alert("该产品有BOM使用不能删除！");
       }
       else
       {
           sql += " delete from Xs_Products_Prodocts_Demo where XPD_FaterBarCode in ('" + s_BarCode.Replace(",", "','") + "') ";
           sql += " delete from Xs_Products_Prodocts_Demo where XPD_ProductsBarCode in ('" + s_BarCode.Replace(",", "','") + "') ";
           sql += " delete from PB_Products_CgDays where PPC_ProductsBarCode in ('" + s_BarCode.Replace(",", "','") + "') ";
           sql += " delete from Xs_Customer_Products where XCP_ProductsID in ('" + s_BarCode.Replace(",", "','") + "') ";
           DbHelperSQL.ExecuteSql(sql);
           AdminloginMess LogAM = new AdminloginMess();
           LogAM.Add_Logs("系统设置--->产品字典--->产品字典删除 操作成功！");

           this.DataShows();
       }
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

    public string GetState(string s_ProductsBarCode, int s_Del)
    {
        string s_Return = "";
        try
        {

            if (s_Del == 1)
            {
                string JSD = "KnetProductsSetting_Details.aspx?BarCode=" + s_ProductsBarCode + "&Model=IsDel";
                s_Return = "<a href=\"" + JSD + "\" onclick=\"\"  target=\"_blank\" ><font color=red>停用</font></a>";
            }
            else
            {
                string JSD = "KnetProductsSetting_Details.aspx?BarCode=" + s_ProductsBarCode + "&Model=IsDel";
                s_Return = "<a href=\"" + JSD + "\" onclick=\"\"  target=\"_blank\" >启用</a>";
            }
        }
        catch
        { }
        return s_Return;
    }



    public string GetQr(string s_ProductsBarCode, int s_Del)
    {
        string s_Return = "";
        try
        {

            if (s_Del == 1)
            {
                string JSD = "KnetProductsSetting.aspx?ID=" + s_ProductsBarCode + "&Model=IsQr";
                s_Return = "<a href=\"" + JSD + "\" onclick=\"\" target=\"_blank\"  ><font color=red>未审</font></a>";
            }
            else
            {
                string JSD = "KnetProductsSetting.aspx?ID=" + s_ProductsBarCode + "&Model=IsQr";
                s_Return = "<a href=\"" + JSD + "\" onclick=\"\"  target=\"_blank\" >已审</a>";
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

    public void BuildTree(string s_ID, TreeNode tree)
    {
        try
        {
            KNet.BLL.PB_Basic_ProductsClass Bll = new KNet.BLL.PB_Basic_ProductsClass();
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


            DataSet Dts_Table = null;
            if (s_ID == "M160818111423567")//如果是采购类产品
            {
                Dts_Table = bll.GetList(" PBP_FaterID='" + s_ID + "'   order by PBP_Order");
            }
            else if (s_ID == "M160818111359632")//如果是销售类产品
            {
                KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
                string s_SonID = Bll_ProductsDetails.GetSonIDs(Tbx_Productstype.Text);
                s_SonID = s_SonID.Replace(",", "','");
                string s_Sql = "";
                if (Tbx_Productstype.Text != "")
                {
                    s_Sql = " PBP_FaterID='" + s_ID + "' and PBP_ID in ('" + Tbx_Productstype.Text + "','" + s_SonID + "')  order by PBP_Order";
                }
                else
                {
                    s_Sql = " PBP_FaterID='" + s_ID + "' order by PBP_Order";
                }
                
                Dts_Table = bll.GetList(s_Sql);
            }
            else
            {

                Dts_Table = bll.GetList(" PBP_FaterID='" + s_ID + "'  order by PBP_Order");
            }



            if (Dts_Table.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                {
                    TreeNode treeNode1 = new TreeNode();
                    treeNode1.Text = Dts_Table.Tables[0].Rows[i]["PBP_Name"].ToString();
                    treeNode1.Value = Dts_Table.Tables[0].Rows[i]["PBP_ID"].ToString();
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

    protected void Ddl_Batch_TextChanged(object sender, EventArgs e)
    {
        this.DataShows();
    }
    protected void Lbl_Spce_Click(object sender, EventArgs e)
    {
        string UploadPath = "../../UpFile/Products/产品型号命名规则.doc";  //上传文件
        Response.Redirect(UploadPath);
    }
}
