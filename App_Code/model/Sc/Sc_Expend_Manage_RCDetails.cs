using System;
using System.Collections;
namespace KNet.Model
{
    /// <summary>
    /// Sc_Expend_Manage_RCDetails:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Sc_Expend_Manage_RCDetails
    {
        public Sc_Expend_Manage_RCDetails()
        { }
        #region 
        private string _SER_ID;
        private string _SER_SEMID;
        private string _SER_OrderDetailID;
        private string _SER_ProductsBarCode;
        private int _SER_ScNumber = 0;
        private decimal _SER_ScPrice;
        private decimal _SER_ScMoney;
        private string _SER_HouseNo;
        private decimal _SER_ScHandMoney;
        private decimal _SER_ScHandPrice;
        private decimal _SER_MaterMoney;
        private decimal _SER_MaterPrice;
        private decimal _SER_ScHandFaxMoney;
        private decimal _SER_MaterFaxMoney;
        private decimal _SER_ScNotHandMoney;
        private decimal _SER_ScNotHandPrice;
        private decimal _SER_NotMaterMoney;
        private decimal _SER_NotMaterPrice;
        private decimal _SER_DirectMaterPrice;
        private decimal _SER_DirectMaterMoney;
        private decimal _SER_UnitManHouse;
        private decimal _SER_CountManHouse;
        private decimal _SER_CountMakeMoney;
        private decimal _SER_UnitMakePrice;
        #endregion
        #region 属性设计器

        /// <summary>
        /// 
        /// </summary>
        public string SER_ID
        {
            set { _SER_ID = value; }
            get { return _SER_ID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SER_SEMID
        {
            set { _SER_SEMID = value; }
            get { return _SER_SEMID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SER_OrderDetailID
        {
            set { _SER_OrderDetailID = value; }
            get { return _SER_OrderDetailID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SER_ProductsBarCode
        {
            set { _SER_ProductsBarCode = value; }
            get { return _SER_ProductsBarCode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SER_ScNumber
        {
            set { _SER_ScNumber = value; }
            get { return _SER_ScNumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal SER_ScPrice
        {
            set { _SER_ScPrice = value; }
            get { return _SER_ScPrice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal SER_ScMoney
        {
            set { _SER_ScMoney = value; }
            get { return _SER_ScMoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SER_HouseNo
        {
            set { _SER_HouseNo = value; }
            get { return _SER_HouseNo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal SER_ScHandMoney
        {
            set { _SER_ScHandMoney = value; }
            get { return _SER_ScHandMoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal SER_ScHandPrice
        {
            set { _SER_ScHandPrice = value; }
            get { return _SER_ScHandPrice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal SER_MaterMoney
        {
            set { _SER_MaterMoney = value; }
            get { return _SER_MaterMoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal SER_MaterPrice
        {
            set { _SER_MaterPrice = value; }
            get { return _SER_MaterPrice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal SER_ScHandFaxMoney
        {
            set { _SER_ScHandFaxMoney = value; }
            get { return _SER_ScHandFaxMoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal SER_MaterFaxMoney
        {
            set { _SER_MaterFaxMoney = value; }
            get { return _SER_MaterFaxMoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal SER_ScNotHandMoney
        {
            set { _SER_ScNotHandMoney = value; }
            get { return _SER_ScNotHandMoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal SER_ScNotHandPrice
        {
            set { _SER_ScNotHandPrice = value; }
            get { return _SER_ScNotHandPrice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal SER_NotMaterMoney
        {
            set { _SER_NotMaterMoney = value; }
            get { return _SER_NotMaterMoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal SER_NotMaterPrice
        {
            set { _SER_NotMaterPrice = value; }
            get { return _SER_NotMaterPrice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal SER_DirectMaterPrice
        {
            set { _SER_DirectMaterPrice = value; }
            get { return _SER_DirectMaterPrice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal SER_DirectMaterMoney
        {
            set { _SER_DirectMaterMoney = value; }
            get { return _SER_DirectMaterMoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal SER_UnitManHouse
        {
            set { _SER_UnitManHouse = value; }
            get { return _SER_UnitManHouse; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal SER_CountManHouse
        {
            set { _SER_CountManHouse = value; }
            get { return _SER_CountManHouse; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal SER_CountMakeMoney
        {
            set { _SER_CountMakeMoney = value; }
            get { return _SER_CountMakeMoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal SER_UnitMakePrice
        {
            set { _SER_UnitMakePrice = value; }
            get { return _SER_UnitMakePrice; }
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
