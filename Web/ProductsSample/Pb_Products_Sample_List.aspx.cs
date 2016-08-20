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
using System.IO;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
using KNet.Common;

public partial class Web_Sales_Pb_Products_Sample_List : BasePage
{
    public string s_DivStyle = "";
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Lbl_Title.Text = "样品申请列表";
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin(this.Lbl_Title.Text) == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
            else
            {
                //删除样品申请
                if (AM.YNAuthority("删除样品申请") == false)
                {
                    this.Btn_Del.Enabled = false;
                }
                DataShows();
                base.Base_DropBatchBind(this.Ddl_Batch, "Pb_Products_Sample", "PPS_DutyPeson");
                base.Base_DropBindSearch(this.bas_searchfield, "Pb_Products_Sample");
                base.Base_DropBindSearch(this.Fields, "Pb_Products_Sample");
            }
        }

    }

    protected string GetOutWareListfollowup(object OutWareNo, string s_Title)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select top 1 ID,FollowNo,OutWareNo,FollowDateTime,FollowStaffNo,FollowText,FollowEnd,ReTime from KNet_Sales_OutWareList_FlowList where OutWareNo='" + OutWareNo + "' order by FollowDateTime desc";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string s_Str = "";
                if ((dr["ReTime"] != null) && (dr["ReTime"].ToString() != ""))
                {
                    s_Str += "交期：" + DateTime.Parse(dr["ReTime"].ToString()).ToShortDateString();
                }
                s_Str += KNetPage.CutString(dr["FollowText"].ToString().Trim(), 40);
                if (dr["FollowEnd"].ToString() == "True")
                {
                    return "<img src=\"../images/takman.gif\" width=\"11\" height=\"14\" border=\"0\" /><a href=\"#\" style=\"line-height: 22px;\" onclick=\"lhgdialog.opendlg('" + s_Title + ":<font color=Red>" + OutWareNo + "</font> 跟踪', '../ProductsSample/Knet_Sales_Ship_Manage_Talks_List.aspx?OutWareNo=" + OutWareNo + "', 780, 400,false,false);\">" + s_Str + "</a>&nbsp;<font color=red>结束</font>";//&nbsp;<font color=\"gray\">" + base.Base_GetUserName(dr["FollowStaffNo"].ToString()) + "&nbsp;(" + dr["FollowDateTime"].ToString() + ")</font>
                }
                else
                {
                    return "<img src=\"../images/takman.gif\" width=\"11\" height=\"14\" border=\"0\" /><a href=\"#\" style=\"line-height: 22px;\" onclick=\"lhgdialog.opendlg('" + s_Title + ":<font color=Red>" + OutWareNo + "</font> 跟踪', '../ProductsSample/Knet_Sales_Ship_Manage_Talks_List.aspx?OutWareNo=" + OutWareNo + "', 780, 400,false,false);\">" + s_Str + "</a>&nbsp;<img src=\"../images/45.gif\" width=\"11\" height=\"11\" border=\"0\" /><a href=\"#\" onclick=\"lhgdialog.opendlg('" + s_Title + ":<font color=Red>" + OutWareNo + "</font> 跟踪', '../ProductsSample/Knet_Sales_Ship_Manage_Talks_Add.aspx?OutWareNo=" + OutWareNo + "', 780, 400,false,false);\">添加</a>";
                }
            }
            else
            {
                return "<a href=\"#\" onclick=\"lhgdialog.opendlg('" + s_Title + ":<font color=Red>" + OutWareNo + "</font> 跟踪', '../ProductsSample/Knet_Sales_Ship_Manage_Talks_Add.aspx?OutWareNo=" + OutWareNo + "', 780, 400,false,false);\">添加</a>";
            }
        }
    }

    protected void Btn_Del_Click(object sender, EventArgs e)
    {
        AdminloginMess LogAM = new AdminloginMess();
        string sql = "delete from Pb_Products_Sample where"; //删除采购单
        string sql2 = "delete from Pb_Products_Sample_Images where"; //采购单明细
        string sql3 = "delete from Pb_Products_Sample_Confim where"; //采购单明细
        string sql4 = "delete from Pb_Products_SampleAsk where"; //采购单明细

        string cal = "", cal2 = "", cal3 = "", cal4 = "";
        for (int i = 0; i < this.MyGridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)MyGridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {
                cal += " PPS_ID='" + MyGridView1.DataKeys[i].Value.ToString() + "' or ";
                cal2 += " PPI_SmapleID='" + MyGridView1.DataKeys[i].Value.ToString() + "' or ";
                cal3 += " PBC_SampleID='" + MyGridView1.DataKeys[i].Value.ToString() + "' or ";
                cal4 += " PPA_SampleID='" + MyGridView1.DataKeys[i].Value.ToString() + "' or ";
            }
        }
        if (cal != "")
        {
            sql += cal.Substring(0, cal.Length - 3);
            sql2 += cal2.Substring(0, cal2.Length - 3);
            sql3 += cal3.Substring(0, cal3.Length - 3);
            sql4 += cal4.Substring(0, cal4.Length - 3);

        }
        else
        {
            sql = "";       //不删除
            sql2 = "";       //不删除
            sql3 = "";       //不删除
            sql4 = "";       //不删除
            Response.Write("<script language=javascript>alert('您没有选择要删除的记录!');history.back(-1);</script>");
            Response.End();
        }

        DbHelperSQL.ExecuteSql(sql4);
        DbHelperSQL.ExecuteSql(sql3);
        DbHelperSQL.ExecuteSql(sql2);
        DbHelperSQL.ExecuteSql(sql);
        Alert("删除成功！");
        LogAM.Add_Logs("产品--->样品申请--->样品申请删除 操作成功！");

        this.DataShows();
    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {

        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string s_Type = "";

        string SqlWhere = " 1=1 ";
        AdminloginMess AM = new AdminloginMess();

        if (s_WhereID != "")
        {
            SqlWhere += Base_GetBasicWhere(s_WhereID);
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
        if (this.Ddl_Batch.SelectedValue != "")
        {
            SqlWhere += Base_GetBasicWhere(this.Ddl_Batch.SelectedValue);

        }
        SqlWhere += " Order by PPS_CTime desc ";
        KNet.BLL.Pb_Products_Sample bll = new KNet.BLL.Pb_Products_Sample();
        DataSet ds = bll.GetList(SqlWhere);
        this.MyGridView1.DataSource = ds;
        MyGridView1.DataKeyNames = new string[] { "PPS_ID" };
        MyGridView1.DataBind();
    }

    protected void Btn_Query_Click(object sender, EventArgs e)
    {
        this.DataShows();


    }

    protected void Ddl_Batch_TextChanged(object sender, EventArgs e)
    {
        this.DataShows();
    }
    public string getShState(string s_ID)
    {
        AdminloginMess AM = new AdminloginMess();
        string s_Return = "";
        try
        {
            KNet.BLL.Pb_Products_Sample Bll = new KNet.BLL.Pb_Products_Sample();
            KNet.Model.Pb_Products_Sample Model = Bll.GetModel(s_ID);
            if (Model.PPS_Type == "1")//样品领用
            {
                if (Model.PPS_Dept == "0")
                {
                    //市场销售部审批
                    if ((AM.KNet_StaffDepart == "129652783822281241") && (AM.KNet_Position == "102"))
                    {
                        s_Return = "<a href='Pb_Products_Sample_Approval.aspx?ID=" + s_ID + "&Type=0'>审批</a><br>等待 <font color=red>市场销售部</font> 审批";
                    }
                    else
                    {
                        s_Return = "等待 <font color=red>市场销售部</font> 审批";
                    }
                }
                else if (Model.PPS_Dept == "1")
                {
                    //市场销售部审批
                    if (AM.KNet_StaffDepart == "129757466300748845")
                    {
                        s_Return = "<a href='Pb_Products_Sample_Approval.aspx?ID=" + s_ID + "&Type=0'>审批</a><br>等待 <font color=red>物料部（仓库）</font> 审批";
                    }
                    else
                    {
                        s_Return = "等待 <font color=red>物料部（仓库）</font> 审批";
                    }
                }
                else if (Model.PPS_Dept == "2")//部门没通过申请
                {
                    //市场销售部审批
                    if (AM.KNet_StaffNo == Model.PPS_DutyPeson)
                    {
                        s_Return = "<a href='Pb_Products_Sample_Add.aspx?ID=" + s_ID + "&Type=M'>修改确认</a><br>等待 <font color=red>" + base.Base_GetUserName(Model.PPS_DutyPeson) + "</font> 审批";
                    }
                    else
                    {
                        s_Return = "等待 <font color=red>" + base.Base_GetUserName(Model.PPS_DutyPeson) + "</font> 确认";
                    }
                }
            }
            else
            {
                if ((Model.PPS_Type == "2") && ((Model.PPS_Dept == "22") || (Model.PPS_Dept == "0")))//如果是设计修改 需要供应链平台审批
                {
                    if (Model.PPS_Dept == "22")//部门没通过申请
                    {
                        //市场销售部审批
                        if (AM.KNet_StaffNo == Model.PPS_DutyPeson)
                        {
                            s_Return = "<a href='Pb_Products_Sample_Add.aspx?ID=" + s_ID + "&Type=M'>修改确认</a><br>等待 <font color=red>" + base.Base_GetUserName(Model.PPS_DutyPeson) + "</font> 审批";
                        }
                        else
                        {
                            s_Return = "等待 <font color=red>" + base.Base_GetUserName(Model.PPS_DutyPeson) + "</font> 确认";
                        }
                    }
                    else
                    {
                        //研发中心审批
                        if ((AM.KNet_StaffDepart == "129652784259578018") && (AM.KNet_Position == "102"))
                        {
                            s_Return = "<a href='Pb_Products_Sample_Approval.aspx?ID=" + s_ID + "&Type=0'>审批</a><br>等待 <font color=red>供应链平台</font> 审批";
                        }
                        else
                        {
                            s_Return = "等待 <font color=red>供应链平台</font> 审批";
                        }
                    }
                }
                else
                {
                    if (Model.PPS_Dept == "2")//部门没通过申请
                    {
                        //市场销售部审批
                        if (AM.KNet_StaffNo == Model.PPS_DutyPeson)
                        {
                            s_Return = "<a href='Pb_Products_Sample_Add.aspx?ID=" + s_ID + "&Type=M'>修改确认</a><br>等待 <font color=red>" + base.Base_GetUserName(Model.PPS_DutyPeson) + "</font> 审批";
                        }
                        else
                        {
                            s_Return = "等待 <font color=red>" + base.Base_GetUserName(Model.PPS_DutyPeson) + "</font> 确认";
                        }
                    }
                    else if ((Model.PPS_Dept == "0") || (Model.PPS_Dept == "21"))
                    {
                        //研发中心审批
                        if ((AM.KNet_StaffDepart == "129652783965723459") && (AM.KNet_Position == "102"))
                        {
                            s_Return = "<a href='Pb_Products_Sample_Approval.aspx?ID=" + s_ID + "&Type=0'>审批</a><br>等待 <font color=red>研发经理</font> 审批";
                        }
                        else
                        {
                            s_Return = "等待 <font color=red>研发经理</font> 审批";
                        }
                    }

                    else if ((Model.PPS_Dept == "5") || (Model.PPS_Dept == "20"))
                    {
                        //研发中心审批
                        if ((AM.KNet_StaffDepart == "129652783965723459"))
                        {
                            s_Return = "<a href='Pb_Products_Sample_Approval.aspx?ID=" + s_ID + "&Type=0'>审批</a><br>等待 <font color=red>外观确认</font> 审批";
                        }
                        else
                        {
                            s_Return = "等待 <font color=red>外观确认</font> 审批";
                        }
                    }
                    else if ((Model.PPS_Dept == "1") || (Model.PPS_Dept == "7"))
                    {
                        //研发中心审批
                        if ((AM.KNet_StaffDepart == "129652783965723459"))
                        {
                            s_Return = "<a href='Pb_Products_Sample_Approval.aspx?ID=" + s_ID + "&Type=0'>审批</a><br>等待 <font color=red>程序确认</font> 审批";
                        }
                        else
                        {
                            s_Return = "等待 <font color=red>程序确认</font> 审批";
                        }
                    }

                    //15 修改确认
                    else if ((Model.PPS_Dept == "15") || (Model.PPS_Dept == "9") || (Model.PPS_Dept == "19"))//部门通过申请或者设计修改
                    {
                        //研发中心审批
                        if (AM.KNet_StaffDepart == "129652783965723459") //&& (AM.KNet_Position == "102"))
                        {
                            s_Return = "<a href='Pb_Products_Sample_Approval.aspx?ID=" + s_ID + "&Type=0'>审批</a><br>等待 <font color=red>研发中心</font> 审批";
                        }
                        else
                        {
                            s_Return = "等待 <font color=red>研发中心</font> 审批";
                        }
                    }
                    else if (Model.PPS_Dept == "8")
                    {

                        //研发中心审批
                        if ((AM.KNet_StaffDepart == "129652783965723459"))
                        {
                            s_Return = "<a href='Pb_Products_Sample_Approval.aspx?ID=" + s_ID + "&Type=0'>审批</a><br>等待 <font color=red>安排打样</font> 审批";
                        }
                        else
                        {
                            s_Return = "等待 <font color=red>安排打样</font> 审批";
                        }
                    }
                    else if ((Model.PPS_Dept == "4") || (Model.PPS_Dept == "6") || (Model.PPS_Dept == "12") || (Model.PPS_Dept == "18"))//设计评审或者设计修改评审样品提交
                    {

                        //市场销售部审批
                        if (AM.KNet_StaffNo == Model.PPS_DutyPeson)
                        {
                            s_Return = "<a href='Pb_Products_Sample_Approval.aspx?ID=" + s_ID + "&Type=0' >确认</a><br>等待 <font color=red>" + AM.KNet_StaffName + "</font> 确认";
                        }
                        else
                        {
                            s_Return = "等待 <font color=red>" + base.Base_GetUserName(Model.PPS_DutyPeson) + "</font> 确认";
                        }
                    }
                    else if ((Model.PPS_Dept == "10") || (Model.PPS_Dept == "11") || (Model.PPS_Dept == "14") || (Model.PPS_Dept == "16") || (Model.PPS_Dept == "17"))
                    {
                        if (AM.KNet_StaffDepart == "129652784446995911")
                        {
                            s_Return = "<a href='Pb_Products_Sample_Approval.aspx?ID=" + s_ID + "&Type=0'>确认</a><br>等待 <font color=red>质量部</font> 审批";
                        }
                        else
                        {
                            s_Return = "等待 <font color=red>质量部</font> 审批";
                        }
                    }
                    else if (Model.PPS_Dept == "13")//样品申请
                    {
                        //s_Return = "<a href='Pb_Products_SampleAsk_Add.aspx?ID=" + s_ID + "&Type=0'>样品领用申请</a>";

                        s_Return += "<a href='Pb_Products_Sample_Add.aspx?ID=" + s_ID + "&IsModify=1'>设计修改</a>";

                    }
                    else if (Model.PPS_Dept == "106")//样品出库申请
                    {

                        if (AM.KNet_StaffDepart == "129652784446995911")
                        {
                            s_Return = "<a href='Pb_Products_Sample_Approval.aspx?ID=" + s_ID + "&Type=0'>确认</a><br>等待 <font color=red>质量部</font> 审批";
                        }

                    }
                }

            }

        }
        catch
        {

        }
        return s_Return;
    }
    public string getDemo(string s_ID)
    {
        string s_Return = "";
        try
        {
            KNet.BLL.KNet_Sys_Products BLL = new KNet.BLL.KNet_Sys_Products();
            DataSet dts = BLL.GetList(" KSP_SampleId='" + s_ID + "'");
            if (dts.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dts.Tables[0].Rows.Count; i++)
                {
                    s_Return = "<a href=../Products/KnetProductsSetting_Details.aspx?BarCode=" + dts.Tables[0].Rows[i]["ProductsBarCode"].ToString() + " target=\"_blank\" >" + dts.Tables[0].Rows[i]["ProductsEdition"].ToString() + "</a><br>";
                }
                s_Return += "<a target=\"_blank\" href=../Products/SelectProduct.aspx?KSP_SampleId=" + s_ID + " >选择</a>";

            }
            else
            {
                //s_Return = "<a href=../Products/KnetProductsSetting_Add.aspx?KSP_SampleId=" + s_ID + " >添加</a>";
                s_Return += "<a target=\"_blank\" href=../Products/SelectProduct.aspx?KSP_SampleId=" + s_ID + " >选择</a>";

            }
        }
        catch (Exception ex)
        {

        }
        return s_Return;
    }
    public string getRequst(string s_ID)
    {
        string s_Return = "";
        try
        {
            KNet.BLL.Pb_Products_SampleAsk BLL = new KNet.BLL.Pb_Products_SampleAsk();
            DataSet dts = BLL.GetList(" PPA_SampleID='" + s_ID + "'");
            if (dts.Tables[0].Rows.Count > 0)
            {
                s_Return = "<a href=Pb_Products_Sample_Print.aspx?ID=" + dts.Tables[0].Rows[0]["PPA_ID"].ToString() + " target=\"_blank\" >查看</a>";

            }
            else
            {
                s_Return = "--";
            }
        }
        catch (Exception ex)
        {

        }
        return s_Return;
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

    /// <summary>
    /// 添加提示
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_DataRowBinding(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string s_PPS_ID = this.MyGridView1.DataKeys[e.Row.RowIndex].Value.ToString(); //获取ID值
            KNet.BLL.Pb_Products_Sample Bll = new KNet.BLL.Pb_Products_Sample();
            KNet.Model.Pb_Products_Sample Model = Bll.GetModel(s_PPS_ID);

            CheckBox cb = (CheckBox)e.Row.Cells[1].FindControl("Chbk");
            if (Model.PPS_Dept != "0")
            {
                cb.Enabled = false;
                e.Row.Cells[13].Text = "<font color=red>不可修改</font>";
            }
            else
            {
                cb.Enabled = true;
            }
        }
    }
}
