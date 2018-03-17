
<%@ WebHandler Language="C#" Class="GetMessage" %>
using System;
using System.Web;
using System.Text;
using System.Web.SessionState;
using System.Data.SqlClient;
using System.Data;
using KNet.Common;

public class GetMessage : IHttpHandler, IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
        context.Response.Clear();
        context.Response.Buffer = true;
        StringBuilder s_Return =new StringBuilder();
        StringBuilder s_Return1 = new StringBuilder();
        StringBuilder s_Return2 = new StringBuilder();
        string strReceivedID = Convert.ToString(context.Session["KNet_Admin_StaffNo"]);
        BasePage Page = new BasePage();
        KNet.BLL.System_Message_Manage Bll=new KNet.BLL.System_Message_Manage();
        DataSet Dts_Table = Bll.GetList(" SMM_ReceiveID='" + strReceivedID + "' and  SMM_Del=0  and SMM_UnRead=1 Order by SMM_SendTime ");//未读信息

        s_Return1.Append("[");
        if (Dts_Table.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
            {
                s_Return.Append("{");
                s_Return.Append("sms_id:\"" + Dts_Table.Tables[0].Rows[i]["SMM_ID"].ToString() + "\",");
                s_Return.Append("to_id:\"" + Dts_Table.Tables[0].Rows[i]["SMM_ReceiveID"].ToString() + "\",");
                s_Return.Append("from_id:\"" + Dts_Table.Tables[0].Rows[i]["SMM_SenderID"].ToString() + "\",");
                s_Return.Append("from_name:\"" + Page.Base_GetUserName(Dts_Table.Tables[0].Rows[i]["SMM_SenderID"].ToString()) + "\",");
                s_Return.Append("type_id:\"" + Dts_Table.Tables[0].Rows[i]["SMM_Type"].ToString() + "\",");
                s_Return.Append("type_name:\"" + Page.Base_GetBasicCodeName("147", Dts_Table.Tables[0].Rows[i]["SMM_Type"].ToString()) + "\",");
                s_Return.Append("send_time:\"" + DateTime.Parse(Dts_Table.Tables[0].Rows[i]["SMM_SendTime"].ToString()).Hour + ":" + DateTime.Parse(Dts_Table.Tables[0].Rows[i]["SMM_SendTime"].ToString()).Minute + "\",");
                s_Return.Append("unread:\"" + Dts_Table.Tables[0].Rows[i]["SMM_UnRead"].ToString() + "\",");
                s_Return.Append("content:\"" + KHtmlDiscode1(KNetPage.KHtmlDiscode(Dts_Table.Tables[0].Rows[i]["SMM_Detail"].ToString())) + "\",");
                s_Return.Append("url:\"Web/Message/System_Message_List.aspx?Type=inbox\",");
                s_Return.Append("receive:\"" + Dts_Table.Tables[0].Rows[i]["SMM_Receive"].ToString() + "\"");
                s_Return.Append("},");
            }
            s_Return1.Append(s_Return.ToString().Substring(0, s_Return.ToString().Length - 1));
        } 
        s_Return2.Append(s_Return1.ToString() + "]");

        context.Response.Write(s_Return2.ToString()); 
        context.Response.Flush();
        context.Response.End();
    }
    public  string KHtmlDiscode1(string theString)
    {
        if (theString != null)
        {
            theString = theString.Replace("\"", "\\\"");

        }
        return theString;

    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}