using KNet.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_SC_Product_HomeNum : BasePage
{
    public string s_MyTable_Detail = "",
        s_ProductsTable_Detail = "",
        s_ProductsTable_BomDetail = "",
        s_ProductsRC = "",
        s_ProductsTable_BomDetail1 = "";

    public string s_OrderStyle = "",
        s_DetailsStyle = "",
        s_RC_ProductsBarCode = "",
        s_CgDayDetail = "",
        s_AlternativeDetail = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            this.GetBomDetails();
        }
    }

    private void GetBomDetails()
    {
        decimal d_totalPrice = 0;
        string ProductsBarCode = Request.QueryString["ProductCode"].ToString();
       
        int sd = 0;
       
        string sql =
                "select ContractAmount from KNet_Sales_ContractList a join KNet_Sales_ContractList_Details b on a.ContractNo = b.ContractNo where ProductsBarCode = '" +
                ProductsBarCode + "' and a.ContractNo not in (select ContractNo from Knet_Procure_OrdersList)";
        //查询同一个产品同个订单并且还没耗料的
        this.BeginQuery(sql);
        DataSet Dts_OrderCount = (DataSet)this.QueryForDataSet();
        DataTable Dtb_OrderCount = Dts_OrderCount.Tables[0];
        if (Dtb_OrderCount.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_OrderCount.Rows.Count; i++)
            {
                sd += int.Parse(Dtb_OrderCount.Rows[i][0].ToString());
            }
        }
        else
        {
            sd = 1;
        }
        //string HouseNo = Dtb_DemoHouse.Rows[0]["HouseNo"].ToString();

        AdminloginMess AM = new AdminloginMess();
        string s_DemoProductsID = "";
        string s_Where1 = " and XPD_FaterBarCode='" + ProductsBarCode + "' ";

        string s_Sql =
            "Select * from Xs_Products_Prodocts_Demo a join KNET_Sys_Products b on a.XPD_ProductsBarCode=b.ProductsBarCode";
        s_Sql += " left join PB_Basic_Code d on b.KSP_LossType=d.PBC_Code  and d.PBC_ID='1136' ";
        s_Sql += " join PB_Basic_ProductsClass c on b.ProductsType=c.PBP_ID where 1=1  ";
        this.BeginQuery(s_Sql + s_Where1 + "  order by c.PBP_Name,ProductsEdition,XPD_Place");
        DataSet Dts_DemoProducts = (DataSet)this.QueryForDataSet();
        DataTable Dtb_DemoProducts = Dts_DemoProducts.Tables[0];
        StringBuilder Sb_BomDetails = new StringBuilder();

        string s_Name = "";
        try
        {
            s_Name = base.Base_GetProdutsName(ProductsBarCode) + "(" + base.Base_GetProductsPattern(ProductsBarCode) +
                     ")";
        }
        catch
        {
        }
        string s_FileName = s_Name + "_BOM库存表(此数据仅供参考)";
        this.Lbl_BomTitle.Text = s_FileName;
        Lbl_BomTitle.Text = s_FileName;
        Sb_BomDetails.Append(" <style>");
        Sb_BomDetails.Append(".ListHead {");
        Sb_BomDetails.Append("border-top: 0px solid #666666;");
        Sb_BomDetails.Append("border-left: 1px solid #666666;");
        Sb_BomDetails.Append("border-right: 0px solid #666666;");
        Sb_BomDetails.Append("border-bottom: 1px solid #666666;");
        Sb_BomDetails.Append("font-weight: bold;");

        Sb_BomDetails.Append("background: #f6f6f6 url(images/mailSubHeaderBg-grey.gif) bottom repeat-x;");
        Sb_BomDetails.Append("vertical-align:middle;");
        Sb_BomDetails.Append("text-align:center;");
        Sb_BomDetails.Append("}");

        Sb_BomDetails.Append(".ListHeadDetails {");
        Sb_BomDetails.Append("padding-left:2px;");
        Sb_BomDetails.Append("border-bottom: 1px solid #666666;");
        Sb_BomDetails.Append("border-right: 0px solid #666666;");
        Sb_BomDetails.Append("border-left: 1px solid #666666;");
        Sb_BomDetails.Append("border-top: 0px solid #666666;");
        Sb_BomDetails.Append("}");

        Sb_BomDetails.Append(".ListDetails {");
        Sb_BomDetails.Append("BORDER-COLLAPSE: collapse;");
        Sb_BomDetails.Append("border-color:#666666;");
        Sb_BomDetails.Append("font-family: Arial, Helvetica, sans-serif;");
        Sb_BomDetails.Append("font-size: 13px;");
        Sb_BomDetails.Append("color: #000000;");
        Sb_BomDetails.Append("border-top: 1px solid #666666;");
        Sb_BomDetails.Append("border-left: 1px solid #666666;");
        Sb_BomDetails.Append("border-right: 1px solid #666666;");
        Sb_BomDetails.Append("}");
        Sb_BomDetails.Append("</style>");
        Sb_BomDetails.Append(
            "<table id=\"ProductsBomTable\" width=\"100%\" border=\"0\" align=\"center\" cellpadding=\"0\" class=\"ListDetails\"");
        Sb_BomDetails.Append("cellspacing=\"0\">");
        Sb_BomDetails.Append("<tr>");
        Sb_BomDetails.Append("<td align=\"center\" class=\"ListHead\" colspan=\"11\" height=\"40px\"><h2>");
        Sb_BomDetails.Append(Lbl_BomTitle.Text);
        Sb_BomDetails.Append("</h2></td>");
        Sb_BomDetails.Append("</tr>");
        Sb_BomDetails.Append("<tr id=\"tr3\">");
        Sb_BomDetails.Append("<td align=\"center\" class=\"ListHead\">序号");
        Sb_BomDetails.Append("</td>");
        Sb_BomDetails.Append("<td align=\"center\" class=\"ListHead\">产品名称");
        Sb_BomDetails.Append("</td>");
        Sb_BomDetails.Append("<td align=\"center\" class=\"ListHead\">版本号");
        Sb_BomDetails.Append("</td>");
        Sb_BomDetails.Append("<td align=\"center\" class=\"ListHead\">替换料");
        Sb_BomDetails.Append("</td>");
        Sb_BomDetails.Append("<td align=\"center\" class=\"ListHead\">状态");
        Sb_BomDetails.Append("</td>");
        Sb_BomDetails.Append("<td align=\"center\" class=\"ListHead\">料号");
        Sb_BomDetails.Append("</td>");
        Sb_BomDetails.Append("<td align=\"center\" class=\"ListHead\">BOM数量");
        Sb_BomDetails.Append("</td>");
        Sb_BomDetails.Append("<td align=\"center\" class=\"ListHead\">需耗数量");
        Sb_BomDetails.Append("</td>");
        Sb_BomDetails.Append("<td align=\"center\" class=\"ListHead\">使用方式");
        Sb_BomDetails.Append("</td>");
        Sb_BomDetails.Append("</td>");
        Sb_BomDetails.Append("<td align=\"center\" class=\"ListHead\">损耗类型");
        Sb_BomDetails.Append("</td>");
        Sb_BomDetails.Append("<td align=\"center\" class=\"ListHead\">仓库库存");
        Sb_BomDetails.Append("</td>");
        Sb_BomDetails.Append("</tr>");
        if (Dtb_DemoProducts.Rows.Count > 0)
        {

            for (int i = 0; i < Dtb_DemoProducts.Rows.Count; i++)
            {
                s_DemoProductsID += Dtb_DemoProducts.Rows[i]["XPD_ProductsBarCode"].ToString() + ",";
                Sb_BomDetails.Append("<tr>");
                Sb_BomDetails.Append("<td class=\"ListHeadDetails\">" + (i + 1).ToString() + "</td>");
                Sb_BomDetails.Append("<td class=\"ListHeadDetails\">" +
                                     Dtb_DemoProducts.Rows[i]["ProductsName"].ToString() + "</td>");
                Sb_BomDetails.Append("<td class=\"ListHeadDetails\">" +
                                     Dtb_DemoProducts.Rows[i]["ProductsEdition"].ToString() + "</td>");

                //Sb_BomDetails.Append("<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition_Link(Dtb_DemoProducts.Rows[i]["XPD_ProductsBarCode"].ToString()) + "</td>");
                string s_ProductsCode = "";
                if (Dtb_DemoProducts.Rows[i]["ReplaceNum"].ToString() == "0")
                {
                    Sb_BomDetails.Append(
                        "<td class=\"ListHeadDetails\" style=\"max-width:100px; word-break: break-all;word-wrap:break-word;\">主料</td>");
                }
                else
                {
                    Sb_BomDetails.Append(
                        "<td class=\"ListHeadDetails\" style=\"max-width:100px;color:red;word-break: break-all;word-wrap:break-word;\">替料" +
                        Dtb_DemoProducts.Rows[i]["ReplaceNum"].ToString() + "</td>");
                }
                string s_Del = Dtb_DemoProducts.Rows[i]["KSP_Del"].ToString();
                if (s_Del == "1")
                {
                    Sb_BomDetails.Append("<td class=\"ListHeadDetails\"><font color=red>已停用</font></td>");
                }
                else
                {
                    Sb_BomDetails.Append("<td class=\"ListHeadDetails\"><font color=green>启用</font></td>");
                }
                Sb_BomDetails.Append("<td class=\"ListHeadDetails\">&nbsp;" +
                                     Dtb_DemoProducts.Rows[i]["KSP_Code"].ToString() + "</td>");
                Sb_BomDetails.Append(
                    "<td class=\"ListHeadDetails\"><input type=\"hidden\" input Name=\"DemoNumber\" value='" +
                    Dtb_DemoProducts.Rows[i]["XPD_Number"].ToString() + "'>" +
                    Dtb_DemoProducts.Rows[i]["XPD_Number"].ToString() + "</td>");
                Sb_BomDetails.Append("<td class=\"ListHeadDetails\">" +
                                     int.Parse(Dtb_DemoProducts.Rows[i]["XPD_Number"].ToString()) * sd + "</td>");
                //使用方式
                Sb_BomDetails.Append("<td class=\"ListHeadDetails\">" +
                                     base.Base_GetBasicCodeName("1134",
                                         Dtb_DemoProducts.Rows[i]["KSP_UseType"].ToString()) + "</td>");
                Sb_BomDetails.Append("<td class=\"ListHeadDetails\">" + Dtb_DemoProducts.Rows[i]["PBC_Name"].ToString() +
                                     "(" +
                                     base.FormatNumber1(
                                         Convert.ToString(
                                             decimal.Parse(Dtb_DemoProducts.Rows[i]["PBC_Details"].ToString()) * 100), 2) +
                                     "%)</td>");
                Sb_BomDetails.Append("<td class=\"ListHeadDetails\">" +
                                     Base_GetHouseAndNumber1(Dtb_DemoProducts.Rows[i]["XPD_ProductsBarCode"].ToString(), int.Parse(Dtb_DemoProducts.Rows[i]["XPD_Number"].ToString())) +
                                     "</td>");
                //, int.Parse(Dtb_DemoProducts.Rows[i]["XPD_Number"].ToString()) * sd

                Sb_BomDetails.Append("</tr>");
            }
        }

        Sb_BomDetails.Append("</table>");
        Lbl_BomDetails1.Text = Sb_BomDetails.ToString();
        Tbx_BomNumber.Text = Dtb_DemoProducts.Rows.Count.ToString();

    }



    protected void Btn_Excel_Click(object sender, EventArgs e)
    {
        Response.Buffer = true;
        Response.Clear();
        Response.ClearContent();
        Response.AddHeader("content-disposition",
            "attachment; filename=" +
            HttpUtility.UrlEncode(this.Lbl_BomTitle.Text + ".xls", System.Text.Encoding.UTF8).ToString());
        //Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");

        Response.ContentType = "application/ms-excel";
        Response.Write(Lbl_BomDetails1.Text);
        Response.Flush();
        Response.End();
    }

    public string Base_GetHouseAndNumber1(string s_ProductsBarCode, int num)
    {
        //,int xq_num
        //select sum(a.ContractAmount * b.XPD_Number) from
        //KNet_Sales_ContractList_Details a join Xs_Products_Prodocts_Demo b on a.ProductsBarCode = b.XPD_FaterBarCode
        //join Knet_Procure_OrdersList c on a.ContractNo = c.ContractNo
        //where c.OrderNo not in (select OrderNo from Knet_Procure_OrdersList_Details ) 
        //and b.XPD_ProductsBarCode = 'D160826876740359'
        //and a.Add_DateTime > '2018-05-01'
        //and a.ContractNo not in(select ContractNo from KNet_Sales_OutWareList) 
        //and b.XPD_Del != 1
        string s_Return = "";
        try
        {
            string bom_sql =
                "select sum(a.ContractAmount*b.XPD_Number) from KNet_Sales_ContractList_Details a join Xs_Products_Prodocts_Demo b on a.ProductsBarCode=b.XPD_FaterBarCode join KNet_Sales_ContractList c on a.ContractNo=c.ContractNo where a.ContractNo not in (select ContractNo from Knet_Procure_OrdersList where OrderDateTime>'2018-05-01') and XPD_ProductsBarCode='" +
                s_ProductsBarCode +
                "' and a.Add_DateTime>'2018-05-01' and a.ContractNo not in(select ContractNo from KNet_Sales_OutWareList) and b.XPD_Del!=1 and c.ContractState!='-1'";
            this.BeginQuery(bom_sql);
            this.QueryForDataTable();
            DataTable BomSum_Table = this.Dtb_Result; //计算订单评审并且没有创建生产订单也没有创建出库通知的应耗物料的总数量

            string s_Sql =
                "Select isnull(Sum(DirectInAmount),0),a.HouseNo from v_Store a join KNet_Sys_WareHouse b on a.HouseNo=b.HouseNo  Where a.ProductsBarCode='" +
                s_ProductsBarCode + "' and a.HouseType='0'  Group by a.HouseNo ";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;//计算实际库存
            if (Dtb_Table.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
                    //if ((Dtb_Table.Rows[i][0].ToString() != "") && (Dtb_Table.Rows[i][0].ToString() != "0"))
                    //{
                    string cg_Sql =
                        " select isnull(Sum(OrderAmount),0) from Knet_Procure_OrdersList a join Knet_Procure_OrdersList_Details b on a.OrderNo=b.OrderNo where KPO_PreHouseNo='" +
                        Dtb_Table.Rows[i][1].ToString() + "' and b.ProductsBarCode='" + s_ProductsBarCode +
                        "' and a.KPO_Del!=1 and a.OrderNo not in( select ReceivNo from Knet_Procure_WareHouseList)";
                    //string cg_Sql =
                    //   "Select isnull(sum(wrkNumber),0),a.ProductsBarCode from Knet_Procure_OrdersList_Details a join v_OrderRkDetails c on c.KPO_ID=a.ID join Knet_Procure_OrdersList b  on a.OrderNo =b.OrderNo Where  a.OrderNo in(select OrderNo FROM Knet_Procure_OrdersList a  join v_OrderRKWithNoDel b on a.OrderNO=b.V_OrderNo join KNet_Sys_ProcureType c on a.OrderType=c.ProcureTypeValue where rkState!=1 and OrderType!='128860698200781250'and a.KPO_Del!=1) and a.ProductsBarCode ='" + s_ProductsBarCode + "' and KPO_PreHouseNo='" + Dtb_Table.Rows[i][1].ToString() +"' group by a.ProductsBarCode";
                    this.BeginQuery(cg_Sql);
                    this.QueryForDataTable();
                    DataTable Dtb_CgTable = this.Dtb_Result;//在途数量

                    if ((Dtb_Table.Rows[i][0].ToString() == "0") && (Dtb_CgTable.Rows[0][0].ToString() == "0"))
                    {

                    }
                    else
                    {
                        //    string sc_Sql =
                        //" select isnull(sum(OrderAmount),0) from Knet_Procure_OrdersList a join Knet_Procure_OrdersList_Details b on a.OrderNo=b.OrderNo  where  a.OrderNo not in (select OrderNo from Sc_Expend_Manage_RCDetails a join Knet_Procure_OrdersList_Details b on a.SER_OrderDetailID=b.ID ) and OrderType='128860698200781250' and b.ProductsBarCode in (select XPD_FaterBarCode from Xs_Products_Prodocts_Demo where XPD_ProductsBarCode='" + s_ProductsBarCode + "')and a.KPO_Del!=1 and SuppNo in(select SuppNo from KNet_Sys_WareHouse where HouseNo='" + Dtb_Table.Rows[i][1].ToString() + "')";
                        //    this.BeginQuery(sc_Sql);
                        //    this.QueryForDataTable();
                        //    DataTable Dtb_ScTable = this.Dtb_Result;//生产订单未入库
                        string sc_Sql =
                           "Select wrkNumber,a.ProductsBarCode from Knet_Procure_OrdersList_Details a join v_OrderRkDetails c on c.KPO_ID=a.ID join Knet_Procure_OrdersList b  on a.OrderNo =b.OrderNo Where  a.OrderNo in(select OrderNo FROM Knet_Procure_OrdersList a  join v_OrderRKWithNoDel b on a.OrderNO=b.V_OrderNo join KNet_Sys_ProcureType c on a.OrderType=c.ProcureTypeValue where rkState!=1 and OrderType='128860698200781250'and a.KPO_Del!=1) and a.ProductsBarCode in (select XPD_FaterBarCode from Xs_Products_Prodocts_Demo where XPD_ProductsBarCode='" + s_ProductsBarCode + "') and SuppNo in(select SuppNo from KNet_Sys_WareHouse where HouseNo='" + Dtb_Table.Rows[i][1].ToString() + "')";
                        this.BeginQuery(sc_Sql);
                        this.QueryForDataTable();
                        DataTable Dtb_ScTable = this.Dtb_Result;//生产订单未入库或者部分入库
                        int a = 0, b = 0, c = 0;
                        for (int j = 0; j < Dtb_ScTable.Rows.Count; j++)
                        {
                            string pro_Sql = "select XPD_Number from Xs_Products_Prodocts_Demo where XPD_FaterBarCode='" +
                                             Dtb_ScTable.Rows[j][1] + "' and XPD_ProductsBarCode='" + s_ProductsBarCode +
                                             "'";
                            this.BeginQuery(pro_Sql);
                            this.QueryForDataTable();
                            DataTable Dtb_PrTable = this.Dtb_Result;//获取BOM数量
                            if (Dtb_ScTable.Rows[j][0].ToString() == "0")
                            {
                                c += 0;
                            }
                            else
                            {
                                c += int.Parse(Dtb_ScTable.Rows[j][0].ToString()) * int.Parse(Dtb_PrTable.Rows[0][0].ToString());//计算已经下生产订单，但还未耗料的
                            }
                        }
                       
                        if (BomSum_Table.Rows[0][0].ToString() == "")
                        {

                        }
                        else
                        {
                            a = int.Parse(BomSum_Table.Rows[0][0].ToString());//计算订单评审并且没有创建生产订单也没有创建出库通知的应耗物料的总数量
                        }
                        //if (Dtb_ScTable.Rows[0][0].ToString() == "0")
                        //{

                        //}
                        //else
                        //{
                        //    c = int.Parse(Dtb_ScTable.Rows[0][0].ToString()) * num;//计算已经下生产订单，但还未耗料的
                        //}
                        try
                        {
                            if (Dtb_CgTable.Rows[0][0].ToString() == "0")
                            {

                            }
                            else
                            {
                                b = int.Parse(Dtb_CgTable.Rows[0][0].ToString());//在途数量
                            }
                        }
                        catch
                        {


                        }

                        int count = (int.Parse(Dtb_Table.Rows[i][0].ToString()) + b - a - c);
                        if (count <= 0)
                        {
                            s_Return += "<a href =\"javascript:void(0);\" style=\"color: red;\" target=\"_blank\">" +
                                        Base_GetHouseName(Dtb_Table.Rows[i][1].ToString()) + "(" + count + ")|" + "</a>" + "<a href =\"javascript:void(0);\" style=\"color: black;\" target=\"_blank\">在途【" + b + "】|" + "</a>";
                        }
                        else
                        {
                            s_Return += "<a href =\"javascript:void(0);\"  target=\"_blank\">" +
                                       Base_GetHouseName(Dtb_Table.Rows[i][1].ToString()) + "(" + count + ")|" + "</a>" + "<a href =\"javascript:void(0);\" style=\"color: black;\" target=\"_blank\">在途【" + b + "】|" + "</a>";
                        }
                    }
                }
            }
            else
            {
                s_Return = "<a href =\"javascript:void(0);\" style=\"color: red;\" target=\"_blank\">无库存</a><br/>";
            }
        }
        catch (Exception ex)
        {
            s_Return = "-<br/>";
            throw;
        }
        return s_Return;
    }
}