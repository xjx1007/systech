using System;
namespace KNet.Model
{
    /// <summary>
    /// Pb_Basic_Notice:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Pb_Basic_Notice
    {
        public Pb_Basic_Notice()
        { }
        #region Model
        private string _pbn_id;
        private string _pbn_title;
        private string _pbn_type;
        private DateTime? _pbn_begintime;
        private DateTime? _pbn_endtime;
        private string _pbn_receiveid;
        private string _pbn_details;
        private DateTime? _pbn_ctime;
        private string _pbn_creator;
        private DateTime? _pbn_mtime;
        private string _pbn_mender;
        private int? _pbn_del = 0;
        /// <summary>
        /// 
        /// </summary>
        public string PBN_ID
        {
            set { _pbn_id = value; }
            get { return _pbn_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBN_Title
        {
            set { _pbn_title = value; }
            get { return _pbn_title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBN_Type
        {
            set { _pbn_type = value; }
            get { return _pbn_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PBN_BeginTime
        {
            set { _pbn_begintime = value; }
            get { return _pbn_begintime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PBN_EndTime
        {
            set { _pbn_endtime = value; }
            get { return _pbn_endtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBN_ReceiveID
        {
            set { _pbn_receiveid = value; }
            get { return _pbn_receiveid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBN_Details
        {
            set { _pbn_details = value; }
            get { return _pbn_details; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PBN_CTime
        {
            set { _pbn_ctime = value; }
            get { return _pbn_ctime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBN_Creator
        {
            set { _pbn_creator = value; }
            get { return _pbn_creator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PBN_MTime
        {
            set { _pbn_mtime = value; }
            get { return _pbn_mtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBN_Mender
        {
            set { _pbn_mender = value; }
            get { return _pbn_mender; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PBN_Del
        {
            set { _pbn_del = value; }
            get { return _pbn_del; }
        }
        #endregion Model

    }
}

