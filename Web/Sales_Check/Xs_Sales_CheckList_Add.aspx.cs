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
using System.Text;
using System.Data.SqlClient;

using KNet.DBUtility;
using KNet.Common;


public partial class Web_Xs_Sales_CheckList_Add : BasePage
{
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
            else
            {
                this.Tbx_CheckCode.Text = base.GetNewID("Xs_Sales_CheckList", 0);
                this.Tbx_Stime.Text = DateTime.Now.ToShortDateString();
            }
        }

    }




    protected void Btn_Serch_Click(object sender, EventArgs e)
    {

    }
    protected void Btn_Save_Click(object sender, EventArgs e)
    {

    }
}
