using System;
namespace KNet.Model
{
    /// <summary>
    /// 实体类A_CostManagementUnits
    /// </summary>
    [Serializable]
    public class A_CostManagementUnits
    {
        public A_CostManagementUnits()
        { }
        #region Model
        private string _id;
        private string _unitsvalue;
        private string _unitsname;
        private bool _ynshow;
        private int? _unitskings;
        /// <summary>
        /// 自动ID值
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 唯一值
        /// </summary>
        public string UnitsValue
        {
            set { _unitsvalue = value; }
            get { return _unitsvalue; }
        }
        /// <summary>
        /// 费用单位名称
        /// </summary>
        public string UnitsName
        {
            set { _unitsname = value; }
            get { return _unitsname; }
        }
        /// <summary>
        /// 是否使用
        /// </summary>
        public bool YNshow
        {
            set { _ynshow = value; }
            get { return _ynshow; }
        }
        /// <summary>
        /// 费用单位类型(1是采购，2是销售）
        /// </summary>
        public int? UnitsKings
        {
            set { _unitskings = value; }
            get { return _unitskings; }
        }
        #endregion Model

    }
}

