using System;
using System.Collections;
namespace KNet.Model
{
    /// <summary>
    /// Xs_Sales_Quotes:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Xs_Sales_Quotes
    {
        public Xs_Sales_Quotes()
        { }
        #region Model
        private string _xsq_id;
        private string _xsq_code;
        private string _xsq_saleschance;
        private string _xsq_name;
        private string _xsq_step;
        private DateTime? _xsq_stime;
        private string _xsq_customervalue;
        private string _xsq_linkman;
        private string _xsq_dutyperson;
        private string _xsq_payment;
        private string _xsq_remarks;
        private DateTime? _xsq_ctime;
        private string _xsq_creator;
        private string _xsq_mender;
        private string _xsq_mtime;
        private int? _xsq_del = 0;
        private ArrayList _Arr_ProductsList;
        /// <summary>
        /// 
        /// </summary>
        public string XSQ_ID
        {
            set { _xsq_id = value; }
            get { return _xsq_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XSQ_Code
        {
            set { _xsq_code = value; }
            get { return _xsq_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XSQ_SalesChance
        {
            set { _xsq_saleschance = value; }
            get { return _xsq_saleschance; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XSQ_Name
        {
            set { _xsq_name = value; }
            get { return _xsq_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XSQ_Step
        {
            set { _xsq_step = value; }
            get { return _xsq_step; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? XSQ_STime
        {
            set { _xsq_stime = value; }
            get { return _xsq_stime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XSQ_CustomerValue
        {
            set { _xsq_customervalue = value; }
            get { return _xsq_customervalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XSQ_LinkMan
        {
            set { _xsq_linkman = value; }
            get { return _xsq_linkman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XSQ_DutyPerson
        {
            set { _xsq_dutyperson = value; }
            get { return _xsq_dutyperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XSQ_Payment
        {
            set { _xsq_payment = value; }
            get { return _xsq_payment; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XSQ_Remarks
        {
            set { _xsq_remarks = value; }
            get { return _xsq_remarks; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? XSQ_CTime
        {
            set { _xsq_ctime = value; }
            get { return _xsq_ctime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XSQ_Creator
        {
            set { _xsq_creator = value; }
            get { return _xsq_creator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XSQ_Mender
        {
            set { _xsq_mender = value; }
            get { return _xsq_mender; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XSQ_MTime
        {
            set { _xsq_mtime = value; }
            get { return _xsq_mtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? XSQ_Del
        {
            set { _xsq_del = value; }
            get { return _xsq_del; }
        }

        public ArrayList Arr_ProductsList
        {
            set { _Arr_ProductsList = value; }
            get { return _Arr_ProductsList; }
        }
        #endregion Model

    }
}

