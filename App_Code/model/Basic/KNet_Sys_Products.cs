using System;
using System.Collections;
namespace KNet.Model
{
    /// <summary>
    /// 实体类KNet_Sys_Products
    /// </summary>
    public class KNet_Sys_Products
    {
        public KNet_Sys_Products()
        { }
        #region Model
        private string _id;
        private string _productsname;
        private string _productsbarcode;
        private string _productspattern;
        private string _productsmaincategory;
        private string _productssmallcategory;
        private string _productsunits;
        private decimal? _productssellingprice;
        private decimal? _productscostprice;
        private int? _productsstockalert;
        private bool _productspic;
        private string _productsbigpicture;
        private string _productssmallpicture;
        private string _productsdescription;
        private string _productsdetaildescription;
        private DateTime? _productsaddtime;
        private string _productsaddman;
        private string _productstype;
        private ArrayList _CustomerList;
        private ArrayList _ProductsList;
        private ArrayList _DemoProductsList;
        private ArrayList _arr_Details;
        private ArrayList _arr_CgDayDetails;
        private ArrayList _arr_Alternative;
        private decimal? _handprice;
        private string _ProductsEdition;
        private string _KSP_SampleId;
        private int _KSP_Del;
        private int _KSP_isModiy;

        private string _ksp_mould;
        private string _ksp_creator;
        private DateTime? _ksp_ctime;
        private DateTime? _ksp_mtime;
        private string _ksp_mender;
        private string _ksp_code;
        private string _KSP_GProductsBarCode;
        private decimal _KSP_Weight;
        private decimal _KSP_Volume;

        private int _KSP_IsAdd;
        private int _KSP_IsReplace;
        private int _KSP_IsDelete;

        private int _KSP_CgType;
        private string _KSP_DelRemarks;
        private string _KSP_RDPerson;



        private string _KSP_CustomerProductsName;
        private string _KSP_CustomerProductsCode;
        private string _KSP_CustomerProductsEdition;
        private string _KSP_ShPerson;
        private int _KSP_BZNumber;
        private int _Type;
        private string[] _s_BomIDs;

        public string[] s_BomIDs
        {
            set { _s_BomIDs = value; }
            get { return _s_BomIDs; }
        }
        public int Type
        {
            set { _Type = value; }
            get { return _Type; }
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
        /// 建议销售价格
        /// </summary>
        public decimal? ProductsSellingPrice
        {
            set { _productssellingprice = value; }
            get { return _productssellingprice; }
        }
        /// <summary>
        /// 参考成本价格
        /// </summary>
        public decimal? ProductsCostPrice
        {
            set { _productscostprice = value; }
            get { return _productscostprice; }
        }
        /// <summary>
        /// 库存预警
        /// </summary>
        public int? ProductsStockAlert
        {
            set { _productsstockalert = value; }
            get { return _productsstockalert; }
        }

        public int KSP_BZNumber
        {
            set { _KSP_BZNumber = value; }
            get { return _KSP_BZNumber; }
        }

        /// <summary>
        /// 是否有图片
        /// </summary>
        public bool ProductsPic
        {
            set { _productspic = value; }
            get { return _productspic; }
        }
        /// <summary>
        /// 大图片
        /// </summary>
        public string ProductsBigPicture
        {
            set { _productsbigpicture = value; }
            get { return _productsbigpicture; }
        }
        /// <summary>
        /// 小图片
        /// </summary>
        public string ProductsSmallPicture
        {
            set { _productssmallpicture = value; }
            get { return _productssmallpicture; }
        }
        /// <summary>
        /// 简单描述
        /// </summary>
        public string ProductsDescription
        {
            set { _productsdescription = value; }
            get { return _productsdescription; }
        }
        /// <summary>
        /// 详细描述
        /// </summary>
        public string ProductsDetailDescription
        {
            set { _productsdetaildescription = value; }
            get { return _productsdetaildescription; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? ProductsAddTime
        {
            set { _productsaddtime = value; }
            get { return _productsaddtime; }
        }
        /// <summary>
        /// 添加操作员
        /// </summary>
        public string ProductsAddMan
        {
            set { _productsaddman = value; }
            get { return _productsaddman; }
        }

        public string ProductsType
        {
            set { _productstype = value; }
            get { return _productstype; }
        }

        public ArrayList CustomerList
        {
            set { _CustomerList = value; }
            get { return _CustomerList; }
        }
        public ArrayList ProductsList
        {
            set { _ProductsList = value; }
            get { return _ProductsList; }
        }
        public ArrayList DemoProductsList
        {
            set { _DemoProductsList = value; }
            get { return _DemoProductsList; }
        }
        public ArrayList arr_Details
        {
            set { _arr_Details = value; }
            get { return _arr_Details; }
        }
        public ArrayList arr_CgDayDetails
        {
            set { _arr_CgDayDetails = value; }
            get { return _arr_CgDayDetails; }
        }
        public ArrayList arr_Alternative
        {
            set { _arr_Alternative = value; }
            get { return _arr_Alternative; }
        }
        private ArrayList _arr_RCDetails;
        public ArrayList arr_RCDetails
        {
            set { _arr_RCDetails = value; }
            get { return _arr_RCDetails; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? HandPrice
        {
            set { _handprice = value; }
            get { return _handprice; }
        }
        
        public string ProductsEdition
        {
            set { _ProductsEdition = value; }
            get { return _ProductsEdition; }
        }

        public string KSP_SampleId
        {
            set { _KSP_SampleId = value; }
            get { return _KSP_SampleId; }
        }
        public int KSP_Del
        {
            set { _KSP_Del = value; }
            get { return _KSP_Del; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KSP_Mould
        {
            set { _ksp_mould = value; }
            get { return _ksp_mould; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KSP_Creator
        {
            set { _ksp_creator = value; }
            get { return _ksp_creator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? KSP_CTime
        {
            set { _ksp_ctime = value; }
            get { return _ksp_ctime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? KSP_MTime
        {
            set { _ksp_mtime = value; }
            get { return _ksp_mtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KSP_Mender
        {
            set { _ksp_mender = value; }
            get { return _ksp_mender; }
        }

        public string KSP_Code
        {
            set { _ksp_code = value; }
            get { return _ksp_code; }
        }
        public int KSP_isModiy
        {
            set { _KSP_isModiy = value; }
            get { return _KSP_isModiy; }
        }
        public string KSP_GProductsBarCode
        {
            set { _KSP_GProductsBarCode=value;}
            get { return _KSP_GProductsBarCode; }
        }

        public decimal KSP_Weight
        {
            set { _KSP_Weight = value; }
            get { return _KSP_Weight; }
        }
        public decimal KSP_Volume
        {
            set { _KSP_Volume = value; }
            get { return _KSP_Volume; }
        }

        public int KSP_IsAdd
        {
            set { _KSP_IsAdd = value; }
            get { return _KSP_IsAdd; }
        }
        public int KSP_IsReplace
        {
            set { _KSP_IsReplace = value; }
            get { return _KSP_IsReplace; }
        }
        public int KSP_IsDelete
        {
            set { _KSP_IsDelete = value; }
            get { return _KSP_IsDelete; }
        }


        public int KSP_CgType
        {
            set { _KSP_CgType = value; }
            get { return _KSP_CgType; }
        }
        
        
        public string KSP_DelRemarks
        {
            set { _KSP_DelRemarks=value;}
            get { return _KSP_DelRemarks; }
        }


        public string KSP_CustomerProductsName
        {
            set { _KSP_CustomerProductsName = value; }
            get { return _KSP_CustomerProductsName; }
        }
        public string KSP_CustomerProductsCode
        {
            set { _KSP_CustomerProductsCode = value; }
            get { return _KSP_CustomerProductsCode; }
        }
        public string KSP_CustomerProductsEdition
        {
            set { _KSP_CustomerProductsEdition = value; }
            get { return _KSP_CustomerProductsEdition; }
        }

        public string KSP_RDPerson
        {
            set { _KSP_RDPerson = value; }
            get { return _KSP_RDPerson; }
        }

        public string KSP_ShPerson
        {
            set { _KSP_ShPerson = value; }
            get { return _KSP_ShPerson; }
        }
        
        #endregion Model

    }
}

