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
    public string s_MyTable_Detail = "", s_OrderStyle = "", s_DetailsStyle = "";
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
        this.Lbl_Link.Text = "<a href=\"../Bill/CG_Account_Bill_Add.aspx?CheckNo=" + s_ID + "\" target=\"_blank\"  class=\"webMnu\">创建发票</a>";
    }

    private void ShowInfo(string s_ID)
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.BLL.Cg_Order_Checklist BLL = new KNet.BLL.Cg_Order_Checklist();
        KNet.Model.Cg_Order_Checklist Model = BLL.GetModel(s_ID);
        this.Lbl_Code.Text = Model.COC_Code;
        try
        {
            this.Lbl_Stime.Text = DateTime.Parse(Model.COC_Stime.ToString()).ToShortDateString();
        }
        catch { }
        try
        {

            this.Lbl_PreTime.Text = DateTime.Parse(Model.COC_BeginDate.ToString()).ToShortDateString() + "-" + DateTime.Parse(Model.COC_EndDate.ToString()).ToShortDateString();
        }
        catch { }
        try
        {
            Lbl_Type.Text = base.Base_GetBasicCodeName("144", Model.COC_Type);
        }
        catch { }
        try
        {
            Lbl_Supp.Text = base.Base_GetSupplierName_Link(Model.COC_SuppNo);
        }
        catch { }

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
        if (AM.YNAuthority("采购对账审批") == true)
        {
            this.btn_Chcek.Visible = true;
        }
        else
        {
            this.btn_Chcek.Visible = false;

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

        this.CommentList2.CommentFID = Model.COC_Code;
        this.CommentList2.CommentType = 5;

        this.CommentList1.CommentFID = Model.COC_Code;
        this.CommentList1.CommentType ="ProcureCheck";
        
        this.Lbl_Remarks.Text = Model.COC_Details;
        KNet.BLL.Cg_Order_Checklist_Details Bll_Details = new KNet.BLL.Cg_Order_Checklist_Details();
        DataSet Dts_Table = Bll_Details.GetList(" COD_CheckNo='" + s_ID + "'");
        decimal d_Total = 0, d_Total1 = 0, d_Total2 = 0, d_Total3 = 0;
        if (Dts_Table.Tables[0].Rows.Count > 0)
        {
            s_MyTable_Detail += "";
            for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
            {
                s_MyTable_Detail += " <tr>";
                if (Model.COC_Type == "0")//成品对账
                {
                    KNet.BLL.KNet_WareHouse_DirectOutList_Details Bll_DirectOutDetails = new KNet.BLL.KNet_WareHouse_DirectOutList_Details();
                    KNet.Model.KNet_WareHouse_DirectOutList_Details Model_DirectOutDetails = Bll_DirectOutDetails.GetModel(Dts_Table.Tables[0].Rows[i]["COD_DirectOutID"].ToString());
                    if (Model_DirectOutDetails != null)
                    {
                        KNet.BLL.KNet_WareHouse_DirectOutList Bll_DirectOut = new KNet.BLL.KNet_WareHouse_DirectOutList();
                        KNet.Model.KNet_WareHouse_DirectOutList Model_DirectOut = Bll_DirectOut.GetModelB(Model_DirectOutDetails.DirectOutNo);
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + Model_DirectOutDetails.DirectOutNo + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + Model_DirectOut.KWD_ShipNo + "</td>";
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
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\"  nowrap><a href='../OrderInWareHouse/Knet_Procure_WareHouseList_View.aspx?ID=" + Model_WareHouseDetails.WareHouseNo + "' target=\"_blank\">" + Model_WareHouseDetails.WareHouseNo + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + Model_WareHouse.OrderNo + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + DateTime.Parse(Model_WareHouse.WareHouseDateTime.ToString()).ToShortDateString() + "</td>";
                    }
                }
                string s_CustomerValue = base.Base_GetHouseName(Dts_Table.Tables[0].Rows[i]["COD_CustomerValue"].ToString());
                if (s_CustomerValue == "")
                {
                    s_CustomerValue = base.Base_GetCustomerName_Link(Dts_Table.Tables[0].Rows[i]["COD_CustomerValue"].ToString());
                }
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"left\">" + s_CustomerValue + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetProdutsName_Link(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";

                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetProductsCode(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\" nowrap>" + base.Base_GetProductsEdition(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["COD_CkNumber"].ToString(), 0) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["COD_DzNumber"].ToString(), 0) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["COD_BNumber"].ToString(), 0) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["COD_Price"].ToString(), 3) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["COD_HandPrice"].ToString(), 3) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["COD_Money"].ToString(), 3) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + Dts_Table.Tables[0].Rows[i]["COD_Details"].ToString() + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + IsFP(Dts_Table.Tables[0].Rows[i]["COD_Code"].ToString()) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + IsQr(Dts_Table.Tables[0].Rows[i]["COD_Code"].ToString()) + "</td>";
               

                s_MyTable_Detail += "</tr>";
                try
                {
                    d_Total += decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_CkNumber"].ToString());
                    d_Total1 += decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_DzNumber"].ToString());
                    d_Total2 += decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_BNumber"].ToString());
                    d_Total3 += decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_Money"].ToString());
                }
                catch
                { }
            }
            s_MyTable_Detail += "<tr>";
            s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"left\" colspan=7>合计：</td>";
            s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_Total.ToString(), 0) + "</td>";
            s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_Total1.ToString(), 0) + "</td>";
            s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_Total2.ToString(), 0) + "</td>";
            s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">&nbsp;</td>";
            s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">&nbsp;</td>";
            s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_Total3.ToString(), 2) + "</td>";
            s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\" colspan=\"3\">&nbsp;</td>";
            s_MyTable_Detail += "</tr>";
        }

        string s_SqlWhere = "  CAB_CheckNo='" + Model.COC_Code + "'";
        s_SqlWhere += " order by CAB_MTime desc ";
        KNet.BLL.CG_Account_Bill bll = new KNet.BLL.CG_Account_Bill();
        DataSet ds = bll.GetList(s_SqlWhere);
        this.MyGridView1.DataSource = ds;
        MyGridView1.DataKeyNames = new string[] { "CAB_ID" };
        MyGridView1.DataBind();

        try
        {
            KNet.BLL.PB_Basic_Mail bll_Mail = new KNet.BLL.PB_Basic_Mail();
            string s_Sql = "PBM_Del=0 and PBM_FID='" + Model.COC_Code + "' and PBM_Type=4 ";
            s_Sql += " Order by PBM_CTime desc";
            DataSet ds_Mail = bll_Mail.GetList(s_Sql);
            MyGridView3.DataSource = ds_Mail;
            MyGridView3.DataKeyNames = new string[] { "PBM_ID" };
            MyGridView3.DataBind();
        }
        catch
        { }

    }

    public string GetState(string s_State)
    {
        if (s_State == "2")
        {
            return "<font color=red>失败</font>";
        }
        else if (s_State == "1")
        {
            return "<font color=green>成功</font>";
        }
        else
        {

            return "<font color=blue>待发</font>";
        }
    }
    private string IsFP(string s_CABD_CheckDetailsID)
    {
        string b_Return = "<font color=green>未开</font>";
        try
        {
            this.BeginQuery("Select CABD_ID from CG_Account_Bill_Details where CABD_CheckDetailsID='" + s_CABD_CheckDetailsID + "' ");
            string s_ID = this.QueryForReturn();
            if (s_ID != "")
            {
                b_Return = "<font color=red>已开</font>";
            }
        }
        catch { }
        return b_Return;
    }

    private string IsQr(string s_CABD_CheckDetailsID)
    {
        string b_Return = "<font color=red>未确认</font>";
        try
        {
            this.BeginQuery("Select KPO_QRState from Knet_Procure_WareHouseList a join Knet_Procure_WareHouseList_Details b where b.ID='" + s_CABD_CheckDetailsID + "' ");
            string s_ID = this.QueryForReturn();
            if (s_ID != "1")
            {
                b_Return = "已确认";
            }
        }
        catch { }
        return b_Return;
    }
    protected void btn_Chcek_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        if (btn_Chcek.Text == "审批")
        {
            string DoSql = "update Cg_Order_Checklist  set COC_CheckYN=1,COC_CheckPerson ='" + AM.KNet_StaffNo + "',COC_CheckTime='" + DateTime.Now.ToString() + "'  where  COC_Code='" + this.Tbx_ID.Text + "' ";
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

    protected void Button4_Click(object sender, EventArgs e)
    {
        KNet.BLL.Cg_Order_Checklist Bll = new KNet.BLL.Cg_Order_Checklist();
        KNet.Model.Cg_Order_Checklist Model = Bll.GetModel(this.Tbx_ID.Text);
        string JSD = "CG/Procure_Check/Procure_ShipCheck_View.aspx?ID=" + Model.COC_Code + "";
        if (base.HtmlToPdf1(JSD, Server.MapPath("PDF"), this.Tbx_ID.Text))
        {
            Alert("生成成功！");
        }
    }
}
