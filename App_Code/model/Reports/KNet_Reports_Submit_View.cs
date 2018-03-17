using System;
namespace KNet.Model
{
    /// <summary>
    /// KNet_Reports_Submit_View:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class KNet_Reports_Submit_View
    {
        public KNet_Reports_Submit_View()
        { }
        #region Model
        private string _krv_id;
        private string _krv_submitid;
        private string _krv_fatherid;
        private string _krv_remarks;
        private string _krv_person;
        private DateTime? _krv_ctime;
        private string _krv_creator;
        private int? _krv_del = 0;
        /// <summary>
        /// 
        /// </summary>
        public string KRV_ID
        {
            set { _krv_id = value; }
            get { return _krv_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KRV_SubmitID
        {
            set { _krv_submitid = value; }
            get { return _krv_submitid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KRV_FatherID
        {
            set { _krv_fatherid = value; }
            get { return _krv_fatherid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KRV_Remarks
        {
            set { _krv_remarks = value; }
            get { return _krv_remarks; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KRV_Person
        {
            set { _krv_person = value; }
            get { return _krv_person; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? KRV_CTime
        {
            set { _krv_ctime = value; }
            get { return _krv_ctime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KRV_Creator
        {
            set { _krv_creator = value; }
            get { return _krv_creator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? KRV_Del
        {
            set { _krv_del = value; }
            get { return _krv_del; }
        }
        #endregion Model

    }
}

