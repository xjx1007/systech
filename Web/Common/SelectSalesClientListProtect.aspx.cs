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
/// 选择销售客户
/// </summary>
public partial class Knet_Common_SelectSalesClientListProtect : System.Web.UI.Page
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
        this.Page.Title = "选择客户";

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
                DataSet ds = KNet.Common.KNet_Static_Province.GetProvinceInfo("");
                string code, name;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    code = ds.Tables[0].Rows[i]["code"].ToString();
                    name = ds.Tables[0].Rows[i]["name"].ToString();
                    this.sheng.Items.Add(new ListItem(name, code));
                }

                this.city.Disabled = true;

                this.HyperLink1.NavigateUrl = "SelectSalesClientList.aspx?Sn=" + DateTime.Now.ToFileTimeUtc().ToString() + "";
                this.HyperLink2.NavigateUrl = "SelectSalesClientListProtect.aspx?Sn=" + DateTime.Now.ToFileTimeUtc().ToString() + "";


                ViewState["SortOrder"] = "CustomerAddtime";
                ViewState["OrderDire"] = "Desc";
                this.Button2.Attributes.Add("onclick", "return confirm('你确定要选择所选的记录吗?！')");

               
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
        AdminloginMess AM = new AdminloginMess();
        KNet.BLL.KNet_Sales_ClientList bll = new KNet.BLL.KNet_Sales_ClientList();
        string KSeachKey = null;

        string SqlWhere = "( " + AM.MyDoSqlWith_DoClientList + " ) and  CustomerProtect=1 ";

        if (Request["KSeachKey"] != null && Request["KSeachKey"] != "")
        {
            KSeachKey = Request.QueryString["KSeachKey"].ToString().Trim();
            if (KSeachKey == "") { KSeachKey = null; }
            this.SeachKey.Text = KSeachKey;

            SqlWhere = SqlWhere + " and ( CustomerName like '%" + KSeachKey + "%' or CustomerContact  like '%" + KSeachKey + "%' or CustomerTel  like '%" + KSeachKey + "%' or CustomerMobile  like '%" + KSeachKey + "%' )";
        }

        if (Request["CustomerProvinces"] != null && Request["CustomerProvinces"] != "" && Request["CustomerProvinces"] != "0")
        {
            string CustomerProvinces = Request.QueryString["CustomerProvinces"].ToString().Trim();
            this.sheng.Value = CustomerProvinces;
            SqlWhere = SqlWhere + " and   CustomerProvinces = '" + CustomerProvinces + "' ";
        }
        if (Request["CustomerCity"] != null && Request["CustomerCity"] != "" && Request["CustomerCity"] != "0")
        {
            string CustomerCity = Request.QueryString["CustomerCity"].ToString().Trim();
            SqlWhere = SqlWhere + " and   CustomerCity = '" + CustomerCity + "' ";
        }
        SqlWhere = SqlWhere + " order by CustomerAddtime desc";


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
            GridView1.DataKeyNames = new string[] { "CustomerValue" };
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
        string SuppNoVale = "";
        string s_Code = "";
        int KK = 0;
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {
                cal += " CustomerValue='" + GridView1.DataKeys[i].Value.ToString() + "' or";
                SuppNoVale = GridView1.DataKeys[i].Value.ToString();
                KK = KK + 1;
            }
        }
        s_Code = "QUT" + SuppNoVale.Substring(1, SuppNoVale.Length - 1) + KNetOddNumbers();
        if (KK > 1)
        {
            Response.Write("<script language=javascript>alert('每次只能选择一个客户！');window.close();</script>");
            Response.End();
        }

        if (cal == "")
        {
            Response.Write("<script language=javascript>alert('您没有选择记录！\\n\\n注意:每次只能选择一个客户');window.close();</script>");
            Response.End();
        }
        else
        {
            if (SuppNoVale == null || SuppNoVale == "")
            {
                Response.Write("<script language=javascript>alert('您没有选择记录！\\n\n注意:每次只能选择一个客户！');window.close();</script>");
                Response.End();
            }
            else
            {
                StringBuilder s = new StringBuilder();
                s.Append("<script language=javascript>" + "\n");
                s.Append("window.returnValue='" + SuppNoVale + "|" + GetCustomerName(SuppNoVale) + "|" + GetCustomerNameAdress(SuppNoVale) + "|" + s_Code + "';" + "\n");
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


    #region 返回单号情况

    /// <summary>
    /// 返回当前的  单号 （唯一性，如 2009121402）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string KNetOddNumbers()
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select count(*) as AA  from  KNet_Sales_BaoPriceList  where (datediff(d,SystemDatetimes,GETDATE())=0)";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (int.Parse(dr["AA"].ToString()) == 0)
                {
                    return DateTime.Today.ToString("yyyyMMdd") + "01";
                }
                else
                {
                    return DateTime.Today.ToString("yyyyMMdd") + KNus003(int.Parse(dr["AA"].ToString()) + 1);
                }
            }
            else
            {
                return DateTime.Today.ToString("yyyyMMdd") + "01";
            }
        }
    }
    /// <summary>
    /// 返回当前的  单号 （唯一性，如 2009121402）
    /// </summary>
    /// <param name="ss"></param>
    /// <returns></returns>
    protected string KNus003(int ss)
    {
        if (ss.ToString().Length == 1)
        {
            return "0" + ss.ToString();
        }
        else
        {
            return ss.ToString();
        }
    }
    #endregion
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
    protected void Button1_Click1(object sender, EventArgs e)
    {
        string Sekety = KNetPage.KHtmlEncode(this.SeachKey.Text.Trim());
        Response.Redirect("SelectSalesClientListProtect.aspx?KSeachKey=" + Sekety + "");
        Response.End();
    }



    /// <summary>
    /// 返回定义属性名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetClient_Name(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,ClientValue,Client_Name from KNet_Sales_ClientAppseting where ClientValue='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["Client_Name"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }
    /// <summary>
    /// 返回省份
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetClient_CustomerProvinces(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select id,code,name from KNet_Static_Province where code='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["name"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }
    /// <summary>
    /// 返回客户名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetCustomerName(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,CustomerValue,CustomerName from KNet_Sales_ClientList where CustomerValue='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["CustomerName"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }

    /// <summary>
    /// 返回客户地址
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetCustomerNameAdress(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,CustomerValue,CustomerName,CustomerAddress from KNet_Sales_ClientList where CustomerValue='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["CustomerAddress"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }
    /// <summary>
    /// 按省城 筛选记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button12_Click1(object sender, EventArgs e)
    {
        string CustomerProvinces = this.sheng.Value.ToString();
        string CustomerCity = "0";
        if (Request["city"] != null && Request["city"] != "")
        {
            CustomerCity = Request["city"].Trim();
        }

        Response.Redirect("SelectSalesClientListProtect.aspx?CustomerProvinces=" + CustomerProvinces + "&CustomerCity=" + CustomerCity + "&Css1=Div22");
        Response.End();
    }
}
