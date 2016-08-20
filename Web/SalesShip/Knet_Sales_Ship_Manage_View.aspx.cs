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


public partial class Web_Knet_Sales_Ship_Manage_View : BasePage
{
    public string s_MyTable_Detail = "", s_OrderStyle = "", s_DetailsStyle = "", s_ID1 = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.Lbl_Title.Text = "查看发货通知信息";
            s_ID1 = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            if (s_Type == "1")
            {
                s_OrderStyle = "class=\"dvtUnSelectedCell\"";
                s_DetailsStyle = "class=\"dvtSelectedCell\"";
                Pan_Order.Visible = false;
                Pan_Detail.Visible = true;
                Table_Btn.Visible = false;
                KNet.BLL.KNet_WareHouse_DirectOutList bll = new KNet.BLL.KNet_WareHouse_DirectOutList();
                string SqlWhere = " KWD_shipNo='" + s_ID1 + "'";
                SqlWhere += " order by KWD_DirectOutNo";
                DataSet ds = bll.GetList(SqlWhere);

                MyGridView1.DataSource = ds.Tables[0];
                MyGridView1.DataKeyNames = new string[] { "DirectOutNo" };
                MyGridView1.DataBind();

                KNet.BLL.System_PhoneMessage_Manage bllPhoneMessage = new KNet.BLL.System_PhoneMessage_Manage();
                string s_Sql = "SPM_Del=0 and SPM_FID in (Select DirectOutNo From KNet_WareHouse_DirectOutList where KWD_ShipNo='" + s_ID1 + "') ";

                s_Sql += " Order by SPM_SendTime desc";
                DataSet dsPhoneMessage = bllPhoneMessage.GetList(s_Sql);
                GridView1.DataSource = dsPhoneMessage;
                GridView1.DataKeyNames = new string[] { "SPM_ID" };
                GridView1.DataBind();
            }
            else
            {
                s_DetailsStyle = "class=\"dvtUnSelectedCell\"";
                s_OrderStyle = "class=\"dvtSelectedCell\"";
                Pan_Order.Visible = true;
                Pan_Detail.Visible = false;
                Table_Btn.Visible = true;
            }
            if (s_ID1 != "")
            {
                ShowInfo(s_ID1);
            }
        }
    }

    private void ShowInfo(string s_ID)
    {
        AdminloginMess AM = new AdminloginMess();

        KNet.BLL.KNet_Sales_OutWareList BLL = new KNet.BLL.KNet_Sales_OutWareList();
        KNet.Model.KNet_Sales_OutWareList Model = BLL.GetModelB(s_ID);

        if (Request["ID"] != null && Request["ID"] != "")
        {
            this.OutWareNo.Text = Model.OutWareNo;
            this.DutyPerson.Text = base.Base_GetUserName(Model.DutyPerson);
            this.OutWareDateTime.Text = DateTime.Parse(Model.OutWareDateTime.ToString()).ToShortDateString();
            this.PlanTime.Text = DateTime.Parse(Model.KSO_PlanOutWareDateTime.ToString()).ToShortDateString();
            this.CustomerName.Text = base.Base_GetCustomerName_Link(Model.CustomerValue);
            string[] s_ContractNo = Model.ContractNo == null ? "".Split(',') : Model.ContractNo.Split(',');
            for (int i = 0; i < s_ContractNo.Length; i++)
            {
                this.ContractNo.Text += "<a href=\"../SalesContract/KNet_Sales_ContractList_View.aspx?ID=" + s_ContractNo[i] + "\" >" + s_ContractNo[i] + "</a><br>";

            }

            //this.ContractNo.Text = "<a href=\"../SalesContract/KNet_Sales_ContractList_View.aspx?ID=" + Model.ContractNo + "\">" + Model.ContractNo + "</a>";
            this.ContectPerson.Text = Model.OutWareOursContact;
            this.Step.Text = base.Base_GetBasicCodeName("133", Model.OutWareTopic);
            if (Model.KSO_ContentPersonName != "")
            {
                this.RePerson.Text = Model.KSO_ContentPersonName;//收货联系人
            }
            else
            {
                this.RePerson.Text = base.Base_GetLinkManValue(Model.OutWareSideContact, "XOL_Name");//收货联系人
            }
            this.Phone.Text = Model.KSO_TelPhone;
            this.Address.Text = Model.ContractToAddress;
            this.ContractDeliveMethods.Text = base.Base_GetKClaaName(Model.ContractDeliveMethods);
            this.Remarks.Text = Model.OutWareRemarks;
            this.Lbl_SCutomer.Text = base.Base_GetCustomerName_Link(Model.KSO_SCustomerValue);
            this.Lbl_ShipType.Text = Model.KSO_ShipType;
            this.Lbl_Creator.Text = base.Base_GetUserName(Model.OutWareStaffNo);
            //this.Lbl_MaterNumber.Text = "遥控器：" + Model.KSO_MaterNumber.Replace(",", "电池：");
            //this.Lbl_OrderNo.Text = "遥控器：" + Model.KSO_OrderNo.Replace(",", "电池：");
            this.Lbl_PlanNo.Text = Model.KSO_PlanNo;
            this.Lbl_Type.Text = base.Base_GetBasicCodeName("145", Model.KSO_Type);
            this.Lbl_FhDetails.Text = Model.KSO_FhDetails;
            KNet.BLL.KNet_Sales_OutWareList_Details BLL_Details = new KNet.BLL.KNet_Sales_OutWareList_Details();
            DataSet Dts_Details = BLL_Details.GetList(" OutWareNo='" + Model.OutWareNo + "'");

            if (Dts_Details.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_Details.Tables[0].Rows.Count; i++)
                {
                    s_MyTable_Detail += "<tr>";
                    KNet.BLL.KNet_Sales_ContractList_Details Bll_ContractListDetails = new KNet.BLL.KNet_Sales_ContractList_Details();
                    KNet.Model.KNet_Sales_ContractList_Details Model_ContractListDetails = Bll_ContractListDetails.GetModel(Dts_Details.Tables[0].Rows[i]["KSO_ContractDetailsID"].ToString());
                    if (Model_ContractListDetails != null)
                    {
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\">" +Model_ContractListDetails.ContractNo + "</td>";
                    }
                    else
                    {
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["KSD_ContractNo"].ToString() + "</td>";
                    }
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsCode(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition_Link(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["OutWareAmount"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["KSD_BNumber"].ToString() + "</td>";
                    //查看销售单价权限
                    if (AM.YNAuthority("销售单价查看") == false)
                    {
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\">-</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\">-</td>";
                    }
                    else
                    {
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.FormatNumber(Dts_Details.Tables[0].Rows[i]["outWare_SalesUnitPrice"].ToString(), 3) + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.FormatNumber(Dts_Details.Tables[0].Rows[i]["outWare_SalesTotalNet"].ToString(), 3) + "</td>";
                    }
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["MaterOrderNo"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["RCOrderNo"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["RCMNo"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["MaterMNo"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["KSO_IsFollow"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["OutWareRemarks"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsPattern(Dts_Details.Tables[0].Rows[i]["KSO_Battery"].ToString()) + "</td>";
                   
                    s_MyTable_Detail += "</tr>";
                }
            }

        }
        else
        {
            Response.Write("<script language=javascript>alert('非法参数！');window.close();</script>");
            Response.End();
        }
    }


}
