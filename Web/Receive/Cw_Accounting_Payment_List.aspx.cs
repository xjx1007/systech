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

using System.Data.SqlClient;
using System.Runtime.Serialization.Json;

using KNet.DBUtility;
using KNet.Common;
using System.Net;

public partial class Cw_Accounting_Payment_List : BasePage
{
    public string s_AdvShow = "", s_Title = "应收款计划列表";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string s_Type=Request.QueryString["Type"]==null?"":Request.QueryString["Type"].ToString();

            if (s_Type != "")
            {
 
            }
            AdminloginMess AM = new AdminloginMess();

            if (AM.CheckLogin(s_Title) == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
            else
            {
                base.Base_DropBatchBind(this.Ddl_Batch, "Cw_Accounting_Payment", "CAP_DutyPerson");
                this.Btn_Del.Attributes.Add("onclick", "return confirm('你确信要删除所选记录吗?！')");
                base.Base_DropBindSearch(this.bas_searchfield, "Cw_Accounting_Payment");
                base.Base_DropBindSearch(this.Fields, "Cw_Accounting_Payment");
                DataShows();
            }
        }
        
    }

    protected string GetOutWareListfollowup(object OutWareNo, object DirectOutNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select top 1 ID,FollowNo,OutWareNo,FollowDateTime,FollowStaffNo,FollowText,FollowEnd from KNet_Sales_OutWareList_FlowList where OutWareNo='" + OutWareNo + "' order by FollowDateTime desc";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["FollowEnd"].ToString() == "True")
                {
                    return "<img src=\"../images/takman.gif\" width=\"11\" height=\"14\" border=\"0\" /><a href=\"#\" style=\"line-height: 22px;\" onclick=\"lhgdialog.opendlg('发货单号:<font color=Red>" + OutWareNo + "</font> 跟踪', '../SalesOut/Knet_Sales_Ship_Manage_Talks_List.aspx?OutWareNo=" + OutWareNo + "', 780, 500,false,false);\">" + KNetPage.CutString(dr["FollowText"].ToString().Trim(), 40) + "</a>&nbsp;<font color=red>结束</font><a href=\"#\" onclick=\"lhgdialog.opendlg('发货单号:<font color=Red>" + OutWareNo + "</font> 跟踪', '../SalesOut/Knet_Sales_Ship_Manage_Talks_Add.aspx?OutWareNo=" + OutWareNo + "&DirectOutNo=" + DirectOutNo + "', 780, 500,false,false);\">添加</a>";//&nbsp;<font color=\"gray\">" + base.Base_GetUserName(dr["FollowStaffNo"].ToString()) + "&nbsp;(" + dr["FollowDateTime"].ToString() + ")</font>
                }
                else
                {
                    return "<img src=\"../images/takman.gif\" width=\"11\" height=\"14\" border=\"0\" /><a href=\"#\" style=\"line-height: 22px;\" onclick=\"lhgdialog.opendlg('发货单号:<font color=Red>" + OutWareNo + "</font> 跟踪', '../SalesOut/Knet_Sales_Ship_Manage_Talks_List.aspx?OutWareNo=" + OutWareNo + "', 780, 500,false,false);\">" + KNetPage.CutString(dr["FollowText"].ToString().Trim(), 40) + "</a>&nbsp;<img src=\"../images/45.gif\" width=\"11\" height=\"11\" border=\"0\" /><a href=\"#\" onclick=\"lhgdialog.opendlg('发货单号:<font color=Red>" + OutWareNo + "</font> 跟踪', '../SalesOut/Knet_Sales_Ship_Manage_Talks_Add.aspx?OutWareNo=" + OutWareNo + "&DirectOutNo=" + DirectOutNo + "', 780, 500,false,false);\">添加</a>";
                }
            }
            else
            {
                return "<a href=\"#\" onclick=\"lhgdialog.opendlg('发货单号:<font color=Red>" + OutWareNo + "</font> 跟踪', '../SalesOut/Knet_Sales_Ship_Manage_Talks_Add.aspx?OutWareNo=" + OutWareNo + "&DirectOutNo=" + DirectOutNo + "', 780, 500,false,false);\">添加</a>";
            }
        }
    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        string s_SqlWhere = " CAP_Type=1 ";

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
        s_SqlWhere += " Order by CAP_MTime desc";
        KNet.BLL.Cw_Accounting_Payment bll = new KNet.BLL.Cw_Accounting_Payment();
        DataSet ds = bll.GetList(s_SqlWhere);
        this.MyGridView1.DataSource = ds;
        MyGridView1.DataKeyNames = new string[] { "CAP_ID" };
        MyGridView1.DataBind();
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
            KNet.BLL.Cw_Account_Bill Bll = new KNet.BLL.Cw_Account_Bill();
            DataSet Dts_Table = Bll.GetList(" CAB_CAPID='" + s_ID + "'");
            if (Dts_Table.Tables[0].Rows.Count>0)
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
                    s_Sql.Append(" delete from  Cw_Accounting_Payment Where CAP_ID='" + s_ID + "'  ");
                    s_Sql.Append(" delete from  KNet_WareHouse_DirectOutList_Details Where  DirectOutNo in (Select  DirectOutNo from KNet_WareHouse_DirectOutList Where DirectOutTopic='" + s_ID + "' )  ");
                    s_Sql.Append(" delete from  KNet_WareHouse_DirectOutList Where DirectOutTopic='" + s_ID + "'  ");
                    s_Sql.Append(" delete from  Cw_Accounting_PaymentDetails Where CAPD_CARID='" + s_ID + "'  ");
                    s_Log.Append(s_ID);
                }
            }
            DbHelperSQL.ExecuteSql(s_Sql.ToString());
            this.DataShows();
            AdminloginMess AM = new AdminloginMess();
            AM.Add_Logs("Cw_Accounting_Payment 删除 编号：" + s_Log + "");
            Alert("删除成功！");
        }
        catch (Exception ex)
        {
            Alert("删除失败！"+ex.Message);
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
    public string GetPayTime(string s_ID)
    {
        string s_Return = "";
        try
        {
            this.BeginQuery(" Select b.CAA_PayTime from Cw_Accounting_Pay_Details a join Cw_Accounting_Pay b on a.CAY_CAAID=b.CAA_ID where a.CAY_CAPID='" + s_ID + "' ");
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            for (int i = 0; i < Dtb_Table.Rows.Count; i++)
            {
                s_Return += DateTime.Parse(Dtb_Table.Rows[0][0].ToString()).ToShortDateString()+",";
            }
            s_Return = s_Return.Substring(0, s_Return.Length - 1);
        }
        catch { }
        return s_Return;
    }
    public string GetCheckYN(string s_ID)
    {
        string s_Return = "";
        try 
        {
            string StrPop = "", JSD="";
            KNet.BLL.Cw_Accounting_Payment Bll_Payment = new KNet.BLL.Cw_Accounting_Payment();
            KNet.Model.Cw_Accounting_Payment Model_Payment = Bll_Payment.GetModel(s_ID);
            if (Model_Payment.CAP_CheckYN == 1)
            {

                s_Return = "<img src=\"../../images/gou.gif\"  border=\"0\" />";
            }
            else {
                if (Model_Payment.CAP_IsFP == "101")
                {
                    JSD = "Cw_Accounting_Payment_View.aspx?ID=" + s_ID + "";
                    StrPop = "<a href=\"" + JSD + "\"  title=\"点击进行审核操作\">审核</a><br/>等待 <font color=red>" + base.Base_GetUserName(Model_Payment.CAP_DutyPerson) + "</font>  审核";
                    s_Return = StrPop;
                }
                else
                {
                    s_Return = "<font color=red>未通知</font>";
                }
            }
        }
        catch {}
        return s_Return;
    }

    public string Base_GetProductsPattern(string s_StoreNo)
    {
        string s_Return = "";
        string s_Sql = "Select * from Cw_Accounting_PaymentDetails a join KNet_WareHouse_DirectOutList_Details b on a.CAPD_FID=b.ID ";
        s_Sql += " where CAPD_CARID='" + s_StoreNo + "'";
        s_Sql+="order by  ProductsBarCode ";
        this.BeginQuery(s_Sql);
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                s_Return += Base_GetProductsEdition_Link(Dtb_Result.Rows[i]["ProductsBarCode"].ToString()) + "<br>";
            }
            s_Return = s_Return.Substring(0, s_Return.Length - 4);
        }
        return s_Return;
    }


    public string Base_GetProductsPatternNumber(string s_StoreNo)
    {
        string s_Return = "";
        string s_Sql = "Select * from Cw_Accounting_PaymentDetails a join KNet_WareHouse_DirectOutList_Details b on a.CAPD_FID=b.ID ";
        s_Sql += " where CAPD_CARID='" + s_StoreNo + "'";
        s_Sql+="order by  ProductsBarCode ";
        this.BeginQuery(s_Sql);
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                s_Return += base.FormatNumber1(Dtb_Result.Rows[i]["CAPD_Number"].ToString(),0) + "<br>";
            }
            s_Return = s_Return.Substring(0, s_Return.Length - 4);
        }
        return s_Return;
    }

    public string Base_GetProductsNotPatternNumber(string s_StoreNo)
    {
      
        string s_Return = "";
        string s_Sql = "Select * from Cw_Accounting_PaymentDetails a join KNet_WareHouse_DirectOutList_Details b on a.CAPD_FID=b.ID ";
        s_Sql += " where CAPD_CARID='" + s_StoreNo + "'";
        s_Sql += "order by  ProductsBarCode ";
        this.BeginQuery(s_Sql);
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                s_Return += base.FormatNumber1((Convert.ToDecimal(Dtb_Result.Rows[i]["DirectOutAmount"].ToString())-Convert.ToDecimal(Dtb_Result.Rows[i]["CAPD_Number"].ToString())).ToString() , 0) + "<br>";
            }
            s_Return = s_Return.Substring(0, s_Return.Length - 4);
        }
        return s_Return;
    }
}
