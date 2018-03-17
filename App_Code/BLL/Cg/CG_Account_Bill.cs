using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// CG_Account_Bill
    /// </summary>
    public partial class CG_Account_Bill
    {
        private readonly KNet.DAL.CG_Account_Bill dal = new KNet.DAL.CG_Account_Bill();
        public CG_Account_Bill()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CAB_ID)
        {
            return dal.Exists(CAB_ID);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(KNet.Model.CG_Account_Bill model)
        {
            try
            {
                KNet.BLL.CG_Account_Bill_Details Bll_Details = new CG_Account_Bill_Details();
                KNet.BLL.CG_Account_Bill_Outimes Bll_Outimes = new CG_Account_Bill_Outimes();
                if (dal.Add(model))
                {
                    if (model.Arr_Detail.Count > 0)
                    {
                        for (int i = 0; i < model.Arr_Detail.Count; i++)
                        {
                            KNet.Model.CG_Account_Bill_Details Model_Details = (KNet.Model.CG_Account_Bill_Details)model.Arr_Detail[i];
                            Bll_Details.Add(Model_Details);
                        }
                    }
                    if (model.arr_OutTimes.Count > 0)
                    {

                        for (int i = 0; i < model.arr_OutTimes.Count; i++)
                        {
                            KNet.Model.CG_Account_Bill_Outimes Model_Outimes = (KNet.Model.CG_Account_Bill_Outimes)model.arr_OutTimes[i];
                            Bll_Outimes.Add(Model_Outimes);
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 修改一条数据
        /// </summary>
        public bool Update(KNet.Model.CG_Account_Bill model)
        {
            try
            {
                KNet.BLL.CG_Account_Bill_Details Bll_Details = new CG_Account_Bill_Details();
                KNet.BLL.CG_Account_Bill_Outimes Bll_Outimes = new CG_Account_Bill_Outimes();
                if (dal.Update(model))
                {
                    if (model.Arr_Detail.Count > 0)
                    {
                        Bll_Details.DeleteByFID(model.CAB_ID);
                        for (int i = 0; i < model.Arr_Detail.Count; i++)
                        {
                            KNet.Model.CG_Account_Bill_Details Model_Details = (KNet.Model.CG_Account_Bill_Details)model.Arr_Detail[i];
                            Bll_Details.Add(Model_Details);
                        }
                    }
                    if (model.arr_OutTimes.Count > 0)
                    {
                        Bll_Outimes.DeleteByFID(model.CAB_ID);
                        for (int i = 0; i < model.arr_OutTimes.Count; i++)
                        {
                            KNet.Model.CG_Account_Bill_Outimes Model_Outimes = (KNet.Model.CG_Account_Bill_Outimes)model.arr_OutTimes[i];
                            Bll_Outimes.Add(Model_Outimes);
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string CAB_ID)
        {
            return dal.Delete(CAB_ID);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public bool UpdateDel(KNet.Model.CG_Account_Bill model)
        {
            return dal.UpdateDel(model);
        }
        /// <summary>
        /// 批量删除一条数据
        /// </summary>
        public bool DeleteList(string CAB_ID)
        {
            return dal.DeleteList(CAB_ID);
        }
        /// <summary>
        ///删除父节点数据
        /// </summary>
        public bool DeleteByFID(string CAB_ID)
        {
            return dal.DeleteByFID(CAB_ID);
        }
        /// <summary>
        ///删除父节点数据
        /// </summary>
        public KNet.Model.CG_Account_Bill GetModel(string CAB_ID)
        {
            return dal.GetModel(CAB_ID);
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
