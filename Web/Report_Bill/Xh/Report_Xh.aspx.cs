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


public partial class Web_Report_Xh : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DateTime datetime = DateTime.Now;
            this.StartDate.Text = datetime.AddDays(1 - datetime.Day).ToShortDateString();
            this.EndDate.Text = datetime.ToShortDateString();
            base.Base_DropWareHouseBind(this.HouseNo, " KSW_Type='0'");
            this.Base_DropBasicCodeBind(this.Ddl_Type, "205", false);
        }
    }

    protected void Btn_Query_Click(object sender, EventArgs e)
    {
        OpenWebFormSize("Procure_Xh_View.aspx?Type="+this.Ddl_Type.SelectedValue+"&StartDate=" + this.StartDate.Text + "&EndDate=" + this.EndDate.Text + "&SuppNo=" + this.HouseNo.SelectedValue + "&ProductsEdition=" + this.Tbx_ProductsEdition.Text, 800, 600, 100, 100);
    }
}
