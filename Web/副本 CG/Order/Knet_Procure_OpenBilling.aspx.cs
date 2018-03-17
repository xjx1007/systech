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
using System.Text;

/// <summary>
/// 采购开单
/// </summary>
public partial class Knet_Web_Procure_Knet_Procure_OrderList : BasePage
{
    public string s_MyTable_Detail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(Knet_Web_Procure_Knet_Procure_OrderList));
        if (!IsPostBack)
        {
            
            AdminloginMess AM = new AdminloginMess();

            this.KNet_Sys_ProcureTypebind();

            this.KNet_OrderStaffBranchbind();
            this.OrderDateTime.Text = DateTime.Now.ToShortDateString();

            try
            {
                this.OrderStaffBranch.SelectedValue = AM.KNet_StaffBranch;
            }
            catch { }

            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string s_ContractNo = Request.QueryString["ContractNo"] == null ? "" : Request.QueryString["ContractNo"].ToString();
            this.Tbx_Type.Text = s_Type;
            if (s_ID != "")
            {
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制采购订单";
                    this.OrderNo.Text = "PO" + KNetOddNumbers();
                }
                else
                {
                    this.Lbl_Title.Text = "修改采购订单";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }
            else
            {
                this.Lbl_Title.Text = "新增采购订单";
                this.OrderNo.Text = "PO" + KNetOddNumbers();
                if (s_ContractNo != "")
                {

                    this.BeginQuery("Select * from Knet_Procure_OrdersList where ContractNos  like  '%" + s_ContractNo + "%' or ContractNo  like  '%" + s_ContractNo + "%' ");
                    this.QueryForDataTable();
                    if (this.Dtb_Result.Rows.Count > 0)
                    {
                        AlertAndGoBack("该订单已采购");
                    }
                    this.SalesOrderNoSelectValue.Value = s_ContractNo;
                    this.SalesOrderNo.Text = s_ContractNo;
                    this.OrderAddress.Text = GetCustomerAddress(s_ContractNo);
                    KNet.BLL.KNet_Sales_ContractList Bll_Contract=new KNet.BLL.KNet_Sales_ContractList();
                    KNet.Model.KNet_Sales_ContractList Model_Contract=Bll_Contract.GetModelB(s_ContractNo);
                    OrderRemarks.Text = Model_Contract.ContractRemarks;
                    this.Tbx_ScDetails.Text = GetScDetails(s_ContractNo);
                    this.OrderType.SelectedValue = "128860698200781250";
                }
            }
            if (AM.CheckLogin(this.Lbl_Title.Text) == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            this.OrderStaffNo.Text = AM.KNet_StaffName;
            this.OrderStaffNotxt.Text = AM.KNet_StaffNo;
            //this.OrderNo.Text = KNetPage.GetOrderId("P");
            this.OrderStaffDepart.SelectedValue = AM.KNet_StaffDepart;


        }
    }
    private void ShowInfo(string s_ID)
    {
        try
        {

            KNet.BLL.Knet_Procure_OrdersList BLL = new KNet.BLL.Knet_Procure_OrdersList();
            KNet.Model.Knet_Procure_OrdersList Model = BLL.GetModelB(s_ID);
            if (Model.OrderCheckYN == true)
            {
                AlertAndGoBack("已审核不能修改");
                return;
            }
            this.Tbx_ID.Text = Model.ID;
            this.OrderNo.Text = Model.OrderNo;
            this.OrderDateTime.Text = DateTime.Parse(Model.OrderDateTime.ToString()).ToShortDateString();
            this.OrderPreToDate.Text = DateTime.Parse(Model.OrderPreToDate.ToString()).ToShortDateString();
            this.SuppNoSelectValue.Value = Model.SuppNo;
            this.SuppNo.Text = base.Base_GetSupplierName(Model.SuppNo);
            //  this.OrderPaymentNotes.SelectedValue = Model.OrderPaymentNotes;
            this.Tbx_SuppNo.Value = Model.ReceiveSuppNo;
            this.Tbx_SuppName.Text = base.Base_GetSupplierName(Model.ReceiveSuppNo);
            this.SalesOrderNoSelectValue.Value = Model.ContractNo;
            this.SalesOrderNo.Text = Model.ContractNos;
            this.OrderStaffDepart.SelectedValue = Model.OrderStaffDepart;
            this.OrderType.SelectedValue = Model.OrderType;
            this.OrderAddress.Text = Model.ContractAddress;
            this.OrderRemarks.Text = Model.OrderRemarks;
            this.OrderFaterNo.Text=Model.ParentOrderNo;
            this.Tbx_ScDetails.Text = Model.KPO_ScDetails;
            
            KNet.BLL.Knet_Procure_OrdersList_Details Bll_Details = new KNet.BLL.Knet_Procure_OrdersList_Details();
            DataSet Dts_Table = Bll_Details.GetList(" b.OrderNo='" + s_ID + "'");
            decimal d_All_OrderTotal = 0, d_All_HandTotal = 0, d_All_Total = 0;
            if (Dts_Table.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                {
                    this.Xs_ProductsCode.Text += Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString() + ",";
                    decimal d_Amount = Decimal.Parse(Dts_Table.Tables[0].Rows[i]["OrderTotalNet"].ToString() == "" ? "0" : Dts_Table.Tables[0].Rows[i]["OrderTotalNet"].ToString()) + Decimal.Parse(Dts_Table.Tables[0].Rows[i]["HandTotal"].ToString() == "" ? "0" : Dts_Table.Tables[0].Rows[i]["HandTotal"].ToString());
                    d_All_OrderTotal += Decimal.Parse(Dts_Table.Tables[0].Rows[i]["OrderTotalNet"].ToString() == "" ? "0" : Dts_Table.Tables[0].Rows[i]["OrderTotalNet"].ToString());
                    d_All_HandTotal += Decimal.Parse(Dts_Table.Tables[0].Rows[i]["HandTotal"].ToString() == "" ? "0" : Dts_Table.Tables[0].Rows[i]["HandTotal"].ToString());
                    d_All_Total += d_Amount;
                    s_MyTable_Detail += " <tr>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">";
                    if ((this.Tbx_ID.Text != "")&&(this.Tbx_Type.Text!="1"))
                    {
                        s_MyTable_Detail += "<input type=\"hidden\"  Name=\"ID_" + i.ToString() + "\" value='" + Dts_Table.Tables[0].Rows[i]["ID"].ToString() + "'>";
                    }
                    s_MyTable_Detail += "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ProductsName_" + i.ToString() + "\" value='" + base.Base_GetProdutsName(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "'>" + base.Base_GetProdutsName(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ProductsBarCode_" + i.ToString() + "\" value='" + Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "'>" + Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ProductsPattern_" + i.ToString() + "\" value='" + base.Base_GetProductsPattern(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "'>" + base.Base_GetProductsPattern(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ProductsEdition_" + i.ToString() + "\" value='" + base.Base_GetProductsEdition(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "'>" + base.Base_GetProductsEdition(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"ChangPrice();this.className=\'detailedViewTextBox\'\"   Name=\"Number_" + i.ToString() + "\" value='" + Dts_Table.Tables[0].Rows[i]["OrderAmount"].ToString() + "'></td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"ChangPrice();this.className=\'detailedViewTextBox\'\"   Name=\"Price_" + i.ToString() + "\" value='" + Dts_Table.Tables[0].Rows[i]["OrderUnitPrice"].ToString() + "'></td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\"  Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\"  Name=\"Money_" + i.ToString() + "\" value='" + Dts_Table.Tables[0].Rows[i]["OrderTotalNet"].ToString() + "'></td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input  type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" Name=\"HandPrice_" + i.ToString() + "\" value='" + FormatNumber(Dts_Table.Tables[0].Rows[i]["HandPrice"].ToString() == "" ? "0" : Dts_Table.Tables[0].Rows[i]["HandPrice"].ToString(), 3) + "'></td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\"  Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\"  Name=\"HandMoney_" + i.ToString() + "\" value='" + FormatNumber(Dts_Table.Tables[0].Rows[i]["HandTotal"].ToString() == "" ? "0" : Dts_Table.Tables[0].Rows[i]["HandTotal"].ToString(), 3) + "'></td>";

                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\"  Name=\"Remarks_" + i.ToString() + "\"  value=''></td>";

                }
                this.Tbx_Num.Text = Dts_Table.Tables[0].Rows.Count.ToString();
            }
        }
        catch (Exception ex)
        {
        }
    }

    #region 返回单号情况

    /// <summary>
    /// 返回当前的  单号 （唯一性，如 2009121402）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string KNetOddNumbers()
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string s_Code = "";
            this.BeginQuery("select SuppCode from Knet_Procure_Suppliers Where SuppNo='" + this.SuppNo.Text + "' ");
            DataTable Dtb_Table = this.QueryForDataTable();
            if (Dtb_Table.Rows.Count > 0)
            {
                s_Code = Dtb_Table.Rows[0][0].ToString();
            }
            string Dostr = "select count(*) as AA  from  Knet_Procure_OrdersList  where (datediff(d,SystemDatetimes,GETDATE())=0)";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (int.Parse(dr["AA"].ToString()) == 0)
                {
                    return s_Code + DateTime.Today.ToString("yyyyMMdd").Substring(2, 2) + "001";
                }
                else
                {
                    return s_Code + DateTime.Today.ToString("yyyyMMdd").Substring(2, 2) + KNus003(int.Parse(dr["AA"].ToString()) + 1);
                }
            }
            else
            {
                return s_Code + DateTime.Today.ToString("yyyyMMdd").Substring(2, 2) + "001";
            }
        }
    }
    /// <summary>
    /// 返回当前的  单号 （唯一性，如 2009121402）
    /// </summary>
    /// <param name="ss"></param>
    /// <returns></returns>
    protected string KNus003(int ss)
    {
        if (ss.ToString().Length == 1)
        {
            return "000" + ss.ToString();
        }
        else if (ss.ToString().Length == 2)
        {
            return "00" + ss.ToString();
        }
        else if (ss.ToString().Length == 3)
        {
            return "0" + ss.ToString();
        }
        else if (ss.ToString().Length == 4)
        {
            return ss.ToString();
        }
        else
        {
            return ss.ToString();
        }
    }
    #endregion




    /// <summary>
    /// 采购类型
    /// </summary> 
    protected void KNet_Sys_ProcureTypebind()
    {
        KNet.BLL.KNet_Sys_ProcureType bll = new KNet.BLL.KNet_Sys_ProcureType();
        DataSet ds = bll.GetAllList();
        this.OrderType.DataSource = ds;
        this.OrderType.DataTextField = "ProcureTypeName";
        this.OrderType.DataValueField = "ProcureTypeValue";
        this.OrderType.DataBind();
        ListItem item = new ListItem("请选择采购类型", ""); //默认值
        this.OrderType.Items.Insert(0, item);
    }
    /// <summary>
    /// 公司或部门绑定
    /// </summary> 
    protected void KNet_OrderStaffBranchbind()
    {
        KNet.BLL.KNet_Resource_OrganizationalStructure bll = new KNet.BLL.KNet_Resource_OrganizationalStructure();
        DataSet ds = bll.GetList(" StrucPID='0' ");
        this.OrderStaffBranch.DataSource = ds;
        this.OrderStaffBranch.DataTextField = "StrucName";
        this.OrderStaffBranch.DataValueField = "StrucValue";
        this.OrderStaffBranch.DataBind();

        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from KNet_Resource_OrganizationalStructure where StrucPID='" + this.OrderStaffBranch.SelectedValue + "' ", conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            this.OrderStaffDepart.DataSource = sdr;
            this.OrderStaffDepart.DataTextField = "StrucName";
            this.OrderStaffDepart.DataValueField = "StrucValue";
            this.OrderStaffDepart.DataBind();
            ListItem item3 = new ListItem("请选择部门", ""); //默认值
            this.OrderStaffDepart.Items.Insert(0, item3);
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
            string proID = this.OrderStaffBranch.SelectedValue.ToString().Trim();
            using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from KNet_Resource_OrganizationalStructure where StrucPID='" + proID + "' ", conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                this.OrderStaffDepart.DataSource = sdr;
                this.OrderStaffDepart.DataTextField = "StrucName";
                this.OrderStaffDepart.DataValueField = "StrucValue";
                this.OrderStaffDepart.DataBind();
                ListItem item = new ListItem("请选择部门", ""); //默认值
                this.OrderStaffDepart.Items.Insert(0, item);
            }
        }
        catch { }
    }
    /// <summary>
    /// 检查此供应商是否存在
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected bool GetSupplierYN(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,SuppNo,SuppName from Knet_Procure_Suppliers where SuppNo='" + aa + "'";
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
    /// 保存采购单
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        AdminloginMess AM=new AdminloginMess();
        string OrderTopic1 = KNetPage.KHtmlEncode("");
        string OrderNo1 = KNetPage.KHtmlEncode(this.OrderNo.Text.Trim());

        DateTime OrderDateTime1 = DateTime.Now;
        try
        {
            OrderDateTime1 = DateTime.Parse(this.OrderDateTime.Text.Trim());
        }
        catch { }


        DateTime OrderPreToDate1 = DateTime.Parse("1900-10-10");
        if (this.OrderPreToDate.Text != "" && this.OrderPreToDate.Text != null)
        {
            OrderPreToDate1 = DateTime.Parse(this.OrderPreToDate.Text.Trim());
        }

        string SuppNo1 = this.SuppNoSelectValue.Value;
        if (GetSupplierYN(SuppNo1) == false)
        {
            Response.Write("<script language=javascript>alert('您没有选择供应商或是选择出错，请重新选择供应商!');history.back(-1);</script>");
            Response.End();
        }

        // string OrderPaymentNotes1 = this.OrderPaymentNotes.SelectedValue;
        string OrderStaffBranch1 = this.OrderStaffBranch.SelectedValue;
        string OrderStaffDepart1 = this.OrderStaffDepart.SelectedValue;

        string OrderStaffNo1 = this.OrderStaffNotxt.Text.Trim();
        string OrderCheckStaffNo1 = this.OrderCheckStaffNotxt.Text.Trim();

        decimal OrderTransShare1 = decimal.Parse(this.OrderTransShare.Text.Trim());
        string OrderType1 = this.OrderType.SelectedValue;
        string OrderRemarks1 = KNetPage.KHtmlEncode(this.OrderRemarks.Text.Trim());

        decimal AdvancesPrice1 = decimal.Parse(this.AdvancesPrice.Text.Trim());
        int paykings = int.Parse(this.paykings.SelectedValue);
        string ContractNo = this.SalesOrderNoSelectValue.Value;
        string ContractAddress = this.OrderAddress.Text.ToString();
        decimal InvoRate = decimal.Parse(this.InvoRate.Text.Trim());


        KNet.BLL.Knet_Procure_OrdersList BLL = new KNet.BLL.Knet_Procure_OrdersList();
        KNet.Model.Knet_Procure_OrdersList model = new KNet.Model.Knet_Procure_OrdersList();
        if (this.Tbx_ID.Text != "")
        {
            model.ID = this.Tbx_ID.Text;
        }
        else
        {
            model.ID = base.GetMainID();
        }
        model.OrderTopic = OrderTopic1;
        model.OrderNo = OrderNo1;
        model.OrderDateTime = OrderDateTime1;
        model.OrderPreToDate = OrderPreToDate1;
        model.SuppNo = SuppNo1;
        //  model.OrderPaymentNotes = OrderPaymentNotes1;
        model.OrderStaffBranch = OrderStaffBranch1;
        model.OrderStaffDepart = OrderStaffDepart1;
        model.OrderStaffNo = OrderStaffNo1;
        model.OrderCheckStaffNo = OrderCheckStaffNo1;
        model.OrderTransShare = OrderTransShare1;
        model.OrderType = OrderType1;
        model.OrderRemarks = OrderRemarks1;
        model.AdvancesPrice = AdvancesPrice1;
        model.paykings = paykings;
        model.ContractNo = ContractNo;
        model.ContractAddress = ContractAddress;
        model.InvoRate = InvoRate;
        model.ReceiveSuppNo = this.Tbx_SuppNo.Value;
        model.ContractNos = this.SalesOrderNo.Text;
        model.ParentOrderNo = this.OrderFaterNo.Text;

        model.KPO_Creator = AM.KNet_StaffNo;
        model.KPO_CTime = DateTime.Now;
        model.KPO_Mender = AM.KNet_StaffNo;
        model.KPO_MTime = DateTime.Now;
        model.ArrivalDate = OrderPreToDate1;
        model.KPO_ScDetails = this.Tbx_ScDetails.Text;

        ArrayList Arr_Products = new ArrayList();
        int i_Num = int.Parse(this.Tbx_Num.Text);
        for (int i = 0; i < i_Num; i++)
        {
            if (Request.Form["ProductsBarCode_" + i] != null)
            {
                string s_ProductsBarCode = Request.Form["ProductsBarCode_" + i];
                string s_ProductsName = Request.Form["ProductsName_" + i];
                string s_ProductsPattern = Request.Form["ProductsPattern_" + i];    
                string s_Number = Request.Form["Number_" + i];
                string s_Price = Request.Form["Price_" + i];
                string s_Money = Request.Form["Money_" + i];
                string s_HandPrice = Request.Form["HandPrice_" + i];
                string s_HandMoney = Request.Form["HandMoney_" + i];
                string s_Remarks = Request.Form["Remarks_" + i];
                string s_DID = Request.Form["ID_" + i]==null?GetMainID(i):Request.Form["ID_" + i];
                KNet.Model.Knet_Procure_OrdersList_Details Model_Details = new KNet.Model.Knet_Procure_OrdersList_Details();
                Model_Details.ProductsBarCode = s_ProductsBarCode;
                Model_Details.ProductsName = s_ProductsName;
                Model_Details.ProductsPattern = s_ProductsPattern;
                Model_Details.OrderAmount = int.Parse(s_Number);
                Model_Details.OrderUnitPrice = decimal.Parse(s_Price);
                Model_Details.ID = s_DID;
                try
                {
                    Model_Details.HandPrice = decimal.Parse(s_HandPrice);
                }
                catch { }
                try
                {
                    Model_Details.HandTotal =Model_Details.OrderAmount * Model_Details.HandPrice ;
                }
                catch { }

                Model_Details.OrderTotalNet =  Model_Details.OrderAmount * Model_Details.OrderUnitPrice;
                Model_Details.OrderRemarks = s_Remarks.ToString();
                if (s_Number != "0")
                {
                    Arr_Products.Add(Model_Details);
                }
            }


        }
        //string[] s_ProductsBarCode = Request.Form["ProductsBarCode"].Split(',');
        //string[] s_ProductsName = Request.Form["ProductsName"].Split(',');
        //string[] s_ProductsPattern = Request.Form["ProductsPattern"].Split(',');
        //string[] s_Number = Request.Form["Number"].Split(',');
        //string[] s_Price = Request.Form["Price"].Split(',');
        //string[] s_Money = Request.Form["Money"].Split(',');
        //string[] s_HandPrice = Request.Form["HandPrice"].Split(',');
        //string[] s_HandMoney = Request.Form["HandMoney"].Split(',');
        //string[] s_Remarks = Request.Form["Remarks"].Split(',');
        //for (int i = 0; i < s_ProductsBarCode.Length; i++)
        //{
        //    KNet.Model.Knet_Procure_OrdersList_Details Model_Details = new KNet.Model.Knet_Procure_OrdersList_Details();
        //    Model_Details.ProductsBarCode = s_ProductsBarCode[i];
        //    Model_Details.ProductsName = s_ProductsName[i];
        //    Model_Details.ProductsPattern = s_ProductsPattern[i];
        //    Model_Details.OrderAmount = int.Parse(s_Number[i]);
        //    Model_Details.OrderUnitPrice = decimal.Parse(s_Price[i]);
        //    Model_Details.OrderTotalNet = decimal.Parse(s_Money[i]);
        //    try
        //    {
        //        Model_Details.HandPrice = decimal.Parse(s_HandPrice[i]);
        //    }
        //    catch { }
        //    try
        //    {
        //        Model_Details.HandTotal = decimal.Parse(s_HandMoney[i]);
        //    }
        //    catch { }
        //    Model_Details.OrderRemarks = s_Remarks[i].ToString();
        //    Arr_Products.Add(Model_Details);
        //}
        model.Arr_ProductsList = Arr_Products;


        string s_ID = this.Tbx_ID.Text;
        try
        {

            if (s_ID == "")//新增
            {
                if (BLL.Exists(OrderNo1) == false)
                {
                    BLL.Add(model);
                    AdminloginMess LogAM = new AdminloginMess();
                    LogAM.Add_Logs("采购入库--->采购开单--->开单 添加 操作成功！采购单号：" + OrderNo1);

                    string JSD = "CG/Order/Knet_Procure_OpenBilling_Print.aspx?ID=" + model.ID + "";
                    base.HtmlToPdf1(JSD, Server.MapPath("PDF"), OrderNo1);
                    //发给研发中心经理
                   // base.Base_SendMessage(Base_GetDeptPerson("研发中心", 1), KNetPage.KHtmlEncode("有 采购订单 <a href='Web/Order/Knet_Procure_OpenBilling_View.aspx?ID=" + OrderNo1 + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + OrderNo1 + "</a> 需要您作为负责人选择审批流程，敬请关注！"));
                    //base.Base_SendMessage(Base_GetDeptPerson("供应链平台", 1), KNetPage.KHtmlEncode("有 采购订单 <a href='Web/Order/Knet_Procure_OpenBilling_View.aspx?ID=" + OrderNo1 + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + OrderNo1 + "</a> 需要您作为负责人选择审批流程，敬请关注！"));

                    AlertAndRedirect("采购开单 添加  操作成功", "Knet_Procure_OpenBilling_Manage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('采购单号已存在 添加失败！');history.back(-1);</script>");
                    Response.End();
                }
            }
            else
            {
                model.ID = this.Tbx_ID.Text;
                BLL.Update(model);
                string JSD = "CG/Order/Knet_Procure_OpenBilling_Print.aspx?ID=" + model.ID + "";
                base.HtmlToPdf1(JSD, Server.MapPath("PDF"), OrderNo1);
                AdminloginMess LogAM = new AdminloginMess();
                LogAM.Add_Logs("采购入库--->采购开单--->开单 修改 操作成功！采购单号：" + OrderNo1);
                AlertAndRedirect("采购开单 修改  操作成功", "Knet_Procure_OpenBilling_Manage.aspx");
            }

        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('采购添加失败！');history.back(-1);</script>");
            Response.End();
            ShowInfo(this.Tbx_ID.Text);
        }
    }
    [Ajax.AjaxMethod]
    public string GetScDetails(string ContractNo)
    {
        string s_ScDetails = "";
        try
        {
            string s_Sql = "Select * from Xs_Contract_FhDetails where XCF_FID in ('" + ContractNo.Replace(",", "','") + "')";
            this.BeginQuery(s_Sql);
            DataTable Dtb_Table = this.QueryForDataTable();
            for (int i = 0; i < Dtb_Table.Rows.Count; i++)
            {
                s_ScDetails +=Dtb_Table.Rows[i]["XCF_Details"].ToString() + "\n";
            }
        }
        catch { }
        return s_ScDetails;
    }


    public string GetCustomerAddress(string s_ContractNo)
    {
        this.BeginQuery("Select CustomerAddress,CustomerName,CustomerContact,CustomerTel,CustomerMobile From KNet_Sales_ClientList Where CustomerValue in(select CustomerValue from KNet_Sales_ContractList Where ContractNo='" + s_ContractNo + "') ");
        this.QueryForDataTable();
        StringBuilder Sb_Return = new StringBuilder();
        Sb_Return.Append("地址: " + this.Dtb_Result.Rows[0][0].ToString() + "\n");
        Sb_Return.Append(this.Dtb_Result.Rows[0][1].ToString() + "\n");
        Sb_Return.Append("收货人:" + this.Dtb_Result.Rows[0][2].ToString() + "\n");
        if (this.Dtb_Result.Rows[0][3].ToString() != "")
        {
            Sb_Return.Append("联系电话:" + this.Dtb_Result.Rows[0][3].ToString() + "\n");
        }
        else
        {
            Sb_Return.Append("联系手机:" + this.Dtb_Result.Rows[0][4].ToString() + "\n");
        }
        return Sb_Return.ToString();
    }

    [Ajax.AjaxMethod]
    public string KNetOddNumbers(string s_SuppNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string s_Code = "PO";
            this.BeginQuery("select SuppCode from Knet_Procure_Suppliers Where SuppNo='" + s_SuppNo + "' ");
            DataTable Dtb_Table = this.QueryForDataTable();
            if (Dtb_Table.Rows.Count > 0)
            {
                s_Code += Dtb_Table.Rows[0][0].ToString();
            }
            string Dostr = "select Max(OrderNo) as AA  from  Knet_Procure_OrdersList  where year(SystemDatetimes)=year(GetDate()) and OrderNo like '" + s_Code + "1%' ";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["AA"].ToString() == "")
                {
                    return s_Code + DateTime.Today.ToString("yyyyMMdd").Substring(2, 2) + "0001";
                }
                else
                {
                    return s_Code + DateTime.Today.ToString("yyyyMMdd").Substring(2, 2) + KNus003(int.Parse(dr["AA"].ToString().Substring(s_Code.Length + 2, 4)) + 1);
                }
            }
            else
            {
                return s_Code + DateTime.Today.ToString("yyyyMMdd").Substring(2, 2) + "0001";
            }
        }
    }


}
