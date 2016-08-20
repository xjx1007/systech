using System;
namespace KNet.Model
{
    /// <summary>
    /// Xs_Sales_Task:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Xs_Sales_Task
    {
        public Xs_Sales_Task()
        { }
        #region Model
        private string _xst_id;
        private string _xst_topic;
        private string _xst_state;
        private string _xst_claim;
        private int? _xst_ismodiy = 0;
        private DateTime? _xst_begintime;
        private DateTime? _xst_endtime;
        private string _xst_dutyperson;
        private string _xst_executor;
        private string _xst_remarks;
        private string _xst_creator;
        private DateTime? _xst_ctime;
        private string _xst_mender;
        private DateTime? _xst_mtime;
        private int? _xst_del = 0;
        /// <summary>
        /// 
        /// </summary>
        public string XST_ID
        {
            set { _xst_id = value; }
            get { return _xst_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XST_Topic
        {
            set { _xst_topic = value; }
            get { return _xst_topic; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XST_State
        {
            set { _xst_state = value; }
            get { return _xst_state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XST_Claim
        {
            set { _xst_claim = value; }
            get { return _xst_claim; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? XST_ISModiy
        {
            set { _xst_ismodiy = value; }
            get { return _xst_ismodiy; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? XST_BeginTime
        {
            set { _xst_begintime = value; }
            get { return _xst_begintime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? XST_EndTime
        {
            set { _xst_endtime = value; }
            get { return _xst_endtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XST_DutyPerson
        {
            set { _xst_dutyperson = value; }
            get { return _xst_dutyperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XST_Executor
        {
            set { _xst_executor = value; }
            get { return _xst_executor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XST_Remarks
        {
            set { _xst_remarks = value; }
            get { return _xst_remarks; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XST_Creator
        {
            set { _xst_creator = value; }
            get { return _xst_creator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? XST_CTime
        {
            set { _xst_ctime = value; }
            get { return _xst_ctime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XST_Mender
        {
            set { _xst_mender = value; }
            get { return _xst_mender; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? XST_MTime
        {
            set { _xst_mtime = value; }
            get { return _xst_mtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? XST_Del
        {
            set { _xst_del = value; }
            get { return _xst_del; }
        }
        #endregion Model

    }
}

