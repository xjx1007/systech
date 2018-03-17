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


public partial class Web_Report_Xs_Report_XsDetails : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            base.Base_DropKClaaBind(this.Tbx_CustomerTypes, 2, "", "请选择客户类型");
            DateTime datetime = DateTime.Now;
            this.StartDate.Text = datetime.AddDays(1 - datetime.Day).ToShortDateString();
            this.EndDate.Text = datetime.ToShortDateString();
        }

    }

    protected void Btn_Query_Click(object sender, EventArgs e)
    {
        OpenWebFormSize("List_ShipList.aspx?StartDate=" + this.StartDate.Text + "&EndDate=" + this.EndDate.Text + "&CustomerName=" + this.Tbx_CustomerName.Text + "&ProductsType=" + this.Tbx_Type.Text + "&CustomerTypes=" + this.Tbx_CustomerTypes.SelectedValue, 800, 600, 100, 100);
    }
}
