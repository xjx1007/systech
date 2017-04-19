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


public partial class Web_Sales_ShipWareOut_View : BasePage
{
    public string s_MyTable_Detail = "", s_OrderStyle = "", s_DetailsStyle = "", s_TotalPrice = "",s_SuppHouseNo="";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            AdminloginMess AM = new AdminloginMess();
            this.Lbl_Title.Text = "查看出库单信息";
            if (AM.CheckLogin("查看发货出库") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            this.Tbx_ID.Text = s_ID;
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            string s_DType = Request.QueryString["DType"] == null ? "" : Request.QueryString["DType"].ToString();
            if (s_DType == "1")
            {
                this.btn_Chcek.Visible = false;
            }
            if (s_Type == "1")
            {
                s_OrderStyle = "class=\"dvtUnSelectedCell\"";
                s_DetailsStyle = "class=\"dvtSelectedCell\"";
                Pan_Order.Visible = false;
                Pan_Detail.Visible = true;
                Table_Btn.Visible = false;
            }
            else
            {
                s_DetailsStyle = "class=\"dvtUnSelectedCell\"";
                s_OrderStyle = "class=\"dvtSelectedCell\"";
                Pan_Order.Visible = true;
                Pan_Detail.Visible = false;
                Table_Btn.Visible = true;
            }
            if (s_ID != "")
            {
                ShowInfo(s_ID);
            }
        }

    }

    public string GetState(string s_State)
    {
        if (s_State == "2")
        {
            return "<font color=red>失败</font>";
        }
        else
        {

            return "<font color=blue>成功</font>";
        }
    }
    private void ShowInfo(string s_ID)
    {
        base.Base_DropDutyPerson(this.Ddl_RkPerson);
        base.Base_DropDutyPerson(this.Ddl_WwPerson);
        AdminloginMess AM = new AdminloginMess();
        KNet.BLL.KNet_WareHouse_DirectOutList BLL = new KNet.BLL.KNet_WareHouse_DirectOutList();
        KNet.Model.KNet_WareHouse_DirectOutList Model = BLL.GetModelB(s_ID);
        try
        {
            if (Request["ID"] != null && Request["ID"] != "")
            {
                this.DirectOutNO.Text = Model.DirectOutNo;
                this.OutWareNo.Text = "<a href=\"../SalesShip/Knet_Sales_Ship_Manage_View.aspx?ID=" + Model.KWD_ShipNo + "\" target=\"_self\">" + Model.KWD_ShipNo + "</a>";
                this.DutyPerson.Text = base.Base_GetUserName(Model.DirectOutStaffNo);
                this.House.Text = base.Base_GetHouseName(Model.HouseNo);
                KNet.BLL.KNet_Sys_WareHouse Bll_WareHouse =new KNet.BLL.KNet_Sys_WareHouse();
                KNet.Model.KNet_Sys_WareHouse Model_WareHouse =Bll_WareHouse .GetModel(Model.HouseNo);

                s_SuppHouseNo = Model_WareHouse.SuppNo;
                if (Model.HouseNo == "128502353068906250")
                {
                    this.Chk_IsDetails.Checked = false;
                }
                this.Lbl_HouseNo.Text = Model.HouseNo;
                this.KWd_CwCode.Text = Model.KWD_CwCode;
                try
                {
                    this.Lbl_ReceTime.Text = Model.KWD_ReceTime.ToShortDateString();
                }
                catch { }
                this.ShipType.Text = base.Base_GetKClaaName(Model.KWD_ContractDeliveMethods);
                this.Lbl_sCustomer.Text = base.Base_GetCustomerName_Link(Model.KWD_SCustomerValue);
                this.Lbl_CwTime.Text = Model.KWD_CWOutTime.ToShortDateString();
                try
                {
                    this.DirectOutDateTime.Text = DateTime.Parse(Model.DirectOutDateTime.ToString()).ToShortDateString();
                    this.Tbx_RkTime.Text = DateTime.Parse(Model.KWD_CWOutTime.ToString()).ToShortDateString();
                    this.Tbx_WwTime.Text = DateTime.Parse(Model.KWD_CWOutTime.ToString()).ToShortDateString();
                }
                catch
                {
                    this.Tbx_RkTime.Text = DateTime.Now.ToShortDateString();
                    this.Tbx_WwTime.Text = DateTime.Now.ToShortDateString();
                }
                try
                {
                    this.Customer.Text = base.Base_GetCustomerName_Link(Model.KWD_Custmoer);
                    this.Lbl_Customer.Text = Model.KWD_Custmoer;
                }
                catch { }
                if (Lbl_sCustomer.Text == "--")
                {

                   Lbl_sCustomer.Text= this.Customer.Text ;
                }
                try
                {
                    this.LinkMan.Text = Model.KWD_ContentPerson;
                    this.Address.Text = Model.KWD_Address;
                    this.Remarks.Text = Model.DirectOutRemarks;
                    this.Phone.Text = Model.KWD_Telphone;
                }
                catch { }
                if (Model.DirectOutCheckYN == 3)
                {
                    btn_Chcek.Text = "反财务审批";
                }
                else if (Model.DirectOutCheckYN == 2)
                {
                    if (AM.YNAuthority("财务审核出库单") == true)
                    {
                        btn_Chcek.Text = "财务审批";
                    }
                    else
                    {
                        btn_Chcek.Text = "反审批";
                    }
                }
                else if (Model.DirectOutCheckYN == 1)
                {
                    if (AM.YNAuthority("财务审核出库单") == true)
                    {
                        btn_Chcek.Text = "财务审批";
                    }
                    else
                    {
                        btn_Chcek.Text = "反审批";
                    }
                }
                else
                {
                    btn_Chcek.Text = "审批";
                }
                if ((AM.YNAuthority("发货单审核")==false) || (AM.YNAuthority("财务审核出库单") == true))//如果销售出库审核
                {
                    btn_Chcek.Enabled = true;
                }
                else
                {
                    btn_Chcek.Enabled = false;
                }
                KNet.BLL.KNet_WareHouse_DirectOutList_Details BLL_Details = new KNet.BLL.KNet_WareHouse_DirectOutList_Details();
                DataSet Dts_Details = BLL_Details.GetList(" DirectOutNo='" + Model.DirectOutNo + "' ");
                if (Dts_Details.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < Dts_Details.Tables[0].Rows.Count; i++)
                    {
                        s_MyTable_Detail += "<tr>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName_Link(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsCode(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" nowrap>" + base.Base_GetProductsEdition(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.FormatNumber(Dts_Details.Tables[0].Rows[i]["DirectOutAmount"].ToString(), 0) + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Class=\"detailedViewTextBox\" OnFocus=\"this.class=\'detailedViewTextBoxOn\'\" OnBlur=\"this.class=\'detailedViewTextBox\'\" Name=\"BNumber_" + i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["KWD_BNumber"].ToString() + "'>" + base.FormatNumber(Dts_Details.Tables[0].Rows[i]["KWD_BNumber"].ToString(), 0) + "</td>";
                        //查看销售单价权限
                        if (AM.YNAuthority("销售单价查看") == false)
                        {
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\">-</td>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\">-</td>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\">-</td>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\">-</td>";
                        }
                        else
                        {
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.FormatNumber(Dts_Details.Tables[0].Rows[i]["DirectOutUnitPrice"].ToString(), 3) + "</td>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.FormatNumber(Dts_Details.Tables[0].Rows[i]["DirectOutTotalNet"].ToString(), 3) + "</td>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.FormatNumber(Dts_Details.Tables[0].Rows[i]["KWD_SalesUnitPrice"].ToString(), 3) + "</td>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.FormatNumber(Dts_Details.Tables[0].Rows[i]["KWD_SalesTotalNet"].ToString(), 3) + "</td>";
                        }
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["CustomerProductsName"].ToString().Replace("?", "") + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["PlanNo"].ToString().Replace("?", "") + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["OrderNo"].ToString().Replace("?", "") + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["MaterNo"].ToString().Replace("?", "") + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["DirectOutRemarks"].ToString() + "</td>";
                        s_MyTable_Detail += "</tr>";
                    }
                    //物料计划
                }
                this.Lbl_Details.Text = s_MyTable_Detail;
                DataSet Dts_Details1 = BLL_Details.GetList(" DirectOutNo='" + Model.DirectOutNo + "' and ProductsBarCode not in (select ProductsBarCode from KNet_Sys_Products where ProductsType='M130704050932527') ");
                this.MyGridView1.DataSource = Dts_Details1;
                MyGridView1.DataBind();

                string s_DSql = "Select distinct a.XPP_ProductsBarCode as ProductsBarCode,XPP_Price,XPP_SuppNo,XPP_Number,a.XPP_FaterBarCode,Sum(XPP_Number*(b.DirectOutAmount+Isnull(KWD_BNumber,0))) as Number,c.ProductsName from Xs_Products_Prodocts a ";
                s_DSql += " join KNet_WareHouse_DirectOutList_Details b on a.XPP_FaterBarCode=b.ProductsBarCode join KNet_Sys_Products c on c.ProductsBarCode=a.XPP_ProductsBarCode";
                s_DSql += " Where b.DirectOutNo='" + Model.DirectOutNo + "' and a.XPP_ISOrder='是' Group by a.XPP_ProductsBarCode,XPP_Number,XPP_Price,XPP_SuppNo,XPP_FaterBarCode,c.ProductsName order by c.ProductsName ";

                this.BeginQuery(s_DSql);
                this.QueryForDataSet();
                DataSet ds1 = Dts_Result;
                this.MyGridView2.DataSource = ds1.Tables[0];
                MyGridView2.DataBind();

                KNet.BLL.Sc_Expend_Manage bll_Manage = new KNet.BLL.Sc_Expend_Manage();
                string SqlWhere = " SEM_Type=1 and SEM_DirectOutNO='" + Model.DirectOutNo + "' ";
                SqlWhere = SqlWhere + " order by SEM_MTime desc";
                DataSet ds_Manage = bll_Manage.GetList(SqlWhere);

                GridView1.DataSource = ds_Manage;
                GridView1.DataKeyNames = new string[] { "SEM_ID" };
                GridView1.DataBind();

                

        KNet.BLL.PB_Basic_Mail bll = new KNet.BLL.PB_Basic_Mail();
        string s_Sql = "PBM_Del=0 and PBM_FID='" + Model.DirectOutNo + "'";

        s_Sql += " Order by PBM_CTime desc";
        DataSet ds = bll.GetList(s_Sql);
        MyGridView3.DataSource = ds;
        MyGridView3.DataKeyNames = new string[] { "PBM_ID" };
        MyGridView3.DataBind();
        ds.Dispose();
                
            }
            else
            {
                Response.Write("<script language=javascript>alert('非法参数！');window.close();</script>");
                Response.End();
            }

        }
        catch { }

    }

    protected void btn_Chcek_Click(object sender, EventArgs e)
    {
        AdminloginMess  AM =new AdminloginMess();
        if (btn_Chcek.Text == "审批")
        {

            string DoSql = "update KNet_WareHouse_DirectOutList  set DirectOutCheckYN=1,DirectOutCheckStaffNo='" + AM.KNet_StaffNo + "'  where  DirectOutNo='" + this.Tbx_ID.Text + "' ";
            DbHelperSQL.ExecuteSql(DoSql);
            btn_Chcek.Text = "反审批";
            AM.Add_Logs("审批成功" + this.Tbx_ID.Text);
            AlertAndRedirect("审批成功！", "Sales_ShipWareOut_View.aspx?ID=" + this.Tbx_ID.Text + "");
               // this.Panel_SCDetails.Visible = true;
        }
        else if (btn_Chcek.Text == "反审批")
        {

            string DoSql = "update KNet_WareHouse_DirectOutList  set DirectOutCheckYN=0,DirectOutCheckStaffNo='" + AM.KNet_StaffNo + "'  where  DirectOutNo='" + this.Tbx_ID.Text + "' ";
            DbHelperSQL.ExecuteSql(DoSql);
            btn_Chcek.Text = "审批";
            AM.Add_Logs("反审批成功" + this.Tbx_ID.Text);
            AlertAndRedirect("反审批成功！", "Sales_ShipWareOut_View.aspx?ID=" + this.Tbx_ID.Text + "");
            //删除
            //string sql = " delete from Sc_Expend_Manage_MaterDetails where SED_SEMID in(Select SEM_ID from Sc_Expend_Manage Sc_Expend_Manage where SEM_DirectOutNo='" + this.Tbx_ID.Text + "' ) "; //发货 明细
            //sql += " delete from Sc_Expend_Manage_RCDetails where SER_SEMID in(Select SEM_ID from Sc_Expend_Manage Sc_Expend_Manage where SEM_DirectOutNo='" + this.Tbx_ID.Text + "' ) "; //发货 明细
            //sql += " delete from Sc_Expend_Manage where SEM_DirectOutNo='" + this.Tbx_ID.Text + "' "; //删除生产消耗
            //sql += " update KNet_WareHouse_DirectOutList  set DirectOutCheckYN=1,DirectOutCheckStaffNo =''  where  DirectOutNo='" + this.Tbx_ID.Text + "' ";
            //DbHelperSQL.ExecuteSql(sql);
            //btn_Chcek.Text = "审批";
            //AM.Add_Logs("原材料消耗删除" + this.Tbx_ID.Text);
            //AlertAndRedirect("原材料消耗删除成功！", "Sales_ShipWareOut_View.aspx?Type=1&ID="+this.Tbx_ID.Text+"");
        }
        else if (btn_Chcek.Text == "财务审批")
        {
            string DoSql = "update KNet_WareHouse_DirectOutList  set DirectOutCheckYN=3,DirectOutCheckStaffNo='"+AM.KNet_StaffNo+"'  where  DirectOutNo='" + this.Tbx_ID.Text + "' ";
            DbHelperSQL.ExecuteSql(DoSql);
            btn_Chcek.Text = "反财务审批";
            AM.Add_Logs("财务审批成功" + this.Tbx_ID.Text);
            AlertAndRedirect("财务审批成功！", "Sales_ShipWareOut_View.aspx?ID=" + this.Tbx_ID.Text + "");
        }
        else if (btn_Chcek.Text == "反财务审批")
        {
            string DoSql = "update KNet_WareHouse_DirectOutList  set DirectOutCheckYN=1,DirectOutCheckStaffNo=''  where  DirectOutNo='" + this.Tbx_ID.Text + "' ";
            DbHelperSQL.ExecuteSql(DoSql);
            btn_Chcek.Text = "反财务审批";
            AM.Add_Logs("财务审批成功" + this.Tbx_ID.Text);
            AlertAndRedirect("财务审批成功！", "Sales_ShipWareOut_View.aspx?ID=" + this.Tbx_ID.Text + "");
        }
    }


    public string s_GetHouse(string s_DirectOutNO)
    {
        string s_Return = "";
        try
        {
            KNet.BLL.KNet_WareHouse_DirectOutList Bll = new KNet.BLL.KNet_WareHouse_DirectOutList();
            KNet.Model.KNet_WareHouse_DirectOutList Model = Bll.GetModelB(s_DirectOutNO);
            s_Return = base.Base_GetHouseName(Model.HouseNo);
        }
        catch { }
        return s_Return;
    }
    protected void Btn_SaveOnClick(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        string s_ID = this.Tbx_ID.Text;

        KNet.Model.Sc_Expend_Manage model = new KNet.Model.Sc_Expend_Manage();
        KNet.BLL.Sc_Expend_Manage bll = new KNet.BLL.Sc_Expend_Manage();

        if (Chk_IsDetails.Checked)
        {
            string s_Return=this.SetValue(model);
            if (s_Return != "")
            {
                Alert(s_Return);
                return;
            }
        }
        try
        {
            if (btn_Chcek.Text == "审批")
            {
                string DoSql = "update KNet_WareHouse_DirectOutList  set DirectOutCheckYN=2,DirectOutCheckStaffNo ='" + AM.KNet_StaffNo + "'  where  DirectOutNo='" + this.Tbx_ID.Text + "' ";
                DbHelperSQL.ExecuteSql(DoSql);
                btn_Chcek.Text = "反审批";
                if (Chk_IsDetails.Checked)
                {
                    bll.Add(model);
                    AM.Add_Logs("原材料消耗增加" + this.Tbx_ID.Text);
                    AlertAndRedirect("原材料消耗成功！", "Sales_ShipWareOut_View.aspx?Type=1&ID=" + this.Tbx_ID.Text + "");
                }
                else
                {

                    AM.Add_Logs("审核成功" + this.Tbx_ID.Text);
                    AlertAndRedirect("审核成功！", "Sales_ShipWareOut_View.aspx?Type=1&ID=" + this.Tbx_ID.Text + "");
                }
            }
        }
        catch (Exception ex)
        {
            Alert(ex.Message);
        }
    }


    private string  SetValue(KNet.Model.Sc_Expend_Manage model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
             model.SEM_ID = base.GetNewID("Sc_Expend_Manage", 1);
            
            try
            {
                model.SEM_Stime = DateTime.Parse(this.Lbl_CwTime.Text);
            }
            catch { }
            model.SEM_SuppNo = this.Lbl_HouseNo.Text;
            model.SEM_CustomerName = this.Lbl_Customer.Text;
            model.SEM_DutyPerson = AM.KNet_StaffNo;
            model.SEM_Type = 1;
            try
            {
                model.SEM_RkTime = DateTime.Parse(this.Tbx_RkTime.Text);
            }
            catch { }
            try
            {
                model.SEM_WwTime = DateTime.Parse(this.Tbx_WwTime.Text);
            }
            catch { }
            model.SEM_RkPerson = this.Ddl_RkPerson.SelectedValue;
            model.SEM_WwPerson = this.Ddl_WwPerson.SelectedValue;
            model.SEM_Remarks = "";
            model.SEM_Creator = AM.KNet_StaffNo;
            model.SEM_CTime = DateTime.Now;
            model.SEM_Mendor = AM.KNet_StaffNo;
            model.SEM_MTime = DateTime.Now;
            model.SEM_DirectOutNO = this.Tbx_ID.Text;
            //单号
            model.SEM_RCRKCode = GetIDByMonth(0, "4");
            ///成品消耗
            ArrayList arr_RcDetails = new ArrayList();
            int i_Num = 0;
            for (int i = 0; i < this.MyGridView1.Rows.Count; i++)
            {
                KNet.Model.Sc_Expend_Manage_RCDetails Mode_RkDetails = new KNet.Model.Sc_Expend_Manage_RCDetails();
                Mode_RkDetails.SER_ID = base.GetNewID("Sc_Expend_Manage_RCDetails", 1);
                TextBox Tbx_ProductsBarCode = (TextBox)this.MyGridView1.Rows[i].Cells[0].FindControl("Tbx_ProductsBarCode");
                DropDownList Ddl_House = (DropDownList)MyGridView1.Rows[i].Cells[0].FindControl("Ddl_House");
                TextBox Tbx_DID = (TextBox)MyGridView1.Rows[i].Cells[0].FindControl("Tbx_DID");
                TextBox Tbx_Number = (TextBox)MyGridView1.Rows[i].Cells[0].FindControl("Tbx_Number");
                TextBox Tbx_Price = (TextBox)MyGridView1.Rows[i].Cells[0].FindControl("Tbx_Price");
                decimal d_Price = decimal.Parse(Tbx_Price.Text == "" ? "0" : Tbx_Price.Text);
                CheckBox Chk_Chbk = (CheckBox)MyGridView1.Rows[i].Cells[0].FindControl("Chbk");
                if (Chk_Chbk.Checked)
                {
                    Mode_RkDetails.SER_ProductsBarCode = Tbx_ProductsBarCode.Text;
                    Mode_RkDetails.SER_OrderDetailID = Tbx_DID.Text;
                    Mode_RkDetails.SER_ScNumber = int.Parse(Tbx_Number.Text);
                    Mode_RkDetails.SER_ScPrice = d_Price;
                    Mode_RkDetails.SER_ScMoney = d_Price * int.Parse(Tbx_Number.Text);
                    Mode_RkDetails.SER_SEMID = model.SEM_ID;
                    Mode_RkDetails.SER_HouseNo = Ddl_House.SelectedValue;
                    arr_RcDetails.Add(Mode_RkDetails);
                    i_Num++;
                }
            }
            model.arr_Details = arr_RcDetails;
            ///物料消耗
            ArrayList arr_MaterDetails = new ArrayList();
            for (int i = 0; i < this.MyGridView2.Rows.Count; i++)
            {
                DropDownList Ddl_RkHouse = (DropDownList)MyGridView2.Rows[i].Cells[0].FindControl("Ddl_RkHouse");
                DropDownList Ddl_House = (DropDownList)MyGridView2.Rows[i].Cells[0].FindControl("Ddl_House");
                TextBox Tbx_ProductsBarCode = (TextBox)MyGridView2.Rows[i].Cells[0].FindControl("Tbx_ProductsBarCode");
                TextBox Tbx_Remarks = (TextBox)MyGridView2.Rows[i].Cells[0].FindControl("Tbx_Remarks");
                TextBox Tbx_Number = (TextBox)MyGridView2.Rows[i].Cells[0].FindControl("Tbx_Number");

                TextBox Tbx_KCNumber = (TextBox)MyGridView2.Rows[i].Cells[0].FindControl("Tbx_KCNumber");
                string SED_RkPrice = MyGridView2.Rows[i].Cells[5].Text;
                KNet.Model.Sc_Expend_Manage_MaterDetails Mode_MaterDetails = new KNet.Model.Sc_Expend_Manage_MaterDetails();

                CheckBox Chk_Chbk = MyGridView2.Rows[i].FindControl("Chbk_ID") as CheckBox;
                if (Chk_Chbk.Checked)
                {

                    //try
                    //{
                    //    if (decimal.Parse(Tbx_KCNumber.Text) < decimal.Parse(Tbx_Number.Text))
                    //    {
                    //        return "不能小于库结存！";
                    //    }
                    //}
                    //catch
                    //{
                    //    return "数量错误！";
                    //}
                    //委外发料
                    KNet.Model.Sc_Expend_Manage_MaterDetails Mode_MaterDetails1 = new KNet.Model.Sc_Expend_Manage_MaterDetails();
                    Mode_MaterDetails1.SED_SEMID = model.SEM_ID;
                    Mode_MaterDetails1.SED_HouseNo = this.Lbl_HouseNo.Text;
                    Mode_MaterDetails1.SED_ProductsBarCode = Tbx_ProductsBarCode.Text;
                    Mode_MaterDetails1.SED_Remarks = Tbx_Remarks.Text;
                    Mode_MaterDetails1.SED_FromHouseNo = "130088401935635079";//原材料库
                    Mode_MaterDetails1.SED_Code = GetIDByMonth(0, "4");

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
                    Mode_MaterDetails1.SED_RkPerson = this.Ddl_RkPerson.SelectedValue;
                    try
                    {
                        Mode_MaterDetails1.SED_RkTime = DateTime.Parse(this.Tbx_RkTime.Text);
                    }
                    catch { }
                    Mode_MaterDetails1.SED_Type = 4;
                    if (Mode_MaterDetails1.SED_RkNumber > 0)
                    {
                        arr_MaterDetails.Add(Mode_MaterDetails1);
                    }

                    //委外消耗
                    KNet.Model.Sc_Expend_Manage_MaterDetails Mode_MaterDetails2 = new KNet.Model.Sc_Expend_Manage_MaterDetails();
                    Mode_MaterDetails2.SED_SEMID = model.SEM_ID;
                    Mode_MaterDetails2.SED_HouseNo = this.Lbl_HouseNo.Text;
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
                    Mode_MaterDetails2.SED_RkPerson = this.Ddl_RkPerson.SelectedValue;
                    try
                    {
                        Mode_MaterDetails2.SED_RkTime = DateTime.Parse(this.Tbx_RkTime.Text);
                    }
                    catch { }
                    Mode_MaterDetails2.SED_Type = 5;
                    Mode_MaterDetails2.SED_Code = GetIDByMonth(0, "5");
                    if (Mode_MaterDetails2.SED_RkNumber > 0)
                    {
                        arr_MaterDetails.Add(Mode_MaterDetails2);
                    }
                }
            }
            model.arr_MaterDetails = arr_MaterDetails;

        
            return "";
        }
        catch
        {
            return "错误！";
        }
    }


    private string GetIDByMonth(int i_num,string s_Type)
    {
        string s_Return = "";
        try
        {
            string s_Sql = "Select isnull(Max(SED_Code),'') from Sc_Expend_Manage_MaterDetails Where Isnull(SED_Type,'0')='" + s_Type + "' and Year(SED_RkTime)='" + DateTime.Now.Year.ToString() + "' and Month(SED_RkTime)='" + DateTime.Now.Month.ToString() + "' ";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            if (Dtb_Result.Rows.Count > 0)
            {
                if (Dtb_Result.Rows[0][0].ToString() == "")
                {
                    s_Return = DateTime.Today.ToString("yyyyMM") + "001";
                }
                s_Return = Convert.ToString(int.Parse(Dtb_Result.Rows[0][0].ToString()) + 1 + i_num);
            }
            else
            {
                s_Return = DateTime.Today.ToString("yyyyMM") + "001";
            }
        }
        catch { }
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
            base.Base_DropWareHouseBindNoSelect(Ddl_House, "  SuppNo='129841337340625000' and KSW_Type='1' ");//杭州士腾的库存
        }
    }
}
