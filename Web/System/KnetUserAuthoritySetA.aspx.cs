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
/// 权限设置
/// </summary>
public partial class web_SystemSettings_AuthoritySetA : BasePage
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
            else
            {
                ////用户组权限设置
                //if (AM.YNAuthority("用户组权限设置") == false)
                //{
                //    //AM.NoAuthority("7012");
                //    this.Button1.Enabled = false;
                //}
                if (GetGroupNameYN(Request.QueryString["GroupValue"].Trim()) == true)
                {
                    int King = 1020;
                    if (Request.QueryString["King"] != null)
                    {
                        King = int.Parse(Request.QueryString["King"].ToString());
                    }

                    this.GroupValue.Text = Request.QueryString["GroupValue"];
                    this.GroupName.Text = GetGroupName(Request.QueryString["GroupValue"].Trim());
                    this.LBNamB.Text = GetGroupName(Request.QueryString["GroupValue"].Trim());
                    this.SNameValue.Text = base.Base_GetBasicCodeName("152", King.ToString());
                    this.DBbindAuthList(this.AuthorityA, King, Request.QueryString["GroupValue"].Trim());

                    string s_Sql="";
                    s_Sql = "Select * from KNet_Sys_Authority_AuthList where GroupValue='" + this.GroupValue.Text + "' and  StaffNo in (Select StaffNo from KNet_Resource_Staff where StaffYN=0 ) ";
                    this.BeginQuery(s_Sql);
                    DataTable Dtb_Table = this.QueryForDataTable();
                    if (Dtb_Table.Rows.Count > 0)
                    {
                        for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                        {
                            this.Lbl_StaffNo.Text += base.Base_GetUserName(Dtb_Table.Rows[i][0].ToString()) + " [" + base.Base_GetUserDept(Dtb_Table.Rows[i][0].ToString()) + "]";
                        }
 
                    }
                    
                }
                else
                {
                    Response.Write("<script>alert('非法参数！');window.close();</script>");
                    Response.End();
                }
            }
        }


    }
    /// <summary>
    /// 确定权限设置
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
      try
        {
            int AuthorityKing = 1;
            if (Request.QueryString["King"] != null)
            {
                AuthorityKing = int.Parse(Request.QueryString["King"].ToString());
            }


            string GroupValue = this.GroupValue.Text.ToString();
            string[] SortId = new string[] { }; //功能编码值
            string SortIds = "";

            ////AuthorityA
            for (int i = 0; i < AuthorityA.Items.Count; i++)
            {
                if (AuthorityA.Items[i].Selected == true)
                {
                    if (SortIds == "")
                        SortIds = AuthorityA.Items[i].Value;
                    else
                        SortIds = SortIds + "," + AuthorityA.Items[i].Value;
                }
            }

            if (SortIds == "")
            {
                Response.Write("<script language=javascript>alert('您没有选择任何可选择的权限!');location.href='" + Request.Url.ToString() + "';</script>");
                Response.End();
            }

            //分开好后写入
            SortId = (SortIds.ToString()).Split(',');

            using (SqlConnection conn = DBClass.GetConnection("KNetJxcDB"))
            {
                conn.Open();
                //------------先删除该用户组下的权限[1]所有权限骗码值-----------//
                SqlCommand DelComm = new SqlCommand("Proc_KNet_Sys_AuthorityUserGroupSetup_Delete", conn);
                DelComm.CommandType = CommandType.StoredProcedure;
                SqlParameter[] dels ={
                    new SqlParameter("@GroupValue", SqlDbType.NVarChar, 50),
                    new SqlParameter("@AuthorityGroup", SqlDbType.Int, 4),
                };
                dels[0].Value = GroupValue;    //用户组唯一值
                dels[1].Value = AuthorityKing; //权限分类

                foreach (SqlParameter p in dels)
                {
                    DelComm.Parameters.Add(p);
                }
                DelComm.ExecuteNonQuery();
                DelComm.Dispose();

                //--------------再插入选择的类--------//

                foreach (string newsSort in SortId)
                {
                    SqlCommand MyComm = new SqlCommand("Proc_KNet_Sys_AuthorityUserGroupSetup_Insert", conn);
                    MyComm.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] prams ={
                   new SqlParameter("@GroupValue",SqlDbType.NVarChar,50),
                   new SqlParameter("@AuthorityValue",SqlDbType.NVarChar,50),
                   new SqlParameter("@AuthorityGroup", SqlDbType.Int, 4),
                };

                    prams[0].Value = GroupValue;
                    prams[1].Value = newsSort;
                    prams[2].Value = AuthorityKing;

                    foreach (SqlParameter parames in prams)
                    {
                        MyComm.Parameters.Add(parames);
                    }

                    MyComm.ExecuteNonQuery();
                    MyComm.Dispose();
                }

                AdminloginMess AMLog = new AdminloginMess();
                AMLog.Add_Logs("给用户组 " + GetGroupName(GroupValue) + " 设置操作权限成功！");
                Response.Write("<script language=\"javascript\" type=\"text/javascript\">alert('给用户组 " + GetGroupName(GroupValue) + " 设置操作权限成功！');location.href='" + Request.Url.ToString() + "';</script>");
                Response.End();
            }
        }
        catch(Exception ex)
        {
            throw;
        }

    }




    /// <summary>
    /// 绑定及选定
    /// </summary>
    protected void DBbindAuthList(CheckBoxList CLT, int AGP, string GroupValue)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetJxcDB"))
        {
            conn.Open();
            string Dosqls = "select * from KNet_Sys_AuthorityTable where AuthorityGroup=" + AGP + " order by AuthorityValue ";

            SqlDataAdapter da = new SqlDataAdapter(Dosqls, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "AuthorityTable");
            CLT.DataSource = ds;
            CLT.DataTextField = "AuthorityName";
            CLT.DataValueField = "AuthorityValue";
            CLT.DataBind();

            string DoSqls2 = "select * from KNet_Sys_AuthorityUserGroupSetup where GroupValue='" + GroupValue + "'";
            using (SqlCommand cmd2 = new SqlCommand(DoSqls2, conn))
            {
                SqlDataReader DR = cmd2.ExecuteReader();
                while (DR.Read())
                {
                    foreach (ListItem li in CLT.Items)
                    {
                        if (li.Value.Equals(DR["AuthorityValue"].ToString()))    //如果li.Value值等于选定的权限值,就钩选
                        {
                            li.Selected = true;                    //等于true就表示钩选啦.
                            break;
                        }
                    }
                }
            }
        }
    }


    //==============================
    /// <summary>
    /// 获取用户组名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetGroupName(string GroupValue)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetJxcDB"))
        {
            conn.Open();
            string Dostr = "select ID,GroupValue,GroupName from KNet_Sys_AuthorityUserGroup where  GroupValue='" + GroupValue + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["GroupName"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }

    //==============================
    /// <summary>
    /// 用户组是否存在
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected bool GetGroupNameYN(string GroupValue)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetJxcDB"))
        {
            conn.Open();
            string Dostr = "select ID,GroupValue,GroupName from KNet_Sys_AuthorityUserGroup where  GroupValue='" + GroupValue + "'";
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


}
