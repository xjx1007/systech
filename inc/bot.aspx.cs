using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using KNet.DBUtility;
using KNet.Common;
public partial class Bot_bot : BasePage
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        AdminloginMess AMLanguage = new AdminloginMess();
        if (AMLanguage.KNet_Soft_StaffLanguage == 2)
        {
            // 1、默认为简体转繁体，编码为utf-8
            Response.Filter = new LU.Web.ChineseConvertor(Response.Filter);
        }
        else if (AMLanguage.KNet_Soft_StaffLanguage == 1)
        {
            // 2、繁体简体转，编码为utf-8
            Response.Filter = new LU.Web.ChineseConvertor(Response.Filter, LU.Web.ChineseConvertor.CCDirection.T2S);
        }
        else
        { }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(Bot_bot));
        if (!IsPostBack)
        {
            AdminloginMess AMbot = new AdminloginMess();
            this.HouseName.Text = AMbot.KNet_StaffName;
            this.LoginNum.Text = AMbot.KNet_Staff_LoginNum.ToString();
            this.LastLoginDate.Text = DateTime.Parse(AMbot.KNet_Last_Staff_LoginDate.ToString()).ToString();
            this.LogIP.Text = AMbot.KNet_Last_Staff_LoginIP;
            this.LogIPLast.Text = AMbot.KNet_this_Staff_LoginIP;

            if (AMbot.KNet_StaffBranch != null && AMbot.KNet_StaffBranch != "")
            {
                if (AMbot.KNet_StaffDepart != null && AMbot.KNet_StaffDepart != "")
                {
                    this.CompanyName.Text = base.Base_GeDept(AMbot.KNet_StaffBranch) + "(" + base.Base_GeDept(AMbot.KNet_StaffDepart) + ")";
                }
                else
                {
                    this.CompanyName.Text = base.Base_GeDept(AMbot.KNet_StaffBranch);
                }
            }
            else
            {
                this.CompanyName.Text = AMbot.KNet_Sys_CompanyName;
            }

            this.BeginQuery("Select * From System_Message_Manage where SMM_ReceiveId='" + AMbot.KNet_StaffNo + "' and SMM_Del=0 and SMM_State=0");
            DataTable Dtb_Table = this.QueryForDataTable(); 
            if (Dtb_Table.Rows.Count > 0)
            {

            }
        }

    }
    [Ajax.AjaxMethod()]
    public string GetMessage()
    {
        AdminloginMess AMbot = new AdminloginMess();
        KNet.BLL.System_Message_Manage bll = new KNet.BLL.System_Message_Manage();
        KNet.Model.System_Message_Manage Model = new KNet.Model.System_Message_Manage();
        Model.SMM_ReceiveID = AMbot.KNet_StaffNo;
        Model.SMM_Del = 0;
        Model.SMM_State = 0;
        if (bll.Exists(Model))//如果有未读消息
        {
            return "1";
        }
        else
        {
            return "0";
        }
    }
}