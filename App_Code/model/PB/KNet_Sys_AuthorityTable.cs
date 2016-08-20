using System;
namespace KNet.Model
{
    /// <summary>
    /// KNet_Sys_AuthorityTable:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class KNet_Sys_AuthorityTable
    {
        public KNet_Sys_AuthorityTable()
        { }
        #region Model
        private int _id;
        private string _authorityname;
        private int? _authorityvalue = 0;
        private int? _authoritygroup = 0;
        private string _authorityfaterid;
        private string _AuthorityFunction;
        
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 权限名称
        /// </summary>
        public string AuthorityName
        {
            set { _authorityname = value; }
            get { return _authorityname; }
        }
        /// <summary>
        /// 权限值
        /// </summary>
        public int? AuthorityValue
        {
            set { _authorityvalue = value; }
            get { return _authorityvalue; }
        }
        /// <summary>
        /// 权限分组
        /// </summary>
        public int? AuthorityGroup
        {
            set { _authoritygroup = value; }
            get { return _authoritygroup; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AuthorityFaterID
        {
            set { _authorityfaterid = value; }
            get { return _authorityfaterid; }
        }


        /// <summary>
        /// 
        /// </summary>
        public string AuthorityFunction
        {
            set { _AuthorityFunction = value; }
            get { return _AuthorityFunction; }
        }
        #endregion Model

    }
}

