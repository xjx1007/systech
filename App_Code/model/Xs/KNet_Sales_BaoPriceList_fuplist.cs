using System;
namespace KNet.Model
{
    /// <summary>
    /// 实体类KNet_Sales_BaoPriceList_fuplist 
    /// </summary>
    [Serializable]
    public class KNet_Sales_BaoPriceList_fuplist
    {
        public KNet_Sales_BaoPriceList_fuplist()
        { }
        #region Model
        private string _id;
        private string _followupno;
        private string _baopriceno;
        private DateTime? _followupdatetime;
        private string _followupstaffno;
        private string _followuptext;
        /// <summary>
        /// 自动ID值
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 洽谈唯一值
        /// </summary>
        public string followupNo
        {
            set { _followupno = value; }
            get { return _followupno; }
        }
        /// <summary>
        /// 报价单唯一值
        /// </summary>
        public string BaoPriceNo
        {
            set { _baopriceno = value; }
            get { return _baopriceno; }
        }
        /// <summary>
        /// 进跟时间
        /// </summary>
        public DateTime? followupDateTime
        {
            set { _followupdatetime = value; }
            get { return _followupdatetime; }
        }
        /// <summary>
        /// 洽谈跟进人唯一值
        /// </summary>
        public string followupStaffNo
        {
            set { _followupstaffno = value; }
            get { return _followupstaffno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string followupText
        {
            set { _followuptext = value; }
            get { return _followuptext; }
        }
        #endregion Model

    }
}

