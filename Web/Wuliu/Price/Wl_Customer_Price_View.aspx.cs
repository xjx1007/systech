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

using KNet.DBUtility;
using KNet.Common;
using System.Data.SqlClient;

public partial class Xs_Sales_Freight_View : BasePage
{
    public string  s_OrderStyle = "", s_DetailsStyle = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            //this.Tbx_ID.Text = s_ID;
            this.Lbl_Title.Text = "查看运费承担";
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            try
            {
                ShowInfo(s_ID);
            }
            catch
            { }
        }

    }



    [Ajax.AjaxMethod]
    public string ShowCheckDetails1()
    {
        string s_SuppNo = "";
        string s_Return = "";
        string s_Type = "";
        decimal d_Total = 0, d_Total1 = 0, d_Total2 = 0, d_Total3 = 0;
        decimal dd_Total = 0, dd_Total1 = 0, dd_Total2 = 0, dd_Total3 = 0, dd_Total4 = 0;
        s_Return = "" + "|";

        string s_Sql1 = "Select * from PB_Basic_Attachment where PBA_Type='WuliuPrice' and PBA_FID='" + this.Tbx_Code.Text + "' order by PBA_CTime desc";
        this.BeginQuery(s_Sql1);
        DataTable Dtb_Table = this.QueryForDataTable();
        if (Dtb_Table.Rows.Count > 0)
        {
            this.Lbl_Upload.Text = "<a href=\"" + Dtb_Table.Rows[0]["PBA_URL"].ToString() + "\">" + Dtb_Table.Rows[0]["PBA_Name"].ToString() + "</a><br/>";
            this.Tbx_URL.Text = Dtb_Table.Rows[0]["PBA_URL"].ToString();
        }
        Excel excel = new Excel();
        DataTable myT = excel.ExcelFirestToDataTable(this.Tbx_URL.Text, "1=1");
        if (myT != null)
        {
            string s_OrderNo = "", s_DirectOutNO = "";

            if (myT.Rows.Count > 0)
            {
                s_Return += "";
                s_Return += " <table id=\"myTable\" width=\"98%\" border=\"0\" align=\"center\" cellpadding=\"2\" cellspacing=\"0\" class=\"ListDetails\" style=\"height: 28px\">";
                s_Return += "<tr valign=\"top\">";
                s_Return += "<td class=\"ListHead\" nowrap>";
                s_Return += "<b>选择</b></td>";
                s_Return += "<td class=\"ListHead\" nowrap>";
                s_Return += "<b>省份</b></td>";
                s_Return += "<td class=\"ListHead\" nowrap>";
                s_Return += "<b>城市</b></td>";
                s_Return += "<td class=\"ListHead\" nowrap>";
                s_Return += "<b>类型</b></td>";
                s_Return += "<td class=\"ListHead\" nowrap>";
                s_Return += "<b>最少时间</b></td>";
                s_Return += "<td class=\"ListHead\" nowrap>";
                s_Return += "<b>最长时间</b></td>";
                s_Return += "<td class=\"ListHead\" nowrap>";
                s_Return += "<b>最低收费</b></td>";
                s_Return += "<td class=\"ListHead\" >";
                s_Return += "<b>单价</b></td>";
                s_Return += "<td class=\"ListHead\" nowrap>";
                s_Return += "<b>提货费</b></td>";
                s_Return += "<td class=\"ListHead\" nowrap>";
                s_Return += "<b>送货费</b></td>";
                s_Return += "<td class=\"ListHead\" nowrap>";
                s_Return += "<b>上楼费</b></td>";
                s_Return += "<td class=\"ListHead\" nowrap>";
                s_Return += "<b>进仓费（150KG以下）</b></td>";
                s_Return += "<td class=\"ListHead\" nowrap>";
                s_Return += "<b>进仓单价（150KG以上）</b></td>";
                s_Return += "<td class=\"ListHead\" nowrap>";
                s_Return += "<b>保价</b></td>";
                s_Return += "<td class=\"ListHead\" nowrap>";
                s_Return += "<b>回签单</b></td>";
                s_Return += "<td class=\"ListHead\" nowrap>";
                s_Return += "<b>最晚发车</b></td>";
                s_Return += "</tr>";
                for (int i = 0; i < myT.Rows.Count; i++)
                {
                    s_Return += "<tr>";
                    s_Return += "<td class=\"ListHeadDetails\" align=\"center\"><input type=\"CheckBox\" ID=\"Chk_" + i.ToString() + "\"  Name=\"Chk_" + i.ToString() + "\" Checked></td>";

                    try
                    {

                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "" + myT.Rows[i][0].ToString() + "</td>";
                    }
                    catch
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "&nbsp;</td>";
                    }
                    try
                    {

                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "" + myT.Rows[i][1].ToString() + "</td>";
                    }
                    catch
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "&nbsp;</td>";
                    }
                    try
                    {

                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "" + myT.Rows[i][2].ToString() + "</td>";
                    }
                    catch
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "&nbsp;</td>";
                    }
                    try
                    {

                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "" + myT.Rows[i][3].ToString() + "</td>";
                    }
                    catch
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "&nbsp;</td>";
                    }
                    try
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "" + myT.Rows[i][4].ToString() + "</td>";
                    }
                    catch
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "&nbsp;</td>";
                    }

                    try
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "" + myT.Rows[i][5].ToString() + "</td>";
                    }
                    catch
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "&nbsp;</td>";
                    }
                    try
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "" + myT.Rows[i][6].ToString() + "</td>";
                    }
                    catch
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "&nbsp;</td>";
                    }
                    try
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "" + myT.Rows[i][7].ToString() + "</td>";
                    }
                    catch
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "&nbsp;</td>";
                    }
                    try
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "" + myT.Rows[i][8].ToString() + "</td>";
                    }
                    catch
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "&nbsp;</td>";
                    }
                    try
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "" + myT.Rows[i][9].ToString() + "</td>";
                    }
                    catch
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "&nbsp;</td>";
                    }
                    try
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "" + myT.Rows[i][10].ToString() + "</td>";
                    }
                    catch
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "&nbsp;</td>";
                    }
                    try
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "" + myT.Rows[i][11].ToString() + "</td>";
                    }
                    catch
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "&nbsp;</td>";
                    }
                    try
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "" + myT.Rows[i][12].ToString() + "</td>";
                    }
                    catch
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "&nbsp;</td>";
                    }
                    try
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "" + myT.Rows[i][13].ToString() + "</td>";
                    }
                    catch
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "&nbsp;</td>";
                    }
                    try
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "" + myT.Rows[i][14].ToString() + "</td>";
                    }
                    catch
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "&nbsp;</td>";
                    }
                    s_Return += "</tr>";
                }

            }
            s_Return += "</table>";
        }
        return s_Return;
    }

    /// <summary>
    /// 修改显示
    /// </summary>
    private void ShowInfo(string s_ID)
    {
        KNet.BLL.Wl_Customer_Price bll = new KNet.BLL.Wl_Customer_Price();
        KNet.Model.Wl_Customer_Price model = bll.GetModel(s_ID);
        this.Tbx_ID.Text = s_ID;
        this.Tbx_Code.Text = model.WCP_Code;
        this.Tbx_SuppNo.Text = model.WCP_SuppNo;
        this.Tbx_SuppName.Text = base.Base_GetSupplierName(model.WCP_SuppNo);
        this.Tbx_WuliuSuppNo.Text = model.WCP_WuliuSuppNo;
        this.Tbx_WuliuSuppName.Text = base.Base_GetSupplierName(model.WCP_WuliuSuppNo);
        this.Ddl_DutyPerson.Text = base.Base_GetUserName(model.WCP_DutyPerson);
        this.Tbx_Remarks.Text = model.WCP_Remarks;
        this.Lbl_Details.Text = ShowCheckDetails1();
        this.Tbx_Stime.Text = base.DateToString(model.WCP_STime.ToString());
    }


}
