using KNet.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Report_Bill_List_Products_MakeMoney : BasePage
{
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
            string s_StartDate = Request.QueryString["Tbx_Time"] == null ? "" : Request.QueryString["Tbx_Time"].ToString();
            //string s_EndDate = Request.QueryString["EndDate"] == null ? "" : Request.QueryString["EndDate"].ToString();
            //string s_SuppNo = Request.QueryString["SuppNo"] == null ? "" : Request.QueryString["SuppNo"].ToString();
            //string s_ProductsEdition = Request.QueryString["ProductsEdition"] == null ? "" : Request.QueryString["ProductsEdition"].ToString();
            //string s_HouseNo = Request.QueryString["HouseNo"] == null ? "" : Request.QueryString["HouseNo"].ToString();
            //string s_State = Request.QueryString["State"] == null ? "" : Request.QueryString["State"].ToString();

            //string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            //string s_ProductsBarCode = Request.QueryString["ProductsBarCode"] == null ? "" : Request.QueryString["ProductsBarCode"].ToString();

            string s_Sql = "";
            if (s_StartDate!="")
            {
                string y = s_StartDate.Substring(0, 4);
                int it = s_StartDate.IndexOf("-");
                string m;
                if (s_StartDate.Substring(it+1,1)=="0")
                {
                     m = s_StartDate.Substring(it+2,1);
                }
                else
                {
                     m = s_StartDate.Substring(it+1,2);
                }
                
                s_Sql =
                    "select * from Sc_Expend_Manage_RCDetails a join KNet_Sys_Products b on a.SER_ProductsBarCode=b.ProductsBarCode join Sc_Expend_Manage c on a.SER_SEMID = c.SEM_ID where year(c.SEM_Stime) =" +
                    y + " and month(c.SEM_Stime) =" + m + "";
            }
            else
            {
                s_Sql =
                  "select * from Sc_Expend_Manage_RCDetails a join KNet_Sys_Products b on a.SER_ProductsBarCode=b.ProductsBarCode join Sc_Expend_Manage c on a.SER_SEMID = c.SEM_ID ";
            }
           
            string s_House = "", s_Style = "", s_Code = "";
            decimal d_TotalNet = 0, d_TotalNet1 = 0;
            decimal d_TotalNumber = 0;
            string s_Head = "";
            string s_Details = "";
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
                    //if (s_Type == "0")//明细
                    //{
                        s_Details += "<td class='thstyleLeftDetails'align=center noWrap>" + Dtb_Table.Rows[i]["SEM_ID"].ToString() + "</td>\n";
                        s_Details += "<td class='thstyleLeftDetails'align=center noWrap>" + Dtb_Table.Rows[i]["SER_ProductsBarCode"].ToString() + "</td>\n";
                        s_Details += "<td class='thstyleLeftDetails'align=center noWrap>" + Dtb_Table.Rows[i]["ProductsName"].ToString() + "</td>\n";
                        s_Details += "<td class='thstyleLeftDetails'align=center noWrap>" + Dtb_Table.Rows[i]["SER_ScNumber"].ToString() + "</td>\n";
                        s_Details += "<td  class='thstyleLeftDetails'align=center noWrap>" + Dtb_Table.Rows[i]["SER_UnitManHouse"].ToString() + "</td>\n";
                        s_Details += "<td class='thstyleLeftDetails' align=center noWrap>" + Dtb_Table.Rows[i]["SER_CountManHouse"].ToString() + "</td>\n";
                       
                        s_Details += "<td  class='thstyleLeftDetails'align=center noWrap>" + Dtb_Table.Rows[i]["SER_UnitMakePrice"].ToString() + "</td>\n";
                        
                       
                            //s_Details += "<td class='thstyleLeftDetails' align=center noWrap>&nbsp;</td>\n";
                        
                        s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + Dtb_Table.Rows[i]["SER_CountMakeMoney"].ToString() + "</td>\n";
                        //s_Details += "<td  class='thstyleLeftDetails' align=right noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i][5].ToString(), 3) + "</td>\n";//money
                        //s_Details += "<td  class='thstyleLeftDetails' align=right noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i][6].ToString(), 3) + "</td>\n";//money
                        //s_Details += "<td  class='thstyleLeftDetails' align=right noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["KWP_NoTaxMoney"].ToString(), 3) + "</td>\n";//money


                        //s_Details += "<td  class='thstyleLeftDetails' align=center noWrap>&nbsp;" + Dtb_Table.Rows[i][8].ToString() + "</td>\n";
                        s_Details += " </tr>";
                        //try
                        //{
                        //    d_TotalNet += decimal.Parse(Dtb_Table.Rows[i][6].ToString());
                        //    d_TotalNet1 += decimal.Parse(Dtb_Table.Rows[i]["KWP_NoTaxMoney"].ToString());
                        //    d_TotalNumber += decimal.Parse(Dtb_Table.Rows[i][3].ToString());
                        //}
                        //catch
                        //{
                        //}
                   // }
                    //else
                    //{
                    //    s_Details += "<td class='thstyleLeftDetails'align=center noWrap>" + base.Base_GetSupplierName(Dtb_Table.Rows[i][1].ToString()) + "</td>\n";
                    //    s_Details += "<td class='thstyleLeftDetails'align=center noWrap>" + base.Base_GetProdutsName(Dtb_Table.Rows[i][0].ToString()) + "</td>\n";
                    //    s_Details += "<td  class='thstyleLeftDetails'align=center noWrap>" + base.Base_GetProductsEdition(Dtb_Table.Rows[i][0].ToString()) + "</td>\n";
                    //    s_Details += "<td class='thstyleLeftDetails' align=center noWrap>" + base.Base_GetUnitsName(base.Base_GetProductsUnits(Dtb_Table.Rows[i][0].ToString())) + "</td>\n";

                    //    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i][3].ToString(), 0) + "</td>\n";
                    //    s_Details += "<td  class='thstyleLeftDetails' align=right noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i][2].ToString(), 3) + "</td>\n";//money
                    //    try
                    //    {
                    //        s_Details += "<td  class='thstyleLeftDetails' align=right noWrap>" + base.FormatNumber1(Convert.ToString(decimal.Parse(Dtb_Table.Rows[i][2].ToString()) * decimal.Parse(Dtb_Table.Rows[i][3].ToString())), 3) + "</td>\n";//money
                    //    }
                    //    catch
                    //    { }
                    //    s_Details += " </tr>";
                    //    try
                    //    {
                    //        d_TotalNumber += decimal.Parse(Dtb_Table.Rows[i][3].ToString());
                    //        d_TotalNet += decimal.Parse(Dtb_Table.Rows[i][2].ToString()) * decimal.Parse(Dtb_Table.Rows[i][3].ToString());

                    //    }
                    //    catch
                    //    {
                    //    }
                    //}

                }
                //if (s_Type == "0")//明细
                //{
                //    s_Details += " <tr >\n";
                //    s_Details += "<td class='thstyleLeftDetails'align=center noWrap colspan='8'>合计:</td>\n";
                //    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_TotalNumber.ToString(), 0) + "</td>\n";
                //    s_Details += "<td  class='thstyleLeftDetails' align=right noWrap>&nbsp;</td>\n";//money
                //    s_Details += "<td  class='thstyleLeftDetails' align=right noWrap>&nbsp;" + base.FormatNumber1(d_TotalNet.ToString(), 3) + "</td>\n";//money
                //    s_Details += "<td  class='thstyleLeftDetails' align=right noWrap>&nbsp;" + base.FormatNumber1(d_TotalNet1.ToString(), 3) + "</td>\n";//money

                //    s_Details += "<td  class='thstyleLeftDetails' align=center noWrap>&nbsp;</td>\n";
                //    s_Details += " </tr>";
                //    s_House = Dtb_Table.Rows[0][1].ToString();
                //    s_Code = Dtb_Table.Rows[0][11].ToString();
                //}
                //else
                //{
                //    s_Details += " <tr >\n";
                //    s_Details += "<td class='thstyleLeftDetails'align=center noWrap colspan='6'>合计:</td>\n";
                //    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_TotalNumber.ToString(), 0) + "</td>\n";
                //    s_Details += "<td  class='thstyleLeftDetails' align=right noWrap>&nbsp;</td>\n";//money
                //    s_Details += "<td  class='thstyleLeftDetails' align=right noWrap>&nbsp;" + base.FormatNumber1(d_TotalNet.ToString(), 3) + "</td>\n";//money
                //    s_Details += " </tr>";
                //    s_House = Dtb_Table.Rows[0][1].ToString();
                //}
            }
            s_Details += "</tbody></table></td></tr>";

           // s_Time = "日期:" + s_StartDate + " 到" + s_EndDate;
            //s_HouseName = "供应商名称:" + base.Base_GetSupplierName(s_House);
            //if (s_Type == "0")//明细
            //{
                s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n";
                s_Head += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\"> \n";
                s_Head += "<tr>\n<th colspan=\"12\" class=\"MaterTitle\" style='height:14.25pt'>杭州士腾科技有限公司<br/>生产入库制造费用</th></tr>\n";
                s_Head += "<tr>\n<th colspan=\"7\" class=\"thstyleleft\"  ></th><th colspan=\"5\" class=\"thstyleRight\" ></th></tr>\n";
                s_Head += "<th class=\"thstyle\" >项次</th>\n";
                s_Head += "<th class=\"thstyle\" align=center>入库编号</th>\n";
                s_Head += "<th class=\"thstyle\" align=center>产品编号</th>\n";
                s_Head += "<th class=\"thstyle\" align=center>产品名称</th>\n";
                s_Head += "<th class=\"thstyle\" align=center>入库数量</th>\n";
                s_Head += "<th class=\"thstyle\" align=center>单位工时</th>\n";
                s_Head += "<th class=\"thstyle\" align=center>总工时</th>\n";
                s_Head += "<th class=\"thstyle\"  align=center >单位制造费用</th>\n";
              
                s_Head += "<th class=\"thstyle\" align=center >总制造费用</th>\n";
               
                s_Head += "</thead><tbody class=\"scrollContent\">";
                s_Details += "</div>";
           // }
            //else
            //{
            //    s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n";
            //    s_Head += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\"> \n";
            //    s_Head += "<tr>\n<th colspan=\"8\" class=\"MaterTitle\" style='height:14.25pt'>杭州士腾科技有限公司<br/>原材料入库汇总</th></tr>\n";
            //    s_Head += "<tr>\n<th colspan=\"4\" class=\"thstyleleft\"  >入库仓库：原材料库</th><th colspan=\"4\" class=\"thstyleRight\" >" + s_Time + "</th></tr>\n";
            //    s_Head += "<th class=\"thstyle\" >项次</th>\n";
            //    s_Head += "<th class=\"thstyle\" align=center>供应商</th>\n";
            //    s_Head += "<th class=\"thstyle\" align=center>品名</th>\n";
            //    s_Head += "<th class=\"thstyle\" align=center>型号</th>\n";
            //    s_Head += "<th class=\"thstyle\">单位</th>\n";
            //    s_Head += "<th class=\"thstyle\">入库数量</th>\n";
            //    s_Head += "<th class=\"thstyle\" align=center >单价</th>\n";
            //    s_Head += "<th class=\"thstyle\" align=center>总额</th>\n";
            //    s_Head += "</thead><tbody class=\"scrollContent\">";
            //    s_Details += "</div>";
            //}

            this.Lbl_Details.Text = s_Head + s_Details;
        }
    }

    protected void Btn_Save_OnClick(object sender, EventArgs e)
    {
        Excel Excel = new Excel();
        Excel.HtmlToExcel(this.Lbl_Details.Text, "生产入库制造费用");
    }
}