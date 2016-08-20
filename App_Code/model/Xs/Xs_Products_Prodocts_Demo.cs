using System;
namespace KNet.Model
{
    /// <summary>
    /// Xs_Products_Prodocts_Demo:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Xs_Products_Prodocts_Demo
    {
        public Xs_Products_Prodocts_Demo()
        { }
        #region Model
        private string _XPD_id;
        private string _XPD_productsbarcode;
        private string _XPD_suppno;
        private decimal? _XPD_price;
        private decimal? _XPD_number;
        private string _XPD_faterbarcode;
        private string _XPD_IsOrder;
        private string _XPD_Address;
        private string _XPD_ReplaceProductsBarCode;
        private int? _XPD_Order;
        private int? _XPD_Only;
        
        /// <summary>
        /// 
        /// </summary>
        public string XPD_ID
        {
            set { _XPD_id = value; }
            get { return _XPD_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XPD_ProductsBarCode
        {
            set { _XPD_productsbarcode = value; }
            get { return _XPD_productsbarcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XPD_SuppNo
        {
            set { _XPD_suppno = value; }
            get { return _XPD_suppno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? XPD_Price
        {
            set { _XPD_price = value; }
            get { return _XPD_price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? XPD_Number
        {
            set { _XPD_number = value; }
            get { return _XPD_number; }
        }

        public string XPD_FaterBarCode
        {
            set { _XPD_faterbarcode = value; }
            get { return _XPD_faterbarcode; }
        }

        public string XPD_IsOrder
        {
            set { _XPD_IsOrder = value; }
            get { return _XPD_IsOrder; }
        }

        public string XPD_Address
        {
            set { _XPD_Address = value; }
            get { return _XPD_Address; }
        }
        public string XPD_ReplaceProductsBarCode
        {
            set { _XPD_ReplaceProductsBarCode = value; }
            get { return _XPD_ReplaceProductsBarCode; }
        }


        public int? XPD_Order
        {
            set { _XPD_Order = value; }
            get { return _XPD_Order; }
        }
        public int? XPD_Only
        {
            set { _XPD_Only = value; }
            get { return _XPD_Only; }
        }
        #endregion Model

    }
}

