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
using KNet.DBUtility;
using KNet.Common;


public partial class Web_Sales_KNet_Sales_LinkMan_View : BasePage
{
    public string s_MyTable_Detail = "", s_OrderStyle = "", s_DetailsStyle = "", s_StructureStyle = "", s_Structure = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.Lbl_Title.Text = "查看联系人信息";
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin(this.Lbl_Title.Text) == false)
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
                s_StructureStyle = "class=\"dvtUnSelectedCell\"";
                Pan_Order.Visible = false;
                Pan_Detail.Visible = true;
                Table_Btn.Visible = false;
            }
            else
            {

                s_DetailsStyle = "class=\"dvtUnSelectedCell\"";
                s_OrderStyle = "class=\"dvtSelectedCell\"";
                s_StructureStyle = "class=\"dvtUnSelectedCell\"";
                Pan_Order.Visible = true;
                Pan_Detail.Visible = false;
                Table_Btn.Visible = true;
            }
            if (s_ID != "")
            {
                ShowInfo(s_ID);
            }
        }
       
    }

    private void ShowInfo(string XOL_ID)
    {
        KNet.BLL.XS_Compy_LinkMan bll = new KNet.BLL.XS_Compy_LinkMan();
        KNet.Model.XS_Compy_LinkMan model = bll.GetModel(XOL_ID);
        this.Tbx_ID.Text = model.XOL_ID;
        this.Lbl_CompyName.Text = model.XOL_Compy;
        this.Lbl_CompyName.Text = base.Base_GetCustomerName_Link(model.XOL_Compy);

        this.Lbl_Name.Text = model.XOL_Name;
        this.Lbl_Phone.Text = model.XOL_Phone;
        this.Lbl_Mail.Text = model.XOL_Mail;
        this.Lbl_Sex.Text = model.XOL_Sex;
        this.Lbl_Age.Text = model.XOL_Age;
        this.Lbl_Birthday.Text = model.XOL_Birthday;
        this.Lbl_Place.Text = model.XOL_Place;
        this.Lbl_Nation.Text = base.Base_GetBasicCodeName("753",model.XOL_Nation);
        this.Lbl_Marriage.Text = model.XOL_Marriage;
        this.Lbl_Officephone.Text = model.XOL_Officephone;
        this.Lbl_Homephone.Text = model.XOL_Homephone;
        this.Lbl_Fax.Text = model.XOL_Fax;
        this.Lbl_Education.Text = base.Base_GetBasicCodeName("751",model.XOL_Education);
        this.Lbl_Experience.Text = model.XOL_Experience;
        this.Lbl_Responsible.Text = model.XOL_Responsible;
        this.Lbl_Hobby.Text = model.XOL_Hobby;
        this.Lbl_Address.Text = model.XOL_Address;
        this.Lbl_LogisticsAddress.Text = model.XOL_LogisticsAddress;
        this.Lbl_Evaluation.Text = model.XOL_Evaluation;
        this.Lbl_Remark.Text = model.XOL_Remark;
        this.Lbl_Duty.Text = model.XOL_Duty;
        this.Lbl_Code.Text = model.XOL_Code;

        this.Lbl_QQ.Text = model.XOL_QQ;
        this.Lbl_Manager.Text = base.Base_GetLinkManValue(model.XOL_Manager,"XOL_Name");
        this.Lbl_CallName.Text = base.Base_GetBasicCodeName("115",model.XOL_CallName);
        this.Lbl_DutyPerson.Text = base.Base_GetUserName(model.XOL_DutyPerson);
        this.Lbl_EnglishName.Text = model.XOL_EnglishName;

        this.Lbl_Card.Text = "<A  target=\"_blank\" href=\"../../VCard/" + model.XOL_Name + ".jpg\"  ><Image ID=\"Image_1\" Src=\"../../VCard/" + model.XOL_Name + ".jpg\" Height=\"200px\" width=\"400\"  border=0 /></a>";
        this.Lbl_CardBg.Text = "<A  target=\"_blank\" href=\"../../VCard/" + model.XOL_Name + "_bg.jpg\"  ><Image ID=\"Image_1\" Src=\"../../VCard/" + model.XOL_Name + "_bg.jpg\" Height=\"200px\" width=\"400\"  border=0 /></a>";
    }

}
