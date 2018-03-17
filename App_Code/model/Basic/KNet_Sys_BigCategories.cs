using System;
namespace KNet.Model
{
    /// <summary>
    /// 实体类KNet_Sys_BigCategories 
    /// </summary>
    public class KNet_Sys_BigCategories
    {
        public KNet_Sys_BigCategories()
        { }
        #region Model
        private string _id;
        private string _bigno;
        private string _catename;
        private int? _catepai;
        /// <summary>
        /// 自动ID值
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 大分类唯一值
        /// </summary>
        public string BigNo
        {
            set { _bigno = value; }
            get { return _bigno; }
        }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string CateName
        {
            set { _catename = value; }
            get { return _catename; }
        }
        /// <summary>
        /// 分类排序
        /// </summary>
        public int? CatePai
        {
            set { _catepai = value; }
            get { return _catepai; }
        }
        #endregion Model

    }
}

