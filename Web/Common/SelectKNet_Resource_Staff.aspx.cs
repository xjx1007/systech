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
using System.IO;
using System.Text;

using KNet.DBUtility;
using KNet.Common;

/// <summary>
/// 选择人员
/// </summary>
public partial class Knet_Common_SelectKNet_Resource_Staff : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        KNet.DBUtility.AdminloginMess AMLanguage = new KNet.DBUtility.AdminloginMess();
        if (AMLanguage.KNet_Soft_StaffLanguage == 2)
        {
            // 1、默认为简体转繁体，编码为utf-8
            Response.Filter = new LU.Web.ChineseConvertor(Response.Filter);
        }
        else if (AMLanguage.KNet_Soft_StaffLanguage == 1)
        {
            // 2、繁体简体转，编码为utf-8
            Response.Filter = new LU.Web.ChineseConvertor(Response.Filter, LU.Web.ChineseConvertor.CCDirection.T2S);
        }
        else
        { }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "人员选择";

        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
               Response.End();
            }
            else
            {

                ViewState["SortOrder"] = "StaffAddTime";
                ViewState["OrderDire"] = "Desc";
                this.Button2.Attributes.Add("onclick", "return confirm('你确定要指派选择所选的人员吗?！')");

                this.DataBindStaffBranch();
                this.KNetStaffBranchBind();

                this.DataShows();
                this.RowOverYN();
            }
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

        string SqlWhere = "  StaffAdmin=0 ";

        if (Request["KSeachKey"] != null && Request["KSeachKey"] != "")
        {
            KSeachKey = Request.QueryString["KSeachKey"].ToString().Trim();
            if (KSeachKey == "") { KSeachKey = null; }
            this.SeachKey.Text = KSeachKey;

            SqlWhere = SqlWhere + " and ( StaffCard like '%" + KSeachKey + "%' or StaffName  like '%" + KSeachKey + "%' or StaffTel  like '%" + KSeachKey + "%' )";
        }

        if (Request["StaffBranch"] != null && Request["StaffBranch"] != "")
        {
            string StaffBranch = Request.QueryString["StaffBranch"].ToString().Trim();
            this.StaffBranch.SelectedValue = StaffBranch;
            this.KNetStaffBranch.SelectedValue = StaffBranch;
            SqlWhere = SqlWhere + " and  StaffBranch = '" + StaffBranch + "' ";
        }

        if (Request["StaffDepart"] != null && Request["StaffDepart"] != "")
        {
            string StaffDepart = Request.QueryString["StaffDepart"].ToString().Trim();
            SqlWhere = SqlWhere + " and  StaffDepart = '" + StaffDepart + "' ";
        }
        SqlWhere = SqlWhere + " order by StaffAddTime desc";

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
        this.RowOverYN();
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
    /// 添加提示
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_DataRowBinding(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        { //自动ID号
            int id = (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = id.ToString();
        }
    }



    /// <summary>
    /// 添加指派的人员
    /// </summary>
    /// <param name="StaffNo"></param>
    /// <param name="HouseNo"></param>
    protected void AddAutdata(string StaffNo, string CustomerValue)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select StaffNo,CustomerValue from KNet_Sales_ClientList_AuthList where StaffNo='" + StaffNo + "' and  CustomerValue='" + CustomerValue + "' ";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {}
            else
            {
                string DoSql = "INSERT INTO KNet_Sales_ClientList_AuthList(StaffNo,CustomerValue) VALUES ('" + StaffNo + "','" + CustomerValue + "')";
                DbHelperSQL.ExecuteSql(DoSql);
            }
        }
    }


    /// <summary>
    /// 确定选择
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
            string cal = "";
            if (Request.QueryString["CustomerValue"] != null && Request.QueryString["CustomerValue"] != "")
            {
                string CustomerValue = Request.QueryString["CustomerValue"].Trim();
                //this.BeelData(CustomerValue);

                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
                    if (cb.Checked == true)
                    {
                        cal += GridView1.DataKeys[i].Value.ToString();
                        this.AddAutdata(GridView1.DataKeys[i].Value.ToString(), CustomerValue);
                    }
                }
                if (cal == "")
                {
                    Response.Write("<script language=javascript>alert('您没有选择要指派的人员！');this.window.close();</script>");
                    Response.End();
                }
                else
                {
                    AdminloginMess LogAM = new AdminloginMess();
                    LogAM.Add_Logs("销售管理--->管理管理--->保护客户指派 操作成功！");

                    Response.Write("<script language='javascript'>window.opener.location.reload();</script>");
                    Response.Write("<script language='javascript'>window.opener=null;window.close();</script>");
                }
            }
            else
            {
                Response.Write("<script language=javascript>alert('非法参数请求!');this.window.close();</script>");
                Response.End();
            } 
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
    /// 分公司绑定
    /// </summary>
    protected void KNetStaffBranchBind()
    {
        KNet.BLL.KNet_Resource_OrganizationalStructure bll = new KNet.BLL.KNet_Resource_OrganizationalStructure();
        using (DataSet ds = bll.GetList(" StrucPID='0'"))
        {
            this.KNetStaffBranch.DataSource = ds;
            this.KNetStaffBranch.DataTextField = "StrucName";
            this.KNetStaffBranch.DataValueField = "StrucValue";
            this.KNetStaffBranch.DataBind();
            ListItem item = new ListItem("选择分部", ""); //默认值
            this.KNetStaffBranch.Items.Insert(0, item);


            ListItem item2 = new ListItem("请选择部门", ""); //默认值
            this.KNetStaffDepart.Items.Insert(0, item2);
        }
    }
    /// <summary>
    /// 搜索
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click1(object sender, EventArgs e)
    {
        string Sekety = KNetPage.KHtmlEncode(this.SeachKey.Text.Trim());

        string StaffBranch = this.KNetStaffBranch.SelectedValue;
        string StaffDepart = this.KNetStaffDepart.SelectedValue;

        Response.Redirect("SelectKNet_Resource_Staff.aspx?KSeachKey=" + Sekety + "&StaffBranch=" + StaffBranch + "&StaffDepart=" + StaffDepart + "");
        Response.End();
    }
    /// <summary>
    /// 按分公司筛选记录
    /// </summary>
    protected void DataBindStaffBranch()
    {
        KNet.BLL.KNet_Resource_OrganizationalStructure bll = new KNet.BLL.KNet_Resource_OrganizationalStructure();
        using (DataSet ds = bll.GetList( " StrucPID='0'" ))
        {
            this.StaffBranch.DataSource = ds;
            this.StaffBranch.DataTextField = "StrucName";
            this.StaffBranch.DataValueField = "StrucValue";
            this.StaffBranch.DataBind();
            ListItem item = new ListItem("按分部筛选", ""); //默认值
            this.StaffBranch.Items.Insert(0, item);
        }
    }

    /// <summary>
    /// 按分公司筛选记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void StrucNameDList_SelectedIndexChanged(object sender, EventArgs e)
    {
        string StaffBranch = this.StaffBranch.SelectedValue;

        Response.Redirect("SelectKNet_Resource_Staff.aspx?StaffBranch=" + StaffBranch + "");
        Response.End();
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
    /// 选择分公司后
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void KNetStaffBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string proID = this.KNetStaffBranch.SelectedValue.ToString().Trim();
            using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from KNet_Resource_OrganizationalStructure where StrucPID='" + proID + "' ", conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                this.KNetStaffDepart.DataSource = sdr;
                this.KNetStaffDepart.DataTextField = "StrucName";
                this.KNetStaffDepart.DataValueField = "StrucValue";
                this.KNetStaffDepart.DataBind();
                ListItem item = new ListItem("请选择部门", ""); //默认值
                this.KNetStaffDepart.Items.Insert(0, item);
            }
        }
        catch { }
    }
}
