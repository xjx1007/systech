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


public partial class Cw_Account_Bill_Add : BasePage
{
    public string s_MyTable_Detail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(Cw_Account_Bill_Add));
        if (!Page.IsPostBack)
        {
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string s_ReceiveID = Request.QueryString["ReceiveID"] == null ? "" : Request.QueryString["ReceiveID"].ToString();
            this.Tbx_FID.Text = s_ReceiveID;
            base.Base_DropDutyPerson(this.Ddl_DutyPerson);
            base.Base_DropBasicCodeBind(this.Ddl_BillType, "203");
            this.Tbx_STime.Text = DateTime.Now.ToShortDateString();
            base.Base_DropBasicCodeBind(this.Ddl_PayMent, "104");
            if (s_ReceiveID != "")
            {
                KNet.BLL.Cw_Accounting_Payment Bll = new KNet.BLL.Cw_Accounting_Payment();
                KNet.Model.Cw_Accounting_Payment Model = Bll.GetModel(s_ReceiveID);
                if (Model.CAP_KpState == 2)
                {
                    AlertAndClose("该应收单已收！");
                }
                this.Tbx_CustomerValue.Value = Model.CAP_CustomerValue;
                this.Tbx_CustomerName.Text = base.Base_GetCustomerName(Model.CAP_CustomerValue);
                this.Ddl_BillType.SelectedValue = Model.CAP_FpType;
                this.Ddl_DutyPerson.SelectedValue = Model.CAP_DutyPerson;
                KNet.BLL.Cw_Accounting_PaymentDetails Bll_Details = new KNet.BLL.Cw_Accounting_PaymentDetails();
                this.Tbx_Money.Text = Model.cap_Leftmoney.ToString();

                this.BeginQuery("Select distinct top 5  KWD_ShipNo from KNet_WareHouse_DirectOutlist a join KNet_WareHouse_DirectOutlist_Details b on a.DirectOutNo=b.DirectOutNo join Cw_Accounting_PaymentDetails c on CAPD_FID=b.ID where CAPD_CARID='" + s_ReceiveID + "' order by KWD_ShipNo desc ");
                this.QueryForDataTable();
                string s_PayMent="",s_OutWareNo="";
                s_PayMent = Model.CAP_Payment;
                if(Dtb_Result.Rows.Count>0)
                {
                    for (int i = 0; i < Dtb_Result.Rows.Count; i++)
                    {
                        s_OutWareNo = Dtb_Result.Rows[0]["KWD_ShipNo"].ToString();
                       // this.Lbl_PayMent.Text += base.Base_GetCustomerPayMent(Model.CAP_CustomerValue, Dtb_Result.Rows[i]["KWD_ShipNo"].ToString());
                    }

                    if (s_PayMent == "")
                    {
                        string s_Sql11 = "Select PayMent from Knet_Sales_ContractList where ContractNo in (Select ContractNo from Knet_Sales_OutWarelist where OutWareNo='" + s_OutWareNo + "' ) ";
                        s_Sql11 += " union all Select PayMent from Knet_Sales_ContractList where CustomerValue in (Select CustomerValue from Knet_Sales_OutWarelist where OutWareNo='" + s_OutWareNo + "' )";
                        this.BeginQuery(s_Sql11);
                        s_PayMent = this.QueryForReturn();
                    }
                }
                this.Ddl_PayMent.SelectedValue = s_PayMent;
                DataSet Dts_Table = Bll_Details.GetListByLeft(" CAPD_CARID='" + s_ReceiveID + "' ");
                for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                {
                    KNet.BLL.KNet_WareHouse_DirectOutList_Details bll_DircetOutDetails = new KNet.BLL.KNet_WareHouse_DirectOutList_Details();
                    KNet.Model.KNet_WareHouse_DirectOutList_Details Model_DircetOutDetails = bll_DircetOutDetails.GetModel(Dts_Table.Tables[0].Rows[i]["CAPD_FID"].ToString());
                    s_MyTable_Detail += " <tr> ";
                    s_MyTable_Detail += " <td  class=\"ListHeadDetails\"><A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a></td>";

                    if (Model_DircetOutDetails != null)
                    {
                        KNet.BLL.KNet_WareHouse_DirectOutList bll_DircetOut = new KNet.BLL.KNet_WareHouse_DirectOutList();
                        KNet.Model.KNet_WareHouse_DirectOutList Model_DircetOut = bll_DircetOut.GetModelB(Model_DircetOutDetails.DirectOutNo);
                        if (Model_DircetOut != null)
                        {
                            KNet.BLL.KNet_Sales_OutWareList Bll_SalesOut = new KNet.BLL.KNet_Sales_OutWareList();
                            KNet.Model.KNet_Sales_OutWareList Model_SalesOut = Bll_SalesOut.GetModelB(Model_DircetOut.KWD_ShipNo);
                            if (Model_SalesOut.ContractNo != "")
                            {
                                s_MyTable_Detail += " <td  class=\"ListHeadDetails\"><input type=\"hidden\"  style=\"width:0px;\" Name=\"Contract_" + i.ToString() + "\" Value=\"" + Model_SalesOut.ContractNo + "\"><input type=\"hidden\"  style=\"width:0px;\" Name=\"FID_" + i.ToString() + "\" Value=\"" + Dts_Table.Tables[0].Rows[i]["CAPD_ID"].ToString() + "\">" + Model_SalesOut.ContractNo + "</td>";
                            }
                            else
                            {
                                s_MyTable_Detail += " <td  class=\"ListHeadDetails\">&nbsp;</td>";
                            }
                        }
                        s_MyTable_Detail += " <td  class=\"ListHeadDetails\"><input type=\"hidden\"  style=\"width:0px;\" Name=\"ShipNo_" + i.ToString() + "\" Value=\"" + Model_DircetOutDetails.ID + "\">" + Model_DircetOut.DirectOutNo + "</td>";
                        s_MyTable_Detail += " <td  class=\"ListHeadDetails\"><input type=\"hidden\"  style=\"width:0px;\" Name=\"ProductsBarCode_" + i.ToString() + "\" Value=\"" + Model_DircetOutDetails.ProductsBarCode + "\">" + base.Base_GetProductsEdition_Link(Model_DircetOutDetails.ProductsBarCode) + "</td>";
                        s_MyTable_Detail += " <td  class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"ChangePrice();this.className=\'detailedViewTextBox\'\" style=\"width:170px;\" Name=\"Number_" + i.ToString() + "\" value=" + base.FormatNumber1(Dts_Table.Tables[0].Rows[i]["CAPD_Number"].ToString(),0) + "></td>";
                        s_MyTable_Detail += " <td  class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:170px;\" Name=\"Price_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["CAPD_Price"].ToString() + "> </td>";
                        s_MyTable_Detail += " <td  class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:170px;\" Name=\"Money_" + i.ToString() + "\" value=" + base.FormatNumber1(Dts_Table.Tables[0].Rows[i]["CAPD_Money"].ToString(),2) + "> </td>";
                        s_MyTable_Detail += " <td  class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:170px;\" Name=\"Remarks_" + i.ToString() + "\" > </td>";
                    }
                    s_MyTable_Detail += " </tr> ";
                }
                this.Tbx_Num.Text = Dts_Table.Tables[0].Rows.Count.ToString();

            }
            if (s_ID != "")
            {
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Tbx_Code.Text = GetCwCode(0, "Cw_Account_Bill", "CAB_Code", "CAB_Stime");
                    this.Lbl_Title.Text = "复制发票管理";
                }
                else
                {
                    this.Lbl_Title.Text = "修改发票管理";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }
            else
            {
                this.Lbl_Title.Text = "新增发票管理";
                this.Tbx_Code.Text = GetCwCode(1, "Cw_Account_Bill", "CAB_Code", "CAB_Stime");
            }
        }
    }

    private void ShowInfo(string s_ID)
    {

        KNet.BLL.Cw_Account_Bill bll = new KNet.BLL.Cw_Account_Bill();
        KNet.Model.Cw_Account_Bill model = bll.GetModel(s_ID);
        try
        {
            this.Tbx_ID.Text = s_ID;

            this.Tbx_FID.Text = model.CAB_ReceiveID;
            this.Tbx_Code.Text = model.CAB_Code;
            this.Tbx_Content.Text = model.CAB_Content;
            this.Tbx_CustomerValue.Value = model.CAB_CustomerValue;
            this.Tbx_CustomerName.Text = base.Base_GetCustomerName(model.CAB_CustomerValue);
            this.Tbx_ContractNo.Text = model.CAB_ContractNo;
            this.Ddl_PayMent.SelectedValue = model.CAB_PayMent;
            //this.Tbx_Day.Text = model.CAB_Day;
            //try
            //{
            //    this.Tbx_OutTime.Text = DateTime.Parse(model.CAB_OutTime.ToString()).ToShortDateString();
            //}
            //catch
            //{ }
            try
            {
                this.Tbx_STime.Text = DateTime.Parse(model.CAB_Stime.ToString()).ToShortDateString();
            }
            catch
            { }
            this.Ddl_BillType.SelectedValue = model.CAB_BillType.ToString();
            this.Tbx_Money.Text = model.CAB_Money.ToString();
            this.Tbx_BillNumber.Text = model.CAB_BillNumber;
            this.Tbx_Remarks.Text = model.CAB_Remarks;

            KNet.BLL.Cw_Account_Bill_Details bll_Details = new KNet.BLL.Cw_Account_Bill_Details();
            KNet.BLL.KNet_WareHouse_DirectOutList_Details bll_DirectOutList = new KNet.BLL.KNet_WareHouse_DirectOutList_Details();
            DataSet Dts_TableDetails = bll_Details.GetList(" CAD_CAAID='" + model.CAB_ID + "'");

            for (int i = 0; i < Dts_TableDetails.Tables[0].Rows.Count; i++)
            {
                KNet.Model.KNet_WareHouse_DirectOutList_Details Model_DirectOutList = bll_DirectOutList.GetModel(Dts_TableDetails.Tables[0].Rows[i]["CAD_OutNo"].ToString());
                s_MyTable_Detail += " <tr> ";
                s_MyTable_Detail += " <td  class=\"ListHeadDetails\"><A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a></td>";
                s_MyTable_Detail += " <td  class=\"ListHeadDetails\"><input type=\"hidden\"  style=\"width:0px;\" Name=\"Contract_" + i.ToString() + "\" Value=\"" + Dts_TableDetails.Tables[0].Rows[i]["CAD_ContractNo"].ToString() + "\"><input type=\"hidden\"  style=\"width:0px;\" Name=\"FID_" + i.ToString() + "\" Value=\"" + Dts_TableDetails.Tables[0].Rows[i]["CAD_FID"].ToString() + "\">" + Dts_TableDetails.Tables[0].Rows[i]["CAD_ContractNo"].ToString() + "</td>";
                s_MyTable_Detail += " <td  class=\"ListHeadDetails\"> <input type=\"hidden\"  style=\"width:0px;\" Name=\"ShipNo_" + i.ToString() + "\" Value=\"" + Dts_TableDetails.Tables[0].Rows[i]["CAD_OutNo"].ToString() + "\">" + Model_DirectOutList.DirectOutNo + "</td>";
                string s_ProductsBarCode=Dts_TableDetails.Tables[0].Rows[i]["CAD_ProductsBarCode"].ToString()==""?Model_DirectOutList.ProductsBarCode:Dts_TableDetails.Tables[0].Rows[i]["CAD_ProductsBarCode"].ToString();
                s_MyTable_Detail += " <td  class=\"ListHeadDetails\"><input type=\"hidden\"  style=\"width:0px;\" Name=\"ProductsBarCode_" + i.ToString() + "\" Value=\"" + s_ProductsBarCode + "\">" + base.Base_GetProductsEdition_Link(s_ProductsBarCode) + "</td>";
                s_MyTable_Detail += " <td  class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"ChangePrice();this.className=\'detailedViewTextBox\'\" style=\"width:170px;\" Name=\"Number_" + i.ToString() + "\" value=" + Dts_TableDetails.Tables[0].Rows[i]["CAD_Number"].ToString() + "></td>";
                s_MyTable_Detail += " <td  class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:170px;\" Name=\"Price_" + i.ToString() + "\" value=" + Dts_TableDetails.Tables[0].Rows[i]["CAD_Price"].ToString() + "> </td>";
                s_MyTable_Detail += " <td  class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:170px;\" Name=\"Money_" + i.ToString() + "\" value=" + Dts_TableDetails.Tables[0].Rows[i]["CAD_Money"].ToString() + "> </td>";
                s_MyTable_Detail += " <td  class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:170px;\" Name=\"Remarks_" + i.ToString() + "\" > </td>";

                s_MyTable_Detail += " </tr> ";
            }

            this.Tbx_Num.Text = Dts_TableDetails.Tables[0].Rows.Count.ToString();



            //this.Tbx_STime.Text = DateTime.Parse(model.CAB_STime.ToString()).ToShortDateString();
            //this.Tbx_CustomerValue.Value = model.CAB_CustomerValue;
            //this.Tbx_CustomerName.Text = base.Base_GetCustomerName(model.CAB_CustomerValue);
            //this.SuppNo.Text = base.Base_GetSupplierName(model.CAB_SuppNo);
            //this.SuppNoSelectValue.Value = model.CAB_SuppNo;
            //this.Ddl_DutyPerson.SelectedValue = model.CAB_DutyPerson;
            //this.Tbx_Title.Text = model.CAB_Title;
            //this.Tbx_Remarks.Text = model.CAB_Details;
            //this.Tbx_Money.Text = model.CAB_InitMoney.ToString();
            //this.Ddl_Type.SelectedValue = model.CAB_Type.ToString();
        }
        catch(Exception ex)
        { }
    }
    private bool SetValue(KNet.Model.Cw_Account_Bill model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text == "")
            {
                model.CAB_ID = GetMainID();
            }
            else
            {
                model.CAB_ID = this.Tbx_ID.Text;
            }
            model.CAB_Code = this.Tbx_Code.Text;
            model.CAB_Content = this.Tbx_Content.Text;
            model.CAB_CustomerValue = this.Tbx_CustomerValue.Value;
            model.CAB_ContractNo = this.Tbx_ContractNo.Text;
            model.CAB_BillType = int.Parse(this.Ddl_BillType.SelectedValue);
            model.CAB_Stime = DateTime.Parse(this.Tbx_STime.Text);
            model.CAB_DutyPerson = this.Ddl_DutyPerson.SelectedValue;
            model.CAB_Money = decimal.Parse(this.Tbx_Money.Text);
            model.CAB_BillNumber = this.Tbx_BillNumber.Text;
            model.CAB_Brokerage = this.Tbx_Brokerage.Text;
            model.CAB_Remarks = this.Tbx_Remarks.Text;
            model.CAB_Ctime = DateTime.Now;
            model.CAB_Creator = AM.KNet_StaffNo;
            model.CAB_Mtime = DateTime.Now;
            model.CAB_Mender = AM.KNet_StaffNo;
            model.CAB_CAPID = this.Tbx_FID.Text;
            model.CAB_PayMent = this.Ddl_PayMent.SelectedValue;

            model.CAB_ReceiveID = this.Tbx_FID.Text;

            //model.CAB_Day = this.Tbx_Day.Text;
            //model.CAB_OutTime = DateTime.Parse(this.Tbx_OutTime.Text);
            ArrayList arr_Details = new ArrayList();
            int i_Num = int.Parse(this.Tbx_Num.Text);
            for (int i = 0; i < i_Num; i++)
            {

                string s_ContractNo = Request["ContractNo_" + i + ""] == null ? "" : Request["ContractNo_" + i + ""].ToString();
                string s_ShipNo = Request["ShipNo_" + i + ""] == null ? "" : Request["ShipNo_" + i + ""].ToString();
                string s_Number = Request["Number_" + i + ""] == null ? "" : Request["Number_" + i + ""].ToString();
                string s_Price = Request["Price_" + i + ""] == null ? "" : Request["Price_" + i + ""].ToString();
                string s_Money = Request["Money_" + i + ""] == null ? "" : Request["Money_" + i + ""].ToString();
                string s_Remarks = Request["Remarks_" + i + ""] == null ? "" : Request["Remarks_" + i + ""].ToString();
                string s_ProductsBarCode = Request["ProductsBarCode_" + i + ""] == null ? "" : Request["ProductsBarCode_" + i + ""].ToString();
                string s_FID = Request["FID_" + i + ""] == null ? "" : Request["FID_" + i + ""].ToString();
                if (s_ShipNo != "")
                {
                    KNet.Model.Cw_Account_Bill_Details Model_Details = new KNet.Model.Cw_Account_Bill_Details();
                    Model_Details.CAD_ID = GetMainID(i);
                    Model_Details.CAD_CAAID = model.CAB_ID;
                    Model_Details.CAD_ContractNo = s_ContractNo;
                    if (s_ContractNo == "")
                    {
                        Model_Details.CAD_ContractNo = this.Tbx_ContractNo.Text;
                    }
                    Model_Details.CAD_OutNo = s_ShipNo;
                    Model_Details.CAD_Number = decimal.Parse(s_Number.ToString().Trim());
                    Model_Details.CAD_Price = decimal.Parse(s_Price);
                    Model_Details.CAD_Money = decimal.Parse(s_Money);
                    Model_Details.CAD_ProductsBarCode = s_ProductsBarCode;
                    Model_Details.CAD_Remarks = s_Remarks;
                    Model_Details.CAD_FID = s_FID;
                    arr_Details.Add(Model_Details);
                    //根据账期和发货单金额去自动创建超期

                    string s_DoSql="Select * from PB_Basic_PayMent where PBP_ID='"+model.CAB_BillType+"'";
                    this.BeginQuery(s_DoSql);
                    DataTable Dtb_tables = this.QueryForDataTable();
                    for (int j = 0; j < Dtb_tables.Rows.Count; j++)
                    {
                        decimal s_D_Money = decimal.Parse(s_Money) * decimal.Parse(Dtb_tables.Rows[j]["PBP_Percent"].ToString());
                        int s_OutDays = int.Parse(Dtb_tables.Rows[j]["PBP_OutDays"].ToString());
                        DateTime s_OutTime =DateTime.Parse(model.CAB_Stime.ToString()).AddDays(s_OutDays);
                        ArrayList arr_Details1 = new ArrayList();
                        KNet.Model.Cw_Account_Bill_Outimes Model_Outimes = new KNet.Model.Cw_Account_Bill_Outimes();
                        Model_Outimes.CAO_ID = base.GetMainID(i*10+j);
                        Model_Outimes.CAO_Money = s_D_Money;
                        Model_Outimes.CAO_OutDays = s_OutDays;
                        Model_Outimes.CAO_OutTime = s_OutTime;
                        Model_Outimes.CAO_CADID = model.CAB_ID;
                        Model_Outimes.CAOC_DirectOutID = Model_Details.CAD_OutNo;
                        arr_Details1.Add(Model_Outimes);
                        model.arr_OutTimes = arr_Details1;
                    }
                }
            }
            model.arr_Details = arr_Details;

            /*
            ArrayList arr_Details1 = new ArrayList();
            int i_Num1 = int.Parse(this.i_Num.Text);
            for (int i = 0; i < i_Num1; i++)
            {

                string s_D_Money = Request["D_Money_" + i + ""] == null ? "" : Request["D_Money_" + i + ""].ToString();
                string s_OutDays = Request["D_OutDays_" + i + ""] == null ? "" : Request["D_OutDays_" + i + ""].ToString();
                string s_OutTime = Request["D_OutTime_" + i + ""] == null ? "" : Request["D_OutTime_" + i + ""].ToString();
                string s_Remarks = Request["D_Remarks_" + i + ""] == null ? "" : Request["D_Remarks_" + i + ""].ToString();
                if (s_D_Money != "")
                {
                    KNet.Model.Cw_Account_Bill_Outimes Model_Outimes = new KNet.Model.Cw_Account_Bill_Outimes();

                    Model_Outimes.CAO_ID = base.GetMainID(i);
                    Model_Outimes.CAO_Money = decimal.Parse(s_D_Money);
                    Model_Outimes.CAO_OutDays = int.Parse(s_OutDays);
                    Model_Outimes.CAO_OutTime = DateTime.Parse(s_OutTime);
                    Model_Outimes.CAO_CADID=model.CAB_ID;
                    arr_Details1.Add(Model_Outimes);
                }
            }
            model.arr_OutTimes = arr_Details1;
             * */
            return true;
        }
        catch (Exception)
        {
            return false;
        }

    }

    protected void Btn_SaveOnClick(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        string s_ID = this.Tbx_ID.Text;
        Btn_Save.Enabled = false;
        KNet.Model.Cw_Account_Bill model = new KNet.Model.Cw_Account_Bill();
        KNet.BLL.Cw_Account_Bill bll = new KNet.BLL.Cw_Account_Bill();

        if (this.SetValue(model) == false)
        {
            Alert("系统错误！");
            return;
            Btn_Save.Enabled = true;
        }
        if (s_ID == "")//新增
        {
            try
            {
                bll.Add(model);
                AM.Add_Logs("发票管理增加" + this.Tbx_ID.Text);
                AlertAndClose("新增成功！");
            }
            catch { }
        }
        else
        {

            try
            {
                bll.Update(model);
                AM.Add_Logs("发票管理修改" + this.Tbx_ID.Text);
                AlertAndRedirect("修改成功！", "Cw_Account_Bill_List.aspx");
            }
            catch
            {
                Btn_Save.Enabled = true;
            }
        }
    }

    [Ajax.AjaxMethod]
    public string GetDetails(string s_ReveiveID,string s_PayMent,string s_Money,string STime)
    {
        string s_Return = "",s_Num="";
        try
        {
            s_Return = "<Table id=\"myTable\" width=\"100%\" border=\"0\" align=\"center\" cellpadding=\"5\" cellspacing=\"0\" class=\"ListDetails\">";
           s_Return += "<tr valign=\"top\">";// "<td valign=\"top\" class=\"lvtCol\" align=\"right\" nowrap><b>工具</b></td>";
           s_Return += "<td class=\"ListHead\" nowrap> <b>金额</b></td>";
           s_Return += "<td class=\"ListHead\" nowrap><b>超期天数</b></td>";
           s_Return += "<td class=\"ListHead\" nowrap><b>超期日期</b></td>";
           s_Return += "<td  class=\"ListHead\" nowrap><b>备注</b></td></tr>";
           if (s_ReveiveID != "")
           {
               KNet.BLL.Cw_Accounting_Payment Bll = new KNet.BLL.Cw_Accounting_Payment();
               KNet.Model.Cw_Accounting_Payment Model = Bll.GetModel(s_ReveiveID);
               decimal d_TotalMoney = decimal.Parse(Model.CAP_ReceiveMoney.ToString());
               this.BeginQuery("Select * from PB_Basic_Payment where PBP_FID='" + s_PayMent + "'");
               this.QueryForDataTable();
               DataTable Dtb_Table = this.Dtb_Result;
               decimal d_SumTotalMoney=0;
               if (Dtb_Table.Rows.Count > 0)
               {
                   for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                   {
                       decimal d_LMoney = decimal.Parse(base.FormatNumber1(Convert.ToString(decimal.Parse(s_Money == "" ? "0" : s_Money) * decimal.Parse(Dtb_Table.Rows[i]["PBP_Percent"].ToString())), 2));
                       d_SumTotalMoney += d_LMoney;
                       if (i == Dtb_Table.Rows.Count)
                       {
                           //最后一行
                           d_LMoney = d_TotalMoney - d_SumTotalMoney;
                       }
                       int i_Days=int.Parse(Dtb_Table.Rows[i]["PBP_OutDays"].ToString());
                       DateTime D_Time=DateTime.Now;
                       if(STime!="")
                       {
                           try{
                                D_Time=DateTime.Parse(STime);
                           }
                           catch
                           {}
                          
                       }
                       D_Time = D_Time.AddDays(i_Days);
                       if (D_Time != DateTime.Parse(STime))
                       {
                           D_Time = D_Time.AddDays(1 - D_Time.Day);
                       }
                       s_Return += "<tr valign=\"top\">"; //"<td class=\"lvtCol\" nowrap><A onclick=\"deleteRow1(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" border=0></a></td>";
                       s_Return += "<td class=\"ListHeadDetails\" nowrap><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:150px;\" Name=\"D_Money_" + i.ToString() + "\" value=" + d_LMoney.ToString() + "></td>";
                       s_Return += "<td class=\"ListHeadDetails\" nowrap><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\';ChgDays()\" style=\"width:150px;\"  Name=\"D_OutDays_" + i.ToString() + "\" value=" + i_Days.ToString() + "></td>";
                       s_Return += "<td class=\"ListHeadDetails\" nowrap><input type=\"text\" class=\"Wdate\" OnFocus=\"WdatePicker()\" style=\"width:200px;\" Name=\"D_OutTime_" + i.ToString() + "\" value=" + D_Time.ToShortDateString() + " ></td>";
                       s_Return += "<td  class=\"ListHeadDetails\" nowrap><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:150px;\" Name=\"D_Remarks_" + i.ToString() + "\" ></td></tr>";
                   }
                   s_Num = Dtb_Table.Rows.Count.ToString();
               }
           }
           s_Return += " </table>";
           s_Return = s_Num + "$" + s_Return;
        }
        catch
        { }
        return s_Return;
    }
}
