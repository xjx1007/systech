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
using System.Runtime.Serialization.Json;

using KNet.DBUtility;
using KNet.Common;
using System.Net;

public partial class Sales_ShipWareOut_Manage_BCw : BasePage
{
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("发货出库列表") == false)
            {

                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            else
            {
                string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"];
                if (s_ID != "")
                {
                    if (AM.CheckLogin("财务审核出库单") == true)
                    {
                        KNet.BLL.KNet_WareHouse_DirectOutList bll = new KNet.BLL.KNet_WareHouse_DirectOutList();
                        KNet.Model.KNet_WareHouse_DirectOutList Model = bll.GetModelB(s_ID);
                        string s_CheckYN="3";
                        if (Model.KWD_LlState == 2)
                        {
                            s_CheckYN = "3";
                        }
                        else
                        {
                            s_CheckYN = "2";
                        }
                        string sql = " update KNet_WareHouse_DirectOutList  set KWD_LlState=" + s_CheckYN + ",DirectOutCheckStaffNo ='" + AM.KNet_StaffNo + "'  where  DirectOutNo='" + s_ID + "' ";
                        DbHelperSQL.ExecuteSql(sql);
                    }
                }
                //删除发货出库
                if (AM.YNAuthority("删除发货出库") == false)
                {
                    this.Btn_Del.Enabled = false;
                }
                this.DataGridBind();
                base.Base_DropBatchBind(this.Ddl_Batch, "KNet_WareHouse_DirectOutList", "KWD_DutyPerson");
                base.Base_DropBindSearch(this.bas_searchfield, "KNet_WareHouse_DirectOutList");
                base.Base_DropBindSearch(this.Fields, "KNet_WareHouse_DirectOutList");
                this.Btn_Del.Attributes.Add("onclick", "return confirm('您确定要把所选择的记录删除吗？')");
            }
        }
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
            string DirectOutNo = MyGridView1.DataKeys[e.Row.RowIndex].Value.ToString(); //获取ID值
            CheckBox cb = (CheckBox)e.Row.Cells[1].FindControl("Chbk");
            KNet.BLL.KNet_WareHouse_DirectOutList Bll = new KNet.BLL.KNet_WareHouse_DirectOutList();
            KNet.Model.KNet_WareHouse_DirectOutList Model = Bll.GetModelB(DirectOutNo);
         
        }
    }
    private void DataGridBind()
    {
        KNet.BLL.KNet_WareHouse_DirectOutList BLL = new KNet.BLL.KNet_WareHouse_DirectOutList();
        KNet.Model.KNet_WareHouse_DirectOutList Model = new KNet.Model.KNet_WareHouse_DirectOutList();

        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string s_Type = "";
        string s_Sql = "Select * from v_RCOutList ";
        string SqlWhere = "where 1=1 ";
        KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
        string s_SonID = Bll_ProductsDetails.GetSonIDs("M160818111359632");
        s_SonID = s_SonID.Replace(",", "','");
        SqlWhere += " and ProductsType  in ('" + s_SonID + "') ";

        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        this.Tbx_WhereID.Text = s_WhereID;
        string s_WhereID1 = Request.QueryString["WhereID1"] == null ? "" : Request.QueryString["WhereID1"].ToString();
        this.Tbx_WhereID1.Text = s_WhereID1;

        if (this.Tbx_WhereID.Text != "")
        {
            SqlWhere += Base_GetBasicWhere(this.Tbx_WhereID.Text);
        }
        if (this.Tbx_WhereID1.Text != "")
        {
            SqlWhere += Base_GetBasicWhere(this.Tbx_WhereID1.Text);
        }
        

        if (this.Ddl_Batch.SelectedValue != "")
        {
            SqlWhere += Base_GetBasicWhere(this.Ddl_Batch.SelectedValue);
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
        SqlWhere += "Order by KWD_CwOutTime desc";
        this.BeginQuery(s_Sql+SqlWhere);
        DataSet ds =(DataSet)this.QueryForDataSet() ;
        Session["Dts_RTable"] = ds;
        this.MyGridView1.DataSource = ds;
        this.MyGridView1.DataKeyNames = new string[] { "DirectOutNo" };
        this.MyGridView1.DataBind();
    }

    protected void Btn_Show_Click(object sender, EventArgs e)
    {
        if (this.MyGridView1.AllowPaging)
        {
            this.Btn_Show.Text = "收缩";
            this.MyGridView1.AllowPaging = false;
            this.DataGridBind();
        }
        else
        {
            this.Btn_Show.Text = "显示全部";
            this.MyGridView1.AllowPaging = true;
            this.DataGridBind();
        }
    }
    /// <summary>
    /// 采购总数量
    /// </summary>
    /// <param name="s_Order"></param>
    /// <returns></returns>
    public string Base_GetShipDetailBNumbers(string s_DirectOutNo, bool b_Battry)
    {
        string s_Return = "";
        if (b_Battry == false)
        {
            string s_Sql = "Select Sum(Isnull(KWD_BNumber,0)) as DirectOutAmount from KNet_WareHouse_DirectOutList_Details a join KNet_Sys_Products b on a.ProductsBarCode=b.ProductsBarCode Where DirectOutNo='" + s_DirectOutNo + "'";
            KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
            string s_SonID = Bll_ProductsDetails.GetSonIDs("01");
            s_SonID = s_SonID.Replace(",", "','");
            s_Sql += " and b.ProductsType in ('" + s_SonID + "') ";

            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            if (this.Dtb_Result.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Result.Rows.Count; i++)
                {
                    s_Return = Dtb_Result.Rows[i]["DirectOutAmount"].ToString();
                }
            }
        }
        if (s_Return == "0")
        {
            s_Return = base.Base_GetShipDetailNumbers(s_DirectOutNo, b_Battry);
        }
        return s_Return;
    }
    public string GetShipType(string s_OutWareNo)
    {
        string s_Return = "";
        try
        {
            KNet.BLL.KNet_Sales_OutWareList Bll = new KNet.BLL.KNet_Sales_OutWareList();
            KNet.Model.KNet_Sales_OutWareList Model = Bll.GetModelB(s_OutWareNo);
            s_Return = base.Base_GetBasicCodeName("145", Model.KSO_Type);
        }
        catch { }
        return s_Return;
    }
    /// <summary>
    /// 返回发货跟踪 最新一条记录（Y）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetDirectOutListfollowup(object DirectOutNo, object KWD_LlState)
    {
        string s_Return = "";
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select top 1 * from KNet_Sales_OutWareList_FlowList where OutWareNo='" + DirectOutNo + "' order by FollowDateTime desc";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                if (dr["KSO_ISFH"].ToString() == "101")
                {
                    s_Return = "<img src=\"../images/takman.gif\" width=\"11\" height=\"14\" border=\"0\" /><a href=\"#\" style=\"line-height: 22px;\" onclick=\"lhgdialog.opendlg('出库单号:<font color=Red>" + DirectOutNo + "</font> 跟踪', '../SalesOut/Knet_Sales_Ship_Manage_Talks_List.aspx?DirectOutNo=" + DirectOutNo + "', 780, 500,false,false);\">" + KNetPage.CutString(dr["FollowText"].ToString().Trim(), 40) + "</a>&nbsp;<font color=red>已发</font>";//&nbsp;<font color=\"gray\">" + base.Base_GetUserName(dr["FollowStaffNo"].ToString()) + "&nbsp;(" + dr["FollowDateTime"].ToString() + ")</font>

                }
                else
                {
                    s_Return = "<img src=\"../images/takman.gif\" width=\"11\" height=\"14\" border=\"0\" /><a href=\"#\" style=\"line-height: 22px;\" onclick=\"lhgdialog.opendlg('出库单号:<font color=Red>" + DirectOutNo + "</font> 跟踪', '../SalesOut/Knet_Sales_Ship_Manage_Talks_List.aspx?DirectOutNo=" + DirectOutNo + "', 780, 500,false,false);\">" + KNetPage.CutString(dr["FollowText"].ToString().Trim(), 40) + "</a>&nbsp;<img src=\"../images/45.gif\" width=\"11\" height=\"11\" border=\"0\" />";

                    s_Return += "<a href=\"#\" onclick=\"lhgdialog.opendlg('出库单号:<font color=Red>" + DirectOutNo + "</font> 跟踪', '../SalesOut/Knet_Sales_Ship_Manage_Talks_Add.aspx?DirectOutNo=" + DirectOutNo + "', 780, 500,false,false);\">添加</a>";

                }
                return s_Return;
            }
            else
            {
                return "<a href=\"#\" onclick=\"lhgdialog.opendlg('出库单号:<font color=Red>" + DirectOutNo + "</font> 跟踪', '../SalesOut/Knet_Sales_Ship_Manage_Talks_Add.aspx?DirectOutNo=" + DirectOutNo + "', 780, 500,false,false);\">添加</a>";
            }
        }
    }
    protected void Btn_Query_Click(object sender, EventArgs e)
    {
        this.DataGridBind();
    }
    /// <summary>
    /// 返回发货跟踪 最新一条记录（Y）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetOutWareListfollowup(object OutWareNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select top 1 ID,FollowNo,OutWareNo,FollowDateTime,FollowStaffNo,FollowText,FollowEnd from KNet_Sales_OutWareList_FlowList where OutWareNo='" + OutWareNo + "' order by FollowDateTime desc";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["FollowEnd"].ToString() == "True")
                {
                    return "<img src=\"../images/takman.gif\" width=\"11\" height=\"14\" border=\"0\" /><a href=\"#\" style=\"line-height: 22px;\" onclick=\"lhgdialog.opendlg('发货单号:<font color=Red>" + OutWareNo + "</font> 跟踪', '../SalesShip/Knet_Sales_Ship_Manage_Talks_List.aspx?OutWareNo=" + OutWareNo + "', 780, 400,false,false);\">" + KNetPage.CutString(dr["FollowText"].ToString().Trim(), 40) + "</a>&nbsp;<font color=red>结束</font>";//&nbsp;<font color=\"gray\">" + base.Base_GetUserName(dr["FollowStaffNo"].ToString()) + "&nbsp;(" + dr["FollowDateTime"].ToString() + ")</font>
                }
                else
                {
                    return "<img src=\"../images/takman.gif\" width=\"11\" height=\"14\" border=\"0\" /><a href=\"#\" style=\"line-height: 22px;\" onclick=\"lhgdialog.opendlg('发货单号:<font color=Red>" + OutWareNo + "</font> 跟踪', '../SalesShip/Knet_Sales_Ship_Manage_Talks_List.aspx?OutWareNo=" + OutWareNo + "', 780, 400,false,false);\">" + KNetPage.CutString(dr["FollowText"].ToString().Trim(), 40) + "</a>&nbsp;<img src=\"../images/45.gif\" width=\"11\" height=\"11\" border=\"0\" /><a href=\"#\" onclick=\"lhgdialog.opendlg('发货单号:<font color=Red>" + OutWareNo + "</font> 跟踪', '../SalesShip/Knet_Sales_Ship_Manage_Talks_Add.aspx?OutWareNo=" + OutWareNo + "', 780, 400,false,false);\"></a>";
                }
            }
            else
            {
                return "";
            }
        }
    }
    /// <summary>
    /// 返回审核情况
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetOrderCheckYN(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,DirectOutNo,KWD_LlState from KNet_WareHouse_DirectOutList where DirectOutNo='" + aa + "' ";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["KWD_LlState"].ToString() == "1")
                {
                    return "<a href=\"Sales_ShipWareOut_Manage_Cw.aspx?ID="+aa+"\"><font color=Green>部门已审</font></a>";
                }
                else if (dr["KWD_LlState"].ToString() == "3")
                {
                    return "<a href=\"Sales_ShipWareOut_Manage_Cw.aspx?ID=" + aa + "\"><font color=red>财务已审</font></a>";
                }
                else
                {
                    return "<font color=blue>未审核</font>";
                }
            }
            else
            {
                return "--";
            }
        }
    }


    public string GetKDSateName(string s_WareNo)
    {
        string s_Rturn = "";
        this.BeginQuery("Select * from KNet_Sales_OutWareList_FlowList where OutWareNo='" + s_WareNo + "' and KDCodeName<>'' and KDCode<>'' ");
        this.QueryForDataTable();
        DataTable Dtb_DataTable = this.Dtb_Result;
        if (Dtb_DataTable.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_DataTable.Rows.Count; i++)
            {
                string s_KDName = Dtb_DataTable.Rows[i]["KDName"].ToString();
                string s_Code = Dtb_DataTable.Rows[i]["KDCode"].ToString();
                string s_CodeName = Dtb_DataTable.Rows[i]["KDCodeName"].ToString();
                string s_ID = Dtb_DataTable.Rows[i]["ID"].ToString();
                string s_State = Dtb_DataTable.Rows[i]["State"] == null ? "" : Dtb_DataTable.Rows[i]["State"].ToString();
                if (s_State == "")
                {
                    String url = "http://api.ickd.cn/?com=" + s_KDName + "&nu=" + s_Code + "&id=F358C662FEC3E1CAA2C8C20DD2F9A448&type=json";
                    string jsonString = "";
                    this.BeginQuery("Select * from PB_Basic_Wl where PBW_Name='" + s_CodeName + "'");
                    this.QueryForDataTable();
                    if (this.Dtb_Result.Rows.Count > 0)
                    {

                        if (this.Dtb_Result.Rows[0]["PBW_URL"].ToString() != "")
                        {
                            WebPage webInfo = new WebPage(this.Dtb_Result.Rows[0]["PBW_Url"].ToString() + s_Code);
                            string s_Detiles = webInfo.M_html.Replace("请输入运单编号", "");
                            if (s_Detiles.IndexOf("签收") > 0)
                            {
                                s_State = "<Font Color=red>已签收</Font>";
                            }
                            else if (s_Detiles.IndexOf("SORRY") > 0)
                            {
                                s_State = "<Font Color=Black>查询失败<Font Color=Blue>";
                            }
                            else
                            {
                                s_State = "<Font Color=Blue>正常</Font>";
                            }
                        }
                        else
                        {
                            try
                            {
                                jsonString = getPageInfo(url);
                                KDDetails KdDetail = JsonHelper.ParseFromJson<KDDetails>(jsonString);
                                s_State = GetSateName(KdDetail.status);
                            }
                            catch (Exception ex)
                            {
                                s_State = "错误！";
                            }
                        }
                    }
                    if (s_State == "<Font Color=red>已签收</Font>")
                    {
                        KNet.BLL.KNet_Sales_OutWareList_FlowList BLL_Flow = new KNet.BLL.KNet_Sales_OutWareList_FlowList();
                        KNet.Model.KNet_Sales_OutWareList_FlowList Model_Flow = new KNet.Model.KNet_Sales_OutWareList_FlowList();
                        Model_Flow.ID = s_ID;
                        Model_Flow.State = s_State;
                        BLL_Flow.UpDataSate(Model_Flow);
                    }
                }
                s_Rturn += "<a href=\"#\"  onclick=\"javascript:window.open('Knet_Sales_Ship_Manage_Talks_Detail.aspx?com=" + s_KDName + "&Code=" + s_Code + "&Name=" + s_CodeName + "','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=580,height=250');\">";

                s_Rturn += " " + s_State + " </a>" + ",";
            }

        }

        return s_Rturn == "" ? "" : s_Rturn.Substring(0, s_Rturn.Length - 1);
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

    public void btnBasicSearch_Click(object sender, EventArgs e)
    {
        this.advSearch.Style["display"] = "none";
        this.Search_basic.Style["display"] = "block";
        this.DataGridBind();
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
        this.DataGridBind();
    }

    protected void Ddl_Batch_TextChanged1(object sender, EventArgs e)
    {
        this.DataGridBind();
    }
    protected void Btn_Del_Click(object sender, ImageClickEventArgs e)
    {

        StringBuilder s_Sql = new StringBuilder();
        StringBuilder s_Log = new StringBuilder();
        try
        {
            for (int i = 0; i < MyGridView1.Rows.Count; i++)
            {
                CheckBox Ckb = (CheckBox)MyGridView1.Rows[i].Cells[0].FindControl("Chbk");
                if (Ckb.Checked)
                {
                    string s_ID = MyGridView1.DataKeys[i].Value.ToString();
                    s_Sql.Append(" delete from  KNet_WareHouse_DirectOutList Where DirectOutNo='" + s_ID + "' ");
                    s_Sql.Append(" delete from  KNet_WareHouse_DirectOutList_Details Where DirectOutNo='" + s_ID + "' ");
                    s_Log.Append(s_ID);
                }
            }
            DbHelperSQL.ExecuteSql(s_Sql.ToString());
            this.DataGridBind();
            AdminloginMess AM = new AdminloginMess();
            AM.Add_Logs("KNet_WareHouse_DirectOutList 删除 编号：" + s_Log + "");
            Alert("删除成功！");
        }
        catch (Exception ex)
        {
            Alert("删除失败！");
            return;
        }
    }


    protected void Btn_SpSave(object sender, EventArgs e)
    {

        StringBuilder s_Sql = new StringBuilder();
        StringBuilder s_Log = new StringBuilder();
        AdminloginMess AM = new AdminloginMess();
        try
        {

            for (int i = 0; i < MyGridView1.Rows.Count; i++)
            {
                CheckBox Ckb = (CheckBox)MyGridView1.Rows[i].Cells[0].FindControl("Chbk");
                if (Ckb.Checked)
                {
                    string s_ID = MyGridView1.DataKeys[i].Value.ToString();

                    if (AM.CheckLogin("财务审核出库单") == true)
                    {
                        KNet.BLL.KNet_WareHouse_DirectOutList bll = new KNet.BLL.KNet_WareHouse_DirectOutList();
                        KNet.Model.KNet_WareHouse_DirectOutList Model = bll.GetModelB(s_ID);
                        string s_CheckYN = "3";
                        if (s_CheckYN != "0")
                        {
                            string sql = " update KNet_WareHouse_DirectOutList  set KWD_LlState=" + s_CheckYN + ",DirectOutCheckStaffNo ='" + AM.KNet_StaffNo + "'  where  DirectOutNo='" + s_ID + "' ";
                            DbHelperSQL.ExecuteSql(sql);
                        }
                    }
                    s_Log.Append(s_ID + ",");
                }
            }
            if (s_Log.ToString() == "")
            {
                Alert("未选择出库单！");
            }
            else
            {
                this.DataBind();
                AM.Add_Logs("KNet_WareHouse_DirectOutList 审批 编号：" + s_Log + "");
                AlertAndRedirect("批量审批成功！", "Sales_ShipWareOut_Manage_BCw.aspx");
            }
        }
        catch (Exception ex)
        {
            Alert("批量审批失败！");
            return;
        }
    }

    protected void Btn_SpSave1(object sender, EventArgs e)
    {

        StringBuilder s_Sql = new StringBuilder();
        StringBuilder s_Log = new StringBuilder();
        AdminloginMess AM = new AdminloginMess();
        try
        {

            for (int i = 0; i < MyGridView1.Rows.Count; i++)
            {
                CheckBox Ckb = (CheckBox)MyGridView1.Rows[i].Cells[0].FindControl("Chbk");
                if (Ckb.Checked)
                {
                    string s_ID = MyGridView1.DataKeys[i].Value.ToString();

                    if (AM.CheckLogin("财务审核出库单") == true)
                    {
                        KNet.BLL.KNet_WareHouse_DirectOutList bll = new KNet.BLL.KNet_WareHouse_DirectOutList();
                        KNet.Model.KNet_WareHouse_DirectOutList Model = bll.GetModelB(s_ID);
                        string s_CheckYN = "1";
                        if (s_CheckYN != "0")
                        {
                            string sql = " update KNet_WareHouse_DirectOutList  set KWD_LlState=" + s_CheckYN + ",DirectOutCheckStaffNo ='" + AM.KNet_StaffNo + "'  where  DirectOutNo='" + s_ID + "' ";
                            DbHelperSQL.ExecuteSql(sql);
                        }
                    }
                    s_Log.Append(s_ID + ",");
                }
            }
            if (s_Log.ToString() == "")
            {
                Alert("未选择出库单！");
            }
            else
            {
                this.DataBind();
                AM.Add_Logs("KNet_WareHouse_DirectOutList 审批 编号：" + s_Log + "");
                AlertAndRedirect("批量审批成功！", "Sales_ShipWareOut_Manage_BCw.aspx");
            }
        }
        catch (Exception ex)
        {
            Alert("批量审批失败！");
            return;
        }
    }

    protected void ImgB_OnClick(object sender, ImageClickEventArgs e)
    {
        Excel export = new Excel();
        string s_FileName = "成品领料单.xls";
        if (this.Tbx_WhereID.Text != "")
        {
            this.BeginQuery("Select PBW_Name from PB_Basic_Where where PBW_ID='" + this.Tbx_WhereID.Text + "'");
            s_FileName = this.QueryForReturn() + s_FileName;
        }
        if (this.Tbx_WhereID1.Text != "")
        {
            this.BeginQuery("Select PBW_Name from PB_Basic_Where where PBW_ID='" + this.Tbx_WhereID1.Text + "'");
            s_FileName = this.QueryForReturn() + s_FileName;
        }
        //if (MyGridView1.AllowPaging == true)
        //{
        //    MyGridView1.AllowPaging = false;
        //    this.DataBind();
        //}
        DataSet Dts_RTable = (DataSet)Session["Dts_RTable"];
        export.ExcelExport(GetStringWriter(Dts_RTable.Tables[0]), s_FileName);
    }
    public StringWriter GetStringWriter(DataTable dt)
    {
        StringWriter sw = new StringWriter();

        //先写列的表头，这样保证如果没有数据也能输出列表头 
        sw.Write("编号  " + "\t ");
        sw.Write("出库单号  " + "\t ");
        sw.Write("日期 " + "\t ");
        sw.Write("料号 " + "\t ");       
        sw.Write("产品名称 " + "\t ");
        sw.Write("产品版本号 " + "\t ");
        sw.Write("领料数量 " + "\t ");
       
        sw.Write("出库厂库 " + "\t ");
        sw.Write("领料人 " + "\t ");
        //sw.Write("备注 " + "\t ");
        sw.Write(sw.NewLine);

        //如果包含数据 
        if (dt != null)
        {
            //写数据 
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                sw.Write(i.ToString() + "\t");
               
                sw.Write(dr["DirectOutNo"].ToString()+"\t ");
                sw.Write(base.DateToString(dr["KWD_CWOutTime"].ToString()) + "\t ");
                sw.Write(Base_GetProductsCode(dr["ProductsBarCode"].ToString()) + "\t ");
                sw.Write(base.Base_GetProdutsName(dr["ProductsBarCode"].ToString()) + "\t ");
                sw.Write(Base_GetProductsEdition_Link1(dr["ProductsBarCode"].ToString()) + "\t ");
                sw.Write(dr["KWD_BNumber"].ToString() + "\t ");
                
                sw.Write(Base_GetHouseName(dr["HouseNo"].ToString()) + "\t ");
                sw.Write(Base_GetUserName(dr["DirectOutStaffNo"].ToString()) + "\t ");
                

                //换行 
                sw.Write(sw.NewLine);
                i++;
            }
        }
        sw.Close();
        return sw;
    }
}
