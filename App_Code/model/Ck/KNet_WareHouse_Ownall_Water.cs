using System;
namespace KNet.Model
{
    /// <summary>
    /// 实体类KNet_WareHouse_Ownall_Water
    /// </summary>
    [Serializable]
    public class KNet_WareHouse_Ownall_Water
    {
        public KNet_WareHouse_Ownall_Water()
        { }
        #region Model
        private string _id;
        private string _houseno;
        private int? _watertype;
        private DateTime? _waterdatetime;
        private string _productsname;
        private string _productsbarcode;
        private string _productspattern;
        private string _productsunits;
        private string _waterhousepack;
        private int? _waterhouseamount;
        private decimal? _waterhouseunitprice;
        private decimal? _waterhousediscount;
        private decimal? _waterhousetotalnet;
        private string _watersupperunitsname;
        private string _waterunionorderno;
        private string _waterdostaffno;
        /// <summary>
        /// 自动ID值
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 仓库流水——进出仓库唯一值
        /// </summary>
        public string HouseNo
        {
            set { _houseno = value; }
            get { return _houseno; }
        }
        /// <summary>
        /// 类型（1 采购入库，2 销售出库，3 直接入库，4 直接出库）
        /// </summary>
        public int? WaterType
        {
            set { _watertype = value; }
            get { return _watertype; }
        }
        /// <summary>
        /// 仓库流水——发生时间
        /// </summary>
        public DateTime? WaterDateTime
        {
            set { _waterdatetime = value; }
            get { return _waterdatetime; }
        }
        /// <summary>
        /// 仓库流水——产品名称
        /// </summary>
        public string ProductsName
        {
            set { _productsname = value; }
            get { return _productsname; }
        }
        /// <summary>
        /// 仓库流水——编码（条形码）
        /// </summary>
        public string ProductsBarCode
        {
            set { _productsbarcode = value; }
            get { return _productsbarcode; }
        }
        /// <summary>
        /// 仓库流水——产品型号
        /// </summary>
        public string ProductsPattern
        {
            set { _productspattern = value; }
            get { return _productspattern; }
        }
        /// <summary>
        /// 仓库流水——单位
        /// </summary>
        public string ProductsUnits
        {
            set { _productsunits = value; }
            get { return _productsunits; }
        }
        /// <summary>
        /// 仓库流水——产品包装
        /// </summary>
        public string WaterHousePack
        {
            set { _waterhousepack = value; }
            get { return _waterhousepack; }
        }
        /// <summary>
        /// 仓库流水——数量
        /// </summary>
        public int? WaterHouseAmount
        {
            set { _waterhouseamount = value; }
            get { return _waterhouseamount; }
        }
        /// <summary>
        /// 仓库流水——单价(原采购单价)
        /// </summary>
        public decimal? WaterHouseUnitPrice
        {
            set { _waterhouseunitprice = value; }
            get { return _waterhouseunitprice; }
        }
        /// <summary>
        /// 仓库流水——计价调节(原调价平均)
        /// </summary>
        public decimal? WaterHouseDiscount
        {
            set { _waterhousediscount = value; }
            get { return _waterhousediscount; }
        }
        /// <summary>
        /// 仓库流水——净值合计(原净值平均)
        /// </summary>
        public decimal? WaterHouseTotalNet
        {
            set { _waterhousetotalnet = value; }
            get { return _waterhousetotalnet; }
        }
        /// <summary>
        /// 仓库流水——往来单位名称
        /// </summary>
        public string WaterSupperUnitsName
        {
            set { _watersupperunitsname = value; }
            get { return _watersupperunitsname; }
        }
        /// <summary>
        /// 仓库流水——关联单号
        /// </summary>
        public string WaterUnionOrderNo
        {
            set { _waterunionorderno = value; }
            get { return _waterunionorderno; }
        }
        /// <summary>
        /// 操作者唯一值
        /// </summary>
        public string WaterDoStaffNo
        {
            set { _waterdostaffno = value; }
            get { return _waterdostaffno; }
        }
        #endregion Model

    }
}

