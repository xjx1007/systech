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

public partial class top_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminloginMess AMLanguage = new AdminloginMess();
        if (AMLanguage.KNet_Soft_StaffLanguage == 2)
        {
            Response.Filter = new LU.Web.ChineseConvertor(Response.Filter);
            this.toplogo.ImageUrl = "../images/toplogo2.jpg";
        }
        else if (AMLanguage.KNet_Soft_StaffLanguage == 1)
        {

            Response.Filter = new LU.Web.ChineseConvertor(Response.Filter, LU.Web.ChineseConvertor.CCDirection.T2S);
            this.toplogo.ImageUrl = "../images/toplogo2.jpg";
        }
        else
        { this.toplogo.ImageUrl = "../images/toplogo2.jpg"; }
    }

}


