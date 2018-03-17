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

using KNet.DBUtility;
using KNet.Common;

/// <summary>
/// 发货开单
/// </summary>
public partial class Knet_Web_Sales_Knet_Sales_Ship_Manage_AddDetails : BasePage
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
        Response.Buffer = true;
        Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
        Response.Expires = 0;
        Response.CacheControl = "no-cache";

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

                if (Request.QueryString["OutWareNo"] != null && Request.QueryString["OutWareNo"] != "")
                {
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

                    this.GetInfo(Request.QueryString["OutWareNo"].ToString().Trim());


                    ViewState["SortOrder"] = "ProductsBarCode";
                    ViewState["OrderDire"] = "Desc";
                    this.DataShows();

                    this.Cshow.Visible = false;
                    this.Cshow_1.Visible = false;
                    this.Dshow.Visible = false;
                    this.Eshow.Visible = false;
                    this.Fshow.Visible = false;
                    this.GShow.Visible = false;

                    this.ImageButton_down.Visible = true;
                    this.ImageButton_up.Visible = false;




                    //this.ProductsBarCode.Focus();
                    //this.ProductsBarCode.Attributes.Add("onmouseover", "this.select()");

            
                    //手工选取
                    string strUrl = "../Common/Select_Sales_ContractList_AddDetails.aspx?OutWareNo=" + Request.QueryString["OutWareNo"].ToString() + "&ContractNo=" + GetContractNo(Request.QueryString["OutWareNo"].ToString()) + "&Sn=" + DateTime.Now.ToFileTimeUtc().ToString() + "";
                    if (this.ContractNo.Text != "")
                    {
                        this.Button2.Attributes.Add("onclick", "javascript:window.open('" + strUrl + "','','top=100,left=140,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=850,height=500')");

                    }
                    else
                    {
                        strUrl = "../Common/SelectCKProducts.aspx?OutWareNo=" + Request.QueryString["OutWareNo"].ToString() + "&Sn=" + DateTime.Now.ToFileTimeUtc().ToString() ;
                        this.Button2.Attributes.Add("onclick", "javascript:window.open('" + strUrl + "','','top=100,left=140,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=850,height=500')");

                    }
                   
                    //发货单状态情况
                    if (GetOutWareCheckYN(Request.QueryString["OutWareNo"].ToString().Trim()) == true)
                    {
                        this.Button3.Enabled = false;
                        this.Button3.Text = "发货已审不可再编辑";

                        this.GridView1.Columns[10].Visible = false;
                        this.DoDinfion.Text = "<font color=\"gray\">发货单不可再编辑</font>";
                        this.AddProuPar.Visible = false;
                    }
                    else
                    {
                        this.AddProuPar.Visible = true;
                        this.GridView1.Columns[10].Visible = true;
                        this.DoDinfion.Text = "<font color=\"gray\">点</font> <img src=\"../../images/Eedit.gif\" border=\"0\" /> <font color=\"gray\">可进行明细编辑.</font>";
                    }
                }
                else
                {
                    Response.Write("<script>alert('非法参数，非法请求！');history.back(-1);</script>");
                    Response.End();
                }

            }
        }
    }
    /// <summary>
    /// 获取合同编号 唯一号（Y）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetContractNo(string OutWareNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,ContractNo,OutWareNo from KNet_Sales_OutWareList where OutWareNo='" + OutWareNo + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["ContractNo"].ToString();
            }
            else
            {
                return "--";
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

        ListItem item = new ListItem("请选择分部", ""); //默认值
        this.OutWareStaffBranch.Items.Insert(0, item);

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
    /// 检查此客户是否存在 （Y）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected bool GetClientListYN(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,CustomerValue,CustomerName from KNet_Sales_ClientList where CustomerValue='" + aa + "'";
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
    /// 检查此合同是否存在 （Y）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected bool GetContractListNoYN(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,ContractNo,ContractTopic from KNet_Sales_ContractList where ContractNo='" + aa + "'";
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
    /// 保存重新编辑过后的 采购单 （Y）
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button3_Click(object sender, EventArgs e)
    {
        AdminloginMess am=new AdminloginMess();
        string OutWareNo = KNetPage.KHtmlEncode(this.OutWareNo.Text.Trim());
        string OutWareTopic = KNetPage.KHtmlEncode("");
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
        string OutWareSideContact = KNetPage.KHtmlEncode(this.OutWareSideContact.Text.Trim());
        string ContractToAddress = KNetPage.KHtmlEncode(this.ContractToAddress.Text.Trim());
        string ContractDeliveMethods = KNetPage.KHtmlEncode(this.ContractDeliveMethods.SelectedValue);

        string OutWareStaffBranch = this.OutWareStaffBranch.SelectedValue;
        string OutWareStaffDepart = this.OutWareStaffDepart.SelectedValue;

        string OutWareStaffNo = this.OutWareStaffNotxt.Text.Trim();



        string OutWareCheckStaffNo = "";
        string OutWareRemarks = KNetPage.KHtmlEncode(this.OutWareRemarks.Text.Trim());


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
        molel.DutyPerson = this.Ddl_DutyPerson.SelectedValue;

        molel.OutWareStaffBranch = OutWareStaffBranch;
        molel.OutWareStaffDepart = OutWareStaffDepart;
        molel.OutWareStaffNo = OutWareStaffNo;
        molel.OutWareCheckStaffNo = OutWareCheckStaffNo;
        molel.OutWareRemarks = OutWareRemarks;

        //
        molel.KSO_MDate = DateTime.Now;
        molel.KSO_Mreator = am.KNet_StaffNo;
        molel.KSO_PlanOutWareDateTime = DateTime.Parse(this.PlanOutWareDateTime.Text);
        molel.KSO_TelPhone = this.Phone.Text;


        KNet.BLL.KNet_Sales_OutWareList BLL = new KNet.BLL.KNet_Sales_OutWareList();


        try
        {
            if (GetClientListYN(CustomerValue) == true)
            {
                BLL.Update(molel);

                AdminloginMess LogAM = new AdminloginMess();
                LogAM.Add_Logs("销售管理--->修改销售发货单--->重新编辑保存销售发货单 操作成功！发货单号：" + OutWareNo);
                string s_Text = "";
                string s_Alert = "";
                if (Is_Mail.Checked)
                {
                    s_Text = "发货编号为：" + OutWareNo + " 需要您审批,请及时登录系统审批。";
                    KNet.BLL.KNet_Resource_Staff BLL_Resource_Staff = new KNet.BLL.KNet_Resource_Staff();
                    KNet.Model.KNet_Resource_Staff Model_Resource_Staff = BLL_Resource_Staff.GetModelC(this.Ddl_DutyPerson.SelectedValue);
                    s_Alert = base.Base_SendEmail(Model_Resource_Staff.StaffEmail, s_Text, "发货审核！");
                }
                Response.Write("<script>alert('销售发货单 重新编辑保存   操作成功！" + s_Alert + "');location.href='Knet_Sales_Ship_Manage_AddDetails.aspx?OutWareNo=" + OutWareNo + "';</script>");
            }
            else
            {
                Response.Write("<script>alert('客户选择出错！ 添加失败！');history.back(-1);</script>");
                Response.End();
            }
        }
        catch
        {
            Response.Write("<script>alert('销售发货单保存失败！');history.back(-1);</script>");
            Response.End();
        }
    }
    /// <summary>
    /// 返回客户名称 （Y）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetCustomerName(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,CustomerValue,CustomerName from KNet_Sales_ClientList where CustomerValue='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["CustomerName"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }

    /// <summary>
    /// 获取员工名称 （Y）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetKNet_Resource_StaffName(string aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,StaffNo,StaffName from KNet_Resource_Staff where StaffNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["StaffName"].ToString();
            }
            else
            {
                return "";
            }
        }
    }
    /// <summary>
    /// 获取信息 （Y）
    /// </summary>
    /// <param name="OrderNo"></param>
    protected void GetInfo(string OutWareNo)
    {
        KNet.BLL.KNet_Sales_OutWareList BLL = new KNet.BLL.KNet_Sales_OutWareList();
        KNet.Model.KNet_Sales_OutWareList model = BLL.GetModelB(OutWareNo);

        this.OutWareNo.Text = model.OutWareNo;
        this.ContractNo.Text = model.ContractNo;

        base.Base_DropLinkManBind(this.OutWareSideContact, model.CustomerValue);

        this.Ddl_DutyPerson.SelectedValue = model.DutyPerson;
        if (model.OutWareDateTime.ToString().Trim() != "1900-10-10 0:00:00")
        {
            this.OutWareDateTime.Text = DateTime.Parse(model.OutWareDateTime.ToString()).ToShortDateString();
        }
        else
        {
            this.OutWareDateTime.Text = "";
        }

        this.Phone.Text = model.KSO_TelPhone;
        if (model.KSO_PlanOutWareDateTime.ToString().Trim() != "")
        {
            this.PlanOutWareDateTime.Text = DateTime.Parse(model.KSO_PlanOutWareDateTime.ToString()).ToShortDateString();
        }
        else
        {
            this.PlanOutWareDateTime.Text = "";
        }


        this.CustomerValue.Value = model.CustomerValue;
        this.CustomerValueName.Text = GetCustomerName(model.CustomerValue);
        this.ContractTranShare.Text = model.ContractTranShare.ToString();

        this.OutWareOursContact.Text = model.OutWareOursContact;
        this.OutWareSideContact.Text = model.OutWareSideContact;
        this.ContractToAddress.Text = model.ContractToAddress;

        try
        {
            this.ContractDeliveMethods.SelectedValue = model.ContractDeliveMethods;
        }
        catch { }


        try
        {
            this.OutWareStaffBranch.SelectedValue = model.OutWareStaffBranch;
        }
        catch { }

        try
        {
            using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from KNet_Resource_OrganizationalStructure where StrucPID='" + model.OutWareStaffBranch + "' ", conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                this.OutWareStaffDepart.DataSource = sdr;
                this.OutWareStaffDepart.DataTextField = "StrucName";
                this.OutWareStaffDepart.DataValueField = "StrucValue";
                this.OutWareStaffDepart.DataBind();
                ListItem item3 = new ListItem("请选择部门", ""); //默认值
                this.OutWareStaffDepart.Items.Insert(0, item3);
            }
            this.OutWareStaffDepart.SelectedValue = model.OutWareStaffDepart;
        }
        catch { }


        this.OutWareStaffNo.Text = GetKNet_Resource_StaffName(model.OutWareStaffNo);
        this.OutWareStaffNotxt.Text = model.OutWareStaffNo;

        this.OutWareCheckStaffNo.Text = GetKNet_Resource_StaffName(model.OutWareCheckStaffNo);
        this.OutWareCheckStaffNotxt.Text = model.OutWareCheckStaffNo;

        this.OutWareRemarks.Text = KNetPage.KHtmlDiscode(model.OutWareRemarks);
    }


    /// <summary>
    /// 向上UP起来（Y）
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImageButton_up_Click(object sender, ImageClickEventArgs e)
    {

        this.Cshow.Visible = false;
        this.Cshow_1.Visible = false;
        this.Dshow.Visible = false;
        this.Eshow.Visible = false;
        this.Fshow.Visible = false;
        this.GShow.Visible = false;
        

        this.ImageButton_down.Visible = true;
        this.ImageButton_up.Visible = false;


    }

     /// <summary>
    /// 向下Down展示（Y）
     /// </summary>
     /// <param name="sender"></param>
     /// <param name="e"></param>
    protected void ImageButton_down_Click(object sender, ImageClickEventArgs e)
    {

        this.Cshow.Visible = true;
        this.Cshow_1.Visible = true;
        this.Dshow.Visible = true;
        this.Eshow.Visible = true;
        this.Fshow.Visible = true;
        this.GShow.Visible = true;
        

        this.ImageButton_down.Visible = false;
        this.ImageButton_up.Visible = true;


    }

     /// <summary>
     /// 添加到明细记录 （Y）暂不用到
     /// </summary>
     /// <param name="ContractNo"></param>
     /// <param name="ProductsName"></param>
     /// <param name="ProductsBarCode"></param>
     /// <param name="ProductsPattern"></param>
     /// <param name="ProductsUnits"></param>
     /// <param name="ContractAmount"></param>
     /// <param name="ContractUnitPrice"></param>
     /// <param name="ContractDiscount"></param>
     /// <param name="ContractTotalNet"></param>
     /// <param name="Contract_SalesUnitPrice"></param>
     /// <param name="Contract_SalesDiscount"></param>
     /// <param name="Contract_SalesTotalNet"></param>
     /// <param name="ContractRemarks"></param>
    protected void AddToKNet_Sales_BaoPriceList_Details(string OutWareNo, string ProductsName, string ProductsBarCode, string ProductsPattern, string ProductsUnits, int OutWareAmount, decimal OutWareUnitPrice, decimal OutWareDiscount, decimal OutWareTotalNet, decimal OutWare_SalesUnitPrice, decimal OutWare_SalesDiscount, decimal OutWare_SalesTotalNet, string OutWareRemarks)
    {
        KNet.BLL.KNet_Sales_OutWareList_Details BLL = new KNet.BLL.KNet_Sales_OutWareList_Details();
        KNet.Model.KNet_Sales_OutWareList_Details model = new KNet.Model.KNet_Sales_OutWareList_Details();

        model.OutWareNo = OutWareNo;
        model.ProductsName = ProductsName;
        model.ProductsBarCode = ProductsBarCode;
        model.ProductsPattern = ProductsPattern;
        model.ProductsUnits = ProductsUnits;

        model.OutWareAmount = OutWareAmount;

        //成本区
        model.OutWareUnitPrice = OutWareUnitPrice;
        model.OutWareDiscount = OutWareDiscount;
        model.OutWareTotalNet = OutWareTotalNet;
        
        //销售区
        model.OutWare_SalesUnitPrice = OutWare_SalesUnitPrice;
        model.OutWare_SalesDiscount = OutWare_SalesDiscount;
        model.OutWare_SalesTotalNet = OutWare_SalesTotalNet;

        model.OutWareRemarks = OutWareRemarks;

        try
        {
            if (BLL.Exists(OutWareNo, ProductsBarCode) == false)
            {
                BLL.Add(model);
            }
            else
            {
                BLL.UpdateB(model);
            }
        }
        catch { throw; }
    }
    ///// <summary>
    ///// 条形码查出商品并处理
    ///// </summary>
    ///// <param name="sender"></param>
    ///// <param name="e"></param>
    //protected void txtProduct_SN_TextChanged(object sender, EventArgs e)
    //{

    //    AdminloginMess AM = new AdminloginMess();
    //    if (AM.CheckLogin() == false)
    //    {
    //        Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
    //        Response.End();
    //    }
    //    else
    //    {
    //        string ContractNo = this.ContractNo.Text.Trim(); //关联合同编号
    //        string ProductsBarCode = this.ProductsBarCode.Text.Trim(); //产品条码
    //        string OutWareNo = this.OutWareNo.Text.Trim(); //出货单号

    //        KNet.BLL.KNet_Sales_ContractList_Details BLL = new KNet.BLL.KNet_Sales_ContractList_Details();
    //        KNet.Model.KNet_Sales_ContractList_Details model = BLL.GetModelB(ContractNo, ProductsBarCode);


    //        KNet.BLL.KNet_Sales_OutWareList_Details BLLA = new KNet.BLL.KNet_Sales_OutWareList_Details();
    //        KNet.Model.KNet_Sales_OutWareList_Details ModelA = new KNet.Model.KNet_Sales_OutWareList_Details();


    //        if (model != null && int.Parse(model.ContractAmount.ToString()) >= 1) //存在数量
    //        {
    //            ModelA.OutWareNo = OutWareNo;
    //            ModelA.ProductsName = model.ProductsName;
    //            ModelA.ProductsBarCode = model.ProductsBarCode;
    //            ModelA.ProductsPattern = model.ProductsPattern;
    //            ModelA.ProductsUnits = model.ProductsUnits;

    //            ModelA.OutWareAmount = 1;

    //            ModelA.OutWareUnitPrice =model.ContractUnitPrice;
    //            ModelA.OutWareDiscount = decimal.Parse(model.ContractDiscount.ToString()) / int.Parse(model.ContractAmount.ToString());
    //            ModelA.OutWareTotalNet = decimal.Parse(model.ContractTotalNet.ToString()) / int.Parse(model.ContractAmount.ToString());


    //            ModelA.OutWare_SalesUnitPrice =model.Contract_SalesUnitPrice;
    //            ModelA.OutWare_SalesDiscount = decimal.Parse(model.Contract_SalesDiscount.ToString()) / int.Parse(model.ContractAmount.ToString());
    //            ModelA.OutWare_SalesTotalNet = decimal.Parse(model.Contract_SalesTotalNet.ToString()) / int.Parse(model.ContractAmount.ToString());


    //            ModelA.OutWareRemarks = "";

    //            decimal ContractDiscountx =decimal.Parse(model.ContractDiscount.ToString()) / int.Parse(model.ContractAmount.ToString());
    //            decimal ContractTotalNetx =decimal.Parse(model.ContractTotalNet.ToString()) / int.Parse(model.ContractAmount.ToString());
    //            decimal Contract_SalesDiscountx =decimal.Parse(model.Contract_SalesDiscount.ToString()) / int.Parse(model.ContractAmount.ToString());
    //            decimal Contract_SalesTotalNetx =decimal.Parse(model.Contract_SalesTotalNet.ToString()) / int.Parse(model.ContractAmount.ToString());

    //            if (BLLA.Exists(OutWareNo, ProductsBarCode) == true)
    //            {

    //                BLLA.UpdateB(ModelA);
    //                this.UpdateKNet_WareHouse_Ownall(1,ContractNo, ProductsBarCode);

    //            }
    //            else
    //            {
    //                BLLA.Add(ModelA);
    //                this.UpdateKNet_WareHouse_Ownall(1,ContractNo, ProductsBarCode);

    //            }
    //        }

    //        Response.Redirect("Knet_Sales_Ship_Manage_AddDetails.aspx?OutWareNo=" + OutWareNo + "");
    //    }
    //}

    /// <summary>
    /// 出货后更新合同单上的信息
    /// </summary>
    /// <param name="thisWareHouseAmount"></param>
    /// <param name="thisWareHouseTotalNet"></param>
    /// <param name="thisWareHouseDiscount"></param>
    /// <param name="HouseNo"></param>
    /// <param name="ProductsBarCode"></param>
    protected void UpdateKNet_WareHouse_Ownall(int thisContractAmount,string ContractNo, string ProductsBarCode)
    {
        try
        {
            string Dosql = "update KNet_Sales_ContractList_Details set ContractReceiving=ContractReceiving+" + thisContractAmount + "  where  ContractNo='" + ContractNo + "' and  ProductsBarCode='" + ProductsBarCode + "'";
            DbHelperSQL.ExecuteSql(Dosql);
        }
        catch { }
    }
    /// <summary>
    /// 返回单位名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetUnitsName(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,UnitsNo,UnitsName from KNet_Sys_Units where UnitsNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["UnitsName"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }

    /// <summary>
    /// 明细产品绑定
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.KNet_Sales_OutWareList_Details bll = new KNet.BLL.KNet_Sales_OutWareList_Details();
        string SqlWhere = " 1=1 ";

        if (Request.QueryString["OutWareNo"] != null && Request.QueryString["OutWareNo"] != "")
        {
            string OutWareNo = Request.QueryString["OutWareNo"].ToString().Trim();
            SqlWhere = SqlWhere + " and  OutWareNo = '" + OutWareNo + "' ";
        }
        else
        {
            SqlWhere = SqlWhere + " and 2=1 ";
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

            //计价调节 合计
            decimal OrderDiscountAll = 0;
            //净值合计
            decimal OrderTotalNetAll = 0;
            //数量合计
            int OrderAmountALL = 0;
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                DataRowView mydrv = ds.Tables[0].DefaultView[i];

                OrderDiscountAll = OrderDiscountAll + decimal.Parse(mydrv["OutWare_SalesDiscount"].ToString());
                OrderTotalNetAll = OrderTotalNetAll + decimal.Parse(mydrv["OutWare_SalesTotalNet"].ToString());
                OrderAmountALL = OrderAmountALL + int.Parse(mydrv["OutWareAmount"].ToString());


                this.HeXinQ.Text = "数量合计:<B><font color=blue>" + OrderAmountALL.ToString() + "</font></B>&nbsp;&nbsp;&nbsp;金额合计:<B><font color=blue>" + OrderTotalNetAll.ToString("N") + "</font></B>&nbsp;&nbsp;&nbsp;调价合计:<B><font color=blue>" + OrderDiscountAll.ToString("N") + "</font></B>";
            }
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
    }

    /// <summary>
    /// 执行分页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void AspNetPager1_PageChanged(object src, EventArgs e)
    {
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
            //自动ID号
            int id = (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = id.ToString();
        }
    }
    /// <summary>
    /// 开启编辑
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_Editing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        this.DataShows();
    }

    /// <summary>
    /// 取消编辑
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        this.DataShows();
    }
    /// <summary>
    /// 删除单个记录 返回数据量
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_del(object sender, GridViewDeleteEventArgs e)
    {
        AdminloginMess AMlog = new AdminloginMess();

        string ContractNo = this.ContractNo.Text.Trim(); //合同编号
        string ProductsBarCode = KNetPage.KHtmlEncode(GridView1.Rows[e.RowIndex].Cells[2].Text); //产品条形码


        KNet.BLL.KNet_Sales_OutWareList_Details bll = new KNet.BLL.KNet_Sales_OutWareList_Details();
        string ID = GridView1.DataKeys[e.RowIndex].Value.ToString();

        try
        {
            bll.Delete(ID, ContractNo, ProductsBarCode);
            AMlog.Add_Logs("销售管理-->发货单产品明细记录删除成功！");
        }
        catch
        {
            throw;
        }
        finally
        {
            GridView1.EditIndex = -1;
            this.DataShows();
        }
    }
    /// <summary>
    /// 更新数据记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        AdminloginMess AMlog = new AdminloginMess();

        KNet.BLL.KNet_Sales_OutWareList_Details bll = new KNet.BLL.KNet_Sales_OutWareList_Details();
        KNet.Model.KNet_Sales_OutWareList_Details model = new KNet.Model.KNet_Sales_OutWareList_Details();

        string ID = GridView1.DataKeys[e.RowIndex].Value.ToString().Trim();
        string OutWareRemarks = KNetPage.KHtmlEncode(((TextBox)GridView1.Rows[e.RowIndex].Cells[9].Controls[0]).Text.ToString().Trim());
        
        model.ID = ID;
        model.OutWareRemarks = OutWareRemarks;
        try
        {
            bll.Update(model);

            AMlog.Add_Logs("销售管理-->销售发货产品明细修改成功！发货编号:" + Request.QueryString["OutWareNo"]);
        }
        catch
        {
            throw;
        }
        GridView1.EditIndex = -1;
        this.DataShows();
    }

    /// <summary>
    /// 返回审核情况 （Y）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected bool GetOutWareCheckYN(string OutWareNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,OutWareNo,OutWareCheckYN from KNet_Sales_OutWareList where OutWareNo='" + OutWareNo + "'";
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

    protected void OutWareSideContact_TextChanged(object sender, EventArgs e)
    {
        if (this.OutWareSideContact.SelectedValue != "")
        {
            this.Phone.Text = base.Base_GetLinkManValue(this.OutWareSideContact.SelectedValue, "XOL_Phone");
        }
        else
        {
            this.Phone.Text = "";
        }
    }

}
