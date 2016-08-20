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

public partial class Web_List_OrderIn : BasePage
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
            string s_SuppNo = Request.QueryString["SuppNo"] == null ? "" : Request.QueryString["SuppNo"].ToString();
            string s_HouseNo = Request.QueryString["HouseNo"] == null ? "" : Request.QueryString["HouseNo"].ToString();
            string s_QRState = Request.QueryString["QRState"] == null ? "" : Request.QueryString["QRState"].ToString();
            string s_State = Request.QueryString["State"] == null ? "" : Request.QueryString["State"].ToString();

            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string s_ProductsEdition = Request.QueryString["ProductsEdition"] == null ? "" : Request.QueryString["ProductsEdition"].ToString();

            string s_ProductsType = Request.QueryString["ProductsType"] == null ? "" : Request.QueryString["ProductsType"].ToString();
            string s_DutyPerson = Request.QueryString["DutyPerson"] == null ? "" : Request.QueryString["DutyPerson"].ToString();

            string s_Sql1 = "select distinct b.HouseNo,b.HouseName from v_DirectOutList_all a join KNET_Sys_WareHouse b on a.HouseNO=b.HouseNo  ";
            s_Sql1 += " where 1=1 ";
            if (s_HouseNo != "")
            {
                s_Sql1 += " and a.HouseNo='" + s_HouseNo + "'";
            }
            s_Sql1 += " order by b.HouseName,b.HouseNo ";
            this.BeginQuery(s_Sql1);
            this.QueryForDataTable();
            DataTable Dtb_HouseNo = this.Dtb_Result;

            string s_Sql = "Select   ";
            for (int i = 0; i < Dtb_HouseNo.Rows.Count; i++)
            {
                s_Sql += "Sum(Case when a.HouseNo='" + Dtb_HouseNo.Rows[i]["HouseNo"].ToString() + "' then DirectOutAmount+isnull(KWD_BNumber,0) else 0 end), ";
            }
            s_Sql += " e.ProductsBarCode,e.ProductsName,e.ProductsEdition,e.ProductsPattern,e.KSP_Code,Sum(DirectOutAmount+isnull(KWD_BNumber,0)) as Number ";
            s_Sql += " from v_DirectOutList_all a    ";
            s_Sql += " join  KNET_Sys_Products e on a.ProductsBarCode=e.ProductsBarCode    ";

            s_Sql += "  Where 1=1 ";
            if (s_StartDate != "")
            {
                s_Sql += " and  a.KWD_CwOutTime>='" + s_StartDate + "'";
            }
            if (s_EndDate != "")
            {
                s_Sql += " and  a.KWD_CwOutTime<='" + s_EndDate + "'";
            }
            if (s_HouseNo != "")
            {
                s_Sql += " and  a.HouseNo='" + s_HouseNo + "'";
            }
            if (s_ProductsEdition != "")
            {
                s_Sql += " and  e.ProductsEdition like '%" + s_ProductsEdition + "%'";
            }

            if (s_ProductsType != "")
            {
                KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
                string s_SonID = Bll_ProductsDetails.GetSonIDs(s_ProductsType);
                s_SonID = s_SonID.Replace(",", "','");
                s_Sql += " and e.ProductsType in ('" + s_SonID + "') ";
            }

            s_Sql += " group by e.ProductsBarCode,e.ProductsName,e.ProductsEdition,e.ProductsPattern,e.KSP_Code order by Sum(DirectOutAmount+KWD_BNumber) desc ";
            string s_House = "", s_Style = "";
            decimal d_TotalNet = 0;
            decimal d_TotalNumber = 0, d_TotalNumber1 = 0, d_TotalNumber2 = 0, d_TotalNumber3 = 0;
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
                    s_Details += "<td class='thstyleLeftDetails'>" + (i + 1).ToString() + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' >&nbsp;" + Dtb_Table.Rows[i]["ProductsName"].ToString() + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' >&nbsp;" + Dtb_Table.Rows[i]["KSP_Code"].ToString() + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' >&nbsp;" + Dtb_Table.Rows[i]["ProductsPattern"].ToString() + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' >&nbsp;" + Dtb_Table.Rows[i]["ProductsEdition"].ToString() + "</td>\n";


                    s_Details += "<td  class='thstyleLeftDetails' align=right  >" + base.FormatNumber1(Dtb_Table.Rows[i]["Number"].ToString(), 0) + "</td>\n";

                    for (int j = 0; j < Dtb_HouseNo.Rows.Count; j++)
                    {
                        s_Details += "<td  class='thstyleLeftDetails' align=right  >" + base.FormatNumber1(Dtb_Table.Rows[i][j].ToString(), 0) + "</td>\n";

                    }
                    s_Details += " </tr>";
                    try
                    {
                        d_TotalNumber += decimal.Parse(Dtb_Table.Rows[i]["Number"].ToString());
                    }
                    catch
                    {
                    }
                }
                s_Details += " <tr >\n";
                s_Details += "<td class='thstyleLeftDetails'align=center noWrap colspan='5'>合计:</td>\n";
                s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_TotalNumber.ToString(), 0) + "</td>\n";
                s_Details += " </tr>";
                s_House = Dtb_Table.Rows[0][0].ToString();
            }
            s_Details += "</tbody></table></td></tr>";
            s_Time = "日期:" + s_StartDate + " 到" + s_EndDate;
            s_HouseName = "入库仓库:" + base.Base_GetHouseName(s_House);
            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n";
            s_Head += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\"> \n";
            s_Head += "<tr>\n<th colspan=\"6\" class=\"MaterTitle\" style='height:14.25pt'>杭州士腾科技有限公司<br/>产品生产统计表单</th></tr>\n";
            s_Head += "<tr>\n<th colspan=\"3\" class=\"thstyleleft\"  ></th><th colspan=\"3\" class=\"thstyleRight\" >" + s_Time + "</th></tr>\n";
            s_Head += "<th class=\"thstyle\" >项次</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>产品名称</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>产品编码</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>型号</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>版本号</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>总数量</th>\n";

            for (int j = 0; j < Dtb_HouseNo.Rows.Count; j++)
            {
                s_Head += "<th class=\"thstyle\" align=center>" + Dtb_HouseNo.Rows[j]["HouseName"].ToString() + "</th>\n";

            }
            s_Head += "</thead><tbody class=\"scrollContent\">";
            s_Details += "</div>";
            this.Lbl_Details.Text = s_Head + s_Details;
        }
    }
}
