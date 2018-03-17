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


public partial class Web_Cg_Contract_Manage_View : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.Lbl_Title.Text = "查看合同档案";
            AdminloginMess AM = new AdminloginMess();
            //this.Lbl_Title.Text
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            if (s_ID != "")
            {
                ShowInfo(s_ID);
            }
        }
       
    }

    private void ShowInfo(string s_ID)
    {
     
        KNet.BLL.Cg_Contract_Manage bll = new KNet.BLL.Cg_Contract_Manage();
        KNet.Model.Cg_Contract_Manage model = bll.GetModel(s_ID);
        try
        {
            if (model != null)
            {

                this.Tbx_Code.Text = model.CCM_Code;
                this.Tbx_Title.Text = model.CCM_Title;
                try
                {
                    this.Tbx_STime.Text = DateTime.Parse(model.CCM_STime.ToString()).ToShortDateString();
                }
                catch { }
                this.DDl_Type.Text = base.Base_GetBasicCodeName("216", model.CCM_Type);
                this.Tbx_CustomerName.Text = base.Base_GetCustomerName_Link(model.CCM_CustomerValue);
                this.Ddl_Flow.Text = base.Base_GetFlowName(model.CCM_Flow,true);
                this.tbx_Remarks.Text = KNetPage.KHtmlDiscode(model.CCM_Remarks == null ? "" : model.CCM_Remarks);
                this.Ddl_DutyPerson.Text = base.Base_GetUserName(model.CCM_DutyPerson);

                this.Drop_Payment.Text = base.Base_GetBasicCodeName("104", model.CCM_PayMent);
                this.ContractToPayment.Text = base.Base_GetCheckMethod(model.CCM_BillType);

                this.Tbx_TechnicalRequire.Text = model.CCM_TechnicalRequire;
                this.Tbx_ProductPackaging.Text = model.CCM_ProductPackaging;
                this.Tbx_QualityRequire.Text = model.CCM_QualityRequire;
                this.Tbx_WarrantyPeriod.Text = model.CCM_WarrantyPeriod;
                this.Tbx_FhDetails.Text = model.CCM_FhDetails;
                this.Tbx_ContractShip.Text = model.CCM_DeliveryReqyire;

                KNet.BLL.PB_Basic_Attachment Bll_Att = new KNet.BLL.PB_Basic_Attachment();
                DataSet Dts_Table = Bll_Att.GetList(" PBA_FID='" + model.CCM_ID + "'");
                if (Dts_Table.Tables[0].Rows.Count > 0)
                {
                    Lbl_Details.Text += "<table id=\"myTableDetails\" width=\"100%\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">";
                    for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                    {
                        string s_FileName = Dts_Table.Tables[0].Rows[i]["PBA_Name"].ToString();
                        string s_filePath = Dts_Table.Tables[0].Rows[i]["PBA_Url"].ToString();
                        Lbl_Details.Text += "<tr><td valign=\"top\" class=\"dvtCellInfo\" align=\"left\" nowrap><a onclick=\"deleteRow3(this)\" href=\"#\">";
                        Lbl_Details.Text += "<img src=\"/themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=\"0\"></a></td>";

                        Lbl_Details.Text += "<td class=\"dvtCellInfo\" align=\"left\" nowrap><input type=\"hidden\"  Name=\"Tbx_PName_" + i.ToString() + "\" value=" + s_FileName + ">" + s_FileName + "</td>";
                        Lbl_Details.Text += "<td class=\"dvtCellInfo\" align=\"left\" nowrap><input Name=\"Image1Big_" + i.ToString() + "\"  type=\"hidden\"  value=" + s_filePath + "><a href=\"" + s_filePath + "\" >" + s_FileName + "</a></td></tr>";

                    }
                    this.Lbl_Details.Text += "</Table>";
                }
            }
        }
        catch
        {}
    }

}
