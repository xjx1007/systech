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

public partial class Procure_ShipCheck_View_Deails : BasePage
{
    public string s_Time = "";
    public string s_HouseName = "";
    public string s_Details = "";
    public string s_ExcelName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string s_ID = Request.QueryString["ID"].ToString();
            string s_Sql = "Select f.XPP_ProductsBarCode,b.COD_Dznumber*isnull(f.XPP_Number,0),d.DirectOutDateTime,b.COD_ProductsBarCode,b.COD_wuliu,b.COd_Price,b.COD_HandPrice, ";
            s_Sql += "b.COD_Money,b.COD_IC,B.COD_ICNumber,a.COC_Stime,a.COC_HouseNo  from Cg_Order_Checklist a join Cg_Order_Checklist_Details b on a.COC_Code=b.COD_CheckNo ";
            s_Sql += " join KNet_WareHouse_DirectOutList_Details c on c.ID=b.COD_DirectOutID join KNet_WareHouse_DirectOutList d on d.DirectOutNo=c.DirectOutNo ";
            s_Sql += " join KNet_Sales_OutWareList e on e.OutWareNo=d.KWD_ShipNo join Xs_Products_Prodocts f on f.XPP_FaterBarCode=b.COD_ProductsBarCode Where 1=1 and a.COC_Code='" + s_ID + "' Order by d.DirectOutDateTime ";
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
                    s_Details += "<td align=center noWrap>" + base.Base_GetProdutsName(Dtb_Table.Rows[i][0].ToString()) + "</td>\n";
                    s_Details += "<td align=center noWrap>" + base.Base_GetProductsPattern(Dtb_Table.Rows[i][0].ToString()) + "</td>\n";
                    s_Details += "<td align=center noWrap>" + base.Base_GetUnitsName(base.Base_GetProductsUnits(Dtb_Table.Rows[i][0].ToString())) + "</td>\n";
                    s_Details += "<td align=center noWrap>" + base.FormatNumber(Dtb_Table.Rows[i][1].ToString(), 0) + "</td>\n";//money
                    s_Details += "<td align=center noWrap>" + base.Base_GetProductsEdition(Dtb_Table.Rows[i][3].ToString()) + "</td>\n";
                    s_Details += "<td align=center noWrap>" + DateTime.Parse(Dtb_Table.Rows[i][2].ToString()).ToShortDateString() + "</td>\n";
                    s_Details += "<td align=center noWrap>&nbsp;</td>\n";
                    s_Details += "<td align=center noWrap>&nbsp;</td>\n";
                    s_Details += " </tr>";
                }
               // s_Date = DateTime.Parse(Dtb_Table.Rows[0][11].ToString()).ToShortDateString();
                //s_House = Dtb_Table.Rows[0][12].ToString();
            }
            s_Details += "</tbody></table></td></tr>";

            s_Time = "日期:" + s_Date;
            s_HouseName = "供应商名称:" + base.Base_GetHouseName(s_House);

            s_ExcelName = base.Base_GetHouseName(s_House) + "(" + DateTime.Parse(s_Date).Year.ToString() + "." + DateTime.Parse(s_Date).Month.ToString() + ").xls";
            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n<table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\"  ><tr><td><table border=\"1\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<tdead class=\"fixedHeader\"> \n";
            s_Head += "<tr >\n<th colspan=\"16\"><font size=\"6\"><b>委外加工发料单</b></font></td></tr>";
            s_Head += "<tr >\n<td class=\"thstyle\" rowspan=2>项次</td>\n";
            s_Head += "<td class=\"thstyle\" align=center  rowspan=2>品名</td>\n";
            s_Head += "<td class=\"thstyle\" align=center  rowspan=2>规格</td>\n";
            s_Head += "<td class=\"thstyle\" align=center rowspan=2>单位</td>\n";
            s_Head += "<td class=\"thstyle\" align=center rowspan=2>数量</td>\n";
            s_Head += "<td class=\"thstyle\" align=center rowspan=2>遥控器</td>\n";
            s_Head += "<td class=\"thstyle\" align=center rowspan=2>遥控器发货日期</td>\n";
            s_Head += "<td class=\"thstyle\" align=center rowspan=2>损耗率</td>\n";
            s_Head += "<td class=\"thstyle\" align=center>备注</td>\n</tr>\n";
            s_Head += "</thead><tbody class=\"scrollContent\">";

         
            s_Details += "</div>";

            this.Lbl_Details.Text = s_Head + s_Details;
            
        }

    }
}
