using System;
using System.Collections;
namespace KNet.Model
{
    /// <summary>
    /// KNet_Reports_Submit:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class KNet_Reports_Submit
    {
        public KNet_Reports_Submit()
        { }
        #region Model
        private string _krs_id;
        private string _krs_code;
        private string _krs_dutyperson;
        private string _krs_type;
        private string _krs_remarks;
        private DateTime? _krs_ctime;
        private string _krs_creator;
        private DateTime? _krs_mtime;
        private string _krs_mender;
        private int? _krs_del = 0;
        private int? _KRS_State = 0;
        private DateTime? _krs_stime;
        private string _KRS_Topic;
        private string _KRS_NoticeID;
        private ArrayList _arr_details;
        /// <summary>
        /// 
        /// </summary>
        public string KRS_ID
        {
            set { _krs_id = value; }
            get { return _krs_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KRS_Code
        {
            set { _krs_code = value; }
            get { return _krs_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KRS_DutyPerson
        {
            set { _krs_dutyperson = value; }
            get { return _krs_dutyperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KRS_Type
        {
            set { _krs_type = value; }
            get { return _krs_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KRS_Remarks
        {
            set { _krs_remarks = value; }
            get { return _krs_remarks; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? KRS_CTime
        {
            set { _krs_ctime = value; }
            get { return _krs_ctime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KRS_Creator
        {
            set { _krs_creator = value; }
            get { return _krs_creator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? KRS_MTime
        {
            set { _krs_mtime = value; }
            get { return _krs_mtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KRS_Mender
        {
            set { _krs_mender = value; }
            get { return _krs_mender; }
        }
        /// </summary>
        public string KRS_Topic
        {
            set { _KRS_Topic = value; }
            get { return _KRS_Topic; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public int? KRS_Del
        {
            set { _krs_del = value; }
            get { return _krs_del; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public int? KRS_State
        {
            set { _KRS_State = value; }
            get { return _KRS_State; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public DateTime? KRS_Stime
        {
            set { _krs_stime = value; }
            get { return _krs_stime; }
        }

        public string KRS_NoticeID
        {
            set { _KRS_NoticeID = value; }
            get { return _KRS_NoticeID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public ArrayList arr_details
        {
            set { _arr_details = value; }
            get { return _arr_details; }
        }
        #endregion Model

    }
}

