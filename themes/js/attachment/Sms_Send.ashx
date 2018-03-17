
<%@ WebHandler Language="C#" Class="UserOnline" %>
using System;
using System.Web;
using System.Web.SessionState;
using System.Data.SqlClient;
using System.Data;
using KNet.DBUtility;
using KNet.Common;

public class UserOnline : IHttpHandler, IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
        AdminloginMess AM = new AdminloginMess();
        BasePage Page = new BasePage();
        KNet.BLL.System_Message_Manage BLL = new KNet.BLL.System_Message_Manage();
        KNet.Model.System_Message_Manage Model = new KNet.Model.System_Message_Manage();
        Model.SMM_ID = Page.GetNewID("System_Message_Manage", 1);
        Model.SMM_Del = 0;
        Model.SMM_ReceiveID = context.Request["TO_ID"];
        Model.SMM_SenderID = AM.KNet_StaffNo;
        Model.SMM_State = 0;
        Model.SMM_Detail = KNetPage.KHtmlEncode(context.Request["CONTENT"]);
        Model.SMM_Title = "";
        Model.SMM_SendTime = DateTime.Now;
        Model.SMM_LookTime = null;
        Model.SMM_Type = "0";
        if (context.Request["TO_ID"] != null)
        {
            BLL.Add(Model);
            context.Response.Write("1");
        }
        else
        {
            context.Response.Write("0");
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}