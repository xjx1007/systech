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
public partial class Web_Report_Xs_Report_CkDetails2 : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            base.Base_DropKClaaBind(this.Tbx_CustomerTypes, 2, "", "请选择客户类型");
            DateTime datetime = DateTime.Now;
            this.StartDate.Text = datetime.AddDays(1 - datetime.Day).ToShortDateString();
            string id = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            this.TextBox1.Text = id;
            if (id=="01")
            {
                Label1.Text = "成品领料明细";
            }
            else
            {
                Label1.Text = "原材料领料明细";
            }
            this.EndDate.Text = datetime.ToShortDateString();
            this.Tbx_ProductsTypeName.Text = "销售类产品 (01)";
            this.Tbx_ProductsTypeNo.Text = "M160818111359632";
        }
    }

}
