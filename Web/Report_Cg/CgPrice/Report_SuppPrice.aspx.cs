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

public partial class Web_Report_Xs_Report_CkDetails : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DateTime datetime = DateTime.Now;
        this.StartDate.Text = datetime.Year + "-" + "1" + "-" + "1";
        this.EndDate.Text = datetime.ToShortDateString();
    }
}
