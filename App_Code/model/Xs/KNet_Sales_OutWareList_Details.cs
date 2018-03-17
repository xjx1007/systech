using System;
namespace KNet.Model
{
    /// <summary>
    /// 实体类KNet_Sales_OutWareList_Details 
    /// </summary>
    [Serializable]
    public class KNet_Sales_OutWareList_Details
    {
        public KNet_Sales_OutWareList_Details()
        { }
        #region Model
        private string _id;
        private string _outwareno;
        private string _productsname;
        private string _productsbarcode;
        private string _productspattern;
        private string _productsunits;
        private int? _outwareamount;
        private decimal? _outwareunitprice;
        private decimal? _outwarediscount;
        private decimal? _outwaretotalnet;
        private decimal? _outware_salesunitprice;
        private decimal? _outware_salesdiscount;
        private decimal? _outware_salestotalnet;
        private string _outwareremarks;
        private int? _outwarereceiving;
        private string _KSO_Battery;
        private string _KSO_Manual;
        private int? _KSD_BNumber;
        private string _KSO_ContractDetailsID;
        private string _RCOrderNo;
        private string _MaterOrderNo;
        private string _RCMNo;
        private string _MaterMNo;
        private string _KSD_ContractNO;
        private string _KSO_IsFollow;
        
        /// <summary>
        /// 自动ID值
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 关联-----出货单号
        /// </summary>
        public string OutWareNo
        {
            set { _outwareno = value; }
            get { return _outwareno; }
        }
        /// <summary>
        /// 合同出货明细---产品名称
        /// </summary>
        public string ProductsName
        {
            set { _productsname = value; }
            get { return _productsname; }
        }
        /// <summary>
        /// 合同出货明细---编码（条形码）（唯一值）
        /// </summary>
        public string ProductsBarCode
        {
            set { _productsbarcode = value; }
            get { return _productsbarcode; }
        }
        /// <summary>
        /// 合同出货明细---产品型号
        /// </summary>
        public string ProductsPattern
        {
            set { _productspattern = value; }
            get { return _productspattern; }
        }
        /// <summary>
        /// 合同出货明细---单位
        /// </summary>
        public string ProductsUnits
        {
            set { _productsunits = value; }
            get { return _productsunits; }
        }
        /// <summary>
        /// 合同出货明细---产品数量
        /// </summary>
        public int? OutWareAmount
        {
            set { _outwareamount = value; }
            get { return _outwareamount; }
        }
        /// <summary>
        /// 合同出货明细---成本单价
        /// </summary>
        public decimal? OutWareUnitPrice
        {
            set { _outwareunitprice = value; }
            get { return _outwareunitprice; }
        }
        /// <summary>
        /// 合同出货明细---成本折扣
        /// </summary>
        public decimal? OutWareDiscount
        {
            set { _outwarediscount = value; }
            get { return _outwarediscount; }
        }
        /// <summary>
        /// 合同出货明细---成本金额合计
        /// </summary>
        public decimal? OutWareTotalNet
        {
            set { _outwaretotalnet = value; }
            get { return _outwaretotalnet; }
        }
        /// <summary>
        /// 合同出货---销售单价
        /// </summary>
        public decimal? OutWare_SalesUnitPrice
        {
            set { _outware_salesunitprice = value; }
            get { return _outware_salesunitprice; }
        }
        /// <summary>
        /// 合同出货明细---销售折扣
        /// </summary>
        public decimal? OutWare_SalesDiscount
        {
            set { _outware_salesdiscount = value; }
            get { return _outware_salesdiscount; }
        }
        /// <summary>
        /// 合同出货明细---销售金额合计
        /// </summary>
        public decimal? OutWare_SalesTotalNet
        {
            set { _outware_salestotalnet = value; }
            get { return _outware_salestotalnet; }
        }
        /// <summary>
        /// 合同出货明细----备注
        /// </summary>
        public string OutWareRemarks
        {
            set { _outwareremarks = value; }
            get { return _outwareremarks; }
        }
        /// <summary>
        /// 合同出货--出货后退回数量
        /// </summary>
        public int? OutWareReceiving
        {
            set { _outwarereceiving = value; }
            get { return _outwarereceiving; }
        }
        /// <summary>
        /// 合同出货--出货后退回数量
        /// </summary>
        public int? KSD_BNumber
        {
            set { _KSD_BNumber = value; }
            get { return _KSD_BNumber; }
        }
        
        public string KSO_Battery
        {
            set { _KSO_Battery = value; }
            get { return _KSO_Battery; }
        }
        public string KSO_Manual
        {
            set { _KSO_Manual = value; }
            get { return _KSO_Manual; }
        }
        public string KSO_ContractDetailsID
        {
            set { _KSO_ContractDetailsID = value; }
            get { return _KSO_ContractDetailsID; }
        }
        public string KSD_ContractNO
        {
            set { _KSD_ContractNO = value; }
            get { return _KSD_ContractNO; }
        }
        public string RCOrderNo
        {
            set { _RCOrderNo = value; }
            get { return _RCOrderNo; }
        }
        public string MaterOrderNo
        {
            set { _MaterOrderNo = value; }
            get { return _MaterOrderNo; }
        }
        public string RCMNo
        {
            set { _RCMNo = value; }
            get { return _RCMNo; }
        }
        public string MaterMNo
        {
            set { _MaterMNo = value; }
            get { return _MaterMNo; }
        }
        public string KSO_IsFollow
        {
            set { _KSO_IsFollow = value; }
            get { return _KSO_IsFollow; }
        }
        
        #endregion Model

    }
}

