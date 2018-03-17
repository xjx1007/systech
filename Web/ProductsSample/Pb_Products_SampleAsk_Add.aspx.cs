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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
     
            base.Base_DropDutyPerson(this.Ddl_DutyPerson);
            base.Base_DropBasicCodeBindByWhere(this.Ddl_Dept, "124", " and PBC_Code In ('16','14')");
            this.Ddl_Dept.SelectedValue = "14";
            this.Tbx_Code.Text = base.GetNewID("Pb_Products_SampleAsk", 0);

            this.Lbl_Title.Text = "新增样品领用申请单";
            this.Tbx_STime.Text = DateTime.Now.ToShortDateString();

            if (s_ID!= "")
            {
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制样品领用申请单";
                }
                else
                {
                    this.Lbl_Title.Text = "修改样品领用申请单";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }
        }
    }

    private void ShowInfo(string s_ID)
    {
        KNet.BLL.Pb_Products_Sample bll = new KNet.BLL.Pb_Products_Sample();
        KNet.Model.Pb_Products_Sample model = bll.GetModel(s_ID);
        this.Tbx_STime.Text = DateTime.Parse(model.PPS_Stime.ToString()).ToShortDateString();
        this.BeginQuery("Select * From KNet_Sys_Products where KSP_SampleId='" + s_ID + "'");
        this.QueryForDataTable();
        DataTable Dtb_Table = Dtb_Result;
        if (Dtb_Table.Rows.Count>0)
        {
            string s_ProdutsBarCode = Dtb_Table.Rows[0]["ProductsBarCode"].ToString();
            this.Tbx_ProductsName.Text = base.Base_GetProdutsName(s_ProdutsBarCode);
            this.Tbx_ProductsBarCode.Text = s_ProdutsBarCode;
            this.Tbx_ProductsEdition.Text = base.Base_GetProductsEdition(s_ProdutsBarCode);
        }
        if (this.Tbx_ProductsBarCode.Text == "")
        {
            AlertAndRedirect("没有相关的产品明细", "Pb_Products_Sample_List.aspx");
        }
        this.Ddl_DutyPerson.SelectedValue = model.PPS_DutyPeson;
        this.Tbx_Remarks.Text = model.PPS_Remarks;
        this.Ddl_Dept.SelectedValue = model.PPS_Dept;
        this.Tbx_Use.Text = model.PPS_Use;
        this.Tbx_Number.Text = model.PPS_Number.ToString();
    }
    private bool SetValue(KNet.Model.Pb_Products_SampleAsk model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            model.PPA_ID = base.GetNewID("Pb_Products_SampleAsk", 1);

            if (this.Tbx_STime.Text != "")
            {
                model.PPA_Stime = DateTime.Parse(this.Tbx_STime.Text);
            }
            model.PPA_ProdutsBarCode = this.Tbx_ProductsBarCode.Text;
            model.PPA_DutyPerson = this.Ddl_DutyPerson.SelectedValue;
            model.PPA_Type = int.Parse(this.Ddl_Dept.SelectedValue);
            try
            {
                model.PPA_Number = int.Parse(this.Tbx_Number.Text);
            }
            catch
            {
                model.PPA_Number = 1;
            }
            model.PPA_Use = this.Tbx_Use.Text;
            if (Chk_IsBack.Checked)
            {
                model.PPA_IsBack = 1;
            }
            else
            {
                model.PPA_IsBack = 0;
            }
            model.PPA_Remarks = this.Tbx_Remarks.Text;
            model.PPA_Creator = AM.KNet_StaffNo;
            model.PPA_CTime = DateTime.Now;
            model.PPA_Mender = AM.KNet_StaffNo;
            model.PPA_MTime = DateTime.Now;
            model.PPA_SampleID = this.Tbx_ID.Text;
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
        string s_ID=this.Tbx_ID.Text;

        KNet.Model.Pb_Products_SampleAsk model = new KNet.Model.Pb_Products_SampleAsk();
        KNet.BLL.Pb_Products_SampleAsk bll = new KNet.BLL.Pb_Products_SampleAsk();

        if (this.SetValue(model) == false)
        {
            Alert("系统错误！");
            return;
        }
            try
            {
                bll.Add(model);
                AlertAndRedirect("样品领用申请单增加！", "Pb_Products_Sample_List.aspx");
                AM.Add_Logs("样品领用申请单增加" + this.Tbx_ID.Text);
            }
            catch(Exception ex) { }

        //    if (s_ID == "")//新增
        //    { }
        //else
        //{

        //    try
        //    {
        //        bll.Update(model);
        //        AM.Add_Logs("样品领用申请单修改" + this.Tbx_ID.Text);
        //        AlertAndRedirect("修改成功！", "Pb_Products_Sample_List.aspx");
        //    }
        //    catch(Exception ex) { }
        //}
    }

}
