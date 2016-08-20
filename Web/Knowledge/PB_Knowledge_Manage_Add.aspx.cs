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
using System.Text;

public partial class Pb_Basic_Knowledge_Add : BasePage
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
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            this.Tbx_ID.Text = s_ID;
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            this.Tbx_Type.Text = s_Type;
            base.Base_DropBasicCodeBind(this.Ddl_State, "220", false);

            if (s_ID != "")
            {
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制知识库";
                }
                else
                {
                    this.Lbl_Title.Text = "修改知识库";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }
            else
            {
                this.Lbl_Title.Text = "新增知识库";
            }
        }

    }
    private void ShowInfo(string s_ID)
    {
        KNet.BLL.PB_Knowledge_Manage bll = new KNet.BLL.PB_Knowledge_Manage();
        KNet.Model.PB_Knowledge_Manage model = bll.GetModel(s_ID);
        if (model != null)
        {

            this.Tbx_ProductsID.Text = model.PKM_ProductsBarCode;
            this.Tbx_ProductsName.Text = base.Base_GetProductsEdition(model.PKM_ProductsBarCode);
            this.Tbx_CustomerValue.Text = model.PKM_CustomerValue;
            this.Tbx_CustomerName.Text = base.Base_GetCustomerName(model.PKM_CustomerValue);
            this.Ddl_State.SelectedValue = model.PKM_State;
            KNet.BLL.PB_Basic_KnowledgeClass bll_Class = new KNet.BLL.PB_Basic_KnowledgeClass();

            this.Tbx_TypeID.Text = model.PKM_Type;
            this.Tbx_TypeName.Text = bll_Class.GetTypeName(model.PKM_Type);
             this.Tbx_Problem.Text = model.PKM_Problem;
             this.Tbx_Remark.Text = KNetPage.KHtmlDiscode(model.PKM_Solution);
        }

    }

    private bool SetValue(KNet.Model.PB_Knowledge_Manage model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text == "")
            {
                model.PKM_ID = GetMainID();
            }
            else
            {
                model.PKM_ID = this.Tbx_ID.Text;
            }
            model.PKM_ProductsBarCode = this.Tbx_ProductsID.Text;
            model.PKM_CustomerValue = this.Tbx_CustomerValue.Text;
            model.PKM_State = this.Ddl_State.SelectedValue;
            model.PKM_Type = this.Tbx_TypeID.Text;

            model.PKM_Problem = this.Tbx_Problem.Text;
            model.PKM_Solution = KNetPage.KHtmlEncode(this.Tbx_Remark.Text);
            model.PKM_Creator = AM.KNet_StaffNo;
            model.PKM_CTime = DateTime.Now;
            model.PKM_Mender = AM.KNet_StaffNo;
            model.PKM_MTime = DateTime.Now;
            return true;
        }
        catch
        {
            return false;
        }

    }
    protected void Btn_Send_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.Model.PB_Knowledge_Manage model = new KNet.Model.PB_Knowledge_Manage();
        KNet.BLL.PB_Knowledge_Manage bll = new KNet.BLL.PB_Knowledge_Manage();

        if (this.SetValue(model) == false)
        {
            Alert("系统错误！");
            return;
        }
        if (this.Tbx_ID.Text != "")//修改
        {
            try
            {
                if (bll.Update(model))
                {
                    AM.Add_Logs("知识库修改" + this.Tbx_ID.Text);
                    base.Base_SendMessage(model.PKM_ID, "知识库： <a href='Web/Notice/PB_Knowledge_Manage_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PKM_ID + "</a> ");
                    AlertAndRedirect("修改成功！", "PB_Knowledge_Manage_List.aspx");
                }
                else
                {
                    AM.Add_Logs("知识库修改失败" + this.Tbx_ID.Text);
                    AlertAndRedirect("修改失败！", "PB_Knowledge_Manage_Add.aspx?ID=" + this.Tbx_ID.Text + "");
                }
            }
            catch { }
        }
        else
        {
            try
            {
                bll.Add(model);
                base.Base_SendMessage(model.PKM_ID, "知识库： <a href='Web/Notice/PB_Knowledge_Manage_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PKM_ID + "</a> ");
                AM.Add_Logs("知识库增加" + this.Tbx_ID.Text);
                AlertAndRedirect("新增成功！", "PB_Knowledge_Manage_List.aspx");
            }
            catch { }
        }

    }
}
