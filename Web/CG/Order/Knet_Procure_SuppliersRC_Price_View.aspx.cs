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


public partial class Web_Sales_Knet_Procure_SuppliersRC_Price_View : BasePage
{
    public string s_MyTable_Detail = "", s_OrderStyle = "", s_DetailsStyle = "", s_MyTable_Detail1 = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        KNet.BLL.Knet_Procure_OrdersList bll = new KNet.BLL.Knet_Procure_OrdersList();
        this.Lbl_Title.Text = "查看BOM报价";
        AdminloginMess AM = new AdminloginMess();
        if (AM.CheckLogin(this.Lbl_Title.Text) == false)
        {
            Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
            Response.End();
        }
        string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
        string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
        this.Tbx_ID.Text = s_ID;
        if (s_ID != "")
        {
            ShowInfo(s_ID);
        }
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

    }

    private void ShowInfo(string s_ID)
    {
        KNet.BLL.Cg_Suppliers_Price BLL = new KNet.BLL.Cg_Suppliers_Price();
        KNet.Model.Cg_Suppliers_Price Model = BLL.GetModel(s_ID);
        if (Model != null)
        {
            this.Lbl_Products.Text = Model.CSP_ID;
            if (Model.CSP_IsStop == 1)
            {
                this.Lbl_STop.Text = "是";
            }
            else
            {
                this.Lbl_STop.Text = "否";
            }
            try
            {
                this.Lbl_CTime.Text = Model.CSP_CTime.ToString();
            }
            catch { }
            this.Lbl_CPerson.Text = base.Base_GetUserName(Model.CSP_Creator);
        }
        if (Model.CSP_State == 0)
        {
            this.btn_Chcek.Text = "审批";
        }
        else
        {
            this.btn_Chcek.Text = "反审批";
        }

        KNet.BLL.Knet_Procure_SuppliersPrice Bll_Details = new KNet.BLL.Knet_Procure_SuppliersPrice();
        string s_Sql = " KPP_CgID='" + s_ID + "'  ";
        s_Sql += " and ProductsBarCode in (Select ProductsBarCode from KNET_Sys_Products where KSP_COde like '01%')";
        DataSet Dts_Table = Bll_Details.GetList(s_Sql);//成品
        if (Dts_Table.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
            {
                s_MyTable_Detail += " <tr>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + DateTime.Parse(Dts_Table.Tables[0].Rows[i]["ProcureUpdateDateTime"].ToString()) + "</td>";//
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetProdutsName(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetProductsCode(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"left\">" + base.Base_GetProductsEdition_Link(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetSupplierName_Link(Dts_Table.Tables[0].Rows[i]["SuppNo"].ToString()) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["ProcureUnitPrice"].ToString(), 3) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["HandPrice"].ToString(), 3) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetBasicCodeName("131", Dts_Table.Tables[0].Rows[i]["KPP_Del"].ToString()) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + Dts_Table.Tables[0].Rows[i]["KPP_Remarks"].ToString() + "&nbsp;</td></tr>";
                //历史报价
                s_MyTable_Detail += " <tr>\n<td colspan=\"9\" class=\"dvInnerHeader\"><b>历史报价</b>\n</td>\n</tr>\n";

                DataSet Dts_HisTable = Bll_Details.GetList(" ProductsBarCode='" + Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "' and  ID<>'" + Dts_Table.Tables[0].Rows[i]["ID"].ToString() + "' and  ProcureUnitPrice<>'" + Dts_Table.Tables[0].Rows[i]["ProcureUnitPrice"].ToString() + "' Order by ProcureUpdateDateTime desc");
                if (Dts_HisTable.Tables[0].Rows.Count > 0)
                {

                    for (int j = 0; j < Dts_HisTable.Tables[0].Rows.Count; j++)
                    {
                        s_MyTable_Detail += "<tr><td class=\"ListHeadDetails\" align=\"center\">" + DateTime.Parse(Dts_HisTable.Tables[0].Rows[j]["ProcureUpdateDateTime"].ToString()) + "</td>";//
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetProdutsName(Dts_HisTable.Tables[0].Rows[j]["ProductsBarCode"].ToString()) + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetProductsCode(Dts_HisTable.Tables[0].Rows[j]["ProductsBarCode"].ToString()) + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"left\">" + base.Base_GetProductsEdition_Link(Dts_HisTable.Tables[0].Rows[j]["ProductsBarCode"].ToString()) + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetSupplierName_Link(Dts_HisTable.Tables[0].Rows[j]["SuppNo"].ToString()) + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_HisTable.Tables[0].Rows[j]["ProcureUnitPrice"].ToString(), 3) + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_HisTable.Tables[0].Rows[j]["HandPrice"].ToString(), 3) + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetBasicCodeName("131", Dts_HisTable.Tables[0].Rows[j]["KPP_Del"].ToString()) + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + Dts_HisTable.Tables[0].Rows[j]["KPP_Remarks"].ToString() + "&nbsp;</td></tr>";
                    }
                }              
            }
        }
        string s_Details = "";
         s_Sql = " KPP_CgID='" + s_ID + "'  ";
         s_Sql += " and ProductsBarCode in (Select ProductsBarCode from KNET_Sys_Products where KSP_COde like '02%') ";
        KNet.BLL.Knet_Procure_SuppliersPrice Bll_Details1 = new KNet.BLL.Knet_Procure_SuppliersPrice();
        DataSet Dts_Table1 = Bll_Details1.GetList(s_Sql);//不是成品的报价
        if (Dts_Table1.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < Dts_Table1.Tables[0].Rows.Count; i++)
            {
                s_MyTable_Detail1 += " <tr>";
                s_MyTable_Detail1 += "<td class=\"ListHeadDetails\" align=\"center\">" + DateTime.Parse(Dts_Table1.Tables[0].Rows[i]["ProcureUpdateDateTime"].ToString()) + "</td>";//
                s_MyTable_Detail1 += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetProdutsName(Dts_Table1.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                s_MyTable_Detail1 += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetProductsCode(Dts_Table1.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                s_MyTable_Detail1 += "<td class=\"ListHeadDetails\" align=\"left\">" + base.Base_GetProductsEdition_Link(Dts_Table1.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                s_MyTable_Detail1 += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetSupplierName_Link(Dts_Table1.Tables[0].Rows[i]["SuppNo"].ToString()) + "</td>";
                s_MyTable_Detail1 += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table1.Tables[0].Rows[i]["ProcureUnitPrice"].ToString(), 3) + "</td>";
                s_MyTable_Detail1 += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table1.Tables[0].Rows[i]["HandPrice"].ToString(), 3) + "</td>";
                s_MyTable_Detail1 += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table1.Tables[0].Rows[i]["KPP_Number"].ToString(), 0) + "&nbsp;</td>";
                s_MyTable_Detail1 += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetBasicCodeName("125", Dts_Table1.Tables[0].Rows[i]["KPP_Address"].ToString()) + "&nbsp;</td>";
                s_MyTable_Detail1 += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetBasicCodeName("131", Dts_Table1.Tables[0].Rows[i]["KPP_Del"].ToString()) + "</td>";
                s_MyTable_Detail1 += "<td class=\"ListHeadDetails\" align=\"center\">" + Dts_Table1.Tables[0].Rows[i]["KPP_Remarks"].ToString() + "&nbsp;</td></tr>";


                //DataSet Dts_HisTable1 = Bll_Details1.GetList(" ProductsBarCode='" + Dts_Table1.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "' and  ID<>'" + Dts_Table1.Tables[0].Rows[i]["ID"].ToString() + "' Order by ProcureUpdateDateTime desc");
                //if (Dts_HisTable1.Tables[0].Rows.Count > 0)
                //{

                //    for (int j = 0; j < Dts_HisTable1.Tables[0].Rows.Count; j++)
                //    {
                //        s_Details += "<tr><td class=\"ListHeadDetails\" align=\"center\">" + DateTime.Parse(Dts_HisTable1.Tables[0].Rows[j]["ProcureUpdateDateTime"].ToString()) + "</td>";//
                //        s_Details += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetProdutsName(Dts_HisTable1.Tables[0].Rows[j]["ProductsBarCode"].ToString()) + "</td>";
                //        s_Details += "<td class=\"ListHeadDetails\" align=\"center\">" + Dts_HisTable1.Tables[0].Rows[j]["ProductsBarCode"].ToString() + "</td>";
                //        s_Details += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetProductsEdition_Link(Dts_HisTable1.Tables[0].Rows[j]["ProductsBarCode"].ToString()) + "</td>";
                //        s_Details += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetSupplierName_Link(Dts_HisTable1.Tables[0].Rows[j]["SuppNo"].ToString()) + "</td>";
                //        s_Details += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_HisTable1.Tables[0].Rows[j]["ProcureUnitPrice"].ToString(), 3) + "</td>";
                //        s_Details += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_HisTable1.Tables[0].Rows[j]["HandPrice"].ToString(), 3) + "</td>";
                //        s_Details += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_HisTable1.Tables[0].Rows[j]["KPP_Number"].ToString(), 3) + "</td>";
                //        s_Details += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_HisTable1.Tables[0].Rows[j]["HandPrice"].ToString(), 3) + "</td>";
                //        s_Details += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetBasicCodeName("131", Dts_HisTable1.Tables[0].Rows[j]["KPP_Del"].ToString()) + "</td>";
                //        s_Details += "<td class=\"ListHeadDetails\" align=\"center\">" + Dts_HisTable1.Tables[0].Rows[j]["KPP_Remarks"].ToString() + "</td></tr>";
                //    }
                //}              
            }

            //历史报价
            //s_MyTable_Detail1 += " <tr>\n<td colspan=\"11\" class=\"dvInnerHeader\"><b>历史报价</b>\n</td>\n</tr>\n" + s_Details;
        }
    }
    protected void btn_Chcek_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        try {

            string s_ID = this.Tbx_ID.Text;
            KNet.BLL.Cg_Suppliers_Price BLL = new KNet.BLL.Cg_Suppliers_Price();
            KNet.Model.Cg_Suppliers_Price Model = BLL.GetModel(s_ID);
            if (this.btn_Chcek.Text == "审批")
            {
                Model.CSP_State = 1;
                BLL.Update(Model);
                string sql = "Update  Knet_Procure_SuppliersPrice set KPP_State=1 where KPP_CgID='" + this.Tbx_ID.Text + "' ";
                DbHelperSQL.ExecuteSql(sql);
                AM.Add_Logs("审批BOM价格：" + s_ID + "");
                AlertAndRedirect("审批成功！", "Knet_Procure_SuppliersRC_Price.aspx");
            }
            else {

                Model.CSP_State = 0;
                BLL.Update(Model);
                string sql = "Update  Knet_Procure_SuppliersPrice set KPP_State=0 where KPP_CgID='" + this.Tbx_ID.Text + "' ";
                DbHelperSQL.ExecuteSql(sql);
                AM.Add_Logs("反审批BOM价格：" + s_ID + "");
                AlertAndRedirect("反审批成功！", "Knet_Procure_SuppliersRC_Price.aspx");
            }
        }
        catch
        { }
    }
}
