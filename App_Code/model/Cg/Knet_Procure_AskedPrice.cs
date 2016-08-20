using System;
namespace KNet.Model
{
    /// <summary>
    /// 实体类Knet_Procure_AskedPrice
    /// </summary>
    [Serializable]
    public class Knet_Procure_AskedPrice
    {
        public Knet_Procure_AskedPrice()
        { }
        #region Model
        private string _id;
        private string _askedpricetopic;
        private string _askedpriceno;
        private DateTime? _askedpricedatetime;
        private string _suppno;
        private string _askedpricestaffbranch;
        private string _askedpricestaffdepart;
        private string _askedpricestaffno;
        private int? _askedpricestate;
        private string _askedpricecontent;
        /// <summary>
        /// 自动ID值
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 采购询价主题
        /// </summary>
        public string AskedPriceTopic
        {
            set { _askedpricetopic = value; }
            get { return _askedpricetopic; }
        }
        /// <summary>
        /// 采购询价单号（维一性）
        /// </summary>
        public string AskedPriceNo
        {
            set { _askedpriceno = value; }
            get { return _askedpriceno; }
        }
        /// <summary>
        /// 采购询价日期
        /// </summary>
        public DateTime? AskedPriceDateTime
        {
            set { _askedpricedatetime = value; }
            get { return _askedpricedatetime; }
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
        /// 采购询价公司
        /// </summary>
        public string AskedPriceStaffBranch
        {
            set { _askedpricestaffbranch = value; }
            get { return _askedpricestaffbranch; }
        }
        /// <summary>
        /// 采购询价部门
        /// </summary>
        public string AskedPriceStaffDepart
        {
            set { _askedpricestaffdepart = value; }
            get { return _askedpricestaffdepart; }
        }
        /// <summary>
        /// 采购询价人唯一值
        /// </summary>
        public string AskedPriceStaffNo
        {
            set { _askedpricestaffno = value; }
            get { return _askedpricestaffno; }
        }
        /// <summary>
        /// 采购询价状态（0初稿，1定稿，2执行，3作废,4完成）
        /// </summary>
        public int? AskedPriceState
        {
            set { _askedpricestate = value; }
            get { return _askedpricestate; }
        }
        /// <summary>
        /// 采购询价内容
        /// </summary>
        public string AskedPriceContent
        {
            set { _askedpricecontent = value; }
            get { return _askedpricecontent; }
        }
        #endregion Model

    }
}

