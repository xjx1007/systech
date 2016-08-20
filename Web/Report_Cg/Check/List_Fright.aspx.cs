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
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string s_ProductsEdition = Request.QueryString["ProductsEdition"] == null ? "" : Request.QueryString["ProductsEdition"].ToString();

            string s_ProductsType = Request.QueryString["ProductsType"] == null ? "" : Request.QueryString["ProductsType"].ToString();
            string s_DutyPerson = Request.QueryString["DutyPerson"] == null ? "" : Request.QueryString["DutyPerson"].ToString();
            string s_Sql = "select case when isnull(COC_SuppNo,'')='' then c.SuppNo else COC_SuppNo end as COC_SuppNo,h.ProductsName,h.ProductsEdition,case when isnull(COC_SuppNo,'')='' then 0 else 1 end as Type,DirectOutAmount+KWD_BNumber as DirectOutAmount,* from Cg_Order_Checklist a join Cg_Order_Checklist_Details b on a.Coc_Code=b.COD_CheckNo left join KNet_Sys_WareHouse c on c.HouseNo=a.COC_HouseNo   ";
            s_Sql += " left Join Knet_Procure_WareHouseList_Details e on e.ID=b.COD_DirectOutID left join Knet_Procure_WareHouseList g on g.WareHouseNo=e.WareHouseNo left join  KNet_WareHouse_DirectOutList_Details f on f.ID=b.COD_DirectOutID ";
            s_Sql += "  Join Knet_Sys_Products h on h.ProductsBarCode=b.COD_ProductsBarCode  ";
            s_Sql += " where 1=1 ";

            if (s_StartDate != "")
            {
                s_Sql += " and  a.COC_Stime>='" + s_StartDate + "'";
            }
            if (s_EndDate != "")
            {
                s_Sql += " and  a.COC_Stime<='" + s_EndDate + "'";
            }
            if (s_SuppNo != "")
            {
                s_Sql += " and  (a.COC_HouseNo='" + s_SuppNo + "' or a.COC_SuppNo='" + s_SuppNo + "')";
            }
            if (s_Type != "")
            {
                s_Sql += " and  a.COC_Type='" + s_Type + "' ";
            }
            if (s_ProductsEdition != "")
            {
                s_Sql += " and  h.ProductsEdition like '%" + s_ProductsEdition + "%' ";
            }

            if (s_ProductsType != "")
            {
                KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
                string s_SonID = Bll_ProductsDetails.GetSonIDs(s_ProductsType);
                s_SonID = s_SonID.Replace(",", "','");
                s_Sql += " and e.ProductsType in ('" + s_SonID + "') ";
            }
            s_Sql += " Order by a.COC_Stime ";
            string s_House = "", s_Style = "";
            decimal d_TotalNet = 0;
            decimal d_TotalNumber = 0, d_TotalNumber1 = 0, d_TotalNumber2 = 0, d_TotalNumber3 = 0, d_TotalNumber4=0;
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
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>&nbsp;" + Dtb_Table.Rows[i]["COC_Code"].ToString() + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>&nbsp;" + Dtb_Table.Rows[i]["WareHouseNo"].ToString() + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>&nbsp;" + Dtb_Table.Rows[i]["OrderNo"].ToString() + "</td>\n";
                    try
                    {
                        s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>&nbsp;" + DateTime.Parse(Dtb_Table.Rows[i]["WareHouseDateTime"].ToString()).ToShortDateString() + "</td>\n";
                    }
                    catch
                    {
                        s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>&nbsp;</td>\n";
                    }

                    s_Details += "<td class='thstyleLeftDetails' align=left noWrap>" + base.Base_GetSupplierName(Dtb_Table.Rows[i]["COC_SuppNo"].ToString()) + "</td>\n";

                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>&nbsp;" + Dtb_Table.Rows[i]["ProductsName"].ToString() + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>&nbsp;" + Dtb_Table.Rows[i]["KSP_Code"].ToString() + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>&nbsp;" + Dtb_Table.Rows[i]["ProductsEdition"].ToString() + "</td>\n";
                    if (Dtb_Table.Rows[i]["Type"].ToString() == "0")
                    {
                        s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["DirectOutAmount"].ToString(), 0) + "</td>\n";
                    }
                    else
                    {
                        s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["WareHouseAmount"].ToString(), 0) + "</td>\n";
                    }
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["COD_DzNumber"].ToString(), 0) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["COD_BNumber"].ToString(), 0) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["COD_Price"].ToString(), 6) + "</td>\n";
                    decimal d_HandMoney=0;
                    try
                    {
                        d_HandMoney = decimal.Parse(Dtb_Table.Rows[i]["COD_DzNumber"].ToString()) * decimal.Parse(Dtb_Table.Rows[i]["COD_HandPrice"].ToString());
                    }
                    catch
                    { }
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>" + base.FormatNumber1(d_HandMoney.ToString(), 2) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["COD_Money"].ToString(), 2) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>&nbsp;" + GetFp(Dtb_Table.Rows[i]["COC_Code"].ToString()) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>&nbsp;" + Dtb_Table.Rows[i]["COD_Details"].ToString() + "</td>\n";

                    
                    
                   // s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber(Dtb_Table.Rows[i][5].ToString(), 0) + "</td>\n";
                    
                    s_Details += " </tr>";
                    try
                    {
                        if (Dtb_Table.Rows[i]["Type"].ToString() == "0")
                        {

                            d_TotalNumber += decimal.Parse(Dtb_Table.Rows[i]["DirectOutAmount"].ToString());
                        }
                        else
                        {

                            d_TotalNumber += decimal.Parse(Dtb_Table.Rows[i]["WareHouseAmount"].ToString());
                        }
                        d_TotalNumber1 += decimal.Parse(Dtb_Table.Rows[i]["COD_DzNumber"].ToString());
                        d_TotalNumber2 += decimal.Parse(Dtb_Table.Rows[i]["COD_BNumber"].ToString());
                        d_TotalNumber3 += d_HandMoney;
                        d_TotalNumber4 += decimal.Parse(Dtb_Table.Rows[i]["COD_Money"].ToString());
                    }
                    catch
                    {
                    }
                }
                s_Details += " <tr >\n";
                s_Details += "<td class='thstyleLeftDetails'align=center noWrap colspan='9'>合计:</td>\n";
                s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_TotalNumber.ToString(), 0) + "</td>\n";
                s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_TotalNumber1.ToString(), 0) + "</td>\n";
                s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_TotalNumber2.ToString(), 0) + "</td>\n";
                s_Details += "<td  class='thstyleLeftDetails' align=right noWrap >&nbsp;</td>\n";//money
                s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_TotalNumber3.ToString(), 2) + "</td>\n";
                s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_TotalNumber4.ToString(), 2) + "</td>\n";
                s_Details += "<td  class='thstyleLeftDetails' align=right noWrap >&nbsp;</td>\n";//money
                s_Details += "<td  class='thstyleLeftDetails' align=right noWrap >&nbsp;</td>\n";//money

                s_Details += " </tr>";
                s_House = Dtb_Table.Rows[0][0].ToString();
            }
            s_Details += "</tbody></table></td></tr>";
                s_Time = "日期:" + s_StartDate + " 到" + s_EndDate;
            s_HouseName = "入库仓库:" + base.Base_GetHouseName(s_House);
            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n";
            s_Head += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\"> \n";
            s_Head += "<tr>\n<th colspan=\"17\" class=\"MaterTitle\" style='height:14.25pt'>杭州士腾科技有限公司<br/>采购对账明细</th></tr>\n";
            s_Head += "<tr>\n<th colspan=\"7\" class=\"thstyleleft\"  ></th><th colspan=\"10\" class=\"thstyleRight\" >" + s_Time + "</th></tr>\n";
            s_Head += "<th class=\"thstyle\" >项次</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>对账单号</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>入库单号</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>订单号</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>入库日期</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>供应商</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>产品名称</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>料号</th>\n";
            s_Head += "<th class=\"thstyle\">版本号</th>\n";
            s_Head += "<th class=\"thstyle\">出/入数量</th>\n";
            s_Head += "<th class=\"thstyle\">对账数量</th>\n";
            s_Head += "<th class=\"thstyle\">备货数量</th>\n";
            s_Head += "<th class=\"thstyle\">对账单价</th>\n";
            s_Head += "<th class=\"thstyle\">加工费</th>\n";
            s_Head += "<th class=\"thstyle\">总金额</th>\n";
            s_Head += "<th class=\"thstyle\">发票</th>\n";
            s_Head += "<th class=\"thstyle\">备注</th>\n";
            s_Head += "</thead><tbody class=\"scrollContent\">";
            s_Details += "</div>";
            this.Lbl_Details.Text = s_Head + s_Details;
        }
    }
    public string GetFp(string s_ID)
    {
        string s_Return = "";
        try
        {
            this.BeginQuery("select * from PB_Basic_Comment where PBC_FID='" + s_ID + "'");
            this.QueryForDataTable();
            if (this.Dtb_Result.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Result.Rows.Count; i++)
                {
                    s_Return += Dtb_Result.Rows[i]["PBC_Description"].ToString()+"<br/>";
                }
                s_Return = s_Return.Substring(0, s_Return.Length - 5);
            }
        }
        catch
        { }
        return s_Return;
    }
}
