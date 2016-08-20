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


public partial class Web_Sales_KNet_Reports_Submit_Add : BasePage
{
    public static string fileExt = ""; //获扩展名
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            base.Base_DropBasicCodeBind(this.Ddl_Types, "129");//关怀类型
            base.Base_DropBasicCodeBind(this.Ddl_State, "128");//关怀类型
            this.Ddl_State.SelectedValue = "0";
            this.Tbx_Code.Text = base.GetNewID("KNet_Reports_Submit", 0);

            this.Tbx_Num.Text = "0";
            base.Base_DropDutyPerson(this.Ddl_DutyPerson);
            this.Tbx_STime.Text = DateTime.Now.ToShortDateString();
            
            this.Lbl_Title.Text = "新增报表上传";
            if (s_ID!= "")
            {
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制报表上传";
                }
                else
                {
                    this.Lbl_Title.Text = "修改报表上传";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }
        }
    }

    protected void button_ServerClick(object sender, EventArgs e)
    {
        if (!(uploadFile.PostedFile.ContentLength > 0))
        {
            Alert("您没有选择文件!");
        }
        else
        {
            string FileType = uploadFile.PostedFile.ContentType.ToString(); //文件类型
            GetThumbnailImage();
            }
    }
    /// <summary>
    /// word上传
    /// </summary>
    protected void GetThumbnailImage()
    {
        string UploadPath = "../../UpLoadPic/Report/";  //上传路径
        string AutoPath = "";

        if (this.Ddl_DutyPerson.SelectedValue == "")
        {
            Alert("请选择人员！");
            return;
        }
        else if (this.Ddl_Types.Text == "")
        {
            Alert("请选择类型！");
            return;
        }
        else
        {
            AutoPath = this.Ddl_DutyPerson.SelectedItem.Text + "_" + this.Ddl_Types.SelectedItem.Text + "_" + System.DateTime.Now.ToString().Replace("-", "").Replace("/", "").Replace(" ", "").Replace(":", "");//System.DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "");
        }
        fileExt = Path.GetExtension(uploadFile.PostedFile.FileName); //获扩展名
        string FileType = uploadFile.PostedFile.ContentType.ToString(); //文件类型

        string filePath = UploadPath + AutoPath + fileExt; //大文件名

        uploadFile.PostedFile.SaveAs(Server.MapPath(filePath)); //上传 
        if (this.Tbx_Num.Text == "0")
        {
            this.Lbl_Spce.Text = AutoPath + fileExt;
            this.Tbx_Type.Text = this.Ddl_Types.SelectedValue;
        }
        else if (this.Tbx_Num.Text == "1")
        {
            this.Lbl_Spce1.Text = AutoPath + fileExt;
            this.Tbx_Type1.Text = this.Ddl_Types.SelectedValue;
        }
        else if (this.Tbx_Num.Text == "2")
        {
            this.Lbl_Spce2.Text = AutoPath + fileExt;
            this.Tbx_Type2.Text = this.Ddl_Types.SelectedValue;
        }
        else
        {
            Alert("只能上传3个文件！");
            return;
        }
        this.Tbx_Num.Text = Convert.ToString(int.Parse(this.Tbx_Num.Text) + 1);
    }

    private void ShowInfo(string s_ID)
    {
        AdminloginMess AM=new AdminloginMess();
        KNet.BLL.KNet_Reports_Submit bll = new KNet.BLL.KNet_Reports_Submit();
        KNet.Model.KNet_Reports_Submit model = bll.GetModel(s_ID);
        this.Tbx_STime.Text = DateTime.Parse(model.KRS_Stime.ToString()).ToShortDateString();
        this.Ddl_DutyPerson.SelectedValue = model.KRS_DutyPerson;
        this.Tbx_Remarks.Text = model.KRS_Remarks;
        this.Ddl_State.SelectedValue = model.KRS_State.ToString();
        this.Tbx_ID.Text = s_ID;
        this.Tbx_Code.Text = s_ID;
        this.Tbx_Topic.Text = model.KRS_Topic;
        this.Tbx_NoticeID.Text = model.KRS_NoticeID;
        
        KNet.BLL.Pb_Basic_Notice bll_Notice = new KNet.BLL.Pb_Basic_Notice();
        KNet.Model.Pb_Basic_Notice Model_Notice = bll_Notice.GetModel(model.KRS_NoticeID);
        if (Model_Notice != null)
        {
            this.Tbx_NoticeTitle.Text = Model_Notice.PBN_Title;
        }
        if (AM.KNet_StaffName != "项洲")
        {
            if (model.KRS_State.ToString() != "0")
            {
                AlertAndGoBack("已提交不能修改！");
            }
        }
        KNet.BLL.KNet_Reports_Submit_Details bll_Details = new KNet.BLL.KNet_Reports_Submit_Details();
        DataSet Dts_Table = bll_Details.GetList(" KRD_SubmitID='" + s_ID + "'");
        for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
        {
            if (i == 0)
            {
                this.Lbl_Spce.Text = Dts_Table.Tables[0].Rows[0]["KRD_Name"].ToString();
            }
            else if (i == 1)
            {
                this.Lbl_Spce1.Text = Dts_Table.Tables[0].Rows[1]["KRD_Name"].ToString();
            }
            else if (i == 2)
            {
                this.Lbl_Spce2.Text = Dts_Table.Tables[0].Rows[2]["KRD_Name"].ToString();
            }
        }
        this.Tbx_Num.Text = Dts_Table.Tables[0].Rows.Count.ToString();
    }

    protected void Lbl_Spce_Click(object sender, EventArgs e)
    {
        string UploadPath = "../UpLoadPic/Report/" + this.Lbl_Spce.Text;  //上传文件
        Response.Redirect(UploadPath);
    }

    protected void Lbl_Spce1_Click(object sender, EventArgs e)
    {
        string UploadPath = "../UpLoadPic/Report/" + this.Lbl_Spce1.Text;  //上传文件
        Response.Redirect(UploadPath);
    }

    protected void Lbl_Spce2_Click(object sender, EventArgs e)
    {
        string UploadPath = "../UpLoadPic/Report/" + this.Lbl_Spce2.Text;  //上传文件
        Response.Redirect(UploadPath);
    }
    private bool SetValue(KNet.Model.KNet_Reports_Submit model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text == "")
            {
                model.KRS_ID= base.GetNewID("KNet_Reports_Submit", 1);
            }
            else
            {
                model.KRS_ID = this.Tbx_ID.Text;
            }
            if (this.Tbx_STime.Text != "")
            {
                model.KRS_Stime = DateTime.Parse(this.Tbx_STime.Text);
            }
            model.KRS_DutyPerson = this.Ddl_DutyPerson.SelectedValue;
            model.KRS_Code = model.KRS_ID;
            model.KRS_Del = 0;
            model.KRS_State = int.Parse(this.Ddl_State.SelectedValue);
            model.KRS_Remarks = this.Tbx_Remarks.Text;
            model.KRS_Creator = AM.KNet_StaffNo;
            model.KRS_CTime = DateTime.Now;
            model.KRS_Mender = AM.KNet_StaffNo;
            model.KRS_MTime = DateTime.Now;
            model.KRS_Topic = this.Tbx_Topic.Text;
            model.KRS_NoticeID = this.Tbx_NoticeID.Text;
            ArrayList arr_Details = new ArrayList();
            if (Lbl_Spce.Text != "")
            {
                KNet.Model.KNet_Reports_Submit_Details Model_Details = new KNet.Model.KNet_Reports_Submit_Details();
                Model_Details.KRD_ID = base.GetNewID("KNet_Reports_Submit_Details", 1);
                Model_Details.KRD_Name = this.Lbl_Spce.Text;
                Model_Details.KRD_URL = "../UpLoadPic/Report/" + this.Lbl_Spce.Text;
                Model_Details.KPD_Type = this.Tbx_Type.Text;
                arr_Details.Add(Model_Details);
            }
            if (Lbl_Spce1.Text != "")
            {
                KNet.Model.KNet_Reports_Submit_Details Model_Details = new KNet.Model.KNet_Reports_Submit_Details();
                Model_Details.KRD_ID = base.GetNewID("KNet_Reports_Submit_Details", 1);
                Model_Details.KRD_Name = this.Lbl_Spce1.Text;
                Model_Details.KRD_URL = "../UpLoadPic/Report/" + this.Lbl_Spce1.Text;
                Model_Details.KPD_Type = this.Tbx_Type.Text;
                arr_Details.Add(Model_Details);
            }
            if (Lbl_Spce2.Text != "")
            {
                KNet.Model.KNet_Reports_Submit_Details Model_Details = new KNet.Model.KNet_Reports_Submit_Details();
                Model_Details.KRD_ID = base.GetNewID("KNet_Reports_Submit_Details", 1);
                Model_Details.KRD_Name = this.Lbl_Spce2.Text;
                Model_Details.KRD_URL = "../UpLoadPic/Report/" + this.Lbl_Spce2.Text;
                Model_Details.KPD_Type = this.Tbx_Type.Text;
                arr_Details.Add(Model_Details);
            }
            model.arr_details = arr_Details;
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

        KNet.Model.KNet_Reports_Submit model = new KNet.Model.KNet_Reports_Submit();
        KNet.BLL.KNet_Reports_Submit bll = new KNet.BLL.KNet_Reports_Submit();

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
                AM.Add_Logs("报表上传增加" + this.Tbx_ID.Text);
                AlertAndRedirect("新增成功！", "KNet_Reports_Submit_List.aspx");
            }
            catch { }
        }
        else
        {

            try
            {
                bll.Update(model);
                AM.Add_Logs("报表上传修改" + this.Tbx_ID.Text);
                AlertAndRedirect("修改成功！", "KNet_Reports_Submit_List.aspx");
            }
            catch { }
        }
    }
    public string GetCode()
    {
        string s_Return = "";
        try
        {
            s_Return += "RP";


        }
        catch (Exception ex)
        {
 
        }
        return s_Return;
    }
}
