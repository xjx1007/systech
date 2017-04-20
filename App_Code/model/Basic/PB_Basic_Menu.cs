using System;
namespace KNet.Model
{
    /// <summary>
    /// PB_Basic_Menu:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class PB_Basic_Menu
    {
        public PB_Basic_Menu()
        { }
        #region Model
        private string _pbm_id;
        private string _pbm_fatherid;
        private string _pbm_name;
        private string _pbm_module;
        private string _pbm_parenttab;
        private string _pbm_url;
        private string _pbm_del;
        private int _pbm_order;
        private DateTime _pbm_ctime;
        private DateTime _pbm_mtime;
        private string _pbm_creator;
        private string _pbm_mender;
        private int _pbm_colspan;
        private int _pbm_rowspan;
        private int _pbm_level;
        private int _pbm_ischild;
        private string _pbm_icon;

        /// <summary>
        /// 
        /// </summary>
        public string PBM_ID
        {
            set { _pbm_id = value; }
            get { return _pbm_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBM_FatherID
        {
            set { _pbm_fatherid = value; }
            get { return _pbm_fatherid; }
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
        public string PBM_Module
        {
            set { _pbm_module = value; }
            get { return _pbm_module; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBM_Parenttab
        {
            set { _pbm_parenttab = value; }
            get { return _pbm_parenttab; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBM_URL
        {
            set { _pbm_url = value; }
            get { return _pbm_url; }
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
        public int PBM_Order
        {
            set { _pbm_order = value; }
            get { return _pbm_order; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime PBM_CTime
        {
            set { _pbm_ctime = value; }
            get { return _pbm_ctime; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime PBM_MTime
        {
            set { _pbm_mtime = value; }
            get { return _pbm_mtime; }
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
        public string PBM_Mender
        {
            set { _pbm_mender = value; }
            get { return _pbm_mender; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int PBM_ColSpan
        {
            set { _pbm_colspan = value; }
            get { return _pbm_colspan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PBM_RowSpan
        {
            set { _pbm_rowspan = value; }
            get { return _pbm_rowspan; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public int PBM_Level
        {
            set { _pbm_level = value; }
            get { return _pbm_level; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PBM_IsChild
        {
            set { _pbm_ischild = value; }
            get { return _pbm_ischild; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBM_Icon
        {
            set { _pbm_icon = value; }
            get { return _pbm_icon; }
        }
        #endregion Model

    }
}

