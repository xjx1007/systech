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


public partial class UpLoad_AddForProducts : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            base.Base_DropBasicCodeBind(this.Ddl_Type, "780");
            string s_ID = Request.QueryString["UpdateID"] == null ? "" : Request.QueryString["UpdateID"].ToString();
            this.Tbx_UpdateID.Text = s_ID;
           
            KNet.BLL.PB_Basic_Attachment BLL = new KNet.BLL.PB_Basic_Attachment();
            KNet.Model.PB_Basic_Attachment model = BLL.GetModel(s_ID);
            if (model != null)
            {
                this.Tbx_UpdateName.Text = model.PBA_Name;
            }
        }

    }
    protected void save_Click(object sender, EventArgs e)
    {

        if (!(uploadFile.PostedFile.ContentLength > 0))
        {
            Alert("您没有选择文件!");
        }
        else
        {
            AdminloginMess AM = new AdminloginMess();
            KNet.Model.PB_Basic_Attachment model = new KNet.Model.PB_Basic_Attachment();
            string FileType = uploadFile.PostedFile.ContentType.ToString(); //文件类型
            GetThumbnailImage1(model);
            try
            {
                //停用老附近
                
                KNet.BLL.PB_Basic_Attachment BLL = new KNet.BLL.PB_Basic_Attachment();
                
                if (model.PBA_UpdateFID != "")
                {
                    KNet.Model.PB_Basic_Attachment Mode_att = BLL.GetModel(model.PBA_UpdateFID);
                    if (Mode_att != null)
                    {
                        Mode_att.PBA_Del = 1;
                        BLL.UpdateByDel(Mode_att);
                        AM.Add_Logs("停用附件：" + Mode_att.PBA_ID);
                    }
                }
                BLL.Add(model);
                AM.Add_Logs("附件上传成功：编号：" + model.PBA_ID);
                string s_Return = "1";
                StringBuilder s = new StringBuilder();
                s.Append("<script language=javascript>" + "\n");
                s.Append("alert('添加成功！');" + "\n");
                s.Append("if(window.opener != undefined)");
                s.Append("{\n");
                s.Append("    window.opener.returnValue = '" + s_Return + "';\n");
                s.Append("    window.opener.SetReturnValueInOpenner_UploadForProducts('" + s_Return + "');\n");
                s.Append("}\n");
                s.Append("else\n");
                s.Append("{\n");
                s.Append("    window.returnValue = '" + s_Return + "';\n");
                s.Append("}\n");
                //s.Append("if(window.opener != undefined) {window.opener.returnValue='1';} else{window.returnValue='1';}" + "\n");
                s.Append("window.close();" + "\n");
                s.Append("</script>");
                Type cstype = this.GetType();
                ClientScriptManager cs = Page.ClientScript;
                string csname = "ltype";
                if (!cs.IsStartupScriptRegistered(cstype, csname))
                    cs.RegisterStartupScript(cstype, csname, s.ToString());
            }
            catch(Exception ex) { }
        }
    }



    #region 资料上传操作
    /// <summary>
    /// 图片上传
    /// </summary>
    protected void GetThumbnailImage1(KNet.Model.PB_Basic_Attachment model)
    {
        AdminloginMess AM = new AdminloginMess();
        //类别下面的
        //历史的
        string UploadPath = "/UpFile/" + Request.QueryString["PBC_Type"] + "/" + Request.QueryString["PBC_FID"].ToString() + "/";  //上传路径
        string AutoPath = System.DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "").Replace("/", "");
        string fileExt = Path.GetExtension(uploadFile.PostedFile.FileName).Replace(".",""); //获扩展名
        string FileType = uploadFile.PostedFile.ContentType.ToString(); //文件类型
        string FileName = Path.GetFileName(uploadFile.PostedFile.FileName);
        string filePath = UploadPath + AutoPath + "_" + FileName; //大文件名
        if (!Directory.Exists(Server.MapPath(UploadPath)))
        {
            Directory.CreateDirectory(Server.MapPath(UploadPath));
        }
        uploadFile.PostedFile.SaveAs(Server.MapPath(filePath)); //上传


        model.PBA_FID = Request.QueryString["PBC_FID"];
        model.PBA_Type = Request.QueryString["PBC_Type"];
        model.PBA_ID = GetMainID();
        model.PBA_Name = this.Tbx_Name.Text;
        model.PBA_URL = filePath;
        model.PBA_CTime = DateTime.Now;
        model.PBA_Creator = AM.KNet_StaffNo;
        model.PBA_Remarks = this.Tbx_Remarks.Text;
        model.PBA_ProductsType=this.Ddl_Type.SelectedValue;
        model.PBA_FileType = fileExt;
        model.PBA_Edition = this.Tbx_Version.Text;
        model.PBA_UpdateFID = this.Tbx_UpdateID.Text;
    }
    #endregion

}