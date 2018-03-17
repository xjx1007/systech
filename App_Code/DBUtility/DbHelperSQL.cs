using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Collections; 
using System.Data.SqlClient;


/// <summary>
/// 数据库的通用访问代码 
/// 此类为抽象类，不允许实例化，在应用时直接调用即可
/// </summary>
public abstract class DbHelperSQL
{

    //获取数据库连接字符串，其属于静态变量且只读，项目中所有文档可以直接使用，但不能修改
    public static readonly string ConnectionStringLocalTransaction = ConfigurationManager.AppSettings["KNetERP"].ToString();

    // 哈希表用来存储缓存的参数信息，哈希表可以存储任意类型的参数。
    private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

    /*返回数据库连接*/
    public static SqlConnection getConnection()
    {
        SqlConnection c = new SqlConnection(ConnectionStringLocalTransaction);
        return c;
    }
    /// <summary>
    ///执行一个不需要返回值的SqlCommand命令，通过指定专用的连接字符串。
    /// 使用参数数组形式提供参数列表 
    /// </summary>
    /// <remarks>
    ///  使用示例:
    ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
    /// </remarks>
    /// <param name="connectionString">一个有效的数据库连接字符串</param>
    /// <param name="commandType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
    /// <param name="commandText">存储过程的名字或者 T-SQL 语句</param>
    /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
    /// <returns>返回一个数值表示此SqlCommand命令执行后影响的行数</returns>
    public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {
        SqlCommand cmd = new SqlCommand();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            //通过PrePareCommand方法将参数逐个加入到SqlCommand的参数集合中
            PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();

            //清空SqlCommand中的参数列表
            cmd.Parameters.Clear();
            return val;
        }
    }


    /// <summary>
    ///执行一条不返回结果的SqlCommand，通过一个已经存在的数据库连接 
    /// 使用参数数组提供参数
    /// </summary>
    /// <remarks>
    /// 使用示例:  
    ///  int result = ExecuteNonQuery(conn, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
    /// </remarks>
    /// <param name="connection">一个现有的数据库连接</param>
    /// <param name="commandType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
    /// <param name="commandText">存储过程的名字或者 T-SQL 语句</param>
    /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
    /// <returns>返回一个数值表示此SqlCommand命令执行后影响的行数</returns>
    public static int ExecuteNonQuery(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {
        SqlCommand cmd = new SqlCommand();
        PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
        int val = cmd.ExecuteNonQuery();
        cmd.Parameters.Clear();
        return val;
    }

    /// <summary>
    /// 执行一条不返回结果的SqlCommand，通过一个已经存在的数据库事物处理 
    /// 使用参数数组提供参数
    /// </summary>
    /// <remarks>
    /// 使用示例: 
    ///  int result = ExecuteNonQuery(trans, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
    /// </remarks>
    /// <param name="trans">一个存在的 sql 事物处理</param>
    /// <param name="commandType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
    /// <param name="commandText">存储过程的名字或者 T-SQL 语句</param>
    /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
    /// <returns>返回一个数值表示此SqlCommand命令执行后影响的行数</returns>
    public static int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {
        SqlCommand cmd = new SqlCommand();
        PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
        int val = cmd.ExecuteNonQuery();
        cmd.Parameters.Clear();
        return val;
    }

    /// <summary>
    /// 执行一条返回结果集的SqlCommand命令，通过专用的连接字符串。
    /// 使用参数数组提供参数
    /// </summary>
    /// <remarks>
    /// 使用示例:  
    ///  SqlDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
    /// </remarks>
    /// <param name="connectionString">一个有效的数据库连接字符串</param>
    /// <param name="commandType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
    /// <param name="commandText">存储过程的名字或者 T-SQL 语句</param>
    /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
    /// <returns>返回一个包含结果的SqlDataReader</returns>
    public static SqlDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection(connectionString);
        // 在这里使用try/catch处理是因为如果方法出现异常，则SqlDataReader就不存在，
        //CommandBehavior.CloseConnection的语句就不会执行，触发的异常由catch捕获。
        //关闭数据库连接，并通过throw再次引发捕捉到的异常。
        try
        {
            PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd.Parameters.Clear();
            return rdr;
        }
        catch
        {
            conn.Close();
            throw;
        }
    }
    /// <summary>
    /// 执行一条返回第一条记录第一列的SqlCommand命令，通过专用的连接字符串。 
    /// 使用参数数组提供参数
    /// </summary>
    /// <remarks>
    /// 使用示例:  
    ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
    /// </remarks>
    /// <param name="connectionString">一个有效的数据库连接字符串</param>
    /// <param name="commandType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
    /// <param name="commandText">存储过程的名字或者 T-SQL 语句</param>
    /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
    /// <returns>返回一个object类型的数据，可以通过 Convert.To{Type}方法转换类型</returns>
    public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {
        SqlCommand cmd = new SqlCommand();
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }
    }

    /// <summary>
    /// 执行一条返回第一条记录第一列的SqlCommand命令，通过已经存在的数据库连接。
    /// 使用参数数组提供参数
    /// </summary>
    /// <remarks>
    /// 使用示例: 
    ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
    /// </remarks>
    /// <param name="conn">一个已经存在的数据库连接</param>
    /// <param name="commandType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
    /// <param name="commandText">存储过程的名字或者 T-SQL 语句</param>
    /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
    /// <returns>返回一个object类型的数据，可以通过 Convert.To{Type}方法转换类型</returns>
    public static object ExecuteScalar(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {

        SqlCommand cmd = new SqlCommand();
        PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
        object val = cmd.ExecuteScalar();
        cmd.Parameters.Clear();
        return val;
    }
    /// <summary>
    /// 缓存参数数组
    /// </summary>
    /// <param name="cacheKey">参数缓存的键值</param>
    /// <param name="cmdParms">被缓存的参数列表</param>
    public static void CacheParameters(string cacheKey, params SqlParameter[] commandParameters)
    {
        parmCache[cacheKey] = commandParameters;
    }
    /// <summary>
    /// 获取被缓存的参数
    /// </summary>
    /// <param name="cacheKey">用于查找参数的KEY值</param>
    /// <returns>返回缓存的参数数组</returns>
    public static SqlParameter[] GetCachedParameters(string cacheKey)
    {
        SqlParameter[] cachedParms = (SqlParameter[])parmCache[cacheKey];

        if (cachedParms == null)
            return null;

        //新建一个参数的克隆列表
        SqlParameter[] clonedParms = new SqlParameter[cachedParms.Length];

        //通过循环为克隆参数列表赋值
        for (int i = 0, j = cachedParms.Length; i < j; i++)
            //使用clone方法复制参数列表中的参数
            clonedParms[i] = (SqlParameter)((ICloneable)cachedParms[i]).Clone();

        return clonedParms;
    }

    /// <summary>
    ///  为执行命令准备参数
    /// </summary>
    /// <param name="cmd"></param>
    /// <param name="conn"></param>
    /// <param name="trans"></param>
    /// <param name="cmdText"></param>
    /// <param name="cmdParms"></param>
    private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
    {
        if (conn.State != ConnectionState.Open)
            conn.Open();
        cmd.Connection = conn;
        cmd.CommandText = cmdText;
        if (trans != null)
            cmd.Transaction = trans;
        cmd.CommandType = CommandType.Text;//cmdType;
        if (cmdParms != null)
        {


            foreach (SqlParameter parameter in cmdParms)
            {
                if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                    (parameter.Value == null))
                {
                    parameter.Value = DBNull.Value;
                }
                cmd.Parameters.Add(parameter);
            }
        }
    }
    /// <summary>
    /// 为执行命令准备参数
    /// </summary>
    /// <param name="cmd">SqlCommand 命令</param>
    /// <param name="conn">已经存在的数据库连接</param>
    /// <param name="trans">数据库事物处理</param>
    /// <param name="cmdType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
    /// <param name="cmdText">Command text，T-SQL语句 例如 Select * from Products</param>
    /// <param name="cmdParms">返回带参数的命令</param>
    private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
    {

        //判断数据库连接状态
        if (conn.State != ConnectionState.Open)
            conn.Open();
        cmd.Connection = conn;
        cmd.CommandText = cmdText;

        //判断是否需要事物处理
        if (trans != null)
            cmd.Transaction = trans;

        cmd.CommandType = cmdType;

        if (cmdParms != null)
        {
            foreach (SqlParameter parm in cmdParms)
                cmd.Parameters.Add(parm);
        }
    }

       #region ExecuteDataSet

        /// <summary>
        /// 返加dataset
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="cmdType">命令类型，如StoredProcedure,Text</param>
        /// <param name="cmdText">the stored procedure name or T-SQL command</param>
        /// <returns>DataSet</returns>
        public static DataSet ExecuteDataSet(string connectionString, CommandType cmdType, string cmdText)
        {
            SqlConnection SqlDataConn = new SqlConnection(connectionString);
            SqlCommand SqlComm = new SqlCommand(cmdText, SqlDataConn);
            SqlComm.CommandType = cmdType;
            SqlDataAdapter SqlDA = new SqlDataAdapter(SqlComm);
            DataSet DS = new DataSet();
            SqlDA.Fill(DS);
            return DS;
        }

        /// <summary>
        /// 使用定义好的连接字符串
        /// </summary>
        /// <param name="cmdType">命令文本类型</param>
        /// <param name="cmdText">命令文本</param>
        /// <returns>DataSet</returns>
        public static DataSet ExecuteDataSet(CommandType cmdType, string cmdText)
        {
            SqlConnection SqlDataConn = new SqlConnection(ConnectionStringLocalTransaction);
            SqlCommand SqlComm = new SqlCommand(cmdText, SqlDataConn);
            SqlComm.CommandType = cmdType;
            SqlDataAdapter SqlDA = new SqlDataAdapter(SqlComm);
            DataSet DS = new DataSet();
            SqlDA.Fill(DS);
            return DS;
        }
        /// <summary>
        /// 使用定义好的连接字符串,CommandType默认为StoredProcedure
        /// </summary>
        /// <param name="cmdText">存储过程名</param>
        /// <returns>object</returns>
      public static DataSet ExecuteDataSet(string cmdText)
      {
          SqlConnection SqlDataConn = new SqlConnection(ConnectionStringLocalTransaction);
            SqlCommand SqlComm = new SqlCommand(cmdText, SqlDataConn);
            SqlComm.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter SqlDA = new SqlDataAdapter(SqlComm);
            DataSet DS = new DataSet();
            SqlDA.Fill(DS);
            return DS;
      }
     
     #endregion

        /// <summary>
        /// 执行存储过程，返回影响的行数		
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="rowsAffected">影响的行数</param>
        /// <returns></returns>
        public static int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringLocalTransaction))
            {
                int result;
                connection.Open();
                
                SqlCommand command = BuildIntCommand(connection, storedProcName, parameters);
                command.CommandTimeout = 10000;
                rowsAffected = command.ExecuteNonQuery();
                result = (int)command.Parameters["ReturnValue"].Value;
                //Connection.Close();
                return result;
            }
        }
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="tableName">DataSet结果中的表名</param>
        /// <returns>DataSet</returns>
        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringLocalTransaction))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.Fill(dataSet, tableName);
                connection.Close();
                return dataSet;
            }
        }
        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName, int Times)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringLocalTransaction))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.SelectCommand.CommandTimeout = Times;
                sqlDA.Fill(dataSet, tableName);
                connection.Close();
                return dataSet;
            }
        }
        /// <summary>
        /// 创建 SqlCommand 对象实例(用来返回一个整数值)	
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand 对象实例</returns>
        private static SqlCommand BuildIntCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.Parameters.Add(new SqlParameter("ReturnValue",
                SqlDbType.Int, 4, ParameterDirection.ReturnValue,
                false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }
        /// <summary>
        /// 构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand</returns>
        private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }
            return command;
        }

    /// <summary>
    /// 是否存在记录
    /// </summary>
    /// <param name="strSql"></param>
    /// <returns></returns>
    public static bool Exists(string strSql)
    {
        object obj = DbHelperSQL.GetSingle(strSql);
        int cmdresult;
        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
        {
            cmdresult = 0;
        }
        else
        {
            cmdresult = int.Parse(obj.ToString());
        }
        if (cmdresult == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    /// <summary>
    /// 是否存在记录
    /// </summary>
    /// <param name="strSql"></param>
    /// <param name="cmdParms"></param>
    /// <returns></returns>
    public static bool Exists(string strSql, params SqlParameter[] cmdParms)
    {
        object obj = DbHelperSQL.GetSingle(strSql, cmdParms);
        int cmdresult;
        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
        {
            cmdresult = 0;
        }
        else
        {
            cmdresult = int.Parse(obj.ToString());
        }
        if (cmdresult == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    /// <summary>
    /// 执行一条计算查询结果语句，返回查询结果（object）。
    /// </summary>
    /// <param name="SQLString">计算查询结果语句</param>
    /// <returns>查询结果（object）</returns>
    public static object GetSingle(string SQLString)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionStringLocalTransaction))
        {
            using (SqlCommand cmd = new SqlCommand(SQLString, connection))
            {
                try
                {
                    connection.Open();
                    object obj = cmd.ExecuteScalar();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    connection.Close();
                    throw e;
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }
    }
    /// <summary>
    /// 执行一条计算查询结果语句，返回查询结果（object）
    /// </summary>
    /// <param name="SQLString"></param>
    /// <param name="Times">执行时间</param>
    /// <returns></returns>
    public static object GetSingle(string SQLString, int Times)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionStringLocalTransaction))
        {
            using (SqlCommand cmd = new SqlCommand(SQLString, connection))
            {
                try
                {
                    connection.Open();
                    cmd.CommandTimeout = Times;
                    object obj = cmd.ExecuteScalar();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    connection.Close();
                    throw e;
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }
    }

    /// <summary>
    /// 执行一条计算查询结果语句，返回查询结果（object）。
    /// </summary>
    /// <param name="SQLString">计算查询结果语句</param>
    /// <returns>查询结果（object）</returns>
    public static object GetSingle(string SQLString, params SqlParameter[] cmdParms)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionStringLocalTransaction))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                    object obj = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    throw e;
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }
    }
        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringLocalTransaction))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd,connection,null,SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        throw e;
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 执行带一个存储过程参数的的SQL语句。
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString, string content)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringLocalTransaction))
            {
                SqlCommand cmd = new SqlCommand(SQLString, connection);
                System.Data.SqlClient.SqlParameter myParameter = new System.Data.SqlClient.SqlParameter("@content", SqlDbType.NText);
                myParameter.Value = content;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    throw e;
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }
        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringLocalTransaction))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringLocalTransaction))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return ds;
            }
        }
        public static DataSet Query(string SQLString, int Times)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringLocalTransaction))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.SelectCommand.CommandTimeout = Times;
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return ds;
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringLocalTransaction))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }
                    return ds;
                }
            }
        }
        /// <summary>
        /// 得到最大ID值
        /// </summary>
        /// <param name="FieldName"></param>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public static int GetMaxID(string FieldName, string TableName)
        {
            string strsql = "select max(" + FieldName + ")+1 from " + TableName;
            object obj = DbHelperSQL.GetSingle(strsql);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }
  }