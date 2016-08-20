using System;
namespace KNet.Model
{
    /// <summary>
    /// 实体类KNet_Sys_CheckNotes
    /// </summary>
    public class KNet_Sys_CheckNotes
    {
        public KNet_Sys_CheckNotes()
        { }
        #region Model
        private string _id;
        private string _notesno;
        private string _notesname;
        private int? _notespai;
        /// <summary>
        /// 自动ID值
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 结算方式唯一值
        /// </summary>
        public string NotesNo
        {
            set { _notesno = value; }
            get { return _notesno; }
        }
        /// <summary>
        /// 结算方式名称
        /// </summary>
        public string NotesName
        {
            set { _notesname = value; }
            get { return _notesname; }
        }
        /// <summary>
        /// 结算方式排序
        /// </summary>
        public int? NotesPai
        {
            set { _notespai = value; }
            get { return _notespai; }
        }
        #endregion Model

    }
}

