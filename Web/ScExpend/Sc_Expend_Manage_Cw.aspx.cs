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
            if (AM.CheckLogin("成品入库单列表") == false)
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

            if (AM.YNAuthority("单据财务审批") == true)
            {
                string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
                if (s_ID != "")
                {
                    KNet.BLL.Sc_Expend_Manage Bll_Sc = new KNet.BLL.Sc_Expend_Manage();
                    KNet.Model.Sc_Expend_Manage Model_Sc = Bll_Sc.GetModel(s_ID);
                    if (Model_Sc != null)
                    {
                        if (Model_Sc.SEM_CheckYN == 1)
                        {
                            string DoSql = "update Sc_Expend_Manage  set SEM_CheckYN=2,SEM_CwCheckStaffNo='" + AM.KNet_StaffNo + "',SEM_CwCheckTime='" + DateTime.Now.ToString() + "'  where  SEM_ID='" + s_ID + "' ";
                            DbHelperSQL.ExecuteSql(DoSql);
                            Alert("审批成功！");
                        }
                        else if (Model_Sc.SEM_CheckYN == 2)
                        {
                            string DoSql = "update Sc_Expend_Manage  set SEM_CheckYN=1,SEM_CwCheckStaffNo='" + AM.KNet_StaffNo + "',SEM_CwCheckTime='" + DateTime.Now.ToString() + "'  where  SEM_ID='" + s_ID + "' ";
                            DbHelperSQL.ExecuteSql(DoSql);
                            Alert("反审批成功！");
                        }
                    }
                    else
                    {
                        KNet.BLL.KNet_WareHouse_DirectInto Bll_DirectInto = new KNet.BLL.KNet_WareHouse_DirectInto();
                        KNet.Model.KNet_WareHouse_DirectInto Model_DirectInto = Bll_DirectInto.GetModelB(s_ID);
                        if (Model_DirectInto.DirectInCheckYN == 1)
                        {
                            string DoSql = "update KNet_WareHouse_DirectInto set DirectInCheckYN=2,DirectInCheckStaffNo='" + AM.KNet_StaffNo + "',KWD_CheckTime='" + DateTime.Now.ToString() + "'  where  DirectInNo='" + s_ID + "' ";
                            DbHelperSQL.ExecuteSql(DoSql);
                            Alert("审批成功！");
                        }
                        else if (Model_DirectInto.DirectInCheckYN == 2)
                        {
                            string DoSql = "update KNet_WareHouse_DirectInto  set DirectInCheckYN=1,DirectInCheckStaffNo='" + AM.KNet_StaffNo + "',KWD_CheckTime='" + DateTime.Now.ToString() + "'  where  DirectInNo='" + s_ID + "' ";
                            DbHelperSQL.ExecuteSql(DoSql);
                            Alert("反审批成功！");
                        }
                    }
                }
            }
            this.DataShows();

        }

    }


    protected void Btn_SpSave(object sender, EventArgs e)
    {

        StringBuilder s_Sql = new StringBuilder();
        StringBuilder s_Log = new StringBuilder();
        AdminloginMess AM = new AdminloginMess();
        try
        {

            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                CheckBox Ckb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
                if (Ckb.Checked)
                {
                    string s_ID = GridView1.DataKeys[i].Value.ToString();

                    if (AM.CheckLogin("财务审核出库单") == true)
                    {
                        KNet.BLL.Sc_Expend_Manage bll = new KNet.BLL.Sc_Expend_Manage();
                        KNet.Model.Sc_Expend_Manage Model = bll.GetModel(s_ID);
                        string s_CheckYN = "2";
                        if (s_CheckYN != "0")
                        {
                            string sql = " update Sc_Expend_Manage  set SEM_CheckYN=" + s_CheckYN + ",SEM_CwCheckStaffNo ='" + AM.KNet_StaffNo + "',SEM_CwCheckTime='" + DateTime.Now.ToString() + "'  where  SEM_ID='" + s_ID + "'  ";
                            DbHelperSQL.ExecuteSql(sql);
                        }
                    }
                    s_Log.Append(s_ID + ",");
                }
            }
            if (s_Log.ToString() == "")
            {
                Alert("未选择出库单！");
            }
            else
            {
                this.DataShows();
                AM.Add_Logs("KNet_WareHouse_DirectOutList 审批 编号：" + s_Log + "");
                Alert("批量审批成功！");
            }
        }
        catch (Exception ex)
        {
            Alert("批量审批失败！");
            return;
        }
    }

    protected void Btn_SpSave1(object sender, EventArgs e)
    {

        StringBuilder s_Sql = new StringBuilder();
        StringBuilder s_Log = new StringBuilder();
        AdminloginMess AM = new AdminloginMess();
        try
        {

            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                CheckBox Ckb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
                if (Ckb.Checked)
                {
                    string s_ID = GridView1.DataKeys[i].Value.ToString();

                    if (AM.CheckLogin("财务审核出库单") == true)
                    {
                        KNet.BLL.Sc_Expend_Manage bll = new KNet.BLL.Sc_Expend_Manage();
                        KNet.Model.Sc_Expend_Manage Model = bll.GetModel(s_ID);
                        string s_CheckYN = "1";
                        if (s_CheckYN != "0")
                        {
                            string sql = " update Sc_Expend_Manage  set SEM_CheckYN=" + s_CheckYN + ",SEM_CwCheckStaffNo ='" + AM.KNet_StaffNo + "',SEM_CwCheckTime='" + DateTime.Now.ToString() + "'  where  SEM_ID='" + s_ID + "'  ";
                            DbHelperSQL.ExecuteSql(sql);
                        }
                    }
                    s_Log.Append(s_ID + ",");
                }
            }
            if (s_Log.ToString() == "")
            {
                Alert("未选择出库单！");
            }
            else
            {
                this.DataShows();
                AM.Add_Logs("KNet_WareHouse_DirectOutList 审批 编号：" + s_Log + "");
                Alert("批量审批成功！");
            }
        }
        catch (Exception ex)
        {
            Alert("批量审批失败！");
            return;
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

        this.BeginQuery("Select * from v_Sc_Expend_Manage where " + SqlWhere);
        DataSet ds = (DataSet)this.QueryForDataSet();
       
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "SEM_ID" };
        GridView1.DataBind();
    }


    protected void GridView1_DataRowBinding(object sender, GridViewRowEventArgs e)
    {
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
            string Dostr = "select SEM_CheckYN from v_Sc_Expend_Manage where SEM_ID='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["SEM_CheckYN"].ToString() == "2")
                {
                    return "<a href=Sc_Expend_Manage_Cw.aspx?ID=" + aa + "><font color=red>反财务审批</font></a>";
                }
                else if (dr["SEM_CheckYN"].ToString() == "1")
                {
                    return "<a href=Sc_Expend_Manage_Cw.aspx?ID=" + aa + "><font color=Blue>财务审批</font></a>";
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

    protected void Btn_Show_Click(object sender, EventArgs e)
    {
        if (this.GridView1.AllowPaging)
        {
            this.Btn_Show.Text = "收缩";
            this.GridView1.AllowPaging = false;
            this.DataShows();
        }
        else
        {
            this.Btn_Show.Text = "显示全部";
            this.GridView1.AllowPaging = true;
            this.DataShows();
        }
    }
    protected void Btn_Del_Click(object sender, ImageClickEventArgs e)
    {
      
    }
    protected void lbtn_Del_Click(object sender, EventArgs e)
    {
        
    }
    public string GetOrderNo(string s_ID)
    {
        string s_Return = "";
        try {
            this.BeginQuery("select * from Sc_Expend_Manage_RCDetails a join Knet_Procure_OrdersList_Details b on a.SER_OrderDetailID=b.ID where SER_SEMID='" + s_ID + "' ");
            this.QueryForDataSet();
            DataSet Dts_RC = this.Dts_Result;
            if (Dts_RC.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_RC.Tables[0].Rows.Count; i++)
                {
                    s_Return+="<a href=\"../Order/Knet_Procure_OpenBilling_View.aspx?ID="+ Dts_RC.Tables[0].Rows[i]["OrderNo"].ToString()+"\">"+ Dts_RC.Tables[0].Rows[i]["OrderNo"].ToString()+"</a><Br/>";
                }
            }
        }
        catch
        { }
        return s_Return;
        
    }
}
