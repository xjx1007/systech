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

public partial class Web_Report_Xs_List_CkList : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string s_Sql = "Select a.DirectOutDateTime,a.HouseNo,b.ProductsName,b.ProductsPattern,b.ProductsBarCode,a.KWD_Custmoer,d.KSO_PlanOutWareDateTime,b.DirectOutAmount,a.KWD_ShipNo,a.DirectOutNo,a.KWD_CWOutTime,isnull(b.KWD_BNumber,0) KWD_BNumber,e.KSP_Code,KWD_AddRess,KSP_Weight";
            s_Sql += "  from KNet_WareHouse_DirectOutList a join KNet_WareHouse_DirectOutList_Details b on a.DirectOutNo=b.DirectOutNo join KNet_Sys_WareHouse c on c.HouseNo=a.HouseNo ";
            s_Sql += " join KNet_Sys_Products e on e.ProductsBarCode=b.ProductsBarCode join KNet_Sales_OutWareList d on a.KWD_ShipNo=d.OutWareNo  Where 1=1 and KWD_Type in('101','DB') and KWD_SystemChange='0'";
            string s_StartDate = Request.QueryString["StartDate"] == null ? "" : Request.QueryString["StartDate"].ToString();
            string s_EndDate = Request.QueryString["EndDate"] == null ? "" : Request.QueryString["EndDate"].ToString();
            string s_CustomerName = Request.QueryString["CustomerName"] == null ? "" : Request.QueryString["CustomerName"].ToString();
            string s_ProductsType = Request.QueryString["ProductsType"] == null ? "" : Request.QueryString["ProductsType"].ToString();
            string s_CustomerTypes = Request.QueryString["CustomerTypes"] == null ? "" : Request.QueryString["CustomerTypes"].ToString();
            string s_ProductsEidition = Request.QueryString["ProductsEidition"] == null ? "" : Request.QueryString["ProductsEidition"].ToString();

            string s_Ck = Request.QueryString["Ck"] == null ? "" : Request.QueryString["Ck"].ToString();
            string s_State = Request.QueryString["State"] == null ? "" : Request.QueryString["State"].ToString();
            string s_HqState = Request.QueryString["HqState"] == null ? "" : Request.QueryString["HqState"].ToString();
            string s_isFirst = Request.QueryString["isFirst"] == null ? "" : Request.QueryString["isFirst"].ToString();


            string s_Details = "", s_Style = "";
            string s_Head = "";
            Decimal DTotalNum = 0, DTotalNet = 0, d_Number = 0;

            if (s_StartDate != "")
            {
                s_Sql += " and a.DirectOutDateTime>='" + s_StartDate + "'";
            }
            if (s_EndDate != "")
            {
                s_Sql += " and a.DirectOutDateTime<='" + s_EndDate + "'";
            }
            if (s_ProductsType != "")
            {
                KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
                string s_SonID = Bll_ProductsDetails.GetSonIDs(s_ProductsType);
                s_SonID = s_SonID.Replace(",", "','");
                s_Sql += " and ProductsType in ('" + s_SonID + "') ";
            }
            if (s_State != "")
            {
                s_Sql += " and  a.DirectOutCheckYN='" + s_State + "' ";
            }
            if (s_CustomerName != "")
            {
                s_Sql += " and a.KWD_Custmoer in (select CustomerValue from KNet_Sales_ClientList where CustomerName like '%" + s_CustomerName + "%')";
            }
            if (s_HqState != "")
            {
                if (s_HqState == "0")
                {
                    s_Sql += " and a.DirectOutNo in (Select PBA_FID From PB_Basic_Attachment where PBA_Type='SalesOut' ) and cast(isnull(KWD_CWOutTime ,'1900-01-01') as dateTime)>'2014-11-30' and DirectOutTopic=''";

                }
                else
                {
                    s_Sql += " and a.DirectOutNo not in (Select PBA_FID From PB_Basic_Attachment where PBA_Type='SalesOut' ) and cast(isnull(KWD_CWOutTime ,'1900-01-01') as dateTime)>'2014-11-30' and DirectOutTopic=''";
                }
            }
            if (s_ProductsEidition != "")
            {
                s_Sql += " and e.ProductsEdition like '%" + s_ProductsEidition + "%'";
            }
            if (s_CustomerTypes != "")
            {
                s_Sql += " and a.KWD_Custmoer in (select CustomerValue from KNet_Sales_ClientList where CustomerTypes='" + s_CustomerTypes + "' ) ";
            }
            if (s_Ck != "")
            {
                s_Sql += " and c.HouseNo='" + s_Ck + "' ";
            }
            if (s_isFirst != "")
            {

                string s_Sql1 = "";
                if (s_StartDate != "")
                {
                    s_Sql1 += " KWD_CWOutTime<='" + s_StartDate + "'";
                }
                if (s_EndDate != "")
                {
                    s_Sql1 += " or KWD_CWOutTime>='" + s_EndDate + "'";
                }
                if (s_isFirst == "0")//是
                {
                    s_Sql += " and  b.ProductsBarCode not in (select ProductsBarCode from KNet_WareHouse_DirectOutList_Details a join KNet_WareHouse_DirectOutList b on a.DirectOutNo=b.DirectOutNo where  " + s_Sql1 + " ) ";
                }
                else
                {

                    s_Sql += " and  b.ProductsBarCode  in (select ProductsBarCode from KNet_WareHouse_DirectOutList_Details a join KNet_WareHouse_DirectOutList b on a.DirectOutNo=b.DirectOutNo where " + s_Sql1 + ") ";
                }
            }
            s_Sql += "Order by a.KWD_DirectOutNo";
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
                    s_Details += "<td align=left class='thstyleLeftDetails'  noWrap>" + (i + 1).ToString() + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + Dtb_Table.Rows[i][9].ToString() + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + base.Base_GetHouseName(Dtb_Table.Rows[i][1].ToString()) + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + DateTime.Parse(Dtb_Table.Rows[i][0].ToString()).ToShortDateString() + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + DateTime.Parse(Dtb_Table.Rows[i][10].ToString()).ToShortDateString() + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + Dtb_Table.Rows[i]["KSP_Code"].ToString() + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + base.Base_GetProductsPattern(Dtb_Table.Rows[i][4].ToString()) + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + base.Base_GetProductsEdition(Dtb_Table.Rows[i][4].ToString()) + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + base.Base_GetCustomerName(Dtb_Table.Rows[i][5].ToString()) + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + DateTime.Parse(Dtb_Table.Rows[i][6].ToString()).ToShortDateString() + "</td>\n";

                    s_Details += "<td align=right class='thstyleLeftDetails' noWrap>" + Dtb_Table.Rows[i][7].ToString() + "</td>\n";//数量
                    s_Details += "<td align=right class='thstyleLeftDetails' noWrap>" + Dtb_Table.Rows[i]["KWD_BNumber"].ToString() + "</td>\n";//数量

                    s_Details += "<td align=left class='thstyleLeftDetails'>" + GetShipDetails(Dtb_Table.Rows[i]["DirectOutNo"].ToString()) + "</td>\n";//单价
                    s_Details += "<td align=left class='thstyleLeftDetails'>" + GetShipDetailsDh(Dtb_Table.Rows[i]["DirectOutNo"].ToString()) + "</td>\n";//单价
                    string[] s_Barrey = GetBattery(Dtb_Table.Rows[i][4].ToString(), Dtb_Table.Rows[i][8].ToString()).Split(',');
                    if (s_Barrey.Length > 1)
                    {
                        s_Details += "<td align=right class='thstyleLeftDetails' noWrap>" + s_Barrey[0] + "</td>\n";//电池
                        s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + base.Base_GetProductsPattern(s_Barrey[1]) + "</td>\n";//数量
                    }
                    else
                    {
                        s_Details += "<td align=right class='thstyleLeftDetails' noWrap>&nbsp;</td>\n";//电池
                        s_Details += "<td align=right class='thstyleLeftDetails' noWrap>&nbsp;</td>\n";//数量
                    }
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + Dtb_Table.Rows[i]["KWD_AddRess"].ToString() + "</td>\n";//数量

                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + GetSign(Dtb_Table.Rows[i]["DirectOutNo"].ToString()) + "</td>\n";//数量

                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + Dtb_Table.Rows[i]["KSP_Weight"].ToString() + "</td>\n";//数量


                    s_Details += " </tr>";
                    DTotalNum += Decimal.Parse(Dtb_Table.Rows[i][7].ToString());
                    DTotalNet += Decimal.Parse(Dtb_Table.Rows[i]["KWD_BNumber"].ToString());
                    try
                    {
                        d_Number += decimal.Parse(s_Barrey[0]);
                    }
                    catch
                    { }
                }
            }

            s_Details += " <tr >\n";

            s_Details += "<td  width='1%' align=left class='thstyleLeftDetails' noWrap colspan=10>合计:" + (Dtb_Table.Rows.Count).ToString() + "</td>\n";
            s_Details += "<td align=right class='thstyleLeftDetails' width='1%' noWrap>" + DTotalNum.ToString() + "</td>\n";//数量
            s_Details += "<td align=right class='thstyleLeftDetails' width='1%'  noWrap>" + DTotalNet.ToString() + "</td>\n";//金额
            s_Details += "<td align=right class='thstyleLeftDetails' width='1%' noWrap>&nbsp;</td>\n";//单价
            s_Details += "<td align=right class='thstyleLeftDetails' width='1%'  noWrap>" + d_Number.ToString() + "</td>\n";//金额

            s_Details += "<td align=right class='thstyleLeftDetails' width='1%'  noWrap>&nbsp;</td>\n";//单价
            s_Details += "<td align=right class='thstyleLeftDetails' width='1%'  noWrap>&nbsp;</td>\n";//单价
            s_Details += " </tr>";
            s_Details += "</tbody></table></div>";

            AdminloginMess Am = new AdminloginMess();
            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\"> \n";
            s_Head += "<tr>\n<th  colspan=\"23\" align=\"center\" width=\"100%\" class=\"thsTitle\" noWrap><font width=\"100\" size=\"6\"><b>发货明细</b></font></th>\n</tr>";
            s_Head += "<tr>\n<th  align=\"left\" width=\"100%\" class=\"thsTitle\" colspan=\"13\">" + "日期:" + s_StartDate + " 到 " + s_EndDate + "</th><th  align=\"right\"  class=\"thsTitle\" colspan=\"10\">" + "制表人:" + Am.KNet_StaffName + "</th>\n</tr>";

            s_Head += "<tr>\n<th class=\"thstyle\">序号</th>\n";
            s_Head += "<th class=\"thstyle\">出库单号</th>\n";
            s_Head += "<th class=\"thstyle\">仓库</th>\n";
            s_Head += "<th class=\"thstyle\">发货日期</th>\n";
            s_Head += "<th class=\"thstyle\">账务日期</th>\n";
            s_Head += "<th class=\"thstyle\">编码</th>\n";
            s_Head += "<th class=\"thstyle\">产品型号</th>\n";
            s_Head += "<th class=\"thstyle\">产品版本</th>\n";
            s_Head += "<th class=\"thstyle\">收货单位</th>\n";
            s_Head += "<th class=\"thstyle\">预计到货日期</th>\n";
            s_Head += "<th class=\"thstyle\">发货数量</th>\n";
            s_Head += "<th class=\"thstyle\">备品</th>\n";
            s_Head += "<th class=\"thstyle\">物流</th>\n";
            s_Head += "<th class=\"thstyle\">单号</th>\n";
            s_Head += "<th class=\"thstyle\">电池数量</th>\n";
            s_Head += "<th class=\"thstyle\">电池</th>\n";
            s_Head += "<th class=\"thstyle\">地址</th>\n";
            s_Head += "<th class=\"thstyle\">回签单</th>\n";
            s_Head += "<th class=\"thstyle\">单重</th>\n";
            s_Head += "</tr>\n";
            s_Head += "</thead><tbody class=\"scrollContent\">";
            this.Lbl_Details.Text = s_Head + s_Details;
        }
    }

    private string GetShipDetails(string s_OutWare)
    {
        string s_Return = "";
        this.BeginQuery("Select * From KNet_Sales_OutWareList_FlowList where OutWareNo='" + s_OutWare + "' order by FollowDateTime");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                if (Dtb_Result.Rows[i]["KDCode"].ToString() != "")
                {
                    s_Return += Dtb_Result.Rows[i]["KDCodeName"].ToString() + "<br/>";
                }
                else
                {
                    s_Return += Dtb_Result.Rows[i]["FollowText"].ToString() + "<br/>";
                }
            }
        }
        else
        {
            s_Return = "&nbsp;";
        }
        return s_Return;
    }

    private string GetShipDetailsDh(string s_OutWare)
    {
        string s_Return = "";
        this.BeginQuery("Select * From KNet_Sales_OutWareList_FlowList where OutWareNo='" + s_OutWare + "' order by FollowDateTime");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                if (Dtb_Result.Rows[i]["KDCode"].ToString() != "")
                {
                    s_Return += Dtb_Result.Rows[i]["KDCode"].ToString();
                }
                else
                {
                }
            }
        }
        else
        {
            s_Return = "&nbsp;";
        }
        return s_Return;
    }


    private string GetBattery(string s_ProductsBarCode, string s_OutWareNo)
    {
        string s_Return = "";
        this.BeginQuery("Select * From Xs_Products_Prodocts a join KNet_Sys_Products b on a.XPP_ProductsBarCOde=b.ProductsBarCode where XPP_FaterBarCode='" + s_ProductsBarCode + "' and b.ProductsMainCategory='129790301274394159' ");//电池是否是配件
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {//如果是配件
                KNet.BLL.Sc_Expend_Manage_MaterDetails Bll_Mater = new KNet.BLL.Sc_Expend_Manage_MaterDetails();
                DataSet dts_Tb = Bll_Mater.GetList(" SED_Type='2' and SED_ProductsBarCode='" + Dtb_Result.Rows[i]["XPP_ProductsBarCOde"] + "'");
                if (dts_Tb.Tables[0].Rows.Count > 0)
                {
                    s_Return = dts_Tb.Tables[0].Rows[0]["SED_RKNumber"].ToString() + "," + dts_Tb.Tables[0].Rows[0]["SED_ProductsBarCode"].ToString();
                }
            }
        }
        if (s_Return == "")//如果不是配件
        {
            this.BeginQuery("Select * From KNet_WareHouse_DirectOutList_Details a join KNet_WareHouse_DirectOutList c on c.DirectOutNo=a.DirectOutNo join KNet_Sys_Products b on a.ProductsBarCode=b.ProductsBarCode where  b.ProductsMainCategory='129790301274394159' and c.KWD_ShipNo='" + s_OutWareNo + "' ");//电池是否是配件
            this.QueryForDataTable();

            if (this.Dtb_Result.Rows.Count > 0)
            {
                s_Return = Dtb_Result.Rows[0]["DirectOutAmount"].ToString() + "," + Dtb_Result.Rows[0]["ProductsBarCode"].ToString();
            }


        }
        return s_Return;
    }

    private string GetSign(string s_DirecOutNO)
    {
        string s_Return = "<font color=red>否</font>";
        string s_Sql = "";
        try
        {
            s_Sql = "Select * from PB_Basic_Attachment where PBA_Type='SalesOut' and  PBA_FID='" + s_DirecOutNO + "'";
            this.BeginQuery(s_Sql);
            DataTable Dtb_Table = (DataTable)this.QueryForDataTable();
            if (Dtb_Table.Rows.Count > 0)
            {

                s_Return = "<font color=blue>是</font>";
            }
        }
        catch
        { }
        return s_Return;
    }

}
