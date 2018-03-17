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

public partial class Pb_Basic_Notice_View : BasePage
{
    public string  s_OrderStyle = "", s_DetailsStyle = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            this.Tbx_ID.Text = s_ID;
            this.Lbl_Title.Text = "查看公告";
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
        KNet.BLL.Pb_Basic_Notice bll = new KNet.BLL.Pb_Basic_Notice();
        KNet.Model.Pb_Basic_Notice model = bll.GetModel(s_ID);
        this.Tbx_Title.Text = model.PBN_Title;
        this.Ddl_Type.Text = base.Base_GetBasicCodeName("219", model.PBN_Type);
        this.Tbx_ReceiveName.Text = base.Base_GetUserNames(model.PBN_ReceiveID);
        this.Tbx_Remark.Text = KNetPage.KHtmlDiscode(model.PBN_Details);
        try
        {
            this.StartDate.Text = DateTime.Parse(model.PBN_BeginTime.ToString()).ToShortDateString();
        }
        catch { }
        try
        {
            this.EndDate.Text = DateTime.Parse(model.PBN_EndTime.ToString()).ToShortDateString();
        }
        catch { }
    }

}
