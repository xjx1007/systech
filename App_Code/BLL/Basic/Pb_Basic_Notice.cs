using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// Pb_Basic_Notice
    /// </summary>
    public partial class Pb_Basic_Notice
    {
        private readonly KNet.DAL.Pb_Basic_Notice dal = new KNet.DAL.Pb_Basic_Notice();
        public Pb_Basic_Notice()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PBN_ID)
        {
            return dal.Exists(PBN_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Pb_Basic_Notice model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Pb_Basic_Notice model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string PBN_ID)
        {

            return dal.Delete(PBN_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string PBN_IDlist)
        {
            return dal.DeleteList(PBN_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Pb_Basic_Notice GetModel(string PBN_ID)
        {

            return dal.GetModel(PBN_ID);
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
        public List<KNet.Model.Pb_Basic_Notice> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.Pb_Basic_Notice> DataTableToList(DataTable dt)
        {
            List<KNet.Model.Pb_Basic_Notice> modelList = new List<KNet.Model.Pb_Basic_Notice>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.Pb_Basic_Notice model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.Pb_Basic_Notice();
                    if (dt.Rows[n]["PBN_ID"] != null && dt.Rows[n]["PBN_ID"].ToString() != "")
                    {
                        model.PBN_ID = dt.Rows[n]["PBN_ID"].ToString();
                    }
                    if (dt.Rows[n]["PBN_Title"] != null && dt.Rows[n]["PBN_Title"].ToString() != "")
                    {
                        model.PBN_Title = dt.Rows[n]["PBN_Title"].ToString();
                    }
                    if (dt.Rows[n]["PBN_Type"] != null && dt.Rows[n]["PBN_Type"].ToString() != "")
                    {
                        model.PBN_Type = dt.Rows[n]["PBN_Type"].ToString();
                    }
                    if (dt.Rows[n]["PBN_BeginTime"] != null && dt.Rows[n]["PBN_BeginTime"].ToString() != "")
                    {
                        model.PBN_BeginTime = DateTime.Parse(dt.Rows[n]["PBN_BeginTime"].ToString());
                    }
                    if (dt.Rows[n]["PBN_EndTime"] != null && dt.Rows[n]["PBN_EndTime"].ToString() != "")
                    {
                        model.PBN_EndTime = DateTime.Parse(dt.Rows[n]["PBN_EndTime"].ToString());
                    }
                    if (dt.Rows[n]["PBN_ReceiveID"] != null && dt.Rows[n]["PBN_ReceiveID"].ToString() != "")
                    {
                        model.PBN_ReceiveID = dt.Rows[n]["PBN_ReceiveID"].ToString();
                    }
                    if (dt.Rows[n]["PBN_Details"] != null && dt.Rows[n]["PBN_Details"].ToString() != "")
                    {
                        model.PBN_Details = dt.Rows[n]["PBN_Details"].ToString();
                    }
                    if (dt.Rows[n]["PBN_CTime"] != null && dt.Rows[n]["PBN_CTime"].ToString() != "")
                    {
                        model.PBN_CTime = DateTime.Parse(dt.Rows[n]["PBN_CTime"].ToString());
                    }
                    if (dt.Rows[n]["PBN_Creator"] != null && dt.Rows[n]["PBN_Creator"].ToString() != "")
                    {
                        model.PBN_Creator = dt.Rows[n]["PBN_Creator"].ToString();
                    }
                    if (dt.Rows[n]["PBN_MTime"] != null && dt.Rows[n]["PBN_MTime"].ToString() != "")
                    {
                        model.PBN_MTime = DateTime.Parse(dt.Rows[n]["PBN_MTime"].ToString());
                    }
                    if (dt.Rows[n]["PBN_Mender"] != null && dt.Rows[n]["PBN_Mender"].ToString() != "")
                    {
                        model.PBN_Mender = dt.Rows[n]["PBN_Mender"].ToString();
                    }
                    if (dt.Rows[n]["PBN_Del"] != null && dt.Rows[n]["PBN_Del"].ToString() != "")
                    {
                        model.PBN_Del = int.Parse(dt.Rows[n]["PBN_Del"].ToString());
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

