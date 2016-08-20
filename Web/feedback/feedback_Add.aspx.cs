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
/// 销售管理-----客户管理---客户添加
/// </summary>
public partial class Knet_Web_feedback_Add : BasePage
{
    public string s_MyTable_Detail = "";
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
            base.Base_DropDutyPerson(this.Tbx_Person);
            this.Tbx_Person.SelectedValue = "129785817148286979";
            base.Base_DropBasicCodeBind(this.Ddl_Type, "148");
            this.Ddl_Type.SelectedValue = "0";
            if (s_ID != "")
            {
                this.Tbx_ID.Text = s_ID;
                KNet.BLL.PB_Basic_Feedback Bll_Feedback = new KNet.BLL.PB_Basic_Feedback();
                KNet.Model.PB_Basic_Feedback Model_Feedback = Bll_Feedback.GetModel(s_ID);
                this.Tbx_Person.SelectedValue = Model_Feedback.PBF_ContentPerson;
                this.Ddl_Type.SelectedValue = Model_Feedback.PBF_Type;
                this.tbx_Remarks.Text = KNetPage.KHtmlDiscode(Model_Feedback.PBF_Details);
                int i_Num = int.Parse(this.Tbx_num.Text);
                KNet.BLL.PB_Basic_Attachment Bll_Att = new KNet.BLL.PB_Basic_Attachment();
                DataSet Dts_Table = Bll_Att.GetList(" PBA_FID='" + Model_Feedback.PBF_ID + "'");
                if (Dts_Table.Tables[0].Rows.Count > 0)
                {
                    Lbl_Details.Text += "<table id=\"myTableDetails\" width=\"100%\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">";
                    for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                    {
                        string s_FileName = Dts_Table.Tables[0].Rows[i]["PBA_Name"].ToString();
                        string s_filePath = Dts_Table.Tables[0].Rows[i]["PBA_Url"].ToString();
                        Lbl_Details.Text += "<tr><td valign=\"top\" class=\"lvtCol\" align=\"left\" nowrap><a onclick=\"deleteRow3(this)\" href=\"#\">";
                        Lbl_Details.Text += "<img src=\"../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=\"0\"></a></td>";

                        Lbl_Details.Text += "<td class=\"lvtCol\" align=\"left\" nowrap><input type=\"hidden\"  Name=\"Tbx_PName_" + i.ToString() + "\" value=" + s_FileName + ">" + s_FileName + "</td>";
                        Lbl_Details.Text += "<td class=\"lvtCol\" align=\"left\" nowrap><input Name=\"Image1Big_" + i.ToString() + "\"  type=\"hidden\"  value=" + s_filePath + "><a href=\"" + s_filePath + "\" >" + s_FileName + "</a></td></tr>";

                    }
                    this.Lbl_Details.Text += "</Table>";
                }
                this.Tbx_num.Text = Dts_Table.Tables[0].Rows.Count.ToString();
            }

        }
    }

    /// <summary>
    /// 添加信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.BLL.PB_Basic_Feedback Bll_Feedback = new KNet.BLL.PB_Basic_Feedback();
        KNet.Model.PB_Basic_Feedback Model_Feedback = new KNet.Model.PB_Basic_Feedback();
        if (this.Tbx_ID.Text == "")
        {
            Model_Feedback.PBF_ID = GetMainID();
            Model_Feedback.PBF_Code = GetNewID("PB_Basic_Feedback", 1);
        }
        else
        {
            Model_Feedback.PBF_ID = this.Tbx_ID.Text;
            Model_Feedback = Bll_Feedback.GetModel(this.Tbx_ID.Text);
        }
        Model_Feedback.PBF_Type = this.Ddl_Type.SelectedValue;
        Model_Feedback.PBF_Details = KNetPage.KHtmlEncode(this.tbx_Remarks.Text);
        Model_Feedback.PBF_ContentPerson = this.Tbx_Person.SelectedValue;
        Model_Feedback.PBF_Creator = AM.KNet_StaffNo;
        Model_Feedback.PBF_CTime = DateTime.Now;
        Model_Feedback.PBF_Mender = AM.KNet_StaffNo;
        Model_Feedback.PBF_MTime = DateTime.Now;
        ArrayList arr_Image = new ArrayList();
        for (int i = 0; i < int.Parse(this.Tbx_num.Text); i++)
        {
            string s_Name = Request["Tbx_PName_" + i.ToString() + ""] == null ? "" : Request["Tbx_PName_" + i.ToString() + ""].ToString();
            string s_URL = Request["Image1Big_" + i.ToString() + ""] == null ? "" : Request["Image1Big_" + i.ToString() + ""].ToString();
            if (s_Name != "")
            {
                KNet.Model.PB_Basic_Attachment Model_Att = new KNet.Model.PB_Basic_Attachment();
                Model_Att.PBA_ID = GetMainID(i);
                Model_Att.PBA_FID = Model_Feedback.PBF_ID;
                Model_Att.PBA_Name = s_Name;
                Model_Att.PBA_URL = s_URL;
                Model_Att.PBA_Type = "0";
                Model_Att.PBA_Creator = AM.KNet_StaffNo;
                Model_Att.PBA_CTime = DateTime.Now;
                arr_Image.Add(Model_Att);
            }
        }
        Model_Feedback.arr_List = arr_Image;
        try
        {
            if (this.Tbx_ID.Text == "")
            {
                Bll_Feedback.Add(Model_Feedback);
                AM.Add_Logs("添加问题反馈成功!+" + Model_Feedback.PBF_ID);
                StringBuilder s = new StringBuilder();
                s.Append("<script language=javascript>" + "\n");
                s.Append("alert('添加问题反馈成功!') \n");
                s.Append("window.close();" + "\n");
                s.Append("</script>");
                Type cstype = this.GetType();
                ClientScriptManager cs = Page.ClientScript;
                string csname = "ltype";
                if (!cs.IsStartupScriptRegistered(cstype, csname))
                    cs.RegisterStartupScript(cstype, csname, s.ToString());
                //AlertAndRedirect("添加问题反馈成功!", "feedback_List.aspx");
            }
            else
            {
                AM.Add_Logs("修改问题反馈成功!+" + Model_Feedback.PBF_ID);
                AlertAndRedirect("修改成功!", "feedback_List.aspx");
            }
        }
        catch(Exception ex)
        {
            Alert("错误!");
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
