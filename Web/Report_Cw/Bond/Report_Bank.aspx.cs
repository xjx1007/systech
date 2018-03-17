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

            KNet.BLL.KNet_Sys_Bank bll = new KNet.BLL.KNet_Sys_Bank();
            DataSet ds = bll.GetList(" BankNo not in ('129780760640657453','129780760640657412')");
            Ddl_Account.DataSource = ds;
            Ddl_Account.DataTextField = "AA";
            Ddl_Account.DataValueField = "BankNo";
            Ddl_Account.DataBind();
            ListItem item = new ListItem("请选择银行（账号）", ""); //默认值
            Ddl_Account.Items.Insert(0, item);
            Ddl_Account.SelectedValue = "129780760640657452";
            base.Base_DropBasicCodeBind(this.Ddl_Type, "766");
            base.Base_DropBasicCodeBind(this.Ddl_Type1, "767");
        }
    }
}
