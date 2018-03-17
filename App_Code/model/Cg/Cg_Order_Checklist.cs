using System;
using System.Collections;
namespace KNet.Model
{
    /// <summary>
    /// Cg_Order_Checklist:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Cg_Order_Checklist
    {
        public Cg_Order_Checklist()
        { }
        #region Model
        private string _coc_code;
        private string _coc_houseno;
        private DateTime? _coc_stime;
        private DateTime? _coc_begindate;
        private DateTime? _coc_enddate;
        private string _coc_details;
        private DateTime? _coc_ctime;
        private string _coc_creator;
        private DateTime? _coc_mtime;
        private string _coc_mender;
        private ArrayList _arr_Details;
        private string _COC_Type;
        private string _COC_SuppNo;
        private int _COC_CheckYN;
        private string _COC_CheckPerson;
        private DateTime? _COC_CheckTime;
        private string _COC_RKCode;
        private int _COC_IsPayMent;
        private int _COC_IsFp;
        private int _COC_IsSend;
        
        /// <summary>
        /// 
        /// </summary>
        public string COC_Code
        {
            set { _coc_code = value; }
            get { return _coc_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string COC_HouseNo
        {
            set { _coc_houseno = value; }
            get { return _coc_houseno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? COC_Stime
        {
            set { _coc_stime = value; }
            get { return _coc_stime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? COC_BeginDate
        {
            set { _coc_begindate = value; }
            get { return _coc_begindate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? COC_EndDate
        {
            set { _coc_enddate = value; }
            get { return _coc_enddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string COC_Details
        {
            set { _coc_details = value; }
            get { return _coc_details; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? COC_CTime
        {
            set { _coc_ctime = value; }
            get { return _coc_ctime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string COC_Creator
        {
            set { _coc_creator = value; }
            get { return _coc_creator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? COC_MTime
        {
            set { _coc_mtime = value; }
            get { return _coc_mtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string COC_Mender
        {
            set { _coc_mender = value; }
            get { return _coc_mender; }
        }

        /// <summary>
        /// 
        /// </summary>
        public ArrayList arr_Details
        {
            set { _arr_Details = value; }
            get { return _arr_Details; }
        }

        public string COC_Type
        {
            set { _COC_Type = value; }
            get { return _COC_Type; }
        }

        public string COC_SuppNo
        {
            set { _COC_SuppNo = value; }
            get { return _COC_SuppNo; }
        }
        public int COC_CheckYN
        {
            set { _COC_CheckYN = value; }
            get { return _COC_CheckYN; }
        }

        public string COC_CheckPerson
        {
            set { _COC_CheckPerson = value; }
            get { return _COC_CheckPerson; }
        }

        public DateTime? COC_CheckTime
        {
            set { _COC_CheckTime = value; }
            get { return _COC_CheckTime; }
        }

        public string COC_RKCode
        {
            set { _COC_RKCode = value; }
            get { return _COC_RKCode; }
        }

        public int COC_IsPayMent
        {
            set { _COC_IsPayMent = value; }
            get { return _COC_IsPayMent; }
        }

        public int COC_IsFp
        {
            set { _COC_IsFp = value; }
            get { return _COC_IsFp; }
        }
        public int COC_IsSend
        {
            set { _COC_IsSend = value; }
            get { return _COC_IsSend; }
        }
        #endregion Model

    }
}

