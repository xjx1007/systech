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

            string s_Sql = "select Month(KWD_CwOutTime) as 月份,cast(Sum(DirectOutAmount)/10000.00  as decimal(18,2)) as 数量,";
            s_Sql += "cast (Sum(KWD_SalesTotalNet) /10000  as decimal(18,2)) as 金额 ";
            s_Sql += " From KNET_WareHouse_DirectOutList a  join KNET_Sales_ClientList f on a.KWD_Custmoer=f.CustomerValue  ";
            s_Sql += " join KNet_WareHouse_DirectOutList_Details b on a.DirectOutNo=b.DirectOutNo ";
            s_Sql += "join KNet_Sys_WareHouse c on c.HouseNo=a.HouseNo join KNet_Sys_Products d on d.ProductsBarCode=b.ProductsBarCode ";
            s_Sql += "join KNet_Sales_OutWarelist e on a.KWD_ShipNo=e.OutWareNo and  b.DirectOutAmount<>0 ";
            s_Sql += " Where 1=1  and Kwd_Type in('101','DB') and KWD_ShipNo<>'' and isnull(KSO_Type,0)<>'2' and ( isnull(KSO_Type,0)<>'1'";
            s_Sql += " or ( Kwd_Type='DB' and isnull(KSO_Type,0)='1' ) )  and isnull(KWD_SalesUnitPrice,0)<>0 and d.KSP_Code like '01%' ";
    
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
                Chartlet1.Width = 1000;
                Chartlet1.YLabels.UnitText = "销售额(万元),销售量(万只)";
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
                Chartlet1.Trend = new FanG.TrendAttributes(s_StartDate, s_EndDate, FanG.Chartlet.TimeSpanTypes.Month, "yyyy-MM");
                //图表标题
                Chartlet1.ChartTitle.Text = DateTime.Parse(s_StartDate).Year + "年销售数量及金额趋势图";
                //绑定数据
                Chartlet1.BindChartData(Dts_Table);
                string s_Detail = "";
                s_Detail = "<table border=\"1\" cellspacing=\"0\" cellpadding=\"0\" width=\"80%\" class=\"ListDetails\">\n  \n";
                s_Detail += "<tr><td class=\"ListHead\">月份</td>";
                s_Detail += "<td class=\"ListHead\">销售数量</td>";
                s_Detail += "<td class=\"ListHead\">销售额</td>";
                s_Detail += "<td class=\"ListHead\">总数量</td>";
                s_Detail += "<td class=\"ListHead\">总金额</td>";
                s_Detail += "</tr>";
                decimal d_TotalNum = 0, d_TotalNet = 0;
                for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                {
                    s_Detail += "<tr><td class=\"ListHeadDetails\">" + Dts_Table.Tables[0].Rows[i][0].ToString() + "月</td>";
                    s_Detail += "<td class=\"ListHeadDetails\">" + Dts_Table.Tables[0].Rows[i][1].ToString() + "</td>";
                    s_Detail += "<td class=\"ListHeadDetails\">" + Dts_Table.Tables[0].Rows[i][2].ToString() + "</td>";
                    d_TotalNum += decimal.Parse(Dts_Table.Tables[0].Rows[i][1].ToString());
                    d_TotalNet += decimal.Parse(Dts_Table.Tables[0].Rows[i][2].ToString());
                    s_Detail += "<td class=\"ListHeadDetails\">" + d_TotalNum.ToString() + "</td>";
                    s_Detail += "<td class=\"ListHeadDetails\">" + d_TotalNet.ToString() + "</td>";
                    s_Detail += "</tr>";
                }
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
