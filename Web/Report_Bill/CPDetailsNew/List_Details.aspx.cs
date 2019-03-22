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

public partial class Web_List_Details : BasePage
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
            Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
            Response.End();
        }
        string s_StartDate = Request.QueryString["StartDate"] == null ? "" : Request.QueryString["StartDate"].ToString();
        string s_EndDate = Request.QueryString["EndDate"] == null ? "" : Request.QueryString["EndDate"].ToString();
        string s_HouseNo = Request.QueryString["HouseNo"] == null ? "" : Request.QueryString["HouseNo"].ToString();

        string s_Number = Request.QueryString["Number"] == null ? "" : Request.QueryString["Number"].ToString();
        string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
        string s_ProductsEdition = Request.QueryString["ProductsEdtion"] == null ? "" : Request.QueryString["ProductsEdtion"].ToString();
        string s_Ly = Request.QueryString["Ly"] == null ? "" : Request.QueryString["Ly"].ToString();

        string s_ProductsType = Request.QueryString["ProductsType"] == null ? "" : Request.QueryString["ProductsType"].ToString();
        string s_Sql = "select b.KSP_CwReamrks,b.ksp_Code,a.ProductsBarCode,b.ProductsName,b.ProductsEdition,b.ProductsUnits,b.ProductsType,b.KSP_ProdutsType,Sum(case when DirectinDateTime<'" + s_StartDate + "' then DirectInAmount else 0 end)  as QCAmount  ";

        string s_WareHoseSql = " and a.HouseNo in  ('" + s_HouseNo + "') ";
        if (Button3.Text == "隐藏仓库")
        {
            s_Sql += ",c.HouseName";
            s_WareHoseSql = "";
        }
        s_Sql += ",Sum(case when DirectinDateTime<'" + s_StartDate + "' then DirectInTotalNet else 0 end)  as QCMoney ";
        s_Sql += ",Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type='101'  then DirectInAmount else 0 end)  as ZjAmount ";
        s_Sql += ",Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type='101'  then DirectInTotalNet else 0 end)  as ZjMoney ";
        s_Sql += ",Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type='109'  then DirectInAmount else 0 end)  as CgAmount ";
        s_Sql += ",Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type='109'  then DirectInTotalNet else 0 end)  as CgMoney ";
        s_Sql += ",Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type='104' and TypeName='直接出库'  then -DirectInAmount else 0 end)  as ZjOutAmount ";
        s_Sql += ",Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type='104' and TypeName='直接出库'    then -DirectInTotalNet else 0 end)  as ZjOutMoney ";
        s_Sql += ",Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type='104' and TypeName='销售出库'  then -DirectInAmount else 0 end)  as OutAmount ";
        s_Sql += ",Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type='104' and TypeName='销售出库'    then -DirectInTotalNet else 0 end)  as OutMoney ";
        s_Sql += ",Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' " + s_WareHoseSql + " and TypeName='调拨入库'  then DirectInAmount else 0 end)  as DbrAmount ";
        s_Sql += ",Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "'  " + s_WareHoseSql + "  and TypeName='调拨入库'    then DirectInTotalNet else 0 end)  as DbrMoney ";
        s_Sql += ",Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "'  " + s_WareHoseSql + "  and TypeName='调拨出库'  then -DirectInAmount else 0 end)  as DbcAmount ";
        s_Sql += ",Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "'  " + s_WareHoseSql + "  and TypeName='调拨出库'    then -DirectInTotalNet else 0 end)  as DbcMoney ";
        s_Sql += ",Sum(case when  DirectinDateTime<='" + s_EndDate + "'   then DirectInAmount else 0 end)  as QMAmount ";
        s_Sql += ",Sum(case when  DirectinDateTime<='" + s_EndDate + "'   then DirectInTotalNet else 0 end)  as QMMoney ";

        s_Sql += ",Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type in ('108') and TypeName='材料调整'  then -DirectInTotalNet else 0 end)  as TZMoney ";
        s_Sql += " from V_Store a join KNet_Sys_Products b on a.ProductsBarCode=b.ProductsBarCode ";
        s_Sql += " join KNet_Sys_WareHouse c on a.HouseNo=c.HouseNo ";

        s_Sql += " where 1=1 ";

        Lbl_Link.Text = "<a target=\"_blank\" href=\"List_Details1.aspx?EndDate=" + s_EndDate + "&StartDate=" + s_StartDate + "\" >期末金额调整</a>";
        if (s_HouseNo != "")
        {
            s_Sql += " and  a.HouseNo='" + s_HouseNo + "'";
        }
        else
        {
            s_Sql += " and  a.HouseNo in (select HouseNo FROM KNet_Sys_WareHouse where HouseYN=1 and KSW_Type='0' )";
        }
        if (s_ProductsType != "")
        {
            KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
            string s_SonID = Bll_ProductsDetails.GetSonIDs(s_ProductsType);
            s_SonID = s_SonID.Replace(",", "','");
            s_Sql += " and b.ProductsType in ('" + s_SonID + "') ";
        }
        if (s_ProductsEdition != "")
        {
            s_Sql += " and a.ProductsBarCode in(Select ProductsBarCode from KNet_sys_Products where ProductsEdition like '%" + s_ProductsEdition + "%' or ProductsName like '%" + s_ProductsEdition + "%' or KSP_COde like '%" + s_ProductsEdition + "%') ";
        }

        s_Sql += " Group by b.KSP_CwReamrks,b.ksp_Code,a.ProductsBarCode,b.ProductsName,b.ProductsEdition,b.ProductsUnits,b.ProductsType,b.KSP_ProdutsType ";

        if (Button3.Text == "隐藏仓库")
        {
            s_Sql += ",c.HouseName";
        }
        s_Sql += " HAVING (Sum(case when DirectinDateTime<'" + s_StartDate + "' then DirectInTotalNet else 0 end)<>0 ";
        s_Sql += " or Sum(case when DirectinDateTime<'" + s_StartDate + "' then DirectInAmount else 0 end)<>0  ";
        s_Sql += " or Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type in ('101')  then DirectInAmount else 0 end)<>0 ";
        s_Sql += " or Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type in ('109')  then DirectInAmount else 0 end)<>0 ";
        s_Sql += " or Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type in ('104') and TypeName='直接出库' then DirectInAmount else 0 end)<>0 ";
        s_Sql += " or Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type in ('104') and TypeName='销售出库' then DirectInAmount else 0 end)<>0 ";

        s_Sql += " or Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and a.HouseNo in ('131187187069993664','131235104473261008') and TypeName='调拨入库'    then DirectInAmount else 0 end)<>0";
        s_Sql += " or Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and a.HouseNo in ('131187187069993664','131235104473261008') and TypeName='调拨出库'  then DirectInAmount else 0 end) <>0) ";
        // s_Sql += " or Sum(case when DirectinDateTime<='" + s_EndDate + "' then DirectInAmount else 0 end)<>0  ";
        //s_Sql += " or Sum(case when  DirectinDateTime<='" + s_EndDate + "'   then DirectInTotalNet else 0 end)<>0 ";
        if (s_Number != "")
        {
            if (s_Number == "0")
            {
                s_Sql += " and  Sum(case when  DirectinDateTime<='" + s_EndDate + "'   then DirectInAmount else 0 end)>0 ";
            }
            else if (s_Number == "1")
            {
                s_Sql += " and  Sum(case when  DirectinDateTime<='" + s_EndDate + "'   then DirectInAmount else 0 end)=0 ";
            }
            else if (s_Number == "2")
            {
                s_Sql += " and  Sum(case when  DirectinDateTime<='" + s_EndDate + "'   then DirectInAmount else 0 end)<0 ";
            }
        }
        else
        {

            s_Sql += " or Sum(case when DirectinDateTime<'" + s_EndDate + "' then DirectInAmount else 0 end)<>0  ";
        }
        s_Sql += " order by b.ProductsName,b.ProductsEdition,b.ProductsType ";
        string s_Style = "";
        string s_Head = "";
        decimal d_QCTotalNumber = 0, d_QCTotalMoney = 0;
        decimal d_CgTotalNumber = 0, d_CgTotalMoney = 0;
        decimal d_WwTotalNumber = 0, d_WwTotalMoney = 0;
        decimal d_DbrTotalNumber = 0, d_DbrTotalMoney = 0;
        decimal d_DbcTotalNumber = 0, d_DbcTotalMoney = 0;
        decimal d_QMTotalNumber = 0, d_QMTotalMoney = 0;
        decimal d_XhTotalNumber = 0, d_XhTotalMoney = 0;
        decimal d_outTotalNumber = 0, d_outTotalMoney = 0;

        decimal d_DbrDCLlTotalNumber = 0, d_DbrDCLlTotalMoney = 0;
        decimal d_DbrDCXsTotalNumber = 0, d_DbrDCXsTotalMoney = 0;
        decimal d_ZjTotalNumber = 0, d_ZjTotalMoney = 0;

        decimal d_TotalTZMoney = 0;

        this.BeginQuery(s_Sql);
        this.QueryForDataTable();
        DataTable Dtb_Table = this.Dtb_Result;
        StringBuilder Sb_Details = new StringBuilder();

        s_Time = "日期:" + s_StartDate + " 到" + s_EndDate;
        if (s_HouseNo == "")
        {
            s_HouseName = "入库仓库:成品库";
        }
        else
        {
            s_HouseName = "入库仓库:" + base.Base_GetHouseName(s_HouseNo);
        }

        Sb_Details.Append("<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n");
        Sb_Details.Append("<tr>\n<td colspan=\"26\" class=\"MaterTitle\" style='height:14.25pt'>杭州士腾科技有限公司<br/>存货收发结存表单(成品)</td></tr>\n");
        Sb_Details.Append("<tr>\n<td colspan=\"13\" class=\"thstyleleft\"  >" + s_HouseName + "</td>\n");
        Sb_Details.Append("<td colspan=\"13\" class=\"thstyleRight\" >" + s_Time + "</td></tr>\n");
        Sb_Details.Append("</table>\n");
        Sb_Details.Append("<div class=\"tableContainer\" id=\"tableContainer\" >\n");

        Sb_Details.Append("<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\" >\n");
        // Sb_Details.Append("<tdead class=\"fixedHeader\"> \n");
        Sb_Details.Append("<tr class=\"tr_Head\"><td class=\"thstyle\"  align=center  rowspan=\"2\" colspan=\"1\">序号</td>\n");
        Sb_Details.Append("<td class=\"thstyle\"  align=center rowspan=\"2\" colspan=\"1\">类别</td>\n");
        Sb_Details.Append("<td class=\"thstyle\"  align=center rowspan=\"2\" colspan=\"1\">品名</td>\n");
        Sb_Details.Append("<td class=\"thstyle\"  align=center rowspan=\"2\" colspan=\"1\">规格</td>\n");
        Sb_Details.Append("<td class=\"thstyle\"  align=center rowspan=\"2\" colspan=\"1\">料号</td>\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center rowspan=\"2\" colspan=\"1\">单位</td>\n");
        if (Button3.Text == "隐藏仓库")
        {
            Sb_Details.Append("<td class=\"thstyle\" align=center rowspan=\"2\" colspan=\"1\">仓库</td>\n");
        }
        Sb_Details.Append("<td class=\"thstyle\" align=center colspan=\"3\">期初</td>\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center colspan=\"3\">直接入库</td>\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center colspan=\"3\">生产入库</td>\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center colspan=\"3\">部门领用</td>\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center colspan=\"3\">销售出库</td>\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center colspan=\"3\">调回数量</td>\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center colspan=\"3\">委外调拨</td>\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center colspan=\"3\">期末</td>\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center colspan=\"3\">产品状态</td>\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center rowspan=\"2\">备注</td>\n</tr>\n");
        Sb_Details.Append("<tr class=\"tr_Head\">\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center >数量</td>\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center >单价</td>\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center >金额</td>\n");

        Sb_Details.Append("<td class=\"thstyle\" align=center >数量</td>\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center >单价</td>\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center >金额</td>\n");

        Sb_Details.Append("<td class=\"thstyle\" align=center >数量</td>\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center >单价</td>\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center >金额</td>\n");

        Sb_Details.Append("<td class=\"thstyle\" align=center >数量</td>\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center >单价</td>\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center >金额</td>\n");

        Sb_Details.Append("<td class=\"thstyle\" align=center >数量</td>\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center >单价</td>\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center >金额</td>\n");

        Sb_Details.Append("<td class=\"thstyle\" align=center >数量</td>\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center >单价</td>\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center >金额</td>\n");

        Sb_Details.Append("<td class=\"thstyle\" align=center >数量</td>\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center >单价</td>\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center >金额</td>\n");

        Sb_Details.Append("<td class=\"thstyle\" align=center >数量</td>\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center >单价</td>\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center >金额</td>\n");

        Sb_Details.Append("<td class=\"thstyle\" align=center >正常</td>\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center >滞销</td>\n");
        Sb_Details.Append("<td class=\"thstyle\" align=center >呆滞</td>\n");
        Sb_Details.Append("</tr>\n");
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
                int i_ProductsType = 0;

                i_ProductsType = int.Parse(Dtb_Table.Rows[i]["KSP_ProdutsType"].ToString());
                if (i_ProductsType == 1)
                {
                    s_Style = "class='red1'";
                }
                else if (i_ProductsType == 2)
                {
                    s_Style = "class='red'";
                }
                Sb_Details.Append(" <tr " + s_Style + " onmouseover='setActiveBG(this)'>\n");
                Sb_Details.Append("<td class='thstyleLeftDetails'align=center noWrap>" + (i + 1).ToString() + "</td>\n");
                Sb_Details.Append("<td class='thstyleLeftDetails'align=center noWrap>" + productclass(Dtb_Table.Rows[i]["KSP_Code"].ToString()) + "</td>\n");
                Sb_Details.Append("<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=" + Dtb_Table.Rows[i]["ProductsBarCode"].ToString() + "&HouseNo=" + s_HouseNo + "' target=\"_blank\">" + Dtb_Table.Rows[i]["ProductsName"].ToString() + "</td>\n");
                string s_ProductsEdition1 = Dtb_Table.Rows[i]["ProductsEdition"].ToString();
                if (Dtb_Table.Rows[i]["ProductsType"].ToString() == "M130703044953260")
                {
                    s_ProductsEdition1 = base.Base_GetProductsPattern(Dtb_Table.Rows[i]["ProductsBarCode"].ToString()) + "_" + s_ProductsEdition1;
                }
                Sb_Details.Append("<td  class='thstyleLeftDetails' align=left  noWrap>" + s_ProductsEdition1 + "&nbsp;</td>\n");
                Sb_Details.Append("<td  class='thstyleLeftDetails' align=left  noWrap>" + Dtb_Table.Rows[i]["KSP_Code"].ToString() + "&nbsp;</td>\n");
                Sb_Details.Append("<td  class='thstyleLeftDetails' align=left  noWrap>" + base.Base_GetUnitsName(Dtb_Table.Rows[i]["ProductsUnits"].ToString()) + "</td>\n");

                if (Button3.Text == "隐藏仓库")
                {
                    Sb_Details.Append("<td  class='thstyleLeftDetails' align=left  noWrap>" + Dtb_Table.Rows[i]["HouseName"].ToString() + "</td>\n");
                }
                //期初
                Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["QCAmount"].ToString(), 0) + "</td>\n");
                decimal d_QcPrice = 0;
                try
                {
                    d_QCTotalNumber += decimal.Parse(Dtb_Table.Rows[i]["QCAmount"].ToString());
                    d_QCTotalMoney += decimal.Parse(Dtb_Table.Rows[i]["QCMoney"].ToString());
                    d_QcPrice = decimal.Parse(Dtb_Table.Rows[i]["QCMoney"].ToString()) / decimal.Parse(Dtb_Table.Rows[i]["QCAmount"].ToString());

                }
                catch { }
                Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(d_QcPrice.ToString(), 5) + "</td>\n");
                Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["QCMoney"].ToString(), 2) + "</td>\n");

                //直接

                Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>");
                if (s_Ly == "0")
                {
                    Sb_Details.Append("<a href='/Web/Report_Bill/ScIn/List_OrderIn.aspx?StartDate=" + s_StartDate + "&EndDate=" + s_EndDate + "&ProductsBarCode=" + Dtb_Table.Rows[i]["ProductsBarCode"].ToString() + "&Type=0&State=&House=" + s_HouseNo + "'  target=\"_blank\">");
                }
                Sb_Details.Append(base.FormatNumber1(Dtb_Table.Rows[i]["ZjAmount"].ToString(), 0));
                if (s_Ly == "0")
                {
                    Sb_Details.Append("</a>");
                }
                Sb_Details.Append("</td>\n");
                decimal d_ZjPrice = 0;
                try
                {
                    d_ZjTotalNumber += decimal.Parse(Dtb_Table.Rows[i]["ZjAmount"].ToString());
                    d_ZjTotalMoney += decimal.Parse(Dtb_Table.Rows[i]["ZjCgMoney"].ToString());
                    d_ZjPrice = decimal.Parse(Dtb_Table.Rows[i]["ZjCgMoney"].ToString()) / decimal.Parse(Dtb_Table.Rows[i]["ZjAmount"].ToString());

                }
                catch { }
                Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(d_ZjPrice.ToString(), 5) + "</td>\n");
                Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["ZjMoney"].ToString(), 2) + "</td>\n");

                //生产入库

                Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>");
                if (s_Ly == "0")
                {
                    Sb_Details.Append("<a href='/Web/Report_Bill/ScInD/List_OrderIn.aspx?StartDate=" + s_StartDate + "&EndDate=" + s_EndDate + "&ProductsBarCode=" + Dtb_Table.Rows[i]["ProductsBarCode"].ToString() + "&Type=0&State=&House=" + s_HouseNo + "'  target=\"_blank\">");
                }
                Sb_Details.Append(base.FormatNumber1(Dtb_Table.Rows[i]["CgAmount"].ToString(), 0));
                if (s_Ly == "0")
                {
                    Sb_Details.Append("</a>");
                }
                Sb_Details.Append("</td>\n");
                decimal d_CgPrice = 0;
                try
                {
                    d_CgTotalNumber += decimal.Parse(Dtb_Table.Rows[i]["CgAmount"].ToString());
                    d_CgTotalMoney += decimal.Parse(Dtb_Table.Rows[i]["CgMoney"].ToString());
                    d_CgPrice = decimal.Parse(Dtb_Table.Rows[i]["CgMoney"].ToString()) / decimal.Parse(Dtb_Table.Rows[i]["CgAmount"].ToString());

                }
                catch { }
                Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(d_CgPrice.ToString(), 5) + "</td>\n");
                Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["CgMoney"].ToString(), 2) + "</td>\n");


                //部门领用

                Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>");
                if (s_Ly == "0")
                {
                    Sb_Details.Append("<a href='/Web/Report_Bill/ScLlDetails/List_CkList2.aspx?StartDate=" + s_StartDate + "&EndDate=" + s_EndDate + "&ProductsBarCode=" + Dtb_Table.Rows[i]["ProductsBarCode"].ToString() + "&Type=0&State=&HouseNo=" + s_HouseNo + "'  target=\"_blank\">");
                }
                Sb_Details.Append(base.FormatNumber1(Dtb_Table.Rows[i]["ZjOutAmount"].ToString(), 0));
                if (s_Ly == "0")
                {
                    Sb_Details.Append("</a>");
                }
                Sb_Details.Append("</td>\n");
                // Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["ZjOutAmount"].ToString(), 0) + "</td>\n");
                decimal d_WwPrice = 0;
                try
                {
                    d_WwTotalNumber += decimal.Parse(Dtb_Table.Rows[i]["ZjOutAmount"].ToString());
                    d_WwTotalMoney += decimal.Parse(Dtb_Table.Rows[i]["ZjOutMoney"].ToString());
                    d_WwPrice = decimal.Parse(Dtb_Table.Rows[i]["ZjOutMoney"].ToString()) / decimal.Parse(Dtb_Table.Rows[i]["ZjOutAmount"].ToString());

                }
                catch { }
                Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(d_WwPrice.ToString(), 5) + "</td>\n");
                Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["ZjOutMoney"].ToString(), 2) + "</td>\n");

                //销售出库


                Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>");
                if (s_Ly == "0")
                {
                    Sb_Details.Append("<a href='/Web/Report_Bill/XsOut/List_CkList.aspx?StartDate=" + s_StartDate + "&EndDate=" + s_EndDate + "&ProductsBarCode=" + Dtb_Table.Rows[i]["ProductsBarCode"].ToString() + "&Type=0&State=&HouseNo=" + s_HouseNo + "'  target=\"_blank\">");
                }
                Sb_Details.Append(base.FormatNumber1(Dtb_Table.Rows[i]["OutAmount"].ToString(), 0));
                if (s_Ly == "0")
                {
                    Sb_Details.Append("</a>");
                }
                Sb_Details.Append("</td>\n");
                decimal d_XhPrice = 0;
                try
                {
                    d_XhTotalNumber += decimal.Parse(Dtb_Table.Rows[i]["OutAmount"].ToString());
                    d_XhTotalMoney += decimal.Parse(Dtb_Table.Rows[i]["OutMoney"].ToString());
                    d_XhPrice = decimal.Parse(Dtb_Table.Rows[i]["OutMoney"].ToString()) / decimal.Parse(Dtb_Table.Rows[i]["OutAmount"].ToString());

                }
                catch { }
                Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(d_XhPrice.ToString(), 5) + "</td>\n");
                Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["OutMoney"].ToString(), 2) + "</td>\n");



                //调拨入库

                Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>");
                if (s_Ly == "0")
                {
                    Sb_Details.Append("<a href='/Web/Report_Bill/DBCP/List_CkList3.aspx?StartDate=" + s_StartDate + "&EndDate=" + s_EndDate + "&ProductsBarCode=" + Dtb_Table.Rows[i]["ProductsBarCode"].ToString() + "&Type=0&State=&InHouseNo=" + s_HouseNo + "'  target=\"_blank\">");
                }
                Sb_Details.Append(base.FormatNumber1(Dtb_Table.Rows[i]["DbrAmount"].ToString(), 0));
                if (s_Ly == "0")
                {
                    Sb_Details.Append("</a>");
                }
                Sb_Details.Append("</td>\n");
               // Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["DbrAmount"].ToString(), 0) + "</td>\n");
                decimal d_DbrPrice = 0;
                try
                {
                    d_DbrTotalNumber += decimal.Parse(Dtb_Table.Rows[i]["DbrAmount"].ToString());
                    d_DbrTotalMoney += decimal.Parse(Dtb_Table.Rows[i]["DbrMoney"].ToString());
                    d_DbrPrice = decimal.Parse(Dtb_Table.Rows[i]["DbrMoney"].ToString()) / decimal.Parse(Dtb_Table.Rows[i]["DbrAmount"].ToString());

                }
                catch { }
                Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(d_DbrPrice.ToString(), 5) + "</td>\n");
                Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["DbrMoney"].ToString(), 2) + "</td>\n");


                //调拨出库

                Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>");
                if (s_Ly == "0")
                {
                    Sb_Details.Append("<a href='/Web/Report_Bill/DBCP/List_CkList3.aspx?StartDate=" + s_StartDate + "&EndDate=" + s_EndDate + "&ProductsBarCode=" + Dtb_Table.Rows[i]["ProductsBarCode"].ToString() + "&Type=0&State=&OutHouseNo=" + s_HouseNo + "'  target=\"_blank\">");

                }
                Sb_Details.Append(base.FormatNumber1(Dtb_Table.Rows[i]["DbcAmount"].ToString(), 0));
                if (s_Ly == "0")
                {
                    Sb_Details.Append("</a>");
                }
                Sb_Details.Append("</td>\n");
                //Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["DbcAmount"].ToString(), 0) + "</td>\n");
                decimal d_DbcPrice = 0;
                try
                {
                    d_DbcTotalNumber += decimal.Parse(Dtb_Table.Rows[i]["DbcAmount"].ToString());
                    d_DbcTotalMoney += decimal.Parse(Dtb_Table.Rows[i]["DbcMoney"].ToString());
                    d_DbcPrice = decimal.Parse(Dtb_Table.Rows[i]["DbrMoney"].ToString()) / decimal.Parse(Dtb_Table.Rows[i]["DbrAmount"].ToString());

                }
                catch { }
                Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(d_DbcPrice.ToString(), 5) + "</td>\n");
                Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["DbcMoney"].ToString(), 2) + "</td>\n");

                try
                {
                    d_TotalTZMoney += decimal.Parse(Dtb_Table.Rows[i]["TZMoney"].ToString());
                }
                catch { }



                //期末
                Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["QMAmount"].ToString(), 0) + "</td>\n");
                decimal d_QMPrice = 0;
                try
                {
                    d_QMTotalNumber += decimal.Parse(Dtb_Table.Rows[i]["QMAmount"].ToString());
                    d_QMTotalMoney += decimal.Parse(Dtb_Table.Rows[i]["QMMoney"].ToString());
                    d_QMPrice = decimal.Parse(Dtb_Table.Rows[i]["QMMoney"].ToString()) / decimal.Parse(Dtb_Table.Rows[i]["QMAmount"].ToString());
                }
                catch { }
                Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(d_QMPrice.ToString(), 5) + "</td>\n");
                Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["QMMoney"].ToString(), 2) + "</td>\n");

                try
                {
                }
                catch
                { }

                if (Btn_Save.Text == "修改")
                {
                    string s_Chekck0 = "", s_Chekck1 = "", s_Chekck2 = "";
                    if (i_ProductsType == 0)
                    {
                        s_Chekck0 = "√";
                    }
                    else if (i_ProductsType == 1)
                    {
                        s_Chekck1 = "√";
                    }
                    else if (i_ProductsType == 2)
                    {
                        s_Chekck2 = "√";
                    }
                    Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>" + s_Chekck0 + "&nbsp; </td>\n");
                    Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>" + s_Chekck1 + "&nbsp;</td>\n");
                    Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>" + s_Chekck2 + "&nbsp;</td>\n");
                    Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + Dtb_Table.Rows[i]["KSP_CwReamrks"].ToString() + "</td>\n");

                }
                else
                {
                    string s_Chekck0 = "Checked", s_Chekck1 = "", s_Chekck2 = "";
                    if (i_ProductsType == 0)
                    {
                        s_Chekck0 = "checked";
                    }
                    else if (i_ProductsType == 1)
                    {
                        s_Chekck1 = "checked";
                    }
                    else if (i_ProductsType == 2)
                    {
                        s_Chekck2 = "checked";
                    }
                    Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap><input type=\"radio\" name=\"radiogroup" + i.ToString() + "\" value=\"0\"  id=\"radiogroup1_0_" + i.ToString() + "\" " + s_Chekck0 + "> </td>\n");
                    Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap><input type=\"hidden\" name=\"Tbx_ProductsBarCode_" + i.ToString() + "\"  value=\"" + Dtb_Table.Rows[i]["ProductsBarCode"].ToString() + "\"><input type=\"radio\" name=\"radiogroup" + i.ToString() + "\" value=\"1\" id=\"radiogroup1_1_" + i.ToString() + "\" " + s_Chekck1 + "></td>\n");
                    Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap><input type=\"radio\" name=\"radiogroup" + i.ToString() + "\" value=\"2\" id=\"radiogroup1_2_" + i.ToString() + "\" " + s_Chekck2 + "></td>\n");
                    Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap><input type=\"input\" name=\"Remarks_" + i.ToString() + "\" id=\"Remarks_" + i.ToString() + "\"  value=\"" + Dtb_Table.Rows[i]["KSP_CwReamrks"].ToString() + "\"></td>\n");

                } Sb_Details.Append(" </tr>\n");
            }
            this.Tbx_Num.Text = Dtb_Table.Rows.Count.ToString();
            Sb_Details.Append(" <tr >\n");
            Sb_Details.Append("<td class='thstyleLeftDetails'align=center noWrap colspan='5'>合计:</td>\n");
            Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_QCTotalNumber.ToString(), 0) + "</td>\n");
            Sb_Details.Append("<td  class='thstyleLeftDetails' align=right noWrap >&nbsp;</td>\n");//money
            Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_QCTotalMoney.ToString(), 2) + "</td>\n");

            Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_ZjTotalNumber.ToString(), 0) + "</td>\n");
            Sb_Details.Append("<td  class='thstyleLeftDetails' align=right noWrap >&nbsp;</td>\n");//money
            Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_ZjTotalMoney.ToString(), 2) + "</td>\n");

            Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_CgTotalNumber.ToString(), 0) + "</td>\n");
            Sb_Details.Append("<td  class='thstyleLeftDetails' align=right noWrap >&nbsp;</td>\n");//money
            Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_CgTotalMoney.ToString(), 2) + "</td>\n");


            Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_WwTotalNumber.ToString(), 0) + "</td>\n");
            Sb_Details.Append("<td  class='thstyleLeftDetails' align=right noWrap >&nbsp;</td>\n");//money
            Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_WwTotalMoney.ToString(), 2) + "</td>\n");


            Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_XhTotalNumber.ToString(), 0) + "</td>\n");
            Sb_Details.Append("<td  class='thstyleLeftDetails' align=right noWrap >&nbsp;</td>\n");//money
            Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_XhTotalMoney.ToString(), 2) + "</td>\n");

            Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_DbrTotalNumber.ToString(), 0) + "</td>\n");
            Sb_Details.Append("<td  class='thstyleLeftDetails' align=right noWrap >&nbsp;</td>\n");//money
            Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_DbrTotalMoney.ToString(), 2) + "</td>\n");

            Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_DbcTotalNumber.ToString(), 0) + "</td>\n");
            Sb_Details.Append("<td  class='thstyleLeftDetails' align=right noWrap >&nbsp;</td>\n");//money
            Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_DbcTotalMoney.ToString(), 2) + "</td>\n");


            Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_QMTotalNumber.ToString(), 0) + "</td>\n");
            Sb_Details.Append("<td  class='thstyleLeftDetails' align=right noWrap >&nbsp;</td>\n");//money
            Sb_Details.Append("<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_QMTotalMoney.ToString(), 2) + "</td>\n");


            Sb_Details.Append("<td  class='thstyleLeftDetails' align=right noWrap colspan=3 >&nbsp;</td>\n");//money


            Sb_Details.Append(" </tr>\n");

        }
        Sb_Details.Append("</table>\n");

        //Sb_Details.Append("</tdead>\n");
        //Sb_Details.Append("</table>\n");

        //Sb_Details.Append("<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n");

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
    /// <summary>
    /// 获取产品类别
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public string productclass(string code)
    {
        string s_return = "";
        this.BeginQuery("select PBP_Name from PB_Basic_ProductsClass  where PBP_ID in (select ProductsType from KNet_Sys_Products where KSP_COde='" + code + "' )");
        this.QueryForDataTable();
        DataTable Dtb_Re = Dtb_Result;
        s_return = Dtb_Re.Rows[0][0].ToString();
        return s_return;
    }
}
