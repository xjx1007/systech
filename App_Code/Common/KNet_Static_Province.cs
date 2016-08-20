using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Data.SqlClient;

using KNet.DBUtility;


namespace KNet.Common
{
    public class KNet_Static_Province
    {
        public KNet_Static_Province()
        {}

        /// <summary>
        /// 获取省的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DataSet GetProvinceInfo(string s_Where)
        {

            string sql = "select ID,Code,Space(Lev-1)+'|--'+Name+'('+Code+')' as Name,FaterID,Lev from KNet_Static_Province where 1=1  " + s_Where;
            sql += " Order by Code";
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
        public static DataSet GetCityInfo(string sheng)
        {

            string sql = "select * from KNet_Static_City where provinceId=" + sheng + "";
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
        /// 获得区的信息
        /// </summary>
        /// <returns></returns>
        public static DataSet GetAreaInfo(string shi)
        {

            string sql = "select * from KNet_Static_Area where cityId=" + shi + "";
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