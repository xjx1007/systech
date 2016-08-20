using System;
using System.Collections;
namespace KNet.Model
{
    /// <summary>
    /// KNet_Sys_Bank:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class KNet_Sys_Bank
    {
        public KNet_Sys_Bank()
        { }
        #region
        private string _ID;
        private string _BankNo;
        private string _BankName;
        private string _BankCount;
        private decimal _BankAmount;
        private int _BankPai = 0;
        private decimal _InitialAmount;
        private DateTime _KSB_STime;
        #endregion
        #region 属性设计器

        /// <summary>
        /// 自动ID值
        /// </summary>
        public string ID
        {
            set { _ID = value; }
            get { return _ID; }
        }
        /// <summary>
        /// 银行账号 唯一值
        /// </summary>
        public string BankNo
        {
            set { _BankNo = value; }
            get { return _BankNo; }
        }
        /// <summary>
        /// 银行账号  名称
        /// </summary>
        public string BankName
        {
            set { _BankName = value; }
            get { return _BankName; }
        }
        /// <summary>
        /// 银行账号 卡号
        /// </summary>
        public string BankCount
        {
            set { _BankCount = value; }
            get { return _BankCount; }
        }
        /// <summary>
        /// 银行账号 金额
        /// </summary>
        public decimal BankAmount
        {
            set { _BankAmount = value; }
            get { return _BankAmount; }
        }
        /// <summary>
        /// 银行账号 排序
        /// </summary>
        public int BankPai
        {
            set { _BankPai = value; }
            get { return _BankPai; }
        }
        /// <summary>
        /// 银行账号 初期金额
        /// </summary>
        public decimal InitialAmount
        {
            set { _InitialAmount = value; }
            get { return _InitialAmount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime KSB_STime
        {
            set { _KSB_STime = value; }
            get { return _KSB_STime; }
        }
        #endregion
        #region 附加信息

        private string Temp;
        public string getTemp()
        {
            return Temp;
        }
        public void setTemp(string Temp)
        {
            this.Temp = Temp;
        }
        private ArrayList _Arr_Detail;
        public ArrayList Arr_Detail
        {
            set { _Arr_Detail = value; }

            get { return _Arr_Detail; }
        }
        #endregion
    }
}
