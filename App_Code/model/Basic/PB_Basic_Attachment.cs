using System;
namespace KNet.Model
{
    /// <summary>
    /// PB_Basic_Attachment:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class PB_Basic_Attachment
    {
        public PB_Basic_Attachment()
        { }
        #region Model
        private string _pba_id;
        private string _pba_fid;
        private string _pba_name;
        private string _pba_type;
        private string _pba_url;
        private string _pba_creator;
        private DateTime? _pba_ctime;
        private string _PBA_Remarks;
        private string _PBA_ProductsType;
        private int _PBA_State = 0;
        private int _PBA_Del = 0;
        private string _PBA_FileType;
        private string _PBA_Edition;
        private string _PBA_UpdateFID;
        private DateTime _PBA_EndTime;
        /// <summary>
        /// 
        /// </summary>
        public string PBA_ID
        {
            set { _pba_id = value; }
            get { return _pba_id; }
        }
        public DateTime PBA_EndTime
        {
            set { _PBA_EndTime = value; }
            get { return _PBA_EndTime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBA_FID
        {
            set { _pba_fid = value; }
            get { return _pba_fid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBA_Name
        {
            set { _pba_name = value; }
            get { return _pba_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBA_Type
        {
            set { _pba_type = value; }
            get { return _pba_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBA_URL
        {
            set { _pba_url = value; }
            get { return _pba_url; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBA_Creator
        {
            set { _pba_creator = value; }
            get { return _pba_creator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PBA_CTime
        {
            set { _pba_ctime = value; }
            get { return _pba_ctime; }
        }
        public string PBA_Remarks
        {
            set { _PBA_Remarks = value; }
            get { return _PBA_Remarks; }
        }


        public string PBA_ProductsType
        {
            set { _PBA_ProductsType = value; }
            get { return _PBA_ProductsType; }
        }


        public string PBA_FileType
        {
            set { _PBA_FileType = value; }
            get { return _PBA_FileType; }
        }

        public int PBA_State
        {
            set { _PBA_State = value; }
            get { return _PBA_State; }
        }

        public int PBA_Del
        {
            set { _PBA_Del = value; }
            get { return _PBA_Del; }
        }

        public string PBA_Edition
        {
            set { _PBA_Edition = value; }
            get { return _PBA_Edition; }
        }

        public string PBA_UpdateFID
        {
            set { _PBA_UpdateFID = value; }
            get { return _PBA_UpdateFID; }
        }

        #endregion Model

    }
}

