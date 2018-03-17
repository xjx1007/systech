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

            string  s_Style = "";
            decimal d_TotalNumber = 0, d_TotalNet = 0;
            string s_Head = "";
            //原材料委外耗料
            string s_Sql = "";
            //明细
            KNet.BLL.Sc_Expend_Manage BLL = new KNet.BLL.Sc_Expend_Manage();
            KNet.Model.Sc_Expend_Manage Model = BLL.GetModel(s_ID);
            s_Sql = "Select *";
            s_Sql += "  from Sc_Expend_Manage  a join Sc_Expend_Manage_MaterDetails b on a.SEM_ID=b.SED_SEMID  ";
            s_Sql += "  Where a.SEM_ID='"+s_ID+"' and SED_Type='2' ";

            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            string s_RkPerson = "";
            if (Dtb_Table.Rows.Count > 0)
            {
                s_RkPerson = Dtb_Table.Rows[0]["SEM_RkPerson"].ToString();
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
                    s_Details += "<td class='thstyleLeftDetails'align=center >" + Dtb_Table.Rows[i]["SED_ID"].ToString() + "</td>\n";
                    s_Details += "<td class='thstyleLeftDetails'align=center >" + base.Base_GetProdutsName(Dtb_Table.Rows[i]["SED_ProductsBarCode"].ToString()) + "</td>\n";
                    s_Details += "<td class='thstyleLeftDetails'align=center >" + base.Base_GetProductsCode(Dtb_Table.Rows[i]["SED_ProductsBarCode"].ToString()) + "</td>\n";

                    if (base.Base_GetProdutsName(Dtb_Table.Rows[i]["SED_ProductsBarCode"].ToString()).IndexOf("芯") > 0)
                    {
                        s_Details += "<td  class='thstyleLeftDetails'align=center >" + base.Base_GetProductsPattern(Dtb_Table.Rows[i]["SED_ProductsBarCode"].ToString()) + "</td>\n";
                    }
                    else
                    {
                        s_Details += "<td  class='thstyleLeftDetails'align=center >" + base.Base_GetProductsEdition(Dtb_Table.Rows[i]["SED_ProductsBarCode"].ToString()) + "</td>\n";
                    }
                    s_Details += "<td class='thstyleLeftDetails' align=center >" + base.Base_GetUnitsName(base.Base_GetProductsUnits(Dtb_Table.Rows[i]["SED_ProductsBarCode"].ToString())) + "</td>\n";


                    s_Details += "<td  class='thstyleLeftDetails' align=right  >&nbsp;" + base.FormatNumber1(Dtb_Table.Rows[i]["SED_RkNumber"].ToString(), 0) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  >&nbsp;" + base.FormatNumber1(Dtb_Table.Rows[i]["SED_RkPrice"].ToString(), 2) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  >&nbsp;" + base.FormatNumber1(Dtb_Table.Rows[i]["SED_RkMoney"].ToString(), 2) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=center >&nbsp;" + Dtb_Table.Rows[i]["SED_Remarks"].ToString() + "</td>\n";
                    s_Details += " </tr>";
                    try
                    {
                        d_TotalNumber += decimal.Parse(Dtb_Table.Rows[i]["SED_RkNumber"].ToString());
                        d_TotalNet += decimal.Parse(Dtb_Table.Rows[i]["SED_RkMoney"].ToString());
                    }
                    catch
                    {
                    }
                }
                s_Details += " <tr >\n";
                s_Details += "<td class='thstyleBootDetails'align=center  colspan='6'>合计:</td>\n";
                s_Details += "<td class='thstyleBootDetails' align=right  >&nbsp;" + base.FormatNumber1(d_TotalNumber.ToString(), 0) + "</td>\n";
                s_Details += "<td class='thstyleBootDetails' align=right >&nbsp;</td>\n";//money
                s_Details += "<td class='thstyleBootDetails' align=right  >&nbsp;" + base.FormatNumber1(d_TotalNet.ToString(), 2) + "</td>\n";
                s_Details += "<td class='thstyleBootDetails' align=right >&nbsp;</td>\n";//money
                s_Details += " </tr>";
            }
            string s_Depart = "制单部门：" + base.Base_GeDept(AM.KNet_StaffDepart);
            string s_StaffName = "制单人：" + AM.KNet_StaffName;
            s_Details += "<tr>\n<td colspan=\"6\" class=\"thstyleleft\"  >" + s_Depart + "</td><td colspan=\"5\" class=\"thstyleRight\" >" + s_StaffName + "</td></tr>\n";

            s_Details += "</tbody></table></td></tr>";
            string s_HouseName = "领料仓库：" + base.Base_GetHouseName(Model.SEM_SuppNo);
            string s_WareHouseNo = "成品单号："+Model.SEM_ID;
            string s_OrderNo = "采购单号：" +GetOrderNo(s_ID);
            string s_WareHouseDateTime = "领料日期：" + DateTime.Parse(Model.SEM_Stime.ToString()).ToShortDateString();

            string s_RC = "成品：" + GetRC(s_ID,0);
            string s_RCNumber = "生产数量：" + GetRC(s_ID, 1);
            string s_Depart1 = "领料部门：" + base.Base_GetUserDept(s_RkPerson);
            string s_StaffName1 = "领料人：" + base.Base_GetUserName(s_RkPerson);

            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n";
            s_Head += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\" > \n";
            s_Head += "<tr>\n<th colspan=\"11\" class=\"MaterTitle\" style='height:14.25pt'>杭州士腾科技有限公司<br/>生产领料单</th></tr>\n";
            s_Head += "<tr>\n<th colspan=\"6\" class=\"thstyleleft\"  >" + s_WareHouseDateTime + "</th><th colspan=\"5\" class=\"thstyleRight\" >" + s_HouseName + "</th></tr>\n";
            s_Head += "<tr>\n<th colspan=\"6\" class=\"thstyleleft\"  >" + s_OrderNo + "</th><th colspan=\"5\" class=\"thstyleRight\" NoWrap >" + s_WareHouseNo + "</th></tr>\n";
            s_Head += "<tr>\n<th colspan=\"6\" class=\"thstyleleft\"  >" + s_RC + "</th><th colspan=\"5\" class=\"thstyleRight\" NoWrap >" + s_RCNumber + "</th></tr>\n";
            s_Head += "<tr>\n<th colspan=\"6\" class=\"thstyleleft\"  >" + s_Depart1 + "</th><th colspan=\"5\" class=\"thstyleRight\" NoWrap >" + s_StaffName1 + "</th></tr>\n";

            s_Head += "<th class=\"thstyle\" >项次</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>单号</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>品名</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>料号</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>型号</th>\n";
            s_Head += "<th class=\"thstyle\">单位</th>\n";
            s_Head += "<th class=\"thstyle\">数量</th>\n";
            s_Head += "<th class=\"thstyle\">单价</th>\n";
            s_Head += "<th class=\"thstyle\">金额</th>\n";
            s_Head += "<th class=\"thstyle\">备注</th>\n";
            s_Head += "</thead><tbody class=\"scrollContent\">";
            s_Details += "</div>";

            this.Lbl_Details.Text = s_Head + s_Details;
            Model.SEM_MaterPrintNums = Model.SEM_MaterPrintNums + 1;
            //Model.KPW_PrintNums =1;
            BLL.UpdateMaterPrintState(Model);
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
    public string GetRC(string s_ID,int i_type)
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
                        s_Return= base.Base_GetProductsPattern(Dts_RC.Tables[0].Rows[0]["SER_ProductsBarCode"].ToString());
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
