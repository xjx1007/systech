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

public partial class IM_Project_Manage_Details_Add : BasePage
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
            Bll_Details.BindDrop(this.Ddl_FID,s_FID,"0");
            this.Ddl_FID.SelectedValue = s_GID;
            Bll_Details.BindDrop(this.Ddl_FTaskID, s_FID, "1");

            Bll_Details.BindDrop(this.Ddl_FIDDetials, s_FID, "0");
            base.Base_DropBasicCodeBind(this.Ddl_State, "226");
            this.Ddl_State.SelectedValue = "2";

            base.Base_DropBasicCodeBind(this.Ddl_ProjectType, "773");
            this.Ddl_ProjectType.SelectedValue = "0";
            base.Base_DropBasicCodeBind(this.Ddl_Import, "774", false);
            base.Base_DropBasicCodeBind(this.Ddl_DayType, "775", false);
            this.BeginQuery("Select * from PB_basic_Code where PBC_ID='776' order by PBC_Order");
            this.QueryForDataTable();
            Rad_HolidayType.DataSource = this.Dtb_Result;
            Rad_HolidayType.DataTextField = "PBC_Name";
            Rad_HolidayType.DataValueField = "PBC_Code";
            Rad_HolidayType.DataBind();
            Rad_HolidayType.SelectedValue = "0";
            if (s_GID != "")
            {
               this.Ddl_Type.SelectedValue = "1";
               this.Ddl_FID.Enabled = false;
               KNet.Model.IM_Project_Manage_Details Model_Details = Bll_Details.GetModel(s_GID);
               if (Model_Details != null)
               {
                   this.Tbx_Level.Text = Model_Details.IPMD_Level.ToString();
               }
            }
            this.Tbx_Code.Text = base.GetNewID("IM_Project_Manage", 0);
            
            if (s_ID != "")
            {
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制子项";
                }
                else
                {
                    this.Lbl_Title.Text = "修改子项";
                    this.Tbx_ID.Text = s_ID;
                    this.Ddl_FID.Enabled = false;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }
            else
            {
                this.Lbl_Title.Text = "新增子项";
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
            this.Tbx_ID.Text = model.IPMD_ID.ToString();
            this.Tbx_FID.Text = model.IPMD_IPMID.ToString();
            this.Ddl_FID.Text = model.IPMD_FID.ToString();
            this.Ddl_Type.SelectedValue = model.IPMD_Type.ToString();
            this.Tbx_Name.Text = model.IPMD_Name.ToString();
            this.Tbx_Days.Text = model.IPMD_Days.ToString();
            this.Tbx_FloatingDays.Text = model.IPMD_FloatingDays.ToString();
            this.Ddl_FTaskID.SelectedValue = model.IPMD_PreTask.ToString();
            this.Tbx_ReceiveID.Text = model.IPMD_Executor.ToString();
            this.Tbx_Remarks.Text = model.IPMD_Remarks.ToString();
            this.Tbx_ReceiveID.Text = model.IPMD_Executor;
            this.Tbx_ReceiveName.Text = base.Base_GetUserNames(model.IPMD_Executor);
            this.Tbx_Level.Text = model.IPMD_Level.ToString();

            this.Ddl_State.SelectedValue = model.IPMD_State.ToString();
        }
    }
    /// <summary>
    /// 赋值
    /// </summary>
    private bool SetValue(KNet.Model.IM_Project_Manage_Details model)
    {
        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text == "")
            {
                model.IPMD_ID = GetMainID();
            }
            else
            {
                model.IPMD_ID = this.Tbx_ID.Text;
            }

            model.IPMD_IPMID = this.Tbx_FID.Text;
            model.IPMD_FID = this.Ddl_FID.SelectedValue.ToString();
            model.IPMD_Type = int.Parse(this.Ddl_Type.SelectedValue.ToString());
            model.IPMD_Name = this.Tbx_Name.Text.ToString();
            model.IPMD_Days = int.Parse(this.Tbx_Days.Text.ToString());
            model.IPMD_FloatingDays = int.Parse(this.Tbx_FloatingDays.Text.ToString());
            model.IPMD_PreTask = this.Ddl_FTaskID.SelectedValue.ToString();

            model.IPMD_EarlyBeginTime = DateTime.Now;
            model.IPMD_EarlyEndTime = DateTime.Now;
            model.IPMD_AtLatestBeginTime = DateTime.Now;
            model.IPMD_AtLatestEndTime = DateTime.Now;
            model.IPMD_DutyPerson = AM.KNet_StaffNo;
            model.IPMD_Executor = this.Tbx_ReceiveID.Text.ToString();
            model.IPMD_Remarks = this.Tbx_Remarks.Text.ToString();
            model.IPMD_Creator = AM.KNet_StaffNo;
            model.IPMD_CTime = DateTime.Now;
            model.IPMD_Del = 0;
            model.IPMD_Mender = AM.KNet_StaffNo;
            model.IPMD_MTime = DateTime.Now;
            model.IPMD_FTaskID = this.Ddl_FTaskID.Text.ToString();

            model.IPMD_State=int.Parse(this.Ddl_State.SelectedValue);

            if ((this.Tbx_ID.Text == "") && (this.Ddl_FID.SelectedValue != ""))
            {
                model.IPMD_Level = int.Parse(this.Tbx_Level.Text) + 1;
            }
            else if ((this.Tbx_ID.Text != "") && (this.Ddl_FID.SelectedValue != ""))
            {
                KNet.BLL.IM_Project_Manage_Details BLL_Details = new KNet.BLL.IM_Project_Manage_Details();
                KNet.Model.IM_Project_Manage_Details Model_Details = BLL_Details.GetModel(this.Tbx_ID.Text);
                if (Model_Details != null)
                {
                    if (Model_Details.IPMD_FID == "")
                    {
                        model.IPMD_Level = int.Parse(this.Tbx_Level.Text) + 1;
                    }
                }
            }
            else 
            {
                model.IPMD_Level = int.Parse(this.Tbx_Level.Text);
            }
            
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
        KNet.Model.IM_Project_Manage_Details model = new KNet.Model.IM_Project_Manage_Details();
        KNet.BLL.IM_Project_Manage_Details bll = new KNet.BLL.IM_Project_Manage_Details();
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
                    AlertAndRedirect("修改失败！", "IM_Project_Manage_Details_Add.aspx?ID=" + this.Tbx_ID.Text + "");
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
                    AM.Add_Logs("项目子项增加" + model.IPMD_ID);

                    StringBuilder s = new StringBuilder();
                    s.Append("<script language=javascript>" + "\n");
                    s.Append("var returnVal = window.confirm(\"添加成功!是否继续添加？\",\"添加子项\");" + "\n");
                    s.Append("if(!returnVal){" + "\n");
                    s.Append("window.close();window.opener.location.reload();" + "\n");
                    s.Append("}else{" + "\n");
                    s.Append(" window.opener.location.reload();window.location.href = \"IM_Project_Manage_Details_Add.aspx?FID=" + this.Tbx_FID.Text + "\";}" + "\n");
                    s.Append("</script>");
                    Type cstype = this.GetType();
                    ClientScriptManager cs = Page.ClientScript;
                    string csname = "ltype";
                    if (!cs.IsStartupScriptRegistered(cstype, csname))
                        cs.RegisterStartupScript(cstype, csname, s.ToString());
                }
                else
                {
                    AM.Add_Logs("新增失败" + model.IPMD_ID);
                    AlertAndRedirect("新增失败！", "IM_Project_Manage_Details_List.aspx");
                }
            }
            catch(Exception ex) { }
        }
    }
}
