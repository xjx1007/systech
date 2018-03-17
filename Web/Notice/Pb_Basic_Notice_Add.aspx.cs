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

public partial class Pb_Basic_Notice_Add : BasePage
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
            base.Base_DropBasicCodeBind(this.Ddl_Type, "219", false);

            if (s_ID != "")
            {
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制公告";
                }
                else
                {
                    this.Lbl_Title.Text = "修改公告";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }
            else
            {
                this.Lbl_Title.Text = "新增公告";
            }
        }

    }
    private void ShowInfo(string s_ID)
    {
        KNet.BLL.Pb_Basic_Notice bll = new KNet.BLL.Pb_Basic_Notice();
        KNet.Model.Pb_Basic_Notice model = bll.GetModel(s_ID);
        this.Tbx_Title.Text = model.PBN_Title;
        this.Ddl_Type.SelectedValue = model.PBN_Type;
        this.Tbx_ReceiveID.Text = model.PBN_ReceiveID;
        this.Tbx_Remark.Text = KNetPage.KHtmlDiscode(model.PBN_Details);
        try
        {
            this.StartDate.Text = DateTime.Parse(model.PBN_BeginTime.ToString()).ToShortDateString();
        }
        catch { }
        try
        {
            this.EndDate.Text = DateTime.Parse(model.PBN_EndTime.ToString()).ToShortDateString();
        }
        catch { }
    }

    private bool SetValue(KNet.Model.Pb_Basic_Notice model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text == "")
            {
                model.PBN_ID = GetMainID();
            }
            else
            {
                model.PBN_ID = this.Tbx_ID.Text;
            }
            model.PBN_Title = this.Tbx_Title.Text;
            model.PBN_Type = this.Ddl_Type.SelectedValue;
            model.PBN_ReceiveID = this.Tbx_ReceiveID.Text;
            model.PBN_Details = KNetPage.KHtmlEncode(this.Tbx_Remark.Text);
            model.PBN_Creator = AM.KNet_StaffNo;
            model.PBN_CTime = DateTime.Now;
            model.PBN_Mender = AM.KNet_StaffNo;
            model.PBN_MTime = DateTime.Now;
            try
            {
                model.PBN_BeginTime = DateTime.Parse(this.StartDate.Text);
            }
            catch { }
            try
            {
                model.PBN_EndTime = DateTime.Parse(this.EndDate.Text);
            }
            catch { }
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
        KNet.Model.Pb_Basic_Notice model = new KNet.Model.Pb_Basic_Notice();
        KNet.BLL.Pb_Basic_Notice bll = new KNet.BLL.Pb_Basic_Notice();

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
                    AM.Add_Logs("公告修改" + this.Tbx_ID.Text);
                    base.Base_SendMessage(model.PBN_ReceiveID, "公告： <a href='Web/Notice/Pb_Basic_Notice_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PBN_Title + "</a> ");
                    AlertAndRedirect("修改成功！", "Pb_Basic_Notice_List.aspx");
                }
                else
                {
                    AM.Add_Logs("公告修改失败" + this.Tbx_ID.Text);
                    AlertAndRedirect("修改失败！", "Pb_Basic_Notice_Add.aspx?ID=" + this.Tbx_ID.Text + "");
                }
            }
            catch { }
        }
        else
        {
            try
            {
                bll.Add(model);
                base.Base_SendMessage(model.PBN_ReceiveID, "公告： <a href='Web/Notice/Pb_Basic_Notice_View.aspx?ID=" + model.PBN_ID + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PBN_Title + "</a> ");
                AM.Add_Logs("公告增加" + model.PBN_ID);
                AlertAndRedirect("新增成功！", "Pb_Basic_Notice_List.aspx");
            }
            catch { }
        }
    }
    protected void Ddl_Type_TextChanged(object sender, EventArgs e)
    {
        if (this.Ddl_Type.SelectedValue != "")
        {
            string s_Sql="Select Top 1 * from Pb_Basic_Notice   ";
            this.BeginQuery(s_Sql);

        }
    }
}
