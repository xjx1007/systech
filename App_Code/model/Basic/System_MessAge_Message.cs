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
    /// System_Message_Manage:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class System_Message_Manage
    {
        public System_Message_Manage()
        { }
        #region Model
        private string _smm_id;
        private string _smm_senderid;
        private string _smm_receiveid;
        private int _smm_state = 0;
        private string _smm_detail;
        private int _smm_del = 0;
        private string _smm_title;
        private DateTime? _smm_sendtime;
        private DateTime? _smm_looktime;
        private string _back_id;
        private string _SMM_Type;
        private int _SMM_UnRead = 1;
        private int _SMM_Receive = 1;
        /// <summary>
        /// 
        /// </summary>
        public string SMM_ID
        {
            set { _smm_id = value; }
            get { return _smm_id; }
        }
        /// <summary>
        /// 发送人
        /// </summary>
        public string SMM_SenderID
        {
            set { _smm_senderid = value; }
            get { return _smm_senderid; }
        }
        /// <summary>
        /// 接收人
        /// </summary>
        public string SMM_ReceiveID
        {
            set { _smm_receiveid = value; }
            get { return _smm_receiveid; }
        }
        /// <summary>
        /// 消息状态
        /// </summary>
        public int SMM_State
        {
            set { _smm_state = value; }
            get { return _smm_state; }
        }
        /// <summary>
        /// 发送明细
        /// </summary>
        public string SMM_Detail
        {
            set { _smm_detail = value; }
            get { return _smm_detail; }
        }
        /// <summary>
        /// 删除状态
        /// </summary>
        public int SMM_Del
        {
            set { _smm_del = value; }
            get { return _smm_del; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string SMM_Title
        {
            set { _smm_title = value; }
            get { return _smm_title; }
        }
        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime? SMM_SendTime
        {
            set { _smm_sendtime = value; }
            get { return _smm_sendtime; }
        }
        /// <summary>
        /// 查看时间
        /// </summary>
        public DateTime? SMM_LookTime
        {
            set { _smm_looktime = value; }
            get { return _smm_looktime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Back_ID
        {
            set { _back_id = value; }
            get { return _back_id; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string SMM_Type
        {
            set { _SMM_Type = value; }
            get { return _SMM_Type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SMM_UnRead
        {
            set { _SMM_UnRead = value; }
            get { return _SMM_UnRead; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SMM_Receive
        {
            set { _SMM_Receive = value; }
            get { return _SMM_Receive; }
        }
        #endregion Model

    }
}



