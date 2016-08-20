using System;
using System.Data;
using System.Collections.Generic;
using KNet.Common;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// KNet_Reports_Submit_Type
    /// </summary>
    public partial class KNet_Reports_Submit_Type
    {
        private readonly KNet.DAL.KNet_Reports_Submit_Type dal = new KNet.DAL.KNet_Reports_Submit_Type();
        public KNet_Reports_Submit_Type()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string KRT_ID)
        {
            return dal.Exists(KRT_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(KNet.Model.KNet_Reports_Submit_Type model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.KNet_Reports_Submit_Type model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string GetCode(KNet.Model.KNet_Reports_Submit_Type model)
        {
            return dal.GetCode(model);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string KRT_ID)
        {

            return dal.Delete(KRT_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string KRT_IDlist)
        {
            return dal.DeleteList(KRT_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Reports_Submit_Type GetModel(string KRT_ID)
        {

            return dal.GetModel(KRT_ID);
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
        public List<KNet.Model.KNet_Reports_Submit_Type> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.KNet_Reports_Submit_Type> DataTableToList(DataTable dt)
        {
            List<KNet.Model.KNet_Reports_Submit_Type> modelList = new List<KNet.Model.KNet_Reports_Submit_Type>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.KNet_Reports_Submit_Type model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.KNet_Reports_Submit_Type();
                    if (dt.Rows[n]["KRT_ID"] != null && dt.Rows[n]["KRT_ID"].ToString() != "")
                    {
                        model.KRT_ID = dt.Rows[n]["KRT_ID"].ToString();
                    }
                    if (dt.Rows[n]["KRT_Code"] != null && dt.Rows[n]["KRT_Code"].ToString() != "")
                    {
                        model.KRT_Code = dt.Rows[n]["KRT_Code"].ToString();
                    }
                    if (dt.Rows[n]["KRT_Depart"] != null && dt.Rows[n]["KRT_Depart"].ToString() != "")
                    {
                        model.KRT_Depart = dt.Rows[n]["KRT_Depart"].ToString();
                    }
                    if (dt.Rows[n]["KRT_Person"] != null && dt.Rows[n]["KRT_Person"].ToString() != "")
                    {
                        model.KRT_Person = dt.Rows[n]["KRT_Person"].ToString();
                    }
                    if (dt.Rows[n]["KRT_TypeName"] != null && dt.Rows[n]["KRT_TypeName"].ToString() != "")
                    {
                        model.KRT_TypeName = dt.Rows[n]["KRT_TypeName"].ToString();
                    }
                    if (dt.Rows[n]["KRT_Type"] != null && dt.Rows[n]["KRT_Type"].ToString() != "")
                    {
                        model.KRT_Type = int.Parse(dt.Rows[n]["KRT_Type"].ToString());
                    }
                    if (dt.Rows[n]["KRT_TypeTime"] != null && dt.Rows[n]["KRT_TypeTime"].ToString() != "")
                    {
                        model.KRT_TypeTime = int.Parse(dt.Rows[n]["KRT_TypeTime"].ToString());
                    }
                    if (dt.Rows[n]["KRT_Del"] != null && dt.Rows[n]["KRT_Del"].ToString() != "")
                    {
                        model.KRT_Del = int.Parse(dt.Rows[n]["KRT_Del"].ToString());
                    }
                    if (dt.Rows[n]["KRT_Creator"] != null && dt.Rows[n]["KRT_Creator"].ToString() != "")
                    {
                        model.KRT_Creator = dt.Rows[n]["KRT_Creator"].ToString();
                    }
                    if (dt.Rows[n]["KRT_CTime"] != null && dt.Rows[n]["KRT_CTime"].ToString() != "")
                    {
                        model.KRT_CTime = DateTime.Parse(dt.Rows[n]["KRT_CTime"].ToString());
                    }
                    if (dt.Rows[n]["KRT_MTime"] != null && dt.Rows[n]["KRT_MTime"].ToString() != "")
                    {
                        model.KRT_MTime = DateTime.Parse(dt.Rows[n]["KRT_MTime"].ToString());
                    }
                    if (dt.Rows[n]["KRT_Mender"] != null && dt.Rows[n]["KRT_Mender"].ToString() != "")
                    {
                        model.KRT_Mender = dt.Rows[n]["KRT_Mender"].ToString();
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

