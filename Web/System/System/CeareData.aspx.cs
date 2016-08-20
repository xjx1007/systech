using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using KNet.DBUtility;
using KNet.Common;

/// <summary>
/// 基本设置
/// </summary>
public partial class Knet_Web_System_CeareData : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        KNet.DBUtility.AdminloginMess AMLanguage = new KNet.DBUtility.AdminloginMess();
        if (AMLanguage.KNet_Soft_StaffLanguage == 2)
        {
            // 1、默认为简体转繁体，编码为utf-8
            Response.Filter = new LU.Web.ChineseConvertor(Response.Filter);
        }
        else if (AMLanguage.KNet_Soft_StaffLanguage == 1)
        {
            // 2、繁体简体转，编码为utf-8
            Response.Filter = new LU.Web.ChineseConvertor(Response.Filter, LU.Web.ChineseConvertor.CCDirection.T2S);
        }
        else
        { }
    }

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
            //系统初始化
            if (AM.YNAuthority("系统初始化") == false)
            {
                this.Button1.Enabled = false;
                this.Button2.Enabled = false;
                this.Button3.Enabled = false;
                this.Button4.Enabled = false;
                this.Button5.Enabled = false;
                this.Button6.Enabled = false;
                this.Button7.Enabled = false;
                this.Button8.Enabled = false;
             //   this.Button9.Enabled = false;
            }
            else
            {
                if (AM.KNet_Soft_WebTest == true) //演示版
                {
                    this.Button1.Enabled = false;
                    this.Button1.Text = "演示版不可操作";

                    this.Button2.Enabled = false;
                    this.Button2.Text = "演示版不可操作";

                    this.Button3.Enabled = false;
                    this.Button3.Text = "演示版不可操作";

                    this.Button4.Enabled = false;
                    this.Button4.Text = "演示版不可操作";

                    this.Button5.Enabled = false;
                    this.Button5.Text = "演示版不可操作";

                    this.Button6.Enabled = false;
                    this.Button6.Text = "演示版不可操作";

                    this.Button7.Enabled = false;
                    this.Button7.Text = "演示版不可操作";

                    this.Button8.Enabled = false;
                    this.Button8.Text = "演示版不可操作";

                    //this.Button9.Enabled = false;
                    //this.Button9.Text = "演示版不可操作";
                }
                else
                {
                    this.Button1.Attributes.Add("onclick", "return confirm('你确定供应商初始化吗?\\n\\n注意：初始化后所有原有数据将被清除，建议操作之前先进行备份操作！')");
                    this.Button2.Attributes.Add("onclick", "return confirm('你确定采购入库初始化吗?\\n\\n注意：初始化后所有原有数据将被清除，建议操作之前先进行备份操作！')");
                    this.Button3.Attributes.Add("onclick", "return confirm('你确定库存管理初始化吗?\\n\\n注意：初始化后所有原有数据将被清除，建议操作之前先进行备份操作！')");
                    this.Button4.Attributes.Add("onclick", "return confirm('你确定销售管理初始化吗?\\n\\n注意：初始化后所有原有数据将被清除，建议操作之前先进行备份操作！')");
                    this.Button5.Attributes.Add("onclick", "return confirm('你确定财务管理初始化吗?\\n\\n注意：初始化后所有原有数据将被清除，建议操作之前先进行备份操作！')");
                    this.Button6.Attributes.Add("onclick", "return confirm('你确定人力资源初始化吗?\\n\\n注意：初始化后所有原有数据将被清除，建议操作之前先进行备份操作！')");
                    this.Button7.Attributes.Add("onclick", "return confirm('你确定系统日志初始化吗?\\n\\n注意：初始化后所有原有数据将被清除，建议操作之前先进行备份操作！')");
                    this.Button8.Attributes.Add("onclick", "return confirm('你确定产品字典初始化吗?\\n\\n注意：初始化后所有原有数据将被清除，建议操作之前先进行备份操作！')");
                   // this.Button9.Attributes.Add("onclick", "return confirm('你确定商城数据初始化吗?\\n\\n注意：初始化后所有原有数据将被清除，建议操作之前先进行备份操作！')");
                }
            }


        }
    }

    /// <summary>
    /// 确定供应商初始化
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            AdminloginMess AMlog = new AdminloginMess();
            string Dosql1 = " TRUNCATE TABLE Knet_Procure_Suppliers";
            string Dosql2 = " TRUNCATE TABLE Knet_Procure_SuppliersPrice";
            DbHelperSQL.ExecuteSql(Dosql1);
            DbHelperSQL.ExecuteSql(Dosql2);

            this.Label1.Text = "供应商初始化-----完成";
            this.Button1.Enabled = false;
            AMlog.Add_Logs("系统管理--->系统初始化--供应商初始化 完成！");
        }
        catch { }
    }

    /// <summary>
    /// 确定采购入库初始化
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            AdminloginMess AMlog = new AdminloginMess();
            string Dosql1 = " TRUNCATE TABLE Knet_Procure_OrdersList";
            string Dosql2 = " TRUNCATE TABLE Knet_Procure_OrdersList_Details";
            string Dosql3 = " TRUNCATE TABLE Knet_Procure_ReceivingList";
            string Dosql4 = " TRUNCATE TABLE Knet_Procure_ReceivingList_Details";
            string Dosql5 = " TRUNCATE TABLE Knet_Procure_ReturnList";
            string Dosql6 = " TRUNCATE TABLE Knet_Procure_ReturnList_Details";
            string Dosql7 = " TRUNCATE TABLE Knet_Procure_ReturnList";
            string Dosql8 = " TRUNCATE TABLE Knet_Procure_WareHouseList";
            string Dosql9 = " TRUNCATE TABLE Knet_Procure_WareHouseList_Details";
            string Dosql10 = " TRUNCATE TABLE Knet_Procure_AskedPrice";

            DbHelperSQL.ExecuteSql(Dosql1);
            DbHelperSQL.ExecuteSql(Dosql2);
            DbHelperSQL.ExecuteSql(Dosql3);
            DbHelperSQL.ExecuteSql(Dosql4);
            DbHelperSQL.ExecuteSql(Dosql5);
            DbHelperSQL.ExecuteSql(Dosql6);
            DbHelperSQL.ExecuteSql(Dosql7);
            DbHelperSQL.ExecuteSql(Dosql8);
            DbHelperSQL.ExecuteSql(Dosql9);
            DbHelperSQL.ExecuteSql(Dosql10);

            this.Label2.Text = "采购入库初始化-----完成";
            this.Button2.Enabled = false;
            AMlog.Add_Logs("系统管理--->系统初始化--采购入库初始化 完成！");
        }
        catch { }
    }
    /// <summary>
    /// 确定库存管理初始化
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            AdminloginMess AMlog = new AdminloginMess();
            string Dosql1 = " TRUNCATE TABLE KNet_WareHouse_AllocateList";
            string Dosql2 = " TRUNCATE TABLE KNet_WareHouse_AllocateList_Details";
            string Dosql3 = " TRUNCATE TABLE KNet_WareHouse_DirectInto";
            string Dosql4 = " TRUNCATE TABLE KNet_WareHouse_DirectInto_Details";
            string Dosql5 = " TRUNCATE TABLE KNet_WareHouse_DirectOutList";
            string Dosql6 = " TRUNCATE TABLE KNet_WareHouse_DirectOutList_Details";
            string Dosql7 = " TRUNCATE TABLE KNet_WareHouse_Ownall";
            string Dosql8 = " TRUNCATE TABLE KNet_WareHouse_Ownall_Water";
            string Dosql9 = " TRUNCATE TABLE KNet_WareHouse_WareCheckList";
            string Dosql0 = " TRUNCATE TABLE KNet_WareHouse_WareCheckList_Details";

            DbHelperSQL.ExecuteSql(Dosql1);
            DbHelperSQL.ExecuteSql(Dosql2);
            DbHelperSQL.ExecuteSql(Dosql3);
            DbHelperSQL.ExecuteSql(Dosql4);
            DbHelperSQL.ExecuteSql(Dosql5);
            DbHelperSQL.ExecuteSql(Dosql6);
            DbHelperSQL.ExecuteSql(Dosql7);
            DbHelperSQL.ExecuteSql(Dosql8);
            DbHelperSQL.ExecuteSql(Dosql9);
            DbHelperSQL.ExecuteSql(Dosql0);

            this.Label3.Text = "库存管理初始化-----完成";
            this.Button3.Enabled = false;
            AMlog.Add_Logs("系统管理--->系统初始化--库存管理初始化 完成！");
        }
        catch { }
    }
    /// <summary>
    /// 确定销售管理初始化
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button4_Click(object sender, EventArgs e)
    {
        try
        {
            AdminloginMess AMlog = new AdminloginMess();
            string Dosql1 = " TRUNCATE TABLE KNet_Sales_BaoPriceList";
            string Dosql2 = " TRUNCATE TABLE KNet_Sales_BaoPriceList_Details";
            string Dosql3 = " TRUNCATE TABLE KNet_Sales_BaoPriceList_fuplist";
            string Dosql4 = " TRUNCATE TABLE KNet_Sales_ClientList";
            string Dosql5 = " TRUNCATE TABLE KNet_Sales_ClientList_AuthList";
            string Dosql6 = " TRUNCATE TABLE KNet_Sales_ContractList";
            string Dosql7 = " TRUNCATE TABLE KNet_Sales_ContractList_Details";
            string Dosql8 = " TRUNCATE TABLE KNet_Sales_OutWareList";
            string Dosql9 = " TRUNCATE TABLE KNet_Sales_OutWareList_Details";
            string Dosql0 = " TRUNCATE TABLE KNet_Sales_OutWareList_FlowList";
            string Dosql10 = " TRUNCATE TABLE KNet_Sales_ReturnList";
            string Dosql11 = " TRUNCATE TABLE KNet_Sales_ReturnList_Details";
            string Dosql12 = " TRUNCATE TABLE KNet_Sales_ReturnList_FlowList";
            string Dosql13 = " TRUNCATE TABLE XS_Compy_LinkMan";//销售联系人
            string Dosql14 = " TRUNCATE TABLE Xs_Customer_Products";
            string Dosql15 = " TRUNCATE TABLE Xs_Products_Prodocts";
            


            DbHelperSQL.ExecuteSql(Dosql1);
            DbHelperSQL.ExecuteSql(Dosql2);
            DbHelperSQL.ExecuteSql(Dosql3);
            DbHelperSQL.ExecuteSql(Dosql4);
            DbHelperSQL.ExecuteSql(Dosql5);
            DbHelperSQL.ExecuteSql(Dosql6);
            DbHelperSQL.ExecuteSql(Dosql7);
            DbHelperSQL.ExecuteSql(Dosql8);
            DbHelperSQL.ExecuteSql(Dosql9);
            DbHelperSQL.ExecuteSql(Dosql0);
            DbHelperSQL.ExecuteSql(Dosql10);
            DbHelperSQL.ExecuteSql(Dosql11);
            DbHelperSQL.ExecuteSql(Dosql12);
            DbHelperSQL.ExecuteSql(Dosql13);
            DbHelperSQL.ExecuteSql(Dosql14);
            DbHelperSQL.ExecuteSql(Dosql15);

            this.Label4.Text = "销售管理初始化-----完成";
            this.Button4.Enabled = false;
            AMlog.Add_Logs("系统管理--->系统初始化--销售管理初始化 完成！");
        }
        catch { }
    }
    /// <summary>
    /// 确定财务管理初始化
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button5_Click(object sender, EventArgs e)
    {
        try
        {
            AdminloginMess AMlog = new AdminloginMess();
            string Dosql1 = " TRUNCATE TABLE KNet_Finance_BankDirectAccess";
            string Dosql2 = " TRUNCATE TABLE KNet_Finance_BankPipeline";
            string Dosql3 = " TRUNCATE TABLE KNet_Finance_BankTransfer";
            string Dosql4 = " TRUNCATE TABLE KNet_Finance_ProcureReceive";
            string Dosql5 = " TRUNCATE TABLE KNet_Finance_ProcureReceive_Details";
            string Dosql6 = " TRUNCATE TABLE KNet_Finance_ProcureReturn";
            string Dosql7 = " TRUNCATE TABLE KNet_Finance_ProcureReturn_Details";
            string Dosql8 = " TRUNCATE TABLE KNet_Finance_Repayment";
            string Dosql9 = " TRUNCATE TABLE KNet_Finance_SalesReceive";
            string Dosql0 = " TRUNCATE TABLE KNet_Finance_SalesReceive_Details";
            string Dosql10 = " TRUNCATE TABLE KNet_Finance_SalesReturn";
            string Dosql11 = " TRUNCATE TABLE KNet_Finance_SalesReturn_Details";
            string Dosql12 = " TRUNCATE TABLE KNet_Finance_Transport";
            string Dosql13 = " TRUNCATE TABLE KNet_Finance_Transport_Details";
            string Dosql14 = " TRUNCATE TABLE KNet_Finance_WageList";
            string Dosql15 = " TRUNCATE TABLE KNet_Finance_WageListGet";
            string Dosql16 = " TRUNCATE TABLE KNet_Finance_WageTip";

            DbHelperSQL.ExecuteSql(Dosql1);
            DbHelperSQL.ExecuteSql(Dosql2);
            DbHelperSQL.ExecuteSql(Dosql3);
            DbHelperSQL.ExecuteSql(Dosql4);
            DbHelperSQL.ExecuteSql(Dosql5);
            DbHelperSQL.ExecuteSql(Dosql6);
            DbHelperSQL.ExecuteSql(Dosql7);
            DbHelperSQL.ExecuteSql(Dosql8);
            DbHelperSQL.ExecuteSql(Dosql9);
            DbHelperSQL.ExecuteSql(Dosql0);
            DbHelperSQL.ExecuteSql(Dosql10);
            DbHelperSQL.ExecuteSql(Dosql11);
            DbHelperSQL.ExecuteSql(Dosql12);
            DbHelperSQL.ExecuteSql(Dosql13);
            DbHelperSQL.ExecuteSql(Dosql14);
            DbHelperSQL.ExecuteSql(Dosql15);
            DbHelperSQL.ExecuteSql(Dosql16);

            this.Label5.Text = "财务管理初始化-----完成";
            this.Button5.Enabled = false;
            AMlog.Add_Logs("系统管理--->系统初始化--财务管理初始化 完成！");
        }
        catch { }
    }
    /// <summary>
    /// 确定人力资源初始化
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button6_Click(object sender, EventArgs e)
    {
        try
        {
            AdminloginMess AMlog = new AdminloginMess();
            string Dosql1 = " TRUNCATE TABLE KNet_Resource_OrganizationalStructure";
            string Dosql2 = " TRUNCATE TABLE KNet_Resource_OutManage";
            string Dosql3 = " DELETE [KNet_Resource_Staff] where WHERE [StaffAdmin]=0";
            DbHelperSQL.ExecuteSql(Dosql1);
            DbHelperSQL.ExecuteSql(Dosql2);
            DbHelperSQL.ExecuteSql(Dosql3);
            this.Label7.Text = "人力资源初始化-----完成";
            this.Button6.Enabled = false;
            AMlog.Add_Logs("系统管理--->系统初始化--人力资源初始化 完成！");
        }
        catch { }

    }
    /// <summary>
    /// 确定系统日志初始化
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button7_Click(object sender, EventArgs e)
    {
        try
        {
            AdminloginMess AMlog = new AdminloginMess();
            string Dosql1 = " TRUNCATE TABLE KNet_Static_logs";
            DbHelperSQL.ExecuteSql(Dosql1);
            this.Label7.Text = "系统日志初始化-----完成";
            this.Button7.Enabled = false;
            AMlog.Add_Logs("系统管理--->系统初始化--系统日志初始化 完成！");
        }
        catch { }
    }
    /// <summary>
    /// 确定产品字典初始化
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button8_Click(object sender, EventArgs e)
    {
        try
        {
            AdminloginMess AMlog = new AdminloginMess();
            string Dosql1 = " TRUNCATE TABLE KNet_Sys_Products";
            DbHelperSQL.ExecuteSql(Dosql1);
            this.Label8.Text = "产品字典初始化-----完成";
            this.Button8.Enabled = false;
            AMlog.Add_Logs("系统管理--->系统初始化--产品字典初始化 完成！");
        }
        catch { }
    }




}
