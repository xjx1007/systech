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


            StringBuilder Sb_Details = new StringBuilder();
            Sb_Details.Append("<table width=\"70%\" border=\"0\" align=\"center\" cellpadding=\"2\" cellspacing=\"0\"  class=\"ListDetails\">");
            string s_Sql = "Select * from sheet4$ ";
            this.BeginQuery(s_Sql);
            DataTable Dtb_Table = (DataTable)this.QueryForDataTable();

            Sb_Details.Append("<tr valign=\"center\" >");
            Sb_Details.Append("<td class=\"ListHead\" align=\"center\" nowrap  width=\"30%\">");
            Sb_Details.Append("ID</td>");
            Sb_Details.Append("<td class=\"ListHead\" align=\"center\" nowrap>");
            Sb_Details.Append("客户</td>");
            Sb_Details.Append("<td class=\"ListHead\" align=\"center\" nowrap>");
            Sb_Details.Append("产品</td>");
            Sb_Details.Append("<td class=\"ListHead\" align=\"center\" nowrap>");
            Sb_Details.Append("数量</td>");
            Sb_Details.Append("<td class=\"ListHead\" align=\"center\" nowrap>");
            Sb_Details.Append("金额</td>");
            Sb_Details.Append("<td class=\"ListHead\" align=\"center\" nowrap>");
            Sb_Details.Append("联系人</td>");
            Sb_Details.Append("<td class=\"ListHead\" align=\"center\" nowrap>");
            Sb_Details.Append("联系电话</td>");
            Sb_Details.Append("<td class=\"ListHead\" align=\"center\" nowrap>");
            Sb_Details.Append("打印</td>");
            Sb_Details.Append("</tr>");
            for (int i = 0; i < Dtb_Table.Rows.Count; i++)
            {
                string s_ProductsPattern = Dtb_Table.Rows[i]["型号"].ToString();
                string s_Number = Dtb_Table.Rows[i]["数量"].ToString();
                string s_Money = Dtb_Table.Rows[i]["金额"].ToString();
                string s_Person = Dtb_Table.Rows[i]["负责人"].ToString();
                string s_Phone = Dtb_Table.Rows[i]["联系方式"].ToString();
                string s_CustomerName = Dtb_Table.Rows[i]["客户名称"].ToString();
                string s_ID = Dtb_Table.Rows[i]["ID"].ToString();

                Sb_Details.Append("<tr valign=\"center\" >");
                Sb_Details.Append("<td class=\"ListHeadDetails\" align=\"center\" nowrap  width=\"30%\">");
                Sb_Details.Append("" + s_ID + "</td>");
                Sb_Details.Append("<td class=\"ListHeadDetails\" align=\"left\" nowrap>");
                Sb_Details.Append("" + s_CustomerName + "</td>");
                Sb_Details.Append("<td class=\"ListHeadDetails\" align=\"left\" nowrap>");
                Sb_Details.Append("" + s_ProductsPattern + "</td>");
                Sb_Details.Append("<td class=\"ListHeadDetails\" align=\"center\" nowrap>");
                Sb_Details.Append("" + s_Number + "</td>");
                Sb_Details.Append("<td class=\"ListHeadDetails\" align=\"center\" nowrap>");
                Sb_Details.Append("" + s_Money + "</td>");
                Sb_Details.Append("<td class=\"ListHeadDetails\" align=\"center\" nowrap>");
                Sb_Details.Append("" + s_Person + "</td>");
                Sb_Details.Append("<td class=\"ListHeadDetails\" align=\"center\" nowrap>");
                Sb_Details.Append("" + s_Phone + "</td>");


                Sb_Details.Append("<td  class='ListHeadDetails' align=right  noWrap><a href=\"#\"  onclick=\"GPrint('" + s_ID+ "')\"><Image ID=\"Image4\" src=\"../images/Print1.gif\" border=0   /></a></td>\n");

                Sb_Details.Append("</tr>");
                this.Tbx_ID.Text +=s_ID+",";
            }
            Sb_Details.Append("</table>");
            this.Lbl_Details.Text = Sb_Details.ToString();
        }
    }
    private string ShowDetails()
    {
        StringBuilder Sb_Details = new StringBuilder();
        try
        {
            string s_Sql = "Select * from 1";
            this.BeginQuery(s_Sql);
            DataTable Dtb_Table = (DataTable)this.QueryForDataTable();
            for (int i = 0; i < Dtb_Table.Rows.Count; i++)
            {
                string s_ProductsPattern = Dtb_Table.Rows[i]["F1"].ToString();
                string s_Number = Dtb_Table.Rows[i]["F1"].ToString();
                string s_Money = Dtb_Table.Rows[i]["F1"].ToString();
                string s_Person = Dtb_Table.Rows[i]["F1"].ToString();
                string s_Phone = Dtb_Table.Rows[i]["F1"].ToString();
                string s_CustomerName = Dtb_Table.Rows[i]["F1"].ToString();
                Sb_Details.Append("<table width=\"50%\" border=\"0\" align=\"center\" cellpadding=\"2\" cellspacing=\"0\"  class=\"ListDetails\">");
                Sb_Details.Append("<tr valign=\"center\">");
                Sb_Details.Append("<td class=\"ListHeadDetails\"  align=\"center\" colspan=2 nowrap>");
                Sb_Details.Append("<H2> 用 户 使 用 报 告</H2></td>");
                Sb_Details.Append("</tr>");
                Sb_Details.Append("<tr valign=\"center\" >");
                Sb_Details.Append("<td class=\"ListHeadDetails\" align=\"center\" nowrap  width=\"30%\">");
                Sb_Details.Append("供应商名称</td>");
                Sb_Details.Append("<td class=\"ListHeadDetails\" align=\"center\" nowrap>");
                Sb_Details.Append("杭州士腾科技有限公司</td>");
                Sb_Details.Append("</tr>");
                Sb_Details.Append("<tr valign=\"center\">");
                Sb_Details.Append("<td class=\"ListHeadDetails\" align=\"center\" nowrap>");
                Sb_Details.Append("设备厂家名称</td>");
                Sb_Details.Append("<td class=\"ListHeadDetails\" align=\"center\" nowrap>");
                Sb_Details.Append("杭州士腾科技有限公司</td>");
                Sb_Details.Append("</tr>");
                Sb_Details.Append("<tr valign=\"center\">");
                Sb_Details.Append("<td class=\"ListHeadDetails\" align=\"center\" nowrap>");
                Sb_Details.Append("设备器材名称/ <br>型号</td>");
                Sb_Details.Append("<td class=\"ListHeadDetails\" align=\"center\" nowrap>");
                Sb_Details.Append(""+s_ProductsPattern+" </td>");
                Sb_Details.Append("</tr>");
                Sb_Details.Append("<tr valign=\"center\">");
                Sb_Details.Append("<td class=\"ListHeadDetails\" align=\"center\" nowrap>");
                Sb_Details.Append("使用时间/ <br>使用数量</td>");
                Sb_Details.Append("<td class=\"ListHeadDetails\" align=\"center\" nowrap>");
                Sb_Details.Append("自<div><font style=\"border-bottom:1px solid #000;\"> 2013 </font><div>年<font style=\"border-bottom:1px solid #000;\"> 01 </font>月至今，上述设备共购买使用 <font style=\"border-bottom:1px solid #000;\"> " + s_Number + " </font>（台/套/），共计   <font style=\"border-bottom:1px solid #000;\"> " + s_Money + " </font> 万元。</td>");
                Sb_Details.Append("</tr>");
                
                Sb_Details.Append("<tr valign=\"center\">");
                Sb_Details.Append("<td class=\"ListHeadDetails\" align=\"center\" nowrap>");
                Sb_Details.Append("使用单位项目负责人/ <br>联系电话</td>");
                Sb_Details.Append("<td class=\"ListHeadDetails\" align=\"center\" nowrap>");
                Sb_Details.Append("姓名：<font style=\"border-bottom:1px solid #000;\">   " + s_Person + "  </font> 联系电话：    <font style=\"border-bottom:1px solid #000;\">   " + s_Phone + "  </font></td>");
                Sb_Details.Append("</tr>");

                Sb_Details.Append("<tr valign=\"center\">");
                Sb_Details.Append("<td class=\"ListHeadDetails\" align=\"center\" nowrap>");
                Sb_Details.Append("设备器材使用情况</td>");
                Sb_Details.Append("<td class=\"ListHeadDetails\" align=\"center\" nowrap>");
                Sb_Details.Append("上述设备器材（在保修期内）出现故障或质量问题的数量为<font style=\"border-bottom:1px solid #000;\">             </font>（台/套/<font style=\"border-bottom:1px solid #000;\">           </font>）,故障率<font style=\"border-bottom:1px solid #000;\">         </font>%（故障或质量问题数量/购买使用数量）。</td>");
                Sb_Details.Append("</tr>");

                Sb_Details.Append("<tr valign=\"center\">");
                Sb_Details.Append("<td class=\"ListHeadDetails\" align=\"center\" nowrap>");
                Sb_Details.Append("售后服务情况</td>");
                Sb_Details.Append("<td class=\"ListHeadDetails\" align=\"center\" nowrap>");
                Sb_Details.Append("□良好    □一般   □不到位   □其他<font style=\"border-bottom:1px solid #000;\">                      </font></td>");
                Sb_Details.Append("</tr>");

                Sb_Details.Append("<tr valign=\"center\">");
                Sb_Details.Append("<td class=\"ListHeadDetails\" align=\"center\" height=\"100px\" nowrap>");
                Sb_Details.Append("使用单位名称/<br/>意见（公司签章）</td>");
                Sb_Details.Append("<td class=\"ListHeadDetails\" align=\"right\" nowrap>");
                Sb_Details.Append("" + s_CustomerName + "</br>年     月    日</td>");
                Sb_Details.Append("</tr>");
            }
        }
        catch { }
        return Sb_Details.ToString();
    }
}