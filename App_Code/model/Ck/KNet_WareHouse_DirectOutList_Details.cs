using System;
namespace KNet.Model
{
    /// <summary>
    /// 实体类KNet_WareHouse_DirectOutList_Details
    /// </summary>
    [Serializable]
    public class KNet_WareHouse_DirectOutList_Details
    {
        public KNet_WareHouse_DirectOutList_Details()
        { }
        #region Model
        private string _id;
        private string _directoutno;
        private string _productsname;
        private string _productsbarcode;
        private string _productspattern;
        private string _productsunits;
        private int? _directoutamount;
        private decimal? _directoutunitprice;
        private decimal? _directoutdiscount;
        private decimal? _directouttotalnet;
        private string _directoutremarks;
        private string _OwnallPID;
        private decimal? _DZnumber;

        private decimal? _KWD_SalesUnitPrice;
        private decimal? _KWD_SalesTotalNet;
        private int? _KWD_BNumber;
        private int? _IsChang;
        private string _KWD_OutWareID;

        private string _CustomerProductsName;
        private string _PlanNo;
        private string _OrderNo;
        private string _MaterNo;
        private string _KWD_IsFollow;
        private decimal _KWD_WwPrice;
        private decimal _KWD_WwMoney;


        public decimal KWD_WwMoney
        {
            set { _KWD_WwMoney = value; }
            get { return _KWD_WwMoney; }
        }
        /// <summary>
        /// 总仓库中的产品ID值
        /// </summary>
        public decimal KWD_WwPrice
        {
            set { _KWD_WwPrice = value; }
            get { return _KWD_WwPrice; }
        }
        /// <summary>
        /// 总仓库中的产品ID值
        /// </summary>
        public string OwnallPID
        {
            set { _OwnallPID = value; }
            get { return _OwnallPID; }
        }

        /// <summary>
        /// 自动ID值
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 关联 直接出库单号
        /// </summary>
        public string DirectOutNo
        {
            set { _directoutno = value; }
            get { return _directoutno; }
        }
        /// <summary>
        /// 直接出库明细---产品名称
        /// </summary>
        public string ProductsName
        {
            set { _productsname = value; }
            get { return _productsname; }
        }
        /// <summary>
        /// 直接出库明细---编码（条形码）
        /// </summary>
        public string ProductsBarCode
        {
            set { _productsbarcode = value; }
            get { return _productsbarcode; }
        }
        /// <summary>
        /// 直接出库 明细---产品型号
        /// </summary>
        public string ProductsPattern
        {
            set { _productspattern = value; }
            get { return _productspattern; }
        }
        /// <summary>
        /// 直接出库明细---单位
        /// </summary>
        public string ProductsUnits
        {
            set { _productsunits = value; }
            get { return _productsunits; }
        }
        /// <summary>
        /// 直接出库明细---收货数量
        /// </summary>
        public int? DirectOutAmount
        {
            set { _directoutamount = value; }
            get { return _directoutamount; }
        }
        /// <summary>
        /// 直接出库明细---收货单价(原采购单价)
        /// </summary>
        public decimal? DirectOutUnitPrice
        {
            set { _directoutunitprice = value; }
            get { return _directoutunitprice; }
        }
        /// <summary>
        /// 直接出库明细---计价调节(原调价平均)
        /// </summary>
        public decimal? DirectOutDiscount
        {
            set { _directoutdiscount = value; }
            get { return _directoutdiscount; }
        }
        /// <summary>
        /// 直接出库明细---净值合计(原净值平均)
        /// </summary>
        public decimal? DirectOutTotalNet
        {
            set { _directouttotalnet = value; }
            get { return _directouttotalnet; }
        }
        /// <summary>
        /// 直接出库产品明细----备注
        /// </summary>
        public string DirectOutRemarks
        {
            set { _directoutremarks = value; }
            get { return _directoutremarks; }
        }

        public decimal? DZnumber
        {
            set { _DZnumber = value; }
            get { return _DZnumber; }
        }
        public decimal? KWD_SalesUnitPrice
        {
            set { _KWD_SalesUnitPrice = value; }
            get { return _KWD_SalesUnitPrice; }
        }
        public decimal? KWD_SalesTotalNet
        {
            set { _KWD_SalesTotalNet = value; }
            get { return _KWD_SalesTotalNet; }
        }

        /// <summary>
        /// 直接出库明细---收货数量
        /// </summary>
        public int? KWD_BNumber
        {
            set { _KWD_BNumber = value; }
            get { return _KWD_BNumber; }
        }

        public int? IsChang
        {
            set { _IsChang = value; }
            get { return _IsChang; }
        }
        public string KWD_OutWareID
        {
            set { _KWD_OutWareID = value; }
            get { return _KWD_OutWareID; }
        }
        public string CustomerProductsName
        {
            set { _CustomerProductsName = value; }
            get { return _CustomerProductsName; }
        }

        public string PlanNo
        {
            set { _PlanNo = value; }
            get { return _PlanNo; }
        }
        public string OrderNo
        {
            set { _OrderNo = value; }
            get { return _OrderNo; }
        }
        public string MaterNo
        {
            set { _MaterNo = value; }
            get { return _MaterNo; }
        }
        public string KWD_IsFollow
        {
            set { _KWD_IsFollow = value; }
            get { return _KWD_IsFollow; }
        }


        
        #endregion Model

    }
}

