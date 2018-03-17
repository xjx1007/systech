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



public partial class Web_WareHouseCheck_KNet_WareHouse_WareCheck_Add : BasePage
{
    public string s_MyTable_Detail = "", s_DType="";
    protected void Page_Load(object sender, EventArgs e)
    {
        string s_OrderNo = Request.QueryString["OrderNo"] == null ? "" : Request.QueryString["OrderNo"].ToString();
        if (!Page.IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            s_DType = Request.QueryString["DType"] == null ? "" : Request.QueryString["DType"].ToString();
           
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            this.ReceivDateTime.Text = DateTime.Now.ToShortDateString();
            if (s_DType == "1")
            {
                this.BeginQuery("select HouseNo,HouseName FROM KNet_Sys_WareHouse  where HouseYN=1 and KSW_Type='1' union all select SuppNo,KPS_SName from Knet_Procure_Suppliers where KPS_Type='128860698200781250' ");
                this.QueryForDataSet();
                this.HouseNo.DataSource = Dts_Result;
                HouseNo.DataTextField = "HouseName";
                HouseNo.DataValueField = "HouseNo";
                HouseNo.DataBind();
                ListItem item = new ListItem("请选择仓库", ""); //默认值
                HouseNo.Items.Insert(0, item);
            }
            else
            {

                base.Base_DropWareHouseBind(this.HouseNo, " 1=1 ");
            }
            if (s_ID != "")
            {
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制盘点单";
                    this.ReceivNo.Text = s_GetCode();
                }
                else
                {
                    this.Lbl_Title.Text = "修改盘点单";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }
            else
            {
                this.Lbl_Title.Text = "新增盘点单";
                this.ReceivNo.Text = s_GetCode();
            }
            // base.Base_DropLinkManBind(this.Ddl_LinkMan, this.Tbx_CustomerValue.Value);
        }
    }

    private void ShowInfo(string s_ID)
    {
        KNet.BLL.KNet_WareHouse_WareCheckList bll = new KNet.BLL.KNet_WareHouse_WareCheckList();
        KNet.Model.KNet_WareHouse_WareCheckList model = bll.GetModelB(s_ID);
        this.ReceivNo.Text = model.WareCheckNo;
        this.ReceivDateTime.Text = DateTime.Parse(model.WareCheckDateTime.ToString()).ToShortDateString();
        this.HouseNo.SelectedValue = model.HouseNo;
        this.ReceivRemarks.Text = model.WareCheckRemarks;

        KNet.BLL.KNet_WareHouse_WareCheckList_Details bll_Details = new KNet.BLL.KNet_WareHouse_WareCheckList_Details();
        DataSet Dts_Details = bll_Details.GetList(" WareCheckNo='" + s_ID + "' order by KSP_Code");
        if (Dts_Details.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < Dts_Details.Tables[0].Rows.Count; i++)
            {
                s_MyTable_Detail += "<tr>";

                this.Xs_ProductsCode.Text += Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + ",";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a></td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ProductsBarCode_" + i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "'>" + Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Number_" + i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["WareCheckAmount"].ToString() + "'></td>";

                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"ZNumber_" + i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["WareCheckAmount"].ToString() + "'></td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"DNumber_" + i.ToString() + "\" value='0'></td>";

                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Price_" + i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["WareCheckUnitPrice"].ToString() + "'></td>";

                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Money_" + i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["WareCheckTotalNet"].ToString() + "'></td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Remarks_" + i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["WareCheckRemarks"].ToString() + "'></td>";
                s_MyTable_Detail += "</tr>";
            }
            this.Tbx_Num.Text = Dts_Details.Tables[0].Rows.Count.ToString();
        }

    }
    private bool SetValue(KNet.Model.KNet_WareHouse_WareCheckList model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            model.WareCheckNo = this.ReceivNo.Text;
            model.HouseNo = this.HouseNo.SelectedValue;
            model.WareCheckDateTime = DateTime.Parse(ReceivDateTime.Text);
            model.WareCheckStaffNo = AM.KNet_StaffNo;
            ArrayList Arr_Products = new ArrayList();
            int i_Num=int.Parse(this.Tbx_Num.Text);
            for (int i = 0; i < i_Num; i++)
            {
                string s_ProductsBarCode = Request.Form["ProductsBarCode_" + i.ToString() + ""] == null ? "" : Request.Form["ProductsBarCode_" + i.ToString() + ""].ToString();
                if (s_ProductsBarCode != "")
                {
                    string s_Number = Request.Form["Number_" + i.ToString() + ""];
                    string s_ZNumber = Request.Form["ZNumber_" + i.ToString() + ""];
                    string s_Price = Request.Form["Price_" + i.ToString() + ""];
                    string s_Money = Request.Form["Money_" + i.ToString() + ""];
                    string s_Remarks = Request.Form["Remarks_" + i.ToString() + ""];
                    KNet.Model.KNet_WareHouse_WareCheckList_Details Model_Details = new KNet.Model.KNet_WareHouse_WareCheckList_Details();
                    Model_Details.ProductsBarCode = s_ProductsBarCode;
                    decimal d_ZPrice=decimal.Parse(base.Base_GetProductsPrice(s_ProductsBarCode,this.HouseNo.SelectedValue));
                   
                    Model_Details.WareCheckAmount = int.Parse(Convert.ToString(decimal.Parse(s_Number) - decimal.Parse(s_ZNumber)));
                    Model_Details.WareCheckTotalNet = decimal.Parse(s_Money);
                    try{
                        Model_Details.WareCheckUnitPrice = decimal.Parse(FormatNumber(Convert.ToString(Model_Details.WareCheckTotalNet / Model_Details.WareCheckAmount),3));
                    }
                    catch 
                    { 
                        Model_Details.WareCheckUnitPrice = 0 ;
                    }
                    Model_Details.WareCheckRemarks = s_Remarks;
                    Model_Details.WareCheckNo = model.WareCheckNo;
                    Arr_Products.Add(Model_Details);
                }
            }
            model.arr_Details = Arr_Products;
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    protected void Btn_SaveOnClick(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        string s_ID = this.Tbx_ID.Text;

        KNet.Model.KNet_WareHouse_WareCheckList model = new KNet.Model.KNet_WareHouse_WareCheckList();
        KNet.BLL.KNet_WareHouse_WareCheckList bll = new KNet.BLL.KNet_WareHouse_WareCheckList();

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
                AM.Add_Logs("盘点单增加" + this.Tbx_ID.Text);
                AlertAndRedirect("新增成功！", "KNet_WareHouse_WareCheck_Manage.aspx");
            }
            catch (Exception ex) { }
        }
        else
        {

            try
            {
                bll.Update(model);
                AM.Add_Logs("盘点单修改" + this.Tbx_ID.Text);
                AlertAndRedirect("修改成功！", "KNet_WareHouse_WareCheck_Manage.aspx");

            }
            catch (Exception ex) { }
        }
    }

    private string s_GetCode()
    {
        string s_Return = "";
        try
        {
            KNet.BLL.KNet_WareHouse_WareCheckList Bll = new KNet.BLL.KNet_WareHouse_WareCheckList();

            string S_Code = Bll.GetLastCode();
            if (S_Code == "")
            {

                s_Return += "P" + DateTime.Today.ToString("yyyyMMdd") + "-" + "001";
            }
            else
            {
                S_Code = "1" + S_Code.Substring(10, 3);
                decimal d_NewCode = decimal.Parse(S_Code) + 1;
                s_Return += "P" + DateTime.Today.ToString("yyyyMMdd") + "-" + d_NewCode.ToString().Substring(1, d_NewCode.ToString().Length - 1);
            }
        }
        catch (Exception ex)
        {
            s_Return = "-";
        }
        return s_Return;
    }
}