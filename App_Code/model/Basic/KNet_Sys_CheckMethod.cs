using System;
namespace KNet.Model
{
    /// <summary>
    /// 实体类KNet_Sys_CheckMethod 
    /// </summary>
    public class KNet_Sys_CheckMethod
    {
        public KNet_Sys_CheckMethod()
        { }
        #region Model
        private string _id;
        private string _checkno;
        private string _checkname;
        private int? _checkpai;
        /// <summary>
        /// 自动ID值
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 票据类型唯一值
        /// </summary>
        public string CheckNo
        {
            set { _checkno = value; }
            get { return _checkno; }
        }
        /// <summary>
        /// 票据类型 名称
        /// </summary>
        public string CheckName
        {
            set { _checkname = value; }
            get { return _checkname; }
        }
        /// <summary>
        /// 票据类型 排序
        /// </summary>
        public int? CheckPai
        {
            set { _checkpai = value; }
            get { return _checkpai; }
        }
        #endregion Model

    }
}

