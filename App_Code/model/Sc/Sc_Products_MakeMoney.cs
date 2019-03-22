using System;
using System.Collections;
namespace KNet.Model
{
    /// <summary>
    /// Sc_Products_MakeMoney:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Sc_Products_MakeMoney
    {
        public Sc_Products_MakeMoney()
        { }
        #region 
        private string _ID;
        
        private DateTime _Stime;
        private decimal _MakeMoney;
        private decimal _PeopleMoney;
        private decimal _ElseMaterialsMoney;
        private decimal _UnitsMakeMoney;
        private decimal _UnitsPeopleMoney;
        private decimal _UnitsElseMaterialsMoney;
        private decimal _CountTime;
        private decimal _ProcessMoneyNotIncluding;
        private decimal _MaterialsMoneyNotIncluding;
        private decimal _DirectMaterialsMoneyNotIncluding;
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
      
        public DateTime Stime
        {
            set { _Stime = value; }
            get { return _Stime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal MakeMoney
        {
            set { _MakeMoney = value; }
            get { return _MakeMoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal PeopleMoney
        {
            set { _PeopleMoney = value; }
            get { return _PeopleMoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal ElseMaterialsMoney
        {
            set { _ElseMaterialsMoney = value; }
            get { return _ElseMaterialsMoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal UnitsMakeMoney
        {
            set { _UnitsMakeMoney = value; }
            get { return _UnitsMakeMoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal UnitsPeopleMoney
        {
            set { _UnitsPeopleMoney = value; }
            get { return _UnitsPeopleMoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal UnitsElseMaterialsMoney
        {
            set { _UnitsElseMaterialsMoney = value; }
            get { return _UnitsElseMaterialsMoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal CountTime
        {
            set { _CountTime = value; }
            get { return _CountTime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal ProcessMoneyNotIncluding
        {
            set { _ProcessMoneyNotIncluding = value; }
            get { return _ProcessMoneyNotIncluding; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal MaterialsMoneyNotIncluding
        {
            set { _MaterialsMoneyNotIncluding = value; }
            get { return _MaterialsMoneyNotIncluding; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal DirectMaterialsMoneyNotIncluding
        {
            set { _DirectMaterialsMoneyNotIncluding = value; }
            get { return _DirectMaterialsMoneyNotIncluding; }
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
