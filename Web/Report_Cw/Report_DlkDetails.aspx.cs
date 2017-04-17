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

using System.Data.SqlClient;

using KNet.DBUtility;
using KNet.Common;
public partial class Web_Report_Xs_Report_CkDetails : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            base.Base_DropKClaaBind(this.Tbx_CustomerTypes, 2, "", "请选择客户类型");
            DateTime datetime = DateTime.Now;
            this.StartDate.Text = datetime.AddDays(1 - datetime.Day).ToShortDateString();
            this.EndDate.Text = datetime.ToShortDateString();
            this.Tbx_CustomerTypes.SelectedValue = "129726189973212926";
            this.Tbx_CustomerName.Text = "广州市候华网络维护有限公司";
            this.Tbx_CustomerValue.Text = "104521";
            this.Tbx_ProductsTypeNo.Text = "01";
            this.Tbx_ProductsTypeName.Text = "成品 (0101)";
        }
    }
}
