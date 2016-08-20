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


public partial class Web_Sales_Procure_ShipCheck_CView : BasePage
{
    public string s_MyTable_Detail = "",s_OrderStyle="",s_DetailsStyle="";
    protected void Page_Load(object sender, EventArgs e)
    {
        string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
        string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
        this.Tbx_ID.Text = s_ID;
        if (s_ID != "")
        {
            ShowInfo(s_ID);
        }
            this.Lbl_Title.Text = "查看采购对账单";
            if (s_Type == "1")
            {
                s_OrderStyle = "class=\"dvtUnSelectedCell\"";
                s_DetailsStyle = "class=\"dvtSelectedCell\"";
                Pan_Order.Visible = false;
                Pan_Detail.Visible = true;
                Table_Btn.Visible = false;
            }
            else
            {
                s_DetailsStyle = "class=\"dvtUnSelectedCell\"";
                s_OrderStyle = "class=\"dvtSelectedCell\"";
                Pan_Order.Visible = true;
                Pan_Detail.Visible = false;
                Table_Btn.Visible = true;
            }
            this.Btn_Create.Attributes.Add("onclick", "lhgdialog.opendlg('对账单号:<font color=Red>" + s_ID + "</font> 创建付款计划', '../PayMentPlan/Cw_Accounting_Payment_Simple_Add.aspx?CheckNo=" + s_ID + "',780, 400,false,false);");
    }

    private void ShowInfo(string s_ID)
    {
        AdminloginMess AM=new AdminloginMess();
        KNet.BLL.Cg_Order_Checklist BLL = new KNet.BLL.Cg_Order_Checklist();
        KNet.Model.Cg_Order_Checklist Model = BLL.GetModel(s_ID);
        this.Lbl_Code.Text=Model.COC_Code;
        try{
            this.Lbl_Stime.Text=DateTime.Parse(Model.COC_Stime.ToString()).ToShortDateString();
        }
        catch{}
        try{

            this.Lbl_PreTime.Text = DateTime.Parse(Model.COC_BeginDate.ToString()).ToShortDateString() + "-" + DateTime.Parse(Model.COC_EndDate.ToString()).ToShortDateString();
        }
        catch{}
        try{
            Lbl_Type.Text = base.Base_GetBasicCodeName("144", Model.COC_Type);
        }
        catch { }
        try
        {
        Lbl_Supp.Text = base.Base_GetSupplierName_Link(Model.COC_SuppNo);   
        }
        catch{}

        try
        {
            this.Lbl_House.Text = base.Base_GetHouseName(Model.COC_HouseNo);
        }
        catch { }
        try
        {
            this.Lbl_CheckYN.Text = base.Base_GetBasicCodeName("132", Model.COC_CheckYN.ToString());
        }
        catch { }
        try
        {
            this.Lbl_Check.Text = base.Base_GetUserName(Model.COC_CheckPerson.ToString()) + "<br/>审核时间：" + Model.COC_CheckTime.ToString();
        }
        catch { }

        this.Lbl_IsPayMent.Text = base.Base_GetBasicCodeName("153", Model.COC_IsPayMent.ToString());
        if (Model.COC_IsPayMent == 1)
        {
            this.Btn_Create.Enabled = false;
        }
        if (AM.KNet_StaffDepart == "")
        {
            this.btn_Chcek.Enabled = false;
        }
        else
        {
            this.btn_Chcek.Enabled = true;
        }
        if (Model.COC_CheckYN == 1)
        {
            btn_Chcek.Text = "反审批";
        }
        else
        {
            btn_Chcek.Text = "审批";
        }
        this.Lbl_Remarks.Text = Model.COC_Details;
        KNet.BLL.Cg_Order_Checklist_Details Bll_Details = new KNet.BLL.Cg_Order_Checklist_Details();
        DataSet Dts_Table = Bll_Details.GetList(" COD_CheckNo='" + s_ID + "'");
        if (Dts_Table.Tables[0].Rows.Count > 0)
        {
            s_MyTable_Detail += "";
            for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
            {
                s_MyTable_Detail += " <tr>";
                if (Model.COC_Type == "0")//遥控器对账
                {
                    KNet.BLL.KNet_WareHouse_DirectOutList_Details Bll_DirectOutDetails = new KNet.BLL.KNet_WareHouse_DirectOutList_Details();
                    KNet.Model.KNet_WareHouse_DirectOutList_Details Model_DirectOutDetails = Bll_DirectOutDetails.GetModel(Dts_Table.Tables[0].Rows[i]["COD_DirectOutID"].ToString());
                    if (Model_DirectOutDetails != null)
                    {
                        KNet.BLL.KNet_WareHouse_DirectOutList Bll_DirectOut = new KNet.BLL.KNet_WareHouse_DirectOutList();
                        KNet.Model.KNet_WareHouse_DirectOutList Model_DirectOut = Bll_DirectOut.GetModelB(Model_DirectOutDetails.DirectOutNo);
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + Model_DirectOutDetails.DirectOutNo + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + DateTime.Parse(Model_DirectOut.DirectOutDateTime.ToString()).ToShortDateString() + "</td>";
                    }
                }
                else
                {
                    KNet.BLL.Knet_Procure_WareHouseList_Details Bll_WareHouseDetails = new KNet.BLL.Knet_Procure_WareHouseList_Details();
                    KNet.Model.Knet_Procure_WareHouseList_Details Model_WareHouseDetails = Bll_WareHouseDetails.GetModel(Dts_Table.Tables[0].Rows[i]["COD_DirectOutID"].ToString());
                    if (Model_WareHouseDetails != null)
                    {
                        KNet.BLL.Knet_Procure_WareHouseList Bll_WareHouse = new KNet.BLL.Knet_Procure_WareHouseList();
                        KNet.Model.Knet_Procure_WareHouseList Model_WareHouse = Bll_WareHouse.GetModelB(Model_WareHouseDetails.WareHouseNo);
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + Model_WareHouseDetails.WareHouseNo + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + DateTime.Parse(Model_WareHouse.WareHouseDateTime.ToString()).ToShortDateString() + "</td>";
                    }
 
                }
                 string s_CustomerValue=base.Base_GetHouseName(Dts_Table.Tables[0].Rows[i]["COD_CustomerValue"].ToString());
                if (s_CustomerValue == "")
                {
                    s_CustomerValue = base.Base_GetCustomerName_Link(Dts_Table.Tables[0].Rows[i]["COD_CustomerValue"].ToString());
                }
                s_MyTable_Detail += "<td align=\"left\">" + s_CustomerValue + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetProdutsName_Link(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";

                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString() + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetProductsEdition(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["COD_CkNumber"].ToString(), 0) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["COD_DzNumber"].ToString(), 0) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["COD_BNumber"].ToString(), 0) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["COD_Price"].ToString(), 3) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["COD_HandPrice"].ToString(), 3) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["COD_Money"].ToString(), 3) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + Dts_Table.Tables[0].Rows[i]["COD_Details"].ToString() + "</td>";
                s_MyTable_Detail += "</tr>";
            }
        }
    }
    protected void btn_Chcek_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        if (btn_Chcek.Text == "审批")
        {
            string DoSql = "update Cg_Order_Checklist  set COC_CheckYN=1,COC_CheckPerson ='" + AM.KNet_StaffNo + "',COC_CheckTime='"+DateTime.Now.ToString()+"'  where  COC_Code='" + this.Tbx_ID.Text + "' ";
            DbHelperSQL.ExecuteSql(DoSql);
            btn_Chcek.Text = "反审批";
        }
        else
        {
            string DoSql = "update Cg_Order_Checklist  set COC_CheckYN=0,COC_CheckPerson ='',COC_CheckTime=''  where  COC_Code='" + this.Tbx_ID.Text + "' ";
            DbHelperSQL.ExecuteSql(DoSql);
            btn_Chcek.Text = "审批";
        }
        Alert("审批成功！");
    }
}
