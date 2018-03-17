using System;
namespace KNet.Model
{
    /// <summary>
    /// 实体类A_CostManagementDB 
    /// </summary>
    [Serializable]
    public class A_CostManagementDB
    {
        public A_CostManagementDB()
        { }
        #region Model
        private string _id;
        private string _themetitle;
        private string _oddnumbers;
        private string _unitsvalue;
        private string _typevalue;
        private decimal? _amountsum;
        private int? _stateid;
        private string _staffnoid;

        private DateTime? _Datetimes;

        private int? _unitskings;
        /// <summary>
        /// 费用单位类型(1是采购，2是销售）
        /// </summary>
        public int? UnitsKings
        {
            set { _unitskings = value; }
            get { return _unitskings; }
        }

        /// <summary>
        /// 发生时间
        /// </summary>
        public DateTime? Datetimes
        {
            set { _Datetimes = value; }
            get { return _Datetimes; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 主题
        /// </summary>
        public string ThemeTitle
        {
            set { _themetitle = value; }
            get { return _themetitle; }
        }
        /// <summary>
        /// 单号
        /// </summary>
        public string OddNumbers
        {
            set { _oddnumbers = value; }
            get { return _oddnumbers; }
        }
        /// <summary>
        /// 单位唯一值
        /// </summary>
        public string UnitsValue
        {
            set { _unitsvalue = value; }
            get { return _unitsvalue; }
        }
        /// <summary>
        /// 类型唯一值
        /// </summary>
        public string TypeValue
        {
            set { _typevalue = value; }
            get { return _typevalue; }
        }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal? AmountSum
        {
            set { _amountsum = value; }
            get { return _amountsum; }
        }
        /// <summary>
        /// 状态（0新单，1已审核，2已支付）
        /// </summary>
        public int? StateId
        {
            set { _stateid = value; }
            get { return _stateid; }
        }
        /// <summary>
        /// 经办人
        /// </summary>
        public string StaffNoId
        {
            set { _staffnoid = value; }
            get { return _staffnoid; }
        }
        #endregion Model

    }
}

