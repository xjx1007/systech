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
///  人力资源 -----考勤管理 
/// </summary>
public partial class Knet_Web_HR_KNet_AttenDance_OutManger : BasePage
{
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }

            ////内部考勤记录查看
            //if (AM.YNAuthority(NQ.Str5006) == false)
            //{
            //    AM.NoAuthority("5006");
            //}
            ////内部考勤记录删除
            //if (AM.YNAuthority(NQ.Str5008) == false)
            //{
            //    this.Btn_Del.Enabled = false;
            //}

            ViewState["SortOrder"] = "AddDatetime";
            ViewState["OrderDire"] = "Desc";
            this.Btn_Del.Attributes.Add("onclick", "return confirm('你确信要删除所选记录吗?！')");

            base.Base_DropBatchBind(this.Ddl_Batch, "KNet_Resource_OutManage", "StaffNo");
            base.Base_DropBindSearch(this.bas_searchfield, "KNet_Resource_OutManage");
            base.Base_DropBindSearch(this.Fields, "KNet_Resource_OutManage");
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

    protected void Ddl_Batch_TextChanged(object sender, EventArgs e)
    {
        this.DataShows();
    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.KNet_Resource_OutManage bll = new KNet.BLL.KNet_Resource_OutManage();
        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string s_Type = "";
        string SqlWhere = " 1=1 ";
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
        if (this.Ddl_Batch.SelectedValue != "")
        {
            SqlWhere += Base_GetBasicWhere(this.Ddl_Batch.SelectedValue);

        }
        if ((AM.KNet_StaffDepart == "129652783693249229") || (AM.KNet_StaffName == "项洲") || (AM.KNet_StaffName == "邵剑慧"))
        {
            SqlWhere += "";
        }
        else if ((AM.KNet_StaffDepart == "129652783965723459") && (AM.KNet_Position == "102"))//研发中心
        {
            SqlWhere += " and StaffNo in (Select StaffNo from KNet_Resource_Staff where StaffDepart<>'129652783822281241' or StaffNo='129785819485620667'  )";
        }
        else if ((AM.KNet_StaffDepart == "129652784259578018") && (AM.KNet_Position == "102"))//物流部
        {
            SqlWhere += " and StaffNo in (Select StaffNo from KNet_Resource_Staff where StaffDepart='129652784259578018' )";
        }
        else if ((AM.KNet_StaffDepart == "129652783822281241") && (AM.KNet_Position == "102"))//市场销售部
        {
            SqlWhere += " and StaffNo in (Select StaffNo from KNet_Resource_Staff where StaffDepart='129652783822281241' or StaffDepart='129652784116845798' )";
        }
        else
        {
            SqlWhere += " and StaffNo='" + AM.KNet_StaffNo + "'";
        }
        DataSet ds = bll.GetList(SqlWhere);
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "ID" };
        GridView1.DataBind();
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
            Image lk = (Image)e.Row.Cells[1].FindControl("Image1");
            Label LB = (Label)e.Row.Cells[1].FindControl("Label1");
            if (LB.Text.ToString().CompareTo("0") == 0) //（0,新申请，1已批，2否决）
            {
                lk.ImageUrl = "../images/Au0.gif";
                lk.ToolTip = "新申请";
            }
            else if (LB.Text.ToString().CompareTo("1") == 0)
            {
                lk.ImageUrl = "../images/Au1.gif";
                lk.ToolTip = "已审批";
            }
            else if (LB.Text.ToString().CompareTo("3") == 0)
            {
                lk.ImageUrl = "../images/Au1.gif";
                lk.ToolTip = "已审批";
            }
            else
            {
                lk.ImageUrl = "../images/Au2.gif";
                lk.ToolTip = "未通过（拨回）";
            }
            string DID = GridView1.DataKeys[e.Row.RowIndex].Value.ToString(); //获取ID值
            string JSD = "KNet_AttenDance_OutMangerDetails.aspx?ID=" + DID + " ";
           // e.Row.Cells[8].Text = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=750,height=400');\">详细</a>";
        }
    }



    /// <summary>
    /// 批量删除记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {

        string sql = "delete from KNet_Resource_OutManage where";
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
        LogAM.Add_Logs("人力资源--->考勤管理--->考勤记录删除 操作成功！");

        this.DataShows();
        this.RowOverYN();
    }

    /// <summary>
    /// 取消所有已选中列
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            CheckBox ChkB = (CheckBox)GridView1.HeaderRow.Cells[0].FindControl("CheckBox1");
            ChkB.Checked = false;

            foreach (GridViewRow gr in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)gr.Cells[0].FindControl("Chbk");
                chk.Checked = false;

                string DID = GridView1.DataKeys[gr.RowIndex].Value.ToString(); //获取ID值
                string JSD = "KNet_AttenDance_OutMangerDetails.aspx?ID=" + DID + " ";
                gr.Cells[9].Text = "";
            }
            GridView1.EditIndex = -1;
            this.DataShows();
            this.RowOverYN();
        }
        catch { }
    }


    /// <summary>
    /// （1请假，2外出，3出差）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetKinksifno(int aa)
    {
        string Kstr = null;
        switch (aa)
        {
            case 0:
                Kstr = "--";
                break;
            case 1:
                Kstr = "请假";
                break;
            case 2:
                Kstr = "外出";
                break;
            case 3:
                Kstr = "出差";
                break;
            default :
                Kstr = "--";
                break;
        }
        return Kstr;
    }

    /// <summary>
    /// 获取申请者
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetStaffInfo(string StaffNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,StaffNo,StaffCard,StaffName from KNet_Resource_Staff where StaffNo='" + StaffNo + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["StaffName"].ToString().Trim() + " /<font color=#999999>" + dr["StaffCard"].ToString().Trim() + "</font>";
            }
            else
            {
                return "--";
            }
        }
    }

    /// <summary>
    /// 返回公司名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetStaffBranchName(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,StrucValue,StrucName from KNet_Resource_OrganizationalStructure where StrucValue='" + aa + "' and StrucPID='0' ";
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
    /// 返回部门名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetStaffDepartName(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,StrucValue,StrucName from KNet_Resource_OrganizationalStructure where StrucValue='" + aa + "' and StrucPID!='0'";
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
    /// 由姓名或卡号返回查询唯一号
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetStaffStaffNoForSeach(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,StaffCard,StaffName,StaffNo from KNet_Resource_Staff where ( StaffName = '" + aa + "' or StaffCard='" + aa + "')";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["StaffNo"].ToString().Trim();
            }
            else
            {
                return "--";
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
    /// <summary>
    /// 状态 状态（0,新申请，1已批，2否决）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetThisState(int aa,string ID)
    {
        KNet.BLL.KNet_Resource_OutManage bll = new KNet.BLL.KNet_Resource_OutManage();
        AdminloginMess AM = new AdminloginMess();
        KNet.Model.KNet_Resource_OutManage Model = bll.GetModel(ID);
        
        string JSD = "#";
        string StrPop = "";
        switch (aa)
        {
            case 0:
                JSD = "inc/KNet_AttenDance_OutManger_Do.aspx?ID=" + ID + "";
                //市场部审批取消
                //研发中心审批 --129652783822281241 市场部
                if (((Model.StaffDepart == "129652783822281241") || (Model.StaffNo == "129785817669906814")) && (AM.KNet_StaffDepart == "129652783693249229")) 
                {
                    StrPop = "<a target=\"_blank\" href='" + JSD + "'>审批</a><br>等待 <font color=red>总经理</font> 审批";
                }
                else if (((Model.StaffDepart == "129652783822281241") && (AM.KNet_StaffDepart != "129652783693249229"))|| (Model.StaffNo== "129785817669906814"))
                {
                    StrPop = "等待 <font color=red>总经理</font> 审批";
                }
                else if (((AM.KNet_StaffDepart == "129652783965723459") && (AM.KNet_Position == "102") && (Model.StaffNo != AM.KNet_StaffNo)) || (AM.KNet_StaffDepart == "129652783693249229"))
                {
                    StrPop = "<a target=\"_blank\" href='" + JSD + "'>审批</a><br>等待 <font color=red>经理</font> 审批";
                }
                else if ((AM.KNet_StaffDepart == "129652784259578018") && (AM.KNet_Position == "102") && (Model.StaffNo != AM.KNet_StaffNo))
                {
                    StrPop = "<a target=\"_blank\" href='" + JSD + "'>审批</a><br>等待 <font color=red>经理</font> 审批";
                }
                else
                {
                    StrPop = "等待 <font color=red>经理</font> 审批";
                }
             //   StrPop = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=400,height=250');\"  title=\"点击进行审批操作\">审批</a>";
                break;
            case 1:
                JSD = "inc/KNet_AttenDance_OutManger_Do.aspx?ID=" + ID + "";
                StrPop = "<font color=Blue>已批</font>";
                if ((Model.ThisState == 1)&&(Model.ThisKings==3))
                {
                    if (AM.KNet_StaffDepart == "129652783693249229")
                    {
                        StrPop = "<a target=\"_blank\" href='" + JSD + "'>审批</a><br>等待 <font color=red>总经理</font> 审批";
                    }
                    else
                    {
                        StrPop = "等待 <font color=red>总经理</font> 审批";
                    }
                }
                break;

            case 3:
                StrPop = "<font color=Blue>已批</font>";
                break;
            case 2:
                StrPop = "<font color=red>拨回</font>";
                break;
            default:
                StrPop = "--";
                break;
        }
        return  StrPop;
    }
    public string GetView(string s_ID,string s_Type)
    {
        string s_Return = "";
        try
        {
            if (s_Type == "3")
            {
                s_Return = "<a href=\"#\"  onclick=\"javascript:window.open('KNet_HR_Manage_Print.aspx?ID=" + s_ID + "','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');\"><img id=\"Image3\" title=\"查看信息\" border=\"0\" src=\"../../images/View.gif\" style=\"border-width:0px;\" /></a>";
            }
            else
            {
                s_Return = "";
            }
        }
        catch { }
        return s_Return;
    }
    public string GetHx(string s_ID, string s_Type)
    {

        string s_Return = "<a target=\"_blank\" href=\"KNet_AttenDance_OutManger_View.aspx?ID=" + s_ID + "&Kx=0\">未核销</a>";
        try
        {
            KNet.BLL.KNet_Resource_OutManage Bll_OutManage = new KNet.BLL.KNet_Resource_OutManage();
            KNet.Model.KNet_Resource_OutManage Model_OutManage = Bll_OutManage.GetModel(s_ID);
            int i_Content = 0;
            if (s_Type == "3")
            {
                if (Model_OutManage.KRO_IsCheck == 0)
                {
                    KNet.BLL.Xs_Customer_Products Bll_Products = new KNet.BLL.Xs_Customer_Products();
                    DataSet Dts_Table = Bll_Products.GetList(" XCP_ProductsID='" + s_ID + "'");
                    if (Dts_Table.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                        {
                            KNet.BLL.Xs_Sales_Content Bll_Content = new KNet.BLL.Xs_Sales_Content();
                            DataSet Dts_Content = Bll_Content.GetList(" XSC_CustomerValue='" + Dts_Table.Tables[0].Rows[i]["XCP_CustomerID"].ToString() + "' and XSC_STime between '" + Model_OutManage.StartDateTime.ToString().Replace("年", "-").Replace("月", "-").Replace("日", "").Substring(0, 10) + "' and  '" + Model_OutManage.EndDatetime.ToString().Replace("年", "-").Replace("月", "-").Replace("日", "").Substring(0, 10) + "' ");
                            if (Dts_Content.Tables[0].Rows.Count > 0)
                            {
                                i_Content = i_Content + 1;
                            }
                        }
                    }
                }
                else
                {
                    s_Return = "<a target=\"_blank\" href=\"KNet_AttenDance_OutManger_View.aspx?ID=" + s_ID + "&Kx=1\"><font color=red>已核销</font></a>";
                }
            }
            else
            {
                s_Return = "";
            }
            if (i_Content != 0)
            {

                string DoSql = "update KNet_Resource_OutManage  set KRO_IsCheck='1'  where  ID='" + s_ID + "' ";
                DbHelperSQL.ExecuteSql(DoSql);
                s_Return = "<a target=\"_blank\" href=\"KNet_AttenDance_OutManger_View.aspx?ID=" + s_ID + "&Kx=1\"><font color=red>已核销</font></a>";
            }
            else
            {
 
            }
        }
        catch { }
        return s_Return;
    }
}
