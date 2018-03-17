using System;
using System.Data;
using System.Collections.Generic;
using KNet.Common;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// PB_Basic_Document
    /// </summary>
    public partial class PB_Basic_Document
    {
        private readonly KNet.DAL.PB_Basic_Document dal = new KNet.DAL.PB_Basic_Document();
        public PB_Basic_Document()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PBM_Name)
        {
            return dal.Exists(PBM_Name);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.PB_Basic_Document model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.PB_Basic_Document model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string PBM_Code)
        {

            return dal.Delete(PBM_Code);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string PBM_Codelist)
        {
            return dal.DeleteList(PBM_Codelist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.PB_Basic_Document GetModel(string PBM_Code)
        {

            return dal.GetModel(PBM_Code);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public string GetDocumentName(string PBM_Code)
        {
            return dal.GetDocumentName(PBM_Code);
        }

        /// <summary>
        /// 得到一个上一个名字相同的
        /// </summary>
        public KNet.Model.PB_Basic_Document GetLastModel(string PBM_Name)
        {

            return dal.GetLastModel(PBM_Name);
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
        public List<KNet.Model.PB_Basic_Document> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.PB_Basic_Document> DataTableToList(DataTable dt)
        {
            List<KNet.Model.PB_Basic_Document> modelList = new List<KNet.Model.PB_Basic_Document>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.PB_Basic_Document model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.PB_Basic_Document();
                    if (dt.Rows[n]["PBM_Code"] != null && dt.Rows[n]["PBM_Code"].ToString() != "")
                    {
                        model.PBM_Code = dt.Rows[n]["PBM_Code"].ToString();
                    }
                    if (dt.Rows[n]["PBM_Name"] != null && dt.Rows[n]["PBM_Name"].ToString() != "")
                    {
                        model.PBM_Name = dt.Rows[n]["PBM_Name"].ToString();
                    }
                    if (dt.Rows[n]["PBM_Type"] != null && dt.Rows[n]["PBM_Type"].ToString() != "")
                    {
                        model.PBM_Type = dt.Rows[n]["PBM_Type"].ToString();
                    }
                    if (dt.Rows[n]["PBM_DutyPerson"] != null && dt.Rows[n]["PBM_DutyPerson"].ToString() != "")
                    {
                        model.PBM_DutyPerson = dt.Rows[n]["PBM_DutyPerson"].ToString();
                    }
                    if (dt.Rows[n]["PBM_Details"] != null && dt.Rows[n]["PBM_Details"].ToString() != "")
                    {
                        model.PBM_Details = dt.Rows[n]["PBM_Details"].ToString();
                    }
                    if (dt.Rows[n]["PBM_Del"] != null && dt.Rows[n]["PBM_Del"].ToString() != "")
                    {
                        model.PBM_Del = dt.Rows[n]["PBM_Del"].ToString();
                    }
                    if (dt.Rows[n]["PBM_CTime"] != null && dt.Rows[n]["PBM_CTime"].ToString() != "")
                    {
                        model.PBM_CTime = DateTime.Parse(dt.Rows[n]["PBM_CTime"].ToString());
                    }
                    if (dt.Rows[n]["PBM_Creator"] != null && dt.Rows[n]["PBM_Creator"].ToString() != "")
                    {
                        model.PBM_Creator = dt.Rows[n]["PBM_Creator"].ToString();
                    }
                    if (dt.Rows[n]["PBM_Mtime"] != null && dt.Rows[n]["PBM_Mtime"].ToString() != "")
                    {
                        model.PBM_Mtime = DateTime.Parse(dt.Rows[n]["PBM_Mtime"].ToString());
                    }
                    if (dt.Rows[n]["PBM_Mender"] != null && dt.Rows[n]["PBM_Mender"].ToString() != "")
                    {
                        model.PBM_Mender = dt.Rows[n]["PBM_Mender"].ToString();
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

