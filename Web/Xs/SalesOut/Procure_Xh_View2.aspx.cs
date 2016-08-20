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
            decimal d_TotalNumber = 0, d_TotalNet = 0;
            string s_Head = "";
            //原材料委外耗料
            string s_Sql = "";
            //明细
            KNet.BLL.KNet_WareHouse_DirectOutList BLL = new KNet.BLL.KNet_WareHouse_DirectOutList();
            KNet.Model.KNet_WareHouse_DirectOutList Model = BLL.GetModelB(s_ID);
            s_Sql = "Select isnull(KWD_BNumber,0) DirectOutAmount,*,'部门领用' TypeName";
            s_Sql += " from KNet_WareHouse_DirectOutList  a  join KNet_WareHouse_DirectOutList_Details b on a.DirectOutNo=b.DirectOutNo ";
            s_Sql += " join dbo.KNet_Sys_Products AS c ON c.ProductsBarCode = b.ProductsBarCode  ";
            s_Sql += "  Where a.DirectOutNo='" + s_ID + "' and c.ProductsType = 'M130704050932527' and isnull(KWD_BNumber,0)<>0 ";
            string s_TypeName = "";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                s_TypeName = Dtb_Table.Rows[0]["TypeName"].ToString();
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
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
                    s_Details += "<td class='thstyleLeftDetails' align=center >" + base.Base_GetUnitsName(base.Base_GetProductsUnits(Dtb_Table.Rows[i]["ProductsBarCode"].ToString())) + "</td>\n";


                    s_Details += "<td  class='thstyleLeftDetails' align=right  >&nbsp;" + base.FormatNumber1(Dtb_Table.Rows[i]["DirectOutAmount"].ToString(), 0) + "</td>\n";
                    try
                    {
                        d_Money=decimal.Parse(Dtb_Table.Rows[i]["DirectOutAmount"].ToString()) * decimal.Parse(Dtb_Table.Rows[i]["DirectOutUnitPrice"].ToString());
                    }
                    catch
                    { }
                    s_Details += "<td  class='thstyleLeftDetails' align=center >&nbsp;</td>\n";
                    s_Details += " </tr>";
                    try
                    {
                        d_TotalNumber += decimal.Parse(Dtb_Table.Rows[i]["DirectOutAmount"].ToString());
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
                s_Details += " </tr>";
            }
            string s_Depart = "部门：" + base.Base_GeDept(AM.KNet_StaffDepart);
            string s_StaffName = "制单人：" + AM.KNet_StaffName;
            s_Details += "<tr>\n<td colspan=\"5\" class=\"thstyleleft\"  >" + s_Depart + "</td><td colspan=\"5\" class=\"thstyleRight\" >" + s_StaffName + "</td></tr>\n";

            s_Details += "</tbody></table></td></tr>";
            string s_HouseName = "领料仓库：" + base.Base_GetHouseName(Model.HouseNo);
            string s_WareHouseNo = "领料单号：" + Model.DirectOutNo;
            string s_WareHouseDateTime = "日期：" + DateTime.Parse(Model.KWD_CWOutTime.ToString()).ToShortDateString();


            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n";
            s_Head += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\" > \n";
            s_Head += "<tr>\n<th colspan=\"8\" class=\"MaterTitle\" style='height:14.25pt'>杭州士腾科技有限公司<br/>原材料领料单</th></tr>\n";
            s_Head += "<tr>\n<th colspan=\"5\" class=\"thstyleleft\"  >" + s_WareHouseDateTime + "</th></tr>\n";
            s_Head += "<tr>\n<th colspan=\"5\" class=\"thstyleleft\"  >" + s_WareHouseNo + "</th><th colspan=\"3\" class=\"thstyleRight\" >" + s_HouseName + "</th></tr>\n";
            s_Head += "<tr>\n<th colspan=\"8\" class=\"thstyleleft\"  >领料类型：" + s_TypeName + "</th></tr>\n";

            s_Head += "<th class=\"thstyle\" >项次</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>品名</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>料号</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>型号</th>\n";
            s_Head += "<th class=\"thstyle\">单位</th>\n";
            s_Head += "<th class=\"thstyle\">数量</th>\n";
            s_Head += "<th class=\"thstyle\">备注</th>\n";
            s_Head += "</thead><tbody class=\"scrollContent\">";
            s_Details += "</div>";
            this.Lbl_Details.Text = s_Head + s_Details;
            string s_Sql1 = "Update KNet_WareHouse_DirectOutList set KWD_PintBatteryNums=KWD_PintBatteryNums+1 where DirectOutNo='" + s_ID + "' ";
            DbHelperSQL.ExecuteSql(s_Sql1);
        }


    }
}
