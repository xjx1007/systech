using System;
namespace KNet.Model
{
    /// <summary>
    /// 实体类AKNet_helps 
    /// </summary>
    [Serializable]
    public class AKNet_helps
    {
        public AKNet_helps()
        { }
        #region Model
        private string _id;
        private string _titles;
        private string _coms;
        private int? _kig;
        private int? _kings;
        private bool _yn;
        private DateTime? _addtimes;
        /// <summary>
        /// 自动ID值
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Titles
        {
            set { _titles = value; }
            get { return _titles; }
        }
        /// <summary>
        /// 内容
        /// </summary>
        public string coms
        {
            set { _coms = value; }
            get { return _coms; }
        }
        /// <summary>
        /// 点数
        /// </summary>
        public int? kig
        {
            set { _kig = value; }
            get { return _kig; }
        }
        /// <summary>
        /// 帮助类型（1采购入库，2库存管理，3销售管理，4财务管理，5统计分析，6人事管理，7系统管理）
        /// </summary>
        public int? kings
        {
            set { _kings = value; }
            get { return _kings; }
        }
        /// <summary>
        /// 是否展示
        /// </summary>
        public bool YN
        {
            set { _yn = value; }
            get { return _yn; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? Addtimes
        {
            set { _addtimes = value; }
            get { return _addtimes; }
        }
        #endregion Model

    }
}

