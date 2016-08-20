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

            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();

            
            string s_NowDate = DateTime.Now.ToShortTimeString();
            string s_CustomerName = Request.QueryString["CustomerName"] == null ? "" : Request.QueryString["CustomerName"].ToString();

            string s_Sql = "select -Money as Money,* ";
            s_Sql += " from v_Receive a left join KNET_Sales_ClientList b on a.CustomerValue=b.CustomerValue ";

            s_Sql += " where Dtype=1 ";
            if (s_Type != "")
            {
                s_Sql += " and  a.CAP_Type  = '" + s_Type + "'";
            }
            if (s_CustomerName != "")
            {
                s_Sql += " and  b.CustomerName  like '%" + s_CustomerName + "%'";
            }
            if (s_StartDate != "")
            {
                s_Sql += " and  sTime  >= '" + s_StartDate + "'";
            }
            if (s_EndDate != "")
            {
                s_Sql += " and  sTime <= '" + s_EndDate + "'";
            }
            s_Sql += " order  by Stime ";
            string  s_Style = "";
            string s_Head = "";
            decimal d_QCTotalMoney = 0, d_BqRKTotalMoney = 0, d_BqSKTotalMoney = 0, d_QMTotalMoney = 0, d_DqTotalMoney = 0, d_wDqTotalMoney = 0;
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
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>" + Dtb_Table.Rows[i]["Code"].ToString() + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>" + base.Base_GetBasicCodeName("766", Dtb_Table.Rows[i]["CAP_Type"].ToString()) + "&nbsp;</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>" + Dtb_Table.Rows[i]["CustomerName"].ToString() + "&nbsp;</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>" + DateTime.Parse(Dtb_Table.Rows[i]["Stime"].ToString()).ToShortDateString() + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=Right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["Money"].ToString(), 2) + "</td>\n";

                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>&nbsp;" + Dtb_Table.Rows[i]["Details"].ToString() + "</td>\n";
                    try
                    {
                        d_QCTotalMoney += decimal.Parse(Dtb_Table.Rows[i]["Money"].ToString());
                        
                    }
                    catch { }
                    s_Details += " </tr>";
                }
                s_Details += " <tr >\n";
                s_Details += "<td class='thstyleLeftDetails'align=center noWrap colspan='5'>合计:</td>\n";
                s_Details += "<td  class='thstyleLeftDetails' align=Right  noWrap>" + base.FormatNumber1(d_QCTotalMoney.ToString(),2) + "</td>\n";

                s_Details += "<td class='thstyleLeftDetails'align=center noWrap >&nbsp;</td>\n";
                s_Details += " </tr>";
              
            }
            s_Details += "</tbody></table></td></tr>";
            s_Time = "日期:" + s_StartDate + " 到" + s_EndDate;
            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n";
            s_Head += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\"> \n";
            s_Head += "<tr>\n<th colspan=\"8\" class=\"MaterTitle\" style='height:14.25pt'>杭州士腾科技有限公司<br/>收款单明细表</th></tr>\n";
            s_Head += "<tr>\n<th colspan=\"3\" class=\"thstyleleft\"  ></th><th colspan=\"5\" class=\"thstyleRight\" >" + s_Time + "</th></tr>\n";
            s_Head += "<th class=\"thstyle\"  align=center >序号</th>\n";
            s_Head += "<th class=\"thstyle\"  align=center >收款单号</th>\n";
            s_Head += "<th class=\"thstyle\"  align=center >类型</th>\n";
            s_Head += "<th class=\"thstyle\"  align=center >客户</th>\n";
            s_Head += "<th class=\"thstyle\"  align=center >日期</th>\n";
            s_Head += "<th class=\"thstyle\"  align=center >收款金额</th>\n";
            s_Head += "<th class=\"thstyle\"  align=center >备注</th>\n";
            s_Head += "</thead><tbody class=\"scrollContent\">";
            s_Details += "</div>";
            this.Lbl_Details.Text = s_Head + s_Details;
        }
    }
}
