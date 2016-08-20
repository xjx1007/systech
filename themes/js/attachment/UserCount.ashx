
<%@ WebHandler Language="C#" Class="UserCount" %>
using System;
using System.Web;
using System.Web.SessionState;
using System.Data.SqlClient;
using System.Data;

public class UserCount : IHttpHandler, IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
        context.Response.Clear();
        context.Response.Buffer = true;
        int i_Online = 0;
        string strReceivedID = Convert.ToString(context.Session["KNet_Admin_StaffNo"]);
        BasePage Page = new BasePage();
        Page.BeginQuery("Select * from KNet_Resource_Staff Where isOnline='1'  ");
        Page.QueryForDataTable();
        DataTable Dtb_Table = Page.Dtb_Result;
        if (Dtb_Table.Rows.Count > 0)
        {
            i_Online = Dtb_Table.Rows.Count;
        }
        context.Response.Write(i_Online.ToString());
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