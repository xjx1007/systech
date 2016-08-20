using System;
namespace KNet.Model
{
    /// <summary>
    /// 实体类KNet_Sys_ProcurePack 
    /// </summary>
    [Serializable]
    public class KNet_Sys_ProcurePack
    {
        public KNet_Sys_ProcurePack()
        { }
        #region Model
        private string _id;
        private string _packvalue;
        private string _packname;
        private int? _packpai;
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
        public string PackValue
        {
            set { _packvalue = value; }
            get { return _packvalue; }
        }
        /// <summary>
        /// 包装名称
        /// </summary>
        public string PackName
        {
            set { _packname = value; }
            get { return _packname; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int? PackPai
        {
            set { _packpai = value; }
            get { return _packpai; }
        }
        #endregion Model

    }
}


