using System;
using System.Collections;
namespace KNet.Model
{
    /// <summary>
    /// Cw_Accounting_Pay:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Cw_Accounting_Pay
    {
        public Cw_Accounting_Pay()
        { }
        #region Model
        private string _caa_id;
        private string _caa_dutyperson;
        private string _caa_customervalue;
        private string _caa_account;
        private DateTime? _caa_paytime;
        private decimal? _caa_paymoney;
        private string _caa_details;
        private DateTime? _caa_ctime;
        private string _caa_creator;
        private DateTime? _caa_mtime;
        private string _caa_mender;
        private string _CAA_Code;
        private int _CAA_Type;
        private ArrayList _arr_Details;
        private string _CAA_FID;
        private DateTime _CAA_StartDateTime;
        private DateTime _CAA_EndDateTime;
        private string _CAA_BillCode;
        private int _CAP_Type;
        private string _CAP_YFBillCode;
        private DateTime _CAP_YFOutDate;
        private string _CAA_FCAAID;
        
        /// <summary>
        /// 
        /// </summary>
        public string CAA_ID
        {
            set { _caa_id = value; }
            get { return _caa_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAA_DutyPerson
        {
            set { _caa_dutyperson = value; }
            get { return _caa_dutyperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAA_CustomerValue
        {
            set { _caa_customervalue = value; }
            get { return _caa_customervalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAA_Account
        {
            set { _caa_account = value; }
            get { return _caa_account; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CAA_PayTime
        {
            set { _caa_paytime = value; }
            get { return _caa_paytime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CAA_PayMoney
        {
            set { _caa_paymoney = value; }
            get { return _caa_paymoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAA_Details
        {
            set { _caa_details = value; }
            get { return _caa_details; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CAA_CTime
        {
            set { _caa_ctime = value; }
            get { return _caa_ctime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAA_Creator
        {
            set { _caa_creator = value; }
            get { return _caa_creator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CAA_MTime
        {
            set { _caa_mtime = value; }
            get { return _caa_mtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAA_Mender
        {
            set { _caa_mender = value; }
            get { return _caa_mender; }
        }
        public string CAA_Code
        {
            set { _CAA_Code = value; }
            get { return _CAA_Code; }
        }
        public int CAA_Type
        {
            set { _CAA_Type = value; }
            get { return _CAA_Type; }
        }
        public string CAA_FID
        {
            set { _CAA_FID = value; }
            get { return _CAA_FID; }
        }

        public ArrayList arr_Details
        {
            set { _arr_Details = value; }
            get { return _arr_Details; }
        }

        private ArrayList _arr_BillDetails;
        public ArrayList arr_BillDetails
        {
            set { _arr_BillDetails = value; }
            get { return _arr_BillDetails; }
        }


        private ArrayList _arr_FpDetails;
        public ArrayList arr_FpDetails
        {
            set { _arr_FpDetails = value; }
            get { return _arr_FpDetails; }
        }

        public DateTime CAA_StartDateTime
        {
            set { _CAA_StartDateTime = value; }
            get { return _CAA_StartDateTime; }

        }
        public DateTime CAA_EndDateTime
        {
            set { _CAA_EndDateTime = value; }
            get { return _CAA_EndDateTime; }
        }
        public string CAA_BillCode
        {
            set { _CAA_BillCode = value; }
            get { return _CAA_BillCode; }
        }
        public int CAP_Type
        {
            set { _CAP_Type = value; }
            get { return _CAP_Type; }
        }



        public DateTime CAP_YFOutDate
        {
            set { _CAP_YFOutDate = value; }
            get { return _CAP_YFOutDate; }
        }
        public string CAP_YFBillCode
        {
            set { _CAP_YFBillCode = value; }
            get { return _CAP_YFBillCode; }
        }
        private decimal _CAA_DetailsTotalMoney;

        public decimal CAA_DetailsTotalMoney
        {
            set { _CAA_DetailsTotalMoney = value; }
            get { return _CAA_DetailsTotalMoney; }
        }

        private decimal _CAA_leftMoney;
        public decimal CAA_leftMoney
        {
            set { _CAA_leftMoney = value; }
            get { return _CAA_leftMoney; }
        }

        public string CAA_FCAAID
        {
            set { _CAA_FCAAID = value; }
            get { return _CAA_FCAAID; }
        }
        
        #endregion Model

    }
}

