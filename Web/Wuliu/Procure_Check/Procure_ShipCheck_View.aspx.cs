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
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            KNet.BLL.Cg_Order_Checklist Bll = new KNet.BLL.Cg_Order_Checklist();
            KNet.Model.Cg_Order_Checklist Model = Bll.GetModel(s_ID);
            string s_Head = "";
            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n<table border=\"1\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<tdead class=\"fixedHeader\"> \n";
            s_Head += "<tr >\n<th  class=\"MaterTitle\" colspan=\"15\"><font size=\"6\"><b>士腾与供应商对账确认单</b></font></td></tr>\n<tr >\n<td colspan=\"15\"  class=\"MaterTitle\" align=\"center\">1.发货对账单</td></tr>\n";
            s_Head += "<tr >\n<td colspan=\"9\"  class=\"thstyleleft\" >" + s_HouseName + "</td><td colspan=\"6\" class=\"thstyleRight\">" + s_Time + "</td></tr>\n";
            s_Head += "<td class=\"thstyle\">序号</td>\n";
            s_Head += "<td class=\"thstyle\" align=center  >出库单号</td>\n";
            s_Head += "<td class=\"thstyle\" align=center  >供应商</td>\n";
            s_Head += "<td class=\"thstyle\">发货日期</td>\n";
            s_Head += "<td class=\"thstyle\"> 产品版本</td>\n";
            s_Head += "<td class=\"thstyle\" >客户</td>\n";
            s_Head += "<td class=\"thstyle\" >省份</td>\n";
            s_Head += "<td class=\"thstyle\" >城市</td>\n";
            s_Head += "<td class=\"thstyle\" >单号</td>\n";
            s_Head += "<td class=\"thstyle\" align=center >数量</td>\n";
            s_Head += "<td class=\"thstyle\" align=center>重量</td>\n";
            s_Head += "<td class=\"thstyle\">单价</td>\n";
            s_Head += "<td class=\"thstyle\">上楼费</td>\n";
            s_Head += "<td class=\"thstyle\" >送货费</td>\n";
            s_Head += "<td class=\"thstyle\" >入仓费</td>\n";
            s_Head += "<td class=\"thstyle\" >回签单</td>\n";
            s_Head += "<td class=\"thstyle\" >保价费率</td>\n";
            s_Head += "<td class=\"thstyle\" >总金额</td>\n";
            s_Head += "<td class=\"thstyle\" >供应商承担</td>\n";
            s_Head += "<td class=\"thstyle\" >士腾承担</td>\n";

            s_Head += "</thead><tbody class=\"scrollContent\">";

            string s_Sql = "Select * from Xs_Sales_Freight a join KNET_WareHouse_DirectOutList b on a.XSF_FID=b.DirectOutNo ";
            s_Sql += " join Cg_Order_Checklist_Details c on a.XSF_ID=c.COD_DirectOutID ";
            s_Sql += " where COD_CheckNo='" + s_ID + "'";
            this.BeginQuery(s_Sql);
            DataSet Dts_Table = (DataSet)this.QueryForDataSet();
            decimal d_Total = 0, d_Total1 = 0, d_Total2 = 0, d_Total3 = 0;
            if (Dts_Table.Tables[0].Rows.Count > 0)
            {
                s_Details += "";
                for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                {
                    s_Details += " <tr>";
                    string s_DirectOutNo = Dts_Table.Tables[0].Rows[i]["XSF_Code"].ToString();
                    string s_Address = Dts_Table.Tables[0].Rows[i]["KWD_Address"].ToString();

                    s_Details += "<td class=\"ListHeadDetails\" align=\"left\">" + (i+1) + "</td>";
                    s_Details += "<td class=\"ListHeadDetails\" align=\"left\">" + s_DirectOutNo + "</td>";
                    s_Details += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetHouseName(Dts_Table.Tables[0].Rows[i]["HouseNo"].ToString()) + "</td>";

                    s_Details += "<td class=\"ListHeadDetails\" align=\"left\">" + base.DateToString(Dts_Table.Tables[0].Rows[i]["XSF_Stime"].ToString()) + "</td>";
                    s_Details += "<td class=\"ListHeadDetails\" align=\"left\">" + base.Base_GetShipDetailProductsPatten(Dts_Table.Tables[0].Rows[i]["XSF_FID"].ToString()) + "</td>";
                    s_Details += "<td class=\"ListHeadDetails\" align=\"left\">" + base.Base_GetCustomerName(Dts_Table.Tables[0].Rows[i]["KWD_Custmoer"].ToString()) + "</td>";

                    s_Details += "<td class=\"ListHeadDetails\" align=\"left\" nowrap>" + base.Base_GetCityName(Dts_Table.Tables[0].Rows[i]["XSF_Province"].ToString()) + "&nbsp;</td>";
                    s_Details += "<td class=\"ListHeadDetails\" align=\"left\" nowrap>" + base.Base_GetShiName(Dts_Table.Tables[0].Rows[i]["XSF_City"].ToString()) + "&nbsp;</td>";
                    s_Details += "<td class=\"ListHeadDetails\" align=\"left\" nowrap>" + Dts_Table.Tables[0].Rows[i]["XSF_KDCode"].ToString() + "&nbsp;</td>";

                    s_Details += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["XSF_TotalNumber"].ToString(), 0) + "</td>";
                    s_Details += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["XSF_Weight"].ToString(), 0) + "</td>";
                    s_Details += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["XSF_WuliuPrice"].ToString(), 3) + "</td>";
                    s_Details += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["XSF_UpstairsCostMoney"].ToString(), 3) + "</td>";
                    s_Details += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["XSF_DeliveryFee"].ToString(), 3) + "</td>";
                    s_Details += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["XSF_WareHouseEntry150Low"].ToString(), 3) + "</td>";
                    s_Details += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["XSF_SignBill"].ToString(), 3) + "</td>";
                    s_Details += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["XSF_Insured"].ToString(), 3) + "</td>";
                    s_Details += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["XSF_TotalMoney"].ToString(), 3) + "</td>";
                    s_Details += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["XSF_FMoney"].ToString(), 3) + "</td>";
                    s_Details += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["XSF_Money"].ToString(), 3) + "</td>";


                    s_Details += "</tr>";
                    try
                    {
                        d_Total += decimal.Parse(Dts_Table.Tables[0].Rows[i]["XSF_TotalNumber"].ToString());
                        d_Total1 += decimal.Parse(Dts_Table.Tables[0].Rows[i]["XSF_TotalMoney"].ToString());
                        d_Total2 += decimal.Parse(Dts_Table.Tables[0].Rows[i]["XSF_FMoney"].ToString());
                        d_Total3 += decimal.Parse(Dts_Table.Tables[0].Rows[i]["XSF_Money"].ToString());
                    }
                    catch
                    { }
                }
                s_Details += "<tr>";
                s_Details += "<td class=\"ListHeadDetails\" align=\"left\" colspan=8>合计：</td>";
                s_Details += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_Total.ToString(), 0) + "</td>";
                s_Details += "<td class=\"ListHeadDetails\" align=\"center\" colspan=7>&nbsp;</td>";
                s_Details += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_Total1.ToString(), 3) + "</td>";
                s_Details += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_Total2.ToString(), 3) + "</td>";
                s_Details += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_Total3.ToString(), 3) + "</td>";
                s_Details += "</tr>";
            }
            this.Lbl_Details.Text = s_Head + s_Details;
        }
    }
}
