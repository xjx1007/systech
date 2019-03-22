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


public partial class CG_Account_Bill_Sp_View : BasePage
{
    public string s_MyTable_Detail = "", s_Return = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.Lbl_Title.Text = "审批采购发票";
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            this.Lbl_ID.Text = s_ID;
            if (s_ID != "")
            {
                ShowInfo(s_ID);
            }
        }

    }

    private void ShowInfo(string s_ID)
    {

        KNet.BLL.CG_Account_Bill bll = new KNet.BLL.CG_Account_Bill();
        KNet.Model.CG_Account_Bill model = bll.GetModel(s_ID);
        try
        {
            this.Lbl_Code.Text = model.CAB_Code;

            this.Lbl_PayMent.Text = base.Base_GetBasicCodeName("300", model.CAB_PayMent);
            this.Lbl_CustomerName.Text = base.Base_GetSupplierName_Link(model.CAB_SuppNo);
            this.Lbl_DutyPerson.Text = base.Base_GetUserName(model.CAB_DutyPerson);
            this.Lbl_Remarks.Text = model.CAB_Remarks;
            this.Lbl_BillType.Text = base.Base_GetBasicCodeName("203", model.CAB_BillType.ToString());
            this.Lbl_CheckNo.Text = "<a target=\"_blank\" href=\"../Procure_Check/Procure_ShipCheck_CView.aspx?ID=" + model.CAB_CheckNo + "\">" + model.CAB_CheckNo + "</a>";
            try
            {
                this.Lbl_STime.Text = DateTime.Parse(model.CAB_Stime.ToString()).ToShortDateString();

            }
            catch { }
            this.Lbl_Money.Text = model.CAB_Money.ToString();
            this.Lbl_BillNumber.Text = model.CAB_FpCode;
            this.Lbl_Brokerage.Text = model.CAB_Brokerage;
            s_Return = "<table id=\"myTable\" width=\"100%\" border=\"0\" align=\"center\" cellpadding=\"2\" cellspacing=\"0\" class=\"ListDetails\" style=\"height: 28px\">";
            s_Return += "<tr valign=\"top\">";// "<td valign=\"top\" class=\"ListHead\" align=\"right\" nowrap><b>工具</b></td>";
            s_Return += "<td class=\"ListHead\" nowrap> <b>金额</b></td>";
            s_Return += "<td class=\"ListHead\" nowrap><b>超期天数</b></td>";
            s_Return += "<td class=\"ListHead\" nowrap><b>超期日期</b></td>";
            s_Return += "<td  class=\"ListHead\" nowrap><b>备注</b></td></tr>";
            KNet.BLL.CG_Account_Bill_Outimes Bll_OutTimes = new KNet.BLL.CG_Account_Bill_Outimes();
            DataTable Dtb_Table = Bll_OutTimes.GetList(" CABO_FID='" + model.CAB_ID + "'").Tables[0];
            if (Dtb_Table.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
                    s_Return += "<tr valign=\"top\">";
                    s_Return += "<td class=\"ListHeadDetails\" nowrap>" + Dtb_Table.Rows[i]["CABO_Money"].ToString() + "</td>";
                    s_Return += "<td class=\"ListHeadDetails\" nowrap>" + Dtb_Table.Rows[i]["CABO_Days"].ToString() + "</td>";
                    s_Return += "<td class=\"ListHeadDetails\" nowrap>" + DateTime.Parse(Dtb_Table.Rows[i]["CABO_OutTime"].ToString()).ToShortDateString() + "</td>";
                    s_Return += "<td  class=\"ListHeadDetails\" nowrap>" + Dtb_Table.Rows[i]["CABO_Remarks"].ToString() + "</tr>";
                }
            }
            s_Return += " </table>";
            if (model.CAB_CheckNo != "")
            {
                ShowCheckDetails(model.CAB_CheckNo);
            }
            else
            {
                string s_Details = ShowCheckDetails1(model.CAB_CheckNo, model.CAB_SuppNo, model.CAB_ID);
                string[] ss = s_Details.Split('|');
                this.Lbl_Detail.Text = ss[2];
            }
        }
        catch
        { }
    }

    public string ShowCheckDetails1(string s_CheckNo, string s_InSuppNo, string s_ID)
    {
        string s_SuppNo = "";
        string s_Return = "";
        string s_Type = "";
        string s_Money = "0";
        if (s_CheckNo != "")
        {

            KNet.BLL.Cg_Order_Checklist Bll = new KNet.BLL.Cg_Order_Checklist();
            KNet.Model.Cg_Order_Checklist Model = Bll.GetModel(s_CheckNo);
            s_CheckNo = Model.COC_Type;
            if (s_CheckNo == "1")
            {
                s_SuppNo = Model.COC_SuppNo;
            }
            else
            {
                //成品对账
                KNet.BLL.KNet_Sys_WareHouse Bll_WareHouse = new KNet.BLL.KNet_Sys_WareHouse();
                KNet.Model.KNet_Sys_WareHouse Model_WareHouse = Bll_WareHouse.GetModel(Model.COC_HouseNo);
                s_SuppNo = Model_WareHouse.SuppNo;
            }
        }
        else
        {
            s_SuppNo = s_InSuppNo;
        }
        KNet.BLL.Knet_Procure_Suppliers Bll_Supp = new KNet.BLL.Knet_Procure_Suppliers();
        KNet.Model.Knet_Procure_Suppliers Model_supp = Bll_Supp.GetModelB(s_SuppNo);
        s_Return = Model_supp.KPS_Days.ToString() + "|";

        if (s_CheckNo != "")
        {
            string s_Sql = "Select Sum(COD_Money) from Cg_Order_Checklist_Details where COD_CheckNo='" + s_CheckNo + "' ";
            this.BeginQuery(s_Sql);
            s_Money = this.QueryForReturn();
        }
        s_Return += s_Money + "|";
        string s_Sql1 = " 1=1 ";
        if (s_CheckNo != "")
        {
            s_Sql1 += " COD_CheckNo='" + s_CheckNo + "'";
        }
        else
        {
            if (s_InSuppNo != "")
            {
                //原材料和成品对账单
                s_Sql1 += "  and COD_CheckNO in (Select COC_Code from Cg_Order_Checklist where COC_SuppNo ='" + s_InSuppNo + "' union all Select COC_Code from Cg_Order_Checklist a join KNet_Sys_WareHouse b on a.Coc_HouseNo=b.HouseNO where b.SuppNo='" + s_InSuppNo + "')";

            }
        }
        if (s_ID == "")
        {
            s_Sql1 += " and COD_Code not in (select CABD_CheckDetailsID from CG_Account_Bill_Details a join CG_Account_Bill b on a.CABD_FID=b.CAB_ID  where CAB_SuppNo='" + s_SuppNo + "' )";
        }
        else
        {
            s_Sql1 += " and COD_Code  in (select CABD_CheckDetailsID from CG_Account_Bill_Details a join CG_Account_Bill b on a.CABD_FID=b.CAB_ID  where CAB_ID='" + s_ID + "' )";
        }
        KNet.BLL.Cg_Order_Checklist_Details Bll_Details = new KNet.BLL.Cg_Order_Checklist_Details();
        DataSet Dts_Table = Bll_Details.GetListJoinCGFP(s_Sql1);
        decimal d_Total = 0, d_Total1 = 0, d_Total2 = 0, d_Total3 = 0, d_Total4 = 0, d_Total5 = 0;
        if (Dts_Table.Tables[0].Rows.Count > 0)
        {
            s_Return += "";

            s_Return += " <table id=\"myTable\" width=\"100%\" border=\"0\" align=\"center\" cellpadding=\"2\" cellspacing=\"0\" class=\"ListDetails\" style=\"height: 28px\">";
            s_Return += "<tr valign=\"top\">";
            s_Return += "<td class=\"ListHead\" nowrap>";
            s_Return += "<b>选择</b></td>";
            s_Return += "<td class=\"ListHead\" nowrap>";
            s_Return += "<b>发生单号</b></td>";
            s_Return += "<td class=\"ListHead\" nowrap>";
            s_Return += "<b>订单号</b></td>";
            s_Return += "<td class=\"ListHead\" nowrap>";
            s_Return += "<b>发生日期</b></td>";
            s_Return += "<td class=\"ListHead\" nowrap>";
            s_Return += "<b>客户/供应商</b></td>";
            s_Return += "<td class=\"ListHead\" nowrap>";
            s_Return += "<b>产品</b></td>";
            s_Return += "<td class=\"ListHead\" nowrap>";
            s_Return += "<b>产品编码</b></td>";
            s_Return += "<td class=\"ListHead\" >";
            s_Return += "<b>版本号</b></td>";
            s_Return += "<td class=\"ListHead\" nowrap>";
            s_Return += "<b>数量</b></td>";
            s_Return += "<td class=\"ListHead\" nowrap>";
            s_Return += "<b>对账</b></td>";
            s_Return += "<td class=\"ListHead\" nowrap>";
            s_Return += "<b>备品</b></td>";
            s_Return += "<td class=\"ListHead\" nowrap>";
            s_Return += "<b>单价</b></td>";
            s_Return += "<td class=\"ListHead\" nowrap>";
            s_Return += "<b>加单</b></td>";
            s_Return += "<td class=\"ListHead\" nowrap>";
            s_Return += "<b>总金额</b></td>";
            s_Return += "<td class=\"ListHead\" nowrap>";
            s_Return += "<b>不含税金额</b></td>";
            s_Return += "<td class=\"ListHead\" nowrap>";
            s_Return += "<b>发票编号</b></td>";
            s_Return += "<td class=\"ListHead\" nowrap>";
            s_Return += "<b>备注</b></td>";
            s_Return += "</tr>";
            for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
            {
                string s_Check = "";
                string s_State = Dts_Table.Tables[0].Rows[i]["State"].ToString();
                s_Check = "checked";
                s_Return += " <tr>";
                s_Return += "<td class=\"ListHeadDetails\" align=\"center\">" + (i + 1).ToString() + "<input name=\"Tbx_CODID_" + i.ToString() + "\" type=\"text\" id=\"Tbx_CODID_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["COD_Code"].ToString() + " style=\"display: none\" /></td>";
                decimal d_KWD_NoTaxMoney = 0;
                KNet.BLL.KNet_WareHouse_DirectOutList_Details Bll_DirectOutDetails = new KNet.BLL.KNet_WareHouse_DirectOutList_Details();
                KNet.Model.KNet_WareHouse_DirectOutList_Details Model_DirectOutDetails = Bll_DirectOutDetails.GetModel(Dts_Table.Tables[0].Rows[i]["COD_DirectOutID"].ToString());
                if (Model_DirectOutDetails != null)
                {
                    KNet.BLL.KNet_WareHouse_DirectOutList Bll_DirectOut = new KNet.BLL.KNet_WareHouse_DirectOutList();
                    KNet.Model.KNet_WareHouse_DirectOutList Model_DirectOut = Bll_DirectOut.GetModelB(Model_DirectOutDetails.DirectOutNo);
                    s_Return += "<td class=\"ListHeadDetails\" align=\"center\"><input name=\"Tbx_DirectOutID_" + i.ToString() + "\" type=\"text\" id=\"Tbx_DirectOutID_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["COD_DirectOutID"].ToString() + " style=\"display: none\" />" + Model_DirectOutDetails.DirectOutNo + "</td>";
                    s_Return += "<td class=\"ListHeadDetails\" align=\"center\">" + Model_DirectOut.KWD_ShipNo + "</td>";
                    s_Return += "<td class=\"ListHeadDetails\" align=\"center\">" + DateTime.Parse(Model_DirectOut.DirectOutDateTime.ToString()).ToShortDateString() + "</td>";

                }
                KNet.BLL.Knet_Procure_WareHouseList_Details Bll_WareHouseDetails = new KNet.BLL.Knet_Procure_WareHouseList_Details();
                KNet.Model.Knet_Procure_WareHouseList_Details Model_WareHouseDetails = Bll_WareHouseDetails.GetModel(Dts_Table.Tables[0].Rows[i]["COD_DirectOutID"].ToString());
                if (Model_WareHouseDetails != null)
                {
                    KNet.BLL.Knet_Procure_WareHouseList Bll_WareHouse = new KNet.BLL.Knet_Procure_WareHouseList();
                    KNet.Model.Knet_Procure_WareHouseList Model_WareHouse = Bll_WareHouse.GetModelB(Model_WareHouseDetails.WareHouseNo);
                    s_Return += "<td class=\"ListHeadDetails\" align=\"center\"  nowrap><a href='../OrderInWareHouse/Knet_Procure_WareHouseList_View.aspx?ID=" + Model_WareHouseDetails.WareHouseNo + "' target=\"_blank\">" + Model_WareHouseDetails.WareHouseNo + "</td>";
                    s_Return += "<td class=\"ListHeadDetails\" align=\"center\"><input name=\"Tbx_DirectOutID_" + i.ToString() + "\" type=\"text\" id=\"Tbx_DirectOutID_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["COD_DirectOutID"].ToString() + " style=\"display: none\" />" + Model_WareHouse.OrderNo + "</td>";
                    s_Return += "<td class=\"ListHeadDetails\" align=\"center\">" + DateTime.Parse(Model_WareHouse.WareHouseDateTime.ToString()).ToShortDateString() + "</td>";
                    d_KWD_NoTaxMoney = Model_WareHouseDetails.KWP_NoTaxMoney;
                }
                string s_CustomerValue = base.Base_GetHouseName(Dts_Table.Tables[0].Rows[i]["COD_CustomerValue"].ToString());
                if (s_CustomerValue == "")
                {
                    s_CustomerValue = base.Base_GetCustomerName_Link(Dts_Table.Tables[0].Rows[i]["COD_CustomerValue"].ToString());
                }
                s_Return += "<td class=\"ListHeadDetails\" align=\"left\">" + s_CustomerValue + "</td>";
                s_Return += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetProdutsName_Link(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";

                s_Return += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetProductsCode(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";
                s_Return += "<td class=\"ListHeadDetails\" align=\"center\" nowrap><input name=\"Tbx_ProductsBarCode_" + i.ToString() + "\" type=\"text\" id=\"Tbx_ProductsBarCode_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString() + " style=\"display: none\" />" + base.Base_GetProductsEdition(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";
                s_Return += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber1(Dts_Table.Tables[0].Rows[i]["COD_CkNumber"].ToString(), 0) + "</td>";
                s_Return += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber1(Dts_Table.Tables[0].Rows[i]["COD_DzNumber"].ToString(), 0) + "</td>";
                s_Return += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber1(Dts_Table.Tables[0].Rows[i]["COD_BNumber"].ToString(), 0) + "</td>";
                s_Return += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber1(Dts_Table.Tables[0].Rows[i]["COD_Price"].ToString(), 3) + "</td>";
                s_Return += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber1(Dts_Table.Tables[0].Rows[i]["COD_HandPrice"].ToString(), 3) + "</td>";
                s_Return += "<td class=\"ListHeadDetails\" align=\"center\"><input name=\"Tbx_Money_" + i.ToString() + "\" type=\"text\" id=\"Tbx_Money_" + i.ToString() + "\" value=" + FormatNumber1(Dts_Table.Tables[0].Rows[i]["COD_Money"].ToString(), 3) + " style=\"display: none\" />" + FormatNumber1(Dts_Table.Tables[0].Rows[i]["COD_Money"].ToString(), 3) + "</td>";
                s_Return += "<td class=\"ListHeadDetails\" align=\"center\"><input name=\"Tbx_NoTaxMoney_" + i.ToString() + "\" type=\"text\" id=\"Tbx_NoTaxMoney_" + i.ToString() + "\" value=" + FormatNumber1(d_KWD_NoTaxMoney.ToString(), 3) + " /></td>";
                this.BeginQuery("Select CABD_FPCode from CG_Account_Bill_Details where CABD_CheckDetailsID='" + Dts_Table.Tables[0].Rows[i]["COD_Code"].ToString() + "'");
                this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">" + this.QueryForReturn() + "</td>";
                  
                s_Return += "<td class=\"ListHeadDetails\" align=\"center\">" + Dts_Table.Tables[0].Rows[i]["COD_Details"].ToString() + "</td>";
                s_Return += "</tr>";
                try
                {
                    d_Total += decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_CkNumber"].ToString());
                    d_Total1 += decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_DzNumber"].ToString());
                    d_Total2 += decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_BNumber"].ToString());
                    d_Total3 += decimal.Parse(FormatNumber1(Dts_Table.Tables[0].Rows[i]["COD_Money"].ToString(), 2));
                    d_Total4 += decimal.Parse(FormatNumber1(d_KWD_NoTaxMoney.ToString(), 2));
                }
                catch
                { }
            }
            s_Return += "<tr>";
            s_Return += "<td class=\"ListHeadDetails\" align=\"left\" colspan=8>合计：</td>";
            s_Return += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber1(d_Total.ToString(), 0) + "</td>";
            s_Return += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber1(d_Total1.ToString(), 0) + "</td>";
            s_Return += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber1(d_Total2.ToString(), 0) + "</td>";
            s_Return += "<td class=\"ListHeadDetails\" align=\"center\">&nbsp;</td>";
            s_Return += "<td class=\"ListHeadDetails\" align=\"center\">&nbsp;</td>";
            s_Return += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber1(d_Total3.ToString(), 2) + "</td>";
            s_Return += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber1(d_Total4.ToString(), 2) + "</td>";
            s_Return += "<td class=\"ListHeadDetails\" align=\"center\" colspan=\"2\">&nbsp;</td>";
            s_Return += "</tr>";
        }
        s_Return += "<input name=\"DetailsNum\" type=\"text\" id=\"DetailsNum\" value=" + Dts_Table.Tables[0].Rows.Count + " style=\"display: none\" />";
        s_Return += "</table>";
        return s_Return;
    }
    private void ShowCheckDetails(string s_CheckNo)
    {
        AdminloginMess AM = new AdminloginMess();
        if (s_CheckNo != "")
        {
            KNet.BLL.Cg_Order_Checklist Bll = new KNet.BLL.Cg_Order_Checklist();
            KNet.Model.Cg_Order_Checklist Model = Bll.GetModel(s_CheckNo);
            string s_SuppNo = "";
            if (Model.COC_Type == "1")
            {
                s_SuppNo = Model.COC_SuppNo;
            }
            else
            {
                //成品对账
                KNet.BLL.KNet_Sys_WareHouse Bll_WareHouse = new KNet.BLL.KNet_Sys_WareHouse();
                KNet.Model.KNet_Sys_WareHouse Model_WareHouse = Bll_WareHouse.GetModel(Model.COC_HouseNo);
                s_SuppNo = Model_WareHouse.SuppNo;
            }
            KNet.BLL.Knet_Procure_Suppliers Bll_Supp = new KNet.BLL.Knet_Procure_Suppliers();
            KNet.Model.Knet_Procure_Suppliers Model_supp = Bll_Supp.GetModelB(s_SuppNo);

            string s_Sql = "Select Sum(COD_Money) from Cg_Order_Checklist_Details where COD_CheckNo='" + s_CheckNo + "' ";
            this.BeginQuery(s_Sql);
            string s_Money = this.QueryForReturn();
            string s_Sql1 = " COD_CheckNo='" + s_CheckNo + "'";
            if (this.Lbl_ID.Text != "")
            {
                s_Sql1 += " and COD_Code in (select CABD_CheckDetailsID from CG_Account_Bill_Details  where CABD_FID='" + this.Lbl_ID.Text + "' )";
            }
            else
            {
                s_Sql1 += " and COD_Code not in (select CABD_CheckDetailsID from CG_Account_Bill_Details  where CABD_FID='" + this.Lbl_ID.Text + "' )";

            }
            KNet.BLL.Cg_Order_Checklist_Details Bll_Details = new KNet.BLL.Cg_Order_Checklist_Details();
            DataSet Dts_Table = Bll_Details.GetListJoinCGFP(s_Sql1);
            decimal d_Total = 0, d_Total1 = 0, d_Total2 = 0, d_Total3 = 0, d_Total4 = 0;
            if (Dts_Table.Tables[0].Rows.Count > 0)
            {
                this.Lbl_Detail.Text += " <table id=\"myTable\" width=\"100%\" border=\"0\" align=\"center\" cellpadding=\"2\" cellspacing=\"0\" class=\"ListDetails\" style=\"height: 28px\">";

                this.Lbl_Detail.Text += "<tr valign=\"top\">";
                this.Lbl_Detail.Text += "<td class=\"ListHead\" nowrap>";
                this.Lbl_Detail.Text += "<b>选择</b></td>";
                this.Lbl_Detail.Text += "<td class=\"ListHead\" nowrap>";
                this.Lbl_Detail.Text += "<b>发生单号</b></td>";
                this.Lbl_Detail.Text += "<td class=\"ListHead\" nowrap>";
                this.Lbl_Detail.Text += "<b>订单号</b></td>";
                this.Lbl_Detail.Text += "<td class=\"ListHead\" nowrap>";
                this.Lbl_Detail.Text += "<b>发生日期</b></td>";
                this.Lbl_Detail.Text += "<td class=\"ListHead\" nowrap>";
                this.Lbl_Detail.Text += "<b>客户/供应商</b></td>";
                this.Lbl_Detail.Text += "<td class=\"ListHead\" nowrap>";
                this.Lbl_Detail.Text += "<b>产品</b></td>";
                this.Lbl_Detail.Text += "<td class=\"ListHead\" nowrap>";
                this.Lbl_Detail.Text += "<b>产品编码</b></td>";
                this.Lbl_Detail.Text += "<td class=\"ListHead\" >";
                this.Lbl_Detail.Text += "<b>版本号</b></td>";
                this.Lbl_Detail.Text += "<td class=\"ListHead\" nowrap>";
                this.Lbl_Detail.Text += "<b>数量</b></td>";
                this.Lbl_Detail.Text += "<td class=\"ListHead\" nowrap>";
                this.Lbl_Detail.Text += "<b>对账</b></td>";
                this.Lbl_Detail.Text += "<td class=\"ListHead\" nowrap>";
                this.Lbl_Detail.Text += "<b>备品</b></td>";
                this.Lbl_Detail.Text += "<td class=\"ListHead\" nowrap>";
                this.Lbl_Detail.Text += "<b>单价</b></td>";
                this.Lbl_Detail.Text += "<td class=\"ListHead\" nowrap>";
                this.Lbl_Detail.Text += "<b>加单</b></td>";
                this.Lbl_Detail.Text += "<td class=\"ListHead\" nowrap>";
                this.Lbl_Detail.Text += "<b>总金额</b></td>";
                this.Lbl_Detail.Text += "<td class=\"ListHead\" nowrap>";
                this.Lbl_Detail.Text += "<b>不含税金额</b></td>";
                this.Lbl_Detail.Text += "<td class=\"ListHead\" nowrap>";
                this.Lbl_Detail.Text += "<b>发票编号</b></td>";
                this.Lbl_Detail.Text += "<td class=\"ListHead\" nowrap>";
                this.Lbl_Detail.Text += "<b>备注</b></td>";
                this.Lbl_Detail.Text += "</tr>";
                this.Lbl_Detail.Text += "";
                for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                {
                    decimal d_KWD_NoTaxMoney = 0;
                    string s_Check = "";
                    string s_State = Dts_Table.Tables[0].Rows[i]["State"].ToString();
                    if (s_State == "1")
                    {
                        s_Check = "checked";
                    }
                    this.Lbl_Detail.Text += " <tr>";
                    this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">" + (i + 1).ToString() + "<input name=\"Tbx_CODID_" + i.ToString() + "\" type=\"text\" id=\"Tbx_CODID_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["COD_Code"].ToString() + " style=\"display: none\" /></td>";

                    if (Model.COC_Type == "0")//成品对账
                    {
                        KNet.BLL.KNet_WareHouse_DirectOutList_Details Bll_DirectOutDetails = new KNet.BLL.KNet_WareHouse_DirectOutList_Details();
                        KNet.Model.KNet_WareHouse_DirectOutList_Details Model_DirectOutDetails = Bll_DirectOutDetails.GetModel(Dts_Table.Tables[0].Rows[i]["COD_DirectOutID"].ToString());
                        if (Model_DirectOutDetails != null)
                        {
                            KNet.BLL.KNet_WareHouse_DirectOutList Bll_DirectOut = new KNet.BLL.KNet_WareHouse_DirectOutList();
                            KNet.Model.KNet_WareHouse_DirectOutList Model_DirectOut = Bll_DirectOut.GetModelB(Model_DirectOutDetails.DirectOutNo);
                            this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\"><input name=\"Tbx_DirectOutID_" + i.ToString() + "\" type=\"text\" id=\"Tbx_DirectOutID_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["COD_DirectOutID"].ToString() + " style=\"display: none\" />" + Model_DirectOutDetails.DirectOutNo + "</td>";
                            this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">" + Model_DirectOut.KWD_ShipNo + "</td>";
                            this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">" + DateTime.Parse(Model_DirectOut.DirectOutDateTime.ToString()).ToShortDateString() + "</td>";
                        }
                    }
                    else
                    {
                        KNet.BLL.Knet_Procure_WareHouseList_Details Bll_WareHouseDetails = new KNet.BLL.Knet_Procure_WareHouseList_Details();
                        KNet.Model.Knet_Procure_WareHouseList_Details Model_WareHouseDetails = Bll_WareHouseDetails.GetModel(Dts_Table.Tables[0].Rows[i]["COD_DirectOutID"].ToString());
                        if (Model_WareHouseDetails != null)
                        {
                            KNet.BLL.Knet_Procure_WareHouseList Bll_WareHouse = new KNet.BLL.Knet_Procure_WareHouseList();
                            KNet.Model.Knet_Procure_WareHouseList Model_WareHouse = Bll_WareHouse.GetModelB(Model_WareHouseDetails.WareHouseNo);
                            this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\"  nowrap><a href='../OrderInWareHouse/Knet_Procure_WareHouseList_View.aspx?ID=" + Model_WareHouseDetails.WareHouseNo + "' target=\"_blank\">" + Model_WareHouseDetails.WareHouseNo + "</td>";
                            this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\"><input name=\"Tbx_DirectOutID_" + i.ToString() + "\" type=\"text\" id=\"Tbx_DirectOutID_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["COD_DirectOutID"].ToString() + " style=\"display: none\" />" + Model_WareHouse.OrderNo + "</td>";
                            this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">" + DateTime.Parse(Model_WareHouse.WareHouseDateTime.ToString()).ToShortDateString() + "</td>";
                            d_KWD_NoTaxMoney = Model_WareHouseDetails.KWP_NoTaxMoney;

                        }
                    }
                    decimal d_Money = decimal.Parse(FormatNumber1(Dts_Table.Tables[0].Rows[i]["COD_Money"].ToString(), 3));
                    if (d_KWD_NoTaxMoney == 0)
                    {
                        d_KWD_NoTaxMoney = decimal.Parse(base.FormatNumber1(Convert.ToString(d_Money / Decimal.Parse("1.16")), 2));
                    }
                    string s_CustomerValue = base.Base_GetHouseName(Dts_Table.Tables[0].Rows[i]["COD_CustomerValue"].ToString());
                    if (s_CustomerValue == "")
                    {
                        s_CustomerValue = base.Base_GetCustomerName_Link(Dts_Table.Tables[0].Rows[i]["COD_CustomerValue"].ToString());
                    }
                    this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"left\">" + s_CustomerValue + "</td>";
                    this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"left\">" + base.Base_GetProdutsName_Link(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";

                    this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"left\">" + base.Base_GetProductsCode(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";
                    this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"left\" nowrap><input name=\"Tbx_ProductsBarCode_" + i.ToString() + "\" type=\"text\" id=\"Tbx_ProductsBarCode_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString() + " style=\"display: none\" />" + base.Base_GetProductsEdition(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";
                    this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber1(Dts_Table.Tables[0].Rows[i]["COD_CkNumber"].ToString(), 0) + "</td>";
                    this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber1(Dts_Table.Tables[0].Rows[i]["COD_DzNumber"].ToString(), 0) + "</td>";
                    this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber1(Dts_Table.Tables[0].Rows[i]["COD_BNumber"].ToString(), 0) + "</td>";
                    this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber1(Dts_Table.Tables[0].Rows[i]["COD_Price"].ToString(), 3) + "</td>";
                    this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber1(Dts_Table.Tables[0].Rows[i]["COD_HandPrice"].ToString(), 3) + "</td>";
                    this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"right\"><input name=\"Tbx_Money_" + i.ToString() + "\" type=\"text\" id=\"Tbx_Money_" + i.ToString() + "\" value=" + FormatNumber1(Dts_Table.Tables[0].Rows[i]["COD_Money"].ToString(), 3) + " style=\"display: none\" />" + FormatNumber1(Dts_Table.Tables[0].Rows[i]["COD_Money"].ToString(), 3) + "</td>";
                    this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"right\"><input name=\"Tbx_NoTaxMoney_" + i.ToString() + "\" type=\"text\" id=\"Tbx_NoTaxMoney_" + i.ToString() + "\" value=" + FormatNumber1(d_KWD_NoTaxMoney.ToString(), 3) + "   class=\"detailedViewTextBox\" /></td>";

                    this.BeginQuery("Select CABD_FPCode from CG_Account_Bill_Details where CABD_CheckDetailsID='" + Dts_Table.Tables[0].Rows[i]["COD_Code"].ToString() + "'");
                    this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">" + this.QueryForReturn() + "</td>";
                    this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"left\">" + Dts_Table.Tables[0].Rows[i]["COD_Details"].ToString() + "</td>";
                    this.Lbl_Detail.Text += "</tr>";
                    try
                    {
                        d_Total += decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_CkNumber"].ToString());
                        d_Total1 += decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_DzNumber"].ToString());
                        d_Total2 += decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_BNumber"].ToString());
                        d_Total3 += decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_Money"].ToString());
                        d_Total4 += decimal.Parse(FormatNumber1(d_KWD_NoTaxMoney.ToString(), 3));
                    }
                    catch
                    { }
                }
                this.Lbl_Detail.Text += "<tr>";
                this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"left\" colspan=8>合计：</td>";
                this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber1(d_Total.ToString(), 0) + "</td>";
                this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber1(d_Total1.ToString(), 0) + "</td>";
                this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber1(d_Total2.ToString(), 0) + "</td>";
                this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">&nbsp;</td>";
                this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">&nbsp;</td>";
                this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber1(d_Total3.ToString(), 2) + "</td>";
                this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber1(d_Total4.ToString(), 3) + "</td>";
                this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\" colspan=\"2\">&nbsp;</td>";
                this.Lbl_Detail.Text += "</tr>";
            }
            this.Lbl_Detail.Text += "<input name=\"DetailsNum\" type=\"text\" id=\"DetailsNum\" value=" + Dts_Table.Tables[0].Rows.Count + " style=\"display: none\" />";
            this.Lbl_Detail.Text += "</table>";
        }
    }
    protected void Btn_SaveOnClick(object sender, EventArgs e)
    {
        try
        {
            AdminloginMess LogAM = new AdminloginMess();
            int i_Num=int.Parse(Request.Form["DetailsNum"]==null?"0":Request.Form["DetailsNum"].ToString());
            for (int i = 0; i < i_Num; i++)
            {
                string s_NoTaxMoney = Request.Form["Tbx_NoTaxMoney_" + i.ToString() + ""] == null ? "0" : Request.Form["Tbx_NoTaxMoney_" + i.ToString() + ""].ToString();
                string s_ID = Request.Form["Tbx_DirectOutID_" + i.ToString() + ""] == null ? "" : Request.Form["Tbx_DirectOutID_" + i.ToString() + ""].ToString();

                KNet.BLL.Knet_Procure_WareHouseList_Details bll = new KNet.BLL.Knet_Procure_WareHouseList_Details();
                KNet.Model.Knet_Procure_WareHouseList_Details model = bll.GetModel(s_ID);
                if (model !=null)
                {
                    model.ID = s_ID;
                    model.KWP_NoTaxMoney = decimal.Parse(s_NoTaxMoney);
                    model.KWP_NoTaxLag = model.KWP_NoTaxLag == null ? 0 : model.KWP_NoTaxLag + 1;
                    try
                    {
                        if (bll.UpdateTaxMoney(model))
                        {
                            LogAM.Add_Logs("单据--->原材料入库--->不含税金额  更新  操作成功！ID：" + ID);
                        }
                        string s_Sql = "Update CG_Account_Bill set CAB_State='1' where CAB_ID='" + this.Lbl_ID.Text + "'";
                        if (DbHelperSQL.ExecuteSql(s_Sql) > 0)
                        {
                            LogAM.Add_Logs("采购--->发票登记--->发票登记审批 操作成功！ID：" + ID);
                        }
                        KNet.BLL.CG_Account_Bill_Details Bll = new KNet.BLL.CG_Account_Bill_Details();
                        DataSet Dts_Table = Bll.GetList(" CABD_FID='" + this.Lbl_ID.Text + "'");
                        if (LogAM.CheckLogin("财务审核出库单") == true)
                        {
                            string s_DetailsID = Dts_Table.Tables[0].Rows[i]["CABD_WareHouseDetailsID"].ToString();
                            KNet.BLL.Knet_Procure_WareHouseList bll_WareHouseList = new KNet.BLL.Knet_Procure_WareHouseList();
                            KNet.Model.Knet_Procure_WareHouseList Model = bll_WareHouseList.GetModelB(model.WareHouseNo);
                            string s_CheckYN = "3";
                            if (Model.WareHouseCheckYN == 1)
                            {
                                s_CheckYN = "2";
                            }
                            else
                            {
                                s_CheckYN = "1";
                            }
                            string sql = " update Knet_Procure_WareHouseList  set WareHouseCheckYN=" + s_CheckYN + ",WareHouseCheckStaffNo ='" + LogAM.KNet_StaffNo + "'  where  WareHouseNo='" + model.WareHouseNo + "' ";
                            DbHelperSQL.ExecuteSql(sql);
                        }
                        AlertAndRedirect("发票审批成功！", "CG_Account_Bill_List.aspx");
                    }
                    catch
                    {
                        // throw;
                        Response.Write("<script>alert('不含税金额 更新 失败！');history.back(-1);</script>");
                        Response.End();
                    }

                }
                else
                {
                    string s_Sql = "Update CG_Account_Bill set CAB_State='1' where CAB_ID='" + this.Lbl_ID.Text + "'";
                    if (DbHelperSQL.ExecuteSql(s_Sql) > 0)
                    {
                        LogAM.Add_Logs("采购--->发票登记--->发票登记审批 操作成功！ID：" + ID);
                    }
                    AlertAndRedirect("发票审批成功！", "CG_Account_Bill_List.aspx");

                }
            }
        }
        catch{}
    }
}
