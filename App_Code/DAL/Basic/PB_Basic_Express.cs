using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:PB_Basic_Express
    /// </summary>
    public partial class PB_Basic_Express
    {
        public PB_Basic_Express()
        { }
        #region  Method


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PBE_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PB_Basic_Express");
            strSql.Append(" where PBE_ID='" + PBE_ID + "' ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(KNet.Model.PB_Basic_Express model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.PBE_ID != null)
            {
                strSql1.Append("PBE_ID,");
                strSql2.Append("'" + model.PBE_ID + "',");
            }
            if (model.PBE_Code != null)
            {
                strSql1.Append("PBE_Code,");
                strSql2.Append("'" + model.PBE_Code + "',");
            }
            if (model.PBE_Stime != null)
            {
                strSql1.Append("PBE_Stime,");
                strSql2.Append("'" + model.PBE_Stime + "',");
            }
            if (model.PBE_DutyPerson != null)
            {
                strSql1.Append("PBE_DutyPerson,");
                strSql2.Append("'" + model.PBE_DutyPerson + "',");
            }
            if (model.PBE_CustomerValue != null)
            {
                strSql1.Append("PBE_CustomerValue,");
                strSql2.Append("'" + model.PBE_CustomerValue + "',");
            }
            if (model.PBE_CustomerName != null)
            {
                strSql1.Append("PBE_CustomerName,");
                strSql2.Append("'" + model.PBE_CustomerName + "',");
            }
            if (model.PBE_LinkMan != null)
            {
                strSql1.Append("PBE_LinkMan,");
                strSql2.Append("'" + model.PBE_LinkMan + "',");
            }
            if (model.PBE_LinkManName != null)
            {
                strSql1.Append("PBE_LinkManName,");
                strSql2.Append("'" + model.PBE_LinkManName + "',");
            }
            if (model.PBE_Shen != null)
            {
                strSql1.Append("PBE_Shen,");
                strSql2.Append("'" + model.PBE_Shen + "',");
            }
            if (model.PBE_Shi != null)
            {
                strSql1.Append("PBE_Shi,");
                strSql2.Append("'" + model.PBE_Shi + "',");
            }
            if (model.PBE_Qu != null)
            {
                strSql1.Append("PBE_Qu,");
                strSql2.Append("'" + model.PBE_Qu + "',");
            }
            if (model.PBE_Jie != null)
            {
                strSql1.Append("PBE_Jie,");
                strSql2.Append("'" + model.PBE_Jie + "',");
            }
            if (model.PBE_Address != null)
            {
                strSql1.Append("PBE_Address,");
                strSql2.Append("'" + model.PBE_Address + "',");
            }
            if (model.PBE_Phone != null)
            {
                strSql1.Append("PBE_Phone,");
                strSql2.Append("'" + model.PBE_Phone + "',");
            }
            if (model.PBE_TelPhone != null)
            {
                strSql1.Append("PBE_TelPhone,");
                strSql2.Append("'" + model.PBE_TelPhone + "',");
            }
            if (model.PBE_ReCustomer != null)
            {
                strSql1.Append("PBE_ReCustomer,");
                strSql2.Append("'" + model.PBE_ReCustomer + "',");
            }
            if (model.PBE_ReCustomerName != null)
            {
                strSql1.Append("PBE_ReCustomerName,");
                strSql2.Append("'" + model.PBE_ReCustomerName + "',");
            }
            if (model.PBE_ReLinkMan != null)
            {
                strSql1.Append("PBE_ReLinkMan,");
                strSql2.Append("'" + model.PBE_ReLinkMan + "',");
            }
            if (model.PBE_ReLinkManName != null)
            {
                strSql1.Append("PBE_ReLinkManName,");
                strSql2.Append("'" + model.PBE_ReLinkManName + "',");
            }
            if (model.PBE_ReShen != null)
            {
                strSql1.Append("PBE_ReShen,");
                strSql2.Append("'" + model.PBE_ReShen + "',");
            }
            if (model.PBE_ReShi != null)
            {
                strSql1.Append("PBE_ReShi,");
                strSql2.Append("'" + model.PBE_ReShi + "',");
            }
            if (model.PBE_ReQu != null)
            {
                strSql1.Append("PBE_ReQu,");
                strSql2.Append("'" + model.PBE_ReQu + "',");
            }
            if (model.PBE_ReJie != null)
            {
                strSql1.Append("PBE_ReJie,");
                strSql2.Append("'" + model.PBE_ReJie + "',");
            }
            if (model.PBE_ReAddress != null)
            {
                strSql1.Append("PBE_ReAddress,");
                strSql2.Append("'" + model.PBE_ReAddress + "',");
            }
            if (model.PBE_RePhone != null)
            {
                strSql1.Append("PBE_RePhone,");
                strSql2.Append("'" + model.PBE_RePhone + "',");
            }
            if (model.PBE_ReTelPhone != null)
            {
                strSql1.Append("PBE_ReTelPhone,");
                strSql2.Append("'" + model.PBE_ReTelPhone + "',");
            }
            if (model.PBE_Use != null)
            {
                strSql1.Append("PBE_Use,");
                strSql2.Append("'" + model.PBE_Use + "',");
            }
            if (model.PBE_KDName != null)
            {
                strSql1.Append("PBE_KDName,");
                strSql2.Append("'" + model.PBE_KDName + "',");
            }
            if (model.PBE_KDCode != null)
            {
                strSql1.Append("PBE_KDCode,");
                strSql2.Append("'" + model.PBE_KDCode + "',");
            }
            if (model.PBE_KDEnglishName != null)
            {
                strSql1.Append("PBE_KDEnglishName,");
                strSql2.Append("'" + model.PBE_KDEnglishName + "',");
            }
            if (model.PBE_State != null)
            {
                strSql1.Append("PBE_State,");
                strSql2.Append("'" + model.PBE_State + "',");
            }
            if (model.PBE_ReceTime != null)
            {
                strSql1.Append("PBE_ReceTime,");
                strSql2.Append("'" + model.PBE_ReceTime + "',");
            }
            if (model.PBE_CTime != null)
            {
                strSql1.Append("PBE_CTime,");
                strSql2.Append("'" + model.PBE_CTime + "',");
            }
            if (model.PBE_Creator != null)
            {
                strSql1.Append("PBE_Creator,");
                strSql2.Append("'" + model.PBE_Creator + "',");
            }
            if (model.PBE_MTime != null)
            {
                strSql1.Append("PBE_MTime,");
                strSql2.Append("'" + model.PBE_MTime + "',");
            }
            if (model.PBE_Mender != null)
            {
                strSql1.Append("PBE_Mender,");
                strSql2.Append("'" + model.PBE_Mender + "',");
            }
            if (model.PBE_Del != null)
            {
                strSql1.Append("PBE_Del,");
                strSql2.Append("" + model.PBE_Del + ",");
            }
            strSql.Append("insert into PB_Basic_Express(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
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
        /// UpDate
        /// </summary>
        public void UpDataSate(KNet.Model.PB_Basic_Express model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PB_Basic_Express set ");
            strSql.Append("PBE_State=@PBE_State ");
            strSql.Append(" where PBE_ID=@PBE_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@PBE_State", SqlDbType.VarChar,50),
					new SqlParameter("@PBE_ID", SqlDbType.VarChar,50)
            };
            parameters[0].Value = model.PBE_State;
            parameters[1].Value = model.PBE_ID;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.PB_Basic_Express model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PB_Basic_Express set ");
            if (model.PBE_Code != null)
            {
                strSql.Append("PBE_Code='" + model.PBE_Code + "',");
            }
            else
            {
                strSql.Append("PBE_Code= null ,");
            }
            if (model.PBE_Stime != null)
            {
                strSql.Append("PBE_Stime='" + model.PBE_Stime + "',");
            }
            else
            {
                strSql.Append("PBE_Stime= null ,");
            }
            if (model.PBE_DutyPerson != null)
            {
                strSql.Append("PBE_DutyPerson='" + model.PBE_DutyPerson + "',");
            }
            else
            {
                strSql.Append("PBE_DutyPerson= null ,");
            }
            if (model.PBE_CustomerValue != null)
            {
                strSql.Append("PBE_CustomerValue='" + model.PBE_CustomerValue + "',");
            }
            else
            {
                strSql.Append("PBE_CustomerValue= null ,");
            }
            if (model.PBE_CustomerName != null)
            {
                strSql.Append("PBE_CustomerName='" + model.PBE_CustomerName + "',");
            }
            else
            {
                strSql.Append("PBE_CustomerName= null ,");
            }
            if (model.PBE_LinkMan != null)
            {
                strSql.Append("PBE_LinkMan='" + model.PBE_LinkMan + "',");
            }
            else
            {
                strSql.Append("PBE_LinkMan= null ,");
            }
            if (model.PBE_LinkManName != null)
            {
                strSql.Append("PBE_LinkManName='" + model.PBE_LinkManName + "',");
            }
            else
            {
                strSql.Append("PBE_LinkManName= null ,");
            }
            if (model.PBE_Shen != null)
            {
                strSql.Append("PBE_Shen='" + model.PBE_Shen + "',");
            }
            else
            {
                strSql.Append("PBE_Shen= null ,");
            }
            if (model.PBE_Shi != null)
            {
                strSql.Append("PBE_Shi='" + model.PBE_Shi + "',");
            }
            else
            {
                strSql.Append("PBE_Shi= null ,");
            }
            if (model.PBE_Qu != null)
            {
                strSql.Append("PBE_Qu='" + model.PBE_Qu + "',");
            }
            else
            {
                strSql.Append("PBE_Qu= null ,");
            }
            if (model.PBE_Jie != null)
            {
                strSql.Append("PBE_Jie='" + model.PBE_Jie + "',");
            }
            else
            {
                strSql.Append("PBE_Jie= null ,");
            }
            if (model.PBE_Address != null)
            {
                strSql.Append("PBE_Address='" + model.PBE_Address + "',");
            }
            else
            {
                strSql.Append("PBE_Address= null ,");
            }
            if (model.PBE_Phone != null)
            {
                strSql.Append("PBE_Phone='" + model.PBE_Phone + "',");
            }
            else
            {
                strSql.Append("PBE_Phone= null ,");
            }
            if (model.PBE_TelPhone != null)
            {
                strSql.Append("PBE_TelPhone='" + model.PBE_TelPhone + "',");
            }
            else
            {
                strSql.Append("PBE_TelPhone= null ,");
            }
            if (model.PBE_ReCustomer != null)
            {
                strSql.Append("PBE_ReCustomer='" + model.PBE_ReCustomer + "',");
            }
            else
            {
                strSql.Append("PBE_ReCustomer= null ,");
            }
            if (model.PBE_ReCustomerName != null)
            {
                strSql.Append("PBE_ReCustomerName='" + model.PBE_ReCustomerName + "',");
            }
            else
            {
                strSql.Append("PBE_ReCustomerName= null ,");
            }
            if (model.PBE_ReLinkMan != null)
            {
                strSql.Append("PBE_ReLinkMan='" + model.PBE_ReLinkMan + "',");
            }
            else
            {
                strSql.Append("PBE_ReLinkMan= null ,");
            }
            if (model.PBE_ReLinkManName != null)
            {
                strSql.Append("PBE_ReLinkManName='" + model.PBE_ReLinkManName + "',");
            }
            else
            {
                strSql.Append("PBE_ReLinkManName= null ,");
            }
            if (model.PBE_ReShen != null)
            {
                strSql.Append("PBE_ReShen='" + model.PBE_ReShen + "',");
            }
            else
            {
                strSql.Append("PBE_ReShen= null ,");
            }
            if (model.PBE_ReShi != null)
            {
                strSql.Append("PBE_ReShi='" + model.PBE_ReShi + "',");
            }
            else
            {
                strSql.Append("PBE_ReShi= null ,");
            }
            if (model.PBE_ReQu != null)
            {
                strSql.Append("PBE_ReQu='" + model.PBE_ReQu + "',");
            }
            else
            {
                strSql.Append("PBE_ReQu= null ,");
            }
            if (model.PBE_ReJie != null)
            {
                strSql.Append("PBE_ReJie='" + model.PBE_ReJie + "',");
            }
            else
            {
                strSql.Append("PBE_ReJie= null ,");
            }
            if (model.PBE_ReAddress != null)
            {
                strSql.Append("PBE_ReAddress='" + model.PBE_ReAddress + "',");
            }
            else
            {
                strSql.Append("PBE_ReAddress= null ,");
            }
            if (model.PBE_RePhone != null)
            {
                strSql.Append("PBE_RePhone='" + model.PBE_RePhone + "',");
            }
            else
            {
                strSql.Append("PBE_RePhone= null ,");
            }
            if (model.PBE_ReTelPhone != null)
            {
                strSql.Append("PBE_ReTelPhone='" + model.PBE_ReTelPhone + "',");
            }
            else
            {
                strSql.Append("PBE_ReTelPhone= null ,");
            }
            if (model.PBE_Use != null)
            {
                strSql.Append("PBE_Use='" + model.PBE_Use + "',");
            }
            else
            {
                strSql.Append("PBE_Use= null ,");
            }
            if (model.PBE_KDName != null)
            {
                strSql.Append("PBE_KDName='" + model.PBE_KDName + "',");
            }
            else
            {
                strSql.Append("PBE_KDName= null ,");
            }
            if (model.PBE_KDCode != null)
            {
                strSql.Append("PBE_KDCode='" + model.PBE_KDCode + "',");
            }
            else
            {
                strSql.Append("PBE_KDCode= null ,");
            }
            if (model.PBE_KDEnglishName != null)
            {
                strSql.Append("PBE_KDEnglishName='" + model.PBE_KDEnglishName + "',");
            }
            else
            {
                strSql.Append("PBE_KDEnglishName= null ,");
            }
            if (model.PBE_State != null)
            {
                strSql.Append("PBE_State='" + model.PBE_State + "',");
            }
            else
            {
                strSql.Append("PBE_State= null ,");
            }
            if (model.PBE_ReceTime != null)
            {
                strSql.Append("PBE_ReceTime='" + model.PBE_ReceTime + "',");
            }
            else
            {
                strSql.Append("PBE_ReceTime= null ,");
            }
            if (model.PBE_CTime != null)
            {
                strSql.Append("PBE_CTime='" + model.PBE_CTime + "',");
            }
            else
            {
                strSql.Append("PBE_CTime= null ,");
            }
            if (model.PBE_Creator != null)
            {
                strSql.Append("PBE_Creator='" + model.PBE_Creator + "',");
            }
            else
            {
                strSql.Append("PBE_Creator= null ,");
            }
            if (model.PBE_MTime != null)
            {
                strSql.Append("PBE_MTime='" + model.PBE_MTime + "',");
            }
            else
            {
                strSql.Append("PBE_MTime= null ,");
            }
            if (model.PBE_Mender != null)
            {
                strSql.Append("PBE_Mender='" + model.PBE_Mender + "',");
            }
            else
            {
                strSql.Append("PBE_Mender= null ,");
            }
            if (model.PBE_Del != null)
            {
                strSql.Append("PBE_Del=" + model.PBE_Del + ",");
            }
            else
            {
                strSql.Append("PBE_Del= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where PBE_ID='" + model.PBE_ID + "' ");
            int rowsAffected = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rowsAffected > 0)
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
        public bool Delete(string PBE_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PB_Basic_Express ");
            strSql.Append(" where PBE_ID='" + PBE_ID + "' ");
            int rowsAffected = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }		/// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string PBE_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PB_Basic_Express ");
            strSql.Append(" where PBE_ID in (" + PBE_IDlist + ")  ");
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
        public KNet.Model.PB_Basic_Express GetModel(string PBE_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" PBE_ID,PBE_Code,PBE_Stime,PBE_DutyPerson,PBE_CustomerValue,PBE_CustomerName,PBE_LinkMan,PBE_LinkManName,PBE_Shen,PBE_Shi,PBE_Qu,PBE_Jie,PBE_Address,PBE_Phone,PBE_TelPhone,PBE_ReCustomer,PBE_ReCustomerName,PBE_ReLinkMan,PBE_ReLinkManName,PBE_ReShen,PBE_ReShi,PBE_ReQu,PBE_ReJie,PBE_ReAddress,PBE_RePhone,PBE_ReTelPhone,PBE_Use,PBE_KDName,PBE_KDCode,PBE_KDEnglishName,PBE_State,PBE_ReceTime,PBE_CTime,PBE_Creator,PBE_MTime,PBE_Mender,PBE_Del ");
            strSql.Append(" from PB_Basic_Express ");
            strSql.Append(" where PBE_ID='" + PBE_ID + "' ");
            KNet.Model.PB_Basic_Express model = new KNet.Model.PB_Basic_Express();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
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
        public KNet.Model.PB_Basic_Express DataRowToModel(DataRow row)
        {
            KNet.Model.PB_Basic_Express model = new KNet.Model.PB_Basic_Express();
            if (row != null)
            {
                if (row["PBE_ID"] != null)
                {
                    model.PBE_ID = row["PBE_ID"].ToString();
                }
                if (row["PBE_Code"] != null)
                {
                    model.PBE_Code = row["PBE_Code"].ToString();
                }
                if (row["PBE_Stime"] != null && row["PBE_Stime"].ToString() != "")
                {
                    model.PBE_Stime = DateTime.Parse(row["PBE_Stime"].ToString());
                }
                if (row["PBE_DutyPerson"] != null)
                {
                    model.PBE_DutyPerson = row["PBE_DutyPerson"].ToString();
                }
                if (row["PBE_CustomerValue"] != null)
                {
                    model.PBE_CustomerValue = row["PBE_CustomerValue"].ToString();
                }
                if (row["PBE_CustomerName"] != null)
                {
                    model.PBE_CustomerName = row["PBE_CustomerName"].ToString();
                }
                if (row["PBE_LinkMan"] != null)
                {
                    model.PBE_LinkMan = row["PBE_LinkMan"].ToString();
                }
                if (row["PBE_LinkManName"] != null)
                {
                    model.PBE_LinkManName = row["PBE_LinkManName"].ToString();
                }
                if (row["PBE_Shen"] != null)
                {
                    model.PBE_Shen = row["PBE_Shen"].ToString();
                }
                if (row["PBE_Shi"] != null)
                {
                    model.PBE_Shi = row["PBE_Shi"].ToString();
                }
                if (row["PBE_Qu"] != null)
                {
                    model.PBE_Qu = row["PBE_Qu"].ToString();
                }
                if (row["PBE_Jie"] != null)
                {
                    model.PBE_Jie = row["PBE_Jie"].ToString();
                }
                if (row["PBE_Address"] != null)
                {
                    model.PBE_Address = row["PBE_Address"].ToString();
                }
                if (row["PBE_Phone"] != null)
                {
                    model.PBE_Phone = row["PBE_Phone"].ToString();
                }
                if (row["PBE_TelPhone"] != null)
                {
                    model.PBE_TelPhone = row["PBE_TelPhone"].ToString();
                }
                if (row["PBE_ReCustomer"] != null)
                {
                    model.PBE_ReCustomer = row["PBE_ReCustomer"].ToString();
                }
                if (row["PBE_ReCustomerName"] != null)
                {
                    model.PBE_ReCustomerName = row["PBE_ReCustomerName"].ToString();
                }
                if (row["PBE_ReLinkMan"] != null)
                {
                    model.PBE_ReLinkMan = row["PBE_ReLinkMan"].ToString();
                }
                if (row["PBE_ReLinkManName"] != null)
                {
                    model.PBE_ReLinkManName = row["PBE_ReLinkManName"].ToString();
                }
                if (row["PBE_ReShen"] != null)
                {
                    model.PBE_ReShen = row["PBE_ReShen"].ToString();
                }
                if (row["PBE_ReShi"] != null)
                {
                    model.PBE_ReShi = row["PBE_ReShi"].ToString();
                }
                if (row["PBE_ReQu"] != null)
                {
                    model.PBE_ReQu = row["PBE_ReQu"].ToString();
                }
                if (row["PBE_ReJie"] != null)
                {
                    model.PBE_ReJie = row["PBE_ReJie"].ToString();
                }
                if (row["PBE_ReAddress"] != null)
                {
                    model.PBE_ReAddress = row["PBE_ReAddress"].ToString();
                }
                if (row["PBE_RePhone"] != null)
                {
                    model.PBE_RePhone = row["PBE_RePhone"].ToString();
                }
                if (row["PBE_ReTelPhone"] != null)
                {
                    model.PBE_ReTelPhone = row["PBE_ReTelPhone"].ToString();
                }
                if (row["PBE_Use"] != null)
                {
                    model.PBE_Use = row["PBE_Use"].ToString();
                }
                if (row["PBE_KDName"] != null)
                {
                    model.PBE_KDName = row["PBE_KDName"].ToString();
                }
                if (row["PBE_KDCode"] != null)
                {
                    model.PBE_KDCode = row["PBE_KDCode"].ToString();
                }
                if (row["PBE_KDEnglishName"] != null)
                {
                    model.PBE_KDEnglishName = row["PBE_KDEnglishName"].ToString();
                }
                if (row["PBE_State"] != null)
                {
                    model.PBE_State = row["PBE_State"].ToString();
                }
                if (row["PBE_ReceTime"] != null && row["PBE_ReceTime"].ToString() != "")
                {
                    model.PBE_ReceTime = DateTime.Parse(row["PBE_ReceTime"].ToString());
                }
                if (row["PBE_CTime"] != null && row["PBE_CTime"].ToString() != "")
                {
                    model.PBE_CTime = DateTime.Parse(row["PBE_CTime"].ToString());
                }
                if (row["PBE_Creator"] != null)
                {
                    model.PBE_Creator = row["PBE_Creator"].ToString();
                }
                if (row["PBE_MTime"] != null && row["PBE_MTime"].ToString() != "")
                {
                    model.PBE_MTime = DateTime.Parse(row["PBE_MTime"].ToString());
                }
                if (row["PBE_Mender"] != null)
                {
                    model.PBE_Mender = row["PBE_Mender"].ToString();
                }
                if (row["PBE_Del"] != null && row["PBE_Del"].ToString() != "")
                {
                    model.PBE_Del = int.Parse(row["PBE_Del"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PBE_ID,PBE_Code,PBE_Stime,PBE_DutyPerson,PBE_CustomerValue,PBE_CustomerName,PBE_LinkMan,PBE_LinkManName,PBE_Shen,PBE_Shi,PBE_Qu,PBE_Jie,PBE_Address,PBE_Phone,PBE_TelPhone,PBE_ReCustomer,PBE_ReCustomerName,PBE_ReLinkMan,PBE_ReLinkManName,PBE_ReShen,PBE_ReShi,PBE_ReQu,PBE_ReJie,PBE_ReAddress,PBE_RePhone,PBE_ReTelPhone,PBE_Use,PBE_KDName,PBE_KDCode,PBE_KDEnglishName,PBE_State,PBE_ReceTime,PBE_CTime,PBE_Creator,PBE_MTime,PBE_Mender,PBE_Del ");
            strSql.Append(" FROM PB_Basic_Express ");
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
            strSql.Append(" PBE_ID,PBE_Code,PBE_Stime,PBE_DutyPerson,PBE_CustomerValue,PBE_CustomerName,PBE_LinkMan,PBE_LinkManName,PBE_Shen,PBE_Shi,PBE_Qu,PBE_Jie,PBE_Address,PBE_Phone,PBE_TelPhone,PBE_ReCustomer,PBE_ReCustomerName,PBE_ReLinkMan,PBE_ReLinkManName,PBE_ReShen,PBE_ReShi,PBE_ReQu,PBE_ReJie,PBE_ReAddress,PBE_RePhone,PBE_ReTelPhone,PBE_Use,PBE_KDName,PBE_KDCode,PBE_KDEnglishName,PBE_State,PBE_ReceTime,PBE_CTime,PBE_Creator,PBE_MTime,PBE_Mender,PBE_Del ");
            strSql.Append(" FROM PB_Basic_Express ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM PB_Basic_Express ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.PBE_ID desc");
            }
            strSql.Append(")AS Row, T.*  from PB_Basic_Express T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        */

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

