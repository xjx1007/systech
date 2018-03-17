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
using System.Collections;
using KNet.Common;


public partial class Web_Sales_KNet_Reports_Submit_Type_Add : BasePage
{
    public static string fileExt = ""; //获扩展名
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Ajax.Utility.RegisterTypeForAjax(typeof(Web_Sales_KNet_Reports_Submit_Type_Add));
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            base.Base_DropBasicCodeBind(this.Ddl_Type, "136");
            base.Base_DropDepart(this.DDl_Depart);
            base.Base_DropDutyPerson(this.Ddl_Person);
            this.Ddl_Person.SelectedValue = "";
            
            this.Lbl_Title.Text = "新增部门报表类型设置";
            if (s_ID!= "")
            {
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制部门报表类型设置";
                }
                else
                {
                    this.Lbl_Title.Text = "修改部门报表类型设置";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }
        }
    }
    private void ShowInfo(string s_ID)
    {
        KNet.BLL.KNet_Reports_Submit bll = new KNet.BLL.KNet_Reports_Submit();
        KNet.Model.KNet_Reports_Submit model = bll.GetModel(s_ID);
        this.Tbx_ID.Text = s_ID;
        this.Tbx_Code.Text = s_ID;
    }

    public string GetCode()
    {
        string s_Rturn = "";
        KNet.Model.KNet_Reports_Submit_Type Model = new KNet.Model.KNet_Reports_Submit_Type();
        KNet.BLL.KNet_Reports_Submit_Type bll = new KNet.BLL.KNet_Reports_Submit_Type();
        Model.KRT_Depart = this.DDl_Depart.SelectedValue;
        Model.KRT_Type = int.Parse(this.Ddl_Type.SelectedValue);
        Model.KRT_Person = this.Ddl_Person.SelectedValue;

        try
        {
            s_Rturn = bll.GetCode(Model);
        }
        catch
        {
 
        }
        return s_Rturn;
    }
    private bool SetValue(KNet.Model.KNet_Reports_Submit_Type model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text == "")
            {
                model.KRT_ID= base.GetNewID("KNet_Reports_Submit_Type", 1);
            }
            else
            {
                model.KRT_ID = this.Tbx_ID.Text;
            }
            model.KRT_Code = this.Tbx_Code.Text;
            model.KRT_Type = int.Parse(this.Ddl_Type.SelectedValue);
            model.KRT_Depart = this.DDl_Depart.SelectedValue;
            model.KRT_Person = this.Ddl_Person.SelectedValue;
            model.KRT_Del = 0;
            model.KRT_Creator = AM.KNet_StaffNo;
            model.KRT_CTime = DateTime.Now;
            model.KRT_Mender = AM.KNet_StaffNo;
            model.KRT_MTime = DateTime.Now;
            return true;
        }
        catch
        {
            return false;
        }
       
    }

    protected void Btn_SaveOnClick(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        string s_ID=this.Tbx_ID.Text;

        KNet.Model.KNet_Reports_Submit_Type model = new KNet.Model.KNet_Reports_Submit_Type();
        KNet.BLL.KNet_Reports_Submit_Type bll = new KNet.BLL.KNet_Reports_Submit_Type();

        if (this.SetValue(model) == false)
        {
            Alert("系统错误！");
            return;
        }
        if (s_ID == "")//新增
        {
            try
            {
                bll.Add(model);
                AM.Add_Logs("部门报表类型设置增加" + this.Tbx_ID.Text);
                AlertAndRedirect("新增成功！", "KNet_Reports_Submit_Type_List.aspx");
            }
            catch { }
        }
        else
        {

            try
            {
                bll.Update(model);
                AM.Add_Logs("部门报表类型设置修改" + this.Tbx_ID.Text);
                AlertAndRedirect("修改成功！", "KNet_Reports_Submit_Type_List.aspx");
            }
            catch { }
        }
    }
    protected void Ddl_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Tbx_Code.Text = GetCode();
    }
    protected void DDl_Depart_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Tbx_Code.Text = GetCode();
    }
    protected void Ddl_Person_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Tbx_Code.Text = GetCode();
    }
}
