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


public partial class Web_CG_Payment_For_View : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.Lbl_Title.Text = "查看用款申请";
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            if (s_ID != "")
            {
                ShowInfo(s_ID);
            }
            this.Lbl_LinkPay.Text = "<a href=\"/Web/Pay/Cw_Accounting_Pay_Add.aspx?FID=" + s_ID + "\" class=\"webMnu\">创建付款单</a>";
        }
       
    }

    private void ShowInfo(string s_ID)
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.BLL.CG_Payment_For bll = new KNet.BLL.CG_Payment_For();
        KNet.Model.CG_Payment_For model = bll.GetModel(s_ID);
        if (model != null)
        {
            this.Tbx_ID.Text = model.CPF_ID;
            this.Tbx_Used.Text = model.CPF_Used;
            try
            {
                this.Tbx_STime.Text = model.CPF_STime.ToShortDateString();
            }
            catch { }
            this.Ddl_Currency.Text = base.Base_GetBasicCodeName("401",model.CPF_Currency);
            this.Ddl_UseType.Text =base.Base_GetBasicCodeName("402",model.CPF_UseType); 
            this.Tbx_Money.Text = model.CPF_Lowercase.ToString();
            this.Tbx_ChineseMoney.Text = model.CPF_Capital;
            this.Tbx_PayeeValue.Value = model.CPF_SuppNo;
            this.Tbx_PayeeName.Text = model.CPF_SuppNoName;

            try
            {
                this.Tbx_YTime.Text = model.CPF_YTime.ToShortDateString();
            }
            catch { }
            this.Ddl_Depart.Text = base.Base_GeDept(model.CPF_DutyDepart);
            this.Ddl_DutyPerson.Text = base.Base_GetUserName(model.CPF_DutyPerson);
            this.Tbx_Remarks.Text = model.CPF_Remarks;
            this.Tbx_Details.Text = model.CPF_Details;
            this.Tbx_BankAccount.Text = model.CPF_Account;
            this.Tbx_BankName.Text = model.CPF_Bank;

            this.Tbx_Shen.Text = model.CPF_Shen;
            this.Tbx_Shi.Text = model.CPF_Shi;

            KNet.BLL.Cw_Accounting_Pay bll_Pay = new KNet.BLL.Cw_Accounting_Pay();
            DataSet ds = bll_Pay.GetList(" CAA_FID='" + s_ID + "'");
            this.MyGridView1.DataSource = ds;
            MyGridView1.DataKeyNames = new string[] { "CAA_ID" };
            MyGridView1.DataBind();

            if ((AM.KNet_StaffDepart == "129652784116845798") || (AM.KNet_StaffDepart == "129652783693249229") || (AM.KNet_StaffDepart == "130143946428906250"))//财务部
            {
                this.btn_Chcek.Visible = true;
                this.Button1.Visible = true;
                Tr_Sp.Visible = true;
            }
            else
            {
                this.btn_Chcek.Visible = false;
                this.Button1.Visible = false;
                Tr_Sp.Visible = false;
            }

            this.Image1.ImageUrl = model.CPF_Image;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            KNet.BLL.CG_Payment_For bll = new KNet.BLL.CG_Payment_For();
            KNet.Model.CG_Payment_For model = bll.GetModel(this.Tbx_ID.Text);
            if ((AM.KNet_StaffDepart == "129652784116845798") || (AM.KNet_StaffDepart == "130143946428906250"))//财务部
            {
                model.CPF_CwDateTime = DateTime.Now;
                model.CPF_CwPerson = AM.KNet_StaffNo;
                model.CPF_State = 3;
                bll.Update(model);
                AddFlow(this.Tbx_ID.Text, 1);
                base.Base_SendMessage(model.CPF_DutyPerson, "用款申请不通过： <a href='Web/CG/Payment/CG_Payment_For_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.CPF_Used + "</a> 需要你审批！ ");

                AM.Add_Logs("用款申请审批：财务部:" + model.CPF_ID + "");
            }
            else if (AM.KNet_StaffDepart == "129652783693249229")//总经理
            {
                model.CPF_ZDateTime = DateTime.Now;
                model.CPF_ZPerson = AM.KNet_StaffNo;
                model.CPF_State = 4;
                bll.Update(model);
                AddFlow(this.Tbx_ID.Text, 2);
                base.Base_SendMessage(model.CPF_DutyPerson, "您的用款申请不通过： <a href='Web/CG/Payment/CG_Payment_For_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.CPF_Used + "</a> 需要你审批！ ");
                AM.Add_Logs("用款申请审批：总经理:" + model.CPF_ID + "");
            }
            AlertAndClose("审批成功！");
        }
        catch { }
    }
    protected void btn_Chcek_Click(object sender, EventArgs e)
    {
        AdminloginMess AM=new AdminloginMess();
        try
        {
            KNet.BLL.CG_Payment_For bll = new KNet.BLL.CG_Payment_For();
            KNet.Model.CG_Payment_For model = bll.GetModel(this.Tbx_ID.Text);
            //130143946428906250 人事管理部
            if ((AM.KNet_StaffDepart == "129652784116845798") || (AM.KNet_StaffDepart == "130143946428906250"))//财务部
            {
                model.CPF_CwDateTime = DateTime.Now;
                model.CPF_CwPerson = AM.KNet_StaffNo;
                model.CPF_State = 1;
                bll.Update(model);
                AddFlow(this.Tbx_ID.Text, 1);
                base.Base_SendMessage(base.Base_GetDeptPerson("总经理", 1), "用款申请审批： <a href='Web/CG/Payment/CG_Payment_For_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.CPF_Used + "</a> 需要你审批！ ");

            }
            else if (AM.KNet_StaffDepart == "129652783693249229")//总经理
            {
                model.CPF_ZDateTime = DateTime.Now;
                model.CPF_ZPerson = AM.KNet_StaffNo;
                model.CPF_State = 2;
                AddFlow(this.Tbx_ID.Text, 2);
                bll.Update(model);
                base.Base_SendMessage(model.CPF_DutyPerson, "您的用款申请已通过： <a href='Web/CG/Payment/CG_Payment_For_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.CPF_Used + "</a> 需要你审批！ ");
            }
            AlertAndClose("审批成功！");
        }
        catch { }
    }


    private bool AddFlow(string s_ContractNo, int i_State)
    {

        AdminloginMess AM = new AdminloginMess();
        //插入审核
        KNet.Model.KNet_Sales_Flow Model = new KNet.Model.KNet_Sales_Flow();
        KNet.BLL.KNet_Sales_Flow Bll = new KNet.BLL.KNet_Sales_Flow();
        Model.KFS_Type = 111;
        Model.KSF_ContractNo = s_ContractNo;
        Model.KSF_Date = DateTime.Now;
        Model.KSF_Detail = "";
        Model.KSF_ShPerson = AM.KNet_StaffNo;
        Model.KSF_State = i_State;
        try
        {
            if (Bll.Exists(Model) == false)
            {

                Bll.Add(Model);
                return true;
            }
            else
            {
                Alert("您已审核，请不要重复审核！");
                return false;
            }

        }
        catch
        {
            throw;
            return false;
        }
    }


}
