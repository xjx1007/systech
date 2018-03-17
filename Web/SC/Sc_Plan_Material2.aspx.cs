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

public partial class Sc_Plan_Material2 : BasePage
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
            if (s_OrderNo != "")
            {
                this.Lbl_Details.Text = this.DataShowsBySupp1(s_OrderNo);
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
        string s_FromOrderNo = Request["OrderNo"] == null ? "" : Request["OrderNo"].ToString();
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


        if (s_FromOrderNo != "")
        {
            SqlWhere = SqlWhere + " and OrderNo='" + s_FromOrderNo + "' ";
        }
        /*
        //OEM
        if (s_suppNo != "")
        {

            SqlWhere = SqlWhere + " and SuppNo='" + s_suppNo + "' ";
        }
        string s_SuppNo1 = Request.QueryString["SuppNo"] == null ? "" : Request.QueryString["SuppNo"].ToString();
        if (s_SuppNo1 != "")
        {

            SqlWhere = SqlWhere + " and SuppNo='" + s_SuppNo1 + "' ";
        }
         * */
        //收货供应商

        if (s_suppNo != "")
        {

            SqlWhere = SqlWhere + " and ReceiveSuppNo='" + s_suppNo + "' ";
        }
        string s_SuppNo1 = Request.QueryString["SuppNo"] == null ? "" : Request.QueryString["SuppNo"].ToString();
        if (s_SuppNo1 != "")
        {

            SqlWhere = SqlWhere + " and ReceiveSuppNo='" + s_SuppNo1 + "' ";
        }
        if (this.Tbx_HouseNo.Value != "")
        {
            SqlWhere = SqlWhere + " and SuppNo='" + this.Tbx_HouseNo.Value + "' ";
        }
        SqlWhere = SqlWhere + " and KPO_Del=0  and rkState<>'1' and KPO_RkState='0' and orderType='128860698200781250' ";
        SqlWhere = SqlWhere + " Order by SuppNo,OrderDateTime ";

        //更新产品库存
         //GetNewStore();
        //先查找供应商

        DataSet ds = bll.GetList(SqlWhere);
        s_DivStyle = "";
        if (ds.Tables[0].Rows.Count > 0)
        {
            Sb_DivStylea.Append("<table class=\"ListDetails\" cellspacing=\"0\" rules=\"all\" border=\"1\" id=\"GridView1\" style=\"border-color: #4974C2; width: 100%; border-collapse: collapse;\">\n");
            Sb_DivStylea.Append(" <tr class=\"colHeader\" style=\"Height:30px\">\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">序号</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">采购单号</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">采购日期</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">到货日期</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">供应商</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">产品名称</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">产品类型</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">采购数量</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">未入库数量</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\" width=\"180px\">说明</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">缺料</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">总缺料</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">库存</td>\n");

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

                string s_Date = "", s_PreDate = "";
                /*
                //OEM
                string s_SuppNo = ds.Tables[0].Rows[i]["SuppNo"].ToString();
                 * */
                string s_SuppNo = ds.Tables[0].Rows[i]["ReceiveSuppNo"].ToString();

                try
                {
                    s_Date = DateTime.Parse(ds.Tables[0].Rows[i]["OrderDateTime"].ToString()).ToShortDateString();
                    s_PreDate = DateTime.Parse(ds.Tables[0].Rows[i]["OrderPREToDate"].ToString()).ToShortDateString();
                }
                catch { }
                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + s_Date + "</td>\n");
                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + s_PreDate + "</td>\n");
                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + base.Base_GetSupplierName(ds.Tables[0].Rows[i]["SuppNo"].ToString()) + "</td>\n");
                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">成品</td>\n");
                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + base.Base_GetOrderDetailProductsPatten(s_OrderNo) + "</td>\n");
                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + ds.Tables[0].Rows[i]["OrderAmount"].ToString() + "</td>\n");
                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + ds.Tables[0].Rows[i]["wrkNumber"].ToString() + "</td>\n");
                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\" >&nbsp;</td>\n");
                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\" >&nbsp;</td>\n");
                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\" >&nbsp;</td>\n");

                KNet.BLL.KNet_Sys_WareHouse Bll = new KNet.BLL.KNet_Sys_WareHouse();
                KNet.Model.KNet_Sys_WareHouse Model_WareHouse = Bll.GetModelBySuppNo(s_SuppNo);
                string s_HouseNo = Model_WareHouse.HouseNo == null ? "" : Model_WareHouse.HouseNo.ToString();
                this.Tbx_HouseNo.Value = s_HouseNo;
                /* Lbl_House.Text = "<a href=\"Sc_Plan_QLMaterial.aspx?HouseNo=" + s_HouseNo + "\" target=\"_blank\">" + Model_WareHouse.HouseName + "</a>";
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
                 * */
                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\" >&nbsp;</td>\n");

                Sb_DivStylea.Append("</tr >\n");

                string s_Sql = "Select b.ProductsType,d.NeedNumber,a.XPD_ProductsBarCode,c.*,b.*,aa.totalNumber,";
                s_Sql += "(select top 1 FollowText from KNet_Sales_OutWareList_FlowList where ReTime is not null and OutWareNO=v_OrderNo  order by FollowDateTime desc) FollowText,";
                s_Sql += "(select top 1 ReTime from KNet_Sales_OutWareList_FlowList where ReTime is not null and OutWareNO=v_OrderNo  order by FollowDateTime desc) ReTime from Xs_Products_Prodocts_Demo a ";
                s_Sql += " join KNet_Sys_Products b on a.XPD_ProductsBarCode=b.ProductsBarCode";
                s_Sql += " left join v_OrderRkDetails c on c.V_ProductsBarCode=a.XPD_ProductsBarCode and c.v_ParentOrderNo='" + s_OrderNo + "'";
                s_Sql += " left join v_NeedNumberStore d on d.ProductsBarCode=a.XPD_ProductsBarCode and d.HouseNo='" + s_HouseNo + "'  ";
                s_Sql += " left join( select Sum(NeedNumber) totalNumber,ProductsBarCode from v_NeedNumberStore group by ProductsBarCode) aa on aa.ProductsBarCode=a.XPD_ProductsBarCode  ";
                s_Sql += "  where b.KSP_Del=0  and a.XPD_IsMail=0  and XPD_FaterBarCode In (select ProductsBarCode from Knet_Procure_OrdersList_Details where OrderNo='" + s_OrderNo + "')  ";
                if (this.Tbx_ProductsBarCode.Value != "")
                {
                    s_Sql = s_Sql + " and XPD_ProductsBarCode='" + this.Tbx_ProductsBarCode.Value + "' ";
                }
                s_Sql += "  order by b.ProductsName ";

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

                                    s_FollowText = Dtb_ProductsTable.Rows[j]["FollowText"].ToString();
                                    s_PreDate = DateTime.Parse(Dtb_ProductsTable.Rows[j]["ReTime"].ToString()).ToShortDateString();
                                }
                                catch
                                {
                                    s_PreDate = "";
                                    s_FollowText = "";
                                }
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + s_Date + "</td>\n");
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + s_PreDate + "</td>\n");
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + base.Base_GetSupplierName(Model_OrdersList.SuppNo) + "</td>\n");
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + Dtb_ProductsTable.Rows[j]["ProductsName"].ToString() + "</td>\n");
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + Dtb_ProductsTable.Rows[j]["ProductsEdition"].ToString() + "</td>\n");
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + Dtb_ProductsTable.Rows[j]["v_OrderAmount"].ToString() + "</td>\n");
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + Dtb_ProductsTable.Rows[j]["wrkNumber"].ToString() + "</td>\n");
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + s_FollowText + "</td>\n");//快递

                                string s_ProductsBarCode = Dtb_ProductsTable.Rows[j]["XPD_ProductsBarCode"].ToString();

                                string s_NeedNumber = "-";
                                s_NeedNumber = Dtb_ProductsTable.Rows[j]["NeedNumber"].ToString() == "" ? "-" : Dtb_ProductsTable.Rows[j]["NeedNumber"].ToString();
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\"><a href=\"Sc_Plan_QLMaterial.aspx?ProductsBarCode=" + s_ProductsBarCode + "&HouseNo=" + s_HouseNo + "\" target=\"_blank\">" + base.GetColorNumber(s_NeedNumber) + "</a></td>\n");//需求数量

                                string s_totalNumber = "-";
                                s_totalNumber = Dtb_ProductsTable.Rows[j]["totalNumber"].ToString() == "" ? "-" : Dtb_ProductsTable.Rows[j]["totalNumber"].ToString();
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\"><a href=\"Sc_Plan_QLMaterial.aspx?ProductsBarCode=" + s_ProductsBarCode + "\" target=\"_blank\">" + base.GetColorNumber(s_totalNumber) + "</a></td>\n");//需求数量
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + base.Base_GetHouseAndNumber1(s_ProductsBarCode, this.Tbx_HouseNo.Value) + "</td>\n");


                            }
                            else
                            {

                                string s_ProductsBarCode = Dtb_ProductsTable.Rows[j]["XPD_ProductsBarCode"].ToString();
                                Sb_DivStylea.Append("<td align=\"center\" class=\"ListHeadDetails\" colspan=\"3\">&nbsp;</td>\n");
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\" >" + base.Base_GetProdutsName(Dtb_ProductsTable.Rows[j]["XPD_ProductsBarCode"] == null ? "" : Dtb_ProductsTable.Rows[j]["XPD_ProductsBarCode"].ToString()) + "</td>\n");
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\" colspan=\"4\">" + base.Base_GetProductsEdition(Dtb_ProductsTable.Rows[j]["XPD_ProductsBarCode"] == null ? "" : Dtb_ProductsTable.Rows[j]["XPD_ProductsBarCode"].ToString()) + "</td>\n");
                                string s_NeedNumber = "-";
                                s_NeedNumber = Dtb_ProductsTable.Rows[j]["NeedNumber"].ToString() == "" ? "-" : Dtb_ProductsTable.Rows[j]["NeedNumber"].ToString();
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\"><a href=\"Sc_Plan_QLMaterial.aspx?ProductsBarCode=" + s_ProductsBarCode + "&HouseNo=" + s_HouseNo + "\" target=\"_blank\">" + base.GetColorNumber(s_NeedNumber) + "</a></td>\n");//需求数量

                                string s_totalNumber = "-";
                                s_totalNumber = Dtb_ProductsTable.Rows[j]["totalNumber"].ToString() == "" ? "-" : Dtb_ProductsTable.Rows[j]["totalNumber"].ToString();
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\"><a href=\"Sc_Plan_QLMaterial.aspx?ProductsBarCode=" + s_ProductsBarCode + "\" target=\"_blank\">" + base.GetColorNumber(s_totalNumber) + "</a></td>\n");//需求数量
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + base.Base_GetHouseAndNumber1(s_ProductsBarCode, this.Tbx_HouseNo.Value) + "</td>\n");

                            }
                            Sb_DivStylea.Append("</tr >\n");
                        }
                    }

                    Sb_DivStylea.Append("<tr>\n");



                    Sb_DivStylea.Append("</tr>\n");
                }
            }

        }
        Sb_DivStylea.Append("</table>\n");
        Sb_DivStylea.Append("</div>\n");
        return Sb_DivStylea.ToString();
    }

    protected string DataShowsBySupp1(string s_OrderNo1)
    {

        KNet.BLL.Knet_Procure_OrdersList bll = new KNet.BLL.Knet_Procure_OrdersList();
        StringBuilder Sb_DivStylea = new StringBuilder();
        string s_Sql = "";
        s_Sql = "select cc.ID,cc.ProductsBarCode,d.ProductsName,d.ProductsPattern,ReceiveSuppNo,OrderDateTime,OrderPREToDate,b.OrderAmount,SuppNo,ContractNos,wrkNumber,a.OrderNo,a.ParentOrderNo,case when RKState<>1 then cast (DATEDIFF(day,getdate(),OrderpretoDate) as varchar(100)) else '' end as DiffDay  ";
        s_Sql += " FROM Knet_Procure_OrdersList a  join v_OrderRKWithNoDel b on a.OrderNO=b.V_OrderNo  ";
        s_Sql += " join Knet_Procure_OrdersList_Details cc on a.OrderNo=cc.OrderNo  ";
        s_Sql += " join KNet_Sys_ProcureType c on a.OrderType=c.ProcureTypeValue  ";

        s_Sql += " join KNET_Sys_Products d on d.ProductsBarCode=cc.ProductsBarCode  ";
        s_Sql += " where a.OrderNo='" + s_OrderNo1 + "' ";
        s_Sql += " and KPO_Del=0  and rkState<>'1' and KPO_RkState='0' and orderType='128860698200781250' ";
        s_Sql += " Order by SuppNo,OrderDateTime ";
        //更新产品库存
        // GetNewStore();
        //先查找供应商
        this.BeginQuery(s_Sql);
        DataSet ds = (DataSet)this.QueryForDataSet();
        s_DivStyle = "";
        if (ds.Tables[0].Rows.Count > 0)
        {
            Sb_DivStylea.Append("<table class=\"ListDetails\" cellspacing=\"0\" rules=\"all\" border=\"1\" id=\"GridView1\" style=\"border-color: #4974C2; width: 100%; border-collapse: collapse;\">\n");

            Sb_DivStylea.Append(" <tr>\n");
            Sb_DivStylea.Append(" <td align=\"center\" colspan=\"13\">\n");
            Sb_DivStylea.Append("<h3>杭州士腾科技有限公司<br/>\n");
            Sb_DivStylea.Append("订单号：" + s_OrderNo1 + " 物料配料明细</h3>\n");
            Sb_DivStylea.Append("</td>\n");
            Sb_DivStylea.Append("</tr>\n");

            Sb_DivStylea.Append(" <tr class=\"colHeader\" style=\"Height:30px\">\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">序号</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">采购单号</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">采购日期</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">到货日期</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">供应商</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">产品名称</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">产品类型</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">采购数量</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">未入库数量</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\" width=\"180px\">说明</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">缺料</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">总缺料</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">库存</td>\n");

            Sb_DivStylea.Append("</tr>\n");
            string s_ContractNos = "";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Sb_DivStylea.Append("<tr style=\"font-weight:bolder;Height:30px\">\n");
                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\"><font color=red>" + Convert.ToString(i + 1) + "</font>.<a onclick=\"fnVisible('layer_H" + i.ToString() + "')\"  href=\"#\"></a>OEM</td>\n");
                string s_OrderNo = ds.Tables[0].Rows[i]["OrderNo"].ToString();
                string s_ID = ds.Tables[0].Rows[i]["ID"].ToString();
                string s_ProductsBarCode1 = ds.Tables[0].Rows[i]["ProductsBarCode"].ToString();


                KNet.Model.Knet_Procure_OrdersList Model = bll.GetModelB(s_OrderNo);
                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\"><a href=\"../Cg/Order/Knet_Procure_OpenBilling_View.aspx?ID=" + s_OrderNo + "\" target=\"_blank\">" + s_OrderNo + "</td>\n");
                s_ContractNos = ds.Tables[0].Rows[i]["ContractNos"].ToString();

                string s_Date = "", s_PreDate = "";

                string s_SuppNo = ds.Tables[0].Rows[i]["suppno"].ToString();

                try
                {
                    s_Date = DateTime.Parse(ds.Tables[0].Rows[i]["OrderDateTime"].ToString()).ToShortDateString();
                    s_PreDate = DateTime.Parse(ds.Tables[0].Rows[i]["OrderPREToDate"].ToString()).ToShortDateString();
                }
                catch { }
                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + s_Date + "</td>\n");
                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + s_PreDate + "</td>\n");
                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + base.Base_GetSupplierName(ds.Tables[0].Rows[i]["SuppNo"].ToString()) + "</td>\n");
                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">成品</td>\n");
                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + base.Base_GetProductsEdition_Link(s_ProductsBarCode1) + "</td>\n");
                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + ds.Tables[0].Rows[i]["OrderAmount"].ToString() + "</td>\n");
                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + ds.Tables[0].Rows[i]["wrkNumber"].ToString() + "</td>\n");
                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\" >&nbsp;</td>\n");
                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\" >&nbsp;</td>\n");
                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\" >&nbsp;</td>\n");

                KNet.BLL.KNet_Sys_WareHouse Bll = new KNet.BLL.KNet_Sys_WareHouse();
                KNet.Model.KNet_Sys_WareHouse Model_WareHouse = Bll.GetModelBySuppNo(s_SuppNo);
                string s_HouseNo = Model_WareHouse.HouseNo == null ? "" : Model_WareHouse.HouseNo.ToString();
                this.Tbx_HouseNo.Value = s_HouseNo;

                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\" >&nbsp;</td>\n");
                Sb_DivStylea.Append("</tr >\n");

                s_Sql = "Select b.ProductsType,d.NeedNumber,a.XPD_ProductsBarCode,c.*,b.*,aa.totalNumber,";
                s_Sql += "(select top 1 FollowText from KNet_Sales_OutWareList_FlowList where ReTime is not null and OutWareNO=v_OrderNo  order by FollowDateTime desc) FollowText,";
                s_Sql += "(select top 1 ReTime from KNet_Sales_OutWareList_FlowList where ReTime is not null and OutWareNO=v_OrderNo  order by FollowDateTime desc) ReTime from Xs_Products_Prodocts_Demo a ";
                s_Sql += " join KNet_Sys_Products b on a.XPD_ProductsBarCode=b.ProductsBarCode";
                s_Sql += " left join v_OrderRkDetails c on c.V_ProductsBarCode=a.XPD_ProductsBarCode   and c.KPO_ID='" + s_ID + "'";
                s_Sql += " left join v_NeedNumberStore d on d.ProductsBarCode=a.XPD_ProductsBarCode and d.HouseNo='" + s_HouseNo + "'  ";
                s_Sql += " left join( select Sum(NeedNumber) totalNumber,ProductsBarCode from v_NeedNumberStore group by ProductsBarCode) aa on aa.ProductsBarCode=a.XPD_ProductsBarCode  ";
                s_Sql += "  where b.KSP_Del=0  and a.XPD_IsMail=0  and XPD_FaterBarCode In (select ProductsBarCode from Knet_Procure_OrdersList_Details where ID='" + s_ID + "')  ";
                if (this.Tbx_ProductsBarCode.Value != "")
                {
                    s_Sql = s_Sql + " and XPD_ProductsBarCode='" + this.Tbx_ProductsBarCode.Value + "' ";
                }
                s_Sql += "  order by b.ProductsName ";

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

                                    s_FollowText = Dtb_ProductsTable.Rows[j]["FollowText"].ToString();
                                    s_PreDate = DateTime.Parse(Dtb_ProductsTable.Rows[j]["ReTime"].ToString()).ToShortDateString();
                                }
                                catch
                                {
                                    s_PreDate = "";
                                    s_FollowText = "";
                                }
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + s_Date + "</td>\n");
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + s_PreDate + "</td>\n");
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + base.Base_GetSupplierName(Model_OrdersList.SuppNo) + "</td>\n");
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + Dtb_ProductsTable.Rows[j]["ProductsName"].ToString() + "</td>\n");
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + Dtb_ProductsTable.Rows[j]["ProductsEdition"].ToString() + "</td>\n");
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + Dtb_ProductsTable.Rows[j]["v_OrderAmount"].ToString() + "</td>\n");
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + Dtb_ProductsTable.Rows[j]["wrkNumber"].ToString() + "</td>\n");
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + s_FollowText + "</td>\n");//快递

                                string s_ProductsBarCode = Dtb_ProductsTable.Rows[j]["XPD_ProductsBarCode"].ToString();

                                string s_NeedNumber = "-";
                                s_NeedNumber = Dtb_ProductsTable.Rows[j]["NeedNumber"].ToString() == "" ? "-" : Dtb_ProductsTable.Rows[j]["NeedNumber"].ToString();
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\"><a href=\"Sc_Plan_QLMaterial.aspx?ProductsBarCode=" + s_ProductsBarCode + "&HouseNo=" + s_HouseNo + "\" target=\"_blank\">" + base.GetColorNumber(s_NeedNumber) + "</a></td>\n");//需求数量

                                string s_totalNumber = "-";
                                s_totalNumber = Dtb_ProductsTable.Rows[j]["totalNumber"].ToString() == "" ? "-" : Dtb_ProductsTable.Rows[j]["totalNumber"].ToString();
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\"><a href=\"Sc_Plan_QLMaterial.aspx?ProductsBarCode=" + s_ProductsBarCode + "\" target=\"_blank\">" + base.GetColorNumber(s_totalNumber) + "</a></td>\n");//需求数量
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + base.Base_GetHouseAndNumber1(s_ProductsBarCode, this.Tbx_HouseNo.Value) + "</td>\n");


                            }
                            else
                            {

                                string s_ProductsBarCode = Dtb_ProductsTable.Rows[j]["XPD_ProductsBarCode"].ToString();
                                Sb_DivStylea.Append("<td align=\"center\" class=\"ListHeadDetails\" colspan=\"3\">&nbsp;</td>\n");
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\" >" + base.Base_GetProdutsName(Dtb_ProductsTable.Rows[j]["XPD_ProductsBarCode"] == null ? "" : Dtb_ProductsTable.Rows[j]["XPD_ProductsBarCode"].ToString()) + "</td>\n");
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\" colspan=\"4\">" + base.Base_GetProductsEdition(Dtb_ProductsTable.Rows[j]["XPD_ProductsBarCode"] == null ? "" : Dtb_ProductsTable.Rows[j]["XPD_ProductsBarCode"].ToString()) + "</td>\n");
                                string s_NeedNumber = "-";
                                s_NeedNumber = Dtb_ProductsTable.Rows[j]["NeedNumber"].ToString() == "" ? "-" : Dtb_ProductsTable.Rows[j]["NeedNumber"].ToString();
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\"><a href=\"Sc_Plan_QLMaterial.aspx?ProductsBarCode=" + s_ProductsBarCode + "&HouseNo=" + s_HouseNo + "\" target=\"_blank\">" + base.GetColorNumber(s_NeedNumber) + "</a></td>\n");//需求数量

                                string s_totalNumber = "-";
                                s_totalNumber = Dtb_ProductsTable.Rows[j]["totalNumber"].ToString() == "" ? "-" : Dtb_ProductsTable.Rows[j]["totalNumber"].ToString();
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\"><a href=\"Sc_Plan_QLMaterial.aspx?ProductsBarCode=" + s_ProductsBarCode + "\" target=\"_blank\">" + base.GetColorNumber(s_totalNumber) + "</a></td>\n");//需求数量
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + base.Base_GetHouseAndNumber1(s_ProductsBarCode, this.Tbx_HouseNo.Value) + "</td>\n");

                            }
                            Sb_DivStylea.Append("</tr >\n");
                        }
                    }

                    Sb_DivStylea.Append("<tr>\n");



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
