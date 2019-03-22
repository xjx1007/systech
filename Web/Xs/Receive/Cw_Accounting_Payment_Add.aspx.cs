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


public partial class Cw_Accounting_Payment_Add : BasePage
{
    public string s_MyTable_Detail = "",s_KSOType="";
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(Cw_Accounting_Payment_Add));
        if (!Page.IsPostBack)
        {
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string s_OutWareNo = Request.QueryString["OutWareNo"] == null ? "" : Request.QueryString["OutWareNo"].ToString();
            string s_ContractNo = Request.QueryString["ContractNo"] == null ? "" : Request.QueryString["ContractNo"].ToString();
            this.Tbx_ContractNo.Text = s_ContractNo;
            this.Tbx_OutWareNo.Text = s_OutWareNo;
            this.Tbx_ID.Text = s_ID;
            base.Base_DropBasicCodeBind(this.Ddl_KP, "107");
            base.Base_DropDutyPerson(this.Ddl_DutyPerson);
            this.Ddl_KP.SelectedValue = "101";
            base.Base_DropBasicCodeBind(this.Ddl_KpType, "203");
            this.Tbx_YTime.Text = DateTime.Now.ToShortDateString();
            base.Base_DropBasicCodeBind(this.Order, "206",false);
            if (s_OutWareNo != "")
            {
                KNet.BLL.KNet_Sales_OutWareList Bll_OutWare = new KNet.BLL.KNet_Sales_OutWareList();
                KNet.Model.KNet_Sales_OutWareList Model_OutWare = Bll_OutWare.GetModelB(s_OutWareNo);
                KNet.BLL.KNet_Sales_ContractList Bll_ContractList = new KNet.BLL.KNet_Sales_ContractList();
                this.Tbx_KPOType.Text = Model_OutWare.KSO_Type;
                base.Base_GetCustomerPayMent("", s_OutWareNo);
                if(Model_OutWare!=null)
                {
                    //发货通知
                    this.Tbx_CustomerValue.Text = Model_OutWare.CustomerValue;
                    this.Tbx_CustomerName.Text = base.Base_GetCustomerName(Model_OutWare.CustomerValue);
                    //发货通知
                    this.Tbx_KCustomerValue.Text = Model_OutWare.CustomerValue;
                    this.Tbx_KCustomerName.Text = base.Base_GetCustomerName(Model_OutWare.CustomerValue);
                    this.Ddl_DutyPerson.SelectedValue = Model_OutWare.DutyPerson;
                    string Sql = " Select a.*,b.KWD_CwCode,b.KWD_Custmoer,v_leftNumber,v_leftNumber*a.KWD_SalesUnitPrice as Money,b.KWD_ShipNo,b.DirectOutDateTime,b.DirectOutStaffBranch,b.HouseNo,b.DirectOutStaffNo ";
                    Sql += " From KNet_WareHouse_DirectOutList_Details a join KNet_WareHouse_DirectOutList b on a.DirectOutNo=b.DirectOutNo";
                    Sql += " join KNet_Sales_OutWareList c on c.OutWareNo=b.KWD_ShipNo ";
                    Sql += " join v_Receive_Number e on e.v_DetailsID=a.ID ";
                    Sql += " join KNet_Sys_Products d on d.ProductsBarCode= a.ProductsBarCode";
                    Sql += "  Where isNull(KWD_Type,'101')='101' and e.v_State<>'2' and d.ProductsType<>'M130704050932527'  ";
                    string SqlWhere = " ";//and OutWareCheckYN=1
                    if (this.Tbx_CustomerValue.Text != "")
                    {
                        SqlWhere = SqlWhere + " and c.OutWareNo='" + s_OutWareNo + "' ";
                    }
                    SqlWhere = SqlWhere + " order by b.DirectOutDateTime desc";
                    this.BeginQuery(Sql + SqlWhere);
                    this.QueryForDataTable();
                    DataSet Dts_table = this.Dts_Result;
                    decimal d_TotalMoney = 0;
                    if (Dts_table.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < Dts_table.Tables[0].Rows.Count; i++)
                        {

                            s_MyTable_Detail += " <tr> ";
                            s_MyTable_Detail += " <td  class=\"ListHeadDetails\"><A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a></td>";

                            KNet.BLL.KNet_WareHouse_DirectOutList_Details bll_DircetOutDetails = new KNet.BLL.KNet_WareHouse_DirectOutList_Details();
                            KNet.Model.KNet_WareHouse_DirectOutList_Details Model_DircetOutDetails = bll_DircetOutDetails.GetModel(Dts_table.Tables[0].Rows[i]["ID"].ToString());
                            if (Model_DircetOutDetails != null)
                            {
                                KNet.BLL.KNet_WareHouse_DirectOutList bll_DircetOut = new KNet.BLL.KNet_WareHouse_DirectOutList();
                                KNet.Model.KNet_WareHouse_DirectOutList Model_DircetOut = bll_DircetOut.GetModelB(Model_DircetOutDetails.DirectOutNo);
                                if (Model_DircetOut.KWD_CwCode != "")
                                {
                                    s_MyTable_Detail += " <td  class=\"ListHeadDetails\"><input type=\"hidden\"  style=\"width:0px;\" Name=\"ID_" + i.ToString() + "\" Value=\"" + Model_DircetOutDetails.ID + "\">" + Model_DircetOut.DirectOutNo + "</td>";
                                }
                                else
                                {
                                    s_MyTable_Detail += " <td  class=\"ListHeadDetails\">&nbsp;</td>";
                                }
                                s_MyTable_Detail += " <td  class=\"ListHeadDetails\"><input type=\"hidden\" ID=\"DirectOutTime_" + i.ToString() + "'\"   Name=\"DirectOutTime_" + i.ToString() + "\" value='" + DateTime.Parse(Model_DircetOut.KWD_CWOutTime.ToString()).ToShortDateString() + "'>" + DateTime.Parse(Model_DircetOut.KWD_CWOutTime.ToString()).ToShortDateString() + "</td>";
                            
                            }
                            s_MyTable_Detail += " <td  class=\"ListHeadDetails\"><input type=\"hidden\" ID=\"ProductsBarCode_" + i.ToString() + "'\"   Name=\"ProductsBarCode_" + i.ToString() + "\" value='" + Model_DircetOutDetails.ProductsBarCode + "'>" + base.Base_GetProductsEdition_Link(Model_DircetOutDetails.ProductsBarCode) + "</td>";
                            s_MyTable_Detail += " <td  class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"ChangePrice();this.className=\'detailedViewTextBox\'\" style=\"width:130px;\" Name=\"Number_" + i.ToString() + "\" value=" + Dts_table.Tables[0].Rows[i]["DirectOutAmount"].ToString() + "></td>";
                            s_MyTable_Detail += " <td  class=\"ListHeadDetails\"><input type=\"hidden\" ID=\"OldPrice_" + i.ToString() + "\"   Name=\"OldPrice_" + i.ToString() + "\" value=" + Dts_table.Tables[0].Rows[i]["KWD_SalesUnitPrice"].ToString() + "><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"ChangePrice();this.className=\'detailedViewTextBox\'\" style=\"width:130px;\" Name=\"Price_" + i.ToString() + "\" value=" + Dts_table.Tables[0].Rows[i]["KWD_SalesUnitPrice"].ToString() + "> </td>";
                            s_MyTable_Detail += " <td  class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:130px;\" Name=\"Money_" + i.ToString() + "\" value=" + Dts_table.Tables[0].Rows[i]["KWD_SalesTotalNet"].ToString() + "> </td>";
                            s_MyTable_Detail += " <td  class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:130px;\" Name=\"Remarks_" + i.ToString() + "\" > </td>";

                            s_MyTable_Detail += " </tr> ";
                            try
                            {
                                d_TotalMoney += decimal.Parse(Dts_table.Tables[0].Rows[i]["KWD_SalesTotalNet"].ToString());
                            }
                            catch { }
                        }
                        this.Tbx_Num.Text = Dts_table.Tables[0].Rows.Count.ToString();
                        this.Tbx_Money.Text = d_TotalMoney.ToString();
                    }

                }
            }
            if (this.Tbx_ID.Text != "")
            {
                ShowInfo(this.Tbx_ID.Text);
            }
            else
            {
                this.Tbx_Code.Text = GetCwCode(0);
            }
        }
    }

    private void ShowInfo(string s_ID)
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.BLL.Cw_Accounting_Payment bll = new KNet.BLL.Cw_Accounting_Payment();
        KNet.Model.Cw_Accounting_Payment Model = bll.GetModel(s_ID);
        try
        {
            if (Model != null)
            {
                if (AM.KNet_StaffName != "薛建新")
                {

                    if (Model.CAP_SKState == 2)
                    {
                        AlertAndGoBack("该单已收款！");
                    }
                    if (Model.CAP_KpState == 2)
                    {
                        AlertAndGoBack("该单已开票！");
                    }
                }
                this.Tbx_Code.Text = Model.CAP_Code;
                if (Model.CAP_KCustomerValue != Model.CAP_CustomerValue)
                {
                    this.Tbx_KCustomerName.Text = base.Base_GetCustomerName(Model.CAP_CustomerValue);
                    this.Tbx_KCustomerValue.Text = Model.CAP_CustomerValue;
                    this.Tbx_CustomerName.Text = base.Base_GetCustomerName(Model.CAP_KCustomerValue);
                    this.Tbx_CustomerValue.Text = Model.CAP_KCustomerValue;
                }
                else
                {
                    this.Tbx_KCustomerName.Text = base.Base_GetCustomerName(Model.CAP_CustomerValue);
                    this.Tbx_KCustomerValue.Text = Model.CAP_CustomerValue;
                    this.Tbx_CustomerName.Text = base.Base_GetCustomerName(Model.CAP_CustomerValue);
                    this.Tbx_CustomerValue.Text = Model.CAP_CustomerValue;
                }
                this.Tbx_YTime.Text = DateTime.Parse(Model.CAP_STime.ToString()).ToShortDateString();
                this.Order.SelectedValue = Model.CAP_Order.ToString();  
                this.Ddl_KP.SelectedValue = Model.CAP_IsFP.ToString();
                this.Ddl_KpType.SelectedValue = Model.CAP_FpType;
                this.Ddl_DutyPerson.SelectedValue = Model.CAP_DutyPerson;
                this.Tbx_Money.Text = Model.CAP_ReceiveMoney.ToString();
                this.Tbx_Remarks.Text = Model.CAP_Details;
                KNet.BLL.Cw_Accounting_PaymentDetails bll_Details = new KNet.BLL.Cw_Accounting_PaymentDetails();
                DataSet Dts_table = bll_Details.GetList(" CAPD_CARID='"+Model.CAP_ID+"' ");
                if (Dts_table.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < Dts_table.Tables[0].Rows.Count; i++)
                    {

                        s_MyTable_Detail += " <tr> ";
                        s_MyTable_Detail += " <td  class=\"ListHeadDetails\"><A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a></td>";

                        KNet.BLL.KNet_WareHouse_DirectOutList_Details bll_DircetOutDetails = new KNet.BLL.KNet_WareHouse_DirectOutList_Details();
                        KNet.Model.KNet_WareHouse_DirectOutList_Details Model_DircetOutDetails = bll_DircetOutDetails.GetModel(Dts_table.Tables[0].Rows[i]["CAPD_FID"].ToString());
                        if (Model_DircetOutDetails != null)
                        {
                            KNet.BLL.KNet_WareHouse_DirectOutList bll_DircetOut = new KNet.BLL.KNet_WareHouse_DirectOutList();
                            KNet.Model.KNet_WareHouse_DirectOutList Model_DircetOut = bll_DircetOut.GetModelB(Model_DircetOutDetails.DirectOutNo);
                            if (Model_DircetOut.KWD_CwCode != "")
                            {
                                s_MyTable_Detail += " <td  class=\"ListHeadDetails\"><input type=\"text\" Class=\"hidden\"  style=\"width:0px;\" Name=\"ID_" + i.ToString() + "\" Value=\"" + Model_DircetOutDetails.ID + "\">" + Model_DircetOut.DirectOutNo + "</td>";
                            }
                            else
                            {
                                s_MyTable_Detail += " <td  class=\"ListHeadDetails\">&nbsp;</td>";
                            }
                            s_MyTable_Detail += " <td  class=\"ListHeadDetails\"><input type=\"hidden\" ID=\"DirectOutTime_" + i.ToString() + "'\"   Name=\"DirectOutTime_" + i.ToString() + "\" value='" + DateTime.Parse(Model_DircetOut.KWD_CWOutTime.ToString()).ToShortDateString() + "'>" + DateTime.Parse(Model_DircetOut.KWD_CWOutTime.ToString()).ToShortDateString() + "</td>";
                        }
                        s_MyTable_Detail += " <td  class=\"ListHeadDetails\"><input type=\"hidden\" ID=\"ProductsBarCode_" + i.ToString() + "\"   Name=\"ProductsBarCode_" + i.ToString() + "\" value='" + Model_DircetOutDetails.ProductsBarCode + "'>" + base.Base_GetProductsEdition_Link(Model_DircetOutDetails.ProductsBarCode) + "</td>";
                        s_MyTable_Detail += " <td  class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"ChangePrice();this.className=\'detailedViewTextBox\'\" style=\"width:170px;\" Name=\"Number_" + i.ToString() + "\" value=" + Dts_table.Tables[0].Rows[i]["CAPD_Number"].ToString() + "></td>";
                        s_MyTable_Detail += " <td  class=\"ListHeadDetails\"><input type=\"hidden\" ID=\"OldPrice_" + i.ToString() + "\"   Name=\"OldPrice_" + i.ToString() + "\" value=" + Model_DircetOutDetails.KWD_SalesUnitPrice.ToString() + "><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"ChangePrice();this.className=\'detailedViewTextBox\'\" style=\"width:170px;\" Name=\"Price_" + i.ToString() + "\" value=" + Dts_table.Tables[0].Rows[i]["CAPD_Price"].ToString() + "> </td>";
                        s_MyTable_Detail += " <td  class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:170px;\" Name=\"Money_" + i.ToString() + "\" value=" + Dts_table.Tables[0].Rows[i]["CAPD_Money"].ToString() + "> </td>";
                        s_MyTable_Detail += " <td  class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:170px;\" Name=\"Remarks_" + i.ToString() + "\" > </td>";

                        s_MyTable_Detail += " </tr> ";
                    }
                    this.Tbx_Num.Text = Dts_table.Tables[0].Rows.Count.ToString();
                }
            }
        }
        catch
        {}

    }
    private bool SetValue(KNet.Model.Cw_Accounting_Payment model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text != "")
            {
                model.CAP_ID = this.Tbx_ID.Text;
            }
            else
            {

                model.CAP_ID = GetMainID();
            }
            model.CAP_Code=this.Tbx_Code.Text;
            model.CAP_DutyPerson = this.Ddl_DutyPerson.SelectedValue;
            model.CAP_IsFP = this.Ddl_KP.SelectedValue;
            model.CAP_ReceiveMoney = decimal.Parse(this.Tbx_Money.Text);
            model.CAP_FpType = this.Ddl_KpType.SelectedValue;
            if (this.Tbx_CustomerValue.Text != this.Tbx_KCustomerValue.Text)
            {

                model.CAP_CustomerValue = this.Tbx_KCustomerValue.Text;
                model.CAP_KCustomerValue = this.Tbx_CustomerValue.Text;
            }
            else
            {

                model.CAP_CustomerValue = this.Tbx_CustomerValue.Text;
                model.CAP_KCustomerValue = this.Tbx_CustomerValue.Text;
            }
            try
            {
                model.CAP_STime = DateTime.Parse(this.Tbx_YTime.Text);
            }
            catch { }
            model.CAP_Type = 1;
            model.CAP_Order = int.Parse(this.Order.SelectedValue);
            model.CAP_Details = this.Tbx_Remarks.Text;
            model.CAP_Creator = AM.KNet_StaffNo;
            model.CAP_CTime = DateTime.Now;
            model.CAP_MTime = DateTime.Now;
            model.CAP_Mender = AM.KNet_StaffNo;

       //     model.CAP_ContractNo = this.Tbx_ContractNo.Text;
     //       model.CAP_OutWareNO = this.Tbx_OutWareNo.Text;
            ArrayList arr_Details = new ArrayList();
            ArrayList arr_DirectOut = new ArrayList();
            
            KNet.BLL.KNet_WareHouse_DirectOutList_Details bll_DirectOutDetails = new KNet.BLL.KNet_WareHouse_DirectOutList_Details();
            KNet.BLL.KNet_WareHouse_DirectOutList bll_DirectOut = new KNet.BLL.KNet_WareHouse_DirectOutList();
            int i_Num= int.Parse(this.Tbx_Num.Text);
            for (int i = 0; i < i_Num; i++)
            {

                ArrayList arr_DirectOutDetails = new ArrayList();
                ArrayList arr_DirectOutDetails1 = new ArrayList();
                string s_DetailsID = Request["ID_" + i + ""] == null ? "" : Request["ID_" + i + ""].ToString();
                string s_Number = Request["Number_" + i + ""] == null ? "" : Request["Number_" + i + ""].ToString();
                string s_OldDateTime = Request["DirectOutTime_" + i + ""] == null ? "" : Request["DirectOutTime_" + i + ""].ToString();
                string s_Price = Request["Price_" + i + ""] == null ? "" : Request["Price_" + i + ""].ToString();
                string s_OldPrice = Request["OldPrice_" + i + ""] == null ? "" : Request["OldPrice_" + i + ""].ToString();
                string s_Money = Request["Money_" + i + ""] == null ? "" : Request["Money_" + i + ""].ToString();
                string s_Remarks = Request["Remarks_" + i + ""] == null ? "" : Request["Remarks_" + i + ""].ToString();
                if (s_DetailsID != "")
                {
                    DateTime D_NowTime = DateTime.Parse(this.Tbx_YTime.Text);
                    DateTime D_OldTime = DateTime.Parse(s_OldDateTime);
                    KNet.Model.Cw_Accounting_PaymentDetails Model_Details = new KNet.Model.Cw_Accounting_PaymentDetails();
                    Model_Details.CAPD_ID = GetMainID(i);
                    Model_Details.CAPD_CARID = model.CAP_ID;
                    Model_Details.CAPD_FID = s_DetailsID;
                    Model_Details.CAPD_Number = decimal.Parse(s_Number);

                    if ((D_OldTime.Year == D_NowTime.Year) && (D_NowTime.Month == D_OldTime.Month))
                    {
                        Model_Details.CAPD_Price = decimal.Parse(s_OldPrice);
                        Model_Details.CAPD_Money = decimal.Parse(s_Number) * decimal.Parse(s_OldPrice);
                    }
                    else
                    {
                        Model_Details.CAPD_Price = decimal.Parse(s_Price);
                        Model_Details.CAPD_Money = decimal.Parse(s_Number) * decimal.Parse(s_Price);
                    }
                    Model_Details.CAPD_Details = s_Remarks;
                    arr_Details.Add(Model_Details);
                    //开票单位和单位不同 开具冲红
                    //单价不同。
                    //如果跨月就冲帐。如果是本月就修改
                    if (((D_OldTime.Year == D_NowTime.Year) && (D_NowTime.Month == D_OldTime.Month)) && (this.Tbx_KPOType.Text != "1") && (Chk_Red.Checked==false))
                    {
                        if ((this.Tbx_CustomerValue.Text != this.Tbx_KCustomerValue.Text) || (s_Price != s_OldPrice) )
                        {
                            KNet.Model.KNet_WareHouse_DirectOutList_Details Model_DirectOutDetails = bll_DirectOutDetails.GetModel(s_DetailsID);
                            KNet.Model.KNet_WareHouse_DirectOutList Model_DirectOut = bll_DirectOut.GetModelB(Model_DirectOutDetails.DirectOutNo);
                            Model_DirectOutDetails.KWD_SalesUnitPrice = decimal.Parse(s_Price);
                            Model_DirectOutDetails.KWD_SalesTotalNet = decimal.Parse(s_Price) * Model_DirectOutDetails.DirectOutAmount;
                            Model_DirectOutDetails.IsChang = 0;
                            Model_DirectOut.isChange = 0;
                            Model_DirectOut.KWD_Custmoer = this.Tbx_KCustomerValue.Text;
                            arr_DirectOutDetails.Add(Model_DirectOutDetails);
                            Model_DirectOut.Arr_Details = arr_DirectOutDetails;
                            //明细的details
                            arr_DirectOut.Add(Model_DirectOut);
                        }
                    }
                    else
                    {
                        if ((this.Tbx_CustomerValue.Text != this.Tbx_KCustomerValue.Text) || (s_Price != s_OldPrice) || (this.Tbx_KPOType.Text == "1") || ((Chk_Red.Checked)))
                        {
                            KNet.Model.KNet_WareHouse_DirectOutList_Details Model_DirectOutDetails = bll_DirectOutDetails.GetModel(s_DetailsID);
                            KNet.Model.KNet_WareHouse_DirectOutList Model_DirectOut = bll_DirectOut.GetModelB(Model_DirectOutDetails.DirectOutNo);
                            string s_DirectOutNo = base.GetNewID("KNet_WareHouse_DirectOutList", 1);
                            Model_DirectOut.DirectOutNo = "<font color=red >" + s_DirectOutNo + "</font>";
                            Model_DirectOut.DirectOutTopic = model.CAP_ID;
                            Model_DirectOut.DirectOutDateTime = DateTime.Parse(this.Tbx_YTime.Text);
                            Model_DirectOut.KWD_CWOutTime = DateTime.Parse(this.Tbx_YTime.Text);
                            Model_DirectOut.DirectOutRemarks = "冲红字";
                            Model_DirectOut.KWD_Custmoer = this.Tbx_CustomerValue.Text;

                            Model_DirectOutDetails.ID = "C" + GetMainID(i);
                            Model_DirectOutDetails.DirectOutNo = "<font color=red>" + s_DirectOutNo + "</font>";
                            Model_DirectOutDetails.DirectOutAmount = -1 * int.Parse(base.FormatNumber1(s_Number,0));
                            Model_DirectOutDetails.KWD_BNumber = -1 * Model_DirectOutDetails.KWD_BNumber;
                            Model_DirectOutDetails.DirectOutTotalNet = -1 * Model_DirectOutDetails.DirectOutTotalNet;
                            Model_DirectOutDetails.KWD_SalesUnitPrice = decimal.Parse(s_OldPrice);
                            Model_DirectOutDetails.KWD_SalesTotalNet = -1 * decimal.Parse(s_OldPrice) * decimal.Parse(s_Number);
                            Model_DirectOutDetails.IsChang = 1;
                            Model_DirectOut.isChange = 1;
                            arr_DirectOutDetails.Add(Model_DirectOutDetails);
                            Model_DirectOut.Arr_Details = arr_DirectOutDetails;
                            arr_DirectOut.Add(Model_DirectOut);
                            //

                            KNet.Model.Cw_Accounting_PaymentDetails Model_PaymentDetails = new KNet.Model.Cw_Accounting_PaymentDetails();
                            Model_PaymentDetails.CAPD_ID = GetMainID(i+100);
                            Model_PaymentDetails.CAPD_CARID = model.CAP_ID;
                            Model_PaymentDetails.CAPD_FID = Model_DirectOutDetails.ID;
                            Model_PaymentDetails.CAPD_Number = Model_DirectOutDetails.DirectOutAmount;
                            Model_PaymentDetails.CAPD_Price = Model_DirectOutDetails.KWD_SalesUnitPrice;
                            Model_PaymentDetails.CAPD_Money = Model_DirectOutDetails.KWD_SalesTotalNet;
                            Model_PaymentDetails.CAPD_Details = Model_DirectOut.DirectOutRemarks;
                            arr_Details.Add(Model_PaymentDetails);
                         
                            KNet.Model.KNet_WareHouse_DirectOutList_Details Model_DirectOutDetails1 = bll_DirectOutDetails.GetModel(s_DetailsID);
                            KNet.Model.KNet_WareHouse_DirectOutList Model_DirectOut1 = bll_DirectOut.GetModelB(Model_DirectOutDetails1.DirectOutNo);
                            s_DirectOutNo = base.GetNewID("KNet_WareHouse_DirectOutList", 1);
                            Model_DirectOut1.DirectOutNo = "<font color=blue>" + s_DirectOutNo + "</font>";
                            Model_DirectOut1.DirectOutTopic = model.CAP_ID;
                            Model_DirectOut1.KWD_Custmoer = this.Tbx_KCustomerValue.Text;
                            Model_DirectOut1.DirectOutDateTime = DateTime.Parse(this.Tbx_YTime.Text);
                            if(this.Tbx_KPOType.Text=="1")
                            {
                                Model_DirectOut1.KWD_Type = "DB";
                            }
                            Model_DirectOut1.KWD_CWOutTime = DateTime.Parse(this.Tbx_YTime.Text);
                            Model_DirectOut1.DirectOutRemarks = "调整";

                            Model_DirectOutDetails1.ID = "T" + GetMainID(i+200);
                            Model_DirectOutDetails1.DirectOutNo = "<font color=blue>" + s_DirectOutNo + "</font>";
                            Model_DirectOutDetails1.DirectOutAmount = int.Parse(base.FormatNumber1(s_Number, 0));
                            Model_DirectOutDetails1.KWD_SalesUnitPrice = decimal.Parse(s_Price);
                            Model_DirectOutDetails1.KWD_SalesTotalNet = decimal.Parse(s_Money);
                            Model_DirectOutDetails1.IsChang = 1;
                            Model_DirectOut1.isChange = 1;
                            arr_DirectOutDetails1.Add(Model_DirectOutDetails1);
                            Model_DirectOut1.Arr_Details = arr_DirectOutDetails1;
                            arr_DirectOut.Add(Model_DirectOut1);
                  
                            
                            KNet.Model.Cw_Accounting_PaymentDetails Model_PaymentDetails1 = new KNet.Model.Cw_Accounting_PaymentDetails();
                            Model_PaymentDetails1.CAPD_ID = GetMainID(i + 300);
                            Model_PaymentDetails1.CAPD_CARID = model.CAP_ID;
                            Model_PaymentDetails1.CAPD_FID = Model_DirectOutDetails1.ID;
                            Model_PaymentDetails1.CAPD_Number = Model_DirectOutDetails1.DirectOutAmount;
                            Model_PaymentDetails1.CAPD_Price = Model_DirectOutDetails1.KWD_SalesUnitPrice;
                            Model_PaymentDetails1.CAPD_Money = Model_DirectOutDetails1.KWD_SalesTotalNet;
                            Model_PaymentDetails1.CAPD_Details = Model_DirectOut1.DirectOutRemarks;
                            arr_Details.Add(Model_PaymentDetails1);
                        }
                    }

                }
            }
            model.arr_DirectOut = arr_DirectOut;
            model.arr_Details = arr_Details;
            return true;
        }
        catch(Exception ex)
        {
            return false;
        }
       
    }
    protected void Btn_SaveOnClick(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.Model.Cw_Accounting_Payment model = new KNet.Model.Cw_Accounting_Payment();
        KNet.BLL.Cw_Accounting_Payment bll = new KNet.BLL.Cw_Accounting_Payment();

        if (this.SetValue(model) == false)
        {
            Alert("系统错误！");
            return;
        }
        if ((this.Tbx_ID.Text != ""))//修改
        {
            try
            {
                bll.Update(model);
                AM.Add_Logs("应收款计划修改" );
                AlertAndRedirect("修改成功！", "Cw_Accounting_Payment_List.aspx");
            }
            catch { }
        }
        else
        {
            try
            {
                bll.Add(model);
                if (this.Ddl_KP.SelectedValue == "101")
                {
                    base.Base_SendMessage(model.CAP_DutyPerson, KNetPage.KHtmlEncode("有 开票通知 <a href='Web/Receive/Cw_Accounting_Payment_View.aspx?ID=" + model.CAP_ID + "' target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.CAP_Code + "</a> 需要您审批，敬请关注！"));
               
                }
                 AM.Add_Logs("应收款计划增加");
                AlertAndRedirect("新增成功！", "Cw_Accounting_Payment_List.aspx");
            }
            catch(Exception ex) { }
        }
    }
    public string GetCwCode(int i_Num)
    {
        string s_Code = "";
        try
        {
            KNet.BLL.KNet_WareHouse_DirectOutList BLL = new KNet.BLL.KNet_WareHouse_DirectOutList();
            this.BeginQuery("Select Max(isNUll(CAP_Code,'')) from Cw_Accounting_Payment Where CAP_Type='1' and year(CAP_CTime)='" + DateTime.Now.Year.ToString() + "'  and Month(CAP_CTime)='" + DateTime.Now.Month.ToString() + "'");
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                if (Dtb_Table.Rows[0][0].ToString() != "")
                {
                    s_Code = Dtb_Table.Rows[0][0].ToString().Substring(0, 6) + "-" + Convert.ToString(int.Parse("1" + Dtb_Table.Rows[0][0].ToString().Substring(7, 3)) + 1 + i_Num).Substring(1, 3);
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
    [Ajax.AjaxMethod()]
    public string GetDetails(string s_ID)
    {
        string s_Return = "",s_Sql="";
        try
        {
            s_Sql = " Select a.*,b.KWD_ShipNo,e.v_LeftNumber,b.DirectOutDateTime,b.DirectOutNo from KNet_WareHouse_DirectOutList_Details a join KNet_WareHouse_DirectOutList b on a.DirectOutNo=b.DirectOutNo  join v_Receive_Number e on e.v_DetailsID=a.ID  ";
            s_Sql += " where a.ID in ('" + s_ID.Replace(",", "','") + "')  ";
            this.BeginQuery(s_Sql);
            this.QueryForDataSet();
            DataSet ds = this.Dts_Result;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                s_Return += ds.Tables[0].Rows[i]["ID"].ToString() + "," + ds.Tables[0].Rows[i]["DirectOutNo"].ToString() + "," + ds.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "," + base.Base_GetProductsEdition(ds.Tables[0].Rows[i]["ProductsBarCode"].ToString());
                s_Return += "," + ds.Tables[0].Rows[i]["v_LeftNumber"].ToString() + "," + ds.Tables[0].Rows[i]["KWD_SalesUnitPrice"].ToString() + "," + DateTime.Parse(ds.Tables[0].Rows[i]["DirectOutDateTime"].ToString()).ToShortDateString() + "|";
            }
            return s_Return;
        }
        catch
        {
            return s_Return;
        }
    }
}
