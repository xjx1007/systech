using System;
namespace KNet.Model
{
    /// <summary>
    /// Cw_Accounting_Init_Details:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Cw_Accounting_Init_Details
    {
        public Cw_Accounting_Init_Details()
        { }
        #region Model
        private string _caid_id;
        private string _caid_fid;
        private DateTime? _caid_outtime;
        private decimal? _caid_number;
        private string _caid_remarks;
        /// <summary>
        /// 
        /// </summary>
        public string CAID_ID
        {
            set { _caid_id = value; }
            get { return _caid_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAID_FID
        {
            set { _caid_fid = value; }
            get { return _caid_fid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CAID_OutTime
        {
            set { _caid_outtime = value; }
            get { return _caid_outtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CAID_Number
        {
            set { _caid_number = value; }
            get { return _caid_number; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAID_Remarks
        {
            set { _caid_remarks = value; }
            get { return _caid_remarks; }
        }
        #endregion Model

    }
}

