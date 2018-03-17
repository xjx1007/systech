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
using System.IO;
using System.Text;

using KNet.DBUtility;
using KNet.Common;

/// <summary>
/// 产品选择
/// </summary>
public partial class Knet_Common_SelectProducts : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "产品选择";

        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
            else
            {
                BuildTree("M160818111359632", null);
                this.TreeView1.CollapseAll();
                this.TreeView1.Nodes[0].Expand();
                this.TreeView1.Nodes[0].Select();
                this.DataShows();
            }
        }
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
    /// 是不是有记录
    /// </summary>
    protected void RowOverYN()
    {
        if (GridView1.Rows.Count == 0) //如果没有记录
        {
            this.Button2.Enabled = false;
        }
    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        string s_CustomerValue = Request.QueryString["CustomerValue"] == null ? "" : Request.QueryString["CustomerValue"].ToString();
        string s_ProductsID = Request.QueryString["sID"] == null ? "" : Request.QueryString["sID"].ToString();
        KNet.BLL.KNet_Sys_Products bll = new KNet.BLL.KNet_Sys_Products();
        this.BeginQuery("Select * from Xs_Customer_Products where XCP_CustomerID='" + s_CustomerValue + "' ");
        this.QueryForDataTable();
        DataTable Dtb_Table = this.Dtb_Result;
        string s_Sql = "select distinct a.ID,a.ProductsBarCode,a.ProductsName,a.ProductsPattern,a.ProductsMainCategory,a.ProductsUnits,a.ProductsCostPrice,a.ProductsSellingPrice,isnull(c.Contract_SalesUnitPrice,0) as Contract_SalesUnitPrice,a.ProductsEdition ";
        s_Sql += "from KNet_Sys_Products a left join Xs_Customer_Products b on b.XCP_ProductsID=a.ProductsBarCode";
        s_Sql += " left join KNet_Sales_ContractList_Details c on c.ProductsBarCode=a.ProductsBarCode  left join KNet_Sales_ContractList d on d.ContractNo=c.ContractNo ";

        string SqlWhere = " where 1=1 ";

        if (this.SeachKey.Text != "")
        {
            SqlWhere = SqlWhere + " and ( a.ProductsName like '%" + this.SeachKey.Text + "%' or a.ProductsBarCode  like '%" + this.SeachKey.Text + "%' or a.ProductsPattern  like '%" + this.SeachKey.Text + "%' )";
        }
        if (Dtb_Table.Rows.Count > 0)
        {

            SqlWhere += " and XCP_CustomerID='" + s_CustomerValue + "' ";
            //and d.CustomerValue='" + s_CustomerValue + "'
        }
        if (s_ProductsID != "")
        {
            SqlWhere += " and a.ProductsBarCode not in ('" + s_ProductsID.Substring(0, s_ProductsID.Length-1).Replace(",", "','") + "') ";
        }

        if (this.TreeView1.SelectedNode.Value != "1")
        {
            KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
            string s_SonID = Bll_ProductsDetails.GetSonIDs(this.TreeView1.SelectedNode.Value);
            s_SonID = s_SonID.Replace(",", "','");
            SqlWhere += " and ProductsType in ('" + s_SonID + "') ";
        }
        this.BeginQuery(s_Sql + SqlWhere);
        this.QueryForDataSet();
        DataSet ds = this.Dts_Result;

        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "ID" };
        GridView1.DataBind();

    }

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        this.DataShows();
    }

    /// <summary>
    /// 页内 搜索 （Y）
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click1(object sender, EventArgs e)
    {
        this.DataShows();
    }



    /// <summary>
    /// 确定完成
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        string s_Return="";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox Chk = (CheckBox)this.GridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (Chk.Checked)
            {
                string s_ProductsBarCode = GridView1.Rows[i].Cells[1].Text;
                string s_ProductsName = GridView1.Rows[i].Cells[2].Text;
                string s_ProductsPattern = GridView1.Rows[i].Cells[3].Text;
                string s_ProductsEdition = GridView1.Rows[i].Cells[4].Text;
                string s_Price = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_Price")).Text;
                string s_Number = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_Number")).Text;
                s_Price = s_Price == "" ? "0" : s_Price;
                s_Number = s_Number == "" ? "1" : s_Number;
                string s_Remark = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_Remark")).Text;
                decimal s_Money = decimal.Parse(s_Price) * decimal.Parse(s_Number);
                s_Return += s_ProductsName + "," + s_ProductsBarCode + "," + s_ProductsEdition + "," + s_Number + "," + s_Price + "," + s_Remark + "," + s_Money.ToString() + "|";
            }
        }
        StringBuilder s = new StringBuilder();
        s.Append("<script language=javascript>" + "\n"); 
        //s.Append("if(window.opener != undefined) {window.opener.returnValue='"+s_Return+"';} else{window.returnValue='"+s_Return+"';}" + "\n");
        s.Append("if (window.opener != undefined)\n");
        s.Append("{\n");
        s.Append("    window.opener.returnValue = '" + s_Return + "';\n");
        s.Append("    window.opener.SetReturnValueInOpenner_Products('" + s_Return + "');\n");
        s.Append("}\n");
        s.Append("else\n");
        s.Append("{\n");
        s.Append("    window.returnValue = '" + s_Return + "';\n");
        s.Append("}\n");
        s.Append("window.close();" + "\n");
        s.Append("</script>");
        Type cstype = this.GetType();
        ClientScriptManager cs = Page.ClientScript;
        string csname = "ltype";
        if (!cs.IsStartupScriptRegistered(cstype, csname))
            cs.RegisterStartupScript(cstype, csname, s.ToString());
    }
}
