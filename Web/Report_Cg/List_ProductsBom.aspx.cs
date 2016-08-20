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

public partial class Web_Report_Xs_List_ProductsBom : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string s_Sql = "Select *";
            s_Sql += "  from Knet_Sys_Products Where 1=1  ";
            string s_ProductsName = Request.QueryString["ProductsName"] == null ? "" : Request.QueryString["ProductsName"].ToString();
            string s_ProductsPattern = Request.QueryString["ProductsPattern"] == null ? "" : Request.QueryString["ProductsPattern"].ToString();
            string s_ProductsEdition = Request.QueryString["ProductsEdition"] == null ? "" : Request.QueryString["ProductsEdition"].ToString();
            string s_ProductsMainCategory = Request.QueryString["ProductsMainCategory"] == null ? "" : Request.QueryString["ProductsMainCategory"].ToString();

            
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
                    s_Details += "<td align=left noWrap>" + (i+1).ToString()+ "</td>\n";
                    s_Details += "<td align=left noWrap>" + Dtb_Table.Rows[i]["ProductsName"].ToString() + "</td>\n";
                    s_Details += "<td align=left noWrap>" + Dtb_Table.Rows[i]["ProductsPattern"].ToString() + "</td>\n";
                    s_Details += "<td align=left noWrap>" + Dtb_Table.Rows[i]["ProductsEdition"].ToString() + "</td>\n";
                    s_Details += "<td align=left noWrap>" + base.Base_GetBigCateNane(Dtb_Table.Rows[i]["ProductsMainCategory"].ToString()) + "</td>\n";
                    s_Details += "<td align=left noWrap>" + base.Base_GetBasicCodeName(Dtb_Table.Rows[i]["ProductsType"].ToString(),"101") + "</td>\n";

                    s_Details += "<td align=left noWrap>" + base.Base_GetUnitsName(Dtb_Table.Rows[i]["ProductsUnits"].ToString()) + "</td>\n";
                    s_Details += "<td align=left noWrap>" + Dtb_Table.Rows[i]["ProductsBarCode"].ToString() + "</td>\n";

                    s_Details += "<td align=left noWrap>" + base.Base_GetUserName(Dtb_Table.Rows[i]["ProductsAddMan"].ToString()) + "</td>\n";
                    s_Details += "<td align=left noWrap>" + DateTime.Parse(Dtb_Table.Rows[i]["ProductsAddTime"].ToString()).ToShortDateString() + "</td>\n";
                    s_Details += "<td align=left >" + Dtb_Table.Rows[i]["ProductsDescription"].ToString() + "</td>\n";
                    


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
            s_Head += "<th class=\"thstyle\">芯片</th>\n";
            s_Head += "<th class=\"thstyle\">导电胶</th>\n";
            s_Head += "<th class=\"thstyle\">塑壳</th>\n";
            s_Head += "<th class=\"thstyle\">PCB板</th>\n";
            s_Head += "<th class=\"thstyle\">发射管</th>\n";
            s_Head += "<th class=\"thstyle\">存储芯片</th>\n";
            s_Head += "<th class=\"thstyle\">晶振</th>\n";
            s_Head += "</tr>\n";
            s_Head += "</thead><tbody class=\"scrollContent\">";
            this.Lbl_Details.Text = s_Head+s_Details;

        }

    }
}
