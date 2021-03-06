﻿using System;
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
using System.Reflection;
using iTextSharp.text;
using Microsoft.Office;
using Word=Microsoft.Office.Interop.Word;

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

    public string PCPrice(string productbarcode)
    {
       
     
      
            string sql = "select top 1 KPP_PCPrice from Knet_Procure_SuppliersPrice where ProductsBarCode='" + productbarcode + "' and KPP_State!=0 and  KPP_Del!=1";

            this.BeginQuery(sql);
            DataSet Dts_DemoProducts = (DataSet)this.QueryForDataSet();
            DataTable Dtb_DemoProducts = Dts_DemoProducts.Tables[0];
            string P = Dtb_DemoProducts.Rows[0][0].ToString();
           
            if (P == "")
            {
                P = "0";
            }
        return P;


    }
    public string HandPrice(string productbarcode)
    {



        string sql = "select top 1 HandPrice from Knet_Procure_SuppliersPrice where ProductsBarCode='" + productbarcode + "' and KPP_State!=0 and  KPP_Del!=1";

        this.BeginQuery(sql);
        DataSet Dts_DemoProducts = (DataSet)this.QueryForDataSet();
        DataTable Dtb_DemoProducts = Dts_DemoProducts.Tables[0];
        string P = Dtb_DemoProducts.Rows[0][0].ToString();

        if (P == "")
        {
            P = "0";
        }
        return P;


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
            if(Model_Supp.KPS_Check=="0")
            {
                this.Lbl_PayFor.Text = base.Base_GetBasicCodeName("300", Model_Supp.KPS_Days.ToString())+"(不承兑)";
            }
            else
            {
                this.Lbl_PayFor.Text = base.Base_GetBasicCodeName("300", Model_Supp.KPS_Days.ToString()) + "(银行承兑)";
            }
            
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
            decimal d_All_OrderTotal = 0, d_All_HandTotal = 0, d_All_Total = 0;
            if (Model.OrderNo.Substring(0,2).ToString()=="YP")//如果是请购单
            {
                string s_Sql = "select  * FROM  KNet_Sampling_List where ID='"+ Model.OrderNo + "'";
                this.BeginQuery(s_Sql);
                DataTable Dts_Table = (DataTable)this.QueryForDataTable();
                if (Dts_Table.Rows.Count > 0)
                {
                    for (int i = 0; i < Dts_Table.Rows.Count; i++)
                    {

                        s_MyTable_Detail += " <tr>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\" rowSpan=2>" + (i + 1) + "</td>";
                       
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\" rowSpan=2>" + Dts_Table.Rows[i]["SampleName"].ToString() + "</td>";
                       
                       
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + Dts_Table.Rows[i]["ID"].ToString() + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\" ></td>";
                        
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\" ></td>";

                      
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\" ></td>";

                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\"></td>";

                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Rows[i]["Number"].ToString(), 0) + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Rows[i]["Price"].ToString(), 6) + "</td>";
                        
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\"></td>";
                        decimal d_Amount = Convert.ToDecimal(Dts_Table.Rows[i]["Price"].ToString())*
                                           Convert.ToDecimal(Dts_Table.Rows[i]["Number"].ToString());
                        d_All_Total += d_Amount;
                        d_All_OrderTotal+= d_Amount;
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_Amount.ToString(), 2) + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + Dts_Table.Rows[i]["Remark"].ToString() + "</td>";
                        s_MyTable_Detail += " </tr>";

                        KNet.BLL.KNet_Sys_Products BLL_Products = new KNet.BLL.KNet_Sys_Products();
                        KNet.Model.KNet_Sys_Products Model_Products = BLL_Products.GetModelB(Dts_Table.Rows[i]["ID"].ToString());
                        s_MyTable_Detail += " <tr>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"left\" height=\"28px\" colspan=9>";
                        s_MyTable_Detail += "<font Size=\"3px\" >参数:</font></td>";
                        s_MyTable_Detail += " </tr>";

                        //this.Lbl_ProductsDetails.Text += Model_Products.ProductsDescription;
                    }
                }
            }
            else
            {
                KNet.BLL.Knet_Procure_OrdersList_Details Bll_Details = new KNet.BLL.Knet_Procure_OrdersList_Details();
                DataSet Dts_Table = Bll_Details.GetList(" a.OrderNo='" + Model.OrderNo + "' ");

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

                       
                        decimal cont = 0;
                        string BigUnits = "";
                        BigUnits =
           base.Base_GetBigUnitsByProductCode(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString());
                        if (BigUnits!="")
                        {
                            string c = BigUnits.Remove(BigUnits.LastIndexOf("/"));
                            string unit= BigUnits.Substring(BigUnits.LastIndexOf("/")+1);
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">"+ unit + "</td>";
                            cont = decimal.Parse(Dts_Table.Tables[0].Rows[i]["OrderAmount"].ToString())/Convert.ToInt32(c);
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + cont.ToString() + "</td>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber((decimal.Parse(Dts_Table.Tables[0].Rows[i]["OrderUnitPrice"].ToString())).ToString(), 6) + "</td>";
                        }
                        else
                        {
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + Dts_Table.Tables[0].Rows[i]["KPOD_BigUnits"].ToString() + "</td>";
                            cont = decimal.Parse(Dts_Table.Tables[0].Rows[i]["OrderAmount"].ToString());
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(cont.ToString(), 0) + "</td>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["OrderUnitPrice"].ToString(), 6) + "</td>";
                        }
                       
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + PCPrice(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";//赔偿单价
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + HandPrice(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
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
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"left\" height=\"28px\" colspan=13>";
                        s_MyTable_Detail += "<font Size=\"3px\" >参数:" + Model_Products.ProductsDescription + "</font></td>";
                        s_MyTable_Detail += " </tr>";

                        //this.Lbl_ProductsDetails.Text += Model_Products.ProductsDescription;
                    }
                }
            }
            if (Model_Supp.KPS_Check=="1")
            {
                this.Lbl_AllCount.Text = " 材料总计：￥" + FormatNumber(d_All_OrderTotal.ToString(), 2) + "   加工费总计：￥" + FormatNumber(d_All_HandTotal.ToString(), 2) + "  总计：￥" + FormatNumber(d_All_Total.ToString(), 2) + "<br/>金额大写：" + base.ConvertMoney(d_All_Total)+ "(含16%增值税)(银行承兑汇票)";
            }
            else
            {
                this.Lbl_AllCount.Text = " 材料总计：￥" + FormatNumber(d_All_OrderTotal.ToString(), 2) + "   加工费总计：￥" + FormatNumber(d_All_HandTotal.ToString(), 2) + "  总计：￥" + FormatNumber(d_All_Total.ToString(), 2) + "<br/>金额大写：" + base.ConvertMoney(d_All_Total)+ "(含16%增值税)";
            }
           
            //this.Lbl_Rate.Text = " 增值税：￥" + Convert.ToString((d_All_Total * 17) / 100) + "  合计(不含税)：￥" + Convert.ToString((d_All_Total * 83) / 100) + "   总计：￥" + d_All_Total.ToString();
            this.Lbl_Staff.Text = "______" + base.Base_GetUserName(Model.OrderStaffNo) + "______";
            this.Lbl_ShStaff.Text = "______" + base.Base_GetUserName(Model.OrderCheckStaffNo) + "______";
        }
        catch
        { }
    }

    //protected void Button1_OnClick(object sender, EventArgs e)
    //{
    //   Word.ApplicationClass wordApp=new Word.ApplicationClass();
    //    object missing = Missing.Value;
    //    object tempName = @"C:\Users\sg\Desktop\Normal.dot";
    //    object docName = @"C:\Users\sg\Desktop\test.doc";
    //    Word.Document MyDoc = wordApp.Documents.Add(ref tempName, ref missing, ref missing, ref missing);
    //    wordApp.Visible = true;
    //    MyDoc.Activate();
    //    wordApp.Selection.Font.Size = 14;
    //    wordApp.Selection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
    //    wordApp.Selection.Font.Bold = (int) Word.WdConstants.wdToggle;
    //    wordApp.Selection.TypeText("helloword");
    //    MyDoc.SaveAs2(ref docName, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
    //    MyDoc.Close(ref missing,ref missing,ref missing);
    //    wordApp.Quit(ref missing,ref missing,ref missing);
    //    MyDoc = null;
    //    wordApp = null;

    //}
  
}
