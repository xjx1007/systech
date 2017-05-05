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


public partial class Web_Cw_Account_Bill_View : BasePage
{
    public string s_MyTable_Detail = "", s_Return="";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.Lbl_Title.Text = "查看发票管理";
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            if (s_ID != "")
            {
                Tbx_ID.Text = s_ID;
                ShowInfo(s_ID);
            }
        }
       
    }

    protected void btn_Chcek_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        try
        {

            if (btn_Chcek.Text == "审批")
            {
                string DoSql = "update Cw_Account_Bill  set CAB_ChchekYN=1  where  CAB_ID='" + this.Tbx_ID.Text + "' ";
                DbHelperSQL.ExecuteSql(DoSql);
                AM.Add_Logs("发票管理审批：" + this.Tbx_ID.Text);
                btn_Chcek.Text = "反审批";
            }
            else
            {
                string DoSql = "update Cw_Account_Bill  set CAB_ChchekYN=0 where  CAB_ID='" + this.Tbx_ID.Text + "' ";
                DbHelperSQL.ExecuteSql(DoSql);
                btn_Chcek.Text = "审批";

                AM.Add_Logs("发票管理反审批：" + this.Tbx_ID.Text);
            }

        }
        catch { }
    }

    private void ShowInfo(string s_ID)
    {

        KNet.BLL.Cw_Account_Bill bll = new KNet.BLL.Cw_Account_Bill();
        KNet.Model.Cw_Account_Bill model = bll.GetModel(s_ID);
        try
        {
            this.Lbl_Code.Text = model.CAB_Code;
            this.Lbl_Content.Text = model.CAB_Content;
            this.Lbl_ContractNo.Text = model.CAB_ContractNo;
            this.Lbl_PayMent.Text = base.Base_GetBasicCodeName("104", model.CAB_PayMent);
            this.Lbl_CustomerName.Text = base.Base_GetCustomerName_Link(model.CAB_CustomerValue);
            this.Lbl_DutyPerson.Text = base.Base_GetUserName(model.CAB_DutyPerson);
            this.Lbl_Remarks.Text = model.CAB_Remarks;
            this.Lbl_BillType.Text = base.Base_GetBasicCodeName("203", model.CAB_BillType.ToString());
            try
            {
                this.Lbl_STime.Text = DateTime.Parse(model.CAB_Stime.ToString()).ToShortDateString();
                
            }
            catch { }
            this.Lbl_Money.Text = model.CAB_Money.ToString();
            this.Lbl_BillNumber.Text = model.CAB_BillNumber;
            this.Lbl_Brokerage.Text = model.CAB_Brokerage;

            if (model.CAB_ChchekYN==1)
            {
                btn_Chcek.Text = "反审批";
            }
            else
            {
                btn_Chcek.Text = "审批";
            }
            s_Return = "<Table id=\"myTable\" width=\"100%\" border=\"0\" align=\"center\" cellpadding=\"5\" cellspacing=\"0\" class=\"crmTable\">";
            s_Return += "<tr valign=\"top\">";// "<td valign=\"top\" class=\"lvtCol\" align=\"right\" nowrap><b>工具</b></td>";
            s_Return += "<td class=\"lvtCol\" nowrap> <b>金额</b></td>";
            s_Return += "<td class=\"lvtCol\" nowrap><b>超期天数</b></td>";
            s_Return += "<td class=\"lvtCol\" nowrap><b>超期日期</b></td>";
            s_Return += "<td  class=\"lvtCol\" nowrap><b>备注</b></td></tr>";
            KNet.BLL.Cw_Account_Bill_Outimes Bll_OutTimes = new KNet.BLL.Cw_Account_Bill_Outimes();
            DataTable Dtb_Table = Bll_OutTimes.GetList(" CAO_CADID='"+model.CAB_ID+"'").Tables[0];
                if (Dtb_Table.Rows.Count > 0)
                {
                    for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                    {
                        s_Return += "<tr valign=\"top\">";
                        s_Return += "<td class=\"dvtCellInfo\" nowrap>" + Dtb_Table.Rows[i][2].ToString() + "</td>";
                        s_Return += "<td class=\"dvtCellInfo\" nowrap>" + Dtb_Table.Rows[i][3].ToString() + "</td>";
                        s_Return += "<td class=\"dvtCellInfo\" nowrap>" + DateTime.Parse(Dtb_Table.Rows[i][4].ToString()).ToShortDateString() + "</td>";
                        s_Return += "<td  class=\"dvtCellInfo\" nowrap>" + Dtb_Table.Rows[i][5].ToString() + "</tr>";
                    }
                }
            s_Return += " </table>";

            KNet.BLL.Cw_Account_Bill_Details bll_Details = new KNet.BLL.Cw_Account_Bill_Details();
            KNet.BLL.KNet_WareHouse_DirectOutList_Details bll_DirectOutList = new KNet.BLL.KNet_WareHouse_DirectOutList_Details();
            DataSet Dts_TableDetails = bll_Details.GetList(" CAD_CAAID='" + model.CAB_ID + "'");

            for (int i = 0; i < Dts_TableDetails.Tables[0].Rows.Count; i++)
            {
                KNet.Model.KNet_WareHouse_DirectOutList_Details Model_DirectOutList = bll_DirectOutList.GetModel(Dts_TableDetails.Tables[0].Rows[i]["CAD_OutNo"].ToString());
                s_MyTable_Detail += " <tr> ";
                s_MyTable_Detail += " <td  class=\"ListHeadDetails\">"+Convert.ToString(i+1)+"&nbsp;</td>";
                s_MyTable_Detail += " <td  class=\"ListHeadDetails\"> " + Model_DirectOutList.DirectOutNo + "</td>";
                string s_ProductsBarCode=Dts_TableDetails.Tables[0].Rows[i]["CAD_ProductsBarCode"].ToString()==""?Model_DirectOutList.ProductsBarCode:Dts_TableDetails.Tables[0].Rows[i]["CAD_ProductsBarCode"].ToString();
                s_MyTable_Detail += " <td  class=\"ListHeadDetails\">" + base.Base_GetProductsEdition_Link(s_ProductsBarCode) + "</td>";
                s_MyTable_Detail += " <td  class=\"ListHeadDetails\">" + base.FormatNumber1(Dts_TableDetails.Tables[0].Rows[i]["CAD_Number"].ToString(),0) + "</td>";
                s_MyTable_Detail += " <td  class=\"ListHeadDetails\">" + Dts_TableDetails.Tables[0].Rows[i]["CAD_Price"].ToString() + " </td>";
                s_MyTable_Detail += " <td  class=\"ListHeadDetails\">" + base.FormatNumber1(Dts_TableDetails.Tables[0].Rows[i]["CAD_Money"].ToString(),2) + "</td>";
                s_MyTable_Detail += " <td  class=\"ListHeadDetails\">" + Dts_TableDetails.Tables[0].Rows[i]["CAD_Remarks"].ToString() + "</td>";

                s_MyTable_Detail += " </tr> ";
            }
        }
        catch
        {}
        Lbl_Details.Text = s_MyTable_Detail;
    }

}
