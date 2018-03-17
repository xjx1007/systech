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


public partial class Web_Xs_Sales_Quotes_View : BasePage
{
    public string s_CustomerValue = "";
    public string s_LinkMan = "";
    public string s_OppID = "";
    public string s_MyTable_Detail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.Lbl_Title.Text = "查看报价单";
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            if (s_ID != "")
            {
                ShowInfo(s_ID);
            }
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin(this.Lbl_Title.Text) == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
        }
       
    }

    private void ShowInfo(string s_ID)
    {
     
        try
        {
            KNet.BLL.Xs_Sales_Quotes bll = new KNet.BLL.Xs_Sales_Quotes();
            KNet.Model.Xs_Sales_Quotes model = bll.GetModel(s_ID);
            this.Tbx_ID.Text = s_ID;
            this.Lbl_Code.Text = model.XSQ_Code;
            this.Lbl_SalesChance.Text = base.Base_GetOppName(model.XSQ_SalesChance);
            this.Lbl_Step.Text = base.Base_GetBasicCodeName("121", model.XSQ_Step);
            this.Lbl_CustomerValue.Text = base.Base_GetCustomerName_Link(model.XSQ_CustomerValue);
            this.Lbl_LinkMan.Text = base.Base_GetLinkManValue(model.XSQ_LinkMan, "XOL_Name");
            this.Lbl_DutyPerson.Text = base.Base_GetUserName(model.XSQ_DutyPerson);

            this.Lbl_Stime.Text = DateTime.Parse(model.XSQ_STime.ToString()).ToShortDateString();

            this.Lbl_Payment.Text = model.XSQ_Payment;
            this.Lbl_Remarks.Text = model.XSQ_Remarks;
            KNet.BLL.Xs_Sales_Quotes_Details BLL_Details = new KNet.BLL.Xs_Sales_Quotes_Details();
            DataSet Dts_Details = BLL_Details.GetList(" SQD_FID='" + model.XSQ_ID + "'");
            if (Dts_Details.Tables[0].Rows.Count > 0)
            {
                s_MyTable_Detail += "<tr>";
                for (int i = 0; i < Dts_Details.Tables[0].Rows.Count; i++)
                {
                    this.Xs_ProductsCode.Text += Dts_Details.Tables[0].Rows[i]["SQD_ProductsBarCode"].ToString() + ",";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName(Dts_Details.Tables[0].Rows[i]["SQD_ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["SQD_ProductsBarCode"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dts_Details.Tables[0].Rows[i]["SQD_ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["SQD_Number"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["SQD_Price"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["SQD_Percent"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["SQD_PercentedMoney"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["SQD_Remarks"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["SQD_Money"].ToString() + "</td>";
                }

                s_MyTable_Detail += "</tr>";
            }

        }
        catch
        {}
    }

}
