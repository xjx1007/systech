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
    public string s_MyTable_Detail = "", s_Flow_Detail="";
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
        KNet.BLL.KNet_Sales_OutWareList BLL = new KNet.BLL.KNet_Sales_OutWareList();
        KNet.Model.KNet_Sales_OutWareList Model = BLL.GetModelB(s_ID);
        this.Lbl_Code.Text = Model.OutWareNo;
        this.Lbl_Customer.Text = base.Base_GetCustomerName(Model.CustomerValue);
        this.Lbl_STime.Text = DateTime.Parse(Model.OutWareDateTime.ToString()).ToShortDateString();
        this.Lbl_JType.Text = base.Base_GetKClaaName(Model.ContractDeliveMethods);
        //收货人
        if (Model.KSO_ContentPersonName != "")
        {
            this.Lbl_SuppNo.Text = Model.KSO_ContentPersonName;//收货联系人
            this.Lbl_Tel.Text = Model.KSO_TelPhone;
            this.Lbl_Address.Text = Model.ContractToAddress;//收货联系人
        }
        else
        {
            this.Lbl_SuppNo.Text = base.Base_GetLinkManValue(Model.OutWareSideContact, "XOL_Name");//收货联系人
            this.Lbl_Tel.Text = base.Base_GetLinkManValue(Model.OutWareSideContact, "XOL_Phone");//收货联系人
            this.Lbl_Fax.Text = base.Base_GetLinkManValue(Model.OutWareSideContact, "XOL_Officephone");//收货联系人
            this.Lbl_Address.Text = base.Base_GetLinkManValue(Model.OutWareSideContact, "XOL_Address");//收货联系人
        }
        //KNet.BLL.XS_Compy_LinkMan BLL_LinkMan = new KNet.BLL.XS_Compy_LinkMan();
        //KNet.Model.XS_Compy_LinkMan Model_LinkMan = BLL_LinkMan.GetModel(Model.OutWareSideContact);
        //if (Model_LinkMan != null)
        //{
        //    this.Lbl_SuppNo.Text = Model_LinkMan.XOL_Name;
        //    this.Lbl_Tel.Text = Model_LinkMan.XOL_Phone;
        //    this.Lbl_Fax.Text = Model_LinkMan.XOL_Officephone;
        //    this.Lbl_Address.Text = Model_LinkMan.XOL_Address;
        //}
        KNet.BLL.KNet_Resource_Staff BLL_STaff = new KNet.BLL.KNet_Resource_Staff();
        KNet.Model.KNet_Resource_Staff Model_STaff=BLL_STaff.GetModelC(Model.OutWareOursContact);
        if (Model_STaff == null)
        {
            Model_STaff = BLL_STaff.GetModelByName(Model.OutWareOursContact);
        }
        if (Model_STaff != null)
        {
            this.Lbl_FromDetails.Text = Model_STaff.StaffName;
            this.Lbl_FromTel.Text = Model_STaff.StaffTel;
        }
        this.Lbl_PreTime.Text =  DateTime.Parse(Model.KSO_PlanOutWareDateTime.ToString()).ToShortDateString() ;
        this.Lbl_Remarks.Text = Model.OutWareRemarks;
        LBl_ShipType.Text = Model.KSO_ShipType;
        //this.Lbl_MatialNo.Text = Model.KSO_MaterNumber == null ? "" : "遥控器：" + Model.KSO_MaterNumber.Replace(",", "电池：");
        //this.Lbl_OrderNo.Text = Model.KSO_OrderNo == null?"":"遥控器：" + Model.KSO_OrderNo.Replace(",", "电池：");
        this.Lbl_Plan.Text = Model.KSO_PlanNo;
        this.Lbl_FhDetails.Text = Model.KSO_FhDetails;
        KNet.BLL.KNet_Sales_OutWareList_Details Bll_Details = new KNet.BLL.KNet_Sales_OutWareList_Details();
        DataSet Dts_Table = Bll_Details.GetList(" OutWareNo='" + s_ID + "'");
        decimal d_All_Total = 0;
        if (Dts_Table.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
            {

                s_MyTable_Detail += " <tr>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" +(i+1) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetProdutsName(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetProductsEdition(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetUnitsName(base.Base_GetProductsUnits(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString())) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["OutWareAmount"].ToString(), 0) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["KSD_BNumber"].ToString(), 0) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + Dts_Table.Tables[0].Rows[i]["MaterOrderNo"].ToString() + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + Dts_Table.Tables[0].Rows[i]["RCOrderNo"].ToString() + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + Dts_Table.Tables[0].Rows[i]["RCMNo"].ToString() + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + Dts_Table.Tables[0].Rows[i]["MaterMNo"].ToString() + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + Dts_Table.Tables[0].Rows[i]["KSO_IsFollow"].ToString() + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + Dts_Table.Tables[0].Rows[i]["OutWareRemarks"].ToString() + "</td>";
                d_All_Total += decimal.Parse(Dts_Table.Tables[0].Rows[i]["OutWareAmount"].ToString());
                s_MyTable_Detail += " </tr>";
            }
        }


        KNet.BLL.KNet_Sales_Flow Bll_Flow = new KNet.BLL.KNet_Sales_Flow();
        DataSet Dts_Table1 = Bll_Flow.GetList(" KSF_ContractNo='" + s_ID + "' and KFS_Type='1'  Order  by KSF_Date desc");
        if (Dts_Table1.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < Dts_Table1.Tables[0].Rows.Count; i++)
            {

                s_Flow_Detail += " <tr>";
                s_Flow_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + (i + 1) + "</td>";
                s_Flow_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetUserName(Dts_Table1.Tables[0].Rows[i]["KSF_ShPerson"].ToString()) + "</td>";
                s_Flow_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GeDept(Dts_Table1.Tables[0].Rows[i]["StaffDepart"].ToString()) + "</td>";
                s_Flow_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + Dts_Table1.Tables[0].Rows[i]["KSF_Date"].ToString() + "</td>";
                s_Flow_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + GetFlowName(Dts_Table1.Tables[0].Rows[i]["KSF_State"].ToString()) + "</td>";
                s_Flow_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + Dts_Table1.Tables[0].Rows[i]["KSF_Detail"].ToString() + "</td>";
                s_Flow_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetUserName(Dts_Table1.Tables[0].Rows[i]["KFS_NextPerson"].ToString()) + "</td>";
                s_Flow_Detail += " </tr>";
            }
        }

        
        this.Lbl_AllCount.Text = " 数量合计：" + d_All_Total.ToString();
        //this.Lbl_Rate.Text = " 增值税：￥" + Convert.ToString((d_All_Total * 17) / 100) + "  合计(不含税)：￥" + Convert.ToString((d_All_Total * 83) / 100) + "   总计：￥" + d_All_Total.ToString();
        this.Lbl_Staff.Text = "______<u>" + base.Base_GetUserName(Model_STaff.StaffNo) + "</u>______";
    }

    //流程
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
}
