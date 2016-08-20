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


public partial class Knet_Sales_Ship_Manage_Print : BasePage
{
    public string s_MyTable_Detail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            if (s_ID != "")
            {
                ShowInfo(s_ID);
            }
        }
       
    }

    private void ShowInfo(string s_ID)
    {
        KNet.BLL.Pb_Products_SampleAsk BLL = new KNet.BLL.Pb_Products_SampleAsk();
        KNet.Model.Pb_Products_SampleAsk Model = BLL.GetModelBySampleID(s_ID);
        this.Lbl_Code.Text = Model.PPA_ID;
        this.Lbl_Dept.Text = base.Base_GetUserDept(Model.PPA_DutyPerson);
        this.Lbl_Person.Text = base.Base_GetUserName(Model.PPA_DutyPerson);
        this.Lbl_SqPerson.Text = this.Lbl_Person.Text;
        try
        {
            this.Lbl_Stime.Text = DateTime.Parse(Model.PPA_Stime.ToString()).ToShortDateString();
        }
        catch (Exception ex)
        { 
        }
        this.Lbl_ProductsName.Text = base.Base_GetProdutsName(Model.PPA_ProdutsBarCode);
        this.Lbl_ProductsEdition.Text = base.Base_GetProductsEdition(Model.PPA_ProdutsBarCode);
        this.Lbl_Number.Text = Model.PPA_Number.ToString();
        this.Lbl_Use.Text = Model.PPA_Use;
        this.Lbl_Remarks.Text = Model.PPA_Remarks;
        if (Model.PPA_IsBack == 1)
        {
            this.Lbl_IsBack.Text = "是";
        }
        else
        {
            this.Lbl_IsBack.Text = "否";
 
        }
        
    }

}
