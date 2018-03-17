using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;

namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类KNet_WareHouse_DirectInto。
    /// </summary>
    public class KNet_WareHouse_DirectInto
    {
        public KNet_WareHouse_DirectInto()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string DirectInNo)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@DirectInNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = DirectInNo;

            int result = DbHelperSQL.RunProcedure("Proc_KNet_WareHouse_DirectInto_Exists", parameters, out rowsAffected);
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
        public void Add(KNet.Model.KNet_WareHouse_DirectInto model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KNet_WareHouse_DirectInto(");
            strSql.Append("DirectInNo,DirectInTopic,DirectInSource,DirectInDateTime,SuppNo,HouseNo,DirectInStaffBranch,DirectInStaffDepart,DirectInStaffNo,DirectInCheckStaffNo,DirectInRemarks,KWD_Type,KWD_ReturnNo,DirectInCheckYN,KWD_KDNameCode,KWD_KDName,KWD_KDCode,KWD_KDState,KWD_PersonName,KWD_Telphone,KWD_Phone,KWD_Address)");
            strSql.Append(" values (");
            strSql.Append("@DirectInNo,@DirectInTopic,@DirectInSource,@DirectInDateTime,@SuppNo,@HouseNo,@DirectInStaffBranch,@DirectInStaffDepart,@DirectInStaffNo,@DirectInCheckStaffNo,@DirectInRemarks,@KWD_Type,@KWD_ReturnNo,@DirectInCheckYN,@KWD_KDNameCode,@KWD_KDName,@KWD_KDCode,@KWD_KDState,@KWD_PersonName,@KWD_Telphone,@KWD_Phone,@KWD_Address)");
            SqlParameter[] parameters = {
					new SqlParameter("@DirectInNo", SqlDbType.NVarChar,50),
					new SqlParameter("@DirectInTopic", SqlDbType.NVarChar,50),
					new SqlParameter("@DirectInSource", SqlDbType.NVarChar,50),
					new SqlParameter("@DirectInDateTime", SqlDbType.DateTime),
					new SqlParameter("@SuppNo", SqlDbType.NVarChar,50),
					new SqlParameter("@HouseNo", SqlDbType.NVarChar,50),
					new SqlParameter("@DirectInStaffBranch", SqlDbType.NVarChar,50),
					new SqlParameter("@DirectInStaffDepart", SqlDbType.NVarChar,50),
					new SqlParameter("@DirectInStaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@DirectInCheckStaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@DirectInRemarks", SqlDbType.NVarChar,1000),
					new SqlParameter("@KWD_Type", SqlDbType.VarChar,50),
					new SqlParameter("@KWD_ReturnNo", SqlDbType.VarChar,50),
					new SqlParameter("@DirectInCheckYN", SqlDbType.Bit),
 new SqlParameter("@KWD_KDNameCode", SqlDbType.VarChar,50),
 new SqlParameter("@KWD_KDName", SqlDbType.VarChar,50),
 new SqlParameter("@KWD_KDCode", SqlDbType.VarChar,50),
 new SqlParameter("@KWD_KDState", SqlDbType.VarChar,50),
 new SqlParameter("@KWD_PersonName", SqlDbType.VarChar,50),
 new SqlParameter("@KWD_Telphone", SqlDbType.VarChar,50),
 new SqlParameter("@KWD_Phone", SqlDbType.VarChar,50),
 new SqlParameter("@KWD_Address", SqlDbType.VarChar,500)};
            parameters[0].Value = model.DirectInNo;
            parameters[1].Value = model.DirectInTopic;
            parameters[2].Value = model.DirectInSource;
            parameters[3].Value = model.DirectInDateTime;
            parameters[4].Value = model.SuppNo;
            parameters[5].Value = model.HouseNo;
            parameters[6].Value = model.DirectInStaffBranch;
            parameters[7].Value = model.DirectInStaffDepart;
            parameters[8].Value = model.DirectInStaffNo;
            parameters[9].Value = model.DirectInCheckStaffNo;
            parameters[10].Value = model.DirectInRemarks;
            parameters[11].Value = model.KWD_Type;
            parameters[12].Value = model.KWD_ReturnNo;
            parameters[13].Value = model.DirectInCheckYN;
            parameters[14].Value = model.KWD_KDNameCode;
            parameters[15].Value = model.KWD_KDName;
            parameters[16].Value = model.KWD_KDCode;
            parameters[17].Value = model.KWD_KDState;
            parameters[18].Value = model.KWD_PersonName;
            parameters[19].Value = model.KWD_Telphone;
            parameters[20].Value = model.KWD_Phone;
            parameters[21].Value = model.KWD_Address;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 修改
        /// </summary>
        public void Update(KNet.Model.KNet_WareHouse_DirectInto model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update KNet_WareHouse_DirectInto set ");
            strSql.Append("DirectInTopic=@DirectInTopic,");
            strSql.Append("DirectInSource=@DirectInSource,");
            strSql.Append("DirectInDateTime=@DirectInDateTime,");
            strSql.Append("SuppNo=@SuppNo,");
            strSql.Append("HouseNo=@HouseNo,");
            strSql.Append("DirectInStaffBranch=@DirectInStaffBranch,");
            strSql.Append("DirectInStaffDepart=@DirectInStaffDepart,");
            strSql.Append("DirectInStaffNo=@DirectInStaffNo,");
            strSql.Append("DirectInRemarks=@DirectInRemarks,");
            strSql.Append("KWD_KDNameCode=@KWD_KDNameCode,");
            strSql.Append("KWD_KDName=@KWD_KDName,");
            strSql.Append("KWD_KDCode=@KWD_KDCode,");
            strSql.Append("KWD_KDState=@KWD_KDState,");
            strSql.Append("KWD_PersonName=@KWD_PersonName,");
            strSql.Append("KWD_Telphone=@KWD_Telphone,");
            strSql.Append("KWD_Phone=@KWD_Phone,");
            strSql.Append("KWD_Address=@KWD_Address ");
            strSql.Append(" where DirectInNo=@DirectInNo ");
            SqlParameter[] parameters = {
 new SqlParameter("@DirectInTopic", SqlDbType.VarChar,100),
 new SqlParameter("@DirectInSource", SqlDbType.VarChar,100),
 new SqlParameter("@DirectInDateTime", SqlDbType.DateTime,8),
 new SqlParameter("@SuppNo", SqlDbType.VarChar,100),
 new SqlParameter("@HouseNo", SqlDbType.VarChar,100),
 new SqlParameter("@DirectInStaffBranch", SqlDbType.VarChar,100),
 new SqlParameter("@DirectInStaffDepart", SqlDbType.VarChar,100),
 new SqlParameter("@DirectInStaffNo", SqlDbType.VarChar,100),
 new SqlParameter("@DirectInRemarks", SqlDbType.VarChar,2000),
  new SqlParameter("@KWD_KDNameCode", SqlDbType.VarChar,50),
 new SqlParameter("@KWD_KDName", SqlDbType.VarChar,50),
 new SqlParameter("@KWD_KDCode", SqlDbType.VarChar,50),
 new SqlParameter("@KWD_KDState", SqlDbType.VarChar,50),
 new SqlParameter("@KWD_PersonName", SqlDbType.VarChar,50),
 new SqlParameter("@KWD_Telphone", SqlDbType.VarChar,50),
 new SqlParameter("@KWD_Phone", SqlDbType.VarChar,50),
 new SqlParameter("@KWD_Address", SqlDbType.VarChar,500),
new SqlParameter("@DirectInNo", SqlDbType.VarChar,100)};
            parameters[0].Value = model.DirectInTopic;
            parameters[1].Value = model.DirectInSource;
            parameters[2].Value = model.DirectInDateTime;
            parameters[3].Value = model.SuppNo;
            parameters[4].Value = model.HouseNo;
            parameters[5].Value = model.DirectInStaffBranch;
            parameters[6].Value = model.DirectInStaffDepart;
            parameters[7].Value = model.DirectInStaffNo;
            parameters[8].Value = model.DirectInRemarks;
            parameters[9].Value = model.KWD_KDNameCode;
            parameters[10].Value = model.KWD_KDName;
            parameters[11].Value = model.KWD_KDCode;
            parameters[12].Value = model.KWD_KDState;
            parameters[13].Value = model.KWD_PersonName;
            parameters[14].Value = model.KWD_Telphone;
            parameters[15].Value = model.KWD_Phone;
            parameters[16].Value = model.KWD_Address;
            parameters[17].Value = model.DirectInNo;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string DirectInNo)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@DirectInNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = DirectInNo;

            DbHelperSQL.RunProcedure("Proc_KNet_WareHouse_DirectInto_Delete", parameters, out rowsAffected);
        }

        /// <summary>
        /// 得到数据
        /// </summary>
        public KNet.Model.KNet_WareHouse_DirectInto GetModel(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from KNet_WareHouse_DirectInto  ");
            strSql.Append("where ID=@ID  ");
            SqlParameter[] parameters = {
 new SqlParameter("@ID", SqlDbType.VarChar,100)
};
            parameters[0].Value = ID;
            KNet.Model.KNet_WareHouse_DirectInto model = new KNet.Model.KNet_WareHouse_DirectInto();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_WareHouse_DirectInto DataRowToModel(DataRow row)
        {
            KNet.Model.KNet_WareHouse_DirectInto model = new KNet.Model.KNet_WareHouse_DirectInto();
            if (row != null)
            {
                if (row["ID"] != null)
                {
                    model.ID = row["ID"].ToString();
                }
                else
                {
                    model.ID = "";
                }
                if (row["DirectInNo"] != null)
                {
                    model.DirectInNo = row["DirectInNo"].ToString();
                }
                else
                {
                    model.DirectInNo = "";
                }
                if (row["DirectInTopic"] != null)
                {
                    model.DirectInTopic = row["DirectInTopic"].ToString();
                }
                else
                {
                    model.DirectInTopic = "";
                }
                if (row["DirectInSource"] != null)
                {
                    model.DirectInSource = row["DirectInSource"].ToString();
                }
                else
                {
                    model.DirectInSource = "";
                }
                if (row["DirectInDateTime"] != null)
                {
                    model.DirectInDateTime = DateTime.Parse(row["DirectInDateTime"].ToString());
                }
                if (row["SuppNo"] != null)
                {
                    model.SuppNo = row["SuppNo"].ToString();
                }
                else
                {
                    model.SuppNo = "";
                }
                if (row["HouseNo"] != null)
                {
                    model.HouseNo = row["HouseNo"].ToString();
                }
                else
                {
                    model.HouseNo = "";
                }
                if (row["DirectInStaffBranch"] != null)
                {
                    model.DirectInStaffBranch = row["DirectInStaffBranch"].ToString();
                }
                else
                {
                    model.DirectInStaffBranch = "";
                }
                if (row["DirectInStaffDepart"] != null)
                {
                    model.DirectInStaffDepart = row["DirectInStaffDepart"].ToString();
                }
                else
                {
                    model.DirectInStaffDepart = "";
                }
                if (row["DirectInStaffNo"] != null)
                {
                    model.DirectInStaffNo = row["DirectInStaffNo"].ToString();
                }
                else
                {
                    model.DirectInStaffNo = "";
                }
                if (row["DirectInCheckStaffNo"] != null)
                {
                    model.DirectInCheckStaffNo = row["DirectInCheckStaffNo"].ToString();
                }
                else
                {
                    model.DirectInCheckStaffNo = "";
                }
                if (row["DirectInRemarks"] != null)
                {
                    model.DirectInRemarks = row["DirectInRemarks"].ToString();
                }
                else
                {
                    model.DirectInRemarks = "";
                }
                if (row["DirectInCheckYN"] != null)
                {
                    model.DirectInCheckYN = int.Parse(row["DirectInCheckYN"].ToString());
                }
                else
                {
                    model.DirectInCheckYN = 0;
                }
                if (row["KWD_Type"] != null)
                {
                    model.KWD_Type = row["KWD_Type"].ToString();
                }
                else
                {
                    model.KWD_Type = "";
                }
                if (row["KWD_ReturnNo"] != null)
                {
                    model.KWD_ReturnNo = row["KWD_ReturnNo"].ToString();
                }
                else
                {
                    model.KWD_ReturnNo = "";
                }
                if (row["KWD_BPrintNums"] != null)
                {
                    model.KWD_BPrintNums = int.Parse(row["KWD_BPrintNums"].ToString());
                }
                else
                {
                    model.KWD_BPrintNums = 0;
                }
                if (row["KWD_KDNameCode"] != null)
                {
                    model.KWD_KDNameCode = row["KWD_KDNameCode"].ToString();
                }
                else
                {
                    model.KWD_KDNameCode = "";
                }
                if (row["KWD_KDName"] != null)
                {

                    model.KWD_KDName = row["KWD_KDName"].ToString();
                    if (model.KWD_KDName == "请选择快递")
                    {
                        model.KWD_KDName = "";
                    }
                }
                else
                {
                    model.KWD_KDName = "";
                }
                if (row["KWD_KDCode"] != null)
                {
                    model.KWD_KDCode = row["KWD_KDCode"].ToString();
                }
                else
                {
                    model.KWD_KDCode = "";
                }
                if (row["KWD_KDState"] != null)
                {
                    model.KWD_KDState = row["KWD_KDState"].ToString();
                }
                else
                {
                    model.KWD_KDState = "";
                }
                if (row["KWD_PersonName"] != null)
                {
                    model.KWD_PersonName = row["KWD_PersonName"].ToString();
                }
                else
                {
                    model.KWD_PersonName = "";
                }
                if (row["KWD_Telphone"] != null)
                {
                    model.KWD_Telphone = row["KWD_Telphone"].ToString();
                }
                else
                {
                    model.KWD_Telphone = "";
                }
                if (row["KWD_Phone"] != null)
                {
                    model.KWD_Phone = row["KWD_Phone"].ToString();
                }
                else
                {
                    model.KWD_Phone = "";
                }
                if (row["KWD_Address"] != null)
                {
                    model.KWD_Address = row["KWD_Address"].ToString();
                }
                else
                {
                    model.KWD_Address = "";
                }
            }
            return model;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_WareHouse_DirectInto GetModelB(string DirectInNo)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from KNet_WareHouse_DirectInto  ");
            strSql.Append("where DirectInNo=@DirectInNo  ");
            SqlParameter[] parameters = {
 new SqlParameter("@DirectInNo", SqlDbType.VarChar,100)
};
            parameters[0].Value = DirectInNo;
            KNet.Model.KNet_WareHouse_DirectInto model = new KNet.Model.KNet_WareHouse_DirectInto();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
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
            strSql.Append(" FROM KNet_WareHouse_DirectInto ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }



        #endregion  成员方法
    }
}

