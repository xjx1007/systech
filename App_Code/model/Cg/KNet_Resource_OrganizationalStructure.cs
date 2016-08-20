using System;
namespace KNet.Model
{
    /// <summary>
    /// 实体类KNet_Resource_OrganizationalStructure
    /// </summary>
    public class KNet_Resource_OrganizationalStructure
    {
        public KNet_Resource_OrganizationalStructure()
        { }
        #region Model
        private string _id;
        private string _strucvalue;
        private string _strucname;
        private string _strucpid;
        private int? _strucpai;
        
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
        public string StrucValue
        {
            set { _strucvalue = value; }
            get { return _strucvalue; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string StrucName
        {
            set { _strucname = value; }
            get { return _strucname; }
        }
        /// <summary>
        /// 上级ID（0分公司）
        /// </summary>
        public string StrucPID
        {
            set { _strucpid = value; }
            get { return _strucpid; }
        }
        /// <summary>
        /// 排序号
        /// </summary>
        public int? StrucPai
        {
            set { _strucpai = value; }
            get { return _strucpai; }
        }



        #endregion Model

    }
}

