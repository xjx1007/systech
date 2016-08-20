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
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();

            string s_Style = "";
            decimal d_TotalNumber = 0, d_TotalNet = 0, d_TotalPrice = 0;
            string s_Head = "";
            //原材料委外耗料
            string s_Sql = "";
            //明细
            KNet.BLL.Sc_Expend_Manage BLL = new KNet.BLL.Sc_Expend_Manage();
            KNet.Model.Sc_Expend_Manage Model = BLL.GetModel(s_ID);
            s_Sql = "select * ";
            s_Sql += "  from Sc_Expend_Manage_RCDetails  a   ";
            s_Sql += "  Where a.SER_SEMID='" + s_ID + "' ";
            decimal d_Number = 0, d_Price = 0;
            string s_RkPerson = "";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                d_Price = decimal.Parse(Dtb_Table.Rows[0]["SER_ScPrice"].ToString());
                d_Number = decimal.Parse(Dtb_Table.Rows[0]["SER_ScNumber"].ToString());
            }
            s_RkPerson = Model.SEM_RkPerson;
            s_Sql = "Select *  from KNet_Sys_Products where ProductsType='M150920074726199' Order by ProductsName ";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            Dtb_Table = this.Dtb_Result;
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
                    s_Details += " <tr " + s_Style + ">\n";
                    s_Details += "<td class='thstyleLeftDetails'align=center >" + (i + 1).ToString() + "</td>\n";
                    s_Details += "<td class='thstyleLeftDetails'align=center >" + base.Base_GetProductsCode(Dtb_Table.Rows[i]["ProductsBarCode"].ToString()) + "</td>\n";
                    s_Details += "<td class='thstyleLeftDetails'align=center >" + base.Base_GetProdutsName(Dtb_Table.Rows[i]["ProductsBarCode"].ToString()) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails'align=center >" + base.Base_GetProductsEdition(Dtb_Table.Rows[i]["ProductsBarCode"].ToString()) + "</td>\n";
                    s_Details += "<td class='thstyleLeftDetails' align=center >" + base.Base_GetUnitsName(base.Base_GetProductsUnits(Dtb_Table.Rows[i]["ProductsBarCode"].ToString())) + "</td>\n";
                    decimal d_Num = 1;
                    if (Dtb_Table.Rows[i]["ProductsBarCode"].ToString() == "D1304021636173814")//如果是电阻
                    {
                        s_Details += "<td  class='thstyleLeftDetails' align=right  >5</td>\n";
                        d_Num = 5;

                    }
                    else
                    {
                        s_Details += "<td  class='thstyleLeftDetails' align=right  >1</td>\n";
                        d_Num = 1;
                    }
                    decimal d_Number1 = 0;
                    d_Number1 = d_Number * d_Num;
                    s_Details += "<td  class='thstyleLeftDetails' align=right  >&nbsp;" + base.FormatNumber1(d_Number1.ToString(), 0) + "</td>\n";
                    decimal d_ProductsCostPrice = decimal.Parse(Dtb_Table.Rows[i]["ProductsCostPrice"].ToString());

                    s_Details += "<td  class='thstyleLeftDetails' align=right  >&nbsp;" + base.FormatNumber1(d_ProductsCostPrice.ToString(), 2) + "</td>\n";
                    decimal d_TotalMoney = d_Number1 * d_ProductsCostPrice;
                    s_Details += "<td  class='thstyleLeftDetails' align=right  >&nbsp;" + base.FormatNumber1(d_TotalMoney.ToString(), 2) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=center >&nbsp;</td>\n";
                    s_Details += " </tr>";
                    try
                    {
                        d_TotalNumber += d_Number1;
                        d_TotalNet += d_TotalMoney;
                        d_TotalPrice += d_Num * d_ProductsCostPrice;
                    }
                    catch
                    {
                    }
                }
                s_Details += " <tr >\n";
                s_Details += "<td class='thstyleBootDetails'align=center  colspan='6'>合计:</td>\n";
                s_Details += "<td class='thstyleBootDetails' align=right  >&nbsp;" + base.FormatNumber1(d_TotalNumber.ToString(), 0) + "</td>\n";
                s_Details += "<td class='thstyleBootDetails' align=right >&nbsp;" + base.FormatNumber1(d_TotalPrice.ToString(), 2) + "</td>\n";//money
                s_Details += "<td class='thstyleBootDetails' align=right  >&nbsp;" + base.FormatNumber1(d_TotalNet.ToString(), 2) + "</td>\n";
                s_Details += "<td class='thstyleBootDetails' align=right >&nbsp;</td>\n";//money
                s_Details += " </tr>";
            }
            string s_Depart = "制单部门：" + base.Base_GeDept(AM.KNet_StaffDepart);
            string s_StaffName = "制单人：" + AM.KNet_StaffName;
            s_Details += "<tr>\n<td colspan=\"6\" class=\"thstyleleft\"  >" + s_Depart + "</td><td colspan=\"5\" class=\"thstyleRight\" >" + s_StaffName + "</td></tr>\n";

            s_Details += "</tbody></table></td></tr>";
            string s_HouseName = "出库仓库：" + base.Base_GetHouseName(Model.SEM_SuppNo);
            string s_WareHouseNo = "遥控器单号：" + Model.SEM_ID;
            string s_OrderNo = "采购单号：" + GetOrderNo(s_ID);
            string s_WareHouseDateTime = "出库日期：" + DateTime.Parse(Model.SEM_Stime.ToString()).ToShortDateString();

            string s_RC = "成品：" + GetRC(s_ID, 0);
            string s_RCNumber = "生产数量：" + GetRC(s_ID, 1);
            string s_Depart1 = "出库部门：" + base.Base_GetUserDept(s_RkPerson);
            string s_StaffName1 = "出库人：" + base.Base_GetUserName(s_RkPerson);

            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n";
            s_Head += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\" > \n";
            s_Head += "<tr>\n<th colspan=\"11\" class=\"MaterTitle\" style='height:14.25pt'>杭州士腾科技有限公司<br/>材料出库单</th></tr>\n";
            s_Head += "<tr>\n<th colspan=\"6\" class=\"thstyleleft\"  >" + s_WareHouseDateTime + "</th><th colspan=\"5\" class=\"thstyleRight\" >" + s_HouseName + "</th></tr>\n";
            s_Head += "<tr>\n<th colspan=\"6\" class=\"thstyleleft\"  >" + s_OrderNo + "</th><th colspan=\"5\" class=\"thstyleRight\" NoWrap >" + s_WareHouseNo + "</th></tr>\n";
            s_Head += "<tr>\n<th colspan=\"6\" class=\"thstyleleft\"  >" + s_RC + "</th><th colspan=\"5\" class=\"thstyleRight\" NoWrap >" + s_RCNumber + "</th></tr>\n";
            s_Head += "<tr>\n<th colspan=\"6\" class=\"thstyleleft\"  >" + s_Depart1 + "</th><th colspan=\"5\" class=\"thstyleRight\" NoWrap >" + s_StaffName1 + "</th></tr>\n";

            s_Head += "<th class=\"thstyle\" >项次</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>料号</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>品名</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>规格</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>单位</th>\n";
            s_Head += "<th class=\"thstyle\">标准用量</th>\n";
            s_Head += "<th class=\"thstyle\">出库数量</th>\n";
            s_Head += "<th class=\"thstyle\">单价</th>\n";
            s_Head += "<th class=\"thstyle\">金额</th>\n";
            s_Head += "<th class=\"thstyle\">备注</th>\n";
            s_Head += "</thead><tbody class=\"scrollContent\">";
            s_Details += "</div>";

            this.Lbl_Details.Text = s_Head + s_Details;
            Model.SEM_MaterPrintNums2 = Model.SEM_MaterPrintNums2 + 1;
            //Model.KPW_PrintNums =1;
            BLL.UpdateMaterPrintState2(Model);
        }


    }

    public string GetOrderNo(string s_ID)
    {
        string s_Return = "";
        try
        {
            this.BeginQuery("select * from Sc_Expend_Manage_RCDetails a join Knet_Procure_OrdersList_Details b on a.SER_OrderDetailID=b.ID where SER_SEMID='" + s_ID + "' ");
            this.QueryForDataSet();
            DataSet Dts_RC = this.Dts_Result;
            if (Dts_RC.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_RC.Tables[0].Rows.Count; i++)
                {
                    s_Return = Dts_RC.Tables[0].Rows[i]["OrderNo"].ToString();
                }
            }
        }
        catch
        { }
        return s_Return;

    }
    public string GetRC(string s_ID, int i_type)
    {
        string s_Return = "";
        try
        {
            this.BeginQuery("select * from Sc_Expend_Manage_RCDetails a join Knet_Procure_OrdersList_Details b on a.SER_OrderDetailID=b.ID where SER_SEMID='" + s_ID + "' ");
            this.QueryForDataSet();
            DataSet Dts_RC = this.Dts_Result;
            if (Dts_RC.Tables[0].Rows.Count > 0)
            {
                if (i_type == 0)
                {

                    if (base.Base_GetProdutsName(Dts_RC.Tables[0].Rows[0]["SER_ProductsBarCode"].ToString()).IndexOf("芯") > 0)
                    {
                        s_Return = base.Base_GetProductsPattern(Dts_RC.Tables[0].Rows[0]["SER_ProductsBarCode"].ToString());
                    }
                    else
                    {
                        s_Return = base.Base_GetProductsEdition(Dts_RC.Tables[0].Rows[0]["SER_ProductsBarCode"].ToString());
                    }
                }
                else
                {
                    s_Return = Dts_RC.Tables[0].Rows[0]["SER_ScNumber"].ToString();
                }

            }
        }
        catch
        { }
        return s_Return;

    }
}
