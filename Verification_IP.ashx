<%@ WebHandler Language="C#" Class="Verification_IP" %>

using System;
using System.Web;

public class Verification_IP : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.AddHeader("Access-Control-Allow-Origin", "*");
        context.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
        context.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type");
        try
        {
            if (context.Request.QueryString["id"].ToString() == "Verification")
            {
                context.Response.Write("Verification_True");
            }
            else
            {
                context.Response.Write("Verification_False");
            }
        }
        catch
        {

            context.Response.Write("Verification_False");
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