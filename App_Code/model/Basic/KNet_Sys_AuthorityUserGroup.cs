using System;
namespace KNet.Model
{
    /// <summary>
    /// 实体类KNet_Sys_AuthorityUserGroup 
    /// </summary>
    [Serializable]
    public class KNet_Sys_AuthorityUserGroup
    {
        public KNet_Sys_AuthorityUserGroup()
        { }
        #region Model
        private string _id;
        private string _groupvalue;
        private string _groupname;
        private int? _grouppai;
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
        public string GroupValue
        {
            set { _groupvalue = value; }
            get { return _groupvalue; }
        }
        /// <summary>
        /// 用户组名称
        /// </summary>
        public string GroupName
        {
            set { _groupname = value; }
            get { return _groupname; }
        }
        /// <summary>
        /// 排序值
        /// </summary>
        public int? GroupPai
        {
            set { _grouppai = value; }
            get { return _grouppai; }
        }
        #endregion Model

    }
}

