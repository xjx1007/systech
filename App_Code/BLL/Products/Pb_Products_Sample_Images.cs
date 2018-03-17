using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// Pb_Products_Sample_Images
    /// </summary>
    public partial class Pb_Products_Sample_Images
    {
        private readonly KNet.DAL.Pb_Products_Sample_Images dal = new KNet.DAL.Pb_Products_Sample_Images();
        public Pb_Products_Sample_Images()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PPI_ID)
        {
            return dal.Exists(PPI_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Pb_Products_Sample_Images model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Pb_Products_Sample_Images model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string PPI_SmapleID, string PPI_Type)
        {

            return dal.Delete(PPI_SmapleID, PPI_Type);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string PPI_IDlist)
        {
            return dal.DeleteList(PPI_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Pb_Products_Sample_Images GetModel(string PPI_ID)
        {

            return dal.GetModel(PPI_ID);
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
        public List<KNet.Model.Pb_Products_Sample_Images> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.Pb_Products_Sample_Images> DataTableToList(DataTable dt)
        {
            List<KNet.Model.Pb_Products_Sample_Images> modelList = new List<KNet.Model.Pb_Products_Sample_Images>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.Pb_Products_Sample_Images model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.Pb_Products_Sample_Images();
                    if (dt.Rows[n]["PPI_ID"] != null && dt.Rows[n]["PPI_ID"].ToString() != "")
                    {
                        model.PPI_ID = dt.Rows[n]["PPI_ID"].ToString();
                    }
                    if (dt.Rows[n]["PPI_SmapleID"] != null && dt.Rows[n]["PPI_SmapleID"].ToString() != "")
                    {
                        model.PPI_SmapleID = dt.Rows[n]["PPI_SmapleID"].ToString();
                    }
                    if (dt.Rows[n]["PPI_URL"] != null && dt.Rows[n]["PPI_URL"].ToString() != "")
                    {
                        model.PPI_URL = dt.Rows[n]["PPI_URL"].ToString();
                    }
                    if (dt.Rows[n]["PPI_Name"] != null && dt.Rows[n]["PPI_Name"].ToString() != "")
                    {
                        model.PPI_Name = dt.Rows[n]["PPI_Name"].ToString();
                    }
                    if (dt.Rows[n]["PPI_URLName"] != null && dt.Rows[n]["PPI_URLName"].ToString() != "")
                    {
                        model.PPI_URLName = dt.Rows[n]["PPI_URLName"].ToString();
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

