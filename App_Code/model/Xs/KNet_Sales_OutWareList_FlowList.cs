using System;
namespace KNet.Model
{
    /// <summary>
    /// 实体类KNet_Sales_OutWareList_FlowList
    /// </summary>
    [Serializable]
    public class KNet_Sales_OutWareList_FlowList
    {
        public KNet_Sales_OutWareList_FlowList()
        { }
        #region Model
        private string _id;
        private string _followno;
        private string _outwareno;
        private DateTime? _followdatetime;
        private string _followstaffno;
        private string _followtext;
        private bool _followend;
        private string _KDName;
        private string _KDCode;
        private string _KDCodeName;
        private string _State;
        private DateTime? _ReTime;
        private string _ReturnType;
        private int _KSO_ISFH;
        private string _KSO_Isreview;
        private string _KSO_Phone;
        private int _KSO_IsMessage;
        private DateTime? _OldTime;
        private int _KSO_Order=0;
        
        /// <summary>
        /// 自动ID值
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 跟踪唯一值
        /// </summary>
        public string FollowNo
        {
            set { _followno = value; }
            get { return _followno; }
        }
        /// <summary>
        /// 发货单唯一值
        /// </summary>
        public string OutWareNo
        {
            set { _outwareno = value; }
            get { return _outwareno; }
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
        /// 进跟时间
        /// </summary>
        public DateTime? OldTime
        {
            set { _OldTime = value; }
            get { return _OldTime; }
        }
        
        /// <summary>
        /// 跟踪跟进人唯一值
        /// </summary>
        public string FollowStaffNo
        {
            set { _followstaffno = value; }
            get { return _followstaffno; }
        }
        /// <summary>
        /// 跟踪内容
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

        /// <summary>
        /// 跟踪内容
        /// </summary>
        public string KDName
        {
            set { _KDName = value; }
            get { return _KDName; }
        }
        
        /// <summary>
        /// 跟踪内容
        /// </summary>
        public string KDCodeName
        {
            set { _KDCodeName = value; }
            get { return _KDCodeName; }
        }
        
        /// <summary>
        /// 跟踪内容
        /// </summary>
        public string KDCode
        {
            set { _KDCode = value; }
            get { return _KDCode; }
        }

        /// <summary>
        /// 跟踪内容
        /// </summary>
        public string State
        {
            set { _State = value; }
            get { return _State; }
        }
        public DateTime? ReTime
        {
            set { _ReTime = value; }
            get { return _ReTime; }
        }
        /// <summary>
        /// 跟踪内容
        /// </summary>
        public string ReturnType
        {
            set { _ReturnType = value; }
            get { return _ReturnType; }
        }
        /// <summary>
        /// 跟踪内容
        /// </summary>
        public int KSO_ISFH
        {
            set { _KSO_ISFH = value; }
            get { return _KSO_ISFH; }
        }


        public string KSO_Isreview
        {
            set { _KSO_Isreview = value; }
            get { return _KSO_Isreview; }
        }
        
        public string KSO_Phone
        {
            set { _KSO_Phone = value; }
            get { return _KSO_Phone; }
        }

        /// <summary>
        /// 跟踪内容
        /// </summary>
        public int KSO_IsMessage
        {
            set { _KSO_IsMessage = value; }
            get { return _KSO_IsMessage; }
        }

        public int KSO_Order
        {
            set { _KSO_Order = value; }
            get { return _KSO_Order; }
        }
        
        
        #endregion Model

    }
}

