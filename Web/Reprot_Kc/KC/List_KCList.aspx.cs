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
            string s_Sql = "Select HouseNo,ProductsBarCode,ProductsName,ProductsEdition,Sum(DirectInAmount),avg(DirectInUnitPrice)";
            s_Sql += ",Sum(DirectInTotalNet),(Select Top 1 SEM_RkTime from Sc_Expend_Manage_MaterDetails a join Sc_Expend_Manage b on a.SED_SEMID=b.SEM_ID and SED_ProductsBarCode=ProductsBarCode  order by SEM_RkTime desc) LastHlTime from v_store Where 1=1  ";
            string s_StartDate = Request.QueryString["StartDate"] == null ? "" : Request.QueryString["StartDate"].ToString();
            string s_EndDate = Request.QueryString["EndDate"] == null ? "" : Request.QueryString["EndDate"].ToString();
            string s_HouseNo = Request.QueryString["HouseNo"] == null ? "" : Request.QueryString["HouseNo"].ToString();
            string s_ProductsName = Request.QueryString["ProductsName"] == null ? "" : Request.QueryString["ProductsName"].ToString();
            string s_ProductsEdition = Request.QueryString["ProductsEdition"] == null ? "" : Request.QueryString["ProductsEdition"].ToString();
            string s_ProductsType = Request.QueryString["ProductsType"] == null ? "" : Request.QueryString["ProductsType"].ToString();
            string s_Number = Request.QueryString["Number"] == null ? "" : Request.QueryString["Number"].ToString();

            string s_Style = "";
            string s_Head = "";
            Decimal DTotalNum = 0, DTotalNet = 0;

            if (s_StartDate != "")
            {
                s_Sql += " and DirectInDateTime>='" + s_StartDate + "'";
            }
            if (s_EndDate != "")
            {
                s_Sql += " and DirectInDateTime<='" + s_EndDate + "'";
            }
            if (s_ProductsName != "")
            {
                s_Sql += " and ProductsName like '%" + s_ProductsName + "%'  ";
            } 
            if (s_ProductsEdition != "")
            {
                s_Sql += " and ProductsEdition like '%" + s_ProductsEdition + "%'  ";
            }
            if (s_HouseNo != "")
            {
                s_Sql += " and HouseNo in ('" + s_HouseNo.Substring(0, s_HouseNo.Length - 1).Replace(",", "','") + "')  ";
            }

            if (s_ProductsType != "")
            {
                KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
                string s_SonID = Bll_ProductsDetails.GetSonIDs(s_ProductsType);
                s_SonID = s_SonID.Replace(",", "','");
                s_Sql += " and ProductsType in ('" + s_SonID + "') ";
            }
            s_Sql += "Group by HouseNo,ProductsBarCode,ProductsName,ProductsEdition ";
            if (s_Number != "")
            {
                if (s_Number == "-1")
                {
                    s_Sql += " having Sum(DirectInAmount)<0 ";
                }
                else if (s_Number == "1")
                {
                    s_Sql += " having Sum(DirectInAmount)>0 ";

                }
            }
            s_Sql += " Order by HouseNo,ProductsName ";

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
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + base.Base_GetHouseName(Dtb_Table.Rows[i][0].ToString()) + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + Dtb_Table.Rows[i][2].ToString() + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + base.Base_GetProductsCode(Dtb_Table.Rows[i][1].ToString()) + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + base.Base_GetProductsPattern(Dtb_Table.Rows[i][1].ToString()) + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + Dtb_Table.Rows[i][3].ToString().ToString() + "</td>\n";
                    string s_URL = "../CkDetails/List_CkList.aspx?StartDate=" + s_StartDate + "&EndDate=" + s_EndDate + "&HouseNo=" + Dtb_Table.Rows[i][0].ToString() + "&ProductsType=" + s_ProductsType + "&ProductsEdition=" + s_ProductsEdition + "&Number=";
                    string s_Number1=Dtb_Table.Rows[i][4].ToString();
                    s_Details += "<td align=right class='thstyleLeftDetails' noWrap><a href=" + s_URL + " target=\"_blank\">" + base.FormatNumber1(Dtb_Table.Rows[i][4].ToString().ToString(), 0) + "</a></td>\n";//数量
                    s_Details += "<td align=right class='thstyleLeftDetails' noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i][5].ToString().ToString(), 6) + "</td>\n";//数量
                    s_Details += "<td align=right class='thstyleLeftDetails' noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i][6].ToString().ToString(), 2) + "</td>\n";//数量
                    string s_Price1 = GetLastPriceOrTime(Dtb_Table.Rows[i]["HouseNo"].ToString().ToString(), Dtb_Table.Rows[i]["ProductsBarCode"].ToString().ToString(), 0);
                    s_Price1 = s_Price1 == "" ? "0" : s_Price1;
                    s_Details += "<td align=right class='thstyleLeftDetails' noWrap>" + s_Price1 + "</td>\n";//数量
                    decimal d_Money1 = decimal.Parse(s_Number1) * decimal.Parse(s_Price1);
                    s_Details += "<td align=right class='thstyleLeftDetails' noWrap>" + base.FormatNumber1(d_Money1.ToString(), 2) + "</td>\n";//数量

                    s_Details += "<td align=right class='thstyleLeftDetails' noWrap>" + GetLastPriceOrTime(Dtb_Table.Rows[i]["HouseNo"].ToString().ToString(), Dtb_Table.Rows[i]["ProductsBarCode"].ToString().ToString(), 1) + "&nbsp;</td>\n";//数量

                    s_Details += "<td align=right class='thstyleLeftDetails' noWrap>" + base.DateToString(Dtb_Table.Rows[i]["LastHlTime"].ToString().ToString()) + "&nbsp;</td>\n";//数量
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + GetRC(Dtb_Table.Rows[i][1].ToString()) + "&nbsp;</td>\n";//数量

                    s_Details += " </tr>";
                    DTotalNum += Decimal.Parse(Dtb_Table.Rows[i][4].ToString() == "" ? "0" : Dtb_Table.Rows[i][4].ToString());
                    DTotalNet += Decimal.Parse(Dtb_Table.Rows[i][6].ToString().ToString() == "" ? "0" : Dtb_Table.Rows[i][6].ToString());
                }
            }

            s_Details += " <tr >\n";
            s_Details += "<td  width='1%' class='thstyleLeftDetails' align=left noWrap colspan=6>合计:" + (Dtb_Table.Rows.Count).ToString() + "</td>\n";
            s_Details += "<td align=right class='thstyleLeftDetails' width='1%' noWrap>" + base.FormatNumber1(DTotalNum.ToString(), 0) + "</td>\n";//数量
            s_Details += "<td align=right class='thstyleLeftDetails' width='1%'noWrap>&nbsp;</td>\n";//单价
            s_Details += "<td align=right class='thstyleLeftDetails' width='1%'  noWrap>" + DTotalNet.ToString() + "</td>\n";//金额
            s_Details += "<td align=right class='thstyleLeftDetails' width='1%'noWrap>&nbsp;</td>\n";//单价
            s_Details += "<td align=right class='thstyleLeftDetails' width='1%'noWrap colspan=3>&nbsp;</td>\n";//单价

            s_Details += " </tr>";

            s_Details += "</tbody></table></div>";

            string s_Time = "日期:" + s_StartDate + " 到 " + s_EndDate;
            if ((s_StartDate == "") && (s_EndDate == ""))
            {
                s_Time = "";

            }
            AdminloginMess Am = new AdminloginMess();
            string s_Preson = "制表人:" + Am.KNet_StaffName;
            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n";
            s_Head += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\"> \n";
            s_Head += "<tr>\n<th colspan=\"14\" class=\"MaterTitle\" style='height:14.25pt'>杭州士腾科技有限公司<br/>库存报表</th></tr>\n";
            s_Head += "<tr>\n<th colspan=\"6\" class=\"thstyleleft\"  >" + s_Time + "</th><th colspan=\"8\" class=\"thstyleRight\" >" + s_Preson + "</th></tr>\n";
            s_Head += "<tr >\n<th class=\"thstyle\">序号</th>\n";
            s_Head += "<th class=\"thstyle\">仓库</th>\n";
            s_Head += "<th class=\"thstyle\">产品</th>\n";
            s_Head += "<th class=\"thstyle\">编码</th>\n";
            s_Head += "<th class=\"thstyle\">型号</th>\n";
            s_Head += "<th class=\"thstyle\">版本号</th>\n";
            s_Head += "<th class=\"thstyle\">数量</th>\n";
            s_Head += "<th class=\"thstyle\">单价</th>\n";
            s_Head += "<th class=\"thstyle\">金额</th>\n";
            s_Head += "<th class=\"thstyle\">参考单价</th>\n";
            s_Head += "<th class=\"thstyle\">参考金额</th>\n";
            s_Head += "<th class=\"thstyle\">最后入库时间</th>\n";
            s_Head += "<th class=\"thstyle\">最后消耗时间</th>\n";
            s_Head += "<th class=\"thstyle\">适用遥控器</th>\n</tr></thead><tbody class=\"scrollContent\">";

            s_Details = s_Head + s_Details;

        }

    }

    public string GetLastPriceOrTime(string s_HouseNo,string s_ProductsCode,int i_Type)
    {
        string s_Return = "", s_Sql = "";
        try
        {
            s_Sql = "select top 1 *  from Knet_Procure_WareHouseList_Details a join Knet_Procure_WareHouseList b on a.WareHouseNo=b.WareHouseNo ";
            s_Sql += " where b.HouseNo='" + s_HouseNo + "' and a.ProductsBarCode='" + s_ProductsCode + "' order by WareHouseDateTime desc";

            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            if (this.Dtb_Result.Rows.Count > 0)
            {
                if (i_Type == 0)
                {
                    s_Return = Dtb_Result.Rows[0]["WareHouseUnitPrice"].ToString();
                }
                else
                {
                    s_Return = base.DateToString(Dtb_Result.Rows[0]["WareHouseDateTime"].ToString());
                }
            }
        }
        catch
        { }
        return s_Return;
    }
    public string GetRC(string s_ProductsCode)
    {
        string s_Return = "",s_Sql = "";
        try
        {
            s_Sql = "select b.ProductsEdition from Xs_Products_Prodocts_Demo a join KNet_Sys_Products b on a.XPD_FaterBarCode=b.ProductsBarCode ";
            s_Sql += " where a.XPD_ProductsBarCode='" + s_ProductsCode + "'";

            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            if (this.Dtb_Result.Rows.Count > 0)
            {
                    int i_Num=Dtb_Result.Rows.Count-1;
                for (int i = 0; i < Dtb_Result.Rows.Count; i++)
                {
                    s_Return += Dtb_Result.Rows[i]["ProductsEdition"].ToString();
                    if(i!=i_Num)
                    {
                        s_Return += "<br/>";
                    }
                }
            }
        }
        catch
        { }
        return s_Return;
    }
    public decimal GetCgPrice(string s_ProductsCode)
    {
        decimal d_Price = 0;
        this.BeginQuery("Select top 1 * from Knet_Procure_OrdersList_Details where ProductsBarCode='" + s_ProductsCode + "' and OrderUnitPrice<>0");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            d_Price = Decimal.Parse(Dtb_Result.Rows[0]["OrderUnitPrice"].ToString()) + Decimal.Parse(Dtb_Result.Rows[0]["HandPrice"].ToString());
        }
        return d_Price;
    }
}
