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


public partial class Web_Sales_Knet_Procure_WareHouseList_Add : BasePage
{
    public string s_MyTable_Detail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string s_OrderNo = Request.QueryString["OrderNo"] == null ? "" : Request.QueryString["OrderNo"].ToString();
        if (!Page.IsPostBack)
        {
            AdminloginMess AM=new AdminloginMess();
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            this.ReceivDateTime.Text = DateTime.Now.ToShortDateString();
            base.Base_DropWareHouseBind(this.ReceivPaymentNotes, " KSW_Type='0'");
            this.BeginQuery("Select * from PB_Basic_Wl ");
            this.QueryForDataTable();
            this.Drop_KD.DataSource = this.Dtb_Result;
            this.Drop_KD.DataTextField = "PBW_Name";
            this.Drop_KD.DataValueField = "PBW_Code";
            this.Drop_KD.DataBind();
            ListItem item = new ListItem("--请选择--", "-1"); //默认值
            Drop_KD.Items.Insert(0, item);
            if (s_ID != "")
            {
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制采购入库";
                    this.ReceivNo.Text = s_GetCode();
                }
                else
                {
                    this.Lbl_Title.Text = "修改采购入库";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }
            else
            {
                this.Lbl_Title.Text = "新增采购入库";
                this.ReceivNo.Text = s_GetCode();
                if (s_OrderNo != "")
                {
                    this.OrderNo.Text = s_OrderNo;
                    KNet.BLL.Knet_Procure_OrdersList Bll=new KNet.BLL.Knet_Procure_OrdersList();
                    KNet.Model.Knet_Procure_OrdersList Model=Bll.GetModelB(s_OrderNo);
                     if (Model.KPO_Del ==1)
                    {
                        AlertAndGoBack("该单已关闭不能入库！");
                    }
                    if (Model.ReceiveSuppNo != "")
                    {
                        KNet.BLL.KNet_Sys_WareHouse Bll_WareHouse = new KNet.BLL.KNet_Sys_WareHouse();
                        DataSet Dts_Table = Bll_WareHouse.GetList(" SuppNo='" + Model.ReceiveSuppNo + "'");
                        try
                        {
                            this.ReceivPaymentNotes.SelectedValue = Dts_Table.Tables[0].Rows[0]["HouseNo"].ToString();
                        }
                        catch { }
                    }
                    this.SuppNoSelectValue.Text = base.Base_GetSupplierName(Model.SuppNo);
                    this.Tbx_SuppNo.Text = Model.SuppNo;
                    this.BeginQuery("Select * from KNet_Sys_WareHouse where SuppNo='" + Model.SuppNo + "'");
                    this.QueryForDataTable();
                    if (this.Dtb_Result.Rows.Count > 0)
                    {
                        this.ReceivPaymentNotes.SelectedValue = Dtb_Result.Rows[0]["HouseNo"].ToString();
                    }
                }
            }
           // base.Base_DropLinkManBind(this.Ddl_LinkMan, this.Tbx_CustomerValue.Value);
        }

        KNet.BLL.Knet_Procure_OrdersList_Details BLL_Details = new KNet.BLL.Knet_Procure_OrdersList_Details();
        DataSet Dts_Details = BLL_Details.GetList(" a.OrderNo='" + s_OrderNo + "'");
        if (Dts_Details.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < Dts_Details.Tables[0].Rows.Count; i++)
            {
                s_MyTable_Detail += "<tr>";
                this.Xs_ProductsCode.Text += Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + ",";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a></td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ID\" value='" + Dts_Details.Tables[0].Rows[i]["ID"].ToString() + "'>" + base.Base_GetProdutsName(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ProductsBarCode\" value='" + Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "'>" + base.Base_GetProductsCode(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Number\" value='" + Dts_Details.Tables[0].Rows[i]["thisNowAmount"].ToString() + "'></td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"BNumber\" value='0'></td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Price\" value='" + Dts_Details.Tables[0].Rows[i]["OrderUnitPrice"].ToString() + "'></td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Money\" value='" + Dts_Details.Tables[0].Rows[i]["thistotalNet"].ToString() + "'></td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Remarks\" value='" + Dts_Details.Tables[0].Rows[i]["OrderRemarks"].ToString() + "'></td>";

                s_MyTable_Detail += "</tr>";
            }

        }
    }

    private void ShowInfo(string s_ID)
    {
        KNet.BLL.Knet_Procure_WareHouseList bll = new KNet.BLL.Knet_Procure_WareHouseList();
        KNet.Model.Knet_Procure_WareHouseList model = bll.GetModelB(s_ID);

        if (model.WareHouseCheckYN>0)
        {
            AlertAndGoBack("已审核，不可修改!");
            return;
        }
        //this.BeginQuery("Select * from Cg_Order_Checklist_Details where COD_DirectOutID in (Select ID from Knet_Procure_WareHouseList_Details where WareHouseNo ='" + s_ID + "')");
        //this.QueryForDataTable();
        //if (Dtb_Result.Rows.Count > 0)
        //{
        //    AlertAndGoBack("已对账，不可修改!");
        //    return;
        //}
        this.ReceivNo.Text = model.WareHouseNo;
        this.Tbx_SuppNo.Text = model.SuppNo;
        this.SuppNoSelectValue.Text = base.Base_GetSupplierName(model.SuppNo);
        this.ReceivDateTime.Text = DateTime.Parse(model.WareHouseDateTime.ToString()).ToShortDateString();
        this.OrderNo.Text = model.OrderNo;
        this.ReceivPaymentNotes.SelectedValue = model.HouseNo;
        this.Tbx_ShipDetials.Text = model.ShipDetials;
        this.ReceivRemarks.Text = model.WareHouseRemarks;
        this.Tbx_Code.Text = model.KPO_KDCode;
        this.Drop_KD.SelectedValue = model.KPO_KDNameCode;
        KNet.BLL.Knet_Procure_WareHouseList_Details BLL_Details = new KNet.BLL.Knet_Procure_WareHouseList_Details();
        DataSet Dts_Details = BLL_Details.GetList(" WareHouseNo='" + s_ID + "'");
        if (Dts_Details.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < Dts_Details.Tables[0].Rows.Count; i++)
            {
                s_MyTable_Detail += "<tr>";
                this.Xs_ProductsCode.Text += Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + ",";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a></td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ID\" value='" + Dts_Details.Tables[0].Rows[i]["ProductsUnits"].ToString() + "'><input type=\"hidden\"  Name=\"PID\" value='" + Dts_Details.Tables[0].Rows[i]["ID"].ToString() + "'>" + base.Base_GetProdutsName(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ProductsBarCode\" value='" + Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "'>" + base.Base_GetProductsCode(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Number\" value='" + Dts_Details.Tables[0].Rows[i]["WareHouseAmount"].ToString() + "'></td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"BNumber\" value='" + Dts_Details.Tables[0].Rows[i]["WareHouseBAmount"].ToString() + "'></td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Price\" value='" + Dts_Details.Tables[0].Rows[i]["WareHouseUnitPrice"].ToString() + "'></td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Money\" value='" + Dts_Details.Tables[0].Rows[i]["WareHousetotalNet"].ToString() + "'></td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Remarks\" value='" + Dts_Details.Tables[0].Rows[i]["WareHouseRemarks"].ToString() + "'></td>";
                s_MyTable_Detail += "</tr>";
            }
        }
    }

    private bool SetValue(KNet.Model.Knet_Procure_WareHouseList model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            model.ReceivNo = this.OrderNo.Text;
            model.WareHouseNo = this.ReceivNo.Text;
            model.OrderNo = this.OrderNo.Text;
            model.HouseNo = this.ReceivPaymentNotes.SelectedValue;
            model.ShipDetials = this.Tbx_ShipDetials.Text;
            model.WareHouseStaffNo = AM.KNet_StaffNo;
            model.SuppNo = this.Tbx_SuppNo.Text;
            model.WareHouseDateTime = DateTime.Parse(this.ReceivDateTime.Text);
            model.WareHouseRemarks = this.ReceivRemarks.Text;
            model.KPW_CTime = DateTime.Now;
            model.KPW_Creator = AM.KNet_StaffNo;
            model.KPW_MTime = DateTime.Now;
            model.KPW_Mender = AM.KNet_StaffNo;
            model.WareHouseCheckYN = 1;
            model.KPW_Del = 0;
            model.KPO_KDNameCode = this.Drop_KD.SelectedValue;
            model.KPO_KDName = this.Drop_KD.SelectedItem.Text;
            model.KPO_KDCode = this.Tbx_Code.Text;
            ArrayList Arr_Products = new ArrayList();
            if (Request["ProductsBarCode"] != null)
            {
                string[] s_ProductsBarCode = Request.Form["ProductsBarCode"].Split(',');
                string[] s_Number = Request.Form["Number"].Split(',');
                string[] s_BNumber = Request.Form["BNumber"].Split(',');
                string[] s_Price = Request.Form["Price"].Split(',');
                string[] s_Money = Request.Form["Money"].Split(',');
                string[] s_Remarks = Request.Form["Remarks"].Split(',');
                string[] s_ID = Request.Form["ID"].Split(',');
                string s_PIDs = Request.Form["PID"] == null ? "" : Request.Form["PID"].ToString();
                string[] s_PID =s_PIDs.Split(',');
                
                for (int i = 0; i < s_ProductsBarCode.Length; i++)
                {
                    KNet.Model.Knet_Procure_WareHouseList_Details Model_Details = new KNet.Model.Knet_Procure_WareHouseList_Details();
                    if (s_PIDs != "")
                    {
                        Model_Details.ID = s_PID[i];
                    }
                    else
                    {
                        Model_Details.ID = GetNewID("Knet_Procure_WareHouseList_Details", 1);
                    }
                    Model_Details.ProductsBarCode = s_ProductsBarCode[i];
                    Model_Details.WareHouseNo = model.WareHouseNo;
                    Model_Details.WareHouseAmount = int.Parse(s_Number[i]);
                    Model_Details.WareHouseUnitPrice = decimal.Parse(s_Price[i]);
                    decimal d_Money = int.Parse(s_Number[i]) * decimal.Parse(s_Price[i]);
                    Model_Details.WareHouseTotalNet = d_Money;
                    Model_Details.WareHouseRemarks = s_Remarks[i];
                    Model_Details.ProductsUnits = s_ID[i];
                    Model_Details.WareHouseBAmount = int.Parse(s_BNumber[i]);
                    Model_Details.KWP_NoTaxMoney = decimal.Parse(base.FormatNumber1(Convert.ToString(d_Money / Decimal.Parse("1.17")), 2)); 
                    Arr_Products.Add(Model_Details);
                }
                model.Arr_Products = Arr_Products;
            }
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    protected void Btn_SaveOnClick(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        string s_ID = this.Tbx_ID.Text;

        KNet.Model.Knet_Procure_WareHouseList model = new KNet.Model.Knet_Procure_WareHouseList();
        KNet.BLL.Knet_Procure_WareHouseList bll = new KNet.BLL.Knet_Procure_WareHouseList();
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
                AM.Add_Logs("采购入库增加" + this.Tbx_ID.Text);
                //base.Base_SendMessage(base.Base_GetDeptPerson("供应链平台", 1), "采购入库增加： <a href='Web/OrderInWareHouse/Knet_Procure_WareHouseList_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.WareHouseNo + "</a> 需要你审批！ ");
                AlertAndRedirect("新增成功！", "Knet_Procure_WareHouseList_List.aspx");
            }
            catch(Exception ex) { }
        }
        else
        {

            try
            {
                bll.Update(model);
                AM.Add_Logs("采购入库修改" + this.Tbx_ID.Text);
                //base.Base_SendMessage(base.Base_GetDeptPerson("供应链平台", 1), "采购入库修改： <a href='Web/OrderInWareHouse/Knet_Procure_WareHouseList_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.WareHouseNo + "</a> 需要你审批！ ");
                AlertAndRedirect("修改成功！", "Knet_Procure_WareHouseList_List.aspx");

            }
            catch(Exception ex) { }
        }
    }
    private string s_GetCode()
    {
        string s_Return = "";
        try
        {
            KNet.BLL.Knet_Procure_WareHouseList Bll = new KNet.BLL.Knet_Procure_WareHouseList();

            string S_Code = Bll.GetLastCode();
            if (S_Code == "")
            {

                s_Return += "W" + DateTime.Today.ToString("yyyyMMdd") + "-" + "0001";
            }
            else
            {
                try
                {
                    S_Code = "1" + S_Code.Substring(10, 4);
                }
                catch
                {

                    S_Code = "10" + S_Code.Substring(10, 3);
                }
                decimal d_NewCode = decimal.Parse(S_Code) + 1;
                s_Return += "W" + DateTime.Today.ToString("yyyyMMdd") + "-" + d_NewCode.ToString().Substring(1, d_NewCode.ToString().Length - 1);
            }

        }
        catch (Exception ex)
        {
           s_Return = "-";
        }
        return s_Return;
    }
}
