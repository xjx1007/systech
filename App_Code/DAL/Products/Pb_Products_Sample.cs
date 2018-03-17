using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:Pb_Products_Sample
    /// </summary>
    public partial class Pb_Products_Sample
    {
        public Pb_Products_Sample()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PPS_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Pb_Products_Sample");
            strSql.Append(" where PPS_ID=@PPS_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PPS_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = PPS_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Pb_Products_Sample model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Pb_Products_Sample(");
            strSql.Append("PPS_ID,PPS_Name,PPS_Stime,PPS_Needtime,PPS_CustomerValue,PPS_LinkMan,PPS_DutyPeson,PPS_Dept,PPS_DemoPicture,PPS_Picture,PPS_Requirement,PPS_Remarks,PPS_CTime,PPS_Creator,PPS_Shell,PPS_Appearance,PPS_Resin,PPS_ResinMaterial,PPS_Chip,PPS_Number,PPS_Use,PPS_Type,PPS_Code,PPS_ProductsBarCode,PPS_DealDetails)");
            strSql.Append(" values (");
            strSql.Append("@PPS_ID,@PPS_Name,@PPS_Stime,@PPS_Needtime,@PPS_CustomerValue,@PPS_LinkMan,@PPS_DutyPeson,@PPS_Dept,@PPS_DemoPicture,@PPS_Picture,@PPS_Requirement,@PPS_Remarks,@PPS_CTime,@PPS_Creator,@PPS_Shell,@PPS_Appearance,@PPS_Resin,@PPS_ResinMaterial,@PPS_Chip,@PPS_Number,@PPS_Use,@PPS_Type,@PPS_Code,@PPS_ProductsBarCode,@PPS_DealDetails)");
            SqlParameter[] parameters = {
					new SqlParameter("@PPS_ID", SqlDbType.VarChar,50),
					new SqlParameter("@PPS_Name", SqlDbType.VarChar,50),
					new SqlParameter("@PPS_Stime", SqlDbType.DateTime),
					new SqlParameter("@PPS_Needtime", SqlDbType.DateTime),
					new SqlParameter("@PPS_CustomerValue", SqlDbType.VarChar,50),
					new SqlParameter("@PPS_LinkMan", SqlDbType.VarChar,50),
					new SqlParameter("@PPS_DutyPeson", SqlDbType.VarChar,50),
					new SqlParameter("@PPS_Dept", SqlDbType.VarChar,50),
					new SqlParameter("@PPS_DemoPicture", SqlDbType.VarChar,50),
					new SqlParameter("@PPS_Picture", SqlDbType.VarChar,50),
					new SqlParameter("@PPS_Requirement", SqlDbType.VarChar,3000),
					new SqlParameter("@PPS_Remarks", SqlDbType.VarChar,500),
					new SqlParameter("@PPS_CTime", SqlDbType.DateTime),
					new SqlParameter("@PPS_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@PPS_Shell", SqlDbType.VarChar,150),
					new SqlParameter("@PPS_Appearance", SqlDbType.VarChar,150),
					new SqlParameter("@PPS_Resin", SqlDbType.VarChar,150),
					new SqlParameter("@PPS_ResinMaterial", SqlDbType.VarChar,150),
					new SqlParameter("@PPS_Chip", SqlDbType.VarChar,150),
					new SqlParameter("@PPS_Number", SqlDbType.Int),
					new SqlParameter("@PPS_Use", SqlDbType.VarChar,150),
					new SqlParameter("@PPS_Type", SqlDbType.VarChar,50),
					new SqlParameter("@PPS_Code", SqlDbType.VarChar,50),
					new SqlParameter("@PPS_ProductsBarCode", SqlDbType.VarChar,50),
					new SqlParameter("@PPS_DealDetails", SqlDbType.VarChar,250),
                    
                    
                                        };
            parameters[0].Value = model.PPS_ID;
            parameters[1].Value = model.PPS_Name;
            parameters[2].Value = model.PPS_Stime;
            parameters[3].Value = model.PPS_Needtime;
            parameters[4].Value = model.PPS_CustomerValue;
            parameters[5].Value = model.PPS_LinkMan;
            parameters[6].Value = model.PPS_DutyPeson;
            parameters[7].Value = model.PPS_Dept;
            parameters[8].Value = model.PPS_DemoPicture;
            parameters[9].Value = model.PPS_Picture;
            parameters[10].Value = model.PPS_Requirement;
            parameters[11].Value = model.PPS_Remarks;
            parameters[12].Value = model.PPS_CTime;
            parameters[13].Value = model.PPS_Creator;
            parameters[14].Value = model.PPS_Shell;
            parameters[15].Value = model.PPS_Appearance;
            parameters[16].Value = model.PPS_Resin;
            parameters[17].Value = model.PPS_ResinMaterial;
            parameters[18].Value = model.PPS_Chip;
            parameters[19].Value = model.PPS_Number;
            parameters[20].Value = model.PPS_Use;
            parameters[21].Value = model.PPS_Type;
            parameters[22].Value = model.PPS_Code;
            parameters[23].Value = model.PPS_ProductsBarCode;
            parameters[24].Value = model.PPS_DealDetails;
            
            
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Pb_Products_Sample model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Pb_Products_Sample set ");
            strSql.Append("PPS_Name=@PPS_Name,");
            strSql.Append("PPS_Stime=@PPS_Stime,");
            strSql.Append("PPS_Needtime=@PPS_Needtime,");
            strSql.Append("PPS_CustomerValue=@PPS_CustomerValue,");
            strSql.Append("PPS_LinkMan=@PPS_LinkMan,");
            strSql.Append("PPS_DutyPeson=@PPS_DutyPeson,");
            strSql.Append("PPS_Dept=@PPS_Dept,");
            strSql.Append("PPS_DemoPicture=@PPS_DemoPicture,");
            strSql.Append("PPS_Picture=@PPS_Picture,");
            strSql.Append("PPS_Requirement=@PPS_Requirement,");
            strSql.Append("PPS_Remarks=@PPS_Remarks,");
            strSql.Append("PPS_MTime=@PPS_MTime,");
            strSql.Append("PPS_Mender=@PPS_Mender,");
            strSql.Append("PPS_Shell=@PPS_Shell,");
            strSql.Append("PPS_Appearance=@PPS_Appearance,");
            strSql.Append("PPS_Resin=@PPS_Resin,");
            strSql.Append("PPS_ResinMaterial=@PPS_ResinMaterial,");
            strSql.Append("PPS_Chip=@PPS_Chip,");
            strSql.Append("PPS_Number=@PPS_Number,");
            strSql.Append("PPS_Type=@PPS_Type,");
            strSql.Append("PPS_Use=@PPS_Use,");
            strSql.Append("PPS_DealDetails=@PPS_DealDetails,");
            
            strSql.Append("PPS_ProductsBarCode=@PPS_ProductsBarCode");
            
            strSql.Append(" where PPS_ID=@PPS_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PPS_Name", SqlDbType.VarChar,50),
					new SqlParameter("@PPS_Stime", SqlDbType.DateTime),
					new SqlParameter("@PPS_Needtime", SqlDbType.DateTime),
					new SqlParameter("@PPS_CustomerValue", SqlDbType.VarChar,50),
					new SqlParameter("@PPS_LinkMan", SqlDbType.VarChar,50),
					new SqlParameter("@PPS_DutyPeson", SqlDbType.VarChar,50),
					new SqlParameter("@PPS_Dept", SqlDbType.VarChar,50),
					new SqlParameter("@PPS_DemoPicture", SqlDbType.VarChar,50),
					new SqlParameter("@PPS_Picture", SqlDbType.VarChar,50),
					new SqlParameter("@PPS_Requirement", SqlDbType.VarChar,3000),
					new SqlParameter("@PPS_Remarks", SqlDbType.VarChar,500),
					new SqlParameter("@PPS_MTime", SqlDbType.DateTime),
					new SqlParameter("@PPS_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@PPS_Shell", SqlDbType.VarChar,150),
					new SqlParameter("@PPS_Appearance", SqlDbType.VarChar,150),
					new SqlParameter("@PPS_Resin", SqlDbType.VarChar,150),
					new SqlParameter("@PPS_ResinMaterial", SqlDbType.VarChar,150),
					new SqlParameter("@PPS_Chip", SqlDbType.VarChar,150),
					new SqlParameter("@PPS_Number", SqlDbType.Int),
					new SqlParameter("@PPS_Type", SqlDbType.VarChar,50),
					new SqlParameter("@PPS_Use", SqlDbType.VarChar,150),
					new SqlParameter("@PPS_DealDetails", SqlDbType.VarChar,250),
                    
					new SqlParameter("@PPS_ProductsBarCode", SqlDbType.VarChar,50),
                    
					new SqlParameter("@PPS_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.PPS_Name;
            parameters[1].Value = model.PPS_Stime;
            parameters[2].Value = model.PPS_Needtime;
            parameters[3].Value = model.PPS_CustomerValue;
            parameters[4].Value = model.PPS_LinkMan;
            parameters[5].Value = model.PPS_DutyPeson;
            parameters[6].Value = model.PPS_Dept;
            parameters[7].Value = model.PPS_DemoPicture;
            parameters[8].Value = model.PPS_Picture;
            parameters[9].Value = model.PPS_Requirement;
            parameters[10].Value = model.PPS_Remarks;
            parameters[11].Value = model.PPS_MTime;
            parameters[12].Value = model.PPS_Mender;
            parameters[13].Value = model.PPS_Shell;
            parameters[14].Value = model.PPS_Appearance;
            parameters[15].Value = model.PPS_Resin;
            parameters[16].Value = model.PPS_ResinMaterial;
            parameters[17].Value = model.PPS_Chip;
            parameters[18].Value = model.PPS_Number;
            parameters[19].Value = model.PPS_Type;
            parameters[20].Value = model.PPS_Use;

            parameters[21].Value = model.PPS_DealDetails;
            parameters[22].Value = model.PPS_ProductsBarCode;
            
            parameters[23].Value = model.PPS_ID;


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
        public bool UpdateDept(KNet.Model.Pb_Products_Sample model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Pb_Products_Sample set ");
            strSql.Append("PPS_Dept=@PPS_Dept ");
            strSql.Append(" where PPS_ID=@PPS_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PPS_Dept", SqlDbType.VarChar,50),
					new SqlParameter("@PPS_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.PPS_Dept;
            parameters[1].Value = model.PPS_ID;

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
        public bool Delete(string PPS_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Pb_Products_Sample ");
            strSql.Append(" where PPS_ID=@PPS_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PPS_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = PPS_ID;

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
        public bool DeleteList(string PPS_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Pb_Products_Sample ");
            strSql.Append(" where PPS_ID in (" + PPS_IDlist + ")  ");
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
        public KNet.Model.Pb_Products_Sample GetModel(string PPS_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Pb_Products_Sample ");
            strSql.Append(" where PPS_ID=@PPS_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PPS_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = PPS_ID;

            KNet.Model.Pb_Products_Sample model = new KNet.Model.Pb_Products_Sample();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PPS_ID"] != null && ds.Tables[0].Rows[0]["PPS_ID"].ToString() != "")
                {
                    model.PPS_ID = ds.Tables[0].Rows[0]["PPS_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PPS_Code"] != null && ds.Tables[0].Rows[0]["PPS_Code"].ToString() != "")
                {
                    model.PPS_Code = ds.Tables[0].Rows[0]["PPS_Code"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PPS_Name"] != null && ds.Tables[0].Rows[0]["PPS_Name"].ToString() != "")
                {
                    model.PPS_Name = ds.Tables[0].Rows[0]["PPS_Name"].ToString();
                }
                else
                {
                    model.PPS_Name = "";
                }
                if (ds.Tables[0].Rows[0]["PPS_Stime"] != null && ds.Tables[0].Rows[0]["PPS_Stime"].ToString() != "")
                {
                    model.PPS_Stime = DateTime.Parse(ds.Tables[0].Rows[0]["PPS_Stime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PPS_Needtime"] != null && ds.Tables[0].Rows[0]["PPS_Needtime"].ToString() != "")
                {
                    model.PPS_Needtime = DateTime.Parse(ds.Tables[0].Rows[0]["PPS_Needtime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PPS_CustomerValue"] != null && ds.Tables[0].Rows[0]["PPS_CustomerValue"].ToString() != "")
                {
                    model.PPS_CustomerValue = ds.Tables[0].Rows[0]["PPS_CustomerValue"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PPS_LinkMan"] != null && ds.Tables[0].Rows[0]["PPS_LinkMan"].ToString() != "")
                {
                    model.PPS_LinkMan = ds.Tables[0].Rows[0]["PPS_LinkMan"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PPS_DutyPeson"] != null && ds.Tables[0].Rows[0]["PPS_DutyPeson"].ToString() != "")
                {
                    model.PPS_DutyPeson = ds.Tables[0].Rows[0]["PPS_DutyPeson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PPS_Dept"] != null && ds.Tables[0].Rows[0]["PPS_Dept"].ToString() != "")
                {
                    model.PPS_Dept = ds.Tables[0].Rows[0]["PPS_Dept"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PPS_DemoPicture"] != null && ds.Tables[0].Rows[0]["PPS_DemoPicture"].ToString() != "")
                {
                    model.PPS_DemoPicture = ds.Tables[0].Rows[0]["PPS_DemoPicture"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PPS_Picture"] != null && ds.Tables[0].Rows[0]["PPS_Picture"].ToString() != "")
                {
                    model.PPS_Picture = ds.Tables[0].Rows[0]["PPS_Picture"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PPS_Requirement"] != null && ds.Tables[0].Rows[0]["PPS_Requirement"].ToString() != "")
                {
                    model.PPS_Requirement = ds.Tables[0].Rows[0]["PPS_Requirement"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PPS_Remarks"] != null && ds.Tables[0].Rows[0]["PPS_Remarks"].ToString() != "")
                {
                    model.PPS_Remarks = ds.Tables[0].Rows[0]["PPS_Remarks"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PPS_CTime"] != null && ds.Tables[0].Rows[0]["PPS_CTime"].ToString() != "")
                {
                    model.PPS_CTime = DateTime.Parse(ds.Tables[0].Rows[0]["PPS_CTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PPS_Creator"] != null && ds.Tables[0].Rows[0]["PPS_Creator"].ToString() != "")
                {
                    model.PPS_Creator = ds.Tables[0].Rows[0]["PPS_Creator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PPS_MTime"] != null && ds.Tables[0].Rows[0]["PPS_MTime"].ToString() != "")
                {
                    model.PPS_MTime = DateTime.Parse(ds.Tables[0].Rows[0]["PPS_MTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PPS_Mender"] != null && ds.Tables[0].Rows[0]["PPS_Mender"].ToString() != "")
                {
                    model.PPS_Mender = ds.Tables[0].Rows[0]["PPS_Mender"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PPS_Del"] != null && ds.Tables[0].Rows[0]["PPS_Del"].ToString() != "")
                {
                    model.PPS_Del = int.Parse(ds.Tables[0].Rows[0]["PPS_Del"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PPS_Shell"] != null && ds.Tables[0].Rows[0]["PPS_Shell"].ToString() != "")
                {
                    model.PPS_Shell = ds.Tables[0].Rows[0]["PPS_Shell"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PPS_Appearance"] != null && ds.Tables[0].Rows[0]["PPS_Appearance"].ToString() != "")
                {
                    model.PPS_Appearance = ds.Tables[0].Rows[0]["PPS_Appearance"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PPS_Resin"] != null && ds.Tables[0].Rows[0]["PPS_Resin"].ToString() != "")
                {
                    model.PPS_Resin = ds.Tables[0].Rows[0]["PPS_Resin"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PPS_ResinMaterial"] != null && ds.Tables[0].Rows[0]["PPS_ResinMaterial"].ToString() != "")
                {
                    model.PPS_ResinMaterial = ds.Tables[0].Rows[0]["PPS_ResinMaterial"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PPS_Chip"] != null && ds.Tables[0].Rows[0]["PPS_Chip"].ToString() != "")
                {
                    model.PPS_Chip = ds.Tables[0].Rows[0]["PPS_Chip"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PPS_Number"] != null && ds.Tables[0].Rows[0]["PPS_Number"].ToString() != "")
                {
                    model.PPS_Number = int.Parse(ds.Tables[0].Rows[0]["PPS_Number"].ToString());
                }
                else
                {
                    model.PPS_Number = 1;
                }
                if (ds.Tables[0].Rows[0]["PPS_Use"] != null && ds.Tables[0].Rows[0]["PPS_Use"].ToString() != "")
                {
                    model.PPS_Use = ds.Tables[0].Rows[0]["PPS_Use"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PPS_ProductsBarCode"] != null && ds.Tables[0].Rows[0]["PPS_ProductsBarCode"].ToString() != "")
                {
                    model.PPS_ProductsBarCode = ds.Tables[0].Rows[0]["PPS_ProductsBarCode"].ToString();
                }
                
                if (ds.Tables[0].Rows[0]["PPS_Type"] != null && ds.Tables[0].Rows[0]["PPS_Type"].ToString() != "")
                {
                    model.PPS_Type = ds.Tables[0].Rows[0]["PPS_Type"].ToString();
                }


                if (ds.Tables[0].Rows[0]["PPS_DealDetails"] != null && ds.Tables[0].Rows[0]["PPS_DealDetails"].ToString() != "")
                {
                    model.PPS_DealDetails = ds.Tables[0].Rows[0]["PPS_DealDetails"].ToString();
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
            strSql.Append(" FROM Pb_Products_Sample ");
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
            strSql.Append(" FROM Pb_Products_Sample ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  Method
    }
}

