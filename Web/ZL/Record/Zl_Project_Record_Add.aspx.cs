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

public partial class Zl_Project_Record_Add : BasePage
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
            this.Tbx_SampleID.Text = s_SampleID;
            KNet.BLL.Pb_Products_Sample Bll_Sample = new KNet.BLL.Pb_Products_Sample();
            KNet.Model.Pb_Products_Sample Model_Sample = Bll_Sample.GetModel(s_SampleID);
 
            if (Model_Sample != null)
            {
                this.Tbx_SampleName.Text = Model_Sample.PPS_Name;
            }
            this.Tbx_Code.Text = GetCode();
            base.Base_DropBindFlow(this.Ddl_Flow, "113");
            base.Base_DropBasicCodeBind(this.Ddl_State, "251",false);
            base.Base_DropBasicCodeBind(this.Ddl_Type, "252");
            this.Tbx_Type.Text = s_Type;
            this.CommentList2.CommentFID = this.Tbx_Code.Text;
            this.CommentList2.CommentType = "XCJL";
            try
            {
                string s_DSql = "Delete from PB_Basic_Attachment wehre PBA_Type='XCJL' and PBA_FID NOT in (Select ZPR_ID from Zl_Project_Record ) and PBA_FID<>'" + this.Tbx_Code.Text + "'";
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
                    this.Lbl_Title.Text = "复制现场记录";
                }
                else
                {
                    this.Lbl_Title.Text = "修改现场记录";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }
            else
            {
                this.Lbl_Title.Text = "新增现场记录";
            }
        }

    }
    private void ShowInfo(string s_ID)
    {
        KNet.BLL.Zl_Project_Record bll = new KNet.BLL.Zl_Project_Record();
        KNet.Model.Zl_Project_Record model = bll.GetModel(s_ID); 
        if (model != null)
        {
            if (model.ZPR_State != 0)
            {
                AlertAndGoBack("不能修改！");
            }
            else
            {
                this.Tbx_ID.Text = model.ZPR_ID.ToString();
                this.Tbx_Code.Text = model.ZPR_Code.ToString();
                this.Tbx_Title.Text = model.ZPR_Title.ToString();
                this.Tbx_STime.Text = DateTime.Parse(model.ZPR_STime.ToString()).ToShortDateString(); ;
                this.Ddl_Flow.SelectedValue = model.ZPR_Flow.ToString();
                this.Ddl_State.SelectedValue = model.ZPR_State.ToString();
                this.Tbx_Remarks.Text = model.ZPR_Remarks.ToString();
                this.Tbx_SampleID.Text = model.ZPR_SampleID.ToString();
                this.Tbx_SampleName.Text = model.ZPR_SampleName.ToString();
                this.Ddl_Type.SelectedValue = model.ZPR_Type.ToString();
                this.CommentList2.CommentFID = this.Tbx_Code.Text;
                this.CommentList2.CommentType = "XCJL";
            }
        }
    }

    private bool SetValue(KNet.Model.Zl_Project_Record model)
    {
        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text == "")
            {
                model.ZPR_ID = GetMainID();
            }
            else
            {
                model.ZPR_ID = this.Tbx_ID.Text;
            }
            model.ZPR_Code = this.Tbx_Code.Text;
            model.ZPR_Title = this.Tbx_Title.Text.ToString();
            model.ZPR_STime = DateTime.Parse(this.Tbx_STime.Text.ToString());
            model.ZPR_Flow = this.Ddl_Flow.SelectedValue.ToString();
            model.ZPR_State = int.Parse(this.Ddl_State.Text.ToString());
            model.ZPR_Remarks = this.Tbx_Remarks.Text.ToString();
            model.ZPR_Del = 0;
            model.ZPR_CTime = DateTime.Now;
            model.ZPR_Creator = AM.KNet_StaffNo;
            model.ZPR_MTime = DateTime.Now;
            model.ZPR_Mender = AM.KNet_StaffNo;
            model.ZPR_SampleID = this.Tbx_SampleID.Text.ToString();
            model.ZPR_SampleName = this.Tbx_SampleName.Text.ToString();
            model.ZPR_Type = int.Parse(this.Ddl_Type.SelectedValue);
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
        KNet.Model.Zl_Project_Record model = new KNet.Model.Zl_Project_Record();
        KNet.BLL.Zl_Project_Record bll = new KNet.BLL.Zl_Project_Record();

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
                 //   AM.Add_Logs("现场记录修改" + this.Tbx_ID.Text);
                  //  base.Base_SendMessage(model.PBW_ID, "现场记录： <a href='Web/Notice/Zl_Project_Record_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PBW_ID + "</a> ");
                    AlertAndRedirect("修改成功！", "Zl_Project_Record_List.aspx");
                }
                else
                {
                    AM.Add_Logs("现场记录修改失败" + this.Tbx_ID.Text);
                    AlertAndRedirect("修改失败！", "Zl_Project_Record_Add.aspx?ID=" + this.Tbx_ID.Text + "");
                }
            }
            catch { }
        }
        else
        {
            try
            {
                bll.Add(model);
               // base.Base_SendMessage(model.PBN_ReceiveID, "现场记录： <a href='Web/Notice/Zl_Project_Record_View.aspx?ID=" + model.PBN_ID + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PBN_Title + "</a> ");
               // AM.Add_Logs("现场记录增加" + model.PBW_ID);
                AlertAndRedirect("新增成功！", "Zl_Project_Record_List.aspx");
            }
            catch { }
        }
    }
    private string GetCode()
    {
        AdminloginMess AM = new AdminloginMess();
        string s_Return = "";
        string s_Sql = "Select isnull(MAX(ZPR_Code),'') from Zl_Project_Record  where year(ZPR_Stime)=year(GetDate())";
        this.BeginQuery(s_Sql);
        string s_Code = this.QueryForReturn();
        if (s_Code == "")
        {
            s_Return = base.Base_GetCodeByTitle("现场记录报告");
        }
        else
        {
            this.BeginQuery("Select Code from KNet_Resource_OrganizationalStructure where strucValue='" + AM.KNet_StaffDepart + "' ");
            string s_DepartCode = this.QueryForReturn();
                string s_Code1 = "",s_Code2="";
            try
            {
                s_Code1 = s_Code.Substring(0, 6);
                s_Code2 = s_Code.Substring(8, 6);
                s_Return = s_Code1 + s_DepartCode + Convert.ToString(int.Parse(s_Code2) + 1);
            }
            catch
            {
                s_Return = s_Code1 + s_DepartCode + Convert.ToString(int.Parse(s_Code2) + 1);
            }
        }
        return s_Return;
    }
}
