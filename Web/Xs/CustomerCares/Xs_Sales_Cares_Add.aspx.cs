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


public partial class Web_Sales_Xs_Sales_Cares_Add : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            base.Base_DropBasicCodeBind(this.Ddl_CareTypes, "116");//关怀类型
            
            base.Base_DropDutyPerson(this.Ddl_DutyPerson);
            base.Base_DropLinkManBind(this.Ddl_LinkMan,this.Tbx_CustomerValue.Value);
            this.Lbl_Title.Text = "新增客户关怀";
            if (s_ID!= "")
            {
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制客户关怀";
                }
                else
                {
                    this.Lbl_Title.Text = "修改客户关怀";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }
            if (AM.CheckLogin(this.Lbl_Title.Text) == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
        }
    }

    private void ShowInfo(string s_ID)
    {
        KNet.BLL.Xs_Customer_Cares bll = new KNet.BLL.Xs_Customer_Cares();
        KNet.Model.Xs_Customer_Cares model = bll.GetModel(s_ID);
        this.Tbx_Topic.Text = model.XCC_Topic;
        this.Tbx_STime.Text = DateTime.Parse(model.XCC_Stime.ToString()).ToShortDateString();
        this.Tbx_CustomerValue.Value = model.XCC_CustomerValue;
        this.Tbx_CustomerName.Text = base.Base_GetCustomerName(model.XCC_CustomerValue);
        this.Ddl_LinkMan.SelectedValue = model.XCC_LinkMan;
        this.Ddl_DutyPerson.SelectedValue = model.XCC_DutyPerson;
        this.Ddl_CareTypes.SelectedValue = model.XCC_CareTypes;
        this.Tbx_CareDetails.Text = model.XCC_CareDetails;
        this.Tbx_CustomerDetails.Text = model.XCC_CustomerDetails;
        this.Tbx_Remarks.Text = model.XCC_Remarks;

    }
    private bool SetValue(KNet.Model.Xs_Customer_Cares model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text == "")
            {
                model.XCC_Code= base.GetNewID("Xs_Customer_Cares", 1);
            }
            else
            {
                model.XCC_Code = this.Tbx_ID.Text;
            }
            model.XCC_Topic = this.Tbx_Topic.Text;
            if (this.Tbx_STime.Text != "")
            {
                model.XCC_Stime = DateTime.Parse(this.Tbx_STime.Text);
            }

            model.XCC_CustomerValue = this.Tbx_CustomerValue.Value;
            model.XCC_LinkMan = this.Ddl_LinkMan.SelectedValue;
            model.XCC_DutyPerson = this.Ddl_DutyPerson.SelectedValue;
            model.XCC_CareTypes = this.Ddl_CareTypes.SelectedValue;
            model.XCC_CareDetails = this.Tbx_CareDetails.Text;
            model.XCC_CustomerDetails = this.Tbx_CustomerDetails.Text;
            model.XCC_Remarks = this.Tbx_Remarks.Text;
            model.XCC_Creator = AM.KNet_StaffNo;
            model.XCC_CTime = DateTime.Now;
            model.XCC_Mender = AM.KNet_StaffNo;
            model.XCC_MTime = DateTime.Now;
             

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

        KNet.Model.Xs_Customer_Cares model = new KNet.Model.Xs_Customer_Cares();
        KNet.BLL.Xs_Customer_Cares bll = new KNet.BLL.Xs_Customer_Cares();

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
                AM.Add_Logs("客户关怀增加" + this.Tbx_ID.Text);
                AlertAndRedirect("新增成功！", "Xs_Sales_Cares_List.aspx");
            }
            catch { }
        }
        else
        {

            try
            {
                bll.Update(model);
                AM.Add_Logs("客户关怀修改" + this.Tbx_ID.Text);
                AlertAndRedirect("修改成功！", "Xs_Sales_Cares_List.aspx");
            }
            catch { }
        }
    }

    #region 资料上传操作
    /// <summary>
    /// 上传资料
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
            //if (FileType == "image/gif" || FileType == "image/pjpeg")
            //{
            //}
            //else
            //{
            //    Alert("文件类型服务器不接受!");
            //}
            GetThumbnailImage1();
        }
    }
    /// <summary>
    /// 图片上传
    /// </summary>
    protected void GetThumbnailImage1()
    {
        AdminloginMess AM = new AdminloginMess();
        string UploadPath = "../../UpFile/Question/";  //上传路径
        string AutoPath = System.DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "").Replace("/", "");
        //string fileExt = Path.GetExtension(uploadFile1.PostedFile.FileName); //获扩展名
        string FileType = uploadFile.PostedFile.ContentType.ToString(); //文件类型
        string FileName = Path.GetFileName(uploadFile.PostedFile.FileName);
        string filePath = UploadPath + AutoPath + "_" + FileName; //大文件名
        if (!Directory.Exists(Server.MapPath(UploadPath)))
        {
            Directory.CreateDirectory(Server.MapPath(UploadPath));
        }
        uploadFile.PostedFile.SaveAs(Server.MapPath(filePath)); //上传
        Up_Loadcs UL = new Up_Loadcs();
        int i_Num = int.Parse(this.Tbx_num.Text);
        if (i_Num == 0)
        {
            Lbl_Details.Text += "<table id=\"myTableDetails\" width=\"100%\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">";
        }
        else
        {
            this.Lbl_Details.Text = this.Lbl_Details.Text.Substring(0, this.Lbl_Details.Text.Length - 8);
        }
        Lbl_Details.Text += "<tr><td valign=\"top\" class=\"lvtCol\" align=\"left\" nowrap><a onclick=\"deleteRow3(this)\" href=\"#\">";
        Lbl_Details.Text += "<img src=\"../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=\"0\"></a></td>";
        Lbl_Details.Text += "<td class=\"lvtCol\" align=\"left\" nowrap><input type=\"hidden\"  Name=\"Tbx_PName_" + i_Num + "\" value=" + FileName + ">" + FileName + "</td>";
        if (FileType == "image/gif" || FileType == "image/pjpeg")
        {
            Lbl_Details.Text += "<td class=\"lvtCol\" align=\"left\" nowrap><input Name=\"Image1Big_" + i_Num + "\"  type=\"hidden\"  value=" + filePath + "><Image ID=\"Image_" + i_Num + "\" Src=\"" + filePath + "\" Height=\"35px\" /></td></tr>";
        }
        else
        {
            Lbl_Details.Text += "<td class=\"lvtCol\" align=\"left\" nowrap><input Name=\"Image1Big_" + i_Num + "\"  type=\"hidden\"  value=" + filePath + "><a href=\"" + filePath + "\" >" + FileName + "</a></td></tr>";
        }
        this.Lbl_Details.Text += "</Table>";
        this.Tbx_num.Text = Convert.ToString(i_Num + 1);
    }
    #endregion
}
