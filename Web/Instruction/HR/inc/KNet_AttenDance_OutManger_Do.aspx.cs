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
using System.Text;

using KNet.DBUtility;
using KNet.Common;

/// <summary>
/// 人力资源 -----考勤管理 审批执行
/// </summary>
public partial class Knet_Web_HR_Inc_KNet_AttenDance_OutManger_Do : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }

            ////内部考勤记录审批
            //if (AM.YNAuthority(NQ.Str5010) == false)
            //{
            //    AM.NoAuthority("5010");
            //}



            if (Request.QueryString["ID"] != null && Request.QueryString["ID"] != "")
            {
                //if (GetThisStateNews(Request.QueryString["ID"].ToString().Trim()) == true)
                //{ }
                //else
                //{
                //    Response.Write("<script>alert('非法参数！或是此记录已审批过!');window.close();</script>");
                //    Response.End();
                //}
                    this.IDtxt.Text = Request.QueryString["ID"].ToString().Trim();
                    ShowInfo(this.IDtxt.Text);
            }
            else
            {
                Response.Write("<script>alert('非法参数！');window.close();</script>");
                Response.End();
            }
        }
    }



    private void ShowInfo(string s_ID)
    {

        KNet.BLL.KNet_Resource_OutManage BLL = new KNet.BLL.KNet_Resource_OutManage();

        if (Request["ID"] != null)
        {
            string MyID = Request.QueryString["ID"].ToString().Trim();
            if (MyID != "")
            {
                KNet.Model.KNet_Resource_OutManage model = BLL.GetModel(MyID);
                this.ThisState.Text = base.Base_GetBasicCodeName("150", model.ThisState.ToString());
                this.StaffName.Text = base.Base_GetUserName(model.StaffNo);
                this.Tbx_StaffNo.Text = model.StaffNo;
                this.StaffCard.Text = GetStaffStaffCardInfo(model.StaffNo);
                this.ThisKings.Text = base.Base_GetBasicCodeName("150", model.ThisKings.ToString());
                this.AddDatetime.Text = model.AddDatetime.ToString();
                this.StaffBranch.Text = base.Base_GeDept(model.StaffBranch);
                this.StaffDepart.Text = base.Base_GeDept(model.StaffDepart);
                this.StartDateTime.Text = model.StartDateTime.ToString();
                this.EndDatetime.Text = model.EndDatetime.ToString();
                this.ApprovalStaffNo.Text = GetStaffStaffCardInfo(model.ApprovalStaffNo);
                this.ApprovalDatetime.Text = model.ApprovalDatetime.ToString();
                this.thisExtendA.Text = model.thisExtendA;
                this.OutJustificate.Text = KNetPage.KHtmlDiscode(model.OutJustificate);
                this.Lbl_Type.Text = base.Base_GetBasicCodeName("151", model.KRO_Type);

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
    /// 审核操作
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        if (AM.CheckLogin() == false)
        {
            Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
            Response.End();
        }
        else
        {
            int AA = int.Parse(this.DropDownList1.SelectedValue);
            string ID = this.IDtxt.Text.Trim();

            if (AM.KNet_StaffDepart == "129652783693249229")
            {
                AA = 3;
            }

            string DoSql = "update KNet_Resource_OutManage  set ThisState=" + AA + ",ApprovalStaffNo ='" + AM.KNet_StaffNo + "',ApprovalDatetime='" + DateTime.Now + "'  where ID='" + ID + "' ";

            if (AA != -1)
            {
                if (AA == 1 || AA == 2 || AA == 3) //通过审批或不通过审批操作
                {
                    DbHelperSQL.ExecuteSql(DoSql);
                    AM.Add_Logs("考勤申请审批操作成功.操作人：" + AM.KNet_StaffName);

                    //
                    base.Base_SendMessage(this.Tbx_StaffNo.Text, KNetPage.KHtmlEncode(" " + this.StaffName.Text + " 的 考勤申请 <a href='Web/HR/KNet_AttenDance_OutManger_View.aspx?ID=" + this.IDtxt.Text + "'  onclick=\"RemoveSms('" + base.GetNewID("System_Message_Manage", 0) + "', '', 0);\" target=\"_blank\"> " + this.IDtxt.Text + "</a>  "+this.DropDownList1.SelectedItem.Text+" ，敬请关注！"));
        

                    Response.Write("<script>alert('考勤申请审批操作成功成功，点 确定 返回！');window.opener.location.reload();window.close();</script>");
                    Response.End();
                }
                else
                {
                    Response.Write("<script>alert('考勤申请暂不执行审批操作，点 确定 返回！');window.opener.location.reload();window.close();</script>");
                    Response.End();
                }
            }
        }
    }



    /// <summary>
    /// 是否是新申请
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected bool GetThisStateNews(string ID)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,ThisState from KNet_Resource_OutManage where ID='" + ID + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (int.Parse(dr["ThisState"].ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }


}
