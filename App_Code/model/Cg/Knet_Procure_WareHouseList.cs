using System;
using System.Collections;
namespace KNet.Model
{
    /// <summary>
    /// 实体类Knet_Procure_WareHouseList 
    /// </summary>
    [Serializable]
    public class Knet_Procure_WareHouseList
    {
        public Knet_Procure_WareHouseList()
        { }
        #region Model
        private string _id;
        private string _warehouseno;
        private string _warehousetopic;
        private string _receivno;
        private DateTime? _warehousedatetime;
        private string _suppno;
        private string _houseno;
        private string _warehousestaffbranch;
        private string _warehousestaffdepart;
        private string _warehousestaffno;
        private string _warehousecheckstaffno;
        private string _warehouseremarks;
        private int _warehousecheckyn;

        private string _OrderNo;
        private string _IsShip;
        private string _ShipDetials;
        private ArrayList _Arr_Products;
        private int? _kpw_del = 0;
        private DateTime? _kpw_ctime;
        private string _kpw_creator;
        private DateTime? _kpw_mtime;
        private string _kpw_Mender;
        private string _kpw_dutyperson;
        private string _kpw_state;
        private string _KPO_OrderDetailsID;
        private string _KPO_KDNameCode;
        private string _KPO_KDName;
        private string _KPO_KDCode;
        private string _KPO_State;
        private int _KPO_QRState;
        private int _KPW_PrintNums;
        private DateTime _KPO_CheckTime;
        private string _KPW_CheckPerson;
        

        /// <summary>
        /// 原采购单号
        /// </summary>
        public string OrderNo
        {
            set { _OrderNo = value; }
            get { return _OrderNo; }
        }
        /// <summary>
        /// 自动编号
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 入库单号
        /// </summary>
        public string WareHouseNo
        {
            set { _warehouseno = value; }
            get { return _warehouseno; }
        }
        /// <summary>
        /// 入库主题
        /// </summary>
        public string WareHouseTopic
        {
            set { _warehousetopic = value; }
            get { return _warehousetopic; }
        }
        /// <summary>
        /// 收货单号（关联）
        /// </summary>
        public string ReceivNo
        {
            set { _receivno = value; }
            get { return _receivno; }
        }
        /// <summary>
        /// 入库单日期
        /// </summary>
        public DateTime? WareHouseDateTime
        {
            set { _warehousedatetime = value; }
            get { return _warehousedatetime; }
        }
        /// <summary>
        /// 供应商
        /// </summary>
        public string SuppNo
        {
            set { _suppno = value; }
            get { return _suppno; }
        }
        /// <summary>
        /// 预入仓库
        /// </summary>
        public string HouseNo
        {
            set { _houseno = value; }
            get { return _houseno; }
        }
        /// <summary>
        /// 入库公司
        /// </summary>
        public string WareHouseStaffBranch
        {
            set { _warehousestaffbranch = value; }
            get { return _warehousestaffbranch; }
        }
        /// <summary>
        /// 入库部门
        /// </summary>
        public string WareHouseStaffDepart
        {
            set { _warehousestaffdepart = value; }
            get { return _warehousestaffdepart; }
        }
        /// <summary>
        /// 经办（入库）人
        /// </summary>
        public string WareHouseStaffNo
        {
            set { _warehousestaffno = value; }
            get { return _warehousestaffno; }
        }
        /// <summary>
        /// 审核人
        /// </summary>
        public string WareHouseCheckStaffNo
        {
            set { _warehousecheckstaffno = value; }
            get { return _warehousecheckstaffno; }
        }
        /// <summary>
        /// 备注说明
        /// </summary>
        public string WareHouseRemarks
        {
            set { _warehouseremarks = value; }
            get { return _warehouseremarks; }
        }
        /// <summary>
        /// 是否通过审核（0否，1是）
        /// </summary>
        public int WareHouseCheckYN
        {
            set { _warehousecheckyn = value; }
            get { return _warehousecheckyn; }
        }
        
        public string IsShip
        {
            set { _IsShip = value; }
            get { return _IsShip; }
        }

        public string ShipDetials
        {
            set { _ShipDetials = value; }
            get { return _ShipDetials; }
        }


        public ArrayList Arr_Products
        {
            set { _Arr_Products = value; }
            get { return _Arr_Products; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? KPW_Del
        {
            set { _kpw_del = value; }
            get { return _kpw_del; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? KPW_CTime
        {
            set { _kpw_ctime = value; }
            get { return _kpw_ctime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KPW_Creator
        {
            set { _kpw_creator = value; }
            get { return _kpw_creator; }
        }

        public string KPW_Mender
        {
            set { _kpw_Mender = value; }
            get { return _kpw_Mender; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? KPW_MTime
        {
            set { _kpw_mtime = value; }
            get { return _kpw_mtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KPW_DutyPerson
        {
            set { _kpw_dutyperson = value; }
            get { return _kpw_dutyperson; }
        }

        public DateTime KPO_CheckTime
        {
            set { _KPO_CheckTime = value; }
            get { return _KPO_CheckTime; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public string KPW_State
        {
            set { _kpw_state = value; }
            get { return _kpw_state; }
        }

        public string KPO_OrderDetailsID
        {
            set { _KPO_OrderDetailsID = value; }
            get { return _KPO_OrderDetailsID; }
        }

        public string KPO_KDNameCode
        {
            set { _KPO_KDNameCode = value; }
            get { return _KPO_KDNameCode; }
        }
        public string KPO_KDName
        {
            set { _KPO_KDName = value; }
            get { return _KPO_KDName; }
        }
        public string KPO_KDCode
        {
            set { _KPO_KDCode = value; }
            get { return _KPO_KDCode; }
        }
        public string KPO_State
        {
            set { _KPO_State = value; }
            get { return _KPO_State; }
        }

        public int KPO_QRState
        {
            set { _KPO_QRState = value; }
            get { return _KPO_QRState; }
        }
        public int KPW_PrintNums
        {
            set { _KPW_PrintNums = value; }
            get { return _KPW_PrintNums; }
        }

        public string KPW_CheckPerson
        {
            set { _KPW_CheckPerson = value; }
            get { return _KPW_CheckPerson; }
        }
        
        
        #endregion Model

    }
}

