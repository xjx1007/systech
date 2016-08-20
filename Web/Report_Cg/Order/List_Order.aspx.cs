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
        if(!IsPostBack)
        {

            string s_Sql = "select  c.SuppName,c.SuppCode,Count(*),d.ProcureTypeName,e.ProductsPattern,e.ProductsEdition,Sum(b.OrderAmount) OrderAmount,Sum(b.OrderTotalNet) OrderTotalNet,Sum(b.HandTotal) HandTotal";
            s_Sql += ",c.SuppNo,e.ProductsBarCode,e.KSP_Code ";
            s_Sql += " from Knet_Procure_OrdersList a  join Knet_Procure_OrdersList_Details b on a.OrderNo=b.OrderNo join Knet_Procure_Suppliers c on c.SuppNo=a.Suppno join KNet_Sys_ProcureType d on d.ProcureTypeValue=a.OrderType join KNet_Sys_Products e on b.ProductsBarCode=e.ProductsBarCode ";
            //  string s_Sql = "Select b.ProductsBarCode,c.CustomerName,b.ProductsPattern as ProductsName,Sum(Case When a.ContractClass='129687502761283812' then b.ContractAmount else 0 end ) as Number,";
            //s_Sql += "Sum(Case When a.ContractClass='129687502761283812' then 0 else b.ContractAmount end ) as BackNumber,b.ProductsBarCode,a.CustomerValue";
            //s_Sql += " from KNet_Sales_ContractList a join KNet_Sales_ContractList_Details b on a.ContractNo=b.ContractNo join KNet_Sales_ClientList c on a.CustomerValue=c.CustomerValue  ";
            s_Sql += " where a.KPO_Del=0 ";
            string s_StartDate = Request.QueryString["StartDate"] == null ? "" : Request.QueryString["StartDate"].ToString();
            string s_SuppNoValue = Request.QueryString["SuppNoValue"] == null ? "" : Request.QueryString["SuppNoValue"].ToString();
            string s_OrderType = Request.QueryString["OrderType"] == null ? "" : Request.QueryString["OrderType"].ToString();
            string s_ProductsType = Request.QueryString["ProductsType"] == null ? "" : Request.QueryString["ProductsType"].ToString();

            string s_EndDate = Request.QueryString["EndDate"] == null ? "" : Request.QueryString["EndDate"].ToString();
            string s_DutyPerson = Request.QueryString["DutyPerson"] == null ? "" : Request.QueryString["DutyPerson"].ToString();
            string s_ProductsEdition = Request.QueryString["ProductsEdition"] == null ? "" : Request.QueryString["ProductsEdition"].ToString();
            string s_Details = "", s_Style = "";
            string s_Head = "";
            decimal d_TotalNumber = 0, d_BackTotalNumber = 0, d_ShipNumber = 0, d_LeftNumber = 0, d_LeftNumber1 = 0, d_LeftNumber2 = 0;
            if(s_StartDate!="")
            {
                s_Sql += " and a.OrderDateTime>='" + s_StartDate + "'";
            }
            if (s_EndDate != "")
            {
                s_Sql += " and a.OrderDateTime<='" + s_EndDate + "'";
            }
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
            s_Sql += "Group by c.SuppName,c.SuppCode,d.ProcureTypeName,e.ProductsPattern,e.ProductsEdition,c.SuppNo,e.ProductsBarCode,e.KSP_Code  Order by c.SuppName";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table=this.Dtb_Result;
            if(Dtb_Table.Rows.Count>0)
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
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + Dtb_Table.Rows[i][0].ToString() + "(" + Dtb_Table.Rows[i][1].ToString() + ")" + "</td>\n";

                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + Dtb_Table.Rows[i][2].ToString() + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + Dtb_Table.Rows[i][3].ToString() + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + Dtb_Table.Rows[i][4].ToString() + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + Dtb_Table.Rows[i]["KSP_Code"].ToString() + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + Dtb_Table.Rows[i][5].ToString() + "</td>\n";
                    s_Details += "<td align=right class='thstyleLeftDetails' noWrap>" + FormatNumber1(Dtb_Table.Rows[i]["OrderAmount"].ToString(), 0) + "</td>\n";
                    s_Details += "<td align=right class='thstyleLeftDetails' noWrap>" + FormatNumber1(Dtb_Table.Rows[i]["OrderTotalNet"].ToString(), 3) + "</td>\n";
                    s_Details += "<td align=right class='thstyleLeftDetails' noWrap>" + FormatNumber1(Dtb_Table.Rows[i]["HandTotal"].ToString(), 3) + "</td>\n";
                    string s_RKNumber = GetRkNumber(Dtb_Table.Rows[i][9].ToString(),Dtb_Table.Rows[i][10].ToString(), 0) == "" ? "0" : GetRkNumber(Dtb_Table.Rows[i][9].ToString(),Dtb_Table.Rows[i][10].ToString(), 0);
                    string s_CKNumber = GetRkNumber(Dtb_Table.Rows[i][9].ToString(),Dtb_Table.Rows[i][10].ToString(), 1) == "" ? "0" : GetRkNumber(Dtb_Table.Rows[i][9].ToString(),Dtb_Table.Rows[i][10].ToString(), 1);


                    s_Details += "<td align=right class='thstyleLeftDetails' noWrap>" + FormatNumber1(s_RKNumber, 0) + "</td>\n";
                    s_Details += "<td align=right class='thstyleLeftDetails' noWrap>" + FormatNumber1(s_CKNumber, 0) + "</td>\n";
                    s_Details += "<td align=right class='thstyleLeftDetails' noWrap>" + FormatNumber1(d_LeftNumber.ToString(), 3) + "</td>\n";
                
                    s_Details += " </tr>";
                    d_TotalNumber += Decimal.Parse(Dtb_Table.Rows[i]["OrderAmount"].ToString());
                    d_BackTotalNumber += Decimal.Parse(Dtb_Table.Rows[i]["OrderTotalNet"].ToString());
                    d_ShipNumber += Decimal.Parse(Dtb_Table.Rows[i]["HandTotal"].ToString());
                    d_LeftNumber1 += Decimal.Parse(s_RKNumber);
                    d_LeftNumber2 += Decimal.Parse(s_CKNumber); 
                }
            }

            s_Details += " <tr >\n";
            s_Details += "<td align=left class='thstyleLeftDetails' noWrap colspan=\"7\">合计：</td>\n";
            s_Details += "<td align=right class='thstyleLeftDetails' noWrap>" + FormatNumber1(d_TotalNumber.ToString(), 0) + "</td>\n";
            s_Details += "<td align=right class='thstyleLeftDetails' noWrap>" + FormatNumber1(d_BackTotalNumber.ToString(), 3) + "</td>\n";
            s_Details += "<td align=right class='thstyleLeftDetails' noWrap>" + FormatNumber1(d_ShipNumber.ToString(), 3) + "</td>\n";
            s_Details += "<td align=right class='thstyleLeftDetails' noWrap>" + FormatNumber1(d_LeftNumber1.ToString(), 0) + "</td>\n";
            s_Details += "<td align=right class='thstyleLeftDetails' noWrap>" + FormatNumber1(d_LeftNumber2.ToString(), 0) + "</td>\n";
            s_Details += "<td align=right class='thstyleLeftDetails' noWrap>&nbsp;</td>\n";
            s_Details += " </tr>";

            s_Details += "</tbody></table></div>";

            AdminloginMess Am = new AdminloginMess();
            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\"> \n";
            s_Head += "<tr>\n<th  colspan=\"21\" align=\"center\" width=\"100%\" class=\"thsTitle\" noWrap><font width=\"100\" size=\"6\"><b>杭州士腾采购订单汇总表</b></font></th>\n</tr>";
            s_Head += "<tr>\n<th  align=\"left\" width=\"100%\" class=\"thsTitle\" colspan=\"11\">" + "日期:" + s_StartDate + " 到 " + s_EndDate + "</th><th  align=\"right\"  class=\"thsTitle\" colspan=\"10\">" + "制表人:" + Am.KNet_StaffName + "</th>\n</tr>";

            s_Head += "<th class=\"thstyle\">序号</th>\n";
            s_Head += "<th class=\"thstyle\">供应商名称</th>\n";
            s_Head += "<th class=\"thstyle\">订单数量</th>\n";
            s_Head += "<th class=\"thstyle\">采购类别</th>\n";
            s_Head += "<th class=\"thstyle\">产品编码</th>\n";
            s_Head += "<th class=\"thstyle\">产品型号</th>\n";
            s_Head += "<th class=\"thstyle\">产品版本</th>\n";
            s_Head += "<th class=\"thstyle\">采购数量</th>\n";
            s_Head += "<th class=\"thstyle\">采购金额</th>\n";
            s_Head += "<th class=\"thstyle\">加工费金额</th>\n";
            s_Head += "<th class=\"thstyle\">已入库数量</th>\n";
            s_Head += "<th class=\"thstyle\">已发货数量</th>\n";
            s_Head += "<th class=\"thstyle\">库存数量</th>\n</tr>";
            s_Head += "</thead><tbody class=\"scrollContent\">";
            this.Lbl_Details.Text = s_Head+s_Details;
        }
    }
    private string GetRkNumber(string s_SuppNo,string s_ProductsBarCode,int i_Type)
    {
        string s_Sql = "Select ABS(SUM(DirectInAmount)) from v_Store a join KNet_Sys_WareHouse b on a.HouseNo=b.HouseNo where a.ProductsBarCode='" + s_ProductsBarCode + "' and b.SuppNo='" + s_SuppNo+"'";
        if (i_Type == 0)
        {
            s_Sql += " and DirectInAmount>0";
        }
        else
        {
            s_Sql += " and DirectInAmount<0";

        }
        this.BeginQuery(s_Sql);
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            return Dtb_Result.Rows[0][0].ToString();
        }
        else
        {
            return "0";
        }
    }
}
