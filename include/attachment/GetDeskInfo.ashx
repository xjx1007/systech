
<%@ WebHandler Language="C#" Class="GetDeskInfo" %>
using System;
using System.Web;
using System.Web.SessionState;
using System.Data.SqlClient;
using System.Data;
using KNet.DBUtility;
using KNet.Common;
public class GetDeskInfo : IHttpHandler, IRequiresSessionState
{
    public BasePage basePage = new BasePage();
    public void ProcessRequest(HttpContext context)
    {
        context.Response.Clear();
        context.Response.Buffer = true;
        string s_Return = "";
        string s_ID = context.Request["ID"] == null ? "" : context.Request["ID"].ToString();
        string s_Type = context.Request["Type"] == null ? "" : context.Request["Type"].ToString();
        AdminloginMess AM = new AdminloginMess();
        string s_Sql="";
        try
        {
            switch (s_Type)
            {
                case "Notice":
                    KNet.BLL.Pb_Basic_Notice Bll_Notice = new KNet.BLL.Pb_Basic_Notice();
                    string s_Sql1 = " PBN_ReceiveID like '%" + AM.KNet_StaffNo + "%'  ";

                    s_Sql1 += "order by PBN_MTime desc ";
                    DataSet Dts_Notice = Bll_Notice.GetList(s_Sql1);
                    if (Dts_Notice.Tables[0].Rows.Count > 0)
                    {
                        s_Return += "<table border=\"0\" cellspacing=\"1\" cellpadding=\"2\" width=\"100%\" class=\"small\">\n";

                        for (int i = 0; i < Dts_Notice.Tables[0].Rows.Count; i++)
                        {
                            s_Return += " <tr>\n";
                            s_Return += " <td align=\"left\" style=\"border-bottom: 1px dashed #cccccc;border-right: 1px dashed #cccccc;\">\n";
                            s_Return += " <a href=\"../web/Notice/Pb_Basic_Notice_View.aspx?ID=" + Dts_Notice.Tables[0].Rows[i]["PBN_ID"].ToString() + "\"> " + basePage.Base_GetBasicCodeName("219", Dts_Notice.Tables[0].Rows[i]["PBN_Type"].ToString()) + "：" + Dts_Notice.Tables[0].Rows[i]["PBN_Title"].ToString() + "</a>";
                            s_Return += " </td >\n";
                            s_Return += " </tr>\n";
                        }
                        s_Return += "</table>\n";

                    }
                    break;
                case "Receive":
                    s_Return += "<table border=\"0\" cellspacing=\"5\" cellpadding=\"4\" width=\"100%\" class=\"small\">\n";
                    s_Return += " <tr>\n";
                    s_Return += "<td width=\"100%\" align=\"left\" valign=\"center\" style=\"border-bottom: 1px dashed #cccccc;\">\n";
                    basePage.BeginQuery("Select Count(*),isnull(Sum(Receive),0) from(Select CustomerValue,Sum(YMoney) as Receive From v_Receive where TypeName=1 Group by CustomerValue) aa");
                    basePage.QueryForDataTable();
                    DataTable Dtb_Receive = basePage.Dtb_Result;
                    if (Dtb_Receive.Rows.Count > 0)
                    {
                        s_Return += "<b>应收款客户汇总:</b> 共有 " + Dtb_Receive.Rows[0][0].ToString() + " 家客户，应收总计 " + Dtb_Receive.Rows[0][1].ToString() + " 元 " + "<a href=\"../web/Receive/Cw_Accounting_Payment_List.aspx\">详细</a>";
                    }
                    s_Return += "</td>\n";
                    s_Return += " </tr>\n";
                    s_Return += " <tr>\n";
                    s_Return += "<td width=\"100%\" align=\"left\" valign=\"center\" style=\"border-bottom: 1px dashed #cccccc;\">\n";
                    basePage.BeginQuery("Select Count(*),isnull(Sum(Receive),0) from(Select CustomerValue,Sum(YMoney) as Receive From v_Receive where TypeName=0 Group by CustomerValue) aa");
                    basePage.QueryForDataTable();
                    DataTable Dtb_Receive1 = basePage.Dtb_Result;
                    if (Dtb_Receive1.Rows.Count > 0)
                    {
                        s_Return += "<b>应付款供应商汇总:</b> 共有 " + Dtb_Receive1.Rows[0][0].ToString() + " 家客户，应收总计 " + Dtb_Receive1.Rows[0][1].ToString() + " 元" + "<a href=\"../web/PayMentPlan/Cw_Accounting_Payment_List.aspx\">详细</a>"; ;
                    }
                    s_Return += "</td>\n";
                    s_Return += " </tr>\n";
                    s_Return += " <tr>\n";
                    s_Return += "<td width=\"100%\" align=\"left\" valign=\"center\" style=\"border-bottom: 1px dashed #cccccc;\">\n";
                    s_Sql = "select Count(CAP_CustomerValue),Sum(v_HaveMoney),Sum(LeftMoney) from Cw_Accounting_Payment a join  Cw_Payment_BillSum_Total b on a.CAP_ID=b.V_ID where 1=1 ";
                    if(AM.KNet_IsSale)
                    {
                            s_Sql+=" and a.CAP_DutyPerson='"+AM.KNet_StaffNo+"'";
                    }
                    basePage.BeginQuery(s_Sql);
                    basePage.QueryForDataTable();
                    DataTable Dtb_Receive2 = basePage.Dtb_Result;
                    if (Dtb_Receive2.Rows.Count > 0)
                    {
                        s_Return += "<b>未开票金额:</b> 共有 " + Dtb_Receive2.Rows[0][0].ToString() + " 家客户，总计 " + Dtb_Receive2.Rows[0][2].ToString() + " 元 " + "<a href=\"../web/Receive/Cw_Accounting_Payment_List.aspx\">详细</a>";
                    }
                    s_Return += "</td>\n";
                    s_Return += " </tr>\n";
                      s_Return += " <tr>\n";
                    s_Return += "<td width=\"100%\" align=\"left\" valign=\"center\" style=\"border-bottom: 1px dashed #cccccc;\">\n";
                    s_Sql = "select Count(*),Sum(case when GetDate()>=CAB_OutTime then CAB_Money else 0 end),Sum(case when GetDate()<CAB_OutTime then CAB_Money else 0 end),Sum(CAB_Money) from Cw_Account_Bill where 1=1 ";
                    if(AM.KNet_IsSale)
                    {
                            s_Sql+=" and CAB_DutyPerson='"+AM.KNet_StaffNo+"'";
                    }
                    basePage.BeginQuery(s_Sql);
                    basePage.QueryForDataTable();
                    DataTable Dtb_Receive3 = basePage.Dtb_Result;
                    if (Dtb_Receive3.Rows.Count > 0)
                    {
                        s_Return += "<b>已开票金额:</b> 共有 " + Dtb_Receive3.Rows[0][0].ToString() + " 家客户，帐期内：" + Dtb_Receive3.Rows[0][2].ToString() + " 元  帐期外：" + Dtb_Receive3.Rows[0][1].ToString() + " 元  总计 " + Dtb_Receive3.Rows[0][3].ToString() + " 元 " + "<a href=\"../Web/Bill/Cw_Account_Bill_List.aspx\">详细</a>";
                    }
                    s_Return += "</td>\n";
                    s_Return += " </tr>\n";
                    s_Return += "</table>\n";
                    break;
                case "CustomerView":
                    s_Return += "<table border=\"0\" cellspacing=\"1\" cellpadding=\"2\" width=\"100%\" class=\"small\">\n";

                    if (AM.YNAuthority("合同评审列表"))
                    {
                        s_Return += GetTitleDetails("营销中心");
                        //未完成合同评审
                        s_Return += GetKeyDetails("未完成合同评审", "销售", "../web/Xs/Contract/Xs_Contract_Manage_List.aspx?WhereID=M141219083912354", "Select Count(*) From Xs_Contract_Manage where  XCM_CheckYN=0 ");
                        s_Return += GetKeyDetails("未完成订单评审", "销售", "../web/Xs/SalesContract/KNet_Sales_ContractList_List.aspx?WhereID=26", "Select Count(*) From KNet_Sales_ContractList where  contractCheckyn='0' ");
                        
                    }
                    if (AM.YNAuthority("客户信息列表"))
                    {
                        s_Return += GetTitleDetails("客户");

                        //意向客户
                       // s_Return += GetKeyDetails("意向客户", "客户", "../web/Customer/KNet_Sales_ClientList_Manger.aspx?WhereID=2", "Select Count(*) From KNet_Sales_ClientList where KSC_State='101'");
                        //本月新增客户
                        s_Return += GetKeyDetails("本月新增客户", "客户", "../web/Customer/KNet_Sales_ClientList_Manger.aspx?WhereID=214", "Select Count(*) From KNet_Sales_ClientList where datediff(month,CustomerAddTime,getdate())=0");
                        //负责客户
                        s_Return += GetKeyDetails("负责客户", "客户", "../web/Customer/KNet_Sales_ClientList_Manger.aspx?WhereID=215", "Select Count(*) From KNet_Sales_ClientList where KSC_DutyPerson='" + AM.KNet_StaffNo + "' ");
                    }
                    if (AM.YNAuthority("合同评审列表"))
                    {
                        //未完成合同评审
                      //  s_Return += GetKeyDetails("有审批意见的订单评审", "销售", "../web/SalesContract/KNet_Sales_ContractList_List.aspx?WhereID=63", "Select Count(*) From KNet_Sales_ContractList where   ContractDateTime>'2013-07-1' and ContractCheckYN='1' and ContractNO not in (Select XCV_ContractNo from Xs_Contract_ViewPerson where XCV_Person='" + AM.KNet_StaffNo + "' )   and ContractNO in (select distinct KSF_ContractNo from KNet_Sales_Flow where KSF_Detail<>'' and KFS_Type='0')  ");
                    }
                    s_Return += GetTitleDetails("供应链平台");
                        //生产计划
                    s_Return += GetKeyDetails("未批准用款申请", "供应链", "\"../Web/Cg/Payment/CG_Payment_For_List.aspx?WhereID=M141219101922764\" ", "Select Count(*)   From CG_Payment_For where CPF_State not in ('2','3') ");
                        
                        //生产计划
                    s_Return += GetKeyDetails("生产计划", "生产", "\"../Web/Sc/SC_Plan_Print.aspx\" target=\"_blank\"", "Select Top 1 SPP_Stime  From Sc_Produce_Plan  order by SPP_Stime desc ");
                        
                    //总经理
                    if (AM.KNet_StaffDepart != "129652783693249229")
                    {

                        //if (AM.YNAuthority("发货通知列表"))
                        //{
                        //    //未完成发货通知
                        //    s_Return += GetKeyDetails("未完成发货通知", "销售", "../web/SalesShip/Knet_Sales_Ship_Manage_Manage.aspx?WhereID=47", "Select Count(*) From KNet_Sales_OutWareList where  OutWareCheckyn='0' ");
                        //    //未完成发货通知
                        //    s_Return += GetKeyDetails("未确认发货通知", "销售", "../web/SalesShip/Knet_Sales_Ship_Manage_Manage.aspx?WhereID=64", "Select Count(*) From KNet_Sales_OutWareList where   OutWareNo not in  (Select OutWareNo from KNet_Sales_OutWareList_FlowList where Followend='1') ");
                        //}
                    }
                    if (AM.YNAuthority("采购单列表"))
                    {
                        
                        //未完成发货通知
                        s_Return += GetKeyDetails("未发送采购单", "采购", "../web/Order/Knet_Procure_OpenBilling_Manage.aspx?WhereID=146", "Select Count(*) From Knet_Procure_OrdersList where isnull(KPO_IsSend,0)='0' ");
                    
                    }
                    
                    if (((AM.KNet_StaffDepart == "129652783965723459") &&(AM.KNet_Position == "102")) || (AM.KNet_StaffDepart == "129652784259578018"))//如果是研发中心经理显示
                    {
                        //未审批
                        s_Return += GetKeyDetails("未审核采购单", "采购", "../web/Order/Knet_Procure_OpenBilling_Manage.aspx?WhereID=55", "Select Count(*) From Knet_Procure_OrdersList where OrderCheckYN='0' ");
                    }
                    if (AM.YNAuthority("样品申请列表"))
                    {
                        s_Return += GetTitleDetails("研发中心");
                        //意向客户
                        s_Return += GetKeyDetails("未提交样品", "产品", "../web/ProductsSample/Pb_Products_Sample_List.aspx?WhereID=181", "Select Count(*) From Pb_Products_Sample where   PPS_Dept not in ('13','3')  and PPS_Type='0' ");
                        
                    }
                    s_Return += "</table>\n";
                    break;

            }

        }
        catch { }
        context.Response.Write(s_Return);
        context.Response.Flush();
        context.Response.End();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

    public string GetTitleDetails(string s_Title)
    {
        string s_Return = "";
        try
        {
                s_Return += " <tr>\n";
                s_Return += "<td width=\"100%\" align=\"left\" valign=\"center\" colspan=\"3\" style=\"border-bottom: 1px dashed #cccccc;border-right: 1px dashed #cccccc;\" >\n";
                if (s_Title != "")
                {
                    s_Return += " <font size=2><b>" + s_Title + "</b></font>\n";
                    s_Return += " </td>\n";
                }
              
                s_Return += " </tr>\n";
        }
        catch
        { }
        return s_Return;
    }

    public string GetKeyDetails(string s_Title,string s_Mudel,string s_Url,string s_Sql)
    {
        string s_Return = "";
        try{
            //负责未完成订单评审
            basePage.BeginQuery(s_Sql);
            basePage.QueryForDataTable();
            DataTable Dtb_Customer = basePage.Dtb_Result;
            if (Dtb_Customer.Rows.Count > 0)
            {
                s_Return += " <tr>\n";
                s_Return += "<td width=\"33%\" align=\"left\" valign=\"center\" style=\"border-bottom: 1px dashed #cccccc;border-right: 1px dashed #cccccc;\">\n";
                if (s_Title != "")
                {
                    s_Return += " <a href=" + s_Url + " >&nbsp;&nbsp;&nbsp;&nbsp;" + s_Title + "</a>\n";
                    s_Return += " </td>\n";
                }
                if (s_Mudel != "")
                {
                    s_Return += " <td align=\"left\" valign=\"center\" style=\"border-bottom: 1px dashed #cccccc;border-right: 1px dashed #cccccc;\">\n";
                    s_Return += " " + s_Mudel + "\n";
                    s_Return += " </td>\n";
                }
                s_Return += " <td align=\"left\" valign=\"center\" style=\"border-bottom: 1px dashed #cccccc;border-right: 1px dashed #cccccc;\">\n";
                s_Return += " " + Dtb_Customer.Rows[0][0].ToString() + "\n";
                s_Return += " </td>\n";
                s_Return += " </tr>\n";
            }
        } 
        catch
        {}
        return s_Return;
    }
}