using System;
using System.Data;
using System.Data.SqlClient;
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

/// <summary>
/// 选择供应商采购报价
/// </summary>
public partial class SelectBill : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "产品选择";

        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
            else
            {
                this.DataShows();
            }
        }
    }

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        this.DataShows();
    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {

        string s_Sql = "Select * from v_BillDetails";
        s_Sql += " where 1=1 and CAP_IsPay=0 ";
        if (this.SeachKey.Text != "")
        {
            s_Sql = s_Sql + " and ( CAA_BillCode like '%" + this.SeachKey.Text + "%' or CAA_Details  like '%" + this.SeachKey.Text + "%' )";
        }

        s_Sql += " Order By CAA_EndDateTime ";

        this.BeginQuery(s_Sql);
        DataSet Dts_Table = this.QueryForDataSet();
        GridView_Bill.DataSource = Dts_Table;
        GridView_Bill.DataKeyNames = new string[] { "CAA_ID" };
        GridView_Bill.DataBind();

    }

    /// <summary>
    /// 确定选择
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        int i_Num = 0;
        string s_Return = "";
        for (int i = 0; i < GridView_Bill.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView_Bill.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked)
            {

                string s_ID = this.GridView_Bill.DataKeys[i].Value.ToString();
                /*
                string s_BillID = this.GridView_Bill.Rows[i].Cells[1].Text.ToString() ;
                string s_StartDate = this.GridView_Bill.Rows[i].Cells[2].Text.ToString();
                string s_EndDate = this.GridView_Bill.Rows[i].Cells[3].Text.ToString();
                string s_Money = this.GridView_Bill.Rows[i].Cells[4].Text.ToString();
                string s_Details = this.GridView_Bill.Rows[i].Cells[5].Text.ToString();
                string s_From = this.GridView_Bill.Rows[i].Cells[6].Text.ToString();*/
                s_Return += s_ID +"|";
                i_Num++;
            }

        }
        StringBuilder s = new StringBuilder();
        s.Append("<script language=javascript>" + "\n");
        s.Append("window.returnValue='" + s_Return + "';" + "\n");
        s.Append("window.close();" + "\n");
        s.Append("</script>");
        Type cstype = this.GetType();
        ClientScriptManager cs = Page.ClientScript;
        string csname = "ltype";
        if (!cs.IsStartupScriptRegistered(cstype, csname))
            cs.RegisterStartupScript(cstype, csname, s.ToString());
       
        
    }
    /// <summary>
    /// 搜索
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click1(object sender, EventArgs e)
    {
        this.DataShows();
    }


}
