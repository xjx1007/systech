using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:Cg_Order_Checklist
    /// </summary>
    public partial class Cg_Order_Checklist
    {
        public Cg_Order_Checklist()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string COC_Code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Cg_Order_Checklist");
            strSql.Append(" where COC_Code=@COC_Code ");
            SqlParameter[] parameters = {
					new SqlParameter("@COC_Code", SqlDbType.VarChar,50)};
            parameters[0].Value = COC_Code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Cg_Order_Checklist model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Cg_Order_Checklist(");
            strSql.Append("COC_Code,COC_HouseNo,COC_Stime,COC_BeginDate,COC_EndDate,COC_Details,COC_CTime,COC_Creator,COC_MTime,COC_Mender,COC_Type,COC_SuppNo,COC_RKCode)");
            strSql.Append(" values (");
            strSql.Append("@COC_Code,@COC_HouseNo,@COC_Stime,@COC_BeginDate,@COC_EndDate,@COC_Details,@COC_CTime,@COC_Creator,@COC_MTime,@COC_Mender,@COC_Type,@COC_SuppNo,@COC_RKCode)");
            SqlParameter[] parameters = {
					new SqlParameter("@COC_Code", SqlDbType.VarChar,50),
					new SqlParameter("@COC_HouseNo", SqlDbType.VarChar,50),
					new SqlParameter("@COC_Stime", SqlDbType.DateTime),
					new SqlParameter("@COC_BeginDate", SqlDbType.DateTime),
					new SqlParameter("@COC_EndDate", SqlDbType.DateTime),
					new SqlParameter("@COC_Details", SqlDbType.VarChar,2000),
					new SqlParameter("@COC_CTime", SqlDbType.DateTime),
					new SqlParameter("@COC_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@COC_MTime", SqlDbType.DateTime),
					new SqlParameter("@COC_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@COC_Type", SqlDbType.VarChar,50),
					new SqlParameter("@COC_SuppNo", SqlDbType.VarChar,50),
					new SqlParameter("@COC_RKCode", SqlDbType.VarChar,50)};
            parameters[0].Value = model.COC_Code;
            parameters[1].Value = model.COC_HouseNo;
            parameters[2].Value = model.COC_Stime;
            parameters[3].Value = model.COC_BeginDate;
            parameters[4].Value = model.COC_EndDate;
            parameters[5].Value = model.COC_Details;
            parameters[6].Value = model.COC_CTime;
            parameters[7].Value = model.COC_Creator;
            parameters[8].Value = model.COC_MTime;
            parameters[9].Value = model.COC_Mender;
            parameters[10].Value = model.COC_Type;
            parameters[11].Value = model.COC_SuppNo;
            parameters[12].Value = model.COC_RKCode;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Cg_Order_Checklist model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cg_Order_Checklist set ");
            strSql.Append("COC_HouseNo=@COC_HouseNo,");
            strSql.Append("COC_Stime=@COC_Stime,");
            strSql.Append("COC_BeginDate=@COC_BeginDate,");
            strSql.Append("COC_EndDate=@COC_EndDate,");
            strSql.Append("COC_Details=@COC_Details,");
            strSql.Append("COC_SuppNo=@COC_SuppNo,");
            strSql.Append("COC_Type=@COC_Type,");
            strSql.Append("COC_MTime=@COC_MTime,");
            strSql.Append("COC_Mender=@COC_Mender");
            strSql.Append(" where COC_Code=@COC_Code ");
            SqlParameter[] parameters = {
					new SqlParameter("@COC_HouseNo", SqlDbType.VarChar,50),
					new SqlParameter("@COC_Stime", SqlDbType.DateTime),
					new SqlParameter("@COC_BeginDate", SqlDbType.DateTime),
					new SqlParameter("@COC_EndDate", SqlDbType.DateTime),
					new SqlParameter("@COC_Details", SqlDbType.VarChar,2000),
					new SqlParameter("@COC_SuppNo", SqlDbType.VarChar,50),
					new SqlParameter("@COC_Type", SqlDbType.VarChar,50),
					new SqlParameter("@COC_MTime", SqlDbType.DateTime),
					new SqlParameter("@COC_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@COC_Code", SqlDbType.VarChar,50)};
            parameters[0].Value = model.COC_HouseNo;
            parameters[1].Value = model.COC_Stime;
            parameters[2].Value = model.COC_BeginDate;
            parameters[3].Value = model.COC_EndDate;
            parameters[4].Value = model.COC_Details;
            parameters[5].Value = model.COC_SuppNo;
            parameters[6].Value = model.COC_Type;
            parameters[7].Value = model.COC_MTime;
            parameters[8].Value = model.COC_Mender;
            parameters[9].Value = model.COC_Code;

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
        public bool UpdateIsPayMent(KNet.Model.Cg_Order_Checklist model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cg_Order_Checklist set ");
            strSql.Append("COC_IsPayMent=@COC_IsPayMent");
            strSql.Append(" where COC_Code=@COC_Code ");
            SqlParameter[] parameters = {
					new SqlParameter("@COC_IsPayMent", SqlDbType.Int,4),
					new SqlParameter("@COC_Code", SqlDbType.VarChar,50)};
            parameters[0].Value = model.COC_IsPayMent;
            parameters[1].Value = model.COC_Code;

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
        public bool Delete(string COC_Code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cg_Order_Checklist ");
            strSql.Append(" where COC_Code=@COC_Code ");
            SqlParameter[] parameters = {
					new SqlParameter("@COC_Code", SqlDbType.VarChar,50)};
            parameters[0].Value = COC_Code;

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
        public bool DeleteList(string COC_Codelist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cg_Order_Checklist ");
            strSql.Append(" where COC_Code in (" + COC_Codelist + ")  ");
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
        public KNet.Model.Cg_Order_Checklist GetModel(string COC_Code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Cg_Order_Checklist ");
            strSql.Append(" where COC_Code=@COC_Code ");
            SqlParameter[] parameters = {
					new SqlParameter("@COC_Code", SqlDbType.VarChar,50)};
            parameters[0].Value = COC_Code;

            KNet.Model.Cg_Order_Checklist model = new KNet.Model.Cg_Order_Checklist();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["COC_Code"] != null && ds.Tables[0].Rows[0]["COC_Code"].ToString() != "")
                {
                    model.COC_Code = ds.Tables[0].Rows[0]["COC_Code"].ToString();
                }
                if (ds.Tables[0].Rows[0]["COC_HouseNo"] != null && ds.Tables[0].Rows[0]["COC_HouseNo"].ToString() != "")
                {
                    model.COC_HouseNo = ds.Tables[0].Rows[0]["COC_HouseNo"].ToString();
                }
                else
                {
                    model.COC_HouseNo = "";
                }

                if (ds.Tables[0].Rows[0]["COC_Stime"] != null && ds.Tables[0].Rows[0]["COC_Stime"].ToString() != "")
                {
                    model.COC_Stime = DateTime.Parse(ds.Tables[0].Rows[0]["COC_Stime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["COC_BeginDate"] != null && ds.Tables[0].Rows[0]["COC_BeginDate"].ToString() != "")
                {
                    model.COC_BeginDate = DateTime.Parse(ds.Tables[0].Rows[0]["COC_BeginDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["COC_EndDate"] != null && ds.Tables[0].Rows[0]["COC_EndDate"].ToString() != "")
                {
                    model.COC_EndDate = DateTime.Parse(ds.Tables[0].Rows[0]["COC_EndDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["COC_Details"] != null && ds.Tables[0].Rows[0]["COC_Details"].ToString() != "")
                {
                    model.COC_Details = ds.Tables[0].Rows[0]["COC_Details"].ToString();
                }
                if (ds.Tables[0].Rows[0]["COC_CTime"] != null && ds.Tables[0].Rows[0]["COC_CTime"].ToString() != "")
                {
                    model.COC_CTime = DateTime.Parse(ds.Tables[0].Rows[0]["COC_CTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["COC_Creator"] != null && ds.Tables[0].Rows[0]["COC_Creator"].ToString() != "")
                {
                    model.COC_Creator = ds.Tables[0].Rows[0]["COC_Creator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["COC_MTime"] != null && ds.Tables[0].Rows[0]["COC_MTime"].ToString() != "")
                {
                    model.COC_MTime = DateTime.Parse(ds.Tables[0].Rows[0]["COC_MTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["COC_Mender"] != null && ds.Tables[0].Rows[0]["COC_Mender"].ToString() != "")
                {
                    model.COC_Mender = ds.Tables[0].Rows[0]["COC_Mender"].ToString();
                }
                if (ds.Tables[0].Rows[0]["COC_SuppNo"] != null && ds.Tables[0].Rows[0]["COC_SuppNo"].ToString() != "")
                {
                    model.COC_SuppNo = ds.Tables[0].Rows[0]["COC_SuppNo"].ToString();
                }
                else
                {
                    model.COC_SuppNo = "";
                }

                if (ds.Tables[0].Rows[0]["COC_Type"] != null && ds.Tables[0].Rows[0]["COC_Type"].ToString() != "")
                {
                    model.COC_Type = ds.Tables[0].Rows[0]["COC_Type"].ToString();
                }
                else
                {
                    model.COC_Type = "0";
                }

                if (ds.Tables[0].Rows[0]["COC_CheckYN"] != null && ds.Tables[0].Rows[0]["COC_CheckYN"].ToString() != "")
                {
                    model.COC_CheckYN = int.Parse(ds.Tables[0].Rows[0]["COC_CheckYN"].ToString());
                }
                if (ds.Tables[0].Rows[0]["COC_CheckPerson"] != null && ds.Tables[0].Rows[0]["COC_CheckPerson"].ToString() != "")
                {
                    model.COC_CheckPerson = ds.Tables[0].Rows[0]["COC_CheckPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["COC_CheckTime"] != null && ds.Tables[0].Rows[0]["COC_CheckTime"].ToString() != "")
                {
                    model.COC_CheckTime = DateTime.Parse(ds.Tables[0].Rows[0]["COC_CheckTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["COC_IsFp"] != null && ds.Tables[0].Rows[0]["COC_IsFp"].ToString() != "")
                {
                    model.COC_IsFp = int.Parse(ds.Tables[0].Rows[0]["COC_IsFp"].ToString());
                }
                else
                {
                    model.COC_IsFp = 0;
                }
                if (ds.Tables[0].Rows[0]["COC_IsPayMent"] != null && ds.Tables[0].Rows[0]["COC_IsPayMent"].ToString() != "")
                {
                    model.COC_IsPayMent = int.Parse(ds.Tables[0].Rows[0]["COC_IsPayMent"].ToString());
                }
                else
                {
                    model.COC_IsPayMent = 0;
                }
                if (ds.Tables[0].Rows[0]["COC_IsSend"] != null && ds.Tables[0].Rows[0]["COC_IsSend"].ToString() != "")
                {
                    model.COC_IsSend = int.Parse(ds.Tables[0].Rows[0]["COC_IsSend"].ToString());
                }
                else
                {
                    model.COC_IsSend = 0;
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
            strSql.Append(" FROM Cg_Order_Checklist ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetDetailsList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *,COD_NOTaxMoney as COD_SMoney,c.WareHouseNo,d.WareHouseDateTime ");
            strSql.Append(" FROM Cg_Order_Checklist a join Cg_Order_Checklist_Details b on a.COC_Code=b.COD_CheckNo join Knet_Procure_WareHouseList_Details c on b.COD_DirectOutID=c.ID join Knet_Procure_WareHouseList d on c.WareHouseNo=d.WareHouseNO ");
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
            strSql.Append(" COC_Code,COC_HouseNo,COC_Stime,COC_BeginDate,COC_EndDate,COC_Details,COC_CTime,COC_Creator,COC_MTime,COC_Mender ");
            strSql.Append(" FROM Cg_Order_Checklist ");
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
            parameters[0].Value = "Cg_Order_Checklist";
            parameters[1].Value = "COC_Code";
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

