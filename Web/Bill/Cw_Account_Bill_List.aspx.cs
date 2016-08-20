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

public partial class Cw_Account_Bill_List : BasePage
{
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
            else
            {
                DataShows();
                this.Btn_Del.Attributes.Add("onclick", "return confirm('你确信要删除所选记录吗?！')");
                base.Base_DropBindSearch(this.bas_searchfield, "Cw_Account_Bill");
                base.Base_DropBindSearch(this.Fields, "Cw_Account_Bill");
                base.Base_DropBatchBind(this.Ddl_Batch, "Cw_Account_Bill", "CAI_DutyPerson");
            }
        }

    }

    protected void GridView1_DataRowBinding(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string s_Details = "0";
            string ID = this.MyGridView1.DataKeys[e.Row.RowIndex].Value.ToString(); //获取ID值
            
            KNet.BLL.Cw_Account_Bill BLL=new KNet.BLL.Cw_Account_Bill();
            KNet.Model.Cw_Account_Bill Model = BLL.GetModel(ID);
            CheckBox cb = (CheckBox)e.Row.Cells[1].FindControl("Chbk");
            try
            {

                string s_Sql = "select Sum(v_HxMoney) from v_FPhx_Money";
                s_Sql += "   where CAB_ID in('" + ID + "')";
                this.BeginQuery(s_Sql);
                s_Details = this.QueryForReturn();
                if ((decimal.Parse(s_Details == "" ? "0" : s_Details) > 0)||(Model.CAB_ChchekYN==1))
                {
                    cb.Enabled = false;
                    e.Row.Cells[12].Text = "<font color=red>不能修改</font>";
                }
                else
                {
                    cb.Enabled = true;
                }
            }
            catch
            { }
        }
    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        string s_SqlWhere = " 1=1";

        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string s_Type = "";
        if (s_WhereID != "")
        {
            s_SqlWhere += Base_GetBasicWhere(s_WhereID);
        }

        if ((this.bas_searchfield.SelectedValue != "") && (search_text.Text != ""))
        {
            s_SqlWhere += base.Base_GetBasicColumnWhere(this.bas_searchfield.SelectedValue, this.search_text.Text);
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
            s_SqlWhere += base.Base_GetAdvWhere(s_Fields, s_Condition, s_Text, s_Type);
        }
        if (this.Ddl_Batch.SelectedValue != "")
        {
            s_SqlWhere += Base_GetBasicWhere(this.Ddl_Batch.SelectedValue);

        }
        KNet.BLL.Cw_Account_Bill bll = new KNet.BLL.Cw_Account_Bill();
        DataSet ds = bll.GetList(s_SqlWhere);
        this.MyGridView1.DataSource = ds;
        MyGridView1.DataKeyNames = new string[] { "CAB_ID" };
        MyGridView1.DataBind();

        decimal d_totalNum = 0, d_totalMoney = 0, d_TotalTaxMoney = 0;
        try
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                d_totalMoney += decimal.Parse(ds.Tables[0].Rows[i]["CAB_Money"].ToString() == "" ? "0" : ds.Tables[0].Rows[i]["CAB_Money"].ToString());
            }
        }
        catch (Exception ex)
        {
        }
        Lbl_Total.Text = "总金额：<font color=red>" + d_totalMoney.ToString() + "</font> ";

    }

    protected void Btn_Query_Click(object sender, EventArgs e)
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
                    string s_ID = this.MyGridView1.DataKeys[i].Value.ToString();
                    s_Sql.Append(" delete from  Cw_Account_Bill_Outimes Where CAO_CADID='" + s_ID + "' ");
                    s_Sql.Append(" delete from  Cw_Account_Bill_Details Where CAD_CAAID='" + s_ID + "' ");
                    s_Sql.Append(" delete from  Cw_Account_Bill Where CAB_ID='" + s_ID + "' ");
                    s_Log.Append(s_ID);
                }
            }
            DbHelperSQL.ExecuteSql(s_Sql.ToString());
            this.DataShows();
            AdminloginMess AM = new AdminloginMess();
            AM.Add_Logs("Cw_Account_Bill 删除 编号：" + s_Log + "");
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
    public string GetDirectOutNo(string s_ID)
    {
        string s_Return = "";
        try
        {
            string s_Sql = "Select DirectOutNo from Cw_Account_Bill_Details a,KNet_WareHouse_DirectOutList_Details b where a.CAD_OutNo=b.ID and a.CAD_CAAID='" + s_ID + "' ";
            this.BeginQuery(s_Sql);
            s_Return= this.QueryForReturn();
        }
        catch
        { }
        return s_Return;
    }
}
