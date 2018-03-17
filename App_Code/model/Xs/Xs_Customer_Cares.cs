using System;
namespace KNet.Model
{
    /// <summary>
    /// Xs_Customer_Cares:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Xs_Customer_Cares
    {
        public Xs_Customer_Cares()
        { }
        #region Model
        private string _xcc_code;
        private string _xcc_topic;
        private DateTime? _xcc_stime;
        private string _xcc_customervalue;
        private string _xcc_linkman;
        private string _xcc_dutyperson;
        private string _xcc_caretypes;
        private string _xcc_caredetails;
        private string _xcc_customerdetails;
        private string _xcc_remarks;
        private string _xcc_creator;
        private DateTime? _xcc_ctime;
        private string _xcc_mender;
        private DateTime? _xcc_mtime;
        private int? _xcc_del = 0;
        /// <summary>
        /// 
        /// </summary>
        public string XCC_Code
        {
            set { _xcc_code = value; }
            get { return _xcc_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XCC_Topic
        {
            set { _xcc_topic = value; }
            get { return _xcc_topic; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? XCC_Stime
        {
            set { _xcc_stime = value; }
            get { return _xcc_stime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XCC_CustomerValue
        {
            set { _xcc_customervalue = value; }
            get { return _xcc_customervalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XCC_LinkMan
        {
            set { _xcc_linkman = value; }
            get { return _xcc_linkman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XCC_DutyPerson
        {
            set { _xcc_dutyperson = value; }
            get { return _xcc_dutyperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XCC_CareTypes
        {
            set { _xcc_caretypes = value; }
            get { return _xcc_caretypes; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XCC_CareDetails
        {
            set { _xcc_caredetails = value; }
            get { return _xcc_caredetails; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XCC_CustomerDetails
        {
            set { _xcc_customerdetails = value; }
            get { return _xcc_customerdetails; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XCC_Remarks
        {
            set { _xcc_remarks = value; }
            get { return _xcc_remarks; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XCC_Creator
        {
            set { _xcc_creator = value; }
            get { return _xcc_creator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? XCC_CTime
        {
            set { _xcc_ctime = value; }
            get { return _xcc_ctime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XCC_Mender
        {
            set { _xcc_mender = value; }
            get { return _xcc_mender; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? XCC_MTime
        {
            set { _xcc_mtime = value; }
            get { return _xcc_mtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? XCC_Del
        {
            set { _xcc_del = value; }
            get { return _xcc_del; }
        }
        #endregion Model

    }
}

