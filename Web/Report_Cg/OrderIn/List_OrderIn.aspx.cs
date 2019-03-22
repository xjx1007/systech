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
            
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string s_ProductsEdition = Request.QueryString["ProductsEdition"] == null ? "" : Request.QueryString["ProductsEdition"].ToString();

            string s_ProductsType = Request.QueryString["ProductsType"] == null ? "" : Request.QueryString["ProductsType"].ToString();
            string s_DutyPerson = Request.QueryString["DutyPerson"] == null ? "" : Request.QueryString["DutyPerson"].ToString();
            string s_Check = Request.QueryString["Check"] == null ? "" : Request.QueryString["Check"].ToString();


            string s_Sql = "Select a.HouseNo,a.SuppNo,c.OrderType,a.WareHouseDateTime,b.ProductsBarCode,d.OrderAmount,b.WareHouseAmount,b.WareHousebAmount,a.WareHouseRemarks,a.WareHouseNo,c.OrderNo,a.HouseNo,d.HandPrice,d.OrderUnitPrice,(Isnull(d.HandPrice,0)+d.OrderUnitPrice)*b.WareHouseAmount,e.KSP_Code,datediff(day,a.WareHouseDateTime, getdate()) days ";
            s_Sql += " from KNet_Procure_WareHouseList  a  join Knet_Procure_WareHouseList_Details b on a.WareHouseNo=b.WareHouseNo ";
            s_Sql += "  join Knet_Procure_OrdersList c on a.OrderNo=c.OrderNo left join Knet_Procure_OrdersList_details d on d.ProductsBarCode=b.ProductsBarCode and a.OrderNO=d.OrderNo join KNet_Sys_Products e on e.ProductsBarCode=b.ProductsBarCode  ";
            s_Sql += "  Where a.KPW_Del='0' ";

            if (s_StartDate != "")
            {
                s_Sql += " and  a.WareHouseDateTime>='" + s_StartDate + "'";
            }
            if (s_EndDate != "")
            {
                s_Sql += " and  a.WareHouseDateTime<='" + s_EndDate + "'";
            }
            if (s_HouseNo != "")
            {
                s_Sql += " and  a.HouseNo='" + s_HouseNo + "'";
            }
            if (s_Check != "")
            {
                if (s_Check == "1")
                {
                    s_Sql += " and  b.ID  in (Select COD_DirectOutID from Cg_Order_Checklist_Details) ";
                }
            }
            
            if (s_SuppNo != "")
            {
                s_Sql += " and  a.SuppNo='" + s_SuppNo + "'";
            }
            if (s_ProductsEdition != "")
            {
                s_Sql += "  e.ProductsEdition like '%" + s_ProductsEdition + "%' ";
            }
            if (s_QRState != "")
            {
                if (s_QRState != "2")
                {
                    s_Sql += " and  a.KPO_QRState='" + s_QRState + "'";
                }
                else
                {
                    s_Sql += " and  a.KPO_QRState='0' and datediff(day,a.WareHouseDateTime, getdate())>=3";
                }
            }

            if (s_ProductsType != "")
            {
                KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
                string s_SonID = Bll_ProductsDetails.GetSonIDs(s_ProductsType);
                s_SonID = s_SonID.Replace(",", "','");
                s_Sql += " and e.ProductsType in ('" + s_SonID + "') ";
            }

            if (s_DutyPerson != "")
            {
                s_Sql += " and a.WareHouseStaffNo ='" + s_DutyPerson + "'";
            }
            s_Sql += " Order by a.WareHouseDateTime ";
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
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>&nbsp;" + Dtb_Table.Rows[i][9].ToString() + "</td>\n";
                    s_Details += "<td class='thstyleLeftDetails' align=left noWrap>" + base.Base_GetSupplierName(Dtb_Table.Rows[i][1].ToString()) + "</td>\n";
                    s_Details += "<td class='thstyleLeftDetails' align=left noWrap>" + base.base_GetProcureTypeNane(Dtb_Table.Rows[i][2].ToString()) + "</td>\n";

                        try
                        {
                            s_Details += "<td  class='thstyleLeftDetails'align=left noWrap>" + DateTime.Parse(Dtb_Table.Rows[i][3].ToString()).ToShortDateString() + "</td>\n";
                        }
                        catch
                        {
                            s_Details += "<td class='thstyleLeftDetails' align=center noWrap>&nbsp;</td>\n";
                        }
                        s_Details += "<td class='thstyleLeftDetails'align=left noWrap>" + Dtb_Table.Rows[i][10].ToString() + "</td>\n";
                        s_Details += "<td class='thstyleLeftDetails'align=left noWrap>" + base.Base_GetHouseName(Dtb_Table.Rows[i][11].ToString()) + "</td>\n";
                    s_Details += "<td class='thstyleLeftDetails'align=center noWrap>" + base.Base_GetProdutsName(Dtb_Table.Rows[i][4].ToString()) + "</td>\n";

                    s_Details += "<td  class='thstyleLeftDetails'align=center noWrap>" + Dtb_Table.Rows[i]["KSP_Code"].ToString() + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails'align=left noWrap>" + base.Base_GetProductsEdition(Dtb_Table.Rows[i][4].ToString()) + "</td>\n";

                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber(Dtb_Table.Rows[i][5].ToString(),0) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber(Dtb_Table.Rows[i][6].ToString(),0) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber(Dtb_Table.Rows[i][7].ToString(),0) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber(Dtb_Table.Rows[i][13].ToString(),3) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber(Dtb_Table.Rows[i][12].ToString(),3) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber(Dtb_Table.Rows[i][14].ToString(),3) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + Dtb_Table.Rows[i][8].ToString() + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + Dtb_Table.Rows[i]["days"].ToString() + "</td>\n";

                    s_Details += " </tr>";
                    try
                    {
                        d_TotalNumber += decimal.Parse(Dtb_Table.Rows[i][5].ToString());
                        d_TotalNumber1 += decimal.Parse(Dtb_Table.Rows[i][6].ToString());
                        d_TotalNumber2 += decimal.Parse(Dtb_Table.Rows[i][7].ToString());
                        d_TotalNumber3 += decimal.Parse(Dtb_Table.Rows[i][14].ToString());
                    }
                    catch
                    {
                    }
                }
                s_Details += " <tr >\n";
                    s_Details += "<td class='thstyleLeftDetails'align=center noWrap colspan='10'>合计:</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber(d_TotalNumber.ToString(), 0) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber(d_TotalNumber1.ToString(), 0) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber(d_TotalNumber2.ToString(), 0) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right noWrap colspan='2'>&nbsp;</td>\n";//money
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber(d_TotalNumber3.ToString(), 3) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right noWrap colspan='2' >&nbsp;</td>\n";//money

                s_Details += " </tr>";
                s_House = Dtb_Table.Rows[0][0].ToString();
            }
            s_Details += "</tbody></table></td></tr>";
                s_Time = "日期:" + s_StartDate + " 到" + s_EndDate;
            s_HouseName = "入库仓库:" + base.Base_GetHouseName(s_House);
            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n";
            s_Head += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\"> \n";
            s_Head += "<tr>\n<th colspan=\"18\" class=\"MaterTitle\" style='height:14.25pt'>杭州士腾科技有限公司<br/>采购入库明细单</th></tr>\n";
            s_Head += "<tr>\n<th colspan=\"6\" class=\"thstyleleft\"  ></th><th colspan=\"12\" class=\"thstyleRight\" >" + s_Time + "</th></tr>\n";
            s_Head += "<th class=\"thstyle\" >项次</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>入库编号</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>供应商名称</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>采购类别</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>发货日期</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>采购单号</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>收货仓库</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>品名</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>料号</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>型号</th>\n";
            s_Head += "<th class=\"thstyle\">采购数量</th>\n";
            s_Head += "<th class=\"thstyle\">入库数量</th>\n";
            s_Head += "<th class=\"thstyle\">备料数量</th>\n";
            s_Head += "<th class=\"thstyle\">单价</th>\n";
            s_Head += "<th class=\"thstyle\">加工费</th>\n";
            s_Head += "<th class=\"thstyle\">金额</th>\n";
            s_Head += "<th class=\"thstyle\">备注</th>\n";
            s_Head += "<th class=\"thstyle\">未确认天数</th>\n";
            s_Head += "</thead><tbody class=\"scrollContent\">";
            s_Details += "</div>";
            this.Lbl_Details.Text = s_Head + s_Details;
        }
    }


    protected void Button2_OnServerClick(object sender, EventArgs e)
    {
        Response.Buffer = true;
        Response.Clear();
        Response.ClearContent();
        Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode("采购入库明细.xls", System.Text.Encoding.UTF8).ToString());
        //Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");

        Response.ContentType = "application/ms-excel";
        Response.Write(this.Lbl_Details.Text);
        Response.Flush();
        Response.End();
    }
}
