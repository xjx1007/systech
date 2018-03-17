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


public partial class Web_Xs_Contract_Manage_View : BasePage
{
    public string s_MyTable_Detail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.Lbl_Title.Text = "查看合同档案";
            AdminloginMess AM = new AdminloginMess();
            //this.Lbl_Title.Text
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            if (s_ID != "")
            {
                ShowInfo(s_ID);
            }
        }
       
    }

    public string GetFlowName(string s_Flow)
    {
        string s_FlowName = "";
        switch (s_Flow)
        {
            case "1":
                s_FlowName = "通过审核!";
                break;
            case "2":
                s_FlowName = "合同作废!";
                break;
            case "3":
                s_FlowName = "<font color='Blue'>异常通过!</font>";
                break;
            case "4":
                s_FlowName = "重新提交!";
                break;
            case "0":
                s_FlowName = "<font color='red'>不通过！</font>";
                break;
        }
        return s_FlowName;
    }
    private void ShowInfo(string s_ID)
    {
     
        KNet.BLL.Xs_Contract_Manage bll = new KNet.BLL.Xs_Contract_Manage();
        KNet.Model.Xs_Contract_Manage model = bll.GetModel(s_ID);

        KNet.BLL.KNet_Sales_Flow Bll_Sales_Flow = new KNet.BLL.KNet_Sales_Flow();
        KNet.Model.KNet_Sales_Flow Model_Sales_Flow = new KNet.Model.KNet_Sales_Flow();
        GridView1.DataSource = Bll_Sales_Flow.GetList(" KSF_ContractNo='" + s_ID + "' and KFS_Type='0'  Order  by KSF_Date desc");
        this.GridView1.DataBind();

        try
        {
            if (model != null)
            {

                this.Tbx_Code.Text = model.XCM_Code;
                this.Tbx_Title.Text = model.XCM_Title;
                try
                {
                    this.Tbx_STime.Text = DateTime.Parse(model.XCM_STime.ToString()).ToShortDateString();
                }
                catch { }
                this.DDl_Type.Text = base.Base_GetBasicCodeName("216", model.XCM_Type);
                this.Tbx_CustomerName.Text = base.Base_GetCustomerName_Link(model.XCM_CustomerValue);
                this.Ddl_Flow.Text = base.Base_GetFlowName(model.XCM_Flow, true);
                this.tbx_Remarks.Text = KNetPage.KHtmlDiscode(model.XCM_Remarks == null ? "" : model.XCM_Remarks);
                this.Ddl_DutyPerson.Text = base.Base_GetUserName(model.XCM_DutyPerson);

                this.Drop_Payment.Text = base.Base_GetBasicCodeName("104", model.XCM_PayMent);
                this.ContractToPayment.Text = base.Base_GetCheckMethod(model.XCM_BillType);

                this.Tbx_TechnicalRequire.Text = model.XCM_TechnicalRequire;
                this.Tbx_ProductPackaging.Text = model.XCM_ProductPackaging;
                this.Tbx_QualityRequire.Text = model.XCM_QualityRequire;
                this.Tbx_WarrantyPeriod.Text = model.XCM_WarrantyPeriod;
                this.Tbx_FhDetails.Text = model.XCM_FhDetails;
                this.Tbx_ContractShip.Text = model.XCM_DeliveryReqyire;
                this.Ddl_KpType.Text = base.Base_GetBasicCodeName("768", model.XCM_KpType);

                KNet.BLL.PB_Basic_Attachment Bll_Att = new KNet.BLL.PB_Basic_Attachment();
                DataSet Dts_Table = Bll_Att.GetList(" PBA_FID='" + model.XCM_ID + "'");
                if (Dts_Table.Tables[0].Rows.Count > 0)
                {
                    Lbl_Details.Text += "<table id=\"myTableDetails\" width=\"100%\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">";
                    for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                    {
                        string s_FileName = Dts_Table.Tables[0].Rows[i]["PBA_Name"].ToString();
                        string s_filePath = Dts_Table.Tables[0].Rows[i]["PBA_Url"].ToString();
                        Lbl_Details.Text += "<tr><td valign=\"top\" class=\"dvtCellInfo\" align=\"left\" nowrap><a onclick=\"deleteRow3(this)\" href=\"#\">";
                        Lbl_Details.Text += "<img src=\"/themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=\"0\"></a></td>";

                        Lbl_Details.Text += "<td class=\"dvtCellInfo\" align=\"left\" nowrap><input type=\"hidden\"  Name=\"Tbx_PName_" + i.ToString() + "\" value=" + s_FileName + ">" + s_FileName + "</td>";
                        Lbl_Details.Text += "<td class=\"dvtCellInfo\" align=\"left\" nowrap><input Name=\"Image1Big_" + i.ToString() + "\"  type=\"hidden\"  value=" + s_filePath + "><a href=\"" + s_filePath + "\" >" + s_FileName + "</a></td></tr>";

                    }
                    this.Lbl_Details.Text += "</Table>";
                }

                AdminloginMess AM = new AdminloginMess();
                KNet.BLL.Xs_Contract_Manage_Details BLL_Details = new KNet.BLL.Xs_Contract_Manage_Details();
                DataSet Dts_Details = BLL_Details.GetList(" XCMD_ContractNo='" + model.XCM_Code + "'");
                if (Dts_Details.Tables[0].Rows.Count > 0)
                {
                    int i_Num = 13;//单价限制
                    //研发中心经理，市场销售部，总经理，财务部有权限查看金额
                    if (AM.YNAuthority("销售单价查看") == false)
                    {
                        i_Num = 10;//单价限制
                    }
                    s_MyTable_Detail += "  <tr valign=\"top\">\n";
                    s_MyTable_Detail += "  <td  class=\"ListHead\" nowrap><b>产品名称</b></td>\n";
                    s_MyTable_Detail += "  <td  class=\"ListHead\" nowrap><b>产品编码</b></td>\n";
                    s_MyTable_Detail += "  <td  class=\"ListHead\" nowrap><b>型号</b></td>\n";
                    s_MyTable_Detail += "  <td  class=\"ListHead\" nowrap><b>数量</b></td>\n";
                    s_MyTable_Detail += "  <td  class=\"ListHead\" nowrap><b>备货数量</b></td>\n";
                    if (i_Num == 8)
                    {
                        s_MyTable_Detail += "  <td  class=\"ListHead\" nowrap><b>单价</b></td>\n";
                        s_MyTable_Detail += "  <td  class=\"ListHead\" nowrap><b>金额</b></td>\n";
                    }
                    s_MyTable_Detail += "  <td  class=\"ListHead\" nowrap><b>计划单号</b></td>\n";
                    s_MyTable_Detail += "  <td  class=\"ListHead\" nowrap><b>订单号</b></td>\n";
                    s_MyTable_Detail += "  <td  class=\"ListHead\" nowrap><b>客户料号</b></td>\n";
                    s_MyTable_Detail += "  <td  class=\"ListHead\" nowrap><b>客户型号</b></td>\n";
                    s_MyTable_Detail += "  <td  class=\"ListHead\" nowrap><b>是否随货</b></td>\n";
                    s_MyTable_Detail += "  <td  class=\"ListHead\" nowrap><b>备注</b></td>\n";
                    s_MyTable_Detail += "  <td  class=\"ListHead\" nowrap><b>电池</b></td>\n";
                    s_MyTable_Detail += "  <td  class=\"ListHead\" nowrap><b>库存</b></td>\n";
                    s_MyTable_Detail += "  </tr>\n";
                    for (int i = 0; i < Dts_Details.Tables[0].Rows.Count; i++)
                    {
                        s_MyTable_Detail += "<tr>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName_Link(Dts_Details.Tables[0].Rows[i]["XCMD_ProductsBarCode"].ToString()) + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsCode(Dts_Details.Tables[0].Rows[i]["XCMD_ProductsBarCode"].ToString()) + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dts_Details.Tables[0].Rows[i]["XCMD_ProductsBarCode"].ToString()) + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["XCMD_ContractAmount"].ToString() + "</td>";
                        if (Dts_Details.Tables[0].Rows[i]["XCMD_BNumber"].ToString() == "0")
                        {
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\">&nbsp;</td>";

                        }
                        else
                        {
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["XCMD_BNumber"].ToString() + "</td>";
                        }
                        if (i_Num == 8)
                        {
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["XCMD_Contract_SalesUnitPrice"].ToString() + "</td>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["XCMD_Contract_SalesTotalNet"].ToString() + "</td>";
                        }
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["XCMD_PlanNumber"].ToString() + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["XCMD_OrderNumber"].ToString() + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["XCMD_MaterNumber"].ToString() + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["XCMD_MaterPattern"].ToString() + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["XCMD_IsFollow"].ToString() + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["XCMD_ContractRemarks"].ToString() + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsPattern(Dts_Details.Tables[0].Rows[i]["XCMD_Battery"].ToString()) + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetHouseAndNumber(Dts_Details.Tables[0].Rows[i]["XCMD_ProductsBarCode"].ToString()) + "</td>";
                        s_MyTable_Detail += "</tr>";
                    }
                    this.BeginQuery("select * from Xs_Contract_FhDetails where XCF_FID='" + model.XCM_ID + "'");
                    DataTable Dtb_FhDetails = (DataTable)this.QueryForDataTable();
                    if (Dtb_FhDetails.Rows.Count > 0)
                    {
                        for (int i = 0; i < Dtb_FhDetails.Rows.Count; i++)
                        {

                            Lbl_FhDetails.Text += " <tr valign=\"middle\">";

                            Lbl_FhDetails.Text += "<td class=\"ListHeadDetails\"><input type=\"input\" style=\"height:50px;width:65%;display:none\" Name=\"FhName_" + i.ToString() + "\"  value=\"'" + Dtb_FhDetails.Rows[i]["XCF_Name"].ToString() + "'\" >" + Dtb_FhDetails.Rows[i]["XCF_Name"].ToString() + "</td>";
                            Lbl_FhDetails.Text += "<td class=\"ListHeadDetails\"><input type=\"input\" style=\"height:50px;width:65%;display:none\" Name=\"FhDetails_" + i.ToString() + "\"  value=\"'" + Dtb_FhDetails.Rows[i]["XCF_Details"].ToString() + "'\" >" + Dtb_FhDetails.Rows[i]["XCF_Details"].ToString() + "</td>";

                            Lbl_FhDetails.Text += "</tr>";

                        }
                        this.FhNum.Text = Dtb_FhDetails.Rows.Count.ToString();
                    }
                }
            }
        }
        catch
        { }
    }

}
