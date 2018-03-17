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


public partial class Web_PB_Basic_Code_View : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.Lbl_Title.Text = "查看系统编码";
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin(this.Lbl_Title.Text) == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string s_Code = Request.QueryString["Code"] == null ? "" : Request.QueryString["Code"].ToString();
            if ((s_ID != "")&&(s_Code!=""))
            {
                ShowInfo(s_ID, s_Code);
            }
        }
       
    }

    private void ShowInfo(string s_ID,string s_Code)
    {
     
        KNet.BLL.PB_Basic_Code bll = new KNet.BLL.PB_Basic_Code();
        KNet.Model.PB_Basic_Code model = bll.GetModel(s_ID,s_Code);
        try
        {
            this.Tbx_ID.Text = s_ID;
            this.Lbl_ID.Text = model.PBC_ID;
            this.Lbl_Code.Text = model.PBC_Code;
            this.Lbl_Name.Text = model.PBC_Name;
            this.Lbl_Order.Text = model.PBC_Order.ToString();
            this.Lbl_Details.Text = model.PBC_Details;
            this.Lbl_CName.Text = model.PBC_CName;

            DataSet ds = bll.GetList(" PBC_ID='"+s_ID+"' Order by cast(PBC_Code as int)  ");
            this.MyGridView1.DataSource = ds;
            MyGridView1.DataKeyNames = new string[] { "PBC_ID" };
            MyGridView1.DataBind();
        }
        catch
        {}
    }

}
