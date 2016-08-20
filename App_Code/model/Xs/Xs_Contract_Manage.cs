using System;
using System.Collections;
namespace KNet.Model
{
    /// <summary>
    /// Xs_Contract_Manage:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Xs_Contract_Manage
    {
        public Xs_Contract_Manage()
        { }
        #region
        private string _XCM_ID;
        private string _XCM_Code;
        private string _XCM_Type;
        private string _XCM_Title;
        private string _XCM_CustomerValue;
        private string _XCM_DutyPerson;
        private DateTime _XCM_STime;
        private string _XCM_Flow;
        private string _XCM_Remarks;
        private int _XCM_Del = 0;
        private string _XCM_Creator;
        private DateTime _XCM_CTime;
        private string _XCM_Mender;
        private DateTime _XCM_MTime;
        private int _XCM_OrderNo = 0;
        private int _XCM_CheckYN = 0;
        private string _XCM_PayMent;
        private string _XCM_BillType;
        private string _XCM_TechnicalRequire;
        private string _XCM_ProductPackaging;
        private string _XCM_QualityRequire;
        private string _XCM_WarrantyPeriod;
        private string _XCM_DeliveryReqyire;
        private string _XCM_FhDetails;
        private string _XCM_KpType;
        #endregion
        #region 属性设计器

        /// <summary>
        /// 
        /// </summary>
        public string XCM_ID
        {
            set { _XCM_ID = value; }
            get { return _XCM_ID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XCM_Code
        {
            set { _XCM_Code = value; }
            get { return _XCM_Code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XCM_Type
        {
            set { _XCM_Type = value; }
            get { return _XCM_Type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XCM_Title
        {
            set { _XCM_Title = value; }
            get { return _XCM_Title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XCM_CustomerValue
        {
            set { _XCM_CustomerValue = value; }
            get { return _XCM_CustomerValue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XCM_DutyPerson
        {
            set { _XCM_DutyPerson = value; }
            get { return _XCM_DutyPerson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime XCM_STime
        {
            set { _XCM_STime = value; }
            get { return _XCM_STime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XCM_Flow
        {
            set { _XCM_Flow = value; }
            get { return _XCM_Flow; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XCM_Remarks
        {
            set { _XCM_Remarks = value; }
            get { return _XCM_Remarks; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int XCM_Del
        {
            set { _XCM_Del = value; }
            get { return _XCM_Del; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XCM_Creator
        {
            set { _XCM_Creator = value; }
            get { return _XCM_Creator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime XCM_CTime
        {
            set { _XCM_CTime = value; }
            get { return _XCM_CTime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XCM_Mender
        {
            set { _XCM_Mender = value; }
            get { return _XCM_Mender; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime XCM_MTime
        {
            set { _XCM_MTime = value; }
            get { return _XCM_MTime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int XCM_OrderNo
        {
            set { _XCM_OrderNo = value; }
            get { return _XCM_OrderNo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int XCM_CheckYN
        {
            set { _XCM_CheckYN = value; }
            get { return _XCM_CheckYN; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XCM_PayMent
        {
            set { _XCM_PayMent = value; }
            get { return _XCM_PayMent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XCM_BillType
        {
            set { _XCM_BillType = value; }
            get { return _XCM_BillType; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XCM_TechnicalRequire
        {
            set { _XCM_TechnicalRequire = value; }
            get { return _XCM_TechnicalRequire; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XCM_ProductPackaging
        {
            set { _XCM_ProductPackaging = value; }
            get { return _XCM_ProductPackaging; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XCM_QualityRequire
        {
            set { _XCM_QualityRequire = value; }
            get { return _XCM_QualityRequire; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XCM_WarrantyPeriod
        {
            set { _XCM_WarrantyPeriod = value; }
            get { return _XCM_WarrantyPeriod; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XCM_DeliveryReqyire
        {
            set { _XCM_DeliveryReqyire = value; }
            get { return _XCM_DeliveryReqyire; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XCM_FhDetails
        {
            set { _XCM_FhDetails = value; }
            get { return _XCM_FhDetails; }
        }

        public string XCM_KpType
        {
            set { _XCM_KpType = value; }
            get { return _XCM_KpType; }
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
        private ArrayList _Arr_Details;
        public ArrayList Arr_Details
        {
            set { _Arr_Details = value; }

            get { return _Arr_Details; }
        }

        private ArrayList _Arr_Details1;
        public ArrayList Arr_Details1
        {
            set { _Arr_Details1 = value; }

            get { return _Arr_Details1; }
        }


        private ArrayList _arr_FhDetails;
        public ArrayList arr_FhDetails
        {
            set { _arr_FhDetails = value; }

            get { return _arr_FhDetails; }
        }
        
        #endregion
    }
}
