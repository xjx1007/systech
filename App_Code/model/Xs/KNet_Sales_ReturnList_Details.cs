using System;
namespace KNet.Model
{
    /// <summary>
    /// 实体类KNet_Sales_ReturnList_Details
    /// </summary>
    [Serializable]
    public class KNet_Sales_ReturnList_Details
    {
        public KNet_Sales_ReturnList_Details()
        { }
        #region Model
        private string _id;
        private string _returnno;
        private string _productsname;
        private string _productsbarcode;
        private string _productspattern;
        private string _productsunits;
        private int? _returnamount;
        private decimal? _returnunitprice;
        private decimal? _returndiscount;
        private decimal? _returntotalnet;
        private decimal? _return_salesunitprice;
        private decimal? _return_salesdiscount;
        private decimal? _return_salestotalnet;
        private string _returnremarks;
        /// <summary>
        /// 自动ID值
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 关联-----退货单号
        /// </summary>
        public string ReturnNo
        {
            set { _returnno = value; }
            get { return _returnno; }
        }
        /// <summary>
        /// 退货明细---产品名称
        /// </summary>
        public string ProductsName
        {
            set { _productsname = value; }
            get { return _productsname; }
        }
        /// <summary>
        /// 退货明细---编码（条形码）（唯一值）
        /// </summary>
        public string ProductsBarCode
        {
            set { _productsbarcode = value; }
            get { return _productsbarcode; }
        }
        /// <summary>
        /// 退货明细---产品型号
        /// </summary>
        public string ProductsPattern
        {
            set { _productspattern = value; }
            get { return _productspattern; }
        }
        /// <summary>
        /// 退货明细---单位
        /// </summary>
        public string ProductsUnits
        {
            set { _productsunits = value; }
            get { return _productsunits; }
        }
        /// <summary>
        /// 退货明细---产品数量
        /// </summary>
        public int? ReturnAmount
        {
            set { _returnamount = value; }
            get { return _returnamount; }
        }
        /// <summary>
        /// 退货明细---成本单价
        /// </summary>
        public decimal? ReturnUnitPrice
        {
            set { _returnunitprice = value; }
            get { return _returnunitprice; }
        }
        /// <summary>
        /// 退货明细---成本折扣
        /// </summary>
        public decimal? ReturnDiscount
        {
            set { _returndiscount = value; }
            get { return _returndiscount; }
        }
        /// <summary>
        /// 退货明细---成本金额合计
        /// </summary>
        public decimal? ReturnTotalNet
        {
            set { _returntotalnet = value; }
            get { return _returntotalnet; }
        }
        /// <summary>
        /// 退货---销售单价
        /// </summary>
        public decimal? Return_SalesUnitPrice
        {
            set { _return_salesunitprice = value; }
            get { return _return_salesunitprice; }
        }
        /// <summary>
        /// 退货明细---销售折扣
        /// </summary>
        public decimal? Return_SalesDiscount
        {
            set { _return_salesdiscount = value; }
            get { return _return_salesdiscount; }
        }
        /// <summary>
        /// 退货明细---销售金额合计
        /// </summary>
        public decimal? Return_SalesTotalNet
        {
            set { _return_salestotalnet = value; }
            get { return _return_salestotalnet; }
        }
        /// <summary>
        /// 退货明细----备注
        /// </summary>
        public string ReturnRemarks
        {
            set { _returnremarks = value; }
            get { return _returnremarks; }
        }
        #endregion Model

    }
}

