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


public partial class Web_Cw_Accounting_Payment : BasePage
{
    public string s_ID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.Lbl_Title.Text = "查看应付款";
             s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            if (s_ID != "")
            {
                ShowInfo(s_ID);
            }
        }
       
    }

    private void ShowInfo(string s_ID)
    {
        
        AdminloginMess AM = new AdminloginMess();
        KNet.BLL.Cw_Accounting_Payment bll = new KNet.BLL.Cw_Accounting_Payment();
        KNet.Model.Cw_Accounting_Payment model = bll.GetModel(s_ID);
        try
        {
            this.Tbx_ID.Text = s_ID;
            this.Lbl_ID.Text = model.CAP_Code;
            if (model.CAP_CustomerValue != model.CAP_KCustomerValue)
            {
                this.Lbl_Customer.Text = base.Base_GetCustomerName_Link(model.CAP_KCustomerValue);
                this.Lbl_KCustomer.Text = base.Base_GetCustomerName_Link(model.CAP_CustomerValue);
            }
            else
            {
                this.Lbl_Customer.Text = base.Base_GetCustomerName_Link(model.CAP_CustomerValue);
                this.Lbl_KCustomer.Text = base.Base_GetCustomerName_Link(model.CAP_CustomerValue);
            }

            
            this.Lbl_YTime.Text = DateTime.Parse(model.CAP_STime.ToString()).ToShortDateString();
            this.Lbl_YMoney.Text =base.FormatNumber(model.CAP_ReceiveMoney.ToString(),3);
            this.Lbl_IsFp.Text = base.Base_GetBasicCodeName("107", model.CAP_IsFP);
            this.Lbl_FpType.Text = base.Base_GetBasicCodeName("203", model.CAP_FpType);
            this.Lbl_Details.Text = model.CAP_Details;
            this.Lbl_DutyPerson.Text = base.Base_GetUserName(model.CAP_DutyPerson);
            this.Lbl_Creator.Text = base.Base_GetUserName(model.CAP_Creator)+"(" + model.CAP_CTime.ToString()+")";
            this.Lbl_PayMent.Text = base.Base_GetBasicCodeName("104", model.CAP_Payment);
            if (model.CAP_CheckYN == 1)
            {
                btn_Chcek.Text = "反审批";
            }
            else
            {
                btn_Chcek.Text = "审批";
            }
            if (AM.KNet_StaffNo != model.CAP_DutyPerson)
            {
                btn_Chcek.Enabled = false;
            }
            else
            {
                btn_Chcek.Enabled = true;
            }
            this.BeginQuery("Select * from Cw_Accounting_PaymentDetails a join KNet_WareHouse_DirectOutList_Details b on a.CAPD_FID=b.ID join KNet_WareHouse_DirectOutList c on c.DirectOutNo=b.DirectOutNo  where CAPD_CARID='" + model.CAP_ID + "'");
            this.QueryForDataSet();
            DataSet ds_Details = this.Dts_Result;
            this.MyGridView2.DataSource = ds_Details;
            MyGridView2.DataBind();

            KNet.BLL.Cw_Accounting_Pay bll_Pay = new KNet.BLL.Cw_Accounting_Pay();
            DataSet ds = bll_Pay.GetList("  CAY_CAPID='"+s_ID+"'");
            this.MyGridView1.DataSource = ds;
            MyGridView1.DataKeyNames = new string[] { "CAA_ID" };
            MyGridView1.DataBind();

            KNet.BLL.Cw_Account_Bill bll_Bill = new KNet.BLL.Cw_Account_Bill();
            DataSet ds_Bill = bll_Bill.GetList(" CAB_CAPID='" + s_ID + "' ");
            this.MyGridView3.DataSource = ds_Bill;
            MyGridView3.DataKeyNames = new string[] { "CAB_ID" };
            MyGridView3.DataBind();


            KNet.BLL.KNet_WareHouse_DirectOutList bll_DirectOutList = new KNet.BLL.KNet_WareHouse_DirectOutList();
            string SqlWhere = " DirectOutTopic='" + s_ID + "'";
            SqlWhere += " order by KWD_DirectOutNo";
            DataSet ds_Bill4 = bll_DirectOutList.GetList(SqlWhere);

            MyGridView4.DataSource = ds_Bill4.Tables[0];
            MyGridView4.DataKeyNames = new string[] { "DirectOutNo" };
            MyGridView4.DataBind();
        }
        catch(Exception ex)
        {}
    }

    protected void btn_Chcek_Click(object sender, EventArgs e)
    {
        string sql="";
        AdminloginMess AM = new AdminloginMess();
        string s_ID = this.Tbx_ID.Text;
        if (btn_Chcek.Text == "审批")
        {
            sql = "Update Cw_Accounting_Payment Set CAP_CheckYN='1' where CAP_ID='" + s_ID + "' ";
            DbHelperSQL.ExecuteSql(sql);
            AM.Add_Logs("开票通知审核" + this.Tbx_ID.Text + " 审核人：" + AM.KNet_StaffName);
            AlertAndRedirect("开票通知审核成功！", "Cw_Accounting_Payment_View.aspx?ID=" + s_ID + "");
        }
        else if (btn_Chcek.Text == "反审批")
        {
            sql = "Update Cw_Accounting_Payment Set CAP_CheckYN='0' where CAP_ID='" + s_ID + "' ";
            DbHelperSQL.ExecuteSql(sql);
            AM.Add_Logs("开票通知审核" + this.Tbx_ID.Text + " 审核人：" + AM.KNet_StaffName);
            AlertAndRedirect("开票通知审核成功！", "Cw_Accounting_Payment_View.aspx?ID=" + s_ID + "");
        }
    }
}
