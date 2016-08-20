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


public partial class CG_Payment_For_Print : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            ShowInfo(s_ID);
        }
    }

    private void ShowInfo(string s_ID)
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.BLL.CG_Payment_For bll = new KNet.BLL.CG_Payment_For();
        KNet.Model.CG_Payment_For model = bll.GetModel(s_ID);
        if (model != null)
        {
            this.Lbl_Used.Text = model.CPF_Used;
            try
            {
                this.Lbl_STime.Text = model.CPF_STime.Year.ToString()+"年"+model.CPF_STime.Month.ToString()+"月"+model.CPF_STime.Day.ToString()+"日";
            }
            catch { }
            this.Lbl_Currency.Text = base.Base_GetBasicCodeName("401", model.CPF_Currency);
            this.Lbl_UseType.Text = base.Base_GetBasicCodeName("402", model.CPF_UseType);
            this.Lbl_Money.Text = model.CPF_Lowercase.ToString();
            this.Lbl_ChineseMoney.Text = model.CPF_Capital;
            this.Lbl_SuppName.Text = model.CPF_SuppNoName;
            this.Lbl_Code.Text = model.CPF_Code;
            try  
            {
                this.Lbl_YTime.Text = model.CPF_YTime.ToShortDateString();
            }
            catch { }
            this.Lbl_Depart.Text = base.Base_GeDept(model.CPF_DutyDepart);
            this.Lbl_DutyPerson.Text = base.Base_GetUserName(model.CPF_DutyPerson);
            this.Lbl_Remarks.Text = model.CPF_Remarks;
            this.Lbl_BankAccount.Text = model.CPF_Account;
            this.Lbl_Bank.Text = model.CPF_Bank;

            string s_Image = model.CPF_BigImage == null ? "" : model.CPF_BigImage;
            if ((s_Image != "../../images/Nopic.jpg") && (s_Image != ""))
            {
                this.Tr_Image.Visible = true;
                this.Lbl_Image.ImageUrl = s_Image;
            }
            else
            {
                this.Tr_Image.Visible = false;
            }
            this.Lbl_Shen.Text = model.CPF_Shen;
            this.Lbl_Shi.Text = model.CPF_Shi;
            if (model.CPF_State == 2)
            {
                this.Lbl_CwPerson.Text = "宗微微";
            }
            this.Lbl_ZPerson.Text = base.Base_GetUserName(model.CPF_ZPerson);
          //  string s_Sql = "Update CG_Payment_For set CPF_PrintNums=CPF_PrintNums+1 where CPF_ID='" + model.CPF_ID + "'";
         //   DbHelperSQL.ExecuteSql(s_Sql);
        }
    }

}
