using System;
namespace KNet.Model
{
    /// <summary>
    /// 实体类Knet_Procure_ReceivingList_Details 
    /// </summary>
    [Serializable]
    public class Knet_Procure_ReceivingList_Details
    {
        public Knet_Procure_ReceivingList_Details()
        { }
        #region Model
        private string _id;
        private string _receivno;
        private string _productsname;
        private string _productsbarcode;
        private string _productspattern;
        private string _productsunits;
        private int? _receivamount;
        private decimal? _receivunitprice;
        private decimal? _receivdiscount;
        private decimal? _receivtotalnet;
        private string _receivremarks;
        private int? _ReceivHaveWareHouse;
        /// <summary>
        /// 自动ID值
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 关联 收货单号
        /// </summary>
        public string ReceivNo
        {
            set { _receivno = value; }
            get { return _receivno; }
        }
        /// <summary>
        /// 收货明细---产品名称
        /// </summary>
        public string ProductsName
        {
            set { _productsname = value; }
            get { return _productsname; }
        }
        /// <summary>
        /// 收货明细---编码（条形码）
        /// </summary>
        public string ProductsBarCode
        {
            set { _productsbarcode = value; }
            get { return _productsbarcode; }
        }
        /// <summary>
        /// 收货 明细---产品型号
        /// </summary>
        public string ProductsPattern
        {
            set { _productspattern = value; }
            get { return _productspattern; }
        }
        /// <summary>
        /// 收货明细---单位
        /// </summary>
        public string ProductsUnits
        {
            set { _productsunits = value; }
            get { return _productsunits; }
        }
        /// <summary>
        /// 收货明细---收货数量
        /// </summary>
        public int? ReceivAmount
        {
            set { _receivamount = value; }
            get { return _receivamount; }
        }
        /// <summary>
        /// 收货明细---收货单价(原采购单价)
        /// </summary>
        public decimal? ReceivUnitPrice
        {
            set { _receivunitprice = value; }
            get { return _receivunitprice; }
        }
        /// <summary>
        /// 收货明细---计价调节(原调价平均)
        /// </summary>
        public decimal? ReceivDiscount
        {
            set { _receivdiscount = value; }
            get { return _receivdiscount; }
        }
        /// <summary>
        /// 收货明细---净值合计(原净值平均)
        /// </summary>
        public decimal? ReceivTotalNet
        {
            set { _receivtotalnet = value; }
            get { return _receivtotalnet; }
        }
        /// <summary>
        /// 收货产品明细----备注
        /// </summary>
        public string ReceivRemarks
        {
            set { _receivremarks = value; }
            get { return _receivremarks; }
        }

        /// <summary>
        /// 已收货入库数量
        /// </summary>
        public int? ReceivHaveWareHouse
        {
            set { _ReceivHaveWareHouse = value; }
            get { return _ReceivHaveWareHouse; }
        }

        #endregion Model

    }
}

