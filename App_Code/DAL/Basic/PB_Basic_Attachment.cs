using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:PB_Basic_Attachment
    /// </summary>
    public partial class PB_Basic_Attachment
    {
        public PB_Basic_Attachment()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PBA_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PB_Basic_Attachment");
            strSql.Append(" where PBA_ID=@PBA_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBA_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = PBA_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.PB_Basic_Attachment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PB_Basic_Attachment(");
            strSql.Append("PBA_ID,PBA_FID,PBA_Name,PBA_Type,PBA_URL,PBA_Creator,PBA_CTime,PBA_Remarks,PBA_ProductsType,PBA_FileType,PBA_Del,PBA_State,PBA_UpdateFID,PBA_Edition)");
            strSql.Append(" values (");
            strSql.Append("@PBA_ID,@PBA_FID,@PBA_Name,@PBA_Type,@PBA_URL,@PBA_Creator,@PBA_CTime,@PBA_Remarks,@PBA_ProductsType,@PBA_FileType,@PBA_Del,@PBA_State,@PBA_UpdateFID,@PBA_Edition)");
            SqlParameter[] parameters = {
					new SqlParameter("@PBA_ID", SqlDbType.VarChar,50),
					new SqlParameter("@PBA_FID", SqlDbType.VarChar,50),
					new SqlParameter("@PBA_Name", SqlDbType.VarChar,250),
					new SqlParameter("@PBA_Type", SqlDbType.VarChar,50),
					new SqlParameter("@PBA_URL", SqlDbType.VarChar,350),
					new SqlParameter("@PBA_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@PBA_CTime", SqlDbType.DateTime),
					new SqlParameter("@PBA_Remarks", SqlDbType.VarChar,500),
					new SqlParameter("@PBA_ProductsType", SqlDbType.VarChar,50),
					new SqlParameter("@PBA_FileType", SqlDbType.VarChar,50),
					new SqlParameter("@PBA_Del", SqlDbType.Int,4),
					new SqlParameter("@PBA_State", SqlDbType.Int,4),
					new SqlParameter("@PBA_UpdateFID", SqlDbType.VarChar,50),
					new SqlParameter("@PBA_Edition", SqlDbType.VarChar,50)
        };
            parameters[0].Value = model.PBA_ID;
            parameters[1].Value = model.PBA_FID;
            parameters[2].Value = model.PBA_Name;
            parameters[3].Value = model.PBA_Type;
            parameters[4].Value = model.PBA_URL;
            parameters[5].Value = model.PBA_Creator;
            parameters[6].Value = model.PBA_CTime;
            parameters[7].Value = model.PBA_Remarks;
            parameters[8].Value = model.PBA_ProductsType;
            parameters[9].Value = model.PBA_FileType;
            parameters[10].Value = model.PBA_Del;
            parameters[11].Value = model.PBA_State;
            parameters[12].Value = model.PBA_UpdateFID;
            parameters[13].Value = model.PBA_Edition;
            
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.PB_Basic_Attachment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PB_Basic_Attachment set ");
            strSql.Append("PBA_FID=@PBA_FID,");
            strSql.Append("PBA_Name=@PBA_Name,");
            strSql.Append("PBA_Type=@PBA_Type,");
            strSql.Append("PBA_URL=@PBA_URL,");
            strSql.Append("PBA_Remarks=@PBA_Remarks");
            strSql.Append(" where PBA_ID=@PBA_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBA_FID", SqlDbType.VarChar,50),
					new SqlParameter("@PBA_Name", SqlDbType.VarChar,250),
					new SqlParameter("@PBA_Type", SqlDbType.Int,4),
					new SqlParameter("@PBA_URL", SqlDbType.VarChar,350),
					new SqlParameter("@PBA_Remarks", SqlDbType.VarChar,50),
					new SqlParameter("@PBA_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.PBA_FID;
            parameters[1].Value = model.PBA_Name;
            parameters[2].Value = model.PBA_Type;
            parameters[3].Value = model.PBA_URL;
            parameters[4].Value = model.PBA_Remarks;
            parameters[5].Value = model.PBA_ID;

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
        /// 更新一条数据
        /// </summary>
        public bool UpdateByState(KNet.Model.PB_Basic_Attachment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PB_Basic_Attachment set ");
            strSql.Append("PBA_State=@PBA_State ");
            strSql.Append(" where PBA_ID=@PBA_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBA_State", SqlDbType.Int,4),
					new SqlParameter("@PBA_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.PBA_State;
            parameters[1].Value = model.PBA_ID;

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
        /// 更新一条数据
        /// </summary>
        public bool UpdateByDel(KNet.Model.PB_Basic_Attachment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PB_Basic_Attachment set ");
            strSql.Append("PBA_Del=@PBA_Del ");
            strSql.Append(" where PBA_ID=@PBA_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBA_Del", SqlDbType.Int,4),
					new SqlParameter("@PBA_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.PBA_Del;
            parameters[1].Value = model.PBA_ID;

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
        public bool Delete(string PBA_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PB_Basic_Attachment ");
            strSql.Append(" where PBA_ID=@PBA_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBA_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = PBA_ID;

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
        public bool DeleteByFID(string PBA_FID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PB_Basic_Attachment ");
            strSql.Append(" where PBA_FID=@PBA_FID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBA_FID", SqlDbType.VarChar,50)};
            parameters[0].Value = PBA_FID;

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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string PBA_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PB_Basic_Attachment ");
            strSql.Append(" where PBA_ID in (" + PBA_IDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.PB_Basic_Attachment GetModel(string PBA_ID)
        {
            if (PBA_ID != "")
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select  top 1 * from PB_Basic_Attachment ");
                strSql.Append(" where PBA_ID=@PBA_ID ");
                SqlParameter[] parameters = {
					new SqlParameter("@PBA_ID", SqlDbType.VarChar,50)};
                parameters[0].Value = PBA_ID;

                KNet.Model.PB_Basic_Attachment model = new KNet.Model.PB_Basic_Attachment();
                DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["PBA_ID"] != null && ds.Tables[0].Rows[0]["PBA_ID"].ToString() != "")
                    {
                        model.PBA_ID = ds.Tables[0].Rows[0]["PBA_ID"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["PBA_FID"] != null && ds.Tables[0].Rows[0]["PBA_FID"].ToString() != "")
                    {
                        model.PBA_FID = ds.Tables[0].Rows[0]["PBA_FID"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["PBA_Name"] != null && ds.Tables[0].Rows[0]["PBA_Name"].ToString() != "")
                    {
                        model.PBA_Name = ds.Tables[0].Rows[0]["PBA_Name"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["PBA_Type"] != null && ds.Tables[0].Rows[0]["PBA_Type"].ToString() != "")
                    {
                        model.PBA_Type = ds.Tables[0].Rows[0]["PBA_Type"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["PBA_URL"] != null && ds.Tables[0].Rows[0]["PBA_URL"].ToString() != "")
                    {
                        model.PBA_URL = ds.Tables[0].Rows[0]["PBA_URL"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["PBA_Creator"] != null && ds.Tables[0].Rows[0]["PBA_Creator"].ToString() != "")
                    {
                        model.PBA_Creator = ds.Tables[0].Rows[0]["PBA_Creator"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["PBA_CTime"] != null && ds.Tables[0].Rows[0]["PBA_CTime"].ToString() != "")
                    {
                        model.PBA_CTime = DateTime.Parse(ds.Tables[0].Rows[0]["PBA_CTime"].ToString());
                    }
                    if (ds.Tables[0].Rows[0]["PBA_Remarks"] != null && ds.Tables[0].Rows[0]["PBA_Remarks"].ToString() != "")
                    {
                        model.PBA_Remarks = ds.Tables[0].Rows[0]["PBA_Remarks"].ToString();
                    }

                    if (ds.Tables[0].Rows[0]["PBA_Del"] != null && ds.Tables[0].Rows[0]["PBA_Del"].ToString() != "")
                    {
                        model.PBA_Del = int.Parse(ds.Tables[0].Rows[0]["PBA_Del"].ToString());
                    }

                    if (ds.Tables[0].Rows[0]["PBA_FileType"] != null && ds.Tables[0].Rows[0]["PBA_FileType"].ToString() != "")
                    {
                        model.PBA_FileType = ds.Tables[0].Rows[0]["PBA_FileType"].ToString();
                    }

                    if (ds.Tables[0].Rows[0]["PBA_State"] != null && ds.Tables[0].Rows[0]["PBA_State"].ToString() != "")
                    {
                        model.PBA_State = int.Parse(ds.Tables[0].Rows[0]["PBA_State"].ToString());
                    }


                    if (ds.Tables[0].Rows[0]["PBA_ProductsType"] != null && ds.Tables[0].Rows[0]["PBA_ProductsType"].ToString() != "")
                    {
                        model.PBA_ProductsType = ds.Tables[0].Rows[0]["PBA_ProductsType"].ToString();
                    }

                    if (ds.Tables[0].Rows[0]["PBA_Edition"] != null && ds.Tables[0].Rows[0]["PBA_Edition"].ToString() != "")
                    {
                        model.PBA_Edition = ds.Tables[0].Rows[0]["PBA_Edition"].ToString();
                    }

                    if (ds.Tables[0].Rows[0]["PBA_UpdateFID"] != null && ds.Tables[0].Rows[0]["PBA_UpdateFID"].ToString() != "")
                    {
                        model.PBA_UpdateFID = ds.Tables[0].Rows[0]["PBA_UpdateFID"].ToString();
                    }


                    return model;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM PB_Basic_Attachment ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM PB_Basic_Attachment ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "PB_Basic_Attachment";
            parameters[1].Value = "PBA_ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method
    }
}

