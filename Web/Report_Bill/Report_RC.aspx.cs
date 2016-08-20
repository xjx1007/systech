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


public partial class Web_Report_RC : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DateTime datetime = DateTime.Now;
            this.StartDate.Text = datetime.AddDays(1 - datetime.Day).ToShortDateString();
            this.EndDate.Text = datetime.ToShortDateString();
            base.Base_DropWareHouseBind(this.HouseNo, "1=1");
        }
    }
    protected void Btn_Query_Click(object sender, EventArgs e)
    {
        OpenWebFormSize("Procure_Rc_View.aspx?StartDate=" + this.StartDate.Text + "&EndDate=" + this.EndDate.Text + "&SuppNo=" + this.HouseNo.SelectedValue + "&ProductsEdition=" + this.Tbx_ProductsEdition.Text, 800, 600, 100, 100);
    }
}
