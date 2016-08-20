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


public partial class Web_Sales_Xs_Transfer_Cheque_Add : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("支出管理列表") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
            else
            {
                string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
                string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
                base.Base_DropBasicCodeBind(this.Ddl_Type, "123");//关怀类型
                base.Base_DropBasicCodeBind(this.Ddl_BillType, "754");
                this.Tbx_STime.Text = DateTime.Now.ToShortDateString();
                Base_DdlBankbind(this.Ddl_Account);

                base.Base_DropDutyPerson(this.Ddl_DutyPerson);
                this.Lbl_Title.Text = "新增账号支出";
                if (s_ID != "")
                {
                    if (s_Type == "1")
                    {
                        this.Tbx_ID.Text = "";
                        this.Lbl_Title.Text = "复制账号支出";
                    }
                    else
                    {
                        this.Lbl_Title.Text = "修改账号支出";
                        this.Tbx_ID.Text = s_ID;
                    }
                    this.Btn_Save.Text = "保存";
                    ShowInfo(s_ID);
                }
 
            }
        }
    }

    private void ShowInfo(string s_ID)
    {
        KNet.BLL.Xs_Transfer_Cheque bll = new KNet.BLL.Xs_Transfer_Cheque();
        KNet.Model.Xs_Transfer_Cheque model = bll.GetModel(s_ID);
        this.Tbx_UseName.Text = model.XTC_UseName;
        this.Tbx_STime.Text = DateTime.Parse(model.XTC_Stime.ToString()).ToShortDateString();
        this.Tbx_PayeeValue.Value = model.XTC_PayeeValue;
        this.Tbx_PayeeName.Text = model.XTC_PayeeName;
        this.Ddl_Type.SelectedValue = model.XTC_Type;
        this.Ddl_Account.SelectedValue = model.XTC_Account;
        this.Ddl_DutyPerson.SelectedValue = model.XTC_DutyPerson;
        this.Tbx_Money.Text = model.XTC_Money.ToString();
        this.Tbx_ChineseMoney.Text = model.XTC_ChineseMoney;
        this.Tbx_Remarks.Text = model.XTC_Remarks;
        this.Tbx_BankName.Text = model.XTC_BankName;
        this.Tbx_BankAccount.Text = model.XTC_BankAccount;
        this.Ddl_BillType.SelectedValue = model.XTC_BillType;
        this.Tbx_BillNumber.Text = model.XTC_BillNumber;

        this.Tbx_Shen.Text = model.XTC_Shen;
        this.Tbx_Shi.Text = model.XTC_Shi;
    }
    private bool SetValue(KNet.Model.Xs_Transfer_Cheque model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            model.XTC_UseName = this.Tbx_UseName.Text;
            if (this.Tbx_STime.Text != "")
            {
                model.XTC_Stime = DateTime.Parse(this.Tbx_STime.Text);
            }
            if (this.Tbx_ID.Text == "")
            {
                this.Tbx_ID.Text = base.GetNewID("Xs_Transfer_Cheque", 1);
            }
            model.XTC_ID = this.Tbx_ID.Text;
            model.XTC_PayeeValue = this.Tbx_PayeeValue.Value;
            model.XTC_PayeeName = this.Tbx_PayeeName.Text;
            model.XTC_Type = this.Ddl_Type.SelectedValue;
            model.XTC_Account = this.Ddl_Account.SelectedValue;
            model.XTC_DutyPerson = this.Ddl_DutyPerson.SelectedValue;
            model.XTC_Money = Convert.ToDecimal(this.Tbx_Money.Text);
            model.XTC_ChineseMoney = this.Tbx_ChineseMoney.Text;
            model.XTC_Remarks = this.Tbx_Remarks.Text;
            model.XTC_Creator = AM.KNet_StaffNo;
            model.XTC_CTime = DateTime.Now;
            model.XTC_Mender = AM.KNet_StaffNo;
            model.XTC_MTime = DateTime.Now;
            model.XTC_BankName = this.Tbx_BankName.Text;
            model.XTC_BankAccount = this.Tbx_BankAccount.Text;
            model.XTC_BillType = this.Ddl_BillType.SelectedValue;
            model.XTC_BillNumber = this.Tbx_BillNumber.Text;
            model.XTC_Shi = this.Tbx_Shi.Text;
            model.XTC_Shen = this.Tbx_Shen.Text;

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
        string s_ID=this.Tbx_ID.Text;

        KNet.Model.Xs_Transfer_Cheque model = new KNet.Model.Xs_Transfer_Cheque();
        KNet.BLL.Xs_Transfer_Cheque bll = new KNet.BLL.Xs_Transfer_Cheque();

        if (this.SetValue(model) == false)
        {
            Alert("系统错误！");
            return;
        }
        if (s_ID == "")//新增
        {
            try
            {
                bll.Add(model);
                AM.Add_Logs("账号支出增加" + this.Tbx_ID.Text);
                AlertAndRedirect("新增成功！", "Xs_Transfer_Cheque_List.aspx");
            }
            catch(Exception ex) {
                this.Tbx_ID.Text = "";
            }
        }
        else
        {

            try
            {
                bll.Update(model);
                AM.Add_Logs("账号支出修改" + this.Tbx_ID.Text);
                AlertAndRedirect("修改成功！", "Xs_Transfer_Cheque_List.aspx");
            }
            catch { }
        }
    }
}
