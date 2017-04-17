using System;
using System.Collections;
namespace KNet.Model
{
    /// <summary>
    /// PB_Products_Brand_Details:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class PB_Products_Brand_Details
    {
        public PB_Products_Brand_Details()
        { }
        #region
        private string _PPBD_ID;
        private string _PPBD_FID;
        private string _PPBD_ProductsBarCode;
        private string _PPBD_BrandName;
        private int _PPBD_IsMainBrand = 0;
        private int _PPBD_BZNumber = 0;
        #endregion
        #region 属性设计器

        /// <summary>
        /// 
        /// </summary>
        public string PPBD_ID
        {
            set { _PPBD_ID = value; }
            get { return _PPBD_ID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PPBD_FID
        {
            set { _PPBD_FID = value; }
            get { return _PPBD_FID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PPBD_ProductsBarCode
        {
            set { _PPBD_ProductsBarCode = value; }
            get { return _PPBD_ProductsBarCode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PPBD_BrandName
        {
            set { _PPBD_BrandName = value; }
            get { return _PPBD_BrandName; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PPBD_IsMainBrand
        {
            set { _PPBD_IsMainBrand = value; }
            get { return _PPBD_IsMainBrand; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PPBD_BZNumber
        {
            set { _PPBD_BZNumber = value; }
            get { return _PPBD_BZNumber; }
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
