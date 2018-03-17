using System;
namespace KNet.Model
{
    /// <summary>
    /// 实体类KNet_Sys_WareHouse
    /// </summary>
    public class KNet_Sys_WareHouse
    {
        public KNet_Sys_WareHouse()
        { }
        #region Model
        private string _id;
        private string _houseno;
        private string _housename;
        private string _housetel;
        private string _houseman;
        private string _houseaddress;
        private string _houseremark;
        private DateTime? _housedate;
        private bool _houseyn;
        private string _SuppNo;
        private int _KSW_Type;
        /// <summary>
        /// 自动ID值
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 仓库唯一编号
        /// </summary>
        public string HouseNo
        {
            set { _houseno = value; }
            get { return _houseno; }
        }
        /// <summary>
        /// 仓库名称
        /// </summary>
        public string HouseName
        {
            set { _housename = value; }
            get { return _housename; }
        }
        /// <summary>
        /// 仓库联系电话
        /// </summary>
        public string HouseTel
        {
            set { _housetel = value; }
            get { return _housetel; }
        }
        /// <summary>
        /// 仓库联系人
        /// </summary>
        public string HouseMan
        {
            set { _houseman = value; }
            get { return _houseman; }
        }
        /// <summary>
        /// 仓库地址
        /// </summary>
        public string HouseAddress
        {
            set { _houseaddress = value; }
            get { return _houseaddress; }
        }
        /// <summary>
        /// 仓库备注说明
        /// </summary>
        public string HouseRemark
        {
            set { _houseremark = value; }
            get { return _houseremark; }
        }
        /// <summary>
        /// 建库时间
        /// </summary>
        public DateTime? HouseDate
        {
            set { _housedate = value; }
            get { return _housedate; }
        }
        /// <summary>
        /// 仓库是否开账
        /// </summary>
        public bool HouseYN
        {
            set { _houseyn = value; }
            get { return _houseyn; }
        }

        public string SuppNo
        {
            set { _SuppNo = value; }
            get { return _SuppNo; }
        }
        public int KSW_Type
        {
            set { _KSW_Type = value; }
            get { return _KSW_Type; }
        }
        #endregion Model

    }
}

