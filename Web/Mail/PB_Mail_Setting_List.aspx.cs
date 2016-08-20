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

public partial class PB_Mail_Setting_List : BasePage
{
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            this.DataShows();

            string s_ID=Request.QueryString["ID"]==null?"":Request.QueryString["ID"].ToString();
            if(s_ID!="")
            {
                string sql = "Update PB_Mail_Setting set PMS_Del='1'  where PMS_ID='"+s_ID+"'"; //删除
                AdminloginMess LogAM = new AdminloginMess();
                DbHelperSQL.ExecuteSql(sql);
                LogAM.Add_Logs("邮件管理--->发件人删除 操作成功！");
                this.DataShows();
            }
        }


    }

    public void btnBasicSearch_Click(object sender, EventArgs e)
    {
        this.advSearch.Style["display"] = "none";
        this.Search_basic.Style["display"] = "block";
        this.DataShows();
    }

    public void btnAdvancedSearch_Click(object sender, EventArgs e)
    {
        this.Search_basic.Style["display"] = "none";
        this.advSearch.Style["display"] = "block";

        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string[] arr_Fields = s_Fields.Split(',');
        string[] arr_Condition = s_Condition.Split(',');
        string[] arr_Text = s_Text.Split(',');
        this.Fields.SelectedValue = arr_Fields[0];
        this.Condition.SelectedValue = arr_Condition[0];
        this.Srch_value.Text = arr_Text[0];
        s_AdvShow = Base_GetAdvShowHtml(arr_Fields, arr_Condition, arr_Text);
        this.DataShows();
    }
    public void DataShows()
    {
        AdminloginMess AM = new AdminloginMess();

        KNet.BLL.PB_Mail_Setting bll = new KNet.BLL.PB_Mail_Setting();
        string s_Sql = "PMS_Del=0  and PMS_Creator='"+AM.KNet_StaffNo+"' ";

        s_Sql += " Order by PMS_ID desc";
        DataSet ds = bll.GetList(s_Sql);
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "PMS_ID" };
        GridView1.DataBind();
        ds.Dispose();
    }

    protected void Btn_Del_Click(object sender, EventArgs e)
    {
        
    }
  
    protected void Btn_Search_Click(object sender, EventArgs e)
    {
        this.DataShows();
    }
    
}
