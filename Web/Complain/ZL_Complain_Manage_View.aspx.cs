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


public partial class Web_ZL_Complain_Manage_View : BasePage
{
    public string s_CustomerValue = "", s_Structure="";
    public string s_LinkMan = "";
    public string s_OppID = "", s_ID="";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.Lbl_Title.Text = "查看客户抱怨";
            AdminloginMess AM = new AdminloginMess();
            //销售机会列表
            if (AM.CheckLogin(this.Lbl_Title.Text) == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
             s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            if (s_ID != "")
            {
                ShowInfo(s_ID);
            }
            CommentList2.CommentType = "Complain";
            CommentList2.CommentFID = s_ID;
        }
    }

    private void ShowInfo(string s_ID)
    {
        KNet.BLL.ZL_Complain_Manage bll = new KNet.BLL.ZL_Complain_Manage();
        KNet.Model.ZL_Complain_Manage model = bll.GetModel(s_ID);

        AdminloginMess AM = new AdminloginMess();
        try
        {
            this.Tbx_ID.Text = model.ZCM_ID;
            this.Tbx_Code.Text = model.ZCM_Code;
            this.SalesOrderNoSelectValue.Value = model.ZCM_ContractNo;
            this.SalesOrderNo.Text = model.ZCM_ContractNo;
            this.Tbx_CustomerValue.Value = model.ZCM_CustomerValue;
            this.Tbx_CustomerName.Text = base.Base_GetCustomerName(model.ZCM_CustomerValue);
            try
            {
                this.Tbx_Stime.Text = DateTime.Parse(model.ZCM_STime.ToString()).ToShortDateString(); ;
            }
            catch { }
            this.Ddl_Type.Text = base.Base_GetBasicCodeName("213", model.ZCM_Type);
            this.Ddl_HurryState.Text = base.Base_GetBasicCodeName("214", model.ZCM_HurryState);
            this.Ddl_TimeState.Text = base.Base_GetBasicCodeName("214", model.ZCM_TimeState); 
            this.Ddl_LinkMan.Text = base.Base_GetLinkManValue(model.ZCM_LinkMan, "XOL_Name"); 
            this.Tbx_ProductsID.Value = model.ZCM_ProductsBarCode;
            this.Tbx_ProductsName.Text = base.Base_GetProductsEdition(model.ZCM_ProductsBarCode);
            this.Ddl_DutyPerson.Text = base.Base_GetUserName(model.ZCM_DutyPerson);
            
            try
            {
                this.Tbx_D1LederID.Text = model.ZCM_D1Leder;
                this.Tbx_D1LederName.Text = base.Base_GetUserNames(model.ZCM_D1Leder);
                this.Tbx_D1Member.Text = model.ZCM_D1Member;
                this.Tbx_D1MemberName.Text = base.Base_GetUserNames(model.ZCM_D1Member);
            }
            catch { }
            this.Tbx_D2Finder.Text = model.ZCM_D2Finder;
            try
            {
                this.Tbx_D2Time.Text = DateTime.Parse(model.ZCM_D2Time.ToString()).ToShortDateString();
            }
            catch { }
            this.Tbx_D2FRemarks.Text = model.ZCM_D2FRemarks;
            try
            {
                this.Tbx_D2Number.Text = model.ZCM_D2Number.ToString();
            }
            catch { }
            this.Tbx_D3QState.Text = model.ZCM_D3QState;
            try
            {
                this.Tbx_D3Time.Text = DateTime.Parse(model.ZCM_D3Time.ToString()).ToShortDateString();
                this.Tbx_D3CompyNumber.Text = model.ZCM_D3CompyNumber.ToString();
                this.Tbx_D3CustomerNumber.Text = model.ZCM_D3CustomerNumber.ToString();
                this.Tbx_D3TravelNumber.Text = model.ZCM_D3TravelNumber.ToString();
            }
            catch { }
            this.Tbx_D3MaterialDetails.Text = model.ZCM_D3MaterialDetails;
            this.Tbx_D3Cause.Text = model.ZCM_D3Cause;
            this.Tbx_D4Cause.Text = model.ZCM_D4Cause;
            this.Ddl_D4Person.Text = base.Base_GetUserName(model.ZCM_D4Person); 
            try
            {
                this.Tbx_D4Time.Text = DateTime.Parse(model.ZCM_D4Time.ToString()).ToShortDateString();
            }
            catch { }
            this.Tbx_D4Cause.Text = model.ZCM_D4Cause;
            try
            {
                this.Tbx_D4Time.Text = DateTime.Parse(model.ZCM_D4Time.ToString()).ToShortDateString();
            }
            catch { }
            this.Tbx_D5Cause.Text = model.ZCM_D5Cause;
            this.Ddl_D5Person.Text = base.Base_GetUserName(model.ZCM_D5Person);
            try
            {
                this.Tbx_D5Time.Text = DateTime.Parse(model.ZCM_D5Time.ToString()).ToShortDateString();
            }
            catch { }
            this.Tbx_D6Cause.Text = model.ZCM_D6Cause;
            this.Ddl_D6Person.Text = base.Base_GetUserName(model.ZCM_D6Person);
            try
            {
                this.Tbx_D6Time.Text = DateTime.Parse(model.ZCM_D6Time.ToString()).ToShortDateString();
            }
            catch { }
            this.Tbx_D7Cause.Text = model.ZCM_D7Cause;
            this.Ddl_D7Person.Text = base.Base_GetUserName(model.ZCM_D7Person);
            try
            {
                this.Tbx_D7Time.Text = DateTime.Parse(model.ZCM_D7Time.ToString()).ToShortDateString();
            }
            catch { }
            this.Tbx_D8Cause.Text = model.ZCM_D8Cause;
            this.Ddl_D8Person.Text = base.Base_GetUserName(model.ZCM_D8Person);
            try
            {
                this.Tbx_D8Time.Text = DateTime.Parse(model.ZCM_D8Time.ToString()).ToShortDateString();
            }
            catch { }
        }
        catch { }
    }
}
