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
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Data.SqlClient;

using KNet.DBUtility;
using KNet.Common;


/// <summary>
///  人力资源 -----考勤管理添加 
/// </summary>
public partial class KNet_AttenDance_OutManger_Report_Add : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            else
            {
                this.StartDateTime.Text = DateTime.Now.AddDays(1 - DateTime.Now.Day).ToShortDateString();
                this.EndDatetime.Text = DateTime.Now.ToShortDateString();
                base.Base_DropDepart(this.Ddl_Dept);
                base.Base_DropDutyPerson(this.Ddl_DutyPerson);

            }
        }

    }

    /// <summary>
    /// 提交申请
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        OpenWebFormSize("KNet_AttenDance_OutManger_List_View.aspx?StartDate=" + this.StartDateTime.Text + "&EndDate=" + this.EndDatetime.Text + "&Dept=" + this.Ddl_Dept.SelectedValue + "&DutyPerson=" + this.Ddl_DutyPerson.SelectedValue + "", 800, 600, 100, 100);
    }

}
