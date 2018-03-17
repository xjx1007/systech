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

            this.Tbx_ID.Text = s_ID;
            base.Base_DropDutyPerson(this.Ddl_DutyPerson);
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
        KNet.BLL.CG_ApplicationPayment_For bll = new KNet.BLL.CG_ApplicationPayment_For();
        KNet.Model.CG_ApplicationPayment_For model = bll.GetModel(s_ID);
        if (model != null)
        {
            this.Tbx_ID.Text = model.CAF_ID;
            this.Tbx_Code.Text = model.CAF_Code;
            this.Tbx_Title.Text = model.CAF_Title;
            this.Ddl_DutyPerson.SelectedValue = model.CAF_DutyPerson;
            this.Tbx_Remarks.Text = model.CAF_Remarks;
            this.Tbx_Stime.Text = DateToString(model.CAF_STime.ToShortDateString());
            ShowDetails();
            if ((AM.KNet_StaffDepart == "129652784116845798") || (AM.KNet_StaffDepart == "129652783693249229") || (AM.KNet_StaffDepart == "130143946428906250") || (AM.KNet_StaffDepart == "129652784259578018"))//财务部
            {
                this.btn_Chcek.Visible = true;
                this.Button1.Visible = true;
            }
            else
            {
                this.btn_Chcek.Visible = false;
                this.Button1.Visible = false;
            }

        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            KNet.BLL.CG_ApplicationPayment_For Bll_For = new KNet.BLL.CG_ApplicationPayment_For();
            KNet.Model.CG_ApplicationPayment_For Model_For = Bll_For.GetModel(this.Tbx_ID.Text);
            this.BeginQuery("Select * from CG_Payment_For where CPF_MainFID='" + this.Tbx_Code.Text + "'");
            DataTable Dtb_Table = this.QueryForDataTable();
            if (Dtb_Table.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
                    KNet.BLL.CG_Payment_For bll = new KNet.BLL.CG_Payment_For();
                    KNet.Model.CG_Payment_For model = bll.GetModel(Dtb_Table.Rows[i]["CPF_ID"].ToString());
                    if ( (AM.KNet_StaffDepart == "129652784259578018"))//财务部
                    {
                        model.CPF_CwDateTime = DateTime.Now;
                        model.CPF_CwPerson = AM.KNet_StaffNo;
                        model.CPF_State = 3;
                        bll.Update(model);

                        AddFlow(Dtb_Table.Rows[0]["CPF_ID"].ToString(), 1);
                        if (i == 0)
                        {
                            AddFlow(this.Tbx_ID.Text, 1);
                            base.Base_SendMessage(model.CPF_DutyPerson, "您的月度用款申请不通过： <a href='/Web/CG/MonthPayment/CG_ApplicationPayment_For_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + Model_For.CAF_Title + "</a> 需要你审批！ ");
                        }

                        AM.Add_Logs("用款申请审批：财务部:" + model.CPF_ID + "");
                    }
                    else if ((AM.KNet_StaffDepart == "129652784116845798") || (AM.KNet_StaffDepart == "130143946428906250") || (AM.KNet_StaffDepart == "129652784259578018"))//财务部
                    {
                        model.CPF_CwDateTime = DateTime.Now;
                        model.CPF_CwPerson = AM.KNet_StaffNo;
                        model.CPF_State = 3;
                        bll.Update(model);

                        AddFlow(Dtb_Table.Rows[0]["CPF_ID"].ToString(), 1);
                        if (i == 0)
                        {
                            AddFlow(this.Tbx_ID.Text, 1);
                            base.Base_SendMessage(model.CPF_DutyPerson, "您的月度用款申请不通过： <a href='/Web/CG/MonthPayment/CG_ApplicationPayment_For_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + Model_For.CAF_Title + "</a> 需要你审批！ ");
                        }

                        AM.Add_Logs("用款申请审批：财务部:" + model.CPF_ID + "");
                    }
                    else if (AM.KNet_StaffDepart == "129652783693249229")//总经理
                    {
                        model.CPF_ZDateTime = DateTime.Now;
                        model.CPF_ZPerson = AM.KNet_StaffNo;
                        model.CPF_State = 4;
                        bll.Update(model);

                        AddFlow(Dtb_Table.Rows[0]["CPF_ID"].ToString(), 2);
                        if (i == 0)
                        {
                            AddFlow(this.Tbx_ID.Text, 2);
                            base.Base_SendMessage(model.CPF_DutyPerson, "您的月度用款申请不通过： <a href='/Web/CG/MonthPayment/CG_ApplicationPayment_For_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + Model_For.CAF_Title + "</a> 需要你审批！ ");

                        }
                        AM.Add_Logs("用款申请审批：总经理:" + model.CPF_ID + "");
                    }
                    AlertAndClose("审批成功！");
                }
            }
        }
        catch { }
    }
    protected void btn_Chcek_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        try
        {
            KNet.BLL.CG_ApplicationPayment_For Bll_For = new KNet.BLL.CG_ApplicationPayment_For();
            KNet.Model.CG_ApplicationPayment_For Model_For = Bll_For.GetModel(this.Tbx_ID.Text);
            this.BeginQuery("Select * from CG_Payment_For where CPF_MainFID='" + this.Tbx_Code.Text + "'");
            DataTable Dtb_Table = this.QueryForDataTable();
            if (Dtb_Table.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
                    KNet.BLL.CG_Payment_For bll = new KNet.BLL.CG_Payment_For();
                    KNet.Model.CG_Payment_For model = bll.GetModel(Dtb_Table.Rows[i]["CPF_ID"].ToString());
                    //130143946428906250 人事管理部

                    if (AM.KNet_StaffDepart == "129652784259578018")//供应链
                    {
                        model.CPF_CwDateTime = DateTime.Now;
                        model.CPF_CwPerson = AM.KNet_StaffNo;
                        model.CPF_State = 1;
                        bll.Update(model);
                        AddFlow(Dtb_Table.Rows[i]["CPF_ID"].ToString(), 1);
                        if (i == 0)
                        {
                            AddFlow(this.Tbx_ID.Text, 1);
                            base.Base_SendMessage(base.Base_GetDeptPerson("总经理", 1), "月度用款申请审批： <a href='/Web/CG/MonthPayment/CG_ApplicationPayment_For_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + Model_For.CAF_Title + "</a> 需要你审批！ ");
                        }

                    }
                    else if ((AM.KNet_StaffDepart == "129652784116845798") || (AM.KNet_StaffDepart == "130143946428906250"))//财务部
                    {
                        model.CPF_CwDateTime = DateTime.Now;
                        model.CPF_CwPerson = AM.KNet_StaffNo;
                        model.CPF_State = 1;
                        bll.Update(model);
                        AddFlow(Dtb_Table.Rows[i]["CPF_ID"].ToString(), 1);
                        if (i == 0)
                        {
                            AddFlow(this.Tbx_ID.Text, 1);
                            base.Base_SendMessage(base.Base_GetDeptPerson("总经理", 1), "月度用款申请审批： <a href='/Web/CG/MonthPayment/CG_ApplicationPayment_For_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + Model_For.CAF_Title + "</a> 需要你审批！ ");


                        }

                    }
                    else if (AM.KNet_StaffDepart == "129652783693249229")//总经理
                    {
                        model.CPF_ZDateTime = DateTime.Now;
                        model.CPF_ZPerson = AM.KNet_StaffNo;
                        model.CPF_State = 2;
                        AddFlow(Dtb_Table.Rows[0]["CPF_ID"].ToString(), 2);
                        if (i == 0)
                        {
                            AddFlow(this.Tbx_ID.Text, 2);
                            base.Base_SendMessage(model.CPF_DutyPerson, "您的月度用款申请已通过： <a href='/Web/CG/MonthPayment/CG_ApplicationPayment_For_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + Model_For.CAF_Title + "</a> 需要你审批！ ");
                        }
                        bll.Update(model);
                        Model_For.CAF_State = 2;
                        Bll_For.Update(Model_For);
                    }
                }

            }
            AlertAndClose("审批成功！");
        }
        catch (Exception ex) { }
    }


    public string GetName(string s_ID, string s_Name)
    {
        string s_Return = "";
        if (s_ID == "")
        {
            s_Return = s_Name;
        }
        else
        {
            if (base.Base_GetCustomerName(s_ID) == "--")
            {
                s_Return = base.Base_GetSupplierName_Link(s_ID);
            }
            else
            {
                s_Return = base.Base_GetCustomerName_Link(s_ID);
            }
        }
        return s_Return;
    }
    public void ShowDetails()
    {

        StringBuilder Sb_Str = new StringBuilder();
        KNet.BLL.CG_Payment_For Bll = new KNet.BLL.CG_Payment_For();
        DataSet Dts_Table = Bll.GetList("  CPF_MainFID='" + this.Tbx_Code.Text + "'  order by CPF_CTIme");
        decimal d_TotalMoney = 0;
        if (Dts_Table.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
            {
                string s_Name = Dts_Table.Tables[0].Rows[i]["CPF_Used"].ToString();
                string s_ReceiveName = GetName(Dts_Table.Tables[0].Rows[i]["CPF_SuppNo"].ToString(), Dts_Table.Tables[0].Rows[i]["CPF_SuppNoName"].ToString());
                string s_STime = DateTime.Parse(Dts_Table.Tables[0].Rows[i]["CPF_YTime"].ToString()).ToShortDateString();
                string s_DutyPerson = base.Base_GetUserName(Dts_Table.Tables[0].Rows[i]["CPF_DutyPerson"].ToString()).ToString();
                string s_Money = Dts_Table.Tables[0].Rows[i]["CPF_LowerCase"].ToString();


                string s_DID = Dts_Table.Tables[0].Rows[i]["CPF_ID"].ToString();
                string s_FID = Dts_Table.Tables[0].Rows[i]["CPF_MainFID"].ToString();
                string s_EditImage = "<a target=\"_blank\" href=\"../Payment/CG_Payment_For_Add.aspx?ID=" + s_DID + "\"><img  border=\"0\"  style=\"cursor: pointer;\" onclick=\"comb(this,'p',531)\" src=\"../../../images/EditDetail.gif\"/></a>";

                string s_DeleteImage = "";
                s_DeleteImage = "<a  href=\"CG_ApplicationPayment_For_Add.aspx?DID=" + s_DID + "\"><img border=\"0\"  style=\"cursor: pointer;\" onclick=\"comb(this,'p',531)\" src=\"../../../images/deleteDetail.gif\"/></a>";
                Sb_Str.Append("<tr>\n");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + (i + 1) + "</td>");
                Sb_Str.Append("<td class=\"ListHeadDetails\"><a target=\"_blank\" href=\"../Payment/CG_Payment_For_View.aspx?ID=" + s_DID + "\">" + s_Name + "</a></td>");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_ReceiveName + "</td>");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_STime + "</td>");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_DutyPerson + "</td>");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_Money + "</td>");
                d_TotalMoney += decimal.Parse(s_Money);
                Sb_Str.Append("<td>");
                Sb_Str.Append("</tr>\n");
                if (GetDetails(s_DID) != "")
                {
                    Sb_Str.Append(GetDetails(s_DID));
                }
            }

            Sb_Str.Append("<tr>\n");
            Sb_Str.Append("<td class=\"ListHeadDetails\" colspan=5>合计</td>");
            Sb_Str.Append("<td class=\"ListHeadDetails\">" + d_TotalMoney + "</td>");
            Sb_Str.Append("<td>");
            Sb_Str.Append("<tr>\n");
        }
        this.Tbx_Money.Text = d_TotalMoney.ToString();
        this.Lbl_Details.Text = Sb_Str.ToString();
    }

    private string GetDetails(string s_ID)
    {
        StringBuilder Sb_Str = new StringBuilder();
        KNet.BLL.CG_Payment_For Bll = new KNet.BLL.CG_Payment_For();
        DataSet Dts_Table = Bll.GetList("  CPF_MainFID='" + s_ID + "' order by CPF_MTime");
        if (Dts_Table.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
            {

                string s_Name = Dts_Table.Tables[0].Rows[i]["CPF_Used"].ToString();
                string s_ReceiveName = GetName(Dts_Table.Tables[0].Rows[i]["CPF_SuppNo"].ToString(), Dts_Table.Tables[0].Rows[i]["CPF_SuppNoName"].ToString());
                string s_STime = DateTime.Parse(Dts_Table.Tables[0].Rows[i]["CPF_YTime"].ToString()).ToShortDateString();
                string s_DutyPerson = base.Base_GetUserName(Dts_Table.Tables[0].Rows[i]["CPF_DutyPerson"].ToString()).ToString();
                string s_Money = Dts_Table.Tables[0].Rows[i]["CPF_LowerCase"].ToString();


                string s_DID = Dts_Table.Tables[0].Rows[i]["CPF_ID"].ToString();
                string s_FID = Dts_Table.Tables[0].Rows[i]["CPF_MainFID"].ToString();
                string s_EditImage = "<a target=\"_blank\" href=\"../Payment/CG_Payment_For_Add.aspx?ID=" + s_DID + "\"><img  border=\"0\"  style=\"cursor: pointer;\" onclick=\"comb(this,'p',531)\" src=\"../../../images/EditDetail.gif\"/></a>";

                string s_DeleteImage = "";
                s_DeleteImage = "<a  href=\"CG_ApplicationPayment_For_Add.aspx?DID=" + s_DID + "\"><img border=\"0\"  style=\"cursor: pointer;\" onclick=\"comb(this,'p',531)\" src=\"../../../images/deleteDetail.gif\"/></a>";
                Sb_Str.Append("<tr>\n");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_Name + "</td>");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_ReceiveName + "</td>");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_STime + "</td>");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_DutyPerson + "</td>");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_Money + "</td>");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_EditImage + "</td>");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_DeleteImage + "</td>");

                Sb_Str.Append("<td>");
                Sb_Str.Append("<tr>\n");
                if (GetDetails(s_DID) != "")
                {
                    Sb_Str.Append(GetDetails(s_DID));
                }
            }
        }
        return Sb_Str.ToString();
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
