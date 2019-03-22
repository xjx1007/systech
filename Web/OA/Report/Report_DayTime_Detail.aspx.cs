using KNet.DBUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_OA_Report_Report_DayTime_Detail : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        base.Base_DropDutyPersonByFidOrHR(this.Preson, AM.KNet_StaffNo);
        DateTime datetime = DateTime.Now;
        this.StartDate.Text = datetime.AddDays(1 - datetime.Day).ToShortDateString();
        this.EndDate.Text = datetime.ToShortDateString();
    }
}