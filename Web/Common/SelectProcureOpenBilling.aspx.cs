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
/// 选择采购单
/// </summary>
public partial class Knet_Common_SelectProcureOpenBilling : BasePage
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
                ViewState["SortOrder"] = "OrderDateTime";
                ViewState["OrderDire"] = "Desc";
                this.Button2.Attributes.Add("onclick", "return confirm('你确定要选择所选的记录吗?！')");

                this.SeachKey.Focus();

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
        KNet.BLL.Knet_Procure_OrdersList bll = new KNet.BLL.Knet_Procure_OrdersList();

        string LogtimeA = null;
        string LogtimeB = null;
        string KSeachKey = null;

        //采购单执行状态（0未执行，1执行中，2逾期作废，3收货中，4退货中，5完成）
        string SqlWhere = " OrderCheckYN=1  and (OrderState=1 or OrderState=3 or OrderState=4 ) ";

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

            DateTime ss = DateTime.Now;
            try
            {
                ss = DateTime.Parse(LogtimeA);
                ss = DateTime.Parse(LogtimeB);
                SqlWhere = SqlWhere + " and ( OrderDateTime >= '" + LogtimeA + "' and  OrderDateTime<='" + LogtimeB + "'   ) ";
            }
            catch
            {
                Response.Write("<script language=javascript>alert('选择的日期格式非法！');window.close();</script>");
                Response.End();
            }
        }
        if (Request["SeachKey"] != null && Request["SeachKey"] != "")
        {
            KSeachKey = Request.QueryString["SeachKey"].ToString().Trim();
            if (KSeachKey == "") { KSeachKey = null; }
            this.SeachKey.Text = KSeachKey;

            SqlWhere = SqlWhere + " and (  OrderTopic like '%" + KSeachKey + "%' or  ContractNo like '%" + KSeachKey + "%' or OrderNo  like '%" + KSeachKey + "%' or OrderNo in(Select OrderNo  from Knet_Procure_OrdersList_Details where ProductsPattern like '%" + KSeachKey + "%'))";
        }
        SqlWhere = SqlWhere + " order by SystemDateTimes desc";

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
            GridView1.DataKeyNames = new string[] { "OrderNo" };
            GridView1.DataBind();
            ds.Dispose();
            dv.Dispose();
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
    /// 确定选择
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        string cal = "";
        string OrderNoVale = "";
        int KK = 0;
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {
                cal += " OrderNo='" + GridView1.DataKeys[i].Value.ToString() + "' or";
                OrderNoVale = GridView1.DataKeys[i].Value.ToString();
                KK = KK + 1;
            }
        }
        if (KK > 1)
        {
            Response.Write("<script language=javascript>alert('每次只能选择一个采购单！');window.close();</script>");
            Response.End();
        }

        if (cal == "")
        {
            Response.Write("<script language=javascript>alert('您没有选择记录！\\n\\n注意:每次只能选择一个采购单');window.close();</script>");
            Response.End();
        }
        else
        {
            if (OrderNoVale == null || OrderNoVale == "")
            {
                Response.Write("<script language=javascript>alert('您没有选择记录！\\n\n注意:每次只能选择一个采购单！');window.close();</script>");
                Response.End();
            }
            else
            {
                StringBuilder s = new StringBuilder();
                s.Append("<script language=javascript>" + "\n");
                s.Append("window.returnValue='" + OrderNoVale + "|" + GetKNet_OrderTopic(OrderNoVale) + "(" + OrderNoVale + ")';" + "\n");
                s.Append("window.close();" + "\n");
                s.Append("</script>");
                Type cstype = this.GetType();
                ClientScriptManager cs = Page.ClientScript;
                string csname = "ltype";
                if (!cs.IsStartupScriptRegistered(cstype, csname))
                    cs.RegisterStartupScript(cstype, csname, s.ToString());
            }
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
    /// 搜索
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button4_Click(object sender, EventArgs e)
    {
        string LogtimeA = StartDate.Text.ToString().Trim();
        string LogtimeB = EndDate.Text.ToString().Trim();
        string SeachKeyContent = KNetPage.KHtmlEncode(SeachKey.Text.ToString());
        if ((LogtimeA == "" && LogtimeB != "") || (LogtimeA != "" && LogtimeB == ""))
        {
            Response.Write("<script language=javascript>alert('您所选择的日期一定要有 开始日期 和 结束日期!');history.back(-1);</script>");
            Response.End();
        }
        Response.Redirect("SelectProcureOpenBilling.aspx?LogtimeA=" + LogtimeA + "&LogtimeB=" + LogtimeB + "&SeachKey=" + SeachKeyContent + "&Css1=Div22");
        Response.End();
    }


    /// <summary>
    /// 返回采购单主题
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetKNet_OrderTopic(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,OrderNo,OrderTopic from Knet_Procure_OrdersList where OrderNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["OrderTopic"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }

    /// <summary>
    /// 返回采购类型名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetKNet_Sys_ProcureTypeNane(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,ProcureTypeValue,ProcureTypeName from KNet_Sys_ProcureType where ProcureTypeValue='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["ProcureTypeName"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }

    /// <summary>
    /// 返回供应商名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetSuppNoName(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,SuppNo,SuppName from Knet_Procure_Suppliers where SuppNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["SuppName"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }

    /// <summary>
    /// 返回采购公司名称
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
    /// 返回经手开单人名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetStaffNameNane(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,StaffNo,StaffName from KNet_Resource_Staff where StaffNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
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


    /// <summary>
    /// 返回状态情况 （0未执行，1执行中，2逾期作废，3收货中，4退货中，5完成）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetOrderStateYN(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,OrderNo,OrderState,OrderCheckYN from Knet_Procure_OrdersList where OrderNo='" + aa + "' ";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                int A = int.Parse(dr["OrderState"].ToString());
                string Str = "--";
                switch (A)
                {
                    case 0:
                        Str = "<font color=#CC9900>未执行</font>";
                        break;
                    case 1:
                        Str = "<font color=blue>执行中</font>";
                        break;
                    case 2:
                        Str = "<font color=Red>作废</font>";
                        break;
                    case 3:
                        Str = "<font color=#990000>收货中</font>";
                        break;
                    case 4:
                        Str = "<font color=#FF9900>退货中</font>";
                        break;
                    case 5:
                        Str = "完成";
                        break;
                    default:
                        Str = "--";
                        break;
                }
                return Str;
            }
            else
            {
                return "--";
            }
        }
    }

}
