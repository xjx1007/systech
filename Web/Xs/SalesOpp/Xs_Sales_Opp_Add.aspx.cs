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


public partial class Web_Sales_Xs_Sales_Opp_Add : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string s_CustomerValue = Request.QueryString["CustomerValue"] == null ? "" : Request.QueryString["CustomerValue"].ToString();
            base.Base_DropBasicCodeBind(this.Ddl_Type, "121");//类型
            base.Base_DropBasicCodeBind(this.Ddl_SalesStep, "118");//类型
            base.Base_DropBasicCodeBind(this.Ddl_SalesType, "202", false);//类型
            this.Ddl_SalesType.SelectedValue = "2";

            this.Tbx_PlanDealDate.Text = DateTime.Now.ToShortDateString();
            base.Base_DropDutyPerson(this.Ddl_DutyPerson, " and IsSale='1' ");
            base.Base_DropDutyPerson(this.Ddl_FDutyPerson, " and IsSale='1' ");
            base.Base_DropBasicCodeBind(this.Ddl_Precent, "154", false);
            base.Base_DropLinkManBind(this.Ddl_LinkMan, this.Tbx_CustomerValue.Value);
            this.Lbl_Title.Text = "新增销售机会";
            if (s_ID != "")
            {
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制销售机会";

                }
                else
                {
                    this.Lbl_Title.Text = "修改销售机会";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }
            else
            {
                if (s_CustomerValue != "")
                {
                    this.Tbx_CustomerValue.Value = s_CustomerValue;
                    this.Tbx_CustomerName.Text = base.Base_GetCustomerName(s_CustomerValue);
                }

            }

            //销售机会列表
            if (AM.CheckLogin(this.Lbl_Title.Text) == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
        }
    }

    private void ShowInfo(string s_ID)
    {
        KNet.BLL.Xs_Sales_Opp bll = new KNet.BLL.Xs_Sales_Opp();
        KNet.Model.Xs_Sales_Opp model = bll.GetModel(s_ID);
        this.Tbx_Name.Text = model.XSO_Name;
        this.Tbx_CustomerValue.Value = model.XSO_CustomerValue;
        base.Base_DropLinkManBind(this.Ddl_LinkMan, this.Tbx_CustomerValue.Value);
        this.Tbx_CustomerName.Text = base.Base_GetCustomerName(model.XSO_CustomerValue);
        this.Ddl_LinkMan.SelectedValue = model.XSO_LinkMan;
        this.Ddl_DutyPerson.SelectedValue = model.XSO_DutyPerson;
        this.Ddl_Type.SelectedValue = model.XSO_Type;
        this.Ddl_Precent.Text = model.XSO_Precent;
        this.Tbx_NextPlan.Text = model.XSO_NextPlan;
        this.Ddl_SalesStep.SelectedValue = model.XSO_SalesStep;
        this.Tbx_Remarks.Text = model.XSO_Remarks;

        this.Ddl_FDutyPerson.SelectedValue = model.XSO_FDutyPerson;
        this.Tbx_Background.Text = model.XSO_Background;
        this.Tbx_History.Text = model.XSO_History;
        this.Tbx_Competitor.Text = model.XSO_Competitor;
        this.Ddl_SalesType.SelectedValue = model.XSO_SalesType;
    }
    private bool SetValue(KNet.Model.Xs_Sales_Opp model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text == "")
            {
                model.XSO_ID = base.GetNewID("Xs_Sales_Opp", 1);
            }
            else
            {
                model.XSO_DID = this.Tbx_ID.Text;
            }
            model.XSO_Name = this.Tbx_Name.Text;
            if (this.Tbx_PlanDealDate.Text != "")
            {
                model.XSO_PlanDealDate = DateTime.Parse(this.Tbx_PlanDealDate.Text);
            }

            model.XSO_CustomerValue = this.Tbx_CustomerValue.Value;
            model.XSO_LinkMan = Request["Ddl_LinkMan"];
            model.XSO_DutyPerson = this.Ddl_DutyPerson.SelectedValue;
            model.XSO_Type = this.Ddl_Type.SelectedValue;
            model.XSO_Precent = this.Ddl_Precent.SelectedValue;
            model.XSO_SalesStep = this.Ddl_SalesStep.SelectedValue;
            model.XSO_Remarks = this.Tbx_Remarks.Text;
            model.XSO_Creator = AM.KNet_StaffNo;
            model.XSO_CTime = DateTime.Now;
            model.XSO_Mender = AM.KNet_StaffNo;
            model.XSO_MTime = DateTime.Now;
            model.XSO_NextPlan = this.Tbx_NextPlan.Text;
            model.XSO_FDutyPerson = this.Ddl_FDutyPerson.SelectedValue;
            model.XSO_Background = KNetPage.KHtmlEncode(this.Tbx_Background.Text);
            model.XSO_History = this.Tbx_History.Text;
            model.XSO_Competitor = this.Tbx_Competitor.Text;
            model.XSO_Del = 0;
            model.XSO_SalesType = this.Ddl_SalesType.SelectedValue;
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

        KNet.Model.Xs_Sales_Opp model = new KNet.Model.Xs_Sales_Opp();
        KNet.BLL.Xs_Sales_Opp bll = new KNet.BLL.Xs_Sales_Opp();

        if (this.SetValue(model) == false)
        {
            Alert("系统错误！");
            return;
        }
        string s_receive = "";
        if (this.Ddl_DutyPerson.SelectedValue != "")
        {
            s_receive = this.Ddl_DutyPerson.SelectedValue;
        }
        if (this.Ddl_FDutyPerson.SelectedValue != "")
        {
            s_receive += ","+this.Ddl_FDutyPerson.SelectedValue;
        }
        if (s_ID == "")//新增
        {
            try
            {
                bll.Add(model);
                AM.Add_Logs("销售机会增加" + this.Tbx_ID.Text);
                base.Base_SendMessage(s_receive, KNetPage.KHtmlEncode("有 新销售机会需要你跟踪 <a href='Web/SalesOpp/Xs_Sales_Opp_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + this.Tbx_Name.Text + "</a>,敬请关注！"));
                AlertAndRedirect("新增成功！", "Xs_Sales_Opp_List.aspx");
            }
            catch (Exception ex) { }
        }
        else
        {

            try
            {
                KNet.Model.Xs_Sales_Opp Model_Opp = bll.GetModel(s_ID);
                Model_Opp.XSO_Del = 1;
                bll.Add(Model_Opp);
                bll.Update(model);

                AM.Add_Logs("销售机会修改" + this.Tbx_ID.Text);
                base.Base_SendMessage(s_receive, KNetPage.KHtmlEncode("有 销售机会 推进 需要你跟踪 <a href='Web/SalesOpp/Xs_Sales_Opp_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + this.Tbx_Name.Text + "</a>,敬请关注！"));
                AlertAndRedirect("修改成功！", "Xs_Sales_Opp_List.aspx");
            }
            catch { }
        }
    }
}
