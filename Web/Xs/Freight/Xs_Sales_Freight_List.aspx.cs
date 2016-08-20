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

public partial class Xs_Sales_Freight_List : BasePage
{
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            this.Lbl_Title.Text = "运费承担列表";
            AdminloginMess AM = new AdminloginMess();

            base.Base_DropBindSearch(this.bas_searchfield, "Xs_Sales_Freight");
            base.Base_DropBindSearch(this.Fields, "Xs_Sales_Freight");
            base.Base_DropBatchBind(this.Ddl_Batch, "Xs_Sales_Freight", "XSF_Creator");
            //this.Ddl_Batch.SelectedValue = " and XSF_Creator='" + AM.KNet_StaffNo + "'";
            if (AM.CheckLogin(this.Lbl_Title.Text) == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            this.Btn_Del.Attributes.Add("onclick", "return confirm('你确信要删除所选记录吗?！')");
            this.DataShows();
        }
    }

    public void btnBasicSearch_Click(object sender, EventArgs e)
    {
        this.advSearch.Style["display"] = "none";
        this.Search_basic.Style["display"] = "block";
        this.DataShows();
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
        this.DataShows();
    }

    public void DataShows()
    {
        AdminloginMess AM = new AdminloginMess();

        KNet.BLL.Xs_Sales_Freight bll = new KNet.BLL.Xs_Sales_Freight(); 
        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string s_Type = "";

        string SqlWhere = "XSF_Del=0 ";
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

        //仅查看自己
        if (AM.YNAuthority("快递仅自己查看") == true)
        {
            if (AM.KNet_StaffName != "项洲")
            {
                SqlWhere += " and (XSF_Creator='" + AM.KNet_StaffNo + "' ";
                //共享给自己的
                SqlWhere += " or XSF_ID in (Select PBS_FromID From PB_Basic_Share where PBS_ToPersonID='" + AM.KNet_StaffNo + "')";
                //辅助人员
                SqlWhere += " or XSF_DutyPerson='" + AM.KNet_StaffNo + "') ";
            }
        }
        SqlWhere += " Order by XSF_MTime desc";
        DataSet ds = bll.GetList(SqlWhere);
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "XSF_ID" };
        GridView1.DataBind();
        ds.Dispose();
    }

    protected string GetCheckYN(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            AdminloginMess AM = new AdminloginMess();
            conn.Open();
            string Dostr = "select XSF_ID,XSF_CheckYN,XSF_Flow from Xs_Sales_Freight where XSF_ID='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["XSF_CheckYN"].ToString() == "1")
                {
                    string StrPop = "<img src=\"/images/gou.gif\"  border=\"0\" />"; ;
                    return StrPop;
                }
                else
                {
                    string s_Type = dr["XSF_Flow"].ToString();
                    string s_DeptID = Base_GetNextDept(aa.ToString(), s_Type);
                    string s_FlowState = Base_GetNextState(aa.ToString(), s_Type);
                    this.BeginQuery("select * from KNet_Sales_Flow a join KNet_Resource_Staff b on a.KSF_ShPerson=b.StaffNo Where KSF_State='0'   and KSF_ContractNo='" + aa.ToString() + "' and StaffDepart='" + s_DeptID + "' and KSF_Del='0'");
                    this.QueryForDataTable();
                    string JSD = "/Web/CheckYN/CheckYN.aspx?ID=" + aa.ToString() + "&FlowState=" + s_FlowState + "&FlowType=6";
                    string StrPop = "";
                    if (this.Dtb_Result.Rows.Count > 0)
                    {
                        JSD = "Xs_Sales_Freight_View.aspx?ID=" + aa.ToString() + "";
                        StrPop = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=700,height=450');\"  title=\"点击进行审核操作\">查看</a><br/> " + base.Base_GeDept(s_DeptID) + " <font color=Blue>不通过</font>";
                        return StrPop;
                    }
                    //下个审批部门
                    if ((s_DeptID == AM.KNet_StaffDepart) && (AM.KNet_Position == "102"))
                    {

                        StrPop = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=700,height=450');\"  title=\"点击进行审核操作\">审核</a><br/>等待 <font color=red>" + base.Base_GeDept(s_DeptID) + "</font>  审核";
                        return StrPop;
                    }
                    else
                    {
                        JSD = "Xs_Sales_Freight_View.aspx?ID=" + aa.ToString() + "";
                        return "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=700,height=450');\"  title=\"点击进行审核操作\">查看</a><br/>等待 <font color=blue>" + base.Base_GeDept(s_DeptID) + "</font> 审核";
                    }
                }
            }
            else
            {
                return "--";
            }
        }
    }
    public string GetCustomer(string s_ID)
    {
        string s_Return = "";
        try
        {
            KNet.BLL.KNet_WareHouse_DirectOutList Bll = new KNet.BLL.KNet_WareHouse_DirectOutList();
            KNet.Model.KNet_WareHouse_DirectOutList Model = Bll.GetModelB(s_ID);
            s_Return = base.Base_GetCustomerName_Link(Model.KWD_Custmoer);


        }
        catch
        { }
        return s_Return;
    }
    protected void Ddl_Batch_TextChanged(object sender, EventArgs e)
    {
        this.DataShows();
    }
    protected void Btn_Del_Click(object sender, EventArgs e)
    {
        KNet.BLL.Xs_Sales_Freight Bll = new KNet.BLL.Xs_Sales_Freight();
        AdminloginMess AM = new AdminloginMess();
        string s_DelID = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {
                s_DelID += GridView1.DataKeys[i].Value.ToString() + ",";
            }
        }
        s_DelID = s_DelID == "" ? "" : s_DelID.Substring(0, s_DelID.Length - 1);
        s_DelID = s_DelID.Replace(",", "','");
        if (s_DelID == "")
        {
            AlertAndGoBack("您没有选择要删除的记录!");
            Response.End();
        }
        else if (Bll.DeleteList(s_DelID))
        {
            Alert("删除成功！");
            AM.Add_Logs("系统设置--->短消息管理--->短消息删除 操作成功！");
            this.DataShows();
        }
    }
  
    protected void Btn_Search_Click(object sender, EventArgs e)
    {
        this.DataShows();
    }

    protected void Btn_Save_Click(object sender, EventArgs e)
    {
        int i_Type = 2;
        AdminloginMess AM = new AdminloginMess();
        KNet.BLL.PB_Basic_Share Bll_Share = new KNet.BLL.PB_Basic_Share();
        ArrayList Arr_Details = new ArrayList();
        string s_FromID = "";
        for (int i = 0; i < this.GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {
                s_FromID += "" + GridView1.DataKeys[i].Value.ToString() + ",";
            }
        }
        if (s_FromID == "")
        {
            Alert("请选择一条记录！");
            return;
        }
        else
        {
            s_FromID = s_FromID.Substring(0, s_FromID.Length - 1);
        }
        string s_CheckBoxAll = "";
        KNet.BLL.KNet_Resource_OrganizationalStructure Bll_Organizational = new KNet.BLL.KNet_Resource_OrganizationalStructure();
        DataSet Dts_Table = Bll_Organizational.GetList("  STRucPID<>'0'  ");
        if (Dts_Table.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
            {
                string s_Details = Request["DetailView_" + Dts_Table.Tables[0].Rows[i][2].ToString() + ""] == null ? "" : Request["DetailView_" + Dts_Table.Tables[0].Rows[i][2].ToString() + ""].ToString();
                if (s_Details != "")
                {
                    s_CheckBoxAll += s_Details + ",";
                }
            }
        }
        string[] FromID = s_FromID.Split(',');
        //先删除该用户 对该数据其他人员的共享

        for (int j = 0; j < FromID.Length; j++)
        {
            KNet.Model.PB_Basic_Share Model_Share1 = new KNet.Model.PB_Basic_Share();
            Model_Share1.PBS_FromID = FromID[j];
            Model_Share1.PBS_FromPersonID = AM.KNet_StaffNo;
            Model_Share1.PBS_Type = i_Type;
            Bll_Share.deleteOldNoToID(Model_Share1);
        }
        if (s_CheckBoxAll != "")
        {
            s_CheckBoxAll = s_CheckBoxAll.Substring(0, s_CheckBoxAll.Length - 1);
            string[] s_CheckBox = s_CheckBoxAll.Split(',');
            //添加共享
            for (int i = 0; i < s_CheckBox.Length; i++)
            {
                for (int j = 0; j < FromID.Length; j++)
                {
                    KNet.Model.PB_Basic_Share Model_Share = new KNet.Model.PB_Basic_Share();
                    Model_Share.PBS_FromID = FromID[j];
                    Model_Share.PBS_FromPersonID = AM.KNet_StaffNo;
                    Model_Share.PBS_ToPersonID = s_CheckBox[i];
                    Model_Share.PBS_Type = i_Type;
                    Model_Share.PBS_CTime = DateTime.Now;
                    Arr_Details.Add(Model_Share);
                }
            }

            if (Bll_Share.Add(Arr_Details) == true)
            {
                AlertAndRedirect("共享成功！", "Xs_Sales_Freight_List.aspx");
                base.Base_SendMessage(s_CheckBoxAll, KNetPage.KHtmlEncode("有 来自" + AM.KNet_StaffName + " 共享的<a href='Web/Express/Xs_Sales_Freight_List.aspx?Batch=163'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'>快递信息</a>  ，敬请关注！"));
            }
        }
    }

    public string GetKDSateName(string s_XSF_ID)
    {
        string s_Rturn = "";
        this.BeginQuery("Select * from Xs_Sales_Freight where XSF_ID='" + s_XSF_ID + "' and XSF_KDNameCode<>'' and XSF_KDCode<>'' ");
        this.QueryForDataTable();
        DataTable Dtb_DataTable = this.Dtb_Result;
        if (Dtb_DataTable.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_DataTable.Rows.Count; i++)
            {
                string s_KDName = Dtb_DataTable.Rows[i]["XSF_KDNameCode"].ToString();
                string s_Code = Dtb_DataTable.Rows[i]["XSF_KDCode"].ToString();
                string s_CodeName = Dtb_DataTable.Rows[i]["XSF_KDName"].ToString();
                string s_ID = Dtb_DataTable.Rows[i]["XSF_ID"].ToString();
                string s_State = Dtb_DataTable.Rows[i]["XSF_State"] == null ? "" : Dtb_DataTable.Rows[i]["XSF_State"].ToString();
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
}
