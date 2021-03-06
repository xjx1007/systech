﻿using System;
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
public partial class Knet_Common_SelectSuppliersPrice : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "供应商报价选择";

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
                BuildTree("1", null);
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
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.Knet_Procure_SuppliersPrice bll = new KNet.BLL.Knet_Procure_SuppliersPrice();
        string isModiy = Request.QueryString["isModiy"] == null ? "" : Request.QueryString["isModiy"].ToString();
        string s_ProductsID = Request.QueryString["sID"] == null ? "" : Request.QueryString["sID"].ToString();
        string s_ContractNo = Request.QueryString["Contract"] == null ? "" : Request.QueryString["Contract"].ToString();
        string s_Sql = "select  b.*,e.KSP_BigUnits,e.ProductsType,isnull(cc.PPB_BrandName,'') PPB_BrandName,e.ksp_Code from Knet_Procure_SuppliersPrice b  join KNet_Sys_Products e on e.ProductsBarCode=b.ProductsBarCode left join PB_Products_Brand cc on cc.PPB_ID=b.KPP_Brand ";
        s_Sql += "left join KNet_Sales_ContractList_Details a on a.ProductsBarCode=b.ProductsBarCode  and b.ProcureState=1 and isnull(KPP_Del,'0')='0' ";
        string SqlWhere = " where 1=1 and b.KPP_Del=0  and b.KPP_State=1  and e.KSP_Del=0 ";

        if (Request["SuppNo"] != null && Request["SuppNo"] != "")
        {
            string SuppNo = Request.QueryString["SuppNo"].ToString().Trim();
            SqlWhere = SqlWhere + " and b.SuppNo = '" + SuppNo + "' ";
        }

        if (Request["ScNo"] != null && Request["ScNo"] != "")
        {
            string SuppNo = Request.QueryString["ScNo"].ToString().Trim();
            SqlWhere = SqlWhere + " and b.ProductsBarCode in(select XPD_ProductsBarCode from v_Order_ProductsDemo_Details where OrderNo='" + Request["ScNo"].ToString()+ "'  ) ";
        }
        if (this.SeachKey.Text != "")
        {
            string KSeachKey = this.SeachKey.Text;
            SqlWhere = SqlWhere + " and ( e.ProductsName  like '%" + KSeachKey + "%' or e.ProductsPattern  like '%" + KSeachKey + "%' or e.ProductsEdition  like '%" + KSeachKey + "%' )";
        }

        if (this.Tbx_Code.Text != "")
        {
            string BarCode = this.Tbx_Code.Text;
            SqlWhere = SqlWhere + " and ( KSP_Code  like '%" + BarCode + "%'  )";
        }
        
        if (isModiy == "")
        {
            if (Request["Contract"] != null && Request["Contract"] != "")
            {
                string s_ContractNo1 = Request["Contract"].ToString();
                SqlWhere = SqlWhere + " and a.ContractNo in ('" + s_ContractNo1 .Replace(",","','")+ "')";
            }
        }
        if (this.TreeView1.SelectedNode.Value != "1")
        {
            KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
            string s_SonID = Bll_ProductsDetails.GetSonIDs(this.TreeView1.SelectedNode.Value);
            s_SonID = s_SonID.Replace(",", "','");
            SqlWhere += " and e.ProductsType in ('" + s_SonID + "') ";
        }
        if (s_ProductsID != "")
        {
            SqlWhere += " and b.ProductsBarCode not in ('" + s_ProductsID.Substring(0, s_ProductsID.Length - 1).Replace(",", "','") + "') ";
        }
        this.BeginQuery(s_Sql + SqlWhere);
        this.QueryForDataSet();
        DataSet ds = Dts_Result;
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "ID" };
        GridView1.DataBind();
        //if (ds.Tables[0].Rows.Count <= 0)
        //{
        //    if (s_ContractNo != "")
        //    {
        //        s_Sql = "select a.*,isnull(ProcureUnitPrice,0) ProcureUnitPrice,isnull(HandPrice,0) HandPrice,b.* from KNet_Sales_ContractList_Details a ";
        //        s_Sql += "left join  Knet_Procure_SuppliersPrice b on a.ProductsBarCode=b.ProductsBarCode and b.ProcureState=1 and isnull(KPP_Del,'0')='0' ";

        //        this.BeginQuery(s_Sql + SqlWhere);
        //        this.QueryForDataSet();
        //        DataSet ds1 = Dts_Result;
        //        GridView1.DataSource = ds1;
        //        GridView1.DataKeyNames = new string[] { "ID" };
        //        GridView1.DataBind();
        //    }

        //}
    }
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        this.DataShows();
    }

    /// <summary>
    /// 确定选择
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        string s_Return = "";
        KNet.BLL.Knet_Procure_SuppliersPrice BLL = new KNet.BLL.Knet_Procure_SuppliersPrice();

        string cal = "";
        string s_SuppNo1 = "";
        string s_String = "";
        int j = 0;
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {
                KNet.Model.Knet_Procure_SuppliersPrice model = BLL.GetModel(GridView1.DataKeys[i].Value.ToString());
                int s_Number = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_Number")).Text == "" ? 1 : int.Parse(((TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_Number")).Text);

                string s_SuppNo = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_SuppNo")).Text;

                string s_Remarks = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_Remark")).Text;
                string s_BrandName = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_BrandName")).Text;
                string s_BigUnits = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("BigUnits")).Text; 
                string ProductsUnits = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("ProductsUnits")).Text;
                string ksp_code= ((TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_Code")).Text;
                string ProductsBarCode = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("ProductsBarCode")).Text;
                string s_WareHouseNo = "";
                try
                {
                    KNet.BLL.KNet_Sys_WareHouse Bll = new KNet.BLL.KNet_Sys_WareHouse();
                    KNet.Model.KNet_Sys_WareHouse Model = Bll.GetModelBySuppNo(s_SuppNo);
                    s_WareHouseNo = Model.HouseNo;
                }
                catch
                { }
                KNet.BLL.KNet_Sys_Products Bll_Products = new KNet.BLL.KNet_Sys_Products();
                KNet.Model.KNet_Sys_Products Model_Products = Bll_Products.GetModelB(model.ProductsBarCode);
                string s_BZNumber = "0";
                if (Model_Products.KSP_BZNumber != 0)
                {
                    //如果是包装数量不为0
                    if (s_Number == 1)
                    {
                        s_Number = Model_Products.KSP_BZNumber;
                    }
                    else
                    {
                        s_BZNumber=Convert.ToString(s_Number/Model_Products.KSP_BZNumber);
                        if (Model_Products.KSP_BZNumber * int.Parse(s_BZNumber) < s_Number)
                        {
                            s_BZNumber = Convert.ToString(int .Parse(s_BZNumber)+1);
                            s_Number = int.Parse(s_BZNumber) * Model_Products.KSP_BZNumber;
                        }
                    }
                }

               
                string price = model.ProcureUnitPrice.ToString();
                if (s_BigUnits.Length > 0)
                {
                    string c = s_BigUnits.Remove(s_BigUnits.LastIndexOf("/"));
                    s_Number = s_Number / Convert.ToInt32(c);
                    ProductsUnits = s_BigUnits.Substring(s_BigUnits.LastIndexOf("/") + 1);
                    price = (decimal.Parse(price) * Convert.ToInt32(c)).ToString();
                }
                int sc = 0;
                if (Request.QueryString["SuppNo"].ToString() == "")
                {
                    s_Return += model.ProductsName + "," + model.ProductsBarCode + "," + model.ProductsPattern + "," + base.Base_GetProductsEdition(model.ProductsBarCode) + "," + s_Number.ToString() + "," + price + "," + Convert.ToString(s_Number * decimal.Parse(price)) + ",";
                    s_Return += 0 + "," + 0 + "," + s_Remarks + "," + s_SuppNo + "," + base.Base_GetSupplierName(s_SuppNo) + "," + s_WareHouseNo + "," + Model_Products.KSP_BZNumber.ToString() + "," + s_BZNumber + "," + s_BrandName + "," + s_BigUnits + "," + ProductsUnits + "|";
                }
                else
                {
                    s_Return += model.ProductsName + "," + model.ProductsBarCode + "," + model.ProductsPattern + "," + base.Base_GetProductsEdition(model.ProductsBarCode) + "," + s_Number.ToString() + "," + price + "," + Convert.ToString(s_Number * decimal.Parse(price)) + ",";
                    s_Return += model.HandPrice.ToString() + "," + Convert.ToString(s_Number * decimal.Parse(model.HandPrice.ToString())) + "," + s_Remarks + "," + s_SuppNo + "," + base.Base_GetSupplierName(s_SuppNo) + "," + s_WareHouseNo + "," + Model_Products.KSP_BZNumber.ToString() + "," + s_BZNumber + "," + s_BrandName + "," + s_BigUnits + "," + ProductsUnits + "|";
                }
              
                cal += GridView1.DataKeys[i].Value.ToString();
                if (j > 0)
                {
                    s_SuppNo1 = ((TextBox)GridView1.Rows[j - 1].Cells[0].FindControl("Tbx_SuppNo")).Text;
                    if (s_SuppNo1 != s_SuppNo)
                    {
                        s_String = "供应商不同，请重新选择";
                    }
                }
                j++;
            }
        }
        if (cal == "")
        {
            Response.Write("<script language=javascript>alert('您没有选择要操作的记录!');this.window.close();</script>");
            Response.End();
        } 
        else
        {
            if (s_String != "")
            {
                AlertAndGoBack(s_String);
            }
            else
            {
                StringBuilder s = new StringBuilder();
                s.Append("<script language=javascript>" + "\n");
                s.Append("if(window.opener != undefined) {window.opener.returnValue='" + s_Return + "';window.opener.SetReturnValueInOpenner_SuppliersPrice('" + s_Return + "')} ");
                s.Append( "else{window.returnValue='" + s_Return + "';}" + "\n");                
                s.Append("window.close();" + "\n");
                s.Append("</script>");
                Type cstype = this.GetType();
                ClientScriptManager cs = Page.ClientScript;
                string csname = "ltype";
                if (!cs.IsStartupScriptRegistered(cstype, csname))
                    cs.RegisterStartupScript(cstype, csname, s.ToString());
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
    }
    public string GetNumber(string s_ProductsBarCode)
    {
        if (Request["Contract"] != null && Request["Contract"] != "")
        {
                string s_ContractNo1 = Request["Contract"].ToString();
                string s_Sql = "Select Sum(ContractAmount+isnull(KSC_BNumber,0)-isnull(KSC_OrderBNumber,0)) From KNet_Sales_ContractList_Details Where ContractNo in ('" + s_ContractNo1.Replace(",", "','") + "') and ProductsBarCode='" + s_ProductsBarCode + "'";
                this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            if (this.Dtb_Result.Rows.Count > 0)
            {
                return Dtb_Result.Rows[0][0].ToString();
            }
            else
            {
                return "";
            }
        }
        else
        {
            return "";
        }
    }
    public string GetLinkScPlan(string s_SuppNo,string s_ProdcutsBarCode)
    {
        string s_Return = "";
        try
        {
            string s_Sql = "select top 1 * from Sc_Produce_Plan order by SPP_CTime desc";

        }
        catch
        { }
        return s_Return;

    }
}
