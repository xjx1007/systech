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

public partial class Web_List_OrderIn : BasePage
{
    public string s_Time = "";
    public string s_HouseName = "";
    public string s_Details = "";
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
            string s_StartDate = Request.QueryString["StartDate"] == null ? "" : Request.QueryString["StartDate"].ToString();
            string s_EndDate = Request.QueryString["EndDate"] == null ? "" : Request.QueryString["EndDate"].ToString();
            string s_CustomerValue = Request.QueryString["CustomerValue"] == null ? "" : Request.QueryString["CustomerValue"].ToString();
            string s_HouseNo = Request.QueryString["HouseNo"] == null ? "" : Request.QueryString["HouseNo"].ToString();
            string s_ContractClass = Request.QueryString["ContractClass"] == null ? "" : Request.QueryString["ContractClass"].ToString();
            
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string s_ProductsEdition = Request.QueryString["ProductsEdition"] == null ? "" : Request.QueryString["ProductsEdition"].ToString();

            string s_ProductsType = Request.QueryString["ProductsType"] == null ? "" : Request.QueryString["ProductsType"].ToString();
            string s_DutyPerson = Request.QueryString["DutyPerson"] == null ? "" : Request.QueryString["DutyPerson"].ToString();

            string s_Sql = "Select a.ContractNo,b.CustomerValue,a.ProductsBarCode,b.ContractClass,b.ContractDateTime,a.Contract_SalesUnitPrice,a.ContractAmount,a.Contract_SalesTotalNet,a.KSC_BNumber,b.DutyPerson ";
            s_Sql += " from KNet_Sales_ContractList_Details  a  join KNet_Sales_ContractList b on a.ContractNo=b.ContractNo ";
            s_Sql += " join KNet_Sys_Products e on e.ProductsBarCode=a.ProductsBarCode  ";
            s_Sql += "  Where 1=1 ";

            if (s_StartDate != "")
            {
                s_Sql += " and  b.ContractDateTime>='" + s_StartDate + "'";
            }
            if (s_EndDate != "")
            {
                s_Sql += " and  b.ContractDateTime<='" + s_EndDate + "'";
            }
            if (s_ProductsEdition != "")
            {
                s_Sql += " and  e.ProductsBarCode in (Select ProductsBarCode From KNet_Sys_Products where ProductsEdition like '%" + s_ProductsEdition + "%')";
            }
            if (s_ProductsType != "")
            {
                KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
                string s_SonID = Bll_ProductsDetails.GetSonIDs(s_ProductsType);
                s_SonID = s_SonID.Replace(",", "','");
                s_Sql += " and e.ProductsType in ('" + s_SonID + "') ";
            }
            if (s_CustomerValue != "")
            {
                s_Sql += " and b.CustomerValue ='" + s_CustomerValue + "'";

            }
            if (s_ContractClass != "")
            {
                s_Sql += " and b.ContractClass ='" + s_ContractClass + "'";
            }
            if (s_DutyPerson != "")
            {
                s_Sql += " and b.DutyPerson ='" + s_DutyPerson + "'";
            }
            s_Sql += " Order by b.SystemDateTimes ";
            string s_House = "", s_Style = "";
            decimal d_TotalNet = 0;
            decimal d_TotalNumber = 0, d_TotalNumber1 = 0, d_TotalNumber2 = 0, d_TotalNumber3=0;
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
                    s_Details += "<td class='thstyleLeftDetails'align=center noWrap>" + (i + 1).ToString() + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>&nbsp;" + Dtb_Table.Rows[i]["ContractNo"].ToString() + "</td>\n";
                    try
                    {
                        s_Details += "<td  class='thstyleLeftDetails'align=left noWrap>" + DateTime.Parse(Dtb_Table.Rows[i]["ContractDateTime"].ToString()).ToShortDateString() + "</td>\n";
                    }
                    catch
                    {
                        s_Details += "<td class='thstyleLeftDetails' align=center noWrap>&nbsp;</td>\n";
                    }
                    s_Details += "<td class='thstyleLeftDetails' align=left noWrap>" + base.Base_GetCustomerName(Dtb_Table.Rows[i]["CustomerValue"].ToString()) + "</td>\n";
                    s_Details += "<td class='thstyleLeftDetails' align=left noWrap>" + base.Base_GetKClaaName(Dtb_Table.Rows[i]["ContractClass"].ToString()) + "</td>\n";

                    s_Details += "<td class='thstyleLeftDetails' align=left noWrap>" + base.Base_GetProdutsName(Dtb_Table.Rows[i]["ProductsBarCode"].ToString()) + "</td>\n";
                    s_Details += "<td class='thstyleLeftDetails' align=left noWrap>" + base.Base_GetProductsEdition(Dtb_Table.Rows[i]["ProductsBarCode"].ToString()) + "</td>\n";

                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(Dtb_Table.Rows[i]["ContractAmount"].ToString(), 0) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(Dtb_Table.Rows[i]["KSC_BNumber"].ToString(), 0) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(Dtb_Table.Rows[i]["Contract_SalesUnitPrice"].ToString(), 3) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(Dtb_Table.Rows[i]["Contract_SalesTotalNet"].ToString(), 3) + "</td>\n";
                    s_Details += "<td class='thstyleLeftDetails' align=left noWrap>" + base.Base_GetUserName(Dtb_Table.Rows[i]["DutyPerson"].ToString()) + "</td>\n";

                    s_Details += " </tr>";
                    try
                    {
                        d_TotalNumber += decimal.Parse(Dtb_Table.Rows[i]["ContractAmount"].ToString());
                        d_TotalNumber1 += decimal.Parse(Dtb_Table.Rows[i]["KSC_BNumber"].ToString());
                        d_TotalNumber2 += decimal.Parse(Dtb_Table.Rows[i]["Contract_SalesUnitPrice"].ToString());
                        d_TotalNumber3 += decimal.Parse(Dtb_Table.Rows[i]["Contract_SalesTotalNet"].ToString());
                    }
                    catch
                    {
                    }
                }
                    s_Details += " <tr >\n";
                    s_Details += "<td class='thstyleLeftDetails'align=center noWrap colspan='7'>合计:</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_TotalNumber.ToString(), 0) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_TotalNumber1.ToString(), 0) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_TotalNumber3.ToString(), 3) + "</td>\n";
                    s_Details += "<td class='thstyleLeftDetails'align=center noWrap >&nbsp;</td>\n";
                    s_Details += " </tr>";
                s_House = Dtb_Table.Rows[0][0].ToString();
            }
            s_Details += "</tbody></table></td></tr>";
                s_Time = "日期:" + s_StartDate + " 到" + s_EndDate;
            s_HouseName = "入库仓库:" + base.Base_GetHouseName(s_House);
            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n";
            s_Head += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\"> \n";
            s_Head += "<tr>\n<th colspan=\"16\" class=\"MaterTitle\" style='height:14.25pt'>杭州士腾科技有限公司<br/>订单评审明细</th></tr>\n";
            s_Head += "<tr>\n<th colspan=\"6\" class=\"thstyleleft\"  ></th><th colspan=\"10\" class=\"thstyleRight\" >" + s_Time + "</th></tr>\n";
            s_Head += "<th class=\"thstyle\" >项次</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>订单号</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>评审日期</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>客户名称</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>合同分类</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>产品名称</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>产品型号</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>订单数量</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>备货数量</th>\n";
            s_Head += "<th class=\"thstyle\">单价</th>\n";
            s_Head += "<th class=\"thstyle\">金额</th>\n";
            s_Head += "<th class=\"thstyle\">责任人</th>\n";
            s_Head += "</thead><tbody class=\"scrollContent\">";
            s_Details += "</div>";
            this.Lbl_Details.Text = s_Head + s_Details;
        }
    }
}
