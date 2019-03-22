using KNet.Common;
using KNet.DBUtility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KNet.Model;
using System.Text;
using System.Net.Mail;

public partial class Web_Complain_Knet_Product_Prototype_InOut : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string KPI_SID = Request.QueryString["KPI_SID"] == null
                ? ""
                : Request.QueryString["KPI_SID"].ToString();
            //string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            //this.SamplingID.Text = SamlingID;
            this.TextBox1.Text = s_GetCode();
            KSP_Stime.Text = DateTime.Now.ToString();
            base.Base_DropWareHouseBind(this.Ddl_HouseNoOut, "  KSW_Type=0 ");
            base.Base_DropWareHouseBind(this.Ddl_HouseNoIn, "  KSW_Type=0 ");
            base.Base_DropBasicCodeBind(this.Ddl_OutOrIn, "1144");
            base.Base_DropDutyPerson(this.Ddl_DutyPerson);
            if (KPI_SID!="")
            {
                
                ShowInfo(KPI_SID);
            }
            base.Base_DropBasicCodeBind(this.BClass, "1146");
            this.BClass.SelectedValue = "0";
        }
    }

    public void ShowInfo(string KPI_SID)
    {
        KNet.BLL.KNet_Product_Gauge_InOut bll = new KNet.BLL.KNet_Product_Gauge_InOut();
        KNet.Model.KNet_Product_Gauge_InOut modle = bll.GetModel(KPI_SID);
        this.TextBox1.Text = modle.KPI_SID;
        this.KSP_Stime.Text = modle.KPI_Time.ToString();
        this.Ddl_HouseNoOut.SelectedValue = modle.KPI_UseFrom;
        this.Ddl_HouseNoIn.SelectedValue = modle.KPI_UserIn;
        this.Ddl_DutyPerson.SelectedValue = modle.KPI_Person;
        this.Ddl_OutOrIn.SelectedValue = modle.KPI_InOut.ToString();
        this.OrderRemarks.Text = modle.KPI_Text;
        this.BClass.SelectedValue = modle.KPI_Type.ToString();
        this.BeginQuery("select * from KNet_Product_Gauge_InOut where KPI_SID='"+ modle.KPI_SID + "'");
        this.QueryForDataTable();
        DataTable Dtb_Re = Dtb_Result;
        StringBuilder Sb_Details = new StringBuilder();
        if (Dtb_Re.Rows.Count > 0)
        {
            Tbx_Num.Text = Dtb_Re.Rows.Count.ToString();
            for (int i = 0; i < Dtb_Re.Rows.Count; i++)
            {
                Sb_Details.Append("<tr>\n");
                Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                Sb_Details.Append(Convert.ToString(i + 1));
                Sb_Details.Append("&nbsp;<A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"/themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a>\n");
                Sb_Details.Append("</td>\n"); //序号

                Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                Sb_Details.Append("<input id=\"Code_" + i.ToString() + "\" type=\"hidden\" name=\"Code_" +
                                  i.ToString() + "\"  value=\"" + Dtb_Re.Rows[i]["KPI_Code"].ToString()  + "\" />" +
                                  Dtb_Re.Rows[i]["KPI_Code"].ToString() + "\n");
                Sb_Details.Append("</td>\n"); //治具编号

                Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                Sb_Details.Append("<input id=\"Name_" + i.ToString() + "\" type=\"hidden\" name=\"Name_" +
                                  i.ToString() + "\"  />" +
                                 GetKPG_Name(Dtb_Re.Rows[i]["KPI_Code"].ToString()) + "\n");
                Sb_Details.Append("</td>\n"); //治具名称

                Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                Sb_Details.Append("<input id=\"KCount_" + i.ToString() + "\" type=\"hidden\" name=\"KCount_" +
                                  i.ToString() + "\"  />" + Base_GetStoreCount(Dtb_Re.Rows[i]["KPI_UseFrom"].ToString(), Dtb_Re.Rows[i]["KPI_Code"].ToString()) + "\n");
                Sb_Details.Append("</td>\n");//库存数量
                Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                Sb_Details.Append("<input id=\"Number_" + i.ToString() + "\" type=\"text\" name=\"Number_" +
                                  i.ToString() + "\"  value=\"" + Dtb_Re.Rows[i]["KPI_Number"].ToString() + "\"  />\n");
                Sb_Details.Append("</td>\n");//数量
                Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                Sb_Details.Append("<input id=\"KPI_BadNumber_" + i.ToString() + "\" type=\"text\" name=\"KPI_BadNumber_" +
                                  i.ToString() + "\"  value=\"" + Dtb_Re.Rows[i]["KPI_BadNumber"].ToString() + "\"  />\n");
                Sb_Details.Append("</td>\n");//损坏数量
                Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                Sb_Details.Append("<input id=\"Remarks_" + i.ToString() + "\" type=\"hidden\" name=\"Remarks_" +
                                  i.ToString() + "\"  />\n");
                Sb_Details.Append("</td>\n");//备注


            }
            this.s_MyTable_Detail.Text = Sb_Details.ToString();
        }

    }

    public string GetKPG_Name(string KPI_Code)
    {
        String s_Name = "";
        this.BeginQuery("select KPG_Name from KNet_Product_Gauge where KPG_KID='"+ KPI_Code + "'");
        this.QueryForDataTable();
        DataTable Dtb_Re = Dtb_Result;
        if (Dtb_Re.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Re.Rows.Count; i++)
            {
                s_Name += Dtb_Re.Rows[i][0].ToString();
                s_Name += "<br/>";
            }

        }
        return s_Name;
    }
    public string Base_GetStoreCount(string suppno, string id)
    {
        int s_Count = 0;
        this.BeginQuery("select ISNULL( sum(KPG_Number),0) from KNet_Product_Gauge where KPG_SuppNo='" + suppno + "' and KPG_KID='" + id + "'");
        this.QueryForDataTable();
        DataTable Dtb_Re1 = Dtb_Result;//本地库存
        this.BeginQuery("select ISNULL( sum(KPI_Number),0) from KNet_Product_Gauge_InOut where KPI_UseFrom='" + suppno + "' and KPI_InOut=0 and KPI_Code='" + id + "'and KPI_State=1");
        this.QueryForDataTable();
        DataTable Dtb_Re2 = Dtb_Result;//借出
        this.BeginQuery("select ISNULL( sum(KPI_Number),0) from KNet_Product_Gauge_InOut where KPI_UserIn='" + suppno + "' and KPI_InOut=0 and KPI_Code='" + id + "' and KPI_State=1");
        this.QueryForDataTable();
        DataTable Dtb_Re3 = Dtb_Result;//借出
        this.BeginQuery("select ISNULL( sum(KPI_Number),0) from KNet_Product_Gauge_InOut where KPI_UserIn='" + suppno + "' and KPI_InOut=1 and KPI_Code='" + id + "'and KPI_State=1");
        this.QueryForDataTable();
        DataTable Dtb_Re4 = Dtb_Result;//归还
        this.BeginQuery("select ISNULL( sum(KPI_Number),0) from KNet_Product_Gauge_InOut where KPI_UseFrom='" + suppno + "' and KPI_InOut=1 and KPI_Code='" + id + "' and KPI_State=1");
        this.QueryForDataTable();
        DataTable Dtb_Re5 = Dtb_Result;//归还
        //this.BeginQuery("select ISNULL( sum(KPI_Number),0) from KNet_Product_Gauge_InOut where KPI_UserIn='" + suppno + "' and KPI_InOut=1 and KPI_Code='" + id + "'and KPI_State=1");
        //this.QueryForDataTable();
        //DataTable Dtb_Re6 = Dtb_Result;//归还 
        this.BeginQuery("select ISNULL( sum(KPI_BadNumber),0) from KNet_Product_Gauge_InOut where KPI_UseFrom='" + suppno + "' and KPI_InOut=1 and KPI_Code='" + id + "' and KPI_State=1");
        this.QueryForDataTable();
        DataTable Dtb_Re7 = Dtb_Result;//归还
        s_Count = int.Parse(Dtb_Re1.Rows[0][0].ToString()) - int.Parse(Dtb_Re2.Rows[0][0].ToString()) +
                  int.Parse(Dtb_Re3.Rows[0][0].ToString()) + int.Parse(Dtb_Re4.Rows[0][0].ToString()) - int.Parse(Dtb_Re5.Rows[0][0].ToString())- int.Parse(Dtb_Re7.Rows[0][0].ToString());
        return s_Count.ToString();
    }
    private string s_GetCode()
    {
        string s_Return = "";
        try
        {

            s_Return += "W" + "-" + string.Format("{0:yyyyMMddHHmmss}", DateTime.Now);


        }
        catch (Exception ex)
        {
            s_Return = "-";
        }
        return s_Return;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        //string OrderTopic1 = KNetPage.KHtmlEncode("");
        KNet.Model.KNet_Product_Gauge_InOut modeBilling = new KNet_Product_Gauge_InOut();
        KNet.BLL.KNet_Product_Gauge_InOut BLLBilling = new KNet.BLL.KNet_Product_Gauge_InOut();
   

        ArrayList Arr_Products = new ArrayList();
        int i_Num = int.Parse(this.Tbx_Num.Text);
       
        try
        {
            if (i_Num>0)
            {
                BLLBilling.Delete(TextBox1.Text);
                for (int i = 0; i <= i_Num; i++)
                {
                    if (Request.Form["Code_" + i] != null)
                    {
                        modeBilling.KPI_SID = TextBox1.Text;
                        modeBilling.KPI_Code = Request.Form["Code_" + i].ToString();
                        modeBilling.KPI_InOut = int.Parse(Ddl_OutOrIn.SelectedValue);
                        modeBilling.KPI_Number = int.Parse(Request.Form["Number_" + i].ToString());
                        modeBilling.KPI_Person = AM.KNet_StaffNo;
                        modeBilling.KPI_Time = DateTime.Parse(KSP_Stime.Text);
                        modeBilling.KPI_UseFrom = Ddl_HouseNoOut.SelectedValue;
                        modeBilling.KPI_UserIn = Ddl_HouseNoIn.SelectedValue;
                        modeBilling.KPI_Text = OrderRemarks.Text;
                        modeBilling.KPI_Type = int.Parse(BClass.SelectedValue);
                        modeBilling.KPI_State = 0;
                        modeBilling.KPI_BadNumber= int.Parse(Request.Form["BadNumber_" + i].ToString());
                        BLLBilling.Add(modeBilling);
                    }

                }
            }
            if (Ddl_OutOrIn.SelectedValue == "1")
            {
                string body = "编号为" + TextBox1.Text + "的治具借出审核创建成功,请及时查看";
                string email_list = "lxj@systech.com.cn" + "|" + "xb@systech.com.cn" + "|";
                string File_Path = "";
                Send("治具借出审核通知", body, email_list, File_Path);
            }
            else
            {
                string body = "编号为" + TextBox1.Text + "的治具归还审核创建成功,请及时查看";
                string email_list = "lxj@systech.com.cn" + "|" + "xb@systech.com.cn" + "|";
                string File_Path = "";
                Send("治具归还审核通知", body, email_list, File_Path);
            }
            AlertAndRedirect("治具操作申请 添加  操作成功", "Knet_Product_Prototype.aspx");
        }
        catch (Exception ex)
        {
            //AlertAndRedirect("治具操作申请 添加  操作失败", "Knet_Product_Prototype.aspx");
            throw ex;
        }
    }
    #region 不管是借出还是归还，发送邮件给小罗和谢斌
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
}