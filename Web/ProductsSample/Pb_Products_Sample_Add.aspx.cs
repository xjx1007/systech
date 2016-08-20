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


public partial class Web_Sales_Pb_Products_Sample_Add : BasePage
{
    public string s_MyTable_Detail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string s_isModify = Request.QueryString["isModify"] == null ? "" : Request.QueryString["isModify"].ToString();
            string s_ProductsBarCode = Request.QueryString["ProductsBarCode"] == null ? "" : Request.QueryString["ProductsBarCode"].ToString();

            base.Base_DropDutyPerson(this.Ddl_DutyPerson);
            this.Lbl_Title.Text = "新增样品申请";
            this.Tbx_STime.Text = DateTime.Now.ToShortDateString();
            base.Base_DropBasicCodeBind(this.Ddl_Type, "142");
            if (s_ID != "")
            {
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制样品申请";
                }
                else
                {
                    this.Lbl_Title.Text = "修改样品申请";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";

                ShowInfo(s_ID);
                base.Base_DropLinkManBind(this.Ddl_LinkMan, this.Tbx_CustomerValue.Value);
            }
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin(this.Lbl_Title.Text) == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            if (s_Type == "M")
            {
                this.Ddl_Dept.Enabled = true;
                base.Base_DropBasicCodeBindByWhere(this.Ddl_Dept, "124", " and PBC_Code in ('14','15')");
                this.Ddl_Dept.SelectedValue = "14";
            }
            else
            {
                base.Base_DropBasicCodeBind(this.Ddl_Dept, "124", false);
                this.Ddl_Dept.SelectedValue = "0";
                this.Ddl_Dept.Enabled = false;
            }

            if (s_isModify == "1")
            {

                Pan_Details.Visible = true;
                this.Ddl_Type.SelectedValue = "2";
                this.Ddl_Type.Enabled = false;
                if (s_ProductsBarCode == "")
                {
                    if (s_ID != "")
                    {
                        string s_Sql1 = "Select  ProductsBarCode from KNet_Sys_Products where KSP_SampleId='" + s_ID + "'";
                        this.BeginQuery(s_Sql1);
                        s_ProductsBarCode = this.QueryForReturn();

                        if (s_ID != "")
                        {
                            this.ShowInfo(s_ID);
                            this.Tbx_ID.Text = "";
                            this.Tbx_NeedTime.Text = "";
                        }
                    }
                }
                if (s_ProductsBarCode != "")
                {

                    //如果是样品设计修改
                    KNet.BLL.KNet_Sys_Products Bll_Products = new KNet.BLL.KNet_Sys_Products();
                    KNet.Model.KNet_Sys_Products Model_Products = Bll_Products.GetModelB(s_ProductsBarCode);

                    this.Tbx_ProductsBarCode.Value = s_ProductsBarCode;
                    this.Tbx_ProductsBarName.Text = Model_Products.ProductsEdition;
                    string s_Sql = " Select * from KNet_Sys_Products a  left join Pb_Products_Sample b on a.KSP_SampleId=b.PPS_ID where ProductsBarCode='" + s_ProductsBarCode + "'";
                    this.BeginQuery(s_Sql);
                    DataTable Dts_Table = (DataTable)this.QueryForDataTable();
                    for (int i = 0; i < Dts_Table.Rows.Count; i++)
                    {
                        this.Lbl_ProductsDetails.Text += "<td class=\"ListHeadDetails\" align=\"left\" nowrap>" + base.Base_GetProductsEdition_Link(s_ProductsBarCode) + "</td>";
                        this.Lbl_ProductsDetails.Text += "<td class=\"ListHeadDetails\" align=\"left\" >" + Dts_Table.Rows[i]["PPS_Requirement"].ToString() + "</td>";
                        this.Lbl_ProductsDetails.Text += "<td class=\"ListHeadDetails\" align=\"left\" >" + Dts_Table.Rows[i]["ProductsDescription"].ToString() + "</td>";
                        this.Lbl_ProductsDetails.Text += "<td class=\"ListHeadDetails\" align=\"left\" >" + base.Base_GetHouseAndNumber(s_ProductsBarCode) + "</td>";

                        string s_Details = "";
                        try
                        {
                            string s_Sql1 = "select v_OrderNo,wrkNumber from v_OrderRkDetailsQR where v_ProductsBarCode='" + s_ProductsBarCode + "' and  wrkNumber>0";
                            this.BeginQuery(s_Sql1);
                            DataTable Dtb_Tabel1 = (DataTable)this.QueryForDataTable();
                            for (int j = 0; j < Dtb_Tabel1.Rows.Count; j++)
                            {
                                s_Details += "<a href=\"/Web/CG/Order/Knet_Procure_OpenBilling_View.aspx?ID=" + Dtb_Tabel1.Rows[j][0].ToString() + "\" target=\"_blank\" >" + Dtb_Tabel1.Rows[j][0].ToString() + "(" + Dtb_Tabel1.Rows[j][1].ToString() + ")<br/>";
                            }
                        }
                        catch
                        { }
                        this.Lbl_ProductsDetails.Text += "<td class=\"ListHeadDetails\" align=\"left\" >" + s_Details + "</td>";
                        this.Lbl_ProductsDetails.Text += "<td class=\"ListHeadDetails\" align=\"left\" ><input type=\"textarea\" rows=\"2\" cols=\"20\"  Name=\"Tbx_DealDetails\" style=\"height:60px;width:200px;\" value=\"" + Dts_Table.Rows[i]["PPS_DealDetails"].ToString() + "\" /></td>";

                        if ((Model_Products.KSP_SampleId != "") && (Model_Products.KSP_SampleId != null))
                        {
                            this.ShowInfo(Model_Products.KSP_SampleId);
                            this.Tbx_ID.Text = "";
                            this.Tbx_NeedTime.Text = "";
                        }
                    }

                }
            }
            else
            {
                Pan_Details.Visible = false;
                if (s_Type == "0")
                {
                    base.Base_DropBasicCodeBind(this.Ddl_Dept, "124", false);
                    this.Ddl_Dept.SelectedValue = "5";
                    this.Ddl_Dept.Enabled = false;
                    this.BeginQuery("Select * from Knet_Procure_OrdersList_Details where ProductsBarCode in (Select ProductsBarCode from KNet_Sys_Products where KSP_SampleId='" + s_ID + "')");
                    this.QueryForDataTable();
                    if (this.Dtb_Result.Rows.Count > 0)
                    {
                        AlertAndGoBack("已有该产品的采购订单，不能设计修改！");
                    }
                }
            }

        }
    }

    private void ShowInfo(string s_ID)
    {
        KNet.BLL.Pb_Products_Sample bll = new KNet.BLL.Pb_Products_Sample();
        KNet.Model.Pb_Products_Sample model = bll.GetModel(s_ID);
        string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
        if (s_Type != "0")
        {
            if ((model.PPS_Dept != "0") && (model.PPS_Dept != "2") && (model.PPS_Dept != "13") && (model.PPS_Dept != "22"))
            {
                AlertAndGoBack("已审批不能修改！");
            }
        }
        this.Tbx_ID.Text = s_ID;
        this.Tbx_Code.Text = model.PPS_Code;
        this.Tbx_Name.Text = model.PPS_Name;
        this.Tbx_STime.Text = DateTime.Parse(model.PPS_Stime.ToString()).ToShortDateString();
        try
        {
            this.Tbx_NeedTime.Text = DateTime.Parse(model.PPS_Needtime.ToString()).ToShortDateString();
        }
        catch { }
        this.Tbx_CustomerValue.Value = model.PPS_CustomerValue;
        this.Tbx_CustomerName.Text = base.Base_GetCustomerName(model.PPS_CustomerValue);
        this.Ddl_LinkMan.SelectedValue = model.PPS_LinkMan;

        if (s_Type != "M")
        {
            this.Ddl_DutyPerson.SelectedValue = model.PPS_DutyPeson;
            this.Ddl_Dept.SelectedValue = model.PPS_Dept;
        }
        this.Tbx_Requirement.Text = model.PPS_Requirement;
        this.Tbx_Remarks.Text = model.PPS_Remarks;
        this.Ddl_LinkMan.SelectedValue = model.PPS_LinkMan;
        this.Ddl_Type.SelectedValue = model.PPS_Type;

        this.Tbx_Shell.Value = model.PPS_Shell;
        this.Tbx_Number.Text = model.PPS_Number.ToString();
        this.Tbx_Use.Text = model.PPS_Use;
        if (model.PPS_Appearance == "1")
        {
            Chk_Appearance.Checked = true;
        }
        else
        {
            Chk_Appearance.Checked = false;
        }
        this.Tbx_Resin.Text = model.PPS_Resin;
        this.Tbx_Chip.Text = model.PPS_Chip;
        this.Tbx_ProductsBarCode.Value = model.PPS_ProductsBarCode;
        this.Tbx_ProductsBarName.Text = base.Base_GetProductsEdition(model.PPS_ProductsBarCode);
        if (model.PPS_ResinMaterial == "1")
        {
            Chk_ResinMaterial.Checked = true;
        }
        else
        {
            Chk_ResinMaterial.Checked = false;
        }
        this.Tbx_Shell.Value = model.PPS_Shell;
        KNet.BLL.Pb_Products_Sample_Images Bll_Images = new KNet.BLL.Pb_Products_Sample_Images();
        DataSet Dts_Table = Bll_Images.GetList(" PPI_SmapleID='" + model.PPS_ID + "' and PBI_Type='0' ");
        if (Dts_Table != null)
        {
            for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
            {
                Lbl_Details.Text += "<tr><td valign=\"top\" class=\"ListHeadDetails\" align=\"left\" nowrap><a onclick=\"deleteRow(this)\" href=\"#\">";
                Lbl_Details.Text += "<img src=\"../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=\"0\"></a></td>";
                Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\" nowrap><input type=\"hidden\"  Name=\"Tbx_PName_" + Convert.ToString(i) + "\" value=" + Dts_Table.Tables[0].Rows[i]["PPI_Name"].ToString() + ">" + Dts_Table.Tables[0].Rows[i]["PPI_Name"].ToString() + "</td>";
                Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\" nowrap><input Name=\"Image1Big_" + Convert.ToString(i) + "\"  type=\"hidden\"  value=" + Dts_Table.Tables[0].Rows[i]["PPI_Url"].ToString() + "><Image ID=\"Image_" + Convert.ToString(i) + "\" Src=\"" + Dts_Table.Tables[0].Rows[i]["PPI_Url"].ToString() + "\" Height=\"35px\" /></td></tr>";
            }
            this.Tbx_num.Text = Dts_Table.Tables[0].Rows.Count.ToString();
        }

    }

    private bool SetValue(KNet.Model.Pb_Products_Sample model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text == "")
            {
                model.PPS_ID = GetMainID();
                model.PPS_Code = base.GetNewID("Pb_Products_Sample", 1);
            }
            else
            {
                model.PPS_ID = this.Tbx_ID.Text;
                model.PPS_Code = this.Tbx_Code.Text;

            }
            model.PPS_Name = this.Tbx_Name.Text;
            if (this.Tbx_STime.Text != "")
            {
                model.PPS_Stime = DateTime.Parse(this.Tbx_STime.Text);
            }
            if (this.Tbx_NeedTime.Text != "")
            {
                model.PPS_Needtime = DateTime.Parse(this.Tbx_NeedTime.Text);
            }

            model.PPS_CustomerValue = this.Tbx_CustomerValue.Value;
            model.PPS_LinkMan = Request["Ddl_LinkMan"];
            model.PPS_DutyPeson = this.Ddl_DutyPerson.SelectedValue;
            model.PPS_Dept = this.Ddl_Dept.SelectedValue;
            model.PPS_Remarks = this.Tbx_Remarks.Text;
            model.PPS_Creator = AM.KNet_StaffNo;
            model.PPS_CTime = DateTime.Now;
            model.PPS_Mender = AM.KNet_StaffNo;
            model.PPS_MTime = DateTime.Now;
            model.PPS_Requirement = this.Tbx_Requirement.Text;
            model.PPS_Shell = this.Tbx_Shell.Value;
            model.PPS_Chip = this.Tbx_Chip.Text;
            model.PPS_DealDetails = Request["Tbx_DealDetails"] == null ? "" : Request["Tbx_DealDetails"];
            try
            {
                model.PPS_Number = int.Parse(this.Tbx_Number.Text);
            }
            catch
            {
                model.PPS_Number = 1;
            }
            model.PPS_Use = this.Tbx_Use.Text;
            if (Chk_Appearance.Checked)
            {
                model.PPS_Appearance = "1";
            }
            else
            {
                model.PPS_Appearance = "0";
            }
            model.PPS_Resin = this.Tbx_Resin.Text;
            if (this.Chk_ResinMaterial.Checked)
            {
                model.PPS_ResinMaterial = "1";
            }
            else
            {
                model.PPS_ResinMaterial = "0";
            }
            model.PPS_Shell = this.Tbx_Shell.Value;
            ArrayList arr_Details = new ArrayList();
            if (this.Tbx_num.Text != "0")
            {
                int i_Num = int.Parse(this.Tbx_num.Text);
                for (int i = 0; i < i_Num; i++)
                {
                    KNet.Model.Pb_Products_Sample_Images Model_Details = new KNet.Model.Pb_Products_Sample_Images();
                    Model_Details.PPI_ID = base.GetNewID("Pb_Products_Sample_Images", 1);
                    Model_Details.PPI_SmapleID = model.PPS_ID;
                    Model_Details.PPI_URL = Request["Image1Big_" + i.ToString() + ""] == null ? "" : Request["Image1Big_" + i.ToString() + ""].ToString();
                    Model_Details.PPI_Name = Request["Tbx_PName_" + i.ToString() + ""] == null ? "" : Request["Tbx_PName_" + i.ToString() + ""].ToString();
                    Model_Details.PBI_Type = "1";
                    Model_Details.PPI_CTime = DateTime.Now;
                    Model_Details.PPI_Creator = AM.KNet_StaffNo;
                    if (Model_Details.PPI_URL != "")
                    {
                        arr_Details.Add(Model_Details);
                    }
                }
            }
            model.arr_Details = arr_Details;

            model.PPS_Type = this.Ddl_Type.SelectedValue;
            model.PPS_ProductsBarCode = this.Tbx_ProductsBarCode.Value;
            return true;
        }
        catch
        {
            return false;
        }

    }

    protected void Btn_SaveOnClick(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        string s_ID = this.Tbx_ID.Text;

        KNet.Model.Pb_Products_Sample model = new KNet.Model.Pb_Products_Sample();
        KNet.BLL.Pb_Products_Sample bll = new KNet.BLL.Pb_Products_Sample();

        if (this.SetValue(model) == false)
        {
            Alert("系统错误！");
            return;
        }
        if (s_ID == "")//新增
        {
            try
            {
                bll.Add(model);
                AM.Add_Logs("样品申请增加" + this.Tbx_ID.Text);
                AlertAndRedirect("新增成功！", "Pb_Products_Sample_List.aspx");
                //如果选择了产品
                if (model.PPS_ProductsBarCode != "")
                {
                    KNet.BLL.KNet_Sys_Products Bll_Products = new KNet.BLL.KNet_Sys_Products();
                    KNet.Model.KNet_Sys_Products Model_Products = new KNet.Model.KNet_Sys_Products();
                    Model_Products.ProductsBarCode = model.PPS_ProductsBarCode;
                    Model_Products.KSP_Del = 1;
                    Bll_Products.UpdateDel(Model_Products);
                }
                //通知市场销售部审核通过审核
                if (model.PPS_Type == "1")
                {
                    base.Base_SendMessage(Base_GetDeptPerson("市场销售部", 1), KNetPage.KHtmlEncode("有 样品审核 <a href='Web/ProductsSample/Pb_Products_Sample_Approval.aspx?ID=" + this.Tbx_ID.Text + "'  onclick=\"RemoveSms('" + base.GetNewID("System_Message_Manage", 0) + "', '', 0);\"> " + this.Tbx_Name.Text + "</a> 需要审核，敬请关注！"));
                }
                else if (model.PPS_Type == "2")
                {
                    base.Base_SendMessage(Base_GetDeptPerson("供应链平台", 1), KNetPage.KHtmlEncode("有 样品审核 <a href='Web/ProductsSample/Pb_Products_Sample_Approval.aspx?ID=" + this.Tbx_ID.Text + "'  onclick=\"RemoveSms('" + base.GetNewID("System_Message_Manage", 0) + "', '', 0);\"> " + this.Tbx_Name.Text + "</a> 需要审核，敬请关注！"));
                }
                else
                {
                    base.Base_SendMessage(Base_GetDeptPerson("研发中心", 1), KNetPage.KHtmlEncode("有 样品审核 <a href='Web/ProductsSample/Pb_Products_Sample_Approval.aspx?ID=" + this.Tbx_ID.Text + "'  onclick=\"RemoveSms('" + base.GetNewID("System_Message_Manage", 0) + "', '', 0);\"> " + this.Tbx_Name.Text + "</a> 需要审核，敬请关注！"));
                }

            }
            catch (Exception ex) { }
        }
        else
        {

            try
            {
                bll.Update(model);
                AM.Add_Logs("样品申请修改" + this.Tbx_ID.Text);
                AlertAndRedirect("修改成功！", "Pb_Products_Sample_List.aspx");   //通知市场销售部审核通过审核
            }
            catch (Exception ex) { }
        }
    }

    #region 图片上传操作
    /// <summary>
    /// 上传图片
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
            GetThumbnailImage();
        }
    }
    /// <summary>
    /// 图片上传
    /// </summary>
    protected void GetThumbnailImage()
    {
        AdminloginMess AM = new AdminloginMess();
        if (this.Tbx_PicName.Text == "")
        {
            Alert("请输入图片名称！");
        }
        else
        {
            string UploadPath = "../UpLoadPic/Sample/";  //上传路径
            string AutoPath = System.DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "").Replace("/", "");
            string fileExt = Path.GetExtension(uploadFile.PostedFile.FileName); //获扩展名
            string FileType = uploadFile.PostedFile.ContentType.ToString(); //文件类型
            string filePath = UploadPath + AM.KNet_StaffName + "/" + AutoPath + fileExt; //大文件名

            //if (FileType == "image/gif" || FileType == "image/pjpeg")
            //{
            //}
            //else
            //{
            //    Alert("文件类型服务器不接受!");
            //}
            if (!Directory.Exists(Server.MapPath(UploadPath + AM.KNet_StaffName + "/")))
            {
                Directory.CreateDirectory(Server.MapPath(UploadPath + AM.KNet_StaffName + "/"));
            }
            uploadFile.PostedFile.SaveAs(Server.MapPath(filePath)); //上传
            Up_Loadcs UL = new Up_Loadcs();
            int i_Num = int.Parse(this.Tbx_num.Text);
            Lbl_Details.Text += "<tr><td valign=\"top\" class=\"lvtCol\" align=\"left\" nowrap><a onclick=\"deleteRow(this)\" href=\"#\">";
            Lbl_Details.Text += "<img src=\"../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=\"0\"></a></td>";
            Lbl_Details.Text += "<td class=\"lvtCol\" align=\"left\" nowrap><input type=\"hidden\"  Name=\"Tbx_PName_" + i_Num + "\" value=" + this.Tbx_PicName.Text + ">" + this.Tbx_PicName.Text + "</td>";
            if (FileType == "image/gif" || FileType == "image/pjpeg")
            {
                Lbl_Details.Text += "<td class=\"lvtCol\" align=\"left\" nowrap><input Name=\"Image1Big_" + i_Num + "\"  type=\"hidden\"  value=" + filePath + "><Image ID=\"Image_" + i_Num + "\" Src=\"" + filePath + "\" Height=\"35px\" /></td></tr>";
            }
            else
            {
                Lbl_Details.Text += "<td class=\"lvtCol\" align=\"left\" nowrap><input Name=\"Image1Big_" + i_Num + "\"  type=\"hidden\"  value=" + filePath + "><a href=\"" + filePath + "\" >" + this.Tbx_PicName.Text + "</a></td></tr>";
            }
            this.Tbx_PicName.Text = "";
            this.Tbx_num.Text = Convert.ToString(i_Num + 1);
            //Image1.ImageUrl = filePath;

            this.Tbx_CustomerValue.Value = Request["Tbx_CustomerValue"].ToString();
            this.Tbx_CustomerName.Text = base.Base_GetCustomerName(this.Tbx_CustomerValue.Value);
            this.Tbx_Shell.Value = Request["Tbx_Shell"].ToString();
            this.Tbx_ShellName.Text = base.Base_GetProdutsName(this.Tbx_Shell.Value);
            //this.Tbx_ShellName.Text = Request["Tbx_ShellName"].ToString();
            //this.Tbx_Shell.Text = Request["Tbx_Shell"].ToString();

        }
    }

    #endregion

}
