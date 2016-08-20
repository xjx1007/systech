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


public partial class Cw_Accounting_Payment_Add : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
        }
    }

    private void ShowInfo(string s_ID,string s_Code)
    {
        KNet.BLL.Cw_Accounting_Payment bll = new KNet.BLL.Cw_Accounting_Payment();

    }
    private bool SetValue(KNet.Model.Cw_Accounting_Payment model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            return true;
        }
        catch
        {
            return false;
        }
       
    }

    protected void Btn_SaveOnClick(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.Model.Cw_Accounting_Payment model = new KNet.Model.Cw_Accounting_Payment();
        KNet.BLL.Cw_Accounting_Payment bll = new KNet.BLL.Cw_Accounting_Payment();

        if (this.SetValue(model) == false)
        {
            Alert("系统错误！");
            return;
        }
        if ((this.Tbx_ID1.Text != "")&&(this.Tbx_Code1.Text!=""))//修改
        {
            try
            {
                bll.Update(model);
                AM.Add_Logs("付款计划修改" + this.Tbx_ID.Text);
                AlertAndRedirect("修改成功！", "Cw_Accounting_Payment_List.aspx");
            }
            catch { }
        }
        else
        {

            try
            {
                bll.Add(model);
                AM.Add_Logs("付款计划增加" + this.Tbx_ID.Text);
                AlertAndRedirect("新增成功！", "Cw_Accounting_Payment_List.aspx");
            }
            catch { }
        }
    }
}
