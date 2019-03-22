using System;
namespace KNet.Model
{
   
    [Serializable]
    public class KNet_WareHouse_FuAllocateList_Details
    {
        public KNet_WareHouse_FuAllocateList_Details()
        { }
        #region Model
        private string _id;
        private string _allocateno;
        private string _productsname;
        private string _productsbarcode;
        private string _productspattern;
        private string _productsunits;
        private int? _allocateamount;
        private decimal? _allocateunitprice;
        private decimal? _allocatediscount;
        private decimal? _allocatetotalnet;
        private string _allocateremarks;

        private string _OwnallPID;
        private decimal? _Allocate_WwPrice;
        private decimal? _Allocate_WwMoney;
        private string _KWAD_FaterBarCode;

        private int _KWAD_CPBZNumber;
        private int _KWAD_BZNumber;

        private int _KWAD_BadNumber;
        private string _KWAD_Reason;
        private int _KWAD_AddBadNumber;
        private int _KWAD_SDNumber;
        private int _KWAD_BFNumber;
        private int _KWAD_BLNumber;
        //private string _KWAD_DirectOutNo;

        /// <summary>
        /// 总仓库产品ID
        /// </summary>
        public string OwnallPID
        {
            set { _OwnallPID = value; }
            get { return _OwnallPID; }
        }
        public int KWAD_BLNumber
        {
            set { _KWAD_BLNumber = value; }
            get { return _KWAD_BLNumber; }
        }
       
        public int KWAD_SDNumber
        {
            set { _KWAD_SDNumber = value; }
            get { return _KWAD_SDNumber; }
        }
        public int KWAD_BFNumber
        {
            set { _KWAD_BFNumber = value; }
            get { return _KWAD_BFNumber; }
        }
        //public string KWAD_DirectOutNo
        //{
        //    set { _KWAD_DirectOutNo = value; }
        //    get { return _KWAD_DirectOutNo; }
        //}
        /// <summary>
        /// 自动ID值
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 调拨 单号（唯一性）
        /// </summary>
        public string AllocateNo
        {
            set { _allocateno = value; }
            get { return _allocateno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProductsName
        {
            set { _productsname = value; }
            get { return _productsname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProductsBarCode
        {
            set { _productsbarcode = value; }
            get { return _productsbarcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProductsPattern
        {
            set { _productspattern = value; }
            get { return _productspattern; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProductsUnits
        {
            set { _productsunits = value; }
            get { return _productsunits; }
        }
        /// <summary>
        /// 调拨 数量
        /// </summary>
        public int? AllocateAmount
        {
            set { _allocateamount = value; }
            get { return _allocateamount; }
        }
        /// <summary>
        /// 调拨 单价格
        /// </summary>
        public decimal? AllocateUnitPrice
        {
            set { _allocateunitprice = value; }
            get { return _allocateunitprice; }
        }
        /// <summary>
        /// 调拨 计调价格
        /// </summary>
        public decimal? AllocateDiscount
        {
            set { _allocatediscount = value; }
            get { return _allocatediscount; }
        }
        /// <summary>
        /// 调拨 净值金额
        /// </summary>
        public decimal? AllocateTotalNet
        {
            set { _allocatetotalnet = value; }
            get { return _allocatetotalnet; }
        }
        /// <summary>
        /// 调拨 备注
        /// </summary>
        public string AllocateRemarks
        {
            set { _allocateremarks = value; }
            get { return _allocateremarks; }
        }
        /// <summary>
        /// 调拨 单价格
        /// </summary>
        public decimal? Allocate_WwPrice
        {
            set { _Allocate_WwPrice = value; }
            get { return _Allocate_WwPrice; }
        }
        /// <summary>
        /// 调拨 单价格
        /// </summary>
        public decimal? Allocate_WwMoney
        {
            set { _Allocate_WwMoney = value; }
            get { return _Allocate_WwMoney; }
        }

        /// <summary>
        /// 调拨 单价格
        /// </summary>
        public string KWAD_FaterBarCode
        {
            set { _KWAD_FaterBarCode = value; }
            get { return _KWAD_FaterBarCode; }
        }


        public int KWAD_CPBZNumber
        {
            set { _KWAD_CPBZNumber = value; }
            get { return _KWAD_CPBZNumber; }
        }

        public int KWAD_BZNumber
        {
            set { _KWAD_BZNumber = value; }
            get { return _KWAD_BZNumber; }
        }

        public int KWAD_BadNumber
        {
            set { _KWAD_BadNumber = value; }
            get { return _KWAD_BadNumber; }
        }

        public int KWAD_AddBadNumber
        {
            set { _KWAD_AddBadNumber = value; }
            get { return _KWAD_AddBadNumber; }
        }
        public string KWAD_Reason
        {
            set { _KWAD_Reason = value; }
            get { return _KWAD_Reason; }
        }
        #endregion Model

    }
}

