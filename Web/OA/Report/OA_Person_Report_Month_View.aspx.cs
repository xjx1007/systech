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

public partial class OA_Person_Report_Add : BasePage
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
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            this.Tbx_ID.Text = s_ID;
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            this.Tbx_Type.Text = s_Type;
            this.Tbx_STime.Text = DateTime.Now.ToShortDateString();
            base.Base_DropDutyPersonByFid(this.Ddl_DutyPerson, AM.KNet_StaffNo);

            int weekDay = (short)DateTime.Today.DayOfWeek;

            this.Lbl_DDays.Text = "<font size='5'>" + DateTime.Today.AddDays(1 - DateTime.Now.Day).ToShortDateString() + "  (" + base.Get_Chinese_Week(DateTime.Today.AddDays(1 - DateTime.Now.Day)) + ")  ~" + DateTime.Today.AddDays(1 - DateTime.Now.Day).AddMonths(1).AddDays(-1).ToShortDateString() + "  (" + base.Get_Chinese_Week(DateTime.Today.AddDays(1 - DateTime.Now.Day).AddMonths(1).AddDays(-1)) + ") 月报 </font>";
            this.Lbl_Pre.Text = "<font size='5'><<</font>   ";
            this.Lbl_Next.Text = "<font size='5'>>></font>   ";
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
                ShowInfo(s_ID);
            }
            else
            {
                this.Tbx_NID.Text = base.GetMainID();
                this.Lbl_Title.Text = "新增日报";

                this.CommentList2.CommentFID = this.Tbx_NID.Text;
                this.CommentList2.CommentType = "TotayReport";

                this.CommentList1.CommentFID = this.Tbx_NID.Text;
                this.CommentList1.CommentType = 7;
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

            this.CommentList1.CommentFID = this.Tbx_NID.Text;
            this.CommentList1.CommentType = 7;
            this.Tbx_STime.Text = DateTime.Parse(model.OPR_STime.ToString()).ToShortDateString();
            this.Tbx_ThisReport.Text = KNetPage.KHtmlEncode(model.OPR_ThisReport.ToString());
            this.Tbx_NextReport.Text = KNetPage.KHtmlEncode(model.OPR_NextReport.ToString());
            this.Tbx_Type.Text = model.OPR_Type.ToString();

            DateTime Dtm_Time = DateTime.Parse(this.Tbx_STime.Text).AddDays(-1);

            DataSet Dts_Table1 = bll.GetList(" OPR_Stime='" + Dtm_Time.ToShortDateString() + "' and  OPR_Type='1' and OPR_State='1' and  OPR_DutyPerson='" + this.Ddl_DutyPerson.SelectedValue + "'");
            if (Dts_Table1.Tables[0].Rows.Count > 0)
            {
                this.Lbl_ThisReport.Text = Dts_Table1.Tables[0].Rows[0]["OPR_NextReport"].ToString();
            }
            else
            {
                this.Lbl_ThisReport.Text = "";
            }
        }
    }

    private void ShowInfoByDateTime(string s_DataTime)
    {
        try
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
                this.Lbl_Days.Text = "<font size='4' color=Blue>" + DateTime.Now.ToShortDateString() + "  (" + base.Get_Chinese_Week(DateTime.Now) + ")  " + this.Ddl_DutyPerson.SelectedItem.Text.ToString() + "  </font>";
                this.Tbx_ID.Text = Dts_Table.Tables[0].Rows[0]["OPR_ID"].ToString();
                this.Tbx_NID.Text = Dts_Table.Tables[0].Rows[0]["OPR_ID"].ToString();
                this.CommentList2.CommentFID = Dts_Table.Tables[0].Rows[0]["OPR_ID"].ToString();
                this.CommentList2.CommentType = "TotayReport";
                this.CommentList1.CommentFID = Dts_Table.Tables[0].Rows[0]["OPR_ID"].ToString();
                this.CommentList1.CommentType = 7;
                this.Tbx_STime.Text = DateTime.Parse(Dts_Table.Tables[0].Rows[0]["OPR_STime"].ToString()).ToShortDateString();

                this.Tbx_ThisReport.Text = GetDetails(this.Tbx_ID.Text, 0);
                this.Tbx_NextReport.Text = GetDetails(this.Tbx_ID.Text, 1); 
                this.Tbx_Type.Text = Dts_Table.Tables[0].Rows[0]["OPR_Type"].ToString();
                i_State = int.Parse(Dts_Table.Tables[0].Rows[0]["OPR_State"].ToString());
            }
            else
            {
                this.Lbl_Days.Text = "<font size='4' color=red>" + DateTime.Now.ToShortDateString() + "  (" + base.Get_Chinese_Week(DateTime.Now) + ")  " + this.Ddl_DutyPerson.SelectedItem.Text.ToString() + "  未写</font>";

                this.Lbl_PersonDetails.Text = "<font ></font>";
                this.Tbx_ID.Text = "";

                this.Tbx_NID.Text = "";

                this.CommentList2.CommentFID = this.Tbx_NID.Text;
                this.CommentList2.CommentType = "TotayReport";
                this.CommentList1.CommentFID = this.Tbx_NID.Text;
                this.CommentList1.CommentType =7;
                this.Tbx_ThisReport.Text = "";
                this.Tbx_NextReport.Text = "";
                this.Tbx_Type.Text = "1";
            }

            DateTime Dtm_Time = DateTime.Parse(s_DataTime).AddDays(-1);
            DataSet Dts_Table1 = bll.GetList("  OPR_Stime>='" + D_Time.AddDays(1 - D_Time.Day).AddMonths(-1) + "' and OPR_Stime<='" + D_Time.AddDays(1 - D_Time.Day).AddDays(-1) + "' and  OPR_Type='3'  and OPR_State='1' and  OPR_DutyPerson='" + this.Ddl_DutyPerson.SelectedValue + "'");
            if (Dts_Table1.Tables[0].Rows.Count > 0)
            {
                this.Lbl_ThisReport.Text = GetDetails(Dts_Table1.Tables[0].Rows[0]["OPR_ID"].ToString(),1);
            }
        }
        catch
        { }
    }
    protected void Lbl_Pre_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        this.Tbx_STime.Text = DateTime.Parse(this.Tbx_STime.Text).AddMonths(-1).ToShortDateString();
        DateTime date = DateTime.Parse(this.Tbx_STime.Text);
        int weekDay = (short)date.DayOfWeek;
        this.Lbl_DDays.Text = "<font size='5'>" + date.AddDays(1 - date.Day).ToShortDateString() + "  (" + base.Get_Chinese_Week(date.AddDays(1 - date.Day)) + ")  ~" + date.AddDays(1 - date.Day).AddMonths(1).AddDays(-1).ToShortDateString() + "  (" + base.Get_Chinese_Week(date.AddDays(1 - date.Day).AddMonths(1).AddDays(-1)) + ")  " + AM.KNet_StaffName + "</font>";
        this.ShowInfoByDateTime(this.Tbx_STime.Text);
    }
    protected void Lbl_Next_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        this.Tbx_STime.Text = DateTime.Parse(this.Tbx_STime.Text).AddMonths(1).ToShortDateString();
        DateTime date = DateTime.Parse(this.Tbx_STime.Text);
        int weekDay = (short)date.DayOfWeek;
        this.Lbl_DDays.Text = "<font size='5'>" + date.AddDays(1 - date.Day).ToShortDateString() + "  (" + base.Get_Chinese_Week(date.AddDays(1 - date.Day)) + ")  ~" + date.AddDays(1 - date.Day).AddMonths(1).AddDays(-1).ToShortDateString() + "  (" + base.Get_Chinese_Week(date.AddDays(1 - date.Day).AddMonths(1).AddDays(-1)) + ")  " + AM.KNet_StaffName + "</font>";
        this.ShowInfoByDateTime(this.Tbx_STime.Text);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        this.ShowInfoByDateTime(this.Tbx_STime.Text);
    }

    public string GetDetails(string s_ID, int i_Type)
    {
        StringBuilder Sb_Project = new StringBuilder();
        try
        {
            //
            KNet.BLL.OA_Person_Report_Project Bll_Project = new KNet.BLL.OA_Person_Report_Project();
            DataSet Dts_Project1 = Bll_Project.GetList(" OPRP_FID='" + s_ID + "' and OPRP_Type=" + i_Type + " ");
            if (Dts_Project1.Tables[0].Rows.Count > 0)
            {
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
                    DataSet Dts_Details = Bll_Details.GetList(" OPRD_FFID='" + s_ID + "' and OPRD_FID='" + s_FID + "' and OPRD_Type=" + i_Type + " ");
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
            }

        }
        catch
        { }
        return Sb_Project.ToString();
    }
}
