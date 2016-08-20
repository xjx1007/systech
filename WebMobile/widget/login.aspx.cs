using System;
using System.Data;
using System.Data.Sql;
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

public partial class KnetWork_DefaultLoging : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Response.Redirect("login.aspx");


        HttpCookie cookies = Request.Cookies["platform"];
        //判断是否有cookie值，有的话就读取出来
        if (cookies != null && cookies.HasKeys)
        {
            UserName.Text = cookies["Name"];
            Password.Text = cookies["Pwd"];
            this.crmcheckbox_rem.Checked = true;
        }
        HttpCookie cookies1 = Request.Cookies["platformauto"];
        //判断是否有cookie值，有的话就读取出来
        if (cookies1 != null && cookies1.HasKeys)
        {
            try
            {
                if (cookies["auto"] == "1")
                {
                    this.crmcheckbox_auto.Checked = true;
                    User_Login(UserName.Text, Password.Text);
                }
            }
            catch
            { }
        }
    }
    /// <summary>
    /// 登录方法 
    /// </summary>
    /// <param name="user">用户名</param>
    /// <param name="pass">密  码</param>
    /// <returns></returns>
    protected string User_Login(string user, string pass)
    {
        string myssss;
        if (user == "" || pass == "")
        {
            return "用户名和密码不能为空！";
        }
        try
        {
            using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
            {
                if (crmcheckbox_rem.Checked)
                {
                    HttpCookie cookie = new HttpCookie("platform");
                    cookie.Values.Add("Name", user.Trim());
                    cookie.Values.Add("Pwd", pass.Trim());
                    cookie.Expires = System.DateTime.Now.AddDays(7.0);
                    HttpContext.Current.Response.Cookies.Add(cookie);
                }
                if (crmcheckbox_auto.Checked)
                {
                    HttpCookie cookie = new HttpCookie("platformauto");
                    cookie.Values.Add("auto", "1");
                    cookie.Expires = System.DateTime.Now.AddDays(7.0);
                    HttpContext.Current.Response.Cookies.Add(cookie);
                }
                conn.Open();
                int result = -1;
                string mywps = KNetPage.KNetMD5(pass.ToUpper().Trim());
                SqlCommand sqlcomm = new SqlCommand("checkAdminLogin", conn);
                sqlcomm.CommandType = CommandType.StoredProcedure;

                sqlcomm.Parameters.Add("@StaffCard_StaffName", SqlDbType.NVarChar, 50).Value = user;
                sqlcomm.Parameters.Add("@StaffPassword", SqlDbType.NVarChar, 50).Value = mywps;
                sqlcomm.Parameters.Add("@Staff_LoginIP", SqlDbType.VarChar, 40).Value = Request.UserHostAddress.ToString();

                sqlcomm.Parameters.Add("@StaffNo", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
                sqlcomm.Parameters.Add("@Staff_LoginIP_Out", SqlDbType.NVarChar, 40).Direction = ParameterDirection.Output;
                sqlcomm.Parameters.Add("@Staff_LoginDate_Out", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
                sqlcomm.Parameters.Add("return1", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                sqlcomm.ExecuteNonQuery();

                result = int.Parse(sqlcomm.Parameters["return1"].Value.ToString());

                switch (result)
                {
                    case 0:
                        this.Session["KNet_Admin_StaffName"] = user; //卡号或是用名
                        this.Session["KNet_Admin_PassWord"] = mywps;

                        this.Session["KNet_Admin_StaffNo"] = sqlcomm.Parameters["@StaffNo"].Value.ToString();
                        this.Session["KNet_Admin_Staff_LoginIP_Out"] = sqlcomm.Parameters["@Staff_LoginIP_Out"].Value.ToString();
                        this.Session["KNet_Admin_Staff_LoginDate_Out"] = sqlcomm.Parameters["@Staff_LoginDate_Out"].Value.ToString();

                        AdminloginMess AM = new AdminloginMess();
                        AM.DeleteTimeOutUser();
                        myssss = "登录成功";
                        break;
                    case 1:
                        myssss = "用名或卡号不存在，或已被禁用！";
                        break;
                    case 2:
                        myssss = "密码错误！";
                        break;
                    case 3:
                        myssss = "未知错误";
                        break;
                    default:
                        myssss = "未知错误,请稍后再试";
                        break;
                }
                conn.Close();
            }
        }
        catch
        {
            myssss = "连接数据库发生错误！";
        }
        return myssss;
    }


    //==================================
    /// <summary>
    /// 系统操作日志
    /// </summary>
    /// <param name="P_str_logContent">日志内容</param>
    public void Add_Logs(string P_str_logContent, string StaffNoss)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            SqlCommand myCmd = new SqlCommand("Proc_KNet_Static_logs_ADD", conn);
            myCmd.CommandType = CommandType.StoredProcedure;

            //添加参数
            SqlParameter StaffNo = new SqlParameter("@StaffNo", SqlDbType.VarChar, 30);
            StaffNo.Value = StaffNoss;
            myCmd.Parameters.Add(StaffNo);
            //添加参数
            SqlParameter logContent = new SqlParameter("@logContent", SqlDbType.VarChar, 250);
            logContent.Value = P_str_logContent;
            myCmd.Parameters.Add(logContent);

            //添加参数
            SqlParameter logIP = new SqlParameter("@logIP", SqlDbType.VarChar, 30);
            logIP.Value = System.Web.HttpContext.Current.Request.UserHostAddress.ToString().Trim();
            myCmd.Parameters.Add(logIP);
            conn.Open();
            try
            {
                myCmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                myCmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }
    }


    protected void ImageButton1_Click(object sender, EventArgs e)
    {

        string AdminUserName = KNetPage.KHtmlEncode(this.UserName.Text.Trim());

        if (AdminUserName == null || AdminUserName == "")
        {
            AdminUserName = "登陆名为空";
        }

        string AdminPassword = this.Password.Text.ToString().Trim().ToUpper();
        //  string VryCode = VerifyCode.Text.ToString().Trim().ToUpper();
        // if (VryCode.CompareTo(Session["VerifyCode"]) != 0)
        // {
        //     this.Add_Logs("登陆系统失败，原因:验证码不正确！", AdminUserName);
        //     BackMess.Text = "验证码不正确！";
        //     return;
        //}

        if (AdminUserName == "" || AdminPassword == "")
        {
            this.Add_Logs("登陆系统失败，原因:用户名或密码为空！", AdminUserName);
            BackMess.Text = "用户名和密码不能为空！";
            return;
        }

        //string AdminUserName = "admin";
        //string AdminPassword = "admin";

        string backmess = User_Login(AdminUserName, AdminPassword);
        if (backmess.CompareTo("登录成功") == 0)
        {
            Add_Logs("登陆系统成功....", AdminUserName);

            Response.Write("<script language='javascript' type='text/javascript'>this.window.location.href='newmain.aspx';</script>");
            Response.End();
        }
        else
        {
            BackMess.Text = backmess;
        }
    }
}
