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
/// 发货 跟踪信息 添加
/// </summary>
public partial class Cw_Accounting_Payment_Simple_Add : BasePage
{
    public string s_MyTable_Detail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "新增应付款计划";

        if (!IsPostBack)
        {
            this.BeginQuery("Select * from PB_Basic_Wl ");
            this.QueryForDataTable();
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
            else
            {
                if (Request.QueryString["CheckNo"] != null && Request.QueryString["CheckNo"] != "")
                {
                    string s_ID = Request.QueryString["CheckNo"].ToString();
                    KNet.BLL.Cg_Order_Checklist BLL_Cg = new KNet.BLL.Cg_Order_Checklist();
                    KNet.Model.Cg_Order_Checklist Model_Cg = BLL_Cg.GetModel(s_ID);
                    KNet.BLL.Cg_Order_Checklist_Details BLL_CgDetails = new KNet.BLL.Cg_Order_Checklist_Details();
                    this.Tbx_Money.Text = BLL_CgDetails.GetTotalNet(s_ID);
                    base.Base_DropDutyPerson(this.Ddl_DutyPerson);
                    if (Model_Cg != null)
                    {
                        this.Tbx_CheckNo.Text = Model_Cg.COC_Code;
                        if (Model_Cg.COC_SuppNo != "")
                        {
                            this.Tbx_SuppNo.Text = Model_Cg.COC_SuppNo;
                            this.Tbx_SuppName.Text = base.Base_GetSupplierName(Model_Cg.COC_SuppNo);
                        }
                        else
                        {
                            KNet.BLL.KNet_Sys_WareHouse Bll_WareHouse = new KNet.BLL.KNet_Sys_WareHouse();
                            KNet.Model.KNet_Sys_WareHouse Model_WareHouse = Bll_WareHouse.GetModel(Model_Cg.COC_HouseNo);
                            if (Model_WareHouse != null)
                            {
                                this.Tbx_SuppNo.Text = Model_WareHouse.SuppNo;
                                this.Tbx_SuppName.Text = base.Base_GetSupplierName(Model_WareHouse.SuppNo);
                            }
                        }
                        KNet.BLL.Cw_Accounting_Payment BLl_Cw = new KNet.BLL.Cw_Accounting_Payment();
                        DataSet Dts_Table = BLl_Cw.GetList(" CAP_FID='" + s_ID + "'");
                        if (Dts_Table.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                            {
                                s_MyTable_Detail += " <tr>";
                                s_MyTable_Detail += "<td align=\"left\"><A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a></td>";
                                s_MyTable_Detail += "<td align=\"left\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\"  style=\"width:70px;\"  Name=\"Order_" + Convert.ToString(i + 1) + "\" value='" + Convert.ToString(i + 1) + "'></td>";
                                s_MyTable_Detail += "<td align=\"left\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\';CheckMoney(this);\"  style=\"width:70px;\"  Name=\"Money_" + Convert.ToString(i + 1) + "\" value='" + Dts_Table.Tables[0].Rows[i]["CAP_ReceiveMoney"].ToString() + "'></td>";
                                s_MyTable_Detail += "<td align=\"left\"><input type=\"text\" Class=\"Wdate\" onFocus=\"WdatePicker()\"  style=\"width:100px;\"  Name=\"Time_" + Convert.ToString(i + 1) + "\" value='" + DateTime.Parse(Dts_Table.Tables[0].Rows[i]["CAP_STime"].ToString()).ToShortDateString() + "'></td>";
                                s_MyTable_Detail += "<td align=\"left\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\"   style=\"width:170px;\"  Name=\"Remarks_" + Convert.ToString(i + 1) + "\"  value='" + Dts_Table.Tables[0].Rows[i]["CAP_Details"].ToString() + "'></td>";
                                s_MyTable_Detail += "</tr>";
                            }
                            this.Tbx_Num.Text = Convert.ToString(Dts_Table.Tables[0].Rows.Count );
                        }
                        else
                        {
                            s_MyTable_Detail += " <tr>";
                            s_MyTable_Detail += "<td align=\"left\"><A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a></td>";
                            s_MyTable_Detail += "<td align=\"left\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\"  style=\"width:70px;\"  Name=\"Order_1\" value='1'></td>";
                            s_MyTable_Detail += "<td align=\"left\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\';CheckMoney(this);\"  style=\"width:70px;\"  Name=\"Money_1\" value='" + this.Tbx_Money.Text + "'></td>";
                            s_MyTable_Detail += "<td align=\"left\"><input type=\"text\" Class=\"Wdate\" onFocus=\"WdatePicker()\"  style=\"width:100px;\"  Name=\"Time_1\" value='" + DateTime.Now.ToShortDateString() + "'></td>";
                            s_MyTable_Detail += "<td align=\"left\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\"   style=\"width:170px;\"  Name=\"Remarks_1\" ></td>";
                            s_MyTable_Detail += "</tr>";
 
                        }
                    }

                    this.Lbl_Title.Text = " 新增应付款计划";
                }
                else
                {
                    Response.Write("<script language=javascript>alert('非法请求参数！');window.close();</script>");
                    Response.End();
                }
            }

        }
    }


    /// <summary>
    /// 确定添加
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Btn_SaveOnClick(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();

        decimal d_HaveMoney = 0;
        KNet.BLL.Cw_Accounting_Payment BLL = new KNet.BLL.Cw_Accounting_Payment();
        ArrayList arr_Details = new ArrayList();
        int i_Num = int.Parse(this.Tbx_Num.Text);
        for (int i = 1; i <= i_Num; i++)
        {
            string s_Money = Request["Money_" + i.ToString() + ""] == null ? "" : Request["Money_" + i.ToString() + ""].ToString();
            string s_Order = Request["Order_" + i.ToString() + ""] == null ? "" : Request["Order_" + i.ToString() + ""].ToString();
            string s_Time = Request["Time_" + i.ToString() + ""] == null ? "" : Request["Time_" + i.ToString() + ""].ToString();
            string s_Remarks = Request["Remarks_" + i.ToString() + ""] == null ? "" : Request["Remarks_" + i.ToString() + ""].ToString();
            if (s_Money != "")
            {
                KNet.Model.Cw_Accounting_Payment model = new KNet.Model.Cw_Accounting_Payment();
                model.CAP_Code = GetCwCode(i);
                model.CAP_CustomerValue = this.Tbx_SuppNo.Text;
                model.CAP_Type = 0;
                model.CAP_FID = this.Tbx_CheckNo.Text;
                try
                {
                    model.CAP_STime = DateTime.Parse(s_Time);
                }
                catch { }
                model.CAP_ReceiveMoney = Decimal.Parse(s_Money);
                d_HaveMoney += Decimal.Parse(s_Money);
                model.CAP_State = int.Parse(s_Order);
                model.CAP_Details = s_Remarks;
                model.CAP_DutyPerson = AM.KNet_StaffNo;
                model.CAP_CTime = DateTime.Now;
                model.CAP_Creator = AM.KNet_StaffNo;
                model.CAP_MTime = DateTime.Now;
                model.CAP_Mender = AM.KNet_StaffNo;
                arr_Details.Add(model);
            }
        }
            try
            {
                if (BLL.Add(arr_Details))
                {
                    if (d_HaveMoney >= decimal.Parse(this.Tbx_Money.Text))
                    {
                        KNet.BLL.Cg_Order_Checklist Bll_Cg = new KNet.BLL.Cg_Order_Checklist();
                        KNet.Model.Cg_Order_Checklist Model_Cg = new KNet.Model.Cg_Order_Checklist();
                        Model_Cg.COC_Code = this.Tbx_CheckNo.Text;
                        Model_Cg.COC_IsPayMent = 1;
                        Bll_Cg.UpdateIsPayMent(Model_Cg);
                    }
                    AdminloginMess LogAM = new AdminloginMess();
                    LogAM.Add_Logs("采购管理--->付款计划--->付款计划添加 操作成功！付款计划单号：");
                    Response.Write("<script>alert('付款计划添加 成功！');windows.close();</script>");
                    Response.End();
                }
            }
            catch
            {
                Response.Write("<script>alert('跟踪添加 失败！');history.back(-1);</script>");
                Response.End();
            }
    }

    public string GetCwCode(int i_Num)
    {
        string s_Code = "";
        try
        {
            KNet.BLL.KNet_WareHouse_DirectOutList BLL = new KNet.BLL.KNet_WareHouse_DirectOutList();
            this.BeginQuery("Select Max(isNUll(CAP_Code,'')) from Cw_Accounting_Payment Where year(CAP_CTime)='" + DateTime.Now.Year.ToString() + "'  and Month(CAP_CTime)='" + DateTime.Now.Month.ToString() + "'");
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                if (Dtb_Table.Rows[0][0].ToString() != "")
                {
                    s_Code = Dtb_Table.Rows[0][0].ToString().Substring(0, 6) + "-" + Convert.ToString(int.Parse("1" + Dtb_Table.Rows[0][0].ToString().Substring(7, 3)) + 1 + i_Num).Substring(1, 3);
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
