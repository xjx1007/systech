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

public partial class Web_Report_Xs_List_OrderList : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {

            string s_Sql = "select a.v_ProductsBarCode,a.v_CustomerValue,a.v_CustomerName,a.v_ProductsName,a.v_ProductsEdition,a.v_ProductsPattern,Sum(Case When a.v_Class='129687502761283812' then a.v_Number else 0 end ) as Number,";
            s_Sql += "Sum(Case When a.v_Class='129687502876636011' then a.v_number else 0 end ) as BackNumber,ISNull(Sum(Case When a.v_Type='102' then a.v_number else 0 end),0) as ShipNubmer,ISNull(Sum(Case When a.v_Type='103' then a.v_number else 0 end),0) as OutNumber ";
            s_Sql += ",b.v_LeftNumer as leftNumer ";
            s_Sql += " From v_Contrac_OutWare_DirectOut a join v_SalesContrac_LeftNumber b on a.v_CustomerValue=b.v_CustomerValue and a.v_ProductsBarCode=b.v_ProductsBarCode where 1=1 ";
            //  string s_Sql = "Select b.ProductsBarCode,c.CustomerName,b.ProductsPattern as ProductsName,Sum(Case When a.ContractClass='129687502761283812' then b.ContractAmount else 0 end ) as Number,";
            //s_Sql += "Sum(Case When a.ContractClass='129687502761283812' then 0 else b.ContractAmount end ) as BackNumber,b.ProductsBarCode,a.CustomerValue";
            //s_Sql += " from KNet_Sales_ContractList a join KNet_Sales_ContractList_Details b on a.ContractNo=b.ContractNo join KNet_Sales_ClientList c on a.CustomerValue=c.CustomerValue  ";

            string s_StartDate = Request.QueryString["StartDate"] == null ? "" : Request.QueryString["StartDate"].ToString();
            string s_EndDate = Request.QueryString["EndDate"] == null ? "" : Request.QueryString["EndDate"].ToString();
            string s_CustomerValue = Request.QueryString["CustomerValue"] == null ? "" : Request.QueryString["CustomerValue"].ToString();
            string s_ProductsEditoin = Request.QueryString["ProductsEidition"] == null ? "" : Request.QueryString["ProductsEidition"].ToString();
            string s_CustomerTypes = Request.QueryString["CustomerTypes"] == null ? "" : Request.QueryString["CustomerTypes"].ToString();
            string s_ProductsType = Request.QueryString["ProductsType"] == null ? "" : Request.QueryString["ProductsType"].ToString();
            string s_DutyPerson = Request.QueryString["DutyPerson"] == null ? "" : Request.QueryString["DutyPerson"].ToString();
            
            string s_Details = "", s_Style = "";
            string s_Head = "";
            decimal d_TotalNumber = 0, d_BackTotalNumber = 0, d_ShipNumber = 0, d_LeftNumber = 0,d_Left=0,d_Out=0;
            if(s_StartDate!="")
            {
                s_Sql += " and a.v_Time>='" + s_StartDate + "'";
            }
            if (s_EndDate != "")
            {
                s_Sql += " and a.v_Time<='" + s_EndDate + "'";
            }
            if (s_CustomerValue != "")
            {
                s_Sql += " and a.v_CustomerValue='" + s_CustomerValue + "'";
            }
            if (s_ProductsEditoin != "")
            {
                s_Sql += " and a.v_ProductsEdition like '%" + s_ProductsEditoin + "%'";
            }
            if (s_DutyPerson != "")
            {
                s_Sql += " and a.v_DutyPerson='" + s_DutyPerson + "'";
 
            }
            if (s_ProductsType != "")
            {
                KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
                string s_SonID = Bll_ProductsDetails.GetSonIDs(s_ProductsType);
                s_SonID = s_SonID.Replace(",", "','");
                s_Sql += " and a.v_ProductsType in ('" + s_SonID + "') ";
            }
            if(s_CustomerTypes!="")
            {
                s_Sql += " and a.v_CustomerTypes='" + s_CustomerTypes + "' ";
            }
            s_Sql += "Group by a.v_CustomerName,a.v_ProductsName,a.v_ProductsPattern,a.v_ProductsBarCode,a.v_CustomerValue,a.v_ProductsEdition,b.v_LeftNumer Order by a.v_CustomerName";
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
                    string s_ShipNumber = GetShipNumber(Dtb_Table.Rows[i]["v_CustomerValue"].ToString(), Dtb_Table.Rows[i]["v_ProductsBarCode"].ToString());
                    if ((s_ShipNumber == "") || (s_ShipNumber == "-"))
                    {
                        s_ShipNumber = "0";
                    }
                    string s_OutNumber = GetOutNumber(Dtb_Table.Rows[i]["v_CustomerValue"].ToString(), Dtb_Table.Rows[i]["v_ProductsBarCode"].ToString());
                    if ((s_OutNumber == "") || (s_OutNumber == "-"))
                    {
                        s_OutNumber = "0";
                    }
                    s_Details += " <tr " + s_Style + " onmouseover='setActiveBG(this)'>\n";
                    s_Details += "<td align=left noWrap><a href='List_CustomerOrderDetails.aspx?CustomerValue=" + Dtb_Table.Rows[i]["v_CustomerValue"].ToString() + "&ProductsBarCode=" + Dtb_Table.Rows[i]["v_ProductsBarCode"].ToString() + "' target=\"_blank\">" + Dtb_Table.Rows[i]["v_CustomerName"].ToString() + "</a></td>\n";
                    s_Details += "<td align=left noWrap>" + Dtb_Table.Rows[i]["v_ProductsName"].ToString() + "</td>\n";
                    s_Details += "<td align=left noWrap>" + Dtb_Table.Rows[i]["v_ProductsPattern"].ToString() + "</td>\n";
                    s_Details += "<td align=left noWrap>" + Dtb_Table.Rows[i]["v_ProductsEdition"].ToString() + "</td>\n";
                    s_Details += "<td align=right noWrap>" + FormatNumber1(Dtb_Table.Rows[i]["Number"].ToString(), 0) + "</td>\n";
                    s_Details += "<td align=right noWrap>" + FormatNumber1(Dtb_Table.Rows[i]["BackNumber"].ToString(), 0) + "</td>\n";
                    s_Details += "<td align=right noWrap>" + FormatNumber1(Dtb_Table.Rows[i]["leftNumer"].ToString(), 0) + "</td>\n";
                    s_Details += "<td align=right noWrap>" + FormatNumber1(s_ShipNumber, 0) + "</td>\n";
                    s_Details += "<td align=right noWrap>" + FormatNumber1(Convert.ToString(decimal.Parse(Dtb_Table.Rows[i]["Number"].ToString()) + decimal.Parse(Dtb_Table.Rows[i]["BackNumber"].ToString()) - decimal.Parse(s_ShipNumber)), 0) + "</td>\n";
                    s_Details += "<td align=right noWrap>" + FormatNumber1(s_OutNumber, 0) + "</td>\n";
                    s_Details += "<td align=center noWrap>" + GetCkNumber(Dtb_Table.Rows[i]["v_ProductsBarCode"].ToString()) + "</td>\n";
                    s_Details += " </tr>";
                    d_TotalNumber += Decimal.Parse(Dtb_Table.Rows[i]["Number"].ToString());
                    d_BackTotalNumber += Decimal.Parse(Dtb_Table.Rows[i]["BackNumber"].ToString());
                    d_ShipNumber += Decimal.Parse(s_ShipNumber);
                    d_Left += Decimal.Parse(Dtb_Table.Rows[i]["leftNumer"].ToString());
                    d_Out +=decimal.Parse(s_OutNumber);
                    d_LeftNumber += decimal.Parse(Dtb_Table.Rows[i]["Number"].ToString()) + decimal.Parse(Dtb_Table.Rows[i]["BackNumber"].ToString()) - decimal.Parse(s_ShipNumber);
                }
            }

            s_Details += " <tr >\n";
            s_Details += "<td align=left noWrap colspan=\"4\">合计：</td>\n";
            s_Details += "<td align=right noWrap>" + FormatNumber1(d_TotalNumber.ToString(), 0) + "</td>\n";
            s_Details += "<td align=right noWrap>" + FormatNumber1(d_BackTotalNumber.ToString(), 0) + "</td>\n";
            s_Details += "<td align=right noWrap>" + FormatNumber1(d_Left.ToString(), 0) + "</td>\n";
            s_Details += "<td align=right noWrap>" + FormatNumber1(d_ShipNumber.ToString(), 0) + "</td>\n";
            s_Details += "<td align=right noWrap>" + FormatNumber1(d_LeftNumber.ToString(), 0) + "</td>\n";
            s_Details += "<td align=right noWrap>" + FormatNumber1(d_Out.ToString(), 0) + "</td>\n";
            
            s_Details += "<td align=right noWrap>&nbsp;</td>\n";
            s_Details += " </tr>";

            s_Details += "</tbody></table></div>";

            AdminloginMess Am = new AdminloginMess();
            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\"> \n";
            s_Head += "<tr>\n<th  colspan=\"11\" align=\"center\" width=\"100%\" class=\"thsTitle\" noWrap><font width=\"100\" size=\"6\"><b>订单执行情况表</b></font></th>\n</tr>";
            s_Head += "<tr>\n<th  align=\"left\" width=\"100%\" class=\"thsTitle\" colspan=\"5\">" + "日期:" + s_StartDate + " 到 " + s_EndDate + "</th><th  align=\"right\"  class=\"thsTitle\" colspan=\"6\">" + "制表人:" + Am.KNet_StaffName + "</th>\n</tr>";
            s_Head += "<th class=\"thstyle\">客户</th>\n";
            s_Head += "<th class=\"thstyle\">产品名称</th>\n";
            s_Head += "<th class=\"thstyle\">产品型号</th>\n";
            s_Head += "<th class=\"thstyle\">版本号</th>\n";
            s_Head += "<th class=\"thstyle\">合同数量</th>\n";
            s_Head += "<th class=\"thstyle\">备货数量</th>\n";
            s_Head += "<th class=\"thstyle\">未核销备货</th>\n";
            s_Head += "<th class=\"thstyle\">通知数量</th>\n";
            s_Head += "<th class=\"thstyle\">剩余数量</th>\n";
            s_Head += "<th class=\"thstyle\">出库数量</th>\n";
            s_Head += "<th class=\"thstyle\">库存数量</th>\n</tr>";
            s_Head += "</thead><tbody class=\"scrollContent\">";
            this.Lbl_Details.Text = s_Head+s_Details;
            
        }
    }
    public string GetShipNumber(string s_CustomerValue, string s_ProductsBarCode)//出库数量
    {
        this.BeginQuery("Select Isnull(Sum(v_Number),0) From v_Contrac_OutWare_DirectOut where v_Type='102' and v_ProductsBarCode='" + s_ProductsBarCode + "' and v_CustomerValue='" + s_CustomerValue + "' ");
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
    public string GetOutNumber(string s_CustomerValue, string s_ProductsBarCode)//出库数量
    {
        this.BeginQuery("Select Isnull(Sum(v_Number),0) From v_Contrac_OutWare_DirectOut where v_Type='103' and v_ProductsBarCode='" + s_ProductsBarCode + "' and v_CustomerValue='" + s_CustomerValue + "' ");
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
        this.BeginQuery("Select Sum(DirectInAmount),HouseNo from v_Store where ProductsBarCode='" + s_ProductsBarCode + "' and HouseNo in( select HouseNO from KNet_Sys_WareHouse where KSW_Type='0') Group by  HouseNo");
        this.QueryForDataTable();
        
        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                if (Dtb_Result.Rows[i][0].ToString() != "0")
                {
                    s_Return += base.Base_GetHouseName(Dtb_Result.Rows[i][1].ToString()) + "（" + Dtb_Result.Rows[i][0].ToString() + ")<br/>";
                }
            }
        }
        else
        {
             s_Return="-";
        }
        return s_Return;
    }
}
