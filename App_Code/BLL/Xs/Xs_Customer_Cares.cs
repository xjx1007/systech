using System;
using System.Data;
using System.Collections.Generic;
using KNet.Common;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// Xs_Customer_Cares
    /// </summary>
    public partial class Xs_Customer_Cares
    {
        private readonly KNet.DAL.Xs_Customer_Cares dal = new KNet.DAL.Xs_Customer_Cares();
        public Xs_Customer_Cares()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string XCC_Code)
        {
            return dal.Exists(XCC_Code);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Xs_Customer_Cares model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Xs_Customer_Cares model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string XCC_Code)
        {

            return dal.Delete(XCC_Code);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string XCC_Codelist)
        {
            return dal.DeleteList(XCC_Codelist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Xs_Customer_Cares GetModel(string XCC_Code)
        {

            return dal.GetModel(XCC_Code);
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
        public List<KNet.Model.Xs_Customer_Cares> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.Xs_Customer_Cares> DataTableToList(DataTable dt)
        {
            List<KNet.Model.Xs_Customer_Cares> modelList = new List<KNet.Model.Xs_Customer_Cares>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.Xs_Customer_Cares model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.Xs_Customer_Cares();
                    if (dt.Rows[n]["XCC_Code"] != null && dt.Rows[n]["XCC_Code"].ToString() != "")
                    {
                        model.XCC_Code = dt.Rows[n]["XCC_Code"].ToString();
                    }
                    if (dt.Rows[n]["XCC_Topic"] != null && dt.Rows[n]["XCC_Topic"].ToString() != "")
                    {
                        model.XCC_Topic = dt.Rows[n]["XCC_Topic"].ToString();
                    }
                    if (dt.Rows[n]["XCC_Stime"] != null && dt.Rows[n]["XCC_Stime"].ToString() != "")
                    {
                        model.XCC_Stime = DateTime.Parse(dt.Rows[n]["XCC_Stime"].ToString());
                    }
                    if (dt.Rows[n]["XCC_CustomerValue"] != null && dt.Rows[n]["XCC_CustomerValue"].ToString() != "")
                    {
                        model.XCC_CustomerValue = dt.Rows[n]["XCC_CustomerValue"].ToString();
                    }
                    if (dt.Rows[n]["XCC_LinkMan"] != null && dt.Rows[n]["XCC_LinkMan"].ToString() != "")
                    {
                        model.XCC_LinkMan = dt.Rows[n]["XCC_LinkMan"].ToString();
                    }
                    if (dt.Rows[n]["XCC_DutyPerson"] != null && dt.Rows[n]["XCC_DutyPerson"].ToString() != "")
                    {
                        model.XCC_DutyPerson = dt.Rows[n]["XCC_DutyPerson"].ToString();
                    }
                    if (dt.Rows[n]["XCC_CareTypes"] != null && dt.Rows[n]["XCC_CareTypes"].ToString() != "")
                    {
                        model.XCC_CareTypes = dt.Rows[n]["XCC_CareTypes"].ToString();
                    }
                    if (dt.Rows[n]["XCC_CareDetails"] != null && dt.Rows[n]["XCC_CareDetails"].ToString() != "")
                    {
                        model.XCC_CareDetails = dt.Rows[n]["XCC_CareDetails"].ToString();
                    }
                    if (dt.Rows[n]["XCC_CustomerDetails"] != null && dt.Rows[n]["XCC_CustomerDetails"].ToString() != "")
                    {
                        model.XCC_CustomerDetails = dt.Rows[n]["XCC_CustomerDetails"].ToString();
                    }
                    if (dt.Rows[n]["XCC_Remarks"] != null && dt.Rows[n]["XCC_Remarks"].ToString() != "")
                    {
                        model.XCC_Remarks = dt.Rows[n]["XCC_Remarks"].ToString();
                    }
                    if (dt.Rows[n]["XCC_Creator"] != null && dt.Rows[n]["XCC_Creator"].ToString() != "")
                    {
                        model.XCC_Creator = dt.Rows[n]["XCC_Creator"].ToString();
                    }
                    if (dt.Rows[n]["XCC_CTime"] != null && dt.Rows[n]["XCC_CTime"].ToString() != "")
                    {
                        model.XCC_CTime = DateTime.Parse(dt.Rows[n]["XCC_CTime"].ToString());
                    }
                    if (dt.Rows[n]["XCC_Mender"] != null && dt.Rows[n]["XCC_Mender"].ToString() != "")
                    {
                        model.XCC_Mender = dt.Rows[n]["XCC_Mender"].ToString();
                    }
                    if (dt.Rows[n]["XCC_MTime"] != null && dt.Rows[n]["XCC_MTime"].ToString() != "")
                    {
                        model.XCC_MTime = DateTime.Parse(dt.Rows[n]["XCC_MTime"].ToString());
                    }
                    if (dt.Rows[n]["XCC_Del"] != null && dt.Rows[n]["XCC_Del"].ToString() != "")
                    {
                        model.XCC_Del = int.Parse(dt.Rows[n]["XCC_Del"].ToString());
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

