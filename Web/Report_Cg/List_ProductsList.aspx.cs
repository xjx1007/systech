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
using System.Data.SqlClient;

using KNet.DBUtility;
using KNet.Common;

public partial class Web_Report_Xs_List_ProductsList : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string s_Sql = "Select ProductsName,KSP_Code,ProductsPattern,ProductsEdition,PBP_Name,UnitsName,KSP_BZNumber,ProductsAddTime,ProductsAddMan,ProductsDescription,KSP_UseType,KSP_LossType ";
            s_Sql += "  from Knet_Sys_Products a join PB_Basic_ProductsClass b on a.ProductsType=b.PBP_ID join KNet_Sys_Units c on c.UnitsNo=a.ProductsUnits Where 1=1 and ksp_Del=0 ";
            string s_ProductsName = Request.QueryString["ProductsName"] == null ? "" : Request.QueryString["ProductsName"].ToString();
            string s_ProductsPattern = Request.QueryString["ProductsPattern"] == null ? "" : Request.QueryString["ProductsPattern"].ToString();
            string s_ProductsEdition = Request.QueryString["ProductsEdition"] == null ? "" : Request.QueryString["ProductsEdition"].ToString();
            string s_ProductsMainCategory = Request.QueryString["ProductsMainCategory"] == null ? "" : Request.QueryString["ProductsMainCategory"].ToString();
            string s_ProductsType = Request.QueryString["ProductsType"] == null ? "" : Request.QueryString["ProductsType"].ToString();

            
            string s_Details="",s_Style="";
            string s_Head = "";

            if (s_ProductsName != "")
            {
                s_Sql += " and ProductsName like '%" + s_ProductsName + "%'";
            }
            if (s_ProductsPattern != "")
            {
                s_Sql += " and ProductsPattern like '%" + s_ProductsPattern + "%'";
            }
            if (s_ProductsEdition != "")
            {
                s_Sql += "  and ProductsEdition like '%" + s_ProductsEdition + "%'";
            }
            if (s_ProductsMainCategory != "")
            {
                s_Sql += " and ProductsMainCategory = '" + s_ProductsMainCategory + "'";
            }

            if (s_ProductsType != "")
            {
                KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
                string s_SonID = Bll_ProductsDetails.GetSonIDs(s_ProductsType);
                s_SonID = s_SonID.Replace(",", "','");
                s_Sql += " and ProductsType in ('" + s_SonID + "') ";
            }
            s_Sql += "Order by ProductsPattern";

            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table=this.Dtb_Result;
            if(Dtb_Table.Rows.Count>0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
                    if(i%2==0)
                    {
                       s_Style="class='gg'";
                    }
                    else
                    {
                        s_Style="class='rr'";
                    }
                    s_Details += " <tr " + s_Style + " onmouseover='setActiveBG(this)'>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + (i + 1).ToString() + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + Dtb_Table.Rows[i]["ProductsName"].ToString() + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>&nbsp;" + Dtb_Table.Rows[i]["KSP_Code"].ToString() + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>&nbsp;" + Dtb_Table.Rows[i]["ProductsPattern"].ToString() + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>&nbsp;" + Dtb_Table.Rows[i]["ProductsEdition"].ToString() + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + Dtb_Table.Rows[i]["PBP_Name"].ToString() + "</td>\n";
                    
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + Dtb_Table.Rows[i]["UnitsName"].ToString()  + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + Dtb_Table.Rows[i]["KSP_BZNumber"].ToString() + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>&nbsp;" + base.Base_GetBasicCodeName("1134", Dtb_Table.Rows[i]["KSP_UseType"].ToString()) + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>&nbsp;" + base.Base_GetBasicCodeName("1136", Dtb_Table.Rows[i]["KSP_LossType"].ToString()) + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>&nbsp;" + base.Base_GetUserName(Dtb_Table.Rows[i]["ProductsAddMan"].ToString()) + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + DateTime.Parse(Dtb_Table.Rows[i]["ProductsAddTime"].ToString()).ToShortDateString() + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails'  >&nbsp;" + Dtb_Table.Rows[i]["ProductsDescription"].ToString() + "</td>\n";
                    s_Details +=" </tr>";
                   // DTotalNum += Decimal.Parse(Dtb_Table.Rows[i][6].ToString());
                   // DTotalNet += Decimal.Parse(Dtb_Table.Rows[i][8].ToString());
                }
            }

            //s_Details += " <tr >\n";

            //s_Details += "<td  width='1%' align=left noWrap colspan=6>合计:" + (Dtb_Table.Rows.Count).ToString() + "</td>\n";
            //s_Details += "<td align=right width='1%' noWrap>" + DTotalNum.ToString() + "</td>\n";//数量
            //s_Details += "<td align=right width='1%'noWrap>&nbsp;</td>\n";//单价
            //s_Details += "<td align=right width='1%'  noWrap>" + DTotalNet.ToString() + "</td>\n";//金额
            //s_Details += "<td align=right width='1%' noWrap>&nbsp;</td>\n";//单价
            //s_Details += "<td align=right width='1%'  noWrap>&nbsp;</td>\n";//单价
            //s_Details += " </tr>";
            s_Details += "</tbody></table></div>";

            AdminloginMess Am = new AdminloginMess();
            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\"> \n";
            s_Head += "<tr>\n<th  colspan=\"20\" align=\"center\" width=\"100%\" class=\"thsTitle\" noWrap><font width=\"100\" size=\"6\"><b>产品明细</b></font></th>\n</tr>";
            s_Head += "<tr>\n<th  align=\"left\" width=\"100%\" class=\"thsTitle\" colspan=\"10\"></th><th  align=\"right\"  class=\"thsTitle\" colspan=\"10\">" + "制表人:" + Am.KNet_StaffName + "</th>\n</tr>";
            
            s_Head += "<tr>\n<th class=\"thstyle\">序号</th>\n";
            s_Head += "<th class=\"thstyle\">产品名称</th>\n";
            s_Head += "<th class=\"thstyle\">料号</th>\n";
            s_Head += "<th class=\"thstyle\">型号</th>\n";
            s_Head += "<th class=\"thstyle\">版本号</th>\n";
            s_Head += "<th class=\"thstyle\">产品分类</th>\n";
            s_Head += "<th class=\"thstyle\">单位</th>\n";
            s_Head += "<th class=\"thstyle\">最小包装</th>\n";
            s_Head += "<th class=\"thstyle\">使用方式</th>\n";
            s_Head += "<th class=\"thstyle\">损耗分类</th>\n";
            s_Head += "<th class=\"thstyle\">添加人员</th>\n";
            s_Head += "<th class=\"thstyle\">时间</th>\n";
            s_Head += "<th class=\"thstyle\">参数描述</th>\n";
            s_Head += "</tr>\n";
            s_Head += "</thead><tbody class=\"scrollContent\">";
            this.Lbl_Details.Text = s_Head+s_Details;

        }

    }

    protected void Btn_Excel_Click(object sender, EventArgs e)
    {
        Response.Buffer = true;
        Response.Clear();
        Response.ClearContent();
        Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode("产品明细.xls", System.Text.Encoding.UTF8).ToString());
        //Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");

        Response.ContentType = "application/ms-excel";
        Response.Write(this.Lbl_Details.Text);
        Response.Flush();
        Response.End();
    }
}
