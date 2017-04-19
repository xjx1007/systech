using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KNet.DBUtility;
using KNet.Common;
using System.Data.SqlClient;
using System.Data;


    public partial class Signin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            BackMess.Visible = false;
            string AdminUserName = KNetPage.KHtmlEncode(this.username.Text.Trim());

            if (AdminUserName == null || AdminUserName == "")
            {
                AdminUserName = "登陆名为空";
            }

            string AdminPassword = this.password.Text.ToString().Trim().ToUpper();
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

                Response.Write("<script language='javascript' type='text/javascript'>this.window.location.href='NewMain.aspx';</script>");
                Response.End();
            }
            else
            {
                BackMess.Visible = true;
                BackMess.Text = backmess;
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
                            myssss = "用户名或卡号不存在，或已被禁用！";
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

}
