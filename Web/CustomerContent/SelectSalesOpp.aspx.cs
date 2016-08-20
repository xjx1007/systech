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
/// 选择销售客户
/// </summary>
public partial class Knet_Common_SelectSalesOpp : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "选择销售机会";
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
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.Xs_Sales_Opp bll = new KNet.BLL.Xs_Sales_Opp();
        string KSeachKey = null;

        string SqlWhere = " XSO_Del='0' ";
        if (this.SeachKey.Text != "")
        {
            KSeachKey = this.SeachKey.Text;

            SqlWhere = SqlWhere + " and ( XSO_CustomerValue in(Select CustomerValue from KNET_Sales_ClientList where CustomerName like '%" + KSeachKey + "%')  or XSO_Name  like '%" + KSeachKey + "%')";
        }

        SqlWhere = SqlWhere + " order by XSO_CTime desc";
        DataSet ds = bll.GetList(SqlWhere);

        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "XSO_ID" };
        GridView1.DataBind();
    }
   

    public string GetLink(string s_ID,string s_Name)
    {
        string s_Return = "";
        try
        {

                     s_Return += "<a href=\"javascript:window.close();\" onclick='set_return_Opp(\"" + s_ID + "\", \"" + s_Name + "\");'>" + s_Name + "</a>";

        }
        catch
        {
            s_Return = "-";
 
        }
        return s_Return;
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
