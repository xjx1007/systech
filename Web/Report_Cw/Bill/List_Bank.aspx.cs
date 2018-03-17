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

public partial class Web_List_Bank : BasePage
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
            string s_Use = Request.QueryString["Use"] == null ? "" : Request.QueryString["Use"].ToString();
            string s_NowDate = DateTime.Now.ToShortDateString();
            string s_CustomerName = Request.QueryString["CustomerName"] == null ? "" : Request.QueryString["CustomerName"].ToString();
            string s_Account = Request.QueryString["Account"] == null ? "" : Request.QueryString["Account"].ToString();


            if (s_StartDate == "")
            {
                s_StartDate = "1900-1-1";
            }
            if (s_EndDate == "")
            {
                s_EndDate = "3000-1-1";
            }

            decimal d_leftMoney = 0;
            //查询上一期期末余额
            string s_Sql = "select isnull(Sum(case when type=2 then -CAA_PayMoney else CAA_PayMoney end ),0) as InitMoney from v_BillDetailsWithoutSum  ";
            s_Sql += " where 1=1  ";

            if (s_StartDate != "")
            {
                s_Sql += " and CAA_PayTime<'" + s_StartDate + "'";
            }
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {

                    s_Details += "<tr>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>" + (i + 1).ToString() + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>" + s_StartDate + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>&nbsp;</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>&nbsp;</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>&nbsp;</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>&nbsp;</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>&nbsp;</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>上期结存</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>&nbsp;</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>&nbsp;</td>\n";
                    d_leftMoney += decimal.Parse(Dtb_Table.Rows[i]["InitMoney"].ToString());
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["InitMoney"].ToString(), 2) + "</td>\n";
                    s_Details += "</tr>\n";

                }
            }

            s_Sql = "select * from v_BillDetailsWithoutSum ";
            s_Sql += " where 1=1  ";
            if (s_StartDate != "")
            {
                s_Sql += " and CAA_PayTime>='" + s_StartDate + "'";
            }
            if (s_EndDate != "")
            {
                s_Sql += " and CAA_PayTime<='" + s_EndDate + "'";
            }

            s_Sql += " Order by CAA_PayTime ";

            string s_Style = "";
            string s_Head = "";

            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
             Dtb_Table = this.Dtb_Result;
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


                    s_Details += "<tr " + s_Style + " onmouseover='setActiveBG(this)'>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>" + (i + 2).ToString() + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>" + base.DateToString(Dtb_Table.Rows[i]["CAA_PayTime"].ToString()) + "&nbsp;</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>" + Dtb_Table.Rows[i]["CAA_BillCode"].ToString() + "&nbsp;</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>" + base.DateToString(Dtb_Table.Rows[i]["CAA_StartDateTime"].ToString()) + "&nbsp;</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>" + base.DateToString(Dtb_Table.Rows[i]["CAA_EndDateTime"].ToString()) + "&nbsp;</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>" + Dtb_Table.Rows[i]["TypeName"].ToString() + "&nbsp;</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>" + base.Base_GetSupplierOrCustomerName(Dtb_Table.Rows[i]["CAA_CustomerValue"].ToString()) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>" + Dtb_Table.Rows[i]["CAA_Details"].ToString() + "&nbsp;</td>\n";
                    if (Dtb_Table.Rows[i]["Type"].ToString() == "2")//付款
                    {
                        decimal d_money = decimal.Parse(Dtb_Table.Rows[i]["CAA_PayMoney"].ToString());
                        s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;</td>\n";
                        s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(d_money.ToString(), 2) + "</td>\n";

                        d_leftMoney += -decimal.Parse(Dtb_Table.Rows[i]["CAA_PayMoney"].ToString());
                    }
                    else
                    {
                        decimal d_money = decimal.Parse(Dtb_Table.Rows[i]["CAA_PayMoney"].ToString());
                        s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(d_money.ToString(), 2) + "</td>\n";
                        s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;</td>\n";
                        d_leftMoney += decimal.Parse(Dtb_Table.Rows[i]["CAA_PayMoney"].ToString());
                    }
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(d_leftMoney.ToString(), 2) + "</td>\n";
                    s_Details += "</tr>\n";

                }
            }


                    /*
                    s_Details += " <tr " + s_Style + " onmouseover='setActiveBG(this)'>\n";
                    s_Details += "<td class='thstyleLeftDetails'align=center noWrap>" + (i + 1).ToString() + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap><a href=\"../Ys/List_Reveive.aspx?CustomerValue=" + Dtb_Table.Rows[i]["CustomerValue"].ToString() + "\" target=\"_blank\">" + Dtb_Table.Rows[i]["CustomerName"].ToString() + "</a></td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=Right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["QCMoney"].ToString(), 2) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=Right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["BqYsMoney"].ToString(), 2) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=Right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["BqSkMoney"].ToString(), 2) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["QMMoney"].ToString(), 2) + "</td>\n";
                    decimal d_KPMoney = decimal.Parse(base.FormatNumber1(Dtb_Table.Rows[i]["BQKPMoney"].ToString(), 2));
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + d_KPMoney.ToString() + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["WKPMoney"].ToString(), 2) + "</td>\n";


                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["DqMoney"].ToString(), 2) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["wDqMoney"].ToString(), 2) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["Dq30Money"].ToString(), 2) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["Dq60Money"].ToString(), 2) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["Dq90Money"].ToString(), 2) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["Dq90MoreMoney"].ToString(), 2) + "</td>\n";

                    try
                    {
                        d_QCTotalMoney += decimal.Parse(Dtb_Table.Rows[i]["QCMoney"].ToString());
                        d_BqRKTotalMoney += decimal.Parse(Dtb_Table.Rows[i]["BqYsMoney"].ToString());
                        d_BqSKTotalMoney += decimal.Parse(Dtb_Table.Rows[i]["BqSkMoney"].ToString());
                        d_QMTotalMoney += decimal.Parse(Dtb_Table.Rows[i]["QMMoney"].ToString());
                        d_DqTotalMoney += decimal.Parse(Dtb_Table.Rows[i]["DqMoney"].ToString());
                        d_wDqTotalMoney += decimal.Parse(Dtb_Table.Rows[i]["wDqMoney"].ToString());
                        d_KpMoney += decimal.Parse(Dtb_Table.Rows[i]["BQKPMoney"].ToString());
                        d_WkpMoney += decimal.Parse(Dtb_Table.Rows[i]["WKPMoney"].ToString());
                        d_Dq30Money += decimal.Parse(Dtb_Table.Rows[i]["Dq30Money"].ToString());
                        d_Dq60Money += decimal.Parse(Dtb_Table.Rows[i]["Dq60Money"].ToString());
                        d_Dq90Money += decimal.Parse(Dtb_Table.Rows[i]["Dq90Money"].ToString());
                        d_Dq90MoreMoney += decimal.Parse(Dtb_Table.Rows[i]["Dq90MoreMoney"].ToString());


                    }
                     * */
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap></td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap></td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap></td>\n";
                    s_Details += " </tr>";

        /*
                s_Details += " <tr >\n";
                s_Details += "<td class='thstyleLeftDetails'align=center noWrap colspan='2'>合计:</td>\n";
                s_Details += "<td  class='thstyleLeftDetails' align=Right  noWrap>" + base.FormatNumber1(d_QCTotalMoney.ToString(), 2) + "</td>\n";
                s_Details += "<td  class='thstyleLeftDetails' align=Right  noWrap>" + base.FormatNumber1(d_BqRKTotalMoney.ToString(), 2) + "</td>\n";
                s_Details += "<td  class='thstyleLeftDetails' align=Right  noWrap>" + base.FormatNumber1(d_BqSKTotalMoney.ToString(), 2) + "</td>\n";
                s_Details += "<td  class='thstyleLeftDetails' align=Right  noWrap>" + base.FormatNumber1(d_QMTotalMoney.ToString(), 2) + "</td>\n";
                s_Details += "<td  class='thstyleLeftDetails' align=Right  noWrap>" + base.FormatNumber1(d_KpMoney.ToString(), 2) + "</td>\n";
                s_Details += "<td  class='thstyleLeftDetails' align=Right  noWrap>" + base.FormatNumber1(d_WkpMoney.ToString(), 2) + "</td>\n";
                s_Details += "<td  class='thstyleLeftDetails' align=Right  noWrap>" + base.FormatNumber1(d_DqTotalMoney.ToString(), 2) + "</td>\n";
                s_Details += "<td  class='thstyleLeftDetails' align=Right  noWrap>" + base.FormatNumber1(d_wDqTotalMoney.ToString(), 2) + "</td>\n";
                s_Details += "<td  class='thstyleLeftDetails' align=Right  noWrap>" + base.FormatNumber1(d_Dq30Money.ToString(), 2) + "</td>\n";
                s_Details += "<td  class='thstyleLeftDetails' align=Right  noWrap>" + base.FormatNumber1(d_Dq60Money.ToString(), 2) + "</td>\n";
                s_Details += "<td  class='thstyleLeftDetails' align=Right  noWrap>" + base.FormatNumber1(d_Dq90Money.ToString(), 2) + "</td>\n";
                s_Details += "<td  class='thstyleLeftDetails' align=Right  noWrap>" + base.FormatNumber1(d_Dq90MoreMoney.ToString(), 2) + "</td>\n";

                s_Details += " </tr>";
         * 
            }*/
            s_Details += "</tbody></table></td></tr>";
            s_Time = "日期:" + s_StartDate + " 到" + s_EndDate;
            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n";
            s_Head += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\"> \n";
            s_Head += "<tr>\n<th colspan=\"11\" class=\"MaterTitle\" style='height:14.25pt'>杭州士腾科技有限公司<br/>票据往来结存表</th></tr>\n";
            s_Head += "<tr>\n<th colspan=\"6\" class=\"thstyleleft\"  ></th><th colspan=\"5\" class=\"thstyleRight\" >" + s_Time + "</th></tr>\n";
            s_Head += "<th class=\"thstyle\"  align=center >序号</th>\n";
            s_Head += "<th class=\"thstyle\"  align=center >日期</th>\n";
            s_Head += "<th class=\"thstyle\"  align=center >票据单号</th>\n";
            s_Head += "<th class=\"thstyle\"  align=center >出票日期</th>\n";
            s_Head += "<th class=\"thstyle\"  align=center >到期日期</th>\n";
            s_Head += "<th class=\"thstyle\" align=center >类型</th>\n";
            s_Head += "<th class=\"thstyle\" align=center >公司/供应商</th>\n";
            s_Head += "<th class=\"thstyle\" align=center >摘要</th>\n";
            s_Head += "<th class=\"thstyle\" align=center >借方金额</th>\n";
            s_Head += "<th class=\"thstyle\" align=center >贷方金额</th>\n";
            s_Head += "<th class=\"thstyle\" align=center >余额</th>\n";
            s_Head += "</thead><tbody class=\"scrollContent\">";
            s_Details += "</div>";
            this.Lbl_Details.Text = s_Head + s_Details;
        }
    }
}
