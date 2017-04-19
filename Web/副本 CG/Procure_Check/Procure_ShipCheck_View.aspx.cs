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

public partial class Web_Sales_Xs_ShipWareOut_View : BasePage
{
    public string s_Time = "";
    public string s_HouseName = "";
    public string s_Details = "";
    public string s_ExcelName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string s_ID = Request.QueryString["ID"]==null?"":Request.QueryString["ID"].ToString();
            KNet.BLL.Cg_Order_Checklist Bll = new KNet.BLL.Cg_Order_Checklist();
            KNet.Model.Cg_Order_Checklist Model = Bll.GetModel(s_ID);
            if (Model.COC_Type == "0")//成品采购
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
            }
            else//原材料对账单
            {
                string s_Sql = "Select b.COD_ProductsBarCode,a.COC_SuppNo,d.WareHouseDateTime,b.COD_Dznumber,b.COD_wuliu,b.COd_Price, ";
                s_Sql += "b.COD_Money,b.COD_CustomerValue,a.COC_Details,a.COC_Stime,e.OrderNo,b.COD_BNumber from Cg_Order_Checklist a join Cg_Order_Checklist_Details b on a.COC_Code=b.COD_CheckNo join Knet_Procure_WareHouseList_Details c on c.ID=b.COD_DirectOutID join Knet_Procure_WareHouseList d on d.WareHouseNo=c.WareHouseNo left join Knet_Procure_OrdersList e on  e.OrderNO=d.OrderNo Where 1=1 and a.COC_Code='" + s_ID + "' Order by d.WareHouseDateTime";
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
                            s_Details += "<td align=left class='ListHeadDetails' noWrap>" + Dtb_Table.Rows[i][10].ToString()+ "</td>\n";
                        }
                        catch { s_Details += "<td align=left class='ListHeadDetails' noWrap>&nbsp;</td>\n"; }
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
            }
        }
    }
    private string GetBattery(string s_DirectOutNoDetailsID,string s_Type)
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
}
