using System;
namespace KNet.Model
{
    /// <summary>
    /// PB_Basic_Code:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class PB_Basic_Code
    {
        public PB_Basic_Code()
        { }
        #region Model
        private string _pbc_id;
        private string _pbc_code;
        private string _pbc_name;
        private int? _pbc_order = 0;
        private int? _pbc_del = 0;
        private string _pbc_details;
        private string _pbc_cname;
        private string _PBC_FID;
        private string _PBC_FCode;
        /// <summary>
        /// 主键
        /// </summary>
        public string PBC_ID
        {
            set { _pbc_id = value; }
            get { return _pbc_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBC_Code
        {
            set { _pbc_code = value; }
            get { return _pbc_code; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string PBC_Name
        {
            set { _pbc_name = value; }
            get { return _pbc_name; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int? PBC_Order
        {
            set { _pbc_order = value; }
            get { return _pbc_order; }
        }
        /// <summary>
        /// 删除状态
        /// </summary>
        public int? PBC_Del
        {
            set { _pbc_del = value; }
            get { return _pbc_del; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBC_Details
        {
            set { _pbc_details = value; }
            get { return _pbc_details; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBC_CName
        {
            set { _pbc_cname = value; }
            get { return _pbc_cname; }
        }
        public string PBC_FID
        {
            set { _PBC_FID = value; }
            get { return _PBC_FID; }
        }
        public string PBC_FCode
        {
            set { _PBC_FCode = value; }
            get { return _PBC_FCode; }
        }
        #endregion Model

    }
}

