using System;
namespace KNet.Model
{
    /// <summary>
    /// 实体类Knet_Procure_ReturnList
    /// </summary>
    [Serializable]
    public class Knet_Procure_ReturnList
    {
        public Knet_Procure_ReturnList()
        { }
        #region Model
        private string _id;
        private string _returnno;
        private string _returntopic;
        private string _orderno;
        private DateTime? _returndatetime;
        private string _suppno;
        private string _returnpaymentnotes;
        private string _returnstaffbranch;
        private string _returnstaffdepart;
        private string _returnstaffno;
        private string _returncheckstaffno;
        private string _returnremarks;
        private bool _returncheckyn;

        private decimal? _ordertransshare;
        private string _ordertype;


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
        /// 自动唯一值
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 退货单号（唯一性）
        /// </summary>
        public string ReturnNo
        {
            set { _returnno = value; }
            get { return _returnno; }
        }
        /// <summary>
        /// 退货单主题
        /// </summary>
        public string ReturnTopic
        {
            set { _returntopic = value; }
            get { return _returntopic; }
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
        /// 退货单日期
        /// </summary>
        public DateTime? ReturnDateTime
        {
            set { _returndatetime = value; }
            get { return _returndatetime; }
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
        /// 退货单结算方式唯一值
        /// </summary>
        public string ReturnPaymentNotes
        {
            set { _returnpaymentnotes = value; }
            get { return _returnpaymentnotes; }
        }
        /// <summary>
        /// 采购公司
        /// </summary>
        public string ReturnStaffBranch
        {
            set { _returnstaffbranch = value; }
            get { return _returnstaffbranch; }
        }
        /// <summary>
        /// 退货单部门
        /// </summary>
        public string ReturnStaffDepart
        {
            set { _returnstaffdepart = value; }
            get { return _returnstaffdepart; }
        }
        /// <summary>
        /// 退货单人唯一值
        /// </summary>
        public string ReturnStaffNo
        {
            set { _returnstaffno = value; }
            get { return _returnstaffno; }
        }
        /// <summary>
        /// 退货单审核人
        /// </summary>
        public string ReturnCheckStaffNo
        {
            set { _returncheckstaffno = value; }
            get { return _returncheckstaffno; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string ReturnRemarks
        {
            set { _returnremarks = value; }
            get { return _returnremarks; }
        }
        /// <summary>
        /// 是否已审核 （0未审，1已审）
        /// </summary>
        public bool ReturnCheckYN
        {
            set { _returncheckyn = value; }
            get { return _returncheckyn; }
        }
        #endregion Model

    }
}

