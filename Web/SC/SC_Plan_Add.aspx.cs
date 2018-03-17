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
using System.Runtime.Serialization.Json;

using KNet.DBUtility;
using KNet.Common;
using System.Net;
/// <summary>
/// 采购管理-----采购单 管理
/// </summary>
public partial class SC_Plan_Add : BasePage
{
    public string s_DivStyle = "";
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("新增生产计划") == false)
            {
                BasePage.AlertAndRedirect("您未登陆系统或已超过，请重新登陆系统!", "Default.aspx");
            }
            else
            {
                string s_SuppNo = Request["SuppNo"] == null ? "" : Request["SuppNo"].ToString();
                if (s_SuppNo != "")
                {
                    this.SuppNoSelectValue.Value = s_SuppNo;
                    this.SuppNo.Text = base.Base_GetSupplierName(s_SuppNo);
                    this.DataShows();
                }
                Tbx_Stime.Text = DateTime.Now.ToShortDateString();
                base.Base_DropDutyPerson(this.Ddl_Batch);
                string s_ProductsBarCode = Request.QueryString["ProductsBarCode"] == null ? "" : Request.QueryString["ProductsBarCode"].ToString();
                string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
                if (s_ID != "")
                {
                    this.Tbx_ID.Text = s_ID;
                }
            }
        }

    }




    private bool SetValue(KNet.Model.Sc_Produce_Plan model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            model.SPP_Creator = AM.KNet_StaffNo;
            model.SPP_Ctime = DateTime.Now;
            model.SPP_STime = DateTime.Parse(Tbx_Stime.Text);
            model.SPP_Remarks = this.Tbx_Remark.Text;
            model.SPP_SuppNo = this.SuppNoSelectValue.Value;
            if (this.Tbx_ID.Text != "")
            {
                model.SPP_ID = this.Tbx_ID.Text;
            }
            else
            {
                model.SPP_ID = base.GetNewID("Sc_Produce_Plan", 1);
            }
            ArrayList arr_Details = new ArrayList();
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                KNet.Model.Sc_Produce_Plan_Details Model_Details = new KNet.Model.Sc_Produce_Plan_Details();
                CheckBox Chbk = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
                TextBox Tbx_BeginDate = (TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_BeginTime");
                TextBox Tbx_EndDate = (TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_EndTime");
                TextBox Tbx_FBeginDate = (TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_FBeginTime");
                TextBox Tbx_FEndDate = (TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_FEndTime");
                TextBox Tbx_Days = (TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_Days");
                TextBox Tbx_Number = (TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_Number");
                TextBox Tbx_DID = (TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_DID");
                TextBox Tbx_Remarks = (TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_Remarks");
                TextBox Tbx_OrderNum = (TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_OrderNum");
                CheckBox Chbk_Wl = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk_Wl");

                if (Chbk.Checked)
                {
                    Model_Details.SPD_ID = base.GetMainID(i);
                    try
                    {
                        Model_Details.SPD_BeginTime = DateTime.Parse(Tbx_BeginDate.Text);
                    }
                    catch
                    { }
                    try
                    {
                        Model_Details.SPD_EndTime = DateTime.Parse(Tbx_EndDate.Text);
                    }
                    catch
                    { }
                    try
                    {
                        Model_Details.SPD_FBeginTime = DateTime.Parse(Tbx_FBeginDate.Text);
                    }
                    catch
                    { }
                    try
                    {
                        Model_Details.SPD_FEndTime = DateTime.Parse(Tbx_FEndDate.Text);
                    }
                    catch
                    { }
                    try
                    {
                        Model_Details.SPD_Number = int.Parse(Tbx_Number.Text);
                    }
                    catch
                    { }
                    try
                    {
                        Model_Details.SPD_Days = int.Parse(Tbx_Days.Text);
                    }
                    catch
                    { }
                    try
                    {
                        Model_Details.SCP_Order = int.Parse(Tbx_OrderNum.Text);
                    }
                    catch
                    {
                        Model_Details.SCP_Order = 0;
                    }
                    Model_Details.SPD_OrderNo = Tbx_DID.Text;
                    Model_Details.SPD_FaterID = model.SPP_ID;
                    Model_Details.SPD_Remarks = Tbx_Remarks.Text;
                    Model_Details.SPD_IsWl = 0;
                    arr_Details.Add(Model_Details);
                }
            }
            model.arr_Details = arr_Details;
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
        string s_Sql = "Select b.ID as DID,SCP_Order,SPD_ID,a.*,b.*,c.CustomerValue,c.DutyPerson,e.wrkNumber,isnull((select top 1 OrderPreToDate from Knet_Procure_OrdersList where ParentOrderNo=a.OrderNo order by OrderPreToDate desc),'1900-01-01') as MaxOrderPreToDate from Knet_Procure_OrdersList a left join Knet_Procure_OrdersList_Details b on a.OrderNo=b.OrderNo left join Knet_Sales_ContractList c on c.ContractNo=a.ContractNo ";
        s_Sql += " join v_OrderRK e on a.OrderNO=e.V_OrderNo ";
        s_Sql += " left join (  select a.*  ";
        s_Sql += " from Sc_Produce_Plan_Details a join SC_Produce_Plan d on a.SPD_FaterID=d.SPP_ID ";
        s_Sql += " where not exists(select 1  ";
        s_Sql += " from Sc_Produce_Plan_Details b join SC_Produce_Plan c on b.SPD_FaterID=c.SPP_ID ";
        s_Sql += "  where b.SPD_OrderNo=a.SPD_OrderNo and c.SPP_CTime>d.SPP_CTime)) aa on aa.SPD_OrderNo=b.ID ";
        s_Sql += " where OrderType='128860698200781250' and Isnull(KPO_RKState,'1')=0 and e.rkstate<>'1' and KPO_Del='0'";
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
        if (this.Tbx_Tyoe.Text == "1")
        {
            s_Sql += " order by isnull(SCP_Order,0),orderPreToDate,isnull(SPD_EndTime,'2900-01-01')  ";
        }
        else
        {
            s_Sql += " order by orderPreToDate,isnull(SCP_Order,0),isnull(SPD_EndTime,'2900-01-01')  ";
        }
        this.BeginQuery(s_Sql);
        this.QueryForDataSet();
        DataSet ds = Dts_Result;

        GridView1.DataSource = ds.Tables[0];
        GridView1.DataKeyNames = new string[] { "OrderNo" };
        GridView1.DataBind();
        try
        {
            decimal d_Total1 = 0, d_total2 = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                d_Total1 += decimal.Parse(ds.Tables[0].Rows[i]["OrderAmount"].ToString());
                d_total2 += decimal.Parse(ds.Tables[0].Rows[i]["wrkNumber"].ToString());
            }
            Lbl_Details.Text = "订单总量：<font color=red>" + d_Total1 + "</font>  未入库总量：<font color=red>" + d_total2 + "</font>";

        }
        catch
        { } ////物料计划
        //string s_DSql = "Select a.XPP_ProductsBarCode as ProductsBarCode from Xs_Products_Prodocts a ";
        //s_DSql += " Where a.XPP_FaterBarCode in (Select b.ProductsBarCode from  Knet_Procure_OrdersList a left join Knet_Procure_OrdersList_Details b on a.OrderNo=b.OrderNo left join Knet_Sales_ContractList c on c.ContractNo=a.ContractNo ";
        //s_DSql += " join v_OrderRK e on a.OrderNO=e.V_OrderNo where OrderType='128860698200781250' and Isnull(KPO_RKState,'1')=0 and e.rkstate<>'1' ";
        //if (this.SuppNoSelectValue.Value != "")
        //{
        //    s_DSql += " and a.SuppNo='" + this.SuppNoSelectValue.Value + "' ";
        //}

        //if (this.Tbx_Customer.Text != "")
        //{
        //    s_DSql += " and c.CustomerValue in (Select CustomerValue From KNet_Sales_ClientList where CustomerName Like '%" + Tbx_Customer.Text + "%') ";
        //}
        //if (this.SeachKey.Text != "")
        //{
        //    s_DSql += " and b.ProductsBarCode in (Select ProductsBarCode From KNet_Sys_Products where ProductsEdition Like '%" + SeachKey.Text + "%' or ProductsName like '%" + SeachKey.Text + "%')";

        //}
        //s_DSql += ") ";

        //this.BeginQuery(s_DSql);
        //this.QueryForDataSet();
        //DataSet ds1 = Dts_Result;

        //this.MyGridView2.DataSource = ds1.Tables[0];
        //MyGridView2.DataBind();

    }

    public string OrderNo(string s_Order1, string s_Order2)
    {
        if (s_Order1 == "")
        {
            s_Order1 = s_Order2;
        }

        return s_Order1;
    }
    public string GetOrderDetails(string s_SuppNo, string s_ProductsBarCode, string s_OrderType)
    {
        string s_Return = "", s_ListProductsBarCode = "", s_HouseNo = "", s_HouseName = "";
        string s_Sql = "Select b.ProductsBarCode from  Xs_Products_Prodocts a ";
        s_Sql += " left join KNet_Sys_Products b on b.ProductsBarCode=a.XPP_ProductsBarCode";//明细的产品
        s_Sql += " where a.XPP_FaterBarCode='" + s_ProductsBarCode + "' ";//未入库的原材料订单
        if (s_OrderType == "1")//芯片
        {
            s_Sql += " and b.ProductsName like '%芯片%' ";
        }
        else if (s_OrderType == "2")//导电胶
        {
            s_Sql += " and b.ProductsName like '%导电胶%' ";
        }
        else if (s_OrderType == "3")//塑壳
        {
            s_Sql += " and b.ProductsName like '%塑壳%' ";
        }
        else if (s_OrderType == "4")//PCB
        {
            s_Sql += " and b.ProductsName like '%PCB%' ";
        }
        else if (s_OrderType == "5")//发射管
        {
            s_Sql += " and b.ProductsName like '%发射管%' ";
        }
        else if (s_OrderType == "6")//发射管
        {
            s_Sql += " and b.ProductsName like '%电池%' ";
        }
        this.BeginQuery(s_Sql);
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            s_ListProductsBarCode = Dtb_Result.Rows[0][0].ToString();
        }
        this.BeginQuery("Select * from KNet_Sys_WareHouse Where SuppNo='" + s_SuppNo + "'");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            s_HouseNo = Dtb_Result.Rows[0]["HouseNo"].ToString();
            s_HouseName = Dtb_Result.Rows[0]["HouseName"].ToString();
        }
        //查询该品种的订单
        string s_DetailsSql = " Select Sum(OrderAmount) from Knet_Procure_OrdersList_Details a join Knet_Procure_OrdersList b on a.OrderNo=b.OrderNo ";
        s_DetailsSql += " Where a.ProductsBarCode='" + s_ListProductsBarCode + "' and KPO_RkState=0";
        this.BeginQuery(s_DetailsSql);
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            s_Return = base.Base_GetProductsEdition(s_ListProductsBarCode) + "<HR/><Font Color=Red>" + Dtb_Result.Rows[0][0].ToString() + "</Font><HR/><Font Color=Green>" + base.Base_GetWareHouseNumber(s_HouseNo, s_ListProductsBarCode) + "</Font>";
        }
        //if (s_Return != "")
        //{
        //    s_Return += "<br><a href='SC_Plan_Manage.aspx?ProductsBarCode=" + s_ListProductsBarCode + "'>详细</a>";
        //}
        return s_Return;
    }

    protected void Btn_SaveOnClick(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        string s_ID = this.Tbx_ID.Text;

        KNet.Model.Sc_Produce_Plan model = new KNet.Model.Sc_Produce_Plan();
        KNet.BLL.Sc_Produce_Plan bll = new KNet.BLL.Sc_Produce_Plan();

        if (this.SetValue(model) == false)
        {
            Alert("系统错误！");
            return;
        }
        if (s_ID == "")//新增
        {
            try
            {

                string s_Sql = " Update Sc_Produce_Plan set SPP_Del=1 where SPP_STime='" + model.SPP_STime + "' and SPP_SuppNo='" + model.SPP_SuppNo + "' ";
                DbHelperSQL.ExecuteSql(s_Sql);
                bll.Add(model);
                AM.Add_Logs("生成计划增加" + this.Tbx_ID.Text);
                AlertAndRedirect("新增成功！", "Sc_Plan_Manage.aspx");

                string JSD = "Sc/Sc_Plan_Print1.aspx?ID=" + model.SPP_ID + "";
                base.HtmlToPdf(JSD, Server.MapPath("../Sc/PDF"), model.SPP_ID + "(" + base.DateToString(model.SPP_STime.ToString()).Replace("/", ".") + ")");

            }
            catch (Exception ex) { }
        }
        else
        {

            try
            {
                bll.Update(model);
                AM.Add_Logs("生成计划修改" + this.Tbx_ID.Text);
                AlertAndRedirect("修改成功！", "Sc_Plan_Manage.aspx");
            }
            catch { }
        }
    }

    public string GetDate(string s_OrderDID, int i_type)
    {
        string s_Return = "";
        try
        {
            this.BeginQuery("Select top 1 isnull(SPD_Days,0) as SPD_Days,* From Sc_Produce_Plan_Details join SC_Produce_Plan on SPD_FaterID=SPP_ID where SPD_OrderNo='" + s_OrderDID + "' order by SPP_CTime desc ");
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
                else if (i_type == 2)
                {
                    s_Return = DateTime.Parse(Dtb_Result.Rows[0]["SPD_FBeginTime"].ToString()).ToShortDateString();
                }
                else if (i_type == 3)
                {
                    s_Return = DateTime.Parse(Dtb_Result.Rows[0]["SPD_FEndTime"].ToString()).ToShortDateString();
                }
                else if (i_type == 4)
                {
                    s_Return = Dtb_Result.Rows[0]["SPD_Remarks"].ToString();
                }
                else if (i_type == 5)
                {
                    s_Return = Dtb_Result.Rows[0]["SPD_Number"].ToString();
                }
                else if (i_type == 6)
                {
                    s_Return = Dtb_Result.Rows[0]["SPD_Days"].ToString();
                }
                else if (i_type == 7)
                {
                    s_Return = Dtb_Result.Rows[0]["SPD_isWl"].ToString();
                }
            }
        }
        catch (Exception ex)
        { }
        return s_Return;

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        this.DataShows();
    }

    protected void Btn_Sc_Click(object sender, EventArgs e)
    {
        try
        {
            AdminloginMess AM = new AdminloginMess();
            //先找该供应商产能和交期
            KNet.BLL.Knet_Procure_Suppliers Bll = new KNet.BLL.Knet_Procure_Suppliers();
            KNet.Model.Knet_Procure_Suppliers Model = Bll.GetModelB(this.SuppNoSelectValue.Value);
            int i_DayScNumber = Model.KPS_ScNumber;
            int i_GiveDays = Model.KPS_GiveDays;
            KNet.BLL.Sc_Order_ProducePlan BLL_ProducePlan = new KNet.BLL.Sc_Order_ProducePlan();
            //删除该供应商的自动排产计划
            BLL_ProducePlan.UpdateDelBySuppNo(this.SuppNoSelectValue.Value);
            //循环给赋值
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                TextBox Tbx_StartTime = (TextBox)GridView1.Rows[i].FindControl("Tbx_EndTime");
                TextBox Tbx_EndTime = (TextBox)GridView1.Rows[i].FindControl("Tbx_FEndTime");
                TextBox Tbx_MaxOrderPreToDate = (TextBox)GridView1.Rows[i].FindControl("Tbx_MaxOrderPreToDate");
                TextBox Tbx_DID = (TextBox)GridView1.Rows[i].FindControl("Tbx_DID");
                TextBox Tbx_Number = (TextBox)GridView1.Rows[i].FindControl("Tbx_Number");
                CheckBox Chk = (CheckBox)GridView1.Rows[i].FindControl("Chbk");
                
                //查询最新的自动排产日期和剩余产量
                
                DateTime D_BeginDateTime = DateTime.Parse(DateTime.Now.ToShortDateString());
                string s_Sql1 = "Select top 1 *  from Sc_Order_ProducePlan where SOP_SuppNo='" + this.SuppNoSelectValue.Value + "' and SOP_STime='" + D_BeginDateTime + "' and SOP_Del='0' order by SOP_EndTime desc";
                this.BeginQuery(s_Sql1);
                this.QueryForDataTable();
                if (Dtb_Result.Rows.Count > 0)
                {
                    D_BeginDateTime = DateTime.Parse(Dtb_Result.Rows[0]["SOP_EndTime"].ToString());
                }
                DateTime Date_MaxOrderPreToDate = DateTime.Parse(Tbx_MaxOrderPreToDate.Text);
                if (Date_MaxOrderPreToDate.AddDays(3) >= D_BeginDateTime)
                {
                    D_BeginDateTime = Date_MaxOrderPreToDate.AddDays(3);
                }
                //要求日期
                //最后物料交货日期

                //插入主表
                if (Chk.Checked)
                {
                    //先删除今日的自动排序信息
                    //先查询今天剩余产量

                    string s_TotalNumber = "0";
                    string s_Sql = "Select Sum(SOP_ScNumber) from Sc_Order_ProducePlan where SOP_SuppNo='" + this.SuppNoSelectValue.Value + "' and SOP_Del='0' and SOP_STime in (Select TOP 1 SOP_EndTime  from Sc_Order_ProducePlan where   SOP_SuppNo='" + this.SuppNoSelectValue.Value + "'   order by SOP_EndTime desc) ";
                    this.BeginQuery(s_Sql);
                    s_TotalNumber = this.QueryForReturn();
                    s_TotalNumber = s_TotalNumber == "" ? "0" : s_TotalNumber;
                    int i_ScNumber = int.Parse(Tbx_Number.Text);
                    //int i_LeftNumber = i_DayScNumber - int.Parse(s_TotalNumber);

                    KNet.Model.Sc_Order_ProducePlan Model_ProducePlan = new KNet.Model.Sc_Order_ProducePlan();
                    Model_ProducePlan.SOP_ID = base.GetMainID(i);
                    Model_ProducePlan.SOP_FID = Tbx_DID.Text;
                    Model_ProducePlan.SOP_PlanID = this.Tbx_ID.Text;
                    Model_ProducePlan.SOP_SuppNo = this.SuppNoSelectValue.Value;
                    Model_ProducePlan.SOP_STime = DateTime.Parse(DateTime.Now.ToShortDateString());

                    string s_Detail = GetSCDetails(D_BeginDateTime, i_DayScNumber, i_ScNumber, this.SuppNoSelectValue.Value);
                    string[] s_Details = s_Detail.Split('|');

                    Model_ProducePlan.SOP_BeginTime = D_BeginDateTime;
                    Model_ProducePlan.SOP_EndTime = DateTime.Parse(s_Details[0]);

                    Model_ProducePlan.SOP_ScNumber = i_ScNumber;
                    Model_ProducePlan.SOP_LeftNumber = int.Parse(s_Details[1]);
                    Model_ProducePlan.SOP_DayScNumber = i_DayScNumber;
                    Model_ProducePlan.SOP_CTime = DateTime.Now;
                    Model_ProducePlan.SOP_Creator = AM.KNet_StaffNo;
                    BLL_ProducePlan.Add(Model_ProducePlan);
                    Tbx_StartTime.Text = D_BeginDateTime.ToShortDateString();
                    Tbx_EndTime.Text = DateTime.Parse(s_Details[0]).ToShortDateString();
                }
            }
        }
        catch
        { }
    }
    private string GetSCDetails(DateTime Date_BeginTime, int i_DayScNumber, int i_ScNumber, string s_SuppNo)
    {
        DateTime d_ReturnTime = Date_BeginTime;
        int i_LeftNumber = 0;
        int i_DayLeftScNumber = 0;
        try
        {
            string s_TotalNumber = "";
            string s_Sql = "Select top 1 SOP_LeftNumber  from Sc_Order_ProducePlan where SOP_SuppNo='" + s_SuppNo + "' and SOP_Del='0' and SOP_STime='" + Date_BeginTime + "' order by SOP_EndTime ";
            this.BeginQuery(s_Sql);
            s_TotalNumber = this.QueryForReturn();
            if (s_TotalNumber != "")
            {
                i_DayLeftScNumber = int.Parse(s_TotalNumber);
            }
            if (i_DayLeftScNumber == 0)
            {
                i_DayLeftScNumber = i_DayScNumber;
            }
            if (i_DayLeftScNumber > i_ScNumber)
            {
                i_LeftNumber = i_DayLeftScNumber - i_ScNumber;
                d_ReturnTime = Date_BeginTime;
            }
            else
            {
                d_ReturnTime = Date_BeginTime.AddDays(1);
                i_LeftNumber = i_ScNumber - i_DayLeftScNumber;
                string s_Detail = GetSCDetails(d_ReturnTime, i_DayScNumber, i_LeftNumber, s_SuppNo);
                string[] s_Details = s_Detail.Split('|');
                d_ReturnTime = DateTime.Parse(s_Details[0]);
                i_LeftNumber = int.Parse(s_Details[1]);
            }

        }
        catch
        { }
        return d_ReturnTime.ToShortDateString() + "|" + i_LeftNumber.ToString();
    }
    public string GetContract(string s_ContractNos)
    {
        string s_Return = "";
        try
        {
            string[] s_ContractNo = s_ContractNos.Split(',');
            for (int i = 0; i < s_ContractNo.Length; i++)
            {
                s_Return += "<a href=\"../SalesContract/Xs_ContractList_View.aspx?ID=" + s_ContractNo[i] + "\" >" + s_ContractNo[i] + "</a><br>";

            }
        }
        catch
        { }
        return s_Return;
    }


    public string GetCustomer(string s_ContractNos)
    {
        string s_Return = "";
        try
        {
            string[] s_ContractNo = s_ContractNos.Split(',');
            for (int i = 0; i < s_ContractNo.Length; i++)
            {
                KNet.BLL.KNet_Sales_ContractList Bll = new KNet.BLL.KNet_Sales_ContractList();
                KNet.Model.KNet_Sales_ContractList Model = Bll.GetModelB(s_ContractNo[i]);
                s_Return = base.Base_GetCustomerName_Link(Model.CustomerValue);
            }
            return s_Return;
        }
        catch
        { }
        return s_Return;
    }
    public string GetKC(string s_ProductsBarCode)
    {
        string s_Return = "";
        try
        {
            string s_SuppNo = this.SuppNoSelectValue.Value;
            KNet.BLL.KNet_Sys_WareHouse BLL = new KNet.BLL.KNet_Sys_WareHouse();
            DataSet Dtb_Table = BLL.GetList(" SuppNo='" + s_SuppNo + "'");
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
            string s_DSql = "Select Sum(b.OrderAmount*XPP_Number )OrderAmount from Knet_Procure_OrdersList a ";
            s_DSql += "left join Knet_Procure_OrdersList_Details b on a.OrderNo=b.OrderNo ";
            s_DSql += "join  Xs_Products_Prodocts c on c.XPP_FaterBarCode=b.ProductsBarCode ";
            s_DSql += "where Isnull(KPO_RKState,'1')=0 and c.XPP_ProductsBarCode='" + s_ProductsBarCode + "' ";
            this.BeginQuery(s_DSql);
            this.QueryForDataTable();
            DataTable Dtb2 = Dtb_Result;
            if (Dtb2.Rows.Count > 0)
            {
                s_Return = base.FormatNumber(Dtb2.Rows[0][0].ToString(), 0);
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
            s_DSql += "left join Knet_Procure_OrdersList_Details b on a.OrderNo=b.OrderNo ";
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




    protected void Btn_SaveOrderNoClick(object sender, EventArgs e)
    {
        try
        {
            this.Tbx_Tyoe.Text = "1";
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                KNet.BLL.Sc_Produce_Plan_Details BLL_Details = new KNet.BLL.Sc_Produce_Plan_Details();

                CheckBox Chbk = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
                TextBox Tbx_OrderNum = (TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_OrderNum");
                TextBox Tbx_SPDID = (TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_SPDID");
                if (Chbk.Checked)
                {
                    if (Tbx_SPDID.Text != "")
                    {
                        KNet.Model.Sc_Produce_Plan_Details Model_Details = BLL_Details.GetModel(Tbx_SPDID.Text);
                        Model_Details.SCP_Order = int.Parse(Tbx_OrderNum.Text);
                        BLL_Details.UpdateOrder(Model_Details);
                    }
                    else
                    {
                        KNet.Model.Sc_Produce_Plan Model = new KNet.Model.Sc_Produce_Plan();
                        KNet.BLL.Sc_Produce_Plan BLL = new KNet.BLL.Sc_Produce_Plan();
                        this.SetValue(Model);
                        Model.SPP_Del = 1;
                        BLL.Add(Model);
                    }
                }
            }
            this.DataShows();
            Alert("序号更新成功！");
        }
        catch (Exception ex)
        { }

    }

    public string GetState(String s_OrderNo)
    {
        string s_Return = "";
        try
        {

            KNet.BLL.Knet_Procure_OrdersList Bll = new KNet.BLL.Knet_Procure_OrdersList();
            KNet.Model.Knet_Procure_OrdersList Model = Bll.GetModelB(s_OrderNo);
            if (Model.KPO_IsStopProduce == 1)
            {
                s_Return = "<font color=red>暂停</font>";
            }
            else
            {

                s_Return = "<font color=green>正常</font>";
            }
        }
        catch
        { }
        return s_Return;
    }
}
