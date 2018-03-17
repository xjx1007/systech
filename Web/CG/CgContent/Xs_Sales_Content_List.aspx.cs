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
using System.IO;
using System.Text;

using KNet.DBUtility;
using KNet.Common;

public partial class Web_Sales_Xs_Sales_Content_List : BasePage
{
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Lbl_Title.Text = "联系记录列表";
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin(this.Lbl_Title.Text) == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
            else
            {
                //联系记录删除
                if (AM.YNAuthority("删除联系记录") == false)
                {
                    this.lbtn_Del.Visible = false;
                }
                base.Base_DropBindSearch(this.bas_searchfield, "Xs_Sales_Content");
                base.Base_DropBindSearch(this.Fields, "Xs_Sales_Content");
                DataShows();
                base.Base_DropBatchBind(this.Ddl_Batch, "Xs_Sales_Content", "XSC_DutyPerson");
            }
        }
        
    }

    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        string SqlWhere = "  XSC_Type='1' ";

        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string s_Type = "";
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
        SqlWhere += " Order by XSC_MTime desc";
        KNet.BLL.Xs_Sales_Content bll = new KNet.BLL.Xs_Sales_Content();
        DataSet ds = bll.GetList(SqlWhere);
        this.MyGridView1.DataSource = ds;
        MyGridView1.DataKeyNames = new string[] { "XSC_ID" };
        MyGridView1.DataBind();
    }

    protected void Btn_Query_Click(object sender, EventArgs e)
    {
        this.DataShows();


    }
    protected void Btn_Del_Click(object sender, EventArgs e)
    {
        StringBuilder s_Sql = new StringBuilder();
        StringBuilder s_Log = new StringBuilder();
        try
        {
            for (int i = 0; i < MyGridView1.Rows.Count; i++)
            {
                CheckBox Ckb = (CheckBox)MyGridView1.Rows[i].Cells[0].FindControl("Chbk");
                if (Ckb.Checked)
                {
                    string s_ID = MyGridView1.DataKeys[i].Value.ToString();
                    s_Sql.Append(" delete from  Xs_Sales_Content Where XSC_ID='" + s_ID + "' ");
                    s_Log.Append(s_ID);
                }
            }
            DbHelperSQL.ExecuteSql(s_Sql.ToString());
            this.DataShows();
            AdminloginMess AM = new AdminloginMess();
            AM.Add_Logs("Xs_Sales_Content 删除 编号：" + s_Log + "");
            Alert("删除成功！");
        }
        catch (Exception ex)
        {
            Alert("删除失败！");
            return;
        }
    }

    protected void Ddl_Batch_TextChanged(object sender, EventArgs e)
    {
        this.DataShows();
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
        s_AdvShow = Base_GetAdvShowHtml(arr_Fields, arr_Condition, arr_Text, "Xs_Sales_Content");
        this.DataShows();
    }
}
