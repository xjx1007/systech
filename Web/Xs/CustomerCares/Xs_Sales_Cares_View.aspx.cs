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


public partial class Web_Xs_Sales_Cares_View : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            this.Lbl_Title.Text = "查看客户关怀";
            if (AM.CheckLogin(this.Lbl_Title.Text) == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
                // 客户关怀列表
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            if (s_ID != "")
            {
                ShowInfo(s_ID);
            }
        }
       
    }

    private void ShowInfo(string s_ID)
    {
     
        KNet.BLL.Xs_Customer_Cares bll = new KNet.BLL.Xs_Customer_Cares();
        KNet.Model.Xs_Customer_Cares model = bll.GetModel(s_ID);
        try
        {
            this.Tbx_ID.Text = s_ID;
            this.Lbl_Topic.Text = model.XCC_Topic;
            this.Lbl_Stime.Text = DateTime.Parse(model.XCC_Stime.ToString()).ToShortDateString();
            this.Lbl_CustomerValue.Text = base.Base_GetCustomerName_Link(model.XCC_CustomerValue);
            this.Lbl_LinkMan.Text = base.Base_GetLinkManValue(model.XCC_LinkMan, "XOL_Name");
            this.Lbl_DutyPerson.Text = base.Base_GetUserName(model.XCC_DutyPerson);
            this.Lbl_CareTypes.Text = base.Base_GetBasicCodeName("116", model.XCC_CareTypes);
            this.Lbl_CustomerDetails.Text = model.XCC_CustomerDetails;
            this.Lbl_CareDetails.Text = model.XCC_CareDetails;
            this.Lbl_Remarks.Text = model.XCC_Remarks;
        }
        catch
        {}
    }

}
