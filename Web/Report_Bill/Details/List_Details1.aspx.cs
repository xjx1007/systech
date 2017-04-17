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
            this.Tbx_StartDate.Text = s_StartDate;
            this.Tbx_EndDate.Text = s_EndDate;
            string s_ProductsType = Request.QueryString["ProductsType"] == null ? "" : Request.QueryString["ProductsType"].ToString();
            string s_Sql = "select a.ProductsBarCode,b.ProductsName,b.ProductsEdition,b.ProductsUnits,b.ProductsType,a.HouseNo,Sum(case when DirectinDateTime<'" + s_StartDate + "' then DirectInAmount else 0 end)  as QCAmount  ";
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
            s_Sql += " where 1=1 and b.KSP_Code not like '01%'  ";
            s_Sql += " and a.HouseNo in (Select HouseNO from  KNet_Sys_WareHouse where HouseYN=1)";
            if (s_HouseNo != "")
            {
                s_Sql += " and  a.HouseNo='" + s_HouseNo + "'";
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

            s_Sql += " Group by  a.HouseNo,a.ProductsBarCode,b.ProductsName,b.ProductsEdition,b.ProductsUnits,b.ProductsType ";
            s_Sql += " HAVING  Sum(case when DirectinDateTime<='" + s_EndDate + "' then DirectInAmount else 0 end)=0 ";
            s_Sql += " and Sum(case when  DirectinDateTime<='" + s_EndDate + "'   then DirectInTotalNet else 0 end)<>0 ";
            s_Sql += " order by  a.HouseNo,b.ProductsName,b.ProductsEdition,b.ProductsType ";
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
                    s_Details += " <tr " + s_Style + " onmouseover='setActiveBG(this)'>\n";
                    s_Details += "<td class='thstyleLeftDetails'align=center noWrap>" + (i + 1).ToString() + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>" + Dtb_Table.Rows[i]["ProductsName"].ToString() + "</td>\n";
                    string s_ProductsEdition1 = Dtb_Table.Rows[i]["ProductsEdition"].ToString();
                    if (Dtb_Table.Rows[i]["ProductsType"].ToString() == "M130703044953260")
                    {
                        s_ProductsEdition1 = base.Base_GetProductsPattern(Dtb_Table.Rows[i]["ProductsBarCode"].ToString()) + "_" + s_ProductsEdition1;
                    }
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap><input type=\"hidden\" name=\"ProductsBarCode_" + i.ToString() + "\" value=\"" + Dtb_Table.Rows[i]["ProductsBarCode"].ToString() + "\" >" + s_ProductsEdition1 + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>" + base.Base_GetUnitsName(Dtb_Table.Rows[i]["ProductsUnits"].ToString()) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap><input type=\"hidden\" name=\"HouseNo_" + i.ToString() + "\" value=\"" + Dtb_Table.Rows[i]["HouseNo"].ToString() + "\" >" + base.Base_GetHouseName(Dtb_Table.Rows[i]["HouseNo"].ToString()) + "</td>\n";
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
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap><input type=\"hidden\" name=\"QmMoney_" + i.ToString() + "\" value=\"" + base.FormatNumber1(Dtb_Table.Rows[i]["QMMoney"].ToString(), 2) + "\" >" + base.FormatNumber1(Dtb_Table.Rows[i]["QMMoney"].ToString(), 2) + "</td>\n";

                    s_Details += " </tr>";
                }
                s_Details += " <tr >\n";
                s_Details += "<td class='thstyleLeftDetails'align=center noWrap colspan='5'>合计:</td>\n";
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


                s_Details += " </tr>";

            }
            this.Tbx_Num.Text = Dtb_Table.Rows.Count.ToString();
            s_Details += "</tbody></table></td></tr>";
            s_Time = "日期:" + s_StartDate + " 到" + s_EndDate;
            s_HouseName = "";// "入库仓库:" + base.Base_GetHouseName(s_HouseNo);
            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n";
            s_Head += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\"> \n";
            s_Head += "<tr>\n<th colspan=\"26\" class=\"MaterTitle\" style='height:14.25pt'>杭州士腾科技有限公司<br/>期末金额调整单</th></tr>\n";
            s_Head += "<tr>\n<th colspan=\"13\" class=\"thstyleleft\"  >" + s_HouseName + "</th><th colspan=\"13\" class=\"thstyleRight\" >" + s_Time + "</th></tr>\n";
            s_Head += "<th class=\"thstyle\"  align=center rowspan=2>序号</th>\n";
            s_Head += "<th class=\"thstyle\"  align=center rowspan=2>品名</th>\n";
            s_Head += "<th class=\"thstyle\"  align=center rowspan=2>规格</th>\n";
            s_Head += "<th class=\"thstyle\" align=center rowspan=2>单位</th>\n";
            s_Head += "<th class=\"thstyle\" align=center rowspan=2>仓库</th>\n";
            s_Head += "<th class=\"thstyle\" align=center colspan=3>期初</th>\n";
            s_Head += "<th class=\"thstyle\" align=center colspan=3>采购入库</th>\n";
            s_Head += "<th class=\"thstyle\" align=center colspan=3>调拨入库</th>\n";
            s_Head += "<th class=\"thstyle\" align=center colspan=3>生产出库</th>\n";
            s_Head += "<th class=\"thstyle\" align=center colspan=3>部门领用</th>\n";
            s_Head += "<th class=\"thstyle\" align=center colspan=3>调拨出库</th>\n";
            s_Head += "<th class=\"thstyle\" align=center colspan=3>期末</th>\n</tr>";
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
            s_Head += "</tr>\n";
            s_Head += "</thead><tbody class=\"scrollContent\">";
            s_Details += "</div>";
            this.Lbl_Details.Text = s_Head + s_Details;
        }
    }




    private bool SetValue(KNet.Model.Sc_Expend_Manage model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            model.SEM_ID = base.GetNewID("Sc_Expend_Manage", 1);
            try
            {
                model.SEM_Stime = DateTime.Parse(this.Tbx_EndDate.Text);
            }
            catch { }
            model.SEM_SuppNo = "";
            model.SEM_CustomerName = "";
            model.SEM_DutyPerson = AM.KNet_StaffNo;
            model.SEM_ProductsEdition = "";
            try
            {
                model.SEM_RkTime = DateTime.Parse(this.Tbx_EndDate.Text);
            }
            catch { }
            try
            {
                model.SEM_WwTime = DateTime.Parse(this.Tbx_EndDate.Text);
            }
            catch { }
            model.SEM_RkPerson = AM.KNet_StaffNo;
            model.SEM_WwPerson = AM.KNet_StaffNo;
            model.SEM_Remarks = "";
            model.SEM_Creator = AM.KNet_StaffNo;
            model.SEM_CTime = DateTime.Now;
            model.SEM_Mendor = AM.KNet_StaffNo;
            model.SEM_MTime = DateTime.Now;

            ///成品消耗
            ArrayList arr_RcDetails = new ArrayList();
            int i_Num = 0;
            KNet.Model.Sc_Expend_Manage_RCDetails Mode_RkDetails = new KNet.Model.Sc_Expend_Manage_RCDetails();
            Mode_RkDetails.SER_ID = base.GetNewID("Sc_Expend_Manage_RCDetails", 1);

            Mode_RkDetails.SER_ProductsBarCode = "";
            Mode_RkDetails.SER_OrderDetailID = "";
            Mode_RkDetails.SER_ScNumber = 0;
            Mode_RkDetails.SER_ScPrice = 0;
            Mode_RkDetails.SER_ScHandPrice = 0;
            Mode_RkDetails.SER_ScMoney = 0;
            Mode_RkDetails.SER_ScHandMoney = 0;
            Mode_RkDetails.SER_SEMID = model.SEM_ID;
            Mode_RkDetails.SER_HouseNo = "";
            arr_RcDetails.Add(Mode_RkDetails);
            model.arr_Details = arr_RcDetails;

            ///物料消耗
            ArrayList arr_MaterDetails = new ArrayList();
            for (int i = 0; i < int.Parse(this.Tbx_Num.Text); i++)
            {
                //原材料入库
                //DropDownList Ddl_RkHouse = (DropDownList)MyGridView2.Rows[i].Cells[0].FindControl("Ddl_RkHouse");
                string s_HouseNo = Request["HouseNo_" + i.ToString() + ""] == null ? "" : Request["HouseNo_" + i.ToString() + ""].ToString();
                string s_ProductsBarCode = Request["ProductsBarCode_" + i.ToString() + ""] == null ? "" : Request["ProductsBarCode_" + i.ToString() + ""].ToString();
                string s_Money = Request["QmMoney_" + i.ToString() + ""] == null ? "" : Request["QmMoney_" + i.ToString() + ""].ToString();

                string SED_RkPrice = "0";
                KNet.Model.Sc_Expend_Manage_MaterDetails Mode_MaterDetails = new KNet.Model.Sc_Expend_Manage_MaterDetails();

                Mode_MaterDetails.SED_SEMID = model.SEM_ID;
                Mode_MaterDetails.SED_HouseNo = s_HouseNo;
                Mode_MaterDetails.SED_ProductsBarCode = s_ProductsBarCode;
                Mode_MaterDetails.SED_Remarks = "";
                try
                {
                    Mode_MaterDetails.SED_RkNumber = 0;
                }
                catch { }
                try
                {
                    Mode_MaterDetails.SED_RkPrice = decimal.Parse(SED_RkPrice);
                }
                catch { }
                try
                {
                    Mode_MaterDetails.SED_RkMoney = decimal.Parse(s_Money);
                }
                catch { }
                Mode_MaterDetails.SED_RkPerson = AM.KNet_StaffNo;
                try
                {
                    Mode_MaterDetails.SED_RkTime = DateTime.Parse(this.Tbx_EndDate.Text);
                }
                catch { }
                Mode_MaterDetails.SED_Type = 0;
                arr_MaterDetails.Add(Mode_MaterDetails);
                //委外发料
                KNet.Model.Sc_Expend_Manage_MaterDetails Mode_MaterDetails1 = new KNet.Model.Sc_Expend_Manage_MaterDetails();
                Mode_MaterDetails1.SED_SEMID = model.SEM_ID;
                Mode_MaterDetails1.SED_HouseNo = s_HouseNo;
                Mode_MaterDetails1.SED_ProductsBarCode = s_ProductsBarCode;
                Mode_MaterDetails1.SED_Remarks = "";
                try
                {
                    Mode_MaterDetails1.SED_RkNumber = 0;
                }
                catch { }
                try
                {
                    Mode_MaterDetails1.SED_RkPrice = decimal.Parse(SED_RkPrice);
                }
                catch { }
                try
                {
                    Mode_MaterDetails1.SED_RkMoney = decimal.Parse(s_Money);
                }
                catch { }
                Mode_MaterDetails1.SED_RkPerson = AM.KNet_StaffNo;
                try
                {
                    Mode_MaterDetails1.SED_RkTime = DateTime.Parse(this.Tbx_EndDate.Text);
                }
                catch { }
                Mode_MaterDetails1.SED_Type = 1;
                arr_MaterDetails.Add(Mode_MaterDetails1);

                //生产入库
                KNet.Model.Sc_Expend_Manage_MaterDetails Mode_MaterDetails2 = new KNet.Model.Sc_Expend_Manage_MaterDetails();
                Mode_MaterDetails2.SED_SEMID = model.SEM_ID;
                Mode_MaterDetails2.SED_HouseNo = s_HouseNo;
                Mode_MaterDetails2.SED_ProductsBarCode = s_ProductsBarCode;
                Mode_MaterDetails2.SED_Remarks = "";
                try
                {
                    Mode_MaterDetails2.SED_RkNumber = 0;
                }
                catch { }
                try
                {
                    Mode_MaterDetails2.SED_RkPrice = decimal.Parse(SED_RkPrice);
                }
                catch { }
                try
                {
                    Mode_MaterDetails2.SED_RkMoney = decimal.Parse(s_Money);
                }
                catch { }
                Mode_MaterDetails2.SED_RkPerson = AM.KNet_StaffNo;
                try
                {
                    Mode_MaterDetails2.SED_RkTime = DateTime.Parse(this.Tbx_EndDate.Text);
                }
                catch { }
                Mode_MaterDetails2.SED_Type = 2;
                arr_MaterDetails.Add(Mode_MaterDetails2);
            }
            model.arr_MaterDetails = arr_MaterDetails;

            return true;
        }
        catch
        {
            return false;
        }
    }


    protected void Btn_SaveOnClick(object sender, EventArgs e)
    {

        AdminloginMess AM = new AdminloginMess();

        KNet.Model.Sc_Expend_Manage model = new KNet.Model.Sc_Expend_Manage();
        KNet.BLL.Sc_Expend_Manage bll = new KNet.BLL.Sc_Expend_Manage();

        if (this.SetValue(model) == false)
        {
            Alert("系统错误！");
            return;
        }
        else
        {
            try
            {
                bll.Add(model);
                AM.Add_Logs("期末金额调整生产入库增加" + model.SEM_ID);

                //更新委外价格
                string s_Sql = "update Sc_Expend_Manage set SEM_CheckYN=2 where SEM_ID='" + model.SEM_ID + "' ";
                s_Sql += "update Sc_Expend_Manage_MaterDetails set SED_WwMoney=SED_RkMoney where SED_SEMID='" + model.SEM_ID + "'";
                DbHelperSQL.ExecuteSql(s_Sql);

                //base.Base_SendMessage(base.Base_GetDeptPerson("供应链平台", 1), "生产入库增加： <a href='Web/ScExpend/Sc_Expend_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.SEM_ID + "</a> 需要你审批！ ");
                AlertAndRedirect("新增成功！", "List_Details1.aspx?EndDate=" + this.Tbx_EndDate.Text + "&StartDate=" + this.Tbx_StartDate.Text + "");
            }
            catch (Exception ex)
            {
                Alert(ex.Message);
            }
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {

        try
        {
            AdminloginMess AM = new AdminloginMess();

            string sql1 = " delete from Sc_Expend_Manage_MaterDetails where SED_SEMID in (Select SEM_ID in  from Sc_Expend_Manage  where SEM_SuppNo='' and SEM_STime='" + DateTime.Parse(this.Tbx_EndDate.Text) + "' )"; //发货 明细
            string sql2 = " delete from Sc_Expend_Manage_RCDetails where SER_SEMID in (Select SEM_ID in  from Sc_Expend_Manage  where SEM_SuppNo='' and SEM_STime='" + DateTime.Parse(this.Tbx_EndDate.Text) + "' ) "; //发货 明细
            DbHelperSQL.ExecuteSql(sql1);
            DbHelperSQL.ExecuteSql(sql2);
            string sql = "delete from Sc_Expend_Manage where  where SEM_SuppNo='' and SEM_STime='" + DateTime.Parse(this.Tbx_EndDate.Text) + "' "; //删除生产消耗
            DbHelperSQL.ExecuteSql(sql);
            AlertAndRedirect("调整删除！", "List_Details1.aspx?EndDate=" + this.Tbx_EndDate.Text + "&StartDate=" + this.Tbx_StartDate.Text + "");

            AM.Add_Logs("期末金额调整删除");

        }
        catch (Exception ex)
        { }
    }
}
