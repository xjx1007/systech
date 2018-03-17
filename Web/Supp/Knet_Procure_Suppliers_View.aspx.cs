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


public partial class Web_Knet_Procure_Suppliers_View : BasePage
{
    public string s_CustomerValue = "";
    public string s_LinkMan = "";
    public string s_OppID = "";
    public string s_MyTable_Detail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.Lbl_Title.Text = "查看供应商";
            AdminloginMess AM = new AdminloginMess();
            //销售机会列表
            if (AM.CheckLogin(this.Lbl_Title.Text) == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
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

        try
        {
            KNet.BLL.Knet_Procure_Suppliers BLL = new KNet.BLL.Knet_Procure_Suppliers();
            string SuppNoID = Request.QueryString["ID"].ToString().Trim();
            KNet.Model.Knet_Procure_Suppliers model = BLL.GetModel(SuppNoID);

            this.SuppNametxt.Text = model.SuppName;
            this.SuppPeopletxt.Text = model.SuppPeople;
            this.SuppMobiTeltxt.Text = model.SuppMobiTel;
            this.SuppPhonetxt.Text = model.SuppPhone;
            this.SuppFaxtxt.Text = model.SuppFax;
            this.SuppEmailtxt.Text = model.SuppEmail;
            this.Lbl_DutyPerson.Text = base.Base_GetUserName(model.KPS_DutyPerson);
            this.SuppProvincetxt.Text = base.Base_GetCityName(model.SuppProvince) + "&nbsp;&nbsp;" + base.Base_GetCityName(model.SuppCity);

            this.SuppWebtxt.Text = model.SuppWeb;
            this.SuppAddresstxt.Text = model.SuppAddress;
            this.SuppZipCodetxt.Text = model.SuppZipCode;
            this.SuppBankNametxt.Text = model.SuppBankName;
            this.SuppBankAccounttxt.Text = model.SuppBankAccount;
            this.SuppProductstxt.Text = model.SuppProducts;
            this.Remarkstxt.Text = model.Remarks;
            this.Lbl_Level.Text = base.Base_GetBasicCodeName("112", model.KPS_Level);
            this.Lbl_Days.Text = base.Base_GetBasicCodeName("300", model.KPS_Days.ToString());
            this.Lbl_GiveDays.Text = model.KPS_GiveDays.ToString();

            KNet.BLL.KNet_Sys_ProcureType bll_Type = new KNet.BLL.KNet_Sys_ProcureType();
            DataSet dts_Table = bll_Type.GetList(" ProcureTypeValue='" + model.KPS_Type + "'");
            if (dts_Table.Tables[0].Rows.Count > 0)
            {
                this.Lbl_Type.Text = dts_Table.Tables[0].Rows[0]["ProcureTypeName"].ToString();
            }
            s_CustomerValue = model.SuppNo;
            this.BeginQuery("Select PBW_Name from PB_Basic_Wl where PBW_Code='" + model.KPS_KDCode + "'");
            string s_Wl = this.QueryForReturn();
            this.Lbl_Wl.Text = s_Wl;
            this.Lbl_Num.Text = model.KPS_ScNumber.ToString();
        }
        catch
        { }
    }

}
