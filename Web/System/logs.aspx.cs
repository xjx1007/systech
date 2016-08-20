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
using KNet.IPinfo;
/// <summary>
/// 系统日志
/// </summary>
public partial class Knet_web_System_logs : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            this.Lbl_Title.Text = "系统日志列表";
            if (AM.CheckLogin("系统日志列表") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            //系统日志管理


            //用户组管理
            if (AM.YNAuthority("删除系统日志") == false)
            {
                this.Button1.Enabled = false;
                this.Button3.Enabled = false;
                this.Button5.Enabled = false;
                this.Button6.Enabled = false;
                this.Button7.Enabled = false;
            }

            ViewState["SortOrder"] = "Logtime";
            ViewState["OrderDire"] = "Desc";
            this.Button1.Attributes.Add("onclick", "return confirm('您真的要删除所选的日志记录吗?')");


            this.Button3.Attributes.Add("onclick", "return confirm('您真的要删除三个月之前所有日志记录吗?')");
            this.Button5.Attributes.Add("onclick", "return confirm('您真的要删除二个月之前所有日志记录吗?')");
            this.Button6.Attributes.Add("onclick", "return confirm('您真的要删除一个月之前所有日志记录吗?')");
            this.Button7.Attributes.Add("onclick", "return confirm('您真的要删除三天之前所有日志记录吗?')");

            this.DataShows();
            this.RowOverYN();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="IP"></param>
    /// <returns></returns>
    protected string IPtoAddress(string IP)
    {
        IPinfo objScan = new IPinfo();
        // string ip = objScan.GetIPAddress();
        objScan.DataPath = Server.MapPath("~/App_Data/qqwry/QQWry.Dat");
        string addre = objScan.IPtoAdrress(IP);
        string err = objScan.ErrMsg;

        return addre + err;

    }

    /// <summary>
    /// 是不是有记录
    /// </summary>
    protected void RowOverYN()
    {
        if (GridView1.Rows.Count == 0) //如果没有记录
        {
            this.Button1.Enabled = false;
            this.Button3.Enabled = false;
            this.Button5.Enabled = false;
            this.Button6.Enabled = false;
            this.Button7.Enabled = false;
        }
    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        string LogtimeA = null;
        string LogtimeB = null;
        string logContentx = null;
        string SqlWhere = " 1=1 ";

        if (Request["LogtimeA"] != null && Request["LogtimeB"] != null && Request["LogtimeA"] != "" && Request["LogtimeB"] != "")
        {
            LogtimeA = Request.QueryString["LogtimeA"].ToString().Trim();
            if (LogtimeA == "") { LogtimeA = null; }
            this.StartDate.Text = LogtimeA;

        }
        if (Request["LogtimeB"] != null && Request["LogtimeA"] != null && Request["LogtimeB"] != "" && Request["LogtimeA"] != "")
        {
            LogtimeB = Request.QueryString["LogtimeB"].ToString().Trim();
            if (LogtimeB == "") { LogtimeB = null; }
            this.EndDate.Text = LogtimeB;

            SqlWhere = SqlWhere + " and ( Logtime >= '" + LogtimeA + "' and  Logtime<='" + LogtimeB + "'   ) ";
        }
        if (Request["logContent"] != null)
        {
            logContentx = Request.QueryString["logContent"].ToString().Trim();
            if (logContentx == "") { logContentx = null; }
            this.SeachKey.Text = logContentx;

            SqlWhere = SqlWhere + " and ( logIP like '%" + logContentx + "%' or logContent  like '%" + logContentx + "%' )";
        }

        DataSet ds = GetList(SqlWhere);

        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "ID" };
        GridView1.DataBind();
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
    }


    /// <summary>
    /// 批量删除记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {

        //演示控制代码
        AdminloginMess LogAM = new AdminloginMess();


        string sql = "delete from KNet_Static_logs where ";
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
        try
        {
            DbHelperSQL.ExecuteSql(sql);

            LogAM.Add_Logs("系统管理--->系统日志  批量删除 操作成功！");
            this.DataShows();
            this.RowOverYN();

        }
        catch { }
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
            }
            GridView1.EditIndex = -1;
            this.DataShows();
        }
        catch { }
    }


    /// <summary>
    /// 由员工编号获取员工姓名
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string Knet_Get_StaffName(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,StaffNo,StaffName from KNet_Resource_Staff where StaffNo='" + aa + "'  or  StaffCard='" + aa + "' ";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["StaffName"].ToString().Trim();
            }
            else
            {
                return "未知账号";
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
        string LogtimeA = StartDate.Text.ToString().Trim();
        string LogtimeB = EndDate.Text.ToString().Trim();
        string logContent = KNetPage.KHtmlEncode(SeachKey.Text.ToString());
        if ((LogtimeA == "" && LogtimeB != "") || (LogtimeA != "" && LogtimeB == ""))
        {
            Response.Write("<script language=javascript>alert('您所选择的日期一定要有 开始日期 和 结束日期!');history.back(-1);</script>");
            Response.End();
        }
        Response.Redirect("logs.aspx?LogtimeA=" + LogtimeA + "&LogtimeB=" + LogtimeB + "&logContent=" + logContent + "");
        Response.End();
    }
    /// <summary>
    /// 删除三天月之前的记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button7_Click(object sender, EventArgs e)
    {
        AdminloginMess LogAM = new AdminloginMess();
        DateTime dotodate = DateTime.Now.AddDays(-3);
        Delete_Knet_logs_ForTime(dotodate);
        LogAM.Add_Logs("系统管理--->系统日志  删除三天前系统日志  操作成功！");
        this.DataShows();
        this.RowOverYN();
    }
    /// <summary>
    /// 删除一个月之前的记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button6_Click(object sender, EventArgs e)
    {
        AdminloginMess LogAM = new AdminloginMess();
        DateTime dotodate = DateTime.Now.AddDays(-30);
        Delete_Knet_logs_ForTime(dotodate);
        LogAM.Add_Logs("系统管理--->系统日志  删除（一个月）之前系统日志  操作成功！");
        this.DataShows();
        this.RowOverYN();
    }
    /// <summary>
    /// 删除二个月之前的记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button5_Click(object sender, EventArgs e)
    {
        AdminloginMess LogAM = new AdminloginMess();
        DateTime dotodate = DateTime.Now.AddDays(-60);
        Delete_Knet_logs_ForTime(dotodate);
        LogAM.Add_Logs("系统管理--->系统日志  删除（两个月）之前系统日志  操作成功！");

        this.DataShows();
        this.RowOverYN();
    }

    /// <summary>
    /// 删除三个月之前的记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button3_Click(object sender, EventArgs e)
    {
        AdminloginMess LogAM = new AdminloginMess();

        DateTime dotodate = DateTime.Now.AddDays(-90);
        Delete_Knet_logs_ForTime(dotodate);
        LogAM.Add_Logs("系统管理--->系统日志  删除（三个月）之前系统日志  操作成功！");

        this.DataShows();
        this.RowOverYN();
    }


    /// <summary>
    /// 删除时间段
    /// </summary>
    /// <param name="P_Int_ID"></param>
    public void Delete_Knet_logs_ForTime(DateTime P_Str_DateTimeStr)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetJxcDB"))
        {
            conn.Open();
            SqlCommand myCmd = new SqlCommand("Proc_KNet_Static_logs_Delete_ForTime", conn);
            myCmd.CommandType = CommandType.StoredProcedure;
            //添加参数
            SqlParameter DateTimeStr = new SqlParameter("@DateTimeStr", SqlDbType.DateTime, 8);
            DateTimeStr.Value = P_Str_DateTimeStr;
            myCmd.Parameters.Add(DateTimeStr);
            //执行过程
            try
            {
                myCmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }
    }
    /// <summary>
    /// 获得数据列表
    /// </summary>
    public DataSet GetList(string strWhere)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select ID,StaffNo,Logtime,logIP,logContent ");
        strSql.Append(" FROM KNet_Static_logs ");
        if (strWhere.Trim() != "")
        {
            strSql.Append(" where " + strWhere);
        }
        strSql.Append(" order by Logtime desc ");
        return DbHelperSQL.Query(strSql.ToString());
    }
}
