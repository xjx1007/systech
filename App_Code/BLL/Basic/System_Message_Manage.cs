using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using KNet.Model;

namespace KNet.BLL
{
    /// <summary>
    /// System_Message_Manage
    /// </summary>
    public partial class System_Message_Manage
    {
        private readonly KNet.DAL.System_Message_Manage dal = new KNet.DAL.System_Message_Manage();
        public System_Message_Manage()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(KNet.Model.System_Message_Manage model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.System_Message_Manage model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.System_Message_Manage model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateState(KNet.Model.System_Message_Manage model)
        {
            return dal.UpdateState(model);
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        public bool UpdateUnRead(KNet.Model.System_Message_Manage model)
        {
            return dal.UpdateUnRead(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string SMM_ID)
        {

            return dal.Delete(SMM_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string SMM_IDlist)
        {
            return dal.DeleteList(SMM_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.System_Message_Manage GetModel(string SMM_ID)
        {

            return dal.GetModel(SMM_ID);
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
        public List<KNet.Model.System_Message_Manage> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.System_Message_Manage> DataTableToList(DataTable dt)
        {
            List<KNet.Model.System_Message_Manage> modelList = new List<KNet.Model.System_Message_Manage>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.System_Message_Manage model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.System_Message_Manage();
                    if (dt.Rows[n]["SMM_ID"] != null && dt.Rows[n]["SMM_ID"].ToString() != "")
                    {
                        model.SMM_ID = dt.Rows[n]["SMM_ID"].ToString();
                    }
                    if (dt.Rows[n]["SMM_SenderID"] != null && dt.Rows[n]["SMM_SenderID"].ToString() != "")
                    {
                        model.SMM_SenderID = dt.Rows[n]["SMM_SenderID"].ToString();
                    }
                    if (dt.Rows[n]["SMM_ReceiveID"] != null && dt.Rows[n]["SMM_ReceiveID"].ToString() != "")
                    {
                        model.SMM_ReceiveID = dt.Rows[n]["SMM_ReceiveID"].ToString();
                    }
                    if (dt.Rows[n]["SMM_State"] != null && dt.Rows[n]["SMM_State"].ToString() != "")
                    {
                        model.SMM_State = int.Parse(dt.Rows[n]["SMM_State"].ToString());
                    }
                    if (dt.Rows[n]["SMM_Detail"] != null && dt.Rows[n]["SMM_Detail"].ToString() != "")
                    {
                        model.SMM_Detail = dt.Rows[n]["SMM_Detail"].ToString();
                    }
                    if (dt.Rows[n]["SMM_Del"] != null && dt.Rows[n]["SMM_Del"].ToString() != "")
                    {
                        model.SMM_Del = int.Parse(dt.Rows[n]["SMM_Del"].ToString());
                    }
                    if (dt.Rows[n]["SMM_Title"] != null && dt.Rows[n]["SMM_Title"].ToString() != "")
                    {
                        model.SMM_Title = dt.Rows[n]["SMM_Title"].ToString();
                    }
                    if (dt.Rows[n]["SMM_SendTime"] != null && dt.Rows[n]["SMM_SendTime"].ToString() != "")
                    {
                        model.SMM_SendTime = DateTime.Parse(dt.Rows[n]["SMM_SendTime"].ToString());
                    }
                    if (dt.Rows[n]["SMM_LookTime"] != null && dt.Rows[n]["SMM_LookTime"].ToString() != "")
                    {
                        model.SMM_LookTime = DateTime.Parse(dt.Rows[n]["SMM_LookTime"].ToString());
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