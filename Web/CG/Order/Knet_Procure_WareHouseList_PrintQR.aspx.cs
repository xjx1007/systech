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

public partial class Web_SalesQuotes_Xs_Sales_Quotes_Print : BasePage
{
    public string s_Company = "", sMan = "", s_CustomerName = "", s_DutypersonName = "", s_Table = "";
    public string s_MyTable_Detail = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            if (s_ID != "")
            {
                //找未确认交期


                this.Lbl_Details.Text = ShowRkDetails(s_ID);
                //找本次入库数量
                //  ShowRkDetails1(s_ID);
                //找未确认入库单信息
                try
                {
                    KNet.BLL.Knet_Procure_Suppliers Bll_Supp = new KNet.BLL.Knet_Procure_Suppliers();
                    KNet.Model.Knet_Procure_Suppliers Model_Supp = Bll_Supp.GetModelB(s_ID);
                    ScExcel(this.Lbl_Details.Text, Model_Supp.SuppName + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString());

                    KNet.BLL.KNet_Sys_WareHouse Bll = new KNet.BLL.KNet_Sys_WareHouse();
                    KNet.Model.KNet_Sys_WareHouse Model = Bll.GetModelBySuppNo(s_ID);
                    s_ID = Model.HouseNo;
                    ShowInfo(s_ID);
                }
                catch
                { }
            }

        }
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

                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["WareHouseNo"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["OrderNo"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["ParentOrderNo"].ToString() + "</td>";

                    try
                    {
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + DateTime.Parse(Dts_Details.Tables[0].Rows[i]["KPO_CheckTime"].ToString()).ToShortDateString() + "</td>";
                    }
                    catch
                    { }
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetSupplierName(Dts_Details.Tables[0].Rows[i]["SuppNo"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsCode(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["WareHouseAmount"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["WareHouseBAmount"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["WareHouseRemarks"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">&nbsp;</td>";
                    s_MyTable_Detail += "</tr>";
                }
            }


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
                s_Sql += "where b.OrderNo='" + s_OrderNo + "'  ";
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
    private string ShowRkDetails(string s_ID)
    {
        string s_HouseNo = "",s_SuppName="";
        try
        {
            KNet.BLL.Knet_Procure_Suppliers Bll_Supp = new KNet.BLL.Knet_Procure_Suppliers();
            KNet.Model.Knet_Procure_Suppliers Model_Supp = Bll_Supp.GetModelB(s_ID);
            s_SuppName = Model_Supp.SuppName;
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
            s_Sql += " Order by OrderDateTime";
            this.BeginQuery(s_Sql);
            DataSet Dts_Details = (DataSet)this.QueryForDataSet();
            if (Dts_Details.Tables[0].Rows.Count > 0)
            {

                Sb_Details.Append("<table border=\"1\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"ListDetails\" >");
                Sb_Details.Append("<tr>");
                Sb_Details.Append("<td colspan=18 >");
                Sb_Details.Append("<div align=\"center\">");
                Sb_Details.Append("<font style=\"FONT-SIZE: 30px\"><strong>杭州士腾科技有限公司<br>");
                Sb_Details.Append("采购跟踪单</strong></font></div>");
                Sb_Details.Append("</td>");
                Sb_Details.Append("</tr>");
                Sb_Details.Append("<tr>");
                Sb_Details.Append("<td colspan=10 align=\"left\">");
                Sb_Details.Append("<font style=\"FONT-SIZE: 14px\">供应商：" + s_SuppName + "</font>");
                Sb_Details.Append("</td>");
                Sb_Details.Append("<td colspan=8 align=\"right\" >");
                Sb_Details.Append("<font style=\"FONT-SIZE: 14px\">时间：" + DateTime.Now.ToShortDateString() + "</font>");
                Sb_Details.Append("</td>");
                Sb_Details.Append("</tr>");
                Sb_Details.Append("<tr valign=\"top\" >");
                Sb_Details.Append("<td colspan=18  align=\"left\" class=\"ListHead\">");
                Sb_Details.Append("<b>1.交期确认和发货登记</b>");
                Sb_Details.Append("</td>");
                Sb_Details.Append("</tr>");


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
                Sb_Details.Append("<td class=\"ListHead\" nowrap><b>交货期</b></td>");
                Sb_Details.Append("<td class=\"ListHead\" nowrap><b>预计交期</b></td>");
                Sb_Details.Append("<td class=\"ListHead\" nowrap><b>备注</b></td>");
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
                    Sb_Details.Append("<td class=\"ListHeadDetails\"><font color=red>" + Convert.ToString(i + 1) + "</font></td>");

                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["OrderNo"].ToString() + "</td>");
                    if (Dts_Details.Tables[0].Rows[0]["OrderType"].ToString() != "128860698200781250")
                    {
                        Sb_Details.Append("<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["ParentOrderNo"].ToString() + "</td>");
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
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["OrderAmount"].ToString() + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["WrkNumber"].ToString() + "</td>");

                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + GetOrderTime(Dts_Details.Tables[0].Rows[i]["OrderNo"].ToString()) + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">&nbsp;</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">&nbsp;</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">&nbsp;</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">&nbsp;</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">&nbsp;</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">&nbsp;</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">&nbsp;</td>");

                    Sb_Details.Append("</tr>");

                    if (Dts_Details.Tables[0].Rows[0]["OrderType"].ToString() == "128860698200781250")
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
                                        Sb_Details.Append("<td align=\"left\" class=\"ListHeadDetails\">" + base.Base_GetProdutsName(Dtb_ProductsTable.Rows[j]["XPD_ProductsBarCode"] == null ? "" : Dtb_ProductsTable.Rows[j]["XPD_ProductsBarCode"].ToString()) + "</td>\n");
                                        Sb_Details.Append("<td align=\"left\" class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dtb_ProductsTable.Rows[j]["XPD_ProductsBarCode"] == null ? "" : Dtb_ProductsTable.Rows[j]["XPD_ProductsBarCode"].ToString()) + "</td>\n");
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
                                        Sb_Details.Append("<td align=\"left\" class=\"ListHeadDetails\">" + base.Base_GetProdutsName(Dtb_ProductsTable.Rows[j]["XPD_ProductsBarCode"] == null ? "" : Dtb_ProductsTable.Rows[j]["XPD_ProductsBarCode"].ToString()) + "</td>\n");
                                        Sb_Details.Append("<td align=\"left\" class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dtb_ProductsTable.Rows[j]["XPD_ProductsBarCode"] == null ? "" : Dtb_ProductsTable.Rows[j]["XPD_ProductsBarCode"].ToString()) + "</td>\n");
                                        Sb_Details.Append("<td align=\"left\" class=\"ListHeadDetails\">" + base.Base_GetProductsCode(Dtb_ProductsTable.Rows[j]["XPD_ProductsBarCode"] == null ? "" : Dtb_ProductsTable.Rows[j]["XPD_ProductsBarCode"].ToString()) + "</td>\n");
                                        string s_WareHouseNumber = Dtb_ProductsTable.Rows[j]["KCNumber"].ToString();// base.Base_GetHouseAndNumber1(s_ProductsBarCode, s_HouseNo);
                                        Sb_Details.Append("<td align=\"left\" class=\"ListHeadDetails\">" + s_WareHouseNumber + "</td>\n");//快递
                                        Sb_Details.Append("<td align=\"left\" class=\"ListHeadDetails\">&nbsp;</td>\n");
                                        Sb_Details.Append("<td class=\"ListHeadDetails\"  nowrap colspan=9>&nbsp;</td>");
                                    }
                                    Sb_Details.Append("</tr >\n");
                                }
                            }

                        }
                    }

                }

                Sb_Details.Append("<table>\n");
            }
        }
        catch
        { }
        return Sb_Details.ToString();
    }

    private void ScExcel(string s_Details, string s_ID)
    {
        try
        {
            string s_Path = Server.MapPath("Excel/" + s_ID + ".xls");
            if (File.Exists(s_Path))
            {
                File.Delete(s_Path);
            }
            FileStream fs = new FileStream(s_Path, FileMode.Create, FileAccess.Write);
            StreamWriter rw = new StreamWriter(fs, Encoding.Default);//建立StreamWriter为写作准备;
            rw.WriteLine(s_Details);
            rw.Close();
            fs.Close();
        }
        catch (Exception ex)
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

}
