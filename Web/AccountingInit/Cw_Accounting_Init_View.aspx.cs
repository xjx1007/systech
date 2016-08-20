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


public partial class Web_Cw_Accounting_Init_View : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.Lbl_Title.Text = "查看期初余额";
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            if (s_ID != "")
            {
                ShowInfo(s_ID);
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
            this.Lbl_Code.Text = model.CAI_Code;
            this.Lbl_Stime.Text = DateTime.Parse(model.CAI_STime.ToString()).ToShortDateString();
            this.Lbl_Customer.Text = base.Base_GetCustomerName_Link(model.CAI_CustomerValue);
            this.Lbl_SuppNo.Text = base.Base_GetSupplierName_Link(model.CAI_SuppNo);
            this.Lbl_DutyPerson.Text = base.Base_GetUserName(model.CAI_DutyPerson);
            this.Lbl_Title1.Text = model.CAI_Title;
            this.Lbl_Remarks.Text = model.CAI_Details;
            this.Lbl_Money.Text = model.CAI_InitMoney.ToString();
            this.Lbl_Type.Text = base.Base_GetBasicCodeName("209", model.CAI_Type.ToString());



            Lbl_Details.Text = "<Table id=\"myTable\" width=\"100%\" border=\"0\" align=\"center\" cellpadding=\"5\" cellspacing=\"0\" class=\"crmTable\">";
            Lbl_Details.Text += "<tr><td colspan=\"11\" class=\"detailedViewHeader\" style=\"height: 15px\">";
            Lbl_Details.Text += "<b>初始化明细</b></td></tr>";
            Lbl_Details.Text += "<tr valign=\"top\">";
            Lbl_Details.Text += "<td class=\"lvtCol\" nowrap> <b>金额</b></td>";
            Lbl_Details.Text += "<td class=\"lvtCol\" nowrap><b>超期日期</b></td>";
            Lbl_Details.Text += "<td  class=\"lvtCol\" nowrap><b>备注</b></td></tr>";
            KNet.BLL.Cw_Accounting_Init_Details Bll_Details = new KNet.BLL.Cw_Accounting_Init_Details();
            DataSet Dts_Table = Bll_Details.GetList(" CAID_FID='" + s_ID + "'");
            if (Dts_Table.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                {
                    Lbl_Details.Text += "<td class=\"dvtCellInfo\" nowrap>" + Dts_Table.Tables[0].Rows[i]["CAID_Number"].ToString() + "</td>";
                    Lbl_Details.Text += "<td class=\"dvtCellInfo\" nowrap>" + DateTime.Parse(Dts_Table.Tables[0].Rows[i]["CAID_OutTime"].ToString()).ToShortDateString() + "</td>";
                    Lbl_Details.Text += "<td  class=\"dvtCellInfo\" nowrap>" + Dts_Table.Tables[0].Rows[i]["CAID_Remarks"].ToString() + "</td></tr>";
 
                }
            }
            Lbl_Details.Text += " </table>";
        }
        catch(Exception ex)
        {}
    }

}
