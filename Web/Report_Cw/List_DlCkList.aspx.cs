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
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
using KNet.Common;

public partial class Web_Report_Xs_List_CkList : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess Am = new AdminloginMess();
            string s_Sql = "Select DirectOutNo,KWD_CWOutTime,HouseNo,KWD_Custmoer,ProductsName,ProductsPattern,DirectOutAmount,KWD_SalesUnitPrice,";
            s_Sql += " DirectOutAmount*KWD_SalesUnitPrice ,DirectOutStaffNo,DirectOutCheckStaffNo,ProductsBarCode,ID,KWD_BNumber,DirectOutCheckYN,KWD_HQState from v_DirectOutList a ";
            s_Sql += "";
            s_Sql += " Where 1=1  ";
            string s_StartDate = Request.QueryString["StartDate"] == null ? "" : Request.QueryString["StartDate"].ToString();
            string s_EndDate = Request.QueryString["EndDate"] == null ? "" : Request.QueryString["EndDate"].ToString();
            string s_CustomerName = Request.QueryString["CustomerName"] == null ? "" : Request.QueryString["CustomerName"].ToString();
            string s_CustomerValue = Request.QueryString["CustomerValue"] == null ? "" : Request.QueryString["CustomerValue"].ToString();

            string s_ProductsType = Request.QueryString["ProductsType"] == null ? "" : Request.QueryString["ProductsType"].ToString();
            string s_CustomerTypes = Request.QueryString["CustomerTypes"] == null ? "" : Request.QueryString["CustomerTypes"].ToString();
            string s_ProductsEdition = Request.QueryString["ProductsEidition"] == null ? "" : Request.QueryString["ProductsEidition"].ToString();
            string s_State = Request.QueryString["State"] == null ? "" : Request.QueryString["State"].ToString();
            string s_Ck = Request.QueryString["Ck"] == null ? "" : Request.QueryString["Ck"].ToString();
            string s_UrlPrice = Request.QueryString["Price"] == null ? "" : Request.QueryString["Price"].ToString();


            string s_Details = "", s_Style = "";
            string s_Head = "";
            Decimal DTotalNum = 0, DTotalNum1 = 0, DTotalNet = 0, DRantTotal = 0, DLeftTotalNet = 0;
            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n";
            s_Head += "<thead class=\"fixedHeader\"> \n";
            s_Head += "<tr>\n<th colspan=\"20\" class=\"MaterTitle\" style='height:14.25pt'>杭州士腾科技有限公司<br/>代理费明细明细</th></tr>\n";
            s_Head += "<tr>\n<th colspan=\"14\" class=\"thstyleleft\"  >" + "制表人:" + Am.KNet_StaffName + "</th><th colspan=\"6\" class=\"thstyleRight\" >" + "日期:" + s_StartDate + " 到 " + s_EndDate + "</th></tr>\n";
            s_Head += "<tr class=\"thstyle\">\n<th>序号</th>\n";
            s_Head += "<th class=\"thstyle\">出库单号</th>\n";
            s_Head += "<th class=\"thstyle\">出库日期</th>\n";
            s_Head += "<th class=\"thstyle\">客户名称</th>\n";
            s_Head += "<th class=\"thstyle\">产品名称</th>\n";
            s_Head += "<th class=\"thstyle\">产品型号</th>\n";
            s_Head += "<th class=\"thstyle\">产品版本</th>\n";
            s_Head += "<th class=\"thstyle\">数量</th>\n";
            s_Head += "<th class=\"thstyle\">销售单价</th>\n";
            s_Head += "<th class=\"thstyle\">金额</th>\n";
            s_Head += "<th class=\"thstyle\">代理费单价</th>\n";
            s_Head += "<th class=\"thstyle\">代理费金额</th>\n";
            s_Head += "<th class=\"thstyle\">累计数量</th>\n";
            s_Head += "<th class=\"thstyle\">发票号</th>\n";
            s_Head += "<th class=\"thstyle\">开票日期</th>\n";
            s_Head += "<th class=\"thstyle\">制单人</th>\n";
            s_Head += "<th class=\"thstyle\">审核</th>\n";
            s_Head += "<th class=\"thstyle\">回签单审批</th>\n</tr>\n";
            s_Head += "</thead><tbody class=\"scrollContent\">";
            if (s_StartDate != "")
            {
                s_Sql += " and a.KWD_CWOutTime>='" + s_StartDate + "' ";
            }
            if (s_EndDate != "")
            {
                s_Sql += " and a.KWD_CWOutTime<='" + s_EndDate + "' ";
            }
            if (s_State != "")
            {
                s_Sql += " and  a.DirectOutCheckYN='" + s_State + "' ";
            }
            if (s_ProductsEdition != "")
            {
                s_Sql += " and ProductsEdition like '%" + s_ProductsEdition + "%' ";
            }
            if (s_ProductsType != "")
            {
                KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
                string s_SonID = Bll_ProductsDetails.GetSonIDs(s_ProductsType);
                s_SonID = s_SonID.Replace(",", "','");
                s_Sql += " and ProductsType in ('" + s_SonID + "') ";
            }
            if (s_Ck != "")
            {
                s_Sql += " and HouseName like '%" + s_Ck + "%' ";
            }
            if (s_UrlPrice == "17.5")
            {
                s_Sql += " and KWD_SalesUnitPrice='17.5' ";
            }
            else if (s_UrlPrice != "")
            {
                s_Sql += " and KWD_SalesUnitPrice<>'17.5' ";
            }
            if ((s_CustomerTypes == "129726189973212926") && (s_CustomerValue != ""))
            {
                s_Sql += " and a.KWD_Custmoer in (Select XCD_CustomerValue from Xs_Customer_Customer a join KNET_Sales_ClientList b on a.XCD_DlCustomerValue=b.CustomerValue where XCD_DlCustomerValue='" + s_CustomerValue + "') ";
            }
            else
            {
                if (s_CustomerName != "")
                {
                    s_Sql += " and a.KWD_Custmoer in (select CustomerValue from KNet_Sales_ClientList where CustomerName like '%" + s_CustomerName + "%')";
                }

                if (s_CustomerTypes != "")
                {
                    s_Sql += " and a.KWD_Custmoer in (select CustomerValue from KNet_Sales_ClientList where CustomerTypes='" + s_CustomerTypes + "' ) ";
                }
            }
            s_Sql += "Order by a.KWD_CWOutTime ";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            //GetThumbnailImage1(Dtb_Table);
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
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + (i + 1).ToString() + "</td>\n";
                    s_Details += "<td align=left  class='thstyleLeftDetails' noWrap>" + Dtb_Table.Rows[i][0].ToString() + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails'  noWrap>" + DateTime.Parse(Dtb_Table.Rows[i][1].ToString()).ToShortDateString() + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails'  noWrap>" + base.Base_GetCustomerName(Dtb_Table.Rows[i][3].ToString()) + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails'  noWrap>" + base.Base_GetProdutsName(Dtb_Table.Rows[i][11].ToString()) + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + base.Base_GetProductsPattern(Dtb_Table.Rows[i][11].ToString()) + "</td>\n";
                    s_Details += "<td align=left  class='thstyleLeftDetails' noWrap>" + base.Base_GetProductsEdition(Dtb_Table.Rows[i][11].ToString()) + "</td>\n";
                    s_Details += "<td align=right class='thstyleLeftDetails'  noWrap>" + Dtb_Table.Rows[i][6].ToString() + "</td>\n";//数量

                    string s_Price = Dtb_Table.Rows[i][7].ToString() == "" ? "0" : Dtb_Table.Rows[i][7].ToString();
                    s_Details += "<td align=right class='thstyleLeftDetails'  noWrap>" + s_Price + "</td>\n";//销售   单价

                    decimal d_TotalNet = 0;
                    try
                    {
                        d_TotalNet = decimal.Parse(Dtb_Table.Rows[i][6].ToString()) * decimal.Parse(s_Price);
                        d_TotalNet = decimal.Parse(base.FormatNumber1(d_TotalNet.ToString(), 2));
                    }
                    catch { }
                    s_Details += "<td align=right  class='thstyleLeftDetails' noWrap>" + base.FormatNumber1(d_TotalNet.ToString(), 2) + "</td>\n";//金额

                    string s_RantTotal = base.FormatNumber1(Convert.ToString(d_TotalNet - decimal.Parse(base.FormatNumber1(Convert.ToString(d_TotalNet / decimal.Parse("1.16")), 2))), 2);
                    string s_LeftTotal = "0";
                    decimal d_LeftTotal = decimal.Parse(base.FormatNumber1(Convert.ToString(d_TotalNet / decimal.Parse("1.16")), 2));

                    s_LeftTotal = base.FormatNumber1(d_LeftTotal.ToString(), 2);

                    decimal d_BasicDlPrice = Convert.ToDecimal(2.900), d_BasicDlPrice1 = Convert.ToDecimal(2.400);
                    decimal d_NowNumber = 0;
                    if (decimal.Parse(s_Price) == decimal.Parse("17.5"))//新价格
                    {
                        d_BasicDlPrice = Convert.ToDecimal(2.600);
                        d_BasicDlPrice1 = Convert.ToDecimal(2.100);
                        DTotalNum1 += Decimal.Parse(Dtb_Table.Rows[i][6].ToString());
                        d_NowNumber = DTotalNum1;
                    }
                    else
                    {
                        DTotalNum += Decimal.Parse(Dtb_Table.Rows[i][6].ToString());
                        d_NowNumber = DTotalNum;
                    }
                    //找代理区间
                    if (d_NowNumber <= 100000)
                    {
                        decimal d_DlMoney = d_BasicDlPrice * decimal.Parse(Dtb_Table.Rows[i][6].ToString());
                        s_Details += "<td align=right  class='thstyleLeftDetails' noWrap>" + d_BasicDlPrice.ToString() + "</td>\n";//单价
                        s_Details += "<td align=right  class='thstyleLeftDetails' noWrap>" + d_DlMoney.ToString() + "</td>\n";//金额
                    }
                    else
                    {
                        string s_DlPrice = "";
                        string s_DlMoney = "",s_DlNumber="";
                        int i_DirectNumber = int.Parse(Dtb_Table.Rows[i][6].ToString());
                        int i_LeftDlNumber = int.Parse(d_NowNumber.ToString()) - 100000;
                        if ((i_DirectNumber >= i_LeftDlNumber) && (i_LeftDlNumber > 0))//如果是这次超过10w 则分开单价
                        {

                            decimal d_DlMoney1 = d_BasicDlPrice * Convert.ToDecimal(i_DirectNumber - d_NowNumber + 100000);
                            decimal d_DlMoney2 = d_BasicDlPrice1 * Convert.ToDecimal(d_NowNumber - 100000);
                            s_DlNumber = "" + Convert.ToString(i_DirectNumber -d_NowNumber+ 100000  ) + "  " + d_BasicDlPrice + "<br>" + Convert.ToString(d_NowNumber - 100000) + "  " + d_BasicDlPrice1 + "";
                            s_DlMoney = "" + d_DlMoney1.ToString() + "<br>" + d_DlMoney2.ToString() + "";
                            s_Details += "<td align=right  class='thstyleLeftDetails' noWrap>" + s_DlNumber + "</td>\n";//单价
                            s_Details += "<td align=right  class='thstyleLeftDetails' noWrap>" + s_DlMoney + "</td>\n";//金额
                        }
                        else
                        {
                            decimal d_DlMoney = d_BasicDlPrice1 * decimal.Parse(i_DirectNumber.ToString());
                            s_Details += "<td align=right  class='thstyleLeftDetails' noWrap>" + d_BasicDlPrice1 + "</td>\n";//单价
                            s_Details += "<td align=right  class='thstyleLeftDetails' noWrap>" + d_DlMoney.ToString() + "</td>\n";//金额

                        }
                    }
                    s_Details += "<td align=right  class='thstyleLeftDetails' noWrap>" + d_NowNumber + "</td>\n";//金额
                    //累计数量
                    /*
                    s_Details += "<td align=right  class='thstyleLeftDetails' noWrap>" + s_RantTotal + "</td>\n";//税额
                    s_Details += "<td align=right  class='thstyleLeftDetails' noWrap>" + s_LeftTotal + "</td>\n";//不含税金额
                     * */
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
                    s_BillCodeSql = "select c.CAB_BillNumber,c.CAB_Stime,c.cab_PayMent from Cw_Account_Bill_Details a ";
                    s_BillCodeSql += " join Cw_Accounting_PaymentDetails  b on  a.CAD_FID=b.CAPD_ID ";
                    s_BillCodeSql += " join Cw_Account_Bill c on CAB_ID=a.CAD_CAAID ";
                    s_BillCodeSql += " where b.CAPD_FID='" + Dtb_Table.Rows[i]["ID"].ToString() + "'";
                    this.BeginQuery(s_BillCodeSql);
                    this.QueryForDataSet();
                    if (Dts_Result.Tables[0].Rows.Count > 0)
                    {
                        s_Details += "<td align=right class='thstyleLeftDetails' noWrap>" + Dts_Result.Tables[0].Rows[0][0].ToString() + "</td>\n";//开票编号
                        s_Details += "<td align=right class='thstyleLeftDetails' noWrap>" + DateTime.Parse(Dts_Result.Tables[0].Rows[0][1].ToString()).ToShortDateString() + "</td>\n";//开票编号
                    }
                    else
                    {
                        s_Details += "<td align=right class='thstyleLeftDetails' noWrap>&nbsp;</td>\n";
                        s_Details += "<td align=right class='thstyleLeftDetails' noWrap>&nbsp;</td>\n";
                    }


                    s_Details += "<td align=center class='thstyleLeftDetails'  noWrap>&nbsp;" + base.Base_GetUserName(Dtb_Table.Rows[i][9].ToString()) + "</td>\n";//制单人
                    if (Dtb_Table.Rows[i]["DirectOutCheckYN"].ToString() == "3")
                    {
                        s_Details += "<td align=center  class='thstyleLeftDetails' noWrap>&nbsp;是</td>\n";//制单人
                    }
                    else
                    {
                        s_Details += "<td align=center  class='thstyleLeftDetails' noWrap>&nbsp;</td>\n";//制单人
                    }

                    if (Dtb_Table.Rows[i]["KWD_HQState"].ToString() == "1")
                    {
                        s_Details += "<td align=center  class='thstyleLeftDetails' noWrap>&nbsp;是</td>\n";//制单人
                    }
                    else
                    {
                        s_Details += "<td align=center  class='thstyleLeftDetails' noWrap>&nbsp;<Font color=red>否</font></td>\n";//制单人
                    }

                    s_Details += " </tr>";
                    DRantTotal += Decimal.Parse(s_RantTotal);
                    DLeftTotalNet += Decimal.Parse(s_LeftTotal);
                    DTotalNet += d_TotalNet;
                }
            }

            s_Details += " <tr >\n";

            s_Details += "<td  class='thstyleLeftDetails' align=left noWrap colspan=7>合计:" + (Dtb_Table.Rows.Count).ToString() + "</td>\n";
            s_Details += "<td align=right class='thstyleLeftDetails' noWrap>" + DTotalNum.ToString() + "</td>\n";//数量
            s_Details += "<td align=right class='thstyleLeftDetails' noWrap>&nbsp;</td>\n";//单价
            s_Details += "<td align=right class='thstyleLeftDetails' noWrap>&nbsp;</td>\n";//单价
            s_Details += "<td align=right class='thstyleLeftDetails'  noWrap>" + base.FormatNumber1(DTotalNet.ToString(), 2) + "</td>\n";//金额
            s_Details += "<td align=right class='thstyleLeftDetails'  noWrap>" + base.FormatNumber1(DRantTotal.ToString(), 2) + "</td>\n";//金额
            s_Details += "<td align=right class='thstyleLeftDetails'  noWrap>" + base.FormatNumber1(DLeftTotalNet.ToString(), 2) + "</td>\n";//金额
            s_Details += "<td align=right class='thstyleLeftDetails' colspan=4 noWrap>&nbsp;</td>\n";//单价
            s_Details += " </tr>";
            s_Details += "</tbody></table></div>";

            this.Lbl_Details.Text = s_Head + s_Details;

        }

    }


    protected void GetThumbnailImage1(DataTable Dtb_Table)
    {
        for (int i = 0; i < Dtb_Table.Rows.Count; i++)
        {

            KNet.Model.PB_Basic_Attachment model = new KNet.Model.PB_Basic_Attachment();
            KNet.BLL.PB_Basic_Attachment BLL = new KNet.BLL.PB_Basic_Attachment();
            AdminloginMess AM = new AdminloginMess();
            //类别下面的
            string UploadPath = "../../UpFile/SalesOut/";  //上传路径
            //string AutoPath = System.DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "").Replace("/", "");
            //string fileExt = Path.GetExtension(uploadFile1.PostedFile.FileName); //获扩展名
            string FileType = ".jpg"; //文件类型
            string FileName = Dtb_Table.Rows[i]["DirectOutNo"].ToString();
            string filePath = UploadPath + FileName + FileType; //大文件名

            if (File.Exists(Server.MapPath(KNetPage.KHtmlEncode(filePath))))
            {
                string s_Sql = "Select * from PB_Basic_Attachment where PBA_Type='SalesOut' and PBA_FID='" + FileName + "' ";
                this.BeginQuery(s_Sql);
                DataTable Dtb_R = (DataTable)this.QueryForDataTable();
                if (Dtb_R.Rows.Count <= 0)
                {
                    model.PBA_FID = FileName;
                    model.PBA_Type = "SalesOut";
                    model.PBA_ID = GetMainID();
                    model.PBA_Name = "回签单";
                    model.PBA_URL = filePath;
                    model.PBA_CTime = DateTime.Now;
                    model.PBA_Creator = AM.KNet_StaffNo;
                    model.PBA_Remarks = "";
                    BLL.Add(model);

                }
            }

        }

    }
}
