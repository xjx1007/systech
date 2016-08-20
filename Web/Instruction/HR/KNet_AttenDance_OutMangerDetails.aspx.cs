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

/// <summary>
/// 人力资源 -----考勤详细信息
/// </summary>
public partial class Knet_Web_HR_KNet_AttenDance_OutMangerDetails : System.Web.UI.Page
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
            ////查看考勤记录详细
            //if (AM.YNAuthority(NQ.Str5009) == false)
            //{
            //    AM.NoAuthority("5009");
            //}

            this.makeMan.Text = AM.KNet_StaffName.ToString();
            this.makeTime.Text = DateTime.Now.ToShortDateString();


            this.Get_Staff_ByID();

        }
    }
    /// <summary>
    /// 获取信息
    /// </summary>
    protected void Get_Staff_ByID()
    {
        KNet.BLL.KNet_Resource_OutManage BLL = new KNet.BLL.KNet_Resource_OutManage();
       
        if (Request["ID"] != null)
        {
            string MyID = Request.QueryString["ID"].ToString().Trim();
            if (MyID != "")
            {
                KNet.Model.KNet_Resource_OutManage model = BLL.GetModel(MyID);


                this.ThisState.Text = GetThisStateifno(int.Parse(model.ThisState.ToString()));
                this.StaffName.Text = GetStaffStaffCardInfo(model.StaffNo);
                this.StaffCard.Text = GetStaffStaffCardInfo(model.StaffNo);
                this.ThisKings.Text = GetKinksifno(int.Parse(model.ThisKings.ToString()));
                this.AddDatetime.Text = model.AddDatetime.ToString();

                this.StaffBranch.Text = GetStaffBranchName(model.StaffBranch);
                this.StaffDepart.Text = GetStaffDepartName(model.StaffDepart);

                this.StartDateTime.Text = model.StartDateTime.ToString();
                this.EndDatetime.Text = model.EndDatetime.ToString();

                this.ApprovalStaffNo.Text = GetStaffStaffCardInfo(model.ApprovalStaffNo);
                this.ApprovalDatetime.Text = model.ApprovalDatetime.ToString();

                this.thisExtendA.Text = model.thisExtendA;

                this.OutJustificate.Text = KNetPage.KHtmlDiscode(model.OutJustificate);

                if (int.Parse(model.ThisKings.ToString()) == 3)
                {
                    this.ADDsPart.Visible = true;
                }
                else
                {
                    this.ADDsPart.Visible = false;
                }
            }
            else
            {
                Response.Write("<script language=javascript>alert('非法参数！');window.close()</script>");
                Response.End();
            }
        }
        else
        {
            Response.Write("<script language=javascript>alert('非法参数！');window.close()</script>");
            Response.End();
        }
    }
    /// <summary>
    /// 获取申请者 卡号
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetStaffStaffCardInfo(string StaffNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,StaffNo,StaffCard,StaffName from KNet_Resource_Staff where StaffNo='" + StaffNo + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["StaffCard"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }
    /// <summary>
    /// 获取申请者 姓名
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetStaffStaffNameInfo(string StaffNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,StaffNo,StaffCard,StaffName from KNet_Resource_Staff where StaffNo='" + StaffNo + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["StaffName"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }
    /// <summary>
    /// 状态 状态（0,新申请，1已批，2否决）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetThisStateifno(int aa)
    {
        string Strx = null;
        switch (aa)
        {
            case 0:
                Strx = "新申请";
                break;
            case 1:
                Strx = "已批";
                break;
            case 2:
                Strx = "否决";
                break;
            default :
                Strx = "--";
                break;
        }
        return Strx;
    }

    /// <summary>
    /// 类型   （1请假，2外出，3出差）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetKinksifno(int aa)
    {
        string Kstr = null;
        switch (aa)
        {
            case 0:
                Kstr = "--";
                break;
            case 1:
                Kstr = "请假";
                break;
            case 2:
                Kstr = "外出";
                break;
            case 3:
                Kstr = "出差";
                break;
            default:
                Kstr = "--";
                break;
        }
        return Kstr;
    }
    /// <summary>
    /// 返回公司名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetStaffBranchName(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,StrucValue,StrucName from KNet_Resource_OrganizationalStructure where StrucValue='" + aa + "' and StrucPID='0' ";
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

    /// <summary>
    /// 返回部门名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetStaffDepartName(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,StrucValue,StrucName from KNet_Resource_OrganizationalStructure where StrucValue='" + aa + "' and StrucPID!='0'";
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
