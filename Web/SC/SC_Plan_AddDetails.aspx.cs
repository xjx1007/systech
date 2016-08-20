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
public partial class SC_Plan_AddDetials : BasePage
{
    public string s_DivStyle = "";
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("客户交货计划添加") == false)
            {
                BasePage.AlertAndRedirect("您未登陆系统或已超过，请重新登陆系统!", "Default.aspx");
            }
            else
            {
                string s_SuppNo = Request["SuppNo"] == null ? "" : Request["SuppNo"].ToString();

                // base.Base_DropDutyPerson(this.Ddl_Batch);
                string s_ProductsBarCode = Request.QueryString["ProductsBarCode"] == null ? "" : Request.QueryString["ProductsBarCode"].ToString();
                string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
                if (s_ID != "")
                {
                    this.Tbx_ID.Text = s_ID;
                    ShowDetails();
                }
            }
        }
    }

    private void ShowDetails()
    {
        if (this.Tbx_ID.Text != "")
        {
            StringBuilder Sb_Details = new StringBuilder();
            string s_Sql = "";
            s_Sql = "Select * from Knet_Procure_OrdersList_Details a join Knet_Procure_OrdersList b on a.OrderNo=b.OrderNo join v_OrderRK e on a.OrderNO=e.V_OrderNo where a.ID='" + this.Tbx_ID.Text + "'";
            this.BeginQuery(s_Sql);
            DataTable Dtb_Table = (DataTable)this.QueryForDataTable();
            if (Dtb_Table.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
                    Sb_Details.Append("<tr>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\" align=\"center\">" + Dtb_Table.Rows[i]["OrderNo"].ToString() + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\" align=\"center\">" + Dtb_Table.Rows[i]["ContractNos"].ToString() + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\" align=\"center\">" + GetCustmoerNameByContractNo(Dtb_Table.Rows[i]["ContractNos"].ToString()) + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetProductsEdition_Link(Dtb_Table.Rows[i]["ProductsBarCode"].ToString()) + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\" align=\"center\">" + Dtb_Table.Rows[i]["OrderAmount"].ToString() + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\" align=\"center\">" + Dtb_Table.Rows[i]["wrkNumber"].ToString() + "</td>");
                    Sb_Details.Append("</tr>");
                    this.Tbx_Number.Text = Dtb_Table.Rows[i]["wrkNumber"].ToString();
                    this.Tbx_EndTime.Text = base.DateToString(Dtb_Table.Rows[i]["OrderPreToDate"].ToString());
                    this.Tbx_OrderNo.Text = Dtb_Table.Rows[i]["OrderNo"].ToString();
                    this.Tbx_OrdTime.Text = base.DateToString(Dtb_Table.Rows[i]["OrderPreToDate"].ToString());
                    
                }
            }
            this.Lbl_SDetail.Text = Sb_Details.ToString();
            StringBuilder Sb_Details1 = new StringBuilder();
            s_Sql = "Select * from SC_Order_Time where SOT_FID='" + this.Tbx_ID.Text + "' order by SOT_CTime desc";
            this.BeginQuery(s_Sql);
            Dtb_Table = (DataTable)this.QueryForDataTable();
            if (Dtb_Table.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
                    Sb_Details1.Append("<tr>");
                    Sb_Details1.Append("<td class=\"ListHeadDetails\" align=\"center\">" + base.DateToString(Dtb_Table.Rows[i]["SOT_NewTime"].ToString()) + "</td>");
                    Sb_Details1.Append("<td class=\"ListHeadDetails\" align=\"center\">" + Dtb_Table.Rows[i]["SOT_Number"].ToString() + "</td>");
                    Sb_Details1.Append("<td class=\"ListHeadDetails\" align=\"center\">" + Dtb_Table.Rows[i]["SOT_Details"].ToString() + "</td>");
                    Sb_Details1.Append("<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetUserName(Dtb_Table.Rows[i]["SOT_Creator"].ToString()) + "</td>");
                    Sb_Details1.Append("<td class=\"ListHeadDetails\" align=\"center\">" + Dtb_Table.Rows[i]["SOT_CTime"].ToString() + "</td>");
                    Sb_Details1.Append("</tr>");
                }
            }
            this.Lbl_HistoryDetails.Text = Sb_Details1.ToString();
        }
    }
    private string GetCustmoerNameByContractNo(string ContractNos)
    {
        string s_Return = "";
        try
        {
            string s_Sql = "Select * from KNET_Sales_ContractList a where ContractNo in ('" + ContractNos.Replace(",", "','") + "')";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                s_Return += base.Base_GetCustomerName_Link(Dtb_Result.Rows[i]["CustomerValue"].ToString()) + "<br/>";
            }
            s_Return = s_Return.Substring(0, s_Return.Length - 5);
        }
        catch
        { }
        return s_Return;
    }

    private bool SetValue(KNet.Model.SC_Order_Time model)
    {

        AdminloginMess AM = new AdminloginMess();
        model.SOT_ID = base.GetMainID();
        model.SOT_FID = this.Tbx_ID.Text;
        try
        {
            model.SOT_NewTime = DateTime.Parse(this.Tbx_EndTime.Text);
            model.SOT_Number = int.Parse(this.Tbx_Number.Text);
            model.SOT_OldTime = DateTime.Parse(this.Tbx_OrdTime.Text);

        }
        catch
        { }

        model.SOT_Details = this.Tbx_Remarks.Text;
        model.SOT_Creator = AM.KNet_StaffNo;
        model.SOT_CTime = DateTime.Now;
        model.SOT_State = 0;
        try
        {
            return true;
        }
        catch
        {
            return false;
        }
    }


    protected void Btn_SaveOnClick(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        string s_ID = this.Tbx_ID.Text;

        KNet.Model.SC_Order_Time model = new KNet.Model.SC_Order_Time();
        KNet.BLL.SC_Order_Time bll = new KNet.BLL.SC_Order_Time();

        if (this.SetValue(model) == false)
        {
            Alert("系统错误！");
            return;
        }
        try
        {
            string s_Sql = " Update Knet_Procure_OrdersList set OrderPreToDate='" + this.Tbx_EndTime.Text + "' where OrderNo='" + this.Tbx_OrderNo.Text + "'  ";
            DbHelperSQL.ExecuteSql(s_Sql);
            bll.Add(model);
            AM.Add_Logs("客户交货计划增加" + this.Tbx_ID.Text);
            AlertAndClose("新增成功！");
        }
        catch (Exception ex) { }
    }

}
