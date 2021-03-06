﻿using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// 业务逻辑类KNet_Sys_CheckNotes
    /// </summary>
    public class KNet_Sys_CheckNotes
    {
        private readonly KNet.DAL.KNet_Sys_CheckNotes dal = new KNet.DAL.KNet_Sys_CheckNotes();
        public KNet_Sys_CheckNotes()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string NotesName)
        {
            return dal.Exists(NotesName);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.KNet_Sys_CheckNotes model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(KNet.Model.KNet_Sys_CheckNotes model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
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

