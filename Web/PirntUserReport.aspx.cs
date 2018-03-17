using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using System.Runtime.Serialization.Json;
using KNet.DBUtility;
using KNet.Common;
using System.Net;
using System.Net.Mail;
using System.Diagnostics;
using iTextSharp.text.pdf;
using System.Linq;
using System.Web.Caching;
using System.Xml;
using System.Web.Script.Serialization;



public partial class Web_PirntUserReport : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            if (s_ID != "")
            {

                this.Lbl_Details.Text = ShowDetails(s_ID);
            }
        }
    }
    private string ShowDetails(string s_ID)
    {
        StringBuilder Sb_Details = new StringBuilder();
        try
        {
            string s_Sql = "Select * from sheet4$  where ID='" + s_ID + "'";
            this.BeginQuery(s_Sql);
            DataTable Dtb_Table = (DataTable)this.QueryForDataTable();
            for (int i = 0; i < Dtb_Table.Rows.Count; i++)
            {
                string s_ProductsPattern = Dtb_Table.Rows[i]["型号"].ToString();
                string s_Number = Dtb_Table.Rows[i]["数量"].ToString();
                string s_Money = Dtb_Table.Rows[i]["金额"].ToString();
                string s_Person = Dtb_Table.Rows[i]["负责人"].ToString();
                string s_Phone = Dtb_Table.Rows[i]["联系方式"].ToString();
                string s_CustomerName = Dtb_Table.Rows[i]["客户名称"].ToString();

                Sb_Details.Append( "<div class=\"tableContainer\" id=\"tableContainer\" >\n");
                Sb_Details.Append("<table width=\"100%\" border=\"0\" align=\"center\" cellpadding=\"2\" cellspacing=\"0\" >");
                Sb_Details.Append("<tr valign=\"center\">");
                Sb_Details.Append("<td class=\"ListHeadDetails2\"  height=\"70px\" align=\"center\" colspan=2 nowrap>");
                Sb_Details.Append("<H1> 用 户 使 用 报 告</H1></td>");
                Sb_Details.Append("</tr>");
                Sb_Details.Append("</table>");
                Sb_Details.Append("<table width=\"100%\" border=\"0\" align=\"center\" cellpadding=\"2\" cellspacing=\"0\"  class=\"ListDetails_Print\">");
                Sb_Details.Append("<tr valign=\"center\" >");
                Sb_Details.Append("<td class=\"ListHeadDetails\" align=\"center\" height=\"70px\" width=\"30%\" nowrap >");
                Sb_Details.Append("供应商名称</td>");
                Sb_Details.Append("<td class=\"ListHeadDetails\" align=\"center\" nowrap>");
                Sb_Details.Append("杭州士腾科技有限公司</td>");
                Sb_Details.Append("</tr>");
                Sb_Details.Append("<tr valign=\"center\">");
                Sb_Details.Append("<td class=\"ListHeadDetails\" height=\"70px\" align=\"center\" nowrap>");
                Sb_Details.Append("设备厂家名称</td>");
                Sb_Details.Append("<td class=\"ListHeadDetails\" align=\"center\" nowrap>");
                Sb_Details.Append("杭州士腾科技有限公司</td>");
                Sb_Details.Append("</tr>");
                Sb_Details.Append("<tr valign=\"center\">");
                Sb_Details.Append("<td class=\"ListHeadDetails\" height=\"110px\" align=\"center\" nowrap>");
                Sb_Details.Append("设备器材名称/ <br>型号</td>");
                Sb_Details.Append("<td class=\"ListHeadDetails\" align=\"center\" >");
                Sb_Details.Append(""+s_ProductsPattern+" </td>");
                Sb_Details.Append("</tr>");
                Sb_Details.Append("<tr valign=\"center\">");
                Sb_Details.Append("<td class=\"ListHeadDetails\" height=\"110px\"  align=\"center\" nowrap>");
                Sb_Details.Append("使用时间/ <br>使用数量</td>");
                Sb_Details.Append("<td class=\"ListHeadDetails\" align=\"left\" >");
                Sb_Details.Append("自<font style=\"border-bottom:1px solid #000;\">&nbsp;2013&nbsp;</font>年<font style=\"border-bottom:1px solid #000;\">&nbsp;&nbsp;01&nbsp;&nbsp;</font>月至今，上述设备共购买使用 <font style=\"border-bottom:1px solid #000;\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + s_Number + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>（台/套/），共计   <font style=\"border-bottom:1px solid #000;\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + s_Money + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font> 万元。</td>");
                Sb_Details.Append("</tr>");
                
                Sb_Details.Append("<tr valign=\"center\">");
                Sb_Details.Append("<td class=\"ListHeadDetails\" height=\"70px\"  align=\"center\" nowrap>");
                Sb_Details.Append("使用单位项目负责人/ <br>联系电话</td>");
                Sb_Details.Append("<td class=\"ListHeadDetails\" align=\"left\" nowrap>");
                Sb_Details.Append("姓名：<font style=\"border-bottom:1px solid #000;\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + s_Person + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font> 联系电话：    <font style=\"border-bottom:1px solid #000;\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + s_Phone + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font></td>");
                Sb_Details.Append("</tr>");

                Sb_Details.Append("<tr valign=\"center\">");
                Sb_Details.Append("<td class=\"ListHeadDetails\"  height=\"140px\"  align=\"center\" nowrap>");
                Sb_Details.Append("设备器材使用情况</td>");
                Sb_Details.Append("<td class=\"ListHeadDetails\" align=\"left\" >");
                Sb_Details.Append("上述设备器材（在保修期内）出现故障或质量问题的数量为<font style=\"border-bottom:1px solid #000;\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>（台/套/<font style=\"border-bottom:1px solid #000;\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>）,故障率<font style=\"border-bottom:1px solid #000;\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>%（故障或质量问题数量/购买使用数量）。</td>");
                Sb_Details.Append("</tr>");

                Sb_Details.Append("<tr valign=\"center\">");
                Sb_Details.Append("<td class=\"ListHeadDetails\" height=\"70px\"  align=\"center\" nowrap>");
                Sb_Details.Append("售后服务情况</td>");
                Sb_Details.Append("<td class=\"ListHeadDetails\" align=\"left\" >");
                Sb_Details.Append("<input type=\"checkbox\">良好    <input type=\"checkbox\">一般   <input type=\"checkbox\">不到位   <input type=\"checkbox\">其他<font style=\"border-bottom:1px solid #000;\"> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font></td>");
                Sb_Details.Append("</tr>");

                Sb_Details.Append("<tr valign=\"center\">");
                Sb_Details.Append("<td class=\"ListHeadDetails1\" align=\"center\" height=\"300px\" nowrap>");
                Sb_Details.Append("使用单位名称/<br/>意见（公司签章）</td>");
                Sb_Details.Append("<td class=\"ListHeadDetails\" align=\"right\" valign=\"bottom\" nowrap>");
                Sb_Details.Append("" + s_CustomerName + "</br>&nbsp;年&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;月&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;日</td>");
                Sb_Details.Append("</tr>");
            }
        }
        catch { }

        Sb_Details.Append("</table>\n");
        Sb_Details.Append("</div>\n");
        return Sb_Details.ToString();
    }
}