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
public partial class Knet_Web_System_Knet_Document_View : BasePage
{
    public string s_NextDocumentHtml = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("查看文档中心") == false)
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
            }
        }
    }
    public void Getinfo(string s_ID)
    {
        KNet.BLL.PB_Basic_Document BLL = new KNet.BLL.PB_Basic_Document();
        KNet.Model.PB_Basic_Document Model = BLL.GetModel(s_ID);
        this.Lbl_Code.Text = s_ID;
            this.Lbl_Name.Text = Model.PBM_Name;
        this.Lbl_Type.Text = base.Base_GetBasicCodeName("111",Model.PBM_Type);
        this.Lbl_DutyPerson.Text = base.Base_GetUserName(Model.PBM_DutyPerson);
        this.Lbl_Spce.Text = "<a href=\"/Web/UpLoadPic/Word/" + Model.PBM_DocName + "\">" + Model.PBM_DocName + "";
        this.Lbl_Details.Text = Model.PBM_Details;
        this.Lbl_Visio.Text = Model.PBM_Visio;
        this.Lbl_FaterName.Text = "<a href=\"/Web/UpLoadPic/Word/" + BLL.GetDocumentName(Model.PBM_FatherID) + "\">" + BLL.GetDocumentName(Model.PBM_FatherID) + "";
        DataSet Dts_Tabel = BLL.GetList(" PBM_FatherID='" + s_ID + "'");
        if(Dts_Tabel.Tables[0].Rows.Count>0)
        {
            for (int i = 0; i < Dts_Tabel.Tables[0].Rows.Count; i++)
            {
                s_NextDocumentHtml += "<tr><td colspan=\"4\"><a href=\"/Web/UpLoadPic/Word/" + Dts_Tabel.Tables[0].Rows[i]["PBM_DocName"].ToString() + "\">" + Dts_Tabel.Tables[0].Rows[i]["PBM_DocName"].ToString() + "</td></tr>";
            }
        }
    }

    protected void Lbl_Spce_Click(object sender, EventArgs e)
    {
        string UploadPath = "/Web/UpLoadPic/Word/" + this.Lbl_Spce.Text;  //上传文件
        Response.Redirect(UploadPath);
    }
}
