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

using KNet.DBUtility;
using KNet.Common;

public partial class Web_Report_Xs_OrderList_Payment_List : BasePage
{
    public string s_Time = "";
    public string s_HouseName = "";
    public string s_Details = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Show();
        }
    }

    private void Show()
    {

        AdminloginMess AM = new AdminloginMess();
        if (AM.CheckLogin() == false)
        {
            Response.Write(
                "<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
            Response.End();
        }
        string s_StartDate = Request.QueryString["StartDate"] == null ? "" : Request.QueryString["StartDate"].ToString();
        string s_Number = Request.QueryString["Number"] == null ? "" : Request.QueryString["Number"].ToString();
        string s_EndDate = Request.QueryString["EndDate"] == null ? "" : Request.QueryString["EndDate"].ToString();
        string s_HouseNo = Request.QueryString["HouseNo"] == null ? "" : Request.QueryString["HouseNo"].ToString();

        string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
        string s_ProductsEdition = Request.QueryString["ProductsEdtion"] == null
            ? ""
            : Request.QueryString["ProductsEdtion"].ToString();

        string s_Ly = Request.QueryString["Ly"] == null ? "" : Request.QueryString["Ly"].ToString();

        string s_ProductsType = Request.QueryString["ProductsType"] == null
            ? ""
            : Request.QueryString["ProductsType"].ToString();
        string s_Sql = "Select ProductsBarCode,c.KWD_Custmoer, sum( case when CAP_STime>='"+ s_StartDate + "'and CAP_STime<='"+ s_EndDate + "' then CAPD_Number else 0 end) as number,sum( case when CAP_STime >= '" + s_StartDate + "'and CAP_STime <= '" + s_EndDate + "' then DirectOutAmount else 0 end) as outnumber,sum( case when CAP_STime < '" + s_StartDate + "' then KWD_SalesTotalNet else 0 end) - sum( case when CAP_STime < '" + s_StartDate + "' then CAPD_Money else 0 end) as QCmoney,sum( case when CAP_STime >= '" + s_StartDate + "'and CAP_STime <= '" + s_EndDate + "' then KWD_SalesTotalNet else 0 end) as FAmoney,sum( case when CAP_STime >= '" + s_StartDate + "'and CAP_STime <= '" + s_EndDate + "' then CAPD_Money else 0 end) as OUTmoney,sum( case when CAP_STime < '" + s_StartDate + "' then CAPD_Price else 0 end) as QCCAODKPrice,COUNT(case when CAP_STime < '" + s_StartDate + "' then ProductsBarCode end) as QCn,sum( case when CAP_STime >= '" + s_StartDate + "'and CAP_STime <= '" + s_EndDate + "' then CAPD_Price else 0 end) as QMCAPDKprice,COUNT(case when CAP_STime >= '" + s_StartDate + "'and CAP_STime <= '" + s_EndDate + "' then ProductsBarCode end) as QMn,(Sum(case when CAP_STime < '" + s_StartDate + "' then DirectOutAmount else 0 end) - Sum(case when CAP_STime < '" + s_StartDate + "' then CAPD_Number else 0 end)) as QCnumber,(sum( case when CAP_STime >= '" + s_StartDate + "'and CAP_STime <= '" + s_EndDate + "' then DirectOutAmount else 0 end) - sum( case when CAP_STime >= '" + s_StartDate + "'and CAP_STime <= '" + s_EndDate + "' then CAPD_Number else 0 end) + (Sum(case when CAP_STime < '" + s_StartDate + "' then DirectOutAmount else 0 end) - Sum(case when CAP_STime < '" + s_StartDate + "' then CAPD_Number else 0 end))) as QMnumber,(sum( case when CAP_STime >= '" + s_StartDate + "'and CAP_STime <= '" + s_EndDate + "' then KWD_SalesTotalNet else 0 end) - sum( case when CAP_STime >= '" + s_StartDate + "'and CAP_STime <= '" + s_EndDate + "' then CAPD_Money else 0 end) + sum( case when CAP_STime < '" + s_StartDate + "' then KWD_SalesTotalNet else 0 end) - sum( case when CAP_STime < '" + s_StartDate + "' then CAPD_Money else 0 end)) as QMmoney from Cw_Accounting_PaymentDetails a join KNet_WareHouse_DirectOutList_Details b on a.CAPD_FID = b.ID join KNet_WareHouse_DirectOutList c on c.DirectOutNo = b.DirectOutNo join Cw_Accounting_Payment d on d.CAP_ID = a.CAPD_CARID group by ProductsBarCode,c.KWD_Custmoer ";


        string s_Style = "";
        string s_Head = "";
        decimal d_QCTotalNumber = 0, d_QCTotalMoney = 0;
        decimal d_CgTotalNumber = 0, d_CgTotalMoney = 0;
        decimal d_WwTotalNumber = 0, d_WwTotalMoney = 0;
        decimal d_DbrTotalNumber = 0, d_DbrTotalMoney = 0;
        decimal d_QMTotalNumber = 0, d_QMTotalMoney = 0;
        decimal d_XhTotalNumber = 0, d_XhTotalMoney = 0;
        decimal d_outTotalNumber = 0, d_outTotalMoney = 0;

        decimal d_DbrDCLlTotalNumber = 0, d_DbrDCLlTotalMoney = 0;
        decimal d_DbrDCXsTotalNumber = 0, d_DbrDCXsTotalMoney = 0;

        decimal d_TotalTZMoney = 0;

        this.BeginQuery(s_Sql);
        this.QueryForDataTable();
        DataTable Dtb_Table = this.Dtb_Result;
        StringBuilder Sb_Details = new StringBuilder();

        s_Time = "日期:" + s_StartDate + " 到" + s_EndDate;
        s_HouseName = "入库仓库:" + base.Base_GetHouseName(s_HouseNo);


        Sb_Details.Append("<div class=\"tableContainer\" id=\"tableContainer\" >\n");
        Sb_Details.Append(
            "<table id=\"ListDetail\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\" >\n");
        Sb_Details.Append("<tr class=\"tr_Head\"><td class=\"thstyle\"  align=center  rowspan=\"2\" colspan=\"1\">序号</td>\n");
        Sb_Details.Append("<td class=\"thstyle\"  align=center rowspan=\"2\" colspan=\"1\">品名</td>\n");
        Sb_Details.Append("<td class=\"thstyle\"  align=center rowspan=\"2\" colspan=\"1\">产品编号</td>\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center rowspan=\"2\" colspan=\"1\">仓库</td>\n");
        //Sb_Details.Append("<td class=\"thstyle\" align=center colspan=\"3\">期初</td>\n");
        //Sb_Details.Append("<td class=\"thstyle\" align=center colspan=\"3\">当月发货</td>\n");
        //Sb_Details.Append("<td class=\"thstyle\" align=center colspan=\"3\">当月开票</td>\n");
        //Sb_Details.Append("<td class=\"thstyle\" align=center colspan=\"3\">期末未开票</td>\n</tr>\n");

        Sb_Details.Append("<td class=\"thstyle\" align=center colspan=\"3\">期初</td>\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center colspan=\"3\">当月发货</td>\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center colspan=\"3\">当月开票</td>\n");
        //Sb_Details.Append("<td class=\"thstyle\" align=center colspan=\"3\">当月开票</td>\n");

        Sb_Details.Append("<td class=\"thstyle\" align=center colspan=\"3\">期末</td>\n</tr>\n");
        Sb_Details.Append("<tr class=\"tr_Head\">\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center >未开票数量</td>\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center >单价</td>\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center >金额</td>\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center >数量</td>\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center >单价</td>\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center >金额</td>\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center >数量</td>\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center >单价</td>\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center >金额</td>\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center >未开票数量</td>\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center >单价</td>\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center >金额</td>\n");

        Sb_Details.Append("</tr>\n");
        if (Dtb_Table.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Table.Rows.Count; i++)
            {
                //string sql =
                //    "Select avg(CAPD_Price)as price from Cw_Accounting_PaymentDetails a join KNet_WareHouse_DirectOutList_Details b on a.CAPD_FID = b.ID join KNet_WareHouse_DirectOutList c on c.DirectOutNo = b.DirectOutNo join Cw_Accounting_Payment d on d.CAP_ID = a.CAPD_CARID where ProductsBarCode = '" +
                //    Dtb_Table.Rows[i]["ProductsBarCode"].ToString() + "' and KWD_Custmoer = '" +
                //    Dtb_Table.Rows[i]["KWD_Custmoer"].ToString() + "' and CAP_STime< '" + s_StartDate + "'";
                //this.BeginQuery(sql);
                //this.QueryForDataTable();
                //DataTable Dtb_Table1 = this.Dtb_Result;
                //decimal price =Convert.ToDecimal(Dtb_Table1.Rows[0][0].ToString()) ;
                //string sql1 =
                //  "Select avg(CAPD_Price)as price from Cw_Accounting_PaymentDetails a join KNet_WareHouse_DirectOutList_Details b on a.CAPD_FID = b.ID join KNet_WareHouse_DirectOutList c on c.DirectOutNo = b.DirectOutNo join Cw_Accounting_Payment d on d.CAP_ID = a.CAPD_CARID where ProductsBarCode = '" +
                //  Dtb_Table.Rows[i]["ProductsBarCode"].ToString() + "' and KWD_Custmoer = '" +
                //  Dtb_Table.Rows[i]["KWD_Custmoer"].ToString() + "' and CAP_STime>= '" + s_StartDate + "'";
                //this.BeginQuery(sql1);
                //this.QueryForDataTable();
                //DataTable Dtb_Table2 = this.Dtb_Result;
                //decimal price1 = Convert.ToDecimal(Dtb_Table2.Rows[0][0].ToString());
                if (i % 2 == 0)
                {
                    s_Style = "class='gg'";
                }
                else
                {
                    s_Style = "class='rr'";
                }

                Sb_Details.Append(" <tr " + s_Style + " onmouseover='setActiveBG(this)'>\n");
                //序号
                Sb_Details.Append("<td class='thstyleLeftDetails'align=center noWrap>" + (i + 1).ToString() + "</td>\n");
                //品名
                Sb_Details.Append("<td  class='thstyleLeftDetails' align=left  noWrap>");

                Sb_Details.Append("<a href='/web/Receive/MakePaymentList.aspx?ProductsBarCode=" +
                                  Dtb_Table.Rows[i]["ProductsBarCode"].ToString() + "&Custmoer=" + Dtb_Table.Rows[i]["KWD_Custmoer"].ToString() +
                                  "&startDate=" + s_StartDate + "&endDate=" + s_EndDate + "'  target=\"_blank\">");

                Sb_Details.Append(Base_GetProductsEdition(Dtb_Table.Rows[i]["ProductsBarCode"].ToString()).ToString());

                Sb_Details.Append("</a>");

                Sb_Details.Append("</td>\n");
                //产品编号
                Sb_Details.Append("<td  class='thstyleLeftDetails' align=left  noWrap>" +
                                  Dtb_Table.Rows[i]["ProductsBarCode"].ToString() + "&nbsp;</td>\n");
                ;

                //客户
                Sb_Details.Append("<td  class='thstyleLeftDetails' align=left  noWrap>" +
                                 Base_GetCustomer(Dtb_Table.Rows[i]["KWD_Custmoer"].ToString()) +
                                  "</td>\n");

                //期初


                //Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["QCnumber"].ToString(), 0) + "</td>\n");
                Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>");

                Sb_Details.Append("<a href='/web/Receive/MakePaymentList.aspx?ProductsBarCode=" +
                                  Dtb_Table.Rows[i]["ProductsBarCode"].ToString() + "&Type=QC&Custmoer=" + Dtb_Table.Rows[i]["KWD_Custmoer"].ToString() +
                                  "&startDate=" + s_StartDate + "&endDate=" + s_EndDate + "'  target=\"_blank\">");

                Sb_Details.Append(base.FormatNumber1(Dtb_Table.Rows[i]["QCnumber"].ToString(), 0));

                Sb_Details.Append("</a>");

                Sb_Details.Append("</td>\n");
                decimal d_QcPrice = 0;
                try
                {
                    d_QCTotalNumber += decimal.Parse(Dtb_Table.Rows[i]["QCnumber"].ToString());
                    if (Dtb_Table.Rows[i]["QCn"].ToString() == "0")
                    {
                        d_QcPrice = 0;
                    }
                    else
                    {
                        d_QcPrice = decimal.Parse(Dtb_Table.Rows[i]["QCCAODKPrice"].ToString()) / decimal.Parse(Dtb_Table.Rows[i]["QCn"].ToString());
                    }

                    d_QCTotalMoney = decimal.Parse(Dtb_Table.Rows[i]["QCmoney"].ToString());


                }
                catch
                {
                }
                Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(d_QcPrice.ToString(), 5) + "</td>\n");
                Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>" + d_QCTotalMoney + "</td>\n");


                //当月发货
                Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>");

                Sb_Details.Append("<a href='/web/Receive/MakePaymentList.aspx?ProductsBarCode=" +
                                  Dtb_Table.Rows[i]["ProductsBarCode"].ToString() + "&Type=FH&Custmoer=" + Dtb_Table.Rows[i]["KWD_Custmoer"].ToString() +
                                  "&startDate=" + s_StartDate + "&endDate=" + s_EndDate + "'  target=\"_blank\">");

                Sb_Details.Append(base.FormatNumber1(Dtb_Table.Rows[i]["outnumber"].ToString(), 0));

                Sb_Details.Append("</a>");

                Sb_Details.Append("</td>\n");
                decimal d_CgPrice = 0;
                try
                {
                    d_CgTotalNumber = decimal.Parse(Dtb_Table.Rows[i]["outnumber"].ToString());
                    if (decimal.Parse(Dtb_Table.Rows[i]["outnumber"].ToString()) == 0)
                    {
                        d_CgPrice = 0;
                    }
                    else
                    {
                        d_CgPrice = decimal.Parse(Dtb_Table.Rows[i]["FAmoney"].ToString()) / decimal.Parse(Dtb_Table.Rows[i]["outnumber"].ToString());
                    }

                    d_CgTotalMoney = decimal.Parse(Dtb_Table.Rows[i]["FAmoney"].ToString());

                }
                catch
                {
                }
                Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>" +
                                  base.FormatNumber1(d_CgPrice.ToString(), 5) + "</td>\n");
                Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>" + d_CgTotalMoney + "</td>\n");

                //当月开票
                Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>");
                Sb_Details.Append("<a href='/web/Receive/MakePaymentList.aspx?ProductsBarCode=" +
                                  Dtb_Table.Rows[i]["ProductsBarCode"].ToString() + "&Type=KP&Custmoer=" + Dtb_Table.Rows[i]["KWD_Custmoer"].ToString() +
                                  "&startDate=" + s_StartDate + "&endDate=" + s_EndDate + "'  target=\"_blank\">");
                Sb_Details.Append(base.FormatNumber1(Dtb_Table.Rows[i]["number"].ToString(), 0));
                Sb_Details.Append("</a>");
                Sb_Details.Append("</td>\n");
                decimal d_WwPrice = 0;
                try
                {
                    d_WwTotalNumber = decimal.Parse(Dtb_Table.Rows[i]["number"].ToString());
                    if (decimal.Parse(Dtb_Table.Rows[i]["number"].ToString()) == 0)
                    {
                        d_WwPrice = 0;
                    }
                    else
                    {
                        d_WwPrice = decimal.Parse(Dtb_Table.Rows[i]["OUTmoney"].ToString()) / decimal.Parse(Dtb_Table.Rows[i]["number"].ToString());
                    }

                    d_WwTotalMoney = decimal.Parse(Dtb_Table.Rows[i]["OUTmoney"].ToString());

                }
                catch
                {
                }
                Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>" +
                                  base.FormatNumber1(d_WwPrice.ToString(), 5) + "</td>\n");
                Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>" + d_WwTotalMoney + "</td>\n");

                //期末
                Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>");
                Sb_Details.Append("<a href='/web/Receive/MakePaymentList.aspx?ProductsBarCode=" +
                                  Dtb_Table.Rows[i]["ProductsBarCode"].ToString() + "&Type=QM&Custmoer=" + Dtb_Table.Rows[i]["KWD_Custmoer"].ToString() +
                                  "&startDate=" + s_StartDate + "&endDate=" + s_EndDate + "'  target=\"_blank\">");
                Sb_Details.Append(base.FormatNumber1(Dtb_Table.Rows[i]["QMnumber"].ToString(), 0));
                Sb_Details.Append("</a>");
                Sb_Details.Append("</td>\n");
                decimal d_WwPrice1 = 0;
                try
                {
                    d_QMTotalNumber+= decimal.Parse(Dtb_Table.Rows[i]["QMnumber"].ToString());
                    decimal d = decimal.Parse(Dtb_Table.Rows[i]["QMmoney"].ToString());
                    if (decimal.Parse(Dtb_Table.Rows[i]["QMnumber"].ToString()) == 0)
                    {
                        d_WwPrice1 = 0;
                    }
                    else
                    {
                        d_WwPrice1 = decimal.Parse(Dtb_Table.Rows[i]["QMmoney"].ToString())/decimal.Parse(Dtb_Table.Rows[i]["QMnumber"].ToString());
                    }

                    d_QMTotalMoney = decimal.Parse(Dtb_Table.Rows[i]["QMmoney"].ToString());



                }
                catch
                {

                }
                Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>" +
                                  base.FormatNumber1(d_WwPrice1.ToString(), 5) + "</td>\n");
                Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>" + d_QMTotalMoney + "</td>\n");

                Sb_Details.Append(" </tr>\n");
            }
            this.Tbx_Num.Text = Dtb_Table.Rows.Count.ToString();


        }
        Sb_Details.Append("</table>\n");



        Sb_Details.Append("</div>\n");
        this.Lbl_Details.Text = Sb_Details.ToString();

    }










protected void Btn_SaveOnClick(object sender, EventArgs e)
    {

        AdminloginMess AM = new AdminloginMess();
        if (Btn_Save.Text == "修改")
        {
            Btn_Save.Text = "保存";
        }
        else
        {

            try
            {
                int i_Num = int.Parse(this.Tbx_Num.Text);
                for (int i = 0; i < i_Num; i++)
                {
                    string s_ProductsBarCode = Request["Tbx_ProductsBarCode_" + i.ToString() + ""] == null ? "" : Request["Tbx_ProductsBarCode_" + i.ToString() + ""].ToString();
                    //更新委外价格
                    string s_radio0 = Request["radiogroup" + i.ToString() + ""] == null ? "" : Request["radiogroup" + i.ToString() + ""].ToString();
                    string s_Remarks = Request["Remarks_" + i.ToString() + ""] == null ? "" : Request["Remarks_" + i.ToString() + ""].ToString();


                    if ((s_radio0 == "1") || (s_radio0 == "2"))
                    {
                        string s_Sql = "update KNet_Sys_Products set KSP_ProdutsType=" + s_radio0 + ",KSP_CwReamrks='" + s_Remarks + "' where ProductsBarCode='" + s_ProductsBarCode + "' ";
                        DbHelperSQL.ExecuteSql(s_Sql);

                        AM.Add_Logs("产品状态修改:" + s_ProductsBarCode);
                    }
                    else
                    {
                        string s_Sql = "update KNet_Sys_Products set KSP_ProdutsType=" + s_radio0 + ",KSP_CwReamrks='" + s_Remarks + "' where ProductsBarCode='" + s_ProductsBarCode + "' ";
                        DbHelperSQL.ExecuteSql(s_Sql);
                    }
                    AlertAndClose("保存成功！");
                    Btn_Save.Text = "修改";
                }
            }
            catch (Exception ex)
            {
                Alert(ex.Message);
            }
        }
        this.Show();
    }
    protected void Btn_SaveOnClick1(object sender, EventArgs e)
    {
        if (Button3.Text == "显示仓库")
        {
            Button3.Text = "隐藏仓库";
        }
        else
        {
            Button3.Text = "显示仓库";
        }
        this.Show();

    }

    protected void Btn_Excel_Click(object sender, EventArgs e)
    {
        /*

        KNet.BLL.Xs_Products_Prodocts BLL_Products_Products = new KNet.BLL.Xs_Products_Prodocts();
        KNet.BLL.PB_Basic_ProductsClass BLL_Basic_ProductsClass = new KNet.BLL.PB_Basic_ProductsClass();
        KNet.BLL.Xs_Products_Prodocts_Demo BLL_DemoProducts_Products = new KNet.BLL.Xs_Products_Prodocts_Demo();
        string s_Where1 = " and XPD_FaterBarCode='" + this.Tbx_ID.Text + "' ";
        s_Where1 += " and  b.KSP_Del=0 ";
        string s_Sql = "Select * from Xs_Products_Prodocts_Demo a join KNET_Sys_Products b on a.XPD_ProductsBarCode=b.ProductsBarCode";
        s_Sql += " join PB_Basic_ProductsClass c on b.ProductsType=c.PBP_ID where 1=1 ";
        this.BeginQuery(s_Sql + s_Where1 + "  order by c.PBP_Name,ProductsEdition");
        DataSet Dts_DemoProducts = (DataSet)this.QueryForDataSet();
        DataTable Dtb_DemoProducts = Dts_DemoProducts.Tables[0];
        
        Excel export = new Excel();
        export.ExcelExport(GetStringWriter(Dtb_DemoProducts), this.Lbl_BomTitle.Text);
        */

        Response.Buffer = true;
        Response.Clear();
        Response.ClearContent();
        Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode("收发存.xls", System.Text.Encoding.UTF8).ToString());
        //Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");

        Response.ContentType = "application/ms-excel";
        Response.Write(this.Lbl_Details.Text);
        Response.Flush();
        Response.End();
    }
}