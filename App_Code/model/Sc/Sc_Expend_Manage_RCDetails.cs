using System;
namespace KNet.Model
{
    /// <summary>
    /// Sc_Expend_Manage_RCDetails:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Sc_Expend_Manage_RCDetails
    {
        public Sc_Expend_Manage_RCDetails()
        { }
        #region Model
        private string _ser_id;
        private string _ser_semid;
        private string _ser_orderdetailid;
        private string _ser_productsbarcode;
        private int? _ser_scnumber;
        private decimal? _ser_scprice;
        private decimal? _ser_scmoney;
        private string _SER_HouseNo;
        private decimal? _SER_ScHandPrice;
        private decimal? _SER_ScHandMoney;
        
        /// <summary>
        /// 
        /// </summary>
        public string SER_ID
        {
            set { _ser_id = value; }
            get { return _ser_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SER_SEMID
        {
            set { _ser_semid = value; }
            get { return _ser_semid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SER_OrderDetailID
        {
            set { _ser_orderdetailid = value; }
            get { return _ser_orderdetailid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SER_ProductsBarCode
        {
            set { _ser_productsbarcode = value; }
            get { return _ser_productsbarcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SER_ScNumber
        {
            set { _ser_scnumber = value; }
            get { return _ser_scnumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SER_ScPrice
        {
            set { _ser_scprice = value; }
            get { return _ser_scprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SER_ScMoney
        {
            set { _ser_scmoney = value; }
            get { return _ser_scmoney; }
        }
        public string SER_HouseNo
        {
            set { _SER_HouseNo = value; }
            get { return _SER_HouseNo; }
        }
        public decimal? SER_ScHandPrice
        {
            set { _SER_ScHandPrice = value; }
            get { return _SER_ScHandPrice; }
        }
        public decimal? SER_ScHandMoney
        {
            set { _SER_ScHandMoney = value; }
            get { return _SER_ScHandMoney; }
        }
        
        #endregion Model

    }
}

