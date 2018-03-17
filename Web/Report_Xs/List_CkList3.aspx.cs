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

public partial class List_CkList3 : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            AdminloginMess Am = new AdminloginMess();
            string s_Sql = "Select a.DirectOutNo,a.KWD_CWOutTime,a.HouseNo,a.KWD_Custmoer,b.ProductsName,b.ProductsPattern,b.DirectOutAmount,b.KWD_SalesUnitPrice,";
            s_Sql += " b.DirectOutAmount*b.KWD_SalesUnitPrice ,a.DirectOutStaffNo,a.DirectOutCheckStaffNo,b.ProductsBarCode,b.ID,isnull(b.KWD_BNumber,0)+isnull(b.DirectOutAmount,0) as totalNum,KWD_DPrintNums from KNet_WareHouse_DirectOutList a ";
            s_Sql += " join KNet_WareHouse_DirectOutList_Details b on a.DirectOutNo=b.DirectOutNo ";
            s_Sql += " left join KNet_Sys_WareHouse c on c.HouseNo=a.HouseNo join KNet_Sys_Products d on d.ProductsBarCode=b.ProductsBarCode ";
            s_Sql += "Where 1=1 and Kwd_Type='101' and (KWD_ShipNo in( select OutWareNo from KNet_Sales_OutWareList where KSO_Type='1') or  KWD_ShipNo='') ";
            string s_StartDate = Request.QueryString["StartDate"] == null ? "" : Request.QueryString["StartDate"].ToString();
            string s_EndDate = Request.QueryString["EndDate"] == null ? "" : Request.QueryString["EndDate"].ToString();
            string s_CustomerName = Request.QueryString["CustomerName"] == null ? "" : Request.QueryString["CustomerName"].ToString();
            string s_ProductsType = Request.QueryString["ProductsType"] == null ? "" : Request.QueryString["ProductsType"].ToString();
            string s_CustomerTypes = Request.QueryString["CustomerTypes"] == null ? "" : Request.QueryString["CustomerTypes"].ToString();
            string s_ProductsEdition = Request.QueryString["ProductsEidition"] == null ? "" : Request.QueryString["ProductsEidition"].ToString();
            string s_State = Request.QueryString["State"] == null ? "" : Request.QueryString["State"].ToString();
            
            string s_Ck = Request.QueryString["Ck"] == null ? "" : Request.QueryString["Ck"].ToString();
     
            string s_Details="",s_Style="";
            string s_Head = "";
            Decimal DTotalNum = 0;
            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n";
            s_Head += "<thead class=\"fixedHeader\"> \n";
            s_Head += "<tr>\n<th colspan=\"13\" class=\"MaterTitle\" style='height:14.25pt'>杭州士腾科技有限公司<br/>成品调拨明细</th></tr>\n";
            s_Head += "<tr>\n<th colspan=\"7\" class=\"thstyleleft\"  >" + "制表人:" + Am.KNet_StaffName + "</th><th colspan=\"6\" class=\"thstyleRight\" >" + "日期:" + s_StartDate + " 到 " + s_EndDate + "</th></tr>\n";
            s_Head += "<tr class=\"thstyle\">\n<th>序号</th>\n";
            s_Head += "<th class=\"thstyle\">调拨单号</th>\n";
            s_Head += "<th class=\"thstyle\">调拨日期</th>\n";
            s_Head += "<th class=\"thstyle\">仓库</th>\n";
            s_Head += "<th class=\"thstyle\">客户名称</th>\n";
            s_Head += "<th class=\"thstyle\">产品名称</th>\n";
            s_Head += "<th class=\"thstyle\">产品型号</th>\n";
            s_Head += "<th class=\"thstyle\">产品版本</th>\n";
            s_Head += "<th class=\"thstyle\">数量</th>\n";
            s_Head += "<th class=\"thstyle\">制单人</th>\n";
            s_Head += "<th class=\"thstyle\">审核</th>\n";
            s_Head += "</tr>\n";
            s_Head += "</thead><tbody class=\"scrollContent\">";
            if(s_StartDate!="")
            {
                s_Sql += " and a.KWD_CWOutTime>='" + s_StartDate + "'";
            }
            if (s_EndDate != "")
            {
                s_Sql += " and a.KWD_CWOutTime<='" + s_EndDate + "'";
            }
            if (s_State != "")
            {
                s_Sql += " and  a.DirectOutCheckYN='" + s_State + "' ";
            }
            if (s_CustomerName != "")
            {
                s_Sql += " and a.KWD_Custmoer in (select CustomerValue from KNet_Sales_ClientList where CustomerName like '%" + s_CustomerName + "%')";
            }
            if (s_ProductsEdition != "")
            {
                s_Sql += " and d.ProductsEdition like '%" + s_ProductsEdition + "%' ";
            }
            if(s_ProductsType!="")
            {
                    KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
                    string s_SonID = Bll_ProductsDetails.GetSonIDs(s_ProductsType);
                    s_SonID = s_SonID.Replace(",", "','");
                    s_Sql += " and ProductsType in ('" + s_SonID + "') ";
            }
            if(s_CustomerTypes!="")
            {
                s_Sql += " and a.KWD_Custmoer in (select CustomerValue from KNet_Sales_ClientList where CustomerTypes='" + s_CustomerTypes + "' ) ";
            }
            if (s_Ck != "")
            {
                s_Sql += " and c.HouseName like '%"+s_Ck+"%' ";
            }
            s_Sql += "Order by a.KWD_CWOutTime,KWD_DirectOutNo ";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table=this.Dtb_Result;

            string s_ID = "";
            if(Dtb_Table.Rows.Count>0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
                    s_ID += Dtb_Table.Rows[i][0].ToString()+",";

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
                    s_Details += "<td align=left  class='thstyleLeftDetails' noWrap>" + Dtb_Table.Rows[i][0].ToString() + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails'  noWrap>" + DateTime.Parse(Dtb_Table.Rows[i][1].ToString()).ToShortDateString() + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails'  noWrap>" + base.Base_GetHouseName(Dtb_Table.Rows[i][2].ToString()) + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails'  noWrap>" + base.Base_GetCustomerName(Dtb_Table.Rows[i][3].ToString()) + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails'  noWrap>" + base.Base_GetProdutsName(Dtb_Table.Rows[i][11].ToString()) + "</td>\n";
                    s_Details += "<td align=left  class='thstyleLeftDetails' noWrap>" + base.Base_GetProductsPattern(Dtb_Table.Rows[i][11].ToString()) + "</td>\n";
                    s_Details += "<td align=left  class='thstyleLeftDetails' noWrap>" + base.Base_GetProductsEdition(Dtb_Table.Rows[i][11].ToString()) + "</td>\n";

                    s_Details += "<td align=right class='thstyleLeftDetails'  noWrap>" + Dtb_Table.Rows[i]["totalNum"].ToString() + "</td>\n";//数量
                    
                    s_Details += "<td align=center class='thstyleLeftDetails'  noWrap>&nbsp;" + base.Base_GetUserName(Dtb_Table.Rows[i][9].ToString()) + "</td>\n";//制单人
                    s_Details += "<td align=center  class='thstyleLeftDetails' noWrap>&nbsp;" + base.Base_GetUserName(Dtb_Table.Rows[i][10].ToString()) + "</td>\n";//制单人
                    s_Details +=" </tr>";
                    DTotalNum += Decimal.Parse(Dtb_Table.Rows[i]["totalNum"].ToString());
                }
            }
            if (s_ID != "")
            {
                this.Tbx_ID.Text = s_ID.Substring(0,s_ID.Length-1);
            }
            s_Details += " <tr >\n";
            s_Details += "<td  class='thstyleLeftDetails' align=left noWrap colspan=8>合计:" + (Dtb_Table.Rows.Count).ToString() + "</td>\n";
            s_Details += "<td align=right class='thstyleLeftDetails' noWrap>" + DTotalNum.ToString() + "</td>\n";//数量
            s_Details += "<td align=right class='thstyleLeftDetails' colspan=4 noWrap>&nbsp;</td>\n";//单价
            s_Details += " </tr>";
            s_Details += "</tbody></table></div>";

            this.Lbl_Details.Text = s_Head+s_Details;

        }

    }
}
