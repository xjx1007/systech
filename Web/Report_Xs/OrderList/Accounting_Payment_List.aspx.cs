using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Report_Xs_OrderList_Accounting_Payment_List : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            base.Base_DropDutyPerson(this.Ddl_DutyPerson, false);
            base.Base_DropKClaaBind(this.Tbx_CustomerTypes, 2, "", "请选择客户类型");
            DateTime datetime = DateTime.Now;
            //this.StartDate.Text = datetime.AddDays(1 - datetime.Day).ToShortDateString();
            //   this.EndDate.Text = datetime.ToShortDateString();
        }
    }
}