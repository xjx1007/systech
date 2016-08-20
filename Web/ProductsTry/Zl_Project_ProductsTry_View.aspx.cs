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

public partial class Zl_Project_ProductsTry_View : BasePage
{
    public string  s_OrderStyle = "", s_DetailsStyle = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            this.Lbl_Title.Text = "查看产品试制";
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

        KNet.BLL.Zl_Project_ProductsTry bll = new KNet.BLL.Zl_Project_ProductsTry();
        KNet.Model.Zl_Project_ProductsTry model = bll.GetModel(s_ID);
        if (model != null)
        {
            this.Tbx_Code.Text = model.ZPP_Code;
            this.CommentList2.CommentFID = model.ZPP_Code;
            this.CommentList2.CommentType = "CPSZ";
            this.Tbx_Title.Text = model.ZPP_Title;
            this.Tbx_SampleName.Text = "<a href=\"../ProductsSample/Pb_Products_Sample_View.aspx?ID=" + model.ZPP_SampleID + "\" target=\"_blank\">" + model.ZPP_SampleName + "</a>";
            this.Tbx_STime.Text = model.ZPP_STime.ToShortDateString();
            this.Ddl_Flow.Text = base.Base_GetFlowName( model.ZPP_Flow);
            this.Ddl_State.Text = base.Base_GetBasicCodeName("251", model.ZPP_State.ToString());
            this.Ddl_Type.Text = base.Base_GetBasicCodeName("252", model.ZPP_Type.ToString());
            this.Tbx_Remarks.Text = model.ZPP_Remarks;
        }
    }

}
