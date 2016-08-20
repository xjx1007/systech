using System;
namespace KNet.Model
{
    /// <summary>
    /// KNet_Reports_Submit_Type:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class KNet_Reports_Submit_Type
    {
        public KNet_Reports_Submit_Type()
        { }
        #region Model
        private string _krt_id;
        private string _krt_code;
        private string _krt_depart;
        private string _krt_person;
        private string _krt_typename;
        private int? _krt_type;
        private int? _krt_typetime;
        private int? _krt_del = 0;
        private string _krt_creator;
        private DateTime? _krt_ctime;
        private DateTime? _krt_mtime;
        private string _krt_mender;
        /// <summary>
        /// 
        /// </summary>
        public string KRT_ID
        {
            set { _krt_id = value; }
            get { return _krt_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KRT_Code
        {
            set { _krt_code = value; }
            get { return _krt_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KRT_Depart
        {
            set { _krt_depart = value; }
            get { return _krt_depart; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KRT_Person
        {
            set { _krt_person = value; }
            get { return _krt_person; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KRT_TypeName
        {
            set { _krt_typename = value; }
            get { return _krt_typename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? KRT_Type
        {
            set { _krt_type = value; }
            get { return _krt_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? KRT_TypeTime
        {
            set { _krt_typetime = value; }
            get { return _krt_typetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? KRT_Del
        {
            set { _krt_del = value; }
            get { return _krt_del; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KRT_Creator
        {
            set { _krt_creator = value; }
            get { return _krt_creator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? KRT_CTime
        {
            set { _krt_ctime = value; }
            get { return _krt_ctime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? KRT_MTime
        {
            set { _krt_mtime = value; }
            get { return _krt_mtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KRT_Mender
        {
            set { _krt_mender = value; }
            get { return _krt_mender; }
        }
        #endregion Model

    }
}

