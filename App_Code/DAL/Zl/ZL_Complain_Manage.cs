using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:ZL_Complain_Manage
    /// </summary>
    public partial class ZL_Complain_Manage
    {
        public ZL_Complain_Manage()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ZCM_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ZL_Complain_Manage");
            strSql.Append(" where ZCM_ID=@ZCM_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ZCM_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = ZCM_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.ZL_Complain_Manage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ZL_Complain_Manage(");
            strSql.Append("ZCM_ID,ZCM_Code,ZCM_ProductsBarCode,ZCM_STime,ZCM_CustomerValue,ZCM_LinkMan,ZCM_DutyPerson,ZCM_Type,ZCM_ContractNo,ZCM_ShipNo,ZCM_HurryState,ZCM_TimeState,ZCM_D1Leder,ZCM_D1Member,ZCM_D2Finder,ZCM_D2Time,ZCM_D2Number,ZCM_D2FRemarks,ZCM_D3QState,ZCM_D3CustomerNumber,ZCM_D3TravelNumber,ZCM_D3CompyNumber,ZCM_D3MaterialDetails,ZCM_D3Time,ZCM_D3Cause,ZCM_D4Cause,ZCM_D4Time,ZCM_D4Person,ZCM_D5Cause,ZCM_D5Time,ZCM_D5Person,ZCM_D6Cause,ZCM_D6Time,ZCM_D6Person,ZCM_D7Cause,ZCM_D7Time,ZCM_D7Person,ZCM_D8Cause,ZCM_D8Time,ZCM_D8Person,ZCM_CTime,ZCM_Creator,ZCM_MTime,ZCM_Mender,ZCM_Del)");
            strSql.Append(" values (");
            strSql.Append("@ZCM_ID,@ZCM_Code,@ZCM_ProductsBarCode,@ZCM_STime,@ZCM_CustomerValue,@ZCM_LinkMan,@ZCM_DutyPerson,@ZCM_Type,@ZCM_ContractNo,@ZCM_ShipNo,@ZCM_HurryState,@ZCM_TimeState,@ZCM_D1Leder,@ZCM_D1Member,@ZCM_D2Finder,@ZCM_D2Time,@ZCM_D2Number,@ZCM_D2FRemarks,@ZCM_D3QState,@ZCM_D3CustomerNumber,@ZCM_D3TravelNumber,@ZCM_D3CompyNumber,@ZCM_D3MaterialDetails,@ZCM_D3Time,@ZCM_D3Cause,@ZCM_D4Cause,@ZCM_D4Time,@ZCM_D4Person,@ZCM_D5Cause,@ZCM_D5Time,@ZCM_D5Person,@ZCM_D6Cause,@ZCM_D6Time,@ZCM_D6Person,@ZCM_D7Cause,@ZCM_D7Time,@ZCM_D7Person,@ZCM_D8Cause,@ZCM_D8Time,@ZCM_D8Person,@ZCM_CTime,@ZCM_Creator,@ZCM_MTime,@ZCM_Mender,@ZCM_Del)");
            SqlParameter[] parameters = {
					new SqlParameter("@ZCM_ID", SqlDbType.VarChar,50),
					new SqlParameter("@ZCM_Code", SqlDbType.VarChar,50),
					new SqlParameter("@ZCM_ProductsBarCode", SqlDbType.VarChar,50),
					new SqlParameter("@ZCM_STime", SqlDbType.DateTime),
					new SqlParameter("@ZCM_CustomerValue", SqlDbType.VarChar,50),
					new SqlParameter("@ZCM_LinkMan", SqlDbType.VarChar,50),
					new SqlParameter("@ZCM_DutyPerson", SqlDbType.VarChar,50),
					new SqlParameter("@ZCM_Type", SqlDbType.VarChar,50),
					new SqlParameter("@ZCM_ContractNo", SqlDbType.VarChar,50),
					new SqlParameter("@ZCM_ShipNo", SqlDbType.VarChar,50),
					new SqlParameter("@ZCM_HurryState", SqlDbType.VarChar,50),
					new SqlParameter("@ZCM_TimeState", SqlDbType.VarChar,50),
					new SqlParameter("@ZCM_D1Leder", SqlDbType.VarChar,50),
					new SqlParameter("@ZCM_D1Member", SqlDbType.VarChar,50),
					new SqlParameter("@ZCM_D2Finder", SqlDbType.VarChar,50),
					new SqlParameter("@ZCM_D2Time", SqlDbType.DateTime),
					new SqlParameter("@ZCM_D2Number", SqlDbType.Int,4),
					new SqlParameter("@ZCM_D2FRemarks", SqlDbType.VarChar,300),
					new SqlParameter("@ZCM_D3QState", SqlDbType.VarChar,50),
					new SqlParameter("@ZCM_D3CustomerNumber", SqlDbType.Int,4),
					new SqlParameter("@ZCM_D3TravelNumber", SqlDbType.Int,4),
					new SqlParameter("@ZCM_D3CompyNumber", SqlDbType.Int,4),
					new SqlParameter("@ZCM_D3MaterialDetails", SqlDbType.VarChar,300),
					new SqlParameter("@ZCM_D3Time", SqlDbType.DateTime),
					new SqlParameter("@ZCM_D3Cause", SqlDbType.VarChar,300),
					new SqlParameter("@ZCM_D4Cause", SqlDbType.VarChar,300),
					new SqlParameter("@ZCM_D4Time", SqlDbType.DateTime),
					new SqlParameter("@ZCM_D4Person", SqlDbType.VarChar,50),
					new SqlParameter("@ZCM_D5Cause", SqlDbType.VarChar,300),
					new SqlParameter("@ZCM_D5Time", SqlDbType.DateTime),
					new SqlParameter("@ZCM_D5Person", SqlDbType.VarChar,50),
					new SqlParameter("@ZCM_D6Cause", SqlDbType.VarChar,300),
					new SqlParameter("@ZCM_D6Time", SqlDbType.DateTime),
					new SqlParameter("@ZCM_D6Person", SqlDbType.VarChar,50),
					new SqlParameter("@ZCM_D7Cause", SqlDbType.VarChar,300),
					new SqlParameter("@ZCM_D7Time", SqlDbType.DateTime),
					new SqlParameter("@ZCM_D7Person", SqlDbType.VarChar,50),
					new SqlParameter("@ZCM_D8Cause", SqlDbType.VarChar,300),
					new SqlParameter("@ZCM_D8Time", SqlDbType.DateTime),
					new SqlParameter("@ZCM_D8Person", SqlDbType.VarChar,50),
					new SqlParameter("@ZCM_CTime", SqlDbType.DateTime),
					new SqlParameter("@ZCM_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@ZCM_MTime", SqlDbType.DateTime),
					new SqlParameter("@ZCM_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@ZCM_Del", SqlDbType.Int,4)};
            parameters[0].Value = model.ZCM_ID;
            parameters[1].Value = model.ZCM_Code;
            parameters[2].Value = model.ZCM_ProductsBarCode;
            parameters[3].Value = model.ZCM_STime;
            parameters[4].Value = model.ZCM_CustomerValue;
            parameters[5].Value = model.ZCM_LinkMan;
            parameters[6].Value = model.ZCM_DutyPerson;
            parameters[7].Value = model.ZCM_Type;
            parameters[8].Value = model.ZCM_ContractNo;
            parameters[9].Value = model.ZCM_ShipNo;
            parameters[10].Value = model.ZCM_HurryState;
            parameters[11].Value = model.ZCM_TimeState;
            parameters[12].Value = model.ZCM_D1Leder;
            parameters[13].Value = model.ZCM_D1Member;
            parameters[14].Value = model.ZCM_D2Finder;
            parameters[15].Value = model.ZCM_D2Time;
            parameters[16].Value = model.ZCM_D2Number;
            parameters[17].Value = model.ZCM_D2FRemarks;
            parameters[18].Value = model.ZCM_D3QState;
            parameters[19].Value = model.ZCM_D3CustomerNumber;
            parameters[20].Value = model.ZCM_D3TravelNumber;
            parameters[21].Value = model.ZCM_D3CompyNumber;
            parameters[22].Value = model.ZCM_D3MaterialDetails;
            parameters[23].Value = model.ZCM_D3Time;
            parameters[24].Value = model.ZCM_D3Cause;
            parameters[25].Value = model.ZCM_D4Cause;
            parameters[26].Value = model.ZCM_D4Time;
            parameters[27].Value = model.ZCM_D4Person;
            parameters[28].Value = model.ZCM_D5Cause;
            parameters[29].Value = model.ZCM_D5Time;
            parameters[30].Value = model.ZCM_D5Person;
            parameters[31].Value = model.ZCM_D6Cause;
            parameters[32].Value = model.ZCM_D6Time;
            parameters[33].Value = model.ZCM_D6Person;
            parameters[34].Value = model.ZCM_D7Cause;
            parameters[35].Value = model.ZCM_D7Time;
            parameters[36].Value = model.ZCM_D7Person;
            parameters[37].Value = model.ZCM_D8Cause;
            parameters[38].Value = model.ZCM_D8Time;
            parameters[39].Value = model.ZCM_D8Person;
            parameters[40].Value = model.ZCM_CTime;
            parameters[41].Value = model.ZCM_Creator;
            parameters[42].Value = model.ZCM_MTime;
            parameters[43].Value = model.ZCM_Mender;
            parameters[44].Value = model.ZCM_Del;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.ZL_Complain_Manage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ZL_Complain_Manage set ");
            strSql.Append("ZCM_Code=@ZCM_Code,");
            strSql.Append("ZCM_ProductsBarCode=@ZCM_ProductsBarCode,");
            strSql.Append("ZCM_STime=@ZCM_STime,");
            strSql.Append("ZCM_CustomerValue=@ZCM_CustomerValue,");
            strSql.Append("ZCM_LinkMan=@ZCM_LinkMan,");
            strSql.Append("ZCM_DutyPerson=@ZCM_DutyPerson,");
            strSql.Append("ZCM_Type=@ZCM_Type,");
            strSql.Append("ZCM_ContractNo=@ZCM_ContractNo,");
            strSql.Append("ZCM_ShipNo=@ZCM_ShipNo,");
            strSql.Append("ZCM_HurryState=@ZCM_HurryState,");
            strSql.Append("ZCM_TimeState=@ZCM_TimeState,");
            strSql.Append("ZCM_D1Leder=@ZCM_D1Leder,");
            strSql.Append("ZCM_D1Member=@ZCM_D1Member,");
            strSql.Append("ZCM_D2Finder=@ZCM_D2Finder,");
            strSql.Append("ZCM_D2Time=@ZCM_D2Time,");
            strSql.Append("ZCM_D2Number=@ZCM_D2Number,");
            strSql.Append("ZCM_D2FRemarks=@ZCM_D2FRemarks,");
            strSql.Append("ZCM_D3QState=@ZCM_D3QState,");
            strSql.Append("ZCM_D3CustomerNumber=@ZCM_D3CustomerNumber,");
            strSql.Append("ZCM_D3TravelNumber=@ZCM_D3TravelNumber,");
            strSql.Append("ZCM_D3CompyNumber=@ZCM_D3CompyNumber,");
            strSql.Append("ZCM_D3MaterialDetails=@ZCM_D3MaterialDetails,");
            strSql.Append("ZCM_D3Time=@ZCM_D3Time,");
            strSql.Append("ZCM_D3Cause=@ZCM_D3Cause,");
            strSql.Append("ZCM_D4Cause=@ZCM_D4Cause,");
            strSql.Append("ZCM_D4Time=@ZCM_D4Time,");
            strSql.Append("ZCM_D4Person=@ZCM_D4Person,");
            strSql.Append("ZCM_D5Cause=@ZCM_D5Cause,");
            strSql.Append("ZCM_D5Time=@ZCM_D5Time,");
            strSql.Append("ZCM_D5Person=@ZCM_D5Person,");
            strSql.Append("ZCM_D6Cause=@ZCM_D6Cause,");
            strSql.Append("ZCM_D6Time=@ZCM_D6Time,");
            strSql.Append("ZCM_D6Person=@ZCM_D6Person,");
            strSql.Append("ZCM_D7Cause=@ZCM_D7Cause,");
            strSql.Append("ZCM_D7Time=@ZCM_D7Time,");
            strSql.Append("ZCM_D7Person=@ZCM_D7Person,");
            strSql.Append("ZCM_D8Cause=@ZCM_D8Cause,");
            strSql.Append("ZCM_D8Time=@ZCM_D8Time,");
            strSql.Append("ZCM_D8Person=@ZCM_D8Person,");
            strSql.Append("ZCM_MTime=@ZCM_MTime,");
            strSql.Append("ZCM_Mender=@ZCM_Mender,");
            strSql.Append("ZCM_Del=@ZCM_Del");
            strSql.Append(" where ZCM_ID=@ZCM_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ZCM_Code", SqlDbType.VarChar,50),
					new SqlParameter("@ZCM_ProductsBarCode", SqlDbType.VarChar,50),
					new SqlParameter("@ZCM_STime", SqlDbType.DateTime),
					new SqlParameter("@ZCM_CustomerValue", SqlDbType.VarChar,50),
					new SqlParameter("@ZCM_LinkMan", SqlDbType.VarChar,50),
					new SqlParameter("@ZCM_DutyPerson", SqlDbType.VarChar,50),
					new SqlParameter("@ZCM_Type", SqlDbType.VarChar,50),
					new SqlParameter("@ZCM_ContractNo", SqlDbType.VarChar,50),
					new SqlParameter("@ZCM_ShipNo", SqlDbType.VarChar,50),
					new SqlParameter("@ZCM_HurryState", SqlDbType.VarChar,50),
					new SqlParameter("@ZCM_TimeState", SqlDbType.VarChar,50),
					new SqlParameter("@ZCM_D1Leder", SqlDbType.VarChar,50),
					new SqlParameter("@ZCM_D1Member", SqlDbType.VarChar,50),
					new SqlParameter("@ZCM_D2Finder", SqlDbType.VarChar,50),
					new SqlParameter("@ZCM_D2Time", SqlDbType.DateTime),
					new SqlParameter("@ZCM_D2Number", SqlDbType.Int,4),
					new SqlParameter("@ZCM_D2FRemarks", SqlDbType.VarChar,300),
					new SqlParameter("@ZCM_D3QState", SqlDbType.VarChar,50),
					new SqlParameter("@ZCM_D3CustomerNumber", SqlDbType.Int,4),
					new SqlParameter("@ZCM_D3TravelNumber", SqlDbType.Int,4),
					new SqlParameter("@ZCM_D3CompyNumber", SqlDbType.Int,4),
					new SqlParameter("@ZCM_D3MaterialDetails", SqlDbType.VarChar,300),
					new SqlParameter("@ZCM_D3Time", SqlDbType.DateTime),
					new SqlParameter("@ZCM_D3Cause", SqlDbType.VarChar,300),
					new SqlParameter("@ZCM_D4Cause", SqlDbType.VarChar,300),
					new SqlParameter("@ZCM_D4Time", SqlDbType.DateTime),
					new SqlParameter("@ZCM_D4Person", SqlDbType.VarChar,50),
					new SqlParameter("@ZCM_D5Cause", SqlDbType.VarChar,300),
					new SqlParameter("@ZCM_D5Time", SqlDbType.DateTime),
					new SqlParameter("@ZCM_D5Person", SqlDbType.VarChar,50),
					new SqlParameter("@ZCM_D6Cause", SqlDbType.VarChar,300),
					new SqlParameter("@ZCM_D6Time", SqlDbType.DateTime),
					new SqlParameter("@ZCM_D6Person", SqlDbType.VarChar,50),
					new SqlParameter("@ZCM_D7Cause", SqlDbType.VarChar,300),
					new SqlParameter("@ZCM_D7Time", SqlDbType.DateTime),
					new SqlParameter("@ZCM_D7Person", SqlDbType.VarChar,50),
					new SqlParameter("@ZCM_D8Cause", SqlDbType.VarChar,300),
					new SqlParameter("@ZCM_D8Time", SqlDbType.DateTime),
					new SqlParameter("@ZCM_D8Person", SqlDbType.VarChar,50),
					new SqlParameter("@ZCM_MTime", SqlDbType.DateTime),
					new SqlParameter("@ZCM_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@ZCM_Del", SqlDbType.Int,4),
					new SqlParameter("@ZCM_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.ZCM_Code;
            parameters[1].Value = model.ZCM_ProductsBarCode;
            parameters[2].Value = model.ZCM_STime;
            parameters[3].Value = model.ZCM_CustomerValue;
            parameters[4].Value = model.ZCM_LinkMan;
            parameters[5].Value = model.ZCM_DutyPerson;
            parameters[6].Value = model.ZCM_Type;
            parameters[7].Value = model.ZCM_ContractNo;
            parameters[8].Value = model.ZCM_ShipNo;
            parameters[9].Value = model.ZCM_HurryState;
            parameters[10].Value = model.ZCM_TimeState;
            parameters[11].Value = model.ZCM_D1Leder;
            parameters[12].Value = model.ZCM_D1Member;
            parameters[13].Value = model.ZCM_D2Finder;
            parameters[14].Value = model.ZCM_D2Time;
            parameters[15].Value = model.ZCM_D2Number;
            parameters[16].Value = model.ZCM_D2FRemarks;
            parameters[17].Value = model.ZCM_D3QState;
            parameters[18].Value = model.ZCM_D3CustomerNumber;
            parameters[19].Value = model.ZCM_D3TravelNumber;
            parameters[20].Value = model.ZCM_D3CompyNumber;
            parameters[21].Value = model.ZCM_D3MaterialDetails;
            parameters[22].Value = model.ZCM_D3Time;
            parameters[23].Value = model.ZCM_D3Cause;
            parameters[24].Value = model.ZCM_D4Cause;
            parameters[25].Value = model.ZCM_D4Time;
            parameters[26].Value = model.ZCM_D4Person;
            parameters[27].Value = model.ZCM_D5Cause;
            parameters[28].Value = model.ZCM_D5Time;
            parameters[29].Value = model.ZCM_D5Person;
            parameters[30].Value = model.ZCM_D6Cause;
            parameters[31].Value = model.ZCM_D6Time;
            parameters[32].Value = model.ZCM_D6Person;
            parameters[33].Value = model.ZCM_D7Cause;
            parameters[34].Value = model.ZCM_D7Time;
            parameters[35].Value = model.ZCM_D7Person;
            parameters[36].Value = model.ZCM_D8Cause;
            parameters[37].Value = model.ZCM_D8Time;
            parameters[38].Value = model.ZCM_D8Person;
            parameters[39].Value = model.ZCM_MTime;
            parameters[40].Value = model.ZCM_Mender;
            parameters[41].Value = model.ZCM_Del;
            parameters[42].Value = model.ZCM_ID;

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
        public bool Delete(string ZCM_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ZL_Complain_Manage ");
            strSql.Append(" where ZCM_ID=@ZCM_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ZCM_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = ZCM_ID;

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
        public bool DeleteList(string ZCM_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ZL_Complain_Manage ");
            strSql.Append(" where ZCM_ID in (" + ZCM_IDlist + ")  ");
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
        public KNet.Model.ZL_Complain_Manage GetModel(string ZCM_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ZCM_ID,ZCM_Code,ZCM_ProductsBarCode,ZCM_STime,ZCM_CustomerValue,ZCM_LinkMan,ZCM_DutyPerson,ZCM_Type,ZCM_ContractNo,ZCM_ShipNo,ZCM_HurryState,ZCM_TimeState,ZCM_D1Leder,ZCM_D1Member,ZCM_D2Finder,ZCM_D2Time,ZCM_D2Number,ZCM_D2FRemarks,ZCM_D3QState,ZCM_D3CustomerNumber,ZCM_D3TravelNumber,ZCM_D3CompyNumber,ZCM_D3MaterialDetails,ZCM_D3Time,ZCM_D3Cause,ZCM_D4Cause,ZCM_D4Time,ZCM_D4Person,ZCM_D5Cause,ZCM_D5Time,ZCM_D5Person,ZCM_D6Cause,ZCM_D6Time,ZCM_D6Person,ZCM_D7Cause,ZCM_D7Time,ZCM_D7Person,ZCM_D8Cause,ZCM_D8Time,ZCM_D8Person,ZCM_CTime,ZCM_Creator,ZCM_MTime,ZCM_Mender,ZCM_Del from ZL_Complain_Manage ");
            strSql.Append(" where ZCM_ID=@ZCM_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ZCM_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = ZCM_ID;

            KNet.Model.ZL_Complain_Manage model = new KNet.Model.ZL_Complain_Manage();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ZCM_ID"] != null && ds.Tables[0].Rows[0]["ZCM_ID"].ToString() != "")
                {
                    model.ZCM_ID = ds.Tables[0].Rows[0]["ZCM_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ZCM_Code"] != null && ds.Tables[0].Rows[0]["ZCM_Code"].ToString() != "")
                {
                    model.ZCM_Code = ds.Tables[0].Rows[0]["ZCM_Code"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ZCM_ProductsBarCode"] != null && ds.Tables[0].Rows[0]["ZCM_ProductsBarCode"].ToString() != "")
                {
                    model.ZCM_ProductsBarCode = ds.Tables[0].Rows[0]["ZCM_ProductsBarCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ZCM_STime"] != null && ds.Tables[0].Rows[0]["ZCM_STime"].ToString() != "")
                {
                    model.ZCM_STime = DateTime.Parse(ds.Tables[0].Rows[0]["ZCM_STime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ZCM_CustomerValue"] != null && ds.Tables[0].Rows[0]["ZCM_CustomerValue"].ToString() != "")
                {
                    model.ZCM_CustomerValue = ds.Tables[0].Rows[0]["ZCM_CustomerValue"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ZCM_LinkMan"] != null && ds.Tables[0].Rows[0]["ZCM_LinkMan"].ToString() != "")
                {
                    model.ZCM_LinkMan = ds.Tables[0].Rows[0]["ZCM_LinkMan"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ZCM_DutyPerson"] != null && ds.Tables[0].Rows[0]["ZCM_DutyPerson"].ToString() != "")
                {
                    model.ZCM_DutyPerson = ds.Tables[0].Rows[0]["ZCM_DutyPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ZCM_Type"] != null && ds.Tables[0].Rows[0]["ZCM_Type"].ToString() != "")
                {
                    model.ZCM_Type = ds.Tables[0].Rows[0]["ZCM_Type"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ZCM_ContractNo"] != null && ds.Tables[0].Rows[0]["ZCM_ContractNo"].ToString() != "")
                {
                    model.ZCM_ContractNo = ds.Tables[0].Rows[0]["ZCM_ContractNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ZCM_ShipNo"] != null && ds.Tables[0].Rows[0]["ZCM_ShipNo"].ToString() != "")
                {
                    model.ZCM_ShipNo = ds.Tables[0].Rows[0]["ZCM_ShipNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ZCM_HurryState"] != null && ds.Tables[0].Rows[0]["ZCM_HurryState"].ToString() != "")
                {
                    model.ZCM_HurryState = ds.Tables[0].Rows[0]["ZCM_HurryState"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ZCM_TimeState"] != null && ds.Tables[0].Rows[0]["ZCM_TimeState"].ToString() != "")
                {
                    model.ZCM_TimeState = ds.Tables[0].Rows[0]["ZCM_TimeState"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ZCM_D1Leder"] != null && ds.Tables[0].Rows[0]["ZCM_D1Leder"].ToString() != "")
                {
                    model.ZCM_D1Leder = ds.Tables[0].Rows[0]["ZCM_D1Leder"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ZCM_D1Member"] != null && ds.Tables[0].Rows[0]["ZCM_D1Member"].ToString() != "")
                {
                    model.ZCM_D1Member = ds.Tables[0].Rows[0]["ZCM_D1Member"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ZCM_D2Finder"] != null && ds.Tables[0].Rows[0]["ZCM_D2Finder"].ToString() != "")
                {
                    model.ZCM_D2Finder = ds.Tables[0].Rows[0]["ZCM_D2Finder"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ZCM_D2Time"] != null && ds.Tables[0].Rows[0]["ZCM_D2Time"].ToString() != "")
                {
                    model.ZCM_D2Time = DateTime.Parse(ds.Tables[0].Rows[0]["ZCM_D2Time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ZCM_D2Number"] != null && ds.Tables[0].Rows[0]["ZCM_D2Number"].ToString() != "")
                {
                    model.ZCM_D2Number = int.Parse(ds.Tables[0].Rows[0]["ZCM_D2Number"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ZCM_D2FRemarks"] != null && ds.Tables[0].Rows[0]["ZCM_D2FRemarks"].ToString() != "")
                {
                    model.ZCM_D2FRemarks = ds.Tables[0].Rows[0]["ZCM_D2FRemarks"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ZCM_D3QState"] != null && ds.Tables[0].Rows[0]["ZCM_D3QState"].ToString() != "")
                {
                    model.ZCM_D3QState = ds.Tables[0].Rows[0]["ZCM_D3QState"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ZCM_D3CustomerNumber"] != null && ds.Tables[0].Rows[0]["ZCM_D3CustomerNumber"].ToString() != "")
                {
                    model.ZCM_D3CustomerNumber = int.Parse(ds.Tables[0].Rows[0]["ZCM_D3CustomerNumber"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ZCM_D3TravelNumber"] != null && ds.Tables[0].Rows[0]["ZCM_D3TravelNumber"].ToString() != "")
                {
                    model.ZCM_D3TravelNumber = int.Parse(ds.Tables[0].Rows[0]["ZCM_D3TravelNumber"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ZCM_D3CompyNumber"] != null && ds.Tables[0].Rows[0]["ZCM_D3CompyNumber"].ToString() != "")
                {
                    model.ZCM_D3CompyNumber = int.Parse(ds.Tables[0].Rows[0]["ZCM_D3CompyNumber"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ZCM_D3MaterialDetails"] != null && ds.Tables[0].Rows[0]["ZCM_D3MaterialDetails"].ToString() != "")
                {
                    model.ZCM_D3MaterialDetails = ds.Tables[0].Rows[0]["ZCM_D3MaterialDetails"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ZCM_D3Time"] != null && ds.Tables[0].Rows[0]["ZCM_D3Time"].ToString() != "")
                {
                    model.ZCM_D3Time = DateTime.Parse(ds.Tables[0].Rows[0]["ZCM_D3Time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ZCM_D3Cause"] != null && ds.Tables[0].Rows[0]["ZCM_D3Cause"].ToString() != "")
                {
                    model.ZCM_D3Cause = ds.Tables[0].Rows[0]["ZCM_D3Cause"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ZCM_D4Cause"] != null && ds.Tables[0].Rows[0]["ZCM_D4Cause"].ToString() != "")
                {
                    model.ZCM_D4Cause = ds.Tables[0].Rows[0]["ZCM_D4Cause"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ZCM_D4Time"] != null && ds.Tables[0].Rows[0]["ZCM_D4Time"].ToString() != "")
                {
                    model.ZCM_D4Time = DateTime.Parse(ds.Tables[0].Rows[0]["ZCM_D4Time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ZCM_D4Person"] != null && ds.Tables[0].Rows[0]["ZCM_D4Person"].ToString() != "")
                {
                    model.ZCM_D4Person = ds.Tables[0].Rows[0]["ZCM_D4Person"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ZCM_D5Cause"] != null && ds.Tables[0].Rows[0]["ZCM_D5Cause"].ToString() != "")
                {
                    model.ZCM_D5Cause = ds.Tables[0].Rows[0]["ZCM_D5Cause"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ZCM_D5Time"] != null && ds.Tables[0].Rows[0]["ZCM_D5Time"].ToString() != "")
                {
                    model.ZCM_D5Time = DateTime.Parse(ds.Tables[0].Rows[0]["ZCM_D5Time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ZCM_D5Person"] != null && ds.Tables[0].Rows[0]["ZCM_D5Person"].ToString() != "")
                {
                    model.ZCM_D5Person = ds.Tables[0].Rows[0]["ZCM_D5Person"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ZCM_D6Cause"] != null && ds.Tables[0].Rows[0]["ZCM_D6Cause"].ToString() != "")
                {
                    model.ZCM_D6Cause = ds.Tables[0].Rows[0]["ZCM_D6Cause"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ZCM_D6Time"] != null && ds.Tables[0].Rows[0]["ZCM_D6Time"].ToString() != "")
                {
                    model.ZCM_D6Time = DateTime.Parse(ds.Tables[0].Rows[0]["ZCM_D6Time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ZCM_D6Person"] != null && ds.Tables[0].Rows[0]["ZCM_D6Person"].ToString() != "")
                {
                    model.ZCM_D6Person = ds.Tables[0].Rows[0]["ZCM_D6Person"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ZCM_D7Cause"] != null && ds.Tables[0].Rows[0]["ZCM_D7Cause"].ToString() != "")
                {
                    model.ZCM_D7Cause = ds.Tables[0].Rows[0]["ZCM_D7Cause"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ZCM_D7Time"] != null && ds.Tables[0].Rows[0]["ZCM_D7Time"].ToString() != "")
                {
                    model.ZCM_D7Time = DateTime.Parse(ds.Tables[0].Rows[0]["ZCM_D7Time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ZCM_D7Person"] != null && ds.Tables[0].Rows[0]["ZCM_D7Person"].ToString() != "")
                {
                    model.ZCM_D7Person = ds.Tables[0].Rows[0]["ZCM_D7Person"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ZCM_D8Cause"] != null && ds.Tables[0].Rows[0]["ZCM_D8Cause"].ToString() != "")
                {
                    model.ZCM_D8Cause = ds.Tables[0].Rows[0]["ZCM_D8Cause"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ZCM_D8Time"] != null && ds.Tables[0].Rows[0]["ZCM_D8Time"].ToString() != "")
                {
                    model.ZCM_D8Time = DateTime.Parse(ds.Tables[0].Rows[0]["ZCM_D8Time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ZCM_D8Person"] != null && ds.Tables[0].Rows[0]["ZCM_D8Person"].ToString() != "")
                {
                    model.ZCM_D8Person = ds.Tables[0].Rows[0]["ZCM_D8Person"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ZCM_CTime"] != null && ds.Tables[0].Rows[0]["ZCM_CTime"].ToString() != "")
                {
                    model.ZCM_CTime = DateTime.Parse(ds.Tables[0].Rows[0]["ZCM_CTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ZCM_Creator"] != null && ds.Tables[0].Rows[0]["ZCM_Creator"].ToString() != "")
                {
                    model.ZCM_Creator = ds.Tables[0].Rows[0]["ZCM_Creator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ZCM_MTime"] != null && ds.Tables[0].Rows[0]["ZCM_MTime"].ToString() != "")
                {
                    model.ZCM_MTime = DateTime.Parse(ds.Tables[0].Rows[0]["ZCM_MTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ZCM_Mender"] != null && ds.Tables[0].Rows[0]["ZCM_Mender"].ToString() != "")
                {
                    model.ZCM_Mender = ds.Tables[0].Rows[0]["ZCM_Mender"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ZCM_Del"] != null && ds.Tables[0].Rows[0]["ZCM_Del"].ToString() != "")
                {
                    model.ZCM_Del = int.Parse(ds.Tables[0].Rows[0]["ZCM_Del"].ToString());
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
            strSql.Append("select ZCM_ID,ZCM_Code,ZCM_ProductsBarCode,ZCM_STime,ZCM_CustomerValue,ZCM_LinkMan,ZCM_DutyPerson,ZCM_Type,ZCM_ContractNo,ZCM_ShipNo,ZCM_HurryState,ZCM_TimeState,ZCM_D1Leder,ZCM_D1Member,ZCM_D2Finder,ZCM_D2Time,ZCM_D2Number,ZCM_D2FRemarks,ZCM_D3QState,ZCM_D3CustomerNumber,ZCM_D3TravelNumber,ZCM_D3CompyNumber,ZCM_D3MaterialDetails,ZCM_D3Time,ZCM_D3Cause,ZCM_D4Cause,ZCM_D4Time,ZCM_D4Person,ZCM_D5Cause,ZCM_D5Time,ZCM_D5Person,ZCM_D6Cause,ZCM_D6Time,ZCM_D6Person,ZCM_D7Cause,ZCM_D7Time,ZCM_D7Person,ZCM_D8Cause,ZCM_D8Time,ZCM_D8Person,ZCM_CTime,ZCM_Creator,ZCM_MTime,ZCM_Mender,ZCM_Del ");
            strSql.Append(" FROM ZL_Complain_Manage ");
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
            strSql.Append(" ZCM_ID,ZCM_Code,ZCM_ProductsBarCode,ZCM_STime,ZCM_CustomerValue,ZCM_LinkMan,ZCM_DutyPerson,ZCM_Type,ZCM_ContractNo,ZCM_ShipNo,ZCM_HurryState,ZCM_TimeState,ZCM_D1Leder,ZCM_D1Member,ZCM_D2Finder,ZCM_D2Time,ZCM_D2Number,ZCM_D2FRemarks,ZCM_D3QState,ZCM_D3CustomerNumber,ZCM_D3TravelNumber,ZCM_D3CompyNumber,ZCM_D3MaterialDetails,ZCM_D3Time,ZCM_D3Cause,ZCM_D4Cause,ZCM_D4Time,ZCM_D4Person,ZCM_D5Cause,ZCM_D5Time,ZCM_D5Person,ZCM_D6Cause,ZCM_D6Time,ZCM_D6Person,ZCM_D7Cause,ZCM_D7Time,ZCM_D7Person,ZCM_D8Cause,ZCM_D8Time,ZCM_D8Person,ZCM_CTime,ZCM_Creator,ZCM_MTime,ZCM_Mender,ZCM_Del ");
            strSql.Append(" FROM ZL_Complain_Manage ");
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
            parameters[0].Value = "ZL_Complain_Manage";
            parameters[1].Value = "ZCM_ID";
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

