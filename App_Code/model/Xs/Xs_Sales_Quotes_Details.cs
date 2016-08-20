using System;
namespace KNet.Model
{
    /// <summary>
    /// Xs_Sales_Quotes_Details:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Xs_Sales_Quotes_Details
    {
        public Xs_Sales_Quotes_Details()
        { }
        #region Model
        private string _sqd_id;
        private string _sqd_fid;
        private string _sqd_productsbarcode;
        private decimal? _sqd_number;
        private decimal? _sqd_price;
        private decimal? _sqd_money;
        private decimal? _sqd_percent;
        private decimal? _sqd_percentedmoney;
        private string _sqd_remarks;
        /// <summary>
        /// 
        /// </summary>
        public string SQD_ID
        {
            set { _sqd_id = value; }
            get { return _sqd_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SQD_FID
        {
            set { _sqd_fid = value; }
            get { return _sqd_fid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SQD_ProductsBarCode
        {
            set { _sqd_productsbarcode = value; }
            get { return _sqd_productsbarcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SQD_Number
        {
            set { _sqd_number = value; }
            get { return _sqd_number; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SQD_Price
        {
            set { _sqd_price = value; }
            get { return _sqd_price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SQD_Money
        {
            set { _sqd_money = value; }
            get { return _sqd_money; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SQD_Percent
        {
            set { _sqd_percent = value; }
            get { return _sqd_percent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SQD_PercentedMoney
        {
            set { _sqd_percentedmoney = value; }
            get { return _sqd_percentedmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SQD_Remarks
        {
            set { _sqd_remarks = value; }
            get { return _sqd_remarks; }
        }
        #endregion Model

    }
}

