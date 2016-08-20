using System;
using System.Collections;
namespace KNet.Model
{
    /// <summary>
    /// 实体类KNet_Resource_OutManage
    /// </summary>
    public class KNet_Resource_OutManage
    {
        public KNet_Resource_OutManage()
        { }
        #region Model
        private string _id;
        private string _staffno;
        private string _staffbranch;
        private string _staffdepart;
        private string _startdatetime;
        private string _enddatetime;
        private string _outjustificate;
        private DateTime? _adddatetime;
        private int? _thisstate;
        private int? _thiskings;
        private string _approvalstaffno;
        private DateTime? _approvaldatetime;
        private string _thisextenda;
        private string _thisextendb;
        private string _KRO_Traffic;
        private string _KRO_Type;
        private int _KRO_IsCheck;
        private string _KRO_Remarks;
        private ArrayList _Arr_Customer;
        /// <summary>
        /// 自动ID值
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 申请人唯一编号
        /// </summary>
        public string StaffNo
        {
            set { _staffno = value; }
            get { return _staffno; }
        }
        /// <summary>
        /// 申请人公司
        /// </summary>
        public string StaffBranch
        {
            set { _staffbranch = value; }
            get { return _staffbranch; }
        }
        /// <summary>
        /// 申请人部门
        /// </summary>
        public string StaffDepart
        {
            set { _staffdepart = value; }
            get { return _staffdepart; }
        }
        /// <summary>
        /// 开始时间
        /// </summary>
        public string StartDateTime
        {
            set { _startdatetime = value; }
            get { return _startdatetime; }
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        public string EndDatetime
        {
            set { _enddatetime = value; }
            get { return _enddatetime; }
        }
        /// <summary>
        /// 原由
        /// </summary>
        public string OutJustificate
        {
            set { _outjustificate = value; }
            get { return _outjustificate; }
        }
        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime? AddDatetime
        {
            set { _adddatetime = value; }
            get { return _adddatetime; }
        }
        /// <summary>
        /// 状态（0,新申请，1已批，2否决）
        /// </summary>
        public int? ThisState
        {
            set { _thisstate = value; }
            get { return _thisstate; }
        }
        /// <summary>
        /// 类型（1请假，2外出，3出差）
        /// </summary>
        public int? ThisKings
        {
            set { _thiskings = value; }
            get { return _thiskings; }
        }
        /// <summary>
        /// 审批人
        /// </summary>
        public string ApprovalStaffNo
        {
            set { _approvalstaffno = value; }
            get { return _approvalstaffno; }
        }
        /// <summary>
        /// 交通工具
        /// </summary>
        public string KRO_Traffic
        {
            set { _KRO_Traffic = value; }
            get { return _KRO_Traffic; }
        }
        
        /// <summary>
        /// 审批时间
        /// </summary>
        public DateTime? ApprovalDatetime
        {
            set { _approvaldatetime = value; }
            get { return _approvaldatetime; }
        }
        /// <summary>
        /// 扩展A（出差目的地）
        /// </summary>
        public string thisExtendA
        {
            set { _thisextenda = value; }
            get { return _thisextenda; }
        }
        /// <summary>
        /// 扩展B
        /// </summary>
        public string thisExtendB
        {
            set { _thisextendb = value; }
            get { return _thisextendb; }
        }
        public string KRO_Type
        {
            set { _KRO_Type = value; }
            get { return _KRO_Type; }
        }

        public int KRO_IsCheck
        {
            set { _KRO_IsCheck = value; }
            get { return _KRO_IsCheck; }
        }
        public string KRO_Remarks
        {
            set { _KRO_Remarks = value; }
            get { return _KRO_Remarks; }
        }
        public ArrayList Arr_Customer
        {
            set { _Arr_Customer = value; }
            get { return _Arr_Customer; }
        }
        #endregion Model

    }
}

