using System;
using System.Collections;
namespace KNet.Model
{
    /// <summary>
    /// Knet_Procure_OrdersList:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Knet_Procure_OrdersList
    {
        public Knet_Procure_OrdersList()
        { }
        #region Model
        private string _id = "newid";
        private string _ordertopic;
        private string _orderno;
        private DateTime? _orderdatetime = DateTime.Now;
        private DateTime? _orderpretodate;
        private string _suppno;
        private string _orderpaymentnotes;
        private string _orderstaffbranch;
        private string _orderstaffdepart;
        private string _orderstaffno;
        private string _ordercheckstaffno;
        private decimal? _ordertransshare = 0M;
        private string _ordertype;
        private string _orderremarks;
        private int? _orderstate = 0;
        private bool? _ordercheckyn = false;
        private decimal? _advancesprice = 0M;
        private int? _paykings = 0;
        private DateTime _systemdatetimes = DateTime.Now;
        private string _contractno;
        private string _contractaddress;
        private decimal? _invorate;
        private string _receivesuppno;
        private decimal _kpo_countweight;
        private string _kpo_sampling;
        private string _Chk_IsChip;
        private string _Chk_Battery;
        private string _ParentOrderNo;
        private ArrayList _Arr_ProductsList;
        private string _KPO_RkState;
        private string _KPO_PayState;
        private int _KPO_IsSend;
        private string _rkState;
        private string _ContractNos;
        private int _KPO_Del = 0;
        private DateTime _KPO_CTime;
        private string _KPO_Creator;
        private DateTime _KPO_MTime;
        private string _KPO_Mender;
        private int _KPO_Print;
        private DateTime _ArrivalDate;
        private string _KPO_ScDetails;
        private ArrayList _Arr_Mail;
        private int _KPO_IsStopProduce;
        private int _KPO_PriceState;
        private int _KPO_IsChange;
        private string _KPO_PreHouseNo;
        private decimal _KPO_CountWeight;
        private string _KPO_Sampling;

        /// <summary>
        /// 自动ID值
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        public string KPO_Sampling
        {
            set { _kpo_sampling = value; }
            get { return _kpo_sampling; }
        }
        /// <summary>
        /// 订单总重量
        /// </summary>
        public decimal KPO_CountWeight
        {
            set { _kpo_countweight = value; }
            get { return _kpo_countweight; }
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
        /// 采购单号（维一性）
        /// </summary>
        public string OrderNo
        {
            set { _orderno = value; }
            get { return _orderno; }
        }
        /// <summary>
        /// 采购日期
        /// </summary>
        public DateTime? OrderDateTime
        {
            set { _orderdatetime = value; }
            get { return _orderdatetime; }
        }
        /// <summary>
        /// 预订到货日期
        /// </summary>
        public DateTime? OrderPreToDate
        {
            set { _orderpretodate = value; }
            get { return _orderpretodate; }
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
        public string OrderPaymentNotes
        {
            set { _orderpaymentnotes = value; }
            get { return _orderpaymentnotes; }
        }
        /// <summary>
        /// 采购公司
        /// </summary>
        public string OrderStaffBranch
        {
            set { _orderstaffbranch = value; }
            get { return _orderstaffbranch; }
        }
        /// <summary>
        /// 采购部门
        /// </summary>
        public string OrderStaffDepart
        {
            set { _orderstaffdepart = value; }
            get { return _orderstaffdepart; }
        }
        /// <summary>
        /// 采购人唯一值
        /// </summary>
        public string OrderStaffNo
        {
            set { _orderstaffno = value; }
            get { return _orderstaffno; }
        }
        /// <summary>
        /// 采购单审核人
        /// </summary>
        public string OrderCheckStaffNo
        {
            set { _ordercheckstaffno = value; }
            get { return _ordercheckstaffno; }
        }
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
        /// 备注
        /// </summary>
        public string OrderRemarks
        {
            set { _orderremarks = value; }
            get { return _orderremarks; }
        }
        /// <summary>
        /// 采购单执行状态（0未执行，1执行中，2逾期作废，3收货中，4退货中，5完成）
        /// </summary>
        public int? OrderState
        {
            set { _orderstate = value; }
            get { return _orderstate; }
        }
        /// <summary>
        /// 是否已审核 （0未审，1已审）
        /// </summary>
        public bool? OrderCheckYN
        {
            set { _ordercheckyn = value; }
            get { return _ordercheckyn; }
        }
        /// <summary>
        /// 采购单加预付款字段
        /// </summary>
        public decimal? AdvancesPrice
        {
            set { _advancesprice = value; }
            get { return _advancesprice; }
        }
        /// <summary>
        /// 1预付款，2后付款
        /// </summary>
        public int? paykings
        {
            set { _paykings = value; }
            get { return _paykings; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime SystemDatetimes
        {
            set { _systemdatetimes = value; }
            get { return _systemdatetimes; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ContractNo
        {
            set { _contractno = value; }
            get { return _contractno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ContractAddress
        {
            set { _contractaddress = value; }
            get { return _contractaddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? InvoRate
        {
            set { _invorate = value; }
            get { return _invorate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ReceiveSuppNo
        {
            set { _receivesuppno = value; }
            get { return _receivesuppno; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Chk_IsChip
        {
            set { _Chk_IsChip = value; }
            get { return _Chk_IsChip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Chk_Battery
        {
            set { _Chk_Battery = value; }
            get { return _Chk_Battery; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public string ParentOrderNo
        {
            set { _ParentOrderNo = value; }
            get { return _ParentOrderNo; }
        }

        public ArrayList Arr_ProductsList
        {
            set { _Arr_ProductsList = value; }
            get { return _Arr_ProductsList; }
        }

        public ArrayList Arr_Mail
        {
            set { _Arr_Mail = value; }
            get { return _Arr_Mail; }
        }
        public string KPO_RkState
        {
            set { _KPO_RkState = value; }
            get { return _KPO_RkState; }
        }
        public string KPO_PayState
        {
            set { _KPO_PayState = value; }
            get { return _KPO_PayState; }
        }
        public int KPO_IsSend
        {
            set { _KPO_IsSend = value; }
            get { return _KPO_IsSend; }
        }
        public string rkState
        {
            set { _rkState = value; }
            get { return _rkState; }
        }
        public string ContractNos
        {
            set { _ContractNos = value; }
            get { return _ContractNos; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int KPO_Del
        {
            set { _KPO_Del = value; }
            get { return _KPO_Del; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime KPO_CTime
        {
            set { _KPO_CTime = value; }
            get { return _KPO_CTime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KPO_Creator
        {
            set { _KPO_Creator = value; }
            get { return _KPO_Creator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime KPO_MTime
        {
            set { _KPO_MTime = value; }
            get { return _KPO_MTime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KPO_Mender
        {
            set { _KPO_Mender = value; }
            get { return _KPO_Mender; }
        }


        public DateTime ArrivalDate
        {
            set { _ArrivalDate = value; }
            get { return _ArrivalDate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int KPO_Print
        {
            set { _KPO_Print = value; }
            get { return _KPO_Print; }
        }


        public int KPO_IsStopProduce
        {
            set { _KPO_IsStopProduce = value; }
            get { return _KPO_IsStopProduce; }
        }
        
        public string KPO_ScDetails
        {
            set { _KPO_ScDetails = value; }
            get { return _KPO_ScDetails; }
        }

        public string KPO_PreHouseNo
        {
            set { _KPO_PreHouseNo = value; }
            get { return _KPO_PreHouseNo; }
        }

        
        public int KPO_PriceState
        {
            set { _KPO_PriceState = value; }
            get { return _KPO_PriceState; }
        }

        public int KPO_IsChange
        {
            set { _KPO_IsChange = value; }
            get { return _KPO_IsChange; }
        }
        
        #endregion Model

    }
}

