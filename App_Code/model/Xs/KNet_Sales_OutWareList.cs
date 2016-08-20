using System;
using System.Collections;
namespace KNet.Model
{
    /// <summary>
    /// 实体类KNet_Sales_OutWareList
    /// </summary>
    [Serializable]
    public class KNet_Sales_OutWareList
    {
        public KNet_Sales_OutWareList()
        { }
        #region Model
        private string _id;
        private string _outwareno;
        private string _outwaretopic;
        private DateTime? _outwaredatetime;
        private string _contractno;
        private string _customervalue;
        private decimal? _contracttranshare;
        private string _outwareourscontact;
        private string _outwaresidecontact;
        private string _contracttoaddress;
        private string _contractdelivemethods;
        private string _outwarestaffbranch;
        private string _outwarestaffdepart;
        private string _outwarestaffno;
        private string _outwarecheckstaffno;
        private string _outwareremarks;
        private bool _outwarecheckyn;

        private string _kso_telphone;
        private DateTime? _kso_planoutwaredatetime;
        private DateTime? _kso_mdate;
        private string _kso_mreator;
        private string _KSO_ShRemark;
        private string _KSO_SuppNoRemarks;
        private string _DutyPerson;
        private string _KSO_ContentPersonName;
        private string _KSO_WareHouseNo;
        private string _kso_shiptype;
        private string _kso_maternumber;
        private string _kso_orderno;
        private string _kso_planno;
        private string _KSO_Type;
        private string _KSO_SCustomerValue;
        private ArrayList _Arr_Details;

        private string _KSO_FhDetails;
        private string _KSO_PayMent;
        private string _KSO_ContentPersonID;
        private string _KSO_KpType;
        /// <summary>
        /// 自动ID值
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 销售出货单（唯一值）
        /// </summary>
        public string OutWareNo
        {
            set { _outwareno = value; }
            get { return _outwareno; }
        }
        /// <summary>
        /// 销售出货 主题
        /// </summary>
        public string OutWareTopic
        {
            set { _outwaretopic = value; }
            get { return _outwaretopic; }
        }
        /// <summary>
        /// 销售出货 时间
        /// </summary>
        public DateTime? OutWareDateTime
        {
            set { _outwaredatetime = value; }
            get { return _outwaredatetime; }
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
        /// 运输分担
        /// </summary>
        public decimal? ContractTranShare
        {
            set { _contracttranshare = value; }
            get { return _contracttranshare; }
        }
        /// <summary>
        /// 发货联系人
        /// </summary>
        public string OutWareOursContact
        {
            set { _outwareourscontact = value; }
            get { return _outwareourscontact; }
        }
        /// <summary>
        /// 收货联系人
        /// </summary>
        public string OutWareSideContact
        {
            set { _outwaresidecontact = value; }
            get { return _outwaresidecontact; }
        }
        /// <summary>
        /// 交货地址
        /// </summary>
        public string ContractToAddress
        {
            set { _contracttoaddress = value; }
            get { return _contracttoaddress; }
        }
        /// <summary>
        /// 交货方式
        /// </summary>
        public string ContractDeliveMethods
        {
            set { _contractdelivemethods = value; }
            get { return _contractdelivemethods; }
        }
        /// <summary>
        /// 销售出货 分公司
        /// </summary>
        public string OutWareStaffBranch
        {
            set { _outwarestaffbranch = value; }
            get { return _outwarestaffbranch; }
        }
        /// <summary>
        /// 销售出货 部门
        /// </summary>
        public string OutWareStaffDepart
        {
            set { _outwarestaffdepart = value; }
            get { return _outwarestaffdepart; }
        }
        /// <summary>
        /// 销售出货 经手人
        /// </summary>
        public string OutWareStaffNo
        {
            set { _outwarestaffno = value; }
            get { return _outwarestaffno; }
        }
        /// <summary>
        /// 销售出货 审核人
        /// </summary>
        public string OutWareCheckStaffNo
        {
            set { _outwarecheckstaffno = value; }
            get { return _outwarecheckstaffno; }
        }
        /// <summary>
        /// 销售出货 备注
        /// </summary>
        public string OutWareRemarks
        {
            set { _outwareremarks = value; }
            get { return _outwareremarks; }
        }
        /// <summary>
        /// 销售出货 是否审核
        /// </summary>
        public bool OutWareCheckYN
        {
            set { _outwarecheckyn = value; }
            get { return _outwarecheckyn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KSO_TelPhone
        {
            set { _kso_telphone = value; }
            get { return _kso_telphone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? KSO_PlanOutWareDateTime
        {
            set { _kso_planoutwaredatetime = value; }
            get { return _kso_planoutwaredatetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? KSO_MDate
        {
            set { _kso_mdate = value; }
            get { return _kso_mdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KSO_Mreator
        {
            set { _kso_mreator = value; }
            get { return _kso_mreator; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string KSO_ShRemark
        {
            set { _KSO_ShRemark = value; }
            get { return _KSO_ShRemark; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string KSO_SuppNoRemarks
        {
            set { _KSO_SuppNoRemarks = value; }
            get { return _KSO_SuppNoRemarks; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string DutyPerson
        {
            set { _DutyPerson = value; }
            get { return _DutyPerson; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string KSO_ContentPersonName
        {
            set { _KSO_ContentPersonName = value; }
            get { return _KSO_ContentPersonName; }
        }

        public string KSO_WareHouseNo
        {
            set { _KSO_WareHouseNo = value; }
            get { return _KSO_WareHouseNo; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string KSO_ShipType
        {
            set { _kso_shiptype = value; }
            get { return _kso_shiptype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KSO_MaterNumber
        {
            set { _kso_maternumber = value; }
            get { return _kso_maternumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KSO_OrderNo
        {
            set { _kso_orderno = value; }
            get { return _kso_orderno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KSO_PlanNo
        {
            set { _kso_planno = value; }
            get { return _kso_planno; }
        }
        
        public ArrayList Arr_Details
        {
            set { _Arr_Details = value; }
            get { return _Arr_Details; }
        }

        public string KSO_Type
        {
            set { _KSO_Type = value; }
            get { return _KSO_Type; }
        }
        public string KSO_SCustomerValue
        {
            set { _KSO_SCustomerValue = value; }
            get { return _KSO_SCustomerValue; }
        }

        public string KSO_FhDetails
        {
            set { _KSO_FhDetails = value; }
            get { return _KSO_FhDetails; }
        }

        public string KSO_PayMent
        {
            set { _KSO_PayMent = value; }
            get { return _KSO_PayMent; }
        }
        public string KSO_ContentPersonID
        {
            set { _KSO_ContentPersonID = value; }
            get { return _KSO_ContentPersonID; }
        }

        public string KSO_KpType
        {
            set { _KSO_KpType = value; }
            get { return _KSO_KpType; }
        }
        #endregion Model
    }
}

