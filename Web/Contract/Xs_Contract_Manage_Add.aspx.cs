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


public partial class Xs_Contract_Manage_Add : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(Xs_Contract_Manage_Add));
        if (!Page.IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string s_CustomerValue = Request.QueryString["CustomerValue"] == null ? "" : Request.QueryString["CustomerValue"].ToString();
            if (s_CustomerValue != "")
            {
                this.Tbx_CustomerValue.Value = s_CustomerValue;
                this.Tbx_CustomerName.Text = base.Base_GetCustomerName(s_CustomerValue);
            }
            this.Tbx_ID.Text = s_ID;
            this.Lbl_Title.Text = "新增合同档案";
            this.Tbx_STime.Text = DateTime.Now.ToShortDateString();
            base.Base_DropDutyPerson(this.Ddl_DutyPerson);
            base.Base_DropBasicCodeBind(this.DDl_Type,"216");
            base.Base_DropBindFlow(this.Ddl_Flow, "103");
            base.Base_DropBasicCodeBind(this.Drop_Payment, "104");

            KNet_ContractToPaymentbind();
            if (s_ID != "")
            {
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制合同档案";
                }
                else
                {
                    this.Lbl_Title.Text = "修改合同档案";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }
            else
            {
                KNet.BLL.Xs_Contract_Manage bll = new KNet.BLL.Xs_Contract_Manage();
            }
            //this.Lbl_Title.Text
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
        }
    }

    private void ShowInfo(string s_ID)
    {
        KNet.BLL.Xs_Contract_Manage bll = new KNet.BLL.Xs_Contract_Manage();
        KNet.Model.Xs_Contract_Manage model = bll.GetModel(s_ID);
        if (model != null)
        {

            this.Tbx_Code.Text = model.XCM_Code;
            this.Tbx_Title.Text = model.XCM_Title;
            try
            {
                this.Tbx_STime.Text = DateTime.Parse(model.XCM_STime.ToString()).ToShortDateString();
            }
            catch { }
            this.DDl_Type.SelectedValue = model.XCM_Type;
            this.Tbx_CustomerValue.Value = model.XCM_CustomerValue;
            this.Tbx_CustomerName.Text = base.Base_GetCustomerName(model.XCM_CustomerValue);
            this.Ddl_Flow.SelectedValue = model.XCM_Flow;
            this.Ddl_DutyPerson.SelectedValue = model.XCM_DutyPerson;
            this.tbx_Remarks.Text = KNetPage.KHtmlEncode(model.XCM_Remarks);
            this.Tbx_OrderNo.Text = model.XCM_OrderNo.ToString();

            this.Drop_Payment.SelectedValue=model.XCM_PayMent ;
            this.ContractToPayment.SelectedValue = model.XCM_BillType;
            this.Tbx_Technicalne.Text = model.XCM_TechnicalRequire;
            this.Tbx_ProductPackaging.Text = model.XCM_ProductPackaging;
            this.Tbx_QualityRequire.Text = model.XCM_QualityRequire;
            this.Tbx_WarrantyPeriod.Text = model.XCM_WarrantyPeriod;
            this.Tbx_ContractShip.Text = model.XCM_DeliveryReqyire;
            this.Tbx_FhDetails.Text = model.XCM_FhDetails;
            KNet.BLL.PB_Basic_Attachment Bll_Att = new KNet.BLL.PB_Basic_Attachment();
            DataSet Dts_Table = Bll_Att.GetList(" PBA_FID='" + model.XCM_ID + "'");
            if (Dts_Table.Tables[0].Rows.Count > 0)
            {
                Lbl_Details.Text += "<table id=\"myTableDetails\" width=\"100%\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">";
                for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                {
                    string s_FileName = Dts_Table.Tables[0].Rows[i]["PBA_Name"].ToString();
                    string s_filePath = Dts_Table.Tables[0].Rows[i]["PBA_Url"].ToString();
                    Lbl_Details.Text += "<tr><td valign=\"top\" class=\"lvtCol\" align=\"left\" nowrap><a onclick=\"deleteRow3(this)\" href=\"#\">";
                    Lbl_Details.Text += "<img src=\"../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=\"0\"></a></td>";
                    Lbl_Details.Text += "<td class=\"lvtCol\" align=\"left\" nowrap><input type=\"hidden\"  Name=\"Tbx_PName_" + i.ToString() + "\" value=" + s_FileName + ">" + s_FileName + "</td>";
                    Lbl_Details.Text += "<td class=\"lvtCol\" align=\"left\" nowrap><input Name=\"Image1Big_" + i.ToString() + "\"  type=\"hidden\"  value=" + s_filePath + "><a href=\"" + s_filePath + "\" >" + s_FileName + "</a></td></tr>";
                }
                this.Lbl_Details.Text += "</Table>";
            }
            this.Tbx_num.Text = Dts_Table.Tables[0].Rows.Count.ToString();
        }
    }
    private bool SetValue(KNet.Model.Xs_Contract_Manage model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text == "")
            {
                model.XCM_ID = base.GetMainID();
            }
            else
            {
                model.XCM_ID = this.Tbx_ID.Text;
            }
            model.XCM_Code = this.Tbx_Code.Text;
            try{
                model.XCM_STime = DateTime.Parse(this.Tbx_STime.Text);
            }
            catch{}
            model.XCM_Type = this.DDl_Type.SelectedValue;
            model.XCM_Flow = this.Ddl_Flow.SelectedValue;
            model.XCM_CustomerValue = this.Tbx_CustomerValue.Value;
            model.XCM_DutyPerson = this.Ddl_DutyPerson.SelectedValue;
            model.XCM_Remarks = KNetPage.KHtmlEncode(this.tbx_Remarks.Text);
            model.XCM_Title = this.Tbx_Title.Text;
            model.XCM_OrderNo = int.Parse(this.Tbx_OrderNo.Text);
            model.XCM_CheckYN = 0;
            model.XCM_CTime = DateTime.Now;
            model.XCM_Creator = AM.KNet_StaffNo;
            model.XCM_Mender = AM.KNet_StaffNo;
            model.XCM_MTime = DateTime.Now;

            model.XCM_PayMent = this.Drop_Payment.SelectedValue;
            model.XCM_BillType = this.ContractToPayment.SelectedValue;
            model.XCM_TechnicalRequire=this.Tbx_Technicalne.Text;
            model.XCM_ProductPackaging = this.Tbx_ProductPackaging.Text;
            model.XCM_QualityRequire = this.Tbx_QualityRequire.Text;
            model.XCM_WarrantyPeriod = this.Tbx_WarrantyPeriod.Text;
            model.XCM_DeliveryReqyire=this.Tbx_ContractShip.Text;
            model.XCM_FhDetails = this.Tbx_FhDetails.Text;

            ArrayList arr_Image = new ArrayList();
            for (int i = 0; i < int.Parse(this.Tbx_num.Text); i++)
            {
                string s_Name = Request["Tbx_PName_" + i.ToString() + ""] == null ? "" : Request["Tbx_PName_" + i.ToString() + ""].ToString();
                string s_URL = Request["Image1Big_" + i.ToString() + ""] == null ? "" : Request["Image1Big_" + i.ToString() + ""].ToString();
                if (s_Name != "")
                {
                    KNet.Model.PB_Basic_Attachment Model_Att = new KNet.Model.PB_Basic_Attachment();
                    Model_Att.PBA_ID = GetMainID(i);
                    Model_Att.PBA_FID = model.XCM_ID;
                    Model_Att.PBA_Name = s_Name;
                    Model_Att.PBA_URL = s_URL;
                    Model_Att.PBA_Type = "Contract";
                    Model_Att.PBA_Creator = AM.KNet_StaffNo;
                    Model_Att.PBA_CTime = DateTime.Now;
                    arr_Image.Add(Model_Att);
                }
            }
            model.Arr_Details = arr_Image;
            return true;
        }
        catch
        {
            return false;
        }
       
    }


    #region 资料上传操作
    /// <summary>
    /// 上传资料
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void button_ServerClick(object sender, EventArgs e)
    {

        if (!(uploadFile.PostedFile.ContentLength > 0))
        {
            Alert("您没有选择文件!");
        }
        else
        {
            string FileType = uploadFile.PostedFile.ContentType.ToString(); //文件类型
            //if (FileType == "image/gif" || FileType == "image/pjpeg")
            //{
            //}
            //else
            //{
            //    Alert("文件类型服务器不接受!");
            //}
            GetThumbnailImage1();
        }
    }
    /// <summary>
    /// 图片上传
    /// </summary>
    protected void GetThumbnailImage1()
    {
        AdminloginMess AM = new AdminloginMess();
        string UploadPath = "../../UpFile/Contract/";  //上传路径
        string AutoPath = System.DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "").Replace("/", "");
        string fileExt = Path.GetExtension(uploadFile.PostedFile.FileName); //获扩展名
        string FileType = uploadFile.PostedFile.ContentType.ToString(); //文件类型
        string FileName = this.Tbx_Name.Text;
            
            //Path.GetFileName(uploadFile.PostedFile.FileName);
        string filePath = UploadPath + AutoPath + "_" + FileName + fileExt; //大文件名
        if (!Directory.Exists(Server.MapPath(UploadPath)))
        {
            Directory.CreateDirectory(Server.MapPath(UploadPath));
        }
        uploadFile.PostedFile.SaveAs(Server.MapPath(filePath)); //上传
        Up_Loadcs UL = new Up_Loadcs();
        int i_Num = int.Parse(this.Tbx_num.Text);
        if (i_Num == 0)
        {
            Lbl_Details.Text += "<table id=\"myTableDetails\" width=\"100%\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">";
        }
        else
        {
            this.Lbl_Details.Text = this.Lbl_Details.Text.Substring(0, this.Lbl_Details.Text.Length - 8);
        }
        Lbl_Details.Text += "<tr><td valign=\"top\" class=\"lvtCol\" align=\"left\" nowrap><a onclick=\"deleteRow3(this)\" href=\"#\">";
        Lbl_Details.Text += "<img src=\"../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=\"0\"></a></td>";
        Lbl_Details.Text += "<td class=\"lvtCol\" align=\"left\" nowrap><input type=\"hidden\"  Name=\"Tbx_PName_" + i_Num + "\" value=" + FileName + ">" + FileName + "</td>";
        if (FileType == "image/gif" || FileType == "image/pjpeg")
        {
            Lbl_Details.Text += "<td class=\"lvtCol\" align=\"left\" nowrap><input Name=\"Image1Big_" + i_Num + "\"  type=\"hidden\"  value=" + filePath + "><Image ID=\"Image_" + i_Num + "\" Src=\"" + filePath + "\" Height=\"35px\" /></td></tr>";
        }
        else
        {
            Lbl_Details.Text += "<td class=\"lvtCol\" align=\"left\" nowrap><input Name=\"Image1Big_" + i_Num + "\"  type=\"hidden\"  value=" + filePath + "><a href=\"" + filePath + "\" >" + FileName + "</a></td></tr>";
        }
        this.Lbl_Details.Text += "</Table>";
        this.Tbx_num.Text = Convert.ToString(i_Num + 1);
        string s_CustomerValue = Request["Tbx_CustomerValue"] == null ? "" : Request["Tbx_CustomerValue"].ToString();
        string s_CustomerName = Request["Tbx_CustomerName"] == null ? "" : Request["Tbx_CustomerName"].ToString();
        
        this.Tbx_CustomerValue.Value = s_CustomerValue;
        this.Tbx_CustomerName.Text = s_CustomerName;
        

    }
    #endregion

    protected void Btn_SaveOnClick(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.Model.Xs_Contract_Manage model = new KNet.Model.Xs_Contract_Manage();
        KNet.BLL.Xs_Contract_Manage bll = new KNet.BLL.Xs_Contract_Manage();

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
                    AM.Add_Logs("合同档案修改" + this.Tbx_ID.Text);
                    AlertAndRedirect("修改成功！", "Xs_Contract_Manage_List.aspx");

                }
                else
                {
                    AM.Add_Logs("合同档案修改失败" + this.Tbx_ID.Text);
                    AlertAndRedirect("修改失败！", "Xs_Contract_Manage_Add.aspx?ID="+this.Tbx_ID.Text+"");
                }
            }
            catch { }
        }
        else
        {

            try
            {
                bll.Add(model);
                AM.Add_Logs("合同档案增加" + this.Tbx_ID.Text);
                AlertAndRedirect("新增成功！", "Xs_Contract_Manage_List.aspx");
            }
            catch { }
        }
    }


    [Ajax.AjaxMethod()]
    public string GetCode(string s_CustomerValue,string s_Type)
    {
        string s_Return = "",s_OrderNumber="";
        string s_CustomerNumber="",s_Date="";
        try
        {
            KNet.BLL.Xs_Contract_Manage Bll = new KNet.BLL.Xs_Contract_Manage();
            s_OrderNumber=Bll.GetMaxOrder();
            if(s_CustomerValue!="")
            {
                s_CustomerNumber = s_CustomerValue.Substring(1, s_CustomerValue.Length - 1);
                if (s_Type != "")
                {
                    s_Date = DateTime.Now.ToString("yyMMdd");
                    s_Return = "CONT" + s_CustomerNumber + s_OrderNumber.Substring(1, s_OrderNumber.Length - 1) + s_Type + s_Date + "," + s_OrderNumber;
                }
            }
            return s_Return;
        }
        catch(Exception ex)
        {
            return s_Return;
        }
    }

    /// <summary>
    /// 结算方式  （Y）
    /// </summary> 
    protected void KNet_ContractToPaymentbind()
    {
        KNet.BLL.KNet_Sys_CheckMethod bll = new KNet.BLL.KNet_Sys_CheckMethod();
        DataSet ds = bll.GetAllList();
        this.ContractToPayment.DataSource = ds;
        this.ContractToPayment.DataTextField = "CheckName";
        this.ContractToPayment.DataValueField = "CheckNo";
        this.ContractToPayment.DataBind();
        ListItem item = new ListItem("请选择付款方式", ""); //默认值
        this.ContractToPayment.Items.Insert(0, item);
    }
}
