using System;
using System.Collections;
namespace KNet.Model
{
    /// <summary>
    /// Cw_Account_Bill:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Cw_Account_Bill
    {
        public Cw_Account_Bill()
        { }
        #region Model
        private string _cab_id;
        private string _cab_code;
        private string _cab_content;
        private string _cab_dutyperson;
        private string _cab_customervalue;
        private string _cab_contractno;
        private string _cab_PayMent;
        private int? _cab_billtype = 0;
        private decimal? _cab_money;
        private string _cab_billnumber;
        private DateTime? _cab_stime;
        private string _cab_brokerage;
        private string _cab_remarks;
        private DateTime? _cab_ctime;
        private string _cab_creator;
        private DateTime? _cab_mtime;
        private string _cab_mender;
        private int? _cab_del = 0;
        private ArrayList _arr_Details;
        private ArrayList _arr_OutTimes;
        
        private string _CAB_CAPID;
        private string _CAB_Day;
        private DateTime? _CAB_OutTime;
        private string _CAB_ReceiveID;
        
        
        /// <summary>
        /// 
        /// </summary>
        public string CAB_ID
        {
            set { _cab_id = value; }
            get { return _cab_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAB_Code
        {
            set { _cab_code = value; }
            get { return _cab_code; }
        }

        private int _CAB_ChchekYN;
        public int CAB_ChchekYN
        {
            set { _CAB_ChchekYN = value; }
            get { return _CAB_ChchekYN; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public string CAB_Content
        {
            set { _cab_content = value; }
            get { return _cab_content; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAB_DutyPerson
        {
            set { _cab_dutyperson = value; }
            get { return _cab_dutyperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAB_CustomerValue
        {
            set { _cab_customervalue = value; }
            get { return _cab_customervalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAB_ContractNo
        {
            set { _cab_contractno = value; }
            get { return _cab_contractno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CAB_BillType
        {
            set { _cab_billtype = value; }
            get { return _cab_billtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CAB_Money
        {
            set { _cab_money = value; }
            get { return _cab_money; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAB_BillNumber
        {
            set { _cab_billnumber = value; }
            get { return _cab_billnumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CAB_Stime
        {
            set { _cab_stime = value; }
            get { return _cab_stime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAB_Brokerage
        {
            set { _cab_brokerage = value; }
            get { return _cab_brokerage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAB_Remarks
        {
            set { _cab_remarks = value; }
            get { return _cab_remarks; }
        }

        public string CAB_PayMent
        {
            set { _cab_PayMent = value; }
            get { return _cab_PayMent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CAB_Ctime
        {
            set { _cab_ctime = value; }
            get { return _cab_ctime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAB_Creator
        {
            set { _cab_creator = value; }
            get { return _cab_creator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CAB_Mtime
        {
            set { _cab_mtime = value; }
            get { return _cab_mtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAB_Mender
        {
            set { _cab_mender = value; }
            get { return _cab_mender; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CAB_Del
        {
            set { _cab_del = value; }
            get { return _cab_del; }
        }
        public ArrayList arr_Details
        {
            set { _arr_Details = value; }
            get { return _arr_Details; }
        }

        public ArrayList arr_OutTimes
        {
            set { _arr_OutTimes = value; }
            get { return _arr_OutTimes; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAB_CAPID
        {
            set { _CAB_CAPID = value; }
            get { return _CAB_CAPID; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string CAB_Day
        {
            set { _CAB_Day = value; }
            get { return _CAB_Day; }
        }
        public DateTime? CAB_OutTime
        {
            set { _CAB_OutTime = value; }
            get { return _CAB_OutTime; }
        }
        public string CAB_ReceiveID
        {
            set { _CAB_ReceiveID = value; }
            get { return _CAB_ReceiveID; }
        }
        
        #endregion Model

    }
}

