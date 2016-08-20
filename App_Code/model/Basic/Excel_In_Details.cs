using System;
using System.Collections;
namespace KNet.Model
{
    /// <summary>
    /// Excel_In_Details:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Excel_In_Details
    {
        public Excel_In_Details()
        { }
        #region
        private string _EID_ID;
        private string _EID_FID;
        private int _EID_YLine = 0;
        private string _EID_Name;
        private string _EID_ColName;
        #endregion
        #region 属性设计器

        /// <summary>
        /// 
        /// </summary>
        public string EID_ID
        {
            set { _EID_ID = value; }
            get { return _EID_ID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EID_FID
        {
            set { _EID_FID = value; }
            get { return _EID_FID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int EID_YLine
        {
            set { _EID_YLine = value; }
            get { return _EID_YLine; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EID_Name
        {
            set { _EID_Name = value; }
            get { return _EID_Name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EID_ColName
        {
            set { _EID_ColName = value; }
            get { return _EID_ColName; }
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
