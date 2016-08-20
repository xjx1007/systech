using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:XS_Compy_LinkMan
    /// </summary>
    public partial class XS_Compy_LinkMan
    {
        public XS_Compy_LinkMan()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string XOL_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from XS_Compy_LinkMan");
            strSql.Append(" where XOL_ID=@XOL_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XOL_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = XOL_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsLinkMan(string XOL_Name, string XOL_CustomerValue, string XOL_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from XS_Compy_LinkMan");
            strSql.Append(" where XOL_Compy=@XOL_Compy and XOL_Name=@XOL_Name and XOL_ID<>@XOL_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XOL_Compy", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Name", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = XOL_CustomerValue;
            parameters[1].Value = XOL_Name;
            parameters[2].Value = XOL_ID;
            

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.XS_Compy_LinkMan model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into XS_Compy_LinkMan(");
            strSql.Append("XOL_ID,XOL_Compy,XOL_Name,XOL_Phone,XOL_Mail,XOL_Duty,XOL_Sex,XOL_Age,XOL_Birthday,XOL_Place,XOL_Nation,XOL_Marriage,XOL_Officephone,XOL_Homephone,XOL_Fax,XOL_Education,XOL_Experience,XOL_Responsible,XOL_Hobby,XOL_Address,XOL_LogisticsAddress,XOL_Evaluation,XOL_Remark,XOL_Del,XOL_CDate,XOL_Creator,XOL_MDate,XOL_Mender,XOL_QQ,XOL_Code,XOL_CallName,XOL_EnglishName,XOL_Manager,XOL_DutyPerson,XOL_Type,XOL_Province,XOL_City,XOL_ChkResponsible,XOL_Card,XOL_PassWord)");
            strSql.Append(" values (");
            strSql.Append("@XOL_ID,@XOL_Compy,@XOL_Name,@XOL_Phone,@XOL_Mail,@XOL_Duty,@XOL_Sex,@XOL_Age,@XOL_Birthday,@XOL_Place,@XOL_Nation,@XOL_Marriage,@XOL_Officephone,@XOL_Homephone,@XOL_Fax,@XOL_Education,@XOL_Experience,@XOL_Responsible,@XOL_Hobby,@XOL_Address,@XOL_LogisticsAddress,@XOL_Evaluation,@XOL_Remark,@XOL_Del,@XOL_CDate,@XOL_Creator,@XOL_MDate,@XOL_Mender,@XOL_QQ,@XOL_Code,@XOL_CallName,@XOL_EnglishName,@XOL_Manager,@XOL_DutyPerson,@XOL_Type,@XOL_Province,@XOL_City,@XOL_ChkResponsible,@XOL_Card,@XOL_PassWord)");
            SqlParameter[] parameters = {
					new SqlParameter("@XOL_ID", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Compy", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Name", SqlDbType.VarChar,20),
					new SqlParameter("@XOL_Phone", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Mail", SqlDbType.VarChar,128),
					new SqlParameter("@XOL_Duty", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Sex", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Age", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Birthday", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Place", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Nation", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Marriage", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Officephone", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Homephone", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Fax", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Education", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Experience", SqlDbType.VarChar,2000),
					new SqlParameter("@XOL_Responsible", SqlDbType.VarChar,2000),
					new SqlParameter("@XOL_Hobby", SqlDbType.VarChar,2000),
					new SqlParameter("@XOL_Address", SqlDbType.VarChar,200),
					new SqlParameter("@XOL_LogisticsAddress", SqlDbType.VarChar,200),
					new SqlParameter("@XOL_Evaluation", SqlDbType.VarChar,2000),
					new SqlParameter("@XOL_Remark", SqlDbType.VarChar,2000),
					new SqlParameter("@XOL_Del", SqlDbType.Int,4),
					new SqlParameter("@XOL_CDate", SqlDbType.DateTime),
					new SqlParameter("@XOL_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_MDate", SqlDbType.DateTime),
					new SqlParameter("@XOL_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_QQ", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Code", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_CallName", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_EnglishName", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Manager", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_DutyPerson", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Type", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Province", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_City", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_ChkResponsible", SqlDbType.VarChar,500),
					new SqlParameter("@XOL_Card", SqlDbType.VarChar,500),
					new SqlParameter("@XOL_PassWord", SqlDbType.VarChar,500)};
            parameters[0].Value = model.XOL_ID;
            parameters[1].Value = model.XOL_Compy;
            parameters[2].Value = model.XOL_Name;
            parameters[3].Value = model.XOL_Phone;
            parameters[4].Value = model.XOL_Mail;
            parameters[5].Value = model.XOL_Duty;
            parameters[6].Value = model.XOL_Sex;
            parameters[7].Value = model.XOL_Age;
            parameters[8].Value = model.XOL_Birthday;
            parameters[9].Value = model.XOL_Place;
            parameters[10].Value = model.XOL_Nation;
            parameters[11].Value = model.XOL_Marriage;
            parameters[12].Value = model.XOL_Officephone;
            parameters[13].Value = model.XOL_Homephone;
            parameters[14].Value = model.XOL_Fax;
            parameters[15].Value = model.XOL_Education;
            parameters[16].Value = model.XOL_Experience;
            parameters[17].Value = model.XOL_Responsible;
            parameters[18].Value = model.XOL_Hobby;
            parameters[19].Value = model.XOL_Address;
            parameters[20].Value = model.XOL_LogisticsAddress;
            parameters[21].Value = model.XOL_Evaluation;
            parameters[22].Value = model.XOL_Remark;
            parameters[23].Value = model.XOL_Del;
            parameters[24].Value = model.XOL_CDate;
            parameters[25].Value = model.XOL_Creator;
            parameters[26].Value = model.XOL_MDate;
            parameters[27].Value = model.XOL_Mender;
            parameters[28].Value = model.XOL_QQ;
            parameters[29].Value = model.XOL_Code;
            parameters[30].Value = model.XOL_CallName;
            parameters[31].Value = model.XOL_EnglishName;
            parameters[32].Value = model.XOL_Manager;
            parameters[33].Value = model.XOL_DutyPerson;
            parameters[34].Value = model.XOL_Type;
            parameters[35].Value = model.XOL_Province;
            parameters[36].Value = model.XOL_City;
            parameters[37].Value = model.XOL_ChkResponsible;
            parameters[38].Value = model.XOL_Card;
            parameters[39].Value = model.XOL_PassWord;
            
            
            
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.XS_Compy_LinkMan model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update XS_Compy_LinkMan set ");
            strSql.Append("XOL_Compy=@XOL_Compy,");
            strSql.Append("XOL_Name=@XOL_Name,");
            strSql.Append("XOL_Phone=@XOL_Phone,");
            strSql.Append("XOL_Mail=@XOL_Mail,");
            strSql.Append("XOL_Duty=@XOL_Duty,");
            strSql.Append("XOL_Sex=@XOL_Sex,");
            strSql.Append("XOL_Age=@XOL_Age,");
            strSql.Append("XOL_Birthday=@XOL_Birthday,");
            strSql.Append("XOL_Place=@XOL_Place,");
            strSql.Append("XOL_Nation=@XOL_Nation,");
            strSql.Append("XOL_Marriage=@XOL_Marriage,");
            strSql.Append("XOL_Officephone=@XOL_Officephone,");
            strSql.Append("XOL_Homephone=@XOL_Homephone,");
            strSql.Append("XOL_Fax=@XOL_Fax,");
            strSql.Append("XOL_Education=@XOL_Education,");
            strSql.Append("XOL_Experience=@XOL_Experience,");
            strSql.Append("XOL_Responsible=@XOL_Responsible,");
            strSql.Append("XOL_Hobby=@XOL_Hobby,");
            strSql.Append("XOL_Address=@XOL_Address,");
            strSql.Append("XOL_LogisticsAddress=@XOL_LogisticsAddress,");
            strSql.Append("XOL_Evaluation=@XOL_Evaluation,");
            strSql.Append("XOL_Remark=@XOL_Remark,");
            strSql.Append("XOL_Del=@XOL_Del,");
            strSql.Append("XOL_MDate=@XOL_MDate,");
            strSql.Append("XOL_Mender=@XOL_Mender,");
            strSql.Append("XOL_QQ=@XOL_QQ,");
            strSql.Append("XOL_Code=@XOL_Code,");
            strSql.Append("XOL_CallName=@XOL_CallName,");
            strSql.Append("XOL_EnglishName=@XOL_EnglishName,");
            strSql.Append("XOL_DutyPerson=@XOL_DutyPerson,");
            strSql.Append("XOL_Manager=@XOL_Manager,");
            strSql.Append("XOL_Province=@XOL_Province,");
            strSql.Append("XOL_City=@XOL_City,");
            strSql.Append("XOL_ChkResponsible=@XOL_ChkResponsible,");
            strSql.Append("XOL_Card=@XOL_Card,");
            strSql.Append("XOL_PassWord=@XOL_PassWord,");
            
            strSql.Append("XOL_Type=@XOL_Type ");
            strSql.Append(" where XOL_ID=@XOL_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XOL_Compy", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Name", SqlDbType.VarChar,20),
					new SqlParameter("@XOL_Phone", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Mail", SqlDbType.VarChar,128),
					new SqlParameter("@XOL_Duty", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Sex", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Age", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Birthday", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Place", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Nation", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Marriage", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Officephone", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Homephone", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Fax", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Education", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Experience", SqlDbType.VarChar,2000),
					new SqlParameter("@XOL_Responsible", SqlDbType.VarChar,2000),
					new SqlParameter("@XOL_Hobby", SqlDbType.VarChar,2000),
					new SqlParameter("@XOL_Address", SqlDbType.VarChar,200),
					new SqlParameter("@XOL_LogisticsAddress", SqlDbType.VarChar,200),
					new SqlParameter("@XOL_Evaluation", SqlDbType.VarChar,2000),
					new SqlParameter("@XOL_Remark", SqlDbType.VarChar,2000),
					new SqlParameter("@XOL_Del", SqlDbType.Int,4),
					new SqlParameter("@XOL_MDate", SqlDbType.DateTime),
					new SqlParameter("@XOL_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_QQ", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Code", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_CallName", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_EnglishName", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_DutyPerson", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Manager", SqlDbType.VarChar,50),

					new SqlParameter("@XOL_Province", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_City", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_ChkResponsible", SqlDbType.VarChar,500),
					new SqlParameter("@XOL_Card", SqlDbType.VarChar,500),
					new SqlParameter("@XOL_PassWord", SqlDbType.VarChar,500),
                    
					new SqlParameter("@XOL_Type", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.XOL_Compy;
            parameters[1].Value = model.XOL_Name;
            parameters[2].Value = model.XOL_Phone;
            parameters[3].Value = model.XOL_Mail;
            parameters[4].Value = model.XOL_Duty;
            parameters[5].Value = model.XOL_Sex;
            parameters[6].Value = model.XOL_Age;
            parameters[7].Value = model.XOL_Birthday;
            parameters[8].Value = model.XOL_Place;
            parameters[9].Value = model.XOL_Nation;
            parameters[10].Value = model.XOL_Marriage;
            parameters[11].Value = model.XOL_Officephone;
            parameters[12].Value = model.XOL_Homephone;
            parameters[13].Value = model.XOL_Fax;
            parameters[14].Value = model.XOL_Education;
            parameters[15].Value = model.XOL_Experience;
            parameters[16].Value = model.XOL_Responsible;
            parameters[17].Value = model.XOL_Hobby;
            parameters[18].Value = model.XOL_Address;
            parameters[19].Value = model.XOL_LogisticsAddress;
            parameters[20].Value = model.XOL_Evaluation;
            parameters[21].Value = model.XOL_Remark;
            parameters[22].Value = model.XOL_Del;
            parameters[23].Value = model.XOL_MDate;
            parameters[24].Value = model.XOL_Mender;
            parameters[25].Value = model.XOL_QQ;
            parameters[26].Value = model.XOL_Code;
            parameters[27].Value = model.XOL_CallName;
            parameters[28].Value = model.XOL_EnglishName;
            parameters[29].Value = model.XOL_DutyPerson;
            parameters[30].Value = model.XOL_Manager;
            parameters[31].Value = model.XOL_Province;
            parameters[32].Value = model.XOL_City;
            parameters[33].Value = model.XOL_ChkResponsible;
            parameters[34].Value = model.XOL_Card;
            parameters[35].Value = model.XOL_PassWord;
            
            parameters[36].Value = model.XOL_Type;
            parameters[37].Value = model.XOL_ID;

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
        public bool UpdateB(KNet.Model.XS_Compy_LinkMan model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update XS_Compy_LinkMan set ");
            strSql.Append("XOL_Compy=@XOL_Compy,");
            strSql.Append("XOL_Name=@XOL_Name,");
            strSql.Append("XOL_Phone=@XOL_Phone,");
            strSql.Append("XOL_Mail=@XOL_Mail,");
            strSql.Append("XOL_Duty=@XOL_Duty,");
            strSql.Append("XOL_Sex=@XOL_Sex,");
            strSql.Append("XOL_Age=@XOL_Age,");
            strSql.Append("XOL_Birthday=@XOL_Birthday,");
            strSql.Append("XOL_Place=@XOL_Place,");
            strSql.Append("XOL_Nation=@XOL_Nation,");
            strSql.Append("XOL_Marriage=@XOL_Marriage,");
            strSql.Append("XOL_Officephone=@XOL_Officephone,");
            strSql.Append("XOL_Homephone=@XOL_Homephone,");
            strSql.Append("XOL_Fax=@XOL_Fax,");
            strSql.Append("XOL_Education=@XOL_Education,");
            strSql.Append("XOL_Experience=@XOL_Experience,");
            strSql.Append("XOL_Responsible=@XOL_Responsible,");
            strSql.Append("XOL_Hobby=@XOL_Hobby,");
            strSql.Append("XOL_Address=@XOL_Address,");
            strSql.Append("XOL_LogisticsAddress=@XOL_LogisticsAddress,");
            strSql.Append("XOL_Evaluation=@XOL_Evaluation,");
            strSql.Append("XOL_Remark=@XOL_Remark,");
            strSql.Append("XOL_Del=@XOL_Del,");
            strSql.Append("XOL_MDate=@XOL_MDate,");

            strSql.Append("XOL_Province=@XOL_Province,");
            strSql.Append("XOL_City=@XOL_City,");
            strSql.Append("XOL_ChkResponsible=@XOL_ChkResponsible,");
            
            strSql.Append("XOL_Mender=@XOL_Mender");
            strSql.Append(" where XOL_ID=@XOL_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XOL_Compy", SqlDbType.VarChar,16),
					new SqlParameter("@XOL_Name", SqlDbType.VarChar,20),
					new SqlParameter("@XOL_Phone", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Mail", SqlDbType.VarChar,128),
					new SqlParameter("@XOL_Duty", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Sex", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Age", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Birthday", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Place", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Nation", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Marriage", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Officephone", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Homephone", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Fax", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Education", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_Experience", SqlDbType.VarChar,2000),
					new SqlParameter("@XOL_Responsible", SqlDbType.VarChar,2000),
					new SqlParameter("@XOL_Hobby", SqlDbType.VarChar,2000),
					new SqlParameter("@XOL_Address", SqlDbType.VarChar,200),
					new SqlParameter("@XOL_LogisticsAddress", SqlDbType.VarChar,200),
					new SqlParameter("@XOL_Evaluation", SqlDbType.VarChar,2000),
					new SqlParameter("@XOL_Remark", SqlDbType.VarChar,2000),
					new SqlParameter("@XOL_Del", SqlDbType.Int,4),
					new SqlParameter("@XOL_MDate", SqlDbType.DateTime),
                    
					new SqlParameter("@XOL_Province", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_City", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_ChkResponsible", SqlDbType.VarChar,500),
                    
					new SqlParameter("@XOL_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@XOL_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.XOL_Compy;
            parameters[1].Value = model.XOL_Name;
            parameters[2].Value = model.XOL_Phone;
            parameters[3].Value = model.XOL_Mail;
            parameters[4].Value = model.XOL_Duty;
            parameters[5].Value = model.XOL_Sex;
            parameters[6].Value = model.XOL_Age;
            parameters[7].Value = model.XOL_Birthday;
            parameters[8].Value = model.XOL_Place;
            parameters[9].Value = model.XOL_Nation;
            parameters[10].Value = model.XOL_Marriage;
            parameters[11].Value = model.XOL_Officephone;
            parameters[12].Value = model.XOL_Homephone;
            parameters[13].Value = model.XOL_Fax;
            parameters[14].Value = model.XOL_Education;
            parameters[15].Value = model.XOL_Experience;
            parameters[16].Value = model.XOL_Responsible;
            parameters[17].Value = model.XOL_Hobby;
            parameters[18].Value = model.XOL_Address;
            parameters[19].Value = model.XOL_LogisticsAddress;
            parameters[20].Value = model.XOL_Evaluation;
            parameters[21].Value = model.XOL_Remark;
            parameters[22].Value = model.XOL_Del;
            parameters[23].Value = model.XOL_MDate;

            parameters[24].Value = model.XOL_Province;
            parameters[25].Value = model.XOL_City;
            parameters[26].Value = model.XOL_ChkResponsible;

            parameters[27].Value = model.XOL_Mender;
            parameters[28].Value = model.XOL_ID;

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
        public bool Delete(string XOL_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from XS_Compy_LinkMan ");
            strSql.Append(" where XOL_ID=@XOL_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XOL_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = XOL_ID;

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
        public bool DeleteList(string XOL_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from XS_Compy_LinkMan ");
            strSql.Append(" where XOL_ID in (" + XOL_IDlist + ")  ");
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
        public KNet.Model.XS_Compy_LinkMan GetModel(string XOL_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from XS_Compy_LinkMan ");
            strSql.Append(" where XOL_ID=@XOL_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XOL_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = XOL_ID;

            KNet.Model.XS_Compy_LinkMan model = new KNet.Model.XS_Compy_LinkMan();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["XOL_ID"] != null && ds.Tables[0].Rows[0]["XOL_ID"].ToString() != "")
                {
                    model.XOL_ID = ds.Tables[0].Rows[0]["XOL_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XOL_Compy"] != null && ds.Tables[0].Rows[0]["XOL_Compy"].ToString() != "")
                {
                    model.XOL_Compy = ds.Tables[0].Rows[0]["XOL_Compy"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XOL_Name"] != null && ds.Tables[0].Rows[0]["XOL_Name"].ToString() != "")
                {
                    model.XOL_Name = ds.Tables[0].Rows[0]["XOL_Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XOL_Phone"] != null && ds.Tables[0].Rows[0]["XOL_Phone"].ToString() != "")
                {
                    model.XOL_Phone = ds.Tables[0].Rows[0]["XOL_Phone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XOL_Mail"] != null && ds.Tables[0].Rows[0]["XOL_Mail"].ToString() != "")
                {
                    model.XOL_Mail = ds.Tables[0].Rows[0]["XOL_Mail"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XOL_Duty"] != null && ds.Tables[0].Rows[0]["XOL_Duty"].ToString() != "")
                {
                    model.XOL_Duty = ds.Tables[0].Rows[0]["XOL_Duty"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XOL_Sex"] != null && ds.Tables[0].Rows[0]["XOL_Sex"].ToString() != "")
                {
                    model.XOL_Sex = ds.Tables[0].Rows[0]["XOL_Sex"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XOL_Age"] != null && ds.Tables[0].Rows[0]["XOL_Age"].ToString() != "")
                {
                    model.XOL_Age = ds.Tables[0].Rows[0]["XOL_Age"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XOL_Birthday"] != null && ds.Tables[0].Rows[0]["XOL_Birthday"].ToString() != "")
                {
                    model.XOL_Birthday = ds.Tables[0].Rows[0]["XOL_Birthday"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XOL_Place"] != null && ds.Tables[0].Rows[0]["XOL_Place"].ToString() != "")
                {
                    model.XOL_Place = ds.Tables[0].Rows[0]["XOL_Place"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XOL_Nation"] != null && ds.Tables[0].Rows[0]["XOL_Nation"].ToString() != "")
                {
                    model.XOL_Nation = ds.Tables[0].Rows[0]["XOL_Nation"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XOL_Marriage"] != null && ds.Tables[0].Rows[0]["XOL_Marriage"].ToString() != "")
                {
                    model.XOL_Marriage = ds.Tables[0].Rows[0]["XOL_Marriage"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XOL_Officephone"] != null && ds.Tables[0].Rows[0]["XOL_Officephone"].ToString() != "")
                {
                    model.XOL_Officephone = ds.Tables[0].Rows[0]["XOL_Officephone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XOL_Homephone"] != null && ds.Tables[0].Rows[0]["XOL_Homephone"].ToString() != "")
                {
                    model.XOL_Homephone = ds.Tables[0].Rows[0]["XOL_Homephone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XOL_Fax"] != null && ds.Tables[0].Rows[0]["XOL_Fax"].ToString() != "")
                {
                    model.XOL_Fax = ds.Tables[0].Rows[0]["XOL_Fax"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XOL_Education"] != null && ds.Tables[0].Rows[0]["XOL_Education"].ToString() != "")
                {
                    model.XOL_Education = ds.Tables[0].Rows[0]["XOL_Education"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XOL_Experience"] != null && ds.Tables[0].Rows[0]["XOL_Experience"].ToString() != "")
                {
                    model.XOL_Experience = ds.Tables[0].Rows[0]["XOL_Experience"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XOL_Responsible"] != null && ds.Tables[0].Rows[0]["XOL_Responsible"].ToString() != "")
                {
                    model.XOL_Responsible = ds.Tables[0].Rows[0]["XOL_Responsible"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XOL_Hobby"] != null && ds.Tables[0].Rows[0]["XOL_Hobby"].ToString() != "")
                {
                    model.XOL_Hobby = ds.Tables[0].Rows[0]["XOL_Hobby"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XOL_Address"] != null && ds.Tables[0].Rows[0]["XOL_Address"].ToString() != "")
                {
                    model.XOL_Address = ds.Tables[0].Rows[0]["XOL_Address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XOL_LogisticsAddress"] != null && ds.Tables[0].Rows[0]["XOL_LogisticsAddress"].ToString() != "")
                {
                    model.XOL_LogisticsAddress = ds.Tables[0].Rows[0]["XOL_LogisticsAddress"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XOL_Evaluation"] != null && ds.Tables[0].Rows[0]["XOL_Evaluation"].ToString() != "")
                {
                    model.XOL_Evaluation = ds.Tables[0].Rows[0]["XOL_Evaluation"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XOL_Remark"] != null && ds.Tables[0].Rows[0]["XOL_Remark"].ToString() != "")
                {
                    model.XOL_Remark = ds.Tables[0].Rows[0]["XOL_Remark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XOL_Del"] != null && ds.Tables[0].Rows[0]["XOL_Del"].ToString() != "")
                {
                    model.XOL_Del = int.Parse(ds.Tables[0].Rows[0]["XOL_Del"].ToString());
                }
                if (ds.Tables[0].Rows[0]["XOL_CDate"] != null && ds.Tables[0].Rows[0]["XOL_CDate"].ToString() != "")
                {
                    model.XOL_CDate = DateTime.Parse(ds.Tables[0].Rows[0]["XOL_CDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["XOL_Creator"] != null && ds.Tables[0].Rows[0]["XOL_Creator"].ToString() != "")
                {
                    model.XOL_Creator = ds.Tables[0].Rows[0]["XOL_Creator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XOL_MDate"] != null && ds.Tables[0].Rows[0]["XOL_MDate"].ToString() != "")
                {
                    model.XOL_MDate = DateTime.Parse(ds.Tables[0].Rows[0]["XOL_MDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["XOL_Mender"] != null && ds.Tables[0].Rows[0]["XOL_Mender"].ToString() != "")
                {
                    model.XOL_Mender = ds.Tables[0].Rows[0]["XOL_Mender"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XOL_QQ"] != null && ds.Tables[0].Rows[0]["XOL_QQ"].ToString() != "")
                {
                    model.XOL_QQ = ds.Tables[0].Rows[0]["XOL_QQ"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XOL_Code"] != null && ds.Tables[0].Rows[0]["XOL_Code"].ToString() != "")
                {
                    model.XOL_Code = ds.Tables[0].Rows[0]["XOL_Code"].ToString();
                }

                if (ds.Tables[0].Rows[0]["XOL_CallName"] != null && ds.Tables[0].Rows[0]["XOL_CallName"].ToString() != "")
                {
                    model.XOL_CallName = ds.Tables[0].Rows[0]["XOL_CallName"].ToString();
                }

                if (ds.Tables[0].Rows[0]["XOL_EnglishName"] != null && ds.Tables[0].Rows[0]["XOL_EnglishName"].ToString() != "")
                {
                    model.XOL_EnglishName = ds.Tables[0].Rows[0]["XOL_EnglishName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XOL_Manager"] != null && ds.Tables[0].Rows[0]["XOL_Manager"].ToString() != "")
                {
                    model.XOL_Manager = ds.Tables[0].Rows[0]["XOL_Manager"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XOL_DutyPerson"] != null && ds.Tables[0].Rows[0]["XOL_DutyPerson"].ToString() != "")
                {
                    model.XOL_DutyPerson = ds.Tables[0].Rows[0]["XOL_DutyPerson"].ToString();
                }

                if (ds.Tables[0].Rows[0]["XOL_Province"] != null && ds.Tables[0].Rows[0]["XOL_Province"].ToString() != "")
                {
                    model.XOL_Province = ds.Tables[0].Rows[0]["XOL_Province"].ToString();
                }

                if (ds.Tables[0].Rows[0]["XOL_City"] != null && ds.Tables[0].Rows[0]["XOL_City"].ToString() != "")
                {
                    model.XOL_City = ds.Tables[0].Rows[0]["XOL_City"].ToString();
                }

                if (ds.Tables[0].Rows[0]["XOL_ChkResponsible"] != null && ds.Tables[0].Rows[0]["XOL_ChkResponsible"].ToString() != "")
                {
                    model.XOL_ChkResponsible = ds.Tables[0].Rows[0]["XOL_ChkResponsible"].ToString();
                }

                if (ds.Tables[0].Rows[0]["XOL_Card"] != null && ds.Tables[0].Rows[0]["XOL_Card"].ToString() != "")
                {
                    model.XOL_Card = ds.Tables[0].Rows[0]["XOL_Card"].ToString();
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
            strSql.Append(" FROM XS_Compy_LinkMan ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  XOL_Del=0 and  " + strWhere);
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
            strSql.Append(" FROM XS_Compy_LinkMan ");
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
            parameters[0].Value = "XS_Compy_LinkMan";
            parameters[1].Value = "XOL_ID";
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

