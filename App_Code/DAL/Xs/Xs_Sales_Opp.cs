using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:Xs_Sales_Opp
    /// </summary>
    public partial class Xs_Sales_Opp
    {
        public Xs_Sales_Opp()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string XSO_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Xs_Sales_Opp");
            strSql.Append(" where XSO_ID=@XSO_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XSO_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = XSO_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Xs_Sales_Opp model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Xs_Sales_Opp(");
            strSql.Append("XSO_ID,XSO_Name,XSO_Money,XSO_CustomerValue,XSO_LinkMan,XSO_PlanDealDate,XSO_Type,XSO_NextPlan,XSO_SalesStep,XSO_Precent,XSO_Remarks,XSO_CTime,XSO_Creator,XSO_Mender,XSO_MTime,XSO_DutyPerson,XSO_FDutyPerson,XSO_History,XSO_Background,XSO_Competitor,XSO_DID,XSO_Del,XSO_SalesType)");
            strSql.Append(" values (");
            strSql.Append("@XSO_ID,@XSO_Name,@XSO_Money,@XSO_CustomerValue,@XSO_LinkMan,@XSO_PlanDealDate,@XSO_Type,@XSO_NextPlan,@XSO_SalesStep,@XSO_Precent,@XSO_Remarks,@XSO_CTime,@XSO_Creator,@XSO_Mender,@XSO_MTime,@XSO_DutyPerson,@XSO_FDutyPerson,@XSO_History,@XSO_Background,@XSO_Competitor,dbo.GetID(),@XSO_Del,@XSO_SalesType)");
            SqlParameter[] parameters = {
					new SqlParameter("@XSO_ID", SqlDbType.VarChar,50),
					new SqlParameter("@XSO_Name", SqlDbType.VarChar,50),
					new SqlParameter("@XSO_Money", SqlDbType.VarChar,50),
					new SqlParameter("@XSO_CustomerValue", SqlDbType.VarChar,50),
					new SqlParameter("@XSO_LinkMan", SqlDbType.VarChar,50),
					new SqlParameter("@XSO_PlanDealDate", SqlDbType.DateTime),
					new SqlParameter("@XSO_Type", SqlDbType.VarChar,3),
					new SqlParameter("@XSO_NextPlan", SqlDbType.VarChar,1000),
					new SqlParameter("@XSO_SalesStep", SqlDbType.VarChar,50),
					new SqlParameter("@XSO_Precent", SqlDbType.VarChar,50),
					new SqlParameter("@XSO_Remarks", SqlDbType.VarChar,3000),
					new SqlParameter("@XSO_CTime", SqlDbType.DateTime),
					new SqlParameter("@XSO_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@XSO_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@XSO_MTime", SqlDbType.DateTime),
					new SqlParameter("@XSO_DutyPerson", SqlDbType.VarChar,50),
					new SqlParameter("@XSO_FDutyPerson", SqlDbType.VarChar,50),
					new SqlParameter("@XSO_History", SqlDbType.VarChar,1000),
					new SqlParameter("@XSO_Background", SqlDbType.VarChar,1000),
					new SqlParameter("@XSO_Competitor", SqlDbType.VarChar,1000),
					new SqlParameter("@XSO_Del", SqlDbType.Int,4),
					new SqlParameter("@XSO_SalesType", SqlDbType.VarChar,50)};
            parameters[0].Value = model.XSO_ID;
            parameters[1].Value = model.XSO_Name;
            parameters[2].Value = model.XSO_Money;
            parameters[3].Value = model.XSO_CustomerValue;
            parameters[4].Value = model.XSO_LinkMan;
            parameters[5].Value = model.XSO_PlanDealDate;
            parameters[6].Value = model.XSO_Type;
            parameters[7].Value = model.XSO_NextPlan;
            parameters[8].Value = model.XSO_SalesStep;
            parameters[9].Value = model.XSO_Precent;
            parameters[10].Value = model.XSO_Remarks;
            parameters[11].Value = model.XSO_CTime;
            parameters[12].Value = model.XSO_Creator;
            parameters[13].Value = model.XSO_Mender;
            parameters[14].Value = model.XSO_MTime;
            parameters[15].Value = model.XSO_DutyPerson;
            parameters[16].Value = model.XSO_FDutyPerson;
            parameters[17].Value = model.XSO_History;
            parameters[18].Value = model.XSO_Background;
            parameters[19].Value = model.XSO_Competitor;
            parameters[20].Value = model.XSO_Del;
            parameters[21].Value = model.XSO_SalesType;
            

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Xs_Sales_Opp model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Xs_Sales_Opp set ");
            strSql.Append("XSO_Name=@XSO_Name,");
            strSql.Append("XSO_Money=@XSO_Money,");
            strSql.Append("XSO_CustomerValue=@XSO_CustomerValue,");
            strSql.Append("XSO_LinkMan=@XSO_LinkMan,");
            strSql.Append("XSO_PlanDealDate=@XSO_PlanDealDate,");
            strSql.Append("XSO_Type=@XSO_Type,");
            strSql.Append("XSO_NextPlan=@XSO_NextPlan,");
            strSql.Append("XSO_SalesStep=@XSO_SalesStep,");
            strSql.Append("XSO_Precent=@XSO_Precent,");
            strSql.Append("XSO_Remarks=@XSO_Remarks,");
            strSql.Append("XSO_Mender=@XSO_Mender,");
            strSql.Append("XSO_MTime=@XSO_MTime,");
            strSql.Append("XSO_DutyPerson=@XSO_DutyPerson ,");
            strSql.Append("XSO_FDutyPerson=@XSO_FDutyPerson,");
            strSql.Append("XSO_History=@XSO_History,");
            strSql.Append("XSO_Background=@XSO_Background,");
            strSql.Append("XSO_Competitor=@XSO_Competitor,");
            strSql.Append("XSO_SalesType=@XSO_SalesType");
            strSql.Append(" where XSO_DID=@XSO_DID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XSO_Name", SqlDbType.VarChar,50),
					new SqlParameter("@XSO_Money", SqlDbType.VarChar,50),
					new SqlParameter("@XSO_CustomerValue", SqlDbType.VarChar,50),
					new SqlParameter("@XSO_LinkMan", SqlDbType.VarChar,50),
					new SqlParameter("@XSO_PlanDealDate", SqlDbType.DateTime),
					new SqlParameter("@XSO_Type", SqlDbType.VarChar,3),
					new SqlParameter("@XSO_NextPlan", SqlDbType.VarChar,1000),
					new SqlParameter("@XSO_SalesStep", SqlDbType.VarChar,50),
					new SqlParameter("@XSO_Precent", SqlDbType.VarChar,50),
					new SqlParameter("@XSO_Remarks", SqlDbType.VarChar,3000),
					new SqlParameter("@XSO_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@XSO_MTime", SqlDbType.DateTime),
					new SqlParameter("@XSO_DutyPerson", SqlDbType.VarChar,50),
					new SqlParameter("@XSO_FDutyPerson", SqlDbType.VarChar,50),
					new SqlParameter("@XSO_History", SqlDbType.VarChar,1000),
					new SqlParameter("@XSO_Background", SqlDbType.VarChar,1000),
					new SqlParameter("@XSO_Competitor", SqlDbType.VarChar,1000),
					new SqlParameter("@XSO_SalesType", SqlDbType.VarChar,50),
					new SqlParameter("@XSO_DID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.XSO_Name;
            parameters[1].Value = model.XSO_Money;
            parameters[2].Value = model.XSO_CustomerValue;
            parameters[3].Value = model.XSO_LinkMan;
            parameters[4].Value = model.XSO_PlanDealDate;
            parameters[5].Value = model.XSO_Type;
            parameters[6].Value = model.XSO_NextPlan;
            parameters[7].Value = model.XSO_SalesStep;
            parameters[8].Value = model.XSO_Precent;
            parameters[9].Value = model.XSO_Remarks;
            parameters[10].Value = model.XSO_Mender;
            parameters[11].Value = model.XSO_MTime;
            parameters[12].Value = model.XSO_DutyPerson;
            parameters[13].Value = model.XSO_FDutyPerson;
            parameters[14].Value = model.XSO_History;
            parameters[15].Value = model.XSO_Background;
            parameters[16].Value = model.XSO_Competitor;
            parameters[17].Value = model.XSO_SalesType;
            parameters[18].Value = model.XSO_DID;

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
        public bool Delete(string XSO_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Xs_Sales_Opp ");
            strSql.Append(" where XSO_ID=@XSO_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XSO_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = XSO_ID;

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
        public bool DeleteList(string XSO_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Xs_Sales_Opp ");
            strSql.Append(" where XSO_ID in (" + XSO_IDlist + ")  ");
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
        public KNet.Model.Xs_Sales_Opp GetModel(string XSO_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Xs_Sales_Opp ");
            strSql.Append(" where XSO_DID=@XSO_DID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XSO_DID", SqlDbType.VarChar,50)};
            parameters[0].Value = XSO_ID;

            KNet.Model.Xs_Sales_Opp model = new KNet.Model.Xs_Sales_Opp();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["XSO_ID"] != null && ds.Tables[0].Rows[0]["XSO_ID"].ToString() != "")
                {
                    model.XSO_ID = ds.Tables[0].Rows[0]["XSO_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSO_DID"] != null && ds.Tables[0].Rows[0]["XSO_DID"].ToString() != "")
                {
                    model.XSO_DID = ds.Tables[0].Rows[0]["XSO_DID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSO_Name"] != null && ds.Tables[0].Rows[0]["XSO_Name"].ToString() != "")
                {
                    model.XSO_Name = ds.Tables[0].Rows[0]["XSO_Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSO_Money"] != null && ds.Tables[0].Rows[0]["XSO_Money"].ToString() != "")
                {
                    model.XSO_Money = ds.Tables[0].Rows[0]["XSO_Money"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSO_CustomerValue"] != null && ds.Tables[0].Rows[0]["XSO_CustomerValue"].ToString() != "")
                {
                    model.XSO_CustomerValue = ds.Tables[0].Rows[0]["XSO_CustomerValue"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSO_LinkMan"] != null && ds.Tables[0].Rows[0]["XSO_LinkMan"].ToString() != "")
                {
                    model.XSO_LinkMan = ds.Tables[0].Rows[0]["XSO_LinkMan"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSO_PlanDealDate"] != null && ds.Tables[0].Rows[0]["XSO_PlanDealDate"].ToString() != "")
                {
                    model.XSO_PlanDealDate = DateTime.Parse(ds.Tables[0].Rows[0]["XSO_PlanDealDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["XSO_Type"] != null && ds.Tables[0].Rows[0]["XSO_Type"].ToString() != "")
                {
                    model.XSO_Type = ds.Tables[0].Rows[0]["XSO_Type"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSO_NextPlan"] != null && ds.Tables[0].Rows[0]["XSO_NextPlan"].ToString() != "")
                {
                    model.XSO_NextPlan = ds.Tables[0].Rows[0]["XSO_NextPlan"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSO_SalesStep"] != null && ds.Tables[0].Rows[0]["XSO_SalesStep"].ToString() != "")
                {
                    model.XSO_SalesStep = ds.Tables[0].Rows[0]["XSO_SalesStep"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSO_Precent"] != null && ds.Tables[0].Rows[0]["XSO_Precent"].ToString() != "")
                {
                    model.XSO_Precent = ds.Tables[0].Rows[0]["XSO_Precent"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSO_Remarks"] != null && ds.Tables[0].Rows[0]["XSO_Remarks"].ToString() != "")
                {
                    model.XSO_Remarks = ds.Tables[0].Rows[0]["XSO_Remarks"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSO_CTime"] != null && ds.Tables[0].Rows[0]["XSO_CTime"].ToString() != "")
                {
                    model.XSO_CTime = DateTime.Parse(ds.Tables[0].Rows[0]["XSO_CTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["XSO_Creator"] != null && ds.Tables[0].Rows[0]["XSO_Creator"].ToString() != "")
                {
                    model.XSO_Creator = ds.Tables[0].Rows[0]["XSO_Creator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSO_Mender"] != null && ds.Tables[0].Rows[0]["XSO_Mender"].ToString() != "")
                {
                    model.XSO_Mender = ds.Tables[0].Rows[0]["XSO_Mender"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSO_Del"] != null && ds.Tables[0].Rows[0]["XSO_Del"].ToString() != "")
                {
                    model.XSO_Del = int.Parse(ds.Tables[0].Rows[0]["XSO_Del"].ToString());
                }
                if (ds.Tables[0].Rows[0]["XSO_DutyPerson"] != null && ds.Tables[0].Rows[0]["XSO_DutyPerson"].ToString() != "")
                {
                    model.XSO_DutyPerson = ds.Tables[0].Rows[0]["XSO_DutyPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSO_FDutyPerson"] != null && ds.Tables[0].Rows[0]["XSO_FDutyPerson"].ToString() != "")
                {
                    model.XSO_FDutyPerson = ds.Tables[0].Rows[0]["XSO_FDutyPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSO_History"] != null && ds.Tables[0].Rows[0]["XSO_History"].ToString() != "")
                {
                    model.XSO_History = ds.Tables[0].Rows[0]["XSO_History"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSO_Background"] != null && ds.Tables[0].Rows[0]["XSO_Background"].ToString() != "")
                {
                    model.XSO_Background = ds.Tables[0].Rows[0]["XSO_Background"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSO_Competitor"] != null && ds.Tables[0].Rows[0]["XSO_Competitor"].ToString() != "")
                {
                    model.XSO_Competitor = ds.Tables[0].Rows[0]["XSO_Competitor"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSO_MTime"] != null && ds.Tables[0].Rows[0]["XSO_MTime"].ToString() != "")
                {
                    model.XSO_MTime = DateTime.Parse(ds.Tables[0].Rows[0]["XSO_MTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["XSO_SalesType"] != null && ds.Tables[0].Rows[0]["XSO_SalesType"].ToString() != "")
                {
                    model.XSO_SalesType = ds.Tables[0].Rows[0]["XSO_SalesType"].ToString();
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
        public KNet.Model.Xs_Sales_Opp GetModelB(string XSO_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Xs_Sales_Opp ");
            strSql.Append(" where XSO_ID=@XSO_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XSO_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = XSO_ID;

            KNet.Model.Xs_Sales_Opp model = new KNet.Model.Xs_Sales_Opp();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["XSO_ID"] != null && ds.Tables[0].Rows[0]["XSO_ID"].ToString() != "")
                {
                    model.XSO_ID = ds.Tables[0].Rows[0]["XSO_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSO_DID"] != null && ds.Tables[0].Rows[0]["XSO_DID"].ToString() != "")
                {
                    model.XSO_DID = ds.Tables[0].Rows[0]["XSO_DID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSO_Name"] != null && ds.Tables[0].Rows[0]["XSO_Name"].ToString() != "")
                {
                    model.XSO_Name = ds.Tables[0].Rows[0]["XSO_Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSO_Money"] != null && ds.Tables[0].Rows[0]["XSO_Money"].ToString() != "")
                {
                    model.XSO_Money = ds.Tables[0].Rows[0]["XSO_Money"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSO_CustomerValue"] != null && ds.Tables[0].Rows[0]["XSO_CustomerValue"].ToString() != "")
                {
                    model.XSO_CustomerValue = ds.Tables[0].Rows[0]["XSO_CustomerValue"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSO_LinkMan"] != null && ds.Tables[0].Rows[0]["XSO_LinkMan"].ToString() != "")
                {
                    model.XSO_LinkMan = ds.Tables[0].Rows[0]["XSO_LinkMan"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSO_PlanDealDate"] != null && ds.Tables[0].Rows[0]["XSO_PlanDealDate"].ToString() != "")
                {
                    model.XSO_PlanDealDate = DateTime.Parse(ds.Tables[0].Rows[0]["XSO_PlanDealDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["XSO_Type"] != null && ds.Tables[0].Rows[0]["XSO_Type"].ToString() != "")
                {
                    model.XSO_Type = ds.Tables[0].Rows[0]["XSO_Type"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSO_NextPlan"] != null && ds.Tables[0].Rows[0]["XSO_NextPlan"].ToString() != "")
                {
                    model.XSO_NextPlan = ds.Tables[0].Rows[0]["XSO_NextPlan"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSO_SalesStep"] != null && ds.Tables[0].Rows[0]["XSO_SalesStep"].ToString() != "")
                {
                    model.XSO_SalesStep = ds.Tables[0].Rows[0]["XSO_SalesStep"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSO_Precent"] != null && ds.Tables[0].Rows[0]["XSO_Precent"].ToString() != "")
                {
                    model.XSO_Precent = ds.Tables[0].Rows[0]["XSO_Precent"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSO_Remarks"] != null && ds.Tables[0].Rows[0]["XSO_Remarks"].ToString() != "")
                {
                    model.XSO_Remarks = ds.Tables[0].Rows[0]["XSO_Remarks"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSO_CTime"] != null && ds.Tables[0].Rows[0]["XSO_CTime"].ToString() != "")
                {
                    model.XSO_CTime = DateTime.Parse(ds.Tables[0].Rows[0]["XSO_CTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["XSO_Creator"] != null && ds.Tables[0].Rows[0]["XSO_Creator"].ToString() != "")
                {
                    model.XSO_Creator = ds.Tables[0].Rows[0]["XSO_Creator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSO_Mender"] != null && ds.Tables[0].Rows[0]["XSO_Mender"].ToString() != "")
                {
                    model.XSO_Mender = ds.Tables[0].Rows[0]["XSO_Mender"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSO_Del"] != null && ds.Tables[0].Rows[0]["XSO_Del"].ToString() != "")
                {
                    model.XSO_Del = int.Parse(ds.Tables[0].Rows[0]["XSO_Del"].ToString());
                }
                if (ds.Tables[0].Rows[0]["XSO_DutyPerson"] != null && ds.Tables[0].Rows[0]["XSO_DutyPerson"].ToString() != "")
                {
                    model.XSO_DutyPerson = ds.Tables[0].Rows[0]["XSO_DutyPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSO_FDutyPerson"] != null && ds.Tables[0].Rows[0]["XSO_FDutyPerson"].ToString() != "")
                {
                    model.XSO_FDutyPerson = ds.Tables[0].Rows[0]["XSO_FDutyPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSO_History"] != null && ds.Tables[0].Rows[0]["XSO_History"].ToString() != "")
                {
                    model.XSO_History = ds.Tables[0].Rows[0]["XSO_History"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSO_Background"] != null && ds.Tables[0].Rows[0]["XSO_Background"].ToString() != "")
                {
                    model.XSO_Background = ds.Tables[0].Rows[0]["XSO_Background"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSO_Competitor"] != null && ds.Tables[0].Rows[0]["XSO_Competitor"].ToString() != "")
                {
                    model.XSO_Competitor = ds.Tables[0].Rows[0]["XSO_Competitor"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSO_MTime"] != null && ds.Tables[0].Rows[0]["XSO_MTime"].ToString() != "")
                {
                    model.XSO_MTime = DateTime.Parse(ds.Tables[0].Rows[0]["XSO_MTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["XSO_SalesType"] != null && ds.Tables[0].Rows[0]["XSO_SalesType"].ToString() != "")
                {
                    model.XSO_SalesType = ds.Tables[0].Rows[0]["XSO_SalesType"].ToString();
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
        public string GetOPPName(string XSO_DID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Xs_Sales_Opp ");
            strSql.Append(" where XSO_DID=@XSO_DID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XSO_DID", SqlDbType.VarChar,50)};
            parameters[0].Value = XSO_DID;

            KNet.Model.Xs_Sales_Opp model = new KNet.Model.Xs_Sales_Opp();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["XSO_Name"] != null && ds.Tables[0].Rows[0]["XSO_Name"].ToString() != "")
                {
                    model.XSO_Name = ds.Tables[0].Rows[0]["XSO_Name"].ToString();
                }
                return model.XSO_Name;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Xs_Sales_Opp ");
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
            strSql.Append(" FROM Xs_Sales_Opp ");
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
            parameters[0].Value = "Xs_Sales_Opp";
            parameters[1].Value = "XSO_ID";
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

