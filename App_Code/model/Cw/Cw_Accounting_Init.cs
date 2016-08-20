using System;
using System.Collections;
namespace KNet.Model
{
    /// <summary>
    /// Cw_Accounting_Init:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Cw_Accounting_Init
    {
        public Cw_Accounting_Init()
        { }
        #region Model
        private string _cai_id = "[dbo].[GetID]";
        private string _cai_code;
        private string _cai_title;
        private DateTime? _cai_stime;
        private string _cai_dutyperson;
        private string _cai_customervalue;
        private string _cai_suppno;
        private int? _cai_type = 0;
        private decimal? _cai_initmoney;
        private string _cai_details;
        private int? _cai_del = 0;
        private string _cai_creator;
        private DateTime? _cai_ctime;
        private string _cai_mender;
        private DateTime? _cai_mtime;
        private ArrayList _Arr_Details;
        /// <summary>
        /// 
        /// </summary>
        public string CAI_ID
        {
            set { _cai_id = value; }
            get { return _cai_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAI_Code
        {
            set { _cai_code = value; }
            get { return _cai_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAI_Title
        {
            set { _cai_title = value; }
            get { return _cai_title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CAI_STime
        {
            set { _cai_stime = value; }
            get { return _cai_stime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAI_DutyPerson
        {
            set { _cai_dutyperson = value; }
            get { return _cai_dutyperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAI_CustomerValue
        {
            set { _cai_customervalue = value; }
            get { return _cai_customervalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAI_SuppNo
        {
            set { _cai_suppno = value; }
            get { return _cai_suppno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CAI_Type
        {
            set { _cai_type = value; }
            get { return _cai_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CAI_InitMoney
        {
            set { _cai_initmoney = value; }
            get { return _cai_initmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAI_Details
        {
            set { _cai_details = value; }
            get { return _cai_details; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CAI_Del
        {
            set { _cai_del = value; }
            get { return _cai_del; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAI_Creator
        {
            set { _cai_creator = value; }
            get { return _cai_creator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CAI_CTime
        {
            set { _cai_ctime = value; }
            get { return _cai_ctime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAI_Mender
        {
            set { _cai_mender = value; }
            get { return _cai_mender; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CAI_MTime
        {
            set { _cai_mtime = value; }
            get { return _cai_mtime; }
        }


        public ArrayList Arr_Details
        {
            set { _Arr_Details = value; }
            get { return _Arr_Details; }
        }
        #endregion Model

    }
}

