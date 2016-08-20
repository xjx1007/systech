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


public partial class KNet_Sys_Bank_Add : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("新增银行账号列表") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
            else
            {
                string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
                string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
                this.Tbx_STime.Text = DateTime.Now.ToShortDateString();
                this.Lbl_Title.Text = "新增银行账号";
                this.Tbx_Money.Text = "0";
                if (s_ID != "")
                {
                    if (s_Type == "1")
                    {
                        this.Tbx_ID.Text = "";
                        this.Lbl_Title.Text = "复制银行账号";
                    }
                    else
                    {
                        this.Lbl_Title.Text = "修改银行账号";
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
        KNet.BLL.KNet_Sys_Bank bll = new KNet.BLL.KNet_Sys_Bank();
        KNet.Model.KNet_Sys_Bank model = bll.GetModel(s_ID);
        if (model != null)
        {
            this.Tbx_BankName.Text = model.BankName;
           this.Tbx_BankAccount.Text= model.BankCount  ;
          this.Tbx_Money.Text=  model.InitialAmount.ToString();
          this.Tbx_STime.Text = model.KSB_STime.ToShortDateString();
        }
    }
    private bool SetValue(KNet.Model.KNet_Sys_Bank model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text != "")
            {
                model.ID = this.Tbx_ID.Text;
                model.BankNo = this.Tbx_Code.Text;
            }
            if (this.Tbx_ID.Text == "")
            {
                model.ID = GetMainID();
                model.BankNo = base.GetNewID("KNet_Sys_Bank", 1);
            }
            model.BankName = this.Tbx_BankName.Text;
            model.BankCount = this.Tbx_BankAccount.Text;
            model.BankPai = 0;
            model.InitialAmount = decimal.Parse(this.Tbx_Money.Text);
            try
            {
                model.KSB_STime = DateTime.Parse(this.Tbx_STime.Text);
            }
            catch
            {
                model.KSB_STime = DateTime.Parse("1900-01-01");
            }
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

        KNet.Model.KNet_Sys_Bank model = new KNet.Model.KNet_Sys_Bank();
        KNet.BLL.KNet_Sys_Bank bll = new KNet.BLL.KNet_Sys_Bank();

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
                AM.Add_Logs("银行账号增加" + this.Tbx_ID.Text);
                AlertAndRedirect("新增成功！", "KNet_Sys_Bank_List.aspx");
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
                AM.Add_Logs("银行账号修改" + this.Tbx_ID.Text);
                AlertAndRedirect("修改成功！", "KNet_Sys_Bank_List.aspx");

            }
            catch(Exception ex) { }
        }
    }

}
