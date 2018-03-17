<%@ WebHandler Language="C#" Class="MessageHandler" %>

using System;
using System.Web;
using System.Web.SessionState;

public class MessageHandler : IHttpHandler, IRequiresSessionState
{


    public void ProcessRequest(HttpContext context)
    {
        string strReceivedID = Convert.ToString(context.Session["KNet_Admin_StaffNo"]);
        context.Response.Write(this.getIsMessageExists());
    }

    public bool getIsMessageExists()
    {
        KNet.DBUtility.AdminloginMess adminLogin = new KNet.DBUtility.AdminloginMess();
        KNet.BLL.System_Message_Manage Message = new KNet.BLL.System_Message_Manage();
        KNet.Model.System_Message_Manage Model = new KNet.Model.System_Message_Manage();
        Model.SMM_State = 0;
        Model.SMM_Del = 0;
        Model.SMM_ReceiveID = adminLogin.KNet_StaffNo;
        return Message.Exists(Model);
    }
    
    public bool IsReusable {
        get {
            return false;
        }
    }

}