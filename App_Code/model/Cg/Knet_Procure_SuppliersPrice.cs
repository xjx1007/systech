using System;
namespace KNet.Model
{
    /// <summary>
    /// 实体类Knet_Procure_SuppliersPrice
    /// </summary>
    public class Knet_Procure_SuppliersPrice
    {
        public Knet_Procure_SuppliersPrice()
        { }
        #region Model
        private string _id;
        private string _suppno;
        private string _productsname;
        private string _productsbarcode;
        private string _productspattern;
        private string _productsmaincategory;
        private string _productssmallcategory;
        private string _productsunits;
        private int? _procureminshu;
        private decimal? _procureunitprice;
        private int? _procurestate;
        private DateTime? _procureupdatedatetime;

        private decimal? _Salesprice;

        private decimal? _handprice;
        private string _KPP_Remarks;
        private string _KPP_CgID;
        private string _KPP_IsOrder;
        private string _KPP_Address;
        private int _KPP_Number;
        private int _KPP_State;


        /// <summary>
        /// 建议销售价格
        /// </summary>
        public decimal? Salesprice
        {
            set { _Salesprice = value; }
            get { return _Salesprice; }
        }
        /// <summary>
        /// 自动ID值
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 供应商唯一值
        /// </summary>
        public string SuppNo
        {
            set { _suppno = value; }
            get { return _suppno; }
        }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductsName
        {
            set { _productsname = value; }
            get { return _productsname; }
        }
        /// <summary>
        /// 编码（条形码）（唯一值）
        /// </summary>
        public string ProductsBarCode
        {
            set { _productsbarcode = value; }
            get { return _productsbarcode; }
        }
        /// <summary>
        /// 产品型号
        /// </summary>
        public string ProductsPattern
        {
            set { _productspattern = value; }
            get { return _productspattern; }
        }
        /// <summary>
        /// 主分类
        /// </summary>
        public string ProductsMainCategory
        {
            set { _productsmaincategory = value; }
            get { return _productsmaincategory; }
        }
        /// <summary>
        /// 小分类
        /// </summary>
        public string ProductsSmallCategory
        {
            set { _productssmallcategory = value; }
            get { return _productssmallcategory; }
        }
        /// <summary>
        /// 单位
        /// </summary>
        public string ProductsUnits
        {
            set { _productsunits = value; }
            get { return _productsunits; }
        }
        /// <summary>
        /// 最少采购量
        /// </summary>
        public int? ProcureMinShu
        {
            set { _procureminshu = value; }
            get { return _procureminshu; }
        }
        /// <summary>
        /// 采购单价
        /// </summary>
        public decimal? ProcureUnitPrice
        {
            set { _procureunitprice = value; }
            get { return _procureunitprice; }
        }
        /// <summary>
        /// 采购报价状态（1正常，2失效）
        /// </summary>
        public int? ProcureState
        {
            set { _procurestate = value; }
            get { return _procurestate; }
        }
        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime? ProcureUpdateDateTime
        {
            set { _procureupdatedatetime = value; }
            get { return _procureupdatedatetime; }
        }

        public decimal? HandPrice
        {
            set { _handprice = value; }
            get { return _handprice; }
        }
        public string KPP_Remarks
        {
            set { _KPP_Remarks = value; }
            get { return _KPP_Remarks; }
        }
        public string KPP_CgID
        {
            set { _KPP_CgID = value; }
            get { return _KPP_CgID; }
        }
        public string KPP_IsOrder
        {
            set { _KPP_IsOrder = value; }
            get { return _KPP_IsOrder; }
        }
        public string KPP_Address
        {
            set { _KPP_Address = value; }
            get { return _KPP_Address; }
        }
        public int KPP_Number
        {
            set { _KPP_Number = value; }
            get { return _KPP_Number; }
        }

        public int KPP_State
        {
            set { _KPP_State = value; }
            get { return _KPP_State; }
        }
        #endregion Model

    }
}

