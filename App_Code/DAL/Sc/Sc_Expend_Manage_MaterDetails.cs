using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:Sc_Expend_Manage_MaterDetails
    /// </summary>
    public partial class Sc_Expend_Manage_MaterDetails
    {
        public Sc_Expend_Manage_MaterDetails()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string SED_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sc_Expend_Manage_MaterDetails");
            strSql.Append(" where SED_ID=@SED_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SED_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = SED_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Sc_Expend_Manage_MaterDetails model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sc_Expend_Manage_MaterDetails(");
            strSql.Append("SED_ID,SED_SEMID,SED_ProductsBarCode,SED_HouseNo,SED_RkNumber,SED_RkPrice,SED_RkMoney,SED_RkTime,SED_RkPerson,SED_Type,SED_Remarks,SED_FromHouseNo,SED_Code)");
            strSql.Append(" values (");
            strSql.Append("@SED_ID,@SED_SEMID,@SED_ProductsBarCode,@SED_HouseNo,@SED_RkNumber,@SED_RkPrice,@SED_RkMoney,@SED_RkTime,@SED_RkPerson,@SED_Type,@SED_Remarks,@SED_FromHouseNo,@SED_Code)");
            SqlParameter[] parameters = {
					new SqlParameter("@SED_ID", SqlDbType.VarChar,50),
					new SqlParameter("@SED_SEMID", SqlDbType.VarChar,50),
					new SqlParameter("@SED_ProductsBarCode", SqlDbType.VarChar,50),
					new SqlParameter("@SED_HouseNo", SqlDbType.VarChar,50),
					new SqlParameter("@SED_RkNumber", SqlDbType.Int,4),
					new SqlParameter("@SED_RkPrice", SqlDbType.Decimal,9),
					new SqlParameter("@SED_RkMoney", SqlDbType.Decimal,9),
					new SqlParameter("@SED_RkTime", SqlDbType.DateTime),
					new SqlParameter("@SED_RkPerson", SqlDbType.VarChar,50),
					new SqlParameter("@SED_Type", SqlDbType.Int,4),
					new SqlParameter("@SED_Remarks", SqlDbType.VarChar,50),
					new SqlParameter("@SED_FromHouseNo", SqlDbType.VarChar,50),
					new SqlParameter("@SED_Code", SqlDbType.VarChar,50)};
            parameters[0].Value = model.SED_ID;
            parameters[1].Value = model.SED_SEMID;
            parameters[2].Value = model.SED_ProductsBarCode;
            parameters[3].Value = model.SED_HouseNo;
            parameters[4].Value = model.SED_RkNumber;
            parameters[5].Value = model.SED_RkPrice;
            parameters[6].Value = model.SED_RkMoney;
            parameters[7].Value = model.SED_RkTime;
            parameters[8].Value = model.SED_RkPerson;
            parameters[9].Value = model.SED_Type;
            parameters[10].Value = model.SED_Remarks;
            parameters[11].Value = model.SED_FromHouseNo;
            parameters[12].Value = model.SED_Code;
            
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Sc_Expend_Manage_MaterDetails model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sc_Expend_Manage_MaterDetails set ");
            strSql.Append("SED_SEMID=@SED_SEMID,");
            strSql.Append("SED_ProductsBarCode=@SED_ProductsBarCode,");
            strSql.Append("SED_HouseNo=@SED_HouseNo,");
            strSql.Append("SED_RkNumber=@SED_RkNumber,");
            strSql.Append("SED_RkPrice=@SED_RkPrice,");
            strSql.Append("SED_RkMoney=@SED_RkMoney,");
            strSql.Append("SED_RkTime=@SED_RkTime,");
            strSql.Append("SED_RkPerson=@SED_RkPerson,");
            strSql.Append("SED_Type=@SED_Type,");
            strSql.Append("SED_Remarks=@SED_Remarks");
            strSql.Append(" where SED_ID=@SED_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SED_SEMID", SqlDbType.VarChar,50),
					new SqlParameter("@SED_ProductsBarCode", SqlDbType.VarChar,50),
					new SqlParameter("@SED_HouseNo", SqlDbType.VarChar,50),
					new SqlParameter("@SED_RkNumber", SqlDbType.Int,4),
					new SqlParameter("@SED_RkPrice", SqlDbType.Decimal,9),
					new SqlParameter("@SED_RkMoney", SqlDbType.Decimal,9),
					new SqlParameter("@SED_RkTime", SqlDbType.DateTime),
					new SqlParameter("@SED_RkPerson", SqlDbType.VarChar,50),
					new SqlParameter("@SED_Type", SqlDbType.Int,4),
					new SqlParameter("@SED_Remarks", SqlDbType.VarChar,50),
					new SqlParameter("@SED_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.SED_SEMID;
            parameters[1].Value = model.SED_ProductsBarCode;
            parameters[2].Value = model.SED_HouseNo;
            parameters[3].Value = model.SED_RkNumber;
            parameters[4].Value = model.SED_RkPrice;
            parameters[5].Value = model.SED_RkMoney;
            parameters[6].Value = model.SED_RkTime;
            parameters[7].Value = model.SED_RkPerson;
            parameters[8].Value = model.SED_Type;
            parameters[9].Value = model.SED_Remarks;
            parameters[10].Value = model.SED_ID;

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
        public bool UpdateWwPrice(KNet.Model.Sc_Expend_Manage_MaterDetails model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sc_Expend_Manage_MaterDetails set ");
            strSql.Append("SED_WwPrice=@SED_WwPrice,");
            strSql.Append("SED_WwMoney=@SED_WwMoney");
            strSql.Append(" where SED_ID=@SED_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SED_WwPrice", SqlDbType.Decimal,9),
					new SqlParameter("@SED_WwMoney", SqlDbType.Decimal,9),
					new SqlParameter("@SED_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.SED_WwPrice;
            parameters[1].Value = model.SED_WwMoney;
            parameters[2].Value = model.SED_ID;

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
        public bool Delete(string SED_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sc_Expend_Manage_MaterDetails ");
            strSql.Append(" where SED_ID=@SED_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SED_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = SED_ID;

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
        public bool DeleteList(string SED_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sc_Expend_Manage_MaterDetails ");
            strSql.Append(" where SED_ID in (" + SED_IDlist + ")  ");
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
        public KNet.Model.Sc_Expend_Manage_MaterDetails GetModel(string SED_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SED_ID,SED_SEMID,SED_ProductsBarCode,SED_HouseNo,SED_RkNumber,SED_RkPrice,SED_RkMoney,SED_RkTime,SED_RkPerson,SED_Type,SED_Remarks from Sc_Expend_Manage_MaterDetails ");
            strSql.Append(" where SED_ID=@SED_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SED_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = SED_ID;

            KNet.Model.Sc_Expend_Manage_MaterDetails model = new KNet.Model.Sc_Expend_Manage_MaterDetails();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SED_ID"] != null && ds.Tables[0].Rows[0]["SED_ID"].ToString() != "")
                {
                    model.SED_ID = ds.Tables[0].Rows[0]["SED_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SED_SEMID"] != null && ds.Tables[0].Rows[0]["SED_SEMID"].ToString() != "")
                {
                    model.SED_SEMID = ds.Tables[0].Rows[0]["SED_SEMID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SED_ProductsBarCode"] != null && ds.Tables[0].Rows[0]["SED_ProductsBarCode"].ToString() != "")
                {
                    model.SED_ProductsBarCode = ds.Tables[0].Rows[0]["SED_ProductsBarCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SED_HouseNo"] != null && ds.Tables[0].Rows[0]["SED_HouseNo"].ToString() != "")
                {
                    model.SED_HouseNo = ds.Tables[0].Rows[0]["SED_HouseNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SED_RkNumber"] != null && ds.Tables[0].Rows[0]["SED_RkNumber"].ToString() != "")
                {
                    model.SED_RkNumber = int.Parse(ds.Tables[0].Rows[0]["SED_RkNumber"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SED_RkPrice"] != null && ds.Tables[0].Rows[0]["SED_RkPrice"].ToString() != "")
                {
                    model.SED_RkPrice = decimal.Parse(ds.Tables[0].Rows[0]["SED_RkPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SED_RkMoney"] != null && ds.Tables[0].Rows[0]["SED_RkMoney"].ToString() != "")
                {
                    model.SED_RkMoney = decimal.Parse(ds.Tables[0].Rows[0]["SED_RkMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SED_RkTime"] != null && ds.Tables[0].Rows[0]["SED_RkTime"].ToString() != "")
                {
                    model.SED_RkTime = DateTime.Parse(ds.Tables[0].Rows[0]["SED_RkTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SED_RkPerson"] != null && ds.Tables[0].Rows[0]["SED_RkPerson"].ToString() != "")
                {
                    model.SED_RkPerson = ds.Tables[0].Rows[0]["SED_RkPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SED_Type"] != null && ds.Tables[0].Rows[0]["SED_Type"].ToString() != "")
                {
                    model.SED_Type = int.Parse(ds.Tables[0].Rows[0]["SED_Type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SED_Remarks"] != null && ds.Tables[0].Rows[0]["SED_Remarks"].ToString() != "")
                {
                    model.SED_Remarks = ds.Tables[0].Rows[0]["SED_Remarks"].ToString();
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
            strSql.Append(" FROM Sc_Expend_Manage_MaterDetails ");
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
            strSql.Append(" SED_ID,SED_SEMID,SED_ProductsBarCode,SED_HouseNo,SED_RkNumber,SED_RkPrice,SED_RkMoney,SED_RkTime,SED_RkPerson,SED_Type,SED_Remarks ");
            strSql.Append(" FROM Sc_Expend_Manage_MaterDetails ");
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
            parameters[0].Value = "Sc_Expend_Manage_MaterDetails";
            parameters[1].Value = "SED_ID";
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

