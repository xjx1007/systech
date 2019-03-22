using System;
using System.Collections;
namespace KNet.Model
{
    /// <summary>
    /// Knet_Sampling_OpenBilling:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Knet_Sampling_OpenBilling
    {
        public Knet_Sampling_OpenBilling()
        { }
        #region 
        private string _ID;
       
        private string _YID;
        
        private string _ReID;
       
        private string _SamplingName;
       
        private int _Number;
        private string _Department;
      
        private decimal _Price;
        private string _Supplier;
       
        private DateTime _STime;
        private string _Proposer;
       
        private string _Remark;
        private string _HouseNo;
        private ArrayList _Arr_ProductsList;
        private string _RState;
        private string _ProjectGroup;
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
        public string RState
        {
            set { _RState = value; }
            get { return _RState; }

        }
        public string ProjectGroup
        {
            set { _ProjectGroup = value; }
            get { return _ProjectGroup; }

        }

        public string HouseNo
        {
            set { _HouseNo = value; }
            get { return _HouseNo; }
        }
        public ArrayList Arr_ProductsList
        {
            set { _Arr_ProductsList = value; }
            get { return _Arr_ProductsList; }
        }
        /// <summary>
        /// 
        /// </summary>

        /// <summary>
        /// 
        /// </summary>
        public string YID
        {
            set { _YID = value; }
            get { return _YID; }
        }
      
        /// <summary>
        /// 
        /// </summary>
        public string ReID
        {
            set { _ReID = value; }
            get { return _ReID; }
        }
        
        
        /// <summary>
        /// 
        /// </summary>
        public string SamplingName
        {
            set { _SamplingName = value; }
            get { return _SamplingName; }
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
        public string Department
        {
            set { _Department = value; }
            get { return _Department; }
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
        public string Supplier
        {
            set { _Supplier = value; }
            get { return _Supplier; }
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
