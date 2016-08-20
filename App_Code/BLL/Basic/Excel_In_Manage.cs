using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// Excel_In_Manage
    /// </summary>
    public partial class Excel_In_Manage
    {
        private readonly KNet.DAL.Excel_In_Manage dal = new KNet.DAL.Excel_In_Manage();
        public Excel_In_Manage()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string EIM_ID)
        {
            return dal.Exists(EIM_ID);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(KNet.Model.Excel_In_Manage model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 修改一条数据
        /// </summary>
        public bool Update(KNet.Model.Excel_In_Manage model)
        {
            return dal.Update(model);
        }
        /// <summary>
        ///删除父节点数据
        /// </summary>
        public bool DeleteByFID(string EIM_ID)
        {
            return dal.DeleteByFID(EIM_ID);
        }
        /// <summary>
        ///删除父节点数据
        /// </summary>
        public KNet.Model.Excel_In_Manage GetModel(string EIM_ID)
        {
            return dal.GetModel(EIM_ID);
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
