using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using KNet.DBUtility;
using KNet.Common;

public partial class Knet_Web_KNet_HR_Manage_Print :BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }

            //企业出差任务书
            this.Tbx_ID.Text=Request.QueryString["ID"]==null?"":Request.QueryString["ID"].ToString();

            this.DataShow();
        }
    }

    /// <summary>
    /// 获取记录数据
    /// </summary>
    protected void DataShow()
    {
        KNet.BLL.KNet_Resource_OutManage BLL = new KNet.BLL.KNet_Resource_OutManage();
        KNet.Model.KNet_Resource_OutManage Model=BLL.GetModel(this.Tbx_ID.Text);
        if(Model!=null)
        {
            this.Lbl_StaffNo.Text = base.Base_GetUserName(Model.StaffNo);
            this.Lbl_Time.Text = Model.StartDateTime.ToString() + "   到   " + Model.EndDatetime.ToString();
            this.Lbl_Place.Text = Model.thisExtendA;
            this.Lbl_Tracfic.Text = base.Base_GetBasicCodeName("141", Model.KRO_Traffic);
            this.Lbl_Remarks.Text = Model.OutJustificate;
            KNet.BLL.KNet_Resource_Staff Bll_Staff = new KNet.BLL.KNet_Resource_Staff();
            KNet.Model.KNet_Resource_Staff Model_Staff = Bll_Staff.GetModelC(Model.StaffNo);
            if ((Model.ThisState == 1)||(Model.ThisState == 3))
            {
                KNet.Model.KNet_Resource_Staff Model_Staff1 = Bll_Staff.GetModel(Model_Staff.ID);
                this.Lbl_BPerson.Text = base.Base_GetUserName(Model_Staff1.KRS_DepartPerson);
            }
            if (Model.ThisState == 3)
            {
                this.Lbl_ZPerson.Text = "黄景江";
            }
        }
       
    }
}
