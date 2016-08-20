
<%@ WebHandler Language="C#" Class="AllUserXML" %>
using System;
using System.Web;
using System.Web.SessionState;
using System.Data.SqlClient;
using System.Data;

public class AllUserXML : IHttpHandler, IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
        context.Response.Clear();
        context.Response.Buffer = true;
        string s_Return = "<?xml version=\"1.0\" encoding=\"GB2312\"?>\n <TreeNode>\n<TreeNode img_src=\"Web/images/menu/system.gif\" Xml=\"\" text=\"士腾科技\" id=\"0\"> \n", s_Return1 = "";
        string strReceivedID = Convert.ToString(context.Session["KNet_Admin_StaffNo"]);
        BasePage Page = new BasePage();
        string s_Dept = context.Request.QueryString["Dept"] == null ? "" : context.Request.QueryString["Dept"].ToString();
        //先找部门
        if (s_Dept == "")
        {
            string s_Sql = "Select * from KNet_Resource_OrganizationalStructure where STrucPID<>'0'";
            s_Sql += " order by strucpai desc ";
            Page.BeginQuery(s_Sql);
            Page.QueryForDataTable();
            DataTable Dtb_DeptTable = Page.Dtb_Result;
            if (Dtb_DeptTable.Rows.Count > 0)
            {
                for (int j = 0; j < Dtb_DeptTable.Rows.Count; j++)
                {
                    s_Return1 += " <TreeNode  id=\"" + (j + 1).ToString() + "\"  title=\"" + Dtb_DeptTable.Rows[j]["StrucName"].ToString() + "\" img_src=\"web/images/node_dept.gif\" Xml=\"themes/js/attachment/AllUserXML.ashx?Dept=" + Dtb_DeptTable.Rows[j]["STrucValue"].ToString() + "\" text=\"[" + Dtb_DeptTable.Rows[j]["StrucName"].ToString() + "]\" target=\"_self\" href=\"javascript:;\"/>\n ";

                }
            }
        s_Return += s_Return1;
        s_Return += "</TreeNode>\n </TreeNode>";
        }
        else
        {

            Page.BeginQuery("Select * from KNet_Resource_Staff Where  staffDepart='" + s_Dept + "' order by isOnline desc,Position desc ");
            Page.QueryForDataTable();
            DataTable Dtb_Table = Page.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                s_Return1 = " <?xml version=\"1.0\" encoding=\"GB2312\"?> \n<TreeNode>\n";
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
                    s_Return1 += " <TreeNode  id=\"" + Dtb_Table.Rows[i]["StaffNo"].ToString() + "\"  title=\"" + Dtb_Table.Rows[i]["StaffName"].ToString() + "\"   text=\"" + Dtb_Table.Rows[i]["StaffName"].ToString() + "\"  value=\"" + Dtb_Table.Rows[i]["StaffName"].ToString() + "\" op_sms=\"1\" ";
                    if(Dtb_Table.Rows[i]["isOnline"].ToString()=="1")
                    {
                    s_Return1 += " img_src=\"web/images/0-1.gif\" ";
                    }
                    else
                    {
                        
                    s_Return1 += " img_src=\"web/images/0-2.gif\" ";
                    }
                    s_Return1 += "onload=\"RAP('" + Dtb_Table.Rows[i]["StaffName"].ToString() + "');\" target=\"_blank\" href=\"Web/HR/KNet_HR_Manage_Details.aspx?StaffNo=" + Dtb_Table.Rows[i]["StaffNo"].ToString() + "\" />\n ";
                }
                s_Return1 += " </TreeNode>\n";
            }
            s_Return = s_Return1;
        }
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