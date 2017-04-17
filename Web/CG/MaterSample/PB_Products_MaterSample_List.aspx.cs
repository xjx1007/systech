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
using System.Text;
public partial class CG_ApplicationPayment_For_List : BasePage
{
    public string s_DivStyle = "";
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("用款申请列表") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
            else
            {
                DataShows();
                base.Base_DropBatchBind(this.Ddl_Batch, "CG_ApplicationPayment_For", "CAF_DutyPerson");
                this.Btn_Del.Attributes.Add("onclick", "return confirm('你确信要删除所选记录吗?！')");
                base.Base_DropBindSearch(this.bas_searchfield, "CG_ApplicationPayment_For");
                base.Base_DropBindSearch(this.Fields, "CG_ApplicationPayment_For");
            }
        }
        
    }

    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        AdminloginMess AM=new AdminloginMess();
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

        //仅自己查看
        if (AM.YNAuthority("查看本部门用款申请"))
        {
            s_SqlWhere += " and CAF_Creator in (select StaffNo from KNet_Resource_Staff where StaffDepart='" + AM.KNet_StaffDepart + "' )";
        }
        else
        {
            //仅自己查看
            if (AM.YNAuthority("查看全部用款申请") == false)
            {
                s_SqlWhere += " and CAF_Creator='" + AM.KNet_StaffNo + "'";
            }
        }
        s_SqlWhere += " order by CAF_MTime desc";
        KNet.BLL.CG_ApplicationPayment_For bll = new KNet.BLL.CG_ApplicationPayment_For();
        DataSet ds = bll.GetList(s_SqlWhere);
        this.MyGridView1.DataSource=ds;
        MyGridView1.DataKeyNames = new string[] { "CAF_ID" };
        MyGridView1.DataBind();
    }

    protected void Btn_Query_Click(object sender, EventArgs e)
    {
        this.DataShows();
    }
    public string getFKState(string s_FID)
    {
        string s_Return = "";
        try{
            this.BeginQuery("Select * from Cw_Accounting_Pay where CAA_FID='" + s_FID + "'");
            DataTable Dtb_Table=(DataTable)this.QueryForDataTable();
            if (Dtb_Table.Rows.Count > 0)
            {
                s_Return = "<font color=green>已付款</font>";

            }
            else
            {
                s_Return = "<a href=\"/Web/Pay/Cw_Accounting_Pay_Add.aspx?FID=" + s_FID + "\" class=\"webMnu\" target=\"_blank\"><font color=red>未付款</font></a>";
            }
        }
        catch{}
        return s_Return;
 
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
                    string s_ID = MyGridView1.DataKeys[i].Value.ToString();
                    s_Sql.Append(" delete from  CG_ApplicationPayment_For Where CAF_ID='" + s_ID + "' ");
                    s_Log.Append(s_ID);
                }
            }
            DbHelperSQL.ExecuteSql(s_Sql.ToString());
            this.DataShows();
            AdminloginMess AM = new AdminloginMess();
            AM.Add_Logs("CG_ApplicationPayment_For 删除 编号：" + s_Log + "");
            Alert("删除成功！");
        }
        catch (Exception ex)
        {
            Alert("删除失败！");
            return;
        }
    }

    protected void Ddl_Batch_TeCAFhanged(object sender, EventArgs e)
    {
        this.DataShows();
    }

    public string GetName(string s_ID,string s_Name)
    {
        string s_Return = "";
        if (s_ID=="")
        {
            s_Return = s_Name;
        }
        else
        {
            if (base.Base_GetCustomerName(s_ID) == "--")
            {
                s_Return = base.Base_GetSupplierName_Link(s_ID);
            }
            else
            {
                s_Return = base.Base_GetCustomerName_Link(s_ID);
            }
        }
        return s_Return;
    }

    public string getShState(string s_ID)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            string s_CgState = "";
            AdminloginMess AM = new AdminloginMess();
            conn.Open();
            string Dostr = "select CAF_State,CAF_DutyPerson from CG_ApplicationPayment_For where CAF_ID='" + s_ID + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string JSD = "CG_ApplicationPayment_For_View.aspx?ID=" + s_ID.ToString() + "";
                //先查询是否需要部门审批
                KNet.BLL.KNet_Resource_Staff Bll = new KNet.BLL.KNet_Resource_Staff();
                KNet.Model.KNet_Resource_Staff Model = Bll.GetModelC(dr["CAF_DutyPerson"].ToString());
                if (Model.StaffDepart == "129652784259578018")
                {
                    if ((dr["CAF_State"].ToString() == "0"))
                    {
                        //供应链部门审批
                        this.BeginQuery("select * from KNet_Sales_Flow a join KNet_Resource_Staff b on a.KSF_ShPerson=b.StaffNo Where  KSF_ContractNo='" + s_ID.ToString() + "' and StaffDepart='" + 129652784259578018 + "' and KSF_Del='0'");
                        this.QueryForDataTable();
                        string StrPop = "";
                        if (this.Dtb_Result.Rows.Count <= 0)
                        {
                            //下个审批部门
                            if ((AM.KNet_StaffDepart == "129652784259578018") && (AM.KNet_Position == "102"))
                            {
                                StrPop = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=700,height=450');\"  title=\"点击进行审核操作\">审核</a><br/>等待 <font color=red>" + base.Base_GeDept("129652784259578018") + "</font>  审核";
                                return StrPop;
                            }
                            else
                            {
                                return "等待 " + base.Base_GeDept("129652784259578018") + " 审核";
                            }
                        }
                    }
                }
                
                if (dr["CAF_State"].ToString() == "2")
                {
                    string StrPop = "<img src=\"../../images/gou.gif\"  border=\"0\" />"; ;
                    return StrPop;
                }
                else if ((dr["CAF_State"].ToString() == "0") || (dr["CAF_State"].ToString() == "1") )
                {
                    //下个审批部门
                    string s_DeptID = Base_GetNextDept(s_ID.ToString(), "111");
                    this.BeginQuery("select * from KNet_Sales_Flow a join KNet_Resource_Staff b on a.KSF_ShPerson=b.StaffNo Where KSF_State in (3,4)  and KSF_ContractNo='" + s_ID.ToString() + "' and StaffDepart='" + s_DeptID + "' and KSF_Del='0'");
                    this.QueryForDataTable();
                    string StrPop = "";
                    if (this.Dtb_Result.Rows.Count > 0)
                    {
                        StrPop = "" + base.Base_GeDept(s_DeptID) + " <font color=Blue>不通过</font> <a href=\"CG_ApplicationPayment_For_List.aspx?ID=" + s_ID + "\">重新提交</a>";
                        return StrPop;
                    }
                    else
                    {
                        //下个审批部门
                        if ((s_DeptID == AM.KNet_StaffDepart) && (AM.KNet_Position == "102"))
                        {
                            StrPop = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=700,height=450');\"  title=\"点击进行审核操作\">审核</a><br/>等待 <font color=red>" + base.Base_GeDept(s_DeptID) + "</font>  审核";
                            return StrPop;
                        }
                        else
                        {
                            return "等待 " + base.Base_GeDept(s_DeptID) + " 审核";
                        }
                    }
                }
                else
                {
                    string StrPop = "<Font Color=red>不通过</font><br/><a href=\"CG_ApplicationPayment_For_List.aspx?ID=" + s_ID + "\">重新提交</a>"; ;
                    return StrPop;
                }
            }
            else
            {
                return "--";
            }
        }
    }

    protected void GridView1_DataRowBinding(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string ID = this.MyGridView1.DataKeys[e.Row.RowIndex].Value.ToString(); //获取ID值
            CheckBox cb = (CheckBox)e.Row.Cells[1].FindControl("Chbk");

            KNet.BLL.CG_ApplicationPayment_For bll = new KNet.BLL.CG_ApplicationPayment_For();
            KNet.Model.CG_ApplicationPayment_For Model = bll.GetModel(ID);
            if (Model.CAF_State != 0)
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
