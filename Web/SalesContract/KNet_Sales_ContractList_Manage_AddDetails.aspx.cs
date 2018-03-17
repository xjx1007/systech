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
using System.IO;
using System.Text;

using KNet.DBUtility;
using KNet.Common;

/// <summary>
/// 合同开单
/// </summary>
public partial class Knet_Web_Sales_KNet_Sales_ContractList_Manage_AddDetails : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Buffer = true;
        Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
        Response.Expires = 0;
        Response.CacheControl = "no-cache";

        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("修改合同评审") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            else
            {
                if (Request.QueryString["ContractNo"] != null && Request.QueryString["ContractNo"] != "")
                {

                    this.KNet_ContractToPaymentbind();
                    this.KNet_OrderStaffBranchbind();

                    base.Base_DropKClaaBind(this.ContractDeliveMethods, 5, "", "请选择交货方式");
                    base.Base_DropKClaaBind(this.ContractClass, 6, "", "");
                    base.Base_DropBasicCodeBind(this.Drop_RoutineTransport, "102");
                    base.Base_DropBasicCodeBind(this.Drop_WorryTransport, "103");
                    base.Base_DropBasicCodeBind(this.Drop_Payment, "104");

                    KNet.BLL.KNet_Resource_Staff Bll = new KNet.BLL.KNet_Resource_Staff();
                    DataSet Dts_Table = Bll.GetList(" StaffNo<>'admin' Order By StaffDepart ");
                    this.Ddl_DutyPerson.DataSource = Dts_Table;
                    this.Ddl_DutyPerson.DataTextField = "StaffName";
                    this.Ddl_DutyPerson.DataValueField = "StaffNo";
                    this.Ddl_DutyPerson.DataBind();
                    ListItem item = new ListItem("请选择责任人", ""); //默认值
                    this.Ddl_DutyPerson.Items.Insert(0, item);

                    this.Image1.ImageUrl = "../images/Nopic.jpg";
                    this.Image1Big.Text = "../images/Nopic.jpg";
                    this.GetInfo(Request.QueryString["ContractNo"].ToString().Trim());


                    ViewState["SortOrder"] = "ProductsBarCode";
                    ViewState["OrderDire"] = "Desc";
                    this.DataShows();

                    this.Panel1.Visible = false;


                    this.ImageButton_down.Visible = true;
                    this.ImageButton_up.Visible = false;



                    this.ProductsBarCode.Focus();
                    this.ProductsBarCode.Attributes.Add("onmouseover", "this.select()");

            
                    //手工选取
                    string strUrl = "SelectProducts_Sales.aspx?ContractNo=" + Request.QueryString["ContractNo"].ToString() + "&Sn=" + DateTime.Now.ToFileTimeUtc().ToString() + "&CustomerValue="+CustomerValue.Value+"";
                    this.Button2.Attributes.Add("onclick", "javascript:window.open('" + strUrl + "','','top=100,left=140,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=1000,height=500')");



                    //采购单状态情况
                    if (GetBaoPriceCheckYN(Request.QueryString["ContractNo"].ToString().Trim()) == true)
                    {
                        this.Button3.Enabled = false;
                        this.Button3.Text = "合同已审不可再编辑";

                        this.GridView1.Columns[12].Visible = false;
                        this.DoDinfion.Text = "<font color=\"gray\">合同不可再编辑</font>";
                        this.AddProuPar.Visible = false;
                    }
                    else
                    {
                        this.AddProuPar.Visible = true;
                        this.GridView1.Columns[11].Visible = true;
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
    /// 是否存在  明细数目
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected int Knet_Procure_OrdersList_Details_ShuYN(string ContractNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select count(*) as IDS  from KNet_Sales_ContractList_Details where ContractNo='" + ContractNo + "'";
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
    /// 获取出货 仓库唯一号（Y）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetHouseNo(string ContractNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,ContractNo,HouseNo from KNet_Sales_ContractList where ContractNo='" + ContractNo + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["HouseNo"].ToString();
            }
            else
            {
                return "--";
            }
        }
    }
    /// <summary>
    /// 仓库绑定
    /// </summary> 
    protected void KNet_WareHouseBind(string HouseNoSql)
    {
        //KNet.BLL.KNet_Sys_WareHouse bll = new KNet.BLL.KNet_Sys_WareHouse();
        //DataSet ds = bll.GetList(" HouseYN=1 and (" + HouseNoSql + ") ");

        //this.HouseNo.DataSource = ds;
        //this.HouseNo.DataTextField = "HouseName";
        //this.HouseNo.DataValueField = "HouseNo";
        //this.HouseNo.DataBind();
        //ListItem item = new ListItem("请选择仓库", ""); //默认值
        //this.HouseNo.Items.Insert(0, item);
    }
    /// <summary>
    /// 结算方式  （Y）
    /// </summary> 
    protected void KNet_ContractToPaymentbind()
    {
        KNet.BLL.KNet_Sys_CheckMethod bll = new KNet.BLL.KNet_Sys_CheckMethod();
        DataSet ds = bll.GetAllList();
        this.ContractToPayment.DataSource = ds;
        this.ContractToPayment.DataTextField = "CheckName";
        this.ContractToPayment.DataValueField = "CheckNo";
        this.ContractToPayment.DataBind();
        ListItem item = new ListItem("请选择付款方式", ""); //默认值
        this.ContractToPayment.Items.Insert(0, item);
    }

    /// <summary>
    /// 公司或部门绑定 （Y）
    /// </summary> 
    /// b
    protected void KNet_OrderStaffBranchbind()
    {
        KNet.BLL.KNet_Resource_OrganizationalStructure bll = new KNet.BLL.KNet_Resource_OrganizationalStructure();
        DataSet ds = bll.GetList(" StrucPID='0' ");
        this.ContractStaffBranch.DataSource = ds;
        this.ContractStaffBranch.DataTextField = "StrucName";
        this.ContractStaffBranch.DataValueField = "StrucValue";
        this.ContractStaffBranch.DataBind();

        ListItem item = new ListItem("请选择分部", ""); //默认值
        this.ContractStaffBranch.Items.Insert(0, item);
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from KNet_Resource_OrganizationalStructure where StrucPID='" + this.ContractStaffBranch.SelectedValue + "' ", conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            this.ContractStaffDepart.DataSource = sdr;
            this.ContractStaffDepart.DataTextField = "StrucName";
            this.ContractStaffDepart.DataValueField = "StrucValue";
            this.ContractStaffDepart.DataBind();
            ListItem item3 = new ListItem("请选择部门", ""); //默认值
            this.ContractStaffDepart.Items.Insert(0, item3);
        }

    }

    /// <summary>
    /// 选择采购公司后 （Y）
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void OrderStaffBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string proID = this.ContractStaffBranch.SelectedValue.ToString().Trim();
            using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from KNet_Resource_OrganizationalStructure where StrucPID='" + proID + "' ", conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                this.ContractStaffDepart.DataSource = sdr;
                this.ContractStaffDepart.DataTextField = "StrucName";
                this.ContractStaffDepart.DataValueField = "StrucValue";
                this.ContractStaffDepart.DataBind();
                ListItem item = new ListItem("请选择部门", ""); //默认值
                this.ContractStaffDepart.Items.Insert(0, item);
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
    /// 检查此仓库是否存在 （Y）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected bool GetWareHouseYN(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,HouseNo,HouseName from KNet_Sys_WareHouse where HouseNo='" + aa + "'";
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
        string ContractNo = KNetPage.KHtmlEncode(this.ContractNo.Text.Trim());

        string CustomerValue = KNetPage.KHtmlEncode(this.CustomerValue.Value.Trim());

        AdminloginMess am = new AdminloginMess();
        //string HouseNovalue = this.HouseNo.SelectedValue; //仓库代码


        DateTime ContractDateTime = DateTime.Now;
        DateTime? ContractStarDateTime = DateTime.Parse("1900-10-10");
        DateTime? ContractEndtDateTime = DateTime.Parse("1900-10-10");
        DateTime? ContractToDeliDate = DateTime.Parse("1900-10-10");
        try
        {
            ContractDateTime = DateTime.Parse(this.ContractDateTime.Text.Trim());
        }
        catch { }
        try
        {
            ContractToDeliDate = DateTime.Parse(this.ContractToDeliDate.Text.Trim());
        }
        catch { }
        
        try
        {
            ContractStarDateTime = DateTime.Parse(this.ContractStarDateTime.Text.Trim());
            ContractEndtDateTime = DateTime.Parse(this.ContractEndtDateTime.Text.Trim());
        }
        catch { }

        string ContractOursDelegate = "";
        string ContractSideDelegate = "";


        decimal ContractTranShare = 0;
        string ContractClass = this.ContractClass.SelectedValue;
        string HouseNo = "";




        string ContractToAddress = KNetPage.KHtmlEncode(this.ContractToAddress.Text);
        string ContractDeliveMethods = KNetPage.KHtmlEncode(this.ContractDeliveMethods.SelectedValue);

        string BaoPriceNo = KNetPage.KHtmlEncode(this.BaoPriceNo.Value.Trim());
        string ContractToPayment = this.ContractToPayment.SelectedValue;

        string ContractStaffBranch = KNetPage.KHtmlEncode(this.ContractStaffBranch.SelectedValue);
        string ContractStaffDepart = KNetPage.KHtmlEncode(this.ContractStaffDepart.SelectedValue);

        string ContractCheckStaffNo = am.KNet_StaffNo;
        string ContractRemarks = KNetPage.KHtmlEncode(this.ContractRemarks.Text.Trim());

        KNet.Model.KNet_Sales_ContractList molel = new KNet.Model.KNet_Sales_ContractList();
        molel.ContractNo = ContractNo;
        molel.ContractTopic = "";
        molel.CustomerValue = CustomerValue;
        molel.ContractDateTime = ContractDateTime;
        molel.ContractStarDateTime = ContractStarDateTime;
        molel.ContractEndtDateTime = ContractEndtDateTime;

        molel.ContractOursDelegate = ContractOursDelegate;
        molel.ContractSideDelegate = ContractSideDelegate;
        molel.ContractClass = ContractClass;

        molel.ContractTranShare = ContractTranShare;
        molel.ContractDeliveMethods = ContractDeliveMethods;
        molel.ContractToAddress = ContractToAddress;
        molel.ContractToDeliDate = ContractToDeliDate;

        molel.ContractToPayment = ContractToPayment;
        molel.HouseNo = HouseNo;

        molel.BaoPriceNo = BaoPriceNo;
        molel.ContractStaffBranch = ContractStaffBranch;
        molel.ContractStaffDepart = ContractStaffDepart;
        molel.ContractCheckStaffNo = ContractCheckStaffNo;
        molel.ContractRemarks = ContractRemarks;
        molel.HouseNo = HouseNo;

        molel.ContentPerson = this.Tbx_ContentPerson.Text;
        molel.Telephone = this.Tbx_Telephone.Text;
        molel.Payment = this.Drop_Payment.SelectedValue;

        molel.RoutineTransport = this.Drop_RoutineTransport.SelectedValue;
        molel.WorryTransport = this.Drop_WorryTransport.SelectedValue;

        molel.DeliveryRequire = this.Tbx_DeliveryRequire.Text;
        molel.QualityRequire = this.Tbx_QualityRequire.Text;
        molel.TechnicalRequire = this.Tbx_TechnicalRequire.Text;
        molel.WarrantyPeriod = this.Tbx_WarrantyPeriod.Text;
        molel.ProductPackaging = this.Tbx_ProductPackaging.Text;
        molel.ContractShip = this.Tbx_ContractShip.Text;
        molel.ProductsSmallPicture = this.Image1.ImageUrl;
        molel.ProductsBigPicture = this.Image1Big.Text;
        molel.DutyPerson = this.Ddl_DutyPerson.SelectedValue;
        if (ProductsPic.Checked)
        {
            molel.ProductsPic = 1;
        }
        else
        {
            molel.ProductsPic = 0;
 
        }

        KNet.BLL.KNet_Sales_ContractList BLL = new KNet.BLL.KNet_Sales_ContractList();

        //if (GetWareHouseYN(HouseNo) == false)
        //{
        //    Response.Write("<script>alert('仓库选择出错！');history.back(-1);</script>");
        //    Response.End();
        //}
        try
        {
            if (GetClientListYN(CustomerValue) == true)
            {
                 BLL.Update(molel);

                AdminloginMess LogAM = new AdminloginMess();
                LogAM.Add_Logs("销售管理--->修改销售合同--->重新编辑保存销售合同 操作成功！合同编号：" + ContractNo);

                string s_Text = "合同编号为：" + ContractNo + " 需要您审批,请及时登录系统审批。";
                KNet.BLL.KNet_Resource_Staff BLL_Resource_Staff = new KNet.BLL.KNet_Resource_Staff();
                KNet.Model.KNet_Resource_Staff Model_Resource_Staff = BLL_Resource_Staff.GetModelC(this.Ddl_DutyPerson.SelectedValue);
                string s_Detail=base.Base_SendEmail(Model_Resource_Staff.StaffEmail, s_Text,"您有一个合同评审需要您审核！");

                Response.Write("<script>alert('销售合同 重新编辑保存 " + s_Detail + "   操作成功！');location.href='KNet_Sales_ContractList_Manage_AddDetails.aspx?ContractNo=" + ContractNo + "';</script>");
            }
            else
            {
                Response.Write("<script>alert('客户选择出错！ 添加失败！');history.back(-1);</script>");
                Response.End();
            }
        }
        catch
        {
            Response.Write("<script>alert('销售合同保存失败！');history.back(-1);</script>");
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
    /// 返回报价单主题 （Y）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string Get_Sales_BaoPriceListName(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,BaoPriceNo,BaoPriceTopic from KNet_Sales_BaoPriceList where BaoPriceNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["BaoPriceTopic"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }
    /// <summary>
    /// 获取信息 （Y）
    /// </summary>
    /// <param name="OrderNo"></param>
    protected void GetInfo(string ContractNo)
    {
        KNet.BLL.KNet_Sales_ContractList BLL = new KNet.BLL.KNet_Sales_ContractList();
        KNet.Model.KNet_Sales_ContractList model = BLL.GetModelB(ContractNo);

        this.ContractNo.Text = model.ContractNo;

        this.CustomerValue.Value = model.CustomerValue;
        this.CustomerValueName.Text = GetCustomerName(model.CustomerValue);
        this.ContractToAddress.Text = model.ContractToAddress;
        this.Tbx_ContentPerson.Text = model.ContentPerson;
        this.Drop_Payment.SelectedValue = model.Payment;
        this.Drop_RoutineTransport.SelectedValue = model.RoutineTransport;
        this.Drop_WorryTransport.SelectedValue = model.WorryTransport;
        this.Tbx_Telephone.Text = model.Telephone;
        this.Tbx_DeliveryRequire.Text = model.DeliveryRequire;
        this.Tbx_ProductPackaging.Text = model.ProductPackaging;
        this.Tbx_QualityRequire.Text = model.QualityRequire;
        this.Tbx_WarrantyPeriod.Text = model.WarrantyPeriod;
        this.Tbx_TechnicalRequire.Text = model.TechnicalRequire;
        this.Ddl_DutyPerson.SelectedValue = model.DutyPerson;

        this.Tbx_ContractShip.Text = model.ContractShip;
        if (model.ProductsPic == 1)
        {
            this.ProductsPic.Checked = true;
            this.AddPic.Visible = true;
            this.Image1.ImageUrl = model.ProductsSmallPicture;
            this.Image1Big.Text = model.ProductsBigPicture;
        }
        if ((model.ContractToDeliDate.ToString().Trim() != "1900-10-10 0:00:00") && (model.ContractToDeliDate.ToString().Trim() != ""))
        {
            this.ContractToDeliDate.Text = DateTime.Parse(model.ContractToDeliDate.ToString()).ToShortDateString();
        }
        else
        {
            this.ContractToDeliDate.Text = "";
        }

        this.ContractDateTime.Text = DateTime.Parse(model.ContractDateTime.ToString()).ToShortDateString();

        if (model.ContractStarDateTime.ToString().Trim() != "1900-10-10 0:00:00")
        {
            this.ContractStarDateTime.Text = DateTime.Parse(model.ContractStarDateTime.ToString()).ToShortDateString();
        }
        else
        {
            this.ContractStarDateTime.Text = "";
        }

        if (model.ContractEndtDateTime.ToString().Trim() != "1900-10-10 0:00:00")
        {
            this.ContractEndtDateTime.Text = DateTime.Parse(model.ContractEndtDateTime.ToString()).ToShortDateString();
        }
        else
        {
            this.ContractEndtDateTime.Text = "";
        }

        try
        {
            this.ContractClass.SelectedValue = model.ContractClass;
        }
        catch { }


        this.ContractToAddress.Text = model.ContractToAddress;


        this.ContractDeliveMethods.SelectedValue = model.ContractDeliveMethods;
        this.BaoPriceNo.Value = model.BaoPriceNo;
        this.BaoPriceNoName.Text = Get_Sales_BaoPriceListName(model.BaoPriceNo);


        try
        {
            this.ContractToPayment.SelectedValue = model.ContractToPayment;
        }
        catch { }

        try
        {
            this.ContractStaffBranch.SelectedValue = model.ContractStaffBranch;
        }
        catch { }

        try
        {
            using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from KNet_Resource_OrganizationalStructure where StrucPID='" + model.ContractStaffBranch + "' ", conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                this.ContractStaffDepart.DataSource = sdr;
                this.ContractStaffDepart.DataTextField = "StrucName";
                this.ContractStaffDepart.DataValueField = "StrucValue";
                this.ContractStaffDepart.DataBind();
                ListItem item3 = new ListItem("请选择部门", ""); //默认值
                this.ContractStaffDepart.Items.Insert(0, item3);
            }
            this.ContractStaffDepart.SelectedValue = model.ContractStaffDepart;
        }
        catch { }



        this.ContractRemarks.Text = KNetPage.KHtmlDiscode(model.ContractRemarks);
    }


    /// <summary>
    /// 向上UP起来（Y）
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImageButton_up_Click(object sender, ImageClickEventArgs e)
    {

        this.Panel1.Visible = false;
        
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
        this.Panel1.Visible = true;
        

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
    protected void AddToKNet_Sales_BaoPriceList_Details(string ContractNo, string ProductsName, string ProductsBarCode, string ProductsPattern, string ProductsUnits, int ContractAmount, decimal ContractUnitPrice, decimal ContractDiscount, decimal ContractTotalNet, decimal Contract_SalesUnitPrice, decimal Contract_SalesDiscount, decimal Contract_SalesTotalNet, string ContractRemarks, string OwnallPID)
    {
        KNet.BLL.KNet_Sales_ContractList_Details BLL = new KNet.BLL.KNet_Sales_ContractList_Details();
        KNet.Model.KNet_Sales_ContractList_Details model = new KNet.Model.KNet_Sales_ContractList_Details();

        model.ContractNo = ContractNo;
        model.ProductsName = ProductsName;
        model.ProductsBarCode = ProductsBarCode;
        model.ProductsPattern = ProductsPattern;
        model.ProductsUnits = ProductsUnits;

        model.ContractAmount = ContractAmount;

        //成本区
        model.ContractUnitPrice = ContractUnitPrice;
        model.ContractDiscount = ContractDiscount;
        model.ContractTotalNet = ContractTotalNet;
        
        //销售区
        model.Contract_SalesUnitPrice = Contract_SalesUnitPrice;
        model.Contract_SalesDiscount = Contract_SalesDiscount;
        model.Contract_SalesTotalNet = Contract_SalesTotalNet;

        model.ContractRemarks = ContractRemarks;
        model.OwnallPID = OwnallPID;
        try
        {
            if (BLL.Exists(ContractNo, ProductsBarCode, OwnallPID) == false)
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

    /// <summary>
    /// 出库后更新仓库总账信息
    /// </summary>
    /// <param name="thisWareHouseAmount"></param>
    /// <param name="thisWareHouseTotalNet"></param>
    /// <param name="thisWareHouseDiscount"></param>
    /// <param name="HouseNo"></param>
    /// <param name="ProductsBarCode"></param>
    protected void UpdateKNet_WareHouse_Ownall(int thisWareHouseAmount, decimal thisWareHouseTotalNet, decimal thisWareHouseDiscount, string HouseNo, string ProductsBarCode,string ID)
    {
        try
        {
            string Dosql = "update KNet_WareHouse_Ownall set ShippedQuantity=ShippedQuantity+" + thisWareHouseAmount + ",WareHouseAmount=WareHouseAmount-" + thisWareHouseAmount + ",WareHouseTotalNet=WareHouseTotalNet-" + thisWareHouseTotalNet + ",WareHouseDiscount=WareHouseDiscount-" + thisWareHouseDiscount + " where  HouseNo='" + HouseNo + "' and  ProductsBarCode='" + ProductsBarCode + "'  and  [ID]='" + ID + "'";
            DbHelperSQL.ExecuteSql(Dosql);
        }
        catch { }
    }


    /// <summary>
    /// 明细产品绑定
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.KNet_Sales_ContractList_Details bll = new KNet.BLL.KNet_Sales_ContractList_Details();
        string SqlWhere = " 1=1 ";

        if (Request.QueryString["ContractNo"] != null && Request.QueryString["ContractNo"] != "")
        {
            string ContractNo = Request.QueryString["ContractNo"].ToString().Trim();
            SqlWhere = SqlWhere + " and  ContractNo = '" + ContractNo + "' ";
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

                OrderDiscountAll = OrderDiscountAll + decimal.Parse(mydrv["Contract_SalesDiscount"].ToString());
                OrderTotalNetAll = OrderTotalNetAll + decimal.Parse(mydrv["Contract_SalesTotalNet"].ToString());
                OrderAmountALL = OrderAmountALL + int.Parse(mydrv["ContractAmount"].ToString());


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

       // string HouseNo = this.HouseNo.SelectedValue.Trim(); //仓库
       // string ProductsBarCode = KNetPage.KHtmlEncode(GridView1.Rows[e.RowIndex].Cells[2].Text); //产品条形码


        KNet.BLL.KNet_Sales_ContractList_Details bll = new KNet.BLL.KNet_Sales_ContractList_Details();
        
        string ID = GridView1.DataKeys[e.RowIndex].Value.ToString();

        KNet.Model.KNet_Sales_ContractList_Details molels = bll.GetModel(ID);


        try
        {
          //  Response.Write(ID);
           // Response.Write("<br>");

          //  Response.End();

            bll.Delete(ID);


            AMlog.Add_Logs("销售管理-->合同产品明细记录删除成功！");
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

        KNet.BLL.KNet_Sales_ContractList_Details bll = new KNet.BLL.KNet_Sales_ContractList_Details();
        KNet.Model.KNet_Sales_ContractList_Details model = new KNet.Model.KNet_Sales_ContractList_Details();

        string ID = GridView1.DataKeys[e.RowIndex].Value.ToString().Trim();

        //数量
        int ContractAmount = int.Parse(KNetPage.KHtmlEncode(((TextBox)GridView1.Rows[e.RowIndex].Cells[5].FindControl("Orsdnttxtsgsdg")).Text.ToString()));
        
        //数量
        int KSC_BNumber = int.Parse(KNetPage.KHtmlEncode(((TextBox)GridView1.Rows[e.RowIndex].Cells[5].FindControl("BNumber")).Text.ToString()));
        
        //单价
        decimal Contract_SalesUnitPrice = decimal.Parse(KNetPage.KHtmlEncode(((TextBox)GridView1.Rows[e.RowIndex].Cells[6].FindControl("OrderUnitPricetxt")).Text.ToString()));
        
        //金额调节
        decimal Contract_SalesDiscount = 0;


        string ContractRemarks = KNetPage.KHtmlEncode(((TextBox)GridView1.Rows[e.RowIndex].Cells[11].Controls[0]).Text.ToString().Trim());



        model.ID = ID;

        model.Contract_SalesDiscount = Contract_SalesDiscount;
        model.Contract_SalesUnitPrice = Contract_SalesUnitPrice;

        model.Contract_SalesTotalNet = (ContractAmount * Contract_SalesUnitPrice);

        model.ContractRemarks = ContractRemarks;
        model.ContractAmount = ContractAmount;
        model.KSC_BNumber = KSC_BNumber;

        //Response.Write(ContractAmount);
        //Response.Write("<BR>");
        //Response.Write(Contract_SalesUnitPrice);
        //Response.Write("<BR>");
        //Response.Write((ContractAmount * Contract_SalesUnitPrice) + Contract_SalesDiscount);
        //Response.Write("<BR>");
        //Response.End();

        try
        {
            bll.Update(model);
            AMlog.Add_Logs("销售管理-->销售合同明细修改成功！合同编号:" + Request.QueryString["ContractNo"]);
            
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
    protected bool GetBaoPriceCheckYN(string ContractNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,ContractNo,ContractCheckYN from KNet_Sales_ContractList where ContractNo='" + ContractNo + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["ContractCheckYN"].ToString() == "True")
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
    /// 打开上传图片
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ProductsPic_CheckedChanged(object sender, EventArgs e)
    {
        if (this.ProductsPic.Checked == true)
        {
            this.AddPic.Visible = true;
        }
        else
        {
            this.AddPic.Visible = false;
        }
    }


    #region 图片上传操作
    /// <summary>
    /// 上传图片
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void button_ServerClick(object sender, EventArgs e)
    {
        if (!(uploadFile.PostedFile.ContentLength > 0))
        {
            Alert("您没有选择文件!");
        }
        else
        {
            string FileType = uploadFile.PostedFile.ContentType.ToString(); //文件类型
            if (FileType == "image/gif" || FileType == "image/pjpeg")
            {
                GetThumbnailImage();
            }
            else
            {
                Response.Write("<script language=javascript>alert('文件类型服务器不接受！类型:" + FileType + " ');history.back(-1);</script>");
                Response.End();
            }
        }
    }

    /// <summary>
    /// 图片上传
    /// </summary>
    protected void GetThumbnailImage()
    {
        string UploadPath = "../UpLoadPic/Contract/";  //上传路径

        string AutoPath = System.DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "");
        string fileExt = Path.GetExtension(uploadFile.PostedFile.FileName); //获扩展名
        string FileType = uploadFile.PostedFile.ContentType.ToString(); //文件类型

        string filePath = UploadPath + AutoPath + fileExt; //大文件名
        string filePathsmall = UploadPath + AutoPath + "_small" + fileExt; //小文件名

        string newfile = filePath + ".jpg"; //略图文件名

        if (FileType == "image/gif" || FileType == "image/pjpeg")
        {
            uploadFile.PostedFile.SaveAs(Server.MapPath(filePath)); //上传

            Up_Loadcs UL = new Up_Loadcs();

            UL.MakeZoomImage(Server.MapPath("../UpLoadPic/Contract/") + AutoPath + fileExt, Server.MapPath("~/Web/UpLoadPic/Contract/") + AutoPath + "_small" + fileExt, 95, 75, "HW");

            this.Image1.ImageUrl = "../UpLoadPic/Contract/" + AutoPath + "_small" + fileExt;
            this.Image1Big.Text = filePath;
        }
        else
        {
            Response.Write("<script language=javascript>alert('文件类型服务器不接受！类型:" + FileType + " ');history.back(-1);</script>");
            Response.End();
        }
    }

    #endregion
}
