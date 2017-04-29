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

public partial class Web_Report_Xs_List_CkList : BasePage
{
    public string s_Details="";
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string s_Sql = "Select Code,DirectInDateTime,HouseNo,ProductsName,ProductsPattern,DirectInAmount,DirectInUnitPrice,";
            s_Sql += " DirectInTotalNet,typeName,ProductsBarCode from v_store Where  HouseType='0'  ";
            string s_StartDate = Request.QueryString["StartDate"] == null ? "" : Request.QueryString["StartDate"].ToString();
            string s_EndDate = Request.QueryString["EndDate"] == null ? "" : Request.QueryString["EndDate"].ToString();
            string s_WaterType = Request.QueryString["WaterType"]==null?"":Request.QueryString["WaterType"].ToString();
            string s_HouseNoDataList = Request.QueryString["HouseNo"] == null ? "" : Request.QueryString["HouseNo"].ToString();
            string s_CustomerName = Request.QueryString["CustomerName"] == null ? "" : Request.QueryString["CustomerName"].ToString();
            string s_ProductsEdition = Request.QueryString["ProductsEdition"] == null ? "" : Request.QueryString["ProductsEdition"].ToString();
            string s_ProductsType = Request.QueryString["ProductsType"] == null ? "" : Request.QueryString["ProductsType"].ToString();

            
            string s_Style="";
            string s_Head = "";
            Decimal DTotalNum = 0, DTotalNet=0;
            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n<table border=\"1\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\"> \n";
            s_Head += "<tr >\n<th>序号</th>\n";
            s_Head += "<th>出库单号</th>\n";
            s_Head += "<th>出库日期</th>\n";
            s_Head += "<th>出入库类型</th>\n";
            s_Head += "<th>仓库</th>\n";
            s_Head += "<th>产品型号</th>\n";
            s_Head += "<th>数量</th>\n";
            s_Head += "<th>单价</th>\n";
            s_Head += "<th>金额</th>\n</tr></thead><tbody class=\"scrollContent\">";

            if(s_StartDate!="")
            {
                s_Sql += " and DirectInDateTime>='" + s_StartDate + "'";
            }
            if (s_EndDate != "")
            {
                s_Sql += " and DirectInDateTime<='" + s_EndDate + "'";
            }
            if (s_WaterType != "")
            {
                s_Sql += " and type='"+s_WaterType+"'";
            }
            if (s_HouseNoDataList != "")
            {
                s_Sql += " and HouseNo='" + s_HouseNoDataList + "'";
            }
            if (s_ProductsEdition!="")
            {
                s_Sql += " and ProductsEdition like '%" + s_ProductsEdition + "%' ";
            }

            if (s_ProductsType != "")
            {
                KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
                string s_SonID = Bll_ProductsDetails.GetSonIDs(s_ProductsType);
                s_SonID = s_SonID.Replace(",", "','");
                s_Sql += " and ProductsType in ('" + s_SonID + "') ";
            }
            s_Sql += "Order by DirectInDateTime";
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
                    s_Details += "<td align=left noWrap>" + Dtb_Table.Rows[i][0].ToString() + "</td>\n";
                    s_Details += "<td align=left noWrap>" + DateTime.Parse(Dtb_Table.Rows[i][1].ToString()).ToShortDateString() + "</td>\n";
                    s_Details += "<td align=left noWrap>" + Dtb_Table.Rows[i][8].ToString() + "</td>\n";
                    s_Details += "<td align=left noWrap>" + base.Base_GetHouseName(Dtb_Table.Rows[i][2].ToString()) + "</td>\n";
                    s_Details += "<td align=left noWrap>" + Dtb_Table.Rows[i][3].ToString() + "(" + Dtb_Table.Rows[i][4].ToString() + ")" + "</td>\n";
                    s_Details += "<td align=right noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i][5].ToString().ToString(),0) + "</td>\n";//数量
                    decimal d_Price = decimal.Parse(Dtb_Table.Rows[i][6].ToString() == "" ? "0" : Dtb_Table.Rows[i][6].ToString());
                        s_Details += "<td align=right noWrap>" + Dtb_Table.Rows[i][6].ToString().ToString() + "</td>\n";//数量
            
                decimal d_Net=0;
                    try{
                        d_Net = d_Price * decimal.Parse(Dtb_Table.Rows[i][5].ToString());
                    }
                    catch
                    {}
                        s_Details += "<td align=right noWrap>" + base.FormatNumber1(d_Net.ToString(),2) + "</td>\n";//数量
          
                    s_Details +=" </tr>";
                    try
                    {
                        DTotalNum += Decimal.Parse(Dtb_Table.Rows[i][5].ToString());
                        DTotalNet += d_Net;
                    }
                    catch
                    { }
                }
            }

            s_Details += " <tr >\n";
            s_Details += "<td  width='1%' align=left noWrap colspan=6>合计:" + (Dtb_Table.Rows.Count).ToString() + "</td>\n";
            s_Details += "<td align=right width='1%' noWrap>" + base.FormatNumber1(DTotalNum.ToString(),0) + "</td>\n";//数量
            s_Details += "<td align=right width='1%'noWrap>&nbsp;</td>\n";//单价
            s_Details += "<td align=right width='1%'  noWrap>" + DTotalNet.ToString() + "</td>\n";//金额
            s_Details += " </tr>";

            s_Details += "</tbody></table></div>";

            s_Details = s_Head + s_Details;
            this.Lbl_Time.Text = "日期:" + s_StartDate + " 到 " + s_EndDate;
            AdminloginMess Am = new AdminloginMess();
            this.Lbl_Person.Text = "制表人:" + Am.KNet_StaffName;

        }

    }
}
