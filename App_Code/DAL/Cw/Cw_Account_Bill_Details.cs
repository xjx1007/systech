using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
	/// <summary>
	/// 数据访问类:Cw_Account_Bill_Details
	/// </summary>
	public partial class Cw_Account_Bill_Details
	{
		public Cw_Account_Bill_Details()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string CAD_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Cw_Account_Bill_Details");
			strSql.Append(" where CAD_ID=@CAD_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CAD_ID", SqlDbType.VarChar,50)};
			parameters[0].Value = CAD_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(KNet.Model.Cw_Account_Bill_Details model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Cw_Account_Bill_Details(");
			strSql.Append("CAD_ID,CAD_CAAID,CAD_OutNo,CAD_ContractNo,CAD_FID,CAD_ProductsBarCode,CAD_Number,CAD_Price,CAD_Money,CAD_Remarks)");
			strSql.Append(" values (");
			strSql.Append("@CAD_ID,@CAD_CAAID,@CAD_OutNo,@CAD_ContractNo,@CAD_FID,@CAD_ProductsBarCode,@CAD_Number,@CAD_Price,@CAD_Money,@CAD_Remarks)");
			SqlParameter[] parameters = {
					new SqlParameter("@CAD_ID", SqlDbType.VarChar,50),
					new SqlParameter("@CAD_CAAID", SqlDbType.VarChar,50),
					new SqlParameter("@CAD_OutNo", SqlDbType.VarChar,50),
					new SqlParameter("@CAD_ContractNo", SqlDbType.VarChar,50),
					new SqlParameter("@CAD_FID", SqlDbType.VarChar,50),
					new SqlParameter("@CAD_ProductsBarCode", SqlDbType.VarChar,50),
					new SqlParameter("@CAD_Number", SqlDbType.Decimal,9),
					new SqlParameter("@CAD_Price", SqlDbType.Decimal,9),
					new SqlParameter("@CAD_Money", SqlDbType.Decimal,9),
					new SqlParameter("@CAD_Remarks", SqlDbType.VarChar,150)};
			parameters[0].Value = model.CAD_ID;
			parameters[1].Value = model.CAD_CAAID;
			parameters[2].Value = model.CAD_OutNo;
			parameters[3].Value = model.CAD_ContractNo;
			parameters[4].Value = model.CAD_FID;
			parameters[5].Value = model.CAD_ProductsBarCode;
			parameters[6].Value = model.CAD_Number;
			parameters[7].Value = model.CAD_Price;
			parameters[8].Value = model.CAD_Money;
			parameters[9].Value = model.CAD_Remarks;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(KNet.Model.Cw_Account_Bill_Details model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Cw_Account_Bill_Details set ");
			strSql.Append("CAD_CAAID=@CAD_CAAID,");
			strSql.Append("CAD_OutNo=@CAD_OutNo,");
			strSql.Append("CAD_ContractNo=@CAD_ContractNo,");
			strSql.Append("CAD_FID=@CAD_FID,");
			strSql.Append("CAD_ProductsBarCode=@CAD_ProductsBarCode,");
			strSql.Append("CAD_Number=@CAD_Number,");
			strSql.Append("CAD_Price=@CAD_Price,");
			strSql.Append("CAD_Money=@CAD_Money,");
			strSql.Append("CAD_Remarks=@CAD_Remarks");
			strSql.Append(" where CAD_ID=@CAD_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CAD_CAAID", SqlDbType.VarChar,50),
					new SqlParameter("@CAD_OutNo", SqlDbType.VarChar,50),
					new SqlParameter("@CAD_ContractNo", SqlDbType.VarChar,50),
					new SqlParameter("@CAD_FID", SqlDbType.VarChar,50),
					new SqlParameter("@CAD_ProductsBarCode", SqlDbType.VarChar,50),
					new SqlParameter("@CAD_Number", SqlDbType.Decimal,9),
					new SqlParameter("@CAD_Price", SqlDbType.Decimal,9),
					new SqlParameter("@CAD_Money", SqlDbType.Decimal,9),
					new SqlParameter("@CAD_Remarks", SqlDbType.VarChar,150),
					new SqlParameter("@CAD_ID", SqlDbType.VarChar,50)};
			parameters[0].Value = model.CAD_CAAID;
			parameters[1].Value = model.CAD_OutNo;
			parameters[2].Value = model.CAD_ContractNo;
			parameters[3].Value = model.CAD_FID;
			parameters[4].Value = model.CAD_ProductsBarCode;
			parameters[5].Value = model.CAD_Number;
			parameters[6].Value = model.CAD_Price;
			parameters[7].Value = model.CAD_Money;
			parameters[8].Value = model.CAD_Remarks;
			parameters[9].Value = model.CAD_ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(string CAD_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Cw_Account_Bill_Details ");
			strSql.Append(" where CAD_ID=@CAD_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CAD_ID", SqlDbType.VarChar,50)};
			parameters[0].Value = CAD_ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string CAD_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Cw_Account_Bill_Details ");
			strSql.Append(" where CAD_ID in ("+CAD_IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public KNet.Model.Cw_Account_Bill_Details GetModel(string CAD_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CAD_ID,CAD_CAAID,CAD_OutNo,CAD_ContractNo,CAD_FID,CAD_ProductsBarCode,CAD_Number,CAD_Price,CAD_Money,CAD_Remarks from Cw_Account_Bill_Details ");
			strSql.Append(" where CAD_ID=@CAD_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CAD_ID", SqlDbType.VarChar,50)};
			parameters[0].Value = CAD_ID;

			KNet.Model.Cw_Account_Bill_Details model=new KNet.Model.Cw_Account_Bill_Details();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["CAD_ID"]!=null && ds.Tables[0].Rows[0]["CAD_ID"].ToString()!="")
				{
					model.CAD_ID=ds.Tables[0].Rows[0]["CAD_ID"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CAD_CAAID"]!=null && ds.Tables[0].Rows[0]["CAD_CAAID"].ToString()!="")
				{
					model.CAD_CAAID=ds.Tables[0].Rows[0]["CAD_CAAID"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CAD_OutNo"]!=null && ds.Tables[0].Rows[0]["CAD_OutNo"].ToString()!="")
				{
					model.CAD_OutNo=ds.Tables[0].Rows[0]["CAD_OutNo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CAD_ContractNo"]!=null && ds.Tables[0].Rows[0]["CAD_ContractNo"].ToString()!="")
				{
					model.CAD_ContractNo=ds.Tables[0].Rows[0]["CAD_ContractNo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CAD_FID"]!=null && ds.Tables[0].Rows[0]["CAD_FID"].ToString()!="")
				{
					model.CAD_FID=ds.Tables[0].Rows[0]["CAD_FID"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CAD_ProductsBarCode"]!=null && ds.Tables[0].Rows[0]["CAD_ProductsBarCode"].ToString()!="")
				{
					model.CAD_ProductsBarCode=ds.Tables[0].Rows[0]["CAD_ProductsBarCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CAD_Number"]!=null && ds.Tables[0].Rows[0]["CAD_Number"].ToString()!="")
				{
					model.CAD_Number=decimal.Parse(ds.Tables[0].Rows[0]["CAD_Number"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CAD_Price"]!=null && ds.Tables[0].Rows[0]["CAD_Price"].ToString()!="")
				{
					model.CAD_Price=decimal.Parse(ds.Tables[0].Rows[0]["CAD_Price"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CAD_Money"]!=null && ds.Tables[0].Rows[0]["CAD_Money"].ToString()!="")
				{
					model.CAD_Money=decimal.Parse(ds.Tables[0].Rows[0]["CAD_Money"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CAD_Remarks"]!=null && ds.Tables[0].Rows[0]["CAD_Remarks"].ToString()!="")
				{
					model.CAD_Remarks=ds.Tables[0].Rows[0]["CAD_Remarks"].ToString();
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select CAD_ID,CAD_CAAID,CAD_OutNo,CAD_ContractNo,CAD_FID,CAD_ProductsBarCode,CAD_Number,CAD_Price,CAD_Money,CAD_Remarks ");
			strSql.Append(" FROM Cw_Account_Bill_Details ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" CAD_ID,CAD_CAAID,CAD_OutNo,CAD_ContractNo,CAD_FID,CAD_ProductsBarCode,CAD_Number,CAD_Price,CAD_Money,CAD_Remarks ");
			strSql.Append(" FROM Cw_Account_Bill_Details ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			parameters[0].Value = "Cw_Account_Bill_Details";
			parameters[1].Value = "CAD_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteByCAAID(string CAD_CAAID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cw_Account_Bill_Details ");
            strSql.Append(" where CAD_CAAID=@CAD_CAAID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CAD_CAAID", SqlDbType.VarChar,50)};
            parameters[0].Value = CAD_CAAID;

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
		#endregion  Method
	}

}


    