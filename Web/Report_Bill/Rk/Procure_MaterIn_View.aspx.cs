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

public partial class Web_Procure_MaterIn_View : BasePage
{
    public string s_Time = "";
    public string s_HouseName = "";
    public string s_Details = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            string s_StartDate = Request.QueryString["StartDate"] == null ? "" : Request.QueryString["StartDate"].ToString();
            string s_EndDate = Request.QueryString["EndDate"] == null ? "" : Request.QueryString["EndDate"].ToString();
            string s_SuppNo = Request.QueryString["SuppNo"] == null ? "" : Request.QueryString["SuppNo"].ToString();
            string s_ProductsEdition = Request.QueryString["ProductsEdition"] == null ? "" : Request.QueryString["ProductsEdition"].ToString();
            string s_HouseNo = Request.QueryString["HouseNo"] == null ? "" : Request.QueryString["HouseNo"].ToString();
            string s_State = Request.QueryString["State"] == null ? "" : Request.QueryString["State"].ToString();
            
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            string s_ProductsBarCode = Request.QueryString["ProductsBarCode"] == null ? "" : Request.QueryString["ProductsBarCode"].ToString();
            
            string s_Sql = "";
            //原材料对账单
            if (s_Type == "0")//明细
            {
                s_Sql = "Select c.ProductsBarCode,d.SuppNo,d.WareHouseDateTime,c.WareHouseAmount,'',";
                s_Sql += "c.WareHouseUnitPrice,c.WareHouseTotalNet,d.HouseNo,d.WareHouseremarks,d.WareHouseDatetime,e.OrderDateTime,c.WareHouseNo,c.KWP_NoTaxMoney ";
                s_Sql += " from  ";
                s_Sql += " Knet_Procure_WareHouseList_Details c ";
                s_Sql += " join Knet_Procure_WareHouseList d on d.WareHouseNo=c.WareHouseNo";
                s_Sql += " left join Knet_Procure_OrdersList e on  e.OrderNO=d.OrderNo Where 1=1 ";
            }
            else
            {
                s_Sql = "Select c.ProductsBarCode,d.SuppNo,c.WareHouseUnitPrice,Sum(c.WareHouseAmount) ";
                s_Sql += " from ";
                s_Sql += " Knet_Procure_WareHouseList_Details c ";
                s_Sql += " join Knet_Procure_WareHouseList d on d.WareHouseNo=c.WareHouseNo";
                s_Sql += " left join Knet_Procure_OrdersList e on  e.OrderNO=d.OrderNo Where 1=1 ";
 
            }
            if (s_StartDate != "")
            {
                s_Sql += " and  WareHouseDateTime>='" + s_StartDate + "'";
            }
            if (s_EndDate != "")
            {
                s_EndDate = s_EndDate + " 23:59:59";
                s_Sql += " and  WareHouseDateTime<='" + s_EndDate + "'";
            }
            if (s_SuppNo != "")
            {
                s_Sql += " and  d.SuppNo='" + s_SuppNo + "'";
            }
            if (s_ProductsEdition != "")
            {
                s_Sql += " and  ProductsBarCode in (Select ProductsBarCode From KNet_Sys_Products where ProductsEdition like '%" + s_ProductsEdition + "%')";
            }
            if (s_ProductsBarCode != "")
            {
                s_Sql += " and  ProductsBarCode='" + s_ProductsBarCode + "'";
 
            }
            if (s_HouseNo != "")
            {
                s_Sql += " and HouseNo='"+s_HouseNo+"' ";
            }
            if (s_State != "")
            {
                s_Sql += " and WareHouseCheckYN='" + s_State + "' ";
 
            }
            if (s_Type == "0")//明细
            {
                s_Sql += " Order by d.WareHouseDateTime ";
            }
            else
            {
                s_Sql += " Group by b.COD_ProductsBarCode,a.COC_SuppNo,b.COd_Price Order by a.COC_SuppNo,b.COD_ProductsBarCode ";
            }
            string s_House = "", s_Style = "", s_Code = "";
            decimal d_TotalNet = 0, d_TotalNet1 = 0;
            decimal d_TotalNumber = 0;
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
                    s_Details += "<td class='thstyleLeftDetails'align=center noWrap>" + (i + 1).ToString() + "</td>\n";
                    if (s_Type == "0")//明细
                    {
                        s_Details += "<td class='thstyleLeftDetails'align=center noWrap>" + Dtb_Table.Rows[i][11].ToString() + "</td>\n";
                        s_Details += "<td class='thstyleLeftDetails'align=center noWrap>" + base.Base_GetSupplierName(Dtb_Table.Rows[i][1].ToString()) + "</td>\n";
                        s_Details += "<td class='thstyleLeftDetails'align=center noWrap>" + base.Base_GetHouseName(Dtb_Table.Rows[i]["HouseNo"].ToString()) + "</td>\n";
                        s_Details += "<td class='thstyleLeftDetails'align=center noWrap>" + base.Base_GetProdutsName(Dtb_Table.Rows[i][0].ToString()) + "</td>\n";
                        s_Details += "<td  class='thstyleLeftDetails'align=center noWrap>" + base.Base_GetProductsEdition(Dtb_Table.Rows[i][0].ToString()) + "</td>\n";
                        s_Details += "<td class='thstyleLeftDetails' align=center noWrap>" + base.Base_GetUnitsName(base.Base_GetProductsUnits(Dtb_Table.Rows[i][0].ToString())) + "</td>\n";
                        try
                        {
                            s_Details += "<td  class='thstyleLeftDetails'align=center noWrap>" + DateTime.Parse(Dtb_Table.Rows[i][2].ToString()).ToShortDateString() + "</td>\n";
                        }
                        catch
                        {
                            s_Details += "<td class='thstyleLeftDetails' align=center noWrap>&nbsp;</td>\n";
                        }
                        s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i][3].ToString(), 0) + "</td>\n";
                        s_Details += "<td  class='thstyleLeftDetails' align=right noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i][5].ToString(), 3) + "</td>\n";//money
                        s_Details += "<td  class='thstyleLeftDetails' align=right noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i][6].ToString(), 3) + "</td>\n";//money
                        s_Details += "<td  class='thstyleLeftDetails' align=right noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["KWP_NoTaxMoney"].ToString(), 3) + "</td>\n";//money

                        
                        s_Details += "<td  class='thstyleLeftDetails' align=center noWrap>&nbsp;" + Dtb_Table.Rows[i][8].ToString() + "</td>\n";
                        s_Details += " </tr>";
                        try
                        {
                            d_TotalNet += decimal.Parse(Dtb_Table.Rows[i][6].ToString());
                            d_TotalNet1 += decimal.Parse(Dtb_Table.Rows[i]["KWP_NoTaxMoney"].ToString());
                            d_TotalNumber += decimal.Parse(Dtb_Table.Rows[i][3].ToString());
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        s_Details += "<td class='thstyleLeftDetails'align=center noWrap>" + base.Base_GetSupplierName(Dtb_Table.Rows[i][1].ToString()) + "</td>\n";
                        s_Details += "<td class='thstyleLeftDetails'align=center noWrap>" + base.Base_GetProdutsName(Dtb_Table.Rows[i][0].ToString()) + "</td>\n";
                        s_Details += "<td  class='thstyleLeftDetails'align=center noWrap>" + base.Base_GetProductsEdition(Dtb_Table.Rows[i][0].ToString()) + "</td>\n";
                        s_Details += "<td class='thstyleLeftDetails' align=center noWrap>" + base.Base_GetUnitsName(base.Base_GetProductsUnits(Dtb_Table.Rows[i][0].ToString())) + "</td>\n";

                        s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i][3].ToString(), 0) + "</td>\n";
                        s_Details += "<td  class='thstyleLeftDetails' align=right noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i][2].ToString(), 3) + "</td>\n";//money
                        try
                        {
                            s_Details += "<td  class='thstyleLeftDetails' align=right noWrap>" + base.FormatNumber1(Convert.ToString(decimal.Parse(Dtb_Table.Rows[i][2].ToString()) * decimal.Parse(Dtb_Table.Rows[i][3].ToString())), 3) + "</td>\n";//money
                        }
                        catch
                        { }
                        s_Details += " </tr>";
                        try
                        {
                            d_TotalNumber += decimal.Parse(Dtb_Table.Rows[i][3].ToString());
                            d_TotalNet += decimal.Parse(Dtb_Table.Rows[i][2].ToString()) * decimal.Parse(Dtb_Table.Rows[i][3].ToString());
                    
                        }
                        catch
                        {
                        }
                    }

                }
                if (s_Type == "0")//明细
                {
                    s_Details += " <tr >\n";
                    s_Details += "<td class='thstyleLeftDetails'align=center noWrap colspan='8'>合计:</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_TotalNumber.ToString(), 0) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right noWrap>&nbsp;</td>\n";//money
                    s_Details += "<td  class='thstyleLeftDetails' align=right noWrap>&nbsp;" + base.FormatNumber1(d_TotalNet.ToString(), 3) + "</td>\n";//money
                    s_Details += "<td  class='thstyleLeftDetails' align=right noWrap>&nbsp;" + base.FormatNumber1(d_TotalNet1.ToString(), 3) + "</td>\n";//money

                    s_Details += "<td  class='thstyleLeftDetails' align=center noWrap>&nbsp;</td>\n";
                    s_Details += " </tr>";
                    s_House = Dtb_Table.Rows[0][1].ToString();
                    s_Code = Dtb_Table.Rows[0][11].ToString();
                }
                else
                {
                    s_Details += " <tr >\n";
                    s_Details += "<td class='thstyleLeftDetails'align=center noWrap colspan='6'>合计:</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_TotalNumber.ToString(), 0) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right noWrap>&nbsp;</td>\n";//money
                    s_Details += "<td  class='thstyleLeftDetails' align=right noWrap>&nbsp;" + base.FormatNumber1(d_TotalNet.ToString(), 3) + "</td>\n";//money
                    s_Details += " </tr>";
                    s_House = Dtb_Table.Rows[0][1].ToString();
                }
            }
            s_Details += "</tbody></table></td></tr>";

            s_Time = "日期:" + s_StartDate + " 到" + s_EndDate;
            s_HouseName = "供应商名称:" + base.Base_GetSupplierName(s_House);
            if (s_Type == "0")//明细
            {
                s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n";
                s_Head += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\"> \n";
                s_Head += "<tr>\n<th colspan=\"12\" class=\"MaterTitle\" style='height:14.25pt'>杭州士腾科技有限公司<br/>原材料入库明细</th></tr>\n";
                s_Head += "<tr>\n<th colspan=\"7\" class=\"thstyleleft\"  ></th><th colspan=\"5\" class=\"thstyleRight\" >" + s_Time + "</th></tr>\n";
                s_Head += "<th class=\"thstyle\" >项次</th>\n";
                s_Head += "<th class=\"thstyle\" align=center>单号</th>\n";
                s_Head += "<th class=\"thstyle\" align=center>供应商</th>\n";
                s_Head += "<th class=\"thstyle\" align=center>入库仓库</th>\n";
                s_Head += "<th class=\"thstyle\" align=center>品名</th>\n";
                s_Head += "<th class=\"thstyle\" align=center>型号</th>\n";
                s_Head += "<th class=\"thstyle\">单位</th>\n";
                s_Head += "<th class=\"thstyle\" >到货日期</th>\n";
                s_Head += "<th class=\"thstyle\" >入库数量</th>\n";
                s_Head += "<th class=\"thstyle\" align=center >单价</th>\n";
                s_Head += "<th class=\"thstyle\" align=center>总额</th>\n";
                s_Head += "<th class=\"thstyle\" align=center>不含税金额</th>\n";
                s_Head += "<th class=\"thstyle\">备注</th>\n";
                s_Head += "</thead><tbody class=\"scrollContent\">";
                s_Details += "</div>";
            }
            else
            {
                s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n";
                s_Head += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\"> \n";
                s_Head += "<tr>\n<th colspan=\"8\" class=\"MaterTitle\" style='height:14.25pt'>杭州士腾科技有限公司<br/>原材料入库汇总</th></tr>\n";
                s_Head += "<tr>\n<th colspan=\"4\" class=\"thstyleleft\"  >入库仓库：原材料库</th><th colspan=\"4\" class=\"thstyleRight\" >" + s_Time + "</th></tr>\n";
                s_Head += "<th class=\"thstyle\" >项次</th>\n";
                s_Head += "<th class=\"thstyle\" align=center>供应商</th>\n";
                s_Head += "<th class=\"thstyle\" align=center>品名</th>\n";
                s_Head += "<th class=\"thstyle\" align=center>型号</th>\n";
                s_Head += "<th class=\"thstyle\">单位</th>\n";
                s_Head += "<th class=\"thstyle\">入库数量</th>\n";
                s_Head += "<th class=\"thstyle\" align=center >单价</th>\n";
                s_Head += "<th class=\"thstyle\" align=center>总额</th>\n";
                s_Head += "</thead><tbody class=\"scrollContent\">";
                s_Details += "</div>";
            }

            this.Lbl_Details.Text = s_Head + s_Details;
        }


    }

    protected void Btn_SaveOnClick(object sender, EventArgs e)
    {
        Excel Excel = new Excel();
        Excel.HtmlToExcel(this.Lbl_Details.Text, "原材料入库");
    }
}
