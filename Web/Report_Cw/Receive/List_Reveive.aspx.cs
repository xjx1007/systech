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

public partial class Web_List_Details : BasePage
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
            string s_DutyPerson = Request.QueryString["DutyPerson"] == null ? "" : Request.QueryString["DutyPerson"].ToString();
            string s_Have = Request.QueryString["Have"] == null ? "s_Have" : Request.QueryString["Have"].ToString();

            if (s_StartDate == "")
            {
                s_StartDate = "1900-1-1";
            }
            if (s_EndDate == "")
            {
                s_EndDate = "3000-1-1";
            }
            string s_Sql = "select b.CustomerValue,b.CustomerName,b.KSC_DutyPerson,Sum(case when STime<'" + s_StartDate + "' then Money else 0 end) QCMoney,";
            s_Sql += "Sum(case when STime>='" + s_StartDate + "'  and  STime<='" + s_EndDate + "' and  CType in(0,2) then Money else 0 end) BqYsMoney, ";
            s_Sql += "Sum(case when STime>='" + s_StartDate + "'  and  STime<='" + s_EndDate + "' and CType=1 then -Money else 0 end) BqSkMoney,";
            s_Sql += "Sum(case when STime<='" + s_EndDate + "' then Money else 0 end) QMMoney,";
            s_Sql += "Sum(Case when CType<>0  and STime<='" + s_EndDate + "'  then -v_LeftMoney when CType=0  then isnull(CQMoney,0) end) DqMoney,Sum(Case when CType=0 and STime<='" + s_EndDate + "' then d.WCQMoney else 0 end) as wDqMoney, ";
            s_Sql += "Sum(case when  CType in(0) and STime<='" + s_EndDate + "' then d.FPTotalMoney when CType in (1,2) and STime<='" + s_EndDate + "' then Money  else 0 end) BQKPMoney,Sum(case when CType=2 then Money else 0 end) CSHMoney,";
            s_Sql += "Sum(case when  CType in(0) and STime<='" + s_EndDate + "'  then d.FPleftMoney else 0 end) WKPMoney,";
            s_Sql += "Sum(Case when CType<>0  and STime<='" + s_EndDate + "'  then -v_LeftMoney else isnull(d.Dq30Money,0) end ) Dq30Money, ";
            s_Sql += "Sum(Case when CType<>0  and STime<='" + s_EndDate + "' then -v_LeftMoney else isnull(d.Dq60Money,0) end  ) Dq60Money, ";
            s_Sql += "Sum(Case when CType<>0 and STime<='" + s_EndDate + "' then -v_LeftMoney else isnull(d.Dq90Money,0) end  ) Dq90Money, ";
            s_Sql += "Sum(Case when CType<>0 and STime<='" + s_EndDate + "' then -v_LeftMoney else isnull(d.Dq90MoreMoney,0) end ) Dq90MoreMoney ";
            s_Sql += " from v_Receive_Real a join KNET_Sales_ClientList b on a.CustomerValue=b.CustomerValue ";
            s_Sql += " join v_DirectOut_FPMoneyDetails d  on d.ID=a.ID ";
            s_Sql += " where 1=1 ";

            if (s_CustomerName != "")
            {
                s_Sql += " and  b.CustomerName  like '%" + s_CustomerName + "%'";
            }
            if (s_DutyPerson != "")
            {
                s_Sql += " and  b.KSC_DutyPerson='" + s_DutyPerson + "'";
            }
            //仅查看自己
            if (AM.YNAuthority("收款单仅责任人查看") == true)
            {
                if (AM.KNet_StaffName != "项洲")
                {
                    s_Sql += " and b.KSC_DutyPerson='" + AM.KNet_StaffNo + "'  ";
                }
            }

            if (s_Have == "1")
            {
                s_Sql += " and  a.v_State<>'2'";
            }
            s_Sql += "group by CustomerName,b.CustomerValue,b.KSC_DutyPerson order by CustomerName";
            string s_Style = "";
            string s_Head = "";
            decimal d_QCTotalMoney = 0, d_BqRKTotalMoney = 0, d_BqSKTotalMoney = 0, d_QMTotalMoney = 0, d_DqTotalMoney = 0, d_wDqTotalMoney = 0;
            decimal d_WkpMoney = 0, d_KpMoney = 0;
            decimal d_Dq30Money = 0, d_Dq60Money = 0, d_Dq90Money = 0, d_Dq90MoreMoney = 0;

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
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap><a href=\"../Ys/List_Reveive.aspx?CustomerValue=" + Dtb_Table.Rows[i]["CustomerValue"].ToString() + "\" target=\"_blank\">" + Dtb_Table.Rows[i]["CustomerName"].ToString() + "</a></td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>&nbsp;" + base.Base_GetUserName(Dtb_Table.Rows[i]["KSC_DutyPerson"].ToString()) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=Right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["QCMoney"].ToString(), 2) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=Right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["BqYsMoney"].ToString(), 2) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=Right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["BqSkMoney"].ToString(), 2) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["QMMoney"].ToString(), 2) + "</td>\n";
                    decimal d_KPMoney = decimal.Parse(base.FormatNumber1(Dtb_Table.Rows[i]["BQKPMoney"].ToString(), 2));
                    decimal d_WKPMoney = decimal.Parse(Dtb_Table.Rows[i]["WKPMoney"].ToString());
                    if (d_WKPMoney < 0)
                    {
                        d_KPMoney = d_KPMoney + d_WKPMoney;
                        d_WKPMoney = 0;
                        s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + d_KPMoney.ToString() + "</td>\n";
                        s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(d_WKPMoney.ToString(), 2) + "</td>\n";
                    }
                    else
                    {
                        s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + d_KPMoney.ToString() + "</td>\n";
                        s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(d_WKPMoney.ToString(), 2) + "</td>\n";
                    }
                    decimal d_DqMoney=decimal.Parse(Dtb_Table.Rows[i]["DqMoney"].ToString());
                    decimal d_WDqMoney=decimal.Parse(Dtb_Table.Rows[i]["wDqMoney"].ToString());
                    if (d_WDqMoney < 0)
                    {

                        d_DqMoney = d_DqMoney + d_WDqMoney;
                        d_WDqMoney = 0;
                        s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + d_DqMoney.ToString() + "</td>\n";
                        s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(d_WDqMoney.ToString(), 2) + "</td>\n";
         
                    }
                    else
                    {
                        s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["DqMoney"].ToString(), 2) + "</td>\n";
                        s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["wDqMoney"].ToString(), 2) + "</td>\n";
                    } 
                    if (decimal.Parse(Dtb_Table.Rows[i]["Dq30Money"].ToString()) >= 0)
                    {
                        s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["Dq30Money"].ToString(), 2) + "</td>\n";

                        d_Dq30Money += decimal.Parse(Dtb_Table.Rows[i]["Dq30Money"].ToString());
                    }
                    else
                    {
                        s_Details += "<td  class='thstyleLeftDetails' align=Right  noWrap>0</td>\n";

                    }
                    if (decimal.Parse(Dtb_Table.Rows[i]["Dq60Money"].ToString()) >= 0)
                    {
                        s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["Dq60Money"].ToString(), 2) + "</td>\n";

                        d_Dq60Money += decimal.Parse(Dtb_Table.Rows[i]["Dq60Money"].ToString());

                    }
                    else
                    {
                        s_Details += "<td  class='thstyleLeftDetails' align=Right  noWrap>0</td>\n";

                    }
                    if (decimal.Parse(Dtb_Table.Rows[i]["Dq90Money"].ToString()) >= 0)
                    {
                        s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["Dq90Money"].ToString(), 2) + "</td>\n";

                        d_Dq90Money += decimal.Parse(Dtb_Table.Rows[i]["Dq90Money"].ToString());
                    }
                    else
                    {
                        s_Details += "<td  class='thstyleLeftDetails' align=Right  noWrap>0</td>\n";

                    }
                    if (decimal.Parse(Dtb_Table.Rows[i]["Dq90MoreMoney"].ToString()) >= 0)
                    {
                        s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["Dq90MoreMoney"].ToString(), 2) + "</td>\n";

                        d_Dq90MoreMoney += decimal.Parse(Dtb_Table.Rows[i]["Dq90MoreMoney"].ToString());
                    }
                    else
                    {
                        s_Details += "<td  class='thstyleLeftDetails' align=Right  noWrap>0</td>\n";

                    } 
                    try
                    {
                        d_QCTotalMoney += decimal.Parse(Dtb_Table.Rows[i]["QCMoney"].ToString());
                        d_BqRKTotalMoney += decimal.Parse(Dtb_Table.Rows[i]["BqYsMoney"].ToString());
                        d_BqSKTotalMoney += decimal.Parse(Dtb_Table.Rows[i]["BqSkMoney"].ToString());
                        d_QMTotalMoney += decimal.Parse(Dtb_Table.Rows[i]["QMMoney"].ToString());
                        d_DqTotalMoney += d_DqMoney;
                        d_wDqTotalMoney += d_WDqMoney;
                        d_KpMoney += decimal.Parse(Dtb_Table.Rows[i]["BQKPMoney"].ToString());
                        d_WkpMoney += d_WKPMoney;
                    }
                    catch { }
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap></td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap></td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap></td>\n";
                    s_Details += " </tr>";
                }
                s_Details += " <tr >\n";
                s_Details += "<td class='thstyleLeftDetails'align=center noWrap colspan='3'>合计:</td>\n";
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
            }
            s_Details += "</tbody></table></td></tr>";
            s_Time = "日期:" + s_StartDate + " 到" + s_EndDate;
            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n";
            s_Head += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\"> \n";
            s_Head += "<tr>\n<th colspan=\"15\" class=\"MaterTitle\" style='height:14.25pt'>杭州士腾科技有限公司<br/>应收款结存表</th></tr>\n";
            s_Head += "<tr>\n<th colspan=\"8\" class=\"thstyleleft\"  ></th><th colspan=\"7\" class=\"thstyleRight\" >" + s_Time + "</th></tr>\n";
            s_Head += "<th class=\"thstyle\"  align=center >序号</th>\n";
            s_Head += "<th class=\"thstyle\"  align=center >客户</th>\n";
            s_Head += "<th class=\"thstyle\"  align=center >责任人</th>\n";
            s_Head += "<th class=\"thstyle\" align=center >期初金额</th>\n";
            s_Head += "<th class=\"thstyle\" align=center >本期应收款</th>\n";
            s_Head += "<th class=\"thstyle\" align=center >本期收款</th>\n";
            s_Head += "<th class=\"thstyle\" align=center >期末余额</th>\n";
            s_Head += "<th class=\"thstyle\" align=center >已开票金额</th>\n";
            s_Head += "<th class=\"thstyle\" align=center >未开票金额</th>\n";
            s_Head += "<th class=\"thstyle\" align=center >到期应收</th>\n";
            s_Head += "<th class=\"thstyle\" align=center >未到期金额</th>\n";
            s_Head += "<th class=\"thstyle\" align=center >1个月以内</th>\n";
            s_Head += "<th class=\"thstyle\" align=center >2个月以内</th>\n";
            s_Head += "<th class=\"thstyle\" align=center >3个月以内</th>\n";
            s_Head += "<th class=\"thstyle\" align=center >3个月以上</th>\n";
            s_Head += "</thead><tbody class=\"scrollContent\">";
            s_Details += "</div>";
            this.Lbl_Details.Text = s_Head + s_Details;
        }
    }
}
