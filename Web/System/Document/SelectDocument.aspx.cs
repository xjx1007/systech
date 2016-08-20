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
public partial class Knet_Common_SelectDocument : BasePage
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        KNet.DBUtility.AdminloginMess AMLanguage = new KNet.DBUtility.AdminloginMess();
        if (AMLanguage.KNet_Soft_StaffLanguage == 2)
        {
            // 1、默认为简体转繁体，编码为utf-8
            Response.Filter = new LU.Web.ChineseConvertor(Response.Filter);
        }
        else if (AMLanguage.KNet_Soft_StaffLanguage == 1)
        {
            // 2、繁体简体转，编码为utf-8
            Response.Filter = new LU.Web.ChineseConvertor(Response.Filter, LU.Web.ChineseConvertor.CCDirection.T2S);
        }
        else
        { }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(Knet_Common_SelectDocument));
        this.Page.Title = "选择文档";
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
        KNet.BLL.PB_Basic_Document bll = new KNet.BLL.PB_Basic_Document();
        string KSeachKey = null;

        string SqlWhere = " PBM_Del='0' ";
        if (this.SeachKey.Text != "")
        {
            KSeachKey = this.SeachKey.Text;

            SqlWhere = SqlWhere + " and ( PBM_Name like '%" + KSeachKey + "%' or PBM_Visio  like '%" + KSeachKey + "%' )";
        }

        SqlWhere = SqlWhere + " order by PBM_CTime desc";
        DataSet ds = bll.GetList(SqlWhere);

        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "PBM_Code" };
        GridView1.DataBind();
    }


    public string GetLink(string s_PBM_Code, string s_PBM_Name,string s_PBM_Visio)
    {
        string s_Return = "";
        try
        {
            s_Return += "<a href=\"javascript:window.close();\" onclick='set_return(\"" + s_PBM_Code + "\", \"" + s_PBM_Name + "_" + s_PBM_Visio + "\");'>" + s_PBM_Name + "</a>";
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
