using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// PB_Products_Brand_Details
    /// </summary>
    public partial class PB_Products_Brand_Details
    {
        private readonly KNet.DAL.PB_Products_Brand_Details dal = new KNet.DAL.PB_Products_Brand_Details();
        public PB_Products_Brand_Details()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PPBD_ID)
        {
            return dal.Exists(PPBD_ID);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(KNet.Model.PB_Products_Brand_Details model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 修改一条数据
        /// </summary>
        public bool Update(KNet.Model.PB_Products_Brand_Details model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string PPBD_ID)
        {
            return dal.Delete(PPBD_ID);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public bool UpdateDel(KNet.Model.PB_Products_Brand_Details model)
        {
            return dal.UpdateDel(model);
        }
        /// <summary>
        /// 批量删除一条数据
        /// </summary>
        public bool DeleteList(string PPBD_ID)
        {
            return dal.DeleteList(PPBD_ID);
        }
        /// <summary>
        ///删除父节点数据
        /// </summary>
        public bool DeleteByFID(string PPBD_ID)
        {
            return dal.DeleteByFID(PPBD_ID);
        }
        /// <summary>
        ///获取类
        /// </summary>
        public KNet.Model.PB_Products_Brand_Details GetModel(string PPBD_ID)
        {
            return dal.GetModel(PPBD_ID);
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
