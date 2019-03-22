using System;
using System.Collections;
namespace KNet.Model
{
    /// <summary>
    /// KNet_Product_Gauge_InOut:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class KNet_Product_Gauge_InOut
    {
        public KNet_Product_Gauge_InOut()
        { }
        #region 
        private string _ID;
        private string _KPI_SID;
        private string _KPI_Code;
        private int _KPI_Number = 0;
        private string _KPI_UseFrom;
        private string _KPI_UserIn;
        private int _KPI_InOut = 0;
        private string _KPI_Person;
        private int _KPI_Type = 0;
        private DateTime _KPI_Time;
        private string _KPI_Text;
        private int _KPI_State;
        private int _KPI_BadNumber;
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
        public string KPI_SID
        {
            set { _KPI_SID = value; }
            get { return _KPI_SID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int KPI_BadNumber
        {
            set { _KPI_BadNumber = value; }
            get { return _KPI_BadNumber; }
        }
        public int KPI_State
        {
            set { _KPI_State = value; }
            get { return _KPI_State; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KPI_Code
        {
            set { _KPI_Code = value; }
            get { return _KPI_Code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int KPI_Number
        {
            set { _KPI_Number = value; }
            get { return _KPI_Number; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KPI_UseFrom
        {
            set { _KPI_UseFrom = value; }
            get { return _KPI_UseFrom; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KPI_UserIn
        {
            set { _KPI_UserIn = value; }
            get { return _KPI_UserIn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int KPI_InOut
        {
            set { _KPI_InOut = value; }
            get { return _KPI_InOut; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KPI_Person
        {
            set { _KPI_Person = value; }
            get { return _KPI_Person; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int KPI_Type
        {
            set { _KPI_Type = value; }
            get { return _KPI_Type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime KPI_Time
        {
            set { _KPI_Time = value; }
            get { return _KPI_Time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KPI_Text
        {
            set { _KPI_Text = value; }
            get { return _KPI_Text; }
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
