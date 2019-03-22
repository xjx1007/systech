using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// Sc_Products_MakeMoney
    /// </summary>
    public partial class Sc_Products_MakeMoney
    {
        private readonly KNet.DAL.Sc_Products_MakeMoney dal = new KNet.DAL.Sc_Products_MakeMoney();
        public Sc_Products_MakeMoney()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ID)
        {
            return dal.Exists(ID);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(KNet.Model.Sc_Products_MakeMoney model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 修改一条数据
        /// </summary>
        public bool Update(KNet.Model.Sc_Products_MakeMoney model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string ID)
        {
            return dal.Delete(ID);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public bool UpdateDel(KNet.Model.Sc_Products_MakeMoney model)
        {
            return dal.UpdateDel(model);
        }
        /// <summary>
        /// 批量删除一条数据
        /// </summary>
        public bool DeleteList(string ID)
        {
            return dal.DeleteList(ID);
        }
        /// <summary>
        ///删除父节点数据
        /// </summary>
        public bool DeleteByFID(string ID)
        {
            return dal.DeleteByFID(ID);
        }
        ///// <summary>
        /////删除父节点数据
        ///// </summary>
        //public KNet.Model.Sc_Products_MakeMoney QueryByFID(string ID)
        //{
        //    return dal.QueryByFID(ID);
        //}
        /// <summary>
        ///获取类
        /// </summary>
        public KNet.Model.Sc_Products_MakeMoney GetModel(string ID)
        {
            return dal.GetModel(ID);
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
