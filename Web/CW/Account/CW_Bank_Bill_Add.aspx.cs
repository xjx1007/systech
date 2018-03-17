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


public partial class CW_Bank_Bill_Add : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("新增银行转账列表") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
            else
            {
                string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
                string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
                string s_BankNo = Request.QueryString["BankNo"] == null ? "" : Request.QueryString["BankNo"].ToString();

                this.Tbx_STime.Text = DateTime.Now.ToShortDateString();

                Base_DdlBankbind(this.Ddl_InAccount);
                Base_DdlBankbind(this.Ddl_OutAccount);
                if (s_BankNo != "")
                {
                    this.Ddl_OutAccount.SelectedValue = s_BankNo;
                }
                this.Lbl_Title.Text = "新增银行转账";
                this.Tbx_Money.Text = "0";
                if (s_ID != "")
                {
                    if (s_Type == "1")
                    {
                        this.Tbx_ID.Text = "";
                        this.Lbl_Title.Text = "复制银行转账";
                    }
                    else
                    {
                        this.Lbl_Title.Text = "修改银行转账";
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
        KNet.BLL.CW_Bank_Bill bll = new KNet.BLL.CW_Bank_Bill();
        KNet.Model.CW_Bank_Bill model = bll.GetModel(s_ID);
        if (model != null)
        {
            this.Tbx_Code.Text = model.CBB_Code;
            this.Ddl_OutAccount.SelectedValue = model.CBB_OutBankNo;
            this.Ddl_InAccount.SelectedValue = model.CBB_InBankNo;
            this.Tbx_Money.Text = model.CBB_Money.ToString();
            try
            {
                this.Tbx_STime.Text = model.CBB_STime.ToShortDateString();
            }
            catch
            {
            }
            this.Tbx_Details.Text = model.CBB_Detail;
        }
    }
    private bool SetValue(KNet.Model.CW_Bank_Bill model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text != "")
            {
                model.CBB_ID = this.Tbx_ID.Text;
                model.CBB_Code = this.Tbx_Code.Text;
            }
            if (this.Tbx_ID.Text == "")
            {
                model.CBB_ID = GetMainID();
                model.CBB_Code = base.GetNewID("CW_Bank_Bill", 1);
            }
            model.CBB_OutBankNo = this.Ddl_OutAccount.SelectedValue;
            model.CBB_InBankNo = this.Ddl_InAccount.SelectedValue;
            model.CBB_Money = decimal.Parse(this.Tbx_Money.Text);
            try
            {
                model.CBB_STime = DateTime.Parse(this.Tbx_STime.Text);
            }
            catch
            {
                model.CBB_STime = DateTime.Parse("1900-01-01");
            }
            model.CBB_Detail = this.Tbx_Details.Text;
            model.CBB_Creator = AM.KNet_StaffNo;
            model.CBB_CTime = DateTime.Now;
            model.CBB_Mender = AM.KNet_StaffNo;
            model.CBB_MTime = DateTime.Now;
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
        string s_ID = this.Tbx_ID.Text;

        KNet.Model.CW_Bank_Bill model = new KNet.Model.CW_Bank_Bill();
        KNet.BLL.CW_Bank_Bill bll = new KNet.BLL.CW_Bank_Bill();

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
                AM.Add_Logs("银行转账增加" + this.Tbx_ID.Text);
                AlertAndRedirect("新增成功！", "CW_Bank_Bill_List.aspx");
            }
            catch (Exception ex)
            {
                this.Tbx_ID.Text = "";
            }
        }
        else
        {

            try
            {
                bll.Update(model);
                AM.Add_Logs("银行转账修改" + this.Tbx_ID.Text);
                AlertAndRedirect("修改成功！", "CW_Bank_Bill_List.aspx");

            }
            catch(Exception ex) { }
        }
    }

}
