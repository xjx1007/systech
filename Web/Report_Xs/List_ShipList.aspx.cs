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

public partial class Web_Report_Xs_List_ShipList : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            string s_Sql = "Select a.OutWareNo,a.OutWareDateTime,a.CustomerValue,b.ProductsName,b.ProductsPattern,b.OutWareAmount,b.OutWare_SalesUnitPrice,";
            s_Sql += " b.OutWare_SalesTotalNet,a.outwareStaffNo,a.OutWareRemarks,c.CustomerClass from KNet_Sales_OutWareList a join KNet_Sales_OutWareList_Details b on a.OutWareNo=b.OutWareNo join KNet_Sales_ClientList c on a.CustomerValue=c.CustomerValue Where 1=1 and OutWareCheckYn='1' ";
            string s_StartDate = Request.QueryString["StartDate"].ToString();
            string s_EndDate = Request.QueryString["EndDate"].ToString();
            string s_CustomerName = Request.QueryString["CustomerName"].ToString();
            string s_ProductsType = Request.QueryString["ProductsType"].ToString();
            string s_CustomerTypes = Request.QueryString["CustomerTypes"].ToString();
            string s_Details = "", s_Style = "";
            string s_Head = "";
            Decimal DTotalNum = 0, DTotalNet = 0;
            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n<table border=\"1\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\"> \n";
            s_Head += "<tr  >\n<th>序号</th>\n";
            s_Head += "<th>发货单号</th>\n";
            s_Head += "<th>快递单号</th>\n";
            s_Head += "<th>发货日期</th>\n";
            s_Head += "<th>客户名称</th>\n";
            s_Head += "<th>产品型号</th>\n";
            s_Head += "<th>数量</th>\n";
            s_Head += "<th>单价</th>\n";
            s_Head += "<th>金额</th>\n";
            s_Head += "<th>客户类别</th>\n";
            s_Head += "<th>操作人</th>\n";
            s_Head += "</thead><tbody class=\"scrollContent\">";

            if (s_StartDate != "")
            {
                s_Sql += " and a.OutWareDateTime>='" + s_StartDate + "'";
            }
            if (s_EndDate != "")
            {
                s_Sql += " and a.OutWareDateTime<='" + s_EndDate + "'";
            }
            if (s_CustomerName != "")
            {
                s_Sql += " and a.CustomerValue in (select CustomerValue from KNet_Sales_ClientList where CustomerName like '%" + s_CustomerName + "%')";
            }
            if (s_ProductsType != "")
            {
                s_Sql += " and b.ProductsPattern like '%" + s_ProductsType + "%'";
            }
            if (s_CustomerTypes != "")
            {
                s_Sql += " and a.CustomerValue in (select CustomerValue from KNet_Sales_ClientList where CustomerTypes='" + s_CustomerTypes + "' ) ";
            }
            s_Sql += "Order by a.OutWareDateTime";
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
                    s_Details += "<td align=left noWrap>" + (i + 1).ToString() + "</td>\n";
                    s_Details += "<td align=left noWrap>" + Dtb_Table.Rows[i][0].ToString() + "</td>\n";
                    s_Details += "<td align=left noWrap>" + GetKdCode(Dtb_Table.Rows[i][0].ToString()) + "</td>\n";
                    s_Details += "<td align=left noWrap>" + DateTime.Parse(Dtb_Table.Rows[i][1].ToString()).ToShortDateString() + "</td>\n";
                    s_Details += "<td align=left noWrap>" + base.Base_GetCustomerName(Dtb_Table.Rows[i][2].ToString()) + "</td>\n";
                    s_Details += "<td align=left noWrap>" + Dtb_Table.Rows[i][4].ToString() + "(" + Dtb_Table.Rows[i][3].ToString() + ")" + "</td>\n";
                    s_Details += "<td align=right noWrap>" + Dtb_Table.Rows[i][5].ToString() + "</td>\n";//数量
                    s_Details += "<td align=right noWrap>" + Dtb_Table.Rows[i][6].ToString() + "</td>\n";//单价
                    s_Details += "<td align=right noWrap>" + Dtb_Table.Rows[i][7].ToString() + "</td>\n";//金额
                    s_Details += "<td align=center noWrap>" + base.Base_GetKClaaName(Dtb_Table.Rows[i]["CustomerClass"].ToString()) + "</td>\n";//客户类别
                    s_Details += "<td align=center noWrap>" + base.Base_GetUserName(Dtb_Table.Rows[i][8].ToString()) + "</td>\n";//制单人
                    s_Details += " </tr>";
                    DTotalNum += Decimal.Parse(Dtb_Table.Rows[i][5].ToString());
                    DTotalNet += Decimal.Parse(Dtb_Table.Rows[i][7].ToString());
                }
            }

            s_Details += " <tr >\n";

            s_Details += "<td  width='1%' align=left noWrap colspan=6>合计:" + (Dtb_Table.Rows.Count).ToString() + "</td>\n";
            s_Details += "<td align=right width='1%' noWrap>" + DTotalNum.ToString() + "</td>\n";//数量
            s_Details += "<td align=right width='1%'noWrap>&nbsp;</td>\n";//单价
            s_Details += "<td align=right width='1%'  noWrap>" + DTotalNet.ToString() + "</td>\n";//金额
            s_Details += "<td align=right width='1%' noWrap>&nbsp;</td>\n";//单价
            s_Details += " </tr>";

            s_Details += "</tbody></table></div>";
            this.Lbl_Details.Text = s_Head + s_Details;
            this.Lbl_Time.Text = "日期:" + s_StartDate + " 到 " + s_EndDate;
            AdminloginMess Am = new AdminloginMess();
            this.Lbl_Person.Text = "制表人:" + Am.KNet_StaffName;

        }
       

    }
    private string GetKdCode(String s_OutWareCode)
    {
        string s_Return="";
        this.BeginQuery("Select * from KNet_Sales_OutWareList_FlowList where  OutWareNo='" + s_OutWareCode + "' order by FollowDateTime");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                if (Dtb_Result.Rows[i]["KDCode"].ToString() != "")
                {
                    s_Return += Dtb_Result.Rows[i]["KDCodeName"].ToString() + "(<a href='../Sales/Knet_Sales_Ship_Manage_Talks_Detail.aspx?com=" + Dtb_Result.Rows[i]["KDName"].ToString() + "&Code=" + Dtb_Result.Rows[i]["KDCode"].ToString() + "&Name=" + Dtb_Result.Rows[i]["KDCodeName"].ToString() + "' target='_bank'>" + Dtb_Result.Rows[i]["KDCode"].ToString() + "</a>)" + ",";
                }
                else
                {
                    s_Return += Dtb_Result.Rows[i]["FollowText"].ToString() + ",";
                }
            }
            s_Return = s_Return.Substring(0, s_Return.Length - 1);
        }
        return s_Return;

    }
}
