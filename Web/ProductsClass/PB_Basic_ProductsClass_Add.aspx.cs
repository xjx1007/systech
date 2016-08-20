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


public partial class PB_Basic_ProductsClass_Add : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();

            KNet.BLL.PB_Basic_ProductsClass bll = new KNet.BLL.PB_Basic_ProductsClass();
        
            if (s_ID != "")
            {
                KNet.Model.PB_Basic_ProductsClass Model = bll.GetModel(s_ID);
                if (s_Type != "M")
                {
                    this.Tbx_FaterID.Text = s_ID;
                    this.Tbx_FaterName.Text = bll.GetProductsName(s_ID);
                    this.Tbx_Code.Text = bll.GetMaxCode(s_ID);
                    this.Tbx_Order.Text = bll.GetMaxOrder(s_ID);
                }
                else
                {
                    this.Tbx_FaterID.Text = Model.PBP_FaterID;
                    this.Tbx_FaterName.Text = bll.GetProductsName(Model.PBP_FaterID);
                    this.Tbx_Code.Text = Model.PBP_Code;
                    this.Tbx_Order.Text = Model.PBP_Order;
                    this.Tbx_Name.Text = Model.PBP_Name;
                    this.Tbx_ID.Text = s_ID;
                    this.Tbx_Days.Text = Model.PBP_Days.ToString();
                    this.Tbx_OrderDays.Text = Model.PBP_OrderDays.ToString();
                    
                }
            }
        }
    }

    private void ShowInfo(string s_ID,string s_Code)
    {
        KNet.BLL.PB_Basic_ProductsClass bll = new KNet.BLL.PB_Basic_ProductsClass();

    }
    private bool SetValue(KNet.Model.PB_Basic_ProductsClass model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text != "")
            {
                model.PBP_ID = this.Tbx_ID.Text;
            }
            else
            {
                model.PBP_ID = GetMainID();
            }
            model.PBP_Code = this.Tbx_Code.Text;
            model.PBP_FaterID = this.Tbx_FaterID.Text;
            model.PBP_Name = this.Tbx_Name.Text;
            model.PBP_Order = this.Tbx_Order.Text;
            model.PBP_Creator = AM.KNet_StaffNo;
            model.PBP_CTime = DateTime.Now;
            model.PBP_Mender = AM.KNet_StaffNo;
            model.PBP_MTime = DateTime.Now;
            string s_Days=this.Tbx_Days.Text==""?"0":this.Tbx_Days.Text;
            model.PBP_Days = int.Parse(s_Days);
            string s_OrderDays = this.Tbx_Days.Text == "" ? "0" : this.Tbx_OrderDays.Text;
            model.PBP_OrderDays = int.Parse(s_OrderDays);
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
        KNet.Model.PB_Basic_ProductsClass model = new KNet.Model.PB_Basic_ProductsClass();
        KNet.BLL.PB_Basic_ProductsClass bll = new KNet.BLL.PB_Basic_ProductsClass();

        if (this.SetValue(model) == false)
        {
            Alert("系统错误！");
            return;
        }
        if (this.Tbx_ID.Text != "")//修改
        {
            try
            {
                bll.Update(model);
                AM.Add_Logs("付款计划修改" );
                AlertAndRedirect("修改成功！", "PB_Basic_ProductsClass_List.aspx");
            }
            catch { }
        }
        else
        {

            try
            {
                bll.Add(model);
                AM.Add_Logs("付款计划增加");
                AlertAndRedirect("新增成功！", "PB_Basic_ProductsClass_List.aspx");
            }
            catch { }
        }
    }
}
