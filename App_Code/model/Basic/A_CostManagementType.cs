using System;
namespace KNet.Model
{
    /// <summary>
    /// 实体类A_CostManagementType 
    /// </summary>
    [Serializable]
    public class A_CostManagementType
    {
        public A_CostManagementType()
        { }
        #region Model
        private string _id;
        private string _typename;
        private string _typevalue;
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
        /// 自动ID值
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 类型名称
        /// </summary>
        public string TypeName
        {
            set { _typename = value; }
            get { return _typename; }
        }
        /// <summary>
        /// 类型名称
        /// </summary>
        public string TypeValue
        {
            set { _typevalue = value; }
            get { return _typevalue; }
        }
        #endregion Model

    }
}

