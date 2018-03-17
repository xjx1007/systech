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
using System.Runtime.Serialization.Json;

using KNet.DBUtility;
using KNet.Common;
using System.Net;

/// <summary>
/// 销售管理-----发货单 管理
/// </summary>
public partial class CK_ProductsIn_Manage : BasePage
{
    public string s_DivStyle = "";
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("成品入库单列表") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }

            //删除成品入库单
            if (AM.YNAuthority("删除成品入库单") == false)
            {
                this.Btn_Del.Enabled = false;
            }
            this.Btn_Del.Attributes.Add("onclick", "return confirm('你确信要删除所选记录吗?！\\n\\n注意：该删除会同时删除发货单产品明细记录.')");
             base.Base_DropBatchBind(this.Ddl_Batch, "Sc_Expend_Manage", "SEM_RKPerson");
            base.Base_DropBindSearch(this.bas_searchfield, "Sc_Expend_Manage");
            base.Base_DropBindSearch(this.Fields, "Sc_Expend_Manage");
            this.DataShows();   
        }

    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.Sc_Expend_Manage bll = new KNet.BLL.Sc_Expend_Manage();
        string SqlWhere = " SEM_Type=1 ";
        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
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
        if (this.Ddl_Batch.SelectedValue != "")
        {
            SqlWhere += Base_GetBasicWhere(this.Ddl_Batch.SelectedValue);
        }
        SqlWhere = SqlWhere + " order by SEM_MTime desc";
        DataSet ds = bll.GetList(SqlWhere);
       
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "SEM_ID" };
        GridView1.DataBind();
    }


    public string s_GetHouse(string s_DirectOutNO)
    {
        string s_Return="";
        try
        {
            KNet.BLL.KNet_WareHouse_DirectOutList Bll = new KNet.BLL.KNet_WareHouse_DirectOutList();
            KNet.Model.KNet_WareHouse_DirectOutList Model = Bll.GetModelB(s_DirectOutNO);
            s_Return = base.Base_GetHouseName(Model.HouseNo);
        }
        catch { }
        return s_Return;
    }
    protected void Ddl_Batch_TextChanged1(object sender, EventArgs e)
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
        s_AdvShow = Base_GetAdvShowHtml(arr_Fields, arr_Condition, arr_Text);
        this.DataShows();
    }


    protected void Btn_Query_Click(object sender, EventArgs e)
    {
        
        this.DataShows();
    }
    
    protected void Btn_Del_Click(object sender, ImageClickEventArgs e)
    {
        string sql = "delete from Sc_Expend_Manage where"; //删除生产消耗
        string sql1 = "delete from Sc_Expend_Manage_MaterDetails where"; //发货 明细
        string sql2 = "delete from Sc_Expend_Manage_RCDetails where"; //发货 明细

        string cal = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)(GridView1.Rows[i].FindControl("Chbk"));
            if (cb.Checked == true)
            {
                cal += GridView1.DataKeys[i].Value.ToString() + ",";
                    sql += "  SEM_ID='" + GridView1.DataKeys[i].Value.ToString() + "' or";
                    sql1 += " SED_SEMID='" + GridView1.DataKeys[i].Value.ToString() + "' or";
                    sql2 += " SER_SEMID='" + GridView1.DataKeys[i].Value.ToString() + "' or";
            }
        }
        if (cal != "")
        {
            DbHelperSQL.ExecuteSql(sql.Substring(0, sql.Length-2));
            DbHelperSQL.ExecuteSql(sql1.Substring(0, sql1.Length - 2));
            DbHelperSQL.ExecuteSql(sql2.Substring(0, sql2.Length - 2));

            AdminloginMess LogAM = new AdminloginMess();
            LogAM.Add_Logs("生产--->生产消耗--->生产消耗删除 操作成功！");

            this.DataShows();
        }
        else
        {
            sql = "";       //不删除
            sql1 = "";       //不删除
            sql2 = "";       //不删除
            Response.Write("<script language=javascript>alert('您没有选择要删除的记录!');history.back(-1);</script>");
            Response.End();
        }

    }
    protected void lbtn_Del_Click(object sender, EventArgs e)
    {
        
    }
}
