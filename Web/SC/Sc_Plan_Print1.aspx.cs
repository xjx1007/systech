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


public partial class Sc_Plan_Print : BasePage
{
    public string s_Details = "", s_MyTable_Detail;
    public int i_Num = 0;
    public string s_SuppName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string s_Modiy = Request.QueryString["M"] == null ? "" : Request.QueryString["M"].ToString();
        string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
        this.Tbx_ID.Text = s_ID;
        string s_Head = "", s_Details = "", s_SuppNo = "", s_ID1 = "", s_FbPerson = "", s_FbTime = "";
        string s_Style = "";
        this.CommentList1.Visible = false;
        KNet.BLL.Sc_Produce_Plan BLL = new KNet.BLL.Sc_Produce_Plan();
        KNet.Model.Sc_Produce_Plan Model = BLL.GetModel(s_ID);
        // this.Lbl_SuppNo.Text = base.Base_GetSupplierName(Model.SPP_SuppNo);
        // this.Lbl_Person.Text = base.Base_GetUserName(Model.SPP_Creator);
        //this.Lbl_CTimes.Text = Model.SPP_Ctime.ToString();
        //this.Lbl_Remarks.Text = Model.SPP_Remarks;
        StringBuilder Sb_Details = new StringBuilder();
        KNet.BLL.Sc_Produce_Plan_Details Bll_Details = new KNet.BLL.Sc_Produce_Plan_Details();
        string s_Sql = "Select  isnull(SPD_IsWl,0) SPD_IsWl,SCP_Order,a.*,b.*,w.*,d.WrkNumber,f.suppName,h.HouseNo,e.suppNo,e.ContractNo,e.ContractNos,c.ProductsEdition,isnull(g.Number,0) as Number,e.OrderPreToDate,e.OrderDateTime,isnull((select top 1 OrderPreToDate from Knet_Procure_OrdersList where ParentOrderNo=e.OrderNo order by OrderPreToDate desc),'1900-01-01') as MaxOrderPreToDate from Sc_Produce_Plan_Details a join Knet_Procure_OrdersList_Details b on a.SPD_OrderNo=b.ID  ";
        s_Sql += "join KNet_Sys_Products c on b.ProductsBarCode=c.ProductsBarCode  ";
        s_Sql += "join v_OrderRkDetails d on d.KPO_ID=b.ID  ";
        s_Sql += "join Knet_Procure_OrdersList e on b.OrderNo=e.OrderNo  ";
        s_Sql += "join Knet_Procure_Suppliers f on e.suppNo=f.suppNo  ";
        s_Sql += "join KNet_Sys_WareHouse h on h.suppno=e.suppNo  and KSW_Type=0  ";
        s_Sql += "left join v_ProdutsStore g on g.HouseNo=h.HouseNo and g.ProductsBarCode=b.ProductsBarCode join Sc_Produce_Plan w on w.SPP_ID=a.SPD_FaterID";
        s_Sql += " where rkstate<>'1'  and SPP_Del=0 ";
        if (this.Tbx_ID.Text != "")
        {
            s_Sql += " and SPD_FaterID='" + this.Tbx_ID.Text + "'";
        }
        else
        {
            //s_Sql += " and SPD_FEndtime is not null ";
            s_Sql += " and SPD_FaterID in (Select SPP_ID  From Sc_Produce_Plan where SPP_Stime in (Select Top 1 SPP_STime From Sc_Produce_Plan  order by SPP_STime desc) )";
        }
        s_Sql += " Order by isnull(SCP_Order,0),isnull(SPD_BeginTime,'9999-09-09'),c.ProductsEdition";
        this.BeginQuery(s_Sql);
        this.QueryForDataSet();
        DataSet Dts_Table = Dts_Result;
        decimal d_TotalOrderNumber = 0, d_TotalWrkNumber = 0, d_TotalKc = 0, d_TotalPCNumber = 0;
        if (Dts_Table.Tables[0].Rows.Count > 0)
        {
            s_SuppName = Dts_Table.Tables[0].Rows[0]["SuppName"].ToString();
            s_SuppNo = Dts_Table.Tables[0].Rows[0]["SuppNo"].ToString();
            s_ID1 = Dts_Table.Tables[0].Rows[0]["SPD_FaterID"].ToString();

            s_FbPerson = base.Base_GetUserName(Dts_Table.Tables[0].Rows[0]["Spp_Creator"].ToString());
            s_FbTime = Dts_Table.Tables[0].Rows[0]["SPP_CTime"].ToString();
            this.Tbx_HouseNo.Text = Dts_Table.Tables[0].Rows[0]["HouseNo"].ToString();
            for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    s_Style = "class='gg'";
                }
                else
                {
                    s_Style = "class='rr'";
                }
                Sb_Details.Append(" <tr " + s_Style + " onmouseover='setActiveBG(this)'>\n");
                Sb_Details.Append("<td  align=\"left\"  >" + (i_Num + i + 1) + "</td>\n");
                Sb_Details.Append("<td  align=\"left\" >" + Dts_Table.Tables[0].Rows[i]["OrderNo"].ToString() + "</td>\n");

                if (this.Tbx_ID.Text == "")
                {
                    Sb_Details.Append("<td  align=\"left\" >" + GetContract(Dts_Table.Tables[0].Rows[i]["ContractNos"].ToString(), Dts_Table.Tables[0].Rows[i]["ContractNo"].ToString(), 0) + "</td>\n");

                }


                if (this.Tbx_ID.Text == "")
                {
                    try
                    {
                        Sb_Details.Append("<td nowrap align=\"left\" >" + base.Base_GetSupplierName_Link(Dts_Table.Tables[0].Rows[i]["SuppNo"].ToString()) + "</td>\n");
                    }
                    catch (Exception ex)
                    {
                        Sb_Details.Append("<td  align=\"left\" >&nbsp;</td>\n");
                    }
                }
                //产品
                try
                {
                    Sb_Details.Append("<td nowrap align=\"left\" >" + Dts_Table.Tables[0].Rows[i]["ProductsEdition"].ToString() + "</td>\n");
                }
                catch
                {
                    Sb_Details.Append("<td  align=\"left\" >&nbsp;</td>\n");
                    Sb_Details.Append("<td  align=\"left\" >&nbsp;</td>\n");
                }
                //下单日期
                try
                {
                    Sb_Details.Append("<td nowrap align=\"left\" >" + base.DateToString(Dts_Table.Tables[0].Rows[i]["OrderDateTime"].ToString()) + "</td>\n");
                }
                catch
                {
                    Sb_Details.Append("<td  align=\"left\" >&nbsp;</td>\n");
                }

                //要求日期
                try
                {
                    Sb_Details.Append("<td nowrap align=\"left\" >" + base.DateToString(Dts_Table.Tables[0].Rows[i]["OrderPreToDate"].ToString()) + "</td>\n");
                }
                catch
                {
                    Sb_Details.Append("<td  align=\"left\" >&nbsp;</td>\n");
                }
                //最迟交货
                try
                {
                    Sb_Details.Append("<td nowrap align=\"left\" >" + base.DateToString(Dts_Table.Tables[0].Rows[i]["MaxOrderPreToDate"].ToString()) + "</td>\n");
                }
                catch
                {
                    Sb_Details.Append("<td  align=\"left\" >&nbsp;</td>\n");
                }

                if (this.Tbx_ID.Text != "")
                {
                    //预计开始
                    try
                    {
                        Sb_Details.Append("<td nowrap align=\"left\" >" + base.DateToString(Dts_Table.Tables[0].Rows[i]["SPD_EndTime"].ToString()) + "</td>\n");
                    }
                    catch
                    {
                        Sb_Details.Append("<td  align=\"left\" >&nbsp;</td>\n");
                    }
                }

                //预计结束
                try
                {


                    if (this.Tbx_ID.Text != "")
                    {
                        Sb_Details.Append("<td nowrap align=\"left\" >" + base.DateToString(Dts_Table.Tables[0].Rows[i]["SPD_FEndTime"].ToString()) + "</td>\n");
                    }
                    else
                    {
                        Sb_Details.Append("<td nowrap align=\"left\" >" + base.DateToString(DateTime.Parse(Dts_Table.Tables[0].Rows[i]["SPD_FEndTime"].ToString()).AddDays(2).ToShortDateString()) + "</td>\n");

                    }
                }
                catch
                {
                    Sb_Details.Append("<td  align=\"left\" >&nbsp;</td>\n");
                }


                //订单数量
                try
                {
                    Sb_Details.Append("<td  align=\"left\" >" + Dts_Table.Tables[0].Rows[i]["OrderAmount"].ToString() + "</td>\n");
                    d_TotalOrderNumber += decimal.Parse(Dts_Table.Tables[0].Rows[i]["OrderAmount"].ToString());
                }
                catch
                {
                    Sb_Details.Append("<td  align=\"left\" >&nbsp;</td>\n");
                }

                try
                {
                    Sb_Details.Append("<td  align=\"left\" >" + Dts_Table.Tables[0].Rows[i]["WrkNumber"].ToString() + "</td>\n");
                    d_TotalWrkNumber += decimal.Parse(Dts_Table.Tables[0].Rows[i]["WrkNumber"].ToString());

                }
                catch
                {
                    Sb_Details.Append("<td  align=\"left\" >&nbsp;</td>\n");
                }
                //产品库存
                try
                {
                    Sb_Details.Append("<td  align=\"left\" >" + Dts_Table.Tables[0].Rows[i]["Number"].ToString() + "</td>\n");
                    d_TotalKc += decimal.Parse(Dts_Table.Tables[0].Rows[i]["Number"].ToString());

                }
                catch
                {
                    Sb_Details.Append("<td  align=\"left\" >&nbsp;</td>\n");
                }
                //本次计划数量
                try
                {
                    Sb_Details.Append("<td  align=\"left\" >" + Dts_Table.Tables[0].Rows[i]["SPD_Number"].ToString() + "&nbsp;</td>\n");
                    d_TotalPCNumber += decimal.Parse(Dts_Table.Tables[0].Rows[i]["SPD_Number"].ToString());

                }
                catch
                {
                    Sb_Details.Append("<td  align=\"left\" >&nbsp;</td>\n");
                }

                //备注
                try
                {
                    Sb_Details.Append("<td  align=\"left\" width=\"200px\" >" + Dts_Table.Tables[0].Rows[i]["SPD_Remarks"].ToString() + "&nbsp;</td>\n");
                }
                catch
                {
                    Sb_Details.Append("<td  align=\"left\" >&nbsp;</td>\n");
                }

                Sb_Details.Append(" </tr>\n");

                if (((i < Dts_Table.Tables[0].Rows.Count - 1) && (Dts_Table.Tables[0].Rows[i]["SuppNo"].ToString() != Dts_Table.Tables[0].Rows[i + 1]["SuppNo"].ToString())) || (i == Dts_Table.Tables[0].Rows.Count - 1))
                {
                    if (this.Tbx_ID.Text == "")
                    {
                        Sb_Details.Append(" <tr style='background-color:#66CCFF;'>\n");
                        Sb_Details.Append("<td  align=\"left\" colspan=2 > 小计：</td>\n");
                        Sb_Details.Append("<td  align=\"left\" colspan=7 >&nbsp;" + base.Base_GetSupplierName(Dts_Table.Tables[0].Rows[i]["SuppNo"].ToString()) + "</td>\n");
                        Sb_Details.Append("<td  align=\"left\"  >&nbsp;" + d_TotalOrderNumber + "</td>\n");
                        Sb_Details.Append("<td  align=\"left\"  >&nbsp;" + d_TotalWrkNumber + "</td>\n");
                        Sb_Details.Append("<td  align=\"left\"  >&nbsp;" + d_TotalKc + "</td>\n");
                        Sb_Details.Append("<td  align=\"left\"  >&nbsp;" + d_TotalPCNumber + "</td>\n");
                        Sb_Details.Append("<td  align=\"left\"  >&nbsp;</td>\n");
                        Sb_Details.Append(" </tr>\n");
                        d_TotalOrderNumber = 0;
                        d_TotalWrkNumber = 0;
                        d_TotalKc = 0;
                        d_TotalPCNumber = 0;
                    }
                    else
                    {

                        Sb_Details.Append(" <tr style='background-color:#66CCFF;'>\n");
                        Sb_Details.Append("<td  align=\"left\" colspan=2 > 小计：</td>\n");
                        Sb_Details.Append("<td  align=\"left\" colspan=6 >&nbsp;" + base.Base_GetSupplierName(Dts_Table.Tables[0].Rows[i]["SuppNo"].ToString()) + "</td>\n");
                        Sb_Details.Append("<td  align=\"left\"  >&nbsp;" + d_TotalOrderNumber + "</td>\n");
                        Sb_Details.Append("<td  align=\"left\"  >&nbsp;" + d_TotalWrkNumber + "</td>\n");
                        Sb_Details.Append("<td  align=\"left\"  >&nbsp;" + d_TotalKc + "</td>\n");
                        Sb_Details.Append("<td  align=\"left\"  >&nbsp;" + d_TotalPCNumber + "</td>\n");
                        Sb_Details.Append("<td  align=\"left\"  >&nbsp;</td>\n");
                        Sb_Details.Append(" </tr>\n");
                        d_TotalOrderNumber = 0;
                        d_TotalWrkNumber = 0;
                        d_TotalKc = 0;
                        d_TotalPCNumber = 0;

                    }
                }
                string s_OrderNo = Dts_Table.Tables[0].Rows[i]["OrderNo"].ToString();
                int i_wl = int.Parse(Dts_Table.Tables[0].Rows[i]["SPD_IsWl"].ToString());

                if (this.Tbx_ID.Text != "")
                {
                    if (i_wl == 1)
                    {
                        Sb_Details.Append(GetDetials(s_OrderNo, i));
                    }
                }

            }
        }
        i_Num += Dts_Table.Tables[0].Rows.Count;

        Sb_Details.Append("</table>\n");

        if (this.Tbx_ID.Text != "")
        {
            this.Lbl_SuppNo.Text = "供应商：" + s_SuppName + "";
        }

        s_Head += "<table id=\"table_2\" align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"print ke-zeroborder\" width=\"90%\">\n";
        s_Head += "<tr>\n<td colspan=\"9\"  ></td><td colspan=\"2\"  ></td></tr>\n";
        s_Head += "<tr><td nowrap>生产序号</td>\n";
        s_Head += "<td  align=center>OEM订单号</td>\n";
        if (this.Tbx_ID.Text == "")
        {
            s_Head += "<td   align=center nowrap>订单号</td>\n";
            s_Head += "<td  align=center>供应商</td>\n";
        }
        s_Head += "<td nowrap align=center>产品</td>\n";
        s_Head += "<td nowrap align=center>采购下单<br>日期</td>\n";
        s_Head += "<td nowrap align=center>客户要求<br>日期</td>\n";
        s_Head += "<td nowrap align=center>物料交货<br>日期</td>\n";

        if (this.Tbx_ID.Text != "")
        {
            s_Head += "<td nowrap align=center>预计开始<br>日期</td>\n";
            s_Head += "<td nowrap align=center>预计结束<br>日期</td>\n";
        }
        else
        {
            s_Head += "<td nowrap align=center>交货<br>日期</td>\n";
        }
        s_Head += "<td nowrap align=center>订单数量</td>\n";
        s_Head += "<td nowrap align=center>未入库</td>\n";
        s_Head += "<td nowrap align=center>库存</td>\n";
        s_Head += "<td  nowrap align=center>排产数量</td>\n";
        s_Head += "<td nowrap  align=center>生产说明</td>\n";
        //s_Head += "<td  align=center >芯片</td>\n";
        //s_Head += "<td  align=center>导电胶</td>\n";
        //s_Head += "<td >塑壳</td>\n";
        //s_Head += "<td >PCB</td>\n";
        //s_Head += "<td >发射管</td>\n";
        //s_Head += "<td >电池</td>\n";
        s_Head += "</tdead>\n<tbody class=\"scrollContent\">\n";
        s_MyTable_Detail = s_Head;
        s_MyTable_Detail += Sb_Details.ToString();
        this.CommentList1.CommentType = 123;
        this.CommentList1.CommentFID = s_ID1;
        this.Lbl_Person.Text = s_FbPerson;
        this.Lbl_CTimes.Text = s_FbTime;
        // this.Lbl_SuppNo.Text = "所有";

    }

    private string GetDetials(string s_OrderNo,int i)
    {
        StringBuilder Sb_DivStylea = new StringBuilder();
        try
        {
            KNet.BLL.Knet_Procure_OrdersList Bll_OrdersList = new KNet.BLL.Knet_Procure_OrdersList();

            KNet.Model.Knet_Procure_OrdersList Model = Bll_OrdersList.GetModelB(s_OrderNo);
            string s_Date = "", s_PreDate = "", s_FollowText="";
            string s_Sql = "Select b.ProductsType,a.XPP_ProductsBarCode,c.* from Xs_Products_Prodocts a ";
            s_Sql += " join KNet_Sys_Products b on a.XPP_ProductsBarCode=b.ProductsBarCode";
            s_Sql += " left join v_OrderRkDetails c on c.V_ProductsBarCode=a.XPP_ProductsBarCode and c.v_ParentOrderNo='" + s_OrderNo + "'";
            s_Sql += "  where XPP_FaterBarCode In (select ProductsBarCode from Knet_Procure_OrdersList_Details where OrderNo='" + s_OrderNo + "')  and XPP_IsOrder='是'";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_ProductsTable = Dtb_Result;
            if (Dtb_ProductsTable != null)
            {


                Sb_DivStylea.Append("<div id=\"layer_H" + i.ToString() + "\" class=\"drag_Element\">\n");
                if (Dtb_ProductsTable.Rows.Count > 0)
                {
                    for (int j = 0; j < Dtb_ProductsTable.Rows.Count; j++)
                    {
                        Sb_DivStylea.Append("<tr class=\"listTableRow\"  style=\"background-color:#CAFFFF;\">");
                        Sb_DivStylea.Append("<td align=\"right\" style=\"height: 25px; width: 40px;\">" + Convert.ToString(j + 1) + "</td>\n");
                        string s_DetailsOrderNo = Dtb_ProductsTable.Rows[j]["v_OrderNo"] == null ? "" : Dtb_ProductsTable.Rows[j]["v_OrderNo"].ToString();
                        string s_DetailsID = Dtb_ProductsTable.Rows[j]["KPO_ID"] == null ? "" : Dtb_ProductsTable.Rows[j]["KPO_ID"].ToString();
                        if (this.Tbx_ID.Text == "")
                        {
                            Sb_DivStylea.Append("<td align=\"left\"><a href=\"../Order/Knet_Procure_OpenBilling_View.aspx?ID=" + s_DetailsOrderNo + "\">" + s_DetailsOrderNo + "</td>\n");
                        }
                        else
                        {

                            Sb_DivStylea.Append("<td align=\"left\">&nbsp;</td>\n");
                        }
                        if (s_DetailsOrderNo != "")
                        {
                            KNet.Model.Knet_Procure_OrdersList Model_OrdersList = Bll_OrdersList.GetModelB(s_DetailsOrderNo);
                            try
                            {
                                string s_Sql1 = " select top 1 * from KNet_Sales_OutWareList_FlowList where ReTime is not null and OutWareNO='" + s_DetailsOrderNo + "' order by FollowDateTime desc";
                                this.BeginQuery(s_Sql1);
                                DataTable Dtb_Details = (DataTable)this.QueryForDataTable();
                                if (Dtb_Details.Rows.Count > 0)
                                {
                                    s_FollowText = Dtb_Details.Rows[0]["FollowText"].ToString();
                                    s_Date = DateTime.Parse(Dtb_Details.Rows[0]["ReTime"].ToString()).ToShortDateString();

                                }
                                else
                                {
                                    s_Date = "";
                                    s_FollowText = "";
                                }
                               // s_Date = DateTime.Parse(Model_OrdersList.OrderDateTime.ToString()).ToShortDateString();
                                //s_PreDate = DateTime.Parse(Model_OrdersList.OrderPreToDate.ToString()).ToShortDateString();
                            }
                            catch
                            {
                                s_Date = "";
                                s_FollowText = "";
                            }
                            string s_KD = "";
                            Sb_DivStylea.Append("<td align=\"left\">" + base.Base_GetProdutsName(Dtb_ProductsTable.Rows[j]["XPP_ProductsBarCode"] == null ? "" : Dtb_ProductsTable.Rows[j]["XPP_ProductsBarCode"].ToString()) + "</td>\n");

                            Sb_DivStylea.Append("<td align=\"left\">" + base.Base_GetProductsEdition(Dtb_ProductsTable.Rows[j]["XPP_ProductsBarCode"] == null ? "" : Dtb_ProductsTable.Rows[j]["XPP_ProductsBarCode"].ToString()) + "</td>\n");

                            Sb_DivStylea.Append("<td align=\"left\">" + Dtb_ProductsTable.Rows[j]["v_OrderAmount"].ToString() + "</td>\n");
                            Sb_DivStylea.Append("<td align=\"left\">" + Dtb_ProductsTable.Rows[j]["wrkNumber"].ToString() + "</td>\n");
                            this.BeginQuery("Select * from KNet_Sys_WareHouse  where KSW_Type=0 and SuppNo='" + Model.SuppNo + "' ");
                            DataTable Dtb_Table1=(DataTable)this.QueryForDataTable();
                            string s_KCDetails="";
                            if(Dtb_Table1.Rows.Count>0)
                            {
                                for (int i_1 = 0; i_1 < Dtb_Table1.Rows.Count; i_1++)
                                {
                                    s_KCDetails = base.Base_GetHouseAndNumber(Dtb_ProductsTable.Rows[j]["XPP_ProductsBarCode"].ToString(), Dtb_Table1.Rows[i_1]["HouseNo"].ToString()) + "<br/>";
                                }
                            }
                            Sb_DivStylea.Append("<td align=\"left\">" + s_KCDetails + "</td>\n");//库存

                            Sb_DivStylea.Append("<td align=\"left\">&nbsp;</td>\n");
                            Sb_DivStylea.Append("<td align=\"left\">" + s_Date + "</td>\n");

                            Sb_DivStylea.Append("<td align=\"left\">" + s_FollowText + "</td>\n");//快递

                        }
                        else
                        {
                            Sb_DivStylea.Append("<td align=\"left\">" + base.Base_GetProdutsName(Dtb_ProductsTable.Rows[j]["XPP_ProductsBarCode"] == null ? "" : Dtb_ProductsTable.Rows[j]["XPP_ProductsBarCode"].ToString()) + "</td>\n");

                            Sb_DivStylea.Append("<td align=\"left\">" + base.Base_GetProductsEdition(Dtb_ProductsTable.Rows[j]["XPP_ProductsBarCode"] == null ? "" : Dtb_ProductsTable.Rows[j]["XPP_ProductsBarCode"].ToString()) + "</td>\n");
                            Sb_DivStylea.Append("<td align=\"center\" colspan=\"2\"></td>\n");
                            this.BeginQuery("Select * from KNet_Sys_WareHouse  where KSW_Type=0 and SuppNo='" + Model.SuppNo + "' ");
                            DataTable Dtb_Table1 = (DataTable)this.QueryForDataTable();
                            string s_KCDetails = "";
                            if (Dtb_Table1.Rows.Count > 0)
                            {
                                for (int i_1 = 0; i_1 < Dtb_Table1.Rows.Count; i_1++)
                                {
                                    s_KCDetails = base.Base_GetHouseAndNumber(Dtb_ProductsTable.Rows[j]["XPP_ProductsBarCode"].ToString(), Dtb_Table1.Rows[i_1]["HouseNo"].ToString()) + "<br/>";
                                }
                            }
                            Sb_DivStylea.Append("<td align=\"left\">" + s_KCDetails + "</td>\n");//库存

                            Sb_DivStylea.Append("<td align=\"center\" colspan=\"3\"></td>\n");

                        }
                        Sb_DivStylea.Append("</tr >\n");
                    }
                    Sb_DivStylea.Append("</div>\n");
                }
            }
        }
        catch (Exception ex) { }
        return Sb_DivStylea.ToString();
    }

    public string GetContract(string s_ContractNos, string s_ContractNo1, int i_Tag)
    {
        string s_Return = "&nbsp;";
        try
        {

            KNet.BLL.KNet_Sales_ContractList bll = new KNet.BLL.KNet_Sales_ContractList();

            string[] s_ContractNo = s_ContractNos.Split(',');
            for (int i = 0; i < s_ContractNo.Length; i++)
            {
                KNet.Model.KNet_Sales_ContractList Model = bll.GetModelB(s_ContractNo[i]);
                if (s_ContractNo[i] != "")
                {
                    s_Return += "<a href=\"../SalesContract/KNet_Sales_ContractList_View.aspx?ID=" + s_ContractNo[i] + "\" >" + s_ContractNo[i] + "</a>";
                    if (i_Tag == 0)
                    {
                        s_Return += "(";
                        s_Return += " " + base.Base_GetCustomerName(Model.CustomerValue) + "|" + bll.GetTotalNumber(s_ContractNo[i]) + ")";
                    }
                    s_Return += "<br>";

                }
            }
            if (s_Return == "")
            {
                KNet.Model.KNet_Sales_ContractList Model = bll.GetModelB(s_ContractNo1);
                if (s_ContractNo1 != "")
                {
                    s_Return += "<a href=\"../SalesContract/Xs_ContractList_View.aspx?ID=" + s_ContractNo1 + "\" >" + s_ContractNo1 + "</a>";
                    if (i_Tag == 0)
                    {
                        s_Return += "(";
                        s_Return += " " + base.Base_GetCustomerName(Model.CustomerValue) + "|" + bll.GetTotalNumber(s_ContractNo1) + ")";

                    }
                    s_Return += "<br>";
                }
            }
        }
        catch
        { }
        return s_Return;
    }
    public string GetState(string s_ID)
    {
        string s_Return = "";
        try
        {
            this.BeginQuery("select * from v_OrderRK where V_OrderNo='" + s_ID + "' ");
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                s_Return = base.Base_GetBasicCodeName("126", Dtb_Table.Rows[0]["RkState"].ToString());
                s_Return += "<HR/>";
                s_Return += Dtb_Table.Rows[0]["RkNumber"].ToString();
            }
        }
        catch
        { }
        return s_Return;
    }
}
