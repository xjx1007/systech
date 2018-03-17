 using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// Xs_Sales_Freight
    /// </summary>
    public partial class Xs_Sales_Freight
    {
        private readonly KNet.DAL.Xs_Sales_Freight dal = new KNet.DAL.Xs_Sales_Freight();
        public Xs_Sales_Freight()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string XSF_ID)
        {
            return dal.Exists(XSF_ID);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsFID(string XSF_FID)
        {
            return dal.ExistsFID(XSF_FID);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(KNet.Model.Xs_Sales_Freight model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 修改一条数据
        /// </summary>
        public bool Update(KNet.Model.Xs_Sales_Freight model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string XSF_ID)
        {
            return dal.Delete(XSF_ID);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public bool UpdateDel(KNet.Model.Xs_Sales_Freight model)
        {
            return dal.UpdateDel(model);
        }
        /// <summary>
        /// 批量删除一条数据
        /// </summary>
        public bool DeleteList(string XSF_ID)
        {
            return dal.DeleteList(XSF_ID);
        }
        /// <summary>
        ///删除父节点数据
        /// </summary>
        public bool DeleteByFID(string XSF_ID)
        {
            return dal.DeleteByFID(XSF_ID);
        }
        /// <summary>
        ///删除父节点数据
        /// </summary>
        public KNet.Model.Xs_Sales_Freight GetModel(string XSF_ID)
        {
            return dal.GetModel(XSF_ID);
        }

        public KNet.Model.Xs_Sales_Freight GetModelByFID(string XSF_FID)
        {
            return dal.GetModelByFID(XSF_FID);
        }
        
        /// <summary>
        ///获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
    }
}
