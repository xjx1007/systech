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

public partial class Web_Report_CG_List_OrderList : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {

            string s_Sql = "select  a.OrderNo,a.OrderDateTime,d.ProcureTypeName,c.SuppCode,c.SuppName,";
            s_Sql += "e.ProductsPattern,e.ProductsEdition,e.ProductsUnits,b.OrderAmount,a.orderPreToDate,";
            s_Sql += "b.OrderUnitPrice,b.HandPrice,b.OrderRemarks,a.ContractNo,a.OrderRemarks";
            s_Sql += ",f.rkNumber,f.wrkNumber,e.ProductsName,a.ContractNos,e.KSP_Code,a.parentOrderNo,a.ReceiveSuppNo";
            s_Sql += " from Knet_Procure_OrdersList a  join Knet_Procure_OrdersList_Details b on a.OrderNo=b.OrderNo";
            s_Sql += " join Knet_Procure_Suppliers c on c.SuppNo=a.Suppno join KNet_Sys_ProcureType d ";
            s_Sql += " on d.ProcureTypeValue=a.OrderType join KNet_Sys_Products e on b.ProductsBarCode=e.ProductsBarCode";
            s_Sql += " join v_OrderRkDetails f on f.KPO_ID=b.ID  "; 
            s_Sql += " where a.KPO_Del=0 ";
            //  string s_Sql = "Select b.ProductsBarCode,c.CustomerName,b.ProductsPattern as ProductsName,Sum(Case When a.ContractClass='129687502761283812' then b.ContractAmount else 0 end ) as Number,";
            //s_Sql += "Sum(Case When a.ContractClass='129687502761283812' then 0 else b.ContractAmount end ) as BackNumber,b.ProductsBarCode,a.CustomerValue";
            //s_Sql += " from KNet_Sales_ContractList a join KNet_Sales_ContractList_Details b on a.ContractNo=b.ContractNo join KNet_Sales_ClientList c on a.CustomerValue=c.CustomerValue  ";

            string s_StartDate = Request.QueryString["StartDate"] == null ? "" : Request.QueryString["StartDate"].ToString();
            string s_EndDate = Request.QueryString["EndDate"] == null ? "" : Request.QueryString["EndDate"].ToString();
            string s_SuppNoValue = Request.QueryString["SuppNoValue"] == null ? "" : Request.QueryString["SuppNoValue"].ToString();
            string s_OrderType = Request.QueryString["OrderType"] == null ? "" : Request.QueryString["OrderType"].ToString();
            string s_ProductsEdition = Request.QueryString["ProductsEdition"] == null ? "" : Request.QueryString["ProductsEdition"].ToString();
            string s_RkState = Request.QueryString["RkState"] == null ? "" : Request.QueryString["RkState"].ToString();
            string s_ProductsType = Request.QueryString["ProductsType"] == null ? "" : Request.QueryString["ProductsType"].ToString();
            string s_OEMOrderNo = Request.QueryString["OEMOrderNo"] == null ? "" : Request.QueryString["OEMOrderNo"].ToString();

            
            string s_DutyPerson = Request.QueryString["DutyPerson"] == null ? "" : Request.QueryString["DutyPerson"].ToString();
            string s_Details = "", s_Style = "";
            string s_Head = "";
           decimal d_TotalNumber = 0, d_BackTotalNumber = 0, d_ShipNumber = 0, d_LeftNumber = 0;
            if(s_StartDate!="")
            {
                s_Sql += " and a.OrderDateTime>='" + s_StartDate + "'";
            }
            if (s_EndDate != "")
            {
                s_Sql += " and a.OrderDateTime<='" + s_EndDate + "'";
            }
            if (s_RkState != "")
            {
                if (s_RkState == "1")//已入库
                {
                    s_Sql += " and  f.rkState='" + s_RkState + "' and a.KPO_RkState='1' ";
                }
                else if (s_RkState == "3")//未完全入库
                {
                    s_Sql += " and  f.rkState in (0,2) and a.KPO_RkState='0' ";
                }
                else
                {
                    s_Sql += " and  f.rkState='" + s_RkState + "' and a.KPO_RkState='0' ";
                }
            }
            if (s_OrderType != "")
            {
                s_Sql += " and a.OrderType='" + s_OrderType + "'";
            }
            if (s_ProductsEdition != "")
            {

                s_Sql += " and e.ProductsEdition like '%" + s_ProductsEdition + "%'";
            }
            if (s_OEMOrderNo != "")
            {
                s_Sql += " and parentOrderNo  like '%" + s_OEMOrderNo + "%'";
            }

            if (s_SuppNoValue != "")
            {
                s_Sql += " and a.SuppNo = '" + s_SuppNoValue + "'";
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
            s_Sql += "Order by a.OrderDateTime";
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
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + Dtb_Table.Rows[i][0].ToString() + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + GetContract(Dtb_Table.Rows[i]["ContractNos"].ToString(), Dtb_Table.Rows[i]["ContractNo"].ToString()) + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + Dtb_Table.Rows[i]["parentOrderNo"].ToString() + "&nbsp;</td>\n";
                    if (Dtb_Table.Rows[i]["parentOrderNo"].ToString() == "")
                    {
                        KNet.BLL.Knet_Procure_OrdersList Bll = new KNet.BLL.Knet_Procure_OrdersList();
                        KNet.Model.Knet_Procure_OrdersList Model = Bll.GetModelB(Dtb_Table.Rows[i]["parentOrderNo"].ToString());
                        s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + base.Base_GetHouseName(Model.SuppNo) + "&nbsp;</td>\n";

                    }
                    else {
                        s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + base.Base_GetHouseName(Dtb_Table.Rows[i]["ReceiveSuppNo"].ToString()) + "&nbsp;</td>\n";

                    }
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + DateTime.Parse(Dtb_Table.Rows[i][1].ToString()).ToShortDateString() + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + Dtb_Table.Rows[i][3].ToString() + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + Dtb_Table.Rows[i][4].ToString() + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + Dtb_Table.Rows[i][17].ToString() + "</td>\n";

                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + Dtb_Table.Rows[i]["KSP_Code"].ToString() + "</td>\n";

                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + Dtb_Table.Rows[i][5].ToString() + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + Dtb_Table.Rows[i][6].ToString() + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + base.Base_GetUnitsName(Dtb_Table.Rows[i][7].ToString()) + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + DateTime.Parse(Dtb_Table.Rows[i][9].ToString()).ToShortDateString() + "</td>\n";
                    s_Details += "<td align=right class='thstyleLeftDetails' noWrap>" + FormatNumber1(Dtb_Table.Rows[i][8].ToString(), 0) + "</td>\n";
                    s_Details += "<td align=right class='thstyleLeftDetails' noWrap>" + FormatNumber(Dtb_Table.Rows[i][10].ToString(), 3) + "</td>\n";
                    s_Details += "<td align=right class='thstyleLeftDetails' noWrap>" + FormatNumber(Dtb_Table.Rows[i][11].ToString(), 3) + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + FormatNumber1(Dtb_Table.Rows[i]["rkNumber"].ToString(), 0) + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + FormatNumber1(Dtb_Table.Rows[i]["wrkNumber"].ToString(), 0) + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + GetFlow(Dtb_Table.Rows[i]["OrderNo"].ToString()) + "</td>\n";

                    s_Details += " </tr>";
                    d_TotalNumber += Decimal.Parse(Dtb_Table.Rows[i][8].ToString());
                    d_BackTotalNumber += Decimal.Parse(Dtb_Table.Rows[i]["rkNumber"].ToString());
                    d_LeftNumber += Decimal.Parse(Dtb_Table.Rows[i]["wrkNumber"].ToString());
                }
            }

            s_Details += " <tr >\n";
            s_Details += "<td align=left noWrap colspan=\"13\">合计：</td>\n";
            s_Details += "<td align=right noWrap>" + FormatNumber1(d_TotalNumber.ToString(), 0) + "</td>\n";
            s_Details += "<td align=left noWrap colspan=\"2\">&nbsp;</td>\n";
            s_Details += "<td align=right noWrap>" + FormatNumber1(d_BackTotalNumber.ToString(), 0) + "</td>\n";
            s_Details += "<td align=right noWrap>" + FormatNumber1(d_LeftNumber.ToString(), 0) + "</td>\n";
            s_Details += "<td align=right noWrap>&nbsp;</td>\n";
            s_Details += " </tr>";

            s_Details += "</tbody></table></div>";

            AdminloginMess Am = new AdminloginMess();
            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\"> \n";
            s_Head += "<tr>\n<th  colspan=\"22\" align=\"center\" width=\"100%\" class=\"thsTitle\" noWrap><font width=\"100\" size=\"6\"><b>杭州士腾订单明细表</b></font></th>\n</tr>";
            s_Head += "<tr>\n<th  align=\"left\" width=\"100%\" class=\"thsTitle\" colspan=\"12\">" + "日期:" + s_StartDate + " 到 " + s_EndDate + "</th><th  align=\"right\"  class=\"thsTitle\" colspan=\"10\">" + "制表人:" + Am.KNet_StaffName + "</th>\n</tr>";

            s_Head += "<th class=\"thstyle\">序号</th>\n";
            s_Head += "<th class=\"thstyle\">采购单号</th>\n";
            s_Head += "<th class=\"thstyle\">合同单号</th>\n";
            s_Head += "<th class=\"thstyle\">OEM订单号</th>\n";
            s_Head += "<th class=\"thstyle\">OEM供应商</th>\n";
            s_Head += "<th class=\"thstyle\">订购日期</th>\n";
            s_Head += "<th class=\"thstyle\">供应商编码</th>\n";
            s_Head += "<th class=\"thstyle\">供应商名称</th>\n";
            s_Head += "<th class=\"thstyle\">产品名称</th>\n";
            s_Head += "<th class=\"thstyle\">产品编码</th>\n";
            s_Head += "<th class=\"thstyle\">产品型号</th>\n";
            s_Head += "<th class=\"thstyle\">产品版本</th>\n";
            s_Head += "<th class=\"thstyle\">产品单位</th>\n";
            s_Head += "<th class=\"thstyle\">产品交期</th>\n";
            s_Head += "<th class=\"thstyle\">采购数量</th>\n";
            s_Head += "<th class=\"thstyle\">产品单价</th>\n";
            s_Head += "<th class=\"thstyle\">加工费单价</th>\n";
            s_Head += "<th class=\"thstyle\">已入库</th>\n";
            s_Head += "<th class=\"thstyle\">未入库</th>\n";
            s_Head += "<th class=\"thstyle\">交期确认</th>\n";
            s_Head += "</tr>\n";
            s_Head += "</thead><tbody class=\"scrollContent\">";
            this.Lbl_Details.Text = s_Head+s_Details;
            
        }
    }
    public string GetFlow(string s_OrderNo)
    {
        string s_Return = "&nbsp;";
        try
        {
            string s_Sql = "Select * from KNet_Sales_OutWareList_FlowList where OutWareNo='" + s_OrderNo + "'";
            this.BeginQuery(s_Sql);
            DataTable Dtb_Table = (DataTable)this.QueryForDataTable();
            if (Dtb_Table.Rows.Count > 0)
            {
                s_Return += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" >";
                for(int i=0;i<Dtb_Table.Rows.Count;i++)
                {
                    s_Return += "<tr>";
                    if (Dtb_Table.Rows[i]["ReTime"] != null)
                    {
                        s_Return += "<td  class='thstyleLeftDetails' noWrap>" + base.DateToString(Dtb_Table.Rows[i]["ReTime"].ToString()) + "</td>";
                    }
                    if(Dtb_Table.Rows[i]["OldTime"] != null)
                    {
                        s_Return += " <td  class='thstyleLeftDetails' noWrap>" + base.DateToString(Dtb_Table.Rows[i]["OldTime"].ToString()) + "</td>";
                    }
                    if (Dtb_Table.Rows[i]["FollowText"].ToString()!="")
                    {
                        s_Return += "<td  class='thstyleLeftDetails' noWrap>" + Dtb_Table.Rows[i]["FollowText"].ToString() + "</td>";
                    }
                    s_Return += "</tr>";
                }
                s_Return += "</table>";
            }
        }
        catch
        { }
        return s_Return;
    }
    public string GetContract(string s_ContractNos, string s_ContractNo1)
    {
        string s_Return = "";
        try
        {
            string[] s_ContractNo = s_ContractNos.Split(',');
            for (int i = 0; i < s_ContractNo.Length; i++)
            {
                s_Return += "<a href=\"../SalesContract/Xs_ContractList_View.aspx?ID=" + s_ContractNo[i] + "\" >" + s_ContractNo[i] + "</a><br>";
            }
            if (s_Return == "")
            {
                s_Return += "<a href=\"../SalesContract/Xs_ContractList_View.aspx?ID=" + s_ContractNo1 + "\" >" + s_ContractNo1 + "</a><br>";
            }
        }
        catch
        { }
        return s_Return;
    }
}
