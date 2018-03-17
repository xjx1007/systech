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

/// <summary>
/// 销售管理-----发货单 管理
/// </summary>
public partial class Knet_Sales_Ship_Manage_Manage : BasePage
{
    public string s_DivStyle = "";
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("发货通知列表") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            //删除合同评审
            if (AM.YNAuthority("删除发货通知") == false)
            {
                this.Btn_Del.Enabled = false;
            }
            string s_ContractNo = Request.QueryString["ContractNo"] == null ? "" : Request.QueryString["ContractNo"].ToString();
           // this.Tbx_ContractNo.Text = s_ContractNo;
            this.Btn_Del.Attributes.Add("onclick", "return confirm('你确信要删除所选记录吗?！\\n\\n注意：该删除会同时删除发货单产品明细记录.')");
            base.Base_DropBatchBind(this.Ddl_Batch, "KNet_Sales_OutWareList", "DutyPerson");
            base.Base_DropBindSearch(this.bas_searchfield, "KNet_Sales_OutWareList");
            base.Base_DropBindSearch(this.Fields, "KNet_Sales_OutWareList");
            if (AM.KNet_StaffDepart == "129652783822281241")//如果是市场销售部
            {
                if (AM.KNet_IsSale==true)
                {
                    this.Ddl_Batch.SelectedValue = " and DutyPerson='" + AM.KNet_StaffNo + "'";
                }
            }
            this.DataShows();   
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
            string Dostr = "select top 1 ID,FollowNo,OutWareNo,FollowDateTime,FollowStaffNo,FollowText,FollowEnd,KSO_isMessage from KNet_Sales_OutWareList_FlowList where OutWareNo='" + OutWareNo + "' order by FollowDateTime desc";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["FollowEnd"].ToString() == "True")
                {
                    return "<img src=\"../images/takman.gif\" width=\"11\" height=\"14\" border=\"0\" /><a href=\"#\" style=\"line-height: 22px;\" onclick=\"lhgdialog.opendlg('发货单号:<font color=Red>" + OutWareNo + "</font> 跟踪', '../SalesShip/Knet_Sales_Ship_Manage_Talks_List.aspx?OutWareNo=" + OutWareNo + "', 780, 400,false,false);\">" + KNetPage.CutString(dr["FollowText"].ToString().Trim(), 40) + "</a>&nbsp;<font color=red>结束</font>";//&nbsp;<font color=\"gray\">" + base.Base_GetUserName(dr["FollowStaffNo"].ToString()) + "&nbsp;(" + dr["FollowDateTime"].ToString() + ")</font>
                }
                else if (dr["KSO_isMessage"].ToString() == "1")
                {
                    return "<img src=\"../images/takman.gif\" width=\"11\" height=\"14\" border=\"0\" /><a href=\"#\" style=\"line-height: 22px;\" onclick=\"lhgdialog.opendlg('发货单号:<font color=Red>" + OutWareNo + "</font> 跟踪', '../SalesShip/Knet_Sales_Ship_Manage_Talks_List.aspx?OutWareNo=" + OutWareNo + "', 780, 400,false,false);\"><font color=green>已发短信</font></a>&nbsp;<img src=\"../images/45.gif\" width=\"11\" height=\"11\" border=\"0\" /><a href=\"#\" onclick=\"lhgdialog.opendlg('发货单号:<font color=Red>" + OutWareNo + "</font> 跟踪', '../SalesShip/Knet_Sales_Ship_Manage_Talks_Add.aspx?OutWareNo=" + OutWareNo + "', 780, 400,false,false);\">添加</a>";
                }
                else
                {
                    return "<img src=\"../images/takman.gif\" width=\"11\" height=\"14\" border=\"0\" /><a href=\"#\" style=\"line-height: 22px;\" onclick=\"lhgdialog.opendlg('发货单号:<font color=Red>" + OutWareNo + "</font> 跟踪', '../SalesShip/Knet_Sales_Ship_Manage_Talks_List.aspx?OutWareNo=" + OutWareNo + "', 780, 400,false,false);\">" + KNetPage.CutString(dr["FollowText"].ToString().Trim(), 40) + "</a>&nbsp;<img src=\"../images/45.gif\" width=\"11\" height=\"11\" border=\"0\" /><a href=\"#\" onclick=\"lhgdialog.opendlg('发货单号:<font color=Red>" + OutWareNo + "</font> 跟踪', '../SalesShip/Knet_Sales_Ship_Manage_Talks_Add.aspx?OutWareNo=" + OutWareNo + "', 780, 400,false,false);\">添加</a>";
                }
            }
            else
            {
                return "<a href=\"#\" onclick=\"lhgdialog.opendlg('发货单号:<font color=Red>" + OutWareNo + "</font> 跟踪', '../SalesShip/Knet_Sales_Ship_Manage_Talks_Add.aspx?OutWareNo=" + OutWareNo + "', 780, 500,false,false);\">添加</a>";
            }
        }
    }

    public string GetFhState(string s_State,string s_ShipNo)
    {
        string s_Retrun = ""; 
        int i_FH = 0;
        this.BeginQuery("Select * from KNet_Sales_OutWareList_FlowList a join Knet_WareHouse_directOutList b on a.OutWareNo=b.DirectOutNO where b.KWD_ShipNo='" + s_ShipNo + "' and a.KSO_ISFH='101' ");
        this.QueryForDataTable();
        if (Dtb_Result.Rows.Count > 0)
        {
            i_FH = 1;
        }
        string s_FH = "";
        if (i_FH == 0)
        {
            s_FH = "<font Color='Green'>通知发货</font><br>";

        }
        if (s_State == "1")
        {
            s_Retrun = "<font Color='red'>未发货</font>";
        }
        else if (s_State == "0")
        {
            s_Retrun = "<font Color='Green'>正常发货</font>"; 
        }
        else if (s_State == "3")
        {
            s_Retrun = "<font Color='Blue'>多发货</font>";
        }
        else if (s_State == "2")
        {
            s_Retrun = "<font Color='Blue'>部分发货</font>";
        }
        return s_FH+s_Retrun;
    }
    /// <summary>
    /// 返回发货跟踪 最新一条记录（Y）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetDirectOutListfollowup(object OutWareNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select top 1 a.* from KNet_Sales_OutWareList_FlowList a join Knet_WareHouse_DirectOutList b on a.OutWareNo=b.DirectOutNo where b.KWD_ShipNo='" + OutWareNo + "' order by FollowDateTime desc";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["FollowEnd"].ToString() == "True")
                {
                    return "<img src=\"../images/takman.gif\" width=\"11\" height=\"14\" border=\"0\" /><a href=\"#\" style=\"line-height: 22px;\" onclick=\"lhgdialog.opendlg('发货单号:<font color=Red>" + OutWareNo + "</font> 跟踪', '../SalesOut/Knet_Sales_Ship_Manage_Talks_List.aspx?OutWareNo=" + OutWareNo + "', 780, 400,false,false);\">" + KNetPage.CutString(dr["FollowText"].ToString().Trim(), 40) + "</a>&nbsp;<font color=red>结束</font>";//&nbsp;<font color=\"gray\">" + base.Base_GetUserName(dr["FollowStaffNo"].ToString()) + "&nbsp;(" + dr["FollowDateTime"].ToString() + ")</font>
                }
                else
                {
                    return "<img src=\"../images/takman.gif\" width=\"11\" height=\"14\" border=\"0\" /><a href=\"#\" style=\"line-height: 22px;\" onclick=\"lhgdialog.opendlg('发货单号:<font color=Red>" + OutWareNo + "</font> 跟踪', '../SalesOut/Knet_Sales_Ship_Manage_Talks_List.aspx?OutWareNo=" + OutWareNo + "', 780, 400,false,false);\">" + KNetPage.CutString(dr["FollowText"].ToString().Trim(), 40) + "</a>&nbsp;<img src=\"../images/45.gif\" width=\"11\" height=\"11\" border=\"0\" /><a href=\"#\" onclick=\"lhgdialog.opendlg('发货单号:<font color=Red>" + OutWareNo + "</font> 跟踪', '../SalesShip/Knet_Sales_Ship_Manage_Talks_Add.aspx?OutWareNo=" + OutWareNo + "', 780, 400,false,false);\"></a>";
                }
            }
            else
            {
                return "<a href=\"#\" onclick=\"lhgdialog.opendlg('发货单号:<font color=Red>" + OutWareNo + "</font> 跟踪', '../SalesOut/Knet_Sales_Ship_Manage_Talks_Add.aspx?OutWareNo=" + OutWareNo + "', 780, 500,false,false);\"></a>";
            }
        }
    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.KNet_Sales_OutWareList bll = new KNet.BLL.KNet_Sales_OutWareList();

        string SqlWhere = " 1=1 ";

        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
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
        if (this.Ddl_Batch.SelectedValue != "")
        {
            SqlWhere += Base_GetBasicWhere(this.Ddl_Batch.SelectedValue);
        }

        SqlWhere = SqlWhere + " order by ";
        AdminloginMess AM = new AdminloginMess();
        if (AM.KNet_StaffDepart == "129652783822281241")//如果是市场销售部
        {
            if (AM.KNet_StaffName != "陈慧")
            {
                SqlWhere += " OutWareCheckYN,";
            }

        }
        SqlWhere = SqlWhere + " SystemDateTimes desc ";
         
        DataSet ds = bll.GetList(SqlWhere);
       
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "OutWareNo" };
        GridView1.DataBind();
    }


    protected void Ddl_Batch_TextChanged1(object sender, EventArgs e)
    {   
        this.DataShows();
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
    /// 查看 发货单 是否已审核
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected bool GetReceivCheckYNEitxt(string OutWareNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,OutWareCheckYN,OutWareNo from KNet_Sales_OutWareList where OutWareNo='" + OutWareNo + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["OutWareCheckYN"].ToString() == "True")
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
    /// 返回关联合同唯一值
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetContractNo(object OutWareNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,ContractNo,OutWareNo from KNet_Sales_OutWareList where OutWareNo='" + OutWareNo + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["ContractNo"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }


    /// <summary>
    /// 获取单明细数目 （Y）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected int Knet_Procure_OrdersList_Details_Shu(string OutWareNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select count(*) as IDS  from KNet_Sales_OutWareList_Details where OutWareNo='" + OutWareNo + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return int.Parse(dr["IDS"].ToString().Trim().ToString());
            }
            else
            {
                return -1;
            }
        }
    }
    /// <summary>
    /// 返回审核情况（Y）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetBaoPriceCheckYN(object aa)
    {
        AdminloginMess AM = new AdminloginMess();
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,OutWareNo,OutWareCheckYN,DutyPerson,IsNull(OutWareIsReview,0) OutWareIsReview from KNet_Sales_OutWareList where OutWareNo='" + aa + "'";
            this.BeginQuery("Select * from KNet_WareHouse_DirectOutList where KWd_ShipNo='"+aa+"'");
            this.QueryForDataTable();
            string s_IsFh="0";
            DataTable Dtb_Table=Dtb_Result;
            if(Dtb_Table.Rows.Count>0)
            {
                s_IsFh = "1";
            }
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string s_DeptID = base.Base_GetNextDept(aa.ToString(), "102");//下一部门ID
                string s_DutyPerson = dr["DutyPerson"].ToString();
                string s_Review = dr["OutWareIsReview"].ToString();
                if (dr["OutWareCheckYN"].ToString() == "True")
                {
                    if (s_Review == "1")
                    {
                        return "";
                    }
                    else
                    {
                        string s_State = base.Base_ShipIsDirectOut(aa.ToString());
                        return "<a href=\"../SalesOut/Sales_ShipWareOut_Add.aspx?ShipNo=" + aa + "\">" + s_State + "</a>";
                    }
                }
                else
                {
                    if (Knet_Procure_OrdersList_Details_Shu(aa.ToString()) <= 0)
                    {
                        return "<a href=\"Knet_Sales_Ship_Manage_AddDetails.aspx?OutWareNo=" + aa + "\"><img src=\"../images/Nodata.gif\"  border=\"0\"  title=\"未完成的发货单（没有明细记录）\" /></a>";
                    }
                    else
                    {
                        
                        //责任人审批
                        if (s_DutyPerson != "")
                        {
                            this.BeginQuery("select * from KNet_Sales_Flow a join KNet_Resource_Staff b on a.KSF_ShPerson=b.StaffNo Where (KSF_State='1' or KSF_State='3')   and KSF_ContractNo='" + aa.ToString() + "'  and b.StaffNo='" + s_DutyPerson + "' and KSF_Del='0'");
                            this.QueryForDataTable();
                            if ((this.Dtb_Result.Rows.Count <= 0) && (AM.KNet_StaffNo == s_DutyPerson))
                            {
                                string JSD = "Knet_Sales_ShipCheckYN.aspx?OutWareNo=" + aa.ToString() + "";
                                string StrPop = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=600,height=500');\"  title=\"点击进行审核操作\">审核</a><br/>等待 <font color=red>" + base.Base_GetUserName(s_DutyPerson) + "</font> 审核";
                                return StrPop;
                            }
                            else if ((this.Dtb_Result.Rows.Count <= 0) && (AM.KNet_StaffNo != s_DutyPerson))
                            {
                                string JSD = "Knet_Sales_ShipCheckDetail.aspx?OutWareNo=" + aa.ToString() + "";
                                string StrPop = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=600,height=500');\"  title=\"点击进行审核操作\">查看</a>&nbsp;&nbsp;";

                                if (AM.KNet_StaffDepart == "129652784259578018")//物料部
                                {

                                    if (s_IsFh == "0")
                                    {
                                        StrPop += "<a href=\"../SalesOut/Sales_ShipWareOut_Add.aspx?ShipNo=" + aa + "\">发货</a>";
                                    }
                                    else
                                    {
                                        StrPop += "<a href=\"../SalesOut/Sales_ShipWareOut_Add.aspx?ShipNo=" + aa + "\">已发货</a>";
                                    }
                                }
                                StrPop += "<br/>等待 <font color=red>" + base.Base_GetUserName(s_DutyPerson) + "</font> 审核";
                                return StrPop;
                            }
                        }
                        this.BeginQuery("Select Top 1 * from KNet_Sales_Flow Where KFS_Type='1' and KSF_ContractNo='" + aa.ToString() + "' Order by KSF_Date Desc ");
                        this.QueryForDataTable();
                        if (this.Dtb_Result.Rows.Count > 0)
                        {
                            if (this.Dtb_Result.Rows[0]["KFS_NextPerson"].ToString() != "")//如果有指定
                            {
                                if (AM.KNet_StaffNo != this.Dtb_Result.Rows[0]["KFS_NextPerson"].ToString())
                                {

                                    string JSD = "Knet_Sales_ShipCheckDetail.aspx?OutWareNo=" + aa.ToString() + "";
                                    string StrPop = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=600,height=500');\"  title=\"点击进行审核操作\">查看</a>&nbsp;&nbsp;";

                                    if (AM.KNet_StaffDepart == "129652784259578018")//物料部
                                    {
                                        if (s_IsFh == "0")
                                        {
                                            StrPop += "<a href=\"../SalesOut/Sales_ShipWareOut_Add.aspx?ShipNo=" + aa + "\">发货</a>";
                                        }
                                        else
                                        {
                                            StrPop += "<a href=\"../SalesOut/Sales_ShipWareOut_Add.aspx?ShipNo=" + aa + "\">已发货</a>";
                                        }
                                    }
                                    StrPop += "<br/>等待 <font color=red>" + base.Base_GetUserName(this.Dtb_Result.Rows[0]["KFS_NextPerson"].ToString()) + "</font> 审核";
                                    return StrPop;
                                }
                                else
                                {
                                    string JSD = "Knet_Sales_ShipCheckYN.aspx?OutWareNo=" + aa.ToString() + "";
                                    string StrPop = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=600,height=500');\"  title=\"点击进行审核操作\">审核</a>&nbsp;&nbsp;";

                                    if (AM.KNet_StaffDepart == "129652784259578018")//物料部
                                    {
                                        if (s_IsFh == "0")
                                        {
                                            StrPop += "<a href=\"../SalesOut/Sales_ShipWareOut_Add.aspx?ShipNo=" + aa + "\">发货</a>";
                                        }
                                        else
                                        {
                                            StrPop += "<a href=\"../SalesOut/Sales_ShipWareOut_Add.aspx?ShipNo=" + aa + "\">已发货</a>";
                                        }
                                    }
                                    StrPop += "<br/>等待 <font color=red>" + base.Base_GetUserName(this.Dtb_Result.Rows[0]["KFS_NextPerson"].ToString()) + "</font> 审核";
                                    return StrPop;
                                }
                            }
                            else
                            {
                                if ((s_DeptID != "") && (AM.KNet_StaffDepart == s_DeptID))
                                {
                                    string JSD = "Knet_Sales_ShipCheckYN.aspx?OutWareNo=" + aa.ToString() + "";
                                    string StrPop = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=600,height=500');\"  title=\"点击进行审核操作\">审核</a>&nbsp;&nbsp;";

                                    if (AM.KNet_StaffDepart == "129652784259578018")//物料部
                                    {
                                        if (s_IsFh == "0")
                                        {
                                            StrPop += "<a href=\"../SalesOut/Sales_ShipWareOut_Add.aspx?ShipNo=" + aa + "\">发货</a>";
                                        }
                                        else
                                        {
                                            StrPop += "<a href=\"../SalesOut/Sales_ShipWareOut_Add.aspx?ShipNo=" + aa + "\">已发货</a>";
                                        }
                                    }
                                    StrPop += "<br/>等待 <font color=red>" + base.Base_GeDept(s_DeptID) + "</font> 审核";
                                    return StrPop;
                                }
                                else
                                {
                                    string JSD = "Knet_Sales_ShipCheckDetail.aspx?OutWareNo=" + aa.ToString() + "";
                                    string StrPop = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=600,height=500');\"  title=\"点击进行审核操作\">查看</a>&nbsp;&nbsp;";

                                    if (AM.KNet_StaffDepart == "129652784259578018")//物料部
                                    {
                                        if (s_IsFh == "0")
                                        {
                                            StrPop += "<a href=\"../SalesOut/Sales_ShipWareOut_Add.aspx?ShipNo=" + aa + "\">发货</a>";
                                        }
                                        else
                                        {
                                            StrPop += "<a href=\"../SalesOut/Sales_ShipWareOut_Add.aspx?ShipNo=" + aa + "\">已发货</a>";
                                        }
                                    }
                                    StrPop += "<br/>等待 <font color=red>" + base.Base_GeDept(s_DeptID) + "</font> 审核";
                                    return StrPop;
                                }
                            }
                        }
                        else
                        {
                            return "";
                        }
                    }//明细
                }
            }
            else
            {
                return "--";
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
            string s_OutWareNo = GridView1.DataKeys[e.Row.RowIndex].Value.ToString(); //获取ID值
            KNet.BLL.KNet_Sales_OutWareList BLL = new KNet.BLL.KNet_Sales_OutWareList();
            if (s_OutWareNo != "")
            {
                string s_CK = GetCk(s_OutWareNo);
                KNet.Model.KNet_Sales_OutWareList Model = BLL.GetModelB(s_OutWareNo);

                CheckBox cb = (CheckBox)e.Row.Cells[1].FindControl("Chbk");

                if ((Model.OutWareCheckYN == true)||(s_CK!=""))
                {
                    cb.Enabled = false;
                }
                else
                {
                    cb.Enabled = true;
                }
            }
        }
    }

    /// <summary>
    /// 查合同单状态 是否完成
    /// </summary>
    /// <param name="OrderNo"></param>
    protected bool UpdateContractState(string ContractNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dosql = " select  (Sum(ContractAmount)-Sum(ContractReceiving)) as SSum from KNet_Sales_ContractList_Details where ContractNo='" + ContractNo + "'";
            SqlCommand cmd = new SqlCommand(Dosql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (int.Parse(dr["SSum"].ToString().Trim()) > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
    protected void Btn_Query_Click(object sender, EventArgs e)
    {
        
        this.DataShows();
    }
    public string GetCk(string s_OutWareNo)
    {
        string s_Return = "";
        try
        {
            KNet.BLL.KNet_WareHouse_DirectOutList Bll=new KNet.BLL.KNet_WareHouse_DirectOutList();
            DataSet Dts_Table = Bll.GetList(" KWD_ShipNo='" + s_OutWareNo + "'");
            if (Dts_Table.Tables[0].Rows.Count > 0)
            {
                s_Return = DateTime.Parse(Dts_Table.Tables[0].Rows[0]["DirectOutDateTime"].ToString()).ToShortDateString();
            }
        }
        catch (Exception ex)
        {
 
        }
        return s_Return;
    }


    protected void Btn_Del_Click(object sender, ImageClickEventArgs e)
    {
        string sql = "delete from KNet_Sales_OutWareList where"; //删除发货单
        string sql2 = "delete from KNet_Sales_OutWareList_Details where"; //发货 明细
        string sql3 = "";//更新合同状态

        string cal = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)(GridView1.Rows[i].FindControl("Chbk"));
            TextBox Tbx_ContractNo = (TextBox)GridView1.Rows[i].Cells[0].FindControl("ContractNo");
            if (cb.Checked == true)
            {
                cal += " OutWareNo='" + GridView1.DataKeys[i].Value.ToString() + "' or";
                sql3 += " Update KNet_Sales_ContractList set ContractState=1 where ContractNo='" + Tbx_ContractNo.Text + "' ";
                sql3 += " Update Knet_Procure_WareHouseList set isship='1' where WareHouseNo in (Select KSO_WareHouseNo from KNet_Sales_OutWareList where OutWareNo='" + GridView1.DataKeys[i].Value.ToString() + "') ";

                KNet.BLL.KNet_Sales_OutWareList_Details BLL = new KNet.BLL.KNet_Sales_OutWareList_Details();
                DataSet ds = BLL.GetList(" OutWareNo='" + GridView1.DataKeys[i].Value.ToString() + "' ");

                for (int j = 0; j <= ds.Tables[0].Rows.Count - 1; j++)
                {
                    DataRowView mydrv = ds.Tables[0].DefaultView[j];

                    string ID = mydrv["ID"].ToString();
                    string ProductsBarCode = mydrv["ProductsBarCode"].ToString();
                    string ContractNo = GetContractNo(GridView1.DataKeys[i].Value.ToString());
                    try
                    {
                        string DoSqlOrder = " update KNet_Sales_ContractList set ContractState=1 where ContractNo='" + ContractNo + "'";
                        DbHelperSQL.ExecuteSql(DoSqlOrder);
                        BLL.Delete(ID, ContractNo, ProductsBarCode);
                    }
                    catch
                    { }
                }
            }
        }
        if (cal != "")
        {
            sql += cal.Substring(0, cal.Length - 3);
            sql2 += cal.Substring(0, cal.Length - 3);
            DbHelperSQL.ExecuteSql(sql3);
            DbHelperSQL.ExecuteSql(sql);
            DbHelperSQL.ExecuteSql(sql2);

            AdminloginMess LogAM = new AdminloginMess();
            LogAM.Add_Logs("销售管理--->销售发货管理--->发货单删除 操作成功！");

            this.DataShows();
        }
        else
        {
            sql = "";       //不删除
            sql2 = "";       //不删除
            Response.Write("<script language=javascript>alert('您没有选择要删除的记录!');history.back(-1);</script>");
            Response.End();
        }


    }
    protected void lbtn_Del_Click(object sender, EventArgs e)
    {
        string sql = "delete from KNet_Sales_OutWareList where"; //删除发货单
        string sql2 = "delete from KNet_Sales_OutWareList_Details where"; //发货 明细
        string sql3 = "";//更新合同状态
        string cal = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
            TextBox Tbx_ContractNo = (TextBox)GridView1.Rows[i].Cells[0].FindControl("ContractNo");
            if (cb.Checked == true)
            {
                cal += " OutWareNo='" + GridView1.DataKeys[i].Value.ToString() + "' or";
                sql3 += " Update KNet_Sales_ContractList set ContractState=1 where ContractNo='" + Tbx_ContractNo.Text + "' ";
                sql3 += " Update Knet_Procure_WareHouseList set isship='1' where WareHouseNo in (Select KSO_WareHouseNo from KNet_Sales_OutWareList where OutWareNo='" + GridView1.DataKeys[i].Value.ToString() + "') ";

                KNet.BLL.KNet_Sales_OutWareList_Details BLL = new KNet.BLL.KNet_Sales_OutWareList_Details();
                DataSet ds = BLL.GetList(" OutWareNo='" + GridView1.DataKeys[i].Value.ToString() + "' ");

                for (int j = 0; j <= ds.Tables[0].Rows.Count - 1; j++)
                {
                    DataRowView mydrv = ds.Tables[0].DefaultView[j];

                    string ID = mydrv["ID"].ToString();
                    string ProductsBarCode = mydrv["ProductsBarCode"].ToString();
                    string ContractNo = GetContractNo(GridView1.DataKeys[i].Value.ToString());
                    try
                    {
                        string DoSqlOrder = " update KNet_Sales_ContractList set ContractState=1 where ContractNo='" + ContractNo + "'";
                        DbHelperSQL.ExecuteSql(DoSqlOrder);
                        BLL.Delete(ID, ContractNo, ProductsBarCode);
                    }
                    catch
                    { }
                }
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

        DbHelperSQL.ExecuteSql(sql3);
        DbHelperSQL.ExecuteSql(sql);
        DbHelperSQL.ExecuteSql(sql2);

        AdminloginMess LogAM = new AdminloginMess();
        LogAM.Add_Logs("销售管理--->销售发货管理--->发货单删除 操作成功！");

        this.DataShows();

    }
    public string GetYsString(string s_OutWareNo,string s_State)
    {
        string s_Return = "";
        KNet.BLL.KNet_Sales_OutWareList Bll = new KNet.BLL.KNet_Sales_OutWareList();
        KNet.Model.KNet_Sales_OutWareList Model = Bll.GetModelB(s_OutWareNo);

        try{
            if (Model.KSO_Type != "2")
            {
                s_Return = base.Base_GetBasicCodeName("212", s_State, "../Receive/Cw_Accounting_Payment_Add.aspx?OutWareNo=" + s_OutWareNo);
            }
            
        }
        catch
        {}
        return s_Return;
    }
}
