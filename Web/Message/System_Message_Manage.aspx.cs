using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using KNet.DBUtility;
using KNet.Common;
using System.Data.SqlClient;
using System.Text;

public partial class System_Message_Manage : BasePage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            string s_To_ID = Request.QueryString["To_ID"] == null ? "" : Request.QueryString["To_ID"].ToString();
            string s_AuthorityName = Request.QueryString["AuthorityName"] == null ? "" : Request.QueryString["AuthorityName"].ToString();
            if (s_AuthorityName != "")
            {
                s_To_ID = "129785817148286974";
                this.Tbx_Title.Text = base.Base_GeDept(AM.KNet_StaffDepart)+"-"+AM.KNet_StaffName + " 申请 <" + s_AuthorityName + ">权限";
                this.Tbx_Remark.Text = this.Tbx_Title.Text + "   <br><hr><a target=\"_blank\" href=\"/Web/Message/System_Message_Sh.aspx?StaffNo=" + AM.KNet_StaffNo + "&PageName=" + Server.UrlEncode(s_AuthorityName) + "&Type=0\" onclick=\"RemoveSms('#ID', '', 0);\">同意</a>   <a target=\"_blank\" href=\"/Web/Message/System_Message_Sh.aspx?StaffNo=" + AM.KNet_StaffNo + "&PageName=" + Server.UrlEncode(s_AuthorityName) + "&Type=1\"  onclick=\"RemoveSms('#ID', '', 0);\">不同意</a>";
            }
            this.Tbx_ToID.Text = s_To_ID;
            KNet.BLL.KNet_Resource_Staff BLL = new KNet.BLL.KNet_Resource_Staff();

            if (s_To_ID != "")
            {
                DataSet Dts_Table = BLL.GetList("StaffNo='" + s_To_ID + "'");
                if (Dts_Table.Tables[0].Rows.Count > 0)
                {
                    this.Tbx_ReceiveID.Text = Dts_Table.Tables[0].Rows[0]["StaffNo"].ToString();
                    this.Tbx_ReceiveName.Text = Dts_Table.Tables[0].Rows[0]["StaffName"].ToString();
                }
            }
        }

    }

    protected void Btn_Send_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        string[] s_ReceiveId = this.Tbx_ReceiveID.Text.Trim().Split(',');
        string s_Detail = this.Tbx_Remark.Text.Trim();
        string s_SendId = AM.KNet_StaffNo;
        string s_Title = this.Tbx_Title.Text;
        try
        {
            for (int i = 0; i < s_ReceiveId.Length; i++)
            {
                KNet.BLL.System_Message_Manage BLL = new KNet.BLL.System_Message_Manage();
                KNet.Model.System_Message_Manage model = new KNet.Model.System_Message_Manage();
                model.SMM_ID = base.GetNewID("System_Message_Manage", 1);
                model.SMM_Del = 0;
                model.SMM_ReceiveID = s_ReceiveId[i];
                model.SMM_SenderID = s_SendId;
                model.SMM_State = 0;
                model.SMM_Detail = KNetPage.KHtmlEncode(s_Detail.Replace("#ID", model.SMM_ID).Replace("#ID", model.SMM_ID));
                model.SMM_Title = s_Title;
                model.SMM_SendTime = DateTime.Now;
                model.SMM_LookTime = null;
                model.SMM_Type = "0";
                BLL.Add(model);
            }
            AdminloginMess LogAM = new AdminloginMess();
            LogAM.Add_Logs("系统设置--->短消息--->短消息 发送 操作成功！名称：" + this.Tbx_ReceiveName.Text);
            if (this.Tbx_ToID.Text != "")
            {
                StringBuilder s = new StringBuilder();
                s.Append("<script language=javascript>" + "\n");
                s.Append("alert('发送成功！');\n");
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
                AlertAndRedirect("发送成功！", "System_Message_List.aspx?Type=unread");
            }
        }
        catch
        {
            Response.Write("<script>alert('消息发送失败1！');history.back(-1);</script>");
            Response.End();
        }

    }
}
