using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// PB_Basic_Code
    /// </summary>
    public partial class PB_Basic_Code
    {
        private readonly KNet.DAL.PB_Basic_Code dal = new KNet.DAL.PB_Basic_Code();
        public PB_Basic_Code()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PBC_ID, string PBC_Code)
        {
            return dal.Exists(PBC_ID, PBC_Code);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.PB_Basic_Code model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.PB_Basic_Code model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string PBC_ID, string PBC_Code)
        {

            return dal.Delete(PBC_ID, PBC_Code);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.PB_Basic_Code GetModel(string PBC_ID, string PBC_Code)
        {

            return dal.GetModel(PBC_ID, PBC_Code);
        }

        /// <summary>
        /// 得到一个最大编码值
        /// </summary>
        public string GetMaxCodeByID(string PBC_ID)
        {

            return dal.GetMaxCodeByID(PBC_ID);
        }
        /// <summary>
        /// 得到一个最大ID
        /// </summary>
        public string GetMaxID()
        {

            return dal.GetMaxID();
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
        public List<KNet.Model.PB_Basic_Code> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.PB_Basic_Code> DataTableToList(DataTable dt)
        {
            List<KNet.Model.PB_Basic_Code> modelList = new List<KNet.Model.PB_Basic_Code>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.PB_Basic_Code model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.PB_Basic_Code();
                    if (dt.Rows[n]["PBC_ID"] != null && dt.Rows[n]["PBC_ID"].ToString() != "")
                    {
                        model.PBC_ID = dt.Rows[n]["PBC_ID"].ToString();
                    }
                    if (dt.Rows[n]["PBC_Code"] != null && dt.Rows[n]["PBC_Code"].ToString() != "")
                    {
                        model.PBC_Code = dt.Rows[n]["PBC_Code"].ToString();
                    }
                    if (dt.Rows[n]["PBC_Name"] != null && dt.Rows[n]["PBC_Name"].ToString() != "")
                    {
                        model.PBC_Name = dt.Rows[n]["PBC_Name"].ToString();
                    }
                    if (dt.Rows[n]["PBC_Order"] != null && dt.Rows[n]["PBC_Order"].ToString() != "")
                    {
                        model.PBC_Order = int.Parse(dt.Rows[n]["PBC_Order"].ToString());
                    }
                    if (dt.Rows[n]["PBC_Del"] != null && dt.Rows[n]["PBC_Del"].ToString() != "")
                    {
                        model.PBC_Del = int.Parse(dt.Rows[n]["PBC_Del"].ToString());
                    }
                    if (dt.Rows[n]["PBC_Details"] != null && dt.Rows[n]["PBC_Details"].ToString() != "")
                    {
                        model.PBC_Details = dt.Rows[n]["PBC_Details"].ToString();
                    }
                    if (dt.Rows[n]["PBC_CName"] != null && dt.Rows[n]["PBC_CName"].ToString() != "")
                    {
                        model.PBC_CName = dt.Rows[n]["PBC_CName"].ToString();
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

