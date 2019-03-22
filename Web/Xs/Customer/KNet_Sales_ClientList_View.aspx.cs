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


public partial class Web_KNet_Sales_ClientList_View : BasePage
{
    public string s_MyTable_Detail = "", s_OrderStyle = "", s_DetailsStyle = "", s_StructureStyle = "", s_Structure = "", s_MyTable_Detail1 = "", s_MyTable_Detail2="";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("客户查看") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            this.Lbl_Title.Text = "客户查看";
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            string s_ID = Request.QueryString["CustomerValue"] == null ? "" : Request.QueryString["CustomerValue"].ToString();


            s_OrderStyle = "class=\"dvtUnSelectedCell\"";
            if (s_ID != "")
            {
                ShowInfo(s_ID);
            }
        }
    }

    public string GetShipType(string s_OutWareNo)
    {
        string s_Return = "";
        try
        {
            if (s_OutWareNo != "")
            {
                KNet.BLL.KNet_Sales_OutWareList Bll = new KNet.BLL.KNet_Sales_OutWareList();
                KNet.Model.KNet_Sales_OutWareList Model = Bll.GetModelB(s_OutWareNo);
                s_Return = base.Base_GetBasicCodeName("145", Model.KSO_Type);
            }
            else
            {
                s_Return = "正常";
            }
        }
        catch { }
        return s_Return;
    }
    private void ShowInfo(string s_ID)
    {

        KNet.BLL.KNet_Sales_ClientList BLL = new KNet.BLL.KNet_Sales_ClientList();
        if (Request["CustomerValue"] != null && Request["CustomerValue"] != "")
        {
            string CustomerValue = Request.QueryString["CustomerValue"].ToString().Trim();
            if (GetKNet_Sys_ProductsYN(CustomerValue) == true)
            {

                KNet.Model.KNet_Sales_ClientList model = BLL.GetModelB(CustomerValue);

                this.CustomerName.Text = model.CustomerName;
                this.CustomerValue.Text = base.Base_GetCustomerCode(model.CustomerValue);

                this.CustomerClass.Text = GetClient_NameName(model.CustomerClass);
                this.CustomerTypes.Text = GetClient_NameName(model.CustomerTypes);
                this.CustomerTrade.Text = GetClient_NameName(model.CustomerTrade);
                this.CustomerSource.Text = GetClient_NameName(model.CustomerSource);
                this.Tbx_SampleName.Text = model.KSC_SampleName;
                this.CustomerProvinces.Text = GetProvinceNane(model.CustomerProvinces);
                this.CustomerCity.Text = GetCityNane(model.CustomerCity);

                this.CustomerContact.Text = model.CustomerContact + "&nbsp;&nbsp;&nbsp;&nbsp;性别:" + model.CustomerContactSex;

                if (model.CustomerProtect == true)
                {
                    this.CustomerProtect.Text = "<B>受保护客户</B>";
                }
                else
                {
                    this.CustomerProtect.Text = "<B>普通客户</B>";
                }

                this.CustomerMobile.Text = model.CustomerMobile;
                this.CustomerTel.Text = model.CustomerTel;
                this.CustomerWebsite.Text = model.CustomerWebsite;
                this.CustomerEmail.Text = model.CustomerEmail;
                this.CustomerQQ.Text = model.CustomerQQ;
                this.CustomerMsn.Text = model.CustomerMsn;
                this.CustomerAddress.Text = model.CustomerAddress;
                this.CustomerZipCode.Text = model.CustomerZipCode;
                this.CustomerIntegral.Text = model.CustomerIntegral.ToString();

                this.CustomerIntroduction.Text = model.CustomerIntroduction;
                this.Lbl_DutyPerson.Text = base.Base_GetUserName(model.KSC_DutyPerson);
                this.Lbl_Auxiliary.Text = base.Base_GetUserName(model.KSC_Auxiliary);
                this.Lbl_DutyPerson1.Text = base.Base_GetUserName(model.KSC_DutyPerson1);
                this.Lbl_Auxiliary1.Text = base.Base_GetUserName(model.KSC_Auxiliary1);
                this.Lbl_PayMent.Text = base.Base_GetBasicCodeName("104", model.KSC_PayMent);
                this.Lbl_KPType.Text = base.Base_GetBasicCodeName("768", model.KSC_KPType);
                this.Lbl_DlPrice.Text = model.KSC_DlPrice.ToString();

                try
                {
                    this.CustomerAddtime.Text = DateTime.Parse(model.CustomerAddtime.ToString()).ToShortDateString();
                }
                catch { }


                KNet.BLL.Xs_Customer_Products BLL_Customer_Products = new KNet.BLL.Xs_Customer_Products();
                string s_ProductsID = "";
                DataSet Dts_Customer_Products = BLL_Customer_Products.GetList(" XCP_CustomerID='" + model.CustomerValue + "' and XCP_ProductsID<>'' and len(XCP_ProductsID)='17'");
                if (Dts_Customer_Products.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < Dts_Customer_Products.Tables[0].Rows.Count; i++)
                    {
                        s_ProductsID += Dts_Customer_Products.Tables[0].Rows[i]["XCP_ProductsID"].ToString() + ",";
                        s_MyTable_Detail += "<tr>";
                        s_MyTable_Detail += "<td class='ListHeadDetails' width='3%'>" + (i + 1) + "</td>";
                        s_MyTable_Detail += "<td class='ListHeadDetails'><input type=\"hidden\" input Name=\"ProductsBarCode\" value='" + Dts_Customer_Products.Tables[0].Rows[i]["XCP_ProductsID"].ToString() + "'>" + base.Base_GetProductsCode(Dts_Customer_Products.Tables[0].Rows[i]["XCP_ProductsID"].ToString()) + "</td>";
                        s_MyTable_Detail += "<td class='ListHeadDetails'><input type=\"hidden\" input Name=\"ProductsName\" value='" + base.Base_GetProdutsName(Dts_Customer_Products.Tables[0].Rows[i]["XCP_ProductsID"].ToString()) + "'>" + base.Base_GetProdutsName_Link(Dts_Customer_Products.Tables[0].Rows[i]["XCP_ProductsID"].ToString()) + "</td>";
                        KNet.BLL.KNet_Sys_Products BLL_Sys_Products = new KNet.BLL.KNet_Sys_Products();
                        KNet.Model.KNet_Sys_Products Model_Sys_Products = BLL_Sys_Products.GetModelB(Dts_Customer_Products.Tables[0].Rows[i]["XCP_ProductsID"].ToString());
                        s_MyTable_Detail += "<td class='ListHeadDetails'><input type=\"hidden\" input Name=\"ProductsPattern\" value='" + base.Base_GetProductsEdition(Dts_Customer_Products.Tables[0].Rows[i]["XCP_ProductsID"].ToString()) + "'>" + base.Base_GetProductsEdition(Dts_Customer_Products.Tables[0].Rows[i]["XCP_ProductsID"].ToString()) + "</td>";
                        s_MyTable_Detail += "</tr>";
                    }

                }


                string s_Sql = "Select * from Xs_Customer_Customer a join KNet_Sales_ClientList b on a.XCD_CustomerValue =b.CustomerValue where XCD_DLCustomerValue='" + model.CustomerValue + "'  order by CustomerName";
                this.BeginQuery(s_Sql);
                DataTable Dtb_DlCustomer=(DataTable)this.QueryForDataTable();
                if (Dtb_DlCustomer.Rows.Count > 0)
                {
                    for (int i = 0; i < Dtb_DlCustomer.Rows.Count; i++)
                    {
                        s_MyTable_Detail1 += "<tr>";
                        s_MyTable_Detail1 += "<td class='ListHeadDetails' width='3%'>" + (i + 1) + "</td>";
                        s_MyTable_Detail1 += "<td class='ListHeadDetails' >" + Dtb_DlCustomer.Rows[i]["CustomerName"].ToString() + "</td>";
                        s_MyTable_Detail1 += "</tr>";
                    }

                }


                s_Sql = "Select * from Xs_Customer_DlPrice where XCD_CustomerValue='" + model.CustomerValue + "'  ";
                this.BeginQuery(s_Sql);
                DataTable Dtb_DlPrice = (DataTable)this.QueryForDataTable();
                if (Dtb_DlPrice.Rows.Count > 0)
                {
                    for (int i = 0; i < Dtb_DlPrice.Rows.Count; i++)
                    {
                        s_MyTable_Detail2 += "<tr>";
                        s_MyTable_Detail2 += "<td class='ListHeadDetails' width='3%'>" + (i + 1) + "</td>";
                        s_MyTable_Detail2 += "<td class='ListHeadDetails' >" + Dtb_DlPrice.Rows[i]["XCD_Min"].ToString() + "</td>";
                        s_MyTable_Detail2 += "<td class='ListHeadDetails' >" + Dtb_DlPrice.Rows[i]["XCD_Price"].ToString() + "</td>";
                        s_MyTable_Detail2 += "<td class='ListHeadDetails' >" + Dtb_DlPrice.Rows[i]["XCD_Max"].ToString() + "</td>";
                        s_MyTable_Detail2 += "<td class='ListHeadDetails' >" + Dtb_DlPrice.Rows[i]["XCD_OutDateTim"].ToString() + "</td>";
                        s_MyTable_Detail2 += "</tr>";
                    }

                }

                KNet.BLL.Xs_Customer_FhInfo Bll = new KNet.BLL.Xs_Customer_FhInfo();
                DataSet Dts_FhInfo = Bll.GetList("  XCF_CustomerValue='" + model.CustomerValue + "'");
                if (Dts_FhInfo.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < Dts_FhInfo.Tables[0].Rows.Count; i++)
                    {
                        Lbl_FhDetails.Text += "<tr>";
                        Lbl_FhDetails.Text += "<td class='ListHeadDetails' width='3%'>" + (i + 1) + "</td>";
                        Lbl_FhDetails.Text += "<td class='ListHeadDetails' width='27%'>" + Dts_FhInfo.Tables[0].Rows[i]["XCF_Name"].ToString() + "</td>";
                        Lbl_FhDetails.Text += "<td class='ListHeadDetails'  width='70%'>" + Dts_FhInfo.Tables[0].Rows[i]["XCF_Details"].ToString() + "</td>";
                        Lbl_FhDetails.Text += "</tr>";
                    }
                }


                KNet.BLL.KNet_Sales_ContractList Bll_ContractList = new KNet.BLL.KNet_Sales_ContractList();
                GridView1.DataSource = Bll_ContractList.GetList(" CustomerValue='" + CustomerValue + "' Order  by ContractDateTime desc");

                GridView1.DataKeyNames = new string[] { "ContractNo" };
                GridView1.DataBind();



                KNet.BLL.Knet_Procure_OrdersList bll_Order = new KNet.BLL.Knet_Procure_OrdersList();
                string SqlWhere = "  ContractNo in (Select ContractNo from KNet_Sales_ContractList Where CustomerValue='" + CustomerValue + "') order by SYstemDateTimes desc";
                DataSet ds = bll_Order.GetList(SqlWhere);

                GridView_Order.DataSource = ds.Tables[0];
                GridView_Order.DataKeyNames = new string[] { "OrderNo" };
                GridView_Order.DataBind();

                KNet.BLL.KNet_Sales_OutWareList bllShip = new KNet.BLL.KNet_Sales_OutWareList();
                SqlWhere = " CustomerValue='" + CustomerValue + "' order by SYstemDateTimes desc";
                DataSet ds_Ship = bllShip.GetList(SqlWhere);

                GridView_Ship.DataSource = ds_Ship.Tables[0];
                GridView_Ship.DataBind();



                SqlWhere = " XOL_Compy='" + CustomerValue + "' and Isnull(XOL_Type,'101')='101' Order by XOL_CDate desc";
                KNet.BLL.XS_Compy_LinkMan bll = new KNet.BLL.XS_Compy_LinkMan();
                DataSet ds_LinkMan = bll.GetList(SqlWhere);
                this.GridView_LinkMan.DataSource = ds_LinkMan;
                GridView_LinkMan.DataBind();

                SqlWhere = " XSC_CustomerValue='" + CustomerValue + "' Order by XSC_MTime desc ";
                KNet.BLL.Xs_Sales_Content bll_Content = new KNet.BLL.Xs_Sales_Content();
                DataSet ds_Content = bll_Content.GetList(SqlWhere);
                this.GridView_Contenct.DataSource = ds_Content;
                GridView_Contenct.DataBind();

                KNet.BLL.KNet_WareHouse_DirectOutList BLL_DirectOutList = new KNet.BLL.KNet_WareHouse_DirectOutList();
                SqlWhere = " KWD_Custmoer='" + CustomerValue + "' order by KWD_CwOutTime desc";
                DataSet ds2 = BLL_DirectOutList.GetList(SqlWhere);
                this.MyGridView2.DataSource = ds2;
                this.MyGridView2.DataKeyNames = new string[] { "DirectOutNo" };
                this.MyGridView2.DataBind();

                AdminloginMess AM = new AdminloginMess();


                //仅查看自己
                SqlWhere = " 1=1 ";
                SqlWhere += " and XSO_CustomerValue='" + CustomerValue + "' ";
                if (AM.YNAuthority("销售机会仅自己查看") == true)
                {
                    if (AM.KNet_StaffName != "薛建新")
                    {
                        SqlWhere += " and (XSO_Creator='" + AM.KNet_StaffNo + "' ";
                        //共享给自己的
                        SqlWhere += " or XSO_DID in (Select PBS_FromID From PB_Basic_Share where PBS_ToPersonID='" + AM.KNet_StaffNo + "')";
                        //辅助人员
                        SqlWhere += " or XSO_FDutyPerson='" + AM.KNet_StaffNo + "') ";
                    }
                }
                SqlWhere += " Order by cast(XSO_CTime as dateTime)  desc";
                KNet.BLL.Xs_Sales_Opp bll_Opp = new KNet.BLL.Xs_Sales_Opp();
                DataSet ds_Opp = bll_Opp.GetList(SqlWhere);
                this.MyGridView1.DataSource = ds_Opp;
                MyGridView1.DataKeyNames = new string[] { "XSO_DID" };
                MyGridView1.DataBind();

                s_Structure = base.GetClient_StructureTree(Request["CustomerValue"]);

                this.CommentList1.CommentFID = CustomerValue;
                this.CommentList1.CommentType = 1;
                this.CommentList2.CommentFID = CustomerValue;
                this.CommentList2.CommentType = "Customer";
            }
            else
            {
                Response.Write("<script language=javascript>alert('该客户已不存在,或数据出错！');window.close();</script>");
                Response.End();
            }
        }
        else
        {
            Response.Write("<script language=javascript>alert('非法参数！');window.close();</script>");
            Response.End();
        }
    }

    protected string GetDirectOutListfollowup(object DirectOutNo, object DirectOutCheckYN)
    {
        string s_Return = "";
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select top 1 * from KNet_Sales_OutWareList_FlowList where OutWareNo='" + DirectOutNo + "' order by FollowDateTime desc";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                if (dr["KSO_ISFH"].ToString() == "101")
                {
                    s_Return = "<img src=\"../images/takman.gif\" width=\"11\" height=\"14\" border=\"0\" /><a href=\"#\" style=\"line-height: 22px;\" onclick=\"lhgdialog.opendlg('出库单号:<font color=Red>" + DirectOutNo + "</font> 跟踪', '../SalesOut/Knet_Sales_Ship_Manage_Talks_List.aspx?DirectOutNo=" + DirectOutNo + "', 780, 500,false,false);\">" + KNetPage.CutString(dr["FollowText"].ToString().Trim(), 40) + "&nbsp;<font color=red>已发</font></a>";//&nbsp;<font color=\"gray\">" + base.Base_GetUserName(dr["FollowStaffNo"].ToString()) + "&nbsp;(" + dr["FollowDateTime"].ToString() + ")</font>

                }
                else
                {
                    s_Return = "<img src=\"../images/takman.gif\" width=\"11\" height=\"14\" border=\"0\" /><a href=\"#\" style=\"line-height: 22px;\" onclick=\"lhgdialog.opendlg('出库单号:<font color=Red>" + DirectOutNo + "</font> 跟踪', '../SalesOut/Knet_Sales_Ship_Manage_Talks_List.aspx?DirectOutNo=" + DirectOutNo + "', 780, 500,false,false);\">" + KNetPage.CutString(dr["FollowText"].ToString().Trim(), 40) + "</a>&nbsp;<img src=\"../images/45.gif\" width=\"11\" height=\"11\" border=\"0\" />";

                    s_Return += "<a href=\"#\" onclick=\"lhgdialog.opendlg('出库单号:<font color=Red>" + DirectOutNo + "</font> 跟踪', '../SalesOut/Knet_Sales_Ship_Manage_Talks_Add.aspx?DirectOutNo=" + DirectOutNo + "', 780, 500,false,false);\">添加</a>";

                }
                return s_Return;
            }
            else
            {
                return "<a href=\"#\" onclick=\"lhgdialog.opendlg('出库单号:<font color=Red>" + DirectOutNo + "</font> 跟踪', '../SalesOut/Knet_Sales_Ship_Manage_Talks_Add.aspx?DirectOutNo=" + DirectOutNo + "', 780, 500,false,false);\">添加</a>";
            }
        }
    }


    protected string GetOrderCheckYN(object aa)
    {
        string s_Return = "";
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,DirectOutNo,DirectOutCheckYN,KWD_IsMail from KNet_WareHouse_DirectOutList where DirectOutNo='" + aa + "' ";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["DirectOutCheckYN"].ToString() == "2")
                {
                    s_Return = "<font color=Green>仓库已审</font>";
                }
                else if (dr["DirectOutCheckYN"].ToString() == "3")
                {
                    s_Return = "<font color=red>财务已审</font>";
                }
                else if (dr["DirectOutCheckYN"].ToString() == "1")
                {
                    s_Return = "<font color=yellow>已审</font>";
                }
                else
                {
                    s_Return = "<font color=blue>未审核</font>";
                }
                if (dr["KWD_IsMail"].ToString() == "0")
                {
                    s_Return += "<br/><a href='Sales_ShipWareOut_Manage.aspx?ID=" + dr["ID"].ToString() + "&Model=IsSend'><font color=blue>未发送</font></a>";
                }
                else if (dr["KWD_IsMail"].ToString() == "1")
                {
                    s_Return += "<br/><a href='Sales_ShipWareOut_Manage.aspx?ID=" + dr["ID"].ToString() + "&Model=IsSend'><font color=red>已发送</font></a>";
                }
                return s_Return;
            }
            else
            {
                return "--";
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
                    return "<img src=\"/Web/images/takman.gif\" width=\"11\" height=\"14\" border=\"0\" /><a href=\"#\" style=\"line-height: 22px;\" onclick=\"lhgdialog.opendlg('发货单号:<font color=Red>" + OutWareNo + "</font> 跟踪', '../Sales/Knet_Sales_Ship_Manage_Talks_List.aspx?OutWareNo=" + OutWareNo + "', 780, 400,false,false);\">" + KNetPage.CutString(dr["FollowText"].ToString().Trim(), 40) + "</a>&nbsp;<font color=red>结束</font>";//&nbsp;<font color=\"gray\">" + base.Base_GetUserName(dr["FollowStaffNo"].ToString()) + "&nbsp;(" + dr["FollowDateTime"].ToString() + ")</font>
                }
                else
                {
                    return "<img src=\"/Web/images/takman.gif\" width=\"11\" height=\"14\" border=\"0\" /><a href=\"#\" style=\"line-height: 22px;\" onclick=\"lhgdialog.opendlg('发货单号:<font color=Red>" + OutWareNo + "</font> 跟踪', '../Sales/Knet_Sales_Ship_Manage_Talks_List.aspx?OutWareNo=" + OutWareNo + "', 780, 400,false,false);\">" + KNetPage.CutString(dr["FollowText"].ToString().Trim(), 40) + "</a>&nbsp;<img src=\"/Web/images/45.gif\" width=\"11\" height=\"11\" border=\"0\" /><a href=\"#\" onclick=\"lhgdialog.opendlg('发货单号:<font color=Red>" + OutWareNo + "</font> 跟踪', '../Sales/Knet_Sales_Ship_Manage_Talks_Add.aspx?OutWareNo=" + OutWareNo + "', 780, 400,false,false);\">添加</a>";
                }
            }
            else
            {
                return "<a href=\"#\" onclick=\"lhgdialog.opendlg('发货单号:<font color=Red>" + OutWareNo + "</font> 跟踪', '../Sales/Knet_Sales_Ship_Manage_Talks_Add.aspx?OutWareNo=" + OutWareNo + "', 780, 400,false,false);\">添加</a>";
            }
        }
    }
    /// <summary>
    ///是否存在记录
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected bool GetKNet_Sys_ProductsYN(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,CustomerValue,CustomerName from KNet_Sales_ClientList where CustomerValue='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }


    /// <summary>
    /// 返回城区名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetCityNane(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select [ID],[name],[code] from KNet_Static_City where code='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["name"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }
    /// <summary>
    /// 返回省份名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetProvinceNane(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select [ID],[name],[code] from KNet_Static_Province where ID='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["name"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }
    /// <summary>
    /// 返回行业等属性值
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetClient_NameName(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,ClientValue,Client_Name from KNet_Sales_ClientAppseting where ClientValue='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["Client_Name"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }

}
