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
using System.Net.Mail;

using KNet.DBUtility;
using KNet.Common;
public partial class Knet_Web_Salese_KNet_Sales_ContractList_Add : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(Knet_Web_Salese_KNet_Sales_ContractList_Add));
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            else
            {
                string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
                string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
                string s_FaterID = Request.QueryString["FaterID"] == null ? "" : Request.QueryString["FaterID"].ToString();
                string s_CustomerValue = Request.QueryString["CustomerValue"] == null ? "" : Request.QueryString["CustomerValue"].ToString();
                string s_Hx = Request.QueryString["Hx"] == null ? "" : Request.QueryString["Hx"].ToString();
                this.Tbx_Hx.Text = s_Hx;
                if (s_CustomerValue != "")
                {
                    this.CustomerValue.Value = s_CustomerValue;
                    this.CustomerValueName.Text = base.Base_GetCustomerName(s_CustomerValue);
                }
                this.Tbx_FaterID.Value = s_FaterID;

                this.ContractDateTime.Text = DateTime.Now.ToShortDateString();
                this.ContractStarDateTime.Text = DateTime.Now.AddDays(1).ToShortDateString();
                this.KNet_ContractToPaymentbind();
                base.Base_DropKClaaBind(this.ContractDeliveMethods, 5, "", "请选择交货方式");
                this.ContractDeliveMethods.SelectedValue = "129687525222726803";
                base.Base_DropKClaaBind(this.ContractClass, 6, "", "");
                base.Base_DropBasicCodeBind(this.Drop_RoutineTransport, "102");
                base.Base_DropBasicCodeBind(this.Drop_WorryTransport, "103");
                base.Base_DropBasicCodeBind(this.Drop_Payment, "104");
                base.Base_DropBasicCodeBind(this.Ddl_KpType, "768");
                KNet.BLL.KNet_Resource_Staff Bll = new KNet.BLL.KNet_Resource_Staff();
                DataSet Dts_Table = Bll.GetList(" StaffNo<>'admin' and IsSale='1' Order By StaffDepart ");
                this.Ddl_DutyPerson.DataSource = Dts_Table;
                this.Ddl_DutyPerson.DataTextField = "StaffName";
                this.Ddl_DutyPerson.DataValueField = "StaffNo";
                this.Ddl_DutyPerson.DataBind();
                ListItem item = new ListItem("请选择责任人", ""); //默认值
                this.Ddl_DutyPerson.Items.Insert(0, item);

                this.Image1.ImageUrl = "../images/Nopic.jpg";
                this.Image1Big.Text = "../images/Nopic.jpg";

                base.Base_DropBasicCodeBind(this.DDl_Type, "216");

                ShowContractDetails(s_FaterID);

                this.Tbx_Type.Text = s_Type;

                if (s_ID != "")
                {
                    if (s_Type == "1")
                    {
                        this.Tbx_ID.Text = "";
                        this.Lbl_Title.Text = "复制订单评审";
                        this.ContractNo.Text = "POP" + KNetOddNumbers();
                        this.Tbx_OrderNo.Text = "PO" + KNetOddNumbers1();
                    }
                    else
                    {
                        this.Lbl_Title.Text = "修改订单评审";
                        this.Tbx_ID.Text = s_ID;
                    }
                    this.Btn_Save.Text = "保存";
                    ShowInfo(s_ID);
                    if (this.Lbl_FhDetails.Text == "")
                    {
                        Lbl_FhDetails.Text = "<Table id=\"myFhTable\" width=\"100%\" border=\"0\" align=\"center\" cellpadding=\"5\" cellspacing=\"0\" class=\"ListDetails\">";
                        Lbl_FhDetails.Text += "<tr valign=\"middle\">";
                        Lbl_FhDetails.Text += "<td class=\"ListHead\"  nowrap> <b>选择</b></td>";
                        Lbl_FhDetails.Text += "<td class=\"ListHead\"  nowrap><b>名称</b></td>";
                        Lbl_FhDetails.Text += "<td class=\"ListHead\"  nowrap><b>详细</b></td></tr>";
                        Lbl_FhDetails.Text += "</Table>";
                        this.Lbl_FhDetails1.Text = Lbl_FhDetails.Text;
                    }
                }
                else
                {
                    this.ContractNo.Text = "POP" + KNetOddNumbers();
                    this.Tbx_OrderNo.Text = "PO" + KNetOddNumbers1();
                    this.Lbl_Title.Text = "新增订单评审";
                    if (Lbl_ContractDetails.Text == "")
                    {
                        Lbl_ContractDetails.Text = "<Table id=\"myTable\" width=\"100%\" border=\"0\" align=\"center\" cellpadding=\"5\" cellspacing=\"0\" class=\"ListDetails\">";

                        Lbl_ContractDetails.Text += "<tr valign=\"middle\"><td valign=\"middle\" class=\"ListHead\" align=\"right\"  nowrap><b>工具</b></td>";
                        Lbl_ContractDetails.Text += "<td class=\"ListHead\"  nowrap> <b>产品名称</b></td>";
                        Lbl_ContractDetails.Text += "<td class=\"ListHead\"  nowrap><b>产品编码</b></td>";
                        Lbl_ContractDetails.Text += "<td class=\"ListHead\"  nowrap><b>型号</b></td>";

                        Lbl_ContractDetails.Text += "<td class=\"ListHead\"  nowrap><b>剩余备货</b></td>";
                        Lbl_ContractDetails.Text += "<td class=\"ListHead\"  nowrap><b>核销</b></td>";
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

                    if (this.Lbl_FhDetails.Text == "")
                    {
                        Lbl_FhDetails.Text = "<Table id=\"myFhTable\" width=\"100%\" border=\"0\" align=\"center\" cellpadding=\"5\" cellspacing=\"0\" class=\"ListDetails\">";

                        Lbl_FhDetails.Text += "<tr valign=\"middle\">";
                        Lbl_FhDetails.Text += "<td class=\"ListHead\"  nowrap> <b>选择</b></td>";
                        Lbl_FhDetails.Text += "<td class=\"ListHead\"  nowrap><b>名称</b></td>";
                        Lbl_FhDetails.Text += "<td class=\"ListHead\"  nowrap><b>详细</b></td></tr>";
                        Lbl_FhDetails.Text += "</Table>";
                        this.Lbl_FhDetails1.Text = Lbl_FhDetails.Text;
                    }
                }
            }
        }
    }
    private void ShowContractDetails(string s_FaterID)
    {
        try
        {
            KNet.BLL.Xs_Contract_Manage Bll_Manage = new KNet.BLL.Xs_Contract_Manage();
            KNet.Model.Xs_Contract_Manage Model_Manage = Bll_Manage.GetModel(s_FaterID);
            if (Model_Manage != null)
            {
                this.Tbx_FaterCode.Text = Model_Manage.XCM_Code;
                this.DDl_Type.SelectedValue = Model_Manage.XCM_Type;
                this.CustomerValue.Value = Model_Manage.XCM_CustomerValue;
                this.CustomerValueName.Text = base.Base_GetCustomerName(Model_Manage.XCM_CustomerValue);
                this.Ddl_DutyPerson.SelectedValue = Model_Manage.XCM_DutyPerson;
                this.Drop_Payment.SelectedValue = Model_Manage.XCM_PayMent;
                this.ContractToPayment.SelectedValue = Model_Manage.XCM_BillType;
                this.Tbx_ContractShip.Text = Model_Manage.XCM_FhDetails;
                this.Tbx_Technicalne.Text = Model_Manage.XCM_TechnicalRequire;
                this.Tbx_ProductPackaging.Text = Model_Manage.XCM_ProductPackaging;
                this.Tbx_Technicalne.Text = Model_Manage.XCM_TechnicalRequire;
                this.Tbx_WarrantyPeriod.Text = Model_Manage.XCM_WarrantyPeriod;
                this.Tbx_DeliveryRequire.Text = Model_Manage.XCM_DeliveryReqyire;
                this.Ddl_KpType.SelectedValue = Model_Manage.XCM_KpType;
                this.BeginQuery("select * from Xs_Contract_FhDetails where XCF_FID='" + Model_Manage.XCM_ID + "'");
                DataTable Dtb_FhDetails = (DataTable)this.QueryForDataTable();
                if (Dtb_FhDetails.Rows.Count > 0)
                {

                    Lbl_FhDetails.Text = "<Table id=\"myFhTable\" width=\"100%\" border=\"0\" align=\"center\" cellpadding=\"5\" cellspacing=\"0\" class=\"ListDetails\">";

                    Lbl_FhDetails.Text += "<tr valign=\"middle\"><td valign=\"middle\" class=\"ListHead\" align=\"right\"  nowrap><b>工具</b></td>";
                    Lbl_FhDetails.Text += "<td class=\"ListHead\"  nowrap> <b>选择</b></td>";
                    Lbl_FhDetails.Text += "<td class=\"ListHead\"  nowrap><b>名称</b></td>";
                    Lbl_FhDetails.Text += "<td class=\"ListHead\"  nowrap><b>详细</b></td></tr>";
                    Lbl_FhDetails.Text += "</tr>";
                    for (int i = 0; i < Dtb_FhDetails.Rows.Count; i++)
                    {

                        Lbl_FhDetails.Text += " <tr valign=\"middle\">";
                        Lbl_FhDetails.Text += "<td class=\"ListHeadDetails\"><input type=\"CheckBox\" id=\"Chk_" + i.ToString() + "\" Name=\"Chk_ " + i.ToString() + "\"  checked ></td>";

                        Lbl_FhDetails.Text += "<td class=\"ListHeadDetails\"><input type=\"input\" style=\"height:50px;width:65%;display:none\" Name=\"FhName_" + i.ToString() + "\"  value=\"'" + Dtb_FhDetails.Rows[i]["XCF_Name"].ToString() + "'\" >" + Dtb_FhDetails.Rows[i]["XCF_Name"].ToString() + "</td>";
                        Lbl_FhDetails.Text += "<td class=\"ListHeadDetails\"><input type=\"input\" style=\"height:50px;width:65%;display:none\" Name=\"FhDetails_" + i.ToString() + "\"  value=\"'" + Dtb_FhDetails.Rows[i]["XCF_Details"].ToString() + "'\" >" + Dtb_FhDetails.Rows[i]["XCF_Details"].ToString() + "</td>";

                        Lbl_FhDetails.Text += "</tr>";

                    }
                    Lbl_FhDetails.Text += "</table>";


                    this.FhNum.Text = Dtb_FhDetails.Rows.Count.ToString();
                }


                KNet.BLL.Xs_Contract_Manage_Details Bll_Details = new KNet.BLL.Xs_Contract_Manage_Details();
                DataSet Dts_Table = Bll_Details.GetList(" XCMD_ContractNo='" + Model_Manage.XCM_Code + "' ");
                decimal d_All_OrderTotal = 0;
                if (Dts_Table.Tables[0].Rows.Count > 0)
                {
                    Lbl_ContractDetails.Text = "<Table id=\"myTable\" width=\"100%\" border=\"0\" align=\"center\" cellpadding=\"5\" cellspacing=\"0\" class=\"crmTable\">";
                    Lbl_ContractDetails.Text += "<tr valign=\"middle\"><td valign=\"middle\" class=\"ListHead\" align=\"right\"  nowrap><b>工具</b></td>";
                    Lbl_ContractDetails.Text += "<td class=\"ListHead\"  nowrap> <b>产品名称</b></td>";
                    Lbl_ContractDetails.Text += "<td class=\"ListHead\"  nowrap><b>产品编码</b></td>";
                    Lbl_ContractDetails.Text += "<td class=\"ListHead\"  nowrap><b>型号</b></td>";

                    Lbl_ContractDetails.Text += "<td class=\"ListHead\"  nowrap><b>剩余备货</b></td>";
                    Lbl_ContractDetails.Text += "<td class=\"ListHead\"  nowrap><b>核销</b></td>";
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
                        Lbl_ContractDetails.Text += "<td class=\"ListHeadDetails\"><input  Name=\"XCMD_ID_" + i.ToString() + "\" value='" + Dts_Table.Tables[0].Rows[i]["XCMD_ID"].ToString() + "'>" + base.Base_GetProdutsName(Dts_Table.Tables[0].Rows[i]["XCMD_ProductsBarCode"].ToString()) + "</td>";
                        Lbl_ContractDetails.Text += "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ProductsBarCode_" + i.ToString() + "\" value='" + Dts_Table.Tables[0].Rows[i]["XCMD_ProductsBarCode"].ToString() + "'>" + Dts_Table.Tables[0].Rows[i]["XCMD_ProductsBarCode"].ToString() + "</td>";
                        Lbl_ContractDetails.Text += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dts_Table.Tables[0].Rows[i]["XCMD_ProductsBarCode"].ToString()) + "</td>";

                        Lbl_ContractDetails.Text += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"ChangPrice();this.className=\'detailedViewTextBox\'\" style=\"width:50px;\" Name=\"Number_" + i.ToString() + "\"></td>";
                        Lbl_ContractDetails.Text += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"ChangPrice();this.className=\'detailedViewTextBox\'\" style=\"width:50px;\" Name=\"BNumber_" + i.ToString() + "\" ></td>";
                        Lbl_ContractDetails.Text += "<td class=\"ListHeadDetails\"><input type=\"text\"  class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"ChangPrice();this.className='\"detailedViewTextBox'\" style=\"width:50px;\"  Name=\"Price_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["XCMD_Contract_SalesUnitPrice"].ToString() + "></td>";
                        Lbl_ContractDetails.Text += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\" readonly  Name=\"Money_" + i.ToString() + "\"  ></td>";
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

                    Lbl_ContractDetails.Text += "<td class=\"ListHead\"  nowrap><b>剩余备货</b></td>";
                    Lbl_ContractDetails.Text += "<td class=\"ListHead\"  nowrap><b>核销</b></td>";
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

                KNet.BLL.KNet_Sales_ClientList Bll_Client = new KNet.BLL.KNet_Sales_ClientList();
                KNet.Model.KNet_Sales_ClientList Model_Client = Bll_Client.GetModelB(Model_Manage.XCM_CustomerValue);
                if (Model_Client != null)
                {
                    this.ContractToAddress.Text = Model_Client.CustomerAddress;
                }
            }
        }
        catch
        { }
    }
    /// <summary>
    /// 获取信息
    /// </summary>
    /// <param name="OrderNo"></param>
    protected void ShowInfo(string s_ID)
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.BLL.KNet_Sales_ContractList Bll = new KNet.BLL.KNet_Sales_ContractList();
        KNet.Model.KNet_Sales_ContractList Model = Bll.GetModelB(s_ID);
        if (AM.KNet_StaffName != "薛建新"&& AM.KNet_StaffName != "张斌")
        {
            if (this.Tbx_Type.Text != "1")
            {
                if (Model.ContractCheckYN == true)
                {

                    AlertAndGoBack("不可修改!");
                    return;
                }
                else
                {
                    if (AM.KNet_StaffNo != Model.ContractStaffNo)
                    {
                        AlertAndGoBack("不可修改!");
                        return;
                    }
                    else
                    {
                        string s_DeptID = Base_GetNextDept(s_ID, "101");
                        this.BeginQuery("select * from KNet_Sales_Flow a join KNet_Resource_Staff b on a.KSF_ShPerson=b.StaffNo Where KSF_State='0'  and KSF_ContractNo='" + s_ID + "' and StaffDepart='" + s_DeptID + "'");
                        this.QueryForDataTable();
                        if ((this.Dtb_Result.Rows.Count < 0))
                        {
                            AlertAndGoBack("不可修改!");
                            return;
                        }
                    }
                }
            }
        }
        try
        {

            if (this.Tbx_Type.Text != "1")
            {
                if (this.Tbx_ID.Text != "")
                {
                    this.ContractNo.Text = Model.ContractNo;
                }
                this.Tbx_OrderNo.Text = Model.KSC_OrderNO;
            }
            this.ContractDateTime.Text = DateTime.Parse(Model.ContractDateTime.ToString()).ToShortDateString();
            this.ContractStarDateTime.Text = DateTime.Parse(Model.ContractStarDateTime.ToString()).ToShortDateString();
            this.ContractToDeliDate.Text = DateTime.Parse(Model.ContractToDeliDate.ToString()).ToShortDateString();

        }
        catch
        { }
        this.CustomerValue.Value = Model.CustomerValue;
        this.CustomerValueName.Text = base.Base_GetCustomerName(Model.CustomerValue);
        this.Ddl_DutyPerson.SelectedValue = Model.DutyPerson;
        this.ContractToAddress.Text = Model.ContractToAddress;
        this.Drop_Payment.SelectedValue = Model.Payment;
        this.Tbx_ContentPerson.Text = Model.ContentPerson;
        this.Tbx_Telephone.Text = Model.Telephone;
        this.ContractClass.SelectedValue = Model.ContractClass;
        this.Drop_RoutineTransport.SelectedValue = Model.RoutineTransport;
        this.Drop_WorryTransport.SelectedValue = Model.WorryTransport;
        this.BaoPriceNo.Value = Model.BaoPriceNo;
        this.BaoPriceNoName.Text = Model.BaoPriceNo;
        this.ContractDeliveMethods.SelectedValue = Model.ContractDeliveMethods;
        this.Tbx_ContractShip.Text = Model.ContractShip;
        this.Tbx_FaterID.Value = Model.KSC_FaterId;
        this.Tbx_ContractState.Text = Model.ContractState.ToString();

        this.Ddl_KpType.SelectedValue = Model.KSC_KpType;

        if (this.Tbx_Type.Text == "1")
        {
            this.Tbx_ContractCheckYN.Text = "0";
        }
        else
        {
            this.Tbx_ContractCheckYN.Text = Model.ContractCheckYN.ToString();

        }

        KNet.BLL.Xs_Contract_Manage BLL_ContractManage = new KNet.BLL.Xs_Contract_Manage();
        KNet.Model.Xs_Contract_Manage Model_ContractManage = BLL_ContractManage.GetModel(Model.KSC_FaterId);
        if (Model_ContractManage != null)
        {
            this.Tbx_FaterCode.Text = Model_ContractManage.XCM_Code;
            this.DDl_Type.SelectedValue = Model_ContractManage.XCM_Type;
        }

        //


        //string[] s_MaterNumber = Model.KSC_MaterNumber.Split(',');
        //if (s_MaterNumber.Length > 0)
        //{
        //    this.Tbx_MaterNumber.Text = s_MaterNumber[0];
        //    this.Tbx_MaterNumber1.Text = s_MaterNumber[1];
        //}
        //string[] s_OrderNo = Model.KSC_CustomerOrderNo.Split(',');
        //if (s_OrderNo.Length > 0)
        //{
        //    this.Tbx_OrderNo2.Text = s_OrderNo[0];
        //    this.Tbx_OrderNo1.Text = s_OrderNo[1];
        //}
        //this.Tbx_PlanNo.Text = Model.KSC_PlanNo;
        //this.Tbx_ShipType.Text = Model.KSC_ShipType;


        if (Model.ProductsPic == 0)
        {
            this.ProductsPic.Checked = false;
            this.AddPic.Visible = false;
        }
        else
        {
            this.ProductsPic.Checked = true;
            this.AddPic.Visible = true;
            this.Image1.ImageUrl = Model.ProductsSmallPicture;
        }
        this.ContractToPayment.SelectedValue = Model.ContractToPayment;
        this.Tbx_QualityRequire.Text = Model.QualityRequire;
        this.Tbx_ProductPackaging.Text = Model.ProductPackaging;
        this.Tbx_Technicalne.Text = Model.TechnicalRequire;
        this.Tbx_DeliveryRequire.Text = Model.DeliveryRequire;
        this.Tbx_WarrantyPeriod.Text = Model.WarrantyPeriod;
        this.ContractRemarks.Text = Model.ContractRemarks;


        if (this.Tbx_OrderNo.Text == "")
        {
            this.Tbx_OrderNo.Text = "PO" + KNetOddNumbers1();
        }
        string s_OrdeURL = Model.KSC_OrderURL == null ? "" : Model.KSC_OrderURL;

        if (this.Tbx_Hx.Text == "1")//如果是核销
        {
            //如果是核销
            this.ContractClass.SelectedValue = "129687502761283812";
            this.ContractDateTime.Text = DateTime.Now.ToShortDateString();
        }
        if (s_OrdeURL != "")
        {
            this.Lbl_Details.Text = "<input Name=\"KSC_OrderURL\"  type=\"hidden\"  value=" + Model.KSC_OrderURL + "><input Name=\"KSC_OrderName\"  type=\"hidden\"  value=" + Model.KSC_OrderName + "><a href=\"" + Model.KSC_OrderURL + "\" >" + Model.KSC_OrderName + "</a>";
        }
        KNet.BLL.KNet_Sales_ContractList_Details Bll_Details = new KNet.BLL.KNet_Sales_ContractList_Details();
        DataSet Dts_Table = Bll_Details.GetList(" ContractNo='" + s_ID + "' ");
        decimal d_All_OrderTotal = 0;
        if (Dts_Table.Tables[0].Rows.Count > 0)
        {
            Lbl_ContractDetails.Text = "<Table id=\"myTable\" width=\"100%\" border=\"0\" align=\"center\" cellpadding=\"5\" cellspacing=\"0\" class=\"crmTable\">";
            Lbl_ContractDetails.Text += "<tr valign=\"middle\"><td valign=\"middle\" class=\"ListHead\" align=\"right\"  nowrap><b>工具</b></td>";
            Lbl_ContractDetails.Text += "<td class=\"ListHead\"  nowrap> <b>产品名称</b></td>";
            Lbl_ContractDetails.Text += "<td class=\"ListHead\"  nowrap><b>产品编码</b></td>";
            Lbl_ContractDetails.Text += "<td class=\"ListHead\"  nowrap><b>型号</b></td>";

            Lbl_ContractDetails.Text += "<td class=\"ListHead\"  nowrap><b>剩余备货</b></td>";
            Lbl_ContractDetails.Text += "<td class=\"ListHead\"  nowrap><b>核销</b></td>";
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
                this.Xs_ProductsCode.Text += Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString() + ",";
                d_All_OrderTotal += Decimal.Parse(Dts_Table.Tables[0].Rows[i]["Contract_SalesTotalNet"].ToString());
                Lbl_ContractDetails.Text += " <tr valign=\"middle\">";
                Lbl_ContractDetails.Text += "<td class=\"ListHeadDetails\"><A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a></td>";
                Lbl_ContractDetails.Text += "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"XCMD_ID_" + i.ToString() + "\" value='" + Dts_Table.Tables[0].Rows[i]["KSD_XCMDID"].ToString() + "'><input type=\"hidden\"  Name=\"ID_" + i.ToString() + "\" value='" + Dts_Table.Tables[0].Rows[i]["ID"].ToString() + "'>" + base.Base_GetProdutsName(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                Lbl_ContractDetails.Text += "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ProductsBarCode_" + i.ToString() + "\" value='" + Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "'>" + Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "</td>";
                Lbl_ContractDetails.Text += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";

                string s_TotalNumber = Dts_Table.Tables[0].Rows[i]["totalNumber"].ToString();
                if (this.Tbx_Type.Text == "")
                {
                    try
                    {
                        s_TotalNumber = Convert.ToString(int.Parse(s_TotalNumber) + int.Parse(Dts_Table.Tables[0].Rows[i]["ContractAmount"].ToString()) + int.Parse(Dts_Table.Tables[0].Rows[i]["KSC_BNumber"].ToString()));
                    }
                    catch
                    { }
                }
                Lbl_ContractDetails.Text += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\" Name=\"LeftTotalBhNumber_" + i.ToString() + "\" value=" + s_TotalNumber + "></td>";
                if (this.Tbx_Hx.Text == "1")
                {
                    string s_HxState = Dts_Table.Tables[0].Rows[i]["KSD_HxState"].ToString();
                    string s_HxNumber = Dts_Table.Tables[0].Rows[i]["KSD_HxNumber"].ToString();
                    if (s_HxNumber == "0")
                    {
                        s_HxState = "1";
                        s_HxNumber = Convert.ToString(decimal.Parse(Dts_Table.Tables[0].Rows[i]["ContractAmount"].ToString()) + decimal.Parse(Dts_Table.Tables[0].Rows[i]["KSC_BNumber"].ToString()));
                    }
                    Lbl_ContractDetails.Text += "<td class=\"ListHeadDetails\"><input type=\"hidden\" Name=\"HxState_" + i.ToString() + "\" value=" + s_HxState + "><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\" Name=\"HxNumber_" + i.ToString() + "\" value=" + s_HxNumber + "></td>";

                }
                else
                {
                    Lbl_ContractDetails.Text += "<td class=\"ListHeadDetails\"><input type=\"hidden\" Name=\"HxState_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["KSD_HxState"].ToString() + "><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\" Name=\"HxNumber_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["KSD_HxNumber"].ToString() + "></td>";
                }

                Lbl_ContractDetails.Text += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"ChangPrice();\" style=\"width:50px;\" Name=\"Number_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["ContractAmount"].ToString() + "></td>";
                Lbl_ContractDetails.Text += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"ChangPrice();\" style=\"width:50px;\" Name=\"BNumber_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["KSC_BNumber"].ToString() + " ></td>";
                Lbl_ContractDetails.Text += "<td class=\"ListHeadDetails\"><input type=\"text\"  class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"ChangPrice();\" style=\"width:50px;\"  Name=\"Price_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["Contract_SalesUnitPrice"].ToString() + "></td>";
                Lbl_ContractDetails.Text += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\" readonly  Name=\"Money_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["Contract_SalesTotalNet"].ToString() + " ></td>";
                Lbl_ContractDetails.Text += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\"   Name=\"PlanNumber_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["KSD_PlanNumber"].ToString() + " ></td>";
                Lbl_ContractDetails.Text += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\"   Name=\"OrderNumber_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["KSD_OrderNumber"].ToString() + " ></td>";
                Lbl_ContractDetails.Text += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\"   Name=\"MaterNumber_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["KSD_MaterNumber"].ToString() + " ></td>";
                Lbl_ContractDetails.Text += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\"   Name=\"MaterPattern_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["KSD_MaterPattern"].ToString() + " ></td>";
                Lbl_ContractDetails.Text += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\"   Name=\"IsFollow_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["KSD_IsFollow"].ToString() + " ></td>";

                Lbl_ContractDetails.Text += " <td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:100px;\"  Name=\"Remarks_" + i.ToString() + "\"  Text=\"" + Dts_Table.Tables[0].Rows[i]["ContractRemarks"].ToString() + "\" ></td>";
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

            Lbl_ContractDetails.Text += "<td class=\"ListHead\"  nowrap><b>剩余备货</b></td>";
            Lbl_ContractDetails.Text += "<td class=\"ListHead\"  nowrap><b>核销</b></td>";
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

        this.BeginQuery("select * from Xs_Contract_FhDetails where XCF_FID='" + Model.ContractNo + "'");
        DataTable Dtb_FhDetails = (DataTable)this.QueryForDataTable();
        if (Dtb_FhDetails.Rows.Count > 0)
        {
            Lbl_FhDetails.Text = "<Table id=\"myFhTable\" width=\"100%\" border=\"0\" align=\"center\" cellpadding=\"5\" cellspacing=\"0\" class=\"ListDetails\">";

            Lbl_FhDetails.Text += "<tr valign=\"middle\">";
            Lbl_FhDetails.Text += "<td class=\"ListHead\"  nowrap><b>选择</b></td>";
            Lbl_FhDetails.Text += "<td class=\"ListHead\"  nowrap><b>名称</b></td>";
            Lbl_FhDetails.Text += "<td class=\"ListHead\"  nowrap><b>详细</b></td></tr>";
            Lbl_FhDetails.Text += "</tr>";

            for (int i = 0; i < Dtb_FhDetails.Rows.Count; i++)
            {

                Lbl_FhDetails.Text += " <tr valign=\"middle\">";
                Lbl_FhDetails.Text += "<td class=\"ListHeadDetails\"><input type=\"CheckBox\" id=\"Chk_" + i.ToString() + "\" Name=\"Chk_ " + i.ToString() + "\"  checked ></td>";

                Lbl_FhDetails.Text += "<td class=\"ListHeadDetails\"><input type=\"input\" style=\"height:50px;width:65%;display:none\" Name=\"FhName_" + i.ToString() + "\"  value=\"'" + Dtb_FhDetails.Rows[i]["XCF_Name"].ToString() + "'\" >" + Dtb_FhDetails.Rows[i]["XCF_Name"].ToString() + "</td>";
                Lbl_FhDetails.Text += "<td class=\"ListHeadDetails\"><input type=\"input\" style=\"height:50px;width:65%;display:none\" Name=\"FhDetails_" + i.ToString() + "\"  value=\"'" + Dtb_FhDetails.Rows[i]["XCF_Details"].ToString() + "'\" >" + Dtb_FhDetails.Rows[i]["XCF_Details"].ToString() + "</td>";

                Lbl_FhDetails.Text += "</tr>";

            }
            Lbl_FhDetails.Text += "</table>";
            this.FhNum.Text = Dtb_FhDetails.Rows.Count.ToString();
        }
    }
    #region 返回单号情况

    /// <summary>
    /// 返回当前的  单号 （唯一性，如 2009121402）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string KNetOddNumbers()
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select isnull(Max(Right(ContractNo,3)),'0') as AA  from  KNet_Sales_ContractList  where (datediff(d,SystemDatetimes,GETDATE())=0)";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (int.Parse(dr["AA"].ToString()) == 0)
                {
                    return DateTime.Today.ToString("yyyyMMdd") + "001";
                }
                else
                {
                    return DateTime.Today.ToString("yyyyMMdd") + KNus003(int.Parse(dr["AA"].ToString()) + 1);
                }
            }
            else
            {
                return DateTime.Today.ToString("yyyyMMdd") + "001";
            }
        }
    }

    protected string KNetOddNumbers1()
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select IsNull(Max(Right(KSC_OrderNo,3)),'0') as AA  from  KNet_Sales_ContractList  where (datediff(d,SystemDatetimes,GETDATE())=0)";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (int.Parse(dr["AA"].ToString()) == 0)
                {
                    return DateTime.Today.ToString("yyyyMMdd") + "001";
                }
                else
                {
                    return DateTime.Today.ToString("yyyyMMdd") + KNus003(int.Parse(dr["AA"].ToString()) + 1);
                }
            }
            else
            {
                return DateTime.Today.ToString("yyyyMMdd") + "001";
            }
        }
    }
    //说明书
    [Ajax.AjaxMethod()]
    public string GetManual(string s_Selected)
    {
        string s_Return = "";
        try
        {
            this.BeginQuery("select * from PB_Basic_Code where PBC_ID='134'");
            this.QueryForDataSet();
            DataSet Dts_Table = Dts_Result;
            if (Dts_Table.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                {
                    s_Return += Dts_Table.Tables[0].Rows[i]["PBC_Code"].ToString() + "," + Dts_Table.Tables[0].Rows[i]["PBC_Name"].ToString();

                    if (Dts_Table.Tables[0].Rows[i]["PBC_Code"].ToString() == s_Selected)
                    {
                        s_Return += "," + " selected";
                    }
                    else
                    {
                        s_Return += "," + " ";
                    }
                    s_Return += "|";
                }
            }
        }
        catch (Exception ex)
        {
            s_Return = "";
        }
        return s_Return;
    }
    [Ajax.AjaxMethod()]
    public string GetBattery(string s_Selected)
    {
        string s_Return = "";
        try
        {
            KNet.BLL.KNet_Sys_Products Bll = new KNet.BLL.KNet_Sys_Products();
            DataSet Dts_Table = Bll.GetList(" ProductsMainCategory='129790301274394159'");
            if (Dts_Table.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                {
                    s_Return += Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "," + Dts_Table.Tables[0].Rows[i]["ProductsPattern"].ToString();
                    if (Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString() == s_Selected)
                    {
                        s_Return += "," + "selected";
                    }
                    else
                    {
                        s_Return += "," + " ";
                    }
                    s_Return += "|";
                }
            }
        }
        catch (Exception ex)
        {
            s_Return = "";
        }
        return s_Return;
    }
    /// <summary>
    /// 返回当前的  单号 （唯一性，如 2009121402）
    /// </summary>
    /// <param name="ss"></param>
    /// <returns></returns>
    protected string KNus003(int ss)
    {
        if (ss.ToString().Length == 1)
        {
            return "00" + ss.ToString();
        }
        else if (ss.ToString().Length == 2)
        {
            return "0" + ss.ToString();
        }
        else if (ss.ToString().Length == 3)
        {
            return ss.ToString();
        }
        else
        {
            return ss.ToString();
        }
    }
    #endregion


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

    public bool SetValue(KNet.Model.KNet_Sales_ContractList molel)
    {

        try
        {
            string ContractNo = KNetPage.KHtmlEncode(this.ContractNo.Text.Trim());
            string ContractTopic = "";
            string CustomerValue = KNetPage.KHtmlEncode(this.CustomerValue.Value.Trim());
            DateTime ContractDateTime = DateTime.Now;
            DateTime? ContractStarDateTime = DateTime.Parse("1900-10-10");
            DateTime? ContractEndtDateTime = DateTime.Parse("1900-10-10");
            DateTime? ContractToDeliDate = DateTime.Parse("1900-10-10");
            try
            {
                ContractDateTime = DateTime.Parse(this.ContractDateTime.Text.Trim());
            }
            catch { }

            try
            {
                ContractStarDateTime = DateTime.Parse(this.ContractStarDateTime.Text.Trim());
                ContractToDeliDate = DateTime.Parse(this.ContractToDeliDate.Text.Trim());
                ContractEndtDateTime = DateTime.Parse(this.ContractEndtDateTime.Text.Trim());
            }
            catch { }

            string ContractOursDelegate = "";//我方代表
            string ContractSideDelegate = "";//对方代表


            decimal ContractTranShare = 0;
            string ContractClass = this.ContractClass.SelectedValue;

            string ContractToAddress = KNetPage.KHtmlEncode(this.ContractToAddress.Text);
            string ContractDeliveMethods = KNetPage.KHtmlEncode(this.ContractDeliveMethods.SelectedValue);

            string BaoPriceNo = KNetPage.KHtmlEncode(this.BaoPriceNo.Value.Trim());


            string ContractToPayment = this.ContractToPayment.SelectedValue;


            string ContractStaffBranch = "";
            string ContractStaffDepart = "";

            //string ContractStaffNo = this.ContractStaffNotxt.Text.Trim();
            string ContractCheckStaffNo = "";
            string ContractRemarks = KNetPage.KHtmlEncode(this.ContractRemarks.Text.Trim());

            string HouseNo = ""; //仓库

            molel.ContractNo = ContractNo;
            molel.ContractTopic = ContractTopic;
            molel.CustomerValue = CustomerValue;
            molel.ContractDateTime = ContractDateTime;
            molel.ContractStarDateTime = ContractStarDateTime;
            molel.ContractEndtDateTime = ContractEndtDateTime;

            molel.ContractOursDelegate = ContractOursDelegate;
            molel.ContractSideDelegate = ContractSideDelegate;
            molel.ContractClass = ContractClass;

            molel.ContractTranShare = ContractTranShare;
            molel.ContractDeliveMethods = ContractDeliveMethods;
            molel.ContractToAddress = ContractToAddress;


            molel.ContractToDeliDate = ContractToDeliDate;
            molel.ContractToPayment = ContractToPayment;
            molel.HouseNo = HouseNo;


            molel.BaoPriceNo = BaoPriceNo; //关联报价唯一值



            molel.ContractStaffBranch = ContractStaffBranch;
            molel.ContractStaffDepart = ContractStaffDepart;

            molel.KSC_OrderNO = this.Tbx_OrderNo.Text;
            molel.KSC_OrderName = Request["KSC_OrderName"] == null ? "" : Request["KSC_OrderName"].ToString();
            molel.KSC_OrderURL = Request["KSC_OrderURL"] == null ? "" : Request["KSC_OrderURL"].ToString();

            AdminloginMess AM = new AdminloginMess();
            molel.ContractStaffNo = AM.KNet_StaffNo;
            molel.ContractCheckStaffNo = ContractCheckStaffNo;
            molel.ContractRemarks = ContractRemarks;

            //增加

            molel.Payment = this.Drop_Payment.SelectedValue;//付款方式
            molel.RoutineTransport = this.Drop_RoutineTransport.SelectedValue;
            molel.WorryTransport = this.Drop_WorryTransport.SelectedValue;
            molel.TechnicalRequire = this.Tbx_Technicalne.Text;
            molel.ProductPackaging = this.Tbx_ProductPackaging.Text;
            molel.QualityRequire = this.Tbx_QualityRequire.Text;
            molel.WarrantyPeriod = this.Tbx_WarrantyPeriod.Text;
            molel.DeliveryRequire = this.Tbx_DeliveryRequire.Text;
            molel.ContentPerson = this.Tbx_ContentPerson.Text;
            molel.Telephone = this.Tbx_Telephone.Text;
            molel.ProductsBigPicture = this.Image1Big.Text;
            molel.ProductsSmallPicture = this.Image1.ImageUrl;
            molel.ContractShip = this.Tbx_ContractShip.Text;
            molel.DutyPerson = this.Ddl_DutyPerson.SelectedValue;
            molel.KSC_FaterId = this.Tbx_FaterID.Value;
            molel.KSC_KpType = this.Ddl_KpType.SelectedValue;
            try
            {
                molel.ContractState = int.Parse(this.Tbx_ContractState.Text);
                molel.ContractCheckYN = bool.Parse(this.Tbx_ContractCheckYN.Text);
            }
            catch
            { }
            //

            molel.KSC_ShipType = "";
            //  molel.KSC_MaterNumber = this.Tbx_MaterNumber.Text + "," + this.Tbx_MaterNumber1.Text;
            // molel.KSC_CustomerOrderNo = this.Tbx_OrderNo2.Text + "," + this.Tbx_OrderNo1.Text;
            molel.KSC_PlanNo = "";

            //
            molel.KSC_Creator = AM.KNet_StaffNo;
            molel.KSC_Mender = AM.KNet_StaffNo;
            molel.KSC_CTime = DateTime.Now;
            molel.KSC_MTime = DateTime.Now;

            if (this.ProductsPic.Checked)
            {
                molel.ProductsPic = 1;
            }
            else
            {
                molel.ProductsPic = 0;
            }


            ArrayList Arr_Details = new ArrayList();

            int i_num = int.Parse(this.i_Num.Text);
            bool b_True = false;
            for (int i = 0; i < i_num; i++)
            {
                KNet.Model.KNet_Sales_ContractList_Details ModelDetails = new KNet.Model.KNet_Sales_ContractList_Details();
                if (Request["ProductsBarCode_" + i] != null)
                {
                    string s_ProductsBarCode = Request["ProductsBarCode_" + i].ToString();
                    string s_ContractDetailsID = Request["ID_" + i] == null ? GetMainID(i) : Request["ID_" + i].ToString();
                    string s_XCMD_ID = Request["XCMD_ID_" + i] == null ? "" : Request["XCMD_ID_" + i].ToString();
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

                    string s_HxNumber = Request["HxNumber_" + i] == "" ? "0" : Request["HxNumber_" + i].ToString();

                    string s_HxState = Request["HxState_" + i] == "" ? "0" : Request["HxState_" + i].ToString();

                    ModelDetails.ProductsBarCode = s_ProductsBarCode;
                    ModelDetails.ContractAmount = int.Parse(s_Number);
                    ModelDetails.Contract_SalesUnitPrice = decimal.Parse(s_Price);
                    ModelDetails.Contract_SalesTotalNet = decimal.Parse(s_Money);
                    ModelDetails.ContractNo = ContractNo;
                    ModelDetails.ContractRemarks = s_Remarks;
                    ModelDetails.KSD_OrderNumber = s_OrderNumber;
                    ModelDetails.KSD_MaterNumber = s_MaterNumber;
                    ModelDetails.KSD_IsFollow = s_IsFollow;
                    ModelDetails.KSD_MaterPattern = s_MaterPattern;
                    ModelDetails.KSD_PlanNumber = s_PlanNumber;
                    ModelDetails.KSD_XCMDID = s_XCMD_ID;
                    try
                    {
                        int i_LeftNumber = int.Parse(s_Number) + int.Parse(s_BNumber) - int.Parse(s_HxNumber);
                        if (i_LeftNumber != 0)
                        {
                            b_True = true;
                        }
                        ModelDetails.KSD_HxState = int.Parse(s_HxState);
                        ModelDetails.KSD_HxNumber = int.Parse(s_HxNumber);
                    }
                    catch
                    {
                        ModelDetails.KSD_HxState = 0;
                        ModelDetails.KSD_HxNumber = 0;
                    }
                    try
                    {
                        ModelDetails.KSD_HxState = 0;
                        ModelDetails.KSD_HxNumber = 0;
                        b_True = false;
                        //去除核销
                    }
                    catch
                    { }
                    if (this.Tbx_Type.Text == "1")
                    {
                        ModelDetails.ID = base.GetMainID(i);
                    }
                    else
                    {
                        ModelDetails.ID = s_ContractDetailsID;
                    }
                    ModelDetails.KSC_BNumber = int.Parse(s_BNumber);
                    ModelDetails.KSC_OrderBNumber = int.Parse(s_OrderBNumber);
                    Arr_Details.Add(ModelDetails);
                }
            }
            /*
            if (b_True == false)
            {
                molel.ContractCheckYN = true;
                molel.ContractState = 1;
                molel.isOrder = 1;
            }
             * */

            molel.arr_Details = Arr_Details;

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
                    Model_FhDetails.XCF_FID = molel.ContractNo;
                    Model_FhDetails.XCF_Name = s_FHName;
                    Model_FhDetails.XCF_Details = s_FHDetail;
                    Arr_FhDetails.Add(Model_FhDetails);
                }
            }
            molel.arr_FhDetails = Arr_FhDetails;

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    /// <summary>
    /// 确定开订单
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button3_Click(object sender, EventArgs e)
    {
        KNet.BLL.KNet_Sales_ContractList BLL = new KNet.BLL.KNet_Sales_ContractList();
        KNet.Model.KNet_Sales_ContractList Model = new KNet.Model.KNet_Sales_ContractList();
        //如果是一般合同
        if (this.ContractClass.SelectedValue == "129687502761283812")
        {
            if (this.Lbl_Details.Text == "")
            {
                Alert("请上传订单原件！");
                return;
            }
        }

        if (this.SetValue(Model) == false)
        {
            Alert("系统错误！");
            return;
        }
        try
        {
            if (this.Tbx_ID.Text == "")
            {
                if (BLL.Exists(this.ContractNo.Text) == false)
                {
                    BLL.Add(Model);
                    string s_Text = "";
                    string s_Alert = "";
                    if (Model.isOrder == 1)
                    {
                        string s_Sql = "Update KNet_Sales_ContractList set  isOrder=2  where ContractNo='" + this.ContractNo.Text + "'  ";
                        DbHelperSQL.ExecuteSql(s_Sql);
                    }
                    else
                    {
                        if (Is_Mail.Checked)
                        {
                            s_Text = "订单编号为：" + this.ContractNo.Text + " 需要您审批,请及时登录系统审批。";
                            KNet.BLL.KNet_Resource_Staff BLL_Resource_Staff = new KNet.BLL.KNet_Resource_Staff();
                            KNet.Model.KNet_Resource_Staff Model_Resource_Staff = BLL_Resource_Staff.GetModelC(this.Ddl_DutyPerson.SelectedValue);
                            try
                            {
                                base.Base_SendMessage(base.Base_GetDeptPerson("总经理", 1), KNetPage.KHtmlEncode("有 订单评审 <a href='Web/Xs/SalesContract/KNet_Sales_ContractList_View.aspx?ID=" + this.ContractNo.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + this.ContractNo.Text + "</a> 需要您作为负责人选择审批流程，敬请关注！"));
                               // s_Alert = base.Base_SendEmail(Model_Resource_Staff.StaffEmail, s_Text, "订单评审审核！");
                            }
                            catch { } }
                    }
                    AdminloginMess LogAM = new AdminloginMess();
                    LogAM.Add_Logs("销售管理--->添加销售订单 操作成功！订单编号：" + this.ContractNo.Text);


                    Response.Write("<script>alert('添加销售订单  操作成功," + s_Alert + "！ ！');location.href='KNet_Sales_ContractList_List.aspx';</script>");
                    Response.End();
                }
                else
                {
                    Response.Write("<script>alert('订单编号已存在 添加失败！');history.back(-1);</script>");
                    Response.End();
                }
            }
            else
            {
                BLL.Update(Model);
                AdminloginMess LogAM = new AdminloginMess();
                LogAM.Add_Logs("销售管理--->修改销售订单 操作成功！订单编号：" + this.ContractNo.Text);
                Response.Write("<script>alert('修改销售订单  操作成功 ！');location.href='KNet_Sales_ContractList_List.aspx';</script>");
                Response.End();
            }
        }
        catch (Exception ex)
        { }

    }



    /// <summary>
    /// 获取用户未结算额度
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected decimal GetLoanAmount(string CustomerValue)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select sum(LoanAmount) as AA from A_Deliveryfa where CustomerValue='" + CustomerValue + "' and  SettlementStatus=1";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return decimal.Parse(dr["AA"].ToString());
            }
            else
            {
                return 0;
            }
        }
    }

    /// <summary>
    /// 打开上传图片
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ProductsPic_CheckedChanged(object sender, EventArgs e)
    {
        if (this.ProductsPic.Checked == true)
        {
            this.AddPic.Visible = true;
        }
        else
        {
            this.AddPic.Visible = false;
        }
    }


    #region 图片上传操作
    /// <summary>
    /// 上传图片
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
            if (FileType == "image/gif" || FileType == "image/pjpeg")
            {
                GetThumbnailImage();
            }
            else
            {
                Response.Write("<script language=javascript>alert('文件类型服务器不接受！类型:" + FileType + " ');history.back(-1);</script>");
                Response.End();
            }
        }
    }

    /// <summary>
    /// 图片上传
    /// </summary>
    protected void GetThumbnailImage()
    {
        string UploadPath = "../UpLoadPic/Contract/";  //上传路径

        string AutoPath = System.DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "");
        string fileExt = Path.GetExtension(uploadFile.PostedFile.FileName); //获扩展名
        string FileType = uploadFile.PostedFile.ContentType.ToString(); //文件类型

        string filePath = UploadPath + AutoPath + fileExt; //大文件名
        string filePathsmall = UploadPath + AutoPath + "_small" + fileExt; //小文件名

        string newfile = filePath + ".jpg"; //略图文件名

        if (FileType == "image/gif" || FileType == "image/pjpeg")
        {
            uploadFile.PostedFile.SaveAs(Server.MapPath(filePath)); //上传

            Up_Loadcs UL = new Up_Loadcs();

            UL.MakeZoomImage(Server.MapPath("../UpLoadPic/Contract/") + AutoPath + fileExt, Server.MapPath("~/Web/UpLoadPic/Contract/") + AutoPath + "_small" + fileExt, 95, 75, "HW");

            this.Image1.ImageUrl = "../UpLoadPic/Contract/" + AutoPath + "_small" + fileExt;
            this.Image1Big.Text = filePath;
        }
        else
        {
            Response.Write("<script language=javascript>alert('文件类型服务器不接受！类型:" + FileType + " ');history.back(-1);</script>");
            Response.End();
        }
    }

    #endregion


    #region 订单上传操作
    /// <summary>
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void button_ServerClick1(object sender, EventArgs e)
    {
        if (!(uploadFile1.PostedFile.ContentLength > 0))
        {
            Alert("您没有选择文件!");
        }
        else
        {
            string FileType = uploadFile1.PostedFile.ContentType.ToString(); //文件类型
            GetThumbnailImage1();
        }
    }
    /// <summary>
    /// 图片上传
    /// </summary>
    protected void GetThumbnailImage1()
    {
        string UploadPath = "../../UpFile/Order/";  //上传路径
        if (this.CustomerValue.Value != "")
        {
            UploadPath += this.CustomerValue.Value + "/";
        }
        string AutoPath = System.DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "").Replace("/", "");
        string fileExt = Path.GetExtension(uploadFile1.PostedFile.FileName); //获扩展名
        string FileType = uploadFile1.PostedFile.ContentType.ToString(); //文件类型
        string FileName = Path.GetFileName(uploadFile1.PostedFile.FileName);
        string filePath = UploadPath + AutoPath + fileExt;
        if (!Directory.Exists(Server.MapPath(UploadPath)))
        {
            Directory.CreateDirectory(Server.MapPath(UploadPath));
        }
        uploadFile1.PostedFile.SaveAs(Server.MapPath(filePath)); //上传
        this.Lbl_Details.Text = "<input Name=\"KSC_OrderURL\"  type=\"hidden\"  value=" + filePath + "><input Name=\"KSC_OrderName\"  type=\"hidden\"  value=" + FileName + "><a href=\"" + filePath + "\" >" + FileName + "</a>";
        this.Lbl_ContractDetails.Text = this.Lbl_ContractDetails1.Text;
        this.Lbl_FhDetails.Text = this.Lbl_FhDetails1.Text;

    }

    #endregion
}
