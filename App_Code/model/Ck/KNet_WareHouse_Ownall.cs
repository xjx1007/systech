using System;
namespace KNet.Model
{
    /// <summary>
    /// 实体类KNet_WareHouse_Ownall
    /// </summary>
    [Serializable]
    public class KNet_WareHouse_Ownall
    {
        public KNet_WareHouse_Ownall()
        { }
        #region Model
        private string _id;
        private string _houseno;
        private string _productsname;
        private string _productsbarcode;
        private string _productspattern;
        private string _productsunits;
        private int? _warehouseamount;
        private decimal? _warehousetotalnet;
        private decimal? _warehousediscount;


        private string _ordernumber;
        private string _singlestorage;
        private DateTime? _storagetime;
        private int? _storagevolume;
        private int? _shippedquantity;

        /// <summary>
        /// 自动ID值
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 仓库总台——仓库唯一值
        /// </summary>
        public string HouseNo
        {
            set { _houseno = value; }
            get { return _houseno; }
        }
        /// <summary>
        /// 仓库总账---产品名称
        /// </summary>
        public string ProductsName
        {
            set { _productsname = value; }
            get { return _productsname; }
        }
        /// <summary>
        /// 仓库总账---编码（条形码）（唯一值）
        /// </summary>
        public string ProductsBarCode
        {
            set { _productsbarcode = value; }
            get { return _productsbarcode; }
        }
        /// <summary>
        /// 仓库总账---产品型号
        /// </summary>
        public string ProductsPattern
        {
            set { _productspattern = value; }
            get { return _productspattern; }
        }
        /// <summary>
        /// 仓库总账---单位
        /// </summary>
        public string ProductsUnits
        {
            set { _productsunits = value; }
            get { return _productsunits; }
        }
        /// <summary>
        /// 仓库总账---现存数量
        /// </summary>
        public int? WareHouseAmount
        {
            set { _warehouseamount = value; }
            get { return _warehouseamount; }
        }
        /// <summary>
        /// 仓库总账---净值合计
        /// </summary>
        public decimal? WareHouseTotalNet
        {
            set { _warehousetotalnet = value; }
            get { return _warehousetotalnet; }
        }
        /// <summary>
        /// 仓库总账---计调合计
        /// </summary>
        public decimal? WareHouseDiscount
        {
            set { _warehousediscount = value; }
            get { return _warehousediscount; }
        }


        /// <summary>
        /// 采购单号
        /// </summary>
        public string OrderNumber
        {
            set { _ordernumber = value; }
            get { return _ordernumber; }
        }
        /// <summary>
        /// 入库单号
        /// </summary>
        public string SingleStorage
        {
            set { _singlestorage = value; }
            get { return _singlestorage; }
        }
        /// <summary>
        /// 入库时间
        /// </summary>
        public DateTime? StorageTime
        {
            set { _storagetime = value; }
            get { return _storagetime; }
        }
        /// <summary>
        /// 入库数量
        /// </summary>
        public int? StorageVolume
        {
            set { _storagevolume = value; }
            get { return _storagevolume; }
        }
        /// <summary>
        /// 已出货数量
        /// </summary>
        public int? ShippedQuantity
        {
            set { _shippedquantity = value; }
            get { return _shippedquantity; }
        }


        #endregion Model

    }
}

