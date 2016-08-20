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

using KNet.DBUtility;
using KNet.Common;
using System.Data.SqlClient;

public partial class Xs_Sales_Freight_View : BasePage
{
    public string  s_OrderStyle = "", s_DetailsStyle = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            //this.Tbx_ID.Text = s_ID;
            this.Lbl_Title.Text = "查看运费承担";
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            try
            {
                ShowInfo(s_ID);
            }
            catch
            { }
        }

    }
    /// <summary>
    /// 修改显示
    /// </summary>
    private void ShowInfo(string s_ID)
    {
        KNet.BLL.Xs_Sales_Freight bll = new KNet.BLL.Xs_Sales_Freight();
        KNet.Model.Xs_Sales_Freight model = bll.GetModel(s_ID);
        this.Lbl_Code.Text = model.XSF_Code.ToString();
        this.Lbl_FID.Text = model.XSF_FID.ToString();
        this.Lbl_Stime.Text = model.XSF_Stime.ToString();
        this.Lbl_Description.Text = model.XSF_Description.ToString();
        this.Lbl_Type.Text = base.Base_GetBasicCodeName("755", model.XSF_Type.ToString());
        this.Lbl_CustomerName.Text = model.XSF_CustomerName.ToString();
        this.Lbl_FPercent.Text = model.XSF_FPercent.ToString();
        this.Lbl_FMoney.Text = model.XSF_FMoney.ToString();
        this.Lbl_Percent.Text = model.XSF_Percent.ToString();
        this.Lbl_Money.Text = model.XSF_Money.ToString();
        this.Lbl_TotalMoney.Text = model.XSF_TotalMoney.ToString();
        this.Lbl_TotalNumber.Text = model.XSF_TotalNumber.ToString();
        this.Lbl_Price.Text = model.XSF_Price.ToString();
        this.Lbl_Remarks.Text = model.XSF_Remarks.ToString();
        this.Lbl_CTime.Text = model.XSF_CTime.ToString();
        this.Lbl_Creator.Text = base.Base_GetUserName(model.XSF_Creator.ToString());
        this.Lbl_MTime.Text = model.XSF_MTime.ToString();
        this.Lbl_Mender.Text = base.Base_GetUserName(model.XSF_Mender.ToString());
        this.Lbl_FSupp.Text = base.Base_GetSupplierName_Link(model.XSF_FSuppNo);
        this.Lbl_KD.Text = model.XSF_KDName;
        this.Lbl_KDCode.Text = model.XSF_KDCode;
        this.Lbl_Address.Text = model.XSF_Address;

    }

}
