using System;
namespace KNet.Model
{
    /// <summary>
    /// PB_Knowledge_Manage:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class PB_Knowledge_Manage
    {
        public PB_Knowledge_Manage()
        { }
        #region Model
        private string _pkm_id;
        private string _pkm_code;
        private string _pkm_title;
        private string _pkm_productsbarcode;
        private string _pkm_customervalue;
        private string _pkm_type;
        private string _pkm_state;
        private string _pkm_problem;
        private string _pkm_solution;
        private int? _pkm_del = 0;
        private string _pkm_creator;
        private DateTime? _pkm_ctime;
        private string _pkm_mender;
        private DateTime? _pkm_mtime;
        /// <summary>
        /// 
        /// </summary>
        public string PKM_ID
        {
            set { _pkm_id = value; }
            get { return _pkm_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PKM_Code
        {
            set { _pkm_code = value; }
            get { return _pkm_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PKM_Title
        {
            set { _pkm_title = value; }
            get { return _pkm_title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PKM_ProductsBarCode
        {
            set { _pkm_productsbarcode = value; }
            get { return _pkm_productsbarcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PKM_CustomerValue
        {
            set { _pkm_customervalue = value; }
            get { return _pkm_customervalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PKM_Type
        {
            set { _pkm_type = value; }
            get { return _pkm_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PKM_State
        {
            set { _pkm_state = value; }
            get { return _pkm_state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PKM_Problem
        {
            set { _pkm_problem = value; }
            get { return _pkm_problem; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PKM_Solution
        {
            set { _pkm_solution = value; }
            get { return _pkm_solution; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PKM_Del
        {
            set { _pkm_del = value; }
            get { return _pkm_del; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PKM_Creator
        {
            set { _pkm_creator = value; }
            get { return _pkm_creator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PKM_CTime
        {
            set { _pkm_ctime = value; }
            get { return _pkm_ctime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PKM_Mender
        {
            set { _pkm_mender = value; }
            get { return _pkm_mender; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PKM_MTime
        {
            set { _pkm_mtime = value; }
            get { return _pkm_mtime; }
        }
        #endregion Model

    }
}

