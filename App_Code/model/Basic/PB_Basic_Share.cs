using System;
namespace KNet.Model
{
    /// <summary>
    /// PB_Basic_Share:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class PB_Basic_Share
    {
        public PB_Basic_Share()
        { }
        #region Model
        private string _pbs_id;
        private string _pbs_fromid;
        private string _pbs_frompersonid;
        private string _pbs_topersonid;
        private int? _pbs_type = 0;
        private DateTime? _pbs_ctime;
        /// <summary>
        /// 
        /// </summary>
        public string PBS_ID
        {
            set { _pbs_id = value; }
            get { return _pbs_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBS_FromID
        {
            set { _pbs_fromid = value; }
            get { return _pbs_fromid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBS_FromPersonID
        {
            set { _pbs_frompersonid = value; }
            get { return _pbs_frompersonid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBS_ToPersonID
        {
            set { _pbs_topersonid = value; }
            get { return _pbs_topersonid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PBS_Type
        {
            set { _pbs_type = value; }
            get { return _pbs_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PBS_CTime
        {
            set { _pbs_ctime = value; }
            get { return _pbs_ctime; }
        }
        #endregion Model

    }
}

