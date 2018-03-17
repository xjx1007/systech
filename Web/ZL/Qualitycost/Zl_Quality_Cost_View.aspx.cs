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

public partial class Zl_Quality_Cost_View : BasePage
{
    public string  s_OrderStyle = "", s_DetailsStyle = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();

            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            this.Lbl_Title.Text = "查看质量成本";
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

        KNet.BLL.Zl_Quality_Cost bll = new KNet.BLL.Zl_Quality_Cost();
        KNet.Model.Zl_Quality_Cost model = bll.GetModel(s_ID);
        if (model != null)
        {
            this.Tbx_Code.Text = model.ZQC_Code;
            this.Tbx_STime.Text = model.ZQC_STime.ToShortDateString();
            this.Ddl_Flow.Text = base.Base_GetFlowName( model.ZQC_Flow);
            this.Ddl_ProjectType.Text = base.Base_GetBasicCodeName("769", model.ZQC_ProjectType.ToString());
            this.Ddl_ContentType.Text = base.Base_GetBasicCodeName("770", model.ZQC_ContentType.ToString());
            this.Tbx_Remarks.Text = model.ZQC_Remarks;
            this.Tbx_Money.Text = model.ZQC_Money.ToString();
        }
    }
}
