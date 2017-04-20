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

public partial class Web_SalesQuotes_Xs_Sales_Quotes_Print : BasePage
{
    public string s_Company = "", s_LinkMan = "", s_CustomerName = "", s_DutypersonName = "", s_MyTable_Detail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
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

        try
        {
            KNet.BLL.Xs_Sales_Quotes bll = new KNet.BLL.Xs_Sales_Quotes();
            KNet.Model.Xs_Sales_Quotes model = bll.GetModel(s_ID);
            this.Lbl_Code.Text = model.XSQ_Code;
            s_Company = "杭州士腾科技有限公司";
            s_CustomerName = base.Base_GetCustomerName(model.XSQ_CustomerValue);
            KNet.BLL.XS_Compy_LinkMan Bll_LinkMan = new KNet.BLL.XS_Compy_LinkMan();
            KNet.Model.XS_Compy_LinkMan Model_LinkMan = Bll_LinkMan.GetModel(model.XSQ_LinkMan);
            this.Lbl_ToATTN.Text = Model_LinkMan.XOL_Name;
            this.Lbl_LinkManFax.Text = Model_LinkMan.XOL_Fax;
            this.Lbl_LinkManTel.Text = Model_LinkMan.XOL_Phone;
            this.Lbl_LinkManEmail.Text = Model_LinkMan.XOL_Mail;
            KNet.BLL.KNet_Resource_Staff Bll_Staff = new KNet.BLL.KNet_Resource_Staff();
            KNet.Model.KNet_Resource_Staff Model_Staff = Bll_Staff.GetModelC(model.XSQ_DutyPerson);
            this.Lbl_FromATTN.Text = Model_Staff.StaffName;
            this.Lbl_DutyPersonTel.Text = Model_Staff.StaffTel;
            this.Lbl_DutyPersonEmail.Text = Model_Staff.StaffEmail;
            this.lbl_PayMent.Text = model.XSQ_Payment;
            KNet.BLL.Xs_Sales_Quotes_Details BLL_Details = new KNet.BLL.Xs_Sales_Quotes_Details();
            DataSet Dts_Details = BLL_Details.GetList(" SQD_FID='" + model.XSQ_ID + "'");
            if (Dts_Details.Tables[0].Rows.Count > 0)
            {
                s_MyTable_Detail += "<tr>";
                for (int i = 0; i < Dts_Details.Tables[0].Rows.Count; i++)
                {
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Convert.ToString(i+1) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName(Dts_Details.Tables[0].Rows[i]["SQD_ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dts_Details.Tables[0].Rows[i]["SQD_ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["SQD_Number"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["SQD_Price"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["SQD_Money"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["SQD_Remarks"].ToString() + "&nbsp;</td>";
                }
                s_MyTable_Detail += "</tr>";
            }

        }
        catch
        { }
    }

}
