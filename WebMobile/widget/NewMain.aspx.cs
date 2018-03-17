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


public partial class Knetwork_Admin_NewMain : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminloginMess AM=new AdminloginMess();
        this.Lbl_User.Text = AM.KNet_StaffName + "(" + base.Base_GeDept(AM.KNet_StaffDepart) + ")";
        this.Lbl_Companyname.Text = "士腾科技";

    }

}
