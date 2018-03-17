using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet  .DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:PB_Basic_ProductsClass
    /// </summary>
    public partial class PB_Basic_ProductsClass
    {
        public PB_Basic_ProductsClass()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PBP_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PB_Basic_ProductsClass");
            strSql.Append(" where PBP_ID=@PBP_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBP_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = PBP_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsFaterID(string PBP_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PB_Basic_ProductsClass");
            strSql.Append(" where PBP_FaterID=@PBP_FaterID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBP_FaterID", SqlDbType.VarChar,50)};
            parameters[0].Value = PBP_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.PB_Basic_ProductsClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PB_Basic_ProductsClass(");
            strSql.Append("PBP_ID,PBP_Code,PBP_Name,PBP_FaterID,PBP_Order,PBP_Creator,PBP_CTime,PBP_MTime,PBP_Mender,PBP_Days,PBP_OrderDays,PBP_Type)");
            strSql.Append(" values (");
            strSql.Append("@PBP_ID,@PBP_Code,@PBP_Name,@PBP_FaterID,@PBP_Order,@PBP_Creator,@PBP_CTime,@PBP_MTime,@PBP_Mender,@PBP_Days,@PBP_OrderDays,@PBP_Type)");
            SqlParameter[] parameters = {
					new SqlParameter("@PBP_ID", SqlDbType.VarChar,50),
					new SqlParameter("@PBP_Code", SqlDbType.VarChar,50),
					new SqlParameter("@PBP_Name", SqlDbType.VarChar,50),
					new SqlParameter("@PBP_FaterID", SqlDbType.VarChar,50),
					new SqlParameter("@PBP_Order", SqlDbType.VarChar,50),
					new SqlParameter("@PBP_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@PBP_CTime", SqlDbType.DateTime),
					new SqlParameter("@PBP_MTime", SqlDbType.DateTime),
					new SqlParameter("@PBP_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@PBP_Days", SqlDbType.Int,4),
					new SqlParameter("@PBP_OrderDays", SqlDbType.Int,4),
					new SqlParameter("@PBP_Type", SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.PBP_ID;
            parameters[1].Value = model.PBP_Code;
            parameters[2].Value = model.PBP_Name;
            parameters[3].Value = model.PBP_FaterID;
            parameters[4].Value = model.PBP_Order;
            parameters[5].Value = model.PBP_Creator;
            parameters[6].Value = model.PBP_CTime;
            parameters[7].Value = model.PBP_MTime;
            parameters[8].Value = model.PBP_Mender;
            parameters[9].Value = model.PBP_Days;
            parameters[10].Value = model.PBP_OrderDays;
            parameters[11].Value = model.PBP_Type;
            
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.PB_Basic_ProductsClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PB_Basic_ProductsClass set ");
            strSql.Append("PBP_Code=@PBP_Code,");
            strSql.Append("PBP_Name=@PBP_Name,");
            strSql.Append("PBP_FaterID=@PBP_FaterID,");
            strSql.Append("PBP_Order=@PBP_Order,");
            strSql.Append("PBP_MTime=@PBP_MTime,");
            strSql.Append("PBP_Mender=@PBP_Mender,");
            strSql.Append("PBP_Days=@PBP_Days,");
            strSql.Append("PBP_OrderDays=@PBP_OrderDays,");
            strSql.Append("PBP_Type=@PBP_Type");
            
            strSql.Append(" where PBP_ID=@PBP_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBP_Code", SqlDbType.VarChar,50),
					new SqlParameter("@PBP_Name", SqlDbType.VarChar,50),
					new SqlParameter("@PBP_FaterID", SqlDbType.VarChar,50),
					new SqlParameter("@PBP_Order", SqlDbType.VarChar,50),
					new SqlParameter("@PBP_MTime", SqlDbType.DateTime),
					new SqlParameter("@PBP_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@PBP_Days", SqlDbType.Int,50),
					new SqlParameter("@PBP_OrderDays", SqlDbType.Int,50),
					new SqlParameter("@PBP_Type", SqlDbType.Int,4),
                    
					new SqlParameter("@PBP_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.PBP_Code;
            parameters[1].Value = model.PBP_Name;
            parameters[2].Value = model.PBP_FaterID;
            parameters[3].Value = model.PBP_Order;
            parameters[4].Value = model.PBP_MTime;
            parameters[5].Value = model.PBP_Mender;
            parameters[6].Value = model.PBP_Days;
            parameters[7].Value = model.PBP_OrderDays;
            parameters[8].Value = model.PBP_Type;
            
            parameters[9].Value = model.PBP_ID;

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
        public bool Delete(string PBP_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PB_Basic_ProductsClass ");
            strSql.Append(" where PBP_ID=@PBP_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBP_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = PBP_ID;

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
        public bool DeleteList(string PBP_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PB_Basic_ProductsClass ");
            strSql.Append(" where PBP_ID in (" + PBP_IDlist + ")  ");
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
        public KNet.Model.PB_Basic_ProductsClass GetModel(string PBP_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from PB_Basic_ProductsClass ");
            strSql.Append(" where PBP_ID=@PBP_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBP_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = PBP_ID;

            KNet.Model.PB_Basic_ProductsClass model = new KNet.Model.PB_Basic_ProductsClass();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PBP_ID"] != null && ds.Tables[0].Rows[0]["PBP_ID"].ToString() != "")
                {
                    model.PBP_ID = ds.Tables[0].Rows[0]["PBP_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBP_Code"] != null && ds.Tables[0].Rows[0]["PBP_Code"].ToString() != "")
                {
                    model.PBP_Code = ds.Tables[0].Rows[0]["PBP_Code"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBP_Name"] != null && ds.Tables[0].Rows[0]["PBP_Name"].ToString() != "")
                {
                    model.PBP_Name = ds.Tables[0].Rows[0]["PBP_Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBP_FaterID"] != null && ds.Tables[0].Rows[0]["PBP_FaterID"].ToString() != "")
                {
                    model.PBP_FaterID = ds.Tables[0].Rows[0]["PBP_FaterID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBP_Order"] != null && ds.Tables[0].Rows[0]["PBP_Order"].ToString() != "")
                {
                    model.PBP_Order = int.Parse(ds.Tables[0].Rows[0]["PBP_Order"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PBP_Creator"] != null && ds.Tables[0].Rows[0]["PBP_Creator"].ToString() != "")
                {
                    model.PBP_Creator = ds.Tables[0].Rows[0]["PBP_Creator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBP_CTime"] != null && ds.Tables[0].Rows[0]["PBP_CTime"].ToString() != "")
                {
                    model.PBP_CTime = DateTime.Parse(ds.Tables[0].Rows[0]["PBP_CTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PBP_MTime"] != null && ds.Tables[0].Rows[0]["PBP_MTime"].ToString() != "")
                {
                    model.PBP_MTime = DateTime.Parse(ds.Tables[0].Rows[0]["PBP_MTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PBP_Mender"] != null && ds.Tables[0].Rows[0]["PBP_Mender"].ToString() != "")
                {
                    model.PBP_Mender = ds.Tables[0].Rows[0]["PBP_Mender"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBP_Days"] != null && ds.Tables[0].Rows[0]["PBP_Days"].ToString() != "")
                {
                    model.PBP_Days = int.Parse(ds.Tables[0].Rows[0]["PBP_Days"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PBP_OrderDays"] != null && ds.Tables[0].Rows[0]["PBP_OrderDays"].ToString() != "")
                {
                    model.PBP_OrderDays = int.Parse(ds.Tables[0].Rows[0]["PBP_OrderDays"].ToString());
                }

                if (ds.Tables[0].Rows[0]["PBP_Type"] != null && ds.Tables[0].Rows[0]["PBP_Type"].ToString() != "")
                {
                    model.PBP_Type = int.Parse(ds.Tables[0].Rows[0]["PBP_Type"].ToString());
                }
                
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public string GetProductsName(string PBP_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from PB_Basic_ProductsClass ");
            strSql.Append(" where PBP_ID=@PBP_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBP_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = PBP_ID;

            KNet.Model.PB_Basic_ProductsClass model = new KNet.Model.PB_Basic_ProductsClass();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PBP_Name"] != null && ds.Tables[0].Rows[0]["PBP_Name"].ToString() != "")
                {
                    model.PBP_Name = ds.Tables[0].Rows[0]["PBP_Name"].ToString();
                }
                else
                {
                    model.PBP_Name = "";
                }

                return model.PBP_Name;
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public string GetSonID(string PBP_ID, int i_Type)
        {
            string s_ID = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   * from PB_Basic_ProductsClass ");
            strSql.Append(" where PBP_FaterID=@PBP_FaterID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBP_FaterID", SqlDbType.VarChar,50)};
            parameters[0].Value = PBP_ID;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    if (ds.Tables[0].Rows[i]["PBP_ID"] != null && ds.Tables[0].Rows[i]["PBP_ID"].ToString() != "")
                    {
                        if (i_Type == 0)
                        {
                            s_ID += "H" + ds.Tables[0].Rows[i]["PBP_ID"].ToString() + ",";
                        }
                        else if (i_Type == 2)
                        {
                            s_ID +=  ds.Tables[0].Rows[i]["PBP_ID"].ToString() + ",";
                        }
                        else
                        {
                            s_ID += "img_H" + ds.Tables[0].Rows[i]["PBP_ID"].ToString() + ",";
                        }
                    }
                    else
                    {
                        s_ID += "";
                    }
                }
                s_ID = s_ID.Substring(0, s_ID.Length - 1);

                return s_ID;
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public string GetSonIDs(string PBP_ID)
        {
            string s_ID = PBP_ID + ",";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   * from PB_Basic_ProductsClass ");
            strSql.Append(" where PBP_FaterID=@PBP_FaterID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBP_FaterID", SqlDbType.VarChar,50)};
            parameters[0].Value = PBP_ID;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    if (ds.Tables[0].Rows[i]["PBP_ID"] != null && ds.Tables[0].Rows[i]["PBP_ID"].ToString() != "")
                    {
                          //s_ID += ds.Tables[0].Rows[i]["PBP_ID"].ToString() + ",";
                          s_ID += GetSonIDs(ds.Tables[0].Rows[i]["PBP_ID"].ToString())+",";
                    }
                    else
                    {
                        s_ID += "";
                    }
                }
                s_ID = s_ID.Substring(0, s_ID.Length - 1);

                return s_ID;
            }
            else
            {
                return PBP_ID;
            }
        }

        public string GetSonIDss(string PBP_ID)
        {
            string s_ID = PBP_ID + ",";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   * from PB_Basic_ProductsClass ");
            strSql.Append(" where PBP_FaterID in('" + PBP_ID.Replace(",", "','") + "') ");
       
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    if (ds.Tables[0].Rows[i]["PBP_ID"] != null && ds.Tables[0].Rows[i]["PBP_ID"].ToString() != "")
                    {
                        //s_ID += ds.Tables[0].Rows[i]["PBP_ID"].ToString() + ",";
                        s_ID += GetSonIDs(ds.Tables[0].Rows[i]["PBP_ID"].ToString()) + ",";
                    }
                    else
                    {
                        s_ID += "";
                    }
                }
                s_ID = s_ID.Substring(0, s_ID.Length - 1);

                return s_ID;
            }
            else
            {
                return PBP_ID;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public string GetMaxCode(string PBP_ID)
        {

            StringBuilder strSql = new StringBuilder();
            KNet.Model.PB_Basic_ProductsClass model = new KNet.Model.PB_Basic_ProductsClass();
            strSql.Append("select  Max(cast('1'+PBP_Code as int)) as PBP_Code  from PB_Basic_ProductsClass ");
            strSql.Append(" where PBP_ID=@PBP_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBP_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = PBP_ID;

            string s_ParentCode = "",s_MaxCode="";
            DataSet ds1 = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                if (ds1.Tables[0].Rows[0]["PBP_Code"] != null && ds1.Tables[0].Rows[0]["PBP_Code"].ToString() != "")
                {
                    s_ParentCode = ds1.Tables[0].Rows[0]["PBP_Code"].ToString();
                }
            }
            strSql.Clear();
            strSql.Append("select  Max(cast('1'+PBP_Code as int)) PBP_Code  from PB_Basic_ProductsClass ");
            strSql.Append(" where PBP_FaterID=@PBP_FaterID ");
            SqlParameter[] parameters1 = {
					new SqlParameter("@PBP_FaterID", SqlDbType.VarChar,50)};
            parameters1[0].Value = PBP_ID;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PBP_Code"] != null && ds.Tables[0].Rows[0]["PBP_Code"].ToString() != "")
                {
                    s_MaxCode = Convert.ToString(int.Parse(ds.Tables[0].Rows[0]["PBP_Code"].ToString())+1);
                }
                else
                {
                    s_MaxCode = s_ParentCode+"01";
                }

                return s_MaxCode.Substring(1, s_MaxCode.Length-1);
            }
            else
            {
                return "01";
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public string GetMaxOrder(string PBP_ID)
        {
            string s_MaxCode = "";
            StringBuilder strSql = new StringBuilder();
            KNet.Model.PB_Basic_ProductsClass model = new KNet.Model.PB_Basic_ProductsClass();
            strSql.Append("select  Max(cast(PBP_Order as int)) PBP_Code  from PB_Basic_ProductsClass ");
            strSql.Append(" where PBP_FaterID=@PBP_FaterID ");
            SqlParameter[] parameters1 = {
					new SqlParameter("@PBP_FaterID", SqlDbType.VarChar,50)};
            parameters1[0].Value = PBP_ID;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PBP_Code"] != null && ds.Tables[0].Rows[0]["PBP_Code"].ToString() != "")
                {
                    s_MaxCode = Convert.ToString(int.Parse(ds.Tables[0].Rows[0]["PBP_Code"].ToString()) + 1);
                }
                else
                {
                    s_MaxCode = "0";
                }

                return s_MaxCode;
            }
            else
            {
                return "0";
            }
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PBP_ID,PBP_Code,PBP_Name,PBP_FaterID,PBP_Order,PBP_Creator,PBP_CTime,PBP_MTime,PBP_Mender ");
            strSql.Append(" FROM PB_Basic_ProductsClass ");
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
            strSql.Append(" PBP_ID,PBP_Code,PBP_Name,PBP_FaterID,PBP_Order,PBP_Creator,PBP_CTime,PBP_MTime,PBP_Mender ");
            strSql.Append(" FROM PB_Basic_ProductsClass ");
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
            parameters[0].Value = "PB_Basic_ProductsClass";
            parameters[1].Value = "PBP_ID";
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

