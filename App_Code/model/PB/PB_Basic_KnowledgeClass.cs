using System;
namespace KNet.Model
{
    /// <summary>
    /// PB_Basic_KnowledgeClass:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class PB_Basic_KnowledgeClass
    {
        public PB_Basic_KnowledgeClass()
        { }
        #region Model
        private string _pbk_id;
        private string _pbk_code;
        private string _pbk_name;
        private string _pbk_faterid;
        private string _pbk_order;
        private string _pbk_creator;
        private DateTime? _pbk_ctime;
        private DateTime? _pbk_mtime;
        private string _pbk_mender;
        private int? _pbk_days = 0;
        /// <summary>
        /// 
        /// </summary>
        public string PBK_ID
        {
            set { _pbk_id = value; }
            get { return _pbk_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBK_Code
        {
            set { _pbk_code = value; }
            get { return _pbk_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBK_Name
        {
            set { _pbk_name = value; }
            get { return _pbk_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBK_FaterID
        {
            set { _pbk_faterid = value; }
            get { return _pbk_faterid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBK_Order
        {
            set { _pbk_order = value; }
            get { return _pbk_order; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBK_Creator
        {
            set { _pbk_creator = value; }
            get { return _pbk_creator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PBK_CTime
        {
            set { _pbk_ctime = value; }
            get { return _pbk_ctime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PBK_MTime
        {
            set { _pbk_mtime = value; }
            get { return _pbk_mtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBK_Mender
        {
            set { _pbk_mender = value; }
            get { return _pbk_mender; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PBK_Days
        {
            set { _pbk_days = value; }
            get { return _pbk_days; }
        }
        #endregion Model

    }
}

