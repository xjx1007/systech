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

public partial class Procure_DbWw_Details_View : BasePage
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
            string s_HouseNo = Request.QueryString["HouseNo"] == null ? "" : Request.QueryString["HouseNo"].ToString();
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            string s_ProductsEdition = Request.QueryString["ProductsEdition"] == null ? "" : Request.QueryString["ProductsEdition"].ToString();
            string s_Sql = "";
            if (s_Type == "0")//明细
            {
                s_Sql = "Select ProductsBarCode,'',AllocateDateTime,AllocateAmount,'',HouseNo,'',";
                s_Sql += "AllocateUnitPrice,AllocateTotalNet,'','',AllocateDateTime,'',AllocateNo,Allocate_WwPrice,Allocate_WwMoney ";
                s_Sql += " from v_AllocateList_Details  Where 1=1 ";
            }
            else//汇总
            {

                s_Sql = "Select ProductsBarCode,Sum(AllocateAmount) AllocateAmount,HouseNo,";
                s_Sql += "Sum(isnull(AllocateUnitPrice,0)),Sum(isnull(AllocateTotalNet,0)),Sum(isnull(Allocate_WwPrice,0)) Allocate_WwPrice,Sum(isnull(Allocate_WwMoney,0)) Allocate_WwMoney ";
                s_Sql += " from v_AllocateList_Details  Where 1=1 ";
            }
            //原材料委外发料
            
            if (s_StartDate != "")
            {
                s_Sql += " and  AllocateDateTime>='" + s_StartDate + "'";
            }
            if (s_EndDate != "")
            {
                s_Sql += " and  AllocateDateTime<='" + s_EndDate + "'";
            }
            if (s_HouseNo != "")
            {
                s_Sql += " and  HouseNo='" + s_HouseNo + "'";
            }
            if (s_ProductsEdition != "")
            {
                s_Sql += " and  ProductsBarCode in (Select ProductsBarCode From KNet_Sys_Products where ProductsEdition like '%" + s_ProductsEdition + "%')";
            }
            if (s_Type == "0")//明细
            {
                s_Sql += " Order by AllocateDateTime ";
            }
            else
            {
                s_Sql += "Group by  ProductsBarCode,HouseNo,Allocate_WwPrice Order by HouseNo,ProductsBarCode ";
 
            }
            string s_Date = "", s_House = "", s_Style = "", s_Code = "";
            decimal d_TotalNet = 0;
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

                    if (s_Type == "0")//明细
                    {
                        s_Details += " <tr " + s_Style + " onmouseover='setActiveBG(this)'>\n";
                        s_Details += "<td class='thstyleLeftDetails'align=center noWrap>" + (i + 1).ToString() + "</td>\n";
                        s_Details += "<td class='thstyleLeftDetails'align=center noWrap>" + base.Base_GetHouseName(Dtb_Table.Rows[i][5].ToString()) + "</td>\n";

                        try
                        {
                            s_Details += "<td  class='thstyleLeftDetails'align=center noWrap>" + DateTime.Parse(Dtb_Table.Rows[i][2].ToString()).ToShortDateString() + "</td>\n";
                        }
                        catch
                        {
                            s_Details += "<td class='thstyleLeftDetails' align=center noWrap>&nbsp;</td>\n";
                        }
                        s_Details += "<td class='thstyleLeftDetails'align=center noWrap>" + base.Base_GetProdutsName(Dtb_Table.Rows[i][0].ToString()) + "</td>\n";
                        s_Details += "<td  class='thstyleLeftDetails'align=left noWrap>" + base.Base_GetProductsEdition(Dtb_Table.Rows[i][0].ToString()) + "</td>\n";
                        s_Details += "<td class='thstyleLeftDetails' align=center noWrap>" + base.Base_GetUnitsName(base.Base_GetProductsUnits(Dtb_Table.Rows[i][0].ToString())) + "</td>\n";
                        s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(Dtb_Table.Rows[i][3].ToString(), 0) + "</td>\n";
                        s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(Dtb_Table.Rows[i]["Allocate_WwPrice"].ToString(), 5) + "</td>\n";
                        s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(Dtb_Table.Rows[i]["Allocate_WwMoney"].ToString(), 2) + "</td>\n";
                        s_Details += "<td  class='thstyleLeftDetails' align=center noWrap>&nbsp;" + Dtb_Table.Rows[i][4].ToString() + "</td>\n";

                        s_Details += " </tr>";
                    }
                    else
                    {
                        s_Details += " <tr " + s_Style + " onmouseover='setActiveBG(this)'>\n";
                        s_Details += "<td class='thstyleLeftDetails'align=center noWrap>" + (i + 1).ToString() + "</td>\n";
                        s_Details += "<td class='thstyleLeftDetails'align=center noWrap>" + base.Base_GetHouseName(Dtb_Table.Rows[i]["HouseNo"].ToString()) + "</td>\n";

                        s_Details += "<td class='thstyleLeftDetails'align=center noWrap>" + base.Base_GetProdutsName(Dtb_Table.Rows[i][0].ToString()) + "</td>\n";
                        s_Details += "<td  class='thstyleLeftDetails'align=left noWrap>" + base.Base_GetProductsEdition(Dtb_Table.Rows[i][0].ToString()) + "</td>\n";
                        s_Details += "<td class='thstyleLeftDetails' align=center noWrap>" + base.Base_GetUnitsName(base.Base_GetProductsUnits(Dtb_Table.Rows[i][0].ToString())) + "</td>\n";
                        s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(Dtb_Table.Rows[i]["AllocateAmount"].ToString(), 0) + "</td>\n";

                        s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(Dtb_Table.Rows[i]["Allocate_WwPrice"].ToString(), 5) + "</td>\n";
                        s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(Dtb_Table.Rows[i]["Allocate_WwMoney"].ToString(), 2) + "</td>\n";
                      
                        s_Details += " </tr>";
                    }
                    try
                    {
                        d_TotalNumber += decimal.Parse(Dtb_Table.Rows[i]["AllocateAmount"].ToString());
                        d_TotalNet += decimal.Parse(Dtb_Table.Rows[i]["Allocate_WwMoney"].ToString());
                    }
                    catch
                    {
                    }
                }
                if (s_Type == "0")//明细
                {
                    s_Details += " <tr >\n";
                    s_Details += "<td class='thstyleLeftDetails'align=center noWrap colspan='6'>合计:</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_TotalNumber.ToString(), 0) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right noWrap>&nbsp;</td>\n";//money
                    s_Details += "<td  class='thstyleLeftDetails' align=right noWrap>&nbsp;" + base.FormatNumber1(d_TotalNet.ToString(), 0) + "</td>\n";//money
                    s_Details += "<td  class='thstyleLeftDetails' align=right noWrap>&nbsp;</td>\n";//money
                    
                    s_Details += " </tr>";
                    s_House = Dtb_Table.Rows[0][0].ToString();
                }
                else
                {
                    s_Details += " <tr >\n";
                    s_Details += "<td class='thstyleLeftDetails'align=center noWrap colspan='5'>合计:</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_TotalNumber.ToString(), 0) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right noWrap>&nbsp;</td>\n";//money
                    s_Details += "<td  class='thstyleLeftDetails' align=right noWrap>&nbsp;" + base.FormatNumber1(d_TotalNet.ToString(), 0) + "</td>\n";//money
                    s_Details += " </tr>";
                    s_House = Dtb_Table.Rows[0][2].ToString();
                }
            }
            s_Details += "</tbody></table></td></tr>";
            if (s_HouseNo != "")
            {
                s_HouseNo = "委外厂商：" + base.Base_GetHouseName(s_HouseNo);
            }
            s_Time = "日期:" + s_StartDate + " 到" + s_EndDate;
            
            if (s_Type == "0")//明细
            {
            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n";
            s_Head += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\"> \n";
            s_Head += "<tr>\n<th colspan=\"10\" class=\"MaterTitle\" style='height:14.25pt'>杭州士腾科技有限公司<br/>原材料委外加工调拨发料明细</th></tr>\n";
            s_Head += "<tr>\n<th colspan=\"4\" class=\"thstyleleft\"  >" + s_HouseNo + "</th><th colspan=\"6\" class=\"thstyleRight\" >" + s_Time + "</th></tr>\n";
            s_Head += "<th class=\"thstyle\" >项次</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>委外厂商</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>委外日期</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>品名</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>型号</th>\n";
            s_Head += "<th class=\"thstyle\">单位</th>\n";
            s_Head += "<th class=\"thstyle\">数量</th>\n";
            s_Head += "<th class=\"thstyle\">单价</th>\n";
            s_Head += "<th class=\"thstyle\">金额</th>\n";
            s_Head += "<th class=\"thstyle\">备注</th>\n";
            }
            else
            {
                s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n";
                s_Head += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\"> \n";
                s_Head += "<tr>\n<th colspan=\"8\" class=\"MaterTitle\" style='height:14.25pt'>杭州士腾科技有限公司<br/>原材料委外加工调拨发料汇总</th></tr>\n";
                s_Head += "<tr>\n<th colspan=\"4\" class=\"thstyleleft\"  ></th><th colspan=\"4\" class=\"thstyleRight\" >" + s_Time + "</th></tr>\n";
                s_Head += "<th class=\"thstyle\" >项次</th>\n";
                s_Head += "<th class=\"thstyle\" align=center>委外厂商</th>\n";
                s_Head += "<th class=\"thstyle\" align=center>品名</th>\n";
                s_Head += "<th class=\"thstyle\" align=center>型号</th>\n";
                s_Head += "<th class=\"thstyle\">单位</th>\n";
                s_Head += "<th class=\"thstyle\">数量</th>\n";
                s_Head += "<th class=\"thstyle\">单价</th>\n";
                s_Head += "<th class=\"thstyle\">金额</th>\n";
            }
            s_Head += "</thead><tbody class=\"scrollContent\">";
            s_Details += "</div>";

            this.Lbl_Details.Text = s_Head + s_Details;
        }


    }
}
