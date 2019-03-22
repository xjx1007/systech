using KNet.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Report_Bill_List_Products_ElseMateMoney : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin() == false)
            {
                Response.Write(
                    "<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            string s_StartDate = Request.QueryString["Tbx_Time"] == null
                ? ""
                : Request.QueryString["Tbx_Time"].ToString();
           

            string s_Sql = "";
            if (s_StartDate != "")
            {
                string y = s_StartDate.Substring(0, 4);
                int it = s_StartDate.IndexOf("-");
                string m;
                if (s_StartDate.Substring(it + 1, 1) == "0")
                {
                    m = s_StartDate.Substring(it + 2, 1);
                }
                else
                {
                    m = s_StartDate.Substring(it + 1, 2);
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
                    if (i%2 == 0)
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
                    s_Details += "<td class='thstyleLeftDetails'align=center noWrap>" +
                                 Dtb_Table.Rows[i]["SEM_ID"].ToString() + "</td>\n";
                    s_Details += "<td class='thstyleLeftDetails'align=center noWrap>" +
                                 Dtb_Table.Rows[i]["SER_ProductsBarCode"].ToString() + "</td>\n";
                    s_Details += "<td class='thstyleLeftDetails'align=center noWrap>" +
                                 Dtb_Table.Rows[i]["ProductsName"].ToString() + "</td>\n";
                    s_Details += "<td class='thstyleLeftDetails'align=center noWrap>" +
                                 Dtb_Table.Rows[i]["SER_ScNumber"].ToString() + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails'align=center noWrap>" +
                                 Dtb_Table.Rows[i]["SER_UnitManHouse"].ToString() + "</td>\n";
                    s_Details += "<td class='thstyleLeftDetails' align=center noWrap>" +
                                 Dtb_Table.Rows[i]["SER_CountManHouse"].ToString() + "</td>\n";

                    s_Details += "<td  class='thstyleLeftDetails'align=center noWrap>" +
                                 Dtb_Table.Rows[i]["SER_DirectMaterPrice"].ToString() + "</td>\n";


                    //s_Details += "<td class='thstyleLeftDetails' align=center noWrap>&nbsp;</td>\n";

                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" +
                                 Dtb_Table.Rows[i]["SER_DirectMaterMoney"].ToString() + "</td>\n";

                    s_Details += " </tr>";

                }
                s_Details += "</tbody></table></td></tr>";


                s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n";
                s_Head +=
                    "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\"> \n";
                s_Head +=
                    "<tr>\n<th colspan=\"12\" class=\"MaterTitle\" style='height:14.25pt'>杭州士腾科技有限公司<br/>生产入库其他材料费用</th></tr>\n";
                s_Head +=
                    "<tr>\n<th colspan=\"7\" class=\"thstyleleft\"  ></th><th colspan=\"5\" class=\"thstyleRight\" ></th></tr>\n";
                s_Head += "<th class=\"thstyle\" >项次</th>\n";
                s_Head += "<th class=\"thstyle\" align=center>入库编号</th>\n";
                s_Head += "<th class=\"thstyle\" align=center>产品编号</th>\n";
                s_Head += "<th class=\"thstyle\" align=center>产品名称</th>\n";
                s_Head += "<th class=\"thstyle\" align=center>入库数量</th>\n";
                s_Head += "<th class=\"thstyle\" align=center>单位工时</th>\n";
                s_Head += "<th class=\"thstyle\" align=center>总工时</th>\n";
                s_Head += "<th class=\"thstyle\"  align=center >单位其他材料费用</th>\n";

                s_Head += "<th class=\"thstyle\" align=center >总其他材料费用</th>\n";

                s_Head += "</thead><tbody class=\"scrollContent\">";
                s_Details += "</div>";


                this.Lbl_Details.Text = s_Head + s_Details;
            }
        }
    }

    protected void Btn_Save_OnClick(object sender, EventArgs e)
    {
        Excel Excel = new Excel();
        Excel.HtmlToExcel(this.Lbl_Details.Text, "生产入库其他材料费用");
    }
}