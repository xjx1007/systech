using System;
namespace KNet.Model
{
    /// <summary>
    /// 实体类Knet_Procure_WareHouseList_Details 
    /// </summary>
    [Serializable]
    public class Knet_Procure_WareHouseList_Details
    {
        public Knet_Procure_WareHouseList_Details()
        { }
        #region Model
        private string _id;
        private string _warehouseno;
        private string _productsname;
        private string _productsbarcode;
        private string _productspattern;
        private string _productsunits;
        private string _warehousepack;
        private int? _warehouseamount;
        private decimal? _warehouseunitprice;
        private decimal? _warehousediscount;
        private decimal? _warehousetotalnet;
        private string _warehouseremarks;
        private int? _warehousebamount;
        private decimal _KWP_NoTaxMoney;
        private int _KWP_NoTaxLag;
        /// <summary>
        /// 自动ID值
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 入库单号
        /// </summary>
        public string WareHouseNo
        {
            set { _warehouseno = value; }
            get { return _warehouseno; }
        }
        /// <summary>
        /// 入库明细---产品名称
        /// </summary>
        public string ProductsName
        {
            set { _productsname = value; }
            get { return _productsname; }
        }
        /// <summary>
        /// 入库明细---编码（条形码）
        /// </summary>
        public string ProductsBarCode
        {
            set { _productsbarcode = value; }
            get { return _productsbarcode; }
        }
        /// <summary>
        /// 入库明细---产品型号
        /// </summary>
        public string ProductsPattern
        {
            set { _productspattern = value; }
            get { return _productspattern; }
        }
        /// <summary>
        /// 入库明细---单位
        /// </summary>
        public string ProductsUnits
        {
            set { _productsunits = value; }
            get { return _productsunits; }
        }
        /// <summary>
        /// 入库明细   产品包装
        /// </summary>
        public string WareHousePack
        {
            set { _warehousepack = value; }
            get { return _warehousepack; }
        }
        /// <summary>
        /// 入库明细---数量
        /// </summary>
        public int? WareHouseAmount
        {
            set { _warehouseamount = value; }
            get { return _warehouseamount; }
        }
        /// <summary>
        /// 入库明细---单价(原采购单价)
        /// </summary>
        public decimal? WareHouseUnitPrice
        {
            set { _warehouseunitprice = value; }
            get { return _warehouseunitprice; }
        }
        /// <summary>
        /// 入库明细---计价调节(原调价平均)
        /// </summary>
        public decimal? WareHouseDiscount
        {
            set { _warehousediscount = value; }
            get { return _warehousediscount; }
        }
        /// <summary>
        /// 入库明细---净值合计(原净值平均)
        /// </summary>
        public decimal? WareHouseTotalNet
        {
            set { _warehousetotalnet = value; }
            get { return _warehousetotalnet; }
        }
        /// <summary>
        /// 入库产品明细----备注
        /// </summary>
        public string WareHouseRemarks
        {
            set { _warehouseremarks = value; }
            get { return _warehouseremarks; }
        }
        /// <summary>
        /// 入库明细---备货数量
        /// </summary>
        public int? WareHouseBAmount
        {
            set { _warehousebamount = value; }
            get { return _warehousebamount; }
        }
        public decimal KWP_NoTaxMoney
        {
            set { _KWP_NoTaxMoney = value; }
            get { return _KWP_NoTaxMoney; }
 
        }

        public int KWP_NoTaxLag
        {
            set { _KWP_NoTaxLag = value; }
            get { return _KWP_NoTaxLag; }
 
        }
        
        #endregion Model

    }
}

