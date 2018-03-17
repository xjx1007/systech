using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类KNet_Sales_ClientAppseting。
    /// </summary>
    public class KNet_Sales_ClientAppseting
    {
        public KNet_Sales_ClientAppseting()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string Client_Name, int ClientKings)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@Client_Name", SqlDbType.NVarChar,50),
                    new SqlParameter("@ClientKings", SqlDbType.Int,4)};
            parameters[0].Value = Client_Name;
            parameters[1].Value = ClientKings;

            int result = DbHelperSQL.RunProcedure("Proc_KNet_Sales_ClientAppseting_Exists", parameters, out rowsAffected);
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///  增加一条数据
        /// </summary>
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.KNet_Sales_ClientAppseting model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KNet_Sales_ClientAppseting(");
            strSql.Append("ClientValue,Client_Name,ClientKings,Clientdefault,ClientPai,Client_FaterNo,Client_Code)");
            strSql.Append(" values (");
            strSql.Append("@ClientValue,@Client_Name,@ClientKings,@Clientdefault,@ClientPai,@Client_FaterNo,@Client_Code)");
            SqlParameter[] parameters = {
					new SqlParameter("@ClientValue", SqlDbType.NVarChar,50),
					new SqlParameter("@Client_Name", SqlDbType.NVarChar,50),
					new SqlParameter("@ClientKings", SqlDbType.Int,4),
					new SqlParameter("@Clientdefault", SqlDbType.Bit,1),
					new SqlParameter("@ClientPai", SqlDbType.Int,4),
					new SqlParameter("@Client_FaterNo", SqlDbType.NVarChar,50),
					new SqlParameter("@Client_Code", SqlDbType.VarChar,150)};
            parameters[0].Value = model.ClientValue;
            parameters[1].Value = model.Client_Name;
            parameters[2].Value = model.ClientKings;
            parameters[3].Value = model.Clientdefault;
            parameters[4].Value = model.ClientPai;
            parameters[5].Value = model.Client_FaterNo;
            parameters[6].Value = model.Client_Code;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Sales_ClientAppseting GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from KNet_Sales_ClientAppseting ");
            strSql.Append(" where ClientValue=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            KNet.Model.KNet_Sales_ClientAppseting model = new KNet.Model.KNet_Sales_ClientAppseting();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ClientValue"] != null && ds.Tables[0].Rows[0]["ClientValue"].ToString() != "")
                {
                    model.ClientValue = ds.Tables[0].Rows[0]["ClientValue"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Client_Name"] != null && ds.Tables[0].Rows[0]["Client_Name"].ToString() != "")
                {
                    model.Client_Name = ds.Tables[0].Rows[0]["Client_Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ClientKings"] != null && ds.Tables[0].Rows[0]["ClientKings"].ToString() != "")
                {
                    model.ClientKings = int.Parse(ds.Tables[0].Rows[0]["ClientKings"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Clientdefault"] != null && ds.Tables[0].Rows[0]["Clientdefault"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Clientdefault"].ToString() == "1") || (ds.Tables[0].Rows[0]["Clientdefault"].ToString().ToLower() == "true"))
                    {
                        model.Clientdefault = true;
                    }
                    else
                    {
                        model.Clientdefault = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["ClientPai"] != null && ds.Tables[0].Rows[0]["ClientPai"].ToString() != "")
                {
                    model.ClientPai = int.Parse(ds.Tables[0].Rows[0]["ClientPai"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Client_FaterNo"] != null && ds.Tables[0].Rows[0]["Client_FaterNo"].ToString() != "")
                {
                    model.Client_FaterNo = ds.Tables[0].Rows[0]["Client_FaterNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Client_Code"] != null && ds.Tables[0].Rows[0]["Client_Code"].ToString() != "")
                {
                    model.Client_Code = ds.Tables[0].Rows[0]["Client_Code"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.KNet_Sales_ClientAppseting model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KNet_Sales_ClientAppseting set ");
            strSql.Append("Client_Name=@Client_Name,");
            strSql.Append("ClientPai=@ClientPai,");
            strSql.Append("Client_FaterNo=@Client_FaterNo,");
            strSql.Append("Client_Code=@Client_Code");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@Client_Name", SqlDbType.NVarChar,50),
					new SqlParameter("@ClientPai", SqlDbType.Int,4),
					new SqlParameter("@Client_FaterNo", SqlDbType.NVarChar,50),
					new SqlParameter("@Client_Code", SqlDbType.VarChar,150),
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.Client_Name;
            parameters[1].Value = model.ClientPai;
            parameters[2].Value = model.Client_FaterNo;
            parameters[3].Value = model.Client_Code;
            parameters[4].Value = model.ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string ID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            DbHelperSQL.RunProcedure("Proc_KNet_Sales_ClientAppseting_Delete", parameters, out rowsAffected);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,ClientValue,Client_Name,case when Client_Code is null then Client_Name else Client_Name+'('+Client_Code+')' end as Name_Code,ClientKings,Clientdefault,ClientPai,Client_FaterNo,Client_Code ");
            strSql.Append(" FROM KNet_Sales_ClientAppseting ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  成员方法
    }
}

