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


public partial class Web_Knet_Procure_WareHouseList_View : BasePage
{
    public string s_CustomerValue = "";
    public string s_LinkMan = "";
    public string s_OppID = "";
    public string s_MyTable_Detail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            this.Lbl_Title.Text = "查看采购入库";
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            if (s_ID != "")
            {
                this.Tbx_ID.Text = s_ID;
                this.Lbl_Dept.Text = base.Base_GetHouseName(s_ID);
                //找未确认交期
                ShowRkDetails(s_ID);
                //找本次入库数量
                //  ShowRkDetails1(s_ID);
                //找未确认入库单信息
                try
                {
                    KNet.BLL.KNet_Sys_WareHouse Bll = new KNet.BLL.KNet_Sys_WareHouse();
                    KNet.Model.KNet_Sys_WareHouse Model = Bll.GetModelBySuppNo(s_ID);
                    s_ID = Model.HouseNo;
                    ShowInfo(s_ID);
                    ShowKCDetails(s_ID);
                }
                catch
                { }
            }

        }
    }

    //相关的OEM HouseNo
    private void ShowRkDetails(string s_ID)
    {
        string s_HouseNo ="";
        try
        {
            KNet.BLL.KNet_Sys_WareHouse Bll = new KNet.BLL.KNet_Sys_WareHouse();
            KNet.Model.KNet_Sys_WareHouse Model = Bll.GetModelBySuppNo(s_ID);
            s_HouseNo = Model.HouseNo;
        }
        catch
        { }
        StringBuilder Sb_Details = new StringBuilder();
        try
        {
            string s_Sql = "Select * from Knet_Procure_OrdersList_Details a join Knet_Procure_OrdersList b on a.OrderNo=b.OrderNo ";
            s_Sql += " join v_OrderRkDetailsQR c on a.ID=c.KPO_ID  ";
            s_Sql += " where  b.KPO_Del=0 and c.rkState<>1 and KPO_RkState<>'1' ";
            if (s_ID != "")
            {
                s_Sql += " and SuppNo='" + s_ID + "'";
            }
            s_Sql += " Order by OrderType,OrderDateTime ";
            this.BeginQuery(s_Sql);
            DataSet Dts_Details = (DataSet)this.QueryForDataSet();
            if (Dts_Details.Tables[0].Rows.Count > 0)
            {

                Sb_Details.Append("<tr valign=\"top\">");
                Sb_Details.Append("<td class=\"ListHead\" nowrap><b>序号</b></td>");
                Sb_Details.Append("<td class=\"ListHead\" nowrap><b>订单号</b></td>");
                if (Dts_Details.Tables[0].Rows[0]["OrderType"].ToString() != "128860698200781250")
                {
                    Sb_Details.Append("<td class=\"ListHead\" nowrap><b>OEM订单号</b></td>");
                }
                Sb_Details.Append("<td class=\"ListHead\" nowrap><b>订单日期</b></td>");
                Sb_Details.Append("<td class=\"ListHead\" nowrap><b>要求日期</b></td>");
                Sb_Details.Append("<td class=\"ListHead\" nowrap><b>产品名称</b></td>");
                Sb_Details.Append("<td class=\"ListHead\" nowrap><b>产品编码</b></td>");
                Sb_Details.Append("<td class=\"ListHead\" nowrap><b>型号</b></td>");
                Sb_Details.Append("<td class=\"ListHead\" nowrap><b>数量</b></td>");
                Sb_Details.Append("<td class=\"ListHead\" nowrap><b>未入库数量</b></td>");
                if (Dts_Details.Tables[0].Rows[0]["OrderType"].ToString() != "128860698200781250")
                {
                    Sb_Details.Append("<td class=\"ListHead\" nowrap><b>交期信息</b></td>");
                }
                else
                {
                    Sb_Details.Append("<td class=\"ListHead\" nowrap><b>生产计划日期</b></td>");
                }
                Sb_Details.Append("<td class=\"ListHead\" nowrap><b>交期确认</b></td>");
                if (Dts_Details.Tables[0].Rows[0]["OrderType"].ToString() != "128860698200781250")
                {
                    Sb_Details.Append("<td class=\"ListHead\" nowrap><b>发货数量</b></td>");
                }
                else
                {
                    Sb_Details.Append("<td class=\"ListHead\" nowrap><b>生产数量</b></td>");
                }
                Sb_Details.Append("<td class=\"ListHead\" nowrap><b>备品数量</b></td>");
                Sb_Details.Append("<td class=\"ListHead\" nowrap><b>物流公司</b></td>");
                Sb_Details.Append("<td class=\"ListHead\" nowrap><b>物流单号</b></td>");
                Sb_Details.Append("<td class=\"ListHead\" nowrap><b>联系电话</b></td>");
                Sb_Details.Append("</tr>");
                for (int i = 0; i < Dts_Details.Tables[0].Rows.Count; i++)
                {
                    string s_OrderNo = Dts_Details.Tables[0].Rows[i]["OrderNo"].ToString();
                    Sb_Details.Append("<tr>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\"><font color=red>"+Convert.ToString(i+1)+"</font></td>");

                    Sb_Details.Append("<td class=\"ListHeadDetails\"><a href=\"Knet_Procure_OpenBilling_View.aspx?ID=" + Dts_Details.Tables[0].Rows[i]["OrderNo"].ToString() + "\" target=\"_blank\">" + Dts_Details.Tables[0].Rows[i]["OrderNo"].ToString() + "</a></td>");
                    if (Dts_Details.Tables[0].Rows[0]["OrderType"].ToString() != "128860698200781250")
                    {
                        Sb_Details.Append("<td class=\"ListHeadDetails\"><a href=\"Knet_Procure_OpenBilling_View.aspx?ID=" + Dts_Details.Tables[0].Rows[i]["ParentOrderNo"].ToString() + "\" target=\"_blank\">" + Dts_Details.Tables[0].Rows[i]["ParentOrderNo"].ToString() + "</a></td>");
                    }
                    try
                    {
                        Sb_Details.Append("<td class=\"ListHeadDetails\">" + DateTime.Parse(Dts_Details.Tables[0].Rows[i]["OrderDateTime"].ToString()).ToShortDateString() + "</td>");
                        Sb_Details.Append("<td class=\"ListHeadDetails\">" + DateTime.Parse(Dts_Details.Tables[0].Rows[i]["ArrivalDate"].ToString()).ToShortDateString() + "</td>");

                        //  Sb_Details.Append("<td class=\"ListHeadDetails\">" + DateTime.Parse(Dts_Details.Tables[0].Rows[i]["OrderPreToDate"].ToString()).ToShortDateString() + "</td>");
                    }
                    catch
                    { }
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + base.Base_GetProductsCode(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition_Link(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["OrderAmount"].ToString() + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["WrkNumber"].ToString() + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + GetOrderTime(Dts_Details.Tables[0].Rows[i]["OrderNo"].ToString()) + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">&nbsp;</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">&nbsp;</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">&nbsp;</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">&nbsp;</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">&nbsp;</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">&nbsp;</td>");

                    Sb_Details.Append("</tr>");

                    if (Dts_Details.Tables[0].Rows[i]["OrderType"].ToString() == "128860698200781250")
                    {
                        //如果是成品要显示委外料

                        string s_Sql1 = "Select b.ProductsType,a.XPD_ProductsBarCode,c.*,isnull(NeedNumber,0) NeedNumber,isnull(e.Number,0) WNumber,isnull(g.Number,0) as KCNumber  from Xs_Products_Prodocts_Demo a ";
                        s_Sql1 += " join KNet_Sys_Products b on a.XPD_ProductsBarCode=b.ProductsBarCode";
                        s_Sql1 += " left join v_OrderRkDetails c on c.V_ProductsBarCode=a.XPD_ProductsBarCode and c.v_ParentOrderNo='" + s_OrderNo + "'";
                        s_Sql1 += " left join v_OrderNeed f on MaterProductsBarCode=b.ProductsBarCode  and f.HouseNO='" + s_HouseNo + "'";
                        s_Sql1 += " left join v_Cg_OrderWrkNumber e on e.ProductsBarCode=b.ProductsBarCode and e.HouseNO='" + s_HouseNo + "'";
                        s_Sql1 += " left join v_ProdutsStore g on g.ProductsBarCode=b.ProductsBarCode and g.HouseNO='" + s_HouseNo + "'";
                        s_Sql1 += "  where b.KSP_Del=0 and XPD_FaterBarCode In (select ProductsBarCode from Knet_Procure_OrdersList_Details where OrderNo='" + s_OrderNo + "')  ";
                        s_Sql1 += " Order by  b.ProductsType ";
                        this.BeginQuery(s_Sql1);
                        this.QueryForDataTable();
                        DataTable Dtb_ProductsTable = Dtb_Result;
                        if (Dtb_ProductsTable != null)
                        {
                            Sb_Details.Append("<div id=\"layer_H" + i.ToString() + "\" class=\"drag_Element\">\n");
                            if (Dtb_ProductsTable.Rows.Count > 0)
                            {
                                Sb_Details.Append("<tr>");
                                Sb_Details.Append("<td class=\"ListHead2\"  nowrap><b>材料耗用</b></td>");
                                Sb_Details.Append("<td class=\"ListHead2\" nowrap><b>序号</b></td>");
                                Sb_Details.Append("<td class=\"ListHead2\" nowrap><b>供应商</b></td>");
                                Sb_Details.Append("<td class=\"ListHead2\" nowrap><b>产品名称</b></td>");
                                Sb_Details.Append("<td class=\"ListHead2\" nowrap><b>型号</b></td>");
                                Sb_Details.Append("<td class=\"ListHead2\" nowrap><b>产品编码</b></td>");
                                Sb_Details.Append("<td class=\"ListHead2\"  nowrap><b>库存</b></td>");
                                Sb_Details.Append("<td class=\"ListHead2\"  nowrap><b>数量</b></td>");
                                Sb_Details.Append("<td class=\"ListHead2\"  nowrap colspan=9>&nbsp;</td>");
                                Sb_Details.Append("</tr>");
                                for (int j = 0; j < Dtb_ProductsTable.Rows.Count; j++)
                                {
                                    Sb_Details.Append("<tr class=\"ListHeadDetails\"  >");
                                    Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap><b>&nbsp;</b></td>");
                                    Sb_Details.Append("<td align=\"right\"  class=\"ListHeadDetails\">" + Convert.ToString(j + 1) + "</td>\n");
                                    string s_DetailsOrderNo = Dtb_ProductsTable.Rows[j]["v_OrderNo"] == null ? "" : Dtb_ProductsTable.Rows[j]["v_OrderNo"].ToString();
                                    string s_DetailsID = Dtb_ProductsTable.Rows[j]["KPO_ID"] == null ? "" : Dtb_ProductsTable.Rows[j]["KPO_ID"].ToString();

                                    if (s_DetailsOrderNo != "")
                                    {
                                        KNet.BLL.Knet_Procure_OrdersList bll = new KNet.BLL.Knet_Procure_OrdersList();
                                        KNet.Model.Knet_Procure_OrdersList Model_OrdersList = bll.GetModelB(s_DetailsOrderNo);
                                        Sb_Details.Append("<td align=\"left\" class=\"ListHeadDetails\">" + base.Base_GetSupplierName_Link(Model_OrdersList.SuppNo) + "</td>\n");
                                        Sb_Details.Append("<td align=\"left\" class=\"ListHeadDetails\">" + base.Base_GetProdutsName(Dtb_ProductsTable.Rows[j]["XPD_ProductsBarCode"] == null ? "" : Dtb_ProductsTable.Rows[j]["XPD_ProductsBarCode"].ToString()) + "</td>\n");
                                        Sb_Details.Append("<td align=\"left\" class=\"ListHeadDetails\">" + base.Base_GetProductsEdition_Link(Dtb_ProductsTable.Rows[j]["XPD_ProductsBarCode"] == null ? "" : Dtb_ProductsTable.Rows[j]["XPD_ProductsBarCode"].ToString()) + "</td>\n");
                                        Sb_Details.Append("<td align=\"left\" class=\"ListHeadDetails\">" + base.Base_GetProductsCode(Dtb_ProductsTable.Rows[j]["XPD_ProductsBarCode"] == null ? "" : Dtb_ProductsTable.Rows[j]["XPD_ProductsBarCode"].ToString()) + "</td>\n");

                                        string s_WareHouseNumber = Dtb_ProductsTable.Rows[j]["KCNumber"].ToString();
                                        string s_ProductsBarCode = Dtb_ProductsTable.Rows[j]["XPD_ProductsBarCode"].ToString();
                                        Sb_Details.Append("<td align=\"left\" class=\"ListHeadDetails\">" + s_WareHouseNumber + "</td>\n");//快递
                                        Sb_Details.Append("<td align=\"left\" class=\"ListHeadDetails\">&nbsp;</td>\n");
                                        Sb_Details.Append("<td class=\"ListHeadDetails\"  nowrap colspan=9>&nbsp;</td>");
                                    }
                                    else
                                    {
                                        string s_ProductsBarCode = Dtb_ProductsTable.Rows[j]["XPD_ProductsBarCode"].ToString();
                                        Sb_Details.Append("<td align=\"center\" class=\"ListHeadDetails\" ><font color=red>未找到</font></td>\n");
                                        Sb_Details.Append("<td align=\"left\" class=\"ListHeadDetails\">" + base.Base_GetProdutsName(Dtb_ProductsTable.Rows[j]["XPD_ProductsBarCode"] == null ? "" : Dtb_ProductsTable.Rows[j]["XPD_ProductsBarCode"].ToString()) + "</td>\n");
                                        Sb_Details.Append("<td align=\"left\" class=\"ListHeadDetails\">" + base.Base_GetProductsEdition_Link(Dtb_ProductsTable.Rows[j]["XPD_ProductsBarCode"] == null ? "" : Dtb_ProductsTable.Rows[j]["XPD_ProductsBarCode"].ToString()) + "</td>\n");
                                        Sb_Details.Append("<td align=\"left\" class=\"ListHeadDetails\">" + base.Base_GetProductsCode(Dtb_ProductsTable.Rows[j]["XPD_ProductsBarCode"] == null ? "" : Dtb_ProductsTable.Rows[j]["XPD_ProductsBarCode"].ToString()) + "</td>\n");
                                        string s_WareHouseNumber = Dtb_ProductsTable.Rows[j]["KCNumber"].ToString();// base.Base_GetHouseAndNumber1(s_ProductsBarCode, s_HouseNo);
                                        Sb_Details.Append("<td align=\"left\" class=\"ListHeadDetails\">" + s_WareHouseNumber + "</td>\n");//快递
                                        Sb_Details.Append("<td align=\"left\" class=\"ListHeadDetails\">&nbsp;</td>\n");
                                        Sb_Details.Append("<td class=\"ListHeadDetails\"  nowrap colspan=9>&nbsp;</td>");
                                    }
                                    Sb_Details.Append("</tr >\n");
                                }
                            }

                            Sb_Details.Append("<tr>\n");

                        }
                    }
                }
            }
            this.Lbl_Details.Text = Sb_Details.ToString();
        }
        catch
        { }
    }

    public string GetLefNumber(string s_KCNumber, string s_OrderNumber, string s_NeedNumber)
    {
        string s_return = "";
        try
        {
            decimal d_Left = decimal.Parse(s_NeedNumber.Trim()) - decimal.Parse(s_OrderNumber.Trim()) - decimal.Parse(s_KCNumber.Trim());
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

    //相关的OEM HouseNo
    private void ShowRkDetails1(string s_ID)
    {
        StringBuilder Sb_Details = new StringBuilder();
        try
        {
            string s_Sql = "Select * from Knet_Procure_OrdersList_Details a join Knet_Procure_OrdersList b on a.OrderNo=b.OrderNo ";
            s_Sql += " join v_OrderRkDetailsQR c on a.ID=c.KPO_ID  ";
            s_Sql += " where  b.KPO_Del=0 and c.rkState<>1 and KPO_RkState<>'1' ";
            if (s_ID != "")
            {
                s_Sql += " and SuppNo='" + s_ID + "'";
            }
            s_Sql += " Order by OrderDateTime";
            this.BeginQuery(s_Sql);
            DataSet Dts_Details = (DataSet)this.QueryForDataSet();
            if (Dts_Details.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_Details.Tables[0].Rows.Count; i++)
                {
                    Sb_Details.Append("<tr>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\"><a href=\"Knet_Procure_OpenBilling_View.aspx?ID=" + Dts_Details.Tables[0].Rows[i]["OrderNo"].ToString() + "\" target=\"_blank\">" + Dts_Details.Tables[0].Rows[i]["OrderNo"].ToString() + "</a></td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\"><a href=\"Knet_Procure_OpenBilling_View.aspx?ID=" + Dts_Details.Tables[0].Rows[i]["ParentOrderNo"].ToString() + "\" target=\"_blank\">" + Dts_Details.Tables[0].Rows[i]["ParentOrderNo"].ToString() + "</a></td>");
                    try
                    {
                        Sb_Details.Append("<td class=\"ListHeadDetails\">" + DateTime.Parse(Dts_Details.Tables[0].Rows[i]["OrderDateTime"].ToString()).ToShortDateString() + "</td>");
                        Sb_Details.Append("<td class=\"ListHeadDetails\">" + DateTime.Parse(Dts_Details.Tables[0].Rows[i]["ArrivalDate"].ToString()).ToShortDateString() + "</td>");

                        //  Sb_Details.Append("<td class=\"ListHeadDetails\">" + DateTime.Parse(Dts_Details.Tables[0].Rows[i]["OrderPreToDate"].ToString()).ToShortDateString() + "</td>");
                    }
                    catch
                    { }
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + base.Base_GetProductsCode(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition_Link(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["OrderAmount"].ToString() + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["WrkNumber"].ToString() + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">&nbsp;</td>");
                    Sb_Details.Append("</tr>");
                }
            }

        }
        catch
        { }
    }



    //相关的OEM HouseNo
    private void ShowKCDetails(string s_ID)
    {
        StringBuilder Sb_Details = new StringBuilder();
        try
        {
            string s_Sql = "Select * from v_ProdutsStore a Join KNET_Sys_Products b on a.ProductsBarCode=b.ProductsBarCode ";
            s_Sql += " where 1=1  and HouseType=0 and Number<>0 ";
            if (s_ID != "")
            {
                s_Sql += " and HouseNo='" + s_ID + "'";
            }
            s_Sql += " Order by KSP_Code";
            this.BeginQuery(s_Sql);
            DataSet Dts_Details = (DataSet)this.QueryForDataSet();
            if (Dts_Details.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_Details.Tables[0].Rows.Count; i++)
                {
                    Sb_Details.Append("<tr>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + base.Base_GetProductsCode(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition_Link(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["Number"].ToString() + "</td>");
                    Sb_Details.Append("</tr>");
                }
            }
            this.Lbl_KCDetails.Text = Sb_Details.ToString();
        }
        catch
        { }
    }

    private string GetOrderTime(string s_OrderNo)
    {
        //如果有有生产日期

        string s_Retrun = "";
        try
        {
            KNet.BLL.Knet_Procure_OrdersList Bll = new KNet.BLL.Knet_Procure_OrdersList();
            KNet.Model.Knet_Procure_OrdersList Model = Bll.GetModelB(s_OrderNo);
            if (Model.OrderType == "128860698200781250")
            {
                string s_Sql = "select top 1 SPD_EndTime from Sc_Produce_Plan_Details a ";
                s_Sql += "join Knet_Procure_OrdersList_Details b on a.SPD_OrderNo=b.ID  ";
                s_Sql += "where b.OrderNo='" + s_OrderNo + "' ";
                s_Sql += "order by SPD_FaterID desc";
                try
                {
                    this.BeginQuery(s_Sql);
                    s_Retrun += base.DateToString(this.QueryForReturn());
                }
                catch
                { }
                s_Retrun += "<br/>";
                //

            }
            else
            {

                string Dostr = "select ID,FollowNo,OutWareNo,FollowDateTime,FollowStaffNo,FollowText,FollowEnd,ReTime from KNet_Sales_OutWareList_FlowList where OutWareNo='" + s_OrderNo + "' order by FollowDateTime desc";
                this.BeginQuery(Dostr);
                DataTable Dtb_tables = (DataTable)this.QueryForDataTable();
                if (Dtb_tables.Rows.Count > 0)
                {
                    for (int i = 0; i < Dtb_tables.Rows.Count; i++)
                    {
                        s_Retrun += "交期" + Convert.ToString(i + 1) + "：" + base.DateToString(Dtb_tables.Rows[i]["ReTime"].ToString()) + KNetPage.CutString(Dtb_tables.Rows[i]["FollowText"].ToString().Trim(), 40);
                        s_Retrun += "<br/>";
                    }
                }
            }


        }
        catch
        { }
        return s_Retrun;
    }
    //相关的OEM HouseNo
    private void ShowInfo(string s_ID)
    {

        try
        {
            string s_Sql = "Select * from Knet_Procure_WareHouseList_Details a join Knet_Procure_WareHouseList b on a.WareHouseNo=b.WareHouseNo ";
            s_Sql += " join Knet_Procure_OrdersList c on b.OrderNo=c.OrderNo ";
            s_Sql += " where b.KPW_Del='0' and b.KPO_QRState=0  ";
            if (s_ID != "")
            {
                s_Sql += " and HouseNo='" + s_ID + "'";
            }
            this.BeginQuery(s_Sql);
            DataSet Dts_Details = (DataSet)this.QueryForDataSet();
            if (Dts_Details.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_Details.Tables[0].Rows.Count; i++)
                {
                    s_MyTable_Detail += "<tr>";
                    this.Xs_ProductsCode.Text += Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + ",";



                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><a href=\"Knet_Procure_WareHouseList_View.aspx?ID=" + Dts_Details.Tables[0].Rows[i]["WareHouseNo"].ToString() + "\">" + Dts_Details.Tables[0].Rows[i]["WareHouseNo"].ToString() + "</a></td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><a href=\"../Order/Knet_Procure_OpenBilling_View.aspx?ID=" + Dts_Details.Tables[0].Rows[i]["OrderNo"].ToString() + "\">" + Dts_Details.Tables[0].Rows[i]["OrderNo"].ToString() + "</a></td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><a href=\"../Order/Knet_Procure_OpenBilling_View.aspx?ID=" + Dts_Details.Tables[0].Rows[i]["ParentOrderNo"].ToString() + "\">" + Dts_Details.Tables[0].Rows[i]["ParentOrderNo"].ToString() + "</a></td>";

                    try
                    {
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + DateTime.Parse(Dts_Details.Tables[0].Rows[i]["KPO_CheckTime"].ToString()).ToShortDateString() + "</td>";
                    }
                    catch
                    { }
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetSupplierName(Dts_Details.Tables[0].Rows[i]["SuppNo"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsCode(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition_Link(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["WareHouseAmount"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["WareHouseBAmount"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["WareHouseRemarks"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">&nbsp;</td>";
                    s_MyTable_Detail += "</tr>";
                }
            }

            try
            {
                KNet.BLL.PB_Basic_Mail bll_Mail = new KNet.BLL.PB_Basic_Mail();
                s_Sql = "PBM_Del=0 and PBM_FID='" + s_ID + "' and PBM_Type=5 ";
                s_Sql += " Order by PBM_CTime desc";
                DataSet ds_Mail = bll_Mail.GetList(s_Sql);
                MyGridView3.DataSource = ds_Mail;
                MyGridView3.DataKeyNames = new string[] { "PBM_ID" };
                MyGridView3.DataBind();
            }
            catch
            { }
            try
            {

                KNet.BLL.PB_Basic_Attachment bllComment = new KNet.BLL.PB_Basic_Attachment();
                string SqlWhere = " PBA_FID like '%" + s_ID + "%' AND PBA_Type='OrderInHouseCheck' order by PBA_CTime desc";
                DataSet ds_Comment = bllComment.GetList(SqlWhere);
                GridView_Comment.DataSource = ds_Comment.Tables[0];
                GridView_Comment.DataBind();
            }
            catch
            { }

        }
        catch
        { }
    }

    protected void save_Click(object sender, EventArgs e)
    {

        if (!(uploadFile.PostedFile.ContentLength > 0))
        {
            Alert("您没有选择文件!");
        }
        else
        {
            AdminloginMess AM = new AdminloginMess();
            KNet.Model.PB_Basic_Attachment model = new KNet.Model.PB_Basic_Attachment();
            string FileType = uploadFile.PostedFile.ContentType.ToString(); //文件类型
            GetThumbnailImage1(model);
            try
            {
                DateTime now = DateTime.Now;
                KNet.BLL.PB_Basic_Attachment BLL = new KNet.BLL.PB_Basic_Attachment();
                BLL.DeleteByFID(this.Tbx_ID.Text + now.Year + now.Month + now.Day);
                BLL.Add(model);
                AM.Add_Logs("附件上传成功：编号：" + model.PBA_ID);
                this.Lbl_Upload.Text = "<a href=\"" + model.PBA_URL + "\">" + model.PBA_Name + "</a><br/>";
                this.Tbx_URL.Text = model.PBA_URL;
                Btn_Serch_Click(sender, e);

            }
            catch (Exception ex) { }
        }
    }

    protected void Btn_Serch_Click(object sender, EventArgs e)
    {

        this.Lbl_Dept.Text = base.Base_GetHouseName(this.Tbx_ID.Text);
        string s_Sql = "Select *,a.ID as DetailsID from Knet_Procure_WareHouseList_Details a join Knet_Procure_WareHouseList b on a.WareHouseNo=b.WareHouseNo ";
        s_Sql += " join Knet_Procure_OrdersList c on b.OrderNo=c.OrderNo ";
        s_Sql += " where b.KPW_Del='0' and b.KPO_QRState=0  ";
        if (this.Tbx_ID.Text != "")
        {
            s_Sql += " and HouseNo='" + this.Tbx_ID.Text + "'";
        }
        this.BeginQuery(s_Sql);
        DataSet Dts_Details = (DataSet)this.QueryForDataSet();

        Excel excel = new Excel();
        DataTable myT = excel.ExcelFirestToDataTable(this.Tbx_URL.Text, " 1=1 ");
        if (Dts_Details.Tables[0].Rows.Count > 0)
        {
            s_MyTable_Detail = "";
            for (int i = 0; i < Dts_Details.Tables[0].Rows.Count; i++)
            {
                s_MyTable_Detail += "<tr>";
                this.Xs_ProductsCode.Text += Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + ",";



                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"hidden\" Name=\"DetailsID\" value=" + Dts_Details.Tables[0].Rows[i]["DetailsID"].ToString() + " ><a href=\"Knet_Procure_WareHouseList_View.aspx?ID=" + Dts_Details.Tables[0].Rows[i]["WareHouseNo"].ToString() + "\">" + Dts_Details.Tables[0].Rows[i]["WareHouseNo"].ToString() + "</a></td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><a href=\"../Order/Knet_Procure_OpenBilling_View.aspx?ID=" + Dts_Details.Tables[0].Rows[i]["OrderNo"].ToString() + "\">" + Dts_Details.Tables[0].Rows[i]["OrderNo"].ToString() + "</a></td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><a href=\"../Order/Knet_Procure_OpenBilling_View.aspx?ID=" + Dts_Details.Tables[0].Rows[i]["ParentOrderNo"].ToString() + "\">" + Dts_Details.Tables[0].Rows[i]["ParentOrderNo"].ToString() + "</a></td>";

                try
                {
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + DateTime.Parse(Dts_Details.Tables[0].Rows[i]["KPO_CheckTime"].ToString()).ToShortDateString() + "</td>";
                }
                catch
                { }
                string s_ProductsCode = base.Base_GetProductsCode(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString());
                s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetSupplierName(Dts_Details.Tables[0].Rows[i]["SuppNo"].ToString()) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + s_ProductsCode + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition_Link(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["WareHouseAmount"].ToString() + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["WareHouseBAmount"].ToString() + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["WareHouseRemarks"].ToString() + "</td>";
                s_MyTable_Detail += "<input type=\"hidden\"   Name=\"OldQrNumber\" value=" + Dts_Details.Tables[0].Rows[i]["WareHouseAmount"].ToString() + " >";
                s_MyTable_Detail += "<input type=\"hidden\"   Name=\"OldQrBNumber\" value=" + Dts_Details.Tables[0].Rows[i]["WareHouseBAmount"].ToString() + " >";

                if (myT != null)
                {
                    string s_SqlD = " F1='" + Dts_Details.Tables[0].Rows[i]["WareHouseNo"].ToString() + "' and ( F7='" + int.Parse(s_ProductsCode.Trim()).ToString() + "' or  F7='" + s_ProductsCode.Trim() + "') and F11<>'' ";
                    DataRow[] arrayDR = myT.Select(s_SqlD);
                    if (arrayDR.Length > 0)
                    {
                        foreach (DataRow dr in arrayDR)
                        {
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\"  Name=\"QrNumber\" value=" + dr[10] + " ></td>";
                        }
                    }
                    else
                    {
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\"  Name=\"QrNumber\" value=0 ></td>";

                    }
                }
                s_MyTable_Detail += "</tr>";
            }
        }
    }

    protected void Btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            StringBuilder s_Sql = new StringBuilder();
            StringBuilder s_Log = new StringBuilder();
            AdminloginMess AM = new AdminloginMess();
            string s_IDs = Request["DetailsID"] == null ? "" : Request["DetailsID"].ToString();
            string s_QrNumbers = Request["QrNumber"] == null ? "" : Request["QrNumber"].ToString();
            string s_OldQrNumbers = Request["OldQrNumber"] == null ? "" : Request["OldQrNumber"].ToString();
            string s_OldBQrNumbers = Request["OldBQrNumber"] == null ? "" : Request["OldBQrNumber"].ToString();

            try
            {
                string[] s_ID = s_IDs.Split(',');
                string[] s_QrNumber = s_QrNumbers.Split(',');
                string[] s_OldQrNumber = s_OldQrNumbers.Split(',');
                string[] s_OldBQrNumber = s_OldBQrNumbers.Split(',');

                for (int i = 0; i < s_ID.Length; i++)
                {
                    int i_Number = 0;
                    int i_OldNumber = 0;
                    int i_OldBQrNumber = 0;
                    try
                    {
                        i_Number = int.Parse(s_QrNumber[i]);
                        i_OldNumber = int.Parse(s_OldQrNumber[i]);
                        i_OldBQrNumber = int.Parse(s_OldBQrNumber[i]);
                    }
                    catch
                    { }
                    if (i_Number > 0)
                    {
                        s_Log.Append(s_ID + ",");
                        if ((i_OldNumber + i_OldBQrNumber) != i_Number)
                        {
                            s_Sql.Append(" Update  Knet_Procure_WareHouseList_Details Set WareHouseAmount='" + (i_Number - i_OldBQrNumber) + "',WareHouseTotalNet='" + (i_Number - i_OldBQrNumber) + "'*WareHouseUnitPrice where ID='" + s_ID[i] + "' ");

                        }
                        s_Sql.Append(" Update  Knet_Procure_WareHouseList Set KPO_QrState='1',WareHouseDateTime='" + DateTime.Now + "',KPW_CheckPerson='" + AM.KNet_StaffNo + "' where WareHouseNo in (select WareHouseNo from Knet_Procure_WareHouseList_Details where ID='" + s_ID[i] + "') ");
                    }
                }
                if (DbHelperSQL.ExecuteSql(s_Sql.ToString()) > 0)
                {
                    AM.Add_Logs("Knet_Procure_WareHouseList 审批 编号：" + s_Log + "");
                    AlertAndRedirect("入库批量确认成功！", "Knet_Procure_WareHouseList_ListQr.aspx");
                }
            }
            catch (Exception ex)
            {
                Alert("批量确认失败！");
                return;
            }

        }
        catch
        { }
    }

    #region 资料上传操作
    /// <summary>
    /// 图片上传
    /// </summary>
    protected void GetThumbnailImage1(KNet.Model.PB_Basic_Attachment model)
    {
        AdminloginMess AM = new AdminloginMess();
        //类别下面的
        string UploadPath = "../../../UpFile/OrderInHouseCheck/";  //上传路径
        string AutoPath = System.DateTime.Now.ToShortDateString().Replace("-", "").Replace(" ", "").Replace(":", "").Replace("/", "");
        //string fileExt = Path.GetExtension(uploadFile1.PostedFile.FileName); //获扩展名
        string FileType = uploadFile.PostedFile.ContentType.ToString(); //文件类型
        string FileName = Path.GetFileName(uploadFile.PostedFile.FileName);
        string filePath = UploadPath + AutoPath + "_" + FileName; //大文件名
        if (!Directory.Exists(Server.MapPath(UploadPath)))
        {
            Directory.CreateDirectory(Server.MapPath(UploadPath));
        }
        uploadFile.PostedFile.SaveAs(Server.MapPath(filePath)); //上传

        DateTime now = DateTime.Now;
        model.PBA_FID = this.Tbx_ID.Text + now.Year + now.Month + now.Day;
        model.PBA_Type = "OrderInHouseCheck";
        model.PBA_ID = GetMainID();
        model.PBA_Name = FileName;
        model.PBA_URL = filePath;
        model.PBA_CTime = DateTime.Now;
        model.PBA_Creator = AM.KNet_StaffNo;
        model.PBA_Remarks = "";
    }
    #endregion
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

}
