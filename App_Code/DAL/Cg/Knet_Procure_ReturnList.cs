using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类Knet_Procure_ReturnList。
    /// </summary>
    public class Knet_Procure_ReturnList
    {
        public Knet_Procure_ReturnList()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ReturnNo)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ReturnNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = ReturnNo;

            int result = DbHelperSQL.RunProcedure("Proc_Knet_Procure_ReturnList_Exists", parameters, out rowsAffected);
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///  增加一条数据
        /// </summary>
        public void Add(KNet.Model.Knet_Procure_ReturnList model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {

					new SqlParameter("@ReturnNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ReturnTopic", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ReturnDateTime", SqlDbType.DateTime),
					new SqlParameter("@SuppNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ReturnPaymentNotes", SqlDbType.NVarChar,50),
					new SqlParameter("@ReturnStaffBranch", SqlDbType.NVarChar,50),
					new SqlParameter("@ReturnStaffDepart", SqlDbType.NVarChar,50),
					new SqlParameter("@ReturnStaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ReturnCheckStaffNo", SqlDbType.NVarChar,50),

                    new SqlParameter("@OrderTransShare", SqlDbType.Decimal,9),
					new SqlParameter("@OrderType", SqlDbType.NVarChar,50),

					new SqlParameter("@ReturnRemarks", SqlDbType.NVarChar,1000)};
           
            parameters[0].Value = model.ReturnNo;
            parameters[1].Value = model.ReturnTopic;
            parameters[2].Value = model.OrderNo;
            parameters[3].Value = model.ReturnDateTime;
            parameters[4].Value = model.SuppNo;
            parameters[5].Value = model.ReturnPaymentNotes;
            parameters[6].Value = model.ReturnStaffBranch;
            parameters[7].Value = model.ReturnStaffDepart;
            parameters[8].Value = model.ReturnStaffNo;
            parameters[9].Value = model.ReturnCheckStaffNo;

            parameters[10].Value = model.OrderTransShare;
            parameters[11].Value = model.OrderType;

            parameters[12].Value = model.ReturnRemarks;
           

            DbHelperSQL.RunProcedure("Proc_Knet_Procure_ReturnList_ADD", parameters, out rowsAffected);
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public void Update(KNet.Model.Knet_Procure_ReturnList model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ReturnNo", SqlDbType.NVarChar,50),
					
					new SqlParameter("@ReturnTopic", SqlDbType.NVarChar,50),
					
					new SqlParameter("@ReturnDateTime", SqlDbType.DateTime),
					
					
					new SqlParameter("@ReturnStaffBranch", SqlDbType.NVarChar,50),
					new SqlParameter("@ReturnStaffDepart", SqlDbType.NVarChar,50),

					new SqlParameter("@ReturnStaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ReturnCheckStaffNo", SqlDbType.NVarChar,50),

                    new SqlParameter("@OrderTransShare", SqlDbType.Decimal,9),
					new SqlParameter("@OrderType", SqlDbType.NVarChar,50),

					new SqlParameter("@ReturnRemarks", SqlDbType.NVarChar,1000)};
          
            parameters[0].Value = model.ReturnNo;
            parameters[1].Value = model.ReturnTopic;
          
            parameters[2].Value = model.ReturnDateTime;
           
           
            parameters[3].Value = model.ReturnStaffBranch;
            parameters[4].Value = model.ReturnStaffDepart;

            parameters[5].Value = model.ReturnStaffNo;
            parameters[6].Value = model.ReturnCheckStaffNo;

            parameters[7].Value = model.OrderTransShare;
            parameters[8].Value = model.OrderType;

            parameters[9].Value = model.ReturnRemarks;
           

            DbHelperSQL.RunProcedure("Proc_Knet_Procure_ReturnList_Update", parameters, out rowsAffected);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string ReturnNo)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ReturnNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = ReturnNo;

            DbHelperSQL.RunProcedure("Proc_Knet_Procure_ReturnList_Delete", parameters, out rowsAffected);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Knet_Procure_ReturnList GetModel(string ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            KNet.Model.Knet_Procure_ReturnList model = new KNet.Model.Knet_Procure_ReturnList();
            DataSet ds = DbHelperSQL.RunProcedure("Proc_Knet_Procure_ReturnList_GetModelByID", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.ReturnNo = ds.Tables[0].Rows[0]["ReturnNo"].ToString();
                model.ReturnTopic = ds.Tables[0].Rows[0]["ReturnTopic"].ToString();
                model.OrderNo = ds.Tables[0].Rows[0]["OrderNo"].ToString();
                if (ds.Tables[0].Rows[0]["ReturnDateTime"].ToString() != "")
                {
                    model.ReturnDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["ReturnDateTime"].ToString());
                }
                model.SuppNo = ds.Tables[0].Rows[0]["SuppNo"].ToString();
                model.ReturnPaymentNotes = ds.Tables[0].Rows[0]["ReturnPaymentNotes"].ToString();
                model.ReturnStaffBranch = ds.Tables[0].Rows[0]["ReturnStaffBranch"].ToString();
                model.ReturnStaffDepart = ds.Tables[0].Rows[0]["ReturnStaffDepart"].ToString();
                model.ReturnStaffNo = ds.Tables[0].Rows[0]["ReturnStaffNo"].ToString();
                model.ReturnCheckStaffNo = ds.Tables[0].Rows[0]["ReturnCheckStaffNo"].ToString();
                model.ReturnRemarks = ds.Tables[0].Rows[0]["ReturnRemarks"].ToString();
                if (ds.Tables[0].Rows[0]["OrderTransShare"].ToString() != "")
                {
                    model.OrderTransShare = decimal.Parse(ds.Tables[0].Rows[0]["OrderTransShare"].ToString());
                }
                model.OrderType = ds.Tables[0].Rows[0]["OrderType"].ToString();

                if (ds.Tables[0].Rows[0]["ReturnCheckYN"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["ReturnCheckYN"].ToString() == "1") || (ds.Tables[0].Rows[0]["ReturnCheckYN"].ToString().ToLower() == "true"))
                    {
                        model.ReturnCheckYN = true;
                    }
                    else
                    {
                        model.ReturnCheckYN = false;
                    }
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Knet_Procure_ReturnList GetModelB(string ReturnNo)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ReturnNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = ReturnNo;

            KNet.Model.Knet_Procure_ReturnList model = new KNet.Model.Knet_Procure_ReturnList();
            DataSet ds = DbHelperSQL.RunProcedure("Proc_Knet_Procure_ReturnList_GetModelByReturnNo", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.ReturnNo = ds.Tables[0].Rows[0]["ReturnNo"].ToString();
                model.ReturnTopic = ds.Tables[0].Rows[0]["ReturnTopic"].ToString();
                model.OrderNo = ds.Tables[0].Rows[0]["OrderNo"].ToString();
                if (ds.Tables[0].Rows[0]["ReturnDateTime"].ToString() != "")
                {
                    model.ReturnDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["ReturnDateTime"].ToString());
                }
                model.SuppNo = ds.Tables[0].Rows[0]["SuppNo"].ToString();
                model.ReturnPaymentNotes = ds.Tables[0].Rows[0]["ReturnPaymentNotes"].ToString();
                model.ReturnStaffBranch = ds.Tables[0].Rows[0]["ReturnStaffBranch"].ToString();
                model.ReturnStaffDepart = ds.Tables[0].Rows[0]["ReturnStaffDepart"].ToString();
                model.ReturnStaffNo = ds.Tables[0].Rows[0]["ReturnStaffNo"].ToString();
                model.ReturnCheckStaffNo = ds.Tables[0].Rows[0]["ReturnCheckStaffNo"].ToString();
                model.ReturnRemarks = ds.Tables[0].Rows[0]["ReturnRemarks"].ToString();

                if (ds.Tables[0].Rows[0]["OrderTransShare"].ToString() != "")
                {
                    model.OrderTransShare = decimal.Parse(ds.Tables[0].Rows[0]["OrderTransShare"].ToString());
                }
                model.OrderType = ds.Tables[0].Rows[0]["OrderType"].ToString();

                if (ds.Tables[0].Rows[0]["ReturnCheckYN"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["ReturnCheckYN"].ToString() == "1") || (ds.Tables[0].Rows[0]["ReturnCheckYN"].ToString().ToLower() == "true"))
                    {
                        model.ReturnCheckYN = true;
                    }
                    else
                    {
                        model.ReturnCheckYN = false;
                    }
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
            strSql.Append("select ID,ReturnNo,ReturnTopic,OrderNo,ReturnDateTime,SuppNo,ReturnPaymentNotes,ReturnStaffBranch,ReturnStaffDepart,ReturnStaffNo,ReturnCheckStaffNo,ReturnRemarks,ReturnCheckYN,OrderTransShare,OrderType ");
            strSql.Append(" FROM Knet_Procure_ReturnList ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }



        #endregion  成员方法
    }
}

