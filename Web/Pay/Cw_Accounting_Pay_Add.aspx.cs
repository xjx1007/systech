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


public partial class Cw_Accounting_Pay_Add : BasePage
{
    public string s_MyTable_Detail = "", s_BillDetails = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        Ajax.Utility.RegisterTypeForAjax(typeof(Cw_Accounting_Pay_Add));
        if (!Page.IsPostBack)
        {
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string s_PayMentID = Request.QueryString["PayMentID"] == null ? "" : Request.QueryString["PayMentID"].ToString();
            string s_FID = Request.QueryString["FID"] == null ? "" : Request.QueryString["FID"].ToString();
            this.Tbx_FID1.Text = s_FID;
            this.Tbx_ID.Text = s_ID;

            base.Base_DropBasicCodeBind(this.Ddl_Type, "767");
            this.Ddl_Type.SelectedValue = "0";
            if (s_ID == "")//新增
            {
                this.Lbl_Title.Text = "新增付款单";
                base.Base_DropDutyPerson(this.Ddl_DutyPerson);
                //base.Base_DropBasicCodeBind(this.Ddl_State, "172", false);
                this.Tbx_PayTime.Text = DateTime.Now.ToShortDateString();
                this.Tbx_FID.Text = GetCwCode(1);
                Base_DdlBankbind(this.Ddl_Account);
                Ddl_Account.SelectedValue = "129780760640657452";
            }
            else
            {
                this.Tbx_ID.Text = s_ID;
                this.Lbl_Title.Text = "修改付款单";
                base.Base_DropDutyPerson(this.Ddl_DutyPerson);
                Base_DdlBankbind(this.Ddl_Account);
                // base.Base_DropBasicCodeBind(this.Ddl_State, "172", false);
                this.Tbx_PayTime.Text = DateTime.Now.ToShortDateString();
                ShowInfo(s_ID);
            }
            if (AM.CheckLogin(this.Lbl_Title.Text) == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
            if (s_FID != "")
            {
                KNet.BLL.CG_Payment_For Bll_For = new KNet.BLL.CG_Payment_For();
                KNet.Model.CG_Payment_For Model_For = Bll_For.GetModel(s_FID);
                this.Tbx_SuppNo.Text = Model_For.CPF_SuppNo;
                this.Tbx_SuppName.Text = Model_For.CPF_SuppNoName;
                this.Tbx_Money.Text = Model_For.CPF_Lowercase.ToString();
                this.Tbx_Details.Text = Model_For.CPF_Used;
                if (Model_For.CPF_UseType == "4")
                {
                    this.Ddl_Type.SelectedValue = "3";
                }
                bindPayment();
                this.Tbx_YFOutDate.Text = Model_For.CPF_OutDateTime.ToShortDateString();
            }
            if (s_PayMentID != "")
            {
                KNet.BLL.Cw_Accounting_Payment Bll = new KNet.BLL.Cw_Accounting_Payment();
                DataSet Dts_Table = Bll.GetList(" a.CAP_ID='" + s_PayMentID + "' ");
                if (Dts_Table.Tables[0].Rows.Count > 0)
                {
                    this.Tbx_SuppNo.Text = Dts_Table.Tables[0].Rows[0]["CAP_CustomerValue"].ToString();
                    this.Tbx_SuppName.Text = base.Base_GetSupplierName(Dts_Table.Tables[0].Rows[0]["CAP_CustomerValue"].ToString());
                }
                decimal d_TotalMoney = 0;
                for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                {
                    d_TotalMoney += decimal.Parse(Dts_Table.Tables[0].Rows[0]["CAP_ReceiveMoney"].ToString());
                }
                this.Tbx_Money.Text = d_TotalMoney.ToString();
                this.MyGridView1.DataSource = Dts_Table;
                this.MyGridView1.DataKeyNames = new string[] { "CAP_ID" };
                this.MyGridView1.DataBind();
            }
        }
    }

    private void ShowInfo(string s_ID)
    {
        KNet.BLL.Cw_Accounting_Pay bll = new KNet.BLL.Cw_Accounting_Pay();
        KNet.Model.Cw_Accounting_Pay Model = bll.GetModel(s_ID);
        try
        {
            this.Tbx_FID1.Text = Model.CAA_FID;
            this.Tbx_FID.Text = Model.CAA_Code;
            this.Ddl_DutyPerson.SelectedValue = Model.CAA_DutyPerson;
            this.Tbx_SuppNo.Text = Model.CAA_CustomerValue;
            this.Tbx_SuppName.Text = base.Base_GetSupplierOrCustomerName(Model.CAA_CustomerValue);
            this.Ddl_Account.SelectedValue = Model.CAA_Account;
            this.Tbx_PayTime.Text = DateTime.Parse(Model.CAA_PayTime.ToString()).ToShortDateString();
            this.Tbx_Money.Text = Model.CAA_PayMoney.ToString();
            this.Tbx_Details.Text = Model.CAA_Details.ToString();
            this.Ddl_Type.SelectedValue = Model.CAP_Type.ToString();
            this.BeginQuery(" Select a.*,c.CAP_PayMoney-b.CAY_PayMoney as CAP_PayMoney,c.CAP_ReceiveMoney-c.CAP_PayMoney+b.CAY_PayMoney as leftMoney from Cw_Accounting_Payment a join Cw_Accounting_Pay_details b on a.CAP_ID=b.CAY_CAPID join v_Pay_Sum c on c.CAP_ID=a.CAP_ID where CAY_CAAID='" + s_ID + "'");
            this.QueryForDataSet();
            DataSet Dts_table = this.Dts_Result;

            if (this.Ddl_Account.SelectedValue == "129780760640657453")
            {
                Pan_Bill.Visible = true;

            }
            else
            {
                Pan_Bill.Visible = false;
            }

            //应付票据的话
            if (this.Ddl_Account.SelectedItem.Text.IndexOf("应付票据") == 0)
            {
                this.Tbx_YFBillCode.Text = Model.CAP_YFBillCode;
                this.Pan_YFBill.Visible = true;
            }
            else
            {
                Pan_YFBill.Visible = false;
            }
            Tbx_YFOutDate.Text = base.DateToString(Model.CAP_YFOutDate.ToString());
            bindPayment();
            this.MyGridView1.DataSource = Dts_table;
            this.MyGridView1.DataKeyNames = new string[] { "CAP_ID" };
            this.MyGridView1.DataBind();
            //现有
            string s_Sql = " Select * from Cw_Bill_Details where CBD_FID='" + Model.CAA_ID + "' and CBD_Type='1'";
            this.BeginQuery(s_Sql);
            DataTable Dtb_Bill = (DataTable)this.QueryForDataTable();
            for (int i = 0; i < Dtb_Bill.Rows.Count; i++)
            {
                this.Lbl_Details1.Text += "<tr>";
                this.Lbl_Details1.Text += "<td class=\"ListHeadDetails\">";
                this.Lbl_Details1.Text += "<A onclick=\"deleteRow2(this)\" href=\"#\"><img src=\"/themes/softed/images/delete.gif\"  border=0></a>";
                this.Lbl_Details1.Text += "</td >";
                this.Lbl_Details1.Text += "<td class=\"ListHeadDetails\">";
                this.Lbl_Details1.Text += "<input  type=\"text\" Class=\"Custom_Hidden\" Name=\"Tbx_BillID_" + i.ToString() + "\" value=\"" + Dtb_Bill.Rows[i]["CBD_ReceID"].ToString() + "\" ><input  type=\"text\" Class=\"Custom_Hidden\" Name=\"Tbx_BillCode_" + i.ToString() + "\" value=\"" + Dtb_Bill.Rows[i]["CBD_BillCode"].ToString() + "\" >" + Dtb_Bill.Rows[i]["CBD_BillCode"].ToString();
                this.Lbl_Details1.Text += "</td>";
                this.Lbl_Details1.Text += "<td class=\"ListHeadDetails\">";
                this.Lbl_Details1.Text += "<input  type=\"text\"   Class=\"Custom_Hidden\"  Name=\"Tbx_BillStartDateTime_" + i.ToString() + "\" value=\"" + base.DateToString(Dtb_Bill.Rows[i]["CBD_BeginTime"].ToString()) + "\"  >" + base.DateToString(Dtb_Bill.Rows[i]["CBD_BeginTime"].ToString());
                this.Lbl_Details1.Text += "</td>";
                this.Lbl_Details1.Text += "<td class=\"ListHeadDetails\">";
                this.Lbl_Details1.Text += "<input  type=\"text\"   Class=\"Custom_Hidden\"  Name=\"Tbx_BillEndDateTime_" + i.ToString() + "\" value=\"" + base.DateToString(Dtb_Bill.Rows[i]["CBD_EndTime"].ToString()) + "\">" + base.DateToString(Dtb_Bill.Rows[i]["CBD_EndTime"].ToString());
                this.Lbl_Details1.Text += "</td>";
                this.Lbl_Details1.Text += "<td class=\"ListHeadDetails\">";

                this.Lbl_Details1.Text += "<input  type=\"text\"  Class=\"Custom_Hidden\"   Name=\"Tbx_BillMoney_" + i.ToString() + "\" value=\"" + base.FormatNumber1(Dtb_Bill.Rows[i]["CBD_Money"].ToString(), 2) + "\">" + base.FormatNumber1(Dtb_Bill.Rows[i]["CBD_Money"].ToString(), 2);
                this.Lbl_Details1.Text += "</td>";
                this.Lbl_Details1.Text += "<td class=\"ListHeadDetails\">";

                this.Lbl_Details1.Text += "<input  type=\"text\"  Class=\"Custom_Hidden\"   Name=\"Tbx_BillDetails_" + i.ToString() + "\" value=\"" + Dtb_Bill.Rows[i]["CBD_Details"].ToString() + "\">" + Dtb_Bill.Rows[i]["CBD_Details"].ToString();
                this.Lbl_Details1.Text += "</td>";
                this.Lbl_Details1.Text += "<td class=\"ListHeadDetails\">";

                this.Lbl_Details1.Text += "<input  type=\"text\"  Class=\"Custom_Hidden\"   Name=\"Tbx_BillFrom_" + i.ToString() + "\" value=\"" + Dtb_Bill.Rows[i]["CBD_From"].ToString() + "\">" + Dtb_Bill.Rows[i]["CBD_From"].ToString();
                this.Lbl_Details1.Text += "</td>";
                this.Lbl_Details1.Text += "<tr>";

            }

            this.BillNum.Text = Convert.ToString(Dtb_Bill.Rows.Count + 1);



            string s_Sql1 = " Select * from Cw_Bill_Details where CBD_FID='" + Model.CAA_ID + "' and CBD_Type='0'";
            this.BeginQuery(s_Sql1);
            DataTable Dtb_Bill1 = (DataTable)this.QueryForDataTable();
            for (int i = 0; i < Dtb_Bill1.Rows.Count; i++)
            {
                this.Lbl_Details2.Text += "<tr>";
                this.Lbl_Details2.Text += "<td class=\"ListHeadDetails\">";
                this.Lbl_Details2.Text += "<A onclick=\"DeleteRow(this)\" href=\"#\"><img src=\"/themes/softed/images/delete.gif\"  border=0></a>";
                this.Lbl_Details2.Text += "</td >";
                this.Lbl_Details2.Text += "<td class=\"ListHeadDetails\">";
                this.Lbl_Details2.Text += "<input  type=\"text\" Class=\"Custom_Hidden\" Name=\"BillID_" + i.ToString() + "\" value=\"" + Dtb_Bill1.Rows[i]["CBD_ID"].ToString() + "\" ><input  type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\"  style=\"width:100px;\"   Name=\"BillCode_" + i.ToString() + "\"  value=\"" + Dtb_Bill1.Rows[i]["CBD_BillCode"].ToString() + "\">";
                this.Lbl_Details2.Text += "</td>";
                this.Lbl_Details2.Text += "<td class=\"ListHeadDetails\">";
                this.Lbl_Details2.Text += "<input  type=\"text\"    CssClass=\"Wdate\" onFocus=\"WdatePicker()\"  Name=\"BillStartDateTime_" + i.ToString() + "\" value=\"" + base.DateToString(Dtb_Bill1.Rows[i]["CBD_BeginTime"].ToString()) + "\"  >";
                this.Lbl_Details2.Text += "</td>";
                this.Lbl_Details2.Text += "<td class=\"ListHeadDetails\">";
                this.Lbl_Details2.Text += "<input  type=\"text\"    CssClass=\"Wdate\" onFocus=\"WdatePicker()\"  Name=\"BillEndDateTime_" + i.ToString() + "\" value=\"" + base.DateToString(Dtb_Bill1.Rows[i]["CBD_EndTime"].ToString()) + "\">";
                this.Lbl_Details2.Text += "</td>";
                this.Lbl_Details2.Text += "<td class=\"ListHeadDetails\">";

                this.Lbl_Details2.Text += "<input  type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\"  style=\"width:100px;\"    Name=\"BillMoney_" + i.ToString() + "\" value=\"" + base.FormatNumber1(Dtb_Bill1.Rows[i]["CBD_Money"].ToString(), 2) + "\">";
                this.Lbl_Details2.Text += "</td>";
                this.Lbl_Details2.Text += "<td class=\"ListHeadDetails\">";

                this.Lbl_Details2.Text += "<input  type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\"  style=\"width:100px;\"    Name=\"Tbx_BillDetails_" + i.ToString() + "\" value=\"" + Dtb_Bill1.Rows[i]["CBD_Details"].ToString() + "\">";
                this.Lbl_Details2.Text += "</td>";
                this.Lbl_Details2.Text += "<td class=\"ListHeadDetails\">";

                this.Lbl_Details2.Text += "<input  type=\"text\"  Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\"  style=\"width:100px;\"    Name=\"Tbx_BillFrom_" + i.ToString() + "\" value=\"" + Dtb_Bill1.Rows[i]["CBD_From"].ToString() + "\">";
                this.Lbl_Details2.Text += "</td>";
                this.Lbl_Details2.Text += "<tr>";

            }

            this.Tbx_NewBillNum.Text = Convert.ToString(Dtb_Bill1.Rows.Count + 1);


        }
        catch (Exception ex)
        { }
    }
    private bool SetValue(KNet.Model.Cw_Accounting_Pay model)
    {
        AdminloginMess AM = new AdminloginMess();
        try
        {
            ArrayList arr_Details = new ArrayList();

            model.CAA_CustomerValue = this.Tbx_SuppNo.Text;
            model.CAA_Account = this.Ddl_Account.SelectedValue;
            model.CAA_DutyPerson = this.Ddl_DutyPerson.SelectedValue;
            model.CAA_PayMoney = decimal.Parse(this.Tbx_Money.Text);
            model.CAA_PayTime = DateTime.Parse(this.Tbx_PayTime.Text);
            model.CAA_Details = this.Tbx_Details.Text;
            model.CAA_Creator = AM.KNet_StaffNo;
            model.CAA_CTime = DateTime.Now;
            model.CAA_MTime = DateTime.Now;
            model.CAA_Mender = AM.KNet_StaffNo;
            model.CAA_Code = this.Tbx_FID.Text;
            model.CAA_FID = this.Tbx_FID1.Text;
            model.CAP_Type = int.Parse(this.Ddl_Type.SelectedValue);
            model.CAA_BillCode = "";
            try
            {
                model.CAA_StartDateTime = DateTime.Parse("1900-1-1"); ;
                model.CAA_EndDateTime = DateTime.Parse("1900-1-1"); ;
            }
            catch
            {
                model.CAA_StartDateTime = DateTime.Parse("1900-1-1"); ;
                model.CAA_EndDateTime = DateTime.Parse("1900-1-1"); ;
            }
            
                try
                {
                    model.CAP_YFOutDate = DateTime.Parse(Tbx_YFOutDate.Text);
                }
                catch
                {
                    model.CAP_YFOutDate = DateTime.Parse("1900-1-1");
                }
            //应付票据的话
            if (this.Ddl_Account.SelectedItem.Text.IndexOf("应付票据") == 0)
            {
                model.CAP_YFBillCode = this.Tbx_YFBillCode.Text;

            }
            for (int i = 0; i < this.MyGridView1.Rows.Count; i++)
            {
                CheckBox Chk = (CheckBox)this.MyGridView1.Rows[i].FindControl("Chbk");
                if (Chk.Checked)
                {
                    TextBox Tbx_PayMoney = (TextBox)this.MyGridView1.Rows[i].FindControl("Tbx_PayMoney");
                    string s_PayMentID = this.MyGridView1.DataKeys[i].Value.ToString();
                    KNet.Model.Cw_Accounting_Pay_Details Model_Details = new KNet.Model.Cw_Accounting_Pay_Details();
                    Model_Details.CAY_CAAID = this.Tbx_Code.Text;
                    Model_Details.CAY_PayMoney = decimal.Parse(Tbx_PayMoney.Text);
                    Model_Details.CAY_CAPID = s_PayMentID;
                    arr_Details.Add(Model_Details);
                }
            }
            model.arr_Details = arr_Details;
            ArrayList arr_Details1 = new ArrayList();
            for (int i = 0; i <= int.Parse(this.Tbx_NewBillNum.Text); i++)
            {
                //新增票据

                KNet.Model.Cw_Bill_Details Model_Bill = new KNet.Model.Cw_Bill_Details();
                //核销票据
                string s_FID = model.CAA_ID;
                string s_BillMoney = Request["BillMoney_" + i.ToString() + ""] == null ? "" : Request["BillMoney_" + i.ToString() + ""].ToString();

                string s_ID = Request["ID_" + i.ToString() + ""] == null ? "" : Request["ID_" + i.ToString() + ""].ToString();
                if (s_ID == "")
                {
                    s_ID = "T" + base.GetMainID(i);
                }
                string s_ReceID = Request["BillID_" + i.ToString() + ""] == null ? "" : Request["BillID_" + i.ToString() + ""].ToString();
                if (s_BillMoney != "")
                {
                    string s_BillCode = Request["BillCode_" + i.ToString() + ""] == null ? "" : Request["BillCode_" + i.ToString() + ""].ToString();

                    string s_BillStartDateTime = Request["BillStartDateTime_" + i.ToString() + ""] == null ? "" : Request["BillStartDateTime_" + i.ToString() + ""].ToString();

                    string s_BillEndDateTime = Request["BillEndDateTime_" + i.ToString() + ""] == null ? "" : Request["BillEndDateTime_" + i.ToString() + ""].ToString();

                    string s_BillDetails = Request["BillDetails_" + i.ToString() + ""] == null ? "" : Request["BillDetails_" + i.ToString() + ""].ToString();
                    string s_BillFrom = Request["BillFrom_" + i.ToString() + ""] == null ? "" : Request["BillFrom_" + i.ToString() + ""].ToString();

                    Model_Bill.CBD_ID = s_ID;
                    Model_Bill.CBD_FID = s_FID;
                    Model_Bill.CBD_ReCeID = "";
                    Model_Bill.CBD_BillCode = s_BillCode;
                    try
                    {
                        Model_Bill.CBD_BeginTime = DateTime.Parse(s_BillStartDateTime);
                    }
                    catch
                    {
                        Model_Bill.CBD_BeginTime = DateTime.Parse("1900-01-01");
                    }
                    try
                    {
                        Model_Bill.CBD_EndTime = DateTime.Parse(s_BillEndDateTime);
                    }
                    catch
                    {
                        Model_Bill.CBD_EndTime = DateTime.Parse("1900-01-01");
                    }
                    try
                    {
                        Model_Bill.CBD_Money = decimal.Parse(s_BillMoney);
                    }
                    catch
                    {
                        Model_Bill.CBD_Money = 0;
                    }
                    Model_Bill.CBD_Details = s_BillDetails;
                    Model_Bill.CBD_From = s_BillFrom;
                    Model_Bill.CBD_Creator = AM.KNet_StaffNo;
                    Model_Bill.CBD_CTime = DateTime.Now;
                    Model_Bill.CBD_Type = 0;
                    arr_Details1.Add(Model_Bill);
                }
            }

            for (int i = 0; i <= int.Parse(this.BillNum.Text); i++)
            {
                KNet.Model.Cw_Bill_Details Model_Bill = new KNet.Model.Cw_Bill_Details();
                //核销票据
                string s_ID = "N" + base.GetMainID(i);
                string s_FID = model.CAA_ID;
                string s_ReceID = Request["Tbx_BillID_" + i.ToString() + ""] == null ? "" : Request["Tbx_BillID_" + i.ToString() + ""].ToString();
                if (s_ReceID != "")
                {
                    string s_BillCode = Request["Tbx_BillCode_" + i.ToString() + ""] == null ? "" : Request["Tbx_BillCode_" + i.ToString() + ""].ToString();

                    string s_BillStartDateTime = Request["Tbx_BillStartDateTime_" + i.ToString() + ""] == null ? "" : Request["Tbx_BillStartDateTime_" + i.ToString() + ""].ToString();

                    string s_BillEndDateTime = Request["Tbx_BillEndDateTime_" + i.ToString() + ""] == null ? "" : Request["Tbx_BillEndDateTime_" + i.ToString() + ""].ToString();

                    string s_BillMoney = Request["Tbx_BillMoney_" + i.ToString() + ""] == null ? "" : Request["Tbx_BillMoney_" + i.ToString() + ""].ToString();
                    string s_BillDetails = Request["Tbx_BillDetails_" + i.ToString() + ""] == null ? "" : Request["Tbx_BillDetails_" + i.ToString() + ""].ToString();
                    string s_BillFrom = Request["Tbx_BillFrom_" + i.ToString() + ""] == null ? "" : Request["Tbx_BillFrom_" + i.ToString() + ""].ToString();

                    Model_Bill.CBD_ID = s_ID;
                    Model_Bill.CBD_FID = s_FID;
                    Model_Bill.CBD_ReCeID = s_ReceID;
                    Model_Bill.CBD_BillCode = s_BillCode;
                    try
                    {
                        Model_Bill.CBD_BeginTime = DateTime.Parse(s_BillStartDateTime);
                    }
                    catch
                    {
                        Model_Bill.CBD_BeginTime = DateTime.Parse("1900-01-01");
                    }
                    try
                    {
                        Model_Bill.CBD_EndTime = DateTime.Parse(s_BillEndDateTime);
                    }
                    catch
                    {
                        Model_Bill.CBD_EndTime = DateTime.Parse("1900-01-01");
                    }
                    try
                    {
                        Model_Bill.CBD_Money = decimal.Parse(s_BillMoney);
                    }
                    catch
                    {
                        Model_Bill.CBD_Money = 0;
                    }
                    Model_Bill.CBD_Details = s_BillDetails;
                    Model_Bill.CBD_From = s_BillFrom;
                    Model_Bill.CBD_Creator = AM.KNet_StaffNo;
                    Model_Bill.CBD_CTime = DateTime.Now;
                    Model_Bill.CBD_Type = 1;
                    arr_Details1.Add(Model_Bill);
                }
            }
            model.arr_BillDetails = arr_Details1;
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
        KNet.Model.Cw_Accounting_Pay model = new KNet.Model.Cw_Accounting_Pay();
        KNet.BLL.Cw_Accounting_Pay bll = new KNet.BLL.Cw_Accounting_Pay();

        if (this.SetValue(model) == false)
        {
            Alert("系统错误！");
            return;
        }
        if (this.Tbx_ID.Text != "")//修改
        {
            try
            {
                model.CAA_ID = this.Tbx_ID.Text;
                bll.Update(model);
                AM.Add_Logs("付款单修改" + this.Tbx_ID.Text);
                AlertAndRedirect("修改成功！", "Cw_Accounting_Pay_List.aspx");
            }
            catch { }
        }
        else
        {
            try
            {
                model.CAA_ID = base.GetMainID();
                bll.Add(model);
                AM.Add_Logs("付款单增加" + this.Tbx_ID.Text);
                KNet.BLL.CG_Payment_For Bll_For = new KNet.BLL.CG_Payment_For();
                KNet.Model.CG_Payment_For Model_For = Bll_For.GetModel(this.Tbx_FID1.Text);
                base.Base_SendMessage(Model_For.CPF_DutyPerson, KNetPage.KHtmlEncode("有 付款申请用途为 <a href='Web/Cg/Payment/CG_Payment_For_View.aspx?ID=" + this.Tbx_FID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + Model_For.CPF_Used + "</a>  已付款，敬请关注！"));

                AlertAndRedirect("新增成功！", "Cw_Accounting_Pay_List.aspx");
            }
            catch (Exception ex) { }
        }
    }
    public string GetCwCode(int i_Num)
    {
        string s_Code = "";
        try
        {
            KNet.BLL.KNet_WareHouse_DirectOutList BLL = new KNet.BLL.KNet_WareHouse_DirectOutList();
            this.BeginQuery("Select isNUll(Max(CAA_Code),'') from Cw_Accounting_Pay Where year(CAA_PayTime)='" + DateTime.Now.Year.ToString() + "'  and Month(CAA_PayTime)='" + DateTime.Now.Month.ToString() + "'");
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                if (Dtb_Table.Rows[0][0].ToString() != "")
                {
                    s_Code = Dtb_Table.Rows[0][0].ToString().Substring(0, 6) + "-" + Convert.ToString(int.Parse("1" + Dtb_Table.Rows[0][0].ToString().Substring(7, 3)) + i_Num).Substring(1, 3);
                }
                else
                {
                    s_Code = DateTime.Today.ToString("yyyyMM") + "-001";
                }
            }
            else
            {
                s_Code = DateTime.Today.ToString("yyyyMM") + "-001";
            }
        }
        catch { }
        return s_Code;
    }
    protected void Ddl_Account_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindBill();
    }
    private void BindBill()
    {
        if (this.Ddl_Account.SelectedValue == "129780760640657453")
        {
            Pan_Bill.Visible = true;

        }
        else
        {
            Pan_Bill.Visible = false;
        }

        if (this.Ddl_Account.SelectedItem.Text.IndexOf("应付票据") == 0)
        {
            this.Pan_YFBill.Visible = true;
        }
        else
        {
            Pan_YFBill.Visible = false;
        }
    }

    [Ajax.AjaxMethod()]
    public string GetBillDetails(string s_ID)
    {
        string s_Return = "";
        try
        {
            string s_Sql = "Select * from v_BillDetails";
            s_Sql += " where CAA_ID='" + s_ID + "'";
            this.BeginQuery(s_Sql);
            DataTable Dtb_Table = this.QueryForDataTable();
            if (Dtb_Table.Rows.Count > 0)
            {
                s_Return += Dtb_Table.Rows[0]["CAA_BillCode"].ToString() + ",";
                try
                {
                    s_Return += base.DateToString(Dtb_Table.Rows[0]["CAA_StartDateTime"].ToString()) + ",";
                }
                catch
                {
                    s_Return += "" + ",";
                }
                try
                {
                    s_Return += base.DateToString(Dtb_Table.Rows[0]["CAA_EndDateTime"].ToString()) + ",";
                }
                catch
                {
                    s_Return += "" + ",";
                }
                s_Return += Dtb_Table.Rows[0]["CAA_PayMoney"].ToString() + ",";
                s_Return += Dtb_Table.Rows[0]["CAA_Details"].ToString() + ",";
                s_Return += base.Base_GetSupplierOrCustomerName(Dtb_Table.Rows[0]["CAA_CustomerValue"].ToString()) + ",";
                s_Return += Dtb_Table.Rows[0]["CAA_ID"].ToString() + ",";
            }
            return s_Return;
        }
        catch
        {
            return s_Return;
        }
    }
    private void bindPayment()
    {
        
        if (Ddl_Type.SelectedValue == "3")
        {
            Pan_BillID.Visible = false;
            Pan_YFBill.Visible = true;

        }
        else
        {
            Pan_BillID.Visible = true;
            Pan_YFBill.Visible = false;
        }
    }
    protected void Ddl_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindPayment();
    }
}
