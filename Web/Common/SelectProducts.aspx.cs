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
                string s_ProductsMainCategroy = Request.QueryString["ProductsMainCategroy"] == null ? "" : Request.QueryString["ProductsMainCategroy"].ToString();
                
                DataSet ds = KNet.Common.KNet_Static_BigClass.GetBigInfo();
                string BigNo, CateName;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    BigNo = ds.Tables[0].Rows[i]["BigNo"].ToString();
                    CateName = ds.Tables[0].Rows[i]["CateName"].ToString();

                }
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

        DataSet ds = bll.GetList(SqlWhere);
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "ID" };
        GridView1.DataBind();

    }

    /// <summary>
    /// 确定选择
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click(object sender, EventArgs e)
    {
        int i_Num = 0;
        string s_Return = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked)
            {
                string s_ProductsEdition = GridView1.Rows[i].Cells[4].Text;
                string s_ProductsPattern = GridView1.Rows[i].Cells[3].Text;
                string s_ProductsBarCode = GridView1.Rows[i].Cells[2].Text;
                string s_Code = "SP" + s_ProductsPattern + "V1" + "001";
                s_Return = s_ProductsEdition + "," + s_ProductsPattern + "," + s_ProductsBarCode + "," + s_Code;
                i_Num++;
            }

        }
        if (i_Num == 0)
        {
            Alert("您没有选择记录！");
        }
        else
        {
            if (i_Num > 1)
            {
                Alert("只能选择一条记录！");
            }
            else
            {
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
        }
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
