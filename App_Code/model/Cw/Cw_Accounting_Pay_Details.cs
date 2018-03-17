using System;
namespace KNet.Model
{
    /// <summary>
    /// Cw_Accounting_Pay_Details:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Cw_Accounting_Pay_Details
    {
        public Cw_Accounting_Pay_Details()
        { }
        #region Model
        private string _cay_id;
        private string _cay_caaid;
        private string _cay_capid;
        private decimal? _cay_paymoney;
        private int? _cay_order = 1;
        /// <summary>
        /// 
        /// </summary>
        public string CAY_ID
        {
            set { _cay_id = value; }
            get { return _cay_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAY_CAAID
        {
            set { _cay_caaid = value; }
            get { return _cay_caaid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAY_CAPID
        {
            set { _cay_capid = value; }
            get { return _cay_capid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CAY_PayMoney
        {
            set { _cay_paymoney = value; }
            get { return _cay_paymoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CAY_Order
        {
            set { _cay_order = value; }
            get { return _cay_order; }
        }
        #endregion Model

    }
}

