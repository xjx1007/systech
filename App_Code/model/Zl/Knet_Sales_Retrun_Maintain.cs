using System;
using System.Collections;
namespace KNet.Model
{
    /// <summary>
    /// Knet_Sales_Retrun_Maintain:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Knet_Sales_Retrun_Maintain
    {
        public Knet_Sales_Retrun_Maintain()
        { }
        #region 
        private string _KSM_ID;
        private string _KSM_MID;
        private DateTime _KSM_Time;
        private int _KSM_Type = 0;
        private int _KSM_Urgency = 0;
        private string _KSM_OrderNo;
        private int _KSM_SpTime;
        private string _KSM_SuppNo;
        private string _KSM_LinkMan;
        private string _KSM_Product;
        private string _KSM_DutyMan;
        private DateTime _KSM_FindTime;
        private int _KSM_Number = 0;
        private string _KSM_Text;
        private string _KSM_WUploadName;
        private string _KSM_WUploadUrl;
        private DateTime _KSM_WTime;
        private string _KSM_WText;
        private int _KSM_WResult = 0;
        private string _KSM_KUploadName;
        private string _KSM_KUploadUrl;
        private DateTime _KSM_KTime;
        private string _KSM_KText;
        private string _KSM_K8DUploadName;
        private string _KSM_K8DUploadUrl;
        private int _KSM_State = 0;
        private int _KSM_DState = 0;
        private string _KSM_ProductName;
        private ArrayList _Arr_Products;
        #endregion
        #region 属性设计器

        public ArrayList Arr_Products
        {
            set { _Arr_Products = value; }
            get { return _Arr_Products; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KSM_ID
        {
            set { _KSM_ID = value; }
            get { return _KSM_ID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KSM_MID
        {
            set { _KSM_MID = value; }
            get { return _KSM_MID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime KSM_Time
        {
            set { _KSM_Time = value; }
            get { return _KSM_Time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int KSM_Type
        {
            set { _KSM_Type = value; }
            get { return _KSM_Type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int KSM_Urgency
        {
            set { _KSM_Urgency = value; }
            get { return _KSM_Urgency; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KSM_OrderNo
        {
            set { _KSM_OrderNo = value; }
            get { return _KSM_OrderNo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int KSM_SpTime
        {
            set { _KSM_SpTime = value; }
            get { return _KSM_SpTime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KSM_SuppNo
        {
            set { _KSM_SuppNo = value; }
            get { return _KSM_SuppNo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KSM_LinkMan
        {
            set { _KSM_LinkMan = value; }
            get { return _KSM_LinkMan; }
        }
        public string KSM_ProductName
        {
            set { _KSM_ProductName = value; }
            get { return _KSM_ProductName; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KSM_Product
        {
            set { _KSM_Product = value; }
            get { return _KSM_Product; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KSM_DutyMan
        {
            set { _KSM_DutyMan = value; }
            get { return _KSM_DutyMan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime KSM_FindTime
        {
            set { _KSM_FindTime = value; }
            get { return _KSM_FindTime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int KSM_Number
        {
            set { _KSM_Number = value; }
            get { return _KSM_Number; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KSM_Text
        {
            set { _KSM_Text = value; }
            get { return _KSM_Text; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KSM_WUploadName
        {
            set { _KSM_WUploadName = value; }
            get { return _KSM_WUploadName; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KSM_WUploadUrl
        {
            set { _KSM_WUploadUrl = value; }
            get { return _KSM_WUploadUrl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime KSM_WTime
        {
            set { _KSM_WTime = value; }
            get { return _KSM_WTime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KSM_WText
        {
            set { _KSM_WText = value; }
            get { return _KSM_WText; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int KSM_WResult
        {
            set { _KSM_WResult = value; }
            get { return _KSM_WResult; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KSM_KUploadName
        {
            set { _KSM_KUploadName = value; }
            get { return _KSM_KUploadName; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KSM_KUploadUrl
        {
            set { _KSM_KUploadUrl = value; }
            get { return _KSM_KUploadUrl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime KSM_KTime
        {
            set { _KSM_KTime = value; }
            get { return _KSM_KTime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KSM_KText
        {
            set { _KSM_KText = value; }
            get { return _KSM_KText; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KSM_K8DUploadName
        {
            set { _KSM_K8DUploadName = value; }
            get { return _KSM_K8DUploadName; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KSM_K8DUploadUrl
        {
            set { _KSM_K8DUploadUrl = value; }
            get { return _KSM_K8DUploadUrl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int KSM_State
        {
            set { _KSM_State = value; }
            get { return _KSM_State; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int KSM_DState
        {
            set { _KSM_DState = value; }
            get { return _KSM_DState; }
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
