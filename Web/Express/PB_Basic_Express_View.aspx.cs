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

public partial class Pb_Basic_Express_View : BasePage
{
    public string  s_OrderStyle = "", s_DetailsStyle = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            this.Tbx_ID.Text = s_ID;
            this.Lbl_Title.Text = "查看公告";
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
    private void ShowInfo(string PBE_ID)
    {
        KNet.BLL.PB_Basic_Express bll = new KNet.BLL.PB_Basic_Express();
        KNet.Model.PB_Basic_Express model = bll.GetModel(PBE_ID);
        this.lblPBE_Code.Text = model.PBE_Code;
        this.lblPBE_Stime.Text = model.PBE_Stime.ToString();
        this.lblPBE_DutyPerson.Text = model.PBE_DutyPerson;
        this.lblPBE_CustomerName.Text = model.PBE_CustomerName;
        this.lblPBE_LinkManName.Text = model.PBE_LinkManName;
        this.lblPBE_Shen.Text = model.PBE_Shen;
        this.lblPBE_Shi.Text = model.PBE_Shi;
        this.lblPBE_Qu.Text = model.PBE_Qu;
        this.lblPBE_Jie.Text = model.PBE_Jie;
        this.lblPBE_Address.Text = model.PBE_Address;
        this.lblPBE_Phone.Text = model.PBE_Phone;
        this.lblPBE_TelPhone.Text = model.PBE_TelPhone;
        this.lblPBE_ReCustomerName.Text = model.PBE_ReCustomerName;
        this.lblPBE_ReLinkManName.Text = model.PBE_ReLinkManName;
        this.lblPBE_ReShen.Text = model.PBE_ReShen;
        this.lblPBE_ReShi.Text = model.PBE_ReShi;
        this.lblPBE_ReQu.Text = model.PBE_ReQu;
        this.lblPBE_ReJie.Text = model.PBE_ReJie;
        this.lblPBE_ReAddress.Text = model.PBE_ReAddress;
        this.lblPBE_RePhone.Text = model.PBE_RePhone;
        this.lblPBE_ReTelPhone.Text = model.PBE_ReTelPhone;
        this.lblPBE_Use.Text = model.PBE_Use;
        this.lblPBE_KDName.Text = model.PBE_KDName;

    }

}
