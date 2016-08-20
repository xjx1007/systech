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


public partial class Cw_Accounting_Pay_WithDirectOut : BasePage
{
    public string s_MyTable_Detail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        Ajax.Utility.RegisterTypeForAjax(typeof(Cw_Accounting_Pay_WithDirectOut));
        if (!Page.IsPostBack)
        {
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string s_PayMentID = Request.QueryString["PayMentID"] == null ? "" : Request.QueryString["PayMentID"].ToString();

            this.Tbx_ID.Text = s_ID;
            base.Base_DropBasicCodeBind(this.Ddl_Type, "766");
            this.Ddl_Type.SelectedValue = "0";

            if (s_ID == "")//新增
            {
                this.Lbl_Title.Text = "新增收款单";
                base.Base_DropDutyPerson(this.Ddl_DutyPerson);
                //base.Base_DropBasicCodeBind(this.Ddl_State, "172", false);
                this.Tbx_PayTime.Text = DateTime.Now.ToShortDateString();
                this.Tbx_FID.Text = GetCwCode(1, this.Tbx_PayTime.Text);
                Base_DdlBankbind(this.Ddl_Account);
            }
            else
            {
                this.Tbx_ID.Text = s_ID;
                this.Lbl_Title.Text = "修改收款单";
                base.Base_DropDutyPerson(this.Ddl_DutyPerson);
                Base_DdlBankbind(this.Ddl_Account);
                // base.Base_DropBasicCodeBind(this.Ddl_State, "172", false);
                this.Tbx_PayTime.Text = DateTime.Now.ToShortDateString();
                ShowInfo(s_ID);
            }
            if (AM.CheckLogin(this.Lbl_Title.Text) == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            if (s_PayMentID != "")
            {
                KNet.BLL.Cw_Accounting_Payment Bll = new KNet.BLL.Cw_Accounting_Payment();
                DataSet Dts_Table = Bll.GetList(" a.CAP_ID='" + s_PayMentID + "' ");
                if (Dts_Table.Tables[0].Rows.Count > 0)
                {
                    this.Tbx_SuppNo.Text = Dts_Table.Tables[0].Rows[0]["CAP_CustomerValue"].ToString();
                    this.Tbx_SuppName.Text = base.Base_GetCustomerName(Dts_Table.Tables[0].Rows[0]["CAP_CustomerValue"].ToString());
                    string s_PayState = Dts_Table.Tables[0].Rows[0]["CAP_PayState"].ToString();
                    if (s_PayState == "2")
                    {
                        AlertAndGoBack("该应收单已收！");
                    }
                }
                decimal d_TotalMoney = 0;
                for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                {
                    d_TotalMoney += decimal.Parse(Dts_Table.Tables[0].Rows[0]["CAP_ReceiveMoney"].ToString());
                }
                this.Tbx_Money.Text = d_TotalMoney.ToString();
                /*   this.MyGridView1.DataSource = Dts_Table;
                   this.MyGridView1.DataKeyNames = new string[] { "CAP_ID" };
                   this.MyGridView1.DataBind();*/
            }
        }
    }

    [Ajax.AjaxMethod()]
    public string GetDetails(string s_ID)
    {

        string[] s_Details = s_ID.Split('|');
        string s_Return = "", s_Sql = "";
        try
        {
            s_Sql = " Select * from v_OutDetails_Hx  ";
            s_Sql += " where ID in ('" + s_Details[0].Replace(",", "','") + "')  and CAO_ID in ('" + s_Details[1].Replace(",", "','") + "') and Type in ('" + s_Details[2].Replace(",", "','") + "') ";
            this.BeginQuery(s_Sql);
            this.QueryForDataSet();
            DataSet ds = this.Dts_Result;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                s_Return += ds.Tables[0].Rows[i]["ID"].ToString() + "," + ds.Tables[0].Rows[i]["DirectOutNo"].ToString() + "," + ds.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "," + base.Base_GetProductsEdition(ds.Tables[0].Rows[i]["ProductsBarCode"].ToString());
                s_Return += "," + ds.Tables[0].Rows[i]["v_LeftMoney"].ToString() + "," + ds.Tables[0].Rows[i]["KWD_SalesUnitPrice"].ToString() + "," + DateTime.Parse(ds.Tables[0].Rows[i]["KWD_CWOutTime"].ToString()).ToShortDateString() + "," + ds.Tables[0].Rows[i]["KWD_SalesTotalNet"].ToString() + "," + ds.Tables[0].Rows[i]["DirectOutAmount"].ToString() + "," + ds.Tables[0].Rows[i]["CAO_ID"].ToString() + "|";
            }
            return s_Return;
        }
        catch
        {
            return s_Return;
        }
    }
    private void ShowInfo(string s_ID)
    {
        KNet.BLL.Cw_Accounting_Pay bll = new KNet.BLL.Cw_Accounting_Pay();
        KNet.Model.Cw_Accounting_Pay Model = bll.GetModel(s_ID);
        try
        {
            this.Tbx_FID.Text = Model.CAA_Code;
            this.Ddl_DutyPerson.SelectedValue = Model.CAA_DutyPerson;
            this.Tbx_SuppNo.Text = Model.CAA_CustomerValue;
            //this.Tbx_SuppName.Text = base.Base_GetSupplierOrCustomerName(Model.CAA_CustomerValue);
            this.Tbx_SuppName.Text = base.Base_GetCustomerName(Model.CAA_CustomerValue);
            this.Ddl_Account.SelectedValue = Model.CAA_Account;
            this.Tbx_PayTime.Text = DateTime.Parse(Model.CAA_PayTime.ToString()).ToShortDateString();
            this.Tbx_Money.Text = Model.CAA_PayMoney.ToString();
            this.Tbx_Details.Text = Model.CAA_Details.ToString();
            this.Tbx_BillCode.Text = Model.CAA_BillCode;
            try
            {
                this.Tbx_StartDate.Text = DateTime.Parse(Model.CAA_StartDateTime.ToString()).ToShortDateString();
                this.Tbx_EndDate.Text = DateTime.Parse(Model.CAA_EndDateTime.ToString()).ToShortDateString();
            }
            catch
            { }
            this.Ddl_Type.SelectedValue = Model.CAP_Type.ToString();
            this.BeginQuery(" Select a.*,c.CAP_PayMoney-b.CAY_PayMoney as CAP_PayMoney,c.CAP_ReceiveMoney-c.CAP_PayMoney+b.CAY_PayMoney as leftMoney from Cw_Accounting_Payment a join Cw_Accounting_Pay_details b on a.CAP_ID=b.CAY_CAPID join v_Pay_Sum c on c.CAP_ID=a.CAP_ID where CAY_CAAID='" + s_ID + "'");
            this.QueryForDataSet();
            DataSet Dts_table = this.Dts_Result;



            KNet.BLL.Cw_Bill_DirectOut_PayDetails bll_Details = new KNet.BLL.Cw_Bill_DirectOut_PayDetails();
             Dts_table = bll_Details.GetList(" CBDP_PayMentID='" + Model.CAA_ID + "'  order by CBDP_CTime ");
            decimal d_Total=0;
            if (Dts_table.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_table.Tables[0].Rows.Count; i++)
                {

                    s_MyTable_Detail += " <tr> ";
                    s_MyTable_Detail += " <td  class=\"ListHeadDetails\"><A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a></td>";

                    KNet.BLL.KNet_WareHouse_DirectOutList_Details bll_DircetOutDetails = new KNet.BLL.KNet_WareHouse_DirectOutList_Details();
                    KNet.Model.KNet_WareHouse_DirectOutList_Details Model_DircetOutDetails = bll_DircetOutDetails.GetModel(Dts_table.Tables[0].Rows[i]["CBDP_DetailsID"].ToString());
                    if (Model_DircetOutDetails != null)
                    {
                        KNet.BLL.KNet_WareHouse_DirectOutList bll_DircetOut = new KNet.BLL.KNet_WareHouse_DirectOutList();
                        KNet.Model.KNet_WareHouse_DirectOutList Model_DircetOut = bll_DircetOut.GetModelB(Model_DircetOutDetails.DirectOutNo);
                        s_MyTable_Detail += " <td  class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ID_" + i.ToString() + "\" Value=\"" + Model_DircetOutDetails.ID + "\"><input type=\"hidden\"  Name=\"FPOutID_" + i.ToString() + "\" Value=\"" + Dts_table.Tables[0].Rows[i]["CBDP_FPOutID"].ToString() + "\">" + Model_DircetOut.DirectOutNo + "</td>";
                        s_MyTable_Detail += " <td  class=\"ListHeadDetails\"><input type=\"hidden\" ID=\"DirectOutTime_" + i.ToString() + "'\"   Name=\"DirectOutTime_" + i.ToString() + "\" value='" + DateTime.Parse(Model_DircetOut.KWD_CWOutTime.ToString()).ToShortDateString() + "'>" + DateTime.Parse(Model_DircetOut.KWD_CWOutTime.ToString()).ToShortDateString() + "</td>";

                        s_MyTable_Detail += " <td  class=\"ListHeadDetails\"><input type=\"hidden\" ID=\"ProductsBarCode_" + i.ToString() + "\"   Name=\"ProductsBarCode_" + i.ToString() + "\" value='" + Model_DircetOutDetails.ProductsBarCode + "'>" + base.Base_GetProductsEdition_Link(Model_DircetOutDetails.ProductsBarCode) + "</td>";
                        s_MyTable_Detail += " <td  class=\"ListHeadDetails\">" + Model_DircetOutDetails.DirectOutAmount + "</td>";

                    }
                    s_MyTable_Detail += " <td  class=\"ListHeadDetails\">" + Model_DircetOutDetails.KWD_SalesUnitPrice.ToString() + "</td>";
                    s_MyTable_Detail += " <td  class=\"ListHeadDetails\">" + Dts_table.Tables[0].Rows[i]["CBDP_Money"].ToString() + "</td>";
                    s_MyTable_Detail += " <td  class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\';sum()\" style=\"width:170px;\" Name=\"Tbx_Money_" + i.ToString() + "\" value=" + Dts_table.Tables[0].Rows[i]["CBDP_Money"].ToString() + "> </td>";
                    d_Total+=decimal.Parse( Dts_table.Tables[0].Rows[i]["CBDP_Money"].ToString());
                    s_MyTable_Detail += " </tr> ";
                }
            }
            this.Tbx_Num.Text = Dts_table.Tables[0].Rows.Count.ToString();
            this.Tbx_DetailsMoney.Text=d_Total.ToString();
            this.Tbx_LeftMoney.Text = Convert.ToString(Model.CAA_PayMoney - d_Total);
            /*
            this.MyGridView1.DataSource = Dts_table;
            this.MyGridView1.DataKeyNames = new string[] { "CAP_ID" };
            this.MyGridView1.DataBind();*/
        }
        catch
        { }
    }
    private bool SetValue(KNet.Model.Cw_Accounting_Pay model)
    {
        AdminloginMess AM = new AdminloginMess();
        try
        {
            ArrayList arr_Details = new ArrayList();
            ArrayList arr_Details1 = new ArrayList();
            model.CAA_CustomerValue = this.Tbx_SuppNo.Text;
            model.CAA_Account = this.Ddl_Account.SelectedValue;
            model.CAA_DutyPerson = this.Ddl_DutyPerson.SelectedValue;
            model.CAA_PayMoney = decimal.Parse(this.Tbx_Money.Text);
            model.CAA_PayTime = DateTime.Parse(this.Tbx_PayTime.Text);
            model.CAA_Details = this.Tbx_Details.Text;
            model.CAA_Creator = AM.KNet_StaffNo;
            model.CAA_CTime = DateTime.Now;
            model.CAA_MTime = DateTime.Now;
            model.CAA_Mender = AM.KNet_StaffNo;
            model.CAA_Code = this.Tbx_FID.Text;
            model.CAA_BillCode = this.Tbx_BillCode.Text;
            try
            {
                model.CAA_DetailsTotalMoney = decimal.Parse(this.Tbx_DetailsMoney.Text);
                model.CAA_leftMoney = decimal.Parse(this.Tbx_LeftMoney.Text);
            }
            catch
            { }

            try
            {
                model.CAP_Type = int.Parse(this.Ddl_Type.SelectedValue);
            }
            catch { }
            try
            {
                model.CAA_StartDateTime = DateTime.Parse(this.Tbx_StartDate.Text);
                model.CAA_EndDateTime = DateTime.Parse(this.Tbx_EndDate.Text);
                model.CAP_YFOutDate = DateTime.Parse("1900-1-1"); ;
            }
            catch
            {
                model.CAA_StartDateTime = DateTime.Parse("1900-1-1"); ;
                model.CAA_EndDateTime = DateTime.Parse("1900-1-1"); ;
                model.CAP_YFOutDate = DateTime.Parse("1900-1-1"); ;
            }
            model.CAA_Type = 1;
            int i_Num = int.Parse(this.Tbx_Num.Text);

            int i_Count = 0;
            for (int i = 0; i < i_Num; i++)
            {

                ArrayList arr_DirectOutDetails = new ArrayList();
                KNet.Model.Cw_Bill_DirectOut_PayDetails Model_PayDetails = new KNet.Model.Cw_Bill_DirectOut_PayDetails();

                string s_DetailsID = Request["ID_" + i + ""] == null ? "" : Request["ID_" + i + ""].ToString();
                string s_Money = Request["Tbx_Money_" + i + ""] == null ? "" : Request["Tbx_Money_" + i + ""].ToString();
                string s_FPOutID = Request["FPOutID_" + i + ""] == null ? "" : Request["FPOutID_" + i + ""].ToString();

                
                if (s_DetailsID != "")
                {
                    Model_PayDetails.CBDP_ID = base.GetMainID(i);
                    Model_PayDetails.CBDP_Code = base.GetNewID("Cw_Bill_DirectOut_PayDetails", 1);
                    Model_PayDetails.CBDP_PayMentID = model.CAA_ID;
                    Model_PayDetails.CBDP_DetailsID = s_DetailsID;
                    Model_PayDetails.CBDP_Money = decimal.Parse(s_Money);
                    Model_PayDetails.CBDP_Creator = AM.KNet_StaffNo;
                    Model_PayDetails.CBDP_CTime = DateTime.Now;
                    Model_PayDetails.CBDP_Mender = AM.KNet_StaffNo;
                    Model_PayDetails.CBDP_MTime = DateTime.Now;

                    Model_PayDetails.CBDP_FPOutID = s_FPOutID;

                    arr_Details1.Add(Model_PayDetails);
                }
            }

            /*
            for (int i = 0; i < this.MyGridView1.Rows.Count; i++)
            {
                CheckBox Chk = (CheckBox)this.MyGridView1.Rows[i].FindControl("Chbk");
                if (Chk.Checked)
                {
                    TextBox Tbx_PayMoney = (TextBox)this.MyGridView1.Rows[i].FindControl("Tbx_PayMoney");
                    string s_PayMentID = this.MyGridView1.DataKeys[i].Value.ToString();
                    KNet.Model.Cw_Accounting_Pay_Details Model_Details = new KNet.Model.Cw_Accounting_Pay_Details();
                    Model_Details.CAY_CAAID = this.Tbx_Code.Text;
                    Model_Details.CAY_PayMoney = decimal.Parse(Tbx_PayMoney.Text);
                    Model_Details.CAY_CAPID = s_PayMentID;
                    arr_Details.Add(Model_Details);
                }
            }*/
            model.arr_FpDetails = arr_Details1;
            return true;
        }
        catch
        {
            return false;
        }
    }

    private bool GethxDetails(string s_Id)
    {
        bool b_true = false;
        try
        {
            string s_Sql = "Select * from Cw_Bill_DirectOut_PayDetails where CBDP_PayMentID='" + s_Id + "'";
            this.BeginQuery(s_Sql);
            DataTable Dtb_table = (DataTable)this.QueryForDataTable();
            if (Dtb_table.Rows.Count > 0)
            {
                b_true = true;
            }
        }
        catch
        { }
        return b_true;
    }
    protected void Btn_SaveOnClick(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.Model.Cw_Accounting_Pay model = new KNet.Model.Cw_Accounting_Pay();
        KNet.BLL.Cw_Accounting_Pay bll = new KNet.BLL.Cw_Accounting_Pay();

        if (this.SetValue(model) == false)
        {
            Alert("系统错误！");
            return;
        }
        if (this.Tbx_ID.Text != "")//修改
        {
            try
            {
                model.CAA_ID = this.Tbx_ID.Text;
                bll.Update(model);
                AM.Add_Logs("收款单核销" + this.Tbx_ID.Text);
                AlertAndRedirect("核销成功！", "Cw_Accounting_Pay_List.aspx");
            }
            catch { }
        }
        else
        {
            try
            {
                model.CAA_ID = base.GetMainID();
                bll.Add(model);
                AM.Add_Logs("收款单增加" + model.CAA_ID);
                this.BeginQuery("select KSC_DutyPerson from KNet_Sales_ClientList where CustomerValue='" + model.CAA_CustomerValue + "'");
                this.QueryForDataTable();
                string s_DutyPerson = "130273944327386905,130221318707334535,129785819485620667";
                if (this.Dtb_Result.Rows.Count > 0)
                {
                    s_DutyPerson += "," + Dtb_Result.Rows[0][0].ToString();
                }
                base.Base_SendMessage(s_DutyPerson, KNetPage.KHtmlEncode("有 收款单新增 <a href='Web/Rece/Cw_Accounting_Pay_View.aspx?ID=" + model.CAA_ID + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.CAA_Code + "</a> ，敬请关注！"));
                AlertAndRedirect("新增成功！", "Cw_Accounting_Pay_List.aspx");
            }
            catch (Exception ex) { }
        }

    }
    public string GetCwCode(int i_Num, string s_Time)
    {
        string s_Code = "";
        try
        {
            KNet.BLL.KNet_WareHouse_DirectOutList BLL = new KNet.BLL.KNet_WareHouse_DirectOutList();
            string s_Sql = "Select isNUll(Max(CAA_Code),'') from Cw_Accounting_Pay Where year(CAA_CTime)=year('" + s_Time + "')  and Month(CAA_CTime)=Month('" + s_Time + "')";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                if (Dtb_Table.Rows[0][0].ToString() != "")
                {
                    s_Code = Dtb_Table.Rows[0][0].ToString().Substring(0, 6) + "-" + Convert.ToString(int.Parse("1" + Dtb_Table.Rows[0][0].ToString().Substring(7, 3)) + i_Num).Substring(1, 3);
                }
                else
                {
                    s_Code = DateTime.Today.ToString("yyyyMM") + "-001";
                }
            }
            else
            {
                s_Code = DateTime.Today.ToString("yyyyMM") + "-001";
            }
        }
        catch { }
        return s_Code;
    }
}
