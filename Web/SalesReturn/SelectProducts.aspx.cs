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
public partial class Knet_Common_SelectProducts : BasePage
{
    public string s_CustomerValue = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "产品选择";
        Ajax.Utility.RegisterTypeForAjax(typeof(Knet_Common_SelectProducts));
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
                s_CustomerValue = Request["CustomerValue"] == null ? "" : Request["CustomerValue"].ToString();
                string s_ContractNos = Request["ContractNo"] == null ? "" : Request["ContractNo"].ToString();
                string s_ProductsBarCode = Request["sID"] == null ? "" : Request["sID"].ToString();
                this.Tbx_ProductsBarCode.Text = s_ProductsBarCode;
                this.Tbx_Customer.Text = s_CustomerValue;
                this.Tbx_ContractNos.Text = s_ContractNos;
                if (s_CustomerValue == "")
                {

                    Response.Write("<script language=javascript>alert('请选择客户！');window.close();</script>");
                    Response.End();
                }
                else
                {
                    this.DataShows();
                }

            }
        }
    }

    [Ajax.AjaxMethod()]
    public string GetProductsInfo(string s_ProductsBarCode, string s_Custom, string d_Price1, string s_Number,string s_ID,string s_ContractNo)
    {
        string s_Return = "";
        try
        {
            KNet.BLL.KNet_Sys_Products BLL = new KNet.BLL.KNet_Sys_Products();
            KNet.Model.KNet_Sys_Products Model = BLL.GetModelB(s_ProductsBarCode);


            s_Return += Model.ProductsBarCode + "|" + base.Base_GetProdutsName(Model.ProductsBarCode) + "|" + base.Base_GetProductsEdition(Model.ProductsBarCode) + "|" + s_Number + "|" + d_Price1.ToString() + "|" + Convert.ToString(decimal.Parse(s_Number) * decimal.Parse(d_Price1)) + "|" + s_Number + "|" + "|" + s_ContractNo + "|" + s_ID + "|";
            return s_Return;
        }
        catch (Exception ex)
        {
            return s_Return;
        }
    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.KNet_Sys_Products bll = new KNet.BLL.KNet_Sys_Products();
        string SqlWhere = " 1=1 ";

        if (this.SeachKey.Text != "")
        {
            SqlWhere = SqlWhere + " and ( ProductsName like '%" + this.SeachKey.Text + "%' or a.ProductsBarCode  like '%" + this.SeachKey.Text + "%' or ProductsPattern  like '%" + this.SeachKey.Text + "%' )";
        }
        //该客户的产品
        if (this.Tbx_Customer.Text != "")
        {
            SqlWhere += " and v_CustomerValue='" + this.Tbx_Customer.Text + "' or v_CustomerValue In (select FaterCode from KNet_Sales_ClientList where  CustomerValue='" + this.Tbx_Customer.Text + "') ";
        }
        if (this.Tbx_ProductsBarCode.Text != "")
        {
            SqlWhere += " and a.ProductsBarCode Not in ('" + this.Tbx_ProductsBarCode.Text.Replace(",", "','") + "') ";
        }
        if (this.Tbx_ContractNos.Text != "")
        {

        }
        DataSet ds = bll.GetListByCustomer(SqlWhere);
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "ID" };
        GridView1.DataBind();
        //if (ds.Tables[0].Rows.Count <= 0)
        //{
        //    if (this.Tbx_Customer.Text != "")
        //    {
        //        SqlWhere = " and XCP_CustomerID='" + this.Tbx_Customer.Text + "' or XCP_CustomerID In (select FaterCode from KNet_Sales_ClientList where  CustomerValue='" + this.Tbx_Customer.Text + "')";
        //    }
        //    this.BeginQuery("Select *,0 as Price,0 as LeftNumber,0 as PNumber,0 as BNumber,0 as WNumber,0 as LeftNumber,0 as FHNumber from KNet_Sys_Products a  join Xs_Customer_Products b on a.ProductsBarCode=b.XCP_ProductsID " + SqlWhere);
        //    this.QueryForDataSet();
        //    GridView1.DataSource = this.Dts_Result;
        //    GridView1.DataKeyNames = new string[] { "ID" };
        //    GridView1.DataBind();
        //}
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

    public string GetLink(string s_ProductsBarCode, string s_Price, string s_LeftNumber,string s_ID,string s_ContractNo)
    {
        string s_Return = "";
        try
        {

            s_Return += "<a href=\"javascript:window.close();\" onclick='set_return_value(\"" + s_ProductsBarCode + "\",\"" + this.Tbx_Customer.Text + "\",\"" + s_Price + "\",\"" + s_LeftNumber + "\",\"" + s_ID + "\",\"" + s_ContractNo + "\");'>" + base.Base_GetProdutsName(s_ProductsBarCode) + "</a>";
        }
        catch
        {
            s_Return = "-";
        }
        return s_Return;
    }


}
