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


public partial class Web_Cw_Accounting_Pay : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            this.Lbl_Title.Text = "付款单查看";
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            if (s_ID != "")
            {
                ShowInfo(s_ID);
            }
            if (AM.CheckLogin("付款单查看") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
        }
       
    }

    private void ShowInfo(string s_ID)
    {
     
        KNet.BLL.Cw_Accounting_Pay bll = new KNet.BLL.Cw_Accounting_Pay();
        KNet.Model.Cw_Accounting_Pay model = bll.GetModel(s_ID);
        try
        {
            this.Tbx_ID.Text = s_ID;
            this.Lbl_Customer.Text = base.Base_GetSupplierOrCustomerName(model.CAA_CustomerValue);
            this.Lbl_ID.Text = model.CAA_Code;
            this.Lbl_STime.Text = DateTime.Parse(model.CAA_PayTime.ToString()).ToShortDateString();
            this.Lbl_SMoney.Text = model.CAA_PayMoney.ToString();
            this.Lbl_Details.Text = model.CAA_Details.ToString();
            this.Lbl_Type.Text = base.Base_GetBasicCodeName("767", model.CAP_Type.ToString());

            this.Tbx_YFBillCode.Text = model.CAP_YFBillCode;
            Tbx_YFOutDate.Text = base.DateToString(model.CAP_YFOutDate.ToString());
        }
        catch
        {}


        this.Lbl_Link.Text = "<a href=\"/Web/Rece/Cw_Accounting_Pay_Add.aspx?PayID=" + s_ID + "\" class=\"webMnu\">找回</a> ";

        //现有
        string s_Sql = " Select * from Cw_Bill_Details where CBD_FID='" + model.CAA_ID + "' and CBD_Type='1'";
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
        
            if (model.CAA_Account == "129780760640657453")
            {
                Pan_Bill.Visible = true;

            }
            else
            {
                Pan_Bill.Visible = false;
            }


        string s_Sql1 = " Select * from Cw_Bill_Details where CBD_FID='" + model.CAA_ID + "' and CBD_Type='0'";
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

}
