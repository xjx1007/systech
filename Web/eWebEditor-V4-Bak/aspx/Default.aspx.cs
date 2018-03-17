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
using System.Text;
using System.IO;
using System.Drawing;
using System.Net;

public partial class eWebEditor_upload_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.uploadfile.PostedFile.FileName.Equals(""))
        {
            return;
        }
        else
        {
            string _flag = Request["flag"];
            string _regex = "";
            switch (_flag)
            {
                case "img":
                    _regex = @"^.+\.(jpeg|gif|jpg|png)$";
                    break;
                case "flash":
                    _regex = @"^.+\.(swf)$";
                    break;
                case "media":
                    _regex = @"^.+\.(asf|wmv|avi|rmvb|mpeg|mov|mp3)$";
                    break;
                case "file":
                    _regex = @"^.+\.(rar|zip|doc|xls|xlsx|pdf|txt|csv)$";
                    break;
                default:
                    _regex = @"^.+\.(a)$";
                    break;
            }

            Regex test = new Regex(_regex.ToLower());
            
            if (test.IsMatch(uploadfile.PostedFile.FileName.ToLower()) == true)
            {
              
                ClientScriptManager cs = Page.ClientScript;
                string imagesfolder = ConfigurationManager.AppSettings["imagesfolder"].ToString();

                string filename = Common.UpLoadFile(uploadfile, imagesfolder);
                if (filename.Equals("1") == true) //没有文件
                {
                    lblinfo.Text = "文件类型不正确！<a href=\"Default.aspx?flag=" + _flag + "\">重新操作</a><script>parent.document.all('divProcessing').style.display='none';</script>";
                }
                if (filename.Equals("2") == true) //文件太大
                {
                    lblinfo.Text = "文件太大无法上传！默认10M.<a href=\"Default.aspx?flag=" + _flag + "\">重新操作</a><script>parent.document.all('divProcessing').style.display='none';</script>";
                }
                string apurl = Request.Url.ToString();
                string apurl2 = Request.CurrentExecutionFilePath;
                string tempurl = apurl.Substring(0, apurl.IndexOf(apurl2));
                string appurl = Request.ApplicationPath;
                string hurl;
                if (appurl.Length == 1)
                    hurl = appurl + filename.Replace("~/", "");
                else
                    hurl = appurl + "/" + filename.Replace("~/", "");
                string imgpreview = tempurl + hurl;

                cs.RegisterClientScriptBlock(this.GetType(), "tt", "parent.document.all('divProcessing').style.display='none';parent.document.all('imgPreview').src='" + imgpreview + "';parent.document.all('Hurl').value='" + hurl + "';parent.document.all('d_fromurl').value='';", true);

                lblinfo.Text = "文件上传成功！点 确定 添加到编辑器";
            }
            else
            {
                lblinfo.Text = "您上传的文件类型不正确！<a href=\"Default.aspx?flag=" + _flag + "\">重新上传</a><script>parent.document.all('divProcessing').style.display='none';</script>";
            }




        }
    }
}
