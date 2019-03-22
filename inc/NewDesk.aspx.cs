using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Json;
using KNet.DBUtility;
using KNet.Common;
using System.Drawing;
using System.Net;
using System.Net.Mail;

public partial class NewDesk : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.YNAuthority("应收款列表"))
            {
                this.Lbl_ShowDetails.Text += ShowDetails("1", "Receive", "应收款、应付款客户汇总");
            }
            this.Lbl_ShowDetails.Text += ShowDetails("1", "Notice", "公告");
            this.Lbl_ShowDetails.Text += ShowDetails("1", "CustomerView", "关键视图");
            stuff_Receive.Visible = false;
            stuff_Account.Visible = false;
            if (AM.YNAuthority("采购单列表"))
            {
            }
            else
            {
            }
            if (AM.YNAuthority("销售机会列表"))
            {
                weekreport.Visible = true;
                bindWeekTotal();
            }
            else
            {
                weekreport.Visible = false;
                
            }
            if (AM.YNAuthority("采购单列表"))
            {
                CgMonth.Visible = true;
                bindCgMonth();
            }
            else
            {
                CgMonth.Visible = false;
            }
            if (AM.YNAuthority("应收款计划列表"))
            {

                stuff_Receive.Visible = true;
                string s_StartDate = "";
                string s_EndDate = DateTime.Now.ToShortDateString();
                if (s_StartDate == "")
                {
                    s_StartDate = "1900-1-1";
                }
                StringBuilder Sb_Str = new StringBuilder();
                Sb_Str.Append("<table width=\"100%\">");
                Sb_Str.Append("<tr>");
                Sb_Str.Append("<td class=\"settingsTabHeader\" align=\"center\">业务员</td>");
                Sb_Str.Append("<td class=\"settingsTabHeader\" align=\"center\">应收款金额</td>");
                Sb_Str.Append("<td class=\"settingsTabHeader\" align=\"center\">超期金额</td>");
                Sb_Str.Append("</tr>");
                string s_Sql = "select b.KSC_DutyPerson,Sum(case when STime<'" + s_StartDate + "' then Money else 0 end) QCMoney,";
                s_Sql += "Sum(case when STime>='" + s_StartDate + "'  and  STime<='" + s_EndDate + "' and  CType in(0,2) then Money else 0 end) BqYsMoney, ";
                s_Sql += "Sum(case when STime>='" + s_StartDate + "'  and  STime<='" + s_EndDate + "' and CType=1 then -Money else 0 end) BqSkMoney,";
                s_Sql += "Sum(case when STime<='" + s_EndDate + "' then Money else 0 end) QMMoney,";
                s_Sql += "Sum(Case when CType<>0 then Money+isnull(d.CQMoney,0) else isnull(d.CQMoney,0) end) DqMoney,Sum(Case when CType=0 then d.WCQMoney else 0 end) as wDqMoney, ";
                s_Sql += "Sum(case when  CType in(0) then d.FPTotalMoney else 0 end) BQKPMoney,Sum(case when CType=2 then Money else 0 end) CSHMoney,";
                s_Sql += "Sum(case when  CType in(0) then d.FPleftMoney else 0 end) WKPMoney,";
                s_Sql += "Sum(Case when CType<>0  then Money+isnull(d.Dq30Money,0) else isnull(d.Dq30Money,0) end ) Dq30Money, ";
                s_Sql += "Sum(Case when CType<>0  then Money+isnull(d.Dq60Money,0) else isnull(d.Dq60Money,0) end  ) Dq60Money, ";
                s_Sql += "Sum(Case when CType<>0  then Money+isnull(d.Dq90Money,0) else isnull(d.Dq90Money,0) end  ) Dq90Money, ";
                s_Sql += "Sum(Case when CType<>0  then Money+isnull(d.Dq90MoreMoney,0) else isnull(d.Dq90MoreMoney,0) end ) Dq90MoreMoney ";
                s_Sql += " from v_Receive_Real a join KNET_Sales_ClientList b on a.CustomerValue=b.CustomerValue ";
                s_Sql += " join v_DirectOut_FPMoneyDetails d on d.ID=a.ID";
                s_Sql += " where 1=1 ";

                //仅查看自己
                if (AM.YNAuthority("收款单仅责任人查看") == true)
                {
                    if (AM.KNet_StaffName != "薛建新")
                    {
                        s_Sql += " and b.KSC_DutyPerson='" + AM.KNet_StaffNo + "'  ";
                    }
                }
                s_Sql += "group by b.KSC_DutyPerson ";
                s_Sql += " having  Sum(case when STime<='" + s_EndDate + "' then Money else 0 end)<>0 and Sum(Case when CType<>0 then Money+isnull(d.CQMoney,0) else isnull(d.CQMoney,0) end)<>0 ";
                s_Sql += " order by b.KSC_DutyPerson ";

                this.BeginQuery(s_Sql);
                DataTable Dtb_Table = (DataTable)this.QueryForDataTable();
                decimal d_TotalMoney = 0, d_TotalMoney1 = 0;
                if (Dtb_Table.Rows.Count > 0)
                {
                    for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                    {

                        Sb_Str.Append("<tr>");
                        Sb_Str.Append("<td class=\"settingsTabHeader\" align=\"center\">" + base.Base_GetUserName(Dtb_Table.Rows[i]["KSC_DutyPerson"].ToString()) + "</td>");
                        Sb_Str.Append("<td class=\"settingsTabList\" align=\"center\">" + FormatNumber1(Dtb_Table.Rows[i]["QMMoney"].ToString(), 2) + "</td>");
                        Sb_Str.Append("<td class=\"settingsTabList\" align=\"center\"><a href=\"/web/Xs/Customer/KNet_Sales_ClientList_Manger_Receive.aspx?DutyPerson=" + Dtb_Table.Rows[i]["KSC_DutyPerson"].ToString() + "\" target=\"_blank\">" + FormatNumber1(Dtb_Table.Rows[i]["DqMoney"].ToString(), 2) + "</a></td>");
                        Sb_Str.Append("</tr>");
                        d_TotalMoney += decimal.Parse(FormatNumber1(Dtb_Table.Rows[i]["QMMoney"].ToString(), 2));
                        d_TotalMoney1 += decimal.Parse(FormatNumber1(Dtb_Table.Rows[i]["DqMoney"].ToString(), 2));
                    }
                }

                Sb_Str.Append("<tr>");
                Sb_Str.Append("<td class=\"settingsTabHeader\" align=\"left\">合计</td>");
                Sb_Str.Append("<td class=\"settingsTabHeader\"  align=\"center\">" + base.FormatNumber(d_TotalMoney.ToString(), 2) + "</td>");
                Sb_Str.Append("<td class=\"settingsTabHeader\"  align=\"center\">" + base.FormatNumber(d_TotalMoney1.ToString(), 2) + "</td>");
                Sb_Str.Append("</tr>");
                Sb_Str.Append("</table>");

                this.Lbl_Receive.Text = Sb_Str.ToString();

            }
            if ((AM.YNAuthority("收款单列表")) && (AM.YNAuthority("付款单列表")))
            {
                stuff_Account.Visible = true;
                this.Lbl_Account.Text += "<table width=\"100%\">";
                this.Lbl_Account.Text += "<tr>";
                this.Lbl_Account.Text += "<td class=\"settingsTabHeader\" align=\"center\">账号</td>";
                this.Lbl_Account.Text += "<td class=\"settingsTabHeader\" align=\"center\">余额</td>";
                this.Lbl_Account.Text += "</tr>";

                //
                DateTime datetime = DateTime.Now;
                string s_StartDate = datetime.AddDays(1 - datetime.Day).ToShortDateString();
                string s_EndDate = datetime.ToShortDateString();
                decimal d_TotalMoney = 0;
                this.BeginQuery("Select * from KNet_Sys_Bank where ID not in('M151127021803388','M151127021904259','M160329043540344')");
                DataTable Dtb_Table = (DataTable)this.QueryForDataTable();
                if (Dtb_Table != null)
                {
                    for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                    {
                        this.Lbl_Account.Text += "<tr>";
                        this.Lbl_Account.Text += "<td  class=\"settingsTabHeader\" align=\"left\" >" + Dtb_Table.Rows[i]["BankName"].ToString() + "</td>";
                        //
                        if (Dtb_Table.Rows[i]["BankName"].ToString() == "应收票据")
                        {
                            string s_Sql = "select isnull(Sum(Case when Type=2 then -CAA_PayMoney else CAA_PayMoney end ),0) as InitMoney from v_BillDetailsWithoutSum  ";
                            s_Sql += " where 1=1  ";

                            this.BeginQuery(s_Sql);
                            string s_Money = this.QueryForReturn();
                            this.Lbl_Account.Text += "<td class=\"settingsTabList\"  align=\"Right\" ><a href=\"/web/Report_Cw/Bill/List_Bank.aspx?StartDate=" + s_StartDate + "&EndDate=" + s_EndDate + "&CustomerName=&Account=" + Dtb_Table.Rows[i]["BankNo"].ToString() + "&Type=&Type1=\" target=\"_blank\">" + base.FormatNumber(s_Money, 2) + "</a></td>";
                            d_TotalMoney += decimal.Parse(s_Money);
                        }
                        else
                        {
                            if ((Dtb_Table.Rows[i]["BankName"].ToString() == "其他货币资金-银行承兑保证金") || (Dtb_Table.Rows[i]["BankName"].ToString() == "应付票据"))
                            {

                            }
                            else
                            {
                                string s_Sql = "select isnull(Sum(CAA_PayMoney),0) as InitMoney from v_BankPayDetails   ";
                                s_Sql += " where 1=1  and  CAA_Account='" + Dtb_Table.Rows[i]["BankNo"].ToString() + "'";
                                this.BeginQuery(s_Sql);
                                string s_Money = this.QueryForReturn();
                                if (Dtb_Table.Rows[i]["BankName"].ToString() == "现金")
                                {
                                    this.Lbl_Account.Text += "<td class=\"settingsTabList\"  align=\"Right\" ><a href=\"/web/Report_Cw/Money/List_Bank.aspx?StartDate=" + s_StartDate + "&EndDate=" + s_EndDate + "&CustomerName=&Account=" + Dtb_Table.Rows[i]["BankNo"].ToString() + "&Type=&Type1=\" target=\"_blank\">" + base.FormatNumber(s_Money, 2) + "</a></td>";
                                }
                                else
                                {
                                    this.Lbl_Account.Text += "<td class=\"settingsTabList\"  align=\"Right\" ><a href=\"/web/Report_Cw/Bank/List_Bank.aspx?StartDate=" + s_StartDate + "&EndDate=" + s_EndDate + "&CustomerName=&Account=" + Dtb_Table.Rows[i]["BankNo"].ToString() + "&Type=&Type1=\" target=\"_blank\">" + base.FormatNumber(s_Money, 2) + "</a></td>";
                                }
                                d_TotalMoney += decimal.Parse(s_Money);
                            }
                        }
                        this.Lbl_Account.Text += "</tr>";
                    }
                }
                this.Lbl_Account.Text += "<tr>";
                this.Lbl_Account.Text += "<td class=\"settingsTabHeader\" align=\"left\">合计</td>";
                this.Lbl_Account.Text += "<td class=\"settingsTabHeader\"  align=\"Right\">" + base.FormatNumber(d_TotalMoney.ToString(), 2) + "</td>";
                this.Lbl_Account.Text += "</tr>";
                this.Lbl_Account.Text += "</table>";
            }

            this.Lbl_ReportDetails.Text += "<table width=\"100%\">";
            this.Lbl_ReportDetails.Text += "<tr>";
            this.Lbl_ReportDetails.Text += "<td class=\"settingsTabHeader\">日/周/月</td>";
            this.Lbl_ReportDetails.Text += "<td class=\"settingsTabHeader\">日报</td>";
            this.Lbl_ReportDetails.Text += "<td class=\"settingsTabHeader\">周报</td>";
            this.Lbl_ReportDetails.Text += "<td class=\"settingsTabHeader\">月报</td>";
            this.Lbl_ReportDetails.Text += "</tr>";
            this.Lbl_ReportDetails.Text += "<tr>";
            this.Lbl_ReportDetails.Text += "<td  class=\"settingsTabHeader\">写</td>";
            this.Lbl_ReportDetails.Text += "<td class=\"settingsTabList\"><a href=\"../Web/OA/Report/OA_Person_Report_Today_Add.aspx\">写</a></td>";
            this.Lbl_ReportDetails.Text += "<td class=\"settingsTabList\"><a href=\"../Web/OA/Report/OA_Person_Report_Week_Add.aspx\">写</a></td>";
            this.Lbl_ReportDetails.Text += "<td class=\"settingsTabList\"><a href=\"../Web/OA/Report/OA_Person_Report_Month_Add.aspx\">写</a></td>";
            this.Lbl_ReportDetails.Text += "</tr>";
            this.Lbl_ReportDetails.Text += "<tr>";
            this.Lbl_ReportDetails.Text += "<td  class=\"settingsTabHeader\">看下级</td>";
            this.Lbl_ReportDetails.Text += "<td class=\"settingsTabList\"><a href=\"../Web/OA/Report/OA_Person_Report_Today_View.aspx\">查看</a></td>";
            this.Lbl_ReportDetails.Text += "<td class=\"settingsTabList\"><a href=\"../Web/OA/Report/OA_Person_Report_Week_View.aspx\">查看</a></td>";
            this.Lbl_ReportDetails.Text += "<td class=\"settingsTabList\"><a href=\"../Web/OA/Report/OA_Person_Report_Month_View.aspx\">查看</a></td>";
            this.Lbl_ReportDetails.Text += "</tr>";
            this.Lbl_ReportDetails.Text += "<tr>";
            this.Lbl_ReportDetails.Text += "<td  class=\"settingsTabHeader\">报表考勤</td>";
            this.Lbl_ReportDetails.Text += "<td class=\"settingsTabList\"><a href=\"../Web/OA/Report/Report_DayTime_Detail.aspx\" target=\"_blank\">查看</a></td>";
            this.Lbl_ReportDetails.Text += "<td class=\"settingsTabList\"><a href=\"../Web/OA/Report/Report_WeekTime_Detail.aspx\" target=\"_blank\">查看</a></td>";
            this.Lbl_ReportDetails.Text += "<td class=\"settingsTabList\"><a href=\"../Web/OA/Report/Report_Month_View.aspx\" target=\"_blank\">查看</a></td>";
            this.Lbl_ReportDetails.Text += "</tr>";
            //this.Lbl_ReportDetails.Text += "<tr>";
            //this.Lbl_ReportDetails.Text += "<td  class=\"settingsTabHeader\">汇总</td>";
            //this.Lbl_ReportDetails.Text += "<td class=\"settingsTabList\"><a href=\"../Web/OA/Report/TotalReport_Today_View.aspx\">查看</a></td>";
            //this.Lbl_ReportDetails.Text += "<td class=\"settingsTabList\"><a href=\"../Web/OA/Report/TotalReport_Week_View.aspx\">查看</a></td>";
            //this.Lbl_ReportDetails.Text += "<td class=\"settingsTabList\"><a href=\"../Web/OA/Report/TotalReport_Month_View.aspx\">查看</a></td>";
            //this.Lbl_ReportDetails.Text += "</tr>";
            this.Lbl_ReportDetails.Text += "</table>";
            if (AM.KNet_StaffName=="薛建新"|| AM.KNet_StaffName =="李文立")
            {
                this.BeginQuery("Select * From PB_Basic_Attachment where PBA_Del=0 and PBA_ProductsType='15' ");
                this.QueryForDataTable();
                string ProCode_list = "";
                string subject = "环保资料到期警报";

                if (Dtb_Result.Rows.Count > 0)
                {
                    for (int i = 0; i < Dtb_Result.Rows.Count; i++)
                    {
                        DateTime dt1 = DateTime.Now;
                        DateTime dt2 = DateTime.Parse(Dtb_Result.Rows[i]["PBA_EndTime"].ToString());
                        TimeSpan ts = dt2 - dt1;
                        if (int.Parse(ts.Days.ToString()) <= 7)
                        {
                            ProCode_list += Dtb_Result.Rows[i]["PBA_FID"].ToString() + ",";
                        }
                    }
                    if (ProCode_list!="")
                    {
                        string body = "产品编号为" + ProCode_list + "的环保资料即将到期,请在一周内及时更新，并且停用过期资料";
                        string email_list = "zb@systech.com.cn" + "|" + "xb@systech.com.cn" + "|" + "zxc@systech.com.cn" +"|" + "hyy@systech.com.cn" + "|" + "xjx@systech.com.cn" + "|";
                        string File_Path = "";
                        //"zb@systech.com.cn" + "|" + "xb@systech.com.cn" + "|" + "lwl@systech.com.cn" + "|" + "hyy@systech.com.cn" + "|";
                        //Send(subject, body, email_list, File_Path);
                    }
                   
                }
            }
           
            
        }
    }
    #region 环保资料到期，发送邮件
    public static void Send(string subject, string body, string email_list, string File_Path)
    {
        string MailUser = "xjx@systech.com.cn";//我测试的是qq邮箱，其他邮箱一样的道理
        string MailPwd = "systech#88888888";//邮箱密码
        string MailName = "ERP系统";
        string MailHost = "smtp.mxhichina.com";//根据自己选择的邮箱来查询smtp的地址

        MailAddress from = new MailAddress(MailUser, MailName); //邮件的发件人  
        MailMessage mail = new MailMessage();

        //设置邮件的标题  
        mail.Subject = subject;

        //设置邮件的发件人  
        //Pass:如果不想显示自己的邮箱地址，这里可以填符合mail格式的任意名称，真正发mail的用户不在这里设定，这个仅仅只做显示用  
        mail.From = from;

        //设置邮件的收件人  
        string address = "";

        //传入多个邮箱，用“|”分割开，可以自己自定义，再通过mail.To.Add（）添加到列表
        string[] email = email_list.Split('|');
        foreach (string name in email)
        {
            if (name != string.Empty)
            {
                address = name;
                mail.To.Add(new MailAddress(address));
            }
        }

        //设置邮件的抄送收件人  
        //这个就简单多了，如果不想快点下岗重要文件还是CC一份给领导比较好  
        //mail.CC.Add(new MailAddress("Manage@hotmail.com", "尊敬的领导");  

        //设置邮件的内容  
        mail.Body = body;
        //设置邮件的格式  
        mail.BodyEncoding = System.Text.Encoding.UTF8;
        mail.IsBodyHtml = true;
        //设置邮件的发送级别  
        mail.Priority = MailPriority.Normal;

        //设置邮件的附件，将在客户端选择的附件先上传到服务器保存一个，然后加入到mail中  
        if (File_Path != "")
        {
            mail.Attachments.Add(new Attachment(File_Path));
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
        }
        SmtpClient client = new SmtpClient();
        //设置用于 SMTP 事务的主机的名称，填IP地址也可以了  
        client.Host = MailHost;
        //设置用于 SMTP 事务的端口，默认的是 25  
        client.Port = 587;
        client.UseDefaultCredentials = false;
        //这里才是真正的邮箱登陆名和密码， 我的用户名为 MailUser ，我的密码是 MailPwd  
        client.Credentials = new System.Net.NetworkCredential(MailUser, MailPwd);
        client.DeliveryMethod = SmtpDeliveryMethod.Network;

        ////如果发送失败，SMTP 服务器将发送 失败邮件告诉我  
        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

        //都定义完了，正式发送了，很是简单吧！  
        client.Send(mail);

    }
    #endregion
    private string ShowDetails(string s_ID, string s_Name, string s_Title)
    {
        StringBuilder s_Return = new StringBuilder();
        try
        {

            string s_PName = s_Name + s_ID;
            s_Return.Append(" <div id=\"stuff_" + s_PName + "\" class=\"portlet\" style=\"overflow-y: auto; overflow-x: hidden;height=280px; width: 32%; float: left; position: relative;\">\n");
            s_Return.Append("<table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" class=\"small portlet_topper\" style=\"padding-right: 0px; padding-left: 0px; padding-top: 0px;\">\n");
            s_Return.Append("<tr id=\"" + s_PName + "\">\n");
            s_Return.Append("<td align=\"left\" style=\"height: 20px;\" nowrap width=\"60%\">\n");
            s_Return.Append("<b>&nbsp;" + s_Title + "</b>\n");
            s_Return.Append("</td>\n");
            s_Return.Append("<td align=\"right\" style=\"height: 20px;\" width=\"5%\">\n");
            s_Return.Append("<span id=\"refresh_" + s_PName + "\" style=\"position: relative;\">&nbsp;&nbsp;</span>\n");
            s_Return.Append("</td>\n");
            s_Return.Append("<td align=\"right\" style=\"height: 20px;\" nowrap width=\"35%\">\n");
            s_Return.Append("<a style='cursor: pointer;' onclick=\"loadStuff(" + s_ID + ",'" + s_Name + "');\">\n");
            s_Return.Append("<img src=\"../themes/softed/images/windowRefresh.gif\" border=\"0\" alt=\"刷新\" title=\"刷新\" hspace=\"2\" align=\"absmiddle\" /></a>\n");
            s_Return.Append("<input type=\"hidden\" id=\"portlet_stuffid_" + s_PName + "\" value=\"1\"/>\n");
            s_Return.Append("<input type=\"hidden\" id=\"portlet_stufftype_" + s_PName + "\" value=\"" + s_Name + "\"/>\n");
            s_Return.Append("<input type=\"hidden\" id=\"portlet_stufftype_value\" value=\"" + s_PName + "\" class=\"portlet_stufftype_value\"/>\n");
            s_Return.Append("</td>\n");
            s_Return.Append("</tr>\n");
            s_Return.Append("</table>\n");
            s_Return.Append("<table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" class=\"small portlet_content\" style=\"padding-right: 0px; padding-left: 0px; padding-top: 0px;\">\n");
            s_Return.Append("<tr id=\"maincont_row_" + s_PName + "\">\n");
            s_Return.Append("<td>\n");
            s_Return.Append(" <div id=\"stuffcont_" + s_PName + "\" style=\"overflow-y: auto; overflow-x: hidden; width: 100%;height: 100%; cursor: auto;\">\n");
            //s_Return.Append( ReturnDetails(s_Name);
            s_Return.Append("</div>\n");
            s_Return.Append("</td>\n");
            s_Return.Append("</tr>\n");
            s_Return.Append("</table>\n");
            s_Return.Append("</div>\n");
            s_Return.Append("<script language=\"javascript\">\n");
            s_Return.Append("window.onresize = function () { positionDivInAccord('stuff_" + s_PName + "', '32%'); };\n");
            s_Return.Append("positionDivInAccord('stuff_" + s_PName + "', '32%');\n");
            s_Return.Append("</script>\n");
            s_Return.Append("<script>\n");
            s_Return.Append("loadStuff(1, '" + s_Name + "');\n");
            s_Return.Append("</script>\n");
        }
        catch
        { }
        return s_Return.ToString();
    }

    public void bindWeekTotal()
    {
        try
        {
            string s_TotalStyle = "height=\"50px\" width=\"12%\"  style=\"font-size:16px;color:#666666;font-weight:400;\"";
            string s_DetailsStyle = "height=\"100px\" style=\"font-size:30px;color:#333333;font-weight:300;font-family:Arial;\"";
            string s_BotStyle = "height=\"50px\" align=\"center\" style=\"font-size:12px;color:#666;font-weight:400;\"";

            string s_Return = "";
            s_Return += "<table  width=\"90%\" height=\"100%\"; align=\"center\" valign=\"center\" >\n";
            s_Return += "<tr >\n";
            s_Return += "<td " + s_TotalStyle + ">\n";
            s_Return += "本月新增联系记录";
            s_Return += "</td>\n";
            s_Return += "<td " + s_TotalStyle + ">\n";
            s_Return += "本月订单成交量";
            s_Return += "</td>\n";
            s_Return += "<td " + s_TotalStyle + ">\n";
            s_Return += "本月订单成交金额";
            s_Return += "</td>\n";
            s_Return += "<td " + s_TotalStyle + ">\n";
            s_Return += "本月收款金额";
            s_Return += "</td>\n";
            s_Return += "<td " + s_TotalStyle + ">\n";
            s_Return += "本月发货数量";
            s_Return += "</td>\n";
            s_Return += "<td " + s_TotalStyle + ">\n";
            s_Return += "本月发货金额";
            s_Return += "</td>\n";
            s_Return += "</tr>\n";
            //客户
            string[] s_LastWork = new string[3];
            string s_Sql = "select Sum(case when datediff(month,CustomerAddTime,getdate())=0 then 1 else 0 end) as ThisWeek,";
            s_Sql += "Sum(case when datediff(month,CustomerAddTime,getdate())=1 then 1 else 0 end) as LastWeek,Sum(case when datediff(year,CustomerAddTime,getdate())=0 then 1 else 0 end) as thisyear";
            s_Sql += " from KNet_sales_ClientList";
            try
            {
                this.BeginQuery(s_Sql);
                this.QueryForDataTable();
            
                if (this.Dtb_Result.Rows.Count > 0)
                {
                    try
                    {
                        s_LastWork[0] = Dtb_Result.Rows[0][0].ToString();
                        s_LastWork[1] = Dtb_Result.Rows[0][1].ToString();
                        s_LastWork[2] = Dtb_Result.Rows[0][2].ToString();
                        /*
                         * if (s_LastWork[1] != "0")
                        {

                            s_LastWork[2] = Convert.ToString((decimal.Parse(s_LastWork[0]) - decimal.Parse(s_LastWork[1])) / decimal.Parse(s_LastWork[1]) * 100);
                        }
                        else
                        {
                            s_LastWork[2] = Convert.ToString((decimal.Parse(s_LastWork[0]) - decimal.Parse(s_LastWork[1])) * 100);
                        }
                         * */
                    }
                    catch { }
                }
            }
            catch
            { }
            //联系记录
            string[] s_Content = new string[3];
            s_Sql = "select Sum(case when datediff(month,XSC_CTime,getdate())=0 then 1 else 0 end) as ThisWeek,";
            s_Sql += "Sum(case when datediff(month,XSC_CTime,getdate())=1 then 1 else 0 end) as LastWeek";
            s_Sql += ",Sum(case when datediff(year,XSC_CTime,getdate())=0 then 1 else 0 end) as thisyear";
            s_Sql += " from Xs_Sales_Content";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            if (this.Dtb_Result.Rows.Count > 0)
            {
                try
                {
                    s_Content[0] = Dtb_Result.Rows[0][0].ToString();
                    s_Content[1] = Dtb_Result.Rows[0][1].ToString();
                    s_Content[2] = Dtb_Result.Rows[0][2].ToString();
                    /*
                    if (s_Content[1] != "0")
                    {

                        s_Content[2] = Convert.ToString((decimal.Parse(s_Content[0]) - decimal.Parse(s_Content[1])) / decimal.Parse(s_Content[1]) * 100);
                    }
                    else
                    {
                        s_Content[2] = Convert.ToString((decimal.Parse(s_Content[0]) - decimal.Parse(s_Content[1])) * 100);
                    }
                     * */
                }
                catch { }
            }

            //本周订单
            //本周订单金额
            string[] s_Order = new string[6];
            s_Sql = "select Sum(case when datediff(month,SystemDateTimes,getdate())=0 then b.ContractAmount else 0 end) as ThisWeekNumber,";
            s_Sql += "Sum(case when datediff(month,SystemDateTimes,getdate())=1 then b.ContractAmount else 0 end) as LastWeekNumber,";
            s_Sql += "Sum(case when datediff(month,SystemDateTimes,getdate())=0 then b.Contract_SalesTotalNet else 0 end) as ThisWeekTotalNet,";
            s_Sql += "Sum(case when datediff(month,SystemDateTimes,getdate())=1 then b.Contract_SalesTotalNet else 0 end) as LastWeekTotalNet,";
            s_Sql += "Sum(case when datediff(year,SystemDateTimes,getdate())=0 then b.ContractAmount else 0 end) as thisyearNumber,";
            s_Sql += "Sum(case when datediff(year,SystemDateTimes,getdate())=0 then b.Contract_SalesTotalNet else 0 end) as ThisyearTotalNet";
            s_Sql += " from KNet_Sales_ContractList a join KNet_Sales_ContractList_Details b on a.ContractNo=b.ContractNo";
            s_Sql += " join KNET_Sys_Products e on b.ProductsBarCode=e.ProductsBarCode  ";

            KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
            string s_SonID = Bll_ProductsDetails.GetSonIDs("01");
            s_SonID = s_SonID.Replace(",", "','");
            s_Sql += " where  a.contractClass<>'129687502761283822' and e.ProductsType in ('" + s_SonID + "') ";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            if (this.Dtb_Result.Rows.Count > 0)
            {
                try
                {
                    s_Order[0] = Dtb_Result.Rows[0][0].ToString();
                    s_Order[1] = Dtb_Result.Rows[0][1].ToString();
                    s_Order[2] = Dtb_Result.Rows[0][4].ToString();

                    /*if (s_Order[1] != "0")
                    {
                        s_Order[2] = Convert.ToString((decimal.Parse(s_Order[0]) - decimal.Parse(s_Order[1])) / decimal.Parse(s_Order[1]) * 100);
                    }
                    else
                    {
                        s_Order[2] = Convert.ToString((decimal.Parse(s_Order[0]) - decimal.Parse(s_Order[1])) * 100);
                    }*/
                    s_Order[3] = Dtb_Result.Rows[0][2].ToString();
                    s_Order[4] = Dtb_Result.Rows[0][3].ToString();
                    s_Order[5] = Dtb_Result.Rows[0][5].ToString();
                    /*
                    if (decimal.Parse(s_Order[4]) != 0)
                    {
                        s_Order[5] = Convert.ToString((decimal.Parse(s_Order[3]) - decimal.Parse(s_Order[4])) / decimal.Parse(s_Order[4]) * 100);
                    }
                    else
                    {
                        s_Order[5] = Convert.ToString((decimal.Parse(s_Order[3]) - decimal.Parse(s_Order[4])) * 100);
                    }*/
                }
                catch (Exception ex) { }
            }

            //本周出库
            //本周出库金额
            string[] s_Ship = new string[10];
            s_Sql = "select Sum(case when datediff(month,KWD_CwOutTime,getdate())=0 then DirectOutAmount else 0 end) as ThismonthNumber,";
            s_Sql += "Sum(case when datediff(month,KWD_CwOutTime,getdate())=1 then DirectOutAmount else 0 end) as LastmonthNumber,";
            s_Sql += "Sum(case when datediff(month,KWD_CwOutTime,getdate())=0 then KWD_SalesTotalNet else 0 end) as ThisMonthTotalNet,";
            s_Sql += "Sum(case when datediff(month,KWD_CwOutTime,getdate())=1 then KWD_SalesTotalNet else 0 end) as LastMonthTotalNet,";
            s_Sql += "Sum(case when datediff(year,KWD_CwOutTime,getdate())=0 then KWD_SalesTotalNet else 0 end) as ThisYearTotalNet, ";
            s_Sql += "Sum(case when datediff(year,KWD_CwOutTime,getdate())=0 then DirectOutAmount else 0 end) as ThisYearNumber ";
            s_Sql += " from v_DirectOutList  ";

            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            if (this.Dtb_Result.Rows.Count > 0)
            {
                try
                {
                    s_Ship[0] = Dtb_Result.Rows[0]["ThismonthNumber"].ToString();
                    s_Ship[1] = Dtb_Result.Rows[0]["LastmonthNumber"].ToString();
                    s_Ship[2] = Dtb_Result.Rows[0]["ThisYearNumber"].ToString();

                    s_Ship[6] = Dtb_Result.Rows[0]["ThisMonthTotalNet"].ToString();
                    s_Ship[7] = Dtb_Result.Rows[0]["LastMonthTotalNet"].ToString();
                    s_Ship[8] = Dtb_Result.Rows[0]["ThisYearTotalNet"].ToString();
                    /*
                    s_Ship[6] = Dtb_Result.Rows[0][4].ToString();
                    if (s_Ship[1] != "0")
                    {
                        s_Ship[2] = Convert.ToString((decimal.Parse(s_Ship[0]) - decimal.Parse(s_Ship[1])) / decimal.Parse(s_Ship[1]) * 100);
                    }
                    else
                    {
                        s_Ship[2] = Convert.ToString((decimal.Parse(s_Ship[0]) - decimal.Parse(s_Ship[1])) * 100);
                    }
                    s_Ship[3] = Dtb_Result.Rows[0][2].ToString();
                    s_Ship[4] = Dtb_Result.Rows[0][3].ToString();
                    if (decimal.Parse(s_Ship[4]) != 0)
                    {
                        s_Ship[5] = Convert.ToString((decimal.Parse(s_Ship[3]) - decimal.Parse(s_Ship[4])) / decimal.Parse(s_Ship[4]) * 100);
                    }
                    else
                    {
                        s_Ship[5] = Convert.ToString((decimal.Parse(s_Ship[3]) - decimal.Parse(s_Ship[4])) * 100);
                    }
                    if (s_Ship[7] != "0")
                    {
                        s_Ship[8] = Convert.ToString((decimal.Parse(s_Ship[6]) - decimal.Parse(s_Ship[7])) / decimal.Parse(s_Ship[7]) * 100);
                    }
                    else
                    {
                        s_Ship[8] = Convert.ToString((decimal.Parse(s_Ship[6]) - decimal.Parse(s_Ship[7])) * 100);
                    }*/
                }
                catch (Exception ex) { }
            }

            //收款金额
            string[] s_Pay = new string[3];
            s_Sql = "select Sum(case when datediff(Month,CAA_PayTime,getdate())=0 then CAA_PayMoney else 0 end) as ThisWeek,";
            s_Sql += "Sum(case when datediff(Month,CAA_PayTime,getdate())=1 then CAA_PayMoney else 0 end) as LastWeek,";
            s_Sql += "Sum(case when datediff(year,CAA_PayTime,getdate())=0 then CAA_PayMoney else 0 end) as thisyear";
            s_Sql += " from Cw_Accounting_Pay where CAA_Type=1 and CAP_Type='0' ";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            if (this.Dtb_Result.Rows.Count > 0)
            {
                try
                {
                    s_Pay[0] = Dtb_Result.Rows[0][0].ToString();
                    s_Pay[1] = Dtb_Result.Rows[0][1].ToString();
                    s_Pay[2] = Dtb_Result.Rows[0][2].ToString();
                    /*
                    if (s_Pay[1] != "0")
                    {
                        s_Pay[2] = Convert.ToString((decimal.Parse(s_Pay[0]) - decimal.Parse(s_Pay[1])) / decimal.Parse(s_Pay[1]) * 100);
                    }
                    else
                    {
                        s_Pay[2] = Convert.ToString((decimal.Parse(s_Pay[0]) - decimal.Parse(s_Pay[1])) * 100);
                    }*/
                }
                catch { }
            }

            s_Return += "<tr >\n";
            s_Return += "<td " + s_DetailsStyle + ">\n";
            s_Return += "<a href=\"/web/Xs/CustomerContent/Xs_Sales_Content_List.aspx?WhereID=M141203095012884\">" + s_Content[0] + "</a>";
            s_Return += "</td>\n";

            s_Return += "<td " + s_DetailsStyle + ">\n";
            s_Return += "<a href=\"/web/Xs/SalesContract/KNet_Sales_ContractList_List.aspx?WhereID=M141203100132301\">" + base.FormatNumber(s_Order[0], 0) + "</a>";
            s_Return += "</td>\n";
            s_Return += "<td " + s_DetailsStyle + ">\n";
            s_Return += "<a href=\"/web/Xs/SalesContract/KNet_Sales_ContractList_List.aspx?WhereID=M141203100132301\">" + base.FormatNumber(s_Order[3], 0) + "</a>";

            s_Return += "</td>\n";
            s_Return += "<td " + s_DetailsStyle + ">\n";
            s_Return += "<a href=\"/web/Rece/Cw_Accounting_Pay_List.aspx?WhereID=M141203102026294\">" + base.FormatNumber(s_Pay[0], 0) + "</a>";
            s_Return += "</td>\n";

            s_Return += "<td " + s_DetailsStyle + ">\n";
            s_Return += "<a href=\"/web/Xs/SalesOut/Sales_ShipWareOut_Manage.aspx?WhereID=M14120310345788\">" + base.FormatNumber(s_Ship[0], 0) + "</a>";
            s_Return += "</td>\n";

            s_Return += "<td " + s_DetailsStyle + ">\n";
            s_Return += "<a href=\"/web/Xs/SalesOut/Sales_ShipWareOut_Manage.aspx?WhereID=M14120310345788\">" + base.FormatNumber(s_Ship[6], 0) + "</a>";
            s_Return += "</td>\n";

            s_Return += "</tr>\n";

            s_Return += "<tr>\n";
            s_Return += "<td " + s_BotStyle + ">\n";
            s_Return += "上月：<a href=\"/Web/Xs/CustomerContent/Xs_Sales_Content_List.aspx?WhereID=M141203095055594\">" + base.FormatNumber1(s_Content[1], 0) + "</a><br/>";
            s_Return += "本年：" + base.FormatNumber1(s_Content[2], 0) + "";
            s_Return += "</td>\n";

            s_Return += "<td " + s_BotStyle + ">\n";
            s_Return += "上月：<a href=\"/web/Xs/SalesContract/KNet_Sales_ContractList_List.aspx?WhereID=M141203100535960\">" + base.FormatNumber(s_Order[1], 0) + "</a><br/>";
            s_Return += "本年：" + base.FormatNumber(s_Order[2], 0) + "";
            s_Return += "</td>\n";

            s_Return += "<td " + s_BotStyle + ">\n";
            s_Return += "上月：<a href=\"/web/Xs/SalesContract/KNet_Sales_ContractList_List.aspx?WhereID=M141203100535960\">" + base.FormatNumber(s_Order[4], 0) + "</a><br/>";
            s_Return += "本年：" + base.FormatNumber(s_Order[5], 0) + "";
            s_Return += "</td>\n";
            s_Return += "<td " + s_BotStyle + ">\n";
            s_Return += "上月：<a href=\"/web/Rece/Cw_Accounting_Pay_List.aspx?WhereID=M141203102059881\">" + base.FormatNumber(s_Pay[1], 0) + "</a>";
            s_Return += "<br/>";

            s_Return += "本年：" + base.FormatNumber(s_Pay[2], 0) + "";
            s_Return += "</td>\n";


            s_Return += "<td " + s_BotStyle + ">\n";
            s_Return += "上月：<a href=\"/web/Xs/SalesOut/Sales_ShipWareOut_Manage.aspx?WhereID=M141203103729933\">" + base.FormatNumber(s_Ship[1], 0) + "</a><br/>";
            s_Return += "本年：" + base.FormatNumber(s_Ship[2], 0) + "";
            s_Return += "</td>\n";

            s_Return += "<td " + s_BotStyle + ">\n";
            s_Return += "上月：<a href=\"/web/Xs/SalesOut/Sales_ShipWareOut_Manage.aspx?WhereID=M141203103729933\">" + base.FormatNumber(s_Ship[7], 0) + "</a><br/>";
            s_Return += "本年：" + base.FormatNumber(s_Ship[8], 0) + "";
            s_Return += "</td>\n";
            s_Return += "</tr>\n";
            s_Return += "</table>\n";
            this.Lbl_WeekTotal.Text = s_Return;
        }
        catch
        { }
    }
    public void bindCgMonth()
    {

        //成品采购金额
        string[] s_Order = new string[6];
        string s_Sql = "select Sum(case when datediff(Month,OrderDateTime,getdate())=0 and a.OrderType='128860698200781250' then OrderAmount else 0 end) as ThisMonthRCNumber,";
        s_Sql += "Sum(case when datediff(Month,OrderDateTime,getdate())=1  and a.OrderType='128860698200781250' then OrderAmount else 0 end) as LastMonthRCNumber,";
        s_Sql += "Sum(case when datediff(Month,OrderDateTime,getdate())=0  and a.OrderType<>'128860698200781250' then OrderAmount else 0 end) as ThisMonthMaterNumber,";
        s_Sql += "Sum(case when datediff(Month,OrderDateTime,getdate())=1  and a.OrderType<>'128860698200781250' then OrderAmount else 0 end) as LastMonthMaterNumber";
        s_Sql += " from Knet_Procure_OrdersList a join Knet_Procure_OrdersList_Details b on a.OrderNo=b.OrderNo ";
        this.BeginQuery(s_Sql);
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            try
            {
                s_Order[0] = Dtb_Result.Rows[0][0].ToString();
                s_Order[1] = Dtb_Result.Rows[0][1].ToString();
                if (s_Order[1] != "0")
                {
                    s_Order[2] = Convert.ToString((decimal.Parse(s_Order[0]) - decimal.Parse(s_Order[1])) / decimal.Parse(s_Order[1]) * 100);
                }
                else
                {
                    s_Order[2] = Convert.ToString((decimal.Parse(s_Order[0]) - decimal.Parse(s_Order[1])) * 100);
                }
                s_Order[3] = Dtb_Result.Rows[0][2].ToString();
                s_Order[4] = Dtb_Result.Rows[0][3].ToString();
                if (s_Order[3] != "0")
                {
                    s_Order[5] = Convert.ToString((decimal.Parse(s_Order[3]) - decimal.Parse(s_Order[4])) / decimal.Parse(s_Order[4]) * 100);
                }
                else
                {
                    s_Order[5] = Convert.ToString((decimal.Parse(s_Order[3]) - decimal.Parse(s_Order[4])) * 100);
                }
            }
            catch { }
        }

        //成品入库数量
        string[] s_Rk = new string[3];
        s_Sql = "select Sum(case when datediff(Month,SEM_Stime,getdate())=0  then SER_ScNumber else 0 end) as ThisMonthRCNumber,";
        s_Sql += "Sum(case when datediff(Month,SEM_Stime,getdate())=1   then SER_ScNumber else 0 end) as LastMonthRCNumber";
        s_Sql += " from Sc_Expend_Manage_RCDetails a join Sc_Expend_Manage b on a.SER_SEMID=b.SEM_ID ";
        this.BeginQuery(s_Sql);
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            try
            {
                s_Rk[0] = Dtb_Result.Rows[0][0].ToString();
                s_Rk[1] = Dtb_Result.Rows[0][1].ToString();
                if (s_Rk[1] != "0")
                {
                    s_Rk[2] = Convert.ToString((decimal.Parse(s_Rk[0]) - decimal.Parse(s_Rk[1])) / decimal.Parse(s_Rk[1]) * 100);
                }
                else
                {
                    s_Rk[2] = Convert.ToString((decimal.Parse(s_Rk[0]) - decimal.Parse(s_Rk[1])) * 100);
                }
            }
            catch { }
        }

        //本周出库
        //本周出库金额
        string[] s_Ship = new string[10];
        s_Sql = "select Sum(case when datediff(month,KWD_CwOutTime,getdate())=0 then DirectOutAmount else 0 end) as ThisWeekNumber,";
        s_Sql += "Sum(case when datediff(month,KWD_CwOutTime,getdate())=1 then DirectOutAmount else 0 end) as LastWeekNumber,";
        s_Sql += "Sum(case when datediff(week,KWD_CwOutTime,getdate())=0 then KWD_SalesTotalNet else 0 end) as ThisWeekTotalNet,";
        s_Sql += "Sum(case when datediff(week,KWD_CwOutTime,getdate())=1 then KWD_SalesTotalNet else 0 end) as LastWeekTotalNet,";
        s_Sql += "Sum(case when datediff(month,KWD_CwOutTime,getdate())=0 then KWD_SalesTotalNet else 0 end) as ThisMonthTotalNet,";
        s_Sql += "Sum(case when datediff(month,KWD_CwOutTime,getdate())=1 then KWD_SalesTotalNet else 0 end) as LastMonthTotalNet";
        s_Sql += " from v_DirectOutList  ";

        this.BeginQuery(s_Sql);
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            try
            {
                s_Ship[0] = Dtb_Result.Rows[0][0].ToString();
                s_Ship[1] = Dtb_Result.Rows[0][1].ToString();
                s_Ship[6] = Dtb_Result.Rows[0][4].ToString();
                s_Ship[7] = Dtb_Result.Rows[0][5].ToString();
                if (s_Ship[1] != "0")
                {
                    s_Ship[2] = Convert.ToString((decimal.Parse(s_Ship[0]) - decimal.Parse(s_Ship[1])) / decimal.Parse(s_Ship[1]) * 100);
                }
                else
                {
                    s_Ship[2] = Convert.ToString((decimal.Parse(s_Ship[0]) - decimal.Parse(s_Ship[1])) * 100);
                }
                s_Ship[3] = Dtb_Result.Rows[0][2].ToString();
                s_Ship[4] = Dtb_Result.Rows[0][3].ToString();
                if (decimal.Parse(s_Ship[4]) != 0)
                {
                    s_Ship[5] = Convert.ToString((decimal.Parse(s_Ship[3]) - decimal.Parse(s_Ship[4])) / decimal.Parse(s_Ship[4]) * 100);
                }
                else
                {
                    s_Ship[5] = Convert.ToString((decimal.Parse(s_Ship[3]) - decimal.Parse(s_Ship[4])) * 100);
                }
                if (s_Ship[7] != "0")
                {
                    s_Ship[8] = Convert.ToString((decimal.Parse(s_Ship[6]) - decimal.Parse(s_Ship[7])) / decimal.Parse(s_Ship[7]) * 100);
                }
                else
                {
                    s_Ship[8] = Convert.ToString((decimal.Parse(s_Ship[6]) - decimal.Parse(s_Ship[7])) * 100);
                }
            }
            catch (Exception ex) { }
        }

        string[] s_KC = new string[10];
        string s_Date = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + "1";
        s_Sql = "select Sum(DirectInAmount),Sum(case when DirectInDateTime <'" + s_Date + "' then  DirectInAmount else 0 end) from V_Store ";
        s_Sql += " a join KNET_Sys_Products b on a.ProductsBarCode=b.ProductsBarCode ";
        s_Sql += " where  HouseNo in(select HouseNo from KNet_Sys_WareHouse  where  KSW_Type=0 ) and a.KSP_Code like '01%'";

        try
        {
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            if (this.Dtb_Result.Rows.Count > 0)
            {
                try
                {
                    s_KC[0] = Dtb_Result.Rows[0][0].ToString();
                    s_KC[1] = Dtb_Result.Rows[0][1].ToString();
                    if (s_KC[1] != "0")
                    {
                        s_KC[2] = Convert.ToString((decimal.Parse(s_KC[0]) - decimal.Parse(s_KC[1])) / decimal.Parse(s_KC[1]) * 100);
                    }
                    else
                    {
                        s_KC[2] = Convert.ToString((decimal.Parse(s_KC[0]) - decimal.Parse(s_KC[1])) * 100);
                    }
                }
                catch { }
            }
        }
        catch
        { }

        string[] s_OrderIn = new string[3];

        s_Sql = "select Sum(case when datediff(month,WareHouseDateTime,getdate())=0 then WareHouseAmount else 0 end) thismonth,";
        s_Sql += " Sum(case when datediff(month,WareHouseDateTime,getdate())=1 then WareHouseAmount else 0 end) ";
        s_Sql += " from Knet_Procure_WareHouseList a ";
        s_Sql += " join Knet_Procure_WareHouseList_Details b on a.WareHouseNo=b.WareHouseNo join KNET_Sys_Products c on b.ProductsBarCode=c.ProductsBarCode  ";
        s_Sql += " where KSP_Code not like '01%'";
        this.BeginQuery(s_Sql);
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            try
            {
                s_OrderIn[0] = Dtb_Result.Rows[0][0].ToString();
                s_OrderIn[1] = Dtb_Result.Rows[0][1].ToString();
                if (s_OrderIn[1] != "0")
                {
                    s_OrderIn[2] = Convert.ToString((decimal.Parse(s_OrderIn[0]) - decimal.Parse(s_OrderIn[1])) / decimal.Parse(s_OrderIn[1]) * 100);
                }
                else
                {
                    s_OrderIn[2] = Convert.ToString((decimal.Parse(s_OrderIn[0]) - decimal.Parse(s_OrderIn[1])) * 100);
                }
            }
            catch { }
        }

        string[] s_ClKC = new string[10];
        s_Sql = "select Sum(DirectInAmount),Sum(case when DirectInDateTime <'" + s_Date + "' then  DirectInAmount else 0 end) from V_Store ";
        s_Sql += " a join KNET_Sys_Products b on a.ProductsBarCode=b.ProductsBarCode ";
        s_Sql += " where   HouseNo in(select HouseNo from KNet_Sys_WareHouse  where  KSW_Type=0 ) and a.KSP_Code not like '01%'";
        try
        {
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            if (this.Dtb_Result.Rows.Count > 0)
            {
                try
                {
                    s_ClKC[0] = Dtb_Result.Rows[0][0].ToString();
                    s_ClKC[1] = Dtb_Result.Rows[0][1].ToString();
                    if (s_ClKC[1] != "0")
                    {
                        s_ClKC[2] = Convert.ToString((decimal.Parse(s_ClKC[0]) - decimal.Parse(s_ClKC[1])) / decimal.Parse(s_ClKC[1]) * 100);
                    }
                    else
                    {
                        s_ClKC[2] = Convert.ToString((decimal.Parse(s_ClKC[0]) - decimal.Parse(s_ClKC[1])) * 100);
                    }
                }
                catch { }
            }
        }
        catch 
        {
            // 忽略空表
        }

        string s_TotalStyle = "height=\"50px\" width=\"12%\"  style=\"font-size:16px;color:#666666;font-weight:400;\"";
        string s_DetailsStyle = "height=\"100px\" style=\"font-size:30px;color:#333333;font-weight:300;font-family:Arial;\"";
        string s_BotStyle = "height=\"50px\" style=\"font-size:12px;color:#666;font-weight:400;\"";

        string s_Return = "";
        s_Return += "<table  width=\"90%\" height=\"100%\"; align=\"center\" valign=\"center\" >\n";
        s_Return += "<tr >\n";
        s_Return += "<td " + s_TotalStyle + ">\n";
        s_Return += "成品采购数量";
        s_Return += "</td>\n";
        s_Return += "<td " + s_TotalStyle + ">\n";
        s_Return += "成品入库数量";
        s_Return += "</td>\n";
        s_Return += "<td " + s_TotalStyle + ">\n";
        s_Return += "成品出库总数量";
        s_Return += "</td>\n";
        s_Return += "<td " + s_TotalStyle + ">\n";
        s_Return += "出货总金额";
        s_Return += "</td>\n";
        s_Return += "<td " + s_TotalStyle + ">\n";
        s_Return += "成品库存数量";
        s_Return += "</td>\n";
        s_Return += "<td " + s_TotalStyle + ">\n";
        s_Return += "材料采购数量";
        s_Return += "</td>\n";
        s_Return += "<td " + s_TotalStyle + ">\n";
        s_Return += "材料入库数量";
        s_Return += "</td>\n";
        s_Return += "<td " + s_TotalStyle + ">\n";
        s_Return += "材料库存总量";
        s_Return += "</td>\n";

        s_Return += "</tr>\n";

        s_Return += "<tr >\n";
        s_Return += "<td " + s_DetailsStyle + ">\n";
        s_Return += "<a href=\"/Web/CG/Order/Knet_Procure_OpenBilling_Manage.aspx?WhereID=M141204030406437\">" + base.FormatNumber(s_Order[0], 0) + "</a>";
        s_Return += "</td>\n";
        s_Return += "<td " + s_DetailsStyle + ">\n";
        s_Return += base.FormatNumber(s_Rk[0], 0);
        s_Return += "</td>\n";

        s_Return += "<td " + s_DetailsStyle + ">\n";
        s_Return += "<a href=\"/web/Xs/SalesOut/Sales_ShipWareOut_Manage.aspx?WhereID=M14120310345788\">" + base.FormatNumber(s_Ship[0], 0) + "</a>";
        s_Return += "</td>\n";
        s_Return += "<td " + s_DetailsStyle + ">\n";
        s_Return += "<a href=\"/web/Xs/SalesOut/Sales_ShipWareOut_Manage.aspx?WhereID=M14120310345788\">" + base.FormatNumber(s_Ship[6], 0) + "</a>";
        s_Return += "</td>\n";
        s_Return += "<td " + s_DetailsStyle + ">\n";
        s_Return += base.FormatNumber(s_KC[0], 0);
        s_Return += "</td>\n";
        s_Return += "<td " + s_DetailsStyle + ">\n";
        s_Return += base.FormatNumber(s_Order[3], 0);
        s_Return += "</td>\n";

        s_Return += "<td " + s_DetailsStyle + ">\n";
        s_Return += base.FormatNumber(s_OrderIn[0], 0);
        s_Return += "</td>\n";
        s_Return += "<td " + s_DetailsStyle + ">\n";
        s_Return += base.FormatNumber(s_ClKC[0], 0);
        s_Return += "</td>\n";
        s_Return += "</tr>\n";

        s_Return += "<tr>\n";
        s_Return += "<td " + s_BotStyle + ">\n";
        s_Return += "上月：<a href=\"/Web/CG/Order/Knet_Procure_OpenBilling_Manage.aspx?WhereID=M141204031028533\">" + s_Order[1] + "</a><br/>";
        s_Return += "较上月：" + base.FormatNumber1(s_Order[2], 0) + "%";
        s_Return += "</td>\n";
        s_Return += "<td " + s_BotStyle + ">\n";
        s_Return += "上月：" + s_Rk[1] + "<br/>";
        s_Return += "较上月：" + base.FormatNumber1(s_Rk[2], 0) + "%";
        s_Return += "</td>\n";

        s_Return += "<td " + s_BotStyle + ">\n";
        s_Return += "上月：<a href=\"/web/Xs/SalesOut/Sales_ShipWareOut_Manage.aspx?WhereID=M141203103729933\">" + base.FormatNumber(s_Ship[1], 0) + "</a><br/>";
        s_Return += "较上月：" + base.FormatNumber1(s_Ship[2], 0) + "%";
        s_Return += "</td>\n";

        s_Return += "<td " + s_BotStyle + ">\n";
        s_Return += "上月：<a href=\"/web/Xs/SalesOut/Sales_ShipWareOut_Manage.aspx?WhereID=M141203103729933\">" + base.FormatNumber(s_Ship[7], 0) + "</a><br/>";
        s_Return += "较上月：" + base.FormatNumber1(s_Ship[8], 0) + "%";
        s_Return += "</td>\n";
        s_Return += "<td " + s_BotStyle + ">\n";
        s_Return += "上月：" + base.FormatNumber1(s_KC[1], 0);

        s_Return += "<br/>";

        s_Return += "较上月：" + base.FormatNumber1(s_KC[2], 0) + "%";
        s_Return += "</td>\n";
        s_Return += "<td " + s_BotStyle + ">\n";

        s_Return += "上月：" + base.FormatNumber1(s_Order[4], 0);

        s_Return += "<br/>";

        s_Return += "较上月：" + base.FormatNumber1(s_Order[5], 0) + "%";
        s_Return += "</td>\n";
        s_Return += "<td " + s_BotStyle + ">\n";

        s_Return += "上月：" + base.FormatNumber1(s_OrderIn[1], 0) + "<br/>";
        s_Return += "较上月：" + base.FormatNumber1(s_OrderIn[2], 0) + "%";
        s_Return += "</td>\n";
        s_Return += "<td " + s_BotStyle + ">\n";

        s_Return += "上月：" + base.FormatNumber1(s_ClKC[1], 0) + "<br/>";
        s_Return += "较上月：" + base.FormatNumber1(s_ClKC[2], 0) + "%";
        s_Return += "</td>\n";
        s_Return += "</tr>\n";
        s_Return += "</table>\n";
        this.Lbl_CgDetails.Text = s_Return;
    }
}
