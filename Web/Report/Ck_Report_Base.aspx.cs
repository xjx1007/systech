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
public partial class Web_Report_Ck_Report_Base : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        AdminloginMess AM = new AdminloginMess();

        if (AM.CheckLogin("查看库存报表") == false)
        {
            Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
            Response.End();
        }
    }
}
