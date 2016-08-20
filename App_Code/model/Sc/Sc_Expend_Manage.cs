using System;
using System.Collections;
namespace KNet.Model
{
    /// <summary>
    /// Sc_Expend_Manage:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Sc_Expend_Manage
    {
        public Sc_Expend_Manage()
        { }
        #region Model
        private string _sem_id;
        private DateTime? _sem_stime;
        private string _sem_suppno;
        private string _sem_customername;
        private string _sem_dutyperson;
        private string _sem_productsedition;
        private DateTime? _sem_rktime;
        private DateTime? _sem_wwtime;
        private string _sem_rkperson;
        private string _sem_wwperson;
        private string _sem_remarks;
        private int? _sem_del = 0;
        private string _sem_creator;
        private DateTime? _sem_ctime;
        private string _sem_mendor;
        private DateTime? _sem_mtime;
        private ArrayList _arr_Details;
        private ArrayList _arr_MaterDetails;
        private int? _SEM_Type = 0;
        private string _SEM_DirectOutNO;
        private string _SEM_RKCode;
        private string _SEM_WwRKCode;
        private string _SEM_XhRKCode;
        private string _SEM_RCRKCode;
        private int _SEM_CheckYN = 0;
        private string _SEM_CheckStaffNo;
        private DateTime _SEM_CheckTime;
        private string _SEM_OrderNo;
        private int _SEM_RCPrintNums = 0;
        private int _SEM_MaterPrintNums = 0;
        private int _SEM_MaterPrintNums1 = 0;
        private int _SEM_MaterPrintNums2 = 0;
        
        /// <summary>
        /// 
        /// </summary>
        public string SEM_ID
        {
            set { _sem_id = value; }
            get { return _sem_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? SEM_Stime
        {
            set { _sem_stime = value; }
            get { return _sem_stime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SEM_SuppNo
        {
            set { _sem_suppno = value; }
            get { return _sem_suppno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SEM_CustomerName
        {
            set { _sem_customername = value; }
            get { return _sem_customername; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SEM_DutyPerson
        {
            set { _sem_dutyperson = value; }
            get { return _sem_dutyperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SEM_ProductsEdition
        {
            set { _sem_productsedition = value; }
            get { return _sem_productsedition; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? SEM_RkTime
        {
            set { _sem_rktime = value; }
            get { return _sem_rktime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? SEM_WwTime
        {
            set { _sem_wwtime = value; }
            get { return _sem_wwtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SEM_RkPerson
        {
            set { _sem_rkperson = value; }
            get { return _sem_rkperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SEM_WwPerson
        {
            set { _sem_wwperson = value; }
            get { return _sem_wwperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SEM_Remarks
        {
            set { _sem_remarks = value; }
            get { return _sem_remarks; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SEM_Del
        {
            set { _sem_del = value; }
            get { return _sem_del; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SEM_Creator
        {
            set { _sem_creator = value; }
            get { return _sem_creator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? SEM_CTime
        {
            set { _sem_ctime = value; }
            get { return _sem_ctime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SEM_Mendor
        {
            set { _sem_mendor = value; }
            get { return _sem_mendor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? SEM_MTime
        {
            set { _sem_mtime = value; }
            get { return _sem_mtime; }
        }

        public ArrayList arr_Details
        {
            set { _arr_Details = value; }
            get { return _arr_Details; }
        }
        public ArrayList arr_MaterDetails
        {
            set { _arr_MaterDetails = value; }
            get { return _arr_MaterDetails; }
        }
        public int? SEM_Type
        {
            set { _SEM_Type = value; }
            get { return _SEM_Type; }
        }
        public string SEM_DirectOutNO
        {
            set { _SEM_DirectOutNO = value; }
            get { return _SEM_DirectOutNO; }
        }
        public string SEM_RKCode
        {
            set { _SEM_RKCode = value; }
            get { return _SEM_RKCode; }
        }

        public string SEM_RCRKCode
        {
            set { _SEM_RCRKCode = value; }
            get { return _SEM_RCRKCode; }
        }

        public int SEM_CheckYN
        {
            set { _SEM_CheckYN = value; }
            get { return _SEM_CheckYN; }
        }
        public string SEM_CheckStaffNo
        {
            set { _SEM_CheckStaffNo = value; }
            get { return _SEM_CheckStaffNo; }
        }
        public DateTime SEM_CheckTime
        {
            set { _SEM_CheckTime = value; }
            get { return _SEM_CheckTime; }
        }

        public string SEM_OrderNo
        {
            set { _SEM_OrderNo = value; }
            get { return _SEM_OrderNo; }
        }

        public int SEM_RCPrintNums
        {
            set { _SEM_RCPrintNums = value; }
            get { return _SEM_RCPrintNums; }
        }
        public int SEM_MaterPrintNums
        {
            set { _SEM_MaterPrintNums = value; }
            get { return _SEM_MaterPrintNums; }
        }
        public int SEM_MaterPrintNums1
        {
            set { _SEM_MaterPrintNums1 = value; }
            get { return _SEM_MaterPrintNums1; }
        }
        public int SEM_MaterPrintNums2
        {
            set { _SEM_MaterPrintNums2 = value; }
            get { return _SEM_MaterPrintNums2; }
        }
        #endregion Model

    }
}

