
<%@ WebHandler Language="C#" Class="UserOnline" %>
using System;
using System.Web;
using System.Web.SessionState;
using System.Data.SqlClient;
using System.Data;

public class UserOnline : IHttpHandler, IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
        context.Response.Clear();
        context.Response.Buffer = true;
        string s_Return = "+OK ", s_Return1 = "", s_Return2 = "";
        int i_Online = 0,i_HasPerson=0;
        string strReceivedID = Convert.ToString(context.Session["KNet_Admin_StaffNo"]);
        BasePage Page = new BasePage();
        
        //先找部门
        
        Page.BeginQuery("Select * from KNet_Resource_OrganizationalStructure where STrucPID<>'0' order by strucpai desc ");
        Page.QueryForDataTable();
        DataTable Dtb_DeptTable = Page.Dtb_Result;
        
        if (Dtb_DeptTable.Rows.Count > 0)
        {
            for (int j = 0; j < Dtb_DeptTable.Rows.Count; j++)
            {
                Page.BeginQuery("Select * from KNet_Resource_Staff Where isOnline='1' and staffDepart='" + Dtb_DeptTable.Rows[j]["StrucValue"].ToString() + "' ");
                Page.QueryForDataTable();
                DataTable Dtb_Table = Page.Dtb_Result;
                if (Dtb_Table.Rows.Count > 0)
                {
                    for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                    {
                        s_Return1 += "tree.nodes['" + (j + 1).ToString() + ",_" + Dtb_Table.Rows[i]["StaffNo"].ToString() + "']=";
                        s_Return1 +="'text:" + Dtb_Table.Rows[i]["StaffName"].ToString() + ";icon:U01;url:javascript:view_user(\""+Dtb_Table.Rows[i]["StaffNo"].ToString()+"\");exclude:0;';";
    
                       // s_Return1 += "D[" + i.ToString() + "]=[\"" + j.ToString() + "\",\"" + Dtb_DeptTable.Rows[j]["StrucName"].ToString() + "\",\"" + Dtb_DeptTable.Rows[j]["StrucName"].ToString() + "\",[]];D[" + i.ToString() + "][" + j.ToString() + "][" + i.ToString() + "]=[\"" + Dtb_Table.Rows[i]["StaffCard"].ToString() + "\",\"" + Dtb_Table.Rows[i]["StaffName"].ToString() + "\",\"U01\"," + i.ToString() + "];";
                        i_Online++;
                        i_HasPerson++;
                    }
                }
                if (i_HasPerson != 0)
                {
                    s_Return2 += "tree.nodes['TDOA," + (j+1).ToString() + "']='type:1;text:[" + Dtb_DeptTable.Rows[j]["StrucName"].ToString() + "];';";
                    i_HasPerson = 0;
                }
            }
        }

        context.Response.Write(s_Return + i_Online.ToString() + ":" + s_Return1 + s_Return2);
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