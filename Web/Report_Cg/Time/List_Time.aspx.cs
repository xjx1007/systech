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

public partial class List_Time : BasePage
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
            string s_Sql = "select a.SuppNo,a.OrderType,Sum(case when c.ID is Not null then 1 else 0 end) as Num from Knet_Procure_OrdersList a join Knet_Procure_OrdersList b on a.OrderNo=b.OrderNo ";
            s_Sql += " left join Knet_Procure_WareHouseList  c  on c.OrderNo=a.OrderNo ";
            s_Sql += " where 1=1 ";
            if (s_StartDate != "")
            {
                s_Sql += " and  c.WareHouseDateTime>='" + s_StartDate + "'";
            }
            if (s_EndDate != "")
            {
                s_Sql += " and  c.WareHouseDateTime<='" + s_EndDate + "'";
            }
            if (s_SuppNo != "")
            {
                s_Sql += " and  a.SuppNo='" + s_SuppNo + "'";
            }
            s_Sql += "  group by a.SuppNo,a.OrderType ";
            string s_House = "", s_Style = "";
            decimal d_Num = 0;
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
                    s_Details += "<td class='thstyleLeftDetails' align=left noWrap>" + base.Base_GetSupplierName(Dtb_Table.Rows[i]["SuppNo"].ToString()) + "</td>\n";
                    s_Details += "<td class='thstyleLeftDetails' align=left noWrap>" + base.base_GetProcureTypeNane(Dtb_Table.Rows[i]["OrderType"].ToString()) + "</td>\n";
                    s_Details += "<td class='thstyleLeftDetails' align=right noWrap>" + Dtb_Table.Rows[i]["Num"].ToString() + "</td>\n";
                    int i_Day1=GetDate(Dtb_Table.Rows[i]["SuppNo"].ToString(), 0);
                    int i_Day2=GetDate(Dtb_Table.Rows[i]["SuppNo"].ToString(), 1);

                    s_Details += "<td class='thstyleLeftDetails' align=right noWrap>" + i_Day1 + "</td>\n";
                    s_Details += "<td class='thstyleLeftDetails' align=right noWrap>" + i_Day2 + "</td>\n";

                  
                    s_Details += " </tr>";
                    try
                    {
                        d_TotalNumber += decimal.Parse(Dtb_Table.Rows[i]["Num"].ToString());
                        d_TotalNumber1 += i_Day1;
                        d_TotalNumber2 += i_Day2;
                    }
                    catch
                    {
                    }
                }
                    s_Details += " <tr >\n";
                    s_Details += "<td class='thstyleLeftDetails'align=center noWrap colspan='3'>合计:</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber(d_TotalNumber.ToString(), 0) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber(d_TotalNumber1.ToString(), 0) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber(d_TotalNumber2.ToString(), 0) + "</td>\n";
                    s_Details += " </tr>";
                    s_Details += " <tr >\n";
                    s_Details += "<td class='thstyleLeftDetails'align=center noWrap colspan='4'>达成率:</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber(Convert.ToString(d_TotalNumber1 / d_TotalNumber * 100), 3) + "%</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber(Convert.ToString(d_TotalNumber2 / d_TotalNumber * 100), 3) + "%</td>\n";
                    s_Details += " </tr>";
                 s_Details += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\"> \n";
            s_Details += "<tr>\n<th colspan=\"6\" class=\"MaterTitle\" style='height:14.25pt'>杭州士腾科技有限公司<br/>未达成原因分析</th></tr>\n";
            s_Details += "<th class=\"thstyle\" >项次</th>\n";
            s_Details += "<th class=\"thstyle\" align=center>供应商名称</th>\n";
            s_Details += "<th class=\"thstyle\" align=center>订单号</th>\n";
            s_Details += "<th class=\"thstyle\" align=center>一次交货期</th>\n";
            s_Details += "<th class=\"thstyle\" align=center>二次交货期</th>\n";
            s_Details += "<th class=\"thstyle\" align=center>实际交货期</th>\n";
            s_Details += "<th class=\"thstyle\" align=center>原因</th>\n";
            s_Details += "</thead><tbody class=\"scrollContent\">";

            s_Sql = "Select distinct OrderNo,WareHouseDateTime,SuppNo from KNet_Sales_OutWareList_FlowList a join Knet_Procure_WareHouseList c on a.OutWareNo=c.OrderNo where cast(FollowText as varchar(1000))<>'' ";
            if (s_StartDate != "")
            {
                s_Sql += " and  c.WareHouseDateTime>='" + s_StartDate + "'";
            }
            if (s_EndDate != "")
            {
                s_Sql += " and  c.WareHouseDateTime<='" + s_EndDate + "'";
            }
            if (s_SuppNo != "")
            {
                s_Sql += " and  c.SuppNo='" + s_SuppNo + "'";
            }
            s_Sql += "  order by OrderNo";
            this.BeginQuery(s_Sql);
            DataTable Dtb_Table1 = (DataTable)this.QueryForDataTable();

            if (Dtb_Table1.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Table1.Rows.Count; i++)
                {
                    s_Details += " <tr " + s_Style + " onmouseover='setActiveBG(this)'>\n";
                    s_Details += "<td class='thstyleLeftDetails'align=center noWrap>" + (i + 1).ToString() + "</td>\n";
                    s_Details += "<td class='thstyleLeftDetails' align=left noWrap>" + base.Base_GetSupplierName(Dtb_Table1.Rows[i]["SuppNo"].ToString()) + "</td>\n";
                    s_Details += "<td class='thstyleLeftDetails' align=left noWrap>" + Dtb_Table1.Rows[i]["OrderNo"].ToString() + "</td>\n";
                    string s_Date1 = GetDate1(Dtb_Table1.Rows[i]["OrderNo"].ToString(), 0);
                    string s_Date2 = GetDate1(Dtb_Table1.Rows[i]["OrderNo"].ToString(), 1);
                    s_Details += "<td class='thstyleLeftDetails' align=left noWrap>" + base.DateToString(s_Date1) + "</td>\n";
                    s_Details += "<td class='thstyleLeftDetails' align=left noWrap>" + base.DateToString(s_Date2) + "</td>\n";
                    s_Details += "<td class='thstyleLeftDetails' align=left noWrap>" + base.DateToString(Dtb_Table1.Rows[i]["WareHouseDateTime"].ToString()) + "</td>\n";
                    s_Details += "<td class='thstyleLeftDetails' align=left noWrap>" + GetText(Dtb_Table1.Rows[i]["OrderNo"].ToString()) + "</td>\n";

                }
            }
            }
            s_Details += "</tbody></table></td></tr>";
                s_Time = "日期:" + s_StartDate + " 到" + s_EndDate;
            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n";
            s_Head += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\"> \n";
            s_Head += "<tr>\n<th colspan=\"6\" class=\"MaterTitle\" style='height:14.25pt'>杭州士腾科技有限公司<br/>物料计划准时出货率</th></tr>\n";
            s_Head += "<tr>\n<th colspan=\"3\" class=\"thstyleleft\"  ></th><th colspan=\"3\" class=\"thstyleRight\" >" + s_Time + "</th></tr>\n";
            s_Head += "<th class=\"thstyle\" >项次</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>供应商名称</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>产品类型</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>入库批次</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>一次交货期</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>二次交货期</th>\n";
            s_Head += "</thead><tbody class=\"scrollContent\">";
            s_Details += "</div>";
            this.Lbl_Details.Text = s_Head + s_Details;
        }
    }
    private int GetDate(string s_SuppNo,int i_num)
    {
        int i_Return = 0;
        try
        {

            string s_StartDate = Request.QueryString["StartDate"] == null ? "" : Request.QueryString["StartDate"].ToString();
            string s_EndDate = Request.QueryString["EndDate"] == null ? "" : Request.QueryString["EndDate"].ToString();
            string s_Sql = "Select WareHouseDateTime,OrderNo from  Knet_Procure_WareHouseList c where 1=1 ";
            if (s_StartDate != "")
            {
                s_Sql += " and  c.WareHouseDateTime>='" + s_StartDate + "'";
            }
            if (s_EndDate != "")
            {
                s_Sql += " and  c.WareHouseDateTime<='" + s_EndDate + "'";
            }
            if (s_SuppNo != "")
            {
                s_Sql += " and  c.SuppNo='" + s_SuppNo + "'";
            }
            s_Sql+=" order by  WareHouseDateTime ";
            this.BeginQuery(s_Sql);
            DataTable Dtb_Table = (DataTable)this.QueryForDataTable();
            for (int i = 0; i < Dtb_Table.Rows.Count; i++)
            {
                string s_Sql1 = "Select ReTime from KNet_Sales_OutWareList_FlowList where OutWareNo='" + Dtb_Table.Rows[i]["OrderNo"].ToString() + "' and  KSO_Order='" + i_num.ToString() + "'";
                this.BeginQuery(s_Sql1);
                  string s_Date=this.QueryForReturn();
                  if (s_Date == "") 
                  {
                      s_Sql1 = "Select OrderPreToDate from Knet_Procure_OrdersList where OrderNo='" + Dtb_Table.Rows[i]["OrderNo"].ToString() + "' ";
                      this.BeginQuery(s_Sql1);
                      s_Date = this.QueryForReturn();
                  }
                  try
                  {

                      if (DateTime.Parse(Dtb_Table.Rows[i]["WareHouseDateTime"].ToString()) <= DateTime.Parse(s_Date))
                      {
                          i_Return += 1;
                      }
                      else
                      {
                          i_Return += 0;
                      }
                  }
                  catch { }
            }
        }
        catch
        { }
        return i_Return;
    }
    private string GetDate1(string s_Order, int i_num)
    {
        string s_Return = "";
        try
        {
            string s_Sql1 = "Select ReTime from KNet_Sales_OutWareList_FlowList where OutWareNo='" + s_Order + "' and  KSO_Order='" + i_num.ToString() + "'";
            this.BeginQuery(s_Sql1);
             s_Return = this.QueryForReturn();
        }
        catch
        { }
        return s_Return;
    }
    private string GetText(string s_Order)
    {
        string s_Return = "";
        try
        {
            string s_Sql1 = "Select * from KNet_Sales_OutWareList_FlowList where OutWareNo='" + s_Order + "' ";
            this.BeginQuery(s_Sql1);
            DataTable Dtb_Table = (DataTable)this.QueryForDataTable();
            for (int i = 0; i < Dtb_Table.Rows.Count; i++)
            {
                s_Return += Dtb_Table.Rows[i]["FollowText"].ToString() + "<br>";
            }
        }
        catch
        { }
        return s_Return;
    }
}
