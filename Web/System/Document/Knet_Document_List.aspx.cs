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
/// 仓库管理
/// </summary>
public partial class Knet_Web_System_Knet_Document_List : BasePage
{
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("文档中心列表") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }

            base.Base_DropBindSearch(this.bas_searchfield, "PB_Basic_Document");
            base.Base_DropBindSearch(this.Fields, "PB_Basic_Document");
            base.Base_DropBatchBind(this.Ddl_Batch, "PB_Basic_Document", "PBM_DutyPerson");

            this.Btn_Del.Attributes.Add("onclick", "return confirm('你确信要删除所选记录吗?！')");

            this.DataShows();
            this.RowOverYN();
        }

    }

    protected void Ddl_Batch_TextChanged1(object sender, EventArgs e)
    {
        this.DataShows();
    }
    /// <summary>
    /// 是不是有记录
    /// </summary>
    protected void RowOverYN()
    {
        if (GridView1.Rows.Count == 0) //如果没有记录
        {
            this.Btn_Del.Enabled = false;
        }
        else
        {
            this.Btn_Del.Enabled = true;
        }
    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.PB_Basic_Document bll = new KNet.BLL.PB_Basic_Document();

        string SqlWhere = " PBM_Del='0' ";

        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string s_Type = "";

        AdminloginMess AM = new AdminloginMess();

        if (s_WhereID != "")
        {
            SqlWhere += Base_GetBasicWhere(s_WhereID);
        }
        if (this.Ddl_Batch.SelectedValue != "")
        {
            SqlWhere += Base_GetBasicWhere(this.Ddl_Batch.SelectedValue);
        }
        if ((this.bas_searchfield.SelectedValue != "") && (search_text.Text != ""))
        {
            SqlWhere += base.Base_GetBasicColumnWhere(this.bas_searchfield.SelectedValue, this.search_text.Text);
        }
        if (s_Text != "")
        {
            if (this.matchtype1.Checked == true)//and
            {
                s_Type = "0";
            }
            if (this.matchtype2.Checked == true)
            {
                s_Type = "1";
            }
            SqlWhere += base.Base_GetAdvWhere(s_Fields, s_Condition, s_Text, s_Type);
        }
        SqlWhere += " order by PBM_CTime Desc";
        DataSet ds = bll.GetList(SqlWhere);
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "PBM_Code" };
        GridView1.DataBind();
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
    protected void Btn_Del_Click(object sender, EventArgs e)
    {

        AdminloginMess AM = new AdminloginMess();
            string sql = "Update PB_Basic_Document set PBM_Del='1'  where";
            string cal = "";
            string s_BarCode = "";
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
                if (cb.Checked == true)
                {
                    cal += " PBM_Code='" + GridView1.DataKeys[i].Value.ToString() + "' or";
                }
            }
            if (cal != "")
            {
                sql += " PBM_DutyPerson='"+AM.KNet_StaffNo+"' and ("+cal.Substring(0, cal.Length - 3)+")";
            }
            else
            {
                sql = "";       //不删除
                Response.Write("<script language=javascript>alert('您没有选择要删除的记录!');history.back(-1);</script>");
                Response.End();
            }
            DbHelperSQL.ExecuteSql(sql);
            AdminloginMess LogAM = new AdminloginMess();
            LogAM.Add_Logs("文档中心-->文档删除 操作成功！");

            this.DataShows();
            this.RowOverYN();
    }
    protected void Btn_Query_Click(object sender, EventArgs e)
    {
        this.DataShows();
    }
    public string GetSpce(string s_ID)
    {
        KNet.BLL.PB_Basic_Document Bll = new KNet.BLL.PB_Basic_Document();
        KNet.Model.PB_Basic_Document Model = Bll.GetModel(s_ID);
        string s_XPS_SpceName = "<a href='/Web/UpLoadPic/Word/" + Model.PBM_DocName + "' >" + Model.PBM_DocName + "</a>";

        return s_XPS_SpceName;
    }


    public string GetModiy(string s_ID,string s_DutyPerson)
    {
        string s_Return="";
        AdminloginMess AM=new AdminloginMess();
        if (AM.KNet_StaffNo == s_DutyPerson)
        {
            s_Return = "<a href=\"Knet_Document_Add.aspx?ID=" + s_ID + "\"><img ID=\"Image3\"  src=\"/images/Edit.gif\"  ToolTip=\"修改\"  style=\"border-width:0px;\"  /></a>";

        }
        else
        {
            s_Return = "<font color=red>不可修改</font>";
        }
        return s_Return;
    }
}
