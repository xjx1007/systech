using System;
namespace KNet.Model
{
    /// <summary>
    /// Xs_Contract_ViewPerson:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Xs_Contract_ViewPerson
    {
        public Xs_Contract_ViewPerson()
        { }
        #region Model
        private string _xcv_id;
        private string _xcv_contractno;
        private string _xcv_person;
        private DateTime _xcv_time;
        private string _xcv_state;
        private int _XCV_Del;
        /// <summary>
        /// 
        /// </summary>
        public string XCV_ID
        {
            set { _xcv_id = value; }
            get { return _xcv_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XCV_ContractNo
        {
            set { _xcv_contractno = value; }
            get { return _xcv_contractno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XCV_Person
        {
            set { _xcv_person = value; }
            get { return _xcv_person; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime XCV_Time
        {
            set { _xcv_time = value; }
            get { return _xcv_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XCV_State
        {
            set { _xcv_state = value; }
            get { return _xcv_state; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int XCV_Del
        {
            set { _XCV_Del = value; }
            get { return _XCV_Del; }
        }
        #endregion Model

    }
}

