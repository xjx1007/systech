using System;
namespace KNet.Model
{
    /// <summary>
    /// KNet_Reports_Submit_Details:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class KNet_Reports_Submit_Details
    {
        public KNet_Reports_Submit_Details()
        { }
        #region Model
        private string _krd_id;
        private string _krd_submitid;
        private string _kpd_type;
        private string _krd_url;
        private string _krd_name;
        /// <summary>
        /// 
        /// </summary>
        public string KRD_ID
        {
            set { _krd_id = value; }
            get { return _krd_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KRD_SubmitID
        {
            set { _krd_submitid = value; }
            get { return _krd_submitid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KPD_Type
        {
            set { _kpd_type = value; }
            get { return _kpd_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KRD_URL
        {
            set { _krd_url = value; }
            get { return _krd_url; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KRD_Name
        {
            set { _krd_name = value; }
            get { return _krd_name; }
        }
        #endregion Model

    }
}

