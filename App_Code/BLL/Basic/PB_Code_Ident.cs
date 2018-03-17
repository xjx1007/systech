using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// PB_Code_Ident
    /// </summary>
    public partial class PB_Code_Ident
    {
        private readonly KNet.DAL.PB_Code_Ident dal = new KNet.DAL.PB_Code_Ident();
        public PB_Code_Ident()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PCI_Table)
        {
            return dal.Exists(PCI_Table);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.PB_Code_Ident model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.PB_Code_Ident model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string PCI_Table)
        {

            return dal.Delete(PCI_Table);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string PCI_Tablelist)
        {
            return dal.DeleteList(PCI_Tablelist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.PB_Code_Ident GetModel(string PCI_Table)
        {

            return dal.GetModel(PCI_Table);
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
        public List<KNet.Model.PB_Code_Ident> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.PB_Code_Ident> DataTableToList(DataTable dt)
        {
            List<KNet.Model.PB_Code_Ident> modelList = new List<KNet.Model.PB_Code_Ident>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.PB_Code_Ident model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.PB_Code_Ident();
                    if (dt.Rows[n]["PCI_Table"] != null && dt.Rows[n]["PCI_Table"].ToString() != "")
                    {
                        model.PCI_Table = dt.Rows[n]["PCI_Table"].ToString();
                    }
                    if (dt.Rows[n]["PCI_Type"] != null && dt.Rows[n]["PCI_Type"].ToString() != "")
                    {
                        model.PCI_Type = dt.Rows[n]["PCI_Type"].ToString();
                    }
                    if (dt.Rows[n]["PCI_Length"] != null && dt.Rows[n]["PCI_Length"].ToString() != "")
                    {
                        model.PCI_Length = int.Parse(dt.Rows[n]["PCI_Length"].ToString());
                    }
                    if (dt.Rows[n]["PCI_Head"] != null && dt.Rows[n]["PCI_Head"].ToString() != "")
                    {
                        model.PCI_Head = dt.Rows[n]["PCI_Head"].ToString();
                    }
                    if (dt.Rows[n]["PCI_Fill"] != null && dt.Rows[n]["PCI_Fill"].ToString() != "")
                    {
                        model.PCI_Fill = dt.Rows[n]["PCI_Fill"].ToString();
                    }
                    if (dt.Rows[n]["PCI_Date"] != null && dt.Rows[n]["PCI_Date"].ToString() != "")
                    {
                        model.PCI_Date = DateTime.Parse(dt.Rows[n]["PCI_Date"].ToString());
                    }
                    if (dt.Rows[n]["PCI_Default"] != null && dt.Rows[n]["PCI_Default"].ToString() != "")
                    {
                        model.PCI_Default = decimal.Parse(dt.Rows[n]["PCI_Default"].ToString());
                    }
                    if (dt.Rows[n]["PCI_Identity"] != null && dt.Rows[n]["PCI_Identity"].ToString() != "")
                    {
                        model.PCI_Identity = decimal.Parse(dt.Rows[n]["PCI_Identity"].ToString());
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

