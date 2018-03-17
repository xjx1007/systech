using System;
namespace KNet.Model
{
    /// <summary>
    /// PB_Code_Sequence:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class PB_Code_Sequence
    {
        public PB_Code_Sequence()
        { }
        #region Model
        private string _pcs_table;
        private DateTime? _pcs_date;
        private string _pcs_type;
        private decimal? _pcs_identity;
        private decimal? _pcs_default;
        /// <summary>
        /// 
        /// </summary>
        public string PCS_Table
        {
            set { _pcs_table = value; }
            get { return _pcs_table; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PCS_Date
        {
            set { _pcs_date = value; }
            get { return _pcs_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PCS_Type
        {
            set { _pcs_type = value; }
            get { return _pcs_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? PCS_Identity
        {
            set { _pcs_identity = value; }
            get { return _pcs_identity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? PCS_Default
        {
            set { _pcs_default = value; }
            get { return _pcs_default; }
        }
        #endregion Model

    }
}

