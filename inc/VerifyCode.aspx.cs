using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;

using KNet.DBUtility;
using KNet.Common;

public partial class KnetWork_VerifyCode : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        KNet_VryImg  KNet_Vry = new KNet_VryImg();
        string verifyCode = KNet_Vry.CreateVerifyCode(3, 1);
        Session["VerifyCode"] = verifyCode.ToUpper();
        System.Drawing.Bitmap bitmap = KNet_Vry.CreateImage(verifyCode);
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
        Response.Clear();
        Response.ContentType = "../images/Png";
        Response.BinaryWrite(ms.GetBuffer());
        bitmap.Dispose();
        ms.Dispose();
        ms.Close();
        Response.End();
    }
}
