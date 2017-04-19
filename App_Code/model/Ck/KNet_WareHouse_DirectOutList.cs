using System;
using System.Collections;
namespace KNet.Model
{
    /// <summary>
    /// KNet_WareHouse_DirectOutList:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class KNet_WareHouse_DirectOutList
    {
        public KNet_WareHouse_DirectOutList()
        { }
        #region Model
        private string _id = "newid";
        private string _directoutno;
        private string _directouttopic;
        private DateTime? _directoutdatetime = DateTime.Now;
        private string _houseno;
        private string _directoutstaffbranch;
        private string _directoutstaffdepart;
        private string _directoutstaffno;
        private string _directoutcheckstaffno;
        private string _directoutremarks;
        private int? _directoutcheckyn = 0;
        private DateTime? _systemdatetimes = DateTime.Now;
        private string _kwd_shipno;
        private string _kwd_custmoer;
        private string _kwd_address;
        private string _kwd_contentperson;
        private string _kwd_type = "101";
        private string _kwd_del = "0";
        private int _isShip = 0;
        private string _KWD_Telphone;
        private string _KWD_WuliuName;
        private string _KWD_WuliuNameCode;
        private string _KWD_WuliuCode;
        private string _KWD_State;
        private string _KWD_CwCode;
        private ArrayList _Arr_Details;
        private int _isChange;
        private DateTime _KWD_CWOutTime;
        private string _KWD_RkHouseNo;
        private DateTime _KWD_ReceTime;
        private string _KWD_SCustomerValue;
        private string _KWD_ContractDeliveMethods;
        private int _KWD_LlState;
        private ArrayList _Arr_Feight;


        private string _KWD_ShipType;
        private string _KWD_PayMent;
        private string _KWD_KpType;

        private string _KWD_MainProductsBarCode;
        private int _KWD_MainProductsNumber=0;
        
        /// <summary>
        /// 自动ID值
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 直接出库单
        /// </summary>
        public string DirectOutNo
        {
            set { _directoutno = value; }
            get { return _directoutno; }
        }
        /// <summary>
        /// 直接出库 主题
        /// </summary>
        public string DirectOutTopic
        {
            set { _directouttopic = value; }
            get { return _directouttopic; }
        }
        /// <summary>
        /// 直接出库 时间
        /// </summary>
        public DateTime? DirectOutDateTime
        {
            set { _directoutdatetime = value; }
            get { return _directoutdatetime; }
        }
        /// <summary>
        /// 直接出库 仓库
        /// </summary>
        public string HouseNo
        {
            set { _houseno = value; }
            get { return _houseno; }
        }
        /// <summary>
        /// 直接出库 公司
        /// </summary>
        public string DirectOutStaffBranch
        {
            set { _directoutstaffbranch = value; }
            get { return _directoutstaffbranch; }
        }
        /// <summary>
        /// 直接出库 部门
        /// </summary>
        public string DirectOutStaffDepart
        {
            set { _directoutstaffdepart = value; }
            get { return _directoutstaffdepart; }
        }
        /// <summary>
        /// 直接出库 经手人
        /// </summary>
        public string DirectOutStaffNo
        {
            set { _directoutstaffno = value; }
            get { return _directoutstaffno; }
        }
        /// <summary>
        /// 直接出库 审核人
        /// </summary>
        public string DirectOutCheckStaffNo
        {
            set { _directoutcheckstaffno = value; }
            get { return _directoutcheckstaffno; }
        }
        /// <summary>
        /// 直接出库 备注
        /// </summary>
        public string DirectOutRemarks
        {
            set { _directoutremarks = value; }
            get { return _directoutremarks; }
        }
        /// <summary>
        /// 直接出库 是否审核
        /// </summary>
        public int? DirectOutCheckYN
        {
            set { _directoutcheckyn = value; }
            get { return _directoutcheckyn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? SystemDatetimes
        {
            set { _systemdatetimes = value; }
            get { return _systemdatetimes; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KWD_ShipNo
        {
            set { _kwd_shipno = value; }
            get { return _kwd_shipno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KWD_Custmoer
        {
            set { _kwd_custmoer = value; }
            get { return _kwd_custmoer; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KWD_Address
        {
            set { _kwd_address = value; }
            get { return _kwd_address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KWD_ContentPerson
        {
            set { _kwd_contentperson = value; }
            get { return _kwd_contentperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KWD_Type
        {
            set { _kwd_type = value; }
            get { return _kwd_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KWD_Del
        {
            set { _kwd_del = value; }
            get { return _kwd_del; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int isShip
        {
            set { _isShip = value; }
            get { return _isShip; }
        }


        /// <summary>
        /// 
        /// </summary>
        public string KWD_Telphone
        {
            set { _KWD_Telphone = value; }
            get { return _KWD_Telphone; }
        }


        /// <summary>
        /// 
        /// </summary>
        public string KWD_WuliuName
        {
            set { _KWD_WuliuName = value; }
            get { return _KWD_WuliuName; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string KWD_WuliuNameCode
        {
            set { _KWD_WuliuNameCode = value; }
            get { return _KWD_WuliuNameCode; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string KWD_WuliuCode
        {
            set { _KWD_WuliuCode = value; }
            get { return _KWD_WuliuCode; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string KWD_State
        {
            set { _KWD_State = value; }
            get { return _KWD_State; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string KWD_CwCode
        {
            set { _KWD_CwCode = value; }
            get { return _KWD_CwCode; }
        }


        public int isChange
        {
            set { _isChange = value; }
            get { return _isChange; }
        }
        public ArrayList Arr_Details
        {
            set { _Arr_Details = value; }
            get { return _Arr_Details; }
        }
        public ArrayList Arr_Feight
        {
            set { _Arr_Feight = value; }
            get { return _Arr_Feight; }
        }

        public DateTime KWD_CWOutTime
        {
            set { _KWD_CWOutTime = value; }
            get { return _KWD_CWOutTime; }
        }
        public string KWD_RkHouseNo
        {
            set { _KWD_RkHouseNo = value; }
            get { return _KWD_RkHouseNo; }
        }

        public DateTime KWD_ReceTime
        {
            set { _KWD_ReceTime = value; }
            get { return _KWD_ReceTime; }
        }
        
        public string KWD_SCustomerValue
        {
            set { _KWD_SCustomerValue = value; }
            get { return _KWD_SCustomerValue; }
        }
        public string KWD_ContractDeliveMethods
        {
            set { _KWD_ContractDeliveMethods = value; }
            get { return _KWD_ContractDeliveMethods; }
        }
        public int KWD_LlState
        {
            set { _KWD_LlState = value; }
            get { return _KWD_LlState; }
        }

        public string KWD_ShipType
        {
            set { _KWD_ShipType = value; }
            get { return _KWD_ShipType; }
        }
        public string KWD_PayMent
        {
            set { _KWD_PayMent = value; }
            get { return _KWD_PayMent; }
        }

        private int _KWD_HQState;
        public int KWD_HQState
        {
            set { _KWD_HQState = value; }
            get { return _KWD_HQState; }
        }

        private string _KWD_HQPerson;
        public string KWD_HQPerson
        {
            set { _KWD_HQPerson = value; }
            get { return _KWD_HQPerson; }
        }
        public string KWD_KpType
        {
            set { _KWD_KpType = value; }
            get { return _KWD_KpType; }
        }

        public string KWD_MainProductsBarCode
        {
            set { _KWD_MainProductsBarCode = value; }
            get { return _KWD_MainProductsBarCode; }
        }
        public int KWD_MainProductsNumber
        {
            set { _KWD_MainProductsNumber = value; }
            get { return _KWD_MainProductsNumber; }
        }
        
        
        #endregion Model

    }
}

