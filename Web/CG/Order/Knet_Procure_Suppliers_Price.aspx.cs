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
/// 采购管理-----供应商采购报价 管理
/// </summary>
public partial class Knet_Web_Procure_Knet_Procure_Suppliers_Price : BasePage
{
    public string s_DivStyle = "";
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Lbl_Title.Text = "采购报价列表";
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin(this.Lbl_Title.Text) == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            Base_DropSupp(this.Ddl_Supp);

            //采购报价
            if (AM.YNAuthority("删除采购报价") == false)
            {
                this.Btn_Del.Enabled = false;
            }
            base.Base_DropBindSearch(this.bas_searchfield, "Knet_Procure_SuppliersPrice");
            base.Base_DropBindSearch(this.Fields, "Knet_Procure_SuppliersPrice");
            this.Btn_Del.Attributes.Add("onclick", "return confirm('你确信要删除所选记录吗?！')");
            BuildTree("1", null);
            this.TreeView1.CollapseAll();
            this.TreeView1.Nodes[0].Expand();
            this.TreeView1.Nodes[0].Select();
            this.DataShows();
            this.RowOverYN();
            //供应链平台经理 薛建新 总经理
            if (((AM.KNet_StaffDepart == "129652784259578018") && (AM.KNet_Position == "102")) || (AM.KNet_StaffName == "薛建新") || (AM.KNet_StaffDepart == "129652783693249229")||(AM.YNAuthority("采购价格审批")==true))
            {
                Btn_Sp.Visible = true;
                Btn_Sp1.Visible = true;
            }
            else
            {
                Btn_Sp.Visible = false;
                Btn_Sp1.Visible = false;
            }
           
        }

    }
    /// <summary>
    /// 是不是有记录
    /// </summary>
    protected void RowOverYN()
    {
        if (GridView1.Rows.Count == 0) //如果没有记录
        {
            this.Btn_Del.Enabled = false;
        }
    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
       
        KNet.BLL.Knet_Procure_SuppliersPrice bll = new KNet.BLL.Knet_Procure_SuppliersPrice();

        string SqlWhere = " 1=1 "; 
        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string s_BarCode = Request["BarCode"] == null ? "" : Request["BarCode"].ToString();
        string s_ProductsBarCode = Request.QueryString["ProductsBarCode"] == null ? "" : Request.QueryString["ProductsBarCode"].ToString();
        string s_Type = "";

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
        if (s_BarCode != "")
        {
            SqlWhere += " and a.ProductsBarCode='" + s_BarCode + "'";
        }
        if (s_ProductsBarCode != "")
        {
            SqlWhere += " and a.ProductsBarCode='" + s_ProductsBarCode + "'";
        }
        if (this.TreeView1.SelectedNode.Value != "1")
        {
            KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
            string s_SonID = Bll_ProductsDetails.GetSonIDs(this.TreeView1.SelectedNode.Value);
            s_SonID = s_SonID.Replace(",", "','");
            SqlWhere += " and v_ProductsType in ('" + s_SonID + "') ";
        }
        if (Ddl_Supp.SelectedValue != "")
        {
            SqlWhere += " and  suppNo='"+this.Ddl_Supp.SelectedValue+"'";
        }
        if (AM.YNAuthority("查看物料报价"))
        {
            SqlWhere += " and  b.v_KSP_Code like '02%'";
        }
        if (AM.YNAuthority("查看所有报价"))
        {
            
        }
        if (AM.YNAuthority("查看加工费报价"))
        {
            SqlWhere += " and  b.v_KSP_Code not like '02%'";
        }
        SqlWhere += "  order by ProcureUpdateDateTime desc ";
        DataSet ds = bll.GetList(SqlWhere);
            GridView1.DataSource = ds;
            GridView1.DataKeyNames = new string[] { "ID" };
            GridView1.DataBind();
    }


    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        this.DataShows();
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

            DataSet Dts_Table = bll.GetList(" PBP_FaterID='" + s_ID + "'");


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
    protected void Btn_SpSave(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        //批量审批
        KNet.BLL.Knet_Procure_SuppliersPrice Bll = new KNet.BLL.Knet_Procure_SuppliersPrice();
        try
        {
            string s_Logs = "";
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {

                CheckBox Ckb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
                if (Ckb.Checked)
                {
                    string s_ID = GridView1.DataKeys[i].Value.ToString();
                    KNet.Model.Knet_Procure_SuppliersPrice Model = new KNet.Model.Knet_Procure_SuppliersPrice();
                    Model.ID = s_ID;
                    Model.KPP_State = 1;
                    Model.KPP_ShPerson = AM.KNet_StaffNo;
                    Model.KPP_ShTime = DateTime.Now;
                    Bll.UpdateState(Model);
                    s_Logs = s_ID + ",";
                }
                AM.Add_Logs("批量审批价格：" + s_Logs + "");
                AlertAndRedirect("审批成功！", "Knet_Procure_Suppliers_Price.aspx?WhereID=M160707014101612");
            }
        }
        catch { }
    }


    protected void Btn_SpSave1(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        //批量审批
        KNet.BLL.Knet_Procure_SuppliersPrice Bll = new KNet.BLL.Knet_Procure_SuppliersPrice();
        try
        {
            string s_Logs = "";
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {

                CheckBox Ckb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
                if (Ckb.Checked)
                {
                    string s_ID = GridView1.DataKeys[i].Value.ToString();
                    KNet.Model.Knet_Procure_SuppliersPrice Model = new KNet.Model.Knet_Procure_SuppliersPrice();
                    Model.ID = s_ID;
                    Model.KPP_State = 2;
                    Model.KPP_ShPerson = AM.KNet_StaffNo;
                    Model.KPP_ShTime = DateTime.Now;
                    Bll.UpdateState(Model);
                    s_Logs = s_ID + ",";
                }
                AM.Add_Logs("批量审批价格：" + s_Logs + "");
                AlertAndRedirect("审批成功！", "Knet_Procure_Suppliers_Price.aspx?WhereID=M160707014101612");
            }
        }
        catch { }
    }

    protected void Ddl_Supp_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataShows();
    }
    protected void Btn_Del_Click(object sender, ImageClickEventArgs e)
    {

        string sql = "Update  Knet_Procure_SuppliersPrice set KPP_Del='1' where";
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
        LogAM.Add_Logs("采购入库--->供应商报价--->供应商报价记录 删除 操作成功！");

        this.DataShows();
        this.RowOverYN();
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
    public string GetShState(string s_State)
    {
        string s_Return = "";
        s_Return = base.Base_GetBasicCodeName("132", s_State);
        if(s_Return=="未审核")
        {
            s_Return="<font color=red>未审核</font>";
        }
        else if (s_Return == "不通过")
        {
            s_Return = "<font color=bule>不通过</font>";
        }
        else
        {
            s_Return="<font color=green>已审核 </font>";
        }
        return s_Return;
    }

    protected void GridView1_DataRowBinding(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string ID = GridView1.DataKeys[e.Row.RowIndex].Value.ToString(); //获取ID值

            KNet.BLL.Knet_Procure_SuppliersPrice Bll = new KNet.BLL.Knet_Procure_SuppliersPrice();
            KNet.Model.Knet_Procure_SuppliersPrice Model = Bll.GetModel(ID);
            CheckBox cb = (CheckBox)e.Row.Cells[1].FindControl("Chbk");
            if (Model.KPP_State==1)
            {
                cb.Enabled = false;
            }
            else
            {
                cb.Enabled = true;
            }
        }
    }
}
