using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
using System.IO;
using System.Collections;
namespace KNet.BLL
{
    /// <summary>
    /// PB_Basic_Share
    /// </summary>
    public partial class PB_Basic_Share
    {
        private readonly KNet.DAL.PB_Basic_Share dal = new KNet.DAL.PB_Basic_Share();
        public PB_Basic_Share()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PBS_ID)
        {
            return dal.Exists(PBS_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.PB_Basic_Share model)
        {
            dal.Add(model);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ArrayList Arr_Details)
        {
            if (Arr_Details != null)
            {
                for (int i = 0; i < Arr_Details.Count; i++)
                {
                    KNet.Model.PB_Basic_Share model = (KNet.Model.PB_Basic_Share)Arr_Details[i];
                    dal.Add(model);
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.PB_Basic_Share model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string PBS_ID)
        {

            return dal.Delete(PBS_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool deleteOldNoToID(KNet.Model.PB_Basic_Share model)
        {

            return dal.deleteOldNoToID(model);
        }
        
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string PBS_IDlist)
        {
            return dal.DeleteList(PBS_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.PB_Basic_Share GetModel(string PBS_ID)
        {

            return dal.GetModel(PBS_ID);
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

        #endregion  Method
    }
}

