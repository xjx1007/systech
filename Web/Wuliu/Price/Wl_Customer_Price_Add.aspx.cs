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
using System.Runtime.Serialization.Json;

using KNet.DBUtility;
using KNet.Common;
using System.Net;

public partial class Wl_Customer_Price_Add : BasePage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Ajax.Utility.RegisterTypeForAjax(typeof(Wl_Customer_Price_Add));
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            this.Tbx_ID.Text = s_ID;
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            this.Tbx_Type.Text = s_Type;
            string s_FID = Request.QueryString["FID"] == null ? "" : Request.QueryString["FID"].ToString();
            string s_Model = Request.QueryString["Model"] == null ? "" : Request.QueryString["Model"].ToString();
            base.Base_DropDutyPerson(this.Ddl_DutyPerson);
 
            this.Tbx_Stime.Text = DateTime.Now.ToShortDateString();
            if (s_ID != "")
            {
                if (s_Type == "1")
                { 
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制物流报价";
                }
                else
                {
                    this.Lbl_Title.Text = "修改物流报价";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }
            else
            {
                this.Lbl_Title.Text = "新增物流报价";
                this.Tbx_Code.Text = base.GetNewID("Wl_Customer_Price", 0);
            }
            //this.Lbl_Title.Text
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }

            this.Lbl_Details.Text = ShowCheckDetails1();
            
        }

    }
    /// <summary>
    /// 修改显示
    /// </summary>
    private void ShowInfo(string s_ID)
    {
        KNet.BLL.Wl_Customer_Price bll = new KNet.BLL.Wl_Customer_Price();
        KNet.Model.Wl_Customer_Price model = bll.GetModel(s_ID);
        this.Tbx_ID.Text = s_ID;
        this.Tbx_Code.Text = model.WCP_Code;
        this.Tbx_SuppNo.Text = model.WCP_SuppNo;
        this.Tbx_SuppName.Text = base.Base_GetSupplierName(model.WCP_SuppNo);
        this.Tbx_WuliuSuppNo.Text = model.WCP_WuliuSuppNo;
        this.Tbx_WuliuSuppName.Text = base.Base_GetSupplierName(model.WCP_WuliuSuppNo);
        this.Ddl_DutyPerson.SelectedValue = model.WCP_DutyPerson;
        this.Tbx_Remarks.Text = model.WCP_Remarks;
        this.Tbx_Stime.Text = base.DateToString(model.WCP_STime.ToString());
    }

    /// <summary>
    /// 赋值
    /// </summary>
    private bool SetValue(KNet.Model.Wl_Customer_Price model)
    {
        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text == "")
            {
                model.WCP_ID = GetMainID();
            }
            else
            {
                model.WCP_ID = this.Tbx_ID.Text;
            }
            if (this.Tbx_ID.Text == "")
            {
                model.WCP_Code = base.GetNewID("Wl_Customer_Price", 1);
            }
            else
            {
                model.WCP_Code = this.Tbx_Code.Text;
            }
            try{
                model.WCP_STime = DateTime.Parse(this.Tbx_Stime.Text);
            }
            catch{}
            model.WCP_SuppNo = this.Tbx_SuppNo.Text;
            model.WCP_WuliuSuppNo = this.Tbx_WuliuSuppNo.Text;
            model.WCP_DutyPerson = this.Ddl_DutyPerson.SelectedValue;
            model.WCP_LinkMan = Request["Ddl_LinkMan"];
            model.WCP_Address = "";
            model.WCP_CustomerValue = "";
            model.WCP_CheckYN = 0;
            model.WCP_Remarks = this.Tbx_Remarks.Text.ToString();
            model.WCP_Del = 0;
            model.WCP_Days = 0;
            model.WCP_CTime = DateTime.Now;
            model.WCP_Creator = AM.KNet_StaffNo;
            model.WCP_MTime = DateTime.Now;
            model.WCP_Mender = AM.KNet_StaffNo;

            ArrayList arr_Details = new ArrayList();
            int i_Num = int.Parse(this.Tbx_Num.Text);

            Excel excel = new Excel();
            DataTable myT = excel.ExcelFirestToDataTable(this.Tbx_URL.Text, "1=1");
            for (int i = 0; i < myT.Rows.Count; i++)
            {

                if (Request.Form["Chk_" + i.ToString() + ""] != null)
                {
                    if (myT.Rows[i][0].ToString() != "")
                    {
                        KNet.Model.Wl_Customer_Price_Details Model_Details = new KNet.Model.Wl_Customer_Price_Details();
                        Model_Details.WCPD_ID = base.GetMainID(i);
                        Model_Details.WCPD_FID = model.WCP_ID;
                        Model_Details.WCPD_Provice = myT.Rows[i][0].ToString();
                        Model_Details.WCPD_City = myT.Rows[i][1].ToString();
                        Model_Details.WCPD_Type = myT.Rows[i][2].ToString();
                        Model_Details.WCPD_MinTime = myT.Rows[i][3].ToString();
                        Model_Details.WCPD_MaxTime = myT.Rows[i][4].ToString();
                        try
                        {
                            Model_Details.WCPD_MinMoney = decimal.Parse(myT.Rows[i][5].ToString() == "" ? "0" : myT.Rows[i][5].ToString());
                        }
                        catch { }
                        try
                        {
                            Model_Details.WCPD_Price = decimal.Parse(myT.Rows[i][6].ToString() == "" ? "0" : myT.Rows[i][6].ToString());
                        }
                        catch { }
                        try
                        {
                            Model_Details.WCPD_PickUpCost = decimal.Parse(myT.Rows[i][7].ToString() == "" ? "0" : myT.Rows[i][7].ToString());
                        }
                        catch { }
                        try
                        {
                            Model_Details.WCPD_DeliveryFee = decimal.Parse(myT.Rows[i][8].ToString() == "" ? "0" : myT.Rows[i][8].ToString());
                        }
                        catch { }
                        try
                        {
                            Model_Details.WCPD_DeliveryFeePrice = decimal.Parse(myT.Rows[i][9].ToString() == "" ? "0" : myT.Rows[i][9].ToString());
                        }
                        catch { }
                        try
                        {
                            Model_Details.WCPD_UpstairsCost = decimal.Parse(myT.Rows[i][10].ToString() == "" ? "0" : myT.Rows[i][10].ToString());
                        }
                        catch { }
                        try
                        {
                            Model_Details.WCPD_WarehouseEntry150Low = decimal.Parse(myT.Rows[i][11].ToString() == "" ? "0" : myT.Rows[i][11].ToString());
                        }
                        catch { }

                        try
                        {
                            Model_Details.WCPD_Insured = decimal.Parse(myT.Rows[i][12].ToString() == "" ? "0" : myT.Rows[i][12].ToString());
                        }
                        catch { }
                        try
                        {
                            Model_Details.WCPD_SignBill = decimal.Parse(myT.Rows[i][13].ToString() == "" ? "0" : myT.Rows[i][13].ToString());
                        }
                        catch { }
                        Model_Details.WCPD_BigLateTime = myT.Rows[i][14].ToString();

                        arr_Details.Add(Model_Details);
                    }
                    
                }
            }
            model.Arr_Detail = arr_Details;
            return true;
        }
        catch
        {
            return false;
        }
    }
    /// <summary>
    /// 保存
    /// </summary>
    protected void Btn_Save_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.Model.Wl_Customer_Price model = new KNet.Model.Wl_Customer_Price();
        KNet.BLL.Wl_Customer_Price bll = new KNet.BLL.Wl_Customer_Price();
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
                    AM.Add_Logs("物流报价修改" + this.Tbx_ID.Text);
                    AlertAndRedirect("修改成功！", "Wl_Customer_Price_List.aspx");
                }
                else
                {
                    AM.Add_Logs("物流报价修改失败" + this.Tbx_ID.Text);
                    AlertAndRedirect("修改失败！", "Wl_Customer_Price_Add.aspx?ID=" + this.Tbx_ID.Text + "");
                }
            }
            catch { }
        }
        else
        {
            try
            {
                if (bll.Add(model))
                {
                    AM.Add_Logs("物流报价增加" + model.WCP_ID);
                    AlertAndRedirect("新增成功！", "Wl_Customer_Price_List.aspx");
                }
                else
                {
                    this.Tbx_ID.Text = "";
                    AM.Add_Logs("物流报价新增失败" + model.WCP_ID);
                    AlertAndRedirect("新增失败！", "Wl_Customer_Price_List.aspx");
                }
            }
            catch(Exception ex) { }
        }
    }
    [Ajax.AjaxMethod()]
    public string GetAddress(string s_SuppNo)
    {
        string s_Return = "";
        try
        {
            this.BeginQuery("Select XOL_Address from XS_Compy_LinkMan where XOL_ID='" + s_SuppNo + "'");
            s_Return = this.QueryForReturn();
        }
        catch { }
        return s_Return;
    }

    protected void save_Click(object sender, EventArgs e)
    {

        if (!(uploadFile.PostedFile.ContentLength > 0))
        {
            Alert("您没有选择文件!");
        }
        else
        {
            AdminloginMess AM = new AdminloginMess();
            KNet.Model.PB_Basic_Attachment model = new KNet.Model.PB_Basic_Attachment();
            string FileType = uploadFile.PostedFile.ContentType.ToString(); //文件类型
            GetThumbnailImage1(model);
            try
            {
                KNet.BLL.PB_Basic_Attachment BLL = new KNet.BLL.PB_Basic_Attachment();
                BLL.DeleteByFID(this.Tbx_Code.Text);
                BLL.Add(model);
                AM.Add_Logs("附件上传成功：编号：" + model.PBA_ID);
                this.Lbl_Upload.Text = "<a href=\"" + model.PBA_URL + "\">" + model.PBA_Name + "</a><br/>";
            }
            catch (Exception ex) { }
            string s_Details = ShowCheckDetails1();
            this.Lbl_Details.Text = s_Details;
        }
    }



    #region 资料上传操作
    /// <summary>
    /// 图片上传
    /// </summary>
    protected void GetThumbnailImage1(KNet.Model.PB_Basic_Attachment model)
    {
        AdminloginMess AM = new AdminloginMess();
        //类别下面的
        string UploadPath = "../../UpFile/WuliuPrice/";  //上传路径
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

        model.PBA_FID = this.Tbx_Code.Text;
        model.PBA_Type = "WuliuPrice";
        model.PBA_ID = GetMainID();
        model.PBA_Name = FileName;
        model.PBA_URL = filePath;
        model.PBA_CTime = DateTime.Now;
        model.PBA_Creator = AM.KNet_StaffNo;
        model.PBA_Remarks = "";
    }
    #endregion

    protected void Btn_Serch_Click(object sender, EventArgs e)
    {
            string s_Details = ShowCheckDetails1();
            this.Lbl_Details.Text = s_Details;
    }



    [Ajax.AjaxMethod]
    public string ShowCheckDetails1()
    {
        string s_SuppNo = "";
        string s_Return = "";
        string s_Type = "";
        decimal d_Total = 0, d_Total1 = 0, d_Total2 = 0, d_Total3 = 0;
        decimal dd_Total = 0, dd_Total1 = 0, dd_Total2 = 0, dd_Total3 = 0, dd_Total4 = 0;
        s_Return = ""+ "|";

        string s_Sql1 = "Select * from PB_Basic_Attachment where PBA_Type='WuliuPrice' and PBA_FID='" + this.Tbx_Code.Text + "' order by PBA_CTime desc";
        this.BeginQuery(s_Sql1);
        DataTable Dtb_Table = this.QueryForDataTable();
        if (Dtb_Table.Rows.Count > 0)
        {
            this.Lbl_Upload.Text = "<a href=\"" + Dtb_Table.Rows[0]["PBA_URL"].ToString() + "\">" + Dtb_Table.Rows[0]["PBA_Name"].ToString() + "</a><br/>";
            this.Tbx_URL.Text = Dtb_Table.Rows[0]["PBA_URL"].ToString();
        }
        Excel excel = new Excel();
        DataTable myT = excel.ExcelFirestToDataTable(this.Tbx_URL.Text, "1=1");
        if (myT != null)
        {
            string s_OrderNo = "", s_DirectOutNO = "";

            if (myT.Rows.Count > 0)
            {
                s_Return += "";
                s_Return += " <table id=\"myTable\" width=\"98%\" border=\"0\" align=\"center\" cellpadding=\"2\" cellspacing=\"0\" class=\"ListDetails\" style=\"height: 28px\">";
                s_Return += "<tr valign=\"top\">";
                s_Return += "<td class=\"ListHead\" rowspan=2 nowrap>";
                s_Return += "<b>选择</b></td>";
                s_Return += "<td class=\"ListHead\" rowspan=2 nowrap>";
                s_Return += "<b>省份</b></td>";
                s_Return += "<td class=\"ListHead\" rowspan=2 nowrap>";
                s_Return += "<b>城市</b></td>";
                s_Return += "<td class=\"ListHead\" rowspan=2 nowrap>";
                s_Return += "<b>类型</b></td>";
                s_Return += "<td class=\"ListHead\" rowspan=2 nowrap>";
                s_Return += "<b>最少时间</b></td>";
                s_Return += "<td class=\"ListHead\" rowspan=2 nowrap>";
                s_Return += "<b>最长时间</b></td>";
                s_Return += "<td class=\"ListHead\" rowspan=2 nowrap>";
                s_Return += "<b>最低收费</b></td>";
                s_Return += "<td class=\"ListHead\" rowspan=2  nowrap >";
                s_Return += "<b>单价</b></td>";
                s_Return += "<td class=\"ListHead\" rowspan=2 nowrap>";
                s_Return += "<b>提货费</b></td>";
                s_Return += "<td class=\"ListHead\" colspan=2 nowrap>";
                s_Return += "<b>送货费</b></td>";
                s_Return += "<td class=\"ListHead\" rowspan=2 nowrap>";
                s_Return += "<b>上楼费</b></td>";
                s_Return += "<td class=\"ListHead\" rowspan=2 nowrap>";
                s_Return += "<b>进仓费</b></td>";
                s_Return += "<td class=\"ListHead\" rowspan=2 nowrap>";
                s_Return += "<b>保价</b></td>";
                s_Return += "<td class=\"ListHead\" rowspan=2 nowrap>";
                s_Return += "<b>回签单</b></td>";
                s_Return += "<td class=\"ListHead\" rowspan=2 nowrap>";
                s_Return += "<b>最晚发车</b></td>";
                s_Return += "</tr>";
                s_Return += "<tr>";
                s_Return += "<td class=\"ListHead\" nowrap>";
                s_Return += "<b>最低收费</b></td>";
                s_Return += "<td class=\"ListHead\" nowrap>";
                s_Return += "<b>单价</b></td>";
                s_Return += "</tr>";
                for (int i = 0; i < myT.Rows.Count; i++)
                {
                    s_Return += "<tr>";
                    s_Return += "<td class=\"ListHeadDetails\" align=\"center\"><input type=\"CheckBox\" ID=\"Chk_" + i.ToString() + "\"  Name=\"Chk_" + i.ToString() + "\" Checked></td>";

                    try {

                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "" + myT.Rows[i][0].ToString() + "</td>";
                    }
                    catch
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "&nbsp;</td>";
                    }
                    try
                    {

                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "" + myT.Rows[i][1].ToString() + "</td>";
                    }
                    catch
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "&nbsp;</td>";
                    }
                    try
                    {

                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "" + myT.Rows[i][2].ToString() + "</td>";
                    }
                    catch
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "&nbsp;</td>";
                    }
                    try
                    {

                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "" + myT.Rows[i][3].ToString() + "</td>";
                    }
                    catch
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "&nbsp;</td>";
                    }
                    try
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "" + myT.Rows[i][4].ToString() + "</td>";
                    }
                    catch
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "&nbsp;</td>";
                    }

                    try
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "" + myT.Rows[i][5].ToString() + "</td>";
                    }
                    catch
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "&nbsp;</td>";
                    }
                    try
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "" + myT.Rows[i][6].ToString() + "</td>";
                    }
                    catch
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "&nbsp;</td>";
                    }
                    try
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "" + myT.Rows[i][7].ToString() + "</td>";
                    }
                    catch
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "&nbsp;</td>";
                    }
                    try
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "" + myT.Rows[i][8].ToString() + "</td>";
                    }
                    catch
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "&nbsp;</td>";
                    }
                    try
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "" + myT.Rows[i][9].ToString() + "</td>";
                    }
                    catch
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "&nbsp;</td>";
                    }
                    try
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "" + myT.Rows[i][10].ToString() + "</td>";
                    }
                    catch
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "&nbsp;</td>";
                    }
                    try
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "" + myT.Rows[i][11].ToString() + "</td>";
                    }
                    catch
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "&nbsp;</td>";
                    }
                    try
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "" + myT.Rows[i][12].ToString() + "</td>";
                    }
                    catch
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "&nbsp;</td>";
                    }
                    try
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "" + myT.Rows[i][13].ToString() + "</td>";
                    }
                    catch
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "&nbsp;</td>";
                    }
                    try
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "" + myT.Rows[i][14].ToString() + "</td>";
                    }
                    catch
                    {
                        s_Return += "<td class=\"ListHeadDetails\" nowrap>";
                        s_Return += "&nbsp;</td>";
                    }
                    s_Return += "</tr>";
                }

            }
            s_Return += "</table>";
        }
        return s_Return ;
    }
}
