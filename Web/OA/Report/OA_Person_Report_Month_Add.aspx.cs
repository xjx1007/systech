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
using KNet.DBUtility;
using KNet.Common;
using System.Data.SqlClient;
using System.Text;

public partial class OA_Person_Report_Month_Add : BasePage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();

            string s_Person = AM.KNet_StaffName;
            this.Tbx_Person_0.Value = AM.KNet_StaffName;
            this.Tbx_Person1_0.Value = AM.KNet_StaffName;
            this.Tbx_Person.Text = s_Person;
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            this.Tbx_ID.Text = s_ID;
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            this.Tbx_Type.Text = s_Type;
            this.Tbx_STime.Text = DateTime.Now.ToShortDateString();
            base.Base_DropDutyPerson(this.Ddl_DutyPerson, true);
            this.Ddl_DutyPerson.Enabled = false;

            int weekDay = (short)DateTime.Today.DayOfWeek;

            this.Lbl_Days.Text = "<font size='5'>" + DateTime.Today.AddDays(1 - DateTime.Now.Day).ToShortDateString() + "  (" + base.Get_Chinese_Week(DateTime.Today.AddDays(1 - DateTime.Now.Day)) + ")  ~" + DateTime.Today.AddDays(1 - DateTime.Now.Day).AddMonths(1).AddDays(-1).ToShortDateString() + "  (" + base.Get_Chinese_Week(DateTime.Today.AddDays(1 - DateTime.Now.Day).AddMonths(1).AddDays(-1)) + ")  " + AM.KNet_StaffName + "</font>";
            this.Lbl_Pre.Text = "<font size='5'><<</font>   ";
            this.Lbl_Next.Text = "<font size='5'>>></font>   ";
            this.Button1.Attributes.Add("onclick", "return confirm('你确定提交报告?！')");
            if (s_ID != "")
            {
                this.Tbx_NID.Text = s_ID;
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制月报";
                }
                else
                {
                    this.Lbl_Title.Text = "修改月报";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "暂 存";
                ShowInfoByDateTime(this.Tbx_STime.Text);
            }
            else
            {
                this.Tbx_NID.Text = base.GetMainID();
                this.Lbl_Title.Text = "新增月报";

                this.CommentList2.CommentFID = this.Tbx_NID.Text;
                this.CommentList2.CommentType = "TotayReport";
                ShowInfoByDateTime(this.Tbx_STime.Text);
            }
        }

    }

    private void ShowInfo(string s_ID)
    {
        KNet.BLL.OA_Person_Report bll = new KNet.BLL.OA_Person_Report();
        KNet.Model.OA_Person_Report model = bll.GetModel(s_ID);
        if (model != null)
        {
            this.Tbx_ID.Text = model.OPR_ID.ToString();
            this.Tbx_NID.Text = model.OPR_ID.ToString();
            this.CommentList2.CommentFID = this.Tbx_NID.Text;
            this.CommentList2.CommentType = "TotayReport";
            this.Tbx_STime.Text = DateTime.Parse(model.OPR_STime.ToString()).ToShortDateString();
            this.Tbx_ThisReport.Text = KNetPage.KHtmlDiscode(model.OPR_ThisReport.ToString());
            this.Tbx_NextReport.Text = KNetPage.KHtmlDiscode(model.OPR_NextReport.ToString());
            this.Tbx_Type.Text = model.OPR_Type.ToString();

            DateTime Dtm_Time = DateTime.Parse(this.Tbx_STime.Text).AddDays(-1);

            DataSet Dts_Table1 = bll.GetList(" OPR_Stime='" + Dtm_Time.ToShortDateString() + "' and  OPR_Type='2' and  OPR_DutyPerson='" + this.Ddl_DutyPerson.SelectedValue + "'");
            if (Dts_Table1.Tables[0].Rows.Count > 0)
            {
                this.Lbl_ThisReport.Text = KNetPage.KHtmlDiscode(Dts_Table1.Tables[0].Rows[0]["OPR_NextReport"].ToString());
            }
            else
            {
                this.Lbl_ThisReport.Text = "";
            }
            ShowDetails(model.OPR_State);

            DateTime D_Time = DateTime.Parse(model.OPR_STime.ToString());
            int weekDay = (short)D_Time.DayOfWeek;

        }

        ShowMonth(this.Tbx_STime.Text);
    }

    private void ShowDetails(int i_State)
    {
        if (i_State == 1)
        {
            this.Tbx_ThisReport.Enabled = false;
            this.Tbx_NextReport.Enabled = false;
            this.Button1.Text = "已提交";
            this.Button1.Enabled = false;
            this.Btn_Save.Enabled = false;

        }
        else
        {
            this.Tbx_ThisReport.Enabled = true;
            this.Tbx_NextReport.Enabled = true;
            this.Button1.Text = "提交";
            this.Button1.Enabled = true;
            this.Btn_Save.Enabled = true;
        }
    }
    private void ShowInfoByDateTime(string s_DataTime)
    {
        DateTime D_Time = DateTime.Parse(s_DataTime);
        DateTime FirstDayTime = new DateTime(D_Time.Year, D_Time.Month, 1);
        DateTime EndDayTime = FirstDayTime.AddMonths(1).AddDays(-1);
        TimeSpan TS = EndDayTime - FirstDayTime;
        int Days = TS.Days;
        int weekDay = (short)D_Time.DayOfWeek;
        int i_State = 0;
        AdminloginMess AM = new AdminloginMess();
        KNet.BLL.OA_Person_Report bll = new KNet.BLL.OA_Person_Report();
        DataSet Dts_Table = bll.GetList(" OPR_Stime>='" + D_Time.AddDays(1 - D_Time.Day) + "' and OPR_Stime<='" + D_Time.AddDays(1 - D_Time.Day).AddMonths(1).AddDays(-1) + "' and OPR_Type='3' and  OPR_DutyPerson='" + this.Ddl_DutyPerson.SelectedValue + "' ");
        if (Dts_Table.Tables[0].Rows.Count > 0)
        {

            this.Tbx_ID.Text = Dts_Table.Tables[0].Rows[0]["OPR_ID"].ToString();
            this.Tbx_NID.Text = Dts_Table.Tables[0].Rows[0]["OPR_ID"].ToString();
            this.CommentList2.CommentFID = Dts_Table.Tables[0].Rows[0]["OPR_ID"].ToString();
            this.CommentList2.CommentType = "TotayReport";
            this.Tbx_STime.Text = DateTime.Parse(Dts_Table.Tables[0].Rows[0]["OPR_STime"].ToString()).ToShortDateString();
            this.Tbx_ThisReport.Text = KNetPage.KHtmlDiscode(Dts_Table.Tables[0].Rows[0]["OPR_ThisReport"].ToString());
            this.Tbx_NextReport.Text = KNetPage.KHtmlDiscode(Dts_Table.Tables[0].Rows[0]["OPR_NextReport"].ToString());
            this.Tbx_Type.Text = Dts_Table.Tables[0].Rows[0]["OPR_Type"].ToString();
            i_State = int.Parse(Dts_Table.Tables[0].Rows[0]["OPR_State"].ToString());

            KNet.BLL.OA_Person_Report_Project Bll_Project = new KNet.BLL.OA_Person_Report_Project();
            DataSet Dts_Project = Bll_Project.GetList(" OPRP_FID='" + this.Tbx_ID.Text + "' and OPRP_Type=0 ");
            if (Dts_Project.Tables[0].Rows.Count > 0)
            {
                StringBuilder Sb_Project = new StringBuilder();
                this.Tr_ThisReport.Visible = false;

                this.Lbl_ThisProject.Visible = true;
                int i_num = 0;
                for (int i = 0; i < Dts_Project.Tables[0].Rows.Count; i++)
                {
                    string s_FID = Dts_Project.Tables[0].Rows[i]["OPRP_ProjectNum"].ToString();
                    string s_Project = Dts_Project.Tables[0].Rows[i]["OPRP_Project"].ToString();

                    Sb_Project.Append("<tr>\n");
                    Sb_Project.Append("<td class=\"ListHeadDetails\" width=\"25%\" nowrap>\n");
                    Sb_Project.Append("<a href=\"#\" onclick=\"AddProject(this," + s_FID + ")\">添加</a>\n");
                    Sb_Project.Append("<input type=\"hidden\" name=\"Tbx_ID_" + i.ToString() + "\"  Id=\"Tbx_ID_" + i.ToString() + "\"  value=\"" + s_FID + "\" >\n");
                    Sb_Project.Append("<input type=\"text\" name=\"Tbx_Project_" + i.ToString() + "\" id=\"Tbx_Project_" + i.ToString() + "\"  style=\"width: 70%\" value=\"" + s_Project + "\" />\n");
                    Sb_Project.Append("</td>\n");
                    Sb_Project.Append("<td class=\"ListHeadDetails\" colspan=\"3\" width=\"72%\" nowrap>\n");
                    Sb_Project.Append("<table width=\"100%\" class=\"ListDetails\">\n");
                    KNet.BLL.OA_Person_Report_Details Bll_Details = new KNet.BLL.OA_Person_Report_Details();
                    DataSet Dts_Details = Bll_Details.GetList(" OPRD_FFID='" + this.Tbx_ID.Text + "' and OPRD_FID='" + s_FID + "' and OPRD_Type=0 ");
                    if (Dts_Details.Tables[0].Rows.Count > 0)
                    {
                        for (int j = 0; j < Dts_Details.Tables[0].Rows.Count; j++)
                        {
                            string s_DetailsNum = Dts_Details.Tables[0].Rows[j]["OPRD_DetailsNum"].ToString();
                            string s_ProjectDetails = Dts_Details.Tables[0].Rows[j]["OPRD_ProjectDetails"].ToString();
                            string s_Person = Dts_Details.Tables[0].Rows[j]["OPRD_Person"].ToString();
                            string s_Time = Dts_Details.Tables[0].Rows[j]["OPRD_Time"].ToString();
                            string s_DNum = i_num.ToString();
                            Sb_Project.Append("<tr>\n");
                            Sb_Project.Append("<td class=\"ListHeadDetails\" width=\"24%\">\n");
                            Sb_Project.Append("<a href=\"#\" onclick=\"AddDetails(this," + s_FID + ")\">添加</a>\n");
                            Sb_Project.Append("<input type=\"hidden\" name=\"Tbx_FID_" + s_DNum + "\"  Id=\"Tbx_FID_" + s_DNum + "\"  value=\"" + s_FID + "\" >\n");
                            Sb_Project.Append("<input type=\"text\" name=\"Tbx_ProjectDetails_" + s_DNum + "\" id=\"Tbx_ProjectDetails_" + s_DNum + "\"  style=\"width: 70%\" value=\"" + s_ProjectDetails + "\" />\n");
                            Sb_Project.Append("</td>\n");
                            Sb_Project.Append("<td class=\"ListHeadDetails\" width=\"24%\">\n");
                            Sb_Project.Append("<input type=\"text\" name=\"Tbx_Person_" + s_DNum + "\" id=\"Tbx_Person_" + s_DNum + "\"  style=\"width: 80%\"  value=\"" + s_Person + "\" />\n");
                            Sb_Project.Append("<img  src=\"../../../themes/softed/images/select.gif\"  onclick=\"return btnGetPerson_onclick('Tbx_Person_" + s_DNum + "')\" /></td>\n");
                            Sb_Project.Append("<td class=\"ListHeadDetails\" width=\"24%\">");
                            Sb_Project.Append("<input type=\"text\" name=\"Tbx_Time_" + s_DNum + "\" id=\"Tbx_Time_" + s_DNum + "\"  style=\"width: 80%\" value=\"" + s_Time + "\" />");
                            Sb_Project.Append("<a onclick=\"deleteRow(this)\" href=\"#\">");
                            Sb_Project.Append("<img src=\"../../../themes/softed/images/delete.gif\" border=\"0\"></a>");
                            Sb_Project.Append("</td>");
                            Sb_Project.Append("</tr>");
                            i_num = i_num + 1;
                        }
                    }

                    Sb_Project.Append("</table>");
                    Sb_Project.Append("</td>");
                    Sb_Project.Append("<td class=\"ListHeadDetails\" width=\"3%\">");
                    Sb_Project.Append("<a onclick=\"deleteRow(this)\" href=\"#\">");
                    Sb_Project.Append("<img src=\"../../../themes/softed/images/delete.gif\" border=\"0\"></a>");
                    Sb_Project.Append("</td>\n");
                    Sb_Project.Append("</tr>\n");

                    this.Tbx_TNum.Text = Dts_Project.Tables[0].Rows.Count.ToString();
                    this.Tbx_DNum.Text = i_num.ToString();
                }
                this.Lbl_ThisProject.Text = Sb_Project.ToString();
            }


            DataSet Dts_Project1 = Bll_Project.GetList(" OPRP_FID='" + this.Tbx_ID.Text + "' and OPRP_Type=1 ");
            if (Dts_Project1.Tables[0].Rows.Count > 0)
            {
                StringBuilder Sb_Project = new StringBuilder();
                this.Tr_NextReport.Visible = false;
                this.Lbl_NextProject.Visible = true;
                int i_num = 0;
                for (int i = 0; i < Dts_Project1.Tables[0].Rows.Count; i++)
                {
                    string s_FID = Dts_Project1.Tables[0].Rows[i]["OPRP_ProjectNum"].ToString();
                    string s_Project = Dts_Project1.Tables[0].Rows[i]["OPRP_Project"].ToString();

                    Sb_Project.Append("<tr>\n");
                    Sb_Project.Append("<td class=\"ListHeadDetails\" width=\"25%\" nowrap>\n");
                    Sb_Project.Append("<a href=\"#\" onclick=\"AddProject1(this," + s_FID + ")\">添加</a>\n");
                    Sb_Project.Append("<input type=\"hidden\" name=\"Tbx_ID1_" + i.ToString() + "\"  Id=\"Tbx_ID1_" + i.ToString() + "\"  value=\"" + s_FID + "\" >\n");
                    Sb_Project.Append("<input type=\"text\" name=\"Tbx_Project1_" + i.ToString() + "\" id=\"Tbx_Project1_" + i.ToString() + "\"  style=\"width: 70%\" value=\"" + s_Project + "\" />\n");
                    Sb_Project.Append("</td>\n");
                    Sb_Project.Append("<td class=\"ListHeadDetails\" colspan=\"3\" width=\"72%\" nowrap>\n");
                    Sb_Project.Append("<table width=\"100%\" class=\"ListDetails\">\n");
                    KNet.BLL.OA_Person_Report_Details Bll_Details = new KNet.BLL.OA_Person_Report_Details();
                    DataSet Dts_Details = Bll_Details.GetList(" OPRD_FFID='" + this.Tbx_ID.Text + "' and OPRD_FID='" + s_FID + "' and OPRD_Type=1 ");
                    if (Dts_Details.Tables[0].Rows.Count > 0)
                    {
                        for (int j = 0; j < Dts_Details.Tables[0].Rows.Count; j++)
                        {
                            string s_DetailsNum = Dts_Details.Tables[0].Rows[j]["OPRD_DetailsNum"].ToString();
                            string s_ProjectDetails = Dts_Details.Tables[0].Rows[j]["OPRD_ProjectDetails"].ToString();
                            string s_Person = Dts_Details.Tables[0].Rows[j]["OPRD_Person"].ToString();
                            string s_Time = Dts_Details.Tables[0].Rows[j]["OPRD_Time"].ToString();
                            string s_DNum = i_num.ToString();
                            Sb_Project.Append("<tr>\n");
                            Sb_Project.Append("<td class=\"ListHeadDetails\" width=\"24%\">\n");
                            Sb_Project.Append("<a href=\"#\" onclick=\"AddDetails1(this," + s_FID + ")\">添加</a>\n");
                            Sb_Project.Append("<input type=\"hidden\" name=\"Tbx_FID1_" + s_DNum + "\"  Id=\"Tbx_FID1_" + s_DNum + "\"  value=\"" + s_FID + "\" >\n");
                            Sb_Project.Append("<input type=\"text\" name=\"Tbx_ProjectDetails1_" + s_DNum + "\" id=\"Tbx_ProjectDetails1_" + s_DNum + "\"  style=\"width: 70%\" value=\"" + s_ProjectDetails + "\" />\n");
                            Sb_Project.Append("</td>\n");
                            Sb_Project.Append("<td class=\"ListHeadDetails\" width=\"24%\">\n");
                            Sb_Project.Append("<input type=\"text\" name=\"Tbx_Person1_" + s_DNum + "\" id=\"Tbx_Person1_" + s_DNum + "\"  style=\"width: 80%\"  value=\"" + s_Person + "\" />\n");
                            Sb_Project.Append("<img  src=\"../../../themes/softed/images/select.gif\"  onclick=\"return btnGetPerson_onclick('Tbx_Person1_" + s_DNum + "')\" /></td>\n");
                            Sb_Project.Append("<td class=\"ListHeadDetails\" width=\"24%\">");
                            Sb_Project.Append("<input type=\"text\" name=\"Tbx_Time1_" + s_DNum + "\" id=\"Tbx_Time1_" + s_DNum + "\"  style=\"width: 80%\" value=\"" + s_Time + "\" />");
                            Sb_Project.Append("<a onclick=\"deleteRow(this)\" href=\"#\">");
                            Sb_Project.Append("<img src=\"../../../themes/softed/images/delete.gif\" border=\"0\"></a>");
                            Sb_Project.Append("</td>");
                            Sb_Project.Append("</tr>");
                            i_num = i_num + 1;
                        }
                    }

                    Sb_Project.Append("</table>");
                    Sb_Project.Append("</td>");
                    Sb_Project.Append("<td class=\"ListHeadDetails\" width=\"3%\">");
                    Sb_Project.Append("<a onclick=\"deleteRow(this)\" href=\"#\">");
                    Sb_Project.Append("<img src=\"../../../themes/softed/images/delete.gif\" border=\"0\"></a>");
                    Sb_Project.Append("</td>\n");
                    Sb_Project.Append("</tr>\n");

                    this.Tbx_TNum1.Text = Dts_Project1.Tables[0].Rows.Count.ToString();
                    this.Tbx_DNum1.Text = i_num.ToString();
                }
                this.Lbl_NextProject.Text = Sb_Project.ToString();
            }
        }
        else
        {
            this.Tbx_ID.Text ="";


            this.Tbx_TNum.Text = "1";
            this.Tbx_DNum.Text = "1";

            this.Tbx_TNum1.Text = "1";
            this.Tbx_DNum1.Text = "1";
            this.Tbx_ProjectDetails_0.Value = "1.1";
            this.Tbx_ProjectDetails1_0.Value = "1.1";
            this.Lbl_ThisProject.Visible = false;
            this.Lbl_NextProject.Visible = false;
            this.Tr_NextReport.Visible = true;
            this.Tr_ThisReport.Visible = true;

            this.Tbx_NID.Text = base.GetMainID();

            this.CommentList2.CommentFID = this.Tbx_NID.Text;
            this.CommentList2.CommentType = "TotayReport";
            this.Tbx_ThisReport.Text = "";
            this.Tbx_NextReport.Text = "";
            this.Tbx_Type.Text ="3";
        }

        ShowDetails(i_State);
        DateTime Dtm_Time = DateTime.Parse(s_DataTime).AddDays(-1);

        DataSet Dts_Table1 = bll.GetList("  OPR_Stime>='" + D_Time.AddDays(1 - D_Time.Day).AddMonths(-1) + "' and OPR_Stime<='" + D_Time.AddDays(1 - D_Time.Day).AddDays(-1) + "' and  OPR_Type='3'  and OPR_State='1' and  OPR_DutyPerson='" + this.Ddl_DutyPerson.SelectedValue + "'");
        if (Dts_Table1.Tables[0].Rows.Count > 0)
        {
            this.Lbl_ThisReport.Text = Dts_Table1.Tables[0].Rows[0]["OPR_NextReport"].ToString();
            string s_ID = Dts_Table1.Tables[0].Rows[0]["OPR_ID"].ToString();
            //
            KNet.BLL.OA_Person_Report_Project Bll_Project = new KNet.BLL.OA_Person_Report_Project();
            DataSet Dts_Project1 = Bll_Project.GetList(" OPRP_FID='" + s_ID + "' and OPRP_Type=1 ");
            if (Dts_Project1.Tables[0].Rows.Count > 0)
            {
                StringBuilder Sb_Project = new StringBuilder();
                int i_num = 0;
                for (int i = 0; i < Dts_Project1.Tables[0].Rows.Count; i++)
                {
                    string s_FID = Dts_Project1.Tables[0].Rows[i]["OPRP_ProjectNum"].ToString();
                    string s_Project = Dts_Project1.Tables[0].Rows[i]["OPRP_Project"].ToString();

                    Sb_Project.Append("<tr>\n");
                    Sb_Project.Append("<td class=\"ListHeadDetails\" width=\"25%\" nowrap>" + s_Project + "\n");
                    Sb_Project.Append("</td>\n");
                    Sb_Project.Append("<td class=\"ListHeadDetails\" colspan=\"3\" width=\"72%\" nowrap>\n");
                    Sb_Project.Append("<table width=\"100%\" class=\"ListDetails\">\n");
                    KNet.BLL.OA_Person_Report_Details Bll_Details = new KNet.BLL.OA_Person_Report_Details();
                    DataSet Dts_Details = Bll_Details.GetList(" OPRD_FFID='" + s_ID + "' and OPRD_FID='" + s_FID + "' and OPRD_Type=1 ");
                    if (Dts_Details.Tables[0].Rows.Count > 0)
                    {
                        for (int j = 0; j < Dts_Details.Tables[0].Rows.Count; j++)
                        {
                            string s_DetailsNum = Dts_Details.Tables[0].Rows[j]["OPRD_DetailsNum"].ToString();
                            string s_ProjectDetails = Dts_Details.Tables[0].Rows[j]["OPRD_ProjectDetails"].ToString();
                            string s_Person = Dts_Details.Tables[0].Rows[j]["OPRD_Person"].ToString();
                            string s_Time = Dts_Details.Tables[0].Rows[j]["OPRD_Time"].ToString();
                            string s_DNum = i_num.ToString();
                            Sb_Project.Append("<tr>\n");
                            Sb_Project.Append("<td class=\"ListHeadDetails\" width=\"24%\">" + s_ProjectDetails + "\n</td>");
                            Sb_Project.Append("<td class=\"ListHeadDetails\" width=\"24%\">" + s_Person + "\n</td>");
                            Sb_Project.Append("<td class=\"ListHeadDetails\" width=\"24%\">" + s_Time + "\n</td>");
                            Sb_Project.Append("</tr>");
                            i_num = i_num + 1;
                        }
                    }

                    Sb_Project.Append("</table>");
                    Sb_Project.Append("</td>");
                    Sb_Project.Append("</tr>\n");

                }
                this.Lbl_ThisReport.Text = Sb_Project.ToString();
            }
        }
        else
        {
            this.Lbl_ThisReport.Text = "";
        }
        ShowMonth(s_DataTime);

    }
    public void ShowMonth(string D_Day)
    {

        DateTime D_Time = DateTime.Parse(D_Day);
        DateTime FirstDayTime = new DateTime(D_Time.Year, D_Time.Month, 1);
        DateTime EndDayTime = FirstDayTime.AddMonths(1).AddDays(-1);
        TimeSpan TS = EndDayTime - FirstDayTime;
        int Days = TS.Days;
        int weekDay = (short)D_Time.DayOfWeek;
        string s_Head = "";
        this.Lbl_Details.Text += "<Table width=\"100%\" class=\"small\" >\n";
        this.Lbl_Details.Text += "<tr>\n";
        this.Lbl_Details.Text += "<td width=\"12%\"  class=\"colHeader\">\n";
        this.Lbl_Details.Text += "<b>星期一</b>\n";
        this.Lbl_Details.Text += "</td>\n";
        this.Lbl_Details.Text += "<td width=\"12%\"  class=\"colHeader\">\n";
        this.Lbl_Details.Text += "<b>星期二</b>\n";
        this.Lbl_Details.Text += "</td>\n";

        this.Lbl_Details.Text += "<td width=\"12%\"  class=\"colHeader\">\n";
        this.Lbl_Details.Text += "<b>星期三</b>\n";
        this.Lbl_Details.Text += "</td>\n";

        this.Lbl_Details.Text += "<td width=\"12%\"  class=\"colHeader\">\n";
        this.Lbl_Details.Text += "<b>星期四</b>\n";
        this.Lbl_Details.Text += "</td>\n";

        this.Lbl_Details.Text += "<td width=\"12%\"  class=\"colHeader\">\n";
        this.Lbl_Details.Text += "<b>星期五</b>\n";
        this.Lbl_Details.Text += "</td>\n";

        this.Lbl_Details.Text += "<td width=\"12%\"  class=\"colHeader\">\n";
        this.Lbl_Details.Text += "<b>星期六</b>\n";
        this.Lbl_Details.Text += "</td>\n";
        this.Lbl_Details.Text += "<td width=\"12%\"  class=\"colHeader\">\n";
        this.Lbl_Details.Text += "<b>星期日</b>\n";
        this.Lbl_Details.Text += "</td>\n";
        this.Lbl_Details.Text += "<td width=\"12%\"  class=\"colHeader\">\n";
        this.Lbl_Details.Text += "<b>周总结和计划</b>\n";
        this.Lbl_Details.Text += "</td>\n";
        this.Lbl_Details.Text += "</tr>\n";

        for (int i = 0; i <= Days; i++)
        {
            DateTime Time_Now = FirstDayTime.AddDays(i);
            int i_WeekDay = (short)Time_Now.DayOfWeek;
            if ((i_WeekDay == 1) || (i == Days))
            {
                s_Head += "<tr>\n";
            }
            if ((i_WeekDay != 1) && (i == 0))
            {
                s_Head += "<tr>\n";
                for (int j = 0; j < i_WeekDay - 1; j++)
                {
                    s_Head += "<td width=\"12%\"  height=\"12px\"  class=\"colHeader\">\n&nbsp;";
                    s_Head += "</td>\n";
                }
                s_Head += "<td width=\"12%\" height=\"12px\" class=\"colHeader\">\n";
                s_Head += "<font size=\"2px\" >  " + Time_Now.Day + "</font>";
                s_Head += "</td>\n";
            }
            else
            {
                s_Head += "<td width=\"12%\" height=\"12px\" class=\"colHeader\">\n";
                s_Head += "<font size=\"2px\" >  " + Time_Now.Day + "</font>";
                s_Head += "</td>\n";
            }

            if (i_WeekDay == 0)
            {
                s_Head += "<td width=\"12%\" class=\"colHeader\">\n&nbsp;";
                s_Head += "</td>\n";
                s_Head += "</tr>";
            }
            if ((i_WeekDay == 1) || (i == Days - 1))
            {
                s_Head += "</tr>";
            }

            if (i_WeekDay == 1)
            {
                this.Lbl_Details.Text += "<tr>\n";
            }
            if ((i_WeekDay != 1) && (i == 0))
            {
                this.Lbl_Details.Text += "<tr>\n";
                for (int j = 0; j < i_WeekDay - 1; j++)
                {
                    this.Lbl_Details.Text += "<td width=\"12%\" height=\"70px\" valign=\"top\" class=\"dvtCellInfo\">\n&nbsp;";
                    this.Lbl_Details.Text += "</td>\n";
                }
                this.Lbl_Details.Text += "<td width=\"12%\" valign=\"top\"  height=\"70px\" class=\"dvtCellInfo\">\n&nbsp;";
                this.Lbl_Details.Text += Time_Now.Day + " 日 <HR>";
                this.Lbl_Details.Text += GetDetails(Time_Now, 1);
                this.Lbl_Details.Text += "</td>\n";
            }
            else
            {
                this.Lbl_Details.Text += "<td width=\"12%\" valign=\"top\"  height=\"70px\" class=\"dvtCellInfo\">\n&nbsp;";
                this.Lbl_Details.Text += Time_Now.Day + " 日 <HR>";
                this.Lbl_Details.Text += GetDetails(Time_Now, 1);
                this.Lbl_Details.Text += "</td>\n";
            }


            if (i_WeekDay == 0)
            {
                this.Lbl_Details.Text += "<td width=\"12%\"  height=\"40px\" class=\"dvtCellInfo\">\n&nbsp;";
                this.Lbl_Details.Text += GetDetails(Time_Now, 2);
                this.Lbl_Details.Text += "</td>\n";
                this.Lbl_Details.Text += "</tr>";
            }
        }
        this.Lbl_Details.Text += "</Table>";
    }
    public string GetDetails(DateTime D_Time,int i_Type)
    {
        string s_return = "";
        try
        {

            int weekDay = (short)D_Time.DayOfWeek;
            KNet.BLL.OA_Person_Report bll = new KNet.BLL.OA_Person_Report();
            DataSet Dts_Table=new DataSet();
            if (i_Type == 1)
            {
                Dts_Table = bll.GetList("  OPR_Stime='" + D_Time.ToShortDateString() + "' and  OPR_Type='" + i_Type.ToString() + "' and  OPR_DutyPerson='" + this.Ddl_DutyPerson.SelectedValue + "' ");

            }
            else
            {
                Dts_Table = bll.GetList(" OPR_Stime>='" + D_Time.AddDays(1 - weekDay).AddDays(-7) + "' and OPR_Stime<='" + D_Time.AddDays(7 - weekDay).AddDays(-7) + "' and  OPR_Type='" + i_Type.ToString() + "' and  OPR_DutyPerson='" + this.Ddl_DutyPerson.SelectedValue + "' ");
            }
            if (Dts_Table.Tables[0].Rows.Count > 0)
            {
                if (Dts_Table.Tables[0].Rows[0]["OPR_ThisReport"].ToString() != "")
                {

                    if (i_Type== 1)
                    {
                        s_return += "<font color=\"blue\">当日总结:</font><br>";
                    }
                    else
                    {

                        s_return += "<font color=\"blue\">本周总结:</font><br>";
                    }
                    s_return += KNetPage.KHtmlDiscode(Dts_Table.Tables[0].Rows[0]["OPR_ThisReport"].ToString());
                }
                if (Dts_Table.Tables[0].Rows[0]["OPR_NextReport"].ToString() != "")
                {
                    if (i_Type == 1)
                    {
                        s_return += "<br><font color=\"red\">次日计划:</font><br>";
                    }
                    else
                    {

                        s_return += "<br><font color=\"red\">下周计划:</font><br>";
                    }
                    s_return += KNetPage.KHtmlDiscode(Dts_Table.Tables[0].Rows[0]["OPR_NextReport"].ToString());
                }

            }
        }
        catch
        { }
        return s_return;

    }
    private bool SetValue(KNet.Model.OA_Person_Report model)
    {
        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text == "")
            {
                model.OPR_ID = this.Tbx_NID.Text;
            }
            else
            {
                model.OPR_ID = this.Tbx_ID.Text;
            }
            model.OPR_Code = base.GetNewID("OA_Person_Report", 1);
            model.OPR_STime = DateTime.Parse(this.Tbx_STime.Text.ToString());
            model.OPR_DutyPerson = this.Ddl_DutyPerson.SelectedValue;
            model.OPR_ThisReport = KNetPage.KHtmlEncode(this.Tbx_ThisReport.Text.ToString());
            model.OPR_NextReport = KNetPage.KHtmlEncode(this.Tbx_NextReport.Text.ToString());
            model.OPR_SubmitTime = DateTime.Now;
            model.OPR_Type = 3;
            model.OPR_State = 0;
            model.OPR_CTime = DateTime.Now;
            model.OPR_Creator = AM.KNet_StaffNo;
            model.OPR_MTime = DateTime.Now;
            model.OPR_Mender = AM.KNet_StaffNo;
            model.OPR_Del = 0;

            int i_TNum = int.Parse(this.Tbx_TNum.Text);
            int i_DNum = int.Parse(this.Tbx_DNum.Text);

            int i_TNum1 = int.Parse(this.Tbx_TNum1.Text);
            int i_DNum1 = int.Parse(this.Tbx_DNum1.Text);
            ArrayList arr_Project = new ArrayList();
            ArrayList arr_Details = new ArrayList();
            for (int i = 0; i < i_TNum; i++)
            {
                KNet.Model.OA_Person_Report_Project Model = new KNet.Model.OA_Person_Report_Project();
                string s_IDs = Request["Tbx_ID_" + i.ToString() + ""] == null ? "" : Request["Tbx_ID_" + i.ToString() + ""].ToString();
                string s_Project = Request["Tbx_Project_" + i.ToString() + ""] == null ? "" : Request["Tbx_Project_" + i.ToString() + ""].ToString();

                if (s_IDs != "")
                {
                    Model.OPRP_ProjectNum = int.Parse(s_IDs);
                    Model.OPRP_Project = s_Project;
                    Model.OPRP_ID = base.GetMainID(i);
                    Model.OPRP_FID = model.OPR_ID;
                    Model.OPRP_CTime = DateTime.Now;
                    Model.OPRP_Creator = AM.KNet_StaffNo;
                    Model.OPRP_Type = 0;
                    arr_Project.Add(Model);
                }
            }
            for (int i = 0; i < i_TNum1; i++)
            {
                KNet.Model.OA_Person_Report_Project Model = new KNet.Model.OA_Person_Report_Project();
                string s_IDs = Request["Tbx_ID1_" + i.ToString() + ""] == null ? "" : Request["Tbx_ID1_" + i.ToString() + ""].ToString();
                string s_Project = Request["Tbx_Project1_" + i.ToString() + ""] == null ? "" : Request["Tbx_Project1_" + i.ToString() + ""].ToString();

                if (s_IDs != "")
                {
                    Model.OPRP_ID = base.GetMainID(i + 100);
                    Model.OPRP_FID = model.OPR_ID;
                    Model.OPRP_ProjectNum = int.Parse(s_IDs);
                    Model.OPRP_Project = s_Project;
                    Model.OPRP_CTime = DateTime.Now;
                    Model.OPRP_Creator = AM.KNet_StaffNo;
                    Model.OPRP_Type = 1;
                    arr_Project.Add(Model);
                }
            }

            for (int i = 0; i < i_DNum; i++)
            {

                KNet.Model.OA_Person_Report_Details Model = new KNet.Model.OA_Person_Report_Details();
                string s_FIDs = Request["Tbx_FID_" + i.ToString() + ""] == null ? "" : Request["Tbx_FID_" + i.ToString() + ""].ToString();
                string s_ProjectDetails = Request["Tbx_ProjectDetails_" + i.ToString() + ""] == null ? "" : Request["Tbx_ProjectDetails_" + i.ToString() + ""].ToString();
                string s_Person = Request["Tbx_Person_" + i.ToString() + ""] == null ? "" : Request["Tbx_Person_" + i.ToString() + ""].ToString();
                string s_Time = Request["Tbx_Time_" + i.ToString() + ""] == null ? "" : Request["Tbx_Time_" + i.ToString() + ""].ToString();

                if (s_FIDs != "")
                {
                    Model.OPRD_ID = base.GetMainID(i + 200);
                    Model.OPRD_FID = s_FIDs;
                    Model.OPRD_FFID = model.OPR_ID;
                    Model.OPRD_ProjectNum = int.Parse(s_FIDs);
                    Model.OPRD_DetailsNum = i;
                    Model.OPRD_ProjectDetails = s_ProjectDetails;
                    Model.OPRD_Person = s_Person;
                    Model.OPRD_Time = s_Time;
                    Model.OPRD_CTime = DateTime.Now;
                    Model.OPRD_Type = 0;
                    Model.OPRD_Creator = AM.KNet_StaffNo;
                    arr_Details.Add(Model);
                }
            }

            for (int i = 0; i < i_DNum1; i++)
            {

                KNet.Model.OA_Person_Report_Details Model = new KNet.Model.OA_Person_Report_Details();
                string s_FIDs = Request["Tbx_FID1_" + i.ToString() + ""] == null ? "" : Request["Tbx_FID1_" + i.ToString() + ""].ToString();
                string s_ProjectDetails = Request["Tbx_ProjectDetails1_" + i.ToString() + ""] == null ? "" : Request["Tbx_ProjectDetails1_" + i.ToString() + ""].ToString();
                string s_Person = Request["Tbx_Person1_" + i.ToString() + ""] == null ? "" : Request["Tbx_Person1_" + i.ToString() + ""].ToString();
                string s_Time = Request["Tbx_Time1_" + i.ToString() + ""] == null ? "" : Request["Tbx_Time1_" + i.ToString() + ""].ToString();

                if (s_FIDs != "")
                {
                    Model.OPRD_ID = base.GetMainID(i + 300);
                    Model.OPRD_FID = s_FIDs;
                    Model.OPRD_FFID = model.OPR_ID;
                    Model.OPRD_ProjectNum = int.Parse(s_FIDs);
                    Model.OPRD_DetailsNum = i;
                    Model.OPRD_ProjectDetails = s_ProjectDetails;
                    Model.OPRD_Person = s_Person;
                    Model.OPRD_Time = s_Time;
                    Model.OPRD_Type = 1;
                    Model.OPRD_CTime = DateTime.Now;
                    Model.OPRD_Creator = AM.KNet_StaffNo;
                    arr_Details.Add(Model);
                }
            }
            model.Arr_Detail = arr_Project;
            model.Arr_Detail1 = arr_Details;
            return true;
        }
        catch
        {
            return false;
        }

    }
    protected void Btn_Send_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.Model.OA_Person_Report model = new KNet.Model.OA_Person_Report();
        KNet.BLL.OA_Person_Report bll = new KNet.BLL.OA_Person_Report();

        if (this.SetValue(model) == false)
        {
            Alert("系统错误！");
            return;
        }
        if (this.Tbx_ID.Text != "")//修改
        {
            try
            {
                if (bll.Update(model))
                {
                    AM.Add_Logs("月报修改" + this.Tbx_ID.Text);
                    //base.Base_SendMessage(model.PBM_ID, "月报：<a href='Web/Notice/OA_Person_Report_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PBM_ID + "</a> ");
                    AlertAndRedirect("修改成功！", "OA_Person_Report_Month_Add.aspx?ID=" + this.Tbx_ID.Text + "");
                }
                else
                {
                    AM.Add_Logs("月报修改失败" + this.Tbx_ID.Text);
                    AlertAndRedirect("修改失败！", "OA_Person_Report_Month_Add.aspx?ID=" + this.Tbx_ID.Text + "");
                }
            }
            catch { }
        }
        else
        {

            try
            {
                bll.Add(model);
                //base.Base_SendMessage(model.PBN_ReceiveID, "月报：<a href='Web/Notice/OA_Person_Report_View.aspx?ID=" + model.PBN_ID + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PBN_Title + "</a> ");
                AM.Add_Logs("月报增加" );
                AlertAndRedirect("新增成功！", "OA_Person_Report_Month_Add.aspx?ID=" + this.Tbx_ID.Text + "");
            }
            catch { }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        KNet.Model.OA_Person_Report model = new KNet.Model.OA_Person_Report();
        KNet.BLL.OA_Person_Report bll = new KNet.BLL.OA_Person_Report();
        AdminloginMess AM = new AdminloginMess();
        
        if (this.SetValue(model) == false)
        {
            Alert("系统错误！");
            return;
        }

        try
        {
            model.OPR_State = 1;
            if (bll.Update(model))
            {
                AM.Add_Logs("月报提交" + this.Tbx_ID.Text);
                //base.Base_SendMessage(model.PBM_ID, "月报：<a href='Web/Notice/OA_Person_Report_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PBM_ID + "</a> ");
                AlertAndRedirect("月报提交成功！", "OA_Person_Report_Month_Add.aspx?ID=" + this.Tbx_ID.Text + "");
            }
            else
            {
                AM.Add_Logs("月报修改失败" + this.Tbx_ID.Text);
                AlertAndRedirect("修改失败！", "OA_Person_Report_Month_Add.aspx?ID=" + this.Tbx_ID.Text + "");
            }
        }
        catch { }
    }
    protected void Lbl_Pre_Click(object sender, EventArgs e)
    {
        this.Lbl_Details.Text = "";
        AdminloginMess AM = new AdminloginMess();
        this.Tbx_STime.Text = DateTime.Parse(this.Tbx_STime.Text).AddMonths(-1).ToShortDateString();
        DateTime date = DateTime.Parse(this.Tbx_STime.Text);
        int weekDay = (short)date.DayOfWeek;
        this.Lbl_Days.Text = "<font size='5'>" + date.AddDays(1 - date.Day).ToShortDateString() + "  (" + base.Get_Chinese_Week(date.AddDays(1 - date.Day)) + ")  ~" + date.AddDays(1 - date.Day).AddMonths(1).AddDays(-1).ToShortDateString() + "  (" + base.Get_Chinese_Week(date.AddDays(1 - date.Day).AddMonths(1).AddDays(-1)) + ")  " + AM.KNet_StaffName + "</font>";
        this.ShowInfoByDateTime(this.Tbx_STime.Text);
    }
    protected void Lbl_Next_Click(object sender, EventArgs e)
    {
        this.Lbl_Details.Text = "";
        AdminloginMess AM = new AdminloginMess();
        this.Tbx_STime.Text = DateTime.Parse(this.Tbx_STime.Text).AddMonths(1).ToShortDateString();
        DateTime date = DateTime.Parse(this.Tbx_STime.Text);
        int weekDay = (short)date.DayOfWeek;
        this.Lbl_Days.Text = "<font size='5'>" + date.AddDays(1 - date.Day).ToShortDateString() + "  (" + base.Get_Chinese_Week(date.AddDays(1 - date.Day)) + ")  ~" + date.AddDays(1 - date.Day).AddMonths(1).AddDays(-1).ToShortDateString() + "  (" + base.Get_Chinese_Week(date.AddDays(1 - date.Day).AddMonths(1).AddDays(-1)) + ")  " + AM.KNet_StaffName + "</font>";
        this.ShowInfoByDateTime(this.Tbx_STime.Text);
    }
}
