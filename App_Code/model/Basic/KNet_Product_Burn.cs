using System;
using System.Collections;
namespace KNet.Model
{
    /// <summary>
    /// KNet_Product_Burn:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class KNet_Product_Burn
    {
        public KNet_Product_Burn()
        { }
        #region 
        private string _KSB_ID;
        private string _KSB_OrderNo;
        private DateTime _KSB_Time;
        private int _KSB_State = 0;
        private string _KSB_Person;
        private string _KSB_Sperson;
        private string _KSB_ProductCode;
        private string _KSB_FileUrl;
        #endregion
        #region 属性设计器

        /// <summary>
        /// 
        /// </summary>
        public string KSB_ID
        {
            set { _KSB_ID = value; }
            get { return _KSB_ID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KSB_ProductCode
        {
            set { _KSB_ProductCode = value; }
            get { return _KSB_ProductCode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KSB_OrderNo
        {
            set { _KSB_OrderNo = value; }
            get { return _KSB_OrderNo; }
        }
        /// <summary>
        /// 附件路径
        /// </summary>
        public string KSB_FileUrl
        {
            set { _KSB_FileUrl = value; }
            get { return _KSB_FileUrl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime KSB_Time
        {
            set { _KSB_Time = value; }
            get { return _KSB_Time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int KSB_State
        {
            set { _KSB_State = value; }
            get { return _KSB_State; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KSB_Person
        {
            set { _KSB_Person = value; }
            get { return _KSB_Person; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KSB_Sperson
        {
            set { _KSB_Sperson = value; }
            get { return _KSB_Sperson; }
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
