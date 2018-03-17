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
using System.IO;
using System.Text;
using System.Data.SqlClient;

using KNet.DBUtility;
using KNet.Common;

public partial class Web_Report_Xs_List_KCList : BasePage
{
    public string s_Details = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            string s_Paper = Request.QueryString["Paper"] == null ? "" : Request.QueryString["Paper"].ToString();
            this.Tbx_Paper.Text = s_Paper;
            //原材料入库
            if (s_Paper != "")
            {
                if (s_Paper == "0")
                {

                    s_Details = "当前纸张选择：<font color=red>小纸</font>";
                }
                else
                {

                    s_Details = "当前纸张选择：<font color=red>大纸</font>";
                }
            }
            s_Details += GetMaterInDetials();
            this.Tbx_ID.Text += "|";
            //生产入库
            //生产领用单
            //材料入库单
            //材料出库单
            s_Details += GetSCDetials();
            this.Tbx_ID.Text += "|";
            //领料单
            s_Details += GetRCDetials();
            this.Tbx_ID.Text += "|";
            //部门领用单,销售出库领用
            s_Details += GetMaterLlDetials();
            this.Tbx_ID.Text += "|";
            //原材料调拨单
            s_Details += GetMaterDBDetials();
        }

    }
    //原材料入库
    private string GetMaterInDetials()
    {
        StringBuilder Sb_Details = new StringBuilder();
        string s_ID = "";
        try
        {
            string s_Sql = "Select a.WareHouseNo,Count(*) row ";
            s_Sql += " from KNet_Procure_WareHouseList  a  join Knet_Procure_WareHouseList_Details b on a.WareHouseNo=b.WareHouseNo ";
            s_Sql += "  join Knet_Procure_OrdersList c on a.OrderNo=c.OrderNo left join Knet_Procure_OrdersList_details d on d.ProductsBarCode=b.ProductsBarCode and a.OrderNO=d.OrderNo join KNet_Sys_Products e on e.ProductsBarCode=b.ProductsBarCode  ";
            s_Sql += "  Where a.KPW_Del='0' and KPO_QRState=1 ";

            string s_StartDate = Request.QueryString["StartDate"] == null ? "" : Request.QueryString["StartDate"].ToString();
            string s_EndDate = Request.QueryString["EndDate"] == null ? "" : Request.QueryString["EndDate"].ToString();
            string s_HouseNo = Request.QueryString["HouseNo"] == null ? "" : Request.QueryString["HouseNo"].ToString();
            string s_ProductsName = Request.QueryString["ProductsName"] == null ? "" : Request.QueryString["ProductsName"].ToString();
            string s_ProductsEdition = Request.QueryString["ProductsEdition"] == null ? "" : Request.QueryString["ProductsEdition"].ToString();
            string s_ProductsType = Request.QueryString["ProductsType"] == null ? "" : Request.QueryString["ProductsType"].ToString();
            string s_State = Request.QueryString["State"] == null ? "" : Request.QueryString["State"].ToString();

            if (s_StartDate != "")
            {
                s_Sql += " and  a.WareHouseDateTime>='" + s_StartDate + "'";
            }
            if (s_EndDate != "")
            {
                s_Sql += " and  a.WareHouseDateTime<='" + s_EndDate + "'";
            }
            if (s_HouseNo != "")
            {
                s_Sql += " and  a.HouseNo='" + s_HouseNo + "'";
            }
            if (s_ProductsType != "")
            {
                KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
                string s_SonID = Bll_ProductsDetails.GetSonIDs(s_ProductsType);
                s_SonID = s_SonID.Replace(",", "','");
                s_Sql += " and ProductsType in ('" + s_SonID + "') ";
            }
            if (s_ProductsEdition != "")
            {
                s_Sql += "  e.ProductsEdition like '%" + s_ProductsEdition + "%' ";
            }
            if (s_State != "")
            {
                if (s_State == "0")
                {
                    s_Sql += " and KPW_PrintNums='0' ";
                }
                else
                {
                    s_Sql += " and KPW_PrintNums<>'0' ";
                }
            }
            s_Sql += " Group by a.WareHouseNo order by a.WareHouseNo  ";

            AdminloginMess Am = new AdminloginMess();
            string s_Preson = "制表人:" + Am.KNet_StaffName;
            string s_Time = "日期:" + s_StartDate + " 到 " + s_EndDate;
            Sb_Details.Append("<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\"> \n");
            Sb_Details.Append("<tr>\n<th colspan=\"8\" class=\"MaterTitle\" style='height:14.25pt'>杭州士腾科技有限公司<br/>仓库单据打印</th></tr>\n");
            Sb_Details.Append("<tr>\n<th colspan=\"8\" style='height:11.25pt' align=left >1.采购入库单</th></tr>\n");
            Sb_Details.Append("<tr>\n<th colspan=\"4\" class=\"thstyleleft\"  >" + s_Time + "</th><th colspan=\"4\" class=\"thstyleRight\" >" + s_Preson + "</th></tr>\n");
            Sb_Details.Append("<tr >\n<th class=\"thstyle\">序号</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">单号</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">日期</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">仓库</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">产品</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">编码</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">版本号</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">数量</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">单价</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">金额</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">打印</th>\n");
            Sb_Details.Append("</tr></thead><tbody class=\"scrollContent\">");

            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table1 = this.Dtb_Result;
            if (Dtb_Table1.Rows.Count > 0)
            {
                for (int j = 0; j < Dtb_Table1.Rows.Count; j++)
                {

                    s_Sql = "Select a.HouseNo,a.SuppNo,c.OrderType,a.WareHouseDateTime,b.ProductsBarCode,d.OrderAmount,b.WareHouseAmount,b.WareHousebAmount,a.WareHouseRemarks,a.WareHouseNo,c.OrderNo,a.HouseNo,d.HandPrice,d.OrderUnitPrice,(Isnull(d.HandPrice,0)+d.OrderUnitPrice)*b.WareHouseAmount,e.KSP_Code,KPW_PrintNums,a.ID ";
                    s_Sql += " from KNet_Procure_WareHouseList  a  join Knet_Procure_WareHouseList_Details b on a.WareHouseNo=b.WareHouseNo ";
                    s_Sql += "  join Knet_Procure_OrdersList c on a.OrderNo=c.OrderNo left join Knet_Procure_OrdersList_details d on d.ProductsBarCode=b.ProductsBarCode and a.OrderNO=d.OrderNo join KNet_Sys_Products e on e.ProductsBarCode=b.ProductsBarCode  ";
                    s_Sql += "  Where a.KPW_Del='0' and KPO_QRState=1 ";
                    s_Sql += "  and a.WareHouseNo='" + Dtb_Table1.Rows[j]["WareHouseNo"].ToString() + "' ";

                    //采购入库

                    if ((s_StartDate == "") && (s_EndDate == ""))
                    {
                        s_Time = "";

                    }
                    string s_Style = "";
                    StringBuilder s_Head = new StringBuilder();
                    Decimal DTotalNum = 0, DTotalNet = 0;
                    s_Sql += " Order by KSP_Code ";

                    this.BeginQuery(s_Sql);
                    this.QueryForDataTable();
                    DataTable Dtb_Table = this.Dtb_Result;
                    if (Dtb_Table.Rows.Count > 0)
                    {
                        for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                        {
                            if (j % 2 == 0)
                            {
                                s_Style = "class='gg'";
                            }
                            else
                            {
                                s_Style = "class='rr'";
                            }
                            string s_Row = Dtb_Table1.Rows[j]["row"].ToString();
                            if ((s_Row == "1") || (i == 0))
                            {
                                Sb_Details.Append(" <tr " + s_Style + " onmouseover='setActiveBG(this)'>\n");
                                Sb_Details.Append("<td class='thstyleLeftDetails'align=center noWrap rowspan=\"" + s_Row + "\">" + (j + 1).ToString() + "</td>\n");
                                Sb_Details.Append("<td  class='thstyleLeftDetails' align=left  noWrap rowspan=\"" + s_Row + "\">&nbsp;" + Dtb_Table.Rows[i][9].ToString() + "</td>\n");
                                try
                                {
                                    Sb_Details.Append("<td  class='thstyleLeftDetails'align=left noWrap rowspan=\"" + s_Row + "\">" + DateTime.Parse(Dtb_Table.Rows[i][3].ToString()).ToShortDateString() + "</td>\n");
                                }
                                catch
                                {
                                    Sb_Details.Append("<td class='thstyleLeftDetails' align=center noWrap rowspan=\"" + s_Row + "\">&nbsp;</td>\n");
                                }
                            }
                            else
                            {
                                Sb_Details.Append(" <tr " + s_Style + " onmouseover='setActiveBG(this)'>\n");
                            }
                           
                            Sb_Details.Append("<td class='thstyleLeftDetails'align=left noWrap>" + base.Base_GetHouseName(Dtb_Table.Rows[i][11].ToString()) + "</td>\n");
                            Sb_Details.Append("<td class='thstyleLeftDetails'align=center noWrap>" + base.Base_GetProdutsName(Dtb_Table.Rows[i][4].ToString()) + "</td>\n");

                            Sb_Details.Append("<td  class='thstyleLeftDetails'align=center noWrap>" + Dtb_Table.Rows[i]["KSP_Code"].ToString() + "</td>\n");
                            Sb_Details.Append("<td  class='thstyleLeftDetails'align=left noWrap>" + base.Base_GetProductsEdition(Dtb_Table.Rows[i][4].ToString()) + "</td>\n");

                            Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(Dtb_Table.Rows[i][6].ToString(), 0) + "</td>\n");
                            Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(Dtb_Table.Rows[i][13].ToString(), 3) + "</td>\n");
                            Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(Dtb_Table.Rows[i][14].ToString(), 3) + "</td>\n");

                            if ((s_Row == "1") || (i == 0))
                            {
                                Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap rowspan="+s_Row+"><a href=\"#\"  onclick=\"GPrint('" + Dtb_Table.Rows[i]["ID"].ToString() + "')\"><Image ID=\"Image4\" src=\"../../../images/Print1.gif\" border=0   /></a>(" + Dtb_Table.Rows[i]["KPW_PrintNums"].ToString() + ")</td>\n");

                                Sb_Details.Append(" </tr>");
                                s_ID += Dtb_Table.Rows[i]["ID"].ToString() + ",";
                            }
                        }
                    }
                }

                Sb_Details.Append("</tbody></table>");
                this.Tbx_ID.Text += s_ID;
            }

        }
        catch { }
        return Sb_Details.ToString();

    }
    //生产入库
    //生产领用单
    //材料入库单
    //材料出库单
    private string GetSCDetials()
    {
        string s_ID = "";
        string s_ID1 = "";
        StringBuilder Sb_Details = new StringBuilder();
        try
        {
            string s_Sql = "Select a.SER_HouseNo,c.SuppNo,c.OrderType,b.SEM_STime,d.ProductsBarCode,d.OrderAmount,a.SER_scNumber,0,b.SEM_Remarks,b.SEM_ID,c.OrderNo,a.SER_HouseNo,0,a.SER_ScPrice,a.SER_ScMoney,isnull(d.OrderUnitPrice,0) as OrderMoney,isnull(d.HandPrice,0) as HandMoney,isnull(d.OrderUnitPrice,0)*SER_scNumber+isnull(d.HandPrice,0)*SER_scNumber as TotalMoney,SEM_RCPrintNums,SEM_ID,SEM_MaterPrintNums,SEM_MaterPrintNums1,SEM_MaterPrintNums2 ";
            s_Sql += " from Sc_Expend_Manage_RCDetails a join Sc_Expend_Manage b on a.SER_SEMID=b.SEM_ID   ";
            s_Sql += " left join Knet_Procure_OrdersList_details d on d.ID=a.SER_ORderDetailID ";
            s_Sql += "  join Knet_Procure_OrdersList c on d.OrderNo=c.OrderNo join KNet_Sys_Products e on e.ProductsBarCode=d.ProductsBarCode  ";
            s_Sql += "  Where 1=1 ";


            string s_StartDate = Request.QueryString["StartDate"] == null ? "" : Request.QueryString["StartDate"].ToString();
            string s_EndDate = Request.QueryString["EndDate"] == null ? "" : Request.QueryString["EndDate"].ToString();
            string s_HouseNo = Request.QueryString["HouseNo"] == null ? "" : Request.QueryString["HouseNo"].ToString();
            string s_ProductsName = Request.QueryString["ProductsName"] == null ? "" : Request.QueryString["ProductsName"].ToString();
            string s_ProductsEdition = Request.QueryString["ProductsEdition"] == null ? "" : Request.QueryString["ProductsEdition"].ToString();
            string s_ProductsType = Request.QueryString["ProductsType"] == null ? "" : Request.QueryString["ProductsType"].ToString();
            string s_State = Request.QueryString["State"] == null ? "" : Request.QueryString["State"].ToString();

            //生产入库

            string s_Time = "日期:" + s_StartDate + " 到 " + s_EndDate;
            if ((s_StartDate == "") && (s_EndDate == ""))
            {
                s_Time = "";

            }
            AdminloginMess Am = new AdminloginMess();
            string s_Preson = "制表人:" + Am.KNet_StaffName;
            Sb_Details.Append("<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\"> \n");
            Sb_Details.Append("<tr>\n<th colspan=\"11\" style='height:11.25pt' align=left >2.生产入库单，生产耗料单，材料入库单，材料出库单</th></tr>\n");
            Sb_Details.Append("<tr >\n<th class=\"thstyle\">序号</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">单号</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">日期</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">仓库</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">产品</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">编码</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">版本号</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">数量</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">单价</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">加工费</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">金额</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">入库单<br>打印</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">耗料单<br>打印</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">材料<br>入库单<br>打印</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">材料<br>出库单<br>打印</th>\n");
            Sb_Details.Append("</tr></thead><tbody class=\"scrollContent\">");

            string s_Style = "";
            StringBuilder s_Head = new StringBuilder();
            Decimal DTotalNum = 0, DTotalNet = 0;

            if (s_StartDate != "")
            {
                s_Sql += " and  b.SEM_STime>='" + s_StartDate + "'";
            }
            if (s_EndDate != "")
            {
                s_Sql += " and  b.SEM_STime<='" + s_EndDate + "'";
            }
            if (s_HouseNo != "")
            {
                s_Sql += " and  a.SER_HouseNo='" + s_HouseNo + "'";
            }
            if (s_ProductsType != "")
            {
                KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
                string s_SonID = Bll_ProductsDetails.GetSonIDs(s_ProductsType);
                s_SonID = s_SonID.Replace(",", "','");
                s_Sql += " and ProductsType in ('" + s_SonID + "') ";
            }
            if (s_ProductsEdition != "")
            {
                s_Sql += "  e.ProductsEdition like '%" + s_ProductsEdition + "%' ";
            }
            string s_Paper = Request.QueryString["Paper"] == null ? "" : Request.QueryString["Paper"].ToString();

            if (s_Paper != "")
            {
                if (s_Paper == "0")
                {
                    s_Sql += " and SEM_RCPrintNums='0' ";
                }
                else if (s_Paper == "1")
                {
                    s_Sql += " and (SEM_MaterPrintNums='0' or ((SEM_MaterPrintNums1='0' or SEM_MaterPrintNums2='0') and SER_ScPrice>0))  ";
                }
            }
            s_Sql += " Order by b.SEM_STime ";

            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        s_Style = "class='gg'";
                    }
                    else
                    {
                        s_Style = "class='rr'";
                    }
                    Sb_Details.Append(" <tr " + s_Style + " onmouseover='setActiveBG(this)'>\n");
                    Sb_Details.Append("<td class='thstyleLeftDetails'align=center noWrap>" + (i + 1).ToString() + "</td>\n");
                    Sb_Details.Append("<td  class='thstyleLeftDetails' align=left  noWrap>&nbsp;" + Dtb_Table.Rows[i][9].ToString() + "</td>\n");

                    try
                    {
                        Sb_Details.Append("<td  class='thstyleLeftDetails'align=left noWrap>" + DateTime.Parse(Dtb_Table.Rows[i][3].ToString()).ToShortDateString() + "</td>\n");
                    }
                    catch
                    {
                        Sb_Details.Append("<td class='thstyleLeftDetails' align=center noWrap>&nbsp;</td>\n");
                    }


                    Sb_Details.Append("<td class='thstyleLeftDetails' >" + base.Base_GetHouseName(Dtb_Table.Rows[i][11].ToString()) + "</td>\n");
                    Sb_Details.Append("<td class='thstyleLeftDetails' >" + base.Base_GetProdutsName(Dtb_Table.Rows[i][4].ToString()) + "</td>\n");
                    Sb_Details.Append("<td class='thstyleLeftDetails' >" + base.Base_GetProductsCode(Dtb_Table.Rows[i][4].ToString()) + "</td>\n");
                    Sb_Details.Append("<td  class='thstyleLeftDetails'align=left >" + base.Base_GetProductsEdition(Dtb_Table.Rows[i][4].ToString()) + "</td>\n");

                    Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  >" + base.FormatNumber1(Dtb_Table.Rows[i][6].ToString(), 0) + "</td>\n");
                    Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  >" + base.FormatNumber1(Dtb_Table.Rows[i]["OrderMoney"].ToString(), 2) + "</td>\n");
                    Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  >" + base.FormatNumber1(Dtb_Table.Rows[i]["HandMoney"].ToString(), 2) + "</td>\n");
                    Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  >" + base.FormatNumber1(Dtb_Table.Rows[i]["TotalMoney"].ToString(), 2) + "</td>\n");

                    Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap><a href=\"#\"  onclick=\"GPrintSc('" + Dtb_Table.Rows[i]["SEM_ID"].ToString() + "')\"><Image ID=\"Image4\" src=\"../../../images/Print1.gif\" border=0   /></a>(" + Dtb_Table.Rows[i]["SEM_RCPrintNums"].ToString() + ")</td>\n");

                    Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap><a href=\"#\"  onclick=\"HPrint('" + Dtb_Table.Rows[i]["SEM_ID"].ToString() + "')\"><Image ID=\"Image4\" src=\"../../../images/Print1.gif\" border=0   /></a>(" + Dtb_Table.Rows[i]["SEM_MaterPrintNums"].ToString() + ")</td>\n");
                    if (decimal.Parse(Dtb_Table.Rows[i]["SER_ScPrice"].ToString()) > 0)
                    {

                        Sb_Details.Append("<td  class='thstyleLeftDetails' align=left  noWrap><a href=\"#\"  onclick=\"QTGPrint('" + Dtb_Table.Rows[i]["SEM_ID"].ToString() + "')\"><Image ID=\"Image4\" src=\"../../../images/Print1.gif\" border=0   /></a>(" + Dtb_Table.Rows[i]["SEM_MaterPrintNums1"].ToString() + ")</td>\n");
                        Sb_Details.Append("<td  class='thstyleLeftDetails' align=left  noWrap><a href=\"#\"  onclick=\"QTHPrint('" + Dtb_Table.Rows[i]["SEM_ID"].ToString() + "')\"><Image ID=\"Image4\" src=\"../../../images/Print1.gif\" border=0   /></a>(" + Dtb_Table.Rows[i]["SEM_MaterPrintNums2"].ToString() + ")</td>\n");
                        s_ID1 += Dtb_Table.Rows[i]["SEM_ID"].ToString() + ",";
                    }
                    else
                    {
                        Sb_Details.Append("<td  class='thstyleLeftDetails' align=left  noWrap colspan=2>&nbsp;</td>\n");
                    }
                    Sb_Details.Append(" </tr>");
                    s_ID += Dtb_Table.Rows[i]["SEM_ID"].ToString() + ",";
                }
                this.Tbx_ID.Text += s_ID;
                this.Tbx_ID1.Text = s_ID + "|" + s_ID1;
            }

            Sb_Details.Append("</tbody></table>");
        }
        catch { }
        return Sb_Details.ToString();
    }
    //成品领料单
    private string GetRCDetials()
    {
        string s_ID = "";
        StringBuilder Sb_Details = new StringBuilder();
        try
        {
            string s_Sql = "Select a.DirectOutNo,a.KWD_CWOutTime,a.HouseNo,a.KWD_Custmoer,e.ProductsName,a.ProductsPattern,e.ProductsEdition,a.DirectOutAmount,a.KWD_SalesUnitPrice,";
            s_Sql += " a.DiretOutMoney,a.DirectOutStaffNo,a.DirectOutCheckStaffNo,a.ProductsBarCode,a.ID, a.KWD_BNumber,a.KWD_BPrintNums,e.KSP_COde from v_RCOutList a ";
            s_Sql += " join KNet_Sys_Products e on e.ProductsBarCode=a.ProductsBarCode ";
            s_Sql += " Where 1=1  and e.KSP_Code like '01%'";


            string s_StartDate = Request.QueryString["StartDate"] == null ? "" : Request.QueryString["StartDate"].ToString();
            string s_EndDate = Request.QueryString["EndDate"] == null ? "" : Request.QueryString["EndDate"].ToString();
            string s_HouseNo = Request.QueryString["HouseNo"] == null ? "" : Request.QueryString["HouseNo"].ToString();
            string s_ProductsName = Request.QueryString["ProductsName"] == null ? "" : Request.QueryString["ProductsName"].ToString();
            string s_ProductsEdition = Request.QueryString["ProductsEdition"] == null ? "" : Request.QueryString["ProductsEdition"].ToString();
            string s_ProductsType = Request.QueryString["ProductsType"] == null ? "" : Request.QueryString["ProductsType"].ToString();
            string s_State = Request.QueryString["State"] == null ? "" : Request.QueryString["State"].ToString();


            string s_Time = "日期:" + s_StartDate + " 到 " + s_EndDate;
            if ((s_StartDate == "") && (s_EndDate == ""))
            {
                s_Time = "";

            }
            AdminloginMess Am = new AdminloginMess();
            string s_Preson = "制表人:" + Am.KNet_StaffName;
            Sb_Details.Append("<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\"> \n");
            Sb_Details.Append("<tr>\n<th colspan=\"10\" style='height:11.25pt' align=left >3.成品领料单</th></tr>\n");
            Sb_Details.Append("<tr >\n<th class=\"thstyle\">序号</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">单号</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">日期</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">仓库</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">产品</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">编码</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">版本号</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">数量</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">单价</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">金额</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">打印</th>\n");
            Sb_Details.Append("</tr></thead><tbody class=\"scrollContent\">");

            string s_Style = "";
            StringBuilder s_Head = new StringBuilder();
            Decimal DTotalNum = 0, DTotalNet = 0;

            if (s_StartDate != "")
            {
                s_Sql += " and KWD_CWOutTime>='" + s_StartDate + "' ";
            }
            if (s_EndDate != "")
            {
                s_Sql += " and KWD_CWOutTime<='" + s_EndDate + "' ";
            }
            if (s_HouseNo != "")
            {
                s_Sql += " and  HouseNo='" + s_HouseNo + "'";
            }
            if (s_ProductsType != "")
            {
                KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
                string s_SonID = Bll_ProductsDetails.GetSonIDs(s_ProductsType);
                s_SonID = s_SonID.Replace(",", "','");
                s_Sql += " and ProductsType in ('" + s_SonID + "') ";
            }
            if (s_ProductsEdition != "")
            {
                s_Sql += "  e.ProductsEdition like '%" + s_ProductsEdition + "%' ";
            }
            if (s_State != "")
            {
                if (s_State == "0")
                {
                    s_Sql += " and KWD_BPrintNums='0'";
                }
                else
                {
                    s_Sql += "and KWD_BPrintNums<>'0'";
                }
            }

            s_Sql += " Order by KWD_CWOutTime ";

            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        s_Style = "class='gg'";
                    }
                    else
                    {
                        s_Style = "class='rr'";
                    }
                    Sb_Details.Append(" <tr " + s_Style + " onmouseover='setActiveBG(this)'>\n");
                    Sb_Details.Append("<td class='thstyleLeftDetails'align=center noWrap>" + (i + 1).ToString() + "</td>\n");
                    Sb_Details.Append("<td  class='thstyleLeftDetails' align=left  noWrap>&nbsp;" + Dtb_Table.Rows[i]["DirectOutNo"].ToString() + "</td>\n");

                    try
                    {
                        Sb_Details.Append("<td  class='thstyleLeftDetails'align=left noWrap>" + DateTime.Parse(Dtb_Table.Rows[i]["KWD_CWOutTime"].ToString()).ToShortDateString() + "</td>\n");
                    }
                    catch
                    {
                        Sb_Details.Append("<td class='thstyleLeftDetails' align=center noWrap>&nbsp;</td>\n");
                    }


                    Sb_Details.Append("<td class='thstyleLeftDetails' >" + base.Base_GetHouseName(Dtb_Table.Rows[i]["HouseNo"].ToString()) + "</td>\n");
                    Sb_Details.Append("<td class='thstyleLeftDetails' >" + Dtb_Table.Rows[i]["ProductsName"].ToString() + "</td>\n");
                    Sb_Details.Append("<td class='thstyleLeftDetails' >" + Dtb_Table.Rows[i]["KSP_COde"].ToString() + "</td>\n");
                    Sb_Details.Append("<td  class='thstyleLeftDetails'align=left >" + Dtb_Table.Rows[i]["ProductsEdition"].ToString() + "</td>\n");

                    Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  >" + base.FormatNumber1(Dtb_Table.Rows[i]["DirectOutAmount"].ToString(), 0) + "</td>\n");
                    Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  >" + base.FormatNumber1(Dtb_Table.Rows[i]["KWD_SalesUnitPrice"].ToString(), 2) + "</td>\n");
                    Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  >" + base.FormatNumber1(Dtb_Table.Rows[i]["DiretOutMoney"].ToString(), 2) + "</td>\n");

                    Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap><a href=\"#\"  onclick=\"GRCBPrint('" + Dtb_Table.Rows[i]["DirectOutNo"].ToString() + "')\"><Image ID=\"Image4\" src=\"../../../images/Print1.gif\" border=0   /></a>(" + Dtb_Table.Rows[i]["KWD_BPrintNums"].ToString() + ")</td>\n");

                    Sb_Details.Append(" </tr>");
                    s_ID += Dtb_Table.Rows[i]["DirectOutNo"].ToString() + ",";
                }
            }

            this.Tbx_ID.Text += s_ID;
            Sb_Details.Append("</tbody></table>");
        }
        catch { }
        return Sb_Details.ToString();
    }



    //原材料领料单
    private string GetMaterLlDetials()
    {
        string s_ID = "";
        StringBuilder Sb_Details = new StringBuilder();
        try
        {

            string s_Sql = "SELECT  ID,SED_ID, SuppNo, ProductsName, ProductsBarCode, ProductsPattern, ProductsEdition, ProductsUnits, -SED_RkNumber SED_RkNumber , ";
            s_Sql += "SED_WwPrice, SED_RkTime,SED_WwPrice,-SED_WwMoney SED_WwMoney,SED_RkPrice,SED_RkMoney SED_RkMoney,SEM_CheckYN,WwMoney,WwPrice,typeName,PrintNums,HouseNo";
            s_Sql += " from  v_Cw_Sc_Expend_Manage_MaterDetails a ";
            s_Sql += "  where CType=1 ";


            string s_StartDate = Request.QueryString["StartDate"] == null ? "" : Request.QueryString["StartDate"].ToString();
            string s_EndDate = Request.QueryString["EndDate"] == null ? "" : Request.QueryString["EndDate"].ToString();
            string s_HouseNo = Request.QueryString["HouseNo"] == null ? "" : Request.QueryString["HouseNo"].ToString();
            string s_ProductsName = Request.QueryString["ProductsName"] == null ? "" : Request.QueryString["ProductsName"].ToString();
            string s_ProductsEdition = Request.QueryString["ProductsEdition"] == null ? "" : Request.QueryString["ProductsEdition"].ToString();
            string s_ProductsType = Request.QueryString["ProductsType"] == null ? "" : Request.QueryString["ProductsType"].ToString();
            string s_State = Request.QueryString["State"] == null ? "" : Request.QueryString["State"].ToString();


            string s_Time = "日期:" + s_StartDate + " 到 " + s_EndDate;
            if ((s_StartDate == "") && (s_EndDate == ""))
            {
                s_Time = "";

            }
            AdminloginMess Am = new AdminloginMess();
            string s_Preson = "制表人:" + Am.KNet_StaffName;
            Sb_Details.Append("<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\"> \n");
            Sb_Details.Append("<tr>\n<th colspan=\"11\" style='height:11.25pt' align=left >4.原材料领料单</th></tr>\n");
            Sb_Details.Append("<tr >\n<th class=\"thstyle\">序号</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">单号</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">领料类型</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">日期</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">仓库</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">产品</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">编码</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">版本号</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">数量</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">单价</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">金额</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">打印</th>\n");
            Sb_Details.Append("</tr></thead><tbody class=\"scrollContent\">");

            string s_Style = "";
            StringBuilder s_Head = new StringBuilder();
            Decimal DTotalNum = 0, DTotalNet = 0;

            if (s_StartDate != "")
            {
                s_Sql += " and SED_RkTime>='" + s_StartDate + "' ";
            }
            if (s_EndDate != "")
            {
                s_Sql += " and SED_RkTime<='" + s_EndDate + "' ";
            }
            if (s_HouseNo != "")
            {
                s_Sql += " and  HouseNo='" + s_HouseNo + "'";
            }
            if (s_ProductsType != "")
            {
                KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
                string s_SonID = Bll_ProductsDetails.GetSonIDs(s_ProductsType);
                s_SonID = s_SonID.Replace(",", "','");
                s_Sql += " and ProductsType in ('" + s_SonID + "') ";
            }
            if (s_ProductsEdition != "")
            {
                s_Sql += "  ProductsEdition like '%" + s_ProductsEdition + "%' ";
            }
            if (s_State != "")
            {
                if (s_State == "0")
                {
                    s_Sql += " and PrintNums='0'";
                }
                else
                {
                    s_Sql += "and PrintNums<>'0'";
                }
            }

            s_Sql += "Order by SED_RkTime ";

            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        s_Style = "class='gg'";
                    }
                    else
                    {
                        s_Style = "class='rr'";
                    }
                    Sb_Details.Append(" <tr " + s_Style + " onmouseover='setActiveBG(this)'>\n");
                    Sb_Details.Append("<td class='thstyleLeftDetails'align=center noWrap>" + (i + 1).ToString() + "</td>\n");
                    Sb_Details.Append("<td  class='thstyleLeftDetails' align=left  noWrap>&nbsp;" + Dtb_Table.Rows[i]["TypeName"].ToString() + "</td>\n");
                    Sb_Details.Append("<td  class='thstyleLeftDetails' align=left  noWrap>&nbsp;" + Dtb_Table.Rows[i]["SED_ID"].ToString() + "</td>\n");

                    try
                    {
                        Sb_Details.Append("<td  class='thstyleLeftDetails'align=left noWrap>" + DateTime.Parse(Dtb_Table.Rows[i]["SED_RkTime"].ToString()).ToShortDateString() + "</td>\n");
                    }
                    catch
                    {
                        Sb_Details.Append("<td class='thstyleLeftDetails' align=center noWrap>&nbsp;</td>\n");
                    }


                    Sb_Details.Append("<td class='thstyleLeftDetails' >" + base.Base_GetHouseName(Dtb_Table.Rows[i]["HouseNo"].ToString()) + "</td>\n");
                    Sb_Details.Append("<td class='thstyleLeftDetails' >" + Dtb_Table.Rows[i]["ProductsName"].ToString() + "</td>\n");
                    Sb_Details.Append("<td class='thstyleLeftDetails' >" + base.Base_GetProductsCode(Dtb_Table.Rows[i]["ProductsBarCode"].ToString()) + "</td>\n");
                    Sb_Details.Append("<td  class='thstyleLeftDetails'align=left >" + Dtb_Table.Rows[i]["ProductsEdition"].ToString() + "</td>\n");

                    Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  >" + base.FormatNumber1(Dtb_Table.Rows[i]["SED_RkNumber"].ToString(), 0) + "</td>\n");
                    Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  >" + base.FormatNumber1(Dtb_Table.Rows[i]["SED_RkPrice"].ToString(), 2) + "</td>\n");
                    Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  >" + base.FormatNumber1(Dtb_Table.Rows[i]["SED_RkMoney"].ToString(), 2) + "</td>\n");

                    Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap><a href=\"#\"  onclick=\"GMaterLlPrint('" + Dtb_Table.Rows[i]["SED_ID"].ToString() + "')\"><Image ID=\"Image4\" src=\"../../../images/Print1.gif\" border=0   /></a>(" + Dtb_Table.Rows[i]["PrintNums"].ToString() + ")</td>\n");

                    Sb_Details.Append(" </tr>");
                    s_ID += Dtb_Table.Rows[i]["SED_ID"].ToString() + ",";
                }
                this.Tbx_ID.Text += s_ID;
                Sb_Details.Append("</tbody></table>");
            }

        }
        catch { }
        return Sb_Details.ToString();
    }
    //原材料调拨
    private string GetMaterDBDetials()
    {
        string s_ID = "";
        StringBuilder Sb_Details = new StringBuilder();
        try
        {

            string s_Sql = "Select AllocateNo,AllocateDateTime,OutHouseNo,inHoueNO,inHoueName,ProductsName,ProductsBarCode,KSP_COde,AllocateAmount,Allocate_WwPrice,";
            s_Sql += " Allocate_WwMoney ,AllocateStaffNo,AllocateCheckStaffNo,OutHouseName,ProductsEdition,KWA_PrintsNums ";
            s_Sql += " from  v_AllocateList  ";
            s_Sql += " Where 1=1 and AllocateNo not like 'FX%'  ";

            string s_StartDate = Request.QueryString["StartDate"] == null ? "" : Request.QueryString["StartDate"].ToString();
            string s_EndDate = Request.QueryString["EndDate"] == null ? "" : Request.QueryString["EndDate"].ToString();
            string s_HouseNo = Request.QueryString["HouseNo"] == null ? "" : Request.QueryString["HouseNo"].ToString();
            string s_ProductsName = Request.QueryString["ProductsName"] == null ? "" : Request.QueryString["ProductsName"].ToString();
            string s_ProductsEdition = Request.QueryString["ProductsEdition"] == null ? "" : Request.QueryString["ProductsEdition"].ToString();
            string s_ProductsType = Request.QueryString["ProductsType"] == null ? "" : Request.QueryString["ProductsType"].ToString();
            string s_State = Request.QueryString["State"] == null ? "" : Request.QueryString["State"].ToString();


            string s_Time = "日期:" + s_StartDate + " 到 " + s_EndDate;
            if ((s_StartDate == "") && (s_EndDate == ""))
            {
                s_Time = "";

            }
            AdminloginMess Am = new AdminloginMess();
            string s_Preson = "制表人:" + Am.KNet_StaffName;
            Sb_Details.Append("<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\"> \n");
            Sb_Details.Append("<tr>\n<th colspan=\"11\" style='height:11.25pt' align=left >5.原材料调拨单</th></tr>\n");
            Sb_Details.Append("<tr >\n<th class=\"thstyle\">序号</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">单号</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">日期</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">调出仓库</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">调入仓库</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">产品</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">编码</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">版本号</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">数量</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">单价</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">金额</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">打印</th>\n");
            Sb_Details.Append("</tr></thead><tbody class=\"scrollContent\">");

            string s_Style = "";
            StringBuilder s_Head = new StringBuilder();
            Decimal DTotalNum = 0, DTotalNet = 0;

            if (s_StartDate != "")
            {
                s_Sql += " and AllocateDateTime>='" + s_StartDate + "' ";
            }
            if (s_EndDate != "")
            {
                s_Sql += " and AllocateDateTime<='" + s_EndDate + "' ";
            }
            if (s_HouseNo != "")
            {
                s_Sql += " and  HouseNo='" + s_HouseNo + "'";
            }
            if (s_ProductsType != "")
            {
                KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
                string s_SonID = Bll_ProductsDetails.GetSonIDs(s_ProductsType);
                s_SonID = s_SonID.Replace(",", "','");
                s_Sql += " and ProductsType in ('" + s_SonID + "') ";
            }
            if (s_ProductsEdition != "")
            {
                s_Sql += "  ProductsEdition like '%" + s_ProductsEdition + "%' ";
            }
            if (s_State != "")
            {
                if (s_State == "0")
                {
                    s_Sql += " and KWA_PrintsNums='0'";
                }
                else
                {
                    s_Sql += "and KWA_PrintsNums<>'0'";
                }
            }

            s_Sql += "Order by a.AllocateDateTime ";

            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        s_Style = "class='gg'";
                    }
                    else
                    {
                        s_Style = "class='rr'";
                    }
                    Sb_Details.Append(" <tr " + s_Style + " onmouseover='setActiveBG(this)'>\n");
                    Sb_Details.Append("<td class='thstyleLeftDetails'align=center noWrap>" + (i + 1).ToString() + "</td>\n");
                    Sb_Details.Append("<td  class='thstyleLeftDetails' align=left  noWrap>&nbsp;" + Dtb_Table.Rows[i]["AllocateNo"].ToString() + "</td>\n");

                    try
                    {
                        Sb_Details.Append("<td  class='thstyleLeftDetails'align=left noWrap>" + DateTime.Parse(Dtb_Table.Rows[i]["AllocateDateTime"].ToString()).ToShortDateString() + "</td>\n");
                    }
                    catch
                    {
                        Sb_Details.Append("<td class='thstyleLeftDetails' align=center noWrap>&nbsp;</td>\n");
                    }


                    Sb_Details.Append("<td class='thstyleLeftDetails' >" + base.Base_GetHouseName(Dtb_Table.Rows[i]["OutHouseNo"].ToString()) + "</td>\n");
                    Sb_Details.Append("<td class='thstyleLeftDetails' >" + base.Base_GetHouseName(Dtb_Table.Rows[i]["inHoueNO"].ToString()) + "</td>\n");

                    Sb_Details.Append("<td class='thstyleLeftDetails' >" + Dtb_Table.Rows[i]["ProductsName"].ToString() + "</td>\n");
                    Sb_Details.Append("<td class='thstyleLeftDetails' >" + Dtb_Table.Rows[i]["KSP_COde"].ToString() + "</td>\n");
                    Sb_Details.Append("<td  class='thstyleLeftDetails'align=left >" + Dtb_Table.Rows[i]["ProductsEdition"].ToString() + "</td>\n");

                    Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  >" + base.FormatNumber1(Dtb_Table.Rows[i]["AllocateAmount"].ToString(), 0) + "</td>\n");
                    Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  >" + base.FormatNumber1(Dtb_Table.Rows[i]["Allocate_WwPrice"].ToString(), 2) + "</td>\n");
                    Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  >" + base.FormatNumber1(Dtb_Table.Rows[i]["Allocate_WwMoney"].ToString(), 2) + "</td>\n");

                    Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap><a href=\"#\"  onclick=\"GMaterDBPrint('" + Dtb_Table.Rows[i]["AllocateNo"].ToString() + "')\"><Image ID=\"Image4\" src=\"../../../images/Print1.gif\" border=0   /></a>(" + Dtb_Table.Rows[i]["KWA_PrintsNums"].ToString() + ")</td>\n");

                    Sb_Details.Append(" </tr>");
                    s_ID += Dtb_Table.Rows[i]["AllocateNo"].ToString() + ",";
                }
                this.Tbx_ID.Text += s_ID;
                Sb_Details.Append("</tbody></table>");
            }

        }
        catch { }
        return Sb_Details.ToString();
    }


    //成品调拨单
    private string GetDBDetials()
    {
        StringBuilder Sb_Details = new StringBuilder();
        try
        {

            string s_Sql = "Select a.DirectOutNo,a.KWD_CWOutTime,a.HouseNo,a.KWD_Custmoer,e.ProductsName,e.ProductsPattern,b.DirectOutAmount,b.KWD_SalesUnitPrice,";
            s_Sql += " b.DirectOutAmount*b.KWD_SalesUnitPrice Money,a.DirectOutStaffNo,a.DirectOutCheckStaffNo,b.ProductsBarCode,b.ID,isnull(b.KWD_BNumber,0)+isnull(b.DirectOutAmount,0) as totalNum,KWD_DPrintNums,e.ProductsEdition,e.KSP_COde from KNet_WareHouse_DirectOutList a ";
            s_Sql += " join KNet_WareHouse_DirectOutList_Details b on a.DirectOutNo=b.DirectOutNo ";
            s_Sql += " left join KNet_Sys_WareHouse c on c.HouseNo=a.HouseNo join KNet_Sys_Products e on e.ProductsBarCode=b.ProductsBarCode ";
            s_Sql += "Where 1=1 and Kwd_Type='101' and (KWD_ShipNo in( select OutWareNo from KNet_Sales_OutWareList where KSO_Type='1') or  KWD_ShipNo='') ";


            string s_StartDate = Request.QueryString["StartDate"] == null ? "" : Request.QueryString["StartDate"].ToString();
            string s_EndDate = Request.QueryString["EndDate"] == null ? "" : Request.QueryString["EndDate"].ToString();
            string s_HouseNo = Request.QueryString["HouseNo"] == null ? "" : Request.QueryString["HouseNo"].ToString();
            string s_ProductsName = Request.QueryString["ProductsName"] == null ? "" : Request.QueryString["ProductsName"].ToString();
            string s_ProductsEdition = Request.QueryString["ProductsEdition"] == null ? "" : Request.QueryString["ProductsEdition"].ToString();
            string s_ProductsType = Request.QueryString["ProductsType"] == null ? "" : Request.QueryString["ProductsType"].ToString();
            string s_State = Request.QueryString["State"] == null ? "" : Request.QueryString["State"].ToString();


            string s_Time = "日期:" + s_StartDate + " 到 " + s_EndDate;
            if ((s_StartDate == "") && (s_EndDate == ""))
            {
                s_Time = "";

            }
            AdminloginMess Am = new AdminloginMess();
            string s_Preson = "制表人:" + Am.KNet_StaffName;
            Sb_Details.Append("<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\"> \n");
            Sb_Details.Append("<tr>\n<th colspan=\"10\" style='height:11.25pt' align=left >3.成品调拨单</th></tr>\n");
            Sb_Details.Append("<tr >\n<th class=\"thstyle\">序号</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">单号</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">日期</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">仓库</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">产品</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">编码</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">版本号</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">数量</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">单价</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">金额</th>\n");
            Sb_Details.Append("<th class=\"thstyle\">打印</th>\n");
            Sb_Details.Append("</tr></thead><tbody class=\"scrollContent\">");

            string s_Style = "";
            StringBuilder s_Head = new StringBuilder();
            Decimal DTotalNum = 0, DTotalNet = 0;

            if (s_StartDate != "")
            {
                s_Sql += " and KWD_CWOutTime>='" + s_StartDate + "' ";
            }
            if (s_EndDate != "")
            {
                s_Sql += " and KWD_CWOutTime<='" + s_EndDate + "' ";
            }
            if (s_HouseNo != "")
            {
                s_Sql += " and  HouseNo='" + s_HouseNo + "'";
            }
            if (s_ProductsType != "")
            {
                KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
                string s_SonID = Bll_ProductsDetails.GetSonIDs(s_ProductsType);
                s_SonID = s_SonID.Replace(",", "','");
                s_Sql += " and ProductsType in ('" + s_SonID + "') ";
            }
            if (s_ProductsEdition != "")
            {
                s_Sql += "  e.ProductsEdition like '%" + s_ProductsEdition + "%' ";
            }
            if (s_State != "")
            {
                if (s_State == "0")
                {
                    s_Sql += " and KWD_PrintNums='0'";
                }
                else
                {
                    s_Sql += "and KWD_PrintNums<>'0'";
                }
            }

            s_Sql += "Order by a.KWD_CWOutTime,KWD_DirectOutNo ";

            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        s_Style = "class='gg'";
                    }
                    else
                    {
                        s_Style = "class='rr'";
                    }
                    Sb_Details.Append(" <tr " + s_Style + " onmouseover='setActiveBG(this)'>\n");
                    Sb_Details.Append("<td class='thstyleLeftDetails'align=center noWrap>" + (i + 1).ToString() + "</td>\n");
                    Sb_Details.Append("<td  class='thstyleLeftDetails' align=left  noWrap>&nbsp;" + Dtb_Table.Rows[i]["DirectOutNo"].ToString() + "</td>\n");

                    try
                    {
                        Sb_Details.Append("<td  class='thstyleLeftDetails'align=left noWrap>" + DateTime.Parse(Dtb_Table.Rows[i]["KWD_CWOutTime"].ToString()).ToShortDateString() + "</td>\n");
                    }
                    catch
                    {
                        Sb_Details.Append("<td class='thstyleLeftDetails' align=center noWrap>&nbsp;</td>\n");
                    }


                    Sb_Details.Append("<td class='thstyleLeftDetails' >" + base.Base_GetHouseName(Dtb_Table.Rows[i]["HouseNo"].ToString()) + "</td>\n");
                    Sb_Details.Append("<td class='thstyleLeftDetails' >" + Dtb_Table.Rows[i]["ProductsName"].ToString() + "</td>\n");
                    Sb_Details.Append("<td class='thstyleLeftDetails' >" + Dtb_Table.Rows[i]["KSP_COde"].ToString() + "</td>\n");
                    Sb_Details.Append("<td  class='thstyleLeftDetails'align=left >" + Dtb_Table.Rows[i]["ProductsEdition"].ToString() + "</td>\n");

                    Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  >" + base.FormatNumber1(Dtb_Table.Rows[i]["DirectOutAmount"].ToString(), 0) + "</td>\n");
                    Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  >" + base.FormatNumber1(Dtb_Table.Rows[i]["KWD_SalesUnitPrice"].ToString(), 2) + "</td>\n");
                    Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  >" + base.FormatNumber1(Dtb_Table.Rows[i]["Money"].ToString(), 2) + "</td>\n");

                    Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap><a href=\"#\"  onclick=\"GRCDBPrint('" + Dtb_Table.Rows[i]["DirectOutNo"].ToString() + "')\"><Image ID=\"Image4\" src=\"../../../images/Print1.gif\" border=0   /></a>(" + Dtb_Table.Rows[i]["KWD_DPrintNums"].ToString() + ")</td>\n");

                    Sb_Details.Append(" </tr>");
                }
            }

            Sb_Details.Append("</tbody></table>");
        }
        catch { }
        return Sb_Details.ToString();
    }
}
