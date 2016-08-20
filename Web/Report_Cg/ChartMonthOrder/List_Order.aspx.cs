using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Json;

using KNet.DBUtility;
using KNet.Common;
using System.Drawing;
using System.Net;


public partial class Web_Report_CG_List_Order : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string s_Year = Request.QueryString["Year"] == null ? "" : Request.QueryString["Year"].ToString();
            string s_SuppNoValue = Request.QueryString["SuppNoValue"] == null ? "" : Request.QueryString["SuppNoValue"].ToString();
            string s_OrderType = Request.QueryString["OrderType"] == null ? "" : Request.QueryString["OrderType"].ToString();
            string s_ProductsType = Request.QueryString["ProductsType"] == null ? "" : Request.QueryString["ProductsType"].ToString();

            string s_DutyPerson = Request.QueryString["DutyPerson"] == null ? "" : Request.QueryString["DutyPerson"].ToString();
            string s_ProductsEdition = Request.QueryString["ProductsEdition"] == null ? "" : Request.QueryString["ProductsEdition"].ToString();
            string s_Type = Request.QueryString["Type"] == null ? "0" : Request.QueryString["Type"].ToString();

            string s_Sql = "select Month(OrderDateTime) 月份,ReplaceSql ";
            string s_DoSql = " cast (Sum( case when Year(OrderDateTime)='" + s_Year + "'  then OrderTotalNet+isnull(HandTotal,0) else 0 end)/10000 as decimal(18,2)) as 金额";
            s_Sql += " from Knet_Procure_OrdersList a  join Knet_Procure_OrdersList_Details b on a.OrderNo=b.OrderNo join Knet_Procure_Suppliers c on c.SuppNo=a.Suppno join KNet_Sys_ProcureType d on d.ProcureTypeValue=a.OrderType join KNet_Sys_Products e on b.ProductsBarCode=e.ProductsBarCode ";
            //  string s_Sql = "Select b.ProductsBarCode,c.CustomerName,b.ProductsPattern as ProductsName,Sum(Case When a.ContractClass='129687502761283812' then b.ContractAmount else 0 end ) as Number,";
            //s_Sql += "Sum(Case When a.ContractClass='129687502761283812' then 0 else b.ContractAmount end ) as BackNumber,b.ProductsBarCode,a.CustomerValue";
            //s_Sql += " from KNet_Sales_ContractList a join KNet_Sales_ContractList_Details b on a.ContractNo=b.ContractNo join KNet_Sales_ClientList c on a.CustomerValue=c.CustomerValue  ";
            s_Sql += " where a.KPO_Del=0 ";

            if (s_SuppNoValue != "")
            {
                s_Sql += " and a.SuppNo = '" + s_SuppNoValue + "'";
            }
            if (s_OrderType != "")
            {
                s_Sql += " and a.OrderType='" + s_OrderType + "'";
            }
            if (s_ProductsEdition != "")
            {
                s_Sql += " and e.ProductsEdition like '%" + s_ProductsEdition + "%'";
            }
            if (s_DutyPerson != "")
            {
                s_Sql += " and a.OrderStaffNo ='" + s_DutyPerson + "'";
            }
            if (s_ProductsType != "")
            {
                KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
                string s_SonID = Bll_ProductsDetails.GetSonIDs(s_ProductsType);
                s_SonID = s_SonID.Replace(",", "','");
                s_Sql += " and e.ProductsType in ('" + s_SonID + "') ";
            }
            s_Sql += " and a.suppNO in(Select distinct suppNo from Knet_Procure_OrdersList where Year(OrderDateTime)='" + s_Year + "')";
            s_Sql += " Group by Month(OrderDateTime) order by Month(OrderDateTime)";
            string s_Sql1 = s_Sql.Replace("ReplaceSql", s_DoSql);
            this.BeginQuery(s_Sql1);
            DataSet Dts_Table = (DataSet)this.QueryForDataSet(); ;
            try
            {
                this.Lbl_SuppName.Text = base.Base_GetSupplierName_Link(s_SuppNoValue);
                this.Lbl_Year.Text = s_Year;
            }
            catch
            { }

            OrderOEM.Width = 600;
            OrderOEM.Height = 400;
            /*选择外观基调*/
            OrderOEM.XLabels.Font = new Font("宋体", 8);
            OrderOEM.YLabels.UnitText = "金额(万元)";
            OrderOEM.XLabels.RotateAngle = 0;
            OrderOEM.AppearanceStyle = FanG.Chartlet.AppearanceStyles.Bar_2D_Breeze_FlatCrystal_NoGlow_NoBorder;
            //关闭投影效果
            OrderOEM.Shadow.Enable = false;
            //下面一句是TrendChart必须要有的，是TrendChart中最重要的设置(StartTime,EndTime,TimeSpanType,XLabelDisplayFormat)
            //如果你使用TrendChart，但是缺少了这一句，那么系统会提示：Please Set Chartlet.Trend attribute for Trend Chart
            //详细介绍请参看Chartlet.Trend的参考手册
            //图表标题
            string s_SuppName = "";
            try
            {
                s_SuppName = base.Base_GetSupplierName(s_SuppNoValue);
            }
            catch
            { }
            OrderOEM.ChartTitle.Text = s_SuppName;
            //绑定数据
            try
            {
                OrderOEM.BindChartData(Dts_Table);
            }
            catch
            { }

            s_DoSql = " cast(Sum( case when Year(OrderDateTime)='" + s_Year + "'  then OrderAmount else 0 end)/1000.0 as decimal(18,2)) as 数量";
            s_Sql = s_Sql.Replace("ReplaceSql", s_DoSql);
            this.BeginQuery(s_Sql);
            DataSet Dts_Table1 = (DataSet)this.QueryForDataSet();

            /*选择外观基调*/
            Chartlet1.Width = 600;
            Chartlet1.Height = 400;
            Chartlet1.XLabels.Font = new Font("宋体", 8);
            Chartlet1.YLabels.UnitText = "千个";
            Chartlet1.XLabels.RotateAngle = 0;
            Chartlet1.AppearanceStyle = FanG.Chartlet.AppearanceStyles.Bar_2D_Breeze_FlatCrystal_NoGlow_NoBorder;
            //关闭投影效果
            Chartlet1.Shadow.Enable = false;
            //下面一句是TrendChart必须要有的，是TrendChart中最重要的设置(StartTime,EndTime,TimeSpanType,XLabelDisplayFormat)
            //如果你使用TrendChart，但是缺少了这一句，那么系统会提示：Please Set Chartlet.Trend attribute for Trend Chart
            //详细介绍请参看Chartlet.Trend的参考手册
            //图表标题
            try
            {
                s_SuppName = base.Base_GetSupplierName(s_SuppNoValue);
            }
            catch
            { }
            Chartlet1.ChartTitle.Text = s_SuppName;
            //绑定数据
            try
            {
                Chartlet1.BindChartData(Dts_Table1);
            }
            catch
            { }
        }
    }
}
