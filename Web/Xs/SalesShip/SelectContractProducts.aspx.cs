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
public partial class SelectContractProducts : BasePage
{
    public string  s_CustomerValue="";
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "产品选择";
        Ajax.Utility.RegisterTypeForAjax(typeof(SelectContractProducts));
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
                string s_ID = Request["sID"] == null ? "" : Request["sID"].ToString();
                 this.Tbx_Customer.Text = s_CustomerValue;
                 this.Tbx_ContractNos.Text = s_ContractNos;
                 this.Tbx_ID.Text = s_ID;
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
    public string GetProductsInfo(string s_ID)
    {
        string s_Return = "";
        try
        {
            KNet.BLL.KNet_Sales_ContractList_Details BLL = new KNet.BLL.KNet_Sales_ContractList_Details();
            KNet.Model.KNet_Sales_ContractList_Details Model = BLL.GetModel(s_ID);

            int i_LeftNumber = 0,i_Number=0,i_BigNumber=0,i_ContractNumber=0;
            decimal d_Price = 0;
            this.BeginQuery("Select v_LeftOutWareTotalNumber from v_Contract_OutWare_DirectOut_Total where v_ContractNo='" + Model.ContractNo + "' and v_ProductsBarcode='" + Model.ProductsBarCode + "' ");
            this.QueryForDataTable();
            DataTable Dtb_T = Dtb_Result;
            if (Dtb_T.Rows.Count > 0)
            {
                i_LeftNumber = int.Parse(Dtb_T.Rows[0]["v_LeftOutWareTotalNumber"].ToString());
            }
            i_Number = i_LeftNumber;
            s_Return += Model.ProductsBarCode + "|" + Model.ProductsBarCode + "|" + base.Base_GetProdutsName(Model.ProductsBarCode) + "|" + base.Base_GetProductsEdition(Model.ProductsBarCode) + "|" + i_Number.ToString() + "|" + d_Price.ToString() + "|" + Convert.ToString(i_Number * d_Price) + "|" + i_Number.ToString() + "|" + Model.ContractAmount.ToString() + "|" + Model.ContractNo + "|"+Model.ID + "|";
            return s_Return;
        }
        catch(Exception ex)
        {
            return s_Return;
        }
    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.KNet_Sales_ContractList_Details bll = new KNet.BLL.KNet_Sales_ContractList_Details();
        string SqlWhere = " 1=1 ";

        if (this.SeachKey.Text != "")
        {
            SqlWhere = SqlWhere + " and ( b.ProductsName like '%" + this.SeachKey.Text + "%' or a.ProductsBarCode  like '%" + this.SeachKey.Text + "%' or b.ProductsEdition  like '%" + this.SeachKey.Text + "%' )";
        }
        //if (this.Tbx_Customer.Text != "")
        //{
        //    SqlWhere += " and CustomerValue='" + this.Tbx_Customer.Text + "' or CustomerValue In (select FaterCode from KNet_Sales_ClientList where  CustomerValue='" + this.Tbx_Customer.Text + "')";
        //}
        if (Tbx_ID.Text != "")
        {
            SqlWhere = SqlWhere + " and a.ID not in('" + this.Tbx_ID.Text.Replace(",", "','") + "')";
        }
        if (this.Tbx_ContractNos.Text != "")
        {
            SqlWhere = SqlWhere + " and ContractNo in('" + this.Tbx_ContractNos.Text.Replace(",","','") + "')";
        }
        DataSet ds = bll.GetList1(SqlWhere);
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "ID" };
        GridView1.DataBind();
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

    public string GetLink(string s_ID,string s_ProductsBarCode,string s_Price,string s_LeftNumber)
    {
        string s_Return = "";
        try
        {

            s_Return += "<a href=\"javascript:window.close();\" onclick='set_return_value(\"" + s_ID + "\");'>" + base.Base_GetProdutsName(s_ProductsBarCode) + "</a>";


        }
        catch
        {
            s_Return = "-";
        }
        return s_Return;
    }


}
