using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// PB_Basic_Feedback
    /// </summary>
    public partial class PB_Basic_Feedback
    {
        private readonly KNet.DAL.PB_Basic_Feedback dal = new KNet.DAL.PB_Basic_Feedback();
        public PB_Basic_Feedback()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PBF_ID)
        {
            return dal.Exists(PBF_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.PB_Basic_Feedback model)
        {
            dal.Add(model);
            if (model.arr_List != null)
            {
                for (int i = 0; i < model.arr_List.Count; i++)
                {
                    KNet.BLL.PB_Basic_Attachment bll_Att = new PB_Basic_Attachment();
                    KNet.Model.PB_Basic_Attachment Model_Att = (KNet.Model.PB_Basic_Attachment)model.arr_List[i];
                    bll_Att.Add(Model_Att);
                }
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.PB_Basic_Feedback model)
        {

            KNet.BLL.PB_Basic_Attachment bll_Att = new PB_Basic_Attachment();
            bll_Att.DeleteByFID(model.PBF_ID);
            if (model.arr_List != null)
            {
                for (int i = 0; i < model.arr_List.Count; i++)
                {
                    KNet.Model.PB_Basic_Attachment Model_Att = (KNet.Model.PB_Basic_Attachment)model.arr_List[i];
                    bll_Att.Add(Model_Att);
                }
            }
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string PBF_ID)
        {

            return dal.Delete(PBF_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string PBF_IDlist)
        {
            return dal.DeleteList(PBF_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.PB_Basic_Feedback GetModel(string PBF_ID)
        {

            return dal.GetModel(PBF_ID);
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
        public List<KNet.Model.PB_Basic_Feedback> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.PB_Basic_Feedback> DataTableToList(DataTable dt)
        {
            List<KNet.Model.PB_Basic_Feedback> modelList = new List<KNet.Model.PB_Basic_Feedback>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.PB_Basic_Feedback model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.PB_Basic_Feedback();
                    if (dt.Rows[n]["PBF_ID"] != null && dt.Rows[n]["PBF_ID"].ToString() != "")
                    {
                        model.PBF_ID = dt.Rows[n]["PBF_ID"].ToString();
                    }
                    if (dt.Rows[n]["PBF_Code"] != null && dt.Rows[n]["PBF_Code"].ToString() != "")
                    {
                        model.PBF_Code = dt.Rows[n]["PBF_Code"].ToString();
                    }
                    if (dt.Rows[n]["PBF_ContentPerson"] != null && dt.Rows[n]["PBF_ContentPerson"].ToString() != "")
                    {
                        model.PBF_ContentPerson = dt.Rows[n]["PBF_ContentPerson"].ToString();
                    }
                    if (dt.Rows[n]["PBF_Type"] != null && dt.Rows[n]["PBF_Type"].ToString() != "")
                    {
                        model.PBF_Type = dt.Rows[n]["PBF_Type"].ToString();
                    }
                    if (dt.Rows[n]["PBF_Details"] != null && dt.Rows[n]["PBF_Details"].ToString() != "")
                    {
                        model.PBF_Details = dt.Rows[n]["PBF_Details"].ToString();
                    }
                    if (dt.Rows[n]["PBF_State"] != null && dt.Rows[n]["PBF_State"].ToString() != "")
                    {
                        model.PBF_State = int.Parse(dt.Rows[n]["PBF_State"].ToString());
                    }
                    if (dt.Rows[n]["PBF_Creator"] != null && dt.Rows[n]["PBF_Creator"].ToString() != "")
                    {
                        model.PBF_Creator = dt.Rows[n]["PBF_Creator"].ToString();
                    }
                    if (dt.Rows[n]["PBF_CTime"] != null && dt.Rows[n]["PBF_CTime"].ToString() != "")
                    {
                        model.PBF_CTime = DateTime.Parse(dt.Rows[n]["PBF_CTime"].ToString());
                    }
                    if (dt.Rows[n]["PBF_Mender"] != null && dt.Rows[n]["PBF_Mender"].ToString() != "")
                    {
                        model.PBF_Mender = dt.Rows[n]["PBF_Mender"].ToString();
                    }
                    if (dt.Rows[n]["PBF_MTime"] != null && dt.Rows[n]["PBF_MTime"].ToString() != "")
                    {
                        model.PBF_MTime = DateTime.Parse(dt.Rows[n]["PBF_MTime"].ToString());
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

