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
            base.Base_DropBasicCodeBind(this.Ddl_Model, "766");
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
            // base.Base_DropLinkManBind(this.Ddl_LinkMan, this.Tbx_CustomerValue.Value);
        }


    }

    protected void Lbl_Del_Click(object sender, EventArgs e)
    {

        try
        {
            KNet.BLL.Excel_In_Details BLL_Details = new KNet.BLL.Excel_In_Details();
            KNet.BLL.PB_Basic_Code Bll = new KNet.BLL.PB_Basic_Code();
            string s_ID = this.Ddl_Model.SelectedValue;
            BLL_Details.DeleteByFID(s_ID);
            Bll.Delete("766", s_ID);
            base.Base_DropBasicCodeBind(this.Ddl_Model, "766");
            Alert("模板删除成功！");
        }
        catch
        {
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
        this.Lbl_Details.Text += "<td width=\"25%\" align=\"center\"><b>ERP系统字段</b></td>";
        this.Lbl_Details.Text += "<td width=\"10%\"><b>列 1</b></td>";
        this.Lbl_Details.Text += "<td width=\"10%\"><b>列 2</b></td>";
        this.Lbl_Details.Text += "<td width=\"10%\"><b>列 3</b></td>";
        this.Lbl_Details.Text += "<td width=\"10%\"><b>列 4</b></td>";
        this.Lbl_Details.Text += "<td width=\"10%\"><b>列 5</b></td>";
        this.Lbl_Details.Text += "<td width=\"10%\"><b>列 7</b></td>";
        this.Lbl_Details.Text += "<td width=\"10%\"><b>列 8</b></td>";
        this.Lbl_Details.Text += "</tr>";
        for (int j = 0; j < Dtb_Table.Columns.Count; j++)
        {

            this.Lbl_Details.Text += "<tr>";
            this.Lbl_Details.Text += "<td><select name=\"Ddl_Select_" + j + "\">";
            this.BeginQuery("select * from PB_Basic_Code where PBC_ID='765'");
            DataTable Dtb_TableCol = this.QueryForDataTable();
            this.Lbl_Details.Text += "<option value=></option>";

            string s_Select = "", s_Name = "";
            KNet.BLL.Excel_In_Details BLL_Details = new KNet.BLL.Excel_In_Details();
            DataSet Dtbs_Excel = BLL_Details.GetList("EID_FID='" + this.Tbx_ID.Text + "' and EID_Yline='" + j.ToString() + "'");
            if (Dtbs_Excel.Tables[0].Rows.Count > 0)
            {
                s_Select = "selected";
                s_Name = Dtbs_Excel.Tables[0].Rows[0]["EID_Name"].ToString();
            }
            else
            {
                s_Select = "";
                s_Name = "";
            }
            for (int i = 0; i < Dtb_TableCol.Rows.Count; i++)
            {
                if (Dtb_TableCol.Rows[i]["PBC_Name"].ToString() == s_Name)
                {
                    s_Select = "selected";
                }
                else
                {
                    s_Select = "";
                }
                this.Lbl_Details.Text += "<option value='" + Dtb_TableCol.Rows[i]["PBC_Code"].ToString() + "' " + s_Select + ">" + Dtb_TableCol.Rows[i]["PBC_Name"].ToString() + "</option>";
            }
            this.Lbl_Details.Text += "</select></td>";
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
    }

    protected void Btn_Save_Click1(object sender, EventArgs e)
    {
        if (this.Button2.Text == "导入")
        {
            StringBuilder SB_Str = new StringBuilder();
            AdminloginMess AM = new AdminloginMess();
            try
            {
                //查询
                this.BeginQuery("select * from Excel_In_Details where EID_FID='" + this.Ddl_Model.SelectedValue + "' ");
                DataTable Dtb_Excel = this.QueryForDataTable();
                string[] s_FName = new string[12];
                if (Dtb_Excel.Rows.Count > 0)
                {
                    for (int i = 0; i < Dtb_Excel.Rows.Count; i++)
                    {
                        int i_Num = int.Parse(Dtb_Excel.Rows[i]["EID_YLine"].ToString()) + 1;
                        if (Dtb_Excel.Rows[i]["EID_ColName"].ToString() == "SuppNo")
                        {
                            s_FName[0] = "f" + i_Num.ToString();
                        }
                        else if (Dtb_Excel.Rows[i]["EID_ColName"].ToString() == "OrderNo")
                        {
                            s_FName[1] = "f" + i_Num.ToString();
                        }
                        else if (Dtb_Excel.Rows[i]["EID_ColName"].ToString() == "Date")
                        {
                            s_FName[2] = "f" + i_Num.ToString();
                        }
                        else if (Dtb_Excel.Rows[i]["EID_ColName"].ToString() == "Type")
                        {
                            s_FName[3] = "f" + i_Num.ToString();
                        }
                        else if (Dtb_Excel.Rows[i]["EID_ColName"].ToString() == "ProductsEdition")
                        {
                            s_FName[4] = "f" + i_Num.ToString();
                        }
                        else if (Dtb_Excel.Rows[i]["EID_ColName"].ToString() == "QrNumber")
                        {
                            s_FName[5] = "f" + i_Num.ToString();
                        }
                        else if (Dtb_Excel.Rows[i]["EID_ColName"].ToString() == "Number")
                        {
                            s_FName[10] = "f" + i_Num.ToString();
                        }
                        else if (Dtb_Excel.Rows[i]["EID_ColName"].ToString() == "HouseNo")
                        {
                            s_FName[6] = "f" + i_Num.ToString();
                        }
                        else if (Dtb_Excel.Rows[i]["EID_ColName"].ToString() == "wuliu")
                        {
                            s_FName[7] = "f" + i_Num.ToString();
                        }
                        else if (Dtb_Excel.Rows[i]["EID_ColName"].ToString() == "wuliuCode")
                        {
                            s_FName[8] = "f" + i_Num.ToString();
                        }
                        else if (Dtb_Excel.Rows[i]["EID_ColName"].ToString() == "BNumber")
                        {
                            s_FName[9] = "f" + i_Num.ToString();
                        }
                    }
                }

                Excel Excel = new Excel();
                DataTable Dtb_Table = Excel.ExcelFirestToDataTable(this.Tbx_ExcelUrl.Text, " " + s_FName[1] + " like '%P%' ");
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {

                    string s_OrderNo = Dtb_Table.Rows[i]["" + s_FName[1] + ""].ToString();
                    string s_Date = Dtb_Table.Rows[i]["" + s_FName[2] + ""].ToString();
                    string s_HouseNo = Dtb_Table.Rows[i]["" + s_FName[6] + ""].ToString();
                    string s_ProductsEdition = Dtb_Table.Rows[i]["" + s_FName[4] + ""].ToString();
                    string s_Type = Dtb_Table.Rows[i]["" + s_FName[3] + ""].ToString();
                    string s_QrNumber = "";
                    try
                    {
                         s_QrNumber = Dtb_Table.Rows[i]["" + s_FName[5] + ""].ToString();
                    }
                    catch { }
                    if ((s_QrNumber == "")&&(s_Type=="采购入库"))
                    {
                        s_QrNumber = Dtb_Table.Rows[i]["" + s_FName[10] + ""].ToString();
                    }
                    string s_Wuliu = "", s_WuliuCode = "", s_BNumber = "";
                    try
                    {
                        s_Wuliu = Dtb_Table.Rows[i]["" + s_FName[7] + ""].ToString();
                        s_WuliuCode = Dtb_Table.Rows[i]["" + s_FName[8] + ""].ToString();
                    }
                    catch
                    { }
                    try
                    {
                        s_BNumber = Dtb_Table.Rows[i]["" + s_FName[9] + ""].ToString();
                    }
                    catch
                    { }
                    #region 入库确认
                    if (s_Type == "入库确认")
                    {
                        if (i == 0)
                        {

                            SB_Str.Append("<table width=\"100%\" class=\"small\" style=\"background-color: rgb(255, 255, 255);\" border=\"0\" cellspacing=\"1\" cellpadding=\"5\">");
                            SB_Str.Append("<tr class=\"windLayerHead\">");
                            SB_Str.Append("<td class=\"ListDetails\">序号</td>");
                            SB_Str.Append("<td class=\"ListDetails\">入库单号</td>");
                            SB_Str.Append("<td class=\"ListDetails\">采购单号</td>");
                            SB_Str.Append("<td class=\"ListDetails\">发货时间</td>");
                            SB_Str.Append("<td class=\"ListDetails\">收货时间</td>");
                            SB_Str.Append("<td class=\"ListDetails\">收货仓库</td>");
                            SB_Str.Append("<td class=\"ListDetails\">型号</td>");
                            SB_Str.Append("<td class=\"ListDetails\">确认数量</td>");
                            SB_Str.Append("<td class=\"ListDetails\">状态</td></tr>");
                        }

                        string s_Sql = "Select * from Knet_Procure_WareHouseList a join Knet_Procure_WareHouseList_Details b on a.WareHouseNo=b.WareHouseNo  where 1=1 ";
                        if (s_OrderNo != "")
                        {
                            s_Sql += " and a.OrderNo='" + s_OrderNo.Trim() + "'  ";
                        }
                        else
                        {
                            s_Sql += " and 1<>1  ";
                        }
                        if (s_QrNumber != "")
                        {
                            s_Sql += " and WareHouseAmount='" + s_QrNumber.Trim() + "' ";
                        }
                        string s_State = "";
                        this.BeginQuery(s_Sql);
                        DataTable Dtb_Details = this.QueryForDataTable();
                        string s_TotalOrderNo = "";
                        if (Dtb_Details.Rows.Count > 0)
                        {
                            for (int j = 0; j < Dtb_Details.Rows.Count; j++)
                            {
                                bool b_Update = true;

                                string s_WareHouseNo = Dtb_Details.Rows[j]["WareHouseNo"].ToString();
                                string s_Number = Dtb_Details.Rows[j]["WareHouseAmount"].ToString();
                                string s_DHouseNo = Dtb_Details.Rows[j]["HouseNo"].ToString();
                                string s_QrState = Dtb_Details.Rows[j]["KPO_QrState"].ToString();

                                string s_DProductsEdition = base.Base_GetProductsEdition(Dtb_Details.Rows[j]["ProductsBarCode"].ToString());
                                SB_Str.Append("<tr>");
                                SB_Str.Append("<td class=\"ListDetails\">" + (i + 1).ToString() + "</td>");
                                SB_Str.Append("<td class=\"ListDetails\"><a href=\"Knet_Procure_WareHouseList_View.aspx?ID=" + s_WareHouseNo + "\" target=\"_blank\">" + s_WareHouseNo + "</a></td>");
                                SB_Str.Append("<td class=\"ListDetails\"><a href=\"../Order/Knet_Procure_OpenBilling_View.aspx?ID=" + Dtb_Details.Rows[j]["OrderNo"].ToString() + "\" target=\"_blank\">" + Dtb_Details.Rows[j]["OrderNo"].ToString() + "</a></td>");
                                SB_Str.Append("<td class=\"ListDetails\">" + DateTime.Parse(Dtb_Details.Rows[j]["WareHouseDateTime"].ToString()).ToShortDateString() + "</td>");
                                if (s_Number == s_QrNumber)
                                {
                                    SB_Str.Append("<td class=\"ListDetails\">" + s_Date + "</td>");
                                }
                                else
                                {
                                    SB_Str.Append("<td class=\"ListDetails\">&nbsp;</td>");
                                    b_Update = false;
                                }
                                //如果仓库名称相同
                                if (base.Base_GetHouseName(s_DHouseNo) == s_HouseNo)
                                {
                                    SB_Str.Append("<td class=\"ListDetails\">" + base.Base_GetHouseName(s_DHouseNo) + "</td>");
                                }
                                else
                                {
                                    SB_Str.Append("<td class=\"ListDetails\">" + s_HouseNo + "（<font color=red>" + base.Base_GetHouseName(s_DHouseNo) + "</font>）</td>");
                                }
                                //如果产品相同
                                if (s_ProductsEdition == s_DProductsEdition)
                                {
                                    SB_Str.Append("<td class=\"ListDetails\">" + s_DProductsEdition + "</td>");
                                }
                                else
                                {
                                    SB_Str.Append("<td class=\"ListDetails\">" + s_ProductsEdition + "（<font color=red>" + s_DProductsEdition + "</font>）</td>");
                                }
                                if (s_Number == s_QrNumber)
                                {
                                    SB_Str.Append("<td class=\"ListDetails\">" + s_Number + "</td>");
                                }
                                else
                                {
                                    SB_Str.Append("<td class=\"ListDetails\">" + s_QrNumber + "（<font color=red>" + s_Number + "</font>）</td>");
                                    b_Update = false;
                                }
                                if (s_QrState == "1")
                                {
                                    s_State = "<font color=blue>已确认</font>";
                                    //string s_DoSql = "Update Knet_Procure_WareHouseList set KPO_QrState='0',KPO_CheckTime='" + s_Date + "' where WareHouseNo='" + s_WareHouseNo + "'";
                                    //if (DbHelperSQL.ExecuteSql(s_DoSql) > 0)
                                    //{
                                    //}
                                }
                                else
                                {
                                    s_State = "<font color=green>确认成功</font>";
                                    string s_DoSql = "Update Knet_Procure_WareHouseList set KPO_QrState='1',KPO_CheckTime='" + s_Date + "' where WareHouseNo='" + s_WareHouseNo + "'";
                                    if (DbHelperSQL.ExecuteSql(s_DoSql) > 0)
                                    {
                                        AM.Add_Logs("采购入库确认成功：" + s_WareHouseNo);
                                    }
                                }
                                if (s_State != "")
                                {
                                    SB_Str.Append("<td class=\"ListDetails\">" + s_State + "</td>");
                                }
                            }
                            SB_Str.Append("</tr>");
                        }
                        else
                        {
                            SB_Str.Append("<td class=\"ListDetails\">&nbsp;</td>");
                            SB_Str.Append("<td class=\"ListDetails\">&nbsp;</td>");
                            SB_Str.Append("<td class=\"ListDetails\"><a href=\"../Order/Knet_Procure_OpenBilling_View.aspx?ID=" + s_OrderNo + "\" target=\"_blank\">" + s_OrderNo + "</a>&nbsp;</td>");
                            SB_Str.Append("<td class=\"ListDetails\">&nbsp;</td>");
                            SB_Str.Append("<td class=\"ListDetails\">" + s_Date + "&nbsp;</td>");
                            SB_Str.Append("<td class=\"ListDetails\">" + s_HouseNo + "</td>");
                            SB_Str.Append("<td class=\"ListDetails\">" + s_ProductsEdition + "</td>");
                            SB_Str.Append("<td class=\"ListDetails\">" + s_QrNumber + "</td>");
                            SB_Str.Append("<td class=\"ListDetails\"><font color=red>未找到该订单</font></td>");
                            SB_Str.Append("</tr>");
                            s_TotalOrderNo += s_OrderNo + ",";
                        }
                    }
                    #endregion


                    #region 采购发货
                        if (s_Type == "采购入库")
                    {
                        this.Button2.Text = "保存";
                        if (i == 0)
                        {
                            SB_Str.Append("<table width=\"100%\" class=\"small\" style=\"background-color: rgb(255, 255, 255);\" border=\"0\" cellspacing=\"1\" cellpadding=\"5\">");
                            SB_Str.Append("<tr class=\"windLayerHead\">");
                            SB_Str.Append("<td class=\"ListDetails\">序号</td>");
                            SB_Str.Append("<td class=\"ListDetails\">入库单号</td>");
                            SB_Str.Append("<td class=\"ListDetails\">采购单号</td>");
                            SB_Str.Append("<td class=\"ListDetails\">发货时间</td>");
                            SB_Str.Append("<td class=\"ListDetails\">收货仓库</td>");
                            SB_Str.Append("<td class=\"ListDetails\">型号</td>");
                            SB_Str.Append("<td class=\"ListDetails\">数量</td>");
                            SB_Str.Append("<td class=\"ListDetails\">备品</td>");
                            SB_Str.Append("<td class=\"ListDetails\">单价</td>");
                            SB_Str.Append("<td class=\"ListDetails\">金额</td>");
                            SB_Str.Append("<td class=\"ListDetails\">未入库数量</td>");
                            SB_Str.Append("<td class=\"ListDetails\">物流</td>");
                            SB_Str.Append("<td class=\"ListDetails\">物流单号</td>");
                            SB_Str.Append("<td class=\"ListDetails\">状态</td></tr>");
                        }
                        string s_Sql = "Select b.ID as DetailsID,* from Knet_Procure_OrdersList a join Knet_Procure_OrdersList_Details b on a.OrderNo=b.OrderNo ";
                        s_Sql += " join  KNet_Sys_Products c on b.ProductsBarCode=c.ProductsBarCode  join v_OrderRK d on a.OrderNO=d.V_OrderNo";
                        s_Sql += "  where 1=1 ";
                        if (s_OrderNo != "")
                        {
                            s_Sql += " and a.OrderNo='" + s_OrderNo.Trim() + "'  ";
                        }
                        else
                        {
                            s_Sql += " and 1<>1  ";
                        }
                        // 该采购单的明细
                        if (s_ProductsEdition != "")
                        {
                            s_Sql += " and c.ProductsEdition like '%" + s_ProductsEdition.Substring(0, 5) + "%' ";
                        }
                        this.BeginQuery(s_Sql);
                        DataTable Dtb_Details = this.QueryForDataTable();

                        string s_HaveWareHouseNo = "";
                        s_Sql = "Select * from Knet_Procure_WareHouseList a join Knet_Procure_WareHouseList_Details b on a.WareHouseNo=b.WareHouseNo  where 1=1 ";
                        if (s_OrderNo != "")
                        {
                            s_Sql += " and a.OrderNo='" + s_OrderNo.Trim() + "'  ";
                        }
                        else
                        {
                            s_Sql += " and 1<>1  ";
                        }
                        if (s_QrNumber != "")
                        {
                            s_Sql += " and WareHouseAmount='" + s_QrNumber.Trim() + "' ";
                        }
                        this.BeginQuery(s_Sql);
                        DataTable Dtb_Details1 = this.QueryForDataTable();
                        if (Dtb_Details1.Rows.Count > 0)
                        {
                            s_HaveWareHouseNo = Dtb_Details1.Rows[0]["WareHouseNo"].ToString();
                        }
                        string s_TotalOrderNo = "";

                        if (Dtb_Details.Rows.Count > 0)
                        {
                            for (int j = 0; j < Dtb_Details.Rows.Count; j++)
                            {
                                string s_State = "";
                                string s_ID = Dtb_Details.Rows[j]["DetailsID"].ToString();
                                string s_DOrderNo = Dtb_Details.Rows[j]["OrderNo"].ToString();
                                string s_ProductsBarCode = Dtb_Details.Rows[j]["ProductsBarCode"].ToString();
                                string s_Price = Dtb_Details.Rows[j]["OrderUnitPrice"].ToString();
                                int d_WrkNumber = int.Parse(Dtb_Details.Rows[j]["WrkNumber"].ToString());


                                this.BeginQuery("Select HouseNo from KNet_Sys_WareHouse where HouseName like '%" + s_HouseNo + "%' and KSW_Type=0 ");
                                string s_DHouseNo = this.QueryForReturn();
                                if (d_WrkNumber <= 0)
                                {
                                    s_State = "<font color=red>已入库</font>";
                                }
                                else if (d_WrkNumber < int.Parse(s_QrNumber))
                                {
                                    s_State = "发货数量少于未入库数量";
                                }
                                else
                                {

                                    KNet.Model.Knet_Procure_WareHouseList model = new KNet.Model.Knet_Procure_WareHouseList();
                                    model.ReceivNo = s_DOrderNo;
                                    model.WareHouseNo = s_GetCode();
                                    model.OrderNo = s_DOrderNo;
                                    model.HouseNo = s_DHouseNo;
                                    model.ShipDetials = "";
                                    model.WareHouseStaffNo = AM.KNet_StaffNo;
                                    model.SuppNo = this.Tbx_SuppNo.Text;
                                    try
                                    {
                                        model.WareHouseDateTime = DateTime.Parse(s_Date);
                                    }
                                    catch { }
                                    model.WareHouseRemarks = "";
                                    model.KPW_CTime = DateTime.Now;
                                    model.KPW_Creator = AM.KNet_StaffNo;
                                    model.KPW_MTime = DateTime.Now;
                                    model.KPW_Mender = AM.KNet_StaffNo;
                                    model.WareHouseCheckYN = 1;
                                    model.KPW_Del = 0;
                                    DataTable Dtb_Wl = null;
                                    if (s_Wuliu.Trim() != "")
                                    {
                                        this.BeginQuery("select * from PB_Basic_Wl where PBW_Name like '%" + s_Wuliu + "%' ");
                                        Dtb_Wl = (DataTable)this.QueryForDataTable();
                                    }
                                    if ((Dtb_Wl!=null)&&(Dtb_Wl.Rows.Count > 0))
                                    {
                                        model.KPO_KDNameCode = Dtb_Wl.Rows[0]["PBW_Code"].ToString();
                                        model.KPO_KDName = Dtb_Wl.Rows[0]["PBW_Name"].ToString();
                                    }
                                    else
                                    {
                                        model.KPO_KDNameCode = "";
                                        model.KPO_KDName = "";
                                    }
                                    model.KPO_KDCode = s_WuliuCode;

                                    ArrayList Arr_Products = new ArrayList();
                                    KNet.Model.Knet_Procure_WareHouseList_Details Model_Details = new KNet.Model.Knet_Procure_WareHouseList_Details();
                                    Model_Details.ID = GetNewID("Knet_Procure_WareHouseList_Details", 1);
                                    Model_Details.ProductsBarCode = s_ProductsBarCode;
                                    Model_Details.WareHouseNo = model.WareHouseNo;
                                    Model_Details.WareHouseAmount = int.Parse(s_QrNumber);
                                    Model_Details.WareHouseUnitPrice = decimal.Parse(s_Price);
                                    decimal d_Money = int.Parse(s_QrNumber) * decimal.Parse(s_Price);
                                    Model_Details.WareHouseTotalNet = d_Money;
                                    Model_Details.WareHouseRemarks = "";
                                    Model_Details.ProductsUnits = s_ID;
                                    Model_Details.WareHouseBAmount = int.Parse(s_BNumber);
                                    Model_Details.KWP_NoTaxMoney = decimal.Parse(base.FormatNumber1(Convert.ToString(d_Money / Decimal.Parse("1.17")), 2));
                                    Arr_Products.Add(Model_Details);
                                    model.Arr_Products = Arr_Products;
                                    Arr_WareHouseIn.Add(model);
                                }
                                string s_DProductsEdition = base.Base_GetProductsEdition(Dtb_Details.Rows[j]["ProductsBarCode"].ToString());
                                SB_Str.Append("<tr>");
                                SB_Str.Append("<td class=\"ListDetails\">" + (i + 1).ToString() + "</td>");
                                SB_Str.Append("<td class=\"ListDetails\"><a href=\"Knet_Procure_WareHouseList_View.aspx?ID=" + s_HaveWareHouseNo + "\" target=\"_blank\">" + s_HaveWareHouseNo + "</a></td>");
                                SB_Str.Append("<td class=\"ListDetails\"><a href=\"../Order/Knet_Procure_OpenBilling_View.aspx?ID=" + Dtb_Details.Rows[j]["OrderNo"].ToString() + "\" target=\"_blank\">" + Dtb_Details.Rows[j]["OrderNo"].ToString() + "</a></td>");
                                SB_Str.Append("<td class=\"ListDetails\">" + DateTime.Parse(s_Date).ToShortDateString() + "</td>");

                                SB_Str.Append("<td class=\"ListDetails\">" + base.Base_GetHouseName(s_DHouseNo) + "</td>");
                                SB_Str.Append("<td class=\"ListDetails\">" + s_DProductsEdition + "</td>");
                                SB_Str.Append("<td class=\"ListDetails\">" + s_QrNumber + "</td>");
                                SB_Str.Append("<td class=\"ListDetails\">" + s_BNumber + "</td>");
                                SB_Str.Append("<td class=\"ListDetails\">" + s_Price + "</td>");

                                SB_Str.Append("<td class=\"ListDetails\">" + int.Parse(s_QrNumber) * decimal.Parse(s_Price) + "</td>");

                                SB_Str.Append("<td class=\"ListDetails\">" + d_WrkNumber + "</td>");
                                try
                                {
                                    SB_Str.Append("<td class=\"ListDetails\">" +s_Wuliu + "</td>");
                                }
                                catch
                                {
                                    SB_Str.Append("<td class=\"ListDetails\">&nbsp;</td>");
                                }
                                SB_Str.Append("<td class=\"ListDetails\">" + s_WuliuCode + "</td>");
                                SB_Str.Append("<td class=\"ListDetails\">" + s_State + "</td>");
                            }
                            SB_Str.Append("</tr>");
                        }
                        else
                        {
                            SB_Str.Append("<td class=\"ListDetails\">" + (i + 1).ToString() + "&nbsp;</td>");
                            SB_Str.Append("<td class=\"ListDetails\">&nbsp;</td>");
                            SB_Str.Append("<td class=\"ListDetails\">" + s_OrderNo + "&nbsp;</td>");
                            SB_Str.Append("<td class=\"ListDetails\">&nbsp;</td>");
                            SB_Str.Append("<td class=\"ListDetails\">" + s_Date + "&nbsp;</td>");
                            SB_Str.Append("<td class=\"ListDetails\">" + s_HouseNo + "</td>");
                            SB_Str.Append("<td class=\"ListDetails\">" + s_ProductsEdition + "</td>");
                            SB_Str.Append("<td class=\"ListDetails\">" + s_QrNumber + "</td>");
                            SB_Str.Append("<td class=\"ListDetails\"><font color=red>未找到该订单</font></td>");
                            SB_Str.Append("</tr>");
                            s_TotalOrderNo += s_OrderNo + ",";
                        }
                    }
                    else
                    {

                        this.Button2.Text = "导入";
                    }
                    #endregion
                }
                SB_Str.Append("</table>");
            }
            catch(Exception ex)
            { }
            this.Lbl_Details.Text = SB_Str.ToString();
        }
        else
        {

        }

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
            Model.PBC_Name = this.Tbx_Model.Text;
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
            base.Base_DropBasicCodeBind(this.Ddl_Model, "766");
            Alert("模板保存成功！");
        }
        catch
        { }
    }

    protected void Ddl_Model_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.Ddl_Model.SelectedValue != "")
        {

            this.Lbl_Details.Text = "";
            string s_Sql = "Select * from PB_Basic_Attachment where PBA_Type='Excel' and PBA_FID='" + this.Tbx_ID.Text + "' order by PBA_CTime desc";
            this.BeginQuery(s_Sql);
            DataTable Dtb_Att = this.QueryForDataTable();
            if (Dtb_Att.Rows.Count > 0)
            {
                Excel excel = new Excel();
                DataTable myT = excel.ExcelFirestToDataTable(Dtb_Att.Rows[0]["PBA_URL"].ToString(), " 1=1 ");
                if (myT == null)
                {
                    AlertAndClose("未找到该Sheet表");

                }
                else
                {
                    this.Lbl_Details.Text = "<table width=\"100%\" class=\"small\" style=\"background-color: rgb(255, 255, 255);\" border=\"0\" cellspacing=\"1\" cellpadding=\"5\">";
                    this.Lbl_Details.Text += "<tbody><tr class=\"windLayerHead\">";
                    this.Lbl_Details.Text += "<td width=\"25%\" align=\"center\"><b>ERP系统字段</b></td>";
                    this.Lbl_Details.Text += "<td width=\"10%\"><b>列 1</b></td>";
                    this.Lbl_Details.Text += "<td width=\"10%\"><b>列 2</b></td>";
                    this.Lbl_Details.Text += "<td width=\"10%\"><b>列 3</b></td>";
                    this.Lbl_Details.Text += "<td width=\"10%\"><b>列 4</b></td>";
                    this.Lbl_Details.Text += "<td width=\"10%\"><b>列 5</b></td>";
                    this.Lbl_Details.Text += "<td width=\"10%\"><b>列 7</b></td>";
                    this.Lbl_Details.Text += "<td width=\"10%\"><b>列 8</b></td>";
                    this.Lbl_Details.Text += "</tr>";
                    for (int j = 0; j < myT.Columns.Count; j++)
                    {
                        this.Lbl_Details.Text += "<tr>";
                        this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\"><select name=\"Ddl_Select_" + j + "\">";
                        this.BeginQuery("select * from PB_Basic_Code where PBC_ID='765'");
                        DataTable Dtb_Table = this.QueryForDataTable();
                        this.Lbl_Details.Text += "<option value=></option>";

                        string s_Select = "", s_Name = "";
                        KNet.BLL.Excel_In_Details BLL_Details = new KNet.BLL.Excel_In_Details();
                        DataSet Dtbs_Excel = BLL_Details.GetList("EID_FID='" + this.Ddl_Model.SelectedValue + "' and EID_Yline='" + j.ToString() + "'");
                        if (Dtbs_Excel.Tables[0].Rows.Count > 0)
                        {
                            s_Select = "selected";
                            s_Name = Dtbs_Excel.Tables[0].Rows[0]["EID_Name"].ToString();
                        }
                        else
                        {
                            s_Select = "";
                            s_Name = "";
                        }
                        for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                        {
                            if (Dtb_Table.Rows[i]["PBC_Name"].ToString() == s_Name)
                            {
                                s_Select = "selected";
                            }
                            else
                            {
                                s_Select = "";
                            }
                            this.Lbl_Details.Text += "<option value='" + Dtb_Table.Rows[i]["PBC_Code"].ToString() + "' " + s_Select + ">" + Dtb_Table.Rows[i]["PBC_Name"].ToString() + "</option>";
                        }
                        this.Lbl_Details.Text += "</select></td>";
                        this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\">" + myT.Rows[0][j].ToString() + "</td>";
                        this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\">" + myT.Rows[1][j].ToString() + "</td>";
                        this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\">" + myT.Rows[2][j].ToString() + "</td>";
                        this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\">" + myT.Rows[3][j].ToString() + "</td>";
                        this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\">" + myT.Rows[4][j].ToString() + "</td>";
                        this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\">" + myT.Rows[5][j].ToString() + "</td>";
                        this.Lbl_Details.Text += "</tr>";

                    }
                    this.Lbl_Details.Text += "</tbody></table>";
                    this.Tbx_Num.Text = myT.Columns.Count.ToString();

                    if (this.Tbx_ExcelUrl.Text != "")
                    {
                        this.Button1.Visible = false;
                        this.Button2.Visible = true;
                    }
                    else
                    {
                        this.Button1.Visible = true;
                        this.Button2.Visible = false;
                    }
                }

            }
        }
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
                s_Return += "W" + DateTime.Today.ToString("yyyyMMdd") + "-" + d_NewCode.ToString().Substring(1, d_NewCode.ToString().Length - 1);
            }

        }
        catch (Exception ex)
        {
            s_Return = "-";
        }
        return s_Return;
    }
}
