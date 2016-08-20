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


public partial class Cw_Accounting_Init_Add : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            
            base.Base_DropDutyPerson(this.Ddl_DutyPerson);
            this.Lbl_Title.Text = "新增期初余额";
            base.Base_DropBasicCodeBind(this.Ddl_Type, "209",false);
            this.Ddl_Type.SelectedValue = "0";
            this.Tbx_STime.Text = "2015-5-31";
            if (s_ID!= "")
            {
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Tbx_Code.Text = base.GetNewID("Cw_Accounting_Init", 0);
                    this.Lbl_Title.Text = "复制期初余额";
                }
                else
                {
                    this.Lbl_Title.Text = "修改期初余额";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }
            else
            {
                this.Tbx_Code.Text = base.GetNewID("Cw_Accounting_Init", 0);

                Lbl_Details.Text = "<Table id=\"myTable\" width=\"100%\" border=\"0\" align=\"center\" cellpadding=\"5\" cellspacing=\"0\" class=\"crmTable\">";
                Lbl_Details.Text += "<tr><td colspan=\"11\" class=\"detailedViewHeader\" style=\"height: 15px\">";
                Lbl_Details.Text += "<b>初始化明细</b></td></tr>";
                Lbl_Details.Text += "<tr valign=\"top\"><td valign=\"top\" class=\"lvtCol\" align=\"right\" nowrap><b>工具</b></td>";
                Lbl_Details.Text += "<td class=\"lvtCol\" nowrap> <b>金额</b></td>";
                Lbl_Details.Text += "<td class=\"lvtCol\" nowrap><b>超期日期</b></td>";
                Lbl_Details.Text += "<td  class=\"lvtCol\" nowrap><b>备注</b></td></tr>";
                Lbl_Details.Text += " </table>";

            }
        }
    }

    private void ShowInfo(string s_ID)
    {
        KNet.BLL.Cw_Accounting_Init bll = new KNet.BLL.Cw_Accounting_Init();
        KNet.Model.Cw_Accounting_Init model = bll.GetModel(s_ID);
        try
        {
            this.Tbx_ID.Text = s_ID;
            this.Tbx_Code.Text = model.CAI_Code;
            this.Tbx_STime.Text = DateTime.Parse(model.CAI_STime.ToString()).ToShortDateString();
            this.Tbx_CustomerValue.Value = model.CAI_CustomerValue;
            this.Tbx_CustomerName.Text = base.Base_GetCustomerName(model.CAI_CustomerValue);
            this.SuppNo.Text = base.Base_GetSupplierName(model.CAI_SuppNo);
            this.SuppNoSelectValue.Value = model.CAI_SuppNo;
            this.Ddl_DutyPerson.SelectedValue = model.CAI_DutyPerson;
            this.Tbx_Title.Text = model.CAI_Title;
            this.Tbx_Remarks.Text = model.CAI_Details;
            this.Tbx_Money.Text = model.CAI_InitMoney.ToString();
            this.Ddl_Type.SelectedValue = model.CAI_Type.ToString();

            Lbl_Details.Text = "<Table id=\"myTable\" width=\"100%\" border=\"0\" align=\"center\" cellpadding=\"5\" cellspacing=\"0\" class=\"crmTable\">";
            Lbl_Details.Text += "<tr valign=\"top\"><td valign=\"top\" class=\"lvtCol\" align=\"right\" nowrap><b>工具</b></td>";
            Lbl_Details.Text += "<td class=\"lvtCol\" nowrap> <b>金额</b></td>";
            Lbl_Details.Text += "<td class=\"lvtCol\" nowrap><b>超期日期</b></td>";
            Lbl_Details.Text += "<td  class=\"lvtCol\" nowrap><b>备注</b></td></tr>";
            if (s_ID != "")
            {
                KNet.BLL.Cw_Accounting_Init Bll = new KNet.BLL.Cw_Accounting_Init();
                KNet.Model.Cw_Accounting_Init Model = Bll.GetModel(s_ID);
                decimal d_TotalMoney = decimal.Parse(Model.CAI_InitMoney.ToString());
                this.BeginQuery("Select * from Cw_Accounting_Init_Details where CAID_FID='" + s_ID + "'");
                this.QueryForDataTable();
                DataTable Dtb_Table = this.Dtb_Result;
                if (Dtb_Table.Rows.Count > 0)
                {
                    for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                    {
                        Lbl_Details.Text += "<tr valign=\"top\"><td class=\"dvtCellInfo\" nowrap><A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" border=0></a></td>";
                        Lbl_Details.Text += "<td class=\"dvtCellInfo\" nowrap><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:150px;\" Name=\"Number_" + i.ToString() + "\" value=" + Dtb_Table.Rows[i]["CAID_Number"].ToString() + "></td>";
                        Lbl_Details.Text += "<td class=\"dvtCellInfo\" nowrap><input type=\"text\" class=\"Wdate\" OnFocus=\"WdatePicker()\" style=\"width:200px;\" Name=\"D_OutTime_" + i.ToString() + "\" value=" + DateTime.Parse(Dtb_Table.Rows[i]["CAID_OutTime"].ToString()) + " ></td>";
                        Lbl_Details.Text += "<td  class=\"dvtCellInfo\" nowrap><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className='detailedViewTextBoxOn'\" OnBlur=\"this.className='detailedViewTextBox'\" style=\"width:150px;\" Name=\"Remarks_" + i.ToString() + "\" value=" + Dtb_Table.Rows[i]["CAID_Remarks"].ToString() + " ></td></tr>";
                    }
                    this.i_Num.Text = Convert.ToString(Dtb_Table.Rows.Count + 1);
                }
            }
            Lbl_Details.Text += " </table>";
        }
        catch
        { }
    }
    private bool SetValue(KNet.Model.Cw_Accounting_Init model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text == "")
            {
                model.CAI_ID = base.GetMainID();
                model.CAI_Code = base.GetNewID("Cw_Accounting_Init", 1);
            }
            else
            {
                model.CAI_ID = this.Tbx_ID.Text;
                model.CAI_Code = this.Tbx_Code.Text;
            }
            model.CAI_Type = int.Parse(this.Ddl_Type.SelectedValue);
            try {
                model.CAI_STime = DateTime.Parse(this.Tbx_STime.Text);
            }
            catch { }
            model.CAI_Title = this.Tbx_Title.Text;
            model.CAI_DutyPerson = this.Ddl_DutyPerson.SelectedValue;
            model.CAI_SuppNo = this.SuppNoSelectValue.Value;
            model.CAI_CustomerValue = this.Tbx_CustomerValue.Value;
            model.CAI_InitMoney = decimal.Parse(this.Tbx_Money.Text);
            model.CAI_Details = this.Tbx_Remarks.Text;
            model.CAI_Creator = AM.KNet_StaffNo;
            model.CAI_CTime = DateTime.Now;
            model.CAI_Mender = AM.KNet_StaffNo;
            model.CAI_MTime = DateTime.Now;
            
            ArrayList Arr_Details = new ArrayList();

            int i_num = int.Parse(this.i_Num.Text);
            int i_cal = 0;
            for (int i = 0; i < i_num; i++)
            {
                KNet.Model.Cw_Accounting_Init_Details ModelDetails = new KNet.Model.Cw_Accounting_Init_Details();
                string s_CAID_Number = Request["Number_" + i] == null ? "" : Request["Number_" + i].ToString();
                string s_CAID_OutTime = Request["OutTime_" + i] == null ? "" : Request["OutTime_" + i].ToString();
                string s_CAID_Remarks = Request["Remarks_" + i] == null ? "" : Request["Remarks_" + i].ToString();
                if (s_CAID_Number != "")
                {
                    ModelDetails.CAID_ID = base.GetMainID(i);
                    ModelDetails.CAID_FID = model.CAI_ID;
                    ModelDetails.CAID_Number = decimal.Parse(s_CAID_Number);
                    ModelDetails.CAID_OutTime = DateTime.Parse(s_CAID_OutTime);
                    ModelDetails.CAID_Remarks = s_CAID_Remarks;
                    i_cal += 1;
                    Arr_Details.Add(ModelDetails);
                }
            }
            model.Arr_Details = Arr_Details;
            if (i_cal != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch
        {
            return false;
        }
    }

    protected void Btn_SaveOnClick(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        string s_ID=this.Tbx_ID.Text;

        KNet.Model.Cw_Accounting_Init model = new KNet.Model.Cw_Accounting_Init();
        KNet.BLL.Cw_Accounting_Init bll = new KNet.BLL.Cw_Accounting_Init();

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
                AM.Add_Logs("期初余额增加" + this.Tbx_ID.Text);
                AlertAndRedirect("新增成功！", "Cw_Accounting_Init_List.aspx");
            }
            catch { }
        }
        else
        {
            try
            {
                bll.Update(model);
                AM.Add_Logs("期初余额修改" + this.Tbx_ID.Text);
                AlertAndRedirect("修改成功！", "Cw_Accounting_Init_List.aspx");
            }
            catch { }
        }
    }
}
