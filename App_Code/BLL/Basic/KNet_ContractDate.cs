using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// KNet_ContractDate
    /// </summary>
    public partial class KNet_ContractDate
    {
        private readonly KNet.DAL.KNet_ContractDate dal = new KNet.DAL.KNet_ContractDate();
        public KNet_ContractDate()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int KC_ID)
        {
            return dal.Exists(KC_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(KNet.Model.KNet_ContractDate model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.KNet_ContractDate model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int KC_ID)
        {

            return dal.Delete(KC_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string KC_IDlist)
        {
            return dal.DeleteList(KC_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_ContractDate GetModel(int KC_ID)
        {

            return dal.GetModel(KC_ID);
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public string GetOldDate(string s_ContractNo,int i_Type)
        {

            return dal.GetOldDate(s_ContractNo, i_Type);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  Method
    }
}

