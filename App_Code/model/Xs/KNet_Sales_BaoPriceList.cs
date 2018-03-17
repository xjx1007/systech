using System;
namespace KNet.Model
{
    /// <summary>
    /// 实体类KNet_Sales_BaoPriceList 
    /// </summary>
    [Serializable]
    public class KNet_Sales_BaoPriceList
    {
        public KNet_Sales_BaoPriceList()
        { }
        #region Model
        private string _id;
        private string _baopriceno;
        private string _baopricetopic;
        private string _customervalue;
        private string _baopricepaymentnotes;
        private DateTime? _baopricedatetime;
        private DateTime? _baoendtodatetime;
        private decimal? _baopricetransshare;
        private string _baopricewarranty;
        private string _baopricetoaddress;
        private string _baopricedelivemethods;
        private string _baopricestaffbranch;
        private string _baopricestaffdepart;
        private string _baopricestaffno;
        private string _baopricecheckstaffno;
        private string _baopriceremarks;
        private bool _baopricecheckyn;
        private string _clause;
        private string _priceterms;
        /// <summary>
        /// 自动ID值
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 报价编号（唯一值）
        /// </summary>
        public string BaoPriceNo
        {
            set { _baopriceno = value; }
            get { return _baopriceno; }
        }
        /// <summary>
        /// 报价主题
        /// </summary>
        public string BaoPriceTopic
        {
            set { _baopricetopic = value; }
            get { return _baopricetopic; }
        }
        /// <summary>
        /// 关联客户唯一值
        /// </summary>
        public string CustomerValue
        {
            set { _customervalue = value; }
            get { return _customervalue; }
        }
        /// <summary>
        /// 报价结算方式
        /// </summary>
        public string BaoPricePaymentNotes
        {
            set { _baopricepaymentnotes = value; }
            get { return _baopricepaymentnotes; }
        }
        /// <summary>
        /// 报价日期
        /// </summary>
        public DateTime? BaoPriceDateTime
        {
            set { _baopricedatetime = value; }
            get { return _baopricedatetime; }
        }
        /// <summary>
        /// 送货日期
        /// </summary>
        public DateTime? BaoEndtoDateTime
        {
            set { _baoendtodatetime = value; }
            get { return _baoendtodatetime; }
        }
        /// <summary>
        /// 运输分担
        /// </summary>
        public decimal? BaoPriceTransShare
        {
            set { _baopricetransshare = value; }
            get { return _baopricetransshare; }
        }
        /// <summary>
        /// 质保期
        /// </summary>
        public string BaoPriceWarranty
        {
            set { _baopricewarranty = value; }
            get { return _baopricewarranty; }
        }
        /// <summary>
        /// 送货地址
        /// </summary>
        public string BaoPriceToAddress
        {
            set { _baopricetoaddress = value; }
            get { return _baopricetoaddress; }
        }
        /// <summary>
        /// 交货方式
        /// </summary>
        public string BaoPriceDeliveMethods
        {
            set { _baopricedelivemethods = value; }
            get { return _baopricedelivemethods; }
        }
        /// <summary>
        /// 报价分公司
        /// </summary>
        public string BaoPriceStaffBranch
        {
            set { _baopricestaffbranch = value; }
            get { return _baopricestaffbranch; }
        }
        /// <summary>
        /// 报价部门
        /// </summary>
        public string BaoPriceStaffDepart
        {
            set { _baopricestaffdepart = value; }
            get { return _baopricestaffdepart; }
        }
        /// <summary>
        /// 报价（经办）人
        /// </summary>
        public string BaoPriceStaffNo
        {
            set { _baopricestaffno = value; }
            get { return _baopricestaffno; }
        }
        /// <summary>
        /// 报价（审核）人
        /// </summary>
        public string BaoPriceCheckStaffNo
        {
            set { _baopricecheckstaffno = value; }
            get { return _baopricecheckstaffno; }
        }
        /// <summary>
        /// 报价备注
        /// </summary>
        public string BaoPriceRemarks
        {
            set { _baopriceremarks = value; }
            get { return _baopriceremarks; }
        }
        /// <summary>
        /// 报价是否已通过审核
        /// </summary>
        public bool BaoPriceCheckYN
        {
            set { _baopricecheckyn = value; }
            get { return _baopricecheckyn; }
        }

        public string Clause
        {
            set { _clause = value; }
            get { return _clause; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PriceTerms
        {
            set { _priceterms = value; }
            get { return _priceterms; }
        }
        #endregion Model

    }
}

