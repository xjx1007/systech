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

public partial class IM_Project_Template_Add : BasePage
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
            string s_FID = Request.QueryString["FID"] == null ? "" : Request.QueryString["FID"].ToString();
            this.Tbx_FID.Text = s_FID;
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            this.Tbx_Type.Text = s_Type;

            this.Tbx_Code.Text = base.GetNewID("IM_Project_Manage", 0);
            
            if (s_ID != "")
            {
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制模版";
                }
                else
                {
                    this.Lbl_Title.Text = "修改模版";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }
            else
            {
                this.Lbl_Title.Text = "新增模版";
                this.Tbx_NID.Text = GetMainID();
            }
        }
    }
    /// <summary>
    /// 修改显示
    /// </summary>
    private void ShowInfo(string s_ID)
    {
        KNet.BLL.IM_Project_Template bll = new KNet.BLL.IM_Project_Template();
        KNet.Model.IM_Project_Template model = bll.GetModel(s_ID);
        if (model != null)
        {
            this.Tbx_Name.Text = model.IPT_Name;
            this.Tbx_Remarks.Text = model.IPT_Details;
        }
    }
    /// <summary>
    /// 赋值
    /// </summary>
    private bool SetValue(KNet.Model.IM_Project_Template model)
    {
        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text == "")
            {
                model.IPT_ID = GetMainID();
            }
            else
            {
                model.IPT_ID = this.Tbx_ID.Text;
            }
            model.IPT_Code = this.Tbx_FID.Text;
            model.IPT_Name = this.Tbx_Name.Text.ToString();

            model.IPT_Details = this.Tbx_Remarks.Text.ToString();
            model.IPT_Creator = AM.KNet_StaffNo;
            model.IPT_CTime = DateTime.Now;
            model.IPT_Del = 0;
            model.IPT_Mender = AM.KNet_StaffNo;
            model.IPT_MTime = DateTime.Now;
            return true;
        }
        catch
        {
            return false;
        }
    }
    /// <summary>
    /// 保存
    /// </summary>
    protected void Btn_Save_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.Model.IM_Project_Template model = new KNet.Model.IM_Project_Template();
        KNet.BLL.IM_Project_Template bll = new KNet.BLL.IM_Project_Template();
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
                    AM.Add_Logs("修改" + this.Tbx_ID.Text);

                    StringBuilder s = new StringBuilder();
                    s.Append("<script language=javascript>" + "\n");
                    s.Append("alert('修改成功');" + "\n");
                    s.Append("window.close();window.opener.location.reload();" + "\n");
                    s.Append("</script>");
                    Type cstype = this.GetType();
                    ClientScriptManager cs = Page.ClientScript;
                    string csname = "ltype";
                    if (!cs.IsStartupScriptRegistered(cstype, csname))
                        cs.RegisterStartupScript(cstype, csname, s.ToString());
                }
                else
                {
                    AM.Add_Logs("修改失败" + this.Tbx_ID.Text);
                    AlertAndRedirect("修改失败！", "IM_Project_Template_Add.aspx?ID=" + this.Tbx_ID.Text + "");
                }
            }
            catch { }
        }
        else
        {
            try
            {
                if (bll.Add(model))
                {
                    AM.Add_Logs("模版增加" + model.IPT_ID);

                    StringBuilder s = new StringBuilder();
                    s.Append("<script language=javascript>" + "\n");
                    s.Append("alert(\"添加成功!\");" + "\n");
                    s.Append("window.close();window.opener.location.reload();" + "\n");
                    s.Append("</script>");
                    Type cstype = this.GetType();
                    ClientScriptManager cs = Page.ClientScript;
                    string csname = "ltype";
                    if (!cs.IsStartupScriptRegistered(cstype, csname))
                        cs.RegisterStartupScript(cstype, csname, s.ToString());
                }
                else
                {
                    AM.Add_Logs("新增失败" + model.IPT_ID);
                    AlertAndRedirect("新增失败！", "IM_Project_Template_List.aspx");
                }
            }
            catch(Exception ex) { }
        }
    }
}
