<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using System.Data.SqlClient;
using System.Data;

public class Handler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string type = context.Request.QueryString["type"];
        if (type.Equals("sheng"))
        {
            string id = context.Request.QueryString["id"];
            context.Response.ContentType = "text/plain";
            context.Response.Write(getSheng(id));//这个是从数据库中根据传来省的id 查询出来的。市的名字和主键，主键以便去查区的名字
        }
        else if (type.Equals("shi"))
        {
            string id = context.Request.QueryString["id"];
            context.Response.ContentType = "text/plain";
            context.Response.Write(getqu(id));    
        }
    }

    public string getqu(string shi)
    {
        DataSet ds = KNet.Common.KNet_Static_Province.GetAreaInfo(shi);
        string str = "";
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (i == ds.Tables[0].Rows.Count - 1)
            {
                str += ds.Tables[0].Rows[i]["code"].ToString() + "," + ds.Tables[0].Rows[i]["name"].ToString();
            }
            else 
            {
                str += ds.Tables[0].Rows[i]["code"].ToString() + "," + ds.Tables[0].Rows[i]["name"].ToString() + "|"; 
            }
        }
        return str.Trim(); 
    }
    public string getSheng(string sheng)
    {
        string str = "";
        if (sheng != "")
        {
            DataSet ds = KNet.Common.KNet_Static_Province.GetCityInfo(sheng);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (i == ds.Tables[0].Rows.Count - 1)
                {
                    str += ds.Tables[0].Rows[i]["ID"].ToString() + "," + ds.Tables[0].Rows[i]["name"].ToString();
                }
                else
                {
                    str += ds.Tables[0].Rows[i]["ID"].ToString() + "," + ds.Tables[0].Rows[i]["name"].ToString() + "|";
                }
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