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

public partial class inc_Default_HomeLeft : BasePage
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        if (AM.CheckLogin() == false)
        {
            Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
            Response.End();
        }
        else
        {
            try
            {
                this.StaffCatalogueDiv.InnerHtml = "<SCRIPT language=javascript>";
                this.StaffCatalogueDiv.InnerHtml += "collapse('g_" + AM.KNet_Soft_StaffCatalogue.ToString() + "')";
                this.StaffCatalogueDiv.InnerHtml += "</SCRIPT>";
            }
            catch
            {
                this.StaffCatalogueDiv.InnerHtml = "<SCRIPT language=javascript>";
                this.StaffCatalogueDiv.InnerHtml += "collapse('g_3')";
                this.StaffCatalogueDiv.InnerHtml += "</SCRIPT>";
            }
        }
    }
}
