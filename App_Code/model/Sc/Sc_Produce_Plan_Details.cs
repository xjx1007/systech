using System;
namespace KNet.Model
{
    /// <summary>
    /// Sc_Produce_Plan_Details:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Sc_Produce_Plan_Details
    {
        public Sc_Produce_Plan_Details()
        { }
        #region Model
        private string _spd_id;
        private DateTime? _spd_begintime;
        private DateTime? _spd_endtime;
        private string _spd_orderno;
        private string _spd_remarks;
        private int? _spd_type = 0;
        private string _spd_faterid;
        private DateTime? _spd_fbegintime;
        private DateTime? _spd_fendtime;
        private int? _spd_days;
        private int? _spd_number;
        private int? _SPD_IsWl;
        private int _SCP_Order;
        
        
        /// <summary>
        /// 
        /// </summary>
        public string SPD_ID
        {
            set { _spd_id = value; }
            get { return _spd_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? SPD_BeginTime
        {
            set { _spd_begintime = value; }
            get { return _spd_begintime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? SPD_EndTime
        {
            set { _spd_endtime = value; }
            get { return _spd_endtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SPD_OrderNo
        {
            set { _spd_orderno = value; }
            get { return _spd_orderno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SPD_Remarks
        {
            set { _spd_remarks = value; }
            get { return _spd_remarks; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SPD_Type
        {
            set { _spd_type = value; }
            get { return _spd_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SPD_FaterID
        {
            set { _spd_faterid = value; }
            get { return _spd_faterid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? SPD_FBeginTime
        {
            set { _spd_fbegintime = value; }
            get { return _spd_fbegintime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? SPD_FEndTime
        {
            set { _spd_fendtime = value; }
            get { return _spd_fendtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SPD_Days
        {
            set { _spd_days = value; }
            get { return _spd_days; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SPD_Number
        {
            set { _spd_number = value; }
            get { return _spd_number; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public int? SPD_IsWl
        {
            set { _SPD_IsWl = value; }
            get { return _SPD_IsWl; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int SCP_Order
        {
            set { _SCP_Order = value; }
            get { return _SCP_Order; }
        }
        
        #endregion Model

    }
}

