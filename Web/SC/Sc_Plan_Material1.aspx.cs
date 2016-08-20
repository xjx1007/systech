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
using System.Runtime.Serialization.Json;

using KNet.DBUtility;
using KNet.Common;
using System.Net;

public partial class Sc_Plan_Material1 : BasePage
{
    public string s_DivStyle = "";
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            //if (AM.CheckLogin("生产计划列表") == false)
            //{
            //    Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
            //    Response.End();
            //}

            ////删除生产计划
            //if (AM.YNAuthority("删除生产计划") == false)
            //{
            //    this.Btn_Del.Enabled = false;
            //}
            string s_ContractNo = Request.QueryString["ContractNo"] == null ? "" : Request.QueryString["ContractNo"].ToString();
            // this.Tbx_ContractNo.Text = s_ContractNo;
            string s_OrderNo = Request.QueryString["OrderNo"] == null ? "" : Request.QueryString["OrderNo"].ToString();
            string s_SuppNo = Request.QueryString["SuppNo"] == null ? "" : Request.QueryString["SuppNo"].ToString();
            string s_HouseNo = Request.QueryString["HouseNo"] == null ? "" : Request.QueryString["HouseNo"].ToString();
            string s_ProductsBarCode = Request.QueryString["ProductsBarCode"] == null ? "" : Request.QueryString["ProductsBarCode"].ToString();
            this.Tbx_HouseNo.Value = s_HouseNo;
            this.Tbx_HouseName.Text = base.Base_GetHouseName(s_HouseNo);
            if (s_ProductsBarCode != "")
            {
                this.Tbx_ProductsName.Text = base.Base_GetProductsEdition(s_ProductsBarCode);
                this.Tbx_ProductsBarCode.Value = s_ProductsBarCode;
            }
            this.Tbx_ID.Text = s_OrderNo;
            s_DivStyle = "<table width=\"100%\"><tr><td  align=\"center\"><div style='border: 3px solid rgb(153, 153, 153); background-color: rgb(255, 255, 255); width: 45%; position: relative; z-index: 10000000;'> <table border='0' cellpadding='5' cellspacing='0' width='98%'><tr> <td rowspan='2' width='25%'><img src='../../themes/softed/images/empty.jpg' height='60' width='61'></td> <td style='border-bottom: 1px solid rgb(204, 204, 204);' nowrap='nowrap' width='75%'><span class='genHeaderSmall'>记录为空</span></td></tr></table> </div></td></tr></table>";
            this.Lbl_Details.Text = " <div style=\"text-align: center\"><img id=\"Imag_Load\" style=\"border-top-width: 0px; border-right-width: 0px; border-bottom-width: 0px; border-left-width: 0px;\" src=\"../../images/loading.gif\"/></div>";
            if (s_SuppNo != "")
            {
                this.Lbl_Details.Text = this.DataShowsBySupp(s_SuppNo);
            }
        }
    }

    protected string DataShowsBySupp(string s_suppNo)
    {

        KNet.BLL.Knet_Procure_OrdersList bll = new KNet.BLL.Knet_Procure_OrdersList();
        string SqlWhere = " 1=1 ";
        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string s_Type = "";

        StringBuilder Sb_DivStylea = new StringBuilder();
        if (s_WhereID != "")
        {
            SqlWhere += Base_GetBasicWhere(s_WhereID);
        }

        if (this.Tbx_ID.Text != "")
        {
            SqlWhere = SqlWhere + " and OrderNo='" + this.Tbx_ID.Text + "' ";
        }
        if (s_suppNo != "")
        {

            SqlWhere = SqlWhere + " and SuppNo='" + s_suppNo + "' ";
        }
        string s_SuppNo1 = Request.QueryString["SuppNo"] == null ? "" : Request.QueryString["SuppNo"].ToString();
        if (s_SuppNo1 != "")
        {

            SqlWhere = SqlWhere + " and SuppNo='" + s_SuppNo1 + "' ";
        }
        if (this.Tbx_HouseNo.Value != "")
        {

            SqlWhere = SqlWhere + " and SuppNo='" + this.Tbx_HouseNo.Value + "' ";
        }
        SqlWhere = SqlWhere + " and KPO_Del=0  and rkState<>'1' and KPO_RkState='0' and orderType='128860698200781250' ";
        SqlWhere = SqlWhere + " Order by SuppNo,OrderDateTime ";


        //先查找供应商

        DataSet ds = bll.GetList(SqlWhere);
        s_DivStyle = "";
        if (ds.Tables[0].Rows.Count > 0)
        {
            Sb_DivStylea.Append("<table class=\"ListDetails\" cellspacing=\"0\" rules=\"all\" border=\"1\" id=\"GridView1\" style=\"border-color: #4974C2; width: 100%; border-collapse: collapse;\">\n");
            Sb_DivStylea.Append(" <tr class=\"colHeader\" style=\"Height:30px\">\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">序号</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">采购单号</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">合同编号</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">采购日期</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">到货日期</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">供应商</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">产品类型</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">采购数量</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">未入库数量</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\" width=\"180px\">说明</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">库存</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">需求</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">在途</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">缺料</td>\n");
            Sb_DivStylea.Append("</tr>\n");
            string s_ContractNos = "";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Sb_DivStylea.Append("<tr style=\"font-weight:bolder;Height:30px\">\n");
                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\"><font color=red>" + Convert.ToString(i + 1) + "</font>.<a onclick=\"fnVisible('layer_H" + i.ToString() + "')\"  href=\"#\"></a>OEM</td>\n");
                string s_OrderNo = ds.Tables[0].Rows[i]["OrderNo"].ToString();
                KNet.Model.Knet_Procure_OrdersList Model = bll.GetModelB(s_OrderNo);
                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\"><a href=\"../Cg/Order/Knet_Procure_OpenBilling_View.aspx?ID=" + s_OrderNo + "\" target=\"_blank\">" + s_OrderNo + "</td>\n");
                s_ContractNos = ds.Tables[0].Rows[i]["ContractNos"].ToString();
                Sb_DivStylea.Append("<td align=\"center\" class=\"ListHeadDetails\">" + GetContract(s_ContractNos) + "</td>\n");

                string s_Date = "", s_PreDate = "";
                string s_SuppNo = ds.Tables[0].Rows[i]["SuppNo"].ToString();
                try
                {
                    s_Date = DateTime.Parse(ds.Tables[0].Rows[i]["OrderDateTime"].ToString()).ToShortDateString();
                    s_PreDate = DateTime.Parse(ds.Tables[0].Rows[i]["OrderPREToDate"].ToString()).ToShortDateString();
                }
                catch { }
                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + s_Date + "</td>\n");
                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + s_PreDate + "</td>\n");
                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + base.Base_GetSupplierName_Link(ds.Tables[0].Rows[i]["SuppNo"].ToString()) + "</td>\n");
                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + base.Base_GetOrderDetailProductsPatten(s_OrderNo) + "</td>\n");
                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + ds.Tables[0].Rows[i]["OrderAmount"].ToString() + "</td>\n");
                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + ds.Tables[0].Rows[i]["wrkNumber"].ToString() + "</td>\n");
                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\" >&nbsp;</td>\n");
                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\" >&nbsp;</td>\n");

                KNet.BLL.KNet_Sys_WareHouse Bll = new KNet.BLL.KNet_Sys_WareHouse();
                KNet.Model.KNet_Sys_WareHouse Model_WareHouse = Bll.GetModelBySuppNo(s_SuppNo);
                string s_HouseNo = Model_WareHouse.HouseNo == null ? "" : Model_WareHouse.HouseNo.ToString();
                Lbl_House.Text = "<a href=\"Sc_Plan_QLMaterial.aspx?HouseNo=" + s_HouseNo + "\" target=\"_blank\">" + Model_WareHouse.HouseName + "</a>";
                this.BeginQuery("Select *  from Knet_Procure_OrdersList_Details where OrderNo ='" + s_OrderNo + "'");
                DataTable Dtb_OrderDetails = (DataTable)this.QueryForDataTable();
                string s_Details = "";
                if (Dtb_OrderDetails.Rows.Count > 0)
                {
                    for (int ii = 0; ii < Dtb_OrderDetails.Rows.Count; ii++)
                    {
                        string s_OrderProductsBarCode = Dtb_OrderDetails.Rows[ii]["ProductsBarCode"].ToString();
                        string s_OrderProductsEdition = base.Base_GetProductsEdition(s_OrderProductsBarCode);
                        s_Details += base.Base_GetHouseAndNumber1(s_OrderProductsBarCode, s_HouseNo) + "<br>";
                    }
                    s_Details.Substring(0, s_Details.Length - 4);
                }
                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\" >" + s_Details + "</td>\n");
                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\" >&nbsp;</td>\n");
                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\" >&nbsp;</td>\n");

                Sb_DivStylea.Append("</tr >\n");

                string s_Sql = "Select b.ProductsType,a.XPD_ProductsBarCode,c.*,isnull(NeedNumber,0) NeedNumber,isnull(e.Number,0) WNumber,isnull(g.Number,0) as KCNumber  from Xs_Products_Prodocts_Demo a ";
                s_Sql += " join KNet_Sys_Products b on a.XPD_ProductsBarCode=b.ProductsBarCode";
                s_Sql += " left join v_OrderRkDetails c on c.V_ProductsBarCode=a.XPD_ProductsBarCode and c.v_ParentOrderNo='" + s_OrderNo + "'";
                s_Sql += " left join v_OrderNeed f on MaterProductsBarCode=b.ProductsBarCode and f.HouseNO='" + s_HouseNo + "' ";
                s_Sql += " left join v_Cg_OrderWrkNumber e on e.ProductsBarCode=b.ProductsBarCode  and e.HouseNO=f.HouseNO and e.number<>0 ";
                s_Sql += " left join v_ProdutsStore g on g.ProductsBarCode=b.ProductsBarCode and g.HouseNO=f.HouseNO  ";
                s_Sql += "  where b.KSP_Del=0   and XPD_FaterBarCode In (select ProductsBarCode from Knet_Procure_OrdersList_Details where OrderNo='" + s_OrderNo + "')  ";
                if (this.Tbx_ProductsBarCode.Value != "")
                {
                    s_Sql = s_Sql + " and XPD_ProductsBarCode='" + this.Tbx_ProductsBarCode.Value + "' ";
                }
                this.BeginQuery(s_Sql);
                this.QueryForDataTable();
                DataTable Dtb_ProductsTable = Dtb_Result;
                if (Dtb_ProductsTable != null)
                {
                    Sb_DivStylea.Append("<div id=\"layer_H" + i.ToString() + "\" class=\"drag_Element\">\n");
                    if (Dtb_ProductsTable.Rows.Count > 0)
                    {
                        for (int j = 0; j < Dtb_ProductsTable.Rows.Count; j++)
                        {
                            Sb_DivStylea.Append("<tr class=\"ListHeadDetails\"  >");
                            Sb_DivStylea.Append("<td align=\"right\"  class=\"ListHeadDetails\">" + Convert.ToString(j + 1) + "</td>\n");
                            string s_DetailsOrderNo = Dtb_ProductsTable.Rows[j]["v_OrderNo"] == null ? "" : Dtb_ProductsTable.Rows[j]["v_OrderNo"].ToString();
                            string s_DetailsID = Dtb_ProductsTable.Rows[j]["KPO_ID"] == null ? "" : Dtb_ProductsTable.Rows[j]["KPO_ID"].ToString();
                            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHeadDetails\"><a href=\"../CG/Order/Knet_Procure_OpenBilling_View.aspx?ID=" + s_DetailsOrderNo + "\" target=\"_blank\">" + s_DetailsOrderNo + "</td>\n");

                            Sb_DivStylea.Append("<td align=\"center\" class=\"ListHeadDetails\">" + GetContract(s_ContractNos) + "</td>\n");
                            if (s_DetailsOrderNo != "")
                            {
                                KNet.Model.Knet_Procure_OrdersList Model_OrdersList = bll.GetModelB(s_DetailsOrderNo);
                                try
                                {
                                    s_Date = DateTime.Parse(Model_OrdersList.OrderDateTime.ToString()).ToShortDateString();
                                }
                                catch
                                {
                                    s_Date = "";
                                }
                                string s_FollowText = "";
                                try
                                {
                                    string s_Sql1 = " select top 1 * from KNet_Sales_OutWareList_FlowList where ReTime is not null and OutWareNO='" + s_DetailsOrderNo + "' order by FollowDateTime desc";
                                    this.BeginQuery(s_Sql1);
                                    DataTable Dtb_Details = (DataTable)this.QueryForDataTable();
                                    if (Dtb_Details.Rows.Count > 0)
                                    {
                                        s_FollowText = Dtb_Details.Rows[0]["FollowText"].ToString();
                                        s_PreDate = DateTime.Parse(Dtb_Details.Rows[0]["ReTime"].ToString()).ToShortDateString();

                                    }
                                    else
                                    {
                                        s_PreDate = "";
                                        s_FollowText = "";
                                    }
                                    // s_Date = DateTime.Parse(Model_OrdersList.OrderDateTime.ToString()).ToShortDateString();
                                    //s_PreDate = DateTime.Parse(Model_OrdersList.OrderPreToDate.ToString()).ToShortDateString();
                                }
                                catch
                                {
                                    s_PreDate = "";
                                    s_FollowText = "";
                                }
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + s_Date + "</td>\n");
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + s_PreDate + "</td>\n");
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + base.Base_GetSupplierName_Link(Model_OrdersList.SuppNo) + "</td>\n");
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + base.Base_GetProductsEdition_Link(Dtb_ProductsTable.Rows[j]["XPD_ProductsBarCode"] == null ? "" : Dtb_ProductsTable.Rows[j]["XPD_ProductsBarCode"].ToString()) + "</td>\n");
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + Dtb_ProductsTable.Rows[j]["v_OrderAmount"].ToString() + "</td>\n");
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + Dtb_ProductsTable.Rows[j]["wrkNumber"].ToString() + "</td>\n");
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + s_FollowText + "</td>\n");//快递

                                string s_WareHouseNumber = Dtb_ProductsTable.Rows[j]["KCNumber"].ToString();
                                string s_ProductsBarCode = Dtb_ProductsTable.Rows[j]["XPD_ProductsBarCode"].ToString();
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + s_WareHouseNumber + "</td>\n");//快递
                                string s_NeedNumber = Dtb_ProductsTable.Rows[j]["NeedNumber"].ToString();// base.Base_GetHouseAndNeedNumber1(s_ProductsBarCode, s_HouseNo);
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + s_NeedNumber + "</td>\n");//需求数量
                                string s_OrderLeftNumber = Dtb_ProductsTable.Rows[j]["WNumber"].ToString(); //base.Base_GetOrderWrkNumber(s_ProductsBarCode, s_HouseNo);
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + s_OrderLeftNumber + "</td>\n");//需求数量
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\"><a href=\"Sc_Plan_QLMaterial.aspx?ProductsBarCode=" + s_ProductsBarCode + "&HouseNo=" + s_HouseNo + "\" target=\"_blank\">" + GetLefNumber(s_WareHouseNumber, s_OrderLeftNumber, s_NeedNumber) + "</a></td>\n");//需求数量

                            }
                            else
                            {

                                string s_ProductsBarCode = Dtb_ProductsTable.Rows[j]["XPD_ProductsBarCode"].ToString();
                                Sb_DivStylea.Append("<td align=\"center\" class=\"ListHeadDetails\" colspan=\"3\"><font color=red>未找到订单</font></td>\n");
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\" colspan=\"4\">" + base.Base_GetProductsEdition_Link(Dtb_ProductsTable.Rows[j]["XPD_ProductsBarCode"] == null ? "" : Dtb_ProductsTable.Rows[j]["XPD_ProductsBarCode"].ToString()) + "</td>\n");
                                string s_WareHouseNumber = Dtb_ProductsTable.Rows[j]["KCNumber"].ToString();// base.Base_GetHouseAndNumber1(s_ProductsBarCode, s_HouseNo);
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + s_WareHouseNumber + "</td>\n");//快递
                                string s_NeedNumber = Dtb_ProductsTable.Rows[j]["NeedNumber"].ToString(); //base.Base_GetHouseAndNeedNumber1(s_ProductsBarCode, s_HouseNo);
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + s_NeedNumber + "</td>\n");//需求数量
                                string s_OrderLeftNumber = Dtb_ProductsTable.Rows[j]["WNumber"].ToString(); //base.Base_GetOrderWrkNumber(s_ProductsBarCode, s_HouseNo);
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + s_OrderLeftNumber + "</td>\n");//需求数量
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\"><a href=\"Sc_Plan_QLMaterial.aspx?ProductsBarCode=" + s_ProductsBarCode + "&HouseNo=" + s_HouseNo + "\" target=\"_blank\">" + GetLefNumber(s_WareHouseNumber, s_OrderLeftNumber, s_NeedNumber) + "</a></td>\n");//需求数量
                            }
                            Sb_DivStylea.Append("</tr >\n");
                        }
                    }

                    Sb_DivStylea.Append("<tr>\n");


                    //查找其他原材料和电池订单和库存
                    string s_DetailsSql = "Select e.ProductsBarCode,v_LeftDirectOutNumber Number from KNet_Sales_ContractList a join KNet_Sales_ContractList_Details b on a.ContractNo=b.ContractNo ";
                    s_DetailsSql += " join KNet_Sys_Products e on e.ProductsBarCode=b.ProductsBarCode   join v_Contract_OutWare_DirectOut_Total on v_ContractNo=a.ContractNo and v_ProductsBarCode=b.ProductsBarCode ";
                    s_DetailsSql += " where a.ContractNo in('" + s_ContractNos.Replace(",", "','") + "') and ProductsType in ('M130704050932527') and v_LeftDirectOutNumber>0   ";
                    this.BeginQuery(s_DetailsSql);
                    DataTable Dtb_DcDetails = (DataTable)this.QueryForDataTable();
                    if (Dtb_DcDetails.Rows.Count > 0)
                    {
                        for (int k = 0; k < Dtb_DcDetails.Rows.Count; k++)
                        {
                            string s_ProductsBarCode = Dtb_DcDetails.Rows[k]["ProductsBarCode"].ToString();
                            string s_Number = Dtb_DcDetails.Rows[k]["Number"].ToString();
                            if (s_ContractNos != "")
                            {
                                string s_CgSql = "Select a.OrderNo,Sum(OrderAmount) from Knet_Procure_OrdersList a join Knet_Procure_OrdersList_Details b on a.OrderNo=b.OrderNo ";
                                s_CgSql += " where a.ContractNos='" + s_ContractNos + "' and ProductsBarCode='" + s_ProductsBarCode + "' group by  a.OrderNo ";
                                this.BeginQuery(s_CgSql);
                                DataTable Dtb_CgTable = this.QueryForDataTable();
                                if (Dtb_CgTable.Rows.Count > 0)
                                {
                                    string s_CgOrderNo = Dtb_CgTable.Rows[0]["OrderNo"].ToString();
                                    string s_OrderAmount = Dtb_CgTable.Rows[0][1].ToString();
                                    Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\"><a href=\"../Cg/Order/Knet_Procure_OpenBilling_View.aspx?ID=" + s_CgOrderNo + "\" target=\"_blank\">" + s_CgOrderNo + "</td>\n");
                                    Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + GetContract(s_ContractNos) + "</td>\n");
                                    Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\" >" + base.Base_GetProductsEdition_Link(s_ProductsBarCode) + "</td>\n");
                                    Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\" >" + s_OrderAmount + "</td>\n");
                                }
                                else
                                {
                                    Sb_DivStylea.Append("<td align=\"center\" class=\"ListHeadDetails\" colspan=\"2\" >&nbsp;</td>\n");

                                    Sb_DivStylea.Append("<td align=\"center\" class=\"ListHeadDetails\" >" + GetContract(s_ContractNos) + "</td>\n");

                                    Sb_DivStylea.Append("<td align=\"center\" class=\"ListHeadDetails\" colspan=\"3\"><font color=red>未找到订单</font></td>\n");
                                    Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\" >" + base.Base_GetProductsEdition_Link(s_ProductsBarCode) + "</td>\n");
                                    Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + s_Number + "</td>\n");
                                    Sb_DivStylea.Append("<td align=\"center\" class=\"ListHeadDetails\" colspan=\"2\" >&nbsp;</td>\n");

                                    string s_WareHouseNumber = base.Base_GetHouseAndNumber1(s_ProductsBarCode, s_HouseNo);
                                    Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + s_WareHouseNumber + "</td>\n");//快递
                                    string s_NeedNumber = GetBatteryNumber(s_ProductsBarCode, s_HouseNo);
                                    Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + s_NeedNumber + "</td>\n");//需求数量

                                    string s_OrderLeftNumber = base.Base_GetOrderWrkNumber(s_ProductsBarCode, s_HouseNo);
                                    Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + s_OrderLeftNumber + "</td>\n");//需求数量
                                    Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\"><a href=\"Sc_Plan_QLMaterial.aspx?ProductsBarCode=" + s_ProductsBarCode + "&HouseNo=" + s_HouseNo + "\" target=\"_blank\">" + GetLefNumber(s_WareHouseNumber, s_OrderLeftNumber, s_NeedNumber) + "</a></td>\n");//需求数量

                                }
                            }

                        }
                    }
                    Sb_DivStylea.Append("</tr>\n");
                }
            }

        }
        Sb_DivStylea.Append("</table>\n");
        Sb_DivStylea.Append("</div>\n");
        return Sb_DivStylea.ToString();
    }
    public string GetBatteryNumber(string s_ProductsBarCode, string s_HouseNo)
    {
        //查找该OEM的所有订单需要的电池
        string s_Return = "";
        try
        {
            string s_Sql = "Select distinct ContractNos from v_OrderNeed_Details where HouseNO='" + s_HouseNo + "'";
            this.BeginQuery(s_Sql);
            string s_ContractNos = "";
            DataTable Dtb_Battery = (DataTable)this.QueryForDataTable();
            if (Dtb_Battery.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Battery.Rows.Count; i++)
                {
                    s_ContractNos += Dtb_Battery.Rows[i][0] + ",";
                }
            }
            if (s_ContractNos != "")
            {

               // string s_FhNumber = GetDirectOutDetails(s_ContractNos);
                //查找订单需求数量
                string s_DetailsSql = "Select Sum(v_LeftDirectOutNumber) Number  from v_Contract_OutWare_DirectOut_Total  a ";
                s_DetailsSql += " where a.v_ContractNo in('" + s_ContractNos.Replace(",", "','") + "') ";

                if (s_ProductsBarCode != "")
                {
                    s_DetailsSql += " and  a.v_ProductsBarCode='" + s_ProductsBarCode + "' and v_LeftDirectOutNumber>0 ";
                }
                this.BeginQuery(s_DetailsSql);
                DataTable Dtb_DcDetails = (DataTable)this.QueryForDataTable();
                if (Dtb_DcDetails.Rows.Count > 0)
                {
                    s_Return = Convert.ToString(decimal.Parse(Dtb_DcDetails.Rows[0]["Number"].ToString()));
                }
            }
        }
        catch
        { }
        return s_Return;
    }
    public string GetContract(string s_ContractNos)
    {
        string s_Return = "";
        try
        {
            string[] s_ContractNo = s_ContractNos.Split(',');
            for (int i = 0; i < s_ContractNo.Length; i++)
            {
                s_Return += "<a href=\"../Xs/SalesContract/KNet_Sales_ContractList_View.aspx?ID=" + s_ContractNo[i] + "\"  target=\"_blank\">" + s_ContractNo[i] + "</a><br>";

            }
        }
        catch
        { }
        return s_Return;
    }


    public string GetLefNumber(string s_KCNumber, string s_OrderNumber, string s_NeedNumber)
    {
        string s_return = "";
        try
        {
            decimal d_Left = decimal.Parse(s_NeedNumber.Trim()) - decimal.Parse(s_OrderNumber.Trim()) - decimal.Parse(s_KCNumber.Trim());
            if (d_Left > 0)
            {
                s_return = "<font color=red>" + d_Left.ToString() + "</font>";
            }
            else
            {
                s_return = "<font color=green>" + Math.Abs(d_Left).ToString() + "</font>";

            }
        }
        catch
        { }
        return s_return;
    }

    public string GetCk(string s_OutWareNo)
    {
        string s_Return = "";
        try
        {
            KNet.BLL.KNet_WareHouse_DirectOutList Bll = new KNet.BLL.KNet_WareHouse_DirectOutList();
            DataSet Dts_Table = Bll.GetList(" KWD_ShipNo='" + s_OutWareNo + "'");
            if (Dts_Table.Tables[0].Rows.Count > 0)
            {
                s_Return = DateTime.Parse(Dts_Table.Tables[0].Rows[0]["DirectOutDateTime"].ToString()).ToShortDateString();
            }
        }
        catch (Exception ex)
        {

        }
        return s_Return;
    }

    private string GetDirectOutDetails(string s_ContractNos)
    {
        string s_Return = "0";
        try
        {
            string s_Sql = "Select Sum(DirectOutAMount) from v_Contract_OutWare_DirectOut_Total  join KNet_Sys_Products e on e.ProductsBarCode=v_ProductsBarCode ";
            s_Sql += "  where v_ContractNo<>'' and v_ContractNo in ('" + s_ContractNos.Replace(",", "','") + "') and ProductsType in ('M130704050932527')  ";
            this.BeginQuery(s_Sql);
            DataTable Dtb_Tabel = (DataTable)this.QueryForDataTable();
            if (Dtb_Tabel.Rows.Count > 0)
            {
                s_Return = Dtb_Tabel.Rows[0][0].ToString();
            }
        }
        catch
        { }
        return s_Return;

    }

}
