using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// IM_Project_Manage_Details_Logs
    /// </summary>
    public partial class IM_Project_Manage_Details_Logs
    {
        private readonly KNet.DAL.IM_Project_Manage_Details_Logs dal = new KNet.DAL.IM_Project_Manage_Details_Logs();
        public IM_Project_Manage_Details_Logs()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string IPML_ID)
        {
            return dal.Exists(IPML_ID);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(KNet.Model.IM_Project_Manage_Details_Logs model)
        {

            //修改日志
            KNet.BLL.IM_Project_Manage_Details bll_Details = new IM_Project_Manage_Details();
            KNet.Model.IM_Project_Manage_Details Model_Details = bll_Details.GetModel(model.IPML_FID);
            Model_Details.IPMD_Precent = Convert.ToDecimal(model.IPML_Precent / 100.0);
            if (bll_Details.Update(Model_Details))
            {
                return dal.Add(model);
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// 修改一条数据
        /// </summary>
        public bool Update(KNet.Model.IM_Project_Manage_Details_Logs model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string IPML_ID)
        {
            return dal.Delete(IPML_ID);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public bool UpdateDel(KNet.Model.IM_Project_Manage_Details_Logs model)
        {
            return dal.UpdateDel(model);
        }
        /// <summary>
        /// 批量删除一条数据
        /// </summary>
        public bool DeleteList(string IPML_ID)
        {
            return dal.DeleteList(IPML_ID);
        }
        /// <summary>
        ///删除父节点数据
        /// </summary>
        public bool DeleteByFID(string IPML_ID)
        {
            return dal.DeleteByFID(IPML_ID);
        }
        /// <summary>
        ///获取类
        /// </summary>
        public KNet.Model.IM_Project_Manage_Details_Logs GetModel(string IPML_ID)
        {
            return dal.GetModel(IPML_ID);
        }
        /// <summary>
        ///获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
    }
}
