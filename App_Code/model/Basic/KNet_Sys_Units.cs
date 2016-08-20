using System;
namespace KNet.Model
{
    /// <summary>
    /// 实体类KNet_Sys_Units 
    /// </summary>
    public class KNet_Sys_Units
    {
        public KNet_Sys_Units()
        { }
        #region Model
        private string _id;
        private string _unitsno;
        private string _unitsname;
        private int? _unitspai;
        /// <summary>
        /// 自动ID值
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 单位唯一值
        /// </summary>
        public string UnitsNo
        {
            set { _unitsno = value; }
            get { return _unitsno; }
        }
        /// <summary>
        /// 单位名称
        /// </summary>
        public string UnitsName
        {
            set { _unitsname = value; }
            get { return _unitsname; }
        }
        /// <summary>
        /// 单位排序
        /// </summary>
        public int? UnitsPai
        {
            set { _unitspai = value; }
            get { return _unitspai; }
        }
        #endregion Model

    }
}

