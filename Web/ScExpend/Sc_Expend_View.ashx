<%@ WebHandler Language="C#" Class="Sc_Expend_View" %>

using System;
using System.Web;
using KNet.BLL;

public class Sc_Expend_View : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string action = context.Request["action"].ToString();
        string deletenum=context.Request["deletenum"].ToString();
        if (action == "Del_Expend")
        {
            Del(context,deletenum);
        }
    }

    public void Del(HttpContext context,string deletenum)
    {
        context.Response.ContentType = "text/plain";
        Sc_Expend_Manage_MaterDetails BLL = new Sc_Expend_Manage_MaterDetails();


        bool i = BLL.Delete(deletenum); ;


        if (i == true)
        {

            context.Response.Write("删除成功");


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