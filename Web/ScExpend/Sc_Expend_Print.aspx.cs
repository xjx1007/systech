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


public partial class Sc_Plan_Print : BasePage
{
    public string s_MyTable_Detail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            if (s_ID != "")
            {
                ShowInfo(s_ID);
            }
        }
       
    }

    private void ShowInfo(string s_ID)
    {
        try
        {

            KNet.BLL.Sc_Produce_Plan BLL = new KNet.BLL.Sc_Produce_Plan();
            KNet.Model.Sc_Produce_Plan Model = BLL.GetModel(s_ID);
            this.Lbl_SuppNo.Text = base.Base_GetSupplierName(Model.SPP_SuppNo);
            this.Lbl_Person.Text = base.Base_GetUserName(Model.SPP_Creator);
            this.Lbl_CTimes.Text = Model.SPP_Ctime.ToString();
            this.Lbl_Remarks.Text = Model.SPP_Remarks;
            KNet.BLL.Sc_Produce_Plan_Details Bll_Details = new KNet.BLL.Sc_Produce_Plan_Details();
            DataSet Dts_Table = Bll_Details.GetList(" SPD_FaterID='" + s_ID + "'");

            if (Dts_Table.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                {
                    KNet.BLL.Knet_Procure_OrdersList_Details Bll_OrderDetails = new KNet.BLL.Knet_Procure_OrdersList_Details();
                    KNet.Model.Knet_Procure_OrdersList_Details Model_OrderDetails = Bll_OrderDetails.GetModel(Dts_Table.Tables[0].Rows[i]["SPD_OrderNo"].ToString());
                    KNet.BLL.Knet_Procure_OrdersList Bll_Order = new KNet.BLL.Knet_Procure_OrdersList();
                    KNet.Model.Knet_Procure_OrdersList Model_Order = Bll_Order.GetModelB(Model_OrderDetails.OrderNo);
                    KNet.BLL.KNet_Sales_ContractList Bll_Contract = new KNet.BLL.KNet_Sales_ContractList();
                    KNet.Model.KNet_Sales_ContractList Model_Contract = Bll_Contract.GetModelB(Model_Order.ContractNo);
                    KNet.BLL.KNet_Sales_OutWareList_FlowList Bll_FlowList = new KNet.BLL.KNet_Sales_OutWareList_FlowList();
                    DataSet Dts_FlowTable = Bll_FlowList.GetList("  OutWareNo='" + Model_Order.OrderNo + "' ");
                    KNet.BLL.KNet_Sys_WareHouse Bll_House = new KNet.BLL.KNet_Sys_WareHouse();
                    DataSet Dts_HouseTable = Bll_House.GetList(" SuppNo='"+Model_Order.SuppNo+"' ");

                    s_MyTable_Detail += " <tr>";
                    s_MyTable_Detail += "<td align=\"left\">" + (i + 1) + "</td>";
                    s_MyTable_Detail += "<td align=\"left\">" + Model_OrderDetails.OrderNo + "</td>";

                    try
                    {
                        s_MyTable_Detail += "<td align=\"left\">" + base.Base_GetCustomerName(Model_Contract.CustomerValue) + "</td>";
                    }
                    catch
                    {
                        s_MyTable_Detail += "<td align=\"left\">&nbsp;</td>";
                    }
                    try
                    {
                        s_MyTable_Detail += "<td align=\"left\">" + base.Base_GetSupplierName(Model_Order.SuppNo) + "<HR/>" + base.Base_GetProductsEdition(Model_OrderDetails.ProductsBarCode) + "</td>";
                    }
                    catch
                    {
                        s_MyTable_Detail += "<td align=\"left\">&nbsp;</td>";
                    }
                    try
                    {
                        s_MyTable_Detail += "<td align=\"left\">" + Model_OrderDetails.OrderAmount + "</td>";
                    }
                    catch
                    {
                        s_MyTable_Detail += "<td align=\"left\">&nbsp;</td>";
                    }
                    try
                    {
                        s_MyTable_Detail += "<td align=\"left\">";
                        string s_Details = "";
                        if (Dts_FlowTable.Tables[0].Rows.Count > 0)
                        {
                            for (int j = 0; j < Dts_FlowTable.Tables[0].Rows.Count; j++)
                            { 
                                s_Details+="<font size=2>"+Dts_FlowTable.Tables[0].Rows[j]["FollowText"].ToString()+"</font><br>";
                            }
                        }
                        if (s_Details != "")
                        {
                            s_Details = s_Details.Substring(0, s_Details.Length - 4);
                        }
                        s_MyTable_Detail += s_Details + "</td>";
                    }
                    catch(Exception ex)
                    {
                        s_MyTable_Detail += "<td align=\"left\">&nbsp;</td>";
                    }

                    try
                    {
                        string s_CKDetails = "";
                        if (Dts_HouseTable.Tables[0].Rows.Count > 0)
                        {
                            for (int j = 0; j < Dts_HouseTable.Tables[0].Rows.Count; j++)
                            {
                                s_CKDetails += Dts_HouseTable.Tables[0].Rows[j]["HouseName"].ToString() + "(" + base.Base_GetWareHouseNumber(Dts_HouseTable.Tables[0].Rows[j]["HouseNo"].ToString(), Model_OrderDetails.ProductsBarCode) + ")";
                            }
                        }
                        s_MyTable_Detail += "<td align=\"left\">" + s_CKDetails + "</td>";
                    }
                    catch
                    {
                        s_MyTable_Detail += "<td align=\"left\">&nbsp;</td>";
                    }
                    try
                    {
                        s_MyTable_Detail += "<td align=\"left\">" + DateTime.Parse(Dts_Table.Tables[0].Rows[i]["SPD_BeginTime"].ToString()).ToShortDateString() + "<HR>" + DateTime.Parse(Dts_Table.Tables[0].Rows[i]["SPD_EndTime"].ToString()).ToShortDateString() + "</td>";
                    }
                    catch
                    {
                        s_MyTable_Detail += "<td align=\"left\">&nbsp;</td>";
                    }
                    
                    try
                    {
                        s_MyTable_Detail += "<td align=\"left\">" + GetOrderDetails(Model_Order.SuppNo,Model_OrderDetails.ProductsBarCode, "1") + "</td>";
                    }
                    catch
                    {
                        s_MyTable_Detail += "<td align=\"left\">&nbsp;</td>";
                    }

                    try
                    {
                        s_MyTable_Detail += "<td align=\"left\">" + GetOrderDetails(Model_Order.SuppNo, Model_OrderDetails.ProductsBarCode, "2") + "</td>";
                    }
                    catch
                    {
                        s_MyTable_Detail += "<td align=\"left\">&nbsp;</td>";
                    }

                    try
                    {
                        s_MyTable_Detail += "<td align=\"left\">" + GetOrderDetails(Model_Order.SuppNo, Model_OrderDetails.ProductsBarCode, "3") + "</td>";
                    }
                    catch
                    {
                        s_MyTable_Detail += "<td align=\"left\">&nbsp;</td>";
                    }


                    try
                    {
                        s_MyTable_Detail += "<td align=\"left\">" + GetOrderDetails(Model_Order.SuppNo, Model_OrderDetails.ProductsBarCode, "4") + "</td>";
                    }
                    catch
                    {
                        s_MyTable_Detail += "<td align=\"left\">&nbsp;</td>";
                    }

                    try
                    {
                        s_MyTable_Detail += "<td align=\"left\">" + GetOrderDetails(Model_Order.SuppNo, Model_OrderDetails.ProductsBarCode, "5") + "</td>";
                    }
                    catch
                    {
                        s_MyTable_Detail += "<td align=\"left\">&nbsp;</td>";
                    }

                    try
                    {
                        s_MyTable_Detail += "<td align=\"left\">" + GetOrderDetails(Model_Order.SuppNo, Model_OrderDetails.ProductsBarCode, "6") + "</td>";
                    }
                    catch
                    {
                        s_MyTable_Detail += "<td align=\"left\">&nbsp;</td>";
                    }

                    s_MyTable_Detail += " </tr>";

                }
            }
        }
        catch { }
    }

    public string GetOrderDetails(string s_SuppNo, string s_ProductsBarCode, string s_OrderType)
    {
        string s_Return = "", s_ListProductsBarCode = "", s_HouseNo = "", s_HouseName = "";
        string s_Sql = "Select b.ProductsBarCode from  Xs_Products_Prodocts a ";
        s_Sql += " left join KNet_Sys_Products b on b.ProductsBarCode=a.XPP_ProductsBarCode";//明细的产品
        s_Sql += " where a.XPP_FaterBarCode='" + s_ProductsBarCode + "' ";//未入库的原材料订单
        if (s_OrderType == "1")//芯片
        {
            s_Sql += " and b.ProductsName like '%芯片%' ";
        }
        else if (s_OrderType == "2")//导电胶
        {
            s_Sql += " and b.ProductsName like '%导电胶%' ";
        }
        else if (s_OrderType == "3")//塑壳
        {
            s_Sql += " and b.ProductsName like '%塑壳%' ";
        }
        else if (s_OrderType == "4")//PCB
        {
            s_Sql += " and b.ProductsName like '%PCB%' ";
        }
        else if (s_OrderType == "5")//发射管
        {
            s_Sql += " and b.ProductsName like '%发射管%' ";
        }
        else if (s_OrderType == "6")//发射管
        {
            s_Sql += " and b.ProductsName like '%电池%' ";
        }
        this.BeginQuery(s_Sql);
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            s_ListProductsBarCode = Dtb_Result.Rows[0][0].ToString();
        }
        this.BeginQuery("Select * from KNet_Sys_WareHouse Where SuppNo='" + s_SuppNo + "'");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            s_HouseNo = Dtb_Result.Rows[0]["HouseNo"].ToString();
            s_HouseName = Dtb_Result.Rows[0]["HouseName"].ToString();
        }
        //查询该品种的订单
        string s_DetailsSql = " Select Sum(OrderAmount) from Knet_Procure_OrdersList_Details a join Knet_Procure_OrdersList b on a.OrderNo=b.OrderNo ";
        s_DetailsSql += " Where a.ProductsBarCode='" + s_ListProductsBarCode + "' and KPO_RkState=0";
        this.BeginQuery(s_DetailsSql);
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            s_Return = "<Font Color=Red>" + Dtb_Result.Rows[0][0].ToString() + "</Font><HR/><Font Color=Green>" + base.Base_GetWareHouseNumber(s_HouseNo, s_ListProductsBarCode) + "</Font>";
        }
        //if (s_Return != "")
        //{
        //    s_Return += "<br><a href='SC_Plan_Manage.aspx?ProductsBarCode=" + s_ListProductsBarCode + "'>详细</a>";
        //}
        return s_Return;
    }
}
