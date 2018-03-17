using System;
namespace KNet.Model
{
    /// <summary>
    /// Xs_Products_Prodocts:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Xs_Products_Prodocts
    {
        public Xs_Products_Prodocts()
        { }
        #region Model
        private string _xpp_id;
        private string _xpp_productsbarcode;
        private string _xpp_suppno;
        private decimal? _xpp_price;
        private decimal? _xpp_number;
        private string _xpp_faterbarcode;
        private string _XPP_IsOrder;
        private string _XPP_Address;
        private string _XPP_CgID;
        
        /// <summary>
        /// 
        /// </summary>
        public string XPP_ID
        {
            set { _xpp_id = value; }
            get { return _xpp_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XPP_ProductsBarCode
        {
            set { _xpp_productsbarcode = value; }
            get { return _xpp_productsbarcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XPP_SuppNo
        {
            set { _xpp_suppno = value; }
            get { return _xpp_suppno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? XPP_Price
        {
            set { _xpp_price = value; }
            get { return _xpp_price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? XPP_Number
        {
            set { _xpp_number = value; }
            get { return _xpp_number; }
        }

        public string XPP_FaterBarCode
        {
            set { _xpp_faterbarcode = value; }
            get { return _xpp_faterbarcode; }
        }

        public string XPP_IsOrder
        {
            set { _XPP_IsOrder = value; }
            get { return _XPP_IsOrder; }
        }

        public string XPP_Address
        {
            set { _XPP_Address = value; }
            get { return _XPP_Address; }
        }
        public string XPP_CgID
        {
            set { _XPP_CgID = value; }
            get { return _XPP_CgID; }
        }
        #endregion Model

    }
}

