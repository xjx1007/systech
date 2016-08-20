using System;
using System.Collections;
namespace KNet.Model
{
    /// <summary>
    /// 实体类KNet_Sales_ReturnList 
    /// </summary>
    [Serializable]
    public class KNet_Sales_ReturnList
    {
        public KNet_Sales_ReturnList()
        { }
        #region Model
        private string _id;
        private string _returnno;
        private string _returntopic;
        private DateTime? _returndatetime;
        private string _contractno;
        private string _customervalue;
        private decimal? _returntranshare;
        private string _outwareno;
        private string _returnporpay;
        private string _returnclass;
        private string _returntoaddress;
        private string _returndelivemethods;
        private string _returnstaffbranch;
        private string _returnstaffdepart;
        private string _returnstaffno;
        private string _returncheckstaffno;
        private string _returnremarks;
        private int? _returnstate;
        private bool _returncheckyn;
        private string _ContentPerson;
        private string _Telphone;
        private string _ReturnType;
        private ArrayList _Arr_Details;
        /// <summary>
        /// 自动ID值
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 销售退货单（唯一值）
        /// </summary>
        public string ReturnNo
        {
            set { _returnno = value; }
            get { return _returnno; }
        }
        /// <summary>
        /// 销售退货 主题
        /// </summary>
        public string ReturnTopic
        {
            set { _returntopic = value; }
            get { return _returntopic; }
        }
        /// <summary>
        /// 销售退货 时间
        /// </summary>
        public DateTime? ReturnDateTime
        {
            set { _returndatetime = value; }
            get { return _returndatetime; }
        }
        /// <summary>
        /// 合同编号（关联合同）
        /// </summary>
        public string ContractNo
        {
            set { _contractno = value; }
            get { return _contractno; }
        }
        /// <summary>
        /// 关联客户唯一号
        /// </summary>
        public string CustomerValue
        {
            set { _customervalue = value; }
            get { return _customervalue; }
        }
        /// <summary>
        /// 退回运输分担
        /// </summary>
        public decimal? ReturnTranShare
        {
            set { _returntranshare = value; }
            get { return _returntranshare; }
        }
        /// <summary>
        /// 关联  发货单(唯一值)
        /// </summary>
        public string OutWareNo
        {
            set { _outwareno = value; }
            get { return _outwareno; }
        }
        /// <summary>
        /// 退款方式
        /// </summary>
        public string ReturnPorPay
        {
            set { _returnporpay = value; }
            get { return _returnporpay; }
        }
        /// <summary>
        /// 退货分类
        /// </summary>
        public string ReturnClass
        {
            set { _returnclass = value; }
            get { return _returnclass; }
        }
        /// <summary>
        /// 退货地址
        /// </summary>
        public string ReturnToAddress
        {
            set { _returntoaddress = value; }
            get { return _returntoaddress; }
        }
        /// <summary>
        /// 退货方式
        /// </summary>
        public string ReturnDeliveMethods
        {
            set { _returndelivemethods = value; }
            get { return _returndelivemethods; }
        }
        /// <summary>
        /// 销售退货 分公司
        /// </summary>
        public string ReturnStaffBranch
        {
            set { _returnstaffbranch = value; }
            get { return _returnstaffbranch; }
        }
        /// <summary>
        /// 销售退货 部门
        /// </summary>
        public string ReturnStaffDepart
        {
            set { _returnstaffdepart = value; }
            get { return _returnstaffdepart; }
        }
        /// <summary>
        /// 销售退货 经手人
        /// </summary>
        public string ReturnStaffNo
        {
            set { _returnstaffno = value; }
            get { return _returnstaffno; }
        }
        /// <summary>
        /// 销售退货 审核人
        /// </summary>
        public string ReturnCheckStaffNo
        {
            set { _returncheckstaffno = value; }
            get { return _returncheckstaffno; }
        }
        /// <summary>
        /// 销售退货 备注
        /// </summary>
        public string ReturnRemarks
        {
            set { _returnremarks = value; }
            get { return _returnremarks; }
        }
        /// <summary>
        /// 退货状态（0新退货申请，1退货洽谈中，2已终止退货，3已退回归库）
        /// </summary>
        public int? ReturnState
        {
            set { _returnstate = value; }
            get { return _returnstate; }
        }
        /// <summary>
        /// 销售退货 是否审核
        /// </summary>
        public bool ReturnCheckYN
        {
            set { _returncheckyn = value; }
            get { return _returncheckyn; }
        }
        public string ContentPerson
        {
            set { _ContentPerson = value; }
            get { return _ContentPerson; }
        }
        public string Telphone
        {
            set { _Telphone = value; }
            get { return _Telphone; }
        }

        public string ReturnType
        {
            set { _ReturnType = value; }
            get { return _ReturnType; }
        }
        public ArrayList Arr_Details
        {
            set { _Arr_Details = value; }
            get { return _Arr_Details; }
        }
        
        #endregion Model

    }
}

