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


public partial class Web_Sales_CG_Payment_For_Add : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("用款申请列表") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
            else
            {
                string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
                string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
                this.Tbx_STime.Text = DateTime.Now.ToShortDateString();
                base.Base_DropBasicCodeBind(this.Ddl_Currency, "401");
                base.Base_DropBasicCodeBind(this.Ddl_UseType, "402");
                this.Ddl_Currency.SelectedValue = "0";
                base.Base_DropDutyPerson(this.Ddl_DutyPerson);
                base.Base_DropDepart(this.Ddl_Depart);
                this.Ddl_Depart.SelectedValue = AM.KNet_StaffDepart;
                this.Lbl_Title.Text = "新增用款申请";
                this.Image1.ImageUrl = "../../images/Nopic.jpg";
                this.Image1Big.Text = "../../images/Nopic.jpg";
                if (s_ID != "")
                {
                    if (s_Type == "1")
                    {
                        this.Tbx_ID.Text = "";
                        this.Lbl_Title.Text = "复制用款申请";
                    }
                    else
                    {
                        this.Lbl_Title.Text = "修改用款申请";
                        this.Tbx_ID.Text = s_ID;
                    }
                    this.Btn_Save.Text = "保存";
                    ShowInfo(s_ID);
                }

            }
        }
    }

    private void ShowInfo(string s_ID)
    {
        AdminloginMess AM=new AdminloginMess();
        KNet.BLL.CG_Payment_For bll = new KNet.BLL.CG_Payment_For();
        KNet.Model.CG_Payment_For model = bll.GetModel(s_ID);
        if (model != null)
        {
            if ((model.CPF_State != 0)&&(AM.KNet_StaffName!="项洲"))
            {
                AlertAndGoBack("已审批不能修改！");
            }
            else
            {
                this.Tbx_ID.Text = model.CPF_ID;
                this.Tbx_FID.Text = model.CPF_FID;
                this.Tbx_Used.Text = model.CPF_Used;
                try
                {
                    this.Tbx_STime.Text = model.CPF_STime.ToShortDateString();
                }
                catch { }
                this.Ddl_Currency.SelectedValue = model.CPF_Currency;
                this.Ddl_UseType.SelectedValue = model.CPF_UseType;
                this.Tbx_Money.Text = model.CPF_Lowercase.ToString();
                this.Tbx_ChineseMoney.Text = model.CPF_Capital;
                this.Tbx_PayeeValue.Value = model.CPF_SuppNo;
                this.Tbx_PayeeName.Text = model.CPF_SuppNoName;

                try
                {
                    this.Tbx_YTime.Text = model.CPF_YTime.ToShortDateString();
                }
                catch { }
                this.Ddl_Depart.SelectedValue = model.CPF_DutyDepart;
                this.Ddl_DutyPerson.SelectedValue = model.CPF_DutyPerson;
                this.Tbx_Remarks.Text = model.CPF_Remarks;
                this.Tbx_BankAccount.Text = model.CPF_Account;
                this.Tbx_BankName.Text = model.CPF_Bank;

                this.Tbx_Shen.Text = model.CPF_Shen;
                this.Tbx_Shi.Text = model.CPF_Shi;
                this.Tbx_Code.Text = model.CPF_Code;
                this.Image1.ImageUrl = model.CPF_Image;
                this.Image1Big.Text = model.CPF_BigImage;
                this.Tbx_Details.Text = model.CPF_Details;
            }

        }
    }
    private bool SetValue(KNet.Model.CG_Payment_For model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text != "")
            {
                model.CPF_ID = this.Tbx_ID.Text;
                model.CPF_Code = this.Tbx_Code.Text;
            }
            if (this.Tbx_ID.Text == "")
            {
                model.CPF_ID = GetMainID();
                model.CPF_Code = base.GetNewID("CG_Payment_For", 1);
            }

            model.CPF_STime = DateTime.Parse(this.Tbx_STime.Text);
            model.CPF_Used = this.Tbx_Used.Text.ToString();
            model.CPF_UseType = this.Ddl_UseType.Text.ToString();
            model.CPF_Currency = this.Ddl_Currency.Text.ToString();
            model.CPF_Capital = this.Tbx_ChineseMoney.Text.ToString();
            model.CPF_Lowercase = decimal.Parse(this.Tbx_Money.Text.ToString());
            model.CPF_DutyPerson = this.Ddl_DutyPerson.Text.ToString();
            model.CPF_FID = this.Tbx_FID.Text.ToString();
            model.CPF_YTime = DateTime.Parse(this.Tbx_YTime.Text.ToString());
            model.CPF_DutyDepart = this.Ddl_Depart.Text.ToString();
            model.CPF_Account = this.Tbx_BankAccount.Text.ToString();
            model.CPF_Bank = this.Tbx_BankName.Text.ToString();
            model.CPF_SuppNo = this.Tbx_PayeeValue.Value.ToString();
            model.CPF_SuppNoName = this.Tbx_PayeeName.Text.ToString();
            model.CPF_Remarks = this.Tbx_Remarks.Text.ToString();
            model.CPF_State = 0;
            model.CPF_Shen = this.Tbx_Shen.Text.ToString();
            model.CPF_Shi = this.Tbx_Shi.Text.ToString();
            model.CPF_CwDateTime = DateTime.Parse("1900-01-01");
            model.CPF_ResDateTime = DateTime.Parse("1900-01-01");
            model.CPF_Creator = AM.KNet_StaffNo;
            model.CPF_CTime = DateTime.Now;
            model.CPF_Mender = AM.KNet_StaffNo;
            model.CPF_MTime = DateTime.Now;
            model.CPF_ZDateTime = DateTime.Parse("1900-01-01");
            model.CPF_Image = this.Image1.ImageUrl;
            model.CPF_BigImage = this.Image1Big.Text;
            model.CPF_Details = this.Tbx_Details.Text;
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
        string s_ID = this.Tbx_ID.Text;

        KNet.Model.CG_Payment_For model = new KNet.Model.CG_Payment_For();
        KNet.BLL.CG_Payment_For bll = new KNet.BLL.CG_Payment_For();

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
                AM.Add_Logs("用款申请增加" + this.Tbx_ID.Text);
                try
                {
                    base.Base_SendMessage(base.Base_GetDeptPerson("财务部", 1), "用款申请审批： <a href='/Web/CG/Payment/CG_Payment_For_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.CPF_Used + "</a> 需要你审批！ ");
                }
                catch
                { }

                AlertAndRedirect("新增成功！", "CG_Payment_For_List.aspx");

            }
            catch (Exception ex)
            {
                this.Tbx_ID.Text = "";
            }
        }
        else
        {

            try
            {
                bll.Update(model);
                try
                {
                    base.Base_SendMessage(base.Base_GetDeptPerson("财务部", 1), "用款申请审批： <a href='/Web/CG/Payment/CG_Payment_For_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.CPF_Used + "</a> 需要你审批！ ");
                }
                catch { }
                AM.Add_Logs("用款申请修改" + this.Tbx_ID.Text);
                AlertAndRedirect("修改成功！", "CG_Payment_For_List.aspx");

            }
            catch { }
        }
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
            if (FileType == "image/gif" || FileType == "image/pjpeg")
            {
                GetThumbnailImage();
            }
            else
            {
                Response.Write("<script language=javascript>alert('文件类型服务器不接受！类型:" + FileType + " ');history.back(-1);</script>");
                Response.End();
            }
        }
    }

    /// <summary>
    /// 图片上传
    /// </summary>
    protected void GetThumbnailImage()
    {
        string UploadPath = "../../../UpFile/Payment/";  //上传路径

        string AutoPath = System.DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "").Replace("/", "");
        string fileExt = Path.GetExtension(uploadFile.PostedFile.FileName); //获扩展名
        string FileType = uploadFile.PostedFile.ContentType.ToString(); //文件类型

        string filePath = UploadPath + AutoPath + fileExt; //大文件名
        string filePathsmall = UploadPath + AutoPath + "_small" + fileExt; //小文件名

        string newfile = filePath + ".jpg"; //略图文件名

        if (FileType == "image/gif" || FileType == "image/pjpeg")
        {
            if (!Directory.Exists(Server.MapPath(UploadPath)))
            {
                Directory.CreateDirectory(Server.MapPath(UploadPath));
            }
            uploadFile.PostedFile.SaveAs(Server.MapPath(filePath)); //上传
            Up_Loadcs UL = new Up_Loadcs();

            UL.MakeZoomImage(Server.MapPath("../../../UpFile/Payment/") + AutoPath + fileExt, Server.MapPath("../../../UpFile/Payment/") + AutoPath + "_small" + fileExt, 95, 75, "HW");

            this.Image1.ImageUrl = "../../../UpFile/Payment/" + AutoPath + "_small" + fileExt;
            this.Image1Big.Text = filePath;
        }
        else
        {
            Response.Write("<script language=javascript>alert('文件类型服务器不接受！类型:" + FileType + " ');history.back(-1);</script>");
            Response.End();
        }
    }

    #endregion
}
