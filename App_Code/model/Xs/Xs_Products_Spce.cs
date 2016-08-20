using System;
namespace KNet.Model
{
    /// <summary>
    /// Xs_Products_Spce:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Xs_Products_Spce
    {
        public Xs_Products_Spce()
        { }
        #region Model
        private string _xps_id;
        private string _xps_productsbarcode;
        private string _xps_spcecode;
        private string _xps_spcename;
        private string _xps_details;
        private string _xps_creator;
        private DateTime? _xps_ctime;
        private string _xps_mender;
        private DateTime? _xps_mtime;
        /// <summary>
        /// 
        /// </summary>
        public string XPS_ID
        {
            set { _xps_id = value; }
            get { return _xps_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XPS_ProductsBarCode
        {
            set { _xps_productsbarcode = value; }
            get { return _xps_productsbarcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XPS_SpceCode
        {
            set { _xps_spcecode = value; }
            get { return _xps_spcecode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XPS_SpceName
        {
            set { _xps_spcename = value; }
            get { return _xps_spcename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XPS_Details
        {
            set { _xps_details = value; }
            get { return _xps_details; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XPS_Creator
        {
            set { _xps_creator = value; }
            get { return _xps_creator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? XPS_CTime
        {
            set { _xps_ctime = value; }
            get { return _xps_ctime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XPS_Mender
        {
            set { _xps_mender = value; }
            get { return _xps_mender; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? XPS_MTime
        {
            set { _xps_mtime = value; }
            get { return _xps_mtime; }
        }
        #endregion Model

    }
}

