using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    public partial class Sc_Products_MakeMoney
    {
        public Sc_Products_MakeMoney()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sc_Products_MakeMoney");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
new SqlParameter("@ID", SqlDbType.VarChar,50)
};
            parameters[0].Value = ID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加
        /// </summary>
        public bool Add(KNet.Model.Sc_Products_MakeMoney model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sc_Products_MakeMoney(");
            strSql.Append("ID,Stime,MakeMoney,PeopleMoney,ElseMaterialsMoney,UnitsMakeMoney,UnitsPeopleMoney,UnitsElseMaterialsMoney,CountTime,ProcessMoneyNotIncluding,MaterialsMoneyNotIncluding,DirectMaterialsMoneyNotIncluding ");
            strSql.Append(") values (");
            strSql.Append("@ID,@Stime,@MakeMoney,@PeopleMoney,@ElseMaterialsMoney,@UnitsMakeMoney,@UnitsPeopleMoney,@UnitsElseMaterialsMoney,@CountTime,@ProcessMoneyNotIncluding,@MaterialsMoneyNotIncluding,@DirectMaterialsMoneyNotIncluding)");
            SqlParameter[] parameters = {

 new SqlParameter("@ID", SqlDbType.VarChar,100),
 new SqlParameter("@Stime", SqlDbType.DateTime,8),
 new SqlParameter("@MakeMoney", SqlDbType.Decimal,9),
 new SqlParameter("@PeopleMoney", SqlDbType.Decimal,9),
 new SqlParameter("@ElseMaterialsMoney", SqlDbType.Decimal,9),
 new SqlParameter("@UnitsMakeMoney", SqlDbType.Decimal,9),
 new SqlParameter("@UnitsPeopleMoney", SqlDbType.Decimal,9),
 new SqlParameter("@UnitsElseMaterialsMoney", SqlDbType.Decimal,9),
 new SqlParameter("@CountTime", SqlDbType.Decimal,9),
 new SqlParameter("@ProcessMoneyNotIncluding", SqlDbType.Decimal,9),
 new SqlParameter("@MaterialsMoneyNotIncluding", SqlDbType.Decimal,9),
 new SqlParameter("@DirectMaterialsMoneyNotIncluding", SqlDbType.Decimal,9)};
            
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Stime;
            parameters[2].Value = model.MakeMoney;
            parameters[3].Value = model.PeopleMoney;
            parameters[4].Value = model.ElseMaterialsMoney;
            parameters[5].Value = model.UnitsMakeMoney;
            parameters[6].Value = model.UnitsPeopleMoney;
            parameters[7].Value = model.UnitsElseMaterialsMoney;
            parameters[8].Value = model.CountTime;
            parameters[9].Value = model.ProcessMoneyNotIncluding;
            parameters[10].Value = model.MaterialsMoneyNotIncluding;
            parameters[11].Value = model.DirectMaterialsMoneyNotIncluding;
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
        public bool Update(KNet.Model.Sc_Products_MakeMoney model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update Sc_Products_MakeMoney set ");
            strSql.Append("ID=@ID,");
            strSql.Append("Stime=@Stime,");
            strSql.Append("MakeMoney=@MakeMoney,");
            strSql.Append("PeopleMoney=@PeopleMoney,");
            strSql.Append("ElseMaterialsMoney=@ElseMaterialsMoney,");
            strSql.Append("UnitsMakeMoney=@UnitsMakeMoney,");
            strSql.Append("UnitsPeopleMoney=@UnitsPeopleMoney,");
            strSql.Append("UnitsElseMaterialsMoney=@UnitsElseMaterialsMoney,");
            strSql.Append("CountTime=@CountTime,");
            strSql.Append("ProcessMoneyNotIncluding=@ProcessMoneyNotIncluding,");
            strSql.Append("MaterialsMoneyNotIncluding=@MaterialsMoneyNotIncluding,");
            strSql.Append("DirectMaterialsMoneyNotIncluding=@DirectMaterialsMoneyNotIncluding");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
 new SqlParameter("@ID", SqlDbType.VarChar,100),
 new SqlParameter("@Stime", SqlDbType.DateTime,8),
 new SqlParameter("@MakeMoney", SqlDbType.Decimal,9),
 new SqlParameter("@PeopleMoney", SqlDbType.Decimal,9),
 new SqlParameter("@ElseMaterialsMoney", SqlDbType.Decimal,9),
 new SqlParameter("@UnitsMakeMoney", SqlDbType.Decimal,9),
 new SqlParameter("@UnitsPeopleMoney", SqlDbType.Decimal,9),
 new SqlParameter("@UnitsElseMaterialsMoney", SqlDbType.Decimal,9),
 new SqlParameter("@CountTime", SqlDbType.Decimal,9),
 new SqlParameter("@ProcessMoneyNotIncluding", SqlDbType.Decimal,9),
 new SqlParameter("@MaterialsMoneyNotIncluding", SqlDbType.Decimal,9),
 new SqlParameter("@DirectMaterialsMoneyNotIncluding", SqlDbType.Decimal,9),
/*new SqlParameter("@ID", SqlDbType.VarChar,100)*/};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Stime;
            parameters[2].Value = model.MakeMoney;
            parameters[3].Value = model.PeopleMoney;
            parameters[4].Value = model.ElseMaterialsMoney;
            parameters[5].Value = model.UnitsMakeMoney;
            parameters[6].Value = model.UnitsPeopleMoney;
            parameters[7].Value = model.UnitsElseMaterialsMoney;
            parameters[8].Value = model.CountTime;
            parameters[9].Value = model.ProcessMoneyNotIncluding;
            parameters[10].Value = model.MaterialsMoneyNotIncluding;
            parameters[11].Value = model.DirectMaterialsMoneyNotIncluding;
            //parameters[12].Value = model.ID;

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
        /// Delete
        /// </summary>
        public bool Delete(string s_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from  Sc_Products_MakeMoney  ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
new SqlParameter("@ID", SqlDbType.VarChar,100)};
            parameters[0].Value = s_ID;
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
        /// Delete
        /// </summary>
        public bool UpdateDel(KNet.Model.Sc_Products_MakeMoney model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update   Sc_Products_MakeMoney  Set ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
new SqlParameter("@ID", SqlDbType.VarChar,100)};
            parameters[0].Value = model.ID;

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
        /// Delete
        /// </summary>
        public bool DeleteList(string s_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Delete From   Sc_Products_MakeMoney  ");
            strSql.Append(" where ID in ('" + s_ID + "')");

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
        /// QueryByFID
        /// </summary>
        public DataSet QueryByFID(string s_FID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from  Sc_Products_MakeMoney  ");
            SqlParameter[] parameters = {
};

            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// DeleteByFID
        /// </summary>
        public bool DeleteByFID(string s_FID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from  Sc_Products_MakeMoney  ");
            SqlParameter[] parameters = {
};

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
        /// 得到数据
        /// </summary>
        public KNet.Model.Sc_Products_MakeMoney GetModel(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from Sc_Products_MakeMoney  ");
            strSql.Append("where ID=@ID  ");
            SqlParameter[] parameters = {
 new SqlParameter("@ID", SqlDbType.VarChar,100)
};
            parameters[0].Value = ID;
            KNet.Model.Sc_Products_MakeMoney model = new KNet.Model.Sc_Products_MakeMoney();
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
        public KNet.Model.Sc_Products_MakeMoney DataRowToModel(DataRow row)
        {
            KNet.Model.Sc_Products_MakeMoney model = new KNet.Model.Sc_Products_MakeMoney();
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
                if (row["Stime"] != null)
                {
                    model.Stime = DateTime.Parse(row["Stime"].ToString());
                }
                if (row["MakeMoney"] != null)
                {
                    model.MakeMoney = Decimal.Parse(row["MakeMoney"].ToString());
                }
                else
                {
                    model.MakeMoney = 0;
                }
                if (row["PeopleMoney"] != null)
                {
                    model.PeopleMoney = Decimal.Parse(row["PeopleMoney"].ToString());
                }
                else
                {
                    model.PeopleMoney = 0;
                }
                if (row["ElseMaterialsMoney"] != null)
                {
                    model.ElseMaterialsMoney = Decimal.Parse(row["ElseMaterialsMoney"].ToString());
                }
                else
                {
                    model.ElseMaterialsMoney = 0;
                }
                if (row["UnitsMakeMoney"] != null)
                {
                    model.UnitsMakeMoney = Decimal.Parse(row["UnitsMakeMoney"].ToString());
                }
                else
                {
                    model.UnitsMakeMoney = 0;
                }
                if (row["UnitsPeopleMoney"] != null)
                {
                    model.UnitsPeopleMoney = Decimal.Parse(row["UnitsPeopleMoney"].ToString());
                }
                else
                {
                    model.UnitsPeopleMoney = 0;
                }
                if (row["UnitsElseMaterialsMoney"] != null)
                {
                    model.UnitsElseMaterialsMoney = Decimal.Parse(row["UnitsElseMaterialsMoney"].ToString());
                }
                else
                {
                    model.UnitsElseMaterialsMoney = 0;
                }
                if (row["CountTime"] != null)
                {
                    model.CountTime = Decimal.Parse(row["CountTime"].ToString());
                }
                else
                {
                    model.CountTime = 0;
                }
                if (row["ProcessMoneyNotIncluding"] != null)
                {
                    model.ProcessMoneyNotIncluding = Decimal.Parse(row["ProcessMoneyNotIncluding"].ToString());
                }
                else
                {
                    model.ProcessMoneyNotIncluding = 0;
                }
                if (row["MaterialsMoneyNotIncluding"] != null)
                {
                    model.MaterialsMoneyNotIncluding = Decimal.Parse(row["MaterialsMoneyNotIncluding"].ToString());
                }
                else
                {
                    model.MaterialsMoneyNotIncluding = 0;
                }
                if (row["DirectMaterialsMoneyNotIncluding"] != null)
                {
                    model.DirectMaterialsMoneyNotIncluding = Decimal.Parse(row["DirectMaterialsMoneyNotIncluding"].ToString());
                }
                else
                {
                    model.DirectMaterialsMoneyNotIncluding = 0;
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
            strSql.Append(" FROM Sc_Products_MakeMoney ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
