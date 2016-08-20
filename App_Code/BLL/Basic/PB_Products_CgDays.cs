using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// PB_Products_CgDays
    /// </summary>
    public partial class PB_Products_CgDays
    {
        private readonly KNet.DAL.PB_Products_CgDays dal = new KNet.DAL.PB_Products_CgDays();
        public PB_Products_CgDays()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PPC_ID)
        {
            return dal.Exists(PPC_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.PB_Products_CgDays model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.PB_Products_CgDays model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string PPC_ID)
        {

            return dal.Delete(PPC_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteByProductsBarCode(string ProductsBarCode)
        {

            return dal.DeleteByProductsBarCode(ProductsBarCode);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string PPC_IDlist)
        {
            return dal.DeleteList(PPC_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.PB_Products_CgDays GetModel(string PPC_ID)
        {

            return dal.GetModel(PPC_ID);
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
        public List<KNet.Model.PB_Products_CgDays> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.PB_Products_CgDays> DataTableToList(DataTable dt)
        {
            List<KNet.Model.PB_Products_CgDays> modelList = new List<KNet.Model.PB_Products_CgDays>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.PB_Products_CgDays model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.PB_Products_CgDays();
                    if (dt.Rows[n]["PPC_ID"] != null && dt.Rows[n]["PPC_ID"].ToString() != "")
                    {
                        model.PPC_ID = dt.Rows[n]["PPC_ID"].ToString();
                    }
                    if (dt.Rows[n]["PPC_Min"] != null && dt.Rows[n]["PPC_Min"].ToString() != "")
                    {
                        model.PPC_Min = decimal.Parse(dt.Rows[n]["PPC_Min"].ToString());
                    }
                    if (dt.Rows[n]["PPC_Max"] != null && dt.Rows[n]["PPC_Max"].ToString() != "")
                    {
                        model.PPC_Max = decimal.Parse(dt.Rows[n]["PPC_Max"].ToString());
                    }
                    if (dt.Rows[n]["PPC_Days"] != null && dt.Rows[n]["PPC_Days"].ToString() != "")
                    {
                        model.PPC_Days = int.Parse(dt.Rows[n]["PPC_Days"].ToString());
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

