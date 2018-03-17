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
using System.Text;
using System.Net.Mail;

using KNet.DBUtility;
using KNet.Common;

/// <summary>
/// 对报价单进行审核
/// </summary>
public partial class Knet_Web_Sales_pop_ContractListCheckYN : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            //"合同档案审核"
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
            if (Request.QueryString["ID"] != null && Request.QueryString["ID"] != "")
            {
                this.Tbx_ID.Text = Request.QueryString["ID"].ToString().Trim();
                this.Tbx_State.Text = Request.QueryString["FlowState"] == null ? "" : Request.QueryString["FlowState"].ToString();
                KNet.BLL.KNet_Sales_Flow Bll = new KNet.BLL.KNet_Sales_Flow();
                KNet.Model.KNet_Sales_Flow Model = new KNet.Model.KNet_Sales_Flow();
                GridView1.DataSource = Bll.GetList(" KSF_ContractNo='" + this.Tbx_ID.Text + "' and KFS_Type='0'  Order  by KSF_Date desc");
                this.GridView1.DataBind();
                DataShow();
            }
            else
            {
                Response.Write("<script>alert('非法参数！');window.close();</script>");
                Response.End();
            }
        }
    }

    /// <summary>
    /// 返回仓库的库存量
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    protected int GetKNet_WareHouse_Ownall(string ID)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,WareHouseAmount  from KNet_WareHouse_Ownall where ID='" + ID + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return int.Parse(dr["WareHouseAmount"].ToString().Trim().ToString());
            }
            else
            {
                return 0;
            }
        }
    }

    private void DataShow()
    {
        if (Request.QueryString["ID"] != null && Request.QueryString["ID"].ToString() != "")
        {
            KNet.BLL.Xs_Contract_Manage bll = new KNet.BLL.Xs_Contract_Manage();
            KNet.Model.Xs_Contract_Manage Model = bll.GetModel(Request.QueryString["ID"].ToString());
            this.ContractNo.Text = "<a href=\"#\"  onclick=\"javascript:window.open('Xs_Contract_Manage_View.aspx?ID=" + Model.XCM_ID + "&PrinterModel=128898695453437500','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');\">" + Model.XCM_Code + "</a>";
            this.ContractDateTime.Text = DateTime.Parse(Model.XCM_STime.ToString()).ToShortDateString();
            this.CustomerName.Text = base.Base_GetCustomerName(Model.XCM_CustomerValue);
            this.Lbl_DutyPerson.Text = base.Base_GetUserName(Model.XCM_DutyPerson);
        }

    }


    /// <summary>
    /// 审核操作
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
        if (AM.CheckLogin() == false)
        {
            Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
            Response.End();
        }
        else
        {
            int AA = int.Parse(this.DropDownList1.SelectedValue);
            string s_ID = this.Tbx_ID.Text.Trim();
            string OrderCheckStaffNo = AM.KNet_StaffNo;

            KNet.BLL.Xs_Contract_Manage BLL = new KNet.BLL.Xs_Contract_Manage();
            KNet.Model.Xs_Contract_Manage Model = BLL.GetModel(s_ID);
            string s_ContractCode = Model.XCM_Code;
            string s_Flow = Model.XCM_Flow;
            string s_FlowState = this.Tbx_State.Text;
            string s_Alert = "";
            if (AA != -1)
            {
                if ((AA == 1) || (AA == 3))//通过审核
                {
                    //无下部门
                    if (s_FlowState == "0")
                    {
                        string DoSql = "update Xs_Contract_Manage  set XCM_CheckYN=" + AA + "   where  XCM_ID='" + s_ID + "' ";
                        DbHelperSQL.ExecuteSql(DoSql);
                    }
                    if (AddFlow(s_ID, AA) == false)
                    {
                        return;
                    }

                    if (this.Chk_IsShow.Checked)
                    {
                        string s_Receive = "", s_Text = "", s_StaffNo = "";
                        //责任人
                        s_Text = "合同编号为：" + s_ContractCode + " 需要您审批,请及时登录系统审批。";

                        //下级要审核的Email
                        this.BeginQuery("select * from KNet_Resource_Staff where StaffDepart='" + base.Base_GetNextDept(s_ID, Model.XCM_Flow) + "' and Position='102' ");
                        this.QueryForDataTable();
                        for (int i = 0; i < this.Dtb_Result.Rows.Count; i++)
                        {
                            s_Receive += Dtb_Result.Rows[0]["StaffEmail"].ToString() + ",";
                            s_StaffNo += Dtb_Result.Rows[0]["StaffNo"].ToString() + ",";
                        }
                        if (s_Receive != "")
                        {
                            s_Alert = base.Base_SendEmail(s_Receive.Substring(0, s_Receive.Length - 1), s_Text, "合同档案审核！") + base.Base_SendMessage(s_StaffNo, KNetPage.KHtmlEncode("有 合同档案 <a href='Web/Contract/Xs_Contract_Manage_View.aspx?ID=" + s_ID + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + s_ContractCode + "</a> 需要您作为负责人选择审批流程，敬请关注！"));

                        }
                        else
                        {
                            KNet.BLL.KNet_Resource_Staff BLL_Resource_Staff = new KNet.BLL.KNet_Resource_Staff();
                            KNet.Model.KNet_Resource_Staff Model_Resource_Staff = BLL_Resource_Staff.GetModelC(Model.XCM_Creator);
                            if (Model_Resource_Staff.StaffEmail != "")
                            {
                                string s_Detail = "您的合同档案已经通过审核！合同编号：" + s_ContractCode + " 审核意见为：" + Tbx_Remark.Text;
                                s_Alert = base.Base_SendEmail(Model_Resource_Staff.StaffEmail, s_Detail, "合同档案审核！") + base.Base_SendMessage(s_StaffNo, KNetPage.KHtmlEncode("有 合同档案 <a href='Web/Contract/Xs_Contract_Manage_View.aspx?ID=" + s_ID + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + s_ContractCode + "</a> 需要您作为负责人选择审批流程，敬请关注！"));
                            }
                        }

                    }
                    AM.Add_Logs("合同档案成功.合同编号：" + s_ContractCode + "");
                    string s_Return = "<script>alert('审核成功，" + s_Alert + "，点 确定 返回！');";
                    if (s_Type == "1")
                    {
                        s_Return += "window.opener.location.href = \"../../../inc/Home.aspx?Type=1\";window.close();</script>";
                    }
                    else
                    {
                        s_Return += "window.opener.location.reload();window.close();</script>";
                    }
                    Response.Write(s_Return);
                    Response.End();
                }
                else
                {
                    if (AA == 2) //合同作废
                    {
                        //总经理审批算通过
                        if (s_FlowState == "0")
                        {
                            string DoSql = "update Xs_Contract_Manage set XCM_CheckYN=" + AA + "  where  XCM_ID='" + s_ID + "' ";
                            DbHelperSQL.ExecuteSql(DoSql);
                        }
                        if (AddFlow(s_ID, AA) == false)
                        {
                            return;
                        }
                        if (this.Chk_IsShow.Checked)
                        {
                            KNet.BLL.KNet_Resource_Staff BLL_Resource_Staff = new KNet.BLL.KNet_Resource_Staff();
                            KNet.Model.KNet_Resource_Staff Model_Resource_Staff = BLL_Resource_Staff.GetModelC(Model.XCM_Creator);
                            if (Model_Resource_Staff.StaffEmail != "")
                            {
                                string s_Detail = "您的合同档案作废！合同编号：" + s_ContractCode + " 审核意见为：" + Tbx_Remark.Text;
                                s_Alert = base.Base_SendEmail(Model_Resource_Staff.StaffEmail, s_Detail, "合同档案审核！") + base.Base_SendMessage(Model_Resource_Staff.StaffNo, KNetPage.KHtmlEncode("有 合同档案作废 <a href='Web/Contract/Xs_Contract_Manage_View.aspx?ID=" + s_ID + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + s_ContractCode + "</a> ，敬请关注！"));

                            }
                        }
                        AM.Add_Logs("合同单作废成功.合同编号：" + s_ContractCode + "");
                        string s_Return = "<script>alert('合同作废成功，" + s_Alert + "，点 确定 返回！')";
                        if (s_Type == "1")
                        {
                            s_Return += "window.opener.location.href = \"../../../inc/Home.aspx?Type=1\";window.close();</script>";
                        }
                        else
                        {
                            s_Return += "window.opener.location.reload();window.close();</script>";
                        }
                        Response.Write(s_Return);
                        Response.End();
                    }
                    else
                    {
                        if (AddFlow(s_ID, AA) == false)
                        {
                            return;
                        }
                        if (this.Chk_IsShow.Checked)
                        {
                            KNet.BLL.KNet_Resource_Staff BLL_Resource_Staff = new KNet.BLL.KNet_Resource_Staff();
                            KNet.Model.KNet_Resource_Staff Model_Resource_Staff = BLL_Resource_Staff.GetModelC(Model.XCM_Creator);
                            if (Model_Resource_Staff.StaffEmail != "")
                            {
                                string s_Detail = "您的合同档案未通过！合同编号：" + s_ContractCode + " 审核意见为：" + Tbx_Remark.Text;
                                s_Alert = base.Base_SendEmail(Model_Resource_Staff.StaffEmail, s_Detail, "合同档案审核！") + base.Base_SendMessage(Model_Resource_Staff.StaffNo, KNetPage.KHtmlEncode("有 合同档案未通过 <a href='Web/Contract/Xs_Contract_Manage_View.aspx?ID=" + s_ID + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + s_ContractCode + "</a> ，敬请关注！")); ;

                            }
                        }

                        string s_Return = "<script>alert('没通过审核，" + s_Alert + "，点 确定 返回！')";
                        if (s_Type == "1")
                        {
                            s_Return += "window.opener.location.href = \"../../../inc/Home.aspx?Type=1\";window.close();</script>";
                        }
                        else
                        {
                            s_Return += "window.opener.location.reload();window.close();</script>";
                        }
                        Response.Write(s_Return);
                        Response.End();

                    }
                }

            }
        }
    }


    private bool AddFlow(string s_ContractNo, int i_State)
    {

        AdminloginMess AM = new AdminloginMess();
        //插入审核
        KNet.Model.KNet_Sales_Flow Model = new KNet.Model.KNet_Sales_Flow();
        KNet.BLL.KNet_Sales_Flow Bll = new KNet.BLL.KNet_Sales_Flow();
        Model.KFS_Type = 0;
        Model.KSF_ContractNo = s_ContractNo;
        Model.KSF_Date = DateTime.Now;
        Model.KSF_Detail = this.Tbx_Remark.Text;
        Model.KSF_ShPerson = AM.KNet_StaffNo;
        Model.KSF_State = i_State;
        try
        {
            if (Bll.Exists(Model) == false)
            {

                Bll.Add(Model);
                return true;
            }
            else
            {
                Alert("您已审核，请不要重复审核！");
                return false;
            }

        }
        catch
        {
            return false;
            throw;
        }
    }


    //流程
    public string GetFlowName(string s_Flow)
    {
        string s_FlowName = "";
        switch (s_Flow)
        {
            case "1":
                s_FlowName = "通过审核!";
                break;
            case "2":
                s_FlowName = "合同作废!";
                break;
            case "3":
                s_FlowName = "异常通过!";
                break;
            case "4":
                s_FlowName = "重新提交!";
                break;
            case "0":
                s_FlowName = "不通过审核！";
                break;
        }
        return s_FlowName;
    }


}
