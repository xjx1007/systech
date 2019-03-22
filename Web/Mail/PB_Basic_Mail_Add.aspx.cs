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
using MSExcel = Microsoft.Office.Interop.Excel;
using System.Reflection;

public partial class PB_Basic_Mail_Add : BasePage
{
    public string s_PassWord = "";

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
            this.Lbl_Send.Text = "<a href=\"PB_Mail_Setting_List.aspx?ID=" + AM.KNet_StaffNo + "\" target=\"_blank\">设置发件人</a>";
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            this.Tbx_ID.Text = s_ID;
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            string s_OrderNo = Request.QueryString["OrderNo"] == null ? "" : Request.QueryString["OrderNo"].ToString();
            string s_DireOutNo = Request.QueryString["DireOutNo"] == null ? "" : Request.QueryString["DireOutNo"].ToString();
            string s_ScNo = Request.QueryString["ScNo"] == null ? "" : Request.QueryString["ScNo"].ToString();
            string s_CheckNo = Request.QueryString["CheckNo"] == null ? "" : Request.QueryString["CheckNo"].ToString();
            string s_HouseNo = Request.QueryString["HouseNo"] == null ? "" : Request.QueryString["HouseNo"].ToString();
            string s_SuppNo = Request.QueryString["SuppNo"] == null ? "" : Request.QueryString["SuppNo"].ToString();



            base.Base_EMail(this.Ddl_SendEmail);

            this.Tbx_MailType.Text = "0";
            if (s_OrderNo != "")
            {
                ShowOrder(s_OrderNo);
                this.Tbx_MailType.Text = "1";
                this.Tbx_OrderNo.Text = s_OrderNo;
            }
            if (s_DireOutNo != "")
            {
                ShowDireOut(s_DireOutNo);
                this.Tbx_MailType.Text = "2";
                this.Tbx_DirectOutNo.Text = s_DireOutNo;
            }
            if (s_ScNo != "")
            {
                ShowSc(s_ScNo);
                this.Tbx_MailType.Text = "3";
                this.Tbx_ScNo.Text = s_ScNo;
                KNet.BLL.Sc_Produce_Plan Bll = new KNet.BLL.Sc_Produce_Plan();
                KNet.Model.Sc_Produce_Plan model = Bll.GetModel(s_ScNo);

                string JSD = "Sc/Sc_Plan_Print1.aspx?ID=" + model.SPP_ID + "";
                string s_Name = model.SPP_ID + "(" + base.DateToString(model.SPP_STime.ToString()).Replace("/", ".") + ")";
                base.HtmlToPdf(JSD, Server.MapPath("../Sc/PDF"), s_Name);
            }
            if (s_HouseNo != "")
            {
                ShowOrderIn(s_HouseNo);
                this.Tbx_MailType.Text = "5";
                this.Tbx_DirectOutNo.Text = s_HouseNo;
            }
            if (s_CheckNo != "")
            {
                ShowCheckNo(s_CheckNo);
                this.Tbx_MailType.Text = "4";
                this.Tbx_CheckNo.Text = s_CheckNo;
            }
            if (s_SuppNo != "")
            {
                ShowSuppDetails(s_SuppNo);
                this.Tbx_MailType.Text = "6";
                this.Tbx_CheckNo.Text = s_SuppNo;
            }
            this.Tbx_Type.Text = s_Type;
            if (s_ID != "")
            {
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制邮件";
                }
                else
                {
                    this.Lbl_Title.Text = "修改邮件";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }
            else
            {
                this.Lbl_Title.Text = "新增邮件";
            }
        }

    }

    private void ShowSuppDetails(string s_SuppNo)
    {
        AdminloginMess AM = new AdminloginMess();
        try
        {
            try
            {
                KNet.BLL.Knet_Procure_Suppliers Bll_Supp = new KNet.BLL.Knet_Procure_Suppliers();
                KNet.Model.Knet_Procure_Suppliers Model_Supp = Bll_Supp.GetModelB(s_SuppNo);
                this.Tbx_SuppNo.Text = s_SuppNo;
                if (Model_Supp != null)
                {
                    this.Tbx_ReceiveEmail.Text = Model_Supp.SuppEmail;
                }

                string JSD = "Cg/Order/Knet_Procure_WareHouseList_PrintQR.aspx?ID=" + s_SuppNo + "";
                base.HtmlToPdf1(JSD, "../CG/Order/PDF", Model_Supp.SuppName + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString());
                string s_Sql = "select top 1 * from PB_Basic_Mail where PBM_Type=1 and PBM_FID in (select OrderNo from Knet_Procure_OrdersList where SuppNo='" + s_SuppNo + "') order by PBM_MTime desc";
                this.BeginQuery(s_Sql);
                DataTable Dtb_Mail = (DataTable)this.QueryForDataTable();
                if (Dtb_Mail.Rows.Count > 0)
                {
                    this.Tbx_ReceiveEmail.Text = Dtb_Mail.Rows[0]["PBM_ReceiveEmail"].ToString();
                    this.Tbx_Cc.Text = Dtb_Mail.Rows[0]["PBM_Cc"].ToString();
                    this.Tbx_Ms.Text = Dtb_Mail.Rows[0]["PBM_Ms"].ToString();
                }

                string s_url1 = "../CG/Order/Excel/" + Model_Supp.SuppName + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + ".xls";
                string s_URL = Server.MapPath(s_url1);
                this.Tbx_File.Text = "<tr><TD class=\"ListHeadDetails\">跟踪单附件</td>";

                this.Tbx_File.Text += "<TD class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"DetailsFile\" ID=\"DetailsFile\" value='" + s_URL + "'><a href=\"" + s_url1 + "\">" + Model_Supp.SuppName + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + ".xls</a></td>";
                this.Tbx_File.Text += "<TD class=\"ListHeadDetails\"> <A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" border=0></a></TD></tr>";
                this.Tbx_FileUrl.Text = s_URL;
                this.Tbx_Title.Text = "士腾采购跟踪单确认： 请尽快回复确认；详细见明细Excel";
                this.Tbx_Text.Text = "尊敬的 " + Model_Supp.SuppName + ":";
                this.Tbx_Text.Text = " 士腾采购跟踪单确认： 请尽快回复确认；详细见明细Excel";
            }
            catch
            { }
            DateTime Dtm_Date = DateTime.Now;
            /*
                DataSet Dts_Details = (DataSet)this.QueryForDataSet();
                string s_url1 = "../CG/OrderInWareHouse/Excel/" + s_HouseName + "_" + Dtm_Date.ToLongDateString() + ".xls";
                string s_URL = Server.MapPath(s_url1);
                excel.CreateExcelByXml(null, Dts_Details.Tables[0], "供应商确认表", s_URL, false);
                // excel.DataTabletoExcel(Dts_Details.Tables[0], null, "供应商确认表", null);1
                this.Tbx_File.Text = "<tr><TD class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"DetailsFile\" ID=\"DetailsFile\" value='" + s_URL + "'><a href=\"" + s_url1 + "\">" + s_HouseName + "_" + Dtm_Date.ToLongDateString() + ".xls</a></td>";
                this.Tbx_File.Text += "<TD class=\"ListHeadDetails\"> <A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" border=0></a></TD></tr>";
                this.Tbx_FileUrl.Text = s_URL;
                this.Tbx_Title.Text = "士腾发货确认： 请尽快回复确认；详细见明细Excel";
                this.Tbx_Text.Text = "尊敬的 " + s_HouseName + ":";
                this.Tbx_Text.Text = " 士腾发货确认： 请尽快回复确认；详细见明细Excel";
             */
        }
        catch (Exception ex) { }
    }

    private void ShowOrderIn(string s_HouseNo)
    {
        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (s_HouseNo != "")
            {
                KNet.BLL.KNet_Sys_WareHouse Bll = new KNet.BLL.KNet_Sys_WareHouse();
                KNet.Model.KNet_Sys_WareHouse Model = Bll.GetModel(s_HouseNo);

                try
                {
                    KNet.BLL.Knet_Procure_Suppliers Bll_Supp = new KNet.BLL.Knet_Procure_Suppliers();
                    KNet.Model.Knet_Procure_Suppliers Model_Supp = Bll_Supp.GetModelB(Model.SuppNo);
                    this.Tbx_SuppNo.Text = Model.SuppNo;
                    if (Model_Supp != null)
                    {
                        this.Tbx_ReceiveEmail.Text = Model_Supp.SuppEmail;
                    }
                    string s_Sql = "select top 1 * from PB_Basic_Mail where PBM_Type=1 and PBM_FID in (select OrderNo from Knet_Procure_OrdersList where SuppNo='" + Model.SuppNo + "') order by PBM_MTime desc";
                    this.BeginQuery(s_Sql);
                    DataTable Dtb_Mail = (DataTable)this.QueryForDataTable();
                    if (Dtb_Mail.Rows.Count > 0)
                    {
                        this.Tbx_ReceiveEmail.Text = Dtb_Mail.Rows[0]["PBM_ReceiveEmail"].ToString();
                        this.Tbx_Cc.Text = Dtb_Mail.Rows[0]["PBM_Cc"].ToString();
                        this.Tbx_Ms.Text = Dtb_Mail.Rows[0]["PBM_Ms"].ToString();
                    }
                }
                catch
                { }
                DateTime Dtm_Date = DateTime.Now;
                string s_HouseName = Model.HouseName;
                string path;  //文件路径
                Excel excel = new Excel();
                string s_Sql1 = "Select ";
                s_Sql1 += " b.WareHouseNo as 入库单号,b.OrderNo as 材料订单号,ParentOrderNo as OEM订单号,convert(varchar(10),KPO_CheckTime ,120)  as 发货日期,d.SuppName 送货供应商, ";
                s_Sql1 += " e.ProductsName 产品名称,KSP_Code as 产品编码,e.ProductsEdition 型号,WareHouseAmount+isnull(WareHouseBAmount,0) 数量,b.WareHouseRemarks 备注,'' 确认数量 ";
                s_Sql1 += " from Knet_Procure_WareHouseList_Details a join Knet_Procure_WareHouseList b on a.WareHouseNo=b.WareHouseNo ";
                s_Sql1 += " join Knet_Procure_OrdersList c on b.OrderNo=c.OrderNo ";
                s_Sql1 += " join Knet_Procure_Suppliers d on b.suppNo=d.suppNo ";
                s_Sql1 += " join KNet_Sys_Products e on a.ProductsBarCode=e.ProductsBarCode ";
                s_Sql1 += " where b.KPW_Del='0' and b.KPO_QRState=0  ";
                if (s_HouseNo != "")
                {
                    s_Sql1 += " and HouseNo='" + s_HouseNo + "'";
                }
                this.BeginQuery(s_Sql1);
                DataSet Dts_Details = (DataSet)this.QueryForDataSet();
                string s_url1 = "../CG/OrderInWareHouse/Excel/" + s_HouseName + "_" + Dtm_Date.ToLongDateString() + ".xls";
                string s_URL = Server.MapPath(s_url1);
                excel.CreateExcelByXml(null, Dts_Details.Tables[0], "供应商确认表", s_URL, false);
                // excel.DataTabletoExcel(Dts_Details.Tables[0], null, "供应商确认表", null);1
                this.Tbx_File.Text = "<tr><TD class=\"ListHeadDetails\">发货单附件</td>";

                this.Tbx_File.Text += "<TD class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"DetailsFile\" ID=\"DetailsFile\" value='" + s_URL + "'><a href=\"" + s_url1 + "\">" + s_HouseName + "_" + Dtm_Date.ToLongDateString() + ".xls</a></td>";
                this.Tbx_File.Text += "<TD class=\"ListHeadDetails\"> <A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" border=0></a></TD></tr>";
                this.Tbx_FileUrl.Text = s_URL;
                this.Tbx_Title.Text = "士腾发货确认： 请尽快回复确认；详细见明细Excel";
                this.Tbx_Text.Text = "尊敬的 " + s_HouseName + ":";
                this.Tbx_Text.Text = " 士腾发货确认： 请尽快回复确认；详细见明细Excel";
            }
        }
        catch (Exception ex) { }
    }


    private void ShowOrderDetails(string s_SuppNo)
    {
        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (s_SuppNo != "")
            {
                try
                {
                    KNet.BLL.Knet_Procure_Suppliers Bll_Supp = new KNet.BLL.Knet_Procure_Suppliers();
                    KNet.Model.Knet_Procure_Suppliers Model_Supp = Bll_Supp.GetModelB(s_SuppNo);

                    KNet.BLL.KNet_Sys_WareHouse Bll = new KNet.BLL.KNet_Sys_WareHouse();
                    KNet.Model.KNet_Sys_WareHouse Model = Bll.GetModelBySuppNo(s_SuppNo);

                    this.Tbx_SuppNo.Text = Model.SuppNo;
                    if (Model_Supp != null)
                    {
                        this.Tbx_ReceiveEmail.Text = Model_Supp.SuppEmail;
                    }
                    string s_Sql = "select top 1 * from PB_Basic_Mail where PBM_Type=1 and PBM_FID in (select OrderNo from Knet_Procure_OrdersList where SuppNo='" + Model.SuppNo + "') order by PBM_MTime desc";
                    this.BeginQuery(s_Sql);
                    DataTable Dtb_Mail = (DataTable)this.QueryForDataTable();
                    if (Dtb_Mail.Rows.Count > 0)
                    {
                        this.Tbx_ReceiveEmail.Text = Dtb_Mail.Rows[0]["PBM_ReceiveEmail"].ToString();
                        this.Tbx_Cc.Text = Dtb_Mail.Rows[0]["PBM_Cc"].ToString();
                        this.Tbx_Ms.Text = Dtb_Mail.Rows[0]["PBM_Ms"].ToString();
                    }
                    DateTime Dtm_Date = DateTime.Now;
                    string s_HouseName = Model.HouseName;
                    string path;  //文件路径
                    Excel excel = new Excel();
                    string s_Sql1 = "Select ";
                    s_Sql1 += " b.WareHouseNo as 入库单号,b.OrderNo as 材料订单号,ParentOrderNo as OEM订单号,convert(varchar(10),KPO_CheckTime ,120)  as 发货日期,d.SuppName 送货供应商, ";
                    s_Sql1 += " e.ProductsName 产品名称,KSP_Code as 产品编码,e.ProductsEdition 型号,WareHouseAmount+isnull(WareHouseBAmount,0) 数量,b.WareHouseRemarks 备注,'' 确认数量 ";
                    s_Sql1 += " from Knet_Procure_WareHouseList_Details a join Knet_Procure_WareHouseList b on a.WareHouseNo=b.WareHouseNo ";
                    s_Sql1 += " join Knet_Procure_OrdersList c on b.OrderNo=c.OrderNo ";
                    s_Sql1 += " join Knet_Procure_Suppliers d on b.suppNo=d.suppNo ";
                    s_Sql1 += " join KNet_Sys_Products e on a.ProductsBarCode=e.ProductsBarCode ";
                    s_Sql1 += " where b.KPW_Del='0' and b.KPO_QRState=0  ";
                    if (Model.HouseNo != "")
                    {
                        s_Sql1 += " and HouseNo='" + Model.HouseNo + "'";
                    }
                    this.BeginQuery(s_Sql1);
                    DataSet Dts_Details = (DataSet)this.QueryForDataSet();
                    string s_url1 = "../CG/OrderInWareHouse/Excel/" + s_HouseName + "_" + Dtm_Date.ToLongDateString() + ".xls";
                    string s_URL = Server.MapPath(s_url1);
                    excel.CreateExcelByXml(null, Dts_Details.Tables[0], "供应商确认表", s_URL, false);
                    // excel.DataTabletoExcel(Dts_Details.Tables[0], null, "供应商确认表", null);1
                    this.Tbx_File.Text = "<tr>发货确认附件</td>";

                    this.Tbx_File.Text += "<TD class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"DetailsFile\" ID=\"DetailsFile\" value='" + s_URL + "'><a href=\"" + s_url1 + "\">" + s_HouseName + "_" + Dtm_Date.ToLongDateString() + ".xls</a></td>";
                    this.Tbx_File.Text += "<TD class=\"ListHeadDetails\"> <A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" border=0></a></TD></tr>";
                    this.Tbx_FileUrl.Text = s_URL;
                    this.Tbx_Title.Text = "士腾发货确认： 请尽快回复确认；详细见明细Excel";
                    this.Tbx_Text.Text = "尊敬的 " + s_HouseName + ":";
                    this.Tbx_Text.Text = " 士腾发货确认： 请尽快回复确认；详细见明细Excel";
                }
                catch
                { }
            }
        }
        catch (Exception ex) { }
    }

    private void ShowSc(string s_ScNo)
    {
        KNet.BLL.Sc_Produce_Plan Bll = new KNet.BLL.Sc_Produce_Plan();
        KNet.Model.Sc_Produce_Plan Model = Bll.GetModel(s_ScNo);
        AdminloginMess AM = new AdminloginMess();
        try
        {
            try
            {
                KNet.BLL.Knet_Procure_Suppliers Bll_Supp = new KNet.BLL.Knet_Procure_Suppliers();
                KNet.Model.Knet_Procure_Suppliers Model_Supp = Bll_Supp.GetModelB(Model.SPP_SuppNo);
                this.Tbx_SuppNo.Text = Model.SPP_SuppNo;
                if (Model_Supp != null)
                {
                    this.Tbx_ReceiveEmail.Text = Model_Supp.SuppEmail;
                }
                string s_Sql = "select top 1 * from PB_Basic_Mail where PBM_Type=3 and PBM_FID in (select SPP_ID from Sc_Produce_Plan where SPP_SuppNo='" + Model.SPP_SuppNo + "') order by PBM_MTime desc";
                this.BeginQuery(s_Sql);
                DataTable Dtb_Mail = (DataTable)this.QueryForDataTable();
                if (Dtb_Mail.Rows.Count > 0)
                {
                    this.Tbx_ReceiveEmail.Text = Dtb_Mail.Rows[0]["PBM_ReceiveEmail"].ToString();
                    this.Tbx_Cc.Text = Dtb_Mail.Rows[0]["PBM_Cc"].ToString();
                    this.Tbx_Ms.Text = Dtb_Mail.Rows[0]["PBM_Ms"].ToString();
                }
            }
            catch
            { }
            string s_Name = Model.SPP_ID + "(" + base.DateToString(Model.SPP_STime.ToString()).Replace("/", ".") + ")";
            this.Tbx_File.Text = "<tr><TD class=\"ListHeadDetails\">生产计划附件</td>";

            this.Tbx_File.Text += "<TD class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"DetailsFile\" ID=\"DetailsFile\" value='" + Server.MapPath("../Sc/PDF/" + s_Name + ".PDF") + "'><a href=\"../Sc/PDF/" + s_Name + ".PDF\">" + s_Name + ".PDF</a></td>";
            this.Tbx_File.Text += "<TD class=\"ListHeadDetails\"> <A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" border=0></a></TD></tr>";

            this.Tbx_FileUrl.Text = Server.MapPath("../Sc/PDF/" + s_Name + ".PDF");
            this.Tbx_Title.Text = "士腾" + base.DateToString(Model.SPP_STime.ToString()) + "生产计划；详细见明细";
            this.Tbx_Text.Text = "尊敬的 " + base.Base_GetSupplierName(Model.SPP_SuppNo) + ":                             <br/>";
            this.Tbx_Text.Text += "<font size=4>请回复！</font><br/>";
            this.Tbx_Text.Text += "" + base.Base_GetUserName(Model.SPP_Creator) + "<br/>";
        }
        catch { }
    }

    private void ShowOrder(string s_OrderNo)
    {
        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (s_OrderNo != "")
            {
                KNet.BLL.Knet_Procure_OrdersList Bll = new KNet.BLL.Knet_Procure_OrdersList();
                KNet.Model.Knet_Procure_OrdersList Model = Bll.GetModelB(s_OrderNo);

                try
                {
                    KNet.BLL.Knet_Procure_Suppliers Bll_Supp = new KNet.BLL.Knet_Procure_Suppliers();
                    KNet.Model.Knet_Procure_Suppliers Model_Supp = Bll_Supp.GetModelB(Model.SuppNo);
                    this.Tbx_SuppNo.Text = Model.SuppNo;
                    if (Model_Supp != null)
                    {
                        this.Tbx_ReceiveEmail.Text = Model_Supp.SuppEmail;
                    }
                    string s_Sql = "select top 1 * from PB_Basic_Mail where PBM_Type=1 and PBM_FID in (select OrderNo from Knet_Procure_OrdersList where SuppNo='" + Model.SuppNo + "') order by PBM_MTime desc";
                    this.BeginQuery(s_Sql);
                    DataTable Dtb_Mail = (DataTable)this.QueryForDataTable();
                    if (Dtb_Mail.Rows.Count > 0)
                    {
                        this.Tbx_ReceiveEmail.Text = Dtb_Mail.Rows[0]["PBM_ReceiveEmail"].ToString();
                        this.Tbx_Cc.Text = Dtb_Mail.Rows[0]["PBM_Cc"].ToString();
                        this.Tbx_Ms.Text = Dtb_Mail.Rows[0]["PBM_Ms"].ToString();
                    }
                }
                catch
                { }
                this.Tbx_File.Text = "<tr><TD class=\"ListHeadDetails\">采购订单附件</td>";

                this.Tbx_File.Text += "<TD class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"DetailsFile\" ID=\"DetailsFile\" value='" + Server.MapPath("../CG/Order/PDF/" + Model.OrderNo + ".PDF") + "'><a href=\"../CG/Order/PDF/" + Model.OrderNo + ".PDF\">" + Model.OrderNo + ".PDF</a></td>";
                this.Tbx_File.Text += "<TD class=\"ListHeadDetails\"> <A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" border=0></a></TD></tr>";
                this.Tbx_FileUrl.Text = Server.MapPath("../CG/Order/PDF/" + Model.OrderNo + ".PDF");


                //

                string s_DoSql = "Select PBA_Name,PBA_ProductsType,PBA_Remarks,PBA_Creator,max(PBA_Ctime) PBA_Ctime,PBA_URL from PB_Basic_Attachment";
                s_DoSql += " where  PBA_FID in (Select ProductsBarCode from Knet_Procure_OrdersList_Details where OrderNo='" + s_OrderNo + "') ";
                //发送生产部门自己上传的文件
               // s_DoSql += " and PBA_Creator in (select StaffNo  from  KNet_Resource_Staff  where StaffDepart='131161769392290242') ";
                s_DoSql += " AND PBA_Type='Products' and PBA_FID<>'0' and PBA_Del=0 and PBA_ProductsType!='2' Group by PBA_Name,PBA_ProductsType,PBA_Remarks,PBA_Creator,PBA_URL order by max(PBA_Ctime)";
                this.BeginQuery(s_DoSql);
                DataSet ds_Comment = (DataSet)this.QueryForDataSet();
                GridView_Comment.DataSource = ds_Comment.Tables[0];
                GridView_Comment.DataBind();

                if (Model.KPO_Del == 1)
                {
                    this.Tbx_Title.Text = "采购订单号：" + Model.OrderNo + " 的订单取消";

                    this.Tbx_Title.Text = "采购订单号：" + Model.OrderNo + " 的订单更改收货地址";
                    this.Tbx_Text.Text = "尊敬的 " + base.Base_GetSupplierName(Model.SuppNo) + ":                             <br/>";
                    this.Tbx_Text.Text += "<font size=4>1)订单号为" + Model.OrderNo + "的订单取消！<br/>";
                    this.Tbx_Text.Text += "任何特殊情况请提前告知！谢谢合作！</font><br/><p></p><p></p><hr>";

                }
                else
                {
                    this.Tbx_Title.Text = "士腾采购单：" + Model.OrderNo + " 请尽快回复交期；详细见明细";

                    this.Tbx_Text.Text = "尊敬的 " + base.Base_GetSupplierName(Model.SuppNo) + ":                             <br/>";
                    this.Tbx_Text.Text += "1)第一时间确认订单收到<br/>";
                    this.Tbx_Text.Text += "2)上午订单，当天下午<font Color=red size=5>3点</font>前务必确认交期并盖章回传<br/>";
                    this.Tbx_Text.Text += "3)下午订单，第二天中午<font Color=red size=5>11点</font>前务必确认交期并盖章回传<br/>";
                    this.Tbx_Text.Text += "4)请务必核对订单送货地址，按订单上的地址发货！<br/>";
                    this.Tbx_Text.Text += "5)发货后，请及时将送货单电子档发给士腾相关采购人员。<br/>";
                    this.Tbx_Text.Text += "以上要求请务必严格执行！任何特殊情况请提前告知！谢谢合作！<br/><p></p><p></p><hr>";
                }
                if (Model.KPO_IsChange == 1)
                {
                    this.Tbx_Title.Text = "采购订单号：" + Model.OrderNo + " 的订单更改收货地址";
                    this.Tbx_Text.Text = "尊敬的 " + base.Base_GetSupplierName(Model.SuppNo) + ":                             <br/>";
                    this.Tbx_Text.Text += "<font size=4>1)订单号为" + Model.OrderNo + "的订单更改收货地址,收到请回复告知<br/>";
                    this.Tbx_Text.Text += "任何特殊情况请提前告知！谢谢合作！</font><br/><p></p><p></p><hr>";

                }
                //
                KNet.BLL.KNet_Resource_Staff Bll_Staff = new KNet.BLL.KNet_Resource_Staff();
                KNet.Model.KNet_Resource_Staff Model_Staff = Bll_Staff.GetModelC(AM.KNet_StaffNo);

                this.Tbx_Text.Text += "" + AM.KNet_StaffName + "<br/>";
                this.Tbx_Text.Text += "采购部<br/>";
                this.Tbx_Text.Text += "杭州士腾科技有限公司<br/>";
                this.Tbx_Text.Text += "手机：" + Model_Staff.StaffTel + "<br/>";
                this.Tbx_Text.Text += "电话：0571 8899 9497-8821<br/>";
                this.Tbx_Text.Text += "E-mail: " + Model_Staff.StaffEmail + "<br/>";
                this.Tbx_Text.Text += "地址：杭州西湖科技园西园九路7号综合楼四楼 <br/>";
            }
        }
        catch { }
    }

    private void ShowDireOut(string s_DireOutNo)
    {
        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (s_DireOutNo != "")
            {
                KNet.BLL.KNet_WareHouse_DirectOutList Bll = new KNet.BLL.KNet_WareHouse_DirectOutList();
                KNet.Model.KNet_WareHouse_DirectOutList Model = Bll.GetModelB(s_DireOutNo);

                try
                {
                    KNet.BLL.KNet_Sys_WareHouse Bll_WareHouse = new KNet.BLL.KNet_Sys_WareHouse();
                    KNet.Model.KNet_Sys_WareHouse Model_WareHouse = Bll_WareHouse.GetModel(Model.HouseNo);
                    this.Tbx_SuppNo.Text = Model_WareHouse.SuppNo;
                    if (Model_WareHouse != null)
                    {
                        KNet.BLL.Knet_Procure_Suppliers Bll_Suppliers = new KNet.BLL.Knet_Procure_Suppliers();
                        KNet.Model.Knet_Procure_Suppliers Model_Suppliers = Bll_Suppliers.GetModelB(Model_WareHouse.SuppNo);
                        this.Tbx_ReceiveEmail.Text = Model_Suppliers.SuppEmail;
                    }

                    string s_Sql = "select top 1 * from PB_Basic_Mail where PBM_Type=2 and PBM_FID in (select DirectOutNo from KNet_WareHouse_DirectOutList where HouseNo='" + Model.HouseNo + "') order by PBM_MTime desc";
                    this.BeginQuery(s_Sql);
                    DataTable Dtb_Mail = (DataTable)this.QueryForDataTable();
                    if (Dtb_Mail.Rows.Count > 0)
                    {
                        this.Tbx_ReceiveEmail.Text = Dtb_Mail.Rows[0]["PBM_ReceiveEmail"].ToString();
                        this.Tbx_Cc.Text = Dtb_Mail.Rows[0]["PBM_Cc"].ToString();
                        this.Tbx_Ms.Text = Dtb_Mail.Rows[0]["PBM_Ms"].ToString();
                    }
                    this.Tbx_File.Text = "<tr><TD class=\"ListHeadDetails\">发货单附件：</td>";
                    this.Tbx_File.Text += "<TD class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"DetailsFile\" ID=\"DetailsFile\" value='" + Server.MapPath("../Xs/SalesOut/PDF/" + Model.DirectOutNo + ".PDF") + "'><a href=\"../Xs/SalesOut/PDF/" + Model.DirectOutNo + ".PDF\">" + Model.DirectOutNo + ".PDF</a></td>";
                    this.Tbx_File.Text += "<TD class=\"ListHeadDetails\"> <A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" border=0></a></TD></tr>";
                    this.Tbx_FileUrl.Text = Server.MapPath("../Xs/SalesOut/PDF/" + Model.DirectOutNo + ".PDF");

                    this.Tbx_Title.Text = "杭州士腾发货单：(" + base.Base_GetHouseName(Model.HouseNo) + ")(" + base.Base_GetCustomerName(Model.KWD_SCustomerValue) + ")" + Model.DirectOutNo + " 请今天安排发货；并尽快提供物流信息";
                    this.Tbx_Text.Text = "尊敬的 " + base.Base_GetSupplierName(Model_WareHouse.SuppNo) + ":                             <br/>";
                    this.Tbx_Text.Text += " 1、 附件为我司今天发货单，请务必安排今日发货，并于明日10点前提供杭州士腾发货记录单，要求所提供的物流信息准确无误。信息延误或信息不准确将予以处罚。";
                    this.Tbx_Text.Text += " <br/>2、以下是本次发货外箱唛头，请按照要求予以制作和贴箱。<br/>3、随货请附我司检验报告。";
                }
                catch
                { }
            }
        }
        catch { }
    }


    private void ShowCheckNo(string s_CheckNo)
    {
        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (s_CheckNo != "")
            {
                KNet.BLL.Cg_Order_Checklist Bll = new KNet.BLL.Cg_Order_Checklist();
                KNet.Model.Cg_Order_Checklist Model = Bll.GetModel(s_CheckNo);

                string s_SuppNo = "";
                try
                {
                    //看采购类型
                    if (Model.COC_Type == "1")
                    {
                        s_SuppNo = Model.COC_SuppNo;

                        KNet.BLL.Knet_Procure_Suppliers Bll_Supp = new KNet.BLL.Knet_Procure_Suppliers();
                        KNet.Model.Knet_Procure_Suppliers Model_Supp = Bll_Supp.GetModelB(s_SuppNo);
                        this.Tbx_SuppNo.Text = Model.COC_SuppNo;
                        if (Model_Supp != null)
                        {
                            this.Tbx_ReceiveEmail.Text = Model_Supp.SuppEmail;
                        }
                        string s_Sql = "select top 1 * from PB_Basic_Mail where PBM_Type=4 and PBM_FID in (select COC_Code from Cg_Order_Checklist where COC_SuppNo='" + Model.COC_SuppNo + "') order by PBM_MTime desc";
                        this.BeginQuery(s_Sql);
                        DataTable Dtb_Mail = (DataTable)this.QueryForDataTable();
                        if (Dtb_Mail.Rows.Count > 0)
                        {
                            this.Tbx_ReceiveEmail.Text = Dtb_Mail.Rows[0]["PBM_ReceiveEmail"].ToString();
                            this.Tbx_Cc.Text = Dtb_Mail.Rows[0]["PBM_Cc"].ToString();
                            this.Tbx_Ms.Text = Dtb_Mail.Rows[0]["PBM_Ms"].ToString();
                        }
                    }
                    else
                    {
                        KNet.BLL.KNet_Sys_WareHouse Bll_WareHouse = new KNet.BLL.KNet_Sys_WareHouse();
                        KNet.Model.KNet_Sys_WareHouse Model_WareHouse = Bll_WareHouse.GetModel(Model.COC_HouseNo);

                        KNet.BLL.Knet_Procure_Suppliers Bll_Supp = new KNet.BLL.Knet_Procure_Suppliers();
                        KNet.Model.Knet_Procure_Suppliers Model_Supp = Bll_Supp.GetModelB(Model_WareHouse.SuppNo);
                        this.Tbx_SuppNo.Text = Model_Supp.SuppNo;
                        s_SuppNo = Model_Supp.SuppNo;
                        if (Model_Supp != null)
                        {
                            this.Tbx_ReceiveEmail.Text = Model_Supp.SuppEmail;
                        }
                        string s_Sql = "select top 1 * from PB_Basic_Mail where PBM_Type=4 and PBM_FID in (select COC_Code from Cg_Order_Checklist where COC_HouseNo='" + Model.COC_HouseNo + "') order by PBM_MTime desc";
                        this.BeginQuery(s_Sql);
                        DataTable Dtb_Mail = (DataTable)this.QueryForDataTable();
                        if (Dtb_Mail.Rows.Count > 0)
                        {
                            this.Tbx_ReceiveEmail.Text = Dtb_Mail.Rows[0]["PBM_ReceiveEmail"].ToString();
                            this.Tbx_Cc.Text = Dtb_Mail.Rows[0]["PBM_Cc"].ToString();
                            this.Tbx_Ms.Text = Dtb_Mail.Rows[0]["PBM_Ms"].ToString();
                        }
                    }

                }
                catch
                { }
                this.Tbx_File.Text = "<tr><TD class=\"ListHeadDetails\">对账单附件：</td>";

                this.Tbx_File.Text += "<TD class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"DetailsFile\" ID=\"DetailsFile\" value='" + Server.MapPath("../CG/Procure_Check/Excel/" + Model.COC_Code + ".xls") + "'><a href=\"../CG/Procure_Check/Excel/" + Model.COC_Code + ".xls\">" + Model.COC_Code + ".xls</a></td>";
                this.Tbx_File.Text += "<TD class=\"ListHeadDetails\"> <A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" border=0></a></TD></tr>";
                this.Tbx_FileUrl.Text = Server.MapPath("../CG/Procure_Check/Excel/" + Model.COC_Code + ".xls");
                this.Tbx_Title.Text = "士腾采购对账单：" + Model.COC_Code + " 请尽快确认；详细见明细";
                this.Tbx_Text.Text = "尊敬的 " + base.Base_GetSupplierName(s_SuppNo) + ":                             <br/>";
                this.Tbx_Text.Text += "附件是本月截止今天已发货并确认收货的对账单，请确认无误后按此开票，且注意以下4点：<br/>";
                this.Tbx_Text.Text += "1.  确认时间最晚不超过第二天；<br/>";
                this.Tbx_Text.Text += "2.  对账单请签字盖章，并以扫描件回复本邮件；<br/>";
                this.Tbx_Text.Text += "3.  签字盖章的对账单随发票一同寄到士腾；<br/>";
                this.Tbx_Text.Text += "4.  对账单和发票到士腾时间为最晚每月30号，晚于要求时间收到的，将做下月开票处理。<br/>";
                this.Tbx_Text.Text += "谢谢合作！<br/>";


                this.Tbx_Text.Text += AM.KNet_StaffName +"<br/>";
                this.Tbx_Text.Text += "采购部<br/>";
                this.Tbx_Text.Text += "杭州士腾科技有限公司<br/>";
                //this.Tbx_Text.Text += "手机：159 6718 4387<br/>";
                //this.Tbx_Text.Text += "电话：0571 8821 0011 -8041<br/>";
                //this.Tbx_Text.Text += "E-mail: fanghy@bremax.com<br/>";
                //this.Tbx_Text.Text += "地址：杭州市西湖区黄姑山路4号1号楼<br/>";
            }
        }
        catch { }
    }
    private void ShowInfo(string s_ID)
    {
        KNet.BLL.PB_Basic_Mail bll = new KNet.BLL.PB_Basic_Mail();
        KNet.Model.PB_Basic_Mail model = bll.GetModel(s_ID);
        if (model != null)
        {
            this.Tbx_ID.Text = model.PBM_ID.ToString();
            this.Tbx_Code.Text = model.PBM_Code.ToString();
            this.Tbx_SendEmail.Text = model.PBM_SendEmail.ToString();
            this.Tbx_ReceiveEmail.Text = model.PBM_ReceiveEmail.ToString();
            this.Tbx_Text.Text = model.PBM_Text.ToString();
            this.Tbx_File.Text = model.PBM_File.ToString();
            this.Tbx_Title.Text = model.PBM_Title.ToString();
            this.Tbx_Ms.Text = model.PBM_Ms.ToString();
            this.Tbx_Cc.Text = model.PBM_Cc.ToString();
            if (model.PBM_Type == 1)
            {
                this.Tbx_OrderNo.Text = model.PBM_FID;
                this.Tbx_DirectOutNo.Text = "";
                this.Tbx_ScNo.Text = "";
            }
            else if (model.PBM_Type == 2)
            {
                this.Tbx_OrderNo.Text = "";
                this.Tbx_DirectOutNo.Text = model.PBM_FID;
                this.Tbx_ScNo.Text = "";
            }
            else if (model.PBM_Type == 3)
            {
                this.Tbx_OrderNo.Text = "";
                this.Tbx_DirectOutNo.Text = "";
                this.Tbx_ScNo.Text = model.PBM_FID;
            }

        }
    }

    private bool SetValue(KNet.Model.PB_Basic_Mail model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text == "")
            {
                model.PBM_ID = GetMainID();
            }
            else
            {
                model.PBM_ID = this.Tbx_ID.Text;
            }
            if (this.Tbx_ID.Text == "")
            {
                model.PBM_Code = base.GetNewID("PBM_Code", 1);
            }
            else
            {
                model.PBM_Code = this.Tbx_Code.Text;
            }
            model.PBM_SendEmail = this.Ddl_SendEmail.SelectedItem.Text.ToString();
            model.PBM_ReceiveEmail = this.Tbx_ReceiveEmail.Text.ToString();
            model.PBM_Text = KNetPage.KHtmlEncode(this.Tbx_Text.Text.ToString());
            if (this.Tbx_FileUrl.Text != "")
            {
                model.PBM_File = KNetPage.KHtmlEncode(this.Tbx_FileUrl.Text.ToString());
                string s_URl = this.Tbx_FileUrl.Text.ToString();
                if (this.Tbx_MailType.Text == "1")
                {
                    //如果是订单
                    for (int i = 0; i < GridView_Comment.Rows.Count; i++)
                    {
                        CheckBox cb = (CheckBox)GridView_Comment.Rows[i].Cells[0].FindControl("Chbk");
                        TextBox Tbx_Urls = (TextBox)GridView_Comment.Rows[i].FindControl("Tbx_UrlDetails");
                        if (cb.Checked)
                        {
                            if (i == GridView_Comment.Rows.Count - 1)
                            {
                                s_URl += Tbx_Urls.Text;
                                if (this.Tbx_FileUrl.Text != "")
                                {
                                    this.Tbx_FileUrl.Text += "," + urlconvertor(Tbx_Urls.Text);
                                }

                            }
                            else
                            {
                                s_URl += Tbx_Urls.Text + ",";
                                if (this.Tbx_FileUrl.Text != "")
                                {
                                    this.Tbx_FileUrl.Text += "," + urlconvertor( Tbx_Urls.Text);
                                }
                            }
                        }
                       
                    }
                    model.PBM_File = KNetPage.KHtmlEncode(s_URl);
                }

            }
            else
            {
                model.PBM_File = "";
            }
            model.PBM_Title = this.Tbx_Title.Text.ToString();
            model.PBM_Creator = AM.KNet_StaffNo;
            model.PBM_CTime = DateTime.Now;
            model.PBM_Mender = AM.KNet_StaffNo;
            model.PBM_MTime = DateTime.Now;

            model.PBM_Cc = this.Tbx_Cc.Text;
            model.PBM_Ms = this.Tbx_Ms.Text;

            if (this.Tbx_MailType.Text == "1")
            {
                model.PBM_FID = this.Tbx_OrderNo.Text;
            }
            else if (this.Tbx_MailType.Text == "2")
            {
                model.PBM_FID = this.Tbx_DirectOutNo.Text;
            }
            else if (this.Tbx_MailType.Text == "3")
            {
                model.PBM_FID = this.Tbx_ScNo.Text;
            }
            else if (this.Tbx_MailType.Text == "4")
            {
                model.PBM_FID = this.Tbx_CheckNo.Text;
            }
            else if (this.Tbx_MailType.Text == "5")
            {
                model.PBM_FID = this.Tbx_DirectOutNo.Text;
            }
            else
            {
                model.PBM_FID = "";
            }
            model.PBM_Type = int.Parse(this.Tbx_MailType.Text);
            KNet.BLL.PB_Mail_Setting BLL_Mail = new KNet.BLL.PB_Mail_Setting();
            KNet.Model.PB_Mail_Setting Model_Mail = BLL_Mail.GetModel(this.Ddl_SendEmail.SelectedValue);
            this.Tbx_User.Text = Model_Mail.PMS_SendPerson;
            this.Tbx_UserPassWord.Text = Model_Mail.PMS_Password;
            return true;
        }
        catch(Exception ex)
        {
            throw ex;
            return false;
        }


    }
    protected void Btn_Send_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.Model.PB_Basic_Mail model = new KNet.Model.PB_Basic_Mail();
        KNet.BLL.PB_Basic_Mail bll = new KNet.BLL.PB_Basic_Mail();

        if (this.SetValue(model) == false)
        {
            Alert("系统错误！");
            return;
        }
        if (this.Tbx_ID.Text != "")//修改
        {
            try
            {
                if (bll.Update(model))
                {
                    AM.Add_Logs("邮件修改" + this.Tbx_ID.Text);
                    //  base.Base_SendMessage(model.PBM_ID, "邮件： <a href='Web/Notice/PB_Basic_Mail_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PBM_ID + "</a> ");
                    AlertAndRedirect("修改成功！", "PB_Basic_Mail_List.aspx");
                }
                else
                {
                    AM.Add_Logs("邮件修改失败" + this.Tbx_ID.Text);
                    AlertAndRedirect("修改失败！", "PB_Basic_Mail_Add.aspx?ID=" + this.Tbx_ID.Text + "");
                }
            }
            catch { }
        }
        else
        {
            try
            {
                SendEmail SendEmail = new SendEmail();
                string s_message = SendEmail.Base_SendEmail(this.Tbx_ReceiveEmail.Text, this.Tbx_Text.Text, this.Tbx_FileUrl.Text, this.Tbx_Title.Text, this.Ddl_SendEmail.SelectedValue, this.Tbx_Cc.Text, this.Tbx_Ms.Text);
                if ((this.Tbx_DirectOutNo.Text != "") || (this.Tbx_OrderNo.Text != "") || (this.Tbx_ScNo.Text != "") || (this.Tbx_CheckNo.Text != ""))
                {
                    if (s_message == "邮件发送成功")
                    {
                        model.PBM_State = 1;
                    }
                    else
                    {
                        model.PBM_State = 2;
                    }
                    if ((model.PBM_State == 1) && (model.PBM_Type == 1))
                    {
                        //订单发送
                        KNet.BLL.Knet_Procure_OrdersList Bll = new KNet.BLL.Knet_Procure_OrdersList();
                        KNet.Model.Knet_Procure_OrdersList Model = Bll.GetModelB(model.PBM_FID);
                        Model.OrderNo = Model.OrderNo;
                        Model.KPO_IsSend = 1;
                        Bll.UpdateIsSend(Model);
                    }
                    else if ((model.PBM_State == 2) && (model.PBM_Type == 1))
                    {
                        //订单发送
                        KNet.BLL.Knet_Procure_OrdersList Bll = new KNet.BLL.Knet_Procure_OrdersList();
                        KNet.Model.Knet_Procure_OrdersList Model = Bll.GetModelB(model.PBM_FID);
                        Model.OrderNo = Model.OrderNo;
                        Model.KPO_IsSend = 0;
                        Bll.UpdateIsSend(Model);
                    }
                    else if ((model.PBM_State == 1) && (model.PBM_Type == 3))
                    {
                        string s_Sql = " Update Sc_Produce_Plan set SPP_IsSend=1 where SPP_ID='" + model.PBM_FID + "' ";
                        DbHelperSQL.ExecuteSql(s_Sql);
                    }

                    else if ((model.PBM_State == 2) && (model.PBM_Type == 3))
                    {
                        string s_Sql = " Update Sc_Produce_Plan set SPP_IsSend=0 where SPP_ID='" + model.PBM_FID + "' ";
                        DbHelperSQL.ExecuteSql(s_Sql);
                    }
                    if ((model.PBM_State == 1) && (model.PBM_Type == 2))
                    {
                        //发货单发送
                        string sql = "Update KNet_WareHouse_DirectOutList set KWD_IsMail='1' where DirectOutNo='" + model.PBM_FID + "' ";
                        DbHelperSQL.ExecuteSql(sql);
                    }
                    else if ((model.PBM_State == 2) && (model.PBM_Type == 2))
                    {

                        //发货单未发送
                        string sql = "Update KNet_WareHouse_DirectOutList set KWD_IsMail='0' where DirectOutNo='" + model.PBM_FID + "' ";
                        DbHelperSQL.ExecuteSql(sql);
                    }
                    else if ((model.PBM_State == 1) && (model.PBM_Type == 4))
                    {
                        //对账单发送
                        string sql = "Update Cg_Order_Checklist set COC_IsSend='1' where COC_Code='" + model.PBM_FID + "' ";
                        DbHelperSQL.ExecuteSql(sql);
                    }
                    else if ((model.PBM_State == 2) && (model.PBM_Type == 4))
                    {
                        //对账单未发送
                        string sql = "Update Cg_Order_Checklist set COC_IsSend='0' where COC_Code='" + model.PBM_FID + "' ";
                        DbHelperSQL.ExecuteSql(sql);
                    }
                }

                bll.Add(model);
                // base.Base_SendMessage(model.PBN_ReceiveID, "邮件： <a href='Web/Notice/PB_Basic_Mail_View.aspx?ID=" + model.PBN_ID + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PBN_Title + "</a> ");
                AM.Add_Logs("邮件发送" + model.PBM_ID);
                AlertAndClose("新增成功 " + s_message + "！");

                //发送邮件
            }
            catch (Exception ex)
            {
                Alert(ex.Message);
            }
        }
    }
    protected void save_Click(object sender, EventArgs e)
    {
        GetThumbnailImage1();
    }


    #region 资料上传操作
    /// <summary>
    /// 图片上传
    /// </summary>
    protected void GetThumbnailImage1()
    {

        KNet.BLL.PB_Basic_Attachment BLL = new KNet.BLL.PB_Basic_Attachment();
        KNet.Model.PB_Basic_Attachment model = new KNet.Model.PB_Basic_Attachment();
        AdminloginMess AM = new AdminloginMess();
        //类别下面的
        string UploadPath = "../../UpFile/Mail/" + AM.KNet_StaffNo + "/";  //上传路径

        string AutoPath = System.DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "").Replace("/", "");
        //string fileExt = Path.GetExtension(uploadFile1.PostedFile.FileName); //获扩展名
        string FileType = uploadFile.PostedFile.ContentType.ToString(); //文件类型
        string FileName = Path.GetFileName(uploadFile.PostedFile.FileName);
        string filePath = UploadPath + AutoPath + "_" + FileName; //文件名

        this.Tbx_File.Text += "<tr><TD class=\"ListHeadDetails\">&nbsp;</TD><TD class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"DetailsFile\" ID=\"DetailsFile\" value='" + Server.MapPath(filePath) + "'><a href=\"" + UploadPath + "\">" + FileName + "</a></td>";
        this.Tbx_File.Text += "<TD class=\"ListHeadDetails\"> <A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" border=0></a></TD></tr>";
        if (this.Tbx_FileUrl.Text != "")
        {
            this.Tbx_FileUrl.Text += "," + Server.MapPath(filePath);
        }
        else
        {

            this.Tbx_FileUrl.Text += Server.MapPath(filePath);
        }
        if (!Directory.Exists(Server.MapPath(UploadPath)))
        {
            Directory.CreateDirectory(Server.MapPath(UploadPath));
        }
        uploadFile.PostedFile.SaveAs(Server.MapPath(filePath)); //上传

        model.PBA_FID = AM.KNet_StaffNo;
        model.PBA_Type = "Mail";
        model.PBA_ID = GetMainID();
        model.PBA_Name = FileName;
        model.PBA_URL = filePath;
        model.PBA_CTime = DateTime.Now;
        model.PBA_Creator = AM.KNet_StaffNo;
        model.PBA_Remarks = "";
    }
    #endregion
    private string urlconvertor(string imagesurl1)
    {
        string tmpRootDir = Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString());//获取程序根目录
        string imagesurl2 = tmpRootDir+ imagesurl1.Substring(1, imagesurl1.Length-1); //转换成相对路径
        imagesurl2 = imagesurl2.Replace(@"/", @"\");
        return imagesurl2;
    }
}
