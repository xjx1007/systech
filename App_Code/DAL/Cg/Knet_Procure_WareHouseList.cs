using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;


namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类Knet_Procure_WareHouseList。
    /// </summary>
    public class Knet_Procure_WareHouseList
    {
        public Knet_Procure_WareHouseList()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string WareHouseNo)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@WareHouseNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = WareHouseNo;

            int result = DbHelperSQL.RunProcedure("Proc_Knet_Procure_WareHouseList_Exists", parameters, out rowsAffected);
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetLastCode()
        {
            string s_Return = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 WareHouseNo from Knet_Procure_WareHouseList");
            strSql.Append("  where datediff(year,KPW_CTime,GetDate())=0  order by WareHouseNo desc");

            DataSet Dts_Table = DbHelperSQL.Query(strSql.ToString());
            if (Dts_Table.Tables[0].Rows.Count > 0)
            {
                s_Return = Dts_Table.Tables[0].Rows[0][0].ToString();
            }
            return s_Return;
        }
        /// <summary>
        ///  增加一条数据 
        /// </summary>
        public void Add(KNet.Model.Knet_Procure_WareHouseList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Knet_Procure_WareHouseList(");
            strSql.Append("WareHouseNo,WareHouseTopic,ReceivNo,WareHouseDateTime,SuppNo,HouseNo,WareHouseStaffBranch,WareHouseStaffDepart,WareHouseStaffNo,WareHouseCheckStaffNo,WareHouseRemarks,OrderNo,IsShip,ShipDetials,WareHouseCheckYN,KPO_KDNameCode,KPO_KDName,KPO_KDCode,KPO_State,KPW_Creator,KPW_CTime,KPO_CheckTime)");
            strSql.Append(" values (");
            strSql.Append("@WareHouseNo,@WareHouseTopic,@ReceivNo,@WareHouseDateTime,@SuppNo,@HouseNo,@WareHouseStaffBranch,@WareHouseStaffDepart,@WareHouseStaffNo,@WareHouseCheckStaffNo,@WareHouseRemarks,@OrderNo,@IsShip,@ShipDetials,@WareHouseCheckYN,@KPO_KDNameCode,@KPO_KDName,@KPO_KDCode,@KPO_State,@KPW_Creator,@KPW_CTime,@KPO_CheckTime)");
            SqlParameter[] parameters = {
					new SqlParameter("@WareHouseNo", SqlDbType.NVarChar,50),
					new SqlParameter("@WareHouseTopic", SqlDbType.NVarChar,50),
					new SqlParameter("@ReceivNo", SqlDbType.NVarChar,50),
					new SqlParameter("@WareHouseDateTime", SqlDbType.DateTime),
					new SqlParameter("@SuppNo", SqlDbType.NVarChar,50),
					new SqlParameter("@HouseNo", SqlDbType.NVarChar,50),
					new SqlParameter("@WareHouseStaffBranch", SqlDbType.NVarChar,50),
					new SqlParameter("@WareHouseStaffDepart", SqlDbType.NVarChar,50),
					new SqlParameter("@WareHouseStaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@WareHouseCheckStaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@WareHouseRemarks", SqlDbType.NVarChar,1000),
					new SqlParameter("@OrderNo", SqlDbType.NVarChar,50),
					new SqlParameter("@IsShip", SqlDbType.VarChar,50),
					new SqlParameter("@ShipDetials", SqlDbType.VarChar,50),
					new SqlParameter("@WareHouseCheckYN", SqlDbType.Int,4),
					new SqlParameter("@KPO_KDNameCode", SqlDbType.VarChar,50),
					new SqlParameter("@KPO_KDName", SqlDbType.VarChar,50),
					new SqlParameter("@KPO_KDCode", SqlDbType.VarChar,50),
					new SqlParameter("@KPO_State", SqlDbType.VarChar,50),
					new SqlParameter("@KPW_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@KPW_CTime", SqlDbType.DateTime),
					new SqlParameter("@KPO_CheckTime", SqlDbType.DateTime)
                                        };
            parameters[0].Value = model.WareHouseNo;
            parameters[1].Value = model.WareHouseTopic;
            parameters[2].Value = model.ReceivNo;
            parameters[3].Value = model.WareHouseDateTime;
            parameters[4].Value = model.SuppNo;
            parameters[5].Value = model.HouseNo;
            parameters[6].Value = model.WareHouseStaffBranch;
            parameters[7].Value = model.WareHouseStaffDepart;
            parameters[8].Value = model.WareHouseStaffNo;
            parameters[9].Value = model.WareHouseCheckStaffNo;
            parameters[10].Value = model.WareHouseRemarks;
            parameters[11].Value = model.OrderNo;
            parameters[12].Value = model.IsShip;
            parameters[13].Value = model.ShipDetials;
            parameters[14].Value = model.WareHouseCheckYN;
            parameters[15].Value = model.KPO_KDNameCode;
            parameters[16].Value = model.KPO_KDName;
            parameters[17].Value = model.KPO_KDCode;
            parameters[18].Value = model.KPO_State;
            parameters[19].Value = model.KPW_Creator;
            parameters[20].Value = model.KPW_CTime;
            parameters[21].Value = model.KPO_CheckTime;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public void Update(KNet.Model.Knet_Procure_WareHouseList model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Knet_Procure_WareHouseList set ");
            strSql.Append("WareHouseTopic=@WareHouseTopic,");
            strSql.Append("WareHouseDateTime=@WareHouseDateTime,");
            strSql.Append("HouseNo=@HouseNo,");
            strSql.Append("WareHouseStaffBranch=@WareHouseStaffBranch,");
            strSql.Append("WareHouseStaffDepart=@WareHouseStaffDepart,");
            strSql.Append("WareHouseStaffNo=@WareHouseStaffNo,");
            strSql.Append("WareHouseRemarks=@WareHouseRemarks,");
            strSql.Append("IsShip=@IsShip,");
            strSql.Append("ShipDetials=@ShipDetials,");
            strSql.Append("KPO_KDNameCode=@KPO_KDNameCode,");
            strSql.Append("KPO_KDName=@KPO_KDName,");
            strSql.Append("KPO_KDCode=@KPO_KDCode,");
            strSql.Append("KPO_State=@KPO_State,");
            strSql.Append("KPW_Mender=@KPW_Mender,");
            strSql.Append("KPW_MTime=@KPW_MTime,");
            strSql.Append("KPO_CheckTime=@KPO_CheckTime");
            
            strSql.Append(" where WareHouseNo=@WareHouseNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@WareHouseTopic", SqlDbType.NVarChar,50),
					new SqlParameter("@WareHouseDateTime", SqlDbType.DateTime),
					new SqlParameter("@HouseNo", SqlDbType.NVarChar,50),
					new SqlParameter("@WareHouseStaffBranch", SqlDbType.NVarChar,50),
					new SqlParameter("@WareHouseStaffDepart", SqlDbType.NVarChar,50),
					new SqlParameter("@WareHouseStaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@WareHouseRemarks", SqlDbType.NVarChar,1000),
					new SqlParameter("@IsShip", SqlDbType.VarChar,50),
					new SqlParameter("@ShipDetials", SqlDbType.VarChar,50),
					new SqlParameter("@WareHouseNo", SqlDbType.NVarChar,50),
					new SqlParameter("@KPO_KDNameCode", SqlDbType.VarChar,50),
					new SqlParameter("@KPO_KDName", SqlDbType.VarChar,50),
					new SqlParameter("@KPO_KDCode", SqlDbType.VarChar,50),
					new SqlParameter("@KPO_State", SqlDbType.VarChar,50),
					new SqlParameter("@KPW_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@KPW_MTime", SqlDbType.DateTime),
					new SqlParameter("@KPO_CheckTime", SqlDbType.DateTime)};
            parameters[0].Value = model.WareHouseTopic;
            parameters[1].Value = model.WareHouseDateTime;
            parameters[2].Value = model.HouseNo;
            parameters[3].Value = model.WareHouseStaffBranch;
            parameters[4].Value = model.WareHouseStaffDepart;
            parameters[5].Value = model.WareHouseStaffNo;
            parameters[6].Value = model.WareHouseRemarks;
            parameters[7].Value = model.IsShip;
            parameters[8].Value = model.ShipDetials;
            parameters[9].Value = model.WareHouseNo;
            parameters[10].Value = model.KPO_KDNameCode;
            parameters[11].Value = model.KPO_KDName;
            parameters[12].Value = model.KPO_KDCode;
            parameters[13].Value = model.KPO_State;
            parameters[14].Value = model.KPW_Mender;
            parameters[15].Value = model.KPW_MTime;
            parameters[16].Value = model.KPO_CheckTime;
            
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public void UpdateShip(string WareHouseNo, string s_Ship)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Knet_Procure_WareHouseList set ");
            strSql.Append("isShip=@isShip ");
            strSql.Append(" where WareHouseNo=@WareHouseNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@isShip", SqlDbType.NVarChar,50),
					new SqlParameter("@WareHouseNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = s_Ship;
            parameters[1].Value = WareHouseNo;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string WareHouseNo)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@WareHouseNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = WareHouseNo;

            DbHelperSQL.RunProcedure("Proc_Knet_Procure_WareHouseList_Delete", parameters, out rowsAffected);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateQRState(KNet.Model.Knet_Procure_WareHouseList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Knet_Procure_WareHouseList set ");
            strSql.Append("KPO_QRState=@KPO_QRState,");
            strSql.Append("WareHouseDateTime=@WareHouseDateTime,");
            strSql.Append("KPW_CheckPerson=@KPW_CheckPerson");
            strSql.Append(" where WareHouseNo=@WareHouseNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@KPO_QRState", SqlDbType.Int,4),
					new SqlParameter("@WareHouseDateTime", SqlDbType.DateTime),
					new SqlParameter("@KPW_CheckPerson", SqlDbType.NVarChar,50),
					new SqlParameter("@WareHouseNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.KPO_QRState;
            parameters[1].Value = model.WareHouseDateTime;
            parameters[2].Value = model.KPW_CheckPerson;
            parameters[3].Value = model.WareHouseNo;

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
        public bool UpdatePrintState(KNet.Model.Knet_Procure_WareHouseList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Knet_Procure_WareHouseList set ");
            strSql.Append("KPW_PrintNums=@KPW_PrintNums");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@KPW_PrintNums", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.KPW_PrintNums;
            parameters[1].Value = model.ID;

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
        /// 得到一个对象实体
        /// </summary>
        /// 
        /// <summary>
        /// 得到数据
        /// </summary>
        public KNet.Model.Knet_Procure_WareHouseList GetModel(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from Knet_Procure_WareHouseList  ");
            strSql.Append("where ID=@ID  ");
            SqlParameter[] parameters = {
 new SqlParameter("@ID", SqlDbType.VarChar,100)
};
            parameters[0].Value = ID;
            KNet.Model.Knet_Procure_WareHouseList model = new KNet.Model.Knet_Procure_WareHouseList();
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
        public KNet.Model.Knet_Procure_WareHouseList DataRowToModel(DataRow row)
        {
            KNet.Model.Knet_Procure_WareHouseList model = new KNet.Model.Knet_Procure_WareHouseList();
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
                if (row["ID"] != null)
                {
                    model.ID = row["ID"].ToString();
                }
                else
                {
                    model.ID = "";
                }
                if (row["WareHouseNo"] != null)
                {
                    model.WareHouseNo = row["WareHouseNo"].ToString();
                }
                else
                {
                    model.WareHouseNo = "";
                }
                if (row["WareHouseNo"] != null)
                {
                    model.WareHouseNo = row["WareHouseNo"].ToString();
                }
                else
                {
                    model.WareHouseNo = "";
                }
                if (row["WareHouseTopic"] != null)
                {
                    model.WareHouseTopic = row["WareHouseTopic"].ToString();
                }
                else
                {
                    model.WareHouseTopic = "";
                }
                if (row["WareHouseTopic"] != null)
                {
                    model.WareHouseTopic = row["WareHouseTopic"].ToString();
                }
                else
                {
                    model.WareHouseTopic = "";
                }
                if (row["ReceivNo"] != null)
                {
                    model.ReceivNo = row["ReceivNo"].ToString();
                }
                else
                {
                    model.ReceivNo = "";
                }
                if (row["ReceivNo"] != null)
                {
                    model.ReceivNo = row["ReceivNo"].ToString();
                }
                else
                {
                    model.ReceivNo = "";
                }
                if (row["WareHouseDateTime"] != null)
                {
                    try
                    {
                        model.WareHouseDateTime = DateTime.Parse(row["WareHouseDateTime"].ToString());
                    }
                    catch
                    { }
                }
                if (row["SuppNo"] != null)
                {
                    model.SuppNo = row["SuppNo"].ToString();
                }
                else
                {
                    model.SuppNo = "";
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
                if (row["HouseNo"] != null)
                {
                    model.HouseNo = row["HouseNo"].ToString();
                }
                else
                {
                    model.HouseNo = "";
                }
                if (row["WareHouseStaffBranch"] != null)
                {
                    model.WareHouseStaffBranch = row["WareHouseStaffBranch"].ToString();
                }
                else
                {
                    model.WareHouseStaffBranch = "";
                }
                if (row["WareHouseStaffBranch"] != null)
                {
                    model.WareHouseStaffBranch = row["WareHouseStaffBranch"].ToString();
                }
                else
                {
                    model.WareHouseStaffBranch = "";
                }
                if (row["WareHouseStaffDepart"] != null)
                {
                    model.WareHouseStaffDepart = row["WareHouseStaffDepart"].ToString();
                }
                else
                {
                    model.WareHouseStaffDepart = "";
                }
                if (row["WareHouseStaffDepart"] != null)
                {
                    model.WareHouseStaffDepart = row["WareHouseStaffDepart"].ToString();
                }
                else
                {
                    model.WareHouseStaffDepart = "";
                }
                if (row["WareHouseStaffNo"] != null)
                {
                    model.WareHouseStaffNo = row["WareHouseStaffNo"].ToString();
                }
                else
                {
                    model.WareHouseStaffNo = "";
                }
                if (row["WareHouseStaffNo"] != null)
                {
                    model.WareHouseStaffNo = row["WareHouseStaffNo"].ToString();
                }
                else
                {
                    model.WareHouseStaffNo = "";
                }
                if (row["WareHouseCheckStaffNo"] != null)
                {
                    model.WareHouseCheckStaffNo = row["WareHouseCheckStaffNo"].ToString();
                }
                else
                {
                    model.WareHouseCheckStaffNo = "";
                }
                if (row["WareHouseCheckStaffNo"] != null)
                {
                    model.WareHouseCheckStaffNo = row["WareHouseCheckStaffNo"].ToString();
                }
                else
                {
                    model.WareHouseCheckStaffNo = "";
                }
                if (row["WareHouseRemarks"] != null)
                {
                    model.WareHouseRemarks = row["WareHouseRemarks"].ToString();
                }
                else
                {
                    model.WareHouseRemarks = "";
                }
                if (row["WareHouseRemarks"] != null)
                {
                    model.WareHouseRemarks = row["WareHouseRemarks"].ToString();
                }
                else
                {
                    model.WareHouseRemarks = "";
                }

                if (row["WareHouseCheckYN"] != null)
                {
                    model.WareHouseCheckYN = int.Parse(row["WareHouseCheckYN"].ToString());
                }
                else
                {
                    model.WareHouseCheckYN = 0;
                }
                if (row["OrderNo"] != null)
                {
                    model.OrderNo = row["OrderNo"].ToString();
                }
                else
                {
                    model.OrderNo = "";
                }
                if (row["OrderNo"] != null)
                {
                    model.OrderNo = row["OrderNo"].ToString();
                }
                else
                {
                    model.OrderNo = "";
                }
                if (row["IsShip"] != null)
                {
                    model.IsShip = row["IsShip"].ToString();
                }
                else
                {
                    model.IsShip = "";
                }
                if (row["ShipDetials"] != null)
                {
                    model.ShipDetials = row["ShipDetials"].ToString();
                }
                else
                {
                    model.ShipDetials = "";
                }
                if (row["KPO_KDNameCode"] != null)
                {
                    model.KPO_KDNameCode = row["KPO_KDNameCode"].ToString();
                }
                else
                {
                    model.KPO_KDNameCode = "";
                }
                if (row["KPO_KDName"] != null)
                {
                    model.KPO_KDName = row["KPO_KDName"].ToString();
                }
                else
                {
                    model.KPO_KDName = "";
                }
                if (row["KPO_KDCode"] != null)
                {
                    model.KPO_KDCode = row["KPO_KDCode"].ToString();
                }
                else
                {
                    model.KPO_KDCode = "";
                }
                if (row["KPO_State"] != null)
                {
                    model.KPO_State = row["KPO_State"].ToString();
                }
                else
                {
                    model.KPO_State = "";
                }
                if (row["KPO_QRState"] != null)
                {
                    model.KPO_QRState = int.Parse(row["KPO_QRState"].ToString());
                }
                else
                {
                    model.KPO_QRState = 0;
                }
                if (row["KPW_PrintNums"] != null)
                {
                    model.KPW_PrintNums = int.Parse(row["KPW_PrintNums"].ToString());
                }
                else
                {
                    model.KPW_PrintNums = 0;
                }
            }
            return model;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Knet_Procure_WareHouseList GetModelB(string WareHouseNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Knet_Procure_WareHouseList ");
            strSql.Append(" where WareHouseNo=@WareHouseNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@WareHouseNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = WareHouseNo;

            KNet.Model.Knet_Procure_WareHouseList model = new KNet.Model.Knet_Procure_WareHouseList();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["WareHouseNo"] != null && ds.Tables[0].Rows[0]["WareHouseNo"].ToString() != "")
                {
                    model.WareHouseNo = ds.Tables[0].Rows[0]["WareHouseNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["WareHouseTopic"] != null && ds.Tables[0].Rows[0]["WareHouseTopic"].ToString() != "")
                {
                    model.WareHouseTopic = ds.Tables[0].Rows[0]["WareHouseTopic"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ReceivNo"] != null && ds.Tables[0].Rows[0]["ReceivNo"].ToString() != "")
                {
                    model.ReceivNo = ds.Tables[0].Rows[0]["ReceivNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["WareHouseDateTime"] != null && ds.Tables[0].Rows[0]["WareHouseDateTime"].ToString() != "")
                {
                    model.WareHouseDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["WareHouseDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SuppNo"] != null && ds.Tables[0].Rows[0]["SuppNo"].ToString() != "")
                {
                    model.SuppNo = ds.Tables[0].Rows[0]["SuppNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["HouseNo"] != null && ds.Tables[0].Rows[0]["HouseNo"].ToString() != "")
                {
                    model.HouseNo = ds.Tables[0].Rows[0]["HouseNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["WareHouseStaffBranch"] != null && ds.Tables[0].Rows[0]["WareHouseStaffBranch"].ToString() != "")
                {
                    model.WareHouseStaffBranch = ds.Tables[0].Rows[0]["WareHouseStaffBranch"].ToString();
                }
                if (ds.Tables[0].Rows[0]["WareHouseStaffDepart"] != null && ds.Tables[0].Rows[0]["WareHouseStaffDepart"].ToString() != "")
                {
                    model.WareHouseStaffDepart = ds.Tables[0].Rows[0]["WareHouseStaffDepart"].ToString();
                }
                if (ds.Tables[0].Rows[0]["WareHouseStaffNo"] != null && ds.Tables[0].Rows[0]["WareHouseStaffNo"].ToString() != "")
                {
                    model.WareHouseStaffNo = ds.Tables[0].Rows[0]["WareHouseStaffNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["WareHouseCheckStaffNo"] != null && ds.Tables[0].Rows[0]["WareHouseCheckStaffNo"].ToString() != "")
                {
                    model.WareHouseCheckStaffNo = ds.Tables[0].Rows[0]["WareHouseCheckStaffNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["WareHouseRemarks"] != null && ds.Tables[0].Rows[0]["WareHouseRemarks"].ToString() != "")
                {
                    model.WareHouseRemarks = ds.Tables[0].Rows[0]["WareHouseRemarks"].ToString();
                }
                if (ds.Tables[0].Rows[0]["WareHouseCheckYN"] != null && ds.Tables[0].Rows[0]["WareHouseCheckYN"].ToString() != "")
                {
                    model.WareHouseCheckYN = int.Parse(ds.Tables[0].Rows[0]["WareHouseCheckYN"].ToString());
                }
                else
                {
                    model.WareHouseCheckYN = 0;
                }
                if (ds.Tables[0].Rows[0]["OrderNo"] != null && ds.Tables[0].Rows[0]["OrderNo"].ToString() != "")
                {
                    model.OrderNo = ds.Tables[0].Rows[0]["OrderNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["IsShip"] != null && ds.Tables[0].Rows[0]["IsShip"].ToString() != "")
                {
                    model.IsShip = ds.Tables[0].Rows[0]["IsShip"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ShipDetials"] != null && ds.Tables[0].Rows[0]["ShipDetials"].ToString() != "")
                {
                    model.ShipDetials = ds.Tables[0].Rows[0]["ShipDetials"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPO_KDNameCode"] != null && ds.Tables[0].Rows[0]["KPO_KDNameCode"].ToString() != "")
                {
                    model.KPO_KDNameCode = ds.Tables[0].Rows[0]["KPO_KDNameCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPO_KDName"] != null && ds.Tables[0].Rows[0]["KPO_KDName"].ToString() != "")
                {
                    model.KPO_KDName = ds.Tables[0].Rows[0]["KPO_KDName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPO_KDCode"] != null && ds.Tables[0].Rows[0]["KPO_KDCode"].ToString() != "")
                {
                    model.KPO_KDCode = ds.Tables[0].Rows[0]["KPO_KDCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPO_State"] != null && ds.Tables[0].Rows[0]["KPO_State"].ToString() != "")
                {
                    model.KPO_State = ds.Tables[0].Rows[0]["KPO_State"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPO_QRState"] != null && ds.Tables[0].Rows[0]["KPO_QRState"].ToString() != "")
                {
                    model.KPO_QRState = int.Parse(ds.Tables[0].Rows[0]["KPO_QRState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KPO_CheckTime"] != null && ds.Tables[0].Rows[0]["KPO_CheckTime"].ToString() != "")
                {
                    model.KPO_CheckTime = DateTime.Parse(ds.Tables[0].Rows[0]["KPO_CheckTime"].ToString());
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
            strSql.Append("select case when Knet_Procure_WareHouseList.KPO_KDName='--请选择--' then '' else Knet_Procure_WareHouseList.KPO_KDName end as KPO_KDName,Knet_Procure_OrdersList.OrderType,Knet_Procure_WareHouseList.* ");
            strSql.Append(" FROM Knet_Procure_WareHouseList left join Knet_Procure_OrdersList on Knet_Procure_OrdersList.OrderNo=ReceivNo");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListByDetails(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.*,b.ID as DetailsID,b.ProductsBarCode,b.WareHouseAmount,b.WareHouseUnitPrice,b.WareHouseTotalNet,b.WareHouseBAmount,isnull(b.KWP_NoTaxMoney,0) KWP_NoTaxMoney,b.KWP_NoTaxLag ");
            strSql.Append(" FROM Knet_Procure_WareHouseList a left join Knet_Procure_WareHouseList_Details b on a.WareHouseNO=b.WareHouseNO");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }


        #endregion  成员方法
    }
}

