using System;
using System.Collections;
namespace KNet.Model
{
    /// <summary>
    /// 实体类KNet_WareHouse_AllocateList
    /// </summary>
    [Serializable]
    public class KNet_WareHouse_FuAllocateList
    {
        public KNet_WareHouse_FuAllocateList()
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
        private ArrayList _Arr_List1;
        private string _KWA_OrderNo;

        private string _KWA_Type;
        private int _KWA_DBType;
        private int _KWA_IsSave;
        private string _KWA_UploadUrl;
        private string _KWA_UploadName;
        private string _KSP_SID;
        private int _KWA_IsEntity;
       
        /// <summary>
        /// 自动ID值
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
       
        /// <summary>
        /// 判断入库通知是否为实物
        /// </summary>
        public int KWA_IsEntity
        {
            set { _KWA_IsEntity = value; }
            get { return _KWA_IsEntity; }
        }
        /// <summary>
        /// 送检单号
        /// </summary>
        public string KSP_SID
        {
            set { _KSP_SID = value; }
            get { return _KSP_SID; }
        }
        /// <summary>
        /// 附件路径
        /// </summary>
        public string KWA_UploadUrl
        {
            set { _KWA_UploadUrl = value; }
            get { return _KWA_UploadUrl; }
        }
        /// <summary>
        /// 附件名称
        /// </summary>
        public string KWA_UploadName
        {
            set { _KWA_UploadName = value; }
            get { return _KWA_UploadName; }
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

        public int KWA_IsSave
        {
            set { _KWA_IsSave = value; }
            get { return _KWA_IsSave; }
        }

        public ArrayList Arr_List
        {
            set { _Arr_List = value; }
            get { return _Arr_List; }
        }

        public ArrayList Arr_List1
        {
            set { _Arr_List1 = value; }
            get { return _Arr_List1; }
        }



        public string KWA_OrderNo
        {
            set { _KWA_OrderNo = value; }
            get { return _KWA_OrderNo; }
        }


        public string KWA_Type
        {
            set { _KWA_Type = value; }
            get { return _KWA_Type; }
        }

        public int KWA_DBType
        {
            set { _KWA_DBType = value; }
            get { return _KWA_DBType; }
        }


        #endregion Model

    }
}

