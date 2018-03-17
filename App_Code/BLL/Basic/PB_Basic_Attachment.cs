using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// PB_Basic_Attachment
    /// </summary>
    public partial class PB_Basic_Attachment
    {
        private readonly KNet.DAL.PB_Basic_Attachment dal = new KNet.DAL.PB_Basic_Attachment();
        public PB_Basic_Attachment()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PBA_ID)
        {
            return dal.Exists(PBA_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.PB_Basic_Attachment model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.PB_Basic_Attachment model)
        {
            return dal.Update(model);
        }
        
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateByState(KNet.Model.PB_Basic_Attachment model)
        {
            return dal.UpdateByState(model);
        }
        
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateByDel(KNet.Model.PB_Basic_Attachment model)
        {
            return dal.UpdateByDel(model);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string PBA_ID)
        {

            return dal.Delete(PBA_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteByFID(string PBA_FID)
        {

            return dal.DeleteByFID(PBA_FID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string PBA_IDlist)
        {
            return dal.DeleteList(PBA_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.PB_Basic_Attachment GetModel(string PBA_ID)
        {

            return dal.GetModel(PBA_ID);
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
        public List<KNet.Model.PB_Basic_Attachment> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.PB_Basic_Attachment> DataTableToList(DataTable dt)
        {
            List<KNet.Model.PB_Basic_Attachment> modelList = new List<KNet.Model.PB_Basic_Attachment>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.PB_Basic_Attachment model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.PB_Basic_Attachment();
                    if (dt.Rows[n]["PBA_ID"] != null && dt.Rows[n]["PBA_ID"].ToString() != "")
                    {
                        model.PBA_ID = dt.Rows[n]["PBA_ID"].ToString();
                    }
                    if (dt.Rows[n]["PBA_FID"] != null && dt.Rows[n]["PBA_FID"].ToString() != "")
                    {
                        model.PBA_FID = dt.Rows[n]["PBA_FID"].ToString();
                    }
                    if (dt.Rows[n]["PBA_Name"] != null && dt.Rows[n]["PBA_Name"].ToString() != "")
                    {
                        model.PBA_Name = dt.Rows[n]["PBA_Name"].ToString();
                    }
                    if (dt.Rows[n]["PBA_Type"] != null && dt.Rows[n]["PBA_Type"].ToString() != "")
                    {
                        model.PBA_Type = dt.Rows[n]["PBA_Type"].ToString();
                    }
                    if (dt.Rows[n]["PBA_URL"] != null && dt.Rows[n]["PBA_URL"].ToString() != "")
                    {
                        model.PBA_URL = dt.Rows[n]["PBA_URL"].ToString();
                    }
                    if (dt.Rows[n]["PBA_Creator"] != null && dt.Rows[n]["PBA_Creator"].ToString() != "")
                    {
                        model.PBA_Creator = dt.Rows[n]["PBA_Creator"].ToString();
                    }
                    if (dt.Rows[n]["PBA_CTime"] != null && dt.Rows[n]["PBA_CTime"].ToString() != "")
                    {
                        model.PBA_CTime = DateTime.Parse(dt.Rows[n]["PBA_CTime"].ToString());
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

