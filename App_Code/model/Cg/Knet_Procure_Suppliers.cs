using System;
namespace KNet.Model
{
    /// <summary>
    /// 实体类Knet_Procure_Suppliers 供应商
    /// </summary>
    public class Knet_Procure_Suppliers
    {
        public Knet_Procure_Suppliers()
        { }
        #region Model
        private string _id;
        private string _suppcode;
        private string _suppno;
        private string _suppname;
        private string _supppeople;
        private string _suppmobitel;
        private string _suppfax;
        private string _suppphone;
        private string _suppweb;
        private string _suppemail;
        private string _suppprovince;
        private string _suppcity;
        private string _suppaddress;
        private string _suppzipcode;
        private string _suppbankname;
        private string _suppbankaccount;
        private string _suppproducts;
        private string _remarks;
        private string _KPS_DutyPerson;
        private string _KPS_Level;
        private string _KPS_Type;
        private string _KPS_Creator;
        private DateTime _KPS_CTime;
        private string _KPS_Mender;
        private DateTime _KPS_MTime;
        private int _KPS_Del;
        private string _KPS_LinkManID;
        private string _KPS_Sname;
        private string _KPS_Code;
        private int _KPS_Days;
        private string _KPS_KDCode;
        private int _KPS_ScNumber;
        private int _KPS_Flow;
        private int _KPS_State;
        private string _KPS_SuppCode;
        private decimal _KPS_KPMaxMoney;
        private int _KPS_MaxRow;
        private int _KPS_GiveDays;
        
        /// <summary>
        /// 自动编号
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 供应商唯一编号
        /// </summary>
        public string SuppNo
        {
            set { _suppno = value; }
            get { return _suppno; }
        }
        public string SuppCode
        {
            set { _suppcode = value; }
            get { return _suppcode; }
        }


        /// <summary>
        /// 供应商名称
        /// </summary>
        public string SuppName
        {
            set { _suppname = value; }
            get { return _suppname; }
        }
        /// <summary>
        /// 供应商联系人
        /// </summary>
        public string SuppPeople
        {
            set { _supppeople = value; }
            get { return _supppeople; }
        }
        /// <summary>
        /// 供应商联系手机
        /// </summary>
        public string SuppMobiTel
        {
            set { _suppmobitel = value; }
            get { return _suppmobitel; }
        }
        /// <summary>
        /// 供应商传真
        /// </summary>
        public string SuppFax
        {
            set { _suppfax = value; }
            get { return _suppfax; }
        }
        /// <summary>
        /// 供应商电话
        /// </summary>
        public string SuppPhone
        {
            set { _suppphone = value; }
            get { return _suppphone; }
        }
        /// <summary>
        /// 供应商网址
        /// </summary>
        public string SuppWeb
        {
            set { _suppweb = value; }
            get { return _suppweb; }
        }
        /// <summary>
        /// 供应商 邮件
        /// </summary>
        public string SuppEmail
        {
            set { _suppemail = value; }
            get { return _suppemail; }
        }
        /// <summary>
        /// 省份
        /// </summary>
        public string SuppProvince
        {
            set { _suppprovince = value; }
            get { return _suppprovince; }
        }
        /// <summary>
        /// 供应商所在地区
        /// </summary>
        public string SuppCity
        {
            set { _suppcity = value; }
            get { return _suppcity; }
        }
        /// <summary>
        /// 供应商 地址
        /// </summary>
        public string SuppAddress
        {
            set { _suppaddress = value; }
            get { return _suppaddress; }
        }
        /// <summary>
        /// 供应商 邮政编码
        /// </summary>
        public string SuppZipCode
        {
            set { _suppzipcode = value; }
            get { return _suppzipcode; }
        }
        /// <summary>
        /// 供应商开户行名称
        /// </summary>
        public string SuppBankName
        {
            set { _suppbankname = value; }
            get { return _suppbankname; }
        }
        /// <summary>
        /// 供应商开户行账号
        /// </summary>
        public string SuppBankAccount
        {
            set { _suppbankaccount = value; }
            get { return _suppbankaccount; }
        }
        /// <summary>
        /// 供应商 主营产品
        /// </summary>
        public string SuppProducts
        {
            set { _suppproducts = value; }
            get { return _suppproducts; }
        }
        /// <summary>
        /// 供应商 备注说明
        /// </summary>
        public string Remarks
        {
            set { _remarks = value; }
            get { return _remarks; }
        }


        public string KPS_DutyPerson
        {
            set { _KPS_DutyPerson = value; }
            get { return _KPS_DutyPerson; }
        }
        
        public string KPS_Level
        {
            set { _KPS_Level = value; }
            get { return _KPS_Level; }
        }
        
        public string KPS_Type
        {
            set { _KPS_Type = value; }
            get { return _KPS_Type; }
        }
        public string KPS_Creator
        {
            set { _KPS_Creator = value; }
            get { return _KPS_Creator; }
        }
        public DateTime KPS_CTime
        {
            set { _KPS_CTime = value; }
            get { return _KPS_CTime; }
        }
        public DateTime KPS_MTime
        {
            set { _KPS_MTime = value; }
            get { return _KPS_MTime; }
        }
        public string KPS_Mender
        {
            set { _KPS_Mender = value; }
            get { return _KPS_Mender; }
        }
        public int KPS_Del
        {
            set { _KPS_Del = value; }
            get { return _KPS_Del; }
        }

        public string KPS_LinkManID
        {
            set { _KPS_LinkManID = value; }
            get { return _KPS_LinkManID; }
        }

        public string KPS_Sname
        {
            set { _KPS_Sname = value; }
            get { return _KPS_Sname; }
        }

        public string KPS_Code
        {
            set { _KPS_Code = value; }
            get { return _KPS_Code; }
        }

        public int KPS_Days
        {
            set { _KPS_Days = value; }
            get { return _KPS_Days; }
        }

        public string KPS_KDCode
        {
            set { _KPS_KDCode = value; }
            get { return _KPS_KDCode; }
        }

        public int KPS_ScNumber
        {
            set { _KPS_ScNumber = value; }
            get { return _KPS_ScNumber; }
        }

        public int KPS_Flow
        {
            set { _KPS_Flow = value; }
            get { return _KPS_Flow; }
        }

        public int KPS_State
        {
            set { _KPS_State = value; }
            get { return _KPS_State; }
        }

        public string KPS_SuppCode
        {
            set { _KPS_SuppCode = value; }
            get { return _KPS_SuppCode; }
        }

        public decimal KPS_KPMaxMoney
        {
            set { _KPS_KPMaxMoney = value; }
            get { return _KPS_KPMaxMoney; }
        }
        public int KPS_MaxRow
        {
            set { _KPS_MaxRow = value; }
            get { return _KPS_MaxRow; }
        }

        public int KPS_GiveDays
        {
            set { _KPS_GiveDays = value; }
            get { return _KPS_GiveDays; }
        }
        

        #endregion Model

    }
}

