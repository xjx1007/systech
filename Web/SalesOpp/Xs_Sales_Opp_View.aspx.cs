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


public partial class Web_Xs_Sales_Opp_View : BasePage
{
    public string s_CustomerValue = "", s_Structure="";
    public string s_LinkMan = "";
    public string s_OppID = "", s_ID="";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.Lbl_Title.Text = "查看销售机会";
            AdminloginMess AM = new AdminloginMess();
            //销售机会列表
            if (AM.CheckLogin(this.Lbl_Title.Text) == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
             s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            if (s_ID != "")
            {
                ShowInfo();
            }
        }
    }
    private void ShowInfo()
    {
     
        KNet.BLL.Xs_Sales_Opp bll = new KNet.BLL.Xs_Sales_Opp();
        KNet.Model.Xs_Sales_Opp model = bll.GetModel(s_ID);
        try
        {
            this.Tbx_ID.Text = s_ID;
            this.Lbl_Name.Text = model.XSO_Name;
            this.CommentList1.CommentFID = s_ID;
            this.CommentList1.CommentType = 2;
            this.CommentList2.CommentFID = s_ID;
            this.CommentList2.CommentType = "SalesOpp";
            s_Structure = base.GetClient_StructureTree(model.XSO_CustomerValue);
            this.Lbl_PlanDealDate.Text = DateTime.Parse(model.XSO_PlanDealDate.ToString()).ToShortDateString();
            this.Lbl_CustomerValue.Text = base.Base_GetCustomerName_Link(model.XSO_CustomerValue);
            this.Lbl_LinkMan.Text = base.Base_GetLinkManValue(model.XSO_LinkMan, "XOL_Name");
            this.Lbl_DutyPerson.Text = base.Base_GetUserName(model.XSO_DutyPerson);
            this.Lbl_FDutyPerson.Text = base.Base_GetUserName(model.XSO_FDutyPerson);
            this.Lbl_SalesStep.Text = base.Base_GetBasicCodeName("118", model.XSO_SalesStep);
            this.Lbl_Type.Text = base.Base_GetBasicCodeName("121", model.XSO_Type);
            this.Lbl_Precent.Text = base.Base_GetBasicCodeName("154", model.XSO_Precent); 
            this.Lbl_NextPlan.Text = model.XSO_NextPlan;
            this.Lbl_Remarks.Text = model.XSO_Remarks;
            this.Lbl_Background.Text = model.XSO_Background;
            this.Lbl_Competitor.Text = model.XSO_Competitor;
            this.Lbl_History.Text = model.XSO_History;
            this.Lbl_Cretaor.Text = base.Base_GetUserName(model.XSO_Creator);
            this.Lbl_Mender.Text = base.Base_GetUserName(model.XSO_Mender);
            this.Lbl_CTime.Text = model.XSO_CTime.ToString();
            this.Lbl_MTime.Text = model.XSO_MTime.ToString();
            s_CustomerValue = model.XSO_CustomerValue;
            s_LinkMan = model.XSO_LinkMan;
            s_OppID = s_ID;
            string  SqlWhere = " XSC_CustomerValue='" + s_CustomerValue + "' Order by XSC_MTime desc ";
            KNet.BLL.Xs_Sales_Content bll_Content = new KNet.BLL.Xs_Sales_Content();
            DataSet ds_Content = bll_Content.GetList(SqlWhere);
            this.GridView_Contenct.DataSource = ds_Content;
            GridView_Contenct.DataBind();

            SqlWhere = " XSO_ID='"+model.XSO_ID+"' and XSO_Del='1' Order by XSO_CTime   desc";
            KNet.BLL.Xs_Sales_Opp bll_Opp = new KNet.BLL.Xs_Sales_Opp();
            DataSet ds = bll_Opp.GetList(SqlWhere);
            this.GridView_Opp.DataSource = ds;
            this.GridView_Opp.DataKeyNames = new string[] { "XSO_DID" };
            GridView_Opp.DataBind();
        }
        catch(Exception ex)
        {
            Alert(ex.Message);
        }
    }
}
