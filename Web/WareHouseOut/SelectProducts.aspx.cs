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
        this.Page.Title = "库存产品选择";

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
                if (Request.QueryString["HouseNo"] != null && Request.QueryString["HouseNo"] != "")
                {

                    BuildTree("1", null);
                    this.TreeView1.CollapseAll();
                    this.TreeView1.Nodes[0].Expand();
                    this.TreeView1.Nodes[0].Select();
                    this.DataShows();
                }
                else
                {
                    Response.Write("<script language=javascript>alert('请选择仓库！');window.close();</script>");
                    Response.End();
                }
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
        string s_HouseNo = Request.QueryString["HouseNo"] == null ? "" : Request.QueryString["HouseNo"].ToString();
        KNet.BLL.KNet_Sys_Products bll = new KNet.BLL.KNet_Sys_Products();
        string s_Sql = "Select a.Number,a.TotalNet,case when a.Number<>0 then a.TotalNet/a.Number else 0 end as Price,b.* from KNet_Sys_Products b left join v_ProdutsStore a on a.ProductsBarCode=b.ProductsBarCode Where HouseNo='" + s_HouseNo + "' ";
        if (this.SeachKey.Text != "")
        {
            s_Sql += " and  (ProductsEdition like '%" + this.SeachKey.Text + "%' or ProductsPattern like '%" + this.SeachKey.Text + "%') ";
        }

        if (this.TreeView1.SelectedNode.Value != "1")
        {
            KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
            string s_SonID = Bll_ProductsDetails.GetSonIDs(this.TreeView1.SelectedNode.Value);
            s_SonID = s_SonID.Replace(",", "','");
            s_Sql += " and b.ProductsType in ('" + s_SonID + "') ";
        }
        if (this.Tbx_Code.Text != "")
        {
            s_Sql += " and b.KSP_Code like '%" + this.Tbx_Code.Text + "%' ";
        }
        if (this.Tbx_ProductsEdition.Text != "")
        {
            s_Sql += " and b.ProductsEdition like '%" + this.Tbx_ProductsEdition.Text + "%' ";
        }
        s_Sql += "  ";
        this.BeginQuery(s_Sql);
        this.QueryForDataSet();
        DataSet ds = this.Dts_Result;
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "ProductsBarCode" };
        GridView1.DataBind();
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
    /// 页内 搜索 （Y）
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click1(object sender, EventArgs e)
    {
        this.DataShows();
    }



    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
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
                string s_ProductsBarCode = GridView1.DataKeys[i].Value.ToString();
                string s_ProductsName = GridView1.Rows[i].Cells[2].Text;
                string s_ProductsPattern = GridView1.Rows[i].Cells[3].Text;
                string s_ProductsEdition = GridView1.Rows[i].Cells[4].Text;
                string s_Number = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_Number")).Text;
                string s_Price = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_Price")).Text;
                s_Price = s_Price == "" ? "0" : s_Price;
                s_Number = s_Number == "" ? "1" : s_Number;
                string s_Remark = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_Remark")).Text;
                decimal s_Money = decimal.Parse(s_Price) * decimal.Parse(s_Number);
                s_Return += s_ProductsName + "," + s_ProductsBarCode + "," + s_ProductsEdition + "," + s_Number + "," + s_Price + "," + s_Remark + "," + s_Money.ToString() + "|";
            }
        }
        StringBuilder s = new StringBuilder();
        s.Append("<script language=javascript>" + "\n"); 
        s.Append("if(window.opener != undefined) {window.opener.returnValue='"+s_Return+"';} else{window.returnValue='"+s_Return+"';}" + "\n");
        s.Append("window.close();" + "\n");
        s.Append("</script>");
        Type cstype = this.GetType();
        ClientScriptManager cs = Page.ClientScript;
        string csname = "ltype";
        if (!cs.IsStartupScriptRegistered(cstype, csname))
            cs.RegisterStartupScript(cstype, csname, s.ToString());
    }
}
