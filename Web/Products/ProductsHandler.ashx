<%@ WebHandler Language="C#" Class="ProductsHandler" %>

using System;
using System.Web;
using KNet.DBUtility;
public class ProductsHandler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string action = context.Request["action"].ToString();
        string deletenum = context.Request["deletenum"].ToString();
        if (action == "Del_Expend")
        {
            Del(context, deletenum);
        }
    }
    public void Del(HttpContext context, string deletenum)
    {
        //context.Response.ContentType = "text/plain";
        //    AdminloginMess AM = new AdminloginMess();
        //if (AM.YNAuthority("审核请购单"))
        //{
        //    string DoSqlOrder = " update KNet_Sampling_List set  AuditState='" + AuditState + "' where ID='" + s_ID + "' ";
        //    DbHelperSQL.ExecuteSql(DoSqlOrder);
        //}
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}