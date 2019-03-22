using KNet.Common;
using KNet.DBUtility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KNet.Model;

public partial class Web_Products_Knet_Sampling_OpenBilling : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string SamlingID = Request.QueryString["SamlingID"] == null
                ? ""
                : Request.QueryString["SamlingID"].ToString();
            //string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            this.SamplingID.Text = SamlingID;
            this.TextBox1.Text = s_GetCode();
            OrderDateTime.Text = DateTime.Now.ToString();
            base.Base_DropWareHouseBind(this.Ddl_HouseNo, "  KSW_Type=0 ");
        }
    }

    private string s_GetCode()
    {
        string s_Return = "";
        try
        {

            s_Return += "W" + "-" + string.Format("{0:yyyyMMddHHmmss}", DateTime.Now);


        }
        catch (Exception ex)
        {
            s_Return = "-";
        }
        return s_Return;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        string OrderTopic1 = KNetPage.KHtmlEncode("");
        Knet_Sampling_OpenBilling modeBilling = new Knet_Sampling_OpenBilling();
        KNet.BLL.Knet_Sampling_OpenBilling BLLBilling = new KNet.BLL.Knet_Sampling_OpenBilling();
        this.BeginQuery("select top 1 ProjectGroup from KNet_Sampling_List where ID='" + this.SamplingID.Text + "'");
        this.QueryForDataTable();
        DataTable Dtb_Re = Dtb_Result;
        string s_ProjectGroup = "";
        if (Dtb_Re.Rows.Count > 0)
        {
            s_ProjectGroup = Dtb_Re.Rows[0][0].ToString();
        }

        ArrayList Arr_Products = new ArrayList();
        int i_Num = int.Parse(this.Tbx_Num.Text);
        try
        {
            for (int i = 0; i < i_Num; i++)
            {
                if (Request.Form["ProductsBarCode_" + i] != null)
                {
                    string s_ProductsBarCode = Request.Form["ProductsBarCode_" + i];
                    string s_ProductsName = Request.Form["ProductsName_" + i];

                    string s_Number = Request.Form["Number_" + i];
                    string s_Price = Request.Form["Price_" + i];
                    string s_Money = Request.Form["Money_" + i];
                    string Supp = this.SuppNoSelectValue.Value;

                    string s_Remarks = Request.Form["Remarks_" + i];
                    modeBilling.Supplier = Supp;
                    modeBilling.Proposer = AM.KNet_StaffNo;
                    modeBilling.SamplingName = s_ProductsName;

                    modeBilling.Number = Convert.ToInt32(s_Number);
                    modeBilling.Price = decimal.Parse(s_Price);
                    modeBilling.ID = this.TextBox1.Text;
                    modeBilling.YID = this.SamplingID.Text;
                    modeBilling.ReID = s_ProductsBarCode;
                    modeBilling.HouseNo = Ddl_HouseNo.SelectedValue;
                    modeBilling.STime = DateTime.Parse(OrderDateTime.Text);
                    modeBilling.Remark = s_Remarks.ToString();
                    modeBilling.RState = "0";
                    modeBilling.Department = s_ProjectGroup;
                    //if (s_Number != "0")
                    //{
                    //    Arr_Products.Add(modeBilling);
                    //}
                    BLLBilling.Add1(modeBilling);
                }


            }
            AlertAndRedirect("请购入库开单 添加  操作成功", "KNet_InHouse_SamplingList.aspx");
        }
        catch (Exception ex)
        {
            AlertAndRedirect("请购入库开单 添加  操作失败", "KNet_InHouse_SamplingList.aspx");
            //throw;
        }
        
      
       // modeBilling.Arr_ProductsList = Arr_Products;


        //string s_ID = this.Tbx_ID.Text;
        //try
        //{

        //    if (s_ID == "") //新增
        //    {
        //        BLLBilling.Add1(modeBilling);
        //        AlertAndRedirect("请购入库开单 添加  操作成功", "KNet_InHouse_SamplingList.aspx");
        //    }
        //}
        //catch (Exception ex)
        //{
        //    //throw ex;
        //    //Response.Write("<script>alert('请购入库失败！');history.back(-1);</script>");
        //    //Response.End();
        //    //ShowInfo(this.Tbx_ID.Text);
        //}
    }
}