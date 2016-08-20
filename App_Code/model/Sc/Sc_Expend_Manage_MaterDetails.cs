using System;
namespace KNet.Model
{
    /// <summary>
    /// Sc_Expend_Manage_MaterDetails:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Sc_Expend_Manage_MaterDetails
    {
        public Sc_Expend_Manage_MaterDetails()
        { }
        #region Model
        private string _sed_id;
        private string _sed_semid;
        private string _sed_productsbarcode;
        private string _sed_houseno;
        private int? _sed_rknumber;
        private decimal? _sed_rkprice;
        private decimal? _sed_rkmoney;
        private DateTime? _sed_rktime;
        private string _sed_rkperson;
        private int? _sed_type = 0;
        private string _sed_remarks;
        private string _SED_FromHouseNo;
        private string _SED_Code;
        private decimal? _sed_WwMoney;
        private decimal? _sed_WwPrice;
        /// <summary>
        /// 
        /// </summary>
        public string SED_ID
        {
            set { _sed_id = value; }
            get { return _sed_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SED_SEMID
        {
            set { _sed_semid = value; }
            get { return _sed_semid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SED_ProductsBarCode
        {
            set { _sed_productsbarcode = value; }
            get { return _sed_productsbarcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SED_HouseNo
        {
            set { _sed_houseno = value; }
            get { return _sed_houseno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SED_RkNumber
        {
            set { _sed_rknumber = value; }
            get { return _sed_rknumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SED_RkPrice
        {
            set { _sed_rkprice = value; }
            get { return _sed_rkprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SED_RkMoney
        {
            set { _sed_rkmoney = value; }
            get { return _sed_rkmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? SED_RkTime
        {
            set { _sed_rktime = value; }
            get { return _sed_rktime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SED_RkPerson
        {
            set { _sed_rkperson = value; }
            get { return _sed_rkperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SED_Type
        {
            set { _sed_type = value; }
            get { return _sed_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SED_Remarks
        {
            set { _sed_remarks = value; }
            get { return _sed_remarks; }
        }
        public string SED_FromHouseNo
        {
            set { _SED_FromHouseNo = value; }
            get { return _SED_FromHouseNo; }
        }
        public string SED_Code
        {
            set { _SED_Code = value; }
            get { return _SED_Code; }
        }

        public decimal? SED_WwMoney
        {
            set { _sed_WwMoney = value; }
            get { return _sed_WwMoney; }
        }
        public decimal? SED_WwPrice
        {
            set { _sed_WwPrice = value; }
            get { return _sed_WwPrice; }
        }
        #endregion Model

    }
}

