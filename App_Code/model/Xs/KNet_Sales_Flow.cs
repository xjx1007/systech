using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
namespace KNet.Model
{
    /// <summary>
    /// KNet_Sales_Flow:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class KNet_Sales_Flow
    {
        public KNet_Sales_Flow()
        { }
        #region Model
        private string _ksf_id = "newid";
        private string _ksf_detail;
        private DateTime? _ksf_date;
        private string _ksf_shperson;
        private int? _ksf_state;
        private string _ksf_contractno;
        private int? _kfs_type;
        private string _KFS_NextPerson;
        private string _KFS_IsNextPerson;
        private DateTime? _KFS_ReDate;
        
        
        /// <summary>
        /// 主键
        /// </summary>
        public string KSF_ID
        {
            set { _ksf_id = value; }
            get { return _ksf_id; }
        }
        /// <summary>
        /// 审核明细
        /// </summary>
        public string KSF_Detail
        {
            set { _ksf_detail = value; }
            get { return _ksf_detail; }
        }
        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime? KSF_Date
        {
            set { _ksf_date = value; }
            get { return _ksf_date; }
        }
        /// <summary>
        /// 审核人
        /// </summary>
        public string KSF_ShPerson
        {
            set { _ksf_shperson = value; }
            get { return _ksf_shperson; }
        }
        /// <summary>
        /// 审核状态
        /// </summary>
        public int? KSF_State
        {
            set { _ksf_state = value; }
            get { return _ksf_state; }
        }
        /// <summary>
        /// 编号
        /// </summary>
        public string KSF_ContractNo
        {
            set { _ksf_contractno = value; }
            get { return _ksf_contractno; }
        }
        /// <summary>
        /// 类型
        /// </summary>
        public int? KFS_Type
        {
            set { _kfs_type = value; }
            get { return _kfs_type; }
        }

        /// <summary>
        /// 编号
        /// </summary>
        public string KFS_NextPerson
        {
            set { _KFS_NextPerson = value; }
            get { return _KFS_NextPerson; }
        }
        /// <summary>
        /// 编号
        /// </summary>
        public string KFS_IsNextPerson
        {
            set { _KFS_IsNextPerson = value; }
            get { return _KFS_IsNextPerson; }
        }
        /// <summary>
        /// 编号
        /// </summary>
        public DateTime? KFS_ReDate
        {
            set { _KFS_ReDate = value; }
            get { return _KFS_ReDate; }
        }
        #endregion Model

    }
}

