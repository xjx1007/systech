using System;
using System.Collections;
namespace KNet.Model
{
    /// <summary>
    /// KNet_WareHouse_AllocateList_CPDetails:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class KNet_WareHouse_AllocateList_CPDetails
    {
        public KNet_WareHouse_AllocateList_CPDetails()
        { }
        #region
        private string _KWAC_ID;
        private string _KWAC_AllocateNo;
        private string _KWAC_OrderNoID;
        private int _KWAC_Number = 0;
        private string _KWAC_Creator;
        private DateTime _KWAC_CTime;
        #endregion
        #region 属性设计器

        /// <summary>
        /// 
        /// </summary>
        public string KWAC_ID
        {
            set { _KWAC_ID = value; }
            get { return _KWAC_ID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KWAC_AllocateNo
        {
            set { _KWAC_AllocateNo = value; }
            get { return _KWAC_AllocateNo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KWAC_OrderNoID
        {
            set { _KWAC_OrderNoID = value; }
            get { return _KWAC_OrderNoID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int KWAC_Number
        {
            set { _KWAC_Number = value; }
            get { return _KWAC_Number; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KWAC_Creator
        {
            set { _KWAC_Creator = value; }
            get { return _KWAC_Creator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime KWAC_CTime
        {
            set { _KWAC_CTime = value; }
            get { return _KWAC_CTime; }
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
