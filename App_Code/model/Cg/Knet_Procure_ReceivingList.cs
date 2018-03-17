using System;
namespace KNet.Model
{
    /// <summary>
    /// 实体类Knet_Procure_ReceivingList
    /// </summary>
    [Serializable]
    public class Knet_Procure_ReceivingList
    {
        public Knet_Procure_ReceivingList()
        { }
        #region Model
        private string _id;
        private string _receivno;
        private string _receivtopic;
        private string _orderno;
        private DateTime? _receivdatetime;
        private string _suppno;
        private string _receivpaymentnotes;
        private string _receivstaffbranch;
        private string _receivstaffdepart;

        private decimal? _ordertransshare;
        private string _ordertype;

        private string _receivstaffno;
        private string _receivcheckstaffno;
        private string _receivremarks;
        private bool _receivcheckyn;



        /// <summary>
        /// 运输分担
        /// </summary>
        public decimal? OrderTransShare
        {
            set { _ordertransshare = value; }
            get { return _ordertransshare; }
        }
        /// <summary>
        /// 采购类型（紧急采购，大件采购等）
        /// </summary>
        public string OrderType
        {
            set { _ordertype = value; }
            get { return _ordertype; }
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
        /// 收货单（唯一性）
        /// </summary>
        public string ReceivNo
        {
            set { _receivno = value; }
            get { return _receivno; }
        }
        /// <summary>
        /// 收货主题
        /// </summary>
        public string ReceivTopic
        {
            set { _receivtopic = value; }
            get { return _receivtopic; }
        }
        /// <summary>
        /// 原采购单号
        /// </summary>
        public string OrderNo
        {
            set { _orderno = value; }
            get { return _orderno; }
        }
        /// <summary>
        /// 收货日期
        /// </summary>
        public DateTime? ReceivDateTime
        {
            set { _receivdatetime = value; }
            get { return _receivdatetime; }
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
        /// 结算方式唯一值
        /// </summary>
        public string ReceivPaymentNotes
        {
            set { _receivpaymentnotes = value; }
            get { return _receivpaymentnotes; }
        }
        /// <summary>
        /// 采购公司
        /// </summary>
        public string ReceivStaffBranch
        {
            set { _receivstaffbranch = value; }
            get { return _receivstaffbranch; }
        }
        /// <summary>
        /// 采购部门
        /// </summary>
        public string ReceivStaffDepart
        {
            set { _receivstaffdepart = value; }
            get { return _receivstaffdepart; }
        }
        /// <summary>
        /// 采购人唯一值
        /// </summary>
        public string ReceivStaffNo
        {
            set { _receivstaffno = value; }
            get { return _receivstaffno; }
        }
        /// <summary>
        /// 采购单审核人
        /// </summary>
        public string ReceivCheckStaffNo
        {
            set { _receivcheckstaffno = value; }
            get { return _receivcheckstaffno; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string ReceivRemarks
        {
            set { _receivremarks = value; }
            get { return _receivremarks; }
        }
        /// <summary>
        /// 是否已审核 （0未审，1已审）
        /// </summary>
        public bool ReceivCheckYN
        {
            set { _receivcheckyn = value; }
            get { return _receivcheckyn; }
        }
        #endregion Model

    }
}

