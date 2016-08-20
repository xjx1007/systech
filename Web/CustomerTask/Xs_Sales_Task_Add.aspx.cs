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


public partial class Web_Sales_Xs_Sales_Task_Add : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();

            base.Base_DropDutyPerson(this.Ddl_DutyPerson);
            base.Base_DropBasicCodeBind(this.Ddl_IsModiy, "107");
            base.Base_DropBasicCodeBind(this.Ddl_State, "119");
            base.Base_DropBasicCodeBind(this.Ddl_Claim, "120");
            this.Ddl_State.SelectedValue = "101";
            this.Ddl_Claim.SelectedValue = "101";
            this.Ddl_IsModiy.SelectedValue = "102";

            this.Lbl_Title.Text = "新增客户任务计划 ";
            if (s_ID!= "")
            {
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制客户任务计划 ";
                }
                else
                {
                    this.Lbl_Title.Text = "修改客户任务计划 ";
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
        KNet.BLL.Xs_Sales_Task bll = new KNet.BLL.Xs_Sales_Task();
        KNet.Model.Xs_Sales_Task model = bll.GetModel(s_ID);
        this.Tbx_Topic.Text = model.XST_Topic;
        this.Ddl_State.SelectedValue = model.XST_State;
        this.Ddl_Claim.SelectedValue = model.XST_Claim;
        this.Ddl_IsModiy.SelectedValue = model.XST_ISModiy.ToString();
        this.Tbx_BeginTime.Text = DateTime.Parse(model.XST_BeginTime.ToString()).ToShortDateString();
        this.Tbx_EndTime.Text = DateTime.Parse(model.XST_EndTime.ToString()).ToShortDateString();

        this.Tbx_ExecutorValue.Text = model.XST_Executor;
        this.Ddl_DutyPerson.SelectedValue = model.XST_DutyPerson;
        this.Tbx_Remarks.Text = model.XST_Remarks;

    }
    private bool SetValue(KNet.Model.Xs_Sales_Task model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text == "")
            {
                model.XST_ID = base.GetNewID("Xs_Sales_Task", 1);
            }
            else
            {
                model.XST_ID = this.Tbx_ID.Text;
            }
            model.XST_Topic = this.Tbx_Topic.Text;
            model.XST_State = this.Ddl_State.SelectedValue;
            model.XST_Claim = this.Ddl_Claim.SelectedValue;
            model.XST_ISModiy = int.Parse(this.Ddl_IsModiy.SelectedValue);
            if (this.Tbx_BeginTime.Text != "")
            {
                model.XST_BeginTime = DateTime.Parse(this.Tbx_BeginTime.Text);
            }
            if (this.Tbx_EndTime.Text != "")
            {
                model.XST_EndTime = DateTime.Parse(this.Tbx_EndTime.Text);
            }
            model.XST_Executor = this.Tbx_ExecutorValue.Text;
            model.XST_DutyPerson = this.Ddl_DutyPerson.SelectedValue;

            model.XST_Remarks = this.Tbx_Remarks.Text;
            model.XST_Creator = AM.KNet_StaffNo;
            model.XST_CTime = DateTime.Now;
            model.XST_Mender = AM.KNet_StaffNo;
            model.XST_MTime = DateTime.Now;
             

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

        KNet.Model.Xs_Sales_Task model = new KNet.Model.Xs_Sales_Task();
        KNet.BLL.Xs_Sales_Task bll = new KNet.BLL.Xs_Sales_Task();
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
                AM.Add_Logs("客户任务计划 增加" + this.Tbx_ID.Text);
                AlertAndRedirect("新增成功！", "Xs_Sales_Task_List.aspx");
            }
            catch { }
        }
        else
        {
            try
            {
                bll.Update(model);
                AM.Add_Logs("客户任务计划 修改" + this.Tbx_ID.Text);
                AlertAndRedirect("修改成功！", "Xs_Sales_Task_List.aspx");
            }
            catch { }
        }
    }
}
