using System;
namespace KNet.Model
{
    /// <summary>
    /// 实体类KNet_Sales_ClientAppseting 
    /// </summary>
    [Serializable]
    public class KNet_Sales_ClientAppseting
    {
        public KNet_Sales_ClientAppseting()
        { }
        #region Model
        private string _id;
        private string _clientvalue;
        private string _client_name;
        private int? _clientkings;
        private bool _clientdefault;
        private int? _clientpai;
        private string _client_faterno;
        private string _client_code;
        /// <summary>
        /// 自动ID值
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 唯一值
        /// </summary>
        public string ClientValue
        {
            set { _clientvalue = value; }
            get { return _clientvalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Client_Name
        {
            set { _client_name = value; }
            get { return _client_name; }
        }
        /// <summary>
        /// 分类(1渠道信息，2客户类型,3客户行业，4客户来源）
        /// </summary>
        public int? ClientKings
        {
            set { _clientkings = value; }
            get { return _clientkings; }
        }
        /// <summary>
        /// 是否是默认值
        /// </summary>
        public bool Clientdefault
        {
            set { _clientdefault = value; }
            get { return _clientdefault; }
        }
        /// <summary>
        /// 排序值
        /// </summary>
        public int? ClientPai
        {
            set { _clientpai = value; }
            get { return _clientpai; }
        }
        #endregion Model

        /// <summary>
        /// 上级ID
        /// </summary>
        public string Client_FaterNo
        {
            set { _client_faterno = value; }
            get { return _client_faterno; }
        }
        /// <summary>
        /// 编码
        /// </summary>
        public string Client_Code
        {
            set { _client_code = value; }
            get { return _client_code; }
        }
    }
}

