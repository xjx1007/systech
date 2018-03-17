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

public partial class PB_Basic_Menu_View : BasePage
{
    public string  s_OrderStyle = "", s_DetailsStyle = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            this.Lbl_Title.Text = "查看菜单";
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            try
            {
                ShowInfo(s_ID);
            }
            catch
            { }
        }

    }

    private void ShowInfo(string s_ID)
    {
        KNet.BLL.PB_Basic_Mail bll = new KNet.BLL.PB_Basic_Mail();
        KNet.Model.PB_Basic_Mail model = bll.GetModel(s_ID);
        this.Lbl_SendEmail.Text = model.PBM_SendEmail.ToString();
        this.Lbl_ReceiveEmail.Text = model.PBM_ReceiveEmail.ToString();
        this.Lbl_Text.Text = KNetPage.KHtmlDiscode(model.PBM_Text.ToString());
        if (model.PBM_File != "")
        {
            this.Lbl_File.Text = "<a href=\"" + model.PBM_File + "\">附件" + model.PBM_File.Substring(model.PBM_File.Length - 4, 4) + "</a>";
        }
        this.Lbl_Title1.Text = model.PBM_Title.ToString();
        this.Lbl_Cc.Text = model.PBM_Cc.ToString();
        this.Lbl_Ms.Text = model.PBM_Ms.ToString();
        if (model.PBM_State == 1)
        {
            this.Lbl_State.Text = "<Font color=blue>成功</font>";
        }
        else
        {
            this.Lbl_State.Text = "<Font color=red>失败</font>";
        }
        this.Lbl_Creator.Text = base.Base_GetUserName(model.PBM_Creator.ToString());
        this.Lbl_CTime.Text = model.PBM_CTime.ToString();
    }

}
