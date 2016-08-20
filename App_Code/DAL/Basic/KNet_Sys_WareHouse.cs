using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类KNet_Sys_WareHouse。
    /// </summary>
    public class KNet_Sys_WareHouse
    {
        public KNet_Sys_WareHouse()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string HouseName)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@HouseName", SqlDbType.NVarChar,50)};
            parameters[0].Value = HouseName;

            int result = DbHelperSQL.RunProcedure("Proc_KNet_Sys_WareHouse_Exists", parameters, out rowsAffected);
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
        /// 是否存在该仓库唯一值
        /// </summary>
        public bool ExistsForHouseNo(string HouseNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from KNet_Sys_WareHouse");
            strSql.Append(" where HouseNo='" + HouseNo + "' ");
            return DbHelperSQL.Exists(strSql.ToString());
        }
        /// <summary>
        ///  增加一条数据
        /// </summary>
        public void Add(KNet.Model.KNet_Sys_WareHouse model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KNet_Sys_WareHouse(");
            strSql.Append("HouseNo,HouseName,HouseTel,HouseMan,HouseAddress,HouseRemark,HouseDate,HouseYN,SuppNo,KSW_Type)");
            strSql.Append(" values (");
            strSql.Append("@HouseNo,@HouseName,@HouseTel,@HouseMan,@HouseAddress,@HouseRemark,@HouseDate,@HouseYN,@SuppNo,@KSW_Type)");
            SqlParameter[] parameters = {
					new SqlParameter("@HouseNo", SqlDbType.NVarChar,50),
					new SqlParameter("@HouseName", SqlDbType.NVarChar,60),
					new SqlParameter("@HouseTel", SqlDbType.NVarChar,30),
					new SqlParameter("@HouseMan", SqlDbType.NVarChar,50),
					new SqlParameter("@HouseAddress", SqlDbType.NVarChar,100),
					new SqlParameter("@HouseRemark", SqlDbType.NText),
					new SqlParameter("@HouseDate", SqlDbType.DateTime),
					new SqlParameter("@HouseYN", SqlDbType.Bit,1),
					new SqlParameter("@SuppNo", SqlDbType.VarChar,50),
					new SqlParameter("@KSW_Type", SqlDbType.Int)};
            parameters[0].Value = model.HouseNo;
            parameters[1].Value = model.HouseName;
            parameters[2].Value = model.HouseTel;
            parameters[3].Value = model.HouseMan;
            parameters[4].Value = model.HouseAddress;
            parameters[5].Value = model.HouseRemark;
            parameters[6].Value = model.HouseDate;
            parameters[7].Value = model.HouseYN;
            parameters[8].Value = model.SuppNo;
            parameters[9].Value = model.KSW_Type;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public void Update(KNet.Model.KNet_Sys_WareHouse model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KNet_Sys_WareHouse set ");
            strSql.Append("HouseName=@HouseName,");
            strSql.Append("HouseTel=@HouseTel,");
            strSql.Append("HouseMan=@HouseMan,");
            strSql.Append("HouseAddress=@HouseAddress,");
            strSql.Append("HouseRemark=@HouseRemark,");
            strSql.Append("HouseDate=@HouseDate,");
            strSql.Append("HouseYN=@HouseYN,");
            strSql.Append("SuppNo=@SuppNo,");
            strSql.Append("KSW_Type=@KSW_Type");
            
            strSql.Append(" where HouseNo=@HouseNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@HouseName", SqlDbType.NVarChar,60),
					new SqlParameter("@HouseTel", SqlDbType.NVarChar,30),
					new SqlParameter("@HouseMan", SqlDbType.NVarChar,50),
					new SqlParameter("@HouseAddress", SqlDbType.NVarChar,100),
					new SqlParameter("@HouseRemark", SqlDbType.NText),
					new SqlParameter("@HouseDate", SqlDbType.DateTime),
					new SqlParameter("@HouseYN", SqlDbType.Bit,1),
					new SqlParameter("@SuppNo", SqlDbType.VarChar,50),
					new SqlParameter("@KSW_Type", SqlDbType.Int),
					new SqlParameter("@HouseNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.HouseName;
            parameters[1].Value = model.HouseTel;
            parameters[2].Value = model.HouseMan;
            parameters[3].Value = model.HouseAddress;
            parameters[4].Value = model.HouseRemark;
            parameters[5].Value = model.HouseDate;
            parameters[6].Value = model.HouseYN;
            parameters[7].Value = model.SuppNo;
            parameters[8].Value = model.KSW_Type;
            parameters[9].Value = model.HouseNo;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string HouseNo)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@HouseNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = HouseNo;

            DbHelperSQL.RunProcedure("Proc_KNet_Sys_WareHouse_Delete", parameters, out rowsAffected);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Sys_WareHouse GetModel(string HouseNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from KNet_Sys_WareHouse ");
            strSql.Append(" where HouseNo=@HouseNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@HouseNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = HouseNo;

            KNet.Model.KNet_Sys_WareHouse model = new KNet.Model.KNet_Sys_WareHouse();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["HouseNo"] != null && ds.Tables[0].Rows[0]["HouseNo"].ToString() != "")
                {
                    model.HouseNo = ds.Tables[0].Rows[0]["HouseNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["HouseName"] != null && ds.Tables[0].Rows[0]["HouseName"].ToString() != "")
                {
                    model.HouseName = ds.Tables[0].Rows[0]["HouseName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["HouseTel"] != null && ds.Tables[0].Rows[0]["HouseTel"].ToString() != "")
                {
                    model.HouseTel = ds.Tables[0].Rows[0]["HouseTel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["HouseMan"] != null && ds.Tables[0].Rows[0]["HouseMan"].ToString() != "")
                {
                    model.HouseMan = ds.Tables[0].Rows[0]["HouseMan"].ToString();
                }
                if (ds.Tables[0].Rows[0]["HouseAddress"] != null && ds.Tables[0].Rows[0]["HouseAddress"].ToString() != "")
                {
                    model.HouseAddress = ds.Tables[0].Rows[0]["HouseAddress"].ToString();
                }
                if (ds.Tables[0].Rows[0]["HouseRemark"] != null && ds.Tables[0].Rows[0]["HouseRemark"].ToString() != "")
                {
                    model.HouseRemark = ds.Tables[0].Rows[0]["HouseRemark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["HouseDate"] != null && ds.Tables[0].Rows[0]["HouseDate"].ToString() != "")
                {
                    model.HouseDate = DateTime.Parse(ds.Tables[0].Rows[0]["HouseDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["HouseYN"] != null && ds.Tables[0].Rows[0]["HouseYN"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["HouseYN"].ToString() == "1") || (ds.Tables[0].Rows[0]["HouseYN"].ToString().ToLower() == "true"))
                    {
                        model.HouseYN = true;
                    }
                    else
                    {
                        model.HouseYN = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["SuppNo"] != null && ds.Tables[0].Rows[0]["SuppNo"].ToString() != "")
                {
                    model.SuppNo = ds.Tables[0].Rows[0]["SuppNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSW_Type"] != null && ds.Tables[0].Rows[0]["KSW_Type"].ToString() != "")
                {
                    model.KSW_Type = int.Parse(ds.Tables[0].Rows[0]["KSW_Type"].ToString());
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
        public KNet.Model.KNet_Sys_WareHouse GetModelBySuppNo(string SuppNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from KNet_Sys_WareHouse ");
            strSql.Append(" where SuppNo=@SuppNo order by KSW_Type,HouseName ");
            SqlParameter[] parameters = {
					new SqlParameter("@SuppNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = SuppNo;

            KNet.Model.KNet_Sys_WareHouse model = new KNet.Model.KNet_Sys_WareHouse();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["HouseNo"] != null && ds.Tables[0].Rows[0]["HouseNo"].ToString() != "")
                {
                    model.HouseNo = ds.Tables[0].Rows[0]["HouseNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["HouseName"] != null && ds.Tables[0].Rows[0]["HouseName"].ToString() != "")
                {
                    model.HouseName = ds.Tables[0].Rows[0]["HouseName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["HouseTel"] != null && ds.Tables[0].Rows[0]["HouseTel"].ToString() != "")
                {
                    model.HouseTel = ds.Tables[0].Rows[0]["HouseTel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["HouseMan"] != null && ds.Tables[0].Rows[0]["HouseMan"].ToString() != "")
                {
                    model.HouseMan = ds.Tables[0].Rows[0]["HouseMan"].ToString();
                }
                if (ds.Tables[0].Rows[0]["HouseAddress"] != null && ds.Tables[0].Rows[0]["HouseAddress"].ToString() != "")
                {
                    model.HouseAddress = ds.Tables[0].Rows[0]["HouseAddress"].ToString();
                }
                if (ds.Tables[0].Rows[0]["HouseRemark"] != null && ds.Tables[0].Rows[0]["HouseRemark"].ToString() != "")
                {
                    model.HouseRemark = ds.Tables[0].Rows[0]["HouseRemark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["HouseDate"] != null && ds.Tables[0].Rows[0]["HouseDate"].ToString() != "")
                {
                    model.HouseDate = DateTime.Parse(ds.Tables[0].Rows[0]["HouseDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["HouseYN"] != null && ds.Tables[0].Rows[0]["HouseYN"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["HouseYN"].ToString() == "1") || (ds.Tables[0].Rows[0]["HouseYN"].ToString().ToLower() == "true"))
                    {
                        model.HouseYN = true;
                    }
                    else
                    {
                        model.HouseYN = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["SuppNo"] != null && ds.Tables[0].Rows[0]["SuppNo"].ToString() != "")
                {
                    model.SuppNo = ds.Tables[0].Rows[0]["SuppNo"].ToString();
                }
                return model;
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
            strSql.Append(" FROM KNet_Sys_WareHouse ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by  HouseDate desc ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  成员方法
    }
}

