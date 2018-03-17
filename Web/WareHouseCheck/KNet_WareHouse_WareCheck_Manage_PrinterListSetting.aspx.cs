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
/// 打印  模板列表  
/// </summary>
public partial class Knet_Web_Warehouse_KNet_WareHouse_WareCheck_Manage_PrinterListSetting : System.Web.UI.Page
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
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            else
            {

                this.Button2.Attributes.Add("onclick", "return confirm('你确信要删除所选记录吗?！')");

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
        KNet.BLL.KNet_WareHouse_WareCheckList_Printer_Setup bll = new KNet.BLL.KNet_WareHouse_WareCheckList_Printer_Setup();
        string LogtimeA = null;
        string LogtimeB = null;
        string KSeachKey = null;

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

            SqlWhere = SqlWhere + " and ( PrinterDatetime >= '" + LogtimeA + "' and  PrinterDatetime<='" + LogtimeB + "'   ) ";
        }
        if (Request["SeachKey"] != null && Request["SeachKey"] != "")
        {
            KSeachKey = Request.QueryString["SeachKey"].ToString().Trim();
            if (KSeachKey == "") { KSeachKey = null; }
            this.SeachKey.Text = KSeachKey;

            SqlWhere = SqlWhere + " and ( PrinterTitle like '%" + KSeachKey + "%' )";
        }

        using (DataSet ds = bll.GetList(SqlWhere + "order by Pai desc,PrinterDatetime desc"))
        {
            //正反排序------
            DataView dv = ds.Tables[0].DefaultView;
            //--分页-------
            PagedDataSource pds = new PagedDataSource();
            AspNetPager1.RecordCount = dv.Count;
            pds.DataSource = dv;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;
            //--End分页-----
            GridView1.DataSource = pds;
            GridView1.DataKeyNames = new string[] { "Tex_ID" };
            GridView1.DataBind();

        }
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
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Image lk = (Image)e.Row.Cells[1].FindControl("Image2");
            string Tex_ID = GridView1.DataKeys[e.Row.RowIndex].Value.ToString(); //获取CustomerValue值

            if (this.GetKNet_PrinterYN_AuthList(Tex_ID) == true)
            {
                lk.ImageUrl = "~/images/Au1.gif";
            }
            else
            {
                lk.ImageUrl = "~/images/Au2.gif";
            }

            CheckBox cb = (CheckBox)e.Row.Cells[1].FindControl("Chbk");
            if (GetDefaultPrinterYN(Tex_ID) == true)
            {
                cb.Enabled = false;
            }
            else
            {
                cb.Enabled = true;
            }
        }
    }
    /// <summary>
    /// 是否为默认模板
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected bool GetDefaultPrinterYN(string Tex_ID)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,DefaultPrinter,Tex_ID from KNet_WareHouse_WareCheckList_Printer_Setup where Tex_ID='" + Tex_ID + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["DefaultPrinter"].ToString() == "True")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
    /// <summary>
    /// 查查是否已启用
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected bool GetKNet_PrinterYN_AuthList(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select Tex_ID,ID,PrinterYN from KNet_WareHouse_WareCheckList_Printer_Setup where Tex_ID='" + aa + "' ";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["PrinterYN"].ToString() == "True")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
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
        string SeachKeyContent = KNetPage.KHtmlEncode(SeachKey.Text.ToString());
        if ((LogtimeA == "" && LogtimeB != "") || (LogtimeA != "" && LogtimeB == ""))
        {
            Response.Write("<script language=javascript>alert('您所选择的日期一定要有 开始日期 和 结束日期!');history.back(-1);</script>");
            Response.End();
        }
        Response.Redirect("KNet_WareHouse_WareCheck_Manage_PrinterListSetting.aspx?LogtimeA=" + LogtimeA + "&LogtimeB=" + LogtimeB + "&SeachKey=" + SeachKeyContent + "&Css5=Div22");
        Response.End();
    }

    /// <summary>
    /// 添加模板
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("KNet_WareHouse_WareCheck_Manage_PrinterList_Add.aspx?Css5=Div22");
        Response.End();
    }

    /// <summary>
    /// 批量删除记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button12_Click(object sender, EventArgs e)
    {

        string sql = "delete from KNet_WareHouse_WareCheckList_Printer_Setup where DefaultPrinter=0 and "; //删除单
        string sql2 = "delete from KNet_WareHouse_WareCheckList_Printer_Value where"; //明细

        string cal = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {
                cal += " Tex_ID='" + GridView1.DataKeys[i].Value.ToString() + "' or";
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
        LogAM.Add_Logs("库存管理--->库存盘点单打印模板--->模板删除 操作成功！");

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
            }
            GridView1.EditIndex = -1;
            this.DataShows();
        }
        catch { }
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
            if (!chk.Checked && chk.Enabled == true)
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
}
