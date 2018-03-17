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
/// 仓库管理
/// </summary>
public partial class Knet_Web_System_KnetProductsSpec_Add : BasePage
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

            this.Lbl_Title.Text = "新增产品规格书";
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string s_ProductsBarCode = Request.QueryString["ProductsBarCode"] == null ? "" : Request.QueryString["ProductsBarCode"].ToString();
            this.Tbx_ID.Text = s_ID;
            if (s_ProductsBarCode != "")
            {
                ProductsBarCode.Value = s_ProductsBarCode;
                ProductsEdition.Text = base.Base_GetProductsEdition(s_ProductsBarCode);
                ProductsPattern.Value = base.Base_GetProductsPattern(s_ProductsBarCode);
                this.Tbx_SpecCode.Text = "SP" + ProductsEdition.Text + "V1" + "001";
            }
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("新增产品规格书") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            else
            {
                if (s_ID != "")
                {
                    Getinfo(s_ID);
                }
                this.ProductsAddTime.Text = DateTime.Now.ToShortDateString();
                this.ProductsAddMan.Text = AM.KNet_StaffName;
                this.ProductsAddMantxt.Text = AM.KNet_StaffNo;
            }
        }
    }
    public void Getinfo(string s_ID)
    {
        KNet.BLL.Xs_Products_Spce BLL = new KNet.BLL.Xs_Products_Spce();
        KNet.Model.Xs_Products_Spce Model = BLL.GetModel(s_ID);
        this.Tbx_SpecCode.Text = Model.XPS_SpceCode;
        this.ProductsPattern.Value = base.Base_GetProductsPattern(Model.XPS_ProductsBarCode);
        this.ProductsEdition.Text = base.Base_GetProductsEdition(Model.XPS_ProductsBarCode);
        this.ProductsBarCode.Value = Model.XPS_ProductsBarCode;
        this.Lbl_Spce.Text = Model.XPS_SpceName;
        this.Tbx_Details.Text = Model.XPS_Details;
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
            //string FileType = uploadFile.PostedFile.ContentType.ToString(); //文件类型
            //if (FileType == "application/msword" || FileType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document")
            //{ }
            //else
            //{
            //    Response.Write("<script language=javascript>alert('文件类型服务器不接受！类型:" + FileType + " ');history.back(-1);</script>");
            //    Response.End();
            //}
                GetThumbnailImage();
                this.Lbl_Spce.Text = this.Tbx_SpecCode.Text + fileExt;
         
        }
    }

    /// <summary>
    /// word上传
    /// </summary>
    protected void GetThumbnailImage()
    {
        string UploadPath = "../UpLoadPic/WordSpce/";  //上传路径
        string AutoPath = "";
        if (this.Tbx_SpecCode.Text == "")
        {
            Alert("请填写版本号！");
            return;
        }
        else
        {
            AutoPath=this.Tbx_SpecCode.Text;//System.DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "");
        }
        fileExt = Path.GetExtension(uploadFile.PostedFile.FileName); //获扩展名
        string FileType = uploadFile.PostedFile.ContentType.ToString(); //文件类型

        string filePath = UploadPath + AutoPath + fileExt; //大文件名

        uploadFile.PostedFile.SaveAs(Server.MapPath(filePath)); //上传
        //if (FileType == "application/msword" || FileType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document")
        //{
        //  //  this.Image1Big.Text = filePath;
        //}
        //else
        //{
        //    Response.Write("<script language=javascript>alert('文件类型服务器不接受！类型:" + FileType + " ');history.back(-1);</script>");
        //    Response.End();
        //}
    }

    #endregion


    protected void Lbl_Spce_Click(object sender, EventArgs e)
    {

        string UploadPath = "../UpLoadPic/WordSpce/" + this.Lbl_Spce.Text;  //上传文件
        Response.Redirect(UploadPath);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        KNet.Model.Xs_Products_Spce Model = new KNet.Model.Xs_Products_Spce();
        KNet.BLL.Xs_Products_Spce BLL = new KNet.BLL.Xs_Products_Spce();
        AdminloginMess AM = new AdminloginMess();
        Model.XPS_ID = this.Tbx_ID.Text;
        Model.XPS_ProductsBarCode = this.ProductsBarCode.Value;
        Model.XPS_SpceCode = this.Tbx_SpecCode.Text;
        Model.XPS_SpceName = this.Lbl_Spce.Text;
        Model.XPS_Creator = AM.KNet_StaffNo;
        Model.XPS_CTime = DateTime.Now;
        Model.XPS_Details = this.Tbx_Details.Text;
        Model.XPS_Mender = AM.KNet_StaffNo;
        Model.XPS_MTime = DateTime.Now;
        try
        {
            if (this.Tbx_ID.Text == "")
            {
                Model.XPS_ID = GetNewID("Xs_Products_Spce", 1);
                BLL.Add(Model);
                AM.Add_Logs("添加规格说明书!+" + Model.XPS_ID);
                AlertAndRedirect("添加成功!", "KnetProductsSpec_List.aspx");

            }
            else
            {
                BLL.Update(Model);
                AM.Add_Logs("修改规格说明书!+" + Model.XPS_ID);
                AlertAndRedirect("修改成功!", "KnetProductsSpec_List.aspx");
 
            }
        }
        catch
        {
            Alert("错误!");
        }
    }
}
