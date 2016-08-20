using System;
namespace KNet.Model
{
    /// <summary>
    /// 实体类A_Deliveryfa 
    /// </summary>
    [Serializable]
    public class A_Deliveryfa
    {
        public A_Deliveryfa()
        { }
        #region Model
        private string _id;
        private string _contractordernumber;
        private string _invoiceordernumber;
        private string _customername;
        private string _customervalue;
        private DateTime? _deliverydate;
        private decimal? _loanamount;
        private DateTime? _expirationdate;
        private int? _settlementstatus;
        private string _shippingwarehouse;
        private DateTime? _thedateofconstruction;
        private DateTime? _settlementdate;
        /// <summary>
        /// 自动ID值
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 合同订单号
        /// </summary>
        public string ContractOrderNumber
        {
            set { _contractordernumber = value; }
            get { return _contractordernumber; }
        }
        /// <summary>
        /// 发货单号
        /// </summary>
        public string InvoiceOrderNumber
        {
            set { _invoiceordernumber = value; }
            get { return _invoiceordernumber; }
        }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName
        {
            set { _customername = value; }
            get { return _customername; }
        }
        /// <summary>
        /// 客户编号
        /// </summary>
        public string CustomerValue
        {
            set { _customervalue = value; }
            get { return _customervalue; }
        }
        /// <summary>
        /// 发货日期
        /// </summary>
        public DateTime? DeliveryDate
        {
            set { _deliverydate = value; }
            get { return _deliverydate; }
        }
        /// <summary>
        /// 货款金额
        /// </summary>
        public decimal? LoanAmount
        {
            set { _loanamount = value; }
            get { return _loanamount; }
        }
        /// <summary>
        /// 到期日期
        /// </summary>
        public DateTime? ExpirationDate
        {
            set { _expirationdate = value; }
            get { return _expirationdate; }
        }
        /// <summary>
        /// 结算状态（1新单，2已结算）
        /// </summary>
        public int? SettlementStatus
        {
            set { _settlementstatus = value; }
            get { return _settlementstatus; }
        }
        /// <summary>
        /// 发货仓库
        /// </summary>
        public string ShippingWarehouse
        {
            set { _shippingwarehouse = value; }
            get { return _shippingwarehouse; }
        }
        /// <summary>
        /// 建单日期（自动获取）
        /// </summary>
        public DateTime? Thedateofconstruction
        {
            set { _thedateofconstruction = value; }
            get { return _thedateofconstruction; }
        }
        /// <summary>
        /// 结算日期
        /// </summary>
        public DateTime? SettlementDate
        {
            set { _settlementdate = value; }
            get { return _settlementdate; }
        }
        #endregion Model

    }
}

