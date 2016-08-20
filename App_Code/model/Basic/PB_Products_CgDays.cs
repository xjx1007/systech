using System;
namespace KNet.Model
{
    /// <summary>
    /// PB_Products_CgDays:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class PB_Products_CgDays
    {
        public PB_Products_CgDays()
        { }
        #region Model
        private string _ppc_id;
        private string _ppc_productsbarcode;
        private decimal? _ppc_min;
        private decimal? _ppc_max;
        private int? _ppc_days;
        /// <summary>
        /// 
        /// </summary>
        public string PPC_ID
        {
            set { _ppc_id = value; }
            get { return _ppc_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PPC_ProductsBarCode
        {
            set { _ppc_productsbarcode = value; }
            get { return _ppc_productsbarcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? PPC_Min
        {
            set { _ppc_min = value; }
            get { return _ppc_min; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? PPC_Max
        {
            set { _ppc_max = value; }
            get { return _ppc_max; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PPC_Days
        {
            set { _ppc_days = value; }
            get { return _ppc_days; }
        }
        #endregion Model

    }
}

