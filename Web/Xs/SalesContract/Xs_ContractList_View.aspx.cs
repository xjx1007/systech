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

using System.IO;
using System.Text;

using KNet.DBUtility;
using KNet.Common;

public partial class Web_Sales_Xs_ContractList_View : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.DataShow();
        }
    }
    private void DataShow()
    {
        string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
        if (s_ID != "")
        {
            KNet.BLL.KNet_Sales_ContractList BLL_Sales_ContractList = new KNet.BLL.KNet_Sales_ContractList();
            KNet.Model.KNet_Sales_ContractList Model = BLL_Sales_ContractList.GetModelB(Request.QueryString["ID"].ToString());
            this.ContractNo.Text = Model.ContractNo;
            this.ContractDateTime.Text = DateTime.Parse(Model.ContractDateTime.ToString()).ToShortDateString();
            this.CustomerName.Text = base.Base_GetCustomerName(Model.CustomerValue);
            this.ContractToAddress.Text = Model.ContractToAddress;
            this.ContractDeliveMethods.Text = base.Base_GetKClaaName(Model.ContractDeliveMethods);
            this.Tbx_ContentPerson.Text = Model.ContentPerson;
            this.Tbx_Telephone.Text = Model.Telephone;
            this.ContractStarDateTime.Text = DateTime.Parse(Model.ContractStarDateTime.ToString()).ToShortDateString();
            KNet.BLL.KNet_ContractDate BLL_Date = new KNet.BLL.KNet_ContractDate();
            if (BLL_Date.GetOldDate(s_ID,0) != "")
            {
                this.ContractToDeliDate.Text = DateTime.Parse(Model.ContractToDeliDate.ToString()).ToShortDateString() + " (<font Color=red>" + DateTime.Parse(BLL_Date.GetOldDate(s_ID,0)).ToShortDateString() + "</font>)";
            }
            else
            {
                this.ContractToDeliDate.Text = DateTime.Parse(Model.ContractToDeliDate.ToString()).ToShortDateString();
            }
            if (BLL_Date.GetOldDate(s_ID, 1) != "")
            {
                this.ContractToDeliDate.Text = DateTime.Parse(Model.KFC_ReDate.ToString()).ToShortDateString() + " (<font Color=red>" + DateTime.Parse(BLL_Date.GetOldDate(s_ID, 1)).ToShortDateString() + "</font>)";
            }
            else
            {
                if (Model.KFC_ReDate != null) 
                {
                    this.ContractToDeliDate.Text = DateTime.Parse(Model.KFC_ReDate.ToString()).ToShortDateString();
                }
            }

            KNet.BLL.Xs_Contract_ViewPerson BLL_View = new KNet.BLL.Xs_Contract_ViewPerson();
            KNet.Model.Xs_Contract_ViewPerson Model_View = new KNet.Model.Xs_Contract_ViewPerson();
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            if ((Model.ContractCheckYN == true)&&(s_Type!=""))
            {
                AdminloginMess AM=new AdminloginMess();
                Model_View.XCV_ID = GetNewID("Xs_Contract_ViewPerson", 1);
                Model_View.XCV_Person = AM.KNet_StaffNo;
                Model_View.XCV_State = "1";
                Model_View.XCV_Time = DateTime.Now;
                Model_View.XCV_ContractNo = s_ID;
                Model_View.XCV_Del = 1;
                try
                {
                    BLL_View.UpdateDel(Model_View);
                    BLL_View.Add(Model_View);
                }
                catch
                {
 
                }
            }

            string s_Sqlwhere = "  XCV_Del='0' and XCV_ContractNo='" + s_ID + "' order by XCV_ID desc ";
            DataSet Ds1 = BLL_View.GetList(s_Sqlwhere);
            GridView2.DataSource = Ds1;
            GridView2.DataBind();

            this.ContractClass.Text = base.Base_GetKClaaName(Model.ContractClass);
            this.Drop_RoutineTransport.Text = base.Base_GetBasicCodeName("102",Model.RoutineTransport);
            this.Drop_WorryTransport.Text = base.Base_GetBasicCodeName("103",Model.WorryTransport);
            this.ContractToPayment.Text = base.Base_GetCheckMethod(Model.ContractToPayment);
            this.Tbx_TechnicalRequire.Text = Model.TechnicalRequire;
            this.Tbx_ProductPackaging.Text = Model.ProductPackaging;
            this.Tbx_QualityRequire.Text = Model.QualityRequire;
            this.Tbx_WarrantyPeriod.Text = Model.WarrantyPeriod;
            this.Tbx_DeliveryRequire.Text = Model.DeliveryRequire;
            this.ContractRemarks.Text = Model.ContractRemarks;
            this.Lbl_ContractShip.Text = Model.ContractShip;
            this.Lbl_DutyPerson.Text = base.Base_GetUserName(Model.DutyPerson);
            this.Drop_Payment.Text = base.Base_GetBasicCodeName( "104",Model.Payment);
            if (Model.ProductsPic == 1)
            {
                this.Image1.Visible = true;
                this.Image1.ImageUrl = Model.ProductsSmallPicture;

                this.HyperLink1.Visible = true;
                this.HyperLink1.NavigateUrl = Model.ProductsBigPicture;
               
            }
            else
            {
                this.Image1.Visible = false;
                this.HyperLink1.Visible = false;
            }

            //明细
            this.BeginQuery("Select OrderNo,SuppNo From Knet_Procure_OrdersList Where ContractNo='" + this.ContractNo.Text + "'");
            this.QueryForDataTable();
            string s_OrderNo = "", s_SuppNo = "";
            if (this.Dtb_Result.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Result.Rows.Count; i++)
                {

                    s_OrderNo = this.Dtb_Result.Rows[i][0].ToString();
                    s_SuppNo = this.Dtb_Result.Rows[i][1].ToString();
                    this.Lbl_Supplier.Text += base.Base_GetSupplierName(s_SuppNo) + ",";
                    this.OrderNo.Text += "<a href=\"#\"  onclick=\"javascript:window.open('../Procure/Knet_Procure_OpenBilling_PrinterListSettingPrinterPage.aspx?OrderNo=" + s_OrderNo + "&PrinterModel=128917825766562500','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');\">" + s_OrderNo + "</a>"+",";


                }

            }




            this.BeginQuery("Select * From  KNet_Sales_OutWareList Where ContractNo='" + this.ContractNo.Text + "'");
            this.QueryForDataTable();
            if (this.Dtb_Result.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Result.Rows.Count; i++)
                {
                    this.ShipNo.Text += "<a href=\"#\"  onclick=\"javascript:window.open('Knet_Sales_Ship_Manage_PrinterListSettingPrinterPage.aspx?OutWareNo=" + Dtb_Result.Rows[i]["OutWareNo"].ToString() + "&PrinterModel=128900331899375001','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');\">" + Dtb_Result.Rows[i]["OutWareNo"].ToString() + "</a>" +"   ";

                }
            }


            this.BeginQuery("Select * From  KNet_WareHouse_DirectOutList Where KWD_ShipNo in (Select OutWareNo from KNet_Sales_OutWareList where  ContractNo='" + this.ContractNo.Text + "')");
            this.QueryForDataTable();
            if (this.Dtb_Result.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Result.Rows.Count; i++)
                {
                    this.DirectNo.Text += "<a href=\"#\"  onclick=\"javascript:window.open('/WareHouse/KNet_WareHouse_DirectOut_Manage_PrinterListSettingPage.aspx?DirectOutNo=" + Dtb_Result.Rows[i]["DirectOutNo"].ToString() + "&PrinterModel=128919258398906250','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');\">" + Dtb_Result.Rows[i]["DirectOutNo"].ToString() + "</a>" + "   ";

                }
            }
            this.BeginQuery("Select HouseNo from Knet_Procure_WareHouseList Where OrderNo='" + s_OrderNo + "' ");
            this.QueryForDataTable();
            string s_HouseNo = "";
            if (this.Dtb_Result.Rows.Count > 0)
            {
                s_HouseNo = this.Dtb_Result.Rows[0][0].ToString();
            }
            this.Lbl_House.Text = base.Base_GetHouseName(s_HouseNo);

            KNet.BLL.KNet_Sales_ContractList_Details BLL_Sales_ContractList_Details = new KNet.BLL.KNet_Sales_ContractList_Details();
            string s_Sql = " ContractNo='" + Model.ContractNo + "'";
            DataSet Dts_ContractList = BLL_Sales_ContractList_Details.GetList(s_Sql);
            MyGridView1.DataSource = Dts_ContractList;
            MyGridView1.DataBind();


            KNet.BLL.KNet_Sales_Flow Bll_Sales_Flow = new KNet.BLL.KNet_Sales_Flow();
            KNet.Model.KNet_Sales_Flow Model_Sales_Flow = new KNet.Model.KNet_Sales_Flow();
            GridView1.DataSource = Bll_Sales_Flow.GetList(" KSF_ContractNo='" + this.ContractNo.Text + "' and KFS_Type='0'  Order  by KSF_Date desc");
            this.GridView1.DataBind();
        }
 
    }
    public string GetCgNumer(string s_ProductsBarCode)
    {
        try
        {
            this.BeginQuery("Select OrderAmount from Knet_Procure_OrdersList_Details Where ProductsBarCode='" + s_ProductsBarCode + "' and OrderNo in (Select OrderNo From Knet_Procure_OrdersList Where ContractNo='" + this.ContractNo.Text + "')");
            this.QueryForDataTable();
            if (Dtb_Result.Rows.Count > 0)
            {
                return Dtb_Result.Rows[0][0].ToString();
            }
            else
            {
                return "";
            }

        }
        catch (Exception ex)
        {
            return "";
        }
    }
    public string GetRkNumber(string s_ProductsBarCode)
    {
        this.BeginQuery("Select OrderHaveReceiving from Knet_Procure_OrdersList_Details Where ProductsBarCode='" + s_ProductsBarCode + "' and OrderNo in (Select OrderNo From Knet_Procure_OrdersList Where ContractNo='" + this.ContractNo.Text + "')");
        this.QueryForDataTable();
        if (Dtb_Result.Rows.Count > 0)
        {
            return Dtb_Result.Rows[0][0].ToString();
        }
        else
        {
            return "";
        }
    }
    public string GetFHNumber(string s_ProductsBarCode)
    {
        this.BeginQuery("Select Sum(OutWareAmount) from KNet_Sales_OutWareList_Details Where ProductsBarCode='" + s_ProductsBarCode + "' and OutWareNo in (Select OutWareNo From KNet_Sales_OutWareList Where ContractNo='" + this.ContractNo.Text + "')");
        this.QueryForDataTable();
        if (Dtb_Result.Rows.Count > 0)
        {
            return Dtb_Result.Rows[0][0].ToString();
        }
        else
        {
            return "";
        }
    }

    //流程
    public string GetFlowName(string s_Flow)
    {
        string s_FlowName = "";
        switch (s_Flow)
        {
            case "1":
                s_FlowName = "通过审核!";
                break;
            case "2":
                s_FlowName = "合同作废!";
                break;
            case "3":
                s_FlowName = "<font color='Blue'>异常通过!</font>";
                break;
            case "4":
                s_FlowName = "重新提交!";
                break;
            case "0":
                s_FlowName = "<font color='red'>不通过！</font>";
                break;
        }
        return s_FlowName;
    }
}
