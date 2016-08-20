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
using System.Text;

using KNet.DBUtility;
using KNet.Common;


public partial class Knet_AKNet_Documentation_Details : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }

            this.Get_Staff_ByID();
        }
    }
    /// <summary>
    /// 获取记录
    /// </summary>
    protected void Get_Staff_ByID()
    {
        if (Request["ID"] != null)
        {
            string MyID = Request.QueryString["ID"].ToString().Trim();
            try
            {
                KNet.BLL.AKNet_helps BLL = new KNet.BLL.AKNet_helps();
                KNet.Model.AKNet_helps model = BLL.GetModel(MyID);


                this.ADDKIg(MyID);

                this.Titles.Text = model.Titles;
                this.Addtimes.Text = model.Addtimes.ToString();
                this.coms.Text = model.coms;

            }
            catch 
            {
                Response.Write("<script language=javascript>alert('非法参数1！');window.close()</script>");
                Response.End();
            }

        }
        else
        {
            Response.Write("<script language=javascript>alert('非法参数2！');window.close()</script>");
            Response.End();
        }

    }

    /// <summary>
    /// 加点数
    /// </summary>
    /// <param name="ID"></param>
    protected void ADDKIg(string ID)
    {
        string DoSQL = "update AKNet_helps set kig=kig+1 where ID='" + ID + "'";
        DbHelperSQL.ExecuteSql(DoSQL);
    }



}
