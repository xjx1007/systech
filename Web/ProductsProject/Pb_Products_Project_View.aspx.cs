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

public partial class Pb_Project_Manage_View : BasePage
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

    private void ShowInfo(string s_ID)
    {
        KNet.BLL.Pb_Project_Manage bll = new KNet.BLL.Pb_Project_Manage();
        KNet.Model.Pb_Project_Manage model = bll.GetModel(s_ID);
        if (model != null)
        {
            this.Tbx_Code.Text=model.PPM_Code;
            this.Tbx_Products.Text = model.PPM_Products;
            this.Tbx_CustomerID.Text = model.PPM_CustomerValue;
            this.Tbx_CustomerName.Text = base.Base_GetCustomerName_Link(model.PPM_CustomerValue);

            try
            {
                this.Tbx_Stime.Text= DateTime.Parse(model.PPM_Stime.ToString()).ToShortDateString();
            }
            catch { }

            this.Ddl_ProductsType.Text =base.Base_GetBasicCodeName("153",model.PPM_ProductsType) ;
            this.Ddl_Model.Text = base.Base_GetBasicCodeName("159",model.PPM_Model);
            this.Ddl_SoftNeed.Text = base.Base_GetBasicCodeName("155", model.PPM_SoftNeed);
            this.Ddl_KeyCustom.Text = base.Base_GetBasicCodeName("156", model.PPM_KeyCustom);
            this.Ddl_Standards.Text = base.Base_GetBasicCodeName("157", model.PPM_Standards);

            this.Tbx_OtherRemarks.Text = model.PPM_OtherRemarks;
            this.Ddl_Shape.Text = base.Base_GetBasicCodeName("158", model.PPM_Shape);
            this.Ddl_Lamp.Text = base.Base_GetBasicCodeName("161", model.PPM_Lamp);
            this.Ddl_Led.Text = base.Base_GetBasicCodeName("161", model.PPM_Led);
            this.Tbx_Upper.Text = model.PPM_Upper;
            this.Tbx_Lower.Text = model.PPM_Lower;
            this.Tbx_Battery.Text = model.PPM_Battery;
            this.Tbx_Conductive.Text = model.PPM_Conductive;
            this.Tbx_KeyNumber.Text = model.PPM_KeyNumber;
            this.Tbx_Pot.Text = model.PPM_Pot;
            this.Tbx_Backlight.Text = model.PPM_Backlight;
            this.Tbx_Description.Text = model.PPM_Description;
            this.Ddl_HaveBattery.Text = base.Base_GetBasicCodeName("161", model.PPM_HaveBattery);
            this.Ddl_Packing.Text = base.Base_GetBasicCodeName("163", model.PPM_Packing);
            this.Ddl_ProductsDescription.Text = base.Base_GetBasicCodeName("164", model.PPM_ProductsDescription);
            this.Ddl_Warranty.Text = base.Base_GetBasicCodeName("161", model.PPM_Warranty); 
            this.Tbx_Price.Text = model.PPM_Price;
            this.Tbx_NeedTime.Text = model.PPM_NeedTime;
            this.Tbx_Application.Text = model.PPM_Application;
            this.Tbx_Remaks.Text = model.PPM_Remaks;
            this.Tbx_Neednumber.Text = model.PPM_Neednumber;
        }
    }

}
