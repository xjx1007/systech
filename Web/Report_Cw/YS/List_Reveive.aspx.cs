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

public partial class Web_List_Details : BasePage
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
            Datashow();
        }
    }
    private void Datashow()
    {
        StringBuilder Sb_Detials = new StringBuilder();
        AdminloginMess AM = new AdminloginMess();
        string s_StartDate = Request.QueryString["StartDate"] == null ? "" : Request.QueryString["StartDate"].ToString();
        string s_EndDate = Request.QueryString["EndDate"] == null ? "" : Request.QueryString["EndDate"].ToString();
        string s_Use = Request.QueryString["Use"] == null ? "" : Request.QueryString["Use"].ToString();
        string s_NowDate = DateTime.Now.ToShortTimeString();
        string s_CustomerValue = Request.QueryString["CustomerValue"] == null ? "" : Request.QueryString["CustomerValue"].ToString();
        string s_Have = Request.QueryString["Have"] == null ? "" : Request.QueryString["Have"].ToString();

        if (this.Tbx_Hx.Text != "")
        {
            s_Have = this.Tbx_Hx.Text;
        }
        string s_Sql = "select a.customerValue,DirectOutNo,b.CustomerName,Stime,Type,ProductsBarCode,Number,Price,Money,DetailsID,OutTime,CType,-1*Money as DMoney,case when CType in(0) then d.FPleftMoney else 0 end FPleftMoney,case when CType in(0) then d.FPTotalMoney else 0 end FPTotalMoney ";
        s_Sql += ",isnull(f.FPCount,0) FPCount,v_LeftMoney,v_HxMoney from v_Receive_Real a join KNET_Sales_ClientList b on a.CustomerValue=b.CustomerValue ";
        s_Sql += " join v_DirectOut_FPMoneyDetails d on d.ID=a.ID left join v_DirectOutFp_Count  f on f.CAD_OutNo=a.ID ";
        s_Sql += " where 1=1 ";

        if (s_CustomerValue != "")
        {
            s_Sql += " and  b.CustomerValue='" + s_CustomerValue + "'";
        }

        //仅查看自己
        if (AM.YNAuthority("收款单仅责任人查看") == true)
        {
            if (AM.KNet_StaffName != "项洲")
            {
                s_Sql += " and b.KSC_DutyPerson='" + AM.KNet_StaffNo + "' ";
            }
        }

        if (s_Have == "1")
        {
            s_Sql += " and  a.v_State<>'2'";
        }
        s_Sql += " Order by Stime,Type,SUBSTRING(DirectOutNo,18,12) ";
        string s_Style = "";
        string s_Head = "";
        decimal d_QCTotalMoney = 0, d_TotalNum = 0, d_BqRKTotalMoney = 0, d_BqSKTotalMoney = 0, d_QMTotalMoney = 0, d_DqTotalMoney = 0, d_wDqTotalMoney = 0;
        this.BeginQuery(s_Sql);
        this.QueryForDataTable();
        DataTable Dtb_Table = this.Dtb_Result;
        decimal d_TotalFpMoney = 0;
        decimal d_TotalWFpMoney = 0;
        if (Dtb_Table.Rows.Count > 0)
        {
            decimal d_LeftMoney = 0;
            decimal d_OutTimeMoney = 0;
            for (int i = 0; i < Dtb_Table.Rows.Count; i++)
            {

                string s_Count = Dtb_Table.Rows[i]["FPCount"].ToString();
                if (i % 2 == 0)
                {
                    s_Style = "class='gg'";
                }
                else
                {
                    s_Style = "class='rr'";
                }
                Sb_Detials.Append(" <tr " + s_Style + " onmouseover='setActiveBG(this)'>\n");
                Sb_Detials.Append("<td class='thstyleLeftDetails' align=center Rowspan='" + s_Count + "' noWrap>" + (i + 1).ToString() + "</td>\n");
                Sb_Detials.Append("<td  class='thstyleLeftDetails' align=left  Rowspan='" + s_Count + "' noWrap>" + Dtb_Table.Rows[i]["Type"].ToString() + "</td>\n");
                Sb_Detials.Append("<td  class='thstyleLeftDetails' align=left  Rowspan='" + s_Count + "' noWrap>" + Dtb_Table.Rows[i]["DirectOutNo"].ToString() + "&nbsp;</td>\n");
                Sb_Detials.Append("<td  class='thstyleLeftDetails' align=left  Rowspan='" + s_Count + "' noWrap>" + DateToString(Dtb_Table.Rows[i]["Stime"].ToString()) + "</td>\n");
                Sb_Detials.Append("<td  class='thstyleLeftDetails' align=left  Rowspan='" + s_Count + "' noWrap>" + base.Base_GetProdutsName(Dtb_Table.Rows[i]["ProductsBarCode"].ToString()) + "</td>\n");
                Sb_Detials.Append("<td  class='thstyleLeftDetails' align=left  Rowspan='" + s_Count + "' noWrap>" + base.Base_GetProductsPattern(Dtb_Table.Rows[i]["ProductsBarCode"].ToString()) + "</td>\n");
                Sb_Detials.Append("<td  class='thstyleLeftDetails' align=left  Rowspan='" + s_Count + "' noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["Number"].ToString(), 0) + "</td>\n");
                Sb_Detials.Append("<td  class='thstyleLeftDetails' align=left  Rowspan='" + s_Count + "' noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["Price"].ToString(), 3) + "</td>\n");
                Sb_Detials.Append("<td  class='thstyleLeftDetails' align=left  Rowspan='" + s_Count + "' noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["Money"].ToString(), 2) + "</td>\n");
                Sb_Detials.Append("<td  class='thstyleLeftDetails' align=left  Rowspan='" + s_Count + "' noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["FPleftMoney"].ToString(), 2) + "</td>\n");
                Sb_Detials.Append("<td  class='thstyleLeftDetails' align=left  Rowspan='" + s_Count + "' noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["FPTotalMoney"].ToString(), 2) + "</td>\n");
                d_TotalFpMoney += decimal.Parse(base.FormatNumber1(Dtb_Table.Rows[i]["FPTotalMoney"].ToString(), 2));
                d_TotalWFpMoney += decimal.Parse(base.FormatNumber1(Dtb_Table.Rows[i]["FPleftMoney"].ToString(), 2));

                string s_CType = Dtb_Table.Rows[i]["CType"].ToString();
                #region 发票明细
                if (s_CType == "0")
                {
                    string s_Sql1 = "select isnull(CAB_Stime,'1900-1-1'),case when f.DirectOutNO like '%red%' then -CAO_Money else CAO_Money end CAO_Money,*,h.v_LeftMoney,h.v_HxMoney  from Cw_Account_Bill_Details c ";
                    s_Sql1 += " left join Cw_Account_Bill d on d.CAB_ID=c.CAD_CAAID ";
                    s_Sql1 += " left join Cw_Account_Bill_Outimes e on e.CAO_CADID=d.CAB_ID ";
                    s_Sql1 += " left join KNET_WareHouse_DirectOutList_Details f on c.CAD_OutNo=f.id";
                    s_Sql1 += " join v_DirectOut_FPMoneyDetails g on g.ID=c.CAD_OutNo";
                    s_Sql1 += "  left join v_FPhx_Money h on h.v_CAO_ID=e.CAO_ID  and h.v_DetailsID=f.ID ";
                    s_Sql1 += " where CAD_OutNo='" + Dtb_Table.Rows[i]["DetailsID"].ToString() + "'  ";
                    s_Sql1 += " Order by CAB_BillNumber,CAO_OutDays ";
                    this.BeginQuery(s_Sql1);
                    DataTable Dtb_Bill = (DataTable)this.QueryForDataTable();
                    if (Dtb_Bill.Rows.Count > 0)
                    {
                        for (int j = 0; j < Dtb_Bill.Rows.Count; j++)
                        {
                            if (j != 0)
                            {
                                Sb_Detials.Append("<tr>");
                            }

                            Sb_Detials.Append("<td  class='thstyleLeftDetails'  align=left  width=\"60px\"  >" + DateToString(Dtb_Bill.Rows[j]["CAB_Stime"].ToString()) + "&nbsp;</td>\n");
                            Sb_Detials.Append("<td  class='thstyleLeftDetails' width=\"60px\" align=left  >" + Dtb_Bill.Rows[j]["CAB_BillNumber"].ToString() + "&nbsp;</td>\n");
                            Sb_Detials.Append("<td  class='thstyleLeftDetails' width=\"30px\" align=left  >" + Dtb_Bill.Rows[j]["CAO_OutDays"].ToString() + "</td>\n");
                            Sb_Detials.Append("<td  class='thstyleLeftDetails' width=\"60px\" align=left  >" + DateToString(Dtb_Bill.Rows[j]["CAO_OutTime"].ToString()) + "</td>\n");
                            Sb_Detials.Append("<td  class='thstyleLeftDetails' width=\"60px\" align=right  >" + base.FormatNumber1(Dtb_Bill.Rows[j]["CAO_Money"].ToString(), 2) + "</td>\n");
                            Sb_Detials.Append("<td  class='thstyleLeftDetails'  width=\"60px\" align=right  >" + base.FormatNumber1(Dtb_Bill.Rows[j]["v_HxMoney"].ToString(), 2) + "</td>\n");
                            Sb_Detials.Append("<td  class='thstyleLeftDetails'  width=\"60px\" align=right  >" + base.FormatNumber1(Dtb_Bill.Rows[j]["v_LeftMoney"].ToString(), 2) + "</td>\n");
                            Sb_Detials.Append("<td  class='thstyleLeftDetails'  width=\"60px\" align=right  >" + base.FormatNumber1(Dtb_Bill.Rows[j]["CAO_Money"].ToString(), 2) + "</td>\n");


                            try
                            {

                                if (s_Have == "1")
                                {
                                    d_LeftMoney += decimal.Parse(base.FormatNumber1(Dtb_Bill.Rows[j]["v_LeftMoney"].ToString(), 2));

                                }
                                else
                                {
                                    d_LeftMoney += decimal.Parse(base.FormatNumber1(Dtb_Bill.Rows[j]["CAO_Money"].ToString(), 2));
                                }
                            }
                            catch (Exception ex)
                            { }
                            if (Dtb_Bill.Rows[j]["CAO_OutTime"].ToString() != "")
                            {
                                if (IsOutTime(DateTime.Parse(Dtb_Bill.Rows[j]["CAO_OutTime"].ToString())))
                                {
                                    //如果是超期则还要计算是否是已经核销 如果否则相加
                                    if (decimal.Parse(Dtb_Bill.Rows[j]["v_LeftMoney"].ToString()) != 0)
                                    {

                                        if (s_Have == "1")
                                        {
                                            d_OutTimeMoney += decimal.Parse(base.FormatNumber1(Dtb_Bill.Rows[j]["v_LeftMoney"].ToString(), 2));

                                        }
                                        else
                                        {
                                            d_OutTimeMoney += decimal.Parse(base.FormatNumber1(Dtb_Bill.Rows[j]["CAO_Money"].ToString(), 2));

                                        }
                                    }
                                    d_BqRKTotalMoney += decimal.Parse(base.FormatNumber1(Dtb_Bill.Rows[j]["CAO_Money"].ToString(), 2));
                                }
                            }
                            else
                            {
                                d_OutTimeMoney += 0;
                                d_BqRKTotalMoney += 0;

                            }
                            Sb_Detials.Append("<td  class='thstyleLeftDetails'  >&nbsp;</td>");
                            Sb_Detials.Append("<td  class='thstyleLeftDetails'   align=left >" + d_LeftMoney.ToString() + "</td>");
                            Sb_Detials.Append("<td  class='thstyleLeftDetails' align=left >" + d_OutTimeMoney.ToString() + "</td>");

                            if (j != 0)
                            {
                                Sb_Detials.Append("</tr>");
                            }
                            else
                            {

                                Sb_Detials.Append(" </tr>");
                            }
                        }
                        try
                        {
                            d_LeftMoney += decimal.Parse(base.FormatNumber1(Dtb_Table.Rows[i]["FPleftMoney"].ToString(), 2));

                        }
                        catch
                        { }


                    }
                    else
                    {
                        d_LeftMoney += decimal.Parse(base.FormatNumber1(Dtb_Table.Rows[i]["Money"].ToString(), 2));

                        Sb_Detials.Append("<td  class='thstyleLeftDetails'  colspan=7 >&nbsp;</td>");

                        Sb_Detials.Append("<td  class='thstyleLeftDetails' align=left  Rowspan='" + s_Count + "' noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["Money"].ToString(), 2) + "</td>\n");
                        Sb_Detials.Append("<td  class='thstyleLeftDetails' rowspan='" + s_Count + "' >&nbsp;</td>");
                        Sb_Detials.Append("<td  class='thstyleLeftDetails'  Rowspan='" + s_Count + "'  align=left >" + d_LeftMoney.ToString() + "</td>");
                        Sb_Detials.Append("<td  class='thstyleLeftDetails'  Rowspan='" + s_Count + "'  align=left >" + d_OutTimeMoney.ToString() + "</td>");
                        Sb_Detials.Append(" </tr>");
                    }

                }
                else if (s_CType == "2")//初始化
                {
                    d_LeftMoney += decimal.Parse(base.FormatNumber1(Dtb_Table.Rows[i]["Money"].ToString(), 2));
                    Sb_Detials.Append("<td  class='thstyleLeftDetails'  colspan=3 >&nbsp;</td>");
                    Sb_Detials.Append("<td  class='thstyleLeftDetails' align=center  >" + DateToString(Dtb_Table.Rows[i]["OutTime"].ToString()) + "</td>");
                    Sb_Detials.Append("<td  class='thstyleLeftDetails' align=left  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["Money"].ToString(), 2) + "</td>\n");

                    Sb_Detials.Append("<td  class='thstyleLeftDetails' colspan=2 >&nbsp;</td>");
                    Sb_Detials.Append("<td  class='thstyleLeftDetails' align=left  noWrap>" + base.FormatNumber1(Dtb_Table.Rows[i]["Money"].ToString(), 2) + "</td>\n");

                    if (IsOutTime(DateTime.Parse(Dtb_Table.Rows[i]["OutTime"].ToString())))
                    {
                                    //如果是超期则还要计算是否是已经核销 如果否则相加
                        if (decimal.Parse(Dtb_Table.Rows[i]["Money"].ToString()) != 0)
                        {
                            d_OutTimeMoney += decimal.Parse(base.FormatNumber1(Dtb_Table.Rows[i]["Money"].ToString(), 2));
                        }
                        d_BqRKTotalMoney += decimal.Parse(base.FormatNumber1(Dtb_Table.Rows[i]["Money"].ToString(), 2));
                    }
                    Sb_Detials.Append("<td  class='thstyleLeftDetails' >&nbsp;</td>");

                    Sb_Detials.Append("<td  class='thstyleLeftDetails'  Rowspan='" + s_Count + "'   align=left>" + d_LeftMoney.ToString() + "</td>");
                    Sb_Detials.Append("<td  class='thstyleLeftDetails'  Rowspan='" + s_Count + "'  align=left >" + d_OutTimeMoney.ToString() + "</td>");
                    Sb_Detials.Append(" </tr>");
                }
                else
                {
                    d_LeftMoney += decimal.Parse(base.FormatNumber1(Dtb_Table.Rows[i]["Money"].ToString(), 2));
                    Sb_Detials.Append("<td  class='thstyleLeftDetails'  colspan=5 >&nbsp;</td>");

                    Sb_Detials.Append("<td  class='thstyleLeftDetails' align=Right >" + base.FormatNumber1(Dtb_Table.Rows[i]["v_HxMoney"].ToString(), 2) + "</td>");
                    Sb_Detials.Append("<td  class='thstyleLeftDetails' align=Right >" + base.FormatNumber1(Dtb_Table.Rows[i]["v_LeftMoney"].ToString(), 2) + "</td>");
                    Sb_Detials.Append("<td  class='thstyleLeftDetails'  >&nbsp;</td>");
                    Sb_Detials.Append("<td  class='thstyleLeftDetails' align=left >" + base.FormatNumber1(Dtb_Table.Rows[i]["DMoney"].ToString(), 2) + "</td>");
                    d_BqSKTotalMoney += decimal.Parse(Dtb_Table.Rows[i]["DMoney"].ToString());
                    
                    //如果是超期则还要计算是否是已经核销 如果否则相加
                    if (decimal.Parse(Dtb_Table.Rows[i]["v_LeftMoney"].ToString()) != 0)
                    {
                        d_OutTimeMoney += decimal.Parse(base.FormatNumber1(Dtb_Table.Rows[i]["Money"].ToString(), 2));
                    }
                    Sb_Detials.Append("<td  class='thstyleLeftDetails'  Rowspan='" + s_Count + "'  align=left >" + d_LeftMoney.ToString() + "</td>");
                    Sb_Detials.Append("<td  class='thstyleLeftDetails'  Rowspan='" + s_Count + "'   align=left>" + d_OutTimeMoney.ToString() + "</td>");
                    Sb_Detials.Append(" </tr>");
                }
                #endregion


                try
                {
                    d_TotalNum += decimal.Parse(Dtb_Table.Rows[i]["Number"].ToString());
                    d_QCTotalMoney += decimal.Parse(Dtb_Table.Rows[i]["Money"].ToString());
                }
                catch
                {
                    d_BqSKTotalMoney += decimal.Parse(Dtb_Table.Rows[i]["BqSkMoney"].ToString());
                    d_QMTotalMoney += decimal.Parse(Dtb_Table.Rows[i]["QMMoney"].ToString());
                    d_DqTotalMoney += decimal.Parse(Dtb_Table.Rows[i]["DqMoney"].ToString());
                    d_wDqTotalMoney += decimal.Parse(Dtb_Table.Rows[i]["wDqMoney"].ToString());
                }
            }

        }

        Sb_Detials.Append(" <tr>");
        Sb_Detials.Append("<td  class='thstyleLeftDetails' colspan=6 >合计：</td>");
        Sb_Detials.Append("<td  class='thstyleLeftDetails'  >" + d_TotalNum.ToString() + "</td>");
        Sb_Detials.Append("<td  class='thstyleLeftDetails'  >&nbsp;</td>");
        Sb_Detials.Append("<td  class='thstyleLeftDetails'  >" + d_QCTotalMoney + "</td>");
        Sb_Detials.Append("<td  class='thstyleLeftDetails'  >" + d_TotalWFpMoney + "</td>");
        Sb_Detials.Append("<td  class='thstyleLeftDetails'  >" + d_TotalFpMoney + "</td>");
        Sb_Detials.Append("<td  class='thstyleLeftDetails'  colspan=7 >&nbsp;</td>");
        Sb_Detials.Append("<td  class='thstyleLeftDetails'  >" + d_BqRKTotalMoney + "</td>");
        Sb_Detials.Append("<td  class='thstyleLeftDetails'  >" + d_BqSKTotalMoney + "</td>");
        Sb_Detials.Append("<td  class='thstyleLeftDetails'  colspan=2 >&nbsp;</td>");

        Sb_Detials.Append(" </tr>");
        Sb_Detials.Append("</tbody></table></td></tr>");
        s_Time = "日期:" + s_StartDate + " 到" + s_EndDate;
        StringBuilder Sb_Head=new StringBuilder();
        
        Sb_Head.Append( "<div class=\"tableContainer\" id=\"tableContainer\" >\n");
        Sb_Head.Append( "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\"  >\n<thead class=\"fixedHeader\"> \n");
        Sb_Head.Append( "<tr>\n<th colspan=\"22\" class=\"MaterTitle\" style='height:14.25pt'>杭州士腾科技有限公司<br/>应收帐款往来明细</th></tr>\n");
        Sb_Head.Append( "<tr>\n<th colspan=\"13\" class=\"thstyleleft\"  >客户:" + base.Base_GetCustomerName(s_CustomerValue) + "</th><th colspan=\"9\" class=\"thstyleRight\" >" + s_Time + "</th></tr>\n");
        Sb_Head.Append( "<th class=\"thstyle\"  align=center >序号</th>\n");
        Sb_Head.Append( "<th class=\"thstyle\" align=center >记账类型</th>\n");
        Sb_Head.Append( "<th class=\"thstyle\" align=center >发货单号</th>\n");
        Sb_Head.Append( "<th class=\"thstyle\" align=center >发货日期</th>\n");
        Sb_Head.Append( "<th class=\"thstyle\" align=center >产品名称</th>\n");
        Sb_Head.Append( "<th class=\"thstyle\" align=center >型号</th>\n");
        Sb_Head.Append( "<th class=\"thstyle\" align=center >数量</th>\n");
        Sb_Head.Append( "<th class=\"thstyle\" align=center >单价</th>\n");
        Sb_Head.Append( "<th class=\"thstyle\" align=center >金额</th>\n");
        Sb_Head.Append( "<th class=\"thstyle\" align=center >未开票金额</th>\n");
        Sb_Head.Append( "<th class=\"thstyle\" align=center >开票金额</th>\n");
        Sb_Head.Append( "<th class=\"thstyle\" align=center width=\"60px\">发票日期</th>\n");
        Sb_Head.Append( "<th class=\"thstyle\" align=center width=\"60px\">发票编号</th>\n");
        Sb_Head.Append( "<th class=\"thstyle\" align=center width=\"30px\">天数</th>\n");
        Sb_Head.Append( "<th class=\"thstyle\" align=center width=\"60px\">超期日期</th>\n");
        Sb_Head.Append( "<th class=\"thstyle\" align=center width=\"60px\">超期金额</th>\n");
        Sb_Head.Append( "<th class=\"thstyle\" align=center width=\"60px\">核销</th>\n");
        Sb_Head.Append( "<th class=\"thstyle\" align=center width=\"60px\">未核销</th>\n");
        Sb_Head.Append( "<th class=\"thstyle\" align=center width=\"60px\">借方</th>\n");
        Sb_Head.Append( "<th class=\"thstyle\" align=center >贷方</th>\n");
        Sb_Head.Append( "<th class=\"thstyle\" align=center >余额</th>\n");
        Sb_Head.Append( "<th class=\"thstyle\" align=center >超期</th>\n");
        Sb_Head.Append( "</thead><tbody class=\"scrollContent\">");
        Sb_Detials.Append("</div>");
        this.Lbl_Details.Text = Sb_Head.ToString() + Sb_Detials.ToString();
    }
    private bool IsOutTime(DateTime d_DateTime)
    {
        bool b_Out = false;
        try
        {
            DateTime D_Now = DateTime.Now;
            if (d_DateTime <= D_Now)
            {
                b_Out = true;
            }
        }
        catch
        { }
        return b_Out;
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        this.Tbx_Hx.Text = "0";

        Datashow();

    }
    protected void Button5_Click(object sender, EventArgs e)
    {

        this.Tbx_Hx.Text = "1";
        Datashow();
    }
}
