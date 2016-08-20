using System;

public partial class KnetWork_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

            Response.Redirect("../login.aspx");
            Response.End();
    }




}
