using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// System_PhoneMessage_Manage
    /// </summary>
    public partial class System_PhoneMessage_Manage
    {
        private readonly KNet.DAL.System_PhoneMessage_Manage dal = new KNet.DAL.System_PhoneMessage_Manage();
        public System_PhoneMessage_Manage()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string SPM_ID)
        {
            return dal.Exists(SPM_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.System_PhoneMessage_Manage model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.System_PhoneMessage_Manage model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string SPM_ID)
        {

            return dal.Delete(SPM_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string SPM_IDlist)
        {
            return dal.DeleteList(SPM_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.System_PhoneMessage_Manage GetModel(string SPM_ID)
        {

            return dal.GetModel(SPM_ID);
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
        public List<KNet.Model.System_PhoneMessage_Manage> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.System_PhoneMessage_Manage> DataTableToList(DataTable dt)
        {
            List<KNet.Model.System_PhoneMessage_Manage> modelList = new List<KNet.Model.System_PhoneMessage_Manage>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.System_PhoneMessage_Manage model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.System_PhoneMessage_Manage();
                    if (dt.Rows[n]["SPM_ID"] != null && dt.Rows[n]["SPM_ID"].ToString() != "")
                    {
                        model.SPM_ID = dt.Rows[n]["SPM_ID"].ToString();
                    }
                    if (dt.Rows[n]["SPM_ReceiveID"] != null && dt.Rows[n]["SPM_ReceiveID"].ToString() != "")
                    {
                        model.SPM_ReceiveID = dt.Rows[n]["SPM_ReceiveID"].ToString();
                    }
                    if (dt.Rows[n]["SPM_ReceivePhone"] != null && dt.Rows[n]["SPM_ReceivePhone"].ToString() != "")
                    {
                        model.SPM_ReceivePhone = dt.Rows[n]["SPM_ReceivePhone"].ToString();
                    }
                    if (dt.Rows[n]["SPM_ReceiveName"] != null && dt.Rows[n]["SPM_ReceiveName"].ToString() != "")
                    {
                        model.SPM_ReceiveName = dt.Rows[n]["SPM_ReceiveName"].ToString();
                    }
                    if (dt.Rows[n]["SPM_SenderID"] != null && dt.Rows[n]["SPM_SenderID"].ToString() != "")
                    {
                        model.SPM_SenderID = dt.Rows[n]["SPM_SenderID"].ToString();
                    }
                    if (dt.Rows[n]["SPM_State"] != null && dt.Rows[n]["SPM_State"].ToString() != "")
                    {
                        model.SPM_State = int.Parse(dt.Rows[n]["SPM_State"].ToString());
                    }
                    if (dt.Rows[n]["SPM_Detail"] != null && dt.Rows[n]["SPM_Detail"].ToString() != "")
                    {
                        model.SPM_Detail = dt.Rows[n]["SPM_Detail"].ToString();
                    }
                    if (dt.Rows[n]["SPM_SendTime"] != null && dt.Rows[n]["SPM_SendTime"].ToString() != "")
                    {
                        model.SPM_SendTime = DateTime.Parse(dt.Rows[n]["SPM_SendTime"].ToString());
                    }
                    if (dt.Rows[n]["SPM_Sender"] != null && dt.Rows[n]["SPM_Sender"].ToString() != "")
                    {
                        model.SPM_Sender = dt.Rows[n]["SPM_Sender"].ToString();
                    }
                    if (dt.Rows[n]["SPM_Type"] != null && dt.Rows[n]["SPM_Type"].ToString() != "")
                    {
                        model.SPM_Type = int.Parse(dt.Rows[n]["SPM_Type"].ToString());
                    }
                    if (dt.Rows[n]["SPM_Del"] != null && dt.Rows[n]["SPM_Del"].ToString() != "")
                    {
                        model.SPM_Del = int.Parse(dt.Rows[n]["SPM_Del"].ToString());
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

