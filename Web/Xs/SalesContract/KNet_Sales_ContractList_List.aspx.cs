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
/// 销售管理-----报价单 管理
/// </summary>
public partial class Knet_Web_Sales_KNet_Sales_ContractList_List : BasePage
{
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("合同评审列表") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            //删除合同评审
            if (AM.YNAuthority("删除合同评审") == false)
            {
                this.Btn_Del.Enabled = false;
            }
            this.Btn_Del.Attributes.Add("onclick", "return confirm('你确信要删除所选记录吗?！\\n\\n注意：该删除会同时删除合同单产品明细记录.')");
            this.Btn_All.Attributes.Add("onclick", "return confirm('你确信要合并所选记录吗?！')");


            base.Base_DropBatchBind(this.Ddl_Batch, "KNet_Sales_ContractList", "DutyPerson");
            base.Base_DropBindSearch(this.bas_searchfield, "KNet_Sales_ContractList");
            base.Base_DropBindSearch(this.Fields, "KNet_Sales_ContractList");
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
        KNet.BLL.KNet_Sales_ContractList bll = new KNet.BLL.KNet_Sales_ContractList();


        string s_SqlWhere = " 1=1 ";
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
        s_SqlWhere = s_SqlWhere + " order by SystemDateTimes desc";
        DataSet ds = bll.GetList(s_SqlWhere);
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "ContractNo" };
        GridView1.DataBind();
    }


    protected void Ddl_Batch_TextChanged(object sender, EventArgs e)
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
        }
    }
    /// <summary>
    /// 单是否已审核
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected bool GetReceivCheckYNEitxt(string ContractNo)
    {
        this.BeginQuery("select * from KNet_Sales_Flow where KSF_ContractNo='" + ContractNo + "'");
        this.QueryForDataTable();
        if (Dtb_Result.Rows.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    /// <summary>
    /// 批量删除记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {

        string sql = "delete from KNet_Sales_ContractList where"; //删除合同
        string sql2 = "delete from KNet_Sales_ContractList_Details where"; //合同 明细

        string cal = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");

            bool b_Checked = true;
            string s_ContractNo = GridView1.DataKeys[i].Value.ToString(); //获取ID值
            KNet.BLL.KNet_Sales_ContractList Bll = new KNet.BLL.KNet_Sales_ContractList();
            KNet.Model.KNet_Sales_ContractList Model = Bll.GetModelB(s_ContractNo);
            string s_contractStaffNo = Model.ContractStaffNo;
            AdminloginMess AM = new AdminloginMess();
            if (AM.KNet_StaffNo != s_contractStaffNo)
            {
                b_Checked = false;
            }
            this.BeginQuery("select * from KNet_Sales_Flow a Where KSF_Del='0' and KSF_State='1' and  KSF_ContractNo='" + s_ContractNo + "'");
            this.QueryForDataTable();
            if ((this.Dtb_Result.Rows.Count <= 0))
            {
                b_Checked = true;
            }
            else
            {
                string s_DeptID = Base_GetNextDept(s_ContractNo, "101");
                this.BeginQuery("select * from KNet_Sales_Flow a join KNet_Resource_Staff b on a.KSF_ShPerson=b.StaffNo Where KSF_State='0'  and KSF_ContractNo='" + s_ContractNo + "' and StaffDepart='" + s_DeptID + "'");
                this.QueryForDataTable();
                if ((this.Dtb_Result.Rows.Count > 0))
                {
                    b_Checked = true;
                }
                else
                {
                    b_Checked = false;
                }
            }
            if ((cb.Checked == true) && (b_Checked == true))
            {
                cal += " ContractNo='" + GridView1.DataKeys[i].Value.ToString() + "' or";

                KNet.BLL.KNet_Sales_ContractList_Details BLL = new KNet.BLL.KNet_Sales_ContractList_Details();
                DataSet ds = BLL.GetList(" ContractNo='" + GridView1.DataKeys[i].Value.ToString() + "' ");

                for (int j = 0; j <= ds.Tables[0].Rows.Count - 1; j++)
                {
                    DataRowView mydrv = ds.Tables[0].DefaultView[j];

                    string ID = mydrv["ID"].ToString();
                    string ProductsBarCode = mydrv["ProductsBarCode"].ToString();
                    string HouseNo = GetHouseNo(GridView1.DataKeys[i].Value.ToString());
                    string OwnallPID = mydrv["OwnallPID"].ToString();
                    try
                    {
                        BLL.Delete(ID);
                    }
                    catch
                    { }
                }
            }
        }
        if (cal != "")
        {
            sql += cal.Substring(0, cal.Length - 3);
            sql2 += cal.Substring(0, cal.Length - 3);
        }
        else
        {
            sql = "";       //不删除
            sql2 = "";       //不删除
            Response.Write("<script language=javascript>alert('您没有选择要删除的记录!');history.back(-1);</script>");
            Response.End();
        }

        DbHelperSQL.ExecuteSql(sql);
        DbHelperSQL.ExecuteSql(sql2);

        AdminloginMess LogAM = new AdminloginMess();
        LogAM.Add_Logs("销售管理--->销售合同管理--->合同单删除 操作成功！");

        this.DataShows();
        this.RowOverYN();
    }


    /// <summary>
    /// 批量删除记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click(object sender, EventArgs e)
    {

        string s_ContractNos = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
            string s_ContractNo = GridView1.DataKeys[i].Value.ToString(); //获取ID值
            if (cb.Checked)
            {
                s_ContractNos += s_ContractNo + ",";
            }
        }

        if (s_ContractNos == "")
        {
            Response.Write("<script>alert('请选择合并订单');</script>");
            Response.End();
        }
        else
        {
            string s_URL = "KNet_Sales_ContractList_AddT.aspx?ContractNos=" + s_ContractNos + "";
            Response.Write("<script>location.href='" + s_URL + "';</script>");
            Response.End();
        }
    }
    /// <summary>
    /// 返回仓库唯一值
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetHouseNo(object ContractNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,ContractNo,HouseNo from KNet_Sales_ContractList where ContractNo='" + ContractNo + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["HouseNo"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }



    /// <summary>
    /// 搜索
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button4_Click(object sender, EventArgs e)
    {
        this.DataShows();
    }


    /// <summary>
    /// 返回采购公司名称（Y）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetStrucNameNane(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,StrucValue,StrucName from KNet_Resource_OrganizationalStructure where StrucValue='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["StrucName"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }
    /// <summary>
    /// 返回审核情况（Y）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetBaoPriceCheckYN(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            string s_CgState = "";
            AdminloginMess AM = new AdminloginMess();
            conn.Open();
            string Dostr = "select ID,ContractNo,ContractCheckYN,DutyPerson,ContractState from KNet_Sales_ContractList where ContractNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string s_DutyPerson = dr["DutyPerson"].ToString();
                if (dr["ContractCheckYN"].ToString() == "True")
                {
                    string JSD = "KNet_Sales_ContractList_View.aspx?ID=" + aa.ToString() + "";
                    string StrPop = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=700,height=450');\"  title=\"点击进行审核操作\">查看</a><img src=\"../../images/gou.gif\"  border=\"0\" />"; ;
                    return StrPop;
                }
                else
                {
                    if (dr["ContractState"].ToString() == "-1")
                    {
                        return "<font color=red>订单取消</font>";
                    }
                    if (dr["ContractState"].ToString() == "-2")
                    {
                        return "<font color=red>需消耗</font>";
                    }
                    else
                    {
                        //等待总经理审批
                        this.BeginQuery("select * from KNet_Sales_Flow a join KNet_Resource_Staff b on a.KSF_ShPerson=b.StaffNo Where (KSF_State='1' or KSF_State='3')   and KSF_ContractNo='" + aa.ToString() + "'  and b.StaffDepart='129652783693249229' and KSF_Del='0'");
                        this.QueryForDataTable();
                        if ((this.Dtb_Result.Rows.Count <= 0) && (AM.KNet_StaffDepart == "129652783693249229"))
                        {
                            string JSD = "ContractListCheckYN.aspx?ContractNo=" + aa.ToString() + "";
                            string StrPop = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=700,height=450');\"  title=\"点击进行审核操作\">审核</a><br/>等待 <font color=red>总经理</font> 审核";

                            return StrPop;
                        }
                        else
                        {

                            string JSD = "KNet_Sales_ContractList_View.aspx?ID=" + aa.ToString() + "";
                            return "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=700,height=450');\"  title=\"点击进行审核操作\">查看</a><br/>等待 <font color=red>总经理</font> 审核";

                        }
                    }

                    /*
                    string s_DeptID = Base_GetNextDept(aa.ToString(), "101",AM.KNet_StaffDepart);
                    string s_Sql1 = "select * from KNet_Sales_Flow a join KNet_Resource_Staff b on a.KSF_ShPerson=b.StaffNo Where KSF_State='0'   and KSF_Del='0'";
                    if (s_DeptID != "")
                    {
                        s_Sql1 += "and KSF_ContractNo='" + aa.ToString() + "'";
                    }
                    this.BeginQuery(s_Sql1);
                    this.QueryForDataTable();
                    string JSD = "ContractListCheckYN.aspx?ContractNo=" + aa.ToString() + "";
                    string StrPop = "";
                    if (this.Dtb_Result.Rows.Count > 0)
                    {
                        JSD = "KNet_Sales_ContractList_View.aspx?ID=" + aa.ToString() + "";
                        string s_Detail = base.Base_GetUserName(Dtb_Result.Rows[0]["KSF_ShPerson"].ToString());
                        StrPop = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=700,height=450');\"  title=\"点击进行审核操作\">查看</a><br/> " + s_Detail + " <font color=Blue>不通过</font>";
                        return StrPop;

                    }
                    //责任人审批
                    if (s_DutyPerson != "")
                    {

                        this.BeginQuery("select * from KNet_Sales_Flow a join KNet_Resource_Staff b on a.KSF_ShPerson=b.StaffNo Where (KSF_State='1' or KSF_State='3')   and KSF_ContractNo='" + aa.ToString() + "'  and b.StaffNo='" + s_DutyPerson + "' and KSF_Del='0'");
                        this.QueryForDataTable();
                        if ((this.Dtb_Result.Rows.Count <= 0) && (AM.KNet_StaffNo == s_DutyPerson))
                        {
                            StrPop = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=700,height=450');\"  title=\"点击进行审核操作\">审核</a><br/>等待 <font color=red>" + base.Base_GetUserName(s_DutyPerson) + "</font> 审核";

                            return StrPop;
                        }
                        else if ((this.Dtb_Result.Rows.Count <= 0) && (AM.KNet_StaffNo != s_DutyPerson))
                        {
                            JSD = "KNet_Sales_ContractList_View.aspx?ID=" + aa.ToString() + "";
                            return "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=700,height=450');\"  title=\"点击进行审核操作\">查看</a><br/>等待 " + base.Base_GetUserName(s_DutyPerson) + " 审核";

                        }
                    }
                    //下个审批部门
                    if ((s_DeptID == AM.KNet_StaffDepart) && (AM.KNet_Position == "102"))
                    {

                        StrPop = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=700,height=450');\"  title=\"点击进行审核操作\">审核</a><br/>等待 <font color=red>" + base.Base_GeDept(s_DeptID) + "</font>  审核";

                        return StrPop;

                    }
                    else
                    {
                        JSD = "KNet_Sales_ContractList_View.aspx?ID=" + aa.ToString() + "";
                        if (s_DeptID == "其他部门")
                        {
                            return "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=700,height=450');\"  title=\"点击进行审核操作\">查看</a><br/>等待 <font color=red>其他部门</font> 审核";
                        }
                        else
                        {
                            return "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=700,height=450');\"  title=\"点击进行审核操作\">查看</a><br/>等待 " + base.Base_GeDept(s_DeptID) + " 审核";
                        }
                    }
                     * */
                }
            }
            else
            {
                return "--";
            }
        }
    }

    public string GetUpdate(string s_ContractNo, string s_contractStaffNo)
    {
        AdminloginMess AM = new AdminloginMess();

        if (AM.KNet_StaffNo != s_contractStaffNo)
        {
            return "<font color=red>不可修改</font>";
        }

        this.BeginQuery("select * from KNet_Sales_Flow a Where KSF_Del='0' and KSF_State='1' and  KSF_ContractNo='" + s_ContractNo + "'");
        this.QueryForDataTable();
        if ((this.Dtb_Result.Rows.Count <= 0))
        {
            return " <a href=\"KNet_Sales_ContractList_Add.aspx?ID=" + s_ContractNo + "\"><img id=\"Image1\" title=\"修改\" src=\"../../images/Edit.gif\" style=\"border-width:0px;\" /></a>";
        }

        string s_DeptID = Base_GetNextDept(s_ContractNo, "101");
        this.BeginQuery("select * from KNet_Sales_Flow a join KNet_Resource_Staff b on a.KSF_ShPerson=b.StaffNo Where KSF_State='0'  and KSF_ContractNo='" + s_ContractNo + "' and StaffDepart='" + s_DeptID + "'");
        this.QueryForDataTable();
        string JSD = "ContractListCheckYN.aspx?ContractNo=" + s_ContractNo + "";
        string StrPop = "";
        if ((this.Dtb_Result.Rows.Count > 0))
        {
            return " <a href=\"KNet_Sales_ContractList_Add.aspx?ID=" + s_ContractNo + "\"><img id=\"Image1\" title=\"修改\" src=\"../../images/Edit.gif\" style=\"border-width:0px;\" /></a>";
        }
        else
        {
            return "<font color=red>不可修改</font>";
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
}
