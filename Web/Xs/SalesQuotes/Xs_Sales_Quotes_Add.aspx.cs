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


public partial class Web_Sales_Xs_Sales_Quotes_Add : BasePage
{
    public string s_MyTable_Detail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string s_OPPID = Request.QueryString["OPPID"] == null ? "" : Request.QueryString["OPPID"].ToString();
            base.Base_DropBasicCodeBind(this.Ddl_Step, "122");//类型
            this.Tbx_STime.Text = DateTime.Now.ToShortDateString();
            base.Base_DropDutyPerson(this.Ddl_DutyPerson, " and isSale=1");
            this.Ddl_Step.SelectedValue = "101";
            if (s_ID != "")
            {
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制报价单";
                    this.Tbx_Code.Text = s_GetCode();
                }
                else
                {
                    this.Lbl_Title.Text = "修改报价单";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }
            else
            {
                this.Lbl_Title.Text = "新增报价单";
                this.Tbx_Code.Text = s_GetCode();
            }
            if (s_OPPID != "")
            {
                KNet.BLL.Xs_Sales_Opp bll_opp = new KNet.BLL.Xs_Sales_Opp();
                KNet.Model.Xs_Sales_Opp model_opp = bll_opp.GetModel(s_OPPID);
                if (model_opp != null)
                {
                    this.Tbx_SalesChanceValue.Text = s_OPPID;
                    this.Tbx_SalesChanceName.Text = model_opp.XSO_Name;
                    this.Tbx_CustomerValue.Value = model_opp.XSO_CustomerValue;
                    this.Tbx_CustomerName.Text = base.Base_GetCustomerName(model_opp.XSO_CustomerValue);
                    this.Ddl_LinkMan.SelectedValue = model_opp.XSO_LinkMan;
                }
            }
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin(this.Lbl_Title.Text) == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
            base.Base_DropLinkManBind(this.Ddl_LinkMan, this.Tbx_CustomerValue.Value);
        }
    }

    private void ShowInfo(string s_ID)
    {
        KNet.BLL.Xs_Sales_Quotes bll = new KNet.BLL.Xs_Sales_Quotes();
        KNet.Model.Xs_Sales_Quotes model = bll.GetModel(s_ID);

        string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
        if (s_Type != "1")
        {
            this.Tbx_Code.Text = model.XSQ_Code;
        }
        this.Tbx_SalesChanceValue.Text = model.XSQ_SalesChance;
        this.Tbx_SalesChanceName.Text = base.Base_GetOppName(model.XSQ_SalesChance);
        this.Tbx_CustomerValue.Value = model.XSQ_CustomerValue;
        this.Tbx_CustomerName.Text = base.Base_GetCustomerName(model.XSQ_CustomerValue);
        this.Ddl_LinkMan.SelectedValue = model.XSQ_LinkMan;
        this.Ddl_DutyPerson.SelectedValue = model.XSQ_DutyPerson;
        this.Ddl_Step.SelectedValue = model.XSQ_Step;
        this.Tbx_STime.Text = DateTime.Parse(model.XSQ_STime.ToString()).ToShortDateString();

        this.Tbx_Payment.Text = KNetPage.KHtmlDiscode(model.XSQ_Payment);
        this.Tbx_Remarks.Text = model.XSQ_Remarks;
        KNet.BLL.Xs_Sales_Quotes_Details BLL_Details = new KNet.BLL.Xs_Sales_Quotes_Details();
        DataSet Dts_Details = BLL_Details.GetList(" SQD_FID='" + model.XSQ_ID + "'");
        if (Dts_Details.Tables[0].Rows.Count > 0)
        {
            s_MyTable_Detail += "<tr>";
            for (int i = 0; i < Dts_Details.Tables[0].Rows.Count; i++)
            {
                this.Xs_ProductsCode.Text += Dts_Details.Tables[0].Rows[i]["SQD_ProductsBarCode"].ToString() + ",";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a></td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName(Dts_Details.Tables[0].Rows[i]["SQD_ProductsBarCode"].ToString()) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ProductsBarCode\" value='" + Dts_Details.Tables[0].Rows[i]["SQD_ProductsBarCode"].ToString() + "'>" + Dts_Details.Tables[0].Rows[i]["SQD_ProductsBarCode"].ToString() + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dts_Details.Tables[0].Rows[i]["SQD_ProductsBarCode"].ToString()) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Number\" value='" + Dts_Details.Tables[0].Rows[i]["SQD_Number"].ToString() + "'></td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Price\" value='" + Dts_Details.Tables[0].Rows[i]["SQD_Price"].ToString() + "'></td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Precent\" value='" + Dts_Details.Tables[0].Rows[i]["SQD_Percent"].ToString() + "'></td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"PrecentMoney\" value='" + Dts_Details.Tables[0].Rows[i]["SQD_PercentedMoney"].ToString() + "'></td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Remarks\" value='" + Dts_Details.Tables[0].Rows[i]["SQD_Remarks"].ToString() + "'></td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Money\" value='" + Dts_Details.Tables[0].Rows[i]["SQD_Money"].ToString() + "'></td>";
            }

            s_MyTable_Detail += "</tr>";
        }

    }



    private bool SetValue(KNet.Model.Xs_Sales_Quotes model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text == "")
            {
                model.XSQ_ID = base.GetNewID("Xs_Sales_Quotes", 1);
            }
            else
            {
                model.XSQ_ID = this.Tbx_ID.Text;
            }
            model.XSQ_Code = this.Tbx_Code.Text;
            model.XSQ_SalesChance = this.Tbx_SalesChanceValue.Text;
            if (this.Tbx_STime.Text != "")
            {
                model.XSQ_STime = DateTime.Parse(this.Tbx_STime.Text);
            }
            model.XSQ_CustomerValue = this.Tbx_CustomerValue.Value;
            model.XSQ_LinkMan = Request["Ddl_LinkMan"];
            model.XSQ_DutyPerson = this.Ddl_DutyPerson.SelectedValue;
            model.XSQ_Step = this.Ddl_Step.SelectedValue;
            model.XSQ_Remarks = this.Tbx_Remarks.Text;
            model.XSQ_Creator = AM.KNet_StaffNo;
            model.XSQ_CTime = DateTime.Now;
            model.XSQ_Mender = AM.KNet_StaffNo;
            model.XSQ_MTime = DateTime.Now.ToLongDateString();
            model.XSQ_Payment = KNetPage.KHtmlEncode(this.Tbx_Payment.Text);
            ArrayList Arr_Products = new ArrayList();
            if (Request["ProductsBarCode"] != null)
            {
                string[] s_ProductsBarCode = Request.Form["ProductsBarCode"].Split(',');
                string[] s_Number = Request.Form["Number"].Split(',');
                string[] s_Price = Request.Form["Price"].Split(',');
                string[] s_Money = Request.Form["Money"].Split(',');
                string[] s_Precent = Request.Form["Precent"].Split(',');
                string[] s_PrecentMoney = Request.Form["PrecentMoney"].Split(',');
                string[] s_Remarks = Request.Form["Remarks"].Split(',');
                for (int i = 0; i < s_ProductsBarCode.Length; i++)
                {
                    KNet.Model.Xs_Sales_Quotes_Details Model_Details = new KNet.Model.Xs_Sales_Quotes_Details();
                    Model_Details.SQD_ID = GetNewID("Xs_Sales_Quotes_Details", 1);
                    Model_Details.SQD_ProductsBarCode = s_ProductsBarCode[i];
                    s_PrecentMoney[i] = Convert.ToString(decimal.Parse(s_Price[i]) * decimal.Parse(s_Number[i]) * decimal.Parse(s_Precent[i]) / 100);
                    s_Money[i] = Convert.ToString(decimal.Parse(s_Price[i]) * decimal.Parse(s_Number[i]) - decimal.Parse(s_PrecentMoney[i]));
                    Model_Details.SQD_Number = decimal.Parse(s_Number[i]);
                    Model_Details.SQD_Price = decimal.Parse(s_Price[i]);
                    Model_Details.SQD_Money = decimal.Parse(s_Money[i]);
                    Model_Details.SQD_Percent = decimal.Parse(s_Precent[i]);
                    Model_Details.SQD_PercentedMoney = decimal.Parse(s_PrecentMoney[i]);
                    Model_Details.SQD_Remarks = s_Remarks[i];
                    Arr_Products.Add(Model_Details);
                }
                model.Arr_ProductsList = Arr_Products;
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

        KNet.Model.Xs_Sales_Quotes model = new KNet.Model.Xs_Sales_Quotes();
        KNet.BLL.Xs_Sales_Quotes bll = new KNet.BLL.Xs_Sales_Quotes();

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
                AM.Add_Logs("报价单增加" + this.Tbx_ID.Text);

                string JSD = "Xs/SalesQuotes/Xs_Sales_Quotes_Print.aspx?ID=" + model.XSQ_ID + "";
                base.HtmlToPdf1(JSD, Server.MapPath("PDF"), this.Tbx_Code.Text);
                AlertAndRedirect("新增成功！", "Xs_Sales_Quotes_List.aspx");
            }
            catch { }
        }
        else
        {

            try
            {
                if (bll.Update(model))
                {
                    AM.Add_Logs("报价单修改" + this.Tbx_ID.Text);
                    string JSD = "Xs/SalesQuotes/Xs_Sales_Quotes_Print.aspx?ID=" + model.XSQ_ID + "";
                    base.HtmlToPdf1(JSD, Server.MapPath("PDF"), this.Tbx_Code.Text);
                    AlertAndRedirect("修改成功！", "Xs_Sales_Quotes_List.aspx");
                }
            }
            catch { }
        }
    }
    private string s_GetCode()
    {
        string s_Return = "";
        try
        {
            KNet.BLL.Xs_Sales_Quotes Bll = new KNet.BLL.Xs_Sales_Quotes();

            string S_Code = Bll.GetLastCode();
            if (S_Code == "")
            {

                s_Return += "SY" + DateTime.Today.ToString("yyyyMMdd") + "-" + "001";
            }
            else
            {
                S_Code = "1" + S_Code.Substring(11, 3);
                decimal d_NewCode = decimal.Parse(S_Code) + 1;
                s_Return += "SY" + DateTime.Today.ToString("yyyyMMdd") + "-" + d_NewCode.ToString().Substring(1, d_NewCode.ToString().Length - 1);
            }

        }
        catch (Exception ex)
        {
            s_Return = "-";

        }
        return s_Return;
    }
}
