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
            this.Tbx_ID.Text = s_ID;
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
        KNet.BLL.PB_Basic_Menu bll = new KNet.BLL.PB_Basic_Menu();
        KNet.Model.PB_Basic_Menu model = bll.GetModel(s_ID);
        this.Tbx_Name.Text = model.PBM_Name;
        this.PBM_Module.Text = model.PBM_Module;
        this.PBM_Parenttab.Text = model.PBM_Parenttab;
        this.PBM_URL.Text = model.PBM_URL;


        KNet.Model.PB_Basic_Menu model1 = bll.GetModel(model.PBM_FatherID);
        this.Lbl_FID.Text = model1.PBM_Name;
    }

}
