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

public partial class Web_SalesQuotes_Xs_Sales_Quotes_Print : BasePage
{
    public string s_Company = "", s_LinkMan = "", s_CustomerName = "", s_DutypersonName = "", s_Table = "";
    public string s_MyTable_Detail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
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
            string s_Sql = "Select * from Knet_Procure_WareHouseList_Details a join Knet_Procure_WareHouseList b on a.WareHouseNo=b.WareHouseNo ";
            s_Sql += " join Knet_Procure_OrdersList c on b.OrderNo=c.OrderNo ";
            s_Sql += " where b.KPW_Del='0' and b.KPO_QRState=0  ";
            if (s_ID != "")
            {
                s_Sql += " and HouseNo='" + s_ID + "'";
            }
            this.BeginQuery(s_Sql);
            DataSet Dts_Details = (DataSet)this.QueryForDataSet();
            if (Dts_Details.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_Details.Tables[0].Rows.Count; i++)
                {
                    s_MyTable_Detail += "<tr>";



                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["OrderNo"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["ParentOrderNo"].ToString() + "</td>";

                    try
                    {
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + DateTime.Parse(Dts_Details.Tables[0].Rows[i]["KPO_CheckTime"].ToString()).ToShortDateString() + "</td>";
                    }
                    catch
                    { }
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetSupplierName(Dts_Details.Tables[0].Rows[i]["SuppNo"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsCode(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["WareHouseAmount"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["WareHouseBAmount"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["WareHouseRemarks"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">&nbsp;</td>";
                    s_MyTable_Detail += "</tr>";
                }
            }

        }
        catch
        { }
    }
}
