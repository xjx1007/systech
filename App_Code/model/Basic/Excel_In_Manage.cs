using System;
using System.Collections;
namespace KNet.Model
{
    /// <summary>
    /// Excel_In_Manage:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Excel_In_Manage
    {
        public Excel_In_Manage()
        { }
        #region
        private string _EIM_ID;
        private string _EIM_FID;
        private string _EIM_Type;
        private string _EIM_Name;
        private string _EIM_Details1;
        private string _EIM_Details2;
        private string _EIM_Details3;
        private string _EIM_Details4;
        private string _EIM_Details5;
        private string _EIM_Details6;
        private string _EIM_Details7;
        #endregion
        #region 属性设计器

        /// <summary>
        /// 
        /// </summary>
        public string EIM_ID
        {
            set { _EIM_ID = value; }
            get { return _EIM_ID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EIM_FID
        {
            set { _EIM_FID = value; }
            get { return _EIM_FID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EIM_Type
        {
            set { _EIM_Type = value; }
            get { return _EIM_Type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EIM_Name
        {
            set { _EIM_Name = value; }
            get { return _EIM_Name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EIM_Details1
        {
            set { _EIM_Details1 = value; }
            get { return _EIM_Details1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EIM_Details2
        {
            set { _EIM_Details2 = value; }
            get { return _EIM_Details2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EIM_Details3
        {
            set { _EIM_Details3 = value; }
            get { return _EIM_Details3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EIM_Details4
        {
            set { _EIM_Details4 = value; }
            get { return _EIM_Details4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EIM_Details5
        {
            set { _EIM_Details5 = value; }
            get { return _EIM_Details5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EIM_Details6
        {
            set { _EIM_Details6 = value; }
            get { return _EIM_Details6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EIM_Details7
        {
            set { _EIM_Details7 = value; }
            get { return _EIM_Details7; }
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
