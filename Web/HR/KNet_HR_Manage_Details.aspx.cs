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

public partial class Knet_Web_HR_KNet_HR_Manage_Details : BasePage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("查看人员管理") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }

            ////企业人事查看
            //if (AM.YNAuthority(NQ.Str5003) == false)
            //{
            //    AM.NoAuthority("5003");
            //}


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
        KNet.BLL.KNet_Resource_Staff BLL = new KNet.BLL.KNet_Resource_Staff();
        if (Request["StaffNo"] != null && Request["StaffNo"] != "")
        {
            string StaffNo = Request.QueryString["StaffNo"].ToString().Trim();
            if (GetKNet_Sys_ProductsYN(StaffNo) == true)
             {

                 KNet.Model.KNet_Resource_Staff model = BLL.GetModelC(StaffNo);

                 this.StaffBranch.Text = GetStructureName(model.StaffBranch);
                 this.StaffDepart.Text = GetStructureName(model.StaffDepart);

                 this.StaffCard.Text = model.StaffCard;
                 this.StaffName.Text = model.StaffName + "  <a href=\"../Message/System_Message_Manage.aspx?TO_ID=" + Request.QueryString["StaffNo"].ToString() + "\">OA短消息</a>";
                 this.Staffwages.Text = model.Staffwages.ToString();


                this.Position.Text= base.Base_GetBasicCodeName("105",model.Position);
                 if (model.StaffSex==true)
                 {
                     this.StaffSex.Text = "男";
                 }
                 else
                 {
                     this.StaffSex.Text = "女";
                 }


                 this.StaffTel.Text = model.StaffTel;
                 this.StaffEmail.Text = model.StaffEmail;
                 this.StaffIDCard.Text = model.StaffIDCard;
                 try
                 {
                     this.StaffAddTime.Text = DateTime.Parse(model.StaffAddTime.ToString()).ToShortDateString();
                 }
                 catch { }
                 this.StaffAddress.Text = model.StaffAddress;

                 this.StaffRemarks.Text = model.StaffRemarks;
 
             }
             else
             {
                 Response.Write("<script language=javascript>alert('该人员已不存在,或数据出错！');window.close();</script>");
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
            string Dostr = "select ID,StaffNo,StaffName from KNet_Resource_Staff where StaffNo='" + aa + "'";
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
    /// 返回属性值
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetStructureName(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,StrucValue,StrucName from KNet_Resource_OrganizationalStructure where StrucValue='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["StrucName"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }
}
