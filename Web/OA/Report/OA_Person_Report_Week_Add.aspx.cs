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
using System.IO;

public partial class OA_Person_Report_Add : BasePage
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
            if (weekDay == 0)
            {
                weekDay = 7;
            }
            string a = DateTime.Today.AddDays( weekDay).ToShortDateString();
            this.Lbl_Days.Text = "<font size='5'>" + DateTime.Today.AddDays(1- weekDay).ToShortDateString() + "  (" + base.Get_Chinese_Week(DateTime.Today.AddDays(1 - weekDay)) + ")  ~" + DateTime.Today.AddDays(7 - weekDay).ToShortDateString() + "  (" + base.Get_Chinese_Week(DateTime.Today.AddDays(7 - weekDay)) + ")  " + AM.KNet_StaffName + "</font>";
            this.Lbl_Pre.Text = "<font size='5'><<</font>   ";
            this.Lbl_Next.Text = "<font size='5'>>></font>   ";
            //this.Button1.Attributes.Add("onclick", "return confirm('你确定提交报告?！')");
            if (s_ID != "")
            {
                this.Tbx_NID.Text = s_ID;
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制周报";
                }
                else
                {
                    this.Lbl_Title.Text = "修改周报";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "暂 存";
                ShowInfoByDateTime(this.Tbx_STime.Text);
            }
            else
            {
                this.Tbx_NID.Text = base.GetMainID();
                this.Lbl_Title.Text = "新增周报";

                //this.CommentList2.CommentFID = this.Tbx_NID.Text;
                //this.CommentList2.CommentType = "TotayReport";
                ShowInfoByDateTime(this.Tbx_STime.Text);
                AddUpload.Visible = false;
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
            //this.CommentList2.CommentFID = this.Tbx_NID.Text;
            //this.CommentList2.CommentType = "TotayReport";
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

            this.Lbl_Details.Text += "<Table width=\"100%\" class=\"small\" >";
            this.Lbl_Details.Text += "<tr>";
            for (int i = 1; i <= 7; i++)
            {
                this.Lbl_Details.Text += "<td width=\"15%\"  class=\"colHeader\">";
                this.Lbl_Details.Text += "<b>" + D_Time.AddDays(i - weekDay).Day + "日 - " + base.Get_Chinese_Week(D_Time.AddDays(i - weekDay)) + "</b>";
                this.Lbl_Details.Text += "</td>";
            }

            this.Lbl_Details.Text += "</tr>";
            this.Lbl_Details.Text += "<tr>";

            for (int i = 1; i <= 7; i++)
            {
                this.Lbl_Details.Text += "<td width=\"15%\"  align=\"center\" >";
                this.Lbl_Details.Text += "<font color=\"gray\">日报总结和计划</font>";
                this.Lbl_Details.Text += "</td>";
            }

            this.Lbl_Details.Text += "</tr>";

            this.Lbl_Details.Text += "<tr>";
            for (int i = 1; i <= 7; i++)
            {
                this.Lbl_Details.Text += "<td width=\"15%\"  align=\"left\" >";
                this.Lbl_Details.Text += GetDetails(D_Time.AddDays(i - weekDay));
                this.Lbl_Details.Text += "</td>";
            }
            this.Lbl_Details.Text += "</tr>";
            this.Lbl_Details.Text += "</Table>";
        }
    }

    private void ShowDetails(int i_State)
    {
        if (i_State == 1)
        {
            this.Tbx_ThisReport.Enabled = false;
            this.Tbx_NextReport.Enabled = false;
            this.Btn_Save.Text = "已提交";
            this.Button1.Enabled = true;
            this.Btn_Save.Enabled = true;

        }
        if (i_State==2)
        {
            this.Tbx_ThisReport.Enabled = false;
            this.Tbx_NextReport.Enabled = false;
            this.Btn_Save.Text = "已提交";
            this.Button1.Enabled = false;
            this.Btn_Save.Enabled = false;
        }
        if(i_State==3)
        {
            this.Tbx_ThisReport.Enabled = true;
            this.Tbx_NextReport.Enabled = true;
            this.Btn_Save.Text = "提交";
            this.Button1.Enabled = false;
            this.Btn_Save.Enabled = false;
        }
        if (i_State==4)
        {
            this.Tbx_ThisReport.Enabled = false;
            this.Tbx_NextReport.Enabled = false;
            this.Btn_Save.Text = "提交";
            this.Button1.Enabled = true;
            this.Btn_Save.Enabled = true;
        }
        if (i_State == 0)
        {
            this.Tbx_ThisReport.Enabled = true;
            this.Tbx_NextReport.Enabled = true;
            this.Btn_Save.Text = "提交";
            this.Button1.Enabled = false;
            this.Btn_Save.Enabled = false;
        }
    }

    private void ShowInfoByDateTime(string s_DataTime)
    {
        DateTime D_Time = DateTime.Parse(s_DataTime);
        int weekDay = (short)D_Time.DayOfWeek;
        if (weekDay == 0)
        {
            weekDay = 7;
        }
        int i_State = 0;
        KNet.BLL.PB_Basic_Attachment bllComment = new KNet.BLL.PB_Basic_Attachment();
        string SqlWhere = "";
        AdminloginMess AM = new AdminloginMess();



        KNet.BLL.OA_Person_Report bll = new KNet.BLL.OA_Person_Report();
        DataSet Dts_Table = bll.GetList(" OPR_Stime>='" + D_Time.AddDays(1 - weekDay) + "' and OPR_Stime<='" + D_Time.AddDays(7 - weekDay) + "'  and OPR_Type='2' and  OPR_DutyPerson='" + this.Ddl_DutyPerson.SelectedValue + "' ");
        if (Dts_Table.Tables[0].Rows.Count > 0)
        {
            this.Tbx_ID.Text = Dts_Table.Tables[0].Rows[0]["OPR_ID"].ToString();
            this.Tbx_NID.Text = Dts_Table.Tables[0].Rows[0]["OPR_ID"].ToString();
            //this.CommentList2.CommentFID = Dts_Table.Tables[0].Rows[0]["OPR_ID"].ToString();
            //this.CommentList2.CommentType = "TotayReport";
            this.Tbx_STime.Text = DateTime.Parse(Dts_Table.Tables[0].Rows[0]["OPR_STime"].ToString()).ToShortDateString();
            this.Tbx_Type.Text = Dts_Table.Tables[0].Rows[0]["OPR_Type"].ToString();
            i_State = int.Parse(Dts_Table.Tables[0].Rows[0]["OPR_State"].ToString());

            SqlWhere = " PBA_FID='" + this.Tbx_ID.Text + "' AND PBA_Type='WeekFile' and PBA_Creator='" + AM.KNet_StaffNo + "' order by PBA_CTime desc";
            DataSet ds_Comment = bllComment.GetList(SqlWhere);
            GridView_Comment.DataSource = ds_Comment.Tables[0];
            GridView_Comment.DataBind();

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
                    //Sb_Project.Append("<input type=\"text\" name=\"Tbx_Project_" + i.ToString() + "\" id=\"Tbx_Project_" + i.ToString() + "\"  style=\"width: 70%;height:70px\" value=\"" + s_Project + "\" />\n");

                    Sb_Project.Append("<textarea name=\"Tbx_Project_" + i.ToString() + "\" id=\"Tbx_Project_" + i.ToString() + "\"   rows=\"5\" style=\"width: 70%;height:70px\" warp=\"virtual\">" + s_Project + "</textarea>\n");
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
                            //Sb_Project.Append("<input type=\"text\" name=\"Tbx_ProjectDetails_" + s_DNum + "\" id=\"Tbx_ProjectDetails_" + s_DNum + "\"  style=\"width: 70%;height:70px\" value=\"" + s_ProjectDetails + "\" />\n");


                            Sb_Project.Append("<textarea name=\"Tbx_ProjectDetails_" + s_DNum + "\" id=\"Tbx_ProjectDetails_" + s_DNum + "\"   rows=\"5\" style=\"width: 70%;height:70px\" warp=\"virtual\">" + s_ProjectDetails + "</textarea>\n");

                            Sb_Project.Append("</td>\n");
                            Sb_Project.Append("<td class=\"ListHeadDetails\" width=\"24%\">\n");
                            Sb_Project.Append("<input type=\"text\" name=\"Tbx_Person_" + s_DNum + "\"  readonly=\"readonly\" id=\"Tbx_Person_" + s_DNum + "\"  style=\"width: 80%\"  value=\"" + s_Person + "\" />\n");
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
                this.Lbl_ThisProject.Text = Sb_Project.ToString();//本周总结
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
                    //Sb_Project.Append("<input type=\"text\" name=\"Tbx_Project1_" + i.ToString() + "\" id=\"Tbx_Project1_" + i.ToString() + "\"  style=\"width: 70%;height:70px\" value=\"" + s_Project + "\" />\n");

                    Sb_Project.Append("<textarea name=\"Tbx_Project1_" + i.ToString() + "\" id=\"Tbx_Project1_" + i.ToString() + "\"   rows=\"5\" style=\"width: 70%;height:70px\" warp=\"virtual\">" + s_Project + "</textarea>\n");
                    //<textarea name="Tbx_Project1_0" id="Tbx_Project1_0" runat="server"  rows="5" style="width: 70%" warp="virtual">1.1</textarea>
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
                            //Sb_Project.Append("<input type=\"text\" name=\"Tbx_ProjectDetails1_" + s_DNum + "\" id=\"Tbx_ProjectDetails1_" + s_DNum + "\"  style=\"width: 70%;height:70px\" value=\"" + s_ProjectDetails + "\" />\n");
                            Sb_Project.Append("<textarea name=\"Tbx_ProjectDetails1_" + s_DNum + "\" id=\"Tbx_ProjectDetails1_" + s_DNum + "\"   rows=\"5\" style=\"width: 70%;height:70px\" warp=\"virtual\">" + s_ProjectDetails + "</textarea>\n");
                            Sb_Project.Append("</td>\n");
                            Sb_Project.Append("<td class=\"ListHeadDetails\" width=\"24%\">\n");
                            Sb_Project.Append("<input type=\"text\" name=\"Tbx_Person1_" + s_DNum + "\" readonly=\"readonly\" id=\"Tbx_Person1_" + s_DNum + "\"  style=\"width: 80%\"  value=\"" + s_Person + "\" />\n");
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
                this.Lbl_NextProject.Text = Sb_Project.ToString();//下周计划
            }
            this.Tbx_ThisReport.Text = KNetPage.KHtmlDiscode(Dts_Table.Tables[0].Rows[0]["OPR_ThisReport"].ToString());
            this.Tbx_NextReport.Text = KNetPage.KHtmlDiscode(Dts_Table.Tables[0].Rows[0]["OPR_NextReport"].ToString());
        }
        else
        {
            this.Tbx_ID.Text = "";

            this.Tbx_NID.Text = base.GetMainID();
            
            this.Tbx_TNum.Text = "1";
            this.Tbx_DNum.Text = "1";

            this.Tbx_TNum1.Text = "1";
            this.Tbx_DNum1.Text = "1";
            //this.Tbx_ProjectDetails_0.Value = "1.1";
            //this.Tbx_ProjectDetails1_0.Value = "1.1";
            this.Lbl_ThisProject.Visible = false;
            this.Lbl_NextProject.Visible = false;
            this.Tr_NextReport.Visible = true;
            this.Tr_ThisReport.Visible = true;
            //this.CommentList2.CommentFID = this.Tbx_NID.Text;
            //this.CommentList2.CommentType = "TotayReport";
            Tbx_Project_0.Value = "1.";
            this.Tbx_ProjectDetails_0.Value = "1.";
            Tbx_Person_0.Value = AM.KNet_StaffName;
            this.Tbx_Time_0.Value = "";

            Tbx_Project1_0.Value = "1.";
            this.Tbx_ProjectDetails1_0.Value = "1.";
            Tbx_Person1_0.Value = AM.KNet_StaffName;
            this.Tbx_Time1_0.Value = "";
           
            this.Tbx_ThisReport.Text = "";
            this.Tbx_NextReport.Text = "";
            this.Tbx_Type.Text = "2";
            SqlWhere = "1!=1";
            DataSet ds_Comment = bllComment.GetList(SqlWhere);
            GridView_Comment.DataSource = ds_Comment.Tables[0];
            GridView_Comment.DataBind();
        }
        if (Dts_Table.Tables[0].Rows.Count > 0)
        {
            if ((DateTime.Now - DateTime.Parse(Dts_Table.Tables[0].Rows[0]["OPR_CTime"].ToString())).TotalHours < 1)
            {
                ShowDetails(1);//当提交大于24小时，不可以编辑今日计划OPR_SubmitTime
            }
            //else if ((DateTime.Now.Day - DateTime.Parse(Dts_Table.Tables[0].Rows[0]["OPR_SubmitTime"].ToString()).Day)<=6)
            //{
            //    ShowDetails(2);//当提交大于24小时，不可以编辑今日计划
            //}
            // if ((DateTime.Now - DateTime.Parse(Dts_Table.Tables[0].Rows[0]["OPR_CTime"].ToString())).TotalHours < 1)
            else
            {
                ShowDetails(3);//小于24小时，可编辑今日计划
            }
        }
        else
        {
            if (DateTime.Now.Date == DateTime.Parse(s_DataTime).Date)
            {
                ShowDetails(4);//不是同一天
            }
            else
            {
                ShowDetails(0);
            }

        }
        //ShowDetails(i_State);
        DateTime Dtm_Time = DateTime.Parse(s_DataTime).AddDays(-1);
        //if (weekDay==7)
        //{
        //    weekDay = 0;
        //}
        DataSet Dts_Table1 = bll.GetList("  OPR_Stime>='" + Dtm_Time.AddDays(-7).AddDays(1 - weekDay+1) + "' and OPR_Stime<='" + Dtm_Time.AddDays(-7).AddDays(7 - weekDay+1) + "' and  OPR_Type='2'  and OPR_State='1' and  OPR_DutyPerson='" + this.Ddl_DutyPerson.SelectedValue + "'");
        if (Dts_Table1.Tables[0].Rows.Count > 0)
        {
            this.Lbl_ThisReport.Text = KNetPage.KHtmlDiscode(Dts_Table1.Tables[0].Rows[0]["OPR_NextReport"].ToString());
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
                    //Sb_Project.Append("<td class=\"ListHeadDetails\" width=\"25%\" nowrap>" + s_Project + "\n");
                    //Sb_Project.Append("</td>\n");
                    Sb_Project.Append("<td class=\"ListHeadDetails\" width=\"25%\" nowrap><textarea  rows=\"5\" style=\"width: 70%;height:70px\" readonly=\"readonly\" warp=\"virtual\">" + s_Project + "</textarea>\n");
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
                            //Sb_Project.Append("<td class=\"ListHeadDetails\" width=\"24%\">" + s_ProjectDetails + "\n</td>");
                            Sb_Project.Append("<td class=\"ListHeadDetails\" width=\"24%\"><textarea  rows=\"5\" style=\"width: 70%;height:70px\" readonly=\"readonly\" warp=\"virtual\">" + s_ProjectDetails + "</textarea>\n</td>");
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
                this.Lbl_ThisReport.Text = Sb_Project.ToString();//上周拟定
            }
        }
        else
        {
            this.Lbl_ThisReport.Text = "";
        }


        this.Lbl_Details.Text = "";
        this.Lbl_Details.Text += "<Table width=\"100%\" class=\"small\" >";
        this.Lbl_Details.Text += "<tr>";
        for (int i = 1; i <= 7; i++)
        {
            this.Lbl_Details.Text += "<td width=\"15%\"  class=\"colHeader\">";
            this.Lbl_Details.Text += "<b>" + D_Time.AddDays(i - weekDay).Day + "日 - " + base.Get_Chinese_Week(D_Time.AddDays(i - weekDay)) + "</b>";
            this.Lbl_Details.Text += "</td>";
        }

        this.Lbl_Details.Text += "</tr>";
        this.Lbl_Details.Text += "<tr>";

        for (int i = 1; i <= 7; i++)
        {
            this.Lbl_Details.Text += "<td width=\"15%\"  align=\"center\" >";
            this.Lbl_Details.Text += "<font color=\"gray\">日报总结和计划</font>";
            this.Lbl_Details.Text += "</td>";
        }

        this.Lbl_Details.Text += "</tr>";

        this.Lbl_Details.Text += "<tr>";
        for (int i = 1; i <= 7; i++)
        {
            this.Lbl_Details.Text += "<td width=\"15%\"  align=\"left\" valign=\"top\" height=\"70px\" class=\"dvtCellInfo\" >";
            this.Lbl_Details.Text += GetDetails(D_Time.AddDays(i - weekDay));
            this.Lbl_Details.Text += "</td>";
        }
        this.Lbl_Details.Text += "</tr>";
        this.Lbl_Details.Text += "</Table>";
    }
    public string GetDetails(DateTime D_Time)
    {
        string s_return = "";
        try
        {

            KNet.BLL.OA_Person_Report bll = new KNet.BLL.OA_Person_Report();
            DataSet Dts_Table = bll.GetList("  OPR_Stime='" + D_Time.ToShortDateString() + "' and  OPR_Type='1' and  OPR_DutyPerson='" + this.Ddl_DutyPerson.SelectedValue + "' ");
            if (Dts_Table.Tables[0].Rows.Count > 0)
            {
                if (Dts_Table.Tables[0].Rows[0]["OPR_NextReport"].ToString() != "")
                {
                    s_return += "<br/><font color=\"blue\">当日计划:</font><br>" + Dts_Table.Tables[0].Rows[0]["OPR_NextReport"].ToString() + "<br>";
                }
                if (Dts_Table.Tables[0].Rows[0]["OPR_ThisReport"].ToString() != "")
                {
                    s_return += "<font color=\"blue\">当日总结:</font><br>" + Dts_Table.Tables[0].Rows[0]["OPR_ThisReport"].ToString() + "<br>";
                }
                KNet.BLL.PB_Basic_Comment bllComment = new KNet.BLL.PB_Basic_Comment();
                string SqlWhere1 = "";
                SqlWhere1 = " PBC_FID='" + Dts_Table.Tables[0].Rows[0]["OPR_ID"].ToString() + "' AND PBC_Type=24 order by PBC_CTime ";
                DataSet ds_Comment1 = bllComment.GetList(SqlWhere1);
                s_return += "<font color=\"red\">领导点评:</font><br>";
                string s_re = "";
                for (int i = 0; i < ds_Comment1.Tables[0].Rows.Count; i++)
                {
                    s_re += "<font>点评人:</font>"+ Base_GetUserName(ds_Comment1.Tables[0].Rows[i]["PBC_FromPerson"].ToString()) + "--<font color=\"red\">" + ds_Comment1.Tables[0].Rows[i]["PBC_Description"].ToString() +
                            "</font><br>";
                }
                s_return += s_re;
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
            model.OPR_Type = 2;
            model.OPR_State = 1;
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
                string Tbx_Person1 = Request["Tbx_Person1_" + i.ToString() + ""] == null ? "" : Request["Tbx_Person1_" + i.ToString() + ""].ToString();
               
                   
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
                        if (s_Time == "")
                        {
                            Model.OPRD_Time = DateTime.Now.ToString();
                        }
                        else
                        {
                            Model.OPRD_Time = s_Time;
                        }

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
                        if (s_Time == "")
                        {
                            Model.OPRD_Time = DateTime.Now.ToString();
                        }
                        else
                        {
                            Model.OPRD_Time = s_Time;
                        }
                        //Model.OPRD_Time = s_Time;
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
            DataSet Dts_Table = bll.GetList(" OPR_ID='" + this.Tbx_ID.Text + "'  and OPR_Type='2' and  OPR_DutyPerson='" + this.Ddl_DutyPerson.SelectedValue + "' ");
            if ((DateTime.Now - DateTime.Parse(Dts_Table.Tables[0].Rows[0]["OPR_CTime"].ToString())).TotalHours > 1)
            {
                Alert("已经超过时限不可再次编辑");
                return;
            }
            else
            {
                try
                {
                    if (bll.Update(model))
                    {
                        AM.Add_Logs("周报修改" + this.Tbx_ID.Text);
                        //base.Base_SendMessage(model.PBM_ID, "周报：<a href='Web/Notice/OA_Person_Report_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PBM_ID + "</a> ");
                        AlertAndRedirect("修改成功！", "OA_Person_Report_Week_Add.aspx?ID=" + this.Tbx_ID.Text + "");
                    }
                    else
                    {
                        AM.Add_Logs("周报修改失败" + this.Tbx_ID.Text);
                        AlertAndRedirect("修改失败！", "OA_Person_Report_Week_Add.aspx?ID=" + this.Tbx_ID.Text + "");
                    }
                }
                catch (Exception ex)
                {
                    Alert("周报修改失败");
                    return;
                }
            }
          
        }
        else
        {

            try
            {
                bll.Add(model);
                //base.Base_SendMessage(model.PBN_ReceiveID, "周报：<a href='Web/Notice/OA_Person_Report_View.aspx?ID=" + model.PBN_ID + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PBN_Title + "</a> ");
                AM.Add_Logs("周报增加");
                AlertAndRedirect("新增成功！", "OA_Person_Report_Week_Add.aspx?ID=" + this.Tbx_ID.Text + "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //KNet.Model.OA_Person_Report model = new KNet.Model.OA_Person_Report();
        //KNet.BLL.OA_Person_Report bll = new KNet.BLL.OA_Person_Report();
        //AdminloginMess AM = new AdminloginMess();

        //if (this.SetValue(model) == false)
        //{
        //    Alert("系统错误！");
        //    return;
        //}

        //try
        //{
        //    model.OPR_State = 1;
        //    if (bll.Update(model))
        //    {
        //        AM.Add_Logs("周报提交" + this.Tbx_ID.Text);
        //        //base.Base_SendMessage(model.PBM_ID, "周报：<a href='Web/Notice/OA_Person_Report_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PBM_ID + "</a> ");
        //        AlertAndRedirect("周报提交成功！", "OA_Person_Report_Week_Add.aspx?ID=" + this.Tbx_ID.Text + "");
        //    }
        //    else
        //    {
        //        AM.Add_Logs("周报修改失败" + this.Tbx_ID.Text);
        //        AlertAndRedirect("修改失败！", "OA_Person_Report_Week_Add.aspx?ID=" + this.Tbx_ID.Text + "");
        //    }
        //}
        //catch { }
        Response.Write("<script language=javascript>location.href='/inc/NewDesk.aspx'</script>");
    }
    protected void Lbl_Pre_Click(object sender, EventArgs e)
    {
        this.Lbl_Details.Text = "";
        AdminloginMess AM = new AdminloginMess();
        this.Tbx_STime.Text = DateTime.Parse(this.Tbx_STime.Text).AddDays(-7).ToShortDateString();
        DateTime date = DateTime.Parse(this.Tbx_STime.Text);
        int weekDay = (short)date.DayOfWeek;
        if (weekDay == 0)
        {
            weekDay = 7;
        }
        this.Lbl_Days.Text = "<font size='5'>" + date.AddDays(1 - weekDay).ToShortDateString() + "  (" + base.Get_Chinese_Week(date.AddDays(1 - weekDay)) + ")  ~" + date.AddDays(7 - weekDay).ToShortDateString() + "  (" + base.Get_Chinese_Week(date.AddDays(7 - weekDay)) + ")  " + AM.KNet_StaffName + "</font>";
        this.ShowInfoByDateTime(this.Tbx_STime.Text);
    }
    protected void Lbl_Next_Click(object sender, EventArgs e)
    {
        this.Lbl_Details.Text = "";
        AdminloginMess AM = new AdminloginMess();
        this.Tbx_STime.Text = DateTime.Parse(this.Tbx_STime.Text).AddDays(7).ToShortDateString();
        DateTime date = DateTime.Parse(this.Tbx_STime.Text);
        int weekDay = (short)date.DayOfWeek;
        if (weekDay==0)
        {
            weekDay = 7;
        }
        this.Lbl_Days.Text = "<font size='5'>" + date.AddDays(1 - weekDay).ToShortDateString() + "  (" + base.Get_Chinese_Week(date.AddDays(1 - weekDay)) + ")  ~" + date.AddDays(7 - weekDay).ToShortDateString() + "  (" + base.Get_Chinese_Week(date.AddDays(7 - weekDay)) + ")  " + AM.KNet_StaffName + "</font>";
        this.ShowInfoByDateTime(this.Tbx_STime.Text);
    }
    public string GetUserName(string FromPerson)
    {
        BasePage page = new BasePage();
        return page.Base_GetUserName(FromPerson);
    }
    /// <summary>
    /// 新增附件按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Btn_Create_OnClick(object sender, EventArgs e)
    {
        this.AddUpload.Visible = true;
    }
    /// <summary>
    /// 提交附件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_OnClick(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.Model.PB_Basic_Attachment model = new KNet.Model.PB_Basic_Attachment();
        string FileType = FileUpload1.PostedFile.ContentType.ToString(); //文件类型
        GetThumbnailImage1(model);
        try
        {
            KNet.BLL.PB_Basic_Attachment BLL = new KNet.BLL.PB_Basic_Attachment();
            BLL.Add(model);
            AM.Add_Logs("附件上传成功：编号：" + model.PBA_ID);
            AddUpload.Visible = false;
            KNet.BLL.PB_Basic_Attachment bllComment = new KNet.BLL.PB_Basic_Attachment();
            string SqlWhere = " PBA_FID='" + Tbx_NID.Text + "' AND PBA_Type='WeekFile' and PBA_Creator='" + AM.KNet_StaffNo + "' order by PBA_CTime desc";
            DataSet ds_Comment = bllComment.GetList(SqlWhere);
            GridView_Comment.DataSource = ds_Comment.Tables[0];
            GridView_Comment.DataBind();
            //ShowInfoByDateTime(this.Tbx_STime.Text);
            //Tbx_Remarks.Text = "2";
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    /// <summary>
    /// 取消
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button3_OnClick(object sender, EventArgs e)
    {
        this.AddUpload.Visible = false;
    }
    #region 资料上传操作
    /// <summary>
    /// 图片上传
    /// </summary>
    protected void GetThumbnailImage1(KNet.Model.PB_Basic_Attachment model)
    {
        AdminloginMess AM = new AdminloginMess();
        //类别下面的
        string UploadPath = "/UpFile/" + Tbx_NID.Text + "/WeekFile/";  //上传路径
        string AutoPath = System.DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "").Replace("/", "");
        //string fileExt = Path.GetExtension(uploadFile1.PostedFile.FileName); //获扩展名
        string FileType = FileUpload1.PostedFile.ContentType.ToString(); //文件类型
        string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
        string filePath = UploadPath + AutoPath + "_" + FileName; //大文件名
        if (!Directory.Exists(Server.MapPath(UploadPath)))
        {
            Directory.CreateDirectory(Server.MapPath(UploadPath));
        }
        FileUpload1.PostedFile.SaveAs(Server.MapPath(filePath)); //上传

        model.PBA_FID = Tbx_NID.Text;
        model.PBA_Type = "WeekFile";
        model.PBA_ID = GetMainID();
        model.PBA_Name = this.Tbx_Name.Text;
        model.PBA_URL = filePath;
        model.PBA_CTime = DateTime.Now;
        model.PBA_EndTime = DateTime.Now;
        model.PBA_Creator = AM.KNet_StaffNo;
        model.PBA_Remarks = this.Tbx_Remarks.Text;
    }
    #endregion
    public string GetCodeID()
    {
        string s_ID = "F";
        try
        {
            string s_Date = DateTime.Now.ToString("yyMMddhhmmss");
            Random rand = new Random();
            int RandKey = int.Parse(rand.Next(1000000, 9999999).ToString().Substring(4, 3));
            s_ID += s_Date + RandKey.ToString();
        }
        catch
        { }
        return s_ID;
    }
}
