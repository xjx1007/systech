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


public partial class Web_Report_Bank : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DateTime datetime = DateTime.Now;
            this.StartDate.Text = datetime.AddDays(1 - datetime.Day).ToShortDateString();
            this.EndDate.Text = datetime.ToShortDateString();

            Base_DdlBankbind(this.Ddl_Account);
            Ddl_Account.SelectedValue = "129780760640657453";
            this.Ddl_Account.Enabled = false;
        }
    }
}
