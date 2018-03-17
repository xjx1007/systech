using System;
namespace KNet.Model
{
    /// <summary>
    /// PB_Basic_Document:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class PB_Basic_Document
    {
        public PB_Basic_Document()
        { }
        #region Model
        private string _pbm_code;
        private string _pbm_name;
        private string _pbm_type;
        private string _pbm_dutyperson;
        private string _pbm_details;
        private string _pbm_del = "0";
        private DateTime? _pbm_ctime;
        private string _pbm_creator;
        private DateTime? _pbm_mtime;
        private string _pbm_mender;
        private string _PBM_DocName;
        private string _PBM_Visio;
        private string _PBM_FatherID;
        /// <summary>
        /// 
        /// </summary>
        public string PBM_Code
        {
            set { _pbm_code = value; }
            get { return _pbm_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBM_Name
        {
            set { _pbm_name = value; }
            get { return _pbm_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBM_Type
        {
            set { _pbm_type = value; }
            get { return _pbm_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBM_DutyPerson
        {
            set { _pbm_dutyperson = value; }
            get { return _pbm_dutyperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBM_Details
        {
            set { _pbm_details = value; }
            get { return _pbm_details; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBM_Del
        {
            set { _pbm_del = value; }
            get { return _pbm_del; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PBM_CTime
        {
            set { _pbm_ctime = value; }
            get { return _pbm_ctime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBM_Creator
        {
            set { _pbm_creator = value; }
            get { return _pbm_creator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PBM_Mtime
        {
            set { _pbm_mtime = value; }
            get { return _pbm_mtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBM_Mender
        {
            set { _pbm_mender = value; }
            get { return _pbm_mender; }
        }

        public string PBM_DocName
        {
            set { _PBM_DocName = value; }
            get { return _PBM_DocName; }
        }
        public string PBM_Visio
        {
            set { _PBM_Visio = value; }
            get { return _PBM_Visio; }
        }
        public string PBM_FatherID
        {
            set { _PBM_FatherID = value; }
            get { return _PBM_FatherID; }
        }

        #endregion Model

    }
}

