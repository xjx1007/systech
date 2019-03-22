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


public partial class Web_Sales_Sales_ShipWareOut_Add : BasePage
{
    public string s_MyTable_Detail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(Web_Sales_Sales_ShipWareOut_Add));
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
                string s_IsFreight = Request.QueryString["IsFreight"] == null ? "" : Request.QueryString["IsFreight"].ToString();
                this.Tbx_Freight.Text = s_IsFreight;
                string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
                string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
                this.Tbx_Type.Text = s_Type;
                if (s_IsFreight != "")
                {
                    this.Pan_DirectOut.Enabled = false;

                    this.Button_Select.Visible = false;
                }
                else
                {
                    this.Pan_DirectOut.Enabled = true;
                    this.Button_Select.Visible = true;
                }
                if (this.Tbx_Type.Text == "1")
                {
                    //编辑付款方式
                    this.Pan_Wuliu.Visible = false;
                    this.Panel1.Enabled = false;
                    this.Panel2.Enabled = false;
                }
                this.Tbx_ID.Text = s_ID;
                this.Tbx_WuliuCode.Text = base.GetNewID("XSF_Code", 0);
                this.Tbx_WuliuStime.Text = DateTime.Now.ToShortDateString();

                base.Base_DropBasicCodeBind(this.Ddl_ShipType, "145");
                base.Base_DropBasicCodeBind(this.Drop_Payment, "104");
                base.Base_DropBasicCodeBind(this.Ddl_KpType, "768");

                this.BeginQuery("Select * from PB_Basic_Wl ");
                this.QueryForDataTable();
                this.Drop_KD.DataSource = this.Dtb_Result;
                this.Drop_KD.DataTextField = "PBW_Name";
                this.Drop_KD.DataValueField = "PBW_Code";
                this.Drop_KD.DataBind();
                ListItem item = new ListItem("--请选择--", "-1"); //默认值
                Drop_KD.Items.Insert(0, item);

                this.BeginQuery("select * from Knet_Procure_Suppliers where KPS_Type='128860697896406251'");
                this.QueryForDataTable();
                this.Ddl_FSupp.DataSource = this.Dtb_Result;
                this.Ddl_FSupp.DataTextField = "SuppName";
                this.Ddl_FSupp.DataValueField = "SuppNo";
                this.Ddl_FSupp.DataBind();
                ListItem item1 = new ListItem("--请选择--", ""); //默认值
                Ddl_FSupp.Items.Insert(0, item);

                string s_ShipNo = Request.QueryString["ShipNo"] == null ? "" : Request.QueryString["ShipNo"].ToString();
                base.Base_DropWareHouseBind(this.Ddl_HouseNo, "  KSW_Type='0' ");
                base.Base_DropWareHouseBind(this.Ddl_RkHouseNo, "  KSW_Type='0' ");
                if (this.Tbx_Type.Text == "2")
                {
                    this.Ddl_HouseNo.SelectedValue = "131429356506502002";

                }
                ShowShipDetails(s_ShipNo);
                if (s_ID == "")
                {
                    this.Tbx_DirectInNo.Text = this.GetNewID("KNet_WareHouse_DirectOutList", 0);
                }
                base.Base_DropDutyPerson(this.Ddl_DutyPerson);
                base.Base_DropKClaaBind(this.ContractDeliveMethods, 5, "", "请选择。交货方式");

                if (s_ID != "")
                {
                    this.DataShow();
                }
                try
                {
                    if (this.Tbx_DirectInDateTime.Text == "")
                    {
                        this.Tbx_DirectInDateTime.Text = DateTime.Now.ToShortDateString();
                    }
                    this.Tbx_CwCode.Text = GetCwCode(DateTime.Parse(this.Tbx_DirectInDateTime.Text));
                }
                catch
                { }
            }
        }

    }
    private void ShowShipDetails(string s_ShipNo)
    {
        AdminloginMess AM = new AdminloginMess();
        if (s_ShipNo != "")
        {
            if (s_ShipNo != "")
            {
                //发货通知信息
                string s_Sql1 = "";
                s_Sql1 += "select d.HouseNo from Knet_Procure_OrdersList a ";
                s_Sql1 += "join KNET_Sales_ContractList b on a.ContractNo=b.ContractNo ";
                s_Sql1 += "join KNet_Sales_OutWareList c on c.ContractNo=a.ContractNo ";
                s_Sql1 += "join KNET_Sys_WareHouse d on d.suppNo=a.suppNo and KSW_Type=0 ";
                s_Sql1 += "where OutWareNo='" + s_ShipNo + "' ";
                s_Sql1 += "and OrderType='128860698200781250' ";
                this.BeginQuery(s_Sql1);
                string s_HouseNo = this.QueryForReturn();
                if (this.Ddl_HouseNo.SelectedValue != "")
                {
                    s_HouseNo = this.Ddl_HouseNo.SelectedValue;
                }
                else
                {
                    if (s_HouseNo != "")
                    {
                        this.Ddl_HouseNo.SelectedValue = s_HouseNo;
                    }
                }
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
                this.Ddl_ShipType.SelectedValue = Model.KSO_Type;
                this.Drop_Payment.SelectedValue = Model.KSO_PayMent;

                this.Ddl_KpType.SelectedValue = Model.KSO_KpType;

                try
                {
                    this.Tbx_ReceTime.Text = DateTime.Parse(Model.KSO_PlanOutWareDateTime.ToString()).ToShortDateString();
                }
                catch { }
                this.Tbx_SCustomerValue.Text = Model.KSO_SCustomerValue;
                this.Tbx_SCustomerName.Text = base.Base_GetCustomerName(Model.KSO_SCustomerValue);
                this.Tbx_CustomerValue.Text = Model.CustomerValue;
                this.Tbx_CustomerName.Text = base.Base_GetCustomerName(Model.CustomerValue);
                KNet.BLL.XS_Compy_LinkMan Bll_LinkMan = new KNet.BLL.XS_Compy_LinkMan();
                KNet.Model.XS_Compy_LinkMan Model_LinkMan = Bll_LinkMan.GetModel(Model.OutWareSideContact);
                base.Base_DropSheng(this.sheng);
                if (Model_LinkMan != null)
                {
                    this.sheng.SelectedValue = Model_LinkMan.XOL_Province;
                }
                base.Base_DropCity(this.city, this.sheng.SelectedValue);
                if (Model_LinkMan != null)
                {
                    this.city.SelectedValue = Model_LinkMan.XOL_City;
                }
                //物流信息自动绑定
                ShowWuliu();


                /*
               if (this.Tbx_ID.Text == "")
               {

                   KNet.BLL.KNet_Sales_OutWareList_Details BLL_Details = new KNet.BLL.KNet_Sales_OutWareList_Details();
                   DataSet Dts_Details = BLL_Details.GetList(" OutWareNo='" + Model.OutWareNo + "'");
                   if (Dts_Details.Tables[0].Rows.Count > 0)
                   {
                       for (int i = 0; i < Dts_Details.Tables[0].Rows.Count; i++)
                       {
                           this.Xs_ProductsCode.Text += Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + ",";
                           s_MyTable_Detail += "<tr>";
                           s_MyTable_Detail += "<td class=\"ListHeadDetails\"><A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"/Web/../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a></td>";
                           s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                           s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ProductsBarCode_" + i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "'>" + base.Base_GetProductsCode(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                           s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ProductsName_" + i.ToString() + "\" value='" + base.Base_GetProdutsName(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "'>" + base.Base_GetProductsEdition(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                           s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"input\"  Name=\"KCNumber_" + i.ToString() + "\" style=\"width:70px;\" disabled=false  value='" + base.Base_GetHouseAndNumber1(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString(), this.Ddl_HouseNo.SelectedValue) + "'></td>";
                           s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"input\"  Name=\"Number_" + i.ToString() + "\" style=\"width:70px;\"  value='" + Dts_Details.Tables[0].Rows[i]["OutWareAmount"].ToString() + "'></td>";
                           s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"input\"  Name=\"BNumber_" + i.ToString() + "\" style=\"width:70px;\"  value='" + Dts_Details.Tables[0].Rows[i]["KSD_BNumber"].ToString() + "'></td>";
                           s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"input\"  Name=\"PlanNo_" + i.ToString() + "\" style=\"width:70px;\"  value='" + Dts_Details.Tables[0].Rows[i]["MaterOrderNo"].ToString() + "'></td>";
                           s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"input\"  Name=\"OrderNo_" + i.ToString() + "\" style=\"width:70px;\"  value='" + Dts_Details.Tables[0].Rows[i]["RCOrderNo"].ToString() + "'></td>";
                           s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"input\"  Name=\"MaterNo_" + i.ToString() + "\" style=\"width:70px;\"  value='" + Dts_Details.Tables[0].Rows[i]["RCMNo"].ToString() + "'></td>";
                           s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"input\"  Name=\"CustomerProductsName_" + i.ToString() + "\" style=\"width:70px;\"  value='" + Dts_Details.Tables[0].Rows[i]["MaterMNo"].ToString() + "'></td>";
                           s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"input\"  Name=\"IsFollow_" + i.ToString() + "\" style=\"width:70px;\"  value='" + Dts_Details.Tables[0].Rows[i]["KSO_IsFollow"].ToString() + "'></td>";

                           s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"input\"  Name=\"Remarks_" + i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["OutWareRemarks"].ToString() + "'></td>";
                       }
                       this.Tbx_Num.Text = Dts_Details.Tables[0].Rows.Count.ToString();

                       s_MyTable_Detail += "</tr>";
                   }
               }
                */
            }
        }
        else
        {
            this.Ddl_RkHouseNo.SelectedValue = "128502353068906250";
            this.Tbx_CustomerValue.Text = "100751";
            this.Tbx_CustomerName.Text = "杭州士腾科技有限公司";
            this.Tbx_SCustomerValue.Text = "100751";
            this.Tbx_SCustomerName.Text = "杭州士腾科技有限公司";
            this.Tbx_ContentPerson.Text = "曹柱立";
            this.Tbx_ContentPersonID.Text = "20121127000001";
            this.Tbx_TelPhone.Text = "13082821205";
            this.Tbx_Address.Text = "杭州市西湖区黄姑山路4号";
            this.ContractDeliveMethods.SelectedValue = "129687525603715469";
        }
    }
    private void ShowWuliu()
    {
        string s_Return = "";
        string s_CustomerProvinces = "";
        string s_CustomerCity = "";
        try
        {

            string Dostr = "select top 1 * from KNet_Sales_OutWareList_FlowList where OutWareNo='" + this.Tbx_ID.Text + "' and KDCode<>''  order by FollowDateTime desc";
            this.BeginQuery(Dostr);
            DataTable Dtb_Tables = (DataTable)this.QueryForDataTable();
            if (Dtb_Tables.Rows.Count > 0)
            {
                this.span.Value = Dtb_Tables.Rows[0]["KDCodeName"].ToString();
                this.Drop_KD.SelectedValue = Dtb_Tables.Rows[0]["KDName"].ToString();
                this.Tbx_KDCode.Text = Dtb_Tables.Rows[0]["KDCode"].ToString();
            }

            string s_Sql = "select XOL_Province,XOL_City,XOL_Name from XS_Compy_LinkMan where XOL_Compy='" + this.Tbx_CustomerValue.Text + "' and XOL_Name='" + this.Tbx_ContentPerson.Text + "' ";
            this.BeginQuery(s_Sql);
            DataTable Dtb_Table = (DataTable)this.QueryForDataTable();
            if (Dtb_Table.Rows.Count <= 0)
            {
                s_Sql = "select XOL_Province,XOL_City,XOL_Name from XS_Compy_LinkMan where XOL_Name='" + this.Tbx_ContentPerson.Text + "' ";
                this.BeginQuery(s_Sql);
                Dtb_Table = (DataTable)this.QueryForDataTable();
            }
            s_CustomerProvinces = base.Base_GetCityName(Dtb_Table.Rows[0][0].ToString());
            s_CustomerCity = base.Base_GetShiName(Dtb_Table.Rows[0][1].ToString());
            string s_Name = Dtb_Table.Rows[0][2].ToString();
            /* if (s_CustomerCity != "")
             {
                 s_CustomerCity = s_CustomerCity.Replace("市", "");
             }
             else
             {
                 Alert("请维护 " + s_Name + " 所在市");
             }
             if (s_CustomerProvinces == "")
             {
                 Alert("请维护 " + s_Name + " 所在省");
             }
             else
             {
                 s_CustomerProvinces = s_CustomerProvinces.Replace("省", "");
                 s_CustomerProvinces = s_CustomerProvinces.Replace("市", "");
             }
             * */
            s_Sql = "Select top 10 * from Wl_Customer_Price a join Wl_Customer_Price_Details b on a.WCP_ID=WCPD_FID where ";
            s_Sql += " WCPD_Provice like '%" + s_CustomerProvinces + "%' and WCPD_City like '%" + s_CustomerCity + "%'";
            s_Sql += " and WCP_SuppNo in (Select SuppNo from KNET_Sys_WareHouse where HouseNo='" + this.Ddl_HouseNo.SelectedValue + "')";
            this.BeginQuery(s_Sql);
            DataTable Dtb_Wuliu = (DataTable)this.QueryForDataTable();
            for (int i = 0; i < Dtb_Wuliu.Rows.Count; i++)
            {
                s_Return += " <tr>";
                s_Return += "<td class=\"ListHeadDetails\" align=\"center\"><input type=\"radio\"   Name=\"Radio\" value=" + i.ToString() + " onclick=\"onSelect(this)\"></td>";
                s_Return += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"Custom_Hidden\"  Name=\"Wuliu_PriceID_" + i.ToString() + "\"  value=\"" + Dtb_Wuliu.Rows[i]["WCPD_ID"].ToString() + "\" />" + base.Base_GetSupplierName(Dtb_Wuliu.Rows[i]["WCP_WuliuSuppNo"].ToString()) + "</td>";
                s_Return += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"Custom_Hidden\"  Name=\"Wuliu_Type_" + i.ToString() + "\"  value=\"" + Dtb_Wuliu.Rows[i]["WCPD_Type"].ToString() + "\" />" + Dtb_Wuliu.Rows[i]["WCPD_Type"].ToString() + "</td>";
                s_Return += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"Custom_Hidden\"  Name=\"Wuliu_Price_" + i.ToString() + "\" value=\"" + Dtb_Wuliu.Rows[i]["WCPD_Price"].ToString() + "\" >" + Dtb_Wuliu.Rows[i]["WCPD_Price"].ToString() + "</td>";
                s_Return += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"Custom_Hidden\"  Name=\"Wuliu_Money_" + i.ToString() + "\" value=\"" + Dtb_Wuliu.Rows[i]["WCPD_Price"].ToString() + "\" >" + Dtb_Wuliu.Rows[i]["WCPD_Price"].ToString() + "</td>";
                s_Return += "<td class=\"ListHeadDetails\"><input type=\"text\"  class=\"Custom_Hidden\" Name=\"Wuliu_Time_" + i.ToString() + "\" value=\"" + Dtb_Wuliu.Rows[i]["WCPD_MaxTime"].ToString() + "\" >" + Dtb_Wuliu.Rows[i]["WCPD_MaxTime"].ToString() + "</td>";
                s_Return += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"Custom_Hidden\" Name=\"Wuliu_MinMoney_" + i.ToString() + "\" value=\"" + Dtb_Wuliu.Rows[i]["WCPD_MinMoney"].ToString() + "\" >" + Dtb_Wuliu.Rows[i]["WCPD_MinMoney"].ToString() + "</td>";
                s_Return += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"Custom_Hidden\" Name=\"Wuliu_PickUpCost_" + i.ToString() + "\" value=\"" + Dtb_Wuliu.Rows[i]["WCPD_PickUpCost"].ToString() + "\" >" + Dtb_Wuliu.Rows[i]["WCPD_PickUpCost"].ToString() + "</td>";
                s_Return += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"Custom_Hidden\" Name=\"Wuliu_DeliveryFee_" + i.ToString() + "\" value=\"" + Dtb_Wuliu.Rows[i]["WCPD_DeliveryFee"].ToString() + "\" >" + Dtb_Wuliu.Rows[i]["WCPD_DeliveryFee"].ToString() + "</td>";
                s_Return += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"Custom_Hidden\" Name=\"Wuliu_UpstairsCost_" + i.ToString() + "\" value=\"" + Dtb_Wuliu.Rows[i]["WCPD_UpstairsCost"].ToString() + "\" >" + Dtb_Wuliu.Rows[i]["WCPD_UpstairsCost"].ToString() + "</td>";
                s_Return += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"Custom_Hidden\" Name=\"Wuliu_UpstairsCostMoney_" + i.ToString() + "\" value=\"" + Dtb_Wuliu.Rows[i]["WCPD_UpstairsCost"].ToString() + "\" >" + Dtb_Wuliu.Rows[i]["WCPD_UpstairsCost"].ToString() + "</td>";
                s_Return += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"Custom_Hidden\" Name=\"Wuliu_WareHouseEntry150Low_" + i.ToString() + "\" value=\"" + Dtb_Wuliu.Rows[i]["WCPD_WareHouseEntry150Low"].ToString() + "\" >" + Dtb_Wuliu.Rows[i]["WCPD_WareHouseEntry150Low"].ToString() + "</td>";
                s_Return += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"Custom_Hidden\"  Name=\"Wuliu_Insured_" + i.ToString() + "\" value=\"" + Dtb_Wuliu.Rows[i]["WCPD_Insured"].ToString() + "\" >" + Dtb_Wuliu.Rows[i]["WCPD_Insured"].ToString() + "</td>";
                s_Return += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"Custom_Hidden\"  Name=\"Wuliu_InsuredMoney_" + i.ToString() + "\" value=\"" + Dtb_Wuliu.Rows[i]["WCPD_Insured"].ToString() + "\" >" + Dtb_Wuliu.Rows[i]["WCPD_Insured"].ToString() + "</td>";
                s_Return += "<td class=\"ListHeadDetails\"><input type=\"text\"  class=\"Custom_Hidden\" Name=\"Wuliu_SignBill_" + i.ToString() + "\" value=\"" + Dtb_Wuliu.Rows[i]["WCPD_SignBill"].ToString() + "\" >" + Dtb_Wuliu.Rows[i]["WCPD_SignBill"].ToString() + "</td>";
                s_Return += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"Custom_Hidden\"  Name=\"Wuliu_BigLateTime_" + i.ToString() + "\" value=\"" + Dtb_Wuliu.Rows[i]["WCPD_BigLateTime"].ToString() + "\" >" + Dtb_Wuliu.Rows[i]["WCPD_BigLateTime"].ToString() + "&nbsp;</td>";
                s_Return += " </tr>";
            }
            Tbx_FeightNum.Text = Dtb_Wuliu.Rows.Count.ToString();
        }
        catch { }
        this.Lbl_Details.Text = s_Return;
    }
    private void DataShow()
    {
        AdminloginMess AM = new AdminloginMess();
        if (this.Tbx_ID.Text != "")
        {
            KNet.BLL.KNet_WareHouse_DirectOutList bll = new KNet.BLL.KNet_WareHouse_DirectOutList();
            KNet.Model.KNet_WareHouse_DirectOutList model = bll.GetModelB(this.Tbx_ID.Text);

            if ((AM.KNet_StaffName != "薛建新") && (this.Pan_DirectOut.Enabled == true))
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
            this.Tbx_TelPhone.Text = model.KWD_Telphone;
            this.Ddl_RkHouseNo.SelectedValue = model.KWD_RkHouseNo;
            //this.Ddl_HouseNo.SelectedValue = model.HouseNo;
            this.Ddl_HouseNo.SelectedValue = "131187187069993664";
            this.Ddl_ShipType.SelectedValue = model.KWD_ShipType;


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
                    string s_Disable = "";
                    if (this.Pan_DirectOut.Enabled == false)
                    {
                        s_Disable = "disabled=false";
                    }
                    s_MyTable_Detail += " <tr " + s_Disable + " >";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"/Web/../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a></td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"FID_" + i.ToString() + "\" value='" + s_ID + "'><input type=\"hidden\"  Name=\"ID_" + i.ToString() + "\" value='" + s_FID + "'><input type=\"hidden\" ID=\"ProductsBarCode_" + i.ToString() + "\"  Name=\"ProductsBarCode_" + i.ToString() + "\" value='" + s_ProductsBarCode + "'>" + s_ProductsName + "&nbsp;</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsCode(s_ProductsBarCode) + "&nbsp;</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ProductsName_" + i.ToString() + "\" value='" + s_ProductsName + "'>" + s_ProductsEditon + "</td>";
                    string s_HouseNumber = base.Base_GetHouseAndNumber1(s_ProductsBarCode, this.Ddl_HouseNo.SelectedValue);
                    string s_OutNumber = Dts_Table.Tables[0].Rows[i]["DirectOutAmount"].ToString();
                    string s_OutBNumber = Dts_Table.Tables[0].Rows[i]["KWD_BNumber"].ToString();
                    try
                    {
                        s_HouseNumber = Convert.ToString(int.Parse(s_HouseNumber) + int.Parse(s_OutNumber) + int.Parse(s_OutBNumber));
                    }
                    catch
                    { }

                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"input\" readonly=\"true\"  Name=\"KCNumber_" + i.ToString() + "\" style=\"width:70px;\"   value='" + s_HouseNumber + "'></td>";

                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\" Name=\"Number_" + i.ToString() + "\" value=" + s_OutNumber + "></td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\" Name=\"BNumber_" + i.ToString() + "\" value=" + s_OutBNumber + " ></td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\"   Name=\"PlanNo_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["PlanNo"].ToString().Replace("?", "") + " ></td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\"   Name=\"OrderNo_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["OrderNo"].ToString().Replace("?", "") + " ></td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\"   Name=\"MaterNo_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["MaterNo"].ToString().Replace("?", "") + " ></td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\"   Name=\"CustomerProductsName_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["CustomerProductsName"].ToString().Replace("?", "") + " ></td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\"   Name=\"IsFollow_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["KWD_IsFollow"].ToString().Replace("?", "") + " ></td>";
                    s_MyTable_Detail += " <td class=\"ListHeadDetails\"><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:50px;\"  Name=\"Remarks_" + i.ToString() + "\"  Text=\"" + Dts_Table.Tables[0].Rows[i]["DirectOutRemarks"].ToString() + "\" ></td>";
                    s_MyTable_Detail += " </tr>";

                    this.Xs_ProductsCode.Text += Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString() + ",";
                }
                this.Tbx_Num.Text = Dts_Table.Tables[0].Rows.Count.ToString();
            }

            KNet.BLL.Xs_Sales_Freight Bll_Freight = new KNet.BLL.Xs_Sales_Freight();
            KNet.Model.Xs_Sales_Freight Model_Freight = Bll_Freight.GetModelByFID(this.Tbx_DirectInNo.Text);

            try
            {
                if (Model_Freight != null)
                {
                    base.Base_DropSheng(this.sheng);
                    this.sheng.SelectedValue = Model_Freight.XSF_Province;

                    base.Base_DropCity(this.city, this.sheng.SelectedValue);
                    this.city.SelectedValue = Model_Freight.XSF_City;
                    Drop_KD.SelectedValue = Model_Freight.XSF_KDNameCode;
                    this.Tbx_KDCode.Text = Model_Freight.XSF_KDCode;
                    this.Ddl_FSupp.SelectedValue = Model_Freight.XSF_FSuppNo;
                    this.Tbx_Wuliu_Type.Text = Model_Freight.XSF_WuliuType;
                    this.Tbx_Wuliu_Price.Text = Model_Freight.XSF_WuliuPrice.ToString();
                    this.Tbx_Wuliu_Money.Text = Model_Freight.XSF_WuliuMoney.ToString();
                    this.Tbx_Wuliu_Time.Text = Model_Freight.XSF_TimeDays.ToString();
                    this.Tbx_Wuliu_MinMoney.Text = Model_Freight.XSF_MinMoney.ToString();
                    this.Tbx_Wuliu_PickUpCost.Text = Model_Freight.XSF_PickUpCost.ToString();
                    this.Tbx_Wuliu_DeliveryFee.Text = Model_Freight.XSF_DeliveryFee.ToString();
                    this.Tbx_Wuliu_UpstairsCost.Text = Model_Freight.XSF_UpstairsCost.ToString();
                    this.Tbx_Wuliu_UpstairsCostMoney.Text = Model_Freight.XSF_UpstairsCostMoney.ToString();
                    this.Tbx_Wuliu_WareHouseEntry150Low.Text = Model_Freight.XSF_WareHouseEntry150Low.ToString();
                    this.Tbx_Wuliu_Insured.Text = Model_Freight.XSF_Insured.ToString();
                    this.Tbx_Wuliu_InsuredMoney.Text = Model_Freight.XSF_InsuredMoney.ToString();
                    this.Tbx_Wuliu_SignBill.Text = Model_Freight.XSF_SignBill.ToString();
                    this.Tbx_Wuliu_BigLateTime.Text = Model_Freight.XSF_BigLateTime.ToString();

                    this.Tbx_Weight.Text = Model_Freight.XSF_Weight.ToString();
                    this.Tbx_WeightDetails.Text = Model_Freight.XSF_WeightDetails.ToString();
                    this.Tbx_Volume.Text = Model_Freight.XSF_Volume.ToString();
                    this.Tbx_VolumeDetails.Text = Model_Freight.XSF_VolumeDetails.ToString();
                    this.Tbx_TotalNumber.Text = Model_Freight.XSF_TotalNumber.ToString();
                    this.Tbx_Price.Text = Model_Freight.XSF_Price.ToString();
                    this.Tbx_TotalMoney.Text = Model_Freight.XSF_TotalMoney.ToString();
                    this.Tbx_TotalMoneyDetails.Text = Model_Freight.XSF_TotalMoneyDetails.ToString();
                    this.Tbx_Description.Text = Model_Freight.XSF_Description;
                    this.Tbx_FPercent.Text = Model_Freight.XSF_FPercent.ToString();
                    this.Tbx_Percent.Text = Model_Freight.XSF_Percent.ToString();
                    this.Tbx_FMoney.Text = Model_Freight.XSF_FMoney.ToString();
                    this.Tbx_Money.Text = Model_Freight.XSF_Money.ToString();
                    this.Tbx_WuliuCode.Text = Model_Freight.XSF_Code;
                    this.Tbx_WuliuID.Text = Model_Freight.XSF_ID;
                }
                else
                {
                    ShowShipDetails(model.KWD_ShipNo);
                }

            }
            catch
            { }
            //ShowWuliu();

            this.Ddl_KpType.SelectedValue = model.KWD_KpType;
            this.Drop_Payment.SelectedValue = model.KWD_PayMent;
            //this.Ddl_DutyPerson.SelectedValue=
        }
    }
    private bool SetValue(KNet.Model.KNet_WareHouse_DirectOutList molel)
    {
        try
        {
            AdminloginMess AM = new AdminloginMess();
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
            molel.KWD_ShipType = this.Ddl_ShipType.SelectedValue;

            molel.KWD_PayMent = this.Drop_Payment.SelectedValue;
            molel.KWD_KpType = this.Ddl_KpType.SelectedValue;


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
                    string KCNumber = Request.Form["KCNumber_" + i] == null ? "" : Request.Form["KCNumber_" + i].ToString();
                    string s_RustomerProductsName = Request["CustomerProductsName_" + i] == null ? "" : Request["CustomerProductsName_" + i].ToString();
                    //限制出库数量不能大于库存---- - 2018.5.8
                    //string s_Sql ="Select isnull(Sum(DirectInAmount),0),a.HouseNo from v_Store a join KNet_Sys_WareHouse b on a.HouseNo=b.HouseNo  Where a.ProductsBarCode='" + s_ProductsBarCode + "' and a.HouseType='0' and a.HouseNo='" + HouseNo + "'  Group by a.HouseNo ";
                    //this.BeginQuery(s_Sql);
                    //this.QueryForDataTable();
                    //DataTable Dtb_Table = this.Dtb_Result;//计算实际库存
                    //if (Dtb_Table.Rows.Count>0)
                    //{
                    //    if (Convert.ToInt32(Dtb_Table.Rows[0][0].ToString()) <0&& Convert.ToInt32(s_Number)<0)
                    //    {
                    //        //Alert("此仓库库存不足，或者库存为负数不能出库，请重新选择");
                    //        //return false;
                    //    }
                    //    else
                    //    {
                    //        if (Convert.ToInt32(Dtb_Table.Rows[0][0].ToString()) < Convert.ToInt32(s_Number))
                    //        {
                    //            Alert("出库数量不能大于库存数量，请重新选择仓库");
                    //            return false;
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    if (Convert.ToInt32(s_Number)>0)
                    //    {
                    //        Alert("出库数量不能大于库存数量，请重新选择仓库");
                    //        return false;
                    //    }

                    //}
                    if (Convert.ToInt32(KCNumber) < 0)
                    {
                        Alert("库存不足，或者库存为负数不能出库");
                        return false;
                    }
                    else
                    {
                        if (Convert.ToInt32(KCNumber) < Convert.ToInt32(s_Number))
                        {
                            Alert("出库数量不能大于库存数量");
                            return false;
                        }
                    }
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
                    //出库单价 decimal.Parse(base.Base_GetProductsPrice(s_ProductsBarCode, HouseNo))
                    ModelDetails.DirectOutUnitPrice = 0;
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

            ArrayList arr_Freight = new ArrayList();
            if (this.Tbx_TotalMoney.Text != "")
            {
                KNet.Model.Xs_Sales_Freight Model_Freight = new KNet.Model.Xs_Sales_Freight();
                if (this.Tbx_WuliuID.Text == "")
                {
                    Model_Freight.XSF_ID = GetMainID();
                }
                else
                {
                    Model_Freight.XSF_ID = this.Tbx_WuliuID.Text;
                }
                if (this.Tbx_WuliuID.Text == "")
                {
                    Model_Freight.XSF_Code = base.GetNewID("XSF_Code", 1);
                }
                else
                {
                    Model_Freight.XSF_Code = this.Tbx_WuliuCode.Text;
                }
                Model_Freight.XSF_FID = DirectInNo.ToString();
                try
                {
                    Model_Freight.XSF_Stime = DateTime.Parse(this.Tbx_WuliuStime.Text);
                }
                catch { }
                Model_Freight.XSF_Description = this.Tbx_Description.Text.ToString();

                KNet.BLL.KNet_Sys_WareHouse Bll_WareHouse = new KNet.BLL.KNet_Sys_WareHouse();
                KNet.Model.KNet_Sys_WareHouse Model_WareHouse = Bll_WareHouse.GetModel(this.Ddl_HouseNo.SelectedValue);
                Model_Freight.XSF_CustomerValue = Model_WareHouse.SuppNo;
                Model_Freight.XSF_CustomerName = base.Base_GetSupplierName(Model_WareHouse.SuppNo);
                try
                {
                    Model_Freight.XSF_FPercent = decimal.Parse(Request["Tbx_FPercent"].ToString());
                }
                catch { }
                try
                {
                    Model_Freight.XSF_FMoney = decimal.Parse(Request["Tbx_FMoney"].ToString());
                }
                catch { }
                try
                {
                    Model_Freight.XSF_Percent = decimal.Parse(Request["Tbx_Percent"].ToString());
                }
                catch { }
                try
                {
                    Model_Freight.XSF_Money = decimal.Parse(Request["Tbx_Money"].ToString());
                }
                catch { }
                try
                {
                    Model_Freight.XSF_TotalMoney = decimal.Parse(Request["Tbx_TotalMoney"].ToString());
                }
                catch { }
                try
                {
                    Model_Freight.XSF_TotalNumber = int.Parse(Request["Tbx_TotalNumber"].ToString());
                }
                catch { }

                try
                {
                    Model_Freight.XSF_Price = decimal.Parse(Request["Tbx_Price"].ToString());
                }
                catch { }
                Model_Freight.XSF_Flow = "107";
                Model_Freight.XSF_Del = 0;
                Model_Freight.XSF_CTime = DateTime.Now;
                Model_Freight.XSF_Creator = AM.KNet_StaffNo;
                Model_Freight.XSF_MTime = DateTime.Now;
                Model_Freight.XSF_Mender = AM.KNet_StaffNo;
                Model_Freight.XSF_KDCode = this.Tbx_KDCode.Text;
                Model_Freight.XSF_KDName = this.Drop_KD.SelectedItem.Text;
                Model_Freight.XSF_KDNameCode = this.Drop_KD.SelectedValue;
                Model_Freight.XSF_Address = this.Tbx_Address.Text;
                Model_Freight.XSF_FSuppNo = Request["Ddl_FSupp"].ToString();

                Model_Freight.XSF_DutyPerson = this.Ddl_DutyPerson.SelectedValue;

                try
                {
                    Model_Freight.XSF_WuliuID = Request["Tbx_Wuliu_PriceID"].ToString();
                }
                catch { }
                try
                {
                    Model_Freight.XSF_WuliuType = Request["Tbx_Wuliu_Type"].ToString();
                }
                catch { }
                try
                {
                    Model_Freight.XSF_WuliuPrice = decimal.Parse(Request["Tbx_Wuliu_Price"].ToString());
                }
                catch { }
                try
                {
                    Model_Freight.XSF_WuliuMoney = decimal.Parse(Request["Tbx_Wuliu_Money"].ToString());
                }
                catch { }

                try
                {
                    Model_Freight.XSF_TimeDays = int.Parse(Request["Tbx_Wuliu_Time"].ToString());
                }
                catch { }

                try
                {
                    Model_Freight.XSF_MinMoney = decimal.Parse(Request["Tbx_Wuliu_MinMoney"].ToString());
                }
                catch { }
                try
                {
                    Model_Freight.XSF_PickUpCost = decimal.Parse(Request["Tbx_Wuliu_PickUpCost"].ToString());
                }
                catch { }

                try
                {
                    Model_Freight.XSF_DeliveryFee = decimal.Parse(Request["Tbx_Wuliu_DeliveryFee"].ToString());
                }
                catch { }

                try
                {
                    Model_Freight.XSF_UpstairsCost = decimal.Parse(Request["Tbx_Wuliu_UpstairsCost"].ToString());
                }
                catch { }

                try
                {
                    Model_Freight.XSF_UpstairsCostMoney = decimal.Parse(Request["Tbx_Wuliu_UpstairsCostMoney"].ToString());
                }
                catch { }

                try
                {
                    Model_Freight.XSF_WareHouseEntry150Low = decimal.Parse(Request["Tbx_Wuliu_WareHouseEntry150Low"].ToString());
                }
                catch { }

                try
                {
                    Model_Freight.XSF_Insured = decimal.Parse(Request["Tbx_Wuliu_Insured"].ToString());
                }
                catch { }
                try
                {
                    Model_Freight.XSF_InsuredMoney = decimal.Parse(Request["Tbx_Wuliu_InsuredMoney"].ToString());
                }
                catch { }
                try
                {
                    Model_Freight.XSF_SignBill = decimal.Parse(Request["Tbx_Wuliu_SignBill"].ToString());
                }
                catch { }
                try
                {
                    Model_Freight.XSF_BigLateTime = Request["Tbx_Wuliu_BigLateTime"].ToString();
                }
                catch { }

                try
                {
                    Model_Freight.XSF_Weight = decimal.Parse(this.Tbx_Weight.Text);
                    Model_Freight.XSF_WeightDetails = this.Tbx_WeightDetails.Text;
                }
                catch { }
                try
                {
                    Model_Freight.XSF_Volume = decimal.Parse(this.Tbx_Volume.Text);
                    Model_Freight.XSF_VolumeDetails = this.Tbx_VolumeDetails.Text;
                }
                catch { }

                try
                {
                    Model_Freight.XSF_Province = this.sheng.SelectedValue;
                    Model_Freight.XSF_City = this.city.SelectedValue;
                }
                catch { }
                Model_Freight.XSF_TotalMoneyDetails = this.Tbx_TotalMoneyDetails.Text;


                Model_Freight.XSF_Province = Request["Sheng"].ToString();
                Model_Freight.XSF_City = Request["City"].ToString();
                arr_Freight.Add(Model_Freight);
                molel.Arr_Feight = arr_Freight;

            }

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
                this.Xs_ProductsCode.Text = "";
                Alert("系统错误！");
                return;
            }
            AdminloginMess LogAM = new AdminloginMess();

            if (this.Tbx_ID.Text == "")
            {
                if (BLL.Exists(this.Tbx_ID.Text) == false)
                {
                    BLL.Add(molel);
                    string JSD = "Xs/SalesOut/Sales_ShipWareOut_Print.aspx?ID=" + molel.KWD_ShipNo + "&DID=" + molel.DirectOutNo + "";
                    base.HtmlToPdfNoWater(JSD, Server.MapPath("PDF"), molel.DirectOutNo);
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

                if (this.Tbx_Type.Text == "1")//如果是编辑发票方式
                {
                    BLL.UpdateByKpType(molel);
                    LogAM.Add_Logs("销售管理--->应收款更改开票方式 操作成功！订单编号：" + this.Tbx_ID.Text);
                    Response.Write("<script>alert('应收款更改开票方式  操作成功 ！');location.href='YSales_ShipWareOut_Manage.aspx';</script>");
                    Response.End();
                }
                else
                {

                    if (this.Tbx_Freight.Text != "")
                    {
                        if (molel.Arr_Feight != null)
                        {
                            KNet.BLL.Xs_Sales_Freight Bll_Freight = new KNet.BLL.Xs_Sales_Freight();

                            for (int i = 0; i < molel.Arr_Feight.Count; i++)
                            {
                                KNet.Model.Xs_Sales_Freight Model = (KNet.Model.Xs_Sales_Freight)molel.Arr_Feight[i];

                                if (this.Tbx_WuliuID.Text != "")
                                {
                                    Bll_Freight.Update(Model);
                                }
                                else
                                {
                                    Bll_Freight.Add(Model);
                                }
                            }
                        }
                        LogAM.Add_Logs("销售管理--->运费编辑 操作成功！订单编号：" + this.Tbx_ID.Text);
                        Response.Write("<script>alert('运费编辑  操作成功 ！');location.href='Sales_ShipWareOut_Manage.aspx';</script>");
                        Response.End();
                    }
                    else
                    {
                        BLL.Update(molel);
                        string JSD = "Xs/SalesOut/Sales_ShipWareOut_Print.aspx?ID=" + molel.KWD_ShipNo + "&DID=" + molel.DirectOutNo + "";
                        base.HtmlToPdfNoWater(JSD, Server.MapPath("PDF"), molel.DirectOutNo);
                        LogAM.Add_Logs("销售管理--->修改发货出库 操作成功！订单编号：" + this.Tbx_ID.Text);
                        Response.Write("<script>alert('修改发货出库  操作成功 ！');location.href='Sales_ShipWareOut_Manage.aspx';</script>");
                        Response.End();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //throw ex;
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
                if (Dtb_Table.Rows[0][0].ToString() != "")
                {
                    s_Code = Dtb_Table.Rows[0][0].ToString().Substring(0, 6) + "-" + Convert.ToString(int.Parse("1" + Dtb_Table.Rows[0][0].ToString().Substring(7, 3)) + 1).Substring(1, 3);
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
            if (FileType == "image/gif" || FileType == "image/pjpeg")
            {
                GetThumbnailImage();
            }
            else
            {
                Response.Write("<script language=javascript>alert('文件类型服务器不接受！类型:" + FileType + " ');history.back(-1);</script>");
                Response.End();
            }
        }
    }

    /// <summary>
    /// 图片上传
    /// </summary>
    protected void GetThumbnailImage()
    {
        string UploadPath = "../../../UpFile/SalesOut/";  //上传路径

        string AutoPath = System.DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "").Replace("/", "");
        string fileExt = Path.GetExtension(uploadFile.PostedFile.FileName); //获扩展名
        string FileType = uploadFile.PostedFile.ContentType.ToString(); //文件类型

        string filePath = UploadPath + AutoPath + fileExt; //大文件名
        string filePathsmall = UploadPath + AutoPath + "_small" + fileExt; //小文件名

        string newfile = filePath + ".jpg"; //略图文件名

        if (FileType == "image/gif" || FileType == "image/pjpeg")
        {
            if (!Directory.Exists(Server.MapPath(UploadPath)))
            {
                Directory.CreateDirectory(Server.MapPath(UploadPath));
            }
            uploadFile.PostedFile.SaveAs(Server.MapPath(filePath)); //上传
            Up_Loadcs UL = new Up_Loadcs();

            UL.MakeZoomImage(Server.MapPath("../../../UpFile/SalesOut/") + AutoPath + fileExt, Server.MapPath("../../../UpFile/SalesOut/") + AutoPath + "_small" + fileExt, 95, 75, "HW");

            this.Image1.ImageUrl = "../../../UpFile/SalesOut/" + AutoPath + "_small" + fileExt;
            this.Image1Big.Text = filePath;
        }
        else
        {
            Response.Write("<script language=javascript>alert('文件类型服务器不接受！类型:" + FileType + " ');history.back(-1);</script>");
            Response.End();
        }
    }

    #endregion


    [Ajax.AjaxMethod]
    public string GetWeightVolume(string s_Products)
    {
        decimal d_Weight = 0;
        decimal d_Volume = 0;
        try
        {
            KNet.BLL.KNet_Sys_Products Bll = new KNet.BLL.KNet_Sys_Products();
            KNet.Model.KNet_Sys_Products Model = Bll.GetModelB(s_Products);
            d_Weight += Model.KSP_Weight;
            d_Volume += Model.KSP_Volume;
        }
        catch
        { }
        return d_Weight.ToString() + "," + d_Volume.ToString();
    }

    [Ajax.AjaxMethod]
    public string GetWuliuPriceDetails(string s_ID)
    {
        string s_Return = "";
        try
        {
            KNet.BLL.Wl_Customer_Price_Details Bll_Details = new KNet.BLL.Wl_Customer_Price_Details();
            KNet.Model.Wl_Customer_Price_Details Model_Details = Bll_Details.GetModel(s_ID);
            KNet.BLL.Wl_Customer_Price Bll = new KNet.BLL.Wl_Customer_Price();
            KNet.Model.Wl_Customer_Price Model = Bll.GetModel(Model_Details.WCPD_FID);
            s_Return = Model.WCP_WuliuSuppNo;
        }
        catch
        { }
        return s_Return.ToString();
    }

    [Ajax.AjaxMethod()]
    public string GetKDCode(string s_SuppNo)
    {
        string s_Return = "";
        try
        {
            this.BeginQuery("Select KPS_KDCode from Knet_Procure_Suppliers where SuppNo='" + s_SuppNo + "'");
            s_Return = this.QueryForReturn();
        }
        catch { }
        return s_Return;
    }
    [Ajax.AjaxMethod()]
    public string GetKCNumber(string s_ProductsBarCode, string s_HouseNo)
    {
        string s_Return = "";
        try
        {
            s_Return = base.Base_GetHouseAndNumber1(s_ProductsBarCode, s_HouseNo);
        }
        catch { }
        return s_Return;
    }

    [Ajax.AjaxMethod()]
    public string GetShen(string s_Shen)
    {
        string s_Return = "";
        try
        {
            this.BeginQuery("Select * from KNET_Static_City where Provinceid = '" + s_Shen + "' ");
            this.QueryForDataTable();
            if (Dtb_Result.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Result.Rows.Count; i++)
                {
                    s_Return += Dtb_Result.Rows[i]["Code"].ToString() + "," + Dtb_Result.Rows[i]["Name"].ToString() + "|";
                }
            }
        }
        catch { }
        return s_Return;
    }
}
