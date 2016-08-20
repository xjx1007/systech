using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;

namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类KNet_Sales_OutWareList_FlowList。
    /// </summary>
    public class KNet_Sales_OutWareList_FlowList
    {
        public KNet_Sales_OutWareList_FlowList()
        { }
        #region  成员方法
        /// <summary>
        ///  增加一条数据
        /// </summary>
        public bool Add(KNet.Model.KNet_Sales_OutWareList_FlowList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KNet_Sales_OutWareList_FlowList(");
            strSql.Append("FollowNo,OutWareNo,FollowDateTime,FollowStaffNo,FollowText,FollowEnd,KDName,KDCode,KDCodeName,ReTime,ReturnType,KSO_ISFH,KSO_Phone,KSO_IsMessage,OldTime,KSO_Order)");
            strSql.Append(" values (");
            strSql.Append("@FollowNo,@OutWareNo,@FollowDateTime,@FollowStaffNo,@FollowText,@FollowEnd,@KDName,@KDCode,@KDCodeName,@ReTime,@ReturnType,@KSO_ISFH,@KSO_Phone,@KSO_IsMessage,@OldTime,@KSO_Order)");
            SqlParameter[] parameters = {
					new SqlParameter("@FollowNo", SqlDbType.NVarChar,50),
					new SqlParameter("@OutWareNo", SqlDbType.NVarChar,50),
					new SqlParameter("@FollowDateTime", SqlDbType.DateTime),
					new SqlParameter("@FollowStaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@FollowText", SqlDbType.NText),
					new SqlParameter("@FollowEnd", SqlDbType.Bit,1),
					new SqlParameter("@KDName", SqlDbType.VarChar,50),
					new SqlParameter("@KDCode", SqlDbType.VarChar,50),
					new SqlParameter("@KDCodeName", SqlDbType.VarChar,50),
					new SqlParameter("@ReTime", SqlDbType.DateTime),
					new SqlParameter("@ReturnType", SqlDbType.VarChar,50),
					new SqlParameter("@KSO_ISFH", SqlDbType.Int,4),
					new SqlParameter("@KSO_Phone", SqlDbType.VarChar,50),
					new SqlParameter("@KSO_IsMessage", SqlDbType.Int,4),
					new SqlParameter("@OldTime", SqlDbType.DateTime),
					new SqlParameter("@KSO_Order", SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.FollowNo;
            parameters[1].Value = model.OutWareNo;
            parameters[2].Value = model.FollowDateTime;
            parameters[3].Value = model.FollowStaffNo;
            parameters[4].Value = model.FollowText;
            parameters[5].Value = model.FollowEnd;
            parameters[6].Value = model.KDName;
            parameters[7].Value = model.KDCode;
            parameters[8].Value = model.KDCodeName;
            parameters[9].Value = model.ReTime;
            parameters[10].Value = model.ReturnType;
            parameters[11].Value = model.KSO_ISFH;
            parameters[12].Value = model.KSO_Phone;
            parameters[13].Value = model.KSO_IsMessage;
            parameters[14].Value = model.OldTime;
            parameters[15].Value = model.KSO_Order;
            
            


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

            DbHelperSQL.RunProcedure("Proc_KNet_Sales_OutWareList_FlowList_Delete", parameters, out rowsAffected);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM KNet_Sales_OutWareList_FlowList ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        
        /// <summary>
        /// UpDate
        /// </summary>
        public void UpDataSate(KNet.Model.KNet_Sales_OutWareList_FlowList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KNet_Sales_OutWareList_FlowList set ");
            strSql.Append("State=@State ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@State", SqlDbType.VarChar,50),
					new SqlParameter("@ID", SqlDbType.VarChar,50)
            };
            parameters[0].Value = model.State;
            parameters[1].Value = model.ID;
             DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
            strSql.Append(" ID,FollowNo,OutWareNo,FollowDateTime,FollowStaffNo,FollowText,FollowEnd ");
            strSql.Append(" FROM KNet_Sales_OutWareList_FlowList ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }



        #endregion  成员方法
    }
}

