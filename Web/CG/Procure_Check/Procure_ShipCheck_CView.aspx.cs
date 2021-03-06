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


public partial class Web_Sales_Procure_ShipCheck_CView : BasePage
{
    public string s_MyTable_Detail = "", s_OrderStyle = "", s_DetailsStyle = "", s_Details = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
        string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
        this.Tbx_ID.Text = s_ID;
        if (s_ID != "")
        {
            ShowInfo(s_ID);
        }
        this.Lbl_Title.Text = "查看采购对账单";
        if (s_Type == "1")
        {
            s_OrderStyle = "class=\"dvtUnSelectedCell\"";
            s_DetailsStyle = "class=\"dvtSelectedCell\"";
            Pan_Order.Visible = false;
            Pan_Detail.Visible = true;
            Table_Btn.Visible = false;
        }
        else
        {
            s_DetailsStyle = "class=\"dvtUnSelectedCell\"";
            s_OrderStyle = "class=\"dvtSelectedCell\"";
            Pan_Order.Visible = true;
            Pan_Detail.Visible = false;
            Table_Btn.Visible = true;
        }
        this.Lbl_Link.Text = "<a href=\"../Bill/CG_Account_Bill_Add.aspx?CheckNo=" + s_ID + "\" target=\"_blank\"  class=\"webMnu\">创建发票</a>";
    }

    private void ShowInfo(string s_ID)
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.BLL.Cg_Order_Checklist BLL = new KNet.BLL.Cg_Order_Checklist();
        KNet.Model.Cg_Order_Checklist Model = BLL.GetModel(s_ID);
        this.Lbl_Code.Text = Model.COC_Code;
        try
        {
            this.Lbl_Stime.Text = DateTime.Parse(Model.COC_Stime.ToString()).ToShortDateString();
        }
        catch { }
        try
        {

            this.Lbl_PreTime.Text = DateTime.Parse(Model.COC_BeginDate.ToString()).ToShortDateString() + "-" + DateTime.Parse(Model.COC_EndDate.ToString()).ToShortDateString();
        }
        catch { }
        try
        {
            Lbl_Type.Text = base.Base_GetBasicCodeName("144", Model.COC_Type);
        }
        catch { }
        try
        {
            Lbl_Supp.Text = base.Base_GetSupplierName_Link(Model.COC_SuppNo);
        }
        catch { }

        try
        {
            this.Lbl_House.Text = base.Base_GetHouseName(Model.COC_HouseNo);
        }
        catch { }
        try
        {
            this.Lbl_CheckYN.Text = base.Base_GetBasicCodeName("132", Model.COC_CheckYN.ToString());
        }
        catch { }
        try
        {
            this.Lbl_Check.Text = base.Base_GetUserName(Model.COC_CheckPerson.ToString()) + "<br/>审核时间：" + Model.COC_CheckTime.ToString();
        }
        catch { }

        this.Lbl_IsPayMent.Text = base.Base_GetBasicCodeName("153", Model.COC_IsPayMent.ToString());
        if (AM.YNAuthority("采购对账审批") == true)
        {
            this.btn_Chcek.Visible = true;
        }
        else
        {
            this.btn_Chcek.Visible = false;

        }
        if (AM.KNet_StaffDepart == "")
        {
            this.btn_Chcek.Enabled = false;
        }
        else
        {
            this.btn_Chcek.Enabled = true;
        }

        if (Model.COC_CheckYN == 1)
        {
            btn_Chcek.Text = "反审批";
        }
        else
        {
            btn_Chcek.Text = "审批";
        }

        //this.CommentList2.CommentFID = Model.COC_Code;
        //this.CommentList2.CommentType = 5;

        //this.CommentList1.CommentFID = Model.COC_Code;
        //this.CommentList1.CommentType = "ProcureCheck";

        this.Lbl_Remarks.Text = Model.COC_Details;
        KNet.BLL.Cg_Order_Checklist_Details Bll_Details = new KNet.BLL.Cg_Order_Checklist_Details();
        DataSet Dts_Table = Bll_Details.GetList(" COD_CheckNo='" + s_ID + "' order by COD_ProductsBarCode,COD_Price,COD_HandPrice,COD_Code ");
        // AllocateCheckYN!='0' and
        //string sql =
        //              " select b.ID,HouseNo_int as HouseNo_int,a.HouseNo  as HouseNo1,b.ProductsBarCode,allocateAmount,allocateunitPrice,allocateTotalNet,a.SystemDateTimes,AllocateStaffNo,a.AllocateNo,a.AllocateDateTime,a.KWA_OrderNo, a.HouseNo ,a.HouseNo_int ,Allocate_WwPrice,Allocate_WwMoney,AllocateCheckYN FROM KNet_WareHouse_AllocateList a join KNet_WareHouse_AllocateList_Details b on a.AllocateNo = b.AllocateNo  join dbo.KNet_Sys_WareHouse AS c ON c.HouseNo = a.HouseNo_int  join dbo.KNet_Sys_WareHouse AS d ON d.HouseNo = a.HouseNo join KNET_sys_Products e on e.ProductsBarCode = b.ProductsBarCode where  a.HouseNo=(select  HouseNo from KNet_Sys_WareHouse where  SuppNo='" + Model.COC_SuppNo + "') and AllocateDateTime>='" + DateTime.Parse(Model.COC_BeginDate.ToString()).ToShortDateString() + "' and AllocateDateTime<='" + DateTime.Parse(Model.COC_EndDate.ToString()).ToShortDateString() + "'";
        //this.BeginQuery(sql);
        //DataTable Dtb_Table1 = this.QueryForDataTable();

        decimal d_MaxMoney = 100000;
        int i_MaxRow = 8;
        if (Model.COC_SuppNo != "")
        {
            try
            {
                KNet.BLL.Knet_Procure_Suppliers Bll_Supp = new KNet.BLL.Knet_Procure_Suppliers();
                KNet.Model.Knet_Procure_Suppliers Model_Supp = Bll_Supp.GetModel(Model.COC_SuppNo);
                d_MaxMoney = Model_Supp.KPS_KPMaxMoney;
                i_MaxRow = Model_Supp.KPS_MaxRow;
            }
            catch
            { }
        }
        else
        {
            try
            {
                KNet.BLL.KNet_Sys_WareHouse Bll_WareHouse = new KNet.BLL.KNet_Sys_WareHouse();
                KNet.Model.KNet_Sys_WareHouse Model_WareHouse = Bll_WareHouse.GetModel(Model.COC_HouseNo);

                KNet.BLL.Knet_Procure_Suppliers Bll_Supp = new KNet.BLL.Knet_Procure_Suppliers();
                KNet.Model.Knet_Procure_Suppliers Model_Supp = Bll_Supp.GetModel(Model_WareHouse.SuppNo);
                d_MaxMoney = Model_Supp.KPS_KPMaxMoney;
                i_MaxRow = Model_Supp.KPS_MaxRow;
            }
            catch { }
        }
        this.Lbl_KpDetails.Text = "  最大开票金额：<font color=red>" + d_MaxMoney.ToString() + "</font>";
        this.Lbl_KpDetails.Text += "   单张最大开票行数：<font color=red>" + i_MaxRow.ToString() + "</font>";
        decimal d_Total = 0, d_Total1 = 0, d_Total2 = 0, d_Total3 = 0, d_TotalPrice = 0, d_Total4 = 0, d_TotalHandPrice = 0, d_FPNumber = 0;
        decimal dd_Total = 0, dd_Total1 = 0, dd_Total2 = 0, dd_Total3 = 0, dd_Total4 = 0, dd_Total5 = 0, dd_Total6 = 0, dd_TotalPrice = 0, dd_TotalHandPrice = 0, dd_TotalTotal = 0;
        decimal ddd_Total = 0, ddd_Total1 = 0, ddd_Total2 = 0, ddd_Total3 = 0;

        int i_Row = 1;
        int i_FPNum = 1;
        string BFNumber = "";
        string BFPrice = "";

        if (Model.COC_Type == "0")//成品对账
        {
            s_Details += " <tr ><td class=\"ListHeadLeft\" align=left colspan=\"11\"><b>成品发票1</b></td>\n</tr>";
            s_Details += " <tr ><td class=\"ListHead\" >项次</td>\n";
            s_Details += "<td class=\"ListHead\" align=center>料号</td>\n";
            s_Details += "<td class=\"ListHead\" align=center>货物名称</td>\n";
            s_Details += "<td class=\"ListHead\" align=center>规格型号</td>\n";
            s_Details += "<td class=\"ListHead\" align=center>单位</td>\n";
            s_Details += "<td class=\"ListHead\">数量</td>\n";
            s_Details += "<td class=\"ListHead\">单价</td>\n";
            s_Details += "<td class=\"ListHead\">金额</td>\n";
            s_Details += "<td class=\"ListHead\">税率</td>\n";
            s_Details += "<td class=\"ListHead\"  colspan=2>税额</td>\n</tr >";
        }
        else if (Model.COC_Type == "1")
        {

            s_Details += " <tr ><td class=\"ListHeadLeft\" align=left colspan=\"11\"><b>原材料发票1</b></td>\n</tr>";
            s_Details += " <tr ><td class=\"ListHead\" >项次</td>\n";
            s_Details += "<td class=\"ListHead\" align=center>料号</td>\n";
            s_Details += "<td class=\"ListHead\" align=center>货物名称</td>\n";
            s_Details += "<td class=\"ListHead\" align=center>规格型号</td>\n";
            s_Details += "<td class=\"ListHead\" align=center>单位</td>\n";
            s_Details += "<td class=\"ListHead\">数量</td>\n";
            s_Details += "<td class=\"ListHead\">单价</td>\n";
            s_Details += "<td class=\"ListHead\">金额</td>\n";
            s_Details += "<td class=\"ListHead\">税率</td>\n";
            s_Details += "<td class=\"ListHead\"  colspan=2>税额</td>\n</tr >";
        }
        else if (Model.COC_Type == "2")
        {

            s_Details += " <tr ><td class=\"ListHeadLeft\" align=left colspan=\"16\"><b>加工费发票1</b></td>\n</tr>";
            s_Details += " <tr ><td class=\"ListHead\" >项次</td>\n";
            s_Details += "<td class=\"ListHead\" align=center>料号</td>\n";
            s_Details += "<td class=\"ListHead\" align=center>货物名称</td>\n";
            s_Details += "<td class=\"ListHead\" align=center>规格型号</td>\n";
            s_Details += "<td class=\"ListHead\" align=center>单位</td>\n";
            s_Details += "<td class=\"ListHead\">订单数量</td>\n";
            s_Details += "<td class=\"ListHead\">送货数量</td>\n";
            s_Details += "<td class=\"ListHead\">入成品库数量</td>\n";
            s_Details += "<td class=\"ListHead\">报废数量</td>\n";
            s_Details += "<td class=\"ListHead\">报废单价</td>\n";
            s_Details += "<td class=\"ListHead\">加工单价</td>\n";
            s_Details += "<td class=\"ListHead\">扣除金额</td>\n";
            s_Details += "<td class=\"ListHead\">额外金额</td>\n";
            s_Details += "<td class=\"ListHead\">应付金额</td>\n";
            s_Details += "<td class=\"ListHead\">税率</td>\n";
            s_Details += "<td class=\"ListHead\"  colspan=2>税额</td>\n</tr >";
        }
        if (Dts_Table.Tables[0].Rows.Count > 0)
        {
            s_MyTable_Detail += "";
            for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
            {
                decimal d_Price = decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_Price"].ToString() == "" ? "0" : Dts_Table.Tables[0].Rows[i]["COD_Price"].ToString());
                decimal d_HandPrice = decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_HandPrice"].ToString() == "" ? "0" : Dts_Table.Tables[0].Rows[i]["COD_HandPrice"].ToString());
                decimal d_Number = decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_DzNumber"].ToString() == "" ? "0" : Dts_Table.Tables[0].Rows[i]["COD_DzNumber"].ToString());
                decimal d_BNumber = decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_BNumber"].ToString() == "" ? "0" : Dts_Table.Tables[0].Rows[i]["COD_BNumber"].ToString());
                decimal d_BFNumber = decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_BFNumber"].ToString() == "" ? "0" : Dts_Table.Tables[0].Rows[i]["COD_BFNumber"].ToString());//报废数量
                decimal d_BFPrice = decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_BFPrice"].ToString() == "" ? "0" : Dts_Table.Tables[0].Rows[i]["COD_BFPrice"].ToString());//报废单价
                s_MyTable_Detail += " <tr>";
                if (Model.COC_Type == "0")//成品对账
                {
                    KNet.BLL.KNet_WareHouse_DirectOutList_Details Bll_DirectOutDetails = new KNet.BLL.KNet_WareHouse_DirectOutList_Details();
                    KNet.Model.KNet_WareHouse_DirectOutList_Details Model_DirectOutDetails = Bll_DirectOutDetails.GetModel(Dts_Table.Tables[0].Rows[i]["COD_DirectOutID"].ToString());
                    if (Model_DirectOutDetails != null)
                    {
                        KNet.BLL.KNet_WareHouse_DirectOutList Bll_DirectOut = new KNet.BLL.KNet_WareHouse_DirectOutList();
                        KNet.Model.KNet_WareHouse_DirectOutList Model_DirectOut = Bll_DirectOut.GetModelB(Model_DirectOutDetails.DirectOutNo);
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + Model_DirectOutDetails.DirectOutNo + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + Model_DirectOut.KWD_ShipNo + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + DateTime.Parse(Model_DirectOut.DirectOutDateTime.ToString()).ToShortDateString() + "</td>";
                    }

                }
                else if (Model.COC_Type == "1")//原材料
                {
                    KNet.BLL.Knet_Procure_WareHouseList_Details Bll_WareHouseDetails = new KNet.BLL.Knet_Procure_WareHouseList_Details();
                    KNet.Model.Knet_Procure_WareHouseList_Details Model_WareHouseDetails = Bll_WareHouseDetails.GetModel(Dts_Table.Tables[0].Rows[i]["COD_DirectOutID"].ToString());
                    if (Model_WareHouseDetails != null)
                    {
                        KNet.BLL.Knet_Procure_WareHouseList Bll_WareHouse = new KNet.BLL.Knet_Procure_WareHouseList();
                        KNet.Model.Knet_Procure_WareHouseList Model_WareHouse = Bll_WareHouse.GetModelB(Model_WareHouseDetails.WareHouseNo);
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\"  nowrap><a href='../OrderInWareHouse/Knet_Procure_WareHouseList_View.aspx?ID=" + Model_WareHouseDetails.WareHouseNo + "' target=\"_blank\">" + Model_WareHouseDetails.WareHouseNo + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + Model_WareHouse.OrderNo + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + DateTime.Parse(Model_WareHouse.WareHouseDateTime.ToString()).ToShortDateString() + "</td>";
                    }
                }
                else if (Model.COC_Type == "2")//加工费
                {
                    //KNet.BLL.Knet_Procure_WareHouseList_Details Bll_WareHouseDetails = new KNet.BLL.Knet_Procure_WareHouseList_Details();
                    //KNet.Model.Knet_Procure_WareHouseList_Details Model_WareHouseDetails = Bll_WareHouseDetails.GetModel(Dts_Table.Tables[0].Rows[i]["COD_DirectOutID"].ToString());


                    
                        //KNet.BLL.Knet_Procure_WareHouseList Bll_WareHouse = new KNet.BLL.Knet_Procure_WareHouseList();
                        //KNet.Model.Knet_Procure_WareHouseList Model_WareHouse = Bll_WareHouse.GetModelB(Model_WareHouseDetails.WareHouseNo);
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + Dts_Table.Tables[0].Rows[i]["COD_Code"].ToString() + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\"  nowrap><a href='/Web/Cg/Order/Knet_Procure_OpenBilling_View_ForSc.aspx?ID=" + Dts_Table.Tables[0].Rows[i]["COD_DirectOutID"].ToString() + " ' target=\"_blank\">" + Dts_Table.Tables[0].Rows[i]["COD_DirectOutID"].ToString() + "</td>";

                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + DateTime.Now.ToShortDateString() + "</td>";
                   
                }
                string s_CustomerValue = base.Base_GetHouseName(Dts_Table.Tables[0].Rows[i]["COD_CustomerValue"].ToString());
                if (s_CustomerValue == "")
                {
                    s_CustomerValue = base.Base_GetCustomerName_Link(Dts_Table.Tables[0].Rows[i]["COD_CustomerValue"].ToString());
                }
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"left\">" + s_CustomerValue + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetProdutsName_Link(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";

                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetProductsCode(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";

                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\" nowrap>" + base.Base_GetProductsEdition(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["COD_CkNumber"].ToString(), 0) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["COD_DzNumber"].ToString(), 0) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["COD_BNumber"].ToString(), 0) + "</td>";
                if (Dts_Table.Tables[0].Rows[i]["COD_BFNumber"].ToString() == "")
                {
                    BFNumber = "0";
                }
                if (Dts_Table.Tables[0].Rows[i]["COD_BFNumber"].ToString() == "")
                {
                    BFPrice = "0";
                }
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + Dts_Table.Tables[0].Rows[i]["COD_RKNumber"].ToString() + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + d_BFNumber + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + d_BFPrice + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["COD_Price"].ToString(), 3) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" +
                                    FormatNumber(Dts_Table.Tables[0].Rows[i]["COD_HandPrice"].ToString(), 3) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["COD_EWMoney"].ToString(), 3) + "</td>";//额外扣除金额

               
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["COD_EWFMoney"].ToString(), 3) + "</td>";//额外应付金额

                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["COD_Money"].ToString(), 3) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + Dts_Table.Tables[0].Rows[i]["COD_Details"].ToString() + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + IsFP(Dts_Table.Tables[0].Rows[i]["COD_Code"].ToString()) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + IsQr(Dts_Table.Tables[0].Rows[i]["COD_Code"].ToString()) + "</td>";


                s_MyTable_Detail += "</tr>";
                try
                {
                    d_Total += decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_CkNumber"].ToString());
                    d_Total1 += decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_DzNumber"].ToString());
                    d_Total2 += decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_BNumber"].ToString());
                    d_Total3 += decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_Money"].ToString());
                    d_Total4 += d_BFNumber;//报废数量
                    d_TotalPrice += (d_Number + d_BNumber) * d_Price;
                    d_TotalHandPrice += (d_Number + d_BNumber) * d_HandPrice;

                    dd_Total += decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_CkNumber"].ToString());
                    if (Model.COC_Type == "0")
                    {
                        dd_Total5 += (d_Number + d_BNumber);
                        dd_Total1 += (d_Number + d_BNumber);
                    }
                    if (Model.COC_Type == "2")
                    {
                        dd_Total5= (d_Number + d_BNumber);
                        dd_Total1 += (d_Number + d_BNumber - d_BFNumber);
                    }
                    else
                    {
                        dd_Total5 += d_Number;
                        dd_Total1 += d_Number;
                    }
                    string COD_RKNumber = Dts_Table.Tables[0].Rows[i]["COD_BNumber"].ToString();
                    if (COD_RKNumber == "")
                    {
                        COD_RKNumber = "0";
                    }
                    dd_Total2 += decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_BNumber"].ToString());
                    dd_Total3 += decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_Money"].ToString());
                    dd_Total6 += decimal.Parse(COD_RKNumber);
                    dd_TotalPrice += (d_Number + d_BNumber) * d_Price;
                    dd_TotalHandPrice += (d_Number + d_BNumber) * d_HandPrice;
                    dd_TotalTotal = dd_TotalPrice + dd_TotalHandPrice;
                    if (d_Price != 0)
                    {
                        d_FPNumber += (d_Number + d_BNumber);
                    }
                }
                catch
                { }
                decimal d_TaxPrice = 0;
                decimal d_FPMoney = 0;
                decimal d_TaxMoney = 0, d_NowPrice = 0, d_NowMoney = 0;

                if (Model.COC_Type == "0")
                {
                    d_NowPrice = d_HandPrice;
                    d_NowMoney = (dd_Total1 * d_HandPrice);
                    d_TaxPrice = decimal.Parse(base.FormatNumber1(Convert.ToString(d_HandPrice / decimal.Parse("1.16")), 10));
                    d_FPMoney = decimal.Parse(base.FormatNumber1(Convert.ToString(d_TaxPrice * dd_Total1), 2));
                    d_TaxMoney = dd_TotalHandPrice - d_FPMoney;
                }
                if (Model.COC_Type == "2")
                {
                    d_NowPrice = d_HandPrice;
                    d_NowMoney = decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_Money"].ToString());
                    d_TaxPrice = decimal.Parse(base.FormatNumber1(Convert.ToString(d_HandPrice / decimal.Parse("1.16")), 10));
                    d_FPMoney = decimal.Parse(base.FormatNumber1(Convert.ToString(d_TaxPrice * dd_Total1), 2));
                    d_TaxMoney = dd_TotalHandPrice - d_FPMoney;
                }
                else
                {
                    d_NowMoney = dd_Total3;
                    d_NowPrice = d_Price;
                    d_TaxPrice = decimal.Parse(base.FormatNumber1(Convert.ToString(d_Price / decimal.Parse("1.16")), 10));
                    d_FPMoney = decimal.Parse(base.FormatNumber1(Convert.ToString(d_TaxPrice * dd_Total1), 2));
                    d_TaxMoney = dd_Total3 - d_FPMoney;
                }
                if ((i >= 0) && (i < Dts_Table.Tables[0].Rows.Count - 1))
                {
                    string s_Price = Dts_Table.Tables[0].Rows[i]["COD_Price"].ToString();
                    string s_NextPrice = Dts_Table.Tables[0].Rows[i + 1]["COD_Price"].ToString();
                    string s_HandPrice = Dts_Table.Tables[0].Rows[i]["COD_HandPrice"].ToString();
                    string s_NextHandPrice = Dts_Table.Tables[0].Rows[i + 1]["COD_HandPrice"].ToString();
                    if ((Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString() != Dts_Table.Tables[0].Rows[i + 1]["COD_ProductsBarCode"].ToString()) || (s_Price != s_NextPrice) || (s_HandPrice != s_NextHandPrice))
                    {


                        s_MyTable_Detail += "<tr style=\"background-color:#0ff\">";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"left\" colspan=5>小计：</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"left\">" + base.Base_GetProductsCode(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"left\">" + base.Base_GetProductsEdition(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";

                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber1(dd_Total.ToString(), 0) + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber1(dd_Total1.ToString(), 0) + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber1(dd_Total2.ToString(), 0) + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber1(dd_Total6.ToString(), 0) + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber1(dd_Total2.ToString(), 0) + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber1(dd_Total2.ToString(), 0) + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber1(d_Price.ToString(), 2) + "</td>";

                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber1(dd_Total2.ToString(), 2) + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">&nbsp</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber1(dd_TotalPrice.ToString(), 2) + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\" colspan=3>&nbsp;</td>";
                        s_MyTable_Detail += "</tr>";


                        //发票信息
                        if (Model.COC_Type == "2")
                        {
                            //发票信息
                            s_Details += "<tr >";
                            s_Details += "<td class=\"ListHeadDetails\" align=\"left\" >" + i_Row.ToString() + "</td>";
                            s_Details += "<td class='ListHeadDetails'align=center >" + base.Base_GetProductsCode(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>\n";

                            if (Model.COC_Type == "0")//成品对账
                            {
                                s_Details += "<td class=\"ListHeadDetails\" align=\"left\"> 成品加工费</td>";
                            }
                            else
                            {
                                s_Details += "<td class=\"ListHeadDetails\" align=\"left\">" + base.Base_GetProdutsName(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";
                            }

                            s_Details += "<td class=\"ListHeadDetails\" align=\"left\">" + base.Base_GetProductsEdition(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";
                            s_Details += "<td class=\"ListHeadDetails\" align=\"left\">" + base.Base_GetUnitsName(base.Base_GetProductsUnits(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString())) + "</td>";

                            s_Details += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber1(dd_Total5.ToString(), 0) + "</td>";//应发数量
                            s_Details += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber1(dd_Total1.ToString(), 0) + "</td>";//实发数量
                            s_Details += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber1(dd_Total6.ToString(), 0) + "</td>";//实发数量
                            s_Details += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber1(d_Total4.ToString(), 0) + "</td>";//报废数量
                            s_Details += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber1(d_BFPrice.ToString(), 0) + "</td>";//报废单价
                            s_Details += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber(d_NowPrice.ToString(), 4) + "</td>";
                            s_Details += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["COD_EWMoney"].ToString(), 4) + "</td>";//额外扣除金额
                            s_Details += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["COD_EWFMoney"].ToString(), 4) + "</td>";//额外付款金额
                            s_Details += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber1(d_NowMoney.ToString(), 2) + "</td>";
                            s_Details += "<td class=\"ListHeadDetails\" align=\"center\">16%</td>";
                            s_Details += "<td class=\"ListHeadDetails\" align=\"right\"  colspan=2>" + FormatNumber1(d_TaxMoney.ToString(), 2) + "</td>";
                            s_Details += "</tr>";
                        }
                        else
                        {
                            s_Details += "<tr >";
                            s_Details += "<td class=\"ListHeadDetails\" align=\"left\" >" + i_Row.ToString() + "</td>";
                            s_Details += "<td class='ListHeadDetails'align=center >" + base.Base_GetProductsCode(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>\n";
                            if (Model.COC_Type == "0")//成品对账
                            {
                                s_Details += "<td class=\"ListHeadDetails\" align=\"left\"> 成品加工费</td>";
                            }
                            else
                            {
                                s_Details += "<td class=\"ListHeadDetails\" align=\"left\">" + base.Base_GetProdutsName(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";
                            }

                            s_Details += "<td class=\"ListHeadDetails\" align=\"left\">" + base.Base_GetProductsEdition(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";
                            s_Details += "<td class=\"ListHeadDetails\" align=\"left\">" + base.Base_GetUnitsName(base.Base_GetProductsUnits(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString())) + "</td>";

                            s_Details += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber1(dd_Total1.ToString(), 0) + "</td>";

                            s_Details += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber(d_NowPrice.ToString(), 4) + "</td>";
                            s_Details += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber1(d_NowMoney.ToString(), 2) + "</td>";

                            s_Details += "<td class=\"ListHeadDetails\" align=\"center\">16%</td>";
                            s_Details += "<td class=\"ListHeadDetails\" align=\"right\"  colspan=2>" + FormatNumber1(d_TaxMoney.ToString(), 2) + "</td>";

                            s_Details += "</tr>";
                        }
                        ddd_Total += dd_Total1;
                        ddd_Total1 += d_NowMoney;
                        ddd_Total2 += d_TaxMoney;
                        dd_Total = 0;
                        dd_Total1 = 0;
                        dd_Total2 = 0;
                        dd_Total3 = 0;
                        dd_Total6 = 0;
                        ddd_Total3 += dd_Total5;
                        dd_Total4 = 0;
                        dd_TotalPrice = 0;
                        dd_TotalHandPrice = 0;

                        if ((i_Row % i_MaxRow == 0) || (ddd_Total1 % d_MaxMoney == 0))
                        {
                            i_FPNum = i_FPNum + 1;
                            if (Model.COC_Type == "0")//成品对账
                            {

                                s_Details += " <tr >\n";
                                s_Details += "<td class='ListHeadDetails'align=center  colspan='5'>合计:</td>\n";
                                s_Details += "<td class='ListHeadDetails' align=right  >&nbsp;" + base.FormatNumber1(ddd_Total.ToString(), 0) + "</td>\n";
                                s_Details += "<td class='ListHeadDetails' align=right >&nbsp;</td>\n";//money
                                s_Details += "<td class='ListHeadDetails' align=right  >&nbsp;" + base.FormatNumber1(ddd_Total1.ToString(), 2) + "</td>\n";
                                s_Details += "<td class='ListHeadDetails' align=right >&nbsp;</td>\n";//money
                                s_Details += "<td class='ListHeadDetails' align=right  colspan=2>&nbsp;" + base.FormatNumber1(ddd_Total2.ToString(), 2) + "</td>\n";
                                ddd_Total = 0;
                                ddd_Total1 = 0;
                                ddd_Total2 = 0;
                                s_Details += " </tr>";
                                s_Details += " <tr ><td class=\"ListHeadLeft\" align=left colspan=\"11\"><b>加工费发票" + i_FPNum + "</b></td>\n</tr>";
                                s_Details += " <tr ><td class=\"ListHead\" >项次</td>\n";
                                s_Details += "<td class=\"ListHead\" align=center>料号</td>\n";
                                s_Details += "<td class=\"ListHead\" align=center>货物名称</td>\n";
                                s_Details += "<td class=\"ListHead\" align=center>规格型号</td>\n";
                                s_Details += "<td class=\"ListHead\" align=center>单位</td>\n";
                                s_Details += "<td class=\"ListHead\">数量</td>\n";
                                s_Details += "<td class=\"ListHead\">单价</td>\n";
                                s_Details += "<td class=\"ListHead\">金额</td>\n";
                                s_Details += "<td class=\"ListHead\">税率</td>\n";
                                s_Details += "<td class=\"ListHead\"  colspan=2>税额</td>\n</tr >";
                            }
                            else if (Model.COC_Type == "1")//原材料
                            {
                                s_Details += " <tr >\n";
                                s_Details += "<td class='ListHeadDetails'align=center  colspan='5'>合计:</td>\n";
                                s_Details += "<td class='ListHeadDetails' align=right  >&nbsp;" + base.FormatNumber1(ddd_Total.ToString(), 0) + "</td>\n";
                                s_Details += "<td class='ListHeadDetails' align=right >&nbsp;</td>\n";//money

                                s_Details += "<td class='ListHeadDetails' align=right  >&nbsp;" + base.FormatNumber1(ddd_Total1.ToString(), 2) + "</td>\n";
                                s_Details += "<td class='ListHeadDetails' align=right >&nbsp;</td>\n";//money
                                s_Details += "<td class='ListHeadDetails' align=right  colspan=2>&nbsp;" + base.FormatNumber1(ddd_Total2.ToString(), 2) + "</td>\n";
                                s_Details += " </tr>";
                                ddd_Total = 0;
                                ddd_Total1 = 0;
                                ddd_Total2 = 0;
                                s_Details += " <tr ><td class=\"ListHeadLeft\" align=left colspan=\"11\"><b>原材料发票" + i_FPNum + "</b></td>\n</tr>";
                                s_Details += " <tr ><td class=\"ListHead\" >项次</td>\n";
                                s_Details += "<td class=\"ListHead\" align=center>料号</td>\n";
                                s_Details += "<td class=\"ListHead\" align=center>货物名称</td>\n";
                                s_Details += "<td class=\"ListHead\" align=center>规格型号</td>\n";
                                s_Details += "<td class=\"ListHead\" align=center>单位</td>\n";
                                s_Details += "<td class=\"ListHead\">数量</td>\n";
                                s_Details += "<td class=\"ListHead\">加工费单价</td>\n";
                                s_Details += "<td class=\"ListHead\">金额</td>\n";
                                s_Details += "<td class=\"ListHead\">税率</td>\n";
                                s_Details += "<td class=\"ListHead\"  colspan=2>税额</td>\n</tr >";

                            }
                            else if (Model.COC_Type == "2")
                            {

                                s_Details += " <tr >\n";
                                s_Details += "<td class='ListHeadDetails'align=center  colspan='5'>合计:</td>\n";
                                s_Details += "<td class='ListHeadDetails' align=right  >&nbsp;" + base.FormatNumber1(ddd_Total3.ToString(), 0) + "</td>\n";//应发数量总和
                                s_Details += "<td class='ListHeadDetails' align=right  >&nbsp;" + base.FormatNumber1(ddd_Total.ToString(), 0) + "</td>\n";//实发数量总和
                                s_Details += "<td class='ListHeadDetails' align=right >&nbsp;</td>\n";//money
                                s_Details += "<td class='ListHeadDetails' align=right >&nbsp;</td>\n";//money
                                s_Details += "<td class='ListHeadDetails' align=right >&nbsp;</td>\n";//money
                                s_Details += "<td class='ListHeadDetails' align=right >&nbsp;</td>\n";//money

                                s_Details += "<td class='ListHeadDetails' align=right  >&nbsp;" + base.FormatNumber1(ddd_Total1.ToString(), 2) + "</td>\n";
                                s_Details += "<td class='ListHeadDetails' align=right >&nbsp;</td>\n";//money
                                s_Details += "<td class='ListHeadDetails' align=right  colspan=4>&nbsp;" + base.FormatNumber1(ddd_Total2.ToString(), 2) + "</td>\n";
                                s_Details += " </tr>";
                                ddd_Total = 0;
                                ddd_Total1 = 0;
                                ddd_Total2 = 0;
                                s_Details += " <tr ><td class=\"ListHeadLeft\" align=left colspan=\"13\"><b>加工费发票" + i_FPNum + "</b></td>\n</tr>";
                                s_Details += " <tr ><td class=\"ListHead\" >项次</td>\n";
                                s_Details += "<td class=\"ListHead\" align=center>料号</td>\n";
                                s_Details += "<td class=\"ListHead\" align=center>货物名称</td>\n";
                                s_Details += "<td class=\"ListHead\" align=center>规格型号</td>\n";
                                s_Details += "<td class=\"ListHead\" align=center>单位</td>\n";
                                s_Details += "<td class=\"ListHead\">订单数量</td>\n";
                                s_Details += "<td class=\"ListHead\">送货数量</td>\n";
                                s_Details += "<td class=\"ListHead\">入成品库数量</td>\n";
                                s_Details += "<td class=\"ListHead\">报废数量</td>\n";
                                s_Details += "<td class=\"ListHead\">报废单价</td>\n";
                                s_Details += "<td class=\"ListHead\">加工单价</td>\n";
                                s_Details += "<td class=\"ListHead\">扣除金额</td>\n";
                                s_Details += "<td class=\"ListHead\">额外付款</td>\n";
                                s_Details += "<td class=\"ListHead\">应付金额</td>\n";
                                s_Details += "<td class=\"ListHead\">税率</td>\n";
                                s_Details += "<td class=\"ListHead\"  colspan=2>税额</td>\n</tr >";
                            }

                        }
                        i_Row++;

                    }
                }
                else if (i == Dts_Table.Tables[0].Rows.Count - 1)
                {
                    s_MyTable_Detail += "<tr style=\"background-color:#0ff\">";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"left\" colspan=5>小计：</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"left\">" + base.Base_GetProductsCode(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"left\">" + base.Base_GetProductsEdition(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber1(dd_Total.ToString(), 0) + "</td>";

                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber1(dd_Total1.ToString(), 0) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber1(dd_Total2.ToString(), 0) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">&nbsp;</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">&nbsp;</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">&nbsp;</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">&nbsp;</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">&nbsp;</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">&nbsp;</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">&nbsp;</td>";
                    //s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber1(dd_Total3.ToString(), 2) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber1(dd_Total3.ToString(), 2) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\" colspan=4>&nbsp;</td>";
                    s_MyTable_Detail += "</tr>";
                    //发票信息
                    if (Model.COC_Type == "2")
                    {
                        s_Details += "<tr >";
                        s_Details += "<td class=\"ListHeadDetails\" align=\"left\" >" + i_Row.ToString() + "</td>";
                        s_Details += "<td class='ListHeadDetails'align=center >" + base.Base_GetProductsCode(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>\n";
                        if (Model.COC_Type == "0")//成品对账
                        {
                            s_Details += "<td class=\"ListHeadDetails\" align=\"left\"> 成品加工费</td>";
                        }
                        else
                        {
                            s_Details += "<td class=\"ListHeadDetails\" align=\"left\">" + base.Base_GetProdutsName(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";
                        }

                        s_Details += "<td class=\"ListHeadDetails\" align=\"left\">" + base.Base_GetProductsEdition(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";
                        s_Details += "<td class=\"ListHeadDetails\" align=\"left\">" + base.Base_GetUnitsName(base.Base_GetProductsUnits(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString())) + "</td>";

                        //s_Return += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber1(dd_Total1.ToString(), 0) + "</td>";
                        s_Details += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber1(dd_Total5.ToString(), 0) + "</td>";//应发数量
                        s_Details += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber1(dd_Total1.ToString(), 0) + "</td>";//实发数量
                        s_Details += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber1(dd_Total6.ToString(), 0) + "</td>";//报废数量
                        s_Details += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber1(d_Total4.ToString(), 0) + "</td>";//报废数量
                        s_Details += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber1(d_BFPrice.ToString(), 0) + "</td>";//报废单价
                        s_Details += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber(d_NowPrice.ToString(), 4) + "</td>";
                        s_Details+="<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["COD_EWMoney"].ToString(), 4) + "</td>";//额外扣除金额
                        s_Details += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["COD_EWFMoney"].ToString(), 4) + "</td>";//额外付款金额
                        s_Details += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber1(d_NowMoney.ToString(), 2) + "</td>";

                        s_Details += "<td class=\"ListHeadDetails\" align=\"center\">16%</td>";
                        s_Details += "<td class=\"ListHeadDetails\" align=\"right\"  colspan=2>" + FormatNumber1(d_TaxMoney.ToString(), 2) + "</td>";

                        s_Details += "</tr>";
                    }
                    else
                    {
                        s_Details += "<tr >";
                        s_Details += "<td class=\"ListHeadDetails\" align=\"left\" >" + i_Row.ToString() + "</td>";
                        s_Details += "<td class='ListHeadDetails'align=center >" + base.Base_GetProductsCode(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>\n";
                        if (Model.COC_Type == "0")//成品对账
                        {
                            s_Details += "<td class=\"ListHeadDetails\" align=\"left\"> 成品加工费</td>";
                        }
                        else
                        {
                            s_Details += "<td class=\"ListHeadDetails\" align=\"left\">" + base.Base_GetProdutsName(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";
                        }

                        s_Details += "<td class=\"ListHeadDetails\" align=\"left\">" + base.Base_GetProductsEdition(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";
                        s_Details += "<td class=\"ListHeadDetails\" align=\"left\">" + base.Base_GetUnitsName(base.Base_GetProductsUnits(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString())) + "</td>";

                        s_Details += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber1(dd_Total1.ToString(), 0) + "</td>";

                        s_Details += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber(d_NowPrice.ToString(), 4) + "</td>";
                        s_Details += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber1(d_NowMoney.ToString(), 2) + "</td>";

                        s_Details += "<td class=\"ListHeadDetails\" align=\"center\">16%</td>";
                        s_Details += "<td class=\"ListHeadDetails\" align=\"right\"  colspan=2>" + FormatNumber1(d_TaxMoney.ToString(), 2) + "</td>";

                        s_Details += "</tr>";
                    }

                    i_Row++;
                    ddd_Total += dd_Total1;
                    ddd_Total1 += d_NowMoney;
                    ddd_Total2 += d_TaxMoney;
                    dd_Total = 0;
                    dd_Total1 = 0;
                    dd_Total2 = 0;
                    dd_Total3 = 0;
                    dd_Total4 = 0;
                }
            }

            if (Model.COC_Type == "2")
            {
                s_Details += " <tr >\n";
                s_Details += "<td class='ListHeadDetails'align=center  colspan='5'>合计:</td>\n";
                s_Details += "<td class='ListHeadDetails' align=right >&nbsp;</td>\n";
                s_Details += "<td class='ListHeadDetails' align=right  >&nbsp;" + base.FormatNumber1(ddd_Total.ToString(), 0) + "</td>\n";
                s_Details += "<td class='ListHeadDetails' align=right >&nbsp;</td>\n";//money
                s_Details += "<td class='ListHeadDetails' align=right >&nbsp;</td>\n";//money
                s_Details += "<td class='ListHeadDetails' align=right >&nbsp;</td>\n";//money
                s_Details += "<td class='ListHeadDetails' align=right >&nbsp;</td>\n";//money
                s_Details += "<td class='ListHeadDetails' align=right >&nbsp;</td>\n";//money
                s_Details += "<td class='ListHeadDetails' align=right >&nbsp;</td>\n";//money
                s_Details += "<td class='ListHeadDetails' align=right  >&nbsp;" + base.FormatNumber1(ddd_Total1.ToString(), 2) + "</td>\n";

                s_Details += "<td class='ListHeadDetails' align=right  colspan=3>&nbsp;" + base.FormatNumber1(ddd_Total2.ToString(), 2) + "</td>\n";
                s_Details += " </tr>";
            }
            else
            {
                s_Details += " <tr >\n";
                s_Details += "<td class='ListHeadDetails'align=center  colspan='5'>合计:</td>\n";
                s_Details += "<td class='ListHeadDetails' align=right  >&nbsp;" + base.FormatNumber1(ddd_Total.ToString(), 0) + "</td>\n";
                s_Details += "<td class='ListHeadDetails' align=right >&nbsp;</td>\n";//money

                s_Details += "<td class='ListHeadDetails' align=right  >&nbsp;" + base.FormatNumber1(ddd_Total1.ToString(), 2) + "</td>\n";
                s_Details += "<td class='ListHeadDetails' align=right >&nbsp;</td>\n";//money
                s_Details += "<td class='ListHeadDetails' align=right  colspan=4>&nbsp;" + base.FormatNumber1(ddd_Total2.ToString(), 2) + "</td>\n";
                s_Details += " </tr>";
            }
            s_MyTable_Detail += "<tr>";
            s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"left\" colspan=7>合计：</td>";
            s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_Total.ToString(), 0) + "</td>";
            s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_Total1.ToString(), 0) + "</td>";
            s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_Total2.ToString(), 0) + "</td>";
            s_MyTable_Detail += "<td class='ListHeadDetails' align=right >&nbsp;</td>\n";//money
            s_MyTable_Detail += "<td class='ListHeadDetails' align=right >&nbsp;</td>\n";//money
            s_MyTable_Detail += "<td class='ListHeadDetails' align=right >&nbsp;</td>\n";//money
            s_MyTable_Detail += "<td class='ListHeadDetails' align=right >&nbsp;</td>\n";//money
            s_MyTable_Detail += "<td class='ListHeadDetails' align=right >&nbsp;</td>\n";//money
            s_MyTable_Detail += "<td class='ListHeadDetails' align=right >&nbsp;</td>\n";//money
            s_MyTable_Detail += "<td class='ListHeadDetails' align=right >&nbsp;</td>\n";//money
            //s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_TotalPrice.ToString(), 2) + "</td>";
            //s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_TotalHandPrice.ToString(), 2) + "</td>";
            s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_Total3.ToString(), 2) + "</td>";
            s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\" colspan=\"3\">&nbsp;</td>";
            s_MyTable_Detail += "</tr>";
            if ((d_FPNumber != 0) && (Model.COC_Type == "0"))
            {
                decimal d_TotalFPNumber = 0, d_TotalFPNet = 0, d_TotalFPPrice = 0, d_TotalTaxPrice = 0;
                string s_Sql = "Select *  from KNet_Sys_Products where ProductsType='M150920074726199' order by ProductsName";
                this.BeginQuery(s_Sql);
                this.QueryForDataTable();
                DataTable Dtb_Table = this.Dtb_Result;
                s_Details += " <tr ><td class=\"ListHeadLeft\" align=left colspan=\"11\"><b>材料费发票1</b></td>\n</tr>";
                s_Details += " <tr ><td class=\"ListHead\" >项次</td>\n";
                s_Details += "<td class=\"ListHead\" align=center>料号</td>\n";
                s_Details += "<td class=\"ListHead\" align=center>品名</td>\n";
                s_Details += "<td class=\"ListHead\" align=center>规格</td>\n";
                s_Details += "<td class=\"ListHead\" align=center>单位</td>\n";
                s_Details += "<td class=\"ListHead\">标准用量</td>\n";
                s_Details += "<td class=\"ListHead\">出库数量</td>\n";
                s_Details += "<td class=\"ListHead\">单价</td>\n";
                s_Details += "<td class=\"ListHead\">金额</td>\n";
                s_Details += "<td class=\"ListHead\">税率</td>\n";
                s_Details += "<td class=\"ListHead\">税额</td>\n</tr >";
                if (Dtb_Table.Rows.Count > 0)
                {
                    for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                    {
                        s_Details += " <tr >\n";
                        s_Details += "<td class='ListHeadDetails'align=center >" + (i + 1).ToString() + "</td>\n";
                        s_Details += "<td class='ListHeadDetails'align=center >" + base.Base_GetProductsCode(Dtb_Table.Rows[i]["ProductsBarCode"].ToString()) + "</td>\n";
                        s_Details += "<td class='ListHeadDetails'align=center >" + base.Base_GetProdutsName(Dtb_Table.Rows[i]["ProductsBarCode"].ToString()) + "</td>\n";
                        s_Details += "<td  class='ListHeadDetails'align=center >" + base.Base_GetProductsEdition(Dtb_Table.Rows[i]["ProductsBarCode"].ToString()) + "</td>\n";
                        s_Details += "<td class='ListHeadDetails' align=center >" + base.Base_GetUnitsName(base.Base_GetProductsUnits(Dtb_Table.Rows[i]["ProductsBarCode"].ToString())) + "</td>\n";
                        decimal d_Num = 1;
                        if (Dtb_Table.Rows[i]["ProductsBarCode"].ToString() == "D1304021636173814")//如果是电阻
                        {
                            s_Details += "<td  class='ListHeadDetails' align=right  >5</td>\n";
                            d_Num = 5;
                        }
                        else
                        {
                            s_Details += "<td  class='ListHeadDetails' align=right  >1</td>\n";
                            d_Num = 1;
                        }
                        decimal d_Number1 = 0;
                        d_Number1 = d_FPNumber * d_Num;
                        s_Details += "<td  class='ListHeadDetails' align=right  >&nbsp;" + base.FormatNumber1(d_Number1.ToString(), 0) + "</td>\n";
                        decimal d_ProductsCostPrice = decimal.Parse(Dtb_Table.Rows[i]["ProductsCostPrice"].ToString());

                        s_Details += "<td  class='ListHeadDetails' align=right  >&nbsp;" + base.FormatNumber1(d_ProductsCostPrice.ToString(), 2) + "</td>\n";
                        decimal d_TotalMoney = d_Number1 * d_ProductsCostPrice;
                        s_Details += "<td  class='ListHeadDetails' align=right  >&nbsp;" + base.FormatNumber1(d_TotalMoney.ToString(), 2) + "</td>\n";
                        s_Details += "<td  class='ListHeadDetails' align=right >&nbsp;16%</td>\n";

                        decimal d_TaxPrice = decimal.Parse(base.FormatNumber1(Convert.ToString(d_ProductsCostPrice / decimal.Parse("1.16")), 10));
                        decimal d_FPMoney = decimal.Parse(base.FormatNumber1(Convert.ToString(d_TaxPrice * d_Number1), 2));
                        decimal d_TaxMoney = d_TotalMoney - d_FPMoney;

                        s_Details += "<td  class='ListHeadDetails' align=right >" + base.FormatNumber1(d_TaxMoney.ToString(), 2) + "</td>\n";
                        s_Details += " </tr>";
                        try
                        {
                            d_TotalFPNumber += d_Number1;
                            d_TotalFPNet += d_TotalMoney;
                            d_TotalFPPrice += d_Num * d_ProductsCostPrice;
                            d_TotalTaxPrice += d_TaxMoney;
                        }
                        catch
                        {
                        }
                    }
                    s_Details += " <tr >\n";
                    s_Details += "<td class='ListHeadDetails'align=center  colspan='6'>合计:</td>\n";
                    s_Details += "<td class='ListHeadDetails' align=right  >&nbsp;" + base.FormatNumber1(d_TotalFPNumber.ToString(), 0) + "</td>\n";
                    s_Details += "<td class='ListHeadDetails' align=right >&nbsp;" + base.FormatNumber1(d_TotalFPPrice.ToString(), 2) + "</td>\n";//money
                    s_Details += "<td class='ListHeadDetails' align=right  >&nbsp;" + base.FormatNumber1(d_TotalFPNet.ToString(), 2) + "</td>\n";
                    s_Details += "<td class='ListHeadDetails' align=right >&nbsp;</td>\n";//money
                    s_Details += "<td class='ListHeadDetails' align=right  >&nbsp;" + base.FormatNumber1(d_TotalTaxPrice.ToString(), 2) + "</td>\n";
                    s_Details += " </tr>";
                }
            }

        }
        //先查供应商单张开票金额，单张最多行数。


        string s_SqlWhere = "  CAB_CheckNo='" + Model.COC_Code + "'";
        s_SqlWhere += " order by CAB_MTime desc ";
        KNet.BLL.CG_Account_Bill bll = new KNet.BLL.CG_Account_Bill();
        DataSet ds = bll.GetList(s_SqlWhere);
        this.MyGridView1.DataSource = ds;
        MyGridView1.DataKeyNames = new string[] { "CAB_ID" };
        MyGridView1.DataBind();

        try
        {
            KNet.BLL.PB_Basic_Mail bll_Mail = new KNet.BLL.PB_Basic_Mail();
            string s_Sql = "PBM_Del=0 and PBM_FID='" + Model.COC_Code + "' and PBM_Type=4 ";
            s_Sql += " Order by PBM_CTime desc";
            DataSet ds_Mail = bll_Mail.GetList(s_Sql);
            MyGridView3.DataSource = ds_Mail;
            MyGridView3.DataKeyNames = new string[] { "PBM_ID" };
            MyGridView3.DataBind();
        }
        catch
        { }

    }

    public string GetState(string s_State)
    {
        if (s_State == "2")
        {
            return "<font color=red>失败</font>";
        }
        else if (s_State == "1")
        {
            return "<font color=green>成功</font>";
        }
        else
        {

            return "<font color=blue>待发</font>";
        }
    }
    private string IsFP(string s_CABD_CheckDetailsID)
    {
        string b_Return = "<font color=green>未开</font>";
        try
        {
            this.BeginQuery("Select CABD_ID from CG_Account_Bill_Details where CABD_CheckDetailsID='" + s_CABD_CheckDetailsID + "' ");
            string s_ID = this.QueryForReturn();
            if (s_ID != "")
            {
                b_Return = "<font color=red>已开</font>";
            }
        }
        catch { }
        return b_Return;
    }

    private string IsQr(string s_CABD_CheckDetailsID)
    {
        string b_Return = "<font color=red>未确认</font>";
        try
        {
            this.BeginQuery("Select KPO_QRState from Knet_Procure_WareHouseList a join Knet_Procure_WareHouseList_Details b where b.ID='" + s_CABD_CheckDetailsID + "' ");
            string s_ID = this.QueryForReturn();
            if (s_ID != "1")
            {
                b_Return = "已确认";
            }
        }
        catch { }
        return b_Return;
    }
    protected void btn_Chcek_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        if (btn_Chcek.Text == "审批")
        {
            string DoSql = "update Cg_Order_Checklist  set COC_CheckYN=1,COC_CheckPerson ='" + AM.KNet_StaffNo + "',COC_CheckTime='" + DateTime.Now.ToString() + "'  where  COC_Code='" + this.Tbx_ID.Text + "' ";
            DbHelperSQL.ExecuteSql(DoSql);
            btn_Chcek.Text = "反审批";
        }
        else
        {
            string DoSql = "update Cg_Order_Checklist  set COC_CheckYN=0,COC_CheckPerson ='',COC_CheckTime=''  where  COC_Code='" + this.Tbx_ID.Text + "' ";
            DbHelperSQL.ExecuteSql(DoSql);
            btn_Chcek.Text = "审批";
        }
        Alert("审批成功！");
    }

    protected void Button4_Click(object sender, EventArgs e)
    {

        KNet.BLL.Cg_Order_Checklist Bll = new KNet.BLL.Cg_Order_Checklist();
        KNet.Model.Cg_Order_Checklist Model = Bll.GetModel(this.Tbx_ID.Text);
        string JSD = "CG/Procure_Check/Procure_ShipCheck_View.aspx?ID=" + Model.COC_Code + "";
        if (base.HtmlToPdf1(JSD, Server.MapPath("PDF"), this.Tbx_ID.Text))
        {
            Alert("生成成功！");
        }
    }


    protected void Button5_Click(object sender, EventArgs e)
    {
        KNet.BLL.Cg_Order_Checklist Bll = new KNet.BLL.Cg_Order_Checklist();
        KNet.Model.Cg_Order_Checklist Model = Bll.GetModel(this.Tbx_ID.Text);
        string JSD = "CG/Procure_Check/Procure_ShipCheck_View.aspx?ID=" + Model.COC_Code + "";

        string s_url1 = "Excel/" + Model.COC_Code + ".xls";
        string s_URL = Server.MapPath(s_url1);
        //  Excel.CreateExcelByXml(Page, null, "对账单名称", s_url1, false);
        if (base.HtmlToPdf1(JSD, Server.MapPath("PDF"), this.Tbx_ID.Text))
        {
            Alert("生成成功！");
        }
    }


}
