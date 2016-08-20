using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// 业务逻辑类KNet_Resource_Staff
    /// </summary>
    public class KNet_Resource_Staff
    {
        private readonly KNet.DAL.KNet_Resource_Staff dal = new KNet.DAL.KNet_Resource_Staff();
        public KNet_Resource_Staff()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录 账号
        /// </summary>
        public bool Exists(string StaffBranch, string StaffName)
        {
            return dal.Exists(StaffBranch, StaffName);
        }
        /// <summary>
        /// 是否存在该记录 卡号
        /// </summary>
        public bool ExistsB(string StaffBranch, string StaffCard)
        {
            return dal.ExistsB(StaffBranch,StaffCard);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.KNet_Resource_Staff model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(KNet.Model.KNet_Resource_Staff model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateOnLine(KNet.Model.KNet_Resource_Staff model)
        {
            dal.UpdateOnLine(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string ID)
        {

            dal.Delete(ID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Resource_Staff GetModel(string ID)
        {
            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Resource_Staff GetModelC(string StaffNo)
        {
            return dal.GetModelC(StaffNo);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Resource_Staff GetModelByName(string s_Name)
        {
            return dal.GetModelByName(s_Name);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Resource_Staff GetModelB(string StaffName, string KStaffPassWord)
        {
            return dal.GetModelB(StaffName, KStaffPassWord);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        public string  GetSonIDs(string ID)
        {
            return dal.GetSonIDs(ID);
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

