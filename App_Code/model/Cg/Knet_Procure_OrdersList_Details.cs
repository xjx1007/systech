using System;
namespace KNet.Model
{
    /// <summary>
    /// 实体类Knet_Procure_OrdersList_Details 
    /// </summary>
    public class Knet_Procure_OrdersList_Details
    {
        public Knet_Procure_OrdersList_Details()
        { }
        #region Model
        private string _id;
        private string _orderno;
        private string _productsname;
        private string _productsbarcode;
        private string _productspattern;
        private string _productsunits;
        private int? _orderamount;
        private decimal? _orderunitprice;
        private decimal? _orderdiscount;
        private decimal? _ordertotalnet;
        private string _orderremarks;
        private string _kpod_bigunits;

        private int? _OrderHaveReceiving;
        private int? _OrderHasReturned;
        private DateTime? _Add_DateTime;
        private decimal? _handprice;
        private decimal? _handtotal;
        private string _KPO_FaterBarCode;

        private int _KPOD_CPBZNumber;
        private int _KPOD_BZNumber;
        private string _KPOD_BrandName;
        private string _KPOD_BigUnits;
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? Add_DateTime
        {
            set { _Add_DateTime = value; }
            get { return _Add_DateTime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 总重量
        /// </summary>
        public string KPOD_BigUnits
        {
            set { _kpod_bigunits = value; }
            get { return _kpod_bigunits; }
        }
        /// <summary>
        /// 关联采购单号
        /// </summary>
        public string OrderNo
        {
            set { _orderno = value; }
            get { return _orderno; }
        }
        /// <summary>
        /// 采购明细---产品名称
        /// </summary>
        public string ProductsName
        {
            set { _productsname = value; }
            get { return _productsname; }
        }
        /// <summary>
        /// 采购明细---编码（条形码）（唯一值）
        /// </summary>
        public string ProductsBarCode
        {
            set { _productsbarcode = value; }
            get { return _productsbarcode; }
        }
        /// <summary>
        /// 采购明细---产品型号
        /// </summary>
        public string ProductsPattern
        {
            set { _productspattern = value; }
            get { return _productspattern; }
        }
        /// <summary>
        /// 采购明细---单位
        /// </summary>
        public string ProductsUnits
        {
            set { _productsunits = value; }
            get { return _productsunits; }
        }
        /// <summary>
        /// 采购明细---采购数量
        /// </summary>
        public int? OrderAmount
        {
            set { _orderamount = value; }
            get { return _orderamount; }
        }


        public int KPOD_CPBZNumber
        {
            set { _KPOD_CPBZNumber = value; }
            get { return _KPOD_CPBZNumber; }
        }

        public int KPOD_BZNumber
        {
            set { _KPOD_BZNumber = value; }
            get { return _KPOD_BZNumber; }
        }
        /// <summary>
        /// 采购明细---采购单价
        /// </summary>
        public decimal? OrderUnitPrice
        {
            set { _orderunitprice = value; }
            get { return _orderunitprice; }
        }
        /// <summary>
        /// 采购明细---计价调节
        /// </summary>
        public decimal? OrderDiscount
        {
            set { _orderdiscount = value; }
            get { return _orderdiscount; }
        }
        /// <summary>
        /// 采购明细---净值合计
        /// </summary>
        public decimal? OrderTotalNet
        {
            set { _ordertotalnet = value; }
            get { return _ordertotalnet; }
        }
        /// <summary>
        /// 采购产品明细----备注
        /// </summary>
        public string OrderRemarks
        {
            set { _orderremarks = value; }
            get { return _orderremarks; }
        }
        
        /// <summary>
        /// 采购产品明细----备注
        /// </summary>
        public string KPO_FaterBarCode
        {
            set { _KPO_FaterBarCode = value; }
            get { return _KPO_FaterBarCode; }
        }
        
        /// <summary>
        /// 采购明细---已收货数量
        /// </summary>
        public int? OrderHaveReceiving
        {
            set { _OrderHaveReceiving = value; }
            get { return _OrderHaveReceiving; }
        }

        /// <summary>
        /// 采购明细---已退货数量
        /// </summary>
        public int? OrderHasReturned
        {
            set { _OrderHasReturned = value; }
            get { return _OrderHasReturned; }
        }

        public decimal? HandPrice
        {
            set { _handprice = value; }
            get { return _handprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? HandTotal
        {
            set { _handtotal = value; }
            get { return _handtotal; }
        }


        public string KPOD_BrandName
        {
            set { _KPOD_BrandName = value; }
            get { return _KPOD_BrandName; }
        }
        
        #endregion Model

    }
}

