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

public partial class IM_Project_Manage_Details_Logs_Add : BasePage
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
            string s_GID = Request.QueryString["GID"] == null ? "" : Request.QueryString["GID"].ToString();
            KNet.BLL.IM_Project_Manage_Details Bll_Details = new KNet.BLL.IM_Project_Manage_Details();

            Bll_Details.BindDrop(this.Ddl_FIDDetials, s_FID, "0");


            Bll_Details.BindDrop(this.Ddl_Name, s_FID, "0");
            base.Base_DropBasicCodeBind(this.Ddl_State, "226");
            this.Ddl_State.SelectedValue = "2";

            base.Base_DropBasicCodeBind(this.Ddl_Import, "774", false);
            base.Base_DropBasicCodeBind(this.Ddl_LogsPrecet, "777", false);
            if (s_GID != "")
            {
                KNet.Model.IM_Project_Manage_Details Model_Details = Bll_Details.GetModel(s_GID);
                if (Model_Details != null)
                {
                    //this.Tbx_Level.Text = Model_Details.IPML_Level.ToString();
                }
            }
            this.Tbx_Code.Text = base.GetNewID("IM_Project_Manage", 0);

            if (s_ID != "")
            {
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制日志";
                }
                else
                {
                    this.Lbl_Title.Text = "修改日志";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }
            else
            {
                this.Lbl_Title.Text = "新增日志";
                this.Tbx_NID.Text = GetMainID();
            }
        }
    }
    /// <summary>
    /// 修改显示
    /// </summary>
    private void ShowInfo(string s_ID)
    {
        KNet.BLL.IM_Project_Manage_Details bll = new KNet.BLL.IM_Project_Manage_Details();
        KNet.Model.IM_Project_Manage_Details model = bll.GetModel(s_ID);
        if (model != null)
        {
            //this.Tbx_ID.Text = model.IPMD_ID.ToString();
            this.Tbx_FID.Text = model.IPMD_IPMID.ToString();
            this.Tbx_Days.Text = model.IPMD_Days.ToString();
            this.Tbx_FloatingDays.Text = model.IPMD_FloatingDays.ToString();
            this.Tbx_ReceiveID.Text = model.IPMD_Executor.ToString();
            this.Tbx_Remarks.Text = model.IPMD_Remarks.ToString();
            this.Tbx_ReceiveID.Text = model.IPMD_Executor;
            this.Tbx_ReceiveName.Text = base.Base_GetUserNames(model.IPMD_Executor);
            this.Tbx_Level.Text = model.IPMD_Level.ToString();

            this.Ddl_State.SelectedValue = model.IPMD_State.ToString();
            this.Tbx_Stime.Text = model.IPMD_AtLatestBeginTime.ToShortDateString();
            this.Tbx_EndTime.Text = model.IPMD_AtLatestEndTime.ToShortDateString();
            this.Ddl_LogsPrecet.SelectedValue = Convert.ToString(model.IPMD_Precent * 100);
            this.Tbx_OldPrecent.Text = Convert.ToString(model.IPMD_Precent * 100);
        }
    }
    /// <summary>
    /// 赋值
    /// </summary>
    private bool SetValue(KNet.Model.IM_Project_Manage_Details_Logs model)
    {
        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text == "")
            {
                model.IPML_ID = GetMainID();
            }
            else
            {
                model.IPML_ID = this.Tbx_ID.Text;
            }
            model.IPML_FID = this.Ddl_Name.SelectedValue;
            try
            {
                model.IPML_ThisUseDays = int.Parse(this.Tbx_UseDays.Text);
            }
            catch
            {
                model.IPML_ThisUseDays = 0;
            }
            try
            {
                model.IPML_Precent = int.Parse(this.Ddl_LogsPrecet.SelectedValue);
            }
            catch
            { }
            model.IPML_Details = this.Tbx_LogRemarks.Text;
            model.IPML_Creator = AM.KNet_StaffNo;
            model.IPML_CTime = DateTime.Now;
            model.IPML_Del = 0;
            model.IPML_OldDetails = "原来进度为：" + this.Tbx_OldPrecent.Text+"% 修改为:" +this.Ddl_LogsPrecet.SelectedValue+"%";
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
        KNet.Model.IM_Project_Manage_Details_Logs model = new KNet.Model.IM_Project_Manage_Details_Logs();
        KNet.BLL.IM_Project_Manage_Details_Logs bll = new KNet.BLL.IM_Project_Manage_Details_Logs();
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
                    AlertAndRedirect("修改失败！", "IM_Project_Manage_Details_Logs_Add.aspx?ID=" + this.Tbx_ID.Text + "");
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
                    AM.Add_Logs("项目日志增加" + model.IPML_ID);

                    StringBuilder s = new StringBuilder();
                    s.Append("<script language=javascript>" + "\n");
                    s.Append("var returnVal = window.confirm(\"添加成功!是否继续添加？\",\"添加日志\");" + "\n");
                    s.Append("if(!returnVal){" + "\n");
                    s.Append("window.close();window.opener.location.reload();" + "\n");
                    s.Append("}else{" + "\n");
                    s.Append(" window.opener.location.reload();window.location.href = \"IM_Project_Manage_Details_Logs_Add.aspx?FID=" + this.Tbx_FID.Text + "\";}" + "\n");
                    s.Append("</script>");
                    Type cstype = this.GetType();
                    ClientScriptManager cs = Page.ClientScript;
                    string csname = "ltype";
                    if (!cs.IsStartupScriptRegistered(cstype, csname))
                        cs.RegisterStartupScript(cstype, csname, s.ToString());
                }
                else
                {
                    AM.Add_Logs("新增失败" + model.IPML_ID);
                    AlertAndRedirect("新增失败！", "IM_Project_Manage_Details_Logs_List.aspx");
                }
            }
            catch (Exception ex) { }
        }
    }
    protected void Ddl_Name_SelectedIndexChanged(object sender, EventArgs e)
    {
        // 
        ShowInfo(this.Ddl_Name.SelectedValue);
    }
}
