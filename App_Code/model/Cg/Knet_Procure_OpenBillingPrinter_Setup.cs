using System;
namespace KNet.Model
{
    /// <summary>
    /// 实体类Knet_Procure_OpenBillingPrinter_Setup
    /// </summary>
    [Serializable]
    public class Knet_Procure_OpenBillingPrinter_Setup
    {
        public Knet_Procure_OpenBillingPrinter_Setup()
        { }
        #region Model
        private string _id;
        private string _tex_id;
        private string _printertitle;
        private bool _printeryn;
        private DateTime? _printerdatetime;
        private string _topcomtont;
        private string _botcomtont;
        private bool _printstatshow;
        private bool _printamount_recodor;
        private bool _printamount_sum;
        private bool _printdiscount_sum;
        private bool _printtotalnet_sum;
        private bool _printtotalnet_bigwrite;
        private bool _defaultprinter;
        private int? _pai;
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
        public string Tex_ID
        {
            set { _tex_id = value; }
            get { return _tex_id; }
        }
        /// <summary>
        /// 打印模板名称
        /// </summary>
        public string PrinterTitle
        {
            set { _printertitle = value; }
            get { return _printertitle; }
        }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool PrinterYN
        {
            set { _printeryn = value; }
            get { return _printeryn; }
        }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime? PrinterDatetime
        {
            set { _printerdatetime = value; }
            get { return _printerdatetime; }
        }
        /// <summary>
        /// 头部模板
        /// </summary>
        public string TopComtont
        {
            set { _topcomtont = value; }
            get { return _topcomtont; }
        }
        /// <summary>
        /// 底部模板
        /// </summary>
        public string BotComtont
        {
            set { _botcomtont = value; }
            get { return _botcomtont; }
        }
        /// <summary>
        /// 是否显统计
        /// </summary>
        public bool PrintStatShow
        {
            set { _printstatshow = value; }
            get { return _printstatshow; }
        }
        /// <summary>
        /// 记录数合计
        /// </summary>
        public bool PrintAmount_Recodor
        {
            set { _printamount_recodor = value; }
            get { return _printamount_recodor; }
        }
        /// <summary>
        /// 数量合计
        /// </summary>
        public bool PrintAmount_Sum
        {
            set { _printamount_sum = value; }
            get { return _printamount_sum; }
        }
        /// <summary>
        /// 折扣合计
        /// </summary>
        public bool PrintDiscount_Sum
        {
            set { _printdiscount_sum = value; }
            get { return _printdiscount_sum; }
        }
        /// <summary>
        /// 总价合计
        /// </summary>
        public bool PrintTotalNet_Sum
        {
            set { _printtotalnet_sum = value; }
            get { return _printtotalnet_sum; }
        }
        /// <summary>
        /// 金额大写
        /// </summary>
        public bool PrintTotalNet_BigWrite
        {
            set { _printtotalnet_bigwrite = value; }
            get { return _printtotalnet_bigwrite; }
        }
        /// <summary>
        /// 是否默认模板
        /// </summary>
        public bool DefaultPrinter
        {
            set { _defaultprinter = value; }
            get { return _defaultprinter; }
        }
        /// <summary>
        /// 排序值
        /// </summary>
        public int? Pai
        {
            set { _pai = value; }
            get { return _pai; }
        }
        #endregion Model

    }
}

