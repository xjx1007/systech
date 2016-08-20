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

public partial class Web_Procure_MaterIn_View : BasePage
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
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();

            if (s_Type == "0")
            {
                this.Tbx_Title.Text = "材料验收入库单";
            }
            else if (s_Type == "1")//委外发料
            {
                this.Tbx_Title.Text = "委外加工发料单";
            }
            else if (s_Type == "2")
            {
                this.Tbx_Title.Text = "委外加工耗料单";
            }
            KNet.BLL.Cg_Order_Checklist Bll = new KNet.BLL.Cg_Order_Checklist();
            KNet.Model.Cg_Order_Checklist Model = Bll.GetModel(s_ID);
          //原材料对账单
                string s_Sql = "Select b.COD_ProductsBarCode,a.COC_SuppNo,d.WareHouseDateTime,b.COD_Dznumber,b.COD_wuliu,b.COd_Price, ";
                s_Sql += "b.COD_Money,b.COD_CustomerValue,a.COC_Details,a.COC_Stime,e.OrderDateTime,a.COC_RKCode  from Cg_Order_Checklist a join Cg_Order_Checklist_Details b on a.COC_Code=b.COD_CheckNo join Knet_Procure_WareHouseList_Details c on c.ID=b.COD_DirectOutID join Knet_Procure_WareHouseList d on d.WareHouseNo=c.WareHouseNo left join Knet_Procure_OrdersList e on  e.OrderNO=d.OrderNo Where 1=1 and a.COC_Code='" + s_ID + "' Order by d.WareHouseDateTime";
                string s_Date = "", s_House = "", s_Style = "",s_Code="";
                decimal d_TotalNet = 0;
                decimal d_TotalNumber = 0;
                string s_Head = "";
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
                        s_Details += "<td class='thstyleLeftDetails'align=center noWrap>" + base.Base_GetProdutsName(Dtb_Table.Rows[i][0].ToString()) + "</td>\n";
                        s_Details += "<td  class='thstyleLeftDetails'align=center noWrap>" + base.Base_GetProductsEdition(Dtb_Table.Rows[i][0].ToString()) + "</td>\n";

                        s_Details += "<td class='thstyleLeftDetails' align=center noWrap>" + base.Base_GetUnitsName(base.Base_GetProductsUnits(Dtb_Table.Rows[i][0].ToString())) + "</td>\n";

                        try
                        {
                            s_Details += "<td  class='thstyleLeftDetails'align=center noWrap>" + DateTime.Parse(Dtb_Table.Rows[i][2].ToString()).ToShortDateString() + "</td>\n";
                        }
                        catch
                        {
                            s_Details += "<td class='thstyleLeftDetails' align=center noWrap>&nbsp;</td>\n";
                        }
                        s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber(Dtb_Table.Rows[i][3].ToString(), 0) + "</td>\n";
                        s_Details += "<td  class='thstyleLeftDetails' align=right noWrap>" + base.FormatNumber(Dtb_Table.Rows[i][5].ToString(),3) + "</td>\n";//money
                        s_Details += "<td  class='thstyleLeftDetails' align=right noWrap>" + base.FormatNumber(Dtb_Table.Rows[i][6].ToString(), 3) + "</td>\n";//money
                        s_Details += "<td  class='thstyleLeftDetails' align=center noWrap>&nbsp;" + Dtb_Table.Rows[i][8].ToString() + "</td>\n";

                        s_Details += " </tr>";
                        try
                        {
                            d_TotalNet += decimal.Parse(Dtb_Table.Rows[i][6].ToString());
                            d_TotalNumber += decimal.Parse(Dtb_Table.Rows[i][3].ToString());
                        }
                        catch
                        {
                        }
                    }
                    s_Details += " <tr >\n";
                    s_Details += "<td class='thstyleLeftDetails'align=center noWrap colspan='5'>合计:</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber(d_TotalNumber.ToString(), 0) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=right noWrap>&nbsp;</td>\n";//money
                    s_Details += "<td  class='thstyleLeftDetails' align=right noWrap>&nbsp;" + base.FormatNumber(d_TotalNet.ToString(), 3) + "</td>\n";//money
                    s_Details += "<td  class='thstyleLeftDetails' align=center noWrap>&nbsp;</td>\n";

                    s_Details += " </tr>";
                    s_Date = DateTime.Parse(Dtb_Table.Rows[0][9].ToString()).ToShortDateString();
                    s_House = Dtb_Table.Rows[0][1].ToString();
                }

                s_Code = s_ID;
                s_Details += "</tbody></table></td></tr>";

                s_Time = "日期:" + s_Date;
                s_HouseName = "供应商名称:" + base.Base_GetSupplierName(s_House);
                s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n";
                s_Head += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\"> \n";
                s_Head += "<tr>\n<th colspan=\"16\" class=\"MaterTitle\" style='height:14.25pt'>杭州士腾科技有限公司<br>" + this.Tbx_Title.Text + "</th></tr>\n";
                s_Head += "<tr>\n<th colspan=\"2\" class=\"thstyleleft\"  >入库仓库：原材料库</th><th colspan=\"2\" class=\"thstyleleft\"  >" + s_HouseName + "</th><th colspan=\"3\" class=\"thstyleleft\"  >单号：" + s_Code + "</th><th colspan=\"2\" class=\"thstyleRight\" >" + s_Time + "</th></tr>\n";
                s_Head += "<th class=\"thstyle\" rowspan=2>项次</th>\n";
                s_Head += "<th class=\"thstyle\" align=center>品名</th>\n";
                s_Head += "<th class=\"thstyle\" align=center>型号</th>\n";
                s_Head += "<th class=\"thstyle\">单位</th>\n";
                s_Head += "<th class=\"thstyle\" >到货日期</th>\n";
                s_Head += "<th class=\"thstyle\" >入库数量</th>\n";
                s_Head += "<th class=\"thstyle\" align=center >单价</th>\n";
                s_Head += "<th class=\"thstyle\" align=center>总额</th>\n";
                s_Head += "<th class=\"thstyle\">备注</th>\n";
                s_Head += "</thead><tbody class=\"scrollContent\">";
                s_Details += "</div>";

                this.Lbl_Details.Text = s_Head + s_Details;
            }
            

    }
}
