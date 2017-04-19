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
    public string s_MyTable_Detail = "", s_OrderStyle = "", s_DetailsStyle = "", s_Details1 = "",s_OrderID="", s_Details2 = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        KNet.BLL.Knet_Procure_OrdersList bll = new KNet.BLL.Knet_Procure_OrdersList();
        this.Lbl_Title.Text = "查看采购订单";
        AdminloginMess AM = new AdminloginMess();
        if (AM.CheckLogin("查看采购单") == false)
        {
            BasePage.AlertAndRedirect("您未登陆系统或已超过，请重新登陆系统!", "Default.aspx");
        }
        string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
        string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
        this.Tbx_ID.Text = s_ID;
        s_OrderID=s_ID;
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

            GridView1.DataSource = ds.Tables[0];
            GridView1.DataKeyNames = new string[] { "OrderNo" };
            GridView1.DataBind();
        }
        else
        {
            s_DetailsStyle = "class=\"dvtUnSelectedCell\"";
            s_OrderStyle = "class=\"dvtSelectedCell\"";
            Pan_Order.Visible = true;
            Table_Btn.Visible = true;
        }
        if (this.Lbl_OrderType.Text != "成品采购")
        {
            //
            KNet.Model.Knet_Procure_OrdersList Model = bll.GetModelB(s_ID);
            string s_FID = Model.ParentOrderNo;
            if (s_FID != "")
            {
                string SqlWhere = " ParentOrderNo='" + s_FID + "' order by SYstemDateTimes desc";

                DataSet ds = bll.GetList(SqlWhere);
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataKeyNames = new string[] { "OrderNo" };
                GridView1.DataBind();
            }
            //s_Details1 = "<iframe  runat=\"server\"  style=\"width: 100%; height: 800px\" id=\"Iframe1\" name=\"top\" marginheight=\"0\" src=\"/Web/Sc/Sc_Plan_Material.aspx?OrderNo=" + s_FID + "\" frameborder=\"0\"></iframe>";
      

            this.Lbl_Link.Text = "<a href=\"/Web/CG/OrderInWareHouse/Knet_Procure_WareHouseList_Add.aspx?OrderNo=" + s_ID + "\" class=\"webMnu\">创建入库单</a> ";
            this.Lbl_Link1.Text = "<a href=\"/Web/CG/Payment/CG_Payment_For_Add.aspx?OrderNo=" + s_ID + "\" class=\"webMnu\">创建用款申请</a> ";

            
        }
        else
        {

            string SqlWhere = " ParentOrderNo='" + s_ID + "' order by SYstemDateTimes desc";
            DataSet ds = bll.GetList(SqlWhere);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataKeyNames = new string[] { "OrderNo" };
            GridView1.DataBind();
            s_Details1 = "<iframe  runat=\"server\"  style=\"width: 100%; height: 800px\" id=\"Iframe1\" name=\"top\" marginheight=\"0\" src=\"/Web/Sc/Sc_Plan_Material.aspx?OrderNo=" + s_ID + "\" frameborder=\"0\"></iframe>";
            this.Lbl_Link.Text = "<a href=\"/Web/ScExpend/Sc_Expend_Add.aspx?OrderNo=" + s_ID + "\" class=\"webMnu\">创建入库单</a> ";
        }
        this.BeginQuery("Select Sum(isnull(cast( OrderCheckYN as int),0)) from Knet_Procure_OrdersList where ParentOrderNo='" + this.Tbx_ID.Text + "'");
        string s_Return = this.QueryForReturn();
        s_Return = s_Return == "" ? "0" : s_Return.ToString();
        if (int.Parse(s_Return) > 0)
        {
            this.Button1.Enabled = false;
        }

        this.Button1.Attributes.Add("onclick", "return confirm('生成将清除原有生成的采购子订单，是否继续？')");
        this.Button3.Attributes.Add("onclick", "return confirm('关闭该订单，是否继续？')");
        this.Btn_Change.Attributes.Add("onclick", "return confirm('确定更换OEM，是否继续？')");

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

        this.Lbl_HouseNo.Text = base.Base_GetHouseName(Model.KPO_PreHouseNo);
        //KNet.BLL.KNet_Sys_CheckMethod Bll_M = new KNet.BLL.KNet_Sys_CheckMethod();
        //DataSet Dts_Table1 = Bll_M.GetList(" CheckNo='" + Model.OrderPaymentNotes + "'");
        //if (Dts_Table1.Tables[0].Rows.Count > 0)
        //{
        //    this.Lbl_Payment.Text = Dts_Table1.Tables[0].Rows[0]["CheckName"].ToString();
        //}
        this.Lbl_ParentOrderNo.Text = "<a href=\"Knet_Procure_OpenBilling_View.aspx?ID=" + Model.ParentOrderNo + "\">" + Model.ParentOrderNo + "</a>";
        this.Lbl_ContractNo.Text = "";
        string[] s_ContractNo = Model.ContractNos.Split(',');
        for (int i = 0; i < s_ContractNo.Length; i++)
        {
            this.Lbl_ContractNo.Text += "<a href=\"../../SalesContract/Xs_ContractList_View.aspx?ID=" + s_ContractNo[i] + "\" >" + s_ContractNo[i] + "</a><br>";

        }
        this.Lbl_SelectSupp.Text = base.Base_GetSupplierName_Link(Model.ReceiveSuppNo);
        this.Lbl_Depart.Text = base.Base_GeDept(Model.OrderStaffDepart);
        this.Lbl_OrderType.Text = base.base_GetProcureTypeNane(Model.OrderType);
        this.Lbl_Address.Text = KNetPage.KHtmlDiscode(Model.ContractAddress.Replace("\n", "<br/>"));
        this.Lbl_Remarks.Text = Model.OrderRemarks;

        if (Model.KPO_PriceState == 1)
        {
            this.Lbl_PriceState.Text = "<font color=red>是</font>";
        }
        else
        {
            this.Lbl_PriceState.Text = "否";
        }
        AdminloginMess AM = new AdminloginMess();

        if (Model.OrderCheckYN == true)
        {
            btn_Chcek.Text = "反审批";
            this.Button1.Enabled = false;
        }
        else
        {
            btn_Chcek.Text = "审批";
            this.Button1.Enabled = true;

        }
        if (Model.KPO_IsStopProduce == 0)
        {

            this.btn_Sc.Text = "暂停生产";
        }
        else
        {

            this.btn_Sc.Text = "恢复生产";
        }
        if (Model.KPO_Del == 1)
        {

            this.Button3.Text = "启用订单";
        }
        else
        {
            this.Button3.Text = "关闭订单";
        }
        /*
        if (((AM.KNet_StaffDepart != "129652783965723459") || (AM.KNet_Position != "102")) && (AM.KNet_StaffDepart != "129652784259578018"))//如果是研发中心经理显示
        {
            btn_Chcek.Enabled = false;
        }
        else
        {
            btn_Chcek.Enabled = true;
        }
         * */
        this.lbl_isRuk.Text = base.Base_GetBasicCodeName("126", Model.rkState);
        this.Lbl_IsPayMent.Text = base.Base_GetBasicCodeName("127", Model.KPO_PayState);
        this.Lbl_PDF.Text = "<a href=\"PDF/" + Model.OrderNo + ".PDF\" target=\"_blank\">" + Model.OrderNo + ".PDF</a>";
        KNet.BLL.Knet_Procure_OrdersList_Details Bll_Details = new KNet.BLL.Knet_Procure_OrdersList_Details();
        DataSet Dts_Table = Bll_Details.GetList(" a.OrderNo='" + s_ID + "' order by isnull(e.XPD_Order,0)");

        decimal d_All_OrderTotal = 0, d_All_HandTotal = 0, d_All_Total = 0, d_All_TotalNeNum = 0, d_All_WrkTotalNeNum = 0; ;
        bool b_boll = false;
        if (Dts_Table.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
            {
                decimal d_Amount = Decimal.Parse(Dts_Table.Tables[0].Rows[i]["OrderTotalNet"].ToString() == "" ? "0" : Dts_Table.Tables[0].Rows[i]["OrderTotalNet"].ToString()) + Decimal.Parse(Dts_Table.Tables[0].Rows[i]["HandTotal"].ToString() == "" ? "0" : Dts_Table.Tables[0].Rows[i]["HandTotal"].ToString());
                d_All_OrderTotal += Decimal.Parse(Dts_Table.Tables[0].Rows[i]["OrderTotalNet"].ToString() == "" ? "0" : Dts_Table.Tables[0].Rows[i]["OrderTotalNet"].ToString());
                d_All_HandTotal += Decimal.Parse(Dts_Table.Tables[0].Rows[i]["HandTotal"].ToString() == "" ? "0" : Dts_Table.Tables[0].Rows[i]["HandTotal"].ToString());
                d_All_Total += d_Amount;
                s_MyTable_Detail += " <tr>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" +Convert.ToString(i+1)+ "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + Dts_Table.Tables[0].Rows[i]["XPD_Order"].ToString() + "</td>";

                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetProdutsName_Link(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                s_MyTable_Detail += "<td  class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetProductsCode(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                s_MyTable_Detail += "<td  class=\"ListHeadDetails\" nowrap align=\"center\">" + base.Base_GetProductsEdition(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["KPOD_CPBZNumber"].ToString(), 0) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["KPOD_BZNumber"].ToString(), 0) + "</td>";

                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["OrderAmount"].ToString(), 0) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["OrderUnitPrice"].ToString(), 4) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["HandPrice"].ToString(), 4) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_Amount.ToString(), 3) + "</td>";
                string s_WrkNumber = FormatNumber1(Dts_Table.Tables[0].Rows[i]["wrkNumber"].ToString() == "" ? "0" : Dts_Table.Tables[0].Rows[i]["wrkNumber"].ToString(), 0);
                d_All_WrkTotalNeNum += int.Parse(s_WrkNumber);
                d_All_TotalNeNum += int.Parse(Dts_Table.Tables[0].Rows[i]["OrderAmount"].ToString());
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + s_WrkNumber + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + Dts_Table.Tables[0].Rows[i]["OrderRemarks"].ToString() + "</td>";
                s_MyTable_Detail += " </tr>";
                //如果这个产品是第一次下单则显示第一次下单需研发审批
              /*  string s_Sql = "Select * from Knet_Procure_OrdersList_Details a join Knet_Procure_OrdersList b on a.OrderNo=b.OrderNO ";
                s_Sql += " and b.SuppNo='" + Model.SuppNo + "' and ProductsBarCode='" + Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "' and a.OrderNo <>'" + Model.OrderNo + "' ";
                this.BeginQuery(s_Sql);
                DataTable Dtb_Table = (DataTable)this.QueryForDataTable();
                if (Dtb_Table.Rows.Count <= 0)
                {
                    this.Lbl_State.Text = "<font color=red>第一次下单<br/>需研发经理审批</font>";
                    b_boll = true;
                }
               * */
            }

            s_MyTable_Detail += " <tr>";
            s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\" colspan=7>合计：</td>";
            s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_All_TotalNeNum.ToString(), 0) + "</td>";

            s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\" colspan=2>&nbsp;</td>";
            s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_All_Total.ToString(), 2) + "</td>";
            s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_All_WrkTotalNeNum.ToString(), 0) + "</td>";

            s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">&nbsp;</td>";

            s_MyTable_Detail += " </tr>";
            /* 
            if (b_boll)
            {
                if ((AM.KNet_Position == "102") && (AM.KNet_StaffDepart == "129652783965723459"))
                {
                    btn_Chcek.Enabled = true;
                }
                else
                {
                    btn_Chcek.Enabled = false;
                }
            }
            */
            try
            {

                KNet.BLL.Knet_Procure_WareHouseList bll = new KNet.BLL.Knet_Procure_WareHouseList();
                DataSet ds = bll.GetList(" KPW_Del='0' and Knet_Procure_WareHouseList.OrderNo='" + s_ID + "'");
                MyGridView1.DataSource = ds;
                MyGridView1.DataBind();
            }
            catch
            { }

            try
            {
                KNet.BLL.Sc_Expend_Manage bll_Expend = new KNet.BLL.Sc_Expend_Manage();
                DataSet ds_Expend = bll_Expend.GetList("SEM_ID In (select SER_SEMID from Sc_Expend_Manage_RCDetails a  join  Knet_Procure_OrdersList_Details b on a.SER_OrderDetailID=b.ID where OrderNo='" + s_ID + "') ");

                MyGridView2.DataSource = ds_Expend;
                MyGridView2.DataKeyNames = new string[] { "SEM_ID" };
                MyGridView2.DataBind();
            }
            catch
            { }


            try
            {
                KNet.BLL.PB_Basic_Mail bll_Mail = new KNet.BLL.PB_Basic_Mail();
                string s_Sql = "PBM_Del in (0,2) and PBM_FID='" + Model.OrderNo + "' and PBM_Type=1 ";
                s_Sql += " Order by PBM_CTime desc";
                DataSet ds_Mail = bll_Mail.GetList(s_Sql);
                MyGridView3.DataSource = ds_Mail;
                MyGridView3.DataKeyNames = new string[] { "PBM_ID" };
                MyGridView3.DataBind();
            }
            catch
            { }

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
    public string GetState(string s_State,string s_Del)
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



    protected void Btn_Change_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Knet_Procure_OpenBilling.aspx?ID="+this.Tbx_ID.Text+"&IsChange=1");

        }
        catch
        { }

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
            AM.Add_Logs("删除子订单：成品订单号：" + this.Tbx_ID.Text + "");
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
            base.Base_SendMessage(Base_GetDeptPerson("研发中心", 1), KNetPage.KHtmlEncode("有 成品订单 <a href='Web/Order/Knet_Procure_OpenBilling_View.aspx?ID=" + this.Tbx_ID.Text + "'  onclick=\"RemoveSms('" + base.GetNewID("System_Message_Manage", 0) + "', '', 0);\"> " + this.Tbx_ID.Text + "</a> 生成的相关订单需要您审批，敬请关注！"));

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
            if (s_isNullSuppNo != "")
            {
                Alert("" + s_ProductsName + "未报价!BOM配件不能生成子订单!请先增加报价！");
                return;
            }
            else
            {
                for (int i = 0; i < i_Num; i++)
                {
                    string s_Check = Request["Chk_Check_" + i.ToString() + ""] == null ? "" : Request["Chk_Check_" + i.ToString() + ""].ToString();
                    string s_ProductsBarCode = Request["Tbx_ProductsBarCode_" + i.ToString() + ""] == null ? "" : Request["Tbx_ProductsBarCode_" + i.ToString() + ""].ToString();
                    string s_NewOrderNo = Request["Tbx_OrderNo_" + i.ToString() + ""] == null ? "" : Request["Tbx_OrderNo_" + i.ToString() + ""].ToString();
                    string s_PreToDate = Request["Tbx_OrderPreDate_" + i.ToString() + ""] == null ? "" : Request["Tbx_OrderPreDate_" + i.ToString() + ""].ToString();
                    string s_Address = Request["Tbx_Address"] == null ? "" : Request["Tbx_Address"].ToString();
                    string s_Remarks = Request["Tbx_Remarks_" + i.ToString() + ""] == null ? "" : Request["Tbx_Remarks_" + i.ToString() + ""].ToString();
                    string s_Number = Request["Tbx_Number_" + i.ToString() + ""] == null ? "" : Request["Tbx_Number_" + i.ToString() + ""].ToString();
                    string s_Price = Request["Tbx_Price_" + i.ToString() + ""] == null ? "" : Request["Tbx_Price_" + i.ToString() + ""].ToString();
                    string s_SuppNo = Request["Tbx_SuppNo_" + i.ToString() + ""] == null ? "" : Request["Tbx_SuppNo_" + i.ToString() + ""].ToString();
                    string s_OrderType = Request["Tbx_OrderType_" + i.ToString() + ""] == null ? "" : Request["Tbx_OrderType_" + i.ToString() + ""].ToString();
                    string s_ProductsCode = Request["Tbx_ProductsCode_" + i.ToString() + ""] == null ? "" : Request["Tbx_ProductsCode_" + i.ToString() + ""].ToString();

                    string s_Chk_IsMail = Request["Chk_IsMail_" + i.ToString() + ""] == null ? "" : Request["Chk_IsMail_" + i.ToString() + ""].ToString();
                    string s_Chk_IsCheck = Request["Chk_IsCheck_" + i.ToString() + ""] == null ? "" : Request["Chk_IsCheck_" + i.ToString() + ""].ToString();


                    if (s_Check != "")
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
                        Model_Procure_OrderList.OrderRemarks = s_Remarks;
                        Model_Procure_OrderList.ParentOrderNo = Model_Procure_OrderList.OrderNo;
                        Model_Procure_OrderList.SuppNo = s_SuppNo;
                        Model_Procure_OrderList.OrderNo = s_NewOrderNo;
                        Model_Procure_OrderList.KPO_ScDetails = "";
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
                        #endregion

                        //如果这个订单号生成过则只删除主表
                        //如果是不同合同编号则不删除
                        KNet.BLL.PB_Basic_Mail Bll_Mail = new KNet.BLL.PB_Basic_Mail();
                        string s_IsModiy = "";
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
                                BLL_Procure_OrdersList.Add(Model_Procure_OrderList);
                                try
                                {
                                    if (int.Parse(s_IsModiy) <= 0)
                                    {
                                        if (s_Chk_IsMail != "")
                                        {
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
                                            model.PBM_Minute = 10 * 60;//10分钟后
                                            model.PBM_SendSettingID = s_SendEmail;
                                            Bll_Mail.Add(model);
                                        }
                                    }

                                }
                                catch
                                {
                                }
                            }
                            else
                            {
                                Model_Procure_OrderList.OrderNo = KNetOddNumbers(s_SuppNo);
                                Model_Order.OrderNo = Model_Procure_OrderList.OrderNo;
                                #region 明细表赋值

                                Model.ID = GetMainID(i);
                                Model.ProductsBarCode = s_ProductsBarCode;
                                string s_Sql = "Select KSP_isModiy from KNet_Sys_Products ";
                                s_Sql += " where ProductsBarCode='" + s_ProductsBarCode + "' ";
                                this.BeginQuery(s_Sql);
                                s_IsModiy = this.QueryForReturn();

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
                                //查找该供应商是否已经生成过
                                ArrayList arr_Details = new ArrayList();
                                arr_Details.Add(Model);
                                Model_Procure_OrderList.Arr_ProductsList = arr_Details;
                                #endregion

                                #region 邮件发送

                                try
                                {
                                    if (int.Parse(s_IsModiy) <= 0)
                                    {
                                        if (s_Chk_IsMail != "")
                                        {
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
                                            model.PBM_Minute = 10 * 60;//10分钟后
                                            model.PBM_SendSettingID = s_SendEmail;
                                            Bll_Mail.Add(model);
                                        }
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
                            string s_Sql = "Select KSP_isModiy from KNet_Sys_Products ";
                            s_Sql += " where ProductsBarCode='" + s_ProductsBarCode + "' ";
                            this.BeginQuery(s_Sql);
                            s_IsModiy = this.QueryForReturn();

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
                            //查找该供应商是否已经生成过
                            ArrayList arr_Details = new ArrayList();
                            arr_Details.Add(Model);
                            Model_Procure_OrderList.Arr_ProductsList = arr_Details;
                            #endregion

                            #region 邮件发送

                            try
                            {
                                if (int.Parse(s_IsModiy) <= 0)
                                {
                                    if (s_Chk_IsMail != "")
                                    {
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
                                        model.PBM_Minute = 10 * 60;//10分钟后
                                        model.PBM_SendSettingID = s_SendEmail;
                                        Bll_Mail.Add(model);
                                    }
                                }

                            }
                            catch
                            {
                            }
                            #endregion

                            BLL_Procure_OrdersList.Add(Model_Procure_OrderList);
                        }
                        s_ReturnCode += Model_Procure_OrderList.OrderNo + ",";
                        try
                        {
                            string JSD = "CG/Order/Knet_Procure_OpenBilling_Print.aspx?ID=" + s_ID + "";
                            base.HtmlToPdf1(JSD, Server.MapPath("PDF"), Model.OrderNo);
                            s_Message = "生成PDF成功";
                        }
                        catch
                        {
                            s_Message = "生成PDF失败";
                        }
                    }

                }
                AM.Add_Logs("采购订单生成->" + s_Message + " 订单号：" + s_ReturnCode);
                AlertAndRedirect("采购订单生成 " + s_Message + " 操作成功", "Knet_Procure_OpenBilling_Manage.aspx");
            }
        }
        catch (Exception ex) { }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {

        try
        {
            string s_Sql1 = "select * from v_OrderRK where v_OrderNo='" + this.Tbx_ID.Text + "' ";
            this.BeginQuery(s_Sql1);
            DataTable Dtb_Table = (DataTable)this.QueryForDataTable();
            if (Dtb_Table.Rows.Count > 0)
            {
                if (this.Button3.Text == "关闭订单")
                {
                    this.Button3.Text = "启用订单";
                    string s_Sql = "update Knet_Procure_OrdersList set KPO_Del='1' where OrderNo ='" + this.Tbx_ID.Text + "' ";
                    DbHelperSQL.ExecuteSql(s_Sql);
                    Alert("订单关闭成功！");
                }
                else
                {
                    this.Button3.Text = "关闭订单";
                    string s_Sql = "update Knet_Procure_OrdersList set KPO_Del='0' where OrderNo ='" + this.Tbx_ID.Text + "' ";
                    DbHelperSQL.ExecuteSql(s_Sql);
                    Alert("启用订单成功！");
                }
            }
        }
        catch { }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            AdminloginMess AM = new AdminloginMess();
            //删除


            //锁定生成
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

                this.Pan_Sc.Visible = true;
                string sql = "Select e.SuppNo as XPDSuppNo,isnull(e.ProcureUnitPrice,0)+isnull(e.HandPrice,0)  as XPDPrice,a.*,b.ProductsBarCode,b.OrderAmount,d.SuppNo,c.ProductsMainCategory,c.ProductsType from Xs_Products_Prodocts_Demo a join Knet_Procure_OrdersList_Details b  on a.XPD_FaterBarCode=b.ProductsBarCode join Knet_Procure_OrdersList d on d.OrderNo=b.OrderNo join KNet_Sys_Products c on c.ProductsBarCode=a.XPD_ProductsBarCode";
                sql += " left join Knet_Procure_SuppliersPrice e on e.ProductsBarCode=a.XPD_ProductsBarCode and e.KPP_Del=0 and e.KPP_State=1 ";
                sql += " where  b.OrderNo='" + s_Code + "'  and c.KSP_Del=0 order by c.ProductsType,c.KSP_Code,XPD_ReplaceProductsBarCode,e.SuppNo ";
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
                        string s_ProductsBarCode = Dtb_Table.Rows[i]["XPD_ProductsBarCode"].ToString();
                        string s_ReplaceProductsBarCode = Dtb_Table.Rows[i]["XPD_ReplaceProductsBarCode"].ToString();
                        string s_FaterProductsBarCode = Dtb_Table.Rows[i]["ProductsBarCode"].ToString();
                        int s_OrderNumber = int.Parse(Dtb_Table.Rows[i]["OrderAmount"].ToString());
                        string s_Price = Dtb_Table.Rows[i]["XPDPrice"].ToString();
                        string s_ProductsType = Dtb_Table.Rows[i]["ProductsType"].ToString();
                        int s_Number = int.Parse(base.FormatNumber(Dtb_Table.Rows[i]["XPD_Number"].ToString(), 0));
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
                        Sb_Details.Append("<input id=\"Tbx_OrderNo_" + i.ToString() + "\" type=\"hidden\" name=\"Tbx_OrderNo_" + i.ToString() + "\"  value=\"" + s_NewOrderNo + "\" />\n");

                        string s_Checked = "";
                        if ((s_NewOrderNo != "") && (s_ReplaceProductsBarCode == ""))
                        {
                            s_Checked = "checked";
                        }
                        Sb_Details.Append("<input id=\"Chk_Check_" + i.ToString() + "\" type=\"checkbox\" name=\"Chk_Check_" + i.ToString() + "\" " + s_Checked + " />\n");
                        Sb_Details.Append("" + base.Base_GetProductsType(s_ProductsType) + "<a href=\"#\" onclick=\"ShowDivByID(" + i.ToString() + ")\">明细</a>\n");
                        Sb_Details.Append("</td>\n");
                        Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                        Sb_Details.Append("<input id=\"Tbx_SuppNo_" + i.ToString() + "\" type=\"hidden\" name=\"Tbx_SuppNo_" + i.ToString() + "\"  value=\"" + s_SuppNo + "\" />" + base.Base_GetSupplierName_Link(s_SuppNo) + "\n");
                        Sb_Details.Append("<input id=\"Tbx_OrderType_" + i.ToString() + "\" type=\"hidden\" name=\"Tbx_OrderType_" + i.ToString() + "\"  value=\"" + s_OrderType + "\" />\n");

                        Sb_Details.Append("</td>\n");

                        Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                        Sb_Details.Append("<input id=\"Tbx_ProductsBarCode_" + i.ToString() + "\" type=\"hidden\" name=\"Tbx_ProductsBarCode_" + i.ToString() + "\"  value=\"" + s_ProductsBarCode + "\" /><input id=\"Tbx_ProductsCode_" + i.ToString() + "\" type=\"hidden\" name=\"Tbx_ProductsCode_" + i.ToString() + "\"  value=\"" + base.Base_GetProductsCode(s_ProductsBarCode) + "\" />" + base.Base_GetProductsCode(s_ProductsBarCode) + "\n");
                        Sb_Details.Append("</td>\n");
                        Sb_Details.Append("<td class=\"ListHeadDetails\" width=\"150px\">\n");
                        Sb_Details.Append("" + base.Base_GetProductsEdition_Link(s_ProductsBarCode) + "\n");
                        Sb_Details.Append("</td>\n");
                        Sb_Details.Append("<td class=\"ListHeadDetails\" width=\"150px\">\n");
                        //如果是silan 1000-5000 +5 5000以上+10
                        if (s_SuppNo == "129682186266972172")
                        {
                            decimal d_totalNet = s_Number * s_OrderNumber;
                            if (s_Number <= 5000)
                            {
                                d_totalNet += 5;
                            }
                            else
                            {
                                d_totalNet += 10;
                            }
                            Sb_Details.Append("<input id=\"Tbx_Number_" + i.ToString() + "\" type=\"input\" name=\"Tbx_Number_" + i.ToString() + "\"  value=\"" + d_totalNet + "\" />\n");
                        }
                        else
                        {
                            Sb_Details.Append("<input id=\"Tbx_Number_" + i.ToString() + "\" type=\"input\" name=\"Tbx_Number_" + i.ToString() + "\"  value=\"" + s_Number * s_OrderNumber + "\" />\n");
                        }
                        Sb_Details.Append("</td>\n");
                        string s_NewPrice = "";
                        this.BeginQuery("select top 1 ProcureUnitPrice from Knet_Procure_SuppliersPrice where SuppNo='" + s_SuppNo + "' and ProcureUnitPrice<>'" + s_Price + "' and ProductsBarCode='" + s_ProductsBarCode + "' and KPP_Del=0  and e.KPP_State=1 order by ProcureUpdateDateTime desc ");
                        s_NewPrice = this.QueryForReturn();

                        Sb_Details.Append("<td class=\"ListHeadDetails\" >\n");
                        Sb_Details.Append("<input id=\"Tbx_Price_" + i.ToString() + "\" type=\"hidden\" name=\"Tbx_Price_" + i.ToString() + "\"  value=\"" + s_Price + "\" />" + s_Price + "\n");
                        if (s_NewPrice != "")
                        {
                            Sb_Details.Append("<font color=red>" + s_NewPrice + "</font>");
                        }
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
                            KNet.BLL.KNet_Sys_WareHouse Bll_WareHouse = new KNet.BLL.KNet_Sys_WareHouse();
                            KNet.Model.KNet_Sys_WareHouse Model_WareHouse = Bll_WareHouse.GetModelBySuppNo(s_GoSuppNo);
                            string s_HouseNo = Model_WareHouse.HouseNo == null ? "" : Model_WareHouse.HouseNo.ToString();

                            string s_OrderLeftNumber = "0";
                            string s_WareHouseNumber = "0";
                            string s_NeedNumber = "0";

                            string s_WareHouseNumber_Total = "0";
                            string s_OrderLeftNumber_Total = "0";
                            string s_NeedNumber_Total = "0";
                            /*
                            s_OrderLeftNumber = base.Base_GetOrderWrkNumber(s_ProductsBarCode, s_HouseNo) == "-" ? "0" : base.Base_GetOrderWrkNumber(s_ProductsBarCode, s_HouseNo);
                            s_WareHouseNumber = base.Base_GetHouseAndNumber1(s_ProductsBarCode, s_HouseNo);
                            s_NeedNumber = base.Base_GetHouseAndNeedNumber1(s_ProductsBarCode, s_HouseNo);

                            s_WareHouseNumber_Total = base.Base_GetHouseAndNumber1(s_ProductsBarCode, "");
                            s_OrderLeftNumber_Total = base.Base_GetOrderWrkNumber(s_ProductsBarCode, "");
                            s_NeedNumber_Total = base.Base_GetHouseAndNeedNumber1(s_ProductsBarCode, "");
                            */
                            Sb_Details.Append("<td class=\"ListHeadDetails\">\n");
                            Sb_Details.Append("<a href=\"/Web/Sc/Sc_Plan_QLMaterial.aspx?ProductsBarCode=" + s_ProductsBarCode + "\" target=\"_blank\">" + GetLefNumber(s_WareHouseNumber_Total, s_OrderLeftNumber_Total, s_NeedNumber_Total, s_Number * s_OrderNumber) + "</a>\n");
                            Sb_Details.Append("</td>\n");

                            Sb_Details.Append("<td class=\"ListHeadDetails\">\n");
                            Sb_Details.Append("<a href=\"/Web/Sc/Sc_Plan_QLMaterial.aspx?ProductsBarCode=" + s_ProductsBarCode + "&HouseNo=" + s_HouseNo + "\" target=\"_blank\">" + GetLefNumber(s_WareHouseNumber, s_OrderLeftNumber, s_NeedNumber, s_Number * s_OrderNumber) + "</a>\n");
                            Sb_Details.Append("</td>\n");
                        }
                        catch
                        { }


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
                        Sb_Details.Append("<td class=\"ListHeadDetails\">\n");
                        Sb_Details.Append("<input  id=\"Chk_IsMail_" + i.ToString() + "\" type=\"checkbox\"  enable=false name=\"Chk_IsMail_" + i.ToString() + "\"  " + s_Checked + " />10分钟发送邮件<br/>\n");
                        Sb_Details.Append("<input  id=\"Chk_IsCheck_" + i.ToString() + "\" type=\"checkbox\" enable=false  name=\"Chk_IsCheck_" + i.ToString() + "\"   " + s_Checked + "  />自动审核\n");
                        Sb_Details.Append("</td>\n");

                        Sb_Details.Append("</tr>\n");
                        Sb_Details.Append("<tr>\n");
                        Sb_Details.Append("<td class=\"ListHeadDetails\" colspan=\"10\">\n");

                        Sb_Details.Append("<div id=\"Div_" + i.ToString() + "\" style=\"display: none;\">\n");
                        Sb_Details.Append("<table width=\"100%\" width=\"100%\" border=\"0\" align=\"center\" cellspacing=\"0\" class=\"ListDetails\">\n");
                        Sb_Details.Append("<tr>\n");
                        Sb_Details.Append("<td class=\"ListHeadDetails\">备注\n");
                        Sb_Details.Append("</td>\n");
                        Sb_Details.Append("<td class=\"ListHeadDetails\" colspan=\"9\">\n");

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

                            if ((s_SuppNo == "129842136364062500") || (s_SuppNo == "130383676039147477"))
                            {
                                /*1. 余姚君超
                                    2. 南昌天佳 用126发*/
                                s_SendEmail = "bremax@126.com";
                            }
                            s_EmailPDF = Server.MapPath("/Web/CG/Order/PDF/" + s_NewOrderNo + ".PDF");
                            s_EmailTitle = "士腾采购单：" + s_NewOrderNo + " 请尽快回复交期；详细见明细";
                            s_EmailDetails = "尊敬的 " + base.Base_GetSupplierName(s_SuppNo) + ":<br/>";
                            s_EmailDetails += "<font size=4>1)第一时间确认订单收到<br/>";
                            s_EmailDetails += "2)上午订单，当天下午<font Color=red size=5>3点</font>前务必确认交期并盖章回传<br/>";
                            s_EmailDetails += "3)下午订单，第二天中午<font Color=red size=5>11点</font>前务必确认交期并盖章回传<br/>";
                            s_EmailDetails += "以上要求请务必严格执行！任何特殊情况请提前告知！谢谢合作！</font><br/><p></p><p></p><hr>";
                            s_EmailDetails += "" + AM.KNet_StaffName + "<br/>";
                            s_EmailDetails += "采购部<br/>";
                            s_EmailDetails += "杭州士腾科技有限公司<br/>";
                            s_EmailDetails += "手机：159 6718 4387<br/>";
                            s_EmailDetails += "电话：0571 8821 0011 -8041<br/>";
                            s_EmailDetails += "E-mail: fanghy@bremax.com<br/>";
                            s_EmailDetails += "地址：杭州市西湖区黄姑山路4号1号楼<br/>";
                        }
                        catch
                        { }

                        Sb_Details.Append("</tr>\n");
                        Sb_Details.Append("<tr>\n");
                        Sb_Details.Append("<td class=\"ListHeadDetails\">发送人\n");
                        Sb_Details.Append("</td>\n");
                        Sb_Details.Append("<td class=\"ListHeadDetails\" colspan=\"9\" >\n");
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
                        Sb_Details.Append("<td class=\"ListHeadDetails\" colspan=\"9\" >\n");
                        Sb_Details.Append("<input id=\"Tbx_EamilFile_" + i.ToString() + "\" type=\"hidden\" name=\"Tbx_EamilFile_" + i.ToString() + "\"  value=\"" + s_EmailPDF + "\" />\n");
                        Sb_Details.Append("<textarea  id=\"ReceiveEmail_" + i.ToString() + "\" type=\"Text\" style=\"height:30px;width:700px;\" name=\"ReceiveEmail_" + i.ToString() + "\"   />" + s_Email + "</textarea>\n");
                        Sb_Details.Append("</td>\n");
                        Sb_Details.Append("<tr>\n");
                        Sb_Details.Append("</tr>\n");
                        Sb_Details.Append("<td class=\"ListHeadDetails\">抄送\n");
                        Sb_Details.Append("</td>\n");
                        Sb_Details.Append("<td class=\"ListHeadDetails\" colspan=\"9\">\n");
                        Sb_Details.Append("<textarea  id=\"ReceiveCsEmail_" + i.ToString() + "\" type=\"Text\" style=\"height:30px;width:700px;\" name=\"ReceiveCsEmail_" + i.ToString() + "\" />" + s_CcEmail + "</textarea>\n");
                        Sb_Details.Append("</td>\n");
                        Sb_Details.Append("<tr>\n");
                        Sb_Details.Append("</tr>\n");
                        Sb_Details.Append("<td class=\"ListHeadDetails\">密送\n");
                        Sb_Details.Append("</td>\n");
                        Sb_Details.Append("<td class=\"ListHeadDetails\" colspan=\"9\">\n");
                        Sb_Details.Append("<textarea  id=\"ReceiveMsEmail_" + i.ToString() + "\" type=\"Text\" style=\"height:30px;width:700px;\" name=\"ReceiveMsEmail_" + i.ToString() + "\"   />" + s_MsEmail + "</textarea>\n");
                        Sb_Details.Append("</td>\n");
                        Sb_Details.Append("<tr>\n");
                        Sb_Details.Append("</tr>\n");
                        Sb_Details.Append("<td class=\"ListHeadDetails\">主题\n");
                        Sb_Details.Append("</td>\n");
                        Sb_Details.Append("<td class=\"ListHeadDetails\" colspan=\"9\">\n");
                        Sb_Details.Append("<textarea  id=\"ReceiveTitle_" + i.ToString() + "\" type=\"Text\" style=\"height:30px;width:700px;\" name=\"ReceiveTitle_" + i.ToString() + "\"   />" + s_EmailTitle + "</textarea>\n");
                        Sb_Details.Append("</td>\n");
                        Sb_Details.Append("<tr>\n");
                        Sb_Details.Append("</tr>\n");
                        Sb_Details.Append("<td class=\"ListHeadDetails\">内容\n");
                        Sb_Details.Append("</td>\n");
                        Sb_Details.Append("<td class=\"ListHeadDetails\" colspan=\"9\">\n");
                        Sb_Details.Append("<input id=\"EmailDetails_" + i.ToString() + "\"  name=\"EmailDetails_" + i.ToString() + "\"  value=\"" + s_EmailDetails + "\" />\n");
                        Sb_Details.Append("</td>\n");
                        Sb_Details.Append("</tr>\n");
                        Sb_Details.Append("</table>\n");
                        Sb_Details.Append("</div>\n");

                        Sb_Details.Append("</td>\n");
                        Sb_Details.Append("</tr>\n");
                    }
                    Sb_Details.Append("<input id=\"Tbx_Num\" type=\"hidden\" name=\"Tbx_Num\"  value=\"" + Dtb_Table.Rows.Count + "\" />\n");
                    this.Tbx_Address.Text = base.Base_GetSuppNoAddress(Model_Procure_OrderList.SuppNo).Replace("$", "\n");
                    this.Lbl_SDetail.Text = Sb_Details.ToString();
                }
            }
        }
        catch { }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        this.Pan_Sc.Visible = false;

    }

    public string GetLefNumber(string s_KCNumber, string s_OrderNumber, string s_NeedNumber, decimal s_Number)
    {
        string s_return = "";
        try
        {
            decimal d_Left = decimal.Parse(s_NeedNumber.Trim()) - decimal.Parse(s_OrderNumber.Trim()) - decimal.Parse(s_KCNumber.Trim()) - decimal.Parse(s_Number.ToString().Trim());
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
            string sql = "Select a.*,b.ProductsBarCode,b.OrderAmount,d.SuppNo,c.ProductsMainCategory from Xs_Products_Prodocts a join Knet_Procure_OrdersList_Details b  on a.XPP_FaterBarCode=b.ProductsBarCode join Knet_Procure_OrdersList d on d.OrderNo=b.OrderNo join KNet_Sys_Products c on c.ProductsBarCode=a.XPP_ProductsBarCode where  b.OrderNo='" + s_Code + "'  ";
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
            this.Button1.Enabled = false;
            this.Button3.Enabled = false;
            string DoSql = "update Knet_Procure_OrdersList  set OrderCheckYN=1,OrderCheckStaffNo ='" + AM.KNet_StaffNo + "',OrderState=1  where  OrderNo='" + this.Tbx_ID.Text + "' ";
            DbHelperSQL.ExecuteSql(DoSql);
            AM.Add_Logs("采购订单审批：" + this.Tbx_ID.Text);
            btn_Chcek.Text = "反审批";
        }
        else
        {
            this.Button1.Enabled = true;
            this.Button3.Enabled = true;
            string DoSql = "update Knet_Procure_OrdersList  set OrderCheckYN=0,OrderCheckStaffNo ='',OrderState=0  where  OrderNo='" + this.Tbx_ID.Text + "' ";
            DbHelperSQL.ExecuteSql(DoSql);
            btn_Chcek.Text = "审批";

            AM.Add_Logs("采购订单反审批：" + this.Tbx_ID.Text);
        }

        try
        {
            KNet.BLL.Knet_Procure_OrdersList Bll = new KNet.BLL.Knet_Procure_OrdersList();
            KNet.Model.Knet_Procure_OrdersList Model = Bll.GetModelB(this.Tbx_ID.Text);
            string JSD = "CG/Order/Knet_Procure_OpenBilling_Print.aspx?ID=" + Model.ID + "";
            base.HtmlToPdf1(JSD, Server.MapPath("PDF"), this.Tbx_ID.Text);
            AM.Add_Logs("采购订单审批：" + this.Tbx_ID.Text);
            Alert("审批成功！");
        }
        catch { }
    }


    protected void btn_Sc_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        if (btn_Sc.Text == "暂停生产")
        {
            string DoSql = "update Knet_Procure_OrdersList  set KPO_IsStopProduce=1 where  OrderNo='" + this.Tbx_ID.Text + "' ";
            DbHelperSQL.ExecuteSql(DoSql);
            AM.Add_Logs("暂停生产审批：" + this.Tbx_ID.Text);
            btn_Sc.Text = "恢复生产";
        }
        else
        {
            string DoSql = "update Knet_Procure_OrdersList  set KPO_IsStopProduce=0 where  OrderNo='" + this.Tbx_ID.Text + "' ";
            DbHelperSQL.ExecuteSql(DoSql);
            btn_Sc.Text = "暂停生产";
            AM.Add_Logs("暂停生产审批：" + this.Tbx_ID.Text);
        }

        try
        {
            KNet.BLL.Knet_Procure_OrdersList Bll = new KNet.BLL.Knet_Procure_OrdersList();
            KNet.Model.Knet_Procure_OrdersList Model = Bll.GetModelB(this.Tbx_ID.Text);
            string JSD = "CG/Order/Knet_Procure_OpenBilling_Print.aspx?ID=" + Model.ID + "";
            base.HtmlToPdf1(JSD, Server.MapPath("PDF"), this.Tbx_ID.Text);
            AM.Add_Logs("采购订单审批：" + this.Tbx_ID.Text);
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
