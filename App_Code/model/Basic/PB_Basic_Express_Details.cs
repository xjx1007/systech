using System;
namespace KNet.Model
{
    /// <summary>
    /// PB_Basic_Express_Details:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class PB_Basic_Express_Details
    {
        public PB_Basic_Express_Details()
        { }
        #region Model
        private string _pbed_id;
        private string _pbed_fid;
        private string _pbed_time;
        private string _pbed_place;
        private string _pbed_details;
        private string _pbed_state;
        /// <summary>
        /// 
        /// </summary>
        public string PBED_ID
        {
            set { _pbed_id = value; }
            get { return _pbed_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBED_FID
        {
            set { _pbed_fid = value; }
            get { return _pbed_fid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBED_Time
        {
            set { _pbed_time = value; }
            get { return _pbed_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBED_Place
        {
            set { _pbed_place = value; }
            get { return _pbed_place; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBED_Details
        {
            set { _pbed_details = value; }
            get { return _pbed_details; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBED_State
        {
            set { _pbed_state = value; }
            get { return _pbed_state; }
        }
        #endregion Model

    }
}

