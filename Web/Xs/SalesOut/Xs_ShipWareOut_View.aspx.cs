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

using KNet.DBUtility;
using KNet.Common;

public partial class Web_Sales_Xs_ShipWareOut_View : BasePage
{
    public string s_Time = "";
    public string s_HouseName = "";
    public string s_Details = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string s_ID = Request.QueryString["ID"].ToString();
            string s_Sql = "Select b.ProductsPattern,b.DirectOutAmount,a.DirectOutDateTime,a.KWD_sCustomerValue,a.KWD_ContentPerson,isnull(c.KSO_TelPhone,a.KWD_TelPhone),a.KWD_Address,a.DirectOutRemarks,a.HouseNo,c.KSO_PlanOutWareDateTime,b.ProductsBarCode ";
            s_Sql += "  from KNet_WareHouse_DirectOutList a join KNet_WareHouse_DirectOutList_Details b on a.DirectOutNo=b.DirectOutNo left join KNet_Sales_OutWareList c on c.OutwareNo=a.KWD_ShipNo  Where 1=1 and Kwd_Type='101' and a.DirectOutNo='" + s_ID + "' ";

            string s_Date = "", s_House = "", s_Style="";
            string s_Head = "";
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
                    s_Details += "<td align=center noWrap>" + (i + 1).ToString() + "</td>\n";
                    s_Details += "<td align=center noWrap>" + base.Base_GetProductsPattern(Dtb_Table.Rows[i][10].ToString()) + "</td>\n";
                    s_Details += "<td align=center noWrap>" + base.Base_GetProductsEdition(Dtb_Table.Rows[i][10].ToString()) + "</td>\n";
                    s_Details += "<td align=right noWrap>" + Dtb_Table.Rows[i][1].ToString() + "</td>\n";
                    s_Details += "<td align=center noWrap>" + DateTime.Parse(Dtb_Table.Rows[i][2].ToString()).ToShortDateString() + "</td>\n";
                    if (Dtb_Table.Rows[i][9].ToString() != "")
                    {
                        s_Details += "<td align=center noWrap>" + DateTime.Parse(Dtb_Table.Rows[i][9].ToString()).ToShortDateString() + "</td>\n";
                    }
                    else
                    {
                        s_Details += "<td align=center noWrap>&nbsp;</td>\n";
                    }
                    s_Details += "<td align=center noWrap>" + base.Base_GetCustomerName(Dtb_Table.Rows[i][3].ToString()) + "</td>\n";
                    s_Details += "<td align=center noWrap>" + Dtb_Table.Rows[i][4].ToString() + "</td>\n";
                    s_Details += "<td align=center noWrap>" + Dtb_Table.Rows[i][5].ToString() + "</td>\n";
                    s_Details += "<td align=center >" + Dtb_Table.Rows[i][6].ToString() + "</td>\n";
                    s_Details += "<td align=center noWrap>" + Dtb_Table.Rows[i][7].ToString() + "</td>\n";
                    s_Details += " </tr>";
                    s_Date = DateTime.Parse(Dtb_Table.Rows[i][2].ToString()).ToShortDateString();
                    s_House = base.Base_GetHouseName(Dtb_Table.Rows[i][8].ToString());
                }
            }
            s_Details += "</tbody></table></div>";

            s_Time = "日期:" + s_Date;
            s_HouseName = "供应商名称:" + s_House;
            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n<table border=\"1\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"print ke-zeroborder\"> \n";
            s_Head += "<tr >\n<td colspan=\"11\" height=\"80px\" align=\"center\"><font size=\"6\"><b>杭州士腾科技发货通知单</b></font></th></tr>\n";
            s_Head += "<tr >\n<td colspan=\"6\" noWrap align=\"left\" style=\"BORDER-Right: #000000 0px solid;BORDER-Left: #000000 0px solid;\">" + s_HouseName + "</th><td noWrap colspan=\"5\" align=\"right\" style=\"BORDER-Right: #000000 0px solid;BORDER-Left: #000000 0px solid;\">" + s_Time + "</th></tr>\n";
            s_Head += "<tr >\n<td>序号</th>\n";
            s_Head += "<td noWrap>产品型号</th>\n";
            s_Head += "<td noWrap>产品版本</th>\n";
            s_Head += "<td noWrap>数量</th>\n";
            s_Head += "<td noWrap>发货日期</th>\n";
            s_Head += "<td noWrap>到货日期</th>\n";
            s_Head += "<td noWrap>客户名称</th>\n";
            s_Head += "<td noWrap>收货人</th>\n";
            s_Head += "<td noWrap>联系电话</th>\n";
            s_Head += "<td noWrap>交货地点</th>\n";
            s_Head += "<td>备注</th>\n</tr>\n";
            s_Head += "<tbody class=\"scrollContent\">";
            this.Lbl_Details.Text = s_Head + s_Details;
        }
    }
}
