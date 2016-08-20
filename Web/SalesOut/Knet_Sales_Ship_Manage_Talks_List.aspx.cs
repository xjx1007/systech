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
using System.Runtime.Serialization.Json;
using KNet.DBUtility;
using KNet.Common;
using System.Net;

/// <summary>
/// 发货跟踪信息 列表
/// </summary>
public partial class KNet_Web_Sales_Knet_Sales_Ship_Manage_Talks_List : BasePage
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
    }
    public class KDDetails
    {

        private string _status;
        private string _errCode;
        private string _message;

        public string status
        {
            set { _status = value; }
            get { return _status; }
        }
        public string errCode
        {
            set { _errCode = value; }
            get { return _errCode; }
        }
        public string message
        {
            set { _message = value; }
            get { return _message; }
        }
    }

    public class KDData
    {
        private string _time;
        private string _context;
        public string time
        {
            set { _time = value; }
            get { return _time; }
        }
        public string context
        {
            set { _context = value; }
            get { return _context; }
        }
    }
　　
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "发货跟踪信息";

        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("发货单跟踪") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
            else
            {
                if (AM.YNAuthority("发货单跟踪删除"))
                {
                    this.Button2.Enabled = true;
                }
                else
                {

                    this.Button2.Enabled = false;
                }



                    ViewState["SortOrder"] = "FollowDateTime";
                    ViewState["OrderDire"] = "Desc";
                    this.Button2.Attributes.Add("onclick", "return confirm('您确定要把所选择的记录删除吗？')");

                    if (Request.QueryString["DirectOutNo"] != null && Request.QueryString["DirectOutNo"] != "")
                    {
                        this.HyperLink2.NavigateUrl = "Knet_Sales_Ship_Manage_Talks_Add.aspx?DirectOutNo=" + Request.QueryString["DirectOutNo"].Trim() + "&Sn=" + DateTime.Now.ToFileTimeUtc().ToString() + "";
                        this.HyperLink1.NavigateUrl = "Knet_Sales_Ship_Manage_Talks_List.aspx?DirectOutNo=" + Request.QueryString["DirectOutNo"].Trim() + "&Sn=" + DateTime.Now.ToFileTimeUtc().ToString() + "";
                    }
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
    public string GetKDName(string s_Code)
    {
        this.BeginQuery("Select * From Pb_Basic_WL where PBW_Name='"+s_Code+"'");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            return Dtb_Result.Rows[0]["PBW_Name"].ToString();

        }
        else
        {
            return "--";
        }
    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.KNet_Sales_OutWareList_FlowList bll = new KNet.BLL.KNet_Sales_OutWareList_FlowList();
        string SqlWhere = " 1=1 ";


        if (Request.QueryString["DirectOutNo"] != null && Request.QueryString["DirectOutNo"] != "")
        {
            string DirectOutNo = Request.QueryString["DirectOutNo"].ToString().Trim();
            SqlWhere = SqlWhere + " and  OutWareNo = '" + DirectOutNo + "' ";
        }
        if (Request.QueryString["OutWareNo"] != null && Request.QueryString["OutWareNo"] != "")
        {
            string OutWareNo = Request.QueryString["OutWareNo"].ToString().Trim();
            SqlWhere = SqlWhere + " and   OutWareNo in (Select DirectOutNo From KNet_WareHouse_DirectOutlist Where KWD_ShipNo='" + OutWareNo + "')  ";
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
            GridView1.DataKeyNames = new string[] { "ID" };
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
    /// 确定选择删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        string sql = "delete from KNet_Sales_OutWareList_FlowList where"; 
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
        LogAM.Add_Logs("销售管理--->发货跟踪内容--->跟踪内容删除 操作成功！");

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
    /// 返回员工名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetStaffName(object StaffNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,StaffNo,StaffName from KNet_Resource_Staff where StaffNo='" + StaffNo + "'";
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
    public string GetKDSateName(string s_KDName, string s_Code, string s_KDCodeName)
    {

        String url = "http://api.ickd.cn/?com=" + s_KDName + "&nu=" + s_Code + "&id=F358C662FEC3E1CAA2C8C20DD2F9A448&type=json";
        string jsonString = "";
        string s_Return = "";
        this.BeginQuery("Select * from PB_Basic_Wl where PBW_Name='" + s_KDCodeName + "'");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {

            if (this.Dtb_Result.Rows[0]["PBW_Code"].ToString() == "")
            {
                WebPage webInfo = new WebPage(this.Dtb_Result.Rows[0]["PBW_Url"].ToString() + s_Code);
                string s_Detiles = webInfo.M_html.Replace("请输入运单编号", "");
                if (s_Detiles.IndexOf("签收") > 0)
                {
                    s_Return = "<Font Color=red>已签收</Font>";
                }
                else if (s_Detiles.IndexOf("SORRY") > 0)
                {
                    s_Return = "<Font Color=Black>查询失败<Font Color=Blue>";
                }
                else
                {
                    s_Return = "<Font Color=Blue>正常</Font>";
                }

            }
            else
            {

                try
                {
                    jsonString = getPageInfo(url);
                    KDDetails KdDetail = JsonHelper.ParseFromJson<KDDetails>(jsonString);
                    s_Return = GetSateName(KdDetail.status);
                }
                catch
                {
                    s_Return = "错误！";
                }

            }
        }
        return s_Return;

    }

    public static string getPageInfo(String url)
    {
        WebResponse wr_result = null;
        StringBuilder txthtml = new StringBuilder();
        try
        {
            WebRequest wr_req = WebRequest.Create(url);
            wr_req.Timeout = 50;
            wr_result = wr_req.GetResponse();
            Stream ReceiveStream = wr_result.GetResponseStream();
            Encoding encode = System.Text.Encoding.GetEncoding("gb2312");
            StreamReader sr = new StreamReader(ReceiveStream, encode);
            if (true)
            {
                Char[] read = new Char[256];
                int count = sr.Read(read, 0, 256);
                while (count > 0)
                {
                    String str = new String(read, 0, count);
                    txthtml.Append(str);
                    count = sr.Read(read, 0, 256);
                }
            }
        }
        catch (Exception)
        {
            txthtml.Append("err");
        }
        finally
        {
            if (wr_result != null)
            {
                wr_result.Close();
            }
        }
        return txthtml.ToString();
    }
    public string GetSateName(string s_ID)
    {
        string s_Return = "";
        //0表示查询失败，1正常，2派送中，3已签收，4退回
        switch (int.Parse(s_ID))
        {
            case 0:
                s_Return = "<Font Color=Black>查询失败<Font Color=Blue>";
                break;
            case 1:
                s_Return = "<Font Color=Blue>正常</Font>";
                break;
            case 2:
                s_Return = "<Font Color=Green>派送中</Font>";
                break;
            case 3:
                s_Return = "<Font Color=red>已签收</Font>";
                break;
        }
        return s_Return;

    }
    //错误代码，0无错误，1单号不存在，2验证码错误，3链接查询服务器失败，4程序内部错误，5程序执行错误，6快递单号格式错误，7快递公司错误，10未知错误。
    public string GetErrorName(string s_ID)
    {
        string s_Return = "";
        //0表示查询失败，1正常，2派送中，3已签收，4退回
        switch (int.Parse(s_ID))
        {
            case 0:
                s_Return = "无错误";
                break;
            case 1:
                s_Return = "单号不存在";
                break;
            case 2:
                s_Return = "验证码错误";
                break;
            case 3:
                s_Return = "链接查询服务器失败";
                break;
            case 4:
                s_Return = "程序内部错误";
                break;
            case 5:
                s_Return = "程序执行错误";
                break;
            case 6:
                s_Return = "快递单号格式错误";
                break;
            case 7:
                s_Return = "快递公司错误";
                break;
            case 10:
                s_Return = "未知错误";
                break;
        }
        return s_Return;
 
    }
}
