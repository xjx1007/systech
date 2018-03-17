using System;
using System.Collections;
namespace KNet.Model
{
    /// <summary>
    /// KNet_Sales_ContractList:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class KNet_Sales_ContractList
    {
        public KNet_Sales_ContractList()
        { }
        #region Model
        private string _id = "newid";
        private string _contractno;
        private string _contracttopic;
        private string _customervalue;
        private DateTime? _contractdatetime = DateTime.Now;
        private DateTime? _contractstardatetime;
        private DateTime? _contractendtdatetime;
        private string _contractoursdelegate;
        private string _contractsidedelegate;
        private string _contractclass;
        private decimal? _contracttranshare = 0M;
        private string _contractdelivemethods;
        private string _contracttoaddress;
        private DateTime? _contracttodelidate;
        private string _contracttopayment;
        private string _houseno;
        private string _baopriceno;
        private string _contractstaffbranch;
        private string _contractstaffdepart;
        private string _contractstaffno;
        private string _contractcheckstaffno;
        private string _contractremarks;
        private int? _contractstate = 0;
        private bool? _contractcheckyn = false;
        private DateTime? _systemdatetimes = DateTime.Now;
        private string _routinetransport;
        private string _worrytransport;
        private string _technicalrequire;
        private string _productpackaging;
        private string _qualityrequire;
        private string _warrantyperiod;
        private string _deliveryrequire;
        private string _payment;
        private string _contentperson;
        private string _telephone;
        private string _productsbigpicture;
        private string _productssmallpicture;
        private string _contractship;
        private int? _productspic;
        private string _dutyPerson;

        private string _KSC_OrderNO;
        private string _KSC_OrderName;
        private string _KSC_OrderURL;

        private DateTime? _KFC_ReDate;
        private ArrayList _arr_Details;
        private string _ksc_maternumber;
        private string _ksc_planno;
        private string _ksc_shiptype;
        private string _ksc_customerorderno;
        private int _isOrder;
        private string _KSC_FaterId;

        private string _ksc_creator;
        private DateTime? _ksc_ctime;
        private string _ksc_mender;
        private DateTime? _ksc_mtime;
        private ArrayList _arr_FhDetails;
        private ArrayList _arr_Ship;
        
        
        /// <summary>
        /// 自动ID值
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 合同编号（唯一值）
        /// </summary>
        public string ContractNo
        {
            set { _contractno = value; }
            get { return _contractno; }
        }
        /// <summary>
        /// 合同主题
        /// </summary>
        public string ContractTopic
        {
            set { _contracttopic = value; }
            get { return _contracttopic; }
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
        /// 答订日期
        /// </summary>
        public DateTime? ContractDateTime
        {
            set { _contractdatetime = value; }
            get { return _contractdatetime; }
        }
        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime? ContractStarDateTime
        {
            set { _contractstardatetime = value; }
            get { return _contractstardatetime; }
        }
        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime? ContractEndtDateTime
        {
            set { _contractendtdatetime = value; }
            get { return _contractendtdatetime; }
        }
        /// <summary>
        /// 我方代表
        /// </summary>
        public string ContractOursDelegate
        {
            set { _contractoursdelegate = value; }
            get { return _contractoursdelegate; }
        }
        /// <summary>
        /// 对方代表
        /// </summary>
        public string ContractSideDelegate
        {
            set { _contractsidedelegate = value; }
            get { return _contractsidedelegate; }
        }
        /// <summary>
        /// 合同分类
        /// </summary>
        public string ContractClass
        {
            set { _contractclass = value; }
            get { return _contractclass; }
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
        /// 交货方式
        /// </summary>
        public string ContractDeliveMethods
        {
            set { _contractdelivemethods = value; }
            get { return _contractdelivemethods; }
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
        /// 出货日期
        /// </summary>
        public DateTime? ContractToDeliDate
        {
            set { _contracttodelidate = value; }
            get { return _contracttodelidate; }
        }
        /// <summary>
        /// 付款方式
        /// </summary>
        public string ContractToPayment
        {
            set { _contracttopayment = value; }
            get { return _contracttopayment; }
        }
        /// <summary>
        /// 出货仓库唯一值
        /// </summary>
        public string HouseNo
        {
            set { _houseno = value; }
            get { return _houseno; }
        }
        /// <summary>
        /// 关联报价唯一值
        /// </summary>
        public string BaoPriceNo
        {
            set { _baopriceno = value; }
            get { return _baopriceno; }
        }
        /// <summary>
        /// 签合同分公司
        /// </summary>
        public string ContractStaffBranch
        {
            set { _contractstaffbranch = value; }
            get { return _contractstaffbranch; }
        }
        /// <summary>
        /// 签合同部门
        /// </summary>
        public string ContractStaffDepart
        {
            set { _contractstaffdepart = value; }
            get { return _contractstaffdepart; }
        }
        /// <summary>
        /// 报价（签合同）人
        /// </summary>
        public string ContractStaffNo
        {
            set { _contractstaffno = value; }
            get { return _contractstaffno; }
        }
        /// <summary>
        /// 签合同（审核）人
        /// </summary>
        public string ContractCheckStaffNo
        {
            set { _contractcheckstaffno = value; }
            get { return _contractcheckstaffno; }
        }
        /// <summary>
        /// 签合同备注
        /// </summary>
        public string ContractRemarks
        {
            set { _contractremarks = value; }
            get { return _contractremarks; }
        }
        /// <summary>
        /// 合同状态（0未执行，1执行中，2出货中，3作废，4完成）
        /// </summary>
        public int? ContractState
        {
            set { _contractstate = value; }
            get { return _contractstate; }
        }
        /// <summary>
        /// 合同是否已通过审核
        /// </summary>
        public bool? ContractCheckYN
        {
            set { _contractcheckyn = value; }
            get { return _contractcheckyn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? SystemDatetimes
        {
            set { _systemdatetimes = value; }
            get { return _systemdatetimes; }
        }
        /// <summary>
        /// 常规运输方式
        /// </summary>
        public string RoutineTransport
        {
            set { _routinetransport = value; }
            get { return _routinetransport; }
        }
        /// <summary>
        /// 应急运输方式
        /// </summary>
        public string WorryTransport
        {
            set { _worrytransport = value; }
            get { return _worrytransport; }
        }
        /// <summary>
        /// 技术要求
        /// </summary>
        public string TechnicalRequire
        {
            set { _technicalrequire = value; }
            get { return _technicalrequire; }
        }
        /// <summary>
        /// 产品包装
        /// </summary>
        public string ProductPackaging
        {
            set { _productpackaging = value; }
            get { return _productpackaging; }
        }
        /// <summary>
        /// 质量要求
        /// </summary>
        public string QualityRequire
        {
            set { _qualityrequire = value; }
            get { return _qualityrequire; }
        }
        /// <summary>
        /// 质保期
        /// </summary>
        public string WarrantyPeriod
        {
            set { _warrantyperiod = value; }
            get { return _warrantyperiod; }
        }
        /// <summary>
        /// 备货要求
        /// </summary>
        public string DeliveryRequire
        {
            set { _deliveryrequire = value; }
            get { return _deliveryrequire; }
        }
        /// <summary>
        /// 付款方式
        /// </summary>
        public string Payment
        {
            set { _payment = value; }
            get { return _payment; }
        }
        /// <summary>
        /// 联系人
        /// </summary>
        public string ContentPerson
        {
            set { _contentperson = value; }
            get { return _contentperson; }
        }
        /// <summary>
        /// 电话号码
        /// </summary>
        public string Telephone
        {
            set { _telephone = value; }
            get { return _telephone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProductsBigPicture
        {
            set { _productsbigpicture = value; }
            get { return _productsbigpicture; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProductsSmallPicture
        {
            set { _productssmallpicture = value; }
            get { return _productssmallpicture; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ContractShip
        {
            set { _contractship = value; }
            get { return _contractship; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ProductsPic
        {
            set { _productspic = value; }
            get { return _productspic; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public string DutyPerson
        {
            set { _dutyPerson = value; }
            get { return _dutyPerson; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string KSC_OrderNO
        {
            set { _KSC_OrderNO = value; }
            get { return _KSC_OrderNO; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KSC_OrderName
        {
            set { _KSC_OrderName = value; }
            get { return _KSC_OrderName; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KSC_OrderURL
        {
            set { _KSC_OrderURL = value; }
            get { return _KSC_OrderURL; }
        }

        /// <summary>
        /// 答订日期
        /// </summary>
        public DateTime? KFC_ReDate
        {
            set { _KFC_ReDate = value; }
            get { return _KFC_ReDate; }
        }

        public ArrayList arr_Details
        {
            set { _arr_Details = value; }
            get { return _arr_Details; }
        }

        public ArrayList arr_FhDetails
        {
            set { _arr_FhDetails = value; }
            get { return _arr_FhDetails; }
        }

        public ArrayList arr_Ship
        {
            set { _arr_Ship = value; }
            get { return _arr_Ship; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KSC_MaterNumber
        {
            set { _ksc_maternumber = value; }
            get { return _ksc_maternumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KSC_PlanNo
        {
            set { _ksc_planno = value; }
            get { return _ksc_planno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KSC_ShipType
        {
            set { _ksc_shiptype = value; }
            get { return _ksc_shiptype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KSC_CustomerOrderNo
        {
            set { _ksc_customerorderno = value; }
            get { return _ksc_customerorderno; }
        }

        public int isOrder
        {
            set { _isOrder = value; }
            get { return _isOrder; }
        }
        public string KSC_FaterId
        {
            set { _KSC_FaterId = value; }
            get { return _KSC_FaterId; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string KSC_Creator
        {
            set { _ksc_creator = value; }
            get { return _ksc_creator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? KSC_CTime
        {
            set { _ksc_ctime = value; }
            get { return _ksc_ctime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KSC_Mender
        {
            set { _ksc_mender = value; }
            get { return _ksc_mender; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? KSC_MTime
        {
            set { _ksc_mtime = value; }
            get { return _ksc_mtime; }
        }
        private string _KSC_KpType;
        public string KSC_KpType
        {
            set { _KSC_KpType = value; }
            get { return _KSC_KpType; }
        }
        
        #endregion Model

    }
}

