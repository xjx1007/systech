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

public partial class Pb_Basic_Notice_View : BasePage
{
    public string  s_OrderStyle = "", s_DetailsStyle = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
           
            this.Lbl_Title.Text = "查看公告";
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
        KNet.BLL.PB_Knowledge_Manage bll = new KNet.BLL.PB_Knowledge_Manage();
        KNet.Model.PB_Knowledge_Manage model = bll.GetModel(s_ID);
        if (model != null)
        {

            this.Tbx_ProductsID.Text = base.Base_GetProductsEdition(model.PKM_ProductsBarCode);
            this.Tbx_CustomerValue.Text = base.Base_GetCustomerName(model.PKM_CustomerValue);
            this.Ddl_State.Text = base.Base_GetBasicCodeName("220", model.PKM_State);
            KNet.BLL.PB_Basic_KnowledgeClass bll_Class = new KNet.BLL.PB_Basic_KnowledgeClass();
            this.Tbx_TypeID.Text = bll_Class.GetTypeName(model.PKM_Type);
            this.Tbx_Problem.Text = model.PKM_Problem;
            this.Tbx_Remark.Text = KNetPage.KHtmlDiscode(model.PKM_Solution);
            this.Lbl_Person.Text = base.Base_GetUserName(model.PKM_Creator);
            this.Lbl_Stime.Text = model.PKM_CTime.ToString();
        }

    }


}
