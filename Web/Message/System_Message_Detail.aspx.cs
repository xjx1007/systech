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

public partial class System_Message_Detail : BasePage
{
    public string  s_OrderStyle = "", s_DetailsStyle = "";

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
            this.Get_System_Message_ByID();
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            if (s_Type == "1")
            {
                s_OrderStyle = "class=\"dvtUnSelectedCell\"";
                s_DetailsStyle = "class=\"dvtSelectedCell\"";
                Pan_Order.Visible = false;
                Pan_Detail.Visible = true;
                Table_Btn.Visible = false;
            }
            else
            {
                s_DetailsStyle = "class=\"dvtUnSelectedCell\"";
                s_OrderStyle = "class=\"dvtSelectedCell\"";
                Pan_Order.Visible = true;
                Pan_Detail.Visible = false;
                Table_Btn.Visible = true;
            }
            try
            {
                KNet.BLL.System_Message_Manage Bll = new KNet.BLL.System_Message_Manage();
                KNet.Model.System_Message_Manage Model = new KNet.Model.System_Message_Manage();
                KNet.Model.System_Message_Manage Model_Details =Bll.GetModel(s_ID);
                //先更新查看状态
                Model.SMM_ID = s_ID;
                Model.SMM_State = 1;
                Model.SMM_LookTime = DateTime.Now;
                if (Model_Details.SMM_ReceiveID == AM.KNet_StaffNo)
                {
                    Bll.UpdateState(Model);
                }
                this.Tbx_ReceiveID.Text = Model_Details.SMM_SenderID;
                this.Tbx_ReceiveName.Text = base.Base_GetUserName(Model_Details.SMM_SenderID);
                this.Tbx_Title.Text = "回复：" + Model_Details.SMM_Title;
              // this.Tbx_Title2.Text = Model_Details.SMM_Title + "(" + Model_Details.SMM_Detail + ")";
                this.Tbx_Remark.Text = ">"+Model_Details.SMM_Detail+"\n";
            }
            catch
            { }
        }

    }

    protected void Get_System_Message_ByID()
    {
        KNet.BLL.System_Message_Manage BLL = new KNet.BLL.System_Message_Manage();
        if (Request["ID"] != null)
        {
            string MyID = Request.QueryString["ID"].ToString().Trim();
            if (MyID != "")
            {
                KNet.Model.System_Message_Manage model = BLL.GetModel(MyID);

                this.Tbx_SenderID.Text = model.SMM_SenderID.ToString();
                this.Tbx_SenderName.Text = GetSenderName(model.SMM_SenderID);
                this.Tbx_Title1.Text = model.SMM_Title;
                this.Tbx_Detail.Text = model.SMM_Detail;
                this.Tbx_SendTime.Text = model.SMM_SendTime.ToString();
            }
            else
            {
                Response.Write("<script language=javascript>alert('非法参数！');window.close()</script>");
                Response.End();
            }
        }
        else
        {
            Response.Write("<script language=javascript>alert('非法参数！');window.close()</script>");
            Response.End();
        }
    }

    /// <summary>
    /// 获取发送者 姓名
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetSenderName(object SenderID)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,StaffNo,StaffCard,StaffName from KNet_Resource_Staff where StaffNo='" + SenderID + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["StaffName"].ToString().Trim();
            }
            else
            {
                return "--";
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
                model.SMM_Del = 0;
                model.SMM_ReceiveID = s_ReceiveId[i];
                model.SMM_SenderID = s_SendId;
                model.SMM_State = 0;
                model.SMM_Detail = s_Detail;
                model.SMM_Title = s_Title;
                model.SMM_SendTime = DateTime.Now;
                model.SMM_LookTime = null;
                BLL.Add(model);
            }
            AdminloginMess LogAM = new AdminloginMess();
            LogAM.Add_Logs("系统设置--->短消息--->短消息 发送 操作成功！名称：" + this.Tbx_ReceiveName.Text);
            string s = "<script language=javascript>" + "\n";
            s += "alert('发送成功！');" + "\n";
            s += "window.opener.location.reload();window.close();" + "\n";
            s += "</script>";
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            string csname = "ltype";
            if (!cs.IsStartupScriptRegistered(cstype, csname))
                cs.RegisterStartupScript(cstype, csname, s.ToString());
        }
        catch
        {
            Response.Write("<script>alert('消息发送失败1！');history.back(-1);</script>");
            Response.End();
        }

    }
}
