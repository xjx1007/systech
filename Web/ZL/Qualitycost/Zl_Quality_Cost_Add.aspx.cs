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

public partial class Zl_Quality_Cost_Add : BasePage
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
            string s_SType = Request.QueryString["SType"] == null ? "" : Request.QueryString["SType"].ToString();
            string s_Table = Request.QueryString["Table"] == null ? "" : Request.QueryString["Table"].ToString();
            string s_SampleID = Request.QueryString["SampleID"] == null ? "" : Request.QueryString["SampleID"].ToString();
            this.Tbx_Code.Text = GetCode();
            base.Base_DropBindFlow(this.Ddl_Flow, "113");
            base.Base_DropBasicCodeBind(this.Ddl_State, "251", false);
            base.Base_DropBasicCodeBind(this.Ddl_Type, "252");
            base.Base_DropBasicCodeBind(this.ddl_ProjectType, "769");
            this.Tbx_Type.Text = s_Type;
            try
            {
                string s_DSql = "Delete from PB_Basic_Attachment wehre PBA_Type='XCJL' and PBA_FID NOT in (Select ZQC_ID from Zl_Quality_Cost ) and PBA_FID<>'" + this.Tbx_Code.Text + "'";
                DbHelperSQL.ExecuteSql(s_DSql);
            }
            catch
            { }
            this.Tbx_STime.Text = DateTime.Now.ToShortDateString();
            if (s_ID != "")
            {
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制质量成本";
                }
                else
                {
                    this.Lbl_Title.Text = "修改质量成本";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }
            else
            {
                this.Lbl_Title.Text = "新增质量成本";
            }
        }

    }
    private void ShowInfo(string s_ID)
    {
        KNet.BLL.Zl_Quality_Cost bll = new KNet.BLL.Zl_Quality_Cost();
        KNet.Model.Zl_Quality_Cost model = bll.GetModel(s_ID);
        if (model != null)
        {
            this.Tbx_ID.Text = model.ZQC_ID.ToString();
            this.Tbx_Code.Text = model.ZQC_Code.ToString();
            this.Tbx_STime.Text = DateTime.Parse(model.ZQC_STime.ToString()).ToShortDateString(); ;
            this.Ddl_Flow.SelectedValue = model.ZQC_Flow.ToString();
            this.Tbx_Remarks.Text = model.ZQC_Remarks.ToString();
            this.ddl_ProjectType.SelectedValue = model.ZQC_ProjectType;
            this.ddl_ContentType.SelectedValue = model.ZQC_ContentType;
        }
    }

    private bool SetValue(KNet.Model.Zl_Quality_Cost model)
    {
        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text == "")
            {
                model.ZQC_ID = GetMainID();
            }
            else
            {
                model.ZQC_ID = this.Tbx_ID.Text;
            }
            model.ZQC_Code = this.Tbx_Code.Text;
            model.ZQC_STime = DateTime.Parse(this.Tbx_STime.Text.ToString());
            model.ZQC_Flow = this.Ddl_Flow.SelectedValue.ToString();
            model.ZQC_Remarks = this.Tbx_Remarks.Text.ToString();
            model.ZQC_ProjectType = this.ddl_ProjectType.SelectedValue;
            model.ZQC_ContentType = this.ddl_ContentType.SelectedValue;
            model.ZQC_Money = decimal.Parse(this.Tbx_Money.Text);

            model.ZQC_Del = 0;
            model.ZQC_CTime = DateTime.Now;
            model.ZQC_Creator = AM.KNet_StaffNo;
            model.ZQC_MTime = DateTime.Now;
            model.ZQC_Mender = AM.KNet_StaffNo;
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
        KNet.Model.Zl_Quality_Cost model = new KNet.Model.Zl_Quality_Cost();
        KNet.BLL.Zl_Quality_Cost bll = new KNet.BLL.Zl_Quality_Cost();

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
                    //   AM.Add_Logs("质量成本修改" + this.Tbx_ID.Text);
                    //  base.Base_SendMessage(model.PBW_ID, "质量成本： <a href='Web/Notice/Zl_Quality_Cost_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PBW_ID + "</a> ");
                    AlertAndRedirect("修改成功！", "Zl_Quality_Cost_List.aspx");
                }
                else
                {
                    AM.Add_Logs("质量成本修改失败" + this.Tbx_ID.Text);
                    AlertAndRedirect("修改失败！", "Zl_Quality_Cost_Add.aspx?ID=" + this.Tbx_ID.Text + "");
                }
            }
            catch { }
        }
        else
        {
            try
            {
                bll.Add(model);
                // base.Base_SendMessage(model.PBN_ReceiveID, "质量成本： <a href='Web/Notice/Zl_Quality_Cost_View.aspx?ID=" + model.PBN_ID + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PBN_Title + "</a> ");
                // AM.Add_Logs("质量成本增加" + model.PBW_ID);
                AlertAndRedirect("新增成功！", "Zl_Quality_Cost_List.aspx");
            }
            catch { }
        }
    }
    private string GetCode()
    {
        AdminloginMess AM = new AdminloginMess();
        string s_Return = "";
        string s_Sql = "Select isnull(MAX(ZQC_Code),'') from Zl_Quality_Cost  where year(ZQC_Stime)=year(GetDate())";
        this.BeginQuery(s_Sql);
        string s_Code = this.QueryForReturn();
        if (s_Code == "")
        {
            s_Return = base.Base_GetCodeByTitle("质量成本");
        }
        else
        {
            this.BeginQuery("Select Code from KNet_Resource_OrganizationalStructure where strucValue='" + AM.KNet_StaffDepart + "' ");
            string s_DepartCode = this.QueryForReturn();

            string s_Code1 = s_Code.Substring(0, 6);
            string s_Code2 = s_Code.Substring(8, 6);
            s_Return = s_Code1 + s_DepartCode + Convert.ToString(int.Parse(s_Code2) + 1);
        }
        return s_Return;
    }
    protected void ddl_ProjectType_SelectedIndexChanged(object sender, EventArgs e)
    {
        base.Base_DropBasicCodeBind(this.ddl_ContentType, "770", "769", this.ddl_ProjectType.SelectedValue);
    }
}
