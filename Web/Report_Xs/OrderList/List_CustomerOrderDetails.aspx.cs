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
using System.IO;
using System.Text;
using System.Data.SqlClient;

using KNet.DBUtility;
using KNet.Common;

public partial class Web_Report_Xs_List_CustomerOrderDetails : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
          //  string s_Sql = "Select b.ProductsBarCode,c.CustomerName,b.ProductsName+'('+b.ProductsPattern+')' as ProductsName,b.ContractAmount,";
           // s_Sql += "b.ProductsBarCode,a.CustomerValue";
            //s_Sql += " from KNet_Sales_ContractList a join KNet_Sales_ContractList_Details b on a.ContractNo=b.ContractNo join KNet_Sales_ClientList c on a.CustomerValue=c.CustomerValue  ";
            string s_Sql = "Select ContractNo,CustomerName,ProductsEdition,ContractDateTime,case when ContractClass='129687502761283812' then '一般合同' when ContractClass='129687502876636011' then '备货合同' when ContractClass='101' then '销售出库' when  ContractClass='102' then '直接出库' end as type,case when len(ContractClass)>3 then Number else 0 end as Contractnumber,case when len(ContractClass)>3 then 0 else Number end as shipnumber,Price,Money From V_Customer_ShipContractList";
            s_Sql += " where 1=1";
            string s_StartDate = Request.QueryString["StartDate"] == null ? "" : Request.QueryString["StartDate"].ToString();
            string s_EndDate = Request.QueryString["EndDate"] == null ? "" : Request.QueryString["EndDate"].ToString();
            string s_CustomerValue = Request.QueryString["CustomerValue"] == null ? "" : Request.QueryString["CustomerValue"].ToString();
            string s_ProductsBarCode = Request.QueryString["ProductsBarCode"] == null ? "" : Request.QueryString["ProductsBarCode"].ToString();
            string s_CustomerTypes = Request.QueryString["CustomerTypes"] == null ? "" : Request.QueryString["CustomerTypes"].ToString();
            string s_Details = "", s_Style = "";
            string s_Head = "";
           

            if(s_StartDate!="")
            {
                s_Sql += " and ContractDateTime>='" + s_StartDate + "'";
            }
            if (s_EndDate != "")
            {
                s_Sql += " and ContractDateTime<='" + s_EndDate + "'";
            }
            if (s_CustomerValue != "")
            {
                s_Sql += " and  CustomerValue= '" + s_CustomerValue + "'";
            }
            if (s_ProductsBarCode != "")
            {
                s_Sql += " and ProductsBarCode = '" + s_ProductsBarCode + "'";
            }
            if(s_CustomerTypes!="")
            {
                s_Sql += " and CustomerValue in (select CustomerValue from KNet_Sales_ClientList where CustomerTypes='" + s_CustomerTypes + "' ) ";
            }
            s_Sql += "Order by CustomerName,ContractDateTime";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table=this.Dtb_Result;
            if(Dtb_Table.Rows.Count>0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
                    if(i%2==0)
                    {
                       s_Style="class='gg'";
                    }
                    else
                    {
                        s_Style="class='rr'";
                    }
                    s_Details += " <tr " + s_Style + " onmouseover='setActiveBG(this)'>\n";
                    s_Details += "<td align=center noWrap>" + (i + 1).ToString() + "</td>\n";
                    s_Details += "<td align=left noWrap>" + Dtb_Table.Rows[i][0].ToString() + "</td>\n";
                    s_Details += "<td align=left noWrap>" + Dtb_Table.Rows[i][1].ToString() + "</td>\n";
                    s_Details += "<td align=left noWrap>" + Dtb_Table.Rows[i][2].ToString() + "</td>\n";
                    if (Dtb_Table.Rows[i][3].ToString() == "")
                    {
                        s_Details += "<td align=left noWrap>" + Dtb_Table.Rows[i][3].ToString() + "</td>\n";
                    }
                    else
                    {
                        s_Details += "<td align=left noWrap>" + DateTime.Parse(Dtb_Table.Rows[i][3].ToString()).ToShortDateString() +"</td>\n";
                    }
                    s_Details += "<td align=left noWrap>" + Dtb_Table.Rows[i][4].ToString() + "</td>\n";
                    s_Details += "<td align=Right noWrap>" + FormatNumber(Dtb_Table.Rows[i][5].ToString(),0) + "</td>\n";
                    s_Details += "<td align=Right noWrap>" + FormatNumber(Dtb_Table.Rows[i][6].ToString(), 0) + "</td>\n";
                    s_Details += "<td align=Right noWrap>" + Dtb_Table.Rows[i][7].ToString() + "</td>\n";
                    s_Details += "<td align=Right noWrap>" + Dtb_Table.Rows[i][8].ToString() + "</td>\n";
                    s_Details +=" </tr>";
                }
            }

            s_Details += "</tbody></table></div>";

            AdminloginMess Am = new AdminloginMess();
            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\"> \n";
            s_Head += "<tr>\n<th  colspan=\"10\" align=\"center\" width=\"100%\" class=\"thsTitle\" noWrap><font width=\"100\" size=\"6\"><b>客户合同出货明细表</b></font></th>\n</tr>";
            s_Head += "<tr>\n<th  align=\"left\" width=\"100%\" class=\"thsTitle\" colspan=\"7\">" + "日期:" + s_StartDate + " 到 " + s_EndDate + "</th><th  align=\"right\"  class=\"thsTitle\" colspan=\"3\">" + "制表人:" + Am.KNet_StaffName + "</th>\n</tr>";
            s_Head += "<tr>\n<th class=\"thstyle\">序号</th>\n";
            s_Head += "<th class=\"thstyle\">编号</th>\n";
            s_Head += "<th class=\"thstyle\">客户</th>\n";
            s_Head += "<th class=\"thstyle\">产品名称</th>\n";
            s_Head += "<th class=\"thstyle\">发生日期</th>\n";
            s_Head += "<th class=\"thstyle\">类型</th>\n";
            s_Head += "<th class=\"thstyle\">订单数量</th>\n";
            s_Head += "<th class=\"thstyle\">发货数量</th>\n";
            s_Head += "<th class=\"thstyle\">单价</th>\n";
            s_Head += "<th class=\"thstyle\">金额</th>\n";
            s_Head += "</thead><tbody class=\"scrollContent\">";
            this.Lbl_Details.Text = s_Head+s_Details;

        }
    }
    public string GetShipNumber(string s_CustomerValue, string s_ProductsBarCode)//出库数量
    {
        this.BeginQuery("Select Sum(DirectoutAmount) From Knet_WareHouse_DirectOutList a join KNet_WareHouse_DirectOutList_Details b on a.DirectOutNo=b.DirectOutNo where Kwd_Type='101' and b.ProductsBarCode='" + s_ProductsBarCode + "' and a.KWD_Custmoer='" + s_CustomerValue + "' ");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            return Dtb_Result.Rows[0][0].ToString();
        }
        else
        {
            return "-";
        }
    }
    public string GetCkNumber(string s_ProductsBarCode)//库存数量
    {
        string s_Return = "";
        this.BeginQuery("Select Sum(DirectInAmount),HouseNo from v_Store where ProductsBarCode='" + s_ProductsBarCode + "' Group by  HouseNo");
        this.QueryForDataTable();
        
        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                s_Return += base.Base_GetHouseName(Dtb_Result.Rows[i][1].ToString()) + "（" + Dtb_Result.Rows[i][0].ToString() + "),";
            }
            s_Return = s_Return.Substring(0, s_Return.Length - 1) ;
        }
        else
        {
             s_Return="-";
        }
        return s_Return;

    }
}
