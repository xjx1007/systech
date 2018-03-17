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

public partial class Web_Procure_RC_View : BasePage
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
            string s_SuppNo = Request.QueryString["HouseNo"] == null ? "" : Request.QueryString["HouseNo"].ToString();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string s_ProductsEdition = Request.QueryString["ProductsEdition"] == null ? "" : Request.QueryString["ProductsEdition"].ToString();

            //原材料委外消耗
            string s_Sql = "Select a.SER_HouseNo,a.SEM_STime,a.SER_ProductsBarCode,a.SER_ScNumber,a.SER_ScPrice,a.SER_ScMoney,TypeName ";
            s_Sql += " ";
            s_Sql += " from v_Sc_Expend_Manage a ";
            s_Sql += "  Where 1=1 ";
            if (s_StartDate != "")
            {
                s_Sql += " and  a.SEM_STime>='" + s_StartDate + "'";
            }
            if (s_EndDate != "")
            {
                s_Sql += " and  a.SEM_STime<='" + s_EndDate + "'";
            }
            if (s_SuppNo != "")
            {
                s_Sql += " and  a.SER_HouseNo='" + s_SuppNo + "'";
            }
            if (s_ProductsEdition != "")
            {
                s_Sql += " and  a.SER_ProductsBarCode in (Select ProductsBarCode From KNet_Sys_Products where ProductsEdition like '%" + s_ProductsEdition + "%')";
            }
            if (s_ID != "")
            {
                s_Sql += " and a.SEM_DirectOutNo='" + s_ID + "' ";
            }
            s_Sql += " Order by a.SEM_STime ";
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
                    s_Details += " <tr " + s_Style + " onmouseover='setActiveBG(this)'>\n";
                    s_Details += "<td class='thstyleLeftDetails'align=center noWrap>" + (i + 1).ToString() + "</td>\n";

                    if (s_ID == "")
                    {
                        try
                        {
                            s_Details += "<td  class='thstyleLeftDetails'align=center noWrap>" + DateTime.Parse(Dtb_Table.Rows[i][1].ToString()).ToShortDateString() + "</td>\n";
                        }
                        catch
                        {
                            s_Details += "<td class='thstyleLeftDetails' align=center noWrap>&nbsp;</td>\n";
                        }
                    }
                    s_Details += "<td class='thstyleLeftDetails'align=center noWrap>" + base.Base_GetProdutsName(Dtb_Table.Rows[i][2].ToString()) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails'align=center noWrap>" + base.Base_GetProductsPattern(Dtb_Table.Rows[i][2].ToString()) + "</td>\n";

                    s_Details += "<td  class='thstyleLeftDetails'align=center noWrap>" + base.Base_GetProductsEdition(Dtb_Table.Rows[i][2].ToString()) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails'align=center noWrap>" + Dtb_Table.Rows[i]["TypeName"].ToString() + "</td>\n";

                    s_Details += "<td class='thstyleLeftDetails' align=center noWrap>" + base.Base_GetUnitsName(base.Base_GetProductsUnits(Dtb_Table.Rows[i][2].ToString())) + "</td>\n";

                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(Dtb_Table.Rows[i][3].ToString(), 0) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(Dtb_Table.Rows[i][4].ToString(), 3) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(Dtb_Table.Rows[i][5].ToString(), 3) + "</td>\n";

                    s_Details += " </tr>";
                    try
                    {
                        d_TotalNumber += decimal.Parse(Dtb_Table.Rows[i][3].ToString());
                        d_TotalNet += decimal.Parse(Dtb_Table.Rows[i][5].ToString());
                    }
                    catch
                    {
                    }
                }
                s_Details += " <tr >\n";
                if (s_ID == "")
                {
                    s_Details += "<td class='thstyleLeftDetails'align=center noWrap colspan='6'>合计:</td>\n";
                }
                else
                {
                    s_Details += "<td class='thstyleLeftDetails'align=center noWrap colspan='5'>合计:</td>\n";
                }
                s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_TotalNumber.ToString(), 0) + "</td>\n";
                s_Details += "<td  class='thstyleLeftDetails' align=right noWrap>&nbsp;</td>\n";//money
                s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_TotalNet.ToString(), 3) + "</td>\n";

                s_Details += " </tr>";
                s_Date = DateTime.Parse(Dtb_Table.Rows[0][1].ToString()).ToShortDateString();
                s_House = Dtb_Table.Rows[0][0].ToString();
            }
            s_Details += "</tbody></table></td></tr>";
            if (s_ID != "")
            {
                s_Time = "入库日期:" + s_Date;
            }
            else
            {
                s_Time = "日期:" + s_StartDate + " 到" + s_EndDate;
            }
            s_HouseName = "入库仓库:" + base.Base_GetHouseName(s_House);
            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n";
            s_Head += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\"> \n";
            s_Head += "<tr>\n<th colspan=\"16\" class=\"MaterTitle\" style='height:14.25pt'>杭州士腾科技有限公司<br/>成品入库单</th></tr>\n";
            s_Head += "<tr>\n<th colspan=\"6\" class=\"thstyleleft\"  >" + s_HouseName + "</th><th colspan=\"5\" class=\"thstyleRight\" >" + s_Time + "</th></tr>\n";
            s_Head += "<th class=\"thstyle\" >项次</th>\n";
            if (s_ID == "")
            {
                s_Head += "<th class=\"thstyle\" align=center>入库日期</th>\n";
            }
            s_Head += "<th class=\"thstyle\" align=center>品名</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>型号</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>版本号</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>入库类型</th>\n";
            s_Head += "<th class=\"thstyle\">单位</th>\n";
            s_Head += "<th class=\"thstyle\">数量</th>\n";
            s_Head += "<th class=\"thstyle\">单价</th>\n";
            s_Head += "<th class=\"thstyle\">金额</th>\n";
            s_Head += "</thead><tbody class=\"scrollContent\">";
            s_Details += "</div>";

            this.Lbl_Details.Text = s_Head + s_Details;
        }


    }
}
