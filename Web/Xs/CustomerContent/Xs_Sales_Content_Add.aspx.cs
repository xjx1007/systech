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


public partial class Web_Sales_Xs_Sales_Content_Add : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();

            string s_CustomerValue = Request.QueryString["CustomerValue"] == null ? "" : Request.QueryString["CustomerValue"].ToString();
            string s_LinkMan = Request.QueryString["LinkMan"] == null ? "" : Request.QueryString["LinkMan"].ToString();
            string s_OppID = Request.QueryString["OppID"] == null ? "" : Request.QueryString["OppID"].ToString();

            base.Base_DropBasicCodeBind(this.Ddl_Types, "117");//
            base.Base_DropBasicCodeBind(this.Ddl_State, "113");//客户状态
            base.Base_DropBasicCodeBind(this.Ddl_Steps, "118");//
            base.Base_DropDutyPerson(this.Ddl_DutyPerson);
            this.Tbx_STime.Text = DateTime.Now.ToShortDateString();
            if (s_CustomerValue != "")
            {
                this.Tbx_CustomerValue.Value = s_CustomerValue;
                this.Tbx_CustomerName.Text = base.Base_GetCustomerName(s_CustomerValue);
                this.Ddl_LinkMan.SelectedValue = s_LinkMan;
                this.Tbx_SalesChanceValue.Text = s_OppID;
                this.Tbx_SalesChanceName.Text = base.Base_GetOppName(s_OppID);

            }
            base.Base_DropLinkManBind(this.Ddl_LinkMan,this.Tbx_CustomerValue.Value);
            this.Lbl_Title.Text = "新增联系记录";
            if (s_ID!= "")
            {
                if (s_Type == "1")
                {
                    this.Lbl_Title.Text = "复制联系记录";
                    this.Tbx_ID.Text = "";
                }
                else
                {
                    this.Lbl_Title.Text = "修改联系记录";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin(this.Lbl_Title.Text) == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
        }
    }

    private void ShowInfo(string s_ID)
    {
        KNet.BLL.Xs_Sales_Content bll = new KNet.BLL.Xs_Sales_Content();
        KNet.Model.Xs_Sales_Content model = bll.GetModel(s_ID);
        this.Tbx_Topic.Text = model.XSC_Topic;
        try
        {
            this.Tbx_NextAskTime.Text = DateTime.Parse(model.XSC_NextAskTime.ToString()).ToShortDateString();
        }
        catch
        { }
        this.Ddl_Steps.SelectedValue = model.XSC_Steps;
        this.Ddl_State.SelectedValue = model.XSC_State;

        this.Tbx_STime.Text = DateTime.Parse(model.XSC_Stime.ToString()).ToShortDateString();
        this.Tbx_CustomerValue.Value = model.XSC_CustomerValue;
        this.Tbx_CustomerName.Text = base.Base_GetCustomerName(model.XSC_CustomerValue);
        base.Base_DropLinkManBind(this.Ddl_LinkMan, this.Tbx_CustomerValue.Value);
        this.Ddl_LinkMan.SelectedValue = model.XSC_LinkMan;
        this.Ddl_DutyPerson.SelectedValue = model.XSC_DutyPerson;
        this.Ddl_Types.SelectedValue = model.XSC_Types;
        this.Tbx_Remarks.Text = model.XSC_Remarks;
        this.Tbx_SalesChanceValue.Text = model.XSC_SalesChance;

        KNet.BLL.Xs_Sales_Opp bll_Opp = new KNet.BLL.Xs_Sales_Opp();
        KNet.Model.Xs_Sales_Opp model_Opp = bll_Opp.GetModelB(model.XSC_SalesChance);
        if (model_Opp != null)
        {
            this.Tbx_SalesChanceName.Text = model_Opp.XSO_Name;
        }


    }
    private bool SetValue(KNet.Model.Xs_Sales_Content model)
    {
        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text == "")
            {
                model.XSC_ID = base.GetNewID("Xs_Sales_Content", 1);
            }
            else
            {
                model.XSC_ID = this.Tbx_ID.Text;
            }
            model.XSC_Topic = this.Tbx_Topic.Text;
            if (this.Tbx_STime.Text != "")
            {
                model.XSC_Stime = DateTime.Parse(this.Tbx_STime.Text);
            }
            if (this.Tbx_NextAskTime.Text != "")
            {
                model.XSC_NextAskTime = DateTime.Parse(this.Tbx_NextAskTime.Text);
            }
            model.XSC_State = this.Ddl_State.SelectedValue;
            model.XSC_Steps = this.Ddl_Steps.SelectedValue;
            model.XSC_SalesChance = this.Tbx_SalesChanceValue.Text;

            model.XSC_CustomerValue = this.Tbx_CustomerValue.Value;
            model.XSC_LinkMan = this.Ddl_LinkMan.SelectedValue;
            model.XSC_DutyPerson = this.Ddl_DutyPerson.SelectedValue;
            model.XSC_Types = this.Ddl_Types.SelectedValue;
            model.XSC_Remarks = this.Tbx_Remarks.Text;
            model.XSC_Creator = AM.KNet_StaffNo;
            model.XSC_CTime = DateTime.Now;
            model.XSC_Mender = AM.KNet_StaffNo;
            model.XSC_MTime = DateTime.Now;
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

        KNet.Model.Xs_Sales_Content model = new KNet.Model.Xs_Sales_Content();
        KNet.BLL.Xs_Sales_Content bll = new KNet.BLL.Xs_Sales_Content();

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
                AM.Add_Logs("联系记录增加" + this.Tbx_ID.Text);
                AlertAndRedirect("新增成功！", "Xs_Sales_Content_List.aspx");
            }
            catch { }
        }
        else
        {

            try
            {
                bll.Update(model);
                AM.Add_Logs("联系记录修改" + this.Tbx_ID.Text);
                AlertAndRedirect("修改成功！", "Xs_Sales_Content_List.aspx");
            }
            catch { }
        }
    }
}
