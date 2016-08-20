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


public partial class Web_Xs_Transfer_Cheque_View : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.Lbl_Title.Text = "查看账号支出";
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            if (s_ID != "")
            {
                ShowInfo(s_ID);
            }
        }
       
    }

    private void ShowInfo(string s_ID)
    {
     
        KNet.BLL.Xs_Transfer_Cheque bll = new KNet.BLL.Xs_Transfer_Cheque();
        KNet.Model.Xs_Transfer_Cheque model = bll.GetModel(s_ID);
        try
        {
            this.Tbx_ID.Text = s_ID;
            this.Lbl_UseName.Text = model.XTC_UseName;
            this.Lbl_Stime.Text = DateTime.Parse(model.XTC_Stime.ToString()).ToShortDateString();
            this.Lbl_Account.Text = base.Base_GetBankName(model.XTC_Account);
            if (model.XTC_PayeeValue == "")
            {
                this.Lbl_Payee.Text = model.XTC_PayeeName;
            }
            else
            {
                if (base.Base_GetCustomerName(model.XTC_PayeeValue) != "--")
                {
                    this.Lbl_Payee.Text = base.Base_GetCustomerName_Link(model.XTC_PayeeValue);
                }
                else
                {
                    this.Lbl_Payee.Text = base.Base_GetSupplierName_Link(model.XTC_PayeeValue);
                }
            }
            this.Lbl_Money.Text = model.XTC_Money.ToString();
            this.Lbl_ChineseMoney.Text = model.XTC_ChineseMoney;
            this.Lbl_Type.Text = base.Base_GetBasicCodeName("123",model.XTC_Type);
            this.Lbl_Remarks.Text = model.XTC_Remarks;
            this.Lbl_DutyPerson.Text = base.Base_GetUserName(model.XTC_DutyPerson);
            this.Lbl_BankName.Text = model.XTC_BankName;
            this.Lbl_BankAccount.Text = model.XTC_BankAccount;
            this.Lbl_BillType.Text = base.Base_GetBasicCodeName("754", model.XTC_BillType);
            this.Lbl_BillNumber.Text = model.XTC_BillNumber;
            this.Lbl_Shen.Text = model.XTC_Shen;
            this.Lbl_Shi.Text = model.XTC_Shi;
            
                
            
            //this.Lbl_Topic.Text = model.XCC_Topic;
            //this.Lbl_Stime.Text 
            //this.Lbl_CustomerValue.Text = base.Base_GetCustomerName_Link(model.XCC_CustomerValue);
            //this.Lbl_LinkMan.Text = base.Base_GetLinkManValue(model.XCC_LinkMan, "XOL_Name");
            //this.Lbl_DutyPerson.Text = base.Base_GetUserName(model.XCC_DutyPerson);
            //this.Lbl_CareTypes.Text = base.Base_GetBasicCodeName("116", model.XCC_CareTypes);
            //this.Lbl_CustomerDetails.Text = model.XCC_CustomerDetails;
            //this.Lbl_CareDetails.Text = model.XCC_CareDetails;
            //
        }
        catch
        {}
    }

}
