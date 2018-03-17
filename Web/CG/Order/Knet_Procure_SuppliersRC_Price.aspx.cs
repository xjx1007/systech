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
/// 采购管理-----供应商采购报价 管理
/// </summary>
public partial class Knet_Web_Procure_Knet_Procure_SuppliersRC_Price : BasePage
{
    public string s_DivStyle = "";
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Lbl_Title.Text = "BOM报价列表";
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin(this.Lbl_Title.Text) == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }

            if (AM.YNAuthority("删除BOM报价") == false)
            {
                this.Btn_Del.Enabled = false;
            }
            base.Base_DropBindSearch(this.bas_searchfield, "CSP_ProductsBarCode");
            base.Base_DropBindSearch(this.Fields, "CSP_ProductsBarCode");
            this.Btn_Del.Attributes.Add("onclick", "return confirm('你确信要删除所选记录吗?！')");

            this.DataShows();
            this.RowOverYN();
           
           
        }

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
    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.Cg_Suppliers_Price bll = new KNet.BLL.Cg_Suppliers_Price();

        string SqlWhere = " 1=1 "; 
        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string s_BarCode = Request["BarCode"] == null ? "" : Request["BarCode"].ToString();
        string s_Type = "";

        AdminloginMess AM = new AdminloginMess();

        if (s_WhereID != "")
        {
            SqlWhere += Base_GetBasicWhere(s_WhereID);
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
        if (s_BarCode != "")
        {
            SqlWhere += " and CSP_ProductsBarCode='" + s_BarCode + "'";
        }
        SqlWhere += "  order by CSP_Ctime desc ";
        DataSet ds = bll.GetList(SqlWhere);
            GridView1.DataSource = ds;
            GridView1.DataKeyNames = new string[] { "CSP_ID" };
            GridView1.DataBind();
    }



    /// <summary>
    /// 返回大类名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetBigCateNane(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,BigNo,CateName from KNet_Sys_BigCategories where BigNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["CateName"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }

    protected void Btn_Del_Click(object sender, ImageClickEventArgs e)
    {

        string sql = "Update  Knet_Procure_SuppliersPrice set KPP_Del='1' where";
        string cal = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {
                cal += " ID='" + GridView1.DataKeys[i].Value.ToString() + "' or";
            }
        }
        if (cal != "")
        {
            sql += cal.Substring(0, cal.Length - 3);
        }
        else
        {
            sql = "";       //不删除
            Response.Write("<script language=javascript>alert('您没有选择要删除的记录!');history.back(-1);</script>");
            Response.End();
        }
        DbHelperSQL.ExecuteSql(sql);

        AdminloginMess LogAM = new AdminloginMess();
        LogAM.Add_Logs("采购入库--->供应商报价--->供应商报价记录 删除 操作成功！");

        this.DataShows();
        this.RowOverYN();
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
    public string GetShState(string s_State)
    {
        string s_Return = "";
        s_Return = base.Base_GetBasicCodeName("132", s_State) == "未审核" ? "<font color=red>未审核</font>" : base.Base_GetBasicCodeName("132", s_State);
        return s_Return;
    }

    protected void GridView1_DataRowBinding(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string ID = GridView1.DataKeys[e.Row.RowIndex].Value.ToString(); //获取ID值

            KNet.BLL.Cg_Suppliers_Price Bll = new KNet.BLL.Cg_Suppliers_Price();
            KNet.Model.Cg_Suppliers_Price Model = Bll.GetModel(ID);
            CheckBox cb = (CheckBox)e.Row.Cells[1].FindControl("Chbk");
            if (Model.CSP_State == 1)
            {
                cb.Enabled = false;
            }
            else
            {
                cb.Enabled = true;
            }
        }
    }
}
