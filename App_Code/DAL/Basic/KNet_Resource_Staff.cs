using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;

namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类KNet_Resource_Staff。
    /// </summary>
    public class KNet_Resource_Staff
    {
        public KNet_Resource_Staff()
        { }
        #region  成员方法


        /// <summary>
        /// 是否存在该记录 账号
        /// </summary>
        public bool Exists(string StaffBranch, string StaffName)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
                    new SqlParameter("@StaffBranch", SqlDbType.NVarChar,50),
					new SqlParameter("@StaffName", SqlDbType.NVarChar,50)};
            parameters[0].Value = StaffBranch;
            parameters[1].Value = StaffName;
            int result = DbHelperSQL.RunProcedure("Proc_KNet_Resource_Staff_Exists_StaffName", parameters, out rowsAffected);
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
        /// 是否存在该记录 卡号
        /// </summary>
        public bool ExistsB(string StaffBranch, string StaffCard)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
                    new SqlParameter("@StaffBranch", SqlDbType.NVarChar,50),
					new SqlParameter("@StaffCard", SqlDbType.NVarChar,50)};
            parameters[0].Value = StaffBranch;
            parameters[1].Value = StaffCard;

            int result = DbHelperSQL.RunProcedure("Proc_KNet_Resource_Staff_Exists_StaffCard", parameters, out rowsAffected);
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
        public void Add(KNet.Model.KNet_Resource_Staff model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					
					new SqlParameter("@StaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@StaffBranch", SqlDbType.NVarChar,50),
					new SqlParameter("@StaffDepart", SqlDbType.NVarChar,50),
					new SqlParameter("@StaffCard", SqlDbType.NVarChar,50),
					new SqlParameter("@StaffName", SqlDbType.NVarChar,50),
					new SqlParameter("@StaffPassword", SqlDbType.NVarChar,50),
					new SqlParameter("@Staffwages", SqlDbType.Decimal,9),
					new SqlParameter("@StaffSex", SqlDbType.Bit,1),
					new SqlParameter("@StaffTel", SqlDbType.NVarChar,50),
					new SqlParameter("@StaffEmail", SqlDbType.NVarChar,50),
					new SqlParameter("@StaffAddress", SqlDbType.NVarChar,120),
					new SqlParameter("@StaffIDCard", SqlDbType.NVarChar,30),
					new SqlParameter("@StaffAddTime", SqlDbType.DateTime),
					new SqlParameter("@StaffRemarks", SqlDbType.NText),
					new SqlParameter("@Position", SqlDbType.VarChar,50),
					new SqlParameter("@KRS_DepartPerson", SqlDbType.VarChar,50),
					new SqlParameter("@KRS_MailPassWord", SqlDbType.VarChar,50),
					new SqlParameter("@isSale", SqlDbType.Int),
					new SqlParameter("@KRS_IsWeb", SqlDbType.Int),
					new SqlParameter("@TelPhone", SqlDbType.VarChar,50),
					new SqlParameter("@ProductsType", SqlDbType.VarChar,500)
                    
                                        };
            
            parameters[0].Value = model.StaffNo;
            parameters[1].Value = model.StaffBranch;
            parameters[2].Value = model.StaffDepart;
            parameters[3].Value = model.StaffCard;
            parameters[4].Value = model.StaffName;
            parameters[5].Value = model.StaffPassword;
            parameters[6].Value = model.Staffwages;
            parameters[7].Value = model.StaffSex;
            parameters[8].Value = model.StaffTel;
            parameters[9].Value = model.StaffEmail;
            parameters[10].Value = model.StaffAddress;
            parameters[11].Value = model.StaffIDCard;
            parameters[12].Value = model.StaffAddTime;
            parameters[13].Value = model.StaffRemarks;
            parameters[14].Value = model.Position;
            parameters[15].Value = model.KRS_DepartPerson;
            parameters[16].Value = model.KRS_MailPassWord;
            parameters[17].Value = model.isSale;
            parameters[18].Value = model.KRS_IsWeb;
            parameters[19].Value = model.TelPhone;
            parameters[20].Value = model.ProductsType;
   

            DbHelperSQL.RunProcedure("Proc_KNet_Resource_Staff_ADD", parameters, out rowsAffected);
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public void Update(KNet.Model.KNet_Resource_Staff model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50),
			
					new SqlParameter("@StaffBranch", SqlDbType.NVarChar,50),
					new SqlParameter("@StaffDepart", SqlDbType.NVarChar,50),

					new SqlParameter("@StaffPassword", SqlDbType.NVarChar,50),
					new SqlParameter("@Staffwages", SqlDbType.Decimal,9),
					new SqlParameter("@StaffSex", SqlDbType.Bit,1),
					new SqlParameter("@StaffTel", SqlDbType.NVarChar,50),
					new SqlParameter("@StaffEmail", SqlDbType.NVarChar,50),
					new SqlParameter("@StaffAddress", SqlDbType.NVarChar,120),
					new SqlParameter("@StaffIDCard", SqlDbType.NVarChar,30),
					new SqlParameter("@StaffAddTime", SqlDbType.DateTime),
					new SqlParameter("@StaffRemarks", SqlDbType.NText),
					new SqlParameter("@Position", SqlDbType.NVarChar,50),
					new SqlParameter("@KRS_DepartPerson", SqlDbType.NVarChar,50),
					new SqlParameter("@KRS_MailPassWord", SqlDbType.NVarChar,50),
					new SqlParameter("@isSale", SqlDbType.Int),
					new SqlParameter("@KRS_IsWeb", SqlDbType.Int),
					new SqlParameter("@StaffName", SqlDbType.NVarChar,50),
					new SqlParameter("@StaffCard", SqlDbType.NVarChar,50),
					new SqlParameter("@TelPhone", SqlDbType.VarChar,50),
					new SqlParameter("@ProductsType", SqlDbType.VarChar,500)
                                        };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.StaffBranch;
            parameters[2].Value = model.StaffDepart;
            parameters[3].Value = model.StaffPassword;
            parameters[4].Value = model.Staffwages;
            parameters[5].Value = model.StaffSex;
            parameters[6].Value = model.StaffTel;
            parameters[7].Value = model.StaffEmail;
            parameters[8].Value = model.StaffAddress;
            parameters[9].Value = model.StaffIDCard;
            parameters[10].Value = model.StaffAddTime;
            parameters[11].Value = model.StaffRemarks;
            parameters[12].Value = model.Position;
            parameters[13].Value = model.KRS_DepartPerson;
            parameters[14].Value = model.KRS_MailPassWord;
            parameters[15].Value = model.isSale;
            parameters[16].Value = model.KRS_IsWeb;
            parameters[17].Value = model.StaffName;
            parameters[18].Value = model.StaffCard;
            parameters[19].Value = model.TelPhone;
            parameters[20].Value = model.ProductsType;
            

            DbHelperSQL.RunProcedure("Proc_KNet_Resource_Staff_Update", parameters, out rowsAffected);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateOnLine(KNet.Model.KNet_Resource_Staff model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KNet_Resource_Staff set ");
            strSql.Append("isOnline=@isOnline");
            strSql.Append(" where StaffNo=@StaffNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@isOnline", SqlDbType.Int,4),
					new SqlParameter("@StaffNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.isOnline;
            parameters[1].Value = model.StaffNo;

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
        public void Delete(string ID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            DbHelperSQL.RunProcedure("Proc_KNet_Resource_Staff_Delete", parameters, out rowsAffected);
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Resource_Staff GetModelByName(string s_Name)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from KNet_Resource_Staff ");
            strSql.Append(" where StaffName=@StaffName ");
            SqlParameter[] parameters = {
					new SqlParameter("@StaffName", SqlDbType.NVarChar,50)};
            parameters[0].Value = s_Name;

            KNet.Model.KNet_Resource_Staff model = new KNet.Model.KNet_Resource_Staff();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StaffNo"] != null && ds.Tables[0].Rows[0]["StaffNo"].ToString() != "")
                {
                    model.StaffNo = ds.Tables[0].Rows[0]["StaffNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StaffBranch"] != null && ds.Tables[0].Rows[0]["StaffBranch"].ToString() != "")
                {
                    model.StaffBranch = ds.Tables[0].Rows[0]["StaffBranch"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StaffDepart"] != null && ds.Tables[0].Rows[0]["StaffDepart"].ToString() != "")
                {
                    model.StaffDepart = ds.Tables[0].Rows[0]["StaffDepart"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StaffCard"] != null && ds.Tables[0].Rows[0]["StaffCard"].ToString() != "")
                {
                    model.StaffCard = ds.Tables[0].Rows[0]["StaffCard"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StaffName"] != null && ds.Tables[0].Rows[0]["StaffName"].ToString() != "")
                {
                    model.StaffName = ds.Tables[0].Rows[0]["StaffName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StaffPassword"] != null && ds.Tables[0].Rows[0]["StaffPassword"].ToString() != "")
                {
                    model.StaffPassword = ds.Tables[0].Rows[0]["StaffPassword"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Staffwages"] != null && ds.Tables[0].Rows[0]["Staffwages"].ToString() != "")
                {
                    model.Staffwages = decimal.Parse(ds.Tables[0].Rows[0]["Staffwages"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StaffSex"] != null && ds.Tables[0].Rows[0]["StaffSex"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["StaffSex"].ToString() == "1") || (ds.Tables[0].Rows[0]["StaffSex"].ToString().ToLower() == "true"))
                    {
                        model.StaffSex = true;
                    }
                    else
                    {
                        model.StaffSex = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["StaffTel"] != null && ds.Tables[0].Rows[0]["StaffTel"].ToString() != "")
                {
                    model.StaffTel = ds.Tables[0].Rows[0]["StaffTel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StaffEmail"] != null && ds.Tables[0].Rows[0]["StaffEmail"].ToString() != "")
                {
                    model.StaffEmail = ds.Tables[0].Rows[0]["StaffEmail"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StaffAddress"] != null && ds.Tables[0].Rows[0]["StaffAddress"].ToString() != "")
                {
                    model.StaffAddress = ds.Tables[0].Rows[0]["StaffAddress"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StaffIDCard"] != null && ds.Tables[0].Rows[0]["StaffIDCard"].ToString() != "")
                {
                    model.StaffIDCard = ds.Tables[0].Rows[0]["StaffIDCard"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StaffAddTime"] != null && ds.Tables[0].Rows[0]["StaffAddTime"].ToString() != "")
                {
                    model.StaffAddTime = DateTime.Parse(ds.Tables[0].Rows[0]["StaffAddTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StaffRemarks"] != null && ds.Tables[0].Rows[0]["StaffRemarks"].ToString() != "")
                {
                    model.StaffRemarks = ds.Tables[0].Rows[0]["StaffRemarks"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Staff_LoginIP"] != null && ds.Tables[0].Rows[0]["Staff_LoginIP"].ToString() != "")
                {
                    model.Staff_LoginIP = ds.Tables[0].Rows[0]["Staff_LoginIP"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Staff_LoginDate"] != null && ds.Tables[0].Rows[0]["Staff_LoginDate"].ToString() != "")
                {
                    model.Staff_LoginDate = DateTime.Parse(ds.Tables[0].Rows[0]["Staff_LoginDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Staff_LoginNum"] != null && ds.Tables[0].Rows[0]["Staff_LoginNum"].ToString() != "")
                {
                    model.Staff_LoginNum = long.Parse(ds.Tables[0].Rows[0]["Staff_LoginNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StaffAdmin"] != null && ds.Tables[0].Rows[0]["StaffAdmin"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["StaffAdmin"].ToString() == "1") || (ds.Tables[0].Rows[0]["StaffAdmin"].ToString().ToLower() == "true"))
                    {
                        model.StaffAdmin = true;
                    }
                    else
                    {
                        model.StaffAdmin = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["StaffYN"] != null && ds.Tables[0].Rows[0]["StaffYN"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["StaffYN"].ToString() == "1") || (ds.Tables[0].Rows[0]["StaffYN"].ToString().ToLower() == "true"))
                    {
                        model.StaffYN = true;
                    }
                    else
                    {
                        model.StaffYN = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["StaffLanguage"] != null && ds.Tables[0].Rows[0]["StaffLanguage"].ToString() != "")
                {
                    model.StaffLanguage = int.Parse(ds.Tables[0].Rows[0]["StaffLanguage"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StaffCatalogue"] != null && ds.Tables[0].Rows[0]["StaffCatalogue"].ToString() != "")
                {
                    model.StaffCatalogue = int.Parse(ds.Tables[0].Rows[0]["StaffCatalogue"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Position"] != null && ds.Tables[0].Rows[0]["Position"].ToString() != "")
                {
                    model.Position = ds.Tables[0].Rows[0]["Position"].ToString();
                }
                if (ds.Tables[0].Rows[0]["isSale"] != null && ds.Tables[0].Rows[0]["isSale"].ToString() != "")
                {
                    model.isSale = int.Parse(ds.Tables[0].Rows[0]["isSale"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KRS_IsWeb"] != null && ds.Tables[0].Rows[0]["KRS_IsWeb"].ToString() != "")
                {
                    model.KRS_IsWeb = int.Parse(ds.Tables[0].Rows[0]["KRS_IsWeb"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TelPhone"] != null && ds.Tables[0].Rows[0]["TelPhone"].ToString() != "")
                {
                    model.TelPhone = ds.Tables[0].Rows[0]["TelPhone"].ToString();
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
        public KNet.Model.KNet_Resource_Staff GetModelB(string StaffName, string KStaffPassWord)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@StaffName", SqlDbType.NVarChar,50),
					new SqlParameter("@KStaffPassWord", SqlDbType.NVarChar,50)};
            parameters[0].Value = StaffName;
            parameters[1].Value = KStaffPassWord;

            KNet.Model.KNet_Resource_Staff model = new KNet.Model.KNet_Resource_Staff();
            DataSet ds = DbHelperSQL.RunProcedure("Proc_KNet_Resource_Staff_GetModelB", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.StaffNo = ds.Tables[0].Rows[0]["StaffNo"].ToString();
                model.StaffBranch = ds.Tables[0].Rows[0]["StaffBranch"].ToString();
                model.StaffDepart = ds.Tables[0].Rows[0]["StaffDepart"].ToString();
                model.StaffCard = ds.Tables[0].Rows[0]["StaffCard"].ToString();
                model.StaffName = ds.Tables[0].Rows[0]["StaffName"].ToString();
                model.StaffPassword = ds.Tables[0].Rows[0]["StaffPassword"].ToString();
                model.Position = ds.Tables[0].Rows[0]["Position"].ToString();    
                if (ds.Tables[0].Rows[0]["StaffLanguage"].ToString() != "")
                {
                    model.StaffLanguage = int.Parse(ds.Tables[0].Rows[0]["StaffLanguage"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StaffCatalogue"].ToString() != "")
                {
                    model.StaffCatalogue = int.Parse(ds.Tables[0].Rows[0]["StaffCatalogue"].ToString());
                }

                if (ds.Tables[0].Rows[0]["Staffwages"].ToString() != "")
                {
                    model.Staffwages = decimal.Parse(ds.Tables[0].Rows[0]["Staffwages"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StaffSex"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["StaffSex"].ToString() == "1") || (ds.Tables[0].Rows[0]["StaffSex"].ToString().ToLower() == "true"))
                    {
                        model.StaffSex = true;
                    }
                    else
                    {
                        model.StaffSex = false;
                    }
                }
                model.StaffTel = ds.Tables[0].Rows[0]["StaffTel"].ToString();
                model.StaffEmail = ds.Tables[0].Rows[0]["StaffEmail"].ToString();
                model.StaffAddress = ds.Tables[0].Rows[0]["StaffAddress"].ToString();
                model.StaffIDCard = ds.Tables[0].Rows[0]["StaffIDCard"].ToString();
                if (ds.Tables[0].Rows[0]["StaffAddTime"].ToString() != "")
                {
                    model.StaffAddTime = DateTime.Parse(ds.Tables[0].Rows[0]["StaffAddTime"].ToString());
                }
                model.StaffRemarks = ds.Tables[0].Rows[0]["StaffRemarks"].ToString();
                model.Staff_LoginIP = ds.Tables[0].Rows[0]["Staff_LoginIP"].ToString();
                if (ds.Tables[0].Rows[0]["Staff_LoginDate"].ToString() != "")
                {
                    model.Staff_LoginDate = DateTime.Parse(ds.Tables[0].Rows[0]["Staff_LoginDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Staff_LoginNum"].ToString() != "")
                {
                    model.Staff_LoginNum = long.Parse(ds.Tables[0].Rows[0]["Staff_LoginNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StaffAdmin"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["StaffAdmin"].ToString() == "1") || (ds.Tables[0].Rows[0]["StaffAdmin"].ToString().ToLower() == "true"))
                    {
                        model.StaffAdmin = true;
                    }
                    else
                    {
                        model.StaffAdmin = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["isSale"].ToString() != "")
                {
                    model.isSale = int.Parse(ds.Tables[0].Rows[0]["isSale"].ToString());
                }
                else
                {
                    model.isSale = 0;
                }

                if (ds.Tables[0].Rows[0]["KRS_IsWeb"] != null && ds.Tables[0].Rows[0]["KRS_IsWeb"].ToString() != "")
                {
                    model.KRS_IsWeb = int.Parse(ds.Tables[0].Rows[0]["KRS_IsWeb"].ToString());
                }
                else
                {
                    model.KRS_IsWeb = 0;
                }
                try
                {
                    if (ds.Tables[0].Rows[0]["ProductsType"] != null && ds.Tables[0].Rows[0]["ProductsType"].ToString() != "")
                    {
                        model.ProductsType = ds.Tables[0].Rows[0]["ProductsType"].ToString();
                    }
                    else
                    {
                        model.ProductsType = "";
                    }
                }
                catch
                {
                    model.ProductsType = "";
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
        public KNet.Model.KNet_Resource_Staff GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from KNet_Resource_Staff ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            KNet.Model.KNet_Resource_Staff model = new KNet.Model.KNet_Resource_Staff();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StaffNo"] != null && ds.Tables[0].Rows[0]["StaffNo"].ToString() != "")
                {
                    model.StaffNo = ds.Tables[0].Rows[0]["StaffNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TelPhone"] != null && ds.Tables[0].Rows[0]["TelPhone"].ToString() != "")
                {
                    model.TelPhone = ds.Tables[0].Rows[0]["TelPhone"].ToString();
                }
                
                if (ds.Tables[0].Rows[0]["StaffBranch"] != null && ds.Tables[0].Rows[0]["StaffBranch"].ToString() != "")
                {
                    model.StaffBranch = ds.Tables[0].Rows[0]["StaffBranch"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StaffDepart"] != null && ds.Tables[0].Rows[0]["StaffDepart"].ToString() != "")
                {
                    model.StaffDepart = ds.Tables[0].Rows[0]["StaffDepart"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StaffCard"] != null && ds.Tables[0].Rows[0]["StaffCard"].ToString() != "")
                {
                    model.StaffCard = ds.Tables[0].Rows[0]["StaffCard"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StaffName"] != null && ds.Tables[0].Rows[0]["StaffName"].ToString() != "")
                {
                    model.StaffName = ds.Tables[0].Rows[0]["StaffName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StaffPassword"] != null && ds.Tables[0].Rows[0]["StaffPassword"].ToString() != "")
                {
                    model.StaffPassword = ds.Tables[0].Rows[0]["StaffPassword"].ToString();
                }
                else
                {
                    model.StaffPassword = "";
 
                }
                if (ds.Tables[0].Rows[0]["Staffwages"] != null && ds.Tables[0].Rows[0]["Staffwages"].ToString() != "")
                {
                    model.Staffwages = decimal.Parse(ds.Tables[0].Rows[0]["Staffwages"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StaffSex"] != null && ds.Tables[0].Rows[0]["StaffSex"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["StaffSex"].ToString() == "1") || (ds.Tables[0].Rows[0]["StaffSex"].ToString().ToLower() == "true"))
                    {
                        model.StaffSex = true;
                    }
                    else
                    {
                        model.StaffSex = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["StaffTel"] != null && ds.Tables[0].Rows[0]["StaffTel"].ToString() != "")
                {
                    model.StaffTel = ds.Tables[0].Rows[0]["StaffTel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StaffEmail"] != null && ds.Tables[0].Rows[0]["StaffEmail"].ToString() != "")
                {
                    model.StaffEmail = ds.Tables[0].Rows[0]["StaffEmail"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StaffAddress"] != null && ds.Tables[0].Rows[0]["StaffAddress"].ToString() != "")
                {
                    model.StaffAddress = ds.Tables[0].Rows[0]["StaffAddress"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StaffIDCard"] != null && ds.Tables[0].Rows[0]["StaffIDCard"].ToString() != "")
                {
                    model.StaffIDCard = ds.Tables[0].Rows[0]["StaffIDCard"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StaffAddTime"] != null && ds.Tables[0].Rows[0]["StaffAddTime"].ToString() != "")
                {
                    model.StaffAddTime = DateTime.Parse(ds.Tables[0].Rows[0]["StaffAddTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StaffRemarks"] != null && ds.Tables[0].Rows[0]["StaffRemarks"].ToString() != "")
                {
                    model.StaffRemarks = ds.Tables[0].Rows[0]["StaffRemarks"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Staff_LoginIP"] != null && ds.Tables[0].Rows[0]["Staff_LoginIP"].ToString() != "")
                {
                    model.Staff_LoginIP = ds.Tables[0].Rows[0]["Staff_LoginIP"].ToString();
                }

                if (ds.Tables[0].Rows[0]["TelPhone"] != null && ds.Tables[0].Rows[0]["TelPhone"].ToString() != "")
                {
                    model.TelPhone = ds.Tables[0].Rows[0]["TelPhone"].ToString();
                }
                
                if (ds.Tables[0].Rows[0]["Staff_LoginDate"] != null && ds.Tables[0].Rows[0]["Staff_LoginDate"].ToString() != "")
                {
                    model.Staff_LoginDate = DateTime.Parse(ds.Tables[0].Rows[0]["Staff_LoginDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Staff_LoginNum"] != null && ds.Tables[0].Rows[0]["Staff_LoginNum"].ToString() != "")
                {
                    model.Staff_LoginNum = long.Parse(ds.Tables[0].Rows[0]["Staff_LoginNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StaffAdmin"] != null && ds.Tables[0].Rows[0]["StaffAdmin"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["StaffAdmin"].ToString() == "1") || (ds.Tables[0].Rows[0]["StaffAdmin"].ToString().ToLower() == "true"))
                    {
                        model.StaffAdmin = true;
                    }
                    else
                    {
                        model.StaffAdmin = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["StaffYN"] != null && ds.Tables[0].Rows[0]["StaffYN"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["StaffYN"].ToString() == "1") || (ds.Tables[0].Rows[0]["StaffYN"].ToString().ToLower() == "true"))
                    {
                        model.StaffYN = true;
                    }
                    else
                    {
                        model.StaffYN = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["StaffLanguage"] != null && ds.Tables[0].Rows[0]["StaffLanguage"].ToString() != "")
                {
                    model.StaffLanguage = int.Parse(ds.Tables[0].Rows[0]["StaffLanguage"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StaffCatalogue"] != null && ds.Tables[0].Rows[0]["StaffCatalogue"].ToString() != "")
                {
                    model.StaffCatalogue = int.Parse(ds.Tables[0].Rows[0]["StaffCatalogue"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Position"] != null && ds.Tables[0].Rows[0]["Position"].ToString() != "")
                {
                    model.Position = ds.Tables[0].Rows[0]["Position"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KRS_DepartPerson"] != null && ds.Tables[0].Rows[0]["KRS_DepartPerson"].ToString() != "")
                {
                    model.KRS_DepartPerson = ds.Tables[0].Rows[0]["KRS_DepartPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KRS_MailPassWord"] != null && ds.Tables[0].Rows[0]["KRS_MailPassWord"].ToString() != "")
                {
                    model.KRS_MailPassWord = ds.Tables[0].Rows[0]["KRS_MailPassWord"].ToString();
                }

                if (ds.Tables[0].Rows[0]["isSale"] != null && ds.Tables[0].Rows[0]["isSale"].ToString() != "")
                {
                    model.isSale = int.Parse(ds.Tables[0].Rows[0]["isSale"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KRS_IsWeb"] != null && ds.Tables[0].Rows[0]["KRS_IsWeb"].ToString() != "")
                {
                    model.KRS_IsWeb = int.Parse(ds.Tables[0].Rows[0]["KRS_IsWeb"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductsType"] != null && ds.Tables[0].Rows[0]["ProductsType"].ToString() != "")
                {
                    model.ProductsType = ds.Tables[0].Rows[0]["ProductsType"].ToString();
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
        public KNet.Model.KNet_Resource_Staff GetModelC(string StaffNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from KNet_Resource_Staff ");
            strSql.Append(" where StaffNo=@StaffNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@StaffNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = StaffNo;

            KNet.Model.KNet_Resource_Staff model = new KNet.Model.KNet_Resource_Staff();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StaffNo"] != null && ds.Tables[0].Rows[0]["StaffNo"].ToString() != "")
                {
                    model.StaffNo = ds.Tables[0].Rows[0]["StaffNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StaffBranch"] != null && ds.Tables[0].Rows[0]["StaffBranch"].ToString() != "")
                {
                    model.StaffBranch = ds.Tables[0].Rows[0]["StaffBranch"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StaffDepart"] != null && ds.Tables[0].Rows[0]["StaffDepart"].ToString() != "")
                {
                    model.StaffDepart = ds.Tables[0].Rows[0]["StaffDepart"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StaffCard"] != null && ds.Tables[0].Rows[0]["StaffCard"].ToString() != "")
                {
                    model.StaffCard = ds.Tables[0].Rows[0]["StaffCard"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StaffName"] != null && ds.Tables[0].Rows[0]["StaffName"].ToString() != "")
                {
                    model.StaffName = ds.Tables[0].Rows[0]["StaffName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StaffPassword"] != null && ds.Tables[0].Rows[0]["StaffPassword"].ToString() != "")
                {
                    model.StaffPassword = ds.Tables[0].Rows[0]["StaffPassword"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Staffwages"] != null && ds.Tables[0].Rows[0]["Staffwages"].ToString() != "")
                {
                    model.Staffwages = decimal.Parse(ds.Tables[0].Rows[0]["Staffwages"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StaffSex"] != null && ds.Tables[0].Rows[0]["StaffSex"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["StaffSex"].ToString() == "1") || (ds.Tables[0].Rows[0]["StaffSex"].ToString().ToLower() == "true"))
                    {
                        model.StaffSex = true;
                    }
                    else
                    {
                        model.StaffSex = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["StaffTel"] != null && ds.Tables[0].Rows[0]["StaffTel"].ToString() != "")
                {
                    model.StaffTel = ds.Tables[0].Rows[0]["StaffTel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StaffEmail"] != null && ds.Tables[0].Rows[0]["StaffEmail"].ToString() != "")
                {
                    model.StaffEmail = ds.Tables[0].Rows[0]["StaffEmail"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StaffAddress"] != null && ds.Tables[0].Rows[0]["StaffAddress"].ToString() != "")
                {
                    model.StaffAddress = ds.Tables[0].Rows[0]["StaffAddress"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StaffIDCard"] != null && ds.Tables[0].Rows[0]["StaffIDCard"].ToString() != "")
                {
                    model.StaffIDCard = ds.Tables[0].Rows[0]["StaffIDCard"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StaffAddTime"] != null && ds.Tables[0].Rows[0]["StaffAddTime"].ToString() != "")
                {
                    model.StaffAddTime = DateTime.Parse(ds.Tables[0].Rows[0]["StaffAddTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StaffRemarks"] != null && ds.Tables[0].Rows[0]["StaffRemarks"].ToString() != "")
                {
                    model.StaffRemarks = ds.Tables[0].Rows[0]["StaffRemarks"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Staff_LoginIP"] != null && ds.Tables[0].Rows[0]["Staff_LoginIP"].ToString() != "")
                {
                    model.Staff_LoginIP = ds.Tables[0].Rows[0]["Staff_LoginIP"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Staff_LoginDate"] != null && ds.Tables[0].Rows[0]["Staff_LoginDate"].ToString() != "")
                {
                    model.Staff_LoginDate = DateTime.Parse(ds.Tables[0].Rows[0]["Staff_LoginDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Staff_LoginNum"] != null && ds.Tables[0].Rows[0]["Staff_LoginNum"].ToString() != "")
                {
                    model.Staff_LoginNum = long.Parse(ds.Tables[0].Rows[0]["Staff_LoginNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StaffAdmin"] != null && ds.Tables[0].Rows[0]["StaffAdmin"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["StaffAdmin"].ToString() == "1") || (ds.Tables[0].Rows[0]["StaffAdmin"].ToString().ToLower() == "true"))
                    {
                        model.StaffAdmin = true;
                    }
                    else
                    {
                        model.StaffAdmin = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["StaffYN"] != null && ds.Tables[0].Rows[0]["StaffYN"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["StaffYN"].ToString() == "1") || (ds.Tables[0].Rows[0]["StaffYN"].ToString().ToLower() == "true"))
                    {
                        model.StaffYN = true;
                    }
                    else
                    {
                        model.StaffYN = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["StaffLanguage"] != null && ds.Tables[0].Rows[0]["StaffLanguage"].ToString() != "")
                {
                    model.StaffLanguage = int.Parse(ds.Tables[0].Rows[0]["StaffLanguage"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StaffCatalogue"] != null && ds.Tables[0].Rows[0]["StaffCatalogue"].ToString() != "")
                {
                    model.StaffCatalogue = int.Parse(ds.Tables[0].Rows[0]["StaffCatalogue"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Position"] != null && ds.Tables[0].Rows[0]["Position"].ToString() != "")
                {
                    model.Position = ds.Tables[0].Rows[0]["Position"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KRS_DepartPerson"] != null && ds.Tables[0].Rows[0]["KRS_DepartPerson"].ToString() != "")
                {
                    model.KRS_DepartPerson = ds.Tables[0].Rows[0]["KRS_DepartPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KRS_MailPassWord"] != null && ds.Tables[0].Rows[0]["KRS_MailPassWord"].ToString() != "")
                {
                    model.KRS_MailPassWord = ds.Tables[0].Rows[0]["KRS_MailPassWord"].ToString();
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
            strSql.Append(" FROM KNet_Resource_Staff ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  StaffYN='0' and " + strWhere + " ");
            }

            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetList1(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM KNet_Resource_Staff ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  " + strWhere + " ");
            }

            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public string GetSonIDs(string KRS_DepartPerson)
        {
            string s_ID = KRS_DepartPerson + ",";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   * from KNet_Resource_Staff ");
            strSql.Append(" where KRS_DepartPerson=@KRS_DepartPerson ");
            SqlParameter[] parameters = {
					new SqlParameter("@KRS_DepartPerson", SqlDbType.VarChar,50)};
            parameters[0].Value = KRS_DepartPerson;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    if (ds.Tables[0].Rows[i]["StaffNo"] != null && ds.Tables[0].Rows[i]["StaffNo"].ToString() != "")
                    {
                        //s_ID += ds.Tables[0].Rows[i]["PBP_ID"].ToString() + ",";
                        s_ID += GetSonIDs(ds.Tables[0].Rows[i]["StaffNo"].ToString()) + ",";
                    }
                    else
                    {
                        s_ID += "";
                    }
                }
                s_ID = s_ID.Substring(0, s_ID.Length - 1);

                return s_ID;
            }
            else
            {
                return KRS_DepartPerson;
            }
        }
        #endregion  成员方法
    }
}

