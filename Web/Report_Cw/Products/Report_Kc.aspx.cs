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

public partial class Web_Report_Xs_Report_Kc : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            AdminloginMess AM = new AdminloginMess();
            string s_Sql = "select * from KNet_Sys_WareHouse ";
            if (s_Type != "")
            {
                s_Sql += " where KSW_Type='" + s_Type + "' and HouseYN=1 ";
            }
            s_Sql += " Order by KSW_Type,HouseName ";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            string s_Return = "";
            if (this.Dtb_Result.Rows.Count > 0)
            {
                for (int i = 0; i < this.Dtb_Result.Rows.Count; i++)
                {
                    s_Return += "<input type=\"checkbox\" id=\"Chk_HouseNo\"  Name=\"Chk_HouseNo\" value=\"" + Dtb_Result.Rows[i]["HouseNo"].ToString() + "\" checked />" + Dtb_Result.Rows[i]["HouseName"].ToString();

                    if ((i % 6 == 0)&&(i!=0))
                    {
                        s_Return += "<br/>";

                    }
                }
            }
            //base.Base_DropWareHouseBind(this.HouseNo, AM.MyDoSqlWith_Do);
            DateTime datetime = DateTime.Now;
           // this.StartDate.Text = datetime.AddDays(1 - datetime.Day).ToShortDateString();
           // this.EndDate.Text = datetime.ToShortDateString();
        }
    }
}
    