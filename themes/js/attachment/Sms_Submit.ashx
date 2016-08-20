
<%@ WebHandler Language="C#" Class="Sms_Submit" %>
using System;
using System.Web;
using System.Text;
using System.Web.SessionState;
using System.Data.SqlClient;
using System.Data;
using KNet.DBUtility;
using KNet.Common;

public class Sms_Submit : IHttpHandler, IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
        context.Response.Clear();
        context.Response.Buffer = true;

        try {
            AdminloginMess AM = new AdminloginMess();
            BasePage Page = new BasePage();
            KNet.BLL.System_Message_Manage BLL = new KNet.BLL.System_Message_Manage();
            KNet.Model.System_Message_Manage Model = new KNet.Model.System_Message_Manage();
            string s_SMS_ID = context.Request["SMS_ID"] == null ? "" : context.Request["SMS_ID"].ToString();
            if (s_SMS_ID != "")
            {
                string[] s_ID = s_SMS_ID.Split(',');
                for (int i = 0; i < s_ID.Length; i++)
                {
                    if (s_ID[i] != "")
                    {
                        Model.SMM_ID = s_ID[i];
                        Model.SMM_UnRead = 0;
                        Model.SMM_LookTime = DateTime.Now;
                        //更新已读情况 
                        BLL.UpdateUnRead(Model);
                    }

                }
            }
            context.Response.Write("1");
        }
        catch
        {
            context.Response.Write("0");
        }
        
        context.Response.Flush();
        context.Response.End();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}