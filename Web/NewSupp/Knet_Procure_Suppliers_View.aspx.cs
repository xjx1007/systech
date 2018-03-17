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
using KNet.DBUtility;
using KNet.Common;


public partial class Web_Knet_Procure_Suppliers_View : BasePage
{
    public string s_CustomerValue = "";
    public string s_LinkMan = "";
    public string s_OppID = "";
    public string s_MyTable_Detail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.Lbl_Title.Text = "查看供应商";
            this.Pan_Sp.Visible = false;
            AdminloginMess AM = new AdminloginMess();
            //销售机会列表
            if (AM.CheckLogin(this.Lbl_Title.Text) == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string s_IsChecked = Request.QueryString["IsChecked"] == null ? "" : Request.QueryString["IsChecked"].ToString();

            if (s_ID != "")
            {
                ShowInfo(s_ID);
            }
        }

    }

    protected void Btn_Sh_Click(object sender, EventArgs e)
    {
        this.Pan_Sp.Visible = true;
    }

    private void ShowInfo(string s_ID)
    {
        string s_IsChecked = Request.QueryString["IsChecked"] == null ? "" : Request.QueryString["IsChecked"].ToString();

        try
        {
            KNet.BLL.Knet_Procure_Suppliers BLL = new KNet.BLL.Knet_Procure_Suppliers();
            string SuppNoID = Request.QueryString["ID"].ToString().Trim();
            KNet.Model.Knet_Procure_Suppliers model = BLL.GetModel(SuppNoID);
            this.Tbx_ID.Text = model.SuppNo;
            this.SuppNametxt.Text =model.SuppName;
            this.SuppPeopletxt.Text = model.SuppPeople;
            this.SuppMobiTeltxt.Text = model.SuppMobiTel;
            this.SuppPhonetxt.Text = model.SuppPhone;
            this.SuppFaxtxt.Text = model.SuppFax;
            this.SuppEmailtxt.Text = model.SuppEmail;
            this.Lbl_DutyPerson.Text = base.Base_GetUserName(model.KPS_DutyPerson);
            this.SuppProvincetxt.Text = base.Base_GetCityName(model.SuppProvince) + "&nbsp;&nbsp;" + base.Base_GetCityName(model.SuppCity);

            this.SuppWebtxt.Text = model.SuppWeb;
            this.SuppAddresstxt.Text = model.SuppAddress;
            this.SuppZipCodetxt.Text = model.SuppZipCode;
            this.SuppBankNametxt.Text = model.SuppBankName;
            this.SuppBankAccounttxt.Text = model.SuppBankAccount;
            this.SuppProductstxt.Text = model.SuppProducts;
            this.Remarkstxt.Text = model.Remarks;
            this.Lbl_Level.Text = base.Base_GetBasicCodeName("112", model.KPS_Level);
            this.Lbl_Days.Text = base.Base_GetBasicCodeName("300", model.KPS_Days.ToString());
            KNet.BLL.KNet_Sys_ProcureType bll_Type = new KNet.BLL.KNet_Sys_ProcureType();
            DataSet dts_Table = bll_Type.GetList(" ProcureTypeValue='" + model.KPS_Type + "'");
            if (dts_Table.Tables[0].Rows.Count > 0)
            {
                this.Lbl_Type.Text = dts_Table.Tables[0].Rows[0]["ProcureTypeName"].ToString();
            }
            s_CustomerValue = model.SuppNo;
            this.BeginQuery("Select PBW_Name from PB_Basic_Wl where PBW_Code='" + model.KPS_KDCode + "'");
            string s_Wl = this.QueryForReturn();
            this.Lbl_Wl.Text = s_Wl;
            this.Lbl_Num.Text = model.KPS_ScNumber.ToString();
        }
        catch
        { }
    }

    protected void Btn_SaveOnClick(object sender, EventArgs e)
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
            string OrderCheckStaffNo = AM.KNet_StaffNo;
            string s_SuppNo = this.Tbx_ID.Text;

            KNet.BLL.Knet_Procure_Suppliers BLL = new KNet.BLL.Knet_Procure_Suppliers();
            KNet.Model.Knet_Procure_Suppliers Model = BLL.GetModelB(s_SuppNo);
            string s_SuppName = "";
            try
            {
                s_SuppName =s_SuppName;
            }
            catch { }
            string s_Alert = "";
            if (AA != -1)
            {
                if (AA == 1) //通过审核
                {

                    //总经理审批算通过
                    if ((AM.KNet_StaffDepart == "129652783693249229") && (AM.KNet_Position == "102"))
                    {
                        string DoSql = "update Knet_Procure_Suppliers  set KPS_State=" + AA + "   where  suppNo='" + s_SuppNo + "' ";
                        DbHelperSQL.ExecuteSql(DoSql);
                    }
                    if (AddFlow(s_SuppNo, AA) == false)
                    {
                        return;
                    }

                    string s_Receive = "", s_Text = "", s_StaffNo = "";
                    //责任人

                    s_Text = "合格供应商评审 名称为：" +s_SuppName + " 需要您审批,请及时登录系统审批。";

                    //下级要审核的Email
                    this.BeginQuery("select * from KNet_Resource_Staff where StaffDepart='" + base.Base_GetNextDept(s_SuppNo, "112") + "' and Position='102' ");
                    this.QueryForDataTable();
                    for (int i = 0; i < this.Dtb_Result.Rows.Count; i++)
                    {
                        s_Receive += Dtb_Result.Rows[0]["StaffEmail"].ToString() + ",";
                        s_StaffNo += Dtb_Result.Rows[0]["StaffNo"].ToString() + ",";
                    }
                    if (s_Receive != "")
                    {
                        base.Base_SendMessage(s_StaffNo, KNetPage.KHtmlEncode("有 合格供应商评审 <a href='Web/NewSupp/Knet_Procure_Suppliers_View.aspx?ID=" + s_SuppNo + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " +s_SuppName + "</a> 需要您作为负责人选择审批流程，敬请关注！"));
                    }
                    else
                    {
                        KNet.BLL.KNet_Resource_Staff BLL_Resource_Staff = new KNet.BLL.KNet_Resource_Staff();
                        KNet.Model.KNet_Resource_Staff Model_Resource_Staff = BLL_Resource_Staff.GetModelC(Model.KPS_DutyPerson);
                        if (Model_Resource_Staff.StaffEmail != "")
                        {
                            string s_Detail = "您的合格供应商评审已经通过审核！名称：" +s_SuppName + " 审核意见为：" + Tbx_Remark.Text;
                            base.Base_SendMessage(s_StaffNo, KNetPage.KHtmlEncode(s_Detail));
                        }
                    }

                    AM.Add_Logs("合格供应商评审成功.合格供应商评审 名称：" +s_SuppName + "");
                    string s_Return = "<script>alert('审核成功，点 确定 返回！');";
                    s_Return += "window.opener.location.href = \"Web/NewSupp/Knet_Procure_Suppliers_View.aspx?ID=" + s_SuppNo + "\";</script>";
                    Response.Write(s_Return);
                    Response.End();
                }
                else
                {
                    if (AddFlow(s_SuppNo, AA) == false)
                    {
                        return;
                    }
                    KNet.BLL.KNet_Resource_Staff BLL_Resource_Staff = new KNet.BLL.KNet_Resource_Staff();
                    KNet.Model.KNet_Resource_Staff Model_Resource_Staff = BLL_Resource_Staff.GetModelC(Model.KPS_DutyPerson);
                    if (Model_Resource_Staff.StaffEmail != "")
                    {
                        string s_Detail = "您的合格供应商评审未通过！名称：" +s_SuppName + " 审核意见为：" + Tbx_Remark.Text;
                        s_Alert = base.Base_SendEmail(Model_Resource_Staff.StaffEmail, s_Detail, "合格供应商评审审核！") + base.Base_SendMessage(Model_Resource_Staff.StaffNo, KNetPage.KHtmlEncode("有 合格供应商评审未通过 <a href='Web/NewSupp/Knet_Procure_Suppliers_View.aspx?ID=" + s_SuppNo + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " +s_SuppName + "</a> ，敬请关注！")); ;

                    }
                }

                string s_Return1 = "<script>alert('没通过审核，" + s_Alert + "，点 确定 返回！')";
                s_Return1 += "window.opener.location.href = \"Web/NewSupp/Knet_Procure_Suppliers_View.aspx?ID=" + s_SuppNo + "\";</script>";

                Response.Write(s_Return1);
                Response.End();

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
        Model.KSF_ID = GetMainID();
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
            throw;
            return false;
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        this.Pan_Sp.Visible = false;
    }
}
