using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Data.SqlClient;

using KNet.DBUtility;


namespace KNet.Common
{
    public class KNet_Static_BigClass
    {
        public KNet_Static_BigClass()
        {}

        /// <summary>
        /// 获取省的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DataSet GetBigInfo()
        {

            string sql = "select * from KNet_Sys_BigCategories";
            SqlCommand cmd = new SqlCommand();
            //定义对象资源保存的范围，一旦using范围结束，将释放对方所占的资源
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.ConnectionStringLocalTransaction))
            {
                //调用执行方法，因为没有参数，所以最后一项直接设置为null
                //注意返回结果是dataset类型
                DataSet myds = DbHelperSQL.ExecuteDataSet(CommandType.Text, sql);
                return myds;
            }
        }
        /// <summary>
        /// 获得市的信息
        /// </summary>
        /// <returns></returns>
        public static DataSet GetSmallInfo(string BigNo)
        {

            string sql = "select * from KNet_Sys_SmallCategories where BigNo=" + BigNo + "";
            SqlCommand cmd = new SqlCommand();
            //定义对象资源保存的范围，一旦using范围结束，将释放对方所占的资源
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.ConnectionStringLocalTransaction))
            {
                //调用执行方法，因为没有参数，所以最后一项直接设置为null
                //注意返回结果是dataset类型
                DataSet myds = DbHelperSQL.ExecuteDataSet(CommandType.Text, sql);
                return myds;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataSet GetInfo(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            //定义对象资源保存的范围，一旦using范围结束，将释放对方所占的资源
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.ConnectionStringLocalTransaction))
            {
                //调用执行方法，因为没有参数，所以最后一项直接设置为null
                //注意返回结果是dataset类型
                DataSet myds = DbHelperSQL.ExecuteDataSet(CommandType.Text, sql);
                return myds;
            }
        }
    }
}