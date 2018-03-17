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
using KNet.Common;


/// <summary>
/// 文档
/// </summary>
public partial class Knet_Web_System_Knet_Document_Add : BasePage
{
    public string s_MyTable_Detail = "", s_ProductsTable_Detail = "";

    public static string fileExt = ""; //获扩展名
    protected void Page_PreInit(object sender, EventArgs e)
    {
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Ajax.Utility.RegisterTypeForAjax(typeof(Knet_Web_System_Knet_Document_Add));
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            this.Tbx_ID.Text = s_ID;
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("新增文档中心") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            else
            {
                base.Base_DropDutyPerson(this.Ddl_DutyPerson);
                base.Base_DropBasicCodeBind(this.Ddl_Type, "111");
                this.Tbx_Code.Text = base.GetNewID("PB_Basic_Document", 0);
                if (s_ID != "")
                {
                    Getinfo(s_ID);
                    this.Button3.Text = "保  存 ";
                }
            }
        }
    }
    public void Getinfo(string s_ID)
    {
        KNet.BLL.PB_Basic_Document BLL = new KNet.BLL.PB_Basic_Document();
        KNet.Model.PB_Basic_Document Model = BLL.GetModel(s_ID);
        this.Tbx_Code.Text = s_ID;
        this.Tbx_Name.Text = Model.PBM_Name;
        this.Ddl_Type.SelectedValue = Model.PBM_Type;
        this.Ddl_DutyPerson.SelectedValue = Model.PBM_DutyPerson;
        this.Lbl_Spce.Text = Model.PBM_DocName;
        this.Tbx_Details.Text = Model.PBM_Details;
        this.Tbx_Visio.Text = Model.PBM_Visio;
        this.tbx_FaterId.Text = Model.PBM_FatherID;
        this.Tbx_FaterName.Text = BLL.GetDocumentName(Model.PBM_FatherID);
    }

    #region 图片上传操作
    /// <summary>
    /// 上传图片
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void button_ServerClick(object sender, EventArgs e)
    {
        if (!(uploadFile.PostedFile.ContentLength > 0))
        {
            Alert("您没有选择文件!");
        }
        else
        {
            string FileType = uploadFile.PostedFile.ContentType.ToString(); //文件类型
            //if (FileType == "application/msword" || FileType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document")
            //{
            //}
            //else
            //{
            //    Response.Write("<script language=javascript>alert('文件类型服务器不接受！类型:" + FileType + " ');history.back(-1);</script>");
            //    Response.End();
            //}
            GetThumbnailImage();
            this.Lbl_Spce.Text = this.Tbx_Name.Text+"_"+this.Tbx_Visio.Text + fileExt;
          
        }
    }
    [Ajax.AjaxMethod]
    public string  GetCode(string s_Name)
    {
        string s_Return = "";
        try
        {

            KNet.BLL.PB_Basic_Document BLL = new KNet.BLL.PB_Basic_Document();
            if (BLL.Exists(s_Name))
            {
                KNet.Model.PB_Basic_Document Model = BLL.GetLastModel(s_Name);

                if (Model.PBM_Visio == "")
                {
                    s_Return = "V" + "1";
                }
                else
                {
                    int i_num = int.Parse(Model.PBM_Visio.Substring(1, Model.PBM_Visio.Length - 1).ToString());
                    i_num++;
                    s_Return = "V" + i_num.ToString();
                }
            }
            else
            {

                s_Return = "V" + "1";
            }
            
        }
        catch(Exception ex)
        {
            s_Return=ex.Message;
        }
        return s_Return;
    }
    /// <summary>
    /// word上传
    /// </summary>
    protected void GetThumbnailImage()
    {
        string UploadPath = "/UpFile/Word/";  //上传路径
        string AutoPath = "";

        if (this.Tbx_Name.Text == "")
        {
            Alert("请填写名称！");
            return;
        }
        else
        {
            AutoPath = this.Tbx_Name.Text + "_" + this.Tbx_Visio.Text;//System.DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "");
        }
        fileExt = Path.GetExtension(uploadFile.PostedFile.FileName); //获扩展名
        string FileType = uploadFile.PostedFile.ContentType.ToString(); //文件类型

        string filePath = UploadPath + AutoPath + fileExt ; //大文件名

        //if (FileType == "application/msword" || FileType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document")
        //{     //  this.Image1Big.Text = filePath;
        //}
        //else
        //{
        //    Response.Write("<script language=javascript>alert('文件类型服务器不接受！类型:" + FileType + " ');history.back(-1);</script>");
        //    Response.End();
        //}
            uploadFile.PostedFile.SaveAs(Server.MapPath(filePath)); //上传
     
    }

    #endregion


    protected void Lbl_Spce_Click(object sender, EventArgs e)
    {
        string UploadPath = "/UpFile/Word/" + this.Lbl_Spce.Text;  //上传文件
        Response.Redirect(UploadPath);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        KNet.Model.PB_Basic_Document Model = new KNet.Model.PB_Basic_Document();
        KNet.BLL.PB_Basic_Document BLL = new KNet.BLL.PB_Basic_Document();
        AdminloginMess AM = new AdminloginMess();

        Model.PBM_DutyPerson = this.Ddl_DutyPerson.SelectedValue;
        Model.PBM_Type = this.Ddl_Type.SelectedValue;
        Model.PBM_Name = this.Tbx_Name.Text;
        Model.PBM_Del = "0";
        Model.PBM_Details = this.Tbx_Details.Text;
        Model.PBM_CTime = DateTime.Now;
        Model.PBM_Creator = AM.KNet_StaffNo;
        Model.PBM_Mtime = DateTime.Now;
        Model.PBM_Mender = AM.KNet_StaffNo;
        Model.PBM_DocName = this.Lbl_Spce.Text;
        Model.PBM_Visio = this.Tbx_Visio.Text;
        Model.PBM_FatherID = this.tbx_FaterId.Text;
        try
        {
            if (this.Tbx_ID.Text == "")
            {
                Model.PBM_Code = base.GetNewID("PB_Basic_Document", 1);
                BLL.Add(Model);
                AM.Add_Logs("添加文档成功!+" + Model.PBM_Code);
                AlertAndRedirect("添加文档成功!", "Knet_Document_List.aspx");

            }
            else
            {
                Model.PBM_Code = this.Tbx_ID.Text;
                BLL.Update(Model);
                AM.Add_Logs("修改规格说明书!+" + Model.PBM_Code);
                AlertAndRedirect("修改成功!", "Knet_Document_List.aspx");
            }
        }
        catch
        {
            Alert("错误!");
        }
    }
}
