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

using KNet.DBUtility;
using KNet.Common;

public partial class Web_List_CustomerPayTime : BasePage
{
    public string s_Time = "";
    public string s_HouseName = "";
    public string s_Details = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            string s_CustomerName = Request.QueryString["CustomerName"] == null ? "" : Request.QueryString["CustomerName"].ToString();
            //原材料委外耗料
            string s_Sql = "Select distinct PayMent,CustomerName,a.CustomerValue ";
            s_Sql += " from Knet_Sales_ContractList a join KNet_Sales_ClientList b on a.CustomerValue=b.CustomerValue where PayMent<>''  ";

            if (s_CustomerName != "")
            {
                s_Sql += " and  b.CustomerName like '%" + s_CustomerName + "%'";
            }
            s_Sql += " Order by b.CustomerName Desc ";
            string s_Style = "";
            string s_Head = "";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        s_Style = "class='gg'";
                    }
                    else
                    {
                        s_Style = "class='rr'";
                    }
                    s_Details += " <tr " + s_Style + " onmouseover='setActiveBG(this)'>\n";
                    s_Details += "<td class='thstyleLeftDetails'align=center noWrap>" + (i + 1).ToString() + "</td>\n";

                    s_Details += "<td class='thstyleLeftDetails'align=left noWrap>" + Dtb_Table.Rows[i]["CustomerName"].ToString() + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails'align=center noWrap>" + base.Base_GetBasicCodeName("104", Dtb_Table.Rows[i]["PayMent"].ToString()) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails'align=center noWrap>" + GetLastTime(Dtb_Table.Rows[i]["CustomerValue"].ToString(), Dtb_Table.Rows[i]["PayMent"].ToString()) + "</td>\n";

                    s_Details += " </tr>";
                }
            }
            s_Details += "</tbody></table></td></tr>";
            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n";
            s_Head += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\"> \n";
            s_Head += "<tr>\n<th colspan=\"3\" class=\"MaterTitle\" style='height:14.25pt'>杭州士腾科技有限公司<br/>客户帐期</th></tr>\n";
            s_Head += "<th class=\"thstyle\" >项次</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>客户名称</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>帐期</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>最新日期</th>\n";
            s_Head += "</thead><tbody class=\"scrollContent\">";
            s_Details += "</div>";

            this.Lbl_Details.Text = s_Head + s_Details;
        }


    }
    public string GetLastTime(string s_CustomerValue, string s_Type)
    {
        string s_Sql = "";
        string s_Return = "&nbsp;";
        try
        {
            s_Sql = " Select top 1 * from KNET_Sales_ContractList where CustomerValue='" + s_CustomerValue + "' ";
            s_Sql += " and PayMent='" + s_Type + "' order by ContractDateTime desc ";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            if (Dtb_Result.Rows.Count > 0)
            {
                s_Return = DateToString(Dtb_Result.Rows[0]["ContractDateTime"].ToString());
            }
        }
        catch
        { }
        return s_Return;
    }
}
