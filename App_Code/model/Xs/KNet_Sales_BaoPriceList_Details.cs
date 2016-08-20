using System;
namespace KNet.Model
{
    /// <summary>
    /// 实体类KNet_Sales_BaoPriceList_Details 
    /// </summary>
    [Serializable]
    public class KNet_Sales_BaoPriceList_Details
    {
        public KNet_Sales_BaoPriceList_Details()
        { }
        #region Model
        private string _id;
        private string _baopriceno;
        private string _productsname;
        private string _productsbarcode;
        private string _productspattern;
        private string _productsunits;
        private int? _baopriceamount;
        private decimal? _baopriceunitprice;
        private decimal? _baopricediscount;
        private decimal? _baopricetotalnet;
        private string _baopriceremarks;
        private int? _baopricereceiving;

    

        /// <summary>
        /// 自动ID值
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 关联报价编号
        /// </summary>
        public string BaoPriceNo
        {
            set { _baopriceno = value; }
            get { return _baopriceno; }
        }
        /// <summary>
        /// 报价明细---产品名称
        /// </summary>
        public string ProductsName
        {
            set { _productsname = value; }
            get { return _productsname; }
        }
        /// <summary>
        /// 报价明细---编码（条形码）（唯一值）
        /// </summary>
        public string ProductsBarCode
        {
            set { _productsbarcode = value; }
            get { return _productsbarcode; }
        }
        /// <summary>
        /// 报价明细---产品型号
        /// </summary>
        public string ProductsPattern
        {
            set { _productspattern = value; }
            get { return _productspattern; }
        }
        /// <summary>
        /// 报价明细---单位
        /// </summary>
        public string ProductsUnits
        {
            set { _productsunits = value; }
            get { return _productsunits; }
        }
        /// <summary>
        /// 报价明细---报价数量
        /// </summary>
        public int? BaoPriceAmount
        {
            set { _baopriceamount = value; }
            get { return _baopriceamount; }
        }
        /// <summary>
        /// 报价明细---报价单价
        /// </summary>
        public decimal? BaoPriceUnitPrice
        {
            set { _baopriceunitprice = value; }
            get { return _baopriceunitprice; }
        }
        /// <summary>
        /// 报价明细---计价调节
        /// </summary>
        public decimal? BaoPriceDiscount
        {
            set { _baopricediscount = value; }
            get { return _baopricediscount; }
        }
        /// <summary>
        /// 报价明细---净值合计
        /// </summary>
        public decimal? BaoPriceTotalNet
        {
            set { _baopricetotalnet = value; }
            get { return _baopricetotalnet; }
        }
        /// <summary>
        /// 报价产品明细----备注
        /// </summary>
        public string BaoPriceRemarks
        {
            set { _baopriceremarks = value; }
            get { return _baopriceremarks; }
        }
        /// <summary>
        /// 已入合同数量
        /// </summary>
        public int? BaoPriceReceiving
        {
            set { _baopricereceiving = value; }
            get { return _baopricereceiving; }
        }
        #endregion Model

    }
}

