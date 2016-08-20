using System;
namespace KNet.Model
{
    /// <summary>
    /// 实体类KNet_Sales_ReturnList_FlowList
    /// </summary>
    [Serializable]
    public class KNet_Sales_ReturnList_FlowList
    {
        public KNet_Sales_ReturnList_FlowList()
        { }
        #region Model
        private string _id;
        private string _followno;
        private string _returnno;
        private DateTime? _followdatetime;
        private string _followstaffno;
        private int? _followprogress;
        private string _followtext;
        private bool _followend;
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
        public string FollowNo
        {
            set { _followno = value; }
            get { return _followno; }
        }
        /// <summary>
        /// 退货单唯一值
        /// </summary>
        public string ReturnNo
        {
            set { _returnno = value; }
            get { return _returnno; }
        }
        /// <summary>
        /// 进跟时间
        /// </summary>
        public DateTime? FollowDateTime
        {
            set { _followdatetime = value; }
            get { return _followdatetime; }
        }
        /// <summary>
        /// 洽谈跟进人唯一值
        /// </summary>
        public string FollowStaffNo
        {
            set { _followstaffno = value; }
            get { return _followstaffno; }
        }
        /// <summary>
        /// 洽谈进度（0新退货申请，1退货洽谈中，2已终止退货，3已退回归库）
        /// </summary>
        public int? FollowProgress
        {
            set { _followprogress = value; }
            get { return _followprogress; }
        }
        /// <summary>
        /// 洽谈内容
        /// </summary>
        public string FollowText
        {
            set { _followtext = value; }
            get { return _followtext; }
        }
        /// <summary>
        /// 是否已结束
        /// </summary>
        public bool FollowEnd
        {
            set { _followend = value; }
            get { return _followend; }
        }
        #endregion Model

    }
}

