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


public partial class Web_KNet_Reports_Submit_View : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.Lbl_Title.Text = "查看报表上传";
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();

            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            if (s_Type != "")
            {
                this.Tr_Andwser.Visible = true;
                AdminloginMess AM = new AdminloginMess();

                this.Lbl_Person.Text = AM.KNet_StaffName;
            }
            if (s_ID != "")
            {
                ShowInfo(s_ID);
            }
        }
       
    }

    private void ShowInfo(string s_ID)
    {

        KNet.BLL.KNet_Reports_Submit bll = new KNet.BLL.KNet_Reports_Submit();
        KNet.BLL.KNet_Reports_Submit_Details bll_Details = new KNet.BLL.KNet_Reports_Submit_Details();
        KNet.BLL.KNet_Reports_Submit_View bll_View = new KNet.BLL.KNet_Reports_Submit_View();
        KNet.Model.KNet_Reports_Submit model = bll.GetModel(s_ID);
        try
        {
            this.Tbx_ID.Text = s_ID;
            this.Lbl_Stime.Text = DateTime.Parse(model.KRS_Stime.ToString()).ToShortDateString();
            this.Lbl_Code.Text = s_ID;
            this.Lbl_DutyPerson.Text = base.Base_GetUserName(model.KRS_DutyPerson);
            this.Lbl_State.Text = base.Base_GetBasicCodeName("128",model.KRS_State.ToString());

            this.Lbl_Remarks.Text = model.KRS_Remarks;
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
            DataSet Dts1 = bll_View.GetList(" KRV_SubmitID='" + s_ID + "' ");
            this.MyGridView1.DataSource = Dts1;
            MyGridView1.DataBind();

        }
        catch
        {}
    }

    protected void Lbl_Spce_Click(object sender, EventArgs e)
    {
        string UploadPath = "/Web/UpLoadPic/Report/" + this.Lbl_Spce.Text;  //上传文件
        Response.Redirect(UploadPath);
    }

    protected void Lbl_Spce1_Click(object sender, EventArgs e)
    {
        string UploadPath = "/Web/UpLoadPic/Report/" + this.Lbl_Spce1.Text;  //上传文件
        Response.Redirect(UploadPath);
    }

    protected void Lbl_Spce2_Click(object sender, EventArgs e)
    {
        string UploadPath = "/Web/UpLoadPic/Report/" + this.Lbl_Spce2.Text;  //上传文件
        Response.Redirect(UploadPath);
    }
    protected void Btn_SaveOnClick(object sender, EventArgs e)
    {
        try
        {
            AdminloginMess AM=new AdminloginMess();
            KNet.Model.KNet_Reports_Submit_View Model= new KNet.Model.KNet_Reports_Submit_View();
            KNet.BLL.KNet_Reports_Submit_View Bll= new KNet.BLL.KNet_Reports_Submit_View();
            Model.KRV_ID = base.GetNewID("KNet_Reports_Submit_View", 1);
            Model.KRV_SubmitID = this.Tbx_ID.Text;
            Model.KRV_Remarks = this.Tbx_Remarks.Text;
            Model.KRV_Person = AM.KNet_StaffNo;
            Model.KRV_Del = 0;
            Model.KRV_CTime = DateTime.Now;
            Model.KRV_Creator = AM.KNet_StaffNo;
            Bll.Add(Model);
            AlertAndRedirect("评阅成功！", "KNet_Reports_Submit_View.aspx?ID=" + this.Tbx_ID.Text);
        }
        catch (Exception ex)
        { 
        }
    }
}
