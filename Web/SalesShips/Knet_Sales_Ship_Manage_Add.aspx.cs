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


/// <summary>
/// 销售管理-----发货单 管理
/// </summary>
public partial class Knet_Web_Sales_Knet_Sales_Ship_Manage_Add : BasePage
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

            string s_WareHouseNo = Request.QueryString["WareHouseNo"] == null ? "" : Request.QueryString["WareHouseNo"].ToString();
            this.Tbx_WareHouseNo.Text = s_WareHouseNo;
            string s_ContractNo = Request.QueryString["ContractNo"] == null ? "" : Request.QueryString["ContractNo"].ToString();
            if (s_ContractNo != "")
            {
                this.Div_Content.Visible = false;
                this.Div_Customer.Visible = false;
                this.Tbx_ContentPerson.CssClass = "Custom_Hidden";
                this.OutWareSideContact.Visible = true;
                this.ContractNoSelectValue.Value=s_ContractNo;
                if (Knet_Procure_OrdersListYN(s_ContractNo) == true)
                {
                    this.GetInfo(s_ContractNo);
                    this.selectPathen.Visible = false;
                    this.AddPaten.Visible = true;
                }
                else
                {
                    Response.Write("<script language=javascript>alert('您所选择的合同编号出错，未满足发货条件！');history.back(-1);</script>");
                    Response.End();
                }
            }
                this.KNet_OrderStaffBranchbind();
                this.KClaaBind(this.ContractDeliveMethods, 5, "请选择交货方式");
                KNet.BLL.KNet_Resource_Staff Bll = new KNet.BLL.KNet_Resource_Staff();
                DataSet Dts_Table = Bll.GetList(" StaffNo<>'admin' Order By StaffDepart ");
                this.Ddl_DutyPerson.DataSource = Dts_Table;
                this.Ddl_DutyPerson.DataTextField = "StaffName";
                this.Ddl_DutyPerson.DataValueField = "StaffNo";
                this.Ddl_DutyPerson.DataBind();
                ListItem item = new ListItem("请选择责任人", ""); //默认值
                this.Ddl_DutyPerson.Items.Insert(0, item);

                this.OutWareStaffNo.Text = AM.KNet_StaffName;
                this.OutWareStaffNotxt.Text = AM.KNet_StaffNo;
            }
        }
    }

    /// <summary>
    /// 分类(1渠道信息，2客户类型,3客户行业，4客户来源,5交货方式,6合同分类）  （Y）
    /// </summary>
    /// <param name="DDL"></param>
    /// <param name="ClientKings"></param>
    protected void KClaaBind(DropDownList DDL, int ClientKings, string StrText)
    {
        KNet.BLL.KNet_Sales_ClientAppseting bll = new KNet.BLL.KNet_Sales_ClientAppseting();
        DataSet ds = bll.GetList(" ClientKings=" + ClientKings + " order by ClientPai desc ");
        DDL.DataSource = ds;
        DDL.DataTextField = "Client_Name";
        DDL.DataValueField = "ClientValue";
        DDL.DataBind();
        ListItem item = new ListItem(StrText, ""); //默认值
        DDL.Items.Insert(0, item);
    }
    /// <summary>
    /// 是否复合发货条件   合同状态（0未执行，1执行中，2出货中，3作废，4完成）
    /// </summary>
    /// <param name="OrderNo"></param>
    /// <returns></returns>
    protected bool Knet_Procure_OrdersListYN(string ContractNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ContractNo,ID,ContractState,ContractCheckYN from KNet_Sales_ContractList where ContractNo='" + ContractNo + "' and ContractCheckYN=1 and ( ContractState=1 or  ContractState=2 )";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }


    /// <summary>
    /// 公司或部门绑定
    /// </summary> 
    protected void KNet_OrderStaffBranchbind()
    {
        KNet.BLL.KNet_Resource_OrganizationalStructure bll = new KNet.BLL.KNet_Resource_OrganizationalStructure();
        DataSet ds = bll.GetList(" StrucPID='0' ");
        this.OutWareStaffBranch.DataSource = ds;
        this.OutWareStaffBranch.DataTextField = "StrucName";
        this.OutWareStaffBranch.DataValueField = "StrucValue";
        this.OutWareStaffBranch.DataBind();


        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from KNet_Resource_OrganizationalStructure where StrucPID='" + this.OutWareStaffBranch.SelectedValue + "' ", conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            this.OutWareStaffDepart.DataSource = sdr;
            this.OutWareStaffDepart.DataTextField = "StrucName";
            this.OutWareStaffDepart.DataValueField = "StrucValue";
            this.OutWareStaffDepart.DataBind();
            ListItem item3 = new ListItem("请选择部门", ""); //默认值
            this.OutWareStaffDepart.Items.Insert(0, item3);
        }

    }

    /// <summary>
    /// 选择采购公司后
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void OrderStaffBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string proID = this.OutWareStaffBranch.SelectedValue.ToString().Trim();
            using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from KNet_Resource_OrganizationalStructure where StrucPID='" + proID + "' ", conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                this.OutWareStaffDepart.DataSource = sdr;
                this.OutWareStaffDepart.DataTextField = "StrucName";
                this.OutWareStaffDepart.DataValueField = "StrucValue";
                this.OutWareStaffDepart.DataBind();
                ListItem item = new ListItem("请选择部门", ""); //默认值
                this.OutWareStaffDepart.Items.Insert(0, item);
            }
        }
        catch { }
    }

    /// <summary>
    /// 获取客户名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetCustomerName(string aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,CustomerValue,CustomerName from KNet_Sales_ClientList where CustomerValue='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["CustomerName"].ToString();
            }
            else
            {
                return "--";
            }
        }
    }
    /// <summary>
    /// 获取信息
    /// </summary>
    /// <param name="OrderNo"></param>
    protected void GetInfo(string ContractNo)
    {
        AdminloginMess AM=new AdminloginMess();
        KNet.BLL.KNet_Sales_ContractList BLL = new KNet.BLL.KNet_Sales_ContractList();
        KNet.Model.KNet_Sales_ContractList model = BLL.GetModelB(ContractNo);

        this.ContractNo.Text = model.ContractNo;
        this.OutWareDateTime.Text = DateTime.Now.ToShortDateString();

        this.OutWareNo.Text = base.GetNewID("KNet_Sales_OutWareList",0);

        this.CustomerValue.Value = model.CustomerValue;
        this.CustomerValueName.Text = GetCustomerName(model.CustomerValue);
        this.ContractTranShare.Text = model.ContractTranShare.ToString();

        this.ContractToAddress.Text = model.ContractToAddress;

        this.OutWareOursContact.Text = base.Base_GetUserName(AM.KNet_StaffNo);

        base.Base_DropLinkManBind(this.OutWareSideContact, model.CustomerValue);

        //Response.Write(GetKNet_Sales_ContractList_DetailsAmount(model.ContractNo).ToString());

        try
        {
            this.ContractDeliveMethods.SelectedValue = model.ContractDeliveMethods;
        }
        catch { }


        try
        {
            this.OutWareStaffBranch.SelectedValue = model.ContractStaffBranch;
        }
        catch { }

        try
        {
            using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from KNet_Resource_OrganizationalStructure where StrucPID='" + model.ContractStaffBranch + "' ", conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                this.OutWareStaffDepart.DataSource = sdr;
                this.OutWareStaffDepart.DataTextField = "StrucName";
                this.OutWareStaffDepart.DataValueField = "StrucValue";
                this.OutWareStaffDepart.DataBind();
                ListItem item3 = new ListItem("请选择部门", ""); //默认值
                this.OutWareStaffDepart.Items.Insert(0, item3);
            }
            this.OutWareStaffDepart.SelectedValue = model.ContractStaffDepart;
        }
        catch { }



    }


    /// <summary>
    /// 确定开收货单
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button3_Click(object sender, EventArgs e)
    {
        string OutWareNo = base.GetNewID("KNet_Sales_OutWareList", 1);
        string OutWareTopic = "";
        string ContractNo = KNetPage.KHtmlEncode(this.ContractNo.Text.Trim());

        DateTime OutWareDateTime = DateTime.Now;
        try
        {
            OutWareDateTime = DateTime.Parse(this.OutWareDateTime.Text.Trim());
        }
        catch { }

        string CustomerValue = KNetPage.KHtmlEncode(this.CustomerValue.Value.Trim());

        decimal ContractTranShare = decimal.Parse(KNetPage.KHtmlEncode(this.ContractTranShare.Text.Trim()));
        string OutWareOursContact = KNetPage.KHtmlEncode(this.OutWareOursContact.Text.Trim());
        string OutWareSideContact = "";
        if (this.ContractNo.Text != "")
        {
             OutWareSideContact = KNetPage.KHtmlEncode(this.OutWareSideContact.SelectedValue.Trim());
        }
        else
        {
            OutWareSideContact = this.Tbx_ContentPersonID.Text;
        }
        string ContractToAddress = KNetPage.KHtmlEncode(this.ContractToAddress.Text.Trim());
        string ContractDeliveMethods = KNetPage.KHtmlEncode(this.ContractDeliveMethods.SelectedValue);

        string OutWareStaffBranch = this.OutWareStaffBranch.SelectedValue;
        string OutWareStaffDepart = this.OutWareStaffDepart.SelectedValue;

        string OutWareStaffNo = this.OutWareStaffNotxt.Text.Trim();



        string OutWareCheckStaffNo = "";
        string OutWareRemarks = KNetPage.KHtmlEncode(this.OutWareRemarks.Text.Trim());



        KNet.BLL.KNet_Sales_ClientList CBLL = new KNet.BLL.KNet_Sales_ClientList();
        KNet.Model.KNet_Sales_ClientList Cmolel = CBLL.GetModelB(CustomerValue);


        KNet.Model.KNet_Sales_OutWareList molel = new KNet.Model.KNet_Sales_OutWareList();
        molel.OutWareNo = OutWareNo;
        molel.OutWareTopic = OutWareTopic;
        molel.ContractNo = ContractNo;
        molel.OutWareDateTime = OutWareDateTime;

        molel.CustomerValue = CustomerValue;
        molel.ContractTranShare = ContractTranShare;
        molel.OutWareOursContact = OutWareOursContact;
        molel.OutWareSideContact = OutWareSideContact;
        molel.ContractToAddress = ContractToAddress;
        molel.ContractDeliveMethods = ContractDeliveMethods;


        molel.OutWareStaffBranch = OutWareStaffBranch;
        molel.OutWareStaffDepart = OutWareStaffDepart;
        molel.OutWareStaffNo = OutWareStaffNo;
        molel.OutWareCheckStaffNo = OutWareCheckStaffNo;
        molel.OutWareRemarks = OutWareRemarks;
        molel.DutyPerson = this.Ddl_DutyPerson.SelectedValue;

        molel.KSO_TelPhone = this.Phone.Text;
        molel.KSO_PlanOutWareDateTime = DateTime.Parse(this.PlanOutWareDateTime.Text);
        molel.KSO_ContentPersonName = this.Tbx_ContentPerson.Text;
        molel.KSO_WareHouseNo = this.Tbx_WareHouseNo.Text;

        KNet.BLL.KNet_Sales_OutWareList BLL = new KNet.BLL.KNet_Sales_OutWareList();

        try
        {
            if (Cmolel.PlayCycleYN == true)
            {
                if (Cmolel.PlayCycleMoney<(GetLoanAmount(CustomerValue) + GetKNet_Sales_ContractList_DetailsAmount(ContractNo)))
                {
                    Response.Write("<script>alert('此客户为额度客户，其额度已超过额度，不能再发货，请联系其先结账');location.href='Knet_Sales_Ship_Manage_Add.aspx?Css5=Div22';</script>");
                    Response.End();
                }
            }

            if (BLL.Exists(OutWareNo) == false)
            {
                if (this.Tbx_WareHouseNo.Text != "")
                {
                    KNet.BLL.Knet_Procure_WareHouseList BLL_Ware = new KNet.BLL.Knet_Procure_WareHouseList();
                    BLL_Ware.UpdateShip(this.Tbx_WareHouseNo.Text,"2");
                }
                BLL.Add(molel);
                AdminloginMess LogAM = new AdminloginMess();
                LogAM.Add_Logs("销售管理--->销售发货管理--->发货开单 添加 操作成功！发货单号：" + OutWareNo);
                string s_Text = "";
                string s_Alert = "";
                if (Is_Mail.Checked)
                {
                    s_Text = "发货编号为：" + OutWareNo + " 需要您审批,请及时登录系统审批。";
                    KNet.BLL.KNet_Resource_Staff BLL_Resource_Staff = new KNet.BLL.KNet_Resource_Staff();
                    KNet.Model.KNet_Resource_Staff Model_Resource_Staff = BLL_Resource_Staff.GetModelC(this.Ddl_DutyPerson.SelectedValue);
                    s_Alert = base.Base_SendEmail(Model_Resource_Staff.StaffEmail, s_Text, "发货审核！");
                }
                Response.Write("<script>alert('发货开单 添加  操作成功！ 确定进入添加发货单产品明细！" + s_Alert + "');location.href='Knet_Sales_Ship_Manage_AddDetails.aspx?OutWareNo=" + OutWareNo + "&Css2=Div22';</script>");
                Response.End();
            }
            else
            {
                Response.Write("<script>alert('发货单号已存在 添加失败！');history.back(-1);</script>");
                Response.End();
            }

        }
        catch
        {
            throw;
            Response.Write("<script>alert('发货开单添加失败！');history.back(-1);</script>");
            Response.End();
        }
    }


    /// <summary>
    /// 获取用户未结算额度
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected decimal GetLoanAmount(string CustomerValue)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select isnull(sum(LoanAmount),0) as AA from A_Deliveryfa where CustomerValue='" + CustomerValue + "' and  SettlementStatus=1";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return decimal.Parse(dr["AA"].ToString());
            }
            else
            {
                return 0;
            }
        }
    }


    /// <summary>
    /// 获取发货合同单金额
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected decimal GetKNet_Sales_ContractList_DetailsAmount(string ContractNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select isnull(sum(Contract_SalesUnitPrice*ContractAmount),0) as AA from KNet_Sales_ContractList_Details where ContractNo='" + ContractNo + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return decimal.Parse(dr["AA"].ToString());
            }
            else
            {
                return 0;
            }
        }
    }

    protected void OutWareSideContact_TextChanged(object sender, EventArgs e)
    {
        if (this.OutWareSideContact.SelectedValue != "")
        {
            this.Phone.Text = base.Base_GetLinkManValue(this.OutWareSideContact.SelectedValue, "XOL_Phone");
            this.ContractToAddress.Text = base.Base_GetLinkManValue(this.OutWareSideContact.SelectedValue, "XOL_Address");
        }
        else
        {
            this.Phone.Text = "";
            this.ContractToAddress.Text = "";
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        AdminloginMess AM=new AdminloginMess();
        this.OutWareNo.Text = base.GetNewID("KNet_Sales_OutWareList", 0);
        this.selectPathen.Visible = false;
        this.AddPaten.Visible = true;
        this.OutWareOursContact.Text = AM.KNet_StaffName;
        base.Base_DropLinkManBind(this.OutWareSideContact, this.CustomerValue.Value);
        this.OutWareDateTime.Text = DateTime.Now.ToShortDateString();

        this.Div_Content.Visible = true;
        this.Div_Customer.Visible = true;
        this.Tbx_ContentPerson.CssClass = "Boxx";
        this.OutWareSideContact.Visible = false;
        
    }

    /// <summary>
    /// 确定收货
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.Div_Content.Visible = false;
        this.Div_Customer.Visible = false;
        this.Tbx_ContentPerson.CssClass = "Custom_Hidden";
        this.OutWareSideContact.Visible = true;
        
        string ContractNo = this.ContractNoSelectValue.Value;
        if (Knet_Procure_OrdersListYN(ContractNo) == true)
        {
            this.GetInfo(ContractNo);
            this.selectPathen.Visible = false;
            this.AddPaten.Visible = true;
        }
        else
        {
            Response.Write("<script language=javascript>alert('您所选择的合同编号出错，未满足发货条件！');history.back(-1);</script>");
            Response.End();
        }
    }



}
