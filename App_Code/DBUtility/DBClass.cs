using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace KNet.DBUtility
{
    public class DBClass
    {
        public DBClass()
        {
            
        }
        /// <summary>
        /// 获取数据库连接对象
        /// </summary>
        /// <param name="name">配置文件中连接字符串的name属性值</param>
        /// <returns></returns>
        public static SqlConnection GetConnection(string name)
        {
            string ConnStr = System.Configuration.ConfigurationManager.AppSettings["KNetERP"].ToString();
            SqlConnection Conn = new SqlConnection(ConnStr);
            return Conn;
        }
    }
}
