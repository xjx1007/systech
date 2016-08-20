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

public partial class Zl_Produce_Problem_List : BasePage
{
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            this.Lbl_Title.Text = "生产问题列表";
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin(this.Lbl_Title.Text) == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }

            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            if (s_ID != "")
            {
                string s_Sql = "Update Knet_Sales_flow Set KSF_Del='1' Where KSF_ContractNo='" + s_ID + "' and KFS_Type='108' ";
                string s_Sql1 = "Update Zl_Produce_Problem Set ZPP_State='0' Where ZPP_ID='" + s_ID + "' ";
                DbHelperSQL.ExecuteSql(s_Sql);
                DbHelperSQL.ExecuteSql(s_Sql1);
                AddFlow(s_ID, 4);
                Alert("提交成功！");
                AM.Add_Logs("质量管理---> 生产问题--->重新提交 操作成功！");
            }
            this.Btn_Del.Attributes.Add("onclick", "return confirm('你确信要删除所选记录吗?！')");
            base.Base_DropBindSearch(this.bas_searchfield, "Zl_Produce_Problem");
            base.Base_DropBindSearch(this.Fields, "Zl_Produce_Problem");
            this.DataShows();
        }
    }

    protected void GridView1_DataRowBinding(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string s_ContractNo = GridView1.DataKeys[e.Row.RowIndex].Value.ToString(); //获取ID值
            KNet.BLL.Zl_Produce_Problem Bll = new KNet.BLL.Zl_Produce_Problem();
            KNet.Model.Zl_Produce_Problem Model = Bll.GetModel(s_ContractNo);
            string s_contractStaffNo = Model.ZPP_Creator;
            CheckBox cb = (CheckBox)e.Row.Cells[1].FindControl("Chbk");
            AdminloginMess AM = new AdminloginMess();
            if (AM.KNet_StaffNo != s_contractStaffNo)
            {
                cb.Enabled = false;
            }
            this.BeginQuery("select * from KNet_Sales_Flow a Where KSF_Del='0' and KSF_State='1' and  KSF_ContractNo='" + s_ContractNo + "'");
            this.QueryForDataTable();
            if ((this.Dtb_Result.Rows.Count <= 0))
            {
                cb.Enabled = true;
            }
            else
            {
                string s_DeptID = Base_GetNextDept(s_ContractNo, "101");
                this.BeginQuery("select * from KNet_Sales_Flow a join KNet_Resource_Staff b on a.KSF_ShPerson=b.StaffNo Where KSF_State='0'  and KSF_ContractNo='" + s_ContractNo + "' and StaffDepart='" + s_DeptID + "'");
                this.QueryForDataTable();
                if ((this.Dtb_Result.Rows.Count > 0))
                {
                    cb.Enabled = true;
                }
                else
                {
                    cb.Enabled = false;
                }
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

        KNet.BLL.Zl_Produce_Problem bll = new KNet.BLL.Zl_Produce_Problem();

        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string s_Type = "";

        string SqlWhere = " 1=1 ";
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
        SqlWhere += " Order by ZPP_MTime desc";
        DataSet ds = bll.GetList(SqlWhere);
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "ZPP_ID" };
        GridView1.DataBind();
        ds.Dispose();
    }

    protected void Btn_Del_Click(object sender, EventArgs e)
    {
        string sql = "delete from  Zl_Produce_Problem  "; //删除
        sql +=" where";
        AdminloginMess LogAM = new AdminloginMess();
        string cal = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {
                cal += " ZPP_ID='" + GridView1.DataKeys[i].Value.ToString() + "' or";
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
        LogAM.Add_Logs("系统设置--->生产问题管理--->生产问题删除 操作成功！");
        this.DataShows();
    }
  
    protected void Btn_Search_Click(object sender, EventArgs e)
    {
        this.DataShows();
    }
    public string getShState(string s_ID)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            string s_CgState = "";
            AdminloginMess AM = new AdminloginMess();
            conn.Open();
            string Dostr = "select * from Zl_Produce_Problem where ZPP_ID='" + s_ID + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string s_DutyDepart = dr["ZPP_DutyDepart"].ToString();
                KNet.BLL.KNet_Resource_Staff Bll_Staff = new KNet.BLL.KNet_Resource_Staff();
                KNet.Model.KNet_Resource_Staff Model_Staff = Bll_Staff.GetModelC(dr["ZPP_DutyPerson"].ToString());
                string s_Depart = Model_Staff.StaffDepart;
                //责任部门
                string JSD = "";
                if ((dr["ZPP_State"].ToString() != "0")&& (dr["ZPP_ClosedState"].ToString() != "0"))
                {
                    string StrPop = "<img src=\"../../images/gou.gif\"  border=\"0\" />"; ;
                    return StrPop;
                }
                else if (dr["ZPP_State"].ToString() == "0")
                {
                    string StrPop = "";

                     JSD = "Zl_Produce_Problem_Add.aspx?ID=" + s_ID.ToString() + "&Type=处理";
                    if ((s_DutyDepart == AM.KNet_StaffDepart) && (AM.KNet_Position == "102"))
                    {
                        StrPop = "<a href=\"" + JSD + "\" >审核</a><br/>等待 <font color=red>" + base.Base_GeDept(s_DutyDepart) + "</font>  审核";
                        return StrPop;

                    }
                    else
                    {
                        return "等待 " + base.Base_GeDept(s_DutyDepart) + " 审核";
                    }
                }
                else if (dr["ZPP_ClosedState"].ToString() == "0")
                {
                    string StrPop = "";
                    JSD = "Zl_Produce_Problem_Add.aspx?ID=" + s_ID.ToString() + "&Type=结案";
                    if ((s_Depart == AM.KNet_StaffDepart) && (AM.KNet_Position == "102"))
                    {
                        StrPop = "<a href=\"" + JSD + "\">审核</a><br/>等待 <font color=red>" + base.Base_GeDept(s_Depart) + "</font>  审核";
                        return StrPop;
                    }
                    else
                    {
                        return "等待 " + base.Base_GeDept(s_Depart) + " 审核";
                    }
                }
                else
                {
                    return "--";
                }
            }
            else
            {
                return "--";
            }
        }
    }


    private void AddFlow(string s_ContractNo, int i_State)
    {

        AdminloginMess AM = new AdminloginMess();
        //插入审核
        KNet.Model.KNet_Sales_Flow Model = new KNet.Model.KNet_Sales_Flow();
        KNet.BLL.KNet_Sales_Flow Bll = new KNet.BLL.KNet_Sales_Flow();
        Model.KFS_Type = 108;
        Model.KSF_ContractNo = s_ContractNo;
        Model.KSF_Date = DateTime.Now;
        Model.KSF_Detail = "";
        Model.KSF_ShPerson = AM.KNet_StaffNo;
        Model.KSF_State = i_State;
        try
        {
            Bll.Add(Model);
        }
        catch
        { throw; }
    }

    public string GetDState(object s_State, string s_ID, string s_DName)
    {
        string s_URL = "";
        try
        {
            s_State = s_State == null ? "0" : s_State.ToString();
            if (s_State.ToString() == "0")
            {
                s_URL = "<a href=\"Zl_Produce_Problem_Add.aspx?ID=" + s_ID + "&Type=" + s_DName + "\"><font color=red>未" + s_DName + "</font></a>";
            }
            else
            {
                s_URL = "<a href=\"Zl_Produce_Problem_Add.aspx?ID=" + s_ID + "&Type=" + s_DName + "\">" + s_DName + "</a>";
            }
        }
        catch { }
        return s_URL;
    }
}
