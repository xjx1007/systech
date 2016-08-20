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


public partial class Xs_Contract_Manage_Add : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(Xs_Contract_Manage_Add));
        if (!Page.IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string s_CustomerValue = Request.QueryString["CustomerValue"] == null ? "" : Request.QueryString["CustomerValue"].ToString();
            if (s_CustomerValue != "")
            {
                this.Tbx_CustomerValue.Value = s_CustomerValue;
                this.Tbx_CustomerName.Text = base.Base_GetCustomerName(s_CustomerValue);
            }
            this.Tbx_ID.Text = s_ID;
            this.Lbl_Title.Text = "新增合同档案";
            this.Tbx_STime.Text = DateTime.Now.ToShortDateString();
            base.Base_DropDutyPerson(this.Ddl_DutyPerson);
            base.Base_DropBasicCodeBind(this.DDl_Type,"216");
            base.Base_DropBindFlow(this.Ddl_Flow, "103");
            this.Ddl_Flow.SelectedValue = "104";
            base.Base_DropBasicCodeBind(this.Drop_Payment, "104");
            base.Base_DropBasicCodeBind(this.Ddl_KpType, "768");

            KNet_ContractToPaymentbind();
            if (s_ID != "")
            {
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制合同档案";
                }
                else
                {
                    this.Lbl_Title.Text = "修改合同档案";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }
            else
            {
                KNet.BLL.Xs_Contract_Manage bll = new KNet.BLL.Xs_Contract_Manage();

                Lbl_ContractDetails.Text = "<Table id=\"myTable\" width=\"100%\" border=\"0\" align=\"center\" cellpadding=\"5\" cellspacing=\"0\" class=\"ListDetails\">";

                Lbl_ContractDetails.Text += "<tr valign=\"middle\"><td valign=\"middle\" class=\"ListHead\" align=\"right\"  nowrap><b>工具</b></td>";
                Lbl_ContractDetails.Text += "<td class=\"ListHead\"  nowrap> <b>产品名称</b></td>";
                Lbl_ContractDetails.Text += "<td class=\"ListHead\"  nowrap><b>产品编码</b></td>";
                Lbl_ContractDetails.Text += "<td class=\"ListHead\"  nowrap><b>型号</b></td>";

                Lbl_ContractDetails.Text += "<td class=\"ListHead\"  nowrap><b>合同数量</b></td>";
                Lbl_ContractDetails.Text += "<td  class=\"ListHead\"  nowrap><b>备品数量</b></td>";
                Lbl_ContractDetails.Text += "<td  class=\"ListHead\"  nowrap><b>价格</b></td>";
                Lbl_ContractDetails.Text += "<td  nowrap  class=\"ListHead\"><b>金额</b></td>";
                Lbl_ContractDetails.Text += "<td class=\"ListHead\"  nowrap>";
                Lbl_ContractDetails.Text += "<b>计划单号</b>";
                Lbl_ContractDetails.Text += "</td>";
                Lbl_ContractDetails.Text += "<td class=\"ListHead\"  nowrap>";
                Lbl_ContractDetails.Text += "<b>订单号</b>";
                Lbl_ContractDetails.Text += "</td>";
                Lbl_ContractDetails.Text += "<td class=\"ListHead\"  nowrap>";
                Lbl_ContractDetails.Text += "<b>客户料号</b>";
                Lbl_ContractDetails.Text += "</td>";
                Lbl_ContractDetails.Text += "<td class=\"ListHead\"  nowrap>";
                Lbl_ContractDetails.Text += "<b>客户型号</b>";
                Lbl_ContractDetails.Text += "</td>";
                Lbl_ContractDetails.Text += "<td  class=\"ListHead\"  nowrap><b>是否随货</b></td>";
                Lbl_ContractDetails.Text += "<td  class=\"ListHead\"  nowrap><b>备注</b></td></tr>";
                this.Lbl_ContractDetails1.Text = Lbl_ContractDetails.Text;
            }
            //this.Lbl_Title.Text
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
        }
    }

    private void ShowInfo(string s_ID)
    {
        KNet.BLL.Xs_Contract_Manage bll = new KNet.BLL.Xs_Contract_Manage();
        KNet.Model.Xs_Contract_Manage model = bll.GetModel(s_ID);
        if (model != null)
        {

            this.Tbx_Code.Text = model.XCM_Code;
            this.Tbx_Title.Text = model.XCM_Title;
            try
            {
                this.Tbx_STime.Text = DateTime.Parse(model.XCM_STime.ToString()).ToShortDateString();
            }
            catch { }
            this.DDl_Type.SelectedValue = model.XCM_Type;
            this.Tbx_CustomerValue.Value = model.XCM_CustomerValue;
            this.Tbx_CustomerName.Text = base.Base_GetCustomerName(model.XCM_CustomerValue);
            this.Ddl_Flow.SelectedValue = model.XCM_Flow;
            this.Ddl_DutyPerson.SelectedValue = model.XCM_DutyPerson;
            this.tbx_Remarks.Text = KNetPage.KHtmlEncode(model.XCM_Remarks);
            this.Tbx_OrderNo.Text = model.XCM_OrderNo.ToString();

            this.Drop_Payment.SelectedValue=model.XCM_PayMent ;
            this.ContractToPayment.SelectedValue = model.XCM_BillType;
            this.Tbx_Technicalne.Text = model.XCM_TechnicalRequire;
            this.Tbx_ProductPackaging.Text = model.XCM_ProductPackaging;
            this.Tbx_QualityRequire.Text = model.XCM_QualityRequire;
            this.Tbx_WarrantyPeriod.Text = model.XCM_WarrantyPeriod;
            this.Tbx_ContractShip.Text = model.XCM_DeliveryReqyire;
            this.Tbx_FhDetails.Text = model.XCM_FhDetails;
            this.Ddl_KpType.SelectedValue = model.XCM_KpType;

            KNet.BLL.PB_Basic_Attachment Bll_Att = new KNet.BLL.PB_Basic_Attachment();
            DataSet Dts_Table = Bll_Att.GetList(" PBA_FID='" + model.XCM_ID + "'");
            if (Dts_Table.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                {
                    string s_FileName = Dts_Table.Tables[0].Rows[i]["PBA_Name"].ToString();
                    string s_filePath = Dts_Table.Tables[0].Rows[i]["PBA_Url"].ToString();
                    Lbl_Details.Text += "<tr><td valign=\"top\" class=\"ListHeadDetails\" align=\"left\" nowrap><a onclick=\"deleteRow3(this)\" href=\"#\">";
                    Lbl_Details.Text += "<img src=\"/themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=\"0\"></a></td>";
                    Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\" nowrap><input type=\"hidden\"  Name=\"Tbx_PName_" + i.ToString() + "\" value=" + s_FileName + ">" + s_FileName + "</td>";
                    Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\" nowrap><input Name=\"Image1Big_" + i.ToString() + "\"  type=\"hidden\"  value=" + s_filePath + "><a href=\"" + s_filePath + "\" >" + s_FileName + "</a></td></tr>";
                }
            }
            this.Tbx_num.Text = Dts_Table.Tables[0].Rows.Count.ToString();

            KNet.BLL.Xs_Contract_Manage_Details Bll_Details = new KNet.BLL.Xs_Contract_Manage_Details();
            Dts_Table = Bll_Details.GetList(" XCMD_ContractNo='" + model.XCM_Code + "' ");
            decimal d_All_OrderTotal = 0;
            if (Dts_Table.Tables[0].Rows.Count > 0)
            {
                Lbl_ContractDetails.Text = "<Table id=\"myTable\" width=\"100%\" border=\"0\" align=\"center\" cellpadding=\"5\" cellspacing=\"0\" class=\"crmTable\">";
                Lbl_ContractDetails.Text += "<tr valign=\"middle\"><td valign=\"middle\" class=\"ListHead\" align=\"right\"  nowrap><b>工具</b></td>";
                Lbl_ContractDetails.Text += "<td class=\"ListHead\"  nowrap> <b>产品名称</b></td>";
                Lbl_ContractDetails.Text += "<td class=\"ListHead\"  nowrap><b>产品编码</b></td>";
                Lbl_ContractDetails.Text += "<td class=\"ListHead\"  nowrap><b>型号</b></td>";

                Lbl_ContractDetails.Text += "<td class=\"ListHead\"  nowrap><b>订单数量</b></td>";
                Lbl_ContractDetails.Text += "<td  class=\"ListHead\"  nowrap><b>备品数量</b></td>";
                Lbl_ContractDetails.Text += "<td  class=\"ListHead\"  nowrap><b>价格</b></td>";
                Lbl_ContractDetails.Text += "<td  nowrap  class=\"ListHead\"><b>金额</b></td>";
                Lbl_ContractDetails.Text += "<td class=\"ListHead\"  nowrap>";
                Lbl_ContractDetails.Text += "<b>计划单号</b>";
                Lbl_ContractDetails.Text += "</td>";
                Lbl_ContractDetails.Text += "<td class=\"ListHead\"  nowrap>";
                Lbl_ContractDetails.Text += "<b>订单号</b>";
                Lbl_ContractDetails.Text += "</td>";
                Lbl_ContractDetails.Text += "<td class=\"ListHead\"  nowrap>";
                Lbl_ContractDetails.Text += "<b>客户料号</b>";
                Lbl_ContractDetails.Text += "</td>";
                Lbl_ContractDetails.Text += "<td class=\"ListHead\"  nowrap>";
                Lbl_ContractDetails.Text += "<b>客户型号</b>";
                Lbl_ContractDetails.Text += "</td>";
                Lbl_ContractDetails.Text += "<td  class=\"ListHead\"  nowrap><b>是否随货</b></td>";
                Lbl_ContractDetails.Text += "<td  class=\"ListHead\"  nowrap><b>备注</b></td></tr>";
                for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                {
                    this.Xs_ProductsCode.Text += Dts_Table.Tables[0].Rows[i]["XCMD_ProductsBarCode"].ToString() + ",";
                    d_All_OrderTotal += Decimal.Parse(Dts_Table.Tables[0].Rows[i]["XCMD_Contract_SalesTotalNet"].ToString());
                    Lbl_ContractDetails.Text += " <tr valign=\"middle\">";
                    Lbl_ContractDetails.Text += "<td class=\"ListHeadDetails\"><A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a></td>";
                    Lbl_ContractDetails.Text += "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ID_" + i.ToString() + "\" value='" + Dts_Table.Tables[0].Rows[i]["XCMD_ID"].ToString() + "'>" + base.Base_GetProdutsName(Dts_Table.Tables[0].Rows[i]["XCMD_ProductsBarCode"].ToString()) + "</td>";
                    Lbl_ContractDetails.Text += "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ProductsBarCode_" + i.ToString() + "\" value='" + Dts_Table.Tables[0].Rows[i]["XCMD_ProductsBarCode"].ToString() + "'>" + Dts_Table.Tables[0].Rows[i]["XCMD_ProductsBarCode"].ToString() + "</td>";
                    Lbl_ContractDetails.Text += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dts_Table.Tables[0].Rows[i]["XCMD_ProductsBarCode"].ToString()) + "</td>";

                    Lbl_ContractDetails.Text += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"ChangPrice();this.className=\'detailedViewTextBox\'\" style=\"width:50px;\" Name=\"Number_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["XCMD_ContractAmount"].ToString() + "></td>";
                    Lbl_ContractDetails.Text += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"ChangPrice();this.className=\'detailedViewTextBox\'\" style=\"width:50px;\" Name=\"BNumber_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["XCMD_BNumber"].ToString() + " ></td>";
                    Lbl_ContractDetails.Text += "<td class=\"ListHeadDetails\"><input type=\"text\"  class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"ChangPrice();this.className='\"detailedViewTextBox'\" style=\"width:50px;\"  Name=\"Price_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["XCMD_Contract_SalesUnitPrice"].ToString() + "></td>";
                    Lbl_ContractDetails.Text += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\" readonly  Name=\"Money_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["XCMD_Contract_SalesTotalNet"].ToString() + " ></td>";
                    Lbl_ContractDetails.Text += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\"   Name=\"PlanNumber_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["XCMD_PlanNumber"].ToString() + " ></td>";
                    Lbl_ContractDetails.Text += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\"   Name=\"OrderNumber_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["XCMD_OrderNumber"].ToString() + " ></td>";
                    Lbl_ContractDetails.Text += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\"   Name=\"MaterNumber_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["XCMD_MaterNumber"].ToString() + " ></td>";
                    Lbl_ContractDetails.Text += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\"   Name=\"MaterPattern_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["XCMD_MaterPattern"].ToString() + " ></td>";
                    Lbl_ContractDetails.Text += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\"   Name=\"IsFollow_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["XCMD_IsFollow"].ToString() + " ></td>";

                    Lbl_ContractDetails.Text += " <td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:100px;\"  Name=\"Remarks_" + i.ToString() + "\"  Text=\"" + Dts_Table.Tables[0].Rows[i]["XCMD_ContractRemarks"].ToString() + "\" ></td>";
                    Lbl_ContractDetails.Text += " </tr>";
                }
                Lbl_ContractDetails.Text += " </table>";
                this.Lbl_ContractDetails1.Text = Lbl_ContractDetails.Text;
                this.i_Num.Text = Convert.ToString(Dts_Table.Tables[0].Rows.Count + 1);
            }
            else
            {
                Lbl_ContractDetails.Text = "<Table id=\"myTable\" width=\"100%\" border=\"0\" align=\"center\" cellpadding=\"5\" cellspacing=\"0\" class=\"crmTable\">";
                Lbl_ContractDetails.Text += "<tr><td colspan=\"14\" class=\"detailedViewHeader\" style=\"height: 15px\">";
                Lbl_ContractDetails.Text += "<b>产品详细信息</b></td></tr>";
                Lbl_ContractDetails.Text += "<tr valign=\"middle\"><td valign=\"middle\" class=\"ListHead\" align=\"right\"  nowrap><b>工具</b></td>";
                Lbl_ContractDetails.Text += "<td class=\"ListHead\"  nowrap> <b>产品名称</b></td>";
                Lbl_ContractDetails.Text += "<td class=\"ListHead\"  nowrap><b>产品编码</b></td>";
                Lbl_ContractDetails.Text += "<td class=\"ListHead\"  nowrap><b>型号</b></td>";

                Lbl_ContractDetails.Text += "<td class=\"ListHead\"  nowrap><b>订单数量</b></td>";
                Lbl_ContractDetails.Text += "<td  class=\"ListHead\"  nowrap><b>备品数量</b></td>";
                Lbl_ContractDetails.Text += "<td  class=\"ListHead\"  nowrap><b>价格</b></td>";
                Lbl_ContractDetails.Text += "<td  nowrap  class=\"ListHead\"><b>金额</b></td>";
                Lbl_ContractDetails.Text += "<td class=\"ListHead\"  nowrap>";
                Lbl_ContractDetails.Text += "<b>计划单号</b>";
                Lbl_ContractDetails.Text += "</td>";
                Lbl_ContractDetails.Text += "<td class=\"ListHead\"  nowrap>";
                Lbl_ContractDetails.Text += "<b>订单号</b>";
                Lbl_ContractDetails.Text += "</td>";
                Lbl_ContractDetails.Text += "<td class=\"ListHead\"  nowrap>";
                Lbl_ContractDetails.Text += "<b>客户料号</b>";
                Lbl_ContractDetails.Text += "</td>";
                Lbl_ContractDetails.Text += "<td class=\"ListHead\"  nowrap>";
                Lbl_ContractDetails.Text += "<b>客户型号</b>";
                Lbl_ContractDetails.Text += "</td>";
                Lbl_ContractDetails.Text += "<td  class=\"ListHead\"  nowrap><b>是否随货</b></td>";
                Lbl_ContractDetails.Text += "<td  class=\"ListHead\"  nowrap><b>备注</b></td></tr>";
                this.Lbl_ContractDetails1.Text = Lbl_ContractDetails.Text;
            }
        }


        this.BeginQuery("select * from Xs_Contract_FhDetails where XCF_FID='" + model.XCM_ID+ "'");
        DataTable Dtb_FhDetails = (DataTable)this.QueryForDataTable();
        if (Dtb_FhDetails.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_FhDetails.Rows.Count; i++)
            {

                Lbl_FhDetails.Text += " <tr valign=\"middle\">";
                Lbl_FhDetails.Text += "<td class=\"ListHeadDetails\"><input type=\"CheckBox\" id=\"Chk_" + i.ToString() + "\" Name=\"Chk_ " + i.ToString() + "\"  checked ></td>";

                Lbl_FhDetails.Text += "<td class=\"ListHeadDetails\"><input type=\"input\" style=\"height:50px;width:65%;display:none\" Name=\"FhName_" + i.ToString() + "\"  value=\"'" + Dtb_FhDetails.Rows[i]["XCF_Name"].ToString() + "'\" >" + Dtb_FhDetails.Rows[i]["XCF_Name"].ToString() + "</td>";
                Lbl_FhDetails.Text += "<td class=\"ListHeadDetails\"><input type=\"input\" style=\"height:50px;width:65%;display:none\" Name=\"FhDetails_" + i.ToString() + "\"  value=\"'" + Dtb_FhDetails.Rows[i]["XCF_Details"].ToString() + "'\" >" + Dtb_FhDetails.Rows[i]["XCF_Details"].ToString() + "</td>";

                Lbl_FhDetails.Text += "</tr>";

            }
            this.FhNum.Text = Dtb_FhDetails.Rows.Count.ToString();
        }
    }
    private bool SetValue(KNet.Model.Xs_Contract_Manage model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text == "")
            {
                model.XCM_ID = base.GetMainID();
            }
            else
            {
                model.XCM_ID = this.Tbx_ID.Text;
            }
            model.XCM_Code = this.Tbx_Code.Text;
            try{
                model.XCM_STime = DateTime.Parse(this.Tbx_STime.Text);
            }
            catch{}
            model.XCM_Type = this.DDl_Type.SelectedValue;
            model.XCM_Flow = this.Ddl_Flow.SelectedValue;
            model.XCM_CustomerValue = this.Tbx_CustomerValue.Value;
            model.XCM_DutyPerson = this.Ddl_DutyPerson.SelectedValue;
            model.XCM_Remarks = KNetPage.KHtmlEncode(this.tbx_Remarks.Text);
            model.XCM_Title = this.Tbx_Title.Text;
            model.XCM_OrderNo = int.Parse(this.Tbx_OrderNo.Text);
            model.XCM_CheckYN = 0;
            model.XCM_CTime = DateTime.Now;
            model.XCM_Creator = AM.KNet_StaffNo;
            model.XCM_Mender = AM.KNet_StaffNo;
            model.XCM_MTime = DateTime.Now;

            model.XCM_PayMent = this.Drop_Payment.SelectedValue;
            model.XCM_BillType = this.ContractToPayment.SelectedValue;
            model.XCM_TechnicalRequire=this.Tbx_Technicalne.Text;
            model.XCM_ProductPackaging = this.Tbx_ProductPackaging.Text;
            model.XCM_QualityRequire = this.Tbx_QualityRequire.Text;
            model.XCM_WarrantyPeriod = this.Tbx_WarrantyPeriod.Text;
            model.XCM_DeliveryReqyire=this.Tbx_ContractShip.Text;
            model.XCM_FhDetails = this.Tbx_FhDetails.Text;
            model.XCM_KpType = this.Ddl_KpType.SelectedValue;

            ArrayList arr_Image = new ArrayList();
            for (int i = 0; i < int.Parse(this.Tbx_num.Text); i++)
            {
                string s_Name = Request["Tbx_PName_" + i.ToString() + ""] == null ? "" : Request["Tbx_PName_" + i.ToString() + ""].ToString();
                string s_URL = Request["Image1Big_" + i.ToString() + ""] == null ? "" : Request["Image1Big_" + i.ToString() + ""].ToString();
                if (s_Name != "")
                {
                    KNet.Model.PB_Basic_Attachment Model_Att = new KNet.Model.PB_Basic_Attachment();
                    Model_Att.PBA_ID = GetMainID(i);
                    Model_Att.PBA_FID = model.XCM_ID;
                    Model_Att.PBA_Name = s_Name;
                    Model_Att.PBA_URL = s_URL;
                    Model_Att.PBA_Type = "Contract";
                    Model_Att.PBA_Creator = AM.KNet_StaffNo;
                    Model_Att.PBA_CTime = DateTime.Now;
                    arr_Image.Add(Model_Att);
                }
            }
            model.Arr_Details = arr_Image;


            ArrayList Arr_Details = new ArrayList();

            int i_num = int.Parse(this.i_Num.Text);
            for (int i = 0; i < i_num; i++)
            {
                KNet.Model.Xs_Contract_Manage_Details ModelDetails = new KNet.Model.Xs_Contract_Manage_Details();
                if (Request["ProductsBarCode_" + i] != null)
                {
                    string s_ProductsBarCode = Request["ProductsBarCode_" + i].ToString();
                    string s_ContractDetailsID = Request["ID_" + i] == null ? GetMainID(i) : Request["ID_" + i].ToString();
                    string s_Number = Request["Number_" + i] == "" ? "0" : Request["Number_" + i].ToString().ToString();
                    string s_BNumber = Request["BNumber_" + i] == "" ? "0" : Request["BNumber_" + i].ToString();
                    string s_OrderBNumber = "0";
                    string s_Price = Request["Price_" + i] == "" ? "0" : Request["Price_" + i].ToString();
                    string s_Money = Request["Money_" + i] == "" ? "0" : Request["Money_" + i].ToString();
                    string s_OrderNumber = Request["OrderNumber_" + i] == null ? "" : Request["OrderNumber_" + i].ToString();
                    string s_MaterNumber = Request["MaterNumber_" + i] == null ? "" : Request["MaterNumber_" + i].ToString();
                    string s_Remarks = Request["Remarks_" + i] == null ? "" : Request["Remarks_" + i].ToString();
                    string s_IsFollow = Request["IsFollow_" + i] == null ? "" : Request["IsFollow_" + i].ToString();
                    string s_PlanNumber = Request["PlanNumber_" + i] == null ? "" : Request["PlanNumber_" + i].ToString();
                    string s_MaterPattern = Request["MaterPattern_" + i] == null ? "" : Request["MaterPattern_" + i].ToString();
                    ModelDetails.XCMD_ID = GetMainID(i);
                    ModelDetails.XCMD_ProductsBarCode = s_ProductsBarCode;
                    ModelDetails.XCMD_ContractAmount = int.Parse(s_Number);
                    ModelDetails.XCMD_Contract_SalesUnitPrice = decimal.Parse(s_Price);
                    ModelDetails.XCMD_Contract_SalesTotalNet = decimal.Parse(s_Money);
                    ModelDetails.XCMD_ContractNo = model.XCM_Code;
                    ModelDetails.XCMD_ContractRemarks = s_Remarks;
                    ModelDetails.XCMD_OrderNumber = s_OrderNumber;
                    ModelDetails.XCMD_MaterNumber = s_MaterNumber;
                    ModelDetails.XCMD_IsFollow = s_IsFollow;
                    ModelDetails.XCMD_MaterPattern = s_MaterPattern;
                    ModelDetails.XCMD_PlanNumber = s_PlanNumber;
                    ModelDetails.XCMD_BNumber = int.Parse(s_BNumber);
                    ModelDetails.XCMD_OrderBNumber = int.Parse(s_OrderBNumber);
                    ModelDetails.XCMD_DateTime = DateTime.Now;
                    Arr_Details.Add(ModelDetails);
                }
            }

            model.Arr_Details1 = Arr_Details;


            int i_FhNum = int.Parse(this.FhNum.Text);

            ArrayList Arr_FhDetails = new ArrayList();
            for (int i = 0; i < i_FhNum; i++)
            {
                if (Request.Form["Chk_" + i.ToString() + ""] != null)
                {
                    string s_FHName = Request["FhName_" + i + ""] == null ? "" : Request["FhName_" + i + ""].ToString();
                    string s_FHDetail = Request["FhDetails_" + i + ""] == null ? "" : Request["FhDetails_" + i + ""].ToString();
                    KNet.Model.Xs_Contract_FhDetails Model_FhDetails = new KNet.Model.Xs_Contract_FhDetails();
                    Model_FhDetails.XCF_ID = GetMainID(i);
                    Model_FhDetails.XCF_FID = model.XCM_ID;
                    Model_FhDetails.XCF_Name = s_FHName;
                    Model_FhDetails.XCF_Details = s_FHDetail;
                    Arr_FhDetails.Add(Model_FhDetails);
                }
            }
            model.arr_FhDetails = Arr_FhDetails;
            
            return true;
        }
        catch   
        {
            return false;
        }
       
    }


    #region 资料上传操作
    /// <summary>
    /// 上传资料
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void button_ServerClick(object sender, EventArgs e)
    {

        if (!(uploadFile.PostedFile.ContentLength > 0))
        {
            Alert("您没有选择文件!");
        }
        else
        {
            string FileType = uploadFile.PostedFile.ContentType.ToString(); //文件类型
            //if (FileType == "image/gif" || FileType == "image/pjpeg")
            //{
            //}
            //else
            //{
            //    Alert("文件类型服务器不接受!");
            //}
            GetThumbnailImage1();
        }
    }
    /// <summary>
    /// 图片上传
    /// </summary>
    protected void GetThumbnailImage1()
    {
        AdminloginMess AM = new AdminloginMess();
        string UploadPath = "../../UpFile/Contract/";  //上传路径
        string AutoPath = System.DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "").Replace("/", "");
        string fileExt = Path.GetExtension(uploadFile.PostedFile.FileName); //获扩展名
        string FileType = uploadFile.PostedFile.ContentType.ToString(); //文件类型
        string FileName = this.Tbx_Name.Text;
            
            //Path.GetFileName(uploadFile.PostedFile.FileName);
        string filePath = UploadPath + AutoPath + "_" + FileName + fileExt; //大文件名
        if (!Directory.Exists(Server.MapPath(UploadPath)))
        {
            Directory.CreateDirectory(Server.MapPath(UploadPath));
        }
        uploadFile.PostedFile.SaveAs(Server.MapPath(filePath)); //上传
        Up_Loadcs UL = new Up_Loadcs();
        int i_Num = int.Parse(this.Tbx_num.Text);
        this.Lbl_Details.Text ="";// this.Lbl_Details.Text.Substring(0, this.Lbl_Details.Text.Length - 8);
        Lbl_Details.Text += "<tr><td valign=\"top\" class=\"ListHeadDetails\" align11=\"left\" nowrap><a onclick=\"deleteRow3(this)\" href=\"#\">";
        Lbl_Details.Text += "<img src=\"/themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=\"0\"></a></td>";
        Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\" nowrap><input type=\"hidden\"  Name=\"Tbx_PName_" + i_Num + "\" value=" + FileName + ">" + FileName + "</td>";
        if (FileType == "image/gif" || FileType == "image/pjpeg")
        {
            Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\" nowrap><input Name=\"Image1Big_" + i_Num + "\"  type=\"hidden\"  value=" + filePath + "><Image ID=\"Image_" + i_Num + "\" Src=\"" + filePath + "\" Height=\"35px\" /></td></tr>";
        }
        else
        {
            Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\" nowrap><input Name=\"Image1Big_" + i_Num + "\"  type=\"hidden\"  value=" + filePath + "><a href=\"" + filePath + "\" >" + FileName + "</a></td></tr>";
        }
        this.Tbx_num.Text = Convert.ToString(i_Num + 1);
        string s_CustomerValue = Request["Tbx_CustomerValue"] == null ? "" : Request["Tbx_CustomerValue"].ToString();
        string s_CustomerName = Request["Tbx_CustomerName"] == null ? "" : Request["Tbx_CustomerName"].ToString();
        
        this.Tbx_CustomerValue.Value = s_CustomerValue;
        this.Tbx_CustomerName.Text = s_CustomerName;
        

    }
    #endregion

    protected void Btn_SaveOnClick(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.Model.Xs_Contract_Manage model = new KNet.Model.Xs_Contract_Manage();
        KNet.BLL.Xs_Contract_Manage bll = new KNet.BLL.Xs_Contract_Manage();

        if (this.SetValue(model) == false)
        {
            Alert("系统错误！");
            return;
        }
        if (this.Tbx_ID.Text != "")//修改
        {
            try
            {
                if (bll.Update(model))
                {
                    AM.Add_Logs("合同档案修改" + this.Tbx_ID.Text);
                    AlertAndRedirect("修改成功！", "Xs_Contract_Manage_List.aspx");

                }
                else
                {
                    AM.Add_Logs("合同档案修改失败" + this.Tbx_ID.Text);
                    AlertAndRedirect("修改失败！", "Xs_Contract_Manage_Add.aspx?ID="+this.Tbx_ID.Text+"");
                }
            }
            catch (Exception ex) { Alert(ex.Message); }
        }
        else
        {

            try
            {
                bll.Add(model);
                AM.Add_Logs("合同档案增加" + this.Tbx_ID.Text);
                AlertAndRedirect("新增成功！", "Xs_Contract_Manage_List.aspx");
            }
            catch { }
        }
    }

    [Ajax.AjaxMethod()]
    public string GetFhDetails(string s_CustomerValue)
    {
        string s_Return = "";
        try
        {
            KNet.BLL.Xs_Customer_FhInfo BLL = new KNet.BLL.Xs_Customer_FhInfo();
            DataSet Dts_Table = BLL.GetList(" XCF_CustomerValue='" + s_CustomerValue + "'");
            for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
            {
                s_Return += Dts_Table.Tables[0].Rows[i]["XCF_Name"].ToString() + "|" + Dts_Table.Tables[0].Rows[i]["XCF_Details"].ToString() + "#";
            }
        }
        catch (Exception ex)
        {
        }
        return s_Return;
    }

    [Ajax.AjaxMethod()]
    public string GetCode(string s_CustomerValue,string s_Type)
    {
        string s_Return = "",s_OrderNumber="";
        string s_CustomerNumber="",s_Date="";
        try
        {
            KNet.BLL.Xs_Contract_Manage Bll = new KNet.BLL.Xs_Contract_Manage();
            s_OrderNumber=Bll.GetMaxOrder();
            if(s_CustomerValue!="")
            {
                s_CustomerNumber = s_CustomerValue.Substring(1, s_CustomerValue.Length - 1);
                if (s_Type != "")
                {
                    s_Date = DateTime.Now.ToString("yyMMdd");
                    s_Return = "CONT" + s_CustomerNumber + s_OrderNumber.Substring(1, s_OrderNumber.Length - 1) + s_Type + s_Date + "," + s_OrderNumber;
                }
            }
            return s_Return;
        }
        catch(Exception ex)
        {
            return s_Return;
        }
    }

    /// <summary>
    /// 结算方式  （Y）
    /// </summary> 
    protected void KNet_ContractToPaymentbind()
    {
        KNet.BLL.KNet_Sys_CheckMethod bll = new KNet.BLL.KNet_Sys_CheckMethod();
        DataSet ds = bll.GetAllList();
        this.ContractToPayment.DataSource = ds;
        this.ContractToPayment.DataTextField = "CheckName";
        this.ContractToPayment.DataValueField = "CheckNo";
        this.ContractToPayment.DataBind();
        ListItem item = new ListItem("请选择付款方式", ""); //默认值
        this.ContractToPayment.Items.Insert(0, item);
    }

    [Ajax.AjaxMethod()]
    public string GetProductsInfo(string s_ProductsBarCode)
    {
        string s_Return = "";
        try
        {
            KNet.BLL.KNet_Sys_Products BLL = new KNet.BLL.KNet_Sys_Products();
            KNet.Model.KNet_Sys_Products Model = BLL.GetModelB(s_ProductsBarCode);
            s_Return += Model.ProductsName + "#" + Model.ProductsEdition;
            return s_Return;
        }
        catch (Exception ex)
        {
            return s_Return;
        }
    }
}
