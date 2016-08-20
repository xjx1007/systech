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
using System.IO;
using System.Text;
using System.Data.SqlClient;

using KNet.DBUtility;
using KNet.Common;


public partial class Web_Report_CustomerPayTime : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }

    protected void Btn_Query_Click(object sender, EventArgs e)
    {
        OpenWebFormSize("List_CustomerPayTime.aspx?CustomerName=" + this.Tbx_Customer.Text, 800, 600, 100, 100);
    }
}
