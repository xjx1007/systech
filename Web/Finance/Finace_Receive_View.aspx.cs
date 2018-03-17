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
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Data.SqlClient;

using KNet.DBUtility;
using KNet.Common;


/// <summary>
/// 采购管理-----采购单 管理
/// </summary>
public partial class Finace_Receive_View : BasePage
{
    public string s_DivStyle = "";
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin() == false)
            {
                BasePage.AlertAndRedirect("您未登陆系统或已超过，请重新登陆系统!", "Default.aspx");
            }
            else
            {
                //非注册用户 （采购管理  20）
                if (AM.BsysGo() == false)
                {
                    AM.Error_BsysCode("Knet_Procure_OrdersList", 20);
                }
                DateTime datetime = DateTime.Now;
                this.StartDate.Text = datetime.AddDays(1 - datetime.Day).ToShortDateString();
                this.EndDate.Text = datetime.ToShortDateString();
                this.DataShows();
            }
        }

    }

    public void btnBasicSearch_Click(object sender, EventArgs e)
    {
        this.DataShows();
    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        string s_Sql = "Select * from KNet_WareHouse_DirectOutList a join KNet_WareHouse_DirectOutList_Details b on a.DirectOutNo=b.DirectOutNo ";
        s_Sql += " where 1=1 ";
        if (this.StartDate.Text != "")
        {
            s_Sql += " and DirectOutDateTime>='" + StartDate.Text + "'";
        }
        if (this.EndDate.Text != "")
        {
            s_Sql += " and DirectOutDateTime<='" + EndDate.Text + "'";
        }
        if (Tbx_CustomName.Text != "")
        {
            s_Sql += " and KWD_Custmoer in (Select CustomerValue From KNet_Sales_ClientList where CustomerName Like '%" + Tbx_CustomName.Text + "%')";
        }
        if (this.Tbx_ProductsName.Text != "")
        {
            s_Sql += " and ProductsBarCode in (Select ProductsBarCode From KNet_Sys_Products where ProductsName Like '%" + Tbx_ProductsName.Text + "%')";

        }
        if (this.Tbx_Pattern.Text != "")
        {
            s_Sql += " and ProductsBarCode in (Select ProductsBarCode From KNet_Sys_Products where ProductsEdition Like '%" + Tbx_Pattern.Text + "%')";

        }
        s_Sql += " order by DirectOutDateTime";
        this.BeginQuery(s_Sql);
        this.QueryForDataSet();
        DataSet ds = Dts_Result;

        GridView1.DataSource = ds.Tables[0];
        GridView1.DataKeyNames = new string[] { "DirectOutNo" };
        GridView1.DataBind();

    }

}
    