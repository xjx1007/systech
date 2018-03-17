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
using System.Data.SqlClient;

using KNet.DBUtility;
using KNet.Common;

public partial class Web_Report_Xs_List_OrderList : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();

            string s_Sql = "select  Month(KWD_CwOutTime) as 月份,";
            if (s_Type == "1")
            {
                s_Sql += " cast(Sum(case when f.CustomerValue in ('100031') then DirectOutAmount else 0 end)/10000.0  as decimal(18,2)) as 九联,";
                s_Sql += " cast(Sum(case when f.CustomerValue in ('100031','103601') then DirectOutAmount else 0 end)/10000.0  as decimal(18,2)) as 海信,";
                s_Sql += " cast(Sum(case when f.CustomerValue in ('100841','103601','100031') then DirectOutAmount else 0 end)/10000.0 as decimal(18,2)) as 创维,";
                s_Sql += " cast(Sum(case when f.CustomerValue in ('100841','103601','100031','101141') then DirectOutAmount else 0 end)/10000.0  as decimal(18,2)) as 银河,";
                s_Sql += " cast(Sum(case when f.CustomerValue in ('100841','103601','100031','101141','100251') then DirectOutAmount else 0 end)/10000.0  as decimal(18,2)) as 新大陆 ";
            }
            else
            {
                s_Sql += " cast (isnull(Sum(case when f.CustomerValue in ('100031') then KWD_SalesTotalNet end),0) /10000  as decimal(18,2)) as 九联, ";
                s_Sql += " cast (isnull(Sum(case when f.CustomerValue in ('100031','103601') then KWD_SalesTotalNet end),0) /10000  as decimal(18,2)) as 海信, ";
                s_Sql += " cast (isnull(Sum(case when f.CustomerValue in ('100841','103601','100031') then KWD_SalesTotalNet end),0) /10000  as decimal(18,2)) as 创维, ";
                s_Sql += " cast (isnull(Sum(case when f.CustomerValue in ('100841','103601','100031','101141') then KWD_SalesTotalNet end),0) /10000  as decimal(18,2)) as 江苏银河, ";
                s_Sql += " cast (isnull(Sum(case when f.CustomerValue in ('100841','103601','100031','101141','100251') then KWD_SalesTotalNet end),0) /10000  as decimal(18,2)) as 福建新大陆 ";
            }

            s_Sql += " From KNET_WareHouse_DirectOutList a  join KNET_Sales_ClientList f on a.KWD_Custmoer=f.CustomerValue  ";
            s_Sql += " join KNet_WareHouse_DirectOutList_Details b on a.DirectOutNo=b.DirectOutNo ";
            s_Sql += "join KNet_Sys_WareHouse c on c.HouseNo=a.HouseNo join KNet_Sys_Products d on d.ProductsBarCode=b.ProductsBarCode ";
            s_Sql += "join KNet_Sales_OutWarelist e on a.KWD_ShipNo=e.OutWareNo and  b.DirectOutAmount<>0 ";
            s_Sql += " Where 1=1  and Kwd_Type in('101','DB') and KWD_ShipNo<>'' and isnull(KSO_Type,0)<>'2' and ( isnull(KSO_Type,0)<>'1'";
            s_Sql += " or ( Kwd_Type='DB' and isnull(KSO_Type,0)='1' ) )  and isnull(KWD_SalesUnitPrice,0)<>0 ";
            s_Sql += " and datediff(month,KWD_CwOutTime,GetDate())<12 ";
            /* s_Sql += " and f.CustomerValue in ( select top 10 f.CustomerValue From KNET_WareHouse_DirectOutList a  join KNET_Sales_ClientList f on a.KWD_Custmoer=f.CustomerValue ";
             s_Sql += "join KNet_WareHouse_DirectOutList_Details b on a.DirectOutNo=b.DirectOutNo ";
             s_Sql += "join KNet_Sys_WareHouse c on c.HouseNo=a.HouseNo join KNet_Sys_Products d on d.ProductsBarCode=b.ProductsBarCode ";
             s_Sql += "join KNet_Sales_OutWarelist e on a.KWD_ShipNo=e.OutWareNo and  b.DirectOutAmount<>0 ";
             s_Sql += " Where 1=1  and Kwd_Type in('101','DB') and KWD_ShipNo<>'' and isnull(KSO_Type,0)<>'2' and ( isnull(KSO_Type,0)<>'1'";
             s_Sql += " or ( Kwd_Type='DB' and isnull(KSO_Type,0)='1' ) )  and isnull(KWD_SalesUnitPrice,0)<>0  group by f.CustomerValue";
             s_Sql += " order by Sum(KWD_SalesTotalNet) desc) ";*/
            string s_StartDate = Request.QueryString["StartDate"] == null ? "" : Request.QueryString["StartDate"].ToString();
            string s_EndDate = Request.QueryString["EndDate"] == null ? "" : Request.QueryString["EndDate"].ToString();
            string s_CustomerName = Request.QueryString["CustomerName"] == null ? "" : Request.QueryString["CustomerName"].ToString();
            string s_ProductsType = Request.QueryString["ProductsType"] == null ? "" : Request.QueryString["ProductsType"].ToString();
            string s_CustomerTypes = Request.QueryString["CustomerTypes"] == null ? "" : Request.QueryString["CustomerTypes"].ToString();
            string s_CustomerClass = Request.QueryString["CustomerClass"] == null ? "" : Request.QueryString["CustomerClass"].ToString();

            if (s_StartDate != "")
            {
                s_Sql += " and KWD_CwOutTime>='" + s_StartDate + "'";
            }
            if (s_EndDate != "")
            {
                s_Sql += " and KWD_CwOutTime<='" + s_EndDate + "'";
            }
            if (s_CustomerName != "")
            {
                s_Sql += " and CustomerName like '%" + s_CustomerName + "%'";
            }
            if (s_ProductsType != "")
            {
                s_Sql += " and ProductsEdition like '%" + s_ProductsType + "%'";
            }
            if (s_CustomerTypes != "")
            {
                s_Sql += " and CustomerValue in (select CustomerValue from KNet_Sales_ClientList where CustomerTypes='" + s_CustomerTypes + "' ) ";
            }
            if (s_CustomerClass != "")
            {
                s_Sql += " and CustomerValue in (select CustomerValue from KNet_Sales_ClientList where CustomerClass='" + s_CustomerClass + "' ) ";
            }
            s_Sql += "Group by Year(KWD_CwOutTime),Month(KWD_CwOutTime) order by Year(KWD_CwOutTime),Month(KWD_CwOutTime)";

            this.BeginQuery(s_Sql);
            this.QueryForDataSet();
            DataSet Dts_Table = this.Dts_Result;
            /*选择外观基调*/
            if (Dts_Table.Tables[0].Rows.Count > 0)
            {
                Chartlet1.Width = 1200;
                Chartlet1.Height = 700;
                if (s_Type == "1")
                {
                    Chartlet1.YLabels.UnitText = "销售量(万只)";
                }
                else
                {
                    Chartlet1.YLabels.UnitText = "销售额(万元)";
                }
                Chartlet1.AppearanceStyle = FanG.Chartlet.AppearanceStyles.Line_2D_Aurora_ThinSquare_Glow_NoBorder;
                //调整折线连接点的大小
                Chartlet1.LineConnectionRadius = 6;
                //调整折线宽度
                Chartlet1.Stroke.Width = 2;
                //关闭投影效果
                Chartlet1.Shadow.Enable = false;
                //通过下面一句调整标题的高度
                Chartlet1.ChartTitle.OffsetY = -10;
                //下面一句是TrendChart必须要有的，是TrendChart中最重要的设置(StartTime,EndTime,TimeSpanType,XLabelDisplayFormat)
                //如果你使用TrendChart，但是缺少了这一句，那么系统会提示：Please Set Chartlet.Trend attribute for Trend Chart
                //详细介绍请参看Chartlet.Trend的参考手册
                //   Chartlet1.Trend = new FanG.TrendAttributes(s_StartDate, s_EndDate, FanG.Chartlet.TimeSpanTypes.Month, "yyyy-MM");
                //图表标题

                if (s_Type == "1")
                {

                    Chartlet1.ChartTitle.Text = "重点机顶盒厂销售数量趋势图";
                }
                else
                {
                    Chartlet1.ChartTitle.Text = "重点机顶盒厂销售金额趋势图";
                }
                //绑定数据
                Chartlet1.BindChartData(Dts_Table);
                string s_Detail = "";
                s_Detail = "<table border=\"1\" cellspacing=\"0\" cellpadding=\"0\" width=\"80%\" class=\"ListDetails\">\n  \n";
                s_Detail += "<tr><td class=\"ListHead\">月份</td>";
                s_Detail += "<td class=\"ListHead\">九联</td>";
                s_Detail += "<td class=\"ListHead\">海信</td>";
                s_Detail += "<td class=\"ListHead\">创维</td>";
                s_Detail += "<td class=\"ListHead\">江苏银河</td>";
                s_Detail += "<td class=\"ListHead\">福建新大陆</td>";
                s_Detail += "<td class=\"ListHead\">合计</td>";
                s_Detail += "</tr>";
                decimal d_TotalNum = 0, d_TotalNet = 0;
                decimal[] d_TotalNums = new decimal[6];
                for (int i = 0; i < 6; i++)
                {
                    d_TotalNums[i] = 0;
                }
                for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                {
                    d_TotalNum = 0;
                    s_Detail += "<tr><td class=\"ListHeadDetails\">" + Dts_Table.Tables[0].Rows[i][0].ToString() + "月</td>";
                    s_Detail += "<td class=\"ListHeadDetails\">" + Dts_Table.Tables[0].Rows[i][1].ToString() + "</td>";
                    decimal d_LeftNumber = decimal.Parse(Dts_Table.Tables[0].Rows[i][2].ToString()) - decimal.Parse(Dts_Table.Tables[0].Rows[i][1].ToString());

                    s_Detail += "<td class=\"ListHeadDetails\">" + d_LeftNumber + "</td>";
                    decimal d_LeftNumber1 = decimal.Parse(Dts_Table.Tables[0].Rows[i][3].ToString()) - decimal.Parse(Dts_Table.Tables[0].Rows[i][2].ToString());

                    s_Detail += "<td class=\"ListHeadDetails\">" + d_LeftNumber1 + "</td>";
                    decimal d_LeftNumber2 = decimal.Parse(Dts_Table.Tables[0].Rows[i][4].ToString()) - decimal.Parse(Dts_Table.Tables[0].Rows[i][2].ToString());

                    s_Detail += "<td class=\"ListHeadDetails\">" + d_LeftNumber2 + "</td>";
                    decimal d_LeftNumber3 = decimal.Parse(Dts_Table.Tables[0].Rows[i][5].ToString()) - decimal.Parse(Dts_Table.Tables[0].Rows[i][4].ToString());

                    s_Detail += "<td class=\"ListHeadDetails\">" + d_LeftNumber3 + "</td>";
                    d_TotalNum +=  decimal.Parse(Dts_Table.Tables[0].Rows[i][5].ToString());
                    s_Detail += "<td class=\"ListHeadDetails\">" + d_TotalNum.ToString() + "</td>";
                    d_TotalNums[0] += decimal.Parse(Dts_Table.Tables[0].Rows[i][1].ToString());
                    d_TotalNums[1] += d_LeftNumber;
                    d_TotalNums[2] += d_LeftNumber1;
                    d_TotalNums[3] += d_LeftNumber2;
                    d_TotalNums[4] += d_LeftNumber3;
                    d_TotalNums[5] += d_TotalNum;

                    s_Detail += "</tr>";
                }
                s_Detail += "<tr><td class=\"ListHeadDetails\">合计</td>";
                s_Detail += "<td class=\"ListHeadDetails\">" + d_TotalNums[0] + "</td>";
                s_Detail += "<td class=\"ListHeadDetails\">" + d_TotalNums[1] + "</td>";
                s_Detail += "<td class=\"ListHeadDetails\">" + d_TotalNums[2] + "</td>";
                s_Detail += "<td class=\"ListHeadDetails\">" + d_TotalNums[3] + "</td>";
                s_Detail += "<td class=\"ListHeadDetails\">" + d_TotalNums[4] + "</td>";
                s_Detail += "<td class=\"ListHeadDetails\">" + d_TotalNums[5] + "</td>";
                s_Detail += "</tr>";
                s_Detail += "</table>";
                this.Lbl_Details.Text = s_Detail;
            }
        }
    }
    public string GetShipNumber(string s_CustomerValue, string s_ProductsBarCode, string s_CustomerName, string s_ProductsPattern)//出库数量
    {
        if ((s_CustomerValue == "") || (s_ProductsBarCode == ""))
        {
            this.BeginQuery("Select Isnull(Sum(Number),0) From V_Customer_ShipContractList where len(ContractClass)<4 and ContractCheckYN='1' and ProductsPattern='" + s_ProductsPattern + "' and CustomerName='" + s_CustomerName + "' ");
            this.QueryForDataTable();
            if (this.Dtb_Result.Rows.Count > 0)
            {
                return Dtb_Result.Rows[0][0].ToString();
            }
            else
            {
                return "-";
            }
        }
        else
        {

            this.BeginQuery("Select Isnull(Sum(Number),0) From V_Customer_ShipContractList where len(ContractClass)<4 and ContractCheckYN='1' and ProductsBarCode='" + s_ProductsBarCode + "' and CustomerValue='" + s_CustomerValue + "' ");
            this.QueryForDataTable();
            if (this.Dtb_Result.Rows.Count > 0)
            {
                return Dtb_Result.Rows[0][0].ToString();
            }
            else
            {
                return "-";
            }

        }
    }
    public string GetCkNumber(string s_ProductsBarCode)//库存数量
    {
        string s_Return = "";
        this.BeginQuery("Select Sum(DirectInAmount),HouseNo from v_Store where ProductsBarCode='" + s_ProductsBarCode + "' Group by  HouseNo");
        this.QueryForDataTable();

        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                s_Return += base.Base_GetHouseName(Dtb_Result.Rows[i][1].ToString()) + "（" + Dtb_Result.Rows[i][0].ToString() + "),";
            }
            s_Return = s_Return.Substring(0, s_Return.Length - 1);
        }
        else
        {
            s_Return = "-";
        }
        return s_Return;
    }
}
