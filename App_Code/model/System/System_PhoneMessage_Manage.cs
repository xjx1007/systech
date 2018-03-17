using System;
namespace KNet.Model
{
    /// <summary>
    /// System_PhoneMessage_Manage:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class System_PhoneMessage_Manage
    {
        public System_PhoneMessage_Manage()
        { }
        #region Model
        private string _spm_id;
        private string _spm_receiveid;
        private string _spm_receivephone;
        private string _spm_receivename;
        private string _spm_senderid;
        private int? _spm_state = 0;
        private string _spm_detail;
        private DateTime? _spm_sendtime;
        private string _spm_sender;
        private int? _spm_type = 0;
        private int? _spm_del = 0;
        private string _spm_FID;
        /// <summary>
        /// 
        /// </summary>
        public string SPM_ID
        {
            set { _spm_id = value; }
            get { return _spm_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SPM_ReceiveID
        {
            set { _spm_receiveid = value; }
            get { return _spm_receiveid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SPM_ReceivePhone
        {
            set { _spm_receivephone = value; }
            get { return _spm_receivephone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SPM_ReceiveName
        {
            set { _spm_receivename = value; }
            get { return _spm_receivename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SPM_SenderID
        {
            set { _spm_senderid = value; }
            get { return _spm_senderid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SPM_State
        {
            set { _spm_state = value; }
            get { return _spm_state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SPM_Detail
        {
            set { _spm_detail = value; }
            get { return _spm_detail; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? SPM_SendTime
        {
            set { _spm_sendtime = value; }
            get { return _spm_sendtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SPM_Sender
        {
            set { _spm_sender = value; }
            get { return _spm_sender; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SPM_Type
        {
            set { _spm_type = value; }
            get { return _spm_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SPM_Del
        {
            set { _spm_del = value; }
            get { return _spm_del; }
        }
        public string SPM_FID
        {
            set { _spm_FID = value; }
            get { return _spm_FID; }
        }
        #endregion Model

    }
}

