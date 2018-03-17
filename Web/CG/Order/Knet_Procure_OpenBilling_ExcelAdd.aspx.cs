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


public partial class Knet_Procure_WareHouseList_ExcelAdd : BasePage
{
    public string s_MyTable_Detail = "";
    private ArrayList Arr_WareHouseIn;
    protected void Page_Load(object sender, EventArgs e)
    {
        string s_OrderNo = Request.QueryString["OrderNo"] == null ? "" : Request.QueryString["OrderNo"].ToString();
        if (!Page.IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            this.Tbx_ID.Text = base.GetNewID("Knet_Procure_WareHouseList", 0);
            this.BeginQuery("Select * from PB_Basic_Wl ");
            // base.Base_DropBasicCodeBind(this.Ddl_Model, "766");
            this.QueryForDataTable();
            Arr_WareHouseIn = new ArrayList();
            if (s_ID != "")
            {
                if (s_Type == "1")
                {
                    this.Lbl_Title.Text = "复制采购入库导入";
                }
                else
                {
                    this.Lbl_Title.Text = "修改采购入库导入";
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }
            else
            {
                this.Lbl_Title.Text = "采购入库导入";
            }

            this.Pan_First.Visible = true;
            this.Pan_Second.Visible = false;
            this.Pan_Third.Visible = false;
            // base.Base_DropLinkManBind(this.Ddl_LinkMan, this.Tbx_CustomerValue.Value);
        }


    }

    private void ShowInfo(string s_ID)
    {
        KNet.BLL.Knet_Procure_WareHouseList bll = new KNet.BLL.Knet_Procure_WareHouseList();
        KNet.Model.Knet_Procure_WareHouseList model = bll.GetModelB(s_ID);

        if (model.WareHouseCheckYN > 0)
        {
            AlertAndGoBack("已审核，不可修改!");
            return;
        }
    }

    #region 资料上传操作
    /// <summary>
    /// 图片上传
    /// </summary>
    protected string GetThumbnailImage1(KNet.Model.PB_Basic_Attachment model)
    {
        AdminloginMess AM = new AdminloginMess();
        //类别下面的
        string UploadPath = "../../UpFile/Excel/";  //上传路径
        string AutoPath = System.DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "").Replace("/", "");
        //string fileExt = Path.GetExtension(uploadFile1.PostedFile.FileName); //获扩展名
        string FileType = uploadFile.PostedFile.ContentType.ToString(); //文件类型
        string FileName = Path.GetFileName(uploadFile.PostedFile.FileName);
        string filePath = UploadPath + AutoPath + "_" + FileName; //大文件名
        if (!Directory.Exists(Server.MapPath(UploadPath)))
        {
            Directory.CreateDirectory(Server.MapPath(UploadPath));
        }
        uploadFile.PostedFile.SaveAs(Server.MapPath(filePath)); //上传

        model.PBA_FID = this.Tbx_ID.Text;
        model.PBA_Type = "Excel";
        model.PBA_ID = GetMainID();
        model.PBA_Name = FileName;
        model.PBA_URL = filePath;
        model.PBA_CTime = DateTime.Now;
        model.PBA_Creator = AM.KNet_StaffNo;
        model.PBA_Remarks = "";
        this.Tbx_ExcelUrl.Text = filePath;
        this.Lbl_Upload.Text = "<a href=\"" + filePath + "\">" + FileName + "</a><br/>";
        base.GetNewID("Knet_Procure_WareHouseList", 1);
        return filePath;
    }
    #endregion
    protected void Btn_Save_Click(object sender, EventArgs e)
    {

        AdminloginMess AM = new AdminloginMess();

        if (this.Button1.Text == "下一步")
        {

            KNet.Model.PB_Basic_Attachment model = new KNet.Model.PB_Basic_Attachment();
            string FileType = uploadFile.PostedFile.ContentType.ToString(); //文件类型
            string s_FileUrl = GetThumbnailImage1(model);
            try
            {
                KNet.BLL.PB_Basic_Attachment BLL = new KNet.BLL.PB_Basic_Attachment();
                BLL.Add(model);
                AM.Add_Logs("附件上传成功：编号：" + model.PBA_ID);
            }
            catch { }
            if (this.Tbx_ExcelUrl.Text != "")
            {
                this.Pan_First.Visible = false;
                this.Pan_Second.Visible = true;
                this.Button2.Visible = false;
                this.Button1.Visible = true;
            }
            else
            {
                this.Pan_First.Visible = true;
                this.Pan_Second.Visible = false;
                this.Button2.Visible = true;
                this.Button1.Visible = false;
            }
            Excel Excel = new Excel();
            DataTable Dtb_Table = Excel.ExcelFirestToDataTable(this.Tbx_ExcelUrl.Text, " 1=1 ");
            this.Lbl_Details.Text = "<table width=\"100%\" class=\"small\" style=\"background-color: rgb(255, 255, 255);\" border=\"0\" cellspacing=\"1\" cellpadding=\"5\">";
            this.Lbl_Details.Text += "<tbody><tr class=\"windLayerHead\">";
            this.Lbl_Details.Text += "<td width=\"10%\"><b>ERP列</b></td>";
            this.Lbl_Details.Text += "<td width=\"10%\"><b>列 1</b></td>";
            this.Lbl_Details.Text += "<td width=\"10%\"><b>列 2</b></td>";
            this.Lbl_Details.Text += "<td width=\"10%\"><b>列 3</b></td>";
            this.Lbl_Details.Text += "<td width=\"10%\"><b>列 4</b></td>";
            this.Lbl_Details.Text += "<td width=\"10%\"><b>列 5</b></td>";
            this.Lbl_Details.Text += "<td width=\"10%\"><b>列 6</b></td>";
            this.Lbl_Details.Text += "<td width=\"10%\"><b>列 7</b></td>";
            this.Lbl_Details.Text += "</tr>";
            for (int j = 0; j < Dtb_Table.Columns.Count; j++)
            {

                this.Lbl_Details.Text += "<tr>";
                this.Lbl_Details.Text += "<td class=\"ListDetails\">" + GetStrColumn(j) + "</td>";
                this.Lbl_Details.Text += "<td class=\"ListDetails\">" + Dtb_Table.Rows[0][j].ToString() + "</td>";
                this.Lbl_Details.Text += "<td class=\"ListDetails\">" + Dtb_Table.Rows[1][j].ToString() + "</td>";
                this.Lbl_Details.Text += "<td class=\"ListDetails\">" + Dtb_Table.Rows[2][j].ToString() + "</td>";
                this.Lbl_Details.Text += "<td class=\"ListDetails\">" + Dtb_Table.Rows[3][j].ToString() + "</td>";
                this.Lbl_Details.Text += "<td class=\"ListDetails\">" + Dtb_Table.Rows[4][j].ToString() + "</td>";
                this.Lbl_Details.Text += "<td class=\"ListDetails\">" + Dtb_Table.Rows[5][j].ToString() + "</td>";
                this.Lbl_Details.Text += "<td class=\"ListDetails\">" + Dtb_Table.Rows[6][j].ToString() + "</td>";
                this.Lbl_Details.Text += "</tr>";
            }
            this.Lbl_Details.Text += "</tbody></table>";
            this.Button1.Text = "下一步2";
        }
        else if (this.Button1.Text == "下一步2")
        {

            this.Pan_First.Visible = false;
            this.Pan_Second.Visible = false;
            this.Pan_Third.Visible = true;
            this.Button2.Visible = true;
            this.Button1.Visible = false;

            Excel Excel = new Excel();
            DataTable Dtb_Table = Excel.ExcelFirestToDataTable(this.Tbx_ExcelUrl.Text, " 1=1 and f2<>'' ");
            StringBuilder Sb_Str = new StringBuilder();
            #region 采购确认
            Sb_Str.Append("<table width=\"100%\" class=\"small\" style=\"background-color: rgb(255, 255, 255);\" border=\"0\" cellspacing=\"1\" cellpadding=\"5\">");
            Sb_Str.Append("<tbody><tr class=\"windLayerHead\">");
            Sb_Str.Append("<td width=\"45%\" colspan=12 ><b>采购确认信息</b></td>");
            Sb_Str.Append("</tr>");
            Sb_Str.Append("<tr class=\"windLayerHead\">");
            Sb_Str.Append("<td width=\"45%\" colspan=7 align=\"center\"><b>Excel信息</b></td>");
            Sb_Str.Append("<td width=\"45%\" colspan=4 align=\"center\"><b>ERP信息</b></td>");
            Sb_Str.Append("<td width=\"10%\"  rowspan=2><b>操作</b></td>");
            Sb_Str.Append("</tr>");
            Sb_Str.Append("<tr class=\"windLayerHead\">");
            Sb_Str.Append("<td width=\"10%\"><b>序号</b></td>");
            Sb_Str.Append("<td width=\"10%\"><b>采购订单</b></td>");
            Sb_Str.Append("<td width=\"10%\"><b>OEM订单号</b></td>");
            Sb_Str.Append("<td width=\"10%\"><b>采购日期</b></td>");
            Sb_Str.Append("<td width=\"10%\"><b>产品型号</b></td>");
            Sb_Str.Append("<td width=\"10%\"><b>收货单位</b></td>");
            Sb_Str.Append("<td width=\"10%\"><b>数量</b></td>");
            Sb_Str.Append("<td width=\"10%\"><b>订单号</b></td>");
            Sb_Str.Append("<td width=\"10%\"><b>上次交期</b></td>");
            Sb_Str.Append("<td width=\"10%\"><b>交期确认</b></td>");
            Sb_Str.Append("<td width=\"10%\"><b>备注</b></td>");
            Sb_Str.Append("</tr>");
            KNet.BLL.Knet_Procure_OrdersList Bll = new KNet.BLL.Knet_Procure_OrdersList();
            for (int j = 1; j < Dtb_Table.Rows.Count; j++)
            {
                string s_Sql = "select rkState from v_OrderRK where v_orderNo='" + Dtb_Table.Rows[j][3].ToString() + "'";
                this.BeginQuery(s_Sql);
                string s_RkState = this.QueryForReturn();
                if (s_RkState != "1")
                {
                    Sb_Str.Append("<tr>");
                    Sb_Str.Append("<td class=\"ListDetails\">" + Dtb_Table.Rows[j][0].ToString() + "</td>");
                    Sb_Str.Append("<td class=\"ListDetails\">" + Dtb_Table.Rows[j][3].ToString() + "</td>");
                    Sb_Str.Append("<td class=\"ListDetails\">" + Dtb_Table.Rows[j][4].ToString() + "</td>");
                    Sb_Str.Append("<td class=\"ListDetails\">" + Dtb_Table.Rows[j][2].ToString() + "</td>");
                    Sb_Str.Append("<td class=\"ListDetails\">" + Dtb_Table.Rows[j][1].ToString() + "</td>");
                    Sb_Str.Append("<td class=\"ListDetails\">" + Dtb_Table.Rows[j][6].ToString() + "</td>");
                    Sb_Str.Append("<td class=\"ListDetails\">" + Dtb_Table.Rows[j][5].ToString() + "</td>");
                    //查找该采购订单
                    KNet.Model.Knet_Procure_OrdersList Model = Bll.GetModelB(Dtb_Table.Rows[j][3].ToString());

                    string s_OrderNo = "<font color=red>未找到订单</font>";
                    string s_Select = "";
                    if (Model != null)
                    {
                        s_Select = "checked";
                        s_OrderNo = "<a href=\"Knet_Procure_OpenBilling_View.aspx?ID=" + Model.OrderNo + "\" target=\"_blank\">" + Model.OrderNo + "</a>";
                    }


                    Sb_Str.Append("<td class=\"ListDetails\"><input type=\"hidden\" Name=\"OrderNo_" + j.ToString() + "\"  value='" + Dtb_Table.Rows[j][3].ToString() + "'>" + s_OrderNo + "</td>");
                    string Dtm_DateTime = "";
                    try
                    {
                        Dtm_DateTime = base.DateToString(Dtb_Table.Rows[j][7].ToString());
                    }
                    catch
                    { }
                    string s_lastTime = GetLastPreDateTime(Dtb_Table.Rows[j][3].ToString());
                    Sb_Str.Append("<td class=\"ListDetails\"><input type=\"hidden\"  Name=\"LastPreDate_" + j.ToString() + "\"  value='" + s_lastTime + "'>" + s_lastTime + "</td>");
                    Sb_Str.Append("<td class=\"ListDetails\"><input type=\"text\"  Class=\"Wdate\" style=\"width:70px;\"  Name=\"PreDate_" + j.ToString() + "\" onFocus=\"WdatePicker()\"  value='" + Dtm_DateTime + "'></td>");
                    Sb_Str.Append("<td class=\"ListDetails\">");
                    Sb_Str.Append("<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\"  Name=\"FollowText_" + j.ToString() + "\"  value='" + Dtb_Table.Rows[j][13].ToString() + "'></td>");
                    Sb_Str.Append("</td>");
                    Sb_Str.Append("<td class=\"ListDetails\"><input type=\"Checkbox\" name=\"chk_select_" + j.ToString() + "\" " + s_Select + "></td>");
                    Sb_Str.Append("</tr>");
                }
            }
            Sb_Str.Append("</tbody></table>");

            #endregion

            #region 采购入库
            #endregion
            Sb_Str.Append("<table width=\"100%\" class=\"small\" style=\"background-color: rgb(255, 255, 255);\" border=\"0\" cellspacing=\"1\" cellpadding=\"5\">");
            Sb_Str.Append("<tbody><tr class=\"windLayerHead\">");
            Sb_Str.Append("<td width=\"45%\" colspan=16 ><b>批量入库信息</b></td>");
            Sb_Str.Append("</tr>");
            Sb_Str.Append("<tr class=\"windLayerHead\">");
            Sb_Str.Append("<td width=\"45%\" colspan=7 align=\"center\"><b>Excel信息</b></td>");
            Sb_Str.Append("<td width=\"45%\" colspan=8 align=\"center\"><b>ERP信息</b></td>");
            Sb_Str.Append("<td width=\"10%\" rowspan=2><b>操作</b></td>");
            Sb_Str.Append("</tr>");
            Sb_Str.Append("<tr class=\"windLayerHead\">");
            Sb_Str.Append("<td width=\"10%\"><b>序号</b></td>");
            Sb_Str.Append("<td width=\"10%\"><b>采购订单</b></td>");
            Sb_Str.Append("<td width=\"10%\"><b>OEM订单号</b></td>");
            Sb_Str.Append("<td width=\"10%\"><b>采购日期</b></td>");
            Sb_Str.Append("<td width=\"10%\"><b>产品型号</b></td>");
            Sb_Str.Append("<td width=\"10%\"><b>收货单位</b></td>");
            Sb_Str.Append("<td width=\"10%\"><b>数量</b></td>");
            Sb_Str.Append("<td width=\"10%\"><b>订单号</b></td>");
            Sb_Str.Append("<td width=\"10%\"><b>入库日期</b></td>");
            Sb_Str.Append("<td width=\"10%\"><b>入库仓库</b></td>");
            Sb_Str.Append("<td width=\"10%\"><b>入库数量</b></td>");
            Sb_Str.Append("<td width=\"10%\"><b>备品数量</b></td>");
            Sb_Str.Append("<td width=\"10%\"><b>物流</b></td>");
            Sb_Str.Append("<td width=\"10%\"><b>单号</b></td>");
            Sb_Str.Append("<td width=\"10%\"><b>备注</b></td>");
            Sb_Str.Append("</tr>");
            for (int j = 1; j < Dtb_Table.Rows.Count; j++)
            {
                string s_Sql = "select rkState from v_OrderRK where v_orderNo='" + Dtb_Table.Rows[j][3].ToString() + "'";
                this.BeginQuery(s_Sql);
                string s_RkState = this.QueryForReturn();
                if (s_RkState != "1")
                {
                    Sb_Str.Append("<tr>");
                    Sb_Str.Append("<td class=\"ListDetails\">" + Dtb_Table.Rows[j][0].ToString() + "</td>");
                    Sb_Str.Append("<td class=\"ListDetails\">" + Dtb_Table.Rows[j][3].ToString() + "</td>");
                    Sb_Str.Append("<td class=\"ListDetails\">" + Dtb_Table.Rows[j][4].ToString() + "</td>");
                    Sb_Str.Append("<td class=\"ListDetails\">" + Dtb_Table.Rows[j][2].ToString() + "</td>");
                    Sb_Str.Append("<td class=\"ListDetails\">" + Dtb_Table.Rows[j][1].ToString() + "</td>");
                    Sb_Str.Append("<td class=\"ListDetails\">" + Dtb_Table.Rows[j][6].ToString() + "</td>");
                    Sb_Str.Append("<td class=\"ListDetails\">" + Dtb_Table.Rows[j][5].ToString() + "</td>");
                    //查找该采购订单
                    KNet.Model.Knet_Procure_OrdersList Model = Bll.GetModelB(Dtb_Table.Rows[j][3].ToString());

                    string s_OrderNo = "<font color=red>未找到订单</font>";
                    string s_Select = "";
                    if (Model != null)
                    {
                        s_Select = "checked";
                        s_OrderNo = "<a href=\"Knet_Procure_OpenBilling_View.aspx?ID=" + Model.OrderNo + "\" target=\"_blank\">" + Model.OrderNo + "</a>";
                    }

                    Sb_Str.Append("<td class=\"ListDetails\"><input type=\"hidden\" Name=\"WareHouseOrderNo_" + j.ToString() + "\"  value='" + Dtb_Table.Rows[j][3].ToString() + "'><input type=\"hidden\" Name=\"ProductsPattern_" + j.ToString() + "\"  value='" + Dtb_Table.Rows[j][1].ToString() + "'>" + s_OrderNo + "</td>");
                    string Dtm_DateTime = "";
                    try
                    {
                        Dtm_DateTime = base.DateToString(Dtb_Table.Rows[j][8].ToString());
                    }
                    catch
                    { }
                    Sb_Str.Append("<td class=\"ListDetails\"><input type=\"text\"  Class=\"Wdate\" style=\"width:70px;\"  Name=\"WareHouseDate_" + j.ToString() + "\" onFocus=\"WdatePicker()\"  value='" + Dtm_DateTime + "'></td>");
                    Sb_Str.Append("<td class=\"ListDetails\">");

                    string s_HouseSql = "select * from KNet_Sys_WareHouse where KSW_Type=0 order by HouseName ";
                    this.BeginQuery(s_HouseSql);
                    DataTable Dtb_houseNo = (DataTable)this.QueryForDataTable();
                    if (Dtb_houseNo.Rows.Count > 0)
                    {
                        Sb_Str.Append("<select name=\"ReceivPaymentNotes_" + j.ToString() + "\">");

                        Sb_Str.Append("<option value=\"\">---请选择---</option>");
                        for (int i = 0; i < Dtb_houseNo.Rows.Count; i++)
                        {
                            string s_HouseNo = Dtb_houseNo.Rows[i]["HouseNo"].ToString();
                            string s_HouseName = Dtb_houseNo.Rows[i]["HouseName"].ToString();
                            string s_HouseSelected = "";
                            if (s_HouseName.IndexOf(Dtb_Table.Rows[j][6].ToString()) > 0)
                            {
                                s_HouseSelected = "selected";
                            }
                            Sb_Str.Append("<option value=\"" + s_HouseNo + "\" " + s_HouseSelected + ">" + s_HouseName + "</option>");
                        }
                        Sb_Str.Append("</select>");
                    }
                    Sb_Str.Append("</td>");


                    Sb_Str.Append("<td class=\"ListDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\"  Name=\"WareHouseNumber_" + j.ToString() + "\"  value='" + Dtb_Table.Rows[j][9].ToString() + "'></td>");
                    Sb_Str.Append("<td class=\"ListDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\"  Name=\"WareHouseBNumber_" + j.ToString() + "\"  value='" + Dtb_Table.Rows[j][10].ToString() + "'></td>");
                    Sb_Str.Append("<td class=\"ListDetails\">");
                    Sb_Str.Append("<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\"  Name=\"Wuliu_" + j.ToString() + "\"  value='" + Dtb_Table.Rows[j][11].ToString() + "'></td>");
                    Sb_Str.Append("</td>");
                    Sb_Str.Append("<td class=\"ListDetails\">");
                    Sb_Str.Append("<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\"  Name=\"WuliuCode_" + j.ToString() + "\"  value='" + Dtb_Table.Rows[j][12].ToString() + "'></td>");
                    Sb_Str.Append("</td>");
                    Sb_Str.Append("<td class=\"ListDetails\">");
                    Sb_Str.Append("<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\"  Name=\"Remarks_" + j.ToString() + "\"  value='" + Dtb_Table.Rows[j][13].ToString() + "'></td>");
                    Sb_Str.Append("</td>");
                    Sb_Str.Append("<td class=\"ListDetails\"><input type=\"Checkbox\" name=\"chk_select1_" + j.ToString() + "\" " + s_Select + "></td>");
                    Sb_Str.Append("</tr>");
                }
            }
            Sb_Str.Append("<td class=\"ListDetails\"><input type=\"hidden\" name=\"Tbx_Number\" value=" + Dtb_Table.Rows.Count.ToString() + "></td>");
            Sb_Str.Append("</tbody></table>");
            this.Lbl_Details2.Text = Sb_Str.ToString();
            this.Button1.Text = "下一步";
        }
    }

    protected void Btn_Save_Click1(object sender, EventArgs e)
    {
        //导入实现
        try
        {
            //交期确认
            string s_ID = GetMainID();
            AdminloginMess AM = new AdminloginMess();
            KNet.BLL.KNet_Sales_OutWareList_FlowList BLL = new KNet.BLL.KNet_Sales_OutWareList_FlowList();
            KNet.BLL.Knet_Procure_WareHouseList BLL_WareHouseList = new KNet.BLL.Knet_Procure_WareHouseList();
            string s_Number = Request["Tbx_Number"] == null ? "0" : Request["Tbx_Number"].ToString();
            for (int i = 0; i < int.Parse(s_Number); i++)
            {
                #region 订单采购交期更新

                string s_OldTime = Request["LastPreDate_" + i.ToString() + ""] == null ? "1900-01-01" : Request["LastPreDate_" + i.ToString() + ""].ToString();
                string s_ReTime = Request["PreDate_" + i.ToString() + ""] == null ? "1900-01-01" : Request["PreDate_" + i.ToString() + ""].ToString();
                string s_OrderNo = Request["OrderNo_" + i.ToString() + ""] == null ? "" : Request["OrderNo_" + i.ToString() + ""].ToString();
                string s_FollowText = Request["FollowText_" + i.ToString() + ""] == null ? "" : Request["FollowText_" + i.ToString() + ""].ToString();
                string s_chk = Request["chk_select_" + i.ToString() + ""] == null ? "" : Request["chk_select_" + i.ToString() + ""].ToString();

                if (s_chk == "on")
                {
                    if (s_OldTime != s_ReTime)
                    {
                        KNet.Model.KNet_Sales_OutWareList_FlowList model = new KNet.Model.KNet_Sales_OutWareList_FlowList();

                        string FollowNo = DateTime.Now.ToFileTimeUtc().ToString();
                        model.FollowNo = FollowNo;
                        model.OutWareNo = s_OrderNo;
                        model.FollowDateTime = DateTime.Now;
                        model.FollowStaffNo = AM.KNet_StaffNo;
                        model.FollowText = s_FollowText;
                        model.FollowEnd = true;
                        model.KDCode = "";
                        model.KDName = "";
                        model.KDCodeName = s_ID;
                        model.ReturnType = "";
                        this.BeginQuery("Select IsNull(Count(*),0) from KNet_Sales_OutWareList_FlowList where OutWareNo='" + s_OrderNo + "'");
                        string s_Num = this.QueryForReturn();
                        model.KSO_Order = int.Parse(s_Num);
                        try
                        {
                            model.OldTime = DateTime.Parse(s_OldTime);
                        }
                        catch
                        { }
                        try
                        {
                            model.ReTime = DateTime.Parse(s_ReTime);
                        }
                        catch
                        { }
                        try
                        {
                            BLL.Add(model);
                            AM.Add_Logs("批量插入确认日期：" + s_ID);
                        }
                        catch
                        { }
                    }
                }
                #endregion


                #region 采购入库
                KNet.Model.Knet_Procure_WareHouseList model_WareHouse = new KNet.Model.Knet_Procure_WareHouseList();

                string s_WareHouseDate = Request["WareHouseDate_" + i.ToString() + ""] == null ? "1900-01-01" : Request["WareHouseDate_" + i.ToString() + ""].ToString();
                string s_WareHouseOrderNo = Request["WareHouseOrderNo_" + i.ToString() + ""] == null ? "" : Request["WareHouseOrderNo_" + i.ToString() + ""].ToString();
                string s_Remarks = Request["Remarks_" + i.ToString() + ""] == null ? "" : Request["Remarks_" + i.ToString() + ""].ToString();
                string s_ReceivPaymentNotes = Request["ReceivPaymentNotes_" + i.ToString() + ""] == null ? "" : Request["ReceivPaymentNotes_" + i.ToString() + ""].ToString();
                string s_WareHouseNumber = Request["WareHouseNumber_" + i.ToString() + ""] == null ? "0" : Request["WareHouseNumber_" + i.ToString() + ""].ToString();
                string s_WareHouseBNumber = Request["WareHouseBNumber_" + i.ToString() + ""] == null ? "0" : Request["WareHouseBNumber_" + i.ToString() + ""].ToString();
                string s_Wuliu = Request["Wuliu_" + i.ToString() + ""] == null ? "" : Request["Wuliu_" + i.ToString() + ""].ToString();
                string s_WuliuCode = Request["WuliuCode_" + i.ToString() + ""] == null ? "" : Request["WuliuCode_" + i.ToString() + ""].ToString();
                string s_ProductsPattern = Request["ProductsPattern_" + i.ToString() + ""] == null ? "" : Request["ProductsPattern_" + i.ToString() + ""].ToString();


                string s_chk1 = Request["chk_select1_" + i.ToString() + ""] == null ? "" : Request["chk_select1_" + i.ToString() + ""].ToString();

                if (s_chk1 == "on")
                {
                    if (s_WareHouseNumber != "")
                    {
                        string s_WareHouseNO = s_GetCode();
                        model_WareHouse.ReceivNo = s_WareHouseOrderNo;
                        model_WareHouse.WareHouseNo = s_WareHouseNO;
                        model_WareHouse.OrderNo = s_WareHouseOrderNo;
                        model_WareHouse.WareHouseTopic = s_ID;
                        model_WareHouse.HouseNo = s_ReceivPaymentNotes;
                        model_WareHouse.ShipDetials = "";
                        model_WareHouse.WareHouseStaffNo = AM.KNet_StaffNo;
                        model_WareHouse.WareHouseDateTime = DateTime.Parse("1900-01-01");
                        model_WareHouse.KPO_CheckTime = DateTime.Parse(s_WareHouseDate);
                        model_WareHouse.WareHouseRemarks = s_Remarks;
                        model_WareHouse.KPW_CTime = DateTime.Now;
                        model_WareHouse.KPW_Creator = AM.KNet_StaffNo;
                        model_WareHouse.KPW_MTime = DateTime.Now;
                        model_WareHouse.KPW_Mender = AM.KNet_StaffNo;
                        model_WareHouse.WareHouseCheckYN = 1;
                        model_WareHouse.KPW_Del = 0;
                        string s_WuliuSql = "Select * from PB_Basic_Wl where PBW_Name like'%" + s_Wuliu + "%' ";
                        this.BeginQuery(s_WuliuSql);
                        DataTable Dtb_Wuliu = (DataTable)this.QueryForDataTable();
                        if (Dtb_Wuliu.Rows.Count > 0)
                        {
                            model_WareHouse.KPO_KDNameCode = Dtb_Wuliu.Rows[0]["PBW_Code"].ToString();
                            model_WareHouse.KPO_KDName = s_Wuliu;
                            model_WareHouse.KPO_KDCode = s_WuliuCode;
                        }
                        else
                        {
                            model_WareHouse.KPO_KDNameCode = "";
                            model_WareHouse.KPO_KDName = s_Wuliu;
                            model_WareHouse.KPO_KDCode = s_WuliuCode;
                        }

                        ArrayList Arr_Products = new ArrayList();
                        KNet.Model.Knet_Procure_WareHouseList_Details Model_Details = new KNet.Model.Knet_Procure_WareHouseList_Details();
                        Model_Details.ID = GetNewID("Knet_Procure_WareHouseList_Details", 1);
                        string s_ProductsSql = "select a.ID as DID,* from Knet_Procure_OrdersList_Details a join KNET_Sys_Products b on a.ProductsBarCode=b.ProductsBarCode  ";

                        s_ProductsSql += "  join Knet_Procure_OrdersList c on a.OrderNo=c.OrderNo ";

                        s_ProductsSql += " where b.ProductsEdition like '%" + s_ProductsPattern + "%' or   b.ProductsPattern like '%" + s_ProductsPattern + "%'";
                        this.BeginQuery(s_ProductsSql);
                        DataTable Dtb_Products = (DataTable)this.QueryForDataTable();
                        string s_ProductsBarCode = "", s_Price = "0", s_DID = "",s_SuppNo="";
                        if (Dtb_Products.Rows.Count > 0)
                        {
                            s_ProductsBarCode = Dtb_Products.Rows[0]["ProductsBarCode"].ToString();
                            s_Price = Dtb_Products.Rows[0]["OrderUnitPrice"].ToString();
                            s_DID = Dtb_Products.Rows[0]["DID"].ToString();
                            s_SuppNo = Dtb_Products.Rows[0]["SuppNo"].ToString();
                        }

                        model_WareHouse.SuppNo = s_SuppNo;
                        Model_Details.ProductsBarCode = s_ProductsBarCode;
                        Model_Details.WareHouseNo = s_WareHouseNO;
                        Model_Details.WareHouseAmount = int.Parse(s_WareHouseNumber);
                        Model_Details.WareHouseUnitPrice = decimal.Parse(s_Price);
                        decimal d_Money = int.Parse(s_WareHouseNumber) * decimal.Parse(s_Price);
                        Model_Details.WareHouseTotalNet = d_Money;
                        Model_Details.WareHouseRemarks = s_Remarks;
                        Model_Details.ProductsUnits = s_DID;
                        Model_Details.WareHouseBAmount = int.Parse(s_WareHouseBNumber == "" ? "0" : s_WareHouseBNumber);
                        Model_Details.KWP_NoTaxMoney = decimal.Parse(base.FormatNumber1(Convert.ToString(d_Money / Decimal.Parse("1.17")), 2));
                        Arr_Products.Add(Model_Details);
                        model_WareHouse.Arr_Products = Arr_Products;
                #endregion
                        BLL_WareHouseList.Add(model_WareHouse);
                        AM.Add_Logs("批量插入采购入库：" + s_ID);
                    }
                }
            }
            AlertAndRedirect("订单交期更新成功！", "Knet_Procure_OpenBilling_Manage.aspx?WhereID=M150318091226587");
        }
        catch
        { }

    }


    private string s_GetCode()
    {
        string s_Return = "";
        try
        {
            KNet.BLL.Knet_Procure_WareHouseList Bll = new KNet.BLL.Knet_Procure_WareHouseList();

            string S_Code = Bll.GetLastCode();

            if (S_Code == "")
            {

                s_Return += "W" + DateTime.Today.ToString("yyyyMMdd") + "-" + "0001";
            }
            else
            {
                try
                {
                    S_Code = "1" + S_Code.Substring(10, 4);
                }
                catch
                {

                    S_Code = "10" + S_Code.Substring(10, 3);
                }
                decimal d_NewCode = decimal.Parse(S_Code) + 1;
                if (d_NewCode == 20000)
                {
                    d_NewCode = 20001;
                }
                s_Return += "W" + DateTime.Today.ToString("yyyyMMdd") + "-" + d_NewCode.ToString().Substring(1, d_NewCode.ToString().Length - 1);
            }

        }
        catch (Exception ex)
        {
            s_Return = "-";
        }
        return s_Return;
    }
    protected void Lbl_Save_Click(object sender, EventArgs e)
    {
        try
        {
            KNet.BLL.PB_Basic_Code Bll = new KNet.BLL.PB_Basic_Code();
            KNet.Model.PB_Basic_Code Model = new KNet.Model.PB_Basic_Code();
            KNet.BLL.Excel_In_Details Bll_Details = new KNet.BLL.Excel_In_Details();

            Model.PBC_ID = "766";
            Model.PBC_Code = Convert.ToString(int.Parse(Bll.GetMaxCodeByID("766")) + 1);
            // Model.PBC_Name = this.Tbx_Model.Text;
            Model.PBC_Order = int.Parse(Bll.GetMaxCodeByID("766")) + 1;
            Bll.Add(Model);
            int i_num = int.Parse(this.Tbx_Num.Text);
            for (int i = 0; i < i_num; i++)
            {
                string s_Ddl_Select = Request["Ddl_Select_" + i.ToString() + ""] == null ? "" : Request["Ddl_Select_" + i.ToString() + ""].ToString();
                KNet.Model.PB_Basic_Code Model1 = Bll.GetModel("765", s_Ddl_Select);
                if (Model1 != null)
                {
                    KNet.Model.Excel_In_Details Model_Details = new KNet.Model.Excel_In_Details();
                    Model_Details.EID_ID = GetMainID(i);
                    Model_Details.EID_Name = Model1.PBC_Name;
                    Model_Details.EID_YLine = i;
                    Model_Details.EID_ColName = Model1.PBC_Details;
                    Model_Details.EID_FID = Model.PBC_Code;
                    Bll_Details.Add(Model_Details);
                }
            }
            // base.Base_DropBasicCodeBind(this.Ddl_Model, "766");
            Alert("模板保存成功！");
        }
        catch
        { }
    }

    private string GetStrColumn(int i)
    {
        string s_Return = "";
        try
        {
            switch (i)
            {
                case 0:
                    s_Return = "序号";
                    break;
                case 1:
                    s_Return = "产品型号";
                    break;
                case 2:
                    s_Return = "采购日期";
                    break;
                case 3:
                    s_Return = "订单编号";
                    break;
                case 4:
                    s_Return = "OEM订单号";
                    break;
                case 5:
                    s_Return = "订单数量";
                    break;
                case 6:
                    s_Return = "收货单位";
                    break;
                case 7:
                    s_Return = "确认交期";
                    break;
                case 8:
                    s_Return = "实际交期";
                    break;
                case 9:
                    s_Return = "发货数量";
                    break;
                case 10:
                    s_Return = "备品数量";
                    break;
                case 11:
                    s_Return = "物流/快递公司名称单";
                    break;
                case 12:
                    s_Return = "异常说明";
                    break;

                default:
                    break;
            }
        }
        catch { }
        return s_Return;
    }

    private string GetLastPreDateTime(string s_OrderNO)
    {
        string s_Return = "";
        try
        {
            string s_Sql = "Select top 1 ReTime from KNet_Sales_OutWareList_FlowList where OutWareNo ='" + s_OrderNO + "' order by FollowDateTime desc";
            this.BeginQuery(s_Sql);
            s_Return = base.DateToString(this.QueryForReturn());
        }
        catch
        { }
        return s_Return;
    }
}
