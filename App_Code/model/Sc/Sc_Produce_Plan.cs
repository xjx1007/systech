using System;
using System.Collections;
namespace KNet.Model
{
    /// <summary>
    /// Sc_Produce_Plan:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Sc_Produce_Plan
    {
        public Sc_Produce_Plan()
        { }
        #region Model
        private string _spp_id = "newid";
        private DateTime? _spp_stime;
        private string _spp_remarks;
        private string _spp_creator;
        private DateTime? _spp_ctime;
        private int? _spp_del = 0;
        private ArrayList _arr_Details;
        private string _SPP_SuppNo;
        private int? _SPP_CheckYN = 0;
        
        /// <summary>
        /// 
        /// </summary>
        public string SPP_ID
        {
            set { _spp_id = value; }
            get { return _spp_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? SPP_STime
        {
            set { _spp_stime = value; }
            get { return _spp_stime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SPP_Remarks
        {
            set { _spp_remarks = value; }
            get { return _spp_remarks; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SPP_Creator
        {
            set { _spp_creator = value; }
            get { return _spp_creator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? SPP_Ctime
        {
            set { _spp_ctime = value; }
            get { return _spp_ctime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SPP_Del
        {
            set { _spp_del = value; }
            get { return _spp_del; }
        }

        public ArrayList arr_Details
        {
            set { _arr_Details = value; }
            get { return _arr_Details; }
        }

        public string SPP_SuppNo
        {
            set { _SPP_SuppNo = value; }
            get { return _SPP_SuppNo; }
        }

        public int? SPP_CheckYN
        {
            set { _SPP_CheckYN = value; }
            get { return _SPP_CheckYN; }
        }
        
        #endregion Model

    }
}

