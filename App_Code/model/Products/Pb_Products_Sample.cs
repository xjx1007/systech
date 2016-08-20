using System;
using System.Collections;
namespace KNet.Model
{
    /// <summary>
    /// Pb_Products_Sample:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Pb_Products_Sample
    {
        public Pb_Products_Sample()
        { }
        #region Model
        private string _pps_id;
        private string _pps_code;
        private string _pps_name;
        private DateTime? _pps_stime;
        private DateTime? _pps_needtime;
        private string _pps_customervalue;
        private string _pps_linkman;
        private string _pps_dutypeson;
        private string _pps_dept;
        private string _pps_demopicture;
        private string _pps_picture;
        private string _pps_requirement;
        private string _pps_remarks;
        private DateTime? _pps_ctime;
        private string _pps_creator;
        private DateTime? _pps_mtime;
        private string _pps_mender;
        private int? _pps_del = 0;
        private string _pps_shell;
        private string _pps_appearance;
        private string _pps_resin;
        private string _pps_resinmaterial;
        private string _pps_chip;
        private int _pps_Number;
        private string _pps_use;
        private string _PPS_Type;
        private string _PPS_ProductsBarCode;
        private string _PPS_DealDetails;
        
        private ArrayList _arr_Details;
        /// <summary>
        /// 
        /// </summary>
        public string PPS_ID
        {
            set { _pps_id = value; }
            get { return _pps_id; }
        }

        public string PPS_Code
        {
            set { _pps_code = value; }
            get { return _pps_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PPS_Name
        {
            set { _pps_name = value; }
            get { return _pps_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PPS_Stime
        {
            set { _pps_stime = value; }
            get { return _pps_stime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PPS_Needtime
        {
            set { _pps_needtime = value; }
            get { return _pps_needtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PPS_CustomerValue
        {
            set { _pps_customervalue = value; }
            get { return _pps_customervalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PPS_LinkMan
        {
            set { _pps_linkman = value; }
            get { return _pps_linkman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PPS_DutyPeson
        {
            set { _pps_dutypeson = value; }
            get { return _pps_dutypeson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PPS_Dept
        {
            set { _pps_dept = value; }
            get { return _pps_dept; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PPS_DemoPicture
        {
            set { _pps_demopicture = value; }
            get { return _pps_demopicture; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PPS_Picture
        {
            set { _pps_picture = value; }
            get { return _pps_picture; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PPS_Requirement
        {
            set { _pps_requirement = value; }
            get { return _pps_requirement; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PPS_Remarks
        {
            set { _pps_remarks = value; }
            get { return _pps_remarks; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PPS_CTime
        {
            set { _pps_ctime = value; }
            get { return _pps_ctime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PPS_Creator
        {
            set { _pps_creator = value; }
            get { return _pps_creator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PPS_MTime
        {
            set { _pps_mtime = value; }
            get { return _pps_mtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PPS_Mender
        {
            set { _pps_mender = value; }
            get { return _pps_mender; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PPS_Del
        {
            set { _pps_del = value; }
            get { return _pps_del; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PPS_Shell
        {
            set { _pps_shell = value; }
            get { return _pps_shell; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PPS_Appearance
        {
            set { _pps_appearance = value; }
            get { return _pps_appearance; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PPS_Resin
        {
            set { _pps_resin = value; }
            get { return _pps_resin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PPS_ResinMaterial
        {
            set { _pps_resinmaterial = value; }
            get { return _pps_resinmaterial; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PPS_Chip
        {
            set { _pps_chip = value; }
            get { return _pps_chip; }
        }

        public int PPS_Number
        {
            set { _pps_Number = value; }
            get { return _pps_Number; }
        }

        public string PPS_Use
        {
            set { _pps_use = value; }
            get { return _pps_use; }
        }

        public string PPS_Type
        {
            set { _PPS_Type = value; }
            get { return _PPS_Type; }
        }

        public string PPS_ProductsBarCode
        {
            set { _PPS_ProductsBarCode = value; }
            get { return _PPS_ProductsBarCode; }
        }

        public string PPS_DealDetails
        {
            set { _PPS_DealDetails = value; }
            get { return _PPS_DealDetails; }
        }
        
        
        public ArrayList arr_Details
        {
            set { _arr_Details = value; }
            get { return _arr_Details; }
        }
        #endregion Model

    }
}

