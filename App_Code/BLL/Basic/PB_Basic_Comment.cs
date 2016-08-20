using System;
using System.Data;
using System.Collections.Generic;
using KNet.Common;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// PB_Basic_Comment
    /// </summary>
    public partial class PB_Basic_Comment
    {
        private readonly KNet.DAL.PB_Basic_Comment dal = new KNet.DAL.PB_Basic_Comment();
        public PB_Basic_Comment()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PBC_ID)
        {
            return dal.Exists(PBC_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(KNet.Model.PB_Basic_Comment model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.PB_Basic_Comment model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string PBC_ID)
        {

            return dal.Delete(PBC_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string PBC_IDlist)
        {
            return dal.DeleteList(PBC_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.PB_Basic_Comment GetModel(string PBC_ID)
        {

            return dal.GetModel(PBC_ID);
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
        public List<KNet.Model.PB_Basic_Comment> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.PB_Basic_Comment> DataTableToList(DataTable dt)
        {
            List<KNet.Model.PB_Basic_Comment> modelList = new List<KNet.Model.PB_Basic_Comment>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.PB_Basic_Comment model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.PB_Basic_Comment();
                    if (dt.Rows[n]["PBC_ID"] != null && dt.Rows[n]["PBC_ID"].ToString() != "")
                    {
                        model.PBC_ID = dt.Rows[n]["PBC_ID"].ToString();
                    }
                    if (dt.Rows[n]["PBC_FID"] != null && dt.Rows[n]["PBC_FID"].ToString() != "")
                    {
                        model.PBC_FID = dt.Rows[n]["PBC_FID"].ToString();
                    }
                    if (dt.Rows[n]["PBC_FromPerson"] != null && dt.Rows[n]["PBC_FromPerson"].ToString() != "")
                    {
                        model.PBC_FromPerson = dt.Rows[n]["PBC_FromPerson"].ToString();
                    }
                    if (dt.Rows[n]["PBC_PresetCode"] != null && dt.Rows[n]["PBC_PresetCode"].ToString() != "")
                    {
                        model.PBC_PresetCode = int.Parse(dt.Rows[n]["PBC_PresetCode"].ToString());
                    }
                    if (dt.Rows[n]["PBC_Description"] != null && dt.Rows[n]["PBC_Description"].ToString() != "")
                    {
                        model.PBC_Description = dt.Rows[n]["PBC_Description"].ToString();
                    }
                    if (dt.Rows[n]["PBC_CTime"] != null && dt.Rows[n]["PBC_CTime"].ToString() != "")
                    {
                        model.PBC_CTime = DateTime.Parse(dt.Rows[n]["PBC_CTime"].ToString());
                    }
                    if (dt.Rows[n]["PBC_Type"] != null && dt.Rows[n]["PBC_Type"].ToString() != "")
                    {
                        model.PBC_Type = int.Parse(dt.Rows[n]["PBC_Type"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
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
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
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

