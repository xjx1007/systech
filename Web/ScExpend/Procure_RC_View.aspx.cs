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

public partial class Web_Procure_RC_View : BasePage
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

            string s_Style = "", s_OrderNo="";
            decimal d_TotalNumber = 0, d_TotalNet = 0;
            string s_Head = "";
            //原材料委外耗料
            string s_Sql = "";
            //明细
            KNet.BLL.Sc_Expend_Manage BLL = new KNet.BLL.Sc_Expend_Manage();
            KNet.Model.Sc_Expend_Manage Model = BLL.GetModel(s_ID);
            s_Sql = "Select *,SER_ScMoney+isnull(SER_ScHandMoney,0) as TotalMoney";
            s_Sql += " from Sc_Expend_Manage  a join Sc_Expend_Manage_RCDetails b on a.SEM_ID=b.SER_SEMID  ";
            s_Sql += " join Knet_Procure_OrdersList_Details c on b.SER_OrderDetailID=c.ID  ";
             
            s_Sql += "  Where a.SEM_ID='"+s_ID+"' ";
            string s_Preson = "";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                s_Preson  = Dtb_Table.Rows[0]["SEM_RkPerson"].ToString();
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
                    s_Details += "<td class='thstyleLeftDetails'align=center >" + base.Base_GetProdutsName(Dtb_Table.Rows[i]["SER_ProductsBarCode"].ToString()) + "</td>\n";
                    s_Details += "<td class='thstyleLeftDetails'align=center >" + base.Base_GetProductsCode(Dtb_Table.Rows[i]["SER_ProductsBarCode"].ToString()) + "</td>\n";

                    if (base.Base_GetProdutsName(Dtb_Table.Rows[i]["SER_ProductsBarCode"].ToString()).IndexOf("芯") > 0)
                    {
                        s_Details += "<td  class='thstyleLeftDetails'align=center >" + base.Base_GetProductsPattern(Dtb_Table.Rows[i]["SER_ProductsBarCode"].ToString()) + "</td>\n";
                    }
                    else
                    {
                        s_Details += "<td  class='thstyleLeftDetails'align=center >" + base.Base_GetProductsEdition(Dtb_Table.Rows[i]["SER_ProductsBarCode"].ToString()) + "</td>\n";
                    }
                    s_Details += "<td class='thstyleLeftDetails' align=center >" + base.Base_GetUnitsName(base.Base_GetProductsUnits(Dtb_Table.Rows[i]["SER_ProductsBarCode"].ToString())) + "</td>\n";


                    s_Details += "<td  class='thstyleLeftDetails' align=right  >&nbsp;" + base.FormatNumber1(Dtb_Table.Rows[i]["SER_ScNumber"].ToString(), 0) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  >&nbsp;" + base.FormatNumber1(Dtb_Table.Rows[i]["SER_ScPrice"].ToString(), 2) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  >&nbsp;" + base.FormatNumber1(Dtb_Table.Rows[i]["SER_ScMoney"].ToString(), 2) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=center >&nbsp;</td>\n";
                    s_Details += " </tr>";
                    try
                    {
                        d_TotalNumber += decimal.Parse(Dtb_Table.Rows[i]["SER_ScNumber"].ToString());
                        d_TotalNet += decimal.Parse(Dtb_Table.Rows[i]["SER_ScMoney"].ToString());
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
                s_OrderNo = Dtb_Table.Rows[0]["OrderNo"].ToString();
            }
            string s_Depart = "制单部门：" + base.Base_GeDept(AM.KNet_StaffDepart);
            string s_StaffName = "制单人：" + AM.KNet_StaffName;
            s_Details += "<tr>\n<td colspan=\"5\" class=\"thstyleleft\"  >" + s_Depart + "</td><td colspan=\"5\" class=\"thstyleRight\" >" + s_StaffName + "</td></tr>\n";

            string s_Depart1 = "入库部门：" + base.Base_GetUserDept(s_Preson);
            string s_StaffName1 = "入库人：" + base.Base_GetUserName(s_Preson);
            s_Details += "</tbody></table></td></tr>";
            string s_SuppName = "入库仓库：" + base.Base_GetSupplierName(Model.SEM_SuppNo);
            //string s_HouseName = "入库仓库：" + base.Base_GetHouseName(Model.sem_r);
            string s_WareHouseNo = "入库单号："+Model.SEM_ID;
            s_OrderNo = "采购单号：" + s_OrderNo;
            string s_WareHouseDateTime = "日期：" + DateTime.Parse(Model.SEM_Stime.ToString()).ToShortDateString();


            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n";
            s_Head += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\" > \n";
            s_Head += "<tr>\n<th colspan=\"10\" class=\"MaterTitle\" style='height:14.25pt'>杭州士腾科技有限公司<br/>成品生产入库单</th></tr>\n";
            s_Head += "<tr>\n<th colspan=\"5\" class=\"thstyleleft\"  >" + s_WareHouseDateTime + "</th><th colspan=\"5\" class=\"thstyleRight\" >" + s_SuppName + "</th></tr>\n";
            s_Head += "<tr>\n<th colspan=\"5\" class=\"thstyleleft\"  >" + s_OrderNo + "</th><th colspan=\"5\" class=\"thstyleRight\" >" + s_WareHouseNo + "</th></tr>\n";
            s_Head += "<tr>\n<th colspan=\"5\" class=\"thstyleleft\"  >" + s_Depart1 + "</th><th colspan=\"5\" class=\"thstyleRight\" >" + s_StaffName1 + "</th></tr>\n";

            s_Head += "<th class=\"thstyle\" >项次</th>\n";
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
            Model.SEM_RCPrintNums = Model.SEM_RCPrintNums + 1;
            // Model.SEM_RCPrintNums =1;
            BLL.UpdateRCPrintState(Model);
        }

        
    }
}
