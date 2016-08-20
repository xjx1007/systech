using System;
namespace KNet.Model
{
    /// <summary>
    /// 实体类KNet_Sys_ProcureType 
    /// </summary>
    public class KNet_Sys_ProcureType
    {
        public KNet_Sys_ProcureType()
        { }
        #region Model
        private string _id;
        private string _procuretypevalue;
        private string _procuretypename;
        private int? _procuretypepai;
        /// <summary>
        /// 
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 采购类型唯一值
        /// </summary>
        public string ProcureTypeValue
        {
            set { _procuretypevalue = value; }
            get { return _procuretypevalue; }
        }
        /// <summary>
        /// 采购类型名称
        /// </summary>
        public string ProcureTypeName
        {
            set { _procuretypename = value; }
            get { return _procuretypename; }
        }
        /// <summary>
        /// 排序号
        /// </summary>
        public int? ProcureTypePai
        {
            set { _procuretypepai = value; }
            get { return _procuretypepai; }
        }
        #endregion Model

    }
}

