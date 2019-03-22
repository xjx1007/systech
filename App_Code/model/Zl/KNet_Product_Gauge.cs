using System;
using System.Collections;
namespace KNet.Model
{
    /// <summary>
    /// KNet_Product_Gauge:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class KNet_Product_Gauge
    {
        public KNet_Product_Gauge()
        { }
        #region 
        private string _KPG_ID;
        private string _KPG_KID;
        private string _KPG_Name;
        private int _KPG_Type = 0;
        private int _KPG_Number = 0;
        private string _KPG_UploadUrl;
        private string _KPG_UploadName;
        private string _KPG_ProductCode;
        private DateTime _KPG_Time;
        private string _KPG_Person;
        private string _KPG_SuppNo;
        private string _KPG_Text;
        #endregion
        #region 属性设计器

        /// <summary>
        /// 
        /// </summary>
        public string KPG_ID
        {
            set { _KPG_ID = value; }
            get { return _KPG_ID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KPG_SuppNo
        {
            set { _KPG_SuppNo = value; }
            get { return _KPG_SuppNo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KPG_Text
        {
            set { _KPG_Text = value; }
            get { return _KPG_Text; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KPG_KID
        {
            set { _KPG_KID = value; }
            get { return _KPG_KID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KPG_Name
        {
            set { _KPG_Name = value; }
            get { return _KPG_Name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int KPG_Type
        {
            set { _KPG_Type = value; }
            get { return _KPG_Type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int KPG_Number
        {
            set { _KPG_Number = value; }
            get { return _KPG_Number; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KPG_UploadUrl
        {
            set { _KPG_UploadUrl = value; }
            get { return _KPG_UploadUrl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KPG_UploadName
        {
            set { _KPG_UploadName = value; }
            get { return _KPG_UploadName; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KPG_ProductCode
        {
            set { _KPG_ProductCode = value; }
            get { return _KPG_ProductCode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime KPG_Time
        {
            set { _KPG_Time = value; }
            get { return _KPG_Time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KPG_Person
        {
            set { _KPG_Person = value; }
            get { return _KPG_Person; }
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
