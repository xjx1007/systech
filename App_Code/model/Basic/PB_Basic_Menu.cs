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
        private string _PBM_Icon;
        /// <summary>
        /// 
        /// </summary>
        public string PBM_Icon
        {
            set { _PBM_Icon = value; }
            get { return _PBM_Icon; }
        }
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
        #endregion Model

    }
}

