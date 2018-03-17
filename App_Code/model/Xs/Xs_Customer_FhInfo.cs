using System;
namespace KNet.Model
{
    /// <summary>
    /// Xs_Customer_FhInfo:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Xs_Customer_FhInfo
    {
        public Xs_Customer_FhInfo()
        { }
        #region Model
        private string _xcf_id;
        private string _xcf_customervalue;
        private string _xcf_name;
        private string _xcf_details;
        /// <summary>
        /// 
        /// </summary>
        public string XCF_ID
        {
            set { _xcf_id = value; }
            get { return _xcf_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XCF_CustomerValue
        {
            set { _xcf_customervalue = value; }
            get { return _xcf_customervalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XCF_Name
        {
            set { _xcf_name = value; }
            get { return _xcf_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XCF_Details
        {
            set { _xcf_details = value; }
            get { return _xcf_details; }
        }
        #endregion Model

    }
}

