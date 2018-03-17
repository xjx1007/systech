using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// PB_Code_Sequence
    /// </summary>
    public partial class PB_Code_Sequence
    {
        private readonly KNet.DAL.PB_Code_Sequence dal = new KNet.DAL.PB_Code_Sequence();
        public PB_Code_Sequence()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PCS_Table, string PCS_Type)
        {
            return dal.Exists(PCS_Table, PCS_Type);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.PB_Code_Sequence model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.PB_Code_Sequence model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string PCS_Table, string PCS_Type)
        {

            return dal.Delete(PCS_Table, PCS_Type);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.PB_Code_Sequence GetModel(string PCS_Table, string PCS_Type)
        {

            return dal.GetModel(PCS_Table, PCS_Type);
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
        public List<KNet.Model.PB_Code_Sequence> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.PB_Code_Sequence> DataTableToList(DataTable dt)
        {
            List<KNet.Model.PB_Code_Sequence> modelList = new List<KNet.Model.PB_Code_Sequence>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.PB_Code_Sequence model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.PB_Code_Sequence();
                    if (dt.Rows[n]["PCS_Table"] != null && dt.Rows[n]["PCS_Table"].ToString() != "")
                    {
                        model.PCS_Table = dt.Rows[n]["PCS_Table"].ToString();
                    }
                    if (dt.Rows[n]["PCS_Date"] != null && dt.Rows[n]["PCS_Date"].ToString() != "")
                    {
                        model.PCS_Date = DateTime.Parse(dt.Rows[n]["PCS_Date"].ToString());
                    }
                    if (dt.Rows[n]["PCS_Type"] != null && dt.Rows[n]["PCS_Type"].ToString() != "")
                    {
                        model.PCS_Type = dt.Rows[n]["PCS_Type"].ToString();
                    }
                    if (dt.Rows[n]["PCS_Identity"] != null && dt.Rows[n]["PCS_Identity"].ToString() != "")
                    {
                        model.PCS_Identity = decimal.Parse(dt.Rows[n]["PCS_Identity"].ToString());
                    }
                    if (dt.Rows[n]["PCS_Default"] != null && dt.Rows[n]["PCS_Default"].ToString() != "")
                    {
                        model.PCS_Default = decimal.Parse(dt.Rows[n]["PCS_Default"].ToString());
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

