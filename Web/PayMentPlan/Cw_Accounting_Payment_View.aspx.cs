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
     
        KNet.BLL.Cw_Accounting_Payment bll = new KNet.BLL.Cw_Accounting_Payment();
        KNet.Model.Cw_Accounting_Payment model = bll.GetModel(s_ID);
        try
        {
            this.Tbx_ID.Text = s_ID;
            this.Lbl_ID.Text = model.CAP_Code;
            this.Lbl_Customer.Text = base.Base_GetSupplierName_Link(model.CAP_CustomerValue);
            this.Lbl_YTime.Text = DateTime.Parse(model.CAP_STime.ToString()).ToShortDateString();
            this.Lbl_YMoney.Text =base.FormatNumber(model.CAP_ReceiveMoney.ToString(),3);
            this.Lbl_STime.Text = GetPayTime(s_ID);
            this.Lbl_SMoney.Text = base.FormatNumber(model.cap_Paymoney.ToString(),3);
            this.Lbl_Details.Text = model.CAP_Details;

            KNet.BLL.Cw_Accounting_Pay bll_Pay = new KNet.BLL.Cw_Accounting_Pay();
            DataSet ds = bll_Pay.GetList("  CAY_CAPID='"+s_ID+"'");
            this.MyGridView1.DataSource = ds;
            MyGridView1.DataKeyNames = new string[] { "CAA_ID" };
            MyGridView1.DataBind();
        }
        catch
        {}
    }

    public string GetPayTime(string s_ID)
    {
        string s_Return = "";
        try
        {
            this.BeginQuery(" Select b.CAA_PayTime from Cw_Accounting_Pay_Details a join Cw_Accounting_Pay b on a.CAY_CAAID=b.CAA_ID where a.CAY_CAPID='" + s_ID + "' ");
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            for (int i = 0; i < Dtb_Table.Rows.Count; i++)
            {
                s_Return += DateTime.Parse(Dtb_Table.Rows[0][0].ToString()).ToShortDateString() + ",";
            }
            s_Return = s_Return.Substring(0, s_Return.Length - 1);
        }
        catch { }
        return s_Return;
    }
}
