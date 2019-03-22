using System;
using System.Collections;
namespace KNet.Model
{
    /// <summary>
    /// Knet_Submitted_Product:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Knet_Submitted_Product
    {
        public Knet_Submitted_Product()
        { }
        #region 
        private string _KSP_ID;
        
        private string _KSP_SID;
       
        private string _KSP_OrderNo;
       
        private string _KSP_SuppNo;
       
        private string _KSP_HouseNo;
       
        private DateTime _KSP_Stime;
        private DateTime _KSP_Time;
        private int _KSP_Rank;
        private ArrayList _Arr_Products;
        private string _KSP_Proposer;
        private string _KSP_AnomalyUrl;
        private string _KSP_AnomalyName;
        private string _KSP_BackUrl;
        private string _KSP_BackName;
        private int _KSP_State;
        private int _KSP_Boss;
        private int _KSP_Prant;
        private string _KSP_UploadUrl;
        private string _KSP_UploadName;
        private string _KSP_Remark;
        private int _KSP_Type;
        private string _KSP_Sproposer;
        #endregion
        #region 属性设计器

        /// <summary>
        /// 
        /// </summary>
        public string KSP_ID
        {
            set { _KSP_ID = value; }
            get { return _KSP_ID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KSP_Sproposer
        {
            set { _KSP_Sproposer = value; }
            get { return _KSP_Sproposer; }
        }
        public int KSP_Prant
        {
            set { _KSP_Prant = value; }
            get { return _KSP_Prant; }
        }
        public int KSP_Type
        {
            set { _KSP_Type = value; }
            get { return _KSP_Type; }
        }
        public string KSP_UploadUrl
        {
            set { _KSP_UploadUrl = value; }
            get { return _KSP_UploadUrl; }
        }
        public string KSP_Remark
        {
            set { _KSP_Remark = value; }
            get { return _KSP_Remark; }
        }
        public string KSP_UploadName
        {
            set { _KSP_UploadName = value; }
            get { return _KSP_UploadName; }
        }
        public string KSP_AnomalyUrl
        {
            set { _KSP_AnomalyUrl = value; }
            get { return _KSP_AnomalyUrl; }
        }
        public string KSP_AnomalyName
        {
            set { _KSP_AnomalyName = value; }
            get { return _KSP_AnomalyName; }
        }
        public string KSP_BackUrl
        {
            set { _KSP_BackUrl = value; }
            get { return _KSP_BackUrl; }
        }
        public string KSP_BackName
        {
            set { _KSP_BackUrl = value; }
            get { return _KSP_BackUrl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KSP_SID
        {
            set { _KSP_SID = value; }
            get { return _KSP_SID; }
        }
      
        /// <summary>
        /// 
        /// </summary>
        public string KSP_OrderNo
        {
            set { _KSP_OrderNo = value; }
            get { return _KSP_OrderNo; }
        }
      
        /// <summary>
        /// 
        /// </summary>
        public string KSP_SuppNo
        {
            set { _KSP_SuppNo = value; }
            get { return _KSP_SuppNo; }
        }
        public ArrayList Arr_Products
        {
            set { _Arr_Products = value; }
            get { return _Arr_Products; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KSP_HouseNo
        {
            set { _KSP_HouseNo = value; }
            get { return _KSP_HouseNo; }
        }
       
        /// <summary>
        /// 
        /// </summary>
        public DateTime KSP_Stime
        {
            set { _KSP_Stime = value; }
            get { return _KSP_Stime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime KSP_Time
        {
            set { _KSP_Time = value; }
            get { return _KSP_Time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int KSP_Rank
        {
            set { _KSP_Rank = value; }
            get { return _KSP_Rank; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KSP_Proposer
        {
            set { _KSP_Proposer = value; }
            get { return _KSP_Proposer; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public int KSP_State
        {
            set { _KSP_State = value; }
            get { return _KSP_State; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int KSP_Boss
        {
            set { _KSP_Boss = value; }
            get { return _KSP_Boss; }
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
