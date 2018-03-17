using System;
namespace KNet.Model
{
    /// <summary>
    /// Cw_Account_Bill_Outimes:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Cw_Account_Bill_Outimes
    {
        public Cw_Account_Bill_Outimes()
        { }
        #region Model
        private string _cao_id;
        private string _cao_cadid;
        private decimal? _cao_money;
        private int? _cao_outdays;
        private DateTime? _cao_outtime;
        private string _cao_remarks;
        private string _CAOC_DirectOutID;
        /// <summary>
        /// 
        /// </summary>
        public string CAO_ID
        {
            set { _cao_id = value; }
            get { return _cao_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAOC_DirectOutID
        {
            set { _CAOC_DirectOutID = value; }
            get { return _CAOC_DirectOutID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAO_CADID
        {
            set { _cao_cadid = value; }
            get { return _cao_cadid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CAO_Money
        {
            set { _cao_money = value; }
            get { return _cao_money; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CAO_OutDays
        {
            set { _cao_outdays = value; }
            get { return _cao_outdays; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CAO_OutTime
        {
            set { _cao_outtime = value; }
            get { return _cao_outtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAO_Remarks
        {
            set { _cao_remarks = value; }
            get { return _cao_remarks; }
        }
        #endregion Model

    }
}

