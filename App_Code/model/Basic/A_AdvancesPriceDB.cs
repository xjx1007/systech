using System;
namespace KNet.Model
{
    /// <summary>
    /// 实体类A_AdvancesPriceDB 
    /// </summary>
    [Serializable]
    public class A_AdvancesPriceDB
    {
        public A_AdvancesPriceDB()
        { }
        #region Model
        private string _id;
        private string _orderno;
        private string _ordertopic;
        private string _suppno;
        private decimal? _payamounts;
        private int? _paystate;
        private string _staffbranch;
        private string _staffdepart;
        private string _receivstaffno;
        private DateTime? _payaddtime;

        private decimal? _PayAmountsStay;
        /// <summary>
        /// 预付款金额
        /// </summary>
        public decimal? PayAmountsStay
        {
            set { _PayAmountsStay = value; }
            get { return _PayAmountsStay; }
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
        /// 采购单号（维一性）
        /// </summary>
        public string OrderNo
        {
            set { _orderno = value; }
            get { return _orderno; }
        }
        /// <summary>
        /// 采购主题
        /// </summary>
        public string OrderTopic
        {
            set { _ordertopic = value; }
            get { return _ordertopic; }
        }
        /// <summary>
        /// 供应商唯一编号
        /// </summary>
        public string SuppNo
        {
            set { _suppno = value; }
            get { return _suppno; }
        }
        /// <summary>
        /// 预付款金额
        /// </summary>
        public decimal? PayAmounts
        {
            set { _payamounts = value; }
            get { return _payamounts; }
        }
        /// <summary>
        /// 状态(0是新单，1已审核，2已完成）
        /// </summary>
        public int? PayState
        {
            set { _paystate = value; }
            get { return _paystate; }
        }
        /// <summary>
        /// 分公司
        /// </summary>
        public string StaffBranch
        {
            set { _staffbranch = value; }
            get { return _staffbranch; }
        }
        /// <summary>
        /// 部门
        /// </summary>
        public string StaffDepart
        {
            set { _staffdepart = value; }
            get { return _staffdepart; }
        }
        /// <summary>
        /// 经手人
        /// </summary>
        public string ReceivStaffNo
        {
            set { _receivstaffno = value; }
            get { return _receivstaffno; }
        }
        /// <summary>
        /// 建立账单时间
        /// </summary>
        public DateTime? PayAddTime
        {
            set { _payaddtime = value; }
            get { return _payaddtime; }
        }
        #endregion Model

    }
}

