using System;
using System.Data;
using System.Collections.Generic;
using KNet.Common;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// Xs_Sales_Content
    /// </summary>
    public partial class Xs_Sales_Content
    {
        private readonly KNet.DAL.Xs_Sales_Content dal = new KNet.DAL.Xs_Sales_Content();
        public Xs_Sales_Content()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string XSC_ID)
        {
            return dal.Exists(XSC_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Xs_Sales_Content model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Xs_Sales_Content model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string XSC_ID)
        {

            return dal.Delete(XSC_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string XSC_IDlist)
        {
            return dal.DeleteList(XSC_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Xs_Sales_Content GetModel(string XSC_ID)
        {

            return dal.GetModel(XSC_ID);
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
        public List<KNet.Model.Xs_Sales_Content> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.Xs_Sales_Content> DataTableToList(DataTable dt)
        {
            List<KNet.Model.Xs_Sales_Content> modelList = new List<KNet.Model.Xs_Sales_Content>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.Xs_Sales_Content model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.Xs_Sales_Content();
                    if (dt.Rows[n]["XSC_ID"] != null && dt.Rows[n]["XSC_ID"].ToString() != "")
                    {
                        model.XSC_ID = dt.Rows[n]["XSC_ID"].ToString();
                    }
                    if (dt.Rows[n]["XSC_CustomerValue"] != null && dt.Rows[n]["XSC_CustomerValue"].ToString() != "")
                    {
                        model.XSC_CustomerValue = dt.Rows[n]["XSC_CustomerValue"].ToString();
                    }
                    if (dt.Rows[n]["XSC_LinkMan"] != null && dt.Rows[n]["XSC_LinkMan"].ToString() != "")
                    {
                        model.XSC_LinkMan = dt.Rows[n]["XSC_LinkMan"].ToString();
                    }
                    if (dt.Rows[n]["XSC_Topic"] != null && dt.Rows[n]["XSC_Topic"].ToString() != "")
                    {
                        model.XSC_Topic = dt.Rows[n]["XSC_Topic"].ToString();
                    }
                    if (dt.Rows[n]["XSC_Stime"] != null && dt.Rows[n]["XSC_Stime"].ToString() != "")
                    {
                        model.XSC_Stime = DateTime.Parse(dt.Rows[n]["XSC_Stime"].ToString());
                    }
                    if (dt.Rows[n]["XSC_DutyPerson"] != null && dt.Rows[n]["XSC_DutyPerson"].ToString() != "")
                    {
                        model.XSC_DutyPerson = dt.Rows[n]["XSC_DutyPerson"].ToString();
                    }
                    if (dt.Rows[n]["XSC_Types"] != null && dt.Rows[n]["XSC_Types"].ToString() != "")
                    {
                        model.XSC_Types = dt.Rows[n]["XSC_Types"].ToString();
                    }
                    if (dt.Rows[n]["XSC_Steps"] != null && dt.Rows[n]["XSC_Steps"].ToString() != "")
                    {
                        model.XSC_Steps = dt.Rows[n]["XSC_Steps"].ToString();
                    }
                    if (dt.Rows[n]["XSC_State"] != null && dt.Rows[n]["XSC_State"].ToString() != "")
                    {
                        model.XSC_State = dt.Rows[n]["XSC_State"].ToString();
                    }
                    if (dt.Rows[n]["XSC_NextAskTime"] != null && dt.Rows[n]["XSC_NextAskTime"].ToString() != "")
                    {
                        model.XSC_NextAskTime = DateTime.Parse(dt.Rows[n]["XSC_NextAskTime"].ToString());
                    }
                    if (dt.Rows[n]["XSC_SalesChance"] != null && dt.Rows[n]["XSC_SalesChance"].ToString() != "")
                    {
                        model.XSC_SalesChance = dt.Rows[n]["XSC_SalesChance"].ToString();
                    }
                    if (dt.Rows[n]["XSC_Remarks"] != null && dt.Rows[n]["XSC_Remarks"].ToString() != "")
                    {
                        model.XSC_Remarks = dt.Rows[n]["XSC_Remarks"].ToString();
                    }
                    if (dt.Rows[n]["XSC_Creator"] != null && dt.Rows[n]["XSC_Creator"].ToString() != "")
                    {
                        model.XSC_Creator = dt.Rows[n]["XSC_Creator"].ToString();
                    }
                    if (dt.Rows[n]["XSC_CTime"] != null && dt.Rows[n]["XSC_CTime"].ToString() != "")
                    {
                        model.XSC_CTime = DateTime.Parse(dt.Rows[n]["XSC_CTime"].ToString());
                    }
                    if (dt.Rows[n]["XSC_Mender"] != null && dt.Rows[n]["XSC_Mender"].ToString() != "")
                    {
                        model.XSC_Mender = dt.Rows[n]["XSC_Mender"].ToString();
                    }
                    if (dt.Rows[n]["XSC_MTime"] != null && dt.Rows[n]["XSC_MTime"].ToString() != "")
                    {
                        model.XSC_MTime = DateTime.Parse(dt.Rows[n]["XSC_MTime"].ToString());
                    }
                    if (dt.Rows[n]["XSC_Del"] != null && dt.Rows[n]["XSC_Del"].ToString() != "")
                    {
                        model.XSC_Del = int.Parse(dt.Rows[n]["XSC_Del"].ToString());
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

