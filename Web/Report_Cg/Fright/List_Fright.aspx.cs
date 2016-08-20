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

public partial class List_Fright : BasePage
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
            string s_HouseNo = Request.QueryString["HouseNo"] == null ? "" : Request.QueryString["HouseNo"].ToString();
            string s_QRState = Request.QueryString["QRState"] == null ? "" : Request.QueryString["QRState"].ToString();
            
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string s_ProductsEdition = Request.QueryString["ProductsEdition"] == null ? "" : Request.QueryString["ProductsEdition"].ToString();

            string s_ProductsType = Request.QueryString["ProductsType"] == null ? "" : Request.QueryString["ProductsType"].ToString();
            string s_DutyPerson = Request.QueryString["DutyPerson"] == null ? "" : Request.QueryString["DutyPerson"].ToString();
            string s_Sql = "select * from Xs_Sales_Freight a left join KNet_WareHouse_DirectOutList b on a.XSF_FID=b.DirectOutNo ";
            s_Sql += " where 1=1 ";

            if (s_StartDate != "")
            {
                s_Sql += " and  a.XSF_Stime>='" + s_StartDate + "'";
            }
            if (s_EndDate != "")
            {
                s_Sql += " and  a.XSF_Stime<='" + s_EndDate + "'";
            }
            if (s_SuppNo != "")
            {
                s_Sql += " and  a.XSF_CustomerValue='" + s_SuppNo + "'";
            }

            s_Sql += " Order by a.XSF_Stime ";
            string s_House = "", s_Style = "";
            decimal d_TotalNet = 0;
            decimal d_TotalNumber = 0, d_TotalNumber1 = 0, d_TotalNumber2 = 0, d_TotalNumber3=0;
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
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>&nbsp;" + Dtb_Table.Rows[i]["XSF_Code"].ToString() + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>&nbsp;" + Dtb_Table.Rows[i]["XSF_FID"].ToString() + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>&nbsp;" + base.Base_GetShipDetailProductsPatten(Dtb_Table.Rows[i]["XSF_FID"].ToString()) + "</td>\n";
                        try
                        {
                            s_Details += "<td  class='thstyleLeftDetails'align=left noWrap>" + DateTime.Parse(Dtb_Table.Rows[i][3].ToString()).ToShortDateString() + "</td>\n";
                        }
                        catch
                        {
                            s_Details += "<td class='thstyleLeftDetails' align=center noWrap>&nbsp;</td>\n";
                        }
                    
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>&nbsp;" +base.Base_GetBasicCodeName("755",Dtb_Table.Rows[i]["XSF_Type"].ToString()) + "</td>\n";

                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(Dtb_Table.Rows[i]["XSF_TotalNumber"].ToString(), 0) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(Dtb_Table.Rows[i]["XSF_TotalMoney"].ToString(), 3) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(Dtb_Table.Rows[i]["XSF_FMoney"].ToString(), 3) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(Dtb_Table.Rows[i]["XSF_Money"].ToString(), 3) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.Base_GetSupplierName(Dtb_Table.Rows[i]["XSF_CustomerValue"].ToString()) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.Base_GetSupplierName(Dtb_Table.Rows[i]["XSF_FSuppNo"].ToString()) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>&nbsp;" + Dtb_Table.Rows[i]["KWD_Address"].ToString() + "</td>\n";

                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" +Dtb_Table.Rows[i]["XSF_Remarks"].ToString() + "</td>\n";

                    s_Details += " </tr>";
                    try
                    {
                        d_TotalNumber += decimal.Parse(base.FormatNumber1(Dtb_Table.Rows[i]["XSF_TotalNumber"].ToString(), 0));
                        d_TotalNumber1 += decimal.Parse(base.FormatNumber1(Dtb_Table.Rows[i]["XSF_TotalMoney"].ToString(), 3));
                        d_TotalNumber2 += decimal.Parse(base.FormatNumber1(Dtb_Table.Rows[i]["XSF_FMoney"].ToString(), 3));
                        d_TotalNumber3 += decimal.Parse(base.FormatNumber1(Dtb_Table.Rows[i]["XSF_Money"].ToString(), 3));
                    }
                    catch
                    {
                    }
                }
                s_Details += " <tr >\n";
                    s_Details += "<td class='thstyleLeftDetails'align=center noWrap colspan='5'>合计:</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_TotalNumber.ToString(), 0) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_TotalNumber1.ToString(), 0) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_TotalNumber2.ToString(), 0) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_TotalNumber3.ToString(), 3) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right noWrap colspan='4' >&nbsp;</td>\n";//money

                s_Details += " </tr>";
                s_House = Dtb_Table.Rows[0][0].ToString();
            }
            s_Details += "</tbody></table></td></tr>";
                s_Time = "日期:" + s_StartDate + " 到" + s_EndDate;
            s_HouseName = "入库仓库:" + base.Base_GetHouseName(s_House);
            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n";
            s_Head += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\"> \n";
            s_Head += "<tr>\n<th colspan=\"14\" class=\"MaterTitle\" style='height:14.25pt'>杭州士腾科技有限公司<br/>运费承担明细单</th></tr>\n";
            s_Head += "<tr>\n<th colspan=\"7\" class=\"thstyleleft\"  ></th><th colspan=\"7\" class=\"thstyleRight\" >" + s_Time + "</th></tr>\n";
            s_Head += "<th class=\"thstyle\" >项次</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>编号</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>来源</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>产品</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>发生日期</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>发生原因</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>数量</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>总额</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>供应商承担</th>\n";
            s_Head += "<th class=\"thstyle\">博承承担</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>发货供应商</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>物流公司</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>收货地址</th>\n";
            s_Head += "<th class=\"thstyle\">备注</th>\n";
            s_Head += "</thead><tbody class=\"scrollContent\">";
            s_Details += "</div>";
            this.Lbl_Details.Text = s_Head + s_Details;
        }
    }
}
