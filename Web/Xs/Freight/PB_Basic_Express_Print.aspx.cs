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

using KNet.DBUtility;
using KNet.Common;

public partial class Web_PB_Basic_Express_Print : BasePage
{
    public string s_ID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(Web_PB_Basic_Express_Print));
        if (!IsPostBack)
        {
            AdminloginMess AM=new AdminloginMess();
            if (AM.CheckLogin()==false)
            {
                
            }
            s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();

           // s_Account = base.Base_GetBankName(Model.XTC_Account.ToString());
        }
    }

    [Ajax.AjaxMethod()]
    public string GetDetails(string s_ID)
    {
        string s_Return = "";
        KNet.BLL.PB_Basic_Express Bll = new KNet.BLL.PB_Basic_Express();
        KNet.Model.PB_Basic_Express Model = Bll.GetModel(s_ID);
        if (Model != null)
        {
            s_Return += Model.PBE_KDName + ",";
            s_Return += Model.PBE_CustomerName + ",";
            s_Return += Model.PBE_LinkManName + ",";
            s_Return += Model.PBE_Phone + ",";
            s_Return += Model.PBE_TelPhone + ",";
            s_Return += Model.PBE_Address + ",";
            s_Return += Model.PBE_ReCustomerName + ",";
            s_Return += Model.PBE_ReLinkManName + ",";
            s_Return += Model.PBE_RePhone + ",";
            s_Return += Model.PBE_ReTelPhone + ",";
            s_Return += Model.PBE_ReAddress ;
        }
        return s_Return;
    }
}
