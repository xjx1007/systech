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

public partial class System_PhoneMessage_Manage : BasePage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("短消息发送") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            string s_To_ID = Request.QueryString["To_ID"] == null ? "" : Request.QueryString["To_ID"].ToString();
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
        string s_ReceiveId = this.Tbx_ReceiveID.Text.Trim();
        string s_ReceiveName = this.Tbx_ReceiveName.Text.Trim();
        string s_ReceivePhone = this.Tbx_ReceivePhone.Text.Trim();
        string s_Detail = this.Tbx_Remark.Text.Trim();
        string s_SendId = AM.KNet_StaffNo;
        if (s_Detail == "")
        {
            Alert("短信内容不能为空");
            return;
        }
        else if (s_ReceivePhone == "")
        {
            Alert("手机号码不能为空");
            return;
        }
        else if (s_Detail.Length > 65)
        {
            Alert("短信内容不能超过65个字");
            return;
        }
        try
        {
            KNet.BLL.System_PhoneMessage_Manage BLL = new KNet.BLL.System_PhoneMessage_Manage();
            KNet.Model.System_PhoneMessage_Manage model = new KNet.Model.System_PhoneMessage_Manage();
            model.SPM_ID = base.GetMainID();
            model.SPM_Del = 0;
            model.SPM_ReceiveID = s_ReceiveId;
            model.SPM_ReceiveName = s_ReceiveName;
            model.SPM_ReceivePhone = s_ReceivePhone;
            model.SPM_SenderID = s_SendId;
            model.SPM_State = 0;
            model.SPM_Detail = KNetPage.KHtmlEncode(s_Detail);
            model.SPM_SendTime = DateTime.Now;
            model.SPM_Type = 0;
            AdminloginMess LogAM = new AdminloginMess();
            LogAM.Add_Logs("系统设置--->短消息--->短消息 发送 操作成功！名称：" + this.Tbx_ReceiveName.Text);
            BLL.Add(model);
            string s_Return = "";
            Message Message = new Message();
            try
            {
                string[] s_ReceiveID=s_ReceivePhone.Split(',');
                if (s_ReceiveID.Length > 0)
                {
                    for (int i = 0; i < s_ReceiveID.Length; i++)
                    {
                        s_Return = Message.SendMessage(s_ReceiveID[i], s_Detail);
                    }
                }
                else
                {
                    s_Return = Message.SendMessage(s_ReceivePhone, s_Detail);
                }
                AlertAndRedirect("发送成功！", "System_PhoneMessage_List.aspx");
            }
            catch(Exception ex)
            {
                AlertAndRedirect("短信发送失败！"+ex.Message, "System_PhoneMessage_List.aspx");
            }
            //StringBuilder s = new StringBuilder();
            //s.Append("<script language=javascript>" + "\n");
            //s.Append("alert('发送成功！');\n");
            //s.Append("window.close();\n");
            //s.Append("</script>");
            //Type cstype = this.GetType();
            //ClientScriptManager cs = Page.ClientScript;
            //string csname = "ltype";
            //if (!cs.IsStartupScriptRegistered(cstype, csname))
            //    cs.RegisterStartupScript(cstype, csname, s.ToString());

        }
        catch
        {
            Response.Write("<script>alert('消息发送失败1！');history.back(-1);</script>");
            Response.End();
        }

    }
}
