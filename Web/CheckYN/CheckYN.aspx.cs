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

public partial class Knet_CheckYN : BasePage
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
                string s_FlowState = Request.QueryString["FlowState"] == null ? "" : Request.QueryString["FlowState"].ToString();
                string s_FlowType = Request.QueryString["FlowType"] == null ? "" : Request.QueryString["FlowType"].ToString();
               
                this.Tbx_State.Text = s_FlowState;
                this.Tbx_Type.Text = s_FlowType;
                
                KNet.BLL.KNet_Sales_Flow Bll = new KNet.BLL.KNet_Sales_Flow();
                KNet.Model.KNet_Sales_Flow Model = new KNet.Model.KNet_Sales_Flow();
              //  GridView1.DataSource = Bll.GetList(" KSF_ContractNo='" + this.Tbx_ID.Text + "' and KFS_Type='0'  Order  by KSF_Date desc");
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

    private void DataShow()
    {
        if (Request.QueryString["ID"] != null && Request.QueryString["ID"].ToString() != "")
        {
            KNet.BLL.Xs_Contract_Manage bll = new KNet.BLL.Xs_Contract_Manage();
            KNet.Model.Xs_Contract_Manage Model = bll.GetModel(Request.QueryString["ID"].ToString());
            //this.ContractNo.Text = "<a href=\"#\"  onclick=\"javascript:window.open('Xs_Contract_Manage_View.aspx?ID=" + Model.XCM_ID + "&PrinterModel=128898695453437500','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');\">" + Model.XCM_Code + "</a>";
            //this.ContractDateTime.Text = DateTime.Parse(Model.XCM_STime.ToString()).ToShortDateString();
            //this.CustomerName.Text = base.Base_GetCustomerName(Model.XCM_CustomerValue);
            //this.Lbl_DutyPerson.Text = base.Base_GetUserName(Model.XCM_DutyPerson);
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
            string s_Title = "", s_Table = "Xs_Sales_Freight", s_Head = "XSF";
            string s_Receive = "", s_Text = "", s_StaffNo = "";
            string s_ContractCode = "";
            string s_Flow = "";
            string s_FlowState = "";
            string s_Alert = "", s_DutyPerson = "";
            if (this.Tbx_Type.Text == "6")
            {
                KNet.BLL.Xs_Sales_Freight BLL = new KNet.BLL.Xs_Sales_Freight();
                KNet.Model.Xs_Sales_Freight Model = BLL.GetModel(this.Tbx_ID.Text);
                s_Table = "Xs_Sales_Freight";
                s_Head = "XSF";
                s_Text = KNetPage.KHtmlEncode("有 运费承担 <a href='Web/Freight/Xs_Sales_Freight_View.aspx?ID=" + Model.XSF_ID + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " +Model.XSF_Code + "</a> 需要您作为负责人选择审批流程，敬请关注！");
                s_Flow = Model.XSF_Flow;
                s_DutyPerson = Model.XSF_Creator;
                s_Title = "运费承担";
                s_ContractCode = Model.XSF_Code;
            }
            int AA = int.Parse(this.DropDownList1.SelectedValue);
            string s_ID = this.Tbx_ID.Text.Trim();
            string OrderCheckStaffNo = AM.KNet_StaffNo;

            if (AA != -1)
            {
                if ((AA == 1) || (AA == 3))//通过审核
                {

                    s_FlowState = this.Tbx_State.Text;
                    //无下部门
                    if (s_FlowState == "0")
                    {
                        string DoSql = "update " + s_Table + "  set " + s_Head + "_CheckYN=" + AA + "   where  " + s_Head + "_ID='" + s_ID + "' ";
                        DbHelperSQL.ExecuteSql(DoSql);
                        base.Base_SendMessage(s_DutyPerson, "您申请的" + s_Title + "<a href='Web/Freight/Xs_Sales_Freight_View.aspx?ID=" + s_ID + "'  target=\"_blank\">" + s_ContractCode + "</a> 已通过审核");
                    }
                    if (AddFlow(s_ID, AA) == false)
                    {
                        return;
                    }

                    if (this.Chk_IsShow.Checked)
                    {
                        //下级要审核的Email
                        this.BeginQuery("select * from KNet_Resource_Staff where StaffDepart='" + base.Base_GetNextDept(s_ID, s_Flow) + "' and Position='102' ");
                        this.QueryForDataTable();
                        for (int i = 0; i < this.Dtb_Result.Rows.Count; i++)
                        {
                            s_Receive += Dtb_Result.Rows[0]["StaffEmail"].ToString() + ",";
                            s_StaffNo += Dtb_Result.Rows[0]["StaffNo"].ToString() + ",";
                        }
                        if (s_StaffNo != "")
                        {
                            s_Alert = base.Base_SendMessage(s_StaffNo.Substring(0, s_StaffNo.Length - 1), s_Text);
                        }
                        else
                        {
                           // KNet.BLL.KNet_Resource_Staff BLL_Resource_Staff = new KNet.BLL.KNet_Resource_Staff();
                          //  KNet.Model.KNet_Resource_Staff Model_Resource_Staff = BLL_Resource_Staff.GetModelC(s_DutyPerson);
                        }

                    }
                    AM.Add_Logs("成功.编号：" + s_ContractCode + "");
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
                        if (AddFlow(s_ID, AA) == false)
                        {
                            return;
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


    private bool AddFlow(string s_ContractNo, int i_State)
    {

        AdminloginMess AM = new AdminloginMess();
        //插入审核
        KNet.Model.KNet_Sales_Flow Model = new KNet.Model.KNet_Sales_Flow();
        KNet.BLL.KNet_Sales_Flow Bll = new KNet.BLL.KNet_Sales_Flow();
        Model.KFS_Type = int.Parse(this.Tbx_Type.Text);
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
