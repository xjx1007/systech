using System;
namespace KNet.Model
{
    /// <summary>
    /// 实体类KNet_Resource_Staff
    /// </summary>
    public class KNet_Resource_Staff
    {
        public KNet_Resource_Staff()
        { }
        #region Model
        private string _id;
        private string _staffno;
        private string _staffbranch;
        private string _staffdepart;
        private string _staffcard;
        private string _staffname;
        private string _staffpassword;
        private decimal? _staffwages;
        private bool _staffsex;
        private string _stafftel;
        private string _staffemail;
        private string _staffaddress;
        private string _staffidcard;
        private DateTime? _staffaddtime;
        private string _staffremarks;
        private string _staff_loginip;
        private DateTime? _staff_logindate;
        private long _staff_loginnum;
        private bool _staffadmin;

        private bool _StaffYN;
        private int _StaffLanguage;
        private int _StaffCatalogue;
        private string _position;
        private int _isOnline;
        private int _isSale;
        private string _KRS_DepartPerson;
        private string _KRS_MailPassWord;
        private int _KRS_IsWeb;
        private string _TelPhone;
        private string _ProductsType;


        public string ProductsType
        {
            set { _ProductsType = value; }
            get { return _ProductsType; }
        }

        /// <summary>
        /// 用户默认打开莱单栏
        /// </summary>
        public int StaffCatalogue
        {
            set { _StaffCatalogue = value; }
            get { return _StaffCatalogue; }
        }
        /// <summary>
        /// 用户默认语言（1简体中文，2繁体中文）
        /// </summary>
        public int StaffLanguage
        {
            set { _StaffLanguage = value; }
            get { return _StaffLanguage; }
        }
        public int isOnline
        {
            set { _isOnline = value; }
            get { return _isOnline; }
        }
        

        /// <summary>
        /// 是否禁用（0否，1是）
        /// </summary>
        public bool StaffYN
        {
            set { _StaffYN = value; }
            get { return _StaffYN; }
        }


        /// <summary>
        /// 自动编号
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 人员维一号
        /// </summary>
        public string StaffNo
        {
            set { _staffno = value; }
            get { return _staffno; }
        }

        
        /// <summary>
        /// 人员维一号
        /// </summary>
        public string TelPhone
        {
            set { _TelPhone = value; }
            get { return _TelPhone; }
        }
        
        /// <summary>
        /// 分公司值
        /// </summary>
        public string StaffBranch
        {
            set { _staffbranch = value; }
            get { return _staffbranch; }
        }
        /// <summary>
        /// 部门值
        /// </summary>
        public string StaffDepart
        {
            set { _staffdepart = value; }
            get { return _staffdepart; }
        }
        /// <summary>
        /// 会员卡号
        /// </summary>
        public string StaffCard
        {
            set { _staffcard = value; }
            get { return _staffcard; }
        }
        /// <summary>
        /// 登陆名
        /// </summary>
        public string StaffName
        {
            set { _staffname = value; }
            get { return _staffname; }
        }
        /// <summary>
        /// 登陆密码
        /// </summary>
        public string StaffPassword
        {
            set { _staffpassword = value; }
            get { return _staffpassword; }
        }
        /// <summary>
        /// 基本工资
        /// </summary>
        public decimal? Staffwages
        {
            set { _staffwages = value; }
            get { return _staffwages; }
        }
        /// <summary>
        /// 男女（0男,1女）
        /// </summary>
        public bool StaffSex
        {
            set { _staffsex = value; }
            get { return _staffsex; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string StaffTel
        {
            set { _stafftel = value; }
            get { return _stafftel; }
        }
        /// <summary>
        /// 联系邮件
        /// </summary>
        public string StaffEmail
        {
            set { _staffemail = value; }
            get { return _staffemail; }
        }
        /// <summary>
        /// 家庭地址
        /// </summary>
        public string StaffAddress
        {
            set { _staffaddress = value; }
            get { return _staffaddress; }
        }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string StaffIDCard
        {
            set { _staffidcard = value; }
            get { return _staffidcard; }
        }
        /// <summary>
        /// 入职时间
        /// </summary>
        public DateTime? StaffAddTime
        {
            set { _staffaddtime = value; }
            get { return _staffaddtime; }
        }
        /// <summary>
        /// 备注说明
        /// </summary>
        public string StaffRemarks
        {
            set { _staffremarks = value; }
            get { return _staffremarks; }
        }
        /// <summary>
        /// 登陆IP地址
        /// </summary>
        public string Staff_LoginIP
        {
            set { _staff_loginip = value; }
            get { return _staff_loginip; }
        }
        /// <summary>
        /// 登陆时间
        /// </summary>
        public DateTime? Staff_LoginDate
        {
            set { _staff_logindate = value; }
            get { return _staff_logindate; }
        }
        /// <summary>
        /// 登陆数次
        /// </summary>
        public long Staff_LoginNum
        {
            set { _staff_loginnum = value; }
            get { return _staff_loginnum; }
        }
        /// <summary>
        /// 是否为超级管理员（0否，1是）
        /// </summary>
        public bool StaffAdmin
        {
            set { _staffadmin = value; }
            get { return _staffadmin; }
        }
        /// <summary>
		/// 职位
		/// </summary>
		public string Position
		{
			set{ _position=value;}
			get{return _position;}
		}
        public int isSale
        {
            set { _isSale = value; }
            get { return _isSale; }
        }
        public string KRS_DepartPerson
        {
            set { _KRS_DepartPerson = value; }
            get { return _KRS_DepartPerson; }
        }
        public string KRS_MailPassWord
        {
            set { _KRS_MailPassWord = value; }
            get { return _KRS_MailPassWord; }
        }

        public int KRS_IsWeb
        {
            set { _KRS_IsWeb = value; }
            get { return _KRS_IsWeb; }
        }
        
        #endregion Model

    }
}

