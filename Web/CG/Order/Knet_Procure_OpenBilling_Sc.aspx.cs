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

public partial class Web_Sales_Knet_Procure_OpenBilling_View : BasePage
{
    public string s_MyTable_Detail = "", s_OrderStyle = "", s_DetailsStyle = "", s_Details1 = "", s_Details2 = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        KNet.BLL.Knet_Procure_OrdersList bll = new KNet.BLL.Knet_Procure_OrdersList();
        this.Lbl_Title.Text = "生成采购订单";
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("查看采购单") == false)
            {
                BasePage.AlertAndRedirect("您未登陆系统或已超过，请重新登陆系统!", "Default.aspx");
            }
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            this.Lbl_Title.Text += "(" + s_ID + ")";
            this.Tbx_ID.Text = s_ID;
            if (s_ID != "")
            {
                base.Base_EMail(this.Ddl_SendEmail);
                ShowInfo(s_ID);

            }
            if (s_Type == "1")
            {
                s_OrderStyle = "class=\"dvtUnSelectedCell\"";
                s_DetailsStyle = "class=\"dvtSelectedCell\"";
                Pan_Order.Visible = false;
                Table_Btn.Visible = false;
                string SqlWhere = " ParentOrderNo='" + s_ID + "' order by SYstemDateTimes desc";
                DataSet ds = bll.GetList(SqlWhere);
            }
            else
            {
                s_DetailsStyle = "class=\"dvtUnSelectedCell\"";
                s_OrderStyle = "class=\"dvtSelectedCell\"";
                Pan_Order.Visible = true;
                Table_Btn.Visible = true;
            }
            if (AM.KNet_StaffName != "项洲")
            {
                this.BeginQuery("Select Sum(isnull(cast( OrderCheckYN as int),0)) from Knet_Procure_OrdersList where ParentOrderNo='" + this.Tbx_ID.Text + "'");
                string s_Return = this.QueryForReturn();
                s_Return = s_Return == "" ? "0" : s_Return.ToString();
                if (int.Parse(s_Return) > 0)
                {
                    //this.Button1.Enabled = false;
                }
                Button3.Visible = false;
                Button4.Visible = false;
            }
            else
            {
                Button3.Visible = true;
                Button4.Visible = true;
            }
            //模具和供应商
            this.Button1.Attributes.Add("onclick", "return confirm('生成将清除原有生成的采购子订单，是否继续？')");

        }

        ////如果订单或者子订单已审核不能重新生成订单
        //    DataSet Dts_HavCheck = bll.GetList(" (OrderCheckYN='1'  and ParentOrderNo='" + this.Tbx_ID.Text + "') or OrderNo in (Select ParentOrderNo From Knet_Procure_OrdersList where OrderCheckYN='1' and ParentOrderNo='" + this.Tbx_ID.Text + "' )  ");
        //    if (Dts_HavCheck.Tables[0].Rows.Count > 0)
        //    {
        //        this.Button5.Enabled = false;
        //    }
    }


    private void ShowInfo(string s_ID)
    {
        KNet.BLL.Knet_Procure_OrdersList BLL = new KNet.BLL.Knet_Procure_OrdersList();
        KNet.Model.Knet_Procure_OrdersList Model = BLL.GetModelB(s_ID);
        this.Lbl_Code.Text = Model.OrderNo;
        this.Lbl_Stime.Text = DateTime.Parse(Model.OrderDateTime.ToString()).ToShortDateString();
        this.Lbl_PreTime.Text = DateTime.Parse(Model.OrderPreToDate.ToString()).ToShortDateString();
        this.Lbl_Supp.Text = base.Base_GetSupplierName_Link(Model.SuppNo);
        this.Tbx_SuppNo.Text = Model.SuppNo;
        //KNet.BLL.KNet_Sys_CheckMethod Bll_M = new KNet.BLL.KNet_Sys_CheckMethod();
        //DataSet Dts_Table1 = Bll_M.GetList(" CheckNo='" + Model.OrderPaymentNotes + "'");
        //if (Dts_Table1.Tables[0].Rows.Count > 0)
        //{
        //    this.Lbl_Payment.Text = Dts_Table1.Tables[0].Rows[0]["CheckName"].ToString();
        //}
        this.Lbl_ParentOrderNo.Text = "<a href=\"Knet_Procure_OpenBilling_View.aspx?ID=" + Model.ParentOrderNo + "\">" + Model.ParentOrderNo + "</a>";
        string[] s_ContractNo = Model.ContractNos.Split(',');
        this.Lbl_ContractNo.Text = "";
        for (int i = 0; i < s_ContractNo.Length; i++)
        {
            this.Lbl_ContractNo.Text += "<a href=\"../../SalesContract/Xs_ContractList_View.aspx?ID=" + s_ContractNo[i] + "\" >" + s_ContractNo[i] + "</a><br>";

        }
        this.Lbl_SelectSupp.Text = base.Base_GetSupplierName_Link(Model.ReceiveSuppNo);
        this.Lbl_Depart.Text = base.Base_GeDept(Model.OrderStaffDepart);
        this.Lbl_OrderType.Text = base.base_GetProcureTypeNane(Model.OrderType);
        this.Lbl_Address.Text = Model.ContractAddress;
        this.Lbl_Remarks.Text = Model.OrderRemarks;
        AdminloginMess AM = new AdminloginMess();

        if (Model.OrderCheckYN == true)
        {
            btn_Chcek.Text = "反审批";
            this.Button1.Enabled = true;

        }
        else
        {
            btn_Chcek.Text = "审批";
            // this.Button1.Enabled = false;

        }
        if (((AM.KNet_StaffDepart != "129652783965723459") || (AM.KNet_Position != "102")) && (AM.KNet_StaffDepart != "129652784259578018"))//如果是研发中心经理显示
        {
            btn_Chcek.Enabled = false;
        }
        else
        {
            btn_Chcek.Enabled = true;
        }
        this.lbl_isRuk.Text = base.Base_GetBasicCodeName("126", Model.rkState);
        this.Lbl_IsPayMent.Text = base.Base_GetBasicCodeName("127", Model.KPO_PayState);
        this.Lbl_PDF.Text = "<a href=\"PDF/" + Model.OrderNo + ".PDF\" target=\"_blank\">" + Model.OrderNo + ".PDF</a>";
        KNet.BLL.Knet_Procure_OrdersList_Details Bll_Details = new KNet.BLL.Knet_Procure_OrdersList_Details();
        DataSet Dts_Table = Bll_Details.GetList(" a.OrderNo='" + s_ID + "'");
        string s_ProductsIDs = "";
        decimal d_All_OrderTotal = 0, d_All_HandTotal = 0, d_All_Total = 0;
        StringBuilder SB_MyTable_Detail = new StringBuilder();
        if (Dts_Table.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
            {
                decimal d_Amount = Decimal.Parse(Dts_Table.Tables[0].Rows[i]["OrderTotalNet"].ToString() == "" ? "0" : Dts_Table.Tables[0].Rows[i]["OrderTotalNet"].ToString()) + Decimal.Parse(Dts_Table.Tables[0].Rows[i]["HandTotal"].ToString() == "" ? "0" : Dts_Table.Tables[0].Rows[i]["HandTotal"].ToString());
                d_All_OrderTotal += Decimal.Parse(Dts_Table.Tables[0].Rows[i]["OrderTotalNet"].ToString() == "" ? "0" : Dts_Table.Tables[0].Rows[i]["OrderTotalNet"].ToString());
                d_All_HandTotal += Decimal.Parse(Dts_Table.Tables[0].Rows[i]["HandTotal"].ToString() == "" ? "0" : Dts_Table.Tables[0].Rows[i]["HandTotal"].ToString());
                d_All_Total += d_Amount;
                s_ProductsIDs += Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString() + ",";
                SB_MyTable_Detail.Append(" <tr>");
                SB_MyTable_Detail.Append("<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetProdutsName_Link(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>");
                SB_MyTable_Detail.Append("<td  class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetProductsCode(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>");
                SB_MyTable_Detail.Append("<td  class=\"ListHeadDetails\" nowrap align=\"center\">" + base.Base_GetProductsEdition(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>");
                SB_MyTable_Detail.Append("<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["OrderAmount"].ToString(), 0) + "</td>");
                SB_MyTable_Detail.Append("<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["OrderUnitPrice"].ToString(), 3) + "</td>");
                SB_MyTable_Detail.Append("<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["HandPrice"].ToString(), 3) + "</td>");
                SB_MyTable_Detail.Append("<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_Amount.ToString(), 3) + "</td>");
                SB_MyTable_Detail.Append("<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["wrkNumber"].ToString() == "" ? "0" : Dts_Table.Tables[0].Rows[i]["wrkNumber"].ToString(), 3) + "</td>");
                SB_MyTable_Detail.Append("<td class=\"ListHeadDetails\" align=\"center\">" + Dts_Table.Tables[0].Rows[i]["OrderRemarks"].ToString() + "</td>");
                SB_MyTable_Detail.Append(" </tr>");
            }
            this.Lbl_Details.Text = SB_MyTable_Detail.ToString();
            string s_MSql = "select KSP_mould+','+a.SuppNo mouldID,ProductsName+'('+b.suppName+'|'+cast(ISNULL(sum(price),0) as  varchar(10))+')' mouldName ";
            s_MSql += " from [v_MouldPricewithProducts] a ";
            s_MSql += "  join Knet_Procure_Suppliers b on a.suppNo=b.suppNo ";

            s_MSql += " where XPD_FaterBarCode in('" + s_ProductsIDs.Replace(",", "','") + "') ";
            s_MSql += " group by KSP_mould ,ProductsName,a.SuppNo,b.suppName ";
            s_MSql += " order by KSP_mould ,a.SuppNo,b.suppName ";
            this.BeginQuery(s_MSql);
            DataTable Dtb_table = (DataTable)this.QueryForDataTable();
            if (Dtb_table != null)
            {
                this.Ddl_Moudle.DataSource = Dtb_table;
                this.Ddl_Moudle.DataValueField = "mouldID";
                this.Ddl_Moudle.DataTextField = "mouldName";
                this.Ddl_Moudle.DataBind();

            }
        }




    }

    /// <summary>
    /// 库存类型
    /// </summary>
    /// <param name="s_Order"></param>
    /// <returns></returns>
    public string Base_GetOrderInProductsPattern(string s_StoreNo)
    {
        string s_Return = "";
        this.BeginQuery("Select * from Knet_Procure_WareHouseList_Details Where WareHouseNo='" + s_StoreNo + "' order by ProductsBarCode");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                s_Return += Base_GetProductsEdition_Link(Dtb_Result.Rows[i]["ProductsBarCode"].ToString()) + "<br>";
            }
            s_Return = s_Return.Substring(0, s_Return.Length - 4);
        }
        return s_Return;
    }

    public string Base_GetOrderInProductsNUmbers(string s_StoreNo)
    {
        string s_Return = "";
        this.BeginQuery("Select WareHouseAmount as WareHouseAmount from Knet_Procure_WareHouseList_Details Where WareHouseNo='" + s_StoreNo + "' order by ProductsBarCode ");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                s_Return += Dtb_Result.Rows[i]["WareHouseAmount"].ToString() + "<br>";
            }
            s_Return = s_Return.Substring(0, s_Return.Length - 4);
        }
        return s_Return;
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


    protected string GetPrint(string s_OrderNo, int i_IsSend)
    {
        string s_Return = "";
        if (i_IsSend == 0)
        {
            string JSD = "Knet_Procure_WareHouseList_List.aspx?ID=" + s_OrderNo + "&Model=IsQr";
            s_Return = "<a href=\"" + JSD + "\" onclick=\"\"  ><font color=red>未确认</font></a>";
        }
        else
        {
            string JSD = "Knet_Procure_WareHouseList_List.aspx?ID=" + s_OrderNo + "&Model=IsQr";
            s_Return = "<a href=\"" + JSD + "\" onclick=\"\" >已确认</a>";
        }
        return s_Return;

    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.BLL.Knet_Procure_OrdersList BLL = new KNet.BLL.Knet_Procure_OrdersList();
        //如果订单已
        if (this.Tbx_ID.Text != "")
        {
            //删除
            string s_Sql = "Delete from Knet_Procure_OrdersList_Details where OrderNo in(Select OrderNo from Knet_Procure_OrdersList where ParentOrderNo='" + this.Tbx_ID.Text + "')";
            string s_Sql1 = "Delete from Knet_Procure_OrdersList where ParentOrderNo='" + this.Tbx_ID.Text + "'";
            DbHelperSQL.ExecuteSql(s_Sql);
            DbHelperSQL.ExecuteSql(s_Sql1);
            AM.Add_Logs("删除子订单：遥控器订单号：" + this.Tbx_ID.Text + "");
            string s_OrderCode = CreateOrderDetails(this.Tbx_ID.Text);
            if (s_OrderCode != "")
            {
                string[] arrCode = s_OrderCode.Substring(0, s_OrderCode.Length - 1).Split(',');
                if (arrCode.Length > 0)
                {
                    for (int i = 0; i < arrCode.Length; i++)
                    {
                        string s_Code = CreateOrderDetails(arrCode[i]);
                        if (s_Code != "")
                        {
                            BLL.Delete(arrCode[i]);
                        }
                        //删除原生成订单
                    }
                }
            }
            base.Base_SendMessage(Base_GetDeptPerson("研发中心", 1), KNetPage.KHtmlEncode("有 遥控器订单 <a href='Web/Order/Knet_Procure_OpenBilling_View.aspx?ID=" + this.Tbx_ID.Text + "'  onclick=\"RemoveSms('" + base.GetNewID("System_Message_Manage", 0) + "', '', 0);\"> " + this.Tbx_ID.Text + "</a> 生成的相关订单需要您审批，敬请关注！"));

            AlertAndRedirect("生成成功！", "Knet_Procure_OpenBilling_View.aspx?ID=" + this.Tbx_ID.Text + "");
        }
    }

    protected void Btn_Click(object sender, EventArgs e)
    {
        try
        {
            this.Btn_Save.Enabled = false;
            string s_Message = "";
            AdminloginMess AM = new AdminloginMess();
            int i_Num = Request["Tbx_Num"] == null ? 0 : int.Parse(Request["Tbx_Num"].ToString());
            string s_ReturnCode = "";
            string s_isNullSuppNo = "", s_ProductsName = "";
            for (int i = 0; i < i_Num; i++)
            {
                string s_SuppNo = Request["Tbx_SuppNo_" + i.ToString() + ""] == null ? "" : Request["Tbx_SuppNo_" + i.ToString() + ""].ToString();
                string s_ProductsCode = Request["Tbx_ProductsBarCode_" + i.ToString() + ""] == null ? "" : Request["Tbx_ProductsBarCode_" + i.ToString() + ""].ToString();

                //如果有未报价的BOM则不打钩
                if (s_SuppNo == "")
                {
                    s_isNullSuppNo = "1";
                    s_ProductsName = base.Base_GetProductsEdition(s_ProductsCode);
                }
            }
            if (AM.KNet_StaffName == "项洲")
            {
                s_isNullSuppNo = "";
            }
            if (s_isNullSuppNo != "")
            {
                Alert("" + s_ProductsName + "未报价!BOM配件不能生成子订单!请先增加报价！");
                return;
            }
            else
            {
                string s_MainAddress = base.Base_GetSuppNoAddress("131187205665612658").Replace("$", "\n");
                for (int i = 0; i < i_Num; i++)
                {
                    try
                    {
                        string s_Address = s_MainAddress;
                        string s_Check = Request["Chk_Check_" + i.ToString() + ""] == null ? "" : Request["Chk_Check_" + i.ToString() + ""].ToString();
                        string s_ProductsBarCode = Request["Tbx_ProductsBarCode_" + i.ToString() + ""] == null ? "" : Request["Tbx_ProductsBarCode_" + i.ToString() + ""].ToString();
                        string s_NewOrderNo = Request["Tbx_OrderNo_" + i.ToString() + ""] == null ? "" : Request["Tbx_OrderNo_" + i.ToString() + ""].ToString();
                        string s_PreToDate = Request["Tbx_OrderPreDate_" + i.ToString() + ""] == null ? "" : Request["Tbx_OrderPreDate_" + i.ToString() + ""].ToString();
                        string s_ReceiveSuppNo = Request["Tbx_ReceiveSuppNo_" + i.ToString() + ""] == null ? "" : Request["Tbx_ReceiveSuppNo_" + i.ToString() + ""].ToString();

                        string s_FaterBarCode = Request["Tbx_FaterBarCode_" + i.ToString() + ""] == null ? "" : Request["Tbx_FaterBarCode_" + i.ToString() + ""].ToString();

                        // Request["Tbx_Address"] == null ? "" : Request["Tbx_Address"].ToString();
                        /* if (s_ReceiveSuppNo != "131187205665612658")
                         {
                             s_Address = base.Base_GetSuppNoAddress(s_ReceiveSuppNo).Replace("$", "\n"); ;
                         }
                         */
                        string s_Remarks = Request["Tbx_Remarks_" + i.ToString() + ""] == null ? "" : Request["Tbx_Remarks_" + i.ToString() + ""].ToString();
                        string s_Number = Request["Tbx_Number_" + i.ToString() + ""] == null ? "" : Request["Tbx_Number_" + i.ToString() + ""].ToString();

                        string s_CPBZNumber = Request["Tbx_CPBZNumber_" + i.ToString() + ""] == null ? "0" : Request["Tbx_CPBZNumber_" + i.ToString() + ""].ToString();
                        string s_BZNumber = Request["Tbx_BZNumber_" + i.ToString() + ""] == null ? "0" : Request["Tbx_BZNumber_" + i.ToString() + ""].ToString();

                        string s_Price = Request["Tbx_Price_" + i.ToString() + ""] == null ? "" : Request["Tbx_Price_" + i.ToString() + ""].ToString();
                        string s_SuppNo = Request["Tbx_SuppNo_" + i.ToString() + ""] == null ? "" : Request["Tbx_SuppNo_" + i.ToString() + ""].ToString();
                        string s_OrderType = Request["Tbx_OrderType_" + i.ToString() + ""] == null ? "" : Request["Tbx_OrderType_" + i.ToString() + ""].ToString();
                        string s_ProductsCode = Request["Tbx_ProductsCode_" + i.ToString() + ""] == null ? "" : Request["Tbx_ProductsCode_" + i.ToString() + ""].ToString();
                        string s_DdlHouseNo = Request["Ddl_HouseNo_" + i.ToString() + ""] == null ? "" : Request["Ddl_HouseNo_" + i.ToString() + ""].ToString();
                        if (s_SuppNo != "")
                        {
                            #region 供应商不为空

                            if (s_DdlHouseNo != "131187187069993664")
                            {
                                KNet.BLL.KNet_Sys_WareHouse Bll_WareHouse = new KNet.BLL.KNet_Sys_WareHouse();
                                KNet.Model.KNet_Sys_WareHouse Model_WareHouse = Bll_WareHouse.GetModel(s_DdlHouseNo);
                                s_Address = base.Base_GetSuppNoAddress(Model_WareHouse.SuppNo).Replace("$", "\n"); ;
                            }

                            string s_Chk_IsMail = Request["Chk_IsMail_" + i.ToString() + ""] == null ? "" : Request["Chk_IsMail_" + i.ToString() + ""].ToString();
                            string s_Chk_IsCheck = Request["Chk_IsCheck_" + i.ToString() + ""] == null ? "" : Request["Chk_IsCheck_" + i.ToString() + ""].ToString();
                            string s_IsModiy = Request["Tbx_isModiy_" + i.ToString() + ""] == null ? "" : Request["Tbx_isModiy_" + i.ToString() + ""].ToString();


                            if ((s_Check != "") && (s_SuppNo != ""))
                            {
                                string s_ID = "";
                                KNet.BLL.Knet_Procure_OrdersList BLL_Procure_OrdersList = new KNet.BLL.Knet_Procure_OrdersList();
                                #region 主表赋值

                                KNet.Model.Knet_Procure_OrdersList Model_Procure_OrderList = BLL_Procure_OrdersList.GetModelB(this.Tbx_ID.Text);
                                try
                                {
                                    Model_Procure_OrderList.OrderPreToDate = DateTime.Parse(s_PreToDate);
                                    Model_Procure_OrderList.ArrivalDate = DateTime.Parse(s_PreToDate);
                                }
                                catch { }
                                Model_Procure_OrderList.ContractAddress = s_Address;
                                Model_Procure_OrderList.ReceiveSuppNo = this.Tbx_SuppNo.Text;
                                Model_Procure_OrderList.OrderRemarks = s_Remarks;
                                Model_Procure_OrderList.ParentOrderNo = Model_Procure_OrderList.OrderNo;
                                Model_Procure_OrderList.SuppNo = s_SuppNo;
                                Model_Procure_OrderList.OrderNo = s_NewOrderNo;
                                Model_Procure_OrderList.KPO_ScDetails = "";
                                Model_Procure_OrderList.KPO_PreHouseNo = s_DdlHouseNo;
                                if ((s_ProductsCode.IndexOf("01") <= 0) && (s_OrderType == "128860698200781250"))
                                {
                                    Model_Procure_OrderList.OrderType = "128860697896406250";
                                }
                                else
                                {
                                    Model_Procure_OrderList.OrderType = s_OrderType;
                                }

                                if (s_Chk_IsCheck != "")
                                {
                                    Model_Procure_OrderList.OrderCheckYN = true;
                                }
                                Model_Procure_OrderList.ID = GetMainID();
                                s_ID = Model_Procure_OrderList.ID;
                                Model_Procure_OrderList.KPO_Creator = AM.KNet_StaffNo;
                                Model_Procure_OrderList.KPO_CTime = DateTime.Now;
                                Model_Procure_OrderList.KPO_Mender = AM.KNet_StaffNo;
                                Model_Procure_OrderList.KPO_MTime = DateTime.Now;
                                Model_Procure_OrderList.OrderStaffNo = AM.KNet_StaffNo;
                                Model_Procure_OrderList.KPO_PriceState = 0;

                                #endregion

                                //如果这个订单号生成过则只删除主表
                                //如果是不同合同编号则不删除
                                KNet.BLL.PB_Basic_Mail Bll_Mail = new KNet.BLL.PB_Basic_Mail();
                                KNet.BLL.Knet_Procure_OrdersList_Details BLL = new KNet.BLL.Knet_Procure_OrdersList_Details();
                                KNet.Model.Knet_Procure_OrdersList_Details Model = new KNet.Model.Knet_Procure_OrdersList_Details();

                                KNet.Model.Knet_Procure_OrdersList Model_Order = BLL_Procure_OrdersList.GetModelB(Model_Procure_OrderList.OrderNo);
                                if (Model_Order != null)
                                {
                                    if (Model_Procure_OrderList.ContractNos == Model_Order.ContractNos)
                                    {
                                        //删除相关邮件
                                        Bll_Mail.DeleteByOrderNo(Model_Order.OrderNo);
                                        BLL_Procure_OrdersList.DeleteByOrderNo(Model_Procure_OrderList.OrderNo);
                                        #region 明细表赋值

                                        Model.ID = GetMainID(i);
                                        Model.ProductsBarCode = s_ProductsBarCode;
                                        Model.OrderNo = s_NewOrderNo;
                                        Model.KPO_FaterBarCode = s_FaterBarCode;
                                        Model.Add_DateTime = DateTime.Now;
                                        Model.HandPrice = 0;
                                        Model.HandTotal = 0;
                                        Model.OrderDiscount = 0;
                                        Model.OrderHasReturned = 0;
                                        Model.OrderHaveReceiving = 0;
                                        Model.OrderAmount = int.Parse(s_Number);
                                        Model.OrderUnitPrice = decimal.Parse(s_Price);
                                        Model.OrderTotalNet = decimal.Parse(s_Price) * decimal.Parse(s_Number);
                                        Model.ProductsName = base.Base_GetProdutsName(s_ProductsBarCode);
                                        Model.ProductsPattern = base.Base_GetProductsPattern(s_ProductsBarCode);
                                        Model.ProductsUnits = base.Base_GetProductsUnits(s_ProductsBarCode);
                                        try
                                        {
                                            if (s_CPBZNumber != "0")
                                            {
                                                Model.KPOD_BZNumber = int.Parse(s_BZNumber);
                                                Model.KPOD_CPBZNumber = int.Parse(s_CPBZNumber);
                                            }
                                        }
                                        catch
                                        { }
                                        //查找该供应商是否已经生成过
                                        ArrayList arr_Details = new ArrayList();
                                        arr_Details.Add(Model);
                                        Model_Procure_OrderList.Arr_ProductsList = arr_Details;
                                        #endregion

                                        #region 发送邮件
                                        BLL_Procure_OrdersList.Add(Model_Procure_OrderList);
                                        try
                                        {
                                            if (s_Chk_IsMail != "")
                                            {
                                                /*
                                                ArrayList arr_Mail = new ArrayList();
                                                KNet.Model.PB_Basic_Mail model = new KNet.Model.PB_Basic_Mail();
                                                model.PBM_ID = GetMainID(i);
                                                model.PBM_Code = base.GetNewID("PBM_Code", 1);
                                                string s_ReceiveEmail = Request["ReceiveEmail_" + i.ToString() + ""] == null ? "" : Request["ReceiveEmail_" + i.ToString() + ""].ToString();
                                                string s_ReceiveMsEmail = Request["ReceiveMsEmail_" + i.ToString() + ""] == null ? "" : Request["ReceiveMsEmail_" + i.ToString() + ""].ToString();
                                                string s_ReceiveCsEmail = Request["ReceiveCsEmail_" + i.ToString() + ""] == null ? "" : Request["ReceiveCsEmail_" + i.ToString() + ""].ToString();
                                                string s_EmailDetails = Request["EmailDetails_" + i.ToString() + ""] == null ? "" : Request["EmailDetails_" + i.ToString() + ""].ToString();
                                                string s_EamilFile = Request["Tbx_EamilFile_" + i.ToString() + ""] == null ? "" : Request["Tbx_EamilFile_" + i.ToString() + ""].ToString();
                                                string s_ReceiveTitle = Request["ReceiveTitle_" + i.ToString() + ""] == null ? "" : Request["ReceiveTitle_" + i.ToString() + ""].ToString();
                                                string s_SendEmail = Request["SendEmail_" + i.ToString() + ""] == null ? "" : Request["SendEmail_" + i.ToString() + ""].ToString();
                                                try
                                                {
                                                    KNet.BLL.PB_Mail_Setting bll_Setting = new KNet.BLL.PB_Mail_Setting();
                                                    KNet.Model.PB_Mail_Setting Model_Setting = bll_Setting.GetModel(s_SendEmail);
                                                    model.PBM_SendEmail = Model_Setting.PMS_SendEmail;
                                                }
                                                catch
                                                { }
                                                model.PBM_ReceiveEmail = s_ReceiveEmail;
                                                model.PBM_Text = KNetPage.KHtmlEncode(s_EmailDetails);
                                                model.PBM_File = KNetPage.KHtmlEncode(s_EamilFile);

                                                model.PBM_Title = s_ReceiveTitle;
                                                model.PBM_Creator = AM.KNet_StaffNo;
                                                model.PBM_CTime = DateTime.Now;
                                                model.PBM_Mender = AM.KNet_StaffNo;
                                                model.PBM_MTime = DateTime.Now;

                                                model.PBM_Cc = s_ReceiveCsEmail;
                                                model.PBM_Ms = s_ReceiveCsEmail;
                                                model.PBM_FID = s_NewOrderNo;
                                                model.PBM_Type = 1;
                                                model.PBM_SendType = 1;
                                                model.PBM_Minute = 20 * 60;//20分钟后
                                                model.PBM_SendSettingID = s_SendEmail;
                                                Bll_Mail.Add(model);*/
                                            }
                                        }
                                        catch
                                        {
                                        }
                                        #endregion
                                    }
                                    else
                                    {
                                        Model_Procure_OrderList.OrderNo = KNetOddNumbers(s_SuppNo);
                                        Model_Order.OrderNo = Model_Procure_OrderList.OrderNo;
                                        #region 明细表赋值

                                        Model.ID = GetMainID(i);
                                        Model.ProductsBarCode = s_ProductsBarCode;
                                        Model.KPO_FaterBarCode = s_FaterBarCode;
                                        Model.OrderNo = s_NewOrderNo;
                                        Model.Add_DateTime = DateTime.Now;
                                        Model.HandPrice = 0;
                                        Model.HandTotal = 0;
                                        Model.OrderDiscount = 0;
                                        Model.OrderHasReturned = 0;
                                        Model.OrderHaveReceiving = 0;
                                        Model.OrderAmount = int.Parse(s_Number);
                                        Model.OrderUnitPrice = decimal.Parse(s_Price);
                                        Model.OrderTotalNet = decimal.Parse(s_Price) * decimal.Parse(s_Number);
                                        Model.ProductsName = base.Base_GetProdutsName(s_ProductsBarCode);
                                        Model.ProductsPattern = base.Base_GetProductsPattern(s_ProductsBarCode);
                                        Model.ProductsUnits = base.Base_GetProductsUnits(s_ProductsBarCode);
                                        try
                                        {
                                            if (s_CPBZNumber != "0")
                                            {
                                                Model.KPOD_BZNumber = int.Parse(s_BZNumber);
                                                Model.KPOD_CPBZNumber = int.Parse(s_CPBZNumber);
                                            }
                                        }
                                        catch
                                        { }
                                        //查找该供应商是否已经生成过
                                        ArrayList arr_Details = new ArrayList();
                                        arr_Details.Add(Model);
                                        Model_Procure_OrderList.Arr_ProductsList = arr_Details;
                                        #endregion

                                        #region 邮件发送
                                        try
                                        {
                                            if (s_Chk_IsMail != "")
                                            {
                                                /*
                                                ArrayList arr_Mail = new ArrayList();
                                                KNet.Model.PB_Basic_Mail model = new KNet.Model.PB_Basic_Mail();
                                                model.PBM_ID = GetMainID(i);
                                                model.PBM_Code = base.GetNewID("PBM_Code", 1);
                                                string s_ReceiveEmail = Request["ReceiveEmail_" + i.ToString() + ""] == null ? "" : Request["ReceiveEmail_" + i.ToString() + ""].ToString();
                                                string s_ReceiveMsEmail = Request["ReceiveMsEmail_" + i.ToString() + ""] == null ? "" : Request["ReceiveMsEmail_" + i.ToString() + ""].ToString();
                                                string s_ReceiveCsEmail = Request["ReceiveCsEmail_" + i.ToString() + ""] == null ? "" : Request["ReceiveCsEmail_" + i.ToString() + ""].ToString();
                                                string s_EmailDetails = Request["EmailDetails_" + i.ToString() + ""] == null ? "" : Request["EmailDetails_" + i.ToString() + ""].ToString();
                                                string s_EamilFile = Request["Tbx_EamilFile_" + i.ToString() + ""] == null ? "" : Request["Tbx_EamilFile_" + i.ToString() + ""].ToString();
                                                string s_ReceiveTitle = Request["ReceiveTitle_" + i.ToString() + ""] == null ? "" : Request["ReceiveTitle_" + i.ToString() + ""].ToString();
                                                string s_SendEmail = Request["SendEmail_" + i.ToString() + ""] == null ? "" : Request["SendEmail_" + i.ToString() + ""].ToString();
                                                try
                                                {
                                                    KNet.BLL.PB_Mail_Setting bll_Setting = new KNet.BLL.PB_Mail_Setting();
                                                    KNet.Model.PB_Mail_Setting Model_Setting = bll_Setting.GetModel(s_SendEmail);
                                                    model.PBM_SendEmail = Model_Setting.PMS_SendEmail;
                                                }
                                                catch
                                                { }
                                                model.PBM_ReceiveEmail = s_ReceiveEmail;
                                                model.PBM_Text = KNetPage.KHtmlEncode(s_EmailDetails);
                                                model.PBM_File = KNetPage.KHtmlEncode(s_EamilFile);

                                                model.PBM_Title = s_ReceiveTitle;
                                                model.PBM_Creator = AM.KNet_StaffNo;
                                                model.PBM_CTime = DateTime.Now;
                                                model.PBM_Mender = AM.KNet_StaffNo;
                                                model.PBM_MTime = DateTime.Now;

                                                model.PBM_Cc = s_ReceiveCsEmail;
                                                model.PBM_Ms = s_ReceiveCsEmail;
                                                model.PBM_FID = s_NewOrderNo;
                                                model.PBM_Type = 1;
                                                model.PBM_SendType = 1;
                                                model.PBM_Minute = 20 * 60;//10分钟后
                                                model.PBM_SendSettingID = s_SendEmail;
                                                Bll_Mail.Add(model);*/
                                            }

                                        }
                                        catch
                                        {
                                        }
                                        #endregion

                                        BLL_Procure_OrdersList.Add(Model_Procure_OrderList);
                                    }
                                }
                                else
                                {

                                    #region 明细表赋值

                                    Model.ID = GetMainID(i);
                                    Model.ProductsBarCode = s_ProductsBarCode;

                                    Model.OrderNo = s_NewOrderNo;
                                    Model.Add_DateTime = DateTime.Now;
                                    Model.HandPrice = 0;
                                    Model.HandTotal = 0;
                                    Model.OrderDiscount = 0;
                                    Model.OrderHasReturned = 0;
                                    Model.OrderHaveReceiving = 0;
                                    Model.KPO_FaterBarCode = s_FaterBarCode;
                                    Model.OrderAmount = int.Parse(s_Number);
                                    Model.OrderUnitPrice = decimal.Parse(s_Price);
                                    Model.OrderTotalNet = decimal.Parse(s_Price) * decimal.Parse(s_Number);
                                    Model.ProductsName = base.Base_GetProdutsName(s_ProductsBarCode);
                                    Model.ProductsPattern = base.Base_GetProductsPattern(s_ProductsBarCode);
                                    Model.ProductsUnits = base.Base_GetProductsUnits(s_ProductsBarCode);
                                    try
                                    {
                                        if (s_CPBZNumber != "0")
                                        {
                                            Model.KPOD_BZNumber = int.Parse(s_BZNumber);
                                            Model.KPOD_CPBZNumber = int.Parse(s_CPBZNumber);
                                        }
                                    }
                                    catch
                                    { }

                                    ArrayList arr_Details = new ArrayList();
                                    arr_Details.Add(Model);
                                    Model_Procure_OrderList.Arr_ProductsList = arr_Details;
                                    #endregion

                                    #region 邮件发送

                                    try
                                    {
                                        if (s_Chk_IsMail != "")
                                        {
                                            /*
                                            ArrayList arr_Mail = new ArrayList();
                                            KNet.Model.PB_Basic_Mail model = new KNet.Model.PB_Basic_Mail();
                                            model.PBM_ID = GetMainID(i);
                                            model.PBM_Code = base.GetNewID("PBM_Code", 1);
                                            string s_ReceiveEmail = Request["ReceiveEmail_" + i.ToString() + ""] == null ? "" : Request["ReceiveEmail_" + i.ToString() + ""].ToString();
                                            string s_ReceiveMsEmail = Request["ReceiveMsEmail_" + i.ToString() + ""] == null ? "" : Request["ReceiveMsEmail_" + i.ToString() + ""].ToString();
                                            string s_ReceiveCsEmail = Request["ReceiveCsEmail_" + i.ToString() + ""] == null ? "" : Request["ReceiveCsEmail_" + i.ToString() + ""].ToString();
                                            string s_EmailDetails = Request["EmailDetails_" + i.ToString() + ""] == null ? "" : Request["EmailDetails_" + i.ToString() + ""].ToString();
                                            string s_EamilFile = Request["Tbx_EamilFile_" + i.ToString() + ""] == null ? "" : Request["Tbx_EamilFile_" + i.ToString() + ""].ToString();
                                            string s_ReceiveTitle = Request["ReceiveTitle_" + i.ToString() + ""] == null ? "" : Request["ReceiveTitle_" + i.ToString() + ""].ToString();
                                            string s_SendEmail = Request["SendEmail_" + i.ToString() + ""] == null ? "" : Request["SendEmail_" + i.ToString() + ""].ToString();
                                            try
                                            {
                                                KNet.BLL.PB_Mail_Setting bll_Setting = new KNet.BLL.PB_Mail_Setting();
                                                KNet.Model.PB_Mail_Setting Model_Setting = bll_Setting.GetModel(s_SendEmail);
                                                model.PBM_SendEmail = Model_Setting.PMS_SendEmail;
                                            }
                                            catch
                                            { }
                                            model.PBM_ReceiveEmail = s_ReceiveEmail;
                                            model.PBM_Text = KNetPage.KHtmlEncode(s_EmailDetails);
                                            model.PBM_File = KNetPage.KHtmlEncode(s_EamilFile);

                                            model.PBM_Title = s_ReceiveTitle;
                                            model.PBM_Creator = AM.KNet_StaffNo;
                                            model.PBM_CTime = DateTime.Now;
                                            model.PBM_Mender = AM.KNet_StaffNo;
                                            model.PBM_MTime = DateTime.Now;

                                            model.PBM_Cc = s_ReceiveCsEmail;
                                            model.PBM_Ms = s_ReceiveCsEmail;
                                            model.PBM_FID = s_NewOrderNo;
                                            model.PBM_Type = 1;
                                            model.PBM_SendType = 1;
                                            model.PBM_Minute = 20 * 60;//10分钟后

                                            if (int.Parse(s_IsModiy) <= 0)
                                            {
                                                model.PBM_Del = 0;
                                            }
                                            else
                                            {
                                                model.PBM_Del = 1;
                                            }
                                            model.PBM_SendSettingID = s_SendEmail;
                                            Bll_Mail.Add(model);*/
                                        }
                                    }


                                    catch
                                    {
                                    }
                                    #endregion

                                    BLL_Procure_OrdersList.Add(Model_Procure_OrderList);
                                }
                                s_ReturnCode += Model_Procure_OrderList.OrderNo + ",";
                                /*
                                 * */
                            }
                            #endregion
                        }
                    }
                    catch (Exception ex)
                    {
                        Alert(ex.Message);
                    }

                }
                //最后来循环订单生产PDF
                try
                {
                    string s_Sql = "Select * from Knet_Procure_OrdersList where ParentOrderNo='" + this.Tbx_ID.Text + "'";
                    this.BeginQuery(s_Sql);
                    DataTable Dtb_Table = (DataTable)this.QueryForDataTable();
                    for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                    {
                        string s_OrderNo = Dtb_Table.Rows[i]["OrderNo"].ToString();
                        string s_ID = Dtb_Table.Rows[i]["ID"].ToString();
                        string JSD = "CG/Order/Knet_Procure_OpenBilling_Print.aspx?ID=" + s_ID + "";
                        base.HtmlToPdf1(JSD, Server.MapPath("PDF"), s_OrderNo);
                        s_Message = "生成PDF成功";
                    }
                }
                catch
                {
                    s_Message = "生成PDF失败";
                }
                AM.Add_Logs("采购订单生成->" + s_Message + " 订单号：" + s_ReturnCode + " 模具和供应商：" + this.Ddl_Moudle.SelectedValue);
                AlertAndClose("采购订单生成 " + s_Message + " 操作成功");
            }
        }
        catch (Exception ex) { }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            AdminloginMess AM = new AdminloginMess();
            //删除

            this.BeginQuery("Select Sum(isnull(cast( OrderCheckYN as int),0)) from Knet_Procure_OrdersList where ParentOrderNo='" + this.Tbx_ID.Text + "'");
            string s_Return = this.QueryForReturn();
            s_Return = s_Return == "" ? "0" : s_Return.ToString();
            if (int.Parse(s_Return) > 0)
            {
                Alert("有子订单已审批不能重新生成！");
            }
            else
            { //删除
                try
                {
                    string s_Sql2 = " Delete from PB_Basic_Mail where PBM_FID  in(Select OrderNo from Knet_Procure_OrdersList where ParentOrderNo='" + this.Tbx_ID.Text + "') and PBM_State=0 ";
                    string s_Sql = " Delete from Knet_Procure_OrdersList_Details where OrderNo in(Select OrderNo from Knet_Procure_OrdersList where ParentOrderNo='" + this.Tbx_ID.Text + "')";
                    string s_Sql1 = " Delete from Knet_Procure_OrdersList where ParentOrderNo='" + this.Tbx_ID.Text + "'";

                    DbHelperSQL.ExecuteSql(s_Sql2);
                    DbHelperSQL.ExecuteSql(s_Sql);
                    DbHelperSQL.ExecuteSql(s_Sql1);
                    AM.Add_Logs("采购->删除子订单 ID:" + this.Tbx_ID.Text);
                }
                catch { }
                string s_Code = this.Tbx_ID.Text;
                KNet.BLL.Knet_Procure_OrdersList BLL_Procure_OrdersList = new KNet.BLL.Knet_Procure_OrdersList();
                KNet.Model.Knet_Procure_OrdersList Model_Procure_OrderList = BLL_Procure_OrdersList.GetModelB(s_Code);
                string s_ContractAddress = Model_Procure_OrderList.ContractAddress;
                DateTime D_Days = DateTime.Parse(Model_Procure_OrderList.OrderPreToDate.ToString());
                DateTime D_NDays = DateTime.Parse(Model_Procure_OrderList.OrderDateTime.ToString());

                //计算库存
                GetNewStore();
                this.Pan_Sc.Visible = true;
                //二级BOM读取 如果产品下面有半成品
                string s_Sql3 = "Select * from Xs_Products_Prodocts_Demo a join Knet_Procure_OrdersList_Details b on a.XPD_FaterBarCode=b.ProductsBarCode join KNET_Sys_Products c on a.XPD_ProductsBarCode=c.ProductsBarCode where ProductsType='M160901092354544'";
                //如果是底层不是半成品

                string sql = "select * from (Select e.SuppNo as XPDSuppNo,a.XPD_FaterBarCode as FaterBarCode,isnull(e.ProcureUnitPrice,0)+isnull(e.HandPrice,0)  as XPDPrice,a.*,b.ProductsBarCode,b.OrderAmount,d.SuppNo,c.ProductsType,c.KSP_Code,c.KSP_CgType,c.KSP_isModiy,c.KSP_BZNumber  ";
                sql += " from Xs_Products_Prodocts_Demo a ";//底层BOM

                sql += " join Knet_Procure_OrdersList_Details b  on a.XPD_FaterBarCode=b.ProductsBarCode ";
                sql += " join Knet_Procure_OrdersList d on d.OrderNo=b.OrderNo ";

                sql += " join KNet_Sys_Products c on c.ProductsBarCode=a.XPD_ProductsBarCode ";
                sql += " left join Knet_Procure_SuppliersPrice e on e.ProductsBarCode=a.XPD_ProductsBarCode and e.KPP_Del=0 and e.KPP_State=1  ";
                sql += " where  b.OrderNo='" + s_Code + "' and c.ProductsType<>'M160901092354544' ";
                sql += " and c.KSP_Del=0  ";

                //如果是底层是半成品
                sql += " union all Select e.SuppNo as XPDSuppNo,a.XPD_FaterBarCode as FaterBarCode,isnull(e.ProcureUnitPrice,0)+isnull(e.HandPrice,0)  as XPDPrice,a.*,b.ProductsBarCode,b.OrderAmount,d.SuppNo,c.ProductsType,c.KSP_Code,c.KSP_CgType,c.KSP_isModiy,c.KSP_BZNumber ";
                sql += " from Xs_Products_Prodocts_Demo a ";//底层BOM
                sql += " join Xs_Products_Prodocts_Demo f on a.XPD_FaterBarCode=f.XPD_ProductsBarCode ";//半成品

                sql += " join Knet_Procure_OrdersList_Details b  on f.XPD_FaterBarCode=b.ProductsBarCode ";
                sql += " join Knet_Procure_OrdersList d on d.OrderNo=b.OrderNo ";

                sql += " join KNet_Sys_Products c on c.ProductsBarCode=a.XPD_ProductsBarCode ";
                sql += " left join Knet_Procure_SuppliersPrice e on e.ProductsBarCode=a.XPD_ProductsBarCode and e.KPP_Del=0 and e.KPP_State=1  ";
                sql += " where  b.OrderNo='" + s_Code + "' ";
                sql += " and c.KSP_Del=0) aa order by XPDSuppNo,XPD_Order,ProductsType,KSP_Code,XPD_ReplaceProductsBarCode,SuppNo ";


                this.BeginQuery(sql);
                this.QueryForDataTable();
                DataTable Dtb_Table = this.Dtb_Result;
                StringBuilder Sb_Details = new StringBuilder();
                if (Dtb_Table.Rows.Count > 0)
                {
                    for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                    {
                        //
                        string s_IsOrder = Dtb_Table.Rows[i]["XPD_IsOrder"].ToString();
                        string s_Address = Dtb_Table.Rows[i]["XPD_Address"].ToString();
                        string s_SuppNo = Dtb_Table.Rows[i]["XPDSuppNo"].ToString();
                        string s_GoSuppNo = Dtb_Table.Rows[i]["SuppNo"].ToString();
                        string s_Order = Dtb_Table.Rows[i]["XPD_Order"].ToString();
                        string s_ProductsBarCode = Dtb_Table.Rows[i]["XPD_ProductsBarCode"].ToString();
                        string s_FaterBarCode = Dtb_Table.Rows[i]["FaterBarCode"].ToString();
                        string s_ProductsCode = Dtb_Table.Rows[i]["KSP_Code"].ToString();
                        string s_ReplaceProductsBarCode = Dtb_Table.Rows[i]["XPD_ReplaceProductsBarCode"].ToString();
                        string s_FaterProductsBarCode = Dtb_Table.Rows[i]["ProductsBarCode"].ToString();
                        int s_OrderNumber = int.Parse(Dtb_Table.Rows[i]["OrderAmount"].ToString());
                        string s_Price = Dtb_Table.Rows[i]["XPDPrice"].ToString();
                        string s_ProductsType = Dtb_Table.Rows[i]["ProductsType"].ToString();
                        int s_Number = int.Parse(base.FormatNumber(Dtb_Table.Rows[i]["XPD_Number"].ToString(), 0));
                        string s_BZNumber = Dtb_Table.Rows[i]["KSP_BZNumber"].ToString();
                        int i_CgType = int.Parse(Dtb_Table.Rows[i]["KSP_CgType"].ToString());
                        string s_isModiy = Dtb_Table.Rows[i]["KSP_isModiy"].ToString();

                        string s_NewOrderNo = "";
                        string s_OrderType = "";
                        if (s_SuppNo != "")
                        {
                            s_NewOrderNo = KNetOddNumbers(s_SuppNo);
                            KNet.BLL.Knet_Procure_Suppliers Bll_Supp = new KNet.BLL.Knet_Procure_Suppliers();
                            KNet.Model.Knet_Procure_Suppliers Model_Supp = Bll_Supp.GetModelB(s_SuppNo);
                            s_OrderType = Model_Supp.KPS_Type;
                        }
                        KNet.BLL.PB_Basic_ProductsClass Bll_ProductsClass = new KNet.BLL.PB_Basic_ProductsClass();
                        KNet.Model.PB_Basic_ProductsClass Model_ProductsClass = Bll_ProductsClass.GetModel(s_ProductsType);
                        string s_Days = Model_ProductsClass.PBP_OrderDays.ToString(); ;

                        Sb_Details.Append("<tr>\n");
                        Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                        Sb_Details.Append(Convert.ToString(i + 1));
                        Sb_Details.Append("</td>\n");
                        Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                        Sb_Details.Append("<input id=\"Tbx_OrderNo_" + i.ToString() + "\" type=\"hidden\" name=\"Tbx_OrderNo_" + i.ToString() + "\"  value=\"" + s_NewOrderNo + "\" />\n");

                        string s_Checked = "";
                        if ((s_NewOrderNo != "") && (s_ReplaceProductsBarCode == ""))
                        {
                            s_Checked = "checked";
                        }
                        if (i_CgType == 0)
                        {
                            s_Checked = "checked";
                        }
                        else
                        {
                            s_Checked = "";
                        }
                        Sb_Details.Append("<input id=\"Chk_Check_" + i.ToString() + "\" type=\"checkbox\" name=\"Chk_Check_" + i.ToString() + "\" " + s_Checked + " />\n");
                        Sb_Details.Append("" + base.Base_GetProductsType(s_ProductsType) + "<a href=\"#\" onclick=\"ShowDivByID(" + i.ToString() + ")\">明细</a>\n");
                        Sb_Details.Append("</td>\n");
                        Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                        Sb_Details.Append("<input id=\"Tbx_SuppNo_" + i.ToString() + "\" type=\"hidden\" name=\"Tbx_SuppNo_" + i.ToString() + "\"  value=\"" + s_SuppNo + "\" />" + base.Base_GetSupplierName_Link(s_SuppNo) + "\n");
                        Sb_Details.Append("<input id=\"Tbx_OrderType_" + i.ToString() + "\" type=\"hidden\" name=\"Tbx_OrderType_" + i.ToString() + "\"  value=\"" + s_OrderType + "\" />\n");

                        Sb_Details.Append("</td>\n");

                        Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                        Sb_Details.Append("<input id=\"Tbx_FaterBarCode_" + i.ToString() + "\" type=\"hidden\" name=\"Tbx_FaterBarCode_" + i.ToString() + "\"  value=\"" + s_FaterBarCode + "\" /><input id=\"Tbx_ProductsBarCode_" + i.ToString() + "\" type=\"hidden\" name=\"Tbx_ProductsBarCode_" + i.ToString() + "\"  value=\"" + s_ProductsBarCode + "\" /><input id=\"Tbx_ProductsCode_" + i.ToString() + "\" type=\"hidden\" name=\"Tbx_ProductsCode_" + i.ToString() + "\"  value=\"" + s_ProductsCode + "\" />" + s_Order + "\n");
                        Sb_Details.Append("</td>\n");
                        Sb_Details.Append("<td class=\"ListHeadDetails\" width=\"300px\">\n");
                        Sb_Details.Append("" + base.Base_GetProductsEdition_Link(s_ProductsBarCode) + "\n");
                        Sb_Details.Append("</td>\n");

                        string s_OrderNum = Convert.ToString(s_Number * s_OrderNumber);

                        string s_OrderCPBZNumber = "0", s_OrderBZNumber = "0";
                        try
                        {
                            if (s_BZNumber != "0")
                            {

                                s_OrderCPBZNumber = s_BZNumber;
                                int i_NumOder = int.Parse(s_OrderNum) / int.Parse(s_OrderCPBZNumber);
                                if (int.Parse(s_OrderNum) > (int.Parse(s_OrderCPBZNumber) * i_NumOder))
                                {
                                    s_OrderBZNumber = Convert.ToString(int.Parse(s_OrderNum) / int.Parse(s_OrderCPBZNumber) + 1);
                                }
                                else
                                {
                                    s_OrderBZNumber = Convert.ToString(int.Parse(s_OrderNum) / int.Parse(s_OrderCPBZNumber));
                                }

                                s_OrderNum = Convert.ToString(int.Parse(s_OrderBZNumber) * int.Parse(s_OrderCPBZNumber));
                            }
                            else
                            {
                                s_OrderBZNumber = s_BZNumber;
                            }
                        }
                        catch
                        { }
                        Sb_Details.Append("<td class=\"ListHeadDetails\" width=\"50px\"  >\n");

                        Sb_Details.Append("<input id=\"Tbx_CPBZNumber_" + i.ToString() + "\" type=\"input\" name=\"Tbx_CPBZNumber_" + i.ToString() + "\"  style=\"width:50px\" onblur=\"ChangPrice()\"    value=\"" + s_OrderCPBZNumber + "\" />\n");

                        Sb_Details.Append("</td>\n");
                        Sb_Details.Append("<td class=\"ListHeadDetails\" width=\"50px\"  >\n");

                        Sb_Details.Append("<input id=\"Tbx_BZNumber_" + i.ToString() + "\" type=\"input\" name=\"Tbx_BZNumber_" + i.ToString() + "\" onblur=\"ChangPrice()\"  style=\"width:50px\"  value=\"" + s_OrderBZNumber + "\" />\n");

                        Sb_Details.Append("</td>\n");
                        Sb_Details.Append("<td class=\"ListHeadDetails\" width=\"50px\"  >\n");

                        Sb_Details.Append("<input id=\"Tbx_Number_" + i.ToString() + "\" type=\"input\" name=\"Tbx_Number_" + i.ToString() + "\"  style=\"width:50px\"  value=\"" + s_OrderNum + "\" />\n");

                        Sb_Details.Append("</td>\n");

                        /*
                         * string s_NewPrice = "";
                        this.BeginQuery("select top 1 ProcureUnitPrice from Knet_Procure_SuppliersPrice where SuppNo='" + s_SuppNo + "' and ProcureUnitPrice<>'" + s_Price + "' and ProductsBarCode='" + s_ProductsBarCode + "' and KPP_Del=0 and e.KPP_State=1   order by ProcureUpdateDateTime desc ");
                        s_NewPrice = this.QueryForReturn();
                        */
                        Sb_Details.Append("<td class=\"ListHeadDetails\" >\n");
                        Sb_Details.Append("<input id=\"Tbx_Price_" + i.ToString() + "\" type=\"hidden\" name=\"Tbx_Price_" + i.ToString() + "\"  value=\"" + s_Price + "\" />" + s_Price + "\n");
                        /*
                        if (s_NewPrice != "")
                        {
                            Sb_Details.Append("<font color=red>" + s_NewPrice + "</font>");
                        }
                         * */
                        Sb_Details.Append("</td>\n");
                        DateTime d_Day = D_Days;
                        if (s_Days != "0")
                        {
                            d_Day = D_NDays.AddDays(int.Parse(s_Days));
                        }
                        else
                        {
                            d_Day = D_Days;
                        }

                        Sb_Details.Append("<td class=\"ListHeadDetails\">\n");
                        Sb_Details.Append("<input id=\"Tbx_OrderPreDate_" + i.ToString() + "\"  class=\"Wdate\" onFocus=\"WdatePicker()\"  style=\"width:80px;\" name=\"Tbx_OrderPreDate_" + i.ToString() + "\"  value=\"" + d_Day.ToShortDateString() + "\" />\n");
                        Sb_Details.Append("</td>\n");

                        //加入供应商收货仓库默认是公司仓库

                        Sb_Details.Append("<td class=\"ListHeadDetails\" >\n");
                        //默认发士腾
                        string s_ReciveSupp = "131187205665612658";
                        s_GoSuppNo = "131187205665612658";
                        string s_HouseNo = "131187187069993664";
                        Sb_Details.Append("<input id=\"Tbx_isModiy_" + i.ToString() + "\" type=\"hidden\" name=\"Tbx_isModiy_" + i.ToString() + "\"   value=\"" + s_isModiy + "\" /><input id=\"Tbx_ReceiveSuppNo_" + i.ToString() + "\" type=\"hidden\" name=\"Tbx_ReceiveSuppNo_" + i.ToString() + "\"   value=\"" + s_ReciveSupp + "\" />\n");
                        Sb_Details.Append("<Select id=\"Ddl_HouseNo_" + i.ToString() + "\" name=\"Ddl_HouseNo_" + i.ToString() + "\">\n");

                        KNet.BLL.KNet_Sys_WareHouse bll_WareHouse = new KNet.BLL.KNet_Sys_WareHouse();
                        DataSet ds_WareHouse = bll_WareHouse.GetList(" HouseYN=1 and KSW_Type=0 ");
                        if (ds_WareHouse.Tables[0].Rows.Count > 0)
                            Sb_Details.Append("<option value=\"\" >---请选择---</option>\n");
                        {
                            for (int i_WarHouse = 0; i_WarHouse < ds_WareHouse.Tables[0].Rows.Count; i_WarHouse++)
                            {
                                //目前是发士腾仓库
                                string s_WareHouseSelected = "";
                                if (ds_WareHouse.Tables[0].Rows[i_WarHouse]["HouseNo"].ToString() == s_HouseNo)
                                {
                                    s_WareHouseSelected = "selected";
                                }
                                Sb_Details.Append("<option value=\"" + ds_WareHouse.Tables[0].Rows[i_WarHouse]["HouseNo"].ToString() + "\" " + s_WareHouseSelected + ">" + ds_WareHouse.Tables[0].Rows[i_WarHouse]["HouseName"].ToString() + "</option>\n");
                            }
                        }


                        Sb_Details.Append("</Select>\n");

                        Sb_Details.Append("</td>\n");

                        Sb_Details.Append("<td class=\"ListHeadDetails\" >\n");
                        if (i_CgType == 0)
                        {
                            Sb_Details.Append("<font color=red>定制</font>\n");
                        }
                        else
                        {
                            Sb_Details.Append("<font color=green>分批</font>\n");
                        }
                        Sb_Details.Append("</td>\n");

                        //if (s_Address == "0")
                        //{
                        //    Model_Procure_OrderList.ContractAddress = base.Base_GetSuppNoAddress(s_GoSuppNo).Replace("$", "\n");
                        //    Model_Procure_OrderList.ReceiveSuppNo = s_GoSuppNo;
                        //}
                        //else
                        //{
                        //    Model_Procure_OrderList.ContractAddress = s_ContractAddress;
                        //}

                        try
                        {
                            //现在默认发士腾仓库
                            /*
                            KNet.BLL.KNet_Sys_WareHouse Bll_WareHouse = new KNet.BLL.KNet_Sys_WareHouse();
                            KNet.Model.KNet_Sys_WareHouse Model_WareHouse = Bll_WareHouse.GetModelBySuppNo(s_GoSuppNo);
                            string s_HouseNo = Model_WareHouse.HouseNo == null ? "" : Model_WareHouse.HouseNo.ToString();

                            KNet.BLL.Knet_Procure_Suppliers Bll_Supp = new KNet.BLL.Knet_Procure_Suppliers();
                            KNet.Model.Knet_Procure_Suppliers Model_Supp = Bll_Supp.GetModelB(s_GoSuppNo);

                            */

                            string s_OrderLeftNumber = "0";
                            string s_WareHouseNumber = "0";
                            string s_NeedNumber = "0";

                            string s_WareHouseNumber_Total = "0";
                            string s_OrderLeftNumber_Total = "0";
                            string s_NeedNumber_Total = "0";
                            /* */
                            s_WareHouseNumber = base.Base_GetHouseAndNumber1(s_ProductsBarCode, s_HouseNo);
                            string s_Sql = "Select isnull(Sum(NeedNumber),0)  from KNET_NeedStore where ProductsBarCode='" + s_ProductsBarCode + "' and HouseNo='" + s_HouseNo + "'  ";
                            this.BeginQuery(s_Sql);
                            s_NeedNumber = this.QueryForReturn();
                            s_NeedNumber = s_NeedNumber == "" ? "0" : s_NeedNumber;
                            s_NeedNumber = Convert.ToString(s_Number * s_OrderNumber + int.Parse(s_NeedNumber_Total));

                            //s_WareHouseNumber_Total = base.Base_GetHouseAndNumber1(s_ProductsBarCode, "");

                            /*   s_Sql = "Select isnull(Sum(NeedNumber),0) from KNET_NeedStore where ProductsBarCode='" + s_ProductsBarCode + "'";
                               this.BeginQuery(s_Sql);
                               s_NeedNumber_Total = this.QueryForReturn();
                               s_NeedNumber_Total = Convert.ToString(s_Number * s_OrderNumber + int.Parse(s_NeedNumber_Total));
                               s_NeedNumber_Total = s_NeedNumber_Total == "" ? "0" : s_NeedNumber_Total;

                               Sb_Details.Append("<td class=\"ListHeadDetails\">\n");
                               Sb_Details.Append("<a href=\"/Web/Sc/Sc_Plan_QLMaterial.aspx?ProductsBarCode=" + s_ProductsBarCode + "\" target=\"_blank\">" + GetColorNumber(s_NeedNumber_Total) + "</a>\n");
                               Sb_Details.Append("</td>\n");
                               */

                            Sb_Details.Append("<td class=\"ListHeadDetails\">\n");
                            Sb_Details.Append("<a href=\"/Web/Sc/Sc_Plan_QLMaterial.aspx?ProductsBarCode=" + s_ProductsBarCode + "&HouseNo=" + s_HouseNo + "\" target=\"_blank\">" + s_WareHouseNumber + "</a>\n");
                            Sb_Details.Append("</td>\n");
                            Sb_Details.Append("<td class=\"ListHeadDetails\">\n");
                            Sb_Details.Append("<a href=\"/Web/Sc/Sc_Plan_QLMaterial.aspx?ProductsBarCode=" + s_ProductsBarCode + "&HouseNo=" + s_HouseNo + "\" target=\"_blank\">" + GetColorNumber(s_NeedNumber) + "</a>\n");
                            Sb_Details.Append("</td>\n");
                        }
                        catch (Exception ex)
                        {
                        }

                        /*
                        if (s_Checked != "")
                        {
                            //找这供应商是否有下过该产品如果下过自动审批 没有不能自动审批
                            string s_Sql = "Select * from Knet_Procure_OrdersList_Details a join  Knet_Procure_OrdersList b on a.OrderNo=b.OrderNo ";
                            s_Sql += " where b.SuppNo='" + s_SuppNo + "' and a.ProductsBarCode='" + s_ProductsBarCode + "'";
                            this.BeginQuery(s_Sql);
                            DataTable Dtb_Table1 = (DataTable)this.QueryForDataTable();
                            if (Dtb_Table1.Rows.Count > 0)
                            {
                                s_Checked = "checked";
                            }
                            else
                            {
                                s_Checked = "";
                            }

                        }
                        */
                        s_Checked = "checked";
                        Sb_Details.Append("<td class=\"ListHeadDetails\">\n");
                        Sb_Details.Append("<input  id=\"Chk_IsMail_" + i.ToString() + "\" type=\"checkbox\"  enable=false name=\"Chk_IsMail_" + i.ToString() + "\"  " + s_Checked + " />20分钟发送邮件<br/>\n");
                        Sb_Details.Append("<input  id=\"Chk_IsCheck_" + i.ToString() + "\" type=\"checkbox\" enable=false  name=\"Chk_IsCheck_" + i.ToString() + "\"   " + s_Checked + "  />自动审核\n");
                        Sb_Details.Append("</td>\n");

                        Sb_Details.Append("</tr>\n");
                        Sb_Details.Append("<tr>\n");
                        Sb_Details.Append("<td class=\"ListHeadDetails\" colspan=\"12\">\n");

                        Sb_Details.Append("<div id=\"Div_" + i.ToString() + "\" style=\"display: none;\">\n");
                        Sb_Details.Append("<table width=\"100%\" width=\"100%\" border=\"0\" align=\"center\" cellspacing=\"0\" class=\"ListDetails\">\n");
                        Sb_Details.Append("<tr>\n");
                        Sb_Details.Append("<td class=\"ListHeadDetails\">备注\n");
                        Sb_Details.Append("</td>\n");
                        Sb_Details.Append("<td class=\"ListHeadDetails\" colspan=\"12\">\n");

                        Sb_Details.Append("<textarea  id=\"Tbx_Remarks_" + i.ToString() + "\" type=\"Text\" style=\"height:30px;width:700px;\" name=\"Tbx_Remarks_" + i.ToString() + "\"   /></textarea>\n");
                        Sb_Details.Append("</td>\n");
                        string s_Email = "", s_CcEmail = "", s_MsEmail = "", s_EmailTitle = "", s_EmailDetails = "", s_EmailPDF = "";
                        string s_SendEmail = "", s_SendSettingID = "", s_Selected = "";
                        try
                        {
                            /*   s_Email = "zxgggl@126.com";*/
                            KNet.BLL.Knet_Procure_Suppliers Bll_Supp = new KNet.BLL.Knet_Procure_Suppliers();
                            KNet.Model.Knet_Procure_Suppliers Model_Supp = Bll_Supp.GetModelB(s_SuppNo);
                            if (Model_Supp != null)
                            {
                                s_Email = Model_Supp.SuppEmail;
                            }
                            string s_Sql = "select top 1 * from PB_Basic_Mail where PBM_Type=1 and PBM_FID in (select OrderNo from Knet_Procure_OrdersList where SuppNo='" + s_SuppNo + "') order by PBM_MTime desc";
                            this.BeginQuery(s_Sql);
                            DataTable Dtb_Mail = (DataTable)this.QueryForDataTable();
                            if (Dtb_Mail.Rows.Count > 0)
                            {
                                s_SendEmail = Dtb_Mail.Rows[0]["PBM_SendEmail"].ToString();
                                s_SendSettingID = Dtb_Mail.Rows[0]["PBM_SendSettingID"].ToString();
                                s_Email = Dtb_Mail.Rows[0]["PBM_ReceiveEmail"].ToString();
                                s_CcEmail = Dtb_Mail.Rows[0]["PBM_Cc"].ToString();
                                s_MsEmail = Dtb_Mail.Rows[0]["PBM_Ms"].ToString();
                            }

                            s_EmailPDF = Server.MapPath("/Web/CG/Order/PDF/" + s_NewOrderNo + ".PDF");
                            s_EmailTitle = "博脉采购单：" + s_NewOrderNo + " 请尽快回复交期；详细见明细";
                            s_EmailDetails = "尊敬的 " + base.Base_GetSupplierName(s_SuppNo) + ":<br/>";
                            KNet.BLL.KNet_Resource_Staff Bll_Staff = new KNet.BLL.KNet_Resource_Staff();
                            KNet.Model.KNet_Resource_Staff Model_Staff = Bll_Staff.GetModelC(AM.KNet_StaffNo);
                            s_EmailDetails += "<font size=4>1)第一时间确认订单收到<br/>";
                            s_EmailDetails += "2)上午订单，当天下午<font Color=red size=5>3点</font>前务必确认交期并盖章回传<br/>";
                            s_EmailDetails += "3)下午订单，第二天中午<font Color=red size=5>11点</font>前务必确认交期并盖章回传<br/>";
                            s_EmailDetails += "以上要求请务必严格执行！任何特殊情况请提前告知！谢谢合作！</font><br/><p></p><p></p><hr>";
                            s_EmailDetails += "" + AM.KNet_StaffName + "<br/>";
                            s_EmailDetails += "采购部<br/>";
                            s_EmailDetails += "杭州士腾科技有限公司<br/>";
                            s_EmailDetails += "电话：" + Model_Staff.StaffTel + "<br/>";
                            s_EmailDetails += "传真：0571 8821 6187<br/>";
                            s_EmailDetails += "E-mail: " + Model_Staff.StaffEmail + "<br/>";
                            s_EmailDetails += "地址：西湖科技园西园九路7号<br/>";
                        }
                        catch
                        { }

                        Sb_Details.Append("</tr>\n");
                        Sb_Details.Append("<tr>\n");
                        Sb_Details.Append("<td class=\"ListHeadDetails\">发送人\n");
                        Sb_Details.Append("</td>\n");
                        Sb_Details.Append("<td class=\"ListHeadDetails\" colspan=\"12\" >\n");
                        Sb_Details.Append("<select name=\"SendEmail_" + i.ToString() + "\" id=\"SendEmail_" + i.ToString() + "\" class=\"detailedViewTextBox\" style=\"width:400px;\">");
                        try
                        {
                            KNet.BLL.PB_Mail_Setting bll = new KNet.BLL.PB_Mail_Setting();
                            string s_Where = " PMS_Creator='" + AM.KNet_StaffNo + "' and PMS_Del='0' order by PMS_MTime ";
                            DataSet ds = bll.GetList(s_Where);
                            for (int ii = 0; ii < ds.Tables[0].Rows.Count; ii++)
                            {
                                if (ds.Tables[0].Rows[ii]["PMS_ID"].ToString() == s_SendSettingID)
                                {
                                    s_Selected = "Selected";
                                }
                                else
                                { s_Selected = ""; }
                                if (ds.Tables[0].Rows[ii]["PMS_SendEmail"].ToString() == s_SendEmail)
                                {
                                    s_Selected = "Selected";
                                }
                                else
                                { s_Selected = ""; }
                                Sb_Details.Append("<option value=\"" + ds.Tables[0].Rows[ii]["PMS_ID"].ToString() + "\" " + s_Selected + ">" + ds.Tables[0].Rows[ii]["PMS_SendEmail"].ToString() + "</option>");
                            }
                        }
                        catch
                        { }
                        Sb_Details.Append("</select>");

                        Sb_Details.Append("</td>\n");
                        Sb_Details.Append("<tr>\n");
                        Sb_Details.Append("<tr>\n");
                        Sb_Details.Append("<td class=\"ListHeadDetails\">接收人\n");
                        Sb_Details.Append("</td>\n");
                        Sb_Details.Append("<td class=\"ListHeadDetails\" colspan=\"12\" >\n");
                        Sb_Details.Append("<input id=\"Tbx_EamilFile_" + i.ToString() + "\" type=\"hidden\" name=\"Tbx_EamilFile_" + i.ToString() + "\"  value=\"" + s_EmailPDF + "\" />\n");
                        Sb_Details.Append("<textarea  id=\"ReceiveEmail_" + i.ToString() + "\" type=\"Text\" style=\"height:30px;width:700px;\" name=\"ReceiveEmail_" + i.ToString() + "\"   />" + s_Email + "</textarea>\n");
                        Sb_Details.Append("</td>\n");
                        Sb_Details.Append("<tr>\n");
                        Sb_Details.Append("</tr>\n");
                        Sb_Details.Append("<td class=\"ListHeadDetails\">抄送\n");
                        Sb_Details.Append("</td>\n");
                        Sb_Details.Append("<td class=\"ListHeadDetails\" colspan=\"12\">\n");
                        Sb_Details.Append("<textarea  id=\"ReceiveCsEmail_" + i.ToString() + "\" type=\"Text\" style=\"height:30px;width:700px;\" name=\"ReceiveCsEmail_" + i.ToString() + "\" />" + s_CcEmail + "</textarea>\n");
                        Sb_Details.Append("</td>\n");
                        Sb_Details.Append("<tr>\n");
                        Sb_Details.Append("</tr>\n");
                        Sb_Details.Append("<td class=\"ListHeadDetails\">密送\n");
                        Sb_Details.Append("</td>\n");
                        Sb_Details.Append("<td class=\"ListHeadDetails\" colspan=\"12\">\n");
                        Sb_Details.Append("<textarea  id=\"ReceiveMsEmail_" + i.ToString() + "\" type=\"Text\" style=\"height:30px;width:700px;\" name=\"ReceiveMsEmail_" + i.ToString() + "\"   />" + s_MsEmail + "</textarea>\n");
                        Sb_Details.Append("</td>\n");
                        Sb_Details.Append("<tr>\n");
                        Sb_Details.Append("</tr>\n");
                        Sb_Details.Append("<td class=\"ListHeadDetails\">主题\n");
                        Sb_Details.Append("</td>\n");
                        Sb_Details.Append("<td class=\"ListHeadDetails\" colspan=\"12\">\n");
                        Sb_Details.Append("<textarea  id=\"ReceiveTitle_" + i.ToString() + "\" type=\"Text\" style=\"height:30px;width:700px;\" name=\"ReceiveTitle_" + i.ToString() + "\"   />" + s_EmailTitle + "</textarea>\n");
                        Sb_Details.Append("</td>\n");
                        Sb_Details.Append("<tr>\n");
                        Sb_Details.Append("</tr>\n");
                        Sb_Details.Append("<td class=\"ListHeadDetails\">内容\n");
                        Sb_Details.Append("</td>\n");
                        Sb_Details.Append("<td class=\"ListHeadDetails\" colspan=\"12\">\n");
                        Sb_Details.Append("<input id=\"EmailDetails_" + i.ToString() + "\"  name=\"EmailDetails_" + i.ToString() + "\"  value=\"" + s_EmailDetails + "\" />\n");
                        Sb_Details.Append("</td>\n");
                        Sb_Details.Append("</tr>\n");
                        Sb_Details.Append("</table>\n");
                        Sb_Details.Append("</div>\n");

                        Sb_Details.Append("</td>\n");
                        Sb_Details.Append("</tr>\n");
                    }
                    Sb_Details.Append("<input id=\"Tbx_Num\" type=\"hidden\" name=\"Tbx_Num\"  value=\"" + Dtb_Table.Rows.Count + "\" />\n");
                    //  this.Tbx_Address.Text = base.Base_GetSuppNoAddress(Model_Procure_OrderList.SuppNo).Replace("$", "\n");
                    this.Lbl_SDetail.Text = Sb_Details.ToString();
                }
            }
        }
        catch (Exception ex)
        {
            Alert(ex.Message);
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        this.Pan_Sc.Visible = false;

    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            AdminloginMess AM = new AdminloginMess();
            string s_DoSql = "update Knet_Procure_OrdersList set OrderCheckYN=1 where ParentOrderNo='" + this.Tbx_ID.Text + "'";
            DbHelperSQL.ExecuteSql(s_DoSql);

            AM.Add_Logs("采购订单批量审批->订单号：" + this.Tbx_ID.Text);
            Alert("操作成功");
        }
        catch
        { }
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        try
        {
            AdminloginMess AM = new AdminloginMess();
            string s_DoSql = "update Knet_Procure_OrdersList set OrderCheckYN=0 where ParentOrderNo='" + this.Tbx_ID.Text + "'";
            DbHelperSQL.ExecuteSql(s_DoSql);

            AM.Add_Logs("采购订单批量反审批->订单号：" + this.Tbx_ID.Text);
            Alert("操作成功");
        }
        catch
        { }
    }

    public string GetLefNumber(string s_KCNumber, string s_OrderNumber, string s_NeedNumber, decimal s_Number)
    {
        string s_return = "";
        try
        {
            decimal d_Left = -decimal.Parse(s_NeedNumber.Trim()) - decimal.Parse(s_OrderNumber.Trim()) - decimal.Parse(s_KCNumber.Trim()) - decimal.Parse(s_Number.ToString().Trim());
            if (d_Left > 0)
            {
                s_return = "<font color=red>" + d_Left.ToString() + "</font>";
            }
            else
            {
                s_return = "<font color=green>" + Math.Abs(d_Left).ToString() + "</font>";

            }
        }
        catch
        { }
        return s_return;
    }

    private string CreateOrderDetails(string s_Code)
    {
        string s_ReturnCode = "";
        try
        {
            AdminloginMess AM = new AdminloginMess();
            KNet.BLL.Knet_Procure_OrdersList BLL_Procure_OrdersList = new KNet.BLL.Knet_Procure_OrdersList();
            KNet.Model.Knet_Procure_OrdersList Model_Procure_OrderList = BLL_Procure_OrdersList.GetModelB(s_Code);
            string s_ContractAddress = Model_Procure_OrderList.ContractAddress;
            string sql = "Select a.*,b.ProductsBarCode,b.OrderAmount,d.SuppNo from Xs_Products_Prodocts a join Knet_Procure_OrdersList_Details b  on a.XPP_FaterBarCode=b.ProductsBarCode join Knet_Procure_OrdersList d on d.OrderNo=b.OrderNo join KNet_Sys_Products c on c.ProductsBarCode=a.XPP_ProductsBarCode where  b.OrderNo='" + s_Code + "'  ";
            this.BeginQuery(sql);
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {

                    string s_IsOrder = Dtb_Table.Rows[i]["XPP_IsOrder"].ToString();
                    string s_Address = Dtb_Table.Rows[i]["XPP_Address"].ToString();
                    if (s_IsOrder == "是")
                    {
                        string s_SuppNo = Dtb_Table.Rows[i]["XPP_SuppNo"].ToString();
                        string s_GoSuppNo = Dtb_Table.Rows[i]["SuppNo"].ToString();
                        string s_ProductsBarCode = Dtb_Table.Rows[i]["XPP_ProductsBarCode"].ToString();
                        string s_FaterProductsBarCode = Dtb_Table.Rows[i]["ProductsBarCode"].ToString();
                        int s_OrderNumber = int.Parse(Dtb_Table.Rows[i]["OrderAmount"].ToString());
                        string s_Price = Dtb_Table.Rows[i]["XPP_Price"].ToString();
                        int s_Number = int.Parse(base.FormatNumber(Dtb_Table.Rows[i]["XPP_Number"].ToString(), 0));

                        string s_NewOrderNo = KNetOddNumbers(s_SuppNo);
                        Model_Procure_OrderList.OrderNo = s_NewOrderNo;
                        Model_Procure_OrderList.SuppNo = s_SuppNo;
                        KNet.BLL.Knet_Procure_Suppliers Bll_Supp = new KNet.BLL.Knet_Procure_Suppliers();
                        KNet.Model.Knet_Procure_Suppliers Model_Supp = Bll_Supp.GetModelB(s_SuppNo);
                        Model_Procure_OrderList.OrderType = Model_Supp.KPS_Type;
                        //如果有没有上级订单
                        if (Model_Procure_OrderList.ParentOrderNo == "")
                        {
                            Model_Procure_OrderList.ParentOrderNo = s_Code;
                            if (s_Address == "0")
                            {
                                Model_Procure_OrderList.ContractAddress = base.Base_GetSuppNoAddress(s_GoSuppNo).Replace("$", "\n");
                                Model_Procure_OrderList.ReceiveSuppNo = s_GoSuppNo;
                            }
                            else
                            {
                                Model_Procure_OrderList.ContractAddress = s_ContractAddress;
                            }
                        }

                        KNet.BLL.Knet_Procure_OrdersList_Details BLL = new KNet.BLL.Knet_Procure_OrdersList_Details();
                        KNet.Model.Knet_Procure_OrdersList_Details Model = new KNet.Model.Knet_Procure_OrdersList_Details();
                        Model.ID = GetMainID(i);
                        Model.ProductsBarCode = s_ProductsBarCode;
                        Model.OrderNo = s_NewOrderNo;
                        Model.Add_DateTime = DateTime.Now;
                        Model.HandPrice = 0;
                        Model.HandTotal = 0;
                        Model.OrderDiscount = 0;
                        Model.OrderHasReturned = 0;
                        Model.OrderHaveReceiving = 0;
                        Model.OrderAmount = s_Number * s_OrderNumber;
                        Model.OrderUnitPrice = decimal.Parse(s_Price);
                        Model.OrderTotalNet = decimal.Parse(s_Price) * s_Number * s_OrderNumber;
                        Model.ProductsName = base.Base_GetProdutsName(s_ProductsBarCode);
                        Model.ProductsPattern = base.Base_GetProductsPattern(s_ProductsBarCode);
                        Model.ProductsUnits = base.Base_GetProductsUnits(s_ProductsBarCode);
                        //查找该供应商该OEM订单是否已经生成过
                        this.BeginQuery("Select * From Knet_Procure_OrdersList where ParentOrderNo='" + Model_Procure_OrderList.ParentOrderNo + "' and OrderNo<>'" + s_Code + "' and SuppNo='" + s_SuppNo + "'");
                        this.QueryForDataTable();
                        DataTable Dtb_HsTable = Dtb_Result;
                        if (Dtb_HsTable.Rows.Count > 0)
                        {
                            Model.OrderNo = Dtb_HsTable.Rows[0]["OrderNo"].ToString();
                        }
                        else
                        {
                            BLL_Procure_OrdersList.Add(Model_Procure_OrderList);
                            s_ReturnCode += Model_Procure_OrderList.OrderNo + ",";
                        }
                        BLL.Add(Model);
                        AM.Add_Logs("采购订单生成->订单号：" + s_ReturnCode);
                        //
                    }
                }
            }
            else
            {
            }
        }
        catch (Exception ex)
        {
            Alert(ex.Message);
        }
        return s_ReturnCode;
    }

    protected void btn_Chcek_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        if (btn_Chcek.Text == "审批")
        {
            //this.Button1.Enabled = false;
            string DoSql = "update Knet_Procure_OrdersList  set OrderCheckYN=1,OrderCheckStaffNo ='" + AM.KNet_StaffNo + "',OrderState=1  where  OrderNo='" + this.Tbx_ID.Text + "' ";
            DbHelperSQL.ExecuteSql(DoSql);
            btn_Chcek.Text = "反审批";
        }
        else
        {
            // this.Button1.Enabled = true;
            string DoSql = "update Knet_Procure_OrdersList  set OrderCheckYN=0,OrderCheckStaffNo ='',OrderState=0  where  OrderNo='" + this.Tbx_ID.Text + "' ";
            DbHelperSQL.ExecuteSql(DoSql);
            btn_Chcek.Text = "审批";

        }

        try
        {
            KNet.BLL.Knet_Procure_OrdersList Bll = new KNet.BLL.Knet_Procure_OrdersList();
            KNet.Model.Knet_Procure_OrdersList Model = Bll.GetModelB(this.Tbx_ID.Text);
            string JSD = "CG/Order/Knet_Procure_OpenBilling_Print.aspx?ID=" + Model.ID + "";
            base.HtmlToPdf1(JSD, Server.MapPath("PDF"), this.Tbx_ID.Text);
            Alert("审批成功！");
        }
        catch { }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        KNet.BLL.Knet_Procure_OrdersList Bll = new KNet.BLL.Knet_Procure_OrdersList();
        KNet.Model.Knet_Procure_OrdersList Model = Bll.GetModelB(this.Tbx_ID.Text);
        string JSD = "CG/Order/Knet_Procure_OpenBilling_Print.aspx?ID=" + Model.ID + "";
        if (base.HtmlToPdf1(JSD, Server.MapPath("PDF"), this.Tbx_ID.Text))
        {
            Alert("生成成功！");
        }
    }
}
