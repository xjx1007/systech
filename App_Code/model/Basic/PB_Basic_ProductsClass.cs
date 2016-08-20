using System;
namespace KNet.Model
{
    /// <summary>
    /// PB_Basic_ProductsClass:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class PB_Basic_ProductsClass
    {
        public PB_Basic_ProductsClass()
        { }
        #region Model
        private string _pbp_id;
        private string _pbp_code;
        private string _pbp_name;
        private string _pbp_faterid;
        private string _pbp_order;
        private string _pbp_creator;
        private DateTime? _pbp_ctime;
        private DateTime? _pbp_mtime;
        private string _pbp_mender;
        private int _pbp_days;
        private int _pbp_orderdays;
        /// <summary>
        /// 
        /// </summary>
        public string PBP_ID
        {
            set { _pbp_id = value; }
            get { return _pbp_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBP_Code
        {
            set { _pbp_code = value; }
            get { return _pbp_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBP_Name
        {
            set { _pbp_name = value; }
            get { return _pbp_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBP_FaterID
        {
            set { _pbp_faterid = value; }
            get { return _pbp_faterid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBP_Order
        {
            set { _pbp_order = value; }
            get { return _pbp_order; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBP_Creator
        {
            set { _pbp_creator = value; }
            get { return _pbp_creator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PBP_CTime
        {
            set { _pbp_ctime = value; }
            get { return _pbp_ctime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PBP_MTime
        {
            set { _pbp_mtime = value; }
            get { return _pbp_mtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBP_Mender
        {
            set { _pbp_mender = value; }
            get { return _pbp_mender; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PBP_Days
        {
            set { _pbp_days = value; }
            get { return _pbp_days; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PBP_OrderDays
        {
            set { _pbp_orderdays = value; }
            get { return _pbp_orderdays; }
        }
        #endregion Model

    }
}

