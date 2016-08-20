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


public partial class Web_Sc_Expend_View : BasePage
{
    public string s_MyTable_Detail = "", s_MyTable_Detail1 = "", s_MyTable_Detail2="";
    protected void Page_Load(object sender, EventArgs e)
    {
        string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
        if (!Page.IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            this.Lbl_Title.Text = "查看生产消耗";
            if (AM.CheckLogin(this.Lbl_Title.Text) == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            if (AM.YNAuthority("生产入库审批") == true)
            {
                this.btn_Chcek.Visible = true;
            }
            else
            {
                this.btn_Chcek.Visible = false;

            }

        }
        if (s_ID != "")
        {
            ShowInfo(s_ID);
        } 
       
    }

    protected void btn_Chcek_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        if (btn_Chcek.Text == "审批")
        {
            string DoSql = "update Sc_Expend_Manage  set SEM_CheckYN=1,SEM_CheckStaffNo='" + AM.KNet_StaffNo + "',SEM_CheckTime='" + DateTime.Now.ToString() + "'  where  SEM_ID='" + this.Tbx_ID.Text + "' ";
            DbHelperSQL.ExecuteSql(DoSql);
            btn_Chcek.Text = "反审批";
        }
            
        else if (btn_Chcek.Text == "财务审批")
        {
            string DoSql = "update Sc_Expend_Manage  set SEM_CheckYN=2,SEM_CwCheckStaffNo='" + AM.KNet_StaffNo + "',SEM_CwCheckTime='" + DateTime.Now.ToString() + "'  where  SEM_ID='" + this.Tbx_ID.Text + "' ";
            DbHelperSQL.ExecuteSql(DoSql);
            btn_Chcek.Text = "反财务审批";
        }
        else if (btn_Chcek.Text == "反财务审批")
        {
            string DoSql = "update Sc_Expend_Manage  set SEM_CheckYN=1,SEM_CwCheckStaffNo ='',SEM_CwCheckTime=''  where  SEM_ID='" + this.Tbx_ID.Text + "' ";
            DbHelperSQL.ExecuteSql(DoSql);
            btn_Chcek.Text = "财务审批";
        }
        else
        {
            string DoSql = "update Sc_Expend_Manage  set SEM_CheckYN=0,SEM_CheckStaffNo ='',SEM_CheckTime=''  where  SEM_ID='" + this.Tbx_ID.Text + "' ";
            DbHelperSQL.ExecuteSql(DoSql);
            btn_Chcek.Text = "审批";
        }
        Alert("审批成功！");
    }
    private void ShowInfo(string s_ID)
    {
        AdminloginMess AM=new AdminloginMess();
        KNet.BLL.Sc_Expend_Manage bll = new KNet.BLL.Sc_Expend_Manage();
        KNet.Model.Sc_Expend_Manage model = bll.GetModel(s_ID);
        KNet.BLL.Sc_Expend_Manage_RCDetails bll_Rc = new KNet.BLL.Sc_Expend_Manage_RCDetails();
        DataSet Dts_Rc = bll_Rc.GetList(" SER_SEMID='" + s_ID + "'");
        KNet.BLL.Sc_Expend_Manage_MaterDetails bll_Mater = new KNet.BLL.Sc_Expend_Manage_MaterDetails();
        DataSet Dts_Mater = bll_Mater.GetList(" SED_SEMID='" + s_ID + "' and SED_Type='2' ");
        KNet.BLL.Knet_Procure_WareHouseList bll_WareHouse = new KNet.BLL.Knet_Procure_WareHouseList();
        DataSet Dts_WareHouse = bll_WareHouse.GetList(" WareHouseTopic='" + s_ID + "'");

        try
        {
            this.Tbx_ID.Text = s_ID;
            this.Lbl_BCode.Text = s_ID;

            if (model.SEM_CheckYN == 1)
            {
                btn_Chcek.Text = "反审批";
                if (AM.YNAuthority("单据财务审批"))
                {
                    btn_Chcek.Text = "财务审批";
                }
            }
            else if (model.SEM_CheckYN == 2)
            {
                if (AM.YNAuthority("单据财务审批"))
                {
                    btn_Chcek.Text = "反财务审批";
                }
            }
            else
            {
                btn_Chcek.Text = "审批";
            }
            this.Lbl_CustomerName.Text = model.SEM_CustomerName;
            this.Lbl_SuppNo.Text = base.Base_GetSupplierName_Link(model.SEM_SuppNo);
            this.Lbl_DutyPerson.Text = base.Base_GetUserName(model.SEM_DutyPerson);
            this.Lbl_ProductsEdition.Text = model.SEM_ProductsEdition;
            try{
                this.Lbl_Stime.Text = DateTime.Parse(model.SEM_Stime.ToString()).ToShortDateString();
            }
            catch{}
            if (Dts_Rc.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < Dts_Rc.Tables[0].Rows.Count; i++)
                {
                    s_MyTable_Detail += "<tr>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetHouseName(Dts_Rc.Tables[0].Rows[i]["SER_HouseNo"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName_Link(Dts_Rc.Tables[0].Rows[i]["SER_ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsCode(Dts_Rc.Tables[0].Rows[i]["SER_ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dts_Rc.Tables[0].Rows[i]["SER_ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Rc.Tables[0].Rows[i]["SER_ScNumber"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Rc.Tables[0].Rows[i]["SER_ScPrice"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Rc.Tables[0].Rows[i]["SER_ScMoney"].ToString() + "</td>";
                    s_MyTable_Detail += "</tr>";
                }
            }
            if (Dts_Mater.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < Dts_Mater.Tables[0].Rows.Count; i++)
                {
                    s_MyTable_Detail1 += "<tr>";
                    s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + Dts_Mater.Tables[0].Rows[i]["SED_ID"].ToString() + "</td>";
                    s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName_Link(Dts_Mater.Tables[0].Rows[i]["SED_ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsCode(Dts_Mater.Tables[0].Rows[i]["SED_ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dts_Mater.Tables[0].Rows[i]["SED_ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + base.Base_GetHouseName(Dts_Mater.Tables[0].Rows[i]["SED_HouseNo"].ToString()) + "</td>";
                    s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + base.Base_GetBasicCodeName("143", Dts_Mater.Tables[0].Rows[i]["SED_Type"].ToString()) + "</td>";
                    s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + base.Base_GetUserName(Dts_Mater.Tables[0].Rows[i]["SED_RkPerson"].ToString()) + "</td>";
                    s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + DateTime.Parse(Dts_Mater.Tables[0].Rows[i]["SED_RkTime"].ToString()).ToShortDateString() + "</td>";
                    s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + Dts_Mater.Tables[0].Rows[i]["SED_RkNumber"].ToString() + "</td>";
                    s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + Dts_Mater.Tables[0].Rows[i]["SED_RkPrice"].ToString() + "</td>";
                    s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + Dts_Mater.Tables[0].Rows[i]["SED_RkMoney"].ToString() + "</td>";
                    s_MyTable_Detail1 += "</tr>";
                }
            }
            
            
            if (Dts_WareHouse.Tables[0].Rows.Count > 0)
            {
                for(int i = 0; i < Dts_WareHouse.Tables[0].Rows.Count; i++)
                {
                        string s_RkPerson="",s_HouseNo="",s_HouseDateTime="";
                     try
                     {
                         s_HouseNo = base.Base_GetHouseName(Dts_WareHouse.Tables[0].Rows[i]["HouseNo"].ToString());
                     }
                     catch { }
                     try
                     {
                         s_HouseDateTime = DateTime.Parse(Dts_WareHouse.Tables[0].Rows[i]["WareHouseDateTime"].ToString()).ToShortDateString();
                     }
                     catch { }
                    try
                    {
                        s_RkPerson = base.Base_GetUserName(Dts_WareHouse.Tables[0].Rows[i]["KPW_Creator"].ToString());
                    }
                    catch { }
                    KNet.BLL.Knet_Procure_WareHouseList_Details bll_WareHouseDetails = new KNet.BLL.Knet_Procure_WareHouseList_Details();
                    DataSet Dts_WareHouseDetails = bll_WareHouseDetails.GetList(" WareHouseNo='" + Dts_WareHouse.Tables[0].Rows[i]["WareHouseNo"].ToString()+ "'");
                    if (Dts_WareHouseDetails.Tables[0].Rows.Count > 0)
                    {
                        for (int j = 0; j < Dts_WareHouseDetails.Tables[0].Rows.Count; j++)
                        {
                            s_MyTable_Detail2 += "<tr>";
                            s_MyTable_Detail2 += "<td class=\"ListHeadDetails\">" + Dts_WareHouseDetails.Tables[0].Rows[j]["WareHouseNo"].ToString() + "</td>";
                            s_MyTable_Detail2 += "<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName(Dts_WareHouseDetails.Tables[0].Rows[j]["ProductsBarCode"].ToString()) + "</td>";
                            s_MyTable_Detail2 += "<td class=\"ListHeadDetails\">" + Dts_WareHouseDetails.Tables[0].Rows[j]["ProductsBarCode"].ToString() + "</td>";
                            s_MyTable_Detail2 += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dts_WareHouseDetails.Tables[0].Rows[j]["ProductsBarCode"].ToString()) + "</td>";
                            s_MyTable_Detail2 += "<td class=\"ListHeadDetails\">" + s_HouseNo + "</td>";
                            s_MyTable_Detail2 += "<td class=\"ListHeadDetails\">" + s_RkPerson + "</td>";
                            s_MyTable_Detail2 += "<td class=\"ListHeadDetails\">" + s_HouseDateTime + "</td>";
                            s_MyTable_Detail2 += "<td class=\"ListHeadDetails\">" + Dts_WareHouseDetails.Tables[0].Rows[j]["WareHouseAmount"].ToString() + "</td>";
                            s_MyTable_Detail2 += "<td class=\"ListHeadDetails\">" + Dts_WareHouseDetails.Tables[0].Rows[j]["WareHouseUnitPrice"].ToString() + "</td>";
                            s_MyTable_Detail2 += "<td class=\"ListHeadDetails\">" + Dts_WareHouseDetails.Tables[0].Rows[j]["WareHouseTotalNet"].ToString() + "</td>";
                            s_MyTable_Detail2 += "</tr>";
                        }
 
                    }
                }
            }
        }
        catch
        {}
    }

}
