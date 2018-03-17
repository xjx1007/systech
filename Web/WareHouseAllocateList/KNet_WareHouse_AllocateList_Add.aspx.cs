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


/// <summary>
/// 库存管理-----库间调拨----添加
/// </summary>
public partial class Knet_Web_WareHouse_KNet_WareHouse_AllocateList_Add : BasePage
{
    public string s_MyTable_Detail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();

            string s_OrderNo = Request.QueryString["OrderNo"] == null ? "" : Request.QueryString["OrderNo"].ToString();

            string s_SuppNo = Request.QueryString["SuppNo"] == null ? "" : Request.QueryString["SuppNo"].ToString();

            this.Tbx_Type.Text = s_Type;
            this.Tbx_SuppNo.Text = s_SuppNo;
            string s_Sql = " 1=1 ";
            this.AllocateDateTime.Text = DateTime.Now.ToShortDateString();
            this.Lbl_Title.Text = "新增调拨入库";

            base.Base_DropBasicCodeBind(this.Ddl_Type, "1132");
            if (s_OrderNo != "")
            {
                if ((s_Type == "1") || (s_Type == "3"))
                {
                    //131235104473261008
                    this.Ddl_Type.SelectedValue = "0";

                    string s_Sql1 = "Select Sum(KSP_isModiy) from KNet_Sys_Products a join Knet_Procure_OrdersList_Details b on a.ProductsBarCode=b.ProductsBarCode";
                    s_Sql1 += " where b.OrderNo='" + s_OrderNo + "' ";
                    this.BeginQuery(s_Sql1);
                    string s_IsModiy = this.QueryForReturn();
                    if (int.Parse(s_IsModiy) > 0)
                    {
                        AlertAndClose("产品未审批不能领料！窗口将关闭");
                    }
                    else
                    {
                        ShowOrderInfo1(s_OrderNo);
                    }
                }
                else if (s_Type == "4")
                {
                    this.Ddl_Type.SelectedValue = "1";
                    GetDetialsOrder2(s_OrderNo);
                }
                else
                {

                    this.Ddl_Type.SelectedValue = "1";
                    ShowOrderInfo(s_OrderNo);
                }

            }
            else
            {
                if (this.Tbx_SuppNo.Text != "")
                {
                    this.Ddl_Type.SelectedValue = "1";
                    this.HouseNo_out.SelectedValue = this.Tbx_SuppNo.Text;

                    this.Ddl_Type.Enabled = false;
                    this.HouseNo_out.Enabled = false;
                }
                StringBuilder Sb_Details = new StringBuilder();
                Sb_Details.Append("<tr valign=\"top\">");
                Sb_Details.Append("<td valign=\"top\" class=\"ListHead\" align=\"right\" nowrap>");
                Sb_Details.Append("<b>工具</b>");
                Sb_Details.Append("</td>");
                Sb_Details.Append("<td class=\"ListHead\" nowrap>");
                Sb_Details.Append("<b>产品名称</b>");
                Sb_Details.Append("</td>");
                Sb_Details.Append("<td class=\"ListHead\" nowrap>");
                Sb_Details.Append("<b>产品编码</b>");
                Sb_Details.Append("</td>");
                Sb_Details.Append("<td class=\"ListHead\" nowrap>");
                Sb_Details.Append("<b>版本号</b>");
                Sb_Details.Append("</td>");
                Sb_Details.Append("<td class=\"ListHead\" nowrap>");
                Sb_Details.Append("<b>最小包装</b>");
                Sb_Details.Append("</td>");
                Sb_Details.Append("<td class=\"ListHead\" nowrap>");
                Sb_Details.Append("<b>包数</b>");
                Sb_Details.Append("</td>");
                Sb_Details.Append("<td class=\"ListHead\" nowrap>");
                Sb_Details.Append("<b>数量</b>");
                Sb_Details.Append("</td>");
                Sb_Details.Append("<td class=\"ListHead\" nowrap>");
                Sb_Details.Append("<b>备注</b>");
                Sb_Details.Append("</td>");
                Sb_Details.Append("</tr>");

                this.Lbl_Details.Text = Sb_Details.ToString();
                if (this.Tbx_SuppNo.Text != "")
                {
                    string s_DoSql = "Select SUM(DirectInAmount) as Number,ProductsBarCode,KSP_Code from v_Store where HouseNo='" + this.Tbx_SuppNo.Text + "'  and KSP_Code not like '01%' group by ProductsBarCode,KSP_Code having SUM(DirectInAmount)<>0";
                    this.BeginQuery(s_DoSql);
                    DataSet Dts_Details = (DataSet)this.QueryForDataSet();

                    if (Dts_Details.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < Dts_Details.Tables[0].Rows.Count; i++)
                        {
                            s_MyTable_Detail += "<tr>";
                            this.Xs_ProductsCode.Text += Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + ",";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\"><A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a></td>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsCode(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ProductsBarCode_" + i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "'>" + base.Base_GetProductsEdition(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";

                            s_MyTable_Detail += "<td class=\"ListHeadDetails\" width=\"50px\"  >\n";

                            s_MyTable_Detail += "<input id=\"Tbx_CPBZNumber_" + i.ToString() + "\" type=\"input\" name=\"Tbx_CPBZNumber_" + i.ToString() + "\"  style=\"width:50px\" onblur=\"ChangPrice1(" + i.ToString() + ")\"    value=\"0\" />\n";

                            s_MyTable_Detail += "</td>\n";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\" width=\"50px\"  >\n";
                            s_MyTable_Detail += "<input id=\"Tbx_BZNumber_" + i.ToString() + "\" type=\"input\" name=\"Tbx_BZNumber_" + i.ToString() + "\" onblur=\"ChangPrice1(" + i.ToString() + ")\"  style=\"width:50px\"  value=\"0\" />\n";

                            s_MyTable_Detail += "</td>\n";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Number_" + i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["Number"].ToString() + "'></td>";

                            s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Remarks_" + i.ToString() + "\" ></td>";
                            s_MyTable_Detail += "</tr>";
                        }
                        this.Lbl_Details.Text += s_MyTable_Detail;
                        this.Tbx_Num.Text = Dts_Details.Tables[0].Rows.Count.ToString();
                    }
                }
            }
            if (s_ID != "")
            {
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制调拨入库";
                    this.AllocateNo.Text = "FXDB" + KNetOddNumbers();
                }
                else
                {
                    this.Lbl_Title.Text = "修改调拨入库";
                    this.Tbx_ID.Text = s_ID;
                    this.AllocateNo.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
            }
            else
            {
                if (s_Type == "2")
                {
                    s_Sql = "  HouseName like '%修%' ";
                    this.AllocateNo.Text = "FXDB" + KNetOddNumbers();
                }
                else
                {
                    s_Sql = "   KSW_Type='0' ";
                    this.AllocateNo.Text = "DB" + KNetOddNumbers();
                }
            }
            base.Base_DropWareHouseBind(this.HouseNo_out, s_Sql);
            base.Base_DropWareHouseBind(this.HouseNo_int, s_Sql);
            if (s_ID != "")
            {
                ShowInfo(s_ID);
            }
            if (AM.CheckLogin("新增直接入库") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
        }
    }

    private void ShowOrderInfo1(string s_OrderNo)
    {
        //显示明细信息
        try
        {

            StringBuilder Sb_Details1 = new StringBuilder();
            this.Tbx_OrderNo.Text = s_OrderNo;
            //
            //默认调出仓库为士腾

            KNet.BLL.Knet_Procure_OrdersList Bll_Order = new KNet.BLL.Knet_Procure_OrdersList();
            KNet.Model.Knet_Procure_OrdersList Model_Order = Bll_Order.GetModelB(s_OrderNo);

            string s_InHouseNo = "", s_OutHouseNo = "", s_INHouseName = "";
            if (this.Tbx_Type.Text == "1")
            {
                s_InHouseNo = "131235104473261008";

                string s_OEMSuppNo = Model_Order.SuppNo;
                try
                {
                    KNet.BLL.KNet_Sys_WareHouse bll_WareHouse = new KNet.BLL.KNet_Sys_WareHouse();
                    KNet.Model.KNet_Sys_WareHouse Model_WareHouse = bll_WareHouse.GetModelBySuppNo(s_OEMSuppNo);
                    //
                    s_OutHouseNo = Model_WareHouse.HouseNo;
                    this.HouseNo_out.SelectedValue = s_OutHouseNo;
                    s_INHouseName = Model_WareHouse.HouseName;
                }
                catch
                { }
                //
            }
            else if (this.Tbx_Type.Text == "3")
            {
                s_InHouseNo = "131187187069993664";
                s_OutHouseNo = "131235104473261008";
                this.HouseNo_out.SelectedValue = s_OutHouseNo;
                s_INHouseName = base.Base_GetHouseName(s_OutHouseNo);
            }

            this.HouseNo_int.SelectedValue = s_InHouseNo;
            string s_HouseName = base.Base_GetHouseName(s_InHouseNo);
            Sb_Details1.Append("<tr valign=\"top\">");
            Sb_Details1.Append("<tr valign=\"top\">");
            Sb_Details1.Append("<td valign=\"top\" class=\"ListHead\" align=\"right\" nowrap>");
            Sb_Details1.Append("<b>序号</b>");
            Sb_Details1.Append("</td>");
            Sb_Details1.Append("<td valign=\"top\" class=\"ListHead\" align=\"right\" nowrap>");
            Sb_Details1.Append("<b>工具</b>");
            Sb_Details1.Append("</td>");
            Sb_Details1.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details1.Append("<b>产品名称</b>");
            Sb_Details1.Append("</td>");
            Sb_Details1.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details1.Append("<b>料号</b>");
            Sb_Details1.Append("</td>");

            Sb_Details1.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details1.Append("<b>版本号</b>");
            Sb_Details1.Append("</td>");
            Sb_Details1.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details1.Append("<b>" + s_INHouseName + "</b>");
            Sb_Details1.Append("</td>");
            Sb_Details1.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details1.Append("<b>" + s_HouseName + "</b>");
            Sb_Details1.Append("</td>");
            Sb_Details1.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details1.Append("<b>数量</b>");
            Sb_Details1.Append("</td>");
            if (this.Tbx_Type.Text == "1")
            {
                Sb_Details1.Append("<td class=\"ListHead\" nowrap>");
                Sb_Details1.Append("<b>士腾不良品</b>");
                Sb_Details1.Append("</td>");
                Sb_Details1.Append("<td class=\"ListHead\" nowrap>");
                Sb_Details1.Append("<b>加工厂不良品</b>");
                Sb_Details1.Append("</td>");

            }
            Sb_Details1.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details1.Append("<b>单价</b>");
            Sb_Details1.Append("</td>");

            Sb_Details1.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details1.Append("<b>金额</b>");
            Sb_Details1.Append("</td>");
            Sb_Details1.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details1.Append("<b>备注</b>");
            Sb_Details1.Append("</td>");
            Sb_Details1.Append("</tr>");

            string s_MainSql = "Select * from v_Knet_Procure_OrdersList_Details_Allocate  a join KNET_Sys_Products b on a.ProductsBarCode=b.ProductsBarCode ";
            if (s_OrderNo != "")
            {
                s_MainSql += " and OrderNo='" + s_OrderNo + "'";
            }

            // s_MainSql += " and  DBState<>2 ";
            this.BeginQuery(s_MainSql);
            this.QueryForDataSet();
            DataSet Dts_MainDetails = Dts_Result;
            if (Dts_MainDetails.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_MainDetails.Tables[0].Rows.Count; i++)
                {
                    Sb_Details1.Append("<tr>");
                    Sb_Details1.Append("<td class=\"ListHeadDetails\">" + Convert.ToString(i + 1) + "</td>");

                    this.Xs_ProductsCode.Text += Dts_MainDetails.Tables[0].Rows[i]["ProductsBarCode"].ToString() + ",";
                    Sb_Details1.Append("<td class=\"ListHeadDetails\"><A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a></td>");
                    Sb_Details1.Append("<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName(Dts_MainDetails.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>");
                    Sb_Details1.Append("<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ProductsBarCode_" + i.ToString() + "\" value='" + Dts_MainDetails.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "'>" + Dts_MainDetails.Tables[0].Rows[i]["KSP_Code"].ToString() + "</td>");
                    Sb_Details1.Append("<td class=\"ListHeadDetails\">" + Dts_MainDetails.Tables[0].Rows[i]["ProductsEdition"].ToString() + "&nbsp;</td>");
                    string s_OutHouseNumber = base.Base_GetWareHouseNumber(s_OutHouseNo, Dts_MainDetails.Tables[0].Rows[i]["ProductsBarCode"].ToString());
                    string s_InHouseNumber = base.Base_GetWareHouseNumber(s_InHouseNo, Dts_MainDetails.Tables[0].Rows[i]["ProductsBarCode"].ToString());
                    Sb_Details1.Append("<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"KcNumber_" + i.ToString() + "\" value='" + s_OutHouseNumber + "'>" + s_OutHouseNumber + "</td>");
                    Sb_Details1.Append("<td class=\"ListHeadDetails\">" + s_InHouseNumber + "</td>");

                    string s_TDstyle = "";
                    try
                    {
                        if (int.Parse(Dts_MainDetails.Tables[0].Rows[i]["OrderAmount"].ToString()) > int.Parse(s_OutHouseNumber))
                        {
                            s_TDstyle = " style=\"background:yellow\" ";
                        }
                    }
                    catch
                    { }
                    Sb_Details1.Append("<td class=\"ListHeadDetails\" " + s_TDstyle + "><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Number_" + i.ToString() + "\" value='" + Dts_MainDetails.Tables[0].Rows[i]["OrderAmount"].ToString() + "'></td>");

                    if (this.Tbx_Type.Text == "1")
                    {
                        Sb_Details1.Append("<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"BadNumber_" + i.ToString() + "\" value='0'></td>");
                        Sb_Details1.Append("<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"AddBadNumber_" + i.ToString() + "\" value='0'></td>");

                    }
                    Sb_Details1.Append("<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Price_" + i.ToString() + "\" value='0'></td>");
                    Sb_Details1.Append("<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Money_" + i.ToString() + "\" value='0'></td>");
                    Sb_Details1.Append("<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Remarks_" + i.ToString() + "\" value=''></td>");
                    Sb_Details1.Append("</tr>");
                }
            }
            this.Tbx_Num.Text = Dts_MainDetails.Tables[0].Rows.Count.ToString();
            this.Lbl_Details.Text += Sb_Details1.ToString();
        }
        catch
        { }
    }
    private void ShowOrderInfo(string s_OrderNo)
    {
        //显示明细信息
        try
        {

            Tr_Order.Visible = true;
            StringBuilder Sb_Details2 = new StringBuilder();
            Sb_Details2.Append("<tr valign=\"top\">");
            Sb_Details2.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details2.Append("<b>序号</b>");
            Sb_Details2.Append("</td>");
            Sb_Details2.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details2.Append("<b>订单号</b>");
            Sb_Details2.Append("</td>");
            Sb_Details2.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details2.Append("<b>产品名称</b>");
            Sb_Details2.Append("</td>");
            Sb_Details2.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details2.Append("<b>产品编码</b>");
            Sb_Details2.Append("</td>");
            Sb_Details2.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details2.Append("<b>版本号</b>");
            Sb_Details2.Append("</td>");
            Sb_Details2.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details2.Append("<b>采购数量</b>");
            Sb_Details2.Append("</td>");
            Sb_Details2.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details2.Append("<b>本次调拨数量</b>");
            Sb_Details2.Append("</td>");
            Sb_Details2.Append("</tr>");
            this.Lbl_DetailsMail.Text = Sb_Details2.ToString();
            StringBuilder Sb_Details1 = new StringBuilder();
            this.Tbx_OrderNo.Text = s_OrderNo;
            //
            string s_MainSql = "Select * from v_Knet_Procure_OrdersList_Details_Allocate  a join KNET_Sys_Products b on a.ProductsBarCode=b.ProductsBarCode ";
            if (s_OrderNo != "")
            {
                s_MainSql += " and OrderNo='" + s_OrderNo + "'";
            }
            s_MainSql += " and  DBState<>2 ";
            this.BeginQuery(s_MainSql);
            this.QueryForDataSet();
            DataSet Dts_MainDetails = Dts_Result;

            if (Dts_MainDetails.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_MainDetails.Tables[0].Rows.Count; i++)
                {
                    //显示主的
                    Sb_Details1.Append("<tr>");
                    Sb_Details1.Append("<td class=\"ListHeadDetails\">" + Convert.ToString(i + 1) + "</td>");
                    this.Xs_ProductsCode.Text += Dts_MainDetails.Tables[0].Rows[i]["OrderNo"].ToString() + ",";
                    Sb_Details1.Append("<td class=\"ListHeadDetails\">" + Dts_MainDetails.Tables[0].Rows[i]["OrderNo"].ToString() + "</td>");
                    Sb_Details1.Append("<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName(Dts_MainDetails.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>");
                    Sb_Details1.Append("<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"OrderID_" + i.ToString() + "\" value='" + Dts_MainDetails.Tables[0].Rows[i]["ID"].ToString() + "'><input type=\"hidden\"  Name=\"MainProductsBarCode_" + i.ToString() + "\" value='" + Dts_MainDetails.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "'>" + Dts_MainDetails.Tables[0].Rows[i]["KSP_Code"].ToString() + "</td>");
                    Sb_Details1.Append("<td class=\"ListHeadDetails\">" + Dts_MainDetails.Tables[0].Rows[i]["ProductsEdition"].ToString() + "&nbsp;</td>");
                    Sb_Details1.Append("<td class=\"ListHeadDetails\">" + Dts_MainDetails.Tables[0].Rows[i]["OrderAmount"].ToString() + "</td>");
                    Sb_Details1.Append("<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\';GetNumber()\" style=\"width:70px;\" Name=\"MainNumber_" + i.ToString() + "\" value='" + Dts_MainDetails.Tables[0].Rows[i]["leftNumber"].ToString() + "'></td>");
                    Sb_Details1.Append("</tr>");
                }
                GetDetialsOrder(s_OrderNo);
            }
            else
            {
                AlertAndClose("该订单已全部调拨！");
            }
            this.Tbx_Number1.Text = Dts_MainDetails.Tables[0].Rows.Count.ToString();
            this.Lbl_DetailsMail.Text += Sb_Details1.ToString();
        }
        catch
        { }
    }


    private void GetDetialsOrder2(string s_OrderNo)
    {
        try
        {
            KNet.BLL.Knet_Procure_OrdersList Bll_Order = new KNet.BLL.Knet_Procure_OrdersList();
            KNet.Model.Knet_Procure_OrdersList Model_Order = Bll_Order.GetModelB(s_OrderNo);
            string s_DSql = "Select  XPD_Number,OrderAmount,BomOrder,KSP_Code,ProductsName,ProductsEdition,XPD_ProductsBarCode  as ProductsBarCode,XPD_Number,ProductsType,XPD_ReplaceProductsBarCode,NeedNumber,FaterProductsName,XPD_FaterBarCode as FaterBarCode,KSP_BZNumber,b.* from  v_Order_ProductsDemo_Details a join ";
            s_DSql += " v_Order_ProductsBack_Total b on a.OrderNo=b.v_orderNo ";
            s_DSql += " and a.XPD_ProductsBarCode=b.ProductsBarCode where 1=1  and isnull(totalleftAmount,0)>=0 ";
            if (s_OrderNo != "")
            {
                s_DSql += " and OrderNo='" + s_OrderNo + "'";
            }
            /*
            if (this.Tbx_Type.Text == "")
            {
                if (this.Chk_Type.Checked)
                {
                    s_DSql += " and PBP_Type='1'";
                }
            }
             * */
            s_DSql += " order by KSP_Code ";

            this.BeginQuery(s_DSql);
            this.QueryForDataSet();
            DataSet Dts_Details = Dts_Result;
            //默认调出仓库为士腾
            string s_OutHouseNo = "131187187069993664", s_InHouseNo = "", s_INHouseName = "";
            this.HouseNo_int.SelectedValue = s_OutHouseNo;
            string s_OEMSuppNo = Model_Order.SuppNo;
            try
            {
                KNet.BLL.KNet_Sys_WareHouse bll_WareHouse = new KNet.BLL.KNet_Sys_WareHouse();
                KNet.Model.KNet_Sys_WareHouse Model_WareHouse = bll_WareHouse.GetModelBySuppNo(s_OEMSuppNo);
                //
                s_InHouseNo = Model_WareHouse.HouseNo;
                this.HouseNo_out.SelectedValue = s_InHouseNo;
                s_INHouseName = Model_WareHouse.HouseName;
            }
            catch
            { }
            StringBuilder Sb_Details = new StringBuilder();

            Sb_Details.Append("<tr valign=\"top\">");
            Sb_Details.Append("<td valign=\"top\" class=\"ListHead\" align=\"right\" nowrap>");
            Sb_Details.Append("<b>序号</b>");
            Sb_Details.Append("</td>");
            Sb_Details.Append("<td valign=\"top\" class=\"ListHead\" align=\"right\" nowrap>");
            Sb_Details.Append("<b>工具</b>");
            Sb_Details.Append("</td>");
            Sb_Details.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details.Append("<b>产品名称</b>");
            Sb_Details.Append("</td>");
            Sb_Details.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details.Append("<b>产品编码</b>");
            Sb_Details.Append("</td>");
            Sb_Details.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details.Append("<b>版本号</b>");
            Sb_Details.Append("</td>");
            Sb_Details.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details.Append("<b>上级产品</b>");
            Sb_Details.Append("</td>");
            Sb_Details.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details.Append("<b>调拨数量</b>");
            Sb_Details.Append("</td>");
            Sb_Details.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details.Append("<b>消耗数量</b>");
            Sb_Details.Append("</td>");
            Sb_Details.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details.Append("<b>调回数量</b>");
            Sb_Details.Append("</td>");
            Sb_Details.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details.Append("<b>单价</b>");
            Sb_Details.Append("</td>");
            Sb_Details.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details.Append("<b>金额</b>");
            Sb_Details.Append("</td>");
            Sb_Details.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details.Append("<b>备注</b>");
            Sb_Details.Append("</td>");
            Sb_Details.Append("</tr>");

            if (Dts_Details.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_Details.Tables[0].Rows.Count; i++)
                {
                    Sb_Details.Append("<tr>");
                    this.Xs_ProductsCode.Text += Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + ",";
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + Convert.ToString(i + 1) + "</td>");

                    Sb_Details.Append("<td class=\"ListHeadDetails\"><A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a>" + Convert.ToString(i + 1) + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ProductsBarCode_" + i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "'>" + Dts_Details.Tables[0].Rows[i]["KSP_Code"].ToString() + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"FaterBarCode_" + i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["FaterBarCode"].ToString() + "'>" + Dts_Details.Tables[0].Rows[i]["ProductsEdition"].ToString() + "&nbsp;</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["FaterProductsName"].ToString() + "&nbsp;</td>");


                    string s_BZNumber = Dts_Details.Tables[0].Rows[i]["KSP_BZNumber"].ToString();
                    int s_OrderNumber = int.Parse(Dts_Details.Tables[0].Rows[i]["OrderAmount"].ToString());
                    int s_Number = int.Parse(base.FormatNumber(Dts_Details.Tables[0].Rows[i]["XPD_Number"].ToString(), 0));
                    string s_OrderNum = Convert.ToString(s_Number * s_OrderNumber);
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["DbtotalAmount"].ToString() + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["XhtotalAmount"].ToString() + "</td>");
                    s_OrderNum = Dts_Details.Tables[0].Rows[i]["totalleftAmount"].ToString();

                    Sb_Details.Append("<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"BomNumber_" + i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["XPD_Number"].ToString() + "'><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Number_" + i.ToString() + "\" value='" + s_OrderNum + "'></td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Price_" + i.ToString() + "\" value='0'></td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Money_" + i.ToString() + "\" value='0'></td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Remarks_" + i.ToString() + "\" value=''></td>");
                    Sb_Details.Append("</tr>");
                }
                this.Lbl_Details.Text = Sb_Details.ToString();
                this.Tbx_Num.Text = Dts_Details.Tables[0].Rows.Count.ToString();
            }
        }
        catch
        { }
    }
    private void GetDetialsOrder(string s_OrderNo)
    {
        try
        {

            KNet.BLL.Knet_Procure_OrdersList Bll_Order = new KNet.BLL.Knet_Procure_OrdersList();
            KNet.Model.Knet_Procure_OrdersList Model_Order = Bll_Order.GetModelB(s_OrderNo);
            string s_DSql = "Select  XPD_Number,OrderAmount,BomOrder,KSP_Code,ProductsName,ProductsEdition,XPD_ProductsBarCode  as ProductsBarCode,XPD_Number,ProductsType,XPD_ReplaceProductsBarCode,NeedNumber,FaterProductsName,XPD_FaterBarCode as FaterBarCode,KSP_BZNumber from  v_Order_ProductsDemo_Details where 1=1 ";
            if (s_OrderNo != "")
            {
                s_DSql += " and OrderNo='" + s_OrderNo + "'";
            }
            /*
            if (this.Tbx_Type.Text == "")
            {
                if (this.Chk_Type.Checked)
                {
                    s_DSql += " and PBP_Type='1'";
                }
            }
             * */
            s_DSql += " order by XPD_FaterBarCode,ProductsType ";
            this.BeginQuery(s_DSql);
            this.QueryForDataSet();
            DataSet Dts_Details = Dts_Result;
            //默认调出仓库为士腾
            string s_OutHouseNo = "131187187069993664", s_InHouseNo = "", s_INHouseName = "";
            this.HouseNo_out.SelectedValue = s_OutHouseNo;
            string s_OEMSuppNo = Model_Order.SuppNo;
            try
            {
                KNet.BLL.KNet_Sys_WareHouse bll_WareHouse = new KNet.BLL.KNet_Sys_WareHouse();
                KNet.Model.KNet_Sys_WareHouse Model_WareHouse = bll_WareHouse.GetModelBySuppNo(s_OEMSuppNo);
                //
                s_InHouseNo = Model_WareHouse.HouseNo;
                this.HouseNo_int.SelectedValue = s_InHouseNo;
                s_INHouseName = Model_WareHouse.HouseName;
            }
            catch
            { }
            StringBuilder Sb_Details = new StringBuilder();

            Sb_Details.Append("<tr valign=\"top\">");
            Sb_Details.Append("<td valign=\"top\" class=\"ListHead\" align=\"right\" nowrap>");
            Sb_Details.Append("<b>序号</b>");
            Sb_Details.Append("</td>");
            Sb_Details.Append("<td valign=\"top\" class=\"ListHead\" align=\"right\" nowrap>");
            Sb_Details.Append("<b>工具</b>");
            Sb_Details.Append("</td>");
            Sb_Details.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details.Append("<b>产品名称</b>");
            Sb_Details.Append("</td>");
            Sb_Details.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details.Append("<b>产品编码</b>");
            Sb_Details.Append("</td>");
            Sb_Details.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details.Append("<b>版本号</b>");
            Sb_Details.Append("</td>");
            Sb_Details.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details.Append("<b>上级产品</b>");
            Sb_Details.Append("</td>");
            Sb_Details.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details.Append("<b>杭州士腾</b>");
            Sb_Details.Append("</td>");
            Sb_Details.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details.Append("<b>" + s_INHouseName + "</b>");
            Sb_Details.Append("</td>");

            Sb_Details.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details.Append("<b>BOM配比</b>");
            Sb_Details.Append("</td>");
            Sb_Details.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details.Append("<b>需求数量</b>");
            Sb_Details.Append("</td>");
            Sb_Details.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details.Append("<b>缺料数量</b>");
            Sb_Details.Append("</td>");

            Sb_Details.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details.Append("<b>最小包装数</b>");
            Sb_Details.Append("</td>");
            Sb_Details.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details.Append("<b>调拨包数</b>");
            Sb_Details.Append("</td>");

            Sb_Details.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details.Append("<b>数量</b>");
            Sb_Details.Append("</td>");
            /*
            Sb_Details.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details.Append("<b>单价</b>");
            Sb_Details.Append("</td>");
            Sb_Details.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details.Append("<b>金额</b>");
            Sb_Details.Append("</td>");
             * */
            Sb_Details.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details.Append("<b>备注</b>");
            Sb_Details.Append("</td>");
            Sb_Details.Append("</tr>");

            if (Dts_Details.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_Details.Tables[0].Rows.Count; i++)
                {
                    Sb_Details.Append("<tr>");
                    this.Xs_ProductsCode.Text += Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + ",";
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + Convert.ToString(i + 1) + "</td>");

                    Sb_Details.Append("<td class=\"ListHeadDetails\"><A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a></td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ProductsBarCode_" + i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "'>" + Dts_Details.Tables[0].Rows[i]["KSP_Code"].ToString() + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"FaterBarCode_" + i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["FaterBarCode"].ToString() + "'>" + Dts_Details.Tables[0].Rows[i]["ProductsEdition"].ToString() + "&nbsp;</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["FaterProductsName"].ToString() + "&nbsp;</td>");
                    string s_OutHouseNumber = base.Base_GetWareHouseNumber(s_OutHouseNo, Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString());
                    string s_InHouseNumber = base.Base_GetWareHouseNumber(s_InHouseNo, Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString());
                    Sb_Details.Append("<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"KcNumber_" + i.ToString() + "\" value='" + s_OutHouseNumber + "'>" + s_OutHouseNumber + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + s_InHouseNumber + "</td>");

                    string s_BZNumber = Dts_Details.Tables[0].Rows[i]["KSP_BZNumber"].ToString();
                    int s_OrderNumber = int.Parse(Dts_Details.Tables[0].Rows[i]["OrderAmount"].ToString());
                    int s_Number = int.Parse(base.FormatNumber(Dts_Details.Tables[0].Rows[i]["XPD_Number"].ToString(), 0));
                    string s_OrderNum = Convert.ToString(s_Number * s_OrderNumber);

                    Sb_Details.Append("<td class=\"ListHeadDetails\" width=\"50px\"  >\n");

                    Sb_Details.Append("<input id=\"BomNumber_" + i.ToString() + "\" type=\"hidden\" name=\"BomNumber_" + i.ToString() + "\"  style=\"width:50px\" onblur=\"ChangPrice()\"    value=\"" + Dts_Details.Tables[0].Rows[i]["XPD_Number"].ToString() + "\" />\n" + Dts_Details.Tables[0].Rows[i]["XPD_Number"].ToString());
                    Sb_Details.Append("</td>\n");
                    string s_TDstyle = "";
                    try
                    {
                        if (int.Parse(s_OrderNum) > int.Parse(s_OutHouseNumber))
                        {
                            s_TDstyle = " style=\"background:yellow\" ";
                        }
                    }
                    catch
                    { }
                    Sb_Details.Append("<td class=\"ListHeadDetails\" width=\"50px\" " + s_TDstyle + " >\n");

                    Sb_Details.Append(s_OrderNum);
                    Sb_Details.Append("</td>\n");

                    string s_Sql = "Select isnull(Sum(NeedNumber),0)  from v_NeedNumberStore where ProductsBarCode='" + Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "' and HouseNo='" + s_InHouseNo + "'  ";
                    this.BeginQuery(s_Sql);
                    string s_NeedNumber = this.QueryForReturn();
                    s_NeedNumber = s_NeedNumber == "" ? "0" : s_NeedNumber;
                    s_NeedNumber = Convert.ToString(int.Parse(s_OrderNum) + int.Parse(s_NeedNumber));
                    Sb_Details.Append("<td class=\"ListHeadDetails\">\n");
                    Sb_Details.Append("<a href=\"/Web/Sc/Sc_Plan_QLMaterial.aspx?ProductsBarCode=" + Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "&HouseNo=" + s_InHouseNo + "\" target=\"_blank\">" + s_NeedNumber + "</a>\n");
                    Sb_Details.Append("</td>\n");
                    string s_OrderCPBZNumber = "0", s_OrderBZNumber = "0";
                    //如果是按原材料
                    if (this.Chk_Type.Checked == false)
                    {
                        try
                        {
                            if (s_BZNumber != "0")
                            {

                                s_OrderCPBZNumber = s_BZNumber;
                                int i_NumOder = int.Parse(s_OrderNum) / int.Parse(s_OrderCPBZNumber);
                                if (int.Parse(s_OrderNum) > (int.Parse(s_OrderCPBZNumber) * i_NumOder))
                                {
                                    s_OrderBZNumber = Convert.ToString(int.Parse(s_OrderNum) / int.Parse(s_OrderCPBZNumber) + 1);
                                }
                                else
                                {
                                    s_OrderBZNumber = Convert.ToString(int.Parse(s_OrderNum) / int.Parse(s_OrderCPBZNumber));
                                }

                                s_OrderNum = Convert.ToString(int.Parse(s_OrderBZNumber) * int.Parse(s_OrderCPBZNumber));
                            }
                            else
                            {
                                s_OrderBZNumber = s_BZNumber;
                            }
                        }
                        catch
                        { }
                    }
                    //如果是消耗库存

                    if (this.Chk_KC.Checked == true)
                    {
                        try
                        {
                            if (int.Parse(s_InHouseNumber) < int.Parse(s_OrderNum))
                            {
                                s_OrderNum = Convert.ToString(int.Parse(s_OrderNum) - int.Parse(s_InHouseNumber));
                            }
                            else
                            {
                                s_OrderNum = "0";
                            }

                        }
                        catch
                        { }

                    }
                    Sb_Details.Append("<td class=\"ListHeadDetails\" width=\"50px\"  >\n");

                    Sb_Details.Append("<input id=\"Tbx_CPBZNumber_" + i.ToString() + "\" type=\"input\" name=\"Tbx_CPBZNumber_" + i.ToString() + "\"  style=\"width:50px\" onblur=\"ChangPrice1(" + i.ToString() + ")\"    value=\"" + s_OrderCPBZNumber + "\" />\n");

                    Sb_Details.Append("</td>\n");
                    Sb_Details.Append("<td class=\"ListHeadDetails\" width=\"50px\"  >\n");

                    Sb_Details.Append("<input id=\"Tbx_BZNumber_" + i.ToString() + "\" type=\"input\" name=\"Tbx_BZNumber_" + i.ToString() + "\" onblur=\"ChangPrice1(" + i.ToString() + ")\"  style=\"width:50px\"  value=\"" + s_OrderBZNumber + "\" />\n");

                    Sb_Details.Append("</td>\n");

                    s_TDstyle = "";
                    if (int.Parse(s_OrderNum) > int.Parse(s_OutHouseNumber))
                    {
                        s_TDstyle = " style=\"background:yellow\" ";
                    }
                    Sb_Details.Append("<td class=\"ListHeadDetails\" " + s_TDstyle + "><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Number_" + i.ToString() + "\" value='" + s_OrderNum + "'></td>");

                    Sb_Details.Append("<input type=\"text\" Class=\"Custom_Hidden\" Name=\"Price_" + i.ToString() + "\" value='0'>");
                    Sb_Details.Append("<input type=\"text\" Class=\"Custom_Hidden\" Name=\"Money_" + i.ToString() + "\" value='0'>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Remarks_" + i.ToString() + "\" value=''></td>");
                    Sb_Details.Append("</tr>");
                }
                this.Lbl_Details.Text = Sb_Details.ToString();
                this.Tbx_Num.Text = Dts_Details.Tables[0].Rows.Count.ToString();
            }
        }
        catch
        { }
    }
    private void ShowInfo(string s_ID)
    {
        KNet.BLL.KNet_WareHouse_AllocateList bll = new KNet.BLL.KNet_WareHouse_AllocateList();
        KNet.Model.KNet_WareHouse_AllocateList model = bll.GetModelB(s_ID);


        if ((model.AllocateCheckYN > 0) && (this.Tbx_Type.Text == ""))
        {
            AlertAndGoBack("已审核不能修改");
        }
        else
        {
            this.AllocateNo.Text = model.AllocateNo;
            this.AllocateDateTime.Text = base.DateToString(model.AllocateDateTime.ToString());
            this.HouseNo_int.SelectedValue = model.HouseNo_int;
            this.HouseNo_out.SelectedValue = model.HouseNo;
            this.AllocateCause.Text = model.AllocateCause;
            this.AllocateRemarks.Text = model.AllocateRemarks;
            this.Tbx_OrderNo.Text = model.KWA_OrderNo;

            this.Ddl_Type.SelectedValue = model.KWA_DBType.ToString();
            if (model.KWA_Type == "1")
            {
                this.Chk_Type.Checked = true;
            }
            else
            {
                this.Chk_Type.Checked = false;
            }
            KNet.BLL.KNet_WareHouse_AllocateList_Details BLL_Details = new KNet.BLL.KNet_WareHouse_AllocateList_Details();

            string s_SqlWhere = " a.AllocateNo='" + model.AllocateNo + "' ";

            if (this.Tbx_OrderNo.Text != "")
            {
                s_SqlWhere += " and KWA_OrderNo='" + this.Tbx_OrderNo.Text + "' ";
                // s_SqlWhere += " order by isnull(e.BomOrderDesc,0)";
            }
            DataSet Dts_Details = BLL_Details.GetList(s_SqlWhere);

            if (Dts_Details.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_Details.Tables[0].Rows.Count; i++)
                {
                    s_MyTable_Detail += "<tr>";
                    this.Xs_ProductsCode.Text += Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + ",";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a></td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"FaterBarCode_" + i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["KWAD_FaterBarCode"].ToString() + "'>" + base.Base_GetProductsCode(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ProductsBarCode_" + i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "'>" + base.Base_GetProductsEdition(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";

                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" width=\"50px\"  >\n";

                    s_MyTable_Detail += "<input id=\"Tbx_CPBZNumber_" + i.ToString() + "\" type=\"input\" name=\"Tbx_CPBZNumber_" + i.ToString() + "\"  style=\"width:50px\" onblur=\"ChangPrice1(" + i.ToString() + ")\"    value=\"" + Dts_Details.Tables[0].Rows[i]["KWAD_CPBZNumber"].ToString() + "\" />\n";

                    s_MyTable_Detail += "</td>\n";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" width=\"50px\"  >\n";
                    s_MyTable_Detail += "<input id=\"Tbx_BZNumber_" + i.ToString() + "\" type=\"input\" name=\"Tbx_BZNumber_" + i.ToString() + "\" onblur=\"ChangPrice1(" + i.ToString() + ")\"  style=\"width:50px\"  value=\"" + Dts_Details.Tables[0].Rows[i]["KWAD_BZNumber"].ToString() + "\" />\n";

                    s_MyTable_Detail += "</td>\n";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Number_" + i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["AllocateAmount"].ToString() + "'></td>";

                    s_MyTable_Detail += "<input type=\"text\" Class=\"Custom_Hidden\" Name=\"Price_" + i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["AllocateUnitPrice"].ToString() + "'>";
                    s_MyTable_Detail += "<input type=\"text\" Class=\"Custom_Hidden\" Name=\"Money_" + i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["AllocateTotalNet"].ToString() + "'>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Remarks_" + i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["AllocateRemarks"].ToString() + "'></td>";
                    s_MyTable_Detail += "</tr>";
                }
                this.Lbl_Details.Text += s_MyTable_Detail;
                this.Tbx_Num.Text = Dts_Details.Tables[0].Rows.Count.ToString();
            }

        }


    }

    #region 返回单号情况

    /// <summary>
    /// 返回当前的  单号 （唯一性，如 2009121402）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string KNetOddNumbers()
    {
        return base.GetNewID("KNet_WareHouse_AllocateList", 0);
    }
    /// <summary>
    /// 返回当前的  单号 （唯一性，如 2009121402）
    /// </summary>
    /// <param name="ss"></param>
    /// <returns></returns>
    protected string KNus003(int ss)
    {
        if (ss.ToString().Length == 1)
        {
            return "000" + ss.ToString();
        }
        else if (ss.ToString().Length == 2)
        {
            return "00" + ss.ToString();
        }
        else if (ss.ToString().Length == 3)
        {
            return "0" + ss.ToString();
        }
        else if (ss.ToString().Length == 4)
        {
            return ss.ToString();
        }
        else
        {
            return ss.ToString();
        }
    }
    #endregion

    private bool SetValue(KNet.Model.KNet_WareHouse_AllocateList molel)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            string AllocateNo = "";
            if (this.Tbx_ID.Text != "")
            {
                AllocateNo = this.AllocateNo.Text;
            }
            else
            {
                AllocateNo = base.GetNewID("KNet_WareHouse_AllocateList", 1);
            }
            string AllocateTopic = KNetPage.KHtmlEncode("");
            string AllocateCause = KNetPage.KHtmlEncode(this.AllocateCause.Text.Trim());

            DateTime AllocateDateTime = DateTime.Now;
            try
            {
                AllocateDateTime = DateTime.Parse(this.AllocateDateTime.Text.Trim());
            }
            catch { }

            string HouseNo_out = KNetPage.KHtmlEncode(this.HouseNo_out.SelectedValue);
            string HouseNo_int = KNetPage.KHtmlEncode(this.HouseNo_int.SelectedValue);

            if (HouseNo_out.ToLower() == HouseNo_int.ToLower())
            {
                Response.Write("<script>alert('错误！！\\n\\n调出仓库不能与调入仓库一样！');history.back(-1);</script>");
                Response.End();
            }
            string AllocateStaffBranch = "";
            string AllocateStaffDepart = "";
            string AllocateStaffNo = AM.KNet_StaffNo;
            string AllocateCheckStaffNo = "";
            string AllocateRemarks = KNetPage.KHtmlEncode(this.AllocateRemarks.Text.Trim());


            molel.AllocateNo = AllocateNo;
            molel.AllocateTopic = AllocateTopic;
            molel.AllocateCause = AllocateCause;

            molel.AllocateDateTime = AllocateDateTime;
            molel.HouseNo = HouseNo_out;
            molel.HouseNo_int = HouseNo_int;

            molel.KWA_Type = this.Tbx_Type.Text;
            molel.AllocateStaffBranch = AllocateStaffBranch;
            molel.AllocateStaffDepart = AllocateStaffDepart;

            molel.AllocateStaffNo = AllocateStaffNo;
            molel.AllocateCheckStaffNo = AllocateCheckStaffNo;
            molel.AllocateRemarks = AllocateRemarks;
            molel.AllocateCheckYN = 0;
            molel.AllocateTopic = "102";//维修品调拨
            molel.KWA_OrderNo = this.Tbx_OrderNo.Text;
            molel.KWA_DBType = int.Parse(this.Ddl_Type.SelectedValue);

            ArrayList Arr_Products = new ArrayList();
            for (int i = 0; i < int.Parse(this.Tbx_Num.Text); i++)
            {

                if (Request["ProductsBarCode_" + i.ToString()] != null)
                {
                    string s_ProductsBarCode = Request.Form["ProductsBarCode_" + i.ToString()] == null ? "" : Request.Form["ProductsBarCode_" + i.ToString()].ToString();
                    string s_FaterBarCode = Request.Form["FaterBarCode_" + i.ToString()] == null ? "" : Request.Form["FaterBarCode_" + i.ToString()].ToString();

                    string s_Number = Request.Form["Number_" + i.ToString()] == "" ? "0" : Request.Form["Number_" + i.ToString()].ToString();

                    string s_Price = "0", s_Money = "0";
                    try
                    {
                        s_Price = Request.Form["Price_" + i.ToString()] == "" ? "0" : Request.Form["Price_" + i.ToString()].ToString();
                    }
                    catch
                    { }
                    try
                    {
                        s_Money = Request.Form["Money_" + i.ToString()] == "" ? "0" : Request.Form["Money_" + i.ToString()].ToString();

                    }
                    catch
                    { }
                    if (decimal.Parse(s_Money) != 0)
                    {
                        try
                        {
                            s_Price = Convert.ToString(decimal.Parse(s_Money) / decimal.Parse(s_Number));
                        }
                        catch { }
                    }
                    else
                    {
                        s_Money = Convert.ToString(decimal.Parse(s_Price) * decimal.Parse(s_Number));
                    }
                    string s_CPBZNumber = "0";
                    string s_BZNumber = "0";

                    try
                    {
                        s_CPBZNumber = Request.Form["Tbx_CPBZNumber_" + i.ToString()] == "" ? "0" : Request.Form["Tbx_CPBZNumber_" + i.ToString()].ToString();
                        s_BZNumber = Request.Form["Tbx_BZNumber_" + i.ToString()] == "" ? "0" : Request.Form["Tbx_BZNumber_" + i.ToString()].ToString();

                    }
                    catch
                    { }
                    string s_BadNumber = "0", s_AddBadNumber = "0";

                    try
                    {
                        s_BadNumber = Request.Form["BadNumber_" + i.ToString()] == "" ? "0" : Request.Form["BadNumber_" + i.ToString()].ToString();

                    }
                    catch
                    { }

                    try
                    {
                        s_AddBadNumber = Request.Form["AddBadNumber_" + i.ToString()] == "" ? "0" : Request.Form["AddBadNumber_" + i.ToString()].ToString();

                    }
                    catch
                    { }

                    string s_Remarks = Request.Form["Remarks_" + i.ToString()].ToString();
                    KNet.Model.KNet_WareHouse_AllocateList_Details Model_Details = new KNet.Model.KNet_WareHouse_AllocateList_Details();
                    Model_Details.ID = GetNewID("KNet_WareHouse_AllocateList_Details", 1);
                    Model_Details.ProductsBarCode = s_ProductsBarCode;
                    Model_Details.AllocateNo = molel.AllocateNo;
                    Model_Details.AllocateAmount = int.Parse(s_Number);
                    try
                    {
                        Model_Details.KWAD_CPBZNumber = int.Parse(s_CPBZNumber);
                        Model_Details.KWAD_BZNumber = int.Parse(s_BZNumber);
                    }
                    catch
                    {
                        Model_Details.KWAD_CPBZNumber = 0;
                        Model_Details.KWAD_BZNumber = 0;
                    }
                    Model_Details.AllocateUnitPrice = decimal.Parse(s_Price);
                    Model_Details.AllocateTotalNet = decimal.Parse(s_Money);
                    Model_Details.AllocateRemarks = s_Remarks;
                    Model_Details.KWAD_FaterBarCode = s_FaterBarCode;


                    try
                    {
                        Model_Details.KWAD_BadNumber = int.Parse(s_BadNumber);
                    }
                    catch { Model_Details.KWAD_BadNumber = 0; }
                    try
                    {
                        Model_Details.KWAD_AddBadNumber = int.Parse(s_AddBadNumber);
                    }
                    catch { Model_Details.KWAD_AddBadNumber = 0; }
                    if (decimal.Parse(s_Number) > 0)
                    {
                        Arr_Products.Add(Model_Details);
                        molel.Arr_List = Arr_Products;
                    }

                }
            }


            ArrayList Arr_Products1 = new ArrayList();
            for (int i = 0; i < int.Parse(this.Tbx_Number1.Text); i++)
            {

                if (Request["MainProductsBarCode_" + i.ToString()] != null)
                {
                    string s_MainProductsBarCode = Request.Form["MainProductsBarCode_" + i.ToString()] == null ? "" : Request.Form["MainProductsBarCode_" + i.ToString()].ToString();

                    string s_MainNumber = Request.Form["MainNumber_" + i.ToString()] == "" ? "0" : Request.Form["MainNumber_" + i.ToString()].ToString();
                    string s_OrderID = Request.Form["OrderID_" + i.ToString()] == "" ? "" : Request.Form["OrderID_" + i.ToString()].ToString();

                    KNet.Model.KNet_WareHouse_AllocateList_CPDetails Model_Details1 = new KNet.Model.KNet_WareHouse_AllocateList_CPDetails();
                    Model_Details1.KWAC_ID = GetNewID("KNet_WareHouse_AllocateList_CPDetails", 1);
                    Model_Details1.KWAC_OrderNoID = s_OrderID;
                    Model_Details1.KWAC_AllocateNo = molel.AllocateNo;
                    try
                    {
                        Model_Details1.KWAC_Number = int.Parse(s_MainNumber);
                    }
                    catch
                    {
                        Model_Details1.KWAC_Number = 0;
                    }
                    Model_Details1.KWAC_Creator = AM.KNet_StaffNo;
                    Model_Details1.KWAC_CTime = DateTime.Now;

                    Arr_Products1.Add(Model_Details1);
                    molel.Arr_List1 = Arr_Products1;

                }
            }
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }



    /// <summary>
    /// 确定开收货单
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Btn_SaveOnClick(object sender, EventArgs e)
    {


        AdminloginMess AM = new AdminloginMess();
        KNet.BLL.KNet_WareHouse_AllocateList BLL = new KNet.BLL.KNet_WareHouse_AllocateList();
        KNet.Model.KNet_WareHouse_AllocateList Model = new KNet.Model.KNet_WareHouse_AllocateList();

        string s_ID = this.Tbx_ID.Text;
        AdminloginMess LogAM = new AdminloginMess();
        if (this.SetValue(Model) == false)
        {
            Alert("系统错误！");
            return;
        }
        try
        {
            if (s_ID == "")//新增
            {
                if (BLL.Exists(Model.AllocateNo) == false)
                {
                    BLL.Add(Model);

                    //发送给仓库有新的库间调拨单
                    base.Base_SendMessage(base.Base_GetDeptPerson("供应链平台（物料部/仓库管理）", 0), "有新的库间调拨单需要您审批：<a href='Web/WareHouseAllocateList/KNet_WareHouse_WareCheck_View.aspx?ID=" + Model.AllocateNo + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'></a> 需要您作为负责人选择审批流程，敬请关注！ ");
                    LogAM.Add_Logs("库存管理--->库间调拨--->调拨开单 添加 操作成功！调拨单号：" + Model.AllocateNo);

                    Response.Write("<script>alert('调拨单 添加  操作成功！');location.href='KNet_WareHouse_AllocateList_Manage.aspx';</script>");
                    Response.End();
                }
                else
                {
                    this.Tbx_ID.Text = "";
                    Response.Write("<script>alert('调拨单号已存在 添加失败！');history.back(-1);</script>");
                    Response.End();
                }
            }
            else
            {

                try
                {
                    BLL.Update(Model);
                    LogAM.Add_Logs("库存管理--->库间调拨--->调拨开单 修改 操作成功！调拨单号：" + Model.AllocateNo);
                    AlertAndRedirect("修改成功！", "KNet_WareHouse_AllocateList_Manage.aspx");
                }
                catch (Exception ex) { }
            }


        }
        catch
        {
            Response.Write("<script>alert('调拨单添加失败！');history.back(-1);</script>");
            Response.End();
        }
    }

    protected void Chk_Type_CheckedChanged(object sender, EventArgs e)
    {
        //如果是选中
        if (this.Tbx_Type.Text == "")
        {
            if (this.Tbx_ID.Text != "")
            {
                GetDetialsOrder(this.Tbx_OrderNo.Text);
            }
            else
            {
                ShowOrderInfo(this.Tbx_OrderNo.Text);
            }
        }
    }
}
