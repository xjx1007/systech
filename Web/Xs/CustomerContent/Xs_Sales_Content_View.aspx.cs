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


public partial class Web_Xs_Sales_Content_View : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.Lbl_Title.Text = "查看联系记录";
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin(this.Lbl_Title.Text) == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            if (s_ID != "")
            {
                ShowInfo(s_ID);
            }
        }
       
    }

    private void ShowInfo(string s_ID)
    {
     
        KNet.BLL.Xs_Sales_Content bll = new KNet.BLL.Xs_Sales_Content();
        KNet.Model.Xs_Sales_Content model = bll.GetModel(s_ID);
        try
        {
            this.Tbx_ID.Text = s_ID;
            CommentList1.CommentFID = s_ID;
            this.Lbl_Topic.Text = model.XSC_Topic;
            this.Lbl_Stime.Text = DateTime.Parse(model.XSC_Stime.ToString()).ToShortDateString();
            this.Lbl_CustomerValue.Text = base.Base_GetCustomerName_Link(model.XSC_CustomerValue);
            this.Lbl_LinkMan.Text = base.Base_GetLinkManValue(model.XSC_LinkMan, "XOL_Name");
            this.Lbl_DutyPerson.Text = base.Base_GetUserName(model.XSC_DutyPerson);
            this.Lbl_Types.Text = base.Base_GetBasicCodeName("117", model.XSC_Types);
            this.Lbl_Steps.Text = base.Base_GetBasicCodeName("118", model.XSC_Steps);
            this.Lbl_State.Text = base.Base_GetBasicCodeName("113", model.XSC_State);
            this.Lbl_Remarks.Text = model.XSC_Remarks;
            this.Lbl_NextAskTime.Text = DateTime.Parse(model.XSC_NextAskTime.ToString()).ToShortDateString();

            KNet.BLL.Xs_Sales_Opp bll_Opp = new KNet.BLL.Xs_Sales_Opp();
            KNet.Model.Xs_Sales_Opp model_Opp = bll_Opp.GetModel(model.XSC_SalesChance);
            if (model_Opp != null)
            {

                this.Lbl_SalesChance.Text = " <a href=\"../SalesOpp/Xs_Sales_Opp_View.aspx?ID=" + model_Opp.XSO_DID+ "\">" + model_Opp.XSO_Name + "</a>";
            }
        }
        catch
        {}
    }

}
