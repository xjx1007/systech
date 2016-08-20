using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// Excel_In_Details
    /// </summary>
    public partial class Excel_In_Details
    {
        private readonly KNet.DAL.Excel_In_Details dal = new KNet.DAL.Excel_In_Details();
        public Excel_In_Details()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string EID_ID)
        {
            return dal.Exists(EID_ID);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(KNet.Model.Excel_In_Details model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 修改一条数据
        /// </summary>
        public bool Update(KNet.Model.Excel_In_Details model)
        {
            return dal.Update(model);
        }
        /// <summary>
        ///删除父节点数据
        /// </summary>
        public bool DeleteByFID(string EID_ID)
        {
            return dal.DeleteByFID(EID_ID);
        }
        /// <summary>
        ///删除父节点数据
        /// </summary>
        public KNet.Model.Excel_In_Details GetModel(string EID_ID)
        {
            return dal.GetModel(EID_ID);
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
