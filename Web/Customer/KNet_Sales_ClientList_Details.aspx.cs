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

public partial class Knet_Web_Sales_KNet_Sales_ClientList_Details : BasePage
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        KNet.DBUtility.AdminloginMess AMLanguage = new KNet.DBUtility.AdminloginMess();
        if (AMLanguage.KNet_Soft_StaffLanguage == 2)
        {
            // 1、默认为简体转繁体，编码为utf-8
            Response.Filter = new LU.Web.ChineseConvertor(Response.Filter);
        }
        else if (AMLanguage.KNet_Soft_StaffLanguage == 1)
        {
            // 2、繁体简体转，编码为utf-8
            Response.Filter = new LU.Web.ChineseConvertor(Response.Filter, LU.Web.ChineseConvertor.CCDirection.T2S);
        }
        else
        { }
    }
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
            //客户查看
            if (AM.YNAuthority("客户查看") == false)
            {
                AM.NoAuthority("客户查看");
            }
            this.makeMan.Text = AM.KNet_StaffName.ToString();
            this.makeTime.Text = DateTime.Now.ToShortDateString();

            this.Get_Knet_Suppliers_ByID();
        }
    }

    /// <summary>
    /// 获取记录数据
    /// </summary>
    protected void Get_Knet_Suppliers_ByID()
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

                 try
                 {
                     this.CustomerAddtime.Text = DateTime.Parse(model.CustomerAddtime.ToString()).ToShortDateString();
                 }
                 catch { }



 
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
