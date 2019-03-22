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
using KNet.Model;
using System.Net.Mail;
using NPOI.SS.UserModel;

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
            string KSP_SID = Request.QueryString["KSP_SID"] == null ? "" : Request.QueryString["KSP_SID"].ToString();
            string SubCode = Request.QueryString["SubCode"] == null ? "" : Request.QueryString["SubCode"].ToString();
            string Sumb = Request.QueryString["Sumb"] == null ? "" : Request.QueryString["Sumb"].ToString();
            this.Tbx_Type.Text = s_Type;
            this.Tbx_SuppNo.Text = s_SuppNo;
            this.KSP_SID.Text = KSP_SID;
            this.SubCode.Text = SubCode;
            this.Sumb.Text = Sumb;
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

                    string s_Sql1 =
                        "Select Sum(KSP_isModiy) from KNet_Sys_Products a join Knet_Procure_OrdersList_Details b on a.ProductsBarCode=b.ProductsBarCode";
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
                    string s_DoSql =
                        "Select SUM(DirectInAmount) as Number,ProductsBarCode,KSP_Code from v_Store where HouseNo='" +
                        this.Tbx_SuppNo.Text +
                        "'  and KSP_Code not like '01%' group by ProductsBarCode,KSP_Code having SUM(DirectInAmount)<>0";
                    this.BeginQuery(s_DoSql);
                    DataSet Dts_Details = (DataSet)this.QueryForDataSet();

                    if (Dts_Details.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < Dts_Details.Tables[0].Rows.Count; i++)
                        {
                            s_MyTable_Detail += "<tr>";
                            this.Xs_ProductsCode.Text += Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() +
                                                         ",";
                            s_MyTable_Detail +=
                                "<td class=\"ListHeadDetails\"><A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a></td>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\">" +
                                                base.Base_GetProdutsName(
                                                    Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) +
                                                "</td>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\">" +
                                                base.Base_GetProductsCode(
                                                    Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) +
                                                "</td>";
                            s_MyTable_Detail +=
                                "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ProductsBarCode_" +
                                i.ToString() + "\" value='" +
                                Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "'>" +
                                base.Base_GetProductsEdition(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) +
                                "</td>";

                            s_MyTable_Detail += "<td class=\"ListHeadDetails\" width=\"50px\"  >\n";

                            s_MyTable_Detail += "<input id=\"Tbx_CPBZNumber_" + i.ToString() +
                                                "\" type=\"input\" name=\"Tbx_CPBZNumber_" + i.ToString() +
                                                "\"  style=\"width:50px\" onblur=\"ChangPrice1(" + i.ToString() +
                                                ")\"    value=\"0\" />\n";

                            s_MyTable_Detail += "</td>\n";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\" width=\"50px\"  >\n";
                            s_MyTable_Detail += "<input id=\"Tbx_BZNumber_" + i.ToString() +
                                                "\" type=\"input\" name=\"Tbx_BZNumber_" + i.ToString() +
                                                "\" onblur=\"ChangPrice1(" + i.ToString() +
                                                ")\"  style=\"width:50px\"  value=\"0\" />\n";

                            s_MyTable_Detail += "</td>\n";
                            s_MyTable_Detail +=
                                "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Number_" +
                                i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["Number"].ToString() +
                                "'></td>";

                            s_MyTable_Detail +=
                                "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Remarks_" +
                                i.ToString() + "\" ></td>";
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
                Response.Write(
                    "<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
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




            string s_InHouseNo = "", s_OutHouseNo = "", s_INHouseName = "", s_OutHouseNo3 = "";
            if (this.Tbx_Type.Text == "1")
            {
                s_InHouseNo = "131187187069993664"; //131235104473261008

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
                {
                }
                //
            }
            else if (this.Tbx_Type.Text == "3")
            {
                KNet.BLL.KNet_Sys_WareHouse bll_WareHouse = new KNet.BLL.KNet_Sys_WareHouse();
                KNet.Model.KNet_Sys_WareHouse Model_WareHouse = bll_WareHouse.GetModelBySuppNo(Model_Order.SuppNo);
                s_OutHouseNo3 = Model_WareHouse.HouseNo;
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
            if (this.Tbx_Type.Text == "1")
            {
                Sb_Details1.Append("<td class=\"ListHead\" nowrap>");
                Sb_Details1.Append("<b>未完结数量</b>");
                Sb_Details1.Append("</td>");
                Sb_Details1.Append("<td class=\"ListHead\" nowrap>");
                Sb_Details1.Append("<b>不良未调回</b>");
                Sb_Details1.Append("</td>");
            }

            Sb_Details1.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details1.Append("<b>送货数量</b>");
            Sb_Details1.Append("</td>");
            if (this.Tbx_Type.Text == "1")
            {
                Sb_Details1.Append("<td class=\"ListHead\" nowrap>");
                Sb_Details1.Append("<b>士腾不良品</b>");
                Sb_Details1.Append("</td>");
                Sb_Details1.Append("<td class=\"ListHead\" nowrap>");
                Sb_Details1.Append("<b>加工厂不良品</b>");
                Sb_Details1.Append("</td>");
                Sb_Details1.Append("<td class=\"ListHead\" nowrap>");
                Sb_Details1.Append("<b>实送数量</b>");
                Sb_Details1.Append("</td>");
                Sb_Details1.Append("<td class=\"ListHead\" nowrap>");
                Sb_Details1.Append("<b>报废数量</b>");
                Sb_Details1.Append("</td>");

            }
            if (this.Tbx_Type.Text == "3")
            {
                Sb_Details1.Append("<td class=\"ListHead\" nowrap>");
                Sb_Details1.Append("<b>车间不良数</b>");
                Sb_Details1.Append("</td>");
                Sb_Details1.Append("<td class=\"ListHead\" nowrap>");
                Sb_Details1.Append("<b>本次不良数</b>");
                Sb_Details1.Append("</td>");
                Sb_Details1.Append("<td class=\"ListHead\" nowrap>");
                Sb_Details1.Append("<b>预入库数量</b>");
                Sb_Details1.Append("</td>");
                Sb_Details1.Append("<td class=\"ListHead\" nowrap>");
                Sb_Details1.Append("<b>可调拨数量</b>");
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

            string s_MainSql =
                "Select * from v_Knet_Procure_OrdersList_Details_Allocate  a join KNET_Sys_Products b on a.ProductsBarCode=b.ProductsBarCode ";
            if (s_OrderNo != "")
            {
                s_MainSql += " and OrderNo='" + s_OrderNo + "'";
            }
            if (this.KSP_SID.Text != "")
            {
                s_MainSql +=
                    "and a.ProductsBarCode in (select KPD_Code from Knet_Submitted_Product_Details where KPD_SID='" +
                    this.KSP_SID.Text + "' )";
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
                    Sb_Details1.Append(
                        "<td class=\"ListHeadDetails\"><A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a></td>");
                    Sb_Details1.Append("<td class=\"ListHeadDetails\">" +
                                       base.Base_GetProdutsName(
                                           Dts_MainDetails.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>");
                    Sb_Details1.Append("<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ProductsBarCode_" +
                                       i.ToString() + "\" value='" +
                                       Dts_MainDetails.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "'>" +
                                       Dts_MainDetails.Tables[0].Rows[i]["KSP_Code"].ToString() + "</td>");
                    Sb_Details1.Append("<td class=\"ListHeadDetails\">" +
                                       Dts_MainDetails.Tables[0].Rows[i]["ProductsEdition"].ToString() + "&nbsp;</td>");
                    string s_OutHouseNumber = base.Base_GetWareHouseNumber(s_OutHouseNo,
                        Dts_MainDetails.Tables[0].Rows[i]["ProductsBarCode"].ToString());
                    string s_InHouseNumber = base.Base_GetWareHouseNumber(s_InHouseNo,
                        Dts_MainDetails.Tables[0].Rows[i]["ProductsBarCode"].ToString());
                    Sb_Details1.Append("<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"KcNumber_" +
                                       i.ToString() + "\" value='" + s_OutHouseNumber + "'>" + s_OutHouseNumber +
                                       "</td>");
                    Sb_Details1.Append("<td class=\"ListHeadDetails\">" + s_InHouseNumber + "</td>");
                    if (this.Tbx_Type.Text == "1")
                    {
                        Sb_Details1.Append("<td class=\"ListHeadDetails\">" + Base_GetNotCloseNumber(Dts_MainDetails.Tables[0].Rows[i]["OrderAmount"].ToString(), s_OrderNo, s_OutHouseNo, Dts_MainDetails.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>");
                        Sb_Details1.Append("<td class=\"ListHeadDetails\">" + Base_GetBLHouseNum(s_OrderNo, Dts_MainDetails.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>");
                    }

                    string s_TDstyle = "";
                    try
                    {
                        if (int.Parse(Dts_MainDetails.Tables[0].Rows[i]["OrderAmount"].ToString()) >
                            int.Parse(s_OutHouseNumber))
                        {
                            s_TDstyle = " style=\"background:yellow\" ";
                        }
                    }
                    catch
                    {
                    }
                    string s_MainSql1 = "select * from Knet_Submitted_Product_Details where KPD_SID='" + KSP_SID.Text + "' and KPD_Code='" + Dts_MainDetails.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "' ";

                    this.BeginQuery(s_MainSql1);
                    this.QueryForDataSet();
                    DataSet Dts_MainDetails1 = Dts_Result;
                    if (Sumb.Text == "1" && Tbx_Type.Text == "3")
                    {
                        if (Dts_MainDetails1.Tables[0].Rows[0]["KPD_KDNumber"].ToString() != "0")
                        {
                            Sb_Details1.Append("<td class=\"ListHeadDetails\" " + s_TDstyle +
                                    "><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Number_" +
                                    i.ToString() + "\" value='" +
                                   int.Parse(Dts_MainDetails1.Tables[0].Rows[0]["KPD_KDNumber"].ToString()) + "'></td>"); //应调数量
                        }
                        else
                        {
                            Sb_Details1.Append("<td class=\"ListHeadDetails\" " + s_TDstyle +
                                    "><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Number_" +
                                    i.ToString() + "\" value='" +
                                   (int.Parse(Dts_MainDetails1.Tables[0].Rows[0]["KPD_Number"].ToString()) - int.Parse(Dts_MainDetails1.Tables[0].Rows[0]["KPD_BadNumber"].ToString())).ToString() + "'></td>"); //应调数量
                        }

                    }
                    else if (Sumb.Text == "1" && Tbx_Type.Text == "1")
                    {
                        if (Dts_MainDetails1.Tables[0].Rows[0]["KPD_YNTState"].ToString() == "2")
                        {
                            Sb_Details1.Append("<td class=\"ListHeadDetails\" " + s_TDstyle +
                                     "><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Number_" +
                                     i.ToString() + "\" value='-" +
                                     Dts_MainDetails1.Tables[0].Rows[0]["KPD_Number"].ToString() + "'></td>"); //应调数量
                        }
                        else
                        {
                            Sb_Details1.Append("<td class=\"ListHeadDetails\" " + s_TDstyle +
                                     "><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Number_" +
                                     i.ToString() + "\" value='-" +
                                     Dts_MainDetails1.Tables[0].Rows[0]["KPD_BadNumber"].ToString() + "'></td>"); //应调数量
                        }
                    }
                    else
                    {
                        Sb_Details1.Append("<td class=\"ListHeadDetails\" " + s_TDstyle +
                                     "><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Number_" +
                                     i.ToString() + "\" value='" +
                                     Dts_MainDetails.Tables[0].Rows[i]["OrderAmount"].ToString() + "'></td>"); //应调数量
                    }

                    if (this.Tbx_Type.Text == "1")
                    {
                        Sb_Details1.Append(
                            "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"BadNumber_" +
                            i.ToString() + "\" value='0'></td>");
                        Sb_Details1.Append(
                            "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"AddBadNumber_" +
                            i.ToString() + "\" value='0'></td>");
                        Sb_Details1.Append("<td class=\"ListHeadDetails\" " + s_TDstyle +
                                           "><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"SDNumber_" +
                                           i.ToString() + "\" value='" +
                                           Dts_MainDetails.Tables[0].Rows[i]["OrderAmount"].ToString() + "'></td>");
                        //实调数量
                        Sb_Details1.Append(
                            "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"BFNumber_" +
                            i.ToString() + "\" value='0'></td>"); //报废数量

                    }
                    //Base_GetYRHouseNum(s_OrderNo, Dts_MainDetails.Tables[0].Rows[i]["ProductsBarCode"].ToString())
                    if (this.Tbx_Type.Text == "3")
                    {
                        Sb_Details1.Append(
                     "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" readonly=\"readonly\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\"  value='" + Base_GetBLHouseNum(s_OrderNo, Dts_MainDetails.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "'></td>");//车间报废总数量
                        Sb_Details1.Append(
                      "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"YBFNumber_" +
                      i.ToString() + "\"  value='0'></td>");//报废数量
                        Sb_Details1.Append(
                       "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"YrkNumber_" +
                       i.ToString() + "\" readonly=\"readonly\" value='" + Base_GetYRHouseNum(s_OrderNo, Dts_MainDetails.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "'></td>");//预入库数量
                        Sb_Details1.Append(
                       "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"YrkNumber_" +
                       i.ToString() + "\" readonly=\"readonly\" value='" + Base_GetCanDBNumber(s_OrderNo, s_OutHouseNo3, Dts_MainDetails.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "'></td>");//可调拨数量
                    }

                    Sb_Details1.Append(
                        "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Price_" +
                        i.ToString() + "\" value='0'></td>");
                    Sb_Details1.Append(
                        "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Money_" +
                        i.ToString() + "\" value='0'></td>");
                    Sb_Details1.Append(
                        "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Remarks_" +
                        i.ToString() + "\" value=''></td>");
                    Sb_Details1.Append("</tr>");
                }
            }
            this.Tbx_Num.Text = Dts_MainDetails.Tables[0].Rows.Count.ToString();
            this.Lbl_Details.Text += Sb_Details1.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
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
            string s_MainSql =
                "Select * from v_Knet_Procure_OrdersList_Details_Allocate  a join KNET_Sys_Products b on a.ProductsBarCode=b.ProductsBarCode ";
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
                    Sb_Details1.Append("<td class=\"ListHeadDetails\">" +
                                       Dts_MainDetails.Tables[0].Rows[i]["OrderNo"].ToString() + "</td>");
                    Sb_Details1.Append("<td class=\"ListHeadDetails\">" +
                                       base.Base_GetProdutsName(
                                           Dts_MainDetails.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>");
                    Sb_Details1.Append("<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"OrderID_" +
                                       i.ToString() + "\" value='" + Dts_MainDetails.Tables[0].Rows[i]["ID"].ToString() +
                                       "'><input type=\"hidden\"  Name=\"MainProductsBarCode_" + i.ToString() +
                                       "\" value='" + Dts_MainDetails.Tables[0].Rows[i]["ProductsBarCode"].ToString() +
                                       "'>" + Dts_MainDetails.Tables[0].Rows[i]["KSP_Code"].ToString() + "</td>");
                    Sb_Details1.Append("<td class=\"ListHeadDetails\">" +
                                       Dts_MainDetails.Tables[0].Rows[i]["ProductsEdition"].ToString() + "&nbsp;</td>");
                    Sb_Details1.Append("<td class=\"ListHeadDetails\">" +
                                       Dts_MainDetails.Tables[0].Rows[i]["OrderAmount"].ToString() + "</td>");
                    Sb_Details1.Append(
                        "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\';GetNumber()\" style=\"width:70px;\" Name=\"MainNumber_" +
                        i.ToString() + "\" value='" + Dts_MainDetails.Tables[0].Rows[i]["leftNumber"].ToString() +
                        "'></td>");
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
        {
        }
    }


    private void GetDetialsOrder2(string s_OrderNo)
    {
        try
        {
            KNet.BLL.Knet_Procure_OrdersList Bll_Order = new KNet.BLL.Knet_Procure_OrdersList();
            KNet.Model.Knet_Procure_OrdersList Model_Order = Bll_Order.GetModelB(s_OrderNo);
            string s_DSql =
                "Select  XPD_Number,OrderAmount,BomOrder,KSP_Code,ProductsName,ProductsEdition,XPD_ProductsBarCode  as ProductsBarCode,XPD_Number,ProductsType,XPD_ReplaceProductsBarCode,NeedNumber,FaterProductsName,XPD_FaterBarCode as FaterBarCode,KSP_BZNumber,b.* from  v_Order_ProductsDemo_Details a join ";
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
            {
            }
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

                    Sb_Details.Append(
                        "<td class=\"ListHeadDetails\"><A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a>" +
                        Convert.ToString(i + 1) + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" +
                                      base.Base_GetProdutsName(
                                          Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ProductsBarCode_" +
                                      i.ToString() + "\" value='" +
                                      Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "'>" +
                                      Dts_Details.Tables[0].Rows[i]["KSP_Code"].ToString() + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"FaterBarCode_" +
                                      i.ToString() + "\" value='" +
                                      Dts_Details.Tables[0].Rows[i]["FaterBarCode"].ToString() + "'>" +
                                      Dts_Details.Tables[0].Rows[i]["ProductsEdition"].ToString() + "&nbsp;</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" +
                                      Dts_Details.Tables[0].Rows[i]["FaterProductsName"].ToString() + "&nbsp;</td>");


                    string s_BZNumber = Dts_Details.Tables[0].Rows[i]["KSP_BZNumber"].ToString();
                    int s_OrderNumber = int.Parse(Dts_Details.Tables[0].Rows[i]["OrderAmount"].ToString());
                    int s_Number =
                        int.Parse(base.FormatNumber(Dts_Details.Tables[0].Rows[i]["XPD_Number"].ToString(), 0));
                    string s_OrderNum = Convert.ToString(s_Number * s_OrderNumber);
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" +
                                      Dts_Details.Tables[0].Rows[i]["DbtotalAmount"].ToString() + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" +
                                      Dts_Details.Tables[0].Rows[i]["XhtotalAmount"].ToString() + "</td>");
                    s_OrderNum = Dts_Details.Tables[0].Rows[i]["totalleftAmount"].ToString();

                    Sb_Details.Append("<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"BomNumber_" +
                                      i.ToString() + "\" value='" +
                                      Dts_Details.Tables[0].Rows[i]["XPD_Number"].ToString() +
                                      "'><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Number_" +
                                      i.ToString() + "\" value='" + s_OrderNum + "'></td>");
                    Sb_Details.Append(
                        "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Price_" +
                        i.ToString() + "\" value='0'></td>");
                    Sb_Details.Append(
                        "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Money_" +
                        i.ToString() + "\" value='0'></td>");
                    Sb_Details.Append(
                        "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Remarks_" +
                        i.ToString() + "\" value=''></td>");
                    Sb_Details.Append("</tr>");
                }
                this.Lbl_Details.Text = Sb_Details.ToString();
                this.Tbx_Num.Text = Dts_Details.Tables[0].Rows.Count.ToString();
            }
        }
        catch
        {
        }
    }

    private void GetDetialsOrder(string s_OrderNo)
    {
        try
        {

            KNet.BLL.Knet_Procure_OrdersList Bll_Order = new KNet.BLL.Knet_Procure_OrdersList();
            KNet.Model.Knet_Procure_OrdersList Model_Order = Bll_Order.GetModelB(s_OrderNo);
            string s_DSql =
                "Select  XPD_Number,OrderAmount,BomOrder,KSP_Code,ProductsName,ProductsEdition,XPD_ProductsBarCode  as ProductsBarCode,XPD_Number,ProductsType,XPD_ReplaceProductsBarCode,NeedNumber,FaterProductsName,XPD_FaterBarCode as FaterBarCode,KSP_BZNumber from  v_Order_ProductsDemo_Details where 1=1 ";
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
            {
            }
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

                    Sb_Details.Append(
                        "<td class=\"ListHeadDetails\"><A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a></td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" +
                                      base.Base_GetProdutsName(
                                          Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ProductsBarCode_" +
                                      i.ToString() + "\" value='" +
                                      Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "'>" +
                                      Dts_Details.Tables[0].Rows[i]["KSP_Code"].ToString() + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"FaterBarCode_" +
                                      i.ToString() + "\" value='" +
                                      Dts_Details.Tables[0].Rows[i]["FaterBarCode"].ToString() + "'>" +
                                      Dts_Details.Tables[0].Rows[i]["ProductsEdition"].ToString() + "&nbsp;</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" +
                                      Dts_Details.Tables[0].Rows[i]["FaterProductsName"].ToString() + "&nbsp;</td>");
                    string s_OutHouseNumber = base.Base_GetWareHouseNumber(s_OutHouseNo,
                        Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString());
                    string s_InHouseNumber = base.Base_GetWareHouseNumber(s_InHouseNo,
                        Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString());
                    Sb_Details.Append("<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"KcNumber_" +
                                      i.ToString() + "\" value='" + s_OutHouseNumber + "'>" + s_OutHouseNumber + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + s_InHouseNumber + "</td>");

                    string s_BZNumber = Dts_Details.Tables[0].Rows[i]["KSP_BZNumber"].ToString();
                    int s_OrderNumber = int.Parse(Dts_Details.Tables[0].Rows[i]["OrderAmount"].ToString());
                    int s_Number =
                        int.Parse(base.FormatNumber(Dts_Details.Tables[0].Rows[i]["XPD_Number"].ToString(), 0));
                    string s_OrderNum = Convert.ToString(s_Number * s_OrderNumber);

                    Sb_Details.Append("<td class=\"ListHeadDetails\" width=\"50px\"  >\n");

                    Sb_Details.Append("<input id=\"BomNumber_" + i.ToString() + "\" type=\"hidden\" name=\"BomNumber_" +
                                      i.ToString() + "\"  style=\"width:50px\" onblur=\"ChangPrice()\"    value=\"" +
                                      Dts_Details.Tables[0].Rows[i]["XPD_Number"].ToString() + "\" />\n" +
                                      Dts_Details.Tables[0].Rows[i]["XPD_Number"].ToString());
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
                    {
                    }
                    Sb_Details.Append("<td class=\"ListHeadDetails\" width=\"50px\" " + s_TDstyle + " >\n");

                    Sb_Details.Append(s_OrderNum);
                    Sb_Details.Append("</td>\n");

                    string s_Sql = "Select isnull(Sum(NeedNumber),0)  from v_NeedNumberStore where ProductsBarCode='" +
                                   Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "' and HouseNo='" +
                                   s_InHouseNo + "'  ";
                    this.BeginQuery(s_Sql);
                    string s_NeedNumber = this.QueryForReturn();
                    s_NeedNumber = s_NeedNumber == "" ? "0" : s_NeedNumber;
                    s_NeedNumber = Convert.ToString(int.Parse(s_OrderNum) + int.Parse(s_NeedNumber));
                    Sb_Details.Append("<td class=\"ListHeadDetails\">\n");
                    Sb_Details.Append("<a href=\"/Web/Sc/Sc_Plan_QLMaterial.aspx?ProductsBarCode=" +
                                      Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "&HouseNo=" +
                                      s_InHouseNo + "\" target=\"_blank\">" + s_NeedNumber + "</a>\n");
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
                                    s_OrderBZNumber =
                                        Convert.ToString(int.Parse(s_OrderNum) / int.Parse(s_OrderCPBZNumber) + 1);
                                }
                                else
                                {
                                    s_OrderBZNumber =
                                        Convert.ToString(int.Parse(s_OrderNum) / int.Parse(s_OrderCPBZNumber));
                                }

                                s_OrderNum = Convert.ToString(int.Parse(s_OrderBZNumber) * int.Parse(s_OrderCPBZNumber));
                            }
                            else
                            {
                                s_OrderBZNumber = s_BZNumber;
                            }
                        }
                        catch
                        {
                        }
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
                        {
                        }

                    }
                    Sb_Details.Append("<td class=\"ListHeadDetails\" width=\"50px\"  >\n");

                    Sb_Details.Append("<input id=\"Tbx_CPBZNumber_" + i.ToString() +
                                      "\" type=\"input\" name=\"Tbx_CPBZNumber_" + i.ToString() +
                                      "\"  style=\"width:50px\" onblur=\"ChangPrice1(" + i.ToString() +
                                      ")\"    value=\"" + s_OrderCPBZNumber + "\" />\n");

                    Sb_Details.Append("</td>\n");
                    Sb_Details.Append("<td class=\"ListHeadDetails\" width=\"50px\"  >\n");

                    Sb_Details.Append("<input id=\"Tbx_BZNumber_" + i.ToString() +
                                      "\" type=\"input\" name=\"Tbx_BZNumber_" + i.ToString() +
                                      "\" onblur=\"ChangPrice1(" + i.ToString() + ")\"  style=\"width:50px\"  value=\"" +
                                      s_OrderBZNumber + "\" />\n");

                    Sb_Details.Append("</td>\n");

                    s_TDstyle = "";
                    if (int.Parse(s_OrderNum) > int.Parse(s_OutHouseNumber))
                    {
                        s_TDstyle = " style=\"background:yellow\" ";
                    }
                    Sb_Details.Append("<td class=\"ListHeadDetails\" " + s_TDstyle +
                                      "><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Number_" +
                                      i.ToString() + "\" value='" + s_OrderNum + "'></td>");

                    Sb_Details.Append("<input type=\"text\" Class=\"Custom_Hidden\" Name=\"Price_" + i.ToString() +
                                      "\" value='0'>");
                    Sb_Details.Append("<input type=\"text\" Class=\"Custom_Hidden\" Name=\"Money_" + i.ToString() +
                                      "\" value='0'>");
                    Sb_Details.Append(
                        "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Remarks_" +
                        i.ToString() + "\" value=''></td>");
                    Sb_Details.Append("</tr>");
                }
                this.Lbl_Details.Text = Sb_Details.ToString();
                this.Tbx_Num.Text = Dts_Details.Tables[0].Rows.Count.ToString();
            }
        }
        catch
        {
        }
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
            KNet.BLL.KNet_WareHouse_AllocateList_Details BLL_Details =
                new KNet.BLL.KNet_WareHouse_AllocateList_Details();

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
                    s_MyTable_Detail +=
                        "<td class=\"ListHeadDetails\"><A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a></td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" +
                                        base.Base_GetProdutsName(
                                            Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"FaterBarCode_" +
                                        i.ToString() + "\" value='" +
                                        Dts_Details.Tables[0].Rows[i]["KWAD_FaterBarCode"].ToString() + "'>" +
                                        base.Base_GetProductsCode(
                                            Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail +=
                        "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ProductsBarCode_" + i.ToString() +
                        "\" value='" + Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "'>" +
                        base.Base_GetProductsEdition(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) +
                        "</td>";

                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" width=\"50px\"  >\n";

                    s_MyTable_Detail += "<input id=\"Tbx_CPBZNumber_" + i.ToString() +
                                        "\" type=\"input\" name=\"Tbx_CPBZNumber_" + i.ToString() +
                                        "\"  style=\"width:50px\" onblur=\"ChangPrice1(" + i.ToString() +
                                        ")\"    value=\"" + Dts_Details.Tables[0].Rows[i]["KWAD_CPBZNumber"].ToString() +
                                        "\" />\n";

                    s_MyTable_Detail += "</td>\n";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" width=\"50px\"  >\n";
                    s_MyTable_Detail += "<input id=\"Tbx_BZNumber_" + i.ToString() +
                                        "\" type=\"input\" name=\"Tbx_BZNumber_" + i.ToString() +
                                        "\" onblur=\"ChangPrice1(" + i.ToString() +
                                        ")\"  style=\"width:50px\"  value=\"" +
                                        Dts_Details.Tables[0].Rows[i]["KWAD_BZNumber"].ToString() + "\" />\n";

                    s_MyTable_Detail += "</td>\n";
                    s_MyTable_Detail +=
                        "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Number_" +
                        i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["AllocateAmount"].ToString() +
                        "'></td>";

                    s_MyTable_Detail += "<input type=\"text\" Class=\"Custom_Hidden\" Name=\"Price_" + i.ToString() +
                                        "\" value='" + Dts_Details.Tables[0].Rows[i]["AllocateUnitPrice"].ToString() +
                                        "'>";
                    s_MyTable_Detail += "<input type=\"text\" Class=\"Custom_Hidden\" Name=\"Money_" + i.ToString() +
                                        "\" value='" + Dts_Details.Tables[0].Rows[i]["AllocateTotalNet"].ToString() +
                                        "'>";
                    s_MyTable_Detail +=
                        "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Remarks_" +
                        i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["AllocateRemarks"].ToString() +
                        "'></td>";
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

    private bool FuSetValue(KNet.Model.KNet_WareHouse_FuAllocateList molel, string KSP_SID)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            string AllocateNo = "";

            AllocateNo = "CP" + base.GetNewID("KNet_WareHouse_AllocateList", 1);
            this.TextBox1.Text = AllocateNo;



            string AllocateTopic = KNetPage.KHtmlEncode("");
            string AllocateCause = KNetPage.KHtmlEncode(this.AllocateCause.Text.Trim());

            DateTime AllocateDateTime = DateTime.Now;
            try
            {
                AllocateDateTime = DateTime.Parse(this.AllocateDateTime.Text.Trim());
            }
            catch
            {
            }

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
            if (this.Tbx_Type.Text == "1")
            {
                if (KPS_InvoiceUrl1.Text == "")
                {
                    Response.Write("<script language=javascript>alert('请上传送货单!');history.back(-1);</script>");
                    Response.End();
                }
            }

            molel.KWA_UploadName = KPS_Invoice1.Text;
            molel.KWA_UploadUrl = KPS_InvoiceUrl1.Text;
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
            molel.AllocateTopic = "102"; //维修品调拨
            molel.KWA_OrderNo = this.Tbx_OrderNo.Text;
            molel.KWA_DBType = int.Parse(this.Ddl_Type.SelectedValue);
            molel.KSP_SID = KSP_SID;// this.KSP_SID.Text;
            if (IsEntity.Checked)
            {
                molel.KWA_IsEntity = 1;
            }
            else
            {
                molel.KWA_IsEntity = 0;
            }
            ArrayList Arr_Products = new ArrayList();
            for (int i = 0; i < int.Parse(this.Tbx_Num.Text); i++)
            {

                if (Request["ProductsBarCode_" + i.ToString()] != null)
                {
                    string s_ProductsBarCode = Request.Form["ProductsBarCode_" + i.ToString()] == null
                        ? ""
                        : Request.Form["ProductsBarCode_" + i.ToString()].ToString();
                    string s_FaterBarCode = Request.Form["FaterBarCode_" + i.ToString()] == null
                        ? ""
                        : Request.Form["FaterBarCode_" + i.ToString()].ToString();

                    string s_Number = Request.Form["SDNumber_" + i.ToString()] == ""
                        ? "0"
                        : Request.Form["SDNumber_" + i.ToString()].ToString();

                    string s_Price = "0", s_Money = "0";
                    try
                    {
                        s_Price = Request.Form["Price_" + i.ToString()] == ""
                            ? "0"
                            : Request.Form["Price_" + i.ToString()].ToString();
                    }
                    catch
                    {
                    }
                    try
                    {
                        s_Money = Request.Form["Money_" + i.ToString()] == ""
                            ? "0"
                            : Request.Form["Money_" + i.ToString()].ToString();

                    }
                    catch
                    {
                    }
                    if (decimal.Parse(s_Money) != 0)
                    {
                        try
                        {
                            s_Price = Convert.ToString(decimal.Parse(s_Money) / decimal.Parse(s_Number));
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        s_Money = Convert.ToString(decimal.Parse(s_Price) * decimal.Parse(s_Number));
                    }
                    string s_CPBZNumber = "0";
                    string s_BZNumber = "0";

                    try
                    {
                        s_CPBZNumber = Request.Form["Tbx_CPBZNumber_" + i.ToString()] == ""
                            ? "0"
                            : Request.Form["Tbx_CPBZNumber_" + i.ToString()].ToString();
                        s_BZNumber = Request.Form["Tbx_BZNumber_" + i.ToString()] == ""
                            ? "0"
                            : Request.Form["Tbx_BZNumber_" + i.ToString()].ToString();

                    }
                    catch
                    {
                    }
                    string s_BadNumber = "0", s_AddBadNumber = "0", s_SDNumber = "0", s_BFNumber = "0", s_BLNumber = "0";

                    try
                    {
                        s_BadNumber = Request.Form["BadNumber_" + i.ToString()] == ""
                            ? "0"
                            : Request.Form["BadNumber_" + i.ToString()].ToString();

                    }
                    catch
                    {
                    }

                    try
                    {
                        s_AddBadNumber = Request.Form["AddBadNumber_" + i.ToString()] == ""
                            ? "0"
                            : Request.Form["AddBadNumber_" + i.ToString()].ToString();

                    }
                    catch
                    {
                    }
                    try
                    {
                        s_SDNumber = Request.Form["SDNumber_" + i.ToString()] == ""
                            ? "0"
                            : Request.Form["SDNumber_" + i.ToString()].ToString();

                    }
                    catch
                    {
                    }
                    try
                    {
                        s_BFNumber = Request.Form["BFNumber_" + i.ToString()] == ""
                            ? "0"
                            : Request.Form["BFNumber_" + i.ToString()].ToString();

                    }
                    catch
                    {
                    }
                    try
                    {
                        s_BLNumber = Request.Form["YBFNumber_" + i.ToString()] == ""
                            ? "0"
                            : Request.Form["YBFNumber_" + i.ToString()].ToString();

                    }
                    catch
                    {
                    }
                    string s_Remarks = Request.Form["Remarks_" + i.ToString()].ToString();
                    KNet.Model.KNet_WareHouse_FuAllocateList_Details Model_Details =
                        new KNet.Model.KNet_WareHouse_FuAllocateList_Details();
                    Model_Details.ID = GetNewID("KNet_WareHouse_FuAllocateList_Details", 1);
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
                        Model_Details.KWAD_SDNumber = int.Parse(s_SDNumber);
                    }
                    catch
                    {
                        Model_Details.KWAD_SDNumber = 0;
                    }
                    try
                    {
                        Model_Details.KWAD_BFNumber = int.Parse(s_BFNumber);
                    }
                    catch
                    {
                        Model_Details.KWAD_BFNumber = 0;
                    }

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
                    try
                    {
                        Model_Details.KWAD_BLNumber = int.Parse(s_BLNumber);
                    }
                    catch { Model_Details.KWAD_BLNumber = 0; }
                    if (decimal.Parse(s_Number) != 0)
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
            throw ex;
            return false;
        }
    }

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
                this.TextBox1.Text = AllocateNo;


            }
            string AllocateTopic = KNetPage.KHtmlEncode("");
            string AllocateCause = KNetPage.KHtmlEncode(this.AllocateCause.Text.Trim());

            DateTime AllocateDateTime = DateTime.Now;
            try
            {
                AllocateDateTime = DateTime.Parse(this.AllocateDateTime.Text.Trim());
            }
            catch
            {
            }

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

            if (this.Tbx_Type.Text == "3")
            {
                molel.AllocateNo = "CP" + AllocateNo;
            }
            else
            {
                molel.AllocateNo = AllocateNo;
            }

            molel.AllocateTopic = AllocateTopic;
            molel.AllocateCause = AllocateCause;
            if (this.Tbx_Type.Text == "1" && Sumb.Text == "")
            {
                if (KPS_InvoiceUrl1.Text == "")
                {
                    Response.Write("<script language=javascript>alert('请上传送货单!');history.back(-1);</script>");
                    Response.End();
                }
            }

            molel.KWA_UploadName = KPS_Invoice1.Text;
            molel.KWA_UploadUrl = KPS_InvoiceUrl1.Text;
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
            molel.AllocateTopic = "102"; //维修品调拨
            molel.KWA_OrderNo = this.Tbx_OrderNo.Text;
            molel.KWA_DBType = int.Parse(this.Ddl_Type.SelectedValue);
            if (IsEntity.Checked)
            {
                molel.KWA_IsEntity = 1;
            }
            else
            {
                molel.KWA_IsEntity = 0;
            }
            ArrayList Arr_Products = new ArrayList();
            for (int i = 0; i < int.Parse(this.Tbx_Num.Text); i++)
            {

                if (Request["ProductsBarCode_" + i.ToString()] != null)
                {
                    string s_ProductsBarCode = Request.Form["ProductsBarCode_" + i.ToString()] == null
                        ? ""
                        : Request.Form["ProductsBarCode_" + i.ToString()].ToString();
                    string s_FaterBarCode = Request.Form["FaterBarCode_" + i.ToString()] == null
                        ? ""
                        : Request.Form["FaterBarCode_" + i.ToString()].ToString();

                    string s_Number = Request.Form["Number_" + i.ToString()] == ""
                        ? "0"
                        : Request.Form["Number_" + i.ToString()].ToString();

                    string s_Price = "0", s_Money = "0";
                    try
                    {
                        s_Price = Request.Form["Price_" + i.ToString()] == ""
                            ? "0"
                            : Request.Form["Price_" + i.ToString()].ToString();
                    }
                    catch
                    {
                    }
                    try
                    {
                        s_Money = Request.Form["Money_" + i.ToString()] == ""
                            ? "0"
                            : Request.Form["Money_" + i.ToString()].ToString();

                    }
                    catch
                    {
                    }
                    if (decimal.Parse(s_Money) != 0)
                    {
                        try
                        {
                            s_Price = Convert.ToString(decimal.Parse(s_Money) / decimal.Parse(s_Number));
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        s_Money = Convert.ToString(decimal.Parse(s_Price) * decimal.Parse(s_Number));
                    }
                    string s_CPBZNumber = "0";
                    string s_BZNumber = "0";

                    try
                    {
                        s_CPBZNumber = Request.Form["Tbx_CPBZNumber_" + i.ToString()] == ""
                            ? "0"
                            : Request.Form["Tbx_CPBZNumber_" + i.ToString()].ToString();
                        s_BZNumber = Request.Form["Tbx_BZNumber_" + i.ToString()] == ""
                            ? "0"
                            : Request.Form["Tbx_BZNumber_" + i.ToString()].ToString();

                    }
                    catch
                    {
                    }
                    string s_BadNumber = "0", s_AddBadNumber = "0", s_SDNumber = "0", s_BFNumber = "0";

                    try
                    {
                        s_BadNumber = Request.Form["BadNumber_" + i.ToString()] == ""
                            ? "0"
                            : Request.Form["BadNumber_" + i.ToString()].ToString();

                    }
                    catch
                    {
                    }

                    try
                    {
                        s_AddBadNumber = Request.Form["AddBadNumber_" + i.ToString()] == ""
                            ? "0"
                            : Request.Form["AddBadNumber_" + i.ToString()].ToString();

                    }
                    catch
                    {
                    }
                    try
                    {
                        s_SDNumber = Request.Form["SDNumber_" + i.ToString()] == ""
                            ? "0"
                            : Request.Form["SDNumber_" + i.ToString()].ToString();

                    }
                    catch
                    {
                    }
                    try
                    {
                        s_BFNumber = Request.Form["BFNumber_" + i.ToString()] == ""
                            ? "0"
                            : Request.Form["BFNumber_" + i.ToString()].ToString();

                    }
                    catch
                    {
                    }
                    string s_Remarks = Request.Form["Remarks_" + i.ToString()].ToString();
                    KNet.Model.KNet_WareHouse_AllocateList_Details Model_Details =
                        new KNet.Model.KNet_WareHouse_AllocateList_Details();
                    Model_Details.ID = GetNewID("KNet_WareHouse_FuAllocateList_Details", 1);
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
                        Model_Details.KWAD_SDNumber = int.Parse(s_SDNumber);
                    }
                    catch
                    {
                        Model_Details.KWAD_SDNumber = 0;
                    }
                    try
                    {
                        Model_Details.KWAD_BFNumber = int.Parse(s_BFNumber);
                    }
                    catch
                    {
                        Model_Details.KWAD_BFNumber = 0;
                    }

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
                    if (decimal.Parse(s_Number) != 0)
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
            throw ex;
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
        KNet.BLL.KNet_WareHouse_FuAllocateList BLL = new KNet.BLL.KNet_WareHouse_FuAllocateList();
        KNet.Model.KNet_WareHouse_FuAllocateList Model = new KNet.Model.KNet_WareHouse_FuAllocateList();
        KNet.Model.KNet_WareHouse_DirectOutList model1 = new KNet_WareHouse_DirectOutList();//研发领料
        KNet.BLL.KNet_WareHouse_DirectOutList BLL1 = new KNet.BLL.KNet_WareHouse_DirectOutList();

        KNet.BLL.KNet_WareHouse_AllocateList BLL3 = new KNet.BLL.KNet_WareHouse_AllocateList();
        KNet.Model.KNet_WareHouse_AllocateList Mode2 = new KNet.Model.KNet_WareHouse_AllocateList();

        KNet.BLL.Knet_Submitted_Product BLL_Sum = new KNet.BLL.Knet_Submitted_Product();
        KNet.Model.Knet_Submitted_Product Model_Sum = new KNet.Model.Knet_Submitted_Product();


        KNet.Model.KNet_WareHouse_DirectOutList model2 = new KNet_WareHouse_DirectOutList();//研发领料
        KNet.BLL.KNet_WareHouse_DirectOutList BLL2 = new KNet.BLL.KNet_WareHouse_DirectOutList();
        string s_ID = this.Tbx_ID.Text;
        AdminloginMess LogAM = new AdminloginMess();

        if (this.Tbx_Type.Text == "1")
        {
            if (this.SetValue1(model1) == false)//研发领料
            {
                Alert("系统错误！");
                return;
            }

            if (Sumb.Text != "")
            {
                if (this.SetValue(Mode2) == false)//创建加工厂成品调回
                {
                    Alert("系统错误！");
                    return;
                }
            }
            if (Sumb.Text == "")
            {
                if (this.SetValue2(Model_Sum) == false)//创建送检单
                {
                    Alert("系统错误！");
                    return;
                }
            }
            if (this.FuSetValue(Model, Model_Sum.KSP_SID) == false)//创建一个入库通知
            {
                Alert("系统错误！");
                return;
            }
        }

        else
        {
            if (this.SetValue(Mode2) == false)
            {
                Alert("系统错误！");
                return;
            }
        }
        try
        {
            if (s_ID == "")//新增
            {

                if (this.Tbx_Type.Text == "3")//如果是车间调士腾
                {
                    BLL.Add(Model);
                }


                else if (this.Tbx_Type.Text == "1")//判断是否为加工厂成品调回
                {

                    if (model1.Arr_Details == null)
                    {

                    }
                    else
                    {
                        BLL2.Add(model1);//插入一条研发领料数据
                    }
                    if (Sumb.Text == "")
                    {

                        //BLL3.Add(Mode2);//库间调拨单   
                       
                        if (Model_Sum.Arr_Products!=null)
                        {
                            BLL.Add(Model);//创建入库通知
                            BLL_Sum.Add(Model_Sum);//插入一条送检申请
                            string body = "送检单号为" + this.Tbx_ID.Text + "已经生成,请及时检验，检验后，请及时通知内勤";
                            string email_list = "zxc@systech.com.cn" + "|";//+ "QRA@systech.com.cn" + "|"
                            string File_Path = "";
                            Send("OQC送检通知", body, email_list, File_Path);
                            AM.Add_Logs("送检申请增加" + Model_Sum.KSP_SID);
                        }
                       


                    }
                    else
                    {
                        BLL3.Add(Mode2);//库间调拨单
                    }

                }
                else
                {
                    BLL3.Add(Mode2);//库间调拨单
                }
                if (this.Tbx_Type.Text == "3")
                {
                    //发送给仓库有新的库间调拨单
                    base.Base_SendMessage(base.Base_GetDeptPerson("供应链平台（物料部/仓库管理）", 0), "有新的库间调拨申请单需要您操作入库：<a href='Web/WareHouseAllocateList/KNet_WareHouse_FuWareCheck_View.aspx?ID=" + Model.AllocateNo + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'></a> 需要您作为负责人选择审批流程，敬请关注！ ");
                    LogAM.Add_Logs("库存管理--->库间调拨申请--->调拨开单申请 添加 操作成功！调拨单号：" + Model.AllocateNo);

                    Response.Write("<script>alert('入成品库申请 添加  操作成功！');location.href='KNet_WareHouse_FuAllocateList.aspx';</script>");
                    Response.End();
                }
                else if (this.Tbx_Type.Text == "" && this.Ddl_Type.SelectedValue == "1")
                {
                    //发送给仓库有新的库间调拨单
                    base.Base_SendMessage(base.Base_GetDeptPerson("供应链平台（物料部/仓库管理）", 0), "有新的库间调拨单需要您审核：<a href='Web/WareHouseAllocateList/KNet_WareHouse_WareCheck_View.aspx?ID=" + Model.AllocateNo + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'></a> 需要您作为负责人选择审批流程，敬请关注！ ");
                    LogAM.Add_Logs("库存管理--->库间调拨--->调拨开单 添加 操作成功！调拨单号：" + Model.AllocateNo);
                    Response.Write("<script>alert('调拨单 添加  操作成功！');location.href='KNet_WareHouse_AllocateList_Manage.aspx';</script>");
                    Response.End();
                }
                else
                {
                    //发送给仓库有新的库间调拨单
                    base.Base_SendMessage(base.Base_GetDeptPerson("供应链平台（物料部/仓库管理）", 0), "有新的库间调拨单需要您审核：<a href='Web/WareHouseAllocateList/KNet_WareHouse_WareCheck_View.aspx?ID=" + Model.AllocateNo + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'></a> 需要您作为负责人选择审批流程，敬请关注！ ");
                    LogAM.Add_Logs("库存管理--->库间调拨--->调拨开单 添加 操作成功！调拨单号：" + Model.AllocateNo);
                    Response.Write("<script>alert('调拨单 添加  操作成功！');location.href='KNet_WareHouse_AllocateList_Manage.aspx';</script>");
                    Response.End();
                }


                //}
                //else
                //{
                //    this.Tbx_ID.Text = "";
                //    Response.Write("<script>alert('调拨单号已存在 添加失败！');history.back(-1);</script>");
                //    Response.End();
                //}
            }
            else
            {

                try
                {
                    if (this.Tbx_Type.Text != "3" && this.Tbx_Type.Text != "1")
                    {
                        BLL3.Update(Mode2);
                    }
                    else
                    {
                        BLL.Update(Model);
                    }
                    LogAM.Add_Logs("库存管理--->库间调拨--->调拨开单 修改 操作成功！调拨单号：" + Model.AllocateNo);
                    AlertAndRedirect("修改成功！", "KNet_WareHouse_AllocateList_Manage.aspx");
                }
                catch (Exception ex) { }
            }


        }
        catch (Exception ex)
        {
            throw ex;
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
    /// <summary>
    /// 自动插入一条研发领料
    /// </summary>
    /// <param name="molel"></param>
    /// <returns></returns>
    private bool SetValue1(KNet.Model.KNet_WareHouse_DirectOutList molel)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {

            string DirectInNo = "CK" + base.GetNewID("KNet_WareHouse_DirectOut", 0) + DateTime.Now.Second.ToString();
            this.KWAD_DirectOutNo.Text = DirectInNo;
            string DirectInTopic = KNetPage.KHtmlEncode("");
            //string DirectInSource = KNetPage.KHtmlEncode(this.DirectInSource.Text.Trim());

            DateTime DirectInDateTime = DateTime.Now;
            try
            {
                DirectInDateTime = DateTime.Parse(this.AllocateDateTime.Text.Trim());
            }
            catch { }
            //string SuppNo = KNetPage.KHtmlEncode(this.SuppNoSelectValue.Value);

            string HouseNo = HouseNo_out.SelectedValue;//报废库"131235104473261008"
            string DirectInStaffNo = AM.KNet_StaffNo;

            string DirectInCheckStaffNo = "";
            string DirectInRemarks = "把加工厂调回的不良产品领出，订单号为" + this.Tbx_OrderNo.Text;



            molel.DirectOutNo = DirectInNo;
            molel.DirectOutTopic = DirectInTopic;
            // molel.DirectInSource = DirectInSource;

            molel.DirectOutDateTime = DirectInDateTime;
            molel.KWD_CWOutTime = DirectInDateTime;
            //   molel. = SuppNo;
            molel.HouseNo = HouseNo;

            molel.DirectOutStaffNo = DirectInStaffNo;
            molel.DirectOutCheckStaffNo = DirectInCheckStaffNo;
            molel.DirectOutRemarks = DirectInRemarks;
            molel.KWD_ContentPerson = Request["Ddl_DutyPerson"] == null ? "" : Request["Ddl_DutyPerson"].ToString();
            molel.KWD_Custmoer = "";//客户
            molel.DirectOutCheckYN = 0;
            molel.KWD_Del = "0";
            molel.KWD_ReceTime = DirectInDateTime;
            molel.KWD_MainProductsBarCode = "";
            try
            {
                molel.KWD_MainProductsNumber = 1;
            }
            catch
            { }

            molel.KWD_Type = "102";

            molel.KWD_IsSupp = 0;

            molel.KWD_Project = "7";//用于项目

            molel.KWD_SuppNo = "";//OEM
            molel.KWD_LyType = "4";//默认车间领用
            //molel.KWD_Order = Tbx_OrderNo.Text;
            ArrayList Arr_Products = new ArrayList();
            string pbc = "";//拼接产品编号
            int num = 0;//合计总数量
            for (int i = 0; i <= int.Parse(this.Tbx_Num.Text); i++)
            {
                if (Request["ProductsBarCode_" + i.ToString()] != null && Request.Form["BFNumber_" + i.ToString()].ToString() != "0")
                {
                    string s_ProductsBarCode = Request.Form["ProductsBarCode_" + i.ToString()] == null ? "" : Request.Form["ProductsBarCode_" + i.ToString()].ToString();
                    pbc += "'" + s_ProductsBarCode + "'" + ",";
                    string s_FaterBarCode = Request.Form["FaterBarCode_" + i.ToString()] == null ? "" : Request.Form["FaterBarCode_" + i.ToString()].ToString();
                    string s_Number = Request.Form["BFNumber_" + i.ToString()] == null ? "0" : Request.Form["BFNumber_" + i.ToString()].ToString();
                    num += Convert.ToInt32(s_Number);
                    string s_Price = Request.Form["Price_" + i.ToString()] == null ? "0" : Request.Form["Price_" + i.ToString()].ToString();
                    string s_Money = Request.Form["Money_" + i.ToString()] == null ? "0" : Request.Form["Money_" + i.ToString()].ToString();
                    string s_Remarks = Request.Form["Remarks_" + i.ToString()] == null ? "" : Request.Form["Remarks_" + i.ToString()].ToString();
                    KNet.Model.KNet_WareHouse_DirectOutList_Details Model_Details = new KNet.Model.KNet_WareHouse_DirectOutList_Details();
                    Model_Details.ID = GetNewID("KNet_WareHouse_DirectOutList_Details", 1);
                    Model_Details.ProductsBarCode = s_ProductsBarCode;
                    Model_Details.DirectOutNo = molel.DirectOutNo;
                    Model_Details.DirectOutAmount = int.Parse(s_Number);
                    Model_Details.DirectOutUnitPrice = decimal.Parse(s_Price);
                    Model_Details.DirectOutTotalNet = Convert.ToDecimal(s_Money);
                    Model_Details.KWD_WwPrice = decimal.Parse(s_Price);
                    Model_Details.KWD_WwMoney = Convert.ToDecimal(s_Money);
                    Model_Details.KWD_AllocateNo = this.TextBox1.Text;//把调拨单号插入领料单中
                    Model_Details.DirectOutRemarks = s_Remarks;
                    Arr_Products.Add(Model_Details);
                    molel.Arr_Details = Arr_Products;
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
    /// 创建送检单
    /// </summary>
    /// <param name="molel"></param>
    /// <returns></returns>
    private bool SetValue2(KNet.Model.Knet_Submitted_Product model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            //model.KSP_SID = s_GetCode();
            string s_id = s_GetCode();
            model.KSP_SID = s_id;
            //model. = this.ReceivNo.Text;
            model.KSP_OrderNo = this.Tbx_OrderNo.Text;
            string sql = "select SuppNo from KNet_Sys_WareHouse where HouseNo='" + this.HouseNo_int.SelectedValue + "'";
            this.BeginQuery(sql);
            DataTable Dtb_Table = this.QueryForDataTable();
            model.KSP_HouseNo = Dtb_Table.Rows[0][0].ToString();
            //model.ShipDetials = this.Tbx_ShipDetials.Text;
            model.KSP_Proposer = AM.KNet_StaffNo;
            string sql1 = "select SuppNo from KNet_Sys_WareHouse where HouseNo='" + this.HouseNo_out.SelectedValue + "'";
            this.BeginQuery(sql1);
            DataTable Dtb_Table1 = this.QueryForDataTable();
            model.KSP_SuppNo = Dtb_Table1.Rows[0][0].ToString();

            model.KSP_Time = DateTime.Parse(this.AllocateDateTime.Text);
            model.KSP_Stime = DateTime.Now;
            model.KSP_Boss = 0;
            model.KSP_Rank = 1;
            model.KSP_State = 0;
            model.KSP_Prant = 10;
            model.KSP_Type = 2;
            model.KSP_UploadUrl = "";
            model.KSP_UploadName = "";
            model.KSP_Remark = AllocateRemarks.Text;
            //model.KPO_KDNameCode = this.Drop_KD.SelectedValue;
            //model.KPO_KDName = this.Drop_KD.SelectedItem.Text;
            //model.KPO_KDCode = this.Tbx_Code.Text;
            ArrayList Arr_Products = new ArrayList();
            for (int i = 0; i <= int.Parse(this.Tbx_Num.Text); i++)
            {
                if (Request["ProductsBarCode_" + i.ToString()] != null && int.Parse(Request.Form["SDNumber_" + i.ToString()].ToString()) > 0)
                {
                    KNet.Model.Knet_Submitted_Product_Details Model_Details = new KNet.Model.Knet_Submitted_Product_Details();
                    string s_Number = Request.Form["SDNumber_" + i.ToString()] == ""
                       ? "0"
                       : Request.Form["SDNumber_" + i.ToString()].ToString();
                    string s_ProductsBarCode = Request.Form["ProductsBarCode_" + i.ToString()] == ""
                       ? "0"
                       : Request.Form["ProductsBarCode_" + i.ToString()].ToString();
                    string s_Remarks = Request.Form["Remarks_" + i.ToString()] == null ? "" : Request.Form["Remarks_" + i.ToString()].ToString();
                    Model_Details.KPD_SID = s_id;
                    Model_Details.KPD_OrderNo = this.Tbx_OrderNo.Text;
                    Model_Details.KPD_Code = s_ProductsBarCode;
                    Model_Details.KPD_Number = int.Parse(s_Number);
                    Model_Details.KPD_Brand = s_Remarks;
                    Model_Details.KPD_PTime = DateTime.Now;
                    Arr_Products.Add(Model_Details);
                    model.Arr_Products = Arr_Products;

                }

            }
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    private string s_GetCode()
    {
        string s_Return = "";
        try
        {
            string S_Code = DateTime.Now.ToString("yyyyMMddHHmmss");
            s_Return += "S" + DateTime.Now.ToString("yyyyMMddHH") + "-" + S_Code.Substring(S_Code.Length - 4);

        }
        catch (Exception ex)
        {
            s_Return = "-";
        }
        return s_Return;
    }

    protected void button2_OnServerClick(object sender, EventArgs e)
    {
        //sfsf
        if (!(uploadFile2.PostedFile.ContentLength > 0))
        {
            Alert("您没有选择文件!");
        }
        else
        {
            //string FileType = uploadFile1.PostedFile.ContentType.ToString(); //文件类型
            //GetThumbnailImage1();
            string UploadPath = "../../UpFile/SHUpload/";  //上传路径
                                                           //if (this.CustomerValue.Value != "")
                                                           //{
                                                           //    UploadPath += this.CustomerValue.Value + "/";
                                                           //}
            string AutoPath = System.DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "").Replace("/", "");
            string fileExt = Path.GetExtension(uploadFile2.PostedFile.FileName); //获扩展名
            string FileType = uploadFile2.PostedFile.ContentType.ToString(); //文件类型
            string FileName = Path.GetFileName(uploadFile2.PostedFile.FileName);
            string filePath = UploadPath + AutoPath + fileExt;
            if (!Directory.Exists(Server.MapPath(UploadPath)))
            {
                Directory.CreateDirectory(Server.MapPath(UploadPath));
            }
            uploadFile2.PostedFile.SaveAs(Server.MapPath(filePath)); //上传
            this.Lbl_Details1.Text = "<input Name=\"KPS_InvoiceUrl\"  type=\"hidden\"  value=" + filePath + "><input Name=\"KPS_Invoice\"  type=\"hidden\"  value=" + FileName + "><a href=\"" + filePath + "\" >" + FileName + "</a>";
            this.KPS_InvoiceUrl1.Text = filePath;
            this.KPS_Invoice1.Text = FileName;
        }
    }
    #region 创建送检单，发送邮件
    public static void Send(string subject, string body, string email_list, string File_Path)
    {
        string MailUser = "xjx@systech.com.cn";//我测试的是qq邮箱，其他邮箱一样的道理
        string MailPwd = "systech#88888888";//邮箱密码
        string MailName = "ERP系统";
        string MailHost = "smtp.mxhichina.com";//根据自己选择的邮箱来查询smtp的地址

        MailAddress from = new MailAddress(MailUser, MailName); //邮件的发件人  
        MailMessage mail = new MailMessage();

        //设置邮件的标题  
        mail.Subject = subject;

        //设置邮件的发件人  
        //Pass:如果不想显示自己的邮箱地址，这里可以填符合mail格式的任意名称，真正发mail的用户不在这里设定，这个仅仅只做显示用  
        mail.From = from;

        //设置邮件的收件人  
        string address = "";

        //传入多个邮箱，用“|”分割开，可以自己自定义，再通过mail.To.Add（）添加到列表
        string[] email = email_list.Split('|');
        foreach (string name in email)
        {
            if (name != string.Empty)
            {
                address = name;
                mail.To.Add(new MailAddress(address));
            }
        }

        //设置邮件的抄送收件人  
        //这个就简单多了，如果不想快点下岗重要文件还是CC一份给领导比较好  
        //mail.CC.Add(new MailAddress("Manage@hotmail.com", "尊敬的领导");  

        //设置邮件的内容  
        mail.Body = body;
        //设置邮件的格式  
        mail.BodyEncoding = System.Text.Encoding.UTF8;
        mail.IsBodyHtml = true;
        //设置邮件的发送级别  
        mail.Priority = MailPriority.Normal;

        int a = 0;
        //设置邮件的附件，将在客户端选择的附件先上传到服务器保存一个，然后加入到mail中  你一
        if (File_Path != "")
        {
            mail.Attachments.Add(new Attachment(File_Path));
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
        }
        SmtpClient client = new SmtpClient();
        //设置用于 SMTP 事务的主机的名称，填IP地址也可以了  
        client.Host = MailHost;
        //设置用于 SMTP 事务的端口，默认的是 25  
        client.Port = 587;
        client.UseDefaultCredentials = false;
        //这里才是真正的邮箱登陆名和密码， 我的用户名为 MailUser ，我的密码是 MailPwd  
        client.Credentials = new System.Net.NetworkCredential(MailUser, MailPwd);
        client.DeliveryMethod = SmtpDeliveryMethod.Network;

        ////如果发送失败，SMTP 服务器将发送 失败邮件告诉我  
        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

        //都定义完了，正式发送了，很是简单吧！  
        client.Send(mail);

    }
    #endregion

    //protected void Btn_Create_OnServerClick(object sender, EventArgs e)
    //{
    //    string fileName = FileUpload1.FileName;
    //    //string sheetName = "day";
    //    string filePath = Server.MapPath("/UploadBOMExcel/");
    //    //string tmpRootDir = Server.MapPath(HttpContext.Current.Request.ApplicationPath.ToString());//获取程序根目录
    //    string s_Date = DateTime.Now.ToString("yyMMddhhmmss");
    //    string fileserverurl = (filePath + s_Date + fileName).Replace(filePath, ""); //转换成相对路径
    //    fileserverurl = fileserverurl.Replace(@"\", @"/");
    //    if (File.Exists(fileserverurl))
    //    {
    //        Alert("你已经上传过一次了，不可再次上传");
    //        return;
    //    }
    //    else
    //    {
    //        FileUpload1.SaveAs(filePath + s_Date + fileName);
    //    }

    //    //DataTable dt = ReadExcelToDataTable(filePath + fileName);
    //    string sheetName = null;
    //    bool isFirstRowColumn = true;
    //    string fileurl = filePath + s_Date + fileName;
    //    //定义要返回的datatable对象
    //    DataTable data = new DataTable();
    //    //excel工作表
    //    ISheet sheet = null;
    //    //数据开始行(排除标题行)
    //    int startRow = 0;
    //    try
    //    {
    //        if (!File.Exists(fileurl))
    //        {

    //        }
    //        //根据指定路径读取文件
    //        FileStream fs = new FileStream(fileurl, FileMode.Open, FileAccess.Read);
    //        //根据文件流创建excel数据结构
    //        IWorkbook workbook = WorkbookFactory.Create(fs);
    //        //IWorkbook workbook = new HSSFWorkbook(fs);
    //        //如果有指定工作表名称
    //        if (!string.IsNullOrEmpty(sheetName))
    //        {
    //            sheet = workbook.GetSheet(sheetName);
    //            //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet
    //            if (sheet == null)
    //            {
    //                sheet = workbook.GetSheetAt(0);
    //            }
    //        }
    //        else
    //        {
    //            //如果没有指定的sheetName，则尝试获取第一个sheet
    //            sheet = workbook.GetSheetAt(0);
    //        }
    //        if (sheet != null)
    //        {
    //            IRow firstRow = sheet.GetRow(0);
    //            //一行最后一个cell的编号 即总的列数
    //            int cellCount = firstRow.LastCellNum;
    //            //如果第一行是标题列名
    //            if (isFirstRowColumn)
    //            {
    //                for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
    //                {
    //                    ICell cell = firstRow.GetCell(i);
    //                    if (cell != null)
    //                    {
    //                        string cellValue = cell.StringCellValue;
    //                        if (cellValue != null)
    //                        {
    //                            DataColumn column = new DataColumn(cellValue);
    //                            data.Columns.Add(column);
    //                        }
    //                    }
    //                }
    //                startRow = sheet.FirstRowNum + 1;
    //            }
    //            else
    //            {
    //                startRow = sheet.FirstRowNum;
    //            }
    //            //最后一列的标号
    //            int rowCount = sheet.LastRowNum;
    //            for (int i = startRow; i <= rowCount; ++i)
    //            {
    //                IRow row = sheet.GetRow(i);
    //                if (row == null) continue; //没有数据的行默认是null　　　　　　　

    //                DataRow dataRow = data.NewRow();
    //                for (int j = row.FirstCellNum; j < cellCount; ++j)
    //                {
    //                    if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
    //                        dataRow[j] = row.GetCell(j).ToString();
    //                }
    //                data.Rows.Add(dataRow);
    //            }
    //        }
    //        string s_DemoProductsID = "";//产品编号
    //        string s_DemoProductCode = "";//产品料号
    //        if (data.Rows.Count > 0)
    //        {
    //            //s_ProductsTable_BomDetail = "";
    //            string[] bomlist = new string[data.Rows.Count];

    //            for (int i = 0; i < data.Rows.Count; i++)
    //            {
    //                int a = i + 1;
    //                bomlist[i] = data.Rows[i][2].ToString();
    //                string productbarcode = GetProductByCode(data.Rows[i][2].ToString().Trim());
    //                if (productbarcode == "")
    //                {
    //                    s_DemoProductCode += data.Rows[i][2].ToString() + ",";
    //                }
    //                else
    //                {


    //                        s_DemoProductsID += productbarcode + ",";
    //                        s_MyTable_Detail += "<tr>\n";
    //                        s_MyTable_Detail += "<td class=\"ListHeadDetails\"><A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"/themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a></td>\n";
    //                        s_MyTable_Detail += "<td class='ListHeadDetails'>";
    //                        s_MyTable_Detail += "<input type=\"hidden\"  Name=\"ProductsName_"+i.ToString()+"\" value='"+ data.Rows[i][1].ToString() + "'>"+ data.Rows[i][1].ToString() + "</td>\n";
    //                        s_MyTable_Detail += "<td class='ListHeadDetails'>";
    //                        s_MyTable_Detail += "<input type=\"hidden\"  Name=\"ProductsBarCode_" + i.ToString() + "\" value='" + productbarcode + "'>"+ productbarcode + "</td>\n";
    //                        s_MyTable_Detail += "<td class='ListHeadDetails' width=\"100px\"><input type=\"hidden\"  Name=\"ProductsPattern_" + i.ToString() + "\" value='" + base.Base_GetProductsEdition(productbarcode) + "'></td>\n";
    //                        s_MyTable_Detail += "<td class='ListHeadDetails'><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width: 100px;\" Name=\"Tbx_CPBZNumber_"+i.ToString()+"\" value=\"0\" ></td>\n";

    //                        s_MyTable_Detail += "<td class='ListHeadDetails'><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width: 100px;\" Name=\"Tbx_BZNumber_" + i.ToString() + "\" value=\"0\" ></td>\n";//位号

    //                        s_MyTable_Detail += "<td class='ListHeadDetails'><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width: 100px;\" Name=\"Number_" + i.ToString() + "\" value='"+ data.Rows[i][0].ToString() + "'  ></td>\n";//替换编号

    //                        s_MyTable_Detail += "<td class='ListHeadDetails'><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width: 100px;\"  Name=\"Remarks_" + i.ToString() + "\"  ></td>\n";//数量

    //                        s_MyTable_Detail += "</tr>\n";



    //                }

    //            }
    //            if (s_DemoProductCode.Length > 0)
    //            {
    //                File.Delete(fileserverurl);
    //                s_MyTable_Detail = "";
    //                Alert("料号：" + s_DemoProductCode + "匹配失败，有可能料号非法或者物料停用,料号未审!请检查你上传的EXCEL表！");
    //            }
    //            else
    //            {
    //                bool flag = true;   //假设不重复 
    //                string cfcode = "";//重复的物料
    //                for (int i = 0; i < bomlist.Length - 1; i++)
    //                { //循环开始元素 
    //                    for (int j = i + 1; j < bomlist.Length; j++)
    //                    { //循环后续所有元素 
    //                      //如果相等，则重复 
    //                        if (bomlist[i] == bomlist[j])
    //                        {
    //                            flag = false; //设置标志变量为重复 
    //                            cfcode += bomlist[i];

    //                        }
    //                    }
    //                }
    //                //判断标志变量 
    //                if (flag)
    //                {
    //                    this.Xs_ProductsCode.Text = s_DemoProductsID;
    //                    this.Tbx_Num.Text = data.Rows.Count.ToString();
    //                    //this.truenum.Text = data.Rows.Count.ToString();
    //                }
    //                else
    //                {
    //                    s_MyTable_Detail = "";
    //                    Alert("你上传的EXCEL表中有重复的物料，料号为：" + cfcode);
    //                }
    //            }
    //            this.Lbl_DetailsMail.Text += s_MyTable_Detail.ToString();

    //        }
    //        else
    //        {
    //            File.Delete(fileserverurl);
    //            s_MyTable_Detail = "";
    //            Alert("EXCEL表格内容不能为空");
    //        }


    //    }
    //    catch (Exception ex)
    //    {

    //        throw ex;
    //    }
    //}
    //public string GetProductByCode(string code)
    //{
    //    string sql = "select * from KNet_Sys_Products where KSP_COde='" + code + "'";
    //    DataTable rownum = DbHelperSQL.ExecuteDataSet(CommandType.Text, sql).Tables[0];
    //    if (rownum.Rows.Count > 0)
    //    {
    //        return rownum.Rows[0]["ProductsBarCode"].ToString();
    //    }
    //    else
    //    {
    //        return "";
    //    }

    //}
}
