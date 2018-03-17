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
/// 选择指定仓库产品
/// </summary>
public partial class Knet_Common_SelectKNet_WareCheck_Ownall : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "仓库产品选择";

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
                        ViewState["SortOrder"] = "ProductsBarCode";
                        ViewState["OrderDire"] = "Desc";
                        this.Button2.Attributes.Add("onclick", "return confirm('您确定要把所选择的记录添加到明细记录吗？')");

                        BuildTree("1", null);
                        this.TreeView1.CollapseAll();
                        this.TreeView1.Nodes[0].Expand();
                        this.TreeView1.Nodes[0].Select();
                        this.DataShows();
                        this.RowOverYN();
                }
                else
                {
                    Response.Write("<script language=javascript>alert('请选择仓库！');window.close();</script>");
                    Response.End();
                }
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
        string s_Sql = "Select HouseNo,ProductsBarCode,Sum(directinamount) as WareHouseAmount,Sum(DirectInTotalNet) as Money,KSP_Code from v_Store  where ";

        if (Request["HouseNo"] != null && Request["HouseNo"] != "" && Request["HouseNo"] != "0")
        {
            string HouseNo = Request.QueryString["HouseNo"].ToString().Trim();
            s_Sql +=  "   HouseNo = '" + HouseNo + "' ";
        }
        else
        {
            s_Sql  +=  "  1=2 ";
        }

        if (Request["Stime"] != null )
        {
            string Stime = Request.QueryString["Stime"].ToString().Trim();
            s_Sql += " and  DirectInDateTime <= '" + Stime + "' ";
        }
        if (Request["Seackey"] != null && Request["Seackey"] != "" )
        {
            string Seackey = Request.QueryString["Seackey"].ToString().Trim();
            s_Sql += "  and ProductsBarCode in (select ProductsBarCode From Knet_Sys_Products where ProductsEdition like '%" + Seackey + "%' ) ";
        }

        if (this.TreeView1.SelectedNode.Value != "1")
        {
            KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
            string s_SonID = Bll_ProductsDetails.GetSonIDs(this.TreeView1.SelectedNode.Value);
            s_SonID = s_SonID.Replace(",", "','");
            s_Sql += " and ProductsType in ('" + s_SonID + "') ";
        }
        s_Sql += " group by HouseNo,ProductsBarCode,KSP_Code";
        this.BeginQuery(s_Sql);
        this.QueryForDataSet();
        DataSet Dts_Tabel = Dts_Result;
        GridView1.DataSource = Dts_Tabel;
        GridView1.DataBind();
    }


    /// <summary>
    /// 确定选择
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click(object sender, EventArgs e)
    {

        string s_Return = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox Chk = (CheckBox)this.GridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (Chk.Checked)
            {
                string s_ProductsBarCode = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_ProductsBarCode")).Text;
                string s_ProductsName = base.Base_GetProdutsName(s_ProductsBarCode);
                string s_ProductsEdition = base.Base_GetProductsEdition(s_ProductsBarCode);
                string s_Number = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_Number")).Text;
                string s_WareHouseAmount = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_WareHouseAmount")).Text;
                string s_Price = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_Price")).Text;
                string s_Money = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_Money")).Text;
                
                s_Number = s_Number == "" ? "0" : s_Number;
                s_WareHouseAmount = s_WareHouseAmount == "" ? "0" : s_WareHouseAmount;
                string s_LeftNumber = Convert.ToString(int.Parse(s_Number) - int.Parse(base.FormatNumber1(s_WareHouseAmount,0)));
                string s_Remark = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_Remark")).Text;
                s_Return += s_ProductsName + "," + s_ProductsBarCode + "," + s_ProductsEdition + "," + s_Number + "," + base.FormatNumber1(s_WareHouseAmount, 0) + "," + s_Price + "," + s_Remark + "," + s_Money + "|";
            }
        }
        StringBuilder s = new StringBuilder();
        s.Append("<script language=javascript>" + "\n");
        //s.Append("if(window.opener != undefined) {window.opener.returnValue='" + s_Return + "';} else{window.returnValue='" + s_Return + "';}" + "\n");
        s.Append("if (window.opener != undefined)\n");
        s.Append("{\n");
        s.Append("    window.opener.returnValue = '" + s_Return + "';\n");
        s.Append("    window.opener.SetReturnValueInOpenner_WareCheck_Ownall('" + s_Return + "');\n");
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
    protected void AddToKnet_Procure_OrdersList_Details(string WareCheckNo, string ProductsName, string ProductsBarCode, string ProductsPattern, string ProductsUnits, int WareCheckLossUp, int WareCheckAmount, decimal WareCheckUnitPrice, decimal WareCheckDiscount, decimal WareCheckTotalNet, string WareCheckRemarks, string OwnallPID)
    {
        KNet.BLL.KNet_WareHouse_WareCheckList_Details BLL = new KNet.BLL.KNet_WareHouse_WareCheckList_Details();
        KNet.Model.KNet_WareHouse_WareCheckList_Details model = new KNet.Model.KNet_WareHouse_WareCheckList_Details();

        model.WareCheckNo = WareCheckNo;
        model.ProductsName = ProductsName;
        model.ProductsBarCode = ProductsBarCode;
        model.ProductsPattern = ProductsPattern;
        model.ProductsUnits = ProductsUnits;

        model.WareCheckLossUp = WareCheckLossUp;
        model.WareCheckAmount = WareCheckAmount;
        model.WareCheckUnitPrice = WareCheckUnitPrice;
        model.WareCheckDiscount = WareCheckDiscount;
        model.WareCheckTotalNet = WareCheckTotalNet;
        model.WareCheckRemarks = WareCheckRemarks;
        model.OwnallPID = OwnallPID;
        
        try
        {
            if (BLL.Exists(WareCheckNo, ProductsBarCode, OwnallPID) == false)
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
    /// 取消所有已选中列
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
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
    /// 返回仓库名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetHouseName(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,HouseNo,HouseName from KNet_Sys_WareHouse where HouseNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["HouseName"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }

    /// <summary>
    /// 返回单位名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetUnitsName(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,UnitsNo,UnitsName from KNet_Sys_Units where UnitsNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["UnitsName"].ToString().Trim();
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
    protected void Button1_Click(object sender, EventArgs e)
    {

        string Seackey = KNetPage.KHtmlEncode(this.KNetSeachKey.Text.Trim());

        Response.Redirect("SelectKNet_WareCheck_Ownall.aspx?Seackey=" + Seackey + "&Stime=" + Request.QueryString["Stime"].Trim() + "&HouseNo=" + Request.QueryString["HouseNo"].Trim() + "&Sn=" + DateTime.Now.ToFileTimeUtc().ToString() + "");
        Response.End();
    }



    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        this.DataShows();
    }
}
