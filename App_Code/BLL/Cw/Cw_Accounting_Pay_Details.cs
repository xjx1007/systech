using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// Cw_Accounting_Pay_Details
    /// </summary>
    public partial class Cw_Accounting_Pay_Details
    {
        private readonly KNet.DAL.Cw_Accounting_Pay_Details dal = new KNet.DAL.Cw_Accounting_Pay_Details();
        public Cw_Accounting_Pay_Details()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CAY_ID)
        {
            return dal.Exists(CAY_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Cw_Accounting_Pay_Details model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Cw_Accounting_Pay_Details model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string CAY_ID)
        {

            return dal.Delete(CAY_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteByCAAID(string CAY_CAAID)
        {

            return dal.DeleteByCAAID(CAY_CAAID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string CAY_IDlist)
        {
            return dal.DeleteList(CAY_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Cw_Accounting_Pay_Details GetModel(string CAY_ID)
        {

            return dal.GetModel(CAY_ID);
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

