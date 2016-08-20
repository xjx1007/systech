using System;
namespace KNet.Model
{
    /// <summary>
    /// PB_Basic_Comment:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class PB_Basic_Comment
    {
        public PB_Basic_Comment()
        { }
        #region Model
        private string _pbc_id;
        private string _pbc_fid;
        private string _pbc_fromperson;
        private int? _pbc_presetcode = -1;
        private string _pbc_description;
        private DateTime? _pbc_ctime;
        private int? _pbc_type = 0;
        /// <summary>
        /// 
        /// </summary>
        public string PBC_ID
        {
            set { _pbc_id = value; }
            get { return _pbc_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBC_FID
        {
            set { _pbc_fid = value; }
            get { return _pbc_fid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBC_FromPerson
        {
            set { _pbc_fromperson = value; }
            get { return _pbc_fromperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PBC_PresetCode
        {
            set { _pbc_presetcode = value; }
            get { return _pbc_presetcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBC_Description
        {
            set { _pbc_description = value; }
            get { return _pbc_description; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PBC_CTime
        {
            set { _pbc_ctime = value; }
            get { return _pbc_ctime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PBC_Type
        {
            set { _pbc_type = value; }
            get { return _pbc_type; }
        }
        #endregion Model

    }
}
