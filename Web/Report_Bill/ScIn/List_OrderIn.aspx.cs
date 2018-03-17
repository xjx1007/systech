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
            string s_SuppNo = Request.QueryString["SuppNo"] == null ? "" : Request.QueryString["SuppNo"].ToString();
            string s_HouseNo = Request.QueryString["HouseNo"] == null ? "" : Request.QueryString["HouseNo"].ToString();
            string s_QRState = Request.QueryString["QRState"] == null ? "" : Request.QueryString["QRState"].ToString();
            string s_State = Request.QueryString["State"] == null ? "" : Request.QueryString["State"].ToString();
            
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string s_ProductsEdition = Request.QueryString["ProductsEdition"] == null ? "" : Request.QueryString["ProductsEdition"].ToString();

            string s_ProductsType = Request.QueryString["ProductsType"] == null ? "" : Request.QueryString["ProductsType"].ToString();
            string s_DutyPerson = Request.QueryString["DutyPerson"] == null ? "" : Request.QueryString["DutyPerson"].ToString();
        
            string s_Sql = "Select c.ProductsName,c.ProductsPattern,c.ProductsEdition,* ";
            s_Sql += " from KNet_WareHouse_DirectInto a join KNet_WareHouse_DirectInto_Details b on a.DirectInNo=b.DirectInNo   ";
            s_Sql += "  join KNET_Sys_Products c on b.ProductsBarCode=c.ProductsBarCode   ";
            s_Sql += "  Where 1=1 and DirectInCheckYN='1' ";

            if (s_StartDate != "")
            {
                s_Sql += " and  a.DirectInDateTime>='" + s_StartDate + "'";
            }
            if (s_EndDate != "")
            {
                s_Sql += " and  a.DirectInDateTime<='" + s_EndDate + "'";
            }
            if (s_HouseNo != "")
            {
                s_Sql += " and  a.HouseNo='" + s_HouseNo + "'";
            }
            if (s_ProductsEdition != "")
            {
                s_Sql += " and  (c.ProductsName like '%" + s_ProductsEdition + "%' or c.ProductsEdition like '%" + s_ProductsEdition + "%' )";
            }
            if (s_State != "")
            {
                s_Sql += " and  a.SEM_CheckYN='" + s_State + "'";

            }
            string s_ProductsBarCode = Request.QueryString["ProductsBarCode"] == null ? "" : Request.QueryString["ProductsBarCode"].ToString();
            string s_HouseNo1 = Request.QueryString["House"] == null ? "" : Request.QueryString["House"].ToString();

            if (s_ProductsBarCode != "")
            {
                s_Sql += " and  c.ProductsBarCode='" + s_ProductsBarCode + "'";
            }
            if (s_HouseNo1 != "")
            {
                s_Sql += " and  a.HouseNo='" + s_HouseNo1 + "'";
            }
            if (s_ProductsType != "")
            {
                KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
                string s_SonID = Bll_ProductsDetails.GetSonIDs(s_ProductsType);
                s_SonID = s_SonID.Replace(",", "','");
                s_Sql += " and c.ProductsType in ('" + s_SonID + "') ";
            }

            s_Sql += " Order by a.DirectInDateTime ";
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
                    s_Details += "<td class='thstyleLeftDetails'>" + (i + 1).ToString() + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' >&nbsp;" + Dtb_Table.Rows[i]["DirectInNo"].ToString() + "</td>\n";
               
                        try
                        {
                            s_Details += "<td  class='thstyleLeftDetails'align=left >" + DateTime.Parse(Dtb_Table.Rows[i]["DirectInDateTime"].ToString()).ToShortDateString() + "</td>\n";
                        }
                        catch
                        {
                            s_Details += "<td class='thstyleLeftDetails' align=center >&nbsp;</td>\n";
                        }
                        s_Details += "<td class='thstyleLeftDetails' >" + base.Base_GetHouseName(Dtb_Table.Rows[i]["HouseNo"].ToString()) + "</td>\n";
                        s_Details += "<td class='thstyleLeftDetails' >" + Dtb_Table.Rows[i]["KSP_Code"].ToString() + "</td>\n";
                        s_Details += "<td class='thstyleLeftDetails' >" + Dtb_Table.Rows[i]["ProductsName"].ToString() + "&nbsp;</td>\n";
                        s_Details += "<td class='thstyleLeftDetails' >" + Dtb_Table.Rows[i]["ProductsPattern"].ToString() + "&nbsp;</td>\n";
                        s_Details += "<td class='thstyleLeftDetails' >" + Dtb_Table.Rows[i]["ProductsEdition"].ToString() + "&nbsp;</td>\n";

                        s_Details += "<td  class='thstyleLeftDetails' align=right  >" + base.FormatNumber1(Dtb_Table.Rows[i]["DirectinAmount"].ToString(), 0) + "</td>\n";
                        s_Details += "<td  class='thstyleLeftDetails' align=right  >" + base.FormatNumber1(Dtb_Table.Rows[i]["DirectinUnitPrice"].ToString(), 2) + "</td>\n";
                        s_Details += "<td  class='thstyleLeftDetails' align=right  >" + base.FormatNumber1(Dtb_Table.Rows[i]["DirectinDisCount"].ToString(), 2) + "</td>\n";
                        s_Details += "<td  class='thstyleLeftDetails' align=right  >" + base.FormatNumber1(Dtb_Table.Rows[i]["DirectinTotalNet"].ToString(), 2) + "</td>\n";
                        s_Details += "<td  class='thstyleLeftDetails' align=right  >&nbsp;" + Dtb_Table.Rows[i]["DirectinRemarks"].ToString() + "</td>\n";

                    s_Details += " </tr>";
                    try
                    {
                        d_TotalNumber1 += decimal.Parse(Dtb_Table.Rows[i][6].ToString());
                        d_TotalNumber += decimal.Parse(Dtb_Table.Rows[i]["OrderMoney"].ToString());
                        d_TotalNumber2 += decimal.Parse(Dtb_Table.Rows[i]["HandMoney"].ToString());
                        d_TotalNumber3 += decimal.Parse(Dtb_Table.Rows[i]["TotalMoney"].ToString());
                    }
                    catch
                    {
                    }
                }
                s_Details += " <tr >\n";
                s_Details += "<td class='thstyleLeftDetails'align=center noWrap colspan='8'>合计:</td>\n";
                s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_TotalNumber1.ToString(), 0) + "</td>\n";
                s_Details += "<td  class='thstyleLeftDetails' align=right noWrap colspan='2' >&nbsp;</td>\n";//money
                s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_TotalNumber3.ToString(), 2) + "</td>\n";
                s_Details += "<td  class='thstyleLeftDetails' align=right noWrap  >&nbsp;</td>\n";//money
                s_Details += " </tr>";
                s_House = Dtb_Table.Rows[0][0].ToString();
            }
            s_Details += "</tbody></table></td></tr>";
                s_Time = "日期:" + s_StartDate + " 到" + s_EndDate;
            s_HouseName = "入库仓库:" + base.Base_GetHouseName(s_House);
            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n";
            s_Head += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\"> \n";
            s_Head += "<tr>\n<th colspan=\"18\" class=\"MaterTitle\" style='height:14.25pt'>杭州士腾科技有限公司<br/>直接入库明细单</th></tr>\n";
            s_Head += "<tr>\n<th colspan=\"7\" class=\"thstyleleft\"  ></th><th colspan=\"11\" class=\"thstyleRight\" >" + s_Time + "</th></tr>\n";
            s_Head += "<th class=\"thstyle\" >项次</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>入库编号</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>入库日期</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>入库仓库</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>料号</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>品名</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>型号</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>版本号</th>\n";
            s_Head += "<th class=\"thstyle\">入库数量</th>\n";
            s_Head += "<th class=\"thstyle\">材料费</th>\n";
            s_Head += "<th class=\"thstyle\">加工费</th>\n";
            s_Head += "<th class=\"thstyle\">金额</th>\n";
            s_Head += "<th class=\"thstyle\">备注</th>\n";
            s_Head += "</thead><tbody class=\"scrollContent\">";
            s_Details += "</div>";
            this.Lbl_Details.Text = s_Head + s_Details;
        }
    }
}
