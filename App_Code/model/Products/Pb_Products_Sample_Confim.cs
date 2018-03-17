using System;
using System.Collections;
namespace KNet.Model
{
    /// <summary>
    /// Pb_Products_Sample_Confim:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Pb_Products_Sample_Confim
    {
        public Pb_Products_Sample_Confim()
        { }
        #region Model
        private string _pbc_id;
        private string _pbc_type;
        private DateTime? _pbc_stime;
        private string _pbc_person;
        private string _pbc_remarks;
        private DateTime? _pbc_ctime;
        private string _pbc_creator;
        private DateTime? _pbc_mtime;
        private string _pbc_mender;
        private int? _pbc_del = 0;
        private ArrayList _arr_Details;
        private string _PBC_SampleID;
        private string _s_Type;
        private string _s_ProductsBarCode;
        
        /// <summary>
        /// 
        /// </summary>
        public string PBC_ID
        {
            set { _pbc_id = value; }
            get { return _pbc_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBC_Type
        {
            set { _pbc_type = value; }
            get { return _pbc_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PBC_Stime
        {
            set { _pbc_stime = value; }
            get { return _pbc_stime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBC_Person
        {
            set { _pbc_person = value; }
            get { return _pbc_person; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBC_Remarks
        {
            set { _pbc_remarks = value; }
            get { return _pbc_remarks; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PBC_CTime
        {
            set { _pbc_ctime = value; }
            get { return _pbc_ctime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBC_Creator
        {
            set { _pbc_creator = value; }
            get { return _pbc_creator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PBC_MTime
        {
            set { _pbc_mtime = value; }
            get { return _pbc_mtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBC_Mender
        {
            set { _pbc_mender = value; }
            get { return _pbc_mender; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PBC_Del
        {
            set { _pbc_del = value; }
            get { return _pbc_del; }
        }

        public ArrayList arr_Details
        {
            set { _arr_Details = value; }
            get { return _arr_Details; }
        }

        private ArrayList _arr_Details1;
        public ArrayList arr_Details1
        {
            set { _arr_Details1 = value; }
            get { return _arr_Details1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBC_SampleID
        {
            set { _PBC_SampleID = value; }
            get { return _PBC_SampleID; }
        }
        public string s_Type
        {
            set { _s_Type = value; }
            get { return _s_Type; }
        }
        public string s_ProductsBarCode
        {
            set { _s_ProductsBarCode = value; }
            get { return _s_ProductsBarCode; }
        }
        #endregion Model

    }
}

