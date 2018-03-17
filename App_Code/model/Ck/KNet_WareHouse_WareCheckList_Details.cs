using System;
namespace KNet.Model
{
    /// <summary>
    /// 实体类KNet_WareHouse_WareCheckList_Details 
    /// </summary>
    [Serializable]
    public class KNet_WareHouse_WareCheckList_Details
    {
        public KNet_WareHouse_WareCheckList_Details()
        { }
        #region Model
        private string _id;
        private string _warecheckno;
        private string _productsname;
        private string _productsbarcode;
        private string _productspattern;
        private string _productsunits;
        private int? _warecheckamount;
        private int? _WareCheckLossUp;
        private decimal? _warecheckunitprice;
        private decimal? _warecheckdiscount;
        private decimal? _warechecktotalnet;
        private string _warecheckremarks;
        private string _OwnallPID;

        /// <summary>
        /// 总仓库产品ID
        /// </summary>
        public string OwnallPID
        {
            set { _OwnallPID = value; }
            get { return _OwnallPID; }
        }
        /// <summary>
        /// 盘点 1盘正，2盘负
        /// </summary>
        public int? WareCheckLossUp
        {
            set { _WareCheckLossUp = value; }
            get { return _WareCheckLossUp; }
        }

        /// <summary>
        /// 自动唯一值
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 盘点 单号
        /// </summary>
        public string WareCheckNo
        {
            set { _warecheckno = value; }
            get { return _warecheckno; }
        }
        /// <summary>
        /// 盘点 产品名称
        /// </summary>
        public string ProductsName
        {
            set { _productsname = value; }
            get { return _productsname; }
        }
        /// <summary>
        /// 产品条形码
        /// </summary>
        public string ProductsBarCode
        {
            set { _productsbarcode = value; }
            get { return _productsbarcode; }
        }
        /// <summary>
        /// 产品型号
        /// </summary>
        public string ProductsPattern
        {
            set { _productspattern = value; }
            get { return _productspattern; }
        }
        /// <summary>
        /// 盘点 单位
        /// </summary>
        public string ProductsUnits
        {
            set { _productsunits = value; }
            get { return _productsunits; }
        }
        /// <summary>
        /// 盘点 差异数量
        /// </summary>
        public int? WareCheckAmount
        {
            set { _warecheckamount = value; }
            get { return _warecheckamount; }
        }
        /// <summary>
        /// 盘点 单价
        /// </summary>
        public decimal? WareCheckUnitPrice
        {
            set { _warecheckunitprice = value; }
            get { return _warecheckunitprice; }
        }
        /// <summary>
        /// 盘点 计调金额
        /// </summary>
        public decimal? WareCheckDiscount
        {
            set { _warecheckdiscount = value; }
            get { return _warecheckdiscount; }
        }
        /// <summary>
        /// 盘点 净值金额
        /// </summary>
        public decimal? WareCheckTotalNet
        {
            set { _warechecktotalnet = value; }
            get { return _warechecktotalnet; }
        }
        /// <summary>
        /// 盘点 产品备注
        /// </summary>
        public string WareCheckRemarks
        {
            set { _warecheckremarks = value; }
            get { return _warecheckremarks; }
        }
        #endregion Model

    }
}

