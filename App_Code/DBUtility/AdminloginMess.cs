using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Text;

using KNet.DBUtility;
using KNet.Common;

namespace KNet.DBUtility
{
    /// <summary>
    /// AdminloginMess 登陆处理的摘要说明 
    /// 会员登陆处理实体
    /// </summary>
    public class AdminloginMess : BasePage
    {
        //****************获取相关信息***************************************
        private string StaffNo;              //唯一号(Session)
        private string StaffCard;            //卡号(Session)
        private string StaffName;            //姓名 (Session)

        private string this_Staff_LoginIP;         //本次登陆IP地址
        private string Last_Staff_LoginIP;         //上次登陆IP地址
        private string this_Staff_LoginDate;       //本次登陆时间
        private string Last_Staff_LoginDate;       //上次登陆时间
        private string Staff_LoginNum;             //登陆数次

        private string _StaffBranch;               //公司编号
        private string _StaffDepart;               //公司部门
        private string _Position;               //公司职位

        private int _StaffLanguage;             //用户默认语言（1简体中文，2繁体中文）
        private int _StaffCatalogue;            //用户默认打开莱单栏
        private int _KRS_IsWeb;            //是否外网登陆

        private string _ProductsType;            //是否外网登陆


        private string WareHouse_ForSQL;    //受权仓库集的SQL语句
        private string ClientList_ForSQL;    //指派的客户的SQL语句
        private string Sys_CompanyName;         //公司名称(企业名称)
        private bool Sys_OutWarning = true;      //产品达到缺货报警时是否自动提醒 
        private bool Sys_NoticeYN = true;       //是否打开公告(0不打开,1打开,默认 1)
        private string Sys_NoticeContent = null; //公告内容
        private bool Sys_LogsYN = true;         //是否记录员工操作日志(1记录,0不记录,默认 1)
        private string Sys_Key;                 //受权码
        private string Sys_UserNo;              //用户编号
        private bool IsSale = false;              //用户编号



        /// <summary>
        ///是否为网上演示版 1 是，0 否
        /// </summary>
        private bool KNettestSee = Convert.ToBoolean(int.Parse(System.Configuration.ConfigurationManager.AppSettings["KnetReg"].ToString().Trim()));

        public AdminloginMess()
        {
            try
            {
                if (CheckLogin() == false)
                {
                    string s_Script = "<script language=javascript>alert('您登陆系统时发生错误,未能登陆成功!'); ";

                    s_Script += "var host = window.location.host;\n";
                    s_Script += " var url=window.location.href \n";
                    s_Script += " if(url.indexOf(\"WebMobile\")>0)\n";
                    s_Script += " { \n";
                    s_Script += "rootpath =\"http://\"+host+\"/\";parent.location.href = rootpath+\"WebMobile/widget/login.aspx\";";
                    s_Script += " }\n";
                    s_Script += " else\n";
                    s_Script += " { \n";
                    s_Script += "rootpath =\"http://\"+host+\"/\";parent.location.href = rootpath+\"Default.aspx\";";
                    s_Script += " }\n";
                    s_Script += " </script>\n";
                    
                   
                    System.Web.HttpContext.Current.Response.Write(s_Script);
                    System.Web.HttpContext.Current.Response.End();
                }
                else
                {
                    //上次登陆的IP地地址和时间
                    this.Last_Staff_LoginIP = HttpContext.Current.Session["KNet_Admin_Staff_LoginIP_Out"].ToString();
                    this.Last_Staff_LoginDate = HttpContext.Current.Session["KNet_Admin_Staff_LoginDate_Out"].ToString();

                    //卡号或用户名
                    string KStaffName = HttpContext.Current.Session["KNet_Admin_StaffName"].ToString();
                    string KStaffPassWord = HttpContext.Current.Session["KNet_Admin_PassWord"].ToString();


                    KNet.BLL.KNet_Resource_Staff bll = new KNet.BLL.KNet_Resource_Staff();
                    KNet.Model.KNet_Resource_Staff model = bll.GetModelB(KStaffName, KStaffPassWord);

                    ////用户信息
                    this.StaffNo = model.StaffNo;
                    this.StaffCard = model.StaffCard;
                    this.StaffName = model.StaffName;
                    this.this_Staff_LoginIP = model.Staff_LoginIP;
                    this.this_Staff_LoginDate = model.Staff_LoginDate.ToString();
                    this.Staff_LoginNum = model.Staff_LoginNum.ToString();
                    this._StaffBranch = model.StaffBranch;
                    this._StaffDepart = model.StaffDepart;
                    this._Position = model.Position;
                    this._StaffLanguage = model.StaffLanguage;
                    this._StaffCatalogue = model.StaffCatalogue;
                    this._KRS_IsWeb = model.KRS_IsWeb;
                    this._ProductsType = model.ProductsType;
                    if (model.isSale == 1)
                    {
                        IsSale = true;
                    }

                    this.WareHouse_ForSQL = GetKNet_Sys_WareHouseNameForSql(model.StaffNo);
                    // this.ClientList_ForSQL = GetKNet_Sys_ClientList_ForSql(model.StaffNo);

                    KNet.BLL.KNet_Sys_Config bll2 = new KNet.BLL.KNet_Sys_Config();
                    KNet.Model.KNet_Sys_Config model2 = bll2.GetModel(1);
                    //系统信息
                    this.Sys_CompanyName = model2.Sys_CompanyName;
                    this.Sys_OutWarning = model2.Sys_OutWarning;
                    this.Sys_NoticeYN = model2.Sys_LogsYN;
                    this.Sys_NoticeContent = model2.Sys_NoticeContent;
                    this.Sys_LogsYN = model2.Sys_LogsYN;
                    this.Sys_Key = model2.Sys_Key;
                    this.Sys_UserNo = model2.Sys_UserNo;
                }
            }
            catch
             {
                throw;
            }
        }


        /// <summary>
        /// 获得受保护的客户  数据列表
        /// </summary>
        private DataSet GetClientAuthList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select StaffNo,CustomerValue ");
            strSql.Append(" FROM KNet_Sales_ClientList_AuthList ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获取员工的指派客户数据 列表
        /// </summary>
        /// <param name="StaffNo"></param>
        /// <returns></returns>
        private string GetKNet_Sys_ClientList_ForSql(string StaffNo)
        {
            string ListStr = "";
            if (StaffNo.ToLower() == "admin")
            {
                ListStr = " 1=1 ";
            }
            else
            {
                using (DataSet ds = GetClientAuthList(" StaffNo='" + StaffNo + "'"))
                {
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        ListStr = " 1=2 ";
                    }
                    else
                    {
                        for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                        {
                            DataRowView mydrv = ds.Tables[0].DefaultView[i];
                            if (i == 0)
                            {
                                ListStr = " CustomerValue='" + mydrv["CustomerValue"].ToString() + "' ";
                            }
                            else
                            {
                                ListStr = ListStr + " or CustomerValue='" + mydrv["CustomerValue"].ToString() + "' ";
                            }
                        }
                    }
                }
            }
            return ListStr;
        }

        /// <summary>
        /// 获得受权仓库  数据列表
        /// </summary>
        private DataSet GetListAutolist(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select StaffNo,HouseNo ");
            strSql.Append(" FROM KNet_Sys_WareHouse_AuthList ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获取员工的仓库列表
        /// </summary>
        /// <param name="StaffNo"></param>
        /// <returns></returns>
        private string GetKNet_Sys_WareHouseNameForSql(string StaffNo)
        {
            string ListStr = "";
            if (StaffNo.ToLower() == "admin")
            {
                ListStr = " 1=1 ";
            }
            else
            {
                using (DataSet ds = GetListAutolist(" StaffNo='" + StaffNo + "'"))
                {
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        ListStr = " 1=2 ";
                    }
                    else
                    {
                        for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                        {
                            DataRowView mydrv = ds.Tables[0].DefaultView[i];
                            if (i == 0)
                            {
                                ListStr = " HouseNo='" + mydrv["HouseNo"].ToString() + "' ";
                            }
                            else
                            {
                                ListStr = ListStr + " or HouseNo='" + mydrv["HouseNo"].ToString() + "' ";
                            }
                        }
                    }
                }
            }
            return ListStr;
        }
        /// <summary>
        /// 获得受权用户组  数据列表
        /// </summary>
        private DataSet GettKNet_Sys_AuthorityUserGrouplist(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select StaffNo,GroupValue ");
            strSql.Append(" FROM KNet_Sys_Authority_AuthList ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获取员工所属的用户组 列表
        /// </summary>
        /// <param name="StaffNo"></param>
        /// <returns></returns>
        private string GetKNet_Sys_AuthorityUserGroupForSql(string StaffNo)
        {
            string ListStr = "";
            if (StaffNo.ToLower() == "admin")
            {
                ListStr = " 1=1 ";
            }
            else
            {
                using (DataSet ds = GettKNet_Sys_AuthorityUserGrouplist(" StaffNo='" + StaffNo + "'"))
                {
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        ListStr = " 1=2 ";
                    }
                    else
                    {
                        for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                        {
                            DataRowView mydrv = ds.Tables[0].DefaultView[i];
                            if (i == 0)
                            {
                                ListStr = " GroupValue='" + mydrv["GroupValue"].ToString() + "' ";
                            }
                            else
                            {
                                ListStr = ListStr + " or  GroupValue='" + mydrv["GroupValue"].ToString() + "' ";
                            }
                        }
                    }
                }
            }
            return ListStr;
        }


        //************************************************************************
        /// <summary>
        /// 验证用户是否拥有操作权限.返回True拥有权限,false没有权限
        /// </summary>
        /// <param name="AuthorityValue">功能编码</param>
        /// <returns></returns>
        public Boolean YNAuthority(string AuthorityName)
        {
            try
            {
                if (StaffName.ToUpper().CompareTo("ADMIN") != 0)
                {
                    using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
                    {
                        conn.Open();
                        SqlCommand MyComm = new SqlCommand("select AuthorityValue,GroupValue from KNet_Sys_AuthorityUserGroupSetup where (" + GetKNet_Sys_AuthorityUserGroupForSql(StaffNo) + ") and  AuthorityValue='" + GetUserAuthorityValue(AuthorityName) + "' ", conn);
                        using (SqlDataReader DR = MyComm.ExecuteReader())
                        {
                            if (DR.Read())
                            {
                                return true; //有权限   
                            }
                            else
                            {
                                if (StaffName == "项洲")
                                {
                                    return false;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 无权限时转向...
        /// </summary>
        /// <param name="AuthorityValue">权限值</param>
        public void NoAuthority(string AuthorityName)
        {
            HttpContext.Current.Response.Write("<style type=\"text/css\">");
            HttpContext.Current.Response.Write("<!--");
            HttpContext.Current.Response.Write("body {");
            HttpContext.Current.Response.Write("background-color: #ffffff;");
            HttpContext.Current.Response.Write("}");
            HttpContext.Current.Response.Write("-->");
            HttpContext.Current.Response.Write("</style>");
            HttpContext.Current.Response.Write("<br>");
            HttpContext.Current.Response.Write("<br>");
            HttpContext.Current.Response.Write("<br>");
            HttpContext.Current.Response.Write("<table width=\"600\" border=\"0\" align=\"center\" cellpadding=\"2\" cellspacing=\"2\" style=\"border:#006699 1px solid;\">");
            HttpContext.Current.Response.Write("<tr>");
            HttpContext.Current.Response.Write("<td width=\"18%\" style=\"border-bottom:#006699 1px dotted\"  align=\"center\"><img src=\"../../images/Esss.gif\" width=\"64\" height=\"64\" /></td>");
            HttpContext.Current.Response.Write("<td width=\"82%\" style=\"border-bottom:#006699 1px dotted\"  ><span style=\"font-size:20px;font-weight:bold;color:red;\">错误！您没有操作此功能的权限！</span></td>");
            HttpContext.Current.Response.Write("</tr>");
            HttpContext.Current.Response.Write("<tr>");
            if (GetUserAuthorityValue(AuthorityName) == -1)
            {
                HttpContext.Current.Response.Write("<span  style=\"font-size:13px;\">本操作权限名称: " + AuthorityName + " <a href=\"/Web/System/Authority/KNet_Sys_AuthorityTable_Add.aspx?AuthorityName=" + AuthorityName + "\">未注册</a></font></span><br />");
            }
            else
            {
                HttpContext.Current.Response.Write("<span  style=\"font-size:13px;\">本操作权限名称:<font color=Blue>" + base.Base_GetBasicCodeName("152", GetAuthorityGroup(AuthorityName).ToString()) + "--> " + AuthorityName + "</font><br /><a href='/Web/Message/System_Message_Manage.aspx?AuthorityName=" + AuthorityName + "' >申请该权限</a></span><br />");
            }
            HttpContext.Current.Response.Write("<br />");
            HttpContext.Current.Response.Write("<span  style=\"font-size:12px;\">需要有管理员身份登陆系统，然后在“系统设置”—>“用户权限设置”中受权设置拥有此权限的用户组</span></td>");
            HttpContext.Current.Response.Write("</tr>");
            HttpContext.Current.Response.Write("</table>");
            HttpContext.Current.Response.End();
        }
        //************************************************************************
        /// <summary>
        /// 获取用户组名称
        /// </summary>
        /// <param name="aa">功能编码</param>
        /// <returns></returns>
        private string GetUserGroupName(string GroupValue)
        {
            using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
            {
                conn.Open();
                string Dostr = "select ID,GroupValue,GroupName from KNet_Sys_AuthorityUserGroup where GroupValue='" + GroupValue + "'";
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
        /// <summary>
        /// 获得已受权用户组  数据列表
        /// </summary>
        private DataSet GetAuthorityValueList(int AuthorityValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select GroupValue from (select GroupValue,AuthorityValue");
            strSql.Append(" FROM KNet_Sys_AuthorityUserGroupSetup  where AuthorityValue=" + AuthorityValue + " ) as AA ");
            strSql.Append(" GROUP BY  GroupValue ");

            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获取用户组名称列表
        /// </summary>
        /// <param name="StaffNo"></param>
        /// <returns></returns>
        private string GetUserGroupNameAllList(int AuthorityValue)
        {
            string ListStr = "";
            using (DataSet ds = GetAuthorityValueList(AuthorityValue))
            {
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    DataRowView mydrv = ds.Tables[0].DefaultView[i];
                    if (i == 0)
                    {
                        ListStr = ListStr + GetUserGroupName(mydrv["GroupValue"].ToString());
                    }
                    else
                    {
                        ListStr = ListStr + "<B>|</B>" + GetUserGroupName(mydrv["GroupValue"].ToString());
                    }
                }
            }
            if (ListStr == "")
            {
                return "<font color=\"gray\">未有任何用户组</font>";
            }
            else
            {
                return ListStr;
            }
        }
        /// <summary>
        /// 获取权限名称
        /// </summary>
        /// <param name="aa">功能编码</param>
        /// <returns></returns>
        private string GetUserAuthorityName(string AuthorityValue)
        {
            try
            {
                using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
                {
                    conn.Open();
                    string Dostr = "select ID,AuthorityName,AuthorityValue from KNet_Sys_AuthorityTable where AuthorityValue=" + int.Parse(AuthorityValue) + "";
                    SqlCommand cmd = new SqlCommand(Dostr, conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        return dr["AuthorityName"].ToString().Trim();
                    }
                    else
                    {
                        return "--";
                    }
                }
            }
            catch { return "--"; }
        }
        /// <summary>
        /// 获取权限名称
        /// </summary>
        /// <param name="aa">功能编码</param>
        /// <returns></returns>
        private int GetUserAuthorityValue(string AuthorityName)
        {
            try
            {
                using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
                {
                    conn.Open();
                    string Dostr = "select ID,AuthorityName,AuthorityValue from KNet_Sys_AuthorityTable where AuthorityName='" + AuthorityName + "' ";
                    SqlCommand cmd = new SqlCommand(Dostr, conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        return int.Parse(dr["AuthorityValue"].ToString().Trim());
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            catch { return -1; }
        }

        /// <summary>
        /// 获取权限名称
        /// </summary>
        /// <param name="aa">功能编码</param>
        /// <returns></returns>
        private int GetAuthorityGroup(string AuthorityName)
        {
            try
            {
                using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
                {
                    conn.Open();
                    string Dostr = "select ID,AuthorityName,AuthorityValue,AuthorityGroup from KNet_Sys_AuthorityTable where AuthorityName='" + AuthorityName + "'";
                    SqlCommand cmd = new SqlCommand(Dostr, conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        return int.Parse(dr["AuthorityGroup"].ToString().Trim());
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            catch { return -1; }
        }




        //************************************************************
        //******基本设置属性***************************************
        //************************************************************
        /// <summary>
        /// 公司名称(企业名称)
        /// </summary>
        public string KNet_Sys_CompanyName
        {
            get
            {
                return Sys_CompanyName;
            }
        }
        /// <summary>
        /// 达到缺货报警时是否自动提醒 (0不打开,1打开,默认 1) 
        /// </summary>
        public bool KNet_Sys_OutWarning
        {
            get
            {
                return Sys_OutWarning;
            }
        }

        /// <summary>
        /// 是否打开公告(0不打开,1打开,默认 1) 
        /// </summary>
        public bool KNet_Sys_NoticeYN
        {
            get
            {
                return Sys_NoticeYN;
            }
        }
        /// <summary>
        /// 是否销售人员
        /// </summary>
        public bool KNet_IsSale
        {
            get
            {
                return IsSale;
            }
        }
        /// <summary>
        /// 公告内容
        /// </summary>
        public string KNet_Sys_NoticeContent
        {
            get
            {
                return Sys_NoticeContent;
            }
        }
        /// <summary>
        /// 是否记录员工操作日志(1记录,0不记录,默认 1)
        /// </summary>
        public bool KNet_Sys_LogsYN
        {
            get
            {
                return Sys_LogsYN;
            }
        }
        /// <summary>
        /// 受权注册码
        /// </summary>
        public string KNet_Sys_Key
        {
            get
            {
                return Sys_Key;
            }
        }
        /// <summary>
        /// 注册用户编号
        /// </summary>
        public string KNet_Sys_UserNo
        {
            get
            {
                return Sys_UserNo;
            }
        }
        //************************************************************
        //******用户登陆设置属性***************************************
        //private string StaffNo;              //唯一号(Session)
        //private string StaffCard;            //卡号(Session)
        //private string StaffName;            //姓名 (Session)

        //private string this_Staff_LoginIP;         //本次登陆IP地址
        //private string Last_Staff_LoginIP;         //上次登陆IP地址
        //private string this_Staff_LoginDate;       //本次登陆时间
        //private string Last_Staff_LoginDate;       //上次登陆时间
        //private string Staff_LoginNum;             //登陆数次
        //private string StaffBranch;               //公司编号
        //private string StaffDepart;               //公司部门
        //************************************************************

        /// <summary>
        /// 读受保护的客户列表   自己的SQL执行语句 ( CustomerValue='128502353068906250' or CustomerValue='128502377330781250')
        /// </summary>
        public string MyDoSqlWith_DoClientList
        {
            get
            {
                return ClientList_ForSQL;
            }
        }

        /// <summary>
        /// 读仓库时自己的SQL执行语句 ( HouseNo='128502353068906250' or HouseNo='128502377330781250')
        /// </summary>
        public string MyDoSqlWith_Do
        {
            get
            {
                return WareHouse_ForSQL;
            }
        }
        /// <summary>
        /// 员工公司编号
        /// </summary>
        public string KNet_StaffBranch
        {
            get
            {
                return _StaffBranch;
            }
        }
        /// <summary>
        /// 员工部门编号
        /// </summary>
        public string KNet_StaffDepart
        {
            get
            {
                return _StaffDepart;
            }
        }
        /// <summary>
        /// 员工职位编号
        /// </summary>
        public string KNet_Position
        {
            get
            {
                return _Position;
            }
        }
        /// <summary>
        /// 员工卡号或用户名
        /// </summary>
        public string KNet_StaffCard
        {
            get
            {
                return StaffCard;
            }
        }

        /// <summary>
        /// 员工唯一号
        /// </summary>
        public string KNet_StaffNo
        {
            get
            {
                return StaffNo;
            }
        }
        /// <summary>
        /// 员工登录名
        /// </summary>
        public string KNet_StaffName
        {
            get
            {
                return StaffName;
            }
        }

        public string ProductsType
        {
            get
            {
                return _ProductsType;
            }
        }
        
        /// <summary>
        /// 本次登录IP地址 
        /// </summary>
        public string KNet_this_Staff_LoginIP
        {
            get
            {
                return this_Staff_LoginIP;
            }
        }
        /// <summary>
        /// 上次登录IP地址
        /// </summary>
        public string KNet_Last_Staff_LoginIP
        {
            get
            {
                return Last_Staff_LoginIP;
            }
        }
        /// <summary>
        /// 本次登陆时间
        /// </summary>
        public string KNet_this_Staff_LoginDate
        {
            get
            {
                return this_Staff_LoginDate;
            }
        }
        /// <summary>
        /// 上次登陆时间
        /// </summary>
        public string KNet_Last_Staff_LoginDate
        {
            get
            {
                return Last_Staff_LoginDate;
            }
        }
        /// <summary>
        /// 登录数次
        /// </summary>
        public string KNet_Staff_LoginNum
        {
            get
            {
                return Staff_LoginNum;
            }
        }

        /// <summary>
        /// 是否是网上演示版 (1是,0否) 
        /// </summary>
        public bool KNet_Soft_WebTest
        {
            set { KNettestSee = value; }
            get { return KNettestSee; }
        }

        /// <summary>
        /// 用户默认语言（1简体中文，2繁体中文）
        /// </summary>
        public int KNet_Soft_StaffLanguage
        {
            set { _StaffLanguage = value; }
            get { return _StaffLanguage; }
        }
        /// <summary>
        /// 用户默认打开莱单栏
        /// </summary>
        public int KNet_Soft_StaffCatalogue
        {
            set { _StaffCatalogue = value; }
            get { return _StaffCatalogue; }
        }

        public int KRS_IsWeb
        {
            set { _KRS_IsWeb = value; }
            get { return _KRS_IsWeb; }
        }
        
        //************************************************************************
        /// <summary>
        /// 检查会员是否登录true已经登陆,false为没有登陆
        /// </summary>
        /// <returns></returns>
        public Boolean CheckLogin()
        {
            try
            {
                string strStaffName = Convert.ToString(HttpContext.Current.Session["KNet_Admin_StaffName"]);
                string strPassWord = Convert.ToString(HttpContext.Current.Session["KNet_Admin_PassWord"]);
                string strStaffNo = Convert.ToString(HttpContext.Current.Session["KNet_Admin_StaffNo"]);
                if ((strStaffName != "") && (strPassWord != "") && (strStaffNo != ""))
                {
                    DeleteTimeOutUser();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Boolean CheckLogin(string s_Title)
        {
            try
            {
                string strStaffName = Convert.ToString(HttpContext.Current.Session["KNet_Admin_StaffName"]);
                string strPassWord = Convert.ToString(HttpContext.Current.Session["KNet_Admin_PassWord"]);
                string strStaffNo = Convert.ToString(HttpContext.Current.Session["KNet_Admin_StaffNo"]);
                if ((strStaffName != "") && (strPassWord != "") && (strStaffNo != ""))
                {
                    if (YNAuthority(s_Title) == false)
                    {
                        NoAuthority(s_Title);
                    }
                    DeleteTimeOutUser();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        //************************************************************************
        /// <summary>
        /// 退出登陆
        /// </summary>
        public void Logout()
        {
            try
            {
                //更新在线状态
                DeleteOnlineUser(HttpContext.Current.Session["KNet_Admin_StaffNo"].ToString());
                HttpContext.Current.Session["KNet_Admin_StaffName"] = null;
                HttpContext.Current.Session["KNet_Admin_PassWord"] = null;
                HttpContext.Current.Session["KNet_Admin_StaffNo"] = null;
                HttpContext.Current.Session.Abandon();
            }
            catch { }
        }

        public void DeleteTimeOutUser()
        {

            try
            {
                KNet.BLL.KNet_Resource_Staff BLL = new BLL.KNet_Resource_Staff();
                //查找在线人数
                DataSet Dts_Table = BLL.GetList(" isOnline=1 ");
                if (Dts_Table.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                    {
                        DateTime Time = DateTime.Parse(Dts_Table.Tables[0].Rows[i]["staff_loginDate"].ToString());
                        string s_StaffNo = Dts_Table.Tables[0].Rows[i]["StaffNo"].ToString();
                        TimeSpan T_Time = DateTime.Now - Time;
                        if (T_Time.TotalMinutes > 50)
                        {
                            DeleteOnlineUser(s_StaffNo);
                        }
                    }
                    //删除超时的在线人数
                }
            }
            catch (Exception ex)
            { }
        }
        private void DeleteOnlineUser(string s_StaffNo)
        {
            try
            {
                KNet.BLL.KNet_Resource_Staff BLL = new BLL.KNet_Resource_Staff();
                KNet.Model.KNet_Resource_Staff Model = new Model.KNet_Resource_Staff();
                Model.StaffNo = s_StaffNo;
                Model.isOnline = 0;
                BLL.UpdateOnLine(Model);
            }
            catch (Exception ex)
            { }
        }

        public string GetOnlineCount()
        {
            string s_Return = "";
            try
            {
                BasePage Page = new BasePage();
                Page.BeginQuery("Select Count(*) From KNet_Resource_Staff  where IsOnline='1'");
                Page.QueryForDataTable();
                if (Page.Dtb_Result.Rows.Count > 0)
                {
                    s_Return = Page.Dtb_Result.Rows[0][0].ToString();
                }
            }
            catch (Exception ex)
            { }
            return s_Return;
        }

        //==================================
        /// <summary>
        /// 系统操作日志
        /// </summary>
        /// <param name="P_str_logContent">日志内容</param>
        public void Add_Logs(string P_str_logContent)
        {
            string StaffNoss = StaffNo;
            if (StaffNoss == null || StaffNoss == "") { StaffNoss = "未知用户"; }
            if (KNet_Sys_LogsYN == true)
            {
                using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
                {
                    SqlCommand myCmd = new SqlCommand("Proc_KNet_Static_logs_ADD", conn);
                    myCmd.CommandType = CommandType.StoredProcedure;

                    //添加参数
                    SqlParameter StaffNoPaner = new SqlParameter("@StaffNo", SqlDbType.VarChar, 30);
                    StaffNoPaner.Value = StaffNoss;
                    myCmd.Parameters.Add(StaffNoPaner);
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
                }
            }
        }
        
        //==================================
        /// <summary>
        /// 系统下载记录
        /// </summary>
        /// <param name="P_str_logContent">日志内容</param>
        
        public void Add_DownRecord(string s_FID)
        {
            string StaffNoss = StaffNo;
            if (StaffNoss == null || StaffNoss == "") { StaffNoss = "未知用户"; }
            if (KNet_Sys_LogsYN == true)
            {
                using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
                {
                    BasePage base1=new BasePage();
                    string s_Dosql = "insert into PB_Basic_Attachment_DownRecord values('" + base1.GetMainID() + "','" + s_FID + "',GetDate(),'" + StaffNoss + "','" + System.Web.HttpContext.Current.Request.UserHostAddress.ToString().Trim() + "')";
                   
                    try
                    {
                        DbHelperSQL.ExecuteSql(s_Dosql);
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
        }
        
        //=========================================================================
        /// <summary>
        /// true 受权正式版
        /// </summary>
        /// <returns></returns>
        public Boolean BsysGo()
        {
            return true;
        }

        //******************************************************************
        /// <summary>
        /// 免费用户提醒
        /// </summary>
        /// <returns></returns>
        public void Error_BsysCode(string TableName, int RecordNum)
        {
            if (KNetPage.GetDBTableNum(TableName) >= RecordNum)
            {
                HttpContext.Current.Response.Write("<style type=\"text/css\">");
                HttpContext.Current.Response.Write("<!--");
                HttpContext.Current.Response.Write("body {");
                HttpContext.Current.Response.Write("background-color: #EEF3F9;");
                HttpContext.Current.Response.Write("}");
                HttpContext.Current.Response.Write("-->");
                HttpContext.Current.Response.Write("</style>");
                HttpContext.Current.Response.Write("<br>");
                HttpContext.Current.Response.Write("<br>");
                HttpContext.Current.Response.Write("<br>");
                HttpContext.Current.Response.Write("<table width=\"700\" border=\"0\" align=\"center\" cellpadding=\"2\" cellspacing=\"2\" style=\"border:#006699 1px solid;\">");
                HttpContext.Current.Response.Write("<tr>");
                HttpContext.Current.Response.Write("<td width=\"18%\" style=\"border-bottom:#006699 1px dotted\"  align=\"center\"><img src=\"../../images/Esss.gif\" width=\"64\" height=\"64\" /></td>");
                HttpContext.Current.Response.Write("<td width=\"82%\" style=\"border-bottom:#006699 1px dotted\"  ><span  style=\"font-size:20px;font-weight:bold;\">对不起，您是非受权用户，数据已超出系统受予试用量！</span></td>");
                HttpContext.Current.Response.Write("</tr>");
                HttpContext.Current.Response.Write("<tr>");
                HttpContext.Current.Response.Write("<td height=\"60\" colspan=\"2\" ><span  style=\"font-size:13px;font-weight: bold;\">如果您想再继续试用，请把数据库表:" + TableName + " 中的部份记录删除再试用！</span><br />");
                HttpContext.Current.Response.Write("<span  style=\"font-size:12px;color:#999999;\">提示:删除原始数据将会直接影响到系统的数据完整性,会直接导致系统的异常出错。我们建议您购买受权码，有关信息请直接与我们联系！</span></td>");
                HttpContext.Current.Response.Write("</tr>");
                HttpContext.Current.Response.Write("<tr>");
                HttpContext.Current.Response.Write("<td height=\"86\" colspan=\"2\" style=\"font-size:12px;\"><br />");
                HttpContext.Current.Response.Write("<a href=\"\" target=\"_blank\"></a></td>");
                HttpContext.Current.Response.Write("</tr>");
                HttpContext.Current.Response.Write("</table>");
                HttpContext.Current.Response.End();
            }
        }
        //==========************************************************============
    }
}