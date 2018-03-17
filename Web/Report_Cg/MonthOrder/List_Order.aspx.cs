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

public partial class Web_Report_CG_List_Order : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string s_Year = Request.QueryString["Year"] == null ? "" : Request.QueryString["Year"].ToString();
            string s_SuppNoValue = Request.QueryString["SuppNoValue"] == null ? "" : Request.QueryString["SuppNoValue"].ToString();
            string s_OrderType = Request.QueryString["OrderType"] == null ? "" : Request.QueryString["OrderType"].ToString();
            string s_ProductsType = Request.QueryString["ProductsType"] == null ? "" : Request.QueryString["ProductsType"].ToString();

            string s_DutyPerson = Request.QueryString["DutyPerson"] == null ? "" : Request.QueryString["DutyPerson"].ToString();
            string s_ProductsEdition = Request.QueryString["ProductsEdition"] == null ? "" : Request.QueryString["ProductsEdition"].ToString();

            string s_Sql = "select  c.SuppName,c.SuppNo,";
            for (int i = 1; i <= 12; i++)
            {
                s_Sql += " Sum( case when Year(OrderDateTime)='" + s_Year + "' and Month(OrderDateTime)='" + i.ToString() + "' then OrderAmount else 0 end) as OrderAmount" + i.ToString() + ",  ";
                s_Sql += " Sum( case when Year(OrderDateTime)='" + s_Year + "' and Month(OrderDateTime)='" + i.ToString() + "' then OrderTotalNet+isnull(HandTotal,0) else 0 end) as Money" + i.ToString() + ", ";
            }
            s_Sql += "c.SuppCode from Knet_Procure_OrdersList a  join Knet_Procure_OrdersList_Details b on a.OrderNo=b.OrderNo join Knet_Procure_Suppliers c on c.SuppNo=a.Suppno join KNet_Sys_ProcureType d on d.ProcureTypeValue=a.OrderType join KNet_Sys_Products e on b.ProductsBarCode=e.ProductsBarCode ";
            //  string s_Sql = "Select b.ProductsBarCode,c.CustomerName,b.ProductsPattern as ProductsName,Sum(Case When a.ContractClass='129687502761283812' then b.ContractAmount else 0 end ) as Number,";
            //s_Sql += "Sum(Case When a.ContractClass='129687502761283812' then 0 else b.ContractAmount end ) as BackNumber,b.ProductsBarCode,a.CustomerValue";
            //s_Sql += " from KNet_Sales_ContractList a join KNet_Sales_ContractList_Details b on a.ContractNo=b.ContractNo join KNet_Sales_ClientList c on a.CustomerValue=c.CustomerValue  ";
            s_Sql += " where a.KPO_Del=0 ";
            string s_Details = "", s_Style = "";
            string s_Head = "";

            if (s_SuppNoValue != "")
            {
                s_Sql += " and a.SuppNo = '" + s_SuppNoValue + "'";
            }
            if (s_OrderType != "")
            {
                s_Sql += " and a.OrderType='" + s_OrderType + "'";
            }
            if (s_ProductsEdition != "")
            {
                s_Sql += " and e.ProductsEdition like '%" + s_ProductsEdition + "%'";
            }
            if (s_DutyPerson != "")
            {
                s_Sql += " and a.OrderStaffNo ='" + s_DutyPerson + "'";
            }
            if (s_ProductsType != "")
            {
                KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
                string s_SonID = Bll_ProductsDetails.GetSonIDs(s_ProductsType);
                s_SonID = s_SonID.Replace(",", "','");
                s_Sql += " and e.ProductsType in ('" + s_SonID + "') ";
            }
            s_Sql += " and a.suppNO in(Select distinct suppNo from Knet_Procure_OrdersList where Year(OrderDateTime)='" + s_Year + "')";
            s_Sql += "Group by c.SuppName,c.SuppCode,c.SuppNo  Order by c.SuppName";
            decimal[] d_Total = new decimal[12];
            decimal[] d_TotalNumber = new decimal[12];
            for (int i_Month = 0; i_Month <= 11; i_Month++)
            {
                d_Total[i_Month] = 0;
                d_TotalNumber[i_Month] = 0;
            }
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        s_Style = "class='gg'";
                    }
                    else
                    {
                        s_Style = "class='rr'";
                    }
                    s_Details += " <tr " + s_Style + " onmouseover='setActiveBG(this)'>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + (i + 1) + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap><a href=\"../ChartMonthOrder/List_Order.aspx?SuppNoValue=" + Dtb_Table.Rows[i]["SuppNo"].ToString() + "&Year=" + s_Year + "\" target=\"_blank\">" + Dtb_Table.Rows[i]["SuppName"].ToString() + "</a></td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + Dtb_Table.Rows[i]["SuppCode"].ToString() + "</td>\n";

                    for (int i_Month = 1; i_Month <= 12; i_Month++)
                    {
                        s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + FormatNumber1(Dtb_Table.Rows[i]["OrderAmount" + i_Month + ""].ToString(), 0) + "</td>\n";
                        s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + FormatNumber1(Dtb_Table.Rows[i]["Money" + i_Month + ""].ToString(), 3) + "</td>\n";
                    }
                    s_Details += " </tr>";
                    for (int i_Month = 0; i_Month <= 11; i_Month++)
                    {
                        int i_Num = i_Month + 1;
                        d_Total[i_Month] += decimal.Parse(Dtb_Table.Rows[i]["OrderAmount" + i_Num + ""].ToString());
                        d_TotalNumber[i_Month] = decimal.Parse(Dtb_Table.Rows[i]["Money" + i_Num + ""].ToString());
                    }
                }
            }

            s_Details += " <tr >\n";
            s_Details += "<td align=left class='thstyleLeftDetails' noWrap colspan=\"3\">合计：</td>\n";

            for (int i_Month = 0; i_Month <= 11; i_Month++)
            {
                int i_Num = i_Month + 1;
                s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + FormatNumber1(d_Total[i_Month].ToString(), 0) + "</td>\n";
                s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + FormatNumber1(d_TotalNumber[i_Month].ToString(), 3) + "</td>\n";
            }
            s_Details += " </tr>";

            s_Details += "</tbody></table></div>";

            AdminloginMess Am = new AdminloginMess();
            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\"> \n";
            s_Head += "<tr>\n<th  colspan=\"27\" align=\"center\" width=\"100%\" class=\"thsTitle\" noWrap><font width=\"100\" size=\"6\"><b>供应商月采购金额</b></font></th>\n</tr>";
            s_Head += "<tr>\n<th  align=\"left\" width=\"100%\" class=\"thsTitle\" colspan=\"17\">" + "年份:" + s_Year + "</th><th  align=\"right\"  class=\"thsTitle\" colspan=\"10\">" + "制表人:" + Am.KNet_StaffName + "</th>\n</tr>";

            s_Head += "<th class=\"thstyle\" rowspan=2>序号</th>\n";
            s_Head += "<th class=\"thstyle\" rowspan=2>供应商名称</th>\n";
            s_Head += "<th class=\"thstyle\" rowspan=2>供应商编码</th>\n";
            for (int i_Month = 1; i_Month <= 12; i_Month++)
            {
                s_Head += "<th class=\"thstyle\" colspan=2 >" + i_Month.ToString() + "月</th>\n";
            }

            s_Head += "<tr>\n";
            for (int i_Month = 1; i_Month <= 12; i_Month++)
            {
                s_Head += "<th class=\"thstyle\" >数量</th>\n";
                s_Head += "<th class=\"thstyle\" >金额</th>\n";
            }
            s_Head += "</tr>\n";
            s_Head += "</thead><tbody class=\"scrollContent\">";
            this.Lbl_Details.Text = s_Head + s_Details;
        }
    }
}
