﻿using System;
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
using KNet.BLL;
using KNet.DBUtility;
using KNet.Common;
using KNet.Model;


public partial class Web_Sc_Expend_View : BasePage
{
    public string s_MyTable_Detail = "", s_MyTable_Detail1 = "", s_MyTable_Detail2="", s_ID;
    protected void Page_Load(object sender, EventArgs e)
    {
         s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
        Session["SED_SEMID"] = s_ID;
        if (!Page.IsPostBack)
        {
            this.AddExpend.Visible = false;
            //this.text1.Value = Request.QueryString["SER_ProductsBarCode"].ToString();
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
            //Session["SED_HouseNo"] = model.SEM_SuppNo;
            this.Lbl_DutyPerson.Text = base.Base_GetUserName(model.SEM_DutyPerson);
            Session["SED_RkPerson"] = model.SEM_DutyPerson;
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
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Rc.Tables[0].Rows[i]["SER_ScHandPrice"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Rc.Tables[0].Rows[i]["SER_ScHandMoney"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Rc.Tables[0].Rows[i]["SER_MaterPrice"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Rc.Tables[0].Rows[i]["SER_MaterMoney"].ToString() + "</td>";
     
                    s_MyTable_Detail += "</tr>";
                }
            }
            decimal HS_Number = 0;//实际耗损
            decimal LL_Number = 0;//理论消耗数量
            if (Dts_Mater.Tables[0].Rows.Count > 0)
            {
                if (Request.QueryString["SEM_CheckYN"].ToString() == "0"|| Request.QueryString["SEM_CheckYN"].ToString() == "1")
                {
                    this.Button1.Visible = true;
                    this.CZ_Done.Visible = true;
                   
                    for (int i = 0; i < Dts_Mater.Tables[0].Rows.Count; i++)
                    {
                        this.TextBox1.Text = Dts_Mater.Tables[0].Rows[i]["SED_HouseNo"].ToString();
                        s_MyTable_Detail1 += "<tr>";
                        s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + Convert.ToString(i + 1) + "</td>";
                        s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + Dts_Mater.Tables[0].Rows[i]["SED_ID"].ToString() + "</td>";

                        //s_MyTable_Detail1 +=
                        //  "<td class='ListHeadDetails'><a class='deleteExpend' id=" + Dts_Mater.Tables[0].Rows[i]["SED_ID"].ToString() + " href='javascript:void(0);'>删除</a></td>";
                        s_MyTable_Detail1 +=
                        "<td class='ListHeadDetails'><A class='deleteExpend' id=" + Dts_Mater.Tables[0].Rows[i]["SED_ID"].ToString() + " href='javascript:void(0);'><img id=\"deleteExpend\" src=\"../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a></td>";
                        //  s_MyTable_Detail1 +=
                        //"<td class='ListHeadDetails'><A onclick=\"{if(confirm('确定要删除这个物料吗 ? ')) {deleteCurrentRow(this); }else {}}\" href=\"#\"><img id=\"deleteExpend\" src=\"../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a></td>";
                        s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + GetReplace(Dts_Mater.Tables[0].Rows[i]["SED_ProductsBarCode"].ToString()) + "</td>";
                        s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName_Link(Dts_Mater.Tables[0].Rows[i]["SED_ProductsBarCode"].ToString()) + "</td>";
                        s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsCode(Dts_Mater.Tables[0].Rows[i]["SED_ProductsBarCode"].ToString()) + "</td>";
                        s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dts_Mater.Tables[0].Rows[i]["SED_ProductsBarCode"].ToString()) + "</td>";
                        s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + base.Base_GetHouseName(Dts_Mater.Tables[0].Rows[i]["SED_HouseNo"].ToString()) + "</td>";
                        s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + base.Base_GetBasicCodeName("143", Dts_Mater.Tables[0].Rows[i]["SED_Type"].ToString()) + "</td>";
                        s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + base.Base_GetUserName(Dts_Mater.Tables[0].Rows[i]["SED_RkPerson"].ToString()) + "</td>";
                        s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + DateTime.Parse(Dts_Mater.Tables[0].Rows[i]["SED_RkTime"].ToString()).ToShortDateString() + "</td>";
                        s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + Dts_Mater.Tables[0].Rows[i]["SED_RkNumber"].ToString() + "</td>";
                        HS_Number += decimal.Parse(Dts_Mater.Tables[0].Rows[i]["SED_RkNumber"].ToString());//实际实际耗损
                        s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + base.Base_GetBasicCodeName("1136", Dts_Mater.Tables[0].Rows[i]["SED_LossType"].ToString()) + "</td>";

                        s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + base.FormatNumber1(Dts_Mater.Tables[0].Rows[i]["SED_LossPercent"].ToString(), 2) + "</td>";

                        s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + Dts_Mater.Tables[0].Rows[i]["SED_LossNumber"].ToString() + "</td>";
                        s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + Dts_Mater.Tables[0].Rows[i]["SED_NeedNumber"].ToString() + "</td>";
                        LL_Number += decimal.Parse(Dts_Mater.Tables[0].Rows[i]["SED_NeedNumber"].ToString());//理论消耗数量
                        s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + Dts_Mater.Tables[0].Rows[i]["SED_WwPrice"].ToString() + "</td>";
                        s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + Dts_Mater.Tables[0].Rows[i]["SED_WwMoney"].ToString() + "</td>";
                         s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + Dts_Mater.Tables[0].Rows[i]["SED_Remarks"].ToString() + "</td>";
                        s_MyTable_Detail1 += "</tr>";
                    }
                    Label1.Text = HS_Number.ToString();
                    Label2.Text = LL_Number.ToString();
                }
                else
                {
                    this.Button1.Visible = false;
                    this.CZ_Done.Visible =false;
                    for (int i = 0; i < Dts_Mater.Tables[0].Rows.Count; i++)
                    {
                        this.TextBox1.Text = Dts_Mater.Tables[0].Rows[i]["SED_HouseNo"].ToString();
                        s_MyTable_Detail1 += "<tr>";
                        s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + Convert.ToString(i + 1) + "</td>";
                        s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + Dts_Mater.Tables[0].Rows[i]["SED_ID"].ToString() + "</td>";
                        s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName_Link(Dts_Mater.Tables[0].Rows[i]["SED_ProductsBarCode"].ToString()) + "</td>";
                        s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsCode(Dts_Mater.Tables[0].Rows[i]["SED_ProductsBarCode"].ToString()) + "</td>";
                        s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dts_Mater.Tables[0].Rows[i]["SED_ProductsBarCode"].ToString()) + "</td>";
                        s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + base.Base_GetHouseName(Dts_Mater.Tables[0].Rows[i]["SED_HouseNo"].ToString()) + "</td>";
                        s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + base.Base_GetBasicCodeName("143", Dts_Mater.Tables[0].Rows[i]["SED_Type"].ToString()) + "</td>";
                        s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + base.Base_GetUserName(Dts_Mater.Tables[0].Rows[i]["SED_RkPerson"].ToString()) + "</td>";
                        s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + DateTime.Parse(Dts_Mater.Tables[0].Rows[i]["SED_RkTime"].ToString()).ToShortDateString() + "</td>";
                        s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + Dts_Mater.Tables[0].Rows[i]["SED_RkNumber"].ToString() + "</td>";
                        HS_Number += decimal.Parse(Dts_Mater.Tables[0].Rows[i]["SED_RkNumber"].ToString());//实际实际耗损
                        s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + base.Base_GetBasicCodeName("1136", Dts_Mater.Tables[0].Rows[i]["SED_LossType"].ToString()) + "</td>";

                        s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + base.FormatNumber1(Dts_Mater.Tables[0].Rows[i]["SED_LossPercent"].ToString(), 2) + "</td>";

                        s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + Dts_Mater.Tables[0].Rows[i]["SED_LossNumber"].ToString() + "</td>";
                        s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + Dts_Mater.Tables[0].Rows[i]["SED_NeedNumber"].ToString() + "</td>";
                        LL_Number += decimal.Parse(Dts_Mater.Tables[0].Rows[i]["SED_NeedNumber"].ToString());//理论消耗数量
                        s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + Dts_Mater.Tables[0].Rows[i]["SED_WwPrice"].ToString() + "</td>";
                        s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + Dts_Mater.Tables[0].Rows[i]["SED_WwMoney"].ToString() + "</td>";
                        s_MyTable_Detail1 += "<td class=\"ListHeadDetails\">" + Dts_Mater.Tables[0].Rows[i]["SED_Remarks"].ToString() + "</td>";
                        s_MyTable_Detail1 += "</tr>";
                    }
                    Label1.Text = HS_Number.ToString();
                    Label2.Text = LL_Number.ToString();
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

    public string GetReplace(string productbarcode)
    {
        string s_Return = "";
        this.BeginQuery("select ReplaceNum from Xs_Products_Prodocts_Demo where XPD_ProductsBarCode='"+ productbarcode + "'");
        this.QueryForDataTable();
        DataTable Dtb_Re = Dtb_Result;
        if (Dtb_Re.Rows.Count>0)
        {
            if (Dtb_Re.Rows[0][0].ToString() == "0")
            {
                s_Return = "<font color=blue>主料</font>";
            }
            else
            {
                s_Return = "<font color=red>替料" + Dtb_Re.Rows[0][0].ToString() + "</font>";
            }
            return s_Return;
        }
        else
        {
            return s_Return= "<font color=blue>主料</font>"; ;
        }
       
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        //base.Base_DropBasicCodeBind(this.GenreDropDownList, "1136");

        KNet.BLL.Sc_Expend_Manage_MaterDetails bll_Mater = new KNet.BLL.Sc_Expend_Manage_MaterDetails();
        DataSet Dts_Mater = bll_Mater.GetList(" SED_Type='2' order by SED_ID desc");
        this.OddNumbers.Text =(Convert.ToInt64(Dts_Mater.Tables[0].Rows[0]["SED_ID"].ToString())+1).ToString() ;
        this.AddExpend.Visible = true;
    }

    

    protected void Button2_Click(object sender, EventArgs e)
    {
        KNet.Model.Sc_Expend_Manage_MaterDetails modelDetails=new KNet.Model.Sc_Expend_Manage_MaterDetails();
        modelDetails.SED_ID = this.OddNumbers.Text;
        modelDetails.SED_ProductsBarCode = this.SED_ProductsBarCode.Text;
        modelDetails.SED_NeedNumber = Convert.ToInt32(this.Amount.Text);
        modelDetails.SED_HouseNo = this.TextBox1.Text;
        decimal a =
            Math.Round(
                Convert.ToInt32(this.Amount.Text) + Convert.ToInt32(this.Amount.Text)*(Convert.ToDecimal(Consume.Text)/100), 0);
        modelDetails.SED_RkNumber =Convert.ToInt32(a) ;
        modelDetails.SED_RkTime=Convert.ToDateTime(Lbl_Stime.Text) ;
        modelDetails.SED_RkPerson = Session["SED_RkPerson"].ToString();
        modelDetails.SED_SEMID = Session["SED_SEMID"].ToString();
        modelDetails.SED_Type = 2;
        modelDetails.SED_LossType = this.TXB_Genre_Value.Text;
        modelDetails.SED_LossPercent = Convert.ToDecimal(Consume.Text);
        KNet.BLL.Sc_Expend_Manage_MaterDetails BLL=new KNet.BLL.Sc_Expend_Manage_MaterDetails();
        BLL.Add(modelDetails);
        //ShowInfo(Session["SED_SEMID"].ToString());

    }
}
