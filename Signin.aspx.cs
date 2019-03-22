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
using Org.BouncyCastle.Utilities.Net;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using KNet.BLL;

public partial class Signin : BasePage
{
    public string Tokentime = ""; //校验码时效

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //username.Text= Request.UserHostAddress;公司公网IP:115.192.77.208
            //Weixin.Style["style"] = "display: none";
            if (null == Session["Token"])
            {
                SetToken();
            }
            //System.Net.IPAddress ipAddr = Dns.Resolve(Dns.GetHostName()).AddressList[0];//获得当前IP地址
            //this.username.Text = ipAddr.ToString();
            //if (ipAddr.ToString() == "173.114.50.233")
            //{
            //    Weixin.Attributes["style"] = "display:block";
            //}
            //Button2.Attributes.Add("OnClick", "return settime(this)");

        }
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
        string RandomNum = Tbx_Weixin.Text.Trim().ToString();
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
        if (RandomNum == "")
        {
            if (Verification.Value=="false")
            {
                BackMess.Text = "请输入验证码！";
                BackMess.Visible = true;
                //BackMess.Text = backmess;
                return;
            }
           
        }
        //string AdminUserName = "admin";
        //string AdminPassword = "admin";

        string backmess = User_Login(AdminUserName, AdminPassword, RandomNum);
        if (backmess.CompareTo("登录成功") == 0)
        {
            Add_Logs("登陆系统成功....", AdminUserName);
            AdminloginMess AM = new AdminloginMess();
            //
            string s_Sql =
                "Select *  FROM KNet_Sales_ContractList left join v_Contract_OutWare_DirectOut_State on v_ContractNO=ContractNO where   datediff(day,getdate(),ContractToDeliDate)<=3  and DirectOutState<2 ";
            this.BeginQuery(s_Sql);
            DataTable Dtb_Table = this.QueryForDataTable();
            if (Dtb_Table.Rows.Count > 0)
            {
                if (((AM.KNet_StaffDepart == "129652783822281241") || (AM.KNet_StaffDepart == "129652784446995911") ||
                     ((AM.KNet_StaffDepart == "129652783693249229"))) && (AM.KNet_Position == "102"))
                {
                    base.Base_SendMessage(AM.KNet_StaffNo + ",129785817148286979",
                        KNetPage.KHtmlEncode(
                            " <a href='Web/Xs/SalesContract/KNet_Sales_ContractList_List.aspx?WhereID=M170823051813470'  target=\"_blank\" onclick=\"RemoveSms('#ID', '', 0);\">今日有 " +
                            Convert.ToString(Dtb_Table.Rows.Count + 1) + "条 订单评审距离交货 还有3天，请跟踪！</a> "));
                }
            }
            s_Sql =
                "select * FROM Knet_Procure_OrdersList a  join v_OrderRKWithNoDel b on a.OrderNO=b.V_OrderNo   join KNet_Sys_ProcureType c on a.OrderType=c.ProcureTypeValue   where  1=1  and datediff(day,getdate(),OrderPreToDate)<=3   and rkState<>'1' and KPO_RkState='0' and orderType='128860698200781250' ";
            this.BeginQuery(s_Sql);
            Dtb_Table = this.QueryForDataTable();
            if (Dtb_Table.Rows.Count > 0)
            {
                if (((AM.KNet_StaffDepart == "131161769392290242") || (AM.KNet_StaffDepart == "129652783693249229")) &&
                    (AM.KNet_Position == "102"))
                {
                    base.Base_SendMessage(AM.KNet_StaffNo + ",129785817148286979",
                        KNetPage.KHtmlEncode(
                            " <a href='Web/CG/Order/Knet_Procure_OpenBilling_Manage_ForSc.aspx?WhereID=M150318091226587'  target=\"_blank\" onclick=\"RemoveSms('#ID', '', 0);\">今日有 " +
                            Convert.ToString(Dtb_Table.Rows.Count + 1) + "条 生产订单距离交货 还有3天，请跟踪！</a> "));

                }
            }

            s_Sql =
                "select * FROM Knet_Procure_OrdersList a  join v_OrderRKWithNoDel b on a.OrderNO=b.V_OrderNo   join KNet_Sys_ProcureType c on a.OrderType=c.ProcureTypeValue   where  1=1  and datediff(day,getdate(),OrderPreToDate)<=3   and rkState<>'1' and KPO_RkState='0' and orderType<>'128860698200781250' ";
            this.BeginQuery(s_Sql);
            Dtb_Table = this.QueryForDataTable();
            if (Dtb_Table.Rows.Count > 0)
            {
                if (((AM.KNet_StaffDepart == "129652784259578018") || (AM.KNet_StaffDepart == "129652783693249229")) &&
                    (AM.KNet_Position == "102"))
                {
                    base.Base_SendMessage(AM.KNet_StaffNo + ",129785817148286979",
                        KNetPage.KHtmlEncode(
                            " <a href='Web/CG/Order/Knet_Procure_OpenBilling_Manage.aspx?WhereID=M170823070418459'  target=\"_blank\" onclick=\"RemoveSms('#ID', '', 0);\">今日有 " +
                            Convert.ToString(Dtb_Table.Rows.Count + 1) + "条 采购订单距离交货 还有3天，请跟踪！</a> "));

                }
            }
            Session["Random"] = null;
            Session["Tokentime"] = null;
            string str_u = Request.ServerVariables["HTTP_USER_AGENT"];
            Regex b =
                new Regex(
                    @"android.+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            Regex v =
                new Regex(
                    @"1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(di|rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (!(b.IsMatch(str_u) || v.IsMatch(str_u.Substring(0, 4))))
            {
                //PC访问
                Response.Write(
                    "<script language='javascript' type='text/javascript'>this.window.location.href='NewMain.aspx';</script>");
                Response.End();
            }
            else
            {
                //手机访问
                Response.Write(
                    "<script language='javascript' type='text/javascript'>this.window.location.href='index.aspx';</script>");
                Response.End();
            }



            //}

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
    protected string User_Login(string user, string pass, string RandomNum)
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
                sqlcomm.Parameters.Add("@Staff_LoginIP", SqlDbType.VarChar, 40).Value =
                    Request.UserHostAddress.ToString();

                sqlcomm.Parameters.Add("@StaffNo", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
                sqlcomm.Parameters.Add("@Staff_LoginIP_Out", SqlDbType.NVarChar, 40).Direction =
                    ParameterDirection.Output;
                sqlcomm.Parameters.Add("@Staff_LoginDate_Out", SqlDbType.NVarChar, 50).Direction =
                    ParameterDirection.Output;
                sqlcomm.Parameters.Add("return1", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                sqlcomm.ExecuteNonQuery();

                result = int.Parse(sqlcomm.Parameters["return1"].Value.ToString());

                switch (result)
                {
                    case 0:
                       
                        try
                        {
                            if (Verification.Value=="false")
                            {
                                if (RandomNum == Session["Random"].ToString() &&
                               (DateTime.Now - DateTime.Parse(Session["Tokentime"].ToString())).TotalMinutes < 15)
                                {
                                    this.Session["KNet_Admin_StaffName"] = user; //卡号或是用名
                                    this.Session["KNet_Admin_PassWord"] = mywps;
                                    this.Session["KNet_Admin_StaffNo"] = sqlcomm.Parameters["@StaffNo"].Value.ToString();
                                    this.Session["KNet_Admin_Staff_LoginIP_Out"] =
                                        sqlcomm.Parameters["@Staff_LoginIP_Out"].Value.ToString();
                                    this.Session["KNet_Admin_Staff_LoginDate_Out"] =
                                        sqlcomm.Parameters["@Staff_LoginDate_Out"].Value.ToString();
                                    AdminloginMess AM = new AdminloginMess();
                                    AM.DeleteTimeOutUser();
                                    myssss = "登录成功";
                                    break;
                                }
                                else
                                {
                                    myssss = "验证码错误或者失效";
                                    Tbx_Weixin.Text = "";
                                    break;
                                }
                            }
                            else
                            {
                                this.Session["KNet_Admin_StaffName"] = user; //卡号或是用名
                                this.Session["KNet_Admin_PassWord"] = mywps;
                                this.Session["KNet_Admin_StaffNo"] = sqlcomm.Parameters["@StaffNo"].Value.ToString();
                                this.Session["KNet_Admin_Staff_LoginIP_Out"] =
                                    sqlcomm.Parameters["@Staff_LoginIP_Out"].Value.ToString();
                                this.Session["KNet_Admin_Staff_LoginDate_Out"] =
                                    sqlcomm.Parameters["@Staff_LoginDate_Out"].Value.ToString();
                                AdminloginMess AM = new AdminloginMess();
                                AM.DeleteTimeOutUser();
                                myssss = "登录成功";
                                break;
                            }
                           
                        }
                        catch
                        {

                            myssss = "验证码无效！请重新获取";
                            Tbx_Weixin.Text = "";
                            break;
                        }


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

    /// <summary>
    /// 获取验证码
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_OnClick(object sender, EventArgs e)
    {
        BackMess.Visible = false;
        if (Request.Form.Get("hiddenTestN").Equals(GetToken()))
        {
            KNet_Resource_Staff krs_Bll = new KNet_Resource_Staff();
            DataSet ds = krs_Bll.GetList(" StaffCard='" + username.Text.Trim() + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                try
                {
                    WXHttpHelper wx = new WXHttpHelper("wxa6bfcd91a60d6225", "abc123", "soOgsAaHep9BAMBcRvUGpwGIiqPzjjMD6RgzlJq9PBQ", "aRuWZfsH7PwZZ1JVLOzrehTUctZi2F7Mf0PcHMQJStU");
                    string Random = GenerateRandomNumber(6);
                    string jsonString = wx.WX_ActiveSend(ds.Tables[0].Rows[0]["StaffAddress"].ToString().Trim(), "", "", "text", "1000005", "验证码：" + Random);
                    JObject jo = (JObject)JsonConvert.DeserializeObject(jsonString);
                    string zone = jo["invaliduser"].ToString();
                    if (zone != "")
                    {
                        BackMess.Visible = true;
                        BackMess.Text = "用户名不正确";
                    }
                    else
                    {
                        Session["Random"] = Random.Trim();
                        SetToken();//别忘了最后要更新Session中的标志
                        Session["Tokentime"] = DateTime.Now.ToString();
                        ClientScript.RegisterStartupScript(ClientScript.GetType(), "bb", "<script type='text/javascript'>settime(Button2);</script>");
                    }
                }
                catch
                {

                    BackMess.Visible = true;
                    BackMess.Text = "获取验证码失败";
                }
               
            }
            else
            {
                BackMess.Visible = true;
                BackMess.Text = "获取验证码凭据无效";
            }



        }
        else
        {
            BackMess.Visible = true;
            BackMess.Text = "请获取验证码";
        }

    }

    private static char[] constant = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    public static string GenerateRandomNumber(int Length)//调用时想生成几位就几位；Length等于多少就多少位。
    {
        StringBuilder newRandom = new StringBuilder(10);
        Random rd = new Random();
        for (int i = 0; i < Length; i++)
        {
            newRandom.Append(constant[rd.Next(10)]);
        }
        return newRandom.ToString();
    }
    public string GetToken()
    {
        if (null != Session["Token"])
        {
            return Session["Token"].ToString();
        }
        else
        {
            return string.Empty;
        }
    }
    //生成标志，并保存到Session
    private void SetToken()
    {
        Session.Add("Token", Session.SessionID + DateTime.Now.Ticks.ToString());  // 可以不用UserMd5
    }
}
