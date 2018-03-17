using System;
using System.Data;
using System.Collections.Generic;
using KNet.Common;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// PB_Basic_Menu
    /// </summary>
    public partial class PB_Basic_Menu
    {
        private readonly KNet.DAL.PB_Basic_Menu dal = new KNet.DAL.PB_Basic_Menu();
        public PB_Basic_Menu()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PBM_ID)
        {
            return dal.Exists(PBM_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.PB_Basic_Menu model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.PB_Basic_Menu model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string PBM_ID)
        {

            return dal.Delete(PBM_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string PBM_IDlist)
        {
            return dal.DeleteList(PBM_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.PB_Basic_Menu GetModel(string PBM_ID)
        {

            return dal.GetModel(PBM_ID);
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
        public List<KNet.Model.PB_Basic_Menu> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.PB_Basic_Menu> DataTableToList(DataTable dt)
        {
            List<KNet.Model.PB_Basic_Menu> modelList = new List<KNet.Model.PB_Basic_Menu>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.PB_Basic_Menu model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.PB_Basic_Menu();
                    if (dt.Rows[n]["PBM_ID"] != null && dt.Rows[n]["PBM_ID"].ToString() != "")
                    {
                        model.PBM_ID = dt.Rows[n]["PBM_ID"].ToString();
                    }
                    if (dt.Rows[n]["PBM_FatherID"] != null && dt.Rows[n]["PBM_FatherID"].ToString() != "")
                    {
                        model.PBM_FatherID = dt.Rows[n]["PBM_FatherID"].ToString();
                    }
                    if (dt.Rows[n]["PBM_Name"] != null && dt.Rows[n]["PBM_Name"].ToString() != "")
                    {
                        model.PBM_Name = dt.Rows[n]["PBM_Name"].ToString();
                    }
                    if (dt.Rows[n]["PBM_Module"] != null && dt.Rows[n]["PBM_Module"].ToString() != "")
                    {
                        model.PBM_Module = dt.Rows[n]["PBM_Module"].ToString();
                    }
                    if (dt.Rows[n]["PBM_Parenttab"] != null && dt.Rows[n]["PBM_Parenttab"].ToString() != "")
                    {
                        model.PBM_Parenttab = dt.Rows[n]["PBM_Parenttab"].ToString();
                    }
                    if (dt.Rows[n]["PBM_URL"] != null && dt.Rows[n]["PBM_URL"].ToString() != "")
                    {
                        model.PBM_URL = dt.Rows[n]["PBM_URL"].ToString();
                    }
                    if (dt.Rows[n]["PBM_Del"] != null && dt.Rows[n]["PBM_Del"].ToString() != "")
                    {
                        model.PBM_Del = dt.Rows[n]["PBM_Del"].ToString();
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
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  Method
    }
}

