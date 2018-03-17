using System;
using System.Collections;
namespace KNet.Model
{
    /// <summary>
    /// PB_Basic_Feedback:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class PB_Basic_Feedback
    {
        public PB_Basic_Feedback()
        { }
        #region Model
        private string _pbf_id;
        private string _pbf_code;
        private string _pbf_contentperson;
        private string _pbf_type;
        private string _pbf_details;
        private int? _pbf_state = 0;
        private string _pbf_creator;
        private DateTime? _pbf_ctime;
        private string _pbf_mender;
        private DateTime? _pbf_mtime;
        private ArrayList _arr_List;
        /// <summary>
        /// 
        /// </summary>
        public string PBF_ID
        {
            set { _pbf_id = value; }
            get { return _pbf_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBF_Code
        {
            set { _pbf_code = value; }
            get { return _pbf_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBF_ContentPerson
        {
            set { _pbf_contentperson = value; }
            get { return _pbf_contentperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBF_Type
        {
            set { _pbf_type = value; }
            get { return _pbf_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBF_Details
        {
            set { _pbf_details = value; }
            get { return _pbf_details; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PBF_State
        {
            set { _pbf_state = value; }
            get { return _pbf_state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBF_Creator
        {
            set { _pbf_creator = value; }
            get { return _pbf_creator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PBF_CTime
        {
            set { _pbf_ctime = value; }
            get { return _pbf_ctime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBF_Mender
        {
            set { _pbf_mender = value; }
            get { return _pbf_mender; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PBF_MTime
        {
            set { _pbf_mtime = value; }
            get { return _pbf_mtime; }
        }
        public ArrayList arr_List
        {
            set { _arr_List = value; }
            get { return _arr_List; }
        }
        #endregion Model

    }
}

