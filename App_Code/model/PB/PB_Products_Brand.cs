using System;
using System.Collections;
namespace KNet.Model
{
    /// <summary>
    /// PB_Products_Brand:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class PB_Products_Brand
    {
        public PB_Products_Brand()
        { }
        #region
        private string _PPB_ID;
        private string _PPB_BrandName;
        private int _PPB_IsMainBrand = 0;
        private string _PPB_Remarks;
        private DateTime _PPB_CTime;
        private string _PPB_Creator;
        private DateTime _PPB_MTime;
        private string _PPB_Mender;
        private int _PPB_Del = 0;
        #endregion
        #region 属性设计器

        /// <summary>
        /// 
        /// </summary>
        public string PPB_ID
        {
            set { _PPB_ID = value; }
            get { return _PPB_ID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PPB_BrandName
        {
            set { _PPB_BrandName = value; }
            get { return _PPB_BrandName; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PPB_IsMainBrand
        {
            set { _PPB_IsMainBrand = value; }
            get { return _PPB_IsMainBrand; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PPB_Remarks
        {
            set { _PPB_Remarks = value; }
            get { return _PPB_Remarks; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime PPB_CTime
        {
            set { _PPB_CTime = value; }
            get { return _PPB_CTime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PPB_Creator
        {
            set { _PPB_Creator = value; }
            get { return _PPB_Creator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime PPB_MTime
        {
            set { _PPB_MTime = value; }
            get { return _PPB_MTime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PPB_Mender
        {
            set { _PPB_Mender = value; }
            get { return _PPB_Mender; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PPB_Del
        {
            set { _PPB_Del = value; }
            get { return _PPB_Del; }
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
