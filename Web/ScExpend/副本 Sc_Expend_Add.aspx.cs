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
/// 采购管理-----采购单 管理
/// </summary>
public partial class Sc_Expend_Add : BasePage
{
    public string s_DivStyle = "";
    public string s_AdvShow = "";
    public string s_TotalPrice = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin() == false)
            {
                BasePage.AlertAndRedirect("您未登陆系统或已超过，请重新登陆系统!", "Default.aspx");
            }
            else
            {
                base.Base_DropDutyPerson(this.Ddl_Batch);
                this.Ddl_Batch.SelectedValue = "";
                string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
                string s_OrderNo = Request.QueryString["OrderNo"] == null ? "" : Request.QueryString["OrderNo"].ToString();

                this.Tbx_Order.Text = s_OrderNo;
                if (this.Tbx_Order.Text != "")
                {

                    KNet.BLL.Knet_Procure_OrdersList Bll_order = new KNet.BLL.Knet_Procure_OrdersList();
                    KNet.Model.Knet_Procure_OrdersList Model_order = Bll_order.GetModelB(s_OrderNo);
                    if (Model_order != null)
                    {
                        this.SuppNoSelectValue.Value = Model_order.SuppNo;
                        this.SuppNo.Text = base.Base_GetSupplierName(Model_order.SuppNo);
                    }
                    this.DataShows();
                }
                if (s_ID != "")
                {
                    this.Tbx_ID.Text = s_ID;
                    this.Tbx_Code.Text = s_ID;
                }
                else
                {
                    this.Tbx_Code.Text = base.GetNewID("Sc_Expend_Manage", 0);
                    this.Tbx_Stime.Text = DateTime.Now.ToShortDateString();
                }
                string s_DID = Request.QueryString["DID"] == null ? "" : Request.QueryString["DID"].ToString();
                if (s_DID != "")
                {
                    this.DID.Text = s_DID;

                    try
                    {
                        KNet.BLL.Knet_Procure_OrdersList_Details BLL_Details = new KNet.BLL.Knet_Procure_OrdersList_Details();
                        KNet.Model.Knet_Procure_OrdersList_Details Model_Details = BLL_Details.GetModel(s_DID);
                        KNet.BLL.Knet_Procure_OrdersList BLL = new KNet.BLL.Knet_Procure_OrdersList();
                        KNet.Model.Knet_Procure_OrdersList Model = BLL.GetModelB(Model_Details.OrderNo);
                        this.SuppNoSelectValue.Value = Model.SuppNo;
                        this.SuppNo.Text = base.Base_GetSupplierName(Model.SuppNo);
                    }
                    catch
                    { }
                    this.DataShows();

                }

            }
        }

    }



    private bool SetValue(KNet.Model.Sc_Expend_Manage model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text != "")
            {
                model.SEM_ID = this.Tbx_ID.Text;
            }
            else
            {
                model.SEM_ID = base.GetNewID("Sc_Expend_Manage", 1);
            }
            try
            {
                model.SEM_Stime = DateTime.Parse(this.Tbx_Stime.Text);
            }
            catch { }
            model.SEM_SuppNo = this.SuppNoSelectValue.Value;
            model.SEM_CustomerName = this.Tbx_Customer.Text;
            model.SEM_DutyPerson = this.Ddl_Batch.SelectedValue;
            model.SEM_ProductsEdition = this.SeachKey.Text;
            try
            {
                model.SEM_RkTime = DateTime.Parse(this.Tbx_Stime.Text);
            }
            catch { }
            try
            {
                model.SEM_WwTime = DateTime.Parse(this.Tbx_Stime.Text);
            }
            catch { }
            model.SEM_RkPerson = AM.KNet_StaffNo;
            model.SEM_WwPerson = AM.KNet_StaffNo;
            model.SEM_Remarks = this.Tbx_Remark.Text;
            model.SEM_Creator = AM.KNet_StaffNo;
            model.SEM_CTime = DateTime.Now;
            model.SEM_Mendor = AM.KNet_StaffNo;
            model.SEM_MTime = DateTime.Now;

            ///遥控器消耗
            ArrayList arr_RcDetails = new ArrayList();
            int i_Num = 0;
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                KNet.Model.Sc_Expend_Manage_RCDetails Mode_RkDetails = new KNet.Model.Sc_Expend_Manage_RCDetails();
                Mode_RkDetails.SER_ID = base.GetNewID("Sc_Expend_Manage_RCDetails", 1);
                TextBox Tbx_ProductsBarCode = (TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_ProductsBarCode");
                DropDownList Ddl_House = (DropDownList)GridView1.Rows[i].Cells[0].FindControl("Ddl_House");
                TextBox Tbx_DID = (TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_DID");
                TextBox Tbx_number = (TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_number");
                decimal d_Price = decimal.Parse(GridView1.Rows[i].Cells[8].Text);
                decimal d_HandPrice = decimal.Parse(GridView1.Rows[i].Cells[9].Text);

                CheckBox Chk_Chbk = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
                if (Chk_Chbk.Checked)
                {

                    Mode_RkDetails.SER_ProductsBarCode = Tbx_ProductsBarCode.Text;
                    Mode_RkDetails.SER_OrderDetailID = Tbx_DID.Text;
                    Mode_RkDetails.SER_ScNumber = int.Parse(Tbx_number.Text);
                    Mode_RkDetails.SER_ScPrice = d_Price;
                    Mode_RkDetails.SER_ScHandPrice = d_HandPrice;
                    Mode_RkDetails.SER_ScMoney = d_Price * int.Parse(Tbx_number.Text);
                    Mode_RkDetails.SER_ScHandMoney = d_HandPrice * int.Parse(Tbx_number.Text);
                    Mode_RkDetails.SER_SEMID = model.SEM_ID;
                    Mode_RkDetails.SER_HouseNo = Ddl_House.SelectedValue;
                    arr_RcDetails.Add(Mode_RkDetails);
                    i_Num++;
                }
            }
            model.arr_Details = arr_RcDetails;
            if (i_Num > 1)
            {
                Alert("请指定一个遥控器生产！");
                return false;
            }

            ///物料消耗
            ArrayList arr_MaterDetails = new ArrayList();
            for (int i = 0; i < this.MyGridView2.Rows.Count; i++)
            {
                //原材料入库
                //DropDownList Ddl_RkHouse = (DropDownList)MyGridView2.Rows[i].Cells[0].FindControl("Ddl_RkHouse");
                DropDownList Ddl_House = (DropDownList)MyGridView2.Rows[i].Cells[0].FindControl("Ddl_House");
                TextBox Tbx_ProductsBarCode = (TextBox)MyGridView2.Rows[i].Cells[0].FindControl("Tbx_ProductsBarCode");
                TextBox Tbx_Remarks = (TextBox)MyGridView2.Rows[i].Cells[0].FindControl("Tbx_Remarks");
                TextBox Tbx_Number = (TextBox)MyGridView2.Rows[i].Cells[0].FindControl("Tbx_Number");
                string SED_RkPrice = MyGridView2.Rows[i].Cells[8].Text;
                KNet.Model.Sc_Expend_Manage_MaterDetails Mode_MaterDetails = new KNet.Model.Sc_Expend_Manage_MaterDetails();

                CheckBox Chk_Chbk = (CheckBox)MyGridView2.Rows[i].Cells[0].FindControl("Chbk");
                if (Chk_Chbk.Checked)
                {
                    Mode_MaterDetails.SED_SEMID = model.SEM_ID;
                    Mode_MaterDetails.SED_HouseNo ="";
                    Mode_MaterDetails.SED_ProductsBarCode = Tbx_ProductsBarCode.Text;
                    Mode_MaterDetails.SED_Remarks = Tbx_Remarks.Text;
                    try
                    {
                        Mode_MaterDetails.SED_RkNumber = int.Parse(Tbx_Number.Text);
                    }
                    catch { }
                    try
                    {
                        Mode_MaterDetails.SED_RkPrice = decimal.Parse(SED_RkPrice);
                    }
                    catch { }
                    try
                    {
                        Mode_MaterDetails.SED_RkMoney = decimal.Parse(SED_RkPrice) * int.Parse(Tbx_Number.Text);
                    }
                    catch { }
                    Mode_MaterDetails.SED_RkPerson = AM.KNet_StaffNo;
                    try
                    {
                        Mode_MaterDetails.SED_RkTime = DateTime.Parse(this.Tbx_Stime.Text);
                    }
                    catch { }
                    Mode_MaterDetails.SED_Type = 0;
                    arr_MaterDetails.Add(Mode_MaterDetails);
                    //委外发料
                    KNet.Model.Sc_Expend_Manage_MaterDetails Mode_MaterDetails1 = new KNet.Model.Sc_Expend_Manage_MaterDetails();
                    Mode_MaterDetails1.SED_SEMID = model.SEM_ID;
                    Mode_MaterDetails1.SED_HouseNo = Ddl_House.SelectedValue;
                    Mode_MaterDetails1.SED_ProductsBarCode = Tbx_ProductsBarCode.Text;
                    Mode_MaterDetails1.SED_Remarks = Tbx_Remarks.Text;
                    try
                    {
                        Mode_MaterDetails1.SED_RkNumber = int.Parse(Tbx_Number.Text);
                    }
                    catch { }
                    try
                    {
                        Mode_MaterDetails1.SED_RkPrice = decimal.Parse(SED_RkPrice);
                    }
                    catch { }
                    try
                    {
                        Mode_MaterDetails1.SED_RkMoney = decimal.Parse(SED_RkPrice) * int.Parse(Tbx_Number.Text);
                    }
                    catch { }
                    Mode_MaterDetails1.SED_RkPerson = AM.KNet_StaffNo;
                    try
                    {
                        Mode_MaterDetails1.SED_RkTime = DateTime.Parse(this.Tbx_Stime.Text);
                    }
                    catch { }
                    Mode_MaterDetails1.SED_Type = 1;
                    arr_MaterDetails.Add(Mode_MaterDetails1);

                    //生产入库
                    KNet.Model.Sc_Expend_Manage_MaterDetails Mode_MaterDetails2 = new KNet.Model.Sc_Expend_Manage_MaterDetails();
                    Mode_MaterDetails2.SED_SEMID = model.SEM_ID;
                    Mode_MaterDetails2.SED_HouseNo = Ddl_House.SelectedValue;
                    Mode_MaterDetails2.SED_ProductsBarCode = Tbx_ProductsBarCode.Text;
                    Mode_MaterDetails2.SED_Remarks = Tbx_Remarks.Text;
                    try
                    {
                        Mode_MaterDetails2.SED_RkNumber = int.Parse(Tbx_Number.Text);
                    }
                    catch { }
                    try
                    {
                        Mode_MaterDetails2.SED_RkPrice = decimal.Parse(SED_RkPrice);
                    }
                    catch { }
                    try
                    {
                        Mode_MaterDetails2.SED_RkMoney = decimal.Parse(SED_RkPrice) * int.Parse(Tbx_Number.Text);
                    }
                    catch { }
                    Mode_MaterDetails2.SED_RkPerson = AM.KNet_StaffNo;
                    try
                    {
                        Mode_MaterDetails2.SED_RkTime = DateTime.Parse(this.Tbx_Stime.Text);
                    }
                    catch { }
                    Mode_MaterDetails2.SED_Type = 2;
                    arr_MaterDetails.Add(Mode_MaterDetails2);
                }
            }
            model.arr_MaterDetails = arr_MaterDetails;

            return true;
        }
        catch
        {
            return false;
        }
    }


    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        string s_Sql = "Select b.ID as DID,a.*,b.*,c.CustomerValue,c.DutyPerson from Knet_Procure_OrdersList a left join View_Procure_OrdersList_Details b on a.OrderNo=b.OrderNo left join Knet_Sales_ContractList c on c.ContractNo=a.ContractNo ";
        s_Sql += " where OrderType='128860698200781250' and Isnull(KPO_RKState,'1')=0 ";
        if (this.SuppNoSelectValue.Value != "")
        {
            s_Sql += " and a.SuppNo='" + this.SuppNoSelectValue.Value + "' ";
        }
        if (this.Tbx_Customer.Text != "")
        {

            s_Sql += " and c.CustomerValue in (Select CustomerValue From KNet_Sales_ClientList where CustomerName Like '%" + Tbx_Customer.Text + "%') ";
        }
        if (this.SeachKey.Text != "")
        {
            s_Sql += " and b.ProductsBarCode in (Select ProductsBarCode From KNet_Sys_Products where ProductsEdition Like '%" + SeachKey.Text + "%' or ProductsName like '%" + SeachKey.Text + "%')";

        }
        if (this.DID.Text != "")
        {
            s_Sql += " and b.ID='" + this.DID.Text + "' ";
        }
        if (this.Tbx_Order.Text != "")
        {
            s_Sql += " and a.OrderNo='" + this.Tbx_Order.Text + "'";
        }
        s_Sql += " order by OrderDateTime ";
        this.BeginQuery(s_Sql);
        this.QueryForDataSet();
        DataSet ds = Dts_Result;

        GridView1.DataSource = ds.Tables[0];
        GridView1.DataKeyNames = new string[] { "OrderNo" };
        GridView1.DataBind();

        //物料计划
        string s_DSql = "Select distinct a.XPP_ProductsBarCode as ProductsBarCode,XPP_Price,XPP_SuppNo,XPP_Number,b.ProductsType from Xs_Products_Prodocts a  join KNet_Sys_Products b on a.XPP_ProductsBarCode=b.ProductsBarCode ";
        s_DSql += " Where a.XPP_FaterBarCode in (Select b.ProductsBarCode from  Knet_Procure_OrdersList a left join View_Procure_OrdersList_Details b on a.OrderNo=b.OrderNo left join Knet_Sales_ContractList c on c.ContractNo=a.ContractNo ";
        s_DSql += " where OrderType='128860698200781250' and Isnull(KPO_RKState,'1')=0 ";
        if (this.SuppNoSelectValue.Value != "")
        {
            s_DSql += " and a.SuppNo='" + this.SuppNoSelectValue.Value + "' ";
        }

        if (this.Tbx_Order.Text != "")
        {
            s_DSql += " and a.OrderNo='" + this.Tbx_Order.Text + "'";
        }
        if (this.Tbx_Customer.Text != "")
        {
            s_DSql += " and c.CustomerValue in (Select CustomerValue From KNet_Sales_ClientList where CustomerName Like '%" + Tbx_Customer.Text + "%') ";
        }
        if (this.SeachKey.Text != "")
        {
            s_DSql += " and b.ProductsBarCode in (Select ProductsBarCode From KNet_Sys_Products where ProductsEdition Like '%" + SeachKey.Text + "%' or ProductsName like '%" + SeachKey.Text + "%')";
        }
        if (this.DID.Text != "")
        {
            s_DSql += " and b.ID='" + this.DID.Text + "' ";
        }
        s_DSql += " ) ";
        s_DSql += " order by b.ProductsType ";
        this.BeginQuery(s_DSql);
        this.QueryForDataSet();
        DataSet ds1 = Dts_Result;

        this.MyGridView2.DataSource = ds1.Tables[0];
        MyGridView2.DataBind();

    }

    protected void Btn_SaveOnClick(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        string s_ID = this.Tbx_ID.Text;

        KNet.Model.Sc_Expend_Manage model = new KNet.Model.Sc_Expend_Manage();
        KNet.BLL.Sc_Expend_Manage bll = new KNet.BLL.Sc_Expend_Manage();

        if (this.SetValue(model) == false)
        {
            Alert("系统错误！");
            return;
        }
        if (s_ID == "")//新增
        {
            try
            {
                bll.Add(model);
                AM.Add_Logs("生产入库增加" + this.Tbx_ID.Text);
                
                //base.Base_SendMessage(base.Base_GetDeptPerson("供应链平台", 1), "生产入库增加： <a href='Web/ScExpend/Sc_Expend_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.SEM_ID + "</a> 需要你审批！ ");
                AlertAndRedirect("新增成功！", "Sc_Expend_Manage.aspx");
            }
            catch(Exception ex) {
                Alert(ex.Message);
            }
        }
        else
        {
            try
            {
                bll.Update(model);
                AM.Add_Logs("生产入库修改" + this.Tbx_ID.Text);
               // base.Base_SendMessage(base.Base_GetDeptPerson("供应链平台", 1), "生产入库修改： <a href='Web/ScExpend/Sc_Expend_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.SEM_ID + "</a> 需要你审批！ ");

                AlertAndRedirect("修改成功！", "Sc_Expend_Manage.aspx");
            }
            catch { }
        }
    }

    public string GetDate(string s_OrderDID, int i_type)
    {
        string s_Return = "";
        try
        {
            this.BeginQuery("Select top 1 * From Sc_Produce_Plan_Details join SC_Produce_Plan on SPD_FaterID=SPP_ID where SPD_OrderNo='" + s_OrderDID + "' order by SPP_CTime desc ");
            this.QueryForDataTable();
            if (this.Dtb_Result.Rows.Count > 0)
            {
                if (i_type == 0)
                {
                    s_Return = DateTime.Parse(Dtb_Result.Rows[0]["SPD_BeginTime"].ToString()).ToShortDateString();
                }
                else if (i_type == 1)
                {
                    s_Return = DateTime.Parse(Dtb_Result.Rows[0]["SPD_EndTime"].ToString()).ToShortDateString();
                }
            }
        }
        catch (Exception ex)
        { }
        return s_Return;

    }
    public string GetSCDate(string s_OrderDID)
    {
        string s_Return = "";
        try
        {
            DateTime d_BeginDate = DateTime.Parse(GetDate(s_OrderDID, 0));
            DateTime d_EndDate = DateTime.Parse(GetDate(s_OrderDID, 0));

            s_Return = d_BeginDate.ToShortDateString() + " - " + d_EndDate.ToShortDateString();
        }
        catch (Exception ex)
        { }
        return s_Return;
    }

    public string GetFaterProducts(string s_ProductsBarCode)
    {
        string s_Return = "";
        try
        {
            string s_DSql = "Select a.XPP_FaterBarCode from Xs_Products_Prodocts a ";
            s_DSql += " Where a.XPP_FaterBarCode in (Select b.ProductsBarCode from  Knet_Procure_OrdersList a left join View_Procure_OrdersList_Details b on a.OrderNo=b.OrderNo left join Knet_Sales_ContractList c on c.ContractNo=a.ContractNo ";
            s_DSql += " where OrderType='128860698200781250' and Isnull(KPO_RKState,'1')=0 ";
            if (this.SuppNoSelectValue.Value != "")
            {
                s_DSql += " and a.SuppNo='" + this.SuppNoSelectValue.Value + "' ";
            }

            if (this.Tbx_Customer.Text != "")
            {
                s_DSql += " and c.CustomerValue in (Select CustomerValue From KNet_Sales_ClientList where CustomerName Like '%" + Tbx_Customer.Text + "%') ";
            }
            if (this.SeachKey.Text != "")
            {
                s_DSql += " and b.ProductsBarCode in (Select ProductsBarCode From KNet_Sys_Products where ProductsEdition Like '%" + SeachKey.Text + "%' or ProductsName like '%" + SeachKey.Text + "%')";

            }
            s_DSql += " ) and XPP_ProductsBarCode='" + s_ProductsBarCode + "' ";
            this.BeginQuery(s_DSql);
            this.QueryForDataSet();
            DataSet Dts_Table = Dts_Result;
            if (Dts_Table.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                {
                    s_Return += base.Base_GetProductsEdition(Dts_Table.Tables[0].Rows[i]["XPP_FaterBarCode"].ToString()) + ",";
                }
                if (s_Return != "")
                {
                    s_Return = s_Return.Substring(0, s_Return.Length - 1);
                }
            }

        }
        catch (Exception ex)
        { }
        return s_Return;
    }


    public string GetSCDateState(string s_OrderDID)
    {
        string s_Return = "";
        try
        {
            //KNet.BLL.Knet_Procure_OrdersList_Details Bll_Details = new KNet.BLL.Knet_Procure_OrdersList_Details();
            //KNet.Model.Knet_Procure_OrdersList_Details Model_Details = Bll_Details.GetModel(s_OrderDID);
            //KNet.BLL.Knet_Procure_OrdersList Bll = new KNet.BLL.Knet_Procure_OrdersList();
            //KNet.Model.Knet_Procure_OrdersList Model = Bll.GetModelB(Model_Details.OrderNo);
            //string s_RkState = Model.KPO_RkState == null ? "0" : Model.KPO_RkState;
            DateTime d_BeginDate = DateTime.Parse(GetDate(s_OrderDID, 0));
            DateTime d_EndDate = DateTime.Parse(GetDate(s_OrderDID, 0));
            DateTime d_Now = DateTime.Parse(DateTime.Now.ToShortDateString());
            if (d_Now > d_EndDate)
            {
                s_Return = "<Font Color=red>已生产</Font>";
            }
            else if (d_Now == d_EndDate)
            {
                s_Return = "<Font Color=blue>今天完成</Font>";
            }
            else if (d_Now == d_BeginDate)
            {
                s_Return = "<Font Color=Green>今天开始生产</Font>";
            }
            else if (d_Now < d_BeginDate)
            {
                TimeSpan ts = d_BeginDate - d_Now;
                s_Return = "<Font Color=black>" + ts.Days.ToString() + "天后开始生产</Font>";
            }
            else if ((d_Now > d_BeginDate) && (d_Now < d_EndDate))
            {
                s_Return = "<Font Color=yellow>正在生产</Font>";
            }

        }
        catch (Exception ex)
        { }
        return s_Return;
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        this.DID.Text = "";
        this.DataShows();
    }

    public string GetKC(string s_ProductsBarCode)
    {
        string s_Return = "";
        try
        {
            string s_SuppNo = this.SuppNoSelectValue.Value;
            KNet.BLL.KNet_Sys_WareHouse BLL = new KNet.BLL.KNet_Sys_WareHouse();
            DataSet Dtb_Table = BLL.GetList(" SuppNo='" + s_SuppNo + "' and KSW_Type='0' ");
            if (Dtb_Table.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Table.Tables[0].Rows.Count; i++)
                {
                    s_Return += base.Base_GetWareHouseNumber(Dtb_Table.Tables[0].Rows[i]["HouseNo"].ToString(), s_ProductsBarCode) + ",";
                }
                if (s_Return != "")
                {
                    s_Return = s_Return.Substring(0, s_Return.Length - 1);
                }

            }
        }
        catch
        { }
        return s_Return;
    }
    public string GetXQ(string s_ProductsBarCode)
    {
        string s_Return = "";
        try
        {
            //物料计划
            string s_DSql = "Select Sum(b.LeftNumber*XPP_Number ) OrderAmount from Knet_Procure_OrdersList a ";
            s_DSql += "left join View_Procure_OrdersList_Details b on a.OrderNo=b.OrderNo ";
            s_DSql += "join  Xs_Products_Prodocts c on c.XPP_FaterBarCode=b.ProductsBarCode ";
            s_DSql += "where Isnull(KPO_RKState,'1')=0 and c.XPP_ProductsBarCode='" + s_ProductsBarCode + "' ";


            if (this.Tbx_Order.Text != "")
            {
                s_DSql += " and b.OrderNo='" + this.Tbx_Order.Text + "'";
            }

            this.BeginQuery(s_DSql);
            this.QueryForDataTable();
            DataTable Dtb2 = Dtb_Result;
            if (Dtb2.Rows.Count > 0)
            {
                s_Return = base.FormatNumber1(Dtb2.Rows[0][0].ToString(), 0);
            }
        }
        catch
        { }
        return s_Return;
    }

    public string GetWRK(string s_ProductsBarCode)
    {
        string s_Return = "";
        try
        {

            //物料计划
            string s_DSql = "Select Sum(b.OrderAmount) OrderAmount from Knet_Procure_OrdersList a ";
            s_DSql += "left join View_Procure_OrdersList_Details b on a.OrderNo=b.OrderNo ";
            s_DSql += "where Isnull(KPO_RKState,'1')=0 and b.ProductsBarCode='" + s_ProductsBarCode + "' ";
            this.BeginQuery(s_DSql);
            this.QueryForDataSet();
            DataTable Dtb1 = Dts_Result.Tables[0];
            if (Dtb1.Rows.Count > 0)
            {
                s_Return = Dtb1.Rows[0][0].ToString();
            }
        }
        catch
        { }
        return s_Return;
    }


    public string GetNeedNumber(string s_ProductsBarCode)
    {
        string s_Return = "";
        try
        {
            string s_XqNumber = GetXQ(s_ProductsBarCode) == "" ? "0" : GetXQ(s_ProductsBarCode);
            string s_KcNumber = GetKC(s_ProductsBarCode) == "" ? "0" : GetKC(s_ProductsBarCode);
            string s_WRKNumber = GetWRK(s_ProductsBarCode) == "" ? "0" : GetWRK(s_ProductsBarCode);
            int i_Return = int.Parse(s_XqNumber) - int.Parse(s_KcNumber) - int.Parse(s_WRKNumber);
            s_Return = i_Return.ToString();
            if (s_Return == "0")
            {
                s_Return = "";
            }
        }
        catch
        { }
        return s_Return;
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
            DropDownList Ddl_House = (DropDownList)e.Row.Cells[0].FindControl("Ddl_House");
            if (this.SuppNoSelectValue.Value != "")
            {
                base.Base_DropWareHouseBindNoSelect(Ddl_House, "  SuppNo='" + this.SuppNoSelectValue.Value + "' and KSW_Type='0' ");
            }
            string s_Price = e.Row.Cells[8].Text == "" ? "0" : e.Row.Cells[8].Text;
            s_TotalPrice = Convert.ToString(decimal.Parse(s_TotalPrice) + decimal.Parse(s_Price));
            //耗料如果是一种类型的打勾有库存的。
            
        }
    }
    /// <summary>
    /// 添加提示
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView3_DataRowBinding(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList Ddl_House = (DropDownList)e.Row.Cells[0].FindControl("Ddl_House");

            if (this.SuppNoSelectValue.Value != "")
            {
                base.Base_DropWareHouseBindNoSelect(Ddl_House, "  SuppNo='" + this.SuppNoSelectValue.Value + "' and KSW_Type='0' ");
            }

            if (Ddl_House.SelectedValue== "")
            {
                base.Base_DropWareHouseBindNoSelect(Ddl_House, " KSW_Type='0'");
            }
        }
    }
    
    protected void GridView2_DataRowBinding(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList Ddl_House = (DropDownList)e.Row.Cells[0].FindControl("Ddl_House");

            TextBox Tbx_YRKTime = (TextBox)e.Row.Cells[0].FindControl("Tbx_YRKTime");
            Tbx_YRKTime.Text = DateTime.Now.ToShortDateString();
            base.Base_DropWareHouseBindNoSelect(Ddl_House, " 1=1 ");
        }
    }
}
