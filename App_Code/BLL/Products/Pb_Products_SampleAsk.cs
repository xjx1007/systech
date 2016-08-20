using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// Pb_Products_SampleAsk
    /// </summary>
    public partial class Pb_Products_SampleAsk
    {
        private readonly KNet.DAL.Pb_Products_SampleAsk dal = new KNet.DAL.Pb_Products_SampleAsk();
        public Pb_Products_SampleAsk()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PPA_ID)
        {
            return dal.Exists(PPA_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Pb_Products_SampleAsk model)
        {
            KNet.BLL.Pb_Products_Sample BLL_Sample = new KNet.BLL.Pb_Products_Sample();
            KNet.Model.Pb_Products_Sample Model_Sample = new KNet.Model.Pb_Products_Sample();
            Model_Sample.PPS_Dept = model.PPA_Type.ToString();
            Model_Sample.PPS_ID = model.PPA_SampleID;
            BLL_Sample.UpdateDept(Model_Sample);
            dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Pb_Products_SampleAsk model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string PPA_ID)
        {

            return dal.Delete(PPA_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string PPA_IDlist)
        {
            return dal.DeleteList(PPA_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Pb_Products_SampleAsk GetModel(string PPA_ID)
        {
            return dal.GetModel(PPA_ID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Pb_Products_SampleAsk GetModelBySampleID(string PPA_SampleID)
        {
            return dal.GetModelBySampleID(PPA_SampleID);
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
        public List<KNet.Model.Pb_Products_SampleAsk> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.Pb_Products_SampleAsk> DataTableToList(DataTable dt)
        {
            List<KNet.Model.Pb_Products_SampleAsk> modelList = new List<KNet.Model.Pb_Products_SampleAsk>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.Pb_Products_SampleAsk model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.Pb_Products_SampleAsk();
                    if (dt.Rows[n]["PPA_ID"] != null && dt.Rows[n]["PPA_ID"].ToString() != "")
                    {
                        model.PPA_ID = dt.Rows[n]["PPA_ID"].ToString();
                    }
                    if (dt.Rows[n]["PPA_ProdutsBarCode"] != null && dt.Rows[n]["PPA_ProdutsBarCode"].ToString() != "")
                    {
                        model.PPA_ProdutsBarCode = dt.Rows[n]["PPA_ProdutsBarCode"].ToString();
                    }
                    if (dt.Rows[n]["PPA_Stime"] != null && dt.Rows[n]["PPA_Stime"].ToString() != "")
                    {
                        model.PPA_Stime = DateTime.Parse(dt.Rows[n]["PPA_Stime"].ToString());
                    }
                    if (dt.Rows[n]["PPA_Number"] != null && dt.Rows[n]["PPA_Number"].ToString() != "")
                    {
                        model.PPA_Number = int.Parse(dt.Rows[n]["PPA_Number"].ToString());
                    }
                    if (dt.Rows[n]["PPA_Use"] != null && dt.Rows[n]["PPA_Use"].ToString() != "")
                    {
                        model.PPA_Use = dt.Rows[n]["PPA_Use"].ToString();
                    }
                    if (dt.Rows[n]["PPA_DutyPerson"] != null && dt.Rows[n]["PPA_DutyPerson"].ToString() != "")
                    {
                        model.PPA_DutyPerson = dt.Rows[n]["PPA_DutyPerson"].ToString();
                    }
                    if (dt.Rows[n]["PPA_Type"] != null && dt.Rows[n]["PPA_Type"].ToString() != "")
                    {
                        model.PPA_Type = int.Parse(dt.Rows[n]["PPA_Type"].ToString());
                    }
                    if (dt.Rows[n]["PPA_IsBack"] != null && dt.Rows[n]["PPA_IsBack"].ToString() != "")
                    {
                        model.PPA_IsBack = int.Parse(dt.Rows[n]["PPA_IsBack"].ToString());
                    }
                    if (dt.Rows[n]["PPA_Remarks"] != null && dt.Rows[n]["PPA_Remarks"].ToString() != "")
                    {
                        model.PPA_Remarks = dt.Rows[n]["PPA_Remarks"].ToString();
                    }
                    if (dt.Rows[n]["PPA_CTime"] != null && dt.Rows[n]["PPA_CTime"].ToString() != "")
                    {
                        model.PPA_CTime = DateTime.Parse(dt.Rows[n]["PPA_CTime"].ToString());
                    }
                    if (dt.Rows[n]["PPA_Creator"] != null && dt.Rows[n]["PPA_Creator"].ToString() != "")
                    {
                        model.PPA_Creator = dt.Rows[n]["PPA_Creator"].ToString();
                    }
                    if (dt.Rows[n]["PPA_MTime"] != null && dt.Rows[n]["PPA_MTime"].ToString() != "")
                    {
                        model.PPA_MTime = DateTime.Parse(dt.Rows[n]["PPA_MTime"].ToString());
                    }
                    if (dt.Rows[n]["PPA_Mender"] != null && dt.Rows[n]["PPA_Mender"].ToString() != "")
                    {
                        model.PPA_Mender = dt.Rows[n]["PPA_Mender"].ToString();
                    }
                    if (dt.Rows[n]["PPA_Del"] != null && dt.Rows[n]["PPA_Del"].ToString() != "")
                    {
                        model.PPA_Del = int.Parse(dt.Rows[n]["PPA_Del"].ToString());
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

