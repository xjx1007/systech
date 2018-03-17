using System;
namespace KNet.Model
{
    /// <summary>
    /// 实体类KNet_WareHouse_DirectInto_Details
    /// </summary>
    [Serializable]
    public class KNet_WareHouse_DirectInto_Details
    {
        public KNet_WareHouse_DirectInto_Details()
        { }
        #region Model
        private string _id;
        private string _directinno;
        private string _productsname;
        private string _productsbarcode;
        private string _productspattern;
        private string _productsunits;
        private int? _directinamount;
        private decimal? _directinunitprice;
        private decimal? _directindiscount;
        private decimal? _directintotalnet;
        private string _directinremarks;
        /// <summary>
        /// 自动唯一值
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 关联 直接入库单号
        /// </summary>
        public string DirectInNo
        {
            set { _directinno = value; }
            get { return _directinno; }
        }
        /// <summary>
        /// 直接入库明细---产品名称
        /// </summary>
        public string ProductsName
        {
            set { _productsname = value; }
            get { return _productsname; }
        }
        /// <summary>
        /// 直接入库明细---编码（条形码）
        /// </summary>
        public string ProductsBarCode
        {
            set { _productsbarcode = value; }
            get { return _productsbarcode; }
        }
        /// <summary>
        /// 直接入库 明细---产品型号
        /// </summary>
        public string ProductsPattern
        {
            set { _productspattern = value; }
            get { return _productspattern; }
        }
        /// <summary>
        /// 直接入库明细---单位
        /// </summary>
        public string ProductsUnits
        {
            set { _productsunits = value; }
            get { return _productsunits; }
        }
        /// <summary>
        /// 直接入库明细---收货数量
        /// </summary>
        public int? DirectInAmount
        {
            set { _directinamount = value; }
            get { return _directinamount; }
        }
        /// <summary>
        /// 直接入库明细---收货单价(原采购单价)
        /// </summary>
        public decimal? DirectInUnitPrice
        {
            set { _directinunitprice = value; }
            get { return _directinunitprice; }
        }
        /// <summary>
        /// 直接入库明细---计价调节(原调价平均)
        /// </summary>
        public decimal? DirectInDiscount
        {
            set { _directindiscount = value; }
            get { return _directindiscount; }
        }
        /// <summary>
        /// 直接入库明细---净值合计(原净值平均)
        /// </summary>
        public decimal? DirectInTotalNet
        {
            set { _directintotalnet = value; }
            get { return _directintotalnet; }
        }
        /// <summary>
        /// 直接入库产品明细----备注
        /// </summary>
        public string DirectInRemarks
        {
            set { _directinremarks = value; }
            get { return _directinremarks; }
        }
        #endregion Model

    }
}


