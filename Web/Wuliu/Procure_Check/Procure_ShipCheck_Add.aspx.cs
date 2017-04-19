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


public partial class Web_Procure_ShipCheck_Add : BasePage
{
    private int i_TotalNum = 0, i_TotalNum_Excel = 0;
    private decimal d_TotalNet = 0, d_TotalNet_Excel = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("新增物流对账") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            else
            {
                base.Base_DropWareHouseBind(this.Ddl_HouseNo, " HouseNo in (select Distinct HouseNo from KNet_WareHouse_DirectOutList where KWD_Type='101') ");

                //编号生成  按月
                this.Tbx_CheckCode.Text = base.GetNewID("Cg_Order_Checklist", 0);
                this.Tbx_RkCode.Text = GetIDByMonth();
                this.Tbx_Stime.Text = DateTime.Now.ToShortDateString();
                //KNet.BLL.Knet_Procure_Suppliers Bll = new KNet.BLL.Knet_Procure_Suppliers();
                //DataSet Dts_Table = Bll.GetList(" 1=1 order by SuppName ");
                //this.Ddl_SuppNo.DataSource = Dts_Table;
                //this.Ddl_SuppNo.DataValueField = "SuppNo";
                //this.Ddl_SuppNo.DataTextField = "KPS_SName";
                //this.Ddl_SuppNo.DataBind();
                //ListItem item = new ListItem("--请选择--", ""); //默认值
                //this.Ddl_SuppNo.Items.Insert(0, item);
                ShowTr();
                string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
                if (s_ID != "")
                {
                    this.Tbx_ID.Text = s_ID;
                    this.Tbx_CheckCode.Text = s_ID;
                    ShowDiog();
                    ShowMessage(s_ID);
                }
                else
                {
                    ShowDiog();
                }

            }
        }

    }

    private void ShowMessage(string s_ID)
    {
        KNet.BLL.Cg_Order_Checklist Bll = new KNet.BLL.Cg_Order_Checklist();
        KNet.Model.Cg_Order_Checklist Model = Bll.GetModel(s_ID);
        if (Model != null)
        {
            ShowTr();
            try
            {
                this.StartDate.Text = DateTime.Parse(Model.COC_BeginDate.ToString()).ToShortDateString();
            }
            catch
            {
                this.EndDate.Text = "";
            }
            try
            {
                this.EndDate.Text = DateTime.Parse(Model.COC_EndDate.ToString()).ToShortDateString();
            }
            catch
            {
                this.EndDate.Text = "";
            }
            try
            {
                this.Tbx_Stime.Text = DateTime.Parse(Model.COC_Stime.ToString()).ToShortDateString();
            }
            catch
            {
                this.EndDate.Text = "";
            }
            if (Model.COC_Type == "1")
            {
                this.Ddl_SuppNo.Value = Model.COC_SuppNo;

                this.DataShows();
            }
            else
            {
                this.Ddl_HouseNo.SelectedValue = Model.COC_HouseNo;
                this.DataShows();
            }
            Tbx_DirectInRemarks.Text = Model.COC_Details;
        }
    }
    private void ShowDiog()
    {
        this.BeginQuery("select * from Excel_In_Manage where EIM_FID='" + this.Tbx_CheckCode.Text + "'");
        DataTable Dtb_Excel = this.QueryForDataTable();
        if (Dtb_Excel.Rows.Count > 0)
        {
            string s_Table = Dtb_Excel.Rows[0]["EIM_Details1"].ToString();
            string s_SuppName1 = Dtb_Excel.Rows[0]["EIM_Name"].ToString();
            string s_Type = Dtb_Excel.Rows[0]["EIM_Type"].ToString();
            ShowTr();

        }
        //查询
        bool b_IsDetails = false;
        this.BeginQuery("select * from Excel_In_Details where EID_FID='" + this.Tbx_CheckCode.Text + "'");
        DataTable Dtb_TableDetails = this.QueryForDataTable();
        if (Dtb_TableDetails.Rows.Count > 0)//如果有明细
        {
            b_IsDetails = true;
        }
        else
        {
            b_IsDetails = false;
        }

        string s_Sql = "Select * from PB_Basic_Attachment where PBA_Type='CgCheck' and PBA_FID='" + this.Tbx_CheckCode.Text + "' order by PBA_CTime desc";
        this.BeginQuery(s_Sql);
        DataTable Dtb_Table = this.QueryForDataTable();
        if (Dtb_Table.Rows.Count > 0)
        {
            this.Lbl_Upload.Text = "<a href=\"" + Dtb_Table.Rows[0]["PBA_URL"].ToString() + "\">" + Dtb_Table.Rows[0]["PBA_Name"].ToString() + "</a><br/>";
            this.Tbx_URL.Text = Dtb_Table.Rows[0]["PBA_URL"].ToString();
            string s_Name = "";
            if (b_IsDetails == false)
            {
                string s_Str = " var temp = window.showModalDialog(\"Procure_ShipCheck_Excel.aspx?ID=" + this.Tbx_CheckCode.Text + "&Table=" + Server.UrlEncode(s_Name) + "\", \"\", \"dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1000px;dialogHeight=700px\");";
                StringBuilder s = new StringBuilder();
                s.Append("<script language=javascript>" + "\n");
                s.Append(s_Str + "\n");
                s.Append(" if (temp == \"true\")\n");
                s.Append("{\n");
                s.Append(" window.location.reload();\n");
                s.Append("} \n");
                s.Append("</script>");
                Type cstype = this.GetType();
                ClientScriptManager cs = Page.ClientScript;
                string csname = "ltype";
                if (!cs.IsStartupScriptRegistered(cstype, csname))
                    cs.RegisterStartupScript(cstype, csname, s.ToString());
            }
        }
    }

    protected string GetPrint(string i_IsSend)
    {
        string s_Return = "";
        if (i_IsSend == "0")
        {
            s_Return = "<font color=red>未确认</font>";
        }
        else
        {
            s_Return = "已确认";
        }
        return s_Return;
    }
    private void ShowDiog(bool b_True)
    {
        string s_Sql = "Select * from PB_Basic_Attachment where PBA_Type='CgCheck' and PBA_FID='" + this.Tbx_CheckCode.Text + "' order by PBA_CTime desc";
        this.BeginQuery(s_Sql);
        DataTable Dtb_Table = this.QueryForDataTable();
        if (Dtb_Table.Rows.Count > 0)
        {
            this.Lbl_Upload.Text = "<a href=\"" + Dtb_Table.Rows[0]["PBA_URL"].ToString() + "\">" + Dtb_Table.Rows[0]["PBA_Name"].ToString() + "</a><br/>";
            string s_Name = "";
            string s_Str = " var temp = window.showModalDialog(\"Procure_ShipCheck_Excel.aspx?ID=" + this.Tbx_CheckCode.Text + "&Table=" + Server.UrlEncode(s_Name) + "\", \"\", \"dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1000px;dialogHeight=700px\");";
            StringBuilder s = new StringBuilder();
            s.Append("<script language=javascript>" + "\n");
            s.Append(s_Str + "\n");
            s.Append(" if (temp == \"true\")\n");
            s.Append("{\n");
            s.Append(" window.location.reload();\n");
            s.Append("} \n");
            s.Append("</script>");
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            string csname = "ltype";
            if (!cs.IsStartupScriptRegistered(cstype, csname))
                cs.RegisterStartupScript(cstype, csname, s.ToString());
        }
    }
    private string GetIDByMonth()
    {
        string s_Return = "";
        try
        {
            string s_Sql = "Select isnull(Max(COC_RKCode),'') from Cg_Order_Checklist Where Isnull(COC_Type,'0')='2' and Year(COC_Stime)='" + DateTime.Now.Year.ToString() + "' and Month(COC_Stime)='" + DateTime.Now.Month.ToString() + "' ";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            if (Dtb_Result.Rows.Count > 0)
            {
                if (Dtb_Result.Rows[0][0].ToString() == "")
                {
                    s_Return = DateTime.Today.ToString("yyyyMM") + "001";
                }
                s_Return = Convert.ToString(int.Parse(Dtb_Result.Rows[0][0].ToString()) + 1);
            }
            else
            {
                s_Return = DateTime.Today.ToString("yyyyMM") + "001";
            }
        }
        catch { }
        return s_Return;
    }
    public void DataShows()
    {
        //运费对账

        string s_Sql="Select * from Xs_Sales_Freight a join KNET_WareHouse_DirectOutList b on a.XSF_FID=b.DirectOutNo";
        s_Sql += " Where 1=1 ";
        s_Sql += " and XSF_ID not in (select COD_DirectOutID from Cg_Order_Checklist_Details  a join Cg_Order_Checklist b on a.COD_CheckNo=b.COC_Code  ) ";
        if (this.StartDate.Text != "")
        {
            s_Sql += " and KWD_CwOutTime >='" + this.StartDate.Text + "'";
        }
        if (this.EndDate.Text != "")
        {
            s_Sql += " and KWD_CwOutTime <='" + this.EndDate.Text + "'";
        }
        if (Ddl_HouseNo.SelectedValue != "")
        {

            s_Sql += " and HouseNo ='" + this.Ddl_HouseNo.SelectedValue + "'";
        }

        this.BeginQuery(s_Sql);
       DataTable Dtb_Table=this.QueryForDataTable();
       GridView1.DataSource = Dtb_Table;
       GridView1.DataKeyNames = new string[] { "XSF_ID" };
       GridView1.DataBind();
        //成品对账
        if (this.Tr_HouseNo.Visible == true)
        {
            //不在明细的成品对账单

            //查未找到的采购单号和入库明细
            string s_Sql2 = "";
          
            this.BeginQuery("select * from Excel_In_Details where EID_FID='" + this.Tbx_CheckCode.Text + "' ");
            DataTable Dtb_Excel = this.QueryForDataTable();
            string[] s_FName = new string[4];
            if (Dtb_Excel.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Excel.Rows.Count; i++)
                {
                    int i_Num = int.Parse(Dtb_Excel.Rows[i]["EID_YLine"].ToString()) + 1;
                    if (Dtb_Excel.Rows[i]["EID_ColName"].ToString() == "DirectOutNo")
                    {
                        s_FName[0] = "f" + i_Num.ToString();
                    }
                }

            }
            Excel excel = new Excel();
            DataTable myT = excel.ExcelFirestToDataTable(this.Tbx_URL.Text," 1=1 ");

            string s_Where = " 1=1 and f2<>'' and f11<>'' and " + s_FName[0] + " like '%20%'  ";
            if (s_Sql2 != "")
            {
                s_Sql2 = s_Sql2.Substring(0, s_Sql2.Length - 1).Replace(",", "','");
                s_Where += "and " + s_FName[0] + " not in ('" + s_Sql2 + "') ";
            }
            if (myT != null)
            {

                DataRow[] arrayDR = myT.Select(s_Where);

                this.Lbl_Details.Text = "未找到的出库：<br/>";
                this.Lbl_Details.Text += "<table id=\"myTable\" width=\"98%\" border=\"0\" align=\"center\" cellpadding=\"2\" cellspacing=\"0\" class=\"ListDetails\" style=\"height: 28px\">";

                this.Lbl_Details.Text += "<tr valign=\"top\">";
                this.Lbl_Details.Text += "<td class=\"ListHead\" nowrap>";
                this.Lbl_Details.Text += "<b>F1</b></td>";
                this.Lbl_Details.Text += "<td class=\"ListHead\" nowrap>";
                this.Lbl_Details.Text += "<b>F2</b></td>";
                this.Lbl_Details.Text += "<td class=\"ListHead\" nowrap>";
                this.Lbl_Details.Text += "<b>F3</b></td>";
                this.Lbl_Details.Text += "<td class=\"ListHead\" nowrap>";
                this.Lbl_Details.Text += "<b>F4</b></td>";
                this.Lbl_Details.Text += "<td class=\"ListHead\" nowrap>";
                this.Lbl_Details.Text += "<b>F5</b></td>";
                this.Lbl_Details.Text += "<td class=\"ListHead\" nowrap>";
                this.Lbl_Details.Text += "<b>F6</b></td>";
                this.Lbl_Details.Text += "<td class=\"ListHead\" nowrap>";
                this.Lbl_Details.Text += "<b>F7</b></td>";
                this.Lbl_Details.Text += "<td class=\"ListHead\" nowrap>";
                this.Lbl_Details.Text += "<b>F8</b></td>";
                this.Lbl_Details.Text += "</tr >";
                foreach (DataRow dr in arrayDR)
                {
                    if (dr[1].ToString() != "")
                    {
                        this.Lbl_Details.Text += "<tr>";
                        this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\" >" + dr[0].ToString() + "</td>";
                        this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\" >" + dr[1].ToString() + "</td>";
                        this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\" >" + dr[2].ToString() + "</td>";
                        this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\" >" + dr[3].ToString() + "</td>";
                        this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\" >" + dr[4].ToString() + "</td>";
                        this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\" >" + dr[5].ToString() + "</td>";
                        this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\" >" + dr[6].ToString() + "</td>";
                        this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\" >" + dr[7].ToString() + "</td>";
                        this.Lbl_Details.Text += "</tr>";
                    }
                }
                this.Lbl_Details.Text += "</table >";
            }

        }
    }

    protected void Ddl_HouseNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Ddl_HouseNo.SelectedValue != "")
        {
            this.DataShows();
        }
    }
    public string GetWuliu(string s_DirectOutNo)
    {
        string s_Return = "";
        this.BeginQuery("Select top 1 * from KNet_Sales_OutWareList_FlowList  where KDCode<>'' and OutWareNo in ('" + s_DirectOutNo + "') ");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            s_Return = Dtb_Result.Rows[0]["KDCodeName"].ToString() + "(" + Dtb_Result.Rows[0]["KDCode"].ToString() + "/" + Dtb_Result.Rows[0]["KSO_Phone"].ToString() + ")";
        }
        return s_Return;
    }

    public string GetIC(string s_ProductsBarCode)
    {
        string s_Return = "";
        this.BeginQuery("select * from Xs_Products_Prodocts a  join KNet_Sys_Products b on a.XPP_ProductsBarCode=b.ProductsBarCode  where XPP_FaterBarCode='" + s_ProductsBarCode + "' and b.ProductsType='M130703044953260'");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            s_Return = Dtb_Result.Rows[0]["ProductsPattern"].ToString();
            s_Return = s_Return.Substring(s_Return.IndexOf("-") + 1, s_Return.Length - s_Return.IndexOf("-") - 1);
        }
        return s_Return;
    }

    protected void Btn_Serch_Click(object sender, EventArgs e)
    {
        ShowDiog();
        this.DataShows();
    }
    protected void Btn_Serch_Click1(object sender, EventArgs e)
    {
        ShowDiog(true);
    }
    protected void Btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            AdminloginMess AM = new AdminloginMess();
            KNet.BLL.Cg_Order_Checklist Bll_Order_Checklist = new KNet.BLL.Cg_Order_Checklist();
            KNet.BLL.Cg_Order_Checklist_Details Bll_Order_ChecklistDetails = new KNet.BLL.Cg_Order_Checklist_Details();
            KNet.Model.Cg_Order_Checklist Model_Order_Checklist = new KNet.Model.Cg_Order_Checklist();
            if (this.Tbx_ID.Text != "")
            {
                Model_Order_Checklist.COC_Code = this.Tbx_ID.Text;
            }
            else
            {
                Model_Order_Checklist.COC_Code = base.GetNewID("Cg_Order_Checklist", 1);
            }
            Model_Order_Checklist.COC_Stime = DateTime.Parse(this.Tbx_Stime.Text);
            Model_Order_Checklist.COC_HouseNo = Ddl_HouseNo.SelectedValue;
            if (this.StartDate.Text != "")
            {
                Model_Order_Checklist.COC_BeginDate = DateTime.Parse(this.StartDate.Text);
            }
            if (this.EndDate.Text != "")
            {
                Model_Order_Checklist.COC_EndDate = DateTime.Parse(this.EndDate.Text);
            }
            Model_Order_Checklist.COC_Creator = AM.KNet_StaffNo;
            Model_Order_Checklist.COC_CTime = DateTime.Now;
            Model_Order_Checklist.COC_Mender = AM.KNet_StaffNo;
            Model_Order_Checklist.COC_MTime = DateTime.Now;
            Model_Order_Checklist.COC_Type = "2";
            Model_Order_Checklist.COC_SuppNo = this.Ddl_SuppNo.Value;
            Model_Order_Checklist.COC_RKCode = this.Tbx_RkCode.Text;
            Model_Order_Checklist.COC_Details = this.Tbx_DirectInRemarks.Text;
            ArrayList arr_Details = new ArrayList();

            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {

                KNet.Model.Cg_Order_Checklist_Details Model_Order_ChecklistDetails = new KNet.Model.Cg_Order_Checklist_Details();
                CheckBox chk = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
                if (chk.Checked)
                {
                    string s_FID = GridView1.DataKeys[i].Value.ToString();
                    string s_Details = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_Details")).Text;
                    string s_Money = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_Money")).Text;
                    Model_Order_ChecklistDetails.COD_Code = base.GetNewID("Cg_Order_Checklist_Details", 1);
                    Model_Order_ChecklistDetails.COD_CheckNo = Model_Order_Checklist.COC_Code;
                    Model_Order_ChecklistDetails.COD_DirectOutID = s_FID;
                    Model_Order_ChecklistDetails.COD_Details = s_Details;
                    Model_Order_ChecklistDetails.COD_RealMoney = decimal.Parse(s_Money);
                    arr_Details.Add(Model_Order_ChecklistDetails);
                }
            }

            Model_Order_Checklist.arr_Details = arr_Details;
            if (this.Tbx_ID.Text == "")
            {
                Bll_Order_Checklist.Add(Model_Order_Checklist);
                AM.Add_Logs("物流对账增加！" + Model_Order_Checklist.COC_Code);
                AlertAndRedirect("物流对账成功！", "Procure_ShipCheck_List.aspx");
            }
            else
            {
                Bll_Order_Checklist.Update(Model_Order_Checklist);
                AM.Add_Logs("物流对账修改！" + Model_Order_Checklist.COC_Code);
                AlertAndRedirect("物流对账修改成功！", "Procure_ShipCheck_List.aspx");
            }
        }
        catch (Exception ex)
        {
            Alert(ex.Message);
        }
    }
    private void ShowTr()
    {
    }

    protected void Ddl_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowTr();
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
                BLL.DeleteByFID(this.Tbx_CheckCode.Text);
                BLL.Add(model);
                AM.Add_Logs("附件上传成功：编号：" + model.PBA_ID);
                this.Lbl_Upload.Text = "<a href=\"" + model.PBA_URL + "\">" + model.PBA_Name + "</a><br/>";
                ShowDiog();
            }
            catch (Exception ex) { }
        }
    }

    public string GetHQCode(string s_OutID)
    {
        string s_Return = "";
        try
        {
            string s_Sql = "Select * from PB_Basic_Attachment where PBA_Type='SalesOut' and PBA_FID='" + s_OutID + "'";
            this.BeginQuery(s_Sql);
            DataTable Dtb_Table = (DataTable)this.QueryForDataTable();
            if (Dtb_Table.Rows.Count > 0)
            {
                s_Return = "<a href=\"../" + Dtb_Table.Rows[0]["PBA_Url"] + "\" target=\"_blank\">是</a>";
            }
            else
            {
                s_Return = "<font color=red>否</font>";
            }

        }
        catch
        { }
        return s_Return;
    }

    #region 资料上传操作
    /// <summary>
    /// 图片上传
    /// </summary>
    protected void GetThumbnailImage1(KNet.Model.PB_Basic_Attachment model)
    {
        AdminloginMess AM = new AdminloginMess();
        //类别下面的
        string UploadPath = "../../../UpFile/CGCheck/";  //上传路径
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

        model.PBA_FID = this.Tbx_CheckCode.Text;
        model.PBA_Type = "CgCheck";
        model.PBA_ID = GetMainID();
        model.PBA_Name = FileName;
        model.PBA_URL = filePath;
        model.PBA_CTime = DateTime.Now;
        model.PBA_Creator = AM.KNet_StaffNo;
        model.PBA_Remarks = "";
    }
    #endregion

}
