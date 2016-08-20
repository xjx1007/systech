using System;
namespace KNet.Model
{
    /// <summary>
    /// Xs_Sales_Content:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Xs_Sales_Content
    {
        public Xs_Sales_Content()
        { }
        #region Model
        private string _xsc_id;
        private string _xsc_customervalue;
        private string _xsc_linkman;
        private string _xsc_topic;
        private DateTime? _xsc_stime;
        private string _xsc_dutyperson;
        private string _xsc_types;
        private string _xsc_steps;
        private string _xsc_state;
        private DateTime? _xsc_nextasktime;
        private string _xsc_saleschance;
        private string _xsc_remarks;
        private string _xsc_creator;
        private DateTime? _xsc_ctime;
        private string _xsc_mender;
        private DateTime? _xsc_mtime;
        private int? _xsc_del = 0;
        private int _XSC_Type = 0;
        
        /// <summary>
        /// 
        /// </summary>
        public string XSC_ID
        {
            set { _xsc_id = value; }
            get { return _xsc_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XSC_CustomerValue
        {
            set { _xsc_customervalue = value; }
            get { return _xsc_customervalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XSC_LinkMan
        {
            set { _xsc_linkman = value; }
            get { return _xsc_linkman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XSC_Topic
        {
            set { _xsc_topic = value; }
            get { return _xsc_topic; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? XSC_Stime
        {
            set { _xsc_stime = value; }
            get { return _xsc_stime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XSC_DutyPerson
        {
            set { _xsc_dutyperson = value; }
            get { return _xsc_dutyperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XSC_Types
        {
            set { _xsc_types = value; }
            get { return _xsc_types; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XSC_Steps
        {
            set { _xsc_steps = value; }
            get { return _xsc_steps; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XSC_State
        {
            set { _xsc_state = value; }
            get { return _xsc_state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? XSC_NextAskTime
        {
            set { _xsc_nextasktime = value; }
            get { return _xsc_nextasktime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XSC_SalesChance
        {
            set { _xsc_saleschance = value; }
            get { return _xsc_saleschance; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XSC_Remarks
        {
            set { _xsc_remarks = value; }
            get { return _xsc_remarks; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XSC_Creator
        {
            set { _xsc_creator = value; }
            get { return _xsc_creator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? XSC_CTime
        {
            set { _xsc_ctime = value; }
            get { return _xsc_ctime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XSC_Mender
        {
            set { _xsc_mender = value; }
            get { return _xsc_mender; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? XSC_MTime
        {
            set { _xsc_mtime = value; }
            get { return _xsc_mtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? XSC_Del
        {
            set { _xsc_del = value; }
            get { return _xsc_del; }
        }

        public int XSC_Type
        {
            set { _XSC_Type = value; }
            get { return _XSC_Type; }
        }
        
        #endregion Model

    }
}

