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
    /// KNet_ContractDate:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class KNet_ContractDate
    {
        private int _kc_id;
        private string _kc_contractno;
        private DateTime? _kc_olddate;
        private DateTime? _kc_date;
        private int? _kc_type;
        private DateTime? _kc_adddate;
        private string _kc_addperson;
        /// <summary>
        /// 
        /// </summary>
        public int KC_ID
        {
            set { _kc_id = value; }
            get { return _kc_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KC_ContractNo
        {
            set { _kc_contractno = value; }
            get { return _kc_contractno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? KC_OldDate
        {
            set { _kc_olddate = value; }
            get { return _kc_olddate; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? KC_Date
        {
            set { _kc_date = value; }
            get { return _kc_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? KC_Type
        {
            set { _kc_type = value; }
            get { return _kc_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? KC_AddDate
        {
            set { _kc_adddate = value; }
            get { return _kc_adddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KC_AddPerson
        {
            set { _kc_addperson = value; }
            get { return _kc_addperson; }
        }

    }
}