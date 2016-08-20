using System;
namespace KNet.Model
{
    /// <summary>
    /// 实体类KNet_Static_logs 
    /// </summary>
    public class KNet_Static_logs
    {
        public KNet_Static_logs()
        { }
        #region Model
        private string _id;
        private string _staffno;
        private DateTime? _logtime;
        private string _logip;
        private string _logcontent;
        /// <summary>
        /// 自动ID值
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 操作员唯一值
        /// </summary>
        public string StaffNo
        {
            set { _staffno = value; }
            get { return _staffno; }
        }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime? Logtime
        {
            set { _logtime = value; }
            get { return _logtime; }
        }
        /// <summary>
        /// IP地址
        /// </summary>
        public string logIP
        {
            set { _logip = value; }
            get { return _logip; }
        }
        /// <summary>
        /// 内容
        /// </summary>
        public string logContent
        {
            set { _logcontent = value; }
            get { return _logcontent; }
        }
        #endregion Model

    }
}

