using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;

namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类Knet_Procure_ReceivingList。
    /// </summary>
    public class Knet_Procure_ReceivingList
    {
        public Knet_Procure_ReceivingList()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ReceivNo)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ReceivNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = ReceivNo;

            int result = DbHelperSQL.RunProcedure("Proc_Knet_Procure_ReceivingList_Exists", parameters, out rowsAffected);
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
        public void Add(KNet.Model.Knet_Procure_ReceivingList model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
		
					new SqlParameter("@ReceivNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ReceivTopic", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ReceivDateTime", SqlDbType.DateTime),
					new SqlParameter("@SuppNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ReceivPaymentNotes", SqlDbType.NVarChar,50),
					new SqlParameter("@ReceivStaffBranch", SqlDbType.NVarChar,50),
					new SqlParameter("@ReceivStaffDepart", SqlDbType.NVarChar,50),
					new SqlParameter("@ReceivStaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ReceivCheckStaffNo", SqlDbType.NVarChar,50),
                	new SqlParameter("@OrderTransShare", SqlDbType.Decimal,9),
					new SqlParameter("@OrderType", SqlDbType.NVarChar,50),
					new SqlParameter("@ReceivRemarks", SqlDbType.NVarChar,1000)};
        
            parameters[0].Value = model.ReceivNo;
            parameters[1].Value = model.ReceivTopic;
            parameters[2].Value = model.OrderNo;
            parameters[3].Value = model.ReceivDateTime;
            parameters[4].Value = model.SuppNo;
            parameters[5].Value = model.ReceivPaymentNotes;
            parameters[6].Value = model.ReceivStaffBranch;
            parameters[7].Value = model.ReceivStaffDepart;
            parameters[8].Value = model.ReceivStaffNo;
            parameters[9].Value = model.ReceivCheckStaffNo;
            parameters[10].Value = model.OrderTransShare;
            parameters[11].Value = model.OrderType;
            parameters[12].Value = model.ReceivRemarks;

            DbHelperSQL.RunProcedure("Proc_Knet_Procure_ReceivingList_ADD", parameters, out rowsAffected);
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public void Update(KNet.Model.Knet_Procure_ReceivingList model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ReceivNo", SqlDbType.NVarChar,50),

					new SqlParameter("@ReceivTopic", SqlDbType.NVarChar,50),
					new SqlParameter("@ReceivDateTime", SqlDbType.DateTime),
					new SqlParameter("@ReceivStaffBranch", SqlDbType.NVarChar,50),
					new SqlParameter("@ReceivStaffDepart", SqlDbType.NVarChar,50),

					new SqlParameter("@ReceivStaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ReceivCheckStaffNo", SqlDbType.NVarChar,50),
                    new SqlParameter("@OrderTransShare", SqlDbType.Decimal,9),
					new SqlParameter("@OrderType", SqlDbType.NVarChar,50),
					new SqlParameter("@ReceivRemarks", SqlDbType.NVarChar,1000)};
          
            parameters[0].Value = model.ReceivNo;

            parameters[1].Value = model.ReceivTopic;
            parameters[2].Value = model.ReceivDateTime;
            parameters[3].Value = model.ReceivStaffBranch;
            parameters[4].Value = model.ReceivStaffDepart;

            parameters[5].Value = model.ReceivStaffNo;
            parameters[6].Value = model.ReceivCheckStaffNo;
            parameters[7].Value = model.OrderTransShare;
            parameters[8].Value = model.OrderType;
            parameters[9].Value = model.ReceivRemarks;
          

            DbHelperSQL.RunProcedure("Proc_Knet_Procure_ReceivingList_Update", parameters, out rowsAffected);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string ReceivNo)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ReceivNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = ReceivNo;

            DbHelperSQL.RunProcedure("Proc_Knet_Procure_ReceivingList_Delete", parameters, out rowsAffected);
        }
        /// <summary>
        /// 得到一个对象实体 
        /// </summary>
        public KNet.Model.Knet_Procure_ReceivingList GetModel(string ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            KNet.Model.Knet_Procure_ReceivingList model = new KNet.Model.Knet_Procure_ReceivingList();
            DataSet ds = DbHelperSQL.RunProcedure("Proc_Knet_Procure_ReceivingList_GetModelByID", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.ReceivNo = ds.Tables[0].Rows[0]["ReceivNo"].ToString();
                model.ReceivTopic = ds.Tables[0].Rows[0]["ReceivTopic"].ToString();
                model.OrderNo = ds.Tables[0].Rows[0]["OrderNo"].ToString();
                if (ds.Tables[0].Rows[0]["ReceivDateTime"].ToString() != "")
                {
                    model.ReceivDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["ReceivDateTime"].ToString());
                }
                model.SuppNo = ds.Tables[0].Rows[0]["SuppNo"].ToString();
                model.ReceivPaymentNotes = ds.Tables[0].Rows[0]["ReceivPaymentNotes"].ToString();
                model.ReceivStaffBranch = ds.Tables[0].Rows[0]["ReceivStaffBranch"].ToString();
                model.ReceivStaffDepart = ds.Tables[0].Rows[0]["ReceivStaffDepart"].ToString();
                model.ReceivStaffNo = ds.Tables[0].Rows[0]["ReceivStaffNo"].ToString();
                model.ReceivCheckStaffNo = ds.Tables[0].Rows[0]["ReceivCheckStaffNo"].ToString();
                model.ReceivRemarks = ds.Tables[0].Rows[0]["ReceivRemarks"].ToString();
                

                if (ds.Tables[0].Rows[0]["OrderTransShare"].ToString() != "")
                {
                    model.OrderTransShare = decimal.Parse(ds.Tables[0].Rows[0]["OrderTransShare"].ToString());
                }
                model.OrderType = ds.Tables[0].Rows[0]["OrderType"].ToString();

                if (ds.Tables[0].Rows[0]["ReceivCheckYN"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["ReceivCheckYN"].ToString() == "1") || (ds.Tables[0].Rows[0]["ReceivCheckYN"].ToString().ToLower() == "true"))
                    {
                        model.ReceivCheckYN = true;
                    }
                    else
                    {
                        model.ReceivCheckYN = false;
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
        public KNet.Model.Knet_Procure_ReceivingList GetModelB(string ReceivNo)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ReceivNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = ReceivNo;

            KNet.Model.Knet_Procure_ReceivingList model = new KNet.Model.Knet_Procure_ReceivingList();
            DataSet ds = DbHelperSQL.RunProcedure("Proc_Knet_Procure_ReceivingList_GetModelByReceivNo", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.ReceivNo = ds.Tables[0].Rows[0]["ReceivNo"].ToString();
                model.ReceivTopic = ds.Tables[0].Rows[0]["ReceivTopic"].ToString();
                model.OrderNo = ds.Tables[0].Rows[0]["OrderNo"].ToString();
                if (ds.Tables[0].Rows[0]["ReceivDateTime"].ToString() != "")
                {
                    model.ReceivDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["ReceivDateTime"].ToString());
                }
                model.SuppNo = ds.Tables[0].Rows[0]["SuppNo"].ToString();
                model.ReceivPaymentNotes = ds.Tables[0].Rows[0]["ReceivPaymentNotes"].ToString();
                model.ReceivStaffBranch = ds.Tables[0].Rows[0]["ReceivStaffBranch"].ToString();
                model.ReceivStaffDepart = ds.Tables[0].Rows[0]["ReceivStaffDepart"].ToString();
                model.ReceivStaffNo = ds.Tables[0].Rows[0]["ReceivStaffNo"].ToString();
                model.ReceivCheckStaffNo = ds.Tables[0].Rows[0]["ReceivCheckStaffNo"].ToString();
                model.ReceivRemarks = ds.Tables[0].Rows[0]["ReceivRemarks"].ToString();
        


                if (ds.Tables[0].Rows[0]["OrderTransShare"].ToString() != "")
                {
                    model.OrderTransShare = decimal.Parse(ds.Tables[0].Rows[0]["OrderTransShare"].ToString());
                }
                model.OrderType = ds.Tables[0].Rows[0]["OrderType"].ToString();

                if (ds.Tables[0].Rows[0]["ReceivCheckYN"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["ReceivCheckYN"].ToString() == "1") || (ds.Tables[0].Rows[0]["ReceivCheckYN"].ToString().ToLower() == "true"))
                    {
                        model.ReceivCheckYN = true;
                    }
                    else
                    {
                        model.ReceivCheckYN = false;
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
            strSql.Append("select ID,ReceivNo,ReceivTopic,OrderNo,ReceivDateTime,SuppNo,ReceivPaymentNotes,ReceivStaffBranch,ReceivStaffDepart,ReceivStaffNo,ReceivCheckStaffNo,ReceivRemarks,ReceivCheckYN,OrderTransShare,OrderType ");
            strSql.Append(" FROM Knet_Procure_ReceivingList ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  成员方法
    }
}

