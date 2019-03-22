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
/// 选择供应商采购报价
/// </summary>
public partial class Knet_Common_SelectProductsDemo : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "产品材料选择";

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
                string s_Details = Request.QueryString["Details"] == null ? "" : Request.QueryString["Details"].ToString();
                this.SeachKey.Text = s_Details;
        
                BuildTree("1", null);
                this.TreeView1.CollapseAll();
                this.TreeView1.Nodes[0].Expand();
                this.TreeView1.Nodes[0].Select();
                this.DataShows();
            }
        }
    }

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        this.DataShows();
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
        else
        {
            this.Button2.Enabled = true;
 
        }
    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.KNet_Sys_Products bll = new KNet.BLL.KNet_Sys_Products();

        string SqlWhere = " KSP_Del=0 ";

        string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
        string s_ProductsTypeID = Request.QueryString["ProductsTypeID"] == null ? "" : Request.QueryString["ProductsTypeID"].ToString();

        string s_CustomerValue = Request.QueryString["CustomerValue"] == null ? "" : Request.QueryString["CustomerValue"].ToString();
        s_ID = s_ID.Replace(",", "','");
        if (s_ID != "")
        {
            SqlWhere += " and ProductsBarCode not in ('" + s_ID + "')";
        }
        if (s_CustomerValue != "")
        {
            SqlWhere += " and ProductsBarCode in (Select XCP_ProductsID from Xs_Customer_Products where XCP_CustomerID='" + s_CustomerValue + "')";
        }
        if (Request["SuppNo"] != null && Request["SuppNo"] != "")
        {
            string SuppNo = Request.QueryString["SuppNo"].ToString().Trim();
            SqlWhere = SqlWhere + " and  SuppNo = '" + SuppNo + "' ";
        }

        if (this.SeachKey.Text != "")
        {
            string KSeachKey = this.SeachKey.Text;
            SqlWhere = SqlWhere + " and ( ProductsName like '%" + KSeachKey + "%' or ProductsBarCode  like '%" + KSeachKey + "%' or ProductsEdition  like '%" + KSeachKey + "%'  or ProductsPattern  like '%" + KSeachKey + "%' )";
        }

        if (this.TreeView1.SelectedNode.Value != "1")
        {
            KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
            string s_SonID = Bll_ProductsDetails.GetSonIDs(this.TreeView1.SelectedNode.Value);
            s_SonID = s_SonID.Replace(",", "','");
            SqlWhere += " and ProductsType in ('" + s_SonID + "') ";
        }
        if (s_ProductsTypeID != "")
        {
            SqlWhere += " and ProductsType in ('" + s_ProductsTypeID + "') ";
 
        }
        DataSet ds = bll.GetList(SqlWhere);
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "ID" };
        GridView1.DataBind();

        this.RowOverYN();
    }
    /// <summary>
    /// 确定选择
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        KNet.BLL.Knet_Procure_SuppliersPrice BLL = new KNet.BLL.Knet_Procure_SuppliersPrice();
        string cal = "";
        string s_Return = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {
                KNet.Model.Knet_Procure_SuppliersPrice model = BLL.GetModel(GridView1.DataKeys[i].Value.ToString());
                string s_ProductsBarCode = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("ProductsBarCode")).Text;
                string s_ProductsName = GridView1.Rows[i].Cells[1].Text;
                string s_ProdctsEdition = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("ProductsEdition")).Text;
                string s_ProductsCode = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("ProductsCode")).Text;
                //string ksp_Code= GridView1.Rows[i].Cells[2].Text;
                int s_Number = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_Number")).Text == "" ? 1 : int.Parse(((TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_Number")).Text);
                cal += s_ProductsBarCode;
                s_Return += s_ProductsBarCode + "," + s_ProductsName + "," + s_Number.ToString() + "," + s_ProdctsEdition + "," + s_ProductsCode + "|";
            }
        }

        if (cal == "")
        {
            Response.Write("<script language=javascript>alert('您没有选择记录！');window.close();</script>");
            Response.End();
        }
        else
        {
            StringBuilder s = new StringBuilder();
            s.Append("<script language=javascript>" + "\n");
            //s.Append("window.returnValue='" + s_Return + "';" + "\n");
            s.Append("if (window.opener != undefined)\n");
            s.Append("{\n");
            s.Append("    window.opener.returnValue = '" + s_Return + "';\n");
            if (Request.QueryString["callBack"] != null && Request.QueryString["callBack"] != "")
            {
                s.Append("    window.opener." + Request.QueryString["callBack"] + "('" + s_Return + "');\n");
            }
            else
            {
                s.Append("    window.opener.SetReturnValueInOpenner_ProductsDemo('" + s_Return + "');\n");
            }
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

    /// <summary>
    ///  添加到明细记录
    /// </summary>
    /// <param name="OrderNo"></param>
    /// <param name="ProductsName"></param>
    /// <param name="ProductsBarCode"></param>
    /// <param name="ProductsPattern"></param>
    /// <param name="ProductsUnits"></param>
    /// <param name="OrderAmount"></param>
    /// <param name="OrderUnitPrice"></param>
    /// <param name="OrderDiscount"></param>
    /// <param name="OrderTotalNet"></param>
    /// <param name="OrderRemarks"></param>
    protected void AddToKnet_Procure_OrdersList_Details(string OrderNo, string ProductsName, string ProductsBarCode, string ProductsPattern, string ProductsUnits, int OrderAmount, decimal OrderUnitPrice, decimal OrderDiscount, decimal OrderTotalNet, string OrderRemarks)
    {
        KNet.BLL.Knet_Procure_OrdersList_Details BLL = new KNet.BLL.Knet_Procure_OrdersList_Details();
        KNet.Model.Knet_Procure_OrdersList_Details model = new KNet.Model.Knet_Procure_OrdersList_Details();

        model.OrderNo = OrderNo;
        model.ProductsName = ProductsName;
        model.ProductsBarCode = ProductsBarCode;
        model.ProductsPattern = ProductsPattern;
        model.ProductsUnits = ProductsUnits;
        model.OrderAmount = OrderAmount;
        model.OrderUnitPrice = OrderUnitPrice;
        model.OrderDiscount = OrderDiscount;
        model.OrderTotalNet = OrderTotalNet;
        model.OrderRemarks = OrderRemarks;

        try
        {
            if (BLL.Exists(OrderNo, ProductsBarCode) == false)
            {
                BLL.Add(model);
            }
            else
            {
                BLL.UpdateB(model);
            }
        }
        catch { throw; }
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

    /// <summary>
    /// 搜索
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click1(object sender, EventArgs e)
    {
        this.DataShows();
        this.RowOverYN();
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
}
