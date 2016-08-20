using System;
namespace KNet.Model
{
    /// <summary>
    /// 实体类AKNnet_coms 
    /// </summary>
    [Serializable]
    public class AKNnet_coms
    {
        public AKNnet_coms()
        { }
        #region Model
        private string _id;
        private string _titles;
        private string _coms;
        private bool _yn;
        private string _kings;
        /// <summary>
        /// 自动ID值
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 主题
        /// </summary>
        public string Titles
        {
            set { _titles = value; }
            get { return _titles; }
        }
        /// <summary>
        /// 内容
        /// </summary>
        public string Coms
        {
            set { _coms = value; }
            get { return _coms; }
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
        /// 分类（1系统总述，2如何使用）
        /// </summary>
        public string Kings
        {
            set { _kings = value; }
            get { return _kings; }
        }
        #endregion Model

    }
}

