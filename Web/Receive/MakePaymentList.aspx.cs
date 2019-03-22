using KNet.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Receive_MakePaymentList : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            string s_ProductsBarCode = Request.QueryString["ProductsBarCode"] == null ? "" : Request.QueryString["ProductsBarCode"].ToString();
            string Custmoer = Request.QueryString["Custmoer"] == null ? "" : Request.QueryString["Custmoer"].ToString();
            string startDate = Request.QueryString["startDate"] == null ? "" : Request.QueryString["startDate"].ToString();
            string endDate = Request.QueryString["endDate"] == null ? "" : Request.QueryString["endDate"].ToString();
            string Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            this.QCKP.Visible = false;
            this.BYFH.Visible = false;
            this.BYQM.Visible = false;
            this.BYKP.Visible = false;
            //if (Custmoer != "")
            //{

            //    Lbl_ProductsBarCode.Text = "客户：(" + Base_GetCustomer(Custmoer) + ")";
            //}
            //if (s_ProductsBarCode != "")
            //{
            //    this.Lbl_House.Text = "产品：" + Base_GetProductsEdition(s_ProductsBarCode);
                
            //}
            if (Type=="QC")
            {
                this.QCKP.Visible = true;
               this.LabelQCKH.Text= "客户：(" + Base_GetCustomer(Custmoer) + ")";
                this.LabelQCN.Text= "产品：" + Base_GetProductsEdition(s_ProductsBarCode);
                this.BeginQuery("Select *,(DirectOutAmount-CAPD_Number) as QC  from Cw_Accounting_PaymentDetails a join KNet_WareHouse_DirectOutList_Details b on a.CAPD_FID = b.ID join KNet_WareHouse_DirectOutList c on c.DirectOutNo = b.DirectOutNo join Cw_Accounting_Payment d on d.CAP_ID = a.CAPD_CARID where ProductsBarCode = '" + s_ProductsBarCode + "'and KWD_Custmoer = '" + Custmoer + "' and CAP_STime < '" + startDate + "'");
                this.QueryForDataSet();
                DataSet ds_Details = this.Dts_Result;
                this.MyGridView1.DataSource = ds_Details;
                MyGridView1.DataBind();
            }
            if (Type == "QM")
            {
                this.BYQM.Visible = true;
                Lbl_ProductsBarCode.Text = "客户：(" + Base_GetCustomer(Custmoer) + ")";
                this.Lbl_House.Text = "产品：" + Base_GetProductsEdition(s_ProductsBarCode);
                this.BeginQuery("Select *,(DirectOutAmount-CAPD_Number) as QC  from Cw_Accounting_PaymentDetails a join KNet_WareHouse_DirectOutList_Details b on a.CAPD_FID = b.ID join KNet_WareHouse_DirectOutList c on c.DirectOutNo = b.DirectOutNo join Cw_Accounting_Payment d on d.CAP_ID = a.CAPD_CARID where ProductsBarCode = '" + s_ProductsBarCode + "'and KWD_Custmoer = '" + Custmoer + "' and CAP_STime >= '" + startDate + "' and CAP_STime <= '" + endDate + "'");
                this.QueryForDataSet();

                DataSet ds_Details1 = this.Dts_Result;
                this.MyGridView2.DataSource = ds_Details1;
                MyGridView2.DataBind();
            }
            if (Type == "FH")
            {
                this.BYFH.Visible = true;
                this.LabelFHKH.Text = "客户：(" + Base_GetCustomer(Custmoer) + ")";
                this.LabelFHN.Text = "产品：" + Base_GetProductsEdition(s_ProductsBarCode);
                this.BeginQuery("Select *,(DirectOutAmount-CAPD_Number) as QC  from Cw_Accounting_PaymentDetails a join KNet_WareHouse_DirectOutList_Details b on a.CAPD_FID = b.ID join KNet_WareHouse_DirectOutList c on c.DirectOutNo = b.DirectOutNo join Cw_Accounting_Payment d on d.CAP_ID = a.CAPD_CARID where ProductsBarCode = '" + s_ProductsBarCode + "'and KWD_Custmoer = '" + Custmoer + "' and CAP_STime >= '" + startDate + "' and CAP_STime <= '" + endDate + "'");
                this.QueryForDataSet();

                DataSet ds_Details1 = this.Dts_Result;
                this.MyGridView3.DataSource = ds_Details1;
                MyGridView3.DataBind();
            }
            if (Type == "KP")
            {
                this.BYKP.Visible = true;
                this.LabelKPKH.Text = "客户：(" + Base_GetCustomer(Custmoer) + ")";
                this.LabelKPN.Text = "产品：" + Base_GetProductsEdition(s_ProductsBarCode);
                this.BeginQuery("Select *,(DirectOutAmount-CAPD_Number) as QC  from Cw_Accounting_PaymentDetails a join KNet_WareHouse_DirectOutList_Details b on a.CAPD_FID = b.ID join KNet_WareHouse_DirectOutList c on c.DirectOutNo = b.DirectOutNo join Cw_Accounting_Payment d on d.CAP_ID = a.CAPD_CARID where ProductsBarCode = '" + s_ProductsBarCode + "'and KWD_Custmoer = '" + Custmoer + "' and CAP_STime >= '" + startDate + "' and CAP_STime <= '" + endDate + "'");
                this.QueryForDataSet();

                DataSet ds_Details1 = this.Dts_Result;
                this.MyGridView4.DataSource = ds_Details1;
                MyGridView4.DataBind();
            }
        }
    }

  
}