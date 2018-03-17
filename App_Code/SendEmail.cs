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
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using System.Runtime.Serialization.Json;
using KNet.DBUtility;
using KNet.Common;
using System.Net;
using System.Net.Mail;
using System.Diagnostics;

/// <summary>
/// SendEmail 的摘要说明
/// </summary>
public class SendEmail
{
	public SendEmail()
	{
        
	}
    public string Base_SendEmail(string s_Receive, string s_Text, string s_File, string s_Title, string s_SettingID, string s_Cc, string s_Ms)
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.BLL.PB_Mail_Setting Bll_Seting = new KNet.BLL.PB_Mail_Setting();
        KNet.Model.PB_Mail_Setting Model_Seting = Bll_Seting.GetModel(s_SettingID);
        SmtpClient client = new SmtpClient();
        client.Credentials = new System.Net.NetworkCredential(Model_Seting.PMS_SendPerson, Model_Seting.PMS_Password);
        client.Host = Model_Seting.PMS_Sever;
        client.Port = int.Parse(Model_Seting.PMS_Port);
        client.EnableSsl = false;
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        MailMessage newMessage = new MailMessage();
        newMessage.From = new MailAddress(Model_Seting.PMS_SendEmail);
        newMessage.Subject = s_Title;
        newMessage.BodyEncoding = System.Text.Encoding.UTF8;//正文编码            
        newMessage.IsBodyHtml = true;//设置为HTML格式            
        newMessage.Priority = MailPriority.High;//优先级
        if (s_File != "")
        {
            string[] s_FileID = s_File.Split(',');
            for (int i = 0; i < s_FileID.Length; i++)
            {

                if (s_FileID[i] != "")
                {
                    string file = s_FileID[i];//附件路径
                    // AM.Add_Logs(Model_Seting.PMS_SendPerson + "," + Model_Seting.PMS_Password + "," + s_Receive + "," + file);
                    Attachment data = new Attachment(file, System.Net.Mime.MediaTypeNames.Application.Octet);
                    // Add time stamp information for the file.
                    System.Net.Mime.ContentDisposition disposition = data.ContentDisposition;
                    disposition.CreationDate = System.IO.File.GetCreationTime(file);
                    disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
                    disposition.ReadDate = System.IO.File.GetLastAccessTime(file);
                    // Add the file attachment to this e-mail message.
                    newMessage.Attachments.Add(data);
                }
            }
        }
        string[] s_ReceiveID = s_Receive.Split(',');
        for (int i = 0; i < s_ReceiveID.Length; i++)
        {
            newMessage.To.Add(s_ReceiveID[i]);
        }
        if (s_Cc != "")
        {
            string[] s_CcID = s_Cc.Split(',');
            for (int i = 0; i < s_CcID.Length; i++)
            {
                newMessage.CC.Add(s_CcID[i]);
            }
        }
        if (s_Ms != "")
        {
            string[] s_MsID = s_Ms.Split(',');
            for (int i = 0; i < s_MsID.Length; i++)
            {
                newMessage.Bcc.Add(s_MsID[i]);
            }
        }
        newMessage.Body = s_Text;
        try
        {
            client.Send(newMessage);
            newMessage.Dispose();
            client.Dispose();
            return "邮件发送成功";
        }
        catch (Exception exception)
        {
            // AM.Add_Logs(s_Receive + "," + s_Text + "," + s_Receive + "," + s_File + "," + s_SettingID);
            return "邮件发送失败,原因:" + exception.Message;
        }
    }
}