<%@ WebHandler Language="C#" Class="ProductClassHandler" %>

using System;
using System.Web;
using System.Data.SqlClient;
using System.Data;

public class ProductClassHandler:IHttpHandler
{
    public void ProcessRequest (HttpContext context) {
        string type = context.Request.QueryString["type"];
        if (type.Equals("BigClass"))
        {
            string BigNo = context.Request.QueryString["BigNo"];
            context.Response.ContentType = "text/plain";
            context.Response.Write(getSmallInfos(BigNo));
            //这个是从数据库中根据传来省的id 查询出来的。市的名字和主键，主键以便去查区的名字
        }
    }

    public string getSmallInfos(string BigNo)
    {
        DataSet ds = KNet.Common.KNet_Static_BigClass.GetSmallInfo(BigNo);
        string str = "";
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (i == ds.Tables[0].Rows.Count - 1)
            {
                str += ds.Tables[0].Rows[i]["SmallNo"].ToString() + "," + ds.Tables[0].Rows[i]["CateName"].ToString();
            }
            else
            {
                str += ds.Tables[0].Rows[i]["SmallNo"].ToString() + "," + ds.Tables[0].Rows[i]["CateName"].ToString() + "|";
            }
        }
        return str.Trim();
    }
    
    
    public bool IsReusable {
        get {
            return false;
        }
    }

}