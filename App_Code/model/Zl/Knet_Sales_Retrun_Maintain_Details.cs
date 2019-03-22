using System;
using System.Collections;
namespace KNet.Model
{
    /// <summary>
    /// Knet_Sales_Retrun_Maintain_Details:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Knet_Sales_Retrun_Maintain_Details
    {
        public Knet_Sales_Retrun_Maintain_Details()
        { }
        #region 
        private string _KSD_ID;
        private string _KSD_ProductCode;
        private int _KSD_Number = 0;
        private int _KSD_BadNumber = 0;
        private int _KSD_GoodNumber = 0;
        private int _KSD_STime = 0;
        private int _KSD_Result = 0;
        private string _KSD_Text;
        #endregion
        #region 属性设计器

        /// <summary>
        /// 
        /// </summary>
        public string KSD_ID
        {
            set { _KSD_ID = value; }
            get { return _KSD_ID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KSD_ProductCode
        {
            set { _KSD_ProductCode = value; }
            get { return _KSD_ProductCode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int KSD_Number
        {
            set { _KSD_Number = value; }
            get { return _KSD_Number; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int KSD_BadNumber
        {
            set { _KSD_BadNumber = value; }
            get { return _KSD_BadNumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int KSD_GoodNumber
        {
            set { _KSD_GoodNumber = value; }
            get { return _KSD_GoodNumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int KSD_STime
        {
            set { _KSD_STime = value; }
            get { return _KSD_STime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int KSD_Result
        {
            set { _KSD_Result = value; }
            get { return _KSD_Result; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KSD_Text
        {
            set { _KSD_Text = value; }
            get { return _KSD_Text; }
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
