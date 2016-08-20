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
public partial class Knet_Common_SelectProducts :BasePage
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
                string s_BigClass = Request.QueryString["BigClass"] == null ? "" : Request.QueryString["BigClass"].ToString();
                
                DataSet ds = KNet.Common.KNet_Static_BigClass.GetBigInfo();
                string BigNo, CateName;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    BigNo = ds.Tables[0].Rows[i]["BigNo"].ToString();
                    CateName = ds.Tables[0].Rows[i]["CateName"].ToString();
                    this.BigClass.Items.Add(new ListItem(CateName, BigNo));
                }
                this.SmallClass.Disabled = true;
                this.BigClass.SelectedValue = s_BigClass;
                this.DataShows();
            }
        }
    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.KNet_Sys_Products bll = new KNet.BLL.KNet_Sys_Products();
        string SqlWhere = " 1=1 ";

        if (this.SeachKey.Text != "")
        {
            SqlWhere = SqlWhere + " and ( ProductsName like '%" + this.SeachKey.Text + "%' or ProductsBarCode  like '%" + this.SeachKey.Text + "%' or ProductsPattern  like '%" + this.SeachKey.Text + "%' )";
        }

        if (this.BigClass.SelectedValue != "" && this.BigClass.SelectedValue != "0")
        {
            SqlWhere = SqlWhere + " and  ProductsMainCategory = '" + this.BigClass.SelectedValue + "' ";
        }

        if (this.SmallClass.Value != "" && this.SmallClass.Value != "0")
        {
            SqlWhere = SqlWhere + " and  ProductsSmallCategory = '" + this.SmallClass.Value + "' ";
        }

        DataSet ds = bll.GetList(SqlWhere);
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "ID" };
        GridView1.DataBind();

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

    public string GetReturn(string s_ID)
    {
        string s_Return = "";
        try
        {
            s_Return += "<a href=\"javascript:window.close();\" onclick='GetReturn(\"" + s_ID + "\",\"" + base.Base_GetProdutsName(s_ID) + "\");'>" + base.Base_GetProdutsName(s_ID) + "</a>";
        }
        catch { }
        return s_Return;
    }

}
