﻿using System;
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

public partial class Report_Month_View : BasePage
{
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

            DateTime D_Time = DateTime.Now;
            DateTime FirstDayTime = new DateTime(D_Time.Year, 1, 1);
            DateTime EndDayTime = FirstDayTime.AddYears(1).AddDays(-1);
            TimeSpan TS = EndDayTime - FirstDayTime;
            int i_Days = TS.Days;
            int i_Month = 12;
            int weekDay = (short)D_Time.DayOfWeek;
            string s_Head = "";
            KNet.BLL.KNet_Resource_Staff Bll_Staff = new KNet.BLL.KNet_Resource_Staff();
            string s_SonIDs = Bll_Staff.GetSonIDs(AM.KNet_StaffNo);

            s_SonIDs = s_SonIDs.Replace(",", "','");
            string SqlWhere = " 1=1 and StaffNo in ('" + s_SonIDs + "') ";
            DataSet Dts_Table = Bll_Staff.GetList(SqlWhere);
            if (Dts_Table.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                {
                    string s_StaffNo = Dts_Table.Tables[0].Rows[i]["StaffNo"].ToString();
                    s_Details += " <tr>";
                    s_Details += "<td  class='thstyleLeftDetails' align=right noWrap>&nbsp;" + Dts_Table.Tables[0].Rows[i]["StaffName"].ToString() + "</td>\n";//money
                    for (int j = 1; j < i_Month + 1; j++)
                    {
                        DateTime d_NewTime = FirstDayTime.AddMonths(j - 1);
                        string s_State = GetDetails(s_StaffNo, d_NewTime);
                        s_Details += "<td class=\"thstyleLeftDetails\" align=center>&nbsp;" + s_State + "</td>";
                    }
                    s_Details += " </tr>";
                }

            }
            s_Details += "</tbody></table></td></tr>";
            //表头
            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n";
            s_Head += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\" > \n";
            s_Head += "<tr>\n<th colspan=\"" + i_Month + 1 + "\" class=\"MaterTitle\"  style='height:14.25pt'>杭州士腾科技有限公司<br/>月报  " + D_Time.Year + "年度状态</th></tr>\n";
            s_Head += "<tr>\n<th colspan=\"" + i_Month + 1 + "\" class=\"MaterTitle\"  style='height:14.25pt'>状态说明：空白：未交月报;+N:N天后上交报告;√:当日交报告</th></tr>\n";
            s_Head += "<tr><th class=\"thstyle\" rowspan=2 nowrap>姓名</th>\n";

            for (int i = 1; i < i_Month + 1; i++)
            {
                s_Head += "<th class=\"thstyle\" align=center nowrap>" + i.ToString() + "月</th>";
            }
            s_Head += "</tr>";
            s_Head += "</thead><tbody class=\"scrollContent\">";
            s_Details += "</div>";

            this.Lbl_Details.Text = s_Head + s_Details;
        }
    }
    private string GetDetails(string s_StaffNO, DateTime D_Day)
    {
        string s_Return = "";
        try
        {
            DateTime D_Time = D_Day;

            DateTime FirstDayTime = new DateTime(D_Time.Year, D_Time.Month, 1);
            DateTime EndDayTime = FirstDayTime.AddMonths(1).AddDays(-1);
            int weekDay = (short)D_Time.DayOfWeek;
            KNet.BLL.OA_Person_Report bll = new KNet.BLL.OA_Person_Report();
            string s_Sql = "  OPR_Stime>='" + FirstDayTime + "' and OPR_Stime<='" + EndDayTime + "'";
            s_Sql += "  and OPR_Type='3' and  OPR_DutyPerson='" + s_StaffNO + "' ";
            DataSet Dts_Table = bll.GetList(s_Sql);
            if (Dts_Table.Tables[0].Rows.Count > 0)
            {
                DateTime OPR_MTime = DateTime.Parse(Dts_Table.Tables[0].Rows[0]["OPR_MTime"].ToString());
                TimeSpan TS = OPR_MTime - D_Time;
                int i_Days = 0;
                i_Days = TS.Days;
                if (i_Days <= 31)
                {
                    s_Return = "<font color=green>√</font>";
                }
                else
                {
                    s_Return = "<font color=red>" + i_Days + "</font>";

                }
            }
        }
        catch
        { }
        return s_Return;
    }

    protected void Button2_OnServerClick(object sender, EventArgs e)
    {
        Response.Buffer = true;
        Response.Clear();
        Response.ClearContent();
        Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode("月报-年度状态.xls", System.Text.Encoding.UTF8).ToString());
        //Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");

        Response.ContentType = "application/ms-excel";
        Response.Write(this.Lbl_Details.Text);
        Response.Flush();
        Response.End();
    }
}
