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
public partial class Knet_Web_System_KnetWarehouse_ToAuth : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("仓库授权分配列表") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }


            ViewState["SortOrder"] = "StaffAddTime";
            ViewState["OrderDire"] = "Desc";
            this.Button1.Attributes.Add("onclick", "return confirm('你确定要给选择的员工受权所选择的仓库吗！')");

            this.Apant.Visible = false;
            this.DataShows();
            this.DataBindStaffBranch();
            this.Knet_Warehouse_Bind();

          
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

        Response.Redirect("KnetWarehouse_ToAuth.aspx?StaffBranch=" + StrucName + "");
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
        Response.Redirect("KnetWarehouse_ToAuth.aspx?KSeachKey=" + Sekety + "");
        Response.End();
    }
    /// <summary>
    /// 仓库绑定 (仓库绑定）
    /// </summary>
    protected void Knet_Warehouse_Bind()
    {
        KNet.BLL.KNet_Sys_WareHouse bll = new KNet.BLL.KNet_Sys_WareHouse();
        using (DataSet ds = bll.GetList(" HouseYN=1 "))
        {
            this.AuthWareHouse1.DataSource = ds;
            this.AuthWareHouse1.DataTextField = "HouseName";
            this.AuthWareHouse1.DataValueField = "HouseNo";
            this.AuthWareHouse1.DataBind();
        }
    }

    /// <summary>
    /// 查查是否已有受权
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected bool GetKNet_Sys_WareHouse_AuthList(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select StaffNo,HouseNo from KNet_Sys_WareHouse_AuthList where StaffNo='" + aa + "' ";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return true;
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
    /// 获返仓库名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetKNet_Sys_WareHouseNameByHouseNo(string  HouseNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,HouseNo,HouseName from KNet_Sys_WareHouse where HouseNo='" + HouseNo + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    return dr["HouseName"].ToString().Trim();
                }
                else
                {
                    return "";
                }
            }
        }
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

            //仓库受权分配
            if (AM.YNAuthority("仓库受权分配") == false)
            {
                e.Row.Cells[8].Text = "<font color=#999999>取消受权</font>";
                e.Row.Cells[8].Attributes.Remove("onClick");
            }
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
            string Dosql = "DELETE  KNet_Sys_WareHouse_AuthList WHERE [StaffNo]='" + StaffNo + "'";
            DbHelperSQL.ExecuteSql(Dosql);

            AdminloginMess LogAM = new AdminloginMess();
            LogAM.Add_Logs("系统管理--->仓库受权--->用户:" + GetStaffName(StaffNo) + "受权仓库清零（重置） 操作成功！");
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
                    ListStr = ListStr + GetKNet_Sys_WareHouseNameByHouseNo(mydrv["HouseNo"].ToString());
                }
                else
                {
                    ListStr = ListStr +"<B>|</B>"+GetKNet_Sys_WareHouseNameByHouseNo(mydrv["HouseNo"].ToString());
                }
            }
        }
        if (ListStr == "")
        {
            return "<font color=\"gray\">未受权任何仓库</font>";
        }
        else
        {
            return ListStr;
        }
    }
    /// <summary>
    /// 获得受权仓库  数据列表
    /// </summary>
    public DataSet GetList(string strWhere)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select StaffNo,HouseNo ");
        strSql.Append(" FROM KNet_Sys_WareHouse_AuthList ");
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
            string Dosql = "DELETE  KNet_Sys_WareHouse_AuthList WHERE [StaffNo]='" + StaffNo + "'";
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
                LogAM.Add_Logs("系统管理--->仓库受权--->仓库受权失败！您没有选择任何仓库！");
                Response.Write("<script>alert('仓库受权失败！您没有选择任何仓库！');history.back(-1);</script>");
                Response.End();
            }
            else
            {
                LogAM.Add_Logs("系统管理--->仓库受权--->仓库受权成功！");
                Response.Write("<script>alert('仓库受权 更新/添加 成功！');location.href='KnetWarehouse_ToAuth.aspx';</script>");
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
    protected void AddAutdata(string StaffNo, string HouseNo)
    {
        string DoSql = "INSERT INTO KNet_Sys_WareHouse_AuthList(StaffNo,HouseNo) VALUES ('" + StaffNo + "','" + HouseNo + "')";
        DbHelperSQL.ExecuteSql(DoSql);
    }
}
