using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// KD 的摘要说明
/// </summary>
public class KD
{
	public KD()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
        #region Model
        private string _id;
        private string _directinno;
        private string _directintopic;
        private string _directinsource;
        private DateTime? _directindatetime;
        private string _suppno;
        private string _houseno;
        private string _directinstaffbranch;
        private string _directinstaffdepart;
        private string _directinstaffno;
        private string _directincheckstaffno;
        private string _directinremarks;
        private int _directincheckyn;
        private string _KWD_Type;
        private string _KWD_ReturnNo;
        private int _KWD_BPrintNums = 0;
        private string _KWD_KDNameCode;
        private string _KWD_KDName;
        private string _KWD_KDCode;
        private string _KWD_KDState;
        private string _KWD_PersonName;
        private string _KWD_Telphone;
        private string _KWD_Phone;
        private string _KWD_Address;
        /// <summary>
        /// 自动ID值
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 直接入库单（唯一性）
        /// </summary>
        public string DirectInNo
        {
            set { _directinno = value; }
            get { return _directinno; }
        }
        /// <summary>
        /// 直接入库主题
        /// </summary>
        public string DirectInTopic
        {
            set { _directintopic = value; }
            get { return _directintopic; }
        }
        /// <summary>
        /// 直接入库物品来源
        /// </summary>
        public string DirectInSource
        {
            set { _directinsource = value; }
            get { return _directinsource; }
        }
        /// <summary>
        /// 直接入库单日期
        /// </summary>
        public DateTime? DirectInDateTime
        {
            set { _directindatetime = value; }
            get { return _directindatetime; }
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
        /// 直接入库公司
        /// </summary>
        public string DirectInStaffBranch
        {
            set { _directinstaffbranch = value; }
            get { return _directinstaffbranch; }
        }
        /// <summary>
        /// 直接入库部门
        /// </summary>
        public string DirectInStaffDepart
        {
            set { _directinstaffdepart = value; }
            get { return _directinstaffdepart; }
        }
        /// <summary>
        /// 经办（直接入库）人
        /// </summary>
        public string DirectInStaffNo
        {
            set { _directinstaffno = value; }
            get { return _directinstaffno; }
        }
        /// <summary>
        /// 审核人
        /// </summary>
        public string DirectInCheckStaffNo
        {
            set { _directincheckstaffno = value; }
            get { return _directincheckstaffno; }
        }
        /// <summary>
        /// 备注说明
        /// </summary>
        public string DirectInRemarks
        {
            set { _directinremarks = value; }
            get { return _directinremarks; }
        }
        /// <summary>
        /// 是否通过审核（0否，1是）
        /// </summary>
        public int DirectInCheckYN
        {
            set { _directincheckyn = value; }
            get { return _directincheckyn; }
        }

        /// <summary>
        /// 备注说明
        /// </summary>
        public string KWD_Type
        {
            set { _KWD_Type = value; }
            get { return _KWD_Type; }
        }
        /// <summary>
        /// 备注说明
        /// </summary>
        public string KWD_ReturnNo
        {
            set { _KWD_ReturnNo = value; }
            get { return _KWD_ReturnNo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int KWD_BPrintNums
        {
            set { _KWD_BPrintNums = value; }
            get { return _KWD_BPrintNums; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KWD_KDNameCode
        {
            set { _KWD_KDNameCode = value; }
            get { return _KWD_KDNameCode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KWD_KDName
        {
            set { _KWD_KDName = value; }
            get { return _KWD_KDName; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KWD_KDCode
        {
            set { _KWD_KDCode = value; }
            get { return _KWD_KDCode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KWD_KDState
        {
            set { _KWD_KDState = value; }
            get { return _KWD_KDState; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KWD_PersonName
        {
            set { _KWD_PersonName = value; }
            get { return _KWD_PersonName; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KWD_Telphone
        {
            set { _KWD_Telphone = value; }
            get { return _KWD_Telphone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KWD_Phone
        {
            set { _KWD_Phone = value; }
            get { return _KWD_Phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KWD_Address
        {
            set { _KWD_Address = value; }
            get { return _KWD_Address; }
        }
        #endregion Model
}