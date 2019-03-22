using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// Knet_Sampling_OpenBilling
    /// </summary>
    public partial class Knet_Sampling_OpenBilling
    {
        private readonly KNet.DAL.Knet_Sampling_OpenBilling dal = new KNet.DAL.Knet_Sampling_OpenBilling();
        public Knet_Sampling_OpenBilling()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ID)
        {
            return dal.Exists(ID);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add1(KNet.Model.Knet_Sampling_OpenBilling model)
        {
            string DoSqlOrder = " update KNet_Sampling_List set  InState='1',Price=" + model.Price + " where ReID = '" + model.ReID + "'";
            DbHelperSQL.ExecuteSql(DoSqlOrder);
            return dal.Add(model);
        }
        public void Adds(KNet.Model.Knet_Sampling_OpenBilling model)
        {
          
            KNet.DAL.Knet_Sampling_OpenBilling BLL_Details = new KNet.DAL.Knet_Sampling_OpenBilling();
            if (model.Arr_ProductsList != null)
            {
                for (int i = 0; i < model.Arr_ProductsList.Count; i++)
                {
                    KNet.Model.Knet_Sampling_OpenBilling Model_Details = (KNet.Model.Knet_Sampling_OpenBilling)model.Arr_ProductsList[i];
                    string DoSqlOrder = " update KNet_Sampling_List set  InState='1',Price=" + Model_Details.Price + " where ReID = '" + Model_Details.ReID + "'";
                    DbHelperSQL.ExecuteSql(DoSqlOrder);
                    //Model_Details.OrderNo = model.OrderNo;
                    BLL_Details.Add(Model_Details);
                }
            }
        }
        /// <summary>
        /// 修改一条数据
        /// </summary>
        public bool Update(KNet.Model.Knet_Sampling_OpenBilling model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string ID)
        {
            return dal.Delete(ID);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public bool UpdateDel(KNet.Model.Knet_Sampling_OpenBilling model)
        {
            return dal.UpdateDel(model);
        }
        /// <summary>
        /// 批量删除一条数据
        /// </summary>
        public bool DeleteList(string ID)
        {
            return dal.DeleteList(ID);
        }
        /// <summary>
        ///删除父节点数据
        /// </summary>
        public bool DeleteByFID(string ID)
        {
            return dal.DeleteByFID(ID);
        }
        /// <summary>
        ///删除父节点数据
        /// </summary>
       
        /// <summary>
        ///获取类
        /// </summary>
        public KNet.Model.Knet_Sampling_OpenBilling GetModel(string ID)
        {
            return dal.GetModel(ID);
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
