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

            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            string s_StartDate = Request.QueryString["StartDate"] == null ? "" : Request.QueryString["StartDate"].ToString();
            string s_EndDate = Request.QueryString["EndDate"] == null ? "" : Request.QueryString["EndDate"].ToString();
            string s_HouseNo = Request.QueryString["HouseNo"] == null ? "" : Request.QueryString["HouseNo"].ToString();

            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string s_ProductsEdition = Request.QueryString["ProductsEdtion"] == null ? "" : Request.QueryString["ProductsEdtion"].ToString();

            string s_ProductsType = Request.QueryString["ProductsType"] == null ? "" : Request.QueryString["ProductsType"].ToString();
            string s_Sql = "select a.ProductsBarCode,b.ProductsName,b.ProductsEdition,b.ProductsUnits,b.ProductsType,b.KSP_ProdutsType,Sum(case when DirectinDateTime<'" + s_StartDate + "' then DirectInAmount else 0 end)  as QCAmount  ";
            s_Sql += ",Sum(case when DirectinDateTime<'" + s_StartDate + "' then DirectInTotalNet else 0 end)  as QCMoney ";
            s_Sql += ",Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type='102'  then DirectInAmount else 0 end)  as CgAmount ";
            s_Sql += ",Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type='102'  then DirectInTotalNet else 0 end)  as CgMoney ";
            s_Sql += ",Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type='106'  then DirectInAmount else 0 end)  as DbinAmount ";
            s_Sql += ",Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type='106'  then DirectInTotalNet else 0 end)  as DbinMoney ";
            s_Sql += ",Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type='105'  then -DirectInAmount else 0 end)  as DboutAmount ";
            s_Sql += ",Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type='105'  then -DirectInTotalNet else 0 end)  as DboutMoney ";
            s_Sql += ",Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type in ('108')  then -DirectInAmount else 0 end)  as XhAmount ";
            s_Sql += ",Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type in ('108')  then -DirectInTotalNet else 0 end)  as XhMoney ";
            s_Sql += ",Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type in ('104')  then -DirectInAmount else 0 end)  as DbrAmount ";
            s_Sql += ",Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type in ('104') then -DirectInTotalNet else 0 end)  as DbrMoney ";
            s_Sql += ",Sum(case when  DirectinDateTime<='" + s_EndDate + "'   then DirectInAmount else 0 end)  as QMAmount ";
            s_Sql += ",Sum(case when  DirectinDateTime<='" + s_EndDate + "'   then DirectInTotalNet else 0 end)  as QMMoney ";
            s_Sql += " from V_Store a join KNet_Sys_Products b on a.ProductsBarCode=b.ProductsBarCode ";
            s_Sql += " where 1=1 ";

            Lbl_Link.Text = "<a target=\"_blank\" href=\"List_Details1.aspx?EndDate=" + s_EndDate + "&StartDate=" + s_StartDate + "\" >期末金额调整</a>";
            if (s_HouseNo != "")
            {
                s_Sql += " and  a.HouseNo='" + s_HouseNo + "'";
            }
            else
            {
                s_Sql += " and  a.HouseNo in (select HouseNo FROM KNet_Sys_WareHouse  where HouseYN=1 and KSW_Type='1' union all select SuppNo from Knet_Procure_Suppliers where KPS_Type='128860698200781250')";
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
                s_Sql += " and a.ProductsBarCode in(Select ProductsBarCode from KNet_sys_Products where ProductsEdition like '%" + s_ProductsEdition + "%') ";
            }

            s_Sql += " Group by a.ProductsBarCode,b.ProductsName,b.ProductsEdition,b.ProductsUnits,b.ProductsType,b.KSP_ProdutsType ";
            s_Sql += " HAVING Sum(case when DirectinDateTime<'" + s_StartDate + "' then DirectInTotalNet else 0 end)<>0 ";
            s_Sql += " or Sum(case when DirectinDateTime<'" + s_StartDate + "' then DirectInAmount else 0 end)<>0  ";
            s_Sql += " or Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type in ('102')  then DirectInAmount else 0 end)<>0 ";
            s_Sql += " or Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type in ('105')  then DirectInAmount else 0 end)<>0 ";
            s_Sql += " or Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type in ('106')  then DirectInAmount else 0 end)<>0 ";
            s_Sql += " or Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type in ('108')  then DirectInAmount else 0 end)<>0 ";
            s_Sql += " or Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type in ('104')  then DirectInAmount else 0 end)<>0 ";
            s_Sql += " or Sum(case when DirectinDateTime<='" + s_EndDate + "' then DirectInAmount else 0 end)<>0  ";
            s_Sql += " or Sum(case when  DirectinDateTime<='" + s_EndDate + "'   then DirectInTotalNet else 0 end)<>0 ";
            s_Sql += " order by b.ProductsName,b.ProductsEdition,b.ProductsType ";
            string s_Style = "";
            string s_Head = "";
            decimal d_QCTotalNumber = 0, d_QCTotalMoney = 0;
            decimal d_CgTotalNumber = 0, d_CgTotalMoney = 0;
            decimal d_WwTotalNumber = 0, d_WwTotalMoney = 0;
            decimal d_DbrTotalNumber = 0, d_DbrTotalMoney = 0;
            decimal d_QMTotalNumber = 0, d_QMTotalMoney = 0;
            decimal d_XhTotalNumber = 0, d_XhTotalMoney = 0;
            decimal d_outTotalNumber = 0, d_outTotalMoney = 0;

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
                    s_Details += " <tr " + s_Style + " onmouseover='setActiveBG(this)'>\n";
                    s_Details += "<td class='thstyleLeftDetails'align=center noWrap>" + (i + 1).ToString() + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>" + Dtb_Table.Rows[i]["ProductsName"].ToString() + "</td>\n";
                    string s_ProductsEdition1 = Dtb_Table.Rows[i]["ProductsEdition"].ToString();
                    if (Dtb_Table.Rows[i]["ProductsType"].ToString() == "M130703044953260")
                    {
                        s_ProductsEdition1 = base.Base_GetProductsPattern(Dtb_Table.Rows[i]["ProductsBarCode"].ToString()) + "_" + s_ProductsEdition1;
                    }
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>" + s_ProductsEdition1 + "&nbsp;</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>" + base.Base_GetUnitsName(Dtb_Table.Rows[i]["ProductsUnits"].ToString()) + "</td>\n";
                    //期初
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(Dtb_Table.Rows[i]["QCAmount"].ToString(), 0) + "</td>\n";
                    decimal d_QcPrice = 0;
                    try
                    {
                        d_QCTotalNumber += decimal.Parse(Dtb_Table.Rows[i]["QCAmount"].ToString());
                        d_QCTotalMoney += decimal.Parse(Dtb_Table.Rows[i]["QCMoney"].ToString());
                        d_QcPrice = decimal.Parse(Dtb_Table.Rows[i]["QCMoney"].ToString()) / decimal.Parse(Dtb_Table.Rows[i]["QCAmount"].ToString());

                    }
                    catch { }
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(d_QcPrice.ToString(), 5) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["QCMoney"].ToString(), 2) + "</td>\n";

                    //采购
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["CgAmount"].ToString(), 0) + "</td>\n";
                    decimal d_CgPrice = 0;
                    try
                    {
                        d_CgTotalNumber += decimal.Parse(Dtb_Table.Rows[i]["CgAmount"].ToString());
                        d_CgTotalMoney += decimal.Parse(Dtb_Table.Rows[i]["CgMoney"].ToString());
                        d_CgPrice = decimal.Parse(Dtb_Table.Rows[i]["CgMoney"].ToString()) / decimal.Parse(Dtb_Table.Rows[i]["CgAmount"].ToString());

                    }
                    catch { }
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(d_CgPrice.ToString(), 5) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["CgMoney"].ToString(), 2) + "</td>\n";

                    //调拨入
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["DbinAmount"].ToString(), 0) + "</td>\n";
                    decimal d_WwPrice = 0;
                    try
                    {
                        d_WwTotalNumber += decimal.Parse(Dtb_Table.Rows[i]["DbinAmount"].ToString());
                        d_WwTotalMoney += decimal.Parse(Dtb_Table.Rows[i]["DbinMoney"].ToString());
                        d_WwPrice = decimal.Parse(Dtb_Table.Rows[i]["DbinMoney"].ToString()) / decimal.Parse(Dtb_Table.Rows[i]["DbinAmount"].ToString());

                    }
                    catch { }
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(d_WwPrice.ToString(), 5) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["DbinMoney"].ToString(), 2) + "</td>\n";

                    //消耗
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["XhAmount"].ToString(), 0) + "</td>\n";
                    decimal d_XhPrice = 0;
                    try
                    {
                        d_XhTotalNumber += decimal.Parse(Dtb_Table.Rows[i]["XhAmount"].ToString());
                        d_XhTotalMoney += decimal.Parse(Dtb_Table.Rows[i]["XhMoney"].ToString());
                        d_XhPrice = decimal.Parse(Dtb_Table.Rows[i]["XhMoney"].ToString()) / decimal.Parse(Dtb_Table.Rows[i]["XhAmount"].ToString());

                    }
                    catch { }
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(d_XhPrice.ToString(), 5) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["XhMoney"].ToString(), 2) + "</td>\n";

                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["DbrAmount"].ToString(), 0) + "</td>\n";
                    decimal d_DbrPrice = 0;
                    try
                    {
                        d_DbrTotalNumber += decimal.Parse(Dtb_Table.Rows[i]["DbrAmount"].ToString());
                        d_DbrTotalMoney += decimal.Parse(Dtb_Table.Rows[i]["DbrMoney"].ToString());
                        d_DbrPrice = decimal.Parse(Dtb_Table.Rows[i]["DbrMoney"].ToString()) / decimal.Parse(Dtb_Table.Rows[i]["DbrAmount"].ToString());

                    }
                    catch { }
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(d_DbrPrice.ToString(), 5) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["DbrMoney"].ToString(), 2) + "</td>\n";

                    //调出
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["DboutAmount"].ToString(), 0) + "</td>\n";
                    decimal d_outPrice = 0;
                    try
                    {
                        d_outTotalNumber += decimal.Parse(Dtb_Table.Rows[i]["DboutAmount"].ToString());
                        d_outTotalMoney += decimal.Parse(Dtb_Table.Rows[i]["DboutMoney"].ToString());
                        d_outPrice = decimal.Parse(Dtb_Table.Rows[i]["DboutMoney"].ToString()) / decimal.Parse(Dtb_Table.Rows[i]["DboutAmount"].ToString());

                    }
                    catch { }
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(d_outPrice.ToString(), 5) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["DboutMoney"].ToString(), 2) + "</td>\n";

                    //期末
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["QMAmount"].ToString(), 0) + "</td>\n";
                    decimal d_QMPrice = 0;
                    try
                    {
                        d_QMTotalNumber += decimal.Parse(Dtb_Table.Rows[i]["QMAmount"].ToString());
                        d_QMTotalMoney += decimal.Parse(Dtb_Table.Rows[i]["QMMoney"].ToString());
                        d_QMPrice = decimal.Parse(Dtb_Table.Rows[i]["QMMoney"].ToString()) / decimal.Parse(Dtb_Table.Rows[i]["QMAmount"].ToString());
                    }
                    catch { }
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(d_QMPrice.ToString(), 5) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["QMMoney"].ToString(), 2) + "</td>\n";

                    try
                    {
                    }
                    catch
                    { }
                    string s_Chekck0 = "Checked", s_Chekck1 = "", s_Chekck2="";
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
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap><input type=\"radio\" name=\"radiogroup" + i.ToString() + "\" value=\"0\"  id=\"radiogroup1_0_" + i.ToString() + "\" " + s_Chekck0 + "> </td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap><input type=\"hidden\" name=\"Tbx_ProductsBarCode_" + i.ToString() + "\"  value=\"" + Dtb_Table.Rows[i]["ProductsBarCode"].ToString() + "\"><input type=\"radio\" name=\"radiogroup" + i.ToString() + "\" value=\"1\" id=\"radiogroup1_1_" + i.ToString() + "\" " + s_Chekck1 + "></td>\n";

                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap><input type=\"radio\" name=\"radiogroup" + i.ToString() + "\" value=\"2\" id=\"radiogroup1_2_" + i.ToString() + "\" " + s_Chekck2 + "></td>\n";
                    s_Details += " </tr>";
                }
                this.Tbx_Num.Text = Dtb_Table.Rows.Count.ToString();
                s_Details += " <tr >\n";
                s_Details += "<td class='thstyleLeftDetails'align=center noWrap colspan='4'>合计:</td>\n";
                s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_QCTotalNumber.ToString(), 0) + "</td>\n";
                s_Details += "<td  class='thstyleLeftDetails' align=right noWrap >&nbsp;</td>\n";//money
                s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_QCTotalMoney.ToString(), 2) + "</td>\n";

                s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_CgTotalNumber.ToString(), 0) + "</td>\n";
                s_Details += "<td  class='thstyleLeftDetails' align=right noWrap >&nbsp;</td>\n";//money
                s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_CgTotalMoney.ToString(), 2) + "</td>\n";

                s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_WwTotalNumber.ToString(), 0) + "</td>\n";
                s_Details += "<td  class='thstyleLeftDetails' align=right noWrap >&nbsp;</td>\n";//money
                s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_WwTotalMoney.ToString(), 2) + "</td>\n";

                s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_XhTotalNumber.ToString(), 0) + "</td>\n";
                s_Details += "<td  class='thstyleLeftDetails' align=right noWrap >&nbsp;</td>\n";//money
                s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_XhTotalMoney.ToString(), 2) + "</td>\n";

                s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_DbrTotalNumber.ToString(), 0) + "</td>\n";
                s_Details += "<td  class='thstyleLeftDetails' align=right noWrap >&nbsp;</td>\n";//money
                s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_DbrTotalMoney.ToString(), 2) + "</td>\n";

                s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_outTotalNumber.ToString(), 0) + "</td>\n";
                s_Details += "<td  class='thstyleLeftDetails' align=right noWrap >&nbsp;</td>\n";//money
                s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_outTotalMoney.ToString(), 2) + "</td>\n";

                s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_QMTotalNumber.ToString(), 0) + "</td>\n";
                s_Details += "<td  class='thstyleLeftDetails' align=right noWrap >&nbsp;</td>\n";//money
                s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_QMTotalMoney.ToString(), 2) + "</td>\n";
                s_Details += "<td  class='thstyleLeftDetails' align=right noWrap colspan=2 >&nbsp;</td>\n";//money


                s_Details += " </tr>";

            }
            s_Details += "</tbody></table></td></tr>";
            s_Time = "日期:" + s_StartDate + " 到" + s_EndDate;
            s_HouseName = "入库仓库:" + base.Base_GetHouseName(s_HouseNo);

            s_Head += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n";
            s_Head += "<tr>\n<th colspan=\"26\" class=\"MaterTitle\" style='height:14.25pt'>杭州士腾科技有限公司<br/>存货收发结存表单</th></tr>\n";
            s_Head += "<tr>\n<th colspan=\"13\" class=\"thstyleleft\"  >" + s_HouseName + "</th>";
            s_Head += "<th colspan=\"13\" class=\"thstyleRight\" >" + s_Time + "</th></tr>\n";
            s_Head += "</table>\n";
            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n";

            s_Head += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n";
            s_Head += "<thead class=\"fixedHeader\"> \n";
            s_Head += "<tr><th class=\"thstyle\"  align=center  rowspan=\"2\" colspan=\"1\">序号</th>\n";
            s_Head += "<th class=\"thstyle\"  align=center rowspan=\"2\" colspan=\"1\">品名</th>\n";
            s_Head += "<th class=\"thstyle\"  align=center rowspan=\"2\" colspan=\"1\">规格</th>\n";
            s_Head += "<th class=\"thstyle\" align=center rowspan=\"2\" colspan=\"1\">单位</th>\n";
            s_Head += "<th class=\"thstyle\" align=center colspan=\"3\">期初</th>\n";
            s_Head += "<th class=\"thstyle\" align=center colspan=\"3\">采购入库</th>\n";
            s_Head += "<th class=\"thstyle\" align=center colspan=\"3\">调拨入库</th>\n";
            s_Head += "<th class=\"thstyle\" align=center colspan=\"3\">生产出库</th>\n";
            s_Head += "<th class=\"thstyle\" align=center colspan=\"3\">部门领用</th>\n";
            s_Head += "<th class=\"thstyle\" align=center colspan=\"3\">调拨出库</th>\n";
            s_Head += "<th class=\"thstyle\" align=center colspan=\"3\">期末</th>\n";
            s_Head += "<th class=\"thstyle\" align=center colspan=\"3\">产品状态</th>\n</tr>";
            s_Head += "<tr>\n";
            s_Head += "<th class=\"thstyle\" align=center >数量</th>\n";
            s_Head += "<th class=\"thstyle\" align=center >单价</th>\n";
            s_Head += "<th class=\"thstyle\" align=center >金额</th>\n";
            s_Head += "<th class=\"thstyle\" align=center >数量</th>\n";
            s_Head += "<th class=\"thstyle\" align=center >单价</th>\n";
            s_Head += "<th class=\"thstyle\" align=center >金额</th>\n";
            s_Head += "<th class=\"thstyle\" align=center >数量</th>\n";
            s_Head += "<th class=\"thstyle\" align=center >单价</th>\n";
            s_Head += "<th class=\"thstyle\" align=center >金额</th>\n";
            s_Head += "<th class=\"thstyle\" align=center >数量</th>\n";
            s_Head += "<th class=\"thstyle\" align=center >单价</th>\n";
            s_Head += "<th class=\"thstyle\" align=center >金额</th>\n";
            s_Head += "<th class=\"thstyle\" align=center >数量</th>\n";
            s_Head += "<th class=\"thstyle\" align=center >单价</th>\n";
            s_Head += "<th class=\"thstyle\" align=center >金额</th>\n";
            s_Head += "<th class=\"thstyle\" align=center >数量</th>\n";
            s_Head += "<th class=\"thstyle\" align=center >单价</th>\n";
            s_Head += "<th class=\"thstyle\" align=center >金额</th>\n";
            s_Head += "<th class=\"thstyle\" align=center >数量</th>\n";
            s_Head += "<th class=\"thstyle\" align=center >单价</th>\n";
            s_Head += "<th class=\"thstyle\" align=center >金额</th>\n";
            s_Head += "<th class=\"thstyle\" align=center >正常</th>\n";
            s_Head += "<th class=\"thstyle\" align=center >滞销</th>\n";
            s_Head += "<th class=\"thstyle\" align=center >呆滞</th>\n";
            s_Head += "</tr>\n";
            s_Head += "</thead>\n";

            s_Head += "<tbody class=\"scrollContent\">";
            s_Details += "</div>";
            this.Lbl_Details.Text = s_Head + s_Details;
        }
    }

    protected void Btn_SaveOnClick(object sender, EventArgs e)
    {
         
        AdminloginMess AM = new AdminloginMess();

        try
        {
            int i_Num = int.Parse(this.Tbx_Num.Text);
            for (int i = 0; i < i_Num; i++)
            {
                string s_ProductsBarCode = Request["Tbx_ProductsBarCode_" + i.ToString() + ""] == null ? "" : Request["Tbx_ProductsBarCode_" + i.ToString() + ""].ToString();
                //更新委外价格
                string s_radio0 = Request["radiogroup" + i.ToString() + ""] == null ? "" : Request["radiogroup" + i.ToString() + ""].ToString();
                if ((s_radio0 == "1") || (s_radio0 == "2"))
                {
                    string s_Sql = "update KNet_Sys_Products set KSP_ProdutsType=" + s_radio0 + " where ProductsBarCode='" + s_ProductsBarCode + "' ";
                    DbHelperSQL.ExecuteSql(s_Sql);

                    AM.Add_Logs("产品状态修改:" + s_ProductsBarCode);
                }
                else
                {
                    string s_Sql = "update KNet_Sys_Products set KSP_ProdutsType=" + s_radio0 + " where ProductsBarCode='" + s_ProductsBarCode + "' ";
                    DbHelperSQL.ExecuteSql(s_Sql);
                }

            }
            Alert("保存成功！");
            RefreshOpener();
        }
        catch (Exception ex)
        {
            Alert(ex.Message);
        }

    }
}
