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
using System.Data.SqlClient;
using KNet.Common;

public partial class Cg_Contract_Manage_List : BasePage
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
                ////合同档案删除"合同档案"
                //if (AM.YNAuthority("删除合同档案") == false)
                //{
                //    this.Btn_Del.Enabled = false;
                //}

                this.Btn_Del.Attributes.Add("onclick", "return confirm('你确信要删除所选记录吗?！')");
                base.Base_DropBindSearch(this.bas_searchfield, "Cg_Contract_Manage");
                base.Base_DropBindSearch(this.Fields, "Cg_Contract_Manage");
                base.Base_DropBatchBind(this.Ddl_Batch, "Cg_Contract_Manage", "CCM_DutyPerson");
                DataShows();
            }
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
        s_SqlWhere += " Order by CCM_MTime Desc ";
        KNet.BLL.Cg_Contract_Manage bll = new KNet.BLL.Cg_Contract_Manage();
        DataSet ds = bll.GetList(s_SqlWhere);
        this.MyGridView1.DataSource = ds;
        MyGridView1.DataKeyNames = new string[] { "CCM_ID" };
        MyGridView1.DataBind();
    }

    protected void GridView1_DataRowBinding(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string s_CCM_ID = MyGridView1.DataKeys[e.Row.RowIndex].Value.ToString(); //获取ID值
            KNet.BLL.Cg_Contract_Manage bll = new KNet.BLL.Cg_Contract_Manage();
            KNet.Model.Cg_Contract_Manage Model = bll.GetModel(s_CCM_ID);
            CheckBox cb = (CheckBox)e.Row.Cells[1].FindControl("Chbk");
            if (Model.CCM_CheckYN==1)
            {
                cb.Enabled = false;
            }
            else
            {
                cb.Enabled = true;
            }
        }
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
                    string s_ID = this.MyGridView1.DataKeys[i].Value.ToString();
                    string s_Code = MyGridView1.Rows[i].Cells[2].Text;
                    s_Sql.Append(" delete from  PB_Basic_Attachment Where PBA_FID='" + s_ID + "' and PBA_Type='Contract'  ");
                    s_Sql.Append(" delete from  Cg_Contract_Manage Where CCM_ID='" + s_ID + "'  ");
                    s_Log.Append(s_ID + " " + s_Code);
                }
            }
            DbHelperSQL.ExecuteSql(s_Sql.ToString());
            this.DataShows();
            AdminloginMess AM = new AdminloginMess();
            AM.Add_Logs("Cg_Contract_Manage 删除 编号：" + s_Log + "");
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
        s_AdvShow = Base_GetAdvShowHtml(arr_Fields, arr_Condition, arr_Text);
        this.DataShows();
    }

    /// <summary>
    /// 返回审核情况（Y）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetCheckYN(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            AdminloginMess AM = new AdminloginMess();
            conn.Open();
            string Dostr = "select CCM_ID,CCM_CheckYN,CCM_Flow from Cg_Contract_Manage where CCM_ID='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["CCM_CheckYN"].ToString() == "1")
                {
                    string StrPop = "<img src=\"../../images/gou.gif\"  border=\"0\" />"; ;
                    return StrPop;
                }
                else
                {
                    string s_Type = dr["CCM_Flow"].ToString();
                    string s_DeptID = Base_GetNextDept(aa.ToString(), s_Type);
                    string s_FlowState =Base_GetNextState(aa.ToString(), s_Type);
                    this.BeginQuery("select * from KNet_Sales_Flow a join KNet_Resource_Staff b on a.KSF_ShPerson=b.StaffNo Where KSF_State='0'   and KSF_ContractNo='" + aa.ToString() + "' and StaffDepart='" + s_DeptID + "' and KSF_Del='0'");
                    this.QueryForDataTable();
                    string JSD = "ContractListCheckYN.aspx?ID=" + aa.ToString() + "&FlowState=" + s_FlowState + "";
                    string StrPop = "";
                    if (this.Dtb_Result.Rows.Count > 0)
                    {
                        JSD = "Cg_Contract_Manage_View.aspx?ID=" + aa.ToString() + "";
                        StrPop = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=700,height=450');\"  title=\"点击进行审核操作\">查看</a><br/> " + base.Base_GeDept(s_DeptID) + " <font color=Blue>不通过</font>";
                        return StrPop;
                    }
                    //下个审批部门
                    if ((s_DeptID == AM.KNet_StaffDepart) && (AM.KNet_Position == "102"))
                    {

                        StrPop = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=700,height=450');\"  title=\"点击进行审核操作\">审核</a><br/>等待 <font color=red>" + base.Base_GeDept(s_DeptID) + "</font>  审核";
                        return StrPop;
                    }
                    else
                    {
                        JSD = "Cg_Contract_Manage_View.aspx?ID=" + aa.ToString() + "";
                        return "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=700,height=450');\"  title=\"点击进行审核操作\">查看</a><br/>等待 <font color=blue>" + base.Base_GeDept(s_DeptID) + "</font> 审核";
                    }
                }
            }
            else
            {
                return "--";
            }
        }
    }
}
