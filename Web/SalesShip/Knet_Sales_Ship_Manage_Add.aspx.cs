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


/// <summary>
/// 销售管理-----发货单 管理
/// </summary>
public partial class Knet_Web_Sales_Knet_Sales_Ship_Manage_Add : BasePage
{
    public string s_MyTable_Detail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(Knet_Web_Sales_Knet_Sales_Ship_Manage_Add));
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            this.Tbx_Type.Text = s_Type;
            base.Base_DropBasicCodeBind(this.Ddl_Step, "133");//类型
            this.Ddl_Step.SelectedValue = "0";
            base.Base_DropDutyPerson(this.Ddl_DutyPerson);
            this.OutWareDateTime.Text = DateTime.Now.ToShortDateString();
            this.OutWareOursContact.Text = AM.KNet_StaffName;
            base.Base_DropBasicCodeBind(this.Ddl_ShipType, "145");
            this.Ddl_ShipType.SelectedValue = "0";
            base.Base_DropKClaaBind(this.ContractDeliveMethods, 5, "", "请选择交货方式");
            base.Base_DropDutyPerson(this.Ddl_DutyPerson);
            if (s_ID != "")
            {
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制发货通知单";
                    this.OutWareNo.Text = base.GetNewID("KNet_Sales_OutWareList", 0);
                }
                else
                {
                    this.Lbl_Title.Text = "修改发货通知单";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }
            else
            {
                SHowContract();
                ShowDetails();
                base.Base_GetFHDetails(this.Ddl_FhDetails, " XCF_CustomerValue='" + this.Tbx_CustomerValue.Value + "'");
                this.Lbl_Title.Text = "新增发货通知单";
                this.OutWareNo.Text = base.GetNewID("KNet_Sales_OutWareList", 0);
            }

            if (AM.CheckLogin(this.Lbl_Title.Text) == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
        }
    }

    private void ShowDetails()
    {
        //未发
        try
        {
            string s_Customer = Request.QueryString["CustomerValue"] == null ? "" : Request.QueryString["CustomerValue"].ToString();
            string s_ProductsBarCode = Request.QueryString["ProductsBarCode"] == null ? "" : Request.QueryString["ProductsBarCode"].ToString();
            this.Tbx_Customer.Text = s_Customer;
            this.Tbx_ProductsBar.Text = s_ProductsBarCode;
            if ((s_Customer != "") && (s_ProductsBarCode != ""))
            {
                this.Tbx_CustomerValue.Value = s_Customer;
                this.Tbx_CustomerName.Text = base.Base_GetCustomerName(s_Customer);
                this.Tbx_SCustomerValue.Value = s_Customer;
                this.Tbx_SCustomerName.Text = base.Base_GetCustomerName(s_Customer);

                KNet.BLL.KNet_Sales_OutWareList Bll = new KNet.BLL.KNet_Sales_OutWareList();
                KNet.Model.KNet_Sales_OutWareList Model = Bll.GetLaseModel(s_Customer);
                if (Model != null)
                {
                    string s_PersonID = Model.OutWareSideContact;
                    string s_PersonName = Model.OutWareSideContact == "" ? Model.KSO_ContentPersonName : base.Base_GetLinkManValue(Model.OutWareSideContact, "XOL_Name");
                    string s_Adress = Model.OutWareSideContact == "" ? Model.ContractToAddress : base.Base_GetLinkManValue(Model.OutWareSideContact, "XOL_Address");
                    string s_Tel = Model.OutWareSideContact == "" ? Model.KSO_TelPhone : base.Base_GetLinkManValue(Model.OutWareSideContact, "XOL_Phone");
                    this.Tbx_ContentPersonID.Text = s_PersonID;
                    this.Tbx_ContentPerson.Text = s_PersonName;
                    this.ContractToAddress.Text = s_Adress;
                    this.Tbx_Phone.Text = s_Tel;
                    this.ContractDeliveMethods.SelectedValue = Model.ContractDeliveMethods;
                    if (s_ProductsBarCode != "")
                    {
                        string s_Sql = "Select v_CustomerValue,v_ProductsBarCode,Sum(v_LeftOutWareNumber) LeftNumber,Sum(v_LeftOutWareBNumber) LeftBNumber from v_Contract_OutWare_DirectOut_Total where v_CustomerValue='" + s_Customer + "' and v_ProductsBarCode='" + s_ProductsBarCode + "' Group by v_CustomerValue,v_ProductsBarCode ";
                        this.BeginQuery(s_Sql);
                        this.QueryForDataSet();
                        DataSet Dts_Table = this.Dts_Result;
                        
                        for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                        {
                            string s_ProductsCode = Dts_Table.Tables[0].Rows[i]["v_ProductsBarCode"].ToString();

                            string s_Price = "";
                            //找单价
                            s_Sql = "Select b.Contract_SalesUnitPrice from v_Contract_OutWare_DirectOut_Total a join KNEt_Sales_ContractList_details b on a.V_ContractNo=b.ContractNO where v_CustomerValue='" + s_Customer + "' and v_ProductsBarCode='" + s_ProductsCode + "' and v_LeftOutWareTotalNumber>0 ";
                            this.BeginQuery(s_Sql);
                            this.QueryForDataTable();
                            DataTable Dtb_Details = this.Dtb_Result;
                            if (Dtb_Details.Rows.Count > 0)
                            {
                                s_Price = Dtb_Details.Rows[0][0].ToString();
                            }
                            string s_BNumber = Dts_Table.Tables[0].Rows[i]["LeftBNumber"].ToString();
                            string s_Number = Dts_Table.Tables[0].Rows[i]["LeftNumber"].ToString();
                            string s_Money = "0";
                            try
                            {
                                s_Money = Convert.ToString(decimal.Parse(s_Number) * decimal.Parse(s_Price == "" ? "0" : s_Price));
                            }
                            catch
                            { }
                            this.Xs_ProductsCode.Text += s_ProductsCode + ",";
                            s_MyTable_Detail += " <tr>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\"><A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a></td>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\">&nbsp;</td>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ProductsBarCode_" + i.ToString() + "\" value='" + s_ProductsCode + "'><input type=\"hidden\"  Name=\"ProductsName_" + i.ToString() + "\" value='" + base.Base_GetProdutsName(s_ProductsCode) + "'>" + base.Base_GetProdutsName(s_ProductsCode) + "</td>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition_Link(s_ProductsBarCode) + "</td>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\"></td>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Style=\"display:none\" Name=\"LeftNumber_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["LeftNumber"].ToString() + " >" + Dts_Table.Tables[0].Rows[i]["LeftNumber"].ToString() + "</td>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"ChangPrice();this.className=\'detailedViewTextBox\'\" style=\"width:50px;\" Name=\"Number_" + i.ToString() + "\" value=" + s_Number + "></td>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"ChangPrice();this.className=\'detailedViewTextBox\'\" style=\"width:50px;\" Name=\"BNumber_" + i.ToString() + "\" value=" + s_BNumber + " ></td>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\"  class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"ChangPrice();this.className='\"detailedViewTextBox'\" style=\"width:50px;\"  Name=\"Price_" + i.ToString() + "\" value=" + s_Price + "></td>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\" readonly  Name=\"Money_" + i.ToString() + "\" value=" + s_Money + " ></td>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\" Name=\"PlanNumber_" + i.ToString() + "\"  ></td>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\" Name=\"RCOrderNo_" + i.ToString() + "\" ></td>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\" Name=\"RCMNo_" + i.ToString() + "\"  ></td>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\" Name=\"MaterPattern_" + i.ToString() + "\"  ></td>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\" Name=\"IsFollow_" + i.ToString() + "\"  ></td>";
                            s_MyTable_Detail += " <td><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\"  Name=\"Remarks_" + i.ToString() + "\"  ></td>";
                            s_MyTable_Detail += " </tr>";
                        }


                        this.i_Num.Text = Dts_Table.Tables[0].Rows.Count.ToString();
                    }
                }
            }
        }
        catch (Exception ex)
        { }
    }
    private void SHowContract()
    {

        string s_ContractNo = Request.QueryString["ContractNo"] == null ? "" : Request.QueryString["ContractNo"].ToString();
        if (s_ContractNo != "")
        {
            this.Tbx_ContractNo.Text = s_ContractNo;
            if (Knet_Procure_OrdersListYN(s_ContractNo) == true)
            {

                KNet.BLL.KNet_Sales_ContractList Bll_Contract = new KNet.BLL.KNet_Sales_ContractList();
                KNet.Model.KNet_Sales_ContractList Model_Contract = Bll_Contract.GetModelB(s_ContractNo);

                this.Ddl_DutyPerson.SelectedValue = Model_Contract.DutyPerson;
                this.Tbx_CustomerValue.Value = Model_Contract.CustomerValue;
                this.Tbx_SCustomerValue.Value = Model_Contract.CustomerValue;
                this.Tbx_CustomerName.Text = base.Base_GetCustomerName(Model_Contract.CustomerValue);
                this.Tbx_SCustomerName.Text = this.Tbx_CustomerName.Text;

                KNet.BLL.KNet_Sales_OutWareList Bll = new KNet.BLL.KNet_Sales_OutWareList();
                KNet.Model.KNet_Sales_OutWareList Model = Bll.GetLaseModel(Model_Contract.CustomerValue);
                if (Model != null)
                {
                    string s_PersonID = Model.OutWareSideContact;
                    string s_PersonName = Model.OutWareSideContact == "" ? Model.KSO_ContentPersonName : base.Base_GetLinkManValue(Model.OutWareSideContact, "XOL_Name");
                    string s_Adress = Model.OutWareSideContact == "" ? Model.ContractToAddress : base.Base_GetLinkManValue(Model.OutWareSideContact, "XOL_Address");
                    string s_Tel = Model.OutWareSideContact == "" ? Model.KSO_TelPhone : base.Base_GetLinkManValue(Model.OutWareSideContact, "XOL_Phone");
                    this.Tbx_ContentPersonID.Text = s_PersonID;
                    this.Tbx_ContentPerson.Text = s_PersonName;
                    this.Tbx_Phone.Text = s_Tel;
                    this.ContractToAddress.Text = s_Adress;
                    this.ContractDeliveMethods.SelectedValue = Model.ContractDeliveMethods;
                    this.Ddl_ShipType.SelectedValue = Model.KSO_Type;
                }
                KNet.BLL.KNet_Sales_ContractList_Details Bll_Details = new KNet.BLL.KNet_Sales_ContractList_Details();
                DataSet Dts_Table = Bll_Details.GetListByView(" ContractNo='" + s_ContractNo + "'");
                decimal d_All_OrderTotal = 0;
                if (Dts_Table.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                    {
                        this.Xs_ProductsCode.Text += Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString() + ",";
                        d_All_OrderTotal += Decimal.Parse(Dts_Table.Tables[0].Rows[i]["Contract_SalesTotalNet"].ToString());
                        s_MyTable_Detail += " <tr>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\"><A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a></td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ContractNo_" + i.ToString() + "\" value='" + Dts_Table.Tables[0].Rows[i]["ContractNo"].ToString() + "'>" + Dts_Table.Tables[0].Rows[i]["ContractNo"].ToString() + "</td>";

                        s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ProductsBarCode_" + i.ToString() + "\" value='" + Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "'><input type=\"hidden\"  Name=\"ProductsName_" + i.ToString() + "\" value='" + base.Base_GetProdutsName(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "'><input type=\"hidden\"  Name=\"ID_" + i.ToString() + "\" value='" + Dts_Table.Tables[0].Rows[i]["ID"].ToString() + "'>" + base.Base_GetProdutsName(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";

                        s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Table.Tables[0].Rows[i]["ContractAmount"].ToString() + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Style=\"display:none\" Name=\"LeftNumber_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["LeftNumber"].ToString() + " >" + Dts_Table.Tables[0].Rows[i]["LeftNumber"].ToString() + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"ChangPrice();this.className=\'detailedViewTextBox\'\" style=\"width:50px;\" Name=\"Number_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["LeftNumber"].ToString() + "></td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"ChangPrice();this.className=\'detailedViewTextBox\'\" style=\"width:50px;\" Name=\"BNumber_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["KSC_BNumber"].ToString() + " ></td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\"  class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"ChangPrice();this.className='\"detailedViewTextBox'\" style=\"width:50px;\"  Name=\"Price_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["Contract_SalesUnitPrice"].ToString() + "></td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\" readonly  Name=\"Money_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["Contract_SalesTotalNet"].ToString() + " ></td>";

                        s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\" Name=\"PlanNumber_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["KSD_PlanNumber"].ToString() + " ></td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\" Name=\"RCOrderNo_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["KSD_OrderNumber"].ToString() + " ></td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\" Name=\"RCMNo_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["KSD_MaterNumber"].ToString() + " ></td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\" Name=\"MaterPattern_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["KSD_MaterPattern"].ToString() + " ></td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\" Name=\"IsFollow_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["KSD_IsFollow"].ToString() + " ></td>";
                        s_MyTable_Detail += " <td><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\"  Name=\"Remarks_" + i.ToString() + "\"  ></td>";

                        s_MyTable_Detail += " </tr>";
                        if (this.Tbx_ContractNo.Text != "")
                        {
                            this.Xs_ProductsCode.Text += Dts_Table.Tables[0].Rows[i]["ID"].ToString() + ",";
                        }
                        this.i_Num.Text = Dts_Table.Tables[0].Rows.Count.ToString();
                    }
                }
            }
            else
            {
                Response.Write("<script language=javascript>alert('您所选择的合同编号出错，未满足发货条件！');history.back(-1);</script>");
                Response.End();
            }
        }
    }
    /// <summary>
    /// 是否复合发货条件   合同状态（0未执行，1执行中，2出货中，3作废，4完成）
    /// </summary>
    /// <param name="OrderNo"></param>
    /// <returns></returns>
    protected bool Knet_Procure_OrdersListYN(string ContractNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ContractNo,ID,ContractState,ContractCheckYN from KNet_Sales_ContractList where ContractNo='" + ContractNo + "' and ContractCheckYN=1 and ( ContractState=1 or  ContractState=2 )";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }


    /// <summary>
    /// 获取信息
    /// </summary>
    /// <param name="OrderNo"></param>
    protected void ShowInfo(string OutWareNo)
    {

        AdminloginMess AM = new AdminloginMess();
        KNet.BLL.KNet_Sales_OutWareList BLL = new KNet.BLL.KNet_Sales_OutWareList();
        KNet.Model.KNet_Sales_OutWareList model = BLL.GetModelB(OutWareNo);

        string s_CK = GetCk(model.OutWareNo);

        if (this.Tbx_Type.Text != "1")
        {
            if (s_CK != "")
            {
                AlertAndGoBack("已出库不能修改！");
                return;
            }
            else if (model.OutWareCheckYN == true)
            {

               // AlertAndGoBack("已审核不能修改！");
              //  return;
            }
        }
        this.OutWareNo.Text = model.OutWareNo;
        this.Ddl_ShipType.SelectedValue = model.KSO_ShipType;
        this.Ddl_DutyPerson.SelectedValue = model.DutyPerson;
        this.Ddl_Step.SelectedValue = model.OutWareTopic;
        this.Tbx_OutWareCheckYN.Text = model.OutWareCheckYN.ToString();
        try
        {
            this.OutWareDateTime.Text = DateTime.Parse(model.OutWareDateTime.ToString()).ToShortDateString();
        }
        catch { }
        try
        {
            this.PlanOutWareDateTime.Text = DateTime.Parse(model.KSO_PlanOutWareDateTime.ToString()).ToShortDateString();
        }
        catch { }
        this.Ddl_ShipType.SelectedValue = model.KSO_Type;
        if (model.KSO_SCustomerValue != model.CustomerValue)
        {
            this.Tbx_SCustomerValue.Value = model.CustomerValue;
            this.Tbx_SCustomerName.Text = base.Base_GetCustomerName(model.CustomerValue);
            this.Tbx_CustomerValue.Value = model.KSO_SCustomerValue;
            this.Tbx_CustomerName.Text = base.Base_GetCustomerName(model.KSO_SCustomerValue);
        }
        else
        {
            this.Tbx_SCustomerValue.Value = model.CustomerValue;
            this.Tbx_SCustomerName.Text = base.Base_GetCustomerName(model.CustomerValue);
            this.Tbx_CustomerValue.Value = model.CustomerValue;
            this.Tbx_CustomerName.Text = base.Base_GetCustomerName(model.CustomerValue);
        }

        //if (s_MaterNumber.Length > 0)
        //{
        //    this.Tbx_MaterNumber.Text = s_MaterNumber[0];
        //    this.Tbx_MaterNumber1.Text = s_MaterNumber[1];
        //}
        //string[] s_OrderNo = model.KSO_OrderNo.Split(',');
        //if (s_OrderNo.Length > 0)
        //{
        //    this.Tbx_OrderNo.Text = s_OrderNo[0];
        //    this.Tbx_OrderNo1.Text = s_OrderNo[1];
        //}
        this.Tbx_ContractNo.Text = model.ContractNo;
        base.Base_GetFHDetails(this.Ddl_FhDetails, " XCF_CustomerValue='" + this.Tbx_CustomerValue.Value + "'");
        this.BeginQuery("Select * from Xs_Customer_FhInfo where XCF_CustomerValue='" + this.Tbx_CustomerValue.Value + "' and  XCF_Details='" + model.KSO_FhDetails + "'");
        this.QueryForDataTable();
        if (Dtb_Result.Rows.Count > 0)
        {
            this.Ddl_FhDetails.SelectedValue = Dtb_Result.Rows[0][0].ToString();
        }
        this.Ddl_Step.SelectedValue = model.OutWareTopic;
        this.ContractDeliveMethods.SelectedValue = model.ContractDeliveMethods;
        this.Tbx_ContentPersonID.Text = model.OutWareSideContact;
        this.Tbx_ContentPerson.Text = base.Base_GetLinkManValue(model.OutWareSideContact, "XOL_Name");//收货联系人
        this.ContractToAddress.Text = model.ContractToAddress;
        this.Tbx_Phone.Text = model.KSO_TelPhone;
        this.Tbx_Remarks.Text = model.OutWareRemarks;


        KNet.BLL.KNet_Sales_OutWareList_Details Bll_Details = new KNet.BLL.KNet_Sales_OutWareList_Details();
        DataSet Dts_Table = Bll_Details.GetList(" OutWareNo='" + model.OutWareNo + "'");
        decimal d_All_OrderTotal = 0;
        if (Dts_Table.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
            {
                d_All_OrderTotal += Decimal.Parse(Dts_Table.Tables[0].Rows[i]["OutWare_SalesTotalNet"].ToString());
                KNet.BLL.KNet_Sales_ContractList_Details BLL_Details = new KNet.BLL.KNet_Sales_ContractList_Details();
                DataSet Dts_Contract = BLL_Details.GetListByView(" ID='" + Dts_Table.Tables[0].Rows[i]["KSO_ContractDetailsID"].ToString() + "' ");
                s_MyTable_Detail += " <tr>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a></td>";
                string s_ContractNo = "";
                try
                {
                    s_ContractNo = Dts_Table.Tables[0].Rows[i]["KSD_ContractNo"] == null ? "" : Dts_Table.Tables[0].Rows[i]["KSD_ContractNo"].ToString();
                }
                catch { }
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ContractNo_" + i.ToString() + "\" value='" + s_ContractNo + "'>" + s_ContractNo + "&nbsp;</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ProductsBarCode_" + i.ToString() + "\" value='" + Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "'><input type=\"hidden\"  Name=\"ProductsName_" + i.ToString() + "\" value='" + base.Base_GetProdutsName(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "'><input type=\"hidden\"  Name=\"ID_" + i.ToString() + "\" value='" + Dts_Table.Tables[0].Rows[i]["ID"].ToString() + "'>" + base.Base_GetProdutsName(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";

                s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";

                int i_LeftNumber = 0, i_ContractAmount = 0;
                try
                {
                    i_LeftNumber = int.Parse(Dts_Contract.Tables[0].Rows[0]["LeftNumber"].ToString()) + int.Parse(Dts_Table.Tables[0].Rows[i]["OutWareAmount"].ToString());
                    i_ContractAmount = int.Parse(Dts_Contract.Tables[0].Rows[0]["ContractAmount"].ToString());
                }
                catch
                { }
                s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + i_ContractAmount.ToString() + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Style=\"display:none\" Name=\"LeftNumber_" + i.ToString() + "\" value=" + i_LeftNumber.ToString() + " >" + i_LeftNumber + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"ChangPrice();this.className=\'detailedViewTextBox\'\" style=\"width:50px;\" Name=\"Number_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["OutWareAmount"].ToString() + "></td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"ChangPrice();this.className=\'detailedViewTextBox\'\" style=\"width:50px;\" Name=\"BNumber_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["KSD_BNumber"].ToString() + " ></td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\"  class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"ChangPrice();this.className='detailedViewTextBox'\" style=\"width:50px;\"  Name=\"Price_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["OutWare_SalesUnitPrice"].ToString() + "></td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\" readonly  Name=\"Money_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["OutWare_SalesTotalNet"].ToString() + " ></td>";

                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\"   Name=\"PlanNumber_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["MaterOrderNo"].ToString() + " ></td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\"   Name=\"RCOrderNo_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["RCOrderNo"].ToString() + " ></td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\"   Name=\"RCMNo_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["RCMNo"].ToString() + " ></td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\"   Name=\"MaterPattern_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["MaterMNo"].ToString() + " ></td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\"   Name=\"IsFollow_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["KSO_IsFollow"].ToString() + " ></td>";
                s_MyTable_Detail += " <td><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\"  Name=\"Remarks_" + i.ToString() + "\"  Text=\"" + Dts_Table.Tables[0].Rows[i]["OutWareRemarks"].ToString() + "\" ></td>";
                s_MyTable_Detail += " </tr>";

                if (this.Tbx_ContractNo.Text != "")
                {
                    this.Xs_ProductsCode.Text += Dts_Table.Tables[0].Rows[i]["ID"].ToString() + ",";
                }
                else
                {
                    this.Xs_ProductsCode.Text += Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString() + ",";
                }
            }
            this.i_Num.Text = Dts_Table.Tables[0].Rows.Count.ToString();
        }
    }

    public string GetCk(string s_OutWareNo)
    {
        string s_Return = "";
        try
        {
            KNet.BLL.KNet_WareHouse_DirectOutList Bll = new KNet.BLL.KNet_WareHouse_DirectOutList();
            DataSet Dts_Table = Bll.GetList(" KWD_ShipNo='" + s_OutWareNo + "'");
            if (Dts_Table.Tables[0].Rows.Count > 0)
            {
                s_Return = DateTime.Parse(Dts_Table.Tables[0].Rows[0]["DirectOutDateTime"].ToString()).ToShortDateString();
            }
        }
        catch (Exception ex)
        {

        }
        return s_Return;
    }

    /// <summary>
    /// 确定开收货单
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button3_Click(object sender, EventArgs e)
    {

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
            string Dostr = "select isnull(sum(LoanAmount),0) as AA from A_Deliveryfa where CustomerValue='" + CustomerValue + "' and  SettlementStatus=1";
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
    /// 获取发货合同单金额
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected decimal GetKNet_Sales_ContractList_DetailsAmount(string ContractNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select isnull(sum(Contract_SalesUnitPrice*ContractAmount),0) as AA from KNet_Sales_ContractList_Details where ContractNo='" + ContractNo + "'";
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
    public bool SetValue(KNet.Model.KNet_Sales_OutWareList molel)
    {
        try
        {
            string OutWareNo = "";
            if (this.Tbx_ID.Text != "")
            {

                OutWareNo = this.Tbx_ID.Text;
            }
            else
            {
                OutWareNo = base.GetNewID("KNet_Sales_OutWareList", 1);
            }
            string OutWareTopic = this.Ddl_Step.SelectedValue;
            string s_ContractNo = Request["Tbx_ContractNo"];
            DateTime OutWareDateTime = DateTime.Now;
            try
            {
                OutWareDateTime = DateTime.Parse(this.OutWareDateTime.Text.Trim());
            }
            catch { }

            string CustomerValue = KNetPage.KHtmlEncode(this.Tbx_CustomerValue.Value.Trim());
            string OutWareOursContact = KNetPage.KHtmlEncode(this.OutWareOursContact.Text.Trim());
            string OutWareSideContact = "";
            OutWareSideContact = this.Tbx_ContentPersonID.Text;
            string ContractToAddress = KNetPage.KHtmlEncode(this.ContractToAddress.Text.Trim());
            string ContractDeliveMethods = KNetPage.KHtmlEncode(this.ContractDeliveMethods.SelectedValue);

            string OutWareStaffBranch = "";
            string OutWareStaffDepart = "";

            string OutWareStaffNo = "";
            string OutWareCheckStaffNo = "";
            string OutWareRemarks = KNetPage.KHtmlEncode(this.Tbx_Remarks.Text.Trim());
            molel.OutWareNo = OutWareNo;
            molel.OutWareTopic = OutWareTopic;
            molel.ContractNo = s_ContractNo;
            molel.OutWareDateTime = OutWareDateTime;

            molel.CustomerValue = CustomerValue;
            molel.OutWareOursContact = OutWareOursContact;
            molel.OutWareSideContact = OutWareSideContact;
            molel.ContractToAddress = ContractToAddress;
            molel.ContractDeliveMethods = ContractDeliveMethods;
            try
            {
                molel.OutWareCheckYN = bool.Parse(this.Tbx_OutWareCheckYN.Text);
            }
            catch
            { }

            molel.KSO_SCustomerValue = this.Tbx_SCustomerValue.Value;
            molel.OutWareStaffBranch = OutWareStaffBranch;
            molel.OutWareStaffDepart = OutWareStaffDepart;
            molel.OutWareStaffNo = OutWareStaffNo;
            molel.OutWareCheckStaffNo = OutWareCheckStaffNo;
            molel.OutWareRemarks = OutWareRemarks;
            molel.DutyPerson = this.Ddl_DutyPerson.SelectedValue;

            molel.KSO_TelPhone = this.Tbx_Phone.Text;
            molel.KSO_PlanOutWareDateTime = DateTime.Parse(this.PlanOutWareDateTime.Text);
            molel.KSO_ContentPersonName = this.Tbx_ContentPerson.Text;
            molel.KSO_WareHouseNo = this.OutWareNo.Text;

            molel.KSO_ShipType = "";
            molel.KSO_MaterNumber = ",";
            molel.KSO_OrderNo = ",";
            molel.KSO_PlanNo = "";
            molel.KSO_Type = this.Ddl_ShipType.SelectedValue;

            if (Ddl_FhDetails.Items.Count > 0)
            {
                molel.KSO_FhDetails = Request["Ddl_FhDetails"];
            }
            else
            {
                molel.KSO_FhDetails = "";
            }
            ArrayList Arr_Details = new ArrayList();

            int i_num = int.Parse(this.i_Num.Text);
            for (int i = 0; i < i_num; i++)
            {
                if (Request["ProductsBarCode_" + i] != null)
                {
                    string s_ProductsBarCode = Request["ProductsBarCode_" + i].ToString();
                    string s_ContractDetailsID = Request["ID_" + i] == null ? "" : Request["ID_" + i].ToString();
                    string s_Number = Request["Number_" + i] == null ? "" : Request["Number_" + i].ToString();
                    string s_BNumber = Request["BNumber_" + i] == "" ? "0" : Request["BNumber_" + i].ToString();
                    string s_Price = Request["Price_" + i] == null ? "" : Request["Price_" + i].ToString();
                    string s_Money = Request["Money_" + i] == null ? "" : Request["Money_" + i].ToString();
                    string s_Battery = Request["Battery_" + i] == null ? "" : Request["Battery_" + i].ToString();
                    string s_Manual = Request["Manual_" + i] == null ? "" : Request["Manual_" + i].ToString();
                    string s_Remarks = Request["Remarks_" + i] == null ? "" : Request["Remarks_" + i].ToString();
                    string s_RCOrderNo = Request["RCOrderNo_" + i] == null ? "" : Request["RCOrderNo_" + i].ToString();
                    string s_RCMNo = Request["RCMNo_" + i] == null ? "" : Request["RCMNo_" + i].ToString();
                    string s_DContractNo = Request["ContractNo_" + i] == null ? "" : Request["ContractNo_" + i].ToString();
                    string s_IsFollow = Request["IsFollow_" + i] == null ? "" : Request["IsFollow_" + i].ToString();
                    string s_PlanNumber = Request["PlanNumber_" + i] == null ? "" : Request["PlanNumber_" + i].ToString();
                    string s_MaterPattern = Request["MaterPattern_" + i] == null ? "" : Request["MaterPattern_" + i].ToString();

                    if ((this.Tbx_Customer.Text != "") && (this.Tbx_ProductsBar.Text != ""))
                    {
                        //未审核订单
                        //先进先出
                        string s_IDAndNumber = GetIDAndNumber( s_ProductsBarCode,this.Tbx_Customer.Text, s_Number,"","");
                        if (s_IDAndNumber.IndexOf("|") <= 0)
                        {
                            return false;
                        }
                        else
                        {
                            string[] s_Details = s_IDAndNumber.Split('|');
                            string[] s_CIDs = s_Details[0].Split(',');
                            string[] s_Numbers = s_Details[1].Split(',');
                            for (int j = 0; j < s_CIDs.Length-1; j++)
                            {
                                KNet.Model.KNet_Sales_OutWareList_Details ModelDetails = new KNet.Model.KNet_Sales_OutWareList_Details();
                                ModelDetails.ProductsBarCode = s_ProductsBarCode;
                                ModelDetails.OutWareAmount = int.Parse(s_Numbers[j]);
                                ModelDetails.OutWare_SalesUnitPrice = decimal.Parse(s_Price);
                                ModelDetails.OutWare_SalesTotalNet = decimal.Parse(s_Money);
                                ModelDetails.OutWareNo = OutWareNo;
                                ModelDetails.OutWareRemarks = s_Remarks;
                                ModelDetails.KSO_Battery = s_Battery;
                                ModelDetails.KSO_Manual = s_Manual;
                                ModelDetails.KSO_ContractDetailsID = s_CIDs[j];
                                ModelDetails.KSD_BNumber = int.Parse(s_BNumber);
                                ModelDetails.RCOrderNo = s_RCOrderNo;
                                ModelDetails.RCMNo = s_RCMNo;
                                ModelDetails.MaterOrderNo = s_PlanNumber;
                                ModelDetails.MaterMNo = s_MaterPattern;
                                ModelDetails.KSO_IsFollow = s_IsFollow;
                                ModelDetails.KSD_ContractNO = s_DContractNo;
                                Arr_Details.Add(ModelDetails);
                            }
                        }
                        
                    }
                    else
                    {
                        KNet.Model.KNet_Sales_OutWareList_Details ModelDetails = new KNet.Model.KNet_Sales_OutWareList_Details();
                        ModelDetails.ProductsBarCode = s_ProductsBarCode;
                        ModelDetails.OutWareAmount = int.Parse(s_Number);
                        ModelDetails.OutWare_SalesUnitPrice = decimal.Parse(s_Price);
                        ModelDetails.OutWare_SalesTotalNet = decimal.Parse(s_Money);
                        ModelDetails.OutWareNo = OutWareNo;
                        ModelDetails.OutWareRemarks = s_Remarks;
                        ModelDetails.KSO_Battery = s_Battery;
                        ModelDetails.KSO_Manual = s_Manual;
                        ModelDetails.KSO_ContractDetailsID = s_ContractDetailsID;
                        ModelDetails.KSD_BNumber = int.Parse(s_BNumber);
                        ModelDetails.RCOrderNo = s_RCOrderNo;
                        ModelDetails.RCMNo = s_RCMNo;
                        ModelDetails.MaterOrderNo = s_PlanNumber;
                        ModelDetails.MaterMNo = s_MaterPattern;
                        ModelDetails.KSO_IsFollow = s_IsFollow;
                        ModelDetails.KSD_ContractNO = s_DContractNo;
                        Arr_Details.Add(ModelDetails);
                    }
                }
            }
            molel.Arr_Details = Arr_Details;
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

    }
    private string GetIDAndNumber(string s_ProductsBarCode, string s_CustomerValue, string s_Number, string s_ID,string s_ReturnNumber)
    {
        try
        {
            //找最老的订单评审
            string s_Sql = "Select Isnull(Sum(v_LeftOutWareTotalNumber),0) Number,c.ID from v_Contract_OutWare_DirectOut_Total  a";
            s_Sql += " join KNEt_Sales_ContractList b on a.V_ContractNo=b.ContractNo join KNEt_Sales_ContractList_Details c on c.ContractNo=b.ContractNo";
            s_Sql += " where ProductsBarCode='" + s_ProductsBarCode + "' ";
            s_Sql += " and CustomerValue='" + s_CustomerValue + "'";
            if (s_ID != "")
            {
                s_Sql += " and c.ID not in('" + s_ID.Replace(",", "','") + "')";
            }
            s_Sql += " Group by b.ContractDateTime,c.ID order by b.ContractDateTime,c.ID ";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                decimal v_LeftOutWareNumber = decimal.Parse(Dtb_Table.Rows[0]["Number"].ToString());
                string s_DID = Dtb_Table.Rows[0]["ID"].ToString();
                if (v_LeftOutWareNumber < decimal.Parse(s_Number))
                {
                    s_ID += s_DID +",";
                    decimal leftNumber = decimal.Parse(s_Number) - v_LeftOutWareNumber;
                    s_ReturnNumber += v_LeftOutWareNumber + ",";
                    if (leftNumber != 0)
                    {
                       return GetIDAndNumber(s_ProductsBarCode, s_CustomerValue, leftNumber.ToString(), s_ID, s_ReturnNumber);
                    }
                    else
                    {
                        return s_ID + "|" + s_ReturnNumber;
                    }
                }
                else
                {
                    s_ID =s_ID+s_DID + ",";
                    s_ReturnNumber =s_ReturnNumber+ s_Number + ",";
                    return s_ID + "|" + s_ReturnNumber;
                }
            }
            else
            {
                return "超过剩余数量";
            }
        }
        catch
        { return "错误"; }

    }
    protected void Btn_SaveOnClick(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        string s_ID = this.Tbx_ID.Text;
        KNet.Model.KNet_Sales_OutWareList Model = new KNet.Model.KNet_Sales_OutWareList();
        KNet.BLL.KNet_Sales_OutWareList BLL = new KNet.BLL.KNet_Sales_OutWareList();
        if (this.SetValue(Model) == false)
        {
            Alert("系统错误！");
            return;
        }
        if (s_ID == "")//新增
        {
            try
            {
                BLL.Add(Model);
                AM.Add_Logs("发货通知单增加" + Model.OutWareNo);
                AlertAndRedirect("新增成功！", "Knet_Sales_Ship_Manage_Manage.aspx");
            }
            catch (Exception ex) { }
        }
        else
        {

            try
            {
                BLL.Update(Model);
                AM.Add_Logs("发货通知单修改" + this.Tbx_ID.Text);
                AlertAndRedirect("修改成功！", "Knet_Sales_Ship_Manage_Manage.aspx");
            }
            catch (Exception ex) { }
        }
    }

    [Ajax.AjaxMethod()]
    public string GetDetails(string s_ContractNo)
    {
        string s_Return = "";
        try
        {
            KNet.BLL.KNet_Sales_ContractList_Details Bll = new KNet.BLL.KNet_Sales_ContractList_Details();
            DataSet Dts_Table = Bll.GetList(" ContractNo='" + s_ContractNo + "'");
            if (Dts_Table.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                {
                    decimal d_HaveAmount = 0;
                    decimal d_Amount = decimal.Parse(Dts_Table.Tables[0].Rows[i]["ContractAmount"].ToString());
                    this.BeginQuery("Select isnull(Sum(OutWareAmount),0) from KNet_Sales_OutWareList_Details where OutWareNo in ( Select OutWareNo from KNet_Sales_OutWareList Where ContractNo='" + s_ContractNo + "' ) and ProductsBarCode='" + Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "'");
                    this.QueryForDataTable();
                    if (this.Dtb_Result.Rows.Count > 0)
                    {

                        d_HaveAmount = decimal.Parse(this.Dtb_Result.Rows[0][0].ToString());
                    }
                    decimal d_LAmount = d_Amount - d_HaveAmount;
                    decimal d_Price = decimal.Parse(Dts_Table.Tables[0].Rows[i]["Contract_SalesUnitPrice"].ToString());
                    decimal d_TotalNet = d_LAmount * d_Price;

                    s_Return += Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "," + base.Base_GetProdutsName(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + ",";
                    s_Return += base.Base_GetProductsEdition(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "," + d_LAmount.ToString() + ",";
                    s_Return += d_Price.ToString() + "," + d_TotalNet.ToString() + "," + Dts_Table.Tables[0].Rows[i]["ContractRemarks"].ToString() + "," + Dts_Table.Tables[0].Rows[i]["KSD_OrderNumber"].ToString() + "," + Dts_Table.Tables[0].Rows[i]["KSD_MaterNumber"].ToString() + "|";
                }
            }
        }
        catch (Exception ex)
        {
            s_Return = "";
        }
        return s_Return;
    }
    //电池下拉框
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
    //上次发货通知单
    [Ajax.AjaxMethod()]
    public string GetLastOutWare(string s_Customer)
    {
        string s_Return = "";
        try
        {
            KNet.BLL.KNet_Sales_OutWareList Bll = new KNet.BLL.KNet_Sales_OutWareList();
            KNet.Model.KNet_Sales_OutWareList Model = Bll.GetLaseModel(s_Customer);
            if (Model != null)
            {
                string s_PersonID = Model.OutWareSideContact;
                string s_PersonName = Model.OutWareSideContact == "" ? Model.KSO_ContentPersonName : base.Base_GetLinkManValue(Model.OutWareSideContact, "XOL_Name");
                string s_Adress = Model.OutWareSideContact == "" ? Model.ContractToAddress : base.Base_GetLinkManValue(Model.OutWareSideContact, "XOL_Address");
                string s_Tel = Model.OutWareSideContact == "" ? Model.KSO_TelPhone : base.Base_GetLinkManValue(Model.OutWareSideContact, "XOL_Phone");
                s_Return = s_PersonID + "," + s_PersonName + "," + s_Tel + "," + s_Adress + "," + Model.DutyPerson + "," + Model.ContractDeliveMethods + "," + Model.KSO_ShipType + "," + Model.KSO_MaterNumber + "," + Model.KSO_OrderNo + "," + Model.KSO_PlanNo;
            }
            else
            {
                s_Return = "";
            }
        }
        catch (Exception ex)
        {
            s_Return = "";
        }
        return s_Return;
    }
    //联系人
    [Ajax.AjaxMethod()]
    public string GetLinkMan(string s_LinManID)
    {
        string s_Return = "";
        try
        {
            KNet.BLL.XS_Compy_LinkMan Bll = new KNet.BLL.XS_Compy_LinkMan();
            KNet.Model.XS_Compy_LinkMan Model = Bll.GetModel(s_LinManID);

            if (Model != null)
            {
                KNet.BLL.KNet_Sales_ClientList Bll_Client = new KNet.BLL.KNet_Sales_ClientList();
                KNet.Model.KNet_Sales_ClientList Model_Client = Bll_Client.GetModelB(Model.XOL_Compy);
                s_Return = Model.XOL_ID + "," + Model.XOL_Name + "," + Model.XOL_Phone + "," + Model.XOL_Address + ",";
                if (Model_Client != null)
                {
                    s_Return += Model_Client.KSC_DutyPerson;
                }
            }
            else
            {
                s_Return = "";
            }
        }
        catch (Exception ex)
        {
            s_Return = "";
        }
        return s_Return;
    }


    //联系人
    [Ajax.AjaxMethod()]
    public string GetFHDetails(string s_LinManID)
    {
        string s_Return = "";
        try
        {

            KNet.BLL.Xs_Customer_FhInfo Bll = new KNet.BLL.Xs_Customer_FhInfo();
            DataSet Dts_Table = Bll.GetList("  XCF_CustomerValue='" + s_LinManID + "'");

            for (int i = 0; i < Dts_Table.Tables[0].Rows.Count;i++ )
            {
                s_Return += Dts_Table.Tables[0].Rows[i]["XCF_ID"].ToString() + "#" + Dts_Table.Tables[0].Rows[i]["XCF_Details"].ToString() + "|";
            }
        }
        catch (Exception ex)
        {
            s_Return = "";
        }
        return s_Return;
    }
}
