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

public partial class Web_Procure_Xh_View : BasePage
{
    public string s_Time = "";
    public string s_HouseName = "";
    public string s_Details = "", s_view="";
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
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
             s_view = Request.QueryString["view"] == null ? "" : Request.QueryString["view"].ToString();

             this.Tbx_View.Text = s_view;
            string s_Style = "", s_ProductsBasicCode = "";
            decimal d_TotalNumber = 0, d_TotalNet = 0;
            string s_Head = "";
            //原材料委外耗料
            string s_Sql = "";
            //明细
            KNet.BLL.KNet_WareHouse_AllocateList BLL = new KNet.BLL.KNet_WareHouse_AllocateList();
            KNet.Model.KNet_WareHouse_AllocateList Model = BLL.GetModelB(s_ID);
            s_Sql = "Select b.ProductsBarCode,";
            if (this.Tbx_View.Text != "1")
            {
                s_Sql += "KWAD_FaterBarCode,";
            }
            s_Sql += "sum(AllocateAmount) AllocateAmount,AllocateUnitPrice,a.AllocateRemarks ";

            s_Sql += " from KNet_WareHouse_AllocateList  a  join KNet_WareHouse_AllocateList_Details b on a.AllocateNo=b.AllocateNo ";
            s_Sql += " join KNET_Sys_Products  c on c.ProductsBarCode=b.ProductsBarCode  ";
            s_Sql += " join PB_Basic_ProductsClass  d on c.ProductsType=d.PBP_ID  ";
            s_Sql += "  Where a.AllocateNo='" + s_ID + "' ";
            s_Sql += "  group by  b.ProductsBarCode,c.ProductsName,AllocateUnitPrice,a.AllocateRemarks ";
            if (this.Tbx_View.Text != "1")
            {
                s_Sql += " ,KWAD_FaterBarCode";
            }
            s_Sql += "  order by c.ProductsName ";


            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
                    s_ProductsBasicCode = base.Base_GetProductsCode(Dtb_Table.Rows[i]["ProductsBarCode"].ToString());
                    decimal d_Money = 0;
                    if (i % 2 == 0)
                    {
                        s_Style = "class='gg'";
                    }
                    else
                    {
                        s_Style = "class='rr'";
                    }
                    s_Details += " <tr " + s_Style + ">\n";
                    s_Details += "<td class='thstyleLeftDetails'align=center >" + (i + 1).ToString() + "</td>\n";
                    s_Details += "<td class='thstyleLeftDetails'align=center >" + base.Base_GetProdutsName(Dtb_Table.Rows[i]["ProductsBarCode"].ToString()) + "</td>\n";
                    s_Details += "<td class='thstyleLeftDetails'align=center >" + base.Base_GetProductsCode(Dtb_Table.Rows[i]["ProductsBarCode"].ToString()) + "</td>\n";

                    if (base.Base_GetProdutsName(Dtb_Table.Rows[i]["ProductsBarCode"].ToString()).IndexOf("芯") > 0)
                    {
                        s_Details += "<td  class='thstyleLeftDetails'align=center >" + base.Base_GetProductsPattern(Dtb_Table.Rows[i]["ProductsBarCode"].ToString()) + "</td>\n";
                    }
                    else
                    {
                        s_Details += "<td  class='thstyleLeftDetails'align=center >" + base.Base_GetProductsEdition(Dtb_Table.Rows[i]["ProductsBarCode"].ToString()) + "</td>\n";
                    }
                    try{
                        if (this.Tbx_View.Text != "1")
                        {
                            s_Details += "<td  class='thstyleLeftDetails'align=center >" + base.Base_GetProductsEdition(Dtb_Table.Rows[i]["KWAD_FaterBarCode"].ToString()) + "</td>\n";
                        }
                    }
                    catch{}
                    
                    s_Details += "<td class='thstyleLeftDetails' align=center >" + base.Base_GetUnitsName(base.Base_GetProductsUnits(Dtb_Table.Rows[i]["ProductsBarCode"].ToString())) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  >&nbsp;" + base.FormatNumber1(Dtb_Table.Rows[i]["AllocateAmount"].ToString(), 0) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  >&nbsp;" + base.FormatNumber1(Dtb_Table.Rows[i]["AllocateUnitPrice"].ToString(), 2) + "</td>\n";
                     try
                    {
                         d_Money = decimal.Parse(Dtb_Table.Rows[i]["AllocateAmount"].ToString()) * decimal.Parse(Dtb_Table.Rows[i]["AllocateUnitPrice"].ToString());
                        s_Details += "<td  class='thstyleLeftDetails' align=right  >&nbsp;" + base.FormatNumber1(d_Money.ToString(), 2) + "</td>\n";
                    }
                    catch
                    { }
                     s_Details += "<td  class='thstyleLeftDetails' align=center >&nbsp;" + Dtb_Table.Rows[i]["AllocateRemarks"].ToString() + "</td>\n";
                    s_Details += " </tr>";
                    try
                    {
                        d_TotalNumber += decimal.Parse(Dtb_Table.Rows[i]["AllocateAmount"].ToString());
                        d_TotalNet += d_Money;
                    }
                    catch
                    {
                    }
                }
                s_Details += " <tr >\n";
                s_Details += "<td class='thstyleBootDetails'align=center  colspan='5'>合计:</td>\n";
                s_Details += "<td class='thstyleBootDetails' align=right  >&nbsp;" + base.FormatNumber1(d_TotalNumber.ToString(), 0) + "</td>\n";
                s_Details += "<td class='thstyleBootDetails' align=right >&nbsp;</td>\n";//money
                s_Details += "<td class='thstyleBootDetails' align=right  >&nbsp;" + base.FormatNumber1(d_TotalNet.ToString(), 2) + "</td>\n";
                s_Details += "<td class='thstyleBootDetails' align=right >&nbsp;</td>\n";//money
                s_Details += " </tr>";
            }
            string s_Depart = "部门：" + base.Base_GeDept(AM.KNet_StaffDepart);
            string s_StaffName = "制单人：" + AM.KNet_StaffName;

            string s_LyType = "";
            if (s_ProductsBasicCode.IndexOf("01") == 0)
            {
                s_LyType = "成品";
            }
            else
            {
                s_LyType = "原材料";

            }
            s_Details += "<tr>\n<td colspan=\"5\" class=\"thstyleleft\"  >" + s_Depart + "</td><td colspan=\"5\" class=\"thstyleRight\" >" + s_StaffName + "</td></tr>\n";

            s_Details += "</tbody></table></td></tr>";
            KNet.BLL.KNet_Sys_WareHouse bll = new KNet.BLL.KNet_Sys_WareHouse();
            KNet.Model.KNet_Sys_WareHouse Model_WareHouse = bll.GetModel(Model.HouseNo_int);
            KNet.Model.KNet_Sys_WareHouse Model_WareHouse1 = bll.GetModel(Model.HouseNo);
            string s_HouseInName = "调拨入库：" + base.Base_GetHouseName(Model_WareHouse.SuppNo);
            string s_HouseName = "调拨出库：" + base.Base_GetHouseName(Model_WareHouse1.SuppNo);
            string s_WareHouseNo = "调拨单号："+Model.AllocateNo;
            string s_WareHouseDateTime = "日期：" + DateTime.Parse(Model.AllocateDateTime.ToString()).ToShortDateString();

            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n";
            s_Head += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\" > \n";
            s_Head += "<tr>\n<th colspan=\"10\" class=\"MaterTitle\" style='height:14.25pt'>杭州士腾科技有限公司<br/>" + s_LyType + "调拨单</th></tr>\n";
            s_Head += "<tr>\n<th colspan=\"5\" class=\"thstyleleft\"  >" + s_HouseInName + "</th><th colspan=\"5\" class=\"thstyleRight\" >" + s_HouseName + "</th></tr>\n";
            s_Head += "<tr>\n<th colspan=\"5\" class=\"thstyleleft\"  >" + s_WareHouseDateTime + "</th><th colspan=\"5\" class=\"thstyleRight\" >" + s_WareHouseNo + "</th></tr>\n";
            s_Head += "<th class=\"thstyle\" >项次</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>品名</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>料号</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>型号</th>\n";
            if (this.Tbx_View.Text != "1")
            {
                s_Head += "<th class=\"thstyle\" align=center>上级名称</th>\n";
            }
            s_Head += "<th class=\"thstyle\">单位</th>\n";
            s_Head += "<th class=\"thstyle\">数量</th>\n";
            s_Head += "<th class=\"thstyle\">单价</th>\n";
            s_Head += "<th class=\"thstyle\">金额</th>\n";
            s_Head += "<th class=\"thstyle\">备注</th>\n";
            s_Head += "</thead><tbody class=\"scrollContent\">";
            s_Details += "</div>";

            this.Lbl_Details.Text = s_Head + s_Details;
            if (this.Tbx_View.Text== "")
            {
                string s_Sql1 = "Update KNet_WareHouse_AllocateList set KWA_PrintsNums=KWA_PrintsNums+1 where AllocateNo='" + s_ID + "' ";
                DbHelperSQL.ExecuteSql(s_Sql1);
            }
        }

        
    }
}
