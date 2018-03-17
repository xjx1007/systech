using System;
namespace KNet.Model
{
    /// <summary>
    /// PB_Code_Ident:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class PB_Code_Ident
    {
        public PB_Code_Ident()
        { }
        #region Model
        private string _pci_table;
        private string _pci_type;
        private int? _pci_length;
        private string _pci_head;
        private string _pci_fill;
        private DateTime? _pci_date;
        private decimal? _pci_default;
        private decimal? _pci_identity;
        /// <summary>
        /// 
        /// </summary>
        public string PCI_Table
        {
            set { _pci_table = value; }
            get { return _pci_table; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PCI_Type
        {
            set { _pci_type = value; }
            get { return _pci_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PCI_Length
        {
            set { _pci_length = value; }
            get { return _pci_length; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PCI_Head
        {
            set { _pci_head = value; }
            get { return _pci_head; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PCI_Fill
        {
            set { _pci_fill = value; }
            get { return _pci_fill; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PCI_Date
        {
            set { _pci_date = value; }
            get { return _pci_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? PCI_Default
        {
            set { _pci_default = value; }
            get { return _pci_default; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? PCI_Identity
        {
            set { _pci_identity = value; }
            get { return _pci_identity; }
        }
        #endregion Model

    }
}

