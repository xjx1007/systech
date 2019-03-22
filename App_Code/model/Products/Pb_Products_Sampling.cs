using System;
using System.Collections;
namespace KNet.Model
{
    /// <summary>
    /// KNet_Sampling_List:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class KNet_Sampling_List
    {
        public KNet_Sampling_List()
        { }
        #region 
        private string _ID;
        private string _ReID;
        private string _SampleName;
        private int _Number = 0;
        private string _ProjectGroup;
        private string _Packaging;
        private string _UploadFile;
        private decimal _Price;
        private string _BuyRank;
        private string _HouseClass;
        private DateTime _STime;
        private DateTime _EndTime;
        private string _Proposer;
        private string _Remark;
        private string _InState;
        private string _BuyState;
        private string _AuditState;
        #endregion
        #region 属性设计器

        /// <summary>
        /// 
        /// </summary>
        public string ID
        {
            set { _ID = value; }
            get { return _ID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ReID
        {
            set { _ReID = value; }
            get { return _ReID; }
        }
        public string HouseClass
        {
            set { _HouseClass = value; }
            get { return _HouseClass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SampleName
        {
            set { _SampleName = value; }
            get { return _SampleName; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Number
        {
            set { _Number = value; }
            get { return _Number; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProjectGroup
        {
            set { _ProjectGroup = value; }
            get { return _ProjectGroup; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Packaging
        {
            set { _Packaging = value; }
            get { return _Packaging; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UploadFile
        {
            set { _UploadFile = value; }
            get { return _UploadFile; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Price
        {
            set { _Price = value; }
            get { return _Price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BuyRank
        {
            set { _BuyRank = value; }
            get { return _BuyRank; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime STime
        {
            set { _STime = value; }
            get { return _STime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime EndTime
        {
            set { _EndTime = value; }
            get { return _EndTime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Proposer
        {
            set { _Proposer = value; }
            get { return _Proposer; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _Remark = value; }
            get { return _Remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string InState
        {
            set { _InState = value; }
            get { return _InState; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BuyState
        {
            set { _BuyState = value; }
            get { return _BuyState; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AuditState
        {
            set { _AuditState = value; }
            get { return _AuditState; }
        }
        #endregion
        #region 附加信息

        private string Temp;
        public string getTemp()
        {
            return Temp;
        }
        public void setTemp(string Temp)
        {
            this.Temp = Temp;
        }
        private ArrayList _Arr_Detail;
        public ArrayList Arr_Detail
        {
            set { _Arr_Detail = value; }

            get { return _Arr_Detail; }
        }
        #endregion
    }
}
