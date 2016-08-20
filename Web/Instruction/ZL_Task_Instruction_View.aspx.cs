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

public partial class ZL_Task_Instruction_View : BasePage
{
    public string  s_OrderStyle = "", s_DetailsStyle = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            this.Lbl_Title.Text = "查看作业指导书";
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

        KNet.BLL.ZL_Task_Instruction bll = new KNet.BLL.ZL_Task_Instruction();
        KNet.Model.ZL_Task_Instruction model = bll.GetModel(s_ID);
        if (model != null)
        {
            this.Tbx_Code.Text = model.ZTI_Code;
            this.CommentList2.CommentFID = model.ZTI_Code;
            this.CommentList2.CommentType = "Instruction";
            this.Tbx_Title.Text = model.ZTI_Name;
            this.Tbx_STime.Text = model.ZTI_Stime.ToShortDateString();
            this.Ddl_Flow.Text = base.Base_GetFlowName( model.ZTI_Flow);
            this.Tbx_Remarks.Text = model.ZTI_Remarks;
            this.Tbx_SampleName.Text = base.Base_GetProductsEdition_Link(model.ZTI_ProductsBarCode);
        }
    }

}
