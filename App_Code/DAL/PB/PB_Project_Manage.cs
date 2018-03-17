using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:Pb_Project_Manage
    /// </summary>
    public partial class Pb_Project_Manage
    {
        public Pb_Project_Manage()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PPM_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Pb_Project_Manage");
            strSql.Append(" where PPM_ID=@PPM_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PPM_ID", SqlDbType.VarChar,50)			};
            parameters[0].Value = PPM_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(KNet.Model.Pb_Project_Manage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Pb_Project_Manage(");
            strSql.Append("PPM_ID,PPM_Code,PPM_Products,PPM_CustomerValue,PPM_Stime,PPM_ProductsType,PPM_Model,PPM_SoftNeed,PPM_KeyCustom,PPM_Standards,PPM_OtherRemarks,PPM_Shape,PPM_Lamp,PPM_Led,PPM_Upper,PPM_Lower,PPM_Battery,PPM_Conductive,PPM_KeyNumber,PPM_Pot,PPM_Backlight,PPM_Description,PPM_HaveBattery,PPM_Packing,PPM_ProductsDescription,PPM_Warranty,PPM_Price,PPM_NeedTime,PPM_Neednumber,PPM_Application,PPM_Remaks,PPM_Del,PPM_CTime,PPM_Creator,PPM_MTime,PPM_Mender)");
            strSql.Append(" values (");
            strSql.Append("@PPM_ID,@PPM_Code,@PPM_Products,@PPM_CustomerValue,@PPM_Stime,@PPM_ProductsType,@PPM_Model,@PPM_SoftNeed,@PPM_KeyCustom,@PPM_Standards,@PPM_OtherRemarks,@PPM_Shape,@PPM_Lamp,@PPM_Led,@PPM_Upper,@PPM_Lower,@PPM_Battery,@PPM_Conductive,@PPM_KeyNumber,@PPM_Pot,@PPM_Backlight,@PPM_Description,@PPM_HaveBattery,@PPM_Packing,@PPM_ProductsDescription,@PPM_Warranty,@PPM_Price,@PPM_NeedTime,@PPM_Neednumber,@PPM_Application,@PPM_Remaks,@PPM_Del,@PPM_CTime,@PPM_Creator,@PPM_MTime,@PPM_Mender)");
            SqlParameter[] parameters = {
					new SqlParameter("@PPM_ID", SqlDbType.VarChar,50),
					new SqlParameter("@PPM_Code", SqlDbType.VarChar,50),
					new SqlParameter("@PPM_Products", SqlDbType.VarChar,150),
					new SqlParameter("@PPM_CustomerValue", SqlDbType.VarChar,100),
					new SqlParameter("@PPM_Stime", SqlDbType.DateTime),
					new SqlParameter("@PPM_ProductsType", SqlDbType.VarChar,100),
					new SqlParameter("@PPM_Model", SqlDbType.VarChar,100),
					new SqlParameter("@PPM_SoftNeed", SqlDbType.VarChar,100),
					new SqlParameter("@PPM_KeyCustom", SqlDbType.VarChar,100),
					new SqlParameter("@PPM_Standards", SqlDbType.VarChar,100),
					new SqlParameter("@PPM_OtherRemarks", SqlDbType.VarChar,500),
					new SqlParameter("@PPM_Shape", SqlDbType.VarChar,100),
					new SqlParameter("@PPM_Lamp", SqlDbType.VarChar,100),
					new SqlParameter("@PPM_Led", SqlDbType.VarChar,100),
					new SqlParameter("@PPM_Upper", SqlDbType.VarChar,100),
					new SqlParameter("@PPM_Lower", SqlDbType.VarChar,100),
					new SqlParameter("@PPM_Battery", SqlDbType.VarChar,100),
					new SqlParameter("@PPM_Conductive", SqlDbType.VarChar,100),
					new SqlParameter("@PPM_KeyNumber", SqlDbType.VarChar,100),
					new SqlParameter("@PPM_Pot", SqlDbType.VarChar,100),
					new SqlParameter("@PPM_Backlight", SqlDbType.VarChar,100),
					new SqlParameter("@PPM_Description", SqlDbType.VarChar,500),
					new SqlParameter("@PPM_HaveBattery", SqlDbType.VarChar,50),
					new SqlParameter("@PPM_Packing", SqlDbType.VarChar,200),
					new SqlParameter("@PPM_ProductsDescription", SqlDbType.VarChar,200),
					new SqlParameter("@PPM_Warranty", SqlDbType.VarChar,200),
					new SqlParameter("@PPM_Price", SqlDbType.VarChar,100),
					new SqlParameter("@PPM_NeedTime", SqlDbType.VarChar,100),
					new SqlParameter("@PPM_Neednumber", SqlDbType.VarChar,100),
					new SqlParameter("@PPM_Application", SqlDbType.VarChar,150),
					new SqlParameter("@PPM_Remaks", SqlDbType.VarChar,500),
					new SqlParameter("@PPM_Del", SqlDbType.Int,4),
					new SqlParameter("@PPM_CTime", SqlDbType.DateTime),
					new SqlParameter("@PPM_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@PPM_MTime", SqlDbType.DateTime),
					new SqlParameter("@PPM_Mender", SqlDbType.VarChar,50)};
            parameters[0].Value = model.PPM_ID;
            parameters[1].Value = model.PPM_Code;
            parameters[2].Value = model.PPM_Products;
            parameters[3].Value = model.PPM_CustomerValue;
            parameters[4].Value = model.PPM_Stime;
            parameters[5].Value = model.PPM_ProductsType;
            parameters[6].Value = model.PPM_Model;
            parameters[7].Value = model.PPM_SoftNeed;
            parameters[8].Value = model.PPM_KeyCustom;
            parameters[9].Value = model.PPM_Standards;
            parameters[10].Value = model.PPM_OtherRemarks;
            parameters[11].Value = model.PPM_Shape;
            parameters[12].Value = model.PPM_Lamp;
            parameters[13].Value = model.PPM_Led;
            parameters[14].Value = model.PPM_Upper;
            parameters[15].Value = model.PPM_Lower;
            parameters[16].Value = model.PPM_Battery;
            parameters[17].Value = model.PPM_Conductive;
            parameters[18].Value = model.PPM_KeyNumber;
            parameters[19].Value = model.PPM_Pot;
            parameters[20].Value = model.PPM_Backlight;
            parameters[21].Value = model.PPM_Description;
            parameters[22].Value = model.PPM_HaveBattery;
            parameters[23].Value = model.PPM_Packing;
            parameters[24].Value = model.PPM_ProductsDescription;
            parameters[25].Value = model.PPM_Warranty;
            parameters[26].Value = model.PPM_Price;
            parameters[27].Value = model.PPM_NeedTime;
            parameters[28].Value = model.PPM_Neednumber;
            parameters[29].Value = model.PPM_Application;
            parameters[30].Value = model.PPM_Remaks;
            parameters[31].Value = model.PPM_Del;
            parameters[32].Value = model.PPM_CTime;
            parameters[33].Value = model.PPM_Creator;
            parameters[34].Value = model.PPM_MTime;
            parameters[35].Value = model.PPM_Mender;

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
        public bool Update(KNet.Model.Pb_Project_Manage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Pb_Project_Manage set ");
            strSql.Append("PPM_Code=@PPM_Code,");
            strSql.Append("PPM_Products=@PPM_Products,");
            strSql.Append("PPM_CustomerValue=@PPM_CustomerValue,");
            strSql.Append("PPM_Stime=@PPM_Stime,");
            strSql.Append("PPM_ProductsType=@PPM_ProductsType,");
            strSql.Append("PPM_Model=@PPM_Model,");
            strSql.Append("PPM_SoftNeed=@PPM_SoftNeed,");
            strSql.Append("PPM_KeyCustom=@PPM_KeyCustom,");
            strSql.Append("PPM_Standards=@PPM_Standards,");
            strSql.Append("PPM_OtherRemarks=@PPM_OtherRemarks,");
            strSql.Append("PPM_Shape=@PPM_Shape,");
            strSql.Append("PPM_Lamp=@PPM_Lamp,");
            strSql.Append("PPM_Led=@PPM_Led,");
            strSql.Append("PPM_Upper=@PPM_Upper,");
            strSql.Append("PPM_Lower=@PPM_Lower,");
            strSql.Append("PPM_Battery=@PPM_Battery,");
            strSql.Append("PPM_Conductive=@PPM_Conductive,");
            strSql.Append("PPM_KeyNumber=@PPM_KeyNumber,");
            strSql.Append("PPM_Pot=@PPM_Pot,");
            strSql.Append("PPM_Backlight=@PPM_Backlight,");
            strSql.Append("PPM_Description=@PPM_Description,");
            strSql.Append("PPM_HaveBattery=@PPM_HaveBattery,");
            strSql.Append("PPM_Packing=@PPM_Packing,");
            strSql.Append("PPM_ProductsDescription=@PPM_ProductsDescription,");
            strSql.Append("PPM_Warranty=@PPM_Warranty,");
            strSql.Append("PPM_Price=@PPM_Price,");
            strSql.Append("PPM_NeedTime=@PPM_NeedTime,");
            strSql.Append("PPM_Neednumber=@PPM_Neednumber,");
            strSql.Append("PPM_Application=@PPM_Application,");
            strSql.Append("PPM_Remaks=@PPM_Remaks,");
            strSql.Append("PPM_Del=@PPM_Del,");
            strSql.Append("PPM_CTime=@PPM_CTime,");
            strSql.Append("PPM_Creator=@PPM_Creator,");
            strSql.Append("PPM_MTime=@PPM_MTime,");
            strSql.Append("PPM_Mender=@PPM_Mender");
            strSql.Append(" where PPM_ID=@PPM_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PPM_Code", SqlDbType.VarChar,50),
					new SqlParameter("@PPM_Products", SqlDbType.VarChar,150),
					new SqlParameter("@PPM_CustomerValue", SqlDbType.VarChar,100),
					new SqlParameter("@PPM_Stime", SqlDbType.DateTime),
					new SqlParameter("@PPM_ProductsType", SqlDbType.VarChar,100),
					new SqlParameter("@PPM_Model", SqlDbType.VarChar,100),
					new SqlParameter("@PPM_SoftNeed", SqlDbType.VarChar,100),
					new SqlParameter("@PPM_KeyCustom", SqlDbType.VarChar,100),
					new SqlParameter("@PPM_Standards", SqlDbType.VarChar,100),
					new SqlParameter("@PPM_OtherRemarks", SqlDbType.VarChar,500),
					new SqlParameter("@PPM_Shape", SqlDbType.VarChar,100),
					new SqlParameter("@PPM_Lamp", SqlDbType.VarChar,100),
					new SqlParameter("@PPM_Led", SqlDbType.VarChar,100),
					new SqlParameter("@PPM_Upper", SqlDbType.VarChar,100),
					new SqlParameter("@PPM_Lower", SqlDbType.VarChar,100),
					new SqlParameter("@PPM_Battery", SqlDbType.VarChar,100),
					new SqlParameter("@PPM_Conductive", SqlDbType.VarChar,100),
					new SqlParameter("@PPM_KeyNumber", SqlDbType.VarChar,100),
					new SqlParameter("@PPM_Pot", SqlDbType.VarChar,100),
					new SqlParameter("@PPM_Backlight", SqlDbType.VarChar,100),
					new SqlParameter("@PPM_Description", SqlDbType.VarChar,500),
					new SqlParameter("@PPM_HaveBattery", SqlDbType.VarChar,50),
					new SqlParameter("@PPM_Packing", SqlDbType.VarChar,200),
					new SqlParameter("@PPM_ProductsDescription", SqlDbType.VarChar,200),
					new SqlParameter("@PPM_Warranty", SqlDbType.VarChar,200),
					new SqlParameter("@PPM_Price", SqlDbType.VarChar,100),
					new SqlParameter("@PPM_NeedTime", SqlDbType.VarChar,100),
					new SqlParameter("@PPM_Neednumber", SqlDbType.VarChar,100),
					new SqlParameter("@PPM_Application", SqlDbType.VarChar,150),
					new SqlParameter("@PPM_Remaks", SqlDbType.VarChar,500),
					new SqlParameter("@PPM_Del", SqlDbType.Int,4),
					new SqlParameter("@PPM_CTime", SqlDbType.DateTime),
					new SqlParameter("@PPM_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@PPM_MTime", SqlDbType.DateTime),
					new SqlParameter("@PPM_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@PPM_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.PPM_Code;
            parameters[1].Value = model.PPM_Products;
            parameters[2].Value = model.PPM_CustomerValue;
            parameters[3].Value = model.PPM_Stime;
            parameters[4].Value = model.PPM_ProductsType;
            parameters[5].Value = model.PPM_Model;
            parameters[6].Value = model.PPM_SoftNeed;
            parameters[7].Value = model.PPM_KeyCustom;
            parameters[8].Value = model.PPM_Standards;
            parameters[9].Value = model.PPM_OtherRemarks;
            parameters[10].Value = model.PPM_Shape;
            parameters[11].Value = model.PPM_Lamp;
            parameters[12].Value = model.PPM_Led;
            parameters[13].Value = model.PPM_Upper;
            parameters[14].Value = model.PPM_Lower;
            parameters[15].Value = model.PPM_Battery;
            parameters[16].Value = model.PPM_Conductive;
            parameters[17].Value = model.PPM_KeyNumber;
            parameters[18].Value = model.PPM_Pot;
            parameters[19].Value = model.PPM_Backlight;
            parameters[20].Value = model.PPM_Description;
            parameters[21].Value = model.PPM_HaveBattery;
            parameters[22].Value = model.PPM_Packing;
            parameters[23].Value = model.PPM_ProductsDescription;
            parameters[24].Value = model.PPM_Warranty;
            parameters[25].Value = model.PPM_Price;
            parameters[26].Value = model.PPM_NeedTime;
            parameters[27].Value = model.PPM_Neednumber;
            parameters[28].Value = model.PPM_Application;
            parameters[29].Value = model.PPM_Remaks;
            parameters[30].Value = model.PPM_Del;
            parameters[31].Value = model.PPM_CTime;
            parameters[32].Value = model.PPM_Creator;
            parameters[33].Value = model.PPM_MTime;
            parameters[34].Value = model.PPM_Mender;
            parameters[35].Value = model.PPM_ID;

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
        public bool Delete(string PPM_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Pb_Project_Manage ");
            strSql.Append(" where PPM_ID=@PPM_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PPM_ID", SqlDbType.VarChar,50)			};
            parameters[0].Value = PPM_ID;

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
        public bool DeleteList(string PPM_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Pb_Project_Manage ");
            strSql.Append(" where PPM_ID in (" + PPM_IDlist + ")  ");
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
        public KNet.Model.Pb_Project_Manage GetModel(string PPM_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 PPM_ID,PPM_Code,PPM_Products,PPM_CustomerValue,PPM_Stime,PPM_ProductsType,PPM_Model,PPM_SoftNeed,PPM_KeyCustom,PPM_Standards,PPM_OtherRemarks,PPM_Shape,PPM_Lamp,PPM_Led,PPM_Upper,PPM_Lower,PPM_Battery,PPM_Conductive,PPM_KeyNumber,PPM_Pot,PPM_Backlight,PPM_Description,PPM_HaveBattery,PPM_Packing,PPM_ProductsDescription,PPM_Warranty,PPM_Price,PPM_NeedTime,PPM_Neednumber,PPM_Application,PPM_Remaks,PPM_Del,PPM_CTime,PPM_Creator,PPM_MTime,PPM_Mender from Pb_Project_Manage ");
            strSql.Append(" where PPM_ID=@PPM_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PPM_ID", SqlDbType.VarChar,50)			};
            parameters[0].Value = PPM_ID;

            KNet.Model.Pb_Project_Manage model = new KNet.Model.Pb_Project_Manage();
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
        public KNet.Model.Pb_Project_Manage DataRowToModel(DataRow row)
        {
            KNet.Model.Pb_Project_Manage model = new KNet.Model.Pb_Project_Manage();
            if (row != null)
            {
                if (row["PPM_ID"] != null)
                {
                    model.PPM_ID = row["PPM_ID"].ToString();
                }
                if (row["PPM_Code"] != null)
                {
                    model.PPM_Code = row["PPM_Code"].ToString();
                }
                if (row["PPM_Products"] != null)
                {
                    model.PPM_Products = row["PPM_Products"].ToString();
                }
                if (row["PPM_CustomerValue"] != null)
                {
                    model.PPM_CustomerValue = row["PPM_CustomerValue"].ToString();
                }
                if (row["PPM_Stime"] != null && row["PPM_Stime"].ToString() != "")
                {
                    model.PPM_Stime = DateTime.Parse(row["PPM_Stime"].ToString());
                }
                if (row["PPM_ProductsType"] != null)
                {
                    model.PPM_ProductsType = row["PPM_ProductsType"].ToString();
                }
                if (row["PPM_Model"] != null)
                {
                    model.PPM_Model = row["PPM_Model"].ToString();
                }
                if (row["PPM_SoftNeed"] != null)
                {
                    model.PPM_SoftNeed = row["PPM_SoftNeed"].ToString();
                }
                if (row["PPM_KeyCustom"] != null)
                {
                    model.PPM_KeyCustom = row["PPM_KeyCustom"].ToString();
                }
                if (row["PPM_Standards"] != null)
                {
                    model.PPM_Standards = row["PPM_Standards"].ToString();
                }
                if (row["PPM_OtherRemarks"] != null)
                {
                    model.PPM_OtherRemarks = row["PPM_OtherRemarks"].ToString();
                }
                if (row["PPM_Shape"] != null)
                {
                    model.PPM_Shape = row["PPM_Shape"].ToString();
                }
                if (row["PPM_Lamp"] != null)
                {
                    model.PPM_Lamp = row["PPM_Lamp"].ToString();
                }
                if (row["PPM_Led"] != null)
                {
                    model.PPM_Led = row["PPM_Led"].ToString();
                }
                if (row["PPM_Upper"] != null)
                {
                    model.PPM_Upper = row["PPM_Upper"].ToString();
                }
                if (row["PPM_Lower"] != null)
                {
                    model.PPM_Lower = row["PPM_Lower"].ToString();
                }
                if (row["PPM_Battery"] != null)
                {
                    model.PPM_Battery = row["PPM_Battery"].ToString();
                }
                if (row["PPM_Conductive"] != null)
                {
                    model.PPM_Conductive = row["PPM_Conductive"].ToString();
                }
                if (row["PPM_KeyNumber"] != null)
                {
                    model.PPM_KeyNumber = row["PPM_KeyNumber"].ToString();
                }
                if (row["PPM_Pot"] != null)
                {
                    model.PPM_Pot = row["PPM_Pot"].ToString();
                }
                if (row["PPM_Backlight"] != null)
                {
                    model.PPM_Backlight = row["PPM_Backlight"].ToString();
                }
                if (row["PPM_Description"] != null)
                {
                    model.PPM_Description = row["PPM_Description"].ToString();
                }
                if (row["PPM_HaveBattery"] != null)
                {
                    model.PPM_HaveBattery = row["PPM_HaveBattery"].ToString();
                }
                if (row["PPM_Packing"] != null)
                {
                    model.PPM_Packing = row["PPM_Packing"].ToString();
                }
                if (row["PPM_ProductsDescription"] != null)
                {
                    model.PPM_ProductsDescription = row["PPM_ProductsDescription"].ToString();
                }
                if (row["PPM_Warranty"] != null)
                {
                    model.PPM_Warranty = row["PPM_Warranty"].ToString();
                }
                if (row["PPM_Price"] != null)
                {
                    model.PPM_Price = row["PPM_Price"].ToString();
                }
                if (row["PPM_NeedTime"] != null)
                {
                    model.PPM_NeedTime = row["PPM_NeedTime"].ToString();
                }
                if (row["PPM_Neednumber"] != null)
                {
                    model.PPM_Neednumber = row["PPM_Neednumber"].ToString();
                }
                if (row["PPM_Application"] != null)
                {
                    model.PPM_Application = row["PPM_Application"].ToString();
                }
                if (row["PPM_Remaks"] != null)
                {
                    model.PPM_Remaks = row["PPM_Remaks"].ToString();
                }
                if (row["PPM_Del"] != null && row["PPM_Del"].ToString() != "")
                {
                    model.PPM_Del = int.Parse(row["PPM_Del"].ToString());
                }
                if (row["PPM_CTime"] != null && row["PPM_CTime"].ToString() != "")
                {
                    model.PPM_CTime = DateTime.Parse(row["PPM_CTime"].ToString());
                }
                if (row["PPM_Creator"] != null)
                {
                    model.PPM_Creator = row["PPM_Creator"].ToString();
                }
                if (row["PPM_MTime"] != null && row["PPM_MTime"].ToString() != "")
                {
                    model.PPM_MTime = DateTime.Parse(row["PPM_MTime"].ToString());
                }
                if (row["PPM_Mender"] != null)
                {
                    model.PPM_Mender = row["PPM_Mender"].ToString();
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
            strSql.Append("select PPM_ID,PPM_Code,PPM_Products,PPM_CustomerValue,PPM_Stime,PPM_ProductsType,PPM_Model,PPM_SoftNeed,PPM_KeyCustom,PPM_Standards,PPM_OtherRemarks,PPM_Shape,PPM_Lamp,PPM_Led,PPM_Upper,PPM_Lower,PPM_Battery,PPM_Conductive,PPM_KeyNumber,PPM_Pot,PPM_Backlight,PPM_Description,PPM_HaveBattery,PPM_Packing,PPM_ProductsDescription,PPM_Warranty,PPM_Price,PPM_NeedTime,PPM_Neednumber,PPM_Application,PPM_Remaks,PPM_Del,PPM_CTime,PPM_Creator,PPM_MTime,PPM_Mender ");
            strSql.Append(" FROM Pb_Project_Manage ");
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
            strSql.Append(" PPM_ID,PPM_Code,PPM_Products,PPM_CustomerValue,PPM_Stime,PPM_ProductsType,PPM_Model,PPM_SoftNeed,PPM_KeyCustom,PPM_Standards,PPM_OtherRemarks,PPM_Shape,PPM_Lamp,PPM_Led,PPM_Upper,PPM_Lower,PPM_Battery,PPM_Conductive,PPM_KeyNumber,PPM_Pot,PPM_Backlight,PPM_Description,PPM_HaveBattery,PPM_Packing,PPM_ProductsDescription,PPM_Warranty,PPM_Price,PPM_NeedTime,PPM_Neednumber,PPM_Application,PPM_Remaks,PPM_Del,PPM_CTime,PPM_Creator,PPM_MTime,PPM_Mender ");
            strSql.Append(" FROM Pb_Project_Manage ");
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
            strSql.Append("select count(1) FROM Pb_Project_Manage ");
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
                strSql.Append("order by T.PPM_ID desc");
            }
            strSql.Append(")AS Row, T.*  from Pb_Project_Manage T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
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
            parameters[0].Value = "Pb_Project_Manage";
            parameters[1].Value = "PPM_ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

