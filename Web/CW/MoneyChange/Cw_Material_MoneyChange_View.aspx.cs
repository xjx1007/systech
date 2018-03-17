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


public partial class Web_Cw_Material_MoneyChange_View : BasePage
{
    public string s_MyTable_Detail = "", s_Return = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.Lbl_Title.Text = "查看原材料调整单";
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            this.Lbl_ID.Text = s_ID;
            if (s_ID != "")
            {
                ShowInfo(s_ID);
            }
        }

    }

    private void ShowInfo(string s_ID)
    {

        KNet.BLL.Cw_Material_MoneyChange bll = new KNet.BLL.Cw_Material_MoneyChange();
        KNet.Model.Cw_Material_MoneyChange model = bll.GetModel(s_ID);
        try
        {
            this.Lbl_Code.Text = model.CMM_Code;
            this.Lbl_FID.Text = GetURl(model.CMM_FID);
            this.Lbl_Remarks.Text = model.CMM_Remarks;
            try
            {
                this.Lbl_STime.Text = DateTime.Parse(model.CMM_STime.ToString()).ToShortDateString();

            }
            catch { }
            this.Lbl_Money.Text = model.CMM_Money.ToString();
        }
        catch
        { }
    }
    public string GetURl(string s_ID)
    {
        string s_Return = "";

        try
        {
            KNet.BLL.CG_Account_Bill BLL = new KNet.BLL.CG_Account_Bill();
            KNet.Model.CG_Account_Bill Model = BLL.GetModel(s_ID);

            s_Return = "<a href=\"/Web/CG/Bill/CG_Account_Bill_View.aspx?ID=" + s_ID + "\" target=\"_blank\">" + Model.CAB_Code + "</a>";

        }
        catch
        { }
        return s_Return;

    }
}
