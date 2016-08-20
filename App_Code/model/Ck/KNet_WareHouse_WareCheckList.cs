using System;
using System.Collections;
namespace KNet.Model
{
    /// <summary>
    /// 实体类KNet_WareHouse_WareCheckList 
    /// </summary>
    [Serializable]
    public class KNet_WareHouse_WareCheckList
    {
        public KNet_WareHouse_WareCheckList()
        { }
        #region Model
        private string _id;
        private string _warecheckno;
        private string _warechecktopic;
        private DateTime? _warecheckdatetime;
        private string _houseno;
        private string _warecheckstaffbranch;
        private string _warecheckstaffdepart;
        private string _warecheckstaffno;
        private string _warecheckcheckstaffno;
        private string _warecheckremarks;
        private bool _warecheckcheckyn;
        private ArrayList _arr_Details;
        private string _suppNo;
        /// <summary>
        /// 自动唯一值
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        public string SuppNo
        {
            set { _suppNo = value; }
            get { return _suppNo; }
        }
        /// <summary>
        /// 盘点单号（唯一性）
        /// </summary>
        public string WareCheckNo
        {
            set { _warecheckno = value; }
            get { return _warecheckno; }
        }
        /// <summary>
        /// 盘点 主题
        /// </summary>
        public string WareCheckTopic
        {
            set { _warechecktopic = value; }
            get { return _warechecktopic; }
        }
        /// <summary>
        /// 盘点日期
        /// </summary>
        public DateTime? WareCheckDateTime
        {
            set { _warecheckdatetime = value; }
            get { return _warecheckdatetime; }
        }
        /// <summary>
        /// 盘点 仓库
        /// </summary>
        public string HouseNo
        {
            set { _houseno = value; }
            get { return _houseno; }
        }
        /// <summary>
        /// 盘点 分公司
        /// </summary>
        public string WareCheckStaffBranch
        {
            set { _warecheckstaffbranch = value; }
            get { return _warecheckstaffbranch; }
        }
        /// <summary>
        /// 盘点 部门
        /// </summary>
        public string WareCheckStaffDepart
        {
            set { _warecheckstaffdepart = value; }
            get { return _warecheckstaffdepart; }
        }
        /// <summary>
        /// 盘点 经手人
        /// </summary>
        public string WareCheckStaffNo
        {
            set { _warecheckstaffno = value; }
            get { return _warecheckstaffno; }
        }
        /// <summary>
        /// 盘点 审核人
        /// </summary>
        public string WareCheckCheckStaffNo
        {
            set { _warecheckcheckstaffno = value; }
            get { return _warecheckcheckstaffno; }
        }
        /// <summary>
        /// 盘点 备注
        /// </summary>
        public string WareCheckRemarks
        {
            set { _warecheckremarks = value; }
            get { return _warecheckremarks; }
        }
        /// <summary>
        /// 盘点 是否审核
        /// </summary>
        public bool WareCheckCheckYN
        {
            set { _warecheckcheckyn = value; }
            get { return _warecheckcheckyn; }
        }

        public ArrayList arr_Details
        {
            set { _arr_Details = value; }
            get { return _arr_Details; }
        }
        #endregion Model

    }
}

