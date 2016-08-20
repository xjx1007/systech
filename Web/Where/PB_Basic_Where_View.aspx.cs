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

public partial class PB_Basic_Where_View : BasePage
{
    public string  s_OrderStyle = "", s_DetailsStyle = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            this.Lbl_Title.Text = "查看菜单";
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            try
            {
                ShowInfo(s_ID);
            }
            catch
            { }
        }

    }

    private void ShowInfo(string s_ID)
    {

        KNet.BLL.PB_Basic_Where bll = new KNet.BLL.PB_Basic_Where();
        KNet.Model.PB_Basic_Where model = bll.GetModel(s_ID);
        if (model != null)
        {
            this.Tbx_Name.Text = model.PBW_Name.ToString();
            this.Tbx_Table.Text = model.PBW_Table.ToString();
            this.Tbx_Sql.Text = model.PBW_Sql.ToString();
            this.Ddl_Type.SelectedValue = model.PBW_Type.ToString();
            this.Tbx_Order.Text = model.PBW_Order.ToString();
            this.Tbx_Cloumn.Text = model.PBW_Cloumn.ToString();
            this.Tbx_FromTable.Text = model.PBW_FromTable.ToString();
            this.Tbx_FromValue.Text = model.PBW_FromValue.ToString();
            this.Tbx_FromName.Text = model.PBW_FromName.ToString();
            this.Ddl_InputType.Text = model.PBW_InputType.ToString();
            this.Tbx_FromWhere.Text = model.PBW_FromWhere.ToString();
        }
    }

}
