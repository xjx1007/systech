using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

using KNet.DBUtility;
using KNet.Common;

/// <summary>
/// 仓库受权操作
/// </summary>
public partial class Knet_Web_System_KnetKnetUserAuthorityList: System.Web.UI.Page
{

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
            //用户权限设置
            //if (AM.YNAuthority("用户权限设置") == false)
            //{
            //    // AM.NoAuthority("7013");
            //    this.Button4.Enabled = false;
            //    this.Button5.Enabled = false;
            //    this.Button6.Enabled = false;
            //}

            ViewState["SortOrder"] = "StaffAddTime";
            ViewState["OrderDire"] = "Desc";
            this.Button1.Attributes.Add("onclick", "return confirm('你确定要给选择的员工设置所选择的用户组吗！')");
            this.Button6.Attributes.Add("onclick", "return confirm('你确定要取消所选用户的禁用操作吗！')");
            this.Button4.Attributes.Add("onclick", "return confirm('你确定要对所选择的用户进行禁用操作吗！')");


            this.Apant.Visible = false;
            this.DataShows();
            this.RowOverYN();

            this.DataBindStaffBranch();
            this.Knet_Warehouse_Bind();

          
        }
    }
    /// <summary>
    /// 是不是有记录
    /// </summary>
    protected void RowOverYN()
    {
        if (GridView1.Rows.Count == 0) //如果没有记录
        {
            this.Button2.Enabled = false;
            this.Button3.Enabled = false;
        }
    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.KNet_Resource_Staff bll = new KNet.BLL.KNet_Resource_Staff();
        string KSeachKey = null;

        string SqlWhere = " StaffAdmin=0 ";

        if (Request["KSeachKey"] != null && Request["KSeachKey"] != "")
        {
            KSeachKey = Request.QueryString["KSeachKey"].ToString().Trim();
            if (KSeachKey == "") { KSeachKey = null; }
            this.SeachKey.Text = KSeachKey;

            SqlWhere = SqlWhere + " and ( StaffCard like '%" + KSeachKey + "%' or StaffName  like '%" + KSeachKey + "%' or StaffIDCard  like '%" + KSeachKey + "%' )";
        }

        if (Request["StaffBranch"] != null && Request["StaffBranch"] != "")
        {
            string KDBList = Request.QueryString["StaffBranch"].ToString().Trim();
            if (KDBList == "") { KDBList = null; }
            this.StrucNameDList.SelectedValue = KDBList;

            SqlWhere = SqlWhere + " and StaffBranch = '" + KDBList + "' ";
        }

        using (DataSet ds = bll.GetList(SqlWhere))
        {
            //正反排序------
            DataView dv = ds.Tables[0].DefaultView;
            string sort = (string)ViewState["SortOrder"] + " " + (string)ViewState["OrderDire"];
            dv.Sort = sort;
            //--分页-------
            PagedDataSource pds = new PagedDataSource();
            AspNetPager1.RecordCount = dv.Count;
            pds.DataSource = dv;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;
            //--End分页-----
            GridView1.DataSource = pds;
            GridView1.DataKeyNames = new string[] { "StaffNo" };
            GridView1.DataBind();
        }
    }

    /// <summary>
    /// 正反排序
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sPage = e.SortExpression;
        if (ViewState["SortOrder"].ToString() == sPage)
        {
            if (ViewState["OrderDire"].ToString() == "Desc")
                ViewState["OrderDire"] = "ASC";
            else
                ViewState["OrderDire"] = "Desc";
        }
        else
        {
            ViewState["SortOrder"] = e.SortExpression;
        }
        this.DataShows();
    }

    /// <summary>
    /// 执行分页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void AspNetPager1_PageChanged(object src, EventArgs e)
    {
        this.DataShows();
        this.RowOverYN();
    }
    /// <summary>
    /// 按公司筛选记录
    /// </summary>
    protected void DataBindStaffBranch()
    {
        KNet.BLL.KNet_Resource_OrganizationalStructure bll = new KNet.BLL.KNet_Resource_OrganizationalStructure();
        DataSet ds = bll.GetList("StrucPID='0'");
        this.StrucNameDList.DataSource = ds;
        this.StrucNameDList.DataTextField = "StrucName";
        this.StrucNameDList.DataValueField = "StrucValue";
        this.StrucNameDList.DataBind();
        ListItem item = new ListItem("按分部筛选记录", ""); //默认值
        this.StrucNameDList.Items.Insert(0, item);
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
    /// 按公司筛选记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void StrucNameDList_SelectedIndexChanged(object sender, EventArgs e)
    {
        string StrucName = this.StrucNameDList.SelectedValue;

        Response.Redirect("KnetUserAuthorityList.aspx?StaffBranch=" + StrucName + "");
        Response.End();
    }
    /// <summary>
    /// 搜索
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click1(object sender, EventArgs e)
    {
        string Sekety = KNetPage.KHtmlEncode(this.SeachKey.Text.Trim());
        Response.Redirect("KnetUserAuthorityList.aspx?KSeachKey=" + Sekety + "");
        Response.End();
    }
    /// <summary>
    /// 用户组绑定 (用户组绑定）
    /// </summary>
    protected void Knet_Warehouse_Bind()
    {
        KNet.BLL.KNet_Sys_AuthorityUserGroup bll = new KNet.BLL.KNet_Sys_AuthorityUserGroup();
        using (DataSet ds = bll.GetAllList())
        {
            this.AuthWareHouse1.DataSource = ds;
            this.AuthWareHouse1.DataTextField = "GroupName";
            this.AuthWareHouse1.DataValueField = "GroupValue";
            this.AuthWareHouse1.DataBind();
        }
    }

    /// <summary>
    /// 查查看用户账号是否已禁用  是否禁用（0否，1是）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected bool GetKNet_Sys_WareHouse_AuthList(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select StaffNo,StaffYN from KNet_Resource_Staff where StaffNo='" + aa + "' ";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["StaffYN"].ToString() == "True" || dr["StaffYN"].ToString() == "1")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }

    /// <summary>
    /// 获返回员工姓名
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetStaffName(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,StaffNo,StaffName from KNet_Resource_Staff where StaffNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    return dr["StaffName"].ToString().Trim();
                }
                else
                {
                    return "--";
                }
            }
        }
    }


    /// <summary>
    /// 获返用户组名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetKNet_Sys_WareHouseNameByHouseNo(string GroupValue)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,GroupValue,GroupName from KNet_Sys_AuthorityUserGroup where GroupValue='" + GroupValue + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    return dr["GroupName"].ToString().Trim();
                }
                else
                {
                    return "";
                }
            }
        }
    }
    /// <summary>
    /// 执行全选操作
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox ChkM = (CheckBox)GridView1.HeaderRow.Cells[0].FindControl("CheckBox1");

        foreach (GridViewRow gr in GridView1.Rows)
        {
            CheckBox chk = (CheckBox)gr.Cells[0].FindControl("Chbk");
            if (!chk.Checked)
            {
                chk.Checked = true;
                ChkM.Text = "消";
            }
            else
            {
                chk.Checked = false;
                ChkM.Text = "选";
            }
        }
    }

    /// <summary>
    /// 批量禁用账号
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button4_Click(object sender, EventArgs e)
    {

        string sql = "update KNet_Resource_Staff set StaffYN=1 where";
        string cal = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {
                cal += " StaffNo='" + GridView1.DataKeys[i].Value.ToString() + "' or";
            }
        }
        if (cal != "")
        {
            sql += cal.Substring(0, cal.Length - 3);
        }
        else
        {
            sql = "";       //不删除
            Response.Write("<script language=javascript>alert('您没有选择要禁用的记录!');history.back(-1);</script>");
            Response.End();
        }
        DbHelperSQL.ExecuteSql(sql);

        AdminloginMess LogAM = new AdminloginMess();
        LogAM.Add_Logs("系统设置--->用户权限设置--->用户账号批量禁用 操作成功！");

        this.DataShows();
        this.RowOverYN();
    }

    /// <summary>
    /// 批量返禁用账号
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button6_Click(object sender, EventArgs e)
    {

        string sql = "update KNet_Resource_Staff set StaffYN=0 where";
        string cal = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {
                cal += " StaffNo='" + GridView1.DataKeys[i].Value.ToString() + "' or";
            }
        }
        if (cal != "")
        {
            sql += cal.Substring(0, cal.Length - 3);
        }
        else
        {
            sql = "";       //不删除
            Response.Write("<script language=javascript>alert('您没有选择要取消禁用的记录!');history.back(-1);</script>");
            Response.End();
        }
        DbHelperSQL.ExecuteSql(sql);

        AdminloginMess LogAM = new AdminloginMess();
        LogAM.Add_Logs("系统设置--->用户权限设置--->用户账号批量取消禁用 操作成功！");

        this.DataShows();
        this.RowOverYN();
    }
    /// <summary>
    /// 取消所有已选中列
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button5_Click(object sender, EventArgs e)
    {
        try
        {
            CheckBox ChkB = (CheckBox)GridView1.HeaderRow.Cells[0].FindControl("CheckBox1");
            ChkB.Checked = false;

            foreach (GridViewRow gr in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)gr.Cells[0].FindControl("Chbk");
                chk.Checked = false;
            }
            GridView1.EditIndex = -1;
            this.DataShows();
        }
        catch { }
    }
    /// <summary>
    /// GridView 添加 提示 事件
    ///  <asp:GridView  OnRowDataBound="GridView1_DataBinding" >
    /// </summary>
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[8].Attributes.Add("onClick", "return confirm('你真的要取消该员工的受权仓库吗?');");

            Image lk = (Image)e.Row.Cells[1].FindControl("Image1");
            string StaffNo = GridView1.DataKeys[e.Row.RowIndex].Value.ToString(); //获取StaffNo值

            if (this.GetKNet_Sys_WareHouse_AuthList(StaffNo) == true)
            {
                lk.ImageUrl = "~/images/Au1.gif";
            }
            else
            {
                lk.ImageUrl = "~/images/Au2.gif";
            }
            ////用户权限设置
            //if (AM.YNAuthority(NQ.Str7013) == false)
            //{
            //    e.Row.Cells[8].Text = "<font color=#999999>取消用户组</font>";
            //    e.Row.Cells[8].Attributes.Remove("onClick");
            //}
        }
        if (e.Row.RowIndex != -1)
        { //自动ID号
            int id = (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = id.ToString();
        }
    }

    /// <summary>
    /// 设置受权(原本删除事件,打开受权面板)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        //用户权限设置
        //if (AM.YNAuthority("用户权限设置") == false)
        //{
        //    // AM.NoAuthority("7013");
        //    this.Button1.Enabled = false;
        //    this.Button2.Enabled = false;
        //}


        this.Apant.Visible = true;
        string StaffNo = GridView1.DataKeys[e.RowIndex].Value.ToString().Trim();
        this.StaffNo1.Text = GetStaffName(StaffNo);
        this.HiddenFieldStaffNo1.Value = StaffNo;
        this.DataShows();


    }
    /// <summary>
    /// 单个受权删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        string StaffNo = GridView1.DataKeys[e.NewSelectedIndex].Value.ToString().Trim();

        try
        {
            string Dosql = "DELETE  KNet_Sys_Authority_AuthList WHERE [StaffNo]='" + StaffNo + "'";
            DbHelperSQL.ExecuteSql(Dosql);

            AdminloginMess LogAM = new AdminloginMess();
            LogAM.Add_Logs("系统管理--->用户权限设置--->用户:" + GetStaffName(StaffNo) + "受权用户组清零（重置） 操作成功！");
        }
        catch {}
        Response.Redirect(Request.Url.ToString());
    }


    /// <summary>
    /// 获取员工的仓库列表
    /// </summary>
    /// <param name="StaffNo"></param>
    /// <returns></returns>
    protected string GetKNet_Sys_WareHouseName(string StaffNo)
    {
        string ListStr = "";
        using (DataSet ds = GetList("StaffNo='" + StaffNo + "'"))
        {
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                DataRowView mydrv = ds.Tables[0].DefaultView[i];
                if (i == 0)
                {
                    ListStr = ListStr + GetKNet_Sys_WareHouseNameByHouseNo(mydrv["GroupValue"].ToString());
                }
                else
                {
                    ListStr = ListStr + "<B>|</B>" + GetKNet_Sys_WareHouseNameByHouseNo(mydrv["GroupValue"].ToString());
                }
            }
        }
        if (ListStr == "")
        {
            return "<font color=\"gray\">未属任何用户组</font>";
        }
        else
        {
            return ListStr;
        }
    }
    /// <summary>
    /// 获得受权用户组  数据列表
    /// </summary>
    public DataSet GetList(string strWhere)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select StaffNo,GroupValue ");
        strSql.Append(" FROM KNet_Sys_Authority_AuthList ");
        if (strWhere.Trim() != "")
        {
            strSql.Append(" where " + strWhere);
        }
        return DbHelperSQL.Query(strSql.ToString());
    }
    /// <summary>
    /// 放弃受权
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click(object sender, EventArgs e)
    {
        this.Apant.Visible = false;
        this.DataShows();
    }

    /// <summary>
    /// 确定受权
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        AdminloginMess LogAM = new AdminloginMess();

        try
        {
            string StaffNo = this.HiddenFieldStaffNo1.Value.ToString();
            string Dosql = "DELETE  KNet_Sys_Authority_AuthList WHERE [StaffNo]='" + StaffNo + "'";
            DbHelperSQL.ExecuteSql(Dosql);


            string rvalue = "";
            foreach (ListItem item in AuthWareHouse1.Items)
            {
                if (item.Selected == true)
                {
                    rvalue += item.Value;
                    this.AddAutdata(StaffNo, item.Value);
                }
            }
            if (rvalue == "")
            {
                LogAM.Add_Logs("系统管理--->用户权限设置--->用户权限受权失败！您没有选择任何用户组！");
                Response.Write("<script>alert('用户权限受权失败！您没有选择任何用户组！');history.back(-1);</script>");
                Response.End();
            }
            else
            {
                LogAM.Add_Logs("系统管理--->用户权限设置--->用户组设置受权成功！");
                Response.Write("<script>alert('用户组设置操作 更新/添加 成功！');location.href='KnetUserAuthorityList.aspx';</script>");
                Response.End();
            }
        }
        catch { }
    }

    /// <summary>
    /// 添加受权仓库
    /// </summary>
    /// <param name="StaffNo"></param>
    /// <param name="HouseNo"></param>
    protected void AddAutdata(string StaffNo, string GroupValue)
    {
        string DoSql = "INSERT INTO KNet_Sys_Authority_AuthList(StaffNo,GroupValue) VALUES ('" + StaffNo + "','" + GroupValue + "')";
        DbHelperSQL.ExecuteSql(DoSql);
    }
}
