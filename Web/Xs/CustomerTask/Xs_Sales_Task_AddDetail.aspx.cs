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


public partial class Web_Xs_Sales_Task_AddDetail : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.Lbl_Title.Text = "查看联系人";
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            if (s_ID != "")
            {
                ShowInfo(s_ID);
            }
        }
       
    }

    private void ShowInfo(string s_ID)
    {
     
        KNet.BLL.Xs_Sales_Task bll = new KNet.BLL.Xs_Sales_Task();
        KNet.Model.Xs_Sales_Task model = bll.GetModel(s_ID);
        try
        {
            this.Tbx_ID.Text = s_ID;
            this.Lbl_Topic.Text = model.XST_Topic;
            this.Lbl_State.Text = base.Base_GetBasicCodeName("119",model.XST_Topic);

            this.Lbl_Claim.Text = base.Base_GetBasicCodeName("120", model.XST_Topic);
            this.Lbl_IsModiy.Text = base.Base_GetBasicCodeName("107", model.XST_Topic);

            this.Lbl_Begintime.Text = DateTime.Parse(model.XST_BeginTime.ToString()).ToShortDateString();
            this.Lbl_Endtime.Text = DateTime.Parse(model.XST_EndTime.ToString()).ToShortDateString();

            this.Lbl_Executor.Text = base.Base_GetUserNames(model.XST_Executor);
            this.Lbl_DutyPerson.Text = base.Base_GetUserName(model.XST_DutyPerson);
            this.Lbl_Remarks.Text = model.XST_Remarks;
        }
        catch
        {}
    }

}
