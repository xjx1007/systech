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

public partial class ZL_Task_Instruction_Add : BasePage
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
            string s_ProductsBarCode = Request.QueryString["ProductsBarCode"] == null ? "" : Request.QueryString["ProductsBarCode"].ToString();
            this.Tbx_ProductsBarCode.Text = s_ProductsBarCode;
            this.Tbx_ProductsName.Text = base.Base_GetProductsEdition(s_ProductsBarCode);
            this.Tbx_Code.Text = GetCode();
            base.Base_DropBindFlow(this.Ddl_Flow, "110");
            base.Base_DropDutyPerson(this.Ddl_DutyPerson);
            this.Tbx_Type.Text = s_Type;
            this.CommentList2.CommentFID = this.Tbx_Code.Text;
            this.CommentList2.CommentType = "Instruction";
            try
            {
                string s_DSql = "Delete from PB_Basic_Attachment wehre PBA_Type='Instruction' and PBA_FID NOT in (Select ZTI_ID from ZL_Task_Instruction ) and PBA_FID<>'" + this.Tbx_Code.Text + "'";
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
                    this.Lbl_Title.Text = "复制作业指导书";
                }
                else
                {
                    this.Lbl_Title.Text = "修改作业指导书";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }
            else
            {
                this.Lbl_Title.Text = "新增作业指导书";
            }
        }

    }
    private void ShowInfo(string s_ID)
    {
        KNet.BLL.ZL_Task_Instruction bll = new KNet.BLL.ZL_Task_Instruction();
        KNet.Model.ZL_Task_Instruction model = bll.GetModel(s_ID); 
        if (model != null)
        {
            if (model.ZTI_State != 0)
            {
                AlertAndGoBack("不能修改！");
            }
            else
            {
                this.Tbx_ID.Text = model.ZTI_ID.ToString();
                this.Tbx_Code.Text = model.ZTI_Code.ToString();
                this.Tbx_Name.Text = model.ZTI_Name.ToString();
                this.Tbx_STime.Text = DateTime.Parse(model.ZTI_Stime.ToString()).ToShortDateString(); ;
                this.Ddl_Flow.SelectedValue = model.ZTI_Flow.ToString();
                this.Tbx_Remarks.Text = model.ZTI_Remarks.ToString();
                this.Tbx_ProductsBarCode.Text = model.ZTI_ProductsBarCode.ToString();
                this.Ddl_DutyPerson.SelectedValue = model.ZTI_DutyPerson.ToString();
                this.CommentList2.CommentFID = this.Tbx_Code.Text;
                this.CommentList2.CommentType = "Instruction";
            }
        }
    }

    private bool SetValue(KNet.Model.ZL_Task_Instruction model)
    {
        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text == "")
            {
                model.ZTI_ID = GetMainID();
            }
            else
            {
                model.ZTI_ID = this.Tbx_ID.Text;
            }
            model.ZTI_Code = this.Tbx_Code.Text;
            model.ZTI_Name = this.Tbx_Name.Text.ToString();
            model.ZTI_Stime = DateTime.Parse(this.Tbx_STime.Text.ToString());
            model.ZTI_Flow = this.Ddl_Flow.SelectedValue.ToString();
            //model.ZTI_State = int.Parse(this.Ddl_State.Text.ToString());
            model.ZTI_Remarks = this.Tbx_Remarks.Text.ToString();
            model.ZTI_Del = 0;
            model.ZTI_CTime = DateTime.Now;
            model.ZTI_Creator = AM.KNet_StaffNo;
            model.ZTI_MTime = DateTime.Now;
            model.ZTI_Mender = AM.KNet_StaffNo;
            model.ZTI_ProductsBarCode = this.Tbx_ProductsBarCode.Text.ToString();
            model.ZTI_DutyPerson =this.Ddl_DutyPerson.SelectedValue;
            model.ZTI_State = 0;
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
        KNet.Model.ZL_Task_Instruction model = new KNet.Model.ZL_Task_Instruction();
        KNet.BLL.ZL_Task_Instruction bll = new KNet.BLL.ZL_Task_Instruction();

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
                   AM.Add_Logs("作业指导书修改" + this.Tbx_ID.Text);
                  //  base.Base_SendMessage(model.PBW_ID, "作业指导书： <a href='Web/Notice/ZL_Task_Instruction_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PBW_ID + "</a> ");
                    AlertAndRedirect("修改成功！", "ZL_Task_Instruction_List.aspx");
                }
                else
                {
                    AM.Add_Logs("作业指导书修改失败" + this.Tbx_ID.Text);
                    AlertAndRedirect("修改失败！", "ZL_Task_Instruction_Add.aspx?ID=" + this.Tbx_ID.Text + "");
                }
            }
            catch { }
        }
        else
        {
            try
            {
                bll.Add(model);
               // base.Base_SendMessage(model.PBN_ReceiveID, "作业指导书： <a href='Web/Notice/ZL_Task_Instruction_View.aspx?ID=" + model.PBN_ID + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PBN_Title + "</a> ");
              AM.Add_Logs("作业指导书增加" + this.Tbx_ID);
                AlertAndRedirect("新增成功！", "ZL_Task_Instruction_List.aspx");
            }
            catch { }
        }
    }
    private string GetCode()
    {
        AdminloginMess AM = new AdminloginMess();
        string s_Return = "";
        string s_Sql = "Select isnull(MAX(ZTI_Code),'') from ZL_Task_Instruction  where year(ZTI_Stime)=year(GetDate())";
        this.BeginQuery(s_Sql);
        string s_Code = this.QueryForReturn();
        if (s_Code == "")
        {
            s_Return = base.Base_GetCodeByTitle("作业指导书");
        }
        else
        {
            this.BeginQuery("Select Code from KNet_Resource_OrganizationalStructure where strucValue='" + AM.KNet_StaffDepart + "' ");
            string s_DepartCode = this.QueryForReturn();

            string s_Code1 = s_Code.Substring(0, 6);
            string s_Code2 = s_Code.Substring(8, 6);
            s_Return = s_Code1 +s_DepartCode+ Convert.ToString(int.Parse(s_Code2) + 1);
        }
        return s_Return;
    }
}
