using System;
namespace KNet.Model
{
    /// <summary>
    /// 实体类KNet_Sales_BaoPriceList_fupsetup
    /// </summary>
    [Serializable]
    public class KNet_Sales_BaoPriceList_fupsetup
    {
        public KNet_Sales_BaoPriceList_fupsetup()
        { }
        #region Model
        private string _id;
        private string _talkcom;
        private string _staffno;
        private int? _talkpai;
        /// <summary>
        /// 自动ID值
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TalkCom
        {
            set { _talkcom = value; }
            get { return _talkcom; }
        }
        /// <summary>
        /// 员工值
        /// </summary>
        public string StaffNo
        {
            set { _staffno = value; }
            get { return _staffno; }
        }
        /// <summary>
        /// 排序值
        /// </summary>
        public int? TalkPai
        {
            set { _talkpai = value; }
            get { return _talkpai; }
        }
        #endregion Model

    }
}


