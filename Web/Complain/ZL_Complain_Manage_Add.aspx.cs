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


public partial class Web_Sales_ZL_Complain_Manage_Add : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            
            base.Base_DropBasicCodeBind(this.Ddl_Type, "213");//类型
            base.Base_DropBasicCodeBind(this.Ddl_HurryState, "214", false);//
            base.Base_DropBasicCodeBind(this.Ddl_TimeState, "215");//
            base.Base_DropDutyPerson(this.Ddl_DutyPerson);
            base.Base_DropLinkManBind(this.Ddl_LinkMan, this.Tbx_CustomerValue.Value);
            this.Tbx_Code.Text = "CQ" + base.GetNewID("ZL_Complain_Manage", 0);
            this.Tbx_Stime.Text = DateTime.Now.ToShortDateString();
            this.Lbl_Title.Text = "新增客户抱怨";
            base.Base_DropDutyPerson(this.Ddl_D4Person);
            base.Base_DropDutyPerson(this.Ddl_D5Person);
            base.Base_DropDutyPerson(this.Ddl_D6Person);
            base.Base_DropDutyPerson(this.Ddl_D7Person);
            base.Base_DropDutyPerson(this.Ddl_D8Person);
            switch (s_Type)
            {
                case "D1":
                    this.D1.Visible = true;
                    break;
                case "D2":
                    this.D2.Visible = true;
                    break;
                case "D3":
                    this.D3.Visible = true;
                    break;
                case "D4":
                    this.D4.Visible = true;
                    break;
                case "D5":
                    this.D5.Visible = true;
                    break;
                case "D6":
                    this.D6.Visible = true;
                    break;
                case "D7":
                    this.D7.Visible = true;
                    break;
                case "D8":
                    this.D8.Visible = true;
                    break;
            }
            if (s_ID != "")
            {
                if (s_Type == "1")
                {
                    this.D0.Visible = true;
                    this.D2.Visible = true;
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制客户抱怨";
                }
                else
                {
                    this.D0.Visible = true;
                    this.D2.Visible = true;
                    this.Lbl_Title.Text = "修改客户抱怨";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }
            else
            {
                this.D0.Visible = true;
                this.D2.Visible = true;
            }

            //客户抱怨列表
            if (AM.CheckLogin(this.Lbl_Title.Text) == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
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
            this.Ddl_Type.SelectedValue = model.ZCM_Type;
            this.Ddl_HurryState.SelectedValue = model.ZCM_HurryState;
            this.Ddl_TimeState.SelectedValue = model.ZCM_TimeState;
            base.Base_DropLinkManBind(this.Ddl_LinkMan, model.ZCM_CustomerValue);
            this.Ddl_LinkMan.SelectedValue = model.ZCM_LinkMan;
            this.Tbx_ProductsID.Value = model.ZCM_ProductsBarCode;
            this.Tbx_ProductsName.Text = base.Base_GetProductsEdition(model.ZCM_ProductsBarCode);
            this.Ddl_DutyPerson.SelectedValue = model.ZCM_DutyPerson;
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
            try
            {
                this.Tbx_D4Time.Text = DateTime.Parse(model.ZCM_D4Time.ToString()).ToShortDateString();
            }
            catch { }
            this.Tbx_D4Cause.Text = model.ZCM_D4Cause;
            this.Ddl_D4Person.SelectedValue = model.ZCM_D4Person;
            try
            {
                this.Tbx_D4Time.Text = DateTime.Parse(model.ZCM_D4Time.ToString()).ToShortDateString();
            }
            catch { }
            this.Tbx_D5Cause.Text = model.ZCM_D5Cause;
            this.Ddl_D5Person.SelectedValue = model.ZCM_D5Person;
            try
            {
                this.Tbx_D5Time.Text = DateTime.Parse(model.ZCM_D5Time.ToString()).ToShortDateString();
            }
            catch { }
            this.Tbx_D6Cause.Text = model.ZCM_D6Cause;
            this.Ddl_D6Person.SelectedValue = model.ZCM_D6Person;
            try
            {
                this.Tbx_D6Time.Text = DateTime.Parse(model.ZCM_D6Time.ToString()).ToShortDateString();
            }
            catch { }
            this.Tbx_D7Cause.Text = model.ZCM_D7Cause;
            this.Ddl_D7Person.SelectedValue = model.ZCM_D7Person;
            try
            {
                this.Tbx_D7Time.Text = DateTime.Parse(model.ZCM_D7Time.ToString()).ToShortDateString();
            }
            catch { }
            this.Tbx_D8Cause.Text = model.ZCM_D8Cause;
            this.Ddl_D8Person.SelectedValue = model.ZCM_D8Person;
            try
            {
                this.Tbx_D8Time.Text = DateTime.Parse(model.ZCM_D8Time.ToString()).ToShortDateString();
            }
            catch { }
        }
        catch { }
    }
    private bool SetValue(KNet.Model.ZL_Complain_Manage model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text == "")
            {
                model.ZCM_ID = base.GetMainID();
            }
            else
            {
                model.ZCM_ID = this.Tbx_ID.Text;
            }
            model.ZCM_Code = this.Tbx_Code.Text;
            model.ZCM_ContractNo = this.SalesOrderNoSelectValue.Value;
            model.ZCM_CustomerValue = this.Tbx_CustomerValue.Value;
            try
            {
                model.ZCM_STime = DateTime.Parse(this.Tbx_Stime.Text);
            }
            catch { }
            model.ZCM_Type = this.Ddl_Type.SelectedValue;
            model.ZCM_HurryState = this.Ddl_HurryState.SelectedValue;
            model.ZCM_TimeState = this.Ddl_TimeState.SelectedValue;
            model.ZCM_LinkMan = this.Ddl_LinkMan.SelectedValue;
            model.ZCM_ProductsBarCode = this.Tbx_ProductsID.Value;
            model.ZCM_DutyPerson = this.Ddl_DutyPerson.SelectedValue;
            //D1

            model.ZCM_D1Leder = this.Tbx_D1LederID.Text;
            model.ZCM_D1Member = this.Tbx_D1Member.Text;

            //D2
            model.ZCM_D2Finder = this.Tbx_D2Finder.Text;
            try
            {
                model.ZCM_D2Time = DateTime.Parse(this.Tbx_D2Time.Text);
            }
            catch { }
            model.ZCM_D2FRemarks = this.Tbx_D2FRemarks.Text;
            try
            {
                model.ZCM_D2Number = int.Parse(this.Tbx_D2Number.Text);
            }
            catch { }
            //D3
            model.ZCM_D3QState = this.Tbx_D3QState.Text;
            try
            {
                model.ZCM_D3Time = DateTime.Parse(this.Tbx_D3Time.Text);
                model.ZCM_D3CompyNumber = int.Parse(this.Tbx_D3CompyNumber.Text);
                model.ZCM_D3CustomerNumber = int.Parse(this.Tbx_D3CustomerNumber.Text);
                model.ZCM_D3TravelNumber = int.Parse(this.Tbx_D3TravelNumber.Text);
            }
            catch { }
            model.ZCM_D3MaterialDetails = this.Tbx_D3MaterialDetails.Text;
            model.ZCM_D3Cause = this.Tbx_D3Cause.Text;
            //D4
            model.ZCM_D4Cause = this.Tbx_D4Cause.Text;
            model.ZCM_D4Person = this.Ddl_D4Person.SelectedValue;
            try
            {
                model.ZCM_D4Time = DateTime.Parse(this.Tbx_D4Time.Text);
            }
            catch { }
            //D5
            model.ZCM_D5Cause = this.Tbx_D5Cause.Text;
            model.ZCM_D5Person = this.Ddl_D5Person.SelectedValue;
            try
            {
                model.ZCM_D5Time = DateTime.Parse(this.Tbx_D5Time.Text);
            }
            catch { }
            //D6
            model.ZCM_D6Cause = this.Tbx_D6Cause.Text;
            model.ZCM_D6Person = this.Ddl_D6Person.SelectedValue;
            try
            {
                model.ZCM_D6Time = DateTime.Parse(this.Tbx_D6Time.Text);
            }
            catch { }
            //D7
            model.ZCM_D7Cause = this.Tbx_D7Cause.Text;
            model.ZCM_D7Person = this.Ddl_D7Person.SelectedValue;
            try
            {
                model.ZCM_D7Time = DateTime.Parse(this.Tbx_D7Time.Text);
            }
            catch { }
            //D8

            model.ZCM_D8Cause = this.Tbx_D8Cause.Text;
            model.ZCM_D8Person = this.Ddl_D8Person.SelectedValue;
            try
            {
                model.ZCM_D8Time = DateTime.Parse(this.Tbx_D8Time.Text);
            }
            catch { }
            model.ZCM_Creator = AM.KNet_StaffNo;
            model.ZCM_CTime = DateTime.Now;
            model.ZCM_Mender = AM.KNet_StaffNo;
            model.ZCM_MTime = DateTime.Now;
            model.ZCM_Del = 0;
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

        KNet.Model.ZL_Complain_Manage model = new KNet.Model.ZL_Complain_Manage();
        KNet.BLL.ZL_Complain_Manage bll = new KNet.BLL.ZL_Complain_Manage();

        if (this.SetValue(model) == false)
        {
            Alert("系统错误！");
            return;
        }
        if (s_ID == "")//新增
        {
            try
            {

                model.ZCM_D4Person = "";
                model.ZCM_D5Person = "";
                model.ZCM_D6Person = "";
                model.ZCM_D7Person = "";
                model.ZCM_D8Person = "";
                base.GetNewID("ZL_Complain_Manage", 1);
                bll.Add(model);
                AM.Add_Logs("客户抱怨增加" + this.Tbx_ID.Text);
                AlertAndRedirect("新增成功！", "ZL_Complain_Manage_List.aspx");
            }
            catch (Exception ex) { }
        }
        else
        {
            try
            {
                bll.Update(model);
                AM.Add_Logs("客户抱怨修改" + this.Tbx_ID.Text);
                AlertAndRedirect("修改成功！", "ZL_Complain_Manage_List.aspx");
            }
            catch { }
        }
    }
}
