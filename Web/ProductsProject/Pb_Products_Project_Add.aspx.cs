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

using KNet.DBUtility;
using KNet.Common;
using System.Data.SqlClient;
using System.Text;

public partial class Pb_Project_Manage_Add : BasePage
{

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
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            this.Tbx_ID.Text = s_ID;
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            this.Tbx_Type.Text = s_Type;
            base.Base_DropBasicCodeBind(this.Ddl_ProductsType, "153");
            base.Base_DropBasicCodeBind(this.Ddl_Model, "159");
            base.Base_DropBasicCodeBind(this.Ddl_SoftNeed, "155");
            base.Base_DropBasicCodeBind(this.Ddl_KeyCustom, "156");
            base.Base_DropBasicCodeBind(this.Ddl_Standards, "157");
            base.Base_DropBasicCodeBind(this.Ddl_Shape, "158");
            base.Base_DropBasicCodeBind(this.Ddl_Lamp, "161");//指示灯 要 不要
            base.Base_DropBasicCodeBind(this.Ddl_Led, "160");
            base.Base_DropBasicCodeBind(this.Ddl_HaveBattery, "161");
            base.Base_DropBasicCodeBind(this.Ddl_Packing, "163");//包装方式
            base.Base_DropBasicCodeBind(this.Ddl_ProductsDescription, "164");//产品说明书
            base.Base_DropBasicCodeBind(this.Ddl_Warranty, "161");//保修
            this.Tbx_Code.Text = base.GetNewID("Pb_Project_Manage", 0);
            if (s_ID != "")
            {
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制项目";
                }
                else
                {
                    this.Lbl_Title.Text = "修改项目";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }
            else
            {
                this.Lbl_Title.Text = "新增项目";
            }
        }
    }
    private void ShowInfo(string s_ID)
    {
        KNet.BLL.Pb_Project_Manage bll = new KNet.BLL.Pb_Project_Manage();
        KNet.Model.Pb_Project_Manage model = bll.GetModel(s_ID);

        if (model != null)
        {
            this.Tbx_Code.Text = model.PPM_Code;
            this.Tbx_Products.Text = model.PPM_Products;
            this.Tbx_CustomerID.Text = model.PPM_CustomerValue;
            this.Tbx_CustomerName.Text = base.Base_GetCustomerName(model.PPM_CustomerValue);
            try
            {
                this.Tbx_Stime.Text = DateTime.Parse(model.PPM_Stime.ToString()).ToShortDateString();
            }
            catch { }
            this.Ddl_ProductsType.SelectedValue = model.PPM_ProductsType;
            this.Ddl_Model.SelectedValue = model.PPM_Model;
            this.Ddl_SoftNeed.SelectedValue = model.PPM_SoftNeed;
            this.Ddl_KeyCustom.SelectedValue = model.PPM_KeyCustom;
            this.Ddl_Standards.SelectedValue = model.PPM_Standards;
            this.Tbx_OtherRemarks.Text = model.PPM_OtherRemarks;
            this.Ddl_Shape.SelectedValue = model.PPM_Shape;
            this.Ddl_Lamp.SelectedValue = model.PPM_Lamp;
            this.Ddl_Led.SelectedValue = model.PPM_Led;
            this.Tbx_Upper.Text = model.PPM_Upper;
            this.Tbx_Lower.Text = model.PPM_Lower;
            this.Tbx_Battery.Text = model.PPM_Battery;
            this.Tbx_Conductive.Text = model.PPM_Conductive;
            this.Tbx_KeyNumber.Text = model.PPM_KeyNumber;
            this.Tbx_Pot.Text = model.PPM_Pot;
            this.Tbx_Backlight.Text = model.PPM_Backlight;
            this.Tbx_Description.Text = model.PPM_Description;
            this.Ddl_HaveBattery.SelectedValue = model.PPM_HaveBattery;
            this.Ddl_Packing.SelectedValue = model.PPM_Packing;
            this.Ddl_ProductsDescription.SelectedValue = model.PPM_ProductsDescription;
            this.Ddl_Warranty.SelectedValue = model.PPM_Warranty;
            this.Tbx_Price.Text = model.PPM_Price;
            this.Tbx_NeedTime.Text = model.PPM_NeedTime;
            this.Tbx_Application.Text = model.PPM_Application;
            this.Tbx_Remaks.Text = model.PPM_Remaks;
            this.Tbx_Neednumber.Text = model.PPM_Neednumber;
        }
    }

    private bool SetValue(KNet.Model.Pb_Project_Manage model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text == "")
            {
                model.PPM_ID = GetMainID();
                model.PPM_Code = base.GetNewID("Pb_Project_Manage", 1);
            }
            else
            {
                model.PPM_ID = this.Tbx_ID.Text;
                model.PPM_Code = this.Tbx_Code.Text;
            }
            model.PPM_Products = this.Tbx_Products.Text;
            model.PPM_CustomerValue = this.Tbx_CustomerID.Text;
            try
            {
                model.PPM_Stime = DateTime.Parse(this.Tbx_Stime.Text);
            }
            catch { }
            model.PPM_ProductsType = this.Ddl_ProductsType.SelectedValue;
            model.PPM_Model = this.Ddl_Model.SelectedValue;
            model.PPM_SoftNeed = this.Ddl_SoftNeed.SelectedValue;
            model.PPM_KeyCustom = this.Ddl_KeyCustom.SelectedValue;
            model.PPM_Standards = this.Ddl_Standards.SelectedValue;
            model.PPM_OtherRemarks = this.Tbx_OtherRemarks.Text;
            model.PPM_Shape = this.Ddl_Shape.SelectedValue;
            model.PPM_Lamp = this.Ddl_Lamp.SelectedValue;
            model.PPM_Led = this.Ddl_Led.SelectedValue;
            model.PPM_Upper = this.Tbx_Upper.Text;
            model.PPM_Lower = this.Tbx_Lower.Text;
            model.PPM_Battery = this.Tbx_Battery.Text;
            model.PPM_Conductive = this.Tbx_Conductive.Text;
            model.PPM_KeyNumber = this.Tbx_KeyNumber.Text;
            model.PPM_Pot = this.Tbx_Pot.Text;
            model.PPM_Backlight = this.Tbx_Backlight.Text;
            model.PPM_Description = this.Tbx_Description.Text;
            model.PPM_HaveBattery = this.Ddl_HaveBattery.SelectedValue;
            model.PPM_Packing = this.Ddl_Packing.SelectedValue;
            model.PPM_ProductsDescription = this.Ddl_ProductsDescription.SelectedValue;
            model.PPM_Warranty = this.Ddl_Warranty.SelectedValue;
            model.PPM_Price = this.Tbx_Price.Text;
            model.PPM_NeedTime = this.Tbx_NeedTime.Text;
            model.PPM_Application = this.Tbx_Application.Text;
            model.PPM_Remaks = this.Tbx_Remaks.Text;
            model.PPM_CTime = DateTime.Now;
            model.PPM_Creator = AM.KNet_StaffNo;
            model.PPM_Mender = AM.KNet_StaffNo;
            model.PPM_MTime = DateTime.Now;
            model.PPM_Neednumber = this.Tbx_Neednumber.Text;
            return true;
        }
        catch
        {
            return false;
        }

    }
    protected void Btn_Send_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.Model.Pb_Project_Manage model = new KNet.Model.Pb_Project_Manage();
        KNet.BLL.Pb_Project_Manage bll = new KNet.BLL.Pb_Project_Manage();

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
                    AM.Add_Logs("项目修改" + this.Tbx_ID.Text);
                   // base.Base_SendMessage(model.PPM_ID, "项目： <a href='Web/Notice/Pb_Project_Manage_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PBN_Title + "</a> ");
                    AlertAndRedirect("修改成功！", "Pb_Project_Manage_List.aspx");

                }
                else
                {
                    AM.Add_Logs("项目修改失败" + this.Tbx_ID.Text);
                    AlertAndRedirect("修改失败！", "Pb_Project_Manage_Add.aspx?ID=" + this.Tbx_ID.Text + "");
                }
            }
            catch { }
        }
        else
        {

            try
            {
                bll.Add(model);
                //base.Base_SendMessage(model.PPM_ID, "项目： <a href='Web/Notice/Pb_Project_Manage_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PBN_Title + "</a> ");
                AM.Add_Logs("项目增加" + this.Tbx_ID.Text);
                AlertAndRedirect("新增成功！", "Pb_Project_Manage_List.aspx");
            }
            catch { }
        }

    }
}
