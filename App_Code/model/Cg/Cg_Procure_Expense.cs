using System;
namespace KNet.Model
{
    /// <summary>
    /// Cg_Procure_Expense:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Cg_Procure_Expense
    {
        public Cg_Procure_Expense()
        { }
        #region Model
        private string _cpe_id;
        private string _cpe_code;
        private string _cpe_directoutno;
        private DateTime? _cpe_stime;
        private string _cpe_cuse;
        private int? _cpe_number;
        private decimal? _cpe_price;
        private decimal? _cpe_money;
        private decimal? _cpe_percent;
        private decimal? _cpe_suppmoney;
        private decimal? _cpe_paymoney;
        private string _cpe_details;
        private int? _cpe_del = 0;
        private DateTime? _cpe_ctime;
        private string _cpe_creator;
        private DateTime? _cpe_mtime;
        private string _cpe_mender;
        /// <summary>
        /// 
        /// </summary>
        public string CPE_ID
        {
            set { _cpe_id = value; }
            get { return _cpe_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CPE_Code
        {
            set { _cpe_code = value; }
            get { return _cpe_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CPE_DirectOutNo
        {
            set { _cpe_directoutno = value; }
            get { return _cpe_directoutno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CPE_Stime
        {
            set { _cpe_stime = value; }
            get { return _cpe_stime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CPE_Cuse
        {
            set { _cpe_cuse = value; }
            get { return _cpe_cuse; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CPE_Number
        {
            set { _cpe_number = value; }
            get { return _cpe_number; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CPE_Price
        {
            set { _cpe_price = value; }
            get { return _cpe_price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CPE_Money
        {
            set { _cpe_money = value; }
            get { return _cpe_money; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CPE_Percent
        {
            set { _cpe_percent = value; }
            get { return _cpe_percent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CPE_SuppMoney
        {
            set { _cpe_suppmoney = value; }
            get { return _cpe_suppmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CPE_PayMoney
        {
            set { _cpe_paymoney = value; }
            get { return _cpe_paymoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CPE_Details
        {
            set { _cpe_details = value; }
            get { return _cpe_details; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CPE_Del
        {
            set { _cpe_del = value; }
            get { return _cpe_del; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CPE_CTime
        {
            set { _cpe_ctime = value; }
            get { return _cpe_ctime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CPE_Creator
        {
            set { _cpe_creator = value; }
            get { return _cpe_creator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CPE_MTime
        {
            set { _cpe_mtime = value; }
            get { return _cpe_mtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CPE_Mender
        {
            set { _cpe_mender = value; }
            get { return _cpe_mender; }
        }
        #endregion Model

    }
}

