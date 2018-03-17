using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:Xs_Contract_Manage
    /// </summary>
    public partial class Xs_Contract_Manage
    {
        public Xs_Contract_Manage()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string XCM_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Xs_Contract_Manage");
            strSql.Append(" where XCM_ID=@XCM_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XCM_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = XCM_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加
        /// </summary>
        public bool Add(KNet.Model.Xs_Contract_Manage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Xs_Contract_Manage(");
            strSql.Append("XCM_ID,XCM_Code,XCM_Type,XCM_Title,XCM_CustomerValue,XCM_DutyPerson,XCM_STime,XCM_Flow,XCM_Remarks,XCM_Del,XCM_Creator,XCM_CTime,XCM_Mender,XCM_MTime,XCM_OrderNo,XCM_CheckYN,XCM_PayMent,XCM_BillType,XCM_TechnicalRequire,XCM_ProductPackaging,XCM_QualityRequire,XCM_WarrantyPeriod,XCM_DeliveryReqyire,XCM_FhDetails,XCM_KpType ");
            strSql.Append(") values (");
            strSql.Append("@XCM_ID,@XCM_Code,@XCM_Type,@XCM_Title,@XCM_CustomerValue,@XCM_DutyPerson,@XCM_STime,@XCM_Flow,@XCM_Remarks,@XCM_Del,@XCM_Creator,@XCM_CTime,@XCM_Mender,@XCM_MTime,@XCM_OrderNo,@XCM_CheckYN,@XCM_PayMent,@XCM_BillType,@XCM_TechnicalRequire,@XCM_ProductPackaging,@XCM_QualityRequire,@XCM_WarrantyPeriod,@XCM_DeliveryReqyire,@XCM_FhDetails,@XCM_KpType)");
            SqlParameter[] parameters = {
 new SqlParameter("@XCM_ID", SqlDbType.VarChar,50),
 new SqlParameter("@XCM_Code", SqlDbType.VarChar,50),
 new SqlParameter("@XCM_Type", SqlDbType.VarChar,50),
 new SqlParameter("@XCM_Title", SqlDbType.VarChar,250),
 new SqlParameter("@XCM_CustomerValue", SqlDbType.VarChar,50),
 new SqlParameter("@XCM_DutyPerson", SqlDbType.VarChar,50),
 new SqlParameter("@XCM_STime", SqlDbType.DateTime,8),
 new SqlParameter("@XCM_Flow", SqlDbType.VarChar,50),
 new SqlParameter("@XCM_Remarks", SqlDbType.VarChar,2000),
 new SqlParameter("@XCM_Del", SqlDbType.Int,4),
 new SqlParameter("@XCM_Creator", SqlDbType.VarChar,50),
 new SqlParameter("@XCM_CTime", SqlDbType.DateTime,8),
 new SqlParameter("@XCM_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@XCM_MTime", SqlDbType.DateTime,8),
 new SqlParameter("@XCM_OrderNo", SqlDbType.Int,4),
 new SqlParameter("@XCM_CheckYN", SqlDbType.Int,4),
 new SqlParameter("@XCM_PayMent", SqlDbType.VarChar,50),
 new SqlParameter("@XCM_BillType", SqlDbType.VarChar,50),
 new SqlParameter("@XCM_TechnicalRequire", SqlDbType.VarChar,450),
 new SqlParameter("@XCM_ProductPackaging", SqlDbType.VarChar,450),
 new SqlParameter("@XCM_QualityRequire", SqlDbType.VarChar,450),
 new SqlParameter("@XCM_WarrantyPeriod", SqlDbType.VarChar,450),
 new SqlParameter("@XCM_DeliveryReqyire", SqlDbType.VarChar,450),
 new SqlParameter("@XCM_FhDetails", SqlDbType.VarChar,1000),
 new SqlParameter("@XCM_KpType", SqlDbType.VarChar,50)
                                        };
            parameters[0].Value = model.XCM_ID;
            parameters[1].Value = model.XCM_Code;
            parameters[2].Value = model.XCM_Type;
            parameters[3].Value = model.XCM_Title;
            parameters[4].Value = model.XCM_CustomerValue;
            parameters[5].Value = model.XCM_DutyPerson;
            parameters[6].Value = model.XCM_STime;
            parameters[7].Value = model.XCM_Flow;
            parameters[8].Value = model.XCM_Remarks;
            parameters[9].Value = model.XCM_Del;
            parameters[10].Value = model.XCM_Creator;
            parameters[11].Value = model.XCM_CTime;
            parameters[12].Value = model.XCM_Mender;
            parameters[13].Value = model.XCM_MTime;
            parameters[14].Value = model.XCM_OrderNo;
            parameters[15].Value = model.XCM_CheckYN;
            parameters[16].Value = model.XCM_PayMent;
            parameters[17].Value = model.XCM_BillType;
            parameters[18].Value = model.XCM_TechnicalRequire;
            parameters[19].Value = model.XCM_ProductPackaging;
            parameters[20].Value = model.XCM_QualityRequire;
            parameters[21].Value = model.XCM_WarrantyPeriod;
            parameters[22].Value = model.XCM_DeliveryReqyire;
            parameters[23].Value = model.XCM_FhDetails;
            parameters[24].Value = model.XCM_KpType;
            
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
        /// 修改
        /// </summary>
        public bool Update(KNet.Model.Xs_Contract_Manage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update Xs_Contract_Manage set ");
            strSql.Append("XCM_Code=@XCM_Code,");
            strSql.Append("XCM_Type=@XCM_Type,");
            strSql.Append("XCM_Title=@XCM_Title,");
            strSql.Append("XCM_CustomerValue=@XCM_CustomerValue,");
            strSql.Append("XCM_DutyPerson=@XCM_DutyPerson,");
            strSql.Append("XCM_STime=@XCM_STime,");
            strSql.Append("XCM_Flow=@XCM_Flow,");
            strSql.Append("XCM_Remarks=@XCM_Remarks,");
            strSql.Append("XCM_Del=@XCM_Del,");
            strSql.Append("XCM_Mender=@XCM_Mender,");
            strSql.Append("XCM_MTime=@XCM_MTime,");
            strSql.Append("XCM_OrderNo=@XCM_OrderNo,");
            strSql.Append("XCM_CheckYN=@XCM_CheckYN,");
            strSql.Append("XCM_PayMent=@XCM_PayMent,");
            strSql.Append("XCM_BillType=@XCM_BillType,");
            strSql.Append("XCM_TechnicalRequire=@XCM_TechnicalRequire,");
            strSql.Append("XCM_ProductPackaging=@XCM_ProductPackaging,");
            strSql.Append("XCM_QualityRequire=@XCM_QualityRequire,");
            strSql.Append("XCM_WarrantyPeriod=@XCM_WarrantyPeriod,");
            strSql.Append("XCM_DeliveryReqyire=@XCM_DeliveryReqyire,");
            strSql.Append("XCM_FhDetails=@XCM_FhDetails,");
            strSql.Append("XCM_KpType=@XCM_KpType");
            
            strSql.Append(" where XCM_ID=@XCM_ID ");
            SqlParameter[] parameters = {
 new SqlParameter("@XCM_Code", SqlDbType.VarChar,50),
 new SqlParameter("@XCM_Type", SqlDbType.VarChar,50),
 new SqlParameter("@XCM_Title", SqlDbType.VarChar,250),
 new SqlParameter("@XCM_CustomerValue", SqlDbType.VarChar,50),
 new SqlParameter("@XCM_DutyPerson", SqlDbType.VarChar,50),
 new SqlParameter("@XCM_STime", SqlDbType.DateTime,8),
 new SqlParameter("@XCM_Flow", SqlDbType.VarChar,50),
 new SqlParameter("@XCM_Remarks", SqlDbType.VarChar,2000),
 new SqlParameter("@XCM_Del", SqlDbType.Int,4),
 new SqlParameter("@XCM_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@XCM_MTime", SqlDbType.DateTime,8),
 new SqlParameter("@XCM_OrderNo", SqlDbType.Int,4),
 new SqlParameter("@XCM_CheckYN", SqlDbType.Int,4),
 new SqlParameter("@XCM_PayMent", SqlDbType.VarChar,50),
 new SqlParameter("@XCM_BillType", SqlDbType.VarChar,50),
 new SqlParameter("@XCM_TechnicalRequire", SqlDbType.VarChar,450),
 new SqlParameter("@XCM_ProductPackaging", SqlDbType.VarChar,450),
 new SqlParameter("@XCM_QualityRequire", SqlDbType.VarChar,450),
 new SqlParameter("@XCM_WarrantyPeriod", SqlDbType.VarChar,450),
 new SqlParameter("@XCM_DeliveryReqyire", SqlDbType.VarChar,450),
 new SqlParameter("@XCM_FhDetails", SqlDbType.VarChar,1000),
 new SqlParameter("@XCM_KpType", SqlDbType.VarChar,50),
 
new SqlParameter("@XCM_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.XCM_Code;
            parameters[1].Value = model.XCM_Type;
            parameters[2].Value = model.XCM_Title;
            parameters[3].Value = model.XCM_CustomerValue;
            parameters[4].Value = model.XCM_DutyPerson;
            parameters[5].Value = model.XCM_STime;
            parameters[6].Value = model.XCM_Flow;
            parameters[7].Value = model.XCM_Remarks;
            parameters[8].Value = model.XCM_Del;
            parameters[9].Value = model.XCM_Mender;
            parameters[10].Value = model.XCM_MTime;
            parameters[11].Value = model.XCM_OrderNo;
            parameters[12].Value = model.XCM_CheckYN;
            parameters[13].Value = model.XCM_PayMent;
            parameters[14].Value = model.XCM_BillType;
            parameters[15].Value = model.XCM_TechnicalRequire;
            parameters[16].Value = model.XCM_ProductPackaging;
            parameters[17].Value = model.XCM_QualityRequire;
            parameters[18].Value = model.XCM_WarrantyPeriod;
            parameters[19].Value = model.XCM_DeliveryReqyire;
            parameters[20].Value = model.XCM_FhDetails;
            parameters[21].Value = model.XCM_KpType;
            parameters[22].Value = model.XCM_ID;

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
        public bool Delete(string XCM_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Xs_Contract_Manage ");
            strSql.Append(" where XCM_ID=@XCM_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XCM_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = XCM_ID;

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
        public bool DeleteList(string XCM_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Xs_Contract_Manage ");
            strSql.Append(" where XCM_ID in (" + XCM_IDlist + ")  ");
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
        /// 得到数据
        /// </summary>
        public KNet.Model.Xs_Contract_Manage GetModel(string XCM_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from Xs_Contract_Manage  ");
            strSql.Append("where XCM_ID=@XCM_ID  ");
            SqlParameter[] parameters = {
 new SqlParameter("@XCM_ID", SqlDbType.VarChar,50)
};
            parameters[0].Value = XCM_ID;
            KNet.Model.Xs_Contract_Manage model = new KNet.Model.Xs_Contract_Manage();
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
        public KNet.Model.Xs_Contract_Manage DataRowToModel(DataRow row)
        {
            KNet.Model.Xs_Contract_Manage model = new KNet.Model.Xs_Contract_Manage();
            if (row != null)
            {
                if (row["XCM_ID"] != null)
                {
                    model.XCM_ID = row["XCM_ID"].ToString();
                }
                else
                {
                    model.XCM_ID = "";
                }
                if (row["XCM_Code"] != null)
                {
                    model.XCM_Code = row["XCM_Code"].ToString();
                }
                else
                {
                    model.XCM_Code = "";
                }
                if (row["XCM_Type"] != null)
                {
                    model.XCM_Type = row["XCM_Type"].ToString();
                }
                else
                {
                    model.XCM_Type = "";
                }

                if (row["XCM_KpType"] != null)
                {
                    model.XCM_KpType = row["XCM_KpType"].ToString();
                }
                else
                {
                    model.XCM_KpType = "";
                }
                
                if (row["XCM_Title"] != null)
                {
                    model.XCM_Title = row["XCM_Title"].ToString();
                }
                else
                {
                    model.XCM_Title = "";
                }
                if (row["XCM_CustomerValue"] != null)
                {
                    model.XCM_CustomerValue = row["XCM_CustomerValue"].ToString();
                }
                else
                {
                    model.XCM_CustomerValue = "";
                }
                if (row["XCM_DutyPerson"] != null)
                {
                    model.XCM_DutyPerson = row["XCM_DutyPerson"].ToString();
                }
                else
                {
                    model.XCM_DutyPerson = "";
                }
                if (row["XCM_STime"] != null)
                {
                    model.XCM_STime = DateTime.Parse(row["XCM_STime"].ToString());
                }
                if (row["XCM_Flow"] != null)
                {
                    model.XCM_Flow = row["XCM_Flow"].ToString();
                }
                else
                {
                    model.XCM_Flow = "";
                }
                if (row["XCM_Remarks"] != null)
                {
                    model.XCM_Remarks = row["XCM_Remarks"].ToString();
                }
                else
                {
                    model.XCM_Remarks = "";
                }
                if (row["XCM_Del"] != null)
                {
                    model.XCM_Del = int.Parse(row["XCM_Del"].ToString());
                }
                else
                {
                    model.XCM_Del = 0;
                }
                if (row["XCM_Creator"] != null)
                {
                    model.XCM_Creator = row["XCM_Creator"].ToString();
                }
                else
                {
                    model.XCM_Creator = "";
                }
                if (row["XCM_CTime"] != null)
                {
                    model.XCM_CTime = DateTime.Parse(row["XCM_CTime"].ToString());
                }
                if (row["XCM_Mender"] != null)
                {
                    model.XCM_Mender = row["XCM_Mender"].ToString();
                }
                else
                {
                    model.XCM_Mender = "";
                }
                if (row["XCM_MTime"] != null)
                {
                    model.XCM_MTime = DateTime.Parse(row["XCM_MTime"].ToString());
                }
                if (row["XCM_OrderNo"] != null)
                {
                    model.XCM_OrderNo = int.Parse(row["XCM_OrderNo"].ToString());
                }
                else
                {
                    model.XCM_OrderNo = 0;
                }
                if (row["XCM_CheckYN"] != null)
                {
                    model.XCM_CheckYN = int.Parse(row["XCM_CheckYN"].ToString());
                }
                else
                {
                    model.XCM_CheckYN = 0;
                }
                if (row["XCM_PayMent"] != null)
                {
                    model.XCM_PayMent = row["XCM_PayMent"].ToString();
                }
                else
                {
                    model.XCM_PayMent = "";
                }
                if (row["XCM_BillType"] != null)
                {
                    model.XCM_BillType = row["XCM_BillType"].ToString();
                }
                else
                {
                    model.XCM_BillType = "";
                }
                if (row["XCM_TechnicalRequire"] != null)
                {
                    model.XCM_TechnicalRequire = row["XCM_TechnicalRequire"].ToString();
                }
                else
                {
                    model.XCM_TechnicalRequire = "";
                }
                if (row["XCM_ProductPackaging"] != null)
                {
                    model.XCM_ProductPackaging = row["XCM_ProductPackaging"].ToString();
                }
                else
                {
                    model.XCM_ProductPackaging = "";
                }
                if (row["XCM_QualityRequire"] != null)
                {
                    model.XCM_QualityRequire = row["XCM_QualityRequire"].ToString();
                }
                else
                {
                    model.XCM_QualityRequire = "";
                }
                if (row["XCM_WarrantyPeriod"] != null)
                {
                    model.XCM_WarrantyPeriod = row["XCM_WarrantyPeriod"].ToString();
                }
                else
                {
                    model.XCM_WarrantyPeriod = "";
                }
                if (row["XCM_DeliveryReqyire"] != null)
                {
                    model.XCM_DeliveryReqyire = row["XCM_DeliveryReqyire"].ToString();
                }
                else
                {
                    model.XCM_DeliveryReqyire = "";
                }
                if (row["XCM_FhDetails"] != null)
                {
                    model.XCM_FhDetails = row["XCM_FhDetails"].ToString();
                }
                else
                {
                    model.XCM_FhDetails = "";
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
            strSql.Append("select * ");
            strSql.Append(" FROM Xs_Contract_Manage ");
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
            strSql.Append(" FROM Xs_Contract_Manage ");
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
            parameters[0].Value = "Xs_Contract_Manage";
            parameters[1].Value = "XCM_ID";
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

