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

public partial class Sc_Plan_QLMaterial : BasePage
{
    public string s_DivStyle = "";
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            string s_ProductsBarCode = Request.QueryString["ProductsBarCode"] == null ? "" : Request.QueryString["ProductsBarCode"].ToString();
            string s_HouseNo = Request.QueryString["HouseNo"] == null ? "" : Request.QueryString["HouseNo"].ToString();
            if (s_ProductsBarCode != "")
            {
                Lbl_ProductsBarCode.Text = "产品：" + base.Base_GetProductsEdition_Link(s_ProductsBarCode) + "(" + base.Base_GetHouseAndNumber1(s_ProductsBarCode, s_HouseNo) + ")";
                this.Tbx_ProductsBarCode.Text = s_ProductsBarCode;
            }
            if (s_HouseNo != "")
            {
                this.Lbl_House.Text = "供应商：" + base.Base_GetHouseName(s_HouseNo);
                this.Tbx_HouseNo.Text = s_HouseNo;
            }
            DataShowNew();
        }

    }

    protected void DataShowNew()
    {
        StringBuilder Sb_DivStylea = new StringBuilder();
        string s_ProductsBarCode = this.Tbx_ProductsBarCode.Text;
        Sb_DivStylea.Append("<table class=\"ListDetails\" cellspacing=\"0\" rules=\"all\" border=\"1\" id=\"GridView1\" style=\"border-color: #4974C2; width: 100%; border-collapse: collapse;\">\n");
        Sb_DivStylea.Append(" <tr class=\"colHeader\" style=\"Height:30px\">\n");
        Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">序号</td>\n");
        Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">单号</td>\n");
        Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">OEM订单号</td>\n");
        Sb_DivStylea.Append("<td align=\"center\"  class=\"ListHead\">合同单号</td>\n");
        Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">类型</td>\n");
        Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">日期</td>\n");
        Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">成品</td>\n");
        if (this.Tbx_ProductsBarCode.Text == "")
        {
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">产品</td>\n");
        }
        Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">供应商</td>\n");
        Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">需求数量</td>\n");
        Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">在途数量</td>\n");

        if (this.Tbx_ProductsBarCode.Text == "")
        {
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">库存</td>\n");
        }
        DataTable Dtb_WareHouseProducts = null;

        int[] i_Total = new int[100];
        int[] i_TotalLeft = new int[100];
        if (this.Tbx_HouseNo.Text == "")
        {
            string s_Sql1 = "Select * from v_ProdutsStore a join KNet_Sys_WareHouse b on a.HouseNo=b.HouseNo and KSW_Type='0'  join Knet_Procure_Suppliers  c on c.suppNo=b.suppNo where ProductsBarCode='" + this.Tbx_ProductsBarCode.Text + "' and Number>0 order by  HouseName";
            this.BeginQuery(s_Sql1);
            Dtb_WareHouseProducts = (DataTable)this.QueryForDataTable();
            for (int i_WareHouse = 0; i_WareHouse < Dtb_WareHouseProducts.Rows.Count; i_WareHouse++)
            {
                Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">" + Dtb_WareHouseProducts.Rows[i_WareHouse]["HouseName"].ToString() + "</td>\n");
                try
                {
                    i_Total[i_WareHouse] = int.Parse(Dtb_WareHouseProducts.Rows[i_WareHouse]["Number"].ToString());
                }
                catch
                {
                    i_Total[i_WareHouse] = 0;
                }
                try
                {
                    i_TotalLeft[i_WareHouse] = int.Parse(Dtb_WareHouseProducts.Rows[i_WareHouse]["Number"].ToString());
                }
                catch
                {
                    i_TotalLeft[i_WareHouse] = 0;
                }
            }
        }
        Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">余量</td>\n");
        //如果是全缺料的话 分列显示仓库

        Sb_DivStylea.Append("</tr>\n");
        string s_Sql = "";

        try
        {
            string s_KCNumber = "0";
            string s_SuppNo = "";
            KNet.BLL.KNet_Sys_WareHouse Bll = new KNet.BLL.KNet_Sys_WareHouse();

            int i_leftNumber = 0;
            try
            {
                KNet.Model.KNet_Sys_WareHouse Model = Bll.GetModel(this.Tbx_HouseNo.Text);
                s_SuppNo = Model.SuppNo;
            }
            catch
            { }
            s_Sql = "Select * from v_CgStore  where 1=1 ";
            if (s_SuppNo != "")
            {
                s_Sql += " and ( suppNo='" + s_SuppNo + "' or ContractAddress like '%" + Base_GetSupplierName(s_SuppNo) + "%') ";
            }
            if (s_ProductsBarCode != "")
            {
                s_Sql += " and ProductsBarCode='" + s_ProductsBarCode + "' ";
            }
            s_Sql += "  order by OrderDateTime,KPO_CTime";
            if (this.Tbx_HouseNo.Text == "")
            {
                this.Lbl_ProductsBarCode.Text = "产品：" + base.Base_GetProductsEdition_Link(s_ProductsBarCode) ;
                string s_KC = base.Base_GetHouseAndNumber(s_ProductsBarCode);
                this.Lbl_ProductsBarCode.Text += "(<b>" + s_KC.Substring(0, s_KC.Length - 5) + "</b>)";

            }
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            int i_TotalNumber = 0, i_TotalNumber1 = 0;
            DataTable Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                Sb_DivStylea.Append("<tr style=\"font-weight:bolder;Height:30px\">\n");
                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\"><font color=red>1</font></td>\n");
                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\" colspan=9>&nbsp;</td>\n");
                if (Dtb_WareHouseProducts != null)
                {
                    int i_TotalHouseNumber = 0;

                    for (int i_WareHouse = 0; i_WareHouse < Dtb_WareHouseProducts.Rows.Count; i_WareHouse++)
                    {
                        Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHeadDetails\">" + GetColorNumber(Dtb_WareHouseProducts.Rows[i_WareHouse]["Number"].ToString()) + "</td>\n");
                        i_TotalHouseNumber += int.Parse(Dtb_WareHouseProducts.Rows[i_WareHouse]["Number"].ToString());
                    }
                    Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHeadDetails\">" + GetColorNumber(i_TotalHouseNumber.ToString()) + "</td>\n");
                    s_KCNumber = i_TotalHouseNumber.ToString();
                }
                else
                {
                    s_KCNumber = base.Base_GetHouseAndNumber1(s_ProductsBarCode, this.Tbx_HouseNo.Text);
                    Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHeadDetails\">" + GetColorNumber(s_KCNumber) + "</td>\n");
                }
                i_leftNumber = int.Parse(s_KCNumber);

                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
                    Sb_DivStylea.Append("<tr style=\"font-weight:bolder;Height:30px\">\n");
                    Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\"><font color=red>" + Convert.ToString(i + 2) + "</font><a onclick=\"fnVisible('layer_H" + i.ToString() + "')\"  href=\"#\"></a></td>\n");
                    string s_OrderNo = Dtb_Table.Rows[i]["OrderNo"].ToString();
                    string s_NeedNumber = Dtb_Table.Rows[i]["number"].ToString();
                    string s_NeedNumber1 = Dtb_Table.Rows[i]["NeedNumber"].ToString();
                    string s_RCProductsBarCode = Dtb_Table.Rows[i]["RCProductsBarCode"].ToString();
                    string s_TypeName = Dtb_Table.Rows[i]["TypeName"].ToString();
                    string s_Type = Dtb_Table.Rows[i]["Type"].ToString();
                    string s_DateTime = base.DateToString(Dtb_Table.Rows[i]["OrderDateTime"].ToString());
                    string s_RcNumber = "0";
                    string s_SuppName = base.Base_GetSupplierName_Link(Dtb_Table.Rows[i]["SuppNo"].ToString());
                    string s_SuppDetailsNo = Dtb_Table.Rows[i]["SuppNo"].ToString();
                    string s_ContractAddress = Dtb_Table.Rows[i]["ContractAddress"].ToString();

                    Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\"><a href=\"../Cg/Order/Knet_Procure_OpenBilling_View.aspx?ID=" + s_OrderNo + "\" target=\"_blank\">" + s_OrderNo + "</td>\n");

                    KNet.BLL.Knet_Procure_OrdersList BLl_Order = new KNet.BLL.Knet_Procure_OrdersList();
                    KNet.Model.Knet_Procure_OrdersList Model_Order = BLl_Order.GetModelB(s_OrderNo);
                    if (Model_Order != null)
                    {
                        Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\"><a href=\"../Cg/Order/Knet_Procure_OpenBilling_View.aspx?ID=" + Model_Order.ParentOrderNo + "\" target=\"_blank\">" + Model_Order.ParentOrderNo + "</td>\n");
                        try
                        {
                            this.BeginQuery("select Sum(WrkNumber) from v_OrderRkDetails a join Xs_Products_Prodocts_Demo b  on a.v_ProductsBarCode=b.XPD_FaterBarCode where v_OrderNo='" + Model_Order.ParentOrderNo + "' and XPD_ProductsBarCode='" + s_ProductsBarCode + "'");
                            s_RcNumber = this.QueryForReturn();
                        }
                        catch { }

                    }
                    else
                    {
                        Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\"><font color=red>red</font></td>\n");

                    }
                    string s_ContractNos = Dtb_Table.Rows[i]["ContractNos"].ToString();
                    Sb_DivStylea.Append("<td align=\"center\" class=\"ListHeadDetails\">" + GetContract(s_ContractNos) + "</td>\n");

                    Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + s_TypeName + "</td>\n");
                    Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + s_DateTime + "</td>\n");
                    Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + base.Base_GetProductsEdition_Link(s_RCProductsBarCode) + "</td>\n");

                    Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + s_SuppName + "</td>\n");
                    if (s_Type == "1")
                    {
                        Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + s_NeedNumber + "</td>\n");
                        Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">&nbsp;</td>\n");
                        i_TotalNumber += int.Parse(s_NeedNumber);
                    }
                    else
                    {
                        Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + s_RcNumber + "</td>\n");
                        Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + s_NeedNumber + "</td>\n");
                        i_TotalNumber1 += int.Parse(s_NeedNumber);

                    }
                    i_leftNumber += int.Parse(s_NeedNumber1);
                    if (this.Tbx_ProductsBarCode.Text == "")
                    {
                        Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + s_KCNumber + "</td>\n");
                    }
                    string s_HouseNoSql = "Select * from v_CgStore where ProductsBarCode='" + this.Tbx_ProductsBarCode.Text + "' and house  ";
                    if (Dtb_WareHouseProducts != null)
                    {

                        for (int i_WareHouse = 0; i_WareHouse < Dtb_WareHouseProducts.Rows.Count; i_WareHouse++)
                        {
                            string s_HouseSuppNo = Dtb_WareHouseProducts.Rows[i_WareHouse]["SuppName"].ToString();

                            if ((Dtb_WareHouseProducts.Rows[i_WareHouse]["SuppNo"].ToString() == s_SuppDetailsNo) || (s_ContractAddress.IndexOf(s_HouseSuppNo) > 0))
                            {
                                if (s_Type == "1")
                                {

                                    i_Total[i_WareHouse] += -int.Parse(s_NeedNumber);
                                    i_TotalLeft[i_WareHouse] += -int.Parse(s_NeedNumber);
                                }
                                else
                                {
                                    i_Total[i_WareHouse] += int.Parse(s_NeedNumber);
                                    i_TotalLeft[i_WareHouse] += int.Parse(s_NeedNumber);
                                }
                                Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHeadDetails\">" + GetColorNumber(i_TotalLeft[i_WareHouse].ToString()) + "</td>\n");

                            }
                            else
                            {
                                Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHeadDetails\">&nbsp;</td>\n");
                            }
                        }
                    }
                    Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + GetColorNumber(i_leftNumber.ToString()) + "</td>\n");
                    Sb_DivStylea.Append("</tr>");

                }

                Sb_DivStylea.Append("<tr style=\"font-weight:bolder;Height:30px\">\n");
                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\" colspan=\"8\">合计：</td>\n");
                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\" >" + i_TotalNumber + "</td>\n");
                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\" >" + i_TotalNumber1 + "</td>\n");
                if (Dtb_WareHouseProducts != null)
                {
                    int i_TotalHouseNumber = 0;
                    for (int i_WareHouse = 0; i_WareHouse < Dtb_WareHouseProducts.Rows.Count; i_WareHouse++)
                    {
                        Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHeadDetails\">" + GetColorNumber(i_TotalLeft[i_WareHouse].ToString()) + "</td>\n");
                    }
                }
                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\" >" + GetColorNumber(i_leftNumber.ToString()) + "</td>\n");
                Sb_DivStylea.Append("</tr>");
            }
        }
        catch (Exception ex)
        {
        }

        this.Lbl_Details.Text = Sb_DivStylea.ToString();

    }

    protected void DataShows()
    {
        KNet.BLL.Knet_Procure_OrdersList bll = new KNet.BLL.Knet_Procure_OrdersList();
        string SqlWhere = " 1=1 ";
        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string s_Type = "";

        if (s_WhereID != "")
        {
            SqlWhere += Base_GetBasicWhere(s_WhereID);
        }

        string s_SuppNo1 = Request.QueryString["SuppNo"] == null ? "" : Request.QueryString["SuppNo"].ToString();
        if (s_SuppNo1 != "")
        {

            SqlWhere = SqlWhere + " and SuppNo='" + s_SuppNo1 + "' ";
        }
        SqlWhere = SqlWhere + " and rkState<>'1' and KPO_RkState='0' and orderType='128860698200781250' ";


        DataSet ds = bll.GetList(SqlWhere);
        s_DivStyle = "";
        StringBuilder Sb_DivStylea = new StringBuilder();
        if (ds.Tables[0].Rows.Count > 0)
        {
            Sb_DivStylea.Append("<table class=\"ListDetails\" cellspacing=\"0\" rules=\"all\" border=\"1\" id=\"GridView1\" style=\"border-color: #4974C2; width: 100%; border-collapse: collapse;\">\n");
            Sb_DivStylea.Append(" <tr class=\"colHeader\" style=\"Height:30px\">\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">序号</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">单号</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">类型</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">日期</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">供应商</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">数量</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">说明</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">库存</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">需求数量</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">在途数量</td>\n");
            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHead\">缺料数量</td>\n");
            Sb_DivStylea.Append("</tr>\n");
            string s_ContractNos = "";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Sb_DivStylea.Append("<tr style=\"font-weight:bolder;Height:30px\">\n");
                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\"><font color=red>" + Convert.ToString(i + 1) + "</font><a onclick=\"fnVisible('layer_H" + i.ToString() + "')\"  href=\"#\"></a>OEM</td>\n");
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
                Lbl_House.Text = Model_WareHouse.HouseName;
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
                string s_Sql = "Select b.ProductsType,a.XPP_ProductsBarCode,c.* from Xs_Products_Prodocts a ";
                s_Sql += " join KNet_Sys_Products b on a.XPP_ProductsBarCode=b.ProductsBarCode";
                s_Sql += " left join v_OrderRkDetails c on c.V_ProductsBarCode=a.XPP_ProductsBarCode and c.v_ParentOrderNo='" + s_OrderNo + "'";
                s_Sql += "  where XPP_FaterBarCode In (select ProductsBarCode from Knet_Procure_OrdersList_Details where OrderNo='" + s_OrderNo + "')  and XPP_IsOrder='是'";
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
                            Sb_DivStylea.Append("<td align=\"left\"  class=\"ListHeadDetails\">" + Convert.ToString(j + 1) + "</td>\n");
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
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + base.Base_GetProductsEdition_Link(Dtb_ProductsTable.Rows[j]["XPP_ProductsBarCode"] == null ? "" : Dtb_ProductsTable.Rows[j]["XPP_ProductsBarCode"].ToString()) + "</td>\n");
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + Dtb_ProductsTable.Rows[j]["v_OrderAmount"].ToString() + "</td>\n");
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + Dtb_ProductsTable.Rows[j]["wrkNumber"].ToString() + "</td>\n");
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + s_FollowText + "</td>\n");//快递
                                this.BeginQuery("Select * from KNet_Sys_WareHouse  where KSW_Type=0 and SuppNo='" + Model.SuppNo + "' ");
                                DataTable Dtb_Table1 = (DataTable)this.QueryForDataTable();
                                string s_KCDetails = "";
                                if (Dtb_Table1.Rows.Count > 0)
                                {
                                    for (int i_1 = 0; i_1 < Dtb_Table1.Rows.Count; i_1++)
                                    {
                                        s_KCDetails = base.Base_GetHouseAndNumber1(Dtb_ProductsTable.Rows[j]["XPP_ProductsBarCode"].ToString(), Dtb_Table1.Rows[i_1]["HouseNo"].ToString()) + "<br/>";
                                    }
                                    s_KCDetails = s_KCDetails.Substring(0, s_KCDetails.Length - 5);
                                }
                                string s_WareHouseNumber = s_KCDetails;
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + s_WareHouseNumber + "</td>\n");//快递
                                string s_NeedNumber = base.Base_GetHouseAndNeedNumber1(Dtb_ProductsTable.Rows[j]["XPP_ProductsBarCode"].ToString(), s_HouseNo);
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + s_NeedNumber + "</td>\n");//需求数量
                                string s_OrderLeftNumber = base.Base_GetOrderWrkNumber(Dtb_ProductsTable.Rows[j]["XPP_ProductsBarCode"].ToString(), s_HouseNo);
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + s_OrderLeftNumber + "</td>\n");//需求数量
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + GetLefNumber(s_WareHouseNumber, s_OrderLeftNumber, s_NeedNumber) + "</td>\n");//需求数量

                            }
                            else
                            {

                                Sb_DivStylea.Append("<td align=\"center\" class=\"ListHeadDetails\" colspan=\"3\"><font color=red>未找到订单</font></td>\n");
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\" colspan=\"4\">" + base.Base_GetProductsEdition_Link(Dtb_ProductsTable.Rows[j]["XPP_ProductsBarCode"] == null ? "" : Dtb_ProductsTable.Rows[j]["XPP_ProductsBarCode"].ToString()) + "</td>\n");
                                string s_WareHouseNumber = base.Base_GetHouseAndNumber1(Dtb_ProductsTable.Rows[j]["XPP_ProductsBarCode"].ToString(), s_HouseNo);
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + s_WareHouseNumber + "</td>\n");//快递
                                string s_NeedNumber = base.Base_GetHouseAndNeedNumber1(Dtb_ProductsTable.Rows[j]["XPP_ProductsBarCode"].ToString(), s_HouseNo);
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + s_NeedNumber + "</td>\n");//需求数量
                                string s_OrderLeftNumber = base.Base_GetOrderWrkNumber(Dtb_ProductsTable.Rows[j]["XPP_ProductsBarCode"].ToString(), s_HouseNo);
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + s_OrderLeftNumber + "</td>\n");//需求数量
                                Sb_DivStylea.Append("<td align=\"left\" class=\"ListHeadDetails\">" + GetLefNumber(s_WareHouseNumber, s_OrderLeftNumber, s_NeedNumber) + "</td>\n");//需求数量
                            }
                            Sb_DivStylea.Append("</tr >\n");
                        }
                    }

                    Sb_DivStylea.Append("<tr>\n");



                    Sb_DivStylea.Append("</tr>\n");

                    Sb_DivStylea.Append("</div>\n");
                }
            }
            this.Lbl_Details.Text = Sb_DivStylea.ToString();

        }
    }

    public string GetBatteryNumber(string s_ProductsBarCode, string s_HouseNo)
    {
        //查找该OEM的所有订单需要的电池
        string s_Return = "";
        try
        {
            string s_Sql = "Select ContractNos from v_OrderNeed_Details where HouseNO='" + s_HouseNo + "'";
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
                //查找订单需求数量
                string s_DetailsSql = "Select Sum(ContractAmount+Isnull(KSC_BNumber,0)) Number from KNet_Sales_ContractList a join KNet_Sales_ContractList_Details b on a.ContractNo=b.ContractNo ";
                s_DetailsSql += " join KNet_Sys_Products e on e.ProductsBarCode=b.ProductsBarCode  ";
                s_DetailsSql += " where a.ContractNo in('" + s_ContractNos.Replace(",", "','") + "') and ProductsType in ('M130704050932527') ";

                if (s_ProductsBarCode != "")
                {
                    s_DetailsSql += " and  e.ProductsBarCode='" + s_ProductsBarCode + "'";
                }
                this.BeginQuery(s_DetailsSql);
                DataTable Dtb_DcDetails = (DataTable)this.QueryForDataTable();
                if (Dtb_DcDetails.Rows.Count > 0)
                {
                    s_Return = Dtb_DcDetails.Rows[0]["Number"].ToString();
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

    protected void Btn_Query_Click(object sender, EventArgs e)
    {

        this.DataShows();
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


}
