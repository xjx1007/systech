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

public partial class BOM : BasePage
{
    public string s_MyTable_Detail = "", s_ProductsTable_Detail = "", s_ProductsTable_BomDetail = "", s_ProductsRC = "", s_ProductsTable_BomDetail1 = "";
    public string s_OrderStyle = "", s_DetailsStyle = "", s_RC_ProductsBarCode = "", s_CgDayDetail = "", s_AlternativeDetail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("查看产品") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            this.Get_Knet_Suppliers_ByID();
        }
    }


    /// <summary>
    /// 获取记录数据
    /// </summary>
    protected void Get_Knet_Suppliers_ByID()
    {

        AdminloginMess AM = new AdminloginMess();

        KNet.BLL.KNet_Sys_Products BLL = new KNet.BLL.KNet_Sys_Products();
        string s_Model = Request.QueryString["Model"] == null ? "" : Request.QueryString["Model"].ToString();
        if (Request["BarCode"] != null && Request["BarCode"] != "")
        {
            string BarCode = Request.QueryString["BarCode"].ToString().Trim();
            this.Tbx_ID.Text = BarCode;
            s_RC_ProductsBarCode = Request.QueryString["BarCode"].ToString().Trim();
            if (GetKNet_Sys_ProductsYN(BarCode) == true)
            {
                KNet.Model.KNet_Sys_Products model = BLL.GetModelB(BarCode);
                if (model.KSP_isModiy == 1)
                {
                    AlertAndClose("产品未通过审批不能查看BOM！请联系研发部。");
                }
                GetBomDetails(model);
                //适用成品1
                KNet.BLL.Xs_Products_Prodocts_Demo BLL_RCProducts = new KNet.BLL.Xs_Products_Prodocts_Demo();
                DataSet Dts_RCProducts = BLL_RCProducts.GetList(" XPD_ProductsBarCode='" + model.ProductsBarCode + "' ");
                DataTable Dtb_RCProducts = Dts_RCProducts.Tables[0];
                if (Dtb_RCProducts.Rows.Count > 0)
                {

                    for (int i = 0; i < Dtb_RCProducts.Rows.Count; i++)
                    {
                        s_ProductsRC += "<tr>";
                        s_ProductsRC += "<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName_Link(Dtb_RCProducts.Rows[i]["XPD_FaterBarCode"].ToString()) + "</td>";
                        s_ProductsRC += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dtb_RCProducts.Rows[i]["XPD_FaterBarCode"].ToString()) + "</td>";
                        s_ProductsRC += "<td class=\"ListHeadDetails\">" + base.Base_GetUnitsName(base.Base_GetProductsUnits(Dtb_RCProducts.Rows[i]["XPD_FaterBarCode"].ToString())) + "</td>";
                        string s_Price = base.FormatNumber1(Dtb_RCProducts.Rows[i]["XPD_Price"].ToString(), 3);
                        if (i > 0)
                        {
                            if (s_Price != base.FormatNumber1(Dtb_RCProducts.Rows[i - 1]["XPD_Price"].ToString(), 3))
                            {
                                s_Price = "<font color=red>" + s_Price + "</font>";
                            }
                        }
                        s_ProductsRC += "<td class=\"ListHeadDetails\">" + s_Price + "</td>";
                        s_ProductsRC += "<td class=\"ListHeadDetails\">" + base.FormatNumber1(Dtb_RCProducts.Rows[i]["XPD_Number"].ToString(), 3) + "</td>";
                        string s_order = Dtb_RCProducts.Rows[i]["XPD_IsOrder"] == null ? "否" : Dtb_RCProducts.Rows[i]["XPD_IsOrder"].ToString();
                        s_ProductsRC += "<td class=\"ListHeadDetails\">" + s_order + "</td>";

                        s_ProductsRC += "</tr>";
                    }
                }

                KNet.BLL.PB_Products_CgDays BLL_CgDays = new KNet.BLL.PB_Products_CgDays();
                DataSet Dts_CgDays = BLL_CgDays.GetList(" PPC_ProductsBarCode='" + model.ProductsBarCode + "' ");
                DataTable Dtb_CgDays = Dts_CgDays.Tables[0];
                if (Dtb_CgDays.Rows.Count > 0)
                {

                    for (int i = 0; i < Dtb_CgDays.Rows.Count; i++)
                    {
                        s_CgDayDetail += "<tr>";
                        s_CgDayDetail += "<td class=\"ListHeadDetails\">" + Dtb_CgDays.Rows[i]["PPC_Min"].ToString() + "</td>";
                        s_CgDayDetail += "<td class=\"ListHeadDetails\">" + Dtb_CgDays.Rows[i]["PPC_Max"].ToString() + "</td>";
                        s_CgDayDetail += "<td class=\"ListHeadDetails\">" + Dtb_CgDays.Rows[i]["PPC_Days"].ToString() + "</td>";
                        s_CgDayDetail += "</tr>";
                    }
                }




            }
            else
            {
                Response.Write("<script language=javascript>alert('该产品在产品字典中已不存在！');window.close();</script>");
                Response.End();
            }
        }
        else
        {
            Response.Write("<script language=javascript>alert('非法参数！');window.close();</script>");
            Response.End();
        }
    }
    private void GetBomDetails(KNet.Model.KNet_Sys_Products model)
    {
        decimal d_totalPrice = 0;

        AdminloginMess AM = new AdminloginMess();

        KNet.BLL.Xs_Products_Prodocts BLL_Products_Products = new KNet.BLL.Xs_Products_Prodocts();
        KNet.BLL.PB_Basic_ProductsClass BLL_Basic_ProductsClass = new KNet.BLL.PB_Basic_ProductsClass();
        string s_DemoProductsID = "";
        KNet.BLL.Xs_Products_Prodocts_Demo BLL_DemoProducts_Products = new KNet.BLL.Xs_Products_Prodocts_Demo();
        string s_Where1 = " and XPD_FaterBarCode='" + model.ProductsBarCode + "' ";
        if ((AM.KNet_StaffDepart == "129652784259578018") || (AM.KNet_StaffName == "项洲"))//如果是
        {
            s_Where1 += " and  b.KSP_Del=0 ";
        }
        string s_Sql = "Select * from Xs_Products_Prodocts_Demo a join KNET_Sys_Products b on a.XPD_ProductsBarCode=b.ProductsBarCode";
        s_Sql += " join PB_Basic_ProductsClass c on b.ProductsType=c.PBP_ID where 1=1 ";
        this.BeginQuery(s_Sql + s_Where1 + "  order by c.PBP_Name,ProductsEdition");
        DataSet Dts_DemoProducts = (DataSet)this.QueryForDataSet();
        DataTable Dtb_DemoProducts = Dts_DemoProducts.Tables[0];
        StringBuilder Sb_BomDetails = new StringBuilder();
        if (Dtb_DemoProducts.Rows.Count > 0)
        {

            for (int i = 0; i < Dtb_DemoProducts.Rows.Count; i++)
            {
                s_DemoProductsID += Dtb_DemoProducts.Rows[i]["XPD_ProductsBarCode"].ToString() + ",";
                Sb_BomDetails.Append("<tr>");
                Sb_BomDetails.Append("<td class=\"ListHeadDetails\">" + (i + 1).ToString() + "</td>");

                Sb_BomDetails.Append("<td class=\"ListHeadDetails\">" + Dtb_DemoProducts.Rows[i]["XPD_Order"].ToString() + "</td>");
                //Sb_BomDetails.Append("<td class=\"ListHeadDetails\">" + Dtb_DemoProducts.Rows[i]["PBP_Name"].ToString() + "</td>");
                Sb_BomDetails.Append("<td class=\"ListHeadDetails\">" + Dtb_DemoProducts.Rows[i]["ProductsName"].ToString() + "</td>");
                Sb_BomDetails.Append("<td class=\"ListHeadDetails\">" + Dtb_DemoProducts.Rows[i]["ProductsEdition"].ToString() + "</td>");

                //Sb_BomDetails.Append("<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition_Link(Dtb_DemoProducts.Rows[i]["XPD_ProductsBarCode"].ToString()) + "</td>");
                string s_ProductsCode = "";

                Sb_BomDetails.Append("<td class=\"ListHeadDetails\">" + Dtb_DemoProducts.Rows[i]["KSP_Code"].ToString() + "</td>");
                Sb_BomDetails.Append("<td class=\"ListHeadDetails\"><input type=\"hidden\" input Name=\"DemoNumber\" value='" + Dtb_DemoProducts.Rows[i]["XPD_Number"].ToString() + "'>" + Dtb_DemoProducts.Rows[i]["XPD_Number"].ToString() + "</td>");
                // Sb_BomDetails.Append("<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition_Link(Dtb_DemoProducts.Rows[i]["XPD_ReplaceProductsBarCode"].ToString()) + "</td>");
                Sb_BomDetails.Append("<td class=\"ListHeadDetails\" style=\"max-width:250px;word-break: break-all;word-wrap:break-word;\">" + Dtb_DemoProducts.Rows[i]["XPD_Place"].ToString() + "</td>");
                //使用方式
                Sb_BomDetails.Append("<td class=\"ListHeadDetails\">" +base.Base_GetBasicCodeName("1134", Dtb_DemoProducts.Rows[i]["KSP_UseType"].ToString() )+ "</td>");

                /* string s_Only = Dtb_DemoProducts.Rows[i]["XPD_Only"] == null ? "0" : Dtb_DemoProducts.Rows[i]["XPD_Only"].ToString();
                 string s_Check = "";
                 if (s_Only == "1")
                 {
                     s_Check = "是";
                 }
                 else
                 {
                     s_Check = "否";
                 }
                 Sb_BomDetails.Append("<td class=\"ListHeadDetails\">" + s_Check + "</td>");
                 * 
                 string s_Del = Dtb_DemoProducts.Rows[i]["KSP_Del"].ToString();
                 if (s_Del == "1")
                 {
                     Sb_BomDetails.Append("<td class=\"ListHeadDetails\"><font color=red>已停用</font></td>");
                 }
                 else
                 {
                     Sb_BomDetails.Append("<td class=\"ListHeadDetails\"><font color=green>启用</font></td>");
                 }

                 string s_IsModify = Dtb_DemoProducts.Rows[i]["KSP_isModiy"].ToString();
                 if (s_IsModify == "1")
                 {
                     Sb_BomDetails.Append("<td class=\"ListHeadDetails\"><font color=red>新产品</font></td>");
                 }
                 else
                 {
                     Sb_BomDetails.Append("<td class=\"ListHeadDetails\"><font color=green>启用</font></td>");
                 }*/

                Sb_BomDetails.Append("</tr>");
            }
        }
        Lbl_BomDetails1.Text = Sb_BomDetails.ToString();
        Tbx_BomNumber.Text = Dtb_DemoProducts.Rows.Count.ToString();
    }
    public string GetContract(string s_ContractNos, string s_ContractNo1)
    {
        string s_Return = "";
        try
        {
            string[] s_ContractNo = s_ContractNos.Split(',');
            for (int i = 0; i < s_ContractNo.Length; i++)
            {
                s_Return += "<a href=\"/Web/Xs/SalesContract/KNet_Sales_ContractList_View.aspx?ID=" + s_ContractNo[i] + "\" target=\"_blank\" >" + s_ContractNo[i] + "</a><br>";
            }
            if (s_Return == "")
            {
                s_Return += "<a href=\"/Web/Xs/SalesContract/KNet_Sales_ContractList_View.aspx?ID=" + s_ContractNo1 + "\"  target=\"_blank\" >" + s_ContractNo1 + "</a><br>";
            }
        }
        catch
        { }
        return s_Return;
    }

    public string GetRk(string s_RKSTtate, string s_OrderNo)
    {

        if (s_RKSTtate == "0")
        {

            return "<a href=\"/Web/Cg/OrderInWareHouse/Knet_Procure_WareHouseList_Add.aspx?OrderNo=" + s_OrderNo + "\"><font color=\"red\">未入库</font></a>";
        }
        else if (s_RKSTtate == "1")
        {
            return "<a href=\"/Web/Cg/OrderInWareHouse/Knet_Procure_WareHouseList_Add.aspx?OrderNo=" + s_OrderNo + "\"><font color=\"red\">已入库</font></a>";
        }
        else
        {
            return "<a href=\"/Web/Cg/OrderInWareHouse/Knet_Procure_WareHouseList_Add.aspx?OrderNo=" + s_OrderNo + "\"><font color=\"red\">部分发货</font></a>";
        }
    }

    protected string CheckView(string s_OrderNo, string s_OrderType)
    {
        string s_Return = "", JSD = "";
        KNet.BLL.Knet_Procure_OrdersList BLl = new KNet.BLL.Knet_Procure_OrdersList();
        KNet.Model.Knet_Procure_OrdersList Model = BLl.GetModel(s_OrderNo);

        if (Model.KPO_Del == 1)
        {
            return "<font color=red>订单关闭</font>";
        }
        if (Model.OrderCheckYN == false)
        {
            s_Return = "";
        }
        else
        {
            //if (base.base_GetProcureTypeNane(s_OrderType) == "芯片")
            //{
            //    JSD = "OrderList_View.aspx?OrderNo=" + s_OrderNo + "";
            //    s_Return = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=780,height=500');\"  title=\"点击进行审核操作\"><img src=\"../../../images/View.gif\"  border=\"0\" /></a>";

            //}
            //else
            //{ }
            string s_Sql = "Select Sum(KSP_isModiy) from KNet_Sys_Products a join Knet_Procure_OrdersList_Details b on a.ProductsBarCode=b.ProductsBarCode";
            s_Sql += " where b.OrderNo='" + Model.OrderNo + "' ";
            this.BeginQuery(s_Sql);
            string s_IsModiy = this.QueryForReturn();
            if (int.Parse(s_IsModiy) > 0)
            {
                s_Return += "<font color=red>产品需确认</font>";
            }
            else
            {
                JSD = "/web/Cg/Order/Knet_Procure_OpenBilling_Print.aspx?ID=" + s_OrderNo + "";
                s_Return = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=120,left=150,toolbar=yes, menubar=yes,scrollbars=yes, resizable=yes, location=yes, status=yes, width=780,height=500');\"  title=\"点击查看\"><img src=\"/web/images/View.gif\"  border=\"0\" /></a>";
                s_Return += "  <a href=\"/web/Cg/Order/PDF/" + Model.OrderNo + ".PDF\" class=\"webMnu\" target=\"_blank\"><img src=\"/web/images/pdf.gif\"  border=\"0\" /></a> ";
                s_Return += "  <a href=\"/web/Mail/PB_Basic_Mail_Add.aspx?OrderNo=" + Model.OrderNo + "\" class=\"webMnu\" target=\"_blank\"><img src=\"/web/images/email.gif\"  border=\"0\" /></a> ";

            }
        }
        return s_Return;

    }

    protected string GetPrint(string s_OrderNo, int i_IsSend)
    {
        string s_Return = "";
        if (i_IsSend == 0)
        {
            s_Return = "<font color=red>未发送</font>";
        }
        else if (i_IsSend == 1)
        {
            s_Return = "已发送";
        }
        else if (i_IsSend == 2)
        {
            s_Return = "<font color=green>已确认</font>";
        }
        return s_Return;

    }

    public string GetSpce(string s_ID)
    {
        KNet.BLL.Xs_Products_Spce Bll = new KNet.BLL.Xs_Products_Spce();
        KNet.Model.Xs_Products_Spce Model = Bll.GetModel(s_ID);
        string s_XPS_SpceName = "../UpLoadPic/WordSpce/" + Model.XPS_SpceName;

        return s_XPS_SpceName;
    }
    /// <summary>
    /// 字典里是否存在产品
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected bool GetKNet_Sys_ProductsYN(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,ProductsBarCode,ProductsName from KNet_Sys_Products where ProductsBarCode='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    private void SetBom()
    {

        Excel export = new Excel();
        string s_Name = "";
        try
        {
            s_Name = base.Base_GetProdutsName(this.Tbx_ID.Text) + "(" + base.Base_GetProductsPattern(this.Tbx_ID.Text) + ")";
        }
        catch { }
        string s_FileName = s_Name + "_BOM.xls";
        //if (MyGridView1.AllowPaging == true)
        //{
        //    MyGridView1.AllowPaging = false;
        //    this.DataBind();
        //}

        KNet.BLL.Xs_Products_Prodocts BLL_Products_Products = new KNet.BLL.Xs_Products_Prodocts();
        KNet.BLL.PB_Basic_ProductsClass BLL_Basic_ProductsClass = new KNet.BLL.PB_Basic_ProductsClass();
        string s_DemoProductsID = "";
        KNet.BLL.Xs_Products_Prodocts_Demo BLL_DemoProducts_Products = new KNet.BLL.Xs_Products_Prodocts_Demo();
        string s_Where1 = " and XPD_FaterBarCode='" + this.Tbx_ID.Text + "' ";
        s_Where1 += " and  b.KSP_Del=0 ";
        string s_Sql = "Select * from Xs_Products_Prodocts_Demo a join KNET_Sys_Products b on a.XPD_ProductsBarCode=b.ProductsBarCode";
        s_Sql += " join PB_Basic_ProductsClass c on b.ProductsType=c.PBP_ID where 1=1 ";
        this.BeginQuery(s_Sql + s_Where1 + "  order by c.PBP_Name,ProductsEdition");
        DataSet Dts_DemoProducts = (DataSet)this.QueryForDataSet();
        DataTable Dtb_DemoProducts = Dts_DemoProducts.Tables[0];
        Tbx_Bom.Text = GetStringWriter(Dtb_DemoProducts).ToString();
    }
    protected void Btn_Excel_Click(object sender, EventArgs e)
    {
        
        //export.ExcelExport(GetStringWriter(Dtb_DemoProducts), s_FileName);
    }

    
    public   StringWriter GetStringWriter(DataTable dt)
    {
        StringWriter sw = new StringWriter();

        //先写列的表头，这样保证如果没有数据也能输出列表头 
        sw.Write("编号  " + "\t ");
        sw.Write("BOM序号 " + "\t ");
        sw.Write("类别 " + "\t ");
        sw.Write("产品名称 " + "\t ");
        sw.Write("版本号 " + "\t ");
        sw.Write("料号 " + "\t ");
        sw.Write("数量 " + "\t ");
        sw.Write("位号 " + "\t ");
        sw.Write("使用方式 " + "\t ");

        sw.Write(sw.NewLine);

        //如果包含数据 
        if (dt != null)
        {
            //写数据 
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                sw.Write((i + 1).ToString()+ "\t");
                
                sw.Write(dt.Rows[i]["XPD_Order"].ToString()+ "\t");
                sw.Write(dt.Rows[i]["PBP_Name"].ToString()+ "\t");
                sw.Write(dt.Rows[i]["ProductsName"].ToString()+ "\t");
                sw.Write(base.Base_GetProductsEdition(dt.Rows[i]["XPD_ProductsBarCode"].ToString()) + "\t");
                sw.Write("'" + dt.Rows[i]["KSP_Code"].ToString() + "\t");
                sw.Write(dt.Rows[i]["XPD_Number"].ToString() + "\t");
                sw.Write(dt.Rows[i]["XPD_Place"].ToString() + "\t");
                sw.Write(base.Base_GetBasicCodeName("1134",dt.Rows[i]["KSP_UseType"].ToString()) + "\t");

                //换行 
                sw.Write(sw.NewLine);
                i++;
            }
        }
        sw.Close();

        return sw;
}
}
