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

using KNet.DBUtility;
using KNet.Common;
using System.Data.SqlClient;

public partial class Table_View : BasePage
{
    public string  s_OrderStyle = "", s_DetailsStyle = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            this.Lbl_Title.Text = "查看表";
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            try
            {
                GetCoumn(s_ID);
            }
            catch
            { }
        }

    }

    private void GetCoumn(string s_Table)
    {
        try
        {
            string s_Sql1 = "select syscolumns.name as name,systypes.name as TypeName,syscolumns.length as Length,sys.extended_properties.Value as description from syscolumns  ";
            s_Sql1 += " left join sys.extended_properties on sys.extended_properties.major_id=syscolumns.ID and sys.extended_properties.minor_id=syscolumns.colorder";
            s_Sql1 += " left join systypes on systypes.xusertype=syscolumns.xusertype";
            s_Sql1 += " where syscolumns.id in (select id from sysobjects where name='" + s_Table + "') order by colid";
            this.BeginQuery(s_Sql1);
            DataTable Dtb_Table = (DataTable)this.QueryForDataTable();
            this.Lbl_Column.Text = "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"small\">\n";
            this.Lbl_Column.Text += "<tr>\n";
            this.Lbl_Column.Text += "<td class=\"ListHead\" nowrap>\n";
            this.Lbl_Column.Text += "<b>列名</b>\n";
            this.Lbl_Column.Text += "</td>\n";
            this.Lbl_Column.Text += "<td class=\"ListHead\" nowrap>\n";
            this.Lbl_Column.Text += "<b>描述</b>\n";
            this.Lbl_Column.Text += "</td>\n";
            this.Lbl_Column.Text += "</tr>\n";
            for (int i = 0; i < Dtb_Table.Rows.Count; i++)
            {
                this.Lbl_Column.Text += "<tr>\n";

                this.Lbl_Column.Text += "<td class=\"ListHeadDetails\" nowrap>\n";
                this.Lbl_Column.Text += "" + Dtb_Table.Rows[i]["name"].ToString() + "\n";
                this.Lbl_Column.Text += "</td>\n";
                this.Lbl_Column.Text += "<td class=\"ListHeadDetails\" nowrap>\n";
                this.Lbl_Column.Text += "" + Dtb_Table.Rows[i]["description"].ToString() + "&nbsp;\n";
                this.Lbl_Column.Text += "</td>\n";
                this.Lbl_Column.Text += "</tr>\n";
            }
            this.Lbl_Column.Text += "</table>\n";
        }
        catch { }

    }

}
