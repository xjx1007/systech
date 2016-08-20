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

using KNet.DBUtility;
using KNet.Common;

/// <summary>
/// 对报价单进行审核
/// </summary>
public partial class Knet_Web_Sales_pop_ContractListCheckYN : BasePage
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
            if (AM.CheckLogin("合同评审审核") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }

            this.Button1.Attributes.Add("onclick", "return confirm('你确信要重新提交吗?！')");
            if (Request.QueryString["ContractNo"] != null && Request.QueryString["ContractNo"] != "")
            {
                this.UsersNotxt.Text = Request.QueryString["ContractNo"].ToString().Trim();
                KNet.BLL.KNet_Sales_ContractList BLL_Sales_ContractList=new KNet.BLL.KNet_Sales_ContractList();
                KNet.Model.KNet_Sales_ContractList Model_Sales_ContractList = BLL_Sales_ContractList.GetModelB(Request.QueryString["ContractNo"].ToString());
                if (AM.KNet_StaffNo == Model_Sales_ContractList.ContractStaffNo)
                {
                    this.Button1.Enabled = true;
                }
                else
                {
                    this.Button1.Enabled = false;
                }
                KNet.BLL.KNet_Sales_Flow Bll = new KNet.BLL.KNet_Sales_Flow();
                KNet.Model.KNet_Sales_Flow Model = new KNet.Model.KNet_Sales_Flow();
                GridView1.DataSource = Bll.GetList(" KSF_ContractNo='" + this.UsersNotxt.Text + "' and KFS_Type='0'  Order  by KSF_Date desc");
                this.GridView1.DataBind();
                this.DataShow();
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
        if (Request.QueryString["ContractNo"] != null && Request.QueryString["ContractNo"].ToString() != "")
        {
            KNet.BLL.KNet_Sales_ContractList BLL_Sales_ContractList = new KNet.BLL.KNet_Sales_ContractList();
            KNet.Model.KNet_Sales_ContractList Model = BLL_Sales_ContractList.GetModelB(Request.QueryString["ContractNo"].ToString());
            this.ContractNo.Text = Model.ContractNo;
            this.ContractDateTime.Text = DateTime.Parse(Model.ContractDateTime.ToString()).ToShortDateString();
            this.CustomerName.Text = base.Base_GetCustomerName(Model.CustomerValue);
            this.ContractToAddress.Text = Model.ContractToAddress;
            this.ContractDeliveMethods.Text = base.Base_GetKClaaName(Model.ContractDeliveMethods);
            this.Tbx_ContentPerson.Text = Model.ContentPerson;
            this.Tbx_Telephone.Text = Model.Telephone;
            this.ContractStarDateTime.Text = DateTime.Parse(Model.ContractStarDateTime.ToString()).ToShortDateString();
            this.ContractToDeliDate.Text = DateTime.Parse(Model.ContractToDeliDate.ToString()).ToShortDateString();
            this.ContractClass.Text = base.Base_GetKClaaName(Model.ContractClass);
            this.Drop_RoutineTransport.Text = base.Base_GetBasicCodeName(Model.RoutineTransport, "102");
            this.Drop_WorryTransport.Text = base.Base_GetBasicCodeName(Model.WorryTransport, "103");
            this.ContractToPayment.Text = base.Base_GetBasicCodeName(Model.ContractToPayment, "104");
            this.Tbx_TechnicalRequire.Text = Model.TechnicalRequire;
            this.Tbx_ProductPackaging.Text = Model.ProductPackaging;
            this.Tbx_QualityRequire.Text = Model.QualityRequire;
            this.Tbx_WarrantyPeriod.Text = Model.WarrantyPeriod;
            this.Tbx_DeliveryRequire.Text = Model.DeliveryRequire;
            this.ContractRemarks.Text = Model.ContractRemarks;
            this.Lbl_ContractShip.Text = Model.ContractShip;
            this.Lbl_DutyPerson.Text = base.Base_GetUserName(Model.DutyPerson);
            if (Model.ProductsPic == 1)
            {
                this.Image1.Visible = true;
                this.Image1.ImageUrl = Model.ProductsSmallPicture;

                this.HyperLink1.Visible = true;
                this.HyperLink1.NavigateUrl = Model.ProductsBigPicture;

            }
            else
            {
                this.Image1.Visible = false;
                this.HyperLink1.Visible = false;
            }

            //明细
            this.BeginQuery("Select OrderNo,SuppNo From Knet_Procure_OrdersList Where ContractNo='" + this.ContractNo.Text + "'");
            this.QueryForDataTable();
            string s_OrderNo = "", s_SuppNo = "";
            if (this.Dtb_Result.Rows.Count > 0)
            {
                s_OrderNo = this.Dtb_Result.Rows[0][0].ToString();
                s_SuppNo = this.Dtb_Result.Rows[0][1].ToString();
            }
            this.Lbl_Supplier.Text = base.Base_GetSupplierName(s_SuppNo);

            this.OrderNo.Text = "<a href=\"#\"  onclick=\"javascript:window.open('../Procure/Knet_Procure_OpenBilling_PrinterListSettingPrinterPage.aspx?OrderNo=" + s_OrderNo + "&PrinterModel=128917825766562500','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');\">" + s_OrderNo + "</a>";
            this.BeginQuery("Select HouseNo from Knet_Procure_WareHouseList Where OrderNo='" + s_OrderNo + "' ");
            this.QueryForDataTable();
            string s_HouseNo = "";
            if (this.Dtb_Result.Rows.Count > 0)
            {
                s_HouseNo = this.Dtb_Result.Rows[0][0].ToString();
            }
            this.Lbl_House.Text = base.Base_GetHouseName(s_HouseNo);

            KNet.BLL.KNet_Sales_ContractList_Details BLL_Sales_ContractList_Details = new KNet.BLL.KNet_Sales_ContractList_Details();
            string s_Sql = " ContractNo='" + Model.ContractNo + "'";
            DataSet Dts_ContractList = BLL_Sales_ContractList_Details.GetListJoinProducts(s_Sql);
            MyGridView1.DataSource = Dts_ContractList;
            MyGridView1.DataBind();
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

    ///// <summary>
    ///// 出库后更新仓库总账信息
    ///// </summary>
    ///// <param name="thisWareHouseAmount">出库数量</param>
    ///// <param name="thisWareHouseTotalNet"></param>
    ///// <param name="thisWareHouseDiscount"></param>
    ///// <param name="HouseNo"></param>
    ///// <param name="ProductsBarCode"></param>
    //protected void UpdateKNet_WareHouse_Ownall(int thisWareHouseAmount, decimal thisWareHouseTotalNet, decimal thisWareHouseDiscount, string ID)
    //{
    //    try
    //    {
    //        string Dosql = null;

    //        if (thisWareHouseDiscount >= 0)
    //        {
    //            Dosql = "update KNet_WareHouse_Ownall set WareHouseAmount=WareHouseAmount-" + thisWareHouseAmount + ",ShippedQuantity=ShippedQuantity+" + thisWareHouseAmount + ",WareHouseTotalNet=WareHouseTotalNet-" + thisWareHouseTotalNet + ",WareHouseDiscount=WareHouseDiscount-" + thisWareHouseDiscount + "  where   ID='" + ID + "'";
    //        }
    //        else if (thisWareHouseDiscount < 0)
    //        {
    //            Dosql = "update KNet_WareHouse_Ownall set WareHouseAmount=WareHouseAmount-" + thisWareHouseAmount + ",ShippedQuantity=ShippedQuantity+" + thisWareHouseAmount + ",WareHouseTotalNet=WareHouseTotalNet-" + thisWareHouseTotalNet + ",WareHouseDiscount=WareHouseDiscount+" + thisWareHouseDiscount + "  where   ID='" + ID + "'";
    //        }
    //        else { }

    //        //Response.Write(Dosql);
    //        //Response.Write("<BR>");

    //        DbHelperSQL.ExecuteSql(Dosql);
    //    }
    //    catch { }
    //}



    /// <summary>
    /// 是否是自己的订单？
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetProcureOrders_onselftYN(string ProcureBM)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select * from KNet_Sales_ContractList where ContractNo='" + ProcureBM + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["ContractStaffNo"].ToString();
            }
            else
            {
                return "";
            }
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
                s_FlowName = "<font color='Blue'>异常通过!</font>";
                break;
            case "4":
                s_FlowName = "重新提交!";
                break;
            case "0":
                s_FlowName = "<font color='red'>不通过！</font>";
                break;
        }
        return s_FlowName;
    }

    /// <summary>
    /// 仓库明细  流出账
    /// </summary>
    /// <param name="HouseNo">仓库流水——进出仓库唯一值</param>
    /// <param name="WaterType">类型（1 采购入库，2 销售出库，3 直接入库，4 直接出库）</param>
    /// <param name="ProductsName">仓库流水——产品名称</param>
    /// <param name="ProductsBarCode">仓库流水——编码（条形码）</param>
    /// <param name="ProductsPattern">仓库流水——产品型号</param>
    /// <param name="ProductsUnits">仓库流水——单位</param>
    /// <param name="WaterHousePack">仓库流水——产品包装</param>
    /// <param name="WaterHouseAmount">仓库流水——数量</param>
    /// <param name="WaterHouseUnitPrice">仓库流水——单价(原采购单价)</param>
    /// <param name="WaterHouseDiscount">仓库流水——计价调节(原调价平均)</param>
    /// <param name="WaterHouseTotalNet">仓库流水——净值合计(原净值平均)</param>
    /// <param name="WaterSupperUnitsName">仓库流水——往来单位名称</param>
    /// <param name="WaterUnionOrderNo">仓库流水——关联单号</param>
    /// <param name="WaterDoStaffNo">操作者唯一值</param>
    protected void BluidWareHouse_Ownall_Water(string HouseNo, int WaterType, string ProductsName, string ProductsBarCode, string ProductsPattern, string ProductsUnits, string WaterHousePack, int WaterHouseAmount, decimal WaterHouseUnitPrice, decimal WaterHouseDiscount, decimal WaterHouseTotalNet, string WaterSupperUnitsName, string WaterUnionOrderNo, string WaterDoStaffNo)
    {
        KNet.BLL.KNet_WareHouse_Ownall_Water BLL = new KNet.BLL.KNet_WareHouse_Ownall_Water();
        KNet.Model.KNet_WareHouse_Ownall_Water model = new KNet.Model.KNet_WareHouse_Ownall_Water();

        model.HouseNo = HouseNo;
        model.WaterType = WaterType;
        model.WaterDateTime = DateTime.Now;
        model.ProductsName = ProductsName;
        model.ProductsBarCode = ProductsBarCode;
        model.ProductsPattern = ProductsPattern;
        model.ProductsUnits = ProductsUnits;
        model.WaterHousePack = WaterHousePack;
        model.WaterHouseAmount = WaterHouseAmount;
        model.WaterHouseUnitPrice = WaterHouseUnitPrice;
        model.WaterHouseDiscount = WaterHouseDiscount;
        model.WaterHouseTotalNet = WaterHouseTotalNet;
        model.WaterSupperUnitsName = WaterSupperUnitsName;
        model.WaterUnionOrderNo = WaterUnionOrderNo;
        model.WaterDoStaffNo = WaterDoStaffNo;

        try
        {
            BLL.Add(model);
        }
        catch { }
    }

    /// <summary>
    /// 单明细数目
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected int Knet_Procure_OrdersList_Details_Shu(string ContractNo)
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
    /// 返回仓库名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string Knet_Procure_HouseNo(string ContractNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select *  from KNet_Sales_ContractList where ContractNo='" + ContractNo + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["HouseNo"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }
    /// <summary>
    /// 返回关联客户
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string Knet_Procure_CustomerValue(string ContractNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select *  from KNet_Sales_ContractList where ContractNo='" + ContractNo + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["CustomerValue"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string s_ContractNo = Request.QueryString["ContractNo"].ToString();
        string s_Sql = "Update Knet_Sales_flow Set KSF_Del='1' Where KSF_ContractNo='" + s_ContractNo + "' ";
        DbHelperSQL.ExecuteSql(s_Sql);
        AddFlow(s_ContractNo, 4);
        Alert("提交成功！");
        AdminloginMess LogAM = new AdminloginMess();
        LogAM.Add_Logs("销售管理---> 合同审批--->重新提交 操作成功！");

    }

    private void AddFlow(string s_ContractNo, int i_State)
    {

        AdminloginMess AM = new AdminloginMess();
        //插入审核
        KNet.Model.KNet_Sales_Flow Model = new KNet.Model.KNet_Sales_Flow();
        KNet.BLL.KNet_Sales_Flow Bll = new KNet.BLL.KNet_Sales_Flow();
        Model.KFS_Type = 0;
        Model.KSF_ContractNo = s_ContractNo;
        Model.KSF_Date = DateTime.Now;
        Model.KSF_Detail = "";
        Model.KSF_ShPerson = AM.KNet_StaffNo;
        Model.KSF_State = i_State;
        try
        {
            Bll.Add(Model);
        }
        catch
        { throw; }
    }
}
