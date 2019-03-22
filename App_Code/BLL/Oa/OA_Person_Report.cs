using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// OA_Person_Report
    /// </summary>
    public partial class OA_Person_Report
    {
        private readonly KNet.DAL.OA_Person_Report dal = new KNet.DAL.OA_Person_Report();
        public OA_Person_Report()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string OPR_ID)
        {
            return dal.Exists(OPR_ID);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(KNet.Model.OA_Person_Report model)
        {
            if (model.Arr_Detail != null)
            {
                KNet.BLL.OA_Person_Report_Project BLL_Project = new OA_Person_Report_Project();
                for (int i = 0; i < model.Arr_Detail.Count; i++)
                {
                    KNet.Model.OA_Person_Report_Project Model = (KNet.Model.OA_Person_Report_Project)model.Arr_Detail[i];
                    BLL_Project.Add(Model);
                }
            }
            if (model.Arr_Detail1 != null)
            {
                KNet.BLL.OA_Person_Report_Details BLL_Details = new OA_Person_Report_Details();
                for (int i = 0; i < model.Arr_Detail1.Count; i++)
                {
                    KNet.Model.OA_Person_Report_Details Model = (KNet.Model.OA_Person_Report_Details)model.Arr_Detail1[i];
                    BLL_Details.Add(Model);
                }
            }
            return dal.Add(model);
        }
        /// <summary>
        /// 修改一条数据
        /// </summary>
        public bool Update(KNet.Model.OA_Person_Report model)
        {

            if (model.Arr_Detail != null)
            {
                KNet.BLL.OA_Person_Report_Project BLL_Project = new OA_Person_Report_Project();
                BLL_Project.DeleteByFID(model.OPR_ID);
                for (int i = 0; i < model.Arr_Detail.Count; i++)
                {
                    KNet.Model.OA_Person_Report_Project Model = (KNet.Model.OA_Person_Report_Project)model.Arr_Detail[i];
                    BLL_Project.Add(Model);
                }
            }
            if (model.Arr_Detail1 != null)
            {

                KNet.BLL.OA_Person_Report_Details BLL_Details = new OA_Person_Report_Details();
                BLL_Details.DeleteByFID(model.OPR_ID);
                for (int i = 0; i < model.Arr_Detail1.Count; i++)
                {
                    KNet.Model.OA_Person_Report_Details Model = (KNet.Model.OA_Person_Report_Details)model.Arr_Detail1[i];
                    BLL_Details.Add(Model);
                }
            }
            return dal.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string OPR_ID)
        {
            return dal.Delete(OPR_ID);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public bool UpdateDel(KNet.Model.OA_Person_Report model)
        {
            return dal.UpdateDel(model);
        }
        /// <summary>
        /// 批量删除一条数据
        /// </summary>
        public bool DeleteList(string OPR_ID)
        {
            return dal.DeleteList(OPR_ID);
        }
        /// <summary>
        ///删除父节点数据
        /// </summary>
        public KNet.Model.OA_Person_Report GetModel(string OPR_ID)
        {
            return dal.GetModel(OPR_ID);
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
