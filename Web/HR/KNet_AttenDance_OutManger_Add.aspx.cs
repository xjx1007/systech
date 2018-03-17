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


/// <summary>
///  人力资源 -----考勤管理添加 
/// </summary>
public partial class Knet_Web_HR_KNet_AttenDance_OutManger_Add : BasePage
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
            else
            {

                ////内部考勤申请
                //if (AM.YNAuthority(NQ.Str5007) == false)
                //{
                //    AM.NoAuthority("5007");
                //}DDLThisKings
              //  base.Base_DropBasicCodeBind(this.Ddl_CCType, "217",false);
                base.Base_DropBasicCodeBind(this.Ddl_Traffic, "141");
                base.Base_DropBasicCodeBind(this.DDLThisKings, "150");
                base.Base_DropBasicCodeBind(Ddl_Type, "151");
                if (AM.KNet_StaffBranch != null && AM.KNet_StaffBranch != "")
                {
                    if (AM.KNet_StaffDepart != null && AM.KNet_StaffDepart != "")
                    {
                        this.StaffNo.Text = GetStaffBranchName(AM.KNet_StaffBranch) +"--"+ GetStaffDepartName(AM.KNet_StaffDepart) +"--"+ AM.KNet_StaffName;
                    }
                    else
                    {
                        this.StaffNo.Text = GetStaffBranchName(AM.KNet_StaffBranch) + "--" + AM.KNet_StaffName;
                    }
                }
                else
                {
                    this.StaffNo.Text = AM.KNet_StaffName;
                }
            }
        }

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




    /// <summary>
    /// 选择类型
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DDLThisKings_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.DDLThisKings.SelectedValue != "" && this.DDLThisKings.SelectedValue != null)
        {
            int DDLtist = int.Parse(this.DDLThisKings.SelectedValue);
            if (DDLtist == 3)
            {
                this.OrderDiti.Visible = true;
            }
            else if ((DDLtist == 4) || (DDLtist == 5) )
            {
                this.StartDateTime.Text = DateTime.Now.ToString();
                this.EndDatetime.Text = DateTime.Now.AddMinutes(1).ToString();
                this.Pan_EndTime.Visible = false;
                this.OrderDiti.Visible = false;
            }
            else
            {
                this.Pan_EndTime.Visible = true;
                this.OrderDiti.Visible = false;
            }
            
            if (DDLtist == 1)
            {
                this.OrderQj.Visible = true;
            }
            else
            {
                this.OrderQj.Visible = false;
            }
        }
        else
        {
            this.OrderDiti.Visible = false;
        }
    }
    /// <summary>
    /// 提交申请
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
         AdminloginMess AM = new AdminloginMess();
         if (AM.CheckLogin() == false)
         {
             Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
             Response.End();
         }
         else
         {
             string StaffNo = AM.KNet_StaffNo;
             string StaffBranch = AM.KNet_StaffBranch;
             string StaffDepart = AM.KNet_StaffDepart;

             string StartDateTime = null;
             if (this.StartDateTime.Text != "" && this.StartDateTime.Text != null)
             {
                StartDateTime = KNetPage.KHtmlEncode(this.StartDateTime.Text.Trim());
             }

             string EndDatetime = null;
             if (this.EndDatetime.Text != "" && this.EndDatetime.Text != null)
             {
               EndDatetime = KNetPage.KHtmlEncode(this.EndDatetime.Text.Trim());
             }

             try
             {
                 if (DateTime.Parse(this.StartDateTime.Text.Trim().ToString()) >= DateTime.Parse(this.EndDatetime.Text.Trim().ToString()))
                 {
                     Response.Write("<script>alert('起始日期（时间）不能大于或等于结束日期（时间）！');history.back(-1);</script>");
                     Response.End();
                 }
             }
             catch { }



             DateTime AddDatetime = DateTime.Now;
             int ThisState = 0;
             string OutJustificate = KNetPage.KHtmlEncode(this.OutJustificate.Text.Trim());
             int ThisKings = int.Parse(this.DDLThisKings.SelectedValue);

             string thisExtendA = this.thisExtendA.Text;

             KNet.BLL.KNet_Resource_OutManage BLL = new KNet.BLL.KNet_Resource_OutManage();
             KNet.Model.KNet_Resource_OutManage model = new KNet.Model.KNet_Resource_OutManage();
             model.ID = base.GetNewID("KNet_Resource_OutManage", 1);
             model.StaffNo = StaffNo;
             model.StaffBranch = StaffBranch;
             model.StaffDepart = StaffDepart;
             model.StartDateTime = StartDateTime;
             model.EndDatetime = EndDatetime;
             model.AddDatetime = AddDatetime;
             model.ThisState = ThisState;
             model.OutJustificate = OutJustificate;
             model.ThisKings = ThisKings;
             model.thisExtendA = thisExtendA;
             model.thisExtendB = "";
             model.KRO_Traffic = this.Ddl_Traffic.SelectedValue;
             model.KRO_Type = this.Ddl_Type.SelectedValue;
             ArrayList Arr_Customer = new ArrayList();
             if (Request["CustomerValue"] != null)
             {
                 string[] s_CustomerValue = Request.Form["CustomerValue"].Split(',');
                 if (s_CustomerValue.Length > 0)
                 {
                     for (int i = 0; i < s_CustomerValue.Length; i++)
                     {
                         KNet.Model.Xs_Customer_Products Model_Customer_Products = new KNet.Model.Xs_Customer_Products();
                         Model_Customer_Products.XCP_CustomerID = s_CustomerValue[i];
                         Model_Customer_Products.XCP_ProductsID = model.ID;
                         Model_Customer_Products.XCP_ID = GetNewID("Xs_Customer_Products", 1);
                         Arr_Customer.Add(Model_Customer_Products);
                     }
                     model.Arr_Customer = Arr_Customer;
                 }
                 else
                 {
                     if (ThisKings == 3)
                     {
                         Alert("出差申请必须选择客户或者供应商！");
                         return;
                     }
                 }
             }
             else
             {
                 if (ThisKings == 3)
                 {
                     Alert("出差申请必须选择客户或者供应商！");
                     return;
                 }
 
             }
             try
             {
                 BLL.Add(model);
                 AM.Add_Logs("人力资源--->考勤管理--->考勤申请 添加 操作成功！申请人：" + GetStaffStaffNameInfo(StaffNo) + "");

                 string s_StaffName = base.Base_GetUserName(StaffNo);
                 if ((AM.KNet_StaffDepart == "129652783965723459") || (AM.KNet_StaffDepart == "129652784259578018") || (AM.KNet_StaffDepart == "129652784446995911") || (AM.KNet_StaffDepart == "129652784116845798") || (AM.KNet_StaffDepart == "129757466300748845"))//研发中心
                 {
                     if (AM.KNet_Position == "102")//经理
                     {
                         //发给黄总
                         base.Base_SendMessage("129652783693249229", KNetPage.KHtmlEncode("有 " + s_StaffName + " 考勤申请 <a href='Web/HR/inc/KNet_AttenDance_OutManger_Do.aspx?ID=" + model.ID + "'  onclick=\"RemoveSms('" + base.GetNewID("System_Message_Manage", 0) + "', '', 0);\" target=\"_blank\"> " + model.ID + "</a> 需要您审批，敬请关注！"));
                     }
                     else
                     {
                         base.Base_SendMessage(Base_GetDeptPerson("研发中心", 1), KNetPage.KHtmlEncode("有" + s_StaffName + "  考勤申请 <a href='Web/HR/inc/KNet_AttenDance_OutManger_Do.aspx?ID=" + model.ID + "'  onclick=\"RemoveSms('" + base.GetNewID("System_Message_Manage", 0) + "', '', 0);\" target=\"_blank\"> " + model.ID + "</a> 需要您审批，敬请关注！"));
                     }
                   }
                 //
                 else if (AM.KNet_StaffDepart == "129652783822281241")//市场销售部
                 {
                     // if (AM.KNet_Position == "102")//经理
                         //{
                         //发给黄总
                         base.Base_SendMessage("129652783693249229", KNetPage.KHtmlEncode("有 " + s_StaffName + " 考勤申请 <a href='Web/HR/inc/KNet_AttenDance_OutManger_Do.aspx?ID=" + model.ID + "'  onclick=\"RemoveSms('" + base.GetNewID("System_Message_Manage", 0) + "', '', 0);\" target=\"_blank\"> " + model.ID + "</a> 需要您审批，敬请关注！"));

                     //}
                     //else
                     //{
                     //    base.Base_SendMessage(Base_GetDeptPerson("市场销售部", 1), KNetPage.KHtmlEncode("有 " + s_StaffName + " 考勤申请 <a href='Web/HR/inc/KNet_AttenDance_OutManger_Do.aspx?ID=" + model.ID + "'  onclick=\"RemoveSms('" + base.GetNewID("System_Message_Manage", 0) + "', '', 0);\" target=\"_blank\"> " + model.ID + "</a> 需要您审批，敬请关注！"));
                     //}
                 }
                 else//其他部门
                 {
                     base.Base_SendMessage(Base_GetDeptPerson("市场销售部", 1) + "," + Base_GetDeptPerson("研发中心", 1), KNetPage.KHtmlEncode("有 " + s_StaffName + " 考勤申请 <a href='Web/HR/inc/KNet_AttenDance_OutManger_Do.aspx?ID=" + model.ID + "'  onclick=\"RemoveSms('" + base.GetNewID("System_Message_Manage", 0) + "', '', 0);\" target=\"_blank\"> " + model.ID + "</a> 需要您审批，敬请关注！"));
              
                 }
                 Response.Write("<script>alert('考勤申请 添加 成功！');location.href='KNet_AttenDance_OutManger.aspx';</script>");
                 Response.End();
             }
             catch
             {
                 Response.Write("<script>alert('考勤申请 添加失败1！');history.back(-1);</script>");
                 Response.End();
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
}
