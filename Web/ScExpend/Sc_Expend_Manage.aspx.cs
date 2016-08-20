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
public partial class Sc_Expend_Manage : BasePage
{
    public string s_DivStyle = "";
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("生产入库列表") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }

            string s_ContractNo = Request.QueryString["ContractNo"] == null ? "" : Request.QueryString["ContractNo"].ToString();
            // this.Tbx_ContractNo.Text = s_ContractNo;
            //
            if (AM.YNAuthority("删除生产入库") == false)
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
        string SqlWhere = " isnull(SEM_Type,0)=0 ";
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
        SqlWhere = SqlWhere + " order by SEM_Ctime desc";

        DataSet ds = bll.GetList(SqlWhere);

        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "SEM_ID" };
        GridView1.DataBind();
    }


    protected void GridView1_DataRowBinding(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string SEMID = this.GridView1.DataKeys[e.Row.RowIndex].Value.ToString(); //获取ID值
            CheckBox cb = (CheckBox)e.Row.Cells[1].FindControl("Chbk");

            KNet.BLL.Sc_Expend_Manage bll = new KNet.BLL.Sc_Expend_Manage();
            KNet.Model.Sc_Expend_Manage Model = bll.GetModel(SEMID);
            if (Model.SEM_CheckYN != 0)
            {
                cb.Enabled = false;
            }
            else
            {
                cb.Enabled = true;
            }
        }
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
        s_AdvShow = Base_GetAdvShowHtml(arr_Fields, arr_Condition, arr_Text, "Sc_Expend_Manage");
        this.DataShows();
    }


    protected void Btn_Query_Click(object sender, EventArgs e)
    {

        this.DataShows();
    }

    protected string GetOrderCheckYN(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select SEM_CheckYN from Sc_Expend_Manage where SEM_ID='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                if (dr["SEM_CheckYN"].ToString() == "2")
                {
                    return "<font color=red>财务</font>";
                }
                else if (dr["SEM_CheckYN"].ToString() == "1")
                {
                    return "<img src=\"../../images/gou.gif\"  border=\"0\" />";
                }
                else
                {
                    string StrPop = "<font color=red>未审核</font>";
                    return StrPop;
                }
            }
            else
            {
                return "--";
            }
        }
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
                sql += "  SEM_ID='" + GridView1.DataKeys[i].Value.ToString() + "' or ";
                sql1 += " SED_SEMID='" + GridView1.DataKeys[i].Value.ToString() + "' or ";
                sql2 += " SER_SEMID='" + GridView1.DataKeys[i].Value.ToString() + "' or ";
            }
        }
        if (cal != "")
        {
            DbHelperSQL.ExecuteSql(sql.Substring(0, sql.Length - 3));
            DbHelperSQL.ExecuteSql(sql1.Substring(0, sql1.Length - 3));
            DbHelperSQL.ExecuteSql(sql2.Substring(0, sql2.Length - 3));

            AdminloginMess LogAM = new AdminloginMess();
            Alert("删除成功！");
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
    public string GetOrderNo(string s_ID)
    {
        string s_Return = "";
        try
        {
            this.BeginQuery("select * from Sc_Expend_Manage_RCDetails a join Knet_Procure_OrdersList_Details b on a.SER_OrderDetailID=b.ID where SER_SEMID='" + s_ID + "' ");
            this.QueryForDataSet();
            DataSet Dts_RC = this.Dts_Result;
            if (Dts_RC.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_RC.Tables[0].Rows.Count; i++)
                {
                    s_Return += "<a href=\"/Web/CG/Order/Knet_Procure_OpenBilling_View.aspx?ID=" + Dts_RC.Tables[0].Rows[i]["OrderNo"].ToString() + "\" target=\"_blank\">" + Dts_RC.Tables[0].Rows[i]["OrderNo"].ToString() + "</a><Br/>";
                }
            }
        }
        catch
        { }
        return s_Return;

    }
    public string GetPrint(string s_ID,string s_Number)
    {
        string s_Return = "";
        string s_Sql = "Select SER_ScPrice from Sc_Expend_Manage_RCDetails where SER_SEMID='" + s_ID + "'";
        this.BeginQuery(s_Sql);
        string s_Price = this.QueryForReturn();
        s_Price=s_Price==""?"0":s_Price;
        try
        {

            if (decimal.Parse(s_Price) > 0)
            {
                s_Return = "<a href=\"#\"  onclick=\"QTGPrint('" + s_ID + "')\"><img title=\"查看详细信息\" id=\"Image6\" style=\"border-top-width: 0px; border-right-width: 0px; border-bottom-width: 0px; border-left-width: 0px;\" src=\"../../images/Print1.gif\" border=\"0\"/></a>";
                s_Return += "(" + s_Number + ")";
            }
        }
        catch
        { }
        return s_Return;
    }
    public string GetQTHPrint(string s_ID, string s_Number)
    {
        string s_Return = "";
        string s_Sql = "Select SER_ScPrice from Sc_Expend_Manage_RCDetails where SER_SEMID='" + s_ID + "'";
        this.BeginQuery(s_Sql);
        string s_Price = this.QueryForReturn();
        s_Price = s_Price == "" ? "0" : s_Price;
        try
        {

            if (decimal.Parse(s_Price) > 0)
            {
                s_Return = "<a href=\"#\"  onclick=\"QTHPrint('" + s_ID + "')\"><img title=\"查看详细信息\" id=\"Image7\" style=\"border-top-width: 0px; border-right-width: 0px; border-bottom-width: 0px; border-left-width: 0px;\" src=\"../../images/Print1.gif\" border=\"0\"/></a>";
                s_Return+="("+s_Number+")";
            }
        }
        catch
        { }
        return s_Return;
    }


}
