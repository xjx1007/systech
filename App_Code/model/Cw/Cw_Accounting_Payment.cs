using System;
using System.Collections;
namespace KNet.Model
{
    /// <summary>
    /// Cw_Accounting_Payment:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Cw_Accounting_Payment
    {
        public Cw_Accounting_Payment()
        { }
        #region Model
        private string _cap_id = "[dbo].[GetID]";
        private string _cap_fid;
        private string _cap_code;
        private string _cap_title;
        private DateTime? _cap_stime;
        private string _cap_dutyperson;
        private string _cap_customervalue;
        private string _cap_kcustomervalue;
        private int? _cap_type = 0;
        private int? _cap_state = 0;
        private decimal? _cap_receivemoney;
        private string _cap_bank;
        private string _cap_isfp;
        private string _cap_details;
        private int? _cap_del = 0;
        private string _cap_creator;
        private DateTime? _cap_ctime;
        private string _cap_mender;
        private DateTime? _cap_mtime;
        private int? _cap_ispay = 0;
        private decimal? _cap_Paymoney;
        private decimal? _cap_Leftmoney;
        private string _CAP_FpType;
        private int? _CAP_Order = 1;
        private ArrayList _arr_Details;

        private int? _CAP_KpState;
        private int? _CAP_SKState;
        private decimal? _cap_wKpmoney;
        private string _CAP_OutWareNO;
        private string _CAP_ContractNo;
        private ArrayList _arr_DirectOut;
        private int? _CAP_CheckYN;
        private string _CAP_Payment;
        /// <summary>
        /// 
        /// </summary>
        public string CAP_ID
        {
            set { _cap_id = value; }
            get { return _cap_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAP_FID
        {
            set { _cap_fid = value; }
            get { return _cap_fid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAP_Code
        {
            set { _cap_code = value; }
            get { return _cap_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAP_Title
        {
            set { _cap_title = value; }
            get { return _cap_title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CAP_STime
        {
            set { _cap_stime = value; }
            get { return _cap_stime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAP_DutyPerson
        {
            set { _cap_dutyperson = value; }
            get { return _cap_dutyperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAP_CustomerValue
        {
            set { _cap_customervalue = value; }
            get { return _cap_customervalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAP_KCustomerValue
        {
            set { _cap_kcustomervalue = value; }
            get { return _cap_kcustomervalue; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public int? CAP_Type
        {
            set { _cap_type = value; }
            get { return _cap_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CAP_State
        {
            set { _cap_state = value; }
            get { return _cap_state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CAP_ReceiveMoney
        {
            set { _cap_receivemoney = value; }
            get { return _cap_receivemoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAP_Bank
        {
            set { _cap_bank = value; }
            get { return _cap_bank; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAP_IsFP
        {
            set { _cap_isfp = value; }
            get { return _cap_isfp; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAP_Details
        {
            set { _cap_details = value; }
            get { return _cap_details; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CAP_Del
        {
            set { _cap_del = value; }
            get { return _cap_del; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAP_Creator
        {
            set { _cap_creator = value; }
            get { return _cap_creator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CAP_CTime
        {
            set { _cap_ctime = value; }
            get { return _cap_ctime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAP_Mender
        {
            set { _cap_mender = value; }
            get { return _cap_mender; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CAP_MTime
        {
            set { _cap_mtime = value; }
            get { return _cap_mtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CAP_IsPay
        {
            set { _cap_ispay = value; }
            get { return _cap_ispay; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? cap_Paymoney
        {
            set { _cap_Paymoney = value; }
            get { return _cap_Paymoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? cap_Leftmoney
        {
            set { _cap_Leftmoney = value; }
            get { return _cap_Leftmoney; }
        }
        public string CAP_FpType
        {
            set { _CAP_FpType = value; }
            get { return _CAP_FpType; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CAP_Order
        {
            set { _CAP_Order = value; }
            get { return _CAP_Order; }
        }

        public ArrayList arr_Details
        {
            set { _arr_Details = value; }
            get { return _arr_Details; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CAP_KpState
        {
            set { _CAP_KpState = value; }
            get { return _CAP_KpState; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CAP_SKState
        {
            set { _CAP_SKState = value; }
            get { return _CAP_SKState; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public decimal? cap_wKpmoney
        {
            set { _cap_wKpmoney = value; }
            get { return _cap_wKpmoney; }
        }
        public string CAP_OutWareNO
        {
            set { _CAP_OutWareNO = value; }
            get { return _CAP_OutWareNO; }
        }
        public string CAP_ContractNo
        {
            set { _CAP_ContractNo = value; }
            get { return _CAP_ContractNo; }
        }

        public ArrayList arr_DirectOut
        {
            set { _arr_DirectOut = value; }
            get { return _arr_DirectOut; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public int? CAP_CheckYN
        {
            set { _CAP_CheckYN = value; }
            get { return _CAP_CheckYN; }
        }

        public string CAP_Payment
        {
            set { _CAP_Payment = value; }
            get { return _CAP_Payment; }
        }

        #endregion Model

    }
}

