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
    public string s_MyTable_Detail = "";
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

            this.Lbl_Type.Text = base.Base_GetBasicCodeName("766", model.CAP_Type.ToString());
            this.Tbx_BillCode.Text = model.CAA_BillCode;
            try
            {
                this.Tbx_StartDate.Text = DateTime.Parse(model.CAA_StartDateTime.ToString()).ToShortDateString();
                this.Tbx_EndDate.Text = DateTime.Parse(model.CAA_EndDateTime.ToString()).ToShortDateString();
            }
            catch
            { }

            this.Lbl_Link.Text = "<a href=\"/Web/Rece/Knet_Procure_WareHouseList_Add.aspx?OrderNo=" + s_ID + "\" class=\"webMnu\">创建入库单</a> ";

            KNet.BLL.Cw_Bill_DirectOut_PayDetails bll_Details = new KNet.BLL.Cw_Bill_DirectOut_PayDetails();
            DataSet Dts_table = bll_Details.GetList(" CBDP_PayMentID='" + model.CAA_ID + "'  order by CBDP_ID ");
            decimal d_Total = 0;
            if (Dts_table.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_table.Tables[0].Rows.Count; i++)
                {

                    s_MyTable_Detail += " <tr> ";
                    s_MyTable_Detail += " <td  class=\"ListHeadDetails\"><A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a></td>";

                    KNet.BLL.KNet_WareHouse_DirectOutList_Details bll_DircetOutDetails = new KNet.BLL.KNet_WareHouse_DirectOutList_Details();
                    KNet.Model.KNet_WareHouse_DirectOutList_Details Model_DircetOutDetails = bll_DircetOutDetails.GetModel(Dts_table.Tables[0].Rows[i]["CBDP_DetailsID"].ToString());
                    if (Model_DircetOutDetails != null)
                    {
                        KNet.BLL.KNet_WareHouse_DirectOutList bll_DircetOut = new KNet.BLL.KNet_WareHouse_DirectOutList();
                        KNet.Model.KNet_WareHouse_DirectOutList Model_DircetOut = bll_DircetOut.GetModelB(Model_DircetOutDetails.DirectOutNo);
                        if (Model_DircetOut.KWD_CwCode != "")
                        {
                            s_MyTable_Detail += " <td  class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ID_" + i.ToString() + "\" Value=\"" + Model_DircetOutDetails.ID + "\">" + Model_DircetOut.DirectOutNo + "</td>";
                        }
                        else
                        {
                            s_MyTable_Detail += " <td  class=\"ListHeadDetails\">&nbsp;</td>";
                        }
                        s_MyTable_Detail += " <td  class=\"ListHeadDetails\"><input type=\"hidden\" ID=\"DirectOutTime_" + i.ToString() + "'\"   Name=\"DirectOutTime_" + i.ToString() + "\" value='" + DateTime.Parse(Model_DircetOut.KWD_CWOutTime.ToString()).ToShortDateString() + "'>" + DateTime.Parse(Model_DircetOut.KWD_CWOutTime.ToString()).ToShortDateString() + "</td>";

                        s_MyTable_Detail += " <td  class=\"ListHeadDetails\"><input type=\"hidden\" ID=\"ProductsBarCode_" + i.ToString() + "\"   Name=\"ProductsBarCode_" + i.ToString() + "\" value='" + Model_DircetOutDetails.ProductsBarCode + "'>" + base.Base_GetProductsEdition_Link(Model_DircetOutDetails.ProductsBarCode) + "</td>";
                        s_MyTable_Detail += " <td  class=\"ListHeadDetails\">" + Model_DircetOutDetails.DirectOutAmount + "</td>";

                    }
                    s_MyTable_Detail += " <td  class=\"ListHeadDetails\">" + Model_DircetOutDetails.KWD_SalesUnitPrice.ToString() + "</td>";
                    s_MyTable_Detail += " <td  class=\"ListHeadDetails\">" + Dts_table.Tables[0].Rows[i]["CBDP_Money"].ToString() + "</td>";
                    s_MyTable_Detail += " <td  class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\';sum()\" style=\"width:170px;\" Name=\"Tbx_Money_" + i.ToString() + "\" value=" + Dts_table.Tables[0].Rows[i]["CBDP_Money"].ToString() + "> </td>";
                    d_Total += decimal.Parse(Dts_table.Tables[0].Rows[i]["CBDP_Money"].ToString());
                    s_MyTable_Detail += " </tr> ";
                }
            }
            this.Tbx_Num.Text = Dts_table.Tables[0].Rows.Count.ToString();
            this.Tbx_DetailsMoney.Text = d_Total.ToString();
            this.Tbx_LeftMoney.Text = Convert.ToString(model.CAA_PayMoney - d_Total);

        }
        catch
        {}
    }

}
