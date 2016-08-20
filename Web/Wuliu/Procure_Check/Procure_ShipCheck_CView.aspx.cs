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
        this.Lbl_Link.Text = "<a href=\"/WEB/Cg/Payment/CG_Payment_For_Add.aspx?WuliuID=" + s_ID + "\" target=\"_blank\"  class=\"webMnu\">创建用款申请</a>";
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
        this.Lbl_Remarks.Text = Model.COC_Details;
        string s_Sql = "Select * from Xs_Sales_Freight a join KNET_WareHouse_DirectOutList b on a.XSF_FID=b.DirectOutNo ";
            s_Sql+=" join Cg_Order_Checklist_Details c on a.XSF_ID=c.COD_DirectOutID ";
        s_Sql+=" where COD_CheckNo='" + s_ID + "'";
        this.BeginQuery(s_Sql);
        DataSet Dts_Table = (DataSet)this.QueryForDataSet();
        decimal d_Total = 0, d_Total1 = 0, d_Total2 = 0, d_Total3 = 0,d_Total4=0;
        if (Dts_Table.Tables[0].Rows.Count > 0)
        {
            s_MyTable_Detail += "";
            for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
            {
                s_MyTable_Detail += " <tr>";
                string s_DirectOutNo = Dts_Table.Tables[0].Rows[i]["XSF_FID"].ToString();
                string s_Address = Dts_Table.Tables[0].Rows[i]["KWD_Address"].ToString();

                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"left\"><a href=\"/Web/Xs/SalesOut/Sales_ShipWareOut_View.aspx?ID="+s_DirectOutNo+"\">" + s_DirectOutNo + "</a></td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetHouseName(Dts_Table.Tables[0].Rows[i]["HouseNo"].ToString()) + "</td>";

                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"left\">" + base.DateToString(Dts_Table.Tables[0].Rows[i]["XSF_Stime"].ToString()) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetShipDetailProductsPatten(Dts_Table.Tables[0].Rows[i]["XSF_FID"].ToString()) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetCustomerName_Link(Dts_Table.Tables[0].Rows[i]["KWD_Custmoer"].ToString()) + "</td>";

                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\" nowrap>" + base.Base_GetCityName(Dts_Table.Tables[0].Rows[i]["XSF_Province"].ToString()) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\" nowrap>" + base.Base_GetShiName(Dts_Table.Tables[0].Rows[i]["XSF_City"].ToString()) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\" nowrap>" + Dts_Table.Tables[0].Rows[i]["XSF_KDCode"].ToString() + "</td>";

                
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["XSF_TotalNumber"].ToString(), 0) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["XSF_Weight"].ToString(), 0) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["XSF_WuliuPrice"].ToString(), 3) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["XSF_UpstairsCostMoney"].ToString(), 3) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["XSF_DeliveryFee"].ToString(), 3) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["XSF_WareHouseEntry150Low"].ToString(), 3) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["XSF_SignBill"].ToString(), 3) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["XSF_Insured"].ToString(), 3) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["XSF_TotalMoney"].ToString(), 3) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["XSF_FMoney"].ToString(), 3) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["XSF_Money"].ToString(), 3) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["COD_RealMoney"].ToString(), 3) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + Dts_Table.Tables[0].Rows[i]["COD_Details"].ToString() + "</td>";
               

                s_MyTable_Detail += "</tr>";
                try
                {
                    d_Total += decimal.Parse(Dts_Table.Tables[0].Rows[i]["XSF_TotalNumber"].ToString());
                    d_Total1 += decimal.Parse(Dts_Table.Tables[0].Rows[i]["XSF_TotalMoney"].ToString());
                    d_Total2 += decimal.Parse(Dts_Table.Tables[0].Rows[i]["XSF_FMoney"].ToString());
                    d_Total3 += decimal.Parse(Dts_Table.Tables[0].Rows[i]["XSF_Money"].ToString());
                    d_Total4 += decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_RealMoney"].ToString());
                }
                catch
                { }
            }
            s_MyTable_Detail += "<tr>";
            s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"left\" colspan=8>合计：</td>";
            s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_Total.ToString(), 0) + "</td>";
            s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\" colspan=7>&nbsp;</td>";
            s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_Total1.ToString(), 3) + "</td>";
            s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_Total2.ToString(), 3) + "</td>";
            s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_Total3.ToString(), 3) + "</td>";
            s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_Total4.ToString(), 3) + "</td>";
            s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">&nbsp;</td>";
            s_MyTable_Detail += "</tr>";
        }

        string s_SqlWhere = "  CAB_CheckNo='" + Model.COC_Code + "'";
        s_SqlWhere += " order by CAB_MTime desc ";
        KNet.BLL.CG_Account_Bill bll = new KNet.BLL.CG_Account_Bill();
        DataSet ds = bll.GetList(s_SqlWhere);
        this.MyGridView1.DataSource = ds;
        MyGridView1.DataKeyNames = new string[] { "CAB_ID" };
        MyGridView1.DataBind();
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
}
