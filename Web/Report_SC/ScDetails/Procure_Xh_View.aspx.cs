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
            string s_StartDate = Request.QueryString["StartDate"] == null ? "" : Request.QueryString["StartDate"].ToString();
            string s_EndDate = Request.QueryString["EndDate"] == null ? "" : Request.QueryString["EndDate"].ToString();
            string s_SuppNo = Request.QueryString["SuppNo"] == null ? "" : Request.QueryString["SuppNo"].ToString();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string s_Type = Request.QueryString["Type"] == null ? "0" : Request.QueryString["Type"].ToString();
            string s_ProductsEdition = Request.QueryString["ProductsEidition"] == null ? "" : Request.QueryString["ProductsEidition"].ToString();
            string s_Code = Request.QueryString["Code"] == null ? "" : Request.QueryString["Code"].ToString();
            
            string s_Date = "", s_House = "", s_Style = "";
            decimal d_TotalNumber = 0,d_TotalNet=0;
            string s_Head = "";
            //原材料委外耗料
            string s_Sql = "";
            if (s_Type == "1")
            {
                //如果是汇总
                string s_Sql1 = " select Count(*) as Row1,SER_ProductsBarCode,SED_HouseNo from (Select a.SED_HouseNo,a.SED_ProductsBarCode,Sum(a.SED_RkNumber) as SED_RkNumber,a.SED_FromHouseNo,a.SER_ProductsBarCode";
                s_Sql1 += " from v_Sc_Expend_Manage_MaterDetails_1  a  ";
                s_Sql1 += " where 1=1  ";

                if (s_StartDate != "")
                {
                    s_Sql1 += " and  a.SED_RkTime>='" + s_StartDate + "'";
                }
                if (s_EndDate != "")
                {
                    s_Sql1 += " and  a.SED_RkTime<='" + s_EndDate + "'";
                }
                if (s_SuppNo != "")
                {
                    s_Sql1 += " and  SED_HouseNo='" + s_SuppNo + "'";
                }
                if (s_ProductsEdition != "")
                {
                    s_Sql1 += " and  SED_ProductsBarCode in (Select ProductsBarCode From KNet_Sys_Products where ProductsEdition like '%" + s_ProductsEdition + "%')";
                }
                if (s_Code != "")
                {
                    s_Sql1 += " and  SED_ProductsBarCode in (Select ProductsBarCode From KNet_Sys_Products where KSP_Code like '%" + s_Code + "%')";
 
                }
                if (s_ID != "")
                {
                    s_Sql1 += " and  SEM_DirectOutNO='" + s_ID + "'";
                }
                s_Sql1 += " Group by a.SED_HouseNo,a.SED_ProductsBarCode,a.SED_FromHouseNo,a.SER_ProductsBarCode) aa ";

                s_Sql1 += " join Knet_Sys_Products b on aa.SER_ProductsBarCode=b.ProductsBarCode where   ProductsType<>'M130704050932527'  ";

                s_Sql1 += " group by SER_ProductsBarCode,SED_HouseNo,ProductsType  ";
                this.BeginQuery(s_Sql1);
                this.QueryForDataTable();
                DataTable Dtb_RowCount = Dtb_Result;
                int k = 1;
                for (int j = 0; j < Dtb_RowCount.Rows.Count; j++)
                {
                    s_Sql = "Select a.SED_HouseNo,a.SED_ProductsBarCode,Sum(a.SED_RkNumber) as SED_RkNumber,a.SED_FromHouseNo,a.SER_ProductsBarCode,isnull(SED_WwPrice,0) SED_WwPrice,Sum(isnull(SED_WwMoney,0)) SED_WwMoney";
                    s_Sql += " from v_Sc_Expend_Manage_MaterDetails_1 a ";
                    s_Sql += "  Where 1=1 ";
                    s_SuppNo = Dtb_RowCount.Rows[j]["SED_HouseNo"].ToString();
                    string s_FProductsBarCode = Dtb_RowCount.Rows[j][1].ToString();
                    string s_RowCount = Dtb_RowCount.Rows[j][0].ToString();
                    if (s_StartDate != "")
                    {
                        s_Sql += " and  a.SED_RkTime>='" + s_StartDate + "'";
                    }
                    if (s_EndDate != "")
                    {
                        s_Sql += " and  a.SED_RkTime<='" + s_EndDate + "'";
                    }
                    if (s_SuppNo != "")
                    {
                        s_Sql += " and  SED_HouseNo='" + s_SuppNo + "'";
                    }
                    if (s_FProductsBarCode != "")
                    {
                        s_Sql += " and  a.SER_ProductsBarCode='" + s_FProductsBarCode + "'";
                    }
                    if (s_ProductsEdition != "")
                    {
                        s_Sql += " and  SED_ProductsBarCode in (Select ProductsBarCode From KNet_Sys_Products where ProductsEdition like '%" + s_ProductsEdition + "%')";
                    }
                    if (s_ID != "")
                    {
                        s_Sql += " and  SEM_DirectOutNO='" + s_ID + "'";
                    }
                    s_Sql += " Group by a.SED_HouseNo,a.SED_ProductsBarCode,a.SED_FromHouseNo,a.SER_ProductsBarCode,SED_WwPrice  ";
                    s_Sql += " Order by d.SER_ProductsBarCode";

                    this.BeginQuery(s_Sql);
                    this.QueryForDataTable();
                    DataTable Dtb_Table = this.Dtb_Result;
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
                        s_Details += "<td class='thstyleLeftDetails'align=center noWrap>" + k.ToString() + "</td>\n";

                        if (s_ID == "")
                        {
                            try
                            {
                                if (s_Type == "0")
                                {
                                    s_Details += "<td  class='thstyleLeftDetails'align=center noWrap>" + DateTime.Parse(Dtb_Table.Rows[i][1].ToString()).ToShortDateString() + "</td>\n";
                                }
                            }
                            catch
                            {
                                s_Details += "<td class='thstyleLeftDetails' align=center noWrap>&nbsp;</td>\n";
                            }
                        }
                        s_Details += "<td class='thstyleLeftDetails'align=center noWrap>" + base.Base_GetProdutsName(Dtb_Table.Rows[i]["SED_ProductsBarCode"].ToString()) + "</td>\n";
                        if (base.Base_GetProdutsName(Dtb_Table.Rows[i]["SED_ProductsBarCode"].ToString()).IndexOf("芯") >= 0)
                        {
                            s_Details += "<td  class='thstyleLeftDetails'align=center noWrap>" + base.Base_GetProductsPattern(Dtb_Table.Rows[i]["SED_ProductsBarCode"].ToString()) + "</td>\n";
                        }
                        else
                        {
                            s_Details += "<td  class='thstyleLeftDetails'align=center noWrap>" + base.Base_GetProductsEdition(Dtb_Table.Rows[i]["SED_ProductsBarCode"].ToString()) + "</td>\n";

                        }
                        s_Details += "<td class='thstyleLeftDetails' align=center noWrap>" + base.Base_GetUnitsName(base.Base_GetProductsUnits(Dtb_Table.Rows[i]["SED_ProductsBarCode"].ToString())) + "</td>\n";

                        s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["SED_RkNumber"].ToString(), 0) + "</td>\n";

                        s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["SED_WwPrice"].ToString(), 5) + "</td>\n";
                        s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["SED_WwMoney"].ToString(), 2) + "</td>\n";
                        if (i == 0)
                        {
                            s_Details += "<td  class='thstyleLeftDetails' align=right noWrap rowspan=" + s_RowCount + " >用于：" + base.Base_GetProductsPattern(Dtb_RowCount.Rows[j][1].ToString()) + "</td>\n";//money
                        }
                        s_Details += " </tr>";
                        try
                        {
                            d_TotalNumber += decimal.Parse(Dtb_Table.Rows[i]["SED_RkNumber"].ToString());
                        }
                        catch
                        {
                        }

                        try
                        {
                            d_TotalNet += decimal.Parse(Dtb_Table.Rows[i]["SED_WwMoney"].ToString());
                        }
                        catch
                        {
                        }

                        k = k + 1;
                    }
                    s_Details += " <tr >\n";
                    s_House = Dtb_Table.Rows[0]["SED_HouseNo"].ToString();
                }
                if (s_ID != "")
                {
                    s_Details += "<td class='thstyleLeftDetails'align=center noWrap colspan='4'>合计:</td>\n";
                }
                else
                {
                    if (s_Type == "0")
                    {
                        s_Details += "<td class='thstyleLeftDetails'align=center noWrap colspan='5'>合计:</td>\n";
                    }
                    else
                    {
                        s_Details += "<td class='thstyleLeftDetails'align=center noWrap colspan='4'>合计:</td>\n";
                    }
                }
                s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_TotalNumber.ToString(), 0) + "</td>\n";

                s_Details += "<td  class='thstyleLeftDetails' align=right noWrap>&nbsp;</td>\n";//money
                s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_TotalNet.ToString(), 2) + "</td>\n";
                s_Details += "<td  class='thstyleLeftDetails' align=right noWrap>&nbsp;</td>\n";//money

                s_Details += " </tr>";

                s_Details += "</tbody></table></td></tr>";
            }
            else
            {
                //明细
                s_Sql = "Select a.SED_HouseNo,a.SED_RkTime,a.SED_ProductsBarCode,a.SED_RkNumber,a.SED_FromHouseNo,isnull(SED_WwPrice,0) SED_WwPrice,isnull(SED_WwMoney,0) SED_WwMoney";
                s_Sql += " ";
                s_Sql += " from v_Sc_Expend_Manage_MaterDetails_1  a ";
                s_Sql += "  Where 1=1 ";
                if (s_StartDate != "")
                {
                    s_Sql += " and  a.SED_RkTime>='" + s_StartDate + "'";
                }
                if (s_EndDate != "")
                {
                    s_Sql += " and  a.SED_RkTime<='" + s_EndDate + "'";
                }
                if (s_SuppNo != "")
                {
                    s_Sql += " and  SED_HouseNo='" + s_SuppNo + "'";
                }
                if (s_ProductsEdition != "")
                {
                    s_Sql += " and  SED_ProductsBarCode in (Select ProductsBarCode From KNet_Sys_Products where ProductsEdition like '%" + s_ProductsEdition + "%')";
                }
                if (s_ID != "")
                {
                    s_Sql += " and  SEM_DirectOutNO='" + s_ID + "'";
                }
                s_Sql += " Order by a.SED_RkTime ";

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

                        if (s_ID == "")
                        {
                            try
                            {
                                if (s_Type == "0")
                                {
                                    s_Details += "<td  class='thstyleLeftDetails'align=center noWrap>" + DateTime.Parse(Dtb_Table.Rows[i][1].ToString()).ToShortDateString() + "</td>\n";
                                }
                            }
                            catch
                            {
                                s_Details += "<td class='thstyleLeftDetails' align=center noWrap>&nbsp;</td>\n";
                            }
                        }
                        s_Details += "<td class='thstyleLeftDetails'align=center noWrap>" + base.Base_GetProdutsName(Dtb_Table.Rows[i]["SED_ProductsBarCode"].ToString()) + "</td>\n";
                        if (base.Base_GetProdutsName(Dtb_Table.Rows[i]["SED_ProductsBarCode"].ToString()).IndexOf("芯") > 0)
                        {
                            s_Details += "<td  class='thstyleLeftDetails'align=center noWrap>" + base.Base_GetProductsPattern(Dtb_Table.Rows[i]["SED_ProductsBarCode"].ToString()) + "</td>\n";
                        }
                        else
                        {
                            s_Details += "<td  class='thstyleLeftDetails'align=center noWrap>" + base.Base_GetProductsEdition(Dtb_Table.Rows[i]["SED_ProductsBarCode"].ToString()) + "</td>\n";

                        }
                        s_Details += "<td class='thstyleLeftDetails' align=center noWrap>" + base.Base_GetUnitsName(base.Base_GetProductsUnits(Dtb_Table.Rows[i]["SED_ProductsBarCode"].ToString())) + "</td>\n";

                        s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["SED_RkNumber"].ToString(), 0) + "</td>\n";
                        s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["SED_WwPrice"].ToString(), 5) + "</td>\n";
                        s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["SED_WwMoney"].ToString(), 2) + "</td>\n";

                        if (s_Type == "0")
                        {
                            s_Details += "<td  class='thstyleLeftDetails' align=center noWrap>&nbsp;" + Dtb_Table.Rows[i][4].ToString() + "</td>\n";
                        }
                        else
                        {

                            s_Details += "<td  class='thstyleLeftDetails' align=right noWrap >用于：" + base.Base_GetProductsPattern(Dtb_Table.Rows[i]["SER_ProductsBarCode"].ToString()) + "</td>\n";//money
                        }

                        s_Details += " </tr>";
                        try
                        {
                            d_TotalNumber += decimal.Parse(Dtb_Table.Rows[i]["SED_RkNumber"].ToString());
                            d_TotalNet += decimal.Parse(Dtb_Table.Rows[i]["SED_WwMoney"].ToString());
                        }
                        catch
                        {
                        }
                    }
                    s_Details += " <tr >\n";
                    if (s_ID != "")
                    {
                        s_Details += "<td class='thstyleLeftDetails'align=center noWrap colspan='4'>合计:</td>\n";
                    }
                    else
                    {
                        if (s_Type == "0")
                        {
                            s_Details += "<td class='thstyleLeftDetails'align=center noWrap colspan='5'>合计:</td>\n";
                        }
                        else
                        {
                            s_Details += "<td class='thstyleLeftDetails'align=center noWrap colspan='4'>合计:</td>\n";
                        }
                    }
                    s_Details += "<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;" + base.FormatNumber1(d_TotalNumber.ToString(), 0) + "</td>\n";

                    s_Details += "<td  class='thstyleLeftDetails' align=right noWrap>&nbsp;</td>\n";//money


                    s_Details += " </tr>";

                    if (s_Type == "0")
                    {
                        s_Date = DateTime.Parse(Dtb_Table.Rows[0][1].ToString()).ToShortDateString();
                    }
                    s_House = Dtb_Table.Rows[0]["SED_HouseNo"].ToString();
                }
                s_Details += "</tbody></table></td></tr>";
            }
            //表头
            if (s_ID != "")
            {
                s_Time = "委外日期:" + s_Date;
            }
            else
            {
                s_Time = "日期:" + s_StartDate + " 到" + s_EndDate;
            }
            s_HouseName = "委外厂商:" + base.Base_GetHouseName(s_House);
            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n";
            s_Head += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\" > \n";
            s_Head += "<tr>\n<th colspan=\"9\" class=\"MaterTitle\" style='height:14.25pt'>杭州士腾科技有限公司<br/>原材料委外加工耗料单</th></tr>\n";
            s_Head += "<tr>\n<th colspan=\"4\" class=\"thstyleleft\"  >" + s_HouseName + "</th><th colspan=\"5\" class=\"thstyleRight\" >" + s_Time + "</th></tr>\n";
            s_Head += "<th class=\"thstyle\" >项次</th>\n";
            if (s_ID == "")
            {
                if (s_Type == "0")
                {
                    s_Head += "<th class=\"thstyle\" align=center>委外日期</th>\n";
                }
            }
            s_Head += "<th class=\"thstyle\" align=center>品名</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>型号</th>\n";
            s_Head += "<th class=\"thstyle\">单位</th>\n";
            s_Head += "<th class=\"thstyle\">数量</th>\n";
            s_Head += "<th class=\"thstyle\">单价</th>\n";
            s_Head += "<th class=\"thstyle\">金额</th>\n";
            s_Head += "<th class=\"thstyle\">备注</th>\n";
            s_Head += "</thead><tbody class=\"scrollContent\">";
            s_Details += "</div>";

            this.Lbl_Details.Text = s_Head + s_Details;
        }
    }
}
