using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
using System.Text;
using KNet.DBUtility;
namespace KNet.BLL
{
    /// <summary>
    /// 业务逻辑类KNet_Sales_ReturnList_Details 的摘要说明。
    /// </summary>
    public class KNet_Sales_ReturnList_Details
    {
        private readonly KNet.DAL.KNet_Sales_ReturnList_Details dal = new KNet.DAL.KNet_Sales_ReturnList_Details();
        public KNet_Sales_ReturnList_Details()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ReturnNo, string ProductsBarCode)
        {
            return dal.Exists(ReturnNo, ProductsBarCode);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.KNet_Sales_ReturnList_Details model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据 （在明细里修改）
        /// </summary>
        public void Update(KNet.Model.KNet_Sales_ReturnList_Details model)
        {
            dal.Update(model);
        }
        /// <summary>
        /// 更新一条数据 （添加时追加记录）
        /// </summary>
        public void UpdateB(KNet.Model.KNet_Sales_ReturnList_Details model)
        {
            dal.UpdateB(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string ID, string OutWareNo, string ProductsBarCode)
        {

            dal.Delete(ID, OutWareNo, ProductsBarCode);
        }
        public void DeleteByReturnNo(string ID)
        {

            dal.DeleteByReturnNo(ID);
        }
        
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Sales_ReturnList_Details GetModel(string ID)
        {

            return dal.GetModel(ID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Sales_ReturnList_Details GetModelB(string ReturnNo, string ProductsBarCode)
        {

            return dal.GetModelB(ReturnNo, ProductsBarCode);
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



        #endregion  成员方法
    }
}


