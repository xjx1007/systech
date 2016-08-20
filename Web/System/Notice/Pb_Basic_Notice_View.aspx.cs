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

using KNet.DBUtility;
using KNet.Common;
using System.Data.SqlClient;

public partial class Pb_Basic_Notice_View : BasePage
{
    public string  s_OrderStyle = "", s_DetailsStyle = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            this.Tbx_ID.Text = s_ID;
            this.Lbl_Title.Text = "查看公告";
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            try
            {
                ShowInfo(s_ID);
            }
            catch
            { }
        }

    }

    private void ShowInfo(string s_ID)
    {
        KNet.BLL.Pb_Basic_Notice bll = new KNet.BLL.Pb_Basic_Notice();
        KNet.Model.Pb_Basic_Notice model = bll.GetModel(s_ID);
        this.Tbx_Title.Text = model.PBN_Title;
        this.Ddl_Type.Text = base.Base_GetBasicCodeName("219", model.PBN_Type);
        this.Tbx_ReceiveName.Text = base.Base_GetUserNames(model.PBN_ReceiveID);
        this.Tbx_Remark.Text = KNetPage.KHtmlDiscode(model.PBN_Details);
        try
        {
            this.StartDate.Text = DateTime.Parse(model.PBN_BeginTime.ToString()).ToShortDateString();
        }
        catch { }
        try
        {
            this.EndDate.Text = DateTime.Parse(model.PBN_EndTime.ToString()).ToShortDateString();
        }
        catch { }



        AdminloginMess AM = new AdminloginMess();
        string s_SqlWhere = " KRS_Del=0";

        string s_Type = "";


        if ((AM.KNet_StaffDepart == "129652783965723459") && (AM.KNet_Position == "102"))//研发中心经理
        {
            s_SqlWhere += " and KRS_DutyPerson in (Select StaffNo from KNet_Resource_Staff where StaffDepart='129652783965723459' or StaffDepart='129652784259578018' or StaffDepart='129652784446995911')";
        }
        else if ((AM.KNet_StaffDepart == "129652783693249229") && (AM.KNet_Position == "102"))
        {
            s_SqlWhere += " and 1=1 ";
        }
        else if (AM.KNet_Position == "102")
        {
            s_SqlWhere += " and KRS_DutyPerson in (Select StaffNo from KNet_Resource_Staff where StaffDepart='" + AM.KNet_StaffDepart + "') ";
        }
        else
        {
            s_SqlWhere += "  and KRS_DutyPerson='" + AM.KNet_StaffNo + "'";
        }
        s_SqlWhere += " and KRS_NoticeID='" + this.Tbx_ID.Text + "'";
        s_SqlWhere += " Order by KRS_CTime desc";
        KNet.BLL.KNet_Reports_Submit bll_Submit = new KNet.BLL.KNet_Reports_Submit();
        DataSet ds = bll_Submit.GetList(s_SqlWhere);
        this.MyGridView1.DataSource = ds;
        MyGridView1.DataKeyNames = new string[] { "KRS_ID" };
        MyGridView1.DataBind();
    }

    public string GetState(string s_ID)
    {
        string s_Return = "";
        KNet.BLL.KNet_Reports_Submit BLL = new KNet.BLL.KNet_Reports_Submit();
        KNet.Model.KNet_Reports_Submit Model = BLL.GetModel(s_ID);
        if (Model.KRS_State == 0)
        {
            s_Return = "<a href='KNet_Reports_Submit_List.aspx?ID=" + s_ID + "'>未提交</a>";
        }
        else if (Model.KRS_State == 1)
        {
            s_Return = "<font color=red>已提交</font>";
        }
        else if (Model.KRS_State == 3)
        {
            s_Return = "<font color=Green>已审阅</font>";
        }
        return s_Return;
    }

    public string GetSpce(string s_ID, int i_num)
    {
        string s_XPS_SpceName = "";
        KNet.BLL.KNet_Reports_Submit_Details Bll = new KNet.BLL.KNet_Reports_Submit_Details();
        DataSet Dts_Table = Bll.GetList(" KRD_SubmitID='" + s_ID + "'");
        if (Dts_Table.Tables[0].Rows.Count > 0)
        {
            string s_Name = "";
            try
            {
                s_Name = Dts_Table.Tables[0].Rows[i_num]["KRD_Name"].ToString();
            }
            catch { }
            s_XPS_SpceName = "<a href='/Web/UpLoadPic/Report/" + s_Name + "' >" + s_Name + "</a>";
        }
        return s_XPS_SpceName;
    }
}
