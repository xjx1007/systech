using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;

namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类KNet_WareHouse_AllocateList。
    /// </summary>
    public class KNet_WareHouse_AllocateList
    {
        public KNet_WareHouse_AllocateList()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string AllocateNo)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@AllocateNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = AllocateNo;

            int result = DbHelperSQL.RunProcedure("Proc_KNet_WareHouse_AllocateList_Exists", parameters, out rowsAffected);
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
        public void Add(KNet.Model.KNet_WareHouse_AllocateList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KNet_WareHouse_AllocateList(");
            strSql.Append("AllocateNo,AllocateTopic,AllocateCause,AllocateDateTime,HouseNo,HouseNo_int,AllocateStaffBranch,AllocateStaffDepart,AllocateStaffNo,AllocateRemarks,AllocateCheckYN,KWA_OrderNo,KWA_Type,KWA_DBType)");
            strSql.Append(" values (");
            strSql.Append("@AllocateNo,@AllocateTopic,@AllocateCause,@AllocateDateTime,@HouseNo,@HouseNo_int,@AllocateStaffBranch,@AllocateStaffDepart,@AllocateStaffNo,@AllocateRemarks,@AllocateCheckYN,@KWA_OrderNo,@KWA_Type,@KWA_DBType)");
            SqlParameter[] parameters = {
					new SqlParameter("@AllocateNo", SqlDbType.NVarChar,50),
					new SqlParameter("@AllocateTopic", SqlDbType.NVarChar,50),
					new SqlParameter("@AllocateCause", SqlDbType.NVarChar,50),
					new SqlParameter("@AllocateDateTime", SqlDbType.DateTime),
					new SqlParameter("@HouseNo", SqlDbType.NVarChar,50),
					new SqlParameter("@HouseNo_int", SqlDbType.NVarChar,50),
					new SqlParameter("@AllocateStaffBranch", SqlDbType.NVarChar,50),
					new SqlParameter("@AllocateStaffDepart", SqlDbType.NVarChar,50),
					new SqlParameter("@AllocateStaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@AllocateRemarks", SqlDbType.NVarChar,1000),
					new SqlParameter("@AllocateCheckYN", SqlDbType.Bit,1),
					new SqlParameter("@KWA_OrderNo", SqlDbType.NVarChar,50),
					new SqlParameter("@KWA_Type", SqlDbType.NVarChar,50),
					new SqlParameter("@KWA_DBType", SqlDbType.Int,4)
                    
                                        };
            parameters[0].Value = model.AllocateNo;
            parameters[1].Value = model.AllocateTopic;
            parameters[2].Value = model.AllocateCause;
            parameters[3].Value = model.AllocateDateTime;
            parameters[4].Value = model.HouseNo;
            parameters[5].Value = model.HouseNo_int;
            parameters[6].Value = model.AllocateStaffBranch;
            parameters[7].Value = model.AllocateStaffDepart;
            parameters[8].Value = model.AllocateStaffNo;
            parameters[9].Value = model.AllocateRemarks;
            parameters[10].Value = model.AllocateCheckYN;
            parameters[11].Value = model.KWA_OrderNo;
            parameters[12].Value = model.KWA_Type;
            parameters[13].Value = model.KWA_DBType;
            
            
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public void Update(KNet.Model.KNet_WareHouse_AllocateList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KNet_WareHouse_AllocateList set ");
            strSql.Append("AllocateTopic=@AllocateTopic,");
            strSql.Append("AllocateCause=@AllocateCause,");
            strSql.Append("AllocateDateTime=@AllocateDateTime,");
            strSql.Append("HouseNo=@HouseNo,");
            strSql.Append("HouseNo_int=@HouseNo_int,");
            strSql.Append("AllocateRemarks=@AllocateRemarks,");
            strSql.Append("KWA_OrderNo=@KWA_OrderNo, ");
            strSql.Append("KWA_Type=@KWA_Type, ");
            strSql.Append("KWA_DBType=@KWA_DBType ");
            
            
            strSql.Append(" where AllocateNo=@AllocateNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@AllocateTopic", SqlDbType.NVarChar,50),
					new SqlParameter("@AllocateCause", SqlDbType.NVarChar,50),
					new SqlParameter("@AllocateDateTime", SqlDbType.DateTime),
					new SqlParameter("@HouseNo", SqlDbType.NVarChar,50),
					new SqlParameter("@HouseNo_int", SqlDbType.NVarChar,50),
					new SqlParameter("@AllocateRemarks", SqlDbType.NVarChar,1000),
					new SqlParameter("@KWA_OrderNo", SqlDbType.NVarChar,50),
					new SqlParameter("@KWA_Type", SqlDbType.NVarChar,50),
					new SqlParameter("@KWA_DBType", SqlDbType.Int,4),
                    
                    
					new SqlParameter("@AllocateNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.AllocateTopic;
            parameters[1].Value = model.AllocateCause;
            parameters[2].Value = model.AllocateDateTime;
            parameters[3].Value = model.HouseNo;
            parameters[4].Value = model.HouseNo_int;
            parameters[5].Value = model.AllocateRemarks;
            parameters[6].Value = model.KWA_OrderNo;
            parameters[7].Value = model.KWA_Type;
            parameters[8].Value = model.KWA_DBType;
            
            parameters[9].Value = model.AllocateNo;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string AllocateNo)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@AllocateNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = AllocateNo;

            DbHelperSQL.RunProcedure("Proc_KNet_WareHouse_AllocateList_Delete", parameters, out rowsAffected);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_WareHouse_AllocateList GetModel(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from KNet_WareHouse_AllocateList ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            KNet.Model.KNet_WareHouse_AllocateList model = new KNet.Model.KNet_WareHouse_AllocateList();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AllocateNo"] != null && ds.Tables[0].Rows[0]["AllocateNo"].ToString() != "")
                {
                    model.AllocateNo = ds.Tables[0].Rows[0]["AllocateNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AllocateTopic"] != null && ds.Tables[0].Rows[0]["AllocateTopic"].ToString() != "")
                {
                    model.AllocateTopic = ds.Tables[0].Rows[0]["AllocateTopic"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AllocateCause"] != null && ds.Tables[0].Rows[0]["AllocateCause"].ToString() != "")
                {
                    model.AllocateCause = ds.Tables[0].Rows[0]["AllocateCause"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AllocateDateTime"] != null && ds.Tables[0].Rows[0]["AllocateDateTime"].ToString() != "")
                {
                    model.AllocateDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["AllocateDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["HouseNo"] != null && ds.Tables[0].Rows[0]["HouseNo"].ToString() != "")
                {
                    model.HouseNo = ds.Tables[0].Rows[0]["HouseNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["HouseNo_int"] != null && ds.Tables[0].Rows[0]["HouseNo_int"].ToString() != "")
                {
                    model.HouseNo_int = ds.Tables[0].Rows[0]["HouseNo_int"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AllocateStaffBranch"] != null && ds.Tables[0].Rows[0]["AllocateStaffBranch"].ToString() != "")
                {
                    model.AllocateStaffBranch = ds.Tables[0].Rows[0]["AllocateStaffBranch"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AllocateStaffDepart"] != null && ds.Tables[0].Rows[0]["AllocateStaffDepart"].ToString() != "")
                {
                    model.AllocateStaffDepart = ds.Tables[0].Rows[0]["AllocateStaffDepart"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AllocateStaffNo"] != null && ds.Tables[0].Rows[0]["AllocateStaffNo"].ToString() != "")
                {
                    model.AllocateStaffNo = ds.Tables[0].Rows[0]["AllocateStaffNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AllocateCheckStaffNo"] != null && ds.Tables[0].Rows[0]["AllocateCheckStaffNo"].ToString() != "")
                {
                    model.AllocateCheckStaffNo = ds.Tables[0].Rows[0]["AllocateCheckStaffNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AllocateRemarks"] != null && ds.Tables[0].Rows[0]["AllocateRemarks"].ToString() != "")
                {
                    model.AllocateRemarks = ds.Tables[0].Rows[0]["AllocateRemarks"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AllocateCheckYN"] != null && ds.Tables[0].Rows[0]["AllocateCheckYN"].ToString() != "")
                {
                    model.AllocateCheckYN = int.Parse(ds.Tables[0].Rows[0]["AllocateCheckYN"].ToString());
                }

                if (ds.Tables[0].Rows[0]["KWA_OrderNo"] != null && ds.Tables[0].Rows[0]["KWA_OrderNo"].ToString() != "")
                {
                    model.KWA_OrderNo = ds.Tables[0].Rows[0]["KWA_OrderNo"].ToString();
                }

                if (ds.Tables[0].Rows[0]["KWA_Type"] != null && ds.Tables[0].Rows[0]["KWA_Type"].ToString() != "")
                {
                    model.KWA_Type = ds.Tables[0].Rows[0]["KWA_Type"].ToString();
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
        public KNet.Model.KNet_WareHouse_AllocateList GetModelB(string AllocateNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from KNet_WareHouse_AllocateList ");
            strSql.Append(" where AllocateNo=@AllocateNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@AllocateNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = AllocateNo;

            KNet.Model.KNet_WareHouse_AllocateList model = new KNet.Model.KNet_WareHouse_AllocateList();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["AllocateNo"] != null && ds.Tables[0].Rows[0]["AllocateNo"].ToString() != "")
                {
                    model.AllocateNo = ds.Tables[0].Rows[0]["AllocateNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AllocateTopic"] != null && ds.Tables[0].Rows[0]["AllocateTopic"].ToString() != "")
                {
                    model.AllocateTopic = ds.Tables[0].Rows[0]["AllocateTopic"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AllocateCause"] != null && ds.Tables[0].Rows[0]["AllocateCause"].ToString() != "")
                {
                    model.AllocateCause = ds.Tables[0].Rows[0]["AllocateCause"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AllocateDateTime"] != null && ds.Tables[0].Rows[0]["AllocateDateTime"].ToString() != "")
                {
                    model.AllocateDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["AllocateDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["HouseNo"] != null && ds.Tables[0].Rows[0]["HouseNo"].ToString() != "")
                {
                    model.HouseNo = ds.Tables[0].Rows[0]["HouseNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["HouseNo_int"] != null && ds.Tables[0].Rows[0]["HouseNo_int"].ToString() != "")
                {
                    model.HouseNo_int = ds.Tables[0].Rows[0]["HouseNo_int"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AllocateStaffBranch"] != null && ds.Tables[0].Rows[0]["AllocateStaffBranch"].ToString() != "")
                {
                    model.AllocateStaffBranch = ds.Tables[0].Rows[0]["AllocateStaffBranch"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AllocateStaffDepart"] != null && ds.Tables[0].Rows[0]["AllocateStaffDepart"].ToString() != "")
                {
                    model.AllocateStaffDepart = ds.Tables[0].Rows[0]["AllocateStaffDepart"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AllocateStaffNo"] != null && ds.Tables[0].Rows[0]["AllocateStaffNo"].ToString() != "")
                {
                    model.AllocateStaffNo = ds.Tables[0].Rows[0]["AllocateStaffNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AllocateCheckStaffNo"] != null && ds.Tables[0].Rows[0]["AllocateCheckStaffNo"].ToString() != "")
                {
                    model.AllocateCheckStaffNo = ds.Tables[0].Rows[0]["AllocateCheckStaffNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AllocateRemarks"] != null && ds.Tables[0].Rows[0]["AllocateRemarks"].ToString() != "")
                {
                    model.AllocateRemarks = ds.Tables[0].Rows[0]["AllocateRemarks"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AllocateCheckYN"] != null && ds.Tables[0].Rows[0]["AllocateCheckYN"].ToString() != "")
                {
                    model.AllocateCheckYN = int.Parse(ds.Tables[0].Rows[0]["AllocateCheckYN"].ToString());
                }

                if (ds.Tables[0].Rows[0]["KWA_OrderNo"] != null && ds.Tables[0].Rows[0]["KWA_OrderNo"].ToString() != "")
                {
                    model.KWA_OrderNo = ds.Tables[0].Rows[0]["KWA_OrderNo"].ToString();
                }

                if (ds.Tables[0].Rows[0]["KWA_Type"] != null && ds.Tables[0].Rows[0]["KWA_Type"].ToString() != "")
                {
                    model.KWA_Type = ds.Tables[0].Rows[0]["KWA_Type"].ToString();
                }

                if (ds.Tables[0].Rows[0]["KWA_DBType"] != null && ds.Tables[0].Rows[0]["KWA_DBType"].ToString() != "")
                {
                    model.KWA_DBType = int.Parse(ds.Tables[0].Rows[0]["KWA_DBType"].ToString());
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
            strSql.Append(" FROM KNet_WareHouse_AllocateList ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetDetailsList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select b.ID,CASE WHEN a.HouseNo_int = '128502353068906250' THEN '130088401935635079' ELSE c.suppNo END as HouseNo_int,CASE WHEN a.HouseNo = '128502353068906250' THEN '130088401935635079' ELSE d.suppNo END as HouseNo1,b.ProductsBarCode,allocateAmount,allocateunitPrice,allocateTotalNet,a.SystemDateTimes,AllocateStaffNo,a.AllocateNo,a.AllocateDateTime,Allocate_WwPrice,Allocate_WwMoney,AllocateCheckYN ");
            strSql.Append(" FROM KNet_WareHouse_AllocateList a join KNet_WareHouse_AllocateList_Details b on a.AllocateNo=b.AllocateNo  join dbo.KNet_Sys_WareHouse AS c ON c.HouseNo = a.HouseNo_int  join dbo.KNet_Sys_WareHouse AS d ON d.HouseNo = a.HouseNo join KNET_sys_Products e on e.ProductsBarCode=b.ProductsBarCode ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  成员方法
    }
}

