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

public partial class Web_Report_Xs_List_Price : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string s_Sql = "Select distinct b.ProductsBarCode,a.CustomerValue,contract_SalesUnitPrice ";
            s_Sql += " from KNet_Sales_ContractList a join KNet_Sales_ContractList_Details b on a.ContractNo=b.ContractNo Where 1=1 ";

            string s_CustomerName = Request.QueryString["CustomerName"].ToString();
            string s_ProductsEidition = Request.QueryString["ProductsEidition"].ToString();
            string s_Details="",s_Style="";
            string s_Head = "";
            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n<table border=\"1\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\"> \n";
            s_Head += "<tr >\n<th>序号</th>\n";

            s_Head += "<th>产品型号</th>\n";
            s_Head += "<th>客户名称</th>\n";
            s_Head += "<th>销售单价（含税）</th>\n</tr><tbody class=\"scrollContent\">";

            if (s_CustomerName != "")
            {
                s_Sql += " and a.CustomerValue in (select CustomerValue from KNet_Sales_ClientList where CustomerName like '%" + s_CustomerName + "%')";
            }
            if (s_ProductsEidition != "")
            {
                s_Sql += " and b.ProductsEidition like '%" + s_ProductsEidition + "%'";
            }
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
                    s_Details += "<td align=left noWrap>" + base.Base_GetProductsEdition_Link(Dtb_Table.Rows[i][0].ToString()) +  "</td>\n";
                    s_Details += "<td align=center noWrap>" + base.Base_GetCustomerName(Dtb_Table.Rows[i][1].ToString()) + "</td>\n";//
                    s_Details += "<td align=center noWrap>" + Dtb_Table.Rows[i][2].ToString() + "</td>\n";//单价
                    s_Details +=" </tr>";
                    //DTotalNum += Decimal.Parse(Dtb_Table.Rows[i][6].ToString());
                    //DTotalNet += Decimal.Parse(Dtb_Table.Rows[i][8].ToString());
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
            this.Lbl_Details.Text = s_Head+s_Details;
            AdminloginMess Am = new AdminloginMess();
            this.Lbl_Person.Text = "制表人:" + Am.KNet_StaffName;

        }

    }
}
