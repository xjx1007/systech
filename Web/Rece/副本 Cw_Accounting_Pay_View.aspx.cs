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


public partial class Web_Cw_Accounting_Pay : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        if (!Page.IsPostBack)
        {
            this.Lbl_Title.Text = "查看收款单";
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            if (s_ID != "")
            {
                ShowInfo(s_ID);
            }
        }
        if (AM.CheckLogin(this.Lbl_Title.Text) == false)
        {
            Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
            Response.End();
        }
       
    }

    private void ShowInfo(string s_ID)
    {
     
        KNet.BLL.Cw_Accounting_Pay bll = new KNet.BLL.Cw_Accounting_Pay();
        KNet.Model.Cw_Accounting_Pay model = bll.GetModel(s_ID);
        try
        {
            this.Tbx_ID.Text = s_ID;
            this.Lbl_ID.Text = model.CAA_Code;
            this.Lbl_Customer.Text = base.Base_GetCustomerName_Link(model.CAA_CustomerValue);
            this.Lbl_YMoney.Text = model.CAA_PayMoney.ToString();
            this.Lbl_YTime.Text = DateTime.Parse(model.CAA_PayTime.ToString()).ToShortDateString();
            this.Lbl_Details.Text = model.CAA_Details;

            this.Lbl_Type.Text = base.Base_GetBasicCodeName("767", model.CAP_Type.ToString());
            this.Tbx_BillCode.Text = model.CAA_BillCode;
            try
            {
                this.Tbx_StartDate.Text = DateTime.Parse(model.CAA_StartDateTime.ToString()).ToShortDateString();
                this.Tbx_EndDate.Text = DateTime.Parse(model.CAA_EndDateTime.ToString()).ToShortDateString();
            }
            catch
            { }

            this.Lbl_Link.Text = "<a href=\"/Web/Rece/Knet_Procure_WareHouseList_Add.aspx?OrderNo=" + s_ID + "\" class=\"webMnu\">创建入库单</a> ";

        }
        catch
        {}
    }

}
