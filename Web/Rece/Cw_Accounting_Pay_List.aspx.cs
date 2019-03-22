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

public partial class Cw_Accounting_Pay_List : BasePage
{
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("收款单列表") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
            else
            {
                base.Base_DropBatchBind(this.Ddl_Batch, "Cw_Accounting_Pay", "CAA_DutyPerson");
                this.Btn_Del.Attributes.Add("onclick", "return confirm('你确信要删除所选记录吗?！')");
                base.Base_DropBindSearch(this.bas_searchfield, "Cw_Accounting_Pay");
                base.Base_DropBindSearch(this.Fields, "Cw_Accounting_Pay");
                DataShows();
            }
        }

    }

    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        AdminloginMess AM = new AdminloginMess();
        string s_SqlWhere = "  CAA_Type='1'  ";

        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string s_Type = "";
        if (s_WhereID != "")
        {
            s_SqlWhere += Base_GetBasicWhere(s_WhereID);
        }
        if (this.Ddl_Batch.SelectedValue != "")
        {
            s_SqlWhere += Base_GetBasicWhere(this.Ddl_Batch.SelectedValue);
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
        //收款单仅
        if (AM.YNAuthority("查看全部收款单") == false)
        {
            s_SqlWhere += " and CAP_Type=0 and CAA_CustomerValue<>'' ";
        }
        //仅查看自己
        if (AM.YNAuthority("收款单仅责任人查看") == true)
        {
            if (AM.KNet_StaffName != "薛建新")
            {
                s_SqlWhere += " and CAA_CustomerValue in (Select CustomerValue from KNet_Sales_ClientList where KSC_DutyPerson='" + AM.KNet_StaffNo + "' ) ";
            }
        }
        s_SqlWhere += " Order by CAA_CTime desc";
        KNet.BLL.Cw_Accounting_Pay bll = new KNet.BLL.Cw_Accounting_Pay();
        DataSet ds = bll.GetList(s_SqlWhere);
        this.MyGridView1.DataSource = ds;
        MyGridView1.DataKeyNames = new string[] { "CAA_ID" };
        MyGridView1.DataBind();
    }

    protected void Ddl_Batch_TextChanged1(object sender, EventArgs e)
    {
        this.DataShows();
    }
    protected void Btn_Query_Click(object sender, EventArgs e)
    {
        this.DataShows();

    }


    /// <summary>
    /// 添加提示
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_DataRowBinding(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string s_ID = this.MyGridView1.DataKeys[e.Row.RowIndex].Value.ToString(); //获取ID值
            CheckBox cb = (CheckBox)e.Row.Cells[1].FindControl("Chbk");
            if (GethxDetails(s_ID) == true)
            {
                cb.Enabled = false;
                e.Row.Cells[13].Text = "<font color=red>不可修改</font>";
            }
            else
            {
                cb.Enabled = true;
            }
        }
    }
    private bool GethxDetails(string s_Id)
    {
        bool b_true = false;
        try
        {
            string s_Sql = "Select * from Cw_Bill_DirectOut_PayDetails where CBDP_PayMentID='" + s_Id + "'";
            this.BeginQuery(s_Sql);
            DataTable Dtb_table = (DataTable)this.QueryForDataTable();
            if (Dtb_table.Rows.Count > 0)
            {
                b_true = true;
            }
        }
        catch
        { }
        return b_true;
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
                    s_Sql.Append(" delete from  Cw_Bill_DirectOut_PayDetails Where CBDP_PayMentID='" + s_ID + "'  ");
                    s_Sql.Append(" delete from  Cw_Accounting_Pay_Details Where CAY_CAAID='" + s_ID + "'  ");
                    s_Sql.Append(" delete from  Cw_Accounting_Pay Where CAA_ID='" + s_ID + "'  ");
                    s_Log.Append(s_ID);
                }
            }
            DbHelperSQL.ExecuteSql(s_Sql.ToString());
            this.DataShows();
            AdminloginMess AM = new AdminloginMess();
            AM.Add_Logs("Cw_Accounting_Pay 删除 编号：" + s_Log + "");
            Alert("删除成功！");
        }
        catch (Exception ex)
        {
            Alert("删除失败！" + ex.Message);
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
        s_AdvShow = Base_GetAdvShowHtml(arr_Fields, arr_Condition, arr_Text);
        this.DataShows();
    }

    public string GetState(string s_ID)
    {
        string s_Return = "";
        try
        {
            KNet.BLL.Cw_Accounting_Pay bll = new KNet.BLL.Cw_Accounting_Pay();
            KNet.Model.Cw_Accounting_Pay model = bll.GetModel(s_ID);
            if (model.CAP_Type == 0)
            {

                if (model.CAA_leftMoney == 0)
                {
                    s_Return = "<a href=\"Cw_Accounting_Pay_WithDirectOut.aspx?ID=" + s_ID + "\"><font color=red>已核销</font></a>";

                }
                else if (model.CAA_DetailsTotalMoney > 0)
                {
                    s_Return = "<a href=\"Cw_Accounting_Pay_WithDirectOut.aspx?ID=" + s_ID + "\"><font color=green>部分核销</font></a>";
                }
                else
                {
                    s_Return = "<a href=\"Cw_Accounting_Pay_WithDirectOut.aspx?ID=" + s_ID + "\">核销</a>";
                }
            }
        }
        catch
        { }
        return s_Return;
    }
}
