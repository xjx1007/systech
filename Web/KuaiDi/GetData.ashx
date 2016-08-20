
<%@ WebHandler Language="C#" Class="GetData" %>
using System;
using System.Web;
using System.Net;
using System.Text;
using System.Web.SessionState;
using System.Data.SqlClient;
using System.Data;
using KNet.DBUtility;
using KNet.Common;
using System.Collections.Generic;
using System.Web.Script.Serialization;
public class GetData : IHttpHandler, IRequiresSessionState
{
    public BasePage basePage = new BasePage();
    public void ProcessRequest(HttpContext context)
    {
        context.Response.Clear();
        context.Response.Buffer = true;
        string s_Return = "";
        string s_ID = context.Request["ID"] == null ? "" : context.Request["ID"].ToString();
        string s_Type = context.Request["Type"] == null ? "" : context.Request["Type"].ToString();
        AdminloginMess AM = new AdminloginMess();
        string s_Sql="";
        
        context.Response.Write(s_Return);
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