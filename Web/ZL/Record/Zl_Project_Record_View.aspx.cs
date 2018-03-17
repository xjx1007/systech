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

public partial class Zl_Project_Record_View : BasePage
{
    public string  s_OrderStyle = "", s_DetailsStyle = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();

            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            this.Lbl_Title.Text = "查看现场记录";
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

        KNet.BLL.Zl_Project_Record bll = new KNet.BLL.Zl_Project_Record();
        KNet.Model.Zl_Project_Record model = bll.GetModel(s_ID);
        if (model != null)
        {
            this.Tbx_Code.Text = model.ZPR_Code;
            this.CommentList2.CommentFID = model.ZPR_Code;
            this.CommentList2.CommentType = "XCJL";
            this.Tbx_Title.Text = model.ZPR_Title;
            this.Tbx_SampleName.Text = "<a href=\"../ProductsSample/Pb_Products_Sample_View.aspx?ID=" + model.ZPR_SampleID + "\" target=\"_blank\">" + model.ZPR_SampleName + "</a>";
            this.Tbx_STime.Text = model.ZPR_STime.ToShortDateString();
            this.Ddl_Flow.Text = base.Base_GetFlowName( model.ZPR_Flow);
            this.Ddl_State.Text = base.Base_GetBasicCodeName("251", model.ZPR_State.ToString());
            this.Ddl_Type.Text = base.Base_GetBasicCodeName("252", model.ZPR_Type.ToString());
            this.Tbx_Remarks.Text = model.ZPR_Remarks;
        }
    }
}
