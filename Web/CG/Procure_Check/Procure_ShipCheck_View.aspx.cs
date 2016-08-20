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

using System.IO;
using System.Text;

using KNet.DBUtility;
using KNet.Common;
using Excel1 = Microsoft.Office.Interop.Excel;
public partial class Web_Sales_Xs_ShipWareOut_View : BasePage
{
    public string s_Time = "";
    public string s_HouseName = "";
    public string s_Details = "";
    public string s_ExcelName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable Dtb_Excel = new DataTable();
        if (!IsPostBack)
        {
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            KNet.BLL.Cg_Order_Checklist Bll = new KNet.BLL.Cg_Order_Checklist();
            KNet.Model.Cg_Order_Checklist Model = Bll.GetModel(s_ID);
            if (Model.COC_Type == "0")//遥控器采购
            {
                string s_Sql = "Select b.COD_ProductsBarCode,isnull(e.CustomerValue,d.KWD_Custmoer),d.DirectOutDateTime,isnull(e.KSO_PlanOutWareDateTime,d.DirectOutDateTime),b.COD_Dznumber,b.COD_wuliu,b.COd_Price,b.COD_HandPrice, ";
                s_Sql += "b.COD_Money,b.COD_IC,B.COD_ICNumber,a.COC_Stime,a.COC_HouseNo,b.COD_BNumber,COD_DirectOutID  from Cg_Order_Checklist a join Cg_Order_Checklist_Details b on a.COC_Code=b.COD_CheckNo join KNet_WareHouse_DirectOutList_Details c on c.ID=b.COD_DirectOutID join KNet_WareHouse_DirectOutList d on d.DirectOutNo=c.DirectOutNo left join KNet_Sales_OutWareList e on e.OutWareNo=d.KWD_ShipNo  Where 1=1 and a.COC_Code='" + s_ID + "' Order by d.DirectOutDateTime";
                string s_Date = "", s_House = "", s_Style = "";
                string s_Head = "";
                this.BeginQuery(s_Sql);
                this.QueryForDataTable();
                DataTable Dtb_Table = this.Dtb_Result;
                decimal d_Number = 0, d_Number1 = 0, d_Number2 = 0, d_Number3 = 0;
                if (Dtb_Table.Rows.Count > 0)
                {
                    for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                    {
                        if (i % 2 == 0)
                        {
                            s_Style = "class='gg'";
                        }
                        else
                        {
                            s_Style = "class='rr'";
                        }
                        s_Details += " <tr " + s_Style + " onmouseover='setActiveBG(this)'>\n";
                        s_Details += "<td align=center class='ListHeadDetails' noWrap>" + (i + 1).ToString() + "</td>\n";
                        s_Details += "<td align=left class='ListHeadDetails' noWrap>" + base.Base_GetProductsEdition(Dtb_Table.Rows[i][0].ToString()) + "</td>\n";
                        s_Details += "<td align=left class='ListHeadDetails' noWrap>" + base.Base_GetCustomerName(Dtb_Table.Rows[i][1].ToString()) + "</td>\n";
                        s_Details += "<td align=center class='ListHeadDetails' noWrap>" + DateTime.Parse(Dtb_Table.Rows[i][2].ToString()).ToShortDateString() + "</td>\n";
                        s_Details += "<td align=center class='ListHeadDetails' noWrap>" + DateTime.Parse(Dtb_Table.Rows[i][3].ToString()).ToShortDateString() + "</td>\n";
                        s_Details += "<td align=right class='ListHeadDetails' noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i][4].ToString(), 0) + "</td>\n";
                        s_Details += "<td align=right class='ListHeadDetails' noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i][13].ToString(), 0) + "</td>\n";
                        s_Details += "<td align=left class='ListHeadDetails' noWrap>" + Dtb_Table.Rows[i][5].ToString() + "&nbsp;</td>\n";
                        s_Details += "<td align=center class='ListHeadDetails' noWrap>" + Dtb_Table.Rows[i][6].ToString() + "</td>\n";//handprice
                        s_Details += "<td align=center class='ListHeadDetails' noWrap>" + Dtb_Table.Rows[i][7].ToString() + "</td>\n";//money
                        s_Details += "<td align=center class='ListHeadDetails' noWrap>" + Dtb_Table.Rows[i][8].ToString() + "</td>\n";//money
                        s_Details += "<td align=left class='ListHeadDetails' noWrap>" + GetBattery(Dtb_Table.Rows[i][14].ToString(), "1") + "</td>\n";//money
                        s_Details += "<td align=right class='ListHeadDetails' noWrap>" + GetBattery(Dtb_Table.Rows[i][14].ToString(), "0") + "</td>\n";

                        s_Details += "<td align=center class='ListHeadDetails' noWrap>&nbsp;</td>\n";//money
                        s_Details += "<td align=center class='ListHeadDetails' noWrap>&nbsp;</td>\n";//money
                        s_Details += " </tr>";
                        d_Number += decimal.Parse(Dtb_Table.Rows[i][4].ToString());
                        d_Number1 += decimal.Parse(Dtb_Table.Rows[i][13].ToString());
                        d_Number2 += decimal.Parse(Dtb_Table.Rows[i][8].ToString());
                        try
                        {
                            d_Number3 += decimal.Parse(GetBattery(Dtb_Table.Rows[i][14].ToString(), "0"));
                        }
                        catch
                        { }
                    }
                    s_Details += " <tr " + s_Style + " onmouseover='setActiveBG(this)'>\n";
                    s_Details += "<td align=center class='ListHeadDetails' noWrap colspan='5'>合计：</td>\n";
                    s_Details += "<td align=center class='ListHeadDetails' noWrap>" + base.FormatNumber1(d_Number.ToString(), 0) + "</td>\n";
                    s_Details += "<td align=center class='ListHeadDetails' noWrap>" + base.FormatNumber1(d_Number1.ToString(), 0) + "</td>\n";
                    s_Details += "<td align=center class='ListHeadDetails' noWrap colspan='3'>&nbsp;</td>\n";//money
                    s_Details += "<td align=center class='ListHeadDetails' noWrap>" + base.FormatNumber1(d_Number2.ToString(), 3) + "</td>\n";
                    s_Details += "<td align=center class='ListHeadDetails' noWrap>&nbsp;</td>\n";//money
                    s_Details += "<td align=center class='ListHeadDetails' noWrap>" + base.FormatNumber1(d_Number3.ToString(), 0) + "</td>\n";
                    s_Details += "<td align=center class='ListHeadDetails' noWrap colspan='2'>&nbsp;</td>\n";//money
                    s_Details += " </tr>";
                    s_Date = DateTime.Parse(Dtb_Table.Rows[0][11].ToString()).ToShortDateString();
                    s_House = Dtb_Table.Rows[0][12].ToString();
                }

                s_Time = "对账月份:" + DateTime.Parse(s_Date).Year.ToString() + "-" + DateTime.Parse(s_Date).Month.ToString();
                s_HouseName = "供应商名称:" + base.Base_GetHouseName(s_House);


                s_ExcelName = base.Base_GetHouseName(s_House) + "(" + DateTime.Parse(s_Date).Year.ToString() + "." + DateTime.Parse(s_Date).Month.ToString() + ").xls";
                s_Head += "<table border=\"1\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"ListDetails\" >\n \n";
                s_Head += "<tr >\n<td colspan=\"15\" class=\"ListHead\"><font size=\"6\"><b>士腾与供应商对账确认单</b></font></td></tr>\n<tr >\n<td colspan=\"15\" class=\"ListHead\" align=\"center\">1.发货对账单</td></tr>\n";
                s_Head += "<tr >\n<td colspan=\"11\"   class=\"ListHead\"  align=\"left\">" + s_HouseName + "</td><td colspan=\"4\" class=\"ListHead\" align=\"right\">" + s_Time + "</td></tr>\n";
                s_Head += "<tr ><td  class=\"ListHead\" colspan=13 align=\"center\">供应商填写</td><td class=\"ListHead\" align=\"center\" colspan=2>士腾采购填写</td></tr><tr >\n<td class=\"ListHead\" rowspan=2>序号</td>\n";
                s_Head += "<td class=\"ListHead\" align=center  rowspan=2>产品版本</td>\n";
                s_Head += "<td class=\"ListHead\" align=center  rowspan=2>收货单位</td>\n";
                s_Head += "<td class=\"ListHead\" rowspan=2>出库日期</td>\n";
                s_Head += "<td class=\"ListHead\" rowspan=2>到货日期</td>\n";
                s_Head += "<td class=\"ListHead\" rowspan=2>发货数量</td>\n";
                s_Head += "<td class=\"ListHead\" rowspan=2>备料</td>\n";
                s_Head += "<td class=\"ListHead\" rowspan=2>物流公司名称(单号/联系电话)</td>\n";
                s_Head += "<td class=\"ListHead\" align=center  colspan=2>单价</td>\n";
                s_Head += "<td class=\"ListHead\" align=center rowspan=2>总额</td>\n";
                s_Head += "<td class=\"ListHead\" align=center  colspan=2>电池</td>\n";
                s_Head += "<td class=\"ListHead\" rowspan=2>士腾确认</td>\n";
                s_Head += "<td class=\"ListHead\" rowspan=2>备注</td>\n</tr>\n";
                s_Head += "<tr><td class=\"ListHead\">材料费</td>\n";
                s_Head += "<td class=\"ListHead\">加工费</td>\n";
                s_Head += "<td class=\"ListHead\">型号</td>\n";
                s_Head += "<td class=\"ListHead\">数量</td>\n</tr>\n";


                //s_Details += "<tr>\n<td colspan=\"17\" class=\"ListHead\"  width=\"100%\" align=\"center\">2.不良品返修对账单</td></tr>";
                //s_Details += "<tr ><td  class=\"ListHead\" colspan=10 align=\"center\">供应商填写</td><td class=\"ListHead\" align=\"center\" colspan=7>士腾采购填写</td></tr>";
                //s_Details += "<tr >\n<td class=\"ListHead\">序号</td>\n";
                //s_Details += "\n<td class=\"ListHead\" >产品型号</td>\n";
                //s_Details += "\n<td class=\"ListHead\" >退货日期</td>\n";
                //s_Details += "\n<td class=\"ListHead\" >退货数量</td>\n";
                //s_Details += "\n<td class=\"ListHead\" >返回日期</td>\n";
                //s_Details += "\n<td class=\"ListHead\" >返还数量</td>\n";
                //s_Details += "\n<td class=\"ListHead\" >物流名称和单号</td>\n";
                //s_Details += "\n<td class=\"ListHead\" >维修记录（原因）</td>\n";
                //s_Details += "\n<td class=\"ListHead\" >签收日期</td>\n";
                //s_Details += "\n<td class=\"ListHead\" >签收人</td>\n";
                //s_Details += "\n<td class=\"ListHead\" >确认人</td>\n";
                //s_Details += "\n<td class=\"ListHead\" >确认时间</td>\n";
                //s_Details += "\n<td class=\"ListHead\" >实收数量</td>\n";
                //s_Details += "\n<td class=\"ListHead\" >确认状况</td>\n";
                //s_Details += "\n<td class=\"ListHead\" colspan=\"3\" >备注</td>\n</tr>";

                //s_Details += "<tr>\n<td colspan=\"17\" class=\"ListHead\"  align=\"center\">3.备品对账单</td></tr>";
                //s_Details += "<tr ><td class=\"ListHead\" colspan=9 align=\"center\">供应商填写</td><td class=\"ListHead\" align=\"center\" colspan=8>士腾采购填写</td></tr>";
                //s_Details += "<tr >\n<td class=\"ListHead\" >序号</td>\n";
                //s_Details += "\n<td class=\"ListHead\" >产品型号</td>\n";
                //s_Details += "\n<td class=\"ListHead\" >发货日期</td>\n";
                //s_Details += "\n<td class=\"ListHead\" >收货单位</td>\n";
                //s_Details += "\n<td class=\"ListHead\" >发货数量</td>\n";
                //s_Details += "\n<td class=\"ListHead\" >物流名称和单号</td>\n";
                //s_Details += "\n<td class=\"ListHead\" >备品记录（原因）</td>\n";
                //s_Details += "\n<td class=\"ListHead\" >签收日期</td>\n";
                //s_Details += "\n<td class=\"ListHead\" >签收人</td>\n";
                //s_Details += "\n<td class=\"ListHead\" >确认人</td>\n";
                //s_Details += "\n<td class=\"ListHead\" >确认时间</td>\n";
                //s_Details += "\n<td class=\"ListHead\" >实收数量</td>\n";
                //s_Details += "\n<td class=\"ListHead\" >确认状况</td>\n";
                //s_Details += "\n<td class=\"ListHead\" colspan=\"4\" >备注</td>\n</tr>";


                //s_Details += "<tr>\n<td colspan=\"17\" class=\"ListHead\" align=\"center\">4. IC对账单</td></tr>";
                //s_Details += "<tr ><td  class=\"ListHead\" colspan=5 align=\"center\">士腾发货人员填写</td><td class=\"ListHead\" align=\"center\" colspan=7>供应商填写</td><td class=\"ListHead\" align=\"center\" colspan=5 >士腾填写</td></tr>";
                //s_Details += "<tr >\n<td class=\"ListHead\" >序号</td>\n";
                //s_Details += "\n<td class=\"ListHead\" >对应成品型号名称</td>\n";
                //s_Details += "\n<td class=\"ListHead\" >IC型号</td>\n";
                //s_Details += "\n<td class=\"ListHead\" >发货日期</td>\n";
                //s_Details += "\n<td class=\"ListHead\" >发货数量</td>\n";
                //s_Details += "\n<td class=\"ListHead\" >签收日期</td>\n";
                //s_Details += "\n<td class=\"ListHead\" >实收数量</td>\n";
                //s_Details += "\n<td class=\"ListHead\" >成品出库数量</td>\n";
                //s_Details += "\n<td class=\"ListHead\" >IC不良数量</td>\n";
                //s_Details += "\n<td class=\"ListHead\" >不良原因 不良品数量超过规定损耗率时填写</td>\n";
                //s_Details += "\n<td class=\"ListHead\" >退回数量</td>\n";
                //s_Details += "\n<td class=\"ListHead\" >前期库存</td>\n";
                //s_Details += "\n<td class=\"ListHead\" >订单未出数量</td>\n";
                //s_Details += "\n<td class=\"ListHead\" >IC库存量</td>\n";
                //s_Details += "\n<td class=\"ListHead\" colspan=3 >确认人</td>\n</tr>";

                /*
                s_Details += "<tr>\n<td colspan=\"15\" class=\"ListHead\" align=\"center\">2.其他项目对账单</td></tr>";
                s_Details += "<tr ><td  class=\"ListHead\"  colspan=10 align=\"center\">供应商填写</td><td class=\"ListHead\"  align=\"center\" colspan=5>士腾相关部门填写</td></tr>";
                s_Details += "<tr >\n<td class=\"ListHead\">序号</td>\n";
                s_Details += "\n<td class=\"ListHead\" >项目</td>\n";
                s_Details += "\n<td class=\"ListHead\" >发生日期</td>\n";
                s_Details += "\n<td class=\"ListHead\" >客户</td>\n";
                s_Details += "\n<td class=\"ListHead\" >发生原因</td>\n";
                s_Details += "\n<td class=\"ListHead\" >数量</td>\n";
                s_Details += "\n<td class=\"ListHead\" >总额</td>\n";
                s_Details += "\n<td class=\"ListHead\" >供应商承担金额</td>\n";
                s_Details += "\n<td class=\"ListHead\" >士腾承担金额</td>\n";
                s_Details += "\n<td class=\"ListHead\" >备注</td>\n";
                s_Details += "\n<td class=\"ListHead\" colspan=5 >士腾确认</td>\n</tr>";
                string s_FreightSql = "select * from Xs_Sales_Freight a join KNet_WareHouse_DirectOutList b on a.XSF_FID=b.DirectOutNo ";
                s_FreightSql += " where a.XSF_Customervalue in (select SuppNo from KNet_Sys_WareHouse where HouseNo='" + s_House + "') ";
                try
                {
                    if (Model.COC_BeginDate.ToString() != "")
                    {
                        s_FreightSql += " and a.XSF_Stime >='" + Model.COC_BeginDate.ToString() + "'";
                    }
                    if (Model.COC_EndDate.ToString() != "")
                    {
                        s_FreightSql += " and a.XSF_Stime <='" + Model.COC_EndDate.ToString() + "'";
                    }
                }
                catch{}
                s_FreightSql += " order by a.XSF_Stime ";
                this.BeginQuery(s_FreightSql);
                this.QueryForDataTable();
                DataTable Dtb_Freight = Dtb_Result;
                decimal d_FAmount = 0, d_FAmount1 = 0, d_FAmount2 = 0, d_FAmount3 = 0;
                for (int i = 0; i < Dtb_Freight.Rows.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        s_Style = "class='gg'";
                    }
                    else
                    {
                        s_Style = "class='rr'";
                    }
                    s_Details += " <tr " + s_Style + " onmouseover='setActiveBG(this)'>\n";
                    s_Details += "<td align=center class='ListHeadDetails' noWrap>" + (i + 1).ToString() + "</td>\n";
                    s_Details += "<td align=center class='ListHeadDetails' noWrap>" + base.Base_GetShipDetailProductsPatten(Dtb_Freight.Rows[i]["DirectOutNo"].ToString()) + "</td>\n";
                    s_Details += "<td align=center class='ListHeadDetails' noWrap>" + DateTime.Parse(Dtb_Freight.Rows[i]["XSF_Stime"].ToString()).ToShortDateString() + "</td>\n";
                    s_Details += "<td align=center class='ListHeadDetails' noWrap>" + base.Base_GetCustomerName(Dtb_Freight.Rows[i]["KWD_Custmoer"].ToString()) + "</td>\n";
                    s_Details += "<td align=center class='ListHeadDetails' noWrap>" + Dtb_Freight.Rows[i]["XSF_Description"].ToString() + "&nbsp;</td>\n";
                    s_Details += "<td align=right class='ListHeadDetails' noWrap>" + base.FormatNumber1(Dtb_Freight.Rows[i]["XSF_TotalNumber"].ToString(), 2) + "</td>\n";
                    s_Details += "<td align=right class='ListHeadDetails' noWrap>" + base.FormatNumber1(Dtb_Freight.Rows[i]["XSF_TotalMoney"].ToString(), 2) + "</td>\n";
                    s_Details += "<td align=right class='ListHeadDetails' noWrap>" + base.FormatNumber1(Dtb_Freight.Rows[i]["XSF_FMoney"].ToString(), 2) + "</td>\n";
                    s_Details += "<td align=right class='ListHeadDetails' noWrap>" + base.FormatNumber1(Dtb_Freight.Rows[i]["XSF_Money"].ToString(), 2) + "</td>\n";
                    s_Details += "<td align=center class='ListHeadDetails' noWrap>" + Dtb_Freight.Rows[i]["XSF_Remarks"].ToString() + "&nbsp;</td>\n";
                    s_Details += "<td align=center class='ListHeadDetails' colspan=6 noWrap>&nbsp;</td>\n";//money
                    s_Details += " </tr>";
                    d_FAmount += decimal.Parse(Dtb_Freight.Rows[i]["XSF_TotalNumber"].ToString());
                    d_FAmount1 += decimal.Parse(Dtb_Freight.Rows[i]["XSF_TotalMoney"].ToString());
                    d_FAmount2 += decimal.Parse(Dtb_Freight.Rows[i]["XSF_FMoney"].ToString());
                    d_FAmount3 += decimal.Parse(Dtb_Freight.Rows[i]["XSF_Money"].ToString());
                }
                s_Details += " <tr " + s_Style + " onmouseover='setActiveBG(this)'>\n";
                s_Details += "<td align=center class='ListHeadDetails' noWrap colspan='5'>合计：</td>\n";
                s_Details += "<td align=right class='ListHeadDetails' noWrap>" + base.FormatNumber1(d_FAmount.ToString(), 2) + "</td>\n";
                s_Details += "<td align=right class='ListHeadDetails' noWrap>" + base.FormatNumber1(d_FAmount1.ToString(), 2) + "</td>\n";
                s_Details += "<td  align=right  class='ListHeadDetails' noWrap>" + base.FormatNumber1(d_FAmount2.ToString(), 2) + "</td>\n";
                s_Details += "<td align=right class='ListHeadDetails' noWrap>" + base.FormatNumber1(d_FAmount3.ToString(), 2) + "</td>\n";
                s_Details += "<td align=center class='ListHeadDetails' noWrap colspan=7>&nbsp;</td>\n";//money
                s_Details += " </tr>";
                
                */
                s_Details += "<br><tr>\n<td class=\"ListHeadDetails\" colspan=2>供应商审核结果:</td><td class=\"ListHeadDetails\" >&nbsp;</td>";
                s_Details += "<td class=\"ListHeadDetails\" colspan=2>制表人及日期:</td><td class=\"ListHeadDetails\" colspan=2>&nbsp;</td>";
                s_Details += "<td class=\"ListHeadDetails\" colspan=2>核准人及时间:</td><td class=\"ListHeadDetails\" colspan=2>&nbsp;</td>";
                s_Details += "<td class=\"ListHeadDetails\" colspan=2>总经理确认:</td><td class=\"ListHeadDetails\" colspan=2>&nbsp;</td></tr>";
                s_Details += "<br><tr>\n<td class=\"ListHeadDetails\" colspan=2>士腾审核结果:</td><td class=\"ListHeadDetails\">&nbsp;</td>";
                s_Details += "<td class=\"ListHeadDetails\" colspan=2>制表人及日期:</td><td class=\"ListHeadDetails\"  colspan=2>&nbsp;</td>";
                s_Details += "<td class=\"ListHeadDetails\" colspan=2>核准人及时间:</td><td class=\"ListHeadDetails\"  colspan=2>&nbsp;</td>";
                s_Details += "<td class=\"ListHeadDetails\" colspan=2>总经理确认:</td><td class=\"ListHeadDetails\" colspan=2>&nbsp;</td></tr>";

                s_Details += "</table>";

                this.Lbl_Details.Text = s_Head + s_Details;
                this.Lbl_Details.Text += "<table border=\"1\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"ListDetails\" >\n \n";
                this.Lbl_Details.Text += "<tr><td class=\"ListHeadLeft\" colspan=11>需开发票</td></tr>";
                this.Lbl_Details.Text += ShowInfo(s_ID);
                this.Lbl_Details.Text += "</table>";
            }
            else//原材料对账单
            {
                string s_Sql = "Select b.COD_ProductsBarCode,a.COC_SuppNo,d.WareHouseDateTime,b.COD_Dznumber,b.COD_wuliu,b.COd_Price, ";
                s_Sql += "b.COD_Money,b.COD_CustomerValue,a.COC_Details,a.COC_Stime,e.OrderNo,b.COD_BNumber,d.KPO_CheckTime from Cg_Order_Checklist a join Cg_Order_Checklist_Details b on a.COC_Code=b.COD_CheckNo join Knet_Procure_WareHouseList_Details c on c.ID=b.COD_DirectOutID join Knet_Procure_WareHouseList d on d.WareHouseNo=c.WareHouseNo left join Knet_Procure_OrdersList e on  e.OrderNO=d.OrderNo Where 1=1 and a.COC_Code='" + s_ID + "' Order by d.WareHouseDateTime";
                string s_Date = "", s_House = "", s_Style = "";
                string s_Head = "";
                this.BeginQuery(s_Sql);
                this.QueryForDataTable();
                DataTable Dtb_Table = this.Dtb_Result;
                if (Dtb_Table.Rows.Count > 0)
                {
                    for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                    {
                        if (i % 2 == 0)
                        {
                            s_Style = "class='gg'";
                        }
                        else
                        {
                            s_Style = "class='rr'";
                        }
                        s_Details += " <tr " + s_Style + " onmouseover='setActiveBG(this)'>\n";
                        s_Details += "<td align=center class='ListHeadDetails' noWrap>" + (i + 1).ToString() + "</td>\n";
                        s_Details += "<td align=left class='ListHeadDetails' noWrap>" + base.Base_GetProdutsName(Dtb_Table.Rows[i][0].ToString()) + "</td>\n";
                        s_Details += "<td align=left class='ListHeadDetails' noWrap>" + base.Base_GetProductsEdition(Dtb_Table.Rows[i][0].ToString()) + "</td>\n";
                        s_Details += "<td align=left class='ListHeadDetails' noWrap>" + base.Base_GetHouseName(Dtb_Table.Rows[i][7].ToString()) + "</td>\n";
                        try
                        {
                            s_Details += "<td align=left class='ListHeadDetails' noWrap>" + Dtb_Table.Rows[i][10].ToString() + "</td>\n";
                        }
                        catch { s_Details += "<td align=left class='ListHeadDetails' noWrap>&nbsp;</td>\n"; }
                        /*s_Details += "<td align=left class='ListHeadDetails' noWrap>" + DateTime.Parse(Dtb_Table.Rows[i]["KPO_CheckTime"].ToString()).ToShortDateString() + "</td>\n";
                        */
                        s_Details += "<td align=left class='ListHeadDetails' noWrap>" + DateTime.Parse(Dtb_Table.Rows[i][2].ToString()).ToShortDateString() + "</td>\n";


                        s_Details += "<td align=right class='ListHeadDetails' noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i][3].ToString(), 0) + "</td>\n";
                        s_Details += "<td align=right class='ListHeadDetails' noWrap>" + Dtb_Table.Rows[i][11].ToString() + "</td>\n";
                        s_Details += "<td align=right class='ListHeadDetails' noWrap>&nbsp;" + Dtb_Table.Rows[i][4].ToString() + "</td>\n";//handprice
                        s_Details += "<td align=right class='ListHeadDetails' noWrap>" + Dtb_Table.Rows[i][5].ToString() + "</td>\n";//money
                        s_Details += "<td align=right class='ListHeadDetails' noWrap>" + Dtb_Table.Rows[i][6].ToString() + "</td>\n";//money
                        s_Details += "<td align=center class='ListHeadDetails' noWrap>&nbsp;" + Dtb_Table.Rows[i][8].ToString() + "</td>\n";

                        s_Details += "<td align=center class='ListHeadDetails' noWrap>&nbsp;</td>\n";//money
                        s_Details += "<td align=center class='ListHeadDetails' noWrap>&nbsp;</td>\n";//money
                        s_Details += "<td align=center class='ListHeadDetails' noWrap>&nbsp;</td>\n";//money
                        s_Details += " </tr>";
                    }
                    s_Date = DateTime.Parse(Dtb_Table.Rows[0][9].ToString()).ToShortDateString();
                    s_House = Dtb_Table.Rows[0][1].ToString();
                }

                s_Time = "对账月份:" + DateTime.Parse(s_Date).Year.ToString() + "-" + DateTime.Parse(s_Date).Month.ToString();
                s_HouseName = "供应商名称:" + base.Base_GetSupplierName(s_House);
                s_ExcelName = base.Base_GetSupplierName(s_House) + "(" + DateTime.Parse(s_Date).Year.ToString() + "." + DateTime.Parse(s_Date).Month.ToString() + ").xls";

                s_Head += "<table border=\"1\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<tdead class=\"fixedHeader\"> \n";
                s_Head += "<tr >\n<td  class=\"ListHead\" colspan=\"15\"><font size=\"6\"><b>士腾与供应商对账确认单</b></font></td></tr>\n<tr >\n<td colspan=\"15\"  class=\"ListHead\" align=\"center\">1.发货对账单</td></tr>\n";
                s_Head += "<tr >\n<td colspan=\"9\"  class=\"ListHead\" >" + s_HouseName + "</td><td colspan=\"6\" class=\"ListHead\">" + s_Time + "</td></tr>\n";
                s_Head += "<td class=\"ListHead\">序号</td>\n";
                s_Head += "<td class=\"ListHead\" align=center  >产品名称</td>\n";
                s_Head += "<td class=\"ListHead\" align=center  >产品型号</td>\n";
                s_Head += "<td class=\"ListHead\">收货单位</td>\n";
                s_Head += "<td class=\"ListHead\"> 采购单号</td>\n";
                s_Head += "<td class=\"ListHead\" >入库日期</td>\n";
                s_Head += "<td class=\"ListHead\" >发货数量</td>\n";
                s_Head += "<td class=\"ListHead\" >备料数量</td>\n";
                s_Head += "<td class=\"ListHead\" >物流及单号</td>\n";
                s_Head += "<td class=\"ListHead\" align=center >单价</td>\n";
                s_Head += "<td class=\"ListHead\" align=center>总额</td>\n";
                s_Head += "<td class=\"ListHead\">备注</td>\n";
                s_Head += "<td class=\"ListHead\" >确认人</td>\n";
                s_Head += "<td class=\"ListHead\" >确认时间</td>\n";
                s_Head += "<td class=\"ListHead\" >确认方法</td>\n";
                s_Head += "</thead><tbody class=\"scrollContent\">";
                /*
                s_Details += "<tr>\n<td colspan=\"15\" class=\"ListHead\" align=\"center\">2.不良品返修对账单</td></tr>";
                s_Details += "<tr ><td  class=\"ListHead\"colspan=10 align=\"center\">供应商填写</td>\n ";
                s_Details += "<td class=\"ListHead\" align=\"center\" colspan=5>士腾采购填写</td></tr>";
                s_Details += "<tr >\n<td class=\"ListHead\" >序号</td>\n";
                s_Details += "\n<td class=\"ListHead\" >产品型号</td>\n";
                s_Details += "\n<td class=\"ListHead\" >退货日期</td>\n";
                s_Details += "\n<td class=\"ListHead\" >退货数量</td>\n";
                s_Details += "\n<td class=\"ListHead\" >返回日期</td>\n";
                s_Details += "\n<td class=\"ListHead\" >返还数量</td>\n";
                s_Details += "\n<td class=\"ListHead\" >物流名称和单号</td>\n";
                s_Details += "\n<td class=\"ListHead\" >维修记录（原因）</td>\n";
                s_Details += "\n<td class=\"ListHead\" >签收日期</td>\n";
                s_Details += "\n<td class=\"ListHead\" >签收人</td>\n";
                s_Details += "\n<td class=\"ListHead\" >确认人</td>\n";
                s_Details += "\n<td class=\"ListHead\" >确认时间</td>\n";
                s_Details += "\n<td class=\"ListHead\" >实收数量</td>\n";
                s_Details += "\n<td class=\"ListHead\" >确认状况</td>\n";
                s_Details += "\n<td class=\"ListHead\" >备注</td>\n</tr>";



                s_Details += "<tr>\n<td colspan=\"15\"  class=\"ListHead\" align=\"center\">3.其他项目对账单</td></tr>";
                s_Details += "<tr ><td  class=\"ListHead\" colspan=9 align=\"center\">供应商填写</td><td class=\"ListHead\" colspan=6>士腾相关部门填写</td></tr>";
                s_Details += "<tr >\n<td class=\"ListHead\">序号</td>\n";
                s_Details += "\n<td class=\"ListHead\" >项目</td>\n";
                s_Details += "\n<td class=\"ListHead\" >发生日期</td>\n";
                s_Details += "\n<td class=\"ListHead\" >发生原因</td>\n";
                s_Details += "\n<td class=\"ListHead\" >数量</td>\n";
                s_Details += "\n<td class=\"ListHead\" >单价</td>\n";
                s_Details += "\n<td class=\"ListHead\" >总额</td>\n";
                s_Details += "\n<td class=\"ListHead\" >承担单位</td>\n";
                s_Details += "\n<td class=\"ListHead\" >承担数量</td>\n";
                s_Details += "\n<td class=\"ListHead\" >承担金额</td>\n";
                s_Details += "\n<td class=\"ListHead\" >确认时间</td>\n";
                s_Details += "\n<td class=\"ListHead\" colspan=\"4\" >备注</td>\n</tr>";
                 */
                s_Details += "<br><tr>\n<td class=\"ListHeadDetails\" colspan=2>供应商审核结果:</td><td class=\"ListHeadDetails\" colspan=2>&nbsp;</td>";
                s_Details += "<td class=\"ListHeadDetails\" colspan=2>制表人及日期:</td><td class=\"ListHeadDetails\" colspan=2>&nbsp;</td>";
                s_Details += "<td class=\"ListHeadDetails\" colspan=2>核准人及时间:</td><td class=\"ListHeadDetails\" colspan=2>&nbsp;</td>";
                s_Details += "<td class=\"ListHeadDetails\" colspan=2>总经理确认:</td><td class=\"ListHeadDetails\" colspan=1>&nbsp;</td></tr>";
                s_Details += "<br><tr>\n<td class=\"ListHeadDetails\" colspan=2>士腾审核结果:</td><td class=\"ListHeadDetails\" colspan=2>&nbsp;</td>";
                s_Details += "<td class=\"ListHeadDetails\" colspan=2>制表人及日期:</td><td class=\"ListHeadDetails\" colspan=2>&nbsp;</td>";
                s_Details += "<td class=\"ListHeadDetails\" colspan=2>核准人及时间:</td><td class=\"ListHeadDetails\" colspan=2>&nbsp;</td>";
                s_Details += "<td class=\"ListHeadDetails\" colspan=2>总经理确认:</td><td class=\"ListHeadDetails\" colspan=1>&nbsp;</td></tr>";
                s_Details += "</table>";
                this.Lbl_Details.Text = s_Head + s_Details;

                this.Lbl_Details.Text += "<table border=\"1\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"ListDetails\" >\n \n";
                this.Lbl_Details.Text += "<tr><td class=\"ListHeadLeft\" colspan=11>需开发票</td></tr>";
                this.Lbl_Details.Text += ShowInfo(s_ID);
                this.Lbl_Details.Text += "</table>";
            }
            ScExcel(this.Lbl_Details.Text,s_ID);
        }
    }

    private void ScExcel(string s_Details,string s_ID)
    {
        try
        {
            string s_Path = Server.MapPath("Excel/" + s_ID + ".xls");
            if (File.Exists(s_Path))
            {
                File.Delete(s_Path);
            }

            FileStream fs = new FileStream(s_Path, FileMode.Create, FileAccess.Write);
            StreamWriter rw = new StreamWriter(fs,Encoding.GetEncoding("UTF-8"));//建立StreamWriter为写作准备;
            rw.WriteLine(s_Details);
            rw.Close();
            fs.Close();
        }
        catch (Exception ex)
        { }
    }
    private string GetBattery(string s_DirectOutNoDetailsID, string s_Type)
    {
        string s_Return = "";
        try
        {
            string s_Sql = "Select Sum(a.DirectOutAmount),b.ProductsPattern from KNet_WareHouse_DirectOutList_Details a join KNet_Sys_Products b on a.ProductsBarCode=b.ProductsBarCode where DirectOutNo in (Select DirectOutNo from KNet_WareHouse_DirectOutList_Details where ID='" + s_DirectOutNoDetailsID + "' ) and ProductsType='M130704050932527' Group by b.ProductsPattern";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();

            if (this.Dtb_Result.Rows.Count > 0)
            {
                if (s_Type == "0")
                {
                    s_Return = Dtb_Result.Rows[0][0].ToString();
                }
                else
                {
                    s_Return = Dtb_Result.Rows[0][1].ToString();
                }
            }
            else
            {
                s_Return = "&nbsp";
            }
            //s_Return
        }
        catch
        { }
        return s_Return;
    }



    private string ShowInfo(string s_ID)
    {
        string s_Return = "";
        KNet.BLL.Cg_Order_Checklist BLL = new KNet.BLL.Cg_Order_Checklist();
        KNet.Model.Cg_Order_Checklist Model = BLL.GetModel(s_ID);
        KNet.BLL.Cg_Order_Checklist_Details Bll_Details = new KNet.BLL.Cg_Order_Checklist_Details();
        DataSet Dts_Table = Bll_Details.GetList(" COD_CheckNo='" + s_ID + "' order by COD_ProductsBarCode,COD_Price,COD_HandPrice,COD_Code ");

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
        // this.Lbl_KpDetails.Text = "  最大开票金额：<font color=red>" + d_MaxMoney.ToString() + "</font>";
        //this.Lbl_KpDetails.Text += "   单张最大开票行数：<font color=red>" + i_MaxRow.ToString() + "</font>";
        decimal d_Total = 0, d_Total1 = 0, d_Total2 = 0, d_Total3 = 0, d_TotalPrice = 0, d_TotalHandPrice = 0, d_FPNumber = 0;
        decimal dd_Total = 0, dd_Total1 = 0, dd_Total2 = 0, dd_Total3 = 0, dd_Total4 = 0, dd_TotalPrice = 0, dd_TotalHandPrice = 0, dd_TotalTotal = 0;
        decimal ddd_Total = 0, ddd_Total1 = 0, ddd_Total2 = 0;

        int i_Row = 1;
        int i_FPNum = 1;


        if (Model.COC_Type == "0")//遥控器对账
        {
            s_Return += " <tr ><td class=\"ListHeadLeft\" align=left colspan=\"11\"><b>加工费发票1</b></td>\n</tr>";
            s_Return += " <tr ><td class=\"ListHeadDetials\" align=left colspan=\"11\"><b><font color=red>发票号码：</font></b>___________________</td></tr>";
            s_Return += " <tr ><td class=\"ListHead\" >项次</td>\n";
            s_Return += "<td class=\"ListHead\" align=center>料号</td>\n";
            s_Return += "<td class=\"ListHead\" align=center>货物名称</td>\n";
            s_Return += "<td class=\"ListHead\" align=center>规格型号</td>\n";
            s_Return += "<td class=\"ListHead\" align=center>单位</td>\n";
            s_Return += "<td class=\"ListHead\">数量</td>\n";
            s_Return += "<td class=\"ListHead\">单价</td>\n";
            s_Return += "<td class=\"ListHead\">金额</td>\n";
            s_Return += "<td class=\"ListHead\">税率</td>\n";
            s_Return += "<td class=\"ListHead\"  colspan=2>税额</td>\n</tr >";
        }
        else
        {

            s_Return += " <tr ><td class=\"ListHeadLeft\" align=left colspan=\"11\"><b>原材料发票1</b></td>\n</tr>";
            s_Return += " <tr ><td class=\"ListHead\" >项次</td>\n";
            s_Return += "<td class=\"ListHead\" align=center>料号</td>\n";
            s_Return += "<td class=\"ListHead\" align=center>货物名称</td>\n";
            s_Return += "<td class=\"ListHead\" align=center>规格型号</td>\n";
            s_Return += "<td class=\"ListHead\" align=center>单位</td>\n";
            s_Return += "<td class=\"ListHead\">数量</td>\n";
            s_Return += "<td class=\"ListHead\">单价</td>\n";
            s_Return += "<td class=\"ListHead\">金额</td>\n";
            s_Return += "<td class=\"ListHead\">税率</td>\n";
            s_Return += "<td class=\"ListHead\"  colspan=2>税额</td>\n</tr >";
        }
        if (Dts_Table.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
            {
                decimal d_Price = decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_Price"].ToString() == "" ? "0" : Dts_Table.Tables[0].Rows[i]["COD_Price"].ToString());
                decimal d_HandPrice = decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_HandPrice"].ToString() == "" ? "0" : Dts_Table.Tables[0].Rows[i]["COD_HandPrice"].ToString());
                decimal d_Number = decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_DzNumber"].ToString() == "" ? "0" : Dts_Table.Tables[0].Rows[i]["COD_DzNumber"].ToString());
                decimal d_BNumber = decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_BNumber"].ToString() == "" ? "0" : Dts_Table.Tables[0].Rows[i]["COD_BNumber"].ToString());
                if (Model.COC_Type == "0")//遥控器对账
                {
                    KNet.BLL.KNet_WareHouse_DirectOutList_Details Bll_DirectOutDetails = new KNet.BLL.KNet_WareHouse_DirectOutList_Details();
                    KNet.Model.KNet_WareHouse_DirectOutList_Details Model_DirectOutDetails = Bll_DirectOutDetails.GetModel(Dts_Table.Tables[0].Rows[i]["COD_DirectOutID"].ToString());
                    if (Model_DirectOutDetails != null)
                    {
                        KNet.BLL.KNet_WareHouse_DirectOutList Bll_DirectOut = new KNet.BLL.KNet_WareHouse_DirectOutList();
                        KNet.Model.KNet_WareHouse_DirectOutList Model_DirectOut = Bll_DirectOut.GetModelB(Model_DirectOutDetails.DirectOutNo);
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
                    }
                }
                string s_CustomerValue = base.Base_GetHouseName(Dts_Table.Tables[0].Rows[i]["COD_CustomerValue"].ToString());
                if (s_CustomerValue == "")
                {
                    s_CustomerValue = base.Base_GetCustomerName_Link(Dts_Table.Tables[0].Rows[i]["COD_CustomerValue"].ToString());
                }
                try
                {
                    d_Total += decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_CkNumber"].ToString());
                    d_Total1 += decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_DzNumber"].ToString());
                    d_Total2 += decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_BNumber"].ToString());
                    d_Total3 += decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_Money"].ToString());
                    d_TotalPrice += (d_Number + d_BNumber) * d_Price;
                    d_TotalHandPrice += (d_Number + d_BNumber) * d_HandPrice;

                    dd_Total += decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_CkNumber"].ToString());
                    if (Model.COC_Type == "0")
                    {
                        dd_Total1 += (d_Number + d_BNumber);
                    }
                    else
                    {
                        dd_Total1 += d_Number;
                    }
                    dd_Total2 += decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_BNumber"].ToString());
                    dd_Total3 += decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_Money"].ToString());
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
                    d_TaxPrice = decimal.Parse(base.FormatNumber1(Convert.ToString(d_HandPrice / decimal.Parse("1.17")), 10));
                    d_FPMoney = decimal.Parse(base.FormatNumber1(Convert.ToString(d_TaxPrice * dd_Total1), 2));
                    d_TaxMoney = dd_TotalHandPrice - d_FPMoney;
                }
                else
                {
                    d_NowMoney = dd_Total3;
                    d_NowPrice = d_Price;
                    d_TaxPrice = decimal.Parse(base.FormatNumber1(Convert.ToString(d_Price / decimal.Parse("1.17")), 10));
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

                        //发票信息
                        s_Return += "<tr >";
                        s_Return += "<td class=\"ListHeadDetails\" align=\"left\" >" + i_Row.ToString() + "</td>";
                        s_Return += "<td class='ListHeadDetails'align=center >" + base.Base_GetProductsCode(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>\n";

                        if (Model.COC_Type == "0")//遥控器对账
                        {
                            s_Return += "<td class=\"ListHeadDetails\" align=\"left\"> 遥控器加工费</td>";
                        }
                        else
                        {
                            s_Return += "<td class=\"ListHeadDetails\" align=\"left\">" + base.Base_GetProdutsName(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";
                        }

                        s_Return += "<td class=\"ListHeadDetails\" align=\"left\">" + base.Base_GetProductsEdition(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";
                        s_Return += "<td class=\"ListHeadDetails\" align=\"left\">" + base.Base_GetUnitsName(base.Base_GetProductsUnits(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString())) + "</td>";

                        s_Return += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber1(dd_Total1.ToString(), 0) + "</td>";
                        s_Return += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber(d_NowPrice.ToString(), 3) + "</td>";
                        s_Return += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber1(d_NowMoney.ToString(), 2) + "</td>";
                        s_Return += "<td class=\"ListHeadDetails\" align=\"center\">17%</td>";
                        s_Return += "<td class=\"ListHeadDetails\" align=\"right\"  colspan=2>" + FormatNumber1(d_TaxMoney.ToString(), 2) + "</td>";
                        s_Return += "</tr>";
                        ddd_Total += dd_Total1;
                        ddd_Total1 += d_NowMoney;
                        ddd_Total2 += d_TaxMoney;
                        dd_Total = 0;
                        dd_Total1 = 0;
                        dd_Total2 = 0;
                        dd_Total3 = 0;
                        dd_Total4 = 0;
                        dd_TotalPrice = 0;
                        dd_TotalHandPrice = 0;

                        if ((i_Row % i_MaxRow == 0) || (ddd_Total1 % d_MaxMoney == 0))
                        {
                            i_FPNum = i_FPNum + 1;
                            if (Model.COC_Type == "0")//遥控器对账
                            {

                                s_Return += " <tr >\n";
                                s_Return += "<td class='ListHeadDetails'align=center  colspan='5'>合计:</td>\n";
                                s_Return += "<td class='ListHeadDetails' align=right  >&nbsp;" + base.FormatNumber1(ddd_Total.ToString(), 0) + "</td>\n";
                                s_Return += "<td class='ListHeadDetails' align=right >&nbsp;</td>\n";//money
                                s_Return += "<td class='ListHeadDetails' align=right  >&nbsp;" + base.FormatNumber1(ddd_Total1.ToString(), 2) + "</td>\n";
                                s_Return += "<td class='ListHeadDetails' align=right >&nbsp;</td>\n";//money
                                s_Return += "<td class='ListHeadDetails' align=right  colspan=2>&nbsp;" + base.FormatNumber1(ddd_Total2.ToString(), 2) + "</td>\n";
                                ddd_Total = 0;
                                ddd_Total1 = 0;
                                ddd_Total2 = 0;
                                s_Return += " </tr>";
                                s_Return += " <tr ><td class=\"ListHeadLeft\" align=left colspan=\"11\"><b>加工费发票" + i_FPNum + "</b></td>\n</tr>";
                                s_Return += " <tr ><td class=\"ListHead\" >项次</td>\n";
                                s_Return += "<td class=\"ListHead\" align=center>料号</td>\n";
                                s_Return += "<td class=\"ListHead\" align=center>货物名称</td>\n";
                                s_Return += "<td class=\"ListHead\" align=center>规格型号</td>\n";
                                s_Return += "<td class=\"ListHead\" align=center>单位</td>\n";
                                s_Return += "<td class=\"ListHead\">数量</td>\n";
                                s_Return += "<td class=\"ListHead\">单价</td>\n";
                                s_Return += "<td class=\"ListHead\">金额</td>\n";
                                s_Return += "<td class=\"ListHead\">税率</td>\n";
                                s_Return += "<td class=\"ListHead\"  colspan=2>税额</td>\n</tr >";
                            }
                            else
                            {

                                s_Return += " <tr >\n";
                                s_Return += "<td class='ListHeadDetails'align=center  colspan='5'>合计:</td>\n";
                                s_Return += "<td class='ListHeadDetails' align=right  >&nbsp;" + base.FormatNumber1(ddd_Total.ToString(), 0) + "</td>\n";
                                s_Return += "<td class='ListHeadDetails' align=right >&nbsp;</td>\n";//money
                                s_Return += "<td class='ListHeadDetails' align=right  >&nbsp;" + base.FormatNumber1(ddd_Total1.ToString(), 2) + "</td>\n";
                                s_Return += "<td class='ListHeadDetails' align=right >&nbsp;</td>\n";//money
                                s_Return += "<td class='ListHeadDetails' align=right  colspan=2>&nbsp;" + base.FormatNumber1(ddd_Total2.ToString(), 2) + "</td>\n";
                                s_Return += " </tr>";
                                ddd_Total = 0;
                                ddd_Total1 = 0;
                                ddd_Total2 = 0;
                                s_Return += " <tr ><td class=\"ListHeadLeft\" align=left colspan=\"11\"><b>原材料发票" + i_FPNum + "</b></td>\n</tr>";
                                s_Return += " <tr ><td class=\"ListHead\" >项次</td>\n";
                                s_Return += "<td class=\"ListHead\" align=center>料号</td>\n";
                                s_Return += "<td class=\"ListHead\" align=center>货物名称</td>\n";
                                s_Return += "<td class=\"ListHead\" align=center>规格型号</td>\n";
                                s_Return += "<td class=\"ListHead\" align=center>单位</td>\n";
                                s_Return += "<td class=\"ListHead\">数量</td>\n";
                                s_Return += "<td class=\"ListHead\">单价</td>\n";
                                s_Return += "<td class=\"ListHead\">金额</td>\n";
                                s_Return += "<td class=\"ListHead\">税率</td>\n";
                                s_Return += "<td class=\"ListHead\"  colspan=2>税额</td>\n</tr >";
                            }
                        }
                        i_Row++;
                    }
                }
                else if (i == Dts_Table.Tables[0].Rows.Count - 1)
                {


                    //发票信息
                    s_Return += "<tr >";
                    s_Return += "<td class=\"ListHeadDetails\" align=\"left\" >" + i_Row.ToString() + "</td>";
                    s_Return += "<td class='ListHeadDetails'align=center >" + base.Base_GetProductsCode(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>\n";
                    if (Model.COC_Type == "0")//遥控器对账
                    {
                        s_Return += "<td class=\"ListHeadDetails\" align=\"left\"> 遥控器加工费</td>";
                    }
                    else
                    {
                        s_Return += "<td class=\"ListHeadDetails\" align=\"left\">" + base.Base_GetProdutsName(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";
                    }

                    s_Return += "<td class=\"ListHeadDetails\" align=\"left\">" + base.Base_GetProductsEdition(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";
                    s_Return += "<td class=\"ListHeadDetails\" align=\"left\">" + base.Base_GetUnitsName(base.Base_GetProductsUnits(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString())) + "</td>";

                    s_Return += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber1(dd_Total1.ToString(), 0) + "</td>";

                    s_Return += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber(d_NowPrice.ToString(), 3) + "</td>";
                    s_Return += "<td class=\"ListHeadDetails\" align=\"right\">" + FormatNumber1(d_NowMoney.ToString(), 2) + "</td>";

                    s_Return += "<td class=\"ListHeadDetails\" align=\"center\">17%</td>";
                    s_Return += "<td class=\"ListHeadDetails\" align=\"right\"  colspan=2>" + FormatNumber1(d_TaxMoney.ToString(), 2) + "</td>";

                    s_Return += "</tr>";

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

            s_Return += " <tr >\n";
            s_Return += "<td class='ListHeadDetails'align=center  colspan='5'>合计:</td>\n";
            s_Return += "<td class='ListHeadDetails' align=right  >&nbsp;" + base.FormatNumber1(ddd_Total.ToString(), 0) + "</td>\n";
            s_Return += "<td class='ListHeadDetails' align=right >&nbsp;</td>\n";//money
            s_Return += "<td class='ListHeadDetails' align=right  >&nbsp;" + base.FormatNumber1(ddd_Total1.ToString(), 2) + "</td>\n";
            s_Return += "<td class='ListHeadDetails' align=right >&nbsp;</td>\n";//money
            s_Return += "<td class='ListHeadDetails' align=right  colspan=2>&nbsp;" + base.FormatNumber1(ddd_Total2.ToString(), 2) + "</td>\n";
            s_Return += " </tr>";
            if ((d_FPNumber != 0) && (Model.COC_Type == "0"))
            {
                decimal d_TotalFPNumber = 0, d_TotalFPNet = 0, d_TotalFPPrice = 0, d_TotalTaxPrice = 0;
                string s_Sql = "Select *  from KNet_Sys_Products where ProductsType='M150920074726199' order by ProductsName";
                this.BeginQuery(s_Sql);
                this.QueryForDataTable();
                DataTable Dtb_Table = this.Dtb_Result;
                s_Return += " <tr ><td class=\"ListHeadLeft\" align=left colspan=\"11\"><b>材料费发票1</b></td>\n</tr>";
                s_Return += " <tr ><td class=\"ListHeadDetials\" align=left colspan=\"11\"><b><font color=red>发票号码：</font></b>___________________</td></tr>";
                s_Return += " <tr ><td class=\"ListHead\" >项次</td>\n";
                s_Return += "<td class=\"ListHead\" align=center>料号</td>\n";
                s_Return += "<td class=\"ListHead\" align=center>品名</td>\n";
                s_Return += "<td class=\"ListHead\" align=center>规格</td>\n";
                s_Return += "<td class=\"ListHead\" align=center>单位</td>\n";
                s_Return += "<td class=\"ListHead\">标准用量</td>\n";
                s_Return += "<td class=\"ListHead\">出库数量</td>\n";
                s_Return += "<td class=\"ListHead\">单价</td>\n";
                s_Return += "<td class=\"ListHead\">金额</td>\n";
                s_Return += "<td class=\"ListHead\">税率</td>\n";
                s_Return += "<td class=\"ListHead\">税额</td>\n</tr >";
                if (Dtb_Table.Rows.Count > 0)
                {
                    for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                    {
                        s_Return += " <tr >\n";
                        s_Return += "<td class='ListHeadDetails'align=center >" + (i + 1).ToString() + "</td>\n";
                        s_Return += "<td class='ListHeadDetails'align=center >" + base.Base_GetProductsCode(Dtb_Table.Rows[i]["ProductsBarCode"].ToString()) + "</td>\n";
                        s_Return += "<td class='ListHeadDetails'align=center >" + base.Base_GetProdutsName(Dtb_Table.Rows[i]["ProductsBarCode"].ToString()) + "</td>\n";
                        s_Return += "<td  class='ListHeadDetails'align=center >" + base.Base_GetProductsEdition(Dtb_Table.Rows[i]["ProductsBarCode"].ToString()) + "</td>\n";
                        s_Return += "<td class='ListHeadDetails' align=center >" + base.Base_GetUnitsName(base.Base_GetProductsUnits(Dtb_Table.Rows[i]["ProductsBarCode"].ToString())) + "</td>\n";
                        decimal d_Num = 1;
                        if (Dtb_Table.Rows[i]["ProductsBarCode"].ToString() == "D1304021636173814")//如果是电阻
                        {
                            s_Return += "<td  class='ListHeadDetails' align=right  >5</td>\n";
                            d_Num = 5;
                        }
                        else
                        {
                            s_Return += "<td  class='ListHeadDetails' align=right  >1</td>\n";
                            d_Num = 1;
                        }
                        decimal d_Number1 = 0;
                        d_Number1 = d_FPNumber * d_Num;
                        s_Return += "<td  class='ListHeadDetails' align=right  >&nbsp;" + base.FormatNumber1(d_Number1.ToString(), 0) + "</td>\n";
                        decimal d_ProductsCostPrice = decimal.Parse(Dtb_Table.Rows[i]["ProductsCostPrice"].ToString());

                        s_Return += "<td  class='ListHeadDetails' align=right  >&nbsp;" + base.FormatNumber1(d_ProductsCostPrice.ToString(), 2) + "</td>\n";
                        decimal d_TotalMoney = d_Number1 * d_ProductsCostPrice;
                        s_Return += "<td  class='ListHeadDetails' align=right  >&nbsp;" + base.FormatNumber1(d_TotalMoney.ToString(), 2) + "</td>\n";
                        s_Return += "<td  class='ListHeadDetails' align=right >&nbsp;17%</td>\n";

                        decimal d_TaxPrice = decimal.Parse(base.FormatNumber1(Convert.ToString(d_ProductsCostPrice / decimal.Parse("1.17")), 10));
                        decimal d_FPMoney = decimal.Parse(base.FormatNumber1(Convert.ToString(d_TaxPrice * d_Number1), 2));
                        decimal d_TaxMoney = d_TotalMoney - d_FPMoney;

                        s_Return += "<td  class='ListHeadDetails' align=right >" + base.FormatNumber1(d_TaxMoney.ToString(), 2) + "</td>\n";
                        s_Return += " </tr>";
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
                    s_Return += " <tr >\n";
                    s_Return += "<td class='ListHeadDetails'align=center  colspan='6'>合计:</td>\n";
                    s_Return += "<td class='ListHeadDetails' align=right  >&nbsp;" + base.FormatNumber1(d_TotalFPNumber.ToString(), 0) + "</td>\n";
                    s_Return += "<td class='ListHeadDetails' align=right >&nbsp;" + base.FormatNumber1(d_TotalFPPrice.ToString(), 2) + "</td>\n";//money
                    s_Return += "<td class='ListHeadDetails' align=right  >&nbsp;" + base.FormatNumber1(d_TotalFPNet.ToString(), 2) + "</td>\n";
                    s_Return += "<td class='ListHeadDetails' align=right >&nbsp;</td>\n";//money
                    s_Return += "<td class='ListHeadDetails' align=right  >&nbsp;" + base.FormatNumber1(d_TotalTaxPrice.ToString(), 2) + "</td>\n";
                    s_Return += " </tr>";
                }
            }

        }
        //先查供应商单张开票金额，单张最多行数。
        return s_Return;

    }
}
