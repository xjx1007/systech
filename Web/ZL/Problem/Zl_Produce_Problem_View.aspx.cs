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
            this.Lbl_Title.Text = "查看生产问题";
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
        KNet.BLL.Zl_Produce_Problem bll = new KNet.BLL.Zl_Produce_Problem();
        KNet.Model.Zl_Produce_Problem model = bll.GetModel(s_ID);
        if (model != null)
        {
                this.Tbx_ID.Text = model.ZPP_ID.ToString();
                this.Tbx_Code.Text = model.ZPP_Code.ToString();
                this.Tbx_Title.Text = model.ZPP_Title.ToString();
                this.Tbx_STime.Text = DateTime.Parse(model.ZPP_STime.ToString()).ToShortDateString();
                this.Tbx_HopeDate.Text = base.DateToString(model.ZPP_HopeDate.ToString());
                this.Tbx_ProdutsBarCode.Text = base.Base_GetProductsEdition_Link(model.ZPP_ProdutsBarCode);
            
                this.Ddl_ScStage.Text = base.Base_GetBasicCodeName("260", model.ZPP_ScStage);
                this.Ddl_Type.Text = base.Base_GetBasicCodeName("261", model.ZPP_Type);
                this.Ddl_Flow.Text = base.Base_GetFlowName(model.ZPP_Flow);
                this.Ddl_FlowStep.Text = base.Base_GetBasicCodeName("263", model.ZPP_FlowStep);
                this.Ddl_DutyPerson.Text = base.Base_GetUserName(model.ZPP_DutyPerson);
                this.Ddl_DutyDepart.Text = base.Base_GeDept(model.ZPP_DutyDepart);
                this.Tbx_Text.Text = model.ZPP_Text;
                this.CommentList2.CommentFID = this.Tbx_Code.Text;
                this.CommentList2.CommentType = "SCProblem";
                this.CommentList1.CommentFID = this.Tbx_Code.Text + "1";
                this.CommentList1.CommentType = "SCProblem1";

                this.Tbx_State.Text = model.ZPP_State.ToString();
                this.Tbx_Cause.Text = model.ZPP_Cause.ToString();
                this.Tbx_Temporary.Text = model.ZPP_Temporary;
                this.Tbx_DoneTime.Text = model.ZPP_DoneTime.ToShortDateString();
                this.Tbx_ClosedState.Text = model.ZPP_ClosedState.ToString();
                this.Ddl_ClosedType.Text = base.Base_GetBasicCodeName("262", model.ZPP_Type);
        }
    }

}
