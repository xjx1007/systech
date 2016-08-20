using System;
namespace KNet.Model
{
    /// <summary>
    /// Xs_Customer_Products:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Xs_Customer_Products
    {
        public Xs_Customer_Products()
        { }
        #region Model
        private string _xcp_id;
        private string _xcp_customerid;
        private string _xcp_productsid;
        /// <summary>
        /// 
        /// </summary>
        public string XCP_ID
        {
            set { _xcp_id = value; }
            get { return _xcp_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XCP_CustomerID
        {
            set { _xcp_customerid = value; }
            get { return _xcp_customerid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XCP_ProductsID
        {
            set { _xcp_productsid = value; }
            get { return _xcp_productsid; }
        }
        #endregion Model

    }
}

