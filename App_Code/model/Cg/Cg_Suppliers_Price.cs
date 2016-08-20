using System;
namespace KNet.Model
{
    /// <summary>
    /// Cg_Suppliers_Price:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Cg_Suppliers_Price
    {
        public Cg_Suppliers_Price()
        { }
        #region Model
        private string _csp_id;
        private string _csp_productsbarcode;
        private int? _csp_isstop = 1;
        private string _csp_productsmaintype;
        private string _csp_serchkey;
        private int? _csp_state = 0;
        private string _csp_shperson;
        private int? _csp_del = 0;
        private string _csp_creator;
        private DateTime? _csp_ctime;
        private string _csp_mender;
        private DateTime? _csp_mtime;
        /// <summary>
        /// 
        /// </summary>
        public string CSP_ID
        {
            set { _csp_id = value; }
            get { return _csp_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CSP_ProductsBarCode
        {
            set { _csp_productsbarcode = value; }
            get { return _csp_productsbarcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CSP_IsStop
        {
            set { _csp_isstop = value; }
            get { return _csp_isstop; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CSP_ProductsMainType
        {
            set { _csp_productsmaintype = value; }
            get { return _csp_productsmaintype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CSP_SerchKey
        {
            set { _csp_serchkey = value; }
            get { return _csp_serchkey; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CSP_State
        {
            set { _csp_state = value; }
            get { return _csp_state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CSP_ShPerson
        {
            set { _csp_shperson = value; }
            get { return _csp_shperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CSP_Del
        {
            set { _csp_del = value; }
            get { return _csp_del; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CSP_Creator
        {
            set { _csp_creator = value; }
            get { return _csp_creator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CSP_CTime
        {
            set { _csp_ctime = value; }
            get { return _csp_ctime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CSP_Mender
        {
            set { _csp_mender = value; }
            get { return _csp_mender; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CSP_MTime
        {
            set { _csp_mtime = value; }
            get { return _csp_mtime; }
        }
        #endregion Model

    }
}

