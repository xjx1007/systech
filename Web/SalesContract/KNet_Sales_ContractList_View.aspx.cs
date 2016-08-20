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

using System.IO;
using System.Text;

using KNet.DBUtility;
using KNet.Common;
using System.Data.SqlClient;

public partial class Web_KNet_Sales_ContractList_View : BasePage
{
    public string s_MyTable_Detail = "", s_OrderStyle = "", s_DetailsStyle = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Lbl_Title.Text = "查看合同评审";
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("查看合同评审") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();

            if (s_Type == "1")
            {
                s_OrderStyle = "class=\"dvtUnSelectedCell\"";
                s_DetailsStyle = "class=\"dvtSelectedCell\"";
                Pan_Order.Visible = false;
                Pan_Detail.Visible = true;
                Table_Btn.Visible = false;
            }
            else
            {

                s_DetailsStyle = "class=\"dvtUnSelectedCell\"";
                s_OrderStyle = "class=\"dvtSelectedCell\"";
                Pan_Order.Visible = true;
                Pan_Detail.Visible = false;
                Table_Btn.Visible = true;
            }
            if (s_ID != "")
            {
                ShowInfo(s_ID);

                KNet.BLL.KNet_Sales_Flow Bll_Sales_Flow = new KNet.BLL.KNet_Sales_Flow();
                KNet.Model.KNet_Sales_Flow Model_Sales_Flow = new KNet.Model.KNet_Sales_Flow();
                GridView1.DataSource = Bll_Sales_Flow.GetList(" KSF_ContractNo='" + this.ContractNo.Text + "' and KFS_Type='0'  Order  by KSF_Date desc");
                this.GridView1.DataBind();


                KNet.BLL.Knet_Procure_OrdersList bll_Order = new KNet.BLL.Knet_Procure_OrdersList();
                string SqlWhere = "  ContractNo='" + this.ContractNo.Text + "' order by SYstemDateTimes desc";
                DataSet ds = bll_Order.GetList(SqlWhere);

                GridView_Order.DataSource = ds.Tables[0];
                GridView_Order.DataKeyNames = new string[] { "OrderNo" };
                GridView_Order.DataBind();

                KNet.BLL.KNet_Sales_OutWareList bllShip = new KNet.BLL.KNet_Sales_OutWareList();
                SqlWhere = "  ContractNo='" + this.ContractNo.Text + "' order by SYstemDateTimes desc";
                DataSet ds_Ship = bllShip.GetList(SqlWhere);

                GridView_Ship.DataSource = ds_Ship.Tables[0];
                GridView_Ship.DataBind();

            }
        }
    }

    public string GetCk(string s_OutWareNo)
    {
        string s_Return = "";
        try
        {
            KNet.BLL.KNet_WareHouse_DirectOutList Bll = new KNet.BLL.KNet_WareHouse_DirectOutList();
            DataSet Dts_Table = Bll.GetList(" KWD_ShipNo='" + s_OutWareNo + "'");
            if (Dts_Table.Tables[0].Rows.Count > 0)
            {
                s_Return = DateTime.Parse(Dts_Table.Tables[0].Rows[0]["DirectOutDateTime"].ToString()).ToShortDateString();
            }
        }
        catch (Exception ex)
        {

        }
        return s_Return;
    }
    /// <summary>
    /// 返回发货跟踪 最新一条记录（Y）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetOutWareListfollowup(object OutWareNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select top 1 ID,FollowNo,OutWareNo,FollowDateTime,FollowStaffNo,FollowText,FollowEnd from KNet_Sales_OutWareList_FlowList where OutWareNo='" + OutWareNo + "' order by FollowDateTime desc";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["FollowEnd"].ToString() == "True")
                {
                    return "<img src=\"../images/takman.gif\" width=\"11\" height=\"14\" border=\"0\" /><a href=\"#\" style=\"line-height: 22px;\" onclick=\"lhgdialog.opendlg('发货单号:<font color=Red>" + OutWareNo + "</font> 跟踪', '../Sales/Knet_Sales_Ship_Manage_Talks_List.aspx?OutWareNo=" + OutWareNo + "', 780, 400,false,false);\">" + KNetPage.CutString(dr["FollowText"].ToString().Trim(), 40) + "</a>&nbsp;<font color=red>结束</font>";//&nbsp;<font color=\"gray\">" + base.Base_GetUserName(dr["FollowStaffNo"].ToString()) + "&nbsp;(" + dr["FollowDateTime"].ToString() + ")</font>
                }
                else
                {
                    return "<img src=\"../images/takman.gif\" width=\"11\" height=\"14\" border=\"0\" /><a href=\"#\" style=\"line-height: 22px;\" onclick=\"lhgdialog.opendlg('发货单号:<font color=Red>" + OutWareNo + "</font> 跟踪', '../Sales/Knet_Sales_Ship_Manage_Talks_List.aspx?OutWareNo=" + OutWareNo + "', 780, 400,false,false);\">" + KNetPage.CutString(dr["FollowText"].ToString().Trim(), 40) + "</a>&nbsp;<img src=\"../images/45.gif\" width=\"11\" height=\"11\" border=\"0\" /><a href=\"#\" onclick=\"lhgdialog.opendlg('发货单号:<font color=Red>" + OutWareNo + "</font> 跟踪', '../Sales/Knet_Sales_Ship_Manage_Talks_Add.aspx?OutWareNo=" + OutWareNo + "', 780, 400,false,false);\">添加</a>";
                }
            }
            else
            {
                return "<a href=\"#\" onclick=\"lhgdialog.opendlg('发货单号:<font color=Red>" + OutWareNo + "</font> 跟踪', '../Sales/Knet_Sales_Ship_Manage_Talks_Add.aspx?OutWareNo=" + OutWareNo + "', 780, 400,false,false);\">添加</a>";
            }
        }
    }
    private void ShowInfo(string s_ID)
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.BLL.KNet_Sales_ContractList BLL_Sales_ContractList = new KNet.BLL.KNet_Sales_ContractList();
        KNet.Model.KNet_Sales_ContractList Model = BLL_Sales_ContractList.GetModelB(s_ID);
        try
        {
            this.ContractNo.Text = Model.ContractNo;
            this.DutyPerson.Text = base.Base_GetUserName(Model.DutyPerson);
            this.Stime.Text = DateTime.Parse(Model.ContractDateTime.ToString()).ToShortDateString();
            this.ContractPerson.Text = Model.ContentPerson;
            this.ContractToAddress.Text = Model.ContractToAddress;
            this.CustomerName.Text = base.Base_GetCustomerName_Link(Model.CustomerValue);
            KNet.BLL.KNet_ContractDate BLL_Date = new KNet.BLL.KNet_ContractDate();
            this.Tbx_OrderNo.Text = Model.KSC_OrderNO;

            string s_OrdeURL = Model.KSC_OrderURL == null ? "" : Model.KSC_OrderURL;
            if (s_OrdeURL != "")
            {
                this.Lbl_Details.Text = "<input Name=\"KSC_OrderURL\"  type=\"hidden\"  value=" + Model.KSC_OrderURL + "><input Name=\"KSC_OrderName\"  type=\"hidden\"  value=" + Model.KSC_OrderName + "><a href=\"" + Model.KSC_OrderURL + "\" >" + Model.KSC_OrderName + "</a>";
            }
            if (BLL_Date.GetOldDate(s_ID, 0) != "")
            {
                this.ContractToDeliDate.Text = DateTime.Parse(Model.ContractToDeliDate.ToString()).ToShortDateString() + " (<font Color=red>" + DateTime.Parse(BLL_Date.GetOldDate(s_ID, 0)).ToShortDateString() + "</font>)";
            }
            else
            {
                this.ContractToDeliDate.Text = DateTime.Parse(Model.ContractToDeliDate.ToString()).ToShortDateString();
            }
            if (BLL_Date.GetOldDate(s_ID, 1) != "")
            {
                this.ContractToDeliDate.Text = DateTime.Parse(Model.KFC_ReDate.ToString()).ToShortDateString() + " (<font Color=red>" + DateTime.Parse(BLL_Date.GetOldDate(s_ID, 1)).ToShortDateString() + "</font>)";
            }
            else
            {
                if (Model.KFC_ReDate != null)
                {
                    this.ContractToDeliDate.Text = DateTime.Parse(Model.KFC_ReDate.ToString()).ToShortDateString();
                }
            }
            this.Tbx_Telephone.Text = Model.Telephone;
            this.ContractDeliveMethods.Text = base.Base_GetKClaaName(Model.ContractDeliveMethods);
            this.ContractToPayment.Text = base.Base_GetCheckMethod(Model.ContractToPayment);
            this.ContractClass.Text = base.Base_GetKClaaName(Model.ContractClass);
            this.Drop_Payment.Text = base.Base_GetBasicCodeName("104", Model.Payment);
            this.Drop_RoutineTransport.Text = base.Base_GetBasicCodeName("102", Model.RoutineTransport);
            this.Drop_WorryTransport.Text = base.Base_GetBasicCodeName("103", Model.WorryTransport);
            this.Lbl_ContractShip.Text = Model.ContractShip;
            this.Lbl_Creator.Text = base.Base_GetUserName(Model.ContractStaffNo);
            this.Lbl_CTime.Text = Model.SystemDatetimes.ToString();
            if (Model.ContractCheckYN==true)
            {
            }

            KNet.BLL.Xs_Contract_ViewPerson BLL_View = new KNet.BLL.Xs_Contract_ViewPerson();
            KNet.Model.Xs_Contract_ViewPerson Model_View = new KNet.Model.Xs_Contract_ViewPerson();
            if (Model.ContractCheckYN == true)
            {
                Model_View.XCV_ID = GetNewID("Xs_Contract_ViewPerson", 1);
                Model_View.XCV_Person = AM.KNet_StaffNo;
                Model_View.XCV_State = "1";
                Model_View.XCV_Time = DateTime.Now;
                Model_View.XCV_ContractNo = s_ID;
                Model_View.XCV_Del = 1;
                try
                {
                    BLL_View.UpdateDel(Model_View);
                    BLL_View.Add(Model_View);
                }
                catch
                {

                }
            }
            if (Model.ProductsPic == 1)
            {
                this.Image1.Visible = true;
                this.Image1.ImageUrl = Model.ProductsSmallPicture;

                this.HyperLink1.Visible = true;
                this.HyperLink1.NavigateUrl = Model.ProductsBigPicture;

            }
            else
            {
                this.Image1.Visible = false;
                this.HyperLink1.Visible = false;
            }
            this.Tbx_TechnicalRequire.Text = Model.TechnicalRequire;
            this.Tbx_ProductPackaging.Text = Model.ProductPackaging;
            this.Tbx_QualityRequire.Text = Model.QualityRequire;
            this.Tbx_WarrantyPeriod.Text = Model.WarrantyPeriod;
            this.Tbx_DeliveryRequire.Text = Model.DeliveryRequire;
            this.ContractRemarks.Text = Model.ContractRemarks;
        KNet.BLL.Xs_Contract_Manage BLL_ContractManage=new KNet.BLL.Xs_Contract_Manage();
        KNet.Model.Xs_Contract_Manage Model_ContractManage = BLL_ContractManage.GetModel(Model.KSC_FaterId);
        if (Model_ContractManage != null)
        {
            this.Lbl_FaterCode.Text = "<a href=\"../Contract/Xs_Contract_Manage_View.aspx?ID=" + Model.KSC_FaterId + "\">" + Model_ContractManage.XCM_Code + "</a>";
            this.Lbl_Type.Text = base.Base_GetBasicCodeName("216",Model_ContractManage.XCM_Type);
        }
            KNet.BLL.KNet_Sales_ContractList_Details BLL_Details = new KNet.BLL.KNet_Sales_ContractList_Details();
            DataSet Dts_Details = BLL_Details.GetList(" ContractNo='" + Model.ContractNo + "'");
            if (Dts_Details.Tables[0].Rows.Count > 0)
            {
                int i_Num = 13;//单价限制
                //研发中心经理，市场销售部，总经理，财务部有权限查看金额
                if (AM.YNAuthority("销售单价查看") == false)
                {
                    i_Num = 10;//单价限制
                }
                s_MyTable_Detail += "  <tr valign=\"top\">\n";
                s_MyTable_Detail += "  <td  class=\"ListHead\" nowrap><b>产品名称</b></td>\n";
                s_MyTable_Detail += "  <td  class=\"ListHead\" nowrap><b>产品编码</b></td>\n";
                s_MyTable_Detail += "  <td  class=\"ListHead\" nowrap><b>型号</b></td>\n";
                s_MyTable_Detail += "  <td  class=\"ListHead\" nowrap><b>数量</b></td>\n";
                s_MyTable_Detail += "  <td  class=\"ListHead\" nowrap><b>备货数量</b></td>\n";
                if (i_Num == 8)
                {
                    s_MyTable_Detail += "  <td  class=\"ListHead\" nowrap><b>单价</b></td>\n";
                    s_MyTable_Detail += "  <td  class=\"ListHead\" nowrap><b>金额</b></td>\n";
                }
                s_MyTable_Detail += "  <td  class=\"ListHead\" nowrap><b>计划单号</b></td>\n";
                s_MyTable_Detail += "  <td  class=\"ListHead\" nowrap><b>订单号</b></td>\n";
                s_MyTable_Detail += "  <td  class=\"ListHead\" nowrap><b>客户料号</b></td>\n";
                s_MyTable_Detail += "  <td  class=\"ListHead\" nowrap><b>客户型号</b></td>\n";
                s_MyTable_Detail += "  <td  class=\"ListHead\" nowrap><b>是否随货</b></td>\n";
                s_MyTable_Detail += "  <td  class=\"ListHead\" nowrap><b>备注</b></td>\n";
                s_MyTable_Detail += "  <td  class=\"ListHead\" nowrap><b>电池</b></td>\n";
                s_MyTable_Detail += "  <td  class=\"ListHead\" nowrap><b>库存</b></td>\n";
                s_MyTable_Detail += "  </tr>\n";
                for (int i = 0; i < Dts_Details.Tables[0].Rows.Count; i++)
                {
                    s_MyTable_Detail += "<tr>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName_Link(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsCode(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["ContractAmount"].ToString() + "</td>";
                    if (Dts_Details.Tables[0].Rows[i]["KSC_BNumber"].ToString() == "0")
                    {
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\">&nbsp;</td>";
                    }
                    else
                    {
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["KSC_BNumber"].ToString() + "</td>";
                    }
                    if (i_Num == 8)
                    {
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["Contract_SalesUnitPrice"].ToString() + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["Contract_SalesTotalNet"].ToString() + "</td>";
                    }
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["KSD_PlanNumber"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["KSD_OrderNumber"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["KSD_MaterNumber"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["KSD_MaterPattern"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["KSD_IsFollow"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["ContractRemarks"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsPattern(Dts_Details.Tables[0].Rows[i]["KSC_Battery"].ToString()) + "</td>";

                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetHouseAndNumber(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "</tr>";
                }
            }
        }
        catch(Exception ex)
        {
        }
    }
    private void DataShow()
    {
        //string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
        //if (s_ID != "")
        //{
        //    KNet.BLL.KNet_Sales_ContractList BLL_Sales_ContractList = new KNet.BLL.KNet_Sales_ContractList();
        //    KNet.Model.KNet_Sales_ContractList Model = BLL_Sales_ContractList.GetModelB(Request.QueryString["ID"].ToString());
        //    this.ContractNo.Text = Model.ContractNo;
        //    this.ContractDateTime.Text = DateTime.Parse(Model.ContractDateTime.ToString()).ToShortDateString();
        //    this.CustomerName.Text = base.Base_GetCustomerName(Model.CustomerValue);
        //    this.ContractToAddress.Text = Model.ContractToAddress;
        //    


        //    KNet.BLL.Xs_Contract_ViewPerson BLL_View = new KNet.BLL.Xs_Contract_ViewPerson();
        //    KNet.Model.Xs_Contract_ViewPerson Model_View = new KNet.Model.Xs_Contract_ViewPerson();
        //    string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
        //    if ((Model.ContractCheckYN == true)&&(s_Type!=""))
        //    {
        //        AdminloginMess AM=new AdminloginMess();
        //        Model_View.XCV_ID = GetNewID("Xs_Contract_ViewPerson", 1);
        //        Model_View.XCV_Person = AM.KNet_StaffNo;
        //        Model_View.XCV_State = "1";
        //        Model_View.XCV_Time = DateTime.Now;
        //        Model_View.XCV_ContractNo = s_ID;
        //        Model_View.XCV_Del = 1;
        //        try
        //        {
        //            BLL_View.UpdateDel(Model_View);
        //            BLL_View.Add(Model_View);
        //        }
        //        catch
        //        {

        //        }
        //    }

        //    string s_Sqlwhere = "  XCV_Del='0' and XCV_ContractNo='" + s_ID + "' order by XCV_ID desc ";
        //    DataSet Ds1 = BLL_View.GetList(s_Sqlwhere);
        //    GridView2.DataSource = Ds1;
        //    GridView2.DataBind();

        //
        //    this.Lbl_DutyPerson.Text = base.Base_GetUserName(Model.DutyPerson);
        //    

        //    //明细
        //    this.BeginQuery("Select OrderNo,SuppNo From Knet_Procure_OrdersList Where ContractNo='" + this.ContractNo.Text + "'");
        //    this.QueryForDataTable();
        //    string s_OrderNo = "", s_SuppNo = "";
        //    if (this.Dtb_Result.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < Dtb_Result.Rows.Count; i++)
        //        {

        //            s_OrderNo = this.Dtb_Result.Rows[i][0].ToString();
        //            s_SuppNo = this.Dtb_Result.Rows[i][1].ToString();
        //            this.Lbl_Supplier.Text += base.Base_GetSupplierName(s_SuppNo) + ",";
        //            this.OrderNo.Text += "<a href=\"#\"  onclick=\"javascript:window.open('../Procure/Knet_Procure_OpenBilling_PrinterListSettingPrinterPage.aspx?OrderNo=" + s_OrderNo + "&PrinterModel=128917825766562500','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');\">" + s_OrderNo + "</a>"+",";


        //        }

        //    }

        //    this.BeginQuery("Select * From  KNet_Sales_OutWareList Where ContractNo='" + this.ContractNo.Text + "'");
        //    this.QueryForDataTable();
        //    if (this.Dtb_Result.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < Dtb_Result.Rows.Count; i++)
        //        {
        //            this.ShipNo.Text += "<a href=\"#\"  onclick=\"javascript:window.open('Knet_Sales_Ship_Manage_PrinterListSettingPrinterPage.aspx?OutWareNo=" + Dtb_Result.Rows[i]["OutWareNo"].ToString() + "&PrinterModel=128900331899375001','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');\">" + Dtb_Result.Rows[i]["OutWareNo"].ToString() + "</a>" +"   ";

        //        }
        //    }


        //    this.BeginQuery("Select * From  KNet_WareHouse_DirectOutList Where KWD_ShipNo in (Select OutWareNo from KNet_Sales_OutWareList where  ContractNo='" + this.ContractNo.Text + "')");
        //    this.QueryForDataTable();
        //    if (this.Dtb_Result.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < Dtb_Result.Rows.Count; i++)
        //        {
        //            this.DirectNo.Text += "<a href=\"#\"  onclick=\"javascript:window.open('/WareHouse/KNet_WareHouse_DirectOut_Manage_PrinterListSettingPage.aspx?DirectOutNo=" + Dtb_Result.Rows[i]["DirectOutNo"].ToString() + "&PrinterModel=128919258398906250','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');\">" + Dtb_Result.Rows[i]["DirectOutNo"].ToString() + "</a>" + "   ";

        //        }
        //    }
        //    this.BeginQuery("Select HouseNo from Knet_Procure_WareHouseList Where OrderNo='" + s_OrderNo + "' ");
        //    this.QueryForDataTable();
        //    string s_HouseNo = "";
        //    if (this.Dtb_Result.Rows.Count > 0)
        //    {
        //        s_HouseNo = this.Dtb_Result.Rows[0][0].ToString();
        //    }
        //    this.Lbl_House.Text = base.Base_GetHouseName(s_HouseNo);

        //    KNet.BLL.KNet_Sales_ContractList_Details BLL_Sales_ContractList_Details = new KNet.BLL.KNet_Sales_ContractList_Details();
        //    string s_Sql = " ContractNo='" + Model.ContractNo + "'";
        //    DataSet Dts_ContractList = BLL_Sales_ContractList_Details.GetList(s_Sql);
        //    MyGridView1.DataSource = Dts_ContractList;
        //    MyGridView1.DataBind();


        //    KNet.BLL.KNet_Sales_Flow Bll_Sales_Flow = new KNet.BLL.KNet_Sales_Flow();
        //    KNet.Model.KNet_Sales_Flow Model_Sales_Flow = new KNet.Model.KNet_Sales_Flow();
        //    GridView1.DataSource = Bll_Sales_Flow.GetList(" KSF_ContractNo='" + this.ContractNo.Text + "' and KFS_Type='0'  Order  by KSF_Date desc");
        //    this.GridView1.DataBind();
        // }

    }
    public string GetCgNumer(string s_ProductsBarCode)
    {
        try
        {
            this.BeginQuery("Select OrderAmount from Knet_Procure_OrdersList_Details Where ProductsBarCode='" + s_ProductsBarCode + "' and OrderNo in (Select OrderNo From Knet_Procure_OrdersList Where ContractNo='" + this.ContractNo.Text + "')");
            this.QueryForDataTable();
            if (Dtb_Result.Rows.Count > 0)
            {
                return Dtb_Result.Rows[0][0].ToString();
            }
            else
            {
                return "";
            }

        }
        catch (Exception ex)
        {
            return "";
        }
    }
    public string GetRkNumber(string s_ProductsBarCode)
    {
        this.BeginQuery("Select OrderHaveReceiving from Knet_Procure_OrdersList_Details Where ProductsBarCode='" + s_ProductsBarCode + "' and OrderNo in (Select OrderNo From Knet_Procure_OrdersList Where ContractNo='" + this.ContractNo.Text + "')");
        this.QueryForDataTable();
        if (Dtb_Result.Rows.Count > 0)
        {
            return Dtb_Result.Rows[0][0].ToString();
        }
        else
        {
            return "";
        }
    }
    public string GetFHNumber(string s_ProductsBarCode)
    {
        this.BeginQuery("Select Sum(OutWareAmount) from KNet_Sales_OutWareList_Details Where ProductsBarCode='" + s_ProductsBarCode + "' and OutWareNo in (Select OutWareNo From KNet_Sales_OutWareList Where ContractNo='" + this.ContractNo.Text + "')");
        this.QueryForDataTable();
        if (Dtb_Result.Rows.Count > 0)
        {
            return Dtb_Result.Rows[0][0].ToString();
        }
        else
        {
            return "";
        }
    }

    //流程
    public string GetFlowName(string s_Flow)
    {
        string s_FlowName = "";
        switch (s_Flow)
        {
            case "1":
                s_FlowName = "通过审核!";
                break;
            case "2":
                s_FlowName = "合同作废!";
                break;
            case "3":
                s_FlowName = "<font color='Blue'>异常通过!</font>";
                break;
            case "4":
                s_FlowName = "重新提交!";
                break;
            case "0":
                s_FlowName = "<font color='red'>不通过！</font>";
                break;
        }
        return s_FlowName;
    }
    protected void Btn_Sh_Click(object sender, EventArgs e)
    {

        OpenWebFormSize("ContractListCheckYN.aspx?ContractNo=" + this.Tbx_ID.Text, 400, 800, 110, 110);
    }
}
