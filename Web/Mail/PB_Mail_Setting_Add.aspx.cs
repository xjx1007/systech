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

public partial class PB_Mail_Setting_Add : BasePage
{
    public string s_PassWord = "";

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
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            this.Tbx_ID.Text = s_ID;
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            this.Tbx_Type.Text = s_Type;
            if (s_ID != "")
            {
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制发件人";
                }
                else
                {
                    this.Lbl_Title.Text = "修改发件人";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }
            else
            {
                this.Lbl_Title.Text = "新增发件人";
            }
        }

    }
    private void ShowInfo(string s_ID)
    {
        KNet.BLL.PB_Mail_Setting bll = new KNet.BLL.PB_Mail_Setting();
        KNet.Model.PB_Mail_Setting model = bll.GetModel(s_ID);
        if (model != null)
        {
            this.Tbx_ID.Text = model.PMS_ID.ToString();
            this.Tbx_Sever.Text = model.PMS_Sever.ToString();
            this.Tbx_Port.Text = model.PMS_Port.ToString();
            this.Tbx_Email.Text = model.PMS_Email.ToString();
            this.Tbx_Password.Text = model.PMS_Password.ToString();
            if (model.PMS_Verification == 0)
            {
                this.Chk_Verification.Checked = false;
            }
            else
            {
                this.Chk_Verification.Checked = true;
            }
            this.Tbx_SendEmail.Text = model.PMS_SendEmail.ToString();
            this.Tbx_SendPerson.Text = model.PMS_SendPerson.ToString();
            this.Tbx_Seconds.Text = model.PMS_Seconds.ToString();
        }
    }

    private bool SetValue(KNet.Model.PB_Mail_Setting model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text == "")
            {
                model.PMS_ID = GetMainID();
            }
            else
            {
                model.PMS_ID = this.Tbx_ID.Text;
            }
            model.PMS_Sever = this.Tbx_Sever.Text;
            model.PMS_Port = this.Tbx_Port.Text.ToString();
            model.PMS_Email = this.Tbx_Email.Text.ToString();
            model.PMS_Password = this.Tbx_Password.Text.ToString();
            if (Chk_Verification.Checked)
            {
                model.PMS_Verification = 1;
            }
            else
            {
                model.PMS_Verification = 0;
            }
            model.PMS_SendEmail = this.Tbx_SendEmail.Text.ToString();
            model.PMS_SendPerson = this.Tbx_SendPerson.Text.ToString();
            model.PMS_Seconds = int.Parse(this.Tbx_Seconds.Text.ToString());
            model.PMS_Creator = AM.KNet_StaffNo;
            model.PMS_CTime = DateTime.Now;
            model.PMS_Mender = AM.KNet_StaffNo;
            model.PMS_MTime = DateTime.Now;

            return true;
        }
        catch
        {
            return false;
        }


    }
    protected void Btn_Send_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.Model.PB_Mail_Setting model = new KNet.Model.PB_Mail_Setting();
        KNet.BLL.PB_Mail_Setting bll = new KNet.BLL.PB_Mail_Setting();

        if (this.SetValue(model) == false)
        {
            Alert("系统错误！");
            return;
        }
        if (this.Tbx_ID.Text != "")//修改
        {
            try
            {
                if (bll.Update(model))
                {
                    AM.Add_Logs("发件人修改" + this.Tbx_ID.Text);
                  //  base.Base_SendMessage(model.PBM_ID, "发件人： <a href='Web/Notice/PB_Mail_Setting_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PBM_ID + "</a> ");
                    AlertAndRedirect("修改成功！", "PB_Mail_Setting_List.aspx");
                }
                else
                {
                    AM.Add_Logs("发件人修改失败" + this.Tbx_ID.Text);
                    AlertAndRedirect("修改失败！", "PB_Mail_Setting_Add.aspx?ID=" + this.Tbx_ID.Text + "");
                }
            }
            catch { }
        }
        else
        {
            try
            {
                bll.Add(model);
               // base.Base_SendMessage(model.PBN_ReceiveID, "发件人： <a href='Web/Notice/PB_Mail_Setting_View.aspx?ID=" + model.PBN_ID + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PBN_Title + "</a> ");
                AM.Add_Logs("发件人增加:" + model.PMS_ID);
                AlertAndRedirect("新增成功！", "PB_Mail_Setting_List.aspx");
            }
            catch { }
        }
    }
}
