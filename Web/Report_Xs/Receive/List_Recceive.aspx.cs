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
using System.Data.SqlClient;

using KNet.DBUtility;
using KNet.Common;

public partial class List_Recceive : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            AdminloginMess Am = new AdminloginMess();
            string s_Sql = "select d.KWD_ShipNo,c.DirectOutNo,d.DirectOutDateTime,d.HouseNo,a.CAP_CustomerValue,c.ProductsBarCode,CAPD_Number,CAPD_Price,CAPD_Money,CAPD_FID from Cw_Accounting_Payment a ";
            s_Sql += " left join Cw_Accounting_PaymentDetails b on a.CAP_ID=CAPD_CARID ";
            s_Sql += " join KNet_WareHouse_DirectOutList_Details c on b.CAPD_FID=c.ID ";
            s_Sql += " join KNet_WareHouse_DirectOutList d on c.DirectOutNo=d.DirectOutNo";
            s_Sql += " join KNet_Sys_Products e on c.ProductsBarCode=e.ProductsBarCode";
            s_Sql += " Where 1=1 ";
            string s_StartDate = Request.QueryString["StartDate"] == null ? "" : Request.QueryString["StartDate"].ToString();
            string s_EndDate = Request.QueryString["EndDate"] == null ? "" : Request.QueryString["EndDate"].ToString();
            string s_CustomerValue = Request.QueryString["CustomerValue"] == null ? "" : Request.QueryString["CustomerValue"].ToString();
            string s_ProductsType = Request.QueryString["ProductsType"] == null ? "" : Request.QueryString["ProductsType"].ToString();
            string s_ProductsEdition = Request.QueryString["ProductsEidition"] == null ? "" : Request.QueryString["ProductsEidition"].ToString();
     
            string s_Details="",s_Style="";
            string s_Head = "";
            Decimal DTotalNum = 0, DTotalNet = 0, DRantTotal = 0, DLeftTotalNet = 0;
            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n";
            s_Head += "<thead class=\"fixedHeader\"> \n";
            s_Head += "<tr>\n<th colspan=\"14\" class=\"MaterTitle\" style='height:14.25pt'>杭州士腾科技有限公司<br/>销售应收款明细</th></tr>\n";
            s_Head += "<tr>\n<th colspan=\"8    \" class=\"thstyleleft\"  >" + "制表人:" + Am.KNet_StaffName + "</th><th colspan=\"6\" class=\"thstyleRight\" >" + "日期:" + s_StartDate + " 到 " + s_EndDate + "</th></tr>\n";
            s_Head += "<tr class=\"thstyle\">\n<th>序号</th>\n";
            s_Head += "<th class=\"thstyle\">发货单号</th>\n";
            s_Head += "<th class=\"thstyle\">出库单号</th>\n";
            s_Head += "<th class=\"thstyle\">发货日期</th>\n";
            s_Head += "<th class=\"thstyle\">客户名称</th>\n";
            s_Head += "<th class=\"thstyle\">产品名称</th>\n";
            s_Head += "<th class=\"thstyle\">产品版本</th>\n";
            s_Head += "<th class=\"thstyle\">数量</th>\n";
            s_Head += "<th class=\"thstyle\">销售单价</th>\n";
            s_Head += "<th class=\"thstyle\">金额</th>\n";
            s_Head += "<th class=\"thstyle\">税额</th>\n";
            s_Head += "<th class=\"thstyle\">不含税金额</th>\n";
            s_Head += "<th class=\"thstyle\">开票单号</th>\n";
            s_Head += "<th class=\"thstyle\">开票日期</th>\n";
            s_Head += "</tr>\n";
            s_Head += "</thead><tbody class=\"scrollContent\">";
            if(s_StartDate!="")
            {
                s_Sql += " and d.DirectOutDateTime>='" + s_StartDate + "' ";
            }
            if (s_EndDate != "")
            {
                s_Sql += " and d.DirectOutDateTime<='" + s_EndDate + "' ";
            }
            if (s_CustomerValue != "")
            {
                s_Sql += " and a.CAP_CustomerValue='" + s_CustomerValue + "' ";
            }
            if (s_ProductsEdition != "")
            {
                s_Sql += " and d.ProductsEdition like '%" + s_ProductsEdition + "%' ";
            }
            if(s_ProductsType!="")
            {
                    KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
                    string s_SonID = Bll_ProductsDetails.GetSonIDs(s_ProductsType);
                    s_SonID = s_SonID.Replace(",", "','");
                    s_Sql += " and ProductsType in ('" + s_SonID + "') ";
            }
            s_Sql += " Order by d.DirectOutDateTime ";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table=this.Dtb_Result;

            string s_ID = "";
            if(Dtb_Table.Rows.Count>0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
                    s_ID += Dtb_Table.Rows[i][0].ToString()+",";

                    if(i%2==0)
                    {
                       s_Style="class='gg'";
                    }
                    else
                    {
                        s_Style="class='rr'";
                    }
                    string s_Code = "";
                    KNet.BLL.KNet_Sys_WareHouse BLL_wareHouse = new KNet.BLL.KNet_Sys_WareHouse();
                    KNet.Model.KNet_Sys_WareHouse Model_wareHouse = BLL_wareHouse.GetModel(Dtb_Table.Rows[i][3].ToString());
                    if (Model_wareHouse != null)
                    {
                        KNet.BLL.Knet_Procure_Suppliers Bll_Supp = new KNet.BLL.Knet_Procure_Suppliers();
                        KNet.Model.Knet_Procure_Suppliers Model_Supp = Bll_Supp.GetModelB(Model_wareHouse.SuppNo);
                        if (Model_Supp != null)
                        {

                            s_Code = Model_Supp.SuppCode;
                        }
                    }
                    s_Details += " <tr " + s_Style + " onmouseover='setActiveBG(this)'>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + (i + 1).ToString() + "</td>\n";
                    s_Details += "<td align=left  class='thstyleLeftDetails' noWrap>" + Dtb_Table.Rows[i][0].ToString() + "</td>\n";
                    s_Details += "<td align=left  class='thstyleLeftDetails' noWrap>" + Dtb_Table.Rows[i][1].ToString()+"   "+s_Code+"" + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails'  noWrap>" + DateTime.Parse(Dtb_Table.Rows[i][2].ToString()).ToShortDateString() + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails'  noWrap>" + base.Base_GetCustomerName(Dtb_Table.Rows[i][4].ToString()) + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails'  noWrap>" + base.Base_GetProdutsName(Dtb_Table.Rows[i][5].ToString()) + "</td>\n";
                    s_Details += "<td align=left  class='thstyleLeftDetails' noWrap>" + base.Base_GetProductsEdition(Dtb_Table.Rows[i][5].ToString()) + "</td>\n";
                    s_Details += "<td align=right class='thstyleLeftDetails'  noWrap>" + Dtb_Table.Rows[i][6].ToString() + "</td>\n";//数量
                    string s_Price = Dtb_Table.Rows[i][7].ToString() == "" ? "0" : Dtb_Table.Rows[i][7].ToString();
                    s_Details += "<td align=right class='thstyleLeftDetails'  noWrap>" + s_Price + "</td>\n";//销售   单价

                    decimal d_TotalNet = 0;
                    try
                    {
                        d_TotalNet = decimal.Parse(Dtb_Table.Rows[i][6].ToString()) * decimal.Parse(s_Price);
                    }
                    catch { }
                    s_Details += "<td align=right  class='thstyleLeftDetails' noWrap>" + base.FormatNumber1(d_TotalNet.ToString(), 2) + "</td>\n";//金额
                    string s_RantTotal = base.FormatNumber1(Convert.ToString(d_TotalNet - decimal.Parse(base.FormatNumber1(Convert.ToString(d_TotalNet / decimal.Parse("1.17")), 2))), 2);
                    string s_LeftTotal="0";
                    decimal d_LeftTotal = decimal.Parse(base.FormatNumber1(Convert.ToString(d_TotalNet / decimal.Parse("1.17")),2));
                   
                    s_LeftTotal= base.FormatNumber1(d_LeftTotal.ToString(),2);
                    s_Details += "<td align=right  class='thstyleLeftDetails' noWrap>" + s_RantTotal + "</td>\n";//税额
                    s_Details += "<td align=right  class='thstyleLeftDetails' noWrap>" + s_LeftTotal + "</td>\n";//不含税金额
                    //this.BeginQuery("Select * from Cw_Payment_BillDetails where V_OutNo='" + Dtb_Table.Rows[i]["ID"].ToString() + "'");
                    //this.QueryForDataTable();
                    //if (this.Dtb_Result.Rows.Count > 0)
                    //{
                    //    s_Details += "<td align=right class='thstyleLeftDetails' noWrap>" + Dtb_Result.Rows[0]["v_Money"].ToString() + "</td>\n";//应收款金额
                    //}
                    //else
                    //{
                    //    s_Details += "<td align=right class='thstyleLeftDetails' noWrap>&nbsp;</td>\n";

                    //}
                    string s_BillCodeSql = "";
                    s_BillCodeSql = "select c.CAB_BillNumber,c.CAB_Stime from Cw_Account_Bill_Details a ";
                    s_BillCodeSql += " join Cw_Accounting_PaymentDetails  b on  a.CAD_FID=b.CAPD_ID ";
                    s_BillCodeSql += " join Cw_Account_Bill c on CAB_ID=a.CAD_CAAID ";
                    s_BillCodeSql += " where b.CAPD_FID='" + Dtb_Table.Rows[i]["CAPD_FID"].ToString() + "'";
                    this.BeginQuery(s_BillCodeSql);
                    this.QueryForDataSet();
                    if (Dts_Result.Tables[0].Rows.Count > 0)
                    {
                        s_Details += "<td align=right class='thstyleLeftDetails' noWrap>&nbsp;" + Dts_Result.Tables[0].Rows[0][0].ToString() + "</td>\n";//开票编号
                        s_Details += "<td align=right class='thstyleLeftDetails' noWrap>" + DateTime.Parse(Dts_Result.Tables[0].Rows[0][1].ToString()).ToShortDateString() + "</td>\n";//开票编号
                    }
                    else
                    {
                        s_Details += "<td align=right class='thstyleLeftDetails' noWrap>&nbsp;</td>\n";
                        s_Details += "<td align=right class='thstyleLeftDetails' noWrap>&nbsp;</td>\n";
                    }
                    s_Details +=" </tr>";
                    DRantTotal += Decimal.Parse(s_RantTotal);
                    DLeftTotalNet += Decimal.Parse(s_LeftTotal);
                    DTotalNum += Decimal.Parse(Dtb_Table.Rows[i][6].ToString());
                    DTotalNet += d_TotalNet;
                }
            }
            if (s_ID != "")
            {
                this.Tbx_ID.Text = s_ID.Substring(0,s_ID.Length-1);
            }
            s_Details += " <tr >\n";
            s_Details += "<td  class='thstyleLeftDetails' align=left noWrap colspan=7>合计:" + (Dtb_Table.Rows.Count).ToString() + "</td>\n";
            s_Details += "<td align=right class='thstyleLeftDetails' noWrap>" + DTotalNum.ToString() + "</td>\n";//数量
            s_Details += "<td align=right class='thstyleLeftDetails' noWrap>&nbsp;</td>\n";//单价
            s_Details += "<td align=right class='thstyleLeftDetails'  noWrap>" + base.FormatNumber1(DTotalNet.ToString(), 2) + "</td>\n";//金额
            s_Details += "<td align=right class='thstyleLeftDetails'  noWrap>" + base.FormatNumber1(DRantTotal.ToString(), 2) + "</td>\n";//金额
            s_Details += "<td align=right class='thstyleLeftDetails'  noWrap>" + DLeftTotalNet.ToString() + "</td>\n";//金额
            s_Details += "<td align=right class='thstyleLeftDetails' noWrap>&nbsp;</td>\n";//单价
            s_Details += "<td align=right class='thstyleLeftDetails' noWrap>&nbsp;</td>\n";//单价
            s_Details += " </tr>";
            s_Details += "</tbody></table></div>";

            this.Lbl_Details.Text = s_Head+s_Details;

        }

    }
}
