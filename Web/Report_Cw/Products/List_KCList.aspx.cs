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

public partial class Web_Report_Xs_List_KCList : BasePage
{
    public string s_Details = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string s_Sql = "Select XPD_FaterBarCode as ProductsBarCode,ProductsName,ProductsEdition,KSP_COde,SUM(newprice) MaterTotalPrice,isnull((Select top 1 ISNULL(ProcureUnitPrice,0)+ISNULL(HandPrice,0)from Knet_Procure_SuppliersPrice a where a.ProductsBarCode=aa.XPD_FaterBarCode  and a.KPP_State=1 and a.KPP_Del=0 order by ProcureUpdateDateTime desc) ,0) HandPrice";
            s_Sql += " from(";
            s_Sql += " select XPD_FaterBarCode,XPD_ProductsBarCode,XPD_Number*isnull((Select top 1 ISNULL(ProcureUnitPrice,0)+ISNULL(HandPrice,0)from Knet_Procure_SuppliersPrice a where a.ProductsBarCode=b.XPD_ProductsBarCode and a.KPP_State=1 and a.KPP_Del=0  order by ProcureUpdateDateTime desc) ,0) as NewPrice ";
            s_Sql += " from Xs_Products_Prodocts_Demo  b) aa";
            s_Sql += " join KNet_Sys_Products b on aa.XPD_FaterBarCode=b.ProductsBarCode";
            string s_ProductsName = Request.QueryString["ProductsName"] == null ? "" : Request.QueryString["ProductsName"].ToString();
            string s_ProductsEdition = Request.QueryString["ProductsEdition"] == null ? "" : Request.QueryString["ProductsEdition"].ToString();
            string s_ProductsType = Request.QueryString["ProductsType"] == null ? "" : Request.QueryString["ProductsType"].ToString();

            string s_Style = "";
            string s_Head = "";
            Decimal DTotalNum = 0, DTotalNet = 0, DTotalNet1 = 0, DTotalNet2 = 0;
            if (s_ProductsName != "")
            {
                s_Sql += " and b.ProductsName like '%" + s_ProductsName + "%'  ";
            }
            if (s_ProductsEdition != "")
            {
                s_Sql += " and b.ProductsEdition like '%" + s_ProductsEdition + "%'  ";
            }
            if (s_ProductsType != "")
            {
                KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
                string s_SonID = Bll_ProductsDetails.GetSonIDs(s_ProductsType);
                s_SonID = s_SonID.Replace(",", "','");
                s_Sql += " and b.ProductsType in ('" + s_SonID + "') ";
            }
            s_Sql += " group by XPD_FaterBarCode,ProductsName,ProductsEdition,KSP_COde";
            s_Sql += " order by ProductsName,ProductsEdition";

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
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + (i + 1).ToString() + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + Dtb_Table.Rows[i]["ProductsName"].ToString() + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + Dtb_Table.Rows[i]["KSP_Code"].ToString() + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + Dtb_Table.Rows[i]["ProductsEdition"].ToString() + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + Dtb_Table.Rows[i]["MaterTotalPrice"].ToString() + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + Dtb_Table.Rows[i]["HandPrice"].ToString() + "</td>\n";
                    decimal d_TotalPrice = 0, d_TotalPrice1 = 0, d_TotalPrice2=0;
                    try
                    {
                         d_TotalPrice = Decimal.Parse(Dtb_Table.Rows[i]["MaterTotalPrice"].ToString().ToString() == "" ? "0" : Dtb_Table.Rows[i]["MaterTotalPrice"].ToString());
                         d_TotalPrice1 = Decimal.Parse(Dtb_Table.Rows[i]["HandPrice"].ToString().ToString() == "" ? "0" : Dtb_Table.Rows[i]["HandPrice"].ToString());
                         d_TotalPrice2 = d_TotalPrice + d_TotalPrice1;
                         DTotalNet += d_TotalPrice;
                         DTotalNet1 += d_TotalPrice1;
                         DTotalNet2 += d_TotalPrice2;

                    }
                    catch
                    { }
                    string s_URL = "/Web/Products/BOMWithPrice.aspx?BarCode=" + Dtb_Table.Rows[i]["ProductsBarCode"].ToString() + "";

                    s_Details += "<td align=right class='thstyleLeftDetails' noWrap><a href=" + s_URL + " target=\"_blank\"><font color=red>" + base.FormatNumber1(d_TotalPrice2.ToString(), 6) + "</font></a></td>\n";//数量

                    
                }
            }

            s_Details += " <tr >\n";
            s_Details += "<td  width='1%' class='thstyleLeftDetails' align=left noWrap colspan=4>合计:" + (Dtb_Table.Rows.Count).ToString() + "</td>\n";
            s_Details += "<td align=right class='thstyleLeftDetails' width='1%' noWrap>" + base.FormatNumber1(DTotalNet.ToString(), 6) + "</td>\n";//数量
            s_Details += "<td align=right class='thstyleLeftDetails' width='1%' noWrap>" + base.FormatNumber1(DTotalNet1.ToString(), 6) + "</td>\n";//数量
            s_Details += "<td align=right class='thstyleLeftDetails' width='1%' noWrap>" + base.FormatNumber1(DTotalNet2.ToString(), 6) + "</td>\n";//数量


            s_Details += " </tr>";

            s_Details += "</tbody></table></div>";

            AdminloginMess Am = new AdminloginMess();
            string s_Preson = "制表人:" + Am.KNet_StaffName;
            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n";
            s_Head += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\"> \n";
            s_Head += "<tr>\n<th colspan=\"14\" class=\"MaterTitle\" style='height:14.25pt'>杭州士腾科技有限公司<br/>成品最新成本明细</th></tr>\n";
            s_Head += "<tr>\n<th colspan=\"6\" class=\"thstyleleft\"  ></th><th colspan=\"8\" class=\"thstyleRight\" >" + s_Preson + "</th></tr>\n";
            s_Head += "<tr >\n<th class=\"thstyle\">序号</th>\n";
            s_Head += "<th class=\"thstyle\">产品</th>\n";
            s_Head += "<th class=\"thstyle\">料号</th>\n";
            s_Head += "<th class=\"thstyle\">版本号</th>\n";
            s_Head += "<th class=\"thstyle\">材料金额</th>\n";
            s_Head += "<th class=\"thstyle\">加工费</th>\n";
            s_Head += "<th class=\"thstyle\">最新总采购成本</th>\n";

            s_Head += "</thead><tbody class=\"scrollContent\">";
            s_Details += "</div>";

            s_Details = s_Head + s_Details;

        }

    }
}
