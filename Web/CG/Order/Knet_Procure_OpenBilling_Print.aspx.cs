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


public partial class Web_Sales_Knet_Procure_OpenBilling_Print : BasePage
{
    public string s_MyTable_Detail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            if (s_ID != "")
            {
                ShowInfo(s_ID);
            }
        }
       
    }

    private void ShowInfo(string s_ID)
    {
        try
        {
            KNet.BLL.Knet_Procure_OrdersList BLL = new KNet.BLL.Knet_Procure_OrdersList();
            KNet.Model.Knet_Procure_OrdersList Model = BLL.GetModel(s_ID);
            this.Lbl_Code.Text = Model.OrderNo;
            this.Lbl_Stime.Text = DateTime.Parse(Model.OrderDateTime.ToString()).ToShortDateString();
            KNet.BLL.Knet_Procure_Suppliers BLL_Supp = new KNet.BLL.Knet_Procure_Suppliers();
            KNet.Model.Knet_Procure_Suppliers Model_Supp = BLL_Supp.GetModelB(Model.SuppNo);
            this.Lbl_Email.Text = Model_Supp.SuppEmail;
            this.Lbl_Fax.Text = Model_Supp.SuppFax;
            this.Lbl_Tel.Text = Model_Supp.SuppPhone;
            this.Lbl_Tel1.Text = Model_Supp.SuppMobiTel;

            this.Lbl_PayFor.Text =  base.Base_GetBasicCodeName("300", Model_Supp.KPS_Days.ToString());
            
            this.Lbl_SuppNo.Text = Model_Supp.SuppName;
            this.Lbl_ToPepole.Text = Model_Supp.SuppPeople;
            KNet.BLL.KNet_Resource_Staff BLL_STaff = new KNet.BLL.KNet_Resource_Staff();
            KNet.Model.KNet_Resource_Staff Model_STaff = BLL_STaff.GetModelC(Model.OrderStaffNo);
            this.Lbl_FromDetails.Text = base.Base_GeDept(Model_STaff.StaffBranch);

            this.Lbl_FromPepole.Text = Model_STaff.StaffName;
            this.Lbl_FromEmail.Text = Model_STaff.StaffEmail;
            this.Lbl_FromTel.Text = Model_STaff.StaffTel;
            this.Lbl_FromTel1.Text = Model_STaff.TelPhone;
            this.Lbl_PreTime.Text = "<font Size=\"4px\">" + DateTime.Parse(Model.OrderPreToDate.ToString()).ToShortDateString() + "</Font>";
            this.Lbl_Remarks.Text = Model.OrderRemarks;
            this.Lbl_Address.Text = Model.ContractAddress.Replace("\n", "<br/>");
            this.Lbl_ScDetails.Text = Model.KPO_ScDetails;
            this.Lbl_FOrderNo.Text = Model.ParentOrderNo;
            KNet.BLL.Knet_Procure_OrdersList_Details Bll_Details = new KNet.BLL.Knet_Procure_OrdersList_Details();
            DataSet Dts_Table = Bll_Details.GetList(" a.OrderNo='" + Model.OrderNo + "' ");
            decimal d_All_OrderTotal = 0, d_All_HandTotal = 0, d_All_Total = 0;
            if (Dts_Table.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                {

                    s_MyTable_Detail += " <tr>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\" rowSpan=2>" + (i + 1) + "</td>";
                    if (Model.OrderType != "128860698200781250")
                    {
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\" rowSpan=2>" + base.Base_GetProdutsName(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    }
                    else
                    {
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\" rowSpan=2>成品</td>";
 
                    }
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetProductsCode(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\" >" + base.Base_GetProductsPattern(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    if (Model.OrderType != "128860698200781250")
                    {
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\" >" + base.Base_GetProductsEdition(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";

                    }
                    else
                    {
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\" rowSpan=2>&nbsp;</td>";
                    }
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\" >" + Dts_Table.Tables[0].Rows[i]["KPOD_BrandName"].ToString() + "</td>";

                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["KPOD_BigUnits"].ToString(), 0) + "</td>";

                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["OrderAmount"].ToString(), 0) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["OrderUnitPrice"].ToString(), 6) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["HandPrice"].ToString(), 4) + "</td>";
                    decimal d_Amount = Decimal.Parse(Dts_Table.Tables[0].Rows[i]["OrderTotalNet"].ToString()) + Decimal.Parse(Dts_Table.Tables[0].Rows[i]["HandTotal"].ToString() == "" ? "0" : Dts_Table.Tables[0].Rows[i]["HandTotal"].ToString());
                    d_All_OrderTotal += Decimal.Parse(Dts_Table.Tables[0].Rows[i]["OrderTotalNet"].ToString());
                    d_All_HandTotal += Decimal.Parse(Dts_Table.Tables[0].Rows[i]["HandTotal"].ToString() == "" ? "0" : Dts_Table.Tables[0].Rows[i]["HandTotal"].ToString());
                    d_All_Total += d_Amount;
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_Amount.ToString(), 2) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + Dts_Table.Tables[0].Rows[i]["OrderRemarks"].ToString() + "</td>";
                    s_MyTable_Detail += " </tr>";

                    KNet.BLL.KNet_Sys_Products BLL_Products = new KNet.BLL.KNet_Sys_Products();
                    KNet.Model.KNet_Sys_Products Model_Products = BLL_Products.GetModelB(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString());
                    s_MyTable_Detail += " <tr>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"left\" height=\"28px\" colspan=9>";
                    s_MyTable_Detail += "<font Size=\"3px\" >参数:" + Model_Products.ProductsDescription + "</font></td>";
                    s_MyTable_Detail += " </tr>";

                    //this.Lbl_ProductsDetails.Text += Model_Products.ProductsDescription;
                }
            }
            this.Lbl_AllCount.Text = " 材料总计：￥" + FormatNumber(d_All_OrderTotal.ToString(), 2) + "   加工费总计：￥" + FormatNumber(d_All_HandTotal.ToString(), 2) + "  总计：￥" + FormatNumber(d_All_Total.ToString(), 2) + "<br/>金额大写：" + base.ConvertMoney(d_All_Total);
            //this.Lbl_Rate.Text = " 增值税：￥" + Convert.ToString((d_All_Total * 17) / 100) + "  合计(不含税)：￥" + Convert.ToString((d_All_Total * 83) / 100) + "   总计：￥" + d_All_Total.ToString();
            this.Lbl_Staff.Text = "______" + base.Base_GetUserName(Model.OrderStaffNo) + "______";
            this.Lbl_ShStaff.Text = "______" + base.Base_GetUserName(Model.OrderCheckStaffNo) + "______";
        }
        catch
        { }
    }

}
