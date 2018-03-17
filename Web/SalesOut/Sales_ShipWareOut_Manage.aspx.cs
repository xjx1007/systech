using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
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
using System.Net.Mail;
using System.Diagnostics;
using iTextSharp.text.pdf;
using System.Linq;
using System.Web.Caching;
using System.Xml;

public partial class Web_Sales_Sales_ShipWareOut_Manage : BasePage
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

            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string s_Model = Request.QueryString["Model"] == null ? "" : Request.QueryString["Model"].ToString();
            if ((s_ID != "") && (s_Model == "IsSend"))
            {
                string s_Sql = "Update KNet_WareHouse_DirectOutList set  KWD_IsMail=ABS(KWD_IsMail-1) where ID='" + s_ID + "'";
                DbHelperSQL.ExecuteSql(s_Sql);
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

            //已对帐的不能调整
            KNet.BLL.Cg_Order_Checklist_Details Cg_Details = new KNet.BLL.Cg_Order_Checklist_Details();
            DataSet dts_Cg = Cg_Details.GetList(" COD_DirectOutID in (select ID from KNet_WareHouse_DirectOutList_Details where DirectOutNO='" + DirectOutNo + "') ");
            if (dts_Cg.Tables[0].Rows.Count > 0)
            {
                cb.Enabled = false;
            }
            else
            {
                cb.Enabled = true;
            }
            if ((Model.DirectOutCheckYN == 2)||(Model.DirectOutCheckYN == 3))
            {
                cb.Enabled = false;
            }
            else
            {
                cb.Enabled = true;
            }
        }
    }
    private void DataGridBind()
    {
        string s_Sql = "";
        KNet.BLL.KNet_WareHouse_DirectOutList BLL = new KNet.BLL.KNet_WareHouse_DirectOutList();
        KNet.Model.KNet_WareHouse_DirectOutList Model = new KNet.Model.KNet_WareHouse_DirectOutList();

        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string s_Type = "";
        string SqlWhere = " KWD_Del='0' and KWD_Type='101' ";
        if (s_WhereID != "")
        {
            SqlWhere += Base_GetBasicWhere(s_WhereID);
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
        SqlWhere += "Order by SystemDateTimes desc";
        DataSet ds = BLL.GetList(SqlWhere);
        this.MyGridView1.DataSource = ds;
        this.MyGridView1.DataKeyNames = new string[] { "DirectOutNo" };
        this.MyGridView1.DataBind();
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
    protected string GetDirectOutListfollowup(object DirectOutNo, object DirectOutCheckYN)
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
                    s_Return = "<img src=\"../images/takman.gif\" width=\"11\" height=\"14\" border=\"0\" /><a href=\"#\" style=\"line-height: 22px;\" onclick=\"lhgdialog.opendlg('出库单号:<font color=Red>" + DirectOutNo + "</font> 跟踪', '../SalesOut/Knet_Sales_Ship_Manage_Talks_List.aspx?DirectOutNo=" + DirectOutNo + "', 780, 500,false,false);\">" + KNetPage.CutString(dr["FollowText"].ToString().Trim(), 40) + "&nbsp;<font color=red>已发</font></a>";//&nbsp;<font color=\"gray\">" + base.Base_GetUserName(dr["FollowStaffNo"].ToString()) + "&nbsp;(" + dr["FollowDateTime"].ToString() + ")</font>
          
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
    /// <summary>
    /// 返回审核情况
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetOrderCheckYN(object aa)
    {
        string s_Return="";
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,DirectOutNo,DirectOutCheckYN,KWD_IsMail from KNet_WareHouse_DirectOutList where DirectOutNo='" + aa + "' ";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["DirectOutCheckYN"].ToString() == "2")
                {
                    s_Return= "<font color=Green>仓库已审</font>";
                }
                else if (dr["DirectOutCheckYN"].ToString() == "3")
                {
                    s_Return= "<font color=red>财务已审</font>";
                }
                else if (dr["DirectOutCheckYN"].ToString() == "1")
                {
                    s_Return= "<font color=yellow>已审</font>";
                }
                else
                {
                    s_Return= "<font color=blue>未审核</font>";
                }
                if (dr["KWD_IsMail"].ToString() == "0")
                {
                    s_Return += "<br/><a href='Sales_ShipWareOut_Manage.aspx?ID=" + dr["ID"].ToString() + "&Model=IsSend'><font color=blue>未发送</font></a>";
                }
                else if (dr["KWD_IsMail"].ToString() == "1")
                {
                    s_Return += "<br/><a href='Sales_ShipWareOut_Manage.aspx?ID=" + dr["ID"].ToString() + "&Model=IsSend'><font color=red>已发送</font></a>";
                }
                    return s_Return;
            }
            else
            {
                return "--";
            }

        }
    }


    public string GetKDSateName1(string s_WareNo)
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

                s_State = base.GetKDSateReturnOlnyState(s_KDName, s_Code, s_CodeName, s_State);
                    if (s_State == "<Font Color=red>已签收</Font>")
                    {
                        KNet.BLL.KNet_Sales_OutWareList_FlowList BLL_Flow = new KNet.BLL.KNet_Sales_OutWareList_FlowList();
                        KNet.Model.KNet_Sales_OutWareList_FlowList Model_Flow = new KNet.Model.KNet_Sales_OutWareList_FlowList();
                        Model_Flow.ID = s_ID;
                        Model_Flow.State = s_State;
                        BLL_Flow.UpDataSate(Model_Flow);
                    }
                s_Rturn += "<a href=\"#\"  onclick=\"javascript:window.open('Knet_Sales_Ship_Manage_Talks_Detail.aspx?com=" + s_KDName + "&Code=" + s_Code + "&Name=" + s_CodeName + "','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=580,height=250');\">";
                s_Rturn += " " + s_State + " </a>" + "<br>";
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
    public string GetShipType(string s_OutWareNo)
    {
        string s_Return = "";
        try
        {
            if (s_OutWareNo != "")
            {
                KNet.BLL.KNet_Sales_OutWareList Bll = new KNet.BLL.KNet_Sales_OutWareList();
                KNet.Model.KNet_Sales_OutWareList Model = Bll.GetModelB(s_OutWareNo);
                s_Return = base.Base_GetBasicCodeName("145", Model.KSO_Type);
            }
            else
            {
                s_Return = "正常";
            }
        }
        catch { }
        return s_Return;
    }


    protected string CheckView(string s_OrderNo, string s_DID)
    {
        string s_Return = "", JSD = "";
        KNet.BLL.KNet_WareHouse_DirectOutList BLl = new KNet.BLL.KNet_WareHouse_DirectOutList();
        KNet.Model.KNet_WareHouse_DirectOutList Model = BLl.GetModelB(s_DID);
        if (Model.DirectOutCheckYN == 0)
        {
            s_Return = "";
        }
        else
        {

            JSD = "Sales_ShipWareOut_Print.aspx?ID=" + s_OrderNo + "&DID=" + s_DID + "";
            s_Return = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=120,left=150,toolbar=yes, menubar=yes,scrollbars=yes, resizable=yes, location=yes, status=yes, width=780,height=500');\"  title=\"点击查看\"><img src=\"../images/View.gif\"  border=\"0\" /></a>";
            s_Return += "  <a href=\"PDF/" + Model.DirectOutNo + ".PDF\" class=\"webMnu\" target=\"_blank\"><img src=\"../images/pdf.gif\"  border=\"0\" /></a> ";
            s_Return += "  <a href=\"../Mail/PB_Basic_Mail_Add.aspx?DireOutNo=" + Model.DirectOutNo + "\" class=\"webMnu\" target=\"_blank\"><img src=\"../images/email.gif\"  border=\"0\" /></a> ";
 }
        return s_Return;

    }
}
