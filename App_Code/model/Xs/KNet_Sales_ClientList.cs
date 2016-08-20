using System;
using System.Collections;
namespace KNet.Model
{
    /// <summary>
    /// 实体类KNet_Sales_ClientList
    /// </summary>
    [Serializable]
    public class KNet_Sales_ClientList
    {
        public KNet_Sales_ClientList()
        { }
        #region Model
        private string _id;
        private bool _registeryn;
        private string _loginid;
        private string _loginpassword;
        private string _customername;
        private string _customervalue;
        private string _customerclass;
        private string _customertypes;
        private string _customerprovinces;
        private string _customercity;
        private string _customertrade;
        private string _customersource;
        private string _customercontact;
        private string _customercontactsex;
        private string _customertel;
        private string _customermobile;
        private string _customerwebsite;
        private string _customeremail;
        private string _customeraddress;
        private string _customerzipcode;
        private string _customerqq;
        private string _customermsn;
        private bool _customerprotect;
        private string _customerintroduction;
        private DateTime? _customeraddtime;
        private int? _customerintegral;
        private int? _customerintegralused;
        private decimal? _customermoney;
        private decimal? _customermoneyused;


        private decimal? _PlayCycleMoney;
        private int? _PlayCycleTime;
        private bool _PlayCycleYN;

        private string _customerfax;
        private string _LinkManID;


        private ArrayList _Arr_LinkMan;
        private ArrayList _Arr_Products;
        private ArrayList _Arr_FhDetails;
        private string _CustomerCode;
        private string _FaterCode;
        
        private string _OpeningBank;
        private string _BankAccount;
        private string _RegistrationNum;

        private string _Mender;
        private DateTime? _MTime;
        private string _KSC_Level;
        private string _KSC_State;
        private string _KSC_Type;
        private string _KSC_DutyPerson;
        private string _KSC_Creator;
        private string _KSC_Auxiliary;
        private string _KSC_SampleName;


        private string _KSC_DutyPerson1;
        private string _KSC_Auxiliary1;

        private decimal? _KSC_DlPrice;


        /// <summary>
        /// 额度，单位为元
        /// </summary>
        public decimal? KSC_DlPrice
        {
            set { _KSC_DlPrice = value; }
            get { return _KSC_DlPrice; }
        }
        /// <summary>
        /// 额度，单位为元
        /// </summary>
        public decimal? PlayCycleMoney
        {
            set { _PlayCycleMoney = value; }
            get { return _PlayCycleMoney; }
        }
        /// <summary>
        /// 支付周期（多少天）
        /// </summary>
        public int? PlayCycleTime
        {
            set { _PlayCycleTime = value; }
            get { return _PlayCycleTime; }
        }
        /// <summary>
        /// 是否有支付额度
        /// </summary>
        public bool PlayCycleYN
        {
            set { _PlayCycleYN = value; }
            get { return _PlayCycleYN; }
        }


        /// <summary>
        /// 自动ID值
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 是否自动注册
        /// </summary>
        public bool RegisterYN
        {
            set { _registeryn = value; }
            get { return _registeryn; }
        }
        /// <summary>
        /// 网站登陆ID账号
        /// </summary>
        public string LoginID
        {
            set { _loginid = value; }
            get { return _loginid; }
        }
        /// <summary>
        /// 网站登陆密码
        /// </summary>
        public string LoginPassword
        {
            set { _loginpassword = value; }
            get { return _loginpassword; }
        }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName
        {
            set { _customername = value; }
            get { return _customername; }
        }
        /// <summary>
        /// 客户编号（唯一号）
        /// </summary>
        public string CustomerValue
        {
            set { _customervalue = value; }
            get { return _customervalue; }
        }
        /// <summary>
        /// 渠道信息值（联表）
        /// </summary>
        public string CustomerClass
        {
            set { _customerclass = value; }
            get { return _customerclass; }
        }
        /// <summary>
        /// 客户类型编号（联表）
        /// </summary>
        public string CustomerTypes
        {
            set { _customertypes = value; }
            get { return _customertypes; }
        }
        /// <summary>
        /// 省份编号（联表）
        /// </summary>
        public string CustomerProvinces
        {
            set { _customerprovinces = value; }
            get { return _customerprovinces; }
        }
        /// <summary>
        /// 客户城市（联表）
        /// </summary>
        public string CustomerCity
        {
            set { _customercity = value; }
            get { return _customercity; }
        }
        /// <summary>
        /// 客户所在行业（联表）
        /// </summary>
        public string CustomerTrade
        {
            set { _customertrade = value; }
            get { return _customertrade; }
        }
        /// <summary>
        /// 客户来源（联表）
        /// </summary>
        public string CustomerSource
        {
            set { _customersource = value; }
            get { return _customersource; }
        }
        /// <summary>
        /// 客户主联系人
        /// </summary>
        public string CustomerContact
        {
            set { _customercontact = value; }
            get { return _customercontact; }
        }
        /// <summary>
        /// 客户联系人性别
        /// </summary>
        public string CustomerContactSex
        {
            set { _customercontactsex = value; }
            get { return _customercontactsex; }
        }
        /// <summary>
        /// 客户联系电话
        /// </summary>
        public string CustomerTel
        {
            set { _customertel = value; }
            get { return _customertel; }
        }
        /// <summary>
        /// 客户移动电话
        /// </summary>
        public string CustomerMobile
        {
            set { _customermobile = value; }
            get { return _customermobile; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CustomerWebsite
        {
            set { _customerwebsite = value; }
            get { return _customerwebsite; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CustomerEmail
        {
            set { _customeremail = value; }
            get { return _customeremail; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CustomerAddress
        {
            set { _customeraddress = value; }
            get { return _customeraddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CustomerZipCode
        {
            set { _customerzipcode = value; }
            get { return _customerzipcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CustomerQQ
        {
            set { _customerqq = value; }
            get { return _customerqq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CustomerMsn
        {
            set { _customermsn = value; }
            get { return _customermsn; }
        }
        /// <summary>
        /// 是否保护客户
        /// </summary>
        public bool CustomerProtect
        {
            set { _customerprotect = value; }
            get { return _customerprotect; }
        }
        /// <summary>
        /// 客户简介
        /// </summary>
        public string CustomerIntroduction
        {
            set { _customerintroduction = value; }
            get { return _customerintroduction; }
        }
        /// <summary>
        /// 添加（注册）时间
        /// </summary>
        public DateTime? CustomerAddtime
        {
            set { _customeraddtime = value; }
            get { return _customeraddtime; }
        }
        /// <summary>
        /// 客户积分
        /// </summary>
        public int? CustomerIntegral
        {
            set { _customerintegral = value; }
            get { return _customerintegral; }
        }
        /// <summary>
        /// 已用积分
        /// </summary>
        public int? CustomerIntegralUsed
        {
            set { _customerintegralused = value; }
            get { return _customerintegralused; }
        }
        /// <summary>
        /// 金额（如果启用金额的话）
        /// </summary>
        public decimal? CustomerMoney
        {
            set { _customermoney = value; }
            get { return _customermoney; }
        }
        /// <summary>
        /// 已用金额
        /// </summary>
        public decimal? CustomerMoneyUsed
        {
            set { _customermoneyused = value; }
            get { return _customermoneyused; }
        }

        public string CustomerCode
        {
            set { _CustomerCode = value; }
            get { return _CustomerCode; }
        }

        public string FaterCode
        {
            set { _FaterCode = value; }
            get { return _FaterCode; }
        }
        /// <summary>
        /// 客户联系Fax
        /// </summary>
        public string CustomerFax
        {
            set { _customerfax = value; }
            get { return _customerfax; }
        }

        public string LinkManID
        {
            set { _LinkManID = value; }
            get { return _LinkManID; }
        }
        
        /// <summary>
        /// 客户联系Fax
        /// </summary>
        public ArrayList Arr_LinkMan
        {
            set { _Arr_LinkMan = value; }
            get { return _Arr_LinkMan; }
        }

        /// <summary>
        /// 客户联系Fax
        /// </summary>
        public ArrayList Arr_Products
        {
            set { _Arr_Products = value; }
            get { return _Arr_Products; }
        }
        public ArrayList Arr_FhDetails
        {
            set { _Arr_FhDetails = value; }
            get { return _Arr_FhDetails; }
        }

        public string OpeningBank
        {
            set { _OpeningBank = value; }
            get { return _OpeningBank; }
        }

        public string BankAccount
        {
            set { _BankAccount = value; }
            get { return _BankAccount; }
        }

        public string RegistrationNum
        {
            set { _RegistrationNum = value; }
            get { return _RegistrationNum; }
        }

        public string Mender
        {
            set { _Mender = value; }
            get { return _Mender; }
        }

        /// <summary>
        /// 添加（注册）时间
        /// </summary>
        public DateTime? MTime
        {
            set { _MTime = value; }
            get { return _MTime; }
        }

        public string KSC_Level
        {
            set { _KSC_Level = value; }
            get { return _KSC_Level; }
        }
        
        public string KSC_State
        {
            set { _KSC_State = value; }
            get { return _KSC_State; }
        }

        public string KSC_Type
        {
            set { _KSC_Type = value; }
            get { return _KSC_Type; }
        }

        public string KSC_DutyPerson
        {
            set { _KSC_DutyPerson = value; }
            get { return _KSC_DutyPerson; }
        }

        public string KSC_Creator
        {
            set { _KSC_Creator = value; }
            get { return _KSC_Creator; }
        }
        public string KSC_Auxiliary
        {
            set { _KSC_Auxiliary = value; }
            get { return _KSC_Auxiliary; }
        }
        public string KSC_SampleName
        {
            set { _KSC_SampleName = value; }
            get { return _KSC_SampleName; }
        }

        public string KSC_Auxiliary1
        {
            set { _KSC_Auxiliary1 = value; }
            get { return _KSC_Auxiliary1; }
        }
        public string KSC_DutyPerson1
        {
            set { _KSC_DutyPerson1 = value; }
            get { return _KSC_DutyPerson1; }
        }

        private string _KSC_PayMent;
        public string KSC_PayMent
        {
            set { _KSC_PayMent = value; }
            get { return _KSC_PayMent; }
        }

        private string _KSC_KPType;
        public string KSC_KPType
        {
            set { _KSC_KPType = value; }
            get { return _KSC_KPType; }
        } 
        
        #endregion Model

    }
}

