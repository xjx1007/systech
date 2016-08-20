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

public partial class IM_Project_Manage_Details_Logs_List : BasePage
{
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            this.Lbl_Title.Text = "任务列表";
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            this.Btn_Del.Attributes.Add("onclick", "return confirm('你确信要删除所选记录吗?！')");
            base.Base_DropBatchBind(this.Ddl_Batch, "IM_Project_Manage_Details_Logs", "IPM_DutyPerson");
            base.Base_DropBindSearch(this.bas_searchfield, "IM_Project_Manage_Details_Logs");
            base.Base_DropBindSearch(this.Fields, "IM_Project_Manage_DGetetails");

            this.DataShows();
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
    public void DataShows()
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.BLL.IM_Project_Manage_Details_Logs bll = new KNet.BLL.IM_Project_Manage_Details_Logs();
        string s_Sql = "Select *,case when DateDiff(DAY,getdate(),IPMD_EarlyEndTime)<0 then 0 else DateDiff(DAY,getdate(),IPMD_EarlyEndTime) end   as LeftDays,DateDiff(DAY,IPMD_EarlyBeginTime,getdate())  as HaveDays,case when DateDiff(DAY,getdate(),IPMD_EarlyEndTime)<0 then '+<font color=red>'+Cast(DateDiff(DAY, IPMD_EarlyEndTime, getdate()) as varchar(50))+'</font>' else  '0'  end OverDays from IM_Project_Manage_Details_Logs a join IM_Project_Manage b  on a.IPMD_IPMID=b.IPM_Code Where IPMD_Del=0 AND IPMD_Type='1' ";
        
        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string s_Type = "";
        if (s_WhereID != "")
        {
            s_Sql += Base_GetBasicWhere(s_WhereID);
        }
        if (this.Ddl_Batch.SelectedValue != "")
        {
            s_Sql += Base_GetBasicWhere(this.Ddl_Batch.SelectedValue);
        }
        if ((this.bas_searchfield.SelectedValue != "") && (search_text.Text != ""))
        {
            s_Sql += base.Base_GetBasicColumnWhere(this.bas_searchfield.SelectedValue, this.search_text.Text);
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
            s_Sql += base.Base_GetAdvWhere(s_Fields, s_Condition, s_Text, s_Type);
        }
        s_Sql += " Order by IPMD_MTime";
        this.BeginQuery(s_Sql);
        DataSet ds = (DataSet)this.QueryForDataSet();
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "IPMD_ID" };
        GridView1.DataBind();
        ds.Dispose();
    }
    protected void Btn_Del_Click(object sender, EventArgs e)
    {
        string sql = "Update IM_Project_Manage_Details_Logs set IPMD_Del='1' "; //删除
        sql +=" where";
        AdminloginMess LogAM = new AdminloginMess();
        string cal = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {
                cal += " IPMD_ID='" + GridView1.DataKeys[i].Value.ToString() + "' or";
            }
        }
        if (cal != "")
        {
            sql += cal.Substring(0, cal.Length - 3);
        }
        else
        {
            Response.Write("<script language=javascript>alert('您没有选择要删除的记录!');history.back(-1);</script>");
            Response.End();
        }

        DbHelperSQL.ExecuteSql(sql);
        LogAM.Add_Logs("系统设置--->研发--->任务管理删除 操作成功！");
        this.DataShows();
    }
  
    protected void Btn_Search_Click(object sender, EventArgs e)
    {
        this.DataShows();
    }

    protected string GetCheckYN(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            AdminloginMess AM = new AdminloginMess();
            conn.Open();
            string Dostr = "select IPM_ID,IPM_ShState from IM_Project_Manage where IPM_ID='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["IPMD_ShState"].ToString() == "018")
                {
                    string StrPop = "<img src=\"../../images/gou.gif\"  border=\"0\" />"; ;
                    return StrPop;
                }
                else
                {
                    string s_Type ="106";
                    string s_DeptID = Base_GetNextDept(aa.ToString(), s_Type);
                    string s_FlowState = Base_GetNextState(aa.ToString(), s_Type);
                    this.BeginQuery("select * from KNet_Sales_Flow a join KNet_Resource_Staff b on a.KSF_ShPerson=b.StaffNo Where KSF_State='0'   and KSF_ContractNo='" + aa.ToString() + "' and StaffDepart='" + s_DeptID + "' and KSF_Del='0'");
                    this.QueryForDataTable();
                    string JSD = "ContractListCheckYN.aspx?ID=" + aa.ToString() + "&FlowState=" + s_FlowState + "";
                    string StrPop = "";
                    if (this.Dtb_Result.Rows.Count > 0)
                    {
                        JSD = "IM_Project_Manage_View.aspx?ID=" + aa.ToString() + "";
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
                        JSD = "IM_Project_Manage_View.aspx?ID=" + aa.ToString() + "";
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
