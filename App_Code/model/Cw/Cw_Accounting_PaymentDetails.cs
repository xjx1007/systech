using System;
namespace KNet.Model
{
    /// <summary>
    /// Cw_Accounting_PaymentDetails:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Cw_Accounting_PaymentDetails
    {
        public Cw_Accounting_PaymentDetails()
        { }
        #region Model
        private string _capd_id = "[dbo].[GetID]";
        private string _capd_carid;
        private DateTime? _capd_ytime;
        private int? _capd_order = 0;
        private int? _capd_state = 0;
        private decimal? _capd_money;
        private string _capd_details;
        private string _capd_fid;
        private decimal? _capd_number;
        private decimal? _capd_price;
        /// <summary>
        /// 
        /// </summary>
        public string CAPD_ID
        {
            set { _capd_id = value; }
            get { return _capd_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAPD_CARID
        {
            set { _capd_carid = value; }
            get { return _capd_carid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CAPD_yTime
        {
            set { _capd_ytime = value; }
            get { return _capd_ytime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CAPD_Order
        {
            set { _capd_order = value; }
            get { return _capd_order; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CAPD_State
        {
            set { _capd_state = value; }
            get { return _capd_state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CAPD_Money
        {
            set { _capd_money = value; }
            get { return _capd_money; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAPD_Details
        {
            set { _capd_details = value; }
            get { return _capd_details; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAPD_FID
        {
            set { _capd_fid = value; }
            get { return _capd_fid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CAPD_Number
        {
            set { _capd_number = value; }
            get { return _capd_number; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CAPD_Price
        {
            set { _capd_price = value; }
            get { return _capd_price; }
        }
        #endregion Model

    }
}

