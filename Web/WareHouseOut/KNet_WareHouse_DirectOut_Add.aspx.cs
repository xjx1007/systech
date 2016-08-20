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


/// <summary>
/// 库存管理-----直接开入库单
/// </summary>
public partial class Knet_Web_WareHouse_KNet_WareHouse_DirectOut_Add : BasePage
{
    public string s_MyTable_Detail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
                string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
                string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
                this.Tbx_Type.Text = s_Type;
                string s_Sql = "1=1";
                this.DirectInDateTime.Text = DateTime.Now.ToShortDateString();
                this.Lbl_Title.Text = "新增直接出库";
                if (s_ID != "")
                {
                    if (s_Type == "1")
                    {
                        this.Tbx_ID.Text = "";
                        this.Lbl_Title.Text = "复制直接出库";
                        this.DirectInNo.Text = "FXCK" + base.GetNewID("KNet_WareHouse_DirectOut", 0);
                    }
                    else
                    {
                        this.Lbl_Title.Text = "修改直接出库";
                        this.Tbx_ID.Text = s_ID;
                        this.DirectInNo.Text = s_ID;
                    }
                    this.Btn_Save.Text = "保存";
                }
                else
                {
                    if (s_Type == "2")
                    {
                        s_Sql = "  HouseName like '%修%' ";
                        this.DirectInNo.Text = "FXCK" +  base.GetNewID("KNet_WareHouse_DirectOut",0);
                    }
                    else
                    {
                        s_Sql = "  HouseName not like '%修%' ";
                        this.DirectInNo.Text = "CK" + base.GetNewID("KNet_WareHouse_DirectOut",0);
                    }
                }
                base.Base_DropWareHouseBind(this.HouseNo, s_Sql);
                if (s_ID != "")
                {
                    ShowInfo(s_ID);
                }

                if (s_Type != "")
                {
                    this.Lbl_Title.Text = this.Lbl_Title.Text.Replace("直接", "售后");
                }
                if (s_Type == "Ly")
                {
                    this.Lbl_Title.Text = "新增领用单";

                    this.BeginQuery("select HouseNo,HouseName FROM KNet_Sys_WareHouse  where HouseYN=1 and KSW_Type='1' union all select SuppNo,KPS_SName from Knet_Procure_Suppliers where KPS_Type='128860698200781250' ");
                    this.QueryForDataSet();
                    this.HouseNo.DataSource = Dts_Result;
                    HouseNo.DataTextField = "HouseName";
                    HouseNo.DataValueField = "HouseNo";
                    HouseNo.DataBind();
                    ListItem item = new ListItem("请选择仓库", ""); //默认值
                    HouseNo.Items.Insert(0, item);
                    this.DirectInNo.Text = "Ly" + base.GetNewID("KNet_WareHouse_DirectOut", 0);
                }
                if (AM.CheckLogin(this.Lbl_Title.Text) == false)
                {
                    Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                    Response.End();
                }
            
        }
    }


    private void ShowInfo(string s_ID)
    {
        KNet.BLL.KNet_WareHouse_DirectOutList bll = new KNet.BLL.KNet_WareHouse_DirectOutList();
        KNet.Model.KNet_WareHouse_DirectOutList model = bll.GetModelB(s_ID);

        if (model.DirectOutCheckYN == 3)
        {
            AlertAndGoBack("不能修改！");
            return;
        }
        if (model.KWD_Type == "105")
        {
            base.Base_DropWareHouseBindCw(this.HouseNo);
        }
        this.DirectInDateTime.Text = DateTime.Parse(model.DirectOutDateTime.ToString()).ToShortDateString();
        this.HouseNo.SelectedValue = model.HouseNo;
        this.CustomerValue.Value = model.KWD_Custmoer;
        this.CustomerValueName.Text = base.Base_GetCustomerName(model.KWD_Custmoer);
        base.Base_DropLinkManBind(this.Ddl_DutyPerson, model.KWD_Custmoer);
        this.Ddl_DutyPerson.SelectedValue = model.KWD_ContentPerson;
        this.Remarks.Text = model.DirectOutRemarks;
        KNet.BLL.KNet_WareHouse_DirectOutList_Details BLL_Details = new KNet.BLL.KNet_WareHouse_DirectOutList_Details();
        DataSet Dts_Details = BLL_Details.GetList(" DirectOutNo='" + s_ID + "'");
        this.Tbx_Type.Text = model.KWD_Type;
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
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Number_" + i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["DirectOutAmount"].ToString() + "'></td>";

                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Price_" + i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["DirectOutUnitPrice"].ToString() + "'></td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Remarks_" + i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["DirectOutRemarks"].ToString() + "'></td>";
                s_MyTable_Detail += "</tr>";
            }
            this.Tbx_Num.Text = Dts_Details.Tables[0].Rows.Count.ToString();
        }

    }

    private bool SetValue(KNet.Model.KNet_WareHouse_DirectOutList  molel)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {

            string DirectInNo = KNetPage.KHtmlEncode(this.DirectInNo.Text.Trim());
            string DirectInTopic = KNetPage.KHtmlEncode("");
            //string DirectInSource = KNetPage.KHtmlEncode(this.DirectInSource.Text.Trim());

            DateTime DirectInDateTime = DateTime.Now;
            try
            {
                DirectInDateTime = DateTime.Parse(this.DirectInDateTime.Text.Trim());
            }
            catch { }

            //string SuppNo = KNetPage.KHtmlEncode(this.SuppNoSelectValue.Value);

            string HouseNo = KNetPage.KHtmlEncode(this.HouseNo.SelectedValue);
            string DirectInStaffNo = AM.KNet_StaffNo;

            string DirectInCheckStaffNo = "";
            string DirectInRemarks = KNetPage.KHtmlEncode(this.Remarks.Text.Trim());



            molel.DirectOutNo = DirectInNo;
            molel.DirectOutTopic = DirectInTopic;
            // molel.DirectInSource = DirectInSource;

            molel.DirectOutDateTime = DirectInDateTime;
            molel.KWD_CWOutTime = DirectInDateTime;
            //   molel. = SuppNo;
            molel.HouseNo = HouseNo;

            molel.DirectOutStaffNo = DirectInStaffNo;
            molel.DirectOutCheckStaffNo = DirectInCheckStaffNo;
            molel.DirectOutRemarks = DirectInRemarks;
            molel.KWD_ContentPerson = Request["Ddl_DutyPerson"]==null?"":Request["Ddl_DutyPerson"].ToString();
            molel.KWD_Custmoer = this.CustomerValue.Value;
            molel.DirectOutCheckYN = 0;
            molel.KWD_Del = "0";
            molel.KWD_ReceTime = DirectInDateTime;

            if (this.Tbx_Type.Text == "2")
            {
                molel.KWD_Type = "103";
            }
            else if (this.Tbx_Type.Text == "3")
            {
                molel.KWD_Type = "104";
            }
            else if (this.Tbx_Type.Text == "Ly")
            {
                molel.KWD_Type = "105";
            }
            else
            {
                molel.KWD_Type = "102";
            }


            ArrayList Arr_Products = new ArrayList();
            for (int i = 0; i <= int.Parse(this.Tbx_Num.Text); i++)
            {
                if (Request["ProductsBarCode_" + i.ToString()] != null)
                {
                    string s_ProductsBarCode = Request.Form["ProductsBarCode_" + i.ToString()].ToString();
                    string s_Number = Request.Form["Number_" + i.ToString()].ToString();
                    string s_Price = Request.Form["Price_" + i.ToString()].ToString();
                    string s_Remarks = Request.Form["Remarks_" + i.ToString()].ToString();
                    KNet.Model.KNet_WareHouse_DirectOutList_Details Model_Details = new KNet.Model.KNet_WareHouse_DirectOutList_Details();
                    Model_Details.ID = GetNewID("KNet_WareHouse_AllocateList_Details", 1);
                    Model_Details.ProductsBarCode = s_ProductsBarCode;
                    Model_Details.DirectOutNo = molel.DirectOutNo;
                    Model_Details.DirectOutAmount = int.Parse(s_Number);
                    Model_Details.DirectOutUnitPrice = decimal.Parse(s_Price);
                    Model_Details.DirectOutTotalNet = decimal.Parse(s_Number) * decimal.Parse(s_Price);
                    Model_Details.DirectOutRemarks = s_Remarks;
                    Arr_Products.Add(Model_Details);
                    molel.Arr_Details = Arr_Products;
                }
            }
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    /// <summary>
    /// 确定开收货单
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Btn_SaveOnClick(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.BLL.KNet_WareHouse_DirectOutList BLL = new KNet.BLL.KNet_WareHouse_DirectOutList();
        KNet.Model.KNet_WareHouse_DirectOutList Model = new KNet.Model.KNet_WareHouse_DirectOutList();

        string s_ID = this.Tbx_ID.Text;
        AdminloginMess LogAM = new AdminloginMess();
         if (this.SetValue(Model) == false)
        {
            Alert("系统错误！");
            return;
        }
        try
        {
            if (s_ID == "")//新增
            {

                base.GetNewID("KNet_WareHouse_DirectOut", 1);
                if (BLL.Exists(s_ID) == false)
                {
                    BLL.Add(Model);
                    LogAM.Add_Logs("库存管理--->直接出库管理--->出库开单 添加 操作成功！出库单号：" + DirectInNo);
                    AlertAndRedirect("新增成功！", "KNet_WareHouse_DirectOut_Manage.aspx?Type=" + this.Tbx_Type.Text + "");
                }
                else
                {
                    Response.Write("<script>alert('直接出库单号已存在 添加失败！');history.back(-1);</script>");
                    Response.End();
                }
            }
            else
            {
                try
                {
                    Model.KWD_Type = this.Tbx_Type.Text;
                    BLL.Update(Model);
                    LogAM.Add_Logs("库存管理--->直接出库管理--->出库开单 添加 操作成功！出库单号：" + DirectInNo);
                    AlertAndRedirect("修改成功！", "KNet_WareHouse_DirectOut_Manage.aspx?Type=" + this.Tbx_Type.Text + "");
                }
                catch (Exception ex) { }
 
            }
        }
        catch(Exception ex)
        {
            Response.Write("<script>alert('直接出库开单添加失败！');history.back(-1);</script>");
            Response.End();
        }
    }
}
