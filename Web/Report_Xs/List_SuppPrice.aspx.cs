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

public partial class Web_List_SuppPrice : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string s_Sql = "Select a.SuppNo,a.ProductsName,a.ProductsPattern,a.ProductsMainCategory,a.ProductsUnits,a.ProcureUnitPrice,a.HandPrice,a.ProcureUpdateDateTime";
            s_Sql += " from Knet_Procure_SuppliersPrice a Where 1=1   ";

            string s_SuppName = Request.QueryString["SuppName"].ToString();
            string s_ProductsName = Request.QueryString["ProductsName"].ToString();
            string s_BigClass = Request.QueryString["BigClass"].ToString();
            string s_SmallClass = Request.QueryString["SmallClass"].ToString();
            string s_Details="",s_Style="";
            string s_Head = "";
            Decimal DTotalNum = 0, DTotalNet=0;
            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n<table border=\"1\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\"> \n";
            s_Head += "<tr>\n<th>序号</th>\n";
            s_Head += "<th>供应商名称</th>\n";
            s_Head += "<th>产品名称</th>\n";
            s_Head += "<th>产品型号</th>\n";
            s_Head += "<th>大类名称</th>\n";
            s_Head += "<th>单位</th>\n";
            s_Head += "<th>单价</th>\n";
            s_Head += "<th>加工费</th>\n";
            s_Head += "<th>操作时间</th>\n";
            s_Head += "</thead><tbody class=\"scrollContent\">";


            if (s_SuppName != "")
            {
                s_Sql += " and a.SuppNo in (select SuppNo from Knet_Procure_Suppliers where SuppName like '%" + s_SuppName + "%')";
            }
            if (s_ProductsName != "")
            {
                s_Sql += " and (a.ProductsName like '%" + s_ProductsName + "%' or a.ProductsPattern like '%" + s_ProductsName + "%')";
            }
            if (s_BigClass != "0")
            {
                s_Sql += " and a.ProductsMainCategory ='" + s_BigClass + "'  ";
            }
            if (s_SmallClass != "0")
            {
                s_Sql += " and a.ProductsSmallCategory ='" + s_SmallClass + "'  ";
            }
            s_Sql += "Order by a.ProcureUpdateDateTime";
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
                    s_Details += "<td align=left noWrap>" + base.Base_GetSupplierName(Dtb_Table.Rows[i][0].ToString()) + "</td>\n";
                    s_Details += "<td align=left noWrap>" + Dtb_Table.Rows[i][1].ToString() + "</td>\n";
                    s_Details += "<td align=left noWrap>" + Dtb_Table.Rows[i][2].ToString() + "</td>\n";
                    s_Details += "<td align=left noWrap>" + base.Base_GetBigCateNane(Dtb_Table.Rows[i][3].ToString()) + "</td>\n";
                    s_Details += "<td align=left noWrap>" + base.Base_GetUnitsName(Dtb_Table.Rows[i][4].ToString()) + "</td>\n";
                    s_Details += "<td align=right noWrap>" + Dtb_Table.Rows[i][5].ToString() + "</td>\n";//单价
                    s_Details += "<td align=right noWrap>" + Dtb_Table.Rows[i][6].ToString()     + "</td>\n";//加工费
                    s_Details += "<td align=left noWrap>" + Dtb_Table.Rows[i][7].ToString() + "</td>\n";
                    s_Details +=" </tr>";
                }
            }

            s_Details += "</tbody></table></div>";

            this.Lbl_Details.Text = s_Head+s_Details;
            this.Lbl_Time.Text = "";
            AdminloginMess Am = new AdminloginMess();
            this.Lbl_Person.Text = "制表人:" + Am.KNet_StaffName;

        }

    }
}
