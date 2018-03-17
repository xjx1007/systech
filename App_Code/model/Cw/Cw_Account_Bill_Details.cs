using System;
namespace KNet.Model
{
    /// <summary>
    /// Cw_Account_Bill_Details:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Cw_Account_Bill_Details
    {
        public Cw_Account_Bill_Details()
        { }
        #region Model
        private string _cad_id;
        private string _cad_caaid;
        private string _cad_outno;
        private string _cad_contractno;
        private string _cad_fid;
        private string _cad_productsbarcode;
        private decimal? _cad_number;
        private decimal? _cad_price;
        private decimal? _cad_money;
        private string _cad_remarks;
        /// <summary>
        /// 
        /// </summary>
        public string CAD_ID
        {
            set { _cad_id = value; }
            get { return _cad_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAD_CAAID
        {
            set { _cad_caaid = value; }
            get { return _cad_caaid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAD_OutNo
        {
            set { _cad_outno = value; }
            get { return _cad_outno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAD_ContractNo
        {
            set { _cad_contractno = value; }
            get { return _cad_contractno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAD_FID
        {
            set { _cad_fid = value; }
            get { return _cad_fid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAD_ProductsBarCode
        {
            set { _cad_productsbarcode = value; }
            get { return _cad_productsbarcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CAD_Number
        {
            set { _cad_number = value; }
            get { return _cad_number; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CAD_Price
        {
            set { _cad_price = value; }
            get { return _cad_price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CAD_Money
        {
            set { _cad_money = value; }
            get { return _cad_money; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CAD_Remarks
        {
            set { _cad_remarks = value; }
            get { return _cad_remarks; }
        }
        #endregion Model

    }
}

