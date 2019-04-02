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
using System.Net.Mail;

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

            string s_Type = Request.QueryString["Types"] == null ? "" : Request.QueryString["Types"].ToString();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string s_ContractNo = Request.QueryString["ContractNo"] == null ? "" : Request.QueryString["ContractNo"].ToString();

            string s_IsChange = Request.QueryString["IsChange"] == null ? "" : Request.QueryString["IsChange"].ToString();
            string Sampling = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            
            string Sampling1 = Request.QueryString["Sampling"] == null ? "" : Request.QueryString["Sampling"].ToString();//验证生产部是否为通过订单评审下的生产订单
            string SamplingID = Request.QueryString["SamlingID"] == null ? "" : Request.QueryString["SamlingID"].ToString();//获取请购单号
            if (Sampling == "Sampling")
            {
                this.Sampling.Text = "Sampling";
            }
            if (SamplingID!="")
            {
                this.SamplingID.Text = SamplingID;
            }
            if (Sampling1== "")
            {
                if (AM.YNAuthority("物料采购权限")==false)
                {
                    Response.Write("<script language=javascript>alert('请根据订单评审创建生产订单！');</script>");
                    Response.End();

                }
            }
            this.TextBox1.Text = Sampling1;
            base.Base_DropWareHouseBind(this.Ddl_HouseNo, "  KSW_Type=0 ");
            if (AM.KNet_StaffDepart == "131161769392290242")//如果是生产部
            {
                this.OrderType.SelectedValue = "128860698200781250";
                this.OrderType.Enabled = false;
                this.Tbx_SuppNo.Value = "131187205665612658";
                this.Tbx_SuppName.Text = "杭州士腾科技有限公司";
                this.Ddl_HouseNo.SelectedValue = "131187187069993664";
                this.OrderAddress.Text = base.Base_GetSuppNoAddress(this.Tbx_SuppNo.Value).Replace("$", "\n");
            }
            this.Tbx_Change.Text = s_IsChange;
            this.Tbx_Type.Text = s_Type;
            if (s_ID != "")
            {
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制采购单";
                    if (Sampling!="")
                    {
                        this.OrderNo.Text="YP" + string.Format("{0:yyyyMMddHH}", DateTime.Now);//如果是样品采购
                    }
                    else
                    {
                        this.OrderNo.Text = "PO" + KNetOddNumbers();
                    }
                   

                }
                else
                {
                    this.Lbl_Title.Text = "修改采购订单";
                    //this.Img_SelectSuppNo.Visible = false;
                    this.Tbx_OrderNo.Text = s_ID;
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }
            else
            {
                this.Lbl_Title.Text = "新增采购订单";
                if (Sampling != "")
                {
                    this.OrderNo.Text = "YP" + string.Format("{0:yyyyMMddHH}", DateTime.Now);
                }
                else
                {
                    this.OrderNo.Text = "PO" + KNetOddNumbers();
                }

                if (s_ContractNo != "")
                {
                    string s_State = base.GetCgState(s_ContractNo);
                    if (s_State == "1")
                    {
                        AlertAndGoBack("该订单已采购");
                    }
                    this.SalesOrderNoSelectValue.Value = s_ContractNo;
                    this.SalesOrderNo.Text = s_ContractNo;
                    //this.OrderAddress.Text = GetCustomerAddress(s_ContractNo);
                    KNet.BLL.KNet_Sales_ContractList Bll_Contract = new KNet.BLL.KNet_Sales_ContractList();
                    KNet.Model.KNet_Sales_ContractList Model_Contract = Bll_Contract.GetModelB(s_ContractNo);
                    OrderRemarks.Text = Model_Contract.ContractRemarks;
                    this.Tbx_ScDetails.Text = GetScDetails(s_ContractNo);

                    try
                    {
                        //查询如果有电池则在生产说明里面加入电池信息
                        string s_Sql = "Select * from KNet_Sales_ContractList_Details a join KNET_Sys_Products b on a.ProductsBarCode=b.ProductsBarCode where ContractNo='" + s_ContractNo + "'";
                        s_Sql += " and ProductsType='M130704050932527' ";
                        this.BeginQuery(s_Sql);
                        DataTable Dtb_Table = (DataTable)this.QueryForDataTable();
                        if (Dtb_Table.Rows.Count > 0)
                        {
                            for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                            {
                                if (i == 0)
                                {
                                    this.Tbx_ScDetails.Text += " 配：";
                                }
                                this.Tbx_ScDetails.Text += Dtb_Table.Rows[i]["ProductsEdition"].ToString();
                            }

                            this.Tbx_ScDetails.Text += " 电池";
                        }
                    }
                    catch
                    { }
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

            this.Tbx_Title.Text = this.Lbl_Title.Text;
        }
    }
    private void ShowInfo(string s_ID)
    {
        try
        {

            KNet.BLL.Knet_Procure_OrdersList BLL = new KNet.BLL.Knet_Procure_OrdersList();
            KNet.Model.Knet_Procure_OrdersList Model = BLL.GetModelB(s_ID);
            /* if (Model.OrderCheckYN == true)
             {
                 AlertAndGoBack("已审核不能修改");
                 return;
             }*/
            //this.selectSupp.Style["Display"] = "Block";GetMainID
            
            if (Tbx_Type.Text=="")
            {
                this.Tbx_ID.Text = Model.ID;
                this.OrderNo.Text = Model.OrderNo;
            }
            else
            {
                this.Tbx_ID.Text = GetMainID();
            }
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
            this.OrderFaterNo.Text = Model.ParentOrderNo;
            this.Tbx_ScDetails.Text = Model.KPO_ScDetails;
            this.Ddl_HouseNo.SelectedValue = Model.KPO_PreHouseNo;
            if (Model.KPO_PriceState == 1)
            {
                this.Chk_PriceState.Checked = true;
            }
            else
            {
                this.Chk_PriceState.Checked = false;
            }


            if (this.Tbx_Change.Text == "1")
            {
                this.Tbx_ID.Text = "";
                this.Tbx_OldID.Text = s_ID;
                //this.SuppNoSelectValue.Value = "";
                //this.SuppNo.Text = "";
                //this.OrderNo.Text = "";
                //this.Lbl_Title.Text = "移动OEM订单";
            }

            KNet.BLL.Knet_Procure_OrdersList_Details Bll_Details = new KNet.BLL.Knet_Procure_OrdersList_Details();
            DataSet Dts_Table;
            if (Model.KPO_Sampling=="1")
            {
                Dts_Table = Bll_Details.GetList(s_ID);
            }
            else
            {
                Dts_Table = Bll_Details.GetList(" b.OrderNo='" + s_ID + "'");
            }

            decimal d_All_OrderTotal = 0, d_All_HandTotal = 0, d_All_Total = 0, OrderCount = 0;
            if (Dts_Table.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                {
                    string s_ProductsCPBZNumber= Dts_Table.Tables[0].Rows[i]["KSP_BZNumber"].ToString();
                    string s_OrderAmount = Dts_Table.Tables[0].Rows[i]["OrderAmount"].ToString();
                    string s_CPBZNumber = Dts_Table.Tables[0].Rows[i]["KPOD_CPBZNumber"].ToString();
                    string s_BZNumber = Dts_Table.Tables[0].Rows[i]["KPOD_BZNumber"].ToString();
                    string s_OrderPrice = Dts_Table.Tables[0].Rows[i]["OrderUnitPrice"].ToString();
                    string s_OrderTotalNet = Dts_Table.Tables[0].Rows[i]["OrderTotalNet"].ToString();
                    //decimal BigUnits= Convert.ToDecimal(Dts_Table.Tables[0].Rows[i]["KPOD_BigUnits"]);
                    string BigUnits =Dts_Table.Tables[0].Rows[i]["KPOD_BigUnits"].ToString();
                    string s_HandPrice =  FormatNumber(Dts_Table.Tables[0].Rows[i]["HandPrice"].ToString() == "" ? "0" : Dts_Table.Tables[0].Rows[i]["HandPrice"].ToString(), 3) ;
                   string s_HandTotal = FormatNumber(Dts_Table.Tables[0].Rows[i]["HandTotal"].ToString() == "" ? "0" : Dts_Table.Tables[0].Rows[i]["HandTotal"].ToString(), 3);
                    string s_OrderCPBZNumber = "0", s_OrderBZNumber = "0";
                    try
                    {
                        if (s_CPBZNumber == "0")
                        {
                            if (s_ProductsCPBZNumber != "0")
                            {

                                s_OrderCPBZNumber = s_ProductsCPBZNumber;
                                int i_NumOder= int.Parse(s_OrderAmount) / int.Parse(s_OrderCPBZNumber);
                                if (int.Parse(s_OrderAmount) > (int.Parse(s_OrderCPBZNumber) * i_NumOder))
                                {
                                    s_OrderBZNumber = Convert.ToString(int.Parse(s_OrderAmount) / int.Parse(s_OrderCPBZNumber) + 1);
                                }
                                else
                                {
                                    s_OrderBZNumber = Convert.ToString(int.Parse(s_OrderAmount) / int.Parse(s_OrderCPBZNumber));
                                }

                                s_OrderAmount = Convert.ToString(int.Parse(s_OrderBZNumber) * int.Parse(s_OrderCPBZNumber));
                                s_OrderTotalNet = FormatNumber1(Convert.ToString(decimal.Parse(s_OrderAmount) * decimal.Parse(s_OrderPrice)),2);
                            }
                            OrderCount +=decimal.Parse(s_OrderAmount) ;
                        }
                        else
                        {
                            s_OrderCPBZNumber = s_CPBZNumber;
                            s_OrderBZNumber = s_BZNumber;

                        }
                    }
                    catch
                    { }

                    this.Xs_ProductsCode.Text += Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString() + ",";
                    decimal d_Amount = Decimal.Parse(Dts_Table.Tables[0].Rows[i]["OrderTotalNet"].ToString() == "" ? "0" : Dts_Table.Tables[0].Rows[i]["OrderTotalNet"].ToString()) + Decimal.Parse(Dts_Table.Tables[0].Rows[i]["HandTotal"].ToString() == "" ? "0" : Dts_Table.Tables[0].Rows[i]["HandTotal"].ToString());
                    d_All_OrderTotal += Decimal.Parse(Dts_Table.Tables[0].Rows[i]["OrderTotalNet"].ToString() == "" ? "0" : Dts_Table.Tables[0].Rows[i]["OrderTotalNet"].ToString());
                    d_All_HandTotal += Decimal.Parse(Dts_Table.Tables[0].Rows[i]["HandTotal"].ToString() == "" ? "0" : Dts_Table.Tables[0].Rows[i]["HandTotal"].ToString());
                    d_All_Total += d_Amount;
                    s_MyTable_Detail += " <tr>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">";
                    if ((this.Tbx_ID.Text != "") && (this.Tbx_Type.Text != "1"))
                    {
                        s_MyTable_Detail += "<input type=\"hidden\"  Name=\"ID_" + i.ToString() + "\" value='" + Dts_Table.Tables[0].Rows[i]["ID"].ToString() + "'><A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a>";
                    }
                    s_MyTable_Detail += "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ProductsName_" + i.ToString() + "\" value='" + base.Base_GetProdutsName(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "'>" + base.Base_GetProdutsName(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ProductsBarCode_" + i.ToString() + "\" value='" + Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "'>" + base.Base_GetProductsCode(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ProductsPattern_" + i.ToString() + "\" value='" + base.Base_GetProductsPattern(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "'>" + base.Base_GetProductsPattern(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ProductsEdition_" + i.ToString() + "\" value='" + base.Base_GetProductsEdition(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "'>" + base.Base_GetProductsEdition(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"BrandName_" + i.ToString() + "\" value='" + Dts_Table.Tables[0].Rows[i]["KPOD_BrandName"].ToString() + "'>" + Dts_Table.Tables[0].Rows[i]["KPOD_BrandName"].ToString() + "</td>";

                    
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"ChangPrice();this.className=\'detailedViewTextBox\'\"  style=\"width:70px;\"   Name=\"CPBZNumber_" + i.ToString() + "\" value='" + s_OrderCPBZNumber + "'></td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"ChangPrice();this.className=\'detailedViewTextBox\'\"  style=\"width:70px;\"   Name=\"BZNumber_" + i.ToString() + "\" value='" + s_OrderBZNumber + "'></td>";

                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"ChangPrice();this.className=\'detailedViewTextBox\'\"  style=\"width:70px;\"   Name=\"Number_" + i.ToString() + "\" value='" + s_OrderAmount + "'></td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"ChangPrice();this.className=\'detailedViewTextBox\'\"  style=\"width:70px;\"    Name=\"Price_" + i.ToString() + "\" value='" + s_OrderPrice + "'></td>";
                    //添加一个小单位
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\"  Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\"  style=\"width:70px;\"  Name=\"Units_" + i.ToString() + "\" value='" + BigUnits + "'></td>";

                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\"  Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\"  style=\"width:70px;\"  Name=\"Money_" + i.ToString() + "\" value='" + s_OrderTotalNet + "'></td>";
                    //// 添加一个大单位
                    // s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\"  Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\"  style=\"width:70px;\"  Name=\"CountWeight_" + i.ToString() + "\" value='" + BigUnits + "'></td>";
                    //s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input  type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\"  style=\"width:70px;\"  Name=\"HandPrice1_" + i.ToString() + "\" value='" + s_HandPrice + "'></td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input  type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\"  style=\"width:70px;\"  Name=\"HandPrice_" + i.ToString() + "\" value='" +s_HandPrice + "'></td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\"  Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\"  style=\"width:70px;\"  Name=\"HandMoney_" + i.ToString() + "\" value='" +s_HandTotal+ "'></td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\"  style=\"width:70px;\"  Name=\"Remarks_" + i.ToString() + "\"  value=''></td>";
                    s_MyTable_Detail += "</tr>";
                }
                this.Tbx_Num.Text = Dts_Table.Tables[0].Rows.Count.ToString();
                this.NumCount.Text = OrderCount.ToString();
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
        if (this.Lbl_Title.Text == "修改采购订单")
        {
            return this.OrderNo.Text;
        }
        else
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
        AdminloginMess AM = new AdminloginMess();
        string OrderTopic1 = KNetPage.KHtmlEncode("");
        //string OrderNo1 = "";
        //string str =  Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
        
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
        //if (GetSupplierYN(SuppNo1) == false)
        //{
        //    Response.Write("<script language=javascript>alert('您没有选择供应商或是选择出错，请重新选择供应商!');history.back(-1);</script>");
        //    Response.End();
        //}

        //string OrderPaymentNotes1 = this.OrderPaymentNotes.SelectedValue;
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
        if (Sampling.Text != "")
        {
            model.KPO_Sampling = "1";
        }
        model.OrderTopic = OrderTopic1;
        if (SamplingID.Text!="")//如果是请购单，
        {
            model.OrderNo = SamplingID.Text;
        }
        else
        {
            model.OrderNo = OrderNo1;
        }
       
        model.OrderDateTime = OrderDateTime1;
        model.OrderPreToDate = OrderPreToDate1;
        if (SuppNo1=="")
        {
            model.SuppNo = "131187205665612658";
        }
        else
        {
            model.SuppNo = SuppNo1;
        }
        
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

        model.KPO_PreHouseNo = this.Ddl_HouseNo.SelectedValue;
        if (this.Chk_PriceState.Checked)
        {
            model.KPO_PriceState = 1;
        }
        else
        {
            model.KPO_PriceState = 0;
        }
        decimal OrderNumCount = 0;//所有订单总数量
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
                string s_HandPrice = "";
                if (SuppNo1=="")
                {
                     s_HandPrice = "0";
                }
                else
                {
                     s_HandPrice = Request.Form["HandPrice_" + i];
                }
                
                string s_HandMoney = Request.Form["HandMoney_" + i];
                string s_Remarks = Request.Form["Remarks_" + i];
                string s_CPBZNumber = Request.Form["CPBZNumber_" + i];
                string s_BZNumber = Request.Form["BZNumber_" + i];
                string s_BrandName = Request.Form["BrandName_" + i];
                string Units= Request.Form["Units_" + i].ToString();
                //if (Request.Form["BigUnits_" + i].ToString()!="")
                //{
                //     BigUnits = Request.Form["BigUnits_" + i].ToString();
                //}
                //else
                //{
                //     BigUnits = Request.Form["Units_" + i].ToString();
                //}
                //KNet.BLL.KNet_Sys_Products bll = new KNet.BLL.KNet_Sys_Products();
                //DataSet ds=bll.GetList(" ProductsBarCode='" + s_ProductsBarCode + "'");
                string KSP_BigUnits = base.Base_GetBigUnitsByProductCode(s_ProductsBarCode); //ds.Tables[0].Rows[0]["KSP_BigUnits"].ToString();
                if (KSP_BigUnits!="")//如果有大单位
                {
                    string c = KSP_BigUnits.Remove(KSP_BigUnits.LastIndexOf("/"));
                    s_Number = (Convert.ToInt32(c)*Convert.ToInt32(s_Number)).ToString();
                }

                string s_DID = Request.Form["ID_" + i] == null ? GetMainID(i) : Request.Form["ID_" + i];
                KNet.Model.Knet_Procure_OrdersList_Details Model_Details = new KNet.Model.Knet_Procure_OrdersList_Details();
                Model_Details.ProductsBarCode = s_ProductsBarCode;
                Model_Details.ProductsName = s_ProductsName;
                Model_Details.ProductsPattern = s_ProductsPattern;
                Model_Details.OrderAmount = Convert.ToInt32(s_Number);
                OrderNumCount+= Convert.ToInt32(s_Number);
                Model_Details.OrderUnitPrice = decimal.Parse(s_Price);
                if (s_CPBZNumber=="")
                {
                    Model_Details.KPOD_CPBZNumber = 0;
                }
                else
                {
                    Model_Details.KPOD_CPBZNumber = int.Parse(s_CPBZNumber);
                }
                if (s_BZNumber=="")
                {
                    Model_Details.KPOD_BZNumber = 0;
                }
                else
                {
                    Model_Details.KPOD_BZNumber = int.Parse(s_BZNumber);
                }
                //if (s_CountWeight=="NaN")
                //{
                //    Model_Details.CountWeight = null;
                //}
                //else
                //{
                    Model_Details.KPOD_BigUnits = Units;
               // }
                
                Model_Details.KPOD_BrandName = s_BrandName;
                Model_Details.ID = s_DID;
                try
                {
                    Model_Details.HandPrice = decimal.Parse(s_HandPrice);
                }
                catch { }
                try
                {
                    Model_Details.HandTotal = Model_Details.OrderAmount * Model_Details.HandPrice;
                }
                catch { }
                if (KSP_BigUnits != "")//如果有大单位
                {
                    string c = KSP_BigUnits.Remove(KSP_BigUnits.LastIndexOf("/"));
                    Model_Details.OrderTotalNet = Math.Round(int.Parse(s_Number) / Convert.ToInt32(c) * decimal.Parse(s_Price),2);
                }
                else
                {
                    Model_Details.OrderTotalNet = Math.Round(int.Parse(s_Number) * decimal.Parse(s_Price),2);
                }
              

                //Model_Details.OrderAmount = Convert.ToInt32(s_Number);

                Model_Details.OrderRemarks = s_Remarks.ToString();
                if (s_Number != "0")
                {
                    Arr_Products.Add(Model_Details);
                }
                else
                {
                    Alert("订单数量不能为空");
                    return;
                }

            }


        }
        if (this.Tbx_ID.Text!="")
        {
            if (OrderNumCount != Convert.ToInt32(this.NumCount.Text) && this.TextBox1.Text != "")
            {
                string subject = "订单数量改变提醒";
                string body = "采购单号为" + this.OrderNo.Text.Trim() + "的订单数量已改变，原订单数总数为" + this.NumCount.Text + ",现在变为" + OrderNumCount + ",请及时更新生产入库单!!!";
                string email_list = "hyy@systech.com.cn" + "|"+ "lzh@systech.com.cn" + "|";
                string File_Path = "";
                //"zb@systech.com.cn" + "|" + "xb@systech.com.cn" + "|" + "lwl@systech.com.cn" + "|" + "hyy@systech.com.cn" + "|";
                Send(subject, body, email_list, File_Path);
            }
        }
       
        model.Arr_ProductsList = Arr_Products;


        string s_ID = this.Tbx_ID.Text;
        try
        {

            if (s_ID == "")//新增
            {

                //如果是自己下单 不是成品采购必须选收货供应商。
                if ((model.OrderType != "128860698200781250") && (model.ReceiveSuppNo == ""))
                {
                    Alert("不是成品采购请选择收货供应商！");
                }
                else
                {

                    if (BLL.Exists(OrderNo1) == false)
                    {
                        //如果是OEM转移
                        if (this.Tbx_Change.Text == "1")
                        {
                            string s_Email = "", s_SendEmail = "", s_SendSettingID = "", s_CcEmail = "", s_MsEmail = "", s_EmailPDF = "", s_EmailTitle = "", s_EmailDetails = "";
                            KNet.BLL.PB_Mail_Setting bll = new KNet.BLL.PB_Mail_Setting();
                            string s_Where = " PMS_Creator='" + AM.KNet_StaffNo + "' and PMS_Del='0' order by PMS_MTime ";
                            DataSet ds = bll.GetList(s_Where);
                            if (ds != null)
                            {
                                s_SendSettingID = ds.Tables[0].Rows[0]["PMS_ID"].ToString();
                                s_SendEmail = ds.Tables[0].Rows[0]["PMS_SendEmail"].ToString();
                            }
                            //先停用原来的订单
                            string s_Sql = "update Knet_Procure_OrdersList set KPO_Del='1' where OrderNo ='" + this.Tbx_OldID.Text + "' ";
                            DbHelperSQL.ExecuteSql(s_Sql);
                            //更新所有材料订单的状态
                            string s_Address = base.Base_GetSuppNoAddress(this.SuppNoSelectValue.Value).Replace("$", "\n");
                            s_Sql = "update Knet_Procure_OrdersList set ReceiveSuppNo='" + this.SuppNoSelectValue.Value + "',ContractAddress='" + s_Address + "',KPO_IsChange=1,KPO_IsSend=0,ParentOrderNo='" + model.OrderNo + "' where ParentOrderNo ='" + this.Tbx_OldID.Text + "' ";
                            DbHelperSQL.ExecuteSql(s_Sql);
                            AM.Add_Logs("订单更改：" + this.Tbx_OldID.Text);
                            //循环去重新生成PDF 和邮件
                            this.BeginQuery("Select * from Knet_Procure_OrdersList where ParentOrderNo='" + model.OrderNo + "'");
                            DataTable Dtb_table1 = (DataTable)this.QueryForDataTable();
                            KNet.BLL.PB_Basic_Mail Bll_Mail = new KNet.BLL.PB_Basic_Mail();
                            for (int i = 0; i < Dtb_table1.Rows.Count; i++)
                            {
                                string JSD1 = "CG/Order/Knet_Procure_OpenBilling_Print.aspx?ID=" + Dtb_table1.Rows[i]["ID"].ToString() + "";
                                string s_OrderDetailsNo = Dtb_table1.Rows[i]["OrderNo"].ToString();
                                base.HtmlToPdf1(JSD1, Server.MapPath("PDF"), s_OrderDetailsNo);

                                string s_SuppNo = Dtb_table1.Rows[i]["SuppNo"].ToString();
                                KNet.BLL.Knet_Procure_Suppliers Bll_Supp = new KNet.BLL.Knet_Procure_Suppliers();
                                KNet.Model.Knet_Procure_Suppliers Model_Supp = Bll_Supp.GetModelB(s_SuppNo);
                                if (Model_Supp != null)
                                {
                                    s_Email = Model_Supp.SuppEmail;
                                }
                                s_Sql = "select top 1 * from PB_Basic_Mail where PBM_Type=1 and PBM_State=2 and PBM_Creator='" + AM.KNet_StaffNo + "' and PBM_FID in (select OrderNo from Knet_Procure_OrdersList where SuppNo='" + s_SuppNo + "') order by PBM_MTime desc";
                                this.BeginQuery(s_Sql);
                                DataTable Dtb_Mail = (DataTable)this.QueryForDataTable();
                                if (Dtb_Mail.Rows.Count > 0)
                                {
                                    s_SendEmail = Dtb_Mail.Rows[0]["PBM_SendEmail"].ToString();
                                    s_SendSettingID = Dtb_Mail.Rows[0]["PBM_SendSettingID"].ToString();
                                    s_Email = Dtb_Mail.Rows[0]["PBM_ReceiveEmail"].ToString();
                                    s_CcEmail = Dtb_Mail.Rows[0]["PBM_Cc"].ToString();
                                    s_MsEmail = Dtb_Mail.Rows[0]["PBM_Ms"].ToString();
                                }

                                if ((s_SuppNo == "129842136364062500") || (s_SuppNo == "130383676039147477"))
                                {
                                    /*1. 余姚君超
                                        2. 南昌天佳 用126发*/
                                    s_SendEmail = "bremax@126.com";
                                }

                                s_EmailPDF = Server.MapPath("/Web/CG/Order/PDF/" + s_OrderDetailsNo + ".PDF");
                                s_EmailTitle = " 更改士腾采购单：" + s_OrderDetailsNo + " 收货供应商；详细见明细";
                                s_EmailDetails = "尊敬的 " + base.Base_GetSupplierName(s_SuppNo) + ":<br/>";
                                s_EmailDetails += "<font size=4>1)第一时间确认订单收到<br/>";
                                s_EmailDetails += "2)更改 士腾采购单：" + s_OrderDetailsNo + " 收货供应商和收货地址 请确认<br/>";
                                s_EmailDetails += "以上要求请务必严格执行！任何特殊情况请提前告知！谢谢合作！</font><br/><p></p><p></p><hr>";
                                s_EmailDetails += "" + AM.KNet_StaffName + "<br/>";
                                s_EmailDetails += "采购部<br/>";
                                s_EmailDetails += "杭州士腾科技有限公司<br/>";
                                s_EmailDetails += "手机：159 6718 4387<br/>";
                                s_EmailDetails += "电话：0571 8821 0011 -8041<br/>";
                                s_EmailDetails += "E-mail: fanghy@bremax.com<br/>";
                                s_EmailDetails += "地址：杭州市西湖区黄姑山路4号1号楼<br/>";

                                ArrayList arr_Mail = new ArrayList();
                                KNet.Model.PB_Basic_Mail model_Mail = new KNet.Model.PB_Basic_Mail();
                                model_Mail.PBM_ID = GetMainID(i);
                                model_Mail.PBM_Code = base.GetNewID("PBM_Code", 1);
                                model_Mail.PBM_SendEmail = s_SendEmail;
                                model_Mail.PBM_SendSettingID = s_SendSettingID;
                                try
                                {
                                    KNet.BLL.PB_Mail_Setting bll_Setting = new KNet.BLL.PB_Mail_Setting();
                                    KNet.Model.PB_Mail_Setting Model_Setting = bll_Setting.GetModel(s_SendEmail);
                                    model_Mail.PBM_SendEmail = Model_Setting.PMS_SendEmail;
                                }
                                catch
                                {
                                }
                                model_Mail.PBM_ReceiveEmail = s_Email;
                                model_Mail.PBM_Text = KNetPage.KHtmlEncode(s_EmailDetails);
                                model_Mail.PBM_File = KNetPage.KHtmlEncode(s_EmailPDF);

                                model_Mail.PBM_Title = s_EmailTitle;
                                model_Mail.PBM_Creator = AM.KNet_StaffNo;
                                model_Mail.PBM_CTime = DateTime.Now;
                                model_Mail.PBM_Mender = AM.KNet_StaffNo;
                                model_Mail.PBM_MTime = DateTime.Now;

                                model_Mail.PBM_Cc = s_CcEmail;
                                model_Mail.PBM_Ms = s_MsEmail;
                                model_Mail.PBM_FID = s_OrderDetailsNo;
                                model_Mail.PBM_Type = 1;
                                model_Mail.PBM_SendType = 1;
                                model_Mail.PBM_Minute = 10 * 60;//10分钟后

                                Bll_Mail.Add(model_Mail);
                            }
                        }
                        BLL.Add(model);
                        AdminloginMess LogAM = new AdminloginMess();
                        LogAM.Add_Logs("采购入库--->采购开单--->开单 添加 操作成功！采购单号：" + OrderNo1);
                        string JSD = "";
                        if (OrderType.SelectedValue== "128860698200781250")//如果是生产订单
                        {
                             JSD = "CG/Order/Knet_Procure_OpenBilling_Print.aspx?ID=" + model.ID + "&Type=SC";
                        }
                        else
                        {
                             JSD = "CG/Order/Knet_Procure_OpenBilling_Print.aspx?ID=" + model.ID + "&Type=CG";
                        }
                       
                        base.HtmlToPdf1(JSD, Server.MapPath("PDF"), OrderNo1);
                       
                        if (OrderType.SelectedValue == "128860698200781250")//如果是生产订单
                        {
                            AlertAndRedirect("采购开单 添加  操作成功", "Knet_Procure_OpenBilling_Manage_ForSc.aspx?SalesOrderNo=" + this.SalesOrderNoSelectValue.Value + "");

                        }
                        else
                        {
                            AlertAndRedirect("采购开单 添加  操作成功", "Knet_Procure_OpenBilling_Manage.aspx?SalesOrderNo=" + this.SalesOrderNoSelectValue.Value + "");

                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('采购单号已存在 添加失败！');history.back(-1);</script>");
                        Response.End();
                    }
                }
            }
            if (s_ID!=""&& Tbx_Type.Text!="")
            {
                //如果是自己下单 不是成品采购必须选收货供应商。
                if ((model.OrderType != "128860698200781250") && (model.ReceiveSuppNo == ""))
                {
                    Alert("不是成品采购请选择收货供应商！");
                }
                else
                {

                    if (BLL.Exists(OrderNo1) == false)
                    {
                        //如果是OEM转移
                        if (this.Tbx_Change.Text == "1")
                        {
                            string s_Email = "", s_SendEmail = "", s_SendSettingID = "", s_CcEmail = "", s_MsEmail = "", s_EmailPDF = "", s_EmailTitle = "", s_EmailDetails = "";
                            KNet.BLL.PB_Mail_Setting bll = new KNet.BLL.PB_Mail_Setting();
                            string s_Where = " PMS_Creator='" + AM.KNet_StaffNo + "' and PMS_Del='0' order by PMS_MTime ";
                            DataSet ds = bll.GetList(s_Where);
                            if (ds != null)
                            {
                                s_SendSettingID = ds.Tables[0].Rows[0]["PMS_ID"].ToString();
                                s_SendEmail = ds.Tables[0].Rows[0]["PMS_SendEmail"].ToString();
                            }
                            //先停用原来的订单
                            string s_Sql = "update Knet_Procure_OrdersList set KPO_Del='1' where OrderNo ='" + this.Tbx_OldID.Text + "' ";
                            DbHelperSQL.ExecuteSql(s_Sql);
                            //更新所有材料订单的状态
                            string s_Address = base.Base_GetSuppNoAddress(this.SuppNoSelectValue.Value).Replace("$", "\n");
                            s_Sql = "update Knet_Procure_OrdersList set ReceiveSuppNo='" + this.SuppNoSelectValue.Value + "',ContractAddress='" + s_Address + "',KPO_IsChange=1,KPO_IsSend=0,ParentOrderNo='" + model.OrderNo + "' where ParentOrderNo ='" + this.Tbx_OldID.Text + "' ";
                            DbHelperSQL.ExecuteSql(s_Sql);
                            AM.Add_Logs("订单更改：" + this.Tbx_OldID.Text);
                            //循环去重新生成PDF 和邮件
                            this.BeginQuery("Select * from Knet_Procure_OrdersList where ParentOrderNo='" + model.OrderNo + "'");
                            DataTable Dtb_table1 = (DataTable)this.QueryForDataTable();
                            KNet.BLL.PB_Basic_Mail Bll_Mail = new KNet.BLL.PB_Basic_Mail();
                            for (int i = 0; i < Dtb_table1.Rows.Count; i++)
                            {

                                string JSD1 = "CG/Order/Knet_Procure_OpenBilling_Print.aspx?ID=" + Dtb_table1.Rows[i]["ID"].ToString() + "";
                                string s_OrderDetailsNo = Dtb_table1.Rows[i]["OrderNo"].ToString();
                                base.HtmlToPdf1(JSD1, Server.MapPath("PDF"), s_OrderDetailsNo);

                                string s_SuppNo = Dtb_table1.Rows[i]["SuppNo"].ToString();
                                KNet.BLL.Knet_Procure_Suppliers Bll_Supp = new KNet.BLL.Knet_Procure_Suppliers();
                                KNet.Model.Knet_Procure_Suppliers Model_Supp = Bll_Supp.GetModelB(s_SuppNo);
                                if (Model_Supp != null)
                                {
                                    s_Email = Model_Supp.SuppEmail;
                                }
                                s_Sql = "select top 1 * from PB_Basic_Mail where PBM_Type=1 and PBM_State=2 and PBM_Creator='" + AM.KNet_StaffNo + "' and PBM_FID in (select OrderNo from Knet_Procure_OrdersList where SuppNo='" + s_SuppNo + "') order by PBM_MTime desc";
                                this.BeginQuery(s_Sql);
                                DataTable Dtb_Mail = (DataTable)this.QueryForDataTable();
                                if (Dtb_Mail.Rows.Count > 0)
                                {
                                    s_SendEmail = Dtb_Mail.Rows[0]["PBM_SendEmail"].ToString();
                                    s_SendSettingID = Dtb_Mail.Rows[0]["PBM_SendSettingID"].ToString();
                                    s_Email = Dtb_Mail.Rows[0]["PBM_ReceiveEmail"].ToString();
                                    s_CcEmail = Dtb_Mail.Rows[0]["PBM_Cc"].ToString();
                                    s_MsEmail = Dtb_Mail.Rows[0]["PBM_Ms"].ToString();
                                }

                                if ((s_SuppNo == "129842136364062500") || (s_SuppNo == "130383676039147477"))
                                {
                                    /*1. 余姚君超
                                        2. 南昌天佳 用126发*/
                                    s_SendEmail = "bremax@126.com";
                                }

                                s_EmailPDF = Server.MapPath("/Web/CG/Order/PDF/" + s_OrderDetailsNo + ".PDF");
                                s_EmailTitle = " 更改士腾采购单：" + s_OrderDetailsNo + " 收货供应商；详细见明细";
                                s_EmailDetails = "尊敬的 " + base.Base_GetSupplierName(s_SuppNo) + ":<br/>";
                                s_EmailDetails += "<font size=4>1)第一时间确认订单收到<br/>";
                                s_EmailDetails += "2)更改 士腾采购单：" + s_OrderDetailsNo + " 收货供应商和收货地址 请确认<br/>";
                                s_EmailDetails += "以上要求请务必严格执行！任何特殊情况请提前告知！谢谢合作！</font><br/><p></p><p></p><hr>";
                                s_EmailDetails += "" + AM.KNet_StaffName + "<br/>";
                                s_EmailDetails += "采购部<br/>";
                                s_EmailDetails += "杭州士腾科技有限公司<br/>";
                                s_EmailDetails += "手机：159 6718 4387<br/>";
                                s_EmailDetails += "电话：0571 8821 0011 -8041<br/>";
                                s_EmailDetails += "E-mail: fanghy@bremax.com<br/>";
                                s_EmailDetails += "地址：杭州市西湖区黄姑山路4号1号楼<br/>";

                                ArrayList arr_Mail = new ArrayList();
                                KNet.Model.PB_Basic_Mail model_Mail = new KNet.Model.PB_Basic_Mail();
                                model_Mail.PBM_ID = GetMainID(i);
                                model_Mail.PBM_Code = base.GetNewID("PBM_Code", 1);
                                model_Mail.PBM_SendEmail = s_SendEmail;
                                model_Mail.PBM_SendSettingID = s_SendSettingID;
                                try
                                {
                                    KNet.BLL.PB_Mail_Setting bll_Setting = new KNet.BLL.PB_Mail_Setting();
                                    KNet.Model.PB_Mail_Setting Model_Setting = bll_Setting.GetModel(s_SendEmail);
                                    model_Mail.PBM_SendEmail = Model_Setting.PMS_SendEmail;
                                }
                                catch
                                {
                                }
                                model_Mail.PBM_ReceiveEmail = s_Email;
                                model_Mail.PBM_Text = KNetPage.KHtmlEncode(s_EmailDetails);
                                model_Mail.PBM_File = KNetPage.KHtmlEncode(s_EmailPDF);

                                model_Mail.PBM_Title = s_EmailTitle;
                                model_Mail.PBM_Creator = AM.KNet_StaffNo;
                                model_Mail.PBM_CTime = DateTime.Now;
                                model_Mail.PBM_Mender = AM.KNet_StaffNo;
                                model_Mail.PBM_MTime = DateTime.Now;

                                model_Mail.PBM_Cc = s_CcEmail;
                                model_Mail.PBM_Ms = s_MsEmail;
                                model_Mail.PBM_FID = s_OrderDetailsNo;
                                model_Mail.PBM_Type = 1;
                                model_Mail.PBM_SendType = 1;
                                model_Mail.PBM_Minute = 10 * 60;//10分钟后

                                Bll_Mail.Add(model_Mail);
                            }
                        }
                        BLL.Add(model);
                        AdminloginMess LogAM = new AdminloginMess();
                        LogAM.Add_Logs("采购入库--->采购开单--->开单 添加 操作成功！采购单号：" + OrderNo1);
                        string JSD = "";
                        if (OrderType.SelectedValue == "128860698200781250")//如果是生产订单
                        {
                            JSD = "CG/Order/Knet_Procure_OpenBilling_Print.aspx?ID=" + model.ID + "&Type=SC";
                        }
                        else
                        {
                            JSD = "CG/Order/Knet_Procure_OpenBilling_Print.aspx?ID=" + model.ID + "&Type=CG";
                        }
                        //string JSD = "CG/Order/Knet_Procure_OpenBilling_Print.aspx?ID=" + model.ID + "";
                        base.HtmlToPdf1(JSD, Server.MapPath("PDF"), OrderNo1);
                        //发给研发中心经理
                        // base.Base_SendMessage(Base_GetDeptPerson("研发中心", 1), KNetPage.KHtmlEncode("有 采购订单 <a href='Web/Order/Knet_Procure_OpenBilling_View.aspx?ID=" + OrderNo1 + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + OrderNo1 + "</a> 需要您作为负责人选择审批流程，敬请关注！"));
                        //base.Base_SendMessage(Base_GetDeptPerson("供应链平台", 1), KNetPage.KHtmlEncode("有 采购订单 <a href='Web/Order/Knet_Procure_OpenBilling_View.aspx?ID=" + OrderNo1 + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + OrderNo1 + "</a> 需要您作为负责人选择审批流程，敬请关注！"));
                        if (OrderType.SelectedValue == "128860698200781250")//如果是生产订单
                        {
                            AlertAndRedirect("采购开单 添加  操作成功", "Knet_Procure_OpenBilling_Manage_ForSc.aspx?SalesOrderNo=" + this.SalesOrderNoSelectValue.Value + "");

                        }
                        else
                        {
                            AlertAndRedirect("采购开单 添加  操作成功", "Knet_Procure_OpenBilling_Manage.aspx?SalesOrderNo=" + this.SalesOrderNoSelectValue.Value + "");

                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('采购单号已存在 添加失败！');history.back(-1);</script>");
                        Response.End();
                    }
                }
            }
            else
            {
                model.ID = this.Tbx_ID.Text;
                BLL.Update(model);
                string JSD = "";
                if (OrderType.SelectedValue == "128860698200781250")//如果是生产订单
                {
                    JSD = "CG/Order/Knet_Procure_OpenBilling_Print.aspx?ID=" + model.ID + "&Type=SC";
                }
                else
                {
                    JSD = "CG/Order/Knet_Procure_OpenBilling_Print.aspx?ID=" + model.ID + "&Type=CG";
                }
                //string JSD = "CG/Order/Knet_Procure_OpenBilling_Print.aspx?ID=" + model.ID + "";
                base.HtmlToPdf1(JSD, Server.MapPath("PDF"), OrderNo1);
                AdminloginMess LogAM = new AdminloginMess();
                LogAM.Add_Logs("采购入库--->采购开单--->开单 修改 操作成功！采购单号：" + OrderNo1);

                if ((AM.KNet_StaffDepart == "131161769392290242") || (AM.KNet_StaffName == "薛建新"))//如果是生产部
                {
                    AlertAndRedirect("采购开单 修改  操作成功", "Knet_Procure_OpenBilling_Manage_ForSc.aspx?SalesOrderNo=" + this.SalesOrderNoSelectValue.Value + "");

                }
                else
                {
                    AlertAndRedirect("采购开单 修改  操作成功", "Knet_Procure_OpenBilling_Manage.aspx?SalesOrderNo=" + this.SalesOrderNoSelectValue.Value + "");

                }
            }

        }
        catch (Exception ex)
        {
            throw ex;
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
                s_ScDetails += Dtb_Table.Rows[i]["XCF_Details"].ToString() + "\n";
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
    public string KNetOddNumbers(string s_SuppNo, string s_Title, string s_OrderNo)
    {
        if (s_Title == "修改采购订单")
        {
            return s_OrderNo;
        }
        else
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

    #region 订单数量改变，以邮件的形式发给仓库
    public static void Send(string subject, string body, string email_list, string File_Path)
    {
        string MailUser = "xjx@systech.com.cn";//我测试的是qq邮箱，其他邮箱一样的道理
        string MailPwd = "systech#88888888";//邮箱密码
        string MailName = "ERP系统";
        string MailHost = "smtp.mxhichina.com";//根据自己选择的邮箱来查询smtp的地址

        MailAddress from = new MailAddress(MailUser, MailName); //邮件的发件人  
        MailMessage mail = new MailMessage();

        //设置邮件的标题  
        mail.Subject = subject;

        //设置邮件的发件人  
        //Pass:如果不想显示自己的邮箱地址，这里可以填符合mail格式的任意名称，真正发mail的用户不在这里设定，这个仅仅只做显示用  
        mail.From = from;

        //设置邮件的收件人  
        string address = "";

        //传入多个邮箱，用“|”分割开，可以自己自定义，再通过mail.To.Add（）添加到列表
        string[] email = email_list.Split('|');
        foreach (string name in email)
        {
            if (name != string.Empty)
            {
                address = name;
                mail.To.Add(new MailAddress(address));
            }
        }

        //设置邮件的抄送收件人  
        //这个就简单多了，如果不想快点下岗重要文件还是CC一份给领导比较好  
        //mail.CC.Add(new MailAddress("Manage@hotmail.com", "尊敬的领导");  

        //设置邮件的内容  
        mail.Body = body;
        //设置邮件的格式  
        mail.BodyEncoding = System.Text.Encoding.UTF8;
        mail.IsBodyHtml = true;
        //设置邮件的发送级别  
        mail.Priority = MailPriority.Normal;

        //设置邮件的附件，将在客户端选择的附件先上传到服务器保存一个，然后加入到mail中  
        if (File_Path != "")
        {
            mail.Attachments.Add(new Attachment(File_Path));
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
        }
        SmtpClient client = new SmtpClient();
        //设置用于 SMTP 事务的主机的名称，填IP地址也可以了  
        client.Host = MailHost;
        //设置用于 SMTP 事务的端口，默认的是 25  
        client.Port = 587;
        client.UseDefaultCredentials = false;
        //这里才是真正的邮箱登陆名和密码， 我的用户名为 MailUser ，我的密码是 MailPwd  
        client.Credentials = new System.Net.NetworkCredential(MailUser, MailPwd);
        client.DeliveryMethod = SmtpDeliveryMethod.Network;

        ////如果发送失败，SMTP 服务器将发送 失败邮件告诉我  
        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

        //都定义完了，正式发送了，很是简单吧！  
        client.Send(mail);

    }
    #endregion
}
