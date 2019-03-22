using KNet.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Report_Zl_IQC_OQC_Submitted_OQC_List : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess Am = new AdminloginMess();
            string s_StartDate = Request.QueryString["StartDate"] == null
                ? ""
                : Request.QueryString["StartDate"].ToString();
            string s_EndDate = Request.QueryString["EndDate"] == null ? "" : Request.QueryString["EndDate"].ToString();
            string s_Sql =
                "select a.KSP_Time as '检验日期',c.KSP_COde as '料号',b.KPD_Code as '编号',d.SuppName as '供应商',c.ProductsName as '物料名称',c.ProductsEdition as '规格型号',b.KPD_OrderNo as '订单号', b.KPD_Number as'送检数量', b.KPD_CheckNumber as '检验数量',b.KPD_BadNumber as '不良数量',b.KPD_RejectRatio as  '不良率',b.KPD_Remark as '备注' from Knet_Submitted_Product a join Knet_Submitted_Product_Details b on a.KSP_SID = b.KPD_SID join KNet_Sys_Products c on b.KPD_Code = c.ProductsBarCode join Knet_Procure_Suppliers d on a.KSP_SuppNo = d.SuppNo   where KSP_Time>= '" +
                s_StartDate + "' and KSP_Time<= '" + s_EndDate +
                "' and KSP_Type = 2 and b.KPD_YNTState!=0 order by KSP_Time";
            //s_Sql += " Allocate_WwMoney ,AllocateStaffNo,AllocateCheckStaffNo,OutHouseName,ProductsEdition,AllocateTotalNet,AllocateUnitPrice ";
            //s_Sql += " from  v_AllocateList  ";
            //s_Sql += " Where 1=1 and AllocateNo not like 'FX%'  ";
            //string s_StartDate = Request.QueryString["StartDate"] == null ? "" : Request.QueryString["StartDate"].ToString();
            //string s_EndDate = Request.QueryString["EndDate"] == null ? "" : Request.QueryString["EndDate"].ToString();
            //string s_CustomerName = Request.QueryString["CustomerName"] == null ? "" : Request.QueryString["CustomerName"].ToString();
            //string s_ProductsType = Request.QueryString["ProductsType"] == null ? "" : Request.QueryString["ProductsType"].ToString();
            //string s_CustomerTypes = Request.QueryString["CustomerTypes"] == null ? "" : Request.QueryString["CustomerTypes"].ToString();
            //string s_ProductsEdition = Request.QueryString["ProductsEidition"] == null ? "" : Request.QueryString["ProductsEidition"].ToString();
            //string s_State = Request.QueryString["State"] == null ? "" : Request.QueryString["State"].ToString();

            //string s_Ck = Request.QueryString["Ck"] == null ? "" : Request.QueryString["Ck"].ToString();
            //string s_InCk = Request.QueryString["InCk"] == null ? "" : Request.QueryString["InCk"].ToString();

            //string s_Code = Request.QueryString["Code"] == null ? "" : Request.QueryString["Code"].ToString();
            //string s_AllocateNo = Request.QueryString["AllocateNo"] == null ? "" : Request.QueryString["AllocateNo"].ToString();

            //string s_FaterBarCode = Request.QueryString["FaterBarCode"] == null ? "" : Request.QueryString["FaterBarCode"].ToString();

            //string s_OutHouseNo = Request.QueryString["OutHouseNo"] == null ? "" : Request.QueryString["OutHouseNo"].ToString();
            //string s_InHouseNo = Request.QueryString["InHouseNo"] == null ? "" : Request.QueryString["InHouseNo"].ToString();
            //string s_ProductsBarCode = Request.QueryString["ProductsBarCode"] == null ? "" : Request.QueryString["ProductsBarCode"].ToString();

            string s_Details = "", s_Style = "";
            string s_Head = "";
            //Decimal DTotalNum = 0, DTotalNum1 = 0, DTotalNum2 = 0;
            s_Head +=
                "<div class=\"tableContainer\" id=\"tableContainer\" >\n<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n";
            s_Head += "<thead class=\"fixedHeader\"> \n";
            s_Head +=
                "<tr>\n<th colspan=\"14\" class=\"MaterTitle\" style='height:14.25pt'>杭州士腾科技有限公司<br/>OQC送检报表</th></tr>\n";
            s_Head += "<tr>\n<th colspan=\"7\" class=\"thstyleleft\"  >" + "制表人:" + Am.KNet_StaffName +
                      "</th><th colspan=\"6\" class=\"thstyleRight\" >" + "日期:" + s_StartDate + " 到 " + s_EndDate +
                      "</th></tr>\n";
            s_Head += "<tr class=\"thstyle\">\n<th>序号</th>\n";
            s_Head += "<th class=\"thstyle\">检验日期</th>\n";
            s_Head += "<th class=\"thstyle\">料号</th>\n";
            s_Head += "<th class=\"thstyle\">供应商</th>\n";
            s_Head += "<th class=\"thstyle\">物料名称</th>\n";
            s_Head += "<th class=\"thstyle\">规格型号</th>\n";
            s_Head += "<th class=\"thstyle\">订单号</th>\n";
            s_Head += "<th class=\"thstyle\">订单数量</th>\n";
            s_Head += "<th class=\"thstyle\">送检数量</th>\n";
            s_Head += "<th class=\"thstyle\">检验数量</th>\n";
            s_Head += "<th class=\"thstyle\">合格数</th>\n";
            s_Head += "<th class=\"thstyle\">不合格数</th>\n";
            s_Head += "<th class=\"thstyle\">不良率</th>\n";
            s_Head += "<th class=\"thstyle\">备注</th>\n";
            s_Head += "</tr>\n";
            s_Head += "</thead><tbody class=\"scrollContent\">";

            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;

            string s_ID = "";
            if (Dtb_Table.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
                    s_ID += Dtb_Table.Rows[i][0].ToString() + ",";

                    if (i%2 == 0)
                    {
                        s_Style = "class='gg'";
                    }
                    else
                    {
                        s_Style = "class='rr'";
                    }
                    s_Details += " <tr " + s_Style + " onmouseover='setActiveBG(this)'>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + (i + 1).ToString() + "</td>\n";
                    s_Details += "<td align=left  class='thstyleLeftDetails' noWrap>" +
                                 Dtb_Table.Rows[i]["检验日期"].ToString() + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails'  noWrap>" +
                                 Dtb_Table.Rows[i]["料号"].ToString() + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails'  noWrap>" +
                                 Dtb_Table.Rows[i]["供应商"].ToString() + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails'  noWrap>" +
                                 Dtb_Table.Rows[i]["物料名称"].ToString() + "</td>\n";

                    s_Details += "<td align=left class='thstyleLeftDetails'  noWrap>" +
                                 Dtb_Table.Rows[i]["规格型号"].ToString() + "</td>\n";
                    s_Details += "<td align=left  class='thstyleLeftDetails' noWrap>" +
                                 Dtb_Table.Rows[i]["订单号"].ToString() + "</td>\n";
                    s_Details += "<td align=left  class='thstyleLeftDetails' noWrap>" +
                                 Get_OrderNum(Dtb_Table.Rows[i]["订单号"].ToString(), Dtb_Table.Rows[i]["编号"].ToString()) +
                                 "</td>\n";
                    s_Details += "<td align=left  class='thstyleLeftDetails' noWrap>" +
                                 Dtb_Table.Rows[i]["送检数量"].ToString() + "</td>\n";
                    s_Details += "<td align=left  class='thstyleLeftDetails' noWrap>" +
                                 Dtb_Table.Rows[i]["检验数量"].ToString() + "</td>\n";
                    s_Details += "<td align=left  class='thstyleLeftDetails' noWrap>" +
                                 (Convert.ToInt32(Dtb_Table.Rows[i]["检验数量"].ToString()) -
                                  Convert.ToInt32(Dtb_Table.Rows[i]["不良数量"].ToString())) + "</td>\n";
                    s_Details += "<td align=right class='thstyleLeftDetails'  noWrap>" +
                                 Dtb_Table.Rows[i]["不良数量"].ToString() + "</td>\n"; //数量

                    s_Details += "<td align=right class='thstyleLeftDetails'  noWrap>" +
                                 (Convert.ToDecimal(Dtb_Table.Rows[i]["不良率"].ToString())*100).ToString("f2") + "%" +
                                 "</td>\n"; //数量
                    s_Details += "<td align=right class='thstyleLeftDetails'  noWrap>" +
                                 Dtb_Table.Rows[i]["备注"].ToString() + "</td>\n"; //数量
                    s_Details += " </tr>";

                }
            }

            this.Lbl_Details.Text = s_Head + s_Details;

        }
    }

    public string Get_OrderNum(string Order, string ProductCode)
    {
        try
        {
            string s_Sql = "select OrderAmount from Knet_Procure_OrdersList_Details where OrderNo='" + Order + "' and ProductsBarCode='" + ProductCode + "'";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            return Dtb_Table.Rows[0][0].ToString();
        }
        catch
        {
            return "";
        }
       
    }

    protected void Button2_OnServerClick(object sender, EventArgs e)
    {
        Response.Buffer = true;
        Response.Clear();
        Response.ClearContent();
        Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode("OQC送检报表.xls", System.Text.Encoding.UTF8).ToString());
        //Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");

        Response.ContentType = "application/ms-excel";
        Response.Write(this.Lbl_Details.Text);
        Response.Flush();
        Response.End();
    }
}