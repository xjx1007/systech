using System;
namespace KNet.Model
{
    /// <summary>
    /// 实体类KNet_Sys_Config 
    /// </summary>
    public class KNet_Sys_Config
    {
        public KNet_Sys_Config()
        { }
        #region Model
        private int _id;
        private string _sys_companyname;
        private bool _sys_noticeyn;
        private string _sys_noticecontent;
        private bool _sys_logsyn;
        private bool _sys_outwarning;
        private string _sys_key;
        private string _sys_userno;
        /// <summary>
        /// 自动ID值
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 企业名称
        /// </summary>
        public string Sys_CompanyName
        {
            set { _sys_companyname = value; }
            get { return _sys_companyname; }
        }
        /// <summary>
        /// 是否打开公告
        /// </summary>
        public bool Sys_NoticeYN
        {
            set { _sys_noticeyn = value; }
            get { return _sys_noticeyn; }
        }
        /// <summary>
        /// 公告内容
        /// </summary>
        public string Sys_NoticeContent
        {
            set { _sys_noticecontent = value; }
            get { return _sys_noticecontent; }
        }
        /// <summary>
        /// 是否记录日志
        /// </summary>
        public bool Sys_LogsYN
        {
            set { _sys_logsyn = value; }
            get { return _sys_logsyn; }
        }
        /// <summary>
        /// 缺货时是否自动弹出提醒
        /// </summary>
        public bool Sys_OutWarning
        {
            set { _sys_outwarning = value; }
            get { return _sys_outwarning; }
        }
        /// <summary>
        /// 受权码
        /// </summary>
        public string Sys_Key
        {
            set { _sys_key = value; }
            get { return _sys_key; }
        }
        /// <summary>
        /// 用户编号
        /// </summary>
        public string Sys_UserNo
        {
            set { _sys_userno = value; }
            get { return _sys_userno; }
        }
        #endregion Model

    }
}

