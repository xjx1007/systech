using System;
namespace KNet.Model
{
    /// <summary>
    /// Pb_Products_Sample_Images:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Pb_Products_Sample_Images
    {
        public Pb_Products_Sample_Images()
        { }
        #region Model
        private string _ppi_id;
        private string _ppi_smapleid;
        private string _ppi_url;
        private string _ppi_name;
        private string _ppi_urlname;
        private string _PBI_Type;
        private DateTime _PPI_CTime;
        private string _PPI_Creator;
        /// <summary>
        /// 
        /// </summary>
        public string PPI_ID
        {
            set { _ppi_id = value; }
            get { return _ppi_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PPI_SmapleID
        {
            set { _ppi_smapleid = value; }
            get { return _ppi_smapleid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PPI_URL
        {
            set { _ppi_url = value; }
            get { return _ppi_url; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PPI_Name
        {
            set { _ppi_name = value; }
            get { return _ppi_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PPI_URLName
        {
            set { _ppi_urlname = value; }
            get { return _ppi_urlname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBI_Type
        {
            set { _PBI_Type = value; }
            get { return _PBI_Type; }
        }
        public DateTime PPI_CTime
        {
            set { _PPI_CTime = value; }
            get { return _PPI_CTime; }
        }
        public string PPI_Creator
        {
            set { _PPI_Creator = value; }
            get { return _PPI_Creator; }
        }
        #endregion Model

    }
}

