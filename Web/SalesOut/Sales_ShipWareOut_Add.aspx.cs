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
using System.Text;
using System.Data.SqlClient;

using KNet.DBUtility;
using KNet.Common;


public partial class Web_Sales_Sales_ShipWareOut_Add : BasePage
{
    public string s_MyTable_Detail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
            AdminloginMess AM = new AdminloginMess();
            //if (AM.KNet_StaffDepart == "129652784259578018")//如果是物流部
            //{
            //}
 
            if (AM.CheckLogin("新增发货出库") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            else
            {
                string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
                this.Tbx_ID.Text = s_ID;
                string s_ShipNo = Request.QueryString["ShipNo"] == null ? "" : Request.QueryString["ShipNo"].ToString();
                base.Base_DropWareHouseBind(this.Ddl_HouseNo,"  KSW_Type='0' ");
                base.Base_DropWareHouseBind(this.Ddl_RkHouseNo, "  KSW_Type='0' ");
                if (s_ID == "")
                {
                    this.Tbx_DirectInNo.Text = this.GetNewID("KNet_WareHouse_DirectOutList", 0);
                }
                base.Base_DropDutyPerson(this.Ddl_DutyPerson);
                base.Base_DropKClaaBind(this.ContractDeliveMethods, 5, "", "请选择交货方式");

                if (s_ShipNo != "")
                {
                    if (s_ShipNo != "")
                    {
                        KNet.BLL.KNet_Sales_OutWareList BLL = new KNet.BLL.KNet_Sales_OutWareList();
                        KNet.Model.KNet_Sales_OutWareList Model = BLL.GetModelB(s_ShipNo);
                        this.Tbx_ContentPerson.Text = base.Base_GetLinkManValue(Model.OutWareSideContact, "XOL_Name") == "" ? Model.KSO_ContentPersonName : base.Base_GetLinkManValue(Model.OutWareSideContact, "XOL_Name");
                        this.Tbx_Address.Text = Model.ContractToAddress;
                        this.Tbx_DirectInDateTime.Text = DateTime.Now.ToShortDateString();
                        this.Tbx_DirectInNo.Text = base.GetNewID("KNet_WareHouse_DirectOutList", 0);
                        this.OutWareNo.Text = s_ShipNo;
                        this.Ddl_DutyPerson.SelectedValue = Model.DutyPerson;
                        this.OutWareOursContact.Text = AM.KNet_StaffName;
                        this.Tbx_ContentPerson.Text = Model.KSO_ContentPersonName;
                        this.ContractDeliveMethods.SelectedValue = Model.ContractDeliveMethods;
                        this.Tbx_TelPhone.Text = Model.KSO_TelPhone;
                        this.Tbx_DirectInRemarks.Text = Model.OutWareRemarks;
                        try
                        {
                            this.Tbx_ReceTime.Text = DateTime.Parse(Model.KSO_PlanOutWareDateTime.ToString()).ToShortDateString();
                        }
                        catch { }
                        this.Tbx_SCustomerValue.Text = Model.KSO_SCustomerValue;
                        this.Tbx_SCustomerName.Text = base.Base_GetCustomerName(Model.KSO_SCustomerValue);
                        this.Tbx_CustomerValue.Text = Model.CustomerValue;
                        this.Tbx_CustomerName.Text = base.Base_GetCustomerName(Model.CustomerValue);
                        //KNet.BLL.KNet_Sales_OutWareList_Details BLL_Details = new KNet.BLL.KNet_Sales_OutWareList_Details();
                        //DataSet Dts_Details = BLL_Details.GetList(" OutWareNo='" + Model.OutWareNo + "'");
                        //if (Dts_Details.Tables[0].Rows.Count > 0)
                        //{
                        //    s_MyTable_Detail += "<tr>";
                        //    for (int i = 0; i < Dts_Details.Tables[0].Rows.Count; i++)
                        //    {
                        //        this.Xs_ProductsCode.Text += Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + ",";
                        //        s_MyTable_Detail += "<td class=\"ListHeadDetails\"><A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a></td>";
                        //        s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                        //        s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ProductsBarCode_" + i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "'>" + Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "</td>";
                        //        s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                        //        s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"input\"  Name=\"Number_" + i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["OutWareAmount"].ToString() + "'></td>";

                        //        s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsPattern(Dts_Details.Tables[0].Rows[i]["KSO_Battery"].ToString()) + "</td>";
                        //        s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetBasicCodeName("134", Dts_Details.Tables[0].Rows[i]["KSO_Manual"].ToString()) + "</td>";
                        //        s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"input\"  Name=\"Remarks_" + i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["OutWareRemarks"].ToString() + "'></td>";
                        //    }
                        //    this.Tbx_Num.Text = Dts_Details.Tables[0].Rows.Count.ToString();

                        //    s_MyTable_Detail += "</tr>";
                        //}

                        //   this.Tbx_DirectInStaffNo.Text = AM.KNet_StaffName;
                    }
                }
                else
                {
                    this.Ddl_RkHouseNo.SelectedValue = "128502353068906250";
                    this.Tbx_CustomerValue.Text = "100751";
                    this.Tbx_CustomerName.Text = "杭州士腾科技有限公司";
                    this.Tbx_SCustomerValue.Text = "100751";
                    this.Tbx_SCustomerName.Text = "杭州士腾科技有限公司";
                    this.Tbx_ContentPerson.Text = "";
                    this.Tbx_ContentPersonID.Text = "";
                    this.Tbx_TelPhone.Text = "";
                    this.Tbx_Address.Text = "";
                    this.ContractDeliveMethods.SelectedValue = "129687525603715469";
                }
                if (s_ID != "")
                {
                    this.DataShow();
                }
                try
                {
                    if (this.Tbx_DirectInDateTime.Text == "")
                    {
                        this.Tbx_DirectInDateTime.Text=DateTime.Now.ToShortDateString();
                    }
                    this.Tbx_CwCode.Text = GetCwCode(DateTime.Parse(this.Tbx_DirectInDateTime.Text));
                }
                catch
                { }
            }
        }

    }
    private void DataShow()
    {
        AdminloginMess AM = new AdminloginMess();
        if (this.Tbx_ID.Text != "")
        {
            KNet.BLL.KNet_WareHouse_DirectOutList bll=new KNet.BLL.KNet_WareHouse_DirectOutList();
            KNet.Model.KNet_WareHouse_DirectOutList model = bll.GetModelB(this.Tbx_ID.Text);

            if (AM.KNet_StaffName != "项洲")
            {
                if (model.DirectOutCheckYN != 0)
                {
                    AlertAndGoBack("已审核不能修改");
                    return;
                }
            }
            this.Tbx_DirectInNo.Text = model.DirectOutNo;
            this.Tbx_ContentPerson.Text = model.KWD_ContentPerson;
            this.Tbx_CustomerValue.Text = model.KWD_Custmoer;
            this.Tbx_CustomerName.Text = base.Base_GetCustomerName(this.Tbx_CustomerName.Text);
            this.Tbx_Address.Text = model.KWD_Address;
            this.Tbx_CustomerName.Text = base.Base_GetCustomerName(model.KWD_Custmoer);
            this.Tbx_DirectInRemarks.Text = model.DirectOutRemarks;
            try
            {
                this.Tbx_DirectInDateTime.Text = DateTime.Parse(model.DirectOutDateTime.ToString()).ToString();
                this.Tbx_ReceTime.Text = DateTime.Parse(model.KWD_ReceTime.ToString()).ToString();
                
            }
            catch { }
            this.Tbx_CwCode.Text = model.KWD_CwCode;
            this.OutWareNo.Text = model.KWD_ShipNo;
            this.OutWareOursContact.Text = AM.KNet_StaffName;
            this.Ddl_HouseNo.SelectedValue = model.HouseNo;
            this.Tbx_TelPhone.Text = model.KWD_Telphone;
            this.Ddl_RkHouseNo.SelectedValue = model.KWD_RkHouseNo;

            KNet.BLL.KNet_WareHouse_DirectOutList_Details Bll_Details = new KNet.BLL.KNet_WareHouse_DirectOutList_Details();
            DataSet Dts_Table = Bll_Details.GetList(" DirectOutNo='" + model.DirectOutNo + "'");
            if (Dts_Table.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                {
                    string s_ID = Dts_Table.Tables[0].Rows[i]["ID"].ToString();
                    string s_FID = Dts_Table.Tables[0].Rows[i]["KWD_OutWareID"].ToString();
                    string s_ProductsBarCode = Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString();
                    string s_ProductsName = base.Base_GetProdutsName(s_ProductsBarCode);
                    string s_ProductsPattern = base.Base_GetProductsPattern(s_ProductsBarCode);
                    string s_ProductsEditon = base.Base_GetProductsEdition(s_ProductsBarCode);
                    s_MyTable_Detail += " <tr>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a></td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"FID_" + i.ToString() + "\" value='" + s_ID + "'><input type=\"hidden\"  Name=\"ID_" + i.ToString() + "\" value='" + s_FID + "'><input type=\"hidden\"  Name=\"ProductsBarCode_" + i.ToString() + "\" value='" + s_ProductsBarCode + "'>" + s_ProductsName + "&nbsp;</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + s_ProductsBarCode + "&nbsp;</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ProductsName_" + i.ToString() + "\" value='" + s_ProductsName + "'>" + s_ProductsPattern + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + s_ProductsEditon + "&nbsp;</td>";

                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\" Name=\"Number_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["DirectOutAmount"].ToString() + "></td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\" Name=\"BNumber_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["KWD_BNumber"].ToString() + " ></td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\"   Name=\"PlanNo_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["PlanNo"].ToString() + " ></td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\"   Name=\"OrderNo_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["OrderNo"].ToString() + " ></td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\"   Name=\"MaterNo_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["MaterNo"].ToString() + " ></td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\"   Name=\"CustomerProductsName_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["CustomerProductsName"].ToString() + " ></td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\"   Name=\"IsFollow_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["KWD_IsFollow"].ToString() + " ></td>";
                    s_MyTable_Detail += " <td><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\"  Name=\"Remarks_" + i.ToString() + "\"  Text=\"" + Dts_Table.Tables[0].Rows[i]["DirectOutRemarks"].ToString() + "\" ></td>";
                    s_MyTable_Detail += " </tr>";

                        this.Xs_ProductsCode.Text += Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString() + ",";
                }
                this.Tbx_Num.Text = Dts_Table.Tables[0].Rows.Count.ToString();
            }
            //this.Ddl_DutyPerson.SelectedValue=
        }
    }
    private bool SetValue(KNet.Model.KNet_WareHouse_DirectOutList molel )
    {
        try
        {
            string DirectInNo = "";
            if (this.Tbx_ID.Text == "")
            {

                 DirectInNo = this.GetNewID("KNet_WareHouse_DirectOutList", 1);
            }
            else
            {
                 DirectInNo = this.Tbx_ID.Text;
 
            }

            DateTime DirectInDateTime = DateTime.Now;
            try
            {
                DirectInDateTime = DateTime.Parse(this.Tbx_DirectInDateTime.Text.Trim());
            }
            catch { }
            AdminloginMess Am = new AdminloginMess();

            string HouseNo = KNetPage.KHtmlEncode(this.Ddl_HouseNo.SelectedValue);
            string DirectInCheckStaffNo = "";

            string DirectInRemarks = KNetPage.KHtmlEncode(this.Tbx_DirectInRemarks.Text.Trim());
            

            molel.DirectOutNo = DirectInNo;
            molel.DirectOutTopic = "";
            molel.DirectOutDateTime = DirectInDateTime;
            molel.KWD_CWOutTime = DirectInDateTime;
            molel.HouseNo = HouseNo;
            molel.DirectOutStaffNo = Am.KNet_StaffNo;
            molel.DirectOutCheckStaffNo = DirectInCheckStaffNo;
            molel.DirectOutRemarks = DirectInRemarks;
            molel.DirectOutCheckYN = 0;
            molel.KWD_Address = this.Tbx_Address.Text;
            molel.KWD_ContentPerson = this.Tbx_ContentPerson.Text;
            molel.KWD_Custmoer = this.Tbx_CustomerValue.Text;
            molel.KWD_Del = "0";
            molel.KWD_Type = "101";
            molel.KWD_State = "";
            molel.KWD_Telphone = this.Tbx_TelPhone.Text;
            molel.KWD_ShipNo = this.OutWareNo.Text;
            molel.KWD_CwCode = GetCwCode(DirectInDateTime);
            molel.KWD_SCustomerValue = this.Tbx_SCustomerValue.Text;
            molel.KWD_ContractDeliveMethods = this.ContractDeliveMethods.SelectedValue;
            try
            {
                molel.KWD_ReceTime = DateTime.Parse(this.Tbx_ReceTime.Text);
            }
            catch
            { }

            molel.KWD_RkHouseNo = this.Ddl_RkHouseNo.SelectedValue;
            ArrayList Arr_Details = new ArrayList();

            int i_num = int.Parse(this.Tbx_Num.Text);
            for (int i = 0; i < i_num; i++)
            {
                KNet.Model.KNet_WareHouse_DirectOutList_Details ModelDetails = new KNet.Model.KNet_WareHouse_DirectOutList_Details();
                if (Request["ProductsBarCode_" + i] != null)
                {
                    string s_ID = Request["ID_" + i] == null ? "" : Request["ID_" + i].ToString();
                    string s_ProductsBarCode = Request["ProductsBarCode_" + i] == null ? "" : Request["ProductsBarCode_" + i].ToString();
                    string s_Number = Request["Number_" + i] == null ? "" : Request["Number_" + i].ToString();
                    string s_BNumber = Request["BNumber_" + i] == null ? "" : Request["BNumber_" + i].ToString();
                    string s_Remarks = Request["Remarks_" + i] == null ? "" : Request["Remarks_" + i].ToString();
                    string s_RustomerProductsName = Request["CustomerProductsName_" + i] == null ? "" : Request["CustomerProductsName_" + i].ToString();
                    string s_PlanNo = Request["PlanNo_" + i] == null ? "" : Request["PlanNo_" + i].ToString();
                    string s_OrderNo = Request["OrderNo_" + i] == null ? "" : Request["OrderNo_" + i].ToString();
                    string s_MaterNo = Request["MaterNo_" + i] == null ? "" : Request["MaterNo_" + i].ToString();
                    string s_IsFollow = Request["IsFollow_" + i] == null ? "" : Request["IsFollow_" + i].ToString();

                    ModelDetails.ProductsBarCode = s_ProductsBarCode;
                    ModelDetails.DirectOutAmount = int.Parse(s_Number);
                    ModelDetails.DirectOutRemarks = s_Remarks;
                    ModelDetails.KWD_OutWareID = s_ID;
                    ModelDetails.CustomerProductsName = s_RustomerProductsName;
                    ModelDetails.PlanNo = s_PlanNo;
                    ModelDetails.OrderNo = s_OrderNo;
                    ModelDetails.MaterNo = s_MaterNo;
                    ModelDetails.KWD_IsFollow = s_IsFollow;
                    if (base.FormatNumber(s_BNumber, 0) == "-")
                    {
                        ModelDetails.KWD_BNumber = 0;
                    }
                    else
                    {
                        try
                        {
                            ModelDetails.KWD_BNumber = int.Parse(s_BNumber, 0);
                        }
                        catch
                        {
                            ModelDetails.KWD_BNumber = int.Parse(base.FormatNumber(s_BNumber, 0));
                        }
                    }
                    //出库单价
                    ModelDetails.DirectOutUnitPrice = decimal.Parse(base.Base_GetProductsPrice(s_ProductsBarCode, HouseNo));
                    ModelDetails.DirectOutTotalNet = ModelDetails.DirectOutAmount * ModelDetails.DirectOutUnitPrice;
                    try
                    {
                        //销售出库单价
                        KNet.BLL.KNet_Sales_OutWareList_Details Bll_OutWare = new KNet.BLL.KNet_Sales_OutWareList_Details();
                        KNet.Model.KNet_Sales_OutWareList_Details Model_OutWare = Bll_OutWare.GetModelB(this.OutWareNo.Text, s_ProductsBarCode);
                        ModelDetails.KWD_SalesUnitPrice = Model_OutWare.OutWare_SalesUnitPrice;
                        ModelDetails.KWD_SalesTotalNet = ModelDetails.DirectOutAmount * Model_OutWare.OutWare_SalesUnitPrice;
                    }
                    catch
                    {
                        ModelDetails.KWD_SalesUnitPrice = 0;
                        ModelDetails.KWD_SalesTotalNet = 0;
                    }
                    Arr_Details.Add(ModelDetails);
                }
            }
            molel.Arr_Details = Arr_Details;
            return true;
        }
        catch
        {
            return false;
        }
    }

    protected void Btn_SaveOnClick(object sender, EventArgs e)
    {

        KNet.BLL.KNet_WareHouse_DirectOutList BLL = new KNet.BLL.KNet_WareHouse_DirectOutList();
        try
        {
            KNet.Model.KNet_WareHouse_DirectOutList molel = new KNet.Model.KNet_WareHouse_DirectOutList();

            if (this.SetValue(molel) == false)
            {
                Alert("系统错误！");
                return;
            }

            if (this.Tbx_ID.Text == "")
            {
                if (BLL.Exists(this.Tbx_ID.Text) == false)
                {
                    BLL.Add(molel);
                    string JSD = "SalesOut/Sales_ShipWareOut_Print.aspx?ID="+molel.KWD_ShipNo+"&DID=" + molel.DirectOutNo + "";
                    base.HtmlToPdf1(JSD, Server.MapPath("PDF"), molel.DirectOutNo);
                    AdminloginMess LogAM = new AdminloginMess();
                    LogAM.Add_Logs("销售管理--->发货出库管理--->出库开单 添加 操作成功！出库单号：" + this.Tbx_ID.Text);

                    Response.Write("<script>alert('发货出库开单 添加  操作成功！');location.href='Sales_ShipWareOut_Manage.aspx';</script>");
                    Response.End();
                }
                else
                {
                    Response.Write("<script>alert('发货出库单号已存在 添加失败！');history.back(-1);</script>");
                    Response.End();
                }
            }
            else
            {
                BLL.Update(molel);

                string JSD = "SalesOut/Sales_ShipWareOut_Print.aspx?ID=" + molel.KWD_ShipNo + "&DID=" + molel.DirectOutNo + "";
                base.HtmlToPdf1(JSD, Server.MapPath("PDF"), molel.DirectOutNo);
                AdminloginMess LogAM = new AdminloginMess();
                LogAM.Add_Logs("销售管理--->修改发货出库 操作成功！订单编号：" + this.Tbx_ID.Text);
                Response.Write("<script>alert('修改发货出库  操作成功 ！');location.href='Sales_ShipWareOut_Manage.aspx';</script>");
                Response.End();

            }

        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('发货出库开单添加失败！');history.back(-1);</script>");
            Response.End();
        }

    }
    public string GetCwCode(DateTime d_DateTime)
    {
        string s_Code = "";
        try
        {
            KNet.BLL.KNet_WareHouse_DirectOutList BLL = new KNet.BLL.KNet_WareHouse_DirectOutList();
            this.BeginQuery("Select Max(isNUll(KWD_CwCode,'')) from KNet_WareHouse_DirectOutList Where year(DirectOutDateTime)='" + d_DateTime.Year.ToString() + "'  and Month(DirectOutDateTime)='" + d_DateTime.Month.ToString() + "'");
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                if(Dtb_Table.Rows[0][0].ToString()!="")
                {
                    s_Code =Dtb_Table.Rows[0][0].ToString().Substring(0, 6)+"-"+Convert.ToString(int.Parse("1"+Dtb_Table.Rows[0][0].ToString().Substring(7, 3))+1).Substring(1,3);
                }
            }
            else
            {
                s_Code = DateTime.Today.ToString("yyyyMM") + "-001";
            }
        }
        catch { }
        return s_Code;
    }
}
