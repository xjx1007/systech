
<%@ WebHandler Language="C#" Class="GetMessage" %>
using System;
using System.Web;
using System.Text;
using System.Web.SessionState;
using System.Data.SqlClient;
using System.Data;
using KNet.Common;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using KNet.DBUtility;
using KNet.Common;

public class User
{
    [DataMember(Order = 0, IsRequired = true)]
    public string password { get; set; }

    [DataMember(Order = 1)]
    public string user_name { get; set; }

    [DataMember(Order = 2)]
    public string platform { get; set; }

    [DataMember(Order = 3)]
    public string deviceToken { get; set; }

}

/*
?({"id":"37","currentuser":"\u8001\u677f(\u603b\u7ecf\u7406)",
"companyname":"\u4e0a\u6d77\u745e\u7b56\u8f6f\u4ef6\u6709\u9650\u516c\u53f8",
"userphoto":"http:\/\/app.c3crm.com\/\/getpic.php?mode=show&attachmentsid=2451",
"service_version":"20141128"})
 */


public class GetMessage : IHttpHandler, IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
        context.Response.Clear();
        context.Response.Buffer = true;
        StringBuilder s_Return = new StringBuilder();
        StringBuilder s_Return1 = new StringBuilder();
        StringBuilder s_Return2 = new StringBuilder();
        string s_LoginDate = context.Request.QueryString["rest_data"] == null ? "" : context.Request.QueryString["rest_data"].ToString();
        s_LoginDate = HttpUtility.UrlDecode(s_LoginDate);

        User User = JsonHelper.ParseFromJson<User>(s_LoginDate);
        BasePage Page = new BasePage();
        string backmess = User_Login(User.user_name, User.password, context);
        if (backmess == "登录成功")
        {
            KNet.BLL.KNet_Resource_Staff Bll = new KNet.BLL.KNet_Resource_Staff();
            DataSet Dts_Table = Bll.GetList(" StaffCard='" + User.user_name + "' ");

            s_Return1.Append("(");
            if (Dts_Table.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                {
                    s_Return1.Append("{");
                    s_Return1.Append("\"id\":\"" + Dts_Table.Tables[0].Rows[i]["StaffNo"].ToString() + "\",");
                    s_Return1.Append("\"currentuser\":\"" + Dts_Table.Tables[0].Rows[i]["StaffNo"].ToString() + "\",");
                    s_Return1.Append("\"companyname\":\"" + HttpUtility.UrlEncode(Page.Base_GetUserDept(Dts_Table.Tables[0].Rows[i]["StaffNo"].ToString())) + "\",");
                    s_Return1.Append("\"userphoto\":\"\",");
                    s_Return1.Append("\"service_version\":\"20150101\"");
                    s_Return1.Append("}");
                }
            }
            s_Return1.Append(")");

            context.Response.Write(s_Return1.ToString());
            context.Response.Flush();
            context.Response.End();
        }
        else
        {
            s_Return2.Append(backmess);
            context.Response.Write(s_Return2.ToString());
            context.Response.Flush();
            context.Response.End();
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

    protected string User_Login(string user, string pass, HttpContext context)
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
                string mywps = pass.ToUpper().Trim();
                SqlCommand sqlcomm = new SqlCommand("checkAdminLogin", conn);
                sqlcomm.CommandType = CommandType.StoredProcedure;

                sqlcomm.Parameters.Add("@StaffCard_StaffName", SqlDbType.NVarChar, 50).Value = user;
                sqlcomm.Parameters.Add("@StaffPassword", SqlDbType.NVarChar, 50).Value = mywps;
                sqlcomm.Parameters.Add("@Staff_LoginIP", SqlDbType.VarChar, 40).Value = context.Request.UserHostAddress.ToString();

                sqlcomm.Parameters.Add("@StaffNo", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
                sqlcomm.Parameters.Add("@Staff_LoginIP_Out", SqlDbType.NVarChar, 40).Direction = ParameterDirection.Output;
                sqlcomm.Parameters.Add("@Staff_LoginDate_Out", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
                sqlcomm.Parameters.Add("return1", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                sqlcomm.ExecuteNonQuery();

                result = int.Parse(sqlcomm.Parameters["return1"].Value.ToString());

                switch (result)
                {
                    case 0:
                        context.Session["KNet_Admin_StaffName"] = user; //卡号或是用名
                        context.Session["KNet_Admin_PassWord"] = mywps;

                        context.Session["KNet_Admin_StaffNo"] = sqlcomm.Parameters["@StaffNo"].Value.ToString();
                        context.Session["KNet_Admin_Staff_LoginIP_Out"] = sqlcomm.Parameters["@Staff_LoginIP_Out"].Value.ToString();
                        context.Session["KNet_Admin_Staff_LoginDate_Out"] = sqlcomm.Parameters["@Staff_LoginDate_Out"].Value.ToString();

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
}