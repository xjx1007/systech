using System;
using System.Collections;
namespace KNet.Model
{
    /// <summary>
    /// 实体类KNet_WareHouse_AllocateList
    /// </summary>
    [Serializable]
    public class KNet_WareHouse_AllocateList
    {
        public KNet_WareHouse_AllocateList()
        { }
        #region Model
        private string _id;
        private string _allocateno;
        private string _allocatetopic;
        private string _allocatecause;
        private DateTime? _allocatedatetime;
        private string _houseno;
        private string _houseno_int;
        private string _allocatestaffbranch;
        private string _allocatestaffdepart;
        private string _allocatestaffno;
        private string _allocatecheckstaffno;
        private string _allocateremarks;
        private int _allocatecheckyn;
        private ArrayList _Arr_List;
        /// <summary>
        /// 自动ID值
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 调拨单号（唯一值）
        /// </summary>
        public string AllocateNo
        {
            set { _allocateno = value; }
            get { return _allocateno; }
        }
        /// <summary>
        /// 调拨主题
        /// </summary>
        public string AllocateTopic
        {
            set { _allocatetopic = value; }
            get { return _allocatetopic; }
        }
        /// <summary>
        /// 调拨原由:
        /// </summary>
        public string AllocateCause
        {
            set { _allocatecause = value; }
            get { return _allocatecause; }
        }
        /// <summary>
        /// 调拨时间
        /// </summary>
        public DateTime? AllocateDateTime
        {
            set { _allocatedatetime = value; }
            get { return _allocatedatetime; }
        }
        /// <summary>
        /// 调拨  出库
        /// </summary>
        public string HouseNo
        {
            set { _houseno = value; }
            get { return _houseno; }
        }
        /// <summary>
        /// 调拨  入库
        /// </summary>
        public string HouseNo_int
        {
            set { _houseno_int = value; }
            get { return _houseno_int; }
        }
        /// <summary>
        /// 调拨 分公司
        /// </summary>
        public string AllocateStaffBranch
        {
            set { _allocatestaffbranch = value; }
            get { return _allocatestaffbranch; }
        }
        /// <summary>
        /// 调拨 部门
        /// </summary>
        public string AllocateStaffDepart
        {
            set { _allocatestaffdepart = value; }
            get { return _allocatestaffdepart; }
        }
        /// <summary>
        /// 调拨 经手人
        /// </summary>
        public string AllocateStaffNo
        {
            set { _allocatestaffno = value; }
            get { return _allocatestaffno; }
        }
        /// <summary>
        /// 调拨 审核人
        /// </summary>
        public string AllocateCheckStaffNo
        {
            set { _allocatecheckstaffno = value; }
            get { return _allocatecheckstaffno; }
        }
        /// <summary>
        /// 调拨 备注
        /// </summary>
        public string AllocateRemarks
        {
            set { _allocateremarks = value; }
            get { return _allocateremarks; }
        }
        /// <summary>
        /// 调拨 是否审核
        /// </summary>
        public int AllocateCheckYN
        {
            set { _allocatecheckyn = value; }
            get { return _allocatecheckyn; }
        }

        public ArrayList Arr_List
        {
            set { _Arr_List = value; }
            get { return _Arr_List; }
        }
        #endregion Model

    }
}

