using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

using KNet.DBUtility;
using KNet.Common;
using System.Data.SqlClient;
using System.Text;

public partial class Web_Message_Default2 : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("注册页面审批") == false)
            {
                Alert("您无权授权");
            }
            else
            {
                string s_StaffNo = Request.QueryString["StaffNo"] == null ? "" : Request.QueryString["StaffNo"].ToString();
                string s_PageName = Request.QueryString["PageName"] == null ? "" : Request.QueryString["PageName"].ToString();
                string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
                s_PageName = Server.UrlDecode(s_PageName);
                if (s_Type == "0")//同意
                {

                    string s_AuthorityID = "", s_GroupID = "", s_GroupValue = "";
                    //找权限名称 和 模块
                    this.BeginQuery("Select * from KNet_Sys_AuthorityTable where AuthorityName='" + s_PageName + "'");
                    this.QueryForDataTable();
                    if (this.Dtb_Result.Rows.Count > 0)
                    {
                        s_AuthorityID = Dtb_Result.Rows[0][2].ToString();
                        s_GroupValue = Dtb_Result.Rows[0][3].ToString();
                    }
                    //找使用的权限组
                    this.BeginQuery("Select * from KNet_Sys_Authority_AuthList where StaffNo ='" + s_StaffNo + "'");
                    this.QueryForDataTable();
                    if (this.Dtb_Result.Rows.Count > 0)
                    {
                        s_GroupID = Dtb_Result.Rows[0][1].ToString();
                    }
                    if (s_AuthorityID == "")
                    {
                        StringBuilder s = new StringBuilder();
                        s.Append("<script language=javascript>" + "\n");
                        s.Append("alert('未找到该权限值！');\n");
                        s.Append("window.close();\n");
                        s.Append("</script>");
                        Type cstype = this.GetType();
                        ClientScriptManager cs = Page.ClientScript;
                        string csname = "ltype";
                        if (!cs.IsStartupScriptRegistered(cstype, csname))
                            cs.RegisterStartupScript(cstype, csname, s.ToString());
                    }
                    string s_Dosql = "";
                    this.BeginQuery("select * from KNet_Sys_AuthorityUserGroupSetup where AuthorityValue='" + s_AuthorityID + "' and GroupValue='" + s_GroupID + "' and AuthorityGroup='" + s_GroupValue + "'");
                    this.QueryForDataTable();
                    if (this.Dtb_Result.Rows.Count > 0)
                    {
                        StringBuilder s = new StringBuilder();
                        s.Append("<script language=javascript>" + "\n");
                        s.Append("alert('该用户已有该权限！');\n");
                        s.Append("window.close();\n");
                        s.Append("</script>");
                        Type cstype = this.GetType();
                        ClientScriptManager cs = Page.ClientScript;
                        string csname = "ltype";
                        if (!cs.IsStartupScriptRegistered(cstype, csname))
                            cs.RegisterStartupScript(cstype, csname, s.ToString());
                    }
                    else
                    {
                        s_Dosql = "insert into KNet_Sys_AuthorityUserGroupSetup (AuthorityValue,GroupValue,AuthorityGroup) values('" + s_AuthorityID + "','" + s_GroupID + "','" + s_GroupValue + "')";
                        try
                        {
                            DbHelperSQL.ExecuteSql(s_Dosql);
                            base.Base_SendMessage(s_StaffNo, "您申请的 <" + s_PageName + "> 权限 通过审批，你现在可以访问。");
                            StringBuilder s = new StringBuilder();
                            s.Append("<script language=javascript>" + "\n");
                            s.Append("alert('批准成功！');\n");
                            s.Append("window.close();\n");
                            s.Append("</script>");
                            Type cstype = this.GetType();
                            ClientScriptManager cs = Page.ClientScript;
                            string csname = "ltype";
                            if (!cs.IsStartupScriptRegistered(cstype, csname))
                                cs.RegisterStartupScript(cstype, csname, s.ToString());
                        }
                        catch (Exception ex) { }
                    }
                }
                else
                {
                    base.Base_SendMessage(s_StaffNo, "您申请的 <" + s_PageName + "> 权限 未通过审批。");
                    StringBuilder s = new StringBuilder();
                    s.Append("<script language=javascript>" + "\n");
                    s.Append("alert('未批准！');\n");
                    s.Append("window.close();\n");
                    s.Append("</script>");
                    Type cstype = this.GetType();
                    ClientScriptManager cs = Page.ClientScript;
                    string csname = "ltype";
                    if (!cs.IsStartupScriptRegistered(cstype, csname))
                        cs.RegisterStartupScript(cstype, csname, s.ToString());
                }
 
            }
           
        }
    }
}