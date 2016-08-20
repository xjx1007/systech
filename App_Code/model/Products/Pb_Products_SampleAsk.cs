using System;
namespace KNet.Model
{
    /// <summary>
    /// Pb_Products_SampleAsk:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Pb_Products_SampleAsk
    {
        public Pb_Products_SampleAsk()
        { }
        #region Model
        private string _ppa_id;
        private string _ppa_produtsbarcode;
        private DateTime? _ppa_stime;
        private int? _ppa_number;
        private string _ppa_use;
        private string _ppa_dutyperson;
        private int? _ppa_type = 0;
        private int? _ppa_isback = 0;
        private string _ppa_remarks;
        private DateTime? _ppa_ctime;
        private string _ppa_creator;
        private DateTime? _ppa_mtime;
        private string _ppa_mender;
        private string _PPA_SampleID;
        private int? _ppa_del = 0;

        public string PPA_SampleID
        {
            set { _PPA_SampleID = value; }
            get { return _PPA_SampleID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PPA_ID
        {
            set { _ppa_id = value; }
            get { return _ppa_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PPA_ProdutsBarCode
        {
            set { _ppa_produtsbarcode = value; }
            get { return _ppa_produtsbarcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PPA_Stime
        {
            set { _ppa_stime = value; }
            get { return _ppa_stime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PPA_Number
        {
            set { _ppa_number = value; }
            get { return _ppa_number; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PPA_Use
        {
            set { _ppa_use = value; }
            get { return _ppa_use; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PPA_DutyPerson
        {
            set { _ppa_dutyperson = value; }
            get { return _ppa_dutyperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PPA_Type
        {
            set { _ppa_type = value; }
            get { return _ppa_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PPA_IsBack
        {
            set { _ppa_isback = value; }
            get { return _ppa_isback; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PPA_Remarks
        {
            set { _ppa_remarks = value; }
            get { return _ppa_remarks; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PPA_CTime
        {
            set { _ppa_ctime = value; }
            get { return _ppa_ctime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PPA_Creator
        {
            set { _ppa_creator = value; }
            get { return _ppa_creator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PPA_MTime
        {
            set { _ppa_mtime = value; }
            get { return _ppa_mtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PPA_Mender
        {
            set { _ppa_mender = value; }
            get { return _ppa_mender; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PPA_Del
        {
            set { _ppa_del = value; }
            get { return _ppa_del; }
        }
        #endregion Model

    }
}

