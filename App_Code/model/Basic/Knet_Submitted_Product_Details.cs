using System;
using System.Collections;

namespace KNet.Model
{
    /// <summary>
    /// Knet_ Submitted_Product_ Details:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Knet_Submitted_Product_Details
    {
        public Knet_Submitted_Product_Details()
        {
        }

        #region

        //private string _KPD_SID;
        private string _KPD_SID;
        //private string _KPD_OrderNo;
        private string _KPD_OrderNo;
        //private string _KPD_Code;
        private string _KPD_Code;
        private int _KPD_Number = 0;
        private int _KPD_CheckNumber = 0;
        private int _KPD_BadNumber = 0;
        private int _KPD_YNTState = 0;
        //private string _KPD_UploadUrl;
        private string _KPD_UploadUrl;
        private int _KPD_Prant = 0;
        private string _KPD_Remark;
        //private string _KPD_Proposer;
        private decimal _KPD_RejectRatio;
        private string _KPD_Proposer;
        private string _KPD_Brand;
        private DateTime _KPD_PTime;
        private int _KPD_KDNumber;
        #endregion

        #region 属性设计器

        /// <summary>
        /// 
        /// </summary>
        public string KPD_SID
        {
            set { _KPD_SID = value; }
            get { return _KPD_SID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int KPD_KDNumber
        {
            set { _KPD_KDNumber = value; }
            get { return _KPD_KDNumber; }
        }

        public string KPD_Brand
        {
            set { _KPD_Brand = value; }
            get { return _KPD_Brand; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string KPD_OrderNo
        {
            set { _KPD_OrderNo = value; }
            get { return _KPD_OrderNo; }
        }


        public decimal KPD_RejectRatio
        {
            set { _KPD_RejectRatio = value; }
            get { return _KPD_RejectRatio; }
        }


        /// <summary>
        /// 
        /// </summary>
        public string KPD_Code
        {
            set { _KPD_Code = value; }
            get { return _KPD_Code; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int KPD_Number
        {
            set { _KPD_Number = value; }
            get { return _KPD_Number; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int KPD_CheckNumber
        {
            set { _KPD_CheckNumber = value; }
            get { return _KPD_CheckNumber; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int KPD_BadNumber
        {
            set { _KPD_BadNumber = value; }
            get { return _KPD_BadNumber; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int KPD_YNTState
        {
            set { _KPD_YNTState = value; }
            get { return _KPD_YNTState; }
        }


        /// <summary>
        /// 
        /// </summary>
        public string KPD_UploadUrl
        {
            set { _KPD_UploadUrl = value; }
            get { return _KPD_UploadUrl; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int KPD_Prant
        {
            set { _KPD_Prant = value; }
            get { return _KPD_Prant; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string KPD_Remark
        {
            set { _KPD_Remark = value; }
            get { return _KPD_Remark; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string KPD_Proposer
        {
            set { _KPD_Proposer = value; }
            get { return _KPD_Proposer; }
        }



        /// <summary>
        /// 
        /// </summary>
        public DateTime KPD_PTime
        {
            set { _KPD_PTime = value; }
            get { return _KPD_PTime; }
        }

        #endregion


    }
}
