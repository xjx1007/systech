using System;
namespace KNet.Model
{
    /// <summary>
    /// 实体类KNet_Sales_ContractList_Details 
    /// </summary>
    [Serializable]
    public class KNet_Sales_ContractList_Details
    {
        public KNet_Sales_ContractList_Details()
        { }
        #region Model
        private string _id;
        private string _contractno;
        private string _productsname;
        private string _productsbarcode;
        private string _productspattern;
        private string _productsunits;
        private int? _contractamount;
        private decimal? _contractunitprice;
        private decimal? _contractdiscount;
        private decimal? _contracttotalnet;
        private decimal? _contract_salesunitprice;
        private decimal? _contract_salesdiscount;
        private decimal? _contract_salestotalnet;
        private string _contractremarks;
        private int? _contractreceiving;
        private string _KSD_OrderNumber;
        private string _KSD_MaterNumber;
        private int _KSC_BNumber;
        private string _OwnallPID;
        private int _KSC_OrderBNumber;

        private string _KSD_IsFollow;
        private string _KSD_PlanNumber;

        private string _KSD_MaterPattern;
        private string _KSD_XCMDID;

        private int _KSD_HxNumber;
        private int _KSD_HxState;

        /// <summary>
        /// 总仓库产品唯一值
        /// </summary>
        public string OwnallPID
        {
            set { _OwnallPID = value; }
            get { return _OwnallPID; }

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
        /// 关联-----合同编号
        /// </summary>
        public string ContractNo
        {
            set { _contractno = value; }
            get { return _contractno; }
        }
        /// <summary>
        /// 合同明细---产品名称
        /// </summary>
        public string ProductsName
        {
            set { _productsname = value; }
            get { return _productsname; }
        }
        /// <summary>
        /// 合同明细---编码（条形码）（唯一值）
        /// </summary>
        public string ProductsBarCode
        {
            set { _productsbarcode = value; }
            get { return _productsbarcode; }
        }
        /// <summary>
        /// 合同明细---产品型号
        /// </summary>
        public string ProductsPattern
        {
            set { _productspattern = value; }
            get { return _productspattern; }
        }
        /// <summary>
        /// 合同明细---单位
        /// </summary>
        public string ProductsUnits
        {
            set { _productsunits = value; }
            get { return _productsunits; }
        }
        /// <summary>
        /// 合同明细---产品数量
        /// </summary>
        public int? ContractAmount
        {
            set { _contractamount = value; }
            get { return _contractamount; }
        }
        
        /// <summary>
        /// 合同明细---成本单价
        /// </summary>
        public decimal? ContractUnitPrice
        {
            set { _contractunitprice = value; }
            get { return _contractunitprice; }
        }
        /// <summary>
        /// 合同明细---成本折扣
        /// </summary>
        public decimal? ContractDiscount
        {
            set { _contractdiscount = value; }
            get { return _contractdiscount; }
        }
        /// <summary>
        /// 合同明细---成本金额合计
        /// </summary>
        public decimal? ContractTotalNet
        {
            set { _contracttotalnet = value; }
            get { return _contracttotalnet; }
        }
        /// <summary>
        /// 单价---销售单价
        /// </summary>
        public decimal? Contract_SalesUnitPrice
        {
            set { _contract_salesunitprice = value; }
            get { return _contract_salesunitprice; }
        }
        /// <summary>
        /// 合同明细---销售折扣
        /// </summary>
        public decimal? Contract_SalesDiscount
        {
            set { _contract_salesdiscount = value; }
            get { return _contract_salesdiscount; }
        }
        /// <summary>
        /// 合同明细---销售金额合计
        /// </summary>
        public decimal? Contract_SalesTotalNet
        {
            set { _contract_salestotalnet = value; }
            get { return _contract_salestotalnet; }
        }
        /// <summary>
        /// 合同产品明细----备注
        /// </summary>
        public string ContractRemarks
        {
            set { _contractremarks = value; }
            get { return _contractremarks; }
        }
        /// <summary>
        /// 合同明细--已出货数量
        /// </summary>
        public int? ContractReceiving
        {
            set { _contractreceiving = value; }
            get { return _contractreceiving; }
        }
        
        /// <summary>
        /// 合同产品明细----电池
        /// </summary>
        public string KSD_OrderNumber
        {
            set { _KSD_OrderNumber = value; }
            get { return _KSD_OrderNumber; }
        }
        public string KSD_MaterNumber
        {
            set { _KSD_MaterNumber = value; }
            get { return _KSD_MaterNumber; }
        }
        public string KSD_IsFollow
        {
            set { _KSD_IsFollow = value; }
            get { return _KSD_IsFollow; }
        }

        public int KSC_BNumber
        {
            set { _KSC_BNumber = value; }
            get { return _KSC_BNumber; }
        }

        public int KSC_OrderBNumber
        {
            set { _KSC_OrderBNumber = value; }
            get { return _KSC_OrderBNumber; }
        }


        public string KSD_PlanNumber
        {
            set { _KSD_PlanNumber = value; }
            get { return _KSD_PlanNumber; }
        }
        public string KSD_MaterPattern
        {
            set { _KSD_MaterPattern = value; }
            get { return _KSD_MaterPattern; }
        }


        public string KSD_XCMDID
        {
            set { _KSD_XCMDID = value; }
            get { return _KSD_XCMDID; }
        }

        public int KSD_HxNumber
        {
            set { _KSD_HxNumber = value; }
            get { return _KSD_HxNumber; }
        }

        public int KSD_HxState
        {
            set { _KSD_HxState = value; }
            get { return _KSD_HxState; }
        }

        #endregion Model

    }
}

