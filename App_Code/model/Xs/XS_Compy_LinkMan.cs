using System;
namespace KNet.Model
{
    /// <summary>
    /// XS_Compy_LinkMan:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class XS_Compy_LinkMan
    {
        public XS_Compy_LinkMan()
        { }
        #region Model
        private string _xol_id = "newid";
        private string _xol_compy;
        private string _xol_name;
        private string _xol_phone;
        private string _xol_mail;
        private string _xol_duty;
        private string _xol_sex;
        private string _xol_age;
        private string _xol_birthday;
        private string _xol_place;
        private string _xol_nation;
        private string _xol_marriage;
        private string _xol_officephone;
        private string _xol_homephone;
        private string _xol_fax;
        private string _xol_education;
        private string _xol_experience;
        private string _xol_responsible;
        private string _xol_hobby;
        private string _xol_address;
        private string _xol_logisticsaddress;
        private string _xol_evaluation;
        private string _xol_remark;
        private int? _xol_del;
        private DateTime? _xol_cdate;
        private string _xol_creator;
        private DateTime? _xol_mdate;
        private string _xol_mender;
        private string _xol_qq;
        private string _XOL_Code;
        private string _XOL_CallName;
        private string _XOL_EnglishName;
        private string _XOL_Manager;
        private string _XOL_DutyPerson;
        private string _XOL_Type;
        private string _XOL_Province;
        private string _XOL_City;
        private string _XOL_ChkResponsible;
        private string _XOL_Card;
        private string _XOL_PassWord;
        /// <summary>
        /// 主键
        /// </summary>
        public string XOL_ID
        {
            set { _xol_id = value; }
            get { return _xol_id; }
        }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string XOL_Compy
        {
            set { _xol_compy = value; }
            get { return _xol_compy; }
        }
        /// <summary>
        /// 联系人
        /// </summary>
        public string XOL_Name
        {
            set { _xol_name = value; }
            get { return _xol_name; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string XOL_Phone
        {
            set { _xol_phone = value; }
            get { return _xol_phone; }
        }
        /// <summary>
        /// Email
        /// </summary>
        public string XOL_Mail
        {
            set { _xol_mail = value; }
            get { return _xol_mail; }
        }
        /// <summary>
        /// 职位
        /// </summary>
        public string XOL_Duty
        {
            set { _xol_duty = value; }
            get { return _xol_duty; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public string XOL_Sex
        {
            set { _xol_sex = value; }
            get { return _xol_sex; }
        }
        /// <summary>
        /// 年龄
        /// </summary>
        public string XOL_Age
        {
            set { _xol_age = value; }
            get { return _xol_age; }
        }
        /// <summary>
        /// 生日
        /// </summary>
        public string XOL_Birthday
        {
            set { _xol_birthday = value; }
            get { return _xol_birthday; }
        }
        /// <summary>
        /// 籍贯
        /// </summary>
        public string XOL_Place
        {
            set { _xol_place = value; }
            get { return _xol_place; }
        }
        /// <summary>
        /// 民族
        /// </summary>
        public string XOL_Nation
        {
            set { _xol_nation = value; }
            get { return _xol_nation; }
        }
        /// <summary>
        /// 婚姻
        /// </summary>
        public string XOL_Marriage
        {
            set { _xol_marriage = value; }
            get { return _xol_marriage; }
        }
        /// <summary>
        /// 办公室电话
        /// </summary>
        public string XOL_Officephone
        {
            set { _xol_officephone = value; }
            get { return _xol_officephone; }
        }
        /// <summary>
        /// 住宅电话
        /// </summary>
        public string XOL_Homephone
        {
            set { _xol_homephone = value; }
            get { return _xol_homephone; }
        }
        /// <summary>
        /// 传真
        /// </summary>
        public string XOL_Fax
        {
            set { _xol_fax = value; }
            get { return _xol_fax; }
        }
        /// <summary>
        /// 学历
        /// </summary>
        public string XOL_Education
        {
            set { _xol_education = value; }
            get { return _xol_education; }
        }
        /// <summary>
        /// 工作履历
        /// </summary>
        public string XOL_Experience
        {
            set { _xol_experience = value; }
            get { return _xol_experience; }
        }
        /// <summary>
        /// 负责业务
        /// </summary>
        public string XOL_Responsible
        {
            set { _xol_responsible = value; }
            get { return _xol_responsible; }
        }
        
        /// <summary>
        /// 负责业务
        /// </summary>
        public string XOL_ChkResponsible
        {
            set { _XOL_ChkResponsible = value; }
            get { return _XOL_ChkResponsible; }
        }
        
        /// <summary>
        /// 爱好/特长
        /// </summary>
        public string XOL_Hobby
        {
            set { _xol_hobby = value; }
            get { return _xol_hobby; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XOL_Address
        {
            set { _xol_address = value; }
            get { return _xol_address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XOL_LogisticsAddress
        {
            set { _xol_logisticsaddress = value; }
            get { return _xol_logisticsaddress; }
        }
        /// <summary>
        /// 评价
        /// </summary>
        public string XOL_Evaluation
        {
            set { _xol_evaluation = value; }
            get { return _xol_evaluation; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string XOL_Remark
        {
            set { _xol_remark = value; }
            get { return _xol_remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? XOL_Del
        {
            set { _xol_del = value; }
            get { return _xol_del; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? XOL_CDate
        {
            set { _xol_cdate = value; }
            get { return _xol_cdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XOL_Creator
        {
            set { _xol_creator = value; }
            get { return _xol_creator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? XOL_MDate
        {
            set { _xol_mdate = value; }
            get { return _xol_mdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XOL_Mender
        {
            set { _xol_mender = value; }
            get { return _xol_mender; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XOL_QQ
        {
            set { _xol_qq = value; }
            get { return _xol_qq; }
        }
        public string XOL_Code
        {
            set { _XOL_Code = value; }
            get { return _XOL_Code; }
        }

        public string XOL_CallName
        {
            set { _XOL_CallName = value; }
            get { return _XOL_CallName; }
        }

        public string XOL_EnglishName
        {
            set { _XOL_EnglishName = value; }
            get { return _XOL_EnglishName; }
        }

        public string XOL_Manager
        {
            set { _XOL_Manager = value; }
            get { return _XOL_Manager; }
        }

        public string XOL_DutyPerson
        {
            set { _XOL_DutyPerson = value; }
            get { return _XOL_DutyPerson; }
        }

        public string XOL_Type
        {
            set { _XOL_Type = value; }
            get { return _XOL_Type; }
        }


        public string XOL_Province
        {
            set { _XOL_Province = value; }
            get { return _XOL_Province; }
        }

        public string XOL_City
        {
            set { _XOL_City = value; }
            get { return _XOL_City; }
        }

        public string XOL_Card
        {
            set { _XOL_Card = value; }
            get { return _XOL_Card; }
        }
        public string XOL_PassWord
        {
            set { _XOL_PassWord = value; }
            get { return _XOL_PassWord; }
        }

        #endregion Model

    }
}

